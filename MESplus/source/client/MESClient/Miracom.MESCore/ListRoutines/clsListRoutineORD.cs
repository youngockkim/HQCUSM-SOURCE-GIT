
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modORDListRoutine.vb
//   Description : Client Common List function ORD Module
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
//#If _ORD = True Then

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
    public sealed class ORDLIST
    {

        public static bool ViewOrderList(Control control, char c_step, string sWorkDate, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_ORDER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_LIST_OUT");

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
            in_node.AddString("WORK_DATE", sWorkDate);

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            do
            {
                if (MPCR.CallService("ORD", "ORD_View_Order_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (c_step == '1' && out_node.GetList(0)[i].GetChar("ORDER_STATUS_FLAG") == 'D')
                    {
                        //do nothing
                    }
                    else
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("ORDER_ID"), (int)SMALLICON_INDEX.IDX_ORDER);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetDouble("ORD_QTY").ToString());
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ORDER_DESC"));
                            }
                            ((ListView)control).Items.Add(itmX);
                            if (out_node.GetList(0)[i].GetChar("ORDER_STATUS_FLAG") == 'D')
                            {
                                itmX.ForeColor = Color.Magenta;
                            }
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("ORDER_ID") + " : " + out_node.GetList(0)[i].GetString("MAT_ID"), 
                                (int)SMALLICON_INDEX.IDX_ORDER, (int)SMALLICON_INDEX.IDX_ORDER);
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
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("ORDER_ID"));
                        }
                    }

                }

                in_node.SetString("NEXT_ORDER_ID", out_node.GetString("NEXT_ORDER_ID"));
            } while (out_node.GetString("NEXT_ORDER_ID") != "");

            return true;

        }

        public static bool ViewPlanList(Control control, char c_step, string sWorkDate, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_PLAN_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_PLAN_LIST_OUT");

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

            in_node.AddString("WORK_DATE", sWorkDate);

            do
            {
                if (MPCR.CallService("ORD", "ORD_View_Plan_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("MAT_ID"), (int)SMALLICON_INDEX.IDX_MATERIAL);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetDouble("PLAN_QTY").ToString());
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("MAT_ID") + 
                            "(" + out_node.GetList(0)[i].GetInt("MAT_VER").ToString() + ") : " + 
                            out_node.GetList(0)[i].GetDouble("PLAN_QTY").ToString(), 
                            (int)SMALLICON_INDEX.IDX_MATERIAL, (int)SMALLICON_INDEX.IDX_MATERIAL);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                    }

                }

                in_node.SetString("NEXT_MAT_ID", out_node.GetString("NEXT_MAT_ID"));
                in_node.SetInt("NEXT_MAT_VER", out_node.GetInt("NEXT_MAT_VER"));
            } while (out_node.GetString("NEXT_MAT_ID") != "");

            return true;

        }

        public static bool ViewPlannedLotList(Control control, char c_step, string sWorkDate, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_PLANNEDLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_PLANNEDLOT_LIST_OUT");

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

            in_node.AddString("WORK_DATE", sWorkDate);

            do
            {
                if (MPCR.CallService("ORD", "ORD_View_PlannedLot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (c_step == '1' && out_node.GetList(0)[i].GetChar("LOT_CREATE_FLAG") == 'Y')
                    {
                        //do nothing
                    }
                    else
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("LOT_ID"), (int)SMALLICON_INDEX.IDX_LOT);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetDouble("QTY_1").ToString());
                            }
                            ((ListView)control).Items.Add(itmX);
                            if (out_node.GetList(0)[i].GetChar("LOT_CREATE_FLAG") == 'Y')
                            {
                                itmX.ForeColor = Color.Red;
                            }
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("LOT_ID") + " : " + 
                                out_node.GetList(0)[i].GetDouble("QTY_1").ToString(), 
                                (int)SMALLICON_INDEX.IDX_LOT, (int)SMALLICON_INDEX.IDX_LOT);
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

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (out_node.GetString("NEXT_LOT_ID") != "");


            return true;

        }

    }
    //#End If
}

