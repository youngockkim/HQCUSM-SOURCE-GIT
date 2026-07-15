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
    public partial class frmWIPTranBonusLotExt : TranForm23
    {
        public frmWIPTranBonusLotExt()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int COL_UNIT23_CRR_ID = 0;
        private const int COL_UNIT23_SLOT_NO = 1;
        private const int COL_UNIT23_SUBLOT = 2;
        private const int COL_UNIT23_QTY = 3;
        private const int COL_UNIT23_BONUS_QTY = 4;
        private const int COL_UNIT23_CHANGED_QTY = 5;

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private string ms_bonus_code_table;

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

        private class BONUS_CODE_TAG
        {
            public string bonus_code;
            public double bonus_qty;
        }

        private class BONUS_CODES_INFOR
        {
            public List<BONUS_CODE_TAG> bonus_codes;

            private int findBonusCode(string s_bonus_code)
            {
                if (bonus_codes == null)
                {
                    bonus_codes = new List<BONUS_CODE_TAG>();
                }

                for (int i = 0; i < bonus_codes.Count; i++)
                {
                    if (bonus_codes[i].bonus_code == s_bonus_code)
                    {
                        return i;
                    }
                }

                return -1;
            }

            public void addBonusCode(string s_bonus_code, double d_bonus_qty)
            {
                int i_bonus_index;

                i_bonus_index = findBonusCode(s_bonus_code);
                if (i_bonus_index < 0)
                {
                    BONUS_CODE_TAG bonus = new BONUS_CODE_TAG();
                    bonus.bonus_code = s_bonus_code;
                    bonus.bonus_qty = d_bonus_qty;

                    bonus_codes.Add(bonus);
                }
                else
                {
                    bonus_codes[i_bonus_index].bonus_qty += d_bonus_qty;
                }
            }
        }

        private class SUBLOT_TAG
        {
            public string sublot_id;
            public int slot_no;
            public string bonus_code;
            public double out_qty_2;
            public double out_qty_3;

            public BONUS_CODES_INFOR unit2;
            public BONUS_CODES_INFOR unit3;

            public SUBLOT_TAG()
            {
                unit2 = new BONUS_CODES_INFOR();
                unit3 = new BONUS_CODES_INFOR();

                unit2.bonus_codes = new List<BONUS_CODE_TAG>();
                unit3.bonus_codes = new List<BONUS_CODE_TAG>();
                bonus_code = "";
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

            public void setUnit2BonusCode(string s_sublot_id, string s_bonus_code, double d_bonus_qty)
            {
                int i_sublot_index;

                i_sublot_index = findSublot(s_sublot_id);
                if (i_sublot_index >= 0)
                {
                    sublots[i_sublot_index].unit2.addBonusCode(s_bonus_code, d_bonus_qty);
                }
            }

            public void setUnit3BonusCode(string s_sublot_id, string s_bonus_code, double d_bonus_qty)
            {
                int i_sublot_index;

                i_sublot_index = findSublot(s_sublot_id);
                if (i_sublot_index >= 0)
                {
                    sublots[i_sublot_index].unit3.addBonusCode(s_bonus_code, d_bonus_qty);
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

            if (ViewSublotLotList() == false) return false;
            if (ViewBonusCode() == false) return false;

            cdvResID.Text = LOT.GetString("START_RES_ID");

            return true;
        }

        protected override bool CheckCondition()
        {
            bool b_exist_bonus_infor;

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

            b_exist_bonus_infor = false;

            if (spdUnit2.ActiveSheet.RowCount > 0)
            {
                if (MPCF.ToInt(spdUnit2.ActiveSheet.Cells[spdUnit2.ActiveSheet.RowCount - 1, COL_UNIT23_BONUS_QTY].Value) > 0)
                {
                    b_exist_bonus_infor = true;
                }
            }

            if (spdUnit3.ActiveSheet.RowCount > 0)
            {
                if (MPCF.ToInt(spdUnit3.ActiveSheet.Cells[spdUnit3.ActiveSheet.RowCount - 1, COL_UNIT23_BONUS_QTY].Value) > 0)
                {
                    b_exist_bonus_infor = true;
                }
            }

            if (b_exist_bonus_infor == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107) + "\n" + MPCF.FindLanguage("Bonus Information", CAPTION_TYPE.LABEL));
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
                MPCF.ClearList(spdUnit2);
                MPCF.ClearList(spdUnit3);
                spdUnit2.ActiveSheet.ColumnCount = COL_UNIT23_CHANGED_QTY + 1;
                spdUnit3.ActiveSheet.ColumnCount = COL_UNIT23_CHANGED_QTY + 1;

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
                        i_row = spdUnit2.ActiveSheet.RowCount;
                        spdUnit2.ActiveSheet.RowCount++;
                        spdUnit3.ActiveSheet.RowCount++;

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
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Width = 60;
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Resizable = true;
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Visible = true;

                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Width = 60;
                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Resizable = true;
                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Visible = true;
                }
                else
                {
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Width = 0;
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Resizable = false;
                    spdUnit2.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Visible = false;

                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Width = 0;
                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Resizable = false;
                    spdUnit3.ActiveSheet.Columns[COL_UNIT23_CRR_ID].Visible = false;
                }

                if (spdUnit2.ActiveSheet.RowCount < 1)
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

        private bool ViewBonusCode()
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");
            ListView lis_bonus_code;
            int i;
            int i_col;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
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
                    tabTran.TabPages.Insert(1, tbpUnit2);
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
                    if (tabTran.TabPages.Contains(tbpUnit2) == true)
                    {
                        tabTran.TabPages.Insert(2, tbpUnit3);
                    }
                    else
                    {
                        tabTran.TabPages.Insert(1, tbpUnit3);
                    }
                }
            }



            ms_bonus_code_table = "";
            ms_bonus_code_table = MPCR.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_BONUS_TBL_DEF);
            if (ms_bonus_code_table == "")
            {
                ms_bonus_code_table = out_node.GetString("BONUS_TBL");
            }

            if (ms_bonus_code_table == "")
            {
                return true;
            }

            lis_bonus_code = new ListView();
            lis_bonus_code.Columns.Add("Bonus Code");             // 0
            lis_bonus_code.Columns.Add("Desc");                  // 1
            lis_bonus_code.Columns.Add("Reusable Type");         // 2

            MPCF.InitListView(lis_bonus_code);

            if (BASLIST.ViewGCMDataList(lis_bonus_code, '1', ms_bonus_code_table) == false)
            {
                return false;
            }

            FarPoint.Win.Spread.CellType.NumberCellType numCell;

            for (i = 0; i < lis_bonus_code.Items.Count; i++)
            {
                i_col = spdUnit2.ActiveSheet.ColumnCount;
                spdUnit2.ActiveSheet.ColumnCount++;
                spdUnit2.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = lis_bonus_code.Items[i].SubItems[0].Text; // Code
                spdUnit2.ActiveSheet.Columns[i_col].Tag = lis_bonus_code.Items[i];
                numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCell.DecimalPlaces = 0;
                numCell.MinimumValue = 0;
                numCell.ShowSeparator = true;
                spdUnit2.ActiveSheet.Columns[i_col].CellType = numCell;
                spdUnit2.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdUnit2.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;

                i_col = spdUnit3.ActiveSheet.ColumnCount;
                spdUnit3.ActiveSheet.ColumnCount++;
                spdUnit3.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = lis_bonus_code.Items[i].SubItems[0].Text; // Code
                spdUnit3.ActiveSheet.Columns[i_col].Tag = lis_bonus_code.Items[i];
                numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCell.DecimalPlaces = 0;
                numCell.MinimumValue = 0;
                numCell.ShowSeparator = true;
                spdUnit3.ActiveSheet.Columns[i_col].CellType = numCell;
                spdUnit3.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdUnit3.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            }

            if (lis_bonus_code.Items.Count > 0)
            {
                i_col = spdUnit2.ActiveSheet.ColumnCount - COL_UNIT23_CHANGED_QTY;

                spdUnit2.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
                spdUnit3.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;

                for (i = 0; i < spdUnit2.ActiveSheet.RowCount; i++)
                {
                    spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_BONUS_QTY].Formula = "SUM(RC[2]:RC[" + i_col.ToString() + "])";
                    spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_CHANGED_QTY].Formula = "RC[-2]+RC[-1]";

                    spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_BONUS_QTY].Formula = "SUM(RC[2]:RC[" + i_col.ToString() + "])";
                    spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_CHANGED_QTY].Formula = "RC[-2]+RC[-1]";
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
                    for (i = 0; i < lis_bonus_code.Items.Count + COL_UNIT23_QTY; i++)
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
                    for (i = 0; i < lis_bonus_code.Items.Count + COL_UNIT23_QTY; i++)
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

            MPCF.FitColumnHeader(spdUnit2);
            MPCF.FitColumnHeader(spdUnit3);

            return true;
        }

        private bool BonusLot()
        {
            TRSNode in_node = new TRSNode("BONUS_LOT_EXT_IN");
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

                in_node.AddDouble("OUT_QTY_1", MPCF.ToDbl(spdUnit2.ActiveSheet.RowCount - 1));
                in_node.AddDouble("OUT_QTY_2", MPCF.ToDbl(spdUnit2.ActiveSheet.Cells[spdUnit2.ActiveSheet.RowCount - 1, COL_UNIT23_CHANGED_QTY].Value));
                in_node.AddDouble("OUT_QTY_3", MPCF.ToDbl(spdUnit3.ActiveSheet.Cells[spdUnit3.ActiveSheet.RowCount - 1, COL_UNIT23_CHANGED_QTY].Value));

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
                in_node.AddString("BONUS_COMMENT", MPCF.Trim(txtBonusComment.Text));

                if (SetCarrierInfor(in_node) == false) return false;
                if (SetUnit2BonusInfor(in_node) == false) return false;
                if (SetUnit3BonusInfor(in_node) == false) return false;
                if (SetSublotInfor(in_node) == false) return false;


                if (MPCR.CallService("WIP", "WIP_Bonus_Lot_Ext", in_node, ref out_node) == false)
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
            int i_changed_qty;

            TRSNode crr_node;

            clsCrrs = new CRRS_INFOR();

            for (i = 0; i < spdUnit2.ActiveSheet.RowCount - 1; i++)
            {
                s_crr_id = MPCF.Trim(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_CRR_ID].Value);
                i_changed_qty = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_CHANGED_QTY].Value);
                if (s_crr_id != "" && i_changed_qty > 0)
                {
                    clsCrrs.addCarrier(s_crr_id, 1, i_changed_qty, 0);
                }
            }

            if (clsCrrs.crrs == null || clsCrrs.crrs.Count < 1)
            {
                return true;
            }
            
            for (i = 0; i < spdUnit3.ActiveSheet.RowCount - 1; i++)
            {
                s_crr_id = MPCF.Trim(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_CRR_ID].Value);
                i_changed_qty = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_CHANGED_QTY].Value);
                if (s_crr_id != "" && i_changed_qty > 0)
                {
                    clsCrrs.addCarrier(s_crr_id, 0, 0, i_changed_qty);
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

        private bool SetUnit2BonusInfor(TRSNode in_node)
        {
            int i;
            string s_bonus_code;
            int i_bonus_qty;
            TRSNode unit_node;

            for (i = COL_UNIT23_CHANGED_QTY + 1; i < spdUnit2.ActiveSheet.ColumnCount; i++)
            {
                s_bonus_code = MPCF.Trim(spdUnit2.ActiveSheet.ColumnHeader.Cells[0, i].Value);
                i_bonus_qty = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[spdUnit2.ActiveSheet.RowCount - 1, i].Value);
                if (i_bonus_qty > 0)
                {
                    unit_node = in_node.AddNode("UNIT2");

                    unit_node.AddString("CODE", s_bonus_code);
                    unit_node.AddDouble("QTY", i_bonus_qty);
                }
            }

            return true;
        }

        private bool SetUnit3BonusInfor(TRSNode in_node)
        {
            int i;
            string s_bonus_code;
            int i_bonus_qty;
            TRSNode unit_node;

            for (i = COL_UNIT23_CHANGED_QTY + 1; i < spdUnit3.ActiveSheet.ColumnCount; i++)
            {
                s_bonus_code = MPCF.Trim(spdUnit3.ActiveSheet.ColumnHeader.Cells[0, i].Value);
                i_bonus_qty = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[spdUnit3.ActiveSheet.RowCount - 1, i].Value);
                if (i_bonus_qty > 0)
                {
                    unit_node = in_node.AddNode("UNIT3");

                    unit_node.AddString("CODE", s_bonus_code);
                    unit_node.AddDouble("QTY", i_bonus_qty);
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
            string s_bonus_code;
            //char c_grade;
            int i_out_qty;
            int i_bonus_qty;

            TRSNode sublot_node;
            TRSNode unit_node;

            clsSublots = new SUBLOTS_INFOR();

            for (i = 0; i < spdUnit2.ActiveSheet.RowCount - 1; i++)
            {
                s_sublot_id = MPCF.Trim(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value);
                i_slot_no = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_SLOT_NO].Value);
                i_out_qty = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, COL_UNIT23_CHANGED_QTY].Value);

                for (k = COL_UNIT23_CHANGED_QTY + 1; k < spdUnit2.ActiveSheet.ColumnCount; k++)
                {
                    s_bonus_code = MPCF.Trim(spdUnit2.ActiveSheet.ColumnHeader.Cells[0, k].Value);
                    i_bonus_qty = MPCF.ToInt(spdUnit2.ActiveSheet.Cells[i, k].Value);

                    if (i_bonus_qty > 0)
                    {
                        if (i_out_qty > -9999999)
                        {
                            clsSublots.addSublot(s_sublot_id, i_slot_no);
                            clsSublots.setOutQty(s_sublot_id, i_out_qty, 0);
                            i_out_qty = -9999999;
                        }

                        clsSublots.setUnit2BonusCode(s_sublot_id, s_bonus_code, i_bonus_qty);
                    }
                }
            }

            for (i = 0; i < spdUnit3.ActiveSheet.RowCount - 1; i++)
            {
                s_sublot_id = MPCF.Trim(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_SUBLOT].Value);
                i_slot_no = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_SLOT_NO].Value);
                i_out_qty = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, COL_UNIT23_CHANGED_QTY].Value);

                for (k = COL_UNIT23_CHANGED_QTY + 1; k < spdUnit3.ActiveSheet.ColumnCount; k++)
                {
                    s_bonus_code = MPCF.Trim(spdUnit3.ActiveSheet.ColumnHeader.Cells[0, k].Value);
                    i_bonus_qty = MPCF.ToInt(spdUnit3.ActiveSheet.Cells[i, k].Value);

                    if (i_bonus_qty > 0)
                    {
                        if (i_out_qty > -9999999)
                        {
                            clsSublots.addSublot(s_sublot_id, i_slot_no);
                            clsSublots.setOutQty(s_sublot_id, 0, i_out_qty);
                            i_out_qty = -9999999;
                        }

                        clsSublots.setUnit3BonusCode(s_sublot_id, s_bonus_code, i_bonus_qty);
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
                sublot_node.AddString("BONUS_CODE", clsSublots.sublots[i].bonus_code);

                for (k = 0; k < clsSublots.sublots[i].unit2.bonus_codes.Count; k++)
                {
                    unit_node = sublot_node.AddNode("UNIT2");
                    unit_node.AddString("CODE", clsSublots.sublots[i].unit2.bonus_codes[k].bonus_code);
                    unit_node.AddDouble("QTY", clsSublots.sublots[i].unit2.bonus_codes[k].bonus_qty);
                }
                for (k = 0; k < clsSublots.sublots[i].unit3.bonus_codes.Count; k++)
                {
                    unit_node = sublot_node.AddNode("UNIT3");
                    unit_node.AddString("CODE", clsSublots.sublots[i].unit3.bonus_codes[k].bonus_code);
                    unit_node.AddDouble("QTY", clsSublots.sublots[i].unit3.bonus_codes[k].bonus_qty);
                }
            }

            return true;
        }


        #endregion

        private void frmWIPTranBonusLotExt_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    tabTran.TabPages.Remove(tbpCMF);
                    tabTran.TabPages.Add(tbpCMF);

                    SetCMFItem(MPGC.MP_CMF_TRN_BONUS);

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

                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_BONUS, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'B') == false) return;
                if (BonusLot() == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_BONUS, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'A') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdUnit23_EditModeOff(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.SheetView spdView = ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet;
            int i_row = spdView.ActiveRowIndex;
            int i_col = spdView.ActiveColumnIndex;

            if (i_col <= COL_UNIT23_CHANGED_QTY) return;

            if (MPCF.ToInt(spdView.Cells[i_row, COL_UNIT23_CHANGED_QTY].Value) < 0)
            {
                spdView.Cells[i_row, i_col].Value = null;
            }
        }

        private void cdvUnit2BonusCode_ButtonPress(object sender, EventArgs e)
        {
            cdvUnit2BonusCode.Init();
            MPCF.InitListView(cdvUnit2BonusCode.GetListView);
            cdvUnit2BonusCode.Columns.Add("Bonus Code", 50, HorizontalAlignment.Left);
            cdvUnit2BonusCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUnit2BonusCode.SelectedSubItemIndex = 0;

            if (BASLIST.ViewGCMDataList(cdvUnit2BonusCode.GetListView, '1', ms_bonus_code_table) == false)
            {
                return;
            }
        }

        private void cdvUnit3BonusCode_ButtonPress(object sender, EventArgs e)
        {
            cdvUnit3BonusCode.Init();
            MPCF.InitListView(cdvUnit3BonusCode.GetListView);
            cdvUnit3BonusCode.Columns.Add("Bonus Code", 50, HorizontalAlignment.Left);
            cdvUnit3BonusCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUnit3BonusCode.SelectedSubItemIndex = 0;

            if (BASLIST.ViewGCMDataList(cdvUnit3BonusCode.GetListView, '1', ms_bonus_code_table) == false)
            {
                return;
            }
        }

        private void btnUnit2BonusApply_Click(object sender, EventArgs e)
        {
            if (numUnit2BonusQty.Value < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                numUnit2BonusQty.Focus();
                return;
            }

            if (MPCF.CheckValue(cdvUnit2BonusCode, 1) == false)
            {
                return;
            }

            int i;
            int k;

            for (i = COL_UNIT23_CHANGED_QTY + 1; i < spdUnit2.ActiveSheet.ColumnCount; i++)
            {
                if (MPCF.Trim(spdUnit2.ActiveSheet.ColumnHeader.Cells[0, i].Value) == cdvUnit2BonusCode.Text)
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
                if (MPCF.ToInt(spdUnit2.ActiveSheet.Cells[k, COL_UNIT23_CHANGED_QTY].Value) >= numUnit2BonusQty.Value)
                {
                    spdUnit2.ActiveSheet.Cells[k, i].Value = numUnit2BonusQty.Value;
                }
            }
        }

        private void btnUnit3BonusApply_Click(object sender, EventArgs e)
        {
            if (numUnit3BonusQty.Value < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                numUnit3BonusQty.Focus();
                return;
            }

            if (MPCF.CheckValue(cdvUnit3BonusCode, 1) == false)
            {
                return;
            }

            int i;
            int k;

            for (i = COL_UNIT23_CHANGED_QTY + 1; i < spdUnit3.ActiveSheet.ColumnCount; i++)
            {
                if (MPCF.Trim(spdUnit3.ActiveSheet.ColumnHeader.Cells[0, i].Value) == cdvUnit3BonusCode.Text)
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
                if (MPCF.ToInt(spdUnit3.ActiveSheet.Cells[k, COL_UNIT23_CHANGED_QTY].Value) >= numUnit3BonusQty.Value)
                {
                    spdUnit3.ActiveSheet.Cells[k, i].Value = numUnit3BonusQty.Value;
                }
            }
        }

        private void btnUnit2BonusClear_Click(object sender, EventArgs e)
        {
            spdUnit2.ActiveSheet.Cells[0, COL_UNIT23_CHANGED_QTY + 1, spdUnit2.ActiveSheet.RowCount - 2, spdUnit2.ActiveSheet.ColumnCount - 1].Value = null;
        }

        private void btnUnit3BonusClear_Click(object sender, EventArgs e)
        {
            spdUnit3.ActiveSheet.Cells[0, COL_UNIT23_CHANGED_QTY + 1, spdUnit3.ActiveSheet.RowCount - 2, spdUnit3.ActiveSheet.ColumnCount - 1].Value = null;
        }





    }
}
