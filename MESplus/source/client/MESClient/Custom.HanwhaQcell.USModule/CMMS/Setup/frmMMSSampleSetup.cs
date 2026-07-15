//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSSampleSetup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewSample() : View Sample definition
//       - UpdateSample() : Create/Update/Delete Sample
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-03-10 10:26:05 : yk.Yoo Created by generator in DEV Tools
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
    public partial class frmMMSSampleSetup : SetupForm02
    {
        public frmMMSSampleSetup()
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
            return this.txtSampleCode;
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
        private bool CheckCondition(string FuncName)
        {
            if (MPCF.CheckValue(txtSampleCode, 1) == false)
            {
                return false;
            }

            return true;            
        }
       
        //
        // ViewSample()
        //       - View Sample
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewSample()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_SAMPLE_IN");
            TRSNode out_node = new TRSNode("CMMS_VIEW_SAMPLE_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SAMPLE_CODE", txtSampleCode.Text);
                if (MPCR.CallService("CMMS", "CMMS_View_Sample", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtSampleCode.Text = out_node.GetString("SAMPLE_CODE");
                txtSampleName.Text = out_node.GetString("SAMPLE_NAME");
                cdvSampleGroup.Text = out_node.GetString("SAMPLE_GROUP_CODE");
                cdvSampleGroup.DescText = out_node.GetString("SAMPLE_GROUP_NAME");
                if (out_node.GetChar("USE_FLAG") == 'Y')
                    rdoUseFlagYes.Checked = true;
                else
                    rdoUseFlagNo.Checked = true;

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
        // ViewSampleList()
        //       - View Sample List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewSampleList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_SAMPLE_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            ListViewItem itmX;

            try
            {
                MPCF.ClearList(lisView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SAMPLE_GROUP_CODE", cdvViewSampleGroup.Text);

                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_SAMPLE_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Sample_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> sample_list = out_node.GetList("SAMPLE_LIST");
                    foreach (TRSNode node in sample_list)
                    {
                        itmX = new ListViewItem(MPCF.Trim(node.GetString("SAMPLE_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("SAMPLE_NAME")));
                        lisView.Items.Add(itmX);
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

        //
        // UpdateSample()
        //       - Update Sample
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateSample(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_SAMPLE_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_SAMPLE_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                in_node.AddString("SAMPLE_CODE", txtSampleCode.Text);
                in_node.AddString("SAMPLE_NAME", txtSampleName.Text);
                in_node.AddString("SAMPLE_GROUP_CODE", cdvSampleGroup.Text);
                in_node.AddChar("USE_FLAG", (rdoUseFlagYes.Checked == true ? 'Y' : 'N'));
                if (MPCR.CallService("CMMS", "CMMS_Update_Sample", in_node, ref out_node) == false)
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


        #endregion

        private void frmMMSSampleSetup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');

                btnRefresh.PerformClick();

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
                ViewSampleList();
                if (lisView.Items.Count > 0)
                {
                    MPCF.FindListItem(lisView, txtSampleCode.Text, false);
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
                if (CheckCondition("CREATE") == false) return;

                if (UpdateSample(MPGC.MP_STEP_CREATE) == false)
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
                if (CheckCondition("UPDATE") == false) return;

                if (UpdateSample(MPGC.MP_STEP_UPDATE) == false)
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
                if (CheckCondition("DELETE") == false) return;

                if (UpdateSample(MPGC.MP_STEP_DELETE) == false)
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

        private void cdvViewSampleGroup_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewSampleGroup.Init();
                MPCF.InitListView(cdvViewSampleGroup.GetListView);
                cdvViewSampleGroup.Columns.Add("Group Code", 150, HorizontalAlignment.Left);
                cdvViewSampleGroup.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewSampleGroup.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewSampleGroup.GetListView, '1', MPGC.MP_GCM_MMS_SAMPLE_GROUP) == true)
                {
                    cdvViewSampleGroup.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvSampleGroup_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvSampleGroup.Init();
                MPCF.InitListView(cdvSampleGroup.GetListView);
                cdvSampleGroup.Columns.Add("Group Code", 150, HorizontalAlignment.Left);
                cdvSampleGroup.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvSampleGroup.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvSampleGroup.GetListView, '1', MPGC.MP_GCM_MMS_SAMPLE_GROUP) == true)
                {
                    cdvSampleGroup.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewSampleGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            ViewSampleList();
        }

        private void lisView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                if (lisView.SelectedItems.Count > 0)
                {
                    txtSampleCode.Text = lisView.SelectedItems[0].Text;
                    txtSampleName.Text = lisView.SelectedItems[0].SubItems[1].Text;
                    ViewSample();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }






    }
}
