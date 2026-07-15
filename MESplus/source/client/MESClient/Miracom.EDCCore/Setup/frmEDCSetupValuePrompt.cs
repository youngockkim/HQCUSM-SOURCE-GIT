using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.EDCCore
{
    public partial class frmEDCSetupValuePrompt : Miracom.MESCore.SetupForm02
    {

        #region " Windows Form auto generated code "

        public frmEDCSetupValuePrompt()
        {
            InitializeComponent();
        }

        #endregion

        #region " Variable Definition"

        bool b_loadflag;

        #endregion

        #region " Function Definition"

        //
        // View_Value_Prompt()
        //       - View Value Prompt
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Value_Prompt()
        {
            TRSNode in_node = new TRSNode("VIEW_VALUE_PROMPT_IN");
            TRSNode out_node = new TRSNode("VIEW_VALUE_PROMPT_OUT");
            int i = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COL_SET_ID", lisColSet.SelectedItems[0].Text);
                in_node.AddInt("COL_SET_VERSION", (chkDefaultFlag.Checked ? 0 : MPCF.ToInt(cdvVersion.Text)));
                in_node.AddChar("DEFAULT_FLAG", (chkDefaultFlag.Checked ? 'Y' : ' '));
                
                for (i = 0; i <= spdPrompt.Sheets[0].RowCount - 1; i++)
                {
                    in_node.AddString("PRT_" + i.ToString(), MPCF.Trim(spdPrompt.Sheets[0].Cells[i, 0].Value));
                }
                if (MPCR.CallService("EDC", "EDC_View_Value_Prompt", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtColSet.Text = MPCF.Trim(out_node.GetString("COL_SET_ID"));
                txtDesc.Text = lisColSet.SelectedItems[0].SubItems[1].Text;

                for (i = 0; i < spdPrompt.Sheets[0].RowCount - 1; i++)
                {
                    spdPrompt.Sheets[0].Cells[i, 0].Value = MPCF.Trim(out_node.GetString("PRT_"+(i+1).ToString()));
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        // Update_Value_Prompt()
        //       - Update Value Prompt
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool Update_Value_Prompt(char c_step)
        {

            try
            {
                TRSNode in_node = new TRSNode("Update_Value_Prompt_In");
                TRSNode out_node = new TRSNode("Update_Value_Prompt_Out");
                int i = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("COL_SET_ID", lisColSet.SelectedItems[0].Text);
                in_node.AddInt("COL_SET_VERSION", (chkDefaultFlag.Checked ? 0 : MPCF.ToInt(cdvVersion.Text)));
                in_node.AddChar("DEFAULT_FLAG", (chkDefaultFlag.Checked ? 'Y' : ' '));
                for (i = 0; i <= spdPrompt.Sheets[0].RowCount - 1; i++)
                {
                    in_node.AddString("PRT_"+(i+1).ToString(), MPCF.Trim(spdPrompt.Sheets[0].Cells[i, 0].Value));
                }

                if (MPCR.CallService("EDC", "EDC_Update_Value_Prompt", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmEDCSetupValuePrompt.Update_Value_Prompt()\n" + ex.Message);
                return false;
            }

        }
       
        #endregion

        private void frmEDCSetupValuePrompt_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_loadflag == false)
                {
                    lblDataCount.Text = "";

                    if (EDCLIST.ViewEDCColSetList(lisColSet, '1', null, "", -1, -1, ' ', false) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(lisColSet.Items.Count);
                        if (lisColSet.Items.Count > 0)
                        {
                            lisColSet.Items[0].Selected = true;
                        }
                    }
                    else
                    {
                        return;
                    }

                    b_loadflag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                lblDataCount.Text = "";
                if (EDCLIST.ViewEDCColSetList(lisColSet, '1', null, "", -1, -1, ' ', false) == false)
                {
                    return;
                }
                lblDataCount.Text = MPCF.Trim(lisColSet.Items.Count);
                if (lisColSet.Items.Count > 0)
                {
                    MPCF.FindListItem(lisColSet, txtColSet.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                MPCF.ExportToExcel(lisColSet, this.Text, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisColSet, txtFind.Text, true, false);

        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisColSet, txtFind.Text, 0, true, false);

        }

        private void cdvcdvVersion_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                cdvVersion.Init();
                MPCF.InitListView(cdvVersion.GetListView);
                cdvVersion.Columns.Add("Version", 50, HorizontalAlignment.Left);
                cdvVersion.SelectedSubItemIndex = 0;
                cdvVersion.DisplaySubItemIndex = 0;
                
                if (EDCLIST.ViewEDCColSetVersionList(cdvVersion.GetListView, '2', txtColSet.Text, -1, null, "") == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvVersion_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                MPCF.ClearList(spdPrompt, true);
                spdPrompt.Sheets[0].RowCount = 100;
                View_Value_Prompt();

                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);

                //MPCF.ClearList(spdPrompt);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void lisColSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                MPCF.ClearList(spdPrompt, true);
                spdPrompt.Sheets[0].RowCount = 100;
                if (lisColSet.SelectedItems.Count > 0)
                {
                    txtColSet.Text = lisColSet.SelectedItems[0].Text;
                    txtDesc.Text = lisColSet.SelectedItems[0].SubItems[1].Text;
                    //View_Value_Prompt();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void chkSDefaultFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDefaultFlag.Checked == true)
                {
                    this.cdvVersion.Text = "";
                    this.cdvVersion.Enabled = false;
                    View_Value_Prompt();
                }
                else
                {
                    this.cdvVersion.Enabled = true;
                    MPCF.ClearList(spdPrompt, true);
                    spdPrompt.Sheets[0].RowCount = 100;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            try
            {
                if (Update_Value_Prompt(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                if (MPGV.gbListAutoRefresh == true)
                {
                    //btnRefresh.PerformClick();
                    View_Value_Prompt();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Update_Value_Prompt(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }

                if (MPGV.gbListAutoRefresh == true)
                {
                    View_Value_Prompt();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (Update_Value_Prompt(MPGC.MP_STEP_DELETE) == false)
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
    }
}
