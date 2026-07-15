
using Miracom.MsgHandler;
using System.Data;
using Miracom.CliFrx;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Drawing;
using Miracom.UI.Controls.MCCodeView;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modALMListRoutine.vb
//   Description : Client Common List function ALM Module
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
//#If _ALM = True Then

namespace Miracom.MESCore
{
    public sealed class ALMLIST
    {

        // ViewAlarmMsgList()
        //       - View Alarm Message list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //       - Optional ByValsTreeItem As String =""     : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //        - Optional ByVal bIgnoreError As Boolean = False: Error Î¨¥Ïãú ?¨Î?
        //
        public static bool ViewAlarmMsgList(Control control, char c_step, char c_alarm_type)
        {
            return ViewAlarmMsgList(control, c_step, c_alarm_type, null, "", false);
        }
        public static bool ViewAlarmMsgList(Control control, char c_step, char c_alarm_type, TreeNode parentNode, string sExt_Factory, bool bIgnoreError)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_ALARM_MSG_LIST_IN");
            TRSNode out_node;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExt_Factory != "")
            {
                in_node.Factory = sExt_Factory;
            }
            
            in_node.AddChar("ALARM_TYPE", c_alarm_type);
            in_node.AddString("NEXT_ALARM_ID", "");

            do
            {
                out_node = new TRSNode("VIEW_ALARM_MSG_LIST_OUT");

                if (MPCR.CallService("ALM", "ALM_View_Alarm_Msg_List", in_node, ref out_node,bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_ALARM_ID",out_node.GetString("NEXT_ALARM_ID"));

            } while (in_node.GetString("NEXT_ALARM_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("ALARM_ID")), (int)SMALLICON_INDEX.IDX_ALARM);
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("ALARM_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("ALARM_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("ALARM_DESC")), (int)SMALLICON_INDEX.IDX_ALARM, (int)SMALLICON_INDEX.IDX_ALARM);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("ALARM_ID"));

                    }
                }
            }

            return true;

        }

    }
}
