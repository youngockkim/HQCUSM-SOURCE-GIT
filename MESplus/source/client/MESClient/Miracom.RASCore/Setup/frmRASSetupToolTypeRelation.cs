//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupToolTypeRelation.cs
//   Description :
//
//   MES Version : 5.3.0.0
//
//   Function List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2013-01-07 : Created by MHIM
//
//
//   Copyright(C) 1998-2013 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;

namespace Miracom.RASCore
{
    public partial class frmRASSetupToolTypeRelation : Miracom.MESCore.SetupForm02
    {
        public frmRASSetupToolTypeRelation()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private enum ColumnsMFO
        {
            TOOL_TYPE = 0,
            TOOL_ID = 1,
            MAT_ID = 2,
            MAT_VER = 3,
            FLOW = 4,
            OPER = 5
        }
        private enum ColumnsRAS
        {
            TOOL_TYPE = 0,
            TOOL_ID = 1,
            RES_TYPE = 2,
            RES_GROUP = 3,
            RES_ID = 4,
            EVENT_ID = 5,
            TOOL_EVENT_ID = 6
        }

        #endregion

        #region " Variable Definition "

        private bool bLoadFlag;
        private char lm_res_rel_level;
        private string lm_res_type;
        private string lm_res_group;
        private string lm_res_id;

        //private TRSNode m_rel_info;

        //private TRSNode RELATION
        //{
        //    get
        //    {
        //        if (m_rel_info == null) m_rel_info = new TRSNode("");
        //        return m_rel_info;
        //    }
        //}

        private string SelectedToolID
        {
            get
            {
                if (lisToolList.Items.Count > 0 &&
                    lisToolList.SelectedItems != null &&
                    lisToolList.SelectedItems.Count > 0 &&
                    lisToolList.SelectedItems[0].Index > 0)
                {
                    return MPCF.Trim(lisToolList.SelectedItems[0].Text);
                }
                else
                {
                    return "";
                }
            }
        }

        #endregion

        #region " Function Definition "

        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 구분??
        //
        private bool CheckCondition(char ProcStep)
        {
            if (tabRelation.SelectedTab == tbpMFO)
            {
                if (udcMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    udcMFO.Focus();
                    return false;
                }
            }

            switch (ProcStep)
            {
                case MPGC.MP_STEP_CREATE:
                    break;
                case MPGC.MP_STEP_UPDATE:
                    break;

                case MPGC.MP_STEP_DELETE:
                    break;
            }

            return true;

        }

        //
        // ViewAlarmRelationList
        //       - View Alarm Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewRelationList(char c_rel_level, string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            TRSNode in_node = new TRSNode("RAS_View_Tool_Type_Relation_List_In");
            TRSNode out_node, list_item;

            ListViewItem itmX;
            System.Collections.ArrayList a_list;

            int i;

