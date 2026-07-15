
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.UI.Controls.MCCodeView;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modWIPListRoutine.vb
//   Description : Client Common List function WIP Module
//
//   MES Version : 4.1.0.0
//
//   Function List
//        - ViewToolTypeList()    : View Tool Type List
//        - ViewToolEventList()    : View Tool Event List
//        - ViewFactoryList()    : View All Factory List
//        - ViewFactoryCmfData() : View FACCMF Table Item Data
//        - ViewFlowList() : View All Flow List
//        - ViewLotHistory()  : View Lot History
//        - ViewMaterialList() : View All Material List
//        - ViewShipFacList() : View All Shipping Factory List
//       - ViewEDCCharacterList() : View Character list
//       - ViewEDCColSetList() : View Collection Set List
//       - ViewEDCColSetVersionList() : View Collection Set Version List
//       - ViewFunctionList() : View All Function List
//       - ViewSecGroupList() : View All Security Group List
//       - ViewResOperList()  : View Resource - Operation Relation List
//       - ViewResEventList()  : View Resource - Event Relation List
//       - ViewMessageGroupList() : View Message Group List
//       - ViewMessageList() : View Message List
//       - ViewLotDataByLot() : View EDC Lot Data by Lot Number
//       - ViewResUserList() : View Resource -User Relation List
//       - ViewPrvGroupList() : View Privilege Grouop List
//       - ViewPrvGrpUserList() : View Privilege Group - User List
//       - ViewPrivilegeList() : View Privilege List
//       - ViewLabelList() : View All Label List
//       - ViewImageList() : View Label Image List
//        - ViewCarrierList() : View Carrier List
//       - ViewRecipeList() : View Recipe List
//        - ViewRecipeVersionList() : View Recipe Version List
//        - ViewLotAlarmMsgList() : View Lot Alarm Message List
//        - ViewAlarmResourceList() : View Alarm Resource List
//        - ViewResourceAlarmMsgList() : View Resource Alarm Message List
//       - ViewToolTypeList() : View Tool Type List
//       - ViewToolEventList() : View Tool Event List
//       - ViewToolList() : View Tool List
//       - ViewToolList_Detail() : View Tool List
//       - ViewToolEventRelationList() : View Tool-Event Relation List
//       - ViewToolHistory() : View Tool History
//
//   Detail Description
//       - ViewFunctionList() : c_step = 1 : Î™®Îì† Function ListÎ•?Í∞Ä?∏Ïò¥
//                              c_step = 2 : ?πÏ†ï SecurityGroup???¨Ìï®??Function ListÎ•?Í∞Ä?∏Ïò¥
//       - ViewEDCColSetList(): c_step="1" : View All Collection Set List which is included
//                                          in the factory (Include Deleted Collection Set)
//                              c_step="2" : View All Collection Set List which is included
//                                          in the factory (exclude Deleted Collection Set)
//                              c_step="3" : View All Collection Set List which is satisfied with the condition
//                                          (Factory, Lot_Or_Res_Flag, Not Deleted)
//       - ViewResUserList() :  c_step = 1 : Resource ?Ä ?∞Í???Î™®Îì† User ListÎ•?Í∞Ä?∏Ïò¥
//                              c_step = 2 : ?πÏ†ï User ?Ä ?∞Í???Î™®Îì† Resource ListÎ•?Í∞Ä?∏Ïò¥
//
//       - ViewPrvGrpUserList() :  c_step = 1 : Privilege Group Í≥??∞Í???Î™®Îì† User ListÎ•?Í∞Ä?∏Ïò¥
//                                 c_step = 2 : ?πÏ†ï User ?Ä ?∞Í???Î™®Îì† Privilege Group ListÎ•?Í∞Ä?∏Ïò¥
//
//       - ViewToolList() : c_step = '1' : Factory?¥Ïùò Î™®Îì† Tool ListÎ•?Í∞Ä?∏Ïò®??
//                          c_step = '2' : Factory, Tool_Type???¥Îãπ?òÎäî Tool ListÎ•?Í∞Ä?∏Ïò®??
//
//                          delete_flag = ' ' : delete_flag???ÅÍ??ÜÏù¥ Î¶¨Ïä§?∏Î? Í∞Ä?∏Ïò®??
//                          delete_flag = 'N' : delete_flag=' ' ??Í≤ÉÎßå Í∞Ä?∏Ïò®??
//                          delete_flag = 'Y' : delete_flag<>' ' ??Í≤ÉÎßå Í∞Ä?∏Ïò®??
//
//       - ViewToolList_Detail() : c_step = '1' : Factory?¥Ïùò Î™®Îì† Tool ListÎ•?Í∞Ä?∏Ïò®??
//                                 c_step = '2' : Factory, Tool_Type???¥Îãπ?òÎäî Tool ListÎ•?Í∞Ä?∏Ïò®??
//
//                                 delete_flag = ' ' : delete_flag???ÅÍ??ÜÏù¥ Î¶¨Ïä§?∏Î? Í∞Ä?∏Ïò®??
//                                 delete_flag = 'N' : delete_flag=' ' ??Í≤ÉÎßå Í∞Ä?∏Ïò®??
//                                 delete_flag = 'Y' : delete_flag<>' ' ??Í≤ÉÎßå Í∞Ä?∏Ïò®??
//
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-09 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.MESCore
{
    public sealed class WIPLIST
    {
        
        // ViewFactoryList()
        //       - View Factory List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewFactoryList(Control control, char c_step, TreeNode parentNode)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            
            TRSNode in_node = new TRSNode("VIEW_FACTORY_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_LIST_OUT");

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
                if (MPCR.CallService("WIP", "WIP_View_Factory_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("FACTORY"), (int)SMALLICON_INDEX.IDX_FACTORY);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FAC_DESC"));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("FACTORY") + " : " + out_node.GetList(0)[i].GetString("FAC_DESC"), 
                            (int)SMALLICON_INDEX.IDX_FACTORY, (int)SMALLICON_INDEX.IDX_FACTORY);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("FACTORY"));

                    }
                }

                in_node.SetString("NEXT_FACTORY", out_node.GetString("NEXT_FACTORY"));
            } while (in_node.GetString("NEXT_FACTORY") != "");

            return true;
        }

        
        // ViewShipFacList()
        //       - View all Shipping Factory List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewShipFacList(Control control, char c_step, TreeNode parentNode, string sExt_Factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_SHIP_FACTORY_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SHIP_FACTORY_LIST_OUT");

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
                if (MPCR.CallService("WIP", "WIP_View_Ship_Factory_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("FACTORY_TO"), (int)SMALLICON_INDEX.IDX_SHIP_FACTORY);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("TRANSIT_OPER"));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("FACTORY_TO") + " : " + out_node.GetList(0)[i].GetString("TRANSIT_OPER"), 
                            (int)SMALLICON_INDEX.IDX_SHIP_FACTORY, (int)SMALLICON_INDEX.IDX_SHIP_FACTORY);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("FACTORY_TO"));

                    }
                }

                in_node.SetString("NEXT_FACTORY_TO", out_node.GetString("NEXT_FACTORY_TO"));
            } while (in_node.GetString("NEXT_FACTORY_TO") != "");

            return true;
        }

        
        // ViewMaterialList()
        //       - View all Material List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sMaterialType As String = "" : Material Type
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewMaterialList(Control control, char c_step)
        {
            return ViewMaterialList(control, c_step, "", ' ', ' ', "", true, null, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, string sMaterialType)
        {
            return ViewMaterialList(control, c_step, sMaterialType, ' ', ' ', "", true, null, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, bool bIncludeVersion)
        {
            return ViewMaterialList(control, c_step, "", ' ', ' ', "", bIncludeVersion, null, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, string sMaterialType, bool bIncludeVersion)
        {
            return ViewMaterialList(control, c_step, sMaterialType, ' ', ' ', "", bIncludeVersion, null, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, TreeNode parentNode)
        {
            return ViewMaterialList(control, c_step, "", ' ', ' ', "", true, parentNode, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, bool bIncludeVersion, TreeNode parentNode)
        {
            return ViewMaterialList(control, c_step, "", ' ', ' ', "", bIncludeVersion, parentNode, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, string sMaterialType, bool bIncludeVersion, TreeNode parentNode)
        {
            return ViewMaterialList(control, c_step, sMaterialType, ' ', ' ', "", bIncludeVersion, parentNode, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, string sMaterialType, char cDeleteFlag, char cDeactiveFlag, string sFilter, bool bIncludeVersion, TreeNode parentNode, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
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

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("MAT_TYPE", sMaterialType);
            in_node.AddString("FILTER", sFilter);
            in_node.AddString("NEXT_MAT_ID", "");
            in_node.AddInt("NEXT_MAT_VER", int.MaxValue);

            in_node.AddChar("DELETE_FLAG", cDeleteFlag);
            in_node.AddChar("DEACTIVE_FLAG", cDeactiveFlag);

            do
            {
                out_node = new TRSNode("VIEW_MATERIAL_LIST_OUT");

                if (MPCR.CallService("WIP", "WIP_View_Material_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_MAT_ID", out_node.GetString("NEXT_MAT_ID"));
                in_node.SetInt("NEXT_MAT_VER", out_node.GetInt("NEXT_MAT_VER"));
            } while (in_node.GetString("NEXT_MAT_ID") != "");


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("MAT_ID"), (int)SMALLICON_INDEX.IDX_MATERIAL);

                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Magenta;
                        }
                        else if (out_node.GetList(0)[i].GetChar("DEACTIVE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Khaki;
                        }

                        if (((ListView)control).Columns.Count > 1)
                        {
                            if (bIncludeVersion == true)
                            {
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                            }
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        if (bIncludeVersion == true)
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("MAT_ID") +
                                                 " (" + out_node.GetList(0)[i].GetInt("MAT_VER").ToString() + ") : " +
                                                 out_node.GetList(0)[i].GetString("MAT_DESC"),
                                                 (int)SMALLICON_INDEX.IDX_MATERIAL,
                                                 (int)SMALLICON_INDEX.IDX_MATERIAL);
                            nodeX.Tag = out_node.GetList(0)[i].GetString("MAT_ID") +
                                                 " (" + out_node.GetList(0)[i].GetInt("MAT_VER").ToString() + ")";

                            if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                            {
                                nodeX.ForeColor = Color.Magenta;
                            }
                            else if (out_node.GetList(0)[i].GetChar("DEACTIVE_FLAG") == 'Y')
                            {
                                nodeX.ForeColor = Color.Khaki;
                            }

                        }
                        else
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("MAT_ID"),
                                                 (int)SMALLICON_INDEX.IDX_MATERIAL,
                                                 (int)SMALLICON_INDEX.IDX_MATERIAL);
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
                        if (bIncludeVersion == true)
                        {
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("MAT_ID") +
                                                          " (" + out_node.GetList(0)[i].GetInt("MAT_VER").ToString() + ")");
                        }
                        else
                        {
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                        }
                    }
                }
            }

            return true;
            
        }

        // ViewMaterialVersionList()
        //       - View all Material Version List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sMatID As String = "" : Material ID
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID)
        {
            return ViewMaterialVersionList(control, c_step, sMatID, "", ' ', ' ', null, "");
        }

        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID, TreeNode parentNode)
        {
            return ViewMaterialVersionList(control, c_step, sMatID, "", ' ', ' ', parentNode, "");
        }

        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID, string sMatType)
        {
            return ViewMaterialVersionList(control, c_step, sMatID, sMatType, ' ', ' ', null, "");
        }

        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID, string sMatType, TreeNode parentNode)
        {
            return ViewMaterialVersionList(control, c_step, sMatID, sMatType, ' ', ' ', parentNode, "");
        }

        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID, string sMatType, char cDeleteFlag, char cDeactiveFlag, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_MATERIAL_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MATERIAL_VERSION_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
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

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("MAT_ID", sMatID);
            in_node.AddString("MAT_TYPE", sMatType);
            in_node.AddInt("NEXT_MAT_VER", int.MaxValue);

            in_node.AddChar("DELETE_FLAG", cDeleteFlag);
            in_node.AddChar("DEACTIVE_FLAG", cDeactiveFlag);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Material_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("MAT_VER").ToString(), (int)SMALLICON_INDEX.IDX_MATERIAL);

                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Magenta;
                        }
                        else if (out_node.GetList(0)[i].GetChar("DEACTIVE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Khaki;
                        }

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("MAT_VER").ToString() + " : " +
                                             out_node.GetList(0)[i].GetString("MAT_DESC"),
                                             (int)SMALLICON_INDEX.IDX_MATERIAL,
                                             (int)SMALLICON_INDEX.IDX_MATERIAL);

                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            nodeX.ForeColor = Color.Magenta;
                        }
                        else if (out_node.GetList(0)[i].GetChar("DEACTIVE_FLAG") == 'Y')
                        {
                            nodeX.ForeColor = Color.Khaki;
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                    }
                }

                in_node.SetInt("NEXT_MAT_VER", out_node.GetInt("NEXT_MAT_VER"));
            } while (in_node.GetInt("NEXT_MAT_VER") > 0);

            return true;

        }

                
        // ViewFlowList()
        //       - View all Flow List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sMaterial As String = ""    : sMaterialÎ•?Í∞ÄÏß?Flow
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Flow
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewFlowList(Control control, char c_step)
        {
            return ViewFlowList(control, c_step, "", 0, "", null, "");
        }
        public static bool ViewFlowList(Control control, char c_step, string sMaterial, int iMatVer)
        {
            return ViewFlowList(control, c_step, sMaterial, iMatVer, "", null, "");
        }
        public static bool ViewFlowList(Control control, char c_step, string sFilter)
        {
            return ViewFlowList(control, c_step, "", 0, sFilter, null, "");
        }
        public static bool ViewFlowList(Control control, char c_step, TreeNode parentNode)
        {
            return ViewFlowList(control, c_step, "", 0, "", parentNode, "");
        }
        public static bool ViewFlowList(Control control, char c_step, string sMaterial, int iMatVer, TreeNode parentNode)
        {
            return ViewFlowList(control, c_step, sMaterial, iMatVer, "", parentNode, "");
        }

        public static bool ViewFlowList(Control control, char c_step, string sMaterial, int iMatVer, string sFilter, TreeNode parentNode, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_FLOW_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
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

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("FILTER", sFilter);
            in_node.AddString("MAT_ID", sMaterial);
            in_node.AddInt("MAT_VER", iMatVer);

            do
            {
                out_node = new TRSNode("VIEW_FLOW_LIST_OUT");

                if (MPCR.CallService("WIP", "WIP_View_Flow_List", in_node, ref out_node) == false)
                {
                    return false;
                }


                a_list.Add(out_node);

                in_node.SetString("NEXT_FLOW", out_node.GetString("NEXT_FLOW"));
                in_node.SetInt("NEXT_FLOW_SEQ_NUM", out_node.GetInt("NEXT_FLOW_SEQ_NUM"));

            } while (in_node.GetString("NEXT_FLOW") != "" || in_node.GetInt("NEXT_FLOW_SEQ_NUM") > 0);


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = ((ListView)control).Items.Add(out_node.GetList(0)[i].GetString("FLOW"), (int)SMALLICON_INDEX.IDX_FLOW);
                        if (((ListView)control).Columns.Count == 4)
                        {
                            //2014.04.03 Optional Group, Option ƒÆ∑≥¿« ¿ßƒ°∏¶ Description ¥Ÿ¿Ω¿∏∑Œ ¿Ãµø 
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW_DESC"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPT_FLOW_GROUP"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("OPT_FLOW_OPTION_FLAG").ToString());
                        }
                        else if (((ListView)control).Columns.Count == 3)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                        }
                        if (((ListView)control).Columns.Count > 1 && ((ListView)control).Columns.Count != 4)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW_DESC"));
                        }

                    }
                    else if (control is TreeView)
                    {
                        if (c_step == '2')
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("FLOW") + " (" +
                                                 out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString() + ") : " +
                                                 out_node.GetList(0)[i].GetString("FLOW_DESC"),
                                                 (int)SMALLICON_INDEX.IDX_FLOW,
                                                 (int)SMALLICON_INDEX.IDX_FLOW);
                        }
                        else
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("FLOW") + " : " +
                                                 out_node.GetList(0)[i].GetString("FLOW_DESC"),
                                                 (int)SMALLICON_INDEX.IDX_FLOW,
                                                 (int)SMALLICON_INDEX.IDX_FLOW);
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
                        if (c_step == '2')
                        {
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("FLOW") + " (" +
                                                          out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString() + ")");
                        }
                        else
                        {
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("FLOW"));
                        }
                    }
                }
            }
            
            return true;
            
        }

        // ViewFlowSequenceList()
        //       - View all flow sequence List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sMatID As String = ""      : Material ID
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewFlowSequenceList(Control control, char c_step, string sMatID, int iMatVer, string sFlow, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_SEQ_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SEQ_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
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

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddInt("NEXT_FLOW_SEQ_NUM", 0);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Flow_Sequence_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString(), (int)SMALLICON_INDEX.IDX_FLOW);
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString(),
                                             (int)SMALLICON_INDEX.IDX_FLOW,
                                             (int)SMALLICON_INDEX.IDX_FLOW);

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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                    }
                }

                in_node.SetInt("NEXT_FLOW_SEQ_NUM", out_node.GetInt("NEXT_FLOW_SEQ_NUM"));
            } while (in_node.GetInt("NEXT_FLOW_SEQ_NUM") > 0);

            return true;


        }

        // ViewFactoryCmfData()
        //       - View FACCMF Table Item Data
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sItemName As String                    : Í∞Ä?∏Ïò¨ Item Name
        //        - ByRef View_Factory_Cmf_Item_Out As WIP_View_Factory_Cmf_Item_Out_Tag
        //                                                    : Í∞Ä?∏Ïò® Item Data??Íµ¨Ï°∞Ï≤?
        //        - Optional ByVal sExtFactory As String = ""    : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞
        //
        public static bool ViewFactoryCmfData(char c_step, string sItemName, ref TRSNode out_node, string sExtFactory, bool bIgnoreMessage)
        {

            TRSNode in_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_IN");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }
            in_node.AddString("ITEM_NAME", sItemName);

            if (MPCR.CallService("WIP", "WIP_View_Factory_Cmf_Item", in_node, ref out_node, bIgnoreMessage) == false)
            {
                return false;
            }

            return true;
        }
        
        // ViewOperationList()
        //       - View All Operation List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sMaterial As String = ""    : sMaterial??Í∞ÄÏß?Operation
        //        - Optional ByVal sFlow As String = ""        : sFlowÎ•?Í∞ÄÏß?Operation
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Oper
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewOperationList(Control control, char c_step)
        {
            return ViewOperationList(control, c_step, "", 0, "", "", null, "");
        }

        public static bool ViewOperationList(Control control, char c_step, bool b_sec_chk_flag)
        {
            return ViewOperationList(control, c_step, "", 0, "", "", null, "", b_sec_chk_flag);
        }

        public static bool ViewOperationList(Control control, char c_step, string sMaterial, int iMatVer)
        {
            return ViewOperationList(control, c_step, sMaterial, iMatVer, "", "", null, "");
        }

        public static bool ViewOperationList(Control control, char c_step, string sFlow)
        {
            return ViewOperationList(control, c_step, "", 0, sFlow, "", null, "");
        }
        public static bool ViewOperationList(Control control, char c_step, TreeNode parentNode)
        {
            return ViewOperationList(control, c_step, "", 0, "", "", parentNode, "");
        }

        public static bool ViewOperationList(Control control, char c_step, string sMaterial, int iMatVer, TreeNode parentNode)
        {
            return ViewOperationList(control, c_step, sMaterial, iMatVer, "", "", parentNode, "");
        }

        public static bool ViewOperationList(Control control, char c_step, string sFlow, TreeNode parentNode)
        {
            return ViewOperationList(control, c_step, "", 0, sFlow, "", parentNode, "");
        }

        public static bool ViewOperationList(Control control, char c_step, string sMaterial, int iMatVer, string sFlow, string sFilter, TreeNode parentNode, string sExtFactory)
        {
            return ViewOperationList(control, c_step, sMaterial, iMatVer, sFlow, sFilter, parentNode, sExtFactory, false);
        }

        public static bool ViewOperationList(Control control, char c_step, string sMaterial, int iMatVer, string sFlow, string sFilter, TreeNode parentNode, string sExtFactory, bool b_sec_chk_flag)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
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

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("FILTER", sFilter);
            in_node.AddString("MAT_ID", sMaterial);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("NEXT_OPER", "");
            in_node.AddChar("SEC_CHK_FLAG", b_sec_chk_flag == true ? 'Y' : ' ');

            do
            {
                out_node = new TRSNode("VIEW_OPERATION_LIST_OUT");

                if (MPCR.CallService("WIP", "WIP_View_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));

            } while (in_node.GetString("NEXT_OPER") != "");


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("OPER"), (int)SMALLICON_INDEX.IDX_OPER);
                        if (((ListView)control).Columns.Count == 4)
                        {
                            //2014.04.03 Optional Group, Option ƒÆ∑≥¿« ¿ßƒ°∏¶ Description ¥Ÿ¿Ω¿∏∑Œ ¿Ãµø
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER_DESC"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPT_OPER_GROUP"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("OPT_OPER_OPTION_FLAG").ToString());
                        }
                        else if (((ListView)control).Columns.Count > 4)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPT_OPER_GROUP"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("OPT_OPER_OPTION_FLAG").ToString());
                        }
                        if (((ListView)control).Columns.Count > 1 && ((ListView)control).Columns.Count != 4)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER_DESC"));
                        }

                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("OPER") + " : " + out_node.GetList(0)[i].GetString("OPER_DESC"), 
                            (int)SMALLICON_INDEX.IDX_OPER, (int)SMALLICON_INDEX.IDX_OPER);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("OPER"));
                    }
                }
            }
            
            return true;
            
        }

        // ViewStepList()
        //       - View All Step List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sMaterial As String = ""    : sMaterial??Í∞ÄÏß?Operation
        //        - Optional ByVal sFlow As String = ""        : sFlowÎ•?Í∞ÄÏß?Operation
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Oper
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //

        public static bool ViewStepList(Control control, char c_step)
        {
            return ViewStepList(control, c_step, "", 0, "", "", ' ', "", null, "");
        }

        public static bool ViewStepList(Control control, char c_step, string sMaterial, int iMatVer, string sFlow, string sOper)
        {
            return ViewStepList(control, c_step, sMaterial, iMatVer, sFlow, sOper, ' ', "", null, "");
        }

        public static bool ViewStepList(Control control, char c_step, string sMaterial, int iMatVer, string sFlow, string sOper, char c_rel_level)
        {
            return ViewStepList(control, c_step, sMaterial, iMatVer, sFlow, sOper, c_rel_level, "", null, "");
        }


        public static bool ViewStepList(Control control, char c_step, string sMaterial, int iMatVer, string sFlow, string sOper, TreeNode parentNode, string sExtFactory)
        {
            return ViewStepList(control, c_step, sMaterial, iMatVer, sFlow, sOper, ' ', "", parentNode, sExtFactory);
        }

        public static bool ViewStepList(Control control, char c_step, string sMaterial, int iMatVer, string sFlow, string sOper, string sLotID, TreeNode parentNode, string sExtFactory)
        {
            return ViewStepList(control, c_step, sMaterial, iMatVer, sFlow, sOper, ' ', sLotID, parentNode, sExtFactory);
        }

        public static bool ViewStepList(Control control, char c_step, string sMaterial, int iMatVer, string sFlow, string sOper, char c_rel_level, string sLotID, TreeNode parentNode, string sExtFactory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_STEP_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            MPCF.InitListView((ListView)control);

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
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

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("MAT_ID", sMaterial);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("OPER", sOper);
            in_node.AddString("NEXT_STEP", "");
            in_node.AddChar("REL_LEVEL", c_rel_level);
            in_node.AddString("LOT_ID", sLotID);

            do
            {
                out_node = new TRSNode("VIEW_STEP_LIST_OUT");

                if (MPCR.CallService("WIP", "WIP_View_Step_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_STEP", out_node.GetString("NEXT_STEP"));

            } while (in_node.GetString("NEXT_STEP") != "");


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("STEP"), (int)SMALLICON_INDEX.IDX_OPER);
                        if (((ListView)control).Columns.Count > 3)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("AUTO_START_FLAG").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("AUTO_END_FLAG").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("START_REQ_FLAG").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("END_REQ_FLAG").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SERIAL_PROC_FLAG").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESV_FIELD_1").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESV_FIELD_2").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESV_FIELD_3").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESV_FIELD_4").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESV_FIELD_5").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("STEP_DESC"));

                        }
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("STEP_DESC"));
                        }

                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("STEP") + " : " + out_node.GetList(0)[i].GetString("STEP_DESC"),
                            (int)SMALLICON_INDEX.IDX_OPER, (int)SMALLICON_INDEX.IDX_OPER);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("STEP"));
                    }
                }
            }

            return true;

        }

        // ViewLotHistory()
        //       - View Lot History
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
        //       - Optional ByVal sTranCode as string =""    : Transaction Code Î™?
        //
        public static bool ViewLotHistory(Control control, char c_step, string sLotID, string sFromTime, string sToTime, char sIncludeDelHistory, TreeNode parentNode, bool bIgnoreError, string sTranCode)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            int iHistIcon;
            int i;

            TRSNode in_node = new TRSNode("VIEW_LOT_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_HISTORY_OUT");

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
            in_node.AddString("FROM_TRAN_TIME", sFromTime);
            in_node.AddString("TO_TRAN_TIME", sToTime);
            in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDelHistory);
            in_node.AddString("TRAN_CODE", sTranCode);
            in_node.AddInt("HIST_SEQ", int.MaxValue);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG") == 'Y')
                    {
                        iHistIcon = (int)SMALLICON_INDEX.IDX_HISTORY_DELETE;
                    }
                    else
                    {
                        iHistIcon = (int)SMALLICON_INDEX.IDX_HISTORY;
                    }

                    if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        // 2007. 04.05. Aiden.
                        // View Lot history ø°º≠¿Ã∑¬¿ª∞°¡Æø¿∞Ì¥ŸΩ√¿Ã«‘ºˆ∏¶»£√‚«œø©¥ŸΩ√∞°¡Æø¬¥Ÿ.
                        // µ˚∂Ûº≠µø¿œ«—≥ªøÎø°¥Î«ÿº≠2π¯∞°¡Æø¿π«∑Œæ∆∑°«‘ºˆ∏¶≈Î«ÿº≠«—π¯ø°±◊∏±ºˆ¿÷µµ∑œ«‘
                        PrintLotHistoryToSpread((FarPoint.Win.Spread.FpSpread)control, out_node.GetList(0)[i]);
                    }
                    else if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("HIST_SEQ").ToString(), iHistIcon);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME")) + " : " +
                                             out_node.GetList(0)[i].GetString("TRAN_CODE"),
                                             (int)SMALLICON_INDEX.IDX_HISTORY,
                                             (int)SMALLICON_INDEX.IDX_HISTORY);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("TRAN_CODE"));
                    }
                }

                in_node.SetInt("HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

            } while (in_node.GetInt("HIST_SEQ") > 0);

            return true;
        }

        // ViewLotHistoryForStep()
        //       - View Lot History For Step
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
        public static bool ViewLotHistoryForStep(Control control, char c_step, string sLotID, string sFromTime, string sToTime, char sIncludeDelHistory, TreeNode parentNode, bool bIgnoreError)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            int iHistIcon;
            int i;

            TRSNode in_node = new TRSNode("VIEW_LOT_HISTORY_FOR_STEP_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_HISTORY_FOR_STEP_OUT");

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
            in_node.AddString("FROM_TRAN_TIME", sFromTime);
            in_node.AddString("TO_TRAN_TIME", sToTime);
            in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDelHistory);
            in_node.AddInt("HIST_SEQ", int.MaxValue);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_History_For_Step", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG") == 'Y')
                    {
                        iHistIcon = (int)SMALLICON_INDEX.IDX_HISTORY_DELETE;
                    }
                    else
                    {
                        iHistIcon = (int)SMALLICON_INDEX.IDX_HISTORY;
                    }

                    if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        // 2007. 04.05. Aiden.
                        // View Lot history ø°º≠¿Ã∑¬¿ª∞°¡Æø¿∞Ì¥ŸΩ√¿Ã«‘ºˆ∏¶»£√‚«œø©¥ŸΩ√∞°¡Æø¬¥Ÿ.
                        // µ˚∂Ûº≠µø¿œ«—≥ªøÎø°¥Î«ÿº≠2π¯∞°¡Æø¿π«∑Œæ∆∑°«‘ºˆ∏¶≈Î«ÿº≠«—π¯ø°±◊∏±ºˆ¿÷µµ∑œ«‘
                        PrintLotHistoryForStepToSpread((FarPoint.Win.Spread.FpSpread)control, out_node.GetList(0)[i]);
                    }
                    else if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("HIST_SEQ").ToString(), iHistIcon);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME")) + " : " +
                                             out_node.GetList(0)[i].GetString("TRAN_CODE"),
                                             (int)SMALLICON_INDEX.IDX_HISTORY,
                                             (int)SMALLICON_INDEX.IDX_HISTORY);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("TRAN_CODE"));
                    }
                }

                in_node.SetInt("HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

            } while (in_node.GetInt("HIST_SEQ") > 0);

            return true;
        }

        public static void PrintLotHistoryToSpread(FarPoint.Win.Spread.FpSpread spd, TRSNode his)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;
            int iCol;

            sheetX = spd.ActiveSheet;
            iRow = sheetX.RowCount;
            sheetX.RowCount++;

            iCol = 0;

            if (his.GetChar("HIST_DEL_FLAG") == 'Y')
            {
                sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
            }
            else
            {
                sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
            }

            sheetX.Cells[iRow, iCol].Value = his.GetInt("HIST_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("TRAN_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("FACTORY");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("MAT_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("MAT_VER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("FLOW");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("FLOW_SEQ_NUM");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OPER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("QTY_1"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("QTY_2"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("QTY_3"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("CRR_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("LOT_TYPE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OWNER_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("CREATE_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("CREATE_TIME")); // HyunJone Noh

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("LOT_PRIORITY");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_STATUS");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("LOT_DEL_TIME")); // HyunJone Noh

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("HOLD_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("HOLD_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("HOLD_PRV_GRP_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OPER_IN_QTY_1"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OPER_IN_QTY_2"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OPER_IN_QTY_3"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("CREATE_QTY_1"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("CREATE_QTY_2"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("CREATE_QTY_3"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("START_QTY_1"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("START_QTY_2"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("START_QTY_3"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("INV_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("TRANSIT_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("UNIT_EXIST_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("INV_UNIT");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("RWK_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("RWK_COUNT");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_RET_FLOW");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("RWK_RET_FLOW_SEQ_NUM");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_RET_OPER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_END_FLOW");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("RWK_END_FLOW_SEQ_NUM");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_END_OPER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("RWK_RET_CLEAR_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("RWK_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("NSTD_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("NSTD_RET_FLOW");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("NSTD_RET_FLOW_SEQ_NUM");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("NSTD_RET_OPER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("NSTD_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("REP_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("REP_RET_OPER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("STR_RET_FLOW");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("STR_RET_FLOW_SEQ_NUM");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("STR_RET_OPER");
                        
            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("START_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("START_TIME"));

            iCol++;
            /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
            //sheetX.Cells[iRow, iCol].Value = his.GetString("START_RES_ID");
            //sheetX.Columns[iCol].CellType = rtb;
            sheetX.Cells[iRow, iCol].Value = MPCR.ParseResourceID('2', "START", his);
            /*** End of Modification (2012.04.09) ***/

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("END_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("END_TIME"));

            iCol++;
            /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
            //sheetX.Cells[iRow, iCol].Value = his.GetString("END_RES_ID");
            sheetX.Cells[iRow, iCol].Value = MPCR.ParseResourceID('2', "END", his);
            /*** End of Modification (2012.04.09) ***/

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("SAMPLE_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("SAMPLE_WAIT_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("SAMPLE_RESULT");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("FROM_TO_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("FROM_TO_LOT_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("FROM_TO_MAT_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("FROM_TO_MAT_VER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("FROM_TO_FLOW");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("FROM_TO_FLOW_SEQ_NUM");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("FROM_TO_OPER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("FROM_TO_QTY_1"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("FROM_TO_QTY_2"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("FROM_TO_QTY_3"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("FROM_TO_HIST_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("SHIP_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("SHIP_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("FAC_IN_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("FLOW_IN_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("OPER_IN_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RESERVE_RES_ID");

            iCol++;
            /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
            //sheetX.Cells[iRow, iCol].Value = his.GetString("PORT_ID");
            sheetX.Cells[iRow, iCol].Value = MPCR.ParseResourceID('2', "START", his, "PORT_ID");
            /*** End of Modification (2012.04.09) ***/

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("BATCH_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("BATCH_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("ORDER_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("ADD_ORDER_ID_1");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("ADD_ORDER_ID_2");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("ADD_ORDER_ID_3");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_LOCATION_1");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_LOCATION_2");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_LOCATION_3");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_1");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_2");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_3");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_4");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_5");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_6");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_7");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_8");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_9");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_10");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_11");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_12");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_13");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_14");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_15");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_16");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_17");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_18");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_19");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_20");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("LOT_DEL_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_DEL_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("BOM_SET_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("BOM_SET_VERSION");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("BOM_ACTIVE_HIST_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("BOM_HIST_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("CRITICAL_RES_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("CRITICAL_RES_GROUP_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("SAVE_RES_ID_1");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("SAVE_RES_ID_2");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("SUBRES_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_GROUP_ID_1");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_GROUP_ID_2");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_GROUP_ID_3");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("######,##0.##########", his.GetDouble("YIELD_1"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("######,##0.##########", his.GetDouble("YIELD_2"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("######,##0.##########", his.GetDouble("YIELD_3"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("######,##0.###", his.GetDouble("GOOD_QTY"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_1");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_2");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_3");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_4");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_5");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_1");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_2");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_3");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_4");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_5");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_FACTORY");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_MAT_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("OLD_MAT_VER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_FLOW");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("OLD_FLOW_SEQ_NUM");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_OPER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OLD_QTY_1"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OLD_QTY_2"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OLD_QTY_3"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("OLD_HIST_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("OLD_LOT_TYPE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_OWNER_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_CREATE_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("OLD_FAC_IN_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("OLD_FLOW_IN_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("OLD_OPER_IN_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_1");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_2");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_3");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_4");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_5");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_6");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_7");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_8");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_9");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_10");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_11");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_12");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_13");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_14");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_15");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_16");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_17");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_18");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_19");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_20");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_USER_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_COMMENT");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("PREV_ACTIVE_HIST_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("MULTI_TR_KEY");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("MULTI_TR_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("HIST_DEL_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("HIST_DEL_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("HIST_DEL_USER_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("HIST_DEL_COMMENT");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("SYS_TRAN_TIME"));

            /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
            sheetX.Rows[iRow].Height = sheetX.Rows[iRow].GetPreferredHeight();
            /*** End of Add (2012.04.09) ***/
        }
        public static void PrintLotExtHistoryToSpread(FarPoint.Win.Spread.FpSpread spd, TRSNode his)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int iCol;
            int iRow;
            int i;

            sheetX = spd.ActiveSheet;
            iRow = sheetX.RowCount;
            sheetX.RowCount++;

            iCol = 0;

            if (his.GetChar("HIST_DEL_FLAG") == 'Y')
            {
                sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
            }
            else
            {
                sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
            }

            sheetX.Cells[iRow, iCol].Value = his.GetInt("HIST_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("TRAN_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("MAT_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("MAT_VER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("FLOW");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("FLOW_SEQ_NUM");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OPER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("QTY_1"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("QTY_2"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("QTY_3"));

            for (i = 11; i < sheetX.ColumnHeader.Columns.Count; i++)
            {
                iCol++;

                if (his.GetList("EXT").Count == 0)
                    continue;

                if (his.GetList("EXT")[0].GetMember(sheetX.ColumnHeader.Cells[0, i].Tag.ToString()) == null)
                    continue;

                if(his.GetList("EXT")[0].GetMember(sheetX.ColumnHeader.Cells[0, i].Tag.ToString()).ValueType==TRSDataType.String)
                    sheetX.Cells[iRow, iCol].Value =his.GetList("EXT")[0].GetString(sheetX.ColumnHeader.Cells[0, i].Tag.ToString());
                else if (his.GetList("EXT")[0].GetMember(sheetX.ColumnHeader.Cells[0, i].Tag.ToString()).ValueType == TRSDataType.Char)
                    sheetX.Cells[iRow, iCol].Value = his.GetList("EXT")[0].GetChar(sheetX.ColumnHeader.Cells[0, i].Tag.ToString()).ToString();
                else if (his.GetList("EXT")[0].GetMember(sheetX.ColumnHeader.Cells[0, i].Tag.ToString()).ValueType == TRSDataType.Int)
                    sheetX.Cells[iRow, iCol].Value = his.GetList("EXT")[0].GetInt(sheetX.ColumnHeader.Cells[0, i].Tag.ToString()).ToString();
                else if (his.GetList("EXT")[0].GetMember(sheetX.ColumnHeader.Cells[0, i].Tag.ToString()).ValueType == TRSDataType.Double)
                    sheetX.Cells[iRow, iCol].Value = his.GetList("EXT")[0].GetDouble(sheetX.ColumnHeader.Cells[0, i].Tag.ToString()).ToString();
            }

        }

        public static void PrintLotHistoryForStepToSpread(FarPoint.Win.Spread.FpSpread spd, TRSNode his)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;
            int iCol;

            sheetX = spd.ActiveSheet;
            iRow = sheetX.RowCount;
            sheetX.RowCount++;

            iCol = 0;

            if (his.GetChar("HIST_DEL_FLAG") == 'Y')
            {
                sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
            }
            else
            {
                sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
            }

            sheetX.Cells[iRow, iCol].Value = his.GetInt("HIST_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CODE");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("TRAN_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("FACTORY");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("MAT_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("MAT_VER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("FLOW");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("FLOW_SEQ_NUM");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("OPER");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("STEP");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("START_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("END_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetInt("LOT_HIST_SEQ");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("OPER_TRAN_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_USER_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_COMMENT");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_1");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_2");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_3");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_4");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_5");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_6");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_7");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_8");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_9");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_10");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_11");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_12");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_13");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_14");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_15");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_16");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_17");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_18");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_19");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_20");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetChar("HIST_DEL_FLAG");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("HIST_DEL_TIME"));

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("HIST_DEL_USER_ID");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = his.GetString("HIST_DEL_COMMENT");

            iCol++;
            sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("SYS_TRAN_TIME"));
        }
        
        // ViewSublotHistory()
        //       - View Sublot History
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sSublotID As String                    : Sublot id
        //        - Optional ByVal sFromTime As String = ""   : ?úÏûë ?úÍ∞Ñ
        //        - Optional ByVal sToTime As String = ""     : ÎßàÏ?Îß??úÍ∞Ñ
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete HistoryÍπåÏ? ?¨Ìï®??Í≤ÉÏù∏ÏßÄ?
        //       - Optional ByVal sTreeItem As String = ""           : Tree Item Í∞?
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨ Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏ÏßÄ?
        //       - Optional ByVal sTranCode as string =""    : Transaction Code Î™?
        //
        public static bool ViewSublotHistory(Control control, char c_step, string sSublotID, string sFromTime, string sToTime, char sIncludeDelHistory, TreeNode parentNode, bool bIgnoreError, string sTranCode)
        {
            
            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;
            int iCol;
            int iHistIcon;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_HISTORY_OUT");

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
            in_node.AddString("SUBLOT_ID", sSublotID);
            in_node.AddString("FROM_TRAN_TIME", sFromTime);
            in_node.AddString("TO_TRAN_TIME", sToTime);
            in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDelHistory);
            in_node.AddString("TRAN_CODE", sTranCode);
            in_node.AddInt("HIST_SEQ", int.MaxValue);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG") == 'Y' && sIncludeDelHistory != 'Y')
                    {
                        continue;
                    }

                    if (out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG") == 'Y')
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

                        if (out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG") == 'Y')
                        {
                            sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FACTORY");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER_DESC");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("SLOT_NO");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CRR_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OWNER_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_STATUS");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SUBLOT_TYPE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SYS_TRAN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("HOLD_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("HOLD_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("INV_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("TRANSIT_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("UNIT_EXIST_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("INV_UNIT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("HOLD_PRV_GRP_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("RWK_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("RWK_COUNT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_RET_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("RWK_RET_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_RET_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_END_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("RWK_END_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_END_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("RWK_RET_CLEAR_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RWK_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("NSTD_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("NSTD_RET_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("NSTD_RET_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("NSTD_RET_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("NSTD_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("REP_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("REP_RET_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("STR_RET_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("STR_RET_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("STR_RET_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("START_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("START_RES_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("START_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("START_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("END_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("END_RES_ID");

                        iCol++;

                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SAMPLE_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SAMPLE_WAIT_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SAMPLE_RESULT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RESERVE_RES_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_LOCATION");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_2");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_3");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_4");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_5");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_6");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_7");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_8");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_9");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_10");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_11");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_12");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_13");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_14");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_15");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_16");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_17");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_18");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_19");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_20");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SUBLOT_DEL_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_DEL_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SUBLOT_DEL_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("GRADE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("GRADE_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CELL_GRADE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_BASE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("LOT_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OLD_FACTORY");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OLD_MAT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("OLD_MAT_VER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OLD_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("OLD_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OLD_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OLD_CRR_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("OLD_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OLD_OWNER_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OLD_CREATE_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_2");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_3");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_4");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_5");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_6");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_7");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_8");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_9");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_10");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_11");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_12");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_13");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_14");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_15");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_16");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_17");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_18");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_19");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_20");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_USER_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_COMMENT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("PREV_ACTIVE_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MULTI_TR_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MULTI_TR_KEY");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("HIST_DEL_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("HIST_DEL_USER_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("HIST_DEL_COMMENT");

                        iCol++;

                    }
                    else if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("HIST_SEQ").ToString(), iHistIcon);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("TRAN_TIME") + " : " + out_node.GetList(0)[i].GetString("TRAN_CODE"), (int)SMALLICON_INDEX.IDX_HISTORY, (int)SMALLICON_INDEX.IDX_HISTORY);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("TRAN_CODE"));
                    }
                }

                in_node.SetInt("HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

            } while (in_node.GetInt("HIST_SEQ") > 0);

            return true;
        }


        public static bool ViewFactoryShiftList(Control control, char c_step)
        {
            
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (MPCR.CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("SHIFT_1_START") != "")
            {
                itmX = new ListViewItem("1", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                if (((ListView)control).Columns.Count > 1)
                {
                    itmX.SubItems.Add(out_node.GetString("SHIFT_1_START"));
                }
                ((ListView)control).Items.Add(itmX);
            }
            if (out_node.GetString("SHIFT_2_START") != "")
            {
                itmX = new ListViewItem("2", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                if (((ListView)control).Columns.Count > 1)
                {
                    itmX.SubItems.Add(out_node.GetString("SHIFT_2_START"));
                }
                ((ListView)control).Items.Add(itmX);
            }
            if (out_node.GetString("SHIFT_3_START") != "")
            {
                itmX = new ListViewItem("3", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                if (((ListView)control).Columns.Count > 1)
                {
                    itmX.SubItems.Add(out_node.GetString("SHIFT_3_START"));
                }
                ((ListView)control).Items.Add(itmX);
            }
            if (out_node.GetString("SHIFT_4_START") != "")
            {
                itmX = new ListViewItem("4", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                if (((ListView)control).Columns.Count > 1)
                {
                    itmX.SubItems.Add(out_node.GetString("SHIFT_4_START"));
                }
                ((ListView)control).Items.Add(itmX);
            }
            return true;
        }


        public static bool ViewLotList(Control control, char c_step, TreeNode parentNode)
        {
            return ViewLotList(control, c_step, "", "", "", 0, parentNode);
        }

        public static bool ViewLotList(Control control, char c_step, string sOper, string sFlow, string sMatID, int iMatVer, TreeNode parentNode)
        {            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
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

            in_node.AddString("OPER", sOper);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);

            do
            {
                out_node = new TRSNode("VIEW_LOT_LIST_OUT");

                if (MPCR.CallService("WIP", "WIP_View_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));

            } while (in_node.GetString("NEXT_LOT_ID") != "");


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("LOT_ID"), (int)SMALLICON_INDEX.IDX_LOT);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("LOT_ID"), (int)SMALLICON_INDEX.IDX_LOT, (int)SMALLICON_INDEX.IDX_LOT);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("LOT_ID"));
                    }
                }
            }

            return true;
            
        }

        public static bool ViewLotListDetail(Control control, char c_step, string[] lot_list, string mat_id, string flow, string oper, string res_id, string table_name1, string table_name2, string table_name3, string grp_1, string grp_2, string grp_3, string from_time, string to_time, char lot_deleted_flag, char zero_qty_flag)
        {

            int i;
            int i_cur;

            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
            TRSNode list_item;

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
            in_node.AddString("MAT_ID", mat_id);
            in_node.AddString("FLOW", flow);
            in_node.AddString("OPER", oper);
            in_node.AddString("RES_ID", res_id);
            in_node.AddString("TABLE_NAME_1", table_name1);
            in_node.AddString("TABLE_NAME_2", table_name2);
            in_node.AddString("TABLE_NAME_3", table_name3);
            in_node.AddString("GRP_1", grp_1);
            in_node.AddString("GRP_2", grp_2);
            in_node.AddString("GRP_3", grp_3);
            in_node.AddString("FROM_TIME", from_time);
            in_node.AddString("TO_TIME", to_time);
            in_node.AddChar("LOT_DEL_FLAG", lot_deleted_flag);
            in_node.AddChar("ZERO_QTY_FLAG", zero_qty_flag);

            if (lot_list == null)
            {
                return false;
            }
            if(lot_list.Length < 1)
            {
                return false;
            }

            i_cur = 0;
            do
            {
                if (lot_list.Length - i_cur > 50)
                {
                    for (i = 0; i < 50; i++)
                    {
                        list_item = in_node.AddNode("LIST");
                        list_item.AddString("LOT_ID", lot_list[i_cur]);
                        i_cur++;
                    }
                }
                else
                {
                    for (i = 0; i < lot_list.Length; i++)
                    {
                        list_item = in_node.AddNode("LIST");
                        list_item.AddString("LOT_ID", lot_list[i_cur]);
                        i_cur++;
                    }
                }

                if (MPCR.CallService("WIP", "WIP_View_Lot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    DisplayLotListDetail(control, out_node.GetList(0)[i], 0);
                }

            } while (lot_list.Length - i_cur > 0);

            return true;

        }

        public static void DisplayLotListDetail(Control control, TRSNode lot_info, int proc_step)
        {
            int iRow;
            int iCol;
            ListViewItem itmX;
            FarPoint.Win.Spread.SheetView sheet;

            if (control is ListView)
            {

                iRow = ((ListView) control).Items.Count + 1;
                itmX = new ListViewItem(iRow.ToString());

                if (proc_step == 1)
                {
                    itmX.SubItems.Add(lot_info.GetString("FACTORY"));
                }

                itmX.SubItems.Add(lot_info.GetString("LOT_ID"));
                itmX.SubItems.Add(lot_info.GetString("MAT_ID"));
                itmX.SubItems.Add(lot_info.GetInt("MAT_VER").ToString());
                itmX.SubItems.Add(lot_info.GetString("FLOW"));
                itmX.SubItems.Add(lot_info.GetInt("FLOW_SEQ_NUM").ToString());
                itmX.SubItems.Add(lot_info.GetString("OPER"));

                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_1")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_2")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_3")));
                //itmX.SubItems.Add(MPCF.Format(lot_info.Get("QTY_1,") "########,##0.###"));
                //itmX.SubItems.Add(MPCF.Format(lot_info.Get("QTY_2,") "########,##0.###"));
                //itmX.SubItems.Add(MPCF.Format(lot_info.Get("QTY_3,") "########,##0.###"));

                itmX.SubItems.Add(lot_info.GetChar("LOT_TYPE").ToString());
                itmX.SubItems.Add(lot_info.GetString("OWNER_CODE"));
                itmX.SubItems.Add(lot_info.GetString("CREATE_CODE"));
                itmX.SubItems.Add(lot_info.GetChar("LOT_PRIORITY").ToString());
                itmX.SubItems.Add(lot_info.GetString("LOT_STATUS"));
                itmX.SubItems.Add(lot_info.GetChar("HOLD_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("HOLD_CODE"));

                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_1")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_2")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_3")));

                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_1")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_2")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_3")));

                itmX.SubItems.Add(lot_info.GetChar("INV_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetChar("TRANSIT_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetChar("UNIT_EXIST_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("INV_UNIT"));

                itmX.SubItems.Add(lot_info.GetChar("RWK_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("RWK_CODE"));
                itmX.SubItems.Add(lot_info.GetInt("RWK_COUNT").ToString());
                itmX.SubItems.Add(lot_info.GetString("RWK_RET_FLOW"));
                itmX.SubItems.Add(lot_info.GetString("RWK_RET_OPER"));
                itmX.SubItems.Add(lot_info.GetString("RWK_END_FLOW"));
                itmX.SubItems.Add(lot_info.GetString("RWK_END_OPER"));
                itmX.SubItems.Add(lot_info.GetChar("RWK_RET_CLEAR_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("RWK_TIME")));

                itmX.SubItems.Add(lot_info.GetChar("NSTD_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("NSTD_RET_FLOW"));
                itmX.SubItems.Add(lot_info.GetString("NSTD_RET_OPER"));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("NSTD_TIME")));

                itmX.SubItems.Add(lot_info.GetChar("REP_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("REP_OPER"));

                itmX.SubItems.Add(lot_info.GetString("STR_RET_FLOW"));
                itmX.SubItems.Add(lot_info.GetInt("STR_RET_FLOW_SEQ_NUM").ToString());
                itmX.SubItems.Add(lot_info.GetString("STR_RET_OPER"));

                itmX.SubItems.Add(lot_info.GetChar("START_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("START_TIME")));
                itmX.SubItems.Add(lot_info.GetString("START_RES_ID"));
                itmX.SubItems.Add(lot_info.GetChar("END_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("END_TIME")));
                itmX.SubItems.Add(lot_info.GetString("END_RES_ID"));

                itmX.SubItems.Add(lot_info.GetChar("SAMPLE_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetChar("SAMPLE_WAIT_FLAG").ToString());

                switch (lot_info.GetChar("SAMPLE_RESULT"))
                {
                    case 'Y':

                        itmX.SubItems.Add("Good");
                        break;
                    case 'N':

                        itmX.SubItems.Add("No Good");
                        break;
                    default:

                        itmX.SubItems.Add("");
                        break;
                }
                itmX.SubItems.Add(lot_info.GetString("FROM_TO_LOT_ID"));
                itmX.SubItems.Add(lot_info.GetString("SHIP_CODE"));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("SHIP_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("CREATE_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("FAC_IN_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("FLOW_IN_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("OPER_IN_TIME")));
                itmX.SubItems.Add(lot_info.GetString("RESERVE_RES_ID"));
                itmX.SubItems.Add(lot_info.GetString("BATCH_ID"));
                itmX.SubItems.Add(MPCF.Format("#######,##0", lot_info.GetInt("BATCH_SEQ")));
                itmX.SubItems.Add(lot_info.GetString("ORDER_ID"));
                itmX.SubItems.Add(lot_info.GetString("ADD_ORDER_ID_1"));
                itmX.SubItems.Add(lot_info.GetString("ADD_ORDER_ID_2"));
                itmX.SubItems.Add(lot_info.GetString("ADD_ORDER_ID_3"));
                itmX.SubItems.Add(lot_info.GetString("LOT_LOCATION"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_1"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_2"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_3"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_4"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_5"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_6"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_7"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_8"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_9"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_10"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_11"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_12"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_13"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_14"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_15"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_16"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_17"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_18"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_19"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_20"));
                itmX.SubItems.Add(lot_info.GetString("BOM_SET_ID"));
                itmX.SubItems.Add(MPCF.Trim(lot_info.GetInt("BOM_SET_VERSION")));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_info.GetInt("BOM_ACTIVE_HIST_SEQ")));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_info.GetInt("BOM_HIST_SEQ")));

                itmX.SubItems.Add(lot_info.GetChar("LOT_DEL_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("LOT_DEL_TIME")));
                itmX.SubItems.Add(lot_info.GetString("LOT_DEL_CODE"));

                itmX.SubItems.Add(lot_info.GetString("LAST_TRAN_CODE"));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("LAST_TRAN_TIME")));
                itmX.SubItems.Add(lot_info.GetString("LAST_COMMENT"));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_info.GetInt("LAST_ACTIVE_HIST_SEQ")));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_info.GetInt("LAST_HIST_SEQ")));

                if (lot_info.GetChar("HOLD_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                }
                else if (lot_info.GetChar("START_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_START;
                }
                else if (lot_info.GetChar("RWK_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                }
                else if (lot_info.GetChar("NSTD_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                }
                else if (lot_info.GetString("LAST_TRAN_CODE") == MPGC.MP_TRAN_CODE_RELEASE)
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                }
                else if (lot_info.GetChar("REP_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                }
                else
                {
                    itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                }

                ((ListView) control).Items.Add(itmX);

            }
            else if (control is FarPoint.Win.Spread.FpSpread)
            {

                sheet = ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet;
                iRow = sheet.RowCount;
                sheet.RowCount++;
                iCol = 0;

                if (proc_step == 1)
                {
                    sheet.Cells[iRow, iCol].Value = lot_info.GetString("FACTORY");

                    iCol++;
                }
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("MAT_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetInt("MAT_VER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetInt("FLOW_SEQ_NUM");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_1"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_2"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_3"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("LOT_TYPE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("OWNER_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("CREATE_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("LOT_PRIORITY");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_STATUS");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("HOLD_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("HOLD_CODE");

                iCol++;

                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_1"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_2"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_3"));

                iCol++;

                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_1"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_2"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_3"));

                iCol++;


                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("INV_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("TRANSIT_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("UNIT_EXIST_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("INV_UNIT");

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("RWK_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetInt("RWK_COUNT");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_RET_FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_RET_OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_END_FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_END_OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("RWK_RET_CLEAR_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("RWK_TIME"));

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("NSTD_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("NSTD_RET_FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("NSTD_RET_OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("NSTD_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("REP_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("REP_OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("STR_RET_FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetInt("STR_RET_FLOW_SEQ_NUM");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("STR_RET_OPER");
                
                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("START_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("START_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("START_RES_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("END_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("END_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("END_RES_ID");

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("SAMPLE_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("SAMPLE_WAIT_FLAG");

                iCol++;
                switch (lot_info.GetChar("SAMPLE_RESULT"))
                {
                    case 'Y':

                        sheet.Cells[iRow, iCol].Value = "Good";
                        break;
                    case 'N':

                        sheet.Cells[iRow, iCol].Value = "No Good";
                        break;
                    default:

                        sheet.Cells[iRow, iCol].Value = "";
                        break;
                }
                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("FROM_TO_LOT_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("SHIP_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("SHIP_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
        
                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("CREATE_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("FAC_IN_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("FLOW_IN_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("OPER_IN_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RESERVE_RES_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("BATCH_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("#######,##0", lot_info.GetInt("BATCH_SEQ"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("ORDER_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("ADD_ORDER_ID_1");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("ADD_ORDER_ID_2");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("ADD_ORDER_ID_3");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_LOCATION");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_1");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_2");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_3");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_4");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_5");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_6");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_7");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_8");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_9");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_10");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_11");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_12");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_13");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_14");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_15");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_16");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_17");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_18");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_19");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_20");

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetString("BOM_SET_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Trim(lot_info.GetInt("BOM_SET_VERSION"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", lot_info.GetInt("BOM_ACTIVE_HIST_SEQ"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", lot_info.GetInt("BOM_HIST_SEQ"));

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("LOT_DEL_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_DEL_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("LOT_DEL_TIME"));

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LAST_TRAN_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("LAST_TRAN_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LAST_COMMENT");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", lot_info.GetInt("LAST_ACTIVE_HIST_SEQ"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", lot_info.GetInt("LAST_HIST_SEQ"));

                iCol++;

                if (lot_info.GetChar("LOT_DEL_FLAG") == 'Y')
                {
                    sheet.Rows[iRow].ForeColor = Color.Magenta;
                }

            }

        }

        /* 2013.06.12. Aiden. Lot Extension ¿ª «•Ω√«œ¥¬ ±‚¥… √ﬂ∞° */
        public static void DisplayLotListDetailExt(Control control, TRSNode lot_info, int proc_step)
        {
            int iRow;
            int iCol;
            ListViewItem itmX;
            FarPoint.Win.Spread.SheetView sheet;

            if (control is ListView)
            {

                iRow = ((ListView) control).Items.Count + 1;
                itmX = new ListViewItem(iRow.ToString());

                if (proc_step == 1)
                {
                    itmX.SubItems.Add(lot_info.GetString("FACTORY"));
                }

                itmX.SubItems.Add(lot_info.GetString("LOT_ID"));
                itmX.SubItems.Add(lot_info.GetString("MAT_ID"));
                itmX.SubItems.Add(lot_info.GetInt("MAT_VER").ToString());
                itmX.SubItems.Add(lot_info.GetString("FLOW"));
                itmX.SubItems.Add(lot_info.GetInt("FLOW_SEQ_NUM").ToString());
                itmX.SubItems.Add(lot_info.GetString("OPER"));

                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_1")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_2")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_3")));

                itmX.SubItems.Add(lot_info.GetChar("LOT_TYPE").ToString());
                itmX.SubItems.Add(lot_info.GetString("OWNER_CODE"));
                itmX.SubItems.Add(lot_info.GetString("CREATE_CODE"));
                itmX.SubItems.Add(lot_info.GetChar("LOT_PRIORITY").ToString());
                itmX.SubItems.Add(lot_info.GetString("LOT_STATUS"));
                itmX.SubItems.Add(lot_info.GetChar("HOLD_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("HOLD_CODE"));

                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_1")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_2")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_3")));

                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_1")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_2")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_3")));

                itmX.SubItems.Add(lot_info.GetChar("INV_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetChar("TRANSIT_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetChar("UNIT_EXIST_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("INV_UNIT"));

                itmX.SubItems.Add(lot_info.GetChar("RWK_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("RWK_CODE"));
                itmX.SubItems.Add(lot_info.GetInt("RWK_COUNT").ToString());
                itmX.SubItems.Add(lot_info.GetString("RWK_RET_FLOW"));
                itmX.SubItems.Add(lot_info.GetString("RWK_RET_OPER"));
                itmX.SubItems.Add(lot_info.GetString("RWK_END_FLOW"));
                itmX.SubItems.Add(lot_info.GetString("RWK_END_OPER"));
                itmX.SubItems.Add(lot_info.GetChar("RWK_RET_CLEAR_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("RWK_TIME")));

                itmX.SubItems.Add(lot_info.GetChar("NSTD_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("NSTD_RET_FLOW"));
                itmX.SubItems.Add(lot_info.GetString("NSTD_RET_OPER"));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("NSTD_TIME")));

                itmX.SubItems.Add(lot_info.GetChar("REP_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetString("REP_OPER"));

                itmX.SubItems.Add(lot_info.GetString("STR_RET_FLOW"));
                itmX.SubItems.Add(lot_info.GetInt("STR_RET_FLOW_SEQ_NUM").ToString());
                itmX.SubItems.Add(lot_info.GetString("STR_RET_OPER"));

                itmX.SubItems.Add(lot_info.GetChar("START_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("START_TIME")));
                itmX.SubItems.Add(lot_info.GetString("START_RES_ID"));
                itmX.SubItems.Add(lot_info.GetChar("END_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("END_TIME")));
                itmX.SubItems.Add(lot_info.GetString("END_RES_ID"));

                itmX.SubItems.Add(lot_info.GetChar("SAMPLE_FLAG").ToString());
                itmX.SubItems.Add(lot_info.GetChar("SAMPLE_WAIT_FLAG").ToString());

                switch (lot_info.GetChar("SAMPLE_RESULT"))
                {
                    case 'Y':

                        itmX.SubItems.Add("Good");
                        break;
                    case 'N':

                        itmX.SubItems.Add("No Good");
                        break;
                    default:

                        itmX.SubItems.Add("");
                        break;
                }
                itmX.SubItems.Add(lot_info.GetString("FROM_TO_LOT_ID"));
                itmX.SubItems.Add(lot_info.GetString("SHIP_CODE"));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("SHIP_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("CREATE_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("FAC_IN_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("FLOW_IN_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("OPER_IN_TIME")));
                itmX.SubItems.Add(lot_info.GetString("RESERVE_RES_ID"));
                itmX.SubItems.Add(lot_info.GetString("BATCH_ID"));
                itmX.SubItems.Add(MPCF.Format("#######,##0", lot_info.GetInt("BATCH_SEQ")));
                itmX.SubItems.Add(lot_info.GetString("ORDER_ID"));
                itmX.SubItems.Add(lot_info.GetString("ADD_ORDER_ID_1"));
                itmX.SubItems.Add(lot_info.GetString("ADD_ORDER_ID_2"));
                itmX.SubItems.Add(lot_info.GetString("ADD_ORDER_ID_3"));
                itmX.SubItems.Add(lot_info.GetString("LOT_LOCATION"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_1"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_2"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_3"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_4"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_5"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_6"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_7"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_8"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_9"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_10"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_11"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_12"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_13"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_14"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_15"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_16"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_17"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_18"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_19"));
                itmX.SubItems.Add(lot_info.GetString("LOT_CMF_20"));
                itmX.SubItems.Add(lot_info.GetString("BOM_SET_ID"));
                itmX.SubItems.Add(MPCF.Trim(lot_info.GetInt("BOM_SET_VERSION")));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_info.GetInt("BOM_ACTIVE_HIST_SEQ")));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_info.GetInt("BOM_HIST_SEQ")));

                itmX.SubItems.Add(lot_info.GetChar("LOT_DEL_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("LOT_DEL_TIME")));
                itmX.SubItems.Add(lot_info.GetString("LOT_DEL_CODE"));

                itmX.SubItems.Add(lot_info.GetString("LAST_TRAN_CODE"));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_info.GetString("LAST_TRAN_TIME")));
                itmX.SubItems.Add(lot_info.GetString("LAST_COMMENT"));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_info.GetInt("LAST_ACTIVE_HIST_SEQ")));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_info.GetInt("LAST_HIST_SEQ")));

                if (lot_info.GetChar("HOLD_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                }
                else if (lot_info.GetChar("START_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_START;
                }
                else if (lot_info.GetChar("RWK_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                }
                else if (lot_info.GetChar("NSTD_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                }
                else if (lot_info.GetString("LAST_TRAN_CODE") == MPGC.MP_TRAN_CODE_RELEASE)
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                }
                else if (lot_info.GetChar("REP_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                }
                else
                {
                    itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                }

                ((ListView) control).Items.Add(itmX);

            }
            else if (control is FarPoint.Win.Spread.FpSpread)
            {

                sheet = ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet;
                iRow = sheet.RowCount;
                sheet.RowCount++;
                iCol = 0;

                if (proc_step == 1)
                {
                    sheet.Cells[iRow, iCol].Value = lot_info.GetString("FACTORY");

                    iCol++;
                }
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("MAT_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetInt("MAT_VER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetInt("FLOW_SEQ_NUM");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_1"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_2"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("QTY_3"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("LOT_TYPE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("OWNER_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("CREATE_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("LOT_PRIORITY");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_STATUS");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("HOLD_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("HOLD_CODE");

                iCol++;

                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_1"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_2"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("CREATE_QTY_3"));

                iCol++;

                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_1"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_2"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", lot_info.GetDouble("OPER_IN_QTY_3"));

                iCol++;


                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("INV_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("TRANSIT_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("UNIT_EXIST_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("INV_UNIT");

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("RWK_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetInt("RWK_COUNT");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_RET_FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_RET_OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_END_FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RWK_END_OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("RWK_RET_CLEAR_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("RWK_TIME"));

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("NSTD_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("NSTD_RET_FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("NSTD_RET_OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("NSTD_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("REP_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("REP_OPER");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("STR_RET_FLOW");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetInt("STR_RET_FLOW_SEQ_NUM");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("STR_RET_OPER");
                
                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("START_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("START_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("START_RES_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("END_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("END_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("END_RES_ID");

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("SAMPLE_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("SAMPLE_WAIT_FLAG");

                iCol++;
                switch (lot_info.GetChar("SAMPLE_RESULT"))
                {
                    case 'Y':

                        sheet.Cells[iRow, iCol].Value = "Good";
                        break;
                    case 'N':

                        sheet.Cells[iRow, iCol].Value = "No Good";
                        break;
                    default:

                        sheet.Cells[iRow, iCol].Value = "";
                        break;
                }
                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("FROM_TO_LOT_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("SHIP_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("SHIP_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("CREATE_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("FAC_IN_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("FLOW_IN_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("OPER_IN_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("RESERVE_RES_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("BATCH_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("#######,##0", lot_info.GetInt("BATCH_SEQ"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("ORDER_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("ADD_ORDER_ID_1");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("ADD_ORDER_ID_2");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("ADD_ORDER_ID_3");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_LOCATION");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_1");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_2");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_3");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_4");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_5");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_6");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_7");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_8");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_9");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_10");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_11");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_12");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_13");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_14");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_15");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_16");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_17");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_18");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_19");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_CMF_20");

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetString("BOM_SET_ID");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Trim(lot_info.GetInt("BOM_SET_VERSION"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", lot_info.GetInt("BOM_ACTIVE_HIST_SEQ"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", lot_info.GetInt("BOM_HIST_SEQ"));

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetChar("LOT_DEL_FLAG");

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LOT_DEL_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("LOT_DEL_TIME"));

                iCol++;

                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LAST_TRAN_CODE");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_info.GetString("LAST_TRAN_TIME"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = lot_info.GetString("LAST_COMMENT");

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", lot_info.GetInt("LAST_ACTIVE_HIST_SEQ"));

                iCol++;
                sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", lot_info.GetInt("LAST_HIST_SEQ"));

                iCol++;

                if (lot_info.GetChar("LOT_DEL_FLAG") == 'Y')
                {
                    sheet.Rows[iRow].ForeColor = Color.Magenta;
                }

            }

        }


        // ViewProcessOperationList()
        //       - View Process Operation List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - ByVal sLotId As String                    : Lot ID
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú Ï∂îÍ???Node
        //
        public static bool ViewProcessedOperationList(Control control, char c_step, string sLotId, TreeNode parentNode)
        {
            
            int i;
            int img_idx;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_PROCESS_OPER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_PROCESS_OPER_LIST_OUT");

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
            in_node.AddString("LOT_ID", sLotId);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Process_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetChar("OPER_PROC_FLAG") == 'Y')
                    {
                        img_idx =  (int)SMALLICON_INDEX.IDX_LOT_CHECK;
                    }
                    else
                    {
                        img_idx =  (int)SMALLICON_INDEX.IDX_OPER;
                    }

                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("OPER"), img_idx);
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("OPER"), img_idx, img_idx);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("OPER"));

                    }
                }

                in_node.SetString("NEXT_FLOW", out_node.GetString("NEXT_FLOW"));
                in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));
            } while (in_node.GetString("NEXT_FLOW") != "" || in_node.GetString("NEXT_OPER") != "");

            return true;
        }


        public static bool ViewSublotList(Control control, char c_step, string sLotId, TreeNode parentNode)
        {
            
            int i;
            ListViewItem itm;
            TreeNode nodeX;
            int i_cur_slot_count;
            int i_empty;
            int i_max_slot_count;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
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
            in_node.AddString("LOT_ID", sLotId);

            i_cur_slot_count = 0;

            do
            {
                out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");

                if (MPCR.CallService("WIP", "WIP_View_Sublot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        if ((out_node.GetList(0)[i].GetInt("SLOT_NO") - i_cur_slot_count) > 1)
                        {
                            for (i_empty = i_cur_slot_count + 1; i_empty < out_node.GetList(0)[i].GetInt("SLOT_NO"); i_empty++)
                            {
                                itm = new ListViewItem(i_empty.ToString(), (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                                itm.SubItems.Add("");
                                itm.SubItems.Add("");
                                itm.SubItems.Add("");
                                itm.SubItems.Add("");

                                ((ListView)control).Items.Add(itm);
                            }
                        }

                        itm = new ListViewItem(out_node.GetList(0)[i].GetInt("SLOT_NO").ToString(), (int)SMALLICON_INDEX.IDX_SLOT_FULL);
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_ID"));
                        itm.SubItems.Add(sLotId);
                        itm.SubItems.Add(out_node.GetList(0)[i].GetChar("GRADE").ToString());
                        itm.SubItems.Add("");
                        itm.Tag = out_node.GetList(0)[i].GetDouble("QTY_2");
                        ((ListView)control).Items.Add(itm);

                        i_cur_slot_count = out_node.GetList(0)[i].GetInt("SLOT_NO");
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("SUBLOT_ID"), (int)SMALLICON_INDEX.IDX_LOT, (int)SMALLICON_INDEX.IDX_SUB_LOT);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("SLOT_NO").ToString() + " : " + out_node.GetList(0)[i].GetString("SUBLOT_ID"));
                    }
                }
            }

            if (control is ListView)
            {
                i_max_slot_count = MPGO.MaxSubLotSlotCount();
                for (i = i_cur_slot_count + 1; i <= i_max_slot_count; i++)
                {
                    itm = new ListViewItem(i.ToString(), (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");

                    ((ListView)control).Items.Add(itm);
                }
            }

            return true;


        }

        public static bool ViewRuleList(Control control, char cgen_type, bool b_only_this_factory, string sExt_Factory)
        {
            int i;
            int i_icon_index;
            TRSNode in_node = new TRSNode("RULE_LIST_IN");
            TRSNode out_node = new TRSNode("RULE_LIST_OUT");
            ListViewItem itmX;

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

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }

            in_node.AddChar("GEN_TYPE", cgen_type);

            if (b_only_this_factory == false)
            {
                if (((ListView)control).Columns.Count < 3)
                {
                    ((ListView)control).Columns.Add(MPCF.FindLanguage("Factory", 0), 150, HorizontalAlignment.Left);
                }
            }
            else
            {
                in_node.AddChar("ONLY_THIS_FACTORY_FLAG", 'Y');

                if (((ListView)control).Columns.Count > 2)
                {
                    while (((ListView)control).Columns.Count > 2)
                    {
                        ((ListView)control).Columns.RemoveAt(((ListView)control).Columns.Count - 1);
                    }
                }
            }

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_ID_Rule_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        i_icon_index = (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE;
                        if (b_only_this_factory == false && out_node.GetList(0)[i].GetString("FACTORY") != MPGV.gsFactory)
                        {
                            i_icon_index = (int)SMALLICON_INDEX.IDX_VERSION_REQUEST;
                        }
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RULE_ID"), i_icon_index);
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RULE_DESC"));
                        if (b_only_this_factory == false)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FACTORY"));
                        }

                        ((ListView)control).Items.Add(itmX);
                    }
                }

                in_node.SetString("NEXT_RULE_ID", out_node.GetString("NEXT_RULE_ID"));
            } while (in_node.GetString("NEXT_RULE_ID") != "");

            MPCF.FitColumnHeader(control);

            return true;
        }

        public static bool ViewRuleDefinitionList(Control control, char c_step, string sRule_ID, int i_seq)
        {
            int i;
            TRSNode in_node = new TRSNode("RULE_LIST_IN");
            TRSNode out_node = new TRSNode("RULE_LIST_OUT");
            ListViewItem itmX;

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

            in_node.AddString("RULE_ID", sRule_ID);
            if (c_step == '2')
            {
                in_node.AddInt("NEXT_RULE_SEQ", i_seq);
            }

            if (MPCR.CallService("WIP", "WIP_View_Rule_Def_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (control is ListView)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("RULE_SEQ").ToString(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                    if (out_node.GetList(0)[i].GetChar("RULE_TYPE") == 'F')
                    {
                        itmX.SubItems.Add("Fixed String");
                    }
                    else if (out_node.GetList(0)[i].GetChar("RULE_TYPE") == 'V')
                    {
                        itmX.SubItems.Add("Field Value");
                    }
                    else if (out_node.GetList(0)[i].GetChar("RULE_TYPE") == 'D')
                    {
                        itmX.SubItems.Add("Date Time Value");
                    }
                    else if (out_node.GetList(0)[i].GetChar("RULE_TYPE") == 'S')
                    {
                        itmX.SubItems.Add("Sequence Value");
                    }
                    else if (out_node.GetList(0)[i].GetChar("RULE_TYPE") == 'B')
                    {
                        itmX.SubItems.Add("Blank Value");
                    }
                    
                    ((ListView)control).Items.Add(itmX);
                }
            }

            MPCF.FitColumnHeader(control);

            return true;
        }

        public static bool ViewBatchRuleList(Control control, char c_step)
        {
            int i;
            TRSNode in_node = new TRSNode("RULE_LIST_IN");
            TRSNode out_node = new TRSNode("RULE_LIST_OUT");
            ListViewItem itmX;

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
                if (MPCR.CallService("WIP", "WIP_View_Batch_Rule_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("CRT_RULE_ID"), (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE);
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CRT_RULE_DESC"));
                        
                        ((ListView)control).Items.Add(itmX);
                    }
                }

                in_node.SetString("NEXT_CRT_RULE_ID", out_node.GetString("NEXT_CRT_RULE_ID"));
            } while (in_node.GetString("NEXT_CRT_RULE_ID") != "");

            MPCF.FitColumnHeader(control);

            return true;
        }

        //ViewToolList()
        //      - View Tool List
        //Return Value
        //      - boolean : True / False
        //Arguments
        //      - ByVal control As Control                 : 
        //      - ByVal c_step As String                   : 
        //
        public static bool ViewToolListByMFO(Control control, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, char c_point_type, string s_res_id)
        {
            int i;
            int j;
            ListViewItem itmX;
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
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);
            in_node.AddChar("POINT_TYPE", c_point_type);
            in_node.AddString("RES_ID", s_res_id);

            do
            {
                out_node = new TRSNode("View_Tool_List_Out");

                if (MPCR.CallService("WIP", "WIP_View_Tool_List_By_MFO", in_node, ref out_node) == false)
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
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")), (int)SMALLICON_INDEX.IDX_TOOL);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_DESC")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID")));

                    }
                }
            }

            return true;
        }

        //ViewBinDefList()
        //      - View Bin List
        //Return Value
        //      - boolean : True / False
        //Arguments
        //      - control   : control
        //      - c_step    : process step
        //
        /* 2013.06.12. Aiden. BIN List ø° Filter √ﬂ∞° */
        public static bool ViewBinDefList(Control control, string s_fileter)
        {
            return ViewBinDefList(control, '1', false, s_fileter, null, "");
        }
        public static bool ViewBinDefList(Control control, bool b_incl_delete_bin, string s_fileter)
        {
            return ViewBinDefList(control, '1', b_incl_delete_bin, s_fileter, null, "");
        }
        public static bool ViewBinDefList(Control control, char c_step, bool b_incl_delete_bin, string s_fileter, TreeNode parentNode, string sExtFactory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_BIN_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_LIST_OUT");
            List<TRSNode> bin_list;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
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

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("FILTER", s_fileter);
            in_node.AddChar("INCLUDE_DEL_BIN", b_incl_delete_bin == true ? 'Y' : ' ');

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Bin_Definition_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                bin_list = out_node.GetList("BIN_LIST");
                for (i = 0; i < bin_list.Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(bin_list[i].GetString("BIN_ID"), (int)SMALLICON_INDEX.IDX_PART);

                        if (bin_list[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Magenta;
                        }

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(bin_list[i].GetString("BIN_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(bin_list[i].GetString("BIN_ID") + " : " +
                                             bin_list[i].GetString("BIN_DESC"),
                                             (int)SMALLICON_INDEX.IDX_PART,
                                             (int)SMALLICON_INDEX.IDX_PART);

                        if (bin_list[i].GetChar("DELETE_FLAG") == 'Y')
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
                        ((ComboBox)control).Items.Add(bin_list[i].GetString("BIN_ID"));
                    }
                }

                in_node.SetString("NEXT_BIN_ID", out_node.GetString("NEXT_BIN_ID"));
            } while (in_node.GetString("NEXT_BIN_ID") != "");

            return true;
        }

        //ViewBinVersionList()
        //      - View Bin Version List
        //Return Value
        //      - boolean : True / False
        //Arguments
        //      - control   : control
        //      - c_step    : process step
        //
        public static bool ViewBinVersionList(Control control, string s_bin_id)
        {
            return ViewBinVersionList(control, '1', s_bin_id, false, null, "");
        }
        public static bool ViewBinVersionList(Control control, string s_bin_id, bool b_ascending)
        {
            return ViewBinVersionList(control, '1', s_bin_id, b_ascending, null, "");
        }
        public static bool ViewBinVersionList(Control control, char c_step, string s_bin_id, bool b_ascending, TreeNode parentNode, string sExtFactory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_BIN_VER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_VER_LIST_OUT");
            List<TRSNode> ver_list;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
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

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("BIN_ID", s_bin_id);
            in_node.AddChar("ASCENDING_FLAG", b_ascending == true ? 'Y' : 'N');

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Bin_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                ver_list = out_node.GetList("VER_LIST");
                for (i = 0; i < ver_list.Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(ver_list[i].GetInt("BIN_VERSION").ToString(), (int)SMALLICON_INDEX.IDX_VERSION);
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(ver_list[i].GetInt("BIN_VERSION").ToString(),
                                             (int)SMALLICON_INDEX.IDX_VERSION,
                                             (int)SMALLICON_INDEX.IDX_VERSION);

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
                        ((ComboBox)control).Items.Add(ver_list[i].GetInt("BIN_VERSION").ToString());
                    }
                }

                in_node.SetInt("NEXT_BIN_VERSION", out_node.GetInt("NEXT_BIN_VERSION"));
            } while (in_node.GetInt("NEXT_BIN_VERSION") > 0);

            return true;
        }

    
    
    
    
    
    }    




}
