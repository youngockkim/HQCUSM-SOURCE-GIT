using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.Threading;
using System.Globalization;

//using Miracom.CliFrx;
//using Miracom.MESCore;
//using Miracom.TRSCore;
//using Miracom.POPCore;
//using Miracom.DNMCore;
//using SOICodeView;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using Miracom.TRSCore;
using SOI.CliFrx;

using FarPoint.Win.Spread;
using Infragistics.Shared;
using Infragistics.Win.UltraWinEditors;
using SOI.OIFrx.SOIControls;
using Miracom.POPCore;
using SOI.DNM;

namespace SOI.Solar
{
    public sealed class CSCR
    {
        #region " ViewResourceMaterialList "

        public static bool ViewResourceMaterialList(char cProcStep, Control Form_control, char rel_level, string key, string sFilter, int Image_idx, string Ext_Factory, bool bIgnoreError)
        {

            ListViewItem itmX;

            int i;
            int j;
            List<string> sList = new List<string>();
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (Form_control is ListView)
            {
                ////MPCF.InitListView((ListView)Form_control);
            }
            else
            {
                return false;
            }
            if (Image_idx == -1)
            {
                Image_idx = (int)SMALLICON_INDEX.IDX_MATERIAL;
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

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cProcStep;

            if (Ext_Factory != "")
            {
                in_node.Factory = Ext_Factory;
            }

            if (rel_level == 'R')
            {
                in_node.AddString("RES_ID", key);
            }
            else if (rel_level == 'G')
            {
                in_node.AddString("RESG_ID", key);
            }
            else if (rel_level == 'W')
            {
                in_node.AddString("WORK_CENTER", key);
            }
            in_node.AddChar("REL_LEVEL", rel_level);

            in_node.AddString("FILTER", MPCF.Trim(sFilter));

            in_node.AddString("NEXT_MAT_ID", "");

            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCF.CallService("CUS", "CUS_View_Resource_Material_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_MAT_ID", out_node.GetString("NEXT_MAT_ID"));

            } while (in_node.GetString("NEXT_MAT_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (Form_control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("MAT_ID"), Image_idx);
                        if (((ListView)Form_control).Columns.Count > 1)
                        {
                            for (j = 0; j < ((ListView)Form_control).Columns.Count - 1; j++)
                            {
                                if (cProcStep == '1' || cProcStep == '2')
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                                            break;
                                        case 1:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_SHORT_DESC"));
                                            break;

                                        case 2:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_DESC"));
                                            break;
                                    }
                                }
                                else //if (cProcStep == '3' || cProcStep == '4') without mat version
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_SHORT_DESC"));
                                            break;
                                        case 1:
                                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_DESC"));
                                            break;
                                    }
                                }

                            }
                        }
                        ((ListView)Form_control).Items.Add(itmX);
                    }
                }
            }

            //MPCF.FitColumnHeader((ListView)Form_control);

            return true;
        }

        #endregion

        #region " ViewLotInfoSubStep "

        public static bool ViewLotInfoSubStep(char cProcStep, char sSubStep, string sLotID, ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            //TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cProcStep;
            in_node.AddString("LOT_ID", sLotID);
            in_node.AddString("SUB_STEP", sSubStep);

            if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region " ViewAttributeList "
        public static bool ViewAttributeList(char c_step, string sAttrType, string sAttrName, string sAttrValue, string sAttrKey,
                                             ref TRSNode out_node, bool bShowMsgBox)
        {
            return ViewAttributeList(c_step, sAttrType, sAttrName, sAttrValue, sAttrKey, ref out_node, bShowMsgBox, null);
        }
        public static bool ViewAttributeList(char c_step, string sAttrType, string sAttrName, string sAttrValue, string sAttrKey,
                                             ref TRSNode out_node, bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus)
        {
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                if (c_step == '1')
                {
                    in_node.AddString("ATTR_TYPE", sAttrType);
                    in_node.AddString("ATTR_NAME", sAttrName);
                    in_node.AddString("ATTR_VALUE", sAttrValue);
                }
                if (c_step == '2')
                {
                    in_node.AddString("ATTR_TYPE", sAttrType);
                    in_node.AddString("ATTR_NAME", sAttrName);
                    in_node.AddString("ATTR_KEY", sAttrKey);
                }

                if (lblStatus != null)
                {
                    CSCF.ShowStatusMsg(lblStatus, 'R', "");
                }

                if (MPCF.CallService("CUS", "CUS_View_Attribute_List", in_node, ref out_node, !bShowMsgBox) == false)
                {
                    if (!bShowMsgBox && lblStatus != null)
                    {
                        CSCF.CheckContinueProcMB(out_node, lblStatus);
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (!bShowMsgBox && lblStatus != null)
                {
                    CSCF.ShowStatusMsg(lblStatus, 'E', ex.Message);
                }
                else
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                return false;
            }

            return true;
        }
        #endregion

        #region " ViewLineList "
        // ViewLineList()
        //       - View All Line List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : List媛 ?ㅼ뼱媛?control
        //        - ByVal c_step As String                        : ?뺤옣 Process Step        
        //

        public static bool ViewLineList(Control control, char c_step)
        {
            return ViewLineList(control, c_step, "", "", null, "", false);
        }
        public static bool ViewLineList(Control control, char c_step, bool bIgnoreError)
        {
            return ViewLineList(control, c_step, "", "", null, "", bIgnoreError);
        }
        public static bool ViewLineList(Control control, char c_step, string sLineType, string sShopCode)
        {
            return ViewLineList(control, c_step, sLineType, sShopCode, null, "", false);
        }

        public static bool ViewLineList(Control control, char c_step, string sLineType, string sShopCode, TreeNode parentNode, string sExtFactory, bool bIgnoreError)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            ////MPCF.InitListView((ListView)control);

            //if (control is ListView)
            //{
            //    //MPCF.InitListView((ListView)control);
            //}
            //else if (!(control is TreeView))
            //{
            //    if (!(parentNode == null))
            //    {
            //        parentNode.Nodes.Clear();
            //    }
            //    else
            //    {
            //        MPCF.ClearList(control, true);
            //    }
            //}

            //MPCF.SetInMsg(in_node);
            //in_node.ProcStep = c_step;

            //if (sExtFactory != "")
            //{
            //    in_node.Factory = sExtFactory;
            //}

            //in_node.AddString("LINE_TYPE", sLineType);
            //in_node.AddString("SHOP_CODE", sShopCode);

            //do
            //{
            //    out_node = new TRSNode("VIEW_LINE_LIST_OUT");

            //    if (MPCF.CallService("CUS", "CUS_View_Line_List", in_node, ref out_node, bIgnoreError) == false)
            //    {
            //        return false;

            //    }

            //    a_list.Add(out_node);

            //    in_node.SetString("NEXT_LINE_ID", out_node.GetString("NEXT_LINE_ID"));

            //} while (in_node.GetString("NEXT_LINE_ID") != "");


            //foreach (object obj in a_list)
            //{
            //    out_node = null;
            //    out_node = (TRSNode)obj;

            //    for (i = 0; i < out_node.GetList(0).Count; i++)
            //    {
            //        if (control is ListView)
            //        {
            //            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("LINE_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
            //            if (((ListView)control).Columns.Count > 3)
            //            {
            //            }
            //            if (((ListView)control).Columns.Count > 1)
            //            {
            //                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LINE_DESC"));
            //            }

            //            ((ListView)control).Items.Add(itmX);
            //        }
            //        else if (control is TreeView)
            //        {
            //            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("LINE_ID") + " : " + out_node.GetList(0)[i].GetString("LINE_DESC"),
            //                (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP, (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
            //            if (!(parentNode == null))
            //            {
            //                parentNode.Nodes.Add(nodeX);
            //            }
            //            else
            //            {
            //                ((TreeView)control).Nodes.Add(nodeX);
            //            }
            //        }
            //        else if (control is ComboBox)
            //        {
            //            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("LINE_ID"));
            //        }
            //    }
            //}

            return true;

        }
        #endregion

        #region " ViewPrvGrpLineList "

        // ViewPrvGrpLineList()
        //       - View Privilege Group - Line Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : List媛 ?ㅼ뼱媛?control
        //        - ByVal c_step As String                        : ?뺤옣 Process Step
        //        - ByVal sKey As String                        : Key 媛?(step='1' ?쇨꼍??Prv_Grp_ID, step='2' ??寃쎌슦 User_ID)
        //        - Optional ByVal sExt_Factory As String = "": ?꾩옱 Factory媛 ?꾨땶寃쎌슦??Factory
        //
        public static bool ViewPrvGrpLineList(Control control, char c_step, string sKey, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_PRIVILEGE_GROUP_LINE_LIST_IN");
            TRSNode out_node;

            try
            {
                //if (control is ListView)
                //{
                //    //MPCF.InitListView((ListView)control);
                //}
                if (control is TreeView)
                {
                    MPCF.ClearList(control, true);
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                if (sExtFactory != "")
                {
                    in_node.Factory = sExtFactory;
                }

                if (c_step == '1')
                {
                    in_node.AddString("NEXT_PRV_GRP_ID", sKey);
                }
                else if (c_step == '2')
                {
                    in_node.AddString("NEXT_LINE_ID", sKey, true);
                }

                do
                {
                    out_node = new TRSNode("VIEW_PRIVILEGE_GROUP_LINE_LIST_OUT");

                    if (MPCF.CallService("CUS", "CUS_View_Privilege_Group_Line_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_LINE_ID", out_node.GetString("NEXT_LINE_ID"), true);
                    in_node.SetString("NEXT_PRV_GRP_ID", out_node.GetString("NEXT_PRV_GRP_ID"));

                } while (in_node.GetString("NEXT_LINE_ID") != "" || in_node.GetString("NEXT_PRV_GRP_ID") != "");

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            if (c_step == '1')
                            {
                                itmX = ((ListView)control).Items.Add(out_node.GetList(0)[i].GetString("LINE_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LINE_DESC"));
                                }
                            }
                            else if (c_step == '2')
                            {
                                itmX = ((ListView)control).Items.Add(out_node.GetList(0)[i].GetString("PRV_GRP_ID"), (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("PRV_GRP_DESC"));
                                }
                            }
                        }
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

        #endregion

        #region " ViewProjectList "

        public static bool ViewProjectList(Control control, char c_step, string s_start_date, TreeNode parentNode, string sExt_Factory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            List<string> sList = new List<string>();

            TRSNode in_node = new TRSNode("VIEW_PROJECT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_PROJECT_LIST_OUT");

            if (control is ListView)
            {
                ////MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, false);
            }

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExt_Factory != "" && sExt_Factory != null)
            {
                in_node.Factory = sExt_Factory;
            }
            else
                in_node.Factory = MPGV.gsFactory;

            in_node.SetString("START_DATE", s_start_date);

            in_node.AddString("NEXT_PROJECT_ID", "");

            do
            {
                if (MPCF.CallService("CUS", "CUS_View_Project_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PROJECT_ID")), (int)SMALLICON_INDEX.IDX_BOM);

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PROJECT_DESC")));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("PROJECT_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("PROJECT_DESC")), (int)SMALLICON_INDEX.IDX_COL_SET, (int)SMALLICON_INDEX.IDX_COL_SET);
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
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PROJECT_ID")));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PROJECT_ID")));
                    }
                }

                in_node.SetString("NEXT_PROJECT_ID", out_node.GetString("NEXT_PROJECT_ID"));

            } while (in_node.GetString("NEXT_PROJECT_ID") != "");

            return true;
        }
        public static bool ViewProjectVersionList(Control control, char c_step, string s_project_id, TreeNode parentNode, string sExt_Factory)
        {
            int i;
            ListViewItem itmX;
            List<string> sList = new List<string>();

            TRSNode in_node = new TRSNode("VIEW_PROJECT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_PROJECT_LIST_OUT");

            if (control is ListView)
            {
                ////MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, false);
            }

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '3';

            if (sExt_Factory != "" && sExt_Factory != null)
            {
                in_node.Factory = sExt_Factory;
            }
            else
                in_node.Factory = MPGV.gsFactory;


            in_node.SetString("PROJECT_ID", s_project_id);

            in_node.AddString("NEXT_PROJECT_ID", "");

            do
            {
                if (MPCF.CallService("CUS", "CUS_View_Project_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {

                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetInt("PROJECT_VER").ToString()), (int)SMALLICON_INDEX.IDX_BOM);

                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("PROJECT_VER").ToString()));
                    }
                    else if (control is FarPoint.Win.Spread.FpSpread)
                    {
                        sList.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("PROJECT_VER").ToString()));
                    }
                }

                in_node.SetString("NEXT_PROJECT_ID", out_node.GetString("NEXT_PROJECT_ID"));

            } while (in_node.GetString("NEXT_PROJECT_ID") != "");

            return true;
        }

        #endregion

        #region " ViewLabelCode "
        // ViewLabelCode()
        //       - Print Order
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        public static bool ViewLabelCode(char cStep, string sLabelID, ref string sLabelCode, string[] Argu, ref string[] sRepStr)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode data_list;
            int i;
            int iArgCount;

            //string[] sRepStr;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cStep;

                in_node.AddString("LABEL_ID", sLabelID);
                in_node.AddInt("LABEL_NO", 1);

                if (Argu != null)
                {
                    for (i = 0; i < Argu.Length; i++)
                    {
                        TRSNode node = in_node.AddNode("SQL_ARG_LIST");
                        node.AddString("SQL_ARG", Argu[i]);
                    }
                }

                if (MPCF.CallService("CUS", "CUS_View_Label_Code", in_node, ref out_node) == false)
                {
                    return false;
                }

                sLabelCode = out_node.GetString("LABEL_CODE_1");
                iArgCount = out_node.GetInt("ARG_COUNT");

                if (out_node.GetList("DATA_LIST").Count > 0)
                {
                    data_list = out_node.GetList("DATA_LIST")[0];

                    sRepStr = new string[20];
                    sRepStr[0] = data_list.GetString("KEY_1");
                    sRepStr[1] = data_list.GetString("KEY_2");
                    sRepStr[2] = data_list.GetString("KEY_3");
                    sRepStr[3] = data_list.GetString("KEY_4");
                    sRepStr[4] = data_list.GetString("KEY_5");
                    sRepStr[5] = data_list.GetString("KEY_6");
                    sRepStr[6] = data_list.GetString("KEY_7");
                    sRepStr[7] = data_list.GetString("KEY_8");
                    sRepStr[8] = data_list.GetString("KEY_9");
                    sRepStr[9] = data_list.GetString("KEY_10");
                    sRepStr[10] = data_list.GetString("DATA_1");
                    sRepStr[11] = data_list.GetString("DATA_2");
                    sRepStr[12] = data_list.GetString("DATA_3");
                    sRepStr[13] = data_list.GetString("DATA_4");
                    sRepStr[14] = data_list.GetString("DATA_5");
                    sRepStr[15] = data_list.GetString("DATA_6");
                    sRepStr[16] = data_list.GetString("DATA_7");
                    sRepStr[17] = data_list.GetString("DATA_8");
                    sRepStr[18] = data_list.GetString("DATA_9");
                    sRepStr[19] = data_list.GetString("DATA_10");
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        #endregion

        #region " ViewLabelInfo "

        public static bool ViewLabelInfo(char cStep, string sLineID, string sOper, ref string sLabelCode, string[] Argu, ref string[] sRepStr)
        {
            char cMultiArrayFlag = ' ';

            return ViewLabelInfo(cStep, sLineID, sOper, ref sLabelCode, ref cMultiArrayFlag, Argu, ref sRepStr, true, null);
        }
        public static bool ViewLabelInfo(char cStep, string sLineID, string sOper, ref string sLabelCode, ref char cMultiArrayFlag,
                                          string[] Argu, ref string[] sRepStr)
        {
            return ViewLabelInfo(cStep, sLineID, sOper, ref sLabelCode, ref cMultiArrayFlag, Argu, ref sRepStr, true, null);
        }
        public static bool ViewLabelInfo(char cStep, string sLineID, string sOper, ref string sLabelCode, ref char cMultiArrayFlag,
                                        string[] Argu, ref string[] sRepStr,
                                         bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode data_list;
            int i;
            int iArgCount;

            //string[] sRepStr;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cStep;

                in_node.AddString("LINE_ID", sLineID);
                in_node.AddString("OPER", sOper);

                if (Argu != null)
                {
                    for (i = 0; i < Argu.Length; i++)
                    {
                        TRSNode node = in_node.AddNode("SQL_ARG_LIST");
                        node.AddString("SQL_ARG", Argu[i]);
                    }
                }

                if (lblStatus != null)
                {
                    CSCF.ShowStatusMsg(lblStatus, 'R', "");
                }

                if (MPCF.CallService("CUS", "CUS_View_Label_Code", in_node, ref out_node, !bShowMsgBox) == false)
                {
                    if (!bShowMsgBox && lblStatus != null)
                    {
                        CSCF.CheckContinueProcMB(out_node, lblStatus);
                    }
                    return false;
                }

                sLabelCode = out_node.GetString("LABEL_CODE_1");

                if (MPCF.Trim(out_node.GetString("LABEL_CMF_2")).Equals("Y"))
                    cMultiArrayFlag = 'Y';

                if (MPCF.Trim(sLabelCode) == "")
                {
                    if (!bShowMsgBox && lblStatus != null)
                    {
                        CSCF.ShowStatusMsg(lblStatus, 'E', MPCF.GetMessage(391));
                    }
                    else
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(391));
                    }
                }

                //sSQLData = out_node.GetString("DATA_SQL");
                iArgCount = out_node.GetInt("ARG_COUNT");

                if (out_node.GetList("DATA_LIST").Count > 0)
                {
                    data_list = out_node.GetList("DATA_LIST")[0];

                    sRepStr = new string[20];
                    sRepStr[0] = data_list.GetString("KEY_1");
                    sRepStr[1] = data_list.GetString("KEY_2");
                    sRepStr[2] = data_list.GetString("KEY_3");
                    sRepStr[3] = data_list.GetString("KEY_4");
                    sRepStr[4] = data_list.GetString("KEY_5");
                    sRepStr[5] = data_list.GetString("KEY_6");
                    sRepStr[6] = data_list.GetString("KEY_7");
                    sRepStr[7] = data_list.GetString("KEY_8");
                    sRepStr[8] = data_list.GetString("KEY_9");
                    sRepStr[9] = data_list.GetString("KEY_10");
                    sRepStr[10] = data_list.GetString("DATA_1");
                    sRepStr[11] = data_list.GetString("DATA_2");
                    sRepStr[12] = data_list.GetString("DATA_3");
                    sRepStr[13] = data_list.GetString("DATA_4");
                    sRepStr[14] = data_list.GetString("DATA_5");
                    sRepStr[15] = data_list.GetString("DATA_6");
                    sRepStr[16] = data_list.GetString("DATA_7");
                    sRepStr[17] = data_list.GetString("DATA_8");
                    sRepStr[18] = data_list.GetString("DATA_9");
                    sRepStr[19] = data_list.GetString("DATA_10");
                }

                return true;
            }
            catch (Exception ex)
            {
                if (!bShowMsgBox && lblStatus != null)
                {
                    CSCF.ShowStatusMsg(lblStatus, 'E', ex.Message);
                }
                else
                {
                    MPCF.ShowMsgBox(ex.Message);
                }

                return false;
            }

        }
        #endregion

        #region " ReplaceLabelData "
        // ReplaceLabelData()
        //       - Print Order
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        public static bool ReplaceLabelData(char cStep, string sLabelCode, ref string sRepLabelCode, string[] sRepStr)
        {
            int i;

            try
            {
                if (sRepStr == null)
                    return false;

                for (i = 0; i < sRepStr.Length; i++)
                {
                    if (sRepStr[i] == null)
                        break;

                    sLabelCode = sLabelCode.Replace("$" + (i + 1).ToString(), sRepStr[i]);
                }

                sRepLabelCode = sLabelCode;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        public static bool ReplaceLabelData(ref TRSNode in_node, ref string sRepLabelCode)
        {
            int i;
            string sLabelCode = string.Empty;
            string sFromStr = string.Empty;
            string sToStr = string.Empty;

            try
            {
                sLabelCode = in_node.GetString("LABEL_CODE_1");

                for (i = 0; i < in_node.GetList("LABEL_AGR").Count; i++)
                {
                    sFromStr = in_node.GetList("LABEL_AGR")[i].GetString("DATA");
                    sToStr = in_node.GetString(sFromStr.Replace("$", ""));

                    sLabelCode = sLabelCode.Replace(sFromStr, sToStr);
                }

                sRepLabelCode = sLabelCode;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
        #endregion

        #region " GetLabelCode "
        // GetLabelCode()
        //       - Print Order
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        //    string sLabelCode = string.Empty;
        //    string[] argu;
        //    argu = new string[1];
        //
        //    argu[0] = "PID0001-0001";
        //
        //    CSCR.GetLabelCode('3', "HMR1_TEST_LABEL2", ref sLabelCode, argu);
        //
        public static bool GetLabelCode(char cStep, string sLineID, string sOper, ref string sRepLabelCode, string[] Argu)
        {
            return GetLabelCode(cStep, sLineID, sOper, ref sRepLabelCode, Argu, true, null);
        }
        public static bool GetLabelCode(char cStep, string sLineID, string sOper, ref string sRepLabelCode, string[] Argu,
                                        bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus)
        {
            string[] sRepStr = null;
            string sLabelCode = string.Empty;
            char cMultiArrayFlag = ' ';

            try
            {
                if (ViewLabelInfo(cStep, sLineID, sOper, ref sLabelCode, ref cMultiArrayFlag, Argu, ref sRepStr, bShowMsgBox, lblStatus) == false)
                    return false;

                if (ReplaceLabelData(cStep, sLabelCode, ref sRepLabelCode, sRepStr) == false)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                if (!bShowMsgBox && lblStatus != null)
                {
                    CSCF.ShowStatusMsg(lblStatus, 'E', ex.Message);
                }
                else
                {
                    MPCF.ShowMsgBox(ex.Message);
                }

                return false;
            }

        }
        #endregion

        #region " FormMultiArrayLabel "

        public static bool FormMultiArrayLabel(ref string[] sMLots, int iLotCount, bool bWithSeq, int iSeqLength, ref string sLabelCommand)
        {
            int i;
            string sLotID = string.Empty;
            string sSeq = string.Empty;

            try
            {
                for (i = 0; i < iLotCount; i++)
                {
                    if (MPCF.Trim(sMLots[i]).Length < iSeqLength)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(416) + " [" + sMLots[i] + "]");
                        return false;
                    }
                }

                sLabelCommand = "^XA^JMA^LL240^PW1020^MD0^PR2^PON^LRN^LH0,0";

                if (iLotCount >= 1)
                {
                    sLotID = sMLots[0];
                    sSeq = sMLots[0].Substring(sMLots[0].Length - iSeqLength);

                    sLabelCommand += "^FO52,12^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO52,95^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 2)
                {
                    sLotID = sMLots[1];
                    sSeq = sMLots[1].Substring(sMLots[1].Length - iSeqLength);

                    sLabelCommand += "^FO194,12^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO194,95^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 3)
                {
                    sLotID = sMLots[2];
                    sSeq = sMLots[2].Substring(sMLots[2].Length - iSeqLength);

                    sLabelCommand += "^FO336,12^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO336,95^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 4)
                {
                    sLotID = sMLots[3];
                    sSeq = sMLots[3].Substring(sMLots[3].Length - iSeqLength);

                    sLabelCommand += "^FO478,12^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO482,95^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 5)
                {
                    sLotID = sMLots[4];
                    sSeq = sMLots[4].Substring(sMLots[4].Length - iSeqLength);

                    sLabelCommand += "^FO620,12^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO620,95^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 6)
                {
                    sLotID = sMLots[5];
                    sSeq = sMLots[5].Substring(sMLots[5].Length - iSeqLength);

                    sLabelCommand += "^FO762,12^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO762,95^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 7)
                {
                    sLotID = sMLots[6];
                    sSeq = sMLots[6].Substring(sMLots[6].Length - iSeqLength);

                    sLabelCommand += "^FO904,12^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO904,95^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 8)
                {
                    sLotID = sMLots[7];
                    sSeq = sMLots[7].Substring(sMLots[7].Length - iSeqLength);

                    sLabelCommand += "^FO52,126^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO52,209^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 9)
                {
                    sLotID = sMLots[8];
                    sSeq = sMLots[8].Substring(sMLots[8].Length - iSeqLength);

                    sLabelCommand += "^FO194,126^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO194,209^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 10)
                {
                    sLotID = sMLots[9];
                    sSeq = sMLots[9].Substring(sMLots[9].Length - iSeqLength);

                    sLabelCommand += "^FO336,126^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO336,209^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 11)
                {
                    sLotID = sMLots[10];
                    sSeq = sMLots[10].Substring(sMLots[10].Length - iSeqLength);

                    sLabelCommand += "^FO478,126^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO482,209^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 12)
                {
                    sLotID = sMLots[11];
                    sSeq = sMLots[11].Substring(sMLots[11].Length - iSeqLength);

                    sLabelCommand += "^FO620,126^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO620,209^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 13)
                {
                    sLotID = sMLots[12];
                    sSeq = sMLots[12].Substring(sMLots[12].Length - iSeqLength);

                    sLabelCommand += "^FO762,126^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO762,209^AAN,15,10^FD" + sSeq + "^FS";
                }
                if (iLotCount >= 14)
                {
                    sLotID = sMLots[13];
                    sSeq = sMLots[13].Substring(sMLots[13].Length - iSeqLength);

                    sLabelCommand += "^FO904,126^BQN,2,3,,A^FDQA," + sLotID + "^FS";

                    if (bWithSeq == true)
                        sLabelCommand += "^FO904,209^AAN,15,10^FD" + sSeq + "^FS";
                }

                sLabelCommand += "^PQ1^XZ";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        // ViewOperationList()
        //       - View All Operation List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : List媛 ?ㅼ뼱媛?control
        //        - ByVal c_step As String                        : ?뺤옣 Process Step
        //        - Optional ByVal sMaterial As String = ""    : sMaterial??媛吏?Operation
        //        - Optional ByVal sFlow As String = ""        : sFlow瑜?媛吏?Operation
        //        - Optional ByVal sFilter As String = ""        : sFilter濡??쒖옉?섎뒗 Oper
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?먯꽌 異붽???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?꾩옱 Factory媛 ?꾨땶寃쎌슦?????Factory
        //

        // View Inventory Operation 추가(WIP에 있는 함수와 동일) bs.kwak 2012.12.13
        // Service만 Inventory Service로 바꿈.

        public static bool ViewInvOperationList(Control control, char c_step)
        {
            return ViewInvOperationList(control, c_step, "", 0, "", "", null, "");
        }

        public static bool ViewInvOperationList(Control control, char c_step, bool b_sec_chk_flag)
        {
            return ViewInvOperationList(control, c_step, "", 0, "", "", null, "", b_sec_chk_flag);
        }

        public static bool ViewInvOperationList(Control control, char c_step, string sMaterial, int iMatVer)
        {
            return ViewInvOperationList(control, c_step, sMaterial, iMatVer, "", "", null, "");
        }

        public static bool ViewInvOperationList(Control control, char c_step, string sFlow)
        {
            return ViewInvOperationList(control, c_step, "", 0, sFlow, "", null, "");
        }
        public static bool ViewInvOperationList(Control control, char c_step, TreeNode parentNode)
        {
            return ViewInvOperationList(control, c_step, "", 0, "", "", parentNode, "");
        }

        public static bool ViewInvOperationList(Control control, char c_step, string sMaterial, int iMatVer, TreeNode parentNode)
        {
            return ViewInvOperationList(control, c_step, sMaterial, iMatVer, "", "", parentNode, "");
        }

        public static bool ViewInvOperationList(Control control, char c_step, string sFlow, TreeNode parentNode)
        {
            return ViewInvOperationList(control, c_step, "", 0, sFlow, "", parentNode, "");
        }

        public static bool ViewInvOperationList(Control control, char c_step, string sMaterial, int iMatVer, string sFlow, string sFilter, TreeNode parentNode, string sExtFactory)
        {
            return ViewInvOperationList(control, c_step, sMaterial, iMatVer, sFlow, sFilter, parentNode, sExtFactory, false);
        }

        // View Inventory Operation 추가(WIP에 있는 함수와 동일) bs.kwak 2012.12.13
        // Service만 Inventory Service로 바꿈.
        public static bool ViewInvOperationList(Control control, char c_step, string sMaterial, int iMatVer, string sFlow, string sFilter, TreeNode parentNode, string sExtFactory, bool b_sec_chk_flag)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (control is ListView)
            {
                ////MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                if (!(parentNode == null))
                {
                    parentNode.Nodes.Clear();
                }
                else
                {
                    MPCF.ClearList(control, true);
                }
            }

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("FILTER", sFilter);
            in_node.AddString("MAT_ID", sMaterial);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("NEXT_OPER", "");
            in_node.AddChar("SEC_CHK_FLAG", b_sec_chk_flag == true ? 'Y' : ' ');

            do
            {
                out_node = new TRSNode("VIEW_OPERATION_LIST_OUT");

                if (MPCF.CallService("TIV", "TIV_View_Inv_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));

            } while (in_node.GetString("NEXT_OPER") != "");


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("OPER"), (int)SMALLICON_INDEX.IDX_OPER);
                        if (((ListView)control).Columns.Count > 3)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPT_OPER_GROUP"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("OPT_OPER_OPTION_FLAG").ToString());
                        }
                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER_DESC"));
                        }
                        if (((ListView)control).Columns.Count > 2)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOSS_TBL"));
                        }

                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetString("OPER") + " : " + out_node.GetList(0)[i].GetString("OPER_DESC"),
                            (int)SMALLICON_INDEX.IDX_OPER, (int)SMALLICON_INDEX.IDX_OPER);
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("OPER"));
                    }
                }
            }

            return true;

        }


        #region " LoadPPCInfo "
        // LoadPPCInfo()
        //       - Load PPC Setup
        //       - After getting IP Address of the PPC which Client is working, 
        //         get and load settings for current PPC
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        public static bool LoadPPCInfo()
        {
            return LoadPPCInfo(true, null);
        }
        public static bool LoadPPCInfo(bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl scrollText)
        {
            TRSNode out_node;

            int i;

            try
            {
                CSGV.gsDefaultTerminalID = "";
                CSGV.gsTerminalID = "";
                CSGV.gsTerminalIPAddress = "";
                CSGV.gsTerminalResList = "";
                CSGV.gsTerminalWCList = "";
                //CSGV.gsTerminalOper = "";

                // Get IP Address of current PPC
                if (MPCF.Trim(CSGV.gsDebugIPAddress) != "")
                {
                    CSGV.gsTerminalIPAddress = CSGV.gsDebugIPAddress;
                }
                else
                {
                    CSGV.gsTerminalIPAddress = CSCF.GetIPAddress();
                }

                // Get PPC Setup
                out_node = new TRSNode("VIEW_MATERIAL_OUT");

                if (CSCR.ViewAttributeList('1', CSGC.MP_GCM_TBL_TERMINAL_INFO, CSGC.ATTR_NAME_TERMINAL_IPADDR, CSGV.gsTerminalIPAddress, "", ref out_node,
                             bShowMsgBox, scrollText) == false)
                {
                    return false;
                }

                if (out_node.GetList(0).Count <= 0)
                {
                    // If there is no operation(s) setup for current PPC
                    CSCF.ShowStatusMsg(scrollText, 'E', MPCF.GetMessage(382) + "[" + CSGV.gsTerminalIPAddress + "]");
                    return false;
                }

                CSGV.gsDefaultTerminalID = out_node.GetList(0)[0].GetString("ATTR_KEY");
                CSGV.gsTerminalID = CSGV.gsDefaultTerminalID;

                // Save PPC Setup
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("ATTR_NAME").Equals(CSGC.ATTR_NAME_TERMINAL_OPER))
                    {
                        //CSGV.gsTerminalOper = out_node.GetList(0)[i].GetString("ATTR_VALUE");
                    }
                    else if (out_node.GetList(0)[i].GetString("ATTR_NAME").Equals(CSGC.ATTR_NAME_TERMINAL_RES_LIST))
                    {
                        CSGV.gsTerminalResList = out_node.GetList(0)[i].GetString("ATTR_VALUE");
                    }
                    else if (out_node.GetList(0)[i].GetString("ATTR_NAME").Equals(CSGC.ATTR_NAME_TERMINAL_WORK_CENTER_LIST))
                    {
                        CSGV.gsTerminalWCList = out_node.GetList(0)[i].GetString("ATTR_VALUE");
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                if (!bShowMsgBox && scrollText != null)
                {
                    CSCF.ShowStatusMsg(scrollText, 'E', ex.Message + " [LoadPPCInfo]");
                }
                else
                {
                    MPCF.ShowMsgBox(ex.Message + " [LoadPPCInfo]");
                }
                return false;
            }
        }

        public static bool LoadPPCInfo(string sTeminalID)
        {
            return LoadPPCInfo(sTeminalID, true, null);
        }
        public static bool LoadPPCInfo(string sTeminalID, bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl scrollText)
        {
            TRSNode out_node;

            int i;

            try
            {
                CSGV.gsTerminalID = "";
                CSGV.gsTerminalResList = "";
                CSGV.gsTerminalWCList = "";
                //CSGV.gsTerminalOper = "";

                // Get PPC Setup
                out_node = new TRSNode("VIEW_MATERIAL_OUT");

                if (CSCR.ViewAttributeList('2', CSGC.MP_GCM_TBL_TERMINAL_INFO, "", "", sTeminalID, ref out_node,
                             bShowMsgBox, scrollText) == false)
                {
                    return false;
                }

                if (out_node.GetList(0).Count <= 0)
                {
                    // If there is no operation(s) setup for current PPC
                    CSCF.ShowStatusMsg(scrollText, 'E', MPCF.GetMessage(382) + "[" + CSGV.gsTerminalIPAddress + "]");
                    return false;
                }

                CSGV.gsTerminalID = sTeminalID;

                // Save PPC Setup
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("ATTR_NAME").Equals(CSGC.ATTR_NAME_TERMINAL_OPER))
                    {
                        //CSGV.gsTerminalOper = out_node.GetList(0)[i].GetString("ATTR_VALUE");
                    }
                    else if (out_node.GetList(0)[i].GetString("ATTR_NAME").Equals(CSGC.ATTR_NAME_TERMINAL_RES_LIST))
                    {
                        CSGV.gsTerminalResList = out_node.GetList(0)[i].GetString("ATTR_VALUE");
                    }
                    else if (out_node.GetList(0)[i].GetString("ATTR_NAME").Equals(CSGC.ATTR_NAME_TERMINAL_WORK_CENTER_LIST))
                    {
                        CSGV.gsTerminalWCList = out_node.GetList(0)[i].GetString("ATTR_VALUE");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (!bShowMsgBox && scrollText != null)
                {
                    CSCF.ShowStatusMsg(scrollText, 'E', ex.Message + " [LoadPPCInfo]");
                }
                else
                {
                    MPCF.ShowMsgBox(ex.Message + " [LoadPPCInfo]");
                }
                return false;
            }
        }

        public static bool LoadPPCInfo(char cStep, string sTeminalID, ref TRSNode out_node, bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl scrollText)
        {
            TRSNode in_node = new TRSNode("VIEW_IN");

            int i;

            try
            {
                if (cStep == '1')
                {
                    CSGV.gsDefaultTerminalID = "";
                    CSGV.gsTerminalIPAddress = "";

                    // Get IP Address of current PPC
                    if (MPCF.Trim(CSGV.gsDebugIPAddress) != "")
                    {
                        CSGV.gsTerminalIPAddress = CSGV.gsDebugIPAddress;
                    }
                    else
                    {
                        CSGV.gsTerminalIPAddress = CSCF.GetIPAddress();
                    }
                }

                CSGV.gsTerminalID = "";
                CSGV.gsTerminalResList = "";
                CSGV.gsTerminalWCList = "";
                //CSGV.gsTerminalOper = "";
                //CSGV.gcOrderCriteria = ' ';
                //CSGV.gcMoldCheckFlag = ' ';
                //CSGV.gcPalleteCheckFlag = ' ';
                //CSGV.gcSNPLockFlag = ' ';

                // Get PPC Setup
                out_node = new TRSNode("VIEW_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cStep;

                if (cStep == '1')
                {
                    in_node.AddString("ATTR_TYPE", CSGC.MP_GCM_TBL_TERMINAL_INFO);
                    in_node.AddString("ATTR_NAME", CSGC.ATTR_NAME_TERMINAL_IPADDR);
                    in_node.AddString("ATTR_VALUE", CSGV.gsTerminalIPAddress);
                }
                if (cStep == '2')
                {
                    in_node.AddString("DEFAULT_TERMIANL", CSGV.gsDefaultTerminalID);
                    in_node.AddString("ATTR_TYPE", CSGC.MP_GCM_TBL_TERMINAL_INFO);
                    in_node.AddString("ATTR_KEY", MPCF.Trim(sTeminalID));
                }

                if (scrollText != null)
                {
                    CSCF.ShowStatusMsg(scrollText, 'R', "");
                }

                if (MPCF.CallService("CUS", "CUS_View_Terminal_Configuration", in_node, ref out_node, !bShowMsgBox) == false)
                {
                    if (!bShowMsgBox && scrollText != null)
                    {
                        CSCF.CheckContinueProcMB(out_node, scrollText);
                    }
                    return false;
                }

                if (cStep == '1')
                {
                    CSGV.gsDefaultTerminalID = out_node.GetString("TERMINAL_ID");
                    CSGV.gsTerminalID = CSGV.gsDefaultTerminalID;
                }
                else
                {
                    CSGV.gsTerminalID = sTeminalID;
                }

                //CSGV.gsTerminalOper = out_node.GetString("TERMINAL_OPER");
                CSGV.gsTerminalResList = out_node.GetString("RES_LIST");
                CSGV.gsTerminalWCList = out_node.GetString("WORK_CENTER_LIST");

                CSGV.gsLabelPrinter = out_node.GetString("LABEL_PRINTER");
                CSGV.gsLblMarginLeft = MPCF.ToInt(out_node.GetString("MARGIN_LEFT"));
                CSGV.gsLblMarginTop = MPCF.ToInt(out_node.GetString("MARGIN_TOP"));
                //CSGV.gcMoldCheckFlag = out_node.GetChar("MOLD_CHECK_FLAG");
                //CSGV.gcOrderCriteria = out_node.GetChar("ORDER_CRITERIA");
                //CSGV.gcPalleteCheckFlag = out_node.GetChar("PALLETE_CHECK_FLAG");
                //CSGV.gcSNPLockFlag = out_node.GetChar("SNP_LOCK_FLAG");

                return true;
            }
            catch (Exception ex)
            {
                if (!bShowMsgBox && scrollText != null)
                {
                    CSCF.ShowStatusMsg(scrollText, 'E', ex.Message + " [LoadPPCInfo]");
                }
                else
                {
                    MPCF.ShowMsgBox(ex.Message + " [LoadPPCInfo]");
                }
                return false;
            }
        }

        #endregion

        #region " ViewOperation "

        //
        // ViewOperation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public static bool ViewOperation(string sOper, ref TRSNode out_node)
        {
            return ViewOperation(sOper, ref out_node, true, null);
        }
        public static bool ViewOperation(string sOper, ref TRSNode out_node, bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl scrollText)
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", sOper);

            if (scrollText != null)
            {
                CSCF.ShowStatusMsg(scrollText, 'R', "");
            }

            if (MPCF.CallService("WIP", "WIP_View_Operation", in_node, ref out_node, !bShowMsgBox) == false)
            {
                if (!bShowMsgBox && scrollText != null)
                {
                    CSCF.CheckContinueProcMB(out_node, scrollText);
                }
                return false;
            }

            return true;
        }

        #endregion

        #region " ViewMaterial "

        // ViewMaterial()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        public static bool ViewMaterial(char sStep, string s_mat_id, int i_mat_ver, char c_route_flag,
                                        string s_route_oper, char c_ord_usr_info_flag, string s_order_id, string s_user_id, ref TRSNode out_node)
        {
            return ViewMaterial(sStep, s_mat_id, i_mat_ver, c_route_flag, s_route_oper, ' ', " ", c_ord_usr_info_flag,
                               s_order_id, s_user_id, ' ', " ", ref out_node);
        }
        public static bool ViewMaterial(char sStep, string s_mat_id, int i_mat_ver, char c_route_flag,
                                        string s_route_oper, char c_label_flag, string s_label_group,
                                        char c_ord_usr_info_flag, string s_order_id, string s_user_id,
                                        char c_oper_flag, string s_oper, ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("View_Data_In");

            try
            {
                out_node = new TRSNode("View_Data_Out");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = sStep;
                in_node.AddString("MAT_ID", MPCF.Trim(s_mat_id));
                in_node.AddInt("MAT_VER", i_mat_ver);

                in_node.AddChar("ROUTE_FLAG", c_route_flag);
                in_node.AddString("ROUTE_OPER", MPCF.Trim(s_route_oper));

                in_node.AddChar("OPER_FLAG", c_oper_flag);
                in_node.AddString("OPER", MPCF.Trim(s_oper));

                in_node.AddChar("LABEL_FLAG", c_label_flag);
                in_node.AddString("LABEL_GROUP", MPCF.Trim(s_label_group));

                in_node.AddChar("ORDER_USER_INFO_FLAG", c_ord_usr_info_flag);
                in_node.AddString("ORDER_ID", MPCF.Trim(s_order_id));
                in_node.AddString("PROC_USER_ID", MPCF.Trim(s_user_id));

                if (MPCF.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #region " ViewInvOperation "

        //
        // ViewInvOperation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public static bool ViewInvOperation(char cProcStep, string sOper, ref TRSNode out_node)
        {
            return ViewInvOperation(cProcStep, sOper, ref out_node, true, null);
        }
        public static bool ViewInvOperation(char cProcStep, string sOper, ref TRSNode out_node, bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl scrollText)
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cProcStep;
            in_node.AddString("OPER", MPCF.Trim(sOper));

            if (scrollText != null)
            {
                CSCF.ShowStatusMsg(scrollText, 'R', "");
            }

            if (MPCF.CallService("TIV", "TIV_View_Inv_Operation", in_node, ref out_node, !bShowMsgBox) == false)
            {
                if (!bShowMsgBox && scrollText != null)
                {
                    CSCF.CheckContinueProcMB(out_node, scrollText);
                }
                return false;
            }

            return true;
        }

        #endregion

        #region " ViewResource "

        //
        // ViewResource()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public static bool ViewResource(string sResID, ref TRSNode out_node)
        {
            return ViewResource(sResID, ' ', " ", ref out_node, true, null);
        }
        public static bool ViewResource(string sResID, char cToolCheckFlag,
                                        string sToolType, ref TRSNode out_node, bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl scrollText)
        {
            TRSNode in_node = new TRSNode("View_Resource_In");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RES_ID", sResID);
            in_node.AddChar("TOOL_CHECK_FLAG", cToolCheckFlag);
            in_node.AddString("TOOL_TYPE", sToolType);

            if (scrollText != null)
            {
                CSCF.ShowStatusMsg(scrollText, 'R', "");
            }

            if (MPCF.CallService("RAS", "RAS_View_Resource", in_node, ref out_node, !bShowMsgBox) == false)
            {
                if (!bShowMsgBox && scrollText != null)
                {
                    CSCF.CheckContinueProcMB(out_node, scrollText);
                }
                return false;
            }

            return true;
        }

        #endregion

        #region " ViewLot "

        //
        // ViewLot()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public static bool ViewLot(char cStep, string sLotID, ref TRSNode out_node)
        {
            return ViewLot(cStep, ' ', sLotID, ref out_node, true, null);
        }
        public static bool ViewLot(char cStep, char cLabelFlag, string sLotID, ref TRSNode out_node)
        {
            return ViewLot(cStep, cLabelFlag, sLotID, ref out_node, true, null);
        }
        public static bool ViewLot(char cStep, char cLabelFlag, string sLotID, ref TRSNode out_node, bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl scrollText)
        {
            TRSNode in_node = new TRSNode("View_Lot_In");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("LOT_ID", sLotID);
            in_node.AddChar("LABEL_FLAG", cLabelFlag);

            if (scrollText != null)
            {
                CSCF.ShowStatusMsg(scrollText, 'R', "");
            }

            if (MPCF.CallService("CUS", "CUS_View_Lot", in_node, ref out_node, !bShowMsgBox) == false)
            {
                if (!bShowMsgBox && scrollText != null)
                {
                    CSCF.CheckContinueProcMB(out_node, scrollText);
                }
                return false;
            }

            return true;
        }

        #endregion

        #region " ViewTool "

        //
        // ViewTool()
        //       -  View Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool ViewTool(char c_proc_type, string s_tool_type, string s_tool_id, ref TRSNode out_node,
                                    bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus)
        {
            TRSNode in_node = new TRSNode("View_Sub_Resource_In");
            int i;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_proc_type;
                in_node.AddString("TOOL_TYPE", MPCF.Trim(s_tool_type));
                in_node.AddString("TOOL_ID", MPCF.Trim(s_tool_id));

                if (lblStatus != null)
                {
                    CSCF.ShowStatusMsg(lblStatus, 'R', "");
                }

                if (MPCF.CallService("RAS", "RAS_View_Tool", in_node, ref out_node, !bShowMsgBox) == false)
                {
                    if (!bShowMsgBox && lblStatus != null)
                    {
                        CSCF.CheckContinueProcMB(out_node, lblStatus);
                    }
                    return false;
                }

                //txtTool.Text = out_node.GetString("TOOL_ID");
                //txtDesc.Text = out_node.GetString("TOOL_DESC");

                //cdvToolGroup.Text = out_node.GetString("TOOL_GRP");
                //txtToolSetID.Text = out_node.GetString("TOOL_SET_ID");
                //txtToolSetLoc.Text = out_node.GetString("TOOL_SET_LOCATION");
                //txtToolStatus.Text = out_node.GetString("TOOL_STATUS");
                //txtLotID.Text = out_node.GetString("LOT_ID");
                //txtSubLotID.Text = out_node.GetString("SUBLOT_ID");
                //txtResID.Text = out_node.GetString("RES_ID");
                //txtSubResID.Text = out_node.GetString("SUBRES_ID");
                //cdvMaterial.Text = out_node.GetString("MAT_ID");
                //cdvMaterial.Version = out_node.GetInt("MAT_VER");
                //txtFlow.Text = out_node.GetString("FLOW");
                //txtOper.Text = out_node.GetString("OPER");
                //txtDeleteFlag.Text = out_node.GetChar("DELETE_FLAG").ToString();
                //cdvAreaID.Text = out_node.GetString("AREA_ID");
                //cdvSubAreaID.Text = out_node.GetString("SUB_AREA_ID");
                //txtToolLoc.Text = out_node.GetString("TOOL_LOCATION");
                //txtVender.Text = out_node.GetString("VENDOR_ID");
                //txtVenderToolID.Text = out_node.GetString("VENDOR_TOOL_ID");
                //txtCellCountX.Text = out_node.GetInt("CELL_COUNT_X").ToString();
                //txtCellCountY.Text = out_node.GetInt("CELL_COUNT_Y").ToString();
                //txtCellCountZ.Text = out_node.GetInt("CELL_COUNT_Z").ToString();
                //txtCellSizeX.Text = out_node.GetInt("CELL_SIZE_X").ToString();
                //txtCellSizeY.Text = out_node.GetInt("CELL_SIZE_Y").ToString();
                //txtCellSizeZ.Text = out_node.GetInt("CELL_SIZE_Z").ToString();
                //cdvToolGradeID.Text = out_node.GetChar("GRADE").ToString();
                //txtToolComment.Text = out_node.GetString("TOOL_COMMENT");


                //if (out_node.GetChar("DELETE_FLAG") == 'R')
                //{
                //    btnRegenerate.Visible = true;
                //    btnDelete.Visible = false;
                //}
                //else
                //{
                //    btnRegenerate.Visible = false;
                //    btnDelete.Visible = true;
                //}

                //if (MPCF.Trim(cdvType.Text) != MPCF.Trim(ToolTypeInfo.tool_type))
                //{
                //    if (View_Tool_Type() == false)
                //    {
                //        return false;
                //    }
                //}

                //for (i = 0; i < 30; i++)
                //{
                //    if (MPCF.Trim(ToolTypeInfo.typelist[i].prompt) != "")
                //    {
                //        spdData.ActiveSheet.Cells[i, 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_STS"));
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        #endregion

        #region " ViewGCMDataListKey12 "

        public static bool ViewGCMDataListKey12(Control Form_control, char c_step, string table_name, int Image_idx, string Ext_Factory, bool bIgnoreError, string[] Argu)
        {

            ListViewItem itmX;

            int i;
            int j;
            List<string> sList = new List<string>();
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (Form_control is ListView)
            {
                //MPCF.InitListView((ListView)Form_control);
            }
            else
            {
                return false;
            }

            //if (Form_control is SOICodeView.MCCodeDropList)
            //{
            //    ((SOICodeView.MCCodeDropList)Form_control).GCMTableName = table_name;
            //}
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

            MPCF.SetInMsg(in_node);
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

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node, bIgnoreError) == false)
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
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("KEY_2"));
                                        break;

                                    case 1:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_1"));
                                        break;

                                    case 2:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_2"));
                                        break;

                                    case 3:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_3"));
                                        break;

                                    case 4:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_4"));
                                        break;

                                    case 5:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_5"));
                                        break;

                                    case 6:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_6"));
                                        break;

                                    case 7:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_7"));
                                        break;

                                    case 8:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_8"));
                                        break;

                                    case 9:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_9"));
                                        break;

                                    case 10:
                                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_10"));
                                        break;
                                }
                            }
                        }
                        ((ListView)Form_control).Items.Add(itmX);
                    }
                }
            }

            return true;
        }

        #endregion

        #region " ViewGCMData "

        public static bool ViewGCMData(char c_step, string table_name, string key_1, string key_2, ref TRSNode out_node, bool bIgnoreError)
        {
            return ViewGCMData(c_step, table_name, key_1, key_2, ref out_node, !bIgnoreError, null);
        }
        public static bool ViewGCMData(char c_step, string table_name, string key_1, string key_2, ref TRSNode out_node, bool bShowMsgBox,
                         SOI.Solar.Controls.udcScrollingTextCtrl scrollText)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddString("TABLE_NAME", table_name);
            in_node.AddString("KEY_1", key_1);
            in_node.AddString("KEY_2", key_2);

            out_node = new TRSNode("VIEW_DATA_OUT");

            if (scrollText != null)
            {
                CSCF.ShowStatusMsg(scrollText, 'R', "");
            }

            if (MPCF.CallService("BAS", "BAS_View_Data", in_node, ref out_node, !bShowMsgBox) == false)
            {
                if (!bShowMsgBox && scrollText != null)
                {
                    CSCF.CheckContinueProcMB(out_node, scrollText);
                }
                return false;
            }


            return true;
        }

        public static bool ViewGCMData(char c_step, string table_name, string key_1, string key_2, ref TRSNode out_node, string Ext_Factory)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (MPCF.Trim(Ext_Factory) != "")
            {
                in_node.SetString("FACTORY", Ext_Factory);
            }

            in_node.AddString("TABLE_NAME", table_name);
            in_node.AddString("KEY_1", key_1);
            in_node.AddString("KEY_2", key_2);

            out_node = new TRSNode("VIEW_DATA_OUT");

            if (MPCF.CallService("BAS", "BAS_View_Data", in_node, ref out_node, false) == false)
            {
                return false;
            }


            return true;
        }

        #endregion

        #region " ViewProcOper "

        public static bool ViewProcOper(char c_step, string sProcKey, string Ext_Factory, ref string sProcOper)
        {
            TRSNode out_node = new TRSNode("VIEW_DATA_OUT");
            string table_name = string.Empty;

            table_name = CSGC.MP_GCM_PROC_OPER_SETUP;

            if (ViewGCMData(c_step, table_name, sProcKey, " ", ref out_node, Ext_Factory) == false)
                return false;

            sProcOper = MPCF.Trim(out_node.GetString("DATA_1"));

            return true;
        }

        #endregion

        #region " ViewWorkOrder "

        // ViewWorkOrder()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        public static bool ViewWorkOrder(string sOrderID, ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("VIEW_IN");

            int i;

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ORDER_ID", MPCF.Trim(sOrderID));

            if (MPCF.CallService("CUS", "CUS_View_Order_List", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region " VIEW ORDER LIST FUNCTIONS "

        #region " SetOrderSpreadColumns "

        //
        // SetOrderSpreadColumns()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step

        public static bool SetOrderSpreadColumns(FarPoint.Win.Spread.FpSpread spdList, bool bBoldHeader, bool bBoldText)
        {
            int i;
            string sTemp = string.Empty;
            System.Drawing.Font bFont;
            System.Drawing.Font bFontTxt;
            //CultureInfo ci = CultureInfo.CurrentCulture;

            FarPoint.Win.Spread.CellType.NumberCellType numCellType;


            try
            {
                numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCellType.FixedPoint = false;
                numCellType.DecimalPlaces = 3;
                numCellType.ShowSeparator = true;
                //numCellType.Separator = ci.NumberFormat.NumberGroupSeparator;
                //numCellType.DecimalSeparator = ci.NumberFormat.NumberDecimalSeparator;

                if (bBoldHeader == true)
                {
                    bFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                }
                else
                {
                    bFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
                }

                if (bBoldText == true)
                {
                    bFontTxt = new System.Drawing.Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
                }
                else
                {
                    bFontTxt = new System.Drawing.Font("Microsoft Sans Serif", 11F, FontStyle.Regular);
                }


                spdList.ActiveSheet.ColumnCount = 0;
                spdList.ActiveSheet.ColumnCount = Enum.GetNames(typeof(CSGC.ORD_LIST)).Length;
                spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].HorizontalAlignment = CellHorizontalAlignment.Left;
                spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].Locked = true;
                spdList.ActiveSheet.FrozenColumnCount = 1;

                for (i = 0; i < spdList.ActiveSheet.ColumnCount; i++)
                {
                    sTemp = Enum.GetName(typeof(CSGC.ORD_LIST), i);

                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].ForeColor = Color.FromArgb(71, 99, 158);
                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].Font = bFont;
                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].Text = CSCF.GenCaptionText(sTemp);

                    if (sTemp.ToUpper().Contains("QTY") || sTemp.ToUpper().Contains("NUM") || sTemp.ToUpper().Contains("COUNT"))
                    {
                        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Right;
                        spdList.ActiveSheet.Columns[i].CellType = numCellType;
                    }
                    else if (sTemp.ToUpper().EndsWith("FLAG") || sTemp.ToUpper().EndsWith("VER"))
                    {
                        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }

                    spdList.ActiveSheet.Columns[i].Font = bFontTxt;

                }
                spdList.ActiveSheet.FrozenColumnCount = (int)CSGC.ORD_LIST.MAT_VER + 1;


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        #endregion

        #region " ViewWorkOrderList "

        // ViewWorkOrderList()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //

        public static bool ViewWorkOrderList(FarPoint.Win.Spread.FpSpread spdList,
                        char ProcStep, string sOper, char c_res_or_wc, string sWorkDate, string sShift, string sResID,
                        string[] sResWcList,
                        bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus)
        {
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");
            TRSNode list_item;

            int i;

            MPCF.ClearList(spdList, true);

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("WORK_DATE", MPCF.Trim(sWorkDate));
            in_node.AddString("OPER", MPCF.Trim(sOper));

            in_node.AddString("SHIFT", MPCF.Trim(sShift));
            in_node.AddString("TOOL_TYPE", CSGC.MP_TOOL_TYPE_MOLD_TYPE_01);

            in_node.AddChar("ORDER_CRITERIA", c_res_or_wc);

            if (MPCF.Trim(sResID) != "")
            {
                in_node.AddChar("KEY_LIST_FLAG", ' ');
                in_node.AddString("RES_ID", MPCF.Trim(sResID));
            }
            else
            {
                in_node.AddChar("KEY_LIST_FLAG", 'Y');

                for (i = 0; i < sResWcList.Length; i++)
                {
                    list_item = in_node.AddNode("RES_LIST");
                    list_item.AddString("RES_WC_ID", sResWcList[i]);
                }
            }

            do
            {
                if (lblStatus != null)
                {
                    CSCF.ShowStatusMsg(lblStatus, 'R', "");
                }

                if (MPCF.CallService("CUS", "CUS_View_Order_List", in_node, ref out_node, !bShowMsgBox) == false)
                {
                    if (!bShowMsgBox && lblStatus != null)
                    {
                        CSCF.CheckContinueProcMB(out_node, lblStatus);
                    }
                    return false;
                }

                if (MakeOrderListInfo('1', spdList, ref out_node) == false)
                {
                    return false;
                }

                in_node.SetString("NEXT_ORDER_ID", out_node.GetString("NEXT_ORDER_ID"));

            } while (in_node.GetString("NEXT_ORDER_ID") != "");

            MPCF.FitColumnHeader(spdList);

            if (spdList.Sheets[0].Columns[(int)CSGC.ORD_LIST.MAT_DESC].Width > 120)
                spdList.Sheets[0].Columns[(int)CSGC.ORD_LIST.MAT_DESC].Width = 120;

            if (spdList.Sheets[0].Columns[(int)CSGC.ORD_LIST.MAT_SHORT_DESC].Width > 140)
                spdList.Sheets[0].Columns[(int)CSGC.ORD_LIST.MAT_SHORT_DESC].Width = 140;

            if (spdList.Sheets[0].Columns[(int)CSGC.ORD_LIST.RES_DESC].Width > 120)
                spdList.Sheets[0].Columns[(int)CSGC.ORD_LIST.RES_DESC].Width = 120;

            if (spdList.Sheets[0].Columns[(int)CSGC.ORD_LIST.RES_SHORT_DESC].Width > 120)
                spdList.Sheets[0].Columns[(int)CSGC.ORD_LIST.RES_SHORT_DESC].Width = 120;

            return true;
        }


        #endregion

        #region " MakeOrderListInfo "

        public static bool MakeOrderListInfo(char cStep,
                              FarPoint.Win.Spread.FpSpread spdList,
                              ref TRSNode out_node)
        {
            FarPoint.Win.Spread.SheetView sheetX = spdList.ActiveSheet;
            //System.Drawing.Font bFont;

            int i, iRow;

            try
            {
                //MPCF.ClearList(spdList);
                //MPGV.geLanguageFormat = LANG_FORMAT.SYSTEM;

                //bFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = sheetX.RowCount;
                    sheetX.RowCount++;
                    sheetX.Rows[iRow].Height = CSGC.SPREAD_RAW_HEIGHT_OI;

                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID].Value = out_node.GetList(0)[i].GetString("ORDER_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_DESC].Value = out_node.GetList(0)[i].GetString("ORDER_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.WORK_DATE].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.SHIFT].Value = out_node.GetList(0)[i].GetString("SHIFT");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.RES_DESC].Value = out_node.GetList(0)[i].GetString("RES_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.RES_SHORT_DESC].Value = out_node.GetList(0)[i].GetString("RES_SHORT_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.WORK_CENTER].Value = out_node.GetList(0)[i].GetString("WORK_CENTER");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.MAT_VER].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.MAT_SHORT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_SHORT_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.FLOW].Value = out_node.GetList(0)[i].GetString("FLOW");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.FLOW_SEQ_NUM].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.OPER].Value = out_node.GetList(0)[i].GetString("OPER");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.OPER_DESC].Value = out_node.GetList(0)[i].GetString("OPER_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_QTY].Value = out_node.GetList(0)[i].GetDouble("ORDER_QTY");
                    //sheetX.Cells[iRow, (int)CSGC.ORD_LIST.WORK_UNIT_ORDER_QTY].Value = out_node.GetList(0)[i].GetInt("WORK_UNIT_ORDER_QTY");

                    //sheetX.Cells[iRow, (int)CSGC.ORD_LIST.WORK_UNIT_QTY].Value = out_node.GetList(0)[i].GetInt("WORK_UNIT_QTY");
                    //sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_QTY_UNIT].Value = out_node.GetList(0)[i].GetString("ORDER_QTY_UNIT");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.MOLD_GROUP_ID].Value = out_node.GetList(0)[i].GetString("MOLD_GROUP_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_TYPE].Value = out_node.GetList(0)[i].GetString("ORDER_TYPE");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.LOT_TYPE].Value = out_node.GetList(0)[i].GetChar("LOT_TYPE");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.OWNER_CODE].Value = out_node.GetList(0)[i].GetString("OWNER_CODE");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.CREATE_CODE].Value = out_node.GetList(0)[i].GetString("CREATE_CODE");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_PRIORITY].Value = out_node.GetList(0)[i].GetChar("ORD_PRIORITY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORG_DUE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ORG_DUE_TIME"));
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_STS].Value = out_node.GetList(0)[i].GetChar("ORD_STATUS_FLAG");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_STSD].Value = out_node.GetList(0)[i].GetString("ORD_STATUS_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.PLAN_START_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("PLAN_START_TIME"));
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.PLAN_END_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("PLAN_END_TIME"));
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.PROC_QTY].Value = out_node.GetList(0)[i].GetDouble("PROC_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.GOOD_QTY].Value = out_node.GetList(0)[i].GetDouble("GOOD_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.LOSS_QTY].Value = out_node.GetList(0)[i].GetDouble("LOSS_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.QC_QTY_1].Value = out_node.GetList(0)[i].GetDouble("QC_QTY_1");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.QC_QTY_2].Value = out_node.GetList(0)[i].GetDouble("QC_QTY_2");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.QC_QTY_3].Value = out_node.GetList(0)[i].GetDouble("QC_QTY_3");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.SCRAP_QTY].Value = out_node.GetList(0)[i].GetDouble("SCRAP_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.NO_LOSS_QTY].Value = out_node.GetList(0)[i].GetDouble("NO_LOSS_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.REWORK_QTY].Value = out_node.GetList(0)[i].GetDouble("REWORK_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_1].Value = out_node.GetList(0)[i].GetString("ORD_CMF_1");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_2].Value = out_node.GetList(0)[i].GetString("ORD_CMF_2");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_3].Value = out_node.GetList(0)[i].GetString("ORD_CMF_3");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_4].Value = out_node.GetList(0)[i].GetString("ORD_CMF_4");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_5].Value = out_node.GetList(0)[i].GetString("ORD_CMF_5");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_6].Value = out_node.GetList(0)[i].GetString("ORD_CMF_6");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_7].Value = out_node.GetList(0)[i].GetString("ORD_CMF_7");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_8].Value = out_node.GetList(0)[i].GetString("ORD_CMF_8");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_9].Value = out_node.GetList(0)[i].GetString("ORD_CMF_9");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORD_CMF_10].Value = out_node.GetList(0)[i].GetString("ORD_CMF_10");

                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.MOLD_ID].Value = out_node.GetList(0)[i].GetString("TOOL_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.CUR_MOLD_GRP].Value = out_node.GetList(0)[i].GetString("TOOL_STS_1");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.RES_STS].Value = out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG");

                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.WORK_DATE_RAW].Value = out_node.GetList(0)[i].GetString("WORK_DATE");

                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.SUSP_LOT_ID].Value = out_node.GetList(0)[i].GetString("SUSPEND_LOT_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.SUSP_QTY].Value = out_node.GetList(0)[i].GetDouble("SUSPEND_QTY");

                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.SUSP_MAT_ID].Value = out_node.GetList(0)[i].GetString("SUSPEND_MAT_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.SUSP_MAT_VER].Value = out_node.GetList(0)[i].GetInt("SUSPEND_MAT_VER");

                    sheetX.Cells[iRow, (int)CSGC.ORD_LIST.CAVITY].Value = out_node.GetList(0)[i].GetInt("CAVITY");

                    if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == 'D')
                    {
                        sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Navy;
                        sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        if (out_node.GetList(0)[i].GetChar("ORD_STATUS_FLAG") == CSGC.MP_ORDER_STATUS_PROC)
                        {
                            sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Navy;
                            sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].BackColor = Color.FromArgb(255, 255, 153);
                            //sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].Font = bFont;
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("SUSPEND_LOT_ID")) != "")
                        {
                            if ((out_node.GetList(0)[i].GetString("MAT_ID").Equals(out_node.GetList(0)[i].GetString("SUSPEND_MAT_ID")) == false) ||
                                (out_node.GetList(0)[i].GetInt("MAT_VER") != out_node.GetList(0)[i].GetInt("SUSPEND_MAT_VER")))
                            {
                                sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Navy;
                                sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].BackColor = Color.Orange;
                            }
                            else
                            {
                                sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Navy;
                                sheetX.Cells[iRow, (int)CSGC.ORD_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].BackColor = Color.PaleGreen;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #endregion

        #region " VIEW ORDER USER LIST FUNCTIONS "

        #region " SetOrderUserSpreadColumns "

        //
        // SetOrderUserSpreadColumns()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step

        public static bool SetOrderUserSpreadColumns(FarPoint.Win.Spread.FpSpread spdList, bool bBoldHeader, bool bBoldText)
        {
            int i;
            string sTemp = string.Empty;
            System.Drawing.Font bFont;
            System.Drawing.Font bFontTxt;

            //CultureInfo ci = CultureInfo.CurrentCulture;

            FarPoint.Win.Spread.CellType.NumberCellType numCellType;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCellType;

            try
            {
                numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCellType.FixedPoint = false;
                numCellType.DecimalPlaces = 3;
                numCellType.ShowSeparator = true;
                //numCellType.Separator = ci.NumberFormat.NumberGroupSeparator;
                //numCellType.DecimalSeparator = ci.NumberFormat.NumberDecimalSeparator;

                btnCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                btnCellType.Text = "REMOVE";

                if (bBoldHeader == true)
                {
                    bFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                }
                else
                {
                    bFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
                }

                if (bBoldText == true)
                {
                    bFontTxt = new System.Drawing.Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
                }
                else
                {
                    bFontTxt = new System.Drawing.Font("Microsoft Sans Serif", 11F, FontStyle.Regular);
                }

                spdList.ActiveSheet.ColumnCount = 0;
                spdList.ActiveSheet.ColumnCount = Enum.GetNames(typeof(CSGC.ORD_USR_LIST)).Length;
                spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].HorizontalAlignment = CellHorizontalAlignment.Left;
                spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].Locked = true;
                spdList.ActiveSheet.FrozenColumnCount = 1;

                for (i = 0; i < spdList.ActiveSheet.ColumnCount; i++)
                {
                    sTemp = Enum.GetName(typeof(CSGC.ORD_USR_LIST), i);

                    //if (sTemp.Equals("RES_WC_ID") == true)
                    //{
                    //    if (CSGV.gcOrderCriteria == CSGC.MP_ORDER_CRITERIA_RESOURCE)
                    //    {
                    //        sTemp = "RES_ID";
                    //    }
                    //    else
                    //    {
                    //        sTemp = "WORK_CENTER";
                    //    }
                    //}

                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].ForeColor = Color.FromArgb(71, 99, 158);
                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].Font = bFont;
                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].Text = CSCF.GenCaptionText(sTemp);

                    if (sTemp.ToUpper().Contains("QTY") || sTemp.ToUpper().Contains("NUM") || sTemp.ToUpper().Contains("COUNT"))
                    {
                        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Right;
                        spdList.ActiveSheet.Columns[i].CellType = numCellType;
                    }
                    else if (sTemp.ToUpper().EndsWith("FLAG") || sTemp.ToUpper().EndsWith("VER"))
                    {
                        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    else if (sTemp.ToUpper().EndsWith("BTN"))
                    {
                        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdList.ActiveSheet.Columns[i].CellType = btnCellType;
                    }

                    spdList.ActiveSheet.Columns[i].Font = bFontTxt;
                }

                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.USER_DESC].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.WORK_DATE].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.SHIFT].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.ORDER_ID].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.WORK_CENTER].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.RES_ID].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.RES_SHORT_DESC].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.RES_DESC].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.MAT_ID].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.MAT_VER].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.MAT_SHORT_DESC].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.MAT_DESC].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.ORD_QTY].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.PROC_QTY].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.GOOD_QTY].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.LOSS_QTY].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.ORD_USR_LIST.MOLD_ID].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        #endregion

        #region " ViewOrderUserList "

        // ViewOrderUserList()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //

        public static bool ViewOrderUserList(FarPoint.Win.Spread.FpSpread spdList,
                        char ProcStep, char cUserListFlag, string sWorkDate, string sShift, char c_res_or_wc, string sKey, string[] sResWcList,
                        bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus)
        {
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");
            TRSNode list_item;

            string sPrevOrderID = string.Empty;
            string sUserList = string.Empty;
            string sUserIDList = string.Empty;

            int i;
            int iStIdx;

            int iUserCount;

            MPCF.ClearList(spdList, true);

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("WORK_DATE", MPCF.Trim(sWorkDate));
            in_node.AddString("SHIFT", MPCF.Trim(sShift));
            in_node.AddString("RES_WC_LIST", MPCF.Trim(sResWcList));

            in_node.AddChar("ORDER_CRITERIA", c_res_or_wc);
            in_node.AddString("TOOL_TYPE", CSGC.MP_TOOL_TYPE_MOLD_TYPE_01);

            in_node.AddString("SEARCH_KEY", MPCF.Trim(sKey));

            if (MPCF.Trim(sKey) == "" && sResWcList != null)
            {
                for (i = 0; i < sResWcList.Length; i++)
                {
                    list_item = in_node.AddNode("RES_LIST");
                    list_item.AddString("RES_WC_ID", sResWcList[i]);
                }
            }

            do
            {
                if (lblStatus != null)
                {
                    CSCF.ShowStatusMsg(lblStatus, 'R', "");
                }

                if (MPCF.CallService("CUS", "CUS_View_Order_User_List", in_node, ref out_node, !bShowMsgBox) == false)
                {
                    if (!bShowMsgBox && lblStatus != null)
                    {
                        CSCF.CheckContinueProcMB(out_node, lblStatus);
                    }
                    return false;
                }

                if (MakeOrderUserListInfo('1', spdList, ref out_node) == false)
                {
                    return false;
                }

                in_node.SetString("NEXT_ORDER_ID", out_node.GetString("NEXT_ORDER_ID"));

            } while (in_node.GetString("NEXT_ORDER_ID") != "");

            if (cUserListFlag == 'Y' && spdList.Sheets[0].RowCount > 0)
            {
                iStIdx = 0;
                iUserCount = 0;

                for (i = 0; i < spdList.Sheets[0].RowCount; i++)
                {
                    if (sPrevOrderID.Equals(MPCF.Trim(spdList.Sheets[0].Cells[i, (int)CSGC.ORD_USR_LIST.ORDER_ID].Text)) == false)
                    {
                        if (i > 0)
                        {
                            spdList.Sheets[0].Cells[iStIdx, (int)CSGC.ORD_USR_LIST.USER_LIST, i - 1, (int)CSGC.ORD_USR_LIST.USER_LIST].Value = sUserList;
                            spdList.Sheets[0].Cells[iStIdx, (int)CSGC.ORD_USR_LIST.USER_ID_LIST, i - 1, (int)CSGC.ORD_USR_LIST.USER_ID_LIST].Value = sUserIDList;
                            spdList.Sheets[0].Cells[iStIdx, (int)CSGC.ORD_USR_LIST.USER_COUNT, i - 1, (int)CSGC.ORD_USR_LIST.USER_COUNT].Value = iUserCount;

                        }

                        iStIdx = i;
                        iUserCount = 1;
                        sPrevOrderID = MPCF.Trim(spdList.Sheets[0].Cells[i, (int)CSGC.ORD_USR_LIST.ORDER_ID].Text);
                        sUserList = MPCF.Trim(spdList.Sheets[0].Cells[i, (int)CSGC.ORD_USR_LIST.USER_DESC].Text);
                        sUserIDList = MPCF.Trim(spdList.Sheets[0].Cells[i, (int)CSGC.ORD_USR_LIST.USER_ID].Text);
                    }
                    else
                    {
                        sUserList = sUserList + ", " + MPCF.Trim(spdList.Sheets[0].Cells[i, (int)CSGC.ORD_USR_LIST.USER_DESC].Text);
                        sUserIDList = sUserIDList + ", " + MPCF.Trim(spdList.Sheets[0].Cells[i, (int)CSGC.ORD_USR_LIST.USER_ID].Text);
                        iUserCount++;
                    }
                }

                spdList.Sheets[0].Cells[iStIdx, (int)CSGC.ORD_USR_LIST.USER_LIST, i - 1, (int)CSGC.ORD_USR_LIST.USER_LIST].Value = sUserList;
                spdList.Sheets[0].Cells[iStIdx, (int)CSGC.ORD_USR_LIST.USER_ID_LIST, i - 1, (int)CSGC.ORD_USR_LIST.USER_ID_LIST].Value = sUserIDList;
                spdList.Sheets[0].Cells[iStIdx, (int)CSGC.ORD_USR_LIST.USER_COUNT, i - 1, (int)CSGC.ORD_USR_LIST.USER_COUNT].Value = iUserCount;
            }

            if (spdList.Sheets[0].Columns[(int)CSGC.ORD_USR_LIST.MAT_DESC].Width > 120)
                spdList.Sheets[0].Columns[(int)CSGC.ORD_USR_LIST.MAT_DESC].Width = 120;

            if (spdList.Sheets[0].Columns[(int)CSGC.ORD_USR_LIST.MAT_SHORT_DESC].Width > 140)
                spdList.Sheets[0].Columns[(int)CSGC.ORD_USR_LIST.MAT_SHORT_DESC].Width = 140;

            if (spdList.Sheets[0].Columns[(int)CSGC.ORD_USR_LIST.RES_DESC].Width > 120)
                spdList.Sheets[0].Columns[(int)CSGC.ORD_USR_LIST.RES_DESC].Width = 120;

            if (spdList.Sheets[0].Columns[(int)CSGC.ORD_USR_LIST.RES_SHORT_DESC].Width > 120)
                spdList.Sheets[0].Columns[(int)CSGC.ORD_USR_LIST.RES_SHORT_DESC].Width = 120;

            MPCF.FitColumnHeader(spdList);


            return true;
        }


        #endregion

        #region " MakeOrderUserListInfo "

        public static bool MakeOrderUserListInfo(char cStep,
                              FarPoint.Win.Spread.FpSpread spdList,
                              ref TRSNode out_node)
        {
            FarPoint.Win.Spread.SheetView sheetX = spdList.ActiveSheet;
            int i, iRow;

            try
            {
                //MPCF.ClearList(spdList);
                //MPGV.geLanguageFormat = LANG_FORMAT.SYSTEM;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = sheetX.RowCount;
                    sheetX.RowCount++;
                    sheetX.Rows[iRow].Height = CSGC.SPREAD_RAW_HEIGHT_OI;

                    //sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.CHECK].Value = out_node.GetList(0)[i].GetString("CHECK");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.WORK_DATE].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.SHIFT].Value = out_node.GetList(0)[i].GetString("SHIFT");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORDER_ID].Value = out_node.GetList(0)[i].GetString("ORDER_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.WORK_CENTER].Value = out_node.GetList(0)[i].GetString("WORK_CENTER");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.RES_SHORT_DESC].Value = out_node.GetList(0)[i].GetString("RES_SHORT_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.RES_DESC].Value = out_node.GetList(0)[i].GetString("RES_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MAT_VER].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MAT_SHORT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_SHORT_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.USER_ID].Value = out_node.GetList(0)[i].GetString("USER_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.USER_DESC].Value = out_node.GetList(0)[i].GetString("USER_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.START_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME"));
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.END_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME"));
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_QTY].Value = out_node.GetList(0)[i].GetDouble("ORDER_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.PROC_QTY].Value = out_node.GetList(0)[i].GetDouble("PROC_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.GOOD_QTY].Value = out_node.GetList(0)[i].GetDouble("GOOD_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.LOSS_QTY].Value = out_node.GetList(0)[i].GetDouble("LOSS_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.QC_QTY_1].Value = out_node.GetList(0)[i].GetDouble("QC_QTY_1");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.QC_QTY_2].Value = out_node.GetList(0)[i].GetDouble("QC_QTY_2");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.QC_QTY_3].Value = out_node.GetList(0)[i].GetDouble("QC_QTY_3");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.CLOSE_FLAG].Value = out_node.GetList(0)[i].GetChar("CLOSE_FLAG");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.RES_OR_WC_FLAG].Value = out_node.GetList(0)[i].GetChar("RES_OR_WC_FLAG");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.FLOW].Value = out_node.GetList(0)[i].GetString("FLOW");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.FLOW_SEQ_NUM].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.OPER].Value = out_node.GetList(0)[i].GetString("OPER");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.OPER_DESC].Value = out_node.GetList(0)[i].GetString("OPER_DESC");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.SEQ_NUM].Value = out_node.GetList(0)[i].GetInt("SEQ_NUM");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MAIN_FLAG].Value = out_node.GetList(0)[i].GetChar("MAIN_FLAG");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MOLD_GROUP_ID].Value = out_node.GetList(0)[i].GetString("MOLD_GROUP_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORDER_TYPE].Value = out_node.GetList(0)[i].GetString("ORDER_TYPE");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.LOT_TYPE].Value = out_node.GetList(0)[i].GetChar("LOT_TYPE");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.OWNER_CODE].Value = out_node.GetList(0)[i].GetString("OWNER_CODE");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.CREATE_CODE].Value = out_node.GetList(0)[i].GetString("CREATE_CODE");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_PRIORITY].Value = out_node.GetList(0)[i].GetChar("ORD_PRIORITY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORG_DUE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ORG_DUE_TIME"));
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_STS].Value = out_node.GetList(0)[i].GetChar("ORD_STATUS_FLAG");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.PLAN_START_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("PLAN_START_TIME"));
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.PLAN_END_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("PLAN_END_TIME"));
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.SCRAP_QTY].Value = out_node.GetList(0)[i].GetString("SCRAP_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.NO_LOSS_QTY].Value = out_node.GetList(0)[i].GetString("NO_LOSS_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.REWORK_QTY].Value = out_node.GetList(0)[i].GetString("REWORK_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.SUSP_LOT_ID].Value = out_node.GetList(0)[i].GetString("SUSPEND_LOT_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.SUSP_QTY].Value = out_node.GetList(0)[i].GetDouble("SUSPEND_QTY");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.SUSP_MAT_ID].Value = out_node.GetList(0)[i].GetString("SUSPEND_MAT_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.SUSP_MAT_VER].Value = out_node.GetList(0)[i].GetInt("SUSPEND_MAT_VER");

                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.WORK_DATE_RAW].Value = out_node.GetList(0)[i].GetString("WORK_DATE");


                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.PALLET_ID].Value = out_node.GetList(0)[i].GetString("ODU_CMF_1");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.CUST_SNP].Value = out_node.GetList(0)[i].GetString("ODU_CMF_2");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.CUST_MAT_ID].Value = out_node.GetList(0)[i].GetString("ODU_CMF_3");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.CUST_ID].Value = out_node.GetList(0)[i].GetString("ODU_CMF_4");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.PALLET_DESC].Value = out_node.GetList(0)[i].GetString("PALLET_DESC");


                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_CMF_3].Value = out_node.GetList(0)[i].GetString("ORD_CMF_3");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_CMF_4].Value = out_node.GetList(0)[i].GetString("ORD_CMF_4");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_CMF_5].Value = out_node.GetList(0)[i].GetString("ORD_CMF_5");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_CMF_6].Value = out_node.GetList(0)[i].GetString("ORD_CMF_6");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_CMF_7].Value = out_node.GetList(0)[i].GetString("ORD_CMF_7");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_CMF_8].Value = out_node.GetList(0)[i].GetString("ORD_CMF_8");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_CMF_9].Value = out_node.GetList(0)[i].GetString("ORD_CMF_9");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORD_CMF_10].Value = out_node.GetList(0)[i].GetString("ORD_CMF_10");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_1].Value = out_node.GetList(0)[i].GetString("ODU_CMF_1");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_2].Value = out_node.GetList(0)[i].GetString("ODU_CMF_2");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_3].Value = out_node.GetList(0)[i].GetString("ODU_CMF_3");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_4].Value = out_node.GetList(0)[i].GetString("ODU_CMF_4");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_5].Value = out_node.GetList(0)[i].GetString("ODU_CMF_5");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_6].Value = out_node.GetList(0)[i].GetString("ODU_CMF_6");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_7].Value = out_node.GetList(0)[i].GetString("ODU_CMF_7");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_8].Value = out_node.GetList(0)[i].GetString("ODU_CMF_8");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_9].Value = out_node.GetList(0)[i].GetString("ODU_CMF_9");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ODU_CMF_10].Value = out_node.GetList(0)[i].GetString("ODU_CMF_10");

                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.USE_FACTORY_DESC].Value = out_node.GetList(0)[i].GetString("USE_FACTORY_DESC");

                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.PRINT_QTY].Value = out_node.GetList(0)[i].GetInt("PRINT_QTY");

                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MOLD_ID].Value = out_node.GetList(0)[i].GetString("MOLD_ID");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.CAVITY].Value = out_node.GetList(0)[i].GetInt("CAVITY");

                    //sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MOLD_GROUP_ID].Value = out_node.GetList(0)[i].GetString("MOLD_GROUP_ID");
                    //sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MOLD_ID].Value = out_node.GetList(0)[i].GetString("TOOL_ID");
                    //sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.CAVITY].Value = out_node.GetList(0)[i].GetString("TOOL_STS_2");
                    //sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.CUR_MOLD_GRP].Value = out_node.GetList(0)[i].GetString("TOOL_STS_1");
                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.RES_STS].Value = out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG");

                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("SUSPEND_LOT_ID")) != "")
                    {
                        if ((out_node.GetList(0)[i].GetString("MAT_ID").Equals(out_node.GetList(0)[i].GetString("SUSPEND_MAT_ID")) == false) ||
                        (out_node.GetList(0)[i].GetInt("MAT_VER") != out_node.GetList(0)[i].GetInt("SUSPEND_MAT_VER")))
                        {
                            sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Navy;
                            sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].BackColor = Color.Orange;
                        }
                    }

                    if (out_node.GetList(0)[i].GetChar("RES_UP_DOWN_FLAG") == 'D')
                    {
                        sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Navy;
                        sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.ORDER_ID, iRow, sheetX.ColumnCount - 1].BackColor = Color.LightSalmon;
                    }

                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.START_TIME_RAW].Value = out_node.GetList(0)[i].GetString("START_TIME");

                    sheetX.Cells[iRow, (int)CSGC.ORD_USR_LIST.MAT_GRP_2].Value = out_node.GetList(0)[i].GetString("MAT_GRP_2");
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #endregion

        #region " VIEW INV LOT SET LIST FUNCTIONS "

        #region " ShowInvLotSetDetail "

        //
        // ShowInvLotSetDetail()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step

        public static bool ShowInvLotSetDetail(FarPoint.Win.Spread.FpSpread spdList, bool bShow)
        {
            return ShowInvLotSetDetail(spdList, bShow, false);
        }
        public static bool ShowInvLotSetDetail(FarPoint.Win.Spread.FpSpread spdList, bool bShow, bool bSec)
        {
            try
            {
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.RES_ID].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.INV_SEQ].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.INPUT_TYPE].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.FINAL_MAT_ID].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.FINAL_MAT_DESC].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.MAT_ID].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.MAT_DESC].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.RAW_MAT_DESC].Visible = bShow;
                //if (!bSec)
                //{
                //    spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.SEQUENCER_SET_ID].Visible = bShow;
                //}

                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.SET_RAW_MAT_ID].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.STD_USAGE].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.QTY].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.PROC_QTY].Visible = bShow;
                ////spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CURRENT_QTY].Visible = bShow;                
                ////spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.SILK_POS_LIST].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.SILK_POS_LIST].Visible = false;

                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.SET_SILK_POS_LIST].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.LAST_SET_SEQ].Visible = bShow;
                ////spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.OLD_INV_LOT_ID].Visible = bShow;
                ////spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.REMAIN_QTY].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.REMAIN_QTY_RAW].Visible = bShow;

                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.MAKER_1].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.MAKER_2].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.MAKER_3].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.MAKER_4].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.LOT_VENDOR_ID].Visible = bShow;

                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_1].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_2].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_3].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_4].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_5].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_6].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_7].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_8].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_9].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_10].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_11].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_12].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_13].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_14].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_15].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_16].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_17].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_18].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_19].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CMF_20].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CREATE_USER_ID].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.CREATE_TIME].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.UPDATE_USER_ID].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.UPDATE_TIME].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.FACTORY].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.LINE_ID].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.IUD_FLAG].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.NO_BOM_FLAG].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.BOM_VERSION].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.LINE_BOM_VERSION].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.SET_BOM_VERSION].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.SET_LINE_BOM_VERSION].Visible = bShow;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.SQC_SET_SEQ].Visible = bShow;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        #endregion

        #region " SetInvLotSetSpreadColumns "
        //
        // SetInvLotSetSpreadColumns()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step

        public static bool SetInvLotSetSpreadColumns(char cStep, FarPoint.Win.Spread.FpSpread spdList)
        {
            int i;
            string sTemp = string.Empty;
            FarPoint.Win.Spread.CellType.CheckBoxCellType ckCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.LineBorder lineBorder = new FarPoint.Win.LineBorder(System.Drawing.Color.White);

            try
            {
                spdList.ActiveSheet.ColumnCount = 0;
                // spdList.ActiveSheet.ColumnCount = Enum.GetNames(typeof(CSGC.INV_SET)).Length;
                //spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].VerticalAlignment = CellVerticalAlignment.Center;
                //spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].HorizontalAlignment = CellHorizontalAlignment.Left;
                //spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].Locked = true;
                //spdList.ActiveSheet.FrozenColumnCount = 4;

                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.LOC].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.RES_ID].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.SLOT_NO].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.INPUT_TYPE].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.RAW_MAT_ID].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.RAW_MAT_DESC].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;

                //spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.REMAIN_QTY].Locked = false;
                ////spdList.ActiveSheet.Columns[(int)CSGC.INV_SET.REMAIN_QTY].BackColor = Color.White;

                //spdList.ActiveSheet.Columns[0, (int)CSGC.INV_SET.STD_USAGE].BackColor = Color.FromArgb(233, 234, 237);
                //spdList.ActiveSheet.Columns[0, (int)CSGC.INV_SET.STD_USAGE].Border = lineBorder;

                //for (i = 0; i < spdList.ActiveSheet.ColumnCount; i++)
                //{
                //    //sTemp = Enum.GetName(typeof(CSGC.INV_SET), i);

                //    if (sTemp.ToUpper() == "CHECK")
                //    {
                //        sTemp = "Del";

                //        if (cStep == '1')
                //        {
                //            spdList.ActiveSheet.Columns[i].CellType = ckCellType;
                //            spdList.ActiveSheet.Columns[i].Locked = false;
                //            spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                //        }
                //        else
                //        {
                //            spdList.ActiveSheet.Columns[i].Visible = false;
                //        }
                //    }

                //    spdList.ActiveSheet.ColumnHeader.Cells[0, i].Text = CSCF.GenCaptionText(sTemp);

                //    if (sTemp.ToUpper().Contains("QTY") || sTemp.ToUpper().Contains("NUM") || sTemp.ToUpper().Contains("COUNT") ||
                //        sTemp.ToUpper().Contains("STD_USAGE"))
                //    {
                //        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Right;
                //    }
                //    else if (sTemp.ToUpper().Contains("FLAG"))
                //    {
                //        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                //    }
                //    else if (sTemp.ToUpper().Equals("LOC") || sTemp.ToUpper().Contains("SLOT_NO"))
                //    {
                //        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                //    }
                //}

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        #endregion

        #region " ViewInvLotSetList "

        // ViewInvLotSetList()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        public static bool ViewInvLotSetList(char cStep, FarPoint.Win.Spread.FpSpread spdList,
                                             string sMatID, char cInputType, string sLine,
                                             string sResID, string sSlotNo, string sSequencerSetID, string sResLocation,
                                             ref int iMainBomVer)
        {
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");

            MPCF.ClearList(spdList, true);

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("MAT_ID", MPCF.Trim(sMatID));
            in_node.AddString("LINE_ID", MPCF.Trim(sLine));
            in_node.AddString("RES_ID", MPCF.Trim(sResID));
            in_node.AddString("SLOT_NO", MPCF.Trim(sSlotNo));
            in_node.AddString("SEQUENCER_SET_ID", MPCF.Trim(sSequencerSetID));
            in_node.AddChar("INPUT_TYPE", cInputType);
            //in_node.AddChar("COMP_SEQ_FLAG", cCompSqcFlag);
            in_node.AddString("RES_LOCATION", MPCF.Trim(sResLocation));

            do
            {
                if (MPCF.CallService("CUS", "CUS_View_Inv_Lot_Set_Status", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MakeInvLotSetListInfo('1', spdList, ref out_node) == false)
                {
                    return false;
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            iMainBomVer = out_node.GetInt("MAIN_BOM_VERSION");

            MPCF.FitColumnHeader(spdList);
            return true;
        }
        public static bool ViewInvLotSetList(char cStep, FarPoint.Win.Spread.FpSpread spdList,
                                             char cUseSetInfo, string sLine, string sResID, string sResLocation,
                                             ref string sFMatID, ref string sFMatDesc, ref string sModel, ref int iMainBomVer)
        {
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");

            MPCF.ClearList(spdList, true);

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("LINE_ID", MPCF.Trim(sLine));
            in_node.AddString("RES_ID", MPCF.Trim(sResID));
            in_node.AddChar("USE_INV_SET_INFO_FLAG", cUseSetInfo);
            in_node.AddString("RES_LOCATION", MPCF.Trim(sResLocation));

            do
            {
                if (MPCF.CallService("CUS", "CUS_View_Inv_Lot_Set_Status", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MakeInvLotSetListInfo('1', spdList, ref out_node) == false)
                {
                    return false;
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            iMainBomVer = out_node.GetInt("MAIN_BOM_VERSION");
            sFMatID = out_node.GetString("FINAL_MAT_ID");
            sFMatDesc = out_node.GetString("FINAL_MAT_DESC");
            sModel = out_node.GetString("FINAL_MAT_MODEL");

            MPCF.FitColumnHeader(spdList);
            return true;
        }

        // ViewInvLotSetListByLine()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        // ViewInvLotSetListByLine()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        public static bool ViewInvLotSetListByLine(char cStep, FarPoint.Win.Spread.FpSpread spdList, char cSkipBOMEmtpy, string sLine,
                                                   string sMatID, ref int iMainBomVer)
        {
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");

            MPCF.ClearList(spdList, true);

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("LINE_ID", MPCF.Trim(sLine));
            in_node.AddString("MAT_ID", MPCF.Trim(sMatID));
            in_node.AddChar("SET_BASE_FLAG", 'N');
            in_node.AddChar("SKIP_BOM_EMPTY", cSkipBOMEmtpy);
            //in_node.AddString("RES_ID", MPCF.Trim(sResID));

            do
            {
                if (MPCF.CallService("CUS", "CUS_View_Inv_Lot_Set_Status_By_Set", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MakeInvLotSetListInfo('1', spdList, ref out_node) == false)
                {
                    return false;
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            iMainBomVer = out_node.GetInt("MAIN_BOM_VERSION");

            MPCF.FitColumnHeader(spdList);
            return true;
        }
        public static bool ViewInvLotSetListByLine(char cStep, FarPoint.Win.Spread.FpSpread spdList, char cSkipBOMEmtpy, string sLine,
                                             ref string sFinalMatID, ref string sFinalMatDesc, ref string sFinalMatModel,
                                             ref string sMatID, ref int iMainBomVer)
        {
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");

            MPCF.ClearList(spdList, true);

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("LINE_ID", MPCF.Trim(sLine));
            in_node.AddChar("SET_BASE_FLAG", 'Y');
            in_node.AddChar("SKIP_BOM_EMPTY", cSkipBOMEmtpy);
            //in_node.AddString("RES_ID", MPCF.Trim(sResID));

            do
            {
                if (MPCF.CallService("CUS", "CUS_View_Inv_Lot_Set_Status_By_Set", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MakeInvLotSetListInfo('1', spdList, ref out_node) == false)
                {
                    return false;
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            sFinalMatID = out_node.GetString("FINAL_MAT_ID");
            sFinalMatDesc = out_node.GetString("FINAL_MAT_DESC");
            sFinalMatModel = out_node.GetString("FINAL_MAT_MODEL");
            sMatID = out_node.GetString("MAT_ID");
            iMainBomVer = out_node.GetInt("MAIN_BOM_VERSION");

            MPCF.FitColumnHeader(spdList);
            return true;
        }

        #endregion

        #region " MakeInvLotSetListInfo "

        public static bool MakeInvLotSetListInfo(char cStep,
                              FarPoint.Win.Spread.FpSpread spdList,
                              ref TRSNode out_node)
        {
            return MakeInvLotSetListInfo(cStep, spdList, ref out_node, true);
        }

        public static bool MakeInvLotSetListInfo(char cStep,
                              FarPoint.Win.Spread.FpSpread spdList,
                              ref TRSNode out_node, bool bClearList)
        {
            FarPoint.Win.Spread.SheetView sheetX = spdList.ActiveSheet;
            int i, iRow;

            double dQty;
            double dCVQty;
            double dProcQty;
            double dRemainQty;

            bool bValid;

            try
            {
                if (bClearList == true)
                {
                    MPCF.ClearList(spdList);
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = sheetX.RowCount;
                    sheetX.RowCount++;
                    sheetX.Rows[iRow].Height = CSGC.SPREAD_RAW_HEIGHT_OI;

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.LOC].Value = out_node.GetList(0)[i].GetString("RES_LOCATION");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.SLOT_NO].Value = out_node.GetList(0)[i].GetString("SLOT_NO");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.INV_SEQ].Value = out_node.GetList(0)[i].GetInt("INV_SEQ");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.INPUT_TYPE].Value = out_node.GetList(0)[i].GetChar("INPUT_TYPE");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.FINAL_MAT_ID].Value = out_node.GetList(0)[i].GetString("FINAL_MAT_ID");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.FINAL_MAT_DESC].Value = out_node.GetList(0)[i].GetString("FINAL_MAT_DESC");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.RAW_MAT_ID].Value = out_node.GetList(0)[i].GetString("INV_MAT_ID");

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.SET_RAW_MAT_ID].Value = out_node.GetList(0)[i].GetString("SET_INV_MAT_ID");


                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.RAW_MAT_DESC].Value = out_node.GetList(0)[i].GetString("INV_MAT_DESC");
                    //if (MPCF.Trim(out_node.GetList(0)[i].GetString("SEQUENCER_SET_ID")) == "")
                    //{
                    //    //sheetX.Cells[iRow, (int)CSGC.INV_SET.SEQUENCER_SET_ID].Value = "NOSQC";
                    //}
                    //else
                    //{
                    //    sheetX.Cells[iRow, (int)CSGC.INV_SET.SEQUENCER_SET_ID].Value = out_node.GetList(0)[i].GetString("SEQUENCER_SET_ID");
                    //}

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.RAW_LOT_ID].Value = out_node.GetList(0)[i].GetString("INV_LOT_ID");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.STD_USAGE].Value = out_node.GetList(0)[i].GetDouble("STD_USAGE");

                    //dQty = out_node.GetList(0)[i].GetDouble("QTY");
                    //dCVQty = out_node.GetList(0)[i].GetDouble("CV_QTY");
                    //dProcQty = out_node.GetList(0)[i].GetDouble("PROC_QTY");

                    //if (dCVQty > 0)
                    //{
                    //    if (dCVQty >= dProcQty)
                    //    {
                    //        dRemainQty = dCVQty - dProcQty;
                    //    }
                    //    else
                    //    {
                    //        dRemainQty = 0;
                    //    }
                    //}
                    //else
                    //{
                    //    if (dQty >= dProcQty)
                    //    {
                    //        dRemainQty = dQty - dProcQty;
                    //    }
                    //    else
                    //    {
                    //        dRemainQty = 0;
                    //    }
                    //}

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.QTY].Value = dQty;
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CURRENT_QTY].Value = dRemainQty;

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.REMAIN_QTY].Value = dRemainQty;
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.REMAIN_QTY_RAW].Value = dRemainQty;

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.PROC_QTY].Value = dProcQty;
                    ////sheetX.Cells[iRow, (int)CSGC.INV_SET.LOSS_QTY].Value = out_node.GetList(0)[i].GetDouble("LOSS_QTY");

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.SILK_POS_LIST].Value = out_node.GetList(0)[i].GetString("SILK_POS_LIST");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.SET_SILK_POS_LIST].Value = out_node.GetList(0)[i].GetString("SET_SILK_POS_LIST");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.LAST_SET_SEQ].Value = out_node.GetList(0)[i].GetInt("LAST_SET_SEQ");

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.OLD_RAW_LOT_ID].Value = out_node.GetList(0)[i].GetString("INV_LOT_ID");

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.LOT_VENDOR_ID].Value = out_node.GetList(0)[i].GetString("LOT_VENDOR_ID");

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_1].Value = out_node.GetList(0)[i].GetString("MAKER_1");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_2].Value = out_node.GetList(0)[i].GetString("MAKER_2");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_3].Value = out_node.GetList(0)[i].GetString("MAKER_3");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_4].Value = out_node.GetList(0)[i].GetString("MAKER_4");

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_1].Value = out_node.GetList(0)[i].GetString("CMF_1");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_2].Value = out_node.GetList(0)[i].GetString("CMF_2");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_3].Value = out_node.GetList(0)[i].GetString("CMF_3");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_4].Value = out_node.GetList(0)[i].GetString("CMF_4");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_5].Value = out_node.GetList(0)[i].GetString("CMF_5");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_6].Value = out_node.GetList(0)[i].GetString("CMF_6");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_7].Value = out_node.GetList(0)[i].GetString("CMF_7");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_8].Value = out_node.GetList(0)[i].GetString("CMF_8");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_9].Value = out_node.GetList(0)[i].GetString("CMF_9");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_10].Value = out_node.GetList(0)[i].GetString("CMF_10");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_11].Value = out_node.GetList(0)[i].GetString("CMF_11");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_12].Value = out_node.GetList(0)[i].GetString("CMF_12");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_13].Value = out_node.GetList(0)[i].GetString("CMF_13");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_14].Value = out_node.GetList(0)[i].GetString("CMF_14");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_15].Value = out_node.GetList(0)[i].GetString("CMF_15");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_16].Value = out_node.GetList(0)[i].GetString("CMF_16");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_17].Value = out_node.GetList(0)[i].GetString("CMF_17");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_18].Value = out_node.GetList(0)[i].GetString("CMF_18");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_19].Value = out_node.GetList(0)[i].GetString("CMF_19");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CMF_20].Value = out_node.GetList(0)[i].GetString("CMF_20");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CREATE_USER_ID].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.CREATE_TIME].Value = out_node.GetList(0)[i].GetString("CREATE_TIME");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.UPDATE_USER_ID].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.UPDATE_TIME].Value = out_node.GetList(0)[i].GetString("UPDATE_TIME");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.FACTORY].Value = out_node.GetList(0)[i].GetString("FACTORY");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.LINE_ID].Value = out_node.GetList(0)[i].GetString("LINE_ID");

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.NO_BOM_FLAG].Value = out_node.GetList(0)[i].GetChar("NO_BOM_FLAG");

                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.BOM_VERSION].Value = out_node.GetList(0)[i].GetInt("BOM_VERSION");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.LINE_BOM_VERSION].Value = out_node.GetList(0)[i].GetInt("LINE_BOM_VERSION");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.SET_BOM_VERSION].Value = out_node.GetList(0)[i].GetInt("SET_BOM_VERSION");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.SET_LINE_BOM_VERSION].Value = out_node.GetList(0)[i].GetInt("SET_LINE_BOM_VERSION");

                    ////sheetX.Cells[iRow, (int)CSGC.INV_SET.SQC_SET_SEQ].Value = out_node.GetList(0)[i].GetInt("SQC_SET_SEQ");
                    //sheetX.Cells[iRow, (int)CSGC.INV_SET.SQC_SET_SEQ].Value = MPCF.ToInt(out_node.GetList(0)[i].GetString("CMF_1"));

                    //bValid = false;

                    //CSCF.CheckVendor(spdList, iRow, MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_VENDOR_ID")), ref bValid, true);

                    //if (bValid == false)
                    //{
                    //    sheetX.Cells[iRow, (int)CSGC.INV_SET.SLOT_NO, iRow, sheetX.ColumnCount - 1].BackColor = Color.FromArgb(197, 217, 241);
                    //}

                    //if (out_node.GetList(0)[i].GetChar("NO_BOM_FLAG") == 'Y')
                    //{
                    //    sheetX.Cells[iRow, (int)CSGC.INV_SET.SLOT_NO, iRow, sheetX.ColumnCount - 1].BackColor = Color.FromArgb(230, 184, 183);
                    //}
                    //else if (MPCF.Trim(out_node.GetList(0)[i].GetString("SET_INV_MAT_ID")) != "" &&
                    //     out_node.GetList(0)[i].GetString("INV_MAT_ID").Equals(out_node.GetList(0)[i].GetString("SET_INV_MAT_ID")) == false)
                    //{
                    //    sheetX.Cells[iRow, (int)CSGC.INV_SET.SLOT_NO, iRow, sheetX.ColumnCount - 1].BackColor = Color.FromArgb(197, 217, 241);
                    //}
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #endregion

        #region " SendCOMData "

        //public static bool SendCOMData(string sDataType, string sString)
        //{
        //    int iPortNo;
        //    int iBaudWidth;
        //    int iDataBit;
        //    int iStopBit;
        //    int iParity;
        //    Rs232 aComPort = new Rs232();
        //    try
        //    {
        //        iPortNo = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "COM" + sDataType, "PortNo"));
        //        iBaudWidth = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "COM" + sDataType, "BaudWidth"));
        //        iDataBit = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "COM" + sDataType, "DataBit"));
        //        iStopBit = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "COM" + sDataType, "StopBit"));
        //        iParity = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "COM" + sDataType, "Parity"));

        //        modPOPPrint.ComPortOpen(ref aComPort, iPortNo, iBaudWidth, iParity, iDataBit, iStopBit);
        //        aComPort.Write(sString);
        //        modPOPPrint.ComPortClose(aComPort);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        return false;
        //    }
        //}

        public static bool SendCOMData(string sDataType, string sString)
        {
            int iPortNo;
            int iBaudWidth;
            int iDataBit;
            int iStopBit;
            int iParity;
            Rs232 aComPort = new Rs232();
            TRSNode com_node = new TRSNode("COM_SETTING");
            try
            {
                CSCF.GetGCMAttributData(com_node, "COM_PORT_TYPE", sDataType);
                iPortNo = MPCF.ToInt(com_node.GetString("PortNumber"));
                iBaudWidth = MPCF.ToInt(com_node.GetString("BaudRate"));
                iDataBit = MPCF.ToInt(com_node.GetString("DataBit"));

                if (com_node.GetString("StopBit") == "Stop Bit 0")
                    iStopBit = 0;
                else if (com_node.GetString("StopBit") == "Stop Bit 1")
                    iStopBit = 1;
                else if (com_node.GetString("StopBit") == "Stop Bit 2")
                    iStopBit = 2;
                else
                    iStopBit = 1;

                if (com_node.GetString("Parity") == "None")
                    iParity = 0;
                else if (com_node.GetString("Parity") == "Odd")
                    iParity = 1;
                else if (com_node.GetString("Parity") == "Even")
                    iParity = 2;
                else
                    iParity = 3;


                if (modPOPPrint.ComPortOpen(ref aComPort, iPortNo, iBaudWidth, iParity, iDataBit, iStopBit) == false)
                    return false;

                aComPort.Write(sString);

                if (modPOPPrint.ComPortClose(aComPort) == false)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #region " ViewMaterialModelInfo "

        public static bool ViewMaterialModelInfo(char cStep,
                                                 string sMatID,
                                                 int iMatVer,
                                                 ref TRSNode MAT)
        {
            TRSNode in_node = new TRSNode("VIEW_IN");
            TRSNode out_node = new TRSNode("VIEW_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cStep;

                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);

                MAT = null;

                if (MPCF.CallService("CUS", "CUS_View_Material_Model_Info", in_node, ref out_node) == false)
                {
                    MAT = null;

                    return false;
                }

                MAT = out_node;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        #endregion

        #region " SetInNodeForLabel "

        public static bool SetInNodeForLabel(char cStep, ref TRSNode MAT, ref TRSNode in_node)
        {
            int i;
            int iThreadTime = 0;
            int iThreadCount = 0;

            TRSNode listItem;

            string sSysTime = string.Empty;

            char cTemp = ' ';

            try
            {
                sSysTime = MAT.GetString("SYS_TIME");

                if (cStep == 'L')
                {
                    in_node.SetString("CUSTOMER_MAT_ID_NH", MAT.GetString("CUSTOMER_MAT_ID").Replace("-", ""));
                    in_node.SetString("CUSTOMER_MAT_ID", MAT.GetString("CUSTOMER_MAT_ID"));

                    in_node.SetString("BARCODE_GEN_ID", MAT.GetString("BARCODE_GEN_ID"));
                    in_node.SetString("LOT_GEN_ID", MAT.GetString("LOT_GEN_ID"));
                    in_node.SetString("LABEL_ID", MAT.GetString("LABEL_ID"));
                    in_node.SetString("LABEL_CODE_1", MAT.GetString("LABEL_CODE_1"));
                    in_node.SetInt("ARG_COUNT", MAT.GetInt("ARG_COUNT"));

                    if (MPCF.CheckNumeric(MAT.GetString("LABEL_CMF_4")) == true)
                    {
                        iThreadCount = MPCF.ToInt(MAT.GetString("LABEL_CMF_4"));
                    }
                    else
                    {
                        iThreadCount = CSGC.MP_DEFAULT_COUNT_FOR_SLEEP;
                    }

                    if (MPCF.CheckNumeric(MAT.GetString("LABEL_CMF_5")) == true)
                    {
                        iThreadTime = MPCF.ToInt(MAT.GetString("LABEL_CMF_5"));
                    }
                    else
                    {
                        iThreadTime = CSGC.MP_DEFAULT_SLEEP_TIME;
                    }

                    for (i = 0; i < MAT.GetList("LABEL_AGR").Count; i++)
                    {
                        listItem = in_node.AddNode("LABEL_AGR");
                        listItem.AddString("DATA", MAT.GetList("LABEL_AGR")[i].GetString("DATA"));
                    }

                }
                else if (cStep == 'B')
                {
                    in_node.SetString("CUSTOMER_MAT_ID_NH", MAT.GetString("CUSTOMER_MAT_ID").Replace("-", ""));
                    in_node.SetString("CUSTOMER_MAT_ID", MAT.GetString("CUSTOMER_MAT_ID"));

                    in_node.SetString("BARCODE_GEN_ID", MAT.GetString("BOX_BARCODE_GEN_ID"));
                    in_node.SetString("LOT_GEN_ID", MAT.GetString("BOX_LOT_GEN_ID"));
                    in_node.SetString("LABEL_ID", MAT.GetString("BOX_LABEL_ID"));
                    in_node.SetString("LABEL_CODE_1", MAT.GetString("BOX_LABEL_CODE_1"));
                    in_node.SetInt("ARG_COUNT", MAT.GetInt("BOX_ARG_COUNT"));

                    if (MPCF.CheckNumeric(MAT.GetString("BOX_LABEL_CMF_4")) == true)
                    {
                        iThreadCount = MPCF.ToInt(MAT.GetString("BOX_LABEL_CMF_4"));
                    }
                    else
                    {
                        iThreadCount = CSGC.MP_DEFAULT_COUNT_FOR_SLEEP;
                    }

                    if (MPCF.CheckNumeric(MAT.GetString("BOX_LABEL_CMF_5")) == true)
                    {
                        iThreadTime = MPCF.ToInt(MAT.GetString("BOX_LABEL_CMF_5"));
                    }
                    else
                    {
                        iThreadTime = CSGC.MP_DEFAULT_SLEEP_TIME;
                    }

                    for (i = 0; i < MAT.GetList("BOX_LABEL_AGR").Count; i++)
                    {
                        listItem = in_node.AddNode("LABEL_AGR");
                        listItem.AddString("DATA", MAT.GetList("BOX_LABEL_AGR")[i].GetString("DATA"));
                    }
                }
                else
                {
                    in_node.SetString("CUSTOMER_MAT_ID_NH", MAT.GetString("CUSTOMER_MAT_ID").Replace("-", ""));
                    in_node.SetString("CUSTOMER_MAT_ID", MAT.GetString("CUSTOMER_MAT_ID"));

                    in_node.SetString("BARCODE_GEN_ID", MAT.GetString("SECONDARY_BARCODE_GEN_ID"));
                    //in_node.SetString("LOT_GEN_ID", MAT.GetString("LOT_GEN_ID"));
                    in_node.SetString("LABEL_ID", MAT.GetString("SECONDARY_LABEL_ID"));
                    in_node.SetString("LABEL_CODE_1", MAT.GetString("SECONDARY_LABEL_CODE_1"));
                    in_node.SetInt("ARG_COUNT", MAT.GetInt("SECONDARY_ARG_COUNT"));

                    if (MPCF.CheckNumeric(MAT.GetString("SECONDARY_LABEL_CMF_4")) == true)
                    {
                        iThreadCount = MPCF.ToInt(MAT.GetString("SECONDARY_LABEL_CMF_4"));
                    }
                    else
                    {
                        iThreadCount = CSGC.MP_DEFAULT_COUNT_FOR_SLEEP;
                    }

                    if (MPCF.CheckNumeric(MAT.GetString("SECONDARY_LABEL_CMF_5")) == true)
                    {
                        iThreadTime = MPCF.ToInt(MAT.GetString("SECONDARY_LABEL_CMF_5"));
                    }
                    else
                    {
                        iThreadTime = CSGC.MP_DEFAULT_SLEEP_TIME;
                    }

                    for (i = 0; i < MAT.GetList("SECONDARY_LABEL_AGR").Count; i++)
                    {
                        listItem = in_node.AddNode("LABEL_AGR");
                        listItem.AddString("DATA", MAT.GetList("SECONDARY_LABEL_AGR")[i].GetString("DATA"));
                    }

                }

                in_node.SetInt("COUNT_FOR_SLEEP", iThreadCount);
                in_node.SetInt("SLEEP_TIME", iThreadTime);

                if (MAT.GetInt("LOT_QTY") > 0)
                {
                    in_node.SetString("PACK_LOT_COUNT_STR", MAT.GetInt("LOT_QTY").ToString());
                    in_node.SetString("BOX_QTY_4", MAT.GetInt("LOT_QTY").ToString("0000"));
                    in_node.SetString("BOX_QTY_5", MAT.GetInt("LOT_QTY").ToString("00000"));
                    in_node.SetString("BOX_QTY_6", MAT.GetInt("LOT_QTY").ToString("000000"));
                }
                else
                {
                    in_node.SetString("PACK_LOT_COUNT_STR", MAT.GetInt("PACK_LOT_COUNT").ToString());
                    in_node.SetString("BOX_QTY_4", MAT.GetInt("PACK_LOT_COUNT").ToString("0000"));
                    in_node.SetString("BOX_QTY_5", MAT.GetInt("PACK_LOT_COUNT").ToString("00000"));
                    in_node.SetString("BOX_QTY_6", MAT.GetInt("PACK_LOT_COUNT").ToString("000000"));
                }


                in_node.SetString("DIMENSION_HR_STR", MAT.GetDouble("DIMENSION_HR").ToString());
                in_node.SetString("WEIGHT_GROSS_STR", MAT.GetDouble("WEIGHT_GROSS").ToString());

                in_node.SetString("DATE_STR", sSysTime.Substring(0, 4) + "." +
                                              sSysTime.Substring(4, 2) + "." +
                                              sSysTime.Substring(6, 2));

                in_node.SetString("DATE_STR_YY", sSysTime.Substring(2, 2) + "/" +
                                              sSysTime.Substring(4, 2) + "/" +
                                              sSysTime.Substring(6, 2));

                in_node.SetString("YYWW", sSysTime.Substring(2, 2) + MAT.GetString("SYS_WEEK"));
                in_node.SetString("W_YYWW", "W" + sSysTime.Substring(2, 2) + MAT.GetString("SYS_WEEK"));

                cTemp = (char)(MPCF.ToInt(sSysTime.Substring(0, 4)) - 2008 + 64);
                in_node.SetString("W_YWW", "W" + cTemp.ToString() + MAT.GetString("SYS_WEEK"));



                //s_year[0] = (char)(i_temp - 2008 + 64);	

                in_node.SetString("FACTORY", MAT.GetString("FACTORY"));
                in_node.SetString("MAT_ID", MAT.GetString("MAT_ID"));
                in_node.SetInt("MAT_VER", MAT.GetInt("MAT_VER"));
                in_node.SetString("MAT_DESC", MAT.GetString("MAT_DESC"));
                in_node.SetString("MAT_TYPE", MAT.GetString("MAT_TYPE"));
                in_node.SetString("MAT_GRP_1", MAT.GetString("MAT_GRP_1"));
                in_node.SetString("MAT_GRP_2", MAT.GetString("MAT_GRP_2"));
                in_node.SetString("MAT_GRP_3", MAT.GetString("MAT_GRP_3"));
                in_node.SetString("MAT_GRP_4", MAT.GetString("MAT_GRP_4"));
                in_node.SetString("MAT_GRP_5", MAT.GetString("MAT_GRP_5"));
                in_node.SetString("MAT_GRP_6", MAT.GetString("MAT_GRP_6"));
                in_node.SetString("MAT_GRP_7", MAT.GetString("MAT_GRP_7"));
                in_node.SetString("MAT_GRP_8", MAT.GetString("MAT_GRP_8"));
                in_node.SetString("MAT_GRP_9", MAT.GetString("MAT_GRP_9"));
                in_node.SetString("MAT_GRP_10", MAT.GetString("MAT_GRP_10"));
                in_node.SetString("MAT_CMF_1", MAT.GetString("MAT_CMF_1"));
                in_node.SetString("MAT_CMF_2", MAT.GetString("MAT_CMF_2"));
                in_node.SetString("MAT_CMF_3", MAT.GetString("MAT_CMF_3"));
                in_node.SetString("MAT_CMF_4", MAT.GetString("MAT_CMF_4"));
                in_node.SetString("MAT_CMF_5", MAT.GetString("MAT_CMF_5"));
                in_node.SetString("MAT_CMF_6", MAT.GetString("MAT_CMF_6"));
                in_node.SetString("MAT_CMF_7", MAT.GetString("MAT_CMF_7"));
                in_node.SetString("MAT_CMF_8", MAT.GetString("MAT_CMF_8"));
                in_node.SetString("MAT_CMF_9", MAT.GetString("MAT_CMF_9"));
                in_node.SetString("MAT_CMF_10", MAT.GetString("MAT_CMF_10"));
                in_node.SetString("MAT_CMF_11", MAT.GetString("MAT_CMF_11"));
                in_node.SetString("MAT_CMF_12", MAT.GetString("MAT_CMF_12"));
                in_node.SetString("MAT_CMF_13", MAT.GetString("MAT_CMF_13"));
                in_node.SetString("MAT_CMF_14", MAT.GetString("MAT_CMF_14"));
                in_node.SetString("MAT_CMF_15", MAT.GetString("MAT_CMF_15"));
                in_node.SetString("MAT_CMF_16", MAT.GetString("MAT_CMF_16"));
                in_node.SetString("MAT_CMF_17", MAT.GetString("MAT_CMF_17"));
                in_node.SetString("MAT_CMF_18", MAT.GetString("MAT_CMF_18"));
                in_node.SetString("MAT_CMF_19", MAT.GetString("MAT_CMF_19"));
                in_node.SetString("MAT_CMF_20", MAT.GetString("MAT_CMF_20"));
                in_node.SetString("FIRST_FLOW", MAT.GetString("FIRST_FLOW"));
                in_node.SetInt("FIRST_FLOW_SEQ_NUM", MAT.GetInt("FIRST_FLOW_SEQ_NUM"));
                in_node.SetString("LAST_FLOW", MAT.GetString("LAST_FLOW"));
                in_node.SetInt("LAST_FLOW_SEQ_NUM", MAT.GetInt("LAST_FLOW_SEQ_NUM"));
                in_node.SetString("MFG_DEVISION", MAT.GetString("MFG_DEVISION"));
                in_node.SetChar("SUBCONTRACT_FLAG", MAT.GetChar("SUBCONTRACT_FLAG"));
                in_node.SetString("BASE_MAT_ID", MAT.GetString("BASE_MAT_ID"));
                in_node.SetString("VENDOR_ID", MAT.GetString("VENDOR_ID"));
                in_node.SetString("VENDOR_MAT_ID", MAT.GetString("VENDOR_MAT_ID"));
                in_node.SetString("CUSTOMER_ID", MAT.GetString("CUSTOMER_ID"));
                //in_node.SetString("CUSTOMER_MAT_ID", MAT.GetString("CUSTOMER_MAT_ID"));
                in_node.SetDouble("DEF_QTY_1", MAT.GetDouble("DEF_QTY_1"));
                in_node.SetDouble("DEF_QTY_2", MAT.GetDouble("DEF_QTY_2"));
                in_node.SetDouble("DEF_QTY_3", MAT.GetDouble("DEF_QTY_3"));
                in_node.SetString("UNIT_1", MAT.GetString("UNIT_1"));
                in_node.SetString("UNIT_2", MAT.GetString("UNIT_2"));
                in_node.SetString("UNIT_3", MAT.GetString("UNIT_3"));
                in_node.SetDouble("WEIGHT_NET", MAT.GetDouble("WEIGHT_NET"));
                in_node.SetDouble("WEIGHT_GROSS", MAT.GetDouble("WEIGHT_GROSS"));
                in_node.SetString("WEIGHT_UNIT", MAT.GetString("WEIGHT_UNIT"));
                in_node.SetDouble("VOLUME", MAT.GetDouble("VOLUME"));
                in_node.SetString("VOLUME_UNIT", MAT.GetString("VOLUME_UNIT"));
                in_node.SetDouble("DIMENSION_HR", MAT.GetDouble("DIMENSION_HR"));
                in_node.SetString("DIMENSION_HR_UNIT", MAT.GetString("DIMENSION_HR_UNIT"));
                in_node.SetDouble("DIMENSION_VT", MAT.GetDouble("DIMENSION_VT"));
                in_node.SetString("DIMENSION_VT_UNIT", MAT.GetString("DIMENSION_VT_UNIT"));
                in_node.SetDouble("DIMENSION_HT", MAT.GetDouble("DIMENSION_HT"));
                in_node.SetString("DIMENSION_HT_UNIT", MAT.GetString("DIMENSION_HT_UNIT"));
                in_node.SetString("BOM_SET_ID", MAT.GetString("BOM_SET_ID"));
                in_node.SetString("DEF_INV_OPER", MAT.GetString("DEF_INV_OPER"));
                in_node.SetChar("PACK_TYPE", MAT.GetChar("PACK_TYPE"));
                in_node.SetInt("PACK_LOT_COUNT", MAT.GetInt("PACK_LOT_COUNT"));
                in_node.SetDouble("PACK_QTY", MAT.GetDouble("PACK_QTY"));
                in_node.SetDouble("LE_STOCK_LEVEL", MAT.GetDouble("LE_STOCK_LEVEL"));
                in_node.SetDouble("LW_STOCK_LEVEL", MAT.GetDouble("LW_STOCK_LEVEL"));
                in_node.SetDouble("HW_STOCK_LEVEL", MAT.GetDouble("HW_STOCK_LEVEL"));
                in_node.SetDouble("HE_STOCK_LEVEL", MAT.GetDouble("HE_STOCK_LEVEL"));
                in_node.SetChar("IQC_FLAG", MAT.GetChar("IQC_FLAG"));
                in_node.SetChar("IQC_SAMPLE_FLAG", MAT.GetChar("IQC_SAMPLE_FLAG"));
                in_node.SetChar("IQC_SAMPLE_RULE", MAT.GetChar("IQC_SAMPLE_RULE"));
                in_node.SetChar("OQC_FLAG", MAT.GetChar("OQC_FLAG"));
                in_node.SetChar("OQC_SAMPLE_FLAG", MAT.GetChar("OQC_SAMPLE_FLAG"));
                in_node.SetChar("OQC_SAMPLE_RULE", MAT.GetChar("OQC_SAMPLE_RULE"));
                in_node.SetDouble("TARGET_YIELD", MAT.GetDouble("TARGET_YIELD"));
                in_node.SetDouble("TARGET_DUE_DAY", MAT.GetDouble("TARGET_DUE_DAY"));
                in_node.SetDouble("TARGET_QTY_1", MAT.GetDouble("TARGET_QTY_1"));
                in_node.SetDouble("TARGET_QTY_2", MAT.GetDouble("TARGET_QTY_2"));
                in_node.SetDouble("TARGET_QTY_3", MAT.GetDouble("TARGET_QTY_3"));
                in_node.SetString("APPLY_START_TIME", MAT.GetString("APPLY_START_TIME"));
                in_node.SetString("APPLY_END_TIME", MAT.GetString("APPLY_END_TIME"));
                in_node.SetChar("APPROVAL_FLAG", MAT.GetChar("APPROVAL_FLAG"));
                in_node.SetString("APPROVAL_USER_ID", MAT.GetString("APPROVAL_USER_ID"));
                in_node.SetString("APPROVAL_TIME", MAT.GetString("APPROVAL_TIME"));
                in_node.SetChar("RELEASE_FLAG", MAT.GetChar("RELEASE_FLAG"));
                in_node.SetString("RELEASE_USER_ID", MAT.GetString("RELEASE_USER_ID"));
                in_node.SetString("RELEASE_TIME", MAT.GetString("RELEASE_TIME"));
                in_node.SetChar("DEACTIVE_FLAG", MAT.GetChar("DEACTIVE_FLAG"));
                in_node.SetString("DEACTIVE_USER_ID", MAT.GetString("DEACTIVE_USER_ID"));
                in_node.SetString("DEACTIVE_TIME", MAT.GetString("DEACTIVE_TIME"));
                in_node.SetChar("DELETE_FLAG", MAT.GetChar("DELETE_FLAG"));
                in_node.SetString("DELETE_USER_ID", MAT.GetString("DELETE_USER_ID"));
                in_node.SetString("DELETE_TIME", MAT.GetString("DELETE_TIME"));
                in_node.SetString("CREATE_USER_ID", MAT.GetString("CREATE_USER_ID"));
                in_node.SetString("CREATE_TIME", MAT.GetString("CREATE_TIME"));
                in_node.SetString("UPDATE_USER_ID", MAT.GetString("UPDATE_USER_ID"));
                in_node.SetString("UPDATE_TIME", MAT.GetString("UPDATE_TIME"));
                in_node.SetString("MAT_SHORT_DESC", MAT.GetString("MAT_SHORT_DESC"));

                in_node.SetChar("GROUP_LOT_FLAG", MAT.GetChar("GROUP_LOT_FLAG"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #region " ViewLine "

        // ViewLine()
        //       -  View Rule
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        public static bool ViewLine(char cStep, char cGetFileInfo, string sLineID, ref TRSNode out_node)
        {
            return ViewLine(cStep, cGetFileInfo, 'N', sLineID, " ", ref out_node);
        }
        public static bool ViewLine(char cStep, char cGetFileInfo, string sLineID, string sResID, ref TRSNode out_node)
        {
            return ViewLine(cStep, cGetFileInfo, 'N', sLineID, sResID, ref out_node);
        }
        public static bool ViewLine(char cStep, char cGetFileInfo, char cGetSetInfo, string sLineID, string sResID, ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("VIEW_LINE_IN");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("LINE_ID", MPCF.Trim(sLineID));
            in_node.AddChar("GET_FILE_INFO", cGetFileInfo);
            in_node.AddChar("GET_SET_INFO", cGetSetInfo);
            in_node.AddString("RES_ID", MPCF.Trim(sResID));

            if (MPCF.CallService("CUS", "CUS_View_Line", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region " ViewMaterial List "
        // ViewMaterialList()
        //       - View all Material List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : List媛 ?ㅼ뼱媛?control
        //        - ByVal c_step As String                        : ?뺤옣 Process Step
        //        - Optional ByVal sMaterialType As String = "" : Material Type
        //        - Optional ByVal sFilter As String = ""        : sFilter濡??쒖옉?섎뒗 Material
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?먯꽌 異붽???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?꾩옱 Factory媛 ?꾨땶寃쎌슦?????Factory
        //
        public static bool ViewMaterialList(Control control, char c_step)
        {
            return ViewMaterialList(control, c_step, "", "", ' ', ' ', "", true, null, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, string sMaterialType)
        {
            return ViewMaterialList(control, c_step, sMaterialType, "", ' ', ' ', "", true, null, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, bool bIncludeVersion)
        {
            return ViewMaterialList(control, c_step, "", "", ' ', ' ', "", bIncludeVersion, null, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, string sMaterialType, bool bIncludeVersion)
        {
            return ViewMaterialList(control, c_step, sMaterialType, "", ' ', ' ', "", bIncludeVersion, null, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, TreeNode parentNode)
        {
            return ViewMaterialList(control, c_step, "", "", ' ', ' ', "", true, parentNode, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, bool bIncludeVersion, TreeNode parentNode)
        {
            return ViewMaterialList(control, c_step, "", "", ' ', ' ', "", bIncludeVersion, parentNode, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, string sMaterialType, bool bIncludeVersion, TreeNode parentNode)
        {
            return ViewMaterialList(control, c_step, sMaterialType, "", ' ', ' ', "", bIncludeVersion, parentNode, "");
        }

        public static bool ViewMaterialList(Control control, char c_step, string sMaterialType, string sMatGrp3, char cDeleteFlag, char cDeactiveFlag, string sFilter, bool bIncludeVersion, TreeNode parentNode, string sExtFactory)
        {

            int i;
            int i_cond_cnt;
            string sViewID = string.Empty;
            Boolean bIcon = true;

            DataTable dt = new DataTable();
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            try
            {

                MPCF.ClearList(control);

                i_cond_cnt = 5;

                TPDR.DirectViewCond[] a = new TPDR.DirectViewCond[i_cond_cnt];


                if (MPCF.Trim(sMatGrp3) == "")
                {
                    sViewID = "VL_MAT_003";

                    a[1].sCondtion_ID = "$MAT_ID";
                    if (sFilter == "")
                    {
                        a[1].sCondition_Value = "ALL";
                    }
                    else
                    {
                        a[1].sCondition_Value = MPCF.Trim(sFilter) + "%";
                    }
                }
                else
                {
                    sViewID = "VL_MAT_004";
                    a[1].sCondtion_ID = "$MAT_GRP_3";
                    a[1].sCondition_Value = MPCF.Trim(sMatGrp3);
                }

                a[0].sCondtion_ID = "$FACTORY";
                a[0].sCondition_Value = MPGV.gsFactory;


                a[2].sCondtion_ID = "$MAT_TYPE";
                if (sMaterialType == "")
                {
                    a[2].sCondition_Value = "ALL";
                }
                else
                {
                    a[2].sCondition_Value = MPCF.Trim(sMaterialType);
                }

                a[3].sCondtion_ID = "$DELETE_FLAG";
                if (cDeleteFlag == ' ')
                {
                    a[3].sCondition_Value = "X";
                }
                else
                {
                    a[3].sCondition_Value = MPCF.Trim(cDeleteFlag);
                }

                a[4].sCondtion_ID = "$DEACTIVE_FLAG";
                if (cDeactiveFlag == ' ')
                {
                    a[4].sCondition_Value = "X";
                }
                else
                {
                    a[4].sCondition_Value = MPCF.Trim(cDeactiveFlag);
                }

                if (TPDR.DirectViewOne(control, sViewID, ref dt, bIcon, bIcon, a) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                if (MPCF.Trim(sMatGrp3) != "")
                {
                    ((ListView)control).Columns[0].Width += 10;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
            //TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
            //TRSNode out_node;

            //a_list = new ArrayList();

            //if (control is ListView)
            //{
            //    //MPCF.InitListView((ListView)control);
            //}
            //else if (!(control is TreeView))
            //{
            //    if (!(parentNode == null))
            //    {
            //        parentNode.Nodes.Clear();
            //    }
            //    else
            //    {
            //        MPCF.ClearList(control, true);
            //    }
            //}

            //MPCF.SetInMsg(in_node);
            //in_node.ProcStep = c_step;

            //if (sExtFactory != "")
            //{
            //    in_node.Factory = sExtFactory;
            //}

            //in_node.AddString("MAT_TYPE", sMaterialType);
            //in_node.AddString("FILTER", sFilter);
            //in_node.AddString("NEXT_MAT_ID", "");
            //in_node.AddInt("NEXT_MAT_VER", int.MaxValue);

            //in_node.AddChar("DELETE_FLAG", cDeleteFlag);
            //in_node.AddChar("DEACTIVE_FLAG", cDeactiveFlag);

            //do
            //{
            //    out_node = new TRSNode("VIEW_MATERIAL_LIST_OUT");

            //    if (MPCF.CallService("WIP", "WIP_View_Material_List", in_node, ref out_node) == false)
            //    {
            //        return false;
            //    }

            //    a_list.Add(out_node);

            //    in_node.SetString("NEXT_MAT_ID", out_node.GetString("NEXT_MAT_ID"));
            //    in_node.SetInt("NEXT_MAT_VER", out_node.GetInt("NEXT_MAT_VER"));
            //} while (in_node.GetString("NEXT_MAT_ID") != "");


            //foreach (object obj in a_list)
            //{
            //    out_node = null;
            //    out_node = (TRSNode)obj;

            //    for (i = 0; i < out_node.GetList(0).Count; i++)
            //    {
            //        if (control is ListView)
            //        {
            //            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("MAT_ID"), (int)SMALLICON_INDEX.IDX_MATERIAL);

            //            if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
            //            {
            //                itmX.ForeColor = Color.Magenta;
            //            }
            //            else if (out_node.GetList(0)[i].GetChar("DEACTIVE_FLAG") == 'Y')
            //            {
            //                itmX.ForeColor = Color.Khaki;
            //            }

            //            if (((ListView)control).Columns.Count > 1)
            //            {
            //                if (bIncludeVersion == true)
            //                {
            //                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
            //                }
            //                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_DESC"));
            //            }
            //            ((ListView)control).Items.Add(itmX);
            //        }
            //        else if (control is TreeView)
            //        {
            //            if (bIncludeVersion == true)
            //            {
            //                nodeX = new TreeNode(out_node.GetList(0)[i].GetString("MAT_ID") +
            //                                     " (" + out_node.GetList(0)[i].GetInt("MAT_VER").ToString() + ") : " +
            //                                     out_node.GetList(0)[i].GetString("MAT_DESC"),
            //                                     (int)SMALLICON_INDEX.IDX_MATERIAL,
            //                                     (int)SMALLICON_INDEX.IDX_MATERIAL);
            //                nodeX.Tag = out_node.GetList(0)[i].GetString("MAT_ID") +
            //                                     " (" + out_node.GetList(0)[i].GetInt("MAT_VER").ToString() + ")";

            //                if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
            //                {
            //                    nodeX.ForeColor = Color.Magenta;
            //                }
            //                else if (out_node.GetList(0)[i].GetChar("DEACTIVE_FLAG") == 'Y')
            //                {
            //                    nodeX.ForeColor = Color.Khaki;
            //                }

            //            }
            //            else
            //            {
            //                nodeX = new TreeNode(out_node.GetList(0)[i].GetString("MAT_ID"),
            //                                     (int)SMALLICON_INDEX.IDX_MATERIAL,
            //                                     (int)SMALLICON_INDEX.IDX_MATERIAL);
            //            }

            //            if (!(parentNode == null))
            //            {
            //                parentNode.Nodes.Add(nodeX);
            //            }
            //            else
            //            {
            //                ((TreeView)control).Nodes.Add(nodeX);
            //            }
            //        }
            //        else if (control is ComboBox)
            //        {
            //            if (bIncludeVersion == true)
            //            {
            //                ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("MAT_ID") +
            //                                              " (" + out_node.GetList(0)[i].GetInt("MAT_VER").ToString() + ")");
            //            }
            //            else
            //            {
            //                ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
            //            }
            //        }
            //    }
            //}

            //return true;

        }
        #endregion

        #region " ViewMaterial VersionList "
        // ViewMaterialVersionList()
        //       - View all Material Version List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : List媛 ?ㅼ뼱媛?control
        //        - ByVal c_step As String                        : ?뺤옣 Process Step
        //        - Optional ByVal sMatID As String = "" : Material ID
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?먯꽌 異붽???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?꾩옱 Factory媛 ?꾨땶寃쎌슦?????Factory
        //
        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID)
        {
            return ViewMaterialVersionList(control, c_step, sMatID, "", ' ', ' ', null, "");
        }

        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID, TreeNode parentNode)
        {
            return ViewMaterialVersionList(control, c_step, sMatID, "", ' ', ' ', parentNode, "");
        }

        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID, string sMatType)
        {
            return ViewMaterialVersionList(control, c_step, sMatID, sMatType, ' ', ' ', null, "");
        }

        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID, string sMatType, TreeNode parentNode)
        {
            return ViewMaterialVersionList(control, c_step, sMatID, sMatType, ' ', ' ', parentNode, "");
        }

        public static bool ViewMaterialVersionList(Control control, char c_step, string sMatID, string sMatType, char cDeleteFlag, char cDeactiveFlag, TreeNode parentNode, string sExtFactory)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;

            TRSNode in_node = new TRSNode("VIEW_MATERIAL_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MATERIAL_VERSION_LIST_OUT");

            if (control is ListView)
            {
                //MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                if (!(parentNode == null))
                {
                    parentNode.Nodes.Clear();
                }
                else
                {
                    MPCF.ClearList(control, true);
                }
            }

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }

            in_node.AddString("MAT_ID", sMatID);
            in_node.AddString("MAT_TYPE", sMatType);
            in_node.AddInt("NEXT_MAT_VER", int.MaxValue);

            in_node.AddChar("DELETE_FLAG", cDeleteFlag);
            in_node.AddChar("DEACTIVE_FLAG", cDeactiveFlag);

            do
            {
                if (MPCF.CallService("WIP", "WIP_View_Material_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("MAT_VER").ToString(), (int)SMALLICON_INDEX.IDX_MATERIAL);

                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Magenta;
                        }
                        else if (out_node.GetList(0)[i].GetChar("DEACTIVE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Khaki;
                        }

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_DESC"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("MAT_VER").ToString() + " : " +
                                             out_node.GetList(0)[i].GetString("MAT_DESC"),
                                             (int)SMALLICON_INDEX.IDX_MATERIAL,
                                             (int)SMALLICON_INDEX.IDX_MATERIAL);

                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            nodeX.ForeColor = Color.Magenta;
                        }
                        else if (out_node.GetList(0)[i].GetChar("DEACTIVE_FLAG") == 'Y')
                        {
                            nodeX.ForeColor = Color.Khaki;
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
                        ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                    }
                }

                in_node.SetInt("NEXT_MAT_VER", out_node.GetInt("NEXT_MAT_VER"));
            } while (in_node.GetInt("NEXT_MAT_VER") > 0);

            return true;

        }
        #endregion

        #region " ViewGCMDataList "
        // ViewGCMDataList()
        //       - View General Code Data list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal Form_control As Control                : List媛 ?ㅼ뼱媛?control
        //        - ByVal c_step As String                        : ?뺤옣 Process Step
        //        - ByVal table_name As String                : BAS??Table_name
        //        - Optional ByVal Image_idx As Integer = -1    : List View???ㅼ뼱媛??꾩씠肄??몃뜳??
        //        - Optional ByVal Ext_Factory As String = ""    : ?꾩옱 Factory媛 ?꾨땶寃쎌슦??Factory
        //        - Optional ByVal TreeItem As String = ""    : TreeView ?먯꽌 異붽???Node??Text
        //       - Optional ByVal Col As Integer = -1        : Spread 而⑦듃濡ㅼ씪 寃쎌슦 ?곗씠?瑜?肉뚮젮以?Column Index (-1?대㈃ ?뱀젙 Row ?꾩껜??肉뚮젮以?
        //       - Optional ByVal Row As Integer = -1        : Spread 而⑦듃濡ㅼ씪 寃쎌슦 ?곗씠?瑜?肉뚮젮以?Row Index (-1?대㈃ ?뱀젙 Column ?꾩껜??肉뚮젮以?
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
                //MPCF.InitListView((ListView)Form_control);
            }
            else if (Form_control is FarPoint.Win.Spread.FpSpread && (Col > 0 || Row > 0))
            {
                //Do Nothing
            }
            else if (!(Form_control is TreeView))
            {
                MPCF.ClearList(Form_control, true);
            }

            //if (Form_control is SOICodeView)
            //{
            //    ((SOICodeView)Form_control).GCMTableName = table_name;
            //}
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

            MPCF.SetInMsg(in_node);
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

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node, bIgnoreError) == false)
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

        public static bool ViewGCMDataList(char c_step, string table_name, ref TRSNode out_node, string Ext_Factory, bool bIgnoreError, string[] Argu)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            int i;

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (MPCF.Trim(Ext_Factory) != "")
            {
                in_node.Factory = MPCF.Trim(Ext_Factory);
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

            if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node, bIgnoreError) == false)
            {
                return false;
            }

            return true;

        }

        #endregion

        #region " InitGRPCMFControl "

        //// InitGRPCMFControl()
        ////       - initial Group/Cmf Control
        //// Return Value
        ////       -
        //// Arguments
        ////       - ByVal sLabelName As String            : Label Control Prefix Name
        ////        - ByVal sCodeViewName As String            : CodeView Control Prefix Name
        ////        - ByVal parentControl As Control        : ParentControl
        //public static void InitGRPCMFControl(string sLabelName, string sCheckBoxName, string sCodeViewName, Control parentControl)
        //{
        //    ArrayList controls;
        //    SOICodeView cdvTemp;
        //    int i;

        //    controls = MPCF.GetIndexedControl(sLabelName, parentControl);
        //    for (i = 0; i <= controls.Count - 1; i++)
        //    {
        //        ((Label)controls[i]).Visible = false;
        //        ((Label)controls[i]).Text = "";
        //    }

        //    controls = MPCF.GetIndexedControl(sCheckBoxName, parentControl);
        //    for (i = 0; i <= controls.Count - 1; i++)
        //    {
        //        ((CheckBox)controls[i]).Visible = false;
        //    }

        //    controls = MPCF.GetIndexedControl(sCodeViewName, parentControl);
        //    for (i = 0; i <= controls.Count - 1; i++)
        //    {
        //        cdvTemp = (SOICodeView)controls[i];
        //        cdvTemp.Init();

        //        /* 2013.05.13. Aiden. CMF/GRP 에서 수기 입력이 가능하게 변경.
        //         * 서비스에서 Validation 하고 있고, CMF/GRP Item 이 무지 많은 경우 리스트 가져오는데 오래걸림.
        //         */

        //        cdvTemp.ReadOnly = false;
        //        cdvTemp.VisibleButton = true;
        //        cdvTemp.Visible = false;
        //        cdvTemp.AllowDrop = true;

        //        //MPCF.InitListView(cdvTemp.GetListView);
        //        cdvTemp.Columns.Add("Value", 100, HorizontalAlignment.Left);
        //        cdvTemp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
        //        cdvTemp.SelectedSubItemIndex = 0;
        //    }
        //}

        #endregion

        #region " SetCMFItem "

        public static void SetCMFItem(string sItemName, string sLabelName, string sCheckBoxName, string sCodeViewName, Control parentControl)
        {
            SetCMFItem(sItemName, sLabelName, sCheckBoxName, sCodeViewName, parentControl, "");
        }
        public static void SetCMFItem(string sItemName, string sLabelName, string sCheckBoxName, string sCodeViewName, Control parentControl, string sFactory)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ArrayList lblList;
            ArrayList cdvList;
            ArrayList ckList;
            Label lblTemp;
            CheckBox ckTemp;
            SOICodeView cdvTemp;
            int i;

            try
            {
                //InitGRPCMFControl(sLabelName, sCheckBoxName, sCodeViewName, parentControl);

                //if (ViewFactoryCmfData('1', sItemName, ref out_node, sFactory, true) == false)
                //{
                //    return;
                //}

                //lblList = MPCF.GetIndexedControl(sLabelName, parentControl);
                //cdvList = MPCF.GetIndexedControl(sCodeViewName, parentControl);
                //ckList = MPCF.GetIndexedControl(sCheckBoxName, parentControl);

                //for (i = 0; i < out_node.GetList(0).Count; i++)
                //{
                //    if (i >= cdvList.Count)
                //    {
                //        break;
                //    }

                //    lblTemp = (Label)lblList[i];
                //    cdvTemp = (SOICodeView.MCCodeView)cdvList[i];
                //    ckTemp = (CheckBox)ckList[i];
                //    lblTemp.Text = out_node.GetList(0)[i].GetString("PROMPT");

                //    if (lblTemp.Text != "")
                //    {
                //        if (out_node.GetList(0)[i].GetChar("OPT") == 'Y')
                //        {
                //            lblTemp.Font = new System.Drawing.Font(lblTemp.Font, System.Drawing.FontStyle.Bold);
                //            cdvTemp.AllowDrop = false;
                //        }

                //        cdvTemp.Tag = out_node.GetList(0)[i].GetChar("FORMAT");
                //        cdvTemp.Tag = cdvTemp.Tag + out_node.GetList(0)[i].GetString("TABLE_NAME");
                //        if (out_node.GetList(0)[i].GetString("TABLE_NAME") == "")
                //        {
                //            cdvTemp.VisibleButton = false;
                //            cdvTemp.DisplaySubItemIndex = cdvTemp.SelectedSubItemIndex;
                //        }

                //        lblTemp.Visible = true;
                //        cdvTemp.Visible = true;
                //        ckTemp.Visible = true;

                //        if (out_node.GetList(0)[i].GetString("TABLE_NAME") != "")
                //        {
                //            if (cdvTemp.DisplaySubItemIndex != cdvTemp.SelectedSubItemIndex)
                //            {
                //                BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', out_node.GetList(0)[i].GetString("TABLE_NAME"));
                //            }
                //        }

                //    }
                //}

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        // ViewFactoryCmfData()
        //       - View FACCMF Table Item Data
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String                        : ?뺤옣 Process Step
        //        - ByVal sItemName As String                    : 媛?몄삱 Item Name
        //        - ByRef View_Factory_Cmf_Item_Out As WIP_View_Factory_Cmf_Item_Out_Tag
        //                                                    : 媛?몄삩 Item Data??援ъ“泥?
        //        - Optional ByVal sExtFactory As String = ""    : ?꾩옱 Factory媛 ?꾨땶寃쎌슦
        //
        public static bool ViewFactoryCmfData(char c_step, string sItemName, ref TRSNode out_node, string sExtFactory, bool bIgnoreMessage)
        {

            TRSNode in_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_IN");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (sExtFactory != "")
            {
                in_node.Factory = sExtFactory;
            }
            in_node.AddString("ITEM_NAME", sItemName);

            if (MPCF.CallService("CUS", "CUS_View_Factory_Cmf_Item", in_node, ref out_node, bIgnoreMessage) == false)
            {
                return false;
            }

            return true;
        }


        #endregion

        #region " ProcGRPCMFButtonPress "

        // ProcGRPCMFButtonPress()
        //       - Process Group/Cmf CodeView Button Press Event
        // Return Value
        //       -
        // Arguments
        //       - ByVal sender As Object    : Occur ButtonPress Event CodeView
        //
        public static void ProcGRPCMFButtonPress(object sender)
        {
            //SOICodeView.MCCodeView cdvTemp;
            //string sTableName;

            //cdvTemp = (SOICodeView.MCCodeView)sender;
            //if (MPCF.Trim(cdvTemp.Tag) != "")
            //{
            //    sTableName = MPCF.Trim(cdvTemp.Tag);
            //    sTableName = sTableName.Substring(1, sTableName.Length - 1);
            //    BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', sTableName);

            //    if (cdvTemp.AllowDrop == true)
            //    {
            //        cdvTemp.InsertEmptyRow(0, 1);
            //    }
            //}

        }

        #endregion

        #region " CheckCMFKeyPress "

        // CheckCMFKeyPress()
        //       - Check Cmf CodeView Key Press Event
        // Return Value
        //       -
        // Arguments
        //       - ByVal sender As Object    : Occur KeyPress Event CodeView
        //       - ByVal e As System.Windows.Forms.KeyPressEventArgs : KeyPress Event Argument
        public static void CheckCMFKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //SOICodeView.MCCodeView cdvTemp;
            //char cFormat;

            //cdvTemp = (SOICodeView.MCCodeView)sender;

            //if ((MPCF.Trim(cdvTemp.Tag) != ""))
            //{
            //    cFormat = MPCF.Trim(cdvTemp.Tag)[0];
            //    if (cFormat == 'N' || cFormat == 'F')
            //    {
            //        if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
            //        {
            //            if (!(e.KeyChar == (char)43 || e.KeyChar == (char)45 || e.KeyChar == (char)8))
            //            {
            //                if (cFormat == 'F')
            //                {
            //                    if (!(e.KeyChar == (char)46))
            //                    {
            //                        e.Handled = true;
            //                    }
            //                }
            //                else
            //                {
            //                    e.Handled = true;
            //                }
            //            }
            //        }
            //    }
            //}

        }

        #endregion

        #region " CheckGRPCMFValue "

        // CheckGRPCMFValue()
        //       - Check Group/Cmf Value
        // Return Value
        //       -
        // Arguments
        //       - ByVal sLabelName As String    : Label Control Name
        //       - ByVal sCodeViewName As String : CodeView Control Name
        //       - ByVal parentControl As Control : Parent Control
        public static bool CheckGRPCMFValue(string sLabelName, string sCheckBoxName, string sCodeViewName, Control parentControl)
        {
            //ArrayList lblList;
            //ArrayList cdvList;
            //ArrayList ckList;
            //Label lblTemp;
            //CheckBox ckTemp;
            //SOICodeView.MCCodeView cdvTemp;
            //int i;

            //try
            //{
            //    lblList = MPCF.GetIndexedControl(sLabelName, parentControl);
            //    cdvList = MPCF.GetIndexedControl(sCodeViewName, parentControl);
            //    ckList = MPCF.GetIndexedControl(sCheckBoxName, parentControl);

            //    for (i = 0; i <= ckList.Count - 1; i++)
            //    {
            //        ckTemp = (CheckBox)ckList[i];

            //        //Modify by J.S. 2009.01.07 cmf의 font의 bold를 초기화 하지 않아서 설정이 없음에도 불구하고 check되는 경우 있음
            //        if (ckTemp.Checked == true)
            //        {
            //            cdvTemp = (SOICodeView.MCCodeView)cdvList[i];
            //            lblTemp = (Label)lblList[i];

            //            if (MPCF.Trim(cdvTemp.Text) == "")
            //            {
            //                MPCF.ShowMsgBox(MPCF.GetMessage(108) + " [" + lblTemp.Text + "]");
            //                cdvTemp.Focus();
            //                return false;
            //            }

            //            if (MPCF.Trim(cdvTemp.Tag)[0] != 'A')
            //            {
            //                if (MPCF.CheckNumeric(cdvTemp.Text) == false)
            //                {
            //                    MPCF.ShowMsgBox(MPCF.GetMessage(110) + " [" + lblTemp.Text + "]");
            //                    cdvTemp.Focus();
            //                    return false;
            //                }
            //            }
            //        }
            //    }

                return true;

            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMsgBox(ex.Message);
            //    return false;
            //}

        }

        #endregion

        #region " GetWorkDate "

        public static bool GetWorkDate(char cStep, ref string sWorkDate)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_DATE_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_DATE_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;

            if (MPCF.CallService("CUS", "CUS_View_Work_Date", in_node, ref out_node) == false)
            {
                return false;
            }

            sWorkDate = out_node.GetString("CUR_WORK_DATE");

            return true;
        }

        // GetWorkDate()
        //       -  View Rule
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //    - 
        public static bool GetWorkDate(char cStep, ref string sWorkDate, ref string sShift, ref string sCurSysTime)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_DATE_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_DATE_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;

            if (MPCF.CallService("CUS", "CUS_View_Work_Date", in_node, ref out_node) == false)
            {
                return false;
            }

            sWorkDate = out_node.GetString("CUR_WORK_DATE");
            sShift = out_node.GetString("CUR_SHIFT_CODE");
            sCurSysTime = out_node.GetString("CURRENT_SYS_TIME");

            return true;
        }
        public static bool GetWorkDate(char cStep, ref string sWorkDate, ref string sShift)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_DATE_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_DATE_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;

            if (MPCF.CallService("CUS", "CUS_View_Work_Date", in_node, ref out_node) == false)
            {
                return false;
            }

            sWorkDate = out_node.GetString("CUR_WORK_DATE");
            sShift = out_node.GetString("CUR_SHIFT_CODE");

            return true;
        }
        public static bool GetWorkDate(char cStep, string sWorkDate, ref string sWeek)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_DATE_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_DATE_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("WORK_DATE", sWorkDate);

            if (MPCF.CallService("CUS", "CUS_View_Work_Date", in_node, ref out_node) == false)
            {
                return false;
            }

            sWeek = out_node.GetString("SYS_WEEK");

            return true;
        }

        public static bool GetStartWorkDate(string sWorkMonth, ref string sStartWorkDate)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_DATE_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_DATE_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '4';
            in_node.AddString("WORK_MONTH", sWorkMonth);

            if (MPCF.CallService("CUS", "CUS_View_Work_Date", in_node, ref out_node) == false)
            {
                return false;
            }

            sStartWorkDate = out_node.GetString("START_WORK_DATE");

            return true;
        }
        //public static bool GetWorkDate(char cStep, ref string sWorkDate, ref string sShift, ref string sCurSysTime, 
        //                          ref string sShiftStartTime, ref string sShiftEndTime)
        //{
        //    TRSNode in_node = new TRSNode("VIEW_WORK_DATE_IN");
        //    TRSNode out_node = new TRSNode("VIEW_WORK_DATE_OUT");

        //    string sRealDate = string.Empty;
        //    string sShift1StartHHMM = string.Empty;
        //    string sCurShiftStartHHMM = string.Empty;
        //    string sCurShiftEndHHMM = string.Empty;

        //    MPCF.SetInMsg(in_node);
        //    in_node.ProcStep = cStep;

        //    if (MPCF.CallService("CUS", "CUS_View_Work_Date", in_node, ref out_node) == false)
        //    {
        //        return false;
        //    }

        //    sWorkDate = out_node.GetString("CUR_WORK_DATE");
        //    sShift = out_node.GetString("CUR_SHIFT_CODE");
        //    sCurSysTime = out_node.GetString("CURRENT_SYS_TIME");

        //    sShift1StartHHMM = out_node.GetString("SHIFT_1_START_TIME");
        //    sCurShiftStartHHMM = out_node.GetString("CUR_SHIFT_START_TIME");
        //    sCurShiftEndHHMM = out_node.GetString("CUR_SHIFT_END_TIME");

        //    if (MPCF.ToInt(sCurShiftStartHHMM) >= 0 && MPCF.ToInt(sCurShiftStartHHMM) < MPCF.ToInt(sShift1StartHHMM))
        //    {
        //        sShiftStartTime = MPCF.ToStandardTime(MPCF.ToDate(sWorkDate + sCurShiftStartHHMM + "00").AddDays(1), MPGC.MP_CONVERT_DATETIME_FORMAT);
        //    }
        //    else
        //    {
        //        sShiftStartTime = sWorkDate + sCurShiftStartHHMM + "00";
        //    }

        //    if (MPCF.ToInt(sCurShiftEndHHMM) >= 0 && MPCF.ToInt(sCurShiftEndHHMM) <= MPCF.ToInt(sShift1StartHHMM))
        //    {
        //        sShiftEndTime = MPCF.ToStandardTime(MPCF.ToDate(sWorkDate + sCurShiftEndHHMM + "00").AddDays(1).AddSeconds(-1), MPGC.MP_CONVERT_DATETIME_FORMAT);
        //    }
        //    else
        //    {
        //        sShiftEndTime = MPCF.ToStandardTime(MPCF.ToDate(sWorkDate + sCurShiftEndHHMM + "00").AddSeconds(-1), MPGC.MP_CONVERT_DATETIME_FORMAT);
        //    }


        //    return true;
        //}

        public static bool GetOrdWorkDateInfo(char cStep, string sWorkDate, string sShift, ref string sCurSysTime,
                                  ref string sShiftStartTime, ref string sShiftEndTime)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_DATE_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_DATE_OUT");

            // string  = string.Empty;
            string sShift1StartHHMM = string.Empty;
            string sCurShiftStartHHMM = string.Empty;
            string sCurShiftEndHHMM = string.Empty;

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("WORK_DATE", sWorkDate);
            in_node.AddString("SHIFT", sShift);

            if (MPCF.CallService("CUS", "CUS_View_Work_Date", in_node, ref out_node) == false)
            {
                return false;
            }

            //sWorkDate = out_node.GetString("CUR_WORK_DATE");
            //sShift = out_node.GetString("CUR_SHIFT_CODE");
            sCurSysTime = out_node.GetString("CURRENT_SYS_TIME");

            sShift1StartHHMM = out_node.GetString("SHIFT_1_START_TIME");
            sCurShiftStartHHMM = out_node.GetString("CUR_SHIFT_START_TIME");
            sCurShiftEndHHMM = out_node.GetString("CUR_SHIFT_END_TIME");

            if (MPCF.ToInt(sCurShiftStartHHMM) >= 0 && MPCF.ToInt(sCurShiftStartHHMM) < MPCF.ToInt(sShift1StartHHMM))
            {
                sShiftStartTime = MPCF.ToStandardTime(MPCF.ToDate(sWorkDate + sCurShiftStartHHMM + "00").AddDays(1), MPGC.MP_CONVERT_DATETIME_FORMAT);
            }
            else
            {
                sShiftStartTime = sWorkDate + sCurShiftStartHHMM + "00";
            }

            if (MPCF.ToInt(sCurShiftEndHHMM) >= 0 && MPCF.ToInt(sCurShiftEndHHMM) <= MPCF.ToInt(sShift1StartHHMM))
            {
                sShiftEndTime = MPCF.ToStandardTime(MPCF.ToDate(sWorkDate + sCurShiftEndHHMM + "00").AddDays(1).AddSeconds(-1), MPGC.MP_CONVERT_DATETIME_FORMAT);
            }
            else
            {
                sShiftEndTime = MPCF.ToStandardTime(MPCF.ToDate(sWorkDate + sCurShiftEndHHMM + "00").AddSeconds(-1), MPGC.MP_CONVERT_DATETIME_FORMAT);
            }


            return true;
        }

        #endregion

        #region " GetFTPInfo "

        public static bool GetFTPInfo(string sFileGroup, ref string sFTPIPaddress, ref int iFTPPort,
                                              ref string sFTPUserID, ref string sFTPPassword, ref string sFTPRootDir)
        {
            TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

            try
            {
                if (ViewGCMData('1', CSGC.MP_GCM_FTP_INFO, sFileGroup, " ", ref out_node, false) == false)
                    return false;

                sFTPIPaddress = MPCF.Trim(out_node.GetString("DATA_1"));
                iFTPPort = MPCF.ToInt(MPCF.Trim(out_node.GetString("DATA_2")));
                sFTPUserID = MPCF.Trim(out_node.GetString("DATA_3"));
                sFTPPassword = MPCF.Trim(out_node.GetString("DATA_4"));
                sFTPRootDir = MPCF.Trim(out_node.GetString("DATA_5"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }


            return true;
        }

        #endregion

        #region " ViewResourceList "

        public static bool ViewResourceList(Control Form_control, char c_step, string table_name, int Image_idx, TreeNode parentNode, string Ext_Factory, bool bIgnoreError, int Col, int Row, string[] Item, string[] Argu)
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
                //MPCF.InitListView((ListView)Form_control);
            }
            else if (Form_control is FarPoint.Win.Spread.FpSpread && (Col > 0 || Row > 0))
            {
                //Do Nothing
            }
            else if (!(Form_control is TreeView))
            {
                MPCF.ClearList(Form_control, true);
            }

            //if (Form_control is SOICodeView.MCCodeDropList)
            //{
            //    ((SOICodeView.MCCodeDropList)Form_control).GCMTableName = table_name;
            //}
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

            MPCF.SetInMsg(in_node);
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

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node, bIgnoreError) == false)
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

                        if (out_node.GetList(0)[i].GetString("DATA_5") == "Y")
                        {
                            itmX.BackColor = Color.PaleGreen;
                        }
                        if (out_node.GetList(0)[i].GetString("DATA_4") == "D")
                        {
                            itmX.BackColor = Color.LightSalmon;
                        }

                        ((ListView)Form_control).Items.Add(itmX);
                    }
                    //else if (Form_control is TreeView)
                    //{
                    //    nodeX = new TreeNode(out_node.GetList(0)[i].GetString("KEY_1") + " : " + out_node.GetList(0)[i].GetString("DATA_1"), Image_idx, Image_idx);
                    //    if (!(parentNode == null))
                    //    {
                    //        parentNode.Nodes.Add(nodeX);
                    //    }
                    //    else
                    //    {
                    //        ((TreeView)Form_control).Nodes.Add(nodeX);
                    //    }
                    //}
                    //else if (Form_control is ComboBox)
                    //{
                    //    ((ComboBox)Form_control).Items.Add(out_node.GetList(0)[i].GetString("KEY_1"));
                    //}
                    //else if (Form_control is FarPoint.Win.Spread.FpSpread)
                    //{
                    //    sheetX = ((FarPoint.Win.Spread.FpSpread)Form_control).ActiveSheet;

                    //    if (sheetX.Columns.Count == 2)
                    //    {

                    //        iRow = sheetX.RowCount;
                    //        sheetX.RowCount++;

                    //        iCol = 0;

                    //        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("KEY_1");

                    //        iCol++;
                    //        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("DATA_1");

                    //        iCol++;

                    //    }
                    //    else if (sheetX.Columns.Count == 3)
                    //    {

                    //        iRow = sheetX.RowCount;
                    //        sheetX.RowCount++;

                    //        iCol = 0;

                    //        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("KEY_1");

                    //        iCol++;
                    //        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("KEY_2");

                    //        iCol++;
                    //        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("DATA_1");

                    //        iCol++;

                    //    }
                    //    else if (sheetX.Columns.Count == 2)
                    //    {
                    //        sList.Add(out_node.GetList(0)[i].GetString("KEY_1"));
                    //    }

                    //}

                }
            }


            return true;

        }

        #endregion

        #region " ViewDescriptionList "

        public static bool ViewDescriptionList(char ProcStep, string[] s_key_list, ref TRSNode out_node)
        {
            int i;

            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode list_item;

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;

            for (i = 0; i < s_key_list.Length; i++)
            {
                if (MPCF.Trim(s_key_list[i]) != "")
                {
                    list_item = in_node.AddNode("KEY_LIST");
                    list_item.AddString("KEY", MPCF.Trim(s_key_list[i]));
                }
            }

            if (MPCF.CallService("CUS", "CUS_View_Description_List", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region " VIEW BOM LOT LIST FUNCTIONS "

        #region " SetBomLotSpreadColumns "

        //
        // SetBomLotSpreadColumns()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step

        public static bool SetBomLotSpreadColumns(FarPoint.Win.Spread.FpSpread spdList, bool bBoldHeader, bool bBoldText)
        {
            int i;
            string sTemp = string.Empty;
            System.Drawing.Font bFont;
            System.Drawing.Font bFontTxt;
            //CultureInfo ci = CultureInfo.CurrentCulture;

            FarPoint.Win.Spread.CellType.NumberCellType numCellType;


            try
            {
                numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCellType.FixedPoint = false;
                numCellType.DecimalPlaces = 3;
                numCellType.ShowSeparator = true;
                //numCellType.Separator = ci.NumberFormat.NumberGroupSeparator;
                //numCellType.DecimalSeparator = ci.NumberFormat.NumberDecimalSeparator;

                if (bBoldHeader == true)
                {
                    bFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                }
                else
                {
                    bFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
                }
                if (bBoldText == true)
                {
                    bFontTxt = new System.Drawing.Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
                }
                else
                {
                    bFontTxt = new System.Drawing.Font("Microsoft Sans Serif", 11F, FontStyle.Regular);
                }

                spdList.ActiveSheet.ColumnCount = 0;
                spdList.ActiveSheet.ColumnCount = Enum.GetNames(typeof(CSGC.BOM_INFO)).Length;
                spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].HorizontalAlignment = CellHorizontalAlignment.Left;
                spdList.ActiveSheet.Columns[0, spdList.ActiveSheet.ColumnCount - 1].Locked = true;
                spdList.ActiveSheet.FrozenColumnCount = 1;

                for (i = 0; i < spdList.ActiveSheet.ColumnCount; i++)
                {
                    sTemp = Enum.GetName(typeof(CSGC.BOM_INFO), i);

                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].ForeColor = Color.FromArgb(71, 99, 158);
                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].Font = bFont;
                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].Text = CSCF.GenCaptionText(sTemp);

                    if (sTemp.ToUpper().Contains("QTY") || sTemp.ToUpper().Contains("NUM") || sTemp.ToUpper().Contains("COUNT"))
                    {
                        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Right;
                        spdList.ActiveSheet.Columns[i].CellType = numCellType;
                    }
                    else if (sTemp.ToUpper().EndsWith("FLAG") || sTemp.ToUpper().EndsWith("VER") || sTemp.ToUpper().EndsWith("UNIT"))
                    {
                        spdList.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }

                    spdList.ActiveSheet.Columns[i].Font = bFontTxt;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        #endregion

        #region " ViewBomLotList "

        // ViewBomLotList()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        public static bool ViewBomLotList(FarPoint.Win.Spread.FpSpread spdList,
                        char ProcStep, string sMatID, int iMatVer, string sBomSetID, int iBomVer, string sResID,
                        string sOper,
                        string sOrderID, string sUserID, ref double dTotUserLossRaw,
                        bool bShowMsgBox, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus)
        {
            FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[3];

            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");

            MPCF.ClearList(spdList, true);

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("MAT_ID", MPCF.Trim(sMatID));
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("BOM_SET_ID", MPCF.Trim(sBomSetID));
            in_node.AddInt("BOM_SET_VERSION", iBomVer);
            in_node.AddString("RES_ID", MPCF.Trim(sResID));
            in_node.AddString("OPER", MPCF.Trim(sOper));
            in_node.AddChar("SHOW_AUTO_INPUT_LOT_FLAG", "Y");

            in_node.AddString("ORDER_ID", MPCF.Trim(sOrderID));
            in_node.AddString("LOSS_USER_ID", MPCF.Trim(sUserID));

            if (lblStatus != null)
            {
                CSCF.ShowStatusMsg(lblStatus, 'R', "");
            }

            if (MPCF.CallService("CUS", "CUS_View_Bom_Info_With_Lot", in_node, ref out_node, !bShowMsgBox) == false)
            {
                if (!bShowMsgBox && lblStatus != null)
                {
                    CSCF.CheckContinueProcMB(out_node, lblStatus);
                }
                return false;
            }

            if (MakeBomLotListInfo('1', spdList, ref out_node) == false)
            {
                return false;
            }

            dTotUserLossRaw = out_node.GetDouble("TOT_USER_LOSS_RAW");

            if (spdList.Sheets[0].RowCount > 0)
            {
                sort[0] = new FarPoint.Win.Spread.SortInfo((int)CSGC.BOM_INFO.OPER_SEQ_NUM, true);
                sort[1] = new FarPoint.Win.Spread.SortInfo((int)CSGC.BOM_INFO.SEQ_NUM, true);
                sort[2] = new FarPoint.Win.Spread.SortInfo((int)CSGC.BOM_INFO.INPUT_TIME, true);
                spdList.Sheets[0].SortRows(0, spdList.Sheets[0].RowCount, sort);

                MPCF.FitColumnHeader(spdList);
            }

            if (spdList.Sheets[0].Columns[(int)CSGC.BOM_INFO.MAT_DESC].Width > 120)
                spdList.Sheets[0].Columns[(int)CSGC.BOM_INFO.MAT_DESC].Width = 120;

            if (spdList.Sheets[0].Columns[(int)CSGC.BOM_INFO.MAT_SHORT_DESC].Width > 140)
                spdList.Sheets[0].Columns[(int)CSGC.BOM_INFO.MAT_SHORT_DESC].Width = 140;

            return true;
        }


        #endregion


        #region " MakeBomLotListInfo "

        public static bool MakeBomLotListInfo(char cStep,
                              FarPoint.Win.Spread.FpSpread spdList,
                              ref TRSNode out_node)
        {
            FarPoint.Win.Spread.SheetView sheetX = spdList.ActiveSheet;
            int i, k, iRow;

            try
            {
                //MPCF.ClearList(spdList);
                //MPGV.geLanguageFormat = LANG_FORMAT.SYSTEM;

                for (i = 0; i < out_node.GetList("BOM_LIST").Count; i++)
                {
                    if (out_node.GetList("BOM_LIST")[i].GetList("LOT_LIST").Count <= 0)
                    {
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;
                        sheetX.Rows[iRow].Height = CSGC.SPREAD_RAW_HEIGHT_OI;

                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.MAT_ID].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_ID");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.MAT_SHORT_DESC].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_SHORT_DESC");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.MAT_DESC].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_DESC");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.QTY].Value = out_node.GetList("BOM_LIST")[i].GetDouble("MAT_QTY");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.UNIT].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_UNIT");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.INV_OPER].Value = out_node.GetList("BOM_LIST")[i].GetString("FROM_INV_OPER");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.LOT_COUNT].Value = MPCF.ToInt(out_node.GetList("BOM_LIST")[i].GetDouble("LOT_COUNT"));
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.TOT_QTY].Value = out_node.GetList("BOM_LIST")[i].GetDouble("LOT_SUM_QTY");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.LOT_UNIT].Value = out_node.GetList("BOM_LIST")[i].GetString("LOT_UNIT");

                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.INPUT_TYPE].Value = out_node.GetList("BOM_LIST")[i].GetString("BOM_INPUT_TYPE_DESC");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.INPUT_TYPE_CODE].Value = out_node.GetList("BOM_LIST")[i].GetString("BOM_INPUT_TYPE");

                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.PURE_IN_QTY].Value = out_node.GetList("BOM_LIST")[i].GetString("PART_CMF_5");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.P_BASE_QTY].Value = out_node.GetList("BOM_LIST")[i].GetString("PART_CMF_1");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.P_BASE_UNIT].Value = out_node.GetList("BOM_LIST")[i].GetString("PART_CMF_2");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.SCRAP_QTY].Value = out_node.GetList("BOM_LIST")[i].GetString("PART_CMF_4");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.SEQ_NUM].Value = out_node.GetList("BOM_LIST")[i].GetInt("SEQ_NUM");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.BOM_SET_ID].Value = out_node.GetList("BOM_LIST")[i].GetString("BOM_SET_ID");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.SCALE_FACTOR].Value = out_node.GetList("BOM_LIST")[i].GetDouble("SCALE_FACTOR");

                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.OPER].Value = out_node.GetList("BOM_LIST")[i].GetString("OPER");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.OPER_SEQ_NUM].Value = out_node.GetList("BOM_LIST")[i].GetInt("OPER_SEQ_NUM");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.USER_LOSS_QTY].Value = out_node.GetList("BOM_LIST")[i].GetDouble("USER_LOSS_QTY");

                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.MAT_GRP_2].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_GRP_2");

                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.REQ_FLAG].Value = out_node.GetList("BOM_LIST")[i].GetChar("REQ_FLAG");
                        sheetX.Cells[iRow, (int)CSGC.BOM_INFO.REQ_TIME].Value = out_node.GetList("BOM_LIST")[i].GetString("REQ_TIME");

                        if (out_node.GetList("BOM_LIST")[i].GetChar("REQ_FLAG") == 'Y')
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.FromArgb(150, 54, 52);
                        }

                    }
                    else
                    {
                        for (k = 0; k < out_node.GetList("BOM_LIST")[i].GetList("LOT_LIST").Count; k++)
                        {
                            iRow = sheetX.RowCount;
                            sheetX.RowCount++;
                            sheetX.Rows[iRow].Height = CSGC.SPREAD_RAW_HEIGHT_OI;

                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.MAT_ID].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_ID");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.MAT_SHORT_DESC].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_SHORT_DESC");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.MAT_DESC].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_DESC");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.QTY].Value = out_node.GetList("BOM_LIST")[i].GetDouble("MAT_QTY");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.UNIT].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_UNIT");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.INV_OPER].Value = out_node.GetList("BOM_LIST")[i].GetString("FROM_INV_OPER");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.LOT_COUNT].Value = MPCF.ToInt(out_node.GetList("BOM_LIST")[i].GetDouble("LOT_COUNT"));
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.TOT_QTY].Value = out_node.GetList("BOM_LIST")[i].GetDouble("LOT_SUM_QTY");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.LOT_UNIT].Value = out_node.GetList("BOM_LIST")[i].GetString("LOT_UNIT");

                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.INPUT_TYPE].Value = out_node.GetList("BOM_LIST")[i].GetString("BOM_INPUT_TYPE_DESC");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.INPUT_TYPE_CODE].Value = out_node.GetList("BOM_LIST")[i].GetString("BOM_INPUT_TYPE");

                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.PURE_IN_QTY].Value = out_node.GetList("BOM_LIST")[i].GetString("PART_CMF_5");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.P_BASE_QTY].Value = out_node.GetList("BOM_LIST")[i].GetString("PART_CMF_1");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.P_BASE_UNIT].Value = out_node.GetList("BOM_LIST")[i].GetString("PART_CMF_2");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.SCRAP_QTY].Value = out_node.GetList("BOM_LIST")[i].GetString("PART_CMF_4");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.SEQ_NUM].Value = out_node.GetList("BOM_LIST")[i].GetInt("SEQ_NUM");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.BOM_SET_ID].Value = out_node.GetList("BOM_LIST")[i].GetString("BOM_SET_ID");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.SCALE_FACTOR].Value = out_node.GetList("BOM_LIST")[i].GetDouble("SCALE_FACTOR");

                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.REQ_FLAG].Value = out_node.GetList("BOM_LIST")[i].GetChar("REQ_FLAG");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.REQ_TIME].Value = out_node.GetList("BOM_LIST")[i].GetString("REQ_TIME");

                            if (out_node.GetList("BOM_LIST")[i].GetChar("REQ_FLAG") == 'Y')
                            {
                                sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.FromArgb(150, 54, 52);
                            }

                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.LOT_ID].Value = out_node.GetList("BOM_LIST")[i].GetList("LOT_LIST")[k].GetString("LOT_ID");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.LOTQTY].Value = out_node.GetList("BOM_LIST")[i].GetList("LOT_LIST")[k].GetDouble("QTY_1");
                            //sheetX.Cells[iRow, (int)CSGC.BOM_INFO.UNIT_1].Value = out_node.GetList("BOM_LIST")[i].GetList("LOT_LIST")[k].GetString("UNIT_1");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.INPUT_TIME].Value = MPCF.MakeDateFormat(out_node.GetList("BOM_LIST")[i].GetList("LOT_LIST")[k].GetString("INPUT_TIME"));
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.LOT_CREATE_TIME].Value = out_node.GetList("BOM_LIST")[i].GetList("LOT_LIST")[k].GetString("LOT_CREATE_TIME");

                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.OPER].Value = out_node.GetList("BOM_LIST")[i].GetString("OPER");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.OPER_SEQ_NUM].Value = out_node.GetList("BOM_LIST")[i].GetInt("OPER_SEQ_NUM");
                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.USER_LOSS_QTY].Value = out_node.GetList("BOM_LIST")[i].GetDouble("USER_LOSS_QTY");

                            sheetX.Cells[iRow, (int)CSGC.BOM_INFO.MAT_GRP_2].Value = out_node.GetList("BOM_LIST")[i].GetString("MAT_GRP_2");
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion


        #endregion

        #region " GetGlobalOption "

        public static bool GetGlobalOption(string s_option_name, ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("VIEW_GLOBAL_OPTION_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPTION_NAME", s_option_name);

                if (MPCF.CallService("BAS", "BAS_View_Global_Option", in_node, ref out_node) == false)
                {
                    return false;
                }

                //cdvOptionName.Text = out_node.GetString("OPTION_NAME");
                //txtOptionDescDefinition.Text = out_node.GetString("OPTION_DESC");
                //txtDEFCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                //txtDEFCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                //txtDEFUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                //txtDEFUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                //cdvValue1.Text = out_node.GetString("VALUE_1");
                //cdvValue2.Text = out_node.GetString("VALUE_2");
                //cdvValue3.Text = out_node.GetString("VALUE_3");
                //cdvValue4.Text = out_node.GetString("VALUE_4");
                //cdvValue5.Text = out_node.GetString("VALUE_5");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public static bool GetGlobalOption(string s_option_name, ref string s_value_1)
        {
            TRSNode in_node = new TRSNode("VIEW_GLOBAL_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_GLOBAL_OPTION_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPTION_NAME", s_option_name);

                if (MPCF.CallService("BAS", "BAS_View_Global_Option", in_node, ref out_node) == false)
                {
                    return false;
                }

                s_value_1 = MPCF.Trim(out_node.GetString("VALUE_1"));

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        #endregion

        #region " ViewResListByArea "
        /// <summary>
        /// Area And Sub Area 별 설비 리스트
        /// </summary>
        /// <param name="control">리스트 담을 콘트롤</param>
        /// <param name="c_step">PROCSTEP</param>
        /// <param name="area">AREA</param>
        /// <param name="subarea">SUBAREA</param>
        /// <returns></returns>
        /// 
        public static bool ViewResListByArea(Control control, char c_step, string s_area)
        {
            return ViewResListByArea(control, c_step, s_area, "", null, "");
        }

        public static bool ViewResListByArea(Control control, char c_step, string s_area, string s_subarea)
        {
            return ViewResListByArea(control, c_step, s_area, s_subarea, null, "");
        }

        public static bool ViewResListByArea(Control control, char c_step, string s_area, string s_subarea, TreeNode parentNode, string sExtFactory)
        {
            int i;
            ListViewItem itmX;
            TreeNode nodeX = null;
            ArrayList a_list;

            try
            {
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
                TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

                a_list = new ArrayList();

                //MPCF.InitListView((ListView)control);

                if (control is ListView)
                {
                    //MPCF.InitListView((ListView)control);
                }
                else if (!(control is TreeView))
                {
                    if (!(parentNode == null))
                    {
                        parentNode.Nodes.Clear();
                    }
                    else
                    {
                        MPCF.ClearList(control, true);
                    }
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                if (sExtFactory != "")
                {
                    in_node.Factory = sExtFactory;
                };

                in_node.ProcStep = c_step;
                in_node.SetString("AREA", MPCF.Trim(s_area));
                in_node.SetString("SUBAREA", MPCF.Trim(s_subarea));

                do
                {
                    if (MPCF.CallService("CUS", "CUS_View_Area_Res_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
                }
                while (in_node.GetString("NEXT_RES_ID") != "");

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RES_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE);

                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RES_DESC"));
                            }

                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("RES_ID") + " : " + out_node.GetList(0)[i].GetString("RES_DESC"),
                                (int)SMALLICON_INDEX.IDX_RESOURCE, (int)SMALLICON_INDEX.IDX_RESOURCE);
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
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("RES_ID"));
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion

        public static bool CheckServer()
        {
            TRSNode in_node;
            TRSNode out_node;

            try
            {

                in_node = new TRSNode("VIEW_IN");
                out_node = new TRSNode("VIEW_OUT");

                MPCF.SetInMsg(in_node);
                in_node.AddChar("SYS_TIME_FLAG", 'N');
                if (MPCF.CallService("CUS", "CUS_Check_Server", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message + " [CheckServer]");
                return false;
            }
        }
        public static bool CheckServer(ref string sDBSysTime)
        {
            TRSNode in_node;
            TRSNode out_node;

            try
            {

                in_node = new TRSNode("VIEW_IN");
                out_node = new TRSNode("VIEW_OUT");
                MPCF.SetInMsg(in_node);
                in_node.AddChar("SYS_TIME_FLAG", 'Y');

                if (MPCF.CallService("CUS", "CUS_Check_Server", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                sDBSysTime = MPCF.Trim(out_node.GetString("DB_SYS_TIME"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message + " [CheckServer]");
                return false;
            }
        }

        public static bool ViewInvLot(char c_proc_step, string s_lot_id, string s_oper,
                                      char c_delete_flag, char c_hold_flag, char c_factory_flag,
                                      char c_oper_flag, char c_oqc_flag,
                                      ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("VIEW_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;
                in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));
                in_node.AddString("OPER", MPCF.Trim(s_oper));

                in_node.AddChar("CHECK_DELETE_FLAG", c_delete_flag);  // LOT 이 DELETE 상태이면 ERROR
                in_node.AddChar("CHECK_HOLD_FLAG", c_hold_flag);    // LOT 이 HOLD 상태이면 ERROR
                in_node.AddChar("CHECK_FACTORY_FLAG", c_factory_flag); // LOT 의 공장과 in_node의 FACTORY가 다르면 ERROR
                in_node.AddChar("CHECK_OPER_FLAG", c_oper_flag);    // LOT 의 공정과 입력된 공정이 다르면 ERROR            
                in_node.AddChar("CHECK_OQC_FLAG", c_oqc_flag);

                if (MPCF.CallService("TIV", "TIV_View_Lot_Ext", in_node, ref out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #region " TriggerInterface "

        public static bool TriggerInterface(char cStep, string sInterfaceID)
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("UPDATE_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("INTERFACE_ID", sInterfaceID);

            if (MPCF.CallService("CUS", "CUS_Trigger_Interface", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region " ViewTriggerInterface "

        public static bool ViewTriggerInterface(char cStep, string sInterfaceID, ref char cIFProcFlag)
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("UPDATE_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cStep;
            in_node.AddString("INTERFACE_ID", sInterfaceID);

            if (MPCF.CallService("CUS", "CUS_View_Trigger_Interface", in_node, ref out_node) == false)
            {
                return false;
            }

            cIFProcFlag = out_node.GetChar("IF_PROC_FLAG");

            return true;
        }

        #endregion


        #region " ViewResourceMaterialList_DTR "

        public static bool ViewResourceMaterialList_DTR(char cProcStep, Control Form_control, char rel_level, string key, string sFilter, int Image_idx, string Ext_Factory, bool bIgnoreError)
        {

            ListViewItem itmX;

            int i;
            int j;
            List<string> sList = new List<string>();
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (Form_control is ListView)
            {
                //MPCF.InitListView((ListView)Form_control);
            }
            else
            {
                return false;
            }
            if (Image_idx == -1)
            {
                Image_idx = (int)SMALLICON_INDEX.IDX_MATERIAL;
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

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = cProcStep;

            if (Ext_Factory != "")
            {
                in_node.Factory = Ext_Factory;
            }

            if (rel_level == 'R')
            {
                in_node.AddString("RES_ID", key);
            }
            else if (rel_level == 'G')
            {
                in_node.AddString("RESG_ID", key);
            }
            else if (rel_level == 'W')
            {
                in_node.AddString("WORK_CENTER", key);
            }
            in_node.AddChar("REL_LEVEL", rel_level);

            in_node.AddString("FILTER", MPCF.Trim(sFilter));

            in_node.AddString("NEXT_MAT_ID", "");

            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCF.CallService("CUS", "CUS_View_Resource_Material_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_MAT_ID", out_node.GetString("NEXT_MAT_ID"));

            } while (in_node.GetString("NEXT_MAT_ID") != "");

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (Form_control is ListView)
                    {
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_CMF_15")) != "Y")
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("MAT_ID"), Image_idx);
                            if (((ListView)Form_control).Columns.Count > 1)
                            {
                                for (j = 0; j < ((ListView)Form_control).Columns.Count - 1; j++)
                                {
                                    if (cProcStep == '1' || cProcStep == '2')
                                    {
                                        switch (j)
                                        {
                                            case 0:
                                                itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                                                break;
                                            case 1:
                                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_SHORT_DESC"));
                                                break;

                                            case 2:
                                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_DESC"));
                                                break;
                                        }
                                    }
                                    else //if (cProcStep == '3' || cProcStep == '4') without mat version
                                    {
                                        switch (j)
                                        {
                                            case 0:
                                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_SHORT_DESC"));
                                                break;
                                            case 1:
                                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_DESC"));
                                                break;
                                        }
                                    }

                                }
                            }
                            ((ListView)Form_control).Items.Add(itmX);
                        }
                    }
                }
            }

            //MPCF.FitColumnHeader((ListView)Form_control);

            return true;
        }

        #endregion

    }
}
