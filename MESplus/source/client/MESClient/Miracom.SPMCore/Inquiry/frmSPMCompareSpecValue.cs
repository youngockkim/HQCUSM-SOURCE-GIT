//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSPMCompareSpecValue.cs
//   Description : Compare Specification Value Form
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
//       - 2012-08-20 : Created by Aiden Koo
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

namespace Miracom.SPMCore
{
    public partial class frmSPMCompareSpecValue : ViewForm01
    {
        public frmSPMCompareSpecValue()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

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
                }
            }
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
            TRSNode in_node = new TRSNode("COMPARE_SPEC_VALUE_IN");
            TRSNode out_node = new TRSNode("COMPARE_SPEC_VALUE_OUT");
            List<TRSNode> data_list;
            List<TRSNode> obj_list;
            int i, k;
            int i_col, i_row;
            string s_temp;

            try
            {
                MPCF.ClearList(spdData);
                spdData.ActiveSheet.ColumnCount = spdSortCol.ActiveSheet.ColumnCount;

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


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID_1", udcMatID1.Text);
                in_node.AddString("MAT_ID_2", udcMatID2.Text);
                in_node.AddString("MAT_ID_3", udcMatID3.Text);
                in_node.AddString("MAT_ID_4", udcMatID4.Text);
                in_node.AddString("MAT_ID_5", udcMatID5.Text);
                in_node.AddInt("MAT_VER_1", udcMatID1.Version);
                in_node.AddInt("MAT_VER_2", udcMatID2.Version);
                in_node.AddInt("MAT_VER_3", udcMatID3.Version);
                in_node.AddInt("MAT_VER_4", udcMatID4.Version);
                in_node.AddInt("MAT_VER_5", udcMatID5.Version);
                in_node.AddString("OPER_1", udcOper1.Text);
                in_node.AddString("OPER_2", udcOper2.Text);
                in_node.AddString("OPER_3", udcOper3.Text);
                in_node.AddString("OPER_4", udcOper4.Text);
                in_node.AddString("OPER_5", udcOper5.Text);

                if (rbtBaseOnMat.Checked == true)
                {
                    in_node.AddChar("BASE_ON_FLAG", 'M');

                    if (MPCF.Trim(udcMatID1.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcMatID1.Text) + " (" + udcMatID1.Version.ToString() + ")";
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                    if (MPCF.Trim(udcMatID2.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcMatID2.Text) + " (" + udcMatID2.Version.ToString() + ")";
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                    if (MPCF.Trim(udcMatID3.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcMatID3.Text) + " (" + udcMatID3.Version.ToString() + ")";
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                    if (MPCF.Trim(udcMatID4.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcMatID4.Text) + " (" + udcMatID4.Version.ToString() + ")";
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                    if (MPCF.Trim(udcMatID5.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcMatID5.Text) + " (" + udcMatID5.Version.ToString() + ")";
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                }
                else if (rbtBaseOnOper.Checked == true)
                {
                    in_node.AddChar("BASE_ON_FLAG", 'O');

                    if (MPCF.Trim(udcOper1.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcOper1.Text);
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                    if (MPCF.Trim(udcOper2.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcOper2.Text);
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                    if (MPCF.Trim(udcOper3.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcOper3.Text);
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                    if (MPCF.Trim(udcOper4.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcOper4.Text);
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                    if (MPCF.Trim(udcOper5.Text) != "")
                    {
                        i_col = spdData.ActiveSheet.ColumnCount;
                        spdData.ActiveSheet.ColumnCount++;

                        spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = MPCF.Trim(udcOper5.Text);
                        spdData.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    }
                }

                in_node.AddString("FLOW", udcFlow.Text);
                in_node.AddString("CHAR_ID", cdvCharID.Text);
                in_node.AddChar("LAST_REL_VER_ONLY_FLAG", (cboRelVersion.SelectedIndex == 0 ? 'Y' : ' '));
                in_node.AddChar("SPEC_VALUE_ONLY_FLAG", 'Y');

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
                    if (MPCR.CallService("SPM", "SPM_Compare_Spec_Value", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    data_list = out_node.GetList("DATA_LIST");
                    for (i = 0; i < data_list.Count; i++)
                    {
                        i_row = spdData.ActiveSheet.RowCount;
                        spdData.ActiveSheet.RowCount++;

                        for (i_col = 0; i_col < spdSortCol.ActiveSheet.ColumnCount; i_col++)
                        {
                            if (Convert.ToBoolean(spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i_col].Value) == true)
                            {
                                s_temp = MPCF.Trim(spdSortCol.ActiveSheet.Cells[0, i_col].Value);
                                if (s_temp == "MAT_VER")
                                {
                                    spdData.ActiveSheet.Cells[i_row, i_col].Value = TrimForMerge(data_list[i].GetInt(s_temp));
                                }
                                else
                                {
                                    spdData.ActiveSheet.Cells[i_row, i_col].Value = TrimForMerge(data_list[i].GetString(s_temp));
                                }
                            }
                            else
                            {
                                spdData.ActiveSheet.Cells[i_row, i_col].Value = " ";
                            }
                        }

                        obj_list = data_list[i].GetList("OBJECT_LIST");
                        for (k = 0; k < obj_list.Count; k++)
                        {
                            s_temp = "";
                            if (rbtBaseOnMat.Checked == true)
                            {
                                s_temp = obj_list[k].GetString("MAT_ID") + " (" + obj_list[k].GetInt("MAT_VER") + ")";
                            }
                            else if (rbtBaseOnOper.Checked == true)
                            {
                                s_temp = obj_list[k].GetString("OPER");
                            }

                            for (i_col = spdSortCol.ActiveSheet.ColumnCount; i_col < spdData.ActiveSheet.ColumnCount; i_col++)
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i_col].Value) == s_temp)
                                {
                                    break;
                                }
                            }
                            if (i_col >= spdData.ActiveSheet.ColumnCount) continue;

                            s_temp = "";
                            if (obj_list[k].GetChar("SPEC_REF_TYPE") == 'M')
                            {
                                s_temp = MPCF.GetSpecInfo(obj_list[k].GetString("UPPER_SPEC_LIMIT"),
                                                          obj_list[k].GetString("LOWER_SPEC_LIMIT"),
                                                          obj_list[k].GetString("TARGET_VALUE"));

                            }
                            else if (obj_list[k].GetChar("SPEC_REF_TYPE") == 'C')
                            {
                                s_temp = MPCF.GetSpecInfo(obj_list[k].GetString("CUST_UPPER_SPEC_LIMIT"),
                                                          obj_list[k].GetString("CUST_LOWER_SPEC_LIMIT"),
                                                          obj_list[k].GetString("CUST_TARGET_VALUE"));

                            }
                            spdData.ActiveSheet.Cells[i_row, i_col].Value = s_temp;
                        }//end for object list
                    }//end for data list

                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                } while (in_node.GetInt("NEXT_SEQ") > 0);

                MPCF.FitColumnHeader(spdData, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public virtual Control GetFirstFocusItem()
        {
            try
            {
                return this.udcMatID1;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmSPMCompareSpecValue_Activated(object sender, EventArgs e)
        {
            int i;
            string s_caption;

            try
            {
                if (b_load_flag == false)
                {
                    spdData.ActiveSheet.ColumnCount = 0;
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

                    spdData.ActiveSheet.SetColumnAllowAutoSort(0, spdData.ActiveSheet.ColumnCount, true);
                    MPCF.FitColumnHeader(spdData);

                    rbtBaseOnMat.Checked = true;

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
            pnlViewTop.Height = 186;
        }

        private void btnToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                sfdPDF.Filter = "PDF Files | *.pdf";
                sfdPDF.FileName = "comparison1";
                if (sfdPDF.ShowDialog() == DialogResult.OK)
                {
                    FarPoint.Win.Spread.PrintInfo printset = new FarPoint.Win.Spread.PrintInfo();
                    printset.Header = "/c /fu1 /fn\"Microsoft Sans Serif\" /fz\"20\" The Compare specification Values/n /fu0 /r /ds /ts";
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
            if (rbtBaseOnMat.Checked == true)
            {
                if (MPCF.Trim(udcMatID1.Text) == "" &&
                    MPCF.Trim(udcMatID2.Text) == "" &&
                    MPCF.Trim(udcMatID3.Text) == "" &&
                    MPCF.Trim(udcMatID4.Text) == "" &&
                    MPCF.Trim(udcMatID5.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udcMatID1.Focus();
                    return;
                }
            }
            else if (rbtBaseOnOper.Checked == true)
            {
                if (MPCF.Trim(udcOper1.Text) == "" &&
                    MPCF.Trim(udcOper2.Text) == "" &&
                    MPCF.Trim(udcOper3.Text) == "" &&
                    MPCF.Trim(udcOper4.Text) == "" &&
                    MPCF.Trim(udcOper5.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udcOper1.Focus();
                    return;
                }
            }

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

        private void rbtBaseOnMat_CheckedChanged(object sender, EventArgs e)
        {
            int i;

            if (rbtBaseOnMat.Checked == true)
            {
                for (i = 0; i < spdSortCol.ActiveSheet.ColumnCount; i++)
                {
                    if (MPCF.Trim(spdSortCol.ActiveSheet.Cells[0, i].Value) == "OPER")
                    {
                        spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].Value = true;
                        MPCF.FitColumnHeader(spdSortCol, i, i);
                    }

                    if (MPCF.Trim(spdSortCol.ActiveSheet.Cells[0, i].Value) == "MAT_ID")
                    {
                        spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].Value = false;
                        spdSortCol.ActiveSheet.Columns[i].Width = 0;
                    }
                    if (MPCF.Trim(spdSortCol.ActiveSheet.Cells[0, i].Value) == "MAT_VER")
                    {
                        spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].Value = false;
                        spdSortCol.ActiveSheet.Columns[i].Width = 0;
                    }
                }
            }
        }

        private void rbtBaseOnOper_CheckedChanged(object sender, EventArgs e)
        {
            int i;

            if (rbtBaseOnOper.Checked == true)
            {
                for (i = 0; i < spdSortCol.ActiveSheet.ColumnCount; i++)
                {
                    if (MPCF.Trim(spdSortCol.ActiveSheet.Cells[0, i].Value) == "MAT_ID")
                    {
                        spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].Value = true;
                        MPCF.FitColumnHeader(spdSortCol, i, i);
                    }
                    if (MPCF.Trim(spdSortCol.ActiveSheet.Cells[0, i].Value) == "MAT_VER")
                    {
                        spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].Value = true;
                        MPCF.FitColumnHeader(spdSortCol, i, i);
                    }

                    if (MPCF.Trim(spdSortCol.ActiveSheet.Cells[0, i].Value) == "OPER")
                    {
                        spdSortCol.ActiveSheet.ColumnHeader.Cells[0, i].Value = false;
                        spdSortCol.ActiveSheet.Columns[i].Width = 0;
                    }
                }
            }
        }

    
    }
}
