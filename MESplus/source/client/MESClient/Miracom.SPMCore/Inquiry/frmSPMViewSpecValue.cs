//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSPMViewSpecValue.cs
//   Description : View Specification Value Form
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-08-13 : Created by Aiden Koo
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
using System.IO;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.SPMCore
{
    public partial class frmSPMViewSpecValue : ViewForm01
    {
        public frmSPMViewSpecValue()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private int i_spec_attr_start_index;

        private struct CHAR_GRP_CMF
        {
            public string s_prompt;
            public string s_table;
            public char c_format;
            public string s_col_name;
        }
        private List<CHAR_GRP_CMF> st_char_grp_cmf;

        private int i_sort_order_x;
        private int i_sort_order_y;
        private int i_sort_order_col;
        private bool b_header_click;
        private int i_file_col_start;
        private bool b_popup_action;

        #endregion

        #region " Function Definition "

        private void SetCharGrpCmfPrompt()
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            int i;
            int i_sort_col_idx;
            string s_prompt;
            CHAR_GRP_CMF st_char;
            string[] sGrpTableName;

            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_CHARACTER, ref out_node, "", true) == false)
            {
                return;
            }

            st_char_grp_cmf = new List<CHAR_GRP_CMF>();
            cboCharGrp1.Items.Add("");
            cboCharGrp2.Items.Add("");

            sGrpTableName = new string[10];
            sGrpTableName[0] = MPGC.MP_GCM_CHAR_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_CHAR_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_CHAR_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_CHAR_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_CHAR_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_CHAR_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_CHAR_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_CHAR_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_CHAR_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_CHAR_GRP_10;


            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                s_prompt = out_node.GetList(0)[i].GetString("PROMPT");
                if (s_prompt != "")
                {
                    cboCharGrp1.Items.Add(s_prompt);
                    cboCharGrp2.Items.Add(s_prompt);

                    st_char = new CHAR_GRP_CMF();
                    st_char.s_prompt = s_prompt;
                    st_char.s_col_name = sGrpTableName[i];
                    st_char.s_table = out_node.GetList(0)[i].GetString("TABLE_NAME");
                    st_char.c_format = out_node.GetList(0)[i].GetChar("FORMAT");
                    if (st_char.s_table == "")
                    {
                        st_char.s_table = sGrpTableName[i];
                    }
                    st_char_grp_cmf.Add(st_char);

                    FarPoint.Win.BevelBorder bevelBorder = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlDark, 2);
                    FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    checkBoxCellType.Caption = s_prompt;

                    i_sort_col_idx = spdSortCol.ActiveSheet.ColumnCount;
                    spdSortCol.ActiveSheet.ColumnCount += 1;
                    spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i_sort_col_idx].Border = bevelBorder;
                    spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i_sort_col_idx].CellType = checkBoxCellType;
                    spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i_sort_col_idx].Tag = s_prompt;
                    spdSortCol.ActiveSheet.Cells[0, i_sort_col_idx].Value = sGrpTableName[i];
                }
            }

            out_node.Init();
            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_CHARACTER, ref out_node, "", true) == false)
            {
                return;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                s_prompt = out_node.GetList(0)[i].GetString("PROMPT");
                if (s_prompt != "")
                {
                    cboCharGrp1.Items.Add(s_prompt);
                    cboCharGrp2.Items.Add(s_prompt);

                    st_char = new CHAR_GRP_CMF();
                    st_char.s_prompt = s_prompt;
                    st_char.s_col_name = "CHAR_CMF_" + (i + 1).ToString();
                    st_char.s_table = out_node.GetList(0)[i].GetString("TABLE_NAME");
                    st_char.c_format = out_node.GetList(0)[i].GetChar("FORMAT");
                    st_char_grp_cmf.Add(st_char);

                    // Sort Order 에는 CMF 는 포함시키지 않도록 한다.
                    //i_sort_col_idx = spdSortCol.ActiveSheet.ColumnCount;
                    //spdSortCol.ActiveSheet.ColumnCount += 1;
                    //spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i_sort_col_idx].Value = s_prompt;
                    //spdSortCol.ActiveSheet.Cells[0, i_sort_col_idx].Value = "CHAR_CMF_" + (i + 1).ToString();
                }
            }
        }

        private bool ViewSpecAttributeNameList()
        {
            int i;
            int i_col_idx;
            TRSNode in_node = new TRSNode("List_In");
            TRSNode out_node = new TRSNode("List_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_SPEC);

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                i_spec_attr_start_index = 0;
                for (i = 0; i < out_node.GetList(0).Count; i++ )
                {
                    i_col_idx = spdData.ActiveSheet.ColumnCount;

                    if (i < 1)
                    {
                        i_spec_attr_start_index = i_col_idx;
                    }

                    spdData.ActiveSheet.ColumnCount += 1;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, i_col_idx].Value = out_node.GetList(0)[i].GetString("ATTR_NAME");
                    spdData.ActiveSheet.Columns[i_col_idx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdData.ActiveSheet.Columns[i_col_idx].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                }

                in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));
            } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);

            return true;
        }

        private string TrimForMerge(object obj)
        {
            string s = MPCF.Trim(obj);
            return s == "" ? " " : s;
        }

        //
        // ViewSpecValue()
        //       - View Spec Value
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewSpecValue()
        {
            TRSNode in_node = new TRSNode("VIEW_SPEC_VALUE_IN");
            TRSNode out_node = new TRSNode("VIEW_SPEC_VALUE_OUT");
            List<TRSNode> value_list;
            List<TRSNode> attr_list;
            int i, k;
            int i_col, i_row;
            string s_temp;

            try
            {
                i_file_col_start = 0;
                MPCF.ClearList(spdData);
                for (i = 0; i < spdSortCol.ActiveSheet.ColumnHeader.Columns.Count; i++)
                {
                    if (Convert.ToBoolean(spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].Value) == true)
                    {
                        spdData.ActiveSheet.ColumnHeader.Cells[0, i].Value = MPCF.Trim(spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].Tag);
                        spdData.ActiveSheet.Columns[i].Resizable = true;
                    }
                    else
                    {
                        spdData.ActiveSheet.ColumnHeader.Cells[0, i].Value = "";
                        spdData.ActiveSheet.Columns[i].Width = 0;
                        spdData.ActiveSheet.Columns[i].Resizable = false;
                    }
                }

                if (chkSpecValueOnly.Checked == true)
                {
                    spdData.ActiveSheet.ClearRangeGroup(false);
                    spdData.ActiveSheet.Tag = null;

                    for (i = spdSortCol.ActiveSheet.ColumnCount + 1; i < spdData.ActiveSheet.ColumnCount; i++)
                    {
                        spdData.ActiveSheet.Columns[i].Width = 0;
                        spdData.ActiveSheet.Columns[i].Resizable = false;
                    }
                }
                else if (MPCF.Trim(spdData.ActiveSheet.Tag) != "Group")
                {
                    int i_start_group_index;
                    int i_count_group;

                    i_start_group_index = spdSortCol.ActiveSheet.ColumnCount + 1;
                    i_count_group = spdData.ActiveSheet.ColumnCount - i_start_group_index - 1;

                    spdData.ActiveSheet.AddRangeGroup(i_start_group_index, i_count_group, false);
                    spdData.ActiveSheet.Tag = "Group";

                    for (i = spdSortCol.ActiveSheet.ColumnCount + 1; i < spdData.ActiveSheet.ColumnCount; i++)
                    {
                        spdData.ActiveSheet.Columns[i].Resizable = true;
                    }
                    spdData.ActiveSheet.Columns[spdData.ActiveSheet.ColumnCount - 1].Resizable = false;
                }


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                /* 2013.06.12. Aiden. LOT_ID 로도 Spec Value 를 조회할 수 있도록 변경 */
                in_node.SetString("LOT_ID", txtLot.Text);
                in_node.AddString("MAT_ID", udcMatID.Text);
                in_node.AddInt("MAT_VER", udcMatID.Version);
                in_node.AddString("OPER", udcOper.Text);
                in_node.AddString("CHAR_ID", cdvCharID.Text);
                in_node.AddChar("LAST_REL_VER_ONLY_FLAG", (cboRelVersion.SelectedIndex == 0 ? 'Y' : ' '));
                in_node.AddChar("SPEC_VALUE_ONLY_FLAG", (chkSpecValueOnly.Checked == true ? 'Y' : ' '));

                if (cboCharGrp1.SelectedIndex > 0 && MPCF.Trim(cdvCharGrp1.Text) != "")
                {
                    in_node.AddString("CHAR_GRP_1", MPCF.Trim(cdvCharGrp1.Text));
                    in_node.AddString("CHAR_GRP_1_COL", MPCF.Trim(cboCharGrp1.Tag));
                }
                if (cboCharGrp2.SelectedIndex > 0 && MPCF.Trim(cdvCharGrp2.Text) != "")
                {
                    in_node.AddString("CHAR_GRP_2", MPCF.Trim(cdvCharGrp2.Text));
                    in_node.AddString("CHAR_GRP_2_COL", MPCF.Trim(cboCharGrp2.Tag));
                }

                s_temp = "";
                for (i_col = 0; i_col < spdSortCol.ActiveSheet.ColumnCount; i_col++)
                {
                    if (Convert.ToBoolean(spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i_col].Value) == true)
                    {
                        if (s_temp != "") s_temp += ", ";
                        s_temp += MPCF.Trim(spdSortCol.ActiveSheet.Cells[0, i_col].Value) + " ASC";
                    }
                }
                in_node.AddString("SORT_ORDER", s_temp);


                do
                {
                    if (MPCR.CallService("SPM", "SPM_View_Spec_Value", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    value_list = out_node.GetList("VALUE_LIST");
                    for (i = 0; i < value_list.Count; i++)
                    {
                        i_row = spdData.ActiveSheet.RowCount;
                        spdData.ActiveSheet.RowCount++;

                        for (i_col = 0; i_col < spdSortCol.ActiveSheet.ColumnCount; i_col++)
                        {
                            if (Convert.ToBoolean(spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i_col].Value) == true)
                            {
                                s_temp = MPCF.Trim(spdSortCol.ActiveSheet.Cells[0, i_col].Value);
                                spdData.ActiveSheet.Cells[i_row, i_col].Value = TrimForMerge(value_list[i].GetString(s_temp));
                            }
                            else
                            {
                                spdData.ActiveSheet.Cells[i_row, i_col].Value = " ";
                            }
                        }

                        s_temp = "";
                        if (value_list[i].GetChar("SPEC_REF_TYPE") == 'M')
                        {
                            s_temp = MPCF.GetSpecInfo(value_list[i].GetString("UPPER_SPEC_LIMIT"),
                                                      value_list[i].GetString("LOWER_SPEC_LIMIT"),
                                                      value_list[i].GetString("TARGET_VALUE"));

                            /* 2013.06.12. Aiden. Target Value 가 File 인 경우 처리 */
                            spdData.ActiveSheet.Cells[i_row, i_col].Value = s_temp;
                            if (value_list[i].GetChar("TARGET_VALUE_WITH_FILE") == 'Y')
                            {
                                spdData.ActiveSheet.Cells[i_row, i_col].Font = new Font(spdData.Font, FontStyle.Underline);
                                spdData.ActiveSheet.Cells[i_row, i_col].ForeColor = Color.Blue;
                            }
                        }
                        else if (value_list[i].GetChar("SPEC_REF_TYPE") == 'C')
                        {
                            s_temp = MPCF.GetSpecInfo(value_list[i].GetString("CUST_UPPER_SPEC_LIMIT"),
                                                      value_list[i].GetString("CUST_LOWER_SPEC_LIMIT"),
                                                      value_list[i].GetString("CUST_TARGET_VALUE"));

                            /* 2013.06.12. Aiden. Target Value 가 File 인 경우 처리 */
                            spdData.ActiveSheet.Cells[i_row, i_col].Value = s_temp;
                            if (value_list[i].GetChar("TARGET_VALUE_WITH_FILE") == 'Y')
                            {
                                spdData.ActiveSheet.Cells[i_row, i_col].Font = new Font(spdData.Font, FontStyle.Underline);
                                spdData.ActiveSheet.Cells[i_row, i_col].ForeColor = Color.Blue;
                            }
                        }

                        i_col += 1;

                        /* 2013.06.12. Aiden. 파일 정보를 앞으로 이동 */
                        if (i_file_col_start == 0)
                        {
                            i_file_col_start = i_col;
                        }
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("DOC_NAME_1"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("DOC_NAME_2"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("DOC_NAME_3"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("DOC_NAME_4"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("DOC_NAME_5"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("IMG_NAME_1"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("IMG_NAME_2"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("IMG_NAME_3"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("IMG_NAME_4"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("IMG_NAME_5"));

                        spdData.ActiveSheet.Cells[i_row, 0].Tag = value_list[i].GetString("SPEC_REL_ID");
                        spdData.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetInt("SPEC_REL_VER");
                        spdData.ActiveSheet.Cells[i_row, 2].Tag = value_list[i].GetString("CHAR_ID");

                        if (chkSpecValueOnly.Checked == true)
                        {
                            continue;
                        }

                        if (value_list[i].GetChar("SPEC_REF_TYPE") == 'M')
                        {
                            spdData.ActiveSheet.Cells[i_row, i_col++].Value = "M";
                            spdData.ActiveSheet.Cells[i_row, i_col++].Value = value_list[i].GetString("SPEC_OUT_ALARM");
                            spdData.ActiveSheet.Cells[i_row, i_col++].Value = value_list[i].GetString("WARN_OUT_ALARM");
                        }
                        else if (value_list[i].GetChar("SPEC_REF_TYPE") == 'C')
                        {
                            spdData.ActiveSheet.Cells[i_row, i_col++].Value = "C";
                            spdData.ActiveSheet.Cells[i_row, i_col++].Value = value_list[i].GetString("CUST_SPEC_OUT_ALARM");
                            spdData.ActiveSheet.Cells[i_row, i_col++].Value = value_list[i].GetString("CUST_WARN_OUT_ALARM");
                        }
                        else
                        {
                            i_col += 3;
                        }

                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = value_list[i].GetChar("RELEASE_FLAG");
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("RELEASE_USER_ID"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(MPCF.MakeDateFormat(value_list[i].GetString("RELEASE_TIME")));

                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = value_list[i].GetChar("APPROVAL_FLAG");
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(value_list[i].GetString("APPROVAL_USER_ID"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = TrimForMerge(MPCF.MakeDateFormat(value_list[i].GetString("APPROVAL_TIME")));

                        s_temp = MPCF.MakeDateFormat(value_list[i].GetString("APPLY_START_TIME")) + " ~ "
                                + MPCF.MakeDateFormat(value_list[i].GetString("APPLY_END_TIME"));
                        spdData.ActiveSheet.Cells[i_row, i_col++].Value = s_temp;
                        spdData.ActiveSheet.Cells[i_row, i_col].Value = " ";

                        if (i_spec_attr_start_index > 0)
                        {
                            for (i_col = i_spec_attr_start_index; i_col < spdData.ActiveSheet.ColumnCount; i_col++)
                            {
                                spdData.ActiveSheet.Cells[i_row, i_col].Value = " ";
                            }

                            attr_list = value_list[i].GetList("ATTR_LIST");
                            for (k = 0; k < attr_list.Count; k++)
                            {
                                for (i_col = i_spec_attr_start_index; i_col < spdData.ActiveSheet.ColumnCount; i_col++)
                                {
                                    if (attr_list[k].GetString("ATTR_NAME") == MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value))
                                    {
                                        if (attr_list[k].GetChar("NULL_FLAG") == 'Y')
                                        {
                                            spdData.ActiveSheet.Cells[i_row, i_col].Value = "[Null]";
                                        }
                                        else
                                        {
                                            spdData.ActiveSheet.Cells[i_row, i_col].Value = TrimForMerge(attr_list[k].GetString("ATTR_VALUE"));
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                } while (in_node.GetInt("NEXT_SEQ") > 0);

                if (chkSpecValueOnly.Checked == true)
                {
                    MPCF.FitColumnHeader(spdData, 0, spdSortCol.ActiveSheet.ColumnCount, true);
                }
                else
                {
                    MPCF.FitColumnHeader(spdData, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /* 2013.06.12. Aiden. Attach File 을 조회하는 기능 추가 */
        private bool ViewCharacterAttachFile(char c_case, string s_spec_rel_id, int i_spec_rel_ver, string s_char_id, string s_file_name)
        {
            TRSNode in_node = new TRSNode("VIEW_SPEC_ATTACH_FILE_IN");
            TRSNode out_node = new TRSNode("VIEW_SPEC_ATTACH_FILE_OUT");
            byte[] bt_buffer;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_case;
            in_node.AddString("SPEC_REL_ID", s_spec_rel_id);
            in_node.AddInt("SPEC_REL_VER", i_spec_rel_ver);
            in_node.AddString("CHAR_ID", s_char_id);
            in_node.AddString("FILE_NAME", s_file_name);

            if (MPCR.CallService("SPM", "SPM_View_Spec_Attach_File", in_node, ref out_node) == false)
            {
                return false;
            }

            if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) == null)
            {
                return false;
            }

            s_file_name = out_node.GetString("FILE_NAME");
            s_file_name = Environment.GetEnvironmentVariable("TEMP") + "\\" + s_file_name;

            try
            {
                FileStream fs = File.Open(s_file_name, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fs);
                writer.Write(bt_buffer, 0, bt_buffer.Length);
                writer.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            Process proc = new Process();
            proc.StartInfo.FileName = s_file_name;
            proc.Start();

            return true;
        }

        public virtual Control GetFirstFocusItem()
        {
            try
            {
                return this.udcMatID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        /* 2013.06.12. Aiden. 외부에서 Material ID 를 지정할 수 있도록 변경 */
        public void SetMaterialID(string s_mat_id, int i_mat_ver)
        {
            b_popup_action = true;
            udcMatID.Text = s_mat_id;
            udcMatID.Version = i_mat_ver;
        }

        #endregion

        private void frmSPMViewSpecValue_Activated(object sender, EventArgs e)
        {
            int i;
            string s_caption;

            try
            {
                if (b_load_flag == false)
                {
                    spdData.ActiveSheet.RowCount = 0;

                    cdvCharGrp1.VisibleButton = false;
                    cdvCharGrp2.VisibleButton = false;

                    cboRelVersion.SelectedIndex = 0;

                    SetCharGrpCmfPrompt();

                    MPCF.FitColumnHeader(spdSortCol);
                    for (i = 0; i < spdSortCol.ActiveSheet.ColumnHeader.Columns.Count; i++)
                    {
                        spdSortCol.ActiveSheet.ColumnHeader.Columns[i].Resizable = false;
                        s_caption = MPCF.Trim(((FarPoint.Win.Spread.CellType.CheckBoxCellType)spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].CellType).Caption);
                        spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].Tag = s_caption;

                        spdData.ActiveSheet.Columns.Add(i, 1);
                        spdData.ActiveSheet.ColumnHeader.Cells[0, i].Value = s_caption;
                        spdData.ActiveSheet.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }

                    ViewSpecAttributeNameList();

                    spdData.ActiveSheet.SetColumnAllowAutoSort(0, spdData.ActiveSheet.ColumnCount, true);
                    MPCF.FitColumnHeader(spdData);

                    /* Column Group Indicator 를 표시하기 위해 */
                    i = spdData.ActiveSheet.ColumnCount;
                    spdData.ActiveSheet.ColumnCount++;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, i].Value = "";
                    spdData.ActiveSheet.Columns[i].Width = 20;
                    spdData.ActiveSheet.Columns[i].Resizable = false;
                    spdData.ActiveSheet.Columns[i].Locked = true;
                    spdData.ActiveSheet.Columns[i].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;


                    /* 2013.06.12. Aiden. Material ID 가 지정되어 있는 경우 자동 조회 */
                    if (udcMatID.Text != "" && b_popup_action == true)
                    {
                        btnView.PerformClick();
                    }

                    b_load_flag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCharID_ButtonPress(object sender, EventArgs e)
        {
            cdvCharID.Init();
            cdvCharID.Columns.Add("Character", 50, HorizontalAlignment.Left);
            cdvCharID.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvCharID.SelectedSubItemIndex = 0;
            if (EDCLIST.ViewEDCCharacterList(cdvCharID.GetListView, '1', 'S') == false)
            {
                return;
            }
        }

        private void cboCharGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb;
            int i_index;
            int i_grp_index;
            Miracom.UI.Controls.MCCodeView.MCCodeView cdv;

            cb = (ComboBox)sender;
            cdv = cdvCharGrp2;
            i_grp_index = 2;

            if (cb.Name == "cboCharGrp1")
            {
                cdv = cdvCharGrp1;
                i_grp_index = 1;
            }
            cdv.Text = "";
            cb.Tag = "";

            if (cb.SelectedIndex < 1)
            {
                cdv.VisibleButton = false; 
                return;
            }

            i_index = cb.SelectedIndex - 1;

            switch (i_grp_index)
            {
                case 1:
                    if (cboCharGrp2.Text == st_char_grp_cmf[i_index].s_prompt)
                    {
                        cboCharGrp1.SelectedIndex = 0;
                        return;
                    }
                    break;
                case 2:
                    if (cboCharGrp1.Text == st_char_grp_cmf[i_index].s_prompt)
                    {
                        cboCharGrp2.SelectedIndex = 0;
                        return;
                    }
                    break;
            }

            cb.Tag = st_char_grp_cmf[i_index].s_col_name;

            if (st_char_grp_cmf[i_index].s_table == "")
            {
                cdv.VisibleButton = false;
            }
            else
            {
                cdv.Init();
                cdv.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdv.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdv.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdv.GetListView, '1', st_char_grp_cmf[i_index].s_table);
                cdv.VisibleButton = true;
            }
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            pnlViewTop.Height = 20;
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            pnlViewTop.Height = 145;
        }

        private void btnToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                sfdPDF.Filter = "PDF Files | *.pdf";
                sfdPDF.FileName = udcMatID.Text + "_" + udcMatID.Version.ToString();
                if (sfdPDF.ShowDialog() == DialogResult.OK)
                {
                    FarPoint.Win.Spread.PrintInfo printset = new FarPoint.Win.Spread.PrintInfo();
                    printset.Header = "/c /fu1 /fn\"Microsoft Sans Serif\" /fz\"20\" The specification of <" + udcMatID.Text + ", " + udcMatID.Version.ToString() + ">/n /fu0 /r /ds /ts";
                    printset.PrintToPdf = true;
                    printset.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;
                    printset.PdfFileName = sfdPDF.FileName;

                    // Assign the printer settings and print
                    spdData.ActiveSheet.PrintInfo = printset;
                    spdData.PrintSheet(0);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //if (MPCF.CheckValue(udcMatID, 0) == false) return;

            ViewSpecValue();
        }

        private void spdSortCol_MouseUp(object sender, MouseEventArgs e)
        {
            if (b_header_click == true)
            {
                if (Math.Abs(e.X - i_sort_order_x) < 5 && Math.Abs(e.Y - i_sort_order_y) < 5)
                {
                    bool b_checked = Convert.ToBoolean(spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i_sort_order_col].Value);
                    spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i_sort_order_col].Value = !b_checked;
                }
            }

            b_header_click = false;
            i_sort_order_x = 0;
            i_sort_order_y = 0;
            i_sort_order_col = 0;
        }

        private void spdSortCol_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == false) return;

            b_header_click = true;
            i_sort_order_x = e.X;
            i_sort_order_y = e.Y;
            i_sort_order_col = e.Column;
        }

        /* 2013.06.12. Aiden. Attach File 링크를 클릭하는 경우 조회 */
        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string s_spec_rel_id;
            int i_spec_rel_ver;
            string s_char_id;
            string s_file_name;

            if (e.Row < 0) return;
            if (e.Column >= i_file_col_start + 10) return;
            if (e.Column < i_file_col_start)
            {
                if (spdData.ActiveSheet.Cells[e.Row, e.Column].Font == null) return;
                if (spdData.ActiveSheet.Cells[e.Row, e.Column].Font.Underline == false) return;
            }

            s_file_name = MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, e.Column].Value);
            if (s_file_name == "") return;

            s_spec_rel_id = MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, 0].Tag);
            i_spec_rel_ver = MPCF.ToInt(spdData.ActiveSheet.Cells[e.Row, 1].Tag);
            s_char_id = MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, 2].Tag);

            if (e.Column < i_file_col_start)
            {
                if (ViewCharacterAttachFile('2', s_spec_rel_id, i_spec_rel_ver, s_char_id, s_file_name) == false)
                {
                    return;
                }
            }
            else
            {
                if (ViewCharacterAttachFile('1', s_spec_rel_id, i_spec_rel_ver, s_char_id, s_file_name) == false)
                {
                    return;
                }
            }
        }

    
    }
}
