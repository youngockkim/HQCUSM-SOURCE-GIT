using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.SECCore
{
    public partial class frmSECSetupFlexibleHeader : Miracom.MESCore.SetupForm01
    {
        public frmSECSetupFlexibleHeader()
        {
            InitializeComponent();
        }

        private bool UpdateFlexibleHeader()
        {
            TRSNode in_node = new TRSNode("UPDATE_FLEXIBLE_HEADER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            int i_member_seq;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddString("SERVICE_NAME", cdvService.Text);
                in_node.AddString("USER_ID", MPCF.Trim(cdvUserID.Text), true);
                in_node.AddString("DSP_ID", MPCF.Trim(cdvDspID.Text));

                i_member_seq = 0;
                MakeHeaderMemberToInNode(tvAttachMember.Nodes[0], ref i_member_seq, in_node);

                if (MPCR.CallService("SEC", "SEC_Update_Flexible_Header", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private void MakeHeaderMemberToInNode(TreeNode tn_node, ref int i_member_seq, TRSNode in_node)
        {
            TRSNode header_list;

            foreach (TreeNode node in tn_node.Nodes)
            {
                header_list = in_node.AddNode("HEADER_LIST");

                header_list.AddInt("MEMBER_SEQ", i_member_seq);
                header_list.AddString("MEMBER_NAME", MPCF.SubtractString(node.Text, ":", false, false));
                header_list.AddString("MEMBER_PATH", MPCF.Trim(node.Tag));

                i_member_seq++;

                if (node.Nodes.Count > 0)
                {
                    MakeHeaderMemberToInNode(node, ref i_member_seq, in_node);
                }
            }
        }

        private bool ViewServiceList(Control control)
        {
            TRSNode in_node = new TRSNode("View_Service_List_In");
            TRSNode out_node = new TRSNode("View_Service_List_Out");
            ListViewItem itmx;
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", cdvModule.Text);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_NAME")), (int)SMALLICON_INDEX.IDX_KEY);
                    if (((ListView)control).Columns.Count > 1)
                    {
                        itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_DESC")));
                    }
                    ((ListView)control).Items.Add(itmx);
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_SERVICE_NAME") != "");

            return true;
        }

        private bool ViewServiceMemberList()
        {
            TRSNode in_node = new TRSNode("View_Service_Member_List_In");
            TRSNode out_node = new TRSNode("View_Service_Member_List_Out");
            ArrayList a_members;
            TreeNode tv_node;
            List<TRSNode> lis_member;
            int i;

            a_members = new ArrayList();
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            MPCF.InitTreeView(tvMember);

            if (MPCF.Trim(cdvModule.Text) == "")
            {
                in_node.AddString("MODULE_NAME", cdvService.Text.Substring(0, 3));
            }
            else
            {
                in_node.AddString("MODULE_NAME", cdvModule.Text);
            }

            in_node.AddString("SERVICE_NAME", cdvService.Text);
            in_node.AddChar("DIRECTION", 'O');
            
            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList("SERVICE_MEMBER_LIST").Count; i++)
                {
                    a_members.Add(out_node.GetList("SERVICE_MEMBER_LIST")[i]);
                }

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);

            tv_node = new TreeNode("[Output Members]", (int)SMALLICON_INDEX.IDX_MODULE, (int)SMALLICON_INDEX.IDX_MODULE);

            SetMemberToTree(tv_node, a_members, 0, "");
            
            tvMember.Nodes.Add(tv_node);

            tv_node.ExpandAll();
            tv_node.EnsureVisible();

            ViewFlexibleHeaderList();



            in_node.Init();
            out_node.Init();

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '4';

            if (MPCF.Trim(cdvModule.Text) == "")
            {
                in_node.AddString("MODULE_NAME", cdvService.Text.Substring(0, 3));
            }
            else
            {
                in_node.AddString("MODULE_NAME", cdvModule.Text);
            }

            in_node.AddString("SERVICE_NAME", cdvService.Text);
            in_node.AddChar("DIRECTION", 'I');

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                lis_member = out_node.GetList("SERVICE_MEMBER_LIST");
                if (lis_member != null)
                {
                    for (i = 0; i < lis_member.Count; i++)
                    {
                        if (lis_member[i].GetString("MEMBER_NAME") == "DSP_ID")
                        {
                            cdvDspID.Enabled = true;
                            break;
                        }
                    }

                    if (i >= lis_member.Count)
                    {
                        cdvDspID.Text = "";
                        cdvDspID.Enabled = false;
                    }
                }

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);
                        
            return true;
        }

        private bool ViewFlexibleHeaderList()
        {
            TRSNode in_node = new TRSNode("VIEW_FLEXIBLE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FLEXIBLE_LIST_OUT");
            int i;
            ArrayList a_members;
            TreeNode tv_node;

            try
            {
                a_members = new ArrayList();
                MPCF.InitTreeView(tvAttachMember);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SERVICE_NAME", cdvService.Text);
                in_node.AddString("USER_ID", cdvUserID.Text);
                in_node.AddString("DSP_ID", cdvDspID.Text);

                do
                {
                    if (MPCR.CallService("SEC", "SEC_View_Flexible_Header_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("HEADER_LIST").Count; i++)
                    {
                        a_members.Add(out_node.GetList("HEADER_LIST")[i]);
                    }

                    in_node.SetInt("NEXT_MEMBER_SEQ", out_node.GetInt("NEXT_MEMBER_SEQ"));

                } while (in_node.GetInt("NEXT_MEMBER_SEQ") > 0);

                tv_node = new TreeNode("[Attached Members]", (int)SMALLICON_INDEX.IDX_MODULE, (int)SMALLICON_INDEX.IDX_MODULE);

                SetMemberToTree(tv_node, a_members, 0, "");

                tvAttachMember.Nodes.Add(tv_node);

                tv_node.ExpandAll();
                tv_node.EnsureVisible();

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private bool IsEssentialMember(TRSNode serviceMember)
        {

            // 필수 항목들은 최상위에만 적용되고 있는것을 기본으로 고려
            if (serviceMember.GetInt("MEMBER_DEPTH") != 0)
                return false;

            if (serviceMember.GetChar("DIRECTION") == 'I')
            {
                switch (serviceMember.GetString("MEMBER_NAME"))
                {
                    //In Part
                    case TRSDefine.IN_FACTORY:
                    case TRSDefine.IN_LANGUAGE:
                    case TRSDefine.IN_PASSPORT:
                    case TRSDefine.IN_PASSWORD:
                    case TRSDefine.IN_PROCSTEP:
                    case TRSDefine.IN_USERID:
                    case TRSDefine.IN_LOGLEVEL:
                        return true;
                    //Out Part
                }
            }
            else
            {
                switch (serviceMember.GetString("MEMBER_NAME"))
                {
                    case TRSDefine.OUT_DBERRMSG:
                    case TRSDefine.OUT_FIELDMSG:
                    case TRSDefine.OUT_MSG:
                    case TRSDefine.OUT_MSGCATE:
                    case TRSDefine.OUT_MSGCODE:
                    case TRSDefine.OUT_STATUSVALUE:
                        return true;
                }
            }

            return false;

        }

        private int GetIconIndex(TRSNode member)
        {
            int icon_index = (int)SMALLICON_INDEX.IDX_VERSION;

            if (IsEssentialMember(member))
            {
                icon_index = (int)SMALLICON_INDEX.IDX_KEY;
            }
            else
            {
                switch (member.GetString("MEMBER_TYPE"))
                {
                    case "String":
                    case "Binary":
                    case "Boolean":
                    case "Char":
                    case "UByte":
                    case "UShort":
                    case "UInt":
                    case "ULong":
                    case "Float":
                    case "Double":
                    case "Byte":
                    case "Short":
                    case "Int":
                    case "Long":
                        break;
                    case "Array":
                        icon_index = (int)SMALLICON_INDEX.IDX_CODE_TABLE;
                        break;
                    case "List":
                        icon_index = (int)SMALLICON_INDEX.IDX_STOCKER;
                        break;
                }
            }

            return icon_index;
        }

        private TreeNode GetParentTreeNode(TreeNode tn_parent, string s_parent_path)
        {
            TreeNode tn_ret;

            foreach (TreeNode tn in tn_parent.Nodes)
            {
                if (tn.Tag != null)
                {
                    if (MPCF.Trim(tn.Tag).Equals(s_parent_path))
                    {
                        return tn;
                    }
                }

                if (tn.Nodes.Count > 0)
                {
                    tn_ret = GetParentTreeNode(tn, s_parent_path);

                    if (tn_ret != null)
                    {
                        return tn_ret;
                    }
                }
            }

            return null;
        }

        private void SetNodeFontStyle(ref TreeNode node, char cReqFlag, bool isOverride)
        {
            if (cReqFlag == 'M')
            {
                node.NodeFont = new Font("Microsoft Sans Serif", 8.25f, (isOverride ? FontStyle.Bold | FontStyle.Underline : FontStyle.Bold));
            }
            else if (cReqFlag == 'C')
            {
                node.NodeFont = new Font("Microsoft Sans Serif", 8.25f, (isOverride ? FontStyle.Italic | FontStyle.Underline : FontStyle.Italic));
            }
            else
            {
                node.NodeFont = new Font("Microsoft Sans Serif", 8.25f, (isOverride ? FontStyle.Regular | FontStyle.Underline : FontStyle.Regular));
            }
        }

        private TreeNode AddServiceMemberToTreeNode(TreeNode targetNode, TRSNode memberItem)
        {
            int icon_index = GetIconIndex(memberItem);

            TreeNode treeNode = targetNode.Nodes.Add(memberItem.GetString("MEMBER_NAME"),
                                                     " ",
                                                     icon_index,
                                                     icon_index);

            treeNode.Tag = memberItem.GetString("MEMBER_PATH");

            SetNodeFontStyle(ref treeNode, memberItem.GetChar("REQ_MEMBER_FLAG"), (memberItem.GetChar("OVERRIDE_FLAG") == 'Y'));

            if (memberItem.GetString("MEMBER_TYPE").Equals("String"))
                treeNode.Text = memberItem.GetString("MEMBER_NAME") + " : " + memberItem.GetString("MEMBER_TYPE") + "(" + memberItem.GetInt("MEMBER_SIZE").ToString() + ")";
            else
            {
                if (memberItem.GetString("MEMBER_TYPE").Equals("Array"))
                    treeNode.Text = memberItem.GetString("MEMBER_NAME") + " : " + memberItem.GetString("MEMBER_TYPE") + " : " + memberItem.GetString("ARRAY_TYPE");
                else
                    treeNode.Text = memberItem.GetString("MEMBER_NAME") + " : " + memberItem.GetString("MEMBER_TYPE");
            }

            return treeNode;
        }

        private int SetMemberToTree(TreeNode tv_node, ArrayList a_members, int index, string s_parent_path)
        {
            int i;
            int i_icon_index;
            TRSNode member;
            TreeNode tv_new_node = null;
            string s_cur_parent_path;

            for (i = index; i < a_members.Count; i++)
            {
                member = (TRSNode)a_members[i];

                if (member.GetInt("MEMBER_DEPTH") == 0)
                {
                    tv_new_node = tv_node;
                }
                else
                {
                    if (tv_new_node != null && tv_new_node.Tag != null)
                    {
                        if (MPCF.Trim(tv_new_node.Tag).Equals(member.GetString("PARENT_MEMBER_PATH")) == false)
                        {
                            tv_new_node = GetParentTreeNode(tv_node, member.GetString("PARENT_MEMBER_PATH"));
                        }
                    }
                    else
                    {
                        tv_new_node = GetParentTreeNode(tv_node, member.GetString("PARENT_MEMBER_PATH"));
                    }
                }

                if (tv_new_node != null)
                {
                    AddServiceMemberToTreeNode(tv_new_node, member);
                }

                /*
                s_cur_parent_path = member.GetString("PARENT_MEMBER_PATH");

                if (s_parent_path == s_cur_parent_path)
                {
                    i_icon_index = (int)SMALLICON_INDEX.IDX_VERSION;
                    if (member.GetString("MEMBER_TYPE") == "List")
                    {
                        i_icon_index = (int)SMALLICON_INDEX.IDX_STOCKER;
                    }
                    else if (member.GetString("MEMBER_TYPE") == "Array")
                    {
                        i_icon_index = (int)SMALLICON_INDEX.IDX_CODE_TABLE;
                    }

                    if (member.GetString("MEMBER_PATH") == TRSDefine.OUT_STATUSVALUE ||
                        member.GetString("MEMBER_PATH") == TRSDefine.OUT_MSG ||
                        member.GetString("MEMBER_PATH") == TRSDefine.OUT_MSGCODE ||
                        member.GetString("MEMBER_PATH") == TRSDefine.OUT_MSGCATE ||
                        member.GetString("MEMBER_PATH") == TRSDefine.OUT_FIELDMSG ||
                        member.GetString("MEMBER_PATH") == TRSDefine.OUT_DBERRMSG ||
                        member.GetString("MEMBER_PATH").StartsWith(TRSDefine.OUT_FIELDMSG) == true)
                    {
                        i_icon_index = (int)SMALLICON_INDEX.IDX_KEY;
                    }

                    if (member.GetString("MEMBER_PRT") == null || member.GetString("MEMBER_PRT") == "")
                    {
                        member.SetString("MEMBER_PRT", member.GetString("MEMBER_NAME"));
                    }

                    tv_new_node = new TreeNode(member.GetString("MEMBER_NAME") + " : " + member.GetString("MEMBER_PRT"), i_icon_index, i_icon_index);                    
                    tv_new_node.Tag = member.GetString("MEMBER_PATH");
                    tv_node.Nodes.Add(tv_new_node);
                }
                else
                {
                    if (s_parent_path.Length < s_cur_parent_path.Length)
                    {
                        i = SetMemberToTree(tv_new_node, a_members, i, s_cur_parent_path);
                    }
                    else
                    {
                        return i - 1;
                    }
                }
                 * */
            }

            return i;
        }

        private TreeNode CheckTreeMemberPath(TreeNode tn_node, string s_member_path)
        {
            TreeNode tn_tmp;

            foreach (TreeNode node in tn_node.Nodes)
            {
                if (MPCF.Trim(node.Tag).Equals(s_member_path))
                {
                    return node;
                }

                if (node.Nodes.Count > 0)
                {
                    tn_tmp = CheckTreeMemberPath(node, s_member_path);
                    if (tn_tmp != null)
                    {
                        return tn_tmp;
                    }
                }
            }

            return null;
        }


        private void frmSECSetupFlexibleHeader_Load(object sender, EventArgs e)
        {
            MPCF.InitTreeView(tvAttachMember);
            MPCF.InitTreeView(tvMember);

            grpAttachFunc_Resize(null, null);
        }

        private void cdvService_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnDelete.PerformClick();
        }

        private void cdvService_ButtonPress(object sender, EventArgs e)
        {
            cdvService.Init();
            MPCF.InitListView(cdvService.GetListView);
            cdvService.Columns.Add("Service", 150, HorizontalAlignment.Left);
            cdvService.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvService.SelectedSubItemIndex = 0;

            ViewServiceList(cdvService.GetListView);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvService.Text) != "")
            {
                ViewServiceMemberList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFlexibleHeader();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i;
            TreeNode tn_sel_node;
            TreeNode tn_parent;
            TreeNode tn_node;
            ArrayList al_selected_nodes;
            string s_member_path;

            if (tvMember.SelectedNodes.Count < 1) return;

            try
            {
                al_selected_nodes = (ArrayList)tvMember.SelectedNodes.Clone();
                al_selected_nodes.Sort(new TreeNodeComparer(true));

                for (i = 0; i < al_selected_nodes.Count; i++)
                {
                    tn_sel_node = (TreeNode)al_selected_nodes[i];
                    s_member_path = MPCF.Trim(tn_sel_node.Tag);

                    if (s_member_path.Equals(TRSDefine.OUT_STATUSVALUE) ||
                        s_member_path.Equals(TRSDefine.OUT_MSG) ||
                        s_member_path.Equals(TRSDefine.OUT_MSGCODE) ||
                        s_member_path.Equals(TRSDefine.OUT_MSGCATE) ||
                        s_member_path.Equals(TRSDefine.OUT_FIELDMSG) ||
                        s_member_path.Equals(TRSDefine.OUT_DBERRMSG))
                    {
                        continue;
                    }

                    if (CheckTreeMemberPath(tvAttachMember.Nodes[0], s_member_path) != null)
                    {
                        continue;
                    }

                    tn_parent = tvAttachMember.Nodes[0];

                    if (tn_sel_node.Parent.Parent != null)
                    {
                        tn_parent = CheckTreeMemberPath(tvAttachMember.Nodes[0], MPCF.Trim(tn_sel_node.Parent.Tag));
                        if (tn_parent == null)
                        {
                            continue;
                        }
                    }


                    tn_node = new TreeNode(tn_sel_node.Text, tn_sel_node.ImageIndex, tn_sel_node.ImageIndex);
                    tn_node.Tag = tn_sel_node.Tag;

                    if (tvAttachMember.SelectedNode != null && tn_parent == tvAttachMember.SelectedNode.Parent)
                    {
                        tn_parent.Nodes.Insert(tvAttachMember.SelectedNode.Index, tn_node);
                    }
                    else
                    {
                        tn_parent.Nodes.Add(tn_node);
                    }

                    tn_parent.Expand();
                    tn_parent.EnsureVisible();
                }

                if (al_selected_nodes.Count == 1)
                {
                    tn_sel_node = (TreeNode)al_selected_nodes[0];

                    if (tn_sel_node.NextNode != null)
                    {
                        al_selected_nodes.Clear();
                        al_selected_nodes.Add(tn_sel_node.NextNode);

                        tvMember.SelectedNode = null;
                        tvMember.SelectedNodes = al_selected_nodes;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int i;
            TreeNode tn_sel_node;

            if (tvAttachMember.SelectedNodes.Count < 1) return;

            try
            {
                for (i = 0; i < tvAttachMember.SelectedNodes.Count; i++)
                {
                    tn_sel_node = (TreeNode)tvAttachMember.SelectedNodes[i];
                    if (tn_sel_node.Parent == null)
                    {
                        continue;
                    }

                    tn_sel_node.Parent.Nodes.Remove(tn_sel_node);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int i;
            int i_prev_index;
            TreeNode tn_parent;
            TreeNode tn_temp;
            TreeNode tn_curr;
            ArrayList al_selected_nodes;
            ArrayList al_new_selected_nodes;

            if (tvAttachMember.SelectedNodes.Count < 1) return;

            try
            {
                al_new_selected_nodes = new ArrayList();
                al_selected_nodes = (ArrayList)tvAttachMember.SelectedNodes.Clone();
                al_selected_nodes.Sort(new TreeNodeComparer(true));

                for (i = 0; i < al_selected_nodes.Count; i++)
                {
                    tn_curr = (TreeNode)(al_selected_nodes[i]);

                    tn_parent = tn_curr.Parent;
                    tn_temp = tn_parent.FirstNode;

                    if (tn_curr != tn_temp)
                    {
                        if (al_selected_nodes.Contains(tn_curr.PrevNode) == false)
                        {
                            tn_temp = (TreeNode)tn_curr.Clone();

                            i_prev_index = tn_curr.PrevNode.Index;
                            tn_parent.Nodes.Insert(i_prev_index, tn_temp);
                            tn_parent.Nodes.Remove(tn_curr);
                        }
                    }

                    if (al_new_selected_nodes.Contains(tn_temp) == false)
                    {
                        tn_temp.ForeColor = Color.Black;
                        tn_temp.BackColor = Color.White;

                        al_new_selected_nodes.Add(tn_temp);
                    }
                }

                if (al_new_selected_nodes.Count > 0)
                {
                    tvAttachMember.SelectedNode = null;
                    tvAttachMember.SelectedNodes = al_new_selected_nodes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int i;
            int i_next_index;
            TreeNode tn_parent;
            TreeNode tn_temp;
            TreeNode tn_curr;
            ArrayList al_selected_nodes;
            ArrayList al_new_selected_nodes;

            if (tvAttachMember.SelectedNodes.Count < 1) return;

            try
            {
                al_new_selected_nodes = new ArrayList();
                al_selected_nodes = (ArrayList)tvAttachMember.SelectedNodes.Clone();
                al_selected_nodes.Sort(new TreeNodeComparer(false));

                for (i = 0; i < al_selected_nodes.Count; i++)
                {
                    tn_curr = (TreeNode)(al_selected_nodes[i]);

                    tn_parent = tn_curr.Parent;
                    tn_temp = tn_parent.LastNode;

                    if (tn_curr != tn_temp)
                    {
                        if (al_selected_nodes.Contains(tn_curr.NextNode) == false)
                        {
                            tn_temp = (TreeNode)tn_curr.Clone();

                            i_next_index = tn_curr.NextNode.Index + 1;
                            tn_parent.Nodes.Insert(i_next_index, tn_temp);
                            tn_parent.Nodes.Remove(tn_curr);
                        }
                    }

                    if (al_new_selected_nodes.Contains(tn_temp) == false)
                    {
                        tn_temp.ForeColor = Color.Black;
                        tn_temp.BackColor = Color.White;

                        al_new_selected_nodes.Add(tn_temp);
                    }
                }

                if (al_new_selected_nodes.Count > 0)
                {
                    tvAttachMember.SelectedNode = null;
                    tvAttachMember.SelectedNodes = al_new_selected_nodes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAttachCollapse_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAttachMember.Nodes)
            {
                if (node.GetNodeCount(false) > 0)
                {
                    node.Collapse(false);
                }
            }

            if (tvAttachMember.Nodes.Count > 0)
            {
                tvAttachMember.Nodes[0].Expand();
                tvAttachMember.Nodes[0].EnsureVisible();
            }
        }

        private void btnAttachExpand_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAttachMember.Nodes)
            {
                if (node.GetNodeCount(false) > 0)
                {
                    node.ExpandAll();
                }
            }

            if (tvAttachMember.Nodes.Count > 0)
            {
                tvAttachMember.Nodes[0].EnsureVisible();
            }
        }

        private void btnMemberCollapse_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvMember.Nodes)
            {
                if (node.GetNodeCount(false) > 0)
                {
                    node.Collapse(false);
                }
            }

            if (tvMember.Nodes.Count > 0)
            {
                tvMember.Nodes[0].Expand();
                tvMember.Nodes[0].EnsureVisible();
            }
        }

        private void btnMemberExpand_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvMember.Nodes)
            {
                if (node.GetNodeCount(false) > 0)
                {
                    node.ExpandAll();
                }
            }

            if (tvMember.Nodes.Count > 0)
            {
                tvMember.Nodes[0].EnsureVisible();
            }
        }

        private void cdvUserID_ButtonPress(object sender, EventArgs e)
        {
            cdvUserID.Init();
            MPCF.InitListView(cdvUserID.GetListView);
            cdvUserID.Columns.Add("UserID", 100, HorizontalAlignment.Left);
            cdvUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUserID.SelectedSubItemIndex = 0;

            SECLIST.ViewSECUserList(cdvUserID.GetListView);
        }

        private void cdvDspID_ButtonPress(object sender, EventArgs e)
        {
            cdvDspID.Init();
            MPCF.InitListView(cdvDspID.GetListView);
            cdvDspID.Columns.Add("UserID", 100, HorizontalAlignment.Left);
            cdvDspID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvDspID.SelectedSubItemIndex = 0;
            RTDLIST.ViewDispatcherList(cdvDspID.GetListView, '1', null, "");
        }

        private void cdvService_TextBoxTextChanged(object sender, EventArgs e)
        {
            MPCF.InitTreeView(tvAttachMember);
            MPCF.InitTreeView(tvMember);
        }

        private void cdvUserID_TextBoxTextChanged(object sender, EventArgs e)
        {
            ViewFlexibleHeaderList();
        }

        private void cdvDspID_TextBoxTextChanged(object sender, EventArgs e)
        {
            ViewFlexibleHeaderList();
        }
       
        private void cdvModule_ButtonPress(object sender, EventArgs e)
        {
            cdvModule.Init();
            MPCF.InitListView(cdvModule.GetListView);
            cdvModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvModule.SelectedSubItemIndex = 0;

            TRSNode in_node = new TRSNode("View_Module_List_In");
            TRSNode out_node = new TRSNode("View_Module_List_Out");
            ListViewItem viewItem;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCR.CallService("SVM", "SVM_View_Module_List", in_node, ref out_node) == false)
            {
                return;
            }

            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {
                viewItem = cdvModule.GetListView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("MODULE_NAME"),
                                                               (int)SMALLICON_INDEX.IDX_MODULE));
            }
        }

        private void grpAttachFunc_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(grpAttachFunc, pnlFuncLeft, pnlFuncRight, pnlAttachFuncMid, 40);
            btnMemberCollapse.Location = new System.Drawing.Point(pnlFuncRight.Location.X + 3, btnMemberCollapse.Location.Y);
            btnMemberExpand.Location = new System.Drawing.Point(btnMemberCollapse.Location.X + 32, btnMemberExpand.Location.Y); 
        }
        
        private void cdvService_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnDelete.PerformClick();
            }
        }



    }
}

