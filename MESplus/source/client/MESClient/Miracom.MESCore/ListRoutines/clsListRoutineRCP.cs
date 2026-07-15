
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modRCPListRoutine.vb
//   Description : Client Common List function RCP Module
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
//#If _RCP = True Then

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.UI.Controls.MCCodeView;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public sealed class RCPLIST
    {
        
        // ViewRecipeList()
        //       - View Recipe List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - ByVal Resource As String                : Resource
        //       - Optional ByVal sOper As String = ""   : Operation
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //       - Optional ByVal Col As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Column Index (-1?¥Î©¥ ?πÏ†ï Row ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //       - Optional ByVal Row As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Row Index (-1?¥Î©¥ ?πÏ†ï Column ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        
        public static bool ViewRecipeList(Control control, char c_step, string sResource, string sOper, TreeNode parentNode, string sExt_Factory, int Col, int Row)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            string[] strData = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            
            TRSNode in_node = new TRSNode("VIEW_RECIPE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RECIPE_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView) && !(control is FarPoint.Win.Spread.FpSpread))
            {
                MPCF.ClearList(control, true);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }
            in_node.AddString("RES_ID", sResource);
            in_node.AddString("OPER", sOper);

            do
            {
                if (MPCR.CallService("RCP", "RCP_View_Recipe_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    // Skip deleted recipe items
                    if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                    {
                        continue;
                    }

                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RECIPE"), (int)SMALLICON_INDEX.IDX_RECIPE);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RECIPE_DESC"));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("RECIPE") + " : " + out_node.GetList(0)[i].GetString("RECIPE_DESC"), (int)SMALLICON_INDEX.IDX_RECIPE, (int)SMALLICON_INDEX.IDX_RECIPE);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("RECIPE"));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("RECIPE"));
                    }
                }

                in_node.SetString("NEXT_RECIPE", out_node.GetString("NEXT_RECIPE"));
            } while (in_node.GetString("NEXT_RECIPE") != "");

            if (control is FarPoint.Win.Spread.FpSpread)
            {
                strData = new string[sList.Count + 1];
                for (i = 0; i < sList.Count; i++)
                {
                    strData[i] = sList[i];
                }
                strData[i] = "";

                cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cboCellType.Items = strData;
                if (Row == - 1 && Col == - 1)
                {
                    //Do Nothing
                }
                else if (Row == - 1)
                {
                    ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Columns.Get(Col).CellType = cboCellType;
                }
                else if (Col == - 1)
                {
                    ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Rows.Get(Row).CellType = cboCellType;
                }
                else
                {
                    ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Cells.Get(Row, Col).CellType = cboCellType;
                }
            }

            return true;
        }


        // ViewRecipeVersionList()
        //       - View Recipe Version List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - ByVal Resource As String                : Resource
        //       - ByVal sRecipe As String                   : Recipe
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        
        public static bool ViewRecipeVersionList(Control control, char c_step, string sResource, string sRecipe, TreeNode parentNode, string sExt_Factory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_RECIPE_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RECIPE_VERSION_LIST_OUT");

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

            in_node.AddString("RES_ID", sResource);
            in_node.AddString("RECIPE", sRecipe);
            in_node.AddInt("NEXT_RECIPE_VERSION", 0);

            do
            {
                if (MPCR.CallService("RCP", "RCP_View_Recipe_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem( MPCF.Trim(out_node.GetList(0)[i].GetInt("RECIPE_VERSION")), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);

                        if (out_node.GetList(0)[i].GetChar("RELEASE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Magenta;
                        }

                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetInt("RECIPE_VERSION")), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION, (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);

                        if (out_node.GetList(0)[i].GetChar("RELEASE_FLAG") == 'Y')
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("RECIPE_VERSION"));
                    }
                }

                in_node.SetInt("NEXT_RECIPE_VERSION", out_node.GetInt("NEXT_RECIPE_VERSION"));
            } while (in_node.GetInt("NEXT_RECIPE_VERSION") > 0);

            return true;

        }
    }
    //#End If
}
