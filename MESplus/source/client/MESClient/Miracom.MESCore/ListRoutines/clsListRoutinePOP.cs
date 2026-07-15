
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modPOPListRoutine.vb
//   Description : Client Common List function POP Module
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
//#If _POP = True Then

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
    public sealed class POPLIST
    {
        
        // ViewLabelList()
        //       - View All Label List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewLabelList(Control control, char c_step, string sMatID, int iMatVer, string sFilter, TreeNode parentNode, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            
            TRSNode in_node = new TRSNode("VIEW_LABEL_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LABEL_LIST_OUT");

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

            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FILTER", sFilter);

            do
            {
                if (MPCR.CallService("POP", "POP_View_Label_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("LABEL_ID"), (int)SMALLICON_INDEX.IDX_LABEL);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LABEL_DESC"));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("LABEL_ID") + " : " + out_node.GetList(0)[i].GetString("LABEL_DESC"), 
                            (int)SMALLICON_INDEX.IDX_LABEL, (int)SMALLICON_INDEX.IDX_LABEL);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("LABEL_ID"));
                    }
                }

                in_node.SetString("NEXT_LABEL", out_node.GetString("NEXT_LABEL"));

            } while (out_node.GetString("NEXT_LABEL") != "");

            return true;

        }

        // ViewImageList()
        //       - View Image List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞¢Ê ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû•Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨FactoryÍ∞¢Ê ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑúÏ∂îÍ???Node??Text
        //       - Optional ByVal Col As Integer = -1        : Spread Ïª®Ìä∏Î°§ÏùºÍ≤ΩÏö∞?∞Ïù¥?¢ÊÎ•?ÎøåÎ†§Ï§?Column Index (-1?¥Î©¥?πÏ†ïRow ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //       - Optional ByVal Row As Integer = -1        : Spread Ïª®Ìä∏Î°§ÏùºÍ≤ΩÏö∞?∞Ïù¥?¢ÊÎ•?ÎøåÎ†§Ï§?Row Index (-1?¥Î©¥?πÏ†ïColumn ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //
        public static bool ViewImageList(Control control, char c_step, TreeNode parentNode, string sExt_Factory, int Col, int Row)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            string[] strData = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;

            TRSNode in_node = new TRSNode("VIEW_IMAGE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_IMAGE_LIST_OUT");

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
                if (MPCR.CallService("POP", "POP_View_Image_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("IMAGE_ID"), (int)SMALLICON_INDEX.IDX_FUNCTION);
                        if (((ListView) control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("IMAGE_DESC"));
                        }
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("IMAGE_ID") + " : " + out_node.GetList(0)[i].GetString("IMAGE_DESC"), (int)SMALLICON_INDEX.IDX_FUNCTION, (int)SMALLICON_INDEX.IDX_FUNCTION);
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
                        ((ComboBox) control).Items.Add(out_node.GetList(0)[i].GetString("IMAGE_ID"));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("IMAGE_ID"));
                    }
                }

                in_node.SetString("NEXT_IMAGE_ID", out_node.GetString("NEXT_IMAGE_ID"));
            } while (out_node.GetString("NEXT_IMAGE_ID") != "");

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

    }

    //#End If
}
