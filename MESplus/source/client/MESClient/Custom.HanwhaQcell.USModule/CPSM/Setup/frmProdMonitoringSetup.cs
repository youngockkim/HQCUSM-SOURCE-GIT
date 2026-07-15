//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmProdMonitoringSetup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCpsm() : View Cpsm definition
//       - UpdateCpsm() : Create/Update/Delete Cpsm
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023/09/25 16:14:56 : XXXX Created by generator in DEV Tools
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
    public partial class frmProdMonitoringSetup : SetupForm02
    {
        public frmProdMonitoringSetup()
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
            return this.txtMainCode;
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
            if (MPCF.CheckValue(txtMainCode, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(cdvCategory, 1) == false)
            {
                return false;
            }

            switch (FuncName)
            {
                case "CREATE":
                    // TODO
                    //if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpGroup;
                    //    return false;
                    //}
                    ////if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    ////{
                    ////    tabXXX.SelectedTab = tbpCmf;
                    ////    return false;
                    ////}
                    break;
                case "UPDATE":
                    // TODO
                    //if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpGroup;
                    //    return false;
                    //}
                    //if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpCmf;
                    //    return false;
                    //}
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
            //string[] sGrpTableName = new string[10];

            //sGrpTableName[0] = MPGC.MP_GCM_CPSM_GRP_1;
            //sGrpTableName[1] = MPGC.MP_GCM_CPSM_GRP_2;
            //sGrpTableName[2] = MPGC.MP_GCM_CPSM_GRP_3;
            //sGrpTableName[3] = MPGC.MP_GCM_CPSM_GRP_4;
            //sGrpTableName[4] = MPGC.MP_GCM_CPSM_GRP_5;
            //sGrpTableName[5] = MPGC.MP_GCM_CPSM_GRP_6;
            //sGrpTableName[6] = MPGC.MP_GCM_CPSM_GRP_7;
            //sGrpTableName[7] = MPGC.MP_GCM_CPSM_GRP_8;
            //sGrpTableName[8] = MPGC.MP_GCM_CPSM_GRP_9;
            //sGrpTableName[9] = MPGC.MP_GCM_CPSM_GRP_10;

            //MPCR.SetGRPItem(MPGC.MP_GRP_CPSM, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
            //MPCR.SetCMFItem(MPGC.MP_CMF_CPSM, "lblCMF", "cdvCMF", grpCMF);
        }

        //
        // UpdateProdMonitoring()
        //       - Update Prod_Monitoring
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateProdMonitoring(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("CPSM_UPDATE_PROD_MONITORING_IN");
            TRSNode out_node = new TRSNode("CPSM_UPDATE_PROD_MONITORING_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                in_node.AddString("CATEGORY", cdvCategory.Text);
                in_node.AddString("BASE_CODE", txtMainCode.Text);
                in_node.AddString("SUB_CODE", txtSubCode.Text);
                in_node.AddString("DESCRIPTION", txtDescription.Text);
                in_node.AddChar("PRINT_CHECK",  (rdoPrinterCheckYes.Checked == true ? "Y":"N"));
                in_node.AddInt("BASE_DT_TIME", nudBaseDTTime.Value);
                in_node.AddString("OPTION_1", cdvOption1.Text);
                in_node.AddString("OPTION_2", cdvOption2.Text);
                in_node.AddString("OPTION_3", cdvOption3.Text);
                in_node.AddString("OPTION_4", cdvOption4.Text);
                in_node.AddString("OPTION_5", cdvOption5.Text);
                //in_node.AddString("CMF_1", xxxCONTROL.Text);
                //in_node.AddString("CMF_2", xxxCONTROL.Text);
                //in_node.AddString("CMF_3", xxxCONTROL.Text);
                //in_node.AddString("CMF_4", xxxCONTROL.Text);
                //in_node.AddString("CMF_5", xxxCONTROL.Text);
                //in_node.AddString("CMF_6", xxxCONTROL.Text);
                //in_node.AddString("CMF_7", xxxCONTROL.Text);
                //in_node.AddString("CMF_8", xxxCONTROL.Text);
                //in_node.AddString("CMF_9", xxxCONTROL.Text);
                //in_node.AddString("CMF_10", xxxCONTROL.Text);

                if (MPCR.CallService("CPSM", "CPSM_Update_Prod_Monitoring", in_node, ref out_node) == false)
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
        // ViewProdMonitoring()
        //       - View Prod_Monitoring
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewProdMonitoring()
        {
            TRSNode in_node = new TRSNode("CPSM_VIEW_PROD_MONITORING_IN");
            TRSNode out_node = new TRSNode("CPSM_VIEW_PROD_MONITORING_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("CATEGORY", cdvCategory.Text);
                in_node.AddString("BASE_CODE", txtMainCode.Text);
                in_node.AddString("SUB_CODE", txtSubCode.Text);
                if (MPCR.CallService("CPSM", "CPSM_View_Prod_Monitoring", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvCategory.Text = out_node.GetString("CATEGORY");
                cdvCategory.DescText = out_node.GetString("CATEGORY_DESC");
                txtMainCode.Text = out_node.GetString("BASE_CODE");
                txtSubCode.Text = out_node.GetString("SUB_CODE");
                txtDescription.Text = out_node.GetString("DESCRIPTION");
                if (out_node.GetChar("PRINT_CHECK") == 'Y')
                    rdoPrinterCheckYes.Checked = true;
                else
                    rdoPrinterCheckNo.Checked = true;

                nudBaseDTTime.Value = out_node.GetInt("BASE_DT_TIME");

                cdvOption1.Text = out_node.GetString("OPTION_1");
                cdvOption2.Text = out_node.GetString("OPTION_2");
                cdvOption3.Text = out_node.GetString("OPTION_3");
                cdvOption4.Text = out_node.GetString("OPTION_4");
                cdvOption5.Text = out_node.GetString("OPTION_5");

                txtLastTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
                
                txtClientVersion.Text = out_node.GetString("CLIENT_VERSION");
                txtLoginUserID.Text = out_node.GetString("TRAN_USER_ID");
                txtPrinterStatus.Text = out_node.GetString("STATUS");
                txtPrinterMessage.Text = out_node.GetString("STATUS_MSG");

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
        // ViewProdMonitoringList()
        //       - View Prod_Monitoring List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewProdMonitoringList()
        {
            TRSNode in_node = new TRSNode("CPSM_VIEW_PROD_MONITORING_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            ListViewItem itmX;
            try
            {
                cdvCategory.Text = cdvViewCategory.Text;
                cdvCategory.DescText = cdvViewCategory.DescText;

                MPCF.ClearList(lisView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("CATEGORY", cdvViewCategory.Text);
                
                do
                {
                    TRSNode out_node = new TRSNode("CPSM_VIEW_PROD_MONITORING_LIST_OUT");

                    if (MPCR.CallService("CPSM", "CPSM_View_Prod_Monitoring_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> equipment_list = out_node.GetList("PROD_MONITORING_LIST");
                    foreach (TRSNode node in equipment_list)
                    {
                        itmX = new ListViewItem(MPCF.Trim(node.GetString("BASE_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("SUB_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("DESCRIPTION")));
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


        #endregion

        private void frmProdMonitoringSetup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');
               // SetGroupCmfItem();

                cdvViewCategory.Text = "MESOI";
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

                ViewProdMonitoringList();

                lblDataCount.Text = lisView.Items.Count.ToString();
                if (lisView.Items.Count > 0)
                {
                    MPCF.FindListItem(lisView, txtMainCode.Text, false);
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

                if (UpdateProdMonitoring(MPGC.MP_STEP_CREATE) == false)
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

                if (UpdateProdMonitoring(MPGC.MP_STEP_UPDATE) == false)
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

                if (UpdateProdMonitoring(MPGC.MP_STEP_DELETE) == false)
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
                    txtMainCode.Text = lisView.SelectedItems[0].Text;
                    txtSubCode.Text = lisView.SelectedItems[0].SubItems[1].Text;
                    txtDescription.Text = lisView.SelectedItems[0].SubItems[2].Text;
                    cdvCategory.Text = cdvViewCategory.Text;
                    ViewProdMonitoring();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewCategory_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewCategory.Init();
                MPCF.InitListView(cdvViewCategory.GetListView);
                cdvViewCategory.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewCategory.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewCategory.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvViewCategory.GetListView, '1', "@CPSM_CATEGORY");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewCategory_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.FieldClear(pnlRight);

            if (cdvViewCategory.Text == "MESOI")
            {
                pnlSOIStatus.Visible = true;
                label13.Text = "Printer Status/Message";
            }
            else
            {
                pnlSOIStatus.Visible = false;
                label13.Text = "Status/Message";
            }
            
            ViewProdMonitoringList();
        }

        private void cdvCategory_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCategory.Init();
                MPCF.InitListView(cdvCategory.GetListView);
                cdvCategory.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvCategory.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCategory.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvCategory.GetListView, '1', "@CPSM_CATEGORY");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvOption_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                Miracom.UI.Controls.MCCodeView.MCCodeView cdvOption = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
                cdvOption.Init();
                MPCF.InitListView(cdvOption.GetListView);
                cdvOption.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvOption.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvOption.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvOption.GetListView, '1', "@CPSM_OPTIONS");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }






    }
}
