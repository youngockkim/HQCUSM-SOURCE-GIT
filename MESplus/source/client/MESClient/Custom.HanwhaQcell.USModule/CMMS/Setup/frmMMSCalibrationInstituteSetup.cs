//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSCalibrationInstituteSetup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewMms() : View Mms definition
//       - UpdateMms() : Create/Update/Delete Mms
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-03-17 09:39:33 : XXXX Created by generator in DEV Tools
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
using System.IO;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSCalibrationInstituteSetup : SetupForm02
    {
        public frmMMSCalibrationInstituteSetup()
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
            return this.txtCalibrationInstituteCode;
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
                    cboViewCalibrationDiv.SelectedIndex = 0;
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
            if (MPCF.CheckValue(txtCalibrationInstituteCode, 1) == false)
            {
                return false;
            }

            switch (FuncName)
            {
                case "CREATE":
                    //// TODO
                    //if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpCMF) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpGroup;
                    //    return false;
                    //}
                    //if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpCmf;
                    //    return false;
                    //}
                    //break;
                case "UPDATE":
                    //// TODO
                    //if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpCMF) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpGroup;
                    //    return false;
                    //}
                    //if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpCmf;
                    //    return false;
                    //}
                    //break;
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

            sGrpTableName[0] = MPGC.MP_GCM_MMS_CALI_INST_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_MMS_CALI_INST_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_MMS_CALI_INST_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_MMS_CALI_INST_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_MMS_CALI_INST_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_MMS_CALI_INST_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_MMS_CALI_INST_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_MMS_CALI_INST_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_MMS_CALI_INST_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_MMS_CALI_INST_GRP_10;

            MPCR.SetCMFItem(MPGC.MP_CMF_MMS_CALI_INST, "lblCMF", "cdvCMF", grpCMF);
        }

        //
        // ViewCalibrationInstituteList()
        //       - View Calibration_Institute List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCalibrationInstituteList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_INSTITUTE_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            ListViewItem itmX;

            try
            {
                MPCF.ClearList(lisView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (MPCF.Trim(cboViewCalibrationDiv.Text) != "")
                {
                    if (MPCF.Trim(cboViewCalibrationDiv.Text).ToUpper() == "INSIDE")
                    {
                        in_node.AddChar("CALI_DIV", '0');
                    }
                    else
                    {
                        in_node.AddChar("CALI_DIV", '1');
                    }
                }
                
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_CALIBRATION_INSTITUTE_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Calibration_Institute_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach (TRSNode out_node in out_list)
                {
                    List<TRSNode> calibration_institute_list = out_node.GetList("CALIBRATION_INSTITUTE_LIST");
                    foreach (TRSNode node in calibration_institute_list)
                    {
                        itmX = new ListViewItem(MPCF.Trim(node.GetString("INSTI_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("INSTI_NAME")));
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
        // ViewCalibrationInstitute()
        //       - View CalibrationIn Stitute Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCalibrationInstitute()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_INSTITUTE_IN");
            TRSNode out_node = new TRSNode("CMMS_VIEW_CALIBRATION_INSTITUTE_OUT");
            byte[] bt_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("INSTI_CODE", txtCalibrationInstituteCode.Text);
                if (MPCR.CallService("CMMS", "CMMS_View_Calibration_Institute", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtCalibrationInstituteCode.Text = out_node.GetString("INSTI_CODE");
                txtCalibrationInstituteName.Text = out_node.GetString("INSTI_NAME");
                if (out_node.GetChar("CALI_DIV") == '0')
                {
                    rdoCaliInside.Checked = true;
                }
                else
                {
                    rdoCaliOutside.Checked = true;
                }
                txtAddress.Text = out_node.GetString("ADDRESS");
                txtCertificateName.Text = out_node.GetString("CERTIFICATE_NAME");
                txtCertificateNo.Text = out_node.GetString("CERTIFICATE_NO");
                txtCertificatePart.Text = out_node.GetString("CERTIFICATE_PART");
                txtCertificateAgency.Text = out_node.GetString("CERTIFICATE_AGENCY");
                dtpIssueDate.Value = MPCF.ToDate(out_node.GetString("ISSUE_DATE"));
                dtpFirstIssueDate.Value = MPCF.ToDate(out_node.GetString("FIRST_ISSUE_DATE"));  //out_node.GetString("FIRST_ISSUE_DATE");
                dtpExpireStartDate.Value = MPCF.ToDate(out_node.GetString("EXPIRE_START_DATE")); // out_node.GetString("EXPIRE_START_DATE");
                dtpExpireEndDate.Value = MPCF.ToDate(out_node.GetString("EXPIRE_END_DATE"));  //out_node.GetString("EXPIRE_END_DATE");
                cdvFileName.Text = out_node.GetString("FILE_NAME");
                //xxxCONTROL.Text = out_node.GetString("FILE_PATH");
                if (out_node.GetChar("USE_FLAG") == 'Y')
                    rdoUseFlagYes.Checked = true;
                else
                    rdoUseFlagNo.Checked = true;

                cdvCMF1.Text = out_node.GetString("CMF_1");
                cdvCMF2.Text = out_node.GetString("CMF_2");
                cdvCMF3.Text = out_node.GetString("CMF_3");
                cdvCMF4.Text = out_node.GetString("CMF_4");
                cdvCMF5.Text = out_node.GetString("CMF_5");
                cdvCMF6.Text = out_node.GetString("CMF_6");
                cdvCMF7.Text = out_node.GetString("CMF_7");
                cdvCMF8.Text = out_node.GetString("CMF_8");
                cdvCMF9.Text = out_node.GetString("CMF_9");
                cdvCMF10.Text = out_node.GetString("CMF_10");
                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
                {
                    HQCF.SetAttachedFile(cdvFileName, bt_buffer, "");
                }
                else
                {
                    cdvFileName.GetTextBox.Tag = "";
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
        // UpdateCalibrationInstitute()
        //       - Update CalibrationInstitute for Setup
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateCalibrationInstitute(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_CALIBRATION_INSTITUTE_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_CALIBRATION_INSTITUTE_OUT");
            byte[] file_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                in_node.AddString("INSTI_CODE", txtCalibrationInstituteCode.Text);
                in_node.AddString("INSTI_NAME", txtCalibrationInstituteName.Text);
                in_node.AddChar("CALI_DIV", (rdoCaliInside.Checked == true ? '0' : '1'));
                in_node.AddString("ADDRESS", txtAddress.Text);
                in_node.AddString("CERTIFICATE_NAME", txtCertificateName.Text);
                in_node.AddString("CERTIFICATE_NO", txtCertificateNo.Text);
                in_node.AddString("CERTIFICATE_PART", txtCertificatePart.Text);
                in_node.AddString("CERTIFICATE_AGENCY", txtCertificateAgency.Text);
                in_node.AddString("ISSUE_DATE", dtpIssueDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("FIRST_ISSUE_DATE", dtpFirstIssueDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("EXPIRE_START_DATE", dtpExpireStartDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("EXPIRE_END_DATE", dtpExpireEndDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("FILE_NAME", System.IO.Path.GetFileName(cdvFileName.Text));

                if (cdvFileName.Tag != null)
                {
                    file_buffer = (byte[])cdvFileName.Tag;
                    in_node.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);
                }

                //in_node.AddString("FILE_PATH", xxxCONTROL.Text);
                in_node.AddChar("USE_FLAG", (rdoUseFlagYes.Checked == true ? 'Y' : 'N'));
                in_node.AddString("CMF_1", cdvCMF1.Text);
                in_node.AddString("CMF_2", cdvCMF2.Text);
                in_node.AddString("CMF_3", cdvCMF3.Text);
                in_node.AddString("CMF_4", cdvCMF4.Text);
                in_node.AddString("CMF_5", cdvCMF5.Text);
                in_node.AddString("CMF_6", cdvCMF6.Text);
                in_node.AddString("CMF_7", cdvCMF7.Text);
                in_node.AddString("CMF_8", cdvCMF8.Text);
                in_node.AddString("CMF_9", cdvCMF9.Text);
                in_node.AddString("CMF_10", cdvCMF10.Text);

                if (MPCR.CallService("CMMS", "CMMS_Update_Calibration_Institute", in_node, ref out_node) == false)
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

        private void frmMMSCalibrationInstituteSetup_Activated(object sender, System.EventArgs e)
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
                ViewCalibrationInstituteList();

                lblDataCount.Text = lisView.Items.Count.ToString();
                
                if (lisView.Items.Count > 0)
                {
                    MPCF.FindListItem(lisView, txtCalibrationInstituteCode.Text, false);
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

                if (UpdateCalibrationInstitute(MPGC.MP_STEP_CREATE) == false)
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

                if (UpdateCalibrationInstitute(MPGC.MP_STEP_UPDATE) == false)
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

                if (UpdateCalibrationInstitute(MPGC.MP_STEP_DELETE) == false)
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

        private void cdvFileName_ButtonPress(object sender, EventArgs e)
        {
            //Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
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
                    if (finfo.Exists == true)
                        HQCF.SetAttachedFile(cdvFileName, finfo, "U");
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
                cdvFileName.Tag = null;
                if (lisView.SelectedItems.Count > 0)
                {
                    txtCalibrationInstituteCode.Text = lisView.SelectedItems[0].Text;
                    txtCalibrationInstituteName.Text = lisView.SelectedItems[0].SubItems[1].Text;
                    ViewCalibrationInstitute();
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

        private void cboViewCalibrationDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        


    }
}