            try
            {
                a_list = new System.Collections.ArrayList();
                MPCF.InitListView(lisRelationList);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("REL_LEVEL", c_rel_level);
                in_node.AddString("MAT_ID", s_mat_id);
                in_node.AddInt("MAT_VER", i_mat_ver);
                in_node.AddString("FLOW", s_flow);
                in_node.AddString("OPER", s_oper);

                do
                {
                    out_node = new TRSNode("RAS_View_Tool_Type_Relation_List_Out");

                    if (MPCR.CallService("RAS", "RAS_View_Tool_Type_Relation_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_MAT_ID", out_node.GetString("NEXT_MAT_ID"));
                    in_node.SetInt("NEXT_MAT_VER", out_node.GetInt("NEXT_MAT_VER"));
                    in_node.SetString("NEXT_FLOW", out_node.GetString("NEXT_FLOW"));
                    in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_TOOL_TYPE"));
                    in_node.SetString("NEXT_TOOL_TYPE", out_node.GetString("NEXT_TOOL_TYPE"));
                    in_node.SetString("NEXT_TOOL_ID", out_node.GetString("NEXT_TOOL_ID"));

                } while (out_node.GetString("NEXT_MAT_ID") != "" ||
                out_node.GetInt("NEXT_MAT_VER") > 0 ||
                out_node.GetString("NEXT_FLOW") != "" ||
                out_node.GetString("NEXT_OPER") != "" ||
                out_node.GetString("NEXT_TOOL_TYPE") != "" ||
                out_node.GetString("NEXT_TOOL_ID") != "");

                foreach (object nodeItem in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)nodeItem;

                    for (i = 0; i < out_node.GetList("TOOL_TYPE_LIST").Count; i++)
                    {
                        list_item = out_node.GetList("TOOL_TYPE_LIST")[i];

                        if (list_item.GetString("TOOL_ID") == "")
                        {
                            itmX = new ListViewItem(list_item.GetString("TOOL_TYPE"), (int)SMALLICON_INDEX.IDX_TOOL_TYPE);
                        }
                        else
                        {
                            itmX = new ListViewItem(list_item.GetString("TOOL_TYPE"), (int)SMALLICON_INDEX.IDX_TOOL);
                        }
                        itmX.SubItems.Add(list_item.GetString("TOOL_ID"));
                        itmX.SubItems.Add(list_item.GetString("MAT_ID"));
                        if (list_item.GetInt("MAT_VER") > 0)
                        {
                            itmX.SubItems.Add(MPCF.Trim(list_item.GetInt("MAT_VER")));
                        }
                        else
                        {
                            itmX.SubItems.Add("");
                        }
                        itmX.SubItems.Add(list_item.GetString("FLOW"));
                        itmX.SubItems.Add(list_item.GetString("OPER"));
                        lisRelationList.Items.Add(itmX);
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

        //
        // ViewAlarmRelationList
        //       - View Alarm Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewRelationList(char c_rel_level, string res_type, string res_group, string res_id)
        {
            TRSNode in_node = new TRSNode("RAS_View_Tool_Type_Relation_List_In");
            TRSNode out_node, list_item;

            ListViewItem itmX;
            System.Collections.ArrayList a_list;

            int i;

            try
            {
                a_list = new System.Collections.ArrayList();
                MPCF.InitListView(lisRelationList);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddChar("REL_LEVEL", c_rel_level);
                in_node.AddString("RES_TYPE", res_type);
                in_node.AddString("RESG_ID", res_group);
                in_node.AddString("RES_ID", res_id);

                do
                {
                    out_node = new TRSNode("RAS_View_Tool_Type_Relation_List_Out");

                    if (MPCR.CallService("RAS", "RAS_View_Tool_Type_Relation_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_EVENT_ID", out_node.GetString("NEXT_EVENT_ID"));
                    in_node.SetString("NEXT_TOOL_TYPE", out_node.GetString("NEXT_TOOL_TYPE"));
                    in_node.SetString("NEXT_TOOL_ID", out_node.GetString("NEXT_TOOL_ID"));

                } while (out_node.GetString("NEXT_EVENT_ID") != "" ||
                    out_node.GetString("NEXT_TOOL_TYPE") != "" ||
                    out_node.GetString("NEXT_TOOL_ID") != "");

                foreach (object nodeItem in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)nodeItem;

                    for (i = 0; i < out_node.GetList("TOOL_TYPE_LIST").Count; i++)
                    {
                        list_item = out_node.GetList("TOOL_TYPE_LIST")[i];

                        if (list_item.GetString("TOOL_ID") == "")
                        {
                            itmX = new ListViewItem(list_item.GetString("TOOL_TYPE"), (int)SMALLICON_INDEX.IDX_TOOL_TYPE);
                        }
                        else
                        {
                            itmX = new ListViewItem(list_item.GetString("TOOL_TYPE"), (int)SMALLICON_INDEX.IDX_TOOL);
                        }

                        itmX.SubItems.Add(list_item.GetString("TOOL_ID"));
                        itmX.SubItems.Add(list_item.GetString("RES_TYPE"));
                        itmX.SubItems.Add(list_item.GetString("RES_GROUP"));
                        itmX.SubItems.Add(list_item.GetString("RES_ID"));
                        itmX.SubItems.Add(list_item.GetString("EVENT_ID"));
                        itmX.SubItems.Add(list_item.GetString("TOOL_EVENT_ID"));
                        lisRelationList.Items.Add(itmX);
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

        //
        // ViewAlarmRelationList
        //       - View Alarm Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewToolTypeRelation(char c_rel_level, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_tool_type, string s_tool_id)
        {
            TRSNode in_node = new TRSNode("RAS_View_Tool_Type_Relation_In");
            TRSNode out_node = new TRSNode("RAS_View_Tool_Type_Relation_Out");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("REL_LEVEL", c_rel_level);
                in_node.AddString("MAT_ID", s_mat_id);
                in_node.AddInt("MAT_VER", i_mat_ver);
                in_node.AddString("FLOW", s_flow);
                in_node.AddString("OPER", s_oper);
                in_node.AddString("TOOL_TYPE", s_tool_type);
                in_node.AddString("TOOL_ID", s_tool_id);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type_Relation", in_node, ref out_node) == false)
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

        //
        // ViewAlarmRelationList
        //       - View Alarm Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewToolTypeRelation(char c_rel_level, string res_type, string res_group, string res_id, string event_id, string s_tool_type, string s_tool_id)
        {
            TRSNode in_node = new TRSNode("RAS_View_Tool_Type_Relation_List_In");
            TRSNode out_node = new TRSNode("RAS_View_Tool_Type_Relation_List_Out");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("REL_LEVEL", c_rel_level);
                in_node.AddString("RES_TYPE", res_type);
                in_node.AddString("RESG_ID", res_group);
                in_node.AddString("RES_ID", res_id);
                in_node.AddString("EVENT_ID", event_id);
                in_node.AddString("TOOL_TYPE", s_tool_type);
                in_node.AddString("TOOL_ID", s_tool_id);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvToolEvent.Text = out_node.GetString("TOOL_EVENT_ID");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proc_step">1:MFO, 2:RAS</param>
        /// <param name="lisData"></param>
        /// <returns></returns>
        private bool SetColumn(char proc_step)
        {
            ListView lisData = lisRelationList;
            try
            {
                if (proc_step == '1')   //MFO
                {
                    lisData.Columns.Clear();
                    lisData.Columns.Add("Tool Type", 100, HorizontalAlignment.Left);
                    lisData.Columns.Add("Tool ID", 100, HorizontalAlignment.Left);
                    lisData.Columns.Add("Mat ID", 80, HorizontalAlignment.Left);
                    lisData.Columns.Add("Mat Ver", 80, HorizontalAlignment.Left);
                    lisData.Columns.Add("Flow", 80, HorizontalAlignment.Left);
                    lisData.Columns.Add("Oper", 80, HorizontalAlignment.Left);

                }
                else if (proc_step == '2')  //RAS
                {
                    lisData.Columns.Clear();
                    lisData.Columns.Add("Tool Type", 100, HorizontalAlignment.Left);
                    lisData.Columns.Add("Tool ID", 100, HorizontalAlignment.Left);
                    lisData.Columns.Add("Resource Type", 100, HorizontalAlignment.Left);
                    lisData.Columns.Add("Resource Group", 100, HorizontalAlignment.Left);
                    lisData.Columns.Add("Resource ID", 80, HorizontalAlignment.Left);
                    lisData.Columns.Add("Event", 80, HorizontalAlignment.Left);
                    lisData.Columns.Add("Tool Event", 150, HorizontalAlignment.Left);
                }

                MPCF.ToClientLanguage(this);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void InitResourceTree()
        {
            MPCF.InitTreeView(tvResList);

            if (rbtFactory.Checked == true)
            {
                TreeNode node;
                node = tvResList.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.Expand();
            }
            else if (rbtResType.Checked == true)
            {
                if (BASLIST.ViewGCMDataList(tvResList, '1', MPGC.MP_RAS_RES_TYPE) == false) return;
            }
            else if (rbtResGroup.Checked == true)
            {
                if (RASLIST.ViewResourceGroupList(tvResList, '1') == false) return;
            }
        }

        private void ViewResourceItem(TreeNode ParentNode)
        {
            string s_resg_id = "";
            string s_res_type = "";

            if (rbtResType.Checked == true)
            {
                s_res_type = MPCF.Trim(ParentNode.Text);
                s_res_type = MPCF.SubtractString(s_res_type, ":", false, false);
            }
            else if (rbtResGroup.Checked == true)
            {
                s_resg_id = MPCF.Trim(ParentNode.Text);
                s_resg_id = MPCF.SubtractString(s_resg_id, ":", false, false);
            }

            if (RASLIST.ViewResourceList(tvResList, '1', s_resg_id, s_res_type, "", "", "", 0, "", "", ' ', "", false, ParentNode, "") == false) return;
            ParentNode.Expand();
        }

        //
        // ViewMFOSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewMFOSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            StringBuilder sb;

            MPCF.InitListView(udcMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (udcMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MRASTOLREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT MAT_ID, MAT_VER, OPER FROM MRASTOLREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER FROM MRASTOLREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER FROM MRASTOLREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER ASC");
                    break;

            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(udcMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        //
        // ViewResourceSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewResourceSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            StringBuilder sb;
            char[] c_rel_level;

            MPCF.InitListView(lisResList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            c_rel_level = new char[2];
            c_rel_level[0] = ' ';
            c_rel_level[1] = ' ';

            if (rbtFactory.Checked == true)
            {
                c_rel_level[0] = 'F';
            }
            else if (rbtResType.Checked == true)
            {
                c_rel_level[0] = 'T';
                c_rel_level[1] = 'R';
            }
            else if (rbtResGroup.Checked == true)
            {
                c_rel_level[0] = 'G';
                c_rel_level[1] = 'R';
            }

            sb = new StringBuilder();

            sb.Append("SELECT FACTORY, RES_TYPE, RESG_ID, RES_ID FROM MRASTOLREL ");
            sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
            sb.Append("AND REL_LEVEL IN ('" + c_rel_level[0].ToString() + "', '" + c_rel_level[1].ToString() + "' ) ");
            sb.Append("GROUP BY FACTORY, RES_TYPE, RESG_ID, RES_ID ");
            sb.Append("ORDER BY FACTORY, RES_TYPE, RESG_ID, RES_ID");

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(lisResList, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private bool UpdateRelation(char ProcStep)
        {
            TRSNode in_node = new TRSNode("RAS_Update_Tool_Type_Relation");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (tabRelation.SelectedTab == tbpMFO)
                {
                    in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", udcMFO.MatID);
                    in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                    in_node.AddString("FLOW", udcMFO.Flow);
                    in_node.AddString("OPER", udcMFO.Oper);

                    in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvToolType.Text));
                }
                else
                {
                    in_node.AddChar("REL_LEVEL", lm_res_rel_level);
                    in_node.AddString("RES_TYPE", lm_res_type);
                    in_node.AddString("RESG_ID", lm_res_group);
                    in_node.AddString("RES_ID", lm_res_id);

                    in_node.AddString("EVENT_ID", MPCF.Trim(cdvResEvent.Text));
                    in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvToolType.Text));
                    in_node.AddString("TOOL_EVENT_ID", MPCF.Trim(cdvToolEvent.Text));
                }

                in_node.AddString("TOOL_ID", SelectedToolID);

                if (MPCR.CallService("RAS", "RAS_Update_Tool_Type_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvToolType;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        private bool ViewToolList()
        {
            string SelectedItem;
            ListViewItem empty;

            try
            {
                SelectedItem = MPCF.Trim(cdvToolType.Text);
                MPCF.InitListView(lisToolList);

                if (RASLIST.ViewToolList(lisToolList, '2', MPCF.Trim(cdvToolType.Text), 'N', false, null) == false)
                {
                    return false;
                }

                empty = new ListViewItem("...", (int)SMALLICON_INDEX.IDX_TOOL_TYPE);
                empty.SubItems.Add("(Select ToolType)");
                lisToolList.Items.Insert(0, empty);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }

        #endregion

        private void frmRASSetupToolTypeRelation_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (bLoadFlag == false)
                {
                    MPCF.FieldClear(this);
                    MPCF.InitListView(lisRelationList);

                    tabRelation_SelectedIndexChanged(null, null);

                    rbtResType.Checked = true;

                    bLoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        #region " MFO & RAS Control Event "

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            udcMFO.GetNext(txtFind.Text);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            if (tabRelation.SelectedTab == tbpMFO)
                udcMFO.RefreshSelectedList();
            else
                chkOnlySettingData_CheckedChanged(null, null);
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisRelationList, this.Text, "");
        }

        private void tabRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(grpCondition);
            MPCF.InitListView(lisRelationList);
            MPCF.ClearList(lisToolList);

            if (tabRelation.SelectedTab == tbpRes)
            {
                SetColumn('2');
                cdvResEvent.Enabled = true;
                cdvToolEvent.Enabled = true;
            }
            else
            {
                SetColumn('1');
                cdvResEvent.Enabled = false;
                cdvToolEvent.Enabled = false;
            }
        }

        private void udcMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.GetTreeView.GetNodeCount(false));
            MPCF.FieldClear(grpCondition);
            MPCF.ClearList(lisToolList);
        }

        private void udcMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.SelectedNode.GetNodeCount(false));
            MPCF.FieldClear(grpCondition);
            MPCF.ClearList(lisToolList);
        }

        private void udcMFO_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            ViewRelationList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper);
        }

        private void udcMFO_GetOnlySetData(object sender, EventArgs e)
        {
            MPCF.FieldClear(pnlRight);
            MPCF.ClearList(lisRelationList);
            MPCF.ClearList(lisToolList);

            ViewMFOSettingDataList();
        }

        private void udcMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(pnlRight);
            MPCF.ClearList(lisRelationList);
            MPCF.ClearList(lisToolList);

            udcMFO_LevelItemSelect(null, null);
        }

        private void tvResList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string s_res_type = "";
            string s_resg_id = "";
            string s_res_id = "";
            char c_rel_level = ' ';

            MPCF.FieldClear(grpCondition);
            MPCF.ClearList(lisToolList);

            if (e.Action == TreeViewAction.Collapse || e.Action == TreeViewAction.Expand || e.Action == TreeViewAction.Unknown) return;

            switch (e.Node.Level)
            {
                case 0:
                    if (rbtFactory.Checked == true)
                    {
                        c_rel_level = 'F';
                    }
                    else if (rbtResType.Checked == true)
                    {
                        c_rel_level = 'T';

                        s_res_type = MPCF.Trim(e.Node.Text);
                        s_res_type = MPCF.SubtractString(s_res_type, ":", false, false);

                        if (e.Node.GetNodeCount(true) < 1)
                        {
                            ViewResourceItem(e.Node);
                        }
                    }
                    else if (rbtResGroup.Checked == true)
                    {
                        c_rel_level = 'G';

                        s_resg_id = MPCF.Trim(e.Node.Text);
                        s_resg_id = MPCF.SubtractString(s_resg_id, ":", false, false);

                        if (e.Node.GetNodeCount(true) < 1)
                        {
                            ViewResourceItem(e.Node);
                        }
                    }
                    break;

                case 1:
                    c_rel_level = 'R';

                    s_res_id = MPCF.Trim(e.Node.Text);
                    s_res_id = MPCF.SubtractString(s_res_id, ":", false, false);
                    break;
            }

            lm_res_rel_level = c_rel_level;
            lm_res_type = s_res_type;
            lm_res_group = s_resg_id;
            lm_res_id = s_res_id;

            ViewRelationList(c_rel_level, s_res_type, s_resg_id, s_res_id);
        }

        private void tvResList_Click(object sender, EventArgs e)
        {
            tvResList.SelectedNode = null;
            MPCF.FieldClear(grpCondition);
            MPCF.ClearList(lisToolList);
        }

        private void rbtResSelLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
                chkOnlySettingData_CheckedChanged(null, null);
        }

        private void chkOnlySettingData_CheckedChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(pnlRight);
            MPCF.ClearList(lisRelationList);
            MPCF.ClearList(lisToolList);

            if (chkOnlySettingData.Checked == true)
            {
                lisResList.Visible = true;
                tvResList.Visible = false;

                ViewResourceSettingDataList();
            }
            else
            {
                lisResList.Visible = false;
                tvResList.Visible = true;

                InitResourceTree();
            }
        }

        private void lisResList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s_res_type = "";
            string s_resg_id = "";
            string s_res_id = "";
            char c_rel_level = ' ';

            if (lisResList.SelectedItems.Count < 1) return;

            if (rbtFactory.Checked == true)
            {
                c_rel_level = 'F';
            }
            else if (rbtResType.Checked == true)
            {
                c_rel_level = 'T';

                s_res_type = MPCF.Trim(lisResList.SelectedItems[0].SubItems[1].Text);
                s_res_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[3].Text);

                if (s_res_id != "")
                    c_rel_level = 'R';
            }
            else if (rbtResGroup.Checked == true)
            {
                c_rel_level = 'G';

                s_resg_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[2].Text);
                s_res_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[3].Text);

                if (s_res_id != "")
                    c_rel_level = 'R';
            }

            lm_res_rel_level = c_rel_level;
            lm_res_type = s_res_type;
            lm_res_group = s_resg_id;
            lm_res_id = s_res_id;

            ViewRelationList(c_rel_level, s_res_type, s_resg_id, s_res_id);
        }



