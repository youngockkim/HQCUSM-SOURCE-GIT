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

namespace Miracom.WIPCore
{
    public partial class frmWIPTranLossLotExt2 : TranForm23
    {
        public frmWIPTranLossLotExt2()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int COL_UNIT1_CRR_ID = 0;
        private const int COL_UNIT1_SLOT_NO = 1;
        private const int COL_UNIT1_SUBLOT = 2;
        private const int COL_UNIT1_GRADE = 3;
        private const int COL_UNIT1_GRADE_BTN = 4;
        private const int COL_UNIT1_LOSS = 5;
        private const int COL_UNIT1_LOSS_BTN = 6;

        private const int COL_UNIT23_CRR_ID = 0;
        private const int COL_UNIT23_SLOT_NO = 1;
        private const int COL_UNIT23_SUBLOT = 2;
        private const int COL_UNIT23_QTY = 3;
        private const int COL_UNIT23_LOSS_QTY = 4;
        private const int COL_UNIT23_REMAIN_QTY = 5;

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private string ms_loss_code_table;

        private class CRR_TAG
        {
            public string crr_id;
            public double qty_1;
            public double qty_2;
            public double qty_3;
        }

        private class CRRS_INFOR
        {
            public List<CRR_TAG> crrs;

            private int findCarrier(string s_crr_id)
            {
                if (crrs == null)
                {
                    crrs = new List<CRR_TAG>();
                }

                for (int i = 0; i < crrs.Count; i++)
                {
                    if (crrs[i].crr_id == s_crr_id)
                    {
                        return i;
                    }
                }

                return -1;
            }

            public void addCarrier(string s_crr_id, double d_qty_1, double d_qty_2, double d_qty_3)
            {
                int i_crr_index;

                i_crr_index = findCarrier(s_crr_id);
                if (i_crr_index < 0)
                {
                    CRR_TAG crr = new CRR_TAG();
                    crr.crr_id = s_crr_id;
                    crr.qty_1 = d_qty_1;
                    crr.qty_2 = d_qty_2;
                    crr.qty_3 = d_qty_3;

                    crrs.Add(crr);
                }
                else
                {
                    crrs[i_crr_index].qty_1 += d_qty_1;
                    crrs[i_crr_index].qty_2 += d_qty_2;
                    crrs[i_crr_index].qty_3 += d_qty_3;
                }
            }
        }

        private class LOSS_CODE_TAG
        {
            public string loss_code;
            public double loss_qty;
        }

        private class LOSS_CODES_INFOR
        {
            public List<LOSS_CODE_TAG> loss_codes;

            private int findLossCode(string s_loss_code)
            {
                if (loss_codes == null)
                {
                    loss_codes = new List<LOSS_CODE_TAG>();
                }

                for (int i = 0; i < loss_codes.Count; i++)
                {
                    if (loss_codes[i].loss_code == s_loss_code)
                    {
                        return i;
                    }
                }

                return -1;
            }

            public void addLossCode(string s_loss_code, double d_loss_qty)
            {
                int i_loss_index;

                i_loss_index = findLossCode(s_loss_code);
                if (i_loss_index < 0)
                {
                    LOSS_CODE_TAG loss = new LOSS_CODE_TAG();
                    loss.loss_code = s_loss_code;
                    loss.loss_qty = d_loss_qty;

                    loss_codes.Add(loss);
                }
                else
                {
                    loss_codes[i_loss_index].loss_qty += d_loss_qty;
                }
            }
        }

        private class SUBLOT_TAG
        {
            public string sublot_id;
            public int slot_no;
            public char grade;
            public string loss_code;
            public double out_qty_2;
            public double out_qty_3;

            public LOSS_CODES_INFOR unit1;
            public LOSS_CODES_INFOR unit2;
            public LOSS_CODES_INFOR unit3;

            public SUBLOT_TAG()
            {
                unit1 = new LOSS_CODES_INFOR();
                unit2 = new LOSS_CODES_INFOR();
                unit3 = new LOSS_CODES_INFOR();

                unit1.loss_codes = new List<LOSS_CODE_TAG>();
                unit2.loss_codes = new List<LOSS_CODE_TAG>();
                unit3.loss_codes = new List<LOSS_CODE_TAG>();
            }
        }

        private class SUBLOTS_INFOR
        {
            public List<SUBLOT_TAG> sublots;

            private int findSublot(string s_sublot_id)
            {
                if (sublots == null)
                {
                    sublots = new List<SUBLOT_TAG>();
                }

                for (int i = 0; i < sublots.Count; i++)
                {
                    if (sublots[i].sublot_id == s_sublot_id)
                    {
                        return i;
                    }
                }

                return -1;
            }

            public void addSublot(string s_sublot_id, int i_slot_no)
            {
                int i_sublot_index;

                i_sublot_index = findSublot(s_sublot_id);
                if (i_sublot_index < 0)
                {
                    SUBLOT_TAG sublot = new SUBLOT_TAG();
                    sublot.sublot_id = s_sublot_id;
                    sublot.slot_no = i_slot_no;

                    sublots.Add(sublot);
                }
            }

            public void setGrade(string s_sublot_id, char c_grade, string s_loss_code)
            {
                int i_sublot_index;

                i_sublot_index = findSublot(s_sublot_id);
                if (i_sublot_index >= 0)
                {
                    sublots[i_sublot_index].grade = c_grade;
                    sublots[i_sublot_index].loss_code = s_loss_code;
                }
            }

            public void setOutQty(string s_sublot_id, double d_out_qty_2, double d_out_qty_3)
            {
                int i_sublot_index;

                i_sublot_index = findSublot(s_sublot_id);
                if (i_sublot_index >= 0)
                {
                    sublots[i_sublot_index].out_qty_2 += d_out_qty_2;
                    sublots[i_sublot_index].out_qty_3 += d_out_qty_3;
                }
            }

            public void setUnit1LossCode(string s_sublot_id, string s_loss_code, double d_loss_qty)
            {
                int i_sublot_index;

                i_sublot_index = findSublot(s_sublot_id);
                if (i_sublot_index >= 0)
                {
                    sublots[i_sublot_index].unit1.addLossCode(s_loss_code, d_loss_qty);
                }
            }

            public void setUnit2LossCode(string s_sublot_id, string s_loss_code, double d_loss_qty)
            {
                int i_sublot_index;

                i_sublot_index = findSublot(s_sublot_id);
                if (i_sublot_index >= 0)
                {
                    sublots[i_sublot_index].unit2.addLossCode(s_loss_code, d_loss_qty);
                }
            }

            public void setUnit3LossCode(string s_sublot_id, string s_loss_code, double d_loss_qty)
            {
                int i_sublot_index;

                i_sublot_index = findSublot(s_sublot_id);
                if (i_sublot_index >= 0)
                {
                    sublots[i_sublot_index].unit3.addLossCode(s_loss_code, d_loss_qty);
                }
            }

        }

        #endregion

        #region " Function Definition "

