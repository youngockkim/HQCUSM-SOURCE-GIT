using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Miracom.UI;
using Miracom.CliFrx;

namespace Miracom.MESCore.Controls
{
    public partial class udcResourceTreeList : UserControl
    {
        private char m_cond_c_step;
        private string m_cond_s_filter;
        private string m_cond_s_ext_factory;

        private ResourceSelectLevel m_select_level;
        private TreeSelectedItem m_selected_item;

        private string m_select_res;
        private string m_select_res_grp;
        private string m_select_res_type;
        
        private bool mb_changing_level;
        private bool mb_visible_resource_include_delete;
        private bool mb_visible_res;
        private bool mb_visible_res_grp;
        private bool mb_visible_res_type;
        private bool mb_visible_set_data;

        public udcResourceTreeList()
        {
            InitializeComponent();

            Init();
        }

        #region "Control Events"

        private System.EventHandler BeforeGetTreeEvent;
        /// <summary>
        /// 최상위 Node 리스트를 가져오기 전 이벤트
        /// </summary>
        public event System.EventHandler BeforeGetTree
        {
            add
            {
                BeforeGetTreeEvent = (System.EventHandler)System.Delegate.Combine(BeforeGetTreeEvent, value);
            }
            remove
            {
                BeforeGetTreeEvent = (System.EventHandler)System.Delegate.Remove(BeforeGetTreeEvent, value);
            }
        }

        private System.EventHandler AfterGetTreeEvent;
        /// <summary>
        /// 최상위 Node 리스트를 가져온 후 이벤트
        /// </summary>
        public event System.EventHandler AfterGetTree
        {
            add
            {
                AfterGetTreeEvent = (System.EventHandler)System.Delegate.Combine(AfterGetTreeEvent, value);
            }
            remove
            {
                AfterGetTreeEvent = (System.EventHandler)System.Delegate.Remove(AfterGetTreeEvent, value);
            }
        }

        private TreeViewEventHandler AfterSelectEvent;
        /// <summary>
        /// 각 Node를 선택한 후 이벤트
        /// </summary>
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

        private TreeViewEventHandler LevelItemSelectEvent;
        /// <summary>
        /// 각 Level의 말단 Node를 선택한 후 이벤트
        /// </summary>
        public event TreeViewEventHandler LevelItemSelect
        {
            add
            {
                LevelItemSelectEvent = (TreeViewEventHandler)System.Delegate.Combine(LevelItemSelectEvent, value);
            }
            remove
            {
                LevelItemSelectEvent = (TreeViewEventHandler)System.Delegate.Remove(LevelItemSelectEvent, value);
            }
        }

        private System.EventHandler GetOnlySetDataEvent;
        /// <summary>
        /// 이미 셋업된 조건 리스트를 가져오기 위한 이벤트
        /// </summary>
        public event System.EventHandler GetOnlySetData
        {
            add
            {
                GetOnlySetDataEvent = (System.EventHandler)System.Delegate.Combine(GetOnlySetDataEvent, value);
            }
            remove
            {
                GetOnlySetDataEvent = (System.EventHandler)System.Delegate.Remove(GetOnlySetDataEvent, value);
            }
        }

        private System.EventHandler SetDataSelectedIndexChangedEvent;
        /// <summary>
        /// 이미 셋업된 조건 리스트의 선택이 변경됬을 경우
        /// </summary>
        public event System.EventHandler SetDataSelectedIndexChanged
        {
            add
            {
                SetDataSelectedIndexChangedEvent = (System.EventHandler)System.Delegate.Combine(SetDataSelectedIndexChangedEvent, value);
            }
            remove
            {
                SetDataSelectedIndexChangedEvent = (System.EventHandler)System.Delegate.Remove(SetDataSelectedIndexChangedEvent, value);
            }
        }

        private System.EventHandler SelectLevelChangedEvent;
        /// <summary>
        /// MFO Level이 변경되었을때 발생
        /// </summary>
        public event System.EventHandler SelectLevelChanged
        {
            add
            {
                SelectLevelChangedEvent = (System.EventHandler)System.Delegate.Combine(SelectLevelChangedEvent, value);
            }
            remove
            {
                SelectLevelChangedEvent = (System.EventHandler)System.Delegate.Remove(SelectLevelChangedEvent, value);
            }
        }

