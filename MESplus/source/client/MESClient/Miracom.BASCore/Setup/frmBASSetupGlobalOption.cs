//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupGlobalOption.vb
//   Description : MFO Option Prompt/Definition Setup/View
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - ViewOptionPrompt() : View table which is included in one factory
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-11-27 : Created by Kenneth
//       - 2008-01-16 : Modified by W.Y.Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.BASCore
{
    public partial class frmBASSetupGlobalOption : Miracom.MESCore.SetupForm01
    {
        public frmBASSetupGlobalOption()
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
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal Proc_step As String : Process Step
        //
        private bool CheckCondition(char c_step)
        {
            int i;
            bool b_empty;

            switch (c_step)
            {
                case MPGC.MP_STEP_CREATE:
                case MPGC.MP_STEP_UPDATE:
                    switch (tabOption.SelectedIndex)
                    {
                        case 0:
                            if (MPCF.CheckValue(txtOptionName, 1) == false) return false;

                            b_empty = true;
                            for (i = 0; i < 5; i++)
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 0].Value) != "")
                                {
                                    b_empty = false;
                                }
                                if (b_empty == true)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(305));
                                    spdData.ActiveSheet.SetActiveCell(0, 0);
                                    return false;
                                }
                            }
                            break;

                        case 1:
                            if (MPCF.CheckValue(cdvOptionName, 1) == false) return false;
                            if (MPCR.CheckGRPCMFValue("lblValue", "cdvValue", grpValueDefinition) == false) return false;
                            break;
                    }
                    break;

                case MPGC.MP_STEP_DELETE:
                    switch (tabOption.SelectedIndex)
                    {
                        case 0:
                            if (MPCF.CheckValue(txtOptionName, 1) == false) return false;
                            break;
                        case 1:
                            if (MPCF.CheckValue(cdvOptionName, 1) == false) return false;
                            break;
                    }
                    break;
            }
            return true;
        }

        private void ClearData(char cType)
        {
            switch (cType)
            {
                case '1':   // TAB 0
                    MPCF.FieldClear(pnlPrompt);
                    spdData.ActiveSheet.ClearRange(0, 0, spdData.ActiveSheet.RowCount, spdData.ActiveSheet.ColumnCount, true);
                    break;
                case '2':   // TAB 1
                    MPCF.FieldClear(grpOptionDefinition);
                    MPCF.FieldClear(grpValueDefinition);

                    lblValue1.Visible = cdvValue1.Visible = lblValue2.Visible = cdvValue2.Visible = false;
                    lblValue3.Visible = cdvValue3.Visible = lblValue4.Visible = cdvValue4.Visible = false;
                    lblValue5.Visible = cdvValue5.Visible = false;
                    break;
                case '3':   // TAB 1, 정의된 Prompt 가 없거나 Prompt 없이 Option을 정의하는 경우
                    txtDEFCreateUser.Text = txtDEFCreateTime.Text = "";
                    txtDEFUpdateUser.Text = txtDEFUpdateTime.Text = "";

                    lblValue1.Text = "Value 1";
                    lblValue2.Text = "Value 2";
                    lblValue3.Text = "Value 3";
                    lblValue4.Text = "Value 4";
                    lblValue5.Text = "Value 5";

                    lblValue1.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);
                    lblValue2.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);
                    lblValue3.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);
                    lblValue4.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);
                    lblValue5.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);

                    cdvValue1.Text = cdvValue2.Text = cdvValue3.Text = cdvValue4.Text = cdvValue5.Text = "";

                    cdvValue1.VisibleButton = cdvValue2.VisibleButton = cdvValue3.VisibleButton = false;
                    cdvValue4.VisibleButton = cdvValue5.VisibleButton = false;

                    cdvValue1.ReadOnly = cdvValue2.ReadOnly = cdvValue3.ReadOnly = false;
                    cdvValue4.ReadOnly = cdvValue5.ReadOnly = false;

                    cdvValue1.Tag = cdvValue2.Tag = cdvValue3.Tag = "";
                    cdvValue4.Tag = cdvValue5.Tag = "";

                    lblValue1.Visible = cdvValue1.Visible = lblValue2.Visible = cdvValue2.Visible = true;
                    lblValue3.Visible = cdvValue3.Visible = lblValue4.Visible = cdvValue4.Visible = true;
                    lblValue5.Visible = cdvValue5.Visible = true;
                    break;
                case '4':   // TAB 1, 정의된 Prompt 가 존재하는 경우
                    lblValue1.Text = lblValue2.Text = lblValue3.Text = lblValue4.Text = lblValue5.Text = "";

                    lblValue1.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);
                    lblValue2.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);
                    lblValue3.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);
                    lblValue4.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);
                    lblValue5.Font = new System.Drawing.Font(lblValue1.Font, System.Drawing.FontStyle.Regular);

                    cdvValue1.Text = cdvValue2.Text = cdvValue3.Text = cdvValue4.Text = cdvValue5.Text = "";

                    cdvValue1.VisibleButton = cdvValue2.VisibleButton = cdvValue3.VisibleButton = false;
                    cdvValue4.VisibleButton = cdvValue5.VisibleButton = false;

                    cdvValue1.ReadOnly = cdvValue2.ReadOnly = cdvValue3.ReadOnly = false;
                    cdvValue4.ReadOnly = cdvValue5.ReadOnly = false;

                    cdvValue1.Tag = cdvValue2.Tag = cdvValue3.Tag = "";
                    cdvValue4.Tag = cdvValue5.Tag = "";

                    lblValue1.Visible = cdvValue1.Visible = lblValue2.Visible = cdvValue2.Visible = false;
                    lblValue3.Visible = cdvValue3.Visible = lblValue4.Visible = cdvValue4.Visible = false;
                    lblValue5.Visible = cdvValue5.Visible = false;
                    break;
            }
        }

        private void SetValueOption(int iValue, TRSNode value_item)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue = null;
            Label lblValue = null;
            string strTableName = value_item.GetString("VALUE_TBL");

            switch (iValue)
            {
                case 0:
                    lblValue = lblValue1; 
                    cdvValue = cdvValue1; 
                    break;

                case 1:
                    lblValue = lblValue2; 
                    cdvValue = cdvValue2; 
                    break;

                case 2: 
                    lblValue = lblValue3; 
                    cdvValue = cdvValue3; 
                    break;

                case 3: 
                    lblValue = lblValue4; 
                    cdvValue = cdvValue4; 
                    break;

                case 4: 
                    lblValue = lblValue5; 
                    cdvValue = cdvValue5; 
                    break;
            }

            lblValue.Text = value_item.GetString("VALUE_PMT");
            lblValue.Visible = cdvValue.Visible = true;
            lblValue.Font = new System.Drawing.Font(lblValue.Font, System.Drawing.FontStyle.Bold);
            cdvValue.Tag = value_item.GetChar("VALUE_FMT") + strTableName;
            cdvValue.VisibleButton = (strTableName == "") ? false : true;

            if (cdvValue.VisibleButton == true)
                cdvValue.ReadOnly = true;
            else
                cdvValue.ReadOnly = false;

        }


        private bool ViewOptionPrompt(char c_step, string s_option_name)
        {
            TRSNode in_node = new TRSNode("VIEW_GLOBAL_OPTION_PROMPT_IN");
            TRSNode out_node = new TRSNode("VIEW_GLOBAL_OPTION_PROMPT_OUT");
            List<TRSNode> node_list;
            int i;

            try
            {
                ClearData(c_step);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPTION_NAME", MPCF.Trim(s_option_name));

                if (MPCR.CallService("BAS", "BAS_View_Global_Option_Prompt", in_node, ref out_node, true) == false)
                {
                    // c_step = '2' 이고 해당하는 Option Prompt 를 찾지 못한 경우 그냥 Return True 한다.
                    if (c_step == '2' && out_node.MsgCode == "BAS-0007")
                    {
                        ClearData('3');
                        return true;
                    }

                    MPCR.CheckContinueProc(out_node);
                    return false;
                }


                switch (c_step)
                {
                    case '1':
                        txtOptionName.Text = out_node.GetString("OPTION_NAME");
                        txtOptionDescPrompt.Text = out_node.GetString("OPTION_DESC");
                        chkMESplusPmtFlag.Checked = (out_node.GetChar("MESPLUS_FLAG") == 'Y' ? true : false);
                        txtPMTCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                        txtPMTCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                        txtPMTUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                        txtPMTUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                        node_list = out_node.GetList("PROMPT_LIST");
                        for (i = 0; i < node_list.Count; i++)
                        {
                            spdData.ActiveSheet.Cells[i, 0].Value = node_list[i].GetString("VALUE_PMT");
                            switch (node_list[i].GetChar("VALUE_FMT"))
                            {
                                case 'A':
                                    spdData.ActiveSheet.Cells[i, 1].Value =  "Ascii";
                                    break;
                                case 'N':
                                    spdData.ActiveSheet.Cells[i, 1].Value =  "Number";
                                    break;
                                case 'F':
                                    spdData.ActiveSheet.Cells[i, 1].Value =  "Float";
                                    break;
                            }

                            spdData.ActiveSheet.Cells[i, 2].Value =  node_list[i].GetString("VALUE_TBL");
                        }
                        break;

                    case '2':

                        cdvOptionName.Text = out_node.GetString("OPTION_NAME");
                        txtOptionDescDefinition.Text = out_node.GetString("OPTION_DESC");
                        chkMESplusOption.Checked = (out_node.GetChar("MESPLUS_FLAG") == 'Y' ? true : false);
                        
                        ClearData('4');

                        node_list = out_node.GetList("PROMPT_LIST");
                        for (i = 0; i < node_list.Count; i++)
                        {
                            if (node_list[i].GetString("VALUE_PMT") != "" &&
                                node_list[i].GetChar("VALUE_FMT") != ' ')
                            {
                                SetValueOption(i, node_list[i]);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ViewOptionPromptList(ListView lisList)
        {
            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");
            ListViewItem itmX;
            List<TRSNode> pmt_list;
            int i;
            int i_icon_index;
            string s_option_name;

            MPCF.InitListView(lisList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCR.CallService("BAS", "BAS_View_Global_Option_Prompt_List", in_node, ref out_node) == false)
            {
                return false;
            }

            pmt_list = out_node.GetList("PROMPT_LIST");

            for (i = 0; i < pmt_list.Count; i++)
            {
                i_icon_index = (int)SMALLICON_INDEX.IDX_VERSION;
                s_option_name = pmt_list[i].GetString("OPTION_NAME");

                if (tabOption.SelectedTab == tbpOption)
                {
                    if (MPCF.FindListItemIndex(lisGOption, s_option_name, false) < 0)
                    {
                        i_icon_index = (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL;
                    }
                }

                itmX = new ListViewItem(s_option_name, i_icon_index);
                itmX.SubItems.Add(pmt_list[i].GetString("OPTION_DESC"));

                if (pmt_list[i].GetChar("MESPLUS_FLAG") == 'Y')
                {
                    itmX.ForeColor = Color.Blue;
                }

                lisList.Items.Add(itmX);
            }

            MPCF.FitColumnHeader(lisList);

            return true;
        }

        private bool UpdateOptionPrompt(char c_step)
        {
            TRSNode in_node = new TRSNode("OPTION_PROMPT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;

            int i;
            string s_prompt;
            char c_format;
            string s_table;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("OPTION_NAME", MPCF.Trim(txtOptionName.Text));
                in_node.AddString("OPTION_DESC", MPCF.Trim(txtOptionDescPrompt.Text));
                in_node.AddChar("SYS_PMT_FLAG", (chkMESplusPmtFlag.Checked == true ? 'Y' : ' '));


                if (c_step != MPGC.MP_STEP_DELETE)
                {
                    for (i = 0; i < 5; i++)
                    {
                        list_item = in_node.AddNode("PROMPT_LIST");

                        s_prompt = MPCF.Trim(spdData.ActiveSheet.Cells[i, 0].Value);
                        c_format = MPCF.ToChar(spdData.ActiveSheet.Cells[i, 1].Value);
                        s_table = MPCF.Trim(spdData.ActiveSheet.Cells[i, 2].Value);

                        list_item.AddString("VALUE_PMT", s_prompt);
                        if (s_prompt != "")
                        {
                            if (c_format == ' ')
                            {
                                c_format = 'A';
                            }

                            list_item.AddChar("VALUE_FMT", c_format);
                            list_item.AddString("VALUE_TBL", s_table);
                        }
                    }
                }

                if (MPCR.CallService("BAS", "BAS_Update_Global_Option_Prompt", in_node, ref out_node) == false)
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


        private bool ViewOption(string s_option_name)
        {
            TRSNode in_node = new TRSNode("VIEW_GLOBAL_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_GLOBAL_OPTION_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPTION_NAME", s_option_name);

                if (MPCR.CallService("BAS", "BAS_View_Global_Option", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvOptionName.Text = out_node.GetString("OPTION_NAME");
                txtOptionDescDefinition.Text = out_node.GetString("OPTION_DESC");
                txtDEFCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtDEFCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtDEFUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtDEFUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                cdvValue1.Text = out_node.GetString("VALUE_1");
                cdvValue2.Text = out_node.GetString("VALUE_2");
                cdvValue3.Text = out_node.GetString("VALUE_3");
                cdvValue4.Text = out_node.GetString("VALUE_4");
                cdvValue5.Text = out_node.GetString("VALUE_5");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ViewOptionList()
        {
            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");
            ListViewItem itmX;
            List<TRSNode> option_list;
            int i;

            MPCF.InitListView(lisGOption);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            try
            {
                if (MPCR.CallService("BAS", "BAS_View_Global_Option_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                option_list = out_node.GetList("OPTION_LIST");
                for (i = 0; i < option_list.Count; i++)
                {

                    itmX = new ListViewItem(option_list[i].GetString("OPTION_NAME"), (int)SMALLICON_INDEX.IDX_VERSION);
                    itmX.SubItems.Add(option_list[i].GetString("OPTION_DESC"));

                    itmX.SubItems.Add(option_list[i].GetString("VALUE_1"));
                    itmX.SubItems.Add(option_list[i].GetString("VALUE_2"));
                    itmX.SubItems.Add(option_list[i].GetString("VALUE_3"));
                    itmX.SubItems.Add(option_list[i].GetString("VALUE_4"));
                    itmX.SubItems.Add(option_list[i].GetString("VALUE_5"));

                    if (option_list[i].GetChar("MESPLUS_FLAG") == 'Y')
                    {
                        itmX.ForeColor = Color.Blue;
                    }

                    lisGOption.Items.Add(itmX);
                }

                MPCF.FitColumnHeader(lisGOption);

                if (lisGOption.Items.Count > 0)
                {
                    if (MPCF.FindListItem(lisGOption, cdvOptionName.Text, false) == false)
                    {
                        lisGOption.Items[0].Selected = true;
                    }

                    lblDataCount.Text = lisGOption.Items.Count.ToString();
                }
                else
                {
                    ClearData('2');
                    lblDataCount.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool UpdateOption(char c_step)
        {
            TRSNode in_node = new TRSNode("OPTION_DEFINITION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("OPTION_NAME", MPCF.Trim(cdvOptionName.Text));

                if (c_step != MPGC.MP_STEP_DELETE)
                {
                    in_node.AddString("OPTION_DESC", MPCF.Trim(txtOptionDescDefinition.Text));

                    in_node.AddString("VALUE_1", MPCF.Trim(cdvValue1.Text));
                    in_node.AddString("VALUE_2", MPCF.Trim(cdvValue2.Text));
                    in_node.AddString("VALUE_3", MPCF.Trim(cdvValue3.Text));
                    in_node.AddString("VALUE_4", MPCF.Trim(cdvValue4.Text));
                    in_node.AddString("VALUE_5", MPCF.Trim(cdvValue5.Text));
                }

                if (MPCR.CallService("BAS", "BAS_Update_Global_Option", in_node, ref out_node) == false)
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
                return this.cdvOptionName;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmBASSetupGlobalOption_Load(object sender, EventArgs e)
        {
            tabOption.SelectedTab = tbpOption;
            if (MPGV.gsFactory == MPGV.gsCentralFactory)
            {
                chkMESplusPmtFlag.Enabled = true;
            }
            else
            {
                chkMESplusPmtFlag.Enabled = false;
            }
        }

        private void frmBASSetupGlobalOption_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.InitListView(lisOption);
                    
                    ViewOptionList();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (tabOption.SelectedIndex)
            {
                case 0:
                    MPCF.FindListItemNextPartial(lisOption, txtFind.Text, true, false);
                    break;
                case 1:
                    MPCF.FindListItemNextPartial(lisGOption, txtFind.Text, true, false);
                    break;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            switch (tabOption.SelectedIndex)
            {
                case 0:
                    MPCF.ExportToExcel(lisOption, this.Text, "");
                    break;
                case 1:
                    MPCF.ExportToExcel(lisGOption, this.Text, "");
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            switch (tabOption.SelectedIndex)
            {
                case 0:
                    ViewOptionPromptList(lisOption);
                    if (lisOption.Items.Count > 0)
                    {
                        if (MPCF.FindListItem(lisOption, txtOptionName.Text, false) == false)
                        {
                            lisOption.Items[0].Selected = true;
                        }

                        lblDataCount.Text = lisOption.Items.Count.ToString();
                    }
                    else
                    {
                        ClearData('1');
                        lblDataCount.Text = "0";
                    }
                    break;
                case 1:
                    ViewOptionList();
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;

                switch (tabOption.SelectedIndex)
                {
                    case 0:
                        if (UpdateOptionPrompt(MPGC.MP_STEP_CREATE) == false) return;
                        break;
                    case 1:
                        if (UpdateOption(MPGC.MP_STEP_CREATE) == false) return;
                        break;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;

                switch (tabOption.SelectedIndex)
                {
                    case 0:
                        if (UpdateOptionPrompt(MPGC.MP_STEP_UPDATE) == false) return;
                        break;
                    case 1:
                        if (UpdateOption(MPGC.MP_STEP_UPDATE) == false) return;
                        break;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                    return;

                if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;

                switch (tabOption.SelectedIndex)
                {
                    case 0:
                        if (UpdateOptionPrompt(MPGC.MP_STEP_DELETE) == false) return;
                        break;
                    case 1:
                        if (UpdateOption(MPGC.MP_STEP_DELETE) == false) return;
                        break;
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

        private void spdData_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            cdvGCMTableList.Init();
            cdvGCMTableList.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvGCMTableList.GetListView);
            cdvGCMTableList.Columns.Add("Table", 30, HorizontalAlignment.Left);
            cdvGCMTableList.Columns.Add("Desc", 80, HorizontalAlignment.Left);
            cdvGCMTableList.ViewPosition = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
            BASLIST.ViewGCMTableList(cdvGCMTableList.GetListView, '1');
            cdvGCMTableList.InsertEmptyRow(0, 1);
            cdvGCMTableList.ShowPopUp(e.Row, e.Column - 1);
        }

        private void spdData_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, 0].Value) == "") spdData.ActiveSheet.ClearRange(e.Row, 0, 1, 4, true);
        }

        private void cdvGCMTableList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdData.ActiveSheet.Cells[e.Row, e.Col].Value = e.SelectedItem.SubItems[0].Text;
        }

        private void lisOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisOption.SelectedItems.Count < 1) return;

            ViewOptionPrompt('1', lisOption.SelectedItems[0].Text);
        }

        private void lisGOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisGOption.SelectedItems.Count < 1) return;

            ViewOptionPrompt('2', lisGOption.SelectedItems[0].Text);
            ViewOption(lisGOption.SelectedItems[0].Text);
        }

        private void cdvOptionName_ButtonPress(object sender, EventArgs e)
        {
            cdvOptionName.Init();
            MPCF.InitListView(cdvOptionName.GetListView);
            cdvOptionName.Columns.Add("Option", 30, HorizontalAlignment.Left);
            cdvOptionName.Columns.Add("Desc", 80, HorizontalAlignment.Left);
            cdvOptionName.SelectedSubItemIndex = 0;
            ViewOptionPromptList(cdvOptionName.GetListView);
        }

        private void cdvOptionName_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.FindListItem(lisGOption, cdvOptionName.Text, false) == false)
            {
                ViewOptionPrompt('2', cdvOptionName.Text);
            }
        }

        private void cdvOptionName_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            ClearData('3');
        }

        private void tabOption_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    if (MPCF.Trim(lisOption.Tag) == "")
                    {
                        ViewOptionPromptList(lisOption);
                        lisOption.Tag = "READED";
                    }

                    txtFind.Text = "";
                    if (lisOption.Items.Count > 0)
                    {
                        lblDataCount.Text = lisOption.Items.Count.ToString();
                    }
                    else
                    {
                        lblDataCount.Text = "0";
                    }

                    break;

                case 1:
                    if (b_load_flag == true)
                    {
                        if (lisGOption.Items.Count > 0)
                        {
                            if (MPCF.FindListItem(lisGOption, cdvOptionName.Text, false) == false)
                            {
                                lisGOption.Items[0].Selected = true;
                            }

                            lblDataCount.Text = lisGOption.Items.Count.ToString();
                        }
                        else
                        {
                            ClearData('2');
                            lblDataCount.Text = "0";
                        }
                    }
                    break;
            }
        }

        private void cdvValue_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            MPCR.ProcGRPCMFButtonPress(cdvTemp);
        }

        private void cdvValue_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            char cFormat;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if ((MPCF.Trim(cdvTemp.Tag) != ""))
            {
                cFormat = MPCF.Trim(cdvTemp.Tag)[0];
                if (cFormat == 'N' || cFormat == 'F')
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (!(e.KeyChar == (char)43 || e.KeyChar == (char)45 || e.KeyChar == (char)8))
                        {
                            if (cFormat == 'F')
                            {
                                if (cdvTemp.Text.IndexOf((char)46) > -1)
                                {
                                    e.Handled = true;
                                }

                                if (!(e.KeyChar == (char)46))
                                {
                                    e.Handled = true;
                                }
                            }
                            else
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (e.KeyChar == (char)43 || e.KeyChar == (char)45)
                            {
                                if (MPCF.Trim(cdvTemp.Text) != "")
                                {
                                    e.Handled = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtOptionName_Leave(object sender, EventArgs e)
        {
            if (MPGV.gsFactory != MPGV.gsCentralFactory)
            {
                if (lisOption.SelectedItems.Count > 0)
                {
                    if (txtOptionName.Text != "")
                    {
                        if (MPCF.Trim(lisOption.SelectedItems[0].Text) != txtOptionName.Text)
                        {
                            chkMESplusPmtFlag.Checked = false;
                        }
                    }
                }
                else if (txtOptionName.Text != "")
                {
                    chkMESplusPmtFlag.Checked = false;
                }
            }

        }




    }
}
