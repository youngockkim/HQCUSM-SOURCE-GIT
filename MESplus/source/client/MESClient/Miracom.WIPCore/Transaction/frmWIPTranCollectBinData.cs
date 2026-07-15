using System;
using System.Collections;
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
    public partial class frmWIPTranCollectBinData : TranForm23
    {
        public frmWIPTranCollectBinData()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int COL_BIN_SEQ = 0;
        private const int COL_BIN_PROMPT = 1;
        private const int COL_BIN_PROMPT_DESC = 2;
        private const int COL_BIN_TYPE = 3;
        private const int COL_BIN_QTY = 4;
        private const int COL_CHILD_LOT = 5;
        private const int COL_SPLIT_BY = 6;
        private const int COL_KEEP_LOT = 7;
        private const int COL_REASON_CODE = 8;
        private const int COL_TO_MAT_ID = 9;
        private const int COL_TO_FLOW = 10;
        private const int COL_TO_OPER = 11;
        private const int COL_TO_LOT_TYPE = 12;
        private const int COL_TO_PRIORITY = 13;
        private const int COL_TO_CREATE_CODE = 14;
        private const int COL_TO_OWNER_CODE = 15;
        private const int COL_TO_CRR_GROUP = 16;

        private const int COL_SUBLOT_ID = 0;
        private const int COL_QTY = 1;
        private const int COL_TOTAL = 2;
        private const int COL_REMAIN = 3;
        private const int COL_PASS_SUM = 4;
        private const int COL_FAIL_SUM = 5;

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private bool mb_col_other_unit_flag;
        private bool mb_sublot_base_collection_flag;
        private bool mb_by_popup_action_flag;
        private Dictionary<string, string> md_child_confirm_key;

        private TRSNode mt_end_lot_in;

        #endregion

        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            ClearData(1);

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }

            if (ViewBinByLot(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }

            return true;
        }

        // ClearData()
        //       -   Clear Form Controls
        // Return Value
        //       -
        // Arguments
        //       -
        protected override void ClearData(int i_case)
        {
            try
            {
                switch (i_case)
                {
                    case 1:
                        base.ClearData(1);
                        MPCF.ClearList(spdBinDataUnit1);
                        MPCF.ClearList(spdBinDataUnit2);
                        spdBinDataUnit2.ActiveSheet.ColumnCount = 6;
                        break;
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
        //       - ByVal FuncName As String : Function Name
        //
        protected override bool CheckCondition()
        {
            if (base.CheckCondition() == false) return false;

            if (MPCF.CheckValue(txtBinID, 1) == false) return false;
            if (MPCF.CheckValue(txtBinVersion, 1) == false) return false;
            if (MPCF.CheckValue(txtBinUnit, 1) == false) return false;

            if (Math.Abs(MPCF.ToDbl(txtRemainBinQty.Text)) > 0.0005)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(353));
                return false;
            }

            if (mb_sublot_base_collection_flag == true)
            {
                int i;
                double d_remain_qty;

                for (i = 0; i < spdBinDataUnit2.ActiveSheet.RowCount - 1; i++)
                {
                    d_remain_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i, COL_REMAIN].Value);
                    if (Math.Abs(d_remain_qty) > 0.0005)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(353));
                        spdBinDataUnit2.ActiveSheet.SetActiveCell(i, COL_REMAIN);
                        spdBinDataUnit2.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left);
                        spdBinDataUnit2.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ViewSublotList(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node;
            ArrayList a_list;
            List<TRSNode> sublot_list;
            int i;
            int i_row;

            a_list = new ArrayList();

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", s_lot_id);

            do
            {
                out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");

                if (MPCR.CallService("WIP", "WIP_View_Sublot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            foreach (object obj in a_list)
            {
                sublot_list = ((TRSNode)obj).GetList("LIST");
                for (i = 0; i < sublot_list.Count; i++)
                {
                    i_row = spdBinDataUnit2.ActiveSheet.RowCount;
                    spdBinDataUnit2.ActiveSheet.RowCount++;

                    spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_SUBLOT_ID].Value = sublot_list[i].GetString("SUBLOT_ID");
                    spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_QTY].Value = sublot_list[i].GetDouble("QTY_2");
                }//end for
            }//end foreach

            return true;
        }

        private void AddRowForUnit1(TRSNode grade_node)
        {
            int i_row;
            string s_child_lot_id;

            i_row = spdBinDataUnit1.ActiveSheet.RowCount;
            spdBinDataUnit1.ActiveSheet.RowCount++;

            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_SEQ].Value = grade_node.GetInt("BIN_SEQ").ToString("000");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_PROMPT].Value = grade_node.GetString("BIN_PROMPT");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_PROMPT_DESC].Value = grade_node.GetString("BIN_PROMPT_DESC");

            if (grade_node.GetChar("BIN_TYPE") == 'P')
            {
                spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_TYPE].Value = MPCF.FindLanguage("Pass", CAPTION_TYPE.LABEL);
                spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_TYPE].Tag = 'P';
            }
            else if (grade_node.GetChar("BIN_TYPE") == 'F')
            {
                spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_TYPE].Value = MPCF.FindLanguage("Fail", CAPTION_TYPE.LABEL);
                spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_TYPE].Tag = 'F';
            }

            s_child_lot_id = grade_node.GetString("CHILD_LOT_ID");
            if (s_child_lot_id != "")
            {
                md_child_confirm_key.Add(s_child_lot_id, grade_node.GetString("CONFIRM_KEY"));
            }

            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_CHILD_LOT].Value = grade_node.GetString("CHILD_LOT_ID");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_SPLIT_BY].Value = null;
            if (grade_node.GetInt("SPLIT_BY_BIN_SEQ") > 0)
            {
                spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_SPLIT_BY].Value = grade_node.GetInt("SPLIT_BY_BIN_SEQ").ToString("000");
            }

            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_KEEP_LOT].Value = grade_node.GetChar("KEEP_LOT_FLAG");
            if (grade_node.GetChar("BIN_TYPE") == 'F')
            {
                spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_REASON_CODE].Value = grade_node.GetString("FAIL_REASON_CODE");
            }

            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_TO_MAT_ID].Value = grade_node.GetString("CHANGE_MAT_ID");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_TO_FLOW].Value = grade_node.GetString("CHANGE_FLOW");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_TO_OPER].Value = grade_node.GetString("MOVE_TO_OPER");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_TO_LOT_TYPE].Value = grade_node.GetChar("CHANGE_LOT_TYPE");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_TO_PRIORITY].Value = grade_node.GetChar("CHANGE_LOT_PRIORITY");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_TO_CREATE_CODE].Value = grade_node.GetString("CHANGE_CREATE_CODE");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_TO_OWNER_CODE].Value = grade_node.GetString("CHANGE_OWNER_CODE");
            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_TO_CRR_GROUP].Value = grade_node.GetString("CHANGE_CRR_GROUP");

            if (grade_node.GetChar("LOGICAL_BIN_FLAG") == 'Y')
            {
                spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_QTY].BackColor = Color.Gainsboro;
                spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_QTY].Locked = true;
            }

        }

        private void AddColumnForUnit2(TRSNode grade_node)
        {
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType;
            int i_col;

            i_col = spdBinDataUnit2.ActiveSheet.ColumnCount;
            spdBinDataUnit2.ActiveSheet.ColumnCount++;

            spdBinDataUnit2.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = grade_node.GetString("BIN_PROMPT");
            spdBinDataUnit2.ActiveSheet.ColumnHeader.Cells[0, i_col].Tag = grade_node.GetInt("BIN_SEQ");

            if (grade_node.GetChar("BIN_TYPE") == 'P')
            {
                spdBinDataUnit2.ActiveSheet.ColumnHeader.Cells[0, i_col].BackColor = Color.PaleGreen;
                spdBinDataUnit2.ActiveSheet.ColumnHeader.Cells[0, i_col].VisualStyles = FarPoint.Win.VisualStyles.Off;
            }
            else if (grade_node.GetChar("BIN_TYPE") == 'F')
            {
                spdBinDataUnit2.ActiveSheet.ColumnHeader.Cells[0, i_col].BackColor = Color.Linen;
                spdBinDataUnit2.ActiveSheet.ColumnHeader.Cells[0, i_col].VisualStyles = FarPoint.Win.VisualStyles.Off;
            }

            spdBinDataUnit2.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 0;
            numberCellType.MaximumValue = 10000000D;
            numberCellType.MinimumValue = 0D;
            numberCellType.ShowSeparator = true;
            spdBinDataUnit2.ActiveSheet.Columns[i_col].CellType = numberCellType;
            spdBinDataUnit2.ActiveSheet.Columns[i_col].Tag = grade_node.GetChar("BIN_TYPE");

            if (grade_node.GetChar("LOGICAL_BIN_FLAG") == 'Y')
            {
                spdBinDataUnit2.ActiveSheet.Columns[i_col].BackColor = Color.Gainsboro;
                spdBinDataUnit2.ActiveSheet.Columns[i_col].Locked = true;
            }

        }

        private bool ViewBinByLot(String s_lot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_BY_LOT_IN");
            TRSNode out_node;

            ArrayList grade_array;
            List<TRSNode> grade_list;
            int i, i_row;

            try
            {
                MPCF.ClearList(spdBinDataUnit1);
                MPCF.ClearList(spdBinDataUnit2);
                spdBinDataUnit2.ActiveSheet.ColumnCount = 6;

                mb_col_other_unit_flag = false;
                mb_sublot_base_collection_flag = false;

                grade_array = new ArrayList();
                md_child_confirm_key = new Dictionary<string, string>();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);

                do
                {
                    out_node = new TRSNode("VIEW_BIN_BY_LOT_OUT");

                    if (MPCR.CallService("WIP", "WIP_View_Bin_By_Lot", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    grade_array.Add(out_node);
            
                    in_node.SetString("NEXT_BIN_ID", out_node.GetString("NEXT_BIN_ID"));
                    in_node.SetInt("NEXT_BIN_VERSION", out_node.GetInt("NEXT_BIN_VERSION"));
                    in_node.SetString("NEXT_BIN_UNIT", out_node.GetString("NEXT_BIN_UNIT"));
                    in_node.SetInt("NEXT_BIN_SEQ", out_node.GetInt("NEXT_BIN_SEQ"));
                } while (in_node.GetString("NEXT_BIN_ID") != "" && in_node.GetInt("NEXT_BIN_SEQ") > 0);

                if(grade_array.Count < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(352));
                    return false;
                }

                mb_col_other_unit_flag = ((TRSNode)grade_array[0]).GetChar("COL_OTHER_UNIT_FLAG") == 'Y' ? true : false;

                txtBinID.Text = ((TRSNode)grade_array[0]).GetString("BIN_ID");
                txtBinVersion.Text = ((TRSNode)grade_array[0]).GetInt("BIN_VERSION").ToString();
                txtBinUnit.Text = ((TRSNode)grade_array[0]).GetString("BIN_UNIT");
                txtBinUnitDesc.Text = ((TRSNode)grade_array[0]).GetString("BIN_UNIT_DESC");

                lblBinUnitQty.Text = ((TRSNode)grade_array[0]).GetString("BIN_UNIT") + " QTY";

                if (((TRSNode)grade_array[0]).GetString("BIN_UNIT_TYPE") == "UNIT2")
                {
                    txtBinUnitQty.Text = LOT.GetDouble("QTY_2").ToString("#######,##0.###");
                    txtBinUnitQty.Tag = LOT.GetDouble("QTY_2");
                    txtRemainBinQty.Text = txtBinUnitQty.Text;

                    mb_sublot_base_collection_flag = true;
                    spdBinDataUnit1.Visible = false;
                    spdBinDataUnit2.Visible = true;

                    /* Sublot Base Bin Collection */
                    if (ViewSublotList(s_lot_id) == false)
                    {
                        return false;
                    }

                    if (spdBinDataUnit2.ActiveSheet.RowCount < 1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(351));
                        return false;
                    }

                    foreach (object grade in grade_array)
                    {
                        grade_list = ((TRSNode)grade).GetList("GRADE_LIST");
                        for (i = 0; i < grade_list.Count; i++)
                        {
                            AddColumnForUnit2(grade_list[i]);
                        }//end for
                    }//end foreach

                    spdBinDataUnit2.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
                    for (i = 0; i < spdBinDataUnit2.ActiveSheet.RowCount; i++)
                    {
                        spdBinDataUnit2.ActiveSheet.Cells[i, COL_TOTAL].Formula = "SUM(RC[2]:RC[3])";
                        spdBinDataUnit2.ActiveSheet.Cells[i, COL_REMAIN].Formula = "RC[-2] - RC[-1]";
                    }//end for

                    i_row = spdBinDataUnit2.ActiveSheet.RowCount;
                    spdBinDataUnit2.ActiveSheet.RowCount++;
                    for (i = COL_QTY; i < spdBinDataUnit2.ActiveSheet.ColumnCount; i++)
                    {
                        spdBinDataUnit2.ActiveSheet.Cells[i_row, i].Formula = "SUM(R[" + (i_row * -1).ToString() + "]C:R[-1]C)";
                    }//end for
                    spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_SUBLOT_ID].Value = MPCF.FindLanguage("Total", CAPTION_TYPE.LABEL);
                    spdBinDataUnit2.ActiveSheet.Rows[i_row].BackColor = Color.Moccasin;
                    spdBinDataUnit2.ActiveSheet.FrozenTrailingRowCount = 1;
                    
                    MPCF.FitColumnHeader(spdBinDataUnit2);
                }//end if
                else
                {
                    txtBinUnitQty.Text = LOT.GetDouble("QTY_1").ToString("#######,##0.###");
                    txtBinUnitQty.Tag = LOT.GetDouble("QTY_1");
                    txtRemainBinQty.Text = txtBinUnitQty.Text;

                    spdBinDataUnit1.Visible = true;
                    spdBinDataUnit2.Visible = false;

                    /* Lot Base Bin Collection */
                    foreach (object grade in grade_array)
                    {
                        grade_list = ((TRSNode)grade).GetList("GRADE_LIST");
                        for (i = 0; i < grade_list.Count; i++)
                        {
                            AddRowForUnit1(grade_list[i]);
                        }//end for
                    }//end foreach

                    MPCF.FitColumnHeader(spdBinDataUnit1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private int FindBinSeqUnit1(int i_bin_seq)
        {
            int i;

            for (i = 0; i < spdBinDataUnit1.ActiveSheet.RowCount; i++)
            {
                if(MPCF.Trim(spdBinDataUnit1.ActiveSheet.Cells[i, COL_BIN_SEQ].Value) == i_bin_seq.ToString("000"))
                {
                    return i;
                }
            }

            return -1;
        }

        private void FindBinSeqUnit2(string s_sublot_id, int i_bin_seq, ref int i_row, ref int i_col)
        {
            int i, k;

            for (i = 0; i < spdBinDataUnit2.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdBinDataUnit2.ActiveSheet.Cells[i, COL_SUBLOT_ID].Value) == s_sublot_id)
                {
                    for (k = 0; k < spdBinDataUnit2.ActiveSheet.ColumnCount; k++)
                    {
                        if (MPCF.ToInt(spdBinDataUnit2.ActiveSheet.ColumnHeader.Cells[0, k].Tag) == i_bin_seq)
                        {
                            i_row = i;
                            i_col = k;
                            return;
                        }
                    }
                }
            }

            i_row = -1;
            i_col = -1;
        }

        private bool ViewLatestBinCollectionData()
        {
            TRSNode in_node = new TRSNode("VIEW_LATEST_BIN_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_LATEST_BIN_DATA_OUT");

            List<TRSNode> data_list;
            int i;
            int i_row, i_col;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("BIN_ID", txtBinID.Text);
                in_node.AddInt("BIN_VERSION", txtBinVersion.Text);
                in_node.AddString("BIN_UNIT", txtBinUnit.Text);

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Latest_Bin_Collection_Data", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    data_list = out_node.GetList("DATA_LIST");
                    for (i = 0; i < data_list.Count; i++)
                    {
                        i_row = i_col = -1;

                        if (mb_sublot_base_collection_flag == false)
                        {
                            i_row = FindBinSeqUnit1(data_list[i].GetInt("BIN_SEQ"));
                            if (i_row < 0) continue;

                            spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_QTY].Value = data_list[i].GetDouble("BIN_QTY");
                        }
                        else
                        {
                            FindBinSeqUnit2(data_list[i].GetString("SUBLOT_ID"), data_list[i].GetInt("BIN_SEQ"), ref i_row, ref i_col);
                            if (i_row < 0 || i_col < 0) continue;

                            spdBinDataUnit2.ActiveSheet.Cells[i_row, i_col].Value = data_list[i].GetDouble("BIN_QTY");
                        }
                    }

                    in_node.SetString("NEXT_SUBLOT_ID", out_node.GetString("NEXT_SUBLOT_ID"));
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    in_node.SetInt("NEXT_BIN_SEQ", out_node.GetInt("NEXT_BIN_SEQ"));
                } while (in_node.GetString("NEXT_SUBLOT_ID") != "" || in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_BIN_SEQ") > 0);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool CollectBinData()
        {
            TRSNode in_node = new TRSNode("COLLECT_BIN_DATA_IN");
            TRSNode out_node = new TRSNode("COLLECT_BIN_DATA_OUT");
            TRSNode grade_item;
            TRSNode sublot_item;
            int i;
            int k;
            string s_child_lot_id;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotID.Text);

                in_node.AddString("BIN_ID", txtBinID.Text);
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(txtBinVersion.Text));
                in_node.AddString("BIN_UNIT", txtBinUnit.Text);
                in_node.AddChar("COL_OTHER_UNIT_FLAG", mb_col_other_unit_flag == true ? 'Y' : ' ');
                in_node.AddChar("SUBLOT_BASE_BIN_FLAG", mb_sublot_base_collection_flag == true ? 'Y' : ' ');

                if(mb_sublot_base_collection_flag == true)
                {
                    for (i = 0; i < spdBinDataUnit2.ActiveSheet.RowCount - 1; i++)
                    {
                        if (MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i, COL_TOTAL].Value) < 0.0005) continue;

                        sublot_item = in_node.AddNode("SUBLOT_LIST");
                        sublot_item.AddString("SUBLOT_ID", spdBinDataUnit2.ActiveSheet.Cells[i, COL_SUBLOT_ID].Value);

                        for (k = COL_FAIL_SUM + 1; k < spdBinDataUnit2.ActiveSheet.ColumnCount; k++)
                        {
                            if (MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i, k].Value) < 0.0005) continue;

                            grade_item = sublot_item.AddNode("GRADE_LIST");
                            grade_item.AddInt("BIN_SEQ", spdBinDataUnit2.ActiveSheet.ColumnHeader.Cells[0, k].Tag);
                            grade_item.AddDouble("BIN_QTY", spdBinDataUnit2.ActiveSheet.Cells[i, k].Value);
                        }
                    }
                }
                else
                {
                    for (i = 0; i < spdBinDataUnit1.ActiveSheet.RowCount; i++)
                    {
                        grade_item = in_node.AddNode("GRADE_LIST");

                        grade_item.AddInt("BIN_SEQ", spdBinDataUnit1.ActiveSheet.Cells[i, COL_BIN_SEQ].Value);
                        grade_item.AddDouble("BIN_QTY", spdBinDataUnit1.ActiveSheet.Cells[i, COL_BIN_QTY].Value);

                        s_child_lot_id = MPCF.Trim(spdBinDataUnit1.ActiveSheet.Cells[i, COL_CHILD_LOT].Value);
                        if (s_child_lot_id != "")
                        {
                            grade_item.AddString("CHILD_LOT_ID", s_child_lot_id);
                            grade_item.AddString("CONFIRM_KEY", md_child_confirm_key[s_child_lot_id]);
                        }
                        //grade_item.AddString("CHILD_CUST_LOT_ID", spdBinDataUnit1.ActiveSheet.Cells[i, COL_CHILD_LOT].Value);
                        //grade_item.AddString("CHILD_CRR_ID", spdBinDataUnit1.ActiveSheet.Cells[i, COL_CHILD_LOT].Value);
                    }
                }
                
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT)
                                                 + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                /* 2013.06.12. Aiden. BIN Collection 과 END_LOT 을 동시에 처리할 수 있는 기능 추가 */
                if (mb_by_popup_action_flag == true && mt_end_lot_in != null)
                {
                    in_node.AddChar("PROC_END_LOT_FLAG", 'Y');
                    in_node.AddNode(mt_end_lot_in, "END_LOT_IN");
                }

                if (MPCR.CallService("WIP", "WIP_Collect_Bin_Data", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (mb_by_popup_action_flag == true)
                {
                    if (out_node.GetString(TRSDefine.OUT_MSGCODE) == "CMN-0000")
                    {
                        MPGV.gtBinLot.bin_lot_id = out_node.GetString("BIN_LOT_ID");
                        MPGV.gtBinLot.bin_lot_hist_seq = out_node.GetInt("BIN_LOT_HIST_SEQ");
                        MPGV.gtBinLot.bin_col_seq = out_node.GetInt("BIN_COL_SEQ");
                        MPGV.gtBinLot.low_yield_flag = false;
                    }
                    else
                    {
                        MPGV.gtBinLot.low_yield_flag = true;
                    }
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

        public void SetPopupAction(bool b_popup, TRSNode end_lot_in)
        {
            mb_by_popup_action_flag = b_popup;
            mt_end_lot_in = end_lot_in;

            txtLotID.ReadOnly = true;
        }

        #endregion

        private void frmWIPTranCollectBinData_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    base.SetCMFItem(MPGC.MP_CMF_TRN_BIN_COL);

                    ClearData(1);
                    spdBinDataUnit2.Visible = false;
                    spdBinDataUnit1.Dock = DockStyle.Fill;
                    spdBinDataUnit2.Dock = DockStyle.Fill;

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

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition() == false) return;
                if (CollectBinData() == false) return;

                if (mb_by_popup_action_flag == true)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ViewLotInfo(txtLotID.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdBinData_EditModeOff(object sender, EventArgs e)
        {
            int i_col;
            int i, k;
            double d_total_bin_qty;
            double d_pass_bin_qty;
            double d_fail_bin_qty;
            double d_bin_qty;

            i_col = spdBinDataUnit1.ActiveSheet.ActiveColumnIndex;

            if (i_col == COL_BIN_QTY)
            {
                d_total_bin_qty = d_pass_bin_qty = d_fail_bin_qty = 0;

                for (i = 0; i < spdBinDataUnit1.ActiveSheet.RowCount; i++)
                {
                    d_bin_qty = MPCF.ToDbl(spdBinDataUnit1.ActiveSheet.Cells[i, COL_BIN_QTY].Value);
                    d_total_bin_qty += d_bin_qty;

                    if (MPCF.Trim(spdBinDataUnit1.ActiveSheet.Cells[i, COL_BIN_TYPE].Tag) == "P")
                    {
                        d_pass_bin_qty += d_bin_qty;
                    }
                    else if (MPCF.Trim(spdBinDataUnit1.ActiveSheet.Cells[i, COL_BIN_TYPE].Tag) == "F")
                    {
                        d_fail_bin_qty += d_bin_qty;
                    }
                }

                for (k = spdBinDataUnit1.ActiveSheet.ActiveRowIndex + 1; k < spdBinDataUnit1.ActiveSheet.RowCount; k++)
                {
                    if (spdBinDataUnit1.ActiveSheet.Cells[k, COL_BIN_QTY].Locked == false)
                    {
                        break;
                    }
                }

                if (k < spdBinDataUnit1.ActiveSheet.RowCount)
                {
                    spdBinDataUnit1.ActiveSheet.SetActiveCell(k, COL_BIN_QTY);
                    spdBinDataUnit1.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);
                }

                txtTotalBinQty.Text = d_total_bin_qty.ToString("#######,##0.###");
                txtRemainBinQty.Text = (MPCF.ToDbl(txtBinUnitQty.Tag) - d_total_bin_qty).ToString("#######,##0.###");

                txtPassBinQty.Text = d_pass_bin_qty.ToString("#######,##0.###");
                txtFailBinQty.Text = d_fail_bin_qty.ToString("#######,##0.###");
            }
        }

        private void spdBinDataUnit2_EditModeOff(object sender, EventArgs e)
        {
            int i_col;
            int i_row;
            int i, k;
            double d_total_bin_qty;
            double d_pass_bin_qty;
            double d_fail_bin_qty;
            double d_bin_qty;

            i_col = spdBinDataUnit2.ActiveSheet.ActiveColumnIndex;
            i_row = spdBinDataUnit2.ActiveSheet.ActiveRowIndex;

            if (i_col > COL_FAIL_SUM)
            {
                d_pass_bin_qty = d_fail_bin_qty = 0;

                for (i = COL_FAIL_SUM + 1; i < spdBinDataUnit2.ActiveSheet.ColumnCount; i++)
                {
                    d_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, i].Value);

                    if (MPCF.Trim(spdBinDataUnit2.ActiveSheet.Columns[i].Tag) == "P")
                    {
                        d_pass_bin_qty += d_bin_qty;
                    }
                    else if (MPCF.Trim(spdBinDataUnit2.ActiveSheet.Columns[i].Tag) == "F")
                    {
                        d_fail_bin_qty += d_bin_qty;
                    }
                }

                for (k = i_col + 1; k < spdBinDataUnit2.ActiveSheet.ColumnCount; k++)
                {
                    if (spdBinDataUnit2.ActiveSheet.Columns[k].Locked == false)
                    {
                        break;
                    }
                }

                if (k < spdBinDataUnit2.ActiveSheet.ColumnCount)
                {
                    spdBinDataUnit2.ActiveSheet.SetActiveCell(i_row, k);
                    spdBinDataUnit2.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);
                }
                else
                {
                    for (k = COL_FAIL_SUM + 1; k < spdBinDataUnit2.ActiveSheet.ColumnCount; k++)
                    {
                        if (spdBinDataUnit2.ActiveSheet.Columns[k].Locked == false)
                        {
                            break;
                        }
                    }
                    if (k < spdBinDataUnit2.ActiveSheet.ColumnCount && i_row + 2 < spdBinDataUnit2.ActiveSheet.RowCount)
                    {
                        spdBinDataUnit2.ActiveSheet.SetActiveCell(i_row + 1, k);
                        spdBinDataUnit2.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);
                    }
                }

                spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_PASS_SUM].Value = d_pass_bin_qty;
                spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_FAIL_SUM].Value = d_fail_bin_qty;

                d_total_bin_qty = d_pass_bin_qty = d_fail_bin_qty = 0;
                i_row = spdBinDataUnit2.ActiveSheet.RowCount - 1;

                d_total_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_TOTAL].Value);
                d_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_REMAIN].Value);
                d_pass_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_PASS_SUM].Value);
                d_fail_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_FAIL_SUM].Value);

                txtTotalBinQty.Text = d_total_bin_qty.ToString("#######,##0.###");
                txtRemainBinQty.Text = d_bin_qty.ToString("#######,##0.###");
                txtPassBinQty.Text = d_pass_bin_qty.ToString("#######,##0.###");
                txtFailBinQty.Text = d_fail_bin_qty.ToString("#######,##0.###");
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int i_col;
            int i_row;
            double d_total_bin_qty;
            double d_pass_bin_qty;
            double d_fail_bin_qty;
            double d_bin_qty;

            if (mb_sublot_base_collection_flag == true)
            {
                for (i_row = 0; i_row < spdBinDataUnit2.ActiveSheet.RowCount - 1; i_row++)
                {
                    d_pass_bin_qty = d_fail_bin_qty = 0;

                    for (i_col = COL_FAIL_SUM + 1; i_col < spdBinDataUnit2.ActiveSheet.ColumnCount; i_col++)
                    {
                        d_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, i_col].Value);

                        if (MPCF.Trim(spdBinDataUnit2.ActiveSheet.Columns[i_col].Tag) == "P")
                        {
                            d_pass_bin_qty += d_bin_qty;
                        }
                        else if (MPCF.Trim(spdBinDataUnit2.ActiveSheet.Columns[i_col].Tag) == "F")
                        {
                            d_fail_bin_qty += d_bin_qty;
                        }
                    }

                    spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_PASS_SUM].Value = d_pass_bin_qty;
                    spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_FAIL_SUM].Value = d_fail_bin_qty;
                }

                d_total_bin_qty = d_pass_bin_qty = d_fail_bin_qty = 0;
                i_row = spdBinDataUnit2.ActiveSheet.RowCount - 1;

                d_total_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_TOTAL].Value);
                d_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_REMAIN].Value);
                d_pass_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_PASS_SUM].Value);
                d_fail_bin_qty = MPCF.ToDbl(spdBinDataUnit2.ActiveSheet.Cells[i_row, COL_FAIL_SUM].Value);

                txtTotalBinQty.Text = d_total_bin_qty.ToString("#######,##0.###");
                txtRemainBinQty.Text = d_bin_qty.ToString("#######,##0.###");
                txtPassBinQty.Text = d_pass_bin_qty.ToString("#######,##0.###");
                txtFailBinQty.Text = d_fail_bin_qty.ToString("#######,##0.###");
            }
            else
            {
                d_total_bin_qty = d_pass_bin_qty = d_fail_bin_qty = 0;

                for (i_row = 0; i_row < spdBinDataUnit1.ActiveSheet.RowCount; i_row++)
                {
                    d_bin_qty = MPCF.ToDbl(spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_QTY].Value);
                    d_total_bin_qty += d_bin_qty;

                    if (MPCF.Trim(spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_TYPE].Tag) == "P")
                    {
                        d_pass_bin_qty += d_bin_qty;
                    }
                    else if (MPCF.Trim(spdBinDataUnit1.ActiveSheet.Cells[i_row, COL_BIN_TYPE].Tag) == "F")
                    {
                        d_fail_bin_qty += d_bin_qty;
                    }
                }

                txtTotalBinQty.Text = d_total_bin_qty.ToString("#######,##0.###");
                txtRemainBinQty.Text = (MPCF.ToDbl(txtBinUnitQty.Tag) - d_total_bin_qty).ToString("#######,##0.###");

                txtPassBinQty.Text = d_pass_bin_qty.ToString("#######,##0.###");
                txtFailBinQty.Text = d_fail_bin_qty.ToString("#######,##0.###");
            }
        }

        private void btnLoadLastData_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtLotID, 1) == false) return;
            if (MPCF.CheckValue(txtBinID, 1) == false) return;
            if (MPCF.CheckValue(txtBinVersion, 1) == false) return;
            if (MPCF.CheckValue(txtBinUnit, 1) == false) return;

            if (ViewLatestBinCollectionData() == false) return;
            btnCalc.PerformClick();
        }




    }
}
