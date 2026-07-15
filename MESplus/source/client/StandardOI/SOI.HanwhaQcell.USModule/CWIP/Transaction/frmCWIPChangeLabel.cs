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
    public partial class frmCWIPChangeLabel : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode ORDER = new TRSNode("ORDER_INFO");
        private TRSNode LOT = new TRSNode("LOT_INFO");

        private enum COL_CHILD_LOT_LIST
        {
            CHK = 0,
            SEQ,
            CHILD_LOT_ID,
            QTY
        }

        #endregion

        #region Constructor

        public frmCWIPChangeLabel()
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
        private void frmCWIPChangeLabel_Load(object sender, EventArgs e)
        {
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
        private void frmCWIPChangeLabel_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                MPCF.SetFocus(txtLotID);
                
                bIsShown = false;
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
                // Validation (Enter Key)
                if (e.KeyCode == Keys.Enter)
                {
                    // Validation (Lot ID)
                    if (MPCF.CheckValue(txtLotID, false) == false)
                    {
                        return;
                    }

                    // View Lot
                    if (ViewLot(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        txtLotID.SelectAll();
                        return;
                    }

                    MPCF.SetFocus(txtChildLotID);
                    txtChildLotID.SelectAll();
                    return;

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtChildLotID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnProcess.PerformClick();
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
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // View Lot
                if (ViewLot(txtLotID.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
                    return;
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

                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(ORDER.GetString("ORDER_ID"));
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
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

                if (SplitLot() == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();                    
                    return;
                }

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
                // Clear
                MPCF.FieldClear(this, txtLotID);
                LOT.Init();
                
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }
                
                // Bind
                txtMaterial.Text = LOT.GetString("MAT_ID") + " : " + LOT.GetString("MAT_DESC");
                txtOper.Text = LOT.GetString("OPER") + " : " + LOT.GetString("OPER_DESC");
                txtQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));;

                if (ViewOrder(LOT.GetString("ORDER_ID")) == false)
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

                //lblTotalSplitQty.Text = lblLotRemainQty.Text = "";

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

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", sOrderId);

                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                ORDER = out_node;
                txtWorkOrder.Text = out_node.GetString("ORDER_ID") + " : " + out_node.GetString("ORDER_DESC");
                txtCustomer.Text = out_node.GetString("CUSTOMER_ID");
                txtLine.Text = out_node.GetString("WORK_LINE") + " : " + out_node.GetString("WORK_LINE_DESC"); ;

                lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
                lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
                lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
                lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Generate Child Lot ID
        /// </summary>
        /// <param name="sChildLotId"></param>
        /// <returns></returns>
        private bool GenChildLotID(ref string sChildLotId)
        {
            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("GENERATE_OUT");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));                
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddChar("REL_LEVEL", '1');
                in_node.AddString("TRAN_CODE", "SPLIT");
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("SEQ_KEY_2", txtLotID.Text);

                if (MPCF.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                if (string.IsNullOrEmpty(out_node.GetString("GEN_ID")) == false)
                {
                    sChildLotId = out_node.GetString("GEN_ID");
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Split Lot
        /// </summary>
        /// <returns></returns>
        private bool SplitLot()
        {
            TRSNode in_node = new TRSNode("SPLIT_LOT_IN");
            TRSNode out_node = new TRSNode("SPLIT_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                in_node.AddString("CHILD_LOT_ID", MPCF.Trim(txtChildLotID.Text));
                //in_node.AddString("CHILD_LOT_DESC", MPCF.Trim(txtChildLotDesc.Text));
                in_node.AddString("CHILD_MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddString("CHILD_FLOW", LOT.GetString("FLOW"));
                in_node.AddString("CHILD_OPER", LOT.GetString("OPER"));

                if (txtQty.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_1", MPCF.ToDbl(txtQty.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_1", 1);
                }

                //in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", 'Y');
                if (chkCopyLabel.Checked == true)
                    in_node.AddChar("COPY_DATA_FLAG", 'N'); //ONLY SPLIT
                else
                    in_node.AddChar("COPY_DATA_FLAG", 'Y'); //CREATE + DATA COPY
 
                if (MPCF.CallService("CWIP", "CWIP_Split_Copy_Lot", in_node, ref  out_node) == false)
                {
                    return false;
                }

                // View New Lot ID
                txtLotID.Text = txtChildLotID.Text;

                if (ViewLot(txtLotID.Text) == false)
                {
                    return false;
                }
               
                MPCF.ShowSuccessMessage(out_node, false);

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

    public class WIPSplitLotFailedModel
    {
        private string child_Lot_ID;
        public string Child_Lot_ID
        {
            get { return child_Lot_ID; }
            set { child_Lot_ID = value; }
        }

        private string qty;
        public string Qty
        {
            get { return qty; }
            set { qty = value; }
        }
    }
}
