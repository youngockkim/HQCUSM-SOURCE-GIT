
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : clsListRoutineSVM.cs
//   Description : Client Common List function SVM Module
//
//   MES Version : 5.0.0.0
//
//   Function List
//        - View_SVMServiceList
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-12-04 : Created by Daniel Jeong
//
//
//   Copyright(C) 1998-2008 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

using Miracom.CliFrx;
using Miracom.UI.Controls.MCCodeView;
using Miracom.TRSCore;
using Miracom.MsgHandler;

namespace Miracom.MESCore
{
    public sealed class SVMLIST
    {

        // ViewSVMServiceList()
        //       - View User List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : List媛 ?ㅼ뼱媛?control
        //        - ByVal c_step As String                        : ?뺤옣 Process Step
        //        - Optional ByVal iImage_idx As Integer = -1    : List View???ㅼ뼱媛??꾩씠肄??몃뜳??
        //        - Optional ByVal sExt_Factory As String = "": ?꾩옱 Factory媛 ?꾨땶寃쎌슦??Factory
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?먯꽌 異붽???Node??Text

        public static bool ViewServiceList(Control control, char c_step)
        {
            return ViewServiceList(control, c_step, -1, null, "", false, -1, -1);   
        }
        public static bool ViewServiceList(Control control, char c_step, bool bSecChkFlag)
        {
            return ViewServiceList(control, c_step, bSecChkFlag, -1, null, "", false, -1, -1); 
        }
        public static bool ViewServiceList(Control control, char c_step, int iImage_idx, TreeNode parentNode, string sExt_Factory, bool bIgnoreError, int Col, int Row)
        {
            return ViewServiceList(control, c_step, false, iImage_idx, parentNode, sExt_Factory, bIgnoreError, Col, Row); 
        }
        public static bool ViewServiceList(Control control, char c_step, bool bSecChkFlag, int iImage_idx, TreeNode parentNode, string sExt_Factory, bool bIgnoreError, int Col, int Row)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            List<string> sList = new List<string>();
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_SERVICE_LIST_IN");
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
                iImage_idx = (int)SMALLICON_INDEX.IDX_PRIVILEGE_SERVICE;
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

            if (c_step == '2' && bSecChkFlag == true)
            {
                in_node.AddChar("SEC_CHK_FLAG", 'Y');
            }
            else
            {
                in_node.AddChar("SEC_CHK_FLAG", ' ');
            }


            do
            {
                out_node = new TRSNode("VIEW_SERVICE_LIST_OUT");

                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));

            } while (out_node.GetString("NEXT_TABLE_NAME") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("SERVICE_NAME"), iImage_idx);
                        //itmX = new ListViewItem(out_node.GetList(0)[i].GetString("SERVICE_NAME"), 102);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SERVICE_DESC_1"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("SERVICE_NAME") + " : " + out_node.GetList(0)[i].GetString("SERVICE_DESC_1"), iImage_idx, iImage_idx);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("SERVICE_NAME"));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("SERVICE_NAME"));
                    }
                }
            }

            return true;

        }

        public static bool ViewServiceListbyKey(Control control, string s_key_type)
        {
            return ViewServiceListbyKey(control, s_key_type, "", true);
        }

        public static bool ViewServiceListbyKey(Control control, string s_key_type, string s_lot_res_flag, bool b_clear_flag)
        {
            TRSNode in_node = new TRSNode("VIEW_DEFAULT_FUNCTION_VERSION_IN");
            TRSNode out_node = new TRSNode("VIEW_DEFAULT_FUNCTION_VERSION_OUT");
            int i;

            try
            {
                if (b_clear_flag == true)
                {
                    if (control is ListView)
                    {
                        MPCF.InitListView((ListView)control);

                    }
                    if (control is TreeView)
                    {
                        MPCF.ClearList(control, true);
                    }
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddChar("PROC_CASE", '2');
                in_node.AddString("KEY_TYPE", s_key_type);
                in_node.AddString("RULE_TYPE", s_lot_res_flag);

                do
                {
                    if (MPCR.CallService("SVM", "SVM_View_Active_Function_Version", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            ListViewItem listViewItem = new ListViewItem(out_node.GetList(0)[i].GetString("KEY_NAME"), (int)SMALLICON_INDEX.IDX_KEY);
                            listViewItem.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_1"));
                            listViewItem.Tag = "K";
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_3")) == "")
                            {
                                listViewItem.Tag += "0";
                            }
                            else
                            {
                                listViewItem.Tag += MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_3"));
                            }

                            ((ListView)control).Items.Add(listViewItem);
                        }

                    }

                    in_node.SetInt("NEXT_ROWNUM", out_node.GetInt("NEXT_ROWNUM"));
                    in_node.SetString("MAX_ROWID", out_node.GetString("MAX_ROWID"));

                } while (in_node.GetInt("NEXT_ROWNUM") > 0);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        /* 2013.06.12. Aiden. Service 의 Member 리스트를 가져오는 기능 추가 */
        public static bool ViewServiceMemberList(Control control, string s_service_name, char c_direction, string s_parent_path)
        {
            int i;
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else
            {
                return false;
            }
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '4';

            in_node.AddString("SERVICE_NAME", s_service_name);
            in_node.AddChar("DIRECTION", c_direction);
            in_node.AddString("PARENT_MEMBER_PATH", s_parent_path);

            if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (control is ListView)
                {
                    ListViewItem listViewItem = new ListViewItem(out_node.GetList(0)[i].GetString("MEMBER_NAME"), (int)SMALLICON_INDEX.IDX_KEY);

                    switch (MPGV.gcLanguage)
                    {
                        case '1': listViewItem.SubItems.Add(out_node.GetList(0)[i].GetString("MEMBER_DESC_1")); break;
                        case '2': listViewItem.SubItems.Add(out_node.GetList(0)[i].GetString("MEMBER_DESC_2")); break;
                        case '3': listViewItem.SubItems.Add(out_node.GetList(0)[i].GetString("MEMBER_DESC_3")); break;
                    }
                    ((ListView)control).Items.Add(listViewItem);
                }
            }

            return true;
        }


    }

}
