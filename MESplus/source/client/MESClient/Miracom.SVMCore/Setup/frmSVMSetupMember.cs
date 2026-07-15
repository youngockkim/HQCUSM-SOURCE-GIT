
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSVMSetupMember.cs
//   Description : Setup Memeber Definition
//
//   MES Version : 4.2.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check Condition
//       - View_member()
//       - View_Member_list()
//       - Update_Member()
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-11-19 : Created by HyunJong Noh
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.MESCore;
using Miracom.TRSCore;
using Miracom.CliFrx;
using System.IO;


namespace Miracom.SVMCore
{
    public partial class frmSVMSetupMember : MESCore.SetupForm02
    {

        public frmSVMSetupMember()
        {
            InitializeComponent();
        }

        #region " Variable Definition"
        private bool b_load_flag = false;
        private bool b_export_stop = false;
        #endregion
                
        #region " Function Implementations"

        private bool CheckCondition(char FuncName)
        {
            switch(FuncName)
            {
                case MPGC.MP_STEP_CREATE:
                case MPGC.MP_STEP_UPDATE:
                    if (MPCF.CheckValue(txtMemberName, 1) == false) return false;
                    if (MPCF.CheckValue(cbxMemberType, 1) == false) return false;
                    if(cbxMemberType.Text == "String")
                        if (MPCF.CheckValue(txtMemberSize, 1) == false) return false;
                    if(cbxMemberType.Text == "Array")
                        if (MPCF.CheckValue(cbxArrayType, 1) == false) return false;
                    if (MPCF.CheckValue(txtMemberDesc_1, 1) == false) return false;
                    if (chkUseRange.Checked)
                    {
                        if (nudRangeMin.Value.ToString() == "")
                        {
                            if(MPCF.CheckValue(nudRangeMin, 1) == false)
                            {
                                nudRangeMin.Focus();
                                return false;
                            }                            
                        }
                        if (nudRangeMax.Value.ToString() == "")
                        {
                            if (MPCF.CheckValue(nudRangeMax, 1) == false)
                            {
                                nudRangeMax.Focus();
                                return false;
                            }                            
                        }
                    }
                    break;

                case MPGC.MP_STEP_DELETE:
                    if (MPCF.CheckValue(txtMemberName, 1) == false) return false;
                    break;
            }

            return true;
        }

        private void ClearData()
        {
            txtMemberName.Text = "";
            txtMemberDesc_1.Text = "";
            txtMemberDesc_2.Text = "";
            txtMemberDesc_3.Text = "";
            txtMemberSize.Text = "";
            chkUseRange.Checked = false;
            nudRangeMin.Text = "";
            nudRangeMax.Text = "";
            cbxMemberType.SelectedIndex = -1;
            cbxArrayType.SelectedIndex = -1;
        }

        private bool View_member()
        {
            if (lisMember.SelectedItems.Count == 0)
                return false;

            TRSNode in_node = new TRSNode("View_Member_In");
            TRSNode out_node = new TRSNode("View_Member_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MEMBER_NAME", lisMember.SelectedItems[0].Text);

            if (MPCR.CallService("SVM", "SVM_View_Member", in_node, ref out_node) == false)
            {
                return false;
            }

            txtMemberName.Text = out_node.GetString("MEMBER_NAME");
            txtMemberDesc_1.Text = out_node.GetString("MEMBER_DESC_1");
            txtMemberDesc_2.Text = out_node.GetString("MEMBER_DESC_2");
            txtMemberDesc_3.Text = out_node.GetString("MEMBER_DESC_3");

            txtMemberCreateUser.Text = out_node.GetString("CREATE_USER_ID");
            txtMemberCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtMemberUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
            txtMemberUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

            txtMemberSize.Text = out_node.GetInt("MEMBER_SIZE").ToString();

            cbxMemberType.Text = out_node.GetString("MEMBER_TYPE");

            string array_type = out_node.GetString("ARRAY_TYPE");

            if (array_type != "")
                cbxArrayType.Text = array_type;

            if (out_node.GetChar("USE_RANGE_FLAG") == 'Y')
            {
                chkUseRange.Checked = true;
                nudRangeMin.Text = out_node.GetDouble("RANGE_MIN").ToString();
                nudRangeMax.Text = out_node.GetDouble("RANGE_MAX").ToString();
            }
            else
            {
                nudRangeMin.Text = "";
                nudRangeMax.Text = "";
            }

            txtExpMember.Text = out_node.GetString("MEMBER_NAME");

            return true;
        }

