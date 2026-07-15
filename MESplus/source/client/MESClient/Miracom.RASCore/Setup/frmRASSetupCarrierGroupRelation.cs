//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupCarrierGroupRelation.cs
//   Description : Carrier group & resource - MFO Relation setup
//
//   MES Version : 4.2.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-11-27 : Created by Aiden
//
//
//   Copyright(C) 1998-2007 MIRACOM,INC.
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

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
namespace Miracom.RASCore
{
    public partial class frmRASSetupCarrierGroupRelation : Miracom.MESCore.SetupForm01
    {
        public frmRASSetupCarrierGroupRelation()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        #endregion

        #region " Variable Definition "
        #endregion

        #region " Function Definition "

        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
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

            switch (MPCF.Trim(FuncName))
            {
                case "ATTACH_GROUP_MFO":

                    if (lisGroupList1.SelectedItems.Count <= 0)
                    {
                        if (lisGroupList1.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisGroupList1.Items[0].Selected = true;
                            lisGroupList1.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_GROUP_MFO":

                    if (lisMFORel.SelectedItems.Count <= 0)
                    {
                        if (lisMFORel.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisMFORel.Items[0].Selected = true;
                            lisMFORel.Focus();
                        }
                        return false;
                    }
                    break;
                case "ATTACH_GROUP_RES":

                    if (lisResRel.Items.Count < 1) return false;

                    if (lisGroupList2.SelectedItems.Count <= 0)
                    {
                        if (lisGroupList2.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisGroupList2.Items[0].Selected = true;
                            lisGroupList2.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_GROUP_RES":

                    if (lisResRel.Items.Count < 1) return false;

                    if (lisResRel.SelectedItems.Count <= 0)
                    {
                        if (lisResRel.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisResRel.Items[0].Selected = true;
                            lisResRel.Focus();
                        }
                        return false;
                    }
                    break;


                case "UPDATE":

                    if (tabRelation.SelectedTab == tbpMFO)
                    {
                        if (lisMFORel.Items.Count < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisMFORel.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if (chkOnlySettingData.Checked == false)
                        {
                            if (tvResList.SelectedNode == null)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                tvResList.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            if (lisResList.SelectedItems.Count < 1)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                lisResList.Focus();
                                return false;
                            }
                        }


                        if (lisResRel.Items.Count < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisResRel.Focus();
                            return false;
                        }
                    }
                    break;
            }

            return true;
        }

        // ViewCarrierMFOOption()
        //       - Get carrier mfo option
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewCarrierMFOOption()
        {
            TRSNode in_node = new TRSNode("Option_In");
            TRSNode out_node = new TRSNode("Option_Out");
          
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                in_node.AddString("MAT_ID", udcMFO.MatID);
                in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                in_node.AddString("FLOW", udcMFO.Flow);
                in_node.AddString("OPER", udcMFO.Oper);

                if (MPCR.CallService("RAS", "RAS_View_Carrier_MFO_Option", in_node, ref out_node) == false)
                {
                    return false;
                }

                
                chkAdHoc.Checked = false;
                chkStart.Checked = false;
                chkEnd.Checked = false;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    switch (out_node.GetList(0)[i].GetChar("CHG_POINT"))
                    {
                        case 'A': // Ad Hoc
                            chkAdHoc.Checked = true;
                            cdvFromTypeAdhoc.Text = out_node.GetList(0)[i].GetString("CUR_TYPE");
                            cdvToTypeAdhoc.Text = out_node.GetList(0)[i].GetString("TO_TYPE");
                            cdvCModeAdhoc.Text = out_node.GetList(0)[i].GetString("CHG_MODE");
                            break;
                        case 'S': // Start
                            chkStart.Checked = true;
                            cdvFromTypeStart.Text = out_node.GetList(0)[i].GetString("CUR_TYPE");
                            cdvToTypeStart.Text = out_node.GetList(0)[i].GetString("TO_TYPE");
                            cdvCModeStart.Text = out_node.GetList(0)[i].GetString("CHG_MODE");
                            break;
                        case 'E': // End
                            chkEnd.Checked = true;
                            cdvFromTypeEnd.Text = out_node.GetList(0)[i].GetString("CUR_TYPE");
                            cdvToTypeEnd.Text = out_node.GetList(0)[i].GetString("TO_TYPE");
                            cdvCModeEnd.Text = out_node.GetList(0)[i].GetString("CHG_MODE");
                            break;
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

        // UpdateCarrierGroupRelation()
        //       - Create/Update/Delete Carrier Group - MFO, RES & Port Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool UpdateCarrierGroupRelation()
        {
            TRSNode in_node = new TRSNode("Relation_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode chg_list;
            TRSNode crr_list;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;

                if (tabRelation.SelectedTab == tbpMFO)
                {
                    in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", udcMFO.MatID);
                    in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                    in_node.AddString("FLOW", udcMFO.Flow);
                    in_node.AddString("OPER", udcMFO.Oper);
                    
                    for (i = 0; i < lisMFORel.Items.Count - 1; i++)
                    {
                        crr_list = in_node.AddNode("CRRG_LIST");
                        crr_list.AddString("CRR_GROUP", lisMFORel.Items[i].SubItems[1].Text);
                        
                    }
                   
                    if (chkAdHoc.Checked == true)
                    {
                        chg_list = in_node.AddNode("CHG_OPT");
                        chg_list.AddChar("CHG_POINT", 'A');
                        chg_list.AddString("CUR_TYPE", MPCF.Trim(cdvFromTypeAdhoc.Text));
                        chg_list.AddString("TO_TYPE",  MPCF.Trim(cdvToTypeAdhoc.Text));
                        chg_list.AddString("CHG_MODE", MPCF.Trim(cdvCModeAdhoc.Text));
                    }
                    if (chkStart.Checked == true)
                    {
                        chg_list = in_node.AddNode("CHG_OPT");
                        chg_list.AddChar("CHG_POINT", 'S');
                        chg_list.AddString("CUR_TYPE",MPCF.Trim(cdvFromTypeStart.Text));
                        chg_list.AddString("TO_TYPE",  MPCF.Trim(cdvToTypeStart.Text));
                        chg_list.AddString("CHG_MODE", MPCF.Trim(cdvCModeStart.Text));
                    }
                    if (chkEnd.Checked == true)
                    {
                        chg_list = in_node.AddNode("CHG_OPT");
                        chg_list.AddChar("CHG_POINT", 'E');
                        chg_list.AddString("CUR_TYPE", MPCF.Trim(cdvFromTypeEnd.Text));
                        chg_list.AddString("TO_TYPE",  MPCF.Trim(cdvToTypeEnd.Text));
                        chg_list.AddString("CHG_MODE",  MPCF.Trim(cdvCModeEnd.Text));
                    }
                    
                }
                else
                {
                    if (chkOnlySettingData.Checked == false)
                    {
                        if (tvResList.SelectedNode.Level == 0)
                        {
                            in_node.AddChar("REL_LEVEL", 'R');
                            in_node.AddString("RES_ID", MPCF.SubtractString(tvResList.SelectedNode.Text, ":", false, false));

                        }
                        else
                        {
                            in_node.AddChar("REL_LEVEL", 'P');
                            in_node.AddString("RES_ID", MPCF.SubtractString(tvResList.SelectedNode.Parent.Text, ":", false, false));
                            in_node.AddString("PORT_ID", MPCF.SubtractString(tvResList.SelectedNode.Text, ":", false, false));

                        }
                    }
                    else
                    {
                        in_node.AddString("RES_ID", MPCF.Trim(lisResList.SelectedItems[0].SubItems[0].Text));
                        in_node.AddString("PORT_ID", MPCF.Trim(lisResList.SelectedItems[0].SubItems[1].Text));
                        in_node.AddChar("REL_LEVEL", in_node.GetString("PORT_ID") == "" ? 'R' : 'P');

                    }

                   for (i = 0; i < lisResRel.Items.Count - 1; i++)
                    {
                        crr_list = in_node.AddNode("CRRG_LIST");
                        crr_list.AddString("CRR_GROUP", lisResRel.Items[i].SubItems[1].Text);
                    }
                   
                }

                if (MPCR.CallService("RAS", "RAS_Update_Carrier_Group_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // ViewSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewSettingDataList()
        {
            TRSNode in_node = new TRSNode("Sql_In");
            TRSNode out_node = new TRSNode("Sql_Out");
            StringBuilder sb;

            MPCF.InitListView(udcMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddInt("NEXT_ROW", 0);

            sb = new StringBuilder();

            switch (udcMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MRASCGRREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT MAT_ID, MAT_VER, OPER FROM MRASCGRREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER FROM MRASCGRREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER FROM MRASCGRREL ");
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
                
            } while (in_node.GetInt("NEXT_ROW") > 0 );

            return true;
        }

        //
        // ViewResourceCondition()
        //       - Get resource List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private void ViewResourceCondition()
        {
            if (chkOnlySettingData.Checked == false)
            {
                MPCF.InitTreeView(tvResList);
                RASLIST.ViewResourceList(tvResList, '1', cdvResGroup.Text, cdvResType.Text, "", "", "", 0, "", "", ' ', "", true, null, "");
            }
            else
            {
                ViewResourceSettingDataList();
            }
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
            TRSNode in_node = new TRSNode("Sql_In");
            TRSNode out_node = new TRSNode("Sql_Out");
            StringBuilder sb;

            MPCF.InitListView(lisResList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddInt("NEXT_ROW", 0);

            sb = new StringBuilder();

            sb.Append("SELECT RES_ID, PORT_ID FROM MRASCGRREL ");
            sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL IN ('R', 'P') ");
            sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER = ' ' ");

            if (MPCF.Trim(cdvResType.Text) != "" || MPCF.Trim(cdvResGroup.Text) != "")
            {
                sb.Append("AND RES_ID IN ( ");
                sb.Append("SELECT RES_ID FROM MRASRESDEF WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                if (MPCF.Trim(cdvResType.Text) != "")
                {
                    sb.Append("AND RES_TYPE = '" + MPCF.Trim(cdvResType.Text) + "' ");
                }
                if (MPCF.Trim(cdvResGroup.Text) != "")
                {
                    sb.Append("AND RES_ID IN (SELECT DISTINCT RES_ID FROM MRASRESMFO WHERE FACTORY = '" + MPGV.gsFactory + "' AND RESG_ID = '" + MPCF.Trim(cdvResGroup.Text) + "') ");
                }
                sb.Append(") ");
            }

            sb.Append("GROUP BY RES_ID, PORT_ID ");
            sb.Append("ORDER BY RES_ID ASC, PORT_ID ASC");

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
        
        
        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.udcMFO;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmRASSetupCarrierGroupRelation_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisGroupList1);
            MPCF.InitListView(lisGroupList2);
            MPCF.InitListView(lisMFORel);
            MPCF.InitListView(lisResRel);

            pnlMFORelation_Resize(null, null);
            pnlResRelation_Resize(null, null);

            if (RASLIST.ViewCarrierGroupList(lisGroupList1) == false) return;
            if (RASLIST.ViewCarrierGroupList(lisGroupList2) == false) return;
        }

        // 선택 Level의 말단 노드가 선택되었을 때
        private void udcMFO_LevelItemSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (RASLIST.ViewCarrierGroupList(lisMFORel, udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "") == false) return;
            
            ListViewItem itm = lisMFORel.Items.Add("");
            itm.SubItems.Add("Attach ...");
            itm.SubItems.Add("");

            ViewCarrierMFOOption();
        }

        private void udcMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewSettingDataList();
        }

        private void udcMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            udcMFO_LevelItemSelect(null, null);
        }

        private void pnlMFORelation_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlMFORelation, pnlMFORelLeft, pnlMFORelRight, pnlMFORelMid, 40);
        }

        private void pnlResRelation_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlResRelation, pnlResRelLeft, pnlResRelRight, pnlResRelMid, 40);
        }

        private void btnMFOAdd_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ListViewItem itmX;
                int i;
                int i_insert_pos;
                string s_group;

                if (CheckCondition("ATTACH_GROUP_MFO") == false) return;

                i_insert_pos = lisMFORel.Items.Count - 1;
                if (lisMFORel.SelectedItems.Count > 0)
                    i_insert_pos = lisMFORel.SelectedItems[0].Index;

                for (i = 0; i <= lisGroupList1.SelectedItems.Count - 1; i++)
                {
                    s_group = lisGroupList1.SelectedItems[i].SubItems[0].Text;

                    if (MPCF.FindListItem(lisMFORel, s_group, 1, false) == false)
                    {
                        itmX = lisMFORel.Items.Insert(i_insert_pos, "", (int)SMALLICON_INDEX.IDX_MODULE_DIR);
                        itmX.SubItems.Add(s_group);
                        itmX.SubItems.Add(lisGroupList1.SelectedItems[i].SubItems[1].Text);

                        i_insert_pos++;
                    }
                }

                if (lisGroupList1.SelectedItems.Count == 1)
                {
                    i = lisGroupList1.SelectedItems[0].Index;
                    if (i + 1 < lisGroupList1.Items.Count)
                    {
                        lisGroupList1.Items[i].Selected = false;
                        lisGroupList1.Items[i + 1].Selected = true;
                    }
                }

                for (i = 1; i < lisMFORel.Items.Count; i++)
                {
                    lisMFORel.Items[i - 1].SubItems[0].Text = i.ToString();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnMFODel_Click(System.Object sender, System.EventArgs e)
        {
            int i;

            if (CheckCondition("DETACH_GROUP_MFO") == false) return;

            for (i = lisMFORel.SelectedItems.Count - 1; i >= 0; i--)
            {
                if (lisMFORel.SelectedItems[i].SubItems[1].Text != "Attach ...")
                {
                    lisMFORel.Items.RemoveAt(lisMFORel.SelectedItems[i].Index);
                }
            }

            for (i = 1; i < lisMFORel.Items.Count; i++)
            {
                lisMFORel.Items[i - 1].SubItems[0].Text = i.ToString();
            }
        }

        private void btnMFOUp_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next;
            int i_list_index;
            string s_group;
            string s_desc;

            if (lisMFORel.SelectedItems.Count < 1) return;

            try
            {

                i_next = 0;
                for (i = 0; i < lisMFORel.SelectedItems.Count; i++)
                {
                    if (lisMFORel.SelectedItems[i].SubItems[1].Text != "Attach ...")
                    {
                        i_list_index = lisMFORel.SelectedItems[i].Index;
                        if (i_list_index > i_next)
                        {
                            s_group = lisMFORel.Items[i_list_index].SubItems[1].Text;
                            lisMFORel.Items[i_list_index].SubItems[1].Text = lisMFORel.Items[i_list_index - 1].SubItems[1].Text;
                            lisMFORel.Items[i_list_index - 1].SubItems[1].Text = s_group;

                            s_desc = lisMFORel.Items[i_list_index].SubItems[2].Text;
                            lisMFORel.Items[i_list_index].SubItems[2].Text = lisMFORel.Items[i_list_index - 1].SubItems[2].Text;
                            lisMFORel.Items[i_list_index - 1].SubItems[2].Text = s_desc;

                            lisMFORel.Items[i_list_index].Selected = false;
                            lisMFORel.Items[i_list_index - 1].Selected = true;
                        }

                        if (i_list_index == i_next)
                        {
                            i_next++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnMFODown_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next;
            int i_list_index;
            string s_group;
            string s_desc;

            if (lisMFORel.SelectedItems.Count < 1) return;

            try
            {
                i_next = lisMFORel.Items.Count - 2;
                for (i = lisMFORel.SelectedItems.Count - 1; i >= 0; i--)
                {
                    if (lisMFORel.SelectedItems[i].SubItems[1].Text != "Attach ...")
                    {
                        i_list_index = lisMFORel.SelectedItems[i].Index;
                        if (i_list_index < i_next)
                        {
                            s_group = lisMFORel.Items[i_list_index].SubItems[1].Text;
                            lisMFORel.Items[i_list_index].SubItems[1].Text = lisMFORel.Items[i_list_index + 1].SubItems[1].Text;
                            lisMFORel.Items[i_list_index + 1].SubItems[1].Text = s_group;

                            s_desc = lisMFORel.Items[i_list_index].SubItems[2].Text;
                            lisMFORel.Items[i_list_index].SubItems[2].Text = lisMFORel.Items[i_list_index + 1].SubItems[2].Text;
                            lisMFORel.Items[i_list_index + 1].SubItems[2].Text = s_desc;

                            lisMFORel.Items[i_list_index].Selected = false;
                            lisMFORel.Items[i_list_index + 1].Selected = true;
                        }

                        if (i_list_index == i_next)
                        {
                            i_next--;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkAdHoc_CheckedChanged(object sender, EventArgs e)
        {
            cdvFromTypeAdhoc.Text = "";
            cdvToTypeAdhoc.Text = "";
            cdvCModeAdhoc.Text = "";

            cdvFromTypeAdhoc.Enabled = chkAdHoc.Checked;
            cdvToTypeAdhoc.Enabled = chkAdHoc.Checked;
            cdvCModeAdhoc.Enabled = chkAdHoc.Checked;
        }

        private void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            cdvFromTypeStart.Text = "";
            cdvToTypeStart.Text = "";
            cdvCModeStart.Text = "";

            cdvFromTypeStart.Enabled = chkStart.Checked;
            cdvToTypeStart.Enabled = chkStart.Checked;
            cdvCModeStart.Enabled = chkStart.Checked;
        }

        private void chkEnd_CheckedChanged(object sender, EventArgs e)
        {
            cdvFromTypeEnd.Text = "";
            cdvToTypeEnd.Text = "";
            cdvCModeEnd.Text = "";

            cdvFromTypeEnd.Enabled = chkEnd.Checked;
            cdvToTypeEnd.Enabled = chkEnd.Checked;
            cdvCModeEnd.Enabled = chkEnd.Checked;
        }

        private void cdvFromType_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            if (cdvTemp.AddEmptyRow(1) == false) return;
        }

        private void cdvToType_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            if (cdvTemp.AddEmptyRow(1) == false) return;
        }

        private void cdvCMode_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            ListViewItem itm;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Change Mode", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;

            itm = new ListViewItem("ST", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itm.SubItems.Add("Standard");
            cdvTemp.GetListView.Items.Add(itm);
            itm = new ListViewItem("SF", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itm.SubItems.Add("Standard Fill");
            cdvTemp.GetListView.Items.Add(itm);
            itm = new ListViewItem("XC", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itm.SubItems.Add("X-Cross");
            cdvTemp.GetListView.Items.Add(itm);
            itm = new ListViewItem("XF", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itm.SubItems.Add("X-Cross Fill");
            cdvTemp.GetListView.Items.Add(itm);
            itm = new ListViewItem("AD", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itm.SubItems.Add("Ad Hoc");
            cdvTemp.GetListView.Items.Add(itm);

            if (cdvTemp.AddEmptyRow(1) == false) return;
        }

        private void cdvResType_ButtonPress(object sender, EventArgs e)
        {
            cdvResType.Init();
            MPCF.InitListView(cdvResType.GetListView);
            cdvResType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvResType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvResType.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
            if (cdvResType.InsertEmptyRow(0, 1) == false) return;
        }

        private void cdvResGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvResGroup.Init();
            MPCF.InitListView(cdvResGroup.GetListView);
            cdvResGroup.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvResGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceGroupList(cdvResGroup.GetListView, '1');
            if (cdvResGroup.InsertEmptyRow(0, 1) == false) return;
        }

        private void cdvResType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            ViewResourceCondition();
        }

        private void cdvResGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            ViewResourceCondition();
        }

        private void tabRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabRelation.SelectedTab == tbpResource)
            {
                ViewResourceCondition();
            }
        }

        private void chkOnlySettingData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnlySettingData.Checked == true)
            {
                lisResList.Visible = true;
                tvResList.Visible = false;
            }
            else
            {
                lisResList.Visible = false;
                tvResList.Visible = true;
            }

            ViewResourceCondition();
        }

        private void tvResList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;
            if (e.Action == TreeViewAction.Collapse) return;
            if (e.Action == TreeViewAction.Expand) return;

            string s_res_id;
            string s_port_id;

            if (e.Node.Level == 0)
            {
                s_res_id = MPCF.SubtractString(e.Node.Text, ":", false, false);

                if (e.Node.Nodes.Count < 1)
                {
                    RASLIST.ViewPortList(tvResList, '1', s_res_id, "", e.Node, "");
                }

                if (RASLIST.ViewCarrierGroupList(lisResRel, 'R', "", 0, "", "", s_res_id, "") == false) return;
            }
            else
            {
                s_res_id = MPCF.SubtractString(e.Node.Parent.Text, ":", false, false);
                s_port_id = MPCF.SubtractString(e.Node.Text, ":", false, false);

                if (RASLIST.ViewCarrierGroupList(lisResRel, 'P', "", 0, "", "", s_res_id, s_port_id) == false) return;
            }

            ListViewItem itm = lisResRel.Items.Add("");
            itm.SubItems.Add("Attach ...");
            itm.SubItems.Add("");
        }

        private void lisResList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s_res_id;
            string s_port_id;
            char c_rel_level;

            if (lisResList.SelectedItems.Count < 1) return;

            s_res_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[0].Text);
            s_port_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[1].Text);
            c_rel_level = s_port_id == "" ? 'R' : 'P';

            if (RASLIST.ViewCarrierGroupList(lisResRel, c_rel_level, "", 0, "", "", s_res_id, s_port_id) == false) return;

            ListViewItem itm = lisResRel.Items.Add("");
            itm.SubItems.Add("Attach ...");
            itm.SubItems.Add("");
        }

        private void btnResAdd_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ListViewItem itmX;
                int i;
                int i_insert_pos;
                string s_group;

                if (CheckCondition("ATTACH_GROUP_RES") == false) return;

                i_insert_pos = lisResRel.Items.Count - 1;
                if (lisResRel.SelectedItems.Count > 0)
                    i_insert_pos = lisResRel.SelectedItems[0].Index;

                for (i = 0; i <= lisGroupList2.SelectedItems.Count - 1; i++)
                {
                    s_group = lisGroupList2.SelectedItems[i].SubItems[0].Text;

                    if (MPCF.FindListItem(lisResRel, s_group, 1, false) == false)
                    {
                        itmX = lisResRel.Items.Insert(i_insert_pos, "", (int)SMALLICON_INDEX.IDX_MODULE_DIR);
                        itmX.SubItems.Add(s_group);
                        itmX.SubItems.Add(lisGroupList2.SelectedItems[i].SubItems[1].Text);

                        i_insert_pos++;
                    }
                }

                if (lisGroupList2.SelectedItems.Count == 1)
                {
                    i = lisGroupList2.SelectedItems[0].Index;
                    if (i + 1 < lisGroupList2.Items.Count)
                    {
                        lisGroupList2.Items[i].Selected = false;
                        lisGroupList2.Items[i + 1].Selected = true;
                    }
                }

                for (i = 1; i < lisResRel.Items.Count; i++)
                {
                    lisResRel.Items[i - 1].SubItems[0].Text = i.ToString();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnResDel_Click(System.Object sender, System.EventArgs e)
        {
            int i;

            if (CheckCondition("DETACH_GROUP_RES") == false) return;

            for (i = lisResRel.SelectedItems.Count - 1; i >= 0; i--)
            {
                if (lisResRel.SelectedItems[i].SubItems[1].Text != "Attach ...")
                {
                    lisResRel.Items.RemoveAt(lisResRel.SelectedItems[i].Index);
                }
            }

            for (i = 1; i < lisResRel.Items.Count; i++)
            {
                lisResRel.Items[i - 1].SubItems[0].Text = i.ToString();
            }
        }

        private void btnResUp_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next;
            int i_list_index;
            string s_group;
            string s_desc;

            if (lisResRel.SelectedItems.Count < 1) return;

            try
            {

                i_next = 0;
                for (i = 0; i < lisResRel.SelectedItems.Count; i++)
                {
                    if (lisResRel.SelectedItems[i].SubItems[1].Text != "Attach ...")
                    {
                        i_list_index = lisResRel.SelectedItems[i].Index;
                        if (i_list_index > i_next)
                        {
                            s_group = lisResRel.Items[i_list_index].SubItems[1].Text;
                            lisResRel.Items[i_list_index].SubItems[1].Text = lisResRel.Items[i_list_index - 1].SubItems[1].Text;
                            lisResRel.Items[i_list_index - 1].SubItems[1].Text = s_group;

                            s_desc = lisResRel.Items[i_list_index].SubItems[2].Text;
                            lisResRel.Items[i_list_index].SubItems[2].Text = lisResRel.Items[i_list_index - 1].SubItems[2].Text;
                            lisResRel.Items[i_list_index - 1].SubItems[2].Text = s_desc;

                            lisResRel.Items[i_list_index].Selected = false;
                            lisResRel.Items[i_list_index - 1].Selected = true;
                        }

                        if (i_list_index == i_next)
                        {
                            i_next++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnResDown_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next;
            int i_list_index;
            string s_group;
            string s_desc;

            if (lisResRel.SelectedItems.Count < 1) return;

            try
            {
                i_next = lisResRel.Items.Count - 2;
                for (i = lisResRel.SelectedItems.Count - 1; i >= 0; i--)
                {
                    if (lisResRel.SelectedItems[i].SubItems[1].Text != "Attach ...")
                    {
                        i_list_index = lisResRel.SelectedItems[i].Index;
                        if (i_list_index < i_next)
                        {
                            s_group = lisResRel.Items[i_list_index].SubItems[1].Text;
                            lisResRel.Items[i_list_index].SubItems[1].Text = lisResRel.Items[i_list_index + 1].SubItems[1].Text;
                            lisResRel.Items[i_list_index + 1].SubItems[1].Text = s_group;

                            s_desc = lisResRel.Items[i_list_index].SubItems[2].Text;
                            lisResRel.Items[i_list_index].SubItems[2].Text = lisResRel.Items[i_list_index + 1].SubItems[2].Text;
                            lisResRel.Items[i_list_index + 1].SubItems[2].Text = s_desc;

                            lisResRel.Items[i_list_index].Selected = false;
                            lisResRel.Items[i_list_index + 1].Selected = true;
                        }

                        if (i_list_index == i_next)
                        {
                            i_next--;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("UPDATE") == false) return;

            if (UpdateCarrierGroupRelation() == false) return;

            
        }

        private void btnMFORelExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;


                sCond = "Material : " + udcMFO.MatID + ", Flow : " + udcMFO.Flow + ", Operation : " + udcMFO.Oper;


                MPCF.ExportToExcel(lisMFORel, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnResCrrGrp_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;

                if (tvResList.SelectedNode == null)
                    return;

                sCond ="Resource : " + tvResList.SelectedNode.Text;


                MPCF.ExportToExcel(lisResRel, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }
}