        private void treResourceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool b_raise_level_item_event;

            m_selected_item = TreeSelectedItem.None;

            if (e.Action == TreeViewAction.Unknown) return;
            if (e.Node == null) return;
            if (m_select_level == ResourceSelectLevel.NONE) return;

            m_selected_item = TreeSelectedItem.Another;
            b_raise_level_item_event = false;

            switch (m_select_level)
            {
                case ResourceSelectLevel.R:
                    switch (e.Node.Level)
                    {
                        case 0:
                            GetResourceInfo(e.Node);
                            b_raise_level_item_event = true;
                            break;
                    }
                    break;
                case ResourceSelectLevel.GR:
                    switch (e.Node.Level)
                    {
                        case 0:
                            GetResourceList(e.Node, true, false);
                            break;
                        case 1:
                            GetGroupTypeInfo(e.Node, true, false);
                            b_raise_level_item_event = true;
                            break;
                    }
                    break;
                case ResourceSelectLevel.TR:
                    switch (e.Node.Level)
                    {
                        case 0:
                            GetResourceList(e.Node, false, true);
                            break;
                        case 1:
                            GetGroupTypeInfo(e.Node, false, true);
                            b_raise_level_item_event = true;
                            break;
                    }
                    break;
            }

            if (m_selected_item == TreeSelectedItem.Another)
            {
                int i_raise_level_item_event_level;
                int i;
                TreeNode t_node;

                i_raise_level_item_event_level = 0;
                switch (m_select_level)
                {
                    case ResourceSelectLevel.R:
                        i_raise_level_item_event_level = 0;
                        break;
                    case ResourceSelectLevel.GR:
                    case ResourceSelectLevel.TR:
                        i_raise_level_item_event_level = 1;
                        break;                }

                t_node = e.Node;
                for (i = e.Node.Level; i > i_raise_level_item_event_level; i--)
                    t_node = t_node.Parent;

                switch (m_select_level)
                {
                    case ResourceSelectLevel.R:
                        GetResourceInfo(t_node);
                        break;
                    case ResourceSelectLevel.GR:
                        GetGroupTypeInfo(t_node, true, false);
                        break;
                    case ResourceSelectLevel.TR:
                        GetGroupTypeInfo(t_node, false, true);
                        break;
                }

                m_selected_item = TreeSelectedItem.Another;
            }

            if (b_raise_level_item_event == true)
            {
                if (LevelItemSelectEvent != null)
                    LevelItemSelectEvent(this, e);
            }

            if (AfterSelectEvent != null)
                AfterSelectEvent(this, e);

        }

        #endregion

        #region "Properties"
        /// <summary>
        /// 현재 선택되어진 Node
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeNode SelectedNode
        {
            get
            {
                return treResourceList.SelectedNode;
            }
        }

        /// <summary>
        /// 현 Level 에서 선택된 Material ID
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Resource
        {
            get
            {
                return m_select_res;
            }
        }

        /// <summary>
        /// 현 Level 에서 선택된 Material Version
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResourceGroup
        {
            get
            {
                return m_select_res_grp;
            }
        }

        /// <summary>
        /// 현 Level 에서 선택된 Flow
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResourceType
        {
            get
            {
                return m_select_res_type;
            }
        }

        /// <summary>
        /// User Control 내의 ListView
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView GetListView
        {
            get
            {
                return this.lisList;
            }
        }

        /// <summary>
        /// User Control 내의 TreeView
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeView GetTreeView
        {
            get
            {
                return this.treResourceList;
            }
        }

        /// <summary>
        /// User Control 이 Set Data List 만을 가져오는지 확인
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OnlySetDataList
        {
            get
            {
                return this.chkSetData.Checked;
            }
            set
            {
                chkSetData.Checked = value;
            }
        }

        /// <summary>
        /// 바탕색
        /// </summary>
        public new Color BackColor
        {
            get
            {
                return treResourceList.BackColor;
            }
            set
            {
                pnlMainTop.BackColor = value;
                pnlMainMid.BackColor = value;
                treResourceList.BackColor = value;
            }
        }

