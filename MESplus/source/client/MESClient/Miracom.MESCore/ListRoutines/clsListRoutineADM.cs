
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
    public sealed class ADMLIST
    {

        // ViewColumnList()
        //       - View Column List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal sStep As String                        : ?ïÏû• Process Step
        //       - Optional ByVal sTableName As String = "" : Material Type
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewColumnList(Control control, char sStep, string sTableName, TreeNode parentNode)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_COLUMN_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_COLUMN_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = sStep;
            in_node.AddString("TNAME", sTableName);
            in_node.AddString("NEXT_COLUMN_NAME", "");

            do
            {
                if (MPCR.CallService("ARC", "ARC_View_Column_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("COLUMN_NAME")), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                        if (((ListView)control).Columns.Count >= 3)
                        {
                            if (out_node.GetList(0)[i].GetString("DATA_TYPE") == "NUMBER")
                            {
                                if (out_node.GetList(0)[i].GetInt("DATA_PRECISION") > 0 && out_node.GetList(0)[i].GetInt("DATA_SCALE") > 0)
                                {
                                    itmX.SubItems.Add(MPCF.RTrim(out_node.GetList(0)[i].GetString("DATA_TYPE")) + " (" + out_node.GetList(0)[i].GetInt("DATA_PRECISION").ToString() + "," + out_node.GetList(0)[i].GetInt("DATA_SCALE").ToString() + ")");
                                }
                                else if (out_node.GetList(0)[i].GetInt("DATA_PRECISION") > 0 && out_node.GetList(0)[i].GetInt("DATA_SCALE") == 0)
                                {
                                    itmX.SubItems.Add(MPCF.RTrim(out_node.GetList(0)[i].GetString("DATA_TYPE")) + " (" + out_node.GetList(0)[i].GetInt("DATA_PRECISION").ToString() + ")");
                                }
                                else
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_TYPE")));
                                }
                            }
                            else
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_TYPE")) + " (" + out_node.GetList(0)[i].GetInt("DATA_LENGTH").ToString() + ")");
                            }
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("INDX_CODE")));

                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("INDX_CODE")) != "")
                                itmX.ForeColor = Color.Red;
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("COLUMN_NAME")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_TYPE")), (int)SMALLICON_INDEX.IDX_CODE_DATA, (int)SMALLICON_INDEX.IDX_CODE_DATA);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("COLUMN_NAME")));

                    }
                }

                in_node.SetString("NEXT_COLUMN_NAME", out_node.GetString("NEXT_COLUMN_NAME"));
            } while (!(in_node.GetString("NEXT_COLUMN_NAME") == ""));


            return true;
        }

        // ViewArchiveTableList()
        //       - View all Archive Table List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal sStep As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sMaterialType As String = "" : Material Type
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Material
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        public static bool ViewArchiveTableList(Control control, char sStep, string sModule, string sFilter, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_ARCHIVE_TABLE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ARCHIVE_TABLE_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = sStep;

            if (sExtFactory.Trim() != "")
            {
                in_node.Factory = sExtFactory.Trim();
            }
            else
            {
                in_node.Factory = MPGV.gsFactory;
            }

            in_node.AddString("MODULE_NAME", sModule.Trim());

            do
            {
                if (MPCR.CallService("ARC", "ARC_View_Archive_Table_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_NAME")), (int)SMALLICON_INDEX.IDX_CODE_TABLE);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_TYPE")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_NAME")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_TYPE")), (int)SMALLICON_INDEX.IDX_CODE_TABLE, (int)SMALLICON_INDEX.IDX_CODE_TABLE);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_NAME")));
                    }
                }

                in_node.SetString("TBL_NAME", out_node.GetString("NEXT_TBL_NAME"));
            } while (!(in_node.GetString("TBL_NAME") == ""));

            return true;
        }

        // ViewSessionList()
        //       - View Session List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal sStep As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewSessionList(Control control, char sStep, TreeNode parentNode)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_SESSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SESSION_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = sStep;

            do
            {
                if (MPCR.CallService("ADM", "ADM_View_Session_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SESSION_ID")), (int)SMALLICON_INDEX.IDX_CODE_TABLE);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("STATUS")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("USERNAME")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("OSUSER")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("MACHINE")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PROGRAM")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TYPE")));
                            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOGON_TIME")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("SESSION_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("USERNAME")), (int)SMALLICON_INDEX.IDX_CODE_TABLE, (int)SMALLICON_INDEX.IDX_CODE_TABLE);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SESSION_ID")));

                    }
                }

                in_node.SetString("NEXT_SESSION_ID", out_node.GetString("NEXT_SESSION_ID"));

            } while (!(in_node.GetString("NEXT_SESSION_ID") == ""));

            return true;
        }

        // ViewTableList()
        //       - View Table List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal sStep As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //
        public static bool ViewTableList(Control control, char sStep, TreeNode parentNode)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_TABLE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = sStep;
            in_node.AddString("NEXT_TNAME", "");

            do
            {
                if (MPCR.CallService("ARC", "ARC_View_Table_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("TNAME")), (int)SMALLICON_INDEX.IDX_CODE_TABLE);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("MODULE_NAME")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_TYPE")));
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_TYPE")) == "M")
                        {

                            itmX.ForeColor = Color.Red;
                            //'lisTable.Items(i).Font.Bold = True
                            itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_COL_SET;

                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetString("TBL_TYPE")) == "S")
                        {
                            itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_COL_SET_VERSION;
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("TNAME")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("TABTYPE")), (int)SMALLICON_INDEX.IDX_CODE_TABLE, (int)SMALLICON_INDEX.IDX_CODE_TABLE);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TNAME")));

                    }
                }

                in_node.SetString("NEXT_TNAME", out_node.GetString("NEXT_TNAME"));
            } while (!(in_node.GetString("NEXT_TNAME") == ""));

            return true;
        }


    
    }
}
