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
    public partial class frmWIPTranMakeSubLotBatch : Miracom.CliFrx.BaseForm03
    {
        private const int COL_LOT_ID = 1;
        private const int COL_MAT_ID = 2;
        private const int COL_MAT_VER = 3;
        private const int COL_FLOW = 4;
        private const int COL_FLOW_SEQ = 5;
        private const int COL_OPER = 6;
        private string s_crt_rule = "";

        public frmWIPTranMakeSubLotBatch()
        {
            InitializeComponent();
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            int i;
            switch (MPCF.Trim(FuncName))
            {
                case "MAKE_BATCH":


                    if (lisAddLot.Items.Count == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(199));
                        return false;
                    }

                    if (MPCF.CheckValue(cdvResID, 1) == false)
                    {
                        cdvResID.Focus();
                        return false;
                    }
                    break;

                case "VIEW":

                    if (MPCF.CheckValue(txtBatchID, 1) == false)
                    {
                        txtBatchID.Focus();
                        return false;
                    }
                    break;

                case "ATTACH_LOT":

                    for (i = 0; i < lisLotList.SelectedItems.Count; i++)
                    {
                        if (MPCF.Trim(lisLotList.SelectedItems[i].SubItems[16].Text) == "Y")//Hold Flag
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(282));
                            return false;
                        }
                        if (MPCF.Trim(lisLotList.SelectedItems[i].SubItems[41].Text) == "Y")// Start Flag
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(283));
                            return false;
                        }
                        if (MPCF.Trim(lisLotList.SelectedItems[i].SubItems[25].Text) == "Y")// Transit Flag
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(284));
                            return false;
                        }
                    }

                    break;

                case "CANCEL":

                    if (MPCF.CheckValue(txtBatchID, 1) == false)
                    {
                        txtBatchID.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(txtBatchComment, 1) == false)
                    {
                        txtBatchComment.Focus();
                        return false;
                    }

                    if (MPCF.ShowMsgBox(MPCF.GetMessage(297), MessageBoxButtons.YesNo, 1) == DialogResult.No)
                    {
                        return false;
                    }

                    break;

                case "CONFIRM":

                    if (MPCF.CheckValue(txtBatchID, 1) == false)
                    {
                        txtBatchID.Focus();
                        return false;
                    }

                    break;
            }

            return true;

        }

        private string GetMatID()
        {

            string s_temp = "";
            int i;

            if (lisAddLot.Items.Count < 1)
            {
                return s_temp;
            }

            try
            {
                s_temp = lisAddLot.Items[0].SubItems[COL_MAT_ID].Text;
                for (i = 0; i < lisAddLot.Items.Count; i++)
                {
                    if (MPCF.Trim(s_temp) != MPCF.Trim(lisAddLot.Items[i].SubItems[COL_MAT_ID].Text))
                    {
                        return "";
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return s_temp;

        }

        private int GetMatVer()
        {

            string s_temp = "";
            int i;

            if (lisAddLot.Items.Count < 1)
            {
                return 0;
            }

            try
            {
                s_temp = lisAddLot.Items[0].SubItems[COL_MAT_VER].Text;
                for (i = 0; i < lisAddLot.Items.Count; i++)
                {
                    if (MPCF.Trim(s_temp) != MPCF.Trim(lisAddLot.Items[i].SubItems[COL_MAT_VER].Text))
                    {
                        return 0;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return MPCF.ToInt(s_temp);

        }

        private string GetFlow()
        {

            string s_temp = "";
            int i;

            if (lisAddLot.Items.Count < 1)
            {
                return s_temp;
            }

            try
            {
                s_temp = lisAddLot.Items[0].SubItems[COL_FLOW].Text;
                for (i = 0; i < lisAddLot.Items.Count; i++)
                {
                    if (MPCF.Trim(s_temp) != MPCF.Trim(lisAddLot.Items[i].SubItems[COL_FLOW].Text))
                    {
                        return "";
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return s_temp;

        }

        private string GetOper()
        {

            string s_temp = "";
            int i;

            if (lisAddLot.Items.Count < 1)
            {
                return s_temp;
            }

            try
            {
                s_temp = lisAddLot.Items[0].SubItems[COL_OPER].Text;
                for (i = 0; i < lisAddLot.Items.Count; i++)
                {
                    if (MPCF.Trim(s_temp) != MPCF.Trim(lisAddLot.Items[i].SubItems[COL_OPER].Text))
                    {
                        return "";
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return s_temp;

        }

        //
        // GetResourceIDList()
        //       - Get ResourceID List by Operation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetResourceIDList()
        {

            try
            {
                if (chkReserveBatch.Checked == true && MPCF.Trim(txtBatchID.Text) != "")
                {
                    View_Reserve_Batch();
                }
                else
                {
                    cdvResID.Init();
                    MPCF.InitListView(cdvResID.GetListView);
                    cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                    cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                    cdvResID.SelectedSubItemIndex = 0;
#if _RAS
                    if (RASLIST.ViewResourceList(cdvResID.GetListView, false) == false)
                    {
                        return false;
                    }
#endif
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }


        private bool ViewBatchRelation()
        {

            TRSNode in_node = new TRSNode("VIEW_BATCH_RELATION_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_RELATION_OUT");

            chkOverriable.Checked = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

            if (MPCR.CallService("WIP", "WIP_View_Batch_Relation", in_node, ref out_node) == false)
            {
                return false;
            }

            chkManual.Checked = false;

            if (out_node.GetChar("OVERRIDE_FLAG") == 'Y')
            {
                chkOverriable.Checked = true;
                chkManual.Enabled = true;
            }
            else
            {
                chkOverriable.Checked = false;
                chkManual.Enabled = false;
            }

            return true;

        }

        private bool View_Reserve_Batch()
        {

            TRSNode in_node = new TRSNode("VIEW_RESERVE_BATCH_IN");
            TRSNode out_node = new TRSNode("VIEW_RESERVE_BATCH_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RSV_BATCH_ID", txtBatchID.Text);

            if (MPCR.CallService("WIP", "WIP_View_Reserve_Batch", in_node, ref out_node) == false)
            {
                return false;
            }

            if (MPCF.Trim(out_node.GetString("RES_ID")) != "")
            {
                cdvResID.Text = MPCF.Trim(out_node.GetString("RES_ID"));
            }
            else
            {
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;

                if (RASLIST.ViewResourceList(cdvResID.GetListView, out_node.GetString("RESG_ID"), out_node.GetString("RES_TYPE"), false) == false)
                {
                    return false;
                }
            }
            s_crt_rule = out_node.GetString("CRT_RULE_ID");
            return true;

        }

        private bool View_SubLot_List()
        {
            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");
            int i;
            ListViewItem itmX;

            MPCF.InitListView(lisLotList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetInt("SLOT_NO")), (int)SMALLICON_INDEX.IDX_SUB_LOT);

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER"));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CRR_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OWNER_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CREATE_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_STATUS"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("HOLD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("HOLD_CODE"));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3")));
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
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESERVE_RES_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_LOCATION"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_1"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_2"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_3"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_4"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_5"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_6"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_7"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_8"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_9"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_10"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_11"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_12"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_13"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_14"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_15"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_16"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_17"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_18"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_19"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_CMF_20"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("GRADE").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("GRADE_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CELL_GRADE")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_BASE").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SUBLOT_DEL_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SUBLOT_DEL_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SUBLOT_DEL_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_TRAN_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_COMMENT"));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ")));

                    itmX.Tag = "S";
                    lisLotList.Items.Add(itmX);
                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            MPCF.FitColumnHeader(lisLotList);
            return true;
        }
        private bool ViewAddLotInfo(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
            ListViewItem itmX;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SUBLOT_ID", s_lot_id);

            if (MPCR.CallService("WIP", "WIP_View_Sublot", in_node, ref out_node) == false)
            {
                return false;
            }

            itmX = new ListViewItem(((int)(lisAddLot.Items.Count + 1)).ToString(), (int)SMALLICON_INDEX.IDX_SUB_LOT);

            itmX.SubItems.Add(s_lot_id);
            itmX.SubItems.Add(out_node.GetString("MAT_ID"));
            itmX.SubItems.Add(out_node.GetInt("MAT_VER").ToString());
            itmX.SubItems.Add(out_node.GetString("FLOW"));
            itmX.SubItems.Add(out_node.GetInt("FLOW_SEQ_NUM").ToString());
            itmX.SubItems.Add(out_node.GetString("OPER"));
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("QTY_2")));
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("QTY_3")));
            itmX.SubItems.Add(out_node.GetString("CRR_ID"));
            itmX.SubItems.Add(out_node.GetString("OWNER_CODE"));
            itmX.SubItems.Add(out_node.GetString("CREATE_CODE"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_STATUS"));
            itmX.SubItems.Add(out_node.GetChar("HOLD_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("HOLD_CODE"));
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("CREATE_QTY_2")));
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("CREATE_QTY_3")));
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("OPER_IN_QTY_2")));
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("OPER_IN_QTY_3")));
            itmX.SubItems.Add(out_node.GetChar("INV_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetChar("TRANSIT_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetChar("UNIT_EXIST_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("INV_UNIT"));
            itmX.SubItems.Add(out_node.GetChar("RWK_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("RWK_CODE"));
            itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetInt("RWK_COUNT")));
            itmX.SubItems.Add(out_node.GetString("RWK_RET_FLOW"));
            itmX.SubItems.Add(out_node.GetString("RWK_RET_OPER"));
            itmX.SubItems.Add(out_node.GetString("RWK_END_FLOW"));
            itmX.SubItems.Add(out_node.GetString("RWK_END_OPER"));
            itmX.SubItems.Add(out_node.GetChar("RWK_RET_CLEAR_FLAG").ToString());
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("RWK_TIME")));
            itmX.SubItems.Add(out_node.GetChar("NSTD_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("NSTD_RET_FLOW"));
            itmX.SubItems.Add(out_node.GetString("NSTD_RET_OPER"));
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("NSTD_TIME")));
            itmX.SubItems.Add(out_node.GetChar("START_FLAG").ToString());
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("START_TIME")));
            itmX.SubItems.Add(out_node.GetString("START_RES_ID"));
            itmX.SubItems.Add(out_node.GetChar("END_FLAG").ToString());
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("END_TIME")));
            itmX.SubItems.Add(out_node.GetString("END_RES_ID"));
            itmX.SubItems.Add(out_node.GetChar("SAMPLE_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetChar("SAMPLE_WAIT_FLAG").ToString());
            switch (out_node.GetChar("SAMPLE_RESULT"))
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
            itmX.SubItems.Add(out_node.GetString("RESERVE_RES_ID"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_LOCATION"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_1"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_2"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_3"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_4"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_5"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_6"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_7"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_8"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_9"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_10"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_11"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_12"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_13"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_14"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_15"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_16"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_17"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_18"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_19"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_20"));
            itmX.SubItems.Add(out_node.GetChar("GRADE").ToString());
            itmX.SubItems.Add(out_node.GetString("GRADE_CODE"));
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("CELL_GRADE")));
            itmX.SubItems.Add(out_node.GetChar("LOT_BASE").ToString());
            itmX.SubItems.Add(out_node.GetChar("SUBLOT_DEL_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("SUBLOT_DEL_CODE"));
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("SUBLOT_DEL_TIME")));
            itmX.SubItems.Add(out_node.GetString("LAST_TRAN_CODE"));
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME")));
            itmX.SubItems.Add(out_node.GetString("LAST_COMMENT"));
            itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetInt("LAST_ACTIVE_HIST_SEQ")));
            itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetInt("LAST_HIST_SEQ")));

            itmX.Tag = "N";
            itmX.Selected = true;
            lisAddLot.Items.Add(itmX);

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
                MPCF.InitListView(lisAddLot);
                chkReserveBatch.Checked = false;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("BATCH_ID", MPCF.Trim(s_batch_id));
                

                if (MPCR.CallService("WIP", "WIP_View_Batch_Item_List", in_node, ref out_node, b_ignore_error) == false)
                {
                    in_node.Init();

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("RSV_BATCH_ID", MPCF.Trim(s_batch_id));

                    if (MPCR.CallService("WIP", "WIP_View_Reserve_Batch_Item_List", in_node, ref out_node, false) == false)
                    {
                        return false;
                    }

                    if (out_node.GetList(0).Count > 0)
                    {
                        chkReserveBatch.Checked = true;

                        View_Reserve_Batch();

                        if (cdvResID.Text != "")
                        {
                            ViewBatchRelation();
                        }
                    }
                }

                
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
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CRR_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OWNER_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CREATE_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_STATUS"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("HOLD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("HOLD_CODE"));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3")));
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
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESERVE_RES_ID"));
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
                    itmX.SubItems.Add("");
                    itmX.SubItems.Add("");
                    itmX.SubItems.Add("");
                    itmX.SubItems.Add("");
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_DEL_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOT_DEL_TIME")));
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

                    lisAddLot.Items.Add(itmX);

                    if (out_node.GetList(0)[i].GetChar("CONFIRM_FLAG") == 'C')
                    {
                        chkConfirm.Checked = true;
                        btnConfirm.Visible = false;
                        btnCancel.Visible = true;
                        btnSeq.Visible = false;
                    }
                    else
                    {
                        chkConfirm.Checked = false;
                        btnConfirm.Visible = true;
                        btnCancel.Visible = false;
                        btnSeq.Visible = false;
                    }

                }

                MPCF.FitColumnHeader(lisAddLot);
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
        //
        // Make Batch()
        //       - Make Batch
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Make_Batch(char ProcStep)
        {

            int i = 0;

            TRSNode in_node = new TRSNode("MAKE_BATCH_IN");
            TRSNode out_node = new TRSNode("MAKE_BATCH_OUT");
            TRSNode list_item;

            try
            {
                MPCR.SetInMsg(in_node);

                /* 
                * '1': Make New Batch and Confirm
                * '2': Added Item to existed batch
                * '3': Remove item from exist batch
                * '4': Change sequence of item in batch
                * '5' : Confirm the batch
                * '6' : Cancel of confirmation) 
                */

                in_node.ProcStep = ProcStep;
                in_node.AddString("MAT_ID", GetMatID());
                if (GetMatID() != "")
                {
                    in_node.AddInt("MAT_VER", GetMatVer());
                }
                in_node.AddString("FLOW", GetFlow());
                in_node.AddString("OPER", GetOper());
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddString("BATCH_COMMENT", txtBatchComment.Text);

                if (ProcStep != '2' && ProcStep != '3')
                {
                    for (i = 0; i < lisAddLot.Items.Count; i++)
                    {
                        list_item = in_node.AddNode("ITEM_LIST");

                        list_item.AddInt("SEQ_NUM", MPCF.ToInt(lisAddLot.Items[i].Text));
                        list_item.AddString("ITEM_ID", MPCF.Trim(lisAddLot.Items[i].SubItems[COL_LOT_ID].Text));
                        list_item.AddChar("ITEM_TYPE", MPCF.ToChar(lisAddLot.Items[i].Tag));
                    }
                }
                else if (ProcStep == '2')
                {
                    for (i = 0; i < lisLotList.SelectedItems.Count; i++)
                    {
                        list_item = in_node.AddNode("ITEM_LIST");

                        list_item.AddInt("SEQ_NUM", MPCF.ToInt(lisLotList.SelectedItems[i].Text));
                        list_item.AddString("ITEM_ID", MPCF.Trim(lisLotList.SelectedItems[i].SubItems[COL_LOT_ID].Text));
                        list_item.AddChar("ITEM_TYPE", MPCF.ToChar(lisLotList.SelectedItems[i].Tag));

                    }
                }
                else
                {
                    for (i = 0; i < lisAddLot.SelectedItems.Count; i++)
                    {
                        list_item = in_node.AddNode("ITEM_LIST");

                        list_item.AddInt("SEQ_NUM", MPCF.ToInt(lisAddLot.SelectedItems[i].Text));
                        list_item.AddString("ITEM_ID", MPCF.Trim(lisAddLot.SelectedItems[i].SubItems[COL_LOT_ID].Text));
                        list_item.AddChar("ITEM_TYPE", MPCF.ToChar(lisAddLot.SelectedItems[i].Tag));

                    }
                }

                if (ProcStep == '1')
                {
                    if (chkReserveBatch.Checked == true)
                    {
                        in_node.AddChar("RESERVE_FLAG", 'Y');
                    }
                }

                if ((ProcStep == '2' || ProcStep == '3' || ProcStep == '4') && chkReserveBatch.Checked == true)
                {
                    in_node.AddString("CRT_RULE_ID", s_crt_rule);

                    if (MPCR.CallService("WIP", "WIP_Make_Reserve_Batch", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (MPCR.CallService("WIP", "WIP_Make_Batch", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }

                txtBatchID.Text = out_node.GetString("BATCH_ID");

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }


        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtLotID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (MPCF.Trim(txtLotID.Text) == "") return;
            if (e.KeyChar == (char)13)
            {
                View_SubLot_List();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i, j;
            ListViewItem itmx;
            try
            {
                if (lisLotList.SelectedItems.Count < 1) return;
                if (CheckCondition("ATTACH_LOT") == false) return;

                if (txtBatchID.Text != "")
                {
                    if (Make_Batch('2') == false)
                    {
                        return;
                    }
                }

                for (i = 0; i < lisLotList.SelectedItems.Count; i++)
                {
                    if (MPCF.FindListItem(lisAddLot, lisLotList.SelectedItems[i].SubItems[COL_LOT_ID].Text, COL_LOT_ID, false) == false)
                    {
                        itmx = new ListViewItem(MPCF.Trim(lisAddLot.Items.Count + 1), (int)SMALLICON_INDEX.IDX_SUB_LOT);
                        for (j = 1; j < lisLotList.SelectedItems[i].SubItems.Count; j++)
                        {
                            itmx.SubItems.Add(lisLotList.SelectedItems[i].SubItems[j].Text);
                        }
                        itmx.Tag = "S";
                        lisAddLot.Items.Add(itmx);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int i;

            if (lisAddLot.SelectedItems.Count < 1) return;


            if (txtBatchID.Text != "")
            {
                if (Make_Batch('3') == false)
                {
                    return;
                }
            }

            while (true)
            {
                if (lisAddLot.SelectedItems.Count < 1) break;
                lisAddLot.Items[lisAddLot.SelectedItems[0].Index].Remove();
            }

            for (i = 1; i <= lisAddLot.Items.Count; i++)
            {
                lisAddLot.Items[i - 1].Text = i.ToString();
            }

        }

        private void txtNPWID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnNPWAdd.PerformClick();
            }
        }

        private void btnNPWAdd_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(this.txtNPWID, 1) == true)
            {
                ViewAddLotInfo(txtNPWID.Text);
            }
            else
            {
                txtNPWID.Focus();
            } 
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int i_idx, i;
            ListViewItem itmx;
            try
            {
                if (lisAddLot.SelectedItems.Count < 1) return;
                if (lisAddLot.SelectedItems[0].Index == 0) return;
                i_idx = lisAddLot.SelectedItems[0].Index;
                itmx = new ListViewItem(MPCF.Trim(i_idx - 1), lisAddLot.SelectedItems[0].ImageIndex);
                for (i = 1; i < lisAddLot.Items[i_idx].SubItems.Count; i++)
                {
                    itmx.SubItems.Add(lisAddLot.Items[i_idx].SubItems[i].Text);
                }
                itmx.Tag = lisAddLot.SelectedItems[0].Tag;
                lisAddLot.Items.Insert(i_idx - 1, itmx);
                lisAddLot.Items.RemoveAt(i_idx + 1);
                for (i = 1; i <= lisAddLot.Items.Count; i++)
                {
                    lisAddLot.Items[i - 1].Text = i.ToString();
                }
                lisAddLot.Items[i_idx - 1].Selected = true;
                if (btnConfirm.Visible == true)
                {
                    btnSeq.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int i_idx, i;
            ListViewItem itmx;
            if (lisAddLot.SelectedItems.Count < 1) return;
            if (lisAddLot.SelectedItems[0].Index == lisAddLot.Items.Count - 1) return;
            i_idx = lisAddLot.SelectedItems[0].Index;
            itmx = new ListViewItem(MPCF.Trim(i_idx + 2), lisAddLot.SelectedItems[0].ImageIndex);
            for (i = 1; i < lisAddLot.Items[i_idx].SubItems.Count; i++)
            {
                itmx.SubItems.Add(lisAddLot.Items[i_idx].SubItems[i].Text);
            }
            itmx.Tag = lisAddLot.SelectedItems[0].Tag;
            lisAddLot.Items.RemoveAt(i_idx);
            lisAddLot.Items.Insert(i_idx + 1, itmx);

            for (i = 1; i <= lisAddLot.Items.Count; i++)
            {
                lisAddLot.Items[i - 1].Text = i.ToString();
            }
            lisAddLot.Items[i_idx + 1].Selected = true;
            if (btnConfirm.Visible == true)
            {
                btnSeq.Visible = true;
            }
        }

        private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvResID.Text) != "")
            {
//                View_Batch_Relation();
            }
            else
            {
                MPCF.InitListView(lisAddLot);
                txtBatchID.Text = "";
                //txtBatchID.ReadOnly = false;
            }
        }
               
        private void btnMake_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("MAKE_BATCH") == true)
                {
                    if (Make_Batch('1') == false)
                    {
                        return;
                    }

                    if (View_Batch_Lot_List(txtBatchID.Text, false) == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {

            if (GetResourceIDList() == false)
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == true)
            {
                View_Batch_Lot_List(txtBatchID.Text, false);
            }
        }

        private void frmWIPTranMakeSubLotBatch_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisLotList);
            MPCF.InitListView(lisAddLot);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("MAKE_BATCH") == true)
            {
                if (Make_Batch('2') == false)
                //if (Make_Batch(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (View_Batch_Lot_List(txtBatchID.Text, false) == false)
                {
                    return;
                }
            }
        }
        private void lisLotList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisLotList.SelectedItems.Count > 0)
            {
                if (MPCF.Trim(lisLotList.SelectedItems[0].SubItems[60].Text) != "")
                {
                    txtBatchID.Text = lisLotList.SelectedItems[0].SubItems[60].Text;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CheckCondition("CONFIRM") == true)
            {
                if (Make_Batch('5') == false)
                {
                    return;
                }
                if (View_Batch_Lot_List(txtBatchID.Text, false) == false)
                {
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CheckCondition("CANCEL") == true)
            {
                if (Make_Batch('6') == false)
                {
                    return;
                }
                if (View_Batch_Lot_List(txtBatchID.Text, false) == false)
                {
                    return;
                }
            }
        }

        private void btnSeq_Click(object sender, EventArgs e)
        {
            if (txtBatchID.Text != "")
            {
                if (Make_Batch('4') == false)
                {
                    return;
                }

                btnSeq.Visible = false;
            }
        }

        private void txtBatchID_TextChanged(object sender, EventArgs e)
        {
            if (chkManual.Checked == false)
            {
                MPCF.InitListView(lisAddLot);
            }
        }

        
    }
}

