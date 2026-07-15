//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmJobChangeItemSetup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCjcm() : View Cjcm definition
//       - UpdateCjcm() : Create/Update/Delete Cjcm
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023/07/18 14:09:04 : XXXX Created by generator in DEV Tools
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
    public partial class frmJobChangeItemSetup : SetupForm02
    {
        public frmJobChangeItemSetup()
        {
            InitializeComponent();
        }


        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private bool b_view_flag;

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
        private bool CheckCondition(string FuncName)
        {
            if (MPCF.CheckValue(txtItemCode, 1) == false)
            {
                return false;
            }
            switch (FuncName)
            {
                case "CREATE":
                case "UPDATE":
                    if (rdoAutoFlagYes.Checked == true)
                    {
                        if (chkSqlStatus.Checked != true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(637));
                            return false;
                        }
                    }
                    if (MPCF.CheckValue(cdvDeptCode, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvAlarmCode, 1) == false)
                    {
                        return false;
                    }
                    break;
                case "DELETE":
                    // TODO
                    break;
            }

            return true;            
        }

        // SetGroupCmfItem()
        //       -   Set Group/Cmf property to control
        // Return Value
        //       -
        // Arguments
        //       -
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];

            //sGrpTableName[0] = MPGC.MP_GCM_CJCM_GRP_1;
            //sGrpTableName[1] = MPGC.MP_GCM_CJCM_GRP_2;
            //sGrpTableName[2] = MPGC.MP_GCM_CJCM_GRP_3;
            //sGrpTableName[3] = MPGC.MP_GCM_CJCM_GRP_4;
            //sGrpTableName[4] = MPGC.MP_GCM_CJCM_GRP_5;
            //sGrpTableName[5] = MPGC.MP_GCM_CJCM_GRP_6;
            //sGrpTableName[6] = MPGC.MP_GCM_CJCM_GRP_7;
            //sGrpTableName[7] = MPGC.MP_GCM_CJCM_GRP_8;
            //sGrpTableName[8] = MPGC.MP_GCM_CJCM_GRP_9;
            //sGrpTableName[9] = MPGC.MP_GCM_CJCM_GRP_10;

            //MPCR.SetGRPItem(MPGC.MP_GRP_CJCM, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
            //MPCR.SetCMFItem(MPGC.MP_CMF_CJCM, "lblCMF", "cdvCMF", grpCMF);
        }

        //
        // CJCMViewSetupJobChangeItem()
        //       - View Setup_Job_Change_Item
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CJCMViewSetupJobChangeItem()
        {
            TRSNode in_node = new TRSNode("CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_IN");
            TRSNode out_node = new TRSNode("CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                b_view_flag = true;
                in_node.AddString("ITEM_CODE", txtItemCode.Text);
                if (MPCR.CallService("CJCM", "CJCM_View_Setup_Job_Change_Item", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtItemCode.Text = out_node.GetString("ITEM_CODE");
                txtItemName.Text = out_node.GetString("ITEM_NAME");
                if (out_node.GetChar("AUTO_FLAG") == 'Y')
                {
                    rdoAutoFlagYes.Checked = true;
                    chkSqlStatus.Checked = true;
                }
                else
                {
                    rdoAutoFlagNo.Checked = true;
                    chkSqlStatus.Checked = false;
                }

                if (out_node.GetChar("USE_FLAG") == 'Y')
                {
                    rdoUseYes.Checked = true;
                }
                else
                {
                    rdoUseNg.Checked = true;
                }

                cdvDeptCode.Text = out_node.GetString("DEPT_CODE");
                cdvDeptCode.DescText = out_node.GetString("DEPT_NAME");

                cdvAlarmCode.Text = out_node.GetString("ALARM_CODE");
                txtSql.Text = out_node.GetString("SQL_TEXT");

                nudPlanStartDate.Value = out_node.GetInt("PLAN_START_DAYS_BEFORE");
                nudPlanEndDate.Value = out_node.GetInt("PLAN_END_DAYS_BEFORE");

                chkAlarmFlag.Checked = (out_node.GetChar("ALARM_FLAG") == 'Y' ? true : false);
                nudAlarmPeriod.Value = MPCF.ToInt(out_node.GetString("CMF_1"));

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
            finally
            {
                b_view_flag = false;
            }
        }

        //
        // CJCMViewSetupJobChangeItemList()
        //       - View Setup_Job_Change_Item List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CJCMViewSetupJobChangeItemList()
        {
            TRSNode in_node = new TRSNode("CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            ListViewItem itmX;

            try
            {
                MPCF.ClearList(lisView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                //in_node.AddString("ITEM_CODE", xxxCONTROL.Text);
                ///* for Datetime format value using ToString() */
                //in_node.AddString("DATETIME", dtpDateTime.Value.ToString("yyyyMMddHHmmss"));
                ///* for Datetime format value using MPCF.ToStandardTime() */
                //in_node.AddString("DATETIME", MPCF.ToStandardTime(dtpDateTime.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
                ///* for Date and Time format value using MPCF.ToStandardTime() */
                //in_node.AddString("DATETIME", MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));

                do
                {
                    TRSNode out_node = new TRSNode("CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST_OUT");

                    if (MPCR.CallService("CJCM", "CJCM_View_Setup_Job_Change_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> item_list = out_node.GetList("SETUP_JOB_CHANGE_ITEM_LIST");
                    foreach (TRSNode node in item_list)
                    {
                        itmX = new ListViewItem(MPCF.Trim(node.GetString("ITEM_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("ITEM_NAME")));
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
        // CJCMUpdateSetupJobChangeItem()
        //       - Update Setup_Job_Change_Item
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CJCMUpdateSetupJobChangeItem(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM_IN");
            TRSNode out_node = new TRSNode("CJCM_UPDATE_SETUP_JOB_CHANGE_ITEM_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                in_node.AddString("ITEM_CODE", txtItemCode.Text);
                in_node.AddString("ITEM_NAME", txtItemName.Text);                
                in_node.AddChar("AUTO_FLAG", rdoAutoFlagYes.Checked == true ? 'Y':'N');
                in_node.AddString("DEPT_CODE", cdvDeptCode.Text);
                in_node.AddString("ALARM_CODE", cdvAlarmCode.Text);
                in_node.AddString("SQL_TEXT", txtSql.Text);
                in_node.AddChar("USE_FLAG", rdoUseYes.Checked == true ? 'Y' : 'N');
                in_node.AddInt("PLAN_START_DAYS_BEFORE", nudPlanStartDate.Value);
                in_node.AddInt("PLAN_END_DAYS_BEFORE", nudPlanEndDate.Value);

                if (chkAlarmFlag.Checked == true)
                {
                    in_node.AddChar("ALARM_FLAG", 'Y');
                    in_node.AddString("ALARM_CODE", cdvAlarmCode.Text);
                    in_node.AddInt("ALARM_PERIOD", nudAlarmPeriod.Value);
                    in_node.AddString("CMF_1", nudAlarmPeriod.Value.ToString());
                }
                else
                {
                    in_node.AddChar("ALARM_FLAG", 'N');
                }

                if (MPCR.CallService("CJCM", "CJCM_Update_Setup_Job_Change_Item", in_node, ref out_node) == false)
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

        private void frmJobChangeItemSetup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');
                SetGroupCmfItem();

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
                lblDataCount.Text = "";
                CJCMViewSetupJobChangeItemList();
                //if (XXXLIST.ViewCjcmList(lisXXX, ...) == false)
                //{
                //    return;
                //}
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
                if (CheckCondition("CREATE") == false) return;

                if (CJCMUpdateSetupJobChangeItem(MPGC.MP_STEP_CREATE) == false)
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

                if (CJCMUpdateSetupJobChangeItem(MPGC.MP_STEP_UPDATE) == false)
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
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
                if (CheckCondition("DELETE") == false) return;

                if (CJCMUpdateSetupJobChangeItem(MPGC.MP_STEP_DELETE) == false)
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

        private void rdoAutoFlagYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAutoFlagYes.Checked == true)
            {
                txtSql.Enabled = true;
            }
            else
            {
                txtSql.Text = "";
                txtSql.Enabled = false;
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
                    CJCMViewSetupJobChangeItem();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnSqlTest_Click(object sender, EventArgs e)
        {
            if (CJCMUpdateSetupJobChangeItem('Q') == false)
            {
                chkSqlStatus.Checked = false;
                chkSqlStatus.Visible = false;
                chkSqlStatus.Enabled = false;
                return;
            }
            else
            {
                chkSqlStatus.Checked = true;
                chkSqlStatus.Visible = true;
                chkSqlStatus.Enabled = true;
            }
        }

        private void cdvDeptCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvDeptCode.Init();
                MPCF.InitListView(cdvDeptCode.GetListView);
                cdvDeptCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvDeptCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvDeptCode.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvDeptCode.GetListView, '1', "@DEPT_CODE") == true)
                {
                    cdvDeptCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtSql_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (b_view_flag == false)
                {
                    chkSqlStatus.Checked = false;
                    chkSqlStatus.Visible = false;
                    chkSqlStatus.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvAlarmCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvAlarmCode.Init();
                MPCF.InitListView(cdvAlarmCode.GetListView);
                cdvAlarmCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvAlarmCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvAlarmCode.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvAlarmCode.GetListView, '1', "ALARM_CODE") == true)
                {
                    cdvAlarmCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkAlarmFlag_CheckedChanged(object sender, EventArgs e)
        {
            nudAlarmPeriod.Enabled = chkAlarmFlag.Checked;
        }
    }
}