        #endregion

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;

                if (UpdateRelation(MPGC.MP_STEP_CREATE) == false) return;

                if (tabRelation.SelectedTab == tbpMFO)
                    ViewRelationList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper);
                else
                    ViewRelationList(lm_res_rel_level, lm_res_type, lm_res_group, lm_res_id);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;

                if (UpdateRelation(MPGC.MP_STEP_UPDATE) == false) return;

                if (tabRelation.SelectedTab == tbpMFO)
                    ViewRelationList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper);
                else
                    ViewRelationList(lm_res_rel_level, lm_res_type, lm_res_group, lm_res_id);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;

                if (UpdateRelation(MPGC.MP_STEP_DELETE) == false) return;

                if (tabRelation.SelectedTab == tbpMFO)
                    ViewRelationList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper);
                else
                    ViewRelationList(lm_res_rel_level, lm_res_type, lm_res_group, lm_res_id);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void lisRelationList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lisRelationList.SelectedItems.Count > 0)
            {
                MPCF.FieldClear(grpCondition);
                MPCF.ClearList(lisToolList);

                string s_tool_type = null, s_tool_id = null;

                if (tabRelation.SelectedTab == tbpMFO)
                {
                    s_tool_type = MPCF.Trim(lisRelationList.SelectedItems[0].SubItems[(int)ColumnsMFO.TOOL_TYPE].Text);
                    s_tool_id = MPCF.Trim(lisRelationList.SelectedItems[0].SubItems[(int)ColumnsMFO.TOOL_ID].Text);
                    //ViewToolTypeRelation(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, s_tool_type, s_tool_id);

                    cdvToolType.Text = s_tool_type;
                }
                else
                {
                    s_tool_type = MPCF.Trim(lisRelationList.SelectedItems[0].SubItems[(int)ColumnsRAS.TOOL_TYPE].Text);
                    s_tool_id = MPCF.Trim(lisRelationList.SelectedItems[0].SubItems[(int)ColumnsRAS.TOOL_ID].Text);
                    string event_id = MPCF.Trim(lisRelationList.SelectedItems[0].SubItems[(int)ColumnsRAS.EVENT_ID].Text);

                    cdvToolType.Text = s_tool_type;
                    cdvResEvent.Text = event_id;

                    ViewToolTypeRelation(lm_res_rel_level, lm_res_type, lm_res_group, lm_res_id, event_id, s_tool_type, s_tool_id);
                }

                ViewToolList();

                int iRow = MPCF.FindListItemIndex(lisToolList, s_tool_id, 0, true);
                if (iRow > 0)
                {
                    lisToolList.Items[iRow].Selected = true;
                    lisToolList.Items[iRow].Focused = true;
                }
            }
        }

        private void cdvToolType_ButtonPress(object sender, EventArgs e)
        {
            cdvToolType.Init();
            MPCF.InitListView(cdvToolType.GetListView);
            cdvToolType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvToolType.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvToolType.SelectedSubItemIndex = 0;
            RASLIST.ViewToolTypeList(cdvToolType.GetListView, '1', 'N', 'N', null);
        }

        private void cdvResEvent_ButtonPress(object sender, EventArgs e)
        {
            string key = "";
            try
            {
                key = lm_res_id;
                if (key == "")
                {
                    if (lm_res_rel_level == 'G')
                    {
                        key = lm_res_group;
                    }
                    else if (lm_res_rel_level == 'T')
                    {
                        key = lm_res_type;
                    }
                }

                cdvResEvent.Init();
                MPCF.InitListView(cdvResEvent.GetListView);
                cdvResEvent.Columns.Add("Event", 50, HorizontalAlignment.Left);
                cdvResEvent.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResEvent.SelectedSubItemIndex = 0;
                if (lm_res_id == "")
                {
                    RASLIST.ViewEventList(cdvResEvent.GetListView, '1', "", null, "");
                }
                else
                {
                    RASLIST.ViewResEventList(cdvResEvent.GetListView, '1', key, null, "");
                }
                cdvResEvent.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvToolEvent_ButtonPress(object sender, EventArgs e)
        {
            string sToolType = MPCF.Trim(cdvToolType.Text);
            string sToolID = "";

            if (sToolType == "") return;
            sToolID = SelectedToolID;

            cdvToolEvent.Init();
            MPCF.InitListView(cdvToolEvent.GetListView);
            cdvToolEvent.Columns.Add("Tool Event", 50, HorizontalAlignment.Left);
            cdvToolEvent.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolEvent.SelectedSubItemIndex = 0;
            if (sToolID == "")
            {
                if (RASLIST.ViewToolEventList(cdvToolEvent.GetListView, '1', sToolType, 'N', null) == false)
                {
                    return;
                }
            }
            else
            {
                if (RASLIST.ViewToolEventRelationList(cdvToolEvent.GetListView, '3', sToolID, sToolType, "", 'N', 'N', null) == false)
                {
                    return;
                }
            }
            cdvToolEvent.InsertEmptyRow(0, 1);
        }

        private void cdvToolType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (this.ActiveControl == (Control)cdvToolType)
            {
                if (lisRelationList.SelectedIndices.Count > 0)
                {
                    lisRelationList.SelectedIndices.Clear();
                }

                MPCF.ClearList(lisToolList);
                ViewToolList();
            }
        }

        private void lisToolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == (Control)lisToolList)
            {
                if (lisRelationList.SelectedIndices.Count > 0)
                {
                    lisRelationList.SelectedIndices.Clear();
                }
                MPCF.ClearList(cdvResEvent);
                MPCF.ClearList(cdvToolEvent);
            }
        }

        private void cdvResEvent_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (this.ActiveControl == (Control)cdvResEvent)
            {
                if (lisRelationList.SelectedIndices.Count > 0)
                {
                    lisRelationList.SelectedIndices.Clear();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lisRelationList.SelectedItems == null || lisRelationList.SelectedItems.Count == 0)
            {
                btnCreate_Click(sender, e);
            }
            else
            {
                btnUpdate_Click(sender, e);
            }
        }

    }
}

//#End If
