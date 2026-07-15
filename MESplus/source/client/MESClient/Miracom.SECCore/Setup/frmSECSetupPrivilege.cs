//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSECSetupPrvUser.vb
//   Description : Privilege Group - User Relation Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//       - Update_Privilege_Group_User() : Create/Update/Delete Privilege Group - User Relation
//       - CheckCondition()      : Check the conditions before transaction
//       - SelectClear()         : Clear Selected Items
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-04-22 : Created by SK Jin
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

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using System.Collections;

namespace Miracom.SECCore
{
    public partial class frmSECSetupPrivilege : Miracom.MESCore.SetupForm01
    {
        public frmSECSetupPrivilege()
        {
            InitializeComponent();
        }

    
        #region " Variable Definition "

                bool b_load_flag;
                bool b_get_available_items;
        
        #endregion

        #region " Function Definition "

        // SelectClear()
        //       - Clear Selected Items
        // Return Value
        //       -
        // Arguments
        //       - ByVal list As ListView : ListView
        //
        private void SelectClear(ListView list)
        {
            int i;
            for (i = 0; i < list.Items.Count; i++)
            {
                list.Items[i].Selected = false;
            }
        }

        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "ATTACH_USER":

                    if (lisPrvGrp.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisPrvGrp.Items.Count > 0)
                        {
                            lisPrvGrp.Items[0].Selected = true;
                            lisPrvGrp.Focus();
                        }
                        return false;
                    }
                    if (lisAvaillableItems.SelectedItems.Count <= 0)
                    {
                        if (lisAvaillableItems.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisAvaillableItems.Items[0].Selected = true;
                            lisAvaillableItems.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_USER":

                    if (lisPrvGrp.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisPrvGrp.Items.Count > 0)
                        {
                            lisPrvGrp.Items[0].Selected = true;
                            lisPrvGrp.Focus();
                        }
                        return false;
                    }
                    if (lisAssignedItems.SelectedItems.Count <= 0)
                    {
                        if (lisAssignedItems.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisAssignedItems.Items[0].Selected = true;
                            lisAssignedItems.Focus();
                        }
                        return false;
                    }
                    break;
                case "ATTACH_PRVGRP":

                    if (lisPrvType.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisPrvType.Items.Count > 0)
                        {
                            lisPrvType.Items[0].Selected = true;
                            lisPrvType.Focus();
                        }
                        return false;
                    }
                    if (lisAvaillableItemsB.SelectedItems.Count <= 0)
                    {
                        if (lisAvaillableItemsB.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisAvaillableItemsB.Items[0].Selected = true;
                            lisAvaillableItemsB.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_RES":

                    if (lisPrvType.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisPrvType.Items.Count > 0)
                        {
                            lisPrvType.Items[0].Selected = true;
                            lisPrvType.Focus();
                        }
                        return false;
                    }
                    if (lisAssignedItemsB.SelectedItems.Count <= 0)
                    {
                        if (lisAssignedItemsB.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisAssignedItemsB.Items[0].Selected = true;
                            lisAssignedItemsB.Focus();
                        }
                        return false;
                    }
                    break;
            }