        /// <summary>
        /// 삭제된 Resource까지 보일지 여부를 확인하는 CheckBox 표시 여부
        /// </summary>
        public bool VisibleResourceIncludeDeleteCheck
        {
            get
            {
                return mb_visible_resource_include_delete;
            }
            set
            {
                mb_visible_resource_include_delete = value;
                ResizeMainTop();
            }
        }

        /// <summary>
        /// MFO Level 표시 여부
        /// </summary>
        public bool VisibleLevel1R
        {
            get
            {
                return mb_visible_res;
            }
            set
            {
                mb_visible_res = value;
                ResizeMainTop();
            }
        }
        /// <summary>
        /// FO Level 표시 여부
        /// </summary>
        public bool VisibleLevel2G
        {
            get
            {
                return mb_visible_res_grp;
            }
            set
            {
                mb_visible_res_grp = value;
                ResizeMainTop();
            }
        }
        /// <summary>
        /// O Level 표시 여부
        /// </summary>
        public bool VisibleLevel3T
        {
            get
            {
                return mb_visible_res_type;
            }
            set
            {
                mb_visible_res_type = value;
                ResizeMainTop();
            }
        }
        
        /// <summary>
        /// Setup 된 조건만 표시 여부
        /// </summary>
        public bool VisibleOnlySetData
        {
            get
            {
                return mb_visible_set_data;
            }
            set
            {
                mb_visible_set_data = value;
                ResizeMainTop();
            }
        }

        /// <summary>
        /// 현재 선택된 표시 Level
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceSelectLevel SelectLevel
        {
            get
            {
                return m_select_level;
            }
            set
            {
                m_select_level = value;

                switch (m_select_level)
                {
                    case ResourceSelectLevel.R:
                        rbtRes.Checked = true; break;
                    case ResourceSelectLevel.GR:
                        rbtResGrp.Checked = true; break;
                    case ResourceSelectLevel.TR:
                        rbtResType.Checked = true; break;
                    case ResourceSelectLevel.NONE:
                        rbtRes.Checked = false;
                        rbtResGrp.Checked = false;
                        rbtResType.Checked = false;
                        break;
                }
            }
        }

        /// <summary>
        /// 현재 선택된 표시 Level에 대한 문자값
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char SelectLevelChar
        {
            get
            {
                switch (m_select_level)
                {
                    case ResourceSelectLevel.R:
                        return 'R';
                    case ResourceSelectLevel.GR:
                        return 'G';
                    case ResourceSelectLevel.TR:
                        return 'T';
                }

                return ' ';
            }
        }

        /// <summary>
        /// 현재 선택된 표시 Level에 대한 문자값
        /// GR,TR이지만 Resource 단위까지 선택되었다면 'R'로 사용
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char SelectLevelCharEx
        {
            get
            {
                switch (m_select_level)
                {
                    case ResourceSelectLevel.R:
                        return 'R';
                    case ResourceSelectLevel.GR:
                        if (SelectedItem == TreeSelectedItem.Resource)
                        {
                            return 'R';
                        }
                        else
                        {
                            return 'G';
                        }
                    case ResourceSelectLevel.TR:
                        if (SelectedItem == TreeSelectedItem.Resource)
                        {
                            return 'R';
                        }
                        else
                        {
                            return 'T';
                        }
                }

                return ' ';
            }
        }

        /// <summary>
        /// 현재 Level에서 선택된 Item
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeSelectedItem SelectedItem
        {
            get
            {
                return m_selected_item;
            }
            set
            {
                m_selected_item = value;
            }
        }

        /// <summary>
        /// Delete Resource을 포함할지 여부
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IncludeDeleteResource
        {
            get
            {
                return chkIncludeDeletedResource.Checked;
            }
            set
            {
                chkIncludeDeletedResource.Checked = value;
            }
        }
        
        /// <summary>
        /// TreeNode의 총수
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ListCount
        {
            get
            {
                return treResourceList.Nodes.Count;
            }
        }

