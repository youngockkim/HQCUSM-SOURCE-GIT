
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
//   File Name   : modRTDListRoutine.vb
//   Description : Client Common List function RTD Module
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
//#If _RTD = True Then

namespace Miracom.MESCore
{
    public sealed class RTDLIST
    {

        #region "RTD Sorting Column"
        private const int MP_RTD_RES_SCORE_COL = 11;
        private const int MP_RTD_LOT_SCORE_COL = 19;
        #endregion
        
        // ViewDispatcherList()
        //       - View All Dispatcher List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewDispatcherList(Control control, char c_step, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_DISPATCHER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCHER_LIST_OUT");

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
            else
            {
                in_node.Factory = MPGV.gsFactory;
            }

            in_node.AddString("NEXT_DSP_ID", "");

            do
            {
                if (MPCR.CallService("RTD", "RTD_View_Dispatcher_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("DSP_ID")), (int)SMALLICON_INDEX.IDX_DISPATCHER);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DSP_DESC")));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("DSP_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("DSP_DESC")), (int)SMALLICON_INDEX.IDX_DISPATCHER, (int)SMALLICON_INDEX.IDX_DISPATCHER);
                        nodeX.Tag = MPCF.Trim(out_node.GetList(0)[i].GetChar("RES_OR_OPER"));
                        if (!(parentNode == null))
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            ((TreeView) control).Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DSP_ID")));
                    }
                }

