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
    public partial class udcMFOTreeList : UserControl
    {
        private char m_cond_c_step;
        private string m_cond_s_ext_factory;

        private MaterialViewType m_view_type;
        private MFOSelectLevel m_select_level;
        private TreeSelectedItem m_selected_item;

        private string m_select_mat_id;
        private int m_select_version;
        private string m_select_flow;
        private int m_select_flow_seq_num;
        private string m_select_oper;
        private string m_select_factory;

        private bool m_include_flow_seq;

        private bool mb_changing_level;
        private bool mb_visible_material_type;
        private bool mb_visible_material_filter;
        private bool mb_visible_material_include_delete;
        private bool mb_visible_material_view_type;
        private bool mb_visible_MFO;
        private bool mb_visible_FO;
        private bool mb_visible_O;
        private bool mb_visible_MO;
        private bool mb_visible_MF;
        private bool mb_visible_M;
        private bool mb_visible_F;
        private bool mb_visible_Factory;
        private bool mb_visible_set_data;

        public udcMFOTreeList()
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

        private void treMFOList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool b_raise_level_item_event;

            m_selected_item = TreeSelectedItem.None;

            if (e.Action == TreeViewAction.Unknown) return;
            if (e.Node == null) return;
            if (m_select_level == MFOSelectLevel.NONE) return;

            m_selected_item = TreeSelectedItem.Another;
            b_raise_level_item_event = false;

            switch (m_select_level)
            {
                case MFOSelectLevel.M:
                    if (ViewType == MaterialViewType.LastActiveVersion)
                    {
                        switch (e.Node.Level)
                        {
                            case 0: // Material & Version
                                GetMaterialInfo(e.Node, false, false);
                                b_raise_level_item_event = true;
                                break;
                        }
                    }
                    else
                    {
                        switch(e.Node.Level)
                        {
                            case 0: // Material
                                GetMaterialVersionList(e.Node);
                                break;
                            case 1: // Version
                                GetMaterialVersionInfo(e.Node, false, false);
                                b_raise_level_item_event = true;
                                break;
                        }
                    }
                    break;

                case MFOSelectLevel.MF:
                    if (ViewType == MaterialViewType.LastActiveVersion)
                    {
                        switch (e.Node.Level)
                        {
                            case 0: // Material & Version
                                GetMaterialInfo(e.Node, true, false);
                                break;
                            case 1: // Flow
                                GetFlowInfo(e.Node, false, true);
                                b_raise_level_item_event = true;
                                break;
                        }
                    }
                    else
                    {
                        switch (e.Node.Level)
                        {
                            case 0: // Material
                                GetMaterialVersionList(e.Node);
                                break;
                            case 1: // Version
                                GetMaterialVersionInfo(e.Node, true, false);
                                break;
                            case 2: // Flow
                                GetFlowInfo(e.Node, false, true);
                                b_raise_level_item_event = true;
                                break;
                        }
                    }
                    break;

                case MFOSelectLevel.MO:
                    if (ViewType == MaterialViewType.LastActiveVersion)
                    {
                        switch (e.Node.Level)
                        {
                            case 0: // Material & Version
                                GetMaterialInfo(e.Node, false, true);
                                break;
                            case 1: // Oper
                                GetOperInfo(e.Node, true, false);
                                b_raise_level_item_event = true;
                                break;
                        }
                    }
                    else
                    {
                        switch (e.Node.Level)
                        {
                            case 0: // Material
                                GetMaterialVersionList(e.Node);
                                break;
                            case 1: // Version
                                GetMaterialVersionInfo(e.Node, false, true);
                                break;
                            case 2: // Oper
                                GetOperInfo(e.Node, true, false);
                                b_raise_level_item_event = true;
                                break;
                        }
                    }
                    break;

                case MFOSelectLevel.MFO:
                    if (ViewType == MaterialViewType.LastActiveVersion)
                    {
                        switch (e.Node.Level)
                        {
                            case 0: // Material & Version
                                GetMaterialInfo(e.Node, true, false);
                                break;
                            case 1: // Flow
                                GetFlowInfo(e.Node, true, true);
                                break;
                            case 2: // Oper
                                GetOperInfo(e.Node, true, true);
                                b_raise_level_item_event = true;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (e.Node.Level)
                        {
                            case 0: // Material
                                GetMaterialVersionList(e.Node);
                                break;
                            case 1: // Version
                                GetMaterialVersionInfo(e.Node, true, false);
                                break;
                            case 2: // Flow
                                GetFlowInfo(e.Node, true, true);
                                break;
                            case 3: // Oper
                                GetOperInfo(e.Node, true, true);
                                b_raise_level_item_event = true;
                                break;
                        }
                    }
                    break;

                case MFOSelectLevel.F:
                    switch (e.Node.Level)
                    {
                        case 0: // Flow
                            GetFlowInfo(e.Node, false, false);
                            b_raise_level_item_event = true;
                            break;
                    }
                    break;

                case MFOSelectLevel.FO:
                    switch (e.Node.Level)
                    {
                        case 0: // Flow
                            GetFlowInfo(e.Node, true, false);
                            break;
                        case 1: // Oper
                            GetOperInfo(e.Node, false, true);
                            b_raise_level_item_event = true;
                            break;
                    }
                    break;

                case MFOSelectLevel.O:
                    switch (e.Node.Level)
                    {
                        case 0: // Oper
                            GetOperInfo(e.Node, false, false);
                            b_raise_level_item_event = true;
                            break;
                    }
                    break;

                case MFOSelectLevel.Factory:
                    switch (e.Node.Level)
                    {
                        case 0: // Factory
                            b_raise_level_item_event = true;
                            m_selected_item = TreeSelectedItem.Factory;
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
                    case MFOSelectLevel.M:
                        if (ViewType == MaterialViewType.LastActiveVersion)
                            i_raise_level_item_event_level = 0;
                        else
                            i_raise_level_item_event_level = 1;
                        break;
                    case MFOSelectLevel.F:
                    case MFOSelectLevel.O:
                    case MFOSelectLevel.Factory:
                        i_raise_level_item_event_level = 0;
                        break;

                    case MFOSelectLevel.MO:
                    case MFOSelectLevel.MF:
                        if (ViewType == MaterialViewType.LastActiveVersion)
                            i_raise_level_item_event_level = 1;
                        else
                            i_raise_level_item_event_level = 2;
                        break;
                    case MFOSelectLevel.FO:
                        i_raise_level_item_event_level = 1;
                        break;

                    case MFOSelectLevel.MFO:
                        if (ViewType == MaterialViewType.LastActiveVersion)
                            i_raise_level_item_event_level = 2;
                        else
                            i_raise_level_item_event_level = 3;
                        break;
                }

                t_node = e.Node;
                for (i = e.Node.Level; i > i_raise_level_item_event_level; i--)
                    t_node = t_node.Parent;

                switch (m_select_level)
                {
                    case MFOSelectLevel.M:
                        if (ViewType == MaterialViewType.LastActiveVersion)
                            GetMaterialInfo(t_node, false, false);
                        else
                            GetMaterialVersionInfo(t_node, false, false);
                        break;
                    case MFOSelectLevel.F:
                        GetFlowInfo(t_node, false, false);
                        break;
                    case MFOSelectLevel.O:
                        GetOperInfo(t_node, false, false);
                        break;

                    case MFOSelectLevel.MO:
                        GetOperInfo(t_node, true, false);
                        break;
                    case MFOSelectLevel.MF:
                        GetFlowInfo(t_node, false, true);
                        break;
                    case MFOSelectLevel.FO:
                        GetOperInfo(t_node, false, true);
                        break;
                    case MFOSelectLevel.MFO:
                        GetOperInfo(t_node, true, true);
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
                return treMFOList.SelectedNode;
            }
        }

        /// <summary>
        /// 현 Level 에서 선택된 Material ID
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MatID
        {
            get
            {
                return m_select_mat_id;
            }
        }

        /// <summary>
        /// 현 Level 에서 선택된 Material Version
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MatVersion
        {
            get
            {
                return m_select_version;
            }
        }

        /// <summary>
        /// 현 Level 에서 선택된 Flow
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Flow
        {
            get
            {
                return m_select_flow;
            }
        }

        /// <summary>
        /// 현 Level 에서 선택된 Flow Sequence
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FlowSeqNum
        {
            get
            {
                return m_select_flow_seq_num;
            }
        }

        /// <summary>
        /// 현 Level 에서 선택된 Operation
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Oper
        {
            get
            {
                return m_select_oper;
            }
        }

        /// <summary>
        /// 현 Level 에서 선택된 Factory
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Factory
        {
            get
            {
                return m_select_factory;
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
                return this.treMFOList;
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
                return treMFOList.BackColor;
            }
            set
            {
                pnlMainTop.BackColor = value;
                pnlMainMid.BackColor = value;
                treMFOList.BackColor = value;
            }
        }


        /// <summary>
        /// Material Type 선택박스 표시 여부
        /// </summary>
        public bool VisibleMaterialType
        {
            get
            {
                return mb_visible_material_type;
            }
            set
            {
                mb_visible_material_type = value;
                ResizeMainTop();
            }
        }

        /// <summary>
        /// 삭제된 Material까지 보일지 여부를 확인하는 CheckBox 표시 여부
        /// </summary>
        public bool VisibleMaterialIncludeDeleteCheck
        {
            get
            {
                return mb_visible_material_include_delete;
            }
            set
            {
                mb_visible_material_include_delete = value;
                ResizeMainTop();
            }
        }

        /* 2013.06.12. Aiden. VisibleDefaultFilter Property 추가 */
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool VisibleDefaultFilter
        {
            get
            {
                return mb_visible_material_filter;
            }
            set
            {
                mb_visible_material_filter = value;
                ResizeMainTop();
            }
        }

        /// <summary>
        /// Material 리스트 선택박스 표시 여부
        /// </summary>
        public bool VisibleViewType
        {
            get
            {
                return mb_visible_material_view_type;
            }
            set
            {
                mb_visible_material_view_type = value;
                ResizeMainTop();
            }
        }

        /// <summary>
        /// MFO Level 표시 여부
        /// </summary>
        public bool VisibleLevel1MFO
        {
            get
            {
                return mb_visible_MFO;
            }
            set
            {
                mb_visible_MFO = value;
                ResizeMainTop();
            }
        }
        /// <summary>
        /// FO Level 표시 여부
        /// </summary>
        public bool VisibleLevel2FO
        {
            get
            {
                return mb_visible_FO;
            }
            set
            {
                mb_visible_FO = value;
                ResizeMainTop();
            }
        }
        /// <summary>
        /// O Level 표시 여부
        /// </summary>
        public bool VisibleLevel3O
        {
            get
            {
                return mb_visible_O;
            }
            set
            {
                mb_visible_O = value;
                ResizeMainTop();
            }
        }
        /// <summary>
        /// MO Level 표시 여부
        /// </summary>
        public bool VisibleLevel4MO
        {
            get
            {
                return mb_visible_MO;
            }
            set
            {
                mb_visible_MO = value;
                ResizeMainTop();
            }
        }
        /// <summary>
        /// MF Level 표시 여부
        /// </summary>
        public bool VisibleLevel5MF
        {
            get
            {
                return mb_visible_MF;
            }
            set
            {
                mb_visible_MF = value;
                ResizeMainTop();
            }
        }
        /// <summary>
        /// M Level 표시 여부
        /// </summary>
        public bool VisibleLevel6M
        {
            get
            {
                return mb_visible_M;
            }
            set
            {
                mb_visible_M = value;
                ResizeMainTop();
            }
        }
        /// <summary>
        /// F Level 표시 여부
        /// </summary>
        public bool VisibleLevel7F
        {
            get
            {
                return mb_visible_F;
            }
            set
            {
                mb_visible_F = value;
                ResizeMainTop();
            }
        }
        /// <summary>
        /// Factory Level 표시 여부
        /// </summary>
        public bool VisibleLevel8Factory
        {
            get
            {
                return mb_visible_Factory;
            }
            set
            {
                mb_visible_Factory = value;
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
        /// Material 리스트 표시 형태 설정
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MaterialViewType ViewType
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
                    case MaterialViewType.LastActiveVersion:
                        rbtLastActive.Checked = true;
                        break;
                    case MaterialViewType.TreeViewList:
                        rbtTree.Checked = true;
                        break;
                }
            }
        }

        /// <summary>
        /// 현재 선택된 표시 Level
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MFOSelectLevel SelectLevel
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
                    case MFOSelectLevel.MFO:
                        rbtMFO.Checked = true; break;
                    case MFOSelectLevel.FO:
                        rbtFO.Checked = true; break;
                    case MFOSelectLevel.O:
                        rbtO.Checked = true; break;
                    case MFOSelectLevel.MO:
                        rbtMO.Checked = true; break;
                    case MFOSelectLevel.MF:
                        rbtMF.Checked = true; break;
                    case MFOSelectLevel.M:
                        rbtM.Checked = true; break;
                    case MFOSelectLevel.F:
                        rbtF.Checked = true; break;
                    case MFOSelectLevel.Factory:
                        rbtFactory.Checked = true; break;
                    case MFOSelectLevel.NONE:
                        rbtMFO.Checked = false;
                        rbtFO.Checked = false;
                        rbtO.Checked = false;
                        rbtMO.Checked = false;
                        rbtMF.Checked = false;
                        rbtM.Checked = false;
                        rbtF.Checked = false;
                        rbtFactory.Checked = false;
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
                    case MFOSelectLevel.MFO:
                        return '1';
                    case MFOSelectLevel.FO:
                        return '2';
                    case MFOSelectLevel.O:
                        return '3';
                    case MFOSelectLevel.MO:
                        return '4';
                    case MFOSelectLevel.MF:
                        return '5';
                    case MFOSelectLevel.M:
                        return '6';
                    case MFOSelectLevel.F:
                        return '7';
                    case MFOSelectLevel.Factory:
                        return '8';
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
        /// Material Type 설정
        /// </summary>
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

        /// <summary>
        /// Delete Material을 포함할지 여부
        /// </summary>
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

        /// <summary>
        /// Deactive Material을 포함할지 여부
        /// </summary>
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
        
        /// <summary>
        /// TreeNode의 총수
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ListCount
        {
            get
            {
                return treMFOList.Nodes.Count;
            }
        }

        /// <summary>
        /// Flow Sequence Number를 포함할지 여부
        /// </summary>
        public bool IncludeFlowSeqNum
        {
            get
            {
                return m_include_flow_seq;
            }
            set
            {
                m_include_flow_seq = value;
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
                return txtFilter.Text;
            }
            set
            {
                txtFilter.Text = value;
            }
        }

        #endregion

        private void udcMFOTreeList_FontChanged(object sender, EventArgs e)
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
                    m_view_type = MaterialViewType.LastActiveVersion;
                }
                else if (((RadioButton)sender).Name == "rbtTree")
                {
                    m_view_type = MaterialViewType.TreeViewList;
                }

                ViewTreeList();
            }
        }

        private void cdvMaterialType_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            ViewTreeList();
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
            ViewTreeList();
        }

        private void MFO_Level_CheckedChanged(object sender, EventArgs e)
        {
            ArrayList a_level;
            int i;

            if (mb_changing_level == true) return;

            mb_changing_level = true;

            m_select_mat_id = "";
            m_select_version = 0;
            m_select_flow = "";
            m_select_flow_seq_num = 0;
            m_select_oper = "";
            m_select_factory = "";

            if (VisibleDefaultFilter == true && ListCond_Filter != "")
            {
                ListCond_Filter = "";
            }

            a_level = new ArrayList();
            a_level.Add(rbtMFO);
            a_level.Add(rbtFO);
            a_level.Add(rbtO);
            a_level.Add(rbtMO);
            a_level.Add(rbtMF);
            a_level.Add(rbtM);
            a_level.Add(rbtF);
            a_level.Add(rbtFactory);

            for (i = 0; i < 8; i++)
            {
                if (a_level[i].Equals(sender) == true)
                {
                    ((RadioButton)a_level[i]).Checked = true;

                    switch (i)
                    {
                        case 0:
                            m_select_level = MFOSelectLevel.MFO; break;
                        case 1:
                            m_select_level = MFOSelectLevel.FO; break;
                        case 2:
                            m_select_level = MFOSelectLevel.O; break;
                        case 3:
                            m_select_level = MFOSelectLevel.MO; break;
                        case 4:
                            m_select_level = MFOSelectLevel.MF; break;
                        case 5:
                            m_select_level = MFOSelectLevel.M; break;
                        case 6:
                            m_select_level = MFOSelectLevel.F; break;
                        case 7:
                            m_select_level = MFOSelectLevel.Factory; break;
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
                ViewListView();
            else
                ViewTreeList();

            mb_changing_level = false;
        }

        private void chkSetData_CheckedChanged(object sender, EventArgs e)
        {
            ClearItemValue();

            if (chkSetData.Checked == true)
            {
                pnlMaterialList.Visible = false;
                lisList.Visible = true;

                mb_visible_material_filter = false;

                bool b_visible_material_view_type_temp = mb_visible_material_view_type;
                mb_visible_material_view_type = false;

                ResizeMainTop();

                mb_visible_material_view_type = b_visible_material_view_type_temp;

                ViewListView();
            }
            else
            {
                lisList.Visible = false;
                pnlMaterialList.Visible = true;
                lisList.Clear();    /*OnlySetData 해제후 Export to Excel 할 때 클리어되지않은 lisList 데이터가 출력되는 문제 해결*/

                mb_visible_material_filter = MPGO.RequireMaterialFilter();
                ResizeMainTop();

                ViewTreeList();
            }
        }

        private void lisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_select_level == MFOSelectLevel.NONE) return;
            if (lisList.SelectedItems.Count < 1) return;

            ClearItemValue();

            switch (m_select_level)
            {
                case MFOSelectLevel.MFO:
                    m_selected_item = TreeSelectedItem.Oper;
                    m_select_mat_id = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    m_select_version = MPCF.ToInt(lisList.SelectedItems[0].SubItems[1].Text);
                    m_select_flow = MPCF.Trim(lisList.SelectedItems[0].SubItems[2].Text);
                    if (m_include_flow_seq == true)
                    {
                        m_select_flow_seq_num = MPCF.ToInt(lisList.SelectedItems[0].SubItems[3].Text);
                        m_select_oper = MPCF.Trim(lisList.SelectedItems[0].SubItems[4].Text);
                    }
                    else
                    {
                        m_select_oper = MPCF.Trim(lisList.SelectedItems[0].SubItems[3].Text);
                    }
                    break;

                case MFOSelectLevel.MF:
                    m_selected_item = TreeSelectedItem.Flow;
                    m_select_mat_id = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    m_select_version = MPCF.ToInt(lisList.SelectedItems[0].SubItems[1].Text);
                    m_select_flow = MPCF.Trim(lisList.SelectedItems[0].SubItems[2].Text);
                    if (m_include_flow_seq == true)
                    {
                        m_select_flow_seq_num = MPCF.ToInt(lisList.SelectedItems[0].SubItems[3].Text);
                    }
                    break;

                case MFOSelectLevel.MO:
                    m_selected_item = TreeSelectedItem.Oper;
                    m_select_mat_id = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    m_select_version = MPCF.ToInt(lisList.SelectedItems[0].SubItems[1].Text);
                    m_select_oper = MPCF.Trim(lisList.SelectedItems[0].SubItems[2].Text);
                    break;

                case MFOSelectLevel.M:
                    m_selected_item = TreeSelectedItem.Material;
                    m_select_mat_id = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    m_select_version = MPCF.ToInt(lisList.SelectedItems[0].SubItems[1].Text);
                    break;

                case MFOSelectLevel.FO:
                    m_selected_item = TreeSelectedItem.Oper;
                    m_select_flow = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    if (m_include_flow_seq == true)
                    {
                        m_select_flow_seq_num = MPCF.ToInt(lisList.SelectedItems[0].SubItems[1].Text);
                        m_select_oper = MPCF.Trim(lisList.SelectedItems[0].SubItems[2].Text);
                    }
                    else
                    {
                        m_select_oper = MPCF.Trim(lisList.SelectedItems[0].SubItems[1].Text);
                    }
                    break;

                case MFOSelectLevel.F:
                    m_selected_item = TreeSelectedItem.Flow;
                    m_select_flow = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    if (m_include_flow_seq == true)
                    {
                        m_select_flow_seq_num = MPCF.ToInt(lisList.SelectedItems[0].SubItems[1].Text);
                    }
                    break;

                case MFOSelectLevel.O:
                    m_selected_item = TreeSelectedItem.Oper;
                    m_select_oper = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    break;

                case MFOSelectLevel.Factory:
                    m_selected_item = TreeSelectedItem.Factory;
                    m_select_factory = MPCF.Trim(lisList.SelectedItems[0].SubItems[0].Text);
                    break;
            }

            if (SetDataSelectedIndexChangedEvent != null)
                SetDataSelectedIndexChangedEvent(this, e);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            if (MPCF.CheckValue(txtFilter, 1) == false) return;

            if (chkSetData.Checked == true)
                ViewListView();
            else
                ViewTreeList();
        }

        
        /// <summary>
        /// User Control 내의 모든 값을 초기화
        /// </summary>
        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";

            m_view_type = MaterialViewType.LastActiveVersion;
            m_selected_item = TreeSelectedItem.None;

            m_select_mat_id = "";
            m_select_version = 0;
            m_select_flow = "";
            m_select_flow_seq_num = 0;
            m_select_oper = "";
            m_select_factory = "";

            m_include_flow_seq = false;

            /* 2013.06.17. Aiden. Material Filter 가 필요한지 Global Option 확인 */
            mb_visible_material_filter = true;
            if (MPCR.IsInDesignMode(this) == false)
            {
                mb_visible_material_filter = MPGO.RequireMaterialFilter();
            }

            mb_visible_material_type = true;
            mb_visible_material_include_delete = true;
            mb_visible_material_view_type = true;
            mb_visible_MFO = true;
            mb_visible_FO = true;
            mb_visible_O = true;
            mb_visible_MO = true;
            mb_visible_MF = true;
            mb_visible_M = true;
            mb_visible_F = true;
            mb_visible_Factory = false;
            mb_visible_set_data = false;
            ResizeMainTop();
            
            mb_changing_level = false;

            m_select_level = MFOSelectLevel.NONE;

            MPCF.InitTreeView(treMFOList);
            MPCF.InitListView(lisList);
        }

        /// <summary>
        /// 현재 Level의 최상위 노드 리스트를 가져옴.
        /// </summary>
        public void ViewTreeList()
        {
            char cDeleteFlag;
            char cDeactiveFlag;

            if (m_select_level == MFOSelectLevel.NONE) return;

            cDeleteFlag = (IncludeDeleteMaterial == true) ? '%' : ' ';
            cDeactiveFlag = (IncludeDeactiveMaterial == true) ? '%' : ' ';


            m_selected_item = TreeSelectedItem.None;


            if (BeforeGetTreeEvent != null)
                BeforeGetTreeEvent(this, new EventArgs());

            MPCF.ClearList(treMFOList, false);

            if (m_select_level == MFOSelectLevel.MFO ||
                m_select_level == MFOSelectLevel.MO  ||
                m_select_level == MFOSelectLevel.MF  ||
                m_select_level == MFOSelectLevel.M)
            {
                /* 2013.06.12. Aiden. VisibleDefaultFilter 가 true 인 경우 Filter 가 없으면 에러 */
                if (VisibleDefaultFilter == true && MPCF.Trim(ListCond_Filter) == "")
                {
                    txtFilter.Focus();
                    return;
                }


                if (ViewType == MaterialViewType.LastActiveVersion)
                {
                    WIPLIST.ViewMaterialList(treMFOList, '1', MaterialType, cDeleteFlag, cDeactiveFlag, ListCond_Filter, true, null, ListCond_ExtFactory);
                }
                else
                {
                    WIPLIST.ViewMaterialList(treMFOList, '1', MaterialType, cDeleteFlag, cDeactiveFlag, ListCond_Filter, false, null, ListCond_ExtFactory);
                }
            }
            else if (m_select_level == MFOSelectLevel.FO ||
                     m_select_level == MFOSelectLevel.F)
            {
                WIPLIST.ViewFlowList(treMFOList, '1', "", 0, ListCond_Filter, null, ListCond_ExtFactory);
            }
            else if (m_select_level == MFOSelectLevel.O)
            {
                WIPLIST.ViewOperationList(treMFOList, '1', "", 0, "", ListCond_Filter, null, ListCond_ExtFactory);
            }
            else if (m_select_level == MFOSelectLevel.Factory)
            {
                treMFOList.Nodes.Add(MPGV.gsFactory, MPGV.gsFactory, (int)SMALLICON_INDEX.IDX_FACTORY);
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
                this.treMFOList_AfterSelect(treMFOList, tveArg);

                if (treMFOList.GetNodeCount(true) > 1)
                {
                    treMFOList.SelectedNode = MPCF.FindTreeNode(treMFOList, s_full_path);
                    if (SelectedNode == null)
                    {
                        treMFOList.SelectedNode = treMFOList.TopNode.FirstNode;
                    }

                    treMFOList.SelectedNode.EnsureVisible();
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
                TreeNode tNode;

                //Modify by J.S. 2011.10.06 TREE NODE가 선택되지 않았을때 검색되지 않는 문제 해결
                if (treMFOList.Nodes.Count < 1) return;

                if (m_selected_item == TreeSelectedItem.None  && SelectedNode == null)
                {
                    //마지막 NODE를 시작점으로 설정(처음부터 검색되게 하기 위해)
                    tNode = treMFOList.Nodes[treMFOList.Nodes.Count - 1];

                    tn = MPCF.FindTreeNodeNextPartial(treMFOList.Nodes[0], tNode, s_text);
                    if (tn != null)
                    {
                        treMFOList.SelectedNode = tn;

                        TreeViewEventArgs ev = new TreeViewEventArgs(tn, TreeViewAction.ByMouse);
                        treMFOList_AfterSelect(treMFOList, ev);

                        treMFOList.SelectedNode.EnsureVisible();
                    }
                }
                else
                {
                    if (m_selected_item == TreeSelectedItem.None) return;
                    if (SelectedNode == null) return;
                    tn = MPCF.FindTreeNodeNextPartial(treMFOList.Nodes[0], SelectedNode, s_text);
                    if (tn != null)
                    {
                        treMFOList.SelectedNode = tn;

                        TreeViewEventArgs ev = new TreeViewEventArgs(tn, TreeViewAction.ByMouse);
                        treMFOList_AfterSelect(treMFOList, ev);

                        treMFOList.SelectedNode.EnsureVisible();
                    }
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

            if (m_select_level == MFOSelectLevel.NONE) return;

            m_selected_item = TreeSelectedItem.None;
            lisList.Items.Clear();
            while (lisList.Columns.Count > 0)
            {
                lisList.Columns.RemoveAt(0);
            }

            switch (m_select_level)
            {
                case MFOSelectLevel.MFO:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Material", 0);
                    lisList.Columns.Add(col);

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Version", 0);
                    lisList.Columns.Add(col);

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Flow", 0);
                    lisList.Columns.Add(col);

                    if (m_include_flow_seq == true)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Seq", 0);
                        lisList.Columns.Add(col);
                    }

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Operation", 0);
                    lisList.Columns.Add(col);
                    break;

                case MFOSelectLevel.MF:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Material", 0);
                    lisList.Columns.Add(col);

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Version", 0);
                    lisList.Columns.Add(col);

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Flow", 0);
                    lisList.Columns.Add(col);

                    if (m_include_flow_seq == true)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Seq", 0);
                        lisList.Columns.Add(col);
                    }
                    break;

                case MFOSelectLevel.MO:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Material", 0);
                    lisList.Columns.Add(col);

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Version", 0);
                    lisList.Columns.Add(col);

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Operation", 0);
                    lisList.Columns.Add(col);
                    break;

                case MFOSelectLevel.M:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Material", 0);
                    lisList.Columns.Add(col);

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Version", 0);
                    lisList.Columns.Add(col);
                    break;

                case MFOSelectLevel.FO:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Flow", 0);
                    lisList.Columns.Add(col);

                    if (m_include_flow_seq == true)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Seq", 0);
                        lisList.Columns.Add(col);
                    }

                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Operation", 0);
                    lisList.Columns.Add(col);
                    break;

                case MFOSelectLevel.F:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Flow", 0);
                    lisList.Columns.Add(col);

                    if (m_include_flow_seq == true)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Seq", 0);
                        lisList.Columns.Add(col);
                    }
                    break;

                case MFOSelectLevel.O:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Operation", 0);
                    lisList.Columns.Add(col);
                    break;

                case MFOSelectLevel.Factory:
                    col = new ColumnHeader();
                    col.Text = MPCF.FindLanguage("Factory", 0);
                    lisList.Columns.Add(col);
                    break;
            }

            if (GetOnlySetDataEvent != null)
                GetOnlySetDataEvent(this, new EventArgs());

            if (lisList.Items.Count > 0)
                MPCF.FitColumnHeader(lisList);

        }

        private void ResizeMainTop()
        {
            int i_height;

            i_height = 0;

            pnlMFO.Visible = mb_visible_MFO;
            if (mb_visible_MFO == true)
            {
                i_height += pnlMFO.Height;
            }
            pnlMO.Visible = mb_visible_MO;
            if (mb_visible_MO == true)
            {
                i_height += pnlMO.Height;
            }
            pnlMF.Visible = mb_visible_MF;
            if (mb_visible_MF == true)
            {
                i_height += pnlMF.Height;
            }
            pnlM.Visible = mb_visible_M;
            if (mb_visible_M == true)
            {
                i_height += pnlM.Height;
            }
            pnlFO.Visible = mb_visible_FO;
            if (mb_visible_FO == true)
            {
                i_height += pnlFO.Height;
            }
            pnlF.Visible = mb_visible_F;
            if (mb_visible_F == true)
            {
                i_height += pnlF.Height;
            }
            pnlO.Visible = mb_visible_O;
            if (mb_visible_O == true)
            {
                i_height += pnlO.Height;
            }
            pnlFactory.Visible = mb_visible_Factory;
            if (mb_visible_Factory == true)
            {
                i_height += pnlFactory.Height;
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


            if (mb_visible_MFO == true ||
                mb_visible_MO == true ||
                mb_visible_MF == true ||
                mb_visible_M == true)
            {
                if (mb_visible_material_type == false && mb_visible_material_filter == false && mb_visible_material_include_delete == false)
                {
                    grpMaterialType.Visible = false;
                    grpMaterialType.Height = 0;
                }
                else if (mb_visible_material_type == false && mb_visible_material_filter == false && mb_visible_material_include_delete == true)
                {
                    grpMaterialType.Visible = true;
                    grpMaterialType.Height = 34;

                    pnlMaterialType.Visible = false;
                    pnlMaterialFilter.Visible = false;
                    pnlMaterialDeleteCondition.Visible = true;

                    pnlMaterialDeleteCondition.Top = 10;
                }
                else if (mb_visible_material_type == true && mb_visible_material_filter == false && mb_visible_material_include_delete == false)
                {
                    grpMaterialType.Visible = true;
                    grpMaterialType.Height = 34;

                    pnlMaterialType.Visible = true;
                    pnlMaterialFilter.Visible = false;
                    pnlMaterialDeleteCondition.Visible = false;
                }
                else if (mb_visible_material_type == true && mb_visible_material_filter == false && mb_visible_material_include_delete == true)
                {
                    grpMaterialType.Visible = true;
                    grpMaterialType.Height = 52;

                    pnlMaterialType.Visible = true;
                    pnlMaterialFilter.Visible = false;
                    pnlMaterialDeleteCondition.Visible = true;

                    pnlMaterialDeleteCondition.Top = 30;
                }
                else if (mb_visible_material_type == true && mb_visible_material_filter == true && mb_visible_material_include_delete == false)
                {
                    grpMaterialType.Visible = true;
                    grpMaterialType.Height = 60;

                    pnlMaterialType.Visible = true;
                    pnlMaterialFilter.Visible = true;
                    pnlMaterialDeleteCondition.Visible = false;

                    pnlMaterialFilter.Top = 33;
                }
                else if (mb_visible_material_type == false && mb_visible_material_filter == true && mb_visible_material_include_delete == false)
                {
                    grpMaterialType.Visible = true;
                    grpMaterialType.Height = 34;

                    pnlMaterialType.Visible = false;
                    pnlMaterialFilter.Visible = true;
                    pnlMaterialDeleteCondition.Visible = false;

                    pnlMaterialFilter.Top = 10;
                }
                else if (mb_visible_material_type == false && mb_visible_material_filter == true && mb_visible_material_include_delete == true)
                {
                    grpMaterialType.Visible = true;
                    grpMaterialType.Height = 52;

                    pnlMaterialType.Visible = false;
                    pnlMaterialFilter.Visible = true;
                    pnlMaterialDeleteCondition.Visible = true;

                    pnlMaterialFilter.Top = 10;
                    pnlMaterialDeleteCondition.Top = 30;
                }
                else if (mb_visible_material_type == true && mb_visible_material_filter == true && mb_visible_material_include_delete == true)
                {
                    grpMaterialType.Visible = true;
                    grpMaterialType.Height = 80;

                    pnlMaterialType.Visible = true;
                    pnlMaterialFilter.Visible = true;
                    pnlMaterialDeleteCondition.Visible = true;

                    pnlMaterialFilter.Top = 33;
                    pnlMaterialDeleteCondition.Top = 55;
                }

                if (mb_visible_material_view_type == true)
                {
                    pnlMaterialViewType.Visible = true;
                }
                else
                {
                    pnlMaterialViewType.Visible = false;
                }
            }
            else
            {
                grpMaterialType.Visible = false;
                grpMaterialType.Height = 0;
                pnlMaterialViewType.Visible = false;
            }

            pnlMainTop.Height = grpLevel.Height + grpMaterialType.Height;
        
        }

        private void GetMaterialInfo(TreeNode node, bool b_get_flow, bool b_get_oper)
        {
            /* 최신버전이므로 Material ID와 Version이 한 Node에 존재한다 */
            m_selected_item = TreeSelectedItem.Material;
            ClearItemValue();
            
            /* 2013.06.12. Aiden. Material ID 에 (,) 가 포함된 경우 Parsing이 제대로 안되는 문제 해결 */
            MPCR.ParseSequenceInfo(node.Tag.ToString(), ref m_select_mat_id, ref m_select_version);

            if (b_get_flow == true)
            {
                if (node.GetNodeCount(true) < 1)
                {
                    if (m_include_flow_seq == true)
                    {
                        WIPLIST.ViewFlowList(treMFOList, '2', m_select_mat_id, m_select_version, "", node, ListCond_ExtFactory);
                    }
                    else
                    {
                        WIPLIST.ViewFlowList(treMFOList, '3', m_select_mat_id, m_select_version, "", node, ListCond_ExtFactory);
                    }
                }
            }
            else if (b_get_oper == true)
            {
                if (node.GetNodeCount(true) < 1)
                {
                    WIPLIST.ViewOperationList(treMFOList, '1', "", 0, "", "", node, ListCond_ExtFactory);
                }
            }
        }

        private void GetMaterialVersionList(TreeNode node)
        {
            /* 모든 Version 이므로 Material ID의 다음 Node에 Version이 있다. */
            m_selected_item = TreeSelectedItem.Material;
            ClearItemValue();

            m_select_mat_id = node.Text;
            m_select_version = 0;

            if (node.GetNodeCount(true) < 1)
            {
                char cDeleteFlag;
                char cDeactiveFlag;

                cDeleteFlag = (IncludeDeleteMaterial == true) ? '%' : ' ';
                cDeactiveFlag = (IncludeDeactiveMaterial == true) ? '%' : ' ';

                WIPLIST.ViewMaterialVersionList(treMFOList, '1', m_select_mat_id, MaterialType, cDeleteFlag, cDeactiveFlag, node, ListCond_ExtFactory);
            }
        }

        private void GetMaterialVersionInfo(TreeNode node, bool b_get_flow, bool b_get_oper)
        {
            /* 모든 Version 이므로 Material ID의 다음 Node에 Version이 있다. */
            m_selected_item = TreeSelectedItem.MaterialVersion;
            ClearItemValue();

            m_select_mat_id = node.Parent.Text;
            m_select_version = MPCF.ToInt(MPCF.SubtractString(node.Text, ":", false, false));

            if (b_get_flow == true)
            {
                if (node.GetNodeCount(true) < 1)
                {
                    if (m_include_flow_seq == true)
                    {
                        WIPLIST.ViewFlowList(treMFOList, '2', m_select_mat_id, m_select_version, "", node, ListCond_ExtFactory);
                    }
                    else
                    {
                        WIPLIST.ViewFlowList(treMFOList, '3', m_select_mat_id, m_select_version, "", node, ListCond_ExtFactory);
                    }
                }
            }
            else if (b_get_oper == true)
            {
                if (node.GetNodeCount(true) < 1)
                {
                    WIPLIST.ViewOperationList(treMFOList, '1', "", 0, "", "", node, ListCond_ExtFactory);
                }
            }

        }

        private void GetFlowInfo(TreeNode node, bool b_get_oper, bool b_get_material_info)
        {
            m_selected_item = TreeSelectedItem.Flow;
            ClearItemValue();

            if (b_get_material_info == true)
            {
                if (ViewType == MaterialViewType.LastActiveVersion)
                {
                    /* 2013.06.12. Aiden. Material ID 에 (,) 가 포함된 경우 Parsing이 제대로 안되는 문제 해결 */
                    MPCR.ParseSequenceInfo(node.Parent.Tag.ToString(), ref m_select_mat_id, ref m_select_version);
                }
                else
                {
                    m_select_mat_id = node.Parent.Parent.Text;
                    m_select_version = MPCF.ToInt(MPCF.SubtractString(node.Parent.Text, ":", false, false));
                }
            }

            // Flow Seq는 Material이 존재할때만 유효함.
            if (m_include_flow_seq == true && b_get_material_info == true)
            {
                /* 2013.06.12. Aiden. Material ID 에 (,) 가 포함된 경우 Parsing이 제대로 안되는 문제 해결 */
                MPCR.ParseSequenceInfo(node.Text, ref m_select_flow, ref m_select_flow_seq_num);
                /* Updated By YJJung 151210 Tag Null 참조로 MES Client 다운되는  현상 */
                //MPCR.ParseSequenceInfo(node.Tag.ToString(), ref m_select_flow, ref m_select_flow_seq_num);
            }
            else
            {
                m_select_flow = MPCF.SubtractString(node.Text, ":", false, false);
                m_select_flow_seq_num = 0;
            }

            if (b_get_oper == true)
            {
                if (node.GetNodeCount(true) < 1)
                {
                    WIPLIST.ViewOperationList(treMFOList, '2', "", 0, m_select_flow, "", node, ListCond_ExtFactory);
                }
            }
        }

        private void GetOperInfo(TreeNode node, bool b_get_material_info, bool b_get_flow_info)
        {
            m_selected_item = TreeSelectedItem.Oper;
            ClearItemValue();

            if (b_get_material_info == true && b_get_flow_info == true)
            {
                if (ViewType == MaterialViewType.LastActiveVersion)
                {
                    /* 2013.06.12. Aiden. Material ID 에 (,) 가 포함된 경우 Parsing이 제대로 안되는 문제 해결 */
                    MPCR.ParseSequenceInfo(node.Parent.Parent.Tag.ToString(), ref m_select_mat_id, ref m_select_version);
                }
                else
                {
                    m_select_mat_id = node.Parent.Parent.Parent.Text;
                    m_select_version = MPCF.ToInt(MPCF.SubtractString(node.Parent.Parent.Text, ":", false, false));
                }

                if (m_include_flow_seq == true)
                {
                    /* 2013.06.12. Aiden. Material ID 에 (,) 가 포함된 경우 Parsing이 제대로 안되는 문제 해결 */
                    MPCR.ParseSequenceInfo(node.Parent.Text, ref m_select_flow, ref m_select_flow_seq_num);
                    /* Updated By YJJung 151210 Tag Null 참조로 MES Client 다운되는  현상 */
                    //MPCR.ParseSequenceInfo(node.Parent.Tag.ToString(), ref m_select_flow, ref m_select_flow_seq_num);
                }
                else
                {
                    m_select_flow = MPCF.SubtractString(node.Parent.Text, ":", false, false);
                    m_select_flow_seq_num = 0;
                }

            }
            else if (b_get_material_info == true)
            {
                if (ViewType == MaterialViewType.LastActiveVersion)
                {
                    /* 2013.06.12. Aiden. Material ID 에 (,) 가 포함된 경우 Parsing이 제대로 안되는 문제 해결 */
                    MPCR.ParseSequenceInfo(node.Parent.Tag.ToString(), ref m_select_mat_id, ref m_select_version);
                }
                else
                {
                    m_select_mat_id = node.Parent.Parent.Text;
                    m_select_version = MPCF.ToInt(MPCF.SubtractString(node.Parent.Text, ":", false, false));
                }
            }
            else if (b_get_flow_info == true)
            {
                m_select_flow = MPCF.SubtractString(node.Parent.Text, ":", false, false);
                m_select_flow_seq_num = 0;
            }

            m_select_oper = MPCF.SubtractString(node.Text, ":", false, false);
        }

        private void ClearItemValue()
        {
            m_select_mat_id = "";
            m_select_version = 0;
            m_select_flow = "";
            m_select_flow_seq_num = 0;
            m_select_oper = "";
            m_select_factory = "";
        }

    }

    /// <summary>
    /// Material List의 표시 형태
    /// </summary>
    public enum MaterialViewType
    {
        LastActiveVersion = 0,
        TreeViewList = 1
    }

    /// <summary>
    /// 표시 Level
    /// </summary>
    public enum MFOSelectLevel
    {
        NONE = -1,
        MFO = 0,
        FO = 1,
        O = 2,
        MO = 3,
        MF = 4,
        M = 5,
        F = 6,
        Factory = 7
    }

    /// <summary>
    /// 현재 Level에서의 선택 Item
    /// </summary>
    public enum TreeSelectedItem
    {
        None = 0,
        Material = 1,
        MaterialVersion = 2,
        Flow = 3,
        Oper = 4,
        Resource = 5,
        ResGrp = 6,
        ResType = 7,
        Factory = 8,
        Another = 9
    }

}
