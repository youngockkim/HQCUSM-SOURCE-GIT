//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : clsListRoutineWEM.cs
//   Description : Client Common List function WEM Module
//
//   MES Version : 5.3.0
//
//   Function List
//        - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-11-19 : Created by Aiden
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MsgHandler;

namespace Miracom.MESCore
{
    public sealed class WEMLIST
    {
        // ViewWorkProcessTypeList()
        //       - View work process type list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - Control control                  : control
        //       - char c_step                      : '1' - view all process type list
        //       - int i_image_idx                  : listview image index
        //       - TreeNode parentNode              : treeview parent node
        //       - string s_ext_factory             : view other factory data
        //       - bool b_ignore_error              : ignore error
        //
        public static bool ViewWorkProcessTypeList(Control control)
        {
            return ViewWorkProcessTypeList(control, '1', -1, null, "", false);
        }
        public static bool ViewWorkProcessTypeList(Control control, char c_step, int i_image_idx, TreeNode parentNode, string s_ext_factory, bool b_ignore_error)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_WORK_PROCESS_TYPE_LIST_IN");
            TRSNode out_node;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            if (i_image_idx == -1)
            {
                i_image_idx = (int)SMALLICON_INDEX.IDX_VERSION;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[i_image_idx] == null)
                {
                    MPCF.ShowMsgBox("Invalid Image Index");
                    return false;
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (s_ext_factory != "")
            {
                in_node.Factory = s_ext_factory;
            }

            do
            {
                out_node = new TRSNode("VIEW_WORK_PROCESS_TYPE_LIST_OUT");

                if (MPCR.CallService("WEM", "WEM_View_Work_Process_Type_List", in_node, ref out_node, b_ignore_error) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_WORK_PROC_TYPE", out_node.GetString("NEXT_WORK_PROC_TYPE"));

            } while (out_node.GetString("NEXT_WORK_PROC_TYPE") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("WORK_PROC_TYPE"), i_image_idx);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("WORK_PROC_TYPE_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("WORK_PROC_TYPE") + " : " + out_node.GetList(0)[i].GetString("WORK_PROC_TYPE_DESC"), i_image_idx, i_image_idx);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("WORK_PROC_TYPE"));
                    }
                }
            }

            return true;
        }

