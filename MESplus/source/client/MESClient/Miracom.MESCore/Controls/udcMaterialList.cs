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
    public partial class udcMaterialList : UserControl
    {
        private char m_cond_c_step;
        private string m_cond_s_ext_factory;

        private MatListViewType m_view_type;
        private string m_select_mat_id;
        private int m_select_version;

        public udcMaterialList()
        {
            InitializeComponent();

            Init();
        }

        #region "Control Events"

        private System.EventHandler BeforeGetListEvent;
        public event System.EventHandler BeforeGetList
        {
            add
            {
                BeforeGetListEvent = (System.EventHandler)System.Delegate.Combine(BeforeGetListEvent, value);
            }
            remove
            {
                BeforeGetListEvent = (System.EventHandler)System.Delegate.Remove(BeforeGetListEvent, value);
            }
        }

        private System.EventHandler AfterGetListEvent;
        public event System.EventHandler AfterGetList
        {
            add
            {
                AfterGetListEvent = (System.EventHandler)System.Delegate.Combine(AfterGetListEvent, value);
            }
            remove
            {
                AfterGetListEvent = (System.EventHandler)System.Delegate.Remove(AfterGetListEvent, value);
            }
        }

        private System.EventHandler SelectedIndexChangedEvent;
        public event System.EventHandler SelectedIndexChanged
        {
            add
            {
                SelectedIndexChangedEvent = (System.EventHandler)System.Delegate.Combine(SelectedIndexChangedEvent, value);
            }
            remove
            {
                SelectedIndexChangedEvent = (System.EventHandler)System.Delegate.Remove(SelectedIndexChangedEvent, value);
            }
        }

        private TreeViewEventHandler AfterSelectEvent;
        public event TreeViewEventHandler AfterSelect
        {
            add
            {
                AfterSelectEvent = (TreeViewEventHandler)System.Delegate.Combine(AfterSelectEvent, value);
            }
            remove
            {
                AfterSelectEvent = (TreeViewEventHandler)System.Delegate.Remove(AfterSelectEvent, value);
            }
        }

        private void lisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                m_select_mat_id = SelectedItem.Text;
                m_select_version = MPCF.ToInt(SelectedItem.SubItems[1].Text);

                if (SelectedIndexChangedEvent != null)
                    SelectedIndexChangedEvent(this, e);
            }
        }

        private void treList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            char cDeleteFlag;
            char cDeactiveFlag;

            if (e.Action == TreeViewAction.Unknown) return;
            if (e.Node == null) return;

            if (e.Node.Parent == null)
            {
                m_select_mat_id = e.Node.Text;
                m_select_version = 0;

                if (e.Node.GetNodeCount(true) < 1)
                {
                    cDeleteFlag = (IncludeDeleteMaterial == true) ? '%' : ' ';
                    cDeactiveFlag = (IncludeDeactiveMaterial == true) ? '%' : ' ';
                    WIPLIST.ViewMaterialVersionList(treMaterialList, '1', m_select_mat_id, MaterialType, cDeleteFlag, cDeactiveFlag, e.Node, ListCond_ExtFactory);
                }
            }
            else
            {
                m_select_mat_id = e.Node.Parent.Text;
                m_select_version = MPCF.ToInt(MPCF.SubtractString(e.Node.Text, ":", false, false));
            }
            
            if (AfterSelectEvent != null)
                AfterSelectEvent(this, e);
        }

        #endregion

        #region "Properties"

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedItem
        {
            get
            {
                if (lisMaterialList.SelectedItems.Count > 0)
                    return lisMaterialList.SelectedItems[0];
                else
                    return null;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeNode SelectedNode
        {
            get
            {
                return treMaterialList.SelectedNode;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return m_select_mat_id;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Version
        {
            get
            {
                return m_select_version;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView GetListView
        {
            get
            {
                return this.lisMaterialList;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeView GetTreeView
        {
            get
            {
                return this.treMaterialList;
            }
        }


        public new Color BackColor
        {
            get
            {
                return lisMaterialList.BackColor;
            }
            set
            {
                pnlMaterialTop.BackColor = value;
                pnlMaterialMid.BackColor = value;
                lisMaterialList.BackColor = value;
                treMaterialList.BackColor = value;
            }
        }

        /* 2013.06.12. Aiden. Filter 추가로 Panel Size 로직을 분리함. */
        private void ChangeTopPanelSize()
        {
            if (VisibleMaterialType == false && VisibleDefaultFilter == false && VisibleIncludeDeleteMaterialCheck == false)
            {
                pnlMaterialTop.Height = 0;
            }
            else if (VisibleMaterialType == false && VisibleDefaultFilter == false && VisibleIncludeDeleteMaterialCheck == true)
            {
                pnlMaterialTop.Height = 50;

                pnlMaterialDeleteCondition.Top = 10;
            }
            else if (VisibleMaterialType == true && VisibleDefaultFilter == false && VisibleIncludeDeleteMaterialCheck == false)
            {
                pnlMaterialTop.Height = 35;
            }
            else if (VisibleMaterialType == false && VisibleDefaultFilter == true && VisibleIncludeDeleteMaterialCheck == false)
            {
                pnlMaterialTop.Height = 35;

                pnlMaterialFilter.Top = 10;
            }
            else if (VisibleMaterialType == true && VisibleDefaultFilter == true && VisibleIncludeDeleteMaterialCheck == false)
            {
                pnlMaterialTop.Height = 57;

                pnlMaterialFilter.Top = 33;
            }
            else if (VisibleMaterialType == true && VisibleDefaultFilter == false && VisibleIncludeDeleteMaterialCheck == true)
            {
                pnlMaterialTop.Height = 72;

                pnlMaterialDeleteCondition.Top = 33;
            }
            else if (VisibleMaterialType == false && VisibleDefaultFilter == true && VisibleIncludeDeleteMaterialCheck == true)
            {
                pnlMaterialTop.Height = 72;

                pnlMaterialFilter.Top = 10;
                pnlMaterialDeleteCondition.Top = 33;
            }
            else if (VisibleMaterialType == true && VisibleDefaultFilter == true && VisibleIncludeDeleteMaterialCheck == true)
            {
                pnlMaterialTop.Height = 95;

                pnlMaterialFilter.Top = 33;
                pnlMaterialDeleteCondition.Top = 56;
            }
        }

        public bool VisibleMaterialType
        {
            get
            {
                return pnlMaterialType.Visible;
            }
            set
            {
                pnlMaterialType.Visible = value;
                ChangeTopPanelSize();
            }
        }

        public bool VisibleIncludeDeleteMaterialCheck
        {
            get
            {
                return pnlMaterialDeleteCondition.Visible;
            }
            set
            {
                pnlMaterialDeleteCondition.Visible = value;
                ChangeTopPanelSize();
            }
        }

        /* 2013.06.12. Aiden. VisibleDefaultFilter Property 추가 */
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool VisibleDefaultFilter
        {
            get
            {
                return pnlMaterialFilter.Visible;
            }
            set
            {
                pnlMaterialFilter.Visible = value;
                ChangeTopPanelSize();
            }
        }

        public bool VisibleViewType
        {
            get
            {
                return pnlMaterialViewType.Visible;
            }
            set
            {
                pnlMaterialViewType.Visible = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MatListViewType ViewType
        {
            get
            {
                return m_view_type;
            }
            set
            {
                m_view_type = value;

                switch (m_view_type)
                {
                    case MatListViewType.LastActiveVersion:
                        rbtLastActive.Checked = true;
                        lisMaterialList.Visible = true;
                        treMaterialList.Visible = false;
                        break;
                    case MatListViewType.TreeViewList:
                        rbtTree.Checked = true;
                        lisMaterialList.Visible = false;
                        treMaterialList.Visible = true;
                        break;
                    case MatListViewType.AllVersion:
                        rbtAllVersion.Checked = true;
                        lisMaterialList.Visible = true;
                        treMaterialList.Visible = false;
                        break;
                }
            }
        }

        public string MaterialType
        {
            get
            {
                return cdvMaterialType.Text;
            }
            set
            {
                cdvMaterialType.Text = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IncludeDeleteMaterial
        {
            get
            {
                return chkIncludeDeletedMaterial.Checked;
            }
            set
            {
                chkIncludeDeletedMaterial.Checked = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IncludeDeactiveMaterial
        {
            get
            {
                return chkIncludeDeactiveMaterial.Checked;
            }
            set
            {
                chkIncludeDeactiveMaterial.Checked = value;
            }
        }
        
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ListCount
        {
            get
            {
                int iCount = 0;

                switch (m_view_type)
                {
                    case MatListViewType.LastActiveVersion:
                    case MatListViewType.AllVersion:
                        iCount = lisMaterialList.Items.Count;
                        break;

                    case MatListViewType.TreeViewList:
                        iCount = treMaterialList.Nodes.Count;
                        break;
                }

                return iCount;
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
                if (txtFilter.Text == null) txtFilter.Text = "";
                return txtFilter.Text;
            }
            set
            {
                txtFilter.Text = value;
            }
        }

        #endregion

        private void udcOperation_FontChanged(object sender, EventArgs e)
        {
            pnlMaterialViewType.Font = this.Font;
            pnlMaterialList.Font = this.Font;
        }

        private void rbtViewType_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                if (((RadioButton)sender).Name == "rbtLastActive")
                {
                    m_view_type = MatListViewType.LastActiveVersion;
                    lisMaterialList.Visible = true;
                    treMaterialList.Visible = false;
                }
                else if (((RadioButton)sender).Name == "rbtTree")
                {
                    m_view_type = MatListViewType.TreeViewList;
                    lisMaterialList.Visible = false;
                    treMaterialList.Visible = true;
                }
                else if (((RadioButton)sender).Name == "rbtAllVersion")
                {
                    m_view_type = MatListViewType.AllVersion;
                    lisMaterialList.Visible = true;
                    treMaterialList.Visible = false;
                }

                ViewList();
            }
        }

        private void cdvMaterialType_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            ViewList();
        }

        private void cdvMaterialType_ButtonPress(object sender, EventArgs e)
        {
            cdvMaterialType.Init();
            MPCF.InitListView(cdvMaterialType.GetListView);
            cdvMaterialType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvMaterialType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvMaterialType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvMaterialType.GetListView, '1', MPGC.MP_WIP_MATERIAL_TYPE);
            cdvMaterialType.InsertEmptyRow(0, 1);
        }

        private void chkIncludeMaterial_CheckedChanged(object sender, EventArgs e)
        {
            ViewList();
        }



        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";
            txtFilter.Text = "";

            m_view_type = MatListViewType.LastActiveVersion;
            m_select_mat_id = "";
            m_select_version = 0;

            VisibleMaterialType = true;
            VisibleIncludeDeleteMaterialCheck = true;
            VisibleViewType = true;

            /* 2013.06.17. Aiden. Material Filter 가 필요한지 Global Option 확인 */
            VisibleDefaultFilter = true;
            if (MPCR.IsInDesignMode(this) == false)
            {
                VisibleDefaultFilter = MPGO.RequireMaterialFilter();
            }

            MPCF.InitListView(lisMaterialList);
            MPCF.InitTreeView(treMaterialList);
        }

        public void ViewList()
        {
            char cDeleteFlag;
            char cDeactiveFlag;

            /* 2013.06.12. Aiden. VisibleDefaultFilter 가 true 인 경우 Filter 가 없으면 에러 */
            if (VisibleDefaultFilter == true && MPCF.Trim(ListCond_Filter) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtFilter.Focus();
                return;
            }

            cDeleteFlag = (IncludeDeleteMaterial == true) ? '%' : ' ';
            cDeactiveFlag = (IncludeDeactiveMaterial == true) ? '%' : ' ';

            if (BeforeGetListEvent != null)
                BeforeGetListEvent(this, new EventArgs());

            switch (m_view_type)
            {
                case MatListViewType.LastActiveVersion:
                    WIPLIST.ViewMaterialList(lisMaterialList, '1', MaterialType, cDeleteFlag, cDeactiveFlag, ListCond_Filter, true, null, ListCond_ExtFactory);
                    break;

                case MatListViewType.TreeViewList:
                    MPCF.ClearList(treMaterialList, false);
                    WIPLIST.ViewMaterialList(treMaterialList, '1', MaterialType, cDeleteFlag, cDeactiveFlag, ListCond_Filter, false, null, ListCond_ExtFactory);
                    break;

                case MatListViewType.AllVersion:
                    WIPLIST.ViewMaterialList(lisMaterialList, '2', MaterialType, cDeleteFlag, cDeactiveFlag, ListCond_Filter, true, null, ListCond_ExtFactory);
                    break;
            }

            if (string.IsNullOrEmpty(Text) == false && Version > 0)
            {
                FindMaterial(Text, Version.ToString(), false);
            }

            if (AfterGetListEvent != null)
                AfterGetListEvent(this, new EventArgs());

        }

        public bool FindMaterial(string sMatID, string sVersion, bool bPartial)
        {
            bool bRet = false;

            switch (m_view_type)
            {
                case MatListViewType.TreeViewList:
                    TreeNode tNode;

                    if (bPartial == true)
                    {
                        int iCurNode;
                        int i;

                        iCurNode = 0;
                        tNode = treMaterialList.SelectedNode;

                        if (tNode != null)
                        {
                            if (treMaterialList.SelectedNode.Parent != null)
                                tNode = treMaterialList.SelectedNode.Parent;

                            iCurNode = tNode.Index + 1;
                        }

                        for (i = iCurNode; i < treMaterialList.Nodes.Count; i++)
                        {
                            tNode = treMaterialList.Nodes[i];

                            if (tNode.Text.StartsWith(sMatID) == true)
                            {
                                treMaterialList.SelectedNode = tNode;
                                tNode.EnsureVisible();
                                break;
                            }
                        }

                        if (i >= treMaterialList.Nodes.Count)
                        {
                            for (i = 0; i < treMaterialList.Nodes.Count; i++)
                            {
                                tNode = treMaterialList.Nodes[i];

                                if (tNode.Text.StartsWith(sMatID) == true)
                                {
                                    treMaterialList.SelectedNode = tNode;
                                    tNode.EnsureVisible();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        tNode = MPCF.FindTreeNode(treMaterialList, sMatID + treMaterialList.PathSeparator + sVersion);
                        if (tNode != null)
                        {
                            treMaterialList.SelectedNode = tNode;
                            tNode.EnsureVisible();
                            bRet = true;
                        }
                    }
                    break;

                default:
                    if (bPartial == true)
                    {
                        if (MPCF.FindListItemNextPartial(lisMaterialList, sMatID, true, false) > 0)
                        {
                            bRet = true;
                        }
                    }
                    else
                    {
                        if (MPCF.FindListItem(lisMaterialList, sMatID, 0, sVersion, 1, false) == true)
                        {
                            bRet = true;
                        }
                    }
                    break;
            }

            return bRet;
        }

        /* 2013.06.12. Aiden. Filter 에서 엔터키 입력시 자동 조회하도록 추가 */
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ViewList();
            }
        }


    }


    public enum MatListViewType
    {
        LastActiveVersion = 0,
        TreeViewList = 1,
        AllVersion = 2
    }
}
