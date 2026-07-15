//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmInputAuditPlanPopup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCAMS() : View CAMS definition
//       - UpdateCAMS() : Create/Update/Delete CAMS
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-05-25 14:47:59 : XXXX Created by generator in DEV Tools
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
    public partial class frmInputAuditPlanPopup : SetupForm01
    {
        public frmInputAuditPlanPopup()
        {
            InitializeComponent();
            btnCreate.Visible = false;
            btnUpdate.Location = new Point(549, 7);
            btnDelete.Location = new Point(640, 7);
            btnClose.Location = new Point(731, 7);
        }


        #region " Constant Definition "





        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private string m_audit_id;
        private bool m_new_flag;

        public string AUDIT_ID
        {
            get
            {
                if (m_audit_id == null)
                {
                    m_audit_id = "";
                }
                return m_audit_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_audit_id = "";
                }
                m_audit_id = value;
            }
        }

        public bool NEW_FLAG
        {
            get 
            {
                return m_new_flag;
            }
            set 
            {
                m_new_flag = value;
            }
        }

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
            return this.txtAuditID;
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
            //if (MPCF.CheckValue(txtKeyField, 1) == false)
            //{
            //    return false;
            //}

            switch (FuncName)
            {
                case "CREATE":

                    if (MPCF.CheckValue(txtAuditDesc, 1) == false) return false;

                    if (MPCF.CheckValue(cdvCustomer, 1) == false) return false;

                    if (MPCF.CheckValue(cdvManager, 1) == false) return false;

                    if (MPCF.CheckValue(txtAuditor, 1) == false) return false;

                    if (MPCF.CheckValue(txtAgenda, 1) == false) return false;



                    break;
                case "UPDATE":
                case "DELETE":
                    if (MPCF.CheckValue(txtAuditID, 1) == false)
                    {
                        return false;
                    }
                    // TODO
                    break;
            }

            return true;            
        }


        //
        // ViewAuditPlan()
        //       - View Audit_Plan
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewAuditPlan()
        {
            TRSNode in_node = new TRSNode("CAMS_VIEW_AUDIT_PLAN_IN");
            TRSNode out_node = new TRSNode("CAMS_VIEW_AUDIT_PLAN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("AUDIT_ID", txtAuditID.Text);

                if (MPCR.CallService("CAMS", "CAMS_View_Audit_Plan", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                txtAuditDesc.Text = out_node.GetString("AUDIT_DESC");
                dtpPlanDate.Value = MPCF.ToDate(out_node.GetString("PLAN_DATE"));

                cdvCustomer.Text = out_node.GetString("CUSTOMER_CODE");
                cdvCustomer.DescText = out_node.GetString("CUSTOMER_NAME");

                txtAuditor.Text = out_node.GetString("AUDITOR");

                cdvManager.Text = out_node.GetString("MANAGER_ID");
                cdvManager.DescText = out_node.GetString("MANAGER_NAME");
                txtAgenda.Text = out_node.GetString("AGENDA");

                if (out_node.GetChar("STATUS") != '0')
                {
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                }


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // UpdateAuditResult()
        //       - Update Audit_Result
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateAuditResult(char c_step)
        {
            TRSNode in_node = new TRSNode("CAMS_UPDATE_AUDIT_PLAN_IN");
            TRSNode out_node = new TRSNode("CAMS_UPDATE_AUDIT_PLAN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);

                if (c_step == MPGC.MP_STEP_DELETE)
                {
                    in_node.ProcStep = MPGC.MP_STEP_DELETE;
                    in_node.AddString("AUDIT_ID", txtAuditID.Text);
                }
                else
                {
                    if (MPCF.Trim(txtAuditID.Text) == "")
                    {
                        in_node.ProcStep = MPGC.MP_STEP_CREATE;
                        in_node.AddString("AUDIT_ID", dtpPlanDate.Value.ToString("yyyyMMdd"));
                    }
                    else
                    {
                        in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                        in_node.AddString("AUDIT_ID", txtAuditID.Text);
                    }
                }               
                in_node.AddString("AUDIT_DESC", txtAuditDesc.Text);

                in_node.AddString("PLAN_DATE", dtpPlanDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("CUSTOMER_CODE", cdvCustomer.Text);
                in_node.AddString("AUDITOR", txtAuditor.Text);
                in_node.AddString("MANAGER_ID", cdvManager.Text);
                in_node.AddString("AGENDA",txtAgenda.Text);
                in_node.AddChar("STATUS",'0');
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

                if (MPCR.CallService("CAMS", "CAMS_Update_Audit_Plan", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (in_node.ProcStep == MPGC.MP_STEP_CREATE)
                    txtAuditID.Text = MPCF.Trim(out_node.GetString("AUDIT_ID"));

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

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

        private void frmInputAuditPlanPopup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');

                if (NEW_FLAG == false)
                {
                    txtAuditID.Text = AUDIT_ID;
                    ViewAuditPlan();
                }

                // TODO
                b_load_flag = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("CREATE") == false) return;

            if (UpdateAuditResult(MPGC.MP_STEP_UPDATE) == true)
            {
                ViewAuditPlan();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckCondition("DELETE") == false) return;

            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (UpdateAuditResult(MPGC.MP_STEP_DELETE) == true)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cdvCustomer_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCustomer.Init();
                MPCF.InitListView(cdvCustomer.GetListView);
                cdvCustomer.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvCustomer.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCustomer.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvCustomer.GetListView, '1', MPGC.MP_GCM_AMS_CUSTOMER) == true)
                {
                    cdvCustomer.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvManager_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvManager.Init();
                MPCF.InitListView(cdvManager.GetListView);
                cdvManager.Columns.Add("ID", 150, HorizontalAlignment.Left);
                cdvManager.Columns.Add("Name", 200, HorizontalAlignment.Left);
                cdvManager.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvManager.GetListView, '1', MPGC.MP_GCM_AMS_MANAGER) == true)
                {
                    cdvManager.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }



    }
}
