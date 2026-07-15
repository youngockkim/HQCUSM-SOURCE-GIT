//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASTranCarrierLot.vb
//   Description : Attach Lot to Carrier Form
//
//   MES Version : 4.1.0.0
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
//       - 2005-07-01 : Created by GI Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
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
namespace Miracom.RASCore
{
    public partial class frmRASTranCarrierChange : Miracom.MESCore.TranForm01
    {
        public frmRASTranCarrierChange()
        {
            InitializeComponent();
        }

        #region " Variable Definition "
        private bool b_load_flag;
        #endregion

        #region " Function Definition "

        // ViewCarrierLotList()
        //       - View Carrier - Lot Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : Listê°€ ?¤ì–´ê°?control
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?„ìž¬ Factoryê°€ ?„ë‹Œê²½ìš°??Factory
        //
        private bool ViewCarrierLotList(string sLot)
        {

            int i;
            int i_total_crr_count;
            double d_total_crr_qty;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_CARRIER_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_LOT_LIST_OUT");

            try
            {
                MPCF.InitListView(lisCrrList);
                i_total_crr_count = 0;
                d_total_crr_qty = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("LOT_ID", sLot);

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Carrier_Lot_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = lisCrrList.Items.Add(((int)(i + 1)).ToString(), (int)SMALLICON_INDEX.IDX_CARRIER);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_1")));

                        i_total_crr_count++;
                        d_total_crr_qty += out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_1");
                    }

                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                    in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                } while (out_node.GetString("NEXT_LOT_ID") != "" || out_node.GetInt("NEXT_CRR_SEQ") > 0);

                txtCrrCount.Text = i_total_crr_count.ToString();
                txtCrrQty.Text = d_total_crr_qty.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckCondition()
        {
            if (MPCF.CheckValue(cdvSourceCarrier, 1) == false) return false;
            if (MPCF.CheckValue(cdvTargetCarrier, 1) == false) return false;

            return true;
        }

        //
        // Change_Carrier()
        //       -  Change carrier
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - 
        //
        private bool Change_Carrier()
        {

            TRSNode in_node = new TRSNode("CHANGE_CARRIER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("CRR_ID", MPCF.Trim(cdvSourceCarrier.Text));
                in_node.AddString("NEW_CRR_ID", MPCF.Trim(cdvTargetCarrier.Text));

                for (i = 0; i < lisTarget.Items.Count; i++)
                {
                    if (MPCF.Trim(lisTarget.Items[i].SubItems[1].Text) != "")
                    {
                        list_item = in_node.AddNode("SUBLOT");
                        list_item.AddString("SUBLOT_ID", MPCF.Trim(lisTarget.Items[i].SubItems[1].Text));
                        list_item.AddInt("NEW_SLOT_NO", i + 1);
                    }
                }
                if (MPCR.CallService("RAS", "RAS_Change_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }

        
        private void ClearMapByChangeMode()
        {
            int i;

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

            if (MPCF.Trim(lisTarget.Tag) == "CHANGE")
            {
                for (i = 0; i < lisTarget.Items.Count; i++)
                {
                    lisTarget.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                    lisTarget.Items[i].SubItems[1].Text = "";
                    lisTarget.Items[i].SubItems[2].Text = "";
                    lisTarget.Items[i].SubItems[3].Text = "";
                }
                lisTarget.Tag = "NOT_CHANGE";
            }
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.txtSrcLotID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmRASTranCarrierChange_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                pnlCarrierMap_Resize(null, null);

                MPCF.InitListView(lisSource);
                MPCF.InitListView(lisTarget);

                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtSrcLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewCarrierLotList(txtSrcLotID.Text);
                }

                b_load_flag = true;
            }
        }

        private void pnlCarrierMap_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlCarrierMap, pnlMapSource, pnlMapTarget, pnlMapCenter, 60);
            pnlSource.Width = (pnlCarrierMap.Width / 2) + 1;
        }

