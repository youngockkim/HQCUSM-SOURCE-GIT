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
using Infragistics.Win.UltraWinGrid;

namespace SOI.ATP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmATPEndLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode nodeLotInfo;

        #endregion

        #region Constructor

        public frmATPEndLot()
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
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {  
            // Grid 초기화
            gridLossInfo.InitDataSource();

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
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // Lot ID Focus
                MPCF.SetFocus(txtLotID);

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Standard Operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbStdOper_Click(object sender, EventArgs e)
        {
            try
            {
                // 조회된 Lot 정보가 없는 경우
                if (this.nodeLotInfo == null)
                {
                    return;
                }

                // *** HTTP(SE)인 경우에만 사용 ***
                // 표준 작업지도서 Show
                MPCF.RunStandardOperationView(this.nodeLotInfo.GetString("MAT_ID"),
                                                                        this.nodeLotInfo.GetInt("MAT_VER"),
                                                                        this.nodeLotInfo.GetString("FLOW"),
                                                                        this.nodeLotInfo.GetString("OPER"),
                                                                        string.Empty);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Lot ID에서 엔터키 입력 시 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter
                && MPCF.Trim(txtLotID.Text) != "")
            {
                if (ViewLot(txtLotID.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    return;
                }
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
        /// Search 버튼 클릭 시
        /// Lot 정보 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
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
        /// Resource ID CodeViewButtonClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (nodeLotInfo == null)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("MAT_ID", nodeLotInfo.GetString("MAT_ID"));
                in_node.AddString("FLOW", nodeLotInfo.GetString("FLOW"));
                in_node.AddString("OPER", nodeLotInfo.GetString("OPER"));

                // CodeView Column Header Setup
                string[] header = new string[] { "Resource ID", "Resource Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show
                cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Loss Code CodeViewButtonClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (nodeLotInfo == null)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
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
                    in_node.AddString("OPER", nodeLotInfo.GetString("OPER"));

                    if (MPCF.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    sLossCodeTable = "";
                    sLossCodeTable = MPCF.GetExtCodeTable(nodeLotInfo.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOSS_TBL_DEF);
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
                        txtTotLoss.Text = (Convert.ToInt32(txtTotLoss.Text.Replace(",", "")) - Convert.ToInt32(gridLossInfo.Rows[i].Cells[3].Value)).ToString();
                        txtLotRemain.Text = (Convert.ToInt32(txtLotRemain.Text.Replace(",", "")) + Convert.ToInt32(gridLossInfo.Rows[i].Cells[3].Value)).ToString();

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
        /// Lot을 End 처리합니다.
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
                if (MPCF.Trim(nodeLotInfo.GetString("START_RES_ID")) != "")
                {
                    if (MPCF.CheckValue(cdvResID, false) == false)
                    {
                        return;
                    }
                }

                // End Lot
                if (EndLot() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Lot 정보를 조회합니다.
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                // FieldClear
                MPCF.FieldClear(this, txtLotID);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                nodeLotInfo = out_node;

                txtMatCode.Text = out_node.GetString("MAT_ID");
                txtMatDesc.Text = out_node.GetString("MAT_DESC");
                txtOperCode.Text = out_node.GetString("OPER");
                txtOperDesc.Text = out_node.GetString("OPER_DESC");
                txtQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("QTY_1"));

                txtLotRemain.Text = MPCF.MakeNumberFormat(out_node.GetDouble("QTY_1"));
                txtTotLoss.Text = "0";

                if (ViewOrder(out_node.GetString("ORDER_ID")) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("START_RES_ID")) != "")
                {
                    cdvResID.Text = out_node.GetString("START_RES_ID");
                }

                if (out_node.GetString("LOT_STATUS") == "PROC")
                {
                    pbStart.LotStatus = true;
                }
                else
                {
                    pbStart.LotStatus = false;
                }
                pbHold.LotStatus = (out_node.GetChar("HOLD_FLAG") == 'Y' ? true : false);
                pbHold.LotStatus = (out_node.GetChar("RWK_FLAG") == 'Y' ? true : false);
                pbHold.LotStatus = (out_node.GetChar("REP_FLAG") == 'Y' ? true : false);
                pbHold.LotStatus = (out_node.GetChar("INV_FLAG") == 'Y' ? true : false);
                pbHold.LotStatus = (out_node.GetChar("TRANSIT_FLAG") == 'Y' ? true : false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Order 조회
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

            txtWorkOrder.Text = out_node.GetString("ORDER_ID");
            txtCustomer.Text = out_node.GetString("CUSTOMER_ID");
            txtLine.Text = out_node.GetString("LINE_CODE");
            txtLineDesc.Text = out_node.GetString("LINE_DESC");

            lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
            lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
            lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
            lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

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
                if (MPCF.CheckValue(txtLossQty, 0.0005, Convert.ToDouble(txtLotRemain.Text), false) == false)
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

                txtTotLoss.Text = (Convert.ToInt32(txtTotLoss.Text.Replace(",", "")) + Convert.ToInt32(txtLossQty.Text.Replace(",", ""))).ToString();
                txtLotRemain.Text = (Convert.ToInt32(txtLotRemain.Text.Replace(",", "")) - Convert.ToInt32(txtLossQty.Text.Replace(",", ""))).ToString();

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

        /// <summary>
        /// End Lot
        /// </summary>
        /// <returns></returns>
        private bool EndLot()
        {

            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("END_LOT_OUT");
            TRSNode res_list;

            try
            {
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", nodeLotInfo.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("MAT_ID", nodeLotInfo.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", nodeLotInfo.GetInt("MAT_VER"));
                in_node.AddString("FLOW", nodeLotInfo.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", nodeLotInfo.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", nodeLotInfo.GetString("OPER"));
                in_node.AddString("RES_ID", cdvResID.Text);

                res_list = in_node.AddNode("RES_LIST");
                res_list.AddString("RES_ID", cdvResID.Text);
                res_list.AddDouble("LOT_QTY_1", MPCF.ToDbl(txtLotRemain.Text));

                SetLossInfo(in_node);

                if (MPCF.CallService("WIP", "WIP_End_Lot_ASSY_INV", in_node, ref out_node) == false)
                {
                    return false;
                }

                // View Lot
                if (ViewLot(txtLotID.Text) == false)
                {
                    return false;
                }

                // Clear Data
                DataTable dt = gridLossInfo.GetDataSource();
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
            loss_in.AddString("RES_ID", cdvResID.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                loss_item = loss_in.AddNode("UNIT1");

                loss_item.AddString("CODE", dt.Rows[i][1].ToString());
                loss_item.AddDouble("QTY", MPCF.ToDbl(dt.Rows[i][3]));
            }

            loss_in.AddDouble("OUT_QTY_1", MPCF.ToDbl(txtLotRemain.Text));
            loss_in.AddDouble("OUT_QTY_2", nodeLotInfo.GetDouble("QTY_2"));
            loss_in.AddDouble("OUT_QTY_3", nodeLotInfo.GetDouble("QTY_3"));

            return true;
        }

        #endregion
    }
}