        protected override void ClearData(int i_case)
        {
            switch (i_case)
            {
                case 1:
                    base.ClearData(1);

                    MPCF.ClearList(spdUnit1);
                    MPCF.ClearList(spdUnit2);
                    MPCF.ClearList(spdUnit3);
                    break;
            }
        }

        protected override bool ViewLotInfo(string s_lot_id)
        {
            base.ClearData(1);

            if (base.ViewLotInfo(txtLotID.Text) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (MPGO.ProcessZeroQtyLot() == true)
                chkNoAutoTermLot.Checked = true;

            if (ViewSublotLotList() == false) return false;
            if (ViewLossCode() == false) return false;

            cdvResID.Text = LOT.GetString("START_RES_ID");

            return true;
        }

        protected override bool CheckCondition()
        {
            bool b_exist_loss_infor;

            if (base.CheckCondition() == false) return false;

            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return false;
            }
            if (MPCF.Trim(LOT.GetString("FLOW")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return false;
            }
            if (MPCF.Trim(LOT.GetString("OPER")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return false;
            }

            b_exist_loss_infor = false;

            if (spdUnit1.ActiveSheet.RowCount > 0)
            {
                int i;

                for (i = 0; i < spdUnit1.ActiveSheet.RowCount - 1; i++)
                {
                    if (MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Tag) == MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Value) &&
                        MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_LOSS].Tag) == MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_LOSS].Value))
                    {
                        continue;
                    }

