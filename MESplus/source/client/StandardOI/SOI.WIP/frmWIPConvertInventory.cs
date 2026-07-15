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

namespace SOI.WIP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPConvertInventory : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode LOT;
        private TRSNode ORDER;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public frmWIPConvertInventory()
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
        private void frmWIPConvertInventory_Load(object sender, EventArgs e)
        {
            // *** HTTP인 경우(SE)에만 사용 ***
            // 표준 작업지도서 아이콘 표시             
            //base.pbStdOper.Visible = true;

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
        private void frmWIPConvertInventory_Shown(object sender, EventArgs e)
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
        ///  Code View Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_INV_MAT_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_MAT_TYPE", "");

                // Display and Header Text Setup
                string[] display = new string[] { "INV_MAT_ID", "INV_MAT_DESC" };
                string[] header = new string[] { "Inv Mat ID", "Inv Mat Desc" };

                // Show CodeView and Get Retur
                cdvInvMatID.Text = cdvInvMatID.Show(cdvInvMatID, "Inv Material ID", "INV", "INV_View_Inv_Material_List", in_node, "INV_MATERIAL_LIST", display, header, "Inv Mat ID");

                if (MPCF.Trim(cdvInvMatID.Text) != "")
                {
                    //ViewInvStoreList(cdvInvMatID.Text, "");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        ///  Code View Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInvStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(cdvInvMatID, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_STORE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_MAT_ID", cdvInvMatID.Text);

                // Display and Header Text Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };
                string[] header = new string[] { "Store ID", "Store Desc" };

                // Show CodeView and Get Return
                cdvInvStore.Text = cdvInvStore.Show(cdvInvStore, "INV Store", "INV", "INV_View_Store_List", in_node, "STORE_LIST", display, header, "Store ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        ///  Process Button Clicked
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
                if (MPCF.CheckValue(cdvInvMatID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvInvStore, false) == false)
                {
                    return;
                }

                // Convert to Inventory
                if (ConvertToInventory() == false)
                {
                    txtLotID.SelectAll();
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                MPCF.SetFocus(txtLotID);
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

                // Show
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

                // Show
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

                // Show
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
        /// Lot ID Enter Key Event
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
        /// Lot ID Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLotIDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (MPCF.Trim(txtLotID.Text) != "")
                {
                    if (ViewLot(txtLotID.Text) == false)
                    {
                        txtLotID.SelectAll();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        
        #endregion

        #region Functions

        /// <summary>
        /// Clear Lot
        /// </summary>
        private void ClearLotnOrderInfo()
        {
            txtMaterial.Text = txtOper.Text = txtLine.Text = txtQty.Text = "";
            txtWorkOrder.Text = txtCustomer.Text = "";
            lblOrderQty.Text = lblInQty.Text = lblOutQty.Text = lblLossQty.Text = "";
        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool ViewLot(string sLotID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            
            try
            {
                LOT.Init();
                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }

                txtMaterial.Text = LOT.GetString("MAT_ID") + " : " + LOT.GetString("MAT_DESC");
                txtOper.Text = LOT.GetString("OPER") + " : " + LOT.GetString("OPER_DESC");
                txtQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));

                if (ViewOrder(LOT.GetString("ORDER_ID")) == false)
                {
                    return false;
                }

                txtInvLotID.Text = sLotID;

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
        /// <param name="sOrderID"></param>
        /// <returns></returns>
        private bool ViewOrder(string sOrderID)
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ORDER_ID", sOrderID);

            if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
            {
                return false;
            }

            ORDER = out_node;
            txtWorkOrder.Text = out_node.GetString("ORDER_ID") + " : " + out_node.GetString("ORDER_DESC");
            txtCustomer.Text = out_node.GetString("CUSTOMER_ID");
            txtLine.Text = out_node.GetString("WORK_LINE") + " : " + out_node.GetString("WORK_LINE_DESC");;

            lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
            lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
            lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
            lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

            return true;
        }

        /// <summary>
        /// Convert to Inventory
        /// </summary>
        /// <returns></returns>
        private bool ConvertToInventory()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode inv_lot;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddChar("OPERATION_TYPE_FLAG", 'L');
                inv_lot = in_node.AddNode("LIST");
                inv_lot.AddString("INV_LOT_ID", txtInvLotID.Text);
                inv_lot.AddString("INV_MAT_ID", cdvInvMatID.Text);
                inv_lot.AddString("STORE_ID", cdvInvStore.Text);
                inv_lot.AddDouble("QTY_1", LOT.GetDouble("QTY_1"));
                inv_lot.AddChar("INV_LOT_TYPE", 'P');
                inv_lot.AddChar("INV_LOT_PRIORITY", '5');

                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}
                //in_node.AddString("TRAN_COMMENT", (txtComment.Content as TextBox).Text);

                if (MPCF.CallService("INV", "INV_Create_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                in_node.Init();
                out_node.Init();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("DEL_CODE", "TO_INVLOT");

                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}
                //in_node.AddString("TRAN_COMMENT", (txtComment.Content as TextBox).Text);

                if (MPCF.CallService("WIP", "WIP_Terminate_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtLotID.Text = "";
                txtInvLotID.Text = "";
                cdvInvMatID.Text = "";
                cdvInvStore.Text = "";

                ClearLotnOrderInfo();

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

}
