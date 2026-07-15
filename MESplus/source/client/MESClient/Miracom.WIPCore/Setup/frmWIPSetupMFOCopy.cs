//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupMFOCopy
//   Description : Copy MFO defined value to object
//
//   MES Version : 5.2.1
//
//   Function List
//       - CopyMFO() : Copy MFO
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-08-22 : Created by CM Koo
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
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

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupMFOCopy : TranForm01
    {
        public frmWIPSetupMFOCopy()
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
        // CopyMFO()
        //       - Copy MFO and relation Item Value
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CopyMFO()
        {
            TRSNode in_node = new TRSNode("COPY_MFO_IN");
            TRSNode out_node = new TRSNode("COPY_MFO_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("OBJ_ID", cdvFromID.Text);
                in_node.AddInt("OBJ_VER", MPCF.ToInt(cdvFromVer.Text));
                in_node.AddString("TO_OBJ_ID", cdvToID.Text);
                in_node.AddInt("TO_OBJ_VER", MPCF.ToInt(cdvToVer.Text));
                in_node.AddString("TO_OBJ_DESC", txtToDesc.Text);
                in_node.AddString("TO_FACTORY", cdvToFactory.Text);

                if (rbtMaterial.Checked == true)
                {
                    in_node.AddChar("COPY_OBJ_FLAG", 'M');
                }
                else if (rbtFlow.Checked == true)
                {
                    in_node.AddChar("COPY_OBJ_FLAG", 'F');
                }
                else if (rbtOperation.Checked == true)
                {
                    in_node.AddChar("COPY_OBJ_FLAG", 'O');
                }

                in_node.AddChar("DO_MF_RELATION", (chkMFRelation.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_FO_RELATION", (chkFORelation.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_REWORK_FLOW", (chkRework.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_REPAIR_OPER", (chkRepair.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_FUTURE_ACTION", (chkFutureAction.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_QUEUE_TIME", (chkQueueTime.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_MFO_OPTION", (chkMFOOption.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_SUBLOT_TRACKING", (chkSublotTracking.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_INPUT_OPER_VALUE", (chkInputOperValue.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_CYCLE_TIME", (chkCycleTime.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_YIELD", (chkYield.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_ID_GEN_RULE", (chkIDGenRule.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_BATCH_KEEP", (chkBatchKeep.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_STEP_RELATION", (chkStepRelation.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_RES_MFO_REL", (chkResMFO.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_CRR_GRP_MFO_REL", (chkCrrGroupMFO.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_CRR_CHG_BY_MFO", (chkCrrChangeMFO.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_ALARM_MFO_REL", (chkAlarmMFO.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_FLEXIBLE_SCR_REL", (chkFlexScrMFO.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_COL_SET_MFO_REL", (chkColSetMFO.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_SPECIFICATION", (chkSpecification.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_RECIPE_MFO_REL", (chkRecipeMFO.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_SPC_CHART_MFO_REL", (chkSPCChartMFO.Checked ? 'Y' : ' '));

                in_node.AddChar("OVERWRITE_FLAG", (chkOverwrite.Checked ? 'Y' : ' '));

                in_node.AddChar("DO_MATERIAL_ATTR_STS", (chkMaterialAttribute.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_FLOW_ATTR_STS", (chkFlowAttribute.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_OPER_ATTR_STS", (chkOperAttribute.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_MATERIAL_ATTR_DEF", (chkMaterialAttributeSetup.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_FLOW_ATTR_DEF", (chkFlowAttributeSetup.Checked ? 'Y' : ' '));
                in_node.AddChar("DO_OPER_ATTR_DEF", (chkOperAttributeSetup.Checked ? 'Y' : ' '));

                //Add By JW.Heo 2012.11.12
                if (chkOverwrite.Checked == true)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(348), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return false;
                    }
                }

                if (MPCR.CallService("WIP", "WIP_Copy_MFO", in_node, ref out_node) == false)
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
                return this.rbtMaterial;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion


        private void frmWIPSetupMFOCopy_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    cdvFromID.Init();
                    cdvFromID.Columns.Add("Object ID", 50, HorizontalAlignment.Left);
                    cdvFromID.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvFromID.SelectedSubItemIndex = 0;

                    cdvFromVer.Init();
                    cdvFromVer.Columns.Add("Object Version", 50, HorizontalAlignment.Left);
                    cdvFromVer.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvFromVer.SelectedSubItemIndex = 0;

                    cdvToID.Init();
                    cdvToID.Columns.Add("Object ID", 50, HorizontalAlignment.Left);
                    cdvToID.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvToID.SelectedSubItemIndex = 0;

                    cdvToVer.Init();
                    cdvToVer.Columns.Add("Object Version", 50, HorizontalAlignment.Left);
                    cdvToVer.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvToVer.SelectedSubItemIndex = 0;

                    rbtMaterial.Checked = true;
                    rbtMaterial_CheckedChanged(null, null);

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void rbtMaterial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMaterial.Checked == true)
            {
                lblFrom.Text = MPCF.FindLanguage("From Material ID", 0);
                cdvFromID.Width = 148;
                cdvFromVer.Visible = true;
                cdvFromID.Text = "";
                cdvFromVer.Text = "";
                txtFromDesc.Text = "";

                lblTo.Text = MPCF.FindLanguage("To Material ID", 0);
                cdvToID.Width = 148;
                cdvToVer.Visible = true;
                cdvToID.Text = "";
                cdvToVer.Text = "";
                txtToDesc.Text = "";

                cdvToFactory.Text = "";

                chkMFRelation.Enabled = true;

                chkFORelation.Checked = false;
                chkFORelation.Enabled = false;

                chkRepair.Checked = false;
                chkRepair.Enabled = false;

                chkMaterialAttribute.Enabled = true;
                chkMaterialAttributeSetup.Enabled = true;

                chkFlowAttribute.Checked = false;
                chkFlowAttribute.Enabled = false;
                chkFlowAttributeSetup.Checked = false;
                chkFlowAttributeSetup.Enabled = false;

                chkOperAttribute.Checked = false;
                chkOperAttribute.Enabled = false;
                chkOperAttributeSetup.Checked = false;
                chkOperAttributeSetup.Enabled = false;

                chkSelectAll.Checked = false;
                chkSelectAll.Checked = true;
            }
        }

        private void rbtFlow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFlow.Checked == true)
            {
                lblFrom.Text = MPCF.FindLanguage("From Flow", 0);
                cdvFromID.Width = 198;
                cdvFromVer.Visible = false;
                cdvFromID.Text = "";
                txtFromDesc.Text = "";

                lblTo.Text = MPCF.FindLanguage("To Flow", 0);
                cdvToID.Width = 198;
                cdvToVer.Visible = false;
                cdvToID.Text = "";
                txtToDesc.Text = "";

                cdvToFactory.Text = "";

                chkMFRelation.Checked = false;
                chkMFRelation.Enabled = false;

                chkFORelation.Enabled = true;

                chkRepair.Checked = false;
                chkRepair.Enabled = false;

                chkMaterialAttribute.Checked = false;
                chkMaterialAttribute.Enabled = false;

                chkMaterialAttributeSetup.Checked = false;
                chkMaterialAttributeSetup.Enabled = false;

                chkFlowAttribute.Enabled = true;
                chkFlowAttributeSetup.Enabled = true;

                chkOperAttribute.Checked = false;
                chkOperAttribute.Enabled = false;
                chkOperAttributeSetup.Checked = false;
                chkOperAttributeSetup.Enabled = false;

                chkSelectAll.Checked = false;
                chkSelectAll.Checked = true;
            }
        }

        private void rbtOperation_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtOperation.Checked == true)
            {
                lblFrom.Text = MPCF.FindLanguage("From Operation", 0);
                cdvFromID.Width = 198;
                cdvFromVer.Visible = false;
                cdvFromID.Text = "";
                txtFromDesc.Text = "";

                lblTo.Text = MPCF.FindLanguage("To Operation", 0);
                cdvToID.Width = 198;
                cdvToVer.Visible = false;
                cdvToID.Text = "";
                txtToDesc.Text = "";

                cdvToFactory.Text = "";

                chkMFRelation.Checked = false;
                chkMFRelation.Enabled = false;

                chkFORelation.Checked = false;
                chkFORelation.Enabled = false;

                chkRepair.Enabled = true;

                chkMaterialAttribute.Checked = false;
                chkMaterialAttribute.Enabled = false;
                chkMaterialAttributeSetup.Checked = false;
                chkMaterialAttributeSetup.Enabled = false;

                chkFlowAttribute.Checked = false;
                chkFlowAttribute.Enabled = false;
                chkFlowAttributeSetup.Checked = false;
                chkFlowAttributeSetup.Enabled = false;

                chkOperAttribute.Enabled = true;
                chkOperAttributeSetup.Enabled = true;


                chkSelectAll.Checked = false;
                chkSelectAll.Checked = true;
            }
        }

        private void cdvFromID_ButtonPress(object sender, EventArgs e)
        {
            if (rbtMaterial.Checked == true)
            {
                if (cdvFromID.Columns.Count < 3)
                {
                    cdvFromID.Columns.Add("Description", 100, HorizontalAlignment.Left);
                }

                WIPLIST.ViewMaterialList(cdvFromID.GetListView, '1', "", ' ', ' ', cdvFromID.Text, true, null, "");
                cdvFromVer.Items.Clear();
            }
            else if (rbtFlow.Checked == true)
            {
                if (cdvFromID.Columns.Count > 2)
                {
                    cdvFromID.Columns.RemoveAt(2);
                }
                WIPLIST.ViewFlowList(cdvFromID.GetListView, '1');
            }
            else if (rbtOperation.Checked == true)
            {
                if (cdvFromID.Columns.Count > 2)
                {
                    cdvFromID.Columns.RemoveAt(2);
                }
                WIPLIST.ViewOperationList(cdvFromID.GetListView, '1');
            }
        }

        private void cdvToID_ButtonPress(object sender, EventArgs e)
        {
            if (rbtMaterial.Checked == true)
            {
                if (cdvToID.Columns.Count < 3)
                {
                    cdvToID.Columns.Add("Description", 100, HorizontalAlignment.Left);
                }

                WIPLIST.ViewMaterialList(cdvToID.GetListView, '1', "", ' ', ' ', cdvToID.Text, true, null, cdvToFactory.Text);
                cdvToID.InsertEmptyRow(0, 1);
                cdvToVer.Items.Clear();
            }
            else if (rbtFlow.Checked == true)
            {
                if (cdvToID.Columns.Count > 2)
                {
                    cdvToID.Columns.RemoveAt(2);
                }
                WIPLIST.ViewFlowList(cdvToID.GetListView, '1', "", 0, cdvToID.Text, null, cdvToFactory.Text);
                cdvToID.InsertEmptyRow(0, 1);
            }
            else if (rbtOperation.Checked == true)
            {
                if (cdvToID.Columns.Count > 2)
                {
                    cdvToID.Columns.RemoveAt(2);
                }
                WIPLIST.ViewOperationList(cdvToID.GetListView, '1', "", 0, "", cdvToID.Text, null, cdvToFactory.Text);
                cdvToID.InsertEmptyRow(0, 1);
            }
        }

        private void cdvFromID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (rbtMaterial.Checked == true)
            {
                txtFromDesc.Text = e.SelectedItem.SubItems[2].Text;
                cdvFromVer.Text = e.SelectedItem.SubItems[1].Text;
                WIPLIST.ViewMaterialVersionList(cdvFromVer.GetListView, '1', e.Text);
            }
            else
            {
                txtFromDesc.Text = e.SelectedItem.SubItems[1].Text;
            }
        }

        private void cdvToID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (rbtMaterial.Checked == true)
            {
                txtToDesc.Text = e.SelectedItem.SubItems[2].Text;
                cdvToVer.Text = e.SelectedItem.SubItems[1].Text;
                WIPLIST.ViewMaterialVersionList(cdvToVer.GetListView, '1', e.Text);
            }
            else
            {
                txtToDesc.Text = e.SelectedItem.SubItems[1].Text;
            }
        }

        private void cdvToID_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvToID.Text) == "")
            {
                txtToDesc.Text = "";
            }
        }

        private void cdvVersion_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && (e.KeyChar < (char)48 || e.KeyChar > (char)57))
            {
                e.Handled = true;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb;
            if (chkSelectAll.Checked == true)
            {
                foreach (Control c in grpOption1.Controls)
                {
                    if (c is CheckBox && (cb = (CheckBox)c).Enabled == true)
                    {
                        cb.Checked = true;
                    }
                }
            }
            else
            {
                foreach (Control c in grpOption1.Controls)
                {
                    if (c is CheckBox && (cb = (CheckBox)c).Enabled == true)
                    {
                        cb.Checked = false;
                    }
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (rbtMaterial.Checked == true)
            {
                if (MPCF.CheckValue(cdvFromID, 1) == false) return;
                if (MPCF.CheckValue(cdvFromVer, 1) == false) return;
                if (MPCF.CheckValue(cdvToID, 1) == false) return;
            }
            else
            {
                if (MPCF.CheckValue(cdvFromID, 1) == false) return;
                if (MPCF.CheckValue(cdvToID, 1) == false) return;
            }

            if (CopyMFO() == false) return;
        }

        private void cdvToFactory_ButtonPress(object sender, EventArgs e)
        {
            cdvToFactory.Init();
            MPCF.InitListView(cdvToFactory.GetListView);
            cdvToFactory.Columns.Add("Factory", 100, HorizontalAlignment.Left);
            cdvToFactory.Columns.Add("Factory Desc", 100, HorizontalAlignment.Left);
            cdvToFactory.SelectedSubItemIndex = 0;
            WIPLIST.ViewFactoryList(cdvToFactory.GetListView, '1', null);

            int i;
            i = 0;
            while (i < cdvToFactory.Items.Count)
            {
                if (MPCF.Trim(cdvToFactory.Items[i].Text) == MPGV.gsFactory || MPCF.Trim(cdvToFactory.Items[i].Text) == MPGV.gsCentralFactory)
                {
                    cdvToFactory.Items.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            cdvToFactory.InsertEmptyRow(0, 1);
        }

    }
}
