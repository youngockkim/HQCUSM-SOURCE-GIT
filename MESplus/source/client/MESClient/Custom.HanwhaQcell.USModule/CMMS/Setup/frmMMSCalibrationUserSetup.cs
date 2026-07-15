//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmCalibrationUserSetup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCalibrationuse() : View Calibrationuse definition
//       - UpdateCalibrationuse() : Create/Update/Delete Calibrationuse
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-03-10 15:35:38 : XXXX Created by generator in DEV Tools
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
    public partial class frmMMSCalibrationUserSetup : SetupForm02
    {
        public frmMMSCalibrationUserSetup()
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
            return this.txtUserID;
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
            if (MPCF.CheckValue(txtUserID, 1) == false)
            {
                return false;
            }            
            return true;            
        }

        
        //
        // ViewCalibrationuserList()
        //       - View Calibration_user List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCalibrationuserList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_USER_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            ListViewItem itmX;

            try
            {
                MPCF.ClearList(lisView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                //in_node.AddString("USER_ID", txtUserID.Text);
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_CALIBRATION_USER_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Calibration_user_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    //Calibration

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach (TRSNode out_node in out_list)
                {
                    List<TRSNode> calibrator_user_list = out_node.GetList("CALIBRATION_USER_LIST");
                    foreach (TRSNode node in calibrator_user_list)
                    {
                        itmX = new ListViewItem(MPCF.Trim(node.GetString("USER_ID")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("USER_NAME")));
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
        // ViewCalibrationuser()
        //       - View Calibrationuse Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCalibrationuser()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_USER_IN");
            TRSNode out_node = new TRSNode("CMMS_VIEW_CALIBRATION_USER_OUT");
            byte[] bt_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("USER_ID", txtUserID.Text);
                if (MPCR.CallService("CMMS", "CMMS_View_Calibration_user", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtUserID.Text = out_node.GetString("USER_ID");
                txtUserName.Text = out_node.GetString("USER_NAME");
                cdvFileName.Text = out_node.GetString("FILE_NAME");
                dtpExpireDate.Value = MPCF.ToDate(out_node.GetString("EXPIRY_DATE"));

                if (out_node.GetChar("USE_FLAG") == 'Y')
                    rdoUseFlagYes.Checked = true;
                else
                    rdoUseFlagNo.Checked = true;

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
        // UpdateCalibrationuser()
        //       - Update Calibrationuser for Setup
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateCalibrationuser(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_CALIBRATION_USER_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_CALIBRATION_USER_OUT");
            byte[] file_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                in_node.AddString("USER_ID", txtUserID.Text);
                in_node.AddString("USER_NAME", txtUserName.Text);
                in_node.AddString("FILE_NAME", cdvFileName.Text);
                if (MPCF.Trim(cdvFileName.GetTextBox.Tag).Equals("U"))
                {
                    if (cdvFileName.Tag != null)
                    {
                        file_buffer = (byte[])cdvFileName.Tag;
                        in_node.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);
                    }
                }

                in_node.AddString("EXPIRY_DATE", dtpExpireDate.Value.ToString("yyyyMMdd"));
                in_node.AddChar("USE_FLAG", (rdoUseFlagYes.Checked == true ? 'Y' : 'N'));

                if (MPCR.CallService("CMMS", "CMMS_Update_Calibration_user", in_node, ref out_node) == false)
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

        private void frmMMSCalibrationUserSetup_Activated(object sender, System.EventArgs e)
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
                lblDataCount.Text = "";
                ViewCalibrationuserList();
                lblDataCount.Text = lisView.Items.Count.ToString();
                if (lisView.Items.Count > 0)
                {
                    MPCF.FindListItem(lisView, txtUserID.Text, false);
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

                if (UpdateCalibrationuser(MPGC.MP_STEP_CREATE) == false)
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

                if (UpdateCalibrationuser(MPGC.MP_STEP_UPDATE) == false)
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

                if (UpdateCalibrationuser(MPGC.MP_STEP_DELETE) == false)
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
                    txtUserID.Text = lisView.SelectedItems[0].Text;
                    txtUserName.Text = lisView.SelectedItems[0].SubItems[1].Text;
                    ViewCalibrationuser();
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

        private void btnFileName_Click(object sender, EventArgs e)
        {
            HQCF.OpenAttachedFile(cdvFileName);
        }

    }
}