                    if ((MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Tag) != MPGC.MP_SUBLOT_GOOD_GRADE ||
                         MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Value) != MPGC.MP_SUBLOT_GOOD_GRADE) &&
                        MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_LOSS].Value) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(237));
                        tabTran.SelectedTab = tbpUnit1;
                        spdUnit1.ActiveSheet.SetActiveCell(i, COL_UNIT1_LOSS);
                        return false;
                    }
                    if (MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_LOSS].Value) != "" && MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Value) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(240));
                        tabTran.SelectedTab = tbpUnit1;
                        spdUnit1.ActiveSheet.SetActiveCell(i, COL_UNIT1_GRADE);
                        return false;
                    }

                    if (MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Value) == MPGC.MP_SUBLOT_SCRAP_GRADE)
                    {
                        string s_sublot_id = MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_SUBLOT].Value);
                        int k;

                        for (k = 0; k < spdUnit2.ActiveSheet.RowCount - 1; k++)
                        {
                            if (MPCF.ToInt(spdUnit2.ActiveSheet.Cells[k, COL_UNIT23_QTY].Value) > 0 &&
                                MPCF.Trim(spdUnit2.ActiveSheet.Rows[k].Tag) == "S" && 
                                MPCF.Trim(spdUnit2.ActiveSheet.Cells[k, COL_UNIT23_SUBLOT].Value) == s_sublot_id)
                            {
                                if (chkSameCodeToUnit23.Checked == false)
                                {
                                    if (MPCF.ToInt(spdUnit2.ActiveSheet.Cells[k, COL_UNIT23_REMAIN_QTY].Value) > 0)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                        tabTran.SelectedTab = tbpUnit2;
                                        spdUnit2.ActiveSheet.SetActiveCell(k, COL_UNIT23_REMAIN_QTY + 1);
                                        spdUnit2.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);
                                        spdUnit2.Focus();
                                        return false;
                                    }
                                }

                                break;
                            }
                        }

                        for (k = 0; k < spdUnit3.ActiveSheet.RowCount - 1; k++)
                        {
                            if (MPCF.ToInt(spdUnit3.ActiveSheet.Cells[k, COL_UNIT23_QTY].Value) > 0 &&
                                MPCF.Trim(spdUnit3.ActiveSheet.Rows[k].Tag) == "S" &&
                                MPCF.Trim(spdUnit3.ActiveSheet.Cells[k, COL_UNIT23_SUBLOT].Value) == s_sublot_id)
                            {
                                if (chkSameCodeToUnit23.Checked == false)
                                {
                                    if (MPCF.ToInt(spdUnit3.ActiveSheet.Cells[k, COL_UNIT23_REMAIN_QTY].Value) > 0)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                        tabTran.SelectedTab = tbpUnit3;
                                        spdUnit3.ActiveSheet.SetActiveCell(k, COL_UNIT23_REMAIN_QTY + 1);
                                        spdUnit3.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);
                                        spdUnit3.Focus();
                                        return false;
                                    }
                                }

                                break;
                            }
                        }

                    }//end if

                    b_exist_loss_infor = true;
                }
            }

            if (spdUnit2.ActiveSheet.RowCount > 0)
            {
                if (MPCF.ToInt(spdUnit2.ActiveSheet.Cells[spdUnit2.ActiveSheet.RowCount - 1, COL_UNIT23_LOSS_QTY].Value) > 0)
                {
                    b_exist_loss_infor = true;
                }
            }

            if (spdUnit3.ActiveSheet.RowCount > 0)
            {
                if (MPCF.ToInt(spdUnit3.ActiveSheet.Cells[spdUnit3.ActiveSheet.RowCount - 1, COL_UNIT23_LOSS_QTY].Value) > 0)
                {
                    b_exist_loss_infor = true;
                }
            }

            if (b_exist_loss_infor == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107) + "\n" + MPCF.FindLanguage("Loss Information", CAPTION_TYPE.LABEL));
                return false;
            }

            return true;
        }

        private bool ViewSublotLotList()
        {
            int i;
            int i_row;
            bool b_exist_crr;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");
            List<TRSNode> l_sublot_list;

            try
            {
                MPCF.ClearList(spdUnit1);
                MPCF.ClearList(spdUnit2);
                MPCF.ClearList(spdUnit3);
                spdUnit1.ActiveSheet.ColumnCount = COL_UNIT1_LOSS_BTN + 1;
                spdUnit2.ActiveSheet.ColumnCount = COL_UNIT23_REMAIN_QTY + 1;
                spdUnit3.ActiveSheet.ColumnCount = COL_UNIT23_REMAIN_QTY + 1;

                b_exist_crr = false;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Sublot_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    l_sublot_list = out_node.GetList(0);
                    for (i = 0; i < l_sublot_list.Count; i++)
                    {
                        i_row = spdUnit1.ActiveSheet.RowCount;
                        spdUnit1.ActiveSheet.RowCount++;
                        spdUnit2.ActiveSheet.RowCount++;
                        spdUnit3.ActiveSheet.RowCount++;

                        spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_CRR_ID].Value = l_sublot_list[i].GetString("CRR_ID");
                        spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_SLOT_NO].Value = l_sublot_list[i].GetInt("SLOT_NO");
                        spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_SUBLOT].Value = l_sublot_list[i].GetString("SUBLOT_ID");
                        spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_GRADE].Value = l_sublot_list[i].GetChar("GRADE");
                        spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_GRADE].Tag = l_sublot_list[i].GetChar("GRADE");
                        spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_LOSS].Value = l_sublot_list[i].GetString("GRADE_CODE");
                        spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_LOSS].Tag = l_sublot_list[i].GetString("GRADE_CODE");

                        spdUnit2.ActiveSheet.Cells[i_row, COL_UNIT23_CRR_ID].Value = l_sublot_list[i].GetString("CRR_ID");
                        spdUnit2.ActiveSheet.Cells[i_row, COL_UNIT23_SLOT_NO].Value = l_sublot_list[i].GetInt("SLOT_NO");
                        spdUnit2.ActiveSheet.Cells[i_row, COL_UNIT23_SUBLOT].Value = l_sublot_list[i].GetString("SUBLOT_ID");
                        spdUnit2.ActiveSheet.Cells[i_row, COL_UNIT23_QTY].Value = l_sublot_list[i].GetDouble("QTY_2");

                        spdUnit3.ActiveSheet.Cells[i_row, COL_UNIT23_CRR_ID].Value = l_sublot_list[i].GetString("CRR_ID");
                        spdUnit3.ActiveSheet.Cells[i_row, COL_UNIT23_SLOT_NO].Value = l_sublot_list[i].GetInt("SLOT_NO");
                        spdUnit3.ActiveSheet.Cells[i_row, COL_UNIT23_SUBLOT].Value = l_sublot_list[i].GetString("SUBLOT_ID");
                        spdUnit3.ActiveSheet.Cells[i_row, COL_UNIT23_QTY].Value = l_sublot_list[i].GetDouble("QTY_3");

                        if (l_sublot_list[i].GetString("CRR_ID") != "")
                        {
                            b_exist_crr = true;
                        }
                    }

                    in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                    in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
                } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

                if (b_exist_crr == true)
                {
                    spdUnit1.ActiveSheet.Columns[COL_UNIT1_CRR_ID].Width = 60;
                    spdUnit1.ActiveSheet.Columns[COL_UNIT1_CRR_ID].Resizable = true;
                    spdUnit1.ActiveSheet.Columns[COL_UNIT1_CRR_ID].Visible = true;

                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Width = 60;
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Resizable = true;
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Visible = true;

                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Width = 60;
                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Resizable = true;
                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Visible = true;
                }
                else
                {
                    spdUnit1.ActiveSheet.Columns[COL_UNIT1_CRR_ID].Width = 0;
                    spdUnit1.ActiveSheet.Columns[COL_UNIT1_CRR_ID].Resizable = false;
                    spdUnit1.ActiveSheet.Columns[COL_UNIT1_CRR_ID].Visible = false;

                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Width = 0;
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Resizable = false;
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Visible = false;

                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Width = 0;
                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Resizable = false;
                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Visible = false;
                }

                if (spdUnit1.ActiveSheet.RowCount < 1)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewLossCode()
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");
            ListView lis_loss_code;
            int i;
            int i_col;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT_1") == "")
            {
                if (tabTran.TabPages.Contains(tbpUnit1) == true)
                {
                    tabTran.TabPages.Remove(tbpUnit1);
                }
            }
            else
            {
                if (tabTran.TabPages.Contains(tbpUnit1) == false)
                {
                    tabTran.TabPages.Insert(1, tbpUnit1);
                }
            }
            if (out_node.GetString("UNIT_2") == "")
            {
                if (tabTran.TabPages.Contains(tbpUnit2) == true)
                {
                    tabTran.TabPages.Remove(tbpUnit2);
                }
            }
            else
            {
                if (tabTran.TabPages.Contains(tbpUnit2) == false)
                {
                    if (tabTran.TabPages.Contains(tbpUnit1) == true)
                    {
                        tabTran.TabPages.Insert(2, tbpUnit2);
                    }
                    else
                    {
                        tabTran.TabPages.Insert(1, tbpUnit2);
                    }
                }
            }
            if (out_node.GetString("UNIT_3") == "")
            {
                if (tabTran.TabPages.Contains(tbpUnit3) == true)
                {
                    tabTran.TabPages.Remove(tbpUnit3);
                }
            }
            else
            {
                if (tabTran.TabPages.Contains(tbpUnit3) == false)
                {
                    if (tabTran.TabPages.Contains(tbpUnit1) == true &&
                        tabTran.TabPages.Contains(tbpUnit2) == true)
                    {
                        tabTran.TabPages.Insert(3, tbpUnit3);
                    }
                    else if (tabTran.TabPages.Contains(tbpUnit1) == false &&
                             tabTran.TabPages.Contains(tbpUnit2) == false)
                    {
                        tabTran.TabPages.Insert(1, tbpUnit3);
                    }
                    else
                    {
                        tabTran.TabPages.Insert(2, tbpUnit3);
                    }
                }
            }


            ms_loss_code_table = "";
            ms_loss_code_table = MPCR.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOSS_TBL_DEF);
            if (ms_loss_code_table == "")
            {
                ms_loss_code_table = out_node.GetString("LOSS_TBL");
            }

            if (ms_loss_code_table == "")
            {
                return true;
            }

            lis_loss_code = new ListView();
            lis_loss_code.Columns.Add("Loss Code");             // 0
            lis_loss_code.Columns.Add("Desc");                  // 1
            lis_loss_code.Columns.Add("Reusable Type");         // 2

            MPCF.InitListView(lis_loss_code);

            if (BASLIST.ViewGCMDataList(lis_loss_code, '1', ms_loss_code_table) == false)
            {
                return false;
            }

            FarPoint.Win.Spread.CellType.CheckBoxCellType chkCell;
            FarPoint.Win.Spread.CellType.NumberCellType numCell;

            for (i = 0; i < lis_loss_code.Items.Count; i++)
            {
                i_col = spdUnit1.ActiveSheet.ColumnCount;
                spdUnit1.ActiveSheet.ColumnCount++;
                spdUnit1.ActiveSheet.ColumnHeader.Cells[1, i_col].Value = lis_loss_code.Items[i].SubItems[0].Text; // Code
                spdUnit1.ActiveSheet.Columns[i_col].Tag = lis_loss_code.Items[i];
                spdUnit1.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;

                chkCell = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                spdUnit1.ActiveSheet.Columns[i_col].CellType = chkCell;
                spdUnit1.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                i_col = spdUnit2.ActiveSheet.ColumnCount;
                spdUnit2.ActiveSheet.ColumnCount++;
                spdUnit2.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = lis_loss_code.Items[i].SubItems[0].Text; // Code
                spdUnit2.ActiveSheet.Columns[i_col].Tag = lis_loss_code.Items[i];
                numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCell.DecimalPlaces = 0;
                numCell.MinimumValue = 0;
                numCell.ShowSeparator = true;
                spdUnit2.ActiveSheet.Columns[i_col].CellType = numCell;
                spdUnit2.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdUnit2.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;

                i_col = spdUnit3.ActiveSheet.ColumnCount;
                spdUnit3.ActiveSheet.ColumnCount++;
                spdUnit3.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = lis_loss_code.Items[i].SubItems[0].Text; // Code
                spdUnit3.ActiveSheet.Columns[i_col].Tag = lis_loss_code.Items[i];
                numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCell.DecimalPlaces = 0;
                numCell.MinimumValue = 0;
                numCell.ShowSeparator = true;
                spdUnit3.ActiveSheet.Columns[i_col].CellType = numCell;
                spdUnit3.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdUnit3.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            }

            if (lis_loss_code.Items.Count > 0)
            {
                i_col = spdUnit2.ActiveSheet.ColumnCount - COL_UNIT23_REMAIN_QTY;

                spdUnit1.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
                spdUnit2.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
                spdUnit3.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;

                for (i = 0; i < spdUnit2.ActiveSheet.RowCount; i++)
                {
                    spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_LOSS_QTY].Formula = "SUM(RC[2]:RC[" + i_col.ToString() + "])";
                    spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY].Formula = "RC[-2]-RC[-1]";

                    spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_LOSS_QTY].Formula = "SUM(RC[2]:RC[" + i_col.ToString() + "])";
                    spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY].Formula = "RC[-2]-RC[-1]";
                }

                if (spdUnit1.ActiveSheet.RowCount > 0)
                {
                    int i_row;

                    spdUnit1.ActiveSheet.ColumnHeader.Cells[0, COL_UNIT1_LOSS_BTN + 1].ColumnSpan = lis_loss_code.Items.Count;
                    spdUnit1.ActiveSheet.ColumnHeader.Cells[0, COL_UNIT1_LOSS_BTN + 1].Value = MPCF.FindLanguage("Additional Reason Code", CAPTION_TYPE.LABEL);

                    i_row = spdUnit1.ActiveSheet.RowCount;
                    spdUnit1.ActiveSheet.RowCount++;

                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 0;
                    numCell.MinimumValue = 0;
                    numCell.ShowSeparator = true;
                    spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_SUBLOT].CellType = numCell;

                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 0;
                    numCell.MinimumValue = 0;
                    numCell.ShowSeparator = true;
                    spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_GRADE].ColumnSpan = 2;
                    spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_GRADE].CellType = numCell;

                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 0;
                    numCell.MinimumValue = 0;
                    numCell.ShowSeparator = true;
                    spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_LOSS].ColumnSpan = 2;
                    spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_LOSS].CellType = numCell;

                    int i_from = i_row * -1;

                    spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_SLOT_NO].Value = MPCF.FindLanguage("Total", CAPTION_TYPE.LABEL);
                    spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_SUBLOT].Formula = "ROWS(R[" + i_from.ToString() + "]C:R[-1]C)"; // Sublot Count
                    spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_GRADE].Formula = "COUNTIF(R[" + i_from.ToString() + "]C:R[-1]C, \"S\")"; // Number of Scrap
                    spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_LOSS].Formula = "RC[-3]-RC[-2]"; // Out Qty
                    for (i = 0; i < lis_loss_code.Items.Count; i++)
                    {
                        numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                        numCell.DecimalPlaces = 0;
                        numCell.MinimumValue = 0;
                        numCell.ShowSeparator = true;
                        spdUnit1.ActiveSheet.Cells[i_row, i + COL_UNIT1_LOSS_BTN + 1].CellType = numCell;
                        //spdUnit1.ActiveSheet.Cells[i_row, i + COL_UNIT1_LOSS_BTN + 1].Formula = "COUNTIF(R[" + i_from.ToString() + "]C:R[-1]C, TRUE)"; // Number of Loss Code
                    }
                    spdUnit1.ActiveSheet.Rows[i_row].Locked = true;
                    spdUnit1.ActiveSheet.Rows[i_row].BackColor = Color.Yellow;
                    spdUnit1.ActiveSheet.Rows[i_row].Font = new Font(spdUnit1.Font, FontStyle.Bold);
                    spdUnit1.ActiveSheet.Rows[i_row].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdUnit1.ActiveSheet.Rows[i_row].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdUnit1.ActiveSheet.FrozenTrailingRowCount = 1;
                }

                if (spdUnit2.ActiveSheet.RowCount > 0)
                {
                    int i_row;

                    i_row = spdUnit2.ActiveSheet.RowCount;
                    spdUnit2.ActiveSheet.RowCount++;
                    spdUnit3.ActiveSheet.RowCount++;

                    int i_from = i_row * -1;

                    spdUnit2.ActiveSheet.Cells[i_row, COL_UNIT23_SLOT_NO].Value = MPCF.FindLanguage("Total", CAPTION_TYPE.LABEL);
                    spdUnit2.ActiveSheet.Cells[i_row, COL_UNIT23_SUBLOT].Formula = "ROWS(R[" + i_from.ToString() + "]C:R[-1]C)"; // Sublot Count
                    for (i = 0; i < lis_loss_code.Items.Count + COL_UNIT23_QTY; i++)
                    {
                        spdUnit2.ActiveSheet.Cells[i_row, i + COL_UNIT23_QTY].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)"; // Sum of QTY
                    }
                    spdUnit2.ActiveSheet.Rows[i_row].Locked = true;
                    spdUnit2.ActiveSheet.Rows[i_row].BackColor = Color.Yellow;
                    spdUnit2.ActiveSheet.Rows[i_row].Font = new Font(spdUnit2.Font, FontStyle.Bold);
                    spdUnit2.ActiveSheet.Rows[i_row].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdUnit2.ActiveSheet.Rows[i_row].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdUnit2.ActiveSheet.FrozenTrailingRowCount = 1;

                    spdUnit3.ActiveSheet.Cells[i_row, COL_UNIT23_SLOT_NO].Value = MPCF.FindLanguage("Total", CAPTION_TYPE.LABEL);
                    spdUnit3.ActiveSheet.Cells[i_row, COL_UNIT23_SUBLOT].Formula = "ROWS(R[" + i_from.ToString() + "]C:R[-1]C)"; // Sublot Count
                    for (i = 0; i < lis_loss_code.Items.Count + COL_UNIT23_QTY; i++)
                    {
                        spdUnit3.ActiveSheet.Cells[i_row, i + COL_UNIT23_QTY].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)"; // Sum of QTY
                    }
                    spdUnit3.ActiveSheet.Rows[i_row].Locked = true;
                    spdUnit3.ActiveSheet.Rows[i_row].BackColor = Color.Yellow;
                    spdUnit3.ActiveSheet.Rows[i_row].Font = new Font(spdUnit3.Font, FontStyle.Bold);
                    spdUnit3.ActiveSheet.Rows[i_row].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdUnit3.ActiveSheet.Rows[i_row].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdUnit3.ActiveSheet.FrozenTrailingRowCount = 1;
                }
            }

            MPCF.FitColumnHeader(spdUnit1, true);
            MPCF.FitColumnHeader(spdUnit2);
            MPCF.FitColumnHeader(spdUnit3);

            return true;
        }

        private bool LossLot()
        {
            TRSNode in_node = new TRSNode("LOSS_LOT_EXT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("CAUSE_FLOW", MPCF.Trim(cdvCauseFlow.Text));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(cdvCauseOper.Text));
                in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));
                in_node.AddString("CHECK_USER_1", MPCF.Trim(txtChkUser1.Text), true);
                in_node.AddString("CHECK_USER_2", MPCF.Trim(txtChkUser2.Text), true);
                in_node.AddString("CHECK_USER_3", MPCF.Trim(txtChkUser3.Text), true);

                in_node.AddDouble("OUT_QTY_1", MPCF.ToDbl(spdUnit1.ActiveSheet.Cells[spdUnit1.ActiveSheet.RowCount - 1, COL_UNIT1_LOSS].Value));
                in_node.AddDouble("OUT_QTY_2", MPCF.ToDbl(spdUnit2.ActiveSheet.Cells[spdUnit2.ActiveSheet.RowCount - 1, COL_UNIT23_REMAIN_QTY].Value));
                in_node.AddDouble("OUT_QTY_3", MPCF.ToDbl(spdUnit3.ActiveSheet.Cells[spdUnit3.ActiveSheet.RowCount - 1, COL_UNIT23_REMAIN_QTY].Value));

                in_node.AddString("LOT_TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("LOT_TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("LOT_TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("LOT_TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("LOT_TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("LOT_TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("LOT_TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("LOT_TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("LOT_TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("LOT_TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("LOT_TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("LOT_TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("LOT_TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("LOT_TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("LOT_TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("LOT_TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("LOT_TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("LOT_TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("LOT_TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("LOT_TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddString("LOSS_COMMENT", MPCF.Trim(txtLossComment.Text));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');


                if (SetCarrierInfor(in_node) == false) return false;
                if (SetUnit1LossInfor(in_node) == false) return false;
                if (SetUnit2LossInfor(in_node) == false) return false;
                if (SetUnit3LossInfor(in_node) == false) return false;
                if (SetSublotInfor(in_node) == false) return false;


                if (MPCR.CallService("WIP", "WIP_Loss_Lot_Ext", in_node, ref out_node) == false)
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

        private bool SetCarrierInfor(TRSNode in_node)
        {
            CRRS_INFOR clsCrrs;
            int i;
            string s_crr_id;
            int i_remain_qty;

            TRSNode crr_node;

            clsCrrs = new CRRS_INFOR();

            for (i = 0; i < spdUnit1.ActiveSheet.RowCount - 1; i++)
            {
                s_crr_id = MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_CRR_ID].Value);
                if (s_crr_id != "" && MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Value) != MPGC.MP_SUBLOT_SCRAP_GRADE)
                {
                    clsCrrs.addCarrier(s_crr_id, 1, 0, 0);
                }
            }

            if (clsCrrs.crrs == null || clsCrrs.crrs.Count < 1)
            {
                return true;
            }

            for (i = 0; i < spdUnit2.ActiveSheet.RowCount - 1; i++)
            {
                s_crr_id = MPCF.Trim(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_CRR_ID].Value);
                i_remain_qty = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY].Value);
                if (s_crr_id != "" && i_remain_qty > 0)
                {
                    clsCrrs.addCarrier(s_crr_id, 0, i_remain_qty, 0);
                }
            }

            for (i = 0; i < spdUnit3.ActiveSheet.RowCount - 1; i++)
            {
                s_crr_id = MPCF.Trim(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_CRR_ID].Value);
                i_remain_qty = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY].Value);
                if (s_crr_id != "" && i_remain_qty > 0)
                {
                    clsCrrs.addCarrier(s_crr_id, 0, 0, i_remain_qty);
                }
            }

            for (i = 0; i < clsCrrs.crrs.Count; i++)
            {
                crr_node = in_node.AddNode("CRR_LIST");

                crr_node.AddString("CRR_ID", clsCrrs.crrs[i].crr_id);
                crr_node.AddDouble("CRR_QTY_1", clsCrrs.crrs[i].qty_1);
                crr_node.AddDouble("CRR_QTY_2", clsCrrs.crrs[i].qty_2);
                crr_node.AddDouble("CRR_QTY_3", clsCrrs.crrs[i].qty_3);

                if (i == 0)
                {
                    in_node.AddString("CRR_ID", clsCrrs.crrs[i].crr_id);
                }
            }

            return true;
        }

        private bool SetUnit1LossInfor(TRSNode in_node)
        {
            LOSS_CODES_INFOR clsLossCodes;
            int i;
            string s_loss_code;

            TRSNode unit_node;

            clsLossCodes = new LOSS_CODES_INFOR();

            for (i = 0; i < spdUnit1.ActiveSheet.RowCount - 1; i++)
            {
                s_loss_code = MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_LOSS].Value);
                if (s_loss_code != "" && MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Value) == MPGC.MP_SUBLOT_SCRAP_GRADE)
                {
                    clsLossCodes.addLossCode(s_loss_code, 1);
                }
            }

            if (clsLossCodes.loss_codes != null)
            {
                for (i = 0; i < clsLossCodes.loss_codes.Count; i++)
                {
                    unit_node = in_node.AddNode("UNIT1");

                    unit_node.AddString("CODE", clsLossCodes.loss_codes[i].loss_code);
                    unit_node.AddDouble("QTY", clsLossCodes.loss_codes[i].loss_qty);
                }
            }

            return true;
        }

        private bool SetUnit2LossInfor(TRSNode in_node)
        {
            int i;
            string s_loss_code;
            int i_loss_qty;
            TRSNode unit_node;

            for (i = COL_UNIT23_REMAIN_QTY + 1; i < spdUnit2.ActiveSheet.ColumnCount; i++)
            {
                s_loss_code = MPCF.Trim(spdUnit2.ActiveSheet.ColumnHeader.Cells[0, i].Value);
                i_loss_qty = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[spdUnit2.ActiveSheet.RowCount - 1, i].Value);
                if (i_loss_qty > 0)
                {
                    unit_node = in_node.AddNode("UNIT2");

                    unit_node.AddString("CODE", s_loss_code);
                    unit_node.AddDouble("QTY", i_loss_qty);
                }
            }

            return true;
        }

        private bool SetUnit3LossInfor(TRSNode in_node)
        {
            int i;
            string s_loss_code;
            int i_loss_qty;
            TRSNode unit_node;

            for (i = COL_UNIT23_REMAIN_QTY + 1; i < spdUnit3.ActiveSheet.ColumnCount; i++)
            {
                s_loss_code = MPCF.Trim(spdUnit3.ActiveSheet.ColumnHeader.Cells[0, i].Value);
                i_loss_qty = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[spdUnit3.ActiveSheet.RowCount - 1, i].Value);
                if (i_loss_qty > 0)
                {
                    unit_node = in_node.AddNode("UNIT3");

                    unit_node.AddString("CODE", s_loss_code);
                    unit_node.AddDouble("QTY", i_loss_qty);
                }
            }

            return true;
        }

        private bool SetSublotInfor(TRSNode in_node)
        {
            SUBLOTS_INFOR clsSublots;
            int i;
            int k;
            string s_sublot_id;
            int i_slot_no;
            string s_loss_code;
            char c_grade;
            int i_out_qty;
            int i_loss_qty;

            TRSNode sublot_node;
            TRSNode unit_node;

            clsSublots = new SUBLOTS_INFOR();

            for (i = 0; i < spdUnit1.ActiveSheet.RowCount - 1; i++)
            {
                s_sublot_id = MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_SUBLOT].Value);
                i_slot_no = MPCF.ToInt(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_SLOT_NO].Value);
                s_loss_code = MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_LOSS].Value);
                c_grade = MPCF.ToChar(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Value);

                if (c_grade != MPCF.ToChar(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Tag) ||
                    s_loss_code != MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_LOSS].Tag))
                {
                    clsSublots.addSublot(s_sublot_id, i_slot_no);
                    clsSublots.setGrade(s_sublot_id, c_grade, s_loss_code);

                    for (k = COL_UNIT1_LOSS_BTN + 1; k < spdUnit1.ActiveSheet.ColumnCount; k++)
                    {
                        if (spdUnit1.ActiveSheet.Cells[i, k].Value != null && ((bool)spdUnit1.ActiveSheet.Cells[i, k].Value) == true)
                        {
                            s_loss_code = MPCF.Trim(spdUnit1.ActiveSheet.ColumnHeader.Cells[1, k].Value);
                            clsSublots.setUnit1LossCode(s_sublot_id, s_loss_code, 0);
                        }
                    }
                }
            }

            for (i = 0; i < spdUnit2.ActiveSheet.RowCount - 1; i++)
            {
                s_sublot_id = MPCF.Trim(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value);
                i_out_qty = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY].Value);

                clsSublots.setOutQty(s_sublot_id, i_out_qty, 0);
            }

            for (i = 0; i < spdUnit3.ActiveSheet.RowCount - 1; i++)
            {
                s_sublot_id = MPCF.Trim(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value);
                i_out_qty = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY].Value);

                clsSublots.setOutQty(s_sublot_id, 0, i_out_qty);
            }


            for (i = 0; i < spdUnit2.ActiveSheet.RowCount - 1; i++)
            {
                s_sublot_id = MPCF.Trim(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value);
                i_slot_no = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_SLOT_NO].Value);
                i_out_qty = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY].Value);

                for (k = COL_UNIT23_REMAIN_QTY + 1; k < spdUnit2.ActiveSheet.ColumnCount; k++)
                {
                    s_loss_code = MPCF.Trim(spdUnit2.ActiveSheet.ColumnHeader.Cells[0, k].Value);
                    i_loss_qty = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, k].Value);

                    if (i_loss_qty > 0)
                    {
                        if (i_out_qty > -9999999)
                        {
                            clsSublots.addSublot(s_sublot_id, i_slot_no);
                            clsSublots.setOutQty(s_sublot_id, i_out_qty, 0);
                            i_out_qty = -9999999;
                        }

                        clsSublots.setUnit2LossCode(s_sublot_id, s_loss_code, i_loss_qty);
                    }
                }
            }

            for (i = 0; i < spdUnit3.ActiveSheet.RowCount - 1; i++)
            {
                s_sublot_id = MPCF.Trim(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value);
                i_slot_no = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_SLOT_NO].Value);
                i_out_qty = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY].Value);

                for (k = COL_UNIT23_REMAIN_QTY + 1; k < spdUnit3.ActiveSheet.ColumnCount; k++)
                {
                    s_loss_code = MPCF.Trim(spdUnit3.ActiveSheet.ColumnHeader.Cells[0, k].Value);
                    i_loss_qty = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, k].Value);

                    if (i_loss_qty > 0)
                    {
                        if (i_out_qty > -9999999)
                        {
                            clsSublots.addSublot(s_sublot_id, i_slot_no);
                            clsSublots.setOutQty(s_sublot_id, 0, i_out_qty);
                            i_out_qty = -9999999;
                        }

                        clsSublots.setUnit3LossCode(s_sublot_id, s_loss_code, i_loss_qty);
                    }
                }
            }

            for (i = 0; i < clsSublots.sublots.Count; i++)
            {
                sublot_node = in_node.AddNode("SUBLOT");

                sublot_node.AddString("SUBLOT_ID", clsSublots.sublots[i].sublot_id);
                sublot_node.AddInt("SLOT_NO", clsSublots.sublots[i].slot_no);
                sublot_node.AddDouble("OUT_QTY_2", clsSublots.sublots[i].out_qty_2);
                sublot_node.AddDouble("OUT_QTY_3", clsSublots.sublots[i].out_qty_3);
                sublot_node.AddChar("GRADE", clsSublots.sublots[i].grade);
                sublot_node.AddString("LOSS_CODE", clsSublots.sublots[i].loss_code);

                for (k = 0; k < clsSublots.sublots[i].unit1.loss_codes.Count; k++)
                {
                    unit_node = sublot_node.AddNode("REASON");
                    unit_node.AddString("REASON_CODE", clsSublots.sublots[i].unit1.loss_codes[k].loss_code);
                }

                for (k = 0; k < clsSublots.sublots[i].unit2.loss_codes.Count; k++)
                {
                    unit_node = sublot_node.AddNode("UNIT2");
                    unit_node.AddString("CODE", clsSublots.sublots[i].unit2.loss_codes[k].loss_code);
                    unit_node.AddDouble("QTY", clsSublots.sublots[i].unit2.loss_codes[k].loss_qty);
                }
                for (k = 0; k < clsSublots.sublots[i].unit3.loss_codes.Count; k++)
                {
                    unit_node = sublot_node.AddNode("UNIT3");
                    unit_node.AddString("CODE", clsSublots.sublots[i].unit3.loss_codes[k].loss_code);
                    unit_node.AddDouble("QTY", clsSublots.sublots[i].unit3.loss_codes[k].loss_qty);
                }
            }

            return true;
        }


        #endregion

        private void frmWIPTranLossLotExt2_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    tabTran.TabPages.Remove(tbpCMF);
                    tabTran.TabPages.Add(tbpCMF);

                    SetCMFItem(MPGC.MP_CMF_TRN_LOSS);

                    ClearData(1);
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
                    }
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvCauseRes_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                if (txtLotID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLotID.Focus();
                    return;
                }
                if (cdvCauseOper.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvCauseOper.Focus();
                    return;
                }

                cdvCauseRes.Init();
                cdvCauseRes.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvCauseRes.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseRes.SelectedSubItemIndex = 0;
