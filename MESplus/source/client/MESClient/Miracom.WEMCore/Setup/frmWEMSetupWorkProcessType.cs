//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWEMSetupWorkProcessType.cs
//   Description : MES Cient Form Work Process Type Setup Class
//
//   MES Version : 5.3.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-11-01 : Created by Aiden
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WEMCore
{
    public partial class frmWEMSetupWorkProcessType : SetupForm02
    {
        public frmWEMSetupWorkProcessType()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private List<String> ls_deleted_status;

        #endregion

        #region " Function Definition "

        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition(char c_proc_step)
        {
            int i;

            if (MPCF.CheckValue(txtProcType, 1) == false) return false;

            switch (c_proc_step)
            {
                case MPGC.MP_STEP_CREATE:
                    if (spdStatus.ActiveSheet.RowCount < 1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                        spdStatus.Focus();
                        return false;
                    }
                    break;
                case MPGC.MP_STEP_UPDATE:
                    for (i = 0; i < spdStatus.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdStatus.ActiveSheet.Rows[i].Tag) != "")
                        {
                            break;
                        }
                    }
                    if (i >= spdStatus.ActiveSheet.RowCount && ls_deleted_status.Count < 1)
                    {
                        return false;
                    }
                    break;
                case MPGC.MP_STEP_DELETE:
                    break;
            }

            return true;
        }

        private bool ViewTableList(ListView listView)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            //Modify by J.S. 2012.02.07 recyclebin에 있는 항목 제거
            in_node.AddString("SQL", "SELECT TNAME FROM TAB WHERE TNAME NOT IN (SELECT OBJECT_NAME FROM RECYCLEBIN) ORDER BY TNAME");
            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(listView, out_node);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private bool ViewTableColumnList(ListView listView, string tableName)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = '" + tableName + "' " +
                                     "       ORDER BY COLUMN_NAME");
            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(listView, out_node);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private void ChangeSQLSyntaxColor()
        {
            int i_start = 0;
            int i_len = 0;

            if (MPCF.Trim(txtWhere3.Text) == "")
            {
                return;
            }

            if (txtWhere3.Text[txtWhere3.Text.Length - 1] != ' ')
            {
                txtWhere3.Text += " ";
            }

            txtWhere3.SelectionStart = 0;
            txtWhere3.SelectionLength = txtWhere3.Text.Length;
            txtWhere3.SelectionColor = System.Drawing.SystemColors.ControlText;

            while (i_len < txtWhere3.Text.Length)
            {
                if (txtWhere3.Text[i_len] == ' ' || i_len == txtWhere3.Text.Length - 1)
                {
                    if (MPCF.IsSQLSyntax(MPCF.ToUpper(txtWhere3.Text.Substring(i_start, i_len - i_start))) == true ||
                        txtWhere3.Text.Substring(i_start, i_len - i_start).IndexOf("$") > 0)
                    {
                        txtWhere3.SelectionStart = i_start;
                        txtWhere3.SelectionLength = i_len - i_start;
                        txtWhere3.SelectionColor = System.Drawing.Color.Blue;
                        txtWhere3.SelectionStart = i_len;
                        txtWhere3.SelectionLength = 0;
                        txtWhere3.SelectionColor = System.Drawing.SystemColors.ControlText;
                    }

                    i_start = i_len;
                }

                i_len++;
            }
        }

        // ViewWorkProcessType()
        //       -  View work process type
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool ViewWorkProcessType()
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_TYPE_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_TYPE_OUT");
            List<TRSNode> lis_status_list;
            int i;
            int i_row;
            string s_status_type;
            string s_format;

            MPCF.ClearList(spdStatus);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(txtProcType.Text));

            if (MPCR.CallService("WEM", "WEM_View_Work_Process_Type", in_node, ref out_node) == false)
            {
                return false;
            }

            txtDesc.Text = MPCF.Trim(out_node.GetString("WORK_PROC_TYPE_DESC"));

            lis_status_list = out_node.GetList("STATUS_LIST");
            for(i = 0; i < lis_status_list.Count; i++)
            {
                i_row = spdStatus.ActiveSheet.RowCount;
                spdStatus.ActiveSheet.RowCount++;

                s_status_type = "";
                switch(lis_status_list[i].GetChar("STATUS_TYPE"))
                {
                    case 'U':
                        s_status_type = MPCF.FindLanguage("User Define", CAPTION_TYPE.LABEL);
                        break;
                    case 'A':
                        s_status_type = MPCF.FindLanguage("Attribute", CAPTION_TYPE.LABEL);
                        break;
                    case 'T':
                        s_status_type = MPCF.FindLanguage("Table-Column", CAPTION_TYPE.LABEL);
                        break;
                    case 'I':
                        s_status_type = MPCF.FindLanguage("Image", CAPTION_TYPE.LABEL);
                        break;
                    case 'F':
                        s_status_type = MPCF.FindLanguage("File", CAPTION_TYPE.LABEL);
                        break;
                }

                s_format = "";
                switch (lis_status_list[i].GetChar("ST_FORMAT"))
                {
                    case 'A':
                        s_format = "A : Ascii";
                        break;
                    case 'N':
                        s_format = "N : Number";
                        break;
                    case 'F':
                        s_format = "F : Float";
                        break;
                    case 'D':
                        s_format = "D : Date";
                        break;
                    case 'T':
                        s_format = "T : Time";
                        break;
                    case 'M':
                        s_format = "M : DateTime";
                        break;
                    case 'C':
                        s_format = "C : CheckBox";
                        break;
                    case '1':
                        s_format = "1 : Current Date";
                        break;
                    case '2':
                        s_format = "2 : Current Time";
                        break;
                    case '3':
                        s_format = "3 : Current DateTime";
                        break;
                    case '4':
                        s_format = "4 : Current Shift";
                        break;
                    case '5':
                        s_format = "5 : Login User ID";
                        break;
                    case '6':
                        s_format = "6 : Login User Desc";
                        break;
                    case '7':
                        s_format = "7 : Login Factory";
                        break;
                }

                spdStatus.ActiveSheet.Cells[i_row, 0].Value = s_status_type;
                spdStatus.ActiveSheet.Cells[i_row, 0].Tag = lis_status_list[i].GetChar("STATUS_TYPE");
                spdStatus.ActiveSheet.Cells[i_row, 1].Value = lis_status_list[i].GetString("STATUS");
                spdStatus.ActiveSheet.Cells[i_row, 2].Value = lis_status_list[i].GetString("STATUS_DESC");
                spdStatus.ActiveSheet.Cells[i_row, 3].Value = s_format;
                spdStatus.ActiveSheet.Cells[i_row, 4].Value = lis_status_list[i].GetInt("ST_SIZE");
                spdStatus.ActiveSheet.Cells[i_row, 5].Value = lis_status_list[i].GetString("DATA_1");
                spdStatus.ActiveSheet.Cells[i_row, 6].Value = lis_status_list[i].GetString("DATA_2");
                spdStatus.ActiveSheet.Cells[i_row, 7].Value = lis_status_list[i].GetString("DATA_3");
            }
            ls_deleted_status.Clear();

            return true;
        }

        // UpdateWorkProcessType()
        //       -   Create and Update and Delete work process type
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - char c_proc_step : MP_STEP_CREATE/UPDATE/DELETE
        //
        private bool UpdateWorkProcessType(char c_proc_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_WORK_PROC_TYPE_IN");
            TRSNode out_node = new TRSNode("UPDATE_WORK_PROC_TYPE_OUT");
            ListViewItem itm;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;
                in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(txtProcType.Text));
                in_node.AddString("WORK_PROC_TYPE_DESC", MPCF.Trim(txtDesc.Text));

                if (MPCR.CallService("WEM", "WEM_Update_Work_Process_Type", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (c_proc_step != MPGC.MP_STEP_DELETE)
                {
                    if (UpdateWorkProcessStatus(c_proc_step) == false) return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_proc_step == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisProcType.Items.Add(txtProcType.Text, (int)SMALLICON_INDEX.IDX_VERSION_REQUEST);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisProcType.Sorting = SortOrder.Ascending;
                        lisProcType.Sort();
                        itm.EnsureVisible();
                    }
                    else if (c_proc_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisProcType, MPCF.Trim(txtProcType.Text), false) == true)
                        {
                            lisProcType.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (c_proc_step == MPGC.MP_STEP_DELETE)
                    {
                        i = MPCF.FindListItemIndex(lisProcType, MPCF.Trim(txtProcType.Text), false);
                        if (i != -1)
                        {
                            lisProcType.Items[i].Remove();
                        }
                    }
                    lblDataCount.Text = lisProcType.Items.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        // UpdateWorkProcessStatus()
        //       -   Create and Update and Delete work process status
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - char c_proc_step : MP_STEP_CREATE/UPDATE/DELETE
        //
        private bool UpdateWorkProcessStatus(char c_proc_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_WORK_PROC_STATUS_IN");
            TRSNode out_node = new TRSNode("UPDATE_WORK_PROC_STATUS_OUT");
            int i;

            try
            {
                for (i = 0; i < ls_deleted_status.Count; i++)
                {
                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = MPGC.MP_STEP_DELETE;
                    in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(txtProcType.Text));
                    in_node.AddString("STATUS", MPCF.Trim(ls_deleted_status[i]));

                    if (MPCR.CallService("WEM", "WEM_Update_Work_Status_Definition", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    in_node.Init();
                }
                ls_deleted_status.Clear();

                for (i = 0; i < spdStatus.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdStatus.ActiveSheet.Rows[i].Tag) != "")
                    {
                        MPCR.SetInMsg(in_node);
                        in_node.ProcStep = c_proc_step;
                        in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(txtProcType.Text));

                        in_node.AddChar("STATUS_TYPE", MPCF.ToChar(spdStatus.ActiveSheet.Cells[i, 0].Tag));
                        in_node.AddString("STATUS", MPCF.Trim(spdStatus.ActiveSheet.Cells[i, 1].Value));
                        in_node.AddString("STATUS_DESC", MPCF.Trim(spdStatus.ActiveSheet.Cells[i, 2].Value));
                        in_node.AddChar("ST_FORMAT", MPCF.ToChar(spdStatus.ActiveSheet.Cells[i, 3].Value));
                        in_node.AddInt("ST_SIZE", MPCF.ToInt(spdStatus.ActiveSheet.Cells[i, 4].Value));
                        in_node.AddString("DATA_1", MPCF.Trim(spdStatus.ActiveSheet.Cells[i, 5].Value));
                        in_node.AddString("DATA_2", MPCF.Trim(spdStatus.ActiveSheet.Cells[i, 6].Value));
                        in_node.AddString("DATA_3", MPCF.Trim(spdStatus.ActiveSheet.Cells[i, 7].Value));

                        if (spdStatus.ActiveSheet.Cells[i, 5].Tag != null)
                        {
                            byte[] file_buffer;

                            file_buffer = null;
                            file_buffer = (byte[])spdStatus.ActiveSheet.Cells[i, 5].Tag;

                            in_node.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);
                        }

                        if (MPCR.CallService("WEM", "WEM_Update_Work_Status_Definition", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        in_node.Init();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private object GetAttachedFile(string s_proc_type, string s_status)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_STS_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_STS_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", s_proc_type);
            in_node.AddString("STATUS", s_status);

            if (MPCR.CallService("WEM", "WEM_View_Work_Status_Definition", in_node, ref out_node) == false)
            {
                return null;
            }

            return out_node.GetBlob(MPGC.MP_BIN_DATA_1);
        }

        private void SetSelectedStatus(int i_row)
        {
            char c_status_type;
            string s_status;
            string s_status_desc;
            string s_format;
            int i_size;
            string s_data_1;
            string s_data_2;
            string s_data_3;
            object o_file_buffer;
            MemoryStream ms_buffer;

            c_status_type = MPCF.ToChar(spdStatus.ActiveSheet.Cells[i_row, 0].Tag);
            s_status = MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 1].Value);
            s_status_desc = MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 2].Value);
            s_format = MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 3].Value);
            i_size = MPCF.ToInt(spdStatus.ActiveSheet.Cells[i_row, 4].Value);
            s_data_1 = MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 5].Value);
            o_file_buffer = spdStatus.ActiveSheet.Cells[i_row, 5].Tag;
            s_data_2 = MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 6].Value);
            s_data_3 = MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 7].Value);

            if ((c_status_type == 'I' || c_status_type == 'F') && s_data_2 != "Y")
            {
                if (s_data_1 != "" && o_file_buffer == null)
                {
                    o_file_buffer = GetAttachedFile(txtProcType.Text, s_status);
                    spdStatus.ActiveSheet.Cells[i_row, 5].Tag = o_file_buffer;
                }
            }

            switch (c_status_type)
            {
                case 'U':
                    rbtUserDefine.Checked = true;
                    txtStatus1.Text = s_status;
                    txtStatusDesc1.Text = s_status_desc;
                    cboFormat1.Text = s_format;
                    txtSize1.Value = i_size;
                    cdvTableName1.Text = s_data_1;

                    if (s_data_2 == "Y")
                    {
                        chkMultiLine1.Checked = true;
                    }
                    else
                    {
                        chkMultiLine1.Checked = false;
                    }
                    if (s_data_3 == "Y")
                    {
                        chkDisplayDesc1.Checked = true;
                    }
                    else
                    {
                        chkDisplayDesc1.Checked = false;
                    }
                    break;
                case 'A':
                    rbtAttribute.Checked = true;
                    txtStatus2.Text = s_status;
                    txtStatusDesc2.Text = s_status_desc;
                    cdvAttrType2.Text = s_data_1;
                    cdvAttrName2.Text = s_data_2;
                    break;
                case 'T':
                    rbtTableColumn.Checked = true;
                    txtStatus3.Text = s_status;
                    txtStatusDesc3.Text = s_status_desc;
                    cdvTableName3.Text = s_data_1;
                    cdvColName3.Text = s_data_2;
                    txtWhere3.Text = s_data_3;
                    break;
                case 'I':
                    rbtImage.Checked = true;
                    txtStatus4.Text = s_status;
                    txtStatusDesc4.Text = s_status_desc;
                    txtFileName4.Text = s_data_1;
                    txtFileName4.Tag = o_file_buffer;

                    if (s_data_1 != "" && o_file_buffer != null)
                    {
                        byte[] buffer = (byte[])o_file_buffer;
                        chkNotAttachFile4.Checked = false;

                        try
                        {
                            ms_buffer = new MemoryStream();
                            ms_buffer.Write(buffer, 0, buffer.Length);
                            ms_buffer.Position = 0;

                            picImage4.Image = Image.FromStream(ms_buffer);
                        }
                        catch (Exception ex)
                        {
                            MPCF.ShowMsgBox(ex.Message);
                        }
                    }
                    else
                    {
                        chkNotAttachFile4.Checked = true;
                    }
                    break;
                case 'F':
                    rbtFile.Checked = true;
                    txtStatus5.Text = s_status;
                    txtStatusDesc5.Text = s_status_desc;
                    cdvFileName5.Text = s_data_1;
                    cdvFileName5.Tag = o_file_buffer;
                    if (s_data_1 != "" && o_file_buffer != null)
                    {
                        chkNotAttachFile5.Checked = false;
                    }
                    else
                    {
                        chkNotAttachFile5.Checked = true;
                    }
                    break;
            }
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.lisProcType;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWEMSetupWorkProcessType_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.InitListView(lisProcType);
                MPCF.ClearList(spdStatus);

                ls_deleted_status = new List<string>();
                rbtUserDefine.Checked = true;

                btnRefresh.PerformClick();

                b_load_flag = true;
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisProcType, this.Text, "");
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                if (WEMLIST.ViewWorkProcessTypeList(lisProcType) == false)
                {
                    return;
                }
                lblDataCount.Text = lisProcType.Items.Count.ToString();
                if (lisProcType.Items.Count > 0)
                {
                    MPCF.FindListItem(lisProcType, txtProcType.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisProcType, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisProcType, txtFind.Text, 0, true, false);
        }

        private void rbtStatusType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtUserDefine.Checked == true)
            {
                grpStatusUserDefine.Dock = DockStyle.Fill;
                grpStatusUserDefine.Visible = true;
                grpStatusAttribute.Dock = DockStyle.None;
                grpStatusAttribute.Visible = false;
                grpStatusTableColumn.Dock = DockStyle.None;
                grpStatusTableColumn.Visible = false;
                grpStatusImage.Dock = DockStyle.None;
                grpStatusImage.Visible = false;
                grpStatusFile.Dock = DockStyle.None;
                grpStatusFile.Visible = false;

                txtStatus1.Text = "";
                txtStatusDesc1.Text = "";
                cboFormat1.SelectedIndex = 0;
                txtSize1.Value = 0;
                cdvTableName1.Text = "";
            }
            else if (rbtAttribute.Checked == true)
            {
                grpStatusUserDefine.Dock = DockStyle.None;
                grpStatusUserDefine.Visible = false;
                grpStatusAttribute.Dock = DockStyle.Fill;
                grpStatusAttribute.Visible = true;
                grpStatusTableColumn.Dock = DockStyle.None;
                grpStatusTableColumn.Visible = false;
                grpStatusImage.Dock = DockStyle.None;
                grpStatusImage.Visible = false;
                grpStatusFile.Dock = DockStyle.None;
                grpStatusFile.Visible = false;

                txtStatus2.Text = "";
                txtStatusDesc2.Text = "";
                cdvAttrType2.Text = "";
                cdvAttrName2.Text = "";
            }
            else if (rbtTableColumn.Checked == true)
            {
                grpStatusUserDefine.Dock = DockStyle.None;
                grpStatusUserDefine.Visible = false;
                grpStatusAttribute.Dock = DockStyle.None;
                grpStatusAttribute.Visible = false;
                grpStatusTableColumn.Dock = DockStyle.Fill;
                grpStatusTableColumn.Visible = true;
                grpStatusImage.Dock = DockStyle.None;
                grpStatusImage.Visible = false;
                grpStatusFile.Dock = DockStyle.None;
                grpStatusFile.Visible = false;

                txtStatus3.Text = "";
                txtStatusDesc3.Text = "";
                cdvTableName3.Text = "";
                cdvColName3.Text = "";
                txtWhere3.Text = "";
            }
            else if (rbtImage.Checked == true)
            {
                grpStatusUserDefine.Dock = DockStyle.None;
                grpStatusUserDefine.Visible = false;
                grpStatusAttribute.Dock = DockStyle.None;
                grpStatusAttribute.Visible = false;
                grpStatusTableColumn.Dock = DockStyle.None;
                grpStatusTableColumn.Visible = false;
                grpStatusImage.Dock = DockStyle.Fill;
                grpStatusImage.Visible = true;
                grpStatusFile.Dock = DockStyle.None;
                grpStatusFile.Visible = false;

                txtStatus4.Text = "";
                txtStatusDesc4.Text = "";
                txtFileName4.Text = "";
                txtFileName4.Tag = null;
                picImage4.Image = null;
            }
            else if (rbtFile.Checked == true)
            {
                grpStatusUserDefine.Dock = DockStyle.None;
                grpStatusUserDefine.Visible = false;
                grpStatusAttribute.Dock = DockStyle.None;
                grpStatusAttribute.Visible = false;
                grpStatusTableColumn.Dock = DockStyle.None;
                grpStatusTableColumn.Visible = false;
                grpStatusImage.Dock = DockStyle.None;
                grpStatusImage.Visible = false;
                grpStatusFile.Dock = DockStyle.Fill;
                grpStatusFile.Visible = true;

                txtStatus5.Text = "";
                txtStatusDesc5.Text = "";
                cdvFileName5.Text = "";
                cdvFileName5.Tag = null;
            }
        }

        private void cdvTableName1_ButtonPress(object sender, EventArgs e)
        {
            cdvTableName1.Init();
            MPCF.InitListView(cdvTableName1.GetListView);
            cdvTableName1.Columns.Add("Table", 150, HorizontalAlignment.Left);
            cdvTableName1.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTableName1.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvTableName1.GetListView, '1');
            cdvTableName1.InsertEmptyRow(0, 1);
        }

        private void cdvAttrType2_ButtonPress(object sender, EventArgs e)
        {
            cdvAttrType2.Init();
            MPCF.InitListView(cdvAttrType2.GetListView);
            cdvAttrType2.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvAttrType2.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrType2.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAttrType2.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);
        }

        private void cdvAttrType2_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvAttrType2.Text) != "")
            {
                cdvAttrName2.Text = "";
            }
        }

        private void cdvAttrName2_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType2, 1) == false) return;

            cdvAttrName2.Init();
            MPCF.InitListView(cdvAttrName2.GetListView);
            cdvAttrName2.Columns.Add("Attribute Seq", 150, HorizontalAlignment.Left);
            cdvAttrName2.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrName2.Columns.Add("Attribute Desc", 200, HorizontalAlignment.Left);
            cdvAttrName2.SelectedSubItemIndex = 1;

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", cdvAttrType2.Text);

            try
            {
                do
                {
                    if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("ATTR_SEQ").ToString(), (int)SMALLICON_INDEX.IDX_KEY);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("ATTR_NAME")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("ATTR_DESC")));
                        cdvAttrName2.Items.Add(itmX);
                    }

                    in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                    in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

                } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvTableName3_ButtonPress(object sender, EventArgs e)
        {
            cdvTableName3.Init();
            MPCF.InitListView(cdvTableName3.GetListView);
            cdvTableName3.Columns.Add("Table", 150, HorizontalAlignment.Left);
            cdvTableName3.SelectedSubItemIndex = 0;
            ViewTableList(cdvTableName3.GetListView);
        }

        private void cdvTableName3_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvTableName3.Text) != "")
            {
                cdvColName3.Text = "";
                txtWhere3.Text = "";
            }
        }

        private void cdvColName3_ButtonPress(object sender, EventArgs e)
        {
            cdvColName3.Init();
            MPCF.InitListView(cdvColName3.GetListView);
            cdvColName3.Columns.Add("Column", 150, HorizontalAlignment.Left);
            cdvColName3.SelectedSubItemIndex = 0;
            ViewTableColumnList(cdvColName3.GetListView, cdvTableName3.Text);
        }

        private void cdvColName3_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvColName3.Text) != "")
            {
                txtWhere3.Text = "";
            }
        }

        private void txtWhere3_Leave(object sender, EventArgs e)
        {
            ChangeSQLSyntaxColor();
        }

        private void btnFileOpen4_Click(object sender, EventArgs e)
        {
            FileInfo finfo;
            BinaryReader br;
            byte[] file_buffer;

            try
            {
                ofdFile.Filter = "All File(*.*)|*.*";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    finfo = new FileInfo(ofdFile.FileName);
                    if (finfo.Exists == true)
                    {
                        picImage4.Image = Image.FromFile(ofdFile.FileName);

                        br = new BinaryReader(finfo.OpenRead());
                        file_buffer = br.ReadBytes((int)finfo.Length);
                        txtFileName4.Tag = file_buffer;
                        br.Close();

                        txtFileName4.Text = finfo.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvFileName5_ButtonPress(object sender, EventArgs e)
        {
            FileInfo finfo;
            BinaryReader br;
            byte[] file_buffer;

            try
            {
                ofdFile.Filter = "All File(*.*)|*.*";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    finfo = new FileInfo(ofdFile.FileName);
                    if (finfo.Exists == true)
                    {
                        br = new BinaryReader(finfo.OpenRead());
                        file_buffer = br.ReadBytes((int)finfo.Length);
                        cdvFileName5.Tag = file_buffer;
                        br.Close();

                        cdvFileName5.Text = finfo.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i_row;
            char c_status_type;
            string s_status_type;
            string s_status;
            string s_status_desc;
            string s_format;
            int i_size;
            string s_data_1;
            string s_data_2;
            string s_data_3;
            object o_file_buffer;

            c_status_type = ' ';
            s_status_type = "";
            s_status = "";
            s_status_desc = "";
            s_format = "";
            i_size = 0;
            s_data_1 = "";
            s_data_2 = "";
            s_data_3 = "";
            o_file_buffer = null;

            if (rbtUserDefine.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus1, 1) == false) return;
                if (MPCF.CheckValue(cboFormat1, 1) == false) return;
                if (txtSize1.Value < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtSize1.Focus();
                    return;
                }

                s_status_type = MPCF.FindLanguage("User Define", CAPTION_TYPE.LABEL);
                c_status_type = 'U';

                s_status = txtStatus1.Text;
                s_status_desc = txtStatusDesc1.Text;

                s_format = cboFormat1.Text;
                i_size = MPCF.ToInt(txtSize1.Value);
                s_data_1 = cdvTableName1.Text;

                if (chkMultiLine1.Checked == true)
                {
                    s_data_2 = "Y";
                }
                if (chkDisplayDesc1.Checked == true)
                {
                    s_data_3 = "Y";
                }
            }
            else if (rbtAttribute.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus2, 1) == false) return;
                if (MPCF.CheckValue(cdvAttrType2, 1) == false) return;
                if (MPCF.CheckValue(cdvAttrName2, 1) == false) return;

                s_status_type = MPCF.FindLanguage("Attribute", CAPTION_TYPE.LABEL);
                c_status_type = 'A';

                s_status = txtStatus2.Text;
                s_status_desc = txtStatusDesc2.Text;

                s_data_1 = cdvAttrType2.Text;
                s_data_2 = cdvAttrName2.Text;
            }
            else if (rbtTableColumn.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus3, 1) == false) return;
                if (MPCF.CheckValue(cdvTableName3, 1) == false) return;
                if (MPCF.CheckValue(cdvColName3, 1) == false) return;

                s_status_type = MPCF.FindLanguage("Table-Column", CAPTION_TYPE.LABEL);
                c_status_type = 'T';

                s_status = txtStatus3.Text;
                s_status_desc = txtStatusDesc3.Text;

                s_data_1 = cdvTableName3.Text;
                s_data_2 = cdvColName3.Text;
                s_data_3 = txtWhere3.Text;
            }
            else if (rbtImage.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus4, 1) == false) return;
                if (chkNotAttachFile4.Checked == false && MPCF.CheckValue(txtFileName4, 1) == false) return;

                s_status_type = MPCF.FindLanguage("Image", CAPTION_TYPE.LABEL);
                c_status_type = 'I';

                s_status = txtStatus4.Text;
                s_status_desc = txtStatusDesc4.Text;

                s_data_1 = txtFileName4.Text;
                o_file_buffer = txtFileName4.Tag;

                if (chkNotAttachFile4.Checked == true)
                {
                    s_data_2 = "Y";
                }
            }
            else if (rbtFile.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus5, 1) == false) return;
                if (chkNotAttachFile5.Checked == false && MPCF.CheckValue(cdvFileName5, 1) == false) return;

                s_status_type = MPCF.FindLanguage("File", CAPTION_TYPE.LABEL);
                c_status_type = 'F';

                s_status = txtStatus5.Text;
                s_status_desc = txtStatusDesc5.Text;

                s_data_1 = cdvFileName5.Text;
                o_file_buffer = cdvFileName5.Tag;

                if (chkNotAttachFile5.Checked == true)
                {
                    s_data_2 = "Y";
                }
            }

            for (i_row = 0; i_row < spdStatus.ActiveSheet.RowCount; i_row++)
            {
                if (MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 1].Value).CompareTo(s_status) == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(111));
                    return;
                }
            }

            i_row = spdStatus.ActiveSheet.RowCount;
            spdStatus.ActiveSheet.RowCount++;

            spdStatus.ActiveSheet.Cells[i_row, 0].Value = s_status_type;
            spdStatus.ActiveSheet.Cells[i_row, 0].Tag = c_status_type;
            spdStatus.ActiveSheet.Cells[i_row, 1].Value = s_status;
            spdStatus.ActiveSheet.Cells[i_row, 2].Value = s_status_desc;
            spdStatus.ActiveSheet.Cells[i_row, 3].Value = s_format;
            spdStatus.ActiveSheet.Cells[i_row, 4].Value = i_size;
            spdStatus.ActiveSheet.Cells[i_row, 5].Value = s_data_1;
            spdStatus.ActiveSheet.Cells[i_row, 5].Tag = o_file_buffer;
            spdStatus.ActiveSheet.Cells[i_row, 6].Value = s_data_2;
            spdStatus.ActiveSheet.Cells[i_row, 7].Value = s_data_3;

            spdStatus.ActiveSheet.Rows[i_row].Tag = 'A';
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i_row = spdStatus.ActiveSheet.ActiveRowIndex;
            if (i_row < 0) return;

            if (MPCF.Trim(spdStatus.ActiveSheet.Rows[i_row].Tag) != "A")
            {
                string s_status;
                s_status = MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 1].Value);
                ls_deleted_status.Add(s_status);
            }
            spdStatus.ActiveSheet.Rows[i_row].Remove();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int i_row;
            char c_status_type;
            string s_status_type;
            string s_status;
            string s_status_desc;
            string s_format;
            int i_size;
            string s_data_1;
            string s_data_2;
            string s_data_3;
            object o_file_buffer;

            if (spdStatus.ActiveSheet.ActiveRowIndex < 0) return;

            c_status_type = ' ';
            s_status_type = "";
            s_status = "";
            s_status_desc = "";
            s_format = "";
            i_size = 0;
            s_data_1 = "";
            s_data_2 = "";
            s_data_3 = "";
            o_file_buffer = null;

            if (rbtUserDefine.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus1, 1) == false) return;
                if (MPCF.CheckValue(cboFormat1, 1) == false) return;
                if (txtSize1.Value < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtSize1.Focus();
                    return;
                }

                s_status_type = MPCF.FindLanguage("User Define", CAPTION_TYPE.LABEL);
                c_status_type = 'U';

                s_status = txtStatus1.Text;
                s_status_desc = txtStatusDesc1.Text;

                s_format = cboFormat1.Text;
                i_size = MPCF.ToInt(txtSize1.Value);
                s_data_1 = cdvTableName1.Text;

                if (chkMultiLine1.Checked == true)
                {
                    s_data_2 = "Y";
                }
                if (chkDisplayDesc1.Checked == true)
                {
                    s_data_3 = "Y";
                }
            }
            else if (rbtAttribute.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus2, 1) == false) return;
                if (MPCF.CheckValue(cdvAttrType2, 1) == false) return;
                if (MPCF.CheckValue(cdvAttrName2, 1) == false) return;

                s_status_type = MPCF.FindLanguage("Attribute", CAPTION_TYPE.LABEL);
                c_status_type = 'A';

                s_status = txtStatus2.Text;
                s_status_desc = txtStatusDesc2.Text;

                s_data_1 = cdvAttrType2.Text;
                s_data_2 = cdvAttrName2.Text;
            }
            else if (rbtTableColumn.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus3, 1) == false) return;
                if (MPCF.CheckValue(cdvTableName3, 1) == false) return;
                if (MPCF.CheckValue(cdvColName3, 1) == false) return;

                s_status_type = MPCF.FindLanguage("Table-Column", CAPTION_TYPE.LABEL);
                c_status_type = 'T';

                s_status = txtStatus3.Text;
                s_status_desc = txtStatusDesc3.Text;

                s_data_1 = cdvTableName3.Text;
                s_data_2 = cdvColName3.Text;
                s_data_3 = txtWhere3.Text;
            }
            else if (rbtImage.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus4, 1) == false) return;
                if (chkNotAttachFile4.Checked == false && MPCF.CheckValue(txtFileName4, 1) == false) return;

                s_status_type = MPCF.FindLanguage("Image", CAPTION_TYPE.LABEL);
                c_status_type = 'I';

                s_status = txtStatus4.Text;
                s_status_desc = txtStatusDesc4.Text;

                s_data_1 = txtFileName4.Text;
                o_file_buffer = txtFileName4.Tag;

                if (chkNotAttachFile4.Checked == true)
                {
                    s_data_2 = "Y";
                }
            }
            else if (rbtFile.Checked == true)
            {
                if (MPCF.CheckValue(txtStatus5, 1) == false) return;
                if (chkNotAttachFile5.Checked == false && MPCF.CheckValue(cdvFileName5, 1) == false) return;

                s_status_type = MPCF.FindLanguage("File", CAPTION_TYPE.LABEL);
                c_status_type = 'F';

                s_status = txtStatus5.Text;
                s_status_desc = txtStatusDesc5.Text;

                s_data_1 = cdvFileName5.Text;
                o_file_buffer = cdvFileName5.Tag;

                if (chkNotAttachFile5.Checked == true)
                {
                    s_data_2 = "Y";
                }
            }

            for (i_row = 0; i_row < spdStatus.ActiveSheet.RowCount; i_row++)
            {
                if (i_row != spdStatus.ActiveSheet.ActiveRowIndex)
                {
                    if (MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 1].Value).CompareTo(s_status) == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(111));
                        return;
                    }
                }
            }

            i_row = spdStatus.ActiveSheet.ActiveRowIndex;

            spdStatus.ActiveSheet.Cells[i_row, 0].Value = s_status_type;
            spdStatus.ActiveSheet.Cells[i_row, 0].Tag = c_status_type;
            spdStatus.ActiveSheet.Cells[i_row, 1].Value = s_status;
            spdStatus.ActiveSheet.Cells[i_row, 2].Value = s_status_desc;
            spdStatus.ActiveSheet.Cells[i_row, 3].Value = s_format;
            spdStatus.ActiveSheet.Cells[i_row, 4].Value = i_size;
            spdStatus.ActiveSheet.Cells[i_row, 5].Value = s_data_1;
            spdStatus.ActiveSheet.Cells[i_row, 5].Tag = o_file_buffer;
            spdStatus.ActiveSheet.Cells[i_row, 6].Value = s_data_2;
            spdStatus.ActiveSheet.Cells[i_row, 7].Value = s_data_3;

            if (MPCF.Trim(spdStatus.ActiveSheet.Rows[i_row].Tag) == "")
            {
                spdStatus.ActiveSheet.Rows[i_row].Tag = 'C';
            }
        }

        private void spdStatus_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            SetSelectedStatus(e.Row);
        }

        private void cboFormat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormat1.SelectedIndex == 7)
            {
                cboFormat1.SelectedIndex = 0;
            }

            txtSize1.Value = 0;
            txtSize1.Enabled = true;
            cdvTableName1.Text = "";
            cdvTableName1.Enabled = true;

            chkMultiLine1.Checked = false;
            chkMultiLine1.Enabled = false;
            chkDisplayDesc1.Checked = false;
            chkDisplayDesc1.Enabled = false;

            switch (cboFormat1.SelectedIndex)
            {
                case 0: // Ascii
                    chkMultiLine1.Enabled = true;
                    break;
                case 3: // Date
                    txtSize1.Value = 8;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
                case 4: // Time
                    txtSize1.Value = 6;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
                case 5: // Datetime
                    txtSize1.Value = 14;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
                case 6: // CheckBox
                    txtSize1.Value = 1;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    chkDisplayDesc1.Enabled = true;
                    break;
                case 8: // Current Date
                    txtSize1.Value = 8;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
                case 9: // Current Time
                    txtSize1.Value = 6;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
                case 10: // Current DateTime
                    txtSize1.Value = 14;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
                case 11: // Current Shift
                    txtSize1.Value = 1;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
                case 12: // Login User ID
                    txtSize1.Value = 20;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
                case 13: // Login User Desc
                    txtSize1.Value = 200;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
                case 14: // Login Factory
                    txtSize1.Value = 10;
                    txtSize1.Enabled = false;
                    cdvTableName1.Enabled = false;
                    break;
            }
        }

        private void lisProcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisProcType.SelectedItems.Count < 1) return;
            txtProcType.Text = lisProcType.SelectedItems[0].Text;

            if (ViewWorkProcessType() == false) return;
            if (spdStatus.ActiveSheet.RowCount > 0)
            {
                SetSelectedStatus(0);
            }
        }

        private void chkNotAttachFile4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotAttachFile4.Checked == true)
            {
                txtFileName4.Text = "";
                txtFileName4.Tag = null;
                txtFileName4.ReadOnly = true;
                btnFileOpen4.Enabled = false;
                picImage4.Image = null;
            }
            else
            {
                txtFileName4.ReadOnly = false;
                btnFileOpen4.Enabled = true;
            }
        }

        private void chkNotAttachFile5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotAttachFile5.Checked == true)
            {
                cdvFileName5.Text = "";
                cdvFileName5.Tag = null;
                cdvFileName5.ReadOnly = true;
                cdvFileName5.BackColor = SystemColors.Control;
            }
            else
            {
                cdvFileName5.ReadOnly = false;
                cdvFileName5.BackColor = SystemColors.Window;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;
            if (UpdateWorkProcessType(MPGC.MP_STEP_CREATE) == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;
            if (UpdateWorkProcessType(MPGC.MP_STEP_UPDATE) == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;
            if (UpdateWorkProcessType(MPGC.MP_STEP_DELETE) == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }

            MPCF.FieldClear(pnlRight);
            MPCF.ClearList(spdStatus);
            rbtUserDefine.Checked = true;
        }

        private void btnViewFile5_Click(object sender, EventArgs e)
        {
            if (cdvFileName5.Tag != null)
            {
                byte[] bt_buffer;
                string s_file_name;
                try
                {
                    s_file_name = Environment.GetEnvironmentVariable("TEMP") + "\\" + cdvFileName5.Text;
                    bt_buffer = (byte[])cdvFileName5.Tag;

                    FileStream fs = File.Open(s_file_name, FileMode.Create);
                    BinaryWriter writer = new BinaryWriter(fs);
                    writer.Write(bt_buffer, 0, bt_buffer.Length);
                    writer.Close();

                    Process process = new Process();
                    process.StartInfo.FileName = s_file_name;
                    process.Start();
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
            }
        }

        private void txtProcType_KeyPress(object sender, KeyPressEventArgs e)
        {
            MPCF.FieldClear(pnlStatus);
            MPCF.ClearList(spdStatus);
            rbtUserDefine.Checked = true;
            ls_deleted_status.Clear();
        }




    }
}
