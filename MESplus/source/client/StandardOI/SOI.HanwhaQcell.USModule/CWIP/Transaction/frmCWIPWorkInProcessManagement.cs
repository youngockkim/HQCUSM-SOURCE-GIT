using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
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

using System.Globalization;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCWIPWorkInProcessManagement : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode LOT;
        private TRSNode ORDER;

        #endregion

        #region Constructor

        public frmCWIPWorkInProcessManagement()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum BOM_LIST
        {
            SEQ = 0,
            MAT_ID,
            MAT_DESC,
            QTY
        }

        public enum ATTACH_MAT_LIST
        {
            SEQ = 0,
            INV_BARCODE_ID,
            INV_MAT_ID,
            INV_LOT_ID,
            MAT_ID,
            MAT_DESC,
            ATTACH_TIME,
            LAST_USED_DATE,
            ATTACH_QTY,
            USED_QTY,
            REMAIN_QTY,
            UNIT
        }

        #endregion

        #region [Variable Definition]

        public PrintOptionModel printOption;

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCWIPWorkInProcessManagement_Load(object sender, EventArgs e)
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
        /// 

        private void frmCWIPWorkInProcessManagement_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(cdvLineID);

                bIsShown = true;
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Clear
                MPCF.FieldClear(pnlMiddleMargin, cdvLineID);

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }

                // View Current Order by Line ID
                ViewWorkOrder();

                // View Order BOM List by Line ID
                ViewOrderBOMList();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOper.Text = cdvOper.Show(cdvOper, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                // Clear
                MPCF.FieldClear(cdvResID);

                // Validation
                if (string.IsNullOrEmpty(cdvOper.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                //cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");
                cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Clear
                MPCF.FieldClear(pnlLotInfo);

                // Validation
                if (string.IsNullOrEmpty(cdvResID.Text) == true)
                {
                    return;
                }

                // View Lot by Resource
                ViewLotByResource();

                // View Attached Mat List
                ViewAttachedMatList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnLotIDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Lot ID Check
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // Clear
                MPCF.FieldClear(pnlLotInfo, txtLotID);

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

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    btnLotIDSearch.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                // Start Lot
                if (StartLot() == false)
                {
                    txtLotID.SelectAll();
                    MPCF.SetFocus(txtLotID);
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

        private void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                // End Lot
                if (EndLot() == false)
                {
                    txtLotID.SelectAll();
                    MPCF.SetFocus(txtLotID);
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
                frmWIPViewLotStatusPopup frm = new frmWIPViewLotStatusPopup(txtLotID.Text);
                frm.Owner = MPGV.gfrmMDI;
                //frm.ClientSize = new System.Drawing.Size(900, 643);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

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
                frmWIPViewLotHistoryPopup frm = new frmWIPViewLotHistoryPopup(txtLotID.Text);
                frm.Owner = MPGV.gfrmMDI;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (string.IsNullOrEmpty(txtWorkOrder.Text))
                {
                    MPCF.ShowMessage(MPCF.GetMessage(504), MSG_LEVEL.ERROR, false);
                    txtWorkOrder.Focus();
                    return;
                }

                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(txtWorkOrder.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        #endregion


        #region Function
        /*
        private bool ViewWorkOrder()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode order_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("KEY_1", MPCF.Trim(cdvLineID.Text));

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                order_list = out_node.GetList(0)[0];
                txtWorkOrder.Text = order_list.GetString("DATA_3");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        */

        private bool ViewWorkOrder()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CURRENT_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_CURRENT_ORDER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

                if (MPCF.CallService("CORD", "CORD_View_Current_Order_By_Line", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtWorkOrder.Text = out_node.GetString("ORDER_ID");
                txtMaterial.Text = out_node.GetString("MAT_ID") + " : " + out_node.GetString("MAT_DESC");
                txtFlow.Text = out_node.GetString("FLOW");
                txtWorkDate.Text = MPCF.MakeDateFormat(out_node.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                
                //txtDueDate.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_DUE_TIME"), DATE_TIME_FORMAT.DATE);

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

        private bool ViewOrderBOMList()
        {
            try
            {
                int i;
                MPCF.ClearList(spdBOM);
                
                TRSNode in_node = new TRSNode("VIEW_ORDER_BOM_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_BOM_LIST_OUT");
                TRSNode bom_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", MPCF.Trim(txtWorkOrder.Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Order_BOM_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdBOM.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    bom_list = out_node.GetList(0)[i];

                    spdBOM.ActiveSheet.RowCount++;

                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.SEQ].Value = bom_list.GetInt("SEQ");
                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.MAT_ID].Value = bom_list.GetString("MAT_ID");
                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.MAT_DESC].Value = bom_list.GetString("MAT_DESC");
                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.QTY].Value = bom_list.GetDouble("QTY");

                }

                MPCF.FitColumnHeader(spdBOM);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewAttachedMatList()
        {
            try
            {
                int i;
                MPCF.ClearList(spdAttachedMaterial);

                TRSNode in_node = new TRSNode("VIEW_ATTACH_MAT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ATTACH_MAT_LIST_OUT");
                TRSNode attached_mat_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

                if (MPCF.CallService("CRAS", "CRAS_View_Attached_Material_List_By_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdAttachedMaterial.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    attached_mat_list = out_node.GetList(0)[i];

                    spdAttachedMaterial.ActiveSheet.RowCount++;

                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.SEQ].Value = attached_mat_list.GetInt("SEQ");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.INV_BARCODE_ID].Value = attached_mat_list.GetString("INV_BARCODE_ID");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.INV_MAT_ID].Value = attached_mat_list.GetString("INV_MAT_ID");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.INV_LOT_ID].Value = attached_mat_list.GetString("INV_LOT_ID");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.MAT_ID].Value = attached_mat_list.GetString("MAT_ID");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.MAT_DESC].Value = attached_mat_list.GetString("MAT_DESC");

                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.ATTACH_TIME].Value = attached_mat_list.GetString("ATTACH_TIME");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.LAST_USED_DATE].Value = attached_mat_list.GetString("LAST_USED_DATE");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.ATTACH_QTY].Value = attached_mat_list.GetDouble("ATTACH_QTY");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.USED_QTY].Value = attached_mat_list.GetDouble("USED_QTY");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.REMAIN_QTY].Value = attached_mat_list.GetDouble("REMAIN_QTY");
                    spdAttachedMaterial.ActiveSheet.Cells[i, (int)ATTACH_MAT_LIST.UNIT].Value = attached_mat_list.GetString("UNIT");

                }

                MPCF.FitColumnHeader(spdAttachedMaterial);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewLotByResource()
        {
            try
            {
                LOT.Init();

                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                //TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("ORDER_ID", MPCF.Trim(txtWorkOrder.Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }

                txtLotID.Text = LOT.GetString("LOT_ID");
                txtLotMatID.Text = LOT.GetString("MAT_ID") + " : " + LOT.GetString("MAT_DESC");
                txtLotWorkOrder.Text = LOT.GetString("ORDER_ID");
                txtLotFlow.Text = LOT.GetString("FLOW") + " : " + LOT.GetString("FLOW_DESC");
                txtLotOper.Text = LOT.GetString("OPER") + " : " + LOT.GetString("OPER_DESC");
                txtLotQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));

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

        private bool ViewLot(string sLotId)
        {
            char sFlag = 'N';

            try
            {
                LOT.Init();

                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                //TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

                if (chkMagazineYn.Checked == true)
                    sFlag = 'Y';

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("MAGAZINE_INPUT_FLAG", sFlag);
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }

                txtLotID.Text = LOT.GetString("LOT_ID");
                txtLotMatID.Text = LOT.GetString("MAT_ID") + " : " + LOT.GetString("MAT_DESC");
                txtLotWorkOrder.Text = LOT.GetString("ORDER_ID");
                txtLotFlow.Text = LOT.GetString("FLOW") + " : " + LOT.GetString("FLOW_DESC");
                txtLotOper.Text = LOT.GetString("OPER") + " : " + LOT.GetString("OPER_DESC");
                txtLotQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));

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

        private bool StartLot()
        {
            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("START_LOT_OUT");

             char sFlag = 'N';

            try
            {
                MPCF.SetInMsg(in_node);

                if (chkMagazineYn.Checked == true)
                    sFlag = 'Y';

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("OPER", cdvOper.Text);
                in_node.AddString("LOT_OPER", LOT.GetString("OPER")); //LOT 의 OPER 필요시 서버에서 쓰세요
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("LINE_ID", cdvLineID.Text);
                in_node.AddString("MAGAZINE_INPUT_FLAG", sFlag);

                //NORMAL (CORE 호출하지 말고.. CUSTOM 으로 JJH)
                //체크로직은 확실하지 않은것말고 Client 에서 금지..서버에서 할것..
                if (MPCF.CallService("CWIP", "CWIP_Start_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                // View Lot
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

        private bool EndLot()
        {
            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("END_LOT_OUT");
            
            char sFlag = 'N';

            try
            {
                MPCF.SetInMsg(in_node);

                if (chkMagazineYn.Checked == true)
                    sFlag = 'Y';

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("OPER", cdvOper.Text);
                in_node.AddString("LOT_OPER", LOT.GetString("OPER")); //LOT 의 OPER 필요시 서버에서 쓰세요'
                in_node.AddString("MAGAZINE_INPUT_FLAG", sFlag);
                in_node.AddString("LINE_ID", cdvLineID.Text);

                //NORMAL (CORE 호출하지 말고.. CUSTOM 으로 JJH)
                //체크로직은 확실하지 않은것말고 Client 에서 금지..서버에서 할것..

                if (MPCF.CallService("CWIP", "CWIP_End_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                
                // View Lot
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

        private void chkMagazineYn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMagazineYn.Checked == true)
            {
                lblLotID.Text = "MAGAZINE ID";
            }
            else
            {
                lblLotID.Text = "LOT ID";
            }
            
        }






    }
}