#if _RAS
                if (RASLIST.ViewResourceList(cdvCauseRes.GetListView, "%", 0, cdvCauseFlow.Text, cdvCauseOper.Text, false) == false)
                {
                    return;
                }
#endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                if (txtLotID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLotID.Focus();
                    return;
                }
                if (MPCF.Trim(LOT.GetString("OPER")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                    return;
                }

                cdvResID.Init();
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
#if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
                {
                    return;
                }
#endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        private void cdvCauseFlow_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                    return;
                }

                cdvCauseFlow.Init();
                cdvCauseFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvCauseFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseFlow.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewFlowList(cdvCauseFlow.GetListView, '1', "", 0, "", null, "") == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvCauseFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvCauseOper.Text = "";
        }

        private void cdvCauseOper_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                    return;
                }
                if (cdvCauseFlow.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvCauseFlow.Focus();
                    return;
                }

                cdvCauseOper.Init();
                cdvCauseOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvCauseOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseOper.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvCauseOper.GetListView, '2', "", 0, cdvCauseFlow.Text, "", null, "") == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvCauseOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvCauseRes.Text = "";
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition() == false) return;

                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_LOSS, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'B') == false) return;
                if (LossLot() == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_LOSS, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'A') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdUnit1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == COL_UNIT1_GRADE_BTN)
            {
                cdvGrade.Init();
                cdvGrade.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvGrade.GetListView);
                cdvGrade.Columns.Add("Grade", 50, HorizontalAlignment.Left);
                cdvGrade.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                BASLIST.ViewGCMDataList(cdvGrade.GetListView, '1', MPGC.MP_WIP_SUBLOT_GRADE);

                if (cdvGrade.Items.Count > 0)
                {
                    cdvGrade.InsertEmptyRow(0, 1);
                    if (cdvGrade.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
            }
            else if (e.Column == COL_UNIT1_LOSS_BTN)
            {
                cdvLossCode.Init();
                cdvLossCode.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvLossCode.GetListView);
                cdvLossCode.Columns.Add("Grade", 50, HorizontalAlignment.Left);
                cdvLossCode.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                BASLIST.ViewGCMDataList(cdvLossCode.GetListView, '1', ms_loss_code_table);

                if (cdvLossCode.Items.Count > 0)
                {
                    cdvLossCode.InsertEmptyRow(0, 1);
                    if (cdvLossCode.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
            }
            else if (e.Column > COL_UNIT1_LOSS_BTN)
            {
                if (MPCF.Trim(spdUnit1.ActiveSheet.Cells[e.Row, COL_UNIT1_LOSS].Value) == "")
                {
                    spdUnit1.ActiveSheet.Cells[e.Row, e.Column].Value = false;
                    return;
                }
                else
                {
                    if (MPCF.Trim(spdUnit1.ActiveSheet.ColumnHeader.Cells[1, e.Column].Value) == MPCF.Trim(spdUnit1.ActiveSheet.Cells[e.Row, COL_UNIT1_LOSS].Value))
                    {
                        spdUnit1.ActiveSheet.Cells[e.Row, e.Column].Value = false;
                        return;
                    }
                }

                int i;
                int i_sel_count;

                i_sel_count = 0;
                for (i = 0; i < spdUnit1.ActiveSheet.RowCount - 1; i++)
                {
                    if (spdUnit1.ActiveSheet.Cells[i, e.Column].Value != null && ((bool)spdUnit1.ActiveSheet.Cells[i, e.Column].Value) == true)
                    {
                        i_sel_count++;
                    }
                }

                spdUnit1.ActiveSheet.Cells[i, e.Column].Value = i_sel_count;
            }

        }

        private void spdUnit1_EditModeOff(object sender, EventArgs e)
        {
            int i_row = spdUnit1.ActiveSheet.ActiveRowIndex;
            int i_col = spdUnit1.ActiveSheet.ActiveColumnIndex;

            if (i_col == COL_UNIT1_GRADE)
            {
                int i;
                int m;
                string s_sublot_id = MPCF.Trim(spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_SUBLOT].Value);
                string s_loss_code = MPCF.Trim(spdUnit1.ActiveSheet.Cells[i_row, COL_UNIT1_LOSS].Value);

                if (MPCF.Trim(spdUnit1.ActiveSheet.Cells[i_row, i_col].Value) == MPGC.MP_SUBLOT_SCRAP_GRADE)
                {
                    for (i = 0; i < spdUnit2.ActiveSheet.RowCount - 1; i++)
                    {
                        if (MPCF.Trim(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value) == s_sublot_id)
                        {
                            if (chkSameCodeToUnit23.Checked == true)
                            {
                                spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit2.ActiveSheet.ColumnCount - 1].Value = null;
                                spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit2.ActiveSheet.ColumnCount - 1].Locked = true;

                                if (MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_QTY].Value) > 0)
                                {
                                    for (m = COL_UNIT23_REMAIN_QTY + 1; m < spdUnit2.ActiveSheet.ColumnCount; m++)
                                    {
                                        if (MPCF.Trim(spdUnit2.ActiveSheet.ColumnHeader.Cells[0, m].Value) == s_loss_code)
                                        {
                                            spdUnit2.ActiveSheet.Cells[i, m].Value = spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_QTY].Value;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit2.ActiveSheet.ColumnCount - 1].Locked = false;
                            }
                            spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit2.ActiveSheet.ColumnCount - 1].BackColor = Color.MistyRose;
                            spdUnit2.ActiveSheet.Rows[i].Tag = 'S';
                            break;
                        }
                    }
                    for (i = 0; i < spdUnit3.ActiveSheet.RowCount - 1; i++)
                    {
                        if (MPCF.Trim(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value) == s_sublot_id)
                        {
                            if (chkSameCodeToUnit23.Checked == true)
                            {
                                spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit3.ActiveSheet.ColumnCount - 1].Value = null;
                                spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit3.ActiveSheet.ColumnCount - 1].Locked = true;

                                if (MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_QTY].Value) > 0)
                                {
                                    for (m = COL_UNIT23_REMAIN_QTY + 1; m < spdUnit3.ActiveSheet.ColumnCount; m++)
                                    {
                                        if (MPCF.Trim(spdUnit3.ActiveSheet.ColumnHeader.Cells[0, m].Value) == s_loss_code)
                                        {
                                            spdUnit3.ActiveSheet.Cells[i, m].Value = spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_QTY].Value;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit2.ActiveSheet.ColumnCount - 1].Locked = false;
                            }
                            spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit3.ActiveSheet.ColumnCount - 1].BackColor = Color.MistyRose;
                            spdUnit3.ActiveSheet.Rows[i].Tag = 'S';
                            break;
                        }
                    }
                }
                else
                {
                    for (i = 0; i < spdUnit2.ActiveSheet.RowCount - 1; i++)
                    {
                        if (MPCF.Trim(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value) == s_sublot_id)
                        {
                            if (MPCF.Trim(spdUnit2.ActiveSheet.Rows[i].Tag) == "S")
                            {
                                spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit2.ActiveSheet.ColumnCount - 1].Value = null;
                                spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit2.ActiveSheet.ColumnCount - 1].Locked = false;
                                spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit2.ActiveSheet.ColumnCount - 1].BackColor = SystemColors.Window;
                                spdUnit2.ActiveSheet.Rows[i].Tag = null;
                            }
                            break;
                        }
                    }
                    for (i = 0; i < spdUnit3.ActiveSheet.RowCount - 1; i++)
                    {
                        if (MPCF.Trim(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value) == s_sublot_id)
                        {
                            if (MPCF.Trim(spdUnit3.ActiveSheet.Rows[i].Tag) == "S")
                            {
                                spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit3.ActiveSheet.ColumnCount - 1].Value = null;
                                spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit3.ActiveSheet.ColumnCount - 1].Locked = false;
                                spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit3.ActiveSheet.ColumnCount - 1].BackColor = SystemColors.Window;
                                spdUnit3.ActiveSheet.Rows[i].Tag = null;
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void cdvGrade_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdUnit1.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;
            spdUnit1.ActiveSheet.SetActiveCell(e.Row, e.Col - 1);
            spdUnit1_EditModeOff(null, null);
        }

        private void cdvLossCode_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdUnit1.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;

            for (int i = COL_UNIT1_LOSS_BTN + 1; i < spdUnit1.ActiveSheet.ColumnCount; i++)
            {
                if (e.SelectedItem.Text == "" || MPCF.Trim(spdUnit1.ActiveSheet.ColumnHeader.Cells[1, i].Value) == e.SelectedItem.Text)
                {
                    if (spdUnit1.ActiveSheet.Cells[e.Row, i].Value != null && ((bool)spdUnit1.ActiveSheet.Cells[e.Row, i].Value) == true)
                    {
                        spdUnit1.ActiveSheet.Cells[e.Row, i].Value = false;

                        int k;
                        int i_sel_count = 0;
                        for (k = 0; k < spdUnit1.ActiveSheet.RowCount - 1; k++)
                        {
                            if (spdUnit1.ActiveSheet.Cells[k, i].Value != null && ((bool)spdUnit1.ActiveSheet.Cells[k, i].Value) == true)
                            {
                                i_sel_count++;
                            }
                        }

                        spdUnit1.ActiveSheet.Cells[k, i].Value = i_sel_count;
                    }
                }
            }

            if (MPCF.Trim(spdUnit1.ActiveSheet.Cells[e.Row, COL_UNIT1_GRADE].Value) == MPGC.MP_SUBLOT_SCRAP_GRADE)
            {
                spdUnit1.ActiveSheet.SetActiveCell(e.Row, COL_UNIT1_GRADE);
                spdUnit1_EditModeOff(null, null);
            }
        }

        private void chkSameCodeToUnit23_CheckedChanged(object sender, EventArgs e)
        {
            int i;

            for(i = 0; i < spdUnit1.ActiveSheet.RowCount - 1; i++)
            {
                if (MPCF.Trim(spdUnit1.ActiveSheet.Cells[i, COL_UNIT1_GRADE].Value) == MPGC.MP_SUBLOT_SCRAP_GRADE)
                {
                    spdUnit1.ActiveSheet.SetActiveCell(i, COL_UNIT1_GRADE);
                    spdUnit1_EditModeOff(null, null);
                }
            }
        }

        private void spdUnit23_EditModeOff(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.SheetView spdView = ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet;
            int i_row = spdView.ActiveRowIndex;
            int i_col = spdView.ActiveColumnIndex;

            if (i_col <= COL_UNIT23_REMAIN_QTY) return;

            if (MPCF.ToInt(spdView.Cells[i_row, COL_UNIT23_REMAIN_QTY].Value) < 0)
            {
                spdView.Cells[i_row, i_col].Value = null;
            }
        }

        private void cdvUnit2LossCode_ButtonPress(object sender, EventArgs e)
        {
            cdvUnit2LossCode.Init();
            MPCF.InitListView(cdvUnit2LossCode.GetListView);
            cdvUnit2LossCode.Columns.Add("Loss Code", 50, HorizontalAlignment.Left);
            cdvUnit2LossCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUnit2LossCode.SelectedSubItemIndex = 0;

            if (BASLIST.ViewGCMDataList(cdvUnit2LossCode.GetListView, '1', ms_loss_code_table) == false)
            {
                return;
            }
        }

        private void cdvUnit3LossCode_ButtonPress(object sender, EventArgs e)
        {
            cdvUnit3LossCode.Init();
            MPCF.InitListView(cdvUnit3LossCode.GetListView);
            cdvUnit3LossCode.Columns.Add("Loss Code", 50, HorizontalAlignment.Left);
            cdvUnit3LossCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUnit3LossCode.SelectedSubItemIndex = 0;

            if (BASLIST.ViewGCMDataList(cdvUnit3LossCode.GetListView, '1', ms_loss_code_table) == false)
            {
                return;
            }
        }

        private void btnUnit2LossApply_Click(object sender, EventArgs e)
        {
            if (numUnit2LossQty.Value < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                numUnit2LossQty.Focus();
                return;
            }

            if (MPCF.CheckValue(cdvUnit2LossCode, 1) == false)
            {
                return;
            }

            int i;
            int k;

            for (i = COL_UNIT23_REMAIN_QTY + 1; i < spdUnit2.ActiveSheet.ColumnCount; i++)
            {
                if (MPCF.Trim(spdUnit2.ActiveSheet.ColumnHeader.Cells[0, i].Value) == cdvUnit2LossCode.Text)
                {
                    break;
                }
            }
            if (i >= spdUnit2.ActiveSheet.ColumnCount)
            {
                return;
            }

            for (k = 0; k < spdUnit2.ActiveSheet.RowCount - 1; k++)
            {
                if (MPCF.ToInt(spdUnit2.ActiveSheet.Cells[k, COL_UNIT23_REMAIN_QTY].Value) >= numUnit2LossQty.Value)
                {
                    spdUnit2.ActiveSheet.Cells[k, i].Value = numUnit2LossQty.Value;
                }
            }
        }

        private void btnUnit3LossApply_Click(object sender, EventArgs e)
        {
            if (numUnit3LossQty.Value < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                numUnit3LossQty.Focus();
                return;
            }

            if (MPCF.CheckValue(cdvUnit3LossCode, 1) == false)
            {
                return;
            }

            int i;
            int k;

            for (i = COL_UNIT23_REMAIN_QTY + 1; i < spdUnit3.ActiveSheet.ColumnCount; i++)
            {
                if (MPCF.Trim(spdUnit3.ActiveSheet.ColumnHeader.Cells[0, i].Value) == cdvUnit3LossCode.Text)
                {
                    break;
                }
            }
            if (i >= spdUnit3.ActiveSheet.ColumnCount)
            {
                return;
            }

            for (k = 0; k < spdUnit3.ActiveSheet.RowCount - 1; k++)
            {
                if (MPCF.ToInt(spdUnit3.ActiveSheet.Cells[k, COL_UNIT23_REMAIN_QTY].Value) >= numUnit3LossQty.Value)
                {
                    spdUnit3.ActiveSheet.Cells[k, i].Value = numUnit3LossQty.Value;
                }
            }
        }

        private void btnUnit2LossClear_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < spdUnit2.ActiveSheet.RowCount - 1; i++)
            {
                if (MPCF.Trim(spdUnit2.ActiveSheet.Rows[i].Tag) == "S" && chkSameCodeToUnit23.Checked == true)
                {
                    ;
                }
                else
                {
                    spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit2.ActiveSheet.ColumnCount - 1].Value = null;
                }
            }
        }

        private void btnUnit3LossClear_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < spdUnit3.ActiveSheet.RowCount - 1; i++)
            {
                if (MPCF.Trim(spdUnit3.ActiveSheet.Rows[i].Tag) == "S" && chkSameCodeToUnit23.Checked == true)
                {
                    ;
                }
                else
                {
                    spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_REMAIN_QTY + 1, i, spdUnit3.ActiveSheet.ColumnCount - 1].Value = null;
                }
            }
        }





    }
}
