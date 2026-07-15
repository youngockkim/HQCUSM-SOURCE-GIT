//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSEvaluationResultRegistration.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCmms() : View Cmms definition
//       - UpdateCmms() : Create/Update/Delete Cmms
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-05-03 18:05:47 : XXXX Created by generator in DEV Tools
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
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSEvaluationResultRegistration : SetupForm02
    {
        public frmMMSEvaluationResultRegistration()
        {
            InitializeComponent();
            InitializeYearData();
        }


        #region " Constant Definition "



        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "


        //
        // InitializeYearData()
        //       - Initalize cboYear()
        // Return Value
        //       -
        // Arguments
        //       - char c_case ("1", "2")
        //
        private void InitializeYearData()
        {
            try
            {
                cboYear.Items.Clear();
                cboViewYear.Items.Clear();
                int i_year = 2020;
                for (int i = i_year; i < DateTime.Now.AddYears(5).Year; i++)
                {
                    cboYear.Items.Add(i.ToString());
                    cboViewYear.Items.Add(i.ToString());
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

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
            return this.cboYear;
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
            if (MPCF.CheckValue(cboYear, 1) == false)
            {
                return false;
            }

            switch (FuncName)
            {
                case "CREATE":
                    // TODO

                    break;
                case "UPDATE":
                    // TODO

                    break;
                case "DELETE":
                    // TODO
                    break;
            }

            return true;            
        }

        //// SetGroupCmfItem()
        ////       -   Set Group/Cmf property to control
        //// Return Value
        ////       -
        //// Arguments
        ////       -
        //private void SetGroupCmfItem()
        //{
        //    string[] sGrpTableName = new string[10];

        //    sGrpTableName[0] = MPGC.MP_GCM_CMMS_GRP_1;
        //    sGrpTableName[1] = MPGC.MP_GCM_CMMS_GRP_2;
        //    sGrpTableName[2] = MPGC.MP_GCM_CMMS_GRP_3;
        //    sGrpTableName[3] = MPGC.MP_GCM_CMMS_GRP_4;
        //    sGrpTableName[4] = MPGC.MP_GCM_CMMS_GRP_5;
        //    sGrpTableName[5] = MPGC.MP_GCM_CMMS_GRP_6;
        //    sGrpTableName[6] = MPGC.MP_GCM_CMMS_GRP_7;
        //    sGrpTableName[7] = MPGC.MP_GCM_CMMS_GRP_8;
        //    sGrpTableName[8] = MPGC.MP_GCM_CMMS_GRP_9;
        //    sGrpTableName[9] = MPGC.MP_GCM_CMMS_GRP_10;

        //    MPCR.SetGRPItem(MPGC.MP_GRP_CMMS, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
        //    MPCR.SetCMFItem(MPGC.MP_CMF_CMMS, "lblCMF", "cdvCMF", grpCMF);
        //}

        
        //
        // UpdateEvaluationResultRegistration()
        //       - Update Evaluation_Result_Registration
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateEvaluationResultRegistration(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_EVALUATION_RESULT_REGISTRATION_OUT");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                string sDocID = MPCF.Trim(txtDocID.Text);

                
                if (c_proc_step == MPGC.MP_STEP_CREATE && sDocID != "")
                {
                    //MPCF.GetMessage(603) //Are you sure you want to register?
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(603), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return false;
                }

                if (c_proc_step == MPGC.MP_STEP_CREATE)
                {
                    sDocID = cboYear.Text + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                }
                in_node.AddString("DOC_ID", sDocID);
                in_node.AddInt("RESULT_YEAR", cboYear.Text);
                in_node.AddString("RESULT_TYPE", cdvEvalDiv.Text);
                in_node.AddChar("ANA_DIV", MPCF.ToChar(cdvAnaDiv.Text));
                in_node.AddString("DEPT_CODE", cdvRegDept.Text);
                in_node.AddString("FILE_NAME", cdvFileName.Text);
                in_node.AddChar("PF_FLAG", '0');
                in_node.AddString("COMMENTS", txtRemarks.Text);

                if (MPCF.Trim(cdvFileName.GetTextBox.Tag).Equals("U"))
                {
                    if (cdvFileName.Tag != null)
                    {
                        byte[] file_buffer = (byte[])cdvFileName.Tag;
                        in_node.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);
                    }
                }

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

                if (MPCR.CallService("CMMS", "CMMS_Update_Evaluation_Result_Registration", in_node, ref out_node) == false)
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
        // ViewEvaluationResultRegistrationList()
        //       - View Evaluation_Result_Registration List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewEvaluationResultRegistrationList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            ListViewItem itmX;

            try
            {
                MPCF.ClearList(lisView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddInt("RESULT_YEAR", MPCF.ToInt(cboViewYear.Text));
                in_node.AddString("RESULT_TYPE", MPCF.Trim(cdvViewEvalDiv.Text));
                in_node.AddChar("ANA_DIV", MPCF.ToChar(cdvViewAnaDiv.Text));
                in_node.AddString("DEPT_CODE", MPCF.Trim(cdvViewRegDept.Text));
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Evaluation_Result_Registration_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> evaluation_result_registration_list = out_node.GetList("EVALUATION_RESULT_REGISTRATION_LIST");
                    foreach (TRSNode node in evaluation_result_registration_list)
                    {
                        itmX = new ListViewItem(MPCF.Trim(node.GetString("DOC_ID")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetInt("RESULT_YEAR").ToString()));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("RESULT_TYPE_NAME").ToString()));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("ANA_DIV_DESC").ToString()));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("DEPT_NAME").ToString()));
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
        // ViewEvaluationResultRegistration()
        //       - View Evaluation_Result_Registration
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewEvaluationResultRegistration()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_VIEW_EVALUATION_RESULT_REGISTRATION_OUT");
            byte[] bt_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("DOC_ID", txtDocID.Text);
                in_node.AddInt("RESULT_YEAR", cboYear.Text);
                if (MPCR.CallService("CMMS", "CMMS_View_Evaluation_Result_Registration", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvAnaDiv.Text = out_node.GetChar("ANA_DIV").ToString();
                cdvAnaDiv.DescText = out_node.GetString("ANA_DIV_DESC").ToString();
                cdvEvalDiv.Text = out_node.GetString("RESULT_TYPE");
                cdvEvalDiv.DescText = out_node.GetString("RESULT_TYPE_NAME");
                cdvRegDept.Text = out_node.GetString("DEPT_CODE");
                cdvRegDept.DescText = out_node.GetString("DEPT_NAME");
                cdvFileName.Text = out_node.GetString("FILE_NAME");
                txtRemarks.Text = out_node.GetString("COMMENTS");
                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
                {
                    HQCF.SetAttachedFile(cdvFileName , bt_buffer, "");
                }
                else
                {
                    cdvFileName.GetTextBox.Tag = "";
                }

                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                //xxxCONTROL.Value = out_node.GetChar("PF_FLAG");
                //xxxCONTROL.Text = out_node.GetString("COMMENTS");
                //xxxCONTROL.Text = out_node.GetString("CMF_1");
                //xxxCONTROL.Text = out_node.GetString("CMF_2");
                //xxxCONTROL.Text = out_node.GetString("CMF_3");
                //xxxCONTROL.Text = out_node.GetString("CMF_4");
                //xxxCONTROL.Text = out_node.GetString("CMF_5");
                //xxxCONTROL.Text = out_node.GetString("CMF_6");
                //xxxCONTROL.Text = out_node.GetString("CMF_7");
                //xxxCONTROL.Text = out_node.GetString("CMF_8");
                //xxxCONTROL.Text = out_node.GetString("CMF_9");
                //xxxCONTROL.Text = out_node.GetString("CMF_10");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmMMSEvaluationResultRegistration_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');

                cboViewYear.Text = DateTime.Now.AddYears(-1).Year.ToString();
               // SetGroupCmfItem();

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
                this.ViewEvaluationResultRegistrationList();
                //if (XXXLIST.ViewCmmsList(lisXXX, ...) == false)
                //{
                //    return;
                //}
                lblDataCount.Text = lisView.Items.Count.ToString();
                if (lisView.Items.Count > 0)
                {
                    MPCF.FindListItem(lisView, cdvEvalDiv.Text, false);
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

                if (UpdateEvaluationResultRegistration(MPGC.MP_STEP_CREATE) == false)
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

                if (UpdateEvaluationResultRegistration(MPGC.MP_STEP_UPDATE) == false)
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

                if (UpdateEvaluationResultRegistration(MPGC.MP_STEP_DELETE) == false)
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
                MPCF.FieldClear(grpRight);
                if (lisView.SelectedItems.Count > 0)
                {
                    txtDocID.Text = lisView.SelectedItems[0].Text;
                    cboYear.Text = lisView.SelectedItems[0].SubItems[1].Text;
                    ViewEvaluationResultRegistration();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewAnaDiv_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewAnaDiv.Init();
                MPCF.InitListView(cdvViewAnaDiv.GetListView);
                cdvViewAnaDiv.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewAnaDiv.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewAnaDiv.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewAnaDiv.GetListView, '1', MPGC.MP_GCM_MMS_ANA_METHOD) == true)
                {
                    cdvViewAnaDiv.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvAnaDiv_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvAnaDiv.Init();
                MPCF.InitListView(cdvAnaDiv.GetListView);
                cdvAnaDiv.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvAnaDiv.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvAnaDiv.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvAnaDiv.GetListView, '1', MPGC.MP_GCM_MMS_ANA_METHOD) == true)
                {
                    cdvAnaDiv.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewRegDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewRegDept.Init();
                MPCF.InitListView(cdvViewRegDept.GetListView);
                cdvViewRegDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewRegDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewRegDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewRegDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvViewRegDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvRegDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvRegDept.Init();
                MPCF.InitListView(cdvRegDept.GetListView);
                cdvRegDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvRegDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvRegDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvRegDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvRegDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewEvalDiv_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewEvalDiv.Init();
                MPCF.InitListView(cdvViewEvalDiv.GetListView);
                cdvViewEvalDiv.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewEvalDiv.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewEvalDiv.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewEvalDiv.GetListView, '1', MPGC.MP_GCM_MMS_RESULT_TYPE) == true)
                {
                    cdvViewEvalDiv.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvEvalDiv_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvEvalDiv.Init();
                MPCF.InitListView(cdvEvalDiv.GetListView);
                cdvEvalDiv.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvEvalDiv.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvEvalDiv.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvEvalDiv.GetListView, '1', MPGC.MP_GCM_MMS_RESULT_TYPE) == true)
                {
                    cdvEvalDiv.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvFileName_ButtonPress(object sender, EventArgs e)
        {
            System.IO.FileInfo finfo;
            System.Windows.Forms.OpenFileDialog ofdFile;
            try
            {
                ofdFile = new OpenFileDialog();
                ofdFile.Filter = "All File(*.*)|*.*";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    finfo = new System.IO.FileInfo(ofdFile.FileName);

                    if (MPCF.ByteLen(finfo.Name) > cdvFileName.MaxLength)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(621));
                        return;
                    }

                    if (finfo.Exists == true)
                        HQCF.SetAttachedFile(cdvFileName, finfo, "U");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnFileName_Click(object sender, EventArgs e)
        {
            HQCF.OpenAttachedFile(cdvFileName);
        }

        private void cboViewYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewEvaluationResultRegistrationList();
        }

        private void cdvViewEvalDiv_TextBoxTextChanged(object sender, EventArgs e)
        {
            ViewEvaluationResultRegistrationList();
        }

        private void cdvViewAnaDiv_TextBoxTextChanged(object sender, EventArgs e)
        {
            ViewEvaluationResultRegistrationList();
        }

        private void cdvViewRegDept_TextBoxTextChanged(object sender, EventArgs e)
        {
            ViewEvaluationResultRegistrationList();
        }
    }
}
