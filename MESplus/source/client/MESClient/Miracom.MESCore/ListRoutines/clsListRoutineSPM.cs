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

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modSPMListRoutine.cs
//   Description : Client Common List function SPM Module
//
//   MES Version : 5.2.0.0
//
//   Function List
//        -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-04-18 : Created by JYPARK
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.MESCore
{
    public sealed class SPMLIST
    {
        /// <summary>
        /// ViewSpecListByMFO
        ///   - View Spec List by M-F-O Relation
        /// </summary>
        /// <param name="control">control object</param>
        /// <param name="c_step">Proc Step</param>
        /// <param name="s_mat_id">Material ID</param>
        /// <param name="i_mat_ver">Material Version</param>
        /// <param name="s_flow">Flow</param>
        /// <param name="s_oper">Operation</param>
        /// <param name="c_mfo_relation_level">M-F-O Relation Level</param>
        /// <param name="s_filter">Filter String</param>
        /// <param name="parentNode">Tree Node</param>
        /// <param name="s_ext_factory">Factory</param>
        /// <returns>True or False</returns>
        public static bool ViewSpecListByMFO(Control control, char c_step, string s_mat_id, int i_mat_ver,
                                             string s_flow, string s_oper, char c_mfo_relation_level,
                                             string s_filter, TreeNode parentNode, string s_ext_factory)
        {
            int i;
            int j;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_SPEC_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

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

            if (s_ext_factory != "")
            {
                in_node.Factory = s_ext_factory;
            }

            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);
            in_node.AddChar("REL_LEVEL", c_mfo_relation_level);

            in_node.AddString("NEXT_SPEC_REL_ID", "");

            do
            {
                out_node = new TRSNode("VIEW_SPEC_LIST_OUT");

                if (MPCR.CallService("SPM", "SPM_View_Spec_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);
                in_node.SetString("NEXT_SPEC_REL_ID", out_node.GetString("NEXT_SPEC_REL_ID"));
            } while (in_node.GetString("NEXT_SPEC_REL_ID") != "");

            for (j = 0; j < a_list.Count; j++)
            {
                out_node = null;
                out_node = (TRSNode)a_list[j];

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SPEC_REL_ID")), (int)SMALLICON_INDEX.IDX_CHARACTER);
                        //if (((ListView)control).Columns.Count > 1)
                        //{
                        //    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SPEC_REL_VER")));
                        //}
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        //nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("SPEC_REL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("SPEC_REL_VER")), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("SPEC_REL_ID")), (int)SMALLICON_INDEX.IDX_CHARACTER, (int)SMALLICON_INDEX.IDX_CHARACTER);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SPEC_REL_ID")));
                    }
                }
            }


            return true;
        }

        /// <summary>
        /// ViewSpecVersionList()
        ///     - View Spec Version List
        /// </summary>
        /// <param name="control">control object</param>
        /// <param name="c_step">Proc Step</param>
        /// <param name="SpecRelID">Spec Relation ID</param>
        /// <param name="iImage_idx">Icon Image Index</param>
        /// <param name="parentNode">Tree Node</param>
        /// <param name="s_ext_factory">Factory</param>
        /// <returns>True or False</returns>
        public static bool ViewSpecVersionList(Control control, char c_step, string SpecRelID, int iImage_idx, TreeNode parentNode, string sExt_Factory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_SPEC_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SPEC_VERSION_LIST_OUT"); ;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            if (iImage_idx == -1)
            {
                iImage_idx = (int)SMALLICON_INDEX.IDX_CHARACTER;
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

            in_node.AddString("SPEC_REL_ID", SpecRelID);

            if (c_step == '1')
            {
                in_node.AddInt("NEXT_SPEC_REL_VER", 0);
            }

            do
            {
                if (MPCR.CallService("SPM", "SPM_View_Spec_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("SPEC_REL_VER").ToString(), (int)SMALLICON_INDEX.IDX_VERSION);
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("SPEC_REL_VER").ToString(), (int)SMALLICON_INDEX.IDX_VERSION, (int)SMALLICON_INDEX.IDX_VERSION);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("SPEC_REL_VER").ToString());
                    }
                }

                in_node.SetInt("NEXT_SPEC_REL_VER", out_node.GetInt("NEXT_SPEC_REL_VER"));

            } while (in_node.GetInt("NEXT_SPEC_REL_VER") > 0);

            return true;

        }

        /// <summary>
        /// ViewSpecVersionListByMFO()
        ///     - View Spec Version List by MFO Relation
        /// </summary>
        /// <param name="control">control object</param>
        /// <param name="cRelLevel">Relation Level</param>
        /// <param name="sMatID">Material ID</param>
        /// <param name="iMatVer">Material Version</param>
        /// <param name="sFlow">Flow</param>
        /// <param name="sOper">Oper</param>
        /// <param name="parentNode">Tree Node</param>
        /// <param name="sExt_Factory">Factory</param>
        /// <returns>True or False</returns>
        /// 
        public static bool ViewSpecVersionListByMFO(Control control, string sMatID, int iMatVer, string sFlow, string sOper, TreeNode parentNode, string sExt_Factory, ref string s_spec_id)
        {
            char cRelLevel = ' ';
            if (MPCF.Trim(sMatID) != "" && MPCF.Trim(sFlow) != "" && MPCF.Trim(sOper) != "")
            {
                cRelLevel = '1'; // MFO
            }
            else if (MPCF.Trim(sMatID) != "" && MPCF.Trim(sFlow) == "" && MPCF.Trim(sOper) != "")
            {
                cRelLevel = '4';  // MO
            }
            else if (MPCF.Trim(sMatID) != "" && MPCF.Trim(sFlow) == "" && MPCF.Trim(sOper) == "")
            {
                cRelLevel = '6';  // M
            }
            else if (MPCF.Trim(sMatID) == "" && MPCF.Trim(sFlow) != "" && MPCF.Trim(sOper) != "")
            {
                cRelLevel = '2';  // FO
            }
            else if (MPCF.Trim(sMatID) == "" && MPCF.Trim(sFlow) != "" && MPCF.Trim(sOper) == "")
            {
                cRelLevel = '7';  // F
            }
            else if (MPCF.Trim(sMatID) == "" && MPCF.Trim(sFlow) == "" && MPCF.Trim(sOper) != "")
            {
                cRelLevel = '3';  // O
            }
            else
            {
                cRelLevel = ' ';  // Factory
            }
            return ViewSpecVersionListByMFO(control, cRelLevel, sMatID, iMatVer, sFlow, sOper, parentNode, sExt_Factory, ref s_spec_id);
        }
        public static bool ViewSpecVersionListByMFO(Control control, char cRelLevel, string sMatID, int iMatVer, string sFlow, string sOper, TreeNode parentNode, string sExt_Factory, ref string s_spec_id)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_SPEC_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SPEC_VERSION_LIST_OUT"); ;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }

            in_node.AddChar("REL_LEVEL", cRelLevel);
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("OPER", sOper);

            do
            {
                if (MPCR.CallService("SPM", "SPM_View_Spec_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (i == 0) s_spec_id = out_node.GetList(0)[i].GetString("SPEC_REL_ID");

                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("SPEC_REL_VER").ToString(), (int)SMALLICON_INDEX.IDX_VERSION);
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("SPEC_REL_VER").ToString(), (int)SMALLICON_INDEX.IDX_VERSION, (int)SMALLICON_INDEX.IDX_VERSION);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("SPEC_REL_VER").ToString());
                    }
                }

                in_node.SetInt("NEXT_SPEC_REL_VER", out_node.GetInt("NEXT_SPEC_REL_VER"));

            } while (in_node.GetInt("NEXT_SPEC_REL_VER") > 0);

            return true;

        }

        //
        // ViewSPMSpecCharacterList()
        //       - View Spec Character list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                      : List control
        //       - ByVal c_step As String                        : Process Step
        //       - Optional ByVal iImage_idx As Integer = -1     : List View Item Image Index
        //       - ByVal sSpecRelID As String = ""               : Spec Relation ID
        //       - ByVal sSpecRelVer As String = ""              : Spec Relation Version
        //       - Optional ByVal sTreeItem As TreeNode = null   : TreeView Node Item
        //       - ByVal bVisibleSeqCol As Boolean               : Visible Sequence Column
        //
        public static bool ViewSpecCharacterList(Control control, char c_step, string sSpecRelID, string sSpecRelVer, bool bVisibleSeqCol)
        {
            return ViewSpecCharacterList(control, c_step, -1, sSpecRelID, sSpecRelVer, null, bVisibleSeqCol);
        }
        public static bool ViewSpecCharacterList(Control control, char c_step, int iImage_idx, string sSpecRelID, string sSpecRelVer, TreeNode parentNode, bool bVisibleSeqCol)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            List<string> sList = new List<string>();
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("View_Spec_Character_List_In");
            TRSNode out_node;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            if (iImage_idx == -1)
            {
                iImage_idx = (int)SMALLICON_INDEX.IDX_CHARACTER;
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

            in_node.AddString("SPEC_REL_ID", sSpecRelID);
            in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(sSpecRelVer));
            in_node.AddString("NEXT_CHAR_ID", "");

            do
            {
                out_node = new TRSNode("View_Spec_Character_List_Out");

                if (MPCR.CallService("SPM", "SPM_View_Spec_Character_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_CHAR_ID", out_node.GetString("NEXT_CHAR_ID"));

            } while (in_node.GetString("NEXT_CHAR_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("CHAR_ID"), iImage_idx);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        }
                        if (((ListView)control).Columns.Count > 2)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("VALUE_TYPE")));
                        }
                        if (bVisibleSeqCol)
                        {
                            if (((ListView)control).Columns.Count > 3)
                            {
                                itmX.SubItems.Add(MPCF.Trim(i + 1));
                            }
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("CHAR_ID") + " : " + out_node.GetList(0)[i].GetString("CHAR_ID"), iImage_idx, iImage_idx);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("CHAR_ID"));
                    }
                }
            }

            return true;

        }

    }
}
