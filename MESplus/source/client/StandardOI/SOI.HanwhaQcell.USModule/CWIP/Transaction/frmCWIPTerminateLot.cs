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
    public partial class frmCWIPTerminateLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode LOT;
        private TRSNode ORDER;

        #endregion

        #region Constructor

        public frmCWIPTerminateLot()
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
        private void frmCWIPTerminateLot_Load(object sender, EventArgs e)
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
        private void frmCWIPTerminateLot_Shown(object sender, EventArgs e)
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
                    MPCF.FieldClear(pnlMiddleMargin, txtLotID);

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

        private void cdvTerminateCode_CodeViewButtonClick(object sender, EventArgs e)
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
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_TERMINATE_CODE));
                //in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LOSS_CODE));

                string[] header = new string[] { "Terminate Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvTerminateCode.Text = cdvTerminateCode.Show(cdvTerminateCode, "Terminate Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvTerminateCode.Text) != "")
                {
                    if (cdvTerminateCode.returnDatas.Count > 0)
                    {
                        cdvTerminateCode.Tag = cdvTerminateCode.returnDatas[1];
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

                if (MPCF.CheckValue(cdvTerminateCode, false) == false)
                {
                    return;
                }

                // Validate Terminate Lot
                if (ValidateTerminateLot() == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();                    
                    return;
                }

                // Terminate Lot
                if (TerminateLot() == false)
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

        private bool ValidateTerminateLot()
        {
            TRSNode in_node = new TRSNode("VALIDATE_LOT_IN");
            TRSNode out_node = new TRSNode("VALIDATE_LOT_OUT");
            //TRSNode terminate_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LOT_ID", txtLotID.Text);

                if (MPCF.CallService("CWIP", "CWIP_Validate_Terminate_Lot", in_node, ref out_node) == false)
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
                txtQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1")); ;

                if (ViewOrder(LOT.GetString("ORDER_ID")) == false)
                {
                    return false;
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
        /// Terminate Lot
        /// </summary>
        /// <returns></returns>
        private bool TerminateLot()
        {
            TRSNode in_node = new TRSNode("TERMINATE_LOT_IN");
            TRSNode out_node = new TRSNode("TERMINATE_LOT_OUT");
            //TRSNode terminate_item;

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
                in_node.AddString("DEL_CODE", MPCF.Trim(cdvTerminateCode.Text));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                //in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", 'Y');

                // Service
                if (MPCF.CallService("WIP", "WIP_Terminate_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Refresh
                /*
                if (ViewLot(txtLotID.Text) == false)
                {
                    return false;
                }
                */
                MPCF.ShowSuccessMessage(out_node, false);

                return true;

                /*
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
                in_node.AddString("CAUSE_FLOW", MPCF.Trim(LOT.GetString("FLOW")));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(LOT.GetString("OPER")));
                in_node.AddString("CODE", MPCF.Trim(cdvTerminateCode.Text));
                in_node.AddString("LOSS_COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddString("NO_SCRAP_FLAG", 'Y');
                //in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));
                //in_node.AddString("CHECK_USER_1", MPCF.Trim(txtChkUser1.Text), true);
                //in_node.AddString("CHECK_USER_2", MPCF.Trim(txtChkUser2.Text), true);
                //in_node.AddString("CHECK_USER_3", MPCF.Trim(txtChkUser3.Text), true);

                in_node.AddDouble("OUT_QTY_1", 0);

                terminate_item = in_node.AddNode("UNIT1");
                terminate_item.AddString("CODE", MPCF.Trim(cdvTerminateCode.Text));
                terminate_item.AddDouble("QTY", LOT.GetDouble("QTY_1"));

                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", ' ');

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

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
                */
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
