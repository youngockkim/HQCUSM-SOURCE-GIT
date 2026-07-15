
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modINVListRoutine.vb
//   Description : Client Common List function INV Module
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
//#If _INV = True Then

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
    public sealed class INVLIST
    {

        // ViewInventoryHistory()
        //       - View Inventory History
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                            : ListÍ∞¢Ê ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                                : ?ïÏû•Process Step
        //        - ByVal sMatID As String                            : Material
        //        - ByVal sInvOper As String                        : Inv Oper
        //        - Optional ByVal sFromTime As String = ""           : ?úÏûë?úÍ∞Ñ
        //        - Optional ByVal sToTime As String = ""             : ÎßàÏ?Îß??úÍ∞Ñ
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete HistoryÍπåÏ? ?¨Ìï®??Í≤ÉÏù∏Ïß¢Ê?
        //       - Optional ByVal sTreeItem As String = ""           : Tree Item Í∞?
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏Ïß¢Ê?
        //       - Optional ByVal sTranCode as string = ""           : Transaction Code Î™?
        //
        public static bool ViewInventoryHistory(Control control, char c_step, string sMatID, int iMatVer, string sInvOper, string sFromTime, string sToTime, char sIncludeDelHistory, TreeNode parentNode, bool bIgnoreError, string sTranCode)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;
            int iCol;
            int iHistIcon;

            TRSNode in_node = new TRSNode("VIEW_INVENTORY_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_INVENTORY_HISTORY_OUT");

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
            in_node.AddString("OPER", sInvOper);
            in_node.AddString("FROM_TIME", sFromTime);
            in_node.AddString("TO_TIME", sToTime);
            in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDelHistory);
            in_node.AddString("TRAN_CODE", sTranCode);
            in_node.AddInt("HIST_SEQ", int.MaxValue);

            do
            {
                if (MPCR.CallService("INV", "INV_View_Inventory_History", in_node, ref out_node) == false)
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
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                        iCol++;
                        //sheetX.Cells(iRow, iCol).Value = MakeDateFormat(Trim(View_Inventory_Historyout_node.GetList(0)[i].Get("SYS_TRAN_TIME"))) : iCol += 1
                        //sheetX.Cells(iRow, iCol).Value = RTrim(View_Inventory_Historyout_node.GetList(0)[i].Get("FACTORY")) : iCol += 1
                        //sheetX.Cells(iRow, iCol).Value = RTrim(View_Inventory_Historyout_node.GetList(0)[i].Get("MAT_ID")) : iCol += 1
                        //sheetX.Cells(iRow, iCol).Value = RTrim(View_Inventory_Historyout_node.GetList(0)[i].Get("OPER")) : iCol += 1
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1"));

                        iCol++;
                        //sheetX.Cells(iRow, iCol).Value = Format(View_Inventory_Historyout_node.GetList(0)[i].Get("QTY_2,") "####,##0.###") : iCol += 1
                        //sheetX.Cells(iRow, iCol).Value = Format(View_Inventory_Historyout_node.GetList(0)[i].Get("QTY_3,") "####,##0.###") : iCol += 1
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("CHG_QTY_1"));

                        iCol++;
                        //sheetX.Cells(iRow, iCol).Value = Format(View_Inventory_Historyout_node.GetList(0)[i].Get("CHG_QTY_2,") "####,##0.###") : iCol += 1
                        //sheetX.Cells(iRow, iCol).Value = Format(View_Inventory_Historyout_node.GetList(0)[i].Get("CHG_QTY_3,") "####,##0.###") : iCol += 1
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("FROM_TO_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FROM_TO_MAT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("FROM_TO_MAT_VER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FROM_TO_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_1"));

                        iCol++;
                        //sheetX.Cells(iRow, iCol).Value = Format(View_Inventory_Historyout_node.GetList(0)[i].Get("FROM_TO_QTY_2,") "####,##0.###") : iCol += 1
                        //sheetX.Cells(iRow, iCol).Value = Format(View_Inventory_Historyout_node.GetList(0)[i].Get("FROM_TO_QTY_3,") "####,##0.###") : iCol += 1
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("FROM_TO_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FROM_TO_LOT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SCRAP_CODE");

                        iCol++;
                        //sheetX.Cells(iRow, iCol).Value = RTrim(View_Inventory_Historyout_node.GetList(0)[i].Get("SHIP_CODE")) : iCol += 1
                        //sheetX.Cells(iRow, iCol).Value = MakeDateFormat(Trim(View_Inventory_Historyout_node.GetList(0)[i].Get("SHIP_TIME"))) : iCol += 1
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_1"));

                        iCol++;
                        //sheetX.Cells(iRow, iCol).Value = Format(View_Inventory_Historyout_node.GetList(0)[i].Get("OLD_QTY_2,") "####,##0.###") : iCol += 1
                        //sheetX.Cells(iRow, iCol).Value = Format(View_Inventory_Historyout_node.GetList(0)[i].Get("OLD_QTY_3,") "####,##0.###") : iCol += 1
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
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_USER_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_COMMENT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("REL_TRAN_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("REL_HIST_SEQ");

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
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("TRAN_TIME") + " : " + out_node.GetList(0)[i].GetString("TRAN_CODE"), 
                            (int)SMALLICON_INDEX.IDX_HISTORY, (int)SMALLICON_INDEX.IDX_HISTORY);
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

            } while (out_node.GetInt("HIST_SEQ") > 0);

            return true;

        }

    }
    //#End If
}