                in_node.SetString("NEXT_DSP_ID", out_node.GetString("NEXT_DSP_ID"));

            } while (in_node.GetString("NEXT_DSP_ID") != "");

            return true;

        }

        
        // ViewDspResList()
        //       - View Dispatcher - Resource List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewDspResList(Control control, char c_step, string sDspID, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_DSPRES_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DSPRES_LIST_OUT");

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
            else
            {
                in_node.Factory = MPGV.gsFactory;
            }

            in_node.AddString("NEXT_DSP_ID", sDspID);
            in_node.AddString("NEXT_RES_ID", "");

            do
            {
                if (MPCR.CallService("RTD", "RTD_View_DspRes_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count- 1; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), (int)SMALLICON_INDEX.IDX_RESOURCE);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        if (!(parentNode == null))
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            ((TreeView) control).Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox) control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                    }
                }                
                in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));

            } while (in_node.GetString("NEXT_RES_ID") != "");
            return true;

        }

        
        // ViewDspOperList()
        //       - View Dispatcher - Operation List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewDspOperList(Control control, char c_step, string sDspID, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_DSPOPER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DSPOPER_LIST_OUT");

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
            else
            {
                in_node.Factory = MPGV.gsFactory;
            }

            in_node.AddString("NEXT_DSP_ID", sDspID);
            in_node.AddString("NEXT_OPER", "");

            do
            {
                if (MPCR.CallService("RTD", "RTD_View_DspOper_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count- 1; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")), (int)SMALLICON_INDEX.IDX_OPER);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC")));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC")), (int)SMALLICON_INDEX.IDX_OPER, (int)SMALLICON_INDEX.IDX_OPER);
                        if (!(parentNode == null))
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            ((TreeView) control).Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox) control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                    }
                }
                 in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));

            } while (in_node.GetString("NEXT_OPER") != "");
               

            return true;

        }


        // ViewRuleList()
        //       - View Dispatcher - Operation List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewRuleItemList(Control control, char c_step, string sRuleID, char sRuleType, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_RULE_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RULE_ITEM_LIST_OUT");

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
            else
            {
                in_node.Factory = MPGV.gsFactory;
            }

            in_node.AddString("RULE_ID", sRuleID);
            in_node.AddChar("RULE_TYPE", sRuleType);
            in_node.AddInt("NEXT_KEY_POINT", int.MaxValue);
            in_node.AddInt("NEXT_PRIO_LEVEL", 0);

            do
            {
                if (MPCR.CallService("RTD", "RTD_View_Rule_Item_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count- 1; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetInt("PRIO_LEVEL")), (int)SMALLICON_INDEX.IDX_HISTORY);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("CLASS_TYPE")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("SORTING_TYPE")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PRIO_KEY")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_VALUE_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_VALUE_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("KEY_POINT")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("UNSELECT_FLAG")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_TYPE")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("CAPABLE_FLAG")));
                            /* 150722 Added By YJJung Description for Rule Item is added */
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_ITEM_DESC")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("OPERATOR")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                            /* Added End */
                            
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetInt("PRIO_LEVEL")));
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("PRIO_LEVEL")));
                    }
                }
                in_node.SetInt("NEXT_KEY_POINT", out_node.GetInt("NEXT_KEY_POINT"));
                in_node.SetInt("NEXT_PRIO_LEVEL", out_node.GetInt("NEXT_PRIO_LEVEL"));

            } while (in_node.GetInt("NEXT_KEY_POINT") > 0 || in_node.GetInt("NEXT_PRIO_LEVEL") > 0);
               
            return true;

        }

        
        public static bool ViewDspLotSimulation(Control control, char c_step, string sDspId, string sResID)
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("GET_LOT_LIST_DETAIL_IN");
            TRSNode out_node = new TRSNode("GET_LOT_LIST_DETAIL_OUT");

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
 
            in_node.AddString("DSP_ID", sDspId);
            in_node.AddString("RES_ID", sResID);
            in_node.AddString("NEXT_LOT_ID", "");
            in_node.AddString("NEXT_OPER", "");
            in_node.AddInt("NEXT_COUNT", 0);


            do
            {
                if (MPCR.CallService("RTD", "RTD_Get_Lot_Simulation_Result", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count- 1; i++)
                {
                    if (control is ListView)
                    {

                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));

                        itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1")));
                        itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2")));
                        itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3")));

                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_TYPE")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("OWNER_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_PRIORITY")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_STATUS")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RESERVE_RES_ID")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("OPER_IN_TIME")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PRIORITY_SCORE")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("UNSELECT_FLAG")));

                        //Add by J.S. 2009.03.17
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("CAPABLE_FLAG")));

                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DSP_REASON")));

                        //Add by J.S. 2009.03.17
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("UNSELECT_REASON")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CAPABLE_REASON")));

                        //Add by J.S. 2009.03.17
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_1")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_2")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_3")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_4")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_5")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_6")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_7")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_8")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_9")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_10")));

                        if (out_node.GetList(0)[i].GetChar("UNSELECT_FLAG") == 'Y' || out_node.GetList(0)[i].GetChar("CAPABLE_FLAG") == 'N')
                        {
                            itmX.ForeColor = Color.Red;
                        }

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
                            itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT;
                        }

                        ((ListView) control).Items.Add(itmX);
                    }
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));
                in_node.SetInt("NEXT_COUNT", out_node.GetInt("NEXT_COUNT"));

            } while (in_node.GetString("NEXT_LOT_ID") != "" || in_node.GetString("NEXT_OPER") != "");

            if (control is ListView)
            {
                ((ListView)control).ListViewItemSorter = new Miracom.CliFrx.ListViewItemComparer(MP_RTD_LOT_SCORE_COL, SortOrder.Descending, Miracom.CliFrx.ListViewItemComparer.SORTING_OPTION.STRING_TYPE);
                ((ListView) control).Sort();
            }

            return true;

        }


        public static bool ViewDspResSimulation(Control control, char c_step, string s_dsp_id, string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("RTD_GET_RES_LIST_DETAIL_IN");
            TRSNode out_node = new TRSNode("RTD_GET_RES_LIST_DETAIL_OUT");

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
  
            in_node.AddString("DSP_ID", s_dsp_id);
            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);
            in_node.AddString("NEXT_RES_ID", "");
            in_node.AddInt("NEXT_COUNT", 0);


            do
            {
                if (MPCR.CallService("RTD", "RTD_Get_Resource_Simulation_Result", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count- 1; i++)
                {
                    if (control is ListView)
                    {

                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_TYPE")));
                        if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == 'U')
                        {
                            itmX.SubItems.Add("UP");
                        }
                        else if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == 'D')
                        {
                            itmX.SubItems.Add("DOWN");
                        }
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_PRI_STS")));

                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("AREA_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SUB_AREA_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_EVENT_ID")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_EVENT_TIME")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_START_TIME")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_END_TIME")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PRIORITY_SCORE")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("UNSELECT_FLAG")));

                        //Add by J.S. 2009.03.17
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("CAPABLE_FLAG")));

                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DSP_REASON")));

                        //Add by J.S. 2009.03.17
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("UNSELECT_REASON")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CAPABLE_REASON")));

                        //Add by J.S. 2009.03.17
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_1")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_2")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_3")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_4")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_5")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_6")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_7")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_8")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_9")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_10")));


                        if (out_node.GetList(0)[i].GetChar("UNSELECT_FLAG") == 'Y' || out_node.GetList(0)[i].GetChar("CAPABLE_FLAG") == 'N')
                        {
                            itmX.ForeColor = Color.Red;
                        }
                        
                        if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == 'U')
                        {
                            itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_RESOURCE;
                        }
                        else if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == 'D')
                        {
                            itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN;
                        }
                        else if (out_node.GetList(0)[i].GetString("RES_PRI_STS") == "PROC")
                        {
                            itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_RESOURCE_PROC;
                        }

                        ((ListView) control).Items.Add(itmX);
                    }
                }
                in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
                in_node.SetInt("NEXT_COUNT", out_node.GetInt("NEXT_COUNT"));

            } while (in_node.GetString("NEXT_RES_ID") != "" );
        
            if (control is ListView)
            {
                ((ListView)control).ListViewItemSorter = new Miracom.CliFrx.ListViewItemComparer(MP_RTD_RES_SCORE_COL, SortOrder.Descending, Miracom.CliFrx.ListViewItemComparer.SORTING_OPTION.STRING_TYPE);
                ((ListView) control).Sort();
            }

            return true;

        }


        public static bool ViewResourcePriSts(Control control, char c_step)
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("CMN_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_PRISTS_OUT");

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
 
            if (MPCR.CallService("RTD", "RTD_View_Resource_PriSts", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i <= out_node.GetList(0).Count- 1; i++)
            {
                if (control is ListView)
                {

                    itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_PRI_STS")), (int)SMALLICON_INDEX.IDX_CODE_DATA);

                    ((ListView)control).Items.Add(itmX);
                }
            }

            return true;

        }

        
        // ViewRuleList()
        //       - View All Rule List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                        : 
        //        - ByVal c_step As String                        : 
        //        - Optional ByVal sTreeItem As String = ""        : 
        //        - Optional ByVal sExt_Factory As String = ""    : 
        //
        public static bool ViewRuleList(Control control, char c_step, TreeNode parentNode, string sExtFactory, char cRuleType)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_RULE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RULE_LIST_OUT");

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
            else
            {
                in_node.Factory = MPGV.gsFactory;
            }

            in_node.AddChar("RULE_TYPE", cRuleType);
            in_node.AddString("NEXT_RULE_ID", "");

            do
            {
                if (MPCR.CallService("RTD", "RTD_View_Rule_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count- 1; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_ID")), (int)SMALLICON_INDEX.IDX_DISPATCHER);
                        if (((ListView) control).Columns.Count == 2)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_DESC")));
                        }
                        else if (((ListView)control).Columns.Count == 3)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("RULE_TYPE")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_DESC")));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_DESC")), (int)SMALLICON_INDEX.IDX_DISPATCHER, (int)SMALLICON_INDEX.IDX_DISPATCHER);
                        nodeX.Tag = MPCF.Trim(out_node.GetList(0)[i].GetChar("RULE_TYPE"));
                        if (!(parentNode == null))
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            ((TreeView) control).Nodes.Add(nodeX);
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_ID")));
                    }
                }
                 in_node.SetString("NEXT_RULE_ID", out_node.GetString("NEXT_RULE_ID"));
                
            } while (in_node.GetString("NEXT_RULE_ID") != "" );
               
            return true;

        }

        // ViewDispatcherList()
        //       - View All Dispatcher List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewDispatcherEventList(Control control, char c_step, TreeNode parentNode, string sExtFactory, string s_service_name)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_DISPATCHER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCHER_LIST_OUT");

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
            else
            {
                in_node.Factory = MPGV.gsFactory;
            }

            in_node.AddString("NEXT_SERVICE_NAME", "");
            in_node.AddInt("NEXT_SERVICE_SEQ", 0);
            if (c_step == '2')
            {
                in_node.SetString("NEXT_SERVICE_NAME", s_service_name);
            }
            

            do
            {
                if (MPCR.CallService("RTD", "RTD_View_Dispatcher_Event_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                {
                    if (control is ListView)
                    {
                        if (c_step == '2')
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetInt("SERVICE_SEQ")), (int)SMALLICON_INDEX.IDX_DISPATCHER);
                        }
                        else
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_NAME")), (int)SMALLICON_INDEX.IDX_DISPATCHER);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("SERVICE_SEQ")));
                            }
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_NAME")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetInt("SERVICE_SEQ")), (int)SMALLICON_INDEX.IDX_DISPATCHER, (int)SMALLICON_INDEX.IDX_DISPATCHER);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_NAME")));
                    }
                }

                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
                in_node.SetInt("NEXT_SERVICE_SEQ", out_node.GetInt("NEXT_SERVICE_SEQ"));

            } while (in_node.GetString("NEXT_SERVICE_NAME") != "" || in_node.GetInt("NEXT_SERVICE_SEQ") != 0);

            return true;

        }

        // ViewDispatcherEventHistory()
        //       - View All Dispatcher List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewDispatcherEventHistory(Control control, char c_step, string s_from_time, string s_to_time, string s_lot, string s_res)
        {

            int i;
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;
            int iCol;

            TRSNode in_node = new TRSNode("VIEW_DISPATCHER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCHER_LIST_OUT");


            sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;

            MPCF.ClearList(control); 

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddString("FROM_TRAN_TIME", s_from_time);
            in_node.AddString("TO_TRAN_TIME", s_to_time);
            in_node.AddString("LOT_ID", s_lot);
            in_node.AddString("RES_ID", s_res);
            in_node.AddInt("NEXT_EVENT_SEQ", int.MaxValue);
            
            do
            {
                if (MPCR.CallService("RTD", "RTD_View_Dispatcher_Event_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                {
                    iCol = 0;

                    iRow = sheetX.RowCount;
                    sheetX.RowCount++;

                    sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat( out_node.GetList(0)[i].GetString("TRAN_TIME"));
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CODE");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CHANGE_MEMBER");
                    iCol++;
                    
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("BATCH_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("DSP_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RULE_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RESG_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_TYPE");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ETC_TYPE");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ETC_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CUSTOM_ACTION_KEY");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("UNSELECT_CAPABLE_ONLY_FLAG");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                                       
                }

                in_node.SetInt("NEXT_EVENT_SEQ", out_node.GetInt("NEXT_EVENT_SEQ"));

            } while (in_node.GetInt("NEXT_EVENT_SEQ") != 0);

            return true;

        }

        // ViewDispatcherList()
        //       - View All Dispatcher List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewPreDispatchedHistory(Control control, char c_step, string s_from_time, string s_to_time, string s_lot_id)
        {

            int i;
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;
            int iCol;

            TRSNode in_node = new TRSNode("VIEW_DISPATCHER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCHER_LIST_OUT");


            sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;

            MPCF.ClearList(control);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddString("FROM_TRAN_TIME", s_from_time);
            in_node.AddString("TO_TRAN_TIME", s_to_time);
            in_node.AddString("LOT_ID", s_lot_id);
            in_node.AddInt("NEXT_ROW_SEQ", 0);

            do
            {
                if (MPCR.CallService("RTD", "RTD_View_Pre_Dispatched_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                {
                    iCol = 0;

                    iRow = sheetX.RowCount;
                    sheetX.RowCount++;

                    sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("RES_OPER_FLAG");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_OPER_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SET_OPER");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SET_RESG_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SET_RES_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("DSP_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RULE_ID");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TEMP_BATCH_ID");
                    iCol++;

                    //Add by J.S. 2009.0.19
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("TEMP_BATCH_SEQ");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CUR_OPER");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("REFERENCE_OPER");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("UNSELECTED_FLAG");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_RESV_FLAG");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOT_RESV_TIME"));
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("CAPABLE_FLAG");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("PRI_ADJUST_FLAG");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PRIORITY_SCORE");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PRI_ADJUST_REASON");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRIGGER_BY");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("DSP_REASON");
                    iCol++;

                    //Add by J.S. 2009.01.19
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("UNSELECT_REASON");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CAPABLE_REASON");
                    iCol++;

                    //Add by J.S. 2009.03.17
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_1");
                    iCol++;
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_2");
                    iCol++;
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_3");
                    iCol++;
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_4");
                    iCol++;
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_5");
                    iCol++;
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_6");
                    iCol++;
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_7");
                    iCol++;
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_8");
                    iCol++;
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_9");
                    iCol++;
                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDS_CMF_10");
                    iCol++;

                    sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");

                }

                in_node.SetInt("NEXT_ROW_SEQ", out_node.GetInt("NEXT_ROW_SEQ"));

            } while (in_node.GetInt("NEXT_ROW_SEQ") != 0);

            return true;

        }

        // ViewDispatcherList()
        //       - View All Dispatcher List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewPreDispatchedStatus(Control control, char c_step, char c_res_oper_flag, string s_res_oper_id)
        {

            int i;
            int iRow = 0;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_DISPATCHER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCHER_LIST_OUT");
       
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

            in_node.AddString("RES_OPER_ID", s_res_oper_id);
            in_node.AddChar("RES_OPER_FLAG", c_res_oper_flag);
            in_node.AddInt("NEXT_INDEX", 0);
                        
            do
            {
               
                    if (MPCR.CallService("RTD", "RTD_View_Pre_Dispatched_Status", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                    {
                        iRow += 1;
                        itmX = new ListViewItem(iRow.ToString(), (int)SMALLICON_INDEX.IDX_LOT);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SET_OPER")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SET_RESG_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SET_RES_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DSP_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TEMP_BATCH_ID")));
                        //Add by J.S. 2009.01.19
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("TEMP_BATCH_SEQ").ToString());

                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CUR_OPER")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("REFERENCE_OPER")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("UNSELECTED_FLAG")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_RESV_FLAG")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOT_RESV_TIME")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("CAPABLE_FLAG")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("PRI_ADJUST_FLAG")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PRIORITY_SCORE")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PRI_ADJUST_REASON")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TRIGGER_BY")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DSP_REASON")));
                        //Add by J.S. 2009.01.19
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("UNSELECT_REASON")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CAPABLE_REASON")));

                        //Add by J.S. 2009.03.16
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_1")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_2")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_3")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_4")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_5")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_6")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_7")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_8")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_9")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PDS_CMF_10")));

                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID")));
                                              
                        if (out_node.GetList(0)[i].GetChar("PRI_ADJUST_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Blue;
                        }
                        if (out_node.GetList(0)[i].GetChar("UNSELECTED_FLAG") == 'Y' || out_node.GetList(0)[i].GetChar("CAPABLE_FLAG") == 'N')
                        {
                            itmX.ForeColor = Color.Red;
                        }
                        ((ListView)control).Items.Add(itmX);



                    }
                    in_node.SetInt("NEXT_INDEX", out_node.GetInt("NEXT_INDEX"));

                } while (in_node.GetInt("NEXT_INDEX") != 0);
                     

            return true;

        }

         public static bool ViewDispatchedLotList(Control control, char c_step, char c_res_oper_flag, 
                                                    string s_res_oper_id, int i_max_count, bool bUnselet, bool bUncapable,
                                                    bool bReserve, bool bStart, bool bZeroQty)
        {

            int i, j;
      
            TRSNode in_node = new TRSNode("VIEW_DISPATCHER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCHER_LIST_OUT");
      
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

            in_node.AddString("RES_OPER_ID", s_res_oper_id);
            in_node.AddChar("RES_OPER_FLAG", c_res_oper_flag);
            in_node.AddInt("MAX_COUNT", i_max_count);

            if (bUnselet == true)
                in_node.AddChar("INCLUDE_UNSELECT", 'Y');
            else
                in_node.AddChar("INCLUDE_UNSELECT", 'N');

            if (bUncapable == true)
                in_node.AddChar("INCLUDE_UNCAPABLE", 'Y');
            else
                in_node.AddChar("INCLUDE_UNCAPABLE", 'N');

            if (bReserve == true)
                in_node.AddChar("INCLUDE_RESERVE", 'Y');
            else
                in_node.AddChar("INCLUDE_RESERVE", 'N');

            if (bStart == true)
                in_node.AddChar("INCLUDE_START", 'Y');
            else
                in_node.AddChar("INCLUDE_START", 'N');
            // Added by YJJung 130312 Qty1¿Ã 0¿Œ Lot¿ª ∫∏ø©¡÷¥¬ ø…º« √ﬂ∞°
            if (bZeroQty == true)
                in_node.AddChar("INCLUDE_ZERO_QTY", 'Y');
            else
                in_node.AddChar("INCLUDE_ZERO_QTY", 'N');
            
            in_node.AddInt("NEXT_INDEX", 0);

            MPCR.ViewFlexibleHeader(control, "RTD_View_Dispatched_Lot_List", MPGV.gsUserID, "", "LIST");
            
            do
            {
                MPCR.ViewServiceResult(control, in_node, ref out_node, "RTD", "RTD_View_Dispatched_Lot_List", (int)SMALLICON_INDEX.IDX_LOT);
                
                in_node.SetInt("NEXT_INDEX", out_node.GetInt("NEXT_INDEX"));

            } while (in_node.GetInt("NEXT_INDEX") != 0);


            for (i = 0; i < ((ListView)control).Columns.Count; i++)
            {
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "PRI_ADJUST_FLAG") 
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {                    
                        if (((ListView)control).Items[j].SubItems[i].Text == "Y")
                        {
                            ((ListView)control).Items[j].ForeColor = Color.Blue;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "UNSELECTED_FLAG" )
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "Y")
                        {
                            ((ListView)control).Items[j].ForeColor = Color.Red;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "CAPABLE_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "N")
                        {
                            ((ListView)control).Items[j].ForeColor = Color.Red;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "HOLD_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "Y")
                        {
                            ((ListView)control).Items[j].ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "START_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "Y")
                        {
                            ((ListView)control).Items[j].ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_START;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "RWK_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "Y")
                        {
                            ((ListView)control).Items[j].ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "NSTD_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "Y")
                        {
                            ((ListView)control).Items[j].ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "LAST_TRAN_CODE")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == MPGC.MP_TRAN_CODE_RELEASE)
                        {
                            ((ListView)control).Items[j].ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "REP_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "Y")
                        {
                            ((ListView)control).Items[j].ImageIndex = (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                        }
                    }
                }                  

            }
           
            return true;

        }

        public static bool ViewDispatchedResourceList(Control control, char c_step, string s_lot, bool bUnselet, bool bUncapable)
        {

            int i, j;
            int i_score_col = -1;
          
            TRSNode in_node = new TRSNode("RTD_GET_RES_LIST_DETAIL_IN");
            TRSNode out_node = new TRSNode("RTD_GET_RES_LIST_DETAIL_OUT");

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

            in_node.AddString("LOT_ID", s_lot);

            if (bUnselet == true)
                in_node.AddChar("INCLUDE_UNSELECT", 'Y');
            else
                in_node.AddChar("INCLUDE_UNSELECT", 'N');

            if (bUncapable == true)
                in_node.AddChar("INCLUDE_UNCAPABLE", 'Y');
            else
                in_node.AddChar("INCLUDE_UNCAPABLE", 'N');

            in_node.AddString("NEXT_RES_ID", "");

            MPCR.ViewFlexibleHeader(control, "RTD_View_Dispatched_Resource_List", MPGV.gsUserID, "", "RES_LIST");

            do
            {
                MPCR.ViewServiceResult(control, in_node, ref out_node, "RTD", "RTD_View_Dispatched_Resource_List", (int)SMALLICON_INDEX.IDX_RESOURCE);
                
                in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
                in_node.SetInt("NEXT_COUNT", out_node.GetInt("NEXT_COUNT"));

            } while (in_node.GetString("NEXT_RES_ID") != "");

            for (i = 0; i < ((ListView)control).Columns.Count; i++)
            {
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "UNSELECTED_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "Y")
                        {
                            ((ListView)control).Items[j].ForeColor = Color.Red;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "CAPABLE_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "N")
                        {
                            ((ListView)control).Items[j].ForeColor = Color.Red;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "RES_UP_DOWN_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "U")
                        {
                            ((ListView)control).Items[j].ImageIndex = (int)SMALLICON_INDEX.IDX_RESOURCE;
                        }
                        else if (((ListView)control).Items[j].SubItems[i].Text == "D")
                        {
                            ((ListView)control).Items[j].ImageIndex = (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "RES_PRI_STS")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "PROC")
                        {
                            ((ListView)control).Items[j].ImageIndex = (int)SMALLICON_INDEX.IDX_RESOURCE_PROC;
                        }
                    }
                }
                if (i_score_col == -1)
                {
                    if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "PRIORITY_SCORE")
                    {
                        i_score_col = i;
                    }
                }
            }
            if (i_score_col != -1)
            {
                if (control is ListView)
                {
                    ((ListView)control).ListViewItemSorter = new Miracom.CliFrx.ListViewItemComparer(i_score_col, SortOrder.Descending, Miracom.CliFrx.ListViewItemComparer.SORTING_OPTION.STRING_TYPE);
                    ((ListView)control).Sort();
                }
            }

            return true;

        }
        public static bool ViewDispatchedPortList(Control control, char c_step, string s_resource, string s_port, bool bUnselet, bool bUncapable)
        {

            int i, j;
            int i_score_col = -1;

            TRSNode in_node = new TRSNode("RTD_GET_PORT_LIST_DETAIL_IN");
            TRSNode out_node = new TRSNode("RTD_GET_PORT_LIST_DETAIL_OUT");

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
            in_node.AddString("RES_ID", s_resource);
            in_node.AddString("PORT_ID", s_port);

            if (bUnselet == true)
                in_node.AddChar("INCLUDE_UNSELECT", 'Y');
            else
                in_node.AddChar("INCLUDE_UNSELECT", 'N');

            if (bUncapable == true)
                in_node.AddChar("INCLUDE_UNCAPABLE", 'Y');
            else
                in_node.AddChar("INCLUDE_UNCAPABLE", 'N');

            in_node.AddString("NEXT_PORT_ID", "");

            MPCR.ViewFlexibleHeader(control, "RTD_View_Dispatched_Port_List", MPGV.gsUserID, "", "PORT_LIST");

            do
            {
                MPCR.ViewServiceResult(control, in_node, ref out_node, "RTD", "RTD_View_Dispatched_Port_List", (int)SMALLICON_INDEX.IDX_PORT);

                in_node.SetString("NEXT_PORT_ID", out_node.GetString("NEXT_PORT_ID"));
                in_node.SetInt("NEXT_COUNT", out_node.GetInt("NEXT_COUNT"));

            } while (in_node.GetString("NEXT_PORT_ID") != "");

            for (i = 0; i < ((ListView)control).Columns.Count; i++)
            {
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "UNSELECTED_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "Y")
                        {
                            ((ListView)control).Items[j].ForeColor = Color.Red;
                        }
                    }
                }
                if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "CAPABLE_FLAG")
                {
                    for (j = 0; j < ((ListView)control).Items.Count; j++)
                    {
                        if (((ListView)control).Items[j].SubItems[i].Text == "N")
                        {
                            ((ListView)control).Items[j].ForeColor = Color.Red;
                        }
                    }
                }
                if (i_score_col == -1)
                {
                    if (MPCF.Trim(((ListView)control).Columns[i].Tag) == "PRIORITY_SCORE")
                    {
                        i_score_col = i;
                    }
                }
            }
            if (i_score_col != -1)
            {
                if (control is ListView)
                {
                    ((ListView)control).ListViewItemSorter = new Miracom.CliFrx.ListViewItemComparer(i_score_col, SortOrder.Descending, Miracom.CliFrx.ListViewItemComparer.SORTING_OPTION.STRING_TYPE);
                    ((ListView)control).Sort();
                }
            }

            return true;

        }

    }
         
    //#End If
    
}
