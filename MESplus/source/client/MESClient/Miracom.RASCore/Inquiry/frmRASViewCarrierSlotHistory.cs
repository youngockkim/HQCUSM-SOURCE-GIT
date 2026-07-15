//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASViewCarrierSlotHistory.cs
//   Description : View Carrier Slot History
//
//   MES Version : 5.1
//
//   Function List
//       - CheckCondition()      : Check the conditions before transaction
//       - ClearData()           : Clear Fields and Initialize Sheet
//       - InitCodeView()        : Initialize MCCodeView
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2009-10-14 : Created by Aiden Koo
//
//
//   Copyright(C) 1998-2009 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.TRSCore;
using Miracom.MESCore;
using Miracom.CliFrx;

namespace Miracom.RASCore
{
    public partial class frmRASViewCarrierSlotHistory : Miracom.MESCore.ViewForm01
    {
        public frmRASViewCarrierSlotHistory()
        {
            InitializeComponent();
        }

#if _CRR

        #region " Constant Definition"

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        // ViewCarrierSlotHistory()
        //       - View Carrier Slot History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool ViewCarrierSlotHistory()
        {
            TRSNode in_node = new TRSNode("VIEW_CARRIER_SLOT_HISTORY_IN");
            TRSNode out_node;
            int i;
            int j;
            int i_crr_size;
            int i_slot_no;
            int i_seq;
            int i_col;
            string s_tran_code;
            ArrayList a_out;
            List<TRSNode> hist_list;
            List<TRSNode> slot_list;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("CRR_ID", cdvCarrierID.Text);

                if (chkPeriod.Checked == true)
                {
                    in_node.AddString("FROM_TRAN_TIME", MPCF.FromDate(dtpFrom));
                    in_node.AddString("TO_TRAN_TIME", MPCF.ToDate(dtpTo));
                }

                spdList.SuspendLayout();
                MPCF.ClearList(spdDetail);

                i_crr_size = 0;
                a_out = new ArrayList();

                do
                {
                    out_node = new TRSNode("VIEW_CARRIER_SLOT_HISTORY_OUT");

                    if (MPCR.CallService("RAS", "RAS_View_Carrier_Slot_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if(i_crr_size < 1)
                    {
                        i_crr_size = out_node.GetInt("CRR_SIZE");
                    }
    
                    a_out.Add(out_node);

                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                    in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

                } while (in_node.GetInt("NEXT_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0 || in_node.GetInt("NEXT_HIST_SEQ") > 0);

                /* Trace information */
                spdList.ActiveSheet.RowCount = 3 + i_crr_size;
                if (spdList.ActiveSheet.ColumnCount - 5 > 0)
                {
                    spdList.ActiveSheet.RemoveColumns(0, spdList.ActiveSheet.ColumnCount - 5);
                }
                spdList.ActiveSheet.ClearRange(3, 1, i_crr_size, 4, true);

                foreach (object obj in a_out)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    hist_list = out_node.GetList("HIST_LIST");

                    for (i = 0; i < hist_list.Count; i++)
                    {
                        spdList.ActiveSheet.AddColumns(0, 5);
                        spdList.ActiveSheet.CopyRange(0, 5, 0, 0, 3 + i_crr_size, 5, false);

                        spdList.ActiveSheet.Columns[0].Width = 30;
                        spdList.ActiveSheet.Columns[0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdList.ActiveSheet.Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdList.ActiveSheet.Columns[1].Width = 50;
                        spdList.ActiveSheet.Columns[1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdList.ActiveSheet.Columns[1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdList.ActiveSheet.Columns[2].Width = 100;
                        spdList.ActiveSheet.Columns[2].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdList.ActiveSheet.Columns[2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        spdList.ActiveSheet.Columns[3].Width = 100;
                        spdList.ActiveSheet.Columns[3].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdList.ActiveSheet.Columns[3].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        spdList.ActiveSheet.Columns[4].Width = 42;
                        spdList.ActiveSheet.Columns[4].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdList.ActiveSheet.Columns[4].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                        slot_list = hist_list[i].GetList("SLOT_LIST");

                        spdList.ActiveSheet.Cells[0, 8].Value = MPCF.MakeDateFormat(slot_list[0].GetString("TRAN_TIME"));
                        spdList.ActiveSheet.Cells[1, 8].Value = slot_list[0].GetString("TRAN_USER_ID");

                        for (j = 0; j < i_crr_size; j++)
                        {
                            spdList.ActiveSheet.Cells[3 + j, 6].Value = j + 1;
                            spdList.ActiveSheet.Cells[3 + j, 5].Border =
                                new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                                                               new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                                                               new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine),
                                                               new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
                            spdList.ActiveSheet.Cells[3 + j, 6, 3 + j, 9].Border =
                                new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                                                               new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                                                               new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine),
                                                               new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
                        }

                        if (spdList.ActiveSheet.ColumnCount > 12)
                        {
                            for (j = 0; j < i_crr_size; j++)
                            {
                                if (spdList.ActiveSheet.Cells[3 + j, 12].Value != null && 
                                    spdList.ActiveSheet.Cells[3 + j, 12].Value.ToString() != "" &&
                                    spdList.ActiveSheet.Cells[3 + j, 12].Note != "DETACH")
                                {
                                    spdList.ActiveSheet.Cells[3 + j, 7].Value = spdList.ActiveSheet.Cells[3 + j, 12].Value;
                                    spdList.ActiveSheet.Cells[3 + j, 8].Value = spdList.ActiveSheet.Cells[3 + j, 13].Value;
                                    spdList.ActiveSheet.Cells[3 + j, 9].Value = spdList.ActiveSheet.Cells[3 + j, 14].Value;
                                }
                            }
                        }

                        for (j = 0; j < slot_list.Count; j++)
                        {
                            i_slot_no = slot_list[j].GetInt("SLOT_NO");

                            if (i_slot_no + 3 >= spdList.ActiveSheet.RowCount)
                            {
                                int k;
                                int i_row;
                                int i_add_count;

                                i_add_count = (i_slot_no + 3) - spdList.ActiveSheet.RowCount;

                                for (k = 0; k < i_add_count; k++)
                                {
                                    i_row = spdList.ActiveSheet.RowCount;
                                    spdList.ActiveSheet.RowCount++;

                                    spdList.ActiveSheet.Cells[i_row, 6].Value = i_row - 2;
                                    spdList.ActiveSheet.Cells[i_row, 5].Border =
                                        new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                                                                       new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                                                                       new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine),
                                                                       new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
                                    spdList.ActiveSheet.Cells[i_row, 6, i_row, 9].Border =
                                        new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                                                                       new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                                                                       new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine),
                                                                       new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));

                                }
                            }

                            i_slot_no--;

                            s_tran_code = slot_list[j].GetString("TRAN_CODE");

                            spdList.ActiveSheet.Cells[3 + i_slot_no, 7].Note = s_tran_code;
                            spdList.ActiveSheet.Cells[3 + i_slot_no, 7].Value = slot_list[j].GetString("SUBLOT_ID");
                            spdList.ActiveSheet.Cells[3 + i_slot_no, 8].Value = slot_list[j].GetString("LOT_ID");
                            spdList.ActiveSheet.Cells[3 + i_slot_no, 9].Value = slot_list[j].GetChar("GRADE");

                            if (s_tran_code == "DETACH")
                            {
                                spdList.ActiveSheet.Cells[3 + i_slot_no, 7, 3 + i_slot_no, 9].ForeColor = Color.DarkGray;
                            }
                            else
                            {
                                spdList.ActiveSheet.Cells[3 + i_slot_no, 7, 3 + i_slot_no, 9].ForeColor = Color.Black;
                            }

                        }
                    }
                }

                if (spdList.ActiveSheet.ColumnCount > 7)
                {
                    spdList.ActiveSheet.RemoveColumns(0, 5);
                    spdList.ActiveSheet.RowHeader.Visible = false;
                    spdList.ActiveSheet.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
                    spdList.ActiveSheet.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
                    spdList.ActiveSheet.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);

                    spdList.ResumeLayout();
                    spdList.Visible = true;
                }
                else
                {
                    spdList.ResumeLayout();
                    spdList.Visible = false;
                }


                /* Detail information */
                spdDetail.SuspendLayout();
                foreach (object obj in a_out)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    hist_list = out_node.GetList("HIST_LIST");

                    for (i = 0; i < hist_list.Count; i++)
                    {
                        i_seq = hist_list[i].GetInt("CRR_SLOT_HIST_SEQ");
                        slot_list = hist_list[i].GetList("SLOT_LIST");

                        spdDetail.ActiveSheet.Rows.Add(0, slot_list.Count);
                        if (i_seq % 2 == 0)
                        {
                            spdDetail.ActiveSheet.Rows[0, slot_list.Count - 1].BackColor = Color.WhiteSmoke;
                        }

                        for (j = 0; j < slot_list.Count; j++)
                        {
                            i_col = 0;
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = i_seq;
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetInt("SLOT_NO");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetInt("HIST_SEQ");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.MakeDateFormat(slot_list[j].GetString("TRAN_TIME"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CODE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_ID");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetInt("SUBLOT_HIST_SEQ");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetInt("CRR_HIST_SEQ");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("OLD_SUBLOT_ID");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetInt("OLD_SUBLOT_HIST_SEQ");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetInt("OLD_CRR_HIST_SEQ");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_USER_ID");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_TRAN_CODE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("LOT_ID");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("FACTORY");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("MAT_ID");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetInt("MAT_VER");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("FLOW");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetInt("FLOW_SEQ_NUM");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("OPER");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.Format("####,##0.###", slot_list[j].GetDouble("QTY_2"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.Format("####,##0.###", slot_list[j].GetDouble("QTY_3"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("OWNER_CODE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("CREATE_CODE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_STATUS");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("HOLD_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("HOLD_CODE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.Format("####,##0.###", slot_list[j].GetDouble("OPER_IN_QTY_2"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.Format("####,##0.###", slot_list[j].GetDouble("OPER_IN_QTY_3"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.Format("####,##0.###", slot_list[j].GetDouble("CREATE_QTY_2"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.Format("####,##0.###", slot_list[j].GetDouble("CREATE_QTY_3"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.Format("####,##0.###", slot_list[j].GetDouble("START_QTY_2"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.Format("####,##0.###", slot_list[j].GetDouble("START_QTY_3"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("INV_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("TRANSIT_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("UNIT_EXIST_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("INV_UNIT");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("RWK_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("RWK_CODE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.MakeDateFormat(slot_list[j].GetString("RWK_TIME"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("NSTD_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.MakeDateFormat(slot_list[j].GetString("NSTD_TIME"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("REP_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("START_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.MakeDateFormat(slot_list[j].GetString("START_TIME"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("START_RES_ID");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("END_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = MPCF.MakeDateFormat(slot_list[j].GetString("END_TIME"));
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("END_RES_ID");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("SAMPLE_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("SAMPLE_WAIT_FLAG");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("SAMPLE_RESULT");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("RESERVE_RES_ID");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("PORT_ID");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_LOCATION_1");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_LOCATION_2");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_LOCATION_3");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("GRADE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("GRADE_CODE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("CELL_GRADE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetChar("LOT_BASE");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetInt("LOT_HIST_SEQ");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_1");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_2");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_3");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_4");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_5");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_6");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_7");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_8");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_9");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_10");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_11");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_12");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_13");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_14");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_15");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_16");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_17");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_18");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_19");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("SUBLOT_CMF_20");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_1");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_2");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_3");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_4");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_5");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_6");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_7");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_8");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_9");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_10");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_11");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_12");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_13");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_14");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_15");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_16");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_17");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_18");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_19");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_CMF_20");
                            spdDetail.ActiveSheet.Cells[j, i_col++].Value = slot_list[j].GetString("TRAN_COMMENT");
                        }
                    }
                }

                MPCF.FitColumnHeader(spdDetail);
                spdDetail.ResumeLayout();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        
        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvCarrierID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmRASViewCarrierSlotHistory_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                b_load_flag = true;

                dtpFrom.Value = DateTime.Today.AddMonths(-3);
                dtpTo.Value = DateTime.Today;

                chkPeriod.Checked = false;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;

                spdList.Visible = false;
                spdList.ActiveSheet.RowHeader.Visible = false;
                spdList.ActiveSheet.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
                
                if (MPGO.RequireCarrierFilter() == true)
                {
                    lblOr.Visible = true;
                }
                
                if (MPCF.Trim(MPGV.gsCurrentCrrID) != "")
                {
                    cdvCarrierID.Text = MPGV.gsCurrentCrrID;
                    cdvCarrierID_SelectedItemChanged(null, null);
                    MPGV.gsCurrentCrrID = "";
                }
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Carrier Type : " + MPCF.Trim(cdvCarrierType.Text) + "\r";
            sCond = sCond + "Carrier Group : " + MPCF.Trim(cdvCrrGroup.Text) + "\r";
            sCond = sCond + "Carrier ID : " + MPCF.Trim(cdvCarrierID.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));

            if (tabView.SelectedTab == tbpTrace)
            {
                MPCF.ExportToExcel(spdList, this.Text, sCond);
            }
            else
            {
                MPCF.ExportToExcel(spdDetail, this.Text, sCond);
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            ViewCarrierSlotHistory();
        }

        private void cdvCarrierType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCarrierType.Init();
            MPCF.InitListView(cdvCarrierType.GetListView);
            cdvCarrierType.Columns.Add("Carrier Type", 50, HorizontalAlignment.Left);
            cdvCarrierType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCarrierType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCarrierType.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            cdvCarrierType.InsertEmptyRow(0, 1);
        }

        private void cdvCarrierType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvCarrierType.Text) != "")
            {
                cdvCarrierID.Text = "";
            }
        }

        private void cdvCrrGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvCrrGroup.Init();
            MPCF.InitListView(cdvCrrGroup.GetListView);
            cdvCrrGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvCrrGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierGroupList(cdvCrrGroup.GetListView);
            cdvCrrGroup.InsertEmptyRow(0, 1);
        }

        private void cdvCrrGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvCrrGroup.Text) != "")
            {
                cdvCarrierID.Text = "";
            }
        }

        private void cdvCarrierID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnView.PerformClick();
        }

        private void cdvCarrierID_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvCarrierID.Text != "")
                {
                    btnView.PerformClick();
                }
            }

        }

        private void cdvCarrierID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            if (MPCF.Trim(cdvCrrGroup.Text) == "" && MPCF.Trim(cdvCarrierType.Text) == "")
            {
                if (MPGO.RequireCarrierFilter() == true)
                {
                    if (MPCF.Trim(cdvCarrierID.Text) == "")
                    {
                        cdvCarrierID.IsPopup = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(258));
                        cdvCarrierID.Focus();
                        return;
                    }
                }
            }

            cdvCarrierID.Init();
            MPCF.InitListView(cdvCarrierID.GetListView);
            cdvCarrierID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCarrierID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCarrierID.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierList(cdvCarrierID.GetListView, '1', cdvCrrGroup.Text, cdvCarrierType.Text, cdvCarrierID.Text);
        }

        private void chkPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPeriod.Checked == true)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }



#endif

    }
}

