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

namespace SOI.SMT
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmSMTEndPCB : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode nodeLotInfo;

        #endregion

        #region Constructor

        public frmSMTEndPCB()
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
        /// Search Lot
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
                MPCF.SetFocus(txtLotID);
                txtLotID.SelectAll();
                return;
            }
        }

        /// <summary>
        /// Search Lot by Enter Key
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
                    txtLotID.SelectAll();
                    return;
                }
            }
        }

        /// <summary>
        /// End PCB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (EndPCB() == false)
            {
                return;
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
                nodeLotInfo = null;

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("SMT", "SMT_View_Lot_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                nodeLotInfo = out_node;

                txtLotDesc.Text = out_node.GetString("LOT_DESC");
                txtOrderID.Text = out_node.GetString("ORDER_ID");
                txtOrderDesc.Text = out_node.GetString("ORDER_DESC");
                txtMatID.Text = out_node.GetString("MAT_ID");
                txtMatDesc.Text = out_node.GetString("MAT_DESC");
                txtOperID.Text = out_node.GetString("OPER");
                txtOperDesc.Text = out_node.GetString("OPER_DESC");
                txtLineID.Text = out_node.GetString("LINE_ID");
                txtResID.Text = out_node.GetString("END_RES_ID");
                txtLotQty.Text = out_node.GetDouble("QTY_1").ToString("####,##0.###");
                txtLotSts.Text = out_node.GetString("LOT_STATUS");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// End PCB
        /// </summary>
        /// <returns></returns>
        private bool EndPCB()
        {
            TRSNode in_node = new TRSNode("END_PCB_IN");
            TRSNode out_node = new TRSNode("END_PCB_OUT");

            try
            {
                // Check Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return false;
                }

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("LANE_ID", nodeLotInfo.GetString("LANE_ID"));
                in_node.AddInt("HIST_SEQ", nodeLotInfo.GetInt("HIST_SEQ"));
                in_node.AddString("END_RES_ID", txtResID.Text);

                if (MPCF.CallService("SMT", "SMT_End_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                ViewLot(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion
    }
}
