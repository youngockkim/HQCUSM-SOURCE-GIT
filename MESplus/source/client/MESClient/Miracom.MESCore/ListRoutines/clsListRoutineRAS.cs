
using Miracom.MsgHandler;
using System.Data;
using Miracom.CliFrx;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Drawing;
using Miracom.UI.Controls.MCCodeView;
using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modRASListRoutine.vb
//   Description : Client Common List function RAS Module
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

namespace Miracom.MESCore
{
    public sealed class RASLIST
    {

        /// <summary>
        /// Get Resource List
        /// </summary>
        /// <param name="control"></param>
        /// <param name="b_include_delete_resource"></param>
        /// <returns></returns>
        public static bool ViewResourceList(Control control, bool b_include_delete_resource)
        {
            return ViewResourceList(control, '1', "", "", "", "", "", 0, "", "", ' ', "", b_include_delete_resource, null, "");
        }
        public static bool ViewResourceList(Control control, bool b_include_delete_resource, bool b_sec_chk_flag)
        {
            return ViewResourceList(control, '1', "", "", "", "", "", 0, "", "", ' ', "", b_include_delete_resource, null, "", b_sec_chk_flag);
        }
        public static bool ViewResourceList(Control control, string s_resg_id, string s_res_type, bool b_include_delete_resource)
        {
            return ViewResourceList(control, '1', s_resg_id, s_res_type, "", "", "", 0, "", "", ' ', "", b_include_delete_resource, null, "");
        }
        public static bool ViewResourceList(Control control, string s_res_type, string s_area, string s_sub_area, bool b_include_delete_resource)
        {
            return ViewResourceList(control, '1', "", s_res_type, s_area, s_sub_area, "", 0, "", "", ' ', "", b_include_delete_resource, null, "");
        }
        public static bool ViewResourceList(Control control, string s_resg_id, string s_res_type, string s_area, string s_sub_area, bool b_include_delete_resource)
        {
            return ViewResourceList(control, '1', s_resg_id, s_res_type, s_area, s_sub_area, "", 0, "", "", ' ', "", b_include_delete_resource, null, "");
        }
        /// <summary>
        /// Get resource list at optimum MFO option
        /// </summary>
        /// <param name="control"></param>
        /// <param name="s_mat_id"></param>
        /// <param name="i_mat_ver"></param>
        /// <param name="s_flow"></param>
        /// <param name="s_oper"></param>
        /// <param name="b_include_delete_resource"></param>
        /// <param name="tv_node"></param>
        /// <returns></returns>
        /* 2013.06.12. Aiden. ±‚¥… √ﬂ∞° */
        public static bool ViewResourceList(Control control, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_resg_id, string s_res_type, bool b_include_delete_resource, TreeNode parentNode)
        {
            return ViewResourceList(control, '1', s_resg_id, s_res_type, "", "", s_mat_id, i_mat_ver, s_flow, s_oper, ' ', "", b_include_delete_resource, parentNode, "");
        }
        /// <summary>
        /// Get resource list at optimum MFO option
        /// </summary>
        /// <param name="control"></param>
        /// <param name="s_mat_id"></param>
        /// <param name="i_mat_ver"></param>
        /// <param name="s_flow"></param>
        /// <param name="s_oper"></param>
        /// <param name="b_include_delete_resource"></param>
        /// <returns></returns>
        public static bool ViewResourceList(Control control, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, bool b_include_delete_resource)
        {
            return ViewResourceList(control, '2', "", "", "", "", s_mat_id, i_mat_ver, s_flow, s_oper, ' ', "", b_include_delete_resource, null, "");
        }
        /// <summary>
        /// Get resource list
        /// </summary>
        /// <param name="control"></param>
        /// <param name="c_step">1 - Accord MFO option, 2 - Optimum MFO option</param>
        /// <param name="s_res_type"></param>
        /// <param name="s_mat_id"></param>
        /// <param name="i_mat_ver"></param>
        /// <param name="s_flow"></param>
        /// <param name="s_oper"></param>
        /// <param name="c_mfo_resource_relation_level">G - Resource Group, R - Resource</param>
        /// <param name="b_include_delete_resource"></param>
        /// <returns></returns>
        public static bool ViewResourceList(Control control, char c_step, string s_res_type, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, char c_mfo_resource_relation_level, bool b_include_delete_resource)
        {
            return ViewResourceList(control, c_step, "", s_res_type, "", "", s_mat_id, i_mat_ver, s_flow, s_oper, c_mfo_resource_relation_level, "", b_include_delete_resource, null, "");
        }
        public static bool ViewResourceList(
            Control control, 
            char c_step,
            string s_resg_id,
            string s_res_type, 
            string s_area, 
            string s_sub_area, 
            string s_mat_id,
            int i_mat_ver,
            string s_flow,
            string s_oper,
            char c_mfo_resource_relation_level,
            string s_filter, 
            bool b_include_delete_resource, 
            TreeNode parentNode, 
            string s_ext_factory)
        {
            return ViewResourceList(control, c_step, s_resg_id, s_res_type, s_area, s_sub_area, s_mat_id, i_mat_ver, s_flow, s_oper, c_mfo_resource_relation_level, s_filter, b_include_delete_resource, parentNode, s_ext_factory, false);
        }
        /// <summary>
        /// Get resource list at optimum MFO option
        /// </summary>
        /// <param name="control"></param>
        /// <param name="s_mat_id"></param>
        /// <param name="i_mat_ver"></param>
        /// <param name="s_flow"></param>
        /// <param name="s_oper"></param>
        /// <param name="s_resg_id></param>
        /// <param name="b_include_delete_resource"></param>
        /// <returns></returns>
        /* 2013.06.12. Aiden. ±‚¥… √ﬂ∞° */
        public static bool ViewResourceList(Control control, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_resg_id, bool b_include_delete_resource, TreeNode parentNode)
        {
            return ViewResourceList(control, '1', s_resg_id, "", "", "", s_mat_id, i_mat_ver, s_flow, s_oper, ' ', "", b_include_delete_resource, parentNode, "");
        }
        /// <summary>
        /// Get resource list
        /// </summary>
        /// <param name="control"></param>
        /// <param name="c_step">1 - Accord MFO option, 2 - Optimum MFO option</param>
        /// <param name="s_resg_id"></param>
        /// <param name="s_res_type"></param>
        /// <param name="s_area"></param>
        /// <param name="s_sub_area"></param>
        /// <param name="s_mat_id"></param>
        /// <param name="i_mat_ver"></param>
        /// <param name="s_flow"></param>
        /// <param name="s_oper"></param>
        /// <param name="c_mfo_resource_relation_level">G - Resource Group, R - Resource</param>
        /// <param name="s_filter"></param>
        /// <param name="b_include_delete_resource"></param>
        /// <param name="parentNode"></param>
        /// <param name="s_ext_factory"></param>
        /// <returns></returns>
        public static bool ViewResourceList(
            Control control, 
            char c_step,
            string s_resg_id,
            string s_res_type, 
            string s_area, 
            string s_sub_area, 
            string s_mat_id,
            int i_mat_ver,
            string s_flow,
            string s_oper,
            char c_mfo_resource_relation_level,
            string s_filter, 
            bool b_include_delete_resource,
            TreeNode parentNode, 
            string s_ext_factory,
            bool b_sec_chk_flag)
        {

            int i;
            int j;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
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

            in_node.AddString("RESG_ID", s_resg_id);
            in_node.AddString("RES_TYPE", s_res_type);
            in_node.AddString("AREA_ID", s_area);
            in_node.AddString("SUB_AREA_ID", s_sub_area);

            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);
            in_node.AddChar("MFO_RESOURCE_REL_LEVEL", c_mfo_resource_relation_level);

            in_node.AddString("FILTER", s_filter);
            in_node.AddChar("INCLUDE_DEL_RESOURCE", b_include_delete_resource == true ? 'Y' : ' ');
            in_node.AddString("NEXT_RES_ID", "");
            in_node.AddChar("SEC_CHK_FLAG", b_sec_chk_flag == true ? 'Y' : ' ');