            return true;
        }

        //
        // Update_Privilege()
        //       -  Update Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - ByVal c_step As String     : ?뺤옣 Process Step
        //
        private bool Update_Privilege(char c_step, string sItem, string sGrpID, string sType)
        {
            TRSNode in_node = new TRSNode("UPDATE_PRIVILEGE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("PRV_TYPE", sType);
                in_node.AddString("PRV_ITEM1", sItem);

                if (sType == MPGC.MP_PRV_TYPE_ATTR)
                {
                    string[] result = sItem.Split(':');

                    if (result.Length > 1)
                    {
                        in_node.SetString("PRV_ITEM2", result[0].Trim());
                        in_node.SetString("PRV_ITEM1", result[1].Trim());
                    }
                }

                in_node.AddString("PRV_GRP_ID", sGrpID);

                if (c_step == MPGC.MP_STEP_CREATE)
                {
                    if (tabPrvType.SelectedIndex == 0)
                    {
                        if (MPCF.FindListItem(lisAssignedItems, sItem, false) == false)
                        {
                            if (MPCR.CallService("SEC", "SEC_Update_Privilege", in_node, ref out_node) == false)
                            {
                                return false;
                            }
                        }
                    }
                    else if (tabPrvType.SelectedIndex == 1)
                    {
                        if (MPCF.FindListItem(lisAssignedItemsB, sGrpID, false) == false)
                        {
                            if (MPCR.CallService("SEC", "SEC_Update_Privilege", in_node, ref out_node) == false)
                            {
                                return false;
                            }
                        }
                    }
                }
                else if (c_step == MPGC.MP_STEP_DELETE)
                {
                    if (tabPrvType.SelectedIndex == 0)
                    {
                        if (MPCF.FindListItem(lisAssignedItems, sItem, false) == true)
                        {
                            if (MPCR.CallService("SEC", "SEC_Update_Privilege", in_node, ref out_node) == false)
                            {
                                return false;
                            }
                        }
                    }
                    else if (tabPrvType.SelectedIndex == 1)
                    {
                        if (MPCF.FindListItem(lisAssignedItemsB, sGrpID, false) == true)
                        {
                            if (MPCR.CallService("SEC", "SEC_Update_Privilege", in_node, ref out_node) == false)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }
        
        private bool ViewAttributeNameList(char c_step, string sType, bool b_sec_chk_flag)
        {
            int i;
            ListViewItem itmX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("List_In");
            TRSNode out_node = new TRSNode("List_Out");

            try
            {
                a_list = new ArrayList();
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                
                in_node.AddString("ATTR_TYPE", sType);
                in_node.AddString("NEXT_ATTR_NAME", "");
                in_node.AddInt("NEXT_ATTR_SEQ", 0);
                in_node.AddChar("SEC_CHK_FLAG", b_sec_chk_flag == true ? 'Y' : ' ');

                do
                {
                    out_node = new TRSNode("List_Out");

                    if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node) == false)
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
                        string attr_item = out_node.GetList(0)[i].GetString("ATTR_TYPE") + " : " + out_node.GetList(0)[i].GetString("ATTR_NAME");

                        itmX = new ListViewItem(attr_item, (int)SMALLICON_INDEX.IDX_KEY);
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ATTR_DESC"));

                        lisAvaillableItems.Items.Add(itmX);

                       
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.lisPrvGrp;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmSECSetupPrivilege_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitListView(lisPrvGrp);
                MPCF.InitListView(lisAssignedItemsB);
                MPCF.InitListView(lisAvaillableItemsB);
                MPCF.InitListView(lisPrvType);
                MPCF.InitListView(lisAssignedItems);
                MPCF.InitListView(lisAvaillableItems);

                b_get_available_items = false;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {

            }
        }

        private void frmSECSetupPrivilege_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {

                    pnlUserMid_Resize(null, null);
                    pnlPrvGrpMid_Resize(null, null);

                    if (SECLIST.ViewPrvGroupList(lisPrvGrp) == false)
                    {
                        return;
                    }

                    if (lisPrvGrp.Items.Count > 0)
                    {
                        lisPrvGrp.Items[0].Selected = true;
                    }

                    if (SECLIST.ViewPrvGroupList(lisAvaillableItemsB) == false)
                    {
                        return;
                    }

                    b_load_flag = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void pnlUserMid_Resize(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlUserMid, pnlUserMidLeft, pnlUserMidRight, pnlUserMidMid, 40);
        }

        private void pnlPrvGrpMid_Resize(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlPrvGrpMid, pnlPrvGrpMidLeft, pnlPrvGrpMidRight, pnlPrvGrpMidMid, 40);
        }

        private void lisPrvGrp_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lisPrvGrp.SelectedItems.Count > 0)
            {
                MPCF.ClearList(lisAssignedItems);

                cdvPrvGrp.Text = lisPrvGrp.SelectedItems[0].Text;
                cdvPrvGrp.Enabled = false;
                
                if (rdoAll.Checked == true)
                {
                    if (SECLIST.ViewPrivilegeList(lisAssignedItems, '5', "", cdvPrvGrp.Text, "") == true)
                    {
                        return;
                    }
                }
                else if (rdoEach.Checked == true)
                {
                    if (SECLIST.ViewPrivilegeList(lisAssignedItems, '4', cboPrvTypeSetup.Text, cdvPrvGrp.Text, "") == true)
                    {
                        return;
                    }
                }
            }
        }

        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            string sItem;
            ListViewItem itmX;
            string[] sSelect = null;
            itmX = null;
            int i;
            int iIdx = 0;

            sSelect = new string[lisAvaillableItems.SelectedItems.Count];
            SelectClear(lisAssignedItems);

            for (i = 0; i < lisAvaillableItems.SelectedItems.Count; i++)
            {
                sItem = lisAvaillableItems.SelectedItems[i].Text;

                if (MPCF.FindListItem(lisAssignedItems, sItem, false) == false)
                {
                    if (Update_Privilege(MPGC.MP_STEP_CREATE, sItem, MPCF.Trim(cdvPrvGrp.Text), MPCF.Trim(cboPrvTypeSetup.Text)) == true)
                    {
                        sSelect[i] = sItem;

                        if (cboPrvTypeSetup.Text == MPGC.MP_PRV_TYPE_OPER)
                        {
                            itmX = lisAssignedItems.Items.Add(sItem, (int)SMALLICON_INDEX.IDX_OPER);
                        }
                        else if (cboPrvTypeSetup.Text == MPGC.MP_PRV_TYPE_RES)
                        {
                            itmX = lisAssignedItems.Items.Add(sItem, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        }
                        else if (cboPrvTypeSetup.Text == MPGC.MP_PRV_TYPE_GCMTBL)
                        {
                            itmX = lisAssignedItems.Items.Add(sItem, (int)SMALLICON_INDEX.IDX_CODE_TABLE);
                        }
                        else if (cboPrvTypeSetup.Text == MPGC.MP_PRV_TYPE_SERVICE)
                        {
                            itmX = lisAssignedItems.Items.Add(sItem, (int)SMALLICON_INDEX.IDX_PRIVILEGE_SERVICE);
                        }
                        else if (cboPrvTypeSetup.Text == MPGC.MP_PRV_TYPE_ATTR)
                        {
                            itmX = lisAssignedItems.Items.Add(sItem, (int)SMALLICON_INDEX.IDX_KEY);
                        }

                        itmX.SubItems.Add(lisAvaillableItems.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisAvaillableItems.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisAssignedItems.Sorting = SortOrder.Ascending;
                        lisAssignedItems.Sort();
                    }
                }
                //else
                //{
                //    sSelect[i] = sUser;
                //    iIdx = lisAvaillableItems.SelectedItems[i].Index;
                //}
            }

            SelectClear(lisAvaillableItems);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisAvaillableItems.Items.Count - 1)
                {
                    lisAvaillableItems.Items[iIdx + 1].Selected = true;
                }
            }
        }

        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            string sItem;
            string sPrvType = "";

            int iIdx = 0;
            int i;
            int iCount;

            iCount = lisAssignedItems.SelectedItems.Count;

            for (i = lisAssignedItems.SelectedItems.Count - 1; i >= 0; i--)
            {
                sItem = lisAssignedItems.SelectedItems[i].Text;

                // Add by DM KIM 2013.08.30 삭제시 선택한 Item의 Icon Index로 Item Type을 구한다.
                if (lisAssignedItems.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_CODE_TABLE)
                {
                    sPrvType = MPGC.MP_PRV_TYPE_GCMTBL;
                }
                else if (lisAssignedItems.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_OPER)
                {
                    sPrvType = MPGC.MP_PRV_TYPE_OPER;
                }
                else if (lisAssignedItems.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE)
                {
                    sPrvType = MPGC.MP_PRV_TYPE_RES;
                }
                else if (lisAssignedItems.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_PRIVILEGE_SERVICE)
                {
                    sPrvType = MPGC.MP_PRV_TYPE_SERVICE;
                }
                else if (lisAssignedItems.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_KEY)
                {
                    sPrvType = MPGC.MP_PRV_TYPE_ATTR;
                }

                if (Update_Privilege(MPGC.MP_STEP_DELETE, sItem, MPCF.Trim(cdvPrvGrp.Text), MPCF.Trim(sPrvType)) == true)
                {
                    iIdx = lisAssignedItems.SelectedItems[i].Index;
                    lisAssignedItems.Items.RemoveAt(iIdx);
                }

                //if (Update_Privilege(MPGC.MP_STEP_DELETE, sItem, MPCF.Trim(cdvPrvGrp.Text), MPCF.Trim(cboPrvTypeSetup.Text)) == true)
                //{
                //    iIdx = lisAssignedItems.SelectedItems[i].Index;
                //    lisAssignedItems.Items.RemoveAt(iIdx);
                //}
            }
            if (iCount == 1)
            {
                if (iIdx < lisAssignedItems.Items.Count)
                {
                    lisAssignedItems.Items[iIdx].Selected = true;
                }
            }
        }

        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            string sItem;
            string sGrp;
            ListViewItem itmX;
            string[] sSelect = null;
            itmX = null;
            int i;
            int iIdx = 0;

            sItem = "";

            try
            {
                sSelect = new string[lisAvaillableItemsB.SelectedItems.Count];
                SelectClear(lisAssignedItemsB);
                if (lisPrvType.SelectedItems.Count > 0)
                {
                    sItem = lisPrvType.SelectedItems[0].Text;
                }

                for (i = 0; i < lisAvaillableItemsB.SelectedItems.Count; i++)
                {
                    sGrp = lisAvaillableItemsB.SelectedItems[i].Text;

                    if (MPCF.FindListItem(lisAssignedItemsB, sGrp, false) == false)
                    {
                        if (Update_Privilege(MPGC.MP_STEP_CREATE, sItem, sGrp, MPCF.Trim(cboPrvTypeB.Text)) == true)
                        {
                            sSelect[i] = sItem;


                            itmX = lisAssignedItemsB.Items.Add(sGrp, (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP);

                            itmX.SubItems.Add(lisAvaillableItemsB.SelectedItems[i].SubItems[1].Text);
                            //iIdx = lisAvaillableItems.SelectedItems[i].Index;
                            itmX.Selected = true;
                            lisAssignedItemsB.Sorting = SortOrder.Ascending;
                            lisAssignedItemsB.Sort();
                        }
                    }
                }

                SelectClear(lisAvaillableItemsB);
                if (sSelect.Length == 1)
                {
                    if (iIdx < lisAvaillableItemsB.Items.Count - 1)
                    {
                        lisAvaillableItemsB.Items[iIdx + 1].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDettach_Click(System.Object sender, System.EventArgs e)
        {
            string sItem = string.Empty;
            string sGrp = string.Empty;

            int iIdx = 0;
            int i;
            int iCount;

            try
            {
                iCount = lisAssignedItemsB.SelectedItems.Count;

                if (lisPrvType.SelectedItems.Count > 0)
                {
                    sItem = lisPrvType.SelectedItems[0].Text;
                }

                for (i = lisAssignedItemsB.SelectedItems.Count - 1; i >= 0; i--)
                {
                    sGrp = lisAssignedItemsB.SelectedItems[i].Text;

                    if (Update_Privilege(MPGC.MP_STEP_DELETE, sItem, sGrp, MPCF.Trim(cboPrvTypeB.Text)) == true)
                    {
                        iIdx = lisAssignedItemsB.SelectedItems[i].Index;
                        lisAssignedItemsB.Items.RemoveAt(iIdx);
                    }
                }
                if (iCount == 1)
                {
                    if (iIdx < lisAssignedItemsB.Items.Count)
                    {
                        lisAssignedItemsB.Items[iIdx].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cboPrvTypeSetup_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.ClearList(lisAvaillableItems);

                b_get_available_items = true;

                if (cboPrvTypeSetup.Text != "")
                {
                    if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_RES)
                    {
                        chkSecChkFlag.Checked = true;
                        chkSecChkFlag.Enabled = false;

                        lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Resource", 0);
#if _RAS
                        if (chkSecChkFlag.Checked != true)
                        {
                            if (RASLIST.ViewResourceList(lisAvaillableItems, false) == false)
                            {
                                b_get_available_items = false;
                                return;
                            }
                        }
                        else if (chkSecChkFlag.Checked == true)
                        {
                            if (RASLIST.ViewResourceList(lisAvaillableItems, false, true) == false)
                            {
                                b_get_available_items = false;
                                return;
                            }
                        }
#endif
                    }
                    else if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_OPER)
                    {
                        chkSecChkFlag.Checked = true;
                        chkSecChkFlag.Enabled = false;

                        lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Operation", 0);
                        if (chkSecChkFlag.Checked == false)
                        {
                            if (WIPLIST.ViewOperationList(lisAvaillableItems, '1') == false)
                            {
                                b_get_available_items = false;
                                return;
                            }
                        }
                        else
                        {
                            if (WIPLIST.ViewOperationList(lisAvaillableItems, '1', true) == false)
                            {
                                b_get_available_items = false;
                                return;
                            }
                        }
                    }
                    else if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_GCMTBL)
                    {
                        chkSecChkFlag.Checked = true;
                        chkSecChkFlag.Enabled = false;

                        lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Table Name", 0);
                        if (chkSecChkFlag.Checked == false)
                        {
                            if (BASLIST.ViewGCMTableList(lisAvaillableItems, '1', false) == false)
                            {
                                b_get_available_items = false;
                                return;
                            }
                        }
                        else
                        {
                            if (BASLIST.ViewGCMTableList(lisAvaillableItems, '1', true, false, false) == false)
                            {
                                b_get_available_items = false;
                                return;
                            }
                        }
                    }
                    else if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_SERVICE)
                    {
                        chkSecChkFlag.Enabled = true;

                        lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Service Name", 0);
                        if (chkSecChkFlag.Checked == false)
                        {
                            if (SVMLIST.ViewServiceList(lisAvaillableItems, '2') == false)
                            {
                                b_get_available_items = false;
                                return;
                            }
                        }
                        else
                        {
                            if (SVMLIST.ViewServiceList(lisAvaillableItems, '2', true) == false)
                            {
                                b_get_available_items = false;
                                return;
                            }

                        }
                    }
                    else if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_ATTR)
                    {
                        chkSecChkFlag.Checked = true;
                        chkSecChkFlag.Enabled = false;

                        lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Attribute Name", 0);
                        if (chkSecChkFlag.Checked == false)
                        {

                            if (ViewAttributeNameList('1', "", false) == false)
                            {
                                b_get_available_items = false;
                                return;
                            }                         
                        }
                        else
                        {
                            if (ViewAttributeNameList('1', "", true) == false)
                            {
                                b_get_available_items = false;
                                return;
                            }
                        }
                    }

                    if(rdoEach.Checked == true)
                    {
                        if (lisPrvGrp.SelectedItems.Count > 0)
                        {
                            if (SECLIST.ViewPrivilegeList(lisAssignedItems, '4', cboPrvTypeSetup.Text, cdvPrvGrp.Text, "") == true)
                            {
                                b_get_available_items = false;
                                return;
                            }
                        }
                    }

                }

                b_get_available_items = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tabPrvType_Selected(object sender, TabControlEventArgs e)
        {
            if(tabPrvType.SelectedTab == tbpPrvType)
            {
                if (lisPrvType.Items.Count < 1)
                {
                    if (SECLIST.ViewPrivilegeList(lisPrvType, '1', "", "") == false)
                    {
                        return;
                    }
                    if (lisPrvType.Items.Count > 0)
                    {
                        lisPrvType.Items[0].Selected = true;
                    }
                }
            }
        }

        private void lisPrvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisPrvType.SelectedItems.Count > 0)
            {
                MPCF.ClearList(lisAssignedItemsB);

                if (lisPrvType.SelectedItems[0].ImageIndex == (int)SMALLICON_INDEX.IDX_CODE_TABLE)
                {
                    cboPrvTypeB.Text = MPGC.MP_PRV_TYPE_GCMTBL;
                }
                else if (lisPrvType.SelectedItems[0].ImageIndex == (int)SMALLICON_INDEX.IDX_OPER)
                {
                    cboPrvTypeB.Text = MPGC.MP_PRV_TYPE_OPER;
                }
                else if (lisPrvType.SelectedItems[0].ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE)
                {
                    cboPrvTypeB.Text = MPGC.MP_PRV_TYPE_RES;
                }
                else if (lisPrvType.SelectedItems[0].ImageIndex == (int)SMALLICON_INDEX.IDX_PRIVILEGE_SERVICE)
                {
                    cboPrvTypeB.Text = MPGC.MP_PRV_TYPE_SERVICE;
                }
                else if (lisPrvType.SelectedItems[0].ImageIndex == (int)SMALLICON_INDEX.IDX_KEY)
                {
                    cboPrvTypeB.Text = MPGC.MP_PRV_TYPE_ATTR;
                }

                SECLIST.ViewPrivilegeAssignGrpList(lisAssignedItemsB, '1', cboPrvTypeB.Text, lisPrvType.SelectedItems[0].Text, "");

            }
        }

        private void cboAssignType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAssignType.Text == "")
            {
                lisPrvType.Columns[0].Text = MPCF.FindLanguage("ITEM", 0);

                if (SECLIST.ViewPrivilegeList(lisPrvType, '1', "", "") == false)
                {
                    return;
                }
            }
            else
            {
                if (cboAssignType.Text == MPGC.MP_PRV_TYPE_GCMTBL)
                {
                    lisPrvType.Columns[0].Text = MPCF.FindLanguage("Table Name", 0);
                }
                else if (cboAssignType.Text == MPGC.MP_PRV_TYPE_SERVICE)
                {
                    lisPrvType.Columns[0].Text = MPCF.FindLanguage("Service", 0);
                }
                else if (cboAssignType.Text == MPGC.MP_PRV_TYPE_OPER)
                {
                    lisPrvType.Columns[0].Text = MPCF.FindLanguage("Operation", 0);
                }
                else if (cboAssignType.Text == MPGC.MP_PRV_TYPE_RES)
                {
                    lisPrvType.Columns[0].Text = MPCF.FindLanguage("Resource", 0);
                }
                else if (cboAssignType.Text == MPGC.MP_PRV_TYPE_ATTR)
                {
                    lisPrvType.Columns[0].Text = MPCF.FindLanguage("Attribute Name", 0);
                }

                if (SECLIST.ViewPrivilegeList(lisPrvType, '2', cboAssignType.Text, "") == false)
                {
                    return;
                }
            }

            if (lisPrvType.Items.Count > 0)
                lisPrvType.Items[0].Selected = true;
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked == true)
            {
                if (lisPrvGrp.SelectedItems.Count > 0)
                {
                    if (SECLIST.ViewPrivilegeList(lisAssignedItems, '5', "", lisPrvGrp.SelectedItems[0].Text, "") == true)
                    {
                        return;
                    }
                }
            }
        }

        private void rdoEach_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEach.Checked == true)
            {
                if (lisPrvGrp.SelectedItems.Count > 0)
                {
                    if (SECLIST.ViewPrivilegeList(lisAssignedItems, '4', cboPrvTypeSetup.Text, lisPrvGrp.SelectedItems[0].Text, "") == true)
                    {
                        return;
                    }
                }
            }
        }

        private void chkSecChkFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (b_get_available_items == true) return;

            if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_SERVICE)
            {
                lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Service Name", 0);
                if (chkSecChkFlag.Checked == false)
                {
                    if (SVMLIST.ViewServiceList(lisAvaillableItems, '2') == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (SVMLIST.ViewServiceList(lisAvaillableItems, '2', true) == false)
                    {
                        return;
                    }

                }

            }
            else if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_RES)
            {
                lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Resource", 0);
#if _RAS
                if (chkSecChkFlag.Checked != true)
                {
                    if (RASLIST.ViewResourceList(lisAvaillableItems, false) == false)
                    {
                        return;
                    }
                }
                else if (chkSecChkFlag.Checked == true)
                {
                    if (RASLIST.ViewResourceList(lisAvaillableItems, false, true) == false)
                    {
                        return;
                    }
                }
#endif
            }
            else if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_OPER)
            {
                lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Operation", 0);
                if (chkSecChkFlag.Checked == false)
                {
                    if (WIPLIST.ViewOperationList(lisAvaillableItems, '1') == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (WIPLIST.ViewOperationList(lisAvaillableItems, '1', true) == false)
                    {
                        return;
                    }
                }
            }
            else if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_GCMTBL)
            {
                lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Table Name", 0);
                if (chkSecChkFlag.Checked == false)
                {
                    if (BASLIST.ViewGCMTableList(lisAvaillableItems, '1', false) == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (BASLIST.ViewGCMTableList(lisAvaillableItems, '1', true, false, false) == false)
                    {
                        return;
                    }
                }
            }
            else if (MPCF.Trim(cboPrvTypeSetup.Text) == MPGC.MP_PRV_TYPE_ATTR)
            {
                lisAvaillableItems.Columns[0].Text = MPCF.FindLanguage("Attribute Name", 0);
                if (chkSecChkFlag.Checked == false)
                {
                    if (ViewAttributeNameList('1', "", false) == false)
                    {
                        return;
                    }    
                }
                else
                {
                    if (ViewAttributeNameList('1', "", true) == false)
                    {
                        return;
                    }
                }
            }
        }
    


    }
}