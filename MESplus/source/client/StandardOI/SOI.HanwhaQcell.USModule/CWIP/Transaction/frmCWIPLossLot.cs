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
using SOI.WIP;
using Infragistics.Win.UltraWinGrid;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCWIPLossLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode LOT;
        private TRSNode ORDER;

        #endregion

        #region Constructor

        public frmCWIPLossLot()
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
        private void frmCWIPLossLot_Load(object sender, EventArgs e)
        {
            // Init
            LOT = new TRSNode("LOT_INFO");
            ORDER = new TRSNode("ORDER_INFO");

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCWIPLossLot_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                // Lot ID Focus
                MPCF.SetFocus(txtLotID);

                bIsShown = true;
            }
        }

        /// <summary>
        /// Lot ID에서 엔터키 입력 시 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && MPCF.Trim(txtLotID.Text) != "")
                {
                    if (ViewLot(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Lot Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLotStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // Show Popup
                frmWIPViewLotStatusPopup f = new frmWIPViewLotStatusPopup(txtLotID.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Lot History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLotHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // Show Popup
                frmWIPViewLotHistoryPopup f = new frmWIPViewLotHistoryPopup(txtLotID.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Work Order 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (ORDER.GetString("ORDER_ID") == null 
                    || ORDER.GetString("ORDER_ID") == "")
                {
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                // Show Popup
                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(ORDER.GetString("ORDER_ID"));
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvCauseFlow_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_FLOW_IN");
                TRSNode out_node = new TRSNode("VIEW_FLOW_OUT");

                // In Node Setup
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                string[] header = new string[] { "Flow", "Flow Desc" };
                string[] display = new string[] { "FLOW", "FLOW_DESC" };

                cdvCauseFlow.Text = cdvCauseFlow.Show(cdvCauseFlow, "Flow", "WIP", "WIP_View_Flow_List", in_node, "FLOW_LIST", display, header, "FLOW");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvCauseOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
                TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

                // In Node Setup
                MPCF.SetInMsg(in_node);

                if (cdvCauseFlow.Text == string.Empty)
                {
                    in_node.ProcStep = '1';
                }
                else
                {
                    in_node.ProcStep = '2';
                    in_node.AddString("FLOW", MPCF.Trim(cdvCauseFlow.Text));
                }

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvCauseOper.Text = cdvCauseOper.Show(cdvCauseOper, "Oper", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
                TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");
                string sLossCodeTable;

                try
                {
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("OPER", LOT.GetString("OPER"));

                    if (MPCF.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    sLossCodeTable = "";
                    sLossCodeTable = MPCF.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOSS_TBL_DEF);
                    if (sLossCodeTable == "")
                    {
                        sLossCodeTable = out_node.GetString("LOSS_TBL");
                    }

                    if (sLossCodeTable == "")
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(247), MSG_LEVEL.WARNING, false);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                    return;
                }

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(sLossCodeTable));

                // CodeView Column Header Setup
                string[] header = new string[] { "Loss Code", "Loss Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Loss Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvLossCode.Text) != "")
                {
                    if (cdvLossCode.returnDatas.Count > 0)
                    {
                        cdvLossCode.Tag = cdvLossCode.returnDatas[1];
                    }

                    MPCF.SetFocus(txtLossQty);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }



        /// <summary>
        /// Add 버튼을 클릭하면 Loss 정보를 등록합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddLossCode() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Del 버튼을 클릭하면 선택된 Loss 정보를 삭제합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우 종료
                if (gridLossInfo.Rows.Count < 1)
                {
                    return;
                }

                // Row 제거
                for (int i = gridLossInfo.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)gridLossInfo.Rows[i].Cells[0].Value == true)
                    {
                        lblTotLoss.Text = (Convert.ToInt32(lblTotLoss.Text.Replace(",", "")) - Convert.ToInt32(MPCF.DestroyNumberFormat(gridLossInfo.Rows[i].Cells[3].Value.ToString()))).ToString();
                        lblLotRemain.Text = (Convert.ToInt32(lblLotRemain.Text.Replace(",", "")) + Convert.ToInt32(MPCF.DestroyNumberFormat(gridLossInfo.Rows[i].Cells[3].Value.ToString()))).ToString();

                        gridLossInfo.Rows[i].Delete(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Search 버튼 클릭 시
        /// Lot 정보 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLotIDSearch_Click(object sender, EventArgs e)
        {
            // Lot ID Check
            if (MPCF.CheckValue(txtLotID, false) == false)
            {
                return;
            }

            // View Lot
            if (ViewLot(txtLotID.Text) == false)
            {
                txtLotID.SelectAll();
                return;
            }
        }

        /// <summary>
        /// Loss Qty Key Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLossQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter
                    && MPCF.Trim(cdvLossCode.Text) != ""
                    && MPCF.Trim(txtLossQty.Text) != "")
                {
                    if (AddLossCode() == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Process Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }
                if (gridLossInfo.Rows.Count < 1)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, false);
                    return;
                }

                // Loss Lot
                if (LossLot() == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();                    
                    return;
                }

                // Clear
                MPCF.SetFocus(txtLotID);
                txtLotID.SelectAll();                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            
            try
            {
                LOT.Init();
            
                if (gridLossInfo.Rows.Count > 0)
                {
                    DataTable dt_temp = gridLossInfo.GetDataSource();
                    dt_temp.Clear();
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }

                txtMaterial.Text = LOT.GetString("MAT_ID") + " : " + LOT.GetString("MAT_DESC");
                txtFlow.Text = LOT.GetString("FLOW") + " : " + LOT.GetString("FLOW_DESC");
                txtOper.Text = LOT.GetString("OPER") + " : " + LOT.GetString("OPER_DESC");
                txtQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));;

                lblLotRemain.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));;
                lblTotLoss.Text = "0";

                if (ViewOrder(LOT.GetString("ORDER_ID")) == false)
                {
                    return false;
                }

                if (ViewLossCodeList(LOT.GetString("OPER")) == false)
                {
                    return false;
                }

                if (LOT.GetString("LOT_STATUS") == "PROC")
                {
                    pbStart.LotStatus = true;
                }
                else
                {
                    pbStart.LotStatus = false;
                }
                pbHold.LotStatus = (LOT.GetChar("HOLD_FLAG") == 'Y' ? true : false);
                pbRework.LotStatus = (LOT.GetChar("RWK_FLAG") == 'Y' ? true : false);
                pbRepair.LotStatus = (LOT.GetChar("REP_FLAG") == 'Y' ? true : false);
                pbInventory.LotStatus = (LOT.GetChar("INV_FLAG") == 'Y' ? true : false);
                pbTransit.LotStatus = (LOT.GetChar("TRANSIT_FLAG") == 'Y' ? true : false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewOrder(string sOrderId)
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ORDER_ID", sOrderId);

            if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
            {
                return false;
            }
            ORDER = out_node;
            txtWorkOrder.Text = out_node.GetString("ORDER_ID") + " : " + out_node.GetString("ORDER_DESC");
            //txtCustomer.Text = out_node.GetString("CUSTOMER_ID");
            //txtLine.Text = out_node.GetString("WORK_LINE") + " : " + out_node.GetString("WORK_LINE_DESC"); ;
            txtLine.Text = out_node.GetString("ORD_CMF_1");

            lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
            lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
            lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
            lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

            return true;
        }

        /// <summary>
        /// View Loss Code List
        /// </summary>
        /// <param name="sOper"></param>
        /// <returns></returns>
        private bool ViewLossCodeList(string sOper)
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");
            string sLossCodeTable;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", sOper);

                if (MPCF.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
                {
                    return false;
                }

                sLossCodeTable = "";
                sLossCodeTable = MPCF.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOSS_TBL_DEF);
                if (sLossCodeTable == "")
                {
                    sLossCodeTable = out_node.GetString("LOSS_TBL");
                }

                if (sLossCodeTable == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(247), MSG_LEVEL.WARNING, false);
                    return false;
                }


                in_node.Init();
                out_node.Init();
                List<TRSNode> lisData;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(sLossCodeTable));

                do
                {
                    if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisData = out_node.GetList("DATA_LIST");
                    foreach (TRSNode data in lisData)
                    {
                        //liCodeList.Add(new CodeModel(data.GetString("KEY_1"), data.GetString("DATA_1")));
                    }

                    in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                    in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "" || in_node.GetInt("NEXT_ROW") > 0);

                //_model.LossCodeList = liCodeList;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Loss Lot
        /// </summary>
        /// <returns></returns>
        private bool LossLot()
        {
            TRSNode in_node = new TRSNode("LOSS_LOT_IN");
            TRSNode out_node = new TRSNode("LOSS_LOT_OUT");
            TRSNode loss_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                //in_node.AddString("RES_ID", _model.ResId);
                //in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));
                in_node.AddString("CAUSE_FLOW", MPCF.Trim(cdvCauseFlow.Text));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(cdvCauseOper.Text));
                //in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));
                //in_node.AddString("CHECK_USER_1", MPCF.Trim(txtChkUser1.Text), true);
                //in_node.AddString("CHECK_USER_2", MPCF.Trim(txtChkUser2.Text), true);
                //in_node.AddString("CHECK_USER_3", MPCF.Trim(txtChkUser3.Text), true);

                in_node.AddDouble("OUT_QTY_1", MPCF.ToDbl(MPCF.DestroyNumberFormat(lblLotRemain.Text)));
                
                DataTable dt = gridLossInfo.GetDataSource();

                if (dt.Rows.Count < 1)
                {
                    return true;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    loss_item = in_node.AddNode("UNIT1");

                    loss_item.AddString("CODE", dt.Rows[i][1].ToString());
                    loss_item.AddDouble("QTY", MPCF.ToDbl(MPCF.DestroyNumberFormat(dt.Rows[i][3].ToString())));
                }

                //in_node.AddDouble("OUT_QTY_1", MPCF.ToDbl(lblLotRemain.Text));
                in_node.AddDouble("OUT_QTY_2", LOT.GetDouble("QTY_2"));
                in_node.AddDouble("OUT_QTY_3", LOT.GetDouble("QTY_3"));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", 'Y');

                // Service
                if (MPCF.CallService("WIP", "WIP_Loss_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Refresh
                if (ViewLot(txtLotID.Text) == false)
                {
                    return false;
                }

                dt.Rows.Clear();
                gridLossInfo.DataBind();

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Loss Info
        /// </summary>
        /// <param name="in_node"></param>
        /// <returns></returns>
        private bool SetLossInfo(TRSNode in_node)
        {
            TRSNode loss_item;
            TRSNode loss_in;

            // DataTable 호출
            DataTable dt = gridLossInfo.GetDataSource();

            if (dt.Rows.Count < 1)
            {
                return true;
            }
            loss_in = in_node.AddNode("LOSS_LOT");

            MPCF.SetInMsg(loss_in);
            loss_in.ProcStep = '1';
            loss_in.AddString("LOT_ID", txtLotID.Text);
            //loss_in.AddString("RES_ID", cdvResID.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                loss_item = loss_in.AddNode("UNIT1");

                loss_item.AddString("CODE", dt.Rows[i][1].ToString());
                loss_item.AddDouble("QTY", MPCF.ToDbl(dt.Rows[i][3]));
            }

            loss_in.AddDouble("OUT_QTY_1", MPCF.ToDbl(MPCF.DestroyNumberFormat(lblLotRemain.Text)));
            loss_in.AddDouble("OUT_QTY_2", LOT.GetDouble("QTY_2"));
            loss_in.AddDouble("OUT_QTY_3", LOT.GetDouble("QTY_3"));

            return true;
        }

        /// <summary>
        /// Add Loss Code to Grid
        /// </summary>
        /// <returns></returns>
        private bool AddLossCode()
        {
            try
            {
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                // Lot ID Check
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return false;
                }

                // Loss Code Check
                if (MPCF.CheckValue(cdvLossCode, false) == false)
                {
                    return false;
                }

                // Loss Qty Check
                if (MPCF.CheckValue(txtLossQty, 0.0005, MPCF.ToDbl(MPCF.DestroyNumberFormat(lblLotRemain.Text)), false) == false)
                {
                    txtLossQty.Text = "";
                    return false;
                }

                double dLossQty = Convert.ToDouble(txtLossQty.Text);

                // DataTable 호출
                DataTable dt = gridLossInfo.GetDataSource();

                bool bFound = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString() == cdvLossCode.Text)
                    {
                        dt.Rows[i][3] = (Convert.ToInt32(dt.Rows[i][3]) + Convert.ToInt32(txtLossQty.Text));

                        bFound = true;
                        break;
                    }
                }

                if (bFound == false)
                {
                    // Row 추가
                    DataRow dr = dt.NewRow();

                    // 값 추가
                    dr[0] = true;
                    dr[1] = cdvLossCode.Text;
                    dr[2] = (cdvLossCode.Tag == null ? string.Empty : cdvLossCode.Tag.ToString());
                    dr[3] = txtLossQty.Text;

                    // Add
                    dt.Rows.Add(dr);
                }

                // Bind
                gridLossInfo.DataBind();

                lblTotLoss.Text = (Convert.ToInt32(lblTotLoss.Text.Replace(",", "")) + Convert.ToInt32(txtLossQty.Text.Replace(",", ""))).ToString();
                lblLotRemain.Text = (Convert.ToInt32(lblLotRemain.Text.Replace(",", "")) - Convert.ToInt32(txtLossQty.Text.Replace(",", ""))).ToString();

                cdvLossCode.Text = "";
                txtLossQty.Text = "";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion


    }
}