        // ViewProcessStepList()
        //       - View work process step list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - Control control                  : control
        //       - char c_step                      : '1' - view all process type list
        //       - int i_image_idx                  : listview image index
        //       - TreeNode parentNode              : treeview parent node
        //       - string s_ext_factory             : view other factory data
        //       - bool b_ignore_error              : ignore error
        //
        public static bool ViewProcessStepList(Control control, string s_work_proc_type)
        {
            return ViewProcessStepList(control, '1', s_work_proc_type , "", - 1, null, "", false);
        }
        public static bool ViewProcessStepList(Control control, string s_work_proc_type, string s_proc_id)
        {
            return ViewProcessStepList(control, '1', s_work_proc_type, s_proc_id, -1, null, "", false);
        }
        public static bool ViewProcessStepList(Control control, char c_step, string s_work_proc_type, string s_proc_id, int i_image_idx, TreeNode parentNode, string s_ext_factory, bool b_ignore_error)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_WORK_PROCESS_STEP_LIST_IN");
            TRSNode out_node;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            if (i_image_idx == -1)
            {
                i_image_idx = (int)SMALLICON_INDEX.IDX_MODULE;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[i_image_idx] == null)
                {
                    MPCF.ShowMsgBox("Invalid Image Index");
                    return false;
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (s_ext_factory != "")
            {
                in_node.Factory = s_ext_factory;
            }

            in_node.AddString("WORK_PROC_TYPE", s_work_proc_type);
            in_node.AddString("PROC_ID", s_proc_id);

            do
            {
                out_node = new TRSNode("VIEW_WORK_PROCESS_STEP_LIST_OUT");

                if (MPCR.CallService("WEM", "WEM_View_Process_Step_List", in_node, ref out_node, b_ignore_error) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_STEP_ID", out_node.GetString("NEXT_STEP_ID"));

            } while (out_node.GetString("NEXT_STEP_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("STEP_ID"), i_image_idx);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("STEP_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("STEP_ID") + " : " + out_node.GetList(0)[i].GetString("STEP_DESC"), i_image_idx, i_image_idx);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("STEP_ID"));
                    }
                }
            }

            return true;
        }

        // ViewStepActionList()
        //       - View work process action list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - Control control                  : control
        //       - char c_step                      : '1' - view all process type list
        //       - int i_image_idx                  : listview image index
        //       - TreeNode parentNode              : treeview parent node
        //       - string s_ext_factory             : view other factory data
        //       - bool b_ignore_error              : ignore error
        //
        public static bool ViewStepActionList(Control control, string s_work_proc_type)
        {
            return ViewStepActionList(control, '1', s_work_proc_type, -1, null, "", false);
        }
        public static bool ViewStepActionList(Control control, char c_step, string s_work_proc_type, int i_image_idx, TreeNode parentNode, string s_ext_factory, bool b_ignore_error)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_WORK_PROCESS_ACTION_LIST_IN");
            TRSNode out_node;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            if (i_image_idx == -1)
            {
                i_image_idx = (int)SMALLICON_INDEX.IDX_VERSION_REQUEST;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[i_image_idx] == null)
                {
                    MPCF.ShowMsgBox("Invalid Image Index");
                    return false;
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (s_ext_factory != "")
            {
                in_node.Factory = s_ext_factory;
            }

            in_node.AddString("WORK_PROC_TYPE", s_work_proc_type);

            do
            {
                out_node = new TRSNode("VIEW_WORK_PROCESS_ACTION_LIST_OUT");

                if (MPCR.CallService("WEM", "WEM_View_Step_Action_List", in_node, ref out_node, b_ignore_error) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_ACTION_ID", out_node.GetString("NEXT_ACTION_ID"));

            } while (out_node.GetString("NEXT_ACTION_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("ACTION_ID"), i_image_idx);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ACTION_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("ACTION_ID") + " : " + out_node.GetList(0)[i].GetString("ACTION_DESC"), i_image_idx, i_image_idx);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("ACTION_ID"));
                    }
                }
            }

            return true;
        }

        // ViewWorkProcessList()
        //       - View work process list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - Control control                  : control
        //       - char c_step                      : '1' - view all process type list
        //       - int i_image_idx                  : listview image index
        //       - TreeNode parentNode              : treeview parent node
        //       - string s_ext_factory             : view other factory data
        //       - bool b_ignore_error              : ignore error
        //
        public static bool ViewWorkProcessList(Control control, string s_work_proc_type)
        {
            return ViewWorkProcessList(control, '1', s_work_proc_type, -1, null, "", false);
        }
        public static bool ViewWorkProcessList(Control control, char c_step, string s_work_proc_type, int i_image_idx, TreeNode parentNode, string s_ext_factory, bool b_ignore_error)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_WORK_PROCESS_LIST_IN");
            TRSNode out_node;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            if (i_image_idx == -1)
            {
                i_image_idx = (int)SMALLICON_INDEX.IDX_VERSION_REQUEST;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[i_image_idx] == null)
                {
                    MPCF.ShowMsgBox("Invalid Image Index");
                    return false;
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (s_ext_factory != "")
            {
                in_node.Factory = s_ext_factory;
            }

            in_node.AddString("WORK_PROC_TYPE", s_work_proc_type);

            do
            {
                out_node = new TRSNode("VIEW_WORK_PROCESS_LIST_OUT");

                if (MPCR.CallService("WEM", "WEM_View_Work_Process_List", in_node, ref out_node, b_ignore_error) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_PROC_ID", out_node.GetString("NEXT_PROC_ID"));

            } while (out_node.GetString("NEXT_PROC_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("PROC_ID"), i_image_idx);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("PROC_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("PROC_ID") + " : " + out_node.GetList(0)[i].GetString("PROC_DESC"), i_image_idx, i_image_idx);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("PROC_ID"));
                    }
                }
            }

            return true;
        }

        // ViewWorkProcessEventList()
        //       - View work process event list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - Control control                  : control
        //       - char c_step                      : '1' - view all process type list
        //       - int i_image_idx                  : listview image index
        //       - TreeNode parentNode              : treeview parent node
        //       - string s_ext_factory             : view other factory data
        //       - bool b_ignore_error              : ignore error
        //
        public static bool ViewWorkProcessEventList(Control control, string s_work_proc_type, string s_proc_id)
        {
            return ViewWorkProcessEventList(control, '2', s_work_proc_type, s_proc_id , - 1, null, "", false);
        }
        public static bool ViewWorkProcessEventList(Control control, char c_step, string s_work_proc_type, string s_proc_id, int i_image_idx, TreeNode parentNode, string s_ext_factory, bool b_ignore_error)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_EVENT_LIST_IN");
            TRSNode out_node;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            if (i_image_idx == -1)
            {
                i_image_idx = (int)SMALLICON_INDEX.IDX_CODE_DATA;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[i_image_idx] == null)
                {
                    MPCF.ShowMsgBox("Invalid Image Index");
                    return false;
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (s_ext_factory != "")
            {
                in_node.Factory = s_ext_factory;
            }

            in_node.AddString("WORK_PROC_TYPE", s_work_proc_type);
            in_node.AddString("PROC_ID", s_proc_id);

            do
            {
                out_node = new TRSNode("VIEW_WORK_PROC_EVENT_LIST_OUT");

                if (MPCR.CallService("WEM", "WEM_View_Event_List", in_node, ref out_node, b_ignore_error) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_PROC_EVENT_ID", out_node.GetString("NEXT_PROC_EVENT_ID"));

            } while (out_node.GetString("NEXT_PROC_EVENT_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("PROC_EVENT_ID"), i_image_idx);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("PROC_EVENT_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("PROC_EVENT_ID") + " : " + out_node.GetList(0)[i].GetString("PROC_EVENT_DESC"), i_image_idx, i_image_idx);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("PROC_EVENT_ID"));
                    }
                }
            }

            return true;
        }

    }
}