        /// <summary>
        /// 리스트를 가지오기 위한 스텝
        /// </summary>
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
        /// <summary>
        /// 리스트를 가져올 공장
        /// </summary>
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
        /// <summary>
        /// 리스트를 가져올 Filter
        /// </summary>
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

        #endregion

        private void treResourceList_FontChanged(object sender, EventArgs e)
        {
            pnlResourceList.Font = this.Font;
        }

        private void chkIncludeResource_CheckedChanged(object sender, EventArgs e)
        {
            ViewTreeList();
        }

        private void Resource_Level_CheckedChanged(object sender, EventArgs e)
        {
            ArrayList a_level;
            int i;

            if (mb_changing_level == true) return;

            mb_changing_level = true;

            a_level = new ArrayList();
            a_level.Add(rbtRes);
            a_level.Add(rbtResGrp);
            a_level.Add(rbtResType);
            
            for (i = 0; i < 3; i++)
            {
                if (a_level[i].Equals(sender) == true)
                {
                    ((RadioButton)a_level[i]).Checked = true;

                    switch (i)
                    {
                        case 0:
                            m_select_level = ResourceSelectLevel.R; break;
                        case 1:
                            m_select_level = ResourceSelectLevel.GR; break;
                        case 2:
                            m_select_level = ResourceSelectLevel.TR; break;
                    }
                }
                else
                {
                    ((RadioButton)a_level[i]).Checked = false;
                }
            }

            if (SelectLevelChangedEvent != null)
                SelectLevelChangedEvent(this, e);

            if (chkSetData.Checked == true)
            {
                ViewListView();
            }
            else
            {
                ViewTreeList();
            }

            mb_changing_level = false;
        }

        private void chkSetData_CheckedChanged(object sender, EventArgs e)
        {

            ClearItemValue();

            if (chkSetData.Checked == true)
            {
                pnlResourceList.Visible = false;
                lisList.Visible = true;

                ViewListView();
            }
            else
            {
                pnlResourceList.Visible = true;
                lisList.Visible = false;

                ViewTreeList();
            }
        }

