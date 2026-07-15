
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modQCMListRoutine.vb
//   Description : Client Common List function QCM Module
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
//#If _QCM = True Then

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.UI.Controls.MCCodeView;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public sealed class QCMLIST
    {
        
        // ViewSamplingProcedureList()
        //       - View All Sampling Procedure List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal parentNode As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewSamplingProcedureList(Control control, char c_step, string sFilter, TreeNode parentNode, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            
            TRSNode in_node = new TRSNode("VIEW_SAMPLING_PROCEDURE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SAMPLING_PROCEDURE_LIST_OUT");

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

            do
            {
                if (MPCR.CallService("QCM", "QCM_View_Sampling_Procedure_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("SAMPLE_PROC"), (int)SMALLICON_INDEX.IDX_CHARACTER);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SAMPLE_PROC_DESC"));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("SAMPLE_PROC") + " : " + out_node.GetList(0)[i].GetString("SAMPLE_PROC_DESC"), 
                            (int)SMALLICON_INDEX.IDX_CHARACTER, (int)SMALLICON_INDEX.IDX_CHARACTER);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("SAMPLE_PROC"));
                    }
                }

                in_node.SetString("NEXT_SAMPLE_PROC", out_node.GetString("NEXT_SAMPLE_PROC"));

            } while (out_node.GetString("NEXT_SAMPLE_PROC") != "");

            return true;

        }

        
        // ViewInspectionItemList()
        //       - View All Inspection Item List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal parentNode As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewInspectionItemList(Control control, char c_step, string sFilter, TreeNode parentNode, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            
            TRSNode in_node = new TRSNode("VIEW_INSPECTION_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_ITEM_LIST_OUT");

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

            if (c_step == '1')
            {
                in_node.AddChar("ACTIVE_FLAG", 'A');
            }
            else if (c_step == '2')
            {
                in_node.AddChar("ACTIVE_FLAG", 'Y');
            }
            else if (c_step == '3')
            {
                in_node.AddChar("ACTIVE_FLAG", 'N');
            }

            do
            {
                if (MPCR.CallService("QCM", "QCM_View_Inspection_Item_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("INSP_ITEM"), (int)SMALLICON_INDEX.IDX_COL_SET);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("INSP_ITEM_DESC"));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("INSP_ITEM") + " : " + out_node.GetList(0)[i].GetString("INSP_ITEM_DESC"), (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("INSP_ITEM"));
                    }
                }

                in_node.SetString("NEXT_INSP_ITEM", out_node.GetString("NEXT_INSP_ITEM"));

            } while (out_node.GetString("NEXT_INSP_ITEM") != "");

            return true;

        }
        
        // ViewAttachInspectionItemList()
        //       - View All Attached Inspection Item List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - Byval sInspSet as string                  : Inspection Set ID
        //       - Byval iInspSetVersion as integer          : Inspection Set Version
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal parentNode As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewAttachInspectionItemList(Control control, char c_step, string sInspSet, int iInspSetVersion, TreeNode parentNode, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_ATTACH_INSPECTION_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_INSPECTION_ITEM_LIST_OUT");

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

            in_node.AddString("INSP_SET_ID", sInspSet);
            in_node.AddInt("INSP_SET_VERSION", iInspSetVersion);

            do
            {
                if (MPCR.CallService("QCM", "QCM_View_Attach_Insp_Item_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("INSP_ITEM"), (int)SMALLICON_INDEX.IDX_COL_SET);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("INSP_ITEM_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("INSP_ITEM") + " : " + out_node.GetList(0)[i].GetString("INSP_ITEM_DESC"), (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("INSP_ITEM"));
                    }
                }

                in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

            } while (out_node.GetInt("NEXT_SEQ_NUM") > 0);

            return true;


        }
        
        
        // ViewInspectionSetList()
        //       - View All Inspection Set List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sInspType As String = ""    : Inspection Type
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal parentNode As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewInspectionSetList(Control control, char c_step, string sInspType, string sFilter, TreeNode parentNode, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            
            TRSNode in_node = new TRSNode("VIEW_INSPECTION_SET_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_SET_LIST_OUT");

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

            in_node.AddString("INSP_TYPE", sInspType);
            in_node.AddString("FILTER", sFilter);

            if (c_step == '1')
            {
                in_node.AddChar("ACTIVE_FLAG", 'A');
            }
            else if (c_step == '2')
            {
                in_node.AddChar("ACTIVE_FLAG", 'Y');
            }
            else if (c_step == '3')
            {
                in_node.AddChar("ACTIVE_FLAG", 'N');
            }

            do
            {
                if (MPCR.CallService("QCM", "QCM_View_Inspection_Set_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("INSP_SET_ID"), (int)SMALLICON_INDEX.IDX_COL_SET);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("INSP_SET_DESC"));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("INSP_SET_ID") + " : " + out_node.GetList(0)[i].GetString("INSP_SET_DESC"), (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("INSP_SET_ID"));
                    }
                }

                in_node.SetString("NEXT_INSP_SET", out_node.GetString("NEXT_INSP_SET"));

            } while (out_node.GetString("NEXT_INSP_SET") != "");

            return true;
        }
        
        // ViewInspectionSetVersionList()
        //       - View All Inspection Set Version List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sInspSetID As String = ""    :
        //        - Optional ByVal parentNode As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewInspectionSetVersionList(Control control, char c_step, string sInspSetID, TreeNode parentNode, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_INSPECTION_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_VERSION_LIST_OUT");

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

            in_node.AddString("INSP_SET_ID", sInspSetID);

            do
            {
                if (MPCR.CallService("QCM", "QCM_View_Inspection_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("INSP_SET_VERSION").ToString(), (int)SMALLICON_INDEX.IDX_COL_SET);
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("INSP_SET_VERSION").ToString(), (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("INSP_SET_VERSION").ToString());
                    }
                }

                in_node.SetInt("NEXT_INSP_SET_VERSION", out_node.GetInt("NEXT_INSP_SET_VERSION"));

            } while (out_node.GetInt("NEXT_INSP_SET_VERSION") > 0);

            return true;
        }
        
        // ViewInspectionMaterialList()
        //       - View All Inspection Maerial List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal parentNode As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewInspectionMaterialList(Control control, char c_step, string sFilter, TreeNode parentNode, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_INSPECTION_MATERIAL_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_MATERIAL_LIST_OUT");

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

            do
            {
                if (MPCR.CallService("QCM", "QCM_View_Inspection_Material_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("MAT_ID"), (int)SMALLICON_INDEX.IDX_MATERIAL);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER")));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_DESC"));
                        }
                        if (c_step == '2')
                        {
                            if (out_node.GetList(0)[i].GetChar("INSP_FLAG") == 'Y')
                            {
                                itmX.ForeColor = Color.Magenta;
                            }
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("MAT_ID") + " : " + out_node.GetList(0)[i].GetString("MAT_DESC"), (int)SMALLICON_INDEX.IDX_MATERIAL, (int)SMALLICON_INDEX.IDX_MATERIAL);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                    }
                }

                in_node.SetString("NEXT_MAT_ID", out_node.GetString("NEXT_MAT_ID"));

            } while (out_node.GetString("NEXT_MAT_ID") != "");

            return true;
        }

        // ViewQARuleList()
        //       - View All Qa Rule List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal parentNode As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewQARuleList(Control control, char c_step, string sQARuleType, string sQARuleID)
        {
            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_QA_RULE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_QA_RULE_LIST_OUT");

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
            in_node.AddString("RULE_TYPE", sQARuleType);
            in_node.AddString("RULE_ID", sQARuleID);
            in_node.AddString("NEXT_RULE_ID", "");

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_QA_Rule_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList("RULE_LIST").Count; i++)
                {

                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList("RULE_LIST")[i].GetString("RULE_ID")), (int)SMALLICON_INDEX.IDX_FACTORY);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList("RULE_LIST")[i].GetString("RULE_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList("RULE_LIST")[i].GetString("RULE_ID")));

                    }
                }

                in_node.SetString("NEXT_RULE_ID", out_node.GetString("NEXT_RULE_ID"));
            } while (string.IsNullOrEmpty(out_node.GetString("NEXT_RULE_ID")) == false);

            return true;
        }

        // ViewMFOQARuleList()
        //       - View All MFO QA Rule List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal parentNode As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewMFOQARuleList(Control control, char c_step, string sQARuleType,
            string sQARuleID, string sMatID, int iMatVer, string sFlow, int iFlowSeq, string sOper, string sResID,
            string sSubResID)
        {

            int i;
            ListViewItem itmX;


            TRSNode in_node = new TRSNode("VIEW_MFO_QA_RULE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_QA_RULE_LIST_OUT");

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
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddInt("FLOW_SEQ", iFlowSeq);
            in_node.AddString("OPER", sOper);
            in_node.AddString("RES_ID", sResID);
            in_node.AddString("SUB_RES_ID", sSubResID);
            in_node.AddString("REL_TYPE", sQARuleType);
            in_node.AddString("RULE_ID", sQARuleID);
            in_node.AddString("NEXT_RULE_ID", "");

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_MFO_QA_Rule_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_ID")), (int)SMALLICON_INDEX.IDX_FACTORY);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RULE_ID")));

                    }
                }

                in_node.SetString("NEXT_RULE_ID", out_node.GetString("NEXT_RULE_ID"));
            } while (string.IsNullOrEmpty(out_node.GetString("NEXT_RULE_ID")) == false);

            return true;
        }
    }
    //#End If
}
