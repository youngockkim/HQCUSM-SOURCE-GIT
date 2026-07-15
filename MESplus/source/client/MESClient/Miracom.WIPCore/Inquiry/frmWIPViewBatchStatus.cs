using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPViewBatchStatus : Miracom.MESCore.ViewForm01
    {
        private int COL_BATCH = 2;
        private int COL_RSV = 4;

        public frmWIPViewBatchStatus()
        {
            InitializeComponent();
        }

        private bool View_Lot_List()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
            int i;
            ListViewItem itmX;
            int j;
            string s_rsv_batch_list;
            List<TRSNode> rsv_batch_list;

            MPCF.InitListView(lisLotList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
            in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_List_By_Operation", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(MPCF.Trim(lisLotList.Items.Count + 1), (int)SMALLICON_INDEX.IDX_LOT);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("BATCH_ID"));
                    itmX.SubItems.Add(MPCF.Format("#######,##0", out_node.GetList(0)[i].GetInt("BATCH_SEQ")));

                    s_rsv_batch_list = "";
                    rsv_batch_list = out_node.GetList(0)[i].GetList("RESERVE_BATCH_LIST");
                    for (j = 0; j < rsv_batch_list.Count; j++)
                    {
                        s_rsv_batch_list += rsv_batch_list[j].GetString("RSV_BATCH_ID");
                        if (j < rsv_batch_list.Count - 1)
                        {
                            s_rsv_batch_list += ", ";
                        }
                    }
                    itmX.SubItems.Add(s_rsv_batch_list);

                    if (j == 1 && out_node.GetList(0)[i].GetInt("BATCH_SEQ") < 1)
                    {
                        itmX.SubItems[3].Text = MPCF.Format("#######,##0", rsv_batch_list[0].GetInt("RSV_BATCH_SEQ"));
                    }

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER"));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("REMAIN_QTIME").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_TYPE").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OWNER_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CREATE_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_PRIORITY").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_STATUS"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("HOLD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("HOLD_CODE"));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3")));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_3")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("INV_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("TRANSIT_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("UNIT_EXIST_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("INV_UNIT"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RWK_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_CODE"));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("RWK_COUNT")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_RET_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_RET_OPER"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_END_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_END_OPER"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RWK_RET_CLEAR_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RWK_TIME")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("NSTD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("NSTD_RET_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("NSTD_RET_OPER"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("NSTD_TIME")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("START_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("START_RES_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("END_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("END_RES_ID"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SAMPLE_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SAMPLE_WAIT_FLAG").ToString());

                    switch (out_node.GetList(0)[i].GetChar("SAMPLE_RESULT"))
                    {
                        case 'Y':

                            itmX.SubItems.Add("Good");
                            break;
                        case 'N':

                            itmX.SubItems.Add("No Good");
                            break;
                        default:

                            itmX.SubItems.Add("");
                            break;
                    }
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FROM_TO_LOT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SHIP_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SHIP_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FAC_IN_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FLOW_IN_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("OPER_IN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESERVE_RES_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ORDER_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_1"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_2"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_3"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_LOCATION"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_1"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_2"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_3"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_4"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_5"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_6"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_7"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_8"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_9"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_10"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_11"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_12"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_13"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_14"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_15"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_16"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_17"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_18"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_19"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_20"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("BOM_SET_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("BOM_SET_VERSION").ToString());
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_ACTIVE_HIST_SEQ")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_HIST_SEQ")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOT_DEL_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_DEL_CODE"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_TRAN_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_COMMENT"));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ")));

                    if (out_node.GetList(0)[i].GetChar("HOLD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                    }
                    else if (out_node.GetList(0)[i].GetChar("START_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_START;
                    }
                    else if (out_node.GetList(0)[i].GetChar("RWK_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                    }
                    else if (out_node.GetList(0)[i].GetChar("NSTD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                    }
                    else if (out_node.GetList(0)[i].GetString("LAST_TRAN_CODE") == MPGC.MP_TRAN_CODE_RELEASE)
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                    }
                    else if (out_node.GetList(0)[i].GetChar("REP_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                    }
                    else
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                    }
                    itmX.Tag = "L"; // Lot batch item type


                    if (out_node.GetList(0)[i].GetString("BATCH_ID") != "")
                    {
                        itmX.BackColor = Color.Thistle;
                    }
                    else if (out_node.GetList(0)[i].GetList("RESERVE_BATCH_LIST").Count > 0)
                    {
                        itmX.BackColor = Color.LightYellow;
                    }

                    lisLotList.Items.Add(itmX);
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            MPCF.FitColumnHeader(lisLotList);
            return true;
        }

        private bool GetBatchResID(string s_batch_id)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            sb.Append("SELECT RES.RES_ID, RES.RES_DESC FROM MRASRESDEF RES, MWIPBATDEF BAT ");
            sb.Append("WHERE BAT.FACTORY = '" + MPGV.gsFactory + "' AND BAT.BATCH_ID = '" + s_batch_id + "' ");
            sb.Append("AND BAT.FACTORY = RES.FACTORY AND BAT.RES_ID = RES.RES_ID ");
            sb.Append("AND ROWNUM = 1 ");

            in_node.AddString("SQL", sb.ToString());

            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList("ROWS").Count > 0)
            {
                if (out_node.GetList("ROWS")[0].GetList("COLS").Count > 0)
                {
                    txtBatchResID.Text = out_node.GetList("ROWS")[0].GetList("COLS")[0].GetString("DATA");
                    txtBatchResDesc.Text = out_node.GetList("ROWS")[0].GetList("COLS")[1].GetString("DATA");
                }
            }

            return true;
        }
        
        private bool View_Batch_Lot_List(string s_batch_id, bool b_ignore_error)
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_BATCH_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_LOT_LIST_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (chkReserveBatch.Checked == false)
                {
                    in_node.AddString("BATCH_ID", MPCF.Trim(s_batch_id));
                    if (MPCR.CallService("WIP", "WIP_View_Batch_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    GetBatchResID(s_batch_id);
                }
                else
                {
                    in_node.AddString("RSV_BATCH_ID", MPCF.Trim(s_batch_id));
                    if (MPCR.CallService("WIP", "WIP_View_Reserve_Batch_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }                    
                }

                MPCF.InitListView(lisAddLot);
                if (out_node.GetList(0).Count < 1)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("SEQ_NUM").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ITEM_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER"));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("REMAIN_QTIME").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_TYPE").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OWNER_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CREATE_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_PRIORITY").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_STATUS"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("HOLD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("HOLD_CODE"));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3")));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_3")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("INV_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("TRANSIT_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("UNIT_EXIST_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("INV_UNIT"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RWK_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_CODE"));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("RWK_COUNT")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_RET_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_RET_OPER"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_END_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_END_OPER"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RWK_RET_CLEAR_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RWK_TIME")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("NSTD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("NSTD_RET_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("NSTD_RET_OPER"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("NSTD_TIME")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("START_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("START_RES_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("END_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("END_RES_ID"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SAMPLE_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SAMPLE_WAIT_FLAG").ToString());

                    switch (out_node.GetList(0)[i].GetChar("SAMPLE_RESULT"))
                    {
                        case 'Y':

                            itmX.SubItems.Add("Good");
                            break;
                        case 'N':

                            itmX.SubItems.Add("No Good");
                            break;
                        default:

                            itmX.SubItems.Add("");
                            break;
                    }
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FROM_TO_LOT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SHIP_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SHIP_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FAC_IN_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FLOW_IN_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("OPER_IN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESERVE_RES_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("BATCH_ID"));
                    itmX.SubItems.Add(MPCF.Format("#######,##0", out_node.GetList(0)[i].GetInt("BATCH_SEQ")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ORDER_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_1"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_2"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_3"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_LOCATION"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_1"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_2"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_3"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_4"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_5"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_6"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_7"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_8"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_9"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_10"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_11"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_12"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_13"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_14"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_15"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_16"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_17"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_18"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_19"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_20"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("BOM_SET_ID"));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("BOM_SET_VERSION")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_ACTIVE_HIST_SEQ")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_HIST_SEQ")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOT_DEL_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_DEL_CODE"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_TRAN_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_COMMENT"));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ")));

                    itmX.Tag = out_node.GetList(0)[i].GetChar("ITEM_TYPE");
                    if (out_node.GetList(0)[i].GetChar("ITEM_TYPE") == 'L')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                    }
                    else
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_SUB_LOT;
                    }

                    if (out_node.GetList(0)[i].GetChar("HOLD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                    }
                    else if (out_node.GetList(0)[i].GetChar("START_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_START;
                    }
                    else if (out_node.GetList(0)[i].GetChar("RWK_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                    }
                    else if (out_node.GetList(0)[i].GetChar("NSTD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                    }
                    else if (out_node.GetList(0)[i].GetString("LAST_TRAN_CODE") == MPGC.MP_TRAN_CODE_RELEASE)
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                    }
                    else if (out_node.GetList(0)[i].GetChar("REP_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                    }
                    else
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                    }

                    lisAddLot.Items.Add(itmX);
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private void cdvMaterial_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.InitListView(lisLotList);
            cdvFlow.Text = "";
            cdvOper.Text = "";
        }

        private void cdvMaterial_VersionSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.InitListView(lisLotList);
            cdvFlow.Text = "";
            cdvOper.Text = "";
        }

        private void cdvFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.InitListView(lisLotList);
            cdvOper.Text = "";
        }
        
        private void cdvFlow_ButtonPress(object sender, EventArgs e)
        {
            cdvFlow.Init();
            MPCF.InitListView(cdvFlow.GetListView);
            cdvFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            if (MPCF.Trim(cdvMaterial.Text) == "")
            {
                if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "") == false)
                {
                    return;
                }
            }
            else
            {
                if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '2', cdvMaterial.Text, cdvMaterial.Version, "", null, "") == false)
                {
                    return;
                }
            }

            cdvFlow.AddEmptyRow(1);

        }

        private void cdvOper_ButtonPress(object sender, EventArgs e)
        {
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            if (cdvMaterial.Text != "" && cdvFlow.Text != "")
            {
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
            }
            else if (cdvMaterial.Text == "" && cdvFlow.Text != "")
            {
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '2', "", 0, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
            }
            else if (cdvMaterial.Text != "" && cdvFlow.Text == "")
            {
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, "", "", null, "") == false)
                {
                    return;
                }
            }
            else if (cdvMaterial.Text == "" && cdvFlow.Text == "")
            {
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '1', "", 0, "", "", null, "") == false)
                {
                    return;
                }
            }
            cdvOper.AddEmptyRow(1);
        }

        private void cdvOper_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnViewLotList.PerformClick();
            }
        }

        private void cdvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnViewLotList.PerformClick();
        }

        private void btnViewLotList_Click(object sender, EventArgs e)
        {
            View_Lot_List();
        }

        private void lisLotList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MPCF.InitListView(lisAddLot);
            if (lisLotList.SelectedItems.Count < 1) return;
            if (MPCF.Trim(lisLotList.SelectedItems[0].SubItems[COL_BATCH].Text) != "")
            {
                txtBatchID.Text = lisLotList.SelectedItems[0].SubItems[COL_BATCH].Text;
                chkReserveBatch.Checked = false;

                View_Batch_Lot_List(txtBatchID.Text, true);
            }
            else if (MPCF.Trim(lisLotList.SelectedItems[0].SubItems[COL_RSV].Text) != "")
            {
                txtBatchID.Text = lisLotList.SelectedItems[0].SubItems[COL_RSV].Text;
                chkReserveBatch.Checked = true;
                
                View_Batch_Lot_List(txtBatchID.Text, true);
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (MPCF.Trim(txtBatchID.Text) != "")
            {
                View_Batch_Lot_List(txtBatchID.Text, true);
            }
        }

        private void txtBatchID_TextChanged(object sender, EventArgs e)
        {
            MPCF.InitListView(lisAddLot);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;
            sCond = "Mat ID : " + MPCF.Trim(cdvMaterial.Text) + "\r";
            sCond = sCond + "Version : " + cdvMaterial.Version + "\r";
            sCond = sCond + "Flow : " + MPCF.Trim(cdvFlow.Text) + "\r";
            sCond = sCond + "Batch ID : " + MPCF.Trim(cdvFlow.Text) + "\r";
            if(chkReserveBatch.Checked)
                sCond = sCond + "Reserved : Y\r";
            else
                sCond = sCond + "Reserved : N\r";

            if (lisAddLot.Items.Count != 0)
            {
                if (MPCF.ExportToExcel(lisAddLot, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
        }


}

}
