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
using SOI.WIP;
using Infragistics.Win.UltraWinGrid;
using System.Collections;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCWIPCreateLot : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        private TRSNode ORDER = new TRSNode("ORDER_INFO");

        private string _flowOfOrder;
        private string sLotIdGenerationRuleId;        
        private string _sLabelID;
        private string _sLabelCommand;

        #endregion

        #region Constructor

        public frmCWIPCreateLot()
        {
            InitializeComponent();
        }

        #endregion

        #region Constant Definition

        public enum MODULE_LIST
        {
            SEQ,
            ARTICLE_NO,
            GR_BATCHNO,
            POWER_CLASS,
            GRADE,
            MODULE_ID
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCWIPCreateLot_Load(object sender, EventArgs e)
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
        private void frmCWIPCreateLot_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                // Lot ID Focus
                MPCF.SetFocus(cdvLineID);

                bIsShown = true;
            }
        }

        /// <summary>
        /// Work Line CodeView Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));

                string[] header = new string[] { "Line", "Line Desc" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                //// Close
                //if (cdvWorkLine.drResult == System.Windows.Forms.DialogResult.Cancel)
                //{
                //    return;
                //}

                // Clear
                MPCF.FieldClear(pnlMiddleMargin, cdvLineID);
                ORDER = null;
                txtWorkOrder.Text = txtMaterial.Text = txtFlow.Text = txtWorkDate.Text = "";
                lblOrderQty.Text = lblInQty.Text = lblOutQty.Text = lblLossQty.Text = "";
                cdvInOper.Text = txtQty.Text = txtDueDate.Text = txtLotID.Text = "";

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
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
        /// Work Order CodeView Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkOrder_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }

                // CodeView Service
                TRSNode in_node = new TRSNode("View_Order_List_Detail_In");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLineID.Text);
                //in_node.AddChar("ORD_STATUS_FLAG", 'Y');
                in_node.AddString("MAT_ID", "");

                string[] header = new string[] { "Order ID", "Order Desc" };
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                cdvWorkOrder.Code = cdvWorkOrder.Show(cdvWorkOrder, "View Production Order List By Line", "CORD", "CORD_View_Order_List_By_Line", in_node, "LIST", display, header, "ORDER_ID");

                //// Close
                //if (cdvWorkOrder.drResult == System.Windows.Forms.DialogResult.Cancel)
                //{
                //    return;
                //}

                // Clear
                MPCF.FieldClear(pnlMiddleMargin, cdvLineID, cdvWorkOrder);
                ORDER = null;
                _flowOfOrder = "";
                txtWorkOrder.Text = txtMaterial.Text = txtFlow.Text = txtWorkDate.Text = "";
                lblOrderQty.Text = lblInQty.Text = lblOutQty.Text = lblLossQty.Text = "";
                cdvInOper.Text = txtQty.Text = txtDueDate.Text = txtLotID.Text = "";

                // Validation
                if (cdvWorkOrder == null || cdvWorkOrder.Text == string.Empty)
                {
                    return;
                }

                // View Order
                if (ViewOrder(cdvWorkOrder.Text) == false)
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
        /// In Oper CodeView Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }

                // CodeView Service
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FLOW", _flowOfOrder);
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };
                cdvInOper.Text = cdvInOper.Show(cdvInOper, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "Oper");

                //// Close
                //if (cdvInOper.drResult == System.Windows.Forms.DialogResult.Cancel)
                //{
                //    return;
                //}

                // Clear
                MPCF.FieldClear(txtLotID);

                // Validation
                if (string.IsNullOrEmpty(cdvInOper.Text) == true)
                {
                    return;
                }                

                // Get Rule
                if (GetLotIdGenerationRule(cdvInOper.Text) == false)
                {
                    txtLotID.ReadOnly = false;
                    btnGenLotID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Work Order Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }

                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(cdvWorkOrder.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Order In Lot History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewOrderInLotHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }

                frmWIPViewOrderLotListPopup f = new frmWIPViewOrderLotListPopup();
                f.Owner = MPGV.gfrmMDI;
                f._orderID = cdvWorkOrder.Text;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Lot ID 발번 Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenLotID_Click(object sender, EventArgs e)
        {
            try
            {
                if (GenLotID() == false)
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
        /// Process Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvInOper, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtQty, 0.0005, Double.MaxValue, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // Create Lot
                if (CreateLot() == false)
                {
                    return;
                }

                // Focus
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

                ORDER = out_node;

                txtWorkOrder.Text = out_node.GetString("ORDER_ID") + " : " + out_node.GetString("ORDER_DESC");
                txtMaterial.Text = out_node.GetString("MAT_ID");
                //txtMaterial.Text = out_node.GetString("MAT_ID") + " : " + out_node.GetString("MAT_DESC");
                _flowOfOrder = txtFlow.Text = out_node.GetString("FLOW");
                txtWorkDate.Text = MPCF.MakeDateFormat(out_node.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);

                lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
                lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
                lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
                lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

                txtQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("QTY"));
                txtDueDate.Text = MPCF.MakeDateFormat(out_node.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                //txtWorkCenter.Text = out_node.GetString("ORD_CMF_2");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Lot ID 발번 규칙
        /// </summary>
        /// <param name="sOper"></param>
        /// <returns></returns>
        private bool GetLotIdGenerationRule(string sOper)
        {
            try
            {
                TRSNode in_node = new TRSNode("RULE_LIST_IN");
                TRSNode out_node = new TRSNode("RULE_LIST_OUT");
                string sRuleId = "";

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddChar("REL_LEVEL", '3');
                //in_node.AddString("MAT_ID", _model.ORDER.GetString("MAT_ID"));
                //in_node.AddString("FLOW", _model.ORDER.GetString("FLOW"));
                in_node.AddString("OPER", sOper);
                in_node.AddString("TRAN_CODE", "CREATE");
                in_node.AddString("NEXT_TRAN_CODE", "CREATE");

                if (MPCF.CallService("WIP", "WIP_View_Rule_Relation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList("LIST").Count > 0)
                {
                    sRuleId = out_node.GetList("LIST")[0].GetString("RULE_ID");
                }

                sLotIdGenerationRuleId = sRuleId;

                if (sRuleId == "")
                {
                    txtLotID.ReadOnly = false;
                    btnGenLotID.Enabled = false;
                }
                else
                {
                    txtLotID.ReadOnly = true;
                    btnGenLotID.Enabled = true;
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
        /// Lot ID 발번
        /// </summary>
        /// <returns></returns>
        private bool GenLotID()
        {
            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("GENERATE_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("RULE_ID", sLotIdGenerationRuleId);

                if (MPCF.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtLotID.Text = out_node.GetString("GEN_ID");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Lot 생성
        /// </summary>
        /// <returns></returns>
        private bool CreateLot()
        {
            TRSNode in_node = new TRSNode("Create_Lot_In");
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotID.Text);
                //in_node.AddString("LOT_DESC", MPCF.Trim(txtLotDesc.Text));
                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}
                in_node.AddString("MAT_ID", ORDER.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", ORDER.GetInt("MAT_VER"));
                in_node.AddString("FLOW", ORDER.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", ORDER.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", cdvInOper.Text);
                in_node.AddDouble("QTY_1", MPCF.ToDbl(txtQty.Text));
                in_node.AddChar("LOT_TYPE", ORDER.GetChar("LOT_TYPE"));
                in_node.AddString("CREATE_CODE", ORDER.GetString("CREATE_CODE"));
                in_node.AddString("OWNER_CODE", ORDER.GetString("OWNER_CODE"));
                in_node.AddChar("LOT_PRIORITY", ORDER.GetChar("LOT_PRIORITY"));
                in_node.AddString("DUE_TIME", ORDER.GetString("ORG_DUE_TIME"));
                in_node.AddChar("IN_CASE", '1');
                in_node.AddString("ORDER_ID", ORDER.GetString("ORDER_ID"));
                if (MPCF.CallService("CWIP", "CWIP_Create_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Print Label & Runsheet
                /*
                if (PrintLabelNRunsheet() == false)
                {
                    return false;
                }
                */

                // View Order
                if (ViewOrder(ORDER.GetString("ORDER_ID")) == false)
                {
                    return false;
                }

                // Init
                txtLotID.Text = "";

                // Success
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
        /// Label Command 조회
        /// </summary>
        /// <returns></returns>
        private bool GetLabelCommand()
        {
            try
            {
                // Init
                _sLabelID = string.Empty;
                _sLabelCommand = string.Empty;

                TRSNode in_node = new TRSNode("VIEW_LABEL_COMMAND_IN");
                TRSNode out_node = new TRSNode("VIEW_LABEL_COMMAND_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotID.Text);

                if (MPCF.CallService("LBL", "LBL_Get_Label_Print_Command", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList(0).Count > 0)
                {
                    _sLabelID = out_node.GetList(0)[0].GetString("LABEL_ID");

                    foreach (TRSNode node in out_node.GetList(0)[0].GetList("CMD_LIST"))
                    {
                        _sLabelCommand = node.GetString("CMD_1");
                    }
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
        /// Print Label
        /// </summary>
        /// <returns></returns>
        private bool PrintLabelNRunsheet()
        {
            try
            {
                // Label Print
                if (chkPrintLabel.Checked == true)
                {
                    // Get Command By Lat ID
                    if (GetLabelCommand() == false)
                    {
                        return false;
                    }

                    // Print by Command
                    if (MPCF.PrintLabelByCommand(this, base.printOption, _sLabelCommand, 1, null) == false)
                    {
                        return false;
                    }

                    // Add Print History
                    if (InsertPrintHistory(_sLabelID, txtLotID.Text, _sLabelCommand) == false)
                    {
                        return false;
                    }
                }

                if (PrintRunsheet() == false)
                {
                    return false;
                }

                // Clear Data
                _sLabelID = string.Empty;
                _sLabelCommand = string.Empty;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        
        /// <summary>
        /// Insert Print History
        /// </summary>
        /// <param name="lotId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        private bool InsertPrintHistory(string labelId, string lotId, string command)
        {
            TRSNode in_node = new TRSNode("UPDATE_PRINT_HISTORY_IN");
            TRSNode out_node = new TRSNode("UPDATE_PRINT_HISTORY_OUT");

            try
            {
                // Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddString("LABEL_ID", labelId);
                in_node.AddString("PRINTED_ID", lotId);
                in_node.AddString("COMMAND", command);
                if (MPCF.CallService("WIP", "WIP_Update_Print_History", in_node, ref out_node) == false)
                {
                    return false;
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
        /// Print Run Sheet
        /// </summary>
        /// <returns></returns>
        private bool PrintRunsheet()
        {
            try
            {
                // No need to print Runsheet
                if (string.IsNullOrEmpty(txtDueDate.Text) == true)
                {
                    return true;
                }

                // Print Runsheet
                if (MPCF.PrintRunsheet(this, base.printOption, txtLotID.Text, ORDER.GetString("MAT_ID"), ORDER) == false)
                {
                    return false;
                }

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