        private void lisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_select_level == ResourceSelectLevel.NONE) return;
            if (lisList.SelectedItems.Count < 1) return;

            ClearItemValue();

            switch (m_select_level)
            {
                case ResourceSelectLevel.R:
                    m_selected_item = TreeSelectedItem.Resource;                    
                    m_select_res = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    break;

                case ResourceSelectLevel.GR:
                    m_selected_item = TreeSelectedItem.ResGrp;
                    m_select_res_grp = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    m_select_res = MPCF.Trim(lisList.SelectedItems[0].SubItems[1].Text);
                    break;

                case ResourceSelectLevel.TR:
                    m_selected_item = TreeSelectedItem.ResType;
                    m_select_res_type = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    m_select_res = MPCF.Trim(lisList.SelectedItems[0].SubItems[1].Text);
                    break;
            }

            if (SetDataSelectedIndexChangedEvent != null)
            {
                SetDataSelectedIndexChangedEvent(this, e);
            }
        }

        /// <summary>
        /// User Control 내의 모든 값을 초기화
        /// </summary>
        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";
            m_cond_s_filter = "";

            m_selected_item = TreeSelectedItem.None;

            m_select_res = "";
            m_select_res_grp = "";
            m_select_res_type = "";

            mb_visible_resource_include_delete = true;
            mb_visible_res = true;
            mb_visible_res_grp = true;
            mb_visible_res_type = true;
            mb_visible_set_data = false;
            ResizeMainTop();
            
            mb_changing_level = false;

            m_select_level = ResourceSelectLevel.NONE;

            MPCF.InitTreeView(treResourceList);
            //MPCF.InitListView(lisList);
        }

        /// <summary>
        /// 현재 Level의 최상위 노드 리스트를 가져옴.
        /// </summary>
        public void ViewTreeList()
        {           
            if (m_select_level == ResourceSelectLevel.NONE) return;

            m_selected_item = TreeSelectedItem.None;

            if (BeforeGetTreeEvent != null)
                BeforeGetTreeEvent(this, new EventArgs());

            MPCF.ClearList(treResourceList, false);

            if (m_select_level == ResourceSelectLevel.R)
            {
                if (RASLIST.ViewResourceList(treResourceList, chkIncludeDeletedResource.Checked) == false) return;
            }
            else if (m_select_level == ResourceSelectLevel.GR)
            {
                if (RASLIST.ViewResourceGroupList(treResourceList, '1') == false) return;
            }
            else if (m_select_level == ResourceSelectLevel.TR) 
            {
                if (BASLIST.ViewGCMDataList(treResourceList, '1', MPGC.MP_RAS_RES_TYPE) == false) return;
            }
            else
            {
                //nothing
            }

            if (AfterGetTreeEvent != null)
                AfterGetTreeEvent(this, new EventArgs());
        }

        /// <summary>
        /// 현재 Level의 선택 노드 리스트, 혹은 설정된 리스트를 다시 가져온다.
        /// </summary>
        public void RefreshSelectedList()
        {
            if (chkSetData.Checked == false)
            {
                if (m_selected_item == TreeSelectedItem.None || m_selected_item == TreeSelectedItem.Another) return;
                if (SelectedNode == null) return;

                // 하위 Customizing 노드가 존재할 수 있으므로 주석처리함. 2007.07.27. Aiden.
                //if (SelectedNode.GetNodeCount(true) < 1) return;

                TreeViewEventArgs tveArg;
                string s_full_path;

                s_full_path = SelectedNode.FullPath;
                SelectedNode.Nodes.Clear();

                tveArg = new TreeViewEventArgs(SelectedNode, TreeViewAction.ByMouse);
                this.treResourceList_AfterSelect(treResourceList, tveArg);

                if (treResourceList.GetNodeCount(true) > 1)
                {
                    treResourceList.SelectedNode = MPCF.FindTreeNode(treResourceList, s_full_path);
                    if (SelectedNode == null)
                    {
                        treResourceList.SelectedNode = treResourceList.TopNode.FirstNode;
                    }

                    treResourceList.SelectedNode.EnsureVisible();
                }
            }
            else
            {
                ClearItemValue();
                ViewListView();
            }
        }

        /// <summary>
        /// s_text로 시작하는 다음 노드 혹은 다음 설정 항목을 가져온다.
        /// </summary>
        /// <param name="s_text"></param>
        public void GetNext(string s_text)
        {
            if (chkSetData.Checked == false)
            {
                TreeNode tn;

                if (m_selected_item == TreeSelectedItem.None) return;
                if (SelectedNode == null) return;
                if (treResourceList.Nodes.Count < 1) return;

                tn = MPCF.FindTreeNodeNextPartial(treResourceList.Nodes[0], SelectedNode, s_text);
                if (tn != null)
                {
                    treResourceList.SelectedNode = tn;

                    TreeViewEventArgs ev = new TreeViewEventArgs(tn, TreeViewAction.ByMouse);
                    treResourceList_AfterSelect(treResourceList, ev);

                    treResourceList.SelectedNode.EnsureVisible();
                }
            }
            else
            {
                MPCF.FindListItemNextPartial(lisList, s_text, true, false);
            }
        }

        private void ViewListView()
        {
            ColumnHeader col;

            if (m_select_level == ResourceSelectLevel.NONE) return;

            lisList.Items.Clear();
            while (lisList.Columns.Count > 0)
            {
                lisList.Columns.RemoveAt(0);
            }

            switch (m_select_level)
            {
                case ResourceSelectLevel.R:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Resource", 0);
                    lisList.Columns.Add(col);

                    break;

                case ResourceSelectLevel.GR:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Res Group", 0);
                    lisList.Columns.Add(col);

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Resource", 0);
                    lisList.Columns.Add(col);

                    break;

                case ResourceSelectLevel.TR:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Res Type", 0);
                    lisList.Columns.Add(col);

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Resource", 0);
                    lisList.Columns.Add(col);

                    break;
            }

            if (GetOnlySetDataEvent != null)
            {
                GetOnlySetDataEvent(this, new EventArgs());
            }

            if (lisList.Items.Count > 0)
            {
                MPCF.FitColumnHeader(lisList);
            }
        }

        private void ResizeMainTop()
        {
            int i_height;

            i_height = 0;

            pnlRes.Visible = mb_visible_res;
            if (mb_visible_res == true)
            {
                i_height += pnlRes.Height;
            }
            pnlResGrp.Visible = mb_visible_res_grp;
            if (mb_visible_res_grp == true)
            {
                i_height += pnlResGrp.Height;
            }
            pnlResType.Visible = mb_visible_res_type;
            if (mb_visible_res_type == true)
            {
                i_height += pnlResType.Height;
            }
            
            if (i_height > 0)
            {
                pnlSetData.Visible = mb_visible_set_data;
                if (mb_visible_set_data == true)
                {
                    i_height += pnlSetData.Height;
                }

                grpLevel.Visible = true;
                grpLevel.Height = i_height + 18;
            }
            else
            {
                grpLevel.Visible = false;
                grpLevel.Height = 0;
            }


            if (mb_visible_res == true ||
                mb_visible_res_grp == true ||
                mb_visible_res_type == true)
            {
                if (mb_visible_resource_include_delete == false)
                {
                    grpRsourceIncludeDelete.Visible = false;
                    grpRsourceIncludeDelete.Height = 0;
                }
                else
                {
                    grpRsourceIncludeDelete.Visible = true;
                    grpRsourceIncludeDelete.Height = 34;
                    grpRsourceIncludeDelete.Top = 10;
                }
            }

            pnlMainTop.Height = grpLevel.Height + grpRsourceIncludeDelete.Height;
        }

        private void GetResourceInfo(TreeNode node)
        {
            m_selected_item = TreeSelectedItem.Resource;
            ClearItemValue();
            m_select_res = MPCF.SubtractString(node.Text, ":", false, false);
        }

        private void GetResourceList(TreeNode node, bool b_get_res_grp, bool b_get_res_type)
        {            
            ClearItemValue();

            if (b_get_res_grp == true)
            {
                m_selected_item = TreeSelectedItem.ResGrp;
                m_select_res_grp = MPCF.SubtractString(node.Text, ":", false, false);
                if (node.GetNodeCount(true) < 1)
                {
                    if (RASLIST.ViewResourceList(treResourceList, '1', MPCF.SubtractString(node.Text, ":", false, false), "", "", "", "", 0, "", "", ' ', "", chkIncludeDeletedResource.Checked, node, "") == false) return;
                }
            }
            else if (b_get_res_type == true)
            {
                m_selected_item = TreeSelectedItem.ResType;
                m_select_res_type = MPCF.SubtractString(node.Text, ":", false, false);
                if (node.GetNodeCount(true) < 1)
                {
                    if (RASLIST.ViewResourceList(treResourceList, '1', "", MPCF.SubtractString(node.Text, ":", false, false), "", "", "", 0, "", "", ' ', "", chkIncludeDeletedResource.Checked, node, "") == false) return;
                }
            }
        }

        private void GetGroupTypeInfo(TreeNode node, bool b_get_res_grp, bool b_get_res_type)
        {
            ClearItemValue();

            m_select_res = MPCF.SubtractString(node.Text, ":", false, false);

            if (b_get_res_grp == true)
            {
                m_selected_item = TreeSelectedItem.ResGrp;
                m_select_res_grp = MPCF.SubtractString(node.Parent.Text, ":", false, false);
            }
            else if (b_get_res_type == true)
            {
                m_selected_item = TreeSelectedItem.ResType;
                m_select_res_type = MPCF.SubtractString(node.Parent.Text, ":", false, false);
            }
        }

        private void ClearItemValue()
        {
            m_select_res = "";
            m_select_res_grp = "";
            m_select_res_type = "";
        }
    }

    /// <summary>
    /// 표시 Level
    /// </summary>
    public enum ResourceSelectLevel
    {
        NONE = -1,
        R = 0,
        GR = 1,
        TR = 2,
        G = 3,
        T = 4
    }

    /// <summary>
    /// 현재 Level에서의 선택 Item
    /// </summary>
    //public enum TreeSelectedItem
    //{
    //    None = 0,
    //    Resource = 1,
    //    ResourceGroup = 2,
    //    ResourceType = 3
    //}
}