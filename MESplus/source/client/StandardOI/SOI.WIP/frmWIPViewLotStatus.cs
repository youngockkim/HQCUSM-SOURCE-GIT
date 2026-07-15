using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

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
    public partial class frmWIPViewLotStatus : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode ORDER = new TRSNode("ORDER_INFO");

        #endregion

        #region Constructor

        public frmWIPViewLotStatus()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWIPViewLotStatus_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWIPViewLotStatus_Shown(object sender, EventArgs e)
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
        /// Lot ID Key Down Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Validation
                    if (MPCF.CheckValue(txtLotID, false) == false)
                    {
                        return;
                    }

                    // View Lot
                    if (ViewLot(txtLotID.Text) == false)
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
        /// View Button Click Event
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

                // View Lot
                if (ViewLot(txtLotID.Text) == false)
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

        #region Functions

        /// <summary>
        /// Lot 조회
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                // Call Service: LOT Info
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotId);
                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Call Service: ORDER Info
				//in_node.Init();
				//MPCF.SetInMsg(in_node);
				//in_node.ProcStep = '1';
				//in_node.AddString("ORDER_ID", out_node.GetString("LOT_CMF_3"));
				//if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref ORDER) == false)
				//{
				//    return false;
				//}

                // Bind
                txtLotDesc.Text = MPCF.Trim(out_node.GetString("LOT_DESC"));
                txtMatID.Text = MPCF.Trim(out_node.GetString("MAT_ID")) + " : " + out_node.GetString("MAT_DESC");
                txtFlow.Text = MPCF.Trim(out_node.GetString("FLOW")) + " : " + out_node.GetString("FLOW_DESC");
                txtOper.Text = MPCF.Trim(out_node.GetString("OPER")) + " : " + out_node.GetString("OPER_DESC");
                txtLotType.Text = MPCF.Trim(out_node.GetChar("LOT_TYPE"));                
                txtLotStatus.Text = MPCF.Trim(out_node.GetString("LOT_STATUS"));
                txtQty.Text = MPCF.Trim(out_node.GetDouble("QTY_1"));
                txtLotDelCode.Text = MPCF.Trim(out_node.GetString("LOT_DEL_CODE"));
                txtShipCode.Text = MPCF.Trim(out_node.GetString("SHIP_CODE"));
                //txtOrderID.Text = MPCF.Trim(out_node.GetString("ORDER_ID")) + " : " + ORDER.GetString("ORDER_DESC");
				txtOrderID.Text = MPCF.Trim(out_node.GetString("ORDER_ID"));
                txtStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
                txtStartResID.Text = MPCF.Trim(out_node.GetString("START_RES_ID"));
                txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));
                txtEndResID.Text = MPCF.Trim(out_node.GetString("END_RES_ID"));
                txtShipTime.Text = MPCF.MakeDateFormat(out_node.GetString("SHIP_TIME"));
                txtSchDueTime.Text = MPCF.MakeDateFormat(out_node.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                txtHoldCode.Text = MPCF.Trim(out_node.GetString("HOLD_CODE"));
                chkStartFlag.Checked = out_node.GetChar("START_FLAG") == 'Y' ? true : false;
                chkEndFlag.Checked = out_node.GetChar("END_FLAG") == 'Y' ? true : false;
                chkHoldFlag.Checked = out_node.GetChar("HOLD_FLAG") == 'Y' ? true : false;
                chkReworkFlag.Checked = out_node.GetChar("RWK_FLAG") == 'Y' ? true : false;
                chkRepairFlag.Checked = out_node.GetChar("REP_FLAG") == 'Y' ? true : false;
                chkInventoryFlag.Checked = out_node.GetChar("INV_FLAG") == 'Y' ? true : false;

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