        private void cdvSourceGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvSourceGroup.Init();
            MPCF.InitListView(cdvSourceGroup.GetListView);
            cdvSourceGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvSourceGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSourceGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierGroupList(cdvSourceGroup.GetListView);
            cdvSourceGroup.InsertEmptyRow(0, 1);
        }

        private void cdvSourceGroup_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvSourceGroup.Text) != "")
            {
                cdvSourceCarrier.Text = "";
                txtLotID.Text = "";
            }
        }

        private void cdvSourceType_ButtonPress(object sender, EventArgs e)
        {
            cdvSourceType.Init();
            MPCF.InitListView(cdvSourceType.GetListView);
            cdvSourceType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvSourceType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSourceType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvSourceType.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            cdvSourceType.InsertEmptyRow(0, 1);
        }

        private void cdvSourceCarrier_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvSourceGroup.Text) == "" && MPCF.Trim(cdvSourceType.Text) == "" && MPCF.Trim(txtLotID.Text) == "")
            {
                if (MPGO.RequireCarrierFilter() == true)
                {
                    if (MPCF.Trim(cdvSourceCarrier.Text) == "")
                    {
                        cdvSourceCarrier.IsPopup = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(258));
                        cdvSourceCarrier.Focus();
                        return;
                    }
                }
            }

            cdvSourceCarrier.Init();
            MPCF.InitListView(cdvSourceCarrier.GetListView);
            cdvSourceCarrier.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvSourceCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSourceCarrier.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierList(cdvSourceCarrier.GetListView, '1', cdvSourceGroup.Text, cdvSourceType.Text, txtLotID.Text, cdvSourceCarrier.Text);
            cdvSourceCarrier.InsertEmptyRow(0, 1);
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

            if (RASLIST.ViewCarrierSublotList(lisSource, '1', cdvSourceCarrier.Text) == false) return;
            lisSource.Tag = "NOT_CHANGE";

            if (MPCF.Trim(cdvTargetCarrier.Text) != "")
            {
                cdvTargetCarrier_SelectedItemChanged(null, null);
            }
        }

        private void cdvSourceCarrier_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cdvSourceCarrier_SelectedItemChanged(null, null);
            }
        }

        private void cdvTargetGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvTargetGroup.Init();
            MPCF.InitListView(cdvTargetGroup.GetListView);
            cdvTargetGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvTargetGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTargetGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierGroupList(cdvTargetGroup.GetListView);
            cdvTargetGroup.InsertEmptyRow(0, 1);
        }

        private void cdvTargetGroup_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvTargetGroup.Text) != "")
            {
                cdvTargetCarrier.Text = "";
            }
        }

        private void cdvTargetType_ButtonPress(object sender, EventArgs e)
        {
            cdvTargetType.Init();
            MPCF.InitListView(cdvTargetType.GetListView);
            cdvTargetType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTargetType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTargetType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTargetType.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            cdvTargetType.InsertEmptyRow(0, 1);
        }

        private void cdvTargetCarrier_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvSourceCarrier, 1) == false) return;

            cdvTargetCarrier.Init();
            MPCF.InitListView(cdvTargetCarrier.GetListView);
            cdvTargetCarrier.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvTargetCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTargetCarrier.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvTargetGroup.Text) == "" && MPCF.Trim(cdvTargetType.Text) == "")
            {
                if (MPGO.RequireCarrierFilter() == true)
                {
                    if (MPCF.Trim(cdvTargetCarrier.Text) == "")
                    {
                        cdvTargetCarrier.IsPopup = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(258));
                        cdvTargetCarrier.Focus();
                        return;
                    }
                }
            }
            RASLIST.ViewCarrierList(cdvTargetCarrier.GetListView, '1', cdvTargetGroup.Text, cdvTargetType.Text, cdvTargetCarrier.Text);
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

            if (RASLIST.ViewCarrierSublotList(lisTarget, '1', cdvTargetCarrier.Text) == false) return;
            lisTarget.Tag = "NOT_CHANGE";

            for (i = 0; i < lisTarget.Items.Count; i++)
            {
                if (MPCF.Trim(lisTarget.Items[i].SubItems[1].Text) != "") break;
            }
            if (i == lisTarget.Items.Count)
            {
                MPCR.ChangeControlEnabled(this, btnST, true);
                MPCR.ChangeControlEnabled(this, btnSF, true);
                MPCR.ChangeControlEnabled(this, btnXC, true);
                MPCR.ChangeControlEnabled(this, btnXF, true);
            }
            else
            {
                btnST.Enabled = false;
                btnSF.Enabled = false;
                btnXC.Enabled = false;
                btnXF.Enabled = false;
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

        private void cdvTargetCarrier_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cdvTargetCarrier_SelectedItemChanged(null, null);
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
                else                                   i_start_idx = lisTarget.SelectedItems[0].Index;

                for (i = 0; i < lisSource.SelectedItems.Count; i++)
                {
                    if (lisSource.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        if (lisTarget.Items[i_start_idx].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_EMPTY)     break;

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
                            if (i_start_idx > lisTarget.Items.Count - 1)    break;
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
                        if (lisSource.Items[i_source_index].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_EMPTY)     break;

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

            try
            {
                if (MPCF.CheckValue(cdvTargetCarrier, 1) == false) return;
                if (lisSource.Items.Count < 1) return;
                if (lisTarget.Items.Count < 1) return;

                ClearMapByChangeMode();

                b_change = false;
                for (i = 0; i < lisSource.Items.Count; i++)
                {
                    if (i > lisTarget.Items.Count - 1) break;

                    if (lisSource.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        lisTarget.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW;
                        lisTarget.Items[i].SubItems[1].Text = lisSource.Items[i].SubItems[1].Text;
                        lisTarget.Items[i].SubItems[2].Text = lisSource.Items[i].SubItems[2].Text;
                        lisTarget.Items[i].SubItems[3].Text = lisSource.Items[i].Text;

                        lisSource.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                        lisSource.Items[i].SubItems[3].Text = ((int)(i + 1)).ToString();

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

                ClearMapByChangeMode();

                b_change = false;
                i_target_index = 0;
                for (i = 0; i < lisSource.Items.Count; i++)
                {
                    if (lisSource.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
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

                ClearMapByChangeMode();

                b_change = false;
                i_target_index = lisTarget.Items.Count - 1;
                for (i = 0; i < lisSource.Items.Count; i++)
                {
                    if (lisSource.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        lisTarget.Items[i_target_index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW;
                        lisTarget.Items[i_target_index].SubItems[1].Text = lisSource.Items[i].SubItems[1].Text;
                        lisTarget.Items[i_target_index].SubItems[2].Text = lisSource.Items[i].SubItems[2].Text;
                        lisTarget.Items[i_target_index].SubItems[3].Text = lisSource.Items[i].Text;

                        lisSource.Items[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                        lisSource.Items[i].SubItems[3].Text = ((int)(i_target_index + 1)).ToString();

                        b_change = true;
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

                ClearMapByChangeMode();

                b_change = false;
                i_target_index = lisTarget.Items.Count - 1;
                for (i = 0; i < lisSource.Items.Count; i++)
                {
                    if (lisSource.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
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
            if (CheckCondition() == false) return;
            if (Change_Carrier() == false) return;

            
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

            if (txtSrcLotID.Text != "")
            {
                ViewCarrierLotList(MPCF.Trim(txtSrcLotID.Text));
            }
        }

        private void txtSrcLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtSrcLotID.Text != "")
            {
                ViewCarrierLotList(MPCF.Trim(txtSrcLotID.Text));
            }
        }

        private void lisCrrList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s_crr_id;

            if(lisCrrList.SelectedItems.Count < 1) return;

            s_crr_id = lisCrrList.SelectedItems[0].SubItems[1].Text;

            txtLotID.Text = txtSrcLotID.Text;
            cdvSourceCarrier.Text = s_crr_id;

            cdvSourceCarrier_SelectedItemChanged(null, null);
        }








    }
}

