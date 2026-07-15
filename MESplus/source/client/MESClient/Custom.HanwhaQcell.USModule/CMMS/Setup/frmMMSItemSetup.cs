//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSItemSetup.cs
//   Description : Item Setup
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewItem() : View Item definition
//       - UpdateItem() : Create/Update/Delete Item
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-03-08 14:10:07 : yk.Yoo Created by generator in DEV Tools
//
//   Copyright(C) 1998-2023 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSItemSetup : SetupForm02
    {
        public frmMMSItemSetup()
        {
            InitializeComponent();
        }


        #region " Constant Definition "



        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        //
        // GetFisrtFocusItem()
        //       - Return first focus control in form
        // Return Value
        //       - Control : Control
        // Arguments
        //       - 
        //
        public virtual Control GetFisrtFocusItem()
        {
            return this.txtItemCode;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - char c_case ('1', '2')
        //
        private void ClearData(char c_case)
        {
            try
            {
                if (c_case == '1')
                {
                    MPCF.FieldClear(this);

                    // TODO
                }
                else if (c_case == '2')
                {
                    // TODO
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - string FuncName : Function Name
        //
        private bool CheckCondition(char ProcStep)
        {

            if (MPCF.CheckValue(txtItemCode, 1) == false)
            {
                return false;
            }

            switch (ProcStep)
            {
                case MPGC.MP_STEP_CREATE:
                case MPGC.MP_STEP_UPDATE:
                    if (MPCF.CheckValue(txtItemName, 1) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(cdvItemGroup, 1) == false)
                    {
                        return false;
                    }

                    if (txtLSL.Text != "")
                    {
                        if (MPCF.CheckNumeric(txtLSL.Text) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(116));
                            txtLSL.Focus();
                            return false;
                        }
                    }

                    if (txtUSL.Text != "")
                    {
                        if (MPCF.CheckNumeric(txtUSL.Text) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(116));
                            txtUSL.Focus();
                            return false;
                        }
                    }

                    break;
                case MPGC.MP_STEP_DELETE:
                    break;
            }

            return true;            
        }


        //
        // ViewItem()
        //       - View Item Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewItem()
        {
            TRSNode in_node = new TRSNode("VIEW_ITEM_IN");
            TRSNode out_node = new TRSNode("VIEW_ITEM_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("ITEM_CODE", MPCF.Trim(txtItemCode.Text));

                if (MPCR.CallService("CMMS", "CMMS_View_Item", in_node, ref out_node) == false)
                {
                    return false;
                }
  
                txtItemCode.Text = out_node.GetString("ITEM_CODE");
                txtItemName.Text  = out_node.GetString("ITEM_NAME");
                cdvItemGroup.Text = out_node.GetString("ITEM_GROUP_CODE");
                cdvItemGroup.DescText = out_node.GetString("ITEM_GROUP_NAME");
                txtLSL.Text = out_node.GetDouble("LSL").ToString();
                txtUSL.Text = out_node.GetDouble("USL").ToString();
                cdvUnit.Text = out_node.GetString("UNIT_CODE");
                if (out_node.GetChar("USE_FLAG") == 'Y')
                    rdoUseFlagYes.Checked = true;
                else
                    rdoUseFlagNo.Checked = true;

                //cboUseFlag.Text = out_node.GetChar("USE_FLAG").ToString();
                nudDecimalPlace.Value = out_node.GetInt("DECIMAL_PLACE");

                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // UpdateItem()
        //       - Update Item for Setup
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateItem(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_ITEM_IN");
            TRSNode out_node = new TRSNode("UPDATE_ITEM_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                in_node.AddString("ITEM_CODE", txtItemCode.Text);
                in_node.AddString("ITEM_NAME", txtItemName.Text);
                in_node.AddString("ITEM_GROUP_CODE", cdvItemGroup.Text);
                in_node.AddDouble("LSL", txtLSL.Text);
                in_node.AddDouble("USL", txtUSL.Text);
                in_node.AddString("UNIT_CODE", cdvUnit.Text);
                in_node.AddInt("DECIMAL_PLACE", nudDecimalPlace.Value);
                in_node.AddChar("USE_FLAG", (rdoUseFlagYes.Checked == true ? 'Y':'N'));
                
                if (MPCR.CallService("CMMS", "CMMS_Update_Item", in_node, ref out_node) == false)
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

        
        //
        // ViewItemList()
        //       - View Item List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewItemList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_ITEM_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            ListViewItem itmX;

            try
            {
                MPCF.ClearList(lisView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("ITEM_GROUP_CODE", cdvViewItemGroup.Text);
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_ITEM_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> item_list = out_node.GetList("ITEM_LIST");
                    foreach (TRSNode node in item_list)
                    {
                        itmX = new ListViewItem(MPCF.Trim(node.GetString("ITEM_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("ITEM_NAME")));                        
                        lisView.Items.Add(itmX);
                        if (node.GetChar("DELETE_FLAG") == 'Y')
                        {
                            lisView.Items[lisView.Items.Count - 1].ForeColor = Color.Silver;
                        }
                    }
                }
                lblDataCount.Text = lisView.Items.Count.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        private void frmMMSItemSetup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');

                ViewItemList();

                // TODO
                b_load_flag = true;
            }
        }

        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {            
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisView, this.Text, "");
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";

                ViewItemList();

                lblDataCount.Text = lisView.Items.Count.ToString();
                if (lisView.Items.Count > 0)
                {
                    MPCF.FindListItem(lisView, txtItemCode.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisView, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisView, txtFind.Text, 0, true, false);
        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;

                if (UpdateItem(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
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

                if (UpdateItem(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
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
                if (MPCF.ShowMsgBox(MPCF.GetMessage(53), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;

                if (UpdateItem(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }

                MPCF.FieldClear(this.pnlRight);
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisView_SelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {                
                MPCF.FieldClear(this.pnlRight);
                if (lisView.SelectedItems.Count > 0)
                {
                    txtItemCode.Text = lisView.SelectedItems[0].Text;
                    txtItemName.Text = lisView.SelectedItems[0].SubItems[1].Text;
                    ViewItem();
                }   
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkIncludeDeleteHistory_CheckedChanged(object sender, EventArgs e)
        {
            ViewItemList();
        }

        private void txtLSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLSL.Text) == false)
                {
                    if (MPCF.CheckNumeric(txtLSL.Text) == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        txtLSL.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtUSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUSL.Text) == false)
                {
                    if (MPCF.CheckNumeric(txtUSL.Text) == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        txtUSL.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewItemGroup_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewItemGroup.Init();
                MPCF.InitListView(cdvViewItemGroup.GetListView);
                cdvViewItemGroup.Columns.Add("Group Code", 150, HorizontalAlignment.Left);
                cdvViewItemGroup.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewItemGroup.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewItemGroup.GetListView, '1', MPGC.MP_GCM_MMS_ITEM_GROUP) == true)
                {
                    cdvViewItemGroup.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvItemGroup_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvItemGroup.Init();
                MPCF.InitListView(cdvItemGroup.GetListView);
                cdvItemGroup.Columns.Add("Group Code", 150, HorizontalAlignment.Left);
                cdvItemGroup.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvItemGroup.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvItemGroup.GetListView, '1', MPGC.MP_GCM_MMS_ITEM_GROUP) == true)
                {
                    cdvItemGroup.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvUnit_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvUnit.Init();
                MPCF.InitListView(cdvUnit.GetListView);
                cdvUnit.Columns.Add("Unit", 150, HorizontalAlignment.Left);
                cdvUnit.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvUnit.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvUnit.GetListView, '1', MPGC.MP_GCM_MMS_UNIT) == true) // GCM TABLE 확인 후 변경 필요 
                {
                    cdvUnit.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewItemGroup_TextBoxTextChanged(object sender, EventArgs e)
        {
            ViewItemList();
        }
    }
}
