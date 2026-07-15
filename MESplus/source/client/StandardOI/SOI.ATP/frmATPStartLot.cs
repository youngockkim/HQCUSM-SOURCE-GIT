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
    public partial class frmATPStartLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode LOT = new TRSNode("LOT_INFO");

        #endregion

        #region Constructor

        public frmATPStartLot()
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
                // (Required) Init Focus Control
                MPCF.SetFocus(txtLotID);

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Lot ID Enter Key
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
        /// Lot Search Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLotSearch_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Resource ID CodeView
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

                if (LOT == null)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

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
        /// Process Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                if (StartLot() == false)
                {
                    txtLotID.SelectAll();
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                txtLotID.SelectAll();
                MPCF.SetFocus(txtLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

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
                // Clear Lot Info
                LOT.Init();

                // FieldClear
                MPCF.FieldClear(this, txtLotID);

                // IN NODE
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                // Service
                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }

                txtMatCode.Text = LOT.GetString("MAT_ID");
                txtMatDesc.Text = LOT.GetString("MAT_DESC");
                txtOperCode.Text = LOT.GetString("OPER");
                txtOperDesc.Text = LOT.GetString("OPER_DESC");
                txtQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));

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
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewOrder(string sOrderId)
        {
            try
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

                lblOrderQty.Text = out_node.GetDouble("ORD_QTY").ToString("####,##0.###");
                lblInQty.Text = out_node.GetDouble("ORD_IN_QTY").ToString("####,##0.###");
                lblOutQty.Text = out_node.GetDouble("ORD_OUT_QTY").ToString("####,##0.###");
                lblLossQty.Text = out_node.GetDouble("ORD_LOSS_QTY").ToString("####,##0.###");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Start Lot
        /// </summary>
        /// <returns></returns>
        private bool StartLot()
        {
            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("START_LOT_OUT");
            TRSNode res_list;

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
                in_node.AddString("RES_ID", cdvResID.Text);
                res_list = in_node.AddNode("RES_LIST");
                res_list.AddString("RES_ID", cdvResID.Text);
                res_list.AddDouble("LOT_QTY_1", LOT.GetDouble("QTY_1"));
                
                if (MPCF.CallService("WIP", "WIP_Start_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

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
}
