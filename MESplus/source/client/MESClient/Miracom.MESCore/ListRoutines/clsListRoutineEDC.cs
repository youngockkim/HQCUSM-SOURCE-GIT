
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modEDCListRoutine.vb
//   Description : Client Common List function EDC Module
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
//#If _EDC = True Then

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
    public sealed class EDCLIST
    {
        
        #region "Constant Defintion"
        
        //spdCharacter
        private const int CHAR_ID = 0;
        private const int CHAR_DESC = 1;
        private const int UNIT_COUNT = 2;
        private const int VALUE_COUNT = 3;
        private const int DISPLAY_PRECISION = 4;
        private const int VALUE_TBL = 5;
        private const int DEF_VALUE = 6;
        private const int OPT_INPUT_FLAG = 7;
        private const int BLANK_REC_SAVE_FLAG = 8;
        private const int DEF_UNIT_FLAG = 9;
        private const int DEF_UNIT_OVR_FLAG = 10;
        private const int UNIT_TBL = 11;
        private const int SPEC_TYPE = 12;
        private const int SPEC_OUT_COUNT = 13;
        private const int TARGET_VALUE = 14;
        private const int UPPER_SPEC_LIMIT = 15;
        private const int LOWER_SPEC_LIMIT = 16;
        private const int UPPER_WARN_LIMIT = 17;
        private const int LOWER_WARN_LIMIT = 18;
        private const int SPEC_INFO = 19;
        private const int SPEC_OUT_ALARM = 20;
        private const int WARN_OUT_ALARM = 21;
        private const int DERIVED_PARAM_FLAG = 22;
        private const int DERIVED_PARAMETER = 23;
        
        #endregion
        
        // ViewEDCCharacterList()
        //       - View Character list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                     : List control
        //        - ByVal c_step As String                      : Process Step
        //        - Optional ByVal iImage_idx As Integer = -1    : List View???§Ïñ¥Í∞??ÑÏù¥ÏΩ??∏Îç±??
        //        - Optional ByVal sExt_Factory As String = ""  : ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //       - Optional ByVal Col As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Column Index (-1?¥Î©¥ ?πÏ†ï Row ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //       - Optional ByVal Row As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Row Index (-1?¥Î©¥ ?πÏ†ï Column ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //
        public static bool ViewEDCCharacterList(Control control, char c_step, char c_char_type)
        {
            return ViewEDCCharacterList(control, c_step, c_char_type, "", "", null, "");
        }
        public static bool ViewEDCCharacterList(Control control, char c_step, char c_char_type, string strFilter)
        {
            return ViewEDCCharacterList(control, c_step, c_char_type, "", strFilter, null, "");
        }
        public static bool ViewEDCCharacterList(Control control, char c_step, char c_char_type, string strColSetID, string strFilter)
        {
            return ViewEDCCharacterList(control, c_step, c_char_type, strColSetID, strFilter, null, "");
        }
        public static bool ViewEDCCharacterList(Control control, char c_step, char c_char_type, string strColSetID, TreeNode parentNode, string sExt_Factory)
        {
            return ViewEDCCharacterList(control, c_step, c_char_type, strColSetID, "", parentNode, sExt_Factory);
        }
        public static bool ViewEDCCharacterList(Control control, char c_step, char c_char_type, string strColSetID, string strFilter, TreeNode parentNode, string sExt_Factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("View_Character_In");
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
            
            in_node.AddString("FILTER", MPCF.Trim(strFilter));
            in_node.AddString("COL_SET_ID", MPCF.Trim(strColSetID));
            in_node.AddChar("CHAR_TYPE", c_char_type);
            in_node.AddString("NEXT_CHAR_ID", "");

            
            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCR.CallService("EDC", "EDC_View_Character_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_CHAR_ID", out_node.GetString("NEXT_CHAR_ID"));

            } while (in_node.GetString("NEXT_CHAR_ID") != "") ;

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("CHAR_ID"), (int)SMALLICON_INDEX.IDX_CHARACTER);
                        itmX.Tag = out_node.GetList(0)[i].GetChar("VALUE_TYPE");
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("CHAR_ID") + " : " + out_node.GetList(0)[i].GetString("CHAR_DESC"), (int)SMALLICON_INDEX.IDX_CHARACTER, (int)SMALLICON_INDEX.IDX_CHARACTER);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("CHAR_ID"));

                    }
                }
            }


            return true;
            
        }
        
        // ViewEDCColSetList()
        //       - View Collection Set List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal iImage_idx As Integer = -1    : List View???§Ïñ¥Í∞??ÑÏù¥ÏΩ??∏Îç±??
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //       - Optional ByVal Col As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Column Index (-1?¥Î©¥ ?πÏ†ï Row ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        //       - Optional ByVal Row As Integer = -1        : Spread Ïª®Ìä∏Î°§Ïùº Í≤ΩÏö∞ ?∞Ïù¥?ÄÎ•?ÎøåÎ†§Ï§?Row Index (-1?¥Î©¥ ?πÏ†ï Column ?ÑÏ≤¥??ÎøåÎ†§Ï§?
        
        public static bool ViewEDCColSetList(Control control, char c_step, TreeNode parentNode, string sExt_Factory, int Col, int Row, char LotResFlag, bool IncludeDeleteSet)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            string[] strData = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_COL_SET_LIST_IN");
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

            in_node.AddChar("LOT_OR_RES_FLAG", LotResFlag);
            in_node.AddString("NEXT_COL_SET_ID", "");
            
            do
            {
                out_node = new TRSNode("VIEW_COL_SET_LIST_OUT");

                if (MPCR.CallService("EDC", "EDC_View_Col_Set_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);
                in_node.SetString("NEXT_COL_SET_ID", out_node.GetString("NEXT_COL_SET_ID"));

            } while (in_node.GetString("NEXT_COL_SET_ID") != "") ;

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (IncludeDeleteSet == false && out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                    {
                        continue;
                    }

                    if (control is ListView)
                    {
                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("COL_SET_ID"), (int)SMALLICON_INDEX.IDX_COL_SET_DELETE);
                            itmX.ForeColor = Color.Magenta;
                        }
                        else
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("COL_SET_ID"), (int)SMALLICON_INDEX.IDX_COL_SET);
                        }
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("COL_SET_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("COL_SET_ID") + " : " + out_node.GetList(0)[i].GetString("COL_SET_DESC"), (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("COL_SET_ID"));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("COL_SET_ID"));
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
        
        // ViewEDCColSetVersionList()
        //       - View Collection Set Version List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal iImage_idx As Integer = -1    : List View???§Ïñ¥Í∞??ÑÏù¥ÏΩ??∏Îç±??
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        
        public static bool ViewEDCColSetVersionList(Control control, char c_step, string ColSetID, int iImage_idx, TreeNode parentNode, string sExt_Factory)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_COL_SET_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_COL_SET_VERSION_LIST_OUT"); ;
            
            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }
            
            if (iImage_idx == - 1)
            {
                iImage_idx =  (int)SMALLICON_INDEX.IDX_COL_SET_VERSION;
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
            
            in_node.AddString("COL_SET_ID", ColSetID);

            if (c_step == '1')
            {
                in_node.AddInt("NEXT_COL_SET_VERSION", 0);
            }
            else if (c_step == '2')
            {
                in_node.AddInt("NEXT_COL_SET_VERSION", int.MaxValue);
            }
            
            
            do
            {
                if (MPCR.CallService("EDC", "EDC_View_Col_Set_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("COL_SET_VERSION").ToString(), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
                        ((ListView) control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("COL_SET_VERSION").ToString(), (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("COL_SET_VERSION").ToString());
                    }
                }

                in_node.SetInt("NEXT_COL_SET_VERSION", out_node.GetInt("NEXT_COL_SET_VERSION"));

            } while (in_node.GetInt("NEXT_COL_SET_VERSION") > 0);
            
            return true;
            
        }
        
        // View_Col_Set_Version_List()
        //       - View Collection Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - Optional ByVal c_step As String = "1"
        //       - ByVal sColSetId As String
        //
        public static bool ViewEDCColSetVersionList(FarPoint.Win.Spread.FpSpread spdVersion, string sColSetId, char c_step)
        {

            int i;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_COL_SET_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_COL_SET_VERSION_LIST_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;                
                in_node.AddString("COL_SET_ID", sColSetId);
                in_node.AddInt("NEXT_COL_SET_VERSION", int.MaxValue);

                do
                {
                    if (MPCR.CallService("EDC", "EDC_View_Col_Set_Version_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    spdVersion.ActiveSheet.RowCount = out_node.GetList(0).Count;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        FarPoint.Win.Spread.SheetView with_1 = spdVersion.ActiveSheet;

                        with_1.SetValue(LastRow, 0, out_node.GetList(0)[i].GetInt("COL_SET_VERSION").ToString());
                        with_1.SetValue(LastRow, 1, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_START_TIME")));
                        with_1.SetValue(LastRow, 2, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_END_TIME")));
                        with_1.SetValue(LastRow, 3, ((out_node.GetList(0)[i].GetChar("APPROVAL_FLAG") == 'Y') ? "V" : ""));
                        with_1.SetValue(LastRow, 4, out_node.GetList(0)[i].GetString("APPROVAL_USER_ID"));
                        with_1.SetValue(LastRow, 5, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPROVAL_TIME")));
                        with_1.SetValue(LastRow, 6, ((out_node.GetList(0)[i].GetChar("RELEASE_FLAG") == 'Y') ? "V" : ""));
                        with_1.SetValue(LastRow, 7, out_node.GetList(0)[i].GetString("RELEASE_USER_ID"));
                        with_1.SetValue(LastRow, 8, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RELEASE_TIME")));

                        LastRow++;
                    }

                    in_node.SetInt("NEXT_COL_SET_VERSION", out_node.GetInt("NEXT_COL_SET_VERSION"));

                } while(in_node.GetInt("NEXT_COL_SET_VERSION") > 0);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        
        
        // ViewEDCAttachCharacterList()
        //       - View General Code Table list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                        : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                            : ?ïÏû• Process Step
        //        - Optional ByVal iImage_idx As Integer = -1        : List View???§Ïñ¥Í∞??ÑÏù¥ÏΩ??∏Îç±??
        //       - Optional ByVal sColSetId As String = ""       : Collection Set ID
        //       - Optional ByVal sColSetVersion As String = ""  : Collection Set Version
        //        - Optional ByVal sExt_Factory As String = ""    : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal sTreeItem As String = ""        : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewEDCAttachCharacterList(Control control, char c_step, int iImage_idx, string sColSetId, string sColSetVersion, TreeNode parentNode, string sExt_Factory, int Col, int Row, char cIncludeUnitID)
        {
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            string[] strData = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            ArrayList a_list = new ArrayList();
            
            TRSNode in_node = new TRSNode("View_Attach_Character_List_In");
            TRSNode out_node;
            
            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }
            
            if (iImage_idx == - 1)
            {
                iImage_idx = (int)SMALLICON_INDEX.IDX_CODE_TABLE;
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

            in_node.AddChar("INCLUDE_UNIT_ID", cIncludeUnitID);
            in_node.AddString("COL_SET_ID", sColSetId);
            in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(sColSetVersion));
            in_node.AddString("NEXT_CHAR_ID", "");
            
            do
            {
                out_node = new TRSNode("View_Attach_Character_List_Out");

                if (MPCR.CallService("EDC", "EDC_View_Attach_Character_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);
                
                in_node.SetString("NEXT_CHAR_ID", out_node.GetString("NEXT_CHAR_ID"));

            } while (in_node.GetString("NEXT_CHAR_ID") != "");

            foreach(object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("CHAR_ID"), (int)SMALLICON_INDEX.IDX_CHARACTER);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("CHAR_ID") + " : " + out_node.GetList(0)[i].GetString("CHAR_ID"), (int)SMALLICON_INDEX.IDX_CHARACTER, (int)SMALLICON_INDEX.IDX_CHARACTER);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("CHAR_ID"));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("CHAR_ID"));
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
        
        // ViewLotDataByLot()
        //       - View Lot Data by Lot
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sLotID As String                    : Lot id
        //       - ByVal iHistSeq As Integer                 : History Sequence
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete HistoryÍπåÏ? ?¨Ìï®??Í≤ÉÏù∏ÏßÄ?
        //       - Optional ByVal sTreeItem As String = ""           : Tree Item Í∞?
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨ Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏ÏßÄ?
        //
        public static bool ViewLotDataByLot(Control control, char c_step, string sLotID, int iHistSeq, char sIncludeDelHistory, TreeNode parentNode, bool bIgnoreError)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int k;
            int m;
            int iRow;
            int iMaxValueCount = 0;
            int COL_VALUE = 22;
            string s_spec_out_mask;
            int iPrecision = 0;


            TRSNode in_node = new TRSNode("VIEW_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_DATA_OUT");

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
            in_node.AddInt("HIST_SEQ", iHistSeq);
            in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDelHistory);
            in_node.AddString("NEXT_COL_SET_ID", " ");
            in_node.AddInt("NEXT_CHAR_SEQ_NUM", 0);
            in_node.AddInt("NEXT_UNIT_SEQ_NUM", 0);
            in_node.AddInt("NEXT_VALUE_SEQ_NUM", 0);
            in_node.AddInt("NEXT_COL_SEQ", 0);

            do
            {
                if (MPCR.CallService("EDC", "EDC_View_Lot_Data", in_node, ref out_node) == false)
                {
                    return false;
                }
                

                if (control is FarPoint.Win.Spread.FpSpread)
                {
                    sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;
                    

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = sheetX.RowCount;
                        sheetX.RowCount ++;
                        if (out_node.GetList(0)[i].GetChar("HIS_DEL_FLAG") == 'Y')
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }

                        //CHARACTER¿« DISPLAY_PRECISION
                        iPrecision = out_node.GetList(0)[i].GetInt("DISPLAY_PRECISION");

                        sheetX.Cells[iRow, 1].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                        sheetX.Cells[iRow, 2].Value = out_node.GetList(0)[i].GetInt("COL_SEQ");
                        sheetX.Cells[iRow, 3].Value = out_node.GetList(0)[i].GetString("TRAN_TIME");
                        sheetX.Cells[iRow, 4].Value = out_node.GetList(0)[i].GetChar("HIS_DEL_FLAG");
                        sheetX.Cells[iRow, 5].Value = out_node.GetList(0)[i].GetString("FACTORY");
                        sheetX.Cells[iRow, 6].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        // mat_ver - «•Ω√«œ¡ˆæ ¿Ω
                        sheetX.Cells[iRow, 7].Value = out_node.GetList(0)[i].GetString("FLOW");
                        sheetX.Cells[iRow, 8].Value = out_node.GetList(0)[i].GetString("OPER");
                        sheetX.Cells[iRow, 9].Value = out_node.GetList(0)[i].GetString("MEAS_RES_ID");
                        sheetX.Cells[iRow, 10].Value = out_node.GetList(0)[i].GetString("PROC_FLOW");
                        sheetX.Cells[iRow, 11].Value = out_node.GetList(0)[i].GetString("COL_SET_ID");
                        sheetX.Cells[iRow, 12].Value = out_node.GetList(0)[i].GetInt("COL_SET_VERSION");
                        sheetX.Cells[iRow, 13].Value = out_node.GetList(0)[i].GetInt("CHAR_SEQ_NUM");
                        sheetX.Cells[iRow, 14].Value = out_node.GetList(0)[i].GetString("CHAR_ID");
                        sheetX.Cells[iRow, 15].Value = out_node.GetList(0)[i].GetString("CHAR_DESC");
                        sheetX.Cells[iRow, 16].Value = MPCF.GetSpecInfo(out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"), 
                                                                        out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"), 
                                                                        out_node.GetList(0)[i].GetString("TARGET_VALUE"));
                        sheetX.Cells[iRow, 17].Value = out_node.GetList(0)[i].GetInt("UNIT_SEQ_NUM");
                        sheetX.Cells[iRow, 18].Value = out_node.GetList(0)[i].GetString("UNIT_ID");
                        sheetX.Cells[iRow, 19].Value = out_node.GetList(0)[i].GetInt("VALUE_SEQ_NUM");
                        sheetX.Cells[iRow, 20].Value = out_node.GetList(0)[i].GetChar("VALUE_TYPE");
                        sheetX.Cells[iRow, 21].Value = out_node.GetList(0)[i].GetInt("VALUE_COUNT");

                        if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                        {
                            if (out_node.GetList(0)[i].GetString("VALUE_1") != "")
                                sheetX.Cells[iRow, COL_VALUE + 0].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_1"));
                            if (out_node.GetList(0)[i].GetString("VALUE_2") != "")
                                sheetX.Cells[iRow, COL_VALUE + 1].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_2"));
                            if (out_node.GetList(0)[i].GetString("VALUE_3") != "")
                                sheetX.Cells[iRow, COL_VALUE + 2].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_3"));
                            if (out_node.GetList(0)[i].GetString("VALUE_4") != "")
                                sheetX.Cells[iRow, COL_VALUE + 3].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_4"));
                            if (out_node.GetList(0)[i].GetString("VALUE_5") != "")
                                sheetX.Cells[iRow, COL_VALUE + 4].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_5"));
                            if (out_node.GetList(0)[i].GetString("VALUE_6") != "")
                                sheetX.Cells[iRow, COL_VALUE + 5].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_6"));
                            if (out_node.GetList(0)[i].GetString("VALUE_7") != "")
                                sheetX.Cells[iRow, COL_VALUE + 6].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_7"));
                            if (out_node.GetList(0)[i].GetString("VALUE_8") != "")
                                sheetX.Cells[iRow, COL_VALUE + 7].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_8"));
                            if (out_node.GetList(0)[i].GetString("VALUE_9") != "")
                                sheetX.Cells[iRow, COL_VALUE + 8].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_9"));
                            if (out_node.GetList(0)[i].GetString("VALUE_10") != "")
                                sheetX.Cells[iRow, COL_VALUE + 9].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_10"));
                            if (out_node.GetList(0)[i].GetString("VALUE_11") != "")
                                sheetX.Cells[iRow, COL_VALUE + 10].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_11"));
                            if (out_node.GetList(0)[i].GetString("VALUE_12") != "")
                                sheetX.Cells[iRow, COL_VALUE + 11].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_12"));
                            if (out_node.GetList(0)[i].GetString("VALUE_13") != "")
                                sheetX.Cells[iRow, COL_VALUE + 12].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_13"));
                            if (out_node.GetList(0)[i].GetString("VALUE_14") != "")
                                sheetX.Cells[iRow, COL_VALUE + 13].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_14"));
                            if (out_node.GetList(0)[i].GetString("VALUE_15") != "")
                                sheetX.Cells[iRow, COL_VALUE + 14].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_15"));
                            if (out_node.GetList(0)[i].GetString("VALUE_16") != "")
                                sheetX.Cells[iRow, COL_VALUE + 15].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_16"));
                            if (out_node.GetList(0)[i].GetString("VALUE_17") != "")
                                sheetX.Cells[iRow, COL_VALUE + 16].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_17"));
                            if (out_node.GetList(0)[i].GetString("VALUE_18") != "")
                                sheetX.Cells[iRow, COL_VALUE + 17].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_18"));
                            if (out_node.GetList(0)[i].GetString("VALUE_19") != "")
                                sheetX.Cells[iRow, COL_VALUE + 18].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_19"));
                            if (out_node.GetList(0)[i].GetString("VALUE_20") != "")
                                sheetX.Cells[iRow, COL_VALUE + 19].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_20"));
                            if (out_node.GetList(0)[i].GetString("VALUE_21") != "")
                                sheetX.Cells[iRow, COL_VALUE + 20].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_21"));
                            if (out_node.GetList(0)[i].GetString("VALUE_22") != "")
                                sheetX.Cells[iRow, COL_VALUE + 21].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_22"));
                            if (out_node.GetList(0)[i].GetString("VALUE_23") != "")
                                sheetX.Cells[iRow, COL_VALUE + 22].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_23"));
                            if (out_node.GetList(0)[i].GetString("VALUE_24") != "")
                                sheetX.Cells[iRow, COL_VALUE + 23].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_24"));
                            if (out_node.GetList(0)[i].GetString("VALUE_25") != "")
                                sheetX.Cells[iRow, COL_VALUE + 24].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_25"));
                        }
                        else
                        {
                            sheetX.Cells[iRow, COL_VALUE + 0].Value = out_node.GetList(0)[i].GetString("VALUE_1");
                            sheetX.Cells[iRow, COL_VALUE + 1].Value = out_node.GetList(0)[i].GetString("VALUE_2");
                            sheetX.Cells[iRow, COL_VALUE + 2].Value = out_node.GetList(0)[i].GetString("VALUE_3");
                            sheetX.Cells[iRow, COL_VALUE + 3].Value = out_node.GetList(0)[i].GetString("VALUE_4");
                            sheetX.Cells[iRow, COL_VALUE + 4].Value = out_node.GetList(0)[i].GetString("VALUE_5");
                            sheetX.Cells[iRow, COL_VALUE + 5].Value = out_node.GetList(0)[i].GetString("VALUE_6");
                            sheetX.Cells[iRow, COL_VALUE + 6].Value = out_node.GetList(0)[i].GetString("VALUE_7");
                            sheetX.Cells[iRow, COL_VALUE + 7].Value = out_node.GetList(0)[i].GetString("VALUE_8");
                            sheetX.Cells[iRow, COL_VALUE + 8].Value = out_node.GetList(0)[i].GetString("VALUE_9");
                            sheetX.Cells[iRow, COL_VALUE + 9].Value = out_node.GetList(0)[i].GetString("VALUE_10");
                            sheetX.Cells[iRow, COL_VALUE + 10].Value = out_node.GetList(0)[i].GetString("VALUE_11");
                            sheetX.Cells[iRow, COL_VALUE + 11].Value = out_node.GetList(0)[i].GetString("VALUE_12");
                            sheetX.Cells[iRow, COL_VALUE + 12].Value = out_node.GetList(0)[i].GetString("VALUE_13");
                            sheetX.Cells[iRow, COL_VALUE + 13].Value = out_node.GetList(0)[i].GetString("VALUE_14");
                            sheetX.Cells[iRow, COL_VALUE + 14].Value = out_node.GetList(0)[i].GetString("VALUE_15");
                            sheetX.Cells[iRow, COL_VALUE + 15].Value = out_node.GetList(0)[i].GetString("VALUE_16");
                            sheetX.Cells[iRow, COL_VALUE + 16].Value = out_node.GetList(0)[i].GetString("VALUE_17");
                            sheetX.Cells[iRow, COL_VALUE + 17].Value = out_node.GetList(0)[i].GetString("VALUE_18");
                            sheetX.Cells[iRow, COL_VALUE + 18].Value = out_node.GetList(0)[i].GetString("VALUE_19");
                            sheetX.Cells[iRow, COL_VALUE + 19].Value = out_node.GetList(0)[i].GetString("VALUE_20");
                            sheetX.Cells[iRow, COL_VALUE + 20].Value = out_node.GetList(0)[i].GetString("VALUE_21");
                            sheetX.Cells[iRow, COL_VALUE + 21].Value = out_node.GetList(0)[i].GetString("VALUE_22");
                            sheetX.Cells[iRow, COL_VALUE + 22].Value = out_node.GetList(0)[i].GetString("VALUE_23");
                            sheetX.Cells[iRow, COL_VALUE + 23].Value = out_node.GetList(0)[i].GetString("VALUE_24");
                            sheetX.Cells[iRow, COL_VALUE + 24].Value = out_node.GetList(0)[i].GetString("VALUE_25");
                        }
                        for (k = COL_VALUE; k < COL_VALUE + 25; k++)
                        {
                            if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                            {
                                //DISPLAY PRECISION ¿˚øÎ
                                if (iPrecision > 0 && sheetX.Cells[iRow, k].Value != null)
                                {
                                    sheetX.Cells[iRow, k].Value = MPCF.SetPrecision(sheetX.Cells[iRow, k].Value.ToString(), iPrecision);
                                }                                
                                MPCR.SetNumberCell(sheetX.Cells[iRow, k]);                                
                            }
                            else
                            {
                                MPCR.SetAsciiCell(sheetX.Cells[iRow, k]);
                            }
                        }
                        sheetX.Cells[iRow, 47].Value = out_node.GetList(0)[i].GetString("SPEC_OUT_MASK");
                        sheetX.Cells[iRow, 48].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                        sheetX.Cells[iRow, 49].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"));

                        if (iMaxValueCount < out_node.GetList(0)[i].GetInt("VALUE_COUNT"))
                        {
                            iMaxValueCount = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                        }

                        s_spec_out_mask = out_node.GetList(0)[i].GetString("SPEC_OUT_MASK");
                        if (s_spec_out_mask != "")
                        {
                            for (m = 0; m < s_spec_out_mask.Length; m++)
                            {
                                if (s_spec_out_mask[m] == '1' ||
                                    s_spec_out_mask[m] == '4' ||
                                    s_spec_out_mask[m] == '5')
                                {
                                    sheetX.Cells[iRow, COL_VALUE + m].BackColor = Color.Red;
                                }
                                else if (s_spec_out_mask[m] == '2' ||
                                         s_spec_out_mask[m] == '3')
                                {
                                    sheetX.Cells[iRow, COL_VALUE + m].BackColor = Color.Yellow;
                                }
                                else
                                {
                                    sheetX.Cells[iRow, COL_VALUE + m].BackColor = Color.White;
                                }
                            }
                        }

                        iRow++;
                    }
                }

                in_node.SetString("NEXT_COL_SET_ID", out_node.GetString("NEXT_COL_SET_ID"));
                in_node.SetInt("NEXT_CHAR_SEQ_NUM", out_node.GetInt("NEXT_CHAR_SEQ_NUM"));
                in_node.SetInt("NEXT_UNIT_SEQ_NUM", out_node.GetInt("NEXT_UNIT_SEQ_NUM"));
                in_node.SetInt("NEXT_VALUE_SEQ_NUM", out_node.GetInt("NEXT_VALUE_SEQ_NUM"));
                in_node.SetInt("NEXT_COL_SEQ", out_node.GetInt("NEXT_COL_SEQ"));

            } while (in_node.GetString("NEXT_COL_SET_ID") !="" || 
                     in_node.GetInt("NEXT_CHAR_SEQ_NUM") > 0 ||
                     in_node.GetInt("NEXT_UNIT_SEQ_NUM") > 0 ||
                     in_node.GetInt("NEXT_VALUE_SEQ_NUM") > 0 ||
                         in_node.GetInt("NEXT_COL_SEQ") > 0);


            if (control is FarPoint.Win.Spread.FpSpread)
            {
                sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;

                if (sheetX.RowCount > 0)
                {
                    if (iMaxValueCount == 0)
                    {
                        iMaxValueCount = 1;
                    }
                    sheetX.Columns.Get(COL_VALUE, COL_VALUE + iMaxValueCount - 1).Visible = true;
                    if (iMaxValueCount < 25)
                    {
                        sheetX.Columns.Get(COL_VALUE + iMaxValueCount, COL_VALUE + 24).Visible = false;
                    }
                }
            }

            return true;

        }

        
        // ViewResourceData()
        //       - View Resource Data
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sResID As String                    : Lot id
        //       - ByVal iHistSeq As Integer                 : History Sequence
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete HistoryÍπåÏ? ?¨Ìï®??Í≤ÉÏù∏ÏßÄ?
        //       - Optional ByVal sTreeItem As String = ""           : Tree Item Í∞?
        //       - Optional ByVal bIgnoreError As Boolean = False    : ?êÎü¨ Î∞úÏÉù??Î¨¥Ïãú??Í≤ÉÏù∏ÏßÄ?
        //
        public static bool ViewResourceData(Control control, char c_step, string sResID, string sSubResID, string sEventID, int iHistSeq, char sIncludeDelHistory, TreeNode parentNode, bool bIgnoreError)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int i, j;
            int iRow;
            int iMaxValueCount = 0;
            int COL_VALUE = 15;
            int iPrecision = 0;

            TRSNode in_node = new TRSNode("VIEW_RESOURCE_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_DATA_OUT");

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
            in_node.AddString("EVENT_ID", sEventID);
            in_node.AddInt("HIST_SEQ", iHistSeq);
            in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDelHistory);
            in_node.AddInt("NEXT_CHAR_SEQ_NUM", 0);
            in_node.AddInt("NEXT_UNIT_SEQ_NUM", 0);
            in_node.AddInt("NEXT_VALUE_SEQ_NUM", 0);
            in_node.AddInt("NEXT_COL_SEQ", 0);

            do
            {
                if (MPCR.CallService("EDC", "EDC_View_Resource_Data", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sheetX = ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        //CHARACTER¿« DISPLAY_PRECISION
                        iPrecision = out_node.GetList(0)[i].GetInt("DISPLAY_PRECISION");

                        if (out_node.GetList(0)[i].GetChar("HIS_DEL_FLAG") == 'Y')
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        sheetX.Cells[iRow, 0].Value = out_node.GetList(0)[i].GetString("FACTORY");
                        sheetX.Cells[iRow, 1].Value = out_node.GetList(0)[i].GetString("RES_ID");
                        sheetX.Cells[iRow, 2].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                        sheetX.Cells[iRow, 3].Value = out_node.GetList(0)[i].GetChar("HIS_DEL_FLAG");
                        sheetX.Cells[iRow, 4].Value = out_node.GetList(0)[i].GetString("COL_SET_ID");
                        sheetX.Cells[iRow, 5].Value = out_node.GetList(0)[i].GetInt("COL_SET_VERSION");
                        sheetX.Cells[iRow, 6].Value = out_node.GetList(0)[i].GetInt("CHAR_SEQ_NUM");
                        sheetX.Cells[iRow, 7].Value = out_node.GetList(0)[i].GetString("CHAR_ID");
                        sheetX.Cells[iRow, 8].Value = out_node.GetList(0)[i].GetString("CHAR_DESC");
                        sheetX.Cells[iRow, 9].Value = MPCF.GetSpecInfo(out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"), 
                                                                       out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"), 
                                                                       out_node.GetList(0)[i].GetString("TARGET_VALUE"));
                        sheetX.Cells[iRow, 10].Value = out_node.GetList(0)[i].GetInt("UNIT_SEQ_NUM");
                        sheetX.Cells[iRow, 11].Value = out_node.GetList(0)[i].GetString("UNIT_ID");
                        sheetX.Cells[iRow, 12].Value = out_node.GetList(0)[i].GetInt("VALUE_SEQ_NUM");
                        sheetX.Cells[iRow, 13].Value = out_node.GetList(0)[i].GetChar("VALUE_TYPE");
                        sheetX.Cells[iRow, 14].Value = out_node.GetList(0)[i].GetInt("VALUE_COUNT");

                        if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                        {
                            if (out_node.GetList(0)[i].GetString("VALUE_1") != "")
                                sheetX.Cells[iRow, COL_VALUE + 0].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_1"));
                            if (out_node.GetList(0)[i].GetString("VALUE_2") != "")
                                sheetX.Cells[iRow, COL_VALUE + 1].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_2"));
                            if (out_node.GetList(0)[i].GetString("VALUE_3") != "")
                                sheetX.Cells[iRow, COL_VALUE + 2].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_3"));
                            if (out_node.GetList(0)[i].GetString("VALUE_4") != "")
                                sheetX.Cells[iRow, COL_VALUE + 3].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_4"));
                            if (out_node.GetList(0)[i].GetString("VALUE_5") != "")
                                sheetX.Cells[iRow, COL_VALUE + 4].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_5"));
                            if (out_node.GetList(0)[i].GetString("VALUE_6") != "")
                                sheetX.Cells[iRow, COL_VALUE + 5].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_6"));
                            if (out_node.GetList(0)[i].GetString("VALUE_7") != "")
                                sheetX.Cells[iRow, COL_VALUE + 6].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_7"));
                            if (out_node.GetList(0)[i].GetString("VALUE_8") != "")
                                sheetX.Cells[iRow, COL_VALUE + 7].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_8"));
                            if (out_node.GetList(0)[i].GetString("VALUE_9") != "")
                                sheetX.Cells[iRow, COL_VALUE + 8].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_9"));
                            if (out_node.GetList(0)[i].GetString("VALUE_10") != "")
                                sheetX.Cells[iRow, COL_VALUE + 9].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_10"));
                            if (out_node.GetList(0)[i].GetString("VALUE_11") != "")
                                sheetX.Cells[iRow, COL_VALUE + 10].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_11"));
                            if (out_node.GetList(0)[i].GetString("VALUE_12") != "")
                                sheetX.Cells[iRow, COL_VALUE + 11].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_12"));
                            if (out_node.GetList(0)[i].GetString("VALUE_13") != "")
                                sheetX.Cells[iRow, COL_VALUE + 12].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_13"));
                            if (out_node.GetList(0)[i].GetString("VALUE_14") != "")
                                sheetX.Cells[iRow, COL_VALUE + 13].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_14"));
                            if (out_node.GetList(0)[i].GetString("VALUE_15") != "")
                                sheetX.Cells[iRow, COL_VALUE + 14].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_15"));
                            if (out_node.GetList(0)[i].GetString("VALUE_16") != "")
                                sheetX.Cells[iRow, COL_VALUE + 15].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_16"));
                            if (out_node.GetList(0)[i].GetString("VALUE_17") != "")
                                sheetX.Cells[iRow, COL_VALUE + 16].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_17"));
                            if (out_node.GetList(0)[i].GetString("VALUE_18") != "")
                                sheetX.Cells[iRow, COL_VALUE + 17].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_18"));
                            if (out_node.GetList(0)[i].GetString("VALUE_19") != "")
                                sheetX.Cells[iRow, COL_VALUE + 18].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_19"));
                            if (out_node.GetList(0)[i].GetString("VALUE_20") != "")
                                sheetX.Cells[iRow, COL_VALUE + 19].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_20"));
                            if (out_node.GetList(0)[i].GetString("VALUE_21") != "")
                                sheetX.Cells[iRow, COL_VALUE + 20].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_21"));
                            if (out_node.GetList(0)[i].GetString("VALUE_22") != "")
                                sheetX.Cells[iRow, COL_VALUE + 21].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_22"));
                            if (out_node.GetList(0)[i].GetString("VALUE_23") != "")
                                sheetX.Cells[iRow, COL_VALUE + 22].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_23"));
                            if (out_node.GetList(0)[i].GetString("VALUE_24") != "")
                                sheetX.Cells[iRow, COL_VALUE + 23].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_24"));
                            if (out_node.GetList(0)[i].GetString("VALUE_25") != "")
                                sheetX.Cells[iRow, COL_VALUE + 24].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_25"));
                        }
                        else
                        {
                            sheetX.Cells[iRow, COL_VALUE + 0].Value = out_node.GetList(0)[i].GetString("VALUE_1");
                            sheetX.Cells[iRow, COL_VALUE + 1].Value = out_node.GetList(0)[i].GetString("VALUE_2");
                            sheetX.Cells[iRow, COL_VALUE + 2].Value = out_node.GetList(0)[i].GetString("VALUE_3");
                            sheetX.Cells[iRow, COL_VALUE + 3].Value = out_node.GetList(0)[i].GetString("VALUE_4");
                            sheetX.Cells[iRow, COL_VALUE + 4].Value = out_node.GetList(0)[i].GetString("VALUE_5");
                            sheetX.Cells[iRow, COL_VALUE + 5].Value = out_node.GetList(0)[i].GetString("VALUE_6");
                            sheetX.Cells[iRow, COL_VALUE + 6].Value = out_node.GetList(0)[i].GetString("VALUE_7");
                            sheetX.Cells[iRow, COL_VALUE + 7].Value = out_node.GetList(0)[i].GetString("VALUE_8");
                            sheetX.Cells[iRow, COL_VALUE + 8].Value = out_node.GetList(0)[i].GetString("VALUE_9");
                            sheetX.Cells[iRow, COL_VALUE + 9].Value = out_node.GetList(0)[i].GetString("VALUE_10");
                            sheetX.Cells[iRow, COL_VALUE + 10].Value = out_node.GetList(0)[i].GetString("VALUE_11");
                            sheetX.Cells[iRow, COL_VALUE + 11].Value = out_node.GetList(0)[i].GetString("VALUE_12");
                            sheetX.Cells[iRow, COL_VALUE + 12].Value = out_node.GetList(0)[i].GetString("VALUE_13");
                            sheetX.Cells[iRow, COL_VALUE + 13].Value = out_node.GetList(0)[i].GetString("VALUE_14");
                            sheetX.Cells[iRow, COL_VALUE + 14].Value = out_node.GetList(0)[i].GetString("VALUE_15");
                            sheetX.Cells[iRow, COL_VALUE + 15].Value = out_node.GetList(0)[i].GetString("VALUE_16");
                            sheetX.Cells[iRow, COL_VALUE + 16].Value = out_node.GetList(0)[i].GetString("VALUE_17");
                            sheetX.Cells[iRow, COL_VALUE + 17].Value = out_node.GetList(0)[i].GetString("VALUE_18");
                            sheetX.Cells[iRow, COL_VALUE + 18].Value = out_node.GetList(0)[i].GetString("VALUE_19");
                            sheetX.Cells[iRow, COL_VALUE + 19].Value = out_node.GetList(0)[i].GetString("VALUE_20");
                            sheetX.Cells[iRow, COL_VALUE + 20].Value = out_node.GetList(0)[i].GetString("VALUE_21");
                            sheetX.Cells[iRow, COL_VALUE + 21].Value = out_node.GetList(0)[i].GetString("VALUE_22");
                            sheetX.Cells[iRow, COL_VALUE + 22].Value = out_node.GetList(0)[i].GetString("VALUE_23");
                            sheetX.Cells[iRow, COL_VALUE + 23].Value = out_node.GetList(0)[i].GetString("VALUE_24");
                            sheetX.Cells[iRow, COL_VALUE + 24].Value = out_node.GetList(0)[i].GetString("VALUE_25");
                        }

                        sheetX.Cells[iRow, 40].Value = out_node.GetList(0)[i].GetString("SPEC_OUT_MASK");
                        sheetX.Cells[iRow, 41].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                        sheetX.Cells[iRow, 42].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"));

                        for (j = COL_VALUE; j < COL_VALUE + 25; j++)
                        {
                            if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                            {
                                //DISPLAY PRECISION ¿˚øÎ
                                if (iPrecision > 0 && sheetX.Cells[iRow, j].Value != null)
                                {
                                    sheetX.Cells[iRow, j].Value = MPCF.SetPrecision(sheetX.Cells[iRow, j].Value.ToString(), iPrecision);
                                } 
                                MPCR.SetNumberCell(sheetX.Cells[iRow, j]);
                            }
                            else
                            {
                                MPCR.SetAsciiCell(sheetX.Cells[iRow, j]);
                            }
                        }

                        if (iMaxValueCount < out_node.GetList(0)[i].GetInt("VALUE_COUNT"))
                        {
                            iMaxValueCount = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                        }                        
                    }
                }

                in_node.SetInt("NEXT_CHAR_SEQ_NUM", out_node.GetInt("NEXT_CHAR_SEQ_NUM"));
                in_node.SetInt("NEXT_UNIT_SEQ_NUM", out_node.GetInt("NEXT_UNIT_SEQ_NUM"));
                in_node.SetInt("NEXT_VALUE_SEQ_NUM", out_node.GetInt("NEXT_VALUE_SEQ_NUM"));

            } while (in_node.GetInt("NEXT_CHAR_SEQ_NUM") > 0 || in_node.GetInt("NEXT_UNIT_SEQ_NUM") > 0 || in_node.GetInt("NEXT_VALUE_SEQ_NUM") > 0);

            if (control is FarPoint.Win.Spread.FpSpread)
            {
                sheetX = ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet;

                if (sheetX.RowCount > 0)
                {
                    if (iMaxValueCount == 0)
                    {
                        iMaxValueCount = 1;
                    }
                    sheetX.Columns.Get(COL_VALUE, COL_VALUE + iMaxValueCount - 1).Visible = true;
                    if (iMaxValueCount < 25)
                    {
                        sheetX.Columns.Get(COL_VALUE + iMaxValueCount, COL_VALUE + 24).Visible = false;
                    }
                }
            }

            return true;

        }

        
        // ViewFlowList()
        //       - View all Flow List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Flow
        //        - Optional ByVal sOper As String = ""        : sOperÎ•?Í∞ÄÏß?Flow
        //        - Optional ByVal sMaterial As String = ""    : sMaterialÎ•?Í∞ÄÏß?Flow
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewCharacterbyCollection(Control control, char c_step, string sColSetId, TreeNode parentNode, string sExtFactory, char cIncludeUnitID)
        {
            
            
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            ArrayList a_list = new ArrayList();
            
            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }
            
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddChar("INCLUDE_UNIT_ID", cIncludeUnitID);
            in_node.AddString("COL_SET_ID", sColSetId);
            in_node.AddString("NEXT_CHAR_ID", "");

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            do
            {
                out_node = new TRSNode("View_Attach_Character_List_Out");
                
                if (MPCR.CallService("EDC", "EDC_View_Attach_Character_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);
                
                in_node.SetString("NEXT_CHAR_ID", out_node.GetString("NEXT_CHAR_ID"));

            } while (in_node.GetString("NEXT_CHAR_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is MCCodeView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("CHAR_ID"), (int)SMALLICON_INDEX.IDX_FLOW);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        }
                        ((MCCodeView)control).Items.Add(itmX);
                    }
                    else if (control is ListView)
                    {
                        itmX = ((ListView)control).Items.Add(out_node.GetList(0)[i].GetString("CHAR_ID"), (int)SMALLICON_INDEX.IDX_FLOW);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        }

                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("CHAR_ID") + " : " + out_node.GetList(0)[i].GetString("CHAR_DESC"), 
                                            (int)SMALLICON_INDEX.IDX_CHARACTER, (int)SMALLICON_INDEX.IDX_CHARACTER);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("CHAR_ID"));
                    }
                }
            }

            return true;
            
        }
        
        // View_Attach_Character_List()
        //       - View Character List by Collection Set
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal sColSetId As String                    : ColSet
        //        - ByVal sColSetVersion As String                : ColSetVersion
        //        -
        //
        public static bool ViewAttachCharacterListToVersion(FarPoint.Win.Spread.FpSpread spdCharacter, string sColSetId, string sColSetVersion, char cIncludeUnitID)
        {

            int i;
            int LastRow = 0;


            TRSNode in_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_OUT");
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '5'; //c_step;                
                in_node.AddChar("INCLUDE_UNIT_ID", cIncludeUnitID);
                in_node.AddString("COL_SET_ID", sColSetId);
                in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(sColSetVersion));
                in_node.AddString("NEXT_CHAR_ID", "");

                do
                {
                    if (MPCR.CallService("EDC", "EDC_View_Attach_Character_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    spdCharacter.ActiveSheet.RowCount = LastRow + out_node.GetList(0).Count;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        FarPoint.Win.Spread.SheetView with_1 = spdCharacter.ActiveSheet;

                        with_1.SetValue(LastRow, CHAR_ID, out_node.GetList(0)[i].GetString("CHAR_ID"));
                        with_1.SetValue(LastRow, CHAR_DESC, out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        with_1.SetValue(LastRow, UNIT_COUNT, out_node.GetList(0)[i].GetInt("UNIT_COUNT").ToString());
                        with_1.SetValue(LastRow, VALUE_COUNT, out_node.GetList(0)[i].GetInt("VALUE_COUNT").ToString());
                        with_1.SetValue(LastRow, DISPLAY_PRECISION, out_node.GetList(0)[i].GetInt("DISPLAY_PRECISION").ToString());
                        with_1.SetValue(LastRow, VALUE_TBL, out_node.GetList(0)[i].GetString("VALUE_TBL"));
                        with_1.SetValue(LastRow, DEF_VALUE, out_node.GetList(0)[i].GetString("DEF_VALUE"));
                        with_1.SetValue(LastRow, OPT_INPUT_FLAG, (out_node.GetList(0)[i].GetChar("OPT_INPUT_FLAG") == 'Y') ? "V" : "");
                        with_1.SetValue(LastRow, BLANK_REC_SAVE_FLAG, (out_node.GetList(0)[i].GetChar("BLANK_REC_SAVE_FLAG") == 'Y') ? "V" : "");
                        if (out_node.GetList(0)[i].GetChar("DEF_UNIT_FLAG") == 'C')
                        {
                            with_1.SetValue(LastRow, DEF_UNIT_FLAG, "CHARACTER");
                        }
                        else if (out_node.GetList(0)[i].GetChar("DEF_UNIT_FLAG") == 'E')
                        {
                            with_1.SetValue(LastRow, DEF_UNIT_FLAG, "NULL");
                        }
                        else
                        {
                            with_1.SetValue(LastRow, DEF_UNIT_FLAG, (out_node.GetList(0)[i].GetChar("DEF_UNIT_FLAG") == 'Y') ? "V" : "");
                        }
                        with_1.SetValue(LastRow, DEF_UNIT_OVR_FLAG, (out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG") == 'Y') ? "V" : "");
                        with_1.SetValue(LastRow, UNIT_TBL, out_node.GetList(0)[i].GetString("UNIT_TBL"));
                        //Spec Type Check
                        if (out_node.GetList(0)[i].GetChar("SPEC_TYPE") == 'B')
                        {
                            with_1.SetValue(LastRow, SPEC_TYPE, "Both");
                        }
                        else if (out_node.GetList(0)[i].GetChar("SPEC_TYPE") == 'U')
                        {
                            with_1.SetValue(LastRow, SPEC_TYPE, "Upper");
                        }
                        else if (out_node.GetList(0)[i].GetChar("SPEC_TYPE") == 'L')
                        {
                            with_1.SetValue(LastRow, SPEC_TYPE, "Lower");
                        }                        
                        with_1.SetValue(LastRow, SPEC_OUT_COUNT, out_node.GetList(0)[i].GetInt("SPEC_OUT_COUNT").ToString());
                        with_1.SetValue(LastRow, TARGET_VALUE, out_node.GetList(0)[i].GetString("TARGET_VALUE"));
                        with_1.SetValue(LastRow, UPPER_SPEC_LIMIT, out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"));
                        with_1.SetValue(LastRow, LOWER_SPEC_LIMIT, out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"));
                        with_1.SetValue(LastRow, UPPER_WARN_LIMIT, out_node.GetList(0)[i].GetString("UPPER_WARN_LIMIT"));
                        with_1.SetValue(LastRow, LOWER_WARN_LIMIT, out_node.GetList(0)[i].GetString("LOWER_WARN_LIMIT"));                        
                        with_1.SetValue(LastRow, SPEC_INFO, out_node.GetList(0)[i].GetString("SPEC_INFO"));
                        with_1.SetValue(LastRow, SPEC_OUT_ALARM, out_node.GetList(0)[i].GetString("SPEC_OUT_ALARM"));
                        with_1.SetValue(LastRow, WARN_OUT_ALARM, out_node.GetList(0)[i].GetString("WARN_OUT_ALARM"));
                        with_1.SetValue(LastRow, DERIVED_PARAM_FLAG, (out_node.GetList(0)[i].GetChar("DERIVED_PARAM_FLAG") == 'Y') ? "V" : "");
                        with_1.SetValue(LastRow, DERIVED_PARAMETER, out_node.GetList(0)[i].GetString("DERIVED_PARAMETER"));

                        LastRow ++;

                    }

                    in_node.SetString("NEXT_CHAR_ID", out_node.GetString("NEXT_CHAR_ID"));

                } while (in_node.GetString("NEXT_CHAR_ID") != "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        
        // ViewMFOColSetList()
        //      - View Collection Set List
        // Return Value
        //      - bool : true / false
        // Arguments
        //      - Control control 
        //      - char cStep 
        //      - TreeNode parentNode
        //      - string sExt_Factory
        //      - char cOptLevel
        //      - string sMatID 
        //      - int iMatVer
        //      - string sFlow
        //      - string sOper
        //      - char cCollectionMode
        //      - char cDefaultFlag
        //      - char cDisableFlag
        //      - int iCol
        //      - int iRow

        public static bool ViewMFOColSetList(Control control, 
            char cStep, 
            TreeNode parentNode, 
            string sExt_Factory, 
            char cOptLevel,
            string sMatID, 
            int iMatVer, 
            string sFlow, 
            string sOper, 
            char cCollectionMode, 
            char cDefaultFlag,
            char cDisableFlag,
            int iCol, 
            int iRow)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            string[] strData = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("View_MFO_ColSet_List_In");
            TRSNode out_node;

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
                in_node.ProcStep = cStep;

                if (sExt_Factory != "")
                {
                    in_node.Factory = sExt_Factory;
                }

                in_node.AddChar("OPT_LEVEL", cOptLevel);

                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("FLOW", sFlow);
                in_node.AddString("OPER", sOper);
                
                in_node.AddChar("COLLECTION_MODE", cCollectionMode);
                in_node.AddChar("DEFAULT_FLAG", cDefaultFlag);
                in_node.AddChar("DISABLE_FLAG", cDisableFlag);

                in_node.AddString("NEXT_OPER", "");
                in_node.AddInt("NEXT_SEQ", 0);
                in_node.AddString("NEXT_COL_SET_ID", "");

                do
                {
                    out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                    if (MPCR.CallService("EDC", "EDC_View_MFO_ColSet_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);
                    in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));
                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                    in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_COL_SET_ID"));

                } while (in_node.GetString("NEXT_OPER") != "" || in_node.GetInt("NEXT_SEQ") > 0 || in_node.GetString("NEXT_COL_SET_ID") != "");


                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("COL_SET_ID"), (int)SMALLICON_INDEX.IDX_COL_SET);

                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("COL_SET_DESC"));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("COL_SET_ID") + " : " + out_node.GetList(0)[i].GetString("COL_SET_DESC"), 
                                                (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("COL_SET_ID"));
                        }
                        else if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            sList.Add(out_node.GetList(0)[i].GetString("COL_SET_ID"));
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
                    if (iRow == -1 && iCol == -1)
                    {
                        //Do Nothing
                    }
                    else if (iRow == -1)
                    {
                        ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet.Columns.Get(iCol).CellType = cboCellType;
                    }
                    else if (iCol == -1)
                    {
                        ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet.Rows.Get(iRow).CellType = cboCellType;
                    }
                    else
                    {
                        ((FarPoint.Win.Spread.FpSpread)control).ActiveSheet.Cells.Get(iRow, iCol).CellType = cboCellType;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
        
    }
    //#End If
}
