
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
//   File Name   : modBOMListRoutine.vb
//   Description : Client Common List function BOM Module
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
//#If _BOM = True Then

namespace Miracom.MESCore
{
    public sealed class BOMLIST
    {
        
        //' ViewBOMSetList()
        //'       - View Collection Set List
        //' Return Value
        //'       - boolean : True / False
        //' Arguments
        //'       - ByVal control As Control                    : List∞° µÈæÓ∞• control
        //'        - ByVal c_step As String                        : »Æ¿Â Process Step
        //'        - Optional ByVal iImage_idx As Integer = -1    : List Viewø° µÈæÓ∞• æ∆¿Ãƒ‹ ¿Œµ¶Ω∫
        //'        - Optional ByVal sExt_Factory As String = "": «ˆ¿Á Factory∞° æ∆¥—∞ÊøÏ¿« Factory
        //'        - Optional ByVal sTreeItem As String = ""    : TreeView ø°º≠ √ﬂ∞°«“ Node¿« Text
        //'       - Optional ByVal Col As Integer = -1        : Spread ƒ¡∆Æ∑—¿œ ∞ÊøÏ µ•¿Ã≈∏∏¶ ª—∑¡¡Ÿ Column Index (-1¿Ã∏È ∆Ø¡§ Row ¿¸√ºø° ª—∑¡¡‹)
        //'       - Optional ByVal Row As Integer = -1        : Spread ƒ¡∆Æ∑—¿œ ∞ÊøÏ µ•¿Ã≈∏∏¶ ª—∑¡¡Ÿ Row Index (-1¿Ã∏È ∆Ø¡§ Column ¿¸√ºø° ª—∑¡¡‹)
        
        public static bool ViewBOMSetList(Control control, char c_step, TreeNode parentNode, string sExt_Factory, int Col, int Row, char MatOrdFlag, bool IncludeDeleteSet)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            string[] strData = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;

            TRSNode in_node = new TRSNode("VIEW_BOMSET_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BOMSET_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, false);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;            
            
            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }           
            
            in_node.AddChar("MAT_OR_ORD_FLAG", MatOrdFlag);
            in_node.AddString("NEXT_BOM_SET_ID", "");

            do
            {
                if (MPCR.CallService("BOM", "BOM_View_BOMSet_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (IncludeDeleteSet == false && MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "Y")
                    {
                        continue;
                    }

                    if (control is ListView)
                    {
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG")) == "Y")
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("BOM_SET_ID")), (int)SMALLICON_INDEX.IDX_BOM);
                            itmX.ForeColor = Color.Magenta;
                        }
                        else
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("BOM_SET_ID")), (int)SMALLICON_INDEX.IDX_BOM);
                        }
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("BOM_SET_DESC")));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("BOM_SET_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("BOM_SET_DESC")), (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                        ((ComboBox) control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("BOM_SET_ID")));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("BOM_SET_ID")));
                    }
                }

                in_node.SetString("NEXT_BOM_SET_ID", out_node.GetString("NEXT_BOM_SET_ID"));

            } while(in_node.GetString("NEXT_BOM_SET_ID") != "");

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

        
        // ViewBOMBOMSetVersionList()
        //       - View Collection Set Version List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - ByVal BOMSetID As String                : BOM Set ID
        //        - Optional ByVal iImage_idx As Integer = -1    : List View???§Ïñ¥Í∞??ÑÏù¥ÏΩ??∏Îç±??
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text

        public static bool ViewBOMSetVersionList(Control control, char c_step, string BOMSetID, int iImage_idx, TreeNode parentNode, string sExt_Factory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_BOM_SET_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BOM_SET_VERSION_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, false);
            }

            if (iImage_idx == -1) 
            {
                iImage_idx = (int)SMALLICON_INDEX.IDX_COL_SET_VERSION;
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
           
            
            in_node.AddString("BOM_SET_ID", BOMSetID);
            in_node.AddInt("NEXT_BOM_SET_VERSION", int.MaxValue);

            do
            {
                if (MPCR.CallService("BOM", "BOM_View_BOMSet_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("BOM_SET_VERSION").ToString(), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("BOM_SET_VERSION").ToString(), (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("BOM_SET_VERSION").ToString());
                    }
                }

                in_node.SetInt("NEXT_BOM_SET_VERSION", out_node.GetInt("NEXT_BOM_SET_VERSION"));

            } while (in_node.GetInt("NEXT_BOM_SET_VERSION") > 0);

            return true;

        }

        
    }
    //#End If
}
