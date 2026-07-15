
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modSECListRoutine.vb
//   Description : Client Common List function SEC Module
//
//   MES Version : 4.1.0.0
//
//   Function List
//        -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-09 : Created by HK, Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using Miracom.MsgHandler;
using System.Data;
using Miracom.CliFrx;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Drawing;
using Miracom.UI.Controls.MCCodeView;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public sealed class SECLIST
    {
        
        // ViewSECUserList()
        //       - View User List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal iImage_idx As Integer = -1    : List View???§Ïñ¥Í∞??ÑÏù¥ÏΩ??∏Îç±??
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text

        public static bool ViewSECUserList(Control control)
        {
            return ViewSECUserList(control, '1', -1, null, "", "");
        }
        public static bool ViewSECUserList(Control control, char c_step, int iImage_idx, TreeNode parentNode, string sExt_Factory, string sUserGroup)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_USER_LIST_IN");
            TRSNode out_node;
            
            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }
            
            if (iImage_idx == - 1)
            {
                iImage_idx =  (int)SMALLICON_INDEX.IDX_USER;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[iImage_idx] == null)
                {
                    MPCF.ShowMsgBox("Invalid Image Index");
                    return false;
                }
            }
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }

            in_node.AddString("USER_GROUP", sUserGroup);

            do
            {
                out_node = new TRSNode("VIEW_USER_LIST_OUT");

                if (MPCR.CallService("SEC", "SEC_View_User_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_USER_ID", out_node.GetString("NEXT_USER_ID"), true);
            } while (out_node.GetString("NEXT_USER_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("USER_ID"), (int)SMALLICON_INDEX.IDX_USER);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("USER_DESC"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SEC_GRP_ID"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("EMAIL_ID"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("USER_ID") + " : " + out_node.GetList(0)[i].GetString("USER_DESC"), (int)SMALLICON_INDEX.IDX_USER, (int)SMALLICON_INDEX.IDX_USER);
                        if (!(parentNode == null))
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            ((TreeView)control).Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("USER_ID"));
                    }
                }
            }

            return true;
            
        }
        
        // ViewFunctionList()
        //       - View Function List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - Optional ByVal sSecGrp As String=""       : Function???¨Ìï®?òÏñ¥ ?àÎäî SecurityGroupID
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewFunctionList(Control control, string s_program_id, string s_sec_grp_id)
        {
            return ViewFunctionList(control, '1', s_program_id, s_sec_grp_id, "", ' ', null, "", false);
        }
        public static bool ViewFunctionList(Control control, string s_program_id, string s_sec_grp_id, string s_func_group)
        {
            return ViewFunctionList(control, '1', s_program_id, s_sec_grp_id, s_func_group, ' ', null, "", false);
        }
        public static bool ViewFunctionList(Control control, string s_program_id, string s_sec_grp_id, TreeNode parentNode, bool b_use_attach_function_tree)
        {
            return ViewFunctionList(control, '1', s_program_id, s_sec_grp_id, "", ' ', parentNode, "", b_use_attach_function_tree);
        }
        public static bool ViewFunctionList(Control control, char c_step, string s_program_id, string s_sec_grp_id, string s_func_group, char c_func_type, TreeNode parentNode, string s_ext_factory, bool b_use_attach_function_tree)
        {
            return ViewFunctionList(control, '1', s_program_id, s_sec_grp_id, s_func_group, c_func_type, parentNode, s_ext_factory, b_use_attach_function_tree, true);
        }

        public static bool ViewFunctionList(Control control, char c_step, string s_program_id, string s_sec_grp_id, string s_func_group, char c_func_type, TreeNode parentNode, string s_ext_factory, bool b_use_attach_function_tree, bool b_use_default_display)
        {
            ListViewItem itmX;
            TreeNode nodeX;
            int i;

            TRSNode in_node = new TRSNode("VIEW_FUNCTION_LIST_IN");
            TRSNode out_node;

            ArrayList func_list = new ArrayList();
            ArrayList a_list = new ArrayList();
            
            if (control is ListView)
            {
                if (((ListView) control).MultiSelect == true)
                {
                    MPCF.InitListView((ListView)control);
                    ((ListView) control).MultiSelect = true;
                }
                else
                {
                    MPCF.InitListView((ListView)control);
                }
            }
            else if (!(control is TreeView))
            {
                if (!(parentNode == null))
                {
                    parentNode.Nodes.Clear();
                }
                else
                {
                    MPCF.ClearList(control, true);
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (s_ext_factory != "")
            {
                in_node.Factory = s_ext_factory;
            }

            in_node.AddString("PROGRAM_ID", s_program_id);
            in_node.AddString("SEC_GRP_ID", s_sec_grp_id);
            in_node.AddString("FUNC_GROUP", s_func_group);
            in_node.AddChar("FUNC_TYPE_FLAG", c_func_type);
            in_node.AddString("NEXT_FUNC_NAME", "");
            
            do
            {
                out_node = new TRSNode("VIEW_FUNCTION_LIST_OUT");

                if (MPCR.CallService("SEC", "SEC_View_Function_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_FUNC_NAME", out_node.GetString("NEXT_FUNC_NAME"));
            } while (in_node.GetString("NEXT_FUNC_NAME") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                if (MPCF.Trim(s_sec_grp_id) != "" && control is TreeView && out_node.GetList(0).Count > 0)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        func_list.Add(out_node.GetList(0)[i]);
                    }
                }
                else
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (control is ListView)
                        {
                            if (b_use_default_display == true)
                            {
                                itmX = new ListViewItem(out_node.GetList(0)[i].GetString("FUNC_NAME"), (int)SMALLICON_INDEX.IDX_FUNCTION);
    
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FUNC_DESC"));
                                }
                            }
                            else
                            {
                                itmX = new ListViewItem(out_node.GetList(0)[i].GetString("FUNC_DESC"), (int)SMALLICON_INDEX.IDX_FUNCTION);

                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FUNC_NAME"));
                                }        

                            }
                            itmX.Tag = out_node.GetList(0)[i].GetChar("ADD_TOOL_BAR") == 'Y' ? "Y" : "N";
                            itmX.Tag += out_node.GetList(0)[i].GetString("SHORT_CUT");
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("FUNC_NAME") + " : " + out_node.GetList(0)[i].GetString("FUNC_DESC"), 
                                (int)SMALLICON_INDEX.IDX_FUNCTION, (int)SMALLICON_INDEX.IDX_FUNCTION);

                            if (parentNode != null)
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)control).Nodes.Add(nodeX);
                            }
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("FUNC_NAME"));
                        }
                    }
                }
            }

            if (MPCF.Trim(s_sec_grp_id) != "" && control is TreeView)
            {
                if (parentNode == null)
                {
                    nodeX = new TreeNode(in_node.Factory, (int)SMALLICON_INDEX.IDX_FACTORY, (int)SMALLICON_INDEX.IDX_FACTORY);
                    ((TreeView)control).Nodes.Add(nodeX);

                    parentNode = nodeX;
                }

                i = 0;
                ViewFunctionTreeViewList(parentNode, "1", func_list, ref i, b_use_attach_function_tree);
                parentNode.ExpandAll();
                parentNode.EnsureVisible();
            }


            return true;
        }


        private static void ViewFunctionTreeViewList(TreeNode node, string s_parent_level, ArrayList func_list, ref int i, bool b_use_attach_function_tree)
        {
            string[] s_p_level;
            string[] s_c_level;
            TreeNode nodeX;
            MenuInfoTag m_menu;
            TRSNode func_item;

            try
            {
                nodeX = null;
                s_p_level = s_parent_level.Split('.');

                if (func_list != null)
                {
                    while (i < func_list.Count)
                    {
                        func_item = (TRSNode)func_list[i];

                        s_c_level = func_item.GetString("DISP_LEVEL").Split('.');

                        if (s_p_level.Length > s_c_level.Length)
                        {
                            if (b_use_attach_function_tree == true)
                            {
                                nodeX = new TreeNode("Attach New Menu...", (int)SMALLICON_INDEX.IDX_VERSION_REQUEST, (int)SMALLICON_INDEX.IDX_VERSION_REQUEST);
                                nodeX.ForeColor = Color.Silver;
                                node.Nodes.Add(nodeX);
                            }

                            return;
                        }
                        else if (nodeX != null && s_p_level.Length < s_c_level.Length)
                        {
                            ViewFunctionTreeViewList(nodeX, func_item.GetString("DISP_LEVEL"), func_list, ref i, b_use_attach_function_tree);
                        }
                        else
                        {
                            if (b_use_attach_function_tree == true)
                            {
                                if (func_item.GetChar("SEPARATOR") == 'Y')
                                {
                                    nodeX = new TreeNode("--------------------", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                                    nodeX.ForeColor = Color.Silver;
                                    node.Nodes.Add(nodeX);
                                }
                                nodeX = new TreeNode(func_item.GetString("FUNC_NAME") + " : " + func_item.GetString("FUNC_DESC"), (int)SMALLICON_INDEX.IDX_FUNCTION, (int)SMALLICON_INDEX.IDX_FUNCTION);
                                nodeX.Tag = func_item.GetChar("ADD_TOOL_BAR") == 'Y' ? "Y" : "N";
                                nodeX.Tag += func_item.GetString("SHORT_CUT");
                            }
                            else
                            {
                                nodeX = new TreeNode(func_item.GetString("FUNC_DESC"), (int)SMALLICON_INDEX.IDX_FUNCTION, (int)SMALLICON_INDEX.IDX_FUNCTION);

                                m_menu.s_func_name = func_item.GetString("FUNC_NAME");
                                m_menu.s_assembly_file = func_item.GetString("ASSEMBLY_FILE");
                                
                                int args_start_p = func_item.GetString("ASSEMBLY_NAME").IndexOf(' ');
                                if (args_start_p > 0)
                                {
                                    m_menu.s_assembly_name = func_item.GetString("ASSEMBLY_NAME").Substring(0, args_start_p);
                                    //Modify by J.S. 2015.05.14 Fix mis range of substring
                                    m_menu.s_args = func_item.GetString("ASSEMBLY_NAME").Substring(args_start_p + 1, func_item.GetString("ASSEMBLY_NAME").Length - args_start_p - 1);
                                }
                                else
                                {
                                    m_menu.s_assembly_name = func_item.GetString("ASSEMBLY_NAME");
                                    m_menu.s_args = null;
                                }
                                m_menu.c_func_type = func_item.GetChar("FUNC_TYPE_FLAG");

                                nodeX.Tag = m_menu;
                            }

                            node.Nodes.Add(nodeX);

                            i++;
                        }
                    }
                }

                if (b_use_attach_function_tree == true)
                {
                    nodeX = new TreeNode("Attach New Menu...", (int)SMALLICON_INDEX.IDX_VERSION_REQUEST, (int)SMALLICON_INDEX.IDX_VERSION_REQUEST);
                    nodeX.ForeColor = Color.Silver;
                    node.Nodes.Add(nodeX);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ViewFunctionTreeViewList()\n" + e.Message);
            }
        }

        // ViewSecGroupList()
        //       - View Function List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewSecGroupList(Control control)
        {
            return ViewSecGroupList(control, '1', null, "");
        }
        public static bool ViewSecGroupList(Control control, char c_step, TreeNode parentNode, string sExt_Factory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();
            
            TRSNode in_node = new TRSNode("VIEW_SECGRP_LIST_IN");
            TRSNode out_node;
            
            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }

            do
            {
                out_node = new TRSNode("VIEW_SECGRP_LIST_OUT");

                if (MPCR.CallService("SEC", "SEC_View_SecGrp_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_SEC_GRP_ID", out_node.GetString("NEXT_SEC_GRP_ID"));
            } while (in_node.GetString("NEXT_SEC_GRP_ID") != "");


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("SEC_GRP_ID"), (int)SMALLICON_INDEX.IDX_SEC_GROUP);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SEC_GRP_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("SEC_GRP_ID") + " : " + out_node.GetList(0)[i].GetString("SEC_GRP_DESC"), 
                            (int)SMALLICON_INDEX.IDX_SEC_GROUP, (int)SMALLICON_INDEX.IDX_SEC_GROUP);

                        if (!(parentNode == null))
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            ((TreeView)control).Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("SEC_GRP_ID"));

                    }
                }
            }
                
            return true;
            
        }
        
        // ViewFavoritesList()
        //       - ViewFavoritesList
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewFavoritesList(Control control, char c_step, string s_program_id, TreeNode parentNode, string sExt_Factory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            MenuInfoTag m_menu_tag;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_FAVORITES_LIST_IN");
            TRSNode out_node;
            
            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }

            in_node.AddString("PROGRAM_ID", s_program_id);
            in_node.AddInt("NEXT_FUNC_SEQ", 0);

            do
            {
                out_node = new TRSNode("VIEW_FAVORITES_LIST_IN");

                if (MPCR.CallService("SEC", "SEC_View_Favorites_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetInt("NEXT_FUNC_SEQ", out_node.GetInt("NEXT_FUNC_SEQ"));
            } while (in_node.GetInt("NEXT_FUNC_SEQ") > 0);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        if (MPCF.Trim(((ListView)control).Columns[0].Tag) == "SEQ")
                        {
                            itmX = new ListViewItem(MPCF.Trim(i + 1), (int)SMALLICON_INDEX.IDX_FUNCTION);
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FUNC_NAME"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("USER_FUNC_DESC"));
                        }
                        else
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("FUNC_NAME"), (int)SMALLICON_INDEX.IDX_FUNCTION);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("USER_FUNC_DESC"));
                            }
                        }

                        m_menu_tag.s_func_name = out_node.GetList(0)[i].GetString("FUNC_NAME");
                        m_menu_tag.s_assembly_file = out_node.GetList(0)[i].GetString("ASSEMBLY_FILE");
                        int args_start_p = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").IndexOf(' ');
                        if (args_start_p > 0)
                        {
                            m_menu_tag.s_assembly_name = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Substring(0, args_start_p);
                            m_menu_tag.s_args = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Substring(args_start_p + 1, out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Length - args_start_p - 1);
                        }
                        else
                        {
                            m_menu_tag.s_assembly_name = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME");
                            m_menu_tag.s_args = null;
                        }
                        m_menu_tag.c_func_type = out_node.GetList(0)[i].GetChar("FUNC_TYPE_FLAG");

                        itmX.Tag = m_menu_tag;

                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("FUNC_NAME") + " : " + out_node.GetList(0)[i].GetString("USER_FUNC_DESC"), 
                            (int)SMALLICON_INDEX.IDX_FUNCTION, (int)SMALLICON_INDEX.IDX_FUNCTION);

                        m_menu_tag.s_func_name = out_node.GetList(0)[i].GetString("FUNC_NAME");
                        m_menu_tag.s_assembly_file = out_node.GetList(0)[i].GetString("ASSEMBLY_FILE");
                        int args_start_p = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").IndexOf(' ');
                        if (args_start_p > 0)
                        {
                            m_menu_tag.s_assembly_name = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Substring(0, args_start_p);
                            m_menu_tag.s_args = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Substring(args_start_p + 1, out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Length - args_start_p - 1);
                        }
                        else
                        {
                            m_menu_tag.s_assembly_name = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME");
                            m_menu_tag.s_args = null;
                        }
                        m_menu_tag.c_func_type = out_node.GetList(0)[i].GetChar("FUNC_TYPE_FLAG");

                        nodeX.Tag = m_menu_tag;

                        if (!(parentNode == null))
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            ((TreeView)control).Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("FUNC_NAME"));
                    }
                }
            }

            return true;

            
        }
        
        // ViewPrvGroupList()
        //       - View Privilege Group List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewPrvGroupList(Control control)
        {
            return ViewPrvGroupList(control, '1', null, "");
        }
        public static bool ViewPrvGroupList(Control control, char c_step, TreeNode parentNode, string sExt_Factory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_PRIVILEGE_GROUP_LIST_IN");
            TRSNode out_node;
            
            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }

            do
            {
                out_node = new TRSNode("VIEW_PRIVILEGE_GROUP_LIST_OUT");

                if (MPCR.CallService("SEC", "SEC_View_Privilege_Group_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_PRV_GRP_ID", out_node.GetString("NEXT_PRV_GRP_ID"));
            } while (in_node.GetString("NEXT_PRV_GRP_ID") != "");
            
            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("PRV_GRP_ID"), (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("PRV_GRP_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("PRV_GRP_ID") + " : " + out_node.GetList(0)[i].GetString("PRV_GRP_DESC"), (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP, (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP);
                        if (!(parentNode == null))
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            ((TreeView)control).Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("PRV_GRP_ID"));
                    }
                }

            }
            
            return true;
            
        }
        
        // ViewPrvGrpUserList()
        //       - View Privilege Group - User Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sKey As String                        : Key Í∞?(step='1' ?ºÍ≤Ω??Prv_Grp_ID, step='2' ??Í≤ΩÏö∞ User_ID)
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewPrvGrpUserList(Control control, char c_step, string sKey, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_PRIVILEGE_GROUP_USER_LIST_IN");
            TRSNode out_node;
            
            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                if (control is TreeView)
                {
                    MPCF.ClearList(control, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                if (sExtFactory != "")
                {
                    in_node.Factory = sExtFactory;
                }

                if (c_step == '1')
                {
                    in_node.AddString("NEXT_PRV_GRP_ID", sKey);
                }
                else if (c_step == '2')
                {
                    in_node.AddString("NEXT_USER_ID", sKey, true);
                }

                do
                {
                    out_node = new TRSNode("VIEW_PRIVILEGE_GROUP_USER_LIST_OUT");

                    if (MPCR.CallService("SEC", "SEC_View_Privilege_Group_User_List", in_node, ref out_node) == false)
                    {                     
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_USER_ID", out_node.GetString("NEXT_USER_ID"), true);
                    in_node.SetString("NEXT_PRV_GRP_ID", out_node.GetString("NEXT_PRV_GRP_ID"));

                } while (in_node.GetString("NEXT_USER_ID") != "" || in_node.GetString("NEXT_PRV_GRP_ID") != "");

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            if (c_step == '1')
                            {
                                itmX = ((ListView)control).Items.Add(out_node.GetList(0)[i].GetString("USER_ID"), (int)SMALLICON_INDEX.IDX_USER);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("USER_DESC"));
                                }
                            }
                            else if (c_step == '2')
                            {
                                itmX = ((ListView)control).Items.Add(out_node.GetList(0)[i].GetString("PRV_GRP_ID"), (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("PRV_GRP_DESC"));
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        // ViewPrivilegeList()
        //       - View Privilege List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sKey As String                        : Key Í∞?(Prv_type)
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //

        public static bool ViewPrivilegeList(Control control, char c_step, string s_prv_type, string sExtFactory)
        {
            return ViewPrivilegeList(control, c_step, s_prv_type, "", sExtFactory);
        }
        public static bool ViewPrivilegeList(Control control, char c_step, string s_prv_type, string s_prv_group, string sExtFactory)
        {
            TRSNode in_node = new TRSNode("VIEW_PRIVILEGE_LIST_IN");
            TRSNode out_node;
            ArrayList a_list = new ArrayList();
            
            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                    if (((ListView) control).Columns.Count > 3)
                    {
                        ((ListView) control).Columns[1].Width = 0;
                        ((ListView) control).Columns[2].Width = 0;
                    }
                }
                if (control is TreeView)
                {
                    MPCF.ClearList(control, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                if (sExtFactory != "")
                {
                    in_node.Factory = sExtFactory;
                }

                in_node.AddString("NEXT_PRV_GRP_ID", s_prv_group);
                in_node.AddString("NEXT_PRV_TYPE", s_prv_type);

                do
                {
                    out_node = new TRSNode("VIEW_PRIVILEGE_LIST_OUT");

                    if (MPCR.CallService("SEC", "SEC_View_Privilege_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_PRV_GRP_ID", out_node.GetString("NEXT_PRV_GRP_ID"));
                    in_node.SetString("NEXT_PRV_TYPE", out_node.GetString("NEXT_PRV_TYPE"));
                    in_node.SetString("NEXT_PRV_ITEM1", out_node.GetString("NEXT_PRV_ITEM1"));
                    in_node.SetString("NEXT_PRV_ITEM2", out_node.GetString("NEXT_PRV_ITEM2"));
                    in_node.SetString("NEXT_PRV_ITEM3", out_node.GetString("NEXT_PRV_ITEM3"));

                } while (in_node.GetString("NEXT_PRV_TYPE") != "" || in_node.GetString("NEXT_PRV_ITEM1") != "" || in_node.GetString("NEXT_PRV_GRP_ID") != "");


                ListViewItem itmX;
                bool bEnable_Item2;
                bool bEnable_Item3;
                List<TRSNode> prv_list;
                int i;
                string sPrvType;
                string sPrvItem;
                int iIconIndex;

                itmX = null;
                bEnable_Item2 = false;
                bEnable_Item3 = false;
                
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    prv_list = out_node.GetList("LIST");
                    for (i = 0; i < prv_list.Count; i++)
                    {
                        sPrvType = prv_list[i].GetString("PRV_TYPE");
                        switch (sPrvType)
                        {
                            case MPGC.MP_PRV_TYPE_OPER:
                                sPrvItem = prv_list[i].GetString("PRV_ITEM1");
                                iIconIndex = (int)SMALLICON_INDEX.IDX_OPER;
                                break;
                            case MPGC.MP_PRV_TYPE_RES:
                                sPrvItem = prv_list[i].GetString("PRV_ITEM1");
                                iIconIndex = (int)SMALLICON_INDEX.IDX_RESOURCE;
                                break;
                            case MPGC.MP_PRV_TYPE_GCMTBL:
                                sPrvItem = prv_list[i].GetString("PRV_ITEM1");
                                iIconIndex = (int)SMALLICON_INDEX.IDX_CODE_TABLE;
                                break;
                            case MPGC.MP_PRV_TYPE_SERVICE:
                                sPrvItem = prv_list[i].GetString("PRV_ITEM1");
                                iIconIndex = (int)SMALLICON_INDEX.IDX_PRIVILEGE_SERVICE;
                                break;
                            case MPGC.MP_PRV_TYPE_ATTR:
                                sPrvItem = prv_list[i].GetString("PRV_ITEM2") + " : " + prv_list[i].GetString("PRV_ITEM1");
                                iIconIndex = (int)SMALLICON_INDEX.IDX_KEY;
                                break;
                            default:
                                sPrvItem = prv_list[i].GetString("PRV_ITEM1");
                                iIconIndex = (int)SMALLICON_INDEX.IDX_PRIVILEGE;
                                break;
                        }

                        if (control is ListView)
                        {
                            if (MPCF.FindListItemIndex((ListView)control, sPrvItem, false) < 0)
                            {
                                itmX = ((ListView)control).Items.Add(sPrvItem, iIconIndex);

                                if (((ListView)control).Columns.Count == 2)
                                {
                                    itmX.SubItems.Add(prv_list[i].GetString("PRV_ITEM_DESC"));
                                }
                                else if (((ListView)control).Columns.Count > 4)
                                {
                                    if (bEnable_Item2 == false && prv_list[i].GetString("PRV_ITEM2") != "")
                                    {
                                        bEnable_Item2 = true;
                                    }
                                    if (bEnable_Item3 == false && prv_list[i].GetString("PRV_ITEM3") != "")
                                    {
                                        bEnable_Item3 = true;
                                    }

                                    itmX.SubItems.Add(prv_list[i].GetString("PRV_ITEM2"));
                                    itmX.SubItems.Add(prv_list[i].GetString("PRV_ITEM3"));
                                    itmX.SubItems.Add(prv_list[i].GetString("PRV_TYPE"));
                                    itmX.SubItems.Add(prv_list[i].GetString("PRV_ITEM_DESC"));
                                }
                            }
                        }
                    }
                }

                if (((ListView) control).Columns.Count > 4)
                {
                    if (bEnable_Item2 == true)
                    {
                        ((ListView) control).Columns[1].Width = 150;
                    }
                    if (bEnable_Item3 == true)
                    {
                        ((ListView) control).Columns[2].Width = 150;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;            
        }

        // ViewPrivilegeList()
        //       - View Privilege List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sKey As String                        : Key Í∞?(Prv_type)
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //

        public static bool ViewPrivilegeAssignGrpList(Control control, char c_step, string s_prv_type, string s_item, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            itmX = null;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_GROUP_BY_TYPE_PRIVILEGE_LIST_IN");
            TRSNode out_node;

            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                    if (((ListView)control).Columns.Count > 3)
                    {
                        ((ListView)control).Columns[1].Width = 0;
                        ((ListView)control).Columns[2].Width = 0;
                    }
                }
                if (control is TreeView)
                {
                    MPCF.ClearList(control, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                if (sExtFactory != "")
                {
                    in_node.Factory = sExtFactory;
                }

                in_node.AddString("NEXT_PRV_TYPE", s_prv_type);
                in_node.AddString("NEXT_PRV_ITEM1", s_item);

                if (s_prv_type == MPGC.MP_PRV_TYPE_ATTR)
                {
                    string[] s_temp = s_item.Split(':');

                    if (s_temp.Length > 1)
                    {
                        in_node.SetString("NEXT_PRV_ITEM2", s_temp[0].Trim());
                        in_node.SetString("NEXT_PRV_ITEM1", s_temp[1].Trim());
                    }
                }

                do
                {
                    out_node = new TRSNode("VIEW_GROUP_BY_TYPE_PRIVILEGE_LIST_OUT");

                    if (MPCR.CallService("SEC", "SEC_View_Group_By_Type_Privilege_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_PRV_GRP_ID", out_node.GetString("NEXT_RPV_GRP_ID"));

                } while (in_node.GetString("NEXT_PRV_GRP_ID") != "");


                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = ((ListView)control).Items.Add(out_node.GetList(0)[i].GetString("PRV_GRP_ID"), (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP);

                            if (((ListView)control).Columns.Count == 2)
                            {
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("PRV_GRP_DESC"));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
        
    }
    
}
