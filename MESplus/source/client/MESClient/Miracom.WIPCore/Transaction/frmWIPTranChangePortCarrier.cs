//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranChangePortCarrier.vb
//   Description : Change port status and carrier
//
//   MES Version : 4.2.0.0
//
//   Function List

//       - CheckCondition()        : Check the conditions before transaction
//       - Update_Carrier_Lot() : Create/Update/Delete Carrier - Lot Relation
//       - SelectClear()           : Clear Selected Items
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-12-10 : Created by Aiden
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

using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPTranChangePortCarrier : Miracom.MESCore.TranForm01
    {
        public frmWIPTranChangePortCarrier()
        {
            InitializeComponent();
        }

        #region " Variable Definition "
        private bool b_load_flag;
        private ChangePortCarrierLayout m_layout = ChangePortCarrierLayout.PORT_and_CARRIER;

        private string s_mat_id;
        private int i_mat_ver;
        private string s_flow;
        private string s_oper;
        private char c_change_point;

        private TRSNode m_port_in = null;
        private TRSNode m_crr_in = null;

        #endregion

        #region " Function Definition "

        //
        // Change_Carrier()
        //       -  Change carrier
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - 
        //
        private bool Change_Port_Carrier()
        {
            int i;
            TRSNode list_item;

            try
            {
                if (m_layout == ChangePortCarrierLayout.PORT || m_layout == ChangePortCarrierLayout.PORT_and_CARRIER)
                {
                    if (MPCF.CheckValue(cdvPortID, 1) == false) return false;
                    if (MPCF.CheckValue(cdvTrsState, 1) == false) return false;
                    if (cdvPortCarrier.Items.Count > 0)
                    {
                        if (MPCF.CheckValue(cdvPortCarrier, 1) == false) return false;
                    }

                    MPCR.SetInMsg(m_port_in);
                    m_port_in.ProcStep = '1';

                    m_port_in.AddString("RES_ID", txtResID.Text);
                    m_port_in.AddString("SUBRES_ID", cdvSubResID.Text);
                    m_port_in.AddString("PORT_ID", cdvPortID.Text);
                    m_port_in.AddString("TRS_STATE", cdvTrsState.Text);

                    if (c_change_point == 'S')
                    {
                        m_port_in.AddString("LOT_ID", txtLotID.Text);
                        m_port_in.AddString("CRR_ID", cdvPortCarrier.Text);
                    }
                    else if (c_change_point == 'E')
                    {
                        m_port_in.AddString("LOT_ID", "");
                        m_port_in.AddString("CRR_ID", "");
                    }
                }

                if (m_layout == ChangePortCarrierLayout.CARRIER || m_layout == ChangePortCarrierLayout.PORT_and_CARRIER)
                {
                    //if (MPCF.CheckValue(cdvTargetCarrier, 1) == false) return false;

                    MPCR.SetInMsg(m_crr_in);
                    m_crr_in.ProcStep = '1';

                    m_crr_in.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                    m_crr_in.AddString("CRR_ID", MPCF.Trim(cdvSourceCarrier.Text));
                    m_crr_in.AddString("NEW_CRR_ID", MPCF.Trim(cdvTargetCarrier.Text));

                    for (i = 0; i < lisTarget.Items.Count; i++)
                    {
                        if (MPCF.Trim(lisTarget.Items[i].SubItems[1].Text) != "")
                        {
                            list_item = m_crr_in.AddNode("SUBLOT");

                            list_item.AddString("SUBLOT_ID", MPCF.Trim(lisTarget.Items[i].SubItems[1].Text));
                            list_item.AddInt("NEW_SLOT_NO", i + 1);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }

        // View_Carrier()
        //       -  View Carrier
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCarrier(bool is_source_carrier, string s_crr_id)
        {

            TRSNode in_node = new TRSNode("View_Carrier_In");
            TRSNode out_node = new TRSNode("View_Carrier_Out");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_ID", MPCF.Trim(s_crr_id));

                if (MPCR.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (is_source_carrier == true)
                {
                    cdvSourceGroup.Text = out_node.GetString("CRR_GROUP");
                    cdvSourceType.Text = out_node.GetString("CRR_TYPE1");
                }
                else
                {
                    cdvTargetGroup.Text = out_node.GetString("CRR_GROUP");
                    cdvTargetType.Text = out_node.GetString("CRR_TYPE1");
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
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

                in_node.AddChar("REL_LEVEL", ' ');
                in_node.AddString("MAT_ID", s_mat_id);
                in_node.AddInt("MAT_VER", i_mat_ver);
                in_node.AddString("FLOW", s_flow);
                in_node.AddString("OPER", s_oper);

                if (MPCR.CallService("RAS", "RAS_View_Carrier_MFO_Option", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (c_change_point == out_node.GetList(0)[i].GetChar("CHG_POINT"))
                    {
                        cdvSourceType.Text = out_node.GetList(0)[i].GetString("CUR_TYPE");
                        cdvTargetType.Text = out_node.GetList(0)[i].GetString("TO_TYPE");

                        if (out_node.GetList(0)[i].GetString("CHG_MODE") != "")
                        {
                            switch (out_node.GetList(0)[i].GetString("CHG_MODE"))
                            {
                                case "ST":
                                    btnSF.Enabled = false;
                                    btnXC.Enabled = false;
                                    btnXF.Enabled = false;
                                    break;
                                case "SF":
                                    btnST.Enabled = false;
                                    btnXC.Enabled = false;
                                    btnXF.Enabled = false;
                                    break;
                                case "XC":
                                    btnST.Enabled = false;
                                    btnSF.Enabled = false;
                                    btnXF.Enabled = false;
                                    break;
                                case "XF":
                                    btnST.Enabled = false;
                                    btnSF.Enabled = false;
                                    btnXC.Enabled = false;
                                    break;
                            }
                        }
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


        private bool ViewSublotList(string sLotId)
        {

            int i;
            int ii;
            ListViewItem itm;

            TRSNode in_node = new TRSNode("View_Sublot_List_In");
            TRSNode out_node = new TRSNode("View_Sublot_List_Out");

            MPCF.InitListView(lisSource);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

            ii = 0;
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itm = new ListViewItem("", (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");

                    lisSource.Items.Add(itm);
                }

                for (i = 0; i < out_node.GetList(0).Count; i++, ii++)
                {
                    for (; ii + 1 < out_node.GetList(0)[i].GetInt("SLOT_NO"); ii++)
                    {
                        itm = new ListViewItem(((int)(ii + 1)).ToString(), (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                        itm.SubItems.Add("");
                        itm.SubItems.Add("");
                        itm.SubItems.Add("");

                        lisSource.Items.Insert(ii, itm);
                    }

                    lisSource.Items[ii].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                    lisSource.Items[ii].Text = out_node.GetList(0)[i].GetInt("SLOT_NO").ToString();
                    lisSource.Items[ii].SubItems[1].Text = out_node.GetList(0)[i].GetString("SUBLOT_ID");
                    lisSource.Items[ii].SubItems[2].Text = MPCF.Trim(sLotId);
                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            lisSource.Tag = "NOT_CHANGE";

            return true;

        }

        
        public void SetLayout(ChangePortCarrierLayout layout)
        {
            m_layout = layout;

            cdvPortCarrier.VisibleButton = false;
            cdvPortCarrier.ReadOnly = true;
            cdvPortCarrier.BackColor = SystemColors.Control;

            cdvSourceGroup.BackColor = SystemColors.Control;
            cdvSourceType.BackColor = SystemColors.Control;
            cdvTargetType.BackColor = SystemColors.Control;

            switch (m_layout)
            {
                case ChangePortCarrierLayout.PORT:
                    this.Height = pnlChangePortStatus.Height + pnlBottom.Height + 32;
                    pnlCarrierMap.Visible = false;
                    grpExchange.Visible = false;

                    cdvPortCarrier.VisibleButton = true;
                    cdvPortCarrier.ReadOnly = false;
                    cdvPortCarrier.BackColor = SystemColors.Window;

                    chkUseTargetCarrier.Visible = false;
                    break;

                case ChangePortCarrierLayout.CARRIER:
                    this.Height = pnlCarrierMap.Height + pnlBottom.Height + 32;
                    pnlChangePortStatus.Visible = false;
                    grpExchange.Visible = true;
                    break;
            }
        }

        public void SetInformation(string s_lot_id, string s_lot_desc, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, 
                                   string s_res_id, char c_change_point, string s_start_port_id, ref TRSNode port_in, ref TRSNode crr_in)
        {
            txtLotID.Text = s_lot_id;
            txtLotDesc.Text = s_lot_desc;
            txtResID.Text = s_res_id;
            cdvPortID.Text = s_start_port_id;

            this.s_mat_id = s_mat_id;
            this.i_mat_ver = i_mat_ver;
            this.s_flow = s_flow;
            this.s_oper = s_oper;
            this.c_change_point = c_change_point;
            this.m_port_in = port_in;
            this.m_crr_in = crr_in;

            if (this.c_change_point == 'S')
            {
                cdvTrsState.Text = "TB";
            }
            else if (this.c_change_point == 'E')
            {
                cdvTrsState.Text = "RTU";
            }
        }


        #endregion

        private void frmWIPTranChangePortCarrier_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                if (m_layout == ChangePortCarrierLayout.PORT)
                {
                    cdvPortCarrier_ButtonPress(null, null);
                    if (cdvPortCarrier.Items.Count == 1)
                    {
                        cdvPortCarrier.Text = cdvPortCarrier.Items[0].Text;
                    }
                }
                else
                {
                    pnlCarrierMap_Resize(null, null);

                    MPCF.InitListView(lisSource);
                    MPCF.InitListView(lisTarget);

                    if (ViewCarrierMFOOption() == false) return;
                    cdvSourceCarrier_ButtonPress(null, null);
                    if (cdvSourceCarrier.Items.Count < 1)
                    {
                        if (ViewSublotList(txtLotID.Text) == false) return;
                    }
                    else if (cdvSourceCarrier.Items.Count == 1)
                    {
                        cdvSourceCarrier.Text = cdvSourceCarrier.Items[0].Text;
                        cdvSourceCarrier_SelectedItemChanged(null, null);
                    }
                }

                b_load_flag = true;
            }
        }

        private void pnlCarrierMap_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(grpChangeCarrier, pnlMapSource, pnlMapTarget, pnlMapCenter, 60);
        }

        private void chkUseTargetCarrier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseTargetCarrier.Checked == true)
            {
                cdvPortCarrier.Text = cdvTargetCarrier.Text;
            }
            else
            {
                cdvPortCarrier.Text = cdvSourceCarrier.Text;
            }
        }

        private void cdvSubResID_ButtonPress(object sender, EventArgs e)
        {
            cdvSubResID.Init();
            MPCF.InitListView(cdvSubResID.GetListView);
            cdvSubResID.Columns.Add("Sub Resource ID", 50, HorizontalAlignment.Left);
            cdvSubResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSubResID.SelectedSubItemIndex = 0;
            RASLIST.ViewSubResourceList(cdvSubResID.GetListView, '1', txtResID.Text);
        }

        private void cdvPortID_ButtonPress(object sender, EventArgs e)
        {
            cdvPortID.Init();
            MPCF.InitListView(cdvPortID.GetListView);
            cdvPortID.Columns.Add("Port ID", 50, HorizontalAlignment.Left);
            cdvPortID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvPortID.SelectedSubItemIndex = 0;
            RASLIST.ViewPortList(cdvPortID.GetListView, '2', txtResID.Text, "");
        }

        private void cdvPortCarrier_ButtonPress(object sender, EventArgs e)
        {
            cdvPortCarrier.Init();
            MPCF.InitListView(cdvPortCarrier.GetListView);
            cdvPortCarrier.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvPortCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvPortCarrier.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierList(cdvPortCarrier.GetListView, txtLotID.Text);
        }

        private void cdvSourceCarrier_ButtonPress(object sender, EventArgs e)
        {
            cdvSourceCarrier.Init();
            MPCF.InitListView(cdvSourceCarrier.GetListView);
            cdvSourceCarrier.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvSourceCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSourceCarrier.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierList(cdvSourceCarrier.GetListView, '1', "", cdvSourceType.Text, txtLotID.Text, "");
        }

        private void cdvSourceCarrier_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvSourceCarrier.Text) == "")
            {
                lisSource.Items.Clear();
                return;
            }

            if (MPCF.Trim(cdvTargetCarrier.Text) != "")
            {
                if (MPCF.Trim(cdvSourceCarrier.Text) == MPCF.Trim(cdvTargetCarrier.Text))
                {
                    cdvSourceCarrier.Text = "";
                    lisSource.Items.Clear();
                    MPCF.ShowMsgBox(MPCF.GetMessage(251));
                    return;
                }
            }

            if (ViewCarrier(true, cdvSourceCarrier.Text) == false) return;
            if (RASLIST.ViewCarrierSublotList(lisSource, '1', cdvSourceCarrier.Text) == false) return;
            lisSource.Tag = "NOT_CHANGE";

            if (chkUseTargetCarrier.Checked == false)
            {
                cdvPortCarrier.Text = cdvSourceCarrier.Text;
            }

            if (MPCF.Trim(cdvTargetCarrier.Text) != "")
            {
                cdvTargetCarrier_SelectedItemChanged(null, null);
            }
        }

        private void cdvTargetGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvTargetGroup.Init();
            MPCF.InitListView(cdvTargetGroup.GetListView);
            cdvTargetGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvTargetGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTargetGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierGroupList(cdvTargetGroup.GetListView, ' ', s_mat_id, i_mat_ver, s_flow, s_oper, txtResID.Text, cdvPortID.Text);
            cdvTargetGroup.InsertEmptyRow(0, 1);
        }

        private void cdvTargetGroup_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvTargetGroup.Text) != "")
            {
                cdvTargetCarrier.Text = "";
            }
        }

        private void cdvTargetCarrier_ButtonPress(object sender, EventArgs e)
        {
            cdvTargetCarrier.Init();
            MPCF.InitListView(cdvTargetCarrier.GetListView);
            cdvTargetCarrier.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvTargetCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTargetCarrier.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierList(cdvTargetCarrier.GetListView, '1', cdvTargetGroup.Text, cdvTargetType.Text, "", ' ', s_mat_id, i_mat_ver, s_flow, s_oper, txtResID.Text, cdvPortID.Text, cdvTargetCarrier.Text, null, "");
            cdvTargetCarrier.InsertEmptyRow(0, 1);
        }

        private void cdvTargetCarrier_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            int i;

            if (MPCF.Trim(cdvTargetCarrier.Text) == "")
            {
                lisTarget.Items.Clear();
                return;
            }

            if (MPCF.Trim(cdvSourceCarrier.Text) != "")
            {
                if (MPCF.Trim(cdvSourceCarrier.Text) == MPCF.Trim(cdvTargetCarrier.Text))
                {
                    cdvTargetCarrier.Text = "";
                    lisTarget.Items.Clear();
                    MPCF.ShowMsgBox(MPCF.GetMessage(251));
                    return;
                }
            }

            if (ViewCarrier(false, cdvTargetCarrier.Text) == false) return;
            if (RASLIST.ViewCarrierSublotList(lisTarget, '1', cdvTargetCarrier.Text) == false) return;
            lisTarget.Tag = "NOT_CHANGE";

            if (chkUseTargetCarrier.Checked == true)
            {
                cdvPortCarrier.Text = cdvTargetCarrier.Text;
            }

            for (i = 0; i < lisTarget.Items.Count; i++)
            {
                if (MPCF.Trim(lisTarget.Items[i].SubItems[1].Text) != "") break;
            }

            if (MPCF.Trim(lisSource.Tag) == "CHANGE")
            {
                for (i = 0; i < lisSource.Items.Count; i++)
                {
                    if (MPCF.Trim(lisSource.Items[i].SubItems[1].Text) == "")
                        lisSource.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                    else
                        lisSource.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                    lisSource.Items[i].SubItems[3].Text = "";
                }
                lisSource.Tag = "NOT_CHANGE";
            }
        }

        private void cdvSourceCarrier_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cdvSourceCarrier_SelectedItemChanged(null, null);
            }
        }

        private void cdvSourceCarrier_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvSourceCarrier.Text) == "")
            {
                cdvSourceCarrier_SelectedItemChanged(null, null);
            }
        }

        private void cdvTargetCarrier_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cdvTargetCarrier_SelectedItemChanged(null, null);
            }
        }

        private void cdvTargetCarrier_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvTargetCarrier.Text) == "")
            {
                cdvTargetCarrier_SelectedItemChanged(null, null);
            }
        }

        private void cdvPortCarrier_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvPortCarrier.Items.Count < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(254));
                    cdvPortCarrier.Text = "";
                    return;
                }
                else
                {
                    if (MPCF.FindListItem(cdvPortCarrier.GetListView, cdvPortCarrier.Text, false) == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(255));
                        cdvPortCarrier.Text = "";
                        return;
                    }
                }
            }
        }

        private void btnInsert_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_start_idx = 0;
            bool b_change;

            try
            {
                if (MPCF.CheckValue(cdvTargetCarrier, 1) == false) return;
                if (lisSource.Items.Count < 1) return;
                if (lisTarget.Items.Count < 1) return;
                if (lisSource.SelectedItems.Count < 1) return;

                b_change = false;
                if (lisTarget.SelectedItems.Count < 1) i_start_idx = 0;
                else i_start_idx = lisTarget.SelectedItems[0].Index;

                for (i = 0; i < lisSource.SelectedItems.Count; i++)
                {
                    if (lisSource.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        if (MPCF.Trim(lisSource.SelectedItems[i].SubItems[2].Text) == txtLotID.Text)
                        {
                            if (lisTarget.Items[i_start_idx].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_EMPTY) break;

                            if (MPCF.FindListItem(lisTarget, lisSource.SelectedItems[i].SubItems[1].Text, 1, false) == false)
                            {
                                lisTarget.Items[i_start_idx].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW;
                                lisTarget.Items[i_start_idx].SubItems[1].Text = lisSource.SelectedItems[i].SubItems[1].Text;
                                lisTarget.Items[i_start_idx].SubItems[2].Text = lisSource.SelectedItems[i].SubItems[2].Text;
                                lisTarget.Items[i_start_idx].SubItems[3].Text = lisSource.SelectedItems[i].Text;

                                lisTarget.Items[i_start_idx].Selected = true;
                                lisTarget.Items[i_start_idx].EnsureVisible();
                                lisSource.SelectedItems[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                                lisSource.SelectedItems[i].SubItems[3].Text = ((int)(i_start_idx + 1)).ToString();

                                b_change = true;

                                i_start_idx++;
                                if (i_start_idx > lisTarget.Items.Count - 1) break;
                            }
                        }
                    }
                }

                if (b_change == true)
                {
                    lisSource.Tag = "CHANGE";
                    lisTarget.Tag = "CHANGE";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnReject_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_source_index = 0;
            bool b_change;

            try
            {
                if (lisSource.Items.Count < 1) return;
                if (lisTarget.Items.Count < 1) return;
                if (lisTarget.SelectedItems.Count < 1) return;

                b_change = false;
                for (i = 0; i < lisTarget.SelectedItems.Count; i++)
                {
                    if (lisTarget.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW)
                    {
                        i_source_index = MPCF.ToInt(lisTarget.SelectedItems[i].SubItems[3].Text) - 1;
                        if (lisSource.Items[i_source_index].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_EMPTY) break;

                        lisSource.Items[i_source_index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                        lisSource.Items[i_source_index].SubItems[3].Text = "";
                        lisSource.Items[i_source_index].Selected = true;
                        lisSource.Items[i_source_index].EnsureVisible();
                        lisTarget.SelectedItems[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                        lisTarget.SelectedItems[i].SubItems[1].Text = "";
                        lisTarget.SelectedItems[i].SubItems[2].Text = "";
                        lisTarget.SelectedItems[i].SubItems[3].Text = "";

                        b_change = true;
                    }
                }

                if (b_change == true)
                {
                    lisSource.Tag = "CHANGE";
                    lisTarget.Tag = "CHANGE";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUp_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next;
            int i_list_index;
            int i_image_index;
            int i_source_index;
            string s_temp;
            bool b_change_source;
            bool b_change_target;

            if (lisTarget.SelectedItems.Count < 1) return;

            try
            {
                b_change_source = false;
                b_change_target = false;

                i_next = 0;
                for (i = 0; i < lisTarget.Items.Count; i++)
                {
                    if (lisTarget.Items[i].Selected == true &&
                        (lisTarget.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW ||
                         lisTarget.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL))
                    {
                        i_list_index = lisTarget.Items[i].Index;
                        if (i_list_index > i_next)
                        {
                            s_temp = lisTarget.Items[i_list_index].SubItems[1].Text;
                            lisTarget.Items[i_list_index].SubItems[1].Text = lisTarget.Items[i_list_index - 1].SubItems[1].Text;
                            lisTarget.Items[i_list_index - 1].SubItems[1].Text = s_temp;

                            s_temp = lisTarget.Items[i_list_index].SubItems[2].Text;
                            lisTarget.Items[i_list_index].SubItems[2].Text = lisTarget.Items[i_list_index - 1].SubItems[2].Text;
                            lisTarget.Items[i_list_index - 1].SubItems[2].Text = s_temp;

                            s_temp = lisTarget.Items[i_list_index].SubItems[3].Text;
                            lisTarget.Items[i_list_index].SubItems[3].Text = lisTarget.Items[i_list_index - 1].SubItems[3].Text;
                            lisTarget.Items[i_list_index - 1].SubItems[3].Text = s_temp;

                            i_image_index = lisTarget.Items[i_list_index].ImageIndex;
                            lisTarget.Items[i_list_index].ImageIndex = lisTarget.Items[i_list_index - 1].ImageIndex;
                            lisTarget.Items[i_list_index - 1].ImageIndex = i_image_index;

                            lisTarget.Items[i_list_index].Selected = false;
                            lisTarget.Items[i_list_index - 1].Selected = true;

                            i_source_index = MPCF.ToInt(lisTarget.Items[i_list_index].SubItems[3].Text) - 1;
                            if (i_source_index >= 0)
                            {
                                lisSource.Items[i_source_index].SubItems[3].Text = ((int)(i_list_index + 1)).ToString();
                                b_change_source = true;
                            }

                            i_source_index = MPCF.ToInt(lisTarget.Items[i_list_index - 1].SubItems[3].Text) - 1;
                            if (i_source_index >= 0)
                            {
                                lisSource.Items[i_source_index].SubItems[3].Text = i_list_index.ToString();
                                b_change_source = true;
                            }

                            b_change_target = true;
                        }

                        if (i_list_index == i_next)
                        {
                            i_next++;
                        }
                    }
                }

                if (b_change_source == true)
                    lisSource.Tag = "CHANGE";
                if (b_change_target == true)
                    lisTarget.Tag = "CHANGE";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDown_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next;
            int i_list_index;
            int i_image_index;
            int i_source_index;
            string s_temp;
            bool b_change_source;
            bool b_change_target;

            if (lisTarget.SelectedItems.Count < 1) return;

            try
            {
                b_change_source = false;
                b_change_target = false;

                i_next = lisTarget.Items.Count - 1;
                for (i = lisTarget.Items.Count - 1; i >= 0; i--)
                {
                    if (lisTarget.Items[i].Selected == true &&
                        (lisTarget.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW ||
                         lisTarget.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL))
                    {
                        i_list_index = lisTarget.Items[i].Index;
                        if (i_list_index < i_next)
                        {
                            s_temp = lisTarget.Items[i_list_index].SubItems[1].Text;
                            lisTarget.Items[i_list_index].SubItems[1].Text = lisTarget.Items[i_list_index + 1].SubItems[1].Text;
                            lisTarget.Items[i_list_index + 1].SubItems[1].Text = s_temp;

                            s_temp = lisTarget.Items[i_list_index].SubItems[2].Text;
                            lisTarget.Items[i_list_index].SubItems[2].Text = lisTarget.Items[i_list_index + 1].SubItems[2].Text;
                            lisTarget.Items[i_list_index + 1].SubItems[2].Text = s_temp;

                            s_temp = lisTarget.Items[i_list_index].SubItems[3].Text;
                            lisTarget.Items[i_list_index].SubItems[3].Text = lisTarget.Items[i_list_index + 1].SubItems[3].Text;
                            lisTarget.Items[i_list_index + 1].SubItems[3].Text = s_temp;

                            i_image_index = lisTarget.Items[i_list_index].ImageIndex;
                            lisTarget.Items[i_list_index].ImageIndex = lisTarget.Items[i_list_index + 1].ImageIndex;
                            lisTarget.Items[i_list_index + 1].ImageIndex = i_image_index;

                            lisTarget.Items[i_list_index].Selected = false;
                            lisTarget.Items[i_list_index + 1].Selected = true;

                            i_source_index = MPCF.ToInt(lisTarget.Items[i_list_index].SubItems[3].Text) - 1;
                            if (i_source_index >= 0)
                            {
                                lisSource.Items[i_source_index].SubItems[3].Text = ((int)(i_list_index + 1)).ToString();
                                b_change_source = true;
                            }

                            i_source_index = MPCF.ToInt(lisTarget.Items[i_list_index + 1].SubItems[3].Text) - 1;
                            if (i_source_index >= 0)
                            {
                                lisSource.Items[i_source_index].SubItems[3].Text = ((int)(i_list_index + 2)).ToString();
                                b_change_source = true;
                            }

                            b_change_target = true;
                        }

                        if (i_list_index == i_next)
                        {
                            i_next--;
                        }
                    }
                }

                if (b_change_source == true)
                    lisSource.Tag = "CHANGE";
                if (b_change_target == true)
                    lisTarget.Tag = "CHANGE";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnReverse_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_last;
            int i_image_index;
            int i_source_index;
            string s_temp;
            bool b_change_source;
            bool b_change_target;

            if (lisTarget.Items.Count < 1) return;

            try
            {
                b_change_source = false;
                b_change_target = false;

                i_last = lisTarget.Items.Count - 1;
                for (i = 0; i <= MPCF.ToInt(i_last / 2); i++)
                {
                    s_temp = lisTarget.Items[i].SubItems[1].Text;
                    lisTarget.Items[i].SubItems[1].Text = lisTarget.Items[i_last - i].SubItems[1].Text;
                    lisTarget.Items[i_last - i].SubItems[1].Text = s_temp;

                    s_temp = lisTarget.Items[i].SubItems[2].Text;
                    lisTarget.Items[i].SubItems[2].Text = lisTarget.Items[i_last - i].SubItems[2].Text;
                    lisTarget.Items[i_last - i].SubItems[2].Text = s_temp;

                    s_temp = lisTarget.Items[i].SubItems[3].Text;
                    lisTarget.Items[i].SubItems[3].Text = lisTarget.Items[i_last - i].SubItems[3].Text;
                    lisTarget.Items[i_last - i].SubItems[3].Text = s_temp;

                    i_image_index = lisTarget.Items[i].ImageIndex;
                    lisTarget.Items[i].ImageIndex = lisTarget.Items[i_last - i].ImageIndex;
                    lisTarget.Items[i_last - i].ImageIndex = i_image_index;

                    i_source_index = MPCF.ToInt(lisTarget.Items[i].SubItems[3].Text) - 1;
                    if (i_source_index >= 0)
                    {
                        lisSource.Items[i_source_index].SubItems[3].Text = ((int)(i + 1)).ToString();
                        b_change_source = true;
                    }

                    i_source_index = MPCF.ToInt(lisTarget.Items[i_last - i].SubItems[3].Text) - 1;
                    if (i_source_index >= 0)
                    {
                        lisSource.Items[i_source_index].SubItems[3].Text = ((int)(i_last - i + 1)).ToString();
                        b_change_source = true;
                    }

                    b_change_target = true;
                }

                if (b_change_source == true)
                    lisSource.Tag = "CHANGE";
                if (b_change_target == true)
                    lisTarget.Tag = "CHANGE";

                lisSource.SelectedItems.Clear();
                lisTarget.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            int i;
            int i_source_index = 0;

            try
            {
                if (btnST.Enabled == true)
                {
                    if (lisSource.Items.Count < 1) return;
                    if (lisTarget.Items.Count < 1) return;
                    if (MPCF.Trim(lisSource.Tag) == "NOT_CHANGE") return;

                    for (i = 0; i < lisTarget.Items.Count; i++)
                    {
                        if (lisTarget.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW)
                        {
                            i_source_index = MPCF.ToInt(lisTarget.Items[i].SubItems[3].Text) - 1;
                            if (lisSource.Items[i_source_index].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_EMPTY) break;

                            lisSource.Items[i_source_index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                            lisSource.Items[i_source_index].SubItems[3].Text = "";

                            lisTarget.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisTarget.Items[i].SubItems[1].Text = "";
                            lisTarget.Items[i].SubItems[2].Text = "";
                            lisTarget.Items[i].SubItems[3].Text = "";
                        }
                    }
                    lisSource.Tag = "NOT_CHANGE";
                    lisTarget.Tag = "NOT_CHANGE";
                    lisSource.SelectedItems.Clear();
                    lisTarget.SelectedItems.Clear();
                }
                else
                {
                    if (MPCF.Trim(lisSource.Tag) == "CHANGE")
                    {
                        if (RASLIST.ViewCarrierSublotList(lisSource, '1', cdvSourceCarrier.Text) == false) return;
                        lisSource.Tag = "NOT_CHANGE";
                    }
                    if (MPCF.Trim(lisTarget.Tag) == "CHANGE")
                    {
                        if (RASLIST.ViewCarrierSublotList(lisTarget, '1', cdvTargetCarrier.Text) == false) return;
                        lisTarget.Tag = "NOT_CHANGE";
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnST_Click(object sender, EventArgs e)
        {
            int i;
            bool b_change;
            int i_target_index;

            try
            {
                if (MPCF.CheckValue(cdvTargetCarrier, 1) == false) return;
                if (lisSource.Items.Count < 1) return;
                if (lisTarget.Items.Count < 1) return;

                b_change = false;
                i_target_index = 0;
                for (i = 0; i < lisSource.Items.Count; i++)
                {
                    if (lisSource.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        if (MPCF.Trim(lisSource.Items[i].SubItems[2].Text) == txtLotID.Text)
                        {
                            if (MPCF.Trim(lisTarget.Items[i_target_index].SubItems[1].Text) != "")
                            {
                                do
                                {
                                    i_target_index++;
                                    if (i_target_index > lisTarget.Items.Count - 1) break;
                                }
                                while (MPCF.Trim(lisTarget.Items[i_target_index].SubItems[1].Text) != "");
                                if (i_target_index > lisTarget.Items.Count - 1) break;
                            }

                            lisTarget.Items[i_target_index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW;
                            lisTarget.Items[i_target_index].SubItems[1].Text = lisSource.Items[i].SubItems[1].Text;
                            lisTarget.Items[i_target_index].SubItems[2].Text = lisSource.Items[i].SubItems[2].Text;
                            lisTarget.Items[i_target_index].SubItems[3].Text = lisSource.Items[i].Text;

                            lisSource.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisSource.Items[i].SubItems[3].Text = ((int)(i + 1)).ToString();

                            b_change = true;
                        }
                    }

                    i_target_index++;
                    if (i_target_index > lisTarget.Items.Count - 1) break;
                }

                if (b_change == true)
                {
                    lisSource.Tag = "CHANGE";
                    lisTarget.Tag = "CHANGE";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnSF_Click(object sender, EventArgs e)
        {
            int i;
            int i_target_index;
            bool b_change;

            try
            {
                if (MPCF.CheckValue(cdvTargetCarrier, 1) == false) return;
                if (lisSource.Items.Count < 1) return;
                if (lisTarget.Items.Count < 1) return;

                b_change = false;
                i_target_index = 0;
                for (i = 0; i < lisSource.Items.Count; i++)
                {
                    if (lisSource.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        if (MPCF.Trim(lisSource.Items[i].SubItems[2].Text) == txtLotID.Text)
                        {
                            if (MPCF.Trim(lisTarget.Items[i_target_index].SubItems[1].Text) != "")
                            {
                                do
                                {
                                    i_target_index++;
                                    if (i_target_index > lisTarget.Items.Count - 1) break;
                                }
                                while (MPCF.Trim(lisTarget.Items[i_target_index].SubItems[1].Text) != "");
                                if (i_target_index > lisTarget.Items.Count - 1) break;
                            }

                            lisTarget.Items[i_target_index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW;
                            lisTarget.Items[i_target_index].SubItems[1].Text = lisSource.Items[i].SubItems[1].Text;
                            lisTarget.Items[i_target_index].SubItems[2].Text = lisSource.Items[i].SubItems[2].Text;
                            lisTarget.Items[i_target_index].SubItems[3].Text = lisSource.Items[i].Text;

                            lisSource.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisSource.Items[i].SubItems[3].Text = ((int)(i_target_index + 1)).ToString();

                            b_change = true;

                            i_target_index++;
                            if (i_target_index > lisTarget.Items.Count - 1) break;
                        }
                    }
                }

                if (b_change == true)
                {
                    lisSource.Tag = "CHANGE";
                    lisTarget.Tag = "CHANGE";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnXC_Click(object sender, EventArgs e)
        {
            int i;
            int i_target_index;
            bool b_change;

            try
            {
                if (MPCF.CheckValue(cdvTargetCarrier, 1) == false) return;
                if (lisSource.Items.Count < 1) return;
                if (lisTarget.Items.Count < 1) return;

                b_change = false;
                i_target_index = lisTarget.Items.Count - 1;
                for (i = 0; i < lisSource.Items.Count; i++)
                {
                    if (lisSource.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        if (MPCF.Trim(lisSource.Items[i].SubItems[2].Text) == txtLotID.Text)
                        {
                            if (MPCF.Trim(lisTarget.Items[i_target_index].SubItems[1].Text) != "")
                            {
                                do
                                {
                                    i_target_index--;
                                    if (i_target_index < 0) break;
                                }
                                while (MPCF.Trim(lisTarget.Items[i_target_index].SubItems[1].Text) != "");
                                if (i_target_index < 0) break;
                            }

                            lisTarget.Items[i_target_index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW;
                            lisTarget.Items[i_target_index].SubItems[1].Text = lisSource.Items[i].SubItems[1].Text;
                            lisTarget.Items[i_target_index].SubItems[2].Text = lisSource.Items[i].SubItems[2].Text;
                            lisTarget.Items[i_target_index].SubItems[3].Text = lisSource.Items[i].Text;

                            lisSource.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisSource.Items[i].SubItems[3].Text = ((int)(i_target_index + 1)).ToString();

                            b_change = true;
                        }
                    }

                    i_target_index--;
                    if (i_target_index < 0) break;
                }

                if (b_change == true)
                {
                    lisSource.Tag = "CHANGE";
                    lisTarget.Tag = "CHANGE";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnXF_Click(object sender, EventArgs e)
        {
            int i;
            int i_target_index;
            bool b_change;

            try
            {
                if (MPCF.CheckValue(cdvTargetCarrier, 1) == false) return;
                if (lisSource.Items.Count < 1) return;
                if (lisTarget.Items.Count < 1) return;

                b_change = false;
                i_target_index = lisTarget.Items.Count - 1;
                for (i = 0; i < lisSource.Items.Count; i++)
                {
                    if (lisSource.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        if (MPCF.Trim(lisSource.Items[i].SubItems[2].Text) == txtLotID.Text)
                        {
                            if (MPCF.Trim(lisTarget.Items[i_target_index].SubItems[1].Text) != "")
                            {
                                do
                                {
                                    i_target_index--;
                                    if (i_target_index < 0) break;
                                }
                                while (MPCF.Trim(lisTarget.Items[i_target_index].SubItems[1].Text) != "");
                                if (i_target_index < 0) break;
                            }

                            lisTarget.Items[i_target_index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW;
                            lisTarget.Items[i_target_index].SubItems[1].Text = lisSource.Items[i].SubItems[1].Text;
                            lisTarget.Items[i_target_index].SubItems[2].Text = lisSource.Items[i].SubItems[2].Text;
                            lisTarget.Items[i_target_index].SubItems[3].Text = lisSource.Items[i].Text;

                            lisSource.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisSource.Items[i].SubItems[3].Text = ((int)(i_target_index + 1)).ToString();

                            b_change = true;

                            i_target_index--;
                            if (i_target_index < 0) break;
                        }
                    }
                }

                if (b_change == true)
                {
                    lisSource.Tag = "CHANGE";
                    lisTarget.Tag = "CHANGE";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (Change_Port_Carrier() == false) return;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cdvTrsState_ButtonPress(object sender, EventArgs e)
        {
            cdvTrsState.Init();
            MPCF.InitListView(cdvTrsState.GetListView);
            cdvTrsState.Columns.Add("Status", 50, HorizontalAlignment.Left);
            cdvTrsState.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTrsState.SelectedSubItemIndex = 0;
            //Port Status table
            BASLIST.ViewGCMDataList(cdvTrsState.GetListView, '1', MPGC.MP_RAS_PORT_STATE);

            ListViewItem trsItm;
            trsItm = new ListViewItem("DOWN", (int)SMALLICON_INDEX.IDX_PORT);
            trsItm.SubItems.Add("Port Down"); cdvTrsState.GetListView.Items.Insert(0, trsItm);
            trsItm = new ListViewItem("TB", (int)SMALLICON_INDEX.IDX_PORT);
            trsItm.SubItems.Add("Transfer Blocked"); cdvTrsState.GetListView.Items.Insert(0, trsItm);
            trsItm = new ListViewItem("RTU", (int)SMALLICON_INDEX.IDX_PORT);
            trsItm.SubItems.Add("Ready To Unload"); cdvTrsState.GetListView.Items.Insert(0, trsItm);
            trsItm = new ListViewItem("RTL", (int)SMALLICON_INDEX.IDX_PORT);
            trsItm.SubItems.Add("Ready To Load"); cdvTrsState.GetListView.Items.Insert(0, trsItm);
        }

    }

    public enum ChangePortCarrierLayout
    {
        PORT = 0,
        CARRIER,
        PORT_and_CARRIER
    }
}

