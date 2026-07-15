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


namespace Miracom.WIPCore
{
    public partial class frmWIPViewBatchHistory : Miracom.MESCore.ViewForm01
    {
        public frmWIPViewBatchHistory()
        {
            InitializeComponent();
        }

        private bool ViewLotHistory()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_HISTORY_OUT");
            int i;
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;
            int iCol;
            TRSNode his;

            try
            {

                MPCF.ClearList(spdHistory);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("FROM_TRAN_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TRAN_TIME", MPCF.ToDate(dtpTo));
                in_node.AddInt("HIST_SEQ", int.MaxValue);

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Lot_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        his = out_node.GetList(0)[i];
                        sheetX = spdHistory.ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        iCol = 0;

                        if (his.GetChar("HIST_DEL_FLAG") == 'Y')
                        {
                            sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            sheetX.Cells[iRow, 1, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        sheetX.Cells[iRow, iCol].Value = his.GetInt("HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("BATCH_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("TRAN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("FACTORY");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("MAT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("MAT_VER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("QTY_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("CRR_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("LOT_TYPE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("OWNER_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("CREATE_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("CREATE_TIME")); // HyunJone Noh

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("LOT_PRIORITY");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_STATUS");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("LOT_DEL_TIME")); // HyunJone Noh

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("HOLD_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("HOLD_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("HOLD_PRV_GRP_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OPER_IN_QTY_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OPER_IN_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OPER_IN_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("CREATE_QTY_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("CREATE_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("CREATE_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("START_QTY_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("START_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("START_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("INV_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("TRANSIT_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("UNIT_EXIST_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("INV_UNIT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("RWK_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("RWK_COUNT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_RET_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("RWK_RET_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_RET_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_END_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("RWK_END_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RWK_END_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("RWK_RET_CLEAR_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("RWK_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("NSTD_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("NSTD_RET_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("NSTD_RET_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("NSTD_RET_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("NSTD_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("REP_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("REP_RET_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("STR_RET_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("STR_RET_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("STR_RET_OPER");
                                    
                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("START_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("START_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("START_RES_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("END_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("END_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("END_RES_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("SAMPLE_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("SAMPLE_WAIT_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("SAMPLE_RESULT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("FROM_TO_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("FROM_TO_LOT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("FROM_TO_MAT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("FROM_TO_MAT_VER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("FROM_TO_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("FROM_TO_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("FROM_TO_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("FROM_TO_QTY_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("FROM_TO_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("FROM_TO_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("FROM_TO_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("SHIP_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("SHIP_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("FAC_IN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("FLOW_IN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("OPER_IN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RESERVE_RES_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("ORDER_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("ADD_ORDER_ID_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("ADD_ORDER_ID_2");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("ADD_ORDER_ID_3");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_LOCATION");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_2");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_3");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_4");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_5");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_6");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_7");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_8");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_9");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_10");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_11");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_12");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_13");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_14");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_15");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_16");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_17");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_18");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_19");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_CMF_20");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("LOT_DEL_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_DEL_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("BOM_SET_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("BOM_SET_VERSION");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("BOM_ACTIVE_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("BOM_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("CRITICAL_RES_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("CRITICAL_RES_GROUP_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("SAVE_RES_ID_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("SAVE_RES_ID_2");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("SUBRES_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_GROUP_ID_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_GROUP_ID_2");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LOT_GROUP_ID_3");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_2");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_3");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_4");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("RESV_FIELD_5");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_2");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_3");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_4");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("RESV_FLAG_5");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_FACTORY");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_MAT_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("OLD_MAT_VER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_FLOW");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("OLD_FLOW_SEQ_NUM");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OLD_QTY_1"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OLD_QTY_2"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", his.GetDouble("OLD_QTY_3"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("OLD_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("OLD_LOT_TYPE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_OWNER_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("OLD_CREATE_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("OLD_FAC_IN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("OLD_FLOW_IN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("OLD_OPER_IN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_2");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_3");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_4");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_5");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_6");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_7");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_8");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_9");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_10");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_11");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_12");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_13");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_14");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_15");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_16");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_17");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_18");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_19");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_CMF_20");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_USER_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("TRAN_COMMENT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("PREV_ACTIVE_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("MULTI_TR_KEY");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("MULTI_TR_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetChar("HIST_DEL_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("HIST_DEL_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("HIST_DEL_USER_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("HIST_DEL_COMMENT");

                        /////////////////////////////////////////////////////////////////
                        // HyunJong Noh 이하추가.            
                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("LAST_ACTIVE_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetInt("LAST_HIST_SEQ");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LAST_TRAN_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("LAST_TRAN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = his.GetString("LAST_COMMENT");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(his.GetString("SYS_TRAN_TIME"));
                        // HyunJong Noh 이상추가.
                        /////////////////////////////////////////////////////////////////
                    }

                    in_node.SetInt("HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                } while (in_node.GetInt("HIST_SEQ") > 0);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ViewBatchHistory()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_HISTORY_OUT");
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;
            int iCol;
            int i;
            try
            {

                MPCF.ClearList(spdBatch);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Batch_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sheetX = spdBatch.ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;
                        iCol = 0;

                        sheetX.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_CODE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ITEM_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("SEQ_NUM").ToString();

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("ITEM_TYPE").ToString();

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("ITEM_HIST_SEQ").ToString();

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("CONFIRM_FLAG");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RESG_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_TYPE");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CRT_RULE_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("GEN_RULE_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("BATCH_COMMENT");
                    }

                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
                    in_node.SetString("NEXT_TRAN_TIME", out_node.GetString("NEXT_TRAN_TIME"));
                } while (in_node.GetInt("NEXT_SEQ_NUM") > 0 || in_node.GetString("NEXT_TRAN_TIME") != "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        
        private void frmWIPViewBatchHistory_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            MPCF.ClearList(spdHistory);
            MPCF.ClearList(spdBatch);
            txtLotID.Focus();
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
           
            MPCF.ClearList(spdBatch, true);
          
            if (txtBatchID.Text != "")
            {
                if (ViewBatchHistory() == false)
                {
                    return;
                }

                MPCF.FitColumnHeader(spdBatch);
            }
        }

        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnViewLotList.PerformClick();
            }
        }

        private void txtLotID_TextChanged(object sender, EventArgs e)
        {
            MPCF.ClearList(spdHistory);
        }

        private void txtBatchID_TextChanged(object sender, EventArgs e)
        {
            MPCF.ClearList(spdBatch);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;
            sCond = "Lot ID : " + MPCF.Trim(txtLotID.Text) + "\r";
            sCond = sCond + "Batch ID : " + txtBatchID.Text + "\r";
            sCond = sCond + "Period : " + MPCF.Trim(dtpFrom.Value) + "~" + MPCF.Trim(dtpTo.Value) + "\r";

            if (MPCF.ExportToExcel(spdHistory, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }

        private void btnViewLotList_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdHistory, true);

            if (txtLotID.Text != "")
            {
                if (ViewLotHistory() == false)
                {
                    return;
                }

                MPCF.ClearList(spdBatch, true);
                txtBatchID.Clear();
                MPCF.FitColumnHeader(spdHistory);
            }
        }

        private void spdHistory_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string s_batch_id;

            if(e.RowHeader == true) return;
            if(e.ColumnHeader == true) return;

            s_batch_id = MPCF.Trim(spdHistory.ActiveSheet.Cells[e.Row, 1].Value);
            if (s_batch_id != "")
            {
                txtBatchID.Text = s_batch_id;

                btnView.PerformClick();
            }
        }
    }
}

