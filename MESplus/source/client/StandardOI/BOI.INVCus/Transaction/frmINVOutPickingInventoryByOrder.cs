using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx;
using SOI.DNM;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVOutPickingInventoryByOrder : BOIBaseForm02
    {
        #region Enum

        public enum ColReqMst
        {
            TRS_NO = 0,
            TRS_DATE,
            FROM_OPER,
            TO_OPER,
            REASON,
            TRS_STS
        }

        public enum ColReqDtl
        {
            MAT_ID = 0,
            MAT_DESC,
            UNIT_1,
            REQ_QTY,
            PICKING_QTY,
            TRAN_QTY,
            REMAIN_QTY,
            SCAN_QTY,
            TRS_NO,
            TRS_NO_SEQ
        }

        public enum ColReqLot
        {
            SELECT = 0,
            LOT_ID,
            MATERIAL,
            MATERIAL_DESC,
            QTY,
            UNIT
        }



        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;

        private cinvReqMstOrder reqMst = null;
        private cinvReqDtlOrder reqDtl = null;
        //private List<cinvReqDtlOrder> lisReqDtl = null;
        //private List<cinvReqLotOrder> lisReqLot = null;


        #endregion

        #region Constructor

        public frmINVOutPickingInventoryByOrder()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            MPCF.FitColumnHeader(spdReqDtlMove);
            MPCF.FitColumnHeader(spdReqLotMove);
            cdvToStore.Tag = "";

        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                
                InvisibleColumn();
                LockColumn();
                initSpread();

                //GetDefaultValueFromReg();

                dtpMoveDate.SetValueAsDateTime(DateTime.Now);

                // (Required) 
                bIsShown = true;
            }
        }

        private void txtLotId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string slotId = string.Empty;
                string smatId = string.Empty;
                string sTrsNo = string.Empty;
                double lotQty = 0.0d;
                double lotQtysum = 0.0d;
                double dTranQty = 0.0d;
                double dReqQty = 0.0d;
                double dRemainQty = 0.0d;
                double dpickingQty = 0.0d;
                string smatDesc = string.Empty;
                string sunit = string.Empty;
                //cinvReqDtlOrder reqDtl = null;
                cinvReqLotOrder reqLot = null;
                bool bMatChecke = false;
                int irow = 0;
                int iactiveRow = 0;
                int iTrsNoSeq = 0;
                if (e.KeyValue == (char)13)
                {

                    //if (MPCF.CheckValue(cdvFromStore, false) == false)
                    //{
                    //    return;
                    //}

                    //if (MPCF.CheckValue(cdvToStore, false) == false)
                    //{
                    //    return;
                    //}

                    if (MPCF.CheckValue(cdvReasonMove, false) == false)
                    {
                        return;
                    }


                    TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                    TRSNode out_node = new TRSNode("VIEW_LOT_OUT");


                    slotId = MPCF.Trim(txtLotId.Text);

                    for (int i = 0; i < spdReqLotMove.Sheets[0].RowCount; i++)
                    {
                        if (MPCF.Trim(spdReqLotMove.Sheets[0].GetValue(i, (int)ColReqLot.LOT_ID)) == MPCF.Trim(slotId))
                        {
                            //CMN164 ERROR - 이 Lot은 이미 존재 합니다. Lot을 확인 하세요.
                            MPCF.ShowMessage(MPCF.GetMessage(164), MSG_LEVEL.ERROR, true);
                            spdReqLotMove.Sheets[0].ActiveRowIndex = i;
                            spdReqLotMove.Sheets[0].SetActiveCell(i, 0, true);
                            return;
                        }
                    }


                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '2';
                    in_node.AddString("LOT_ID", slotId);

                    if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                    {
                        return;
                    }
                    if (out_node.GetString("LOT_CMF_11") == "Y")
                    {
                        //CMN379 ERROR - 이 Lot 은 이미 다른 의 요청 에 할당되어 있습니다.
                        MPCF.ShowMessage(MPCF.GetMessage(379), MSG_LEVEL.ERROR, true);
                        return;
                    }
                    if (out_node.GetDouble("QTY_1") <= 0.00d)
                    {
                        //CMN380 CONFIRM - Lot의 Quantity가 0입니다. Lot을 확인하세요.
                        MPCF.ShowMessage(MPCF.GetMessage(380), MSG_LEVEL.ERROR, true);
                        txtLotId.Focus();
                        txtLotId.SelectAll();
                        return;
                    }
                    //if (cdvFromStore.Tag.ToString() != out_node.GetString("OPER"))
                    //{
                    //    //CMN412 ERROR - 출발 공정이 대상 LOT 공정과 상이합니다.
                    //    MPCF.ShowMessage(MPCF.GetMessage(412), MSG_LEVEL.ERROR, true);
                    //    return;
                    //}

                    for (int j = 0; j < spdReqDtlMove.Sheets[0].RowCount; j++)
                    {
                        if (MPCF.Trim(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.MAT_ID)) == MPCF.Trim(out_node.GetString("MAT_ID")))
                        {
                            bMatChecke = true;
                            smatId = MPCF.Trim(out_node.GetString("MAT_ID"));
                            lotQty = MPCF.ToDbl(out_node.GetDouble("QTY_1"));
                            lotQtysum = MPCF.ToDbl(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.SCAN_QTY)) + MPCF.ToDbl(out_node.GetDouble("QTY_1"));

                            dReqQty = MPCF.ToDbl(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.REQ_QTY));
                            dTranQty = MPCF.ToDbl(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.TRAN_QTY));
                            dpickingQty = MPCF.ToDbl(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.PICKING_QTY));
                            dRemainQty = MPCF.ToDbl(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.REMAIN_QTY));
                            iTrsNoSeq = MPCF.ToInt(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.TRS_NO_SEQ));
                            //sTrsNo = MPCF.Trim(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.TRS_NO));
                            irow = j;

                            //////////////////////////////////////////////////////////////////////////////////////////////
                            int i_active_master_row = 0;
                            reqMst = new cinvReqMstOrder("CINVREQMST_IN");
                            MPCF.SetInMsg(reqMst);
                            reqMst.ProcStep = '1';
                            reqMst.TrsNo = MPCF.Trim(spdReqMstMove.Sheets[0].GetValue(i_active_master_row, (int)ColReqMst.TRS_NO));//  dt.Rows[i]["TRS_NO"].ToString());
                            reqMst.ReqType = MPCF.Trim(BIGC.B_REQ_TYPE_SHIP);
                            reqMst.MoveDate = MPCF.Trim(dtpMoveDate.GetValueAsString(8));
                            reqMst.MoveTime = MPCF.Trim(dtpMoveDate.GetValueAsString(8)) + MPCF.Trim(DateTime.Now.ToString("HHmmss"));
                            reqMst.ReqUserId = MPCF.Trim(reqMst.UserID);
                            reqMst.ReqStatus = 'R';
                            reqMst.FromFactory = MPCF.Trim(MPGV.gsFactory);
                            reqMst.FromStore = MPCF.Trim(cdvFromStore.Tag);
                            reqMst.ToStore = MPCF.Trim(spdReqMstMove.Sheets[0].GetValue(i_active_master_row, (int)ColReqMst.TO_OPER));
                            reqMst.ToStoreDesc = MPCF.Trim(spdReqMstMove.Sheets[0].GetValue(i_active_master_row, (int)ColReqMst.TO_OPER)); //////// desc 나오도록 수정할것
                            reqMst.ReasonDtl = MPCF.Trim(cdvReasonMove.Tag);
                            reqMst.ToFactory = MPCF.Trim(MPGV.gsFactory);

                            reqMst.ReasonDtlDesc = MPCF.Trim(cdvReasonMove.Value);
                            reqMst.FromStoreDesc = MPCF.Trim(cdvFromStore.Value);
                            reqMst.ToStoreDesc = MPCF.Trim(cdvToStore.Value);

                            reqDtl = new cinvReqDtlOrder("CINVORDDTL_IN");
                            MPCF.SetInMsg(reqDtl);
                            reqDtl.TrsNo = MPCF.Trim(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.TRS_NO));
                            reqDtl.TrsNoSeq = MPCF.ToInt(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.TRS_NO_SEQ));
                            reqDtl.MatId = MPCF.Trim(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.MAT_ID));
                            reqDtl.MatDesc = MPCF.Trim(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.MAT_DESC));
                            reqDtl.Unit = MPCF.Trim(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.UNIT_1));
                            reqDtl.ReqQty = MPCF.ToDbl(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.REQ_QTY));
                            reqDtl.PickingQty = MPCF.ToDbl(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.PICKING_QTY));
                            reqDtl.TranQty = MPCF.ToDbl(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.TRAN_QTY));
                            reqDtl.RemainQty = MPCF.ToDbl(spdReqDtlMove.Sheets[0].GetValue(j, (int)ColReqDtl.REMAIN_QTY));
                            reqMst.AddReqDtl(reqDtl);

                            //////////////////////////////////////////////////////////////////////////////////////////////
                        }
                       
                    }

                    if (bMatChecke == false)
                    {
                        //CMN430 ERROR - List 에 없는 제품번호 입니다.
                        MPCF.ShowMessage(MPCF.GetMessage(430), MSG_LEVEL.ERROR, true);
                        return;
                    }

                    smatDesc = MPCF.Trim(out_node.GetString("MAT_DESC"));
                    sunit = MPCF.Trim(out_node.GetString("UNIT_1"));

                    //reqDtl.lisReqDtl[irow].ScanQty = lotQtysum;

                    reqDtl.UpdateRowSpread(spdReqDtlMove, irow, (int)ColReqDtl.SCAN_QTY, lotQtysum);

                    reqLot = new cinvReqLotOrder(slotId);
                    MPCF.SetInMsg(reqLot);
                    reqLot.LotId = MPCF.Trim(slotId);
                    reqLot.ReqQty1 = lotQty;
                    reqLot.MatId = smatId;
                    reqLot.MatDesc = smatDesc;
                    reqLot.Unit = sunit;

                    //reqMst.AddReqDtl(reqDtl); 위에서 추가하고 있어서 주석처리함 2017-04-24
                    reqDtl.AddReqLot(reqLot);
                    reqLot.AddRowSpread(spdReqLotMove);
 
                    txtLotId.Focus();
                    txtLotId.SelectAll();

                    //MPCF.FitColumnHeader(spdReqMstMove);
                    //MPCF.FitColumnHeader(spdReqDtlMove);
                    MPCF.FitColumnHeader(spdReqLotMove);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int irow = 0;
                int ireqDtlrow = 0;
                string lotId = string.Empty;
                string s_matId = string.Empty;
                int iactiveRow = 0;
                int i_total_qty = 0;
                double i_ReqQty = 0;
                if (spdReqLotMove.Sheets[0].RowCount > 0)
                {
                    
                    iactiveRow = spdReqLotMove.Sheets[0].ActiveRowIndex;
                    lotId = MPCF.Trim(spdReqLotMove.Sheets[0].GetValue(iactiveRow, (int)ColReqLot.LOT_ID));
                    i_ReqQty = Convert.ToInt32(MPCF.Trim(spdReqLotMove.Sheets[0].GetValue(iactiveRow, (int)ColReqLot.QTY)));
                    s_matId = MPCF.Trim(spdReqLotMove.Sheets[0].GetValue(iactiveRow, (int)ColReqLot.MATERIAL));

                    for (int i = 0; i < spdReqDtlMove.Sheets[0].RowCount; i++)
                    {
                        if (MPCF.Trim(spdReqDtlMove.Sheets[0].GetValue(i, (int)ColReqDtl.MAT_ID)) == s_matId)
                        {
                            irow = i;
                            i_total_qty = Convert.ToInt32(MPCF.Trim(spdReqDtlMove.Sheets[0].GetValue(i, (int)ColReqDtl.SCAN_QTY))) - Convert.ToInt32(i_ReqQty);
                        }
                    }

                    

                    foreach (cinvReqLotOrder reqLot in reqDtl.lisReqLot)
                    {
                       
                        if (reqDtl.lisReqLot[ireqDtlrow].MatId == s_matId)
                        {
                            reqDtl.UpdateRowSpread(spdReqDtlMove, irow, (int)ColReqDtl.SCAN_QTY, i_total_qty);
                            reqDtl.RemoveReqLot(ireqDtlrow);
                            reqLot.RemoveRowSpread(spdReqLotMove, iactiveRow);
                            //reqDtl.RemoveReqLot(irow);
                            break;
                        }
                        ireqDtlrow++;
                    }

                    txtLotId.Focus();
                    txtLotId.SelectAll();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string invReqNo = string.Empty;
                string reqDate = string.Empty;
                string args = string.Empty;
                if (spdReqMstMove.Sheets[0].RowCount == 0)
                {
                    //CMN107 ERROR - 데이타가 입력되지 않았습니다. 필요한 데이타를 입력해 주십시요.
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, true);
                    return;
                }
                TRSNode picking_out_node = new TRSNode("PICKING_LOT_OUT");

                if (MPCF.CallService("BINV", "BINV_Tran_Picking_Material_For_Order", reqMst, ref picking_out_node) == false)
                {
                    return;
                }

                MPCF.ShowSuccessMessage(picking_out_node, false);

                //invReqNo = picking_out_node.GetString("NEW_INV_REQ_NO");
                //invReqNo = picking_out_node.GetString("TRS_NO");
                //reqDate = reqMst.MoveDate;

                initSpread();

                reqMst.Init();
                reqMst = null;
                reqDtl.Init();
                reqDtl = null;

                txtLotId.Focus();
                txtLotId.SelectAll();
                //MPCF.FieldClear(txtLotId);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvToStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "OPER_GRP_1";
                dvcArgu[1].sCondition_Value = "P";


                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvToStore.Text = cdvToStore.Show(cdvToStore, "Oper", "CINV2210-001", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvToStore.Text) != "")
                {
                    if (cdvToStore.returnDatas != null && cdvToStore.returnDatas.Count > 0)
                    {
                        cdvToStore.Tag = cdvToStore.returnDatas[0];
                    }
                    else
                    {
                        //cdvToStore.Tag = "";
                    }
                }
                else
                {
                    cdvToStore.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvFromStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "USER_ID";
                dvcArgu[1].sCondition_Value = MPGV.gsUserID;

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvFromStore.Text = cdvFromStore.Show(cdvFromStore, "Oper", "COM0000-007", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvFromStore.Text) != "")
                {
                    if (cdvFromStore.returnDatas != null && cdvFromStore.returnDatas.Count > 0)
                    {
                        cdvFromStore.Tag = cdvFromStore.returnDatas[0];
                    }
                    else
                    {
                        //cdvFromStore.Tag = "";
                    }
                }
                else
                {
                    cdvFromStore.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvReasonMove_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup                
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_RSN_DETAIL));
                in_node.AddString("DATA_2", BIGC.B_INV_RSN_GRP_RG5);

                // CodeView Column Header Setup
                string[] header = new string[] { "Reason", "Description", "Account Detail" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_3" };

                // Show
                cdvReasonMove.Text = cdvReasonMove.Show(cdvReasonMove, "Reason", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvReasonMove.Text) != "")
                {
                    if (cdvReasonMove.returnDatas != null && cdvReasonMove.returnDatas.Count > 0)
                    {
                        cdvReasonMove.Tag = cdvReasonMove.returnDatas[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmINVOutPickingInventoryByOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SetDefaultValueToReg();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdReqMstMove);
                MPCF.ClearList(spdReqDtlMove);
                MPCF.ClearList(spdReqLotMove);
                //MPCF.ClearList(spdInvLotList);
                //_bShipFlag = false;
                //btnCancel.Enabled = true;

                if (View_Req_Mst() == false)
                {
                    return;
                    //Nothing
                }

                //ViewDtlLot();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        #endregion

        #region Function
        private void InvisibleColumn()
        {
            //spdReqMstMove.Sheets[0].Columns[(int)ColReqMst.MOVE_REQ_NO].Visible = false;
            spdReqMstMove.Sheets[0].Columns[(int)ColReqMst.REASON].Visible = false;
            spdReqLotMove.Sheets[0].Columns[(int)ColReqLot.SELECT].Visible = false;

            spdReqDtlMove.Sheets[0].Columns[(int)ColReqDtl.TRS_NO].Visible = false;
            spdReqDtlMove.Sheets[0].Columns[(int)ColReqDtl.TRS_NO_SEQ].Visible = false;

        }

        private void LockColumn()
        {
            for (int i = 0; i < spdReqMstMove.Sheets[0].Columns.Count; i++)
            {
                spdReqMstMove.Sheets[0].Columns[i].Locked = true;
            }
            for (int i = 0; i < spdReqDtlMove.Sheets[0].Columns.Count; i++)
            {
                spdReqDtlMove.Sheets[0].Columns[i].Locked = true;
            }
            for (int i = 0; i < spdReqLotMove.Sheets[0].Columns.Count; i++)
            {
                spdReqLotMove.Sheets[0].Columns[i].Locked = true;
            }

        }

        private void initSpread()
        {
            MPCF.ClearList(spdReqMstMove);
            MPCF.ClearList(spdReqDtlMove);
            MPCF.ClearList(spdReqLotMove);
        }

        /// <summary>
        /// View Request Master Data
        /// </summary>
        /// <param name="oDate"></param>
        /// <returns></returns>
        private bool View_Req_Mst()
        {
            try
            {
                string sToOper = string.Empty;
                string sTrsDate = string.Empty;
                //string s_MoveDate = MPCF.Trim(dtpMoveDate.GetValueAsString(8));
                //string s_MoveTime = MPCF.Trim(dtpMoveDate.GetValueAsString(8)) + MPCF.Trim(DateTime.Now.ToString("HHmmss"));

                sToOper = MPCF.Trim(cdvToStore.Tag.ToString());
                sTrsDate = MPCF.Trim(dtpMoveDate.GetValueAsString(8));

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
                DataTable dt = null;
                //string sSql = null;

                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "TRS_DATE";
                dvcArgu[1].sCondition_Value = sTrsDate;

                dvcArgu[2].sCondtion_ID = "TO_OPER";
                dvcArgu[2].sCondition_Value = sToOper;

                if (TPDR.GetDataOne(s_column, ref dt, "OINV2217-004", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdReqMstMove_Sheet1.RowCount++;
 

                    spdReqMstMove_Sheet1.Cells[i, (int)ColReqMst.TRS_NO].Value = dt.Rows[i]["TRS_NO"].ToString();
                    spdReqMstMove_Sheet1.Cells[i, (int)ColReqMst.TRS_DATE].Value = MPCF.ToDate(dt.Rows[i]["TRS_DATE"].ToString()); ;
                    spdReqMstMove_Sheet1.Cells[i, (int)ColReqMst.TO_OPER].Value = dt.Rows[i]["TO_OPER"].ToString();
                    spdReqMstMove_Sheet1.Cells[i, (int)ColReqMst.TRS_STS].Value = dt.Rows[i]["TRS_STS"].ToString();
                }
                
               
                viewOrderDetailList(0);
               
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        private void spdReqMstMove_SelectionChanged()
        {
            throw new NotImplementedException();
        }

        private bool View_Req_Dtl(string s_trs_no)
        {
            string sTrsNo = string.Empty;
            //string sMatId = string.Empty;
            //string sToOper = string.Empty;
            //string sTrsDate = string.Empty;

          

            sTrsNo = s_trs_no;

            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
                DataTable dt = null;
                //string sSql = null;
                
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "TRS_NO";
                dvcArgu[1].sCondition_Value = sTrsNo;

                //dvcArgu[2].sCondtion_ID = "TO_OPER";
                //dvcArgu[2].sCondition_Value = sToOper;

                //dvcArgu[3].sCondtion_ID = "TRS_DATE";
                //dvcArgu[3].sCondition_Value = sTrsDate;
                
                    
                if (TPDR.GetDataOne(s_column, ref dt, "OINV2217-003", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdReqDtlMove_Sheet1.RowCount++;

                    spdReqDtlMove_Sheet1.Cells[i, (int)ColReqDtl.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdReqDtlMove_Sheet1.Cells[i, (int)ColReqDtl.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdReqDtlMove_Sheet1.Cells[i, (int)ColReqDtl.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdReqDtlMove_Sheet1.Cells[i, (int)ColReqDtl.REQ_QTY].Value = dt.Rows[i]["REQ_QTY"].ToString();
                    spdReqDtlMove_Sheet1.Cells[i, (int)ColReqDtl.PICKING_QTY].Value = dt.Rows[i]["PICKING_QTY"].ToString();
                    spdReqDtlMove_Sheet1.Cells[i, (int)ColReqDtl.TRAN_QTY].Value = dt.Rows[i]["TRAN_QTY"].ToString();
                    spdReqDtlMove_Sheet1.Cells[i, (int)ColReqDtl.REMAIN_QTY].Value = dt.Rows[i]["REMAIN_QTY"].ToString();
                    spdReqDtlMove_Sheet1.Cells[i, (int)ColReqDtl.TRS_NO].Value = dt.Rows[i]["TRS_NO"].ToString();
                    spdReqDtlMove_Sheet1.Cells[i, (int)ColReqDtl.TRS_NO_SEQ].Value = dt.Rows[i]["TRS_NO_SEQ"].ToString();

                }
                MPCF.FitColumnHeader(spdReqDtlMove);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        #endregion

        private void txtLotId_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cdvToStore_ValueChanged(object sender, EventArgs e)
        {

        }

        private void spdReqMstMove_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                if (viewOrderDetailList(e.Range.Row) == false) 
                {
                    return;
                }
                //if (spdReqMstMove_Sheet1.RowCount > 0)
                //{
                //    MPCF.ClearList(spdReqDtlMove);
                //    MPCF.ClearList(spdReqLotMove);

                //    if (View_Req_Dtl(MPCF.Trim(spdReqMstMove_Sheet1.Cells[e.Range.Row, (int)ColReqMst.TRS_NO].Value)) == false)
                //    {
                //        return;
                //    }
                //}   

             
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool viewOrderDetailList(int iRowNum)
        {
            try {
                if (spdReqMstMove_Sheet1.RowCount > 0)
                {
                    MPCF.ClearList(spdReqDtlMove);
                    MPCF.ClearList(spdReqLotMove);

                    if (View_Req_Dtl(MPCF.Trim(spdReqMstMove_Sheet1.Cells[iRowNum, (int)ColReqMst.TRS_NO].Value)) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex) {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;

            }
        }

        public class cinvReqMstOrder : TRSNode
        {

            string toStoreDesc;

            public string ReqType { get { return this.GetString("REQ_TYPE"); } set { this.SetString("REQ_TYPE", value); } }
            public string MoveDate { get { return this.GetString("REQ_DATE"); } set { this.SetString("REQ_DATE", value); } }
            public string MoveTime { get { return this.GetString("REQ_TIME"); } set { this.SetString("REQ_TIME", value); } }
            public string ReqUserId { get { return this.GetString("REQ_USER_ID"); } set { this.SetString("REQ_USER_ID", value); } }
            public char ReqStatus { get { return this.GetChar("REQ_STATUS"); } set { this.SetChar("REQ_STATUS", value); } }
            public string FromFactory { get { return this.GetString("REQ_CMF_1"); } set { this.SetString("REQ_CMF_1", value); } }
            public string FromStore { get { return this.GetString("REQ_CMF_2"); } set { this.SetString("REQ_CMF_2", value); } }
            public string ToFactory { get { return this.GetString("REQ_CMF_3"); } set { this.SetString("REQ_CMF_3", value); } }
            public string ToStore { get { return this.GetString("REQ_CMF_4"); } set { this.SetString("REQ_CMF_4", value); } }
            public string ReasonDtl { get { return this.GetString("REQ_CMF_5"); } set { this.SetString("REQ_CMF_5", value); } }
            public string TrsNo { get { return this.GetString("REQ_CMF_6"); } set { this.SetString("REQ_CMF_6", value); } }
            public string ReasonDtlDesc { get; set; }
            public string FromStoreDesc { get; set; }
            public string ToFactoryDesc { get; set; }
            public string ToStoreDesc { get; set; }
            //public string ToStoreDesc { get {return toStoreDesc } set {this.toStoreDesc = value}   }

            public List<cinvReqDtlOrder> lisReqDtl { get; set; }

            public cinvReqMstOrder(string name)
                : base(name)
            {

            }

            public void AddReqDtl(cinvReqDtlOrder ReqDtlNode)
            {
                if (lisReqDtl == null)
                {
                    lisReqDtl = new List<cinvReqDtlOrder>();
                }
                lisReqDtl.Add(ReqDtlNode);
                this.AddNode(ReqDtlNode, "MAT_LIST");
            }

            public void RemoveReqDtl(int index)
            {
                this.lisReqDtl.RemoveAt(index);
                this.Lists[0].items.RemoveAt(index);
            }

            public void AddRowSpread(FarPoint.Win.Spread.FpSpread spread)
            {
                int row = 0;
                row = spread.Sheets[0].Rows.Count++;
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.TRS_NO, MPCF.Trim(this.TrsNo));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.TRS_DATE, MPCF.ToDate(this.MoveDate));
                spread.Sheets[0].SetTag(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.FROM_OPER, MPCF.Trim(this.FromStore));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.FROM_OPER, MPCF.Trim(this.FromStoreDesc));
                spread.Sheets[0].SetTag(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.TO_OPER, MPCF.Trim(this.ToStore));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.TO_OPER, MPCF.Trim(this.ToStoreDesc));
                spread.Sheets[0].SetTag(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.REASON, MPCF.Trim(this.ReasonDtl));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.REASON, MPCF.Trim(this.ReasonDtlDesc));
                spread.Sheets[0].SetTag(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.TRS_STS, BIGC.B_REQ_STATUS_REQUEST);
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqMst.TRS_STS, BIGC.B_REQ_STATUS_REQUEST_DESC);
            }

            public void RemoveRowSpread(FarPoint.Win.Spread.FpSpread spread, int row)
            {
                spread.Sheets[0].RemoveRows(row, 1);
            }

        }

        public class cinvReqDtlOrder : TRSNode
        {
            public string TrsNo { get { return this.GetString("TRS_NO"); } set { this.SetString("TRS_NO", value); } }
            public int TrsNoSeq { get { return this.GetInt("TRS_NO_SEQ"); } set { this.SetInt("TRS_NO_SEQ", value); } }
            public string FromOper { get { return this.GetString("FROM_OPER"); } set { this.SetString("FROM_OPER", value); } }
            public string ToOper { get { return this.GetString("TO_OPER"); } set { this.SetString("TO_OPER", value); } }
            public string MatId { get { return this.GetString("MAT_ID"); } set { this.SetString("MAT_ID", value); } }
            public int MatVer { get { return this.GetInt("MAT_VER"); } set { this.SetInt("MAT_VER", value); } }
            public double ReqQty { get { return this.GetDouble("REQ_QTY"); } set { this.SetDouble("REQ_QTY", value); } }
            public double PickingQty { get { return this.GetDouble("PICKING_QTY"); } set { this.SetDouble("PICKING_QTY", value); } }
            public double TranQty { get { return this.GetDouble("TRAN_QTY"); } set { this.SetDouble("TRAN_QTY", value); } }
            public double RemainQty { get { return this.GetDouble("REMAIN_QTY"); } set { this.SetDouble("REMAIN_QTY", value); } }
            public double ScanQty { get { return this.GetDouble("SCAN_QTY"); } set { this.SetDouble("SCAN_QTY", value); } }
            public string MatDesc { get; set; }
            public string Unit { get; set; }

            public List<cinvReqLotOrder> lisReqLot { get; set; }

            public cinvReqDtlOrder(string name)
                : base(name)
            {

            }

            public void AddReqLot(cinvReqLotOrder ReqLotNode)
            {
                if (lisReqLot == null)
                {
                    lisReqLot = new List<cinvReqLotOrder>();
                }
                lisReqLot.Add(ReqLotNode);
                this.AddNode(ReqLotNode, "LOT_LIST");
            }

            public void RemoveReqLot(int index)
            {
                this.lisReqLot.RemoveAt(index);
                this.Lists[0].items.RemoveAt(index);
            }

            public void AddRowSpread(FarPoint.Win.Spread.FpSpread spread)
            {
                int row = 0;
                row = spread.Sheets[0].Rows.Count++;
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqDtl.MAT_ID, MPCF.Trim(this.MatId));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqDtl.MAT_DESC, MPCF.Trim(this.MatDesc));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqDtl.UNIT_1, MPCF.Trim(this.Unit));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqDtl.REQ_QTY, MPCF.Trim(this.ReqQty));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqDtl.PICKING_QTY, MPCF.Trim(this.PickingQty));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqDtl.TRAN_QTY, MPCF.Trim(this.TranQty));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqDtl.REMAIN_QTY, MPCF.Trim(this.RemainQty));
                //spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqDtl.WEIGHT_PINKING, MPCF.Trim(this.ReqQty1));

            }

            public void UpdateRowSpread(FarPoint.Win.Spread.FpSpread spread, int row, int Colum, object value)
            {
                spread.Sheets[0].SetValue(row, Colum, value);
            }

            public void RemoveRowSpread(FarPoint.Win.Spread.FpSpread spread, int row)
            {
                spread.Sheets[0].RemoveRows(row, 1);
            }

            public override bool Equals(object obj)
            {
                if (this.MatId == ((cinvReqDtlOrder)obj).Name)
                {
                    return true;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

        }

        public class cinvReqLotOrder : TRSNode
        {
            public string LotId { get { return this.GetString("LOT_ID"); } set { this.SetString("LOT_ID", value); } }
            public double ReqQty1 { get { return this.GetDouble("REQ_QTY_1"); } set { this.SetDouble("REQ_QTY_1", value); } }

            public string MatId { get; set; }
            public string MatDesc { get; set; }
            public string Unit { get; set; }

            public cinvReqLotOrder(string name)
                : base(name)
            {
            }

            public override bool Equals(object obj)
            {
                if (this.LotId == ((cinvReqLotOrder)obj).Name)
                {
                    return true;
                }
                return false;
            }

            public void AddRowSpread(FarPoint.Win.Spread.FpSpread spread)
            {
                int row = 0;
                row = spread.Sheets[0].Rows.Count++;
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqLot.LOT_ID, MPCF.Trim(this.LotId));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqLot.MATERIAL, MPCF.Trim(this.MatId));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqLot.MATERIAL_DESC, MPCF.Trim(this.MatDesc));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqLot.UNIT, MPCF.Trim(this.Unit));
                spread.Sheets[0].SetValue(row, (int)frmINVOutPickingInventoryByOrder.ColReqLot.QTY, MPCF.Trim(this.ReqQty1));

            }

            public void RemoveRowSpread(FarPoint.Win.Spread.FpSpread spread, int row)
            {
                spread.Sheets[0].RemoveRows(row, 1);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}


