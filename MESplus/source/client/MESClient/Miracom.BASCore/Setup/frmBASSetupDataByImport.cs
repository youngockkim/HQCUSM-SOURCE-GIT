//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupDataByImport.cs
//   Description : Modeling Data Import function
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - CheckCondition()        : Check the conditions before transaction
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-04-21 : Created by jylee
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
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;

namespace Miracom.BASCore
{
    public partial class frmBASSetupDataByImport : Miracom.MESCore.TranForm02
    {
        public frmBASSetupDataByImport()
        {
            InitializeComponent();
        }

        #region " Constant Definition"

        private const int ROW_DATA_TYPE = 2;
        private const int ROW_MEMBER_NAME = 3;
        private const int ROW_DATA_START = 4;

        #endregion

        #region " Variable Definition "
            public bool b_chk_cancel = false;
        #endregion

        #region " Function Definition "

        private void OpenExcelFile(string filename)
        {
            int i;
            int i_cnt_col;
            int i_cnt_row;

            //Open
            try
            {
                if (spdModel.OpenExcel(filename) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(332));
                    return;
                }

                spdModel.Skin = DefaultSpreadSkins.Classic;
                spdModel.VisualStyles = FarPoint.Win.VisualStyles.Auto;
                spdModel.ScrollBarTrackPolicy = ScrollBarTrackPolicy.Both;
                spdModel.ScrollTipPolicy = ScrollTipPolicy.Both;
                spdModel.TextTipPolicy = TextTipPolicy.Floating;

                for (i = 0; i < spdModel.Sheets.Count; i++)
                {
                    i_cnt_col = 1;
                    //컬럼 갯수 확인
                    if (MPCF.Trim(spdModel.Sheets[i].Cells[ROW_MEMBER_NAME, 1].Value) != "")
                    {
                        while (MPCF.Trim(spdModel.Sheets[i].Cells[ROW_MEMBER_NAME, i_cnt_col].Value) != "")
                        {
                            i_cnt_col++;
                        }
                    }

                    i_cnt_row = 4;
                    //데이터 갯수 확인
                    if (MPCF.Trim(spdModel.Sheets[i].Cells[ROW_DATA_START, 1].Value) != "")
                    {
                        while (MPCF.Trim(spdModel.Sheets[i].Cells[i_cnt_row, 1].Value) != "")
                        {
                            i_cnt_row++;
                        }
                    }

                    //Column, Row 갯수에 따라 스프레드 정리
                    spdModel.Sheets[i].ColumnCount = i_cnt_col;
                    spdModel.Sheets[i].RowCount = i_cnt_row;

                    //필수 컬럼 색상 정리(상단에는 황색 표시하지 않음)
                    spdModel.Sheets[i].Cells[0, 0, 1, i_cnt_col - 1].BackColor = Color.White;

                    if (spdModel.Sheets[i].RowCount > ROW_DATA_START)
                    {
                        spdModel.Sheets[i].Columns[0].CellType = new CheckBoxCellType();
                        spdModel.Sheets[i].Cells[ROW_DATA_START, 0, i_cnt_row - 1, 0].Value = true;
                        spdModel.Sheets[i].Cells[1, 0, 2, 0].CellType = new TextCellType();
                    }
                }
                spdModel.ActiveSheetIndex = 0;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void SaveExcelFile(string filename)
        {
            bool b_ret;

            //Save
            try
            {
                b_ret = spdModel.SaveExcel(filename);

                if (b_ret == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(333));
                    return;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private int FillDataNode(int i_row, TRSNode node, int i_start, int i_end, string s_parent_list_path)
        {
            int i;
            int i_pos;
            string s_data_type;
            string s_member_name;
            string s_value;

            try
            {
                for (i = i_start; i < i_end; i++)
                {
                    s_data_type = MPCF.Trim(spdModel.ActiveSheet.Cells[ROW_DATA_TYPE, i].Value).Substring(0, 1);
                    s_member_name = MPCF.Trim(spdModel.ActiveSheet.Cells[ROW_MEMBER_NAME, i].Value);
                    s_value = MPCF.Trim(spdModel.ActiveSheet.Cells[i_row, i].Value);

                    i_pos = s_member_name.LastIndexOf('.');
                    if (i_pos > 0)
                    {
                        string s_list_path;

                        s_list_path = s_member_name.Substring(0, i_pos);
                        s_member_name = s_member_name.Substring(i_pos + 1);

                        if (s_parent_list_path != s_list_path)
                        {
                            TRSNode child_node;
                            string s_list_name;
                            int i_list_end_col, i_list_end_row;
                            int k;

                            for (i_list_end_col = i + 1; i_list_end_col < i_end; i_list_end_col++)
                            {
                                s_member_name = MPCF.Trim(spdModel.ActiveSheet.Cells[ROW_MEMBER_NAME, i_list_end_col].Value);
                                if (s_member_name.StartsWith(s_list_path) == false)
                                {
                                    break;
                                }
                            }

                            if (s_parent_list_path == null)
                            {
                                s_list_name = s_list_path;
                            }
                            else
                            {
                                s_list_name = s_list_path.Substring(s_parent_list_path.Length + 1);
                            }

                            for (i_list_end_row = i_row + 1; i_list_end_row < spdModel.ActiveSheet.RowCount; i_list_end_row++)
                            {
                                if (spdModel.ActiveSheet.Cells[i_list_end_row, 0].Value == null ||
                                    Convert.ToBoolean(spdModel.ActiveSheet.Cells[i_list_end_row, 0].Value) == false)
                                {
                                    break;
                                }

                                for (k = i_start; k < i; k++)
                                {
                                    if (MPCF.Trim(spdModel.ActiveSheet.Cells[i_list_end_row, k].Value) != 
                                        MPCF.Trim(spdModel.ActiveSheet.Cells[i_row, k].Value))
                                    {
                                        break;
                                    }
                                }
                                if (k < i)
                                {
                                    break;
                                }
                            }

                            for (k = i_row; k < i_list_end_row; k++)
                            {
                                child_node = node.AddNode(s_list_name);
                                k = FillDataNode(k, child_node, i, i_list_end_col, s_list_path);
                            }

                            i_row = i_list_end_row - 1;
                            i = i_list_end_col;
                            continue;
                        }
                    }

                    switch (s_data_type)
                    {
                        case "S": // String
                            node.SetString(s_member_name, s_value);
                            break;
                        case "C": // Char
                            node.SetChar(s_member_name, s_value);
                            break;
                        case "I": // Int
                            node.SetInt(s_member_name, s_value);
                            break;
                        case "D": // Double
                            node.SetDouble(s_member_name, s_value);
                            break;
                    }
                }//end for

                return i_row;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return -1;
            }
        }

        private bool UpdateData(ref int i_row, string s_module, string s_service, char c_proc)
        {
            TRSNode in_node = new TRSNode("IN_NODE");
            TRSNode out_node = new TRSNode("OUT_NODE");

            int i_col;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc;

                i_col = spdModel.ActiveSheet.ColumnCount - 2;
                i_row = FillDataNode(i_row, in_node, 1, i_col, null);

                //spdModel.ActiveSheet.Cells[i_row, 1, i_row, i_col].ForeColor = Color.Black;

                if (MPCR.CallService(s_module, s_service, in_node, ref out_node, true) == false)
                {
                    spdModel.ActiveSheet.SetValue(i_row, i_col, "Failure"); i_col++;
                    spdModel.ActiveSheet.SetValue(i_row, i_col, out_node.Msg);
                    spdModel.ActiveSheet.Cells[i_row, i_col - 1, i_row, i_col].ForeColor = Color.Red;
                    return false;
                }

                spdModel.ActiveSheet.SetValue(i_row, i_col, "Success"); i_col++;
                spdModel.ActiveSheet.SetValue(i_row, i_col, out_node.Msg);
                spdModel.ActiveSheet.Cells[i_row, i_col - 1, i_row, i_col].ForeColor = Color.Green;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckServiceMember(string mod_name, string svc_name)
        {
            int i_mem_cnt;
            int i, k;
            bool b_chk_mbr;
            bool b_chk_final;
            string s_member_name;

            TRSNode in_node = new TRSNode("View_Service_Member_List_In");
            TRSNode out_node = new TRSNode("View_Service_Member_List_Out");
            TRSNode member;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddString("MODULE_NAME", mod_name);
                in_node.AddString("SERVICE_NAME", svc_name);
                in_node.SetChar("DIRECTION", 'I');

                if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                i_mem_cnt = out_node.GetList(0).Count;
                b_chk_final = true;

                for (i = 0; i < i_mem_cnt; i++)
                {
                    member = out_node.GetList(0)[i];

                    if (member.GetString("MEMBER_TYPE") == "List" || member.GetString("MEMBER_TYPE") == "Array")
                    {
                        continue;
                    }

                    s_member_name = member.GetString("MEMBER_PATH");
                    s_member_name = s_member_name.Replace("/", ".");

                    if ((s_member_name != "PASSPORT") && (s_member_name != "LANGUAGE") && (s_member_name != "LOGLEVEL")
                        && (s_member_name != "PROCSTEP") && (s_member_name != "USERID") && (s_member_name != "PASSWORD"))
                    {
                        b_chk_mbr = false;

                        for (k = 1; k < spdModel.ActiveSheet.ColumnCount - 2; k++)
                        {
                            if (s_member_name == MPCF.Trim(spdModel.ActiveSheet.Cells[ROW_MEMBER_NAME, k].Value))
                            {
                                b_chk_mbr = true;
                                break;
                            }
                        }

                        if (b_chk_mbr == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(334) + "\r\n[" + s_member_name + "]");
                            b_chk_final = false;
                        }
                    }
                }

                if (b_chk_final == false)
                {
                    return false;
                }

                MPCF.ShowMsgBox(MPCF.GetMessage(62));
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        private void frmBASSetupDataByImport_Load(object sender, EventArgs e)
        {
            prgBar.Value = 0;
            lblPercent.Text = "";
            lblTotalCnt.Text = "";
            lblOkCnt.Text = "";
            lblErrCnt.Text = "";
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                ofdFile.Filter = "Excel Files(*.xls;*.xlsx)|*.xls;*.xlsx";
                ofdFile.DefaultExt = "xls,xlsx";
                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    txtModelFile.Text = ofdFile.FileName;
                    btnImport.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenExcelFile(txtModelFile.Text);
                cboModelItem.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            int i_dot;
            string s_resfile;
            try
            {
                i_dot = txtModelFile.Text.LastIndexOf(".xls");
                s_resfile = txtModelFile.Text;
                s_resfile = s_resfile.Remove(i_dot);
                s_resfile += "_Result.xls";
                sfdFile.FileName = sfdFile.InitialDirectory + s_resfile;

                if (sfdFile.ShowDialog() == DialogResult.OK)
                {
                    SaveExcelFile(sfdFile.FileName);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdModel_ActiveSheetChanged(object sender, EventArgs e)
        {
            cboModelItem.SelectedItem = spdModel.ActiveSheet.SheetName;
            chkAll.Checked = false;
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (spdModel.ActiveSheet.RowCount > ROW_DATA_START)
            {
                for (int i_row = ROW_DATA_START; i_row < spdModel.ActiveSheet.RowCount; i_row++)
                {
                    spdModel.ActiveSheet.Cells[i_row, 0].Value = chkAll.Checked;
                }
            }
        }

        private void cboModelItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            spdModel.ActiveSheetIndex = cboModelItem.SelectedIndex;
        }

        private void btnValHead_Click(object sender, EventArgs e)
        {
            switch (cboModelItem.SelectedIndex)
            {
                case 0:
                    CheckServiceMember("WIP", "WIP_Update_Operation");
                    break;

                case 1:
                    CheckServiceMember("WIP", "WIP_Update_Material");
                    break;

                case 2:
                    CheckServiceMember("WIP", "WIP_Update_Flow");
                    break;

                case 3:
                    CheckServiceMember("RAS", "RAS_Update_Resource");
                    break;

                case 4:
                    CheckServiceMember("SEC", "SEC_Update_User_Ext");
                    break;

                case 5:
                    CheckServiceMember("BAS", "BAS_Update_Table");
                    break;

                case 6:
                    CheckServiceMember("BAS", "BAS_Update_Data_List");
                    break;
            }
        }

        private void btnValValue_Click(object sender, EventArgs e)
        {
            int i, k;

            if (spdModel.ActiveSheet.RowCount <= ROW_DATA_START)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(336));
                return;
            }

            for (i = 1; i < spdModel.ActiveSheet.ColumnCount; i++)
            {
                if (spdModel.ActiveSheet.Columns[i].BackColor.ToArgb() == 0)
                {
                    continue;
                }

                for (k = ROW_DATA_START; k < spdModel.ActiveSheet.RowCount; k++)
                {
                    if (Convert.ToBoolean(spdModel.ActiveSheet.Cells[k, 0].Value) == true)
                    {
                        if (MPCF.Trim(spdModel.ActiveSheet.Cells[k, i].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335));
                            spdModel.ActiveSheet.SetActiveCell(k, i);
                            spdModel.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                            return;
                        }
                    }
                }
            }

            MPCF.ShowMsgBox(MPCF.GetMessage(62));
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int i_row;
            int i_prev_row;
            int i_cnt_ok;
            int i_cnt_err;
            int i_cnt_chk;
            int i_percent;
            string s_module;
            string s_service;
            char   c_proc;

            try
            {
                prgBar.Value = 0;
                lblPercent.Text = "";
                lblTotalCnt.Text = "";
                lblOkCnt.Text = "";
                lblErrCnt.Text = "";
                i_cnt_ok = 0;
                i_cnt_err = 0;
                i_cnt_chk = 0;

                if (spdModel.ActiveSheet.RowCount <= ROW_DATA_START)
                {
                    return;
                }

                for (i_row = ROW_DATA_START; i_row < spdModel.ActiveSheet.RowCount; i_row++)
                {
                    if (Convert.ToBoolean(spdModel.ActiveSheet.Cells[i_row, 0].Value) == true)
                    {
                        i_cnt_chk++;
                    }
                }

                if (i_cnt_chk < 1)
                {
                    return;
                }

                lblPercent.Text = "(0%)";
                lblTotalCnt.Text = "0/" + i_cnt_chk;
                lblOkCnt.Text = "0";
                lblErrCnt.Text = "0";

                s_module = "";
                s_service = "";
                c_proc = ' ';

                switch (cboModelItem.SelectedIndex)
                {
                    case 0:
                        s_module = "WIP";
                        s_service = "WIP_Update_Operation";
                        c_proc = MPGC.MP_STEP_CREATE;
                        break;
                    case 1:
                        s_module = "WIP";
                        s_service = "WIP_Update_Material";
                        c_proc = MPGC.MP_STEP_CREATE;
                        break;

                    case 2:
                        s_module = "WIP";
                        s_service = "WIP_Update_Flow";
                        c_proc = MPGC.MP_STEP_CREATE;
                        break;

                    case 3:
                        s_module = "RAS";
                        s_service = "RAS_Update_Resource";
                        c_proc = MPGC.MP_STEP_CREATE;
                        break;

                    case 4:
                        s_module = "SEC";
                        s_service = "SEC_Update_User_Ext";
                        c_proc = MPGC.MP_STEP_CREATE;
                        break;

                    case 5:
                        s_module = "BAS";
                        s_service = "BAS_Update_Table";
                        c_proc = MPGC.MP_STEP_CREATE;
                        break;

                    case 6:
                        s_module = "BAS";
                        s_service = "BAS_Update_Data_List";
                        c_proc = MPGC.MP_STEP_UPDATE;
                        break;
                }

                btnCancel.Enabled = true;
                b_chk_cancel = false;

                for (i_row = ROW_DATA_START; i_row < spdModel.ActiveSheet.RowCount; i_row++)
                {
                    if (b_chk_cancel == true)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(63));
                        return;
                    }

                    if (Convert.ToBoolean(spdModel.ActiveSheet.Cells[i_row, 0].Value) == true)
                    {
                        i_prev_row = i_row;
                        if (UpdateData(ref i_row, s_module, s_service, c_proc) == true)
                        {
                            i_cnt_ok += i_row - i_prev_row + 1;
                        }
                        else
                        {
                            i_cnt_err += i_row - i_prev_row + 1;
                        }
                        spdModel.ActiveSheet.Cells[i_prev_row, 0, i_row, 0].Value = false;
                        spdModel.ActiveSheet.SetActiveCell(i_row, 0);
                        spdModel.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

                        i_percent = (int)(((i_cnt_ok + i_cnt_err) / (double)i_cnt_chk) * 100);
                        prgBar.Value = i_percent;
                        lblPercent.Text = "(" + i_percent + "%)";
                        lblTotalCnt.Text = (i_cnt_ok + i_cnt_err) + " / " + i_cnt_chk;
                        lblOkCnt.Text = i_cnt_ok.ToString();
                        lblErrCnt.Text = i_cnt_err.ToString();
                    }
                }//end for

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {
                btnCancel.Enabled = false;
                b_chk_cancel = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            b_chk_cancel = true;
        }
    }
}
