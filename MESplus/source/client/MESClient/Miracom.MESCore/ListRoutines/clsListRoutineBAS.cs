
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modBASListRoutine.vb
//   Description : Client Common List function BAS Module
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
    public sealed class BASLIST
    {

        // ViewGCMDataList()
        //       - View General Code Data list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal Form_control As Control                : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal table_name As String                : BAS??Table_name
        //        - Optional ByVal Image_idx As Integer = -1    : List View???§Ïñ¥Í∞??ÑÏù¥ÏΩ??∏Îç±??
        //        - Optional ByVal Ext_Factory As String = ""    : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal TreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //       - Optional ByVal Col As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Column Index (-1?¥Î©¥ ?πÏ†ï Row ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //       - Optional ByVal Row As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Row Index (-1?¥Î©¥ ?πÏ†ï Column ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //
        public static bool ViewGCMDataList(Control Form_control, char c_step, string table_name)
        {
            return ViewGCMDataList(Form_control, c_step, table_name, -1, null, "", false, -1, -1, null);
        }
        public static bool ViewGCMDataList(Control Form_control, char c_step, string table_name, int Image_idx, TreeNode parentNode, string Ext_Factory)
        {
            return ViewGCMDataList(Form_control, c_step, table_name, Image_idx, parentNode, Ext_Factory, false, -1, -1, null);
        }
        public static bool ViewGCMDataList(Control Form_control, char c_step, string table_name, int Image_idx, TreeNode parentNode, string Ext_Factory, bool bIgnoreError, int Col, int Row, string[] Item)
        {
            return ViewGCMDataList(Form_control, c_step, table_name, Image_idx, parentNode, Ext_Factory, false, Col, Row, null, null);
        }
        public static bool ViewGCMDataList(Control Form_control, char c_step, string table_name, int Image_idx, TreeNode parentNode, string Ext_Factory, bool bIgnoreError, int Col, int Row, string[] Item, string[] Argu)
        {

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;
            int iCol;
            int i;
            int j;
            string[] strData = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (Form_control is ListView)
            {
                MPCF.InitListView((ListView)Form_control);
            }
            else if (Form_control is FarPoint.Win.Spread.FpSpread && (Col > 0 || Row > 0))
            {
                //Do Nothing
            }
            else if (!(Form_control is TreeView))
            {
                MPCF.ClearList(Form_control, true);
            }

            if (Form_control is Miracom.UI.Controls.MCCodeView.MCCodeDropList)
            {
                ((Miracom.UI.Controls.MCCodeView.MCCodeDropList)Form_control).GCMTableName = table_name;
            }
            if (Image_idx == -1)
            {
                Image_idx = (int)SMALLICON_INDEX.IDX_CODE_DATA;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[Image_idx] == null)
                {
                    if (bIgnoreError == false)
                    {
                        MPCF.ShowMsgBox("Invalid Image Index");
                    }
                    return false;
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (Ext_Factory != "")
            {
                in_node.Factory = Ext_Factory;
            }

            in_node.AddString("TABLE_NAME", table_name);
            in_node.AddString("NEXT_KEY_1", "");
            in_node.AddString("NEXT_KEY_2", "");

            if (Argu != null)
            {
                for (i = 0; i < Argu.Length; i++)
                {
                    TRSNode node = in_node.AddNode("ARGU_LIST");
                    node.AddString("ARGUMENT", Argu[i]);
                }
            }

            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));

            } while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "" || in_node.GetInt("NEXT_ROW") > 0);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (Form_control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("KEY_1"), Image_idx);
                        if (((ListView)Form_control).Columns.Count > 1)
                        {
                            for (j = 0; j < ((ListView)Form_control).Columns.Count - 1; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_1"));
                                        break;

                                    case 1:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_2"));
                                        break;

                                    case 2:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_3"));
                                        break;

                                    case 3:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_4"));
                                        break;

                                    case 4:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_5"));
                                        break;

                                    case 5:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_6"));
                                        break;

                                    case 6:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_7"));
                                        break;

                                    case 7:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_8"));
                                        break;

                                    case 8:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_9"));
                                        break;

                                    case 9:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_10"));
                                        break;
                                }
                            }
                        }
                        ((ListView)Form_control).Items.Add(itmX);
                    }
                    else if (Form_control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("KEY_1") + " : " + out_node.GetList(0)[i].GetString("DATA_1"), Image_idx, Image_idx);
                        if (!(parentNode == null))
                        {
                            parentNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            ((TreeView)Form_control).Nodes.Add(nodeX);
                        }
                    }
                    else if (Form_control is ComboBox)
                    {
                        ((ComboBox)Form_control).Items.Add(out_node.GetList(0)[i].GetString("KEY_1"));
                    }
                    else if (Form_control is FarPoint.Win.Spread.FpSpread)
                    {
                        sheetX = ((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet;

                        if (sheetX.Columns.Count == 3)
                        {

                            iRow = sheetX.RowCount;
                            sheetX.RowCount++;

                            iCol = 0;

                            sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("KEY_1");

                            iCol++;
                            sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("KEY_2");

                            iCol++;
                            sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("DATA_1");

                            iCol++;

                        }
                        else
                        {
                            sList.Add(out_node.GetList(0)[i].GetString("KEY_1"));
                        }

                    }

                }
            }

            if (Form_control is FarPoint.Win.Spread.FpSpread)
            {

                if (((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet.Columns.Count == 3)
                {
                    return true;
                }

                if (Item != null)
                {
                    for (i = 0; i <= (Item.Length - 1); i++)
                    {
                        if (sList.Count < 1)
                        {
                            sList.Add(Item[i]);
                        }
                        else
                        {
                            for (j = 0; j < sList.Count; j++)
                            {
                                if (sList.Contains(Item[i]) == true)
                                {
                                    break;
                                }
                            }

                            if (j >= sList.Count)
                            {
                                sList.Add(Item[i]);
                            }
                        }
                    }
                }

                strData = new string[sList.Count + 1];
                for (i = 0; i < sList.Count; i++)
                {
                    strData[i] = sList[i];
                }
                strData[i] = "";

                cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cboCellType.Items = strData;
                if (Row == -1 && Col == -1)
                {
                    //Do Nothing
                }
                else if (Row == -1)
                {
                    ((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet.Columns.Get(Col).CellType = cboCellType;
                }
                else if (Col == -1)
                {
                    ((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet.Rows.Get(Row).CellType = cboCellType;
                }
                else
                {
                    ((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet.Cells.Get(Row, Col).CellType = cboCellType;
                }
            }

            return true;

        }

        // ViewGCMDataList_AREA()
        //       - View General Code Data list
        // Return Value
        //       - boolean : True / False
        //         ∆Ø¡§ ø°∑Ø∏ÆæÓø° º”«— Sub_Area∏∏ ∞°¡ˆ∞Ì ø¬¥Ÿ.
        // Arguments
        //       - ByVal Form_control As Control                : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal table_name As String                : BAS??Table_name
        //        - Optional ByVal Image_idx As Integer = -1    : List View???§Ïñ¥Í∞??ÑÏù¥ÏΩ??∏Îç±??
        //        - Optional ByVal Ext_Factory As String = ""    : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal TreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //       - Optional ByVal Col As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Column Index (-1?¥Î©¥ ?πÏ†ï Row ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //       - Optional ByVal Row As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Row Index (-1?¥Î©¥ ?πÏ†ï Column ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //
        public static bool ViewGCMDataList_AREA(Control Form_control, char c_step, string table_name, int Image_idx, TreeNode parentNode, string Ext_Factory, bool bIgnoreError, int Col, int Row, string[] Item, string Area)
        {
            if (MPGO.IndependentSubarea() == true)
            {
                return ViewGCMDataList(Form_control, c_step, table_name, Image_idx, parentNode, Ext_Factory, bIgnoreError, Col, Row, Item);
            }

            ListViewItem itmX;
            TreeNode nodeX;
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;
            int iCol;
            int i;
            int j;
            string[] strData = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (Form_control is ListView)
            {
                MPCF.InitListView((ListView)Form_control);
            }
            else if (Form_control is FarPoint.Win.Spread.FpSpread && (Col > 0 || Row > 0))
            {
                //Do Nothing
            }
            else if (!(Form_control is TreeView))
            {
                MPCF.ClearList(Form_control, true);
            }
            if (Form_control is Miracom.UI.Controls.MCCodeView.MCCodeDropList)
            {
                ((Miracom.UI.Controls.MCCodeView.MCCodeDropList)Form_control).GCMTableName = table_name;
            }
            if (Image_idx == -1)
            {
                Image_idx = (int)SMALLICON_INDEX.IDX_CODE_DATA;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[Image_idx] == null)
                {
                    if (bIgnoreError == false)
                    {
                        MPCF.ShowMsgBox("Invalid Image Index");
                    }
                    return false;
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (Ext_Factory != "")
            {
                in_node.Factory = Ext_Factory;
            }

            in_node.AddString("TABLE_NAME", table_name);
            in_node.AddString("NEXT_KEY_1", "");
            in_node.AddString("NEXT_KEY_2", "");

            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
            } while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("DATA_2") == MPCF.Trim(Area))
                    {

                        if (Form_control is ListView)
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("KEY_1"), Image_idx);
                            if (((ListView)Form_control).Columns.Count > 1)
                            {
                                for (j = 0; j <= ((ListView)Form_control).Columns.Count - 1; j++)
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_1"));
                                            break;

                                        case 1:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_2"));
                                            break;

                                        case 2:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_3"));
                                            break;

                                        case 3:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_4"));
                                            break;

                                        case 4:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_5"));
                                            break;

                                        case 5:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_6"));
                                            break;

                                        case 6:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_7"));
                                            break;

                                        case 7:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_8"));
                                            break;

                                        case 8:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_9"));
                                            break;

                                        case 9:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_10"));
                                            break;
                                    }
                                }
                            }
                            ((ListView)Form_control).Items.Add(itmX);
                        }
                        else if (Form_control is TreeView)
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("KEY_1") + " : " + out_node.GetList(0)[i].GetString("DATA_1"), Image_idx, Image_idx);

                            if (!(parentNode == null))
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)Form_control).Nodes.Add(nodeX);
                            }
                        }
                        else if (Form_control is ComboBox)
                        {
                            ((ComboBox)Form_control).Items.Add(out_node.GetList(0)[i].GetString("KEY_1"));
                        }
                        else if (Form_control is FarPoint.Win.Spread.FpSpread)
                        {
                            sheetX = ((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet;

                            if (sheetX.Columns.Count == 3)
                            {

                                iRow = sheetX.RowCount;
                                sheetX.RowCount++;

                                iCol = 0;

                                sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("KEY_1");

                                iCol++;
                                sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("KEY_2");

                                iCol++;
                                sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("DATA_1");

                                iCol++;

                            }
                            else
                            {
                                sList.Add(out_node.GetList(0)[i].GetString("KEY_1"));
                            }

                        }

                    }
                }
            }


            if (Form_control is FarPoint.Win.Spread.FpSpread)
            {

                if (((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet.Columns.Count == 3)
                {
                    return true;
                }

                if (Item != null)
                {
                    for (i = 0; i <= (Item.Length - 1); i++)
                    {
                        if (sList.Count < 1)
                        {
                            sList.Add(Item[i]);
                        }
                        else
                        {
                            for (j = 0; j < sList.Count; j++)
                            {
                                if (sList.Contains(Item[i]) == true)
                                {
                                    break;
                                }
                            }

                            if (j >= sList.Count)
                            {
                                sList.Add(Item[i]);
                            }
                        }
                    }
                }
            }

            strData = new string[sList.Count + 1];
            for (i = 0; i < sList.Count; i++)
            {
                strData[i] = sList[i];
            }
            strData[i] = "";

            cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            cboCellType.Items = strData;
            if (Row == -1 && Col == -1)
            {
                //Do Nothing
            }
            else if (Row == -1)
            {
                ((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet.Columns.Get(Col).CellType = cboCellType;
            }
            else if (Col == -1)
            {
                ((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet.Rows.Get(Row).CellType = cboCellType;
            }
            else
            {
                ((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet.Cells.Get(Row, Col).CellType = cboCellType;
            }

            return true;

        }


        // ViewGCMTableList()
        //       - View General Code Table list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sTable_type As String                : BAS??Table_Type
        //        - Optional ByVal iImage_idx As Integer = -1    : List View???§Ïñ¥Í∞??ÑÏù¥ÏΩ??∏Îç±??
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //       - Optional ByVal Col As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Column Index (-1?¥Î©¥ ?πÏ†ï Row ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //       - Optional ByVal Row As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Row Index (-1?¥Î©¥ ?πÏ†ï Column ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //
        public static bool ViewGCMTableList(Control control, char c_step)
        {
            return ViewGCMTableList(control, c_step, ' ', "", -1, null, "", false, -1, -1, false, false, true);
        }
        public static bool ViewGCMTableList(Control control, char c_step, bool b_include_central_table_flag)
        {
            return ViewGCMTableList(control, c_step, ' ', "", -1, null, "", false, -1, -1, false, false, b_include_central_table_flag);
        }
        public static bool ViewGCMTableList(Control control, char c_step, bool b_sec_chk_flag, bool b_only_for_user_flag)
        {
            return ViewGCMTableList(control, c_step, ' ', "", -1, null, "", false, -1, -1, b_sec_chk_flag, b_only_for_user_flag, true);
        }
        public static bool ViewGCMTableList(Control control, char c_step, bool b_sec_chk_flag, bool b_only_for_user_flag, bool b_include_central_table_flag)
        {
            return ViewGCMTableList(control, c_step, ' ', "", -1, null, "", false, -1, -1, b_sec_chk_flag, b_only_for_user_flag, b_include_central_table_flag);
        }
        public static bool ViewGCMTableList(Control control, char c_step, char sTable_type, string sTable_group)
        {
            return ViewGCMTableList(control, c_step, sTable_type, sTable_group, -1, null, "", false, -1, -1, false, false, true);
        }
        public static bool ViewGCMTableList(Control control, char c_step, char sTable_type, string sTable_group, bool b_include_central_table_flag)
        {
            return ViewGCMTableList(control, c_step, sTable_type, sTable_group, -1, null, "", false, -1, -1, false, false, b_include_central_table_flag);
        }
        public static bool ViewGCMTableList(Control control, char c_step, char sTable_type, string sTable_group, bool b_sec_chk_flag, bool b_only_for_user_flag, bool b_include_central_table_flag)
        {
            return ViewGCMTableList(control, c_step, sTable_type, sTable_group, -1, null, "", false, -1, -1, b_sec_chk_flag, b_only_for_user_flag, b_include_central_table_flag);
        }
        public static bool ViewGCMTableList(Control control, char c_step, char sTable_type, string sTable_group, int iImage_idx, TreeNode parentNode, string sExt_Factory, bool bIgnoreError, int Col, int Row, bool b_sec_chk_flag, bool b_only_for_user_flag, bool b_include_central_table_flag)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            string[] strData = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("View_Table_List_In");
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
                iImage_idx = (int)SMALLICON_INDEX.IDX_CODE_TABLE;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[iImage_idx] == null)
                {
                    if (bIgnoreError == false)
                    {
                        MPCF.ShowMsgBox("Invalid Image Index");
                        return false;
                    }
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }

            if (in_node.Factory == MPGV.gsCentralFactory)
            {
                b_include_central_table_flag = false;
            }

            in_node.AddChar("TABLE_TYPE", sTable_type);
            in_node.AddString("TABLE_GROUP", sTable_group);
            in_node.AddString("NEXT_TABLE_NAME", "");
            in_node.AddChar("SEC_CHK_FLAG", b_sec_chk_flag == true ? 'Y' : ' ');
            in_node.AddChar("ONLY_FOR_USER_FLAG", b_only_for_user_flag == true ? 'Y' : ' ');
            in_node.AddChar("INCLUDE_CENTRAL_TABLE_FLAG", b_include_central_table_flag == true ? 'Y' : ' ');

            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Table_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_TABLE_NAME", out_node.GetString("NEXT_TABLE_NAME"));

            } while (out_node.GetString("NEXT_TABLE_NAME") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("TABLE_NAME"), iImage_idx);

                        if (b_include_central_table_flag == true)
                        {
                            if (out_node.GetList(0)[i].GetString("FACTORY") == MPGV.gsCentralFactory)
                            {
                                itmX.BackColor = Color.Gainsboro;
                                itmX.ImageIndex = 3;
                            }
                        }

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("TABLE_DESC"));
                        }
                        /* Added By YJJung 150721 to distinguish system table */
                        if (out_node.GetList(0)[i].GetChar("SYS_TBL_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Blue;
                        }
                        /* Added End */
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("TABLE_NAME") + " : " + out_node.GetList(0)[i].GetString("TABLE_DESC"), iImage_idx, iImage_idx);

                        if (b_include_central_table_flag == true)
                        {
                            if (out_node.GetList(0)[i].GetString("FACTORY") == MPGV.gsCentralFactory)
                            {
                                nodeX.BackColor = Color.Gainsboro;
                                nodeX.ImageIndex = 3;
                                nodeX.SelectedImageIndex = 3;
                            }
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("TABLE_NAME"));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("TABLE_NAME"));
                    }
                }
            }


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
                if (Row == -1 && Col == -1)
                {
                    //Do Nothing
                }
                else if (Row == -1)
                {
                    ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet.Columns.Get(Col).CellType = cboCellType;
                }
                else if (Col == -1)
                {
                    ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet.Rows.Get(Row).CellType = cboCellType;
                }
                else
                {
                    ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet.Cells.Get(Row, Col).CellType = cboCellType;
                }
            }

            return true;

        }

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        // ViewGCMTablePromptList()
        //       - View General Code Table Prompt list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                        : List control
        //       - Optional ByVal c_step As char = '2'             : Process Step
        //       - Optional ByVal sTableName As String = ""        : GCM Table Name
        //       - Optional ByVal iImage_idx As Integer = -1       : ListView icon image index
        //       - Optional ByVal parentNode As TreeNode = null    : TreeView Parent Node
        //       - Optional ByVal sExt_Factory As String = ""      : Ext. factory
        //       - Optional ByVal bIgnoreError As bool = false     : Ignore Error
        //       - Optional ByVal bExcludeEmptyRow As bool = false : Exclude Empty Row
        //
        public static bool ViewGCMTablePromptList(Control control, string sTableName)
        {
            return ViewGCMTablePromptList(control, sTableName, false);
        }
        public static bool ViewGCMTablePromptList(Control control, string sTableName, bool bIncludeCentralTable)
        {
            return ViewGCMTablePromptList(control, sTableName, false, bIncludeCentralTable);
        }
        public static bool ViewGCMTablePromptList(Control control, string sTableName, bool bExcludeEmptyRow, bool bIncludeCentralTable)
        {
            return ViewGCMTablePromptList(control, '2', sTableName, -1, null, "", false, bExcludeEmptyRow, bIncludeCentralTable);
        }
        public static bool ViewGCMTablePromptList(Control control, char c_step, string sTableName, int iImage_idx, TreeNode parentNode, string sExt_Factory, bool bIgnoreError, bool bExcludeEmptyRow, bool bIncludeCentralTable)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            List<string> sList = new List<string>();
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("View_Table_List_In");
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
                iImage_idx = (int)SMALLICON_INDEX.IDX_CODE_TABLE;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[iImage_idx] == null)
                {
                    if (bIgnoreError == false)
                    {
                        MPCF.ShowMsgBox("Invalid Image Index");
                        return false;
                    }
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }

            in_node.AddString("NEXT_TABLE_NAME", sTableName);
            in_node.AddChar("INCLUDE_CENTRAL_TABLE_FLAG", bIncludeCentralTable == true ? 'Y' : ' ');

            do
            {
                out_node = new TRSNode("VIEW_PROMPT_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Table_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_TABLE_NAME", out_node.GetString("NEXT_TABLE_NAME"));

            } while (out_node.GetString("NEXT_TABLE_NAME") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (bExcludeEmptyRow)
                    {
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) == String.Empty) continue;
                    }

                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("COLUMN"), iImage_idx);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("PROMPT"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("COLUMN") + " : " + out_node.GetList(0)[i].GetString("PROMPT"), iImage_idx, iImage_idx);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("COLUMN"));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("COLUMN"));
                    }
                }
            }

            return true;

        }
        /*** End of Add (2012.04.04) ***/

        // ViewMessageGroupList()
        //       - View Message Group list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - Optional ByValsTreeItem As String =""     : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal bIgnoreError As Boolean = False: Error Î¨¥Ïãú ?¨Î?
        //
        public static bool ViewMessageGroupList(Control control, char c_step, TreeNode parentNode, bool bIgnoreError, bool SpaceFlag)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_MESSAGE_GROUP_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MESSAGE_GROUP_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, SpaceFlag);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("NEXT_MSG_GRP", "");

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Message_Group_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("MSG_GRP"), (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MSG_GRP_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("MSG_GRP") + " : " + out_node.GetList(0)[i].GetString("MSG_GRP_DESC"), (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP, (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("MSG_GRP"));

                    }
                }
                in_node.SetString("NEXT_MSG_GRP", out_node.GetString("NEXT_MSG_GRP"));
            } while (out_node.GetString("NEXT_MSG_GRP") != "");

            return true;

        }


        // ViewMessageList()
        //       - View Message list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sMsgGrp As String                    : MessageGroup
        //       - Optional ByValsTreeItem As String =""     : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal bIgnoreError As Boolean = False: Error Î¨¥Ïãú ?¨Î?
        //
        public static bool ViewMessageList(Control control, char c_step, string sMsgGrp, TreeNode parentNode, string sExt_Factory, bool bIgnoreError)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("Message_List_In");
            TRSNode out_node;

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

            in_node.AddString("MSG_GRP", sMsgGrp);

            do
            {
                out_node = new TRSNode("Message_List_Out");

                if (MPCR.CallService("BAS", "BAS_View_Message_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_MSG_ID", out_node.GetString("NEXT_MSG_ID"));

            } while (in_node.GetString("NEXT_MSG_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("MSG_ID"), (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MSG"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("MSG_ID") + " : " +
                            out_node.GetList(0)[i].GetString("MSG"), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);

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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("MSG_ID"));

                    }
                }
            }

            return true;

        }

        public static bool ViewAttributeNameList(Control control, char c_step, string sType)
        {
            return ViewAttributeNameList(control, c_step, sType, false, false, null, "", false);
        }

        public static bool ViewAttributeNameList(Control control, char c_step, string sType, bool b_sec_chk_flag, bool b_only_for_user_flag)
        {
            return ViewAttributeNameList(control, c_step, sType, b_sec_chk_flag, b_only_for_user_flag, null, "", false);
        }

        // ViewAttributeNameList()
        //       - View Attribute Name list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sType As String                        : Attribute Type
        //       - Optional ByValsTreeItem As String =""     : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal bIgnoreError As Boolean = False: Error Î¨¥Ïãú ?¨Î?
        //
        public static bool ViewAttributeNameList(Control control, char c_step, string sType, bool b_sec_chk_flag, bool b_only_for_user_flag, TreeNode parentNode, string sExt_Factory, bool bIgnoreError)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("List_In");
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

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }

            in_node.AddString("ATTR_TYPE", sType);
            in_node.AddChar("SEC_CHK_FLAG", (b_sec_chk_flag == true ? 'Y' : ' '));
            in_node.AddChar("ONLY_FOR_USER_FLAG", (b_only_for_user_flag == true ? 'Y' : ' '));
            in_node.AddString("NEXT_ATTR_NAME", "");
            in_node.AddInt("NEXT_ATTR_SEQ", 0);

            do
            {
                out_node = new TRSNode("List_Out");

                if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

            } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("ATTR_SEQ").ToString(), (int)SMALLICON_INDEX.IDX_KEY);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ATTR_NAME"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ATTR_TYPE"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ATTR_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("ATTR_SEQ") + " : " + out_node.GetList(0)[i].GetString("ATTR_NAME"), (int)SMALLICON_INDEX.IDX_KEY, (int)SMALLICON_INDEX.IDX_KEY);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("ATTR_NAME"));

                    }
                }
            }

            return true;
        }

        // ViewScreenList()
        //       - View Screen list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sScreenGrp As String                    : Screen Group
        //       - Optional ByValsTreeItem As String =""     : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal bIgnoreError As Boolean = False: Error Î¨¥Ïãú ?¨Î?
        //
        public static bool ViewScreenList(Control control, char c_step, string sScreenGrp, string sFactoryOption, TreeNode parentNode, string sExt_Factory, bool bIgnoreError)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("Screen_List_In");
            TRSNode out_node;

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

            in_node.AddString("SCREEN_GROUP", sScreenGrp);
            in_node.AddString("FACTORY_OPTION", sFactoryOption);

            do
            {
                out_node = new TRSNode("Screen_List_Out");

                if (MPCR.CallService("BAS", "BAS_View_Screen_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_SCREEN_ID", out_node.GetString("NEXT_SCREEN_ID"));

            } while (in_node.GetString("NEXT_SCREEN_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("SCREEN_ID"), (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SCREEN_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("SCREEN_ID") + " : " +
                            out_node.GetList(0)[i].GetString("SCREEN_DESC"), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);

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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("SCREEN_ID"));

                    }
                }
            }

            return true;

        }

        // ViewDocFormatList()
        //       - View document format list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step        
        //       - Optional ByValsTreeItem As String =""     : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal bIgnoreError As Boolean = False: Error Î¨¥Ïãú ?¨Î?
        //
        public static bool ViewDocFormatList(Control control, char c_step, string sFactoryOption, TreeNode parentNode, string sExt_Factory, bool bIgnoreError)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("Format_List_In");
            TRSNode out_node;

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

            in_node.AddString("FACTORY_OPTION", sFactoryOption);

            do
            {
                out_node = new TRSNode("Format_List_Out");

                if (MPCR.CallService("BAS", "BAS_View_Document_Format_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_DOF_ID", out_node.GetString("NEXT_DOF_ID"));

            } while (in_node.GetString("NEXT_DOF_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("DOF_ID"), (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DOF_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("DOF_ID") + " : " +
                            out_node.GetList(0)[i].GetString("DOF_DESC"), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);

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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("DOF_ID"));

                    }
                }
            }

            return true;
        }

        // ViewDocTempList()
        //       - View document template list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sDocType As String                    : Document Type
        //       - Optional ByValsTreeItem As String =""     : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal bIgnoreError As Boolean = False: Error Î¨¥Ïãú ?¨Î?
        //
        public static bool ViewDocTempList(Control control, char c_step, string sDocType, string sFactoryOption, TreeNode parentNode, string sExt_Factory, bool bIgnoreError)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("Template_List_In");
            TRSNode out_node;

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

            in_node.AddString("DOC_TYPE", sDocType);
            in_node.AddString("FACTORY_OPTION", sFactoryOption);

            do
            {
                out_node = new TRSNode("Template_List_Out");

                if (MPCR.CallService("BAS", "BAS_View_Document_Template_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_DOT_ID", out_node.GetString("NEXT_DOT_ID"));

            } while (in_node.GetString("NEXT_DOT_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("DOT_ID"), (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DOT_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("DOT_ID") + " : " +
                            out_node.GetList(0)[i].GetString("DOT_DESC"), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);

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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("DOT_ID"));

                    }
                }
            }

            return true;

        }
        public static bool ViewQueryList(Control control, char c_step, string sQuery, int iImage, TreeNode parentNode)
        {

            int i;
            int j;
            int i_image;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");


            if (iImage == 0)
                i_image = (int)SMALLICON_INDEX.IDX_CODE_DATA;
            else
                i_image = iImage;

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

            byte[] bsq = System.Text.Encoding.UTF8.GetBytes(sQuery);
            in_node.AddBlob(MPGC.MP_BIN_DATA_1, bsq);

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList("ROWS").Count != 0)
                {
                    for (i = 0; i < out_node.GetList("ROWS").Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList("ROWS")[i].GetList("COLS")[0].GetString("DATA")), i_image);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                for (j = 1; j < ((ListView)control).Columns.Count; j++)
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList("ROWS")[i].GetList("COLS")[0].GetString("DATA")) + " : " + MPCF.Trim(out_node.GetList("ROWS")[i].GetList("COLS")[1].GetString("DATA")), (int)SMALLICON_INDEX.IDX_FACTORY, (int)SMALLICON_INDEX.IDX_FACTORY);
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
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList("ROWS")[i].GetList("COLS")[0].GetString("DATA")));

                        }
                    }
                }



                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") != 0);

            return true;
        }

        /// <summary>
        /// View transaction code list from GCM Table
        /// </summary>
        /// <param name="control">Target control</param>
        /// <param name="c_step">Process Step</param>
        /// <returns></returns>
        public static bool ViewTranCodeList(Control control, char c_step)
        {
            int i;
            TRSNode in_node = new TRSNode("TRAN_CODE_LIST_IN");
            TRSNode out_node = new TRSNode("TRAN_CODE_LIST_OUT");
            ListViewItem itmX;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("TABLE_NAME", MPGC.MP_GCM_TRAN_CODE);

            if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (control is ListView)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("KEY_1"));

                    if (((ListView)control).Columns.Count > 1)
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_1"));

                    ((ListView)control).Items.Add(itmX);
                }
            }

            MPCF.FitColumnHeader(control);

            return true;
        }

        /* Added by DM KIM 2012.05.07 View Message Popup List Start */

        // View_BBS_Msg_List()
        //       - View BBS Msg List
        // Return Value
        //       -
        // Arguments
        //        -

        public static bool ViewBBSMsgListForUser(TRSNode out_node, string s_user_id)
        {
            return ViewBBSMsgList(out_node, "", "", "", "", s_user_id, "", "", "", false);
        }
        public static bool ViewBBSMsgListForLot(TRSNode out_node, string s_lot_id)
        {
            return ViewBBSMsgList(out_node, s_lot_id, "", "", "", "", "", "", "", true);
        }
        public static bool ViewBBSMsgListForRes(TRSNode out_node, string s_res_id)
        {
            return ViewBBSMsgList(out_node, "", "", "", "", "", s_res_id, "", "", true);
        }

        public static bool ViewBBSMsgList(TRSNode out_node, string s_mat_id, string s_flow, string s_oper)
        {
            return ViewBBSMsgList(out_node, "", s_mat_id, s_flow, s_oper, "", "", "", "", true);
        }
        public static bool ViewBBSMsgList(TRSNode out_node, string s_area_id, string s_subarea_id)
        {
            return ViewBBSMsgList(out_node, "", "", "", "", "", "", s_area_id, s_subarea_id, true);
        }
        public static bool ViewBBSMsgList(TRSNode out_node, string s_lot_id, string s_mat_id, string s_flow, string s_oper, string s_user_id, string s_res_id, string s_area_id, string s_subarea_id, bool b_exclude_sys_msg)
        {
            TRSNode in_node = new TRSNode("VIEW_BBS_MSG_LIST_IN");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("RCV_USER_ID", MPCF.Trim(s_user_id));
                in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));
                in_node.AddString("MAT_ID", MPCF.Trim(s_mat_id));
                in_node.AddString("FLOW", MPCF.Trim(s_flow));
                in_node.AddString("OPER", MPCF.Trim(s_oper));
                in_node.AddString("RES_ID", MPCF.Trim(s_res_id));
                in_node.AddString("AREA_ID", MPCF.Trim(s_area_id));
                in_node.AddString("SUB_AREA_ID", MPCF.Trim(s_subarea_id));
                in_node.AddChar("EXCLUDE_SYS_MSG_FLAG", b_exclude_sys_msg == true ? 'Y' : ' ');

                if (MPCR.CallService("BAS", "BAS_View_BBS_Msg_List", in_node, ref out_node) == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }

        /* Added by DM KIM 2012.05.07 View Message Popup List End */


        /*  Added by YG SON 2012.11.16 View Check Query List
         *  ViewCheckQueryList()
         *       - View Check Query List
         *  Return Value
         *       - boolean : True / False
         *  Arguments
         *       - Control control                    : List control
         *       - char c_step                        : Process Step
         *       - string query_type                  : Query Type(GCM Table : CHECK_QUERY_TYPE)
         *       - TreeNode parentNode                : Tree Node
         *       - string sExtFactory                 : Extended Factory
         */
        public static bool ViewCheckQueryList(Control control, char c_step, string query_type)
        {
            return ViewCheckQueryList(control, c_step, query_type, null, "");
        }
        public static bool ViewCheckQueryList(Control control, char c_step, string query_type, TreeNode parentNode, string s_ext_factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_CHECK_QUERY_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CHECK_QUERY_LIST_OUT");

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

            in_node.AddString("QUERY_TYPE", query_type);
            in_node.AddString("NEXT_QUERY_ID", "");

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Check_Query_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY_ID")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY")), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY_ID")));
                    }
                }
                in_node.SetString("NEXT_QUERY_ID", out_node.GetString("NEXT_QUERY_ID"));
            } while (in_node.GetString("NEXT_QUERY_ID") != "");

            return true;
        }

        /*  Added by YG SON 2012.11.16 View Checklist List
         *  ViewChecklistList()
         *       - View Checklist List
         *  Return Value
         *       - boolean : True / False
         *  Arguments
         *       - Control control                    : List control
         *       - char c_step                        : Process Step
         *       - TreeNode parentNode                : Tree Node
         *       - string sExtFactory                 : Extended Factory
         * 
         */
        public static bool ViewChecklistList(Control control, char c_step, string chklist_type)
        {
            return ViewChecklistList(control, c_step, chklist_type, null, "");
        }

        public static bool ViewChecklistList(Control control, char c_step, string chklist_type, TreeNode parentNode, string s_ext_factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_CHECKLIST_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CHECKLIST_LIST_OUT");

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

            in_node.AddString("CHKLIST_TYPE", chklist_type);
            in_node.AddString("NEXT_CHKLIST_ID", "");

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Checklist_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_ID")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (((ListView)control).Columns.Count > 2)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_TYPE")));
                        }
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_DESC")), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_ID")));
                    }
                }
                in_node.SetString("NEXT_CHKLIST_ID", out_node.GetString("NEXT_CHKLIST_ID"));
            } while (in_node.GetString("NEXT_CHKLIST_ID") != "");

            return true;
        }


        /*  Added by YG SON 2012.11.16 View Checklist List
         *  ViewChecklistQueryList()
         *       - View Checklist Query List
         *  Return Value
         *       - boolean : True / False
         *  Arguments
         *       - Control control                    : List control
         *       - char c_step                        : Process Step
         *       - TreeNode parentNode                : Tree Node
         *       - string sExtFactory                 : Extended Factory
         * 
         */
        public static bool ViewChecklistQueryList(Control control, char c_step, string chklist_id)
        {
            return ViewChecklistQueryList(control, c_step, chklist_id, null, "");
        }

        public static bool ViewChecklistQueryList(Control control, char c_step, string chklist_id, TreeNode parentNode, string s_ext_factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_CHECKLIST_QUERY_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CHECKLIST_QUERY_LIST_OUT");

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

            in_node.AddString("CHKLIST_ID", chklist_id);
            in_node.AddString("NEXT_QUERY_ID", "");

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Checklist_Query_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY_ID")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("REQUIRE_FLAG")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetChar("REQUIRE_FLAG")), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("QUERY_ID")));
                    }
                }
                in_node.SetString("NEXT_QUERY_ID", out_node.GetString("NEXT_QUERY_ID"));
            } while (in_node.GetString("NEXT_QUERY_ID") != "");

            return true;
        }

        /*  Added by YG SON 2012.11.16 View Checklist Relation List
         *  ViewChecklistQueryList()
         *       - View Checklist Relation List
         *  Return Value
         *       - boolean : True / False
         *  Arguments
         *       - Control control                    : List control
         *       - char c_step                        : Process Step
         *       - TreeNode parentNode                : Tree Node
         *       - string sExtFactory                 : Extended Factory
         * 
         */
        public static bool ViewChecklistRelationList(Control control, char c_step, char rel_level, string mat_id, int mat_ver, string flow, string oper, string resg_id, string res_type, string res_id)
        {
            return ViewChecklistRelationList(control, c_step, rel_level, mat_id, mat_ver, flow, oper, resg_id, res_type, res_id, null, "");
        }

        public static bool ViewChecklistRelationList(Control control, char c_step, char rel_level, string mat_id, int mat_ver, string flow, string oper, string resg_id, string res_type, string res_id, TreeNode parentNode, string s_ext_factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_CHECKLIST_RELATION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CHECKLIST_RELATION_LIST_OUT");

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

            in_node.AddChar("REL_LEVEL", rel_level);
            in_node.AddString("MAT_ID", mat_id);
            in_node.AddInt("MAT_VER", mat_ver);
            in_node.AddString("FLOW", flow);
            in_node.AddString("OPER", oper);
            in_node.AddString("RESG_ID", resg_id);
            in_node.AddString("RES_TYPE", res_type);
            in_node.AddString("RES_ID", res_id);
            in_node.AddString("NEXT_CHKLIST_ID", "");

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Checklist_Relation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_ID")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            if (c_step == '1')
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("INHERIT_CHILD_FLAG")));
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CODE")));
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("REQ_COMPLETE_FLAG")));
                                itmX.SubItems.Add(MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME")), DATE_TIME_FORMAT.DATETIME) + " ~ " + MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME")), DATE_TIME_FORMAT.DATETIME));
                            }
                            //else if (c_step == '2')
                            //{
                            //    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")));
                            //    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("REQ_COMPLETE_FLAG")));
                            //    itmX.SubItems.Add(MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME")), DATE_TIME_FORMAT.DATETIME) + " ~ " + MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME")), DATE_TIME_FORMAT.DATETIME));
                            //}
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        if (c_step == '1')
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetChar("INHERIT_CHILD_FLAG")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CODE")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetChar("REQ_COMPLETE_FLAG")) + " : " + MPCF.DestroyDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME"))) + " ~ " + MPCF.DestroyDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_TO_TIME"))), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);
                        }
                        //else if (c_step == '2')
                        //{
                        //    nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetChar("REQ_COMPLETE_FLAG")) + " : " + MPCF.DestroyDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME"))) + " ~ " + MPCF.DestroyDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_TO_TIME"))), (int)SMALLICON_INDEX.IDX_MESSAGE, (int)SMALLICON_INDEX.IDX_MESSAGE);
                        //}
                        else
                        {
                            nodeX = null;
                        }

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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_ID")));
                    }
                }
                in_node.SetString("NEXT_CHKLIST_ID", out_node.GetString("NEXT_CHKLIST_ID"));
            } while (in_node.GetString("NEXT_CHKLIST_ID") != "");

            return true;
        }

        // Add by DM KIM 2013.08.21
        // ViewBatchJobProcessorList()
        //       - View Batch Process List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : List Control
        //        - ByVal c_step As String                        : Process Step
        //        - Optional ByVal iImage_idx As Integer = -1    : Image Index
        //        - Optional ByVal parentNode As TreeNode = null    : Tree Node Parent Node
        //        - Optional ByVal sExt_Factory As String = "": Extra Factory

        public static bool ViewBatchJobProcessorList(Control control)
        {
            return ViewBatchJobProcessorList(control, '1', -1, null, "");
        }
        public static bool ViewBatchJobProcessorList(Control control, char c_step, int iImage_idx, TreeNode parentNode, string sExt_Factory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_BATCH_JOB_PROCESSOR_LIST_IN");
            TRSNode out_node;

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
                out_node = new TRSNode("VIEW_JOB_PROCESS_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Batch_Job_Processor_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_JOB_PROC_ID", out_node.GetString("NEXT_JOB_PROC_ID"), true);
            } while (out_node.GetString("NEXT_JOB_PROC_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        // Batch Process ¿« ¡¯«‡ ø©∫Œø° µ˚∂Û Ω««‡ æ∆¿Ãƒ‹ ¥Ÿ∏£∞‘ «•Ω√
                        // Step¿Ã 1¿Ã∏È Default æ∆¿Ãƒ‹¿∏∑Œ «•Ω√
                        if (iImage_idx == -1)
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("JOB_PROC_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE);
                        }
                        else
                        {
                            if (out_node.GetList(0)[i].GetChar("STATUS_FLAG") == 'C')
                            {
                                itmX = new ListViewItem(out_node.GetList(0)[i].GetString("JOB_PROC_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN);
                            }
                            else if (out_node.GetList(0)[i].GetChar("STATUS_FLAG") == 'P')
                            {
                                itmX = new ListViewItem(out_node.GetList(0)[i].GetString("JOB_PROC_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE_PROC);
                            }
                            else
                            {
                                itmX = new ListViewItem(out_node.GetList(0)[i].GetString("JOB_PROC_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE);
                            }
                        }

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("JOB_PROC_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        // Batch Process ¿« ¡¯«‡ ø©∫Œø° µ˚∂Û Ω««‡ æ∆¿Ãƒ‹ ¥Ÿ∏£∞‘ «•Ω√
                        // Step¿Ã 1¿Ã∏È Default æ∆¿Ãƒ‹¿∏∑Œ «•Ω√
                        if (iImage_idx == -1)
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("JOB_PROC_ID") + " : " + out_node.GetList(0)[i].GetString("JOB_PROC_DESC"), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        }
                        else
                        {
                            if (out_node.GetList(0)[i].GetChar("STATUS_FLAG") == 'F')   // Fail
                            {
                                nodeX = new TreeNode(out_node.GetList(0)[i].GetString("JOB_PROC_ID") + " : " + out_node.GetList(0)[i].GetString("JOB_PROC_DESC"), (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN, (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN);
                            }
                            else if (out_node.GetList(0)[i].GetChar("STATUS_FLAG") == 'P') // Process
                            {
                                nodeX = new TreeNode(out_node.GetList(0)[i].GetString("JOB_PROC_ID") + " : " + out_node.GetList(0)[i].GetString("JOB_PROC_DESC"), (int)SMALLICON_INDEX.IDX_RESOURCE_PROC, (int)SMALLICON_INDEX.IDX_RESOURCE_PROC);
                            }
                            else
                            {
                                // Success
                                nodeX = new TreeNode(out_node.GetList(0)[i].GetString("JOB_PROC_ID") + " : " + out_node.GetList(0)[i].GetString("JOB_PROC_DESC"), (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_RESOURCE);
                            }
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("JOB_PROC_ID"));
                    }
                }
            }

            return true;

        }
    }
}