            do
            {
                out_node = new TRSNode("VIEW_RESOURCE_LIST_OUT");

                if (MPCR.CallService("RAS", "RAS_View_Resource_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);
                in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
            } while (in_node.GetString("NEXT_RES_ID") != "");

            for (j = 0; j < a_list.Count; j++)
            {
                out_node = null;
                out_node = (TRSNode)a_list[j];

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_UP_FLAG)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                        }
                        else if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_DOWN_FLAG)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN);
                        }
                        else
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                        }
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Magenta;
                        }
                    }
                    else if (control is TreeView)
                    {
                        if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_UP_FLAG)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        }
                        else if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_DOWN_FLAG)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")), (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN, (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN);
                        }
                        else
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        }
                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            nodeX.ForeColor = Color.Magenta;
                        }
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                    }
                }
            }


            return true;
        }



        // ViewSubResourceList()
        //       - View all Sub Resource List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - Optional ByVal sResouceType As String = "" : Resource Type
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Resource
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewSubResourceList(Control control, char c_step, string sResourceID)
        {
            return ViewSubResourceList(control, c_step, sResourceID, "");
        }
        /* 2013.06.12. Aiden. ±‚¥… √ﬂ∞° */
        public static bool ViewSubResourceList(Control control, char c_step, string sResourceID, string sParentSubResource, TreeNode parentNode)
        {
            int i_temp = 0;
            return ViewSubResourceList(control, c_step, sResourceID, "", sParentSubResource, "", false, parentNode, ref i_temp);
        }
        public static bool ViewSubResourceList(Control control, char c_step, string sResourceID, string sParentSubResource)
        {
            return ViewSubResourceList(control, c_step, sResourceID, sParentSubResource, "");
        }
        public static bool ViewSubResourceList(Control control, char c_step, string sResourceID, string sParentSubResource, string sSubResType)
        {
            return ViewSubResourceList(control, c_step, sResourceID, sParentSubResource, sSubResType, false);
        }
        public static bool ViewSubResourceList(Control control, char c_step, string sResourceID, string sParentSubResource, string sSubResType, bool bInclude_Delete_Resource)
        {
            int i_temp = 0;
            return ViewSubResourceList(control, c_step, sResourceID, "", sParentSubResource, sSubResType, bInclude_Delete_Resource, null, ref i_temp);
        }
        public static bool ViewSubResourceList(Control control, char c_step, string sResourceID, string sExtFactory, string sParentSubResource, string sSubResType, bool bInclude_Delete_Resource, TreeNode parentNode, ref int iListCount)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_SUB_RESOURCE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUB_RESOURCE_LIST_OUT");

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
           
            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("RES_ID", sResourceID);
            in_node.AddString("PARENTS_SUBRES_ID", sParentSubResource);
            in_node.AddString("SUBRES_TYPE", sSubResType);

            if (bInclude_Delete_Resource == true)
            {
                in_node.AddChar("DELETE_FLAG", 'Y');
            }
            else
            {
                in_node.AddChar("DELETE_FLAG", ' ');
            }

            in_node.AddString("NEXT_SUBRES_ID", "");

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Sub_Resource_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (c_step == '1' && out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                    {
                    }
                    else
                    {
                        if (control is ListView)
                        {
                            if (out_node.GetList(0)[i].GetChar("SUBRES_UP_DOWN_FLAG") == MPGC.MP_RES_UP_FLAG)
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID")), (int)SMALLICON_INDEX.IDX_SUB_EQUIP);
                            }
                            else if (out_node.GetList(0)[i].GetChar("SUBRES_UP_DOWN_FLAG") == MPGC.MP_RES_DOWN_FLAG)
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID")), (int)SMALLICON_INDEX.IDX_SUB_EQUIP);
                            }
                            else
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID")), (int)SMALLICON_INDEX.IDX_SUB_EQUIP);
                            }
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                            if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                            {
                                itmX.ForeColor = Color.Magenta;
                            }
                        }
                        else if (control is TreeView)
                        {
                            if (out_node.GetList(0)[i].GetChar("SUBRES_UP_DOWN_FLAG") == MPGC.MP_RES_UP_FLAG)
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_DESC")), (int)SMALLICON_INDEX.IDX_SUB_EQUIP, (int)SMALLICON_INDEX.IDX_SUB_EQUIP);
                            }
                            else if (out_node.GetList(0)[i].GetChar("SUBRES_UP_DOWN_FLAG") == MPGC.MP_RES_DOWN_FLAG)
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_DESC")), (int)SMALLICON_INDEX.IDX_SUB_EQUIP, (int)SMALLICON_INDEX.IDX_SUB_EQUIP);
                            }
                            else
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_DESC")), (int)SMALLICON_INDEX.IDX_SUB_EQUIP, (int)SMALLICON_INDEX.IDX_SUB_EQUIP);
                            }
                            if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                            {
                                nodeX.ForeColor = Color.Magenta;
                            }
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
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID")));
                        }
                        iListCount++;
                    }
                }

                in_node.SetString("NEXT_SUBRES_ID", out_node.GetString("NEXT_SUBRES_ID"));
            } while (in_node.GetString("NEXT_SUBRES_ID") != "");

            return true;

        }


        // ViewSubResourceHistory()
        //       - View Resource History
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                            : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                                : ?ïÏû• Process Step
        //        - ByVal sResID As String                            : Resource id
        //        - ByVal sSubResID As String                            : Sub Resource id
        //        - ByVal sIncludeDeleteHistory As String                : ??†ú?¥Î†•ÍπåÏ? ?úÏãú?¨Î??
        //       - Optional ByVal sEventID As String = ""            : Event ID
        //       - Optional ByVal sFromDate As String = ""           : From Date
        //       - Optional ByVal sToDate As String = ""             : To Date
        //       - Optional ByVal parentNode As TreeNode = Nothing   : Parent Node (Tree View)
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨ Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏ÏßÄ?
        //
        public static bool ViewSubResourceHistory(Control control, char c_step, string sResID, string sSubResID, char sIncludeDeleteHistory, string sEventID, string sFromDate, string sToDate, TreeNode parentNode, bool bIgnoreError)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;

            TRSNode in_node = new TRSNode("VIEW_SUB_RESOURCE_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_SUB_RESOURCE_HISTORY_OUT");

            try
            {
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
                in_node.AddString("RES_ID", sResID);
                in_node.AddString("SUBRES_ID", sSubResID);
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                in_node.AddString("FROM_TIME", sFromDate);
                in_node.AddString("TO_TIME", sToDate);
                in_node.AddString("EVENT_ID", sEventID);
                in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDeleteHistory);

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Sub_Resource_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (control is FarPoint.Win.Spread.FpSpread)
                        {

                            sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                            iRow = sheetX.RowCount;
                            sheetX.RowCount++;

                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG")) == "Y")
                            {
                                sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                            }
                            else
                            {
                                sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                            }

                            sheetX.Cells[iRow, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                            sheetX.Cells[iRow, 1].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                            sheetX.Cells[iRow, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "D")
                            {
                                sheetX.Cells[iRow, 3].Value = "DOWN";
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "U")
                            {
                                sheetX.Cells[iRow, 3].Value = "UP";
                            }
                            sheetX.Cells[iRow, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_PRI_STS"));
                            sheetX.Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_1"));
                            sheetX.Cells[iRow, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_2"));
                            sheetX.Cells[iRow, 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_3"));
                            sheetX.Cells[iRow, 8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_4"));
                            sheetX.Cells[iRow, 9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_5"));
                            sheetX.Cells[iRow, 10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_6"));
                            sheetX.Cells[iRow, 11].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_7"));
                            sheetX.Cells[iRow, 12].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_8"));
                            sheetX.Cells[iRow, 13].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_9"));
                            sheetX.Cells[iRow, 14].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_10"));
                            sheetX.Cells[iRow, 15].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));
                            sheetX.Cells[iRow, 16].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT"));
                            sheetX.Cells[iRow, 17].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG"));
                            sheetX.Cells[iRow, 18].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_TIME")));
                            sheetX.Cells[iRow, 19].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_USER_ID"));
                            sheetX.Cells[iRow, 20].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_COMMENT"));

                        }
                        else if (control is ListView)
                        {

                        }
                        else if (control is TreeView)
                        {

                        }
                        else if (control is ComboBox)
                        {

                        }
                    }

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }



        //
        // ViewSubResEventList()
        //       - View Sub Resource - Event Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewSubResEventList(Control control, char c_step, string sResID, string sSubResID, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_SUB_RESEVENT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUB_RESEVENT_LIST_OUT");

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
                in_node.AddString("NEXT_RES_ID", sResID);

                if (sExtFactory != "")
                {
                    in_node.Factory = sExtFactory;
                }

                if (c_step == '1')
                {
                    in_node.AddString("NEXT_SUBRES_ID", sSubResID);
                }

                in_node.AddChar("SUBRES_TYPE", 'S');

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Sub_ResEvent_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            if (c_step == '1')
                            {
                                itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")), (int)SMALLICON_INDEX.IDX_EVENT);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_DESC")));
                                }
                            }
                            else if (c_step == '2')
                            {
                                itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_DESC")));
                                }
                            }
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_DESC")), (int)SMALLICON_INDEX.IDX_EVENT, (int)SMALLICON_INDEX.IDX_EVENT);
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
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")));
                        }

                    }
                    in_node.SetString("NEXT_SUBRES_ID", out_node.GetString("NEXT_SUBRES_ID"));
                    in_node.SetString("NEXT_EVENT_ID", out_node.GetString("NEXT_EVENT_ID"));

                } while (in_node.GetString("NEXT_EVENT_ID") != "" || in_node.GetString("NEXT_SUBRES_ID") != "");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // ViewEventList()
        //       - View all Event List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Event
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewEventList(Control control, char c_step, string sFilter, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_EVENT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_LIST_OUT");

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
           
            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("FILTER", sFilter);
            in_node.AddString("NEXT_EVENT_ID", "");

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Event_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")), (int)SMALLICON_INDEX.IDX_EVENT);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_DESC")), (int)SMALLICON_INDEX.IDX_EVENT, (int)SMALLICON_INDEX.IDX_EVENT);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")));
                    }
                }
                in_node.SetString("NEXT_EVENT_ID", out_node.GetString("NEXT_EVENT_ID"));
            } while (in_node.GetString("NEXT_EVENT_ID") != "");


            return true;

        }


        // ViewResourceHistory()
        //       - View Resource History
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sLotID As String                    : Lot id
        //        - Optional ByVal sFromTime As String = ""   : ?úÏûë ?úÍ∞Ñ
        //        - Optional ByVal sToTime As String = ""     : ÎßàÏ?Îß??úÍ∞Ñ
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete HistoryÍπåÏ? ?¨Ìï®??Í≤ÉÏù∏ÏßÄ?
        //       - Optional ByVal sTreeItem As String = ""           : Tree Item Í∞?
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨ Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏ÏßÄ?
        //
        public static bool ViewResourceHistory(Control control, char c_step, string sResID, char sIncludeDeleteHistory, string sEventID, string sFromDate, string sToDate, TreeNode parentNode, bool bIgnoreError)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;

            TRSNode in_node = new TRSNode("VIEW_RESOURCE_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_HISTORY_OUT");

            try
            {
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
                in_node.AddString("RES_ID", sResID);
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                in_node.AddString("FROM_TIME", sFromDate);
                in_node.AddString("TO_TIME", sToDate);
                in_node.AddString("EVENT_ID", sEventID);
                in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDeleteHistory);

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Resource_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (control is FarPoint.Win.Spread.FpSpread)
                        {

                            sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                            iRow = sheetX.RowCount;
                            sheetX.RowCount++;

                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG")) == "Y")
                            {
                                sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                            }
                            else
                            {
                                sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                            }
                            
                            sheetX.Cells[iRow, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                            sheetX.Cells[iRow, 1].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                            sheetX.Cells[iRow, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "D")
                            {
                                sheetX.Cells[iRow, 3].Value = "DOWN";
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "U")
                            {
                                sheetX.Cells[iRow, 3].Value = "UP";
                            }
                            sheetX.Cells[iRow, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_PRI_STS"));
                            sheetX.Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_1"));
                            sheetX.Cells[iRow, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_2"));
                            sheetX.Cells[iRow, 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_3"));
                            sheetX.Cells[iRow, 8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_4"));
                            sheetX.Cells[iRow, 9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_5"));
                            sheetX.Cells[iRow, 10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_6"));
                            sheetX.Cells[iRow, 11].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_7"));
                            sheetX.Cells[iRow, 12].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_8"));
                            sheetX.Cells[iRow, 13].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_9"));
                            sheetX.Cells[iRow, 14].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_10"));
                            sheetX.Cells[iRow, 15].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_1"));
                            sheetX.Cells[iRow, 16].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_2"));
                            sheetX.Cells[iRow, 17].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_3"));
                            sheetX.Cells[iRow, 18].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_4"));
                            sheetX.Cells[iRow, 19].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_5"));
                            sheetX.Cells[iRow, 20].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_6"));
                            sheetX.Cells[iRow, 21].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_7"));
                            sheetX.Cells[iRow, 22].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_8"));
                            sheetX.Cells[iRow, 23].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_9"));
                            sheetX.Cells[iRow, 24].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_10"));
                            sheetX.Cells[iRow, 25].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_11"));
                            sheetX.Cells[iRow, 26].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_12"));
                            sheetX.Cells[iRow, 27].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_13"));
                            sheetX.Cells[iRow, 28].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_14"));
                            sheetX.Cells[iRow, 29].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_15"));
                            sheetX.Cells[iRow, 30].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_16"));
                            sheetX.Cells[iRow, 31].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_17"));
                            sheetX.Cells[iRow, 32].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_18"));
                            sheetX.Cells[iRow, 33].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_19"));
                            sheetX.Cells[iRow, 34].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_20"));
                            sheetX.Cells[iRow, 35].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_PROC_MODE"));
                            sheetX.Cells[iRow, 36].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_CTRL_MODE"));
                            sheetX.Cells[iRow, 37].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));
                            sheetX.Cells[iRow, 38].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT"));
                            sheetX.Cells[iRow, 39].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG"));
                            sheetX.Cells[iRow, 40].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_TIME")));
                            sheetX.Cells[iRow, 41].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_USER_ID"));
                            sheetX.Cells[iRow, 42].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_COMMENT"));

                        }
                        else if (control is ListView)
                        {

                        }
                        else if (control is TreeView)
                        {

                        }
                        else if (control is ComboBox)
                        {

                        }
                    }
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    
                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        //
        // ViewResEventList()
        //       - View Resource - Event Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewResEventList(Control control, char c_step, string sKey, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_RESEVENT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RESEVENT_LIST_OUT");

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
                    in_node.AddString("NEXT_RES_ID", sKey);
                }
                else if (c_step == '2')
                {
                    in_node.AddString("NEXT_EVENT_ID", sKey);
                }
                in_node.AddChar("RES_TYPE", 'M');

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_ResEvent_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            if (c_step == '1')
                            {
                                itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")), (int)SMALLICON_INDEX.IDX_EVENT);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_DESC")));
                                }
                            }
                            else if (c_step == '2')
                            {
                                itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                                }
                            }
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_DESC")), (int)SMALLICON_INDEX.IDX_EVENT, (int)SMALLICON_INDEX.IDX_EVENT);
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
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")));
                        }

                    }
                    in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
                    in_node.SetString("NEXT_EVENT_ID", out_node.GetString("NEXT_EVENT_ID"));
                } while (in_node.GetString("NEXT_EVENT_ID") != "" || in_node.GetString("NEXT_RES_ID") != "");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // ViewResourceListDetailByGroup()
        //       - View Resource by Group
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sResourceType As String                : Resource Type
        //        - ByVal sGrp1 As String                        : Reosource Group
        //        - Optional ByVal sGrp2 As String                        : Reosource Group
        //        - Optional ByVal sGrp3 As String                        : Reosource Group
        //        - ByVal sTbl1 As String                        : Reosource Group Table Name
        //        - Optional ByVal sTbl2 As String                        : Reosource Group Table Name
        //        - Optional ByVal sTbl3 As String                        : Reosource Group Table Name
        //       - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewResourceListDetailByGroup(Control control, char c_step, string sResourceType, string sGrp1, string sTbl1, string sGrp2, string sTbl2, string sGrp3, string sTbl3, TreeNode parentNode, string sExtFactory)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iLastRow;

            TRSNode in_node = new TRSNode("VIEW_RESBYGRP_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RESBYGRP_LIST_OUT");

            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                else if (!(control is TreeView))
                {
                    MPCF.ClearList(control, true);
                }

                MPCR.SetInMsg(in_node);
                
                if (sExtFactory == "")
                {
                    
                }
                else
                {
                    in_node.Factory = sExtFactory;
                }                
                
                in_node.ProcStep = c_step;
                in_node.AddString("RES_TYPE", sResourceType);
                in_node.AddString("RES_GRP1", sGrp1);
                in_node.AddString("RES_GRP2", sGrp2);
                in_node.AddString("RES_GRP3", sGrp3);
                in_node.AddString("TABLE_NAME1", sTbl1);
                in_node.AddString("TABLE_NAME2", sTbl2);
                in_node.AddString("TABLE_NAME3", sTbl3);
                in_node.AddString("NEXT_RES_ID", "");

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Resource_List_Detail_ByGroup", in_node, ref out_node) == false)
                    {
                        return false;
                    }


                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                            iLastRow = sheetX.RowCount;
                            sheetX.RowCount++;
                            sheetX.SetValue(iLastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                            sheetX.SetValue(iLastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                            sheetX.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_TYPE")));
                            sheetX.SetValue(iLastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetChar("USE_FAC_PRT_FLAG")));
                            //.SetValue(iLastRow, 4, RTrim(out_node.GetList(0)[i].Get("DSP_ID")))
                            sheetX.SetValue(iLastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("AREA_ID")));
                            sheetX.SetValue(iLastRow, 5, MPCF.Trim(out_node.GetList(0)[i].GetString("SUB_AREA_ID")));
                            sheetX.SetValue(iLastRow, 6, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_LOCATION")));
                            if (out_node.GetList(0)[i].GetChar("PROC_RULE") == 'S')
                            {
                                sheetX.SetValue(iLastRow, 7, "SERIAL");
                            }
                            else if (out_node.GetList(0)[i].GetChar("PROC_RULE") == 'B')
                            {
                                sheetX.SetValue(iLastRow, 7, "BATCH");
                            }
                            else
                            {
                                sheetX.SetValue(iLastRow, 7, "NORMAL");
                            }
                            sheetX.SetValue(iLastRow, 8, MPCF.Trim(out_node.GetList(0)[i].GetInt("MAX_PROC_COUNT")));
                            sheetX.SetValue(iLastRow, 9, MPCF.Trim(out_node.GetList(0)[i].GetChar("PM_SCH_ENABLE_FLAG")));
                            sheetX.SetValue(iLastRow, 10, MPCF.Trim(out_node.GetList(0)[i].GetChar("UNIT_BASE_ST_FLAG")));
                            sheetX.SetValue(iLastRow, 11, MPCF.Trim(out_node.GetList(0)[i].GetChar("SEC_CHK_FLAG")));
                            sheetX.SetValue(iLastRow, 12, MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID")));
                            sheetX.SetValue(iLastRow, 13, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME"))));
                            sheetX.SetValue(iLastRow, 14, MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID")));
                            sheetX.SetValue(iLastRow, 15, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME"))));
                            sheetX.SetValue(iLastRow, 16, MPCF.Trim(out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG")));
                            sheetX.SetValue(iLastRow, 17, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_PRI_STS")));
                            sheetX.SetValue(iLastRow, 18, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_CTRL_MODE")));
                            sheetX.SetValue(iLastRow, 19, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_PROC_MODE")));
                            sheetX.SetValue(iLastRow, 20, MPCF.Trim(out_node.GetList(0)[i].GetInt("PROC_COUNT")));
                            sheetX.SetValue(iLastRow, 21, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_START_TIME"))));
                            sheetX.SetValue(iLastRow, 22, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_END_TIME"))));
                            sheetX.SetValue(iLastRow, 23, MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_EVENT")));
                            sheetX.SetValue(iLastRow, 24, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_EVENT_TIME"))));
                            sheetX.SetValue(iLastRow, 25, MPCF.Trim(out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ")));
                            sheetX.SetValue(iLastRow, 26, MPCF.Trim(out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ")));
                        }
                        else if (control is ListView)
                        {
                            if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_UP_FLAG)
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                            }
                            else if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_DOWN_FLAG)
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN);
                            }
                            else
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                            }
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is TreeView)
                        {
                            if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_UP_FLAG)
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_RESOURCE);
                            }
                            else if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_DOWN_FLAG)
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")), (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN, (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN);
                            }
                            else
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_RESOURCE);
                            }
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
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                        }
                    }
                    in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
                } while (in_node.GetString("NEXT_RES_ID") != "");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // ViewResLotList()
        //       - View Lot List by Resource Group
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - Optional ByVal sResID As String = ""      : Resource ID
        //       - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewResLotList(Control control, char c_step, string sResID, TreeNode parentNode, string sExtFactory)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iLastRow;

            TRSNode in_node = new TRSNode("VIEW_RESLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RESLOT_LIST_OUT");

            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                else if (!(control is TreeView))
                {
                    MPCF.ClearList(control, true);
                }

                // Modified by J.H.Baek(2006.2.14)
                // FarPoint.Win.Spread.SheetView --> FarPoint.Win.Spread.FpSpred
                //If TypeOf control Is FarPoint.Win.Spread.SheetView Then
                //    sheetX.Models.Span.Clear()
                //End If
                if (control is FarPoint.Win.Spread.FpSpread)
                {
                    sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                    for (i = 0; i <= sheetX.Rows.Count - 1; i++)
                    {
                        sheetX.Rows[i].BackColor = Color.White;
                    }
                    sheetX.Models.Span.Clear();
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("NEXT_RES_ID", sResID);
                in_node.AddString("NEXT_LOT_ID", "");

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_ResLot_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                            iLastRow = sheetX.RowCount;
                            sheetX.RowCount++;

                            sheetX.SetValue(iLastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                            sheetX.SetValue(iLastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_STATUS")));
                            sheetX.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")));
                            sheetX.SetValue(iLastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER")));
                            sheetX.SetValue(iLastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));
                            sheetX.SetValue(iLastRow, 5, MPCF.Trim(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM")));
                            sheetX.SetValue(iLastRow, 6, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                            sheetX.SetValue(iLastRow, 7, MPCF.Trim(out_node.GetList(0)[i].GetDouble("QTY_1")));
                            sheetX.SetValue(iLastRow, 8, MPCF.Trim(out_node.GetList(0)[i].GetDouble("QTY_2")));
                            sheetX.SetValue(iLastRow, 9, MPCF.Trim(out_node.GetList(0)[i].GetDouble("QTY_3")));
                            sheetX.SetValue(iLastRow, 10, MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_TYPE")));
                            sheetX.SetValue(iLastRow, 11, MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_PRIORITY")));
                            sheetX.SetValue(iLastRow, 12, MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_CODE")));
                            sheetX.SetValue(iLastRow, 13, MPCF.Trim(out_node.GetList(0)[i].GetString("OWNER_CODE")));
                            sheetX.SetValue(iLastRow, 14, MPCF.Trim(out_node.GetList(0)[i].GetString("HOLD_CODE")));

                        }
                        else if (control is ListView)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")), (int)SMALLICON_INDEX.IDX_LOT);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_TYPE")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_TYPE")), (int)SMALLICON_INDEX.IDX_LOT, (int)SMALLICON_INDEX.IDX_LOT);
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
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                        }
                    }
                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));

                } while (in_node.GetString("NEXT_LOT_ID") != "");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // ViewLotByResList()
        //       -  View Lot List by Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        public static bool ViewLotByResList(Control control, char c_step, string sRes, string sOper, TreeNode parentNode, string sExtFactory)
        {
            return ViewLotByResList(control, c_step, sRes, sOper, parentNode, sExtFactory, false);
        }
        public static bool ViewLotByResList(Control control, char c_step, string sRes, string sOper, TreeNode parentNode, string sExtFactory, bool bAddIcon)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX = new FarPoint.Win.Spread.SheetView();
            int i;
            int iLastRow;

            TRSNode in_node = new TRSNode("VIEW_LOTBYRES_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOTBYRES_LIST_OUT");

            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                else if (!(control is TreeView))
                {
                    MPCF.ClearList(control, true);
                }

                if (control is FarPoint.Win.Spread.FpSpread)
                {
                    sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                    for (i = 0; i <= sheetX.Rows.Count - 1; i++)
                    {
                        sheetX.Rows[i].BackColor = Color.White;
                    }
                }
                
                MPCR.SetInMsg(in_node);                
                in_node.ProcStep = c_step;
                in_node.AddString("NEXT_LOT_ID", "");
                in_node.AddString("RES_ID", sRes);
                in_node.AddString("OPER", sOper);

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_LotByRes_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                            iLastRow = sheetX.RowCount;
                            sheetX.RowCount++;

                            sheetX.SetValue(iLastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                            sheetX.SetValue(iLastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("START_RES_ID")));
                            sheetX.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_STATUS")));
                            sheetX.SetValue(iLastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")));
                            sheetX.SetValue(iLastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER")));
                            sheetX.SetValue(iLastRow, 5, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));
                            sheetX.SetValue(iLastRow, 6, MPCF.Trim(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM")));
                            sheetX.SetValue(iLastRow, 7, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                            sheetX.SetValue(iLastRow, 8, MPCF.Trim(out_node.GetList(0)[i].GetDouble("QTY_1")));
                            sheetX.SetValue(iLastRow, 9, MPCF.Trim(out_node.GetList(0)[i].GetDouble("QTY_2")));
                            sheetX.SetValue(iLastRow, 10, MPCF.Trim(out_node.GetList(0)[i].GetDouble("QTY_3")));
                            sheetX.SetValue(iLastRow, 11, MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_TYPE")));
                            sheetX.SetValue(iLastRow, 12, MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_PRIORITY")));
                            sheetX.SetValue(iLastRow, 13, MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_CODE")));
                            sheetX.SetValue(iLastRow, 14, MPCF.Trim(out_node.GetList(0)[i].GetString("OWNER_CODE")));
                            sheetX.SetValue(iLastRow, 15, MPCF.Trim(out_node.GetList(0)[i].GetString("HOLD_CODE")));
                        }
                        else if (control is ListView)
                        {
                            if (bAddIcon == false)
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")), (int)SMALLICON_INDEX.IDX_LOT);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_TYPE")));
                                }
                                ((ListView)control).Items.Add(itmX);
                            }
                            else
                            {
                                itmX = new ListViewItem((i + 1).ToString());

                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_ID"));
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("START_RES_ID"));
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_STATUS"));
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW"));
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER"));
                                itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1")));
                                itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2")));
                                itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3")));
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_TYPE").ToString());
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_PRIORITY").ToString());
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CREATE_CODE"));
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OWNER_CODE"));
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("HOLD_CODE"));

                                if (out_node.GetList(0)[i].GetChar("HOLD_FLAG") == 'Y')
                                {
                                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                                }
                                else if (out_node.GetList(0)[i].GetChar("START_FLAG") == 'Y')
                                {
                                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_START;
                                }
                                else if (out_node.GetList(0)[i].GetChar("RWK_FLAG") == 'Y')
                                {
                                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                                }
                                else if (out_node.GetList(0)[i].GetChar("NSTD_FLAG") == 'Y')
                                {
                                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                                }
                                else if (out_node.GetList(0)[i].GetString("LAST_TRAN_CODE") == MPGC.MP_TRAN_CODE_RELEASE)
                                {
                                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                                }
                                else if (out_node.GetList(0)[i].GetChar("REP_FLAG") == 'Y')
                                {
                                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                                }
                                else
                                {
                                    itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                                }

                                ((ListView) control).Items.Add(itmX);
                            }
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_TYPE")), (int)SMALLICON_INDEX.IDX_LOT, (int)SMALLICON_INDEX.IDX_LOT);
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
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                        }
                    }
                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                } while (in_node.GetString("NEXT_LOT_ID") != "");

                for (i = 0; i <= sheetX.RowCount - 1; i++)
                {
                    if (sheetX.Cells[i, 1].Text == "PROC")
                    {
                        sheetX.Rows[i].BackColor = Color.Yellow;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // ViewEventByGrpList()
        //       - View Event List by Group
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sResID As String                     : Resource ID
        //        - ByVal sGrp1 As String                        : Reosource Group
        //        - ByVal sGrp2 As String                        : Reosource Group
        //        - ByVal sGrp3 As String                        : Reosource Group
        //        - ByVal sTbl1 As String                        : Reosource Group Table Name
        //        - ByVal sTbl2 As String                        : Reosource Group Table Name
        //        - ByVal sTbl3 As String                        : Reosource Group Table Name
        //       - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewEventByGrpList(Control control, char c_step, string sResID, string sGrp1, string sTbl1, string sGrp2, string sTbl2, string sGrp3, string sTbl3, TreeNode parentNode, string sExtFactory)
        {
            return ViewEventByGrpList(control, c_step, sResID, sGrp1, sTbl1, sGrp2, sTbl2, sGrp3, sTbl3, parentNode, sExtFactory, "");
        }
        public static bool ViewEventByGrpList(Control control, char c_step, string sResID, string sGrp1, string sTbl1, string sGrp2, string sTbl2, string sGrp3, string sTbl3, TreeNode parentNode, string sExtFactory, string sFilter)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iLastRow;

            TRSNode in_node = new TRSNode("VIEW_EVENT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_LIST_OUT");

            try
            {
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
                in_node.AddString("RES_ID", sResID);
                in_node.AddString("EVENT_GRP_1", sGrp1);
                in_node.AddString("EVENT_GRP_2", sGrp2);
                in_node.AddString("EVENT_GRP_3", sGrp3);
                in_node.AddString("TABLE_NAME1", sTbl1);
                in_node.AddString("TABLE_NAME2", sTbl2);
                in_node.AddString("TABLE_NAME3", sTbl3);
                in_node.AddString("FILTER", sFilter);
                in_node.AddString("NEXT_EVENT_ID", "");
                
                if (sExtFactory != "")                
                {
                    in_node.Factory = sExtFactory;
                }

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Event_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }


                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                            iLastRow = sheetX.RowCount;
                            sheetX.RowCount++;
                            sheetX.SetValue(iLastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")));
                            sheetX.SetValue(iLastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_DESC")));
                            sheetX.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetChar("SYSTEM_FLAG")));
                            sheetX.SetValue(iLastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_UP_DOWN_FLAG")));
                            sheetX.SetValue(iLastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_UP_DOWN")));
                            sheetX.SetValue(iLastRow, 5, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_UP_DOWN_FLAG")));
                            sheetX.SetValue(iLastRow, 6, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_UP_DOWN")));
                            sheetX.SetValue(iLastRow, 7, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_PRI_STS_FLAG")));
                            sheetX.SetValue(iLastRow, 8, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_PRI_STS")));
                            sheetX.SetValue(iLastRow, 9, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_PRI_STS_FLAG")));
                            sheetX.SetValue(iLastRow, 10, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_PRI_STS")));
                            sheetX.SetValue(iLastRow, 11, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_PRI_STS")));
                            sheetX.SetValue(iLastRow, 12, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_1")));
                            sheetX.SetValue(iLastRow, 13, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_1")));
                            sheetX.SetValue(iLastRow, 14, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_1")));
                            sheetX.SetValue(iLastRow, 15, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_1")));
                            sheetX.SetValue(iLastRow, 16, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_1")));
                            sheetX.SetValue(iLastRow, 17, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_2")));
                            sheetX.SetValue(iLastRow, 18, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_2")));
                            sheetX.SetValue(iLastRow, 19, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_2")));
                            sheetX.SetValue(iLastRow, 20, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_2")));
                            sheetX.SetValue(iLastRow, 21, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_2")));
                            sheetX.SetValue(iLastRow, 22, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_3")));
                            sheetX.SetValue(iLastRow, 23, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_3")));
                            sheetX.SetValue(iLastRow, 24, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_3")));
                            sheetX.SetValue(iLastRow, 25, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_3")));
                            sheetX.SetValue(iLastRow, 26, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_3")));
                            sheetX.SetValue(iLastRow, 27, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_4")));
                            sheetX.SetValue(iLastRow, 28, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_4")));
                            sheetX.SetValue(iLastRow, 29, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_4")));
                            sheetX.SetValue(iLastRow, 30, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_4")));
                            sheetX.SetValue(iLastRow, 31, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_4")));
                            sheetX.SetValue(iLastRow, 32, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_5")));
                            sheetX.SetValue(iLastRow, 33, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_5")));
                            sheetX.SetValue(iLastRow, 34, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_5")));
                            sheetX.SetValue(iLastRow, 35, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_5")));
                            sheetX.SetValue(iLastRow, 36, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_5")));
                            sheetX.SetValue(iLastRow, 37, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_6")));
                            sheetX.SetValue(iLastRow, 38, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_6")));
                            sheetX.SetValue(iLastRow, 39, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_6")));
                            sheetX.SetValue(iLastRow, 40, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_6")));
                            sheetX.SetValue(iLastRow, 41, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_6")));
                            sheetX.SetValue(iLastRow, 42, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_7")));
                            sheetX.SetValue(iLastRow, 43, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_7")));
                            sheetX.SetValue(iLastRow, 44, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_7")));
                            sheetX.SetValue(iLastRow, 45, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_7")));
                            sheetX.SetValue(iLastRow, 46, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_7")));
                            sheetX.SetValue(iLastRow, 47, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_8")));
                            sheetX.SetValue(iLastRow, 48, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_8")));
                            sheetX.SetValue(iLastRow, 49, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_8")));
                            sheetX.SetValue(iLastRow, 50, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_8")));
                            sheetX.SetValue(iLastRow, 51, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_8")));
                            sheetX.SetValue(iLastRow, 52, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_9")));
                            sheetX.SetValue(iLastRow, 53, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_9")));
                            sheetX.SetValue(iLastRow, 54, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_9")));
                            sheetX.SetValue(iLastRow, 55, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_9")));
                            sheetX.SetValue(iLastRow, 56, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_9")));
                            sheetX.SetValue(iLastRow, 57, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_FLAG_10")));
                            sheetX.SetValue(iLastRow, 58, MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_STS_10")));
                            sheetX.SetValue(iLastRow, 59, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHG_FLAG_10")));
                            sheetX.SetValue(iLastRow, 60, MPCF.Trim(out_node.GetList(0)[i].GetString("CHG_STS_10")));
                            sheetX.SetValue(iLastRow, 61, MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_10")));
                            sheetX.SetValue(iLastRow, 62, MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID")));
                        }
                        else if (control is ListView)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")), (int)SMALLICON_INDEX.IDX_EVENT);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_DESC")), (int)SMALLICON_INDEX.IDX_EVENT, (int)SMALLICON_INDEX.IDX_EVENT);
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
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")));
                        }
                    }
                    in_node.SetString("NEXT_EVENT_ID", out_node.GetString("NEXT_EVENT_ID"));
                } while (in_node.GetString("NEXT_EVENT_ID") != "");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // View_Resource_List()
        //       - View Reource List By Area/SubArea Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        public static bool ViewResourceListDetail(Control control, string sRes_Type, string sGroup, string sArea_ID, string sSub_Area_ID, string sFilter, bool bInclude_Delete_Resource, bool bInclude_Proc_Lot_Info, string sExtFactory, bool bIgnoreError)
        {
            return ViewResourceListDetail(control, sRes_Type, sGroup, sArea_ID, sSub_Area_ID, "", 0, "", "", "", ' ', "", ' ', sFilter, bInclude_Delete_Resource, bInclude_Proc_Lot_Info, sExtFactory, bIgnoreError); 
        }

        public static bool ViewResourceListDetail(Control control, string sRes_Type, string sMat_ID, int sMat_Ver, string sFlow, string sOper, string sRes_Group, char c_mfo_resource_relation_level, string sFilter, bool bInclude_Delete_Resource, string sExtFactory, bool bIgnoreError)
        {
            return ViewResourceListDetail(control, sRes_Type, "", "", "", sMat_ID, sMat_Ver, sFlow, sOper, "", ' ', sRes_Group, c_mfo_resource_relation_level, sFilter, bInclude_Delete_Resource, false, sExtFactory, bIgnoreError);
        }

        public static bool ViewResourceListDetail(Control control, 
                                                  string sRes_Type, 
                                                  string sGroup, 
                                                  string sArea_ID, 
                                                  string sSub_Area_ID,
                                                  string sMat_ID,
                                                  int sMat_Ver,
                                                  string sFlow,
                                                  string sOper,
                                                  string sLast_Event_ID,
                                                  char cUp_Down_Flag,
                                                  string sRes_Group,
                                                  char c_mfo_resource_relation_level,
                                                  string sFilter, 
                                                  bool bInclude_Delete_Resource, 
                                                  bool bInclude_Proc_Lot_Info, 
                                                  string sExtFactory, 
                                                  bool bIgnoreError)
        {
            bool bGetItem = true;
            int iLastRow;
            int i;

            ListViewItem itmX;
            FarPoint.Win.Spread.SheetView sheetX;

            TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_DETAIL_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_LIST_DETAIL_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("RES_TYPE", sRes_Type);
            in_node.AddString("RES_GRP", sGroup);
            in_node.AddString("AREA_ID", sArea_ID);
            in_node.AddString("SUB_AREA_ID", sSub_Area_ID);
            in_node.AddString("FILTER", sFilter);
            in_node.AddChar("INCLUDE_DEL_RES", bInclude_Delete_Resource == true ? 'Y' : ' ');
            in_node.AddChar("INCLUDE_PROC_LOT_INFO", bInclude_Proc_Lot_Info == true ? 'Y' : ' ');

            in_node.AddString("MAT_ID", sMat_ID);
            in_node.AddInt("MAT_VER", sMat_Ver);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("OPER", sOper);
            in_node.AddString("RESG_ID", sRes_Group);
            in_node.AddChar("MFO_RESOURCE_REL_LEVEL", c_mfo_resource_relation_level);

            in_node.AddString("NEXT_RES_ID", "");

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Resource_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    bGetItem = true;

                    if (cUp_Down_Flag != ' ')
                    {
                        if (cUp_Down_Flag != out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG"))
                        {
                            bGetItem = false;
                        }
                    }

                    if (MPCF.Trim(sLast_Event_ID) != "")
                    {
                        if (sLast_Event_ID != out_node.GetList(0)[i].GetString("LAST_EVENT_ID"))
                        {
                            bGetItem = false;
                        }
                    }

                    if (control is ListView)
                    {
                        if (bGetItem == true)
                        {
                            itmX = new ListViewItem(MPCF.Trim(i + 1));

                            //itmX.SubItems.Add(RTrim(.factory))
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_TYPE")));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG")) == "U")
                            {
                                itmX.SubItems.Add("UP");
                            }
                            else
                            {
                                itmX.SubItems.Add("DOWN");
                            }
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_PRI_STS")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_3")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_4")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_5")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_6")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_7")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_8")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_9")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_PRT_10")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_3")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_4")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_5")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_6")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_7")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_8")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_9")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_STS_10")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("USE_FAC_PRT_FLAG")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_EVENT_ID")));
                            itmX.SubItems.Add(MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_EVENT_TIME"))));
                            itmX.SubItems.Add(MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_START_TIME"))));
                            itmX.SubItems.Add(MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_END_TIME"))));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("PROC_COUNT")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("MAX_PROC_COUNT")));

                            if (bInclude_Proc_Lot_Info == true)
                            {
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[0].GetString("LOT_ID")));
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[1].GetString("LOT_ID")));
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[2].GetString("LOT_ID")));
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[3].GetString("LOT_ID")));
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[4].GetString("LOT_ID")));
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[5].GetString("LOT_ID")));
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[6].GetString("LOT_ID")));
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[7].GetString("LOT_ID")));
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[8].GetString("LOT_ID")));
                                //itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[9].GetString("LOT_ID")));
                            }

                            //itmX.SubItems.Add(RTrim(.res_grp_1))
                            //itmX.SubItems.Add(RTrim(.res_grp_2))
                            //itmX.SubItems.Add(RTrim(.res_grp_3))
                            //itmX.SubItems.Add(RTrim(.res_grp_4))
                            //itmX.SubItems.Add(RTrim(.res_grp_5))
                            //itmX.SubItems.Add(RTrim(.res_grp_6))
                            //itmX.SubItems.Add(RTrim(.res_grp_7))
                            //itmX.SubItems.Add(RTrim(.res_grp_8))
                            //itmX.SubItems.Add(RTrim(.res_grp_9))
                            //itmX.SubItems.Add(RTrim(.res_grp_10))
                            //itmX.SubItems.Add(RTrim(.res_cmf_1))
                            //itmX.SubItems.Add(RTrim(.res_cmf_2))
                            //itmX.SubItems.Add(RTrim(.res_cmf_3))
                            //itmX.SubItems.Add(RTrim(.res_cmf_4))
                            //itmX.SubItems.Add(RTrim(.res_cmf_5))
                            //itmX.SubItems.Add(RTrim(.res_cmf_6))
                            //itmX.SubItems.Add(RTrim(.res_cmf_7))
                            //itmX.SubItems.Add(RTrim(.res_cmf_8))
                            //itmX.SubItems.Add(RTrim(.res_cmf_9))
                            //itmX.SubItems.Add(RTrim(.res_cmf_10))
                            //itmX.SubItems.Add(RTrim(.area_id))
                            //itmX.SubItems.Add(RTrim(.sub_area_id))
                            //itmX.SubItems.Add(RTrim(.dsp_id))
                            //itmX.SubItems.Add(RTrim(.res_location))
                            //itmX.SubItems.Add(RTrim(.proc_rule))
                            //itmX.SubItems.Add(RTrim(.batch_cond_1))
                            //itmX.SubItems.Add(RTrim(.batch_cond_2))
                            //itmX.SubItems.Add(RTrim(.pm_sch_enable_flag))
                            //itmX.SubItems.Add(RTrim(.unit_base_st_flag))
                            //itmX.SubItems.Add(RTrim(.sec_chk_flag))
                            //itmX.SubItems.Add(RTrim(.res_proc_mode))
                            //itmX.SubItems.Add(RTrim(.last_recipe_id))
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ")));
                            //itmX.SubItems.Add(RTrim(.delete_flag))
                            //itmX.SubItems.Add(RTrim(.delete_user_id))
                            //itmX.SubItems.Add(RTrim(.delete_time))
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID")));
                            itmX.SubItems.Add(MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME"))));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID")));
                            itmX.SubItems.Add(MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME"))));

                            if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == 'U')
                            {
                                itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_RESOURCE;
                            }
                            else
                            {
                                itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN;
                            }

                            ((ListView)control).Items.Add(itmX);
                        }
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                        iLastRow = sheetX.RowCount;
                        sheetX.RowCount++;
                        sheetX.SetValue(iLastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                        sheetX.SetValue(iLastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                        sheetX.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_TYPE")));
                        sheetX.SetValue(iLastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetChar("USE_FAC_PRT_FLAG")));
                        sheetX.SetValue(iLastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("AREA_ID")));
                        sheetX.SetValue(iLastRow, 5, MPCF.Trim(out_node.GetList(0)[i].GetString("SUB_AREA_ID")));
                        sheetX.SetValue(iLastRow, 6, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_LOCATION")));
                        sheetX.SetValue(iLastRow, 7, MPCF.Trim(out_node.GetList(0)[i].GetChar("PROC_RULE")));
                        sheetX.SetValue(iLastRow, 8, MPCF.Trim(out_node.GetList(0)[i].GetInt("MAX_PROC_COUNT")));
                        sheetX.SetValue(iLastRow, 9, MPCF.Trim(out_node.GetList(0)[i].GetChar("PM_SCH_ENABLE_FLAG")));
                        sheetX.SetValue(iLastRow, 10, MPCF.Trim(out_node.GetList(0)[i].GetChar("UNIT_BASE_ST_FLAG")));
                        sheetX.SetValue(iLastRow, 11, MPCF.Trim(out_node.GetList(0)[i].GetChar("SEC_CHK_FLAG")));
                        sheetX.SetValue(iLastRow, 12, MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID")));
                        sheetX.SetValue(iLastRow, 13, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME"))));
                        sheetX.SetValue(iLastRow, 14, MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID")));
                        sheetX.SetValue(iLastRow, 15, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME"))));
                        sheetX.SetValue(iLastRow, 16, MPCF.Trim(out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG")));
                        sheetX.SetValue(iLastRow, 17, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_PRI_STS")));
                        sheetX.SetValue(iLastRow, 18, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_PROC_MODE")));
                        sheetX.SetValue(iLastRow, 19, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_CTRL_MODE")));
                        sheetX.SetValue(iLastRow, 20, MPCF.Trim(out_node.GetList(0)[i].GetInt("PROC_COUNT")));
                        sheetX.SetValue(iLastRow, 21, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_START_TIME"))));
                        sheetX.SetValue(iLastRow, 22, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_END_TIME"))));
                        sheetX.SetValue(iLastRow, 23, MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_EVENT_ID")));
                        sheetX.SetValue(iLastRow, 24, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_EVENT_TIME"))));
                        sheetX.SetValue(iLastRow, 25, MPCF.Trim(out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ")));
                        sheetX.SetValue(iLastRow, 26, MPCF.Trim(out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ")));
                    }
                }
                in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
                
            } while (in_node.GetString("NEXT_RES_ID") != "");

            return true;

        }


        // ViewPMSecurityList()
        //       - View PM Security List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sKey As String                        : Key Í∞?(step='1' ?ºÍ≤Ω??Res_ID, step='2' ??Í≤ΩÏö∞ User_ID)
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewPMSecurityList(Control control, char c_step, string sKey, string sExtFactory)
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_PM_SEC_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_PM_SEC_LIST_OUT");

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
                    in_node.AddString("NEXT_RES_ID", sKey);
                }
                else if (c_step == '2')
                {
                    in_node.AddString("NEXT_USER_ID", sKey, true);
                }

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_PM_Security_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            if (c_step == '1')
                            {
                                itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("USER_ID")), (int)SMALLICON_INDEX.IDX_USER);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("USER_DESC")));
                                }
                            }
                            else if (c_step == '2')
                            {
                                itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                                }
                            }
                        }

                    }
                    in_node.SetString("NEXT_USER_ID", out_node.GetString("NEXT_USER_ID"), true);
                    in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"), true);

                } while (in_node.GetString("NEXT_USER_ID") != "" || in_node.GetString("NEXT_RES_ID") != "");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // ViewPortList()
        //       - View Port List
        // Return Value
        //       - boolean : True / False
        // PORT LIST.

        public static bool ViewPortList(Control control, char c_step, string sResource, string sSubResource)
        {
            return ViewPortList(control, c_step, sResource, sSubResource, null, "");
        }

        public static bool ViewPortList(Control control, char c_step, string sResource, string sSubResource, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_PORT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_PORT_LIST_OUT");

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
           
            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("RES_ID", sResource);
            in_node.AddString("SUBRES_ID", sSubResource);

            if (MPCR.CallService("RAS", "RAS_View_Port_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (control is ListView)
                {
                    itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PORT_ID")), (int)SMALLICON_INDEX.IDX_PORT);
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PORT_DESC")));

                    ((ListView)control).Items.Add(itmX);
                }
                else if (control is TreeView)
                {
                    nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("PORT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("PORT_DESC")), (int)SMALLICON_INDEX.IDX_PORT, (int)SMALLICON_INDEX.IDX_PORT);
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
                    ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PORT_ID")));
                }

            }


            return true;

        }

        // ViewCarrierList()
        //       - View all Carrier List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewCarrierList(Control control, string sLotID)
        {
            return ViewCarrierList(control, '1', "", "", sLotID, ' ', "", 0, "", "", "", "", "", null, ""); 
        }

        public static bool ViewCarrierList(Control control, char c_step, string sCrrGroup, string sType1, string sLotID, string sFilter)
        {
            return ViewCarrierList(control, c_step, sCrrGroup, sType1, sLotID, ' ', "", 0, "", "", "", "", sFilter, null, "");
        }
        public static bool ViewCarrierList(Control control, char c_step, string sCrrGroup, string sType1, string sFilter)
        {
            return ViewCarrierList(control, c_step, sCrrGroup, sType1, "", ' ', "", 0, "", "", "", "", sFilter, null, "");
        }
        public static bool ViewCarrierList(Control control, char c_step, char cRelLevel, string sMatID, int iMatVer, 
                                           string sFlow, string sOper, string sResID, string sPortID)
        {
            return ViewCarrierList(control, c_step, "", "", "", cRelLevel, sMatID, iMatVer, sFlow, sOper, sResID, sPortID, "", null, "");
        }
        public static bool ViewCarrierList(Control control, char c_step, string sCrrGroup, string sType1, string sLotID, 
                                           char cRelLevel, string sMatID, int iMatVer, string sFlow, string sOper, string sResID, string sPortID)
        {
            return ViewCarrierList(control, c_step, sCrrGroup, sType1, sLotID, cRelLevel, sMatID, iMatVer, sFlow, sOper, sResID, sPortID, "", null, "");
        }
        public static bool ViewCarrierList(Control control, char c_step, string sCrrGroup, string sType1, string sLotID, 
                                           char cRelLevel, string sMatID, int iMatVer, string sFlow, string sOper, string sResID, string sPortID, 
                                           string sFilter, TreeNode parentNode, string sExtFactory)
        {

            int i;
            int j;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_CARRIER_LIST_IN");
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
            
            in_node.AddString("CRR_GROUP", sCrrGroup);
            in_node.AddString("CRR_TYPE1", sType1);
            in_node.AddString("LOT_ID", sLotID);
            in_node.AddString("FILTER", sFilter);

            in_node.AddChar("REL_LEVEL", cRelLevel);
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("OPER", sOper);
            in_node.AddString("RES_ID", sResID);
            in_node.AddString("PORT_ID", sPortID);


            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }


            in_node.AddString("NEXT_CRR_ID", "");

            do
            {
                out_node = new TRSNode("VIEW_CARRIER_LIST_OUT");

                if (MPCR.CallService("RAS", "RAS_View_Carrier_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_CRR_ID", out_node.GetString("NEXT_CRR_ID"));

            } while (in_node.GetString("NEXT_CRR_ID") != "");

            for (j = 0; j < a_list.Count; j++)
            {
                out_node = null;
                out_node = (TRSNode)a_list[j];

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")), (int)SMALLICON_INDEX.IDX_CARRIER);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_DESC")), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_CARRIER);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")));
                    }

                }
            }

            return true;

        }


        // ViewCarrierGroupList()
        //       - View all Carrier Group List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : Control
        //        - ByVal c_step As String                        : Process Step
        //
        public static bool ViewCarrierGroupList(Control control)
        {
            return ViewCarrierGroupList(control, '1', ' ', "", 0, "", "", "", "", null, "");
        }

        public static bool ViewCarrierGroupList(Control control, char c_rel_level, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_res_id, string s_port_id)
        {
            char c_step;
            c_step = c_rel_level == ' ' ? '3' : '2';
            return ViewCarrierGroupList(control, c_step, c_rel_level, s_mat_id, i_mat_ver, s_flow, s_oper, s_res_id, s_port_id, null, "");
        }

        public static bool ViewCarrierGroupList(Control control, char c_step, char c_rel_level, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_res_id, string s_port_id, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");

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
            
            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("NEXT_CRR_GROUP", "");

            in_node.AddChar("REL_LEVEL", c_rel_level);
            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);
            in_node.AddString("RES_ID", s_res_id);
            in_node.AddString("PORT_ID", s_port_id);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Carrier_Group_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        if (c_step == '2')
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("PRI_SEQ").ToString(), (int)SMALLICON_INDEX.IDX_MODULE);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_GROUP")));
                            }
                            if (((ListView)control).Columns.Count > 2)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_GRP_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_GROUP")), (int)SMALLICON_INDEX.IDX_MODULE);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_GRP_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_GROUP")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_GRP_DESC")), (int)SMALLICON_INDEX.IDX_MODULE, (int)SMALLICON_INDEX.IDX_MODULE);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_GROUP")));
                    }
                }
                in_node.SetString("NEXT_CRR_GROUP", out_node.GetString("NEXT_CRR_GROUP"));

            } while (in_node.GetString("NEXT_CRR_GROUP") != "");

            return true;

        }

        
        // ViewCarrierSublotList()
        //       - View all Sublot List in carrier
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewCarrierSublotList(Control control, char c_step, string sCrrID)
        {
            int i_temp = 0;
            return ViewCarrierSublotList(control, c_step, sCrrID, null, "", ref i_temp, false);
        }
        public static bool ViewCarrierSublotList(Control control, char c_step, string sCrrID, bool bGrade)
        {
            int i_temp = 0;
            return ViewCarrierSublotList(control, c_step, sCrrID, null, "", ref i_temp, bGrade);
        }
        public static bool ViewCarrierSublotList(Control control, char c_step, string sCrrID, TreeNode parentNode, string sExtFactory, ref int iListCount, bool bGrade)
        {

            int i, j;
            //int iRow;
            int iSlotNo, iPrevSlotNo;
            int iCrrSize;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_CARRIER_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_OUT");

            TRSNode crr_in = new TRSNode("VIEW_CARRIER_SUBLOT_LIST_IN");
            TRSNode crr_out = new TRSNode("VIEW_CARRIER_SUBLOT_LIST_OUT");


            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_ID", sCrrID);

                if (sExtFactory != "")
                {
                    in_node.Factory = sExtFactory;
                }

                if (MPCR.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }

                //Add by J.S. 2009.03.04 µø¿œ«— slot_noø° ø©∑Ø∞≥¿« sublot¿Ã ¿÷¥¬ ∞ÊøÏ ∂ßπÆø° ºˆ¡§
                iCrrSize = 0;
                if (control is ListView)
                {
                    iCrrSize = out_node.GetInt("CRR_SIZE");

                    //for (i = 1; i <= out_node.GetInt("CRR_SIZE"); i++)
                    //{
                    //    itmX = new ListViewItem(i.ToString(), (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                    //    itmX.SubItems.Add("");
                    //    itmX.SubItems.Add("");
                    //    itmX.SubItems.Add("");
                    //    itmX.SubItems.Add("");
                    //    ((ListView)control).Items.Add(itmX);
                    //}
                }

                crr_in.ProcStep = c_step;
                crr_in.AddInt("NEXT_SLOT_NO", 0);
                crr_in.AddString("CRR_ID", sCrrID);

                if (sExtFactory != "")
                {
                    crr_in.Factory = sExtFactory;
                }
                else
                {
                    crr_in.Factory = MPGV.gsFactory;
                }

                iPrevSlotNo = 0;
                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Carrier_Sublot_List", crr_in, ref crr_out) == false)
                    {
                        return false;
                    }

                    for (i = 0; i <= crr_out.GetList(0).Count - 1; i++)
                    {
                        if (control is ListView)
                        {
                            iSlotNo = crr_out.GetList(0)[i].GetInt("SLOT_NO");
                            for (j = iPrevSlotNo+1; j < iSlotNo; j++)
                            {
                                itmX = new ListViewItem(j.ToString(), (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                                itmX.SubItems.Add("");
                                itmX.SubItems.Add("");
                                itmX.SubItems.Add("");
                                itmX.SubItems.Add("");

                                ((ListView)control).Items.Add(itmX);
                            }

                            itmX = new ListViewItem(iSlotNo.ToString(), (int)SMALLICON_INDEX.IDX_SLOT_FULL);
                            itmX.SubItems.Add(MPCF.Trim(crr_out.GetList(0)[i].GetString("SUBLOT_ID")));
                            itmX.SubItems.Add(MPCF.Trim(crr_out.GetList(0)[i].GetString("LOT_ID")));
                            if (bGrade == true)
                            {
                                itmX.SubItems.Add(MPCF.Trim(crr_out.GetList(0)[i].GetChar("GRADE")));
                            }
                            else
                            {
                                itmX.SubItems.Add("");
                            }
                            itmX.SubItems.Add("");
                            itmX.Tag = crr_out.GetList(0)[i].GetDouble("QTY_2"); 
                            ((ListView)control).Items.Add(itmX);

                            iPrevSlotNo = iSlotNo;
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(crr_out.GetList(0)[i].GetString("SLOT_NO")) + " : " + MPCF.Trim(crr_out.GetList(0)[i].GetString("SUBLOT_ID")) + " : " + MPCF.Trim(crr_out.GetList(0)[i].GetString("LOT_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_CARRIER);
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
                            ((ComboBox)control).Items.Add(MPCF.Trim(crr_out.GetList(0)[i].GetString("SUBLOT_ID")));
                        }
                        iListCount++;
                    }

                    crr_in.SetInt("NEXT_SLOT_NO", crr_out.GetInt("NEXT_SLOT_NO"));

                } while (crr_out.GetInt("NEXT_SLOT_NO") != 0);


                if (control is ListView)
                {
                    for (j = iPrevSlotNo + 1; j <= iCrrSize; j++)
                    {
                        itmX = new ListViewItem(j.ToString(), (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                        itmX.SubItems.Add("");
                        itmX.SubItems.Add("");
                        itmX.SubItems.Add("");
                        itmX.SubItems.Add("");

                        ((ListView)control).Items.Add(itmX);
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // ViewCarrierHistory()
        //       - View Carrier History
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sCrrID As String                    : Carrier ID
        //        - Optional ByVal sFromTime As String = ""   : ?úÏûë ?úÍ∞Ñ
        //        - Optional ByVal sToTime As String = ""     : ÎßàÏ?Îß??úÍ∞Ñ
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú Ï∂îÍ???Node
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨ Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏ÏßÄ?
        //
        public static bool ViewCarrierHistory(Control control, char c_step, string sCrrID, string sFromTime, string sToTime, TreeNode parentNode, bool bIgnoreError)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;
            int iCol;

            TRSNode in_node = new TRSNode("VIEW_CARRIER_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_HISTORY_OUT");

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
            in_node.AddString("CRR_ID", sCrrID);
            in_node.AddString("FROM_TIME", sFromTime);
            in_node.AddString("TO_TIME", sToTime);
            in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Carrier_History_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                  

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        iCol = 0;

                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CODE"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_STATUS"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("SYS_TRAN_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("USAGE_COUNT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("CLEAN_COUNT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FACTORY"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_4"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_5"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("PORT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("NEED_CLEAN_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("FINISH_CLEAN_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_CLEAN_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("LOT_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_SLOT"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("MOVE_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("EMPTY_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("STOCK_IN_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_4"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_5"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_6"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_7"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_8"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_9"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_10"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_11"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_12"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_13"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_14"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_15"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_16"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_17"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_18"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_19"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_20"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT"));

                        iCol++;

                    }
                    else if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ")), (int)SMALLICON_INDEX.IDX_HISTORY);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CODE")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CODE")), (int)SMALLICON_INDEX.IDX_HISTORY, (int)SMALLICON_INDEX.IDX_HISTORY);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CODE")));
                    }
                }

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
            } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

            return true;

        }


        // ViewCarrierHistoryByLot()
        //       - View Carrier History
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sLotID As String                    : Lot ID
        //        - Optional ByVal sFromTime As String = ""   : ?úÏûë ?úÍ∞Ñ
        //        - Optional ByVal sToTime As String = ""     : ÎßàÏ?Îß??úÍ∞Ñ
        //       - Optional ByVal sIncludeDelHistory as string = ""  : Lot????†ú ?¥Î†•ÍπåÏ? ?¨Ìï®?†Ï? ?¨Î?
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú Ï∂îÍ???Node
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨ Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏ÏßÄ?
        //
        public static bool ViewCarrierHistoryByLot(Control control, char c_step, string sLotID, string sFromTime, string sToTime, char sIncludeDelHistory, TreeNode parentNode, bool bIgnoreError)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;
            int iCol;

            TRSNode in_node = new TRSNode("VIEW_CARRIER_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_HISTORY_OUT");

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
            in_node.AddString("LOT_ID", sLotID);
            in_node.AddString("FROM_TIME", sFromTime);
            in_node.AddString("TO_TIME", sToTime);
            in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDelHistory);
            in_node.AddString("NEXT_CRR_ID", "");
            in_node.AddInt("NEXT_HIST_SEQ", 0);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Carrier_History_List_By_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }
                    
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_HIST_DEL_FLAG")) == "Y")
                        {
                            sheetX.Rows[iRow].ForeColor = Color.Magenta;
                        }

                        iCol = 0;

                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("LOT_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_TRAN_CODE"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_MAT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("LOT_MAT_VER"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_FLOW"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("LOT_FLOW_SEQ_NUM"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_OPER"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("LOT_QTY_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("LOT_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("LOT_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_GROUP"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CODE"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_STATUS"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("USAGE_COUNT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("CLEAN_COUNT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FACTORY"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_4"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOCATION_5"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("PORT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("NEED_CLEAN_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("FINISH_CLEAN_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_CLEAN_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_SLOT"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("MOVE_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("EMPTY_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("STOCK_IN_TIME")));

                        iCol++;
                        //sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("PLAN_TERMINATE_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_4"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_5"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_6"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_7"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_8"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_9"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_10"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_11"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_12"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_13"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_14"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_15"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_16"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_17"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_18"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_19"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_20"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_HIST_DEL_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("SYS_TRAN_TIME")));

                        iCol++;

                    }
                    else if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetInt("LOT_HIST_SEQ")), (int)SMALLICON_INDEX.IDX_HISTORY);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetInt("LOT_HIST_SEQ")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")), (int)SMALLICON_INDEX.IDX_HISTORY, (int)SMALLICON_INDEX.IDX_HISTORY);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")));
                    }
                }
                in_node.SetString("NEXT_CRR_ID", out_node.GetString("NEXT_CRR_ID"));
                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
    
            } while (in_node.GetString("NEXT_CRR_ID") != "" || in_node.GetInt("NEXT_HIST_SEQ") > 0);

            return true;

        }


        //
        // ViewToolTypeList
        //       - View Tool Type List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewToolTypeList(Control control, char c_step, char sSystemFlag, char sDeleteFlag, TreeNode parentNode)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_TOOL_TYPE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_TYPE_LIST_OUT");

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
            in_node.AddChar("SYSTEM_FLAG", sSystemFlag);
            in_node.AddChar("DELETE_FLAG", sDeleteFlag);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Tool_Type_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        if (c_step == '1')
                        {
                            itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE")), (int)SMALLICON_INDEX.IDX_TOOL_TYPE);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE_DESC")));
                            }
                        }
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_TYPE, (int)SMALLICON_INDEX.IDX_TOOL_TYPE);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE")));
                    }

                }
                in_node.SetString("NEXT_TOOL_TYPE", out_node.GetString("NEXT_TOOL_TYPE"));
            } while (in_node.GetString("NEXT_TOOL_TYPE") != "");

            return true;
        }
        //
        // ViewToolTypeList
        //       - View Tool Type List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewToolTypeList(Control control, char c_step, char sSystemFlag, char sDeleteFlag, char rel_revel, string sMatID, int iMatVer, string sFlow, string sOper, TreeNode parentNode)
        {
            return ViewToolTypeList(control, c_step, sSystemFlag, sDeleteFlag, rel_revel, sMatID, iMatVer, sFlow, sOper, "", "", "", "", false, parentNode);
        }
        //
        // ViewToolTypeList
        //       - View Tool Type List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewToolTypeList(Control control, char c_step, char sSystemFlag, char sDeleteFlag, char rel_revel, string sResType, string sResGroup, string sResID, string sEventID, TreeNode parentNode)
        {
            return ViewToolTypeList(control, c_step, sSystemFlag, sDeleteFlag, rel_revel, "", 0, "", "", sResType, sResGroup, sResID, sEventID, true, parentNode);
        }
        //
        // ViewToolTypeList
        //       - View Tool Type List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        private static bool ViewToolTypeList(Control control, char c_step, char sSystemFlag, char sDeleteFlag, char rel_revel, string sMatID, int iMatVer, string sFlow, string sOper, string sResType, string sResGroup, string sResID, string sEventID, bool TrackingToolID, TreeNode parentNode)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_TOOL_TYPE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_TYPE_LIST_OUT");

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
            in_node.AddChar("SYSTEM_FLAG", sSystemFlag);
            in_node.AddChar("DELETE_FLAG", sDeleteFlag);
            in_node.AddChar("REL_LEVEL", rel_revel);
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("OPER", sOper);
            in_node.AddString("RES_TYPE", sResType);
            in_node.AddString("RESG_ID", sResGroup);
            in_node.AddString("RES_ID", sResID);
            in_node.AddString("EVENT_ID", sEventID);
            if (TrackingToolID == true)
            {
                in_node.AddString("TOOL_ID", "%");
            }

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Tool_Type_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE")), (int)SMALLICON_INDEX.IDX_TOOL_TYPE);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE_DESC")));
                        }
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_TYPE, (int)SMALLICON_INDEX.IDX_TOOL_TYPE);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE")));
                    }

                }
                in_node.SetString("NEXT_TOOL_TYPE", out_node.GetString("NEXT_TOOL_TYPE"));
            } while (in_node.GetString("NEXT_TOOL_TYPE") != "");

            return true;

        }



        // ViewToolEventList()
        //       - View Tool Event List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - ByVal sToolType As String                 : Tool Type
        //       - Optional ByVal sSystemFlag as String = "" : SystemFlag
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú Ï∂îÍ???Node
        //
        public static bool ViewToolEventList(Control control, char c_step, string sToolType, char sSystemflag, TreeNode parentNode)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_TOOL_EVENT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_EVENT_LIST_OUT");

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
            in_node.AddString("NEXT_TOOL_TYPE", sToolType);
            in_node.AddChar("SYSTEM_FLAG", sSystemflag);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Tool_Event_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")), (int)SMALLICON_INDEX.IDX_TOOL_EVENT);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_EVENT, (int)SMALLICON_INDEX.IDX_TOOL_EVENT);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")));

                    }
                }
                in_node.SetString("NEXT_TOOL_EVENT_ID", out_node.GetString("NEXT_TOOL_EVENT_ID"));

            } while (in_node.GetString("NEXT_TOOL_EVENT_ID") != "");

            return true;

        }

        // ViewToolEventList()
        //       - View Tool Event List by MFO/RAS-Releation
        // Return Value
        //       - boolean : True / False
        //
        public static bool ViewToolEventList(Control control, char c_step, char sSystemflag, string sToolType, string sToolID, char rel_revel, string sResType, string sResGroup, string sResID, string sEventID, TreeNode parentNode)
        {
            return ViewToolEventList(control, c_step, sSystemflag, sToolType, sToolID, rel_revel, "", 0, "", "", sResType, sResGroup, sResID, sEventID, parentNode);
        }

        // ViewToolEventList()
        //       - View Tool Event List by MFO/RAS-Releation
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private static bool ViewToolEventList(Control control, char c_step, char sSystemflag, string sToolType, string sToolID, char rel_revel, string sMatID, int iMatVer, string sFlow, string sOper, string sResType, string sResGroup, string sResID, string sEventID, TreeNode parentNode)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_TOOL_EVENT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_EVENT_LIST_OUT");

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
            in_node.AddChar("SYSTEM_FLAG", sSystemflag);
            in_node.AddString("TOOL_TYPE", sToolType);
            in_node.AddString("TOOL_ID", sToolID);
            in_node.AddChar("REL_LEVEL", rel_revel);
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("OPER", sOper);
            in_node.AddString("RES_TYPE", sResType);
            in_node.AddString("RESG_ID", sResGroup);
            in_node.AddString("RES_ID", sResID);
            in_node.AddString("EVENT_ID", sEventID);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Tool_Event_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")), (int)SMALLICON_INDEX.IDX_TOOL_EVENT);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_EVENT, (int)SMALLICON_INDEX.IDX_TOOL_EVENT);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")));

                    }
                }
                in_node.SetString("NEXT_TOOL_EVENT_ID", out_node.GetString("NEXT_TOOL_EVENT_ID"));

            } while (in_node.GetString("NEXT_TOOL_EVENT_ID") != "");

            return true;

        }

        //ViewToolList()
        //      - View Tool List
        //Return Value
        //      - boolean : True / False
        //Arguments
        //      - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //    - ByVal c_step As String                        : ?ïÏû• Process Step
        //    - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewToolList(Control control, char c_step, string sToolType, char sDeleteFlag, bool bExceptScrap, TreeNode parentNode)
        {

            int i;
            int j;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_TOOL_LIST_IN");
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
            in_node.AddString("NEXT_TOOL_TYPE", sToolType);
            in_node.AddChar("DELETE_FLAG", sDeleteFlag);

            do
            {
                out_node = new TRSNode("View_Tool_List_Out");

                if (MPCR.CallService("RAS", "RAS_View_Tool_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);
                
                in_node.SetString("NEXT_TOOL_TYPE", out_node.GetString("NEXT_TOOL_TYPE"));
                in_node.SetString("NEXT_TOOL_ID", out_node.GetString("NEXT_TOOL_ID"));

            } while (in_node.GetString("NEXT_TOOL_TYPE") != "" || in_node.GetString("NEXT_TOOL_ID") != "");

            for (j = 0; j < a_list.Count; j++)
            {
                out_node = (TRSNode)a_list[j];
              
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        if (bExceptScrap == false || MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) != "S")
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "")
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "S")
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL_SCRAP);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "R")
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL_RETURN);
                            }
                            else
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL);
                            }

                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                    }
                    else if (control is TreeView)
                    {
                        if (bExceptScrap == false || MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) != "S")
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "")
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL, (int)SMALLICON_INDEX.IDX_TOOL);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "S")
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_SCRAP, (int)SMALLICON_INDEX.IDX_TOOL_SCRAP);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "R")
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_RETURN, (int)SMALLICON_INDEX.IDX_TOOL_RETURN);
                            }
                            else
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL, (int)SMALLICON_INDEX.IDX_TOOL);
                            }
                            if (!(parentNode == null))
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)control).Nodes.Add(nodeX);
                            }
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")));

                    }

                }
            }

            return true;
        }

        //ViewToolList()
        //      - View Tool List
        //Return Value
        //      - boolean : True / False
        //Arguments
        //      - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //    - ByVal c_step As String                        : ?ïÏû• Process Step
        //    - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewToolList(Control control, char c_step, char sDeleteFlag, bool bExceptScrap, string sToolType, char rel_revel, string sResType, string sResGroup, string sResID, string sEventID, TreeNode parentNode)
        {

            int i;
            int j;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_TOOL_LIST_IN");
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
            in_node.AddString("TOOL_TYPE", sToolType);
            in_node.AddChar("DELETE_FLAG", sDeleteFlag);
            in_node.AddChar("REL_LEVEL", rel_revel);
            in_node.AddString("RES_TYPE", sResType);
            in_node.AddString("RESG_ID", sResGroup);
            in_node.AddString("RES_ID", sResID);
            in_node.AddString("EVENT_ID", sEventID);

            do
            {
                out_node = new TRSNode("View_Tool_List_Out");

                if (MPCR.CallService("RAS", "RAS_View_Tool_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_TOOL_ID", out_node.GetString("NEXT_TOOL_ID"));

            } while (in_node.GetString("NEXT_TOOL_ID") != "");

            for (j = 0; j < a_list.Count; j++)
            {
                out_node = (TRSNode)a_list[j];

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        if (bExceptScrap == false || MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) != "S")
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "")
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "S")
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL_SCRAP);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "R")
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL_RETURN);
                            }
                            else
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL);
                            }

                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                    }
                    else if (control is TreeView)
                    {
                        if (bExceptScrap == false || MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) != "S")
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "")
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL, (int)SMALLICON_INDEX.IDX_TOOL);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "S")
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_SCRAP, (int)SMALLICON_INDEX.IDX_TOOL_SCRAP);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "R")
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_RETURN, (int)SMALLICON_INDEX.IDX_TOOL_RETURN);
                            }
                            else
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL, (int)SMALLICON_INDEX.IDX_TOOL);
                            }
                            if (!(parentNode == null))
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)control).Nodes.Add(nodeX);
                            }
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")));

                    }

                }
            }

            return true;
        }

        // ViewToolList_Detail()
        //       - View Tool List (Detail)
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sToolID As String                    : Tool ID
        //       - Optional ByVal sToolType As String = ""   : Tool Type
        //       -    ByVal sToolGrp As String = ""          : Tool Group
        //       -    ByVal sToolSetID As String = ""        : Too Set ID
        //       -    ByVal sToolSts As String = ""          : Tool Status
        //       -    ByVal sLotID As String = ""            : Lot ID
        //       -    ByVal sSubLotID As String = ""         : SubLot ID
        //       -    ByVal sResID As String = ""            : Resource ID
        //       -    ByVal sSubResID As String = ""         : SubResource ID
        //       -    ByVal sMatID As String = ""            : Material
        //       -    ByVal sFlow As String = ""             : Flow
        //       -    ByVal sOper As String = ""             : Operation
        //       -    ByVal sArea As String = ""             : Area
        //       -    ByVal sSubArea As String = ""          : SubArea (Bay)
        //       -    ByVal sVendor As String = ""           : Vendor ID
        //       -    ByVal sGrade As String = ""            : Grade
        //       -    ByVal sDeleteFlag As String = ""       : Tool????†ú/?®Í∏∞/Î∞òÌíà ?¨Î?
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú Ï∂îÍ???Node
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨ Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏ÏßÄ?
        //
        public static bool ViewToolList_Detail(Control control, char c_step, string sToolType, string sToolGrp, string sToolSetID, string sToolSts, string sLotID, string sSubLotID, string sResID, string sSubResID, string sMatID, int iMatVer, string sFlow, string sOper, string sArea, string sSubArea, string sVendor, char sGrade, char sDeleteFlag, TreeNode parentNode, bool bIgnoreError)
        {

            ListViewItem itmX = null;
            TreeNode nodeX = null;
            FarPoint.Win.Spread.SheetView sheetX = new FarPoint.Win.Spread.SheetView();
            int i;
            int iRow;
            int iCol;
            int iToolIcon;
            int j;

            TRSNode in_node = new TRSNode("VIEW_TOOL_LIST_DETAIL_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_LIST_DETAIL_OUT");

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
            
            in_node.AddString("TOOL_TYPE", sToolType);
            in_node.AddString("TOOL_GRP", sToolGrp);
            in_node.AddString("TOOL_SET_ID", sToolSetID);
            in_node.AddString("TOOL_STATUS", sToolSts);
            in_node.AddString("LOT_ID", sLotID);
            in_node.AddString("SUBLOT_ID", sSubLotID);
            in_node.AddString("RES_ID", sResID);
            in_node.AddString("SUBRES_ID", sSubResID);
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("OPER", sOper);
            in_node.AddString("AREA_ID", sArea);
            in_node.AddString("SUB_AREA_ID", sSubArea);
            in_node.AddString("VENDOR_ID", sVendor);
            in_node.AddChar("GRADE", sGrade);
            in_node.AddChar("DELETE_FLAG", sDeleteFlag);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Tool_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }
                   
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iToolIcon = (int)SMALLICON_INDEX.IDX_TOOL;

                    if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        iCol = 0;

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "S")
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "R")
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Lime;
                        }
                        else
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_STATUS"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_GRP"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_SET_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_SET_LOCATION"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBLOT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPER"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("AREA_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUB_AREA_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_LOCATION"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VENDOR_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VENDOR_TOOL_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_COUNT_X")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_COUNT_Y")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_COUNT_Z"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_SIZE_X")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_SIZE_Y")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_SIZE_Z"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("GRADE"));

                        iCol++;

                        for (j = 0; j <= 29; j++)
                        {
                            sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetString("TOOL_STS"));

                            iCol++;
                        }

                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_TOOL_EVENT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_COMMENT"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME")));

                        iCol++;


                    }
                    else if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), iToolIcon);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_STATUS")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "")
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_STATUS")), (int)SMALLICON_INDEX.IDX_TOOL, (int)SMALLICON_INDEX.IDX_TOOL);
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "S")
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_STATUS")), (int)SMALLICON_INDEX.IDX_TOOL_SCRAP, (int)SMALLICON_INDEX.IDX_TOOL_SCRAP);
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "R")
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_STATUS")), (int)SMALLICON_INDEX.IDX_TOOL_RETURN, (int)SMALLICON_INDEX.IDX_TOOL_RETURN);
                        }
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")));
                    }
                }
                in_node.SetString("NEXT_TOOL_ID", out_node.GetString("NEXT_TOOL_ID"));

            } while (in_node.GetString("NEXT_TOOL_ID") != "");

            return true;

        }


        // ViewToolEventRelationList()
        //       - View Tool Event Relation List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sToolID As String                    : Tool ID
        //       - Optional ByVal sToolType As String = ""   : Tool Type
        //       - Optional ByVal sToolEventID As String = "": Tool Event ID
        //        - Optional ByVal sSystemFlag As String = "" : System Event Flag
        //        - Optional ByVal sDeleteFlag As String = "" : Deleted Tool Flag
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú Ï∂îÍ???Node
        //
        public static bool ViewToolEventRelationList(Control control, char c_step, string sToolID, string sToolType, string sToolEventID, char sSystemFlag, char sDeleteFlag, TreeNode parentNode)
        {

            int i;
            ListViewItem itmX = null;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_TOOL_EVENT_RELATION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_EVENT_RELATION_LIST_OUT");

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
            in_node.AddString("NEXT_TOOL_ID", sToolID);
            in_node.AddString("NEXT_TOOL_TYPE", sToolType);
            in_node.AddString("NEXT_TOOL_EVENT_ID", sToolEventID);
            in_node.AddChar("SYSTEM_FLAG", sSystemFlag);
            in_node.AddChar("DELETE_FLAG", sDeleteFlag);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Tool_Event_Relation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        if (c_step == '1' || c_step == '3')
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")), (int)SMALLICON_INDEX.IDX_TOOL_EVENT);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (c_step == '2')
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "")
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "S")
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL_SCRAP);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "R")
                            {
                                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL_RETURN);
                            }
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                    }
                    else if (control is TreeView)
                    {
                        if (c_step == '1' || c_step == '3')
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_EVENT, (int)SMALLICON_INDEX.IDX_TOOL_EVENT);
                            if (!(parentNode == null))
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)control).Nodes.Add(nodeX);
                            }
                        }
                        else if (c_step == '2')
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "")
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL, (int)SMALLICON_INDEX.IDX_TOOL);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "S")
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_SCRAP, (int)SMALLICON_INDEX.IDX_TOOL_SCRAP);
                            }
                            else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "R")
                            {
                                nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")), (int)SMALLICON_INDEX.IDX_TOOL_RETURN, (int)SMALLICON_INDEX.IDX_TOOL_RETURN);
                            }

                            if (!(parentNode == null))
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)control).Nodes.Add(nodeX);
                            }
                        }
                    }
                    else if (control is ComboBox)
                    {
                        if (c_step == '1' || c_step == '3')
                        {
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")));
                        }
                        else if (c_step == '2')
                        {
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")));
                        }

                    }
                }
                in_node.SetString("NEXT_TOOL_ID", out_node.GetString("NEXT_TOOL_ID"));
                in_node.SetString("NEXT_TOOL_TYPE", out_node.GetString("NEXT_TOOL_TYPE"));
                in_node.SetString("NEXT_TOOL_EVENT_ID", out_node.GetString("NEXT_TOOL_EVENT_ID"));

            } while (in_node.GetString("NEXT_TOOL_ID") != "" ||
                     in_node.GetString("NEXT_TOOL_TYPE") != "" ||
                     in_node.GetString("NEXT_TOOL_EVENT_ID") != "");

            return true;

        }


        // ViewToolHistory()
        //       - View Tool History
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sToolID As String                    : Tool ID
        //       - Optional ByVal sToolType As String = ""   : Tool Type
        //       - Optional ByVal sToolEventID As String = "": Tool Event ID
        //        - Optional ByVal sFromTime As String = ""   : ?úÏûë ?úÍ∞Ñ
        //        - Optional ByVal sToTime As String = ""     : ÎßàÏ?Îß??úÍ∞Ñ
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete HistoryÍπåÏ? ?¨Ìï®??Í≤ÉÏù∏ÏßÄ?
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú Ï∂îÍ???Node
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨ Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏ÏßÄ?
        //
        public static bool ViewToolHistory(Control control, char c_step, string sToolID, string sToolType, string sToolEventID, string sFromTime, string sToTime, char sIncludeDelHistory, TreeNode parentNode, bool bIgnoreError)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;
            int iCol;
            int iHistIcon;
            int j;

            TRSNode in_node = new TRSNode("VIEW_TOOL_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_HISTORY_OUT");

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
            in_node.AddString("TOOL_ID", sToolID);
            in_node.AddString("TOOL_TYPE", sToolType);
            in_node.AddString("TOOL_EVENT_ID", sToolEventID);
            in_node.AddString("FROM_TIME", sFromTime);
            in_node.AddString("TO_TIME", sToTime);
            in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDelHistory);
            in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Tool_History", in_node, ref out_node) == false)
                {
                    return false;
                }
                    

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG")) == "Y")
                    {
                        iHistIcon = (int)SMALLICON_INDEX.IDX_HISTORY_DELETE;
                    }
                    else
                    {
                        iHistIcon = (int)SMALLICON_INDEX.IDX_HISTORY;
                    }

                    if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        iCol = 0;

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG")) == "Y")
                        {
                            sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_STATUS"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_GRP"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_SET_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_SET_LOCATION"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBLOT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPER"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("AREA_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUB_AREA_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_LOCATION"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VENDOR_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VENDOR_TOOL_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_COUNT_X")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_COUNT_Y")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_COUNT_Z"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_SIZE_X")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_SIZE_Y")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_SIZE_Z"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("GRADE"));

                        iCol++;

                        for (j = 0; j <= 29; j++)
                        {
                            sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetString("TOOL_STS"));

                            iCol++;
                        }

                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("DEFECT_COLLECT_COUNT"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("DEFECT_CLEAN_COUNT"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("PREV_ACTIVE_HIST_SEQ"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_TIME")));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_USER_ID"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_COMMENT"));

                    }
                    else if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_SEQ")), iHistIcon);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")), (int)SMALLICON_INDEX.IDX_HISTORY, (int)SMALLICON_INDEX.IDX_HISTORY);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID")));
                    }
                }

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

            } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

            return true;

        }


        // ViewResourceGroupList()
        //      - View Resource Group List
        // Return Value
        //      - boolean : True / False
        // Arguments
        //      - Control control                    : List control
        //      - char c_step                        : Process Step
        //      - TreeNode parentNode               : Tree Node
        //      - string sExtFactory                : Extended Factory
        //
        public static bool ViewResourceGroupList(Control control, char c_step)
        {
            return ViewResourceGroupList(control, c_step, "", 0, "", "", "", "", null, "");
        }
        public static bool ViewResourceGroupList(Control control, char c_step, string s_res_id)
        {
            return ViewResourceGroupList(control, c_step, "", 0, "", "", s_res_id, "", null, "");
        }
        public static bool ViewResourceGroupList(Control control, char c_step, string s_res_id, string s_res_type)
        {
            return ViewResourceGroupList(control, c_step, "", 0, "", "", s_res_id, s_res_type, null, "");
        }
        public static bool ViewResourceGroupList(Control control, char c_step, string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            return ViewResourceGroupList(control, c_step, s_mat_id, i_mat_ver, s_flow, s_oper, "", "", null, "");
        }
        public static bool ViewResourceGroupList(Control control, char c_step, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_res_id, string s_res_type, TreeNode parentNode, string s_ext_factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_RESOURCE_GROUP_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_GROUP_LIST_OUT");

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
            in_node.AddString("RES_ID", s_res_id);
            in_node.AddString("RES_TYPE", s_res_type);

            in_node.AddString("NEXT_RESG_ID", "");

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Resource_Group_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RESG_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RESG_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("RESG_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("RESG_DESC")), (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP, (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
                        if (parentNode == null)
                        {
                            ((TreeView)control).Nodes.Add(nodeX);
                        }
                        else
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RESG_ID")));
                    }
                }

                in_node.SetString("NEXT_RESG_ID", out_node.GetString("NEXT_RESG_ID"));
            } while (in_node.GetString("NEXT_RESG_ID") != "");

            return true;
        }


        // ViewSheetQueryList()
        //      - View Sheet Query List
        // Return Value
        //      - boolean : True / False
        // Arguments
        //      - Control control                    : List control
        //      - char c_step                        : Process Step
        //      - TreeNode parentNode               : Tree Node
        //      - string sExtFactory                : Extended Factory
        //
        public static bool ViewSheetQueryList(Control control, char c_step, string data_type)
        {
            return ViewSheetQueryList(control, c_step, data_type, null, "");
        }
        public static bool ViewSheetQueryList(Control control, char c_step, string data_type, TreeNode parentNode, string s_ext_factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_SHEET_QUERY_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SHEET_QUERY_LIST_OUT");

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

            in_node.AddString("DATA_TYPE", data_type);
            in_node.AddString("NEXT_DATA_CODE", "");

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Sheet_Query_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_CODE")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_DATA")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_CODE")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_DATA")), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (parentNode == null)
                        {
                            ((TreeView)control).Nodes.Add(nodeX);
                        }
                        else
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_CODE")));
                    }
                }
                in_node.SetString("NEXT_DATA_CODE", out_node.GetString("NEXT_DATA_CODE"));
            } while (in_node.GetString("NEXT_DATA_CODE") != "");

            return true;
        }


        // ViewSheetList()
        //      - View Sheet List
        // Return Value
        //      - boolean : True / False
        // Arguments
        //      - Control control                    : List control
        //      - char c_step                        : Process Step
        //      - TreeNode parentNode               : Tree Node
        //      - string sExtFactory                : Extended Factory
        //
        public static bool ViewSheetList(Control control, char c_step, string sheet_type)
        {
            return ViewSheetList(control, c_step, sheet_type,
                                 "", "", "", "", "",
                                 "", "", "", "", "",
                                 null, "");
        }
        public static bool ViewSheetList(Control control, char c_step, string sheet_type,
                                         string sheet_grp_1, string sheet_grp_2, string sheet_grp_3, string sheet_grp_4, string sheet_grp_5,
                                         string sheet_grp_6, string sheet_grp_7, string sheet_grp_8, string sheet_grp_9, string sheet_grp_10)
        {
            return ViewSheetList(control, c_step, sheet_type,
                                 sheet_grp_1, sheet_grp_2, sheet_grp_3, sheet_grp_4, sheet_grp_5,
                                 sheet_grp_6, sheet_grp_7, sheet_grp_8, sheet_grp_9, sheet_grp_10,
                                 null, "");
        }
        public static bool ViewSheetList(Control control, char c_step, string sheet_type,
                                         string sheet_grp_1, string sheet_grp_2, string sheet_grp_3, string sheet_grp_4, string sheet_grp_5,
                                         string sheet_grp_6, string sheet_grp_7, string sheet_grp_8, string sheet_grp_9, string sheet_grp_10,
                                         TreeNode parentNode, string s_ext_factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_SHEET_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SHEET_LIST_OUT");

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

            in_node.AddString("SHEET_TYPE", sheet_type);
            in_node.AddString("SHEET_GRP_1", sheet_grp_1);
            in_node.AddString("SHEET_GRP_2", sheet_grp_2);
            in_node.AddString("SHEET_GRP_3", sheet_grp_3);
            in_node.AddString("SHEET_GRP_4", sheet_grp_4);
            in_node.AddString("SHEET_GRP_5", sheet_grp_5);
            in_node.AddString("SHEET_GRP_6", sheet_grp_6);
            in_node.AddString("SHEET_GRP_7", sheet_grp_7);
            in_node.AddString("SHEET_GRP_8", sheet_grp_8);
            in_node.AddString("SHEET_GRP_9", sheet_grp_9);
            in_node.AddString("SHEET_GRP_10", sheet_grp_10);
            in_node.AddString("NEXT_SHEET_NAME", "");

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Sheet_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_NAME")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            if (c_step == '1')
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_DESC")));
                            else if (c_step == '2') 
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_TYPE")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_NAME")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_DESC")), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (parentNode == null)
                        {
                            ((TreeView)control).Nodes.Add(nodeX);
                        }
                        else
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_NAME")));
                    }
                }
                in_node.SetString("NEXT_SHEET_NAME", out_node.GetString("NEXT_SHEET_NAME"));
            } while (in_node.GetString("NEXT_SHEET_NAME") != "");

            return true;
        }
        // ViewCarrierEventList()
        //       - View Carrier Event List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - ByVal sCarrierType As String                 : Carrier Type
        //       - Optional ByVal sSystemFlag as String = "" : SystemFlag
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú Ï∂îÍ???Node
        //
        public static bool ViewCarrierEventList(Control control, char c_step, TreeNode parentNode)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_CRR_EVENT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CRR_EVENT_LIST_OUT");

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

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Carrier_Event_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_EVENT_ID")), (int)SMALLICON_INDEX.IDX_EVENT);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_EVENT_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_EVENT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_EVENT_DESC")), (int)SMALLICON_INDEX.IDX_EVENT, (int)SMALLICON_INDEX.IDX_EVENT);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_EVENT_ID")));

                    }
                }
                in_node.SetString("NEXT_CRR_EVENT_ID", out_node.GetString("NEXT_CRR_EVENT_ID"));

            } while (in_node.GetString("NEXT_CRR_EVENT_ID") != "");

            return true;

        }
        // ViewResourceTypeList()
        //       - View all Sub Resource List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control					    : ListView or TreeView control
        //		 - ByVal c_step As String						: Process Step
        //       - ByVal sMatID As String                       : Material ID
        //       - ByVal sMatVer As integer                     : Material Version
        //       - ByVal sFlow As String                        : Flow
        //       - ByVal sOper As String                        : Operation
        //       - Optional ByVal sResouceType As String = ""   : Resource Type
        //		 - Optional ByVal sFilter As String = ""		: sFilterÎ°??úÏûë?òÎäî Resource
        //		 - Optional ByVal sTreeItem As String = ""	    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //		 - Optional ByVal sExt_Factory As String = ""   : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        /* 2013.06.12. Aiden. ±‚¥… √ﬂ∞° */
        public static bool ViewResourceTypeList(Control control, char c_step, string sMatID, int sMatVer, string sFlow, string sOper, TreeNode parent)
        {
            int i_temp = 0;
            return ViewResourceTypeList(control, c_step, sMatID, sMatVer, sFlow, sOper, "", parent, ref i_temp);
        }

        public static bool ViewResourceTypeList(Control control,
                                                char c_step,
                                                string sMatID,
                                                int sMatVer,
                                                string sFlow,
                                                string sOper,
                                                string sExtFactory,
                                                TreeNode parentNode,
                                                ref int iListCount)
        {

            int i;

            ListViewItem itmX;
            TreeNode nodeX;


            TRSNode in_node = new TRSNode("VIEW_RECOURCE_TYPE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RECOURCE_TYPE_LIST_OUT");

            MPCR.SetInMsg(in_node);

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            in_node.ProcStep = c_step;
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", sMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("OPER", sOper);
            in_node.AddString("NEXT_REST_ID", "");

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Resource_Type_List", in_node, ref out_node) == false)
                {
                    return false;
                }



                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("REST_ID")), (int)SMALLICON_INDEX.IDX_VERSION);

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("REST_DESC")));
                        }
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("REST_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("REST_DESC")), (int)SMALLICON_INDEX.IDX_VERSION, (int)SMALLICON_INDEX.IDX_VERSION);

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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("REST_ID")));
                    }
                    iListCount++;

                }

                in_node.SetString("NEXT_REST_ID", out_node.GetString("NEXT_REST_ID"));
            } while (string.IsNullOrEmpty(out_node.GetString("NEXT_REST_ID")) == false);

            return true;

        }

        // View Resource List for Recipe : Added for QCELLS
        public static bool ViewResourceListForRecipe(Control control, char c_step)
        {
            int i;
            int j;
            ListViewItem itmX;
            //TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
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

            in_node.AddString("LINE_ID", "MDL01");

            //do
            //{
            out_node = new TRSNode("VIEW_RESOURCE_LIST_OUT");

            if (MPCR.CallService("CRAS", "CRAS_View_Resource_List_By_Line", in_node, ref out_node) == false)
            {
                return false;
            }

            a_list.Add(out_node);
            //in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
            //} while (in_node.GetString("NEXT_RES_ID") != "");

            for (j = 0; j < a_list.Count; j++)
            {
                out_node = null;
                out_node = (TRSNode)a_list[j];

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_UP_FLAG)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                        }
                        else if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == MPGC.MP_RES_DOWN_FLAG)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN);
                        }
                        else
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                        }
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Magenta;
                        }
                    }
                }
            }


            return true;
        }


    
    }
}
