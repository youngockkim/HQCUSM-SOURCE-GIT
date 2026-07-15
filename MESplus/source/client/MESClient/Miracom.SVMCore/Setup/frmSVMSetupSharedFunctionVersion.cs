using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.SVMCore
{
    public partial class frmSVMSetupSharedFunctionVersion : Miracom.MESCore.SetupForm01
    {
        public frmSVMSetupSharedFunctionVersion()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        #endregion

        #region " Function Definition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal c_proc_step As String : Process Step
        //
        private bool CheckCondition(char c_proc_case)
        {
            switch (c_proc_case)
            {
                case '1':
                    if (MPCF.CheckValue(txtSMName, 1) == false) return false;
                    if (MPCF.CheckValue(txtSMVersion, 1) == false) return false;
                    if (MPCF.Trim(txtSFName.Text) != "")
                    {
                        if (numSFVersion.Text == "")
                            numSFVersion.Value = 0;

                        if (numSFVersion.Value < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(114));
                            numSFVersion.Focus();
                            return false;
                        }
                    }
                    break;

                case '2':
                    if (MPCF.CheckValue(txtSCID, 1) == false) return false;
                    if (MPCF.CheckValue(txtSModName, 1) == false) return false;
                    //if (MPCF.CheckValue(txtSModVersion, 1) == false) return false;
                    if (MPCF.CheckValue(txtSFuncName, 1) == false) return false;
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", tbpCMF) == false)
                    {
                        return false;
                    }

                    //if (numSFuncVersion.Text == "")
                    //    numSFuncVersion.Value = 0;

                    //if (numSFuncVersion.Value < 1)
                    //{
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(114));
                    //    numSFuncVersion.Focus();
                    //    return false;
                    //}
                    break;
            }
            
            return true;

        }

        //
        // View_Active_Function_Version()
        //       - View active function version in custom shared library
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Active_Function_Version(char c_proc_step, char c_proc_case)
        {
            TRSNode in_node = new TRSNode("VIEW_ACTIVE_FUNCTION_VERSION_IN");
            TRSNode out_node = new TRSNode("VIEW_ACTIVE_FUNCTION_VERSION_OUT");

            int i_row;
            int i;
            try
            {
                if (c_proc_case == '1')
                {
                    MPCF.ClearList(spdActiveList);
                }
                else if (c_proc_case == '2')
                {
                    MPCF.ClearList(spdList);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                in_node.AddChar("PROC_CASE", c_proc_case);
                if (c_proc_case == '1')
                {
                    in_node.AddString("LIB_NAME", txtMName.Text);
                    in_node.AddString("LIB_VER", txtMVersion.Text);
                    in_node.AddChar("LOAD_ONLY_FLAG", (chkMLoadOnly.Checked == true ? 'Y' : ' '));
                    in_node.AddString("SERVICE_NAME", txtFName.Text);

                    if (numFVersion.Text == "")
                        numFVersion.Value = 0;

                    in_node.AddInt("SERVICE_VER", MPCF.ToInt(numFVersion.Value));
                }
                else if (c_proc_case == '2')
                {
                    in_node.AddString("KEY_NAME", txtCID.Text);
                    in_node.AddString("KEY_TYPE", cdvKeyType.Text);
                    in_node.AddString("LIB_NAME", txtModName.Text);
                    in_node.AddString("LIB_VER", txtModVersion.Text);
                    in_node.AddString("SERVICE_NAME", txtFuncName.Text);

                    if (numFuncVersion.Text == "")
                        numFuncVersion.Value = 0;

                    in_node.AddInt("SERVICE_VER", MPCF.ToInt(numFuncVersion.Value));
                }

                do
                {
                    if (MPCR.CallService("SVM", "SVM_View_Active_Function_Version", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (c_proc_case == '1')
                        {
                            i_row = spdActiveList.ActiveSheet.RowCount;
                            spdActiveList.ActiveSheet.RowCount++;

                            spdActiveList.ActiveSheet.Cells[i_row, 0].Value = out_node.GetList(0)[i].GetString("LIB_NAME");
                            spdActiveList.ActiveSheet.Cells[i_row, 1].Value = out_node.GetList(0)[i].GetString("LIB_VER");

                            if (out_node.GetList(0)[i].GetChar("LOAD_ONLY_FLAG") == 'Y')
                            {
                                spdActiveList.ActiveSheet.Cells[i_row, 2].Value = "V";
                            }

                            spdActiveList.ActiveSheet.Cells[i_row, 3].Value = out_node.GetList(0)[i].GetString("SERVICE_NAME");
                            spdActiveList.ActiveSheet.Cells[i_row, 4].Value = out_node.GetList(0)[i].GetInt("SERVICE_VER");
                            spdActiveList.ActiveSheet.Cells[i_row, 5].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
                            spdActiveList.ActiveSheet.Cells[i_row, 6].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                            spdActiveList.ActiveSheet.Cells[i_row, 7].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                            spdActiveList.ActiveSheet.Cells[i_row, 8].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"));
                        }
                        else if (c_proc_case == '2')
                        {
                            i_row = spdList.ActiveSheet.RowCount;
                            spdList.ActiveSheet.RowCount++;

                            spdList.ActiveSheet.Cells[i_row, 0].Value = out_node.GetList(0)[i].GetString("KEY_NAME");
                            spdList.ActiveSheet.Cells[i_row, 1].Value = out_node.GetList(0)[i].GetString("KEY_DESC");
                            spdList.ActiveSheet.Cells[i_row, 2].Value = out_node.GetList(0)[i].GetString("KEY_TYPE");
                            spdList.ActiveSheet.Cells[i_row, 3].Value = out_node.GetList(0)[i].GetString("LIB_NAME");
                            spdList.ActiveSheet.Cells[i_row, 4].Value = out_node.GetList(0)[i].GetString("LIB_VER");
                            spdList.ActiveSheet.Cells[i_row, 5].Value = out_node.GetList(0)[i].GetString("SERVICE_NAME");
                            spdList.ActiveSheet.Cells[i_row, 6].Value = out_node.GetList(0)[i].GetInt("SERVICE_VER");
                            spdList.ActiveSheet.Cells[i_row, 7].Value = out_node.GetList(0)[i].GetString("DATA_1");
                            spdList.ActiveSheet.Cells[i_row, 8].Value = out_node.GetList(0)[i].GetString("DATA_2");
                            spdList.ActiveSheet.Cells[i_row, 9].Value = out_node.GetList(0)[i].GetString("DATA_3");
                            spdList.ActiveSheet.Cells[i_row, 10].Value = out_node.GetList(0)[i].GetString("DATA_4");
                            spdList.ActiveSheet.Cells[i_row, 11].Value = out_node.GetList(0)[i].GetString("DATA_5");
                            spdList.ActiveSheet.Cells[i_row, 12].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
                            spdList.ActiveSheet.Cells[i_row, 13].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                            spdList.ActiveSheet.Cells[i_row, 14].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                            spdList.ActiveSheet.Cells[i_row, 15].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"));
                        }
                    }

                    in_node.SetInt("NEXT_ROWNUM", out_node.GetInt("NEXT_ROWNUM"));
                    in_node.SetString("MAX_ROWID", out_node.GetString("MAX_ROWID"));

                } while (in_node.GetInt("NEXT_ROWNUM") > 0);

                if (c_proc_case == '1')
                {
                    MPCF.FitColumnHeader(spdActiveList);
                }
                else if (c_proc_case == '2')
                {
                    MPCF.FitColumnHeader(spdList);
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
        // Update_Active_Function_Version()
        //       - Create/Update/Delete Security Function Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_proc_step As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_Active_Function_Version(char c_proc_step, char c_proc_case)
        {
            TRSNode in_node = new TRSNode("UPDATE_ACTIVE_FUNCTION_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                in_node.AddChar("PROC_CASE", c_proc_case);
                if (c_proc_case == '1')
                {
                    in_node.AddString("LIB_NAME", txtSMName.Text);
                    in_node.AddString("LIB_VER", txtSMVersion.Text);
                    in_node.AddChar("LOAD_ONLY_FLAG", (chkSMLoadOnly.Checked == true ? 'Y' : ' '));
                    in_node.AddString("SERVICE_NAME", txtSFName.Text);
                    in_node.AddInt("SERVICE_VER", MPCF.ToInt(numSFVersion.Value));
                }
                else if (c_proc_case == '2')
                {
                    in_node.AddString("KEY_NAME", txtSCID.Text);
                    in_node.AddString("KEY_TYPE", cdvSKeyType.Text);
                    in_node.AddString("KEY_DESC", txtDesc.Text);
                    in_node.AddString("LIB_NAME", txtSModName.Text);
                    in_node.AddString("LIB_VER", txtSModVersion.Text);
                    in_node.AddString("SERVICE_NAME", txtSFuncName.Text);
                    in_node.AddInt("SERVICE_VER", MPCF.ToInt(numSFuncVersion.Value));
                    in_node.AddString("DATA_1", cdvCMF1.Text);
                    in_node.AddString("DATA_2", cdvCMF2.Text);
                    in_node.AddString("DATA_3", cdvCMF3.Text);
                    in_node.AddString("DATA_4", cdvCMF4.Text);
                    in_node.AddString("DATA_5", cdvCMF5.Text);
                }

                if (MPCR.CallService("SVM", "SVM_Update_Active_Function_Version", in_node, ref out_node) == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            return true;

        }

        private void SetCMFItem()
        {
            MPCR.InitGRPCMFControl("lblCMF", "cdvCMF", tbpCMF);
            if (MPCF.Trim(cdvSKeyType.Text) != "")
            {
                MPCR.SetCMFItem("FKT-" + cdvSKeyType.Text, "lblCMF", "cdvCMF", tbpCMF);
                if(MPCF.Trim(lblCMF1.Text) == "" && 
                    MPCF.Trim(lblCMF2.Text) == "" &&
                    MPCF.Trim(lblCMF3.Text) == "" &&
                    MPCF.Trim(lblCMF4.Text) == "" &&
                    MPCF.Trim(lblCMF5.Text) == "")
                {
                    MPCR.SetCMFItem(cdvSKeyType.Text, "lblCMF", "cdvCMF", tbpCMF);
                }
            }
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtMName;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmSVMSetupSharedFunctionVersion_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdActiveList);
            MPCF.ClearList(spdList);

            MPCR.InitGRPCMFControl("lblCMF", "cdvCMF", tbpCMF);
            rbtModule.Checked = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tabCase.SelectedTab == tbpActive)
            {
                if (CheckCondition('1') == false) return;
                if (Update_Active_Function_Version(MPGC.MP_STEP_UPDATE, '1') == false) return;
            }
            else if (tabCase.SelectedTab == tbpKey)
            {
                if (CheckCondition('2') == false) return;
                if (Update_Active_Function_Version(MPGC.MP_STEP_UPDATE, '2') == false) return;
            }

            if (MPGV.gbListAutoRefresh == true)
            {
                btnCreate.PerformClick();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tabCase.SelectedTab == tbpActive)
            {
                if (CheckCondition('1') == false) return;
                if (Update_Active_Function_Version(MPGC.MP_STEP_DELETE, '1') == false) return;
            }
            else if (tabCase.SelectedTab == tbpKey)
            {
                if (CheckCondition('2') == false) return;
                if (Update_Active_Function_Version(MPGC.MP_STEP_DELETE, '2') == false) return;
            }

            if (MPGV.gbListAutoRefresh == true)
            {
                btnCreate.PerformClick();
                if (tabCase.SelectedTab == tbpActive)
                {
                    MPCF.FieldClear(grpSetData1);
                }
                else if (tabCase.SelectedTab == tbpKey)
                {
                    MPCF.FieldClear(tbpGeneral);
                }
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tabCase.SelectedTab == tbpActive)
            {
                if (rbtModule.Checked == true)
                {
                    if (View_Active_Function_Version('1', '1') == false) return;
                }
                else if (rbtFunction.Checked == true)
                {
                    if (View_Active_Function_Version('2', '1') == false) return;
                }
            }
            else if (tabCase.SelectedTab == tbpKey)
            {
                if (View_Active_Function_Version('1', '2') == false) return;
            }
        }

        private void rbtModule_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtModule.Checked == true)
            {
                txtFName.Text = "";
                txtFName.Enabled = false;
                numFVersion.Value = 0;
                numFVersion.Enabled = false;

                txtSFName.Text = "";
                txtSFName.Enabled = false;
                numSFVersion.Value = 0;
                numSFVersion.Enabled = false;

                chkMLoadOnly.Enabled = true;
                chkSMLoadOnly.Enabled = true;

                spdActiveList.ActiveSheet.Columns[2, 2].Visible = true;
                spdActiveList.ActiveSheet.Columns[3, 4].Visible = false;
                MPCF.ClearList(spdActiveList);
            }
        }

        private void rbtFunction_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFunction.Checked == true)
            {
                txtFName.Enabled = true;
                numFVersion.Enabled = true;

                txtSFName.Enabled = true;
                numSFVersion.Enabled = true;

                chkMLoadOnly.Checked = false;
                chkMLoadOnly.Enabled = false;
                chkSMLoadOnly.Checked = false;
                chkSMLoadOnly.Enabled = false;

                spdActiveList.ActiveSheet.Columns[2, 2].Visible = false;
                spdActiveList.ActiveSheet.Columns[3, 4].Visible = true;
                MPCF.ClearList(spdActiveList);
            }
        }

        private void spdActiveList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column < 0) return;
            if (e.Row < 0) return;
            if (e.ColumnHeader == true) return;
            if (e.RowHeader == true) return;

            if (rbtModule.Checked == true)
            {
                txtSMName.Text = MPCF.Trim(spdActiveList.ActiveSheet.Cells[e.Row, 0].Value);
                txtSMVersion.Text = MPCF.Trim(spdActiveList.ActiveSheet.Cells[e.Row, 1].Value);

                if (MPCF.Trim(spdActiveList.ActiveSheet.Cells[e.Row, 2].Value) == "V")
                {
                    chkSMLoadOnly.Checked = true;
                }
                else
                {
                    chkSMLoadOnly.Checked = false;
                }
            }
            else
            {
                txtSMName.Text = MPCF.Trim(spdActiveList.ActiveSheet.Cells[e.Row, 0].Value);
                txtSMVersion.Text = MPCF.Trim(spdActiveList.ActiveSheet.Cells[e.Row, 1].Value);
                txtSFName.Text = MPCF.Trim(spdActiveList.ActiveSheet.Cells[e.Row, 3].Value);
                numSFVersion.Value = MPCF.ToInt(spdActiveList.ActiveSheet.Cells[e.Row, 4].Value);
            }
        }

        private void spdList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column < 0) return;
            if (e.Row < 0) return;
            if (e.ColumnHeader == true) return;
            if (e.RowHeader == true) return;

            txtSCID.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 0].Value);
            txtDesc.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 1].Value);
            cdvSKeyType.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 2].Value);
            txtSModName.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 3].Value);
            txtSModVersion.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 4].Value);
            txtSFuncName.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 5].Value);
            numSFuncVersion.Value = MPCF.ToInt(spdList.ActiveSheet.Cells[e.Row, 6].Value);
            cdvCMF1.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 7].Value);
            cdvCMF2.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 8].Value);
            cdvCMF3.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 9].Value);
            cdvCMF4.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 10].Value);
            cdvCMF5.Text = MPCF.Trim(spdList.ActiveSheet.Cells[e.Row, 11].Value);
            
        }

        private void cdvKeyType_ButtonPress(object sender, EventArgs e)
        {
            cdvKeyType.Init();
            MPCF.InitListView(cdvKeyType.GetListView);
            cdvKeyType.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvKeyType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvKeyType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvKeyType.GetListView, '1', MPGC.MP_FUNC_KEY_TYPE);
        }

        private void cdvSKeyType_TextBoxTextChanged(object sender, EventArgs e)
        {
            SetCMFItem();
            if (cdvSKeyType.Text == "RTD")
            {
                txtSCID.MaxLength = 20;
            }
            else
            {
                txtSCID.MaxLength = 50;
            }
        }

        private void cdvSKeyType_ButtonPress(object sender, EventArgs e)
        {
            cdvSKeyType.Init();
            MPCF.InitListView(cdvSKeyType.GetListView);
            cdvSKeyType.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvSKeyType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSKeyType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvSKeyType.GetListView, '1', MPGC.MP_FUNC_KEY_TYPE);
        }

        private void cdvCMF_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                MPCR.ProcGRPCMFButtonPress(sender);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

      
    }
}