        private bool View_Member_list()
        {
            TRSNode in_node = new TRSNode("View_Member_List_In");
            TRSNode out_node = new TRSNode("View_Member_List_Out");
            ListViewItem itmx;
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            MPCF.InitListView(lisMember);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Member_List", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmx = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("MEMBER_NAME"),
                                                           out_node.GetList(0)[i].GetString("MEMBER_TYPE"),
                                                           out_node.GetList(0)[i].GetInt("MEMBER_SIZE").ToString(),
                                                           out_node.GetList(0)[i].GetString("MEMBER_DESC_1")}, (int)SMALLICON_INDEX.IDX_PART);
                    lisMember.Items.Add(itmx);                                 
                }

                in_node.SetString("MEMBER_NAME", out_node.GetString("NEXT_MEMBER_NAME"));
            } while (in_node.GetString("MEMBER_NAME") != "");

            lblDataCount.Text = out_node.GetList(0).Count.ToString();

            return true;
        }

        private bool Update_Member(char step)
        {
            TRSNode in_node = new TRSNode("Update_Member_In");
            TRSNode out_node = new TRSNode("Update_Member_Out");

            if (CheckCondition(step) == false)
                return false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = step;

            in_node.AddString("MEMBER_NAME", txtMemberName.Text);
            in_node.AddString("MEMBER_DESC_1", txtMemberDesc_1.Text);
            in_node.AddString("MEMBER_DESC_2", txtMemberDesc_2.Text);
            in_node.AddString("MEMBER_DESC_3", txtMemberDesc_3.Text);            

            if (chkUseRange.Checked)
            {
                in_node.AddChar("USE_RANGE_FLAG", 'Y');
                in_node.AddDouble("RANGE_MIN", double.Parse(nudRangeMin.Text));
                in_node.AddDouble("RANGE_MAX", double.Parse(nudRangeMax.Text));
            }
            else
            {
                in_node.AddChar("USE_RANGE_FLAG", ' ');
            }
           
            in_node.AddString("MEMBER_TYPE", cbxMemberType.Text);
            in_node.AddString("ARRAY_TYPE", cbxArrayType.Text);

            if (cbxMemberType.Text == "String" || cbxArrayType.Text == "String")
            {
                in_node.AddInt("MEMBER_SIZE", MPCF.ToInt(txtMemberSize.Text));
            }
            else
            {
                in_node.AddInt("MEMBER_SIZE", 0);
            }


            if (MPCR.CallService("SVM", "SVM_Update_Member", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            if (MPGV.gbListAutoRefresh == false)
            {
                ListViewItem itm;
                int idx;

                if (step == MPGC.MP_STEP_CREATE)
                {
                    itm = lisMember.Items.Add(txtMemberName.Text, (int)SMALLICON_INDEX.IDX_PART);
                    itm.SubItems.Add(cbxMemberType.Text);
                    itm.SubItems.Add(txtMemberSize.Text);
                    itm.SubItems.Add(txtMemberDesc_1.Text);
                    itm.Selected = true;
                    lisMember.Sorting = SortOrder.Ascending;
                    lisMember.Sort();
                    itm.EnsureVisible();
                }
                else if (step == MPGC.MP_STEP_UPDATE)
                {
                    if (MPCF.FindListItem(lisMember, MPCF.Trim(txtMemberName.Text), false) == true)
                    {
                        lisMember.SelectedItems[0].SubItems[1].Text = MPCF.Trim(cbxMemberType.Text);
                        lisMember.SelectedItems[0].SubItems[2].Text = MPCF.Trim(txtMemberSize.Text);
                        lisMember.SelectedItems[0].SubItems[3].Text = MPCF.Trim(txtMemberDesc_1.Text);
                    }
                }
                else if (step == MPGC.MP_STEP_DELETE)
                {
                    idx = MPCF.FindListItemIndex(lisMember, MPCF.Trim(txtMemberName.Text), false);
                    if (idx > -1)
                    {
                        lisMember.Items[idx].Remove();
                    }
                }
                lblDataCount.Text = lisMember.Items.Count.ToString();
            }
            else
            {
                View_Member_list();
    
                if(step == MPGC.MP_STEP_DELETE)
                    ClearData();
            }

            
            return true;
        }
        
        #endregion

        private void frmSVMSetupMember_Activated(object sender, EventArgs e)
        {
            if (b_load_flag != true)
            {
                View_Member_list();
                b_load_flag = true;
            }
        }
                
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string memberName = "";

            memberName = txtMemberName.Text;

            if (Update_Member(MPGC.MP_STEP_CREATE))
            {
                int index = MPCF.FindListItemNextPartial(lisMember, memberName, true, true);
                lisMember.EnsureVisible(index);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string memberName = "";

            memberName = txtMemberName.Text;

            if (Update_Member(MPGC.MP_STEP_UPDATE))
            {
                int index = MPCF.FindListItemNextPartial(lisMember, memberName, true, false);
                lisMember.EnsureVisible(index);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            Update_Member(MPGC.MP_STEP_DELETE);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            View_Member_list();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisMember, this.Text, "");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisMember, txtFind.Text, true, false);
        }

        private void txtMemberSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            MPCF.FindListItemPartial(lisMember, txtFind.Text, 0, true, false);
        }

        private void cbxMemberType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void chkUseRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseRange.Checked)
            {
                nudRangeMin.Enabled = true;
                nudRangeMax.Enabled = true;
            }
            else
            {
                nudRangeMin.Enabled = false;
                nudRangeMax.Enabled = false;
            }
        }

        private void lisMember_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lisMember.SelectedItems.Count != 0)
            {
                ClearData();
                View_member();
            }
        }

        private void SetRanges(string valueType)
        {
            double default_min = -99999999999999.0000;
            double default_max = 99999999999999.0000;

            short rangeValue_short = 32767;
            int rangeValue_int = 2147483647;
            long rangeValue_long = 99999999999999;

            ushort rangeValue_ushort = 65535;
            uint rangeValue_uint = 4294967295;
            ulong rangeValue_ulong = 99999999999999;

            int decimalPlaces = 0;
            decimal range_min = 0;
            decimal range_max = 0;
            

            switch(valueType)
            {
                case "String":
                case "Char":
                case "Binary":
                case "Boolean":
                case "Datetime":
                case "Blob":
                case "List":
                case "Array":
                case "Float":
                case "Double":
                    decimalPlaces = 4;
                    range_min = (decimal)default_min;
                    range_max = (decimal)default_max;
                    break;
                /* Unsigned */
                case "UShort":
                    decimalPlaces = 0;
                    range_min = 0;
                    range_max = rangeValue_ushort;
                    break;
                case "UInt":
                    decimalPlaces = 0;
                    range_min = 0;
                    range_max = rangeValue_uint;
                    break;
                case "ULong":
                    decimalPlaces = 0;
                    range_min = 0;
                    range_max = rangeValue_ulong;
                    break;
                /* Signed */
                case "Short":
                    decimalPlaces = 0;
                    range_min = -1 - rangeValue_short;
                    range_max = rangeValue_short;
                    break;
                case "Int":
                    decimalPlaces = 0;
                    range_min = -1 - rangeValue_int;
                    range_max = rangeValue_int;
                    break;
                case "Long":
                    decimalPlaces = 0;
                    range_min = 0 - rangeValue_long;
                    range_max = rangeValue_long;
                    break;
            }

            nudRangeMin.DecimalPlaces = decimalPlaces;
            nudRangeMax.DecimalPlaces = decimalPlaces;
            nudRangeMin.Minimum = range_min;
            nudRangeMin.Maximum = range_max;
            nudRangeMax.Minimum = range_min;
            nudRangeMax.Maximum = range_max;
        }

        private void cbxMemberType_TextChanged(object sender, EventArgs e)
        {
            if (cbxMemberType.Items.Contains(cbxMemberType.Text) == false)
            {
                cbxMemberType.SelectedIndex = -1;
                cbxMemberType.Text = "";
            }
            else
            {
                // Default Setting 적용
                lblRange.Visible = false;                
                chkUseRange.Visible = false;
                chkUseRange.Checked = false;
                nudRangeMin.Visible = false;
                nudRangeMin.Enabled = false;
                lblBetween.Visible = false;
                nudRangeMax.Visible = false;
                nudRangeMax.Enabled = false;

                lblArrayType.Visible = false;
                cbxArrayType.Visible = false;
                cbxArrayType.SelectedIndex = -1;

                lblMemberSize.Visible = false;
                txtMemberSize.Visible = false;

                // 세부 항목별 Setting 적용
                switch (cbxMemberType.Text)
                {
                    case "String":
                        lblMemberSize.Visible = true;
                        txtMemberSize.Visible = true;
                        break;
                    case "Array":
                        lblArrayType.Visible = true;
                        cbxArrayType.Visible = true;
                        break;
                    case "List":
                    case "Datetime":
                    case "Blob":
                    case "Boolean":
                        break;
                    case "Char":
                        txtMemberSize.Text = "";
                        break;
                    default:
                        txtMemberSize.Text = "";
                        lblRange.Visible = true;
                        chkUseRange.Visible = true;
                        nudRangeMin.Visible = true;
                        lblBetween.Visible = true;
                        nudRangeMax.Visible = true;
                        break;
                }

                SetRanges(cbxMemberType.Text);
            }
        }

        private void cbxArrayType_TextChanged(object sender, EventArgs e)
        {
            if (cbxMemberType.Text == "Array")
            {
                if (cbxArrayType.Items.Contains(cbxArrayType.Text) == false)
                {
                    cbxArrayType.SelectedIndex = -1;
                    cbxArrayType.Text = "";
                }
                else
                {
                    lblRange.Visible = false;
                    chkUseRange.Visible = false;
                    chkUseRange.Checked = false;
                    nudRangeMin.Visible = false;
                    nudRangeMin.Enabled = false;
                    lblBetween.Visible = false;
                    nudRangeMax.Visible = false;
                    nudRangeMax.Enabled = false;

                    lblMemberSize.Visible = false;
                    txtMemberSize.Visible = false;

                    // 세부 항목별 Setting 적용
                    switch (cbxArrayType.Text)
                    {
                        case "String":
                            lblMemberSize.Visible = true;
                            txtMemberSize.Visible = true;
                            break;
                        case "Array":
                        case "List":
                        case "Datetime":
                        case "Blob":
                        case "Boolean":
                            break;
                        case "Char":
                            txtMemberSize.Text = "";
                            break;
                        default:
                            txtMemberSize.Text = "";
                            lblRange.Visible = true;
                            chkUseRange.Visible = true;
                            nudRangeMin.Visible = true;
                            lblBetween.Visible = true;
                            nudRangeMax.Visible = true;
                            break;
                    }

                    SetRanges(cbxArrayType.Text);
                }
            }
        }

        private void btnExpFile_Click(object sender, EventArgs e)
        {
            sfdFile.Filter = "SQL | *.sql";
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                txtExpFile.Text = sfdFile.FileName;
                txtExport.Text = "";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            string Query = null;
            string data;
            txtExport.Text = "";
            int i, j;
            string temp = null;
            string cmt = null;
            StringBuilder script = null;

            #region rdobutton 체크
            if (rboMember.Checked == true)
            {
                Query = "SELECT * FROM MSVMMBRDEF WHERE MEMBER_NAME = '" + txtExpMember.Text + "'";
                cmt = "MSVMMBRDEF Table(MEMBER_NAME) : " + txtExpMember.Text;
            }
            else if (rboAllTbl.Checked == true)
            {
                Query = "SELECT * FROM MSVMMBRDEF ORDER BY MEMBER_NAME";
                cmt = "MSVMMBRDEF Table(All Table) : MSVMMBRDEF";
            }
            #endregion

            script = new StringBuilder();
            progressBarExport.Value = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", Query);

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    progressBarExport.Maximum = out_node.GetList("ROWS").Count;

                    #region 컬럼명 셋팅
                    temp = "INSERT INTO MSVMMBRDEF(";

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        temp += out_node.GetList(0)[i].GetString("NAME");
                        if (i < out_node.GetList(0).Count - 1) temp += ", ";
                    }
                    temp += ") VALUES(";
                    script.Append("/* Start [" + cmt + "] */\r\n");
                    script.Append(temp);
                    #endregion

                    if (out_node.GetList("ROWS").Count <= 0)
                    {
                        txtExport.Text = "No Data";
                        return;
                    }

                    //Request Reply Timeout 발생시 옵션에서 TimeOut시간을 늘려주어야함
                    #region Data값 받기
                    for (i = 0; i < out_node.GetList("ROWS").Count; i++)
                    {
                        for (j = 0; j < out_node.GetList("COLUMNS").Count; j++)
                        {
                            if (out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA") == "")
                            {
                                script.Append("' ");
                                if (j < out_node.GetList(0).Count - 1) script.Append("', ");
                                else script.Append("'");
                            }
                            else
                            {
                                script.Append("'");
                                if (out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA").Contains("'"))
                                {
                                    data = out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA").Replace("'", "''");
                                }
                                else
                                {
                                    data = out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA");
                                }
                                script.Append(data);
                                if (j < out_node.GetList(0).Count - 1) script.Append("', ");
                                else script.Append("'");
                            }
                        }
                        script.Append(");\r\n");
                        progressBarExport.Increment(1);

                        if (b_export_stop) //Stop 처리
                        {
                            txtExport.Focus();
                            txtExport.AppendText("<User Stop>..." + "\r\n");
                            b_export_stop = false;
                            return;
                        }
                        if (i < out_node.GetList("ROWS").Count - 1) script.Append(temp);
                        if (i >= out_node.GetList("ROWS").Count - 1) script.Append("/* End [" + cmt + "] */\r\n\r\n");
                    }
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (out_node.GetInt("NEXT_ROW") > 0);
                    #endregion

                txtExport.Text = script.ToString();
                txtExport.Select(0, txtExport.Text.Length);
                txtExport.SelectionFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
                progressBarExport.Increment(1);

                if (txtExpFile.Text != "")
                {
                    StreamWriter write = new StreamWriter(txtExpFile.Text, false, Encoding.GetEncoding("EUC-KR"));
                    write.Write(script);
                    write.Close();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            progressBarExport.Value = 0;
            return;
        }

        private void btnExpStop_Click(object sender, EventArgs e)
        {
            b_export_stop = true;
        }

        private void btnExpCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(txtExport.Text) != "")
                {
                    Clipboard.SetText(txtExport.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}