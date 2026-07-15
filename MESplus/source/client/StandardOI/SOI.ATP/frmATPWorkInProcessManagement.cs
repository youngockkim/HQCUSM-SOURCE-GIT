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
    public partial class frmATPWorkInProcessManagement : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COLS_PROCESS_LIST
        {
            LINE = 0,
            LINE_DESC,
            WORK_DATE,
            WORK_ORDER_ID,
            ORD_TYPE,
            MAT_ID,            
            MAT_DESC,
            MAT_VER,
            ORDER_QTY,
            IN_QTY,
            PROD_QTY,
            LOSS_QTY,
            REMAIN_QTY,
            PACK_QTY,
            ORD_STS,
            SHOP_CODE,
            ENTRY_TYPE
        }

        #endregion

        #region Constructor

        public frmATPWorkInProcessManagement()
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
            // Init Data
            DateTime dtNow = DateTime.Now;
            dtFromWorkDate.SetValueAsDateTime(dtNow);
            //dtNow = dtNow.AddDays(7);
            dtToWorkDate.SetValueAsDateTime(dtNow);

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
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Work Center CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkCenter_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Init Field
                MPCF.FieldClear(this, dtFromWorkDate, dtToWorkDate, cdvWorkCenter);

                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_WORK_CENTER_IN");
                TRSNode out_node = new TRSNode("VIEW_WORK_CENTER_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // CodeView Column Header Setup
                string[] header = new string[] { "Work Center", "Work Center Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvWorkCenter.Text = cdvWorkCenter.Show(cdvWorkCenter, "Work Center", "ATP", "ATP_View_Location_List", in_node, "PLANT_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Shop CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvShop_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Init Field
                MPCF.FieldClear(this, dtFromWorkDate, dtToWorkDate, cdvWorkCenter, cdvShop);

                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_SHOP_IN");
                TRSNode out_node = new TRSNode("VIEW_SHOP_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("PLANT_ID", cdvWorkCenter.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Shop", "Shop Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "SHOP_CODE", "SHOP_DESC" };

                // Show
                cdvShop.Text = cdvShop.Show(cdvShop, "Shop", "ATP", "ATP_View_Location_List", in_node, "SHOP_LIST", display, header, "SHOP_CODE");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Line CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_LINE_LIST_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("PLANT_ID", cdvWorkCenter.Text);
                in_node.AddString("SHOP_CODE", cdvShop.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Line", "Line Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "LINE_CODE", "LINE_DESC" };

                // Show
                cdvLine.Text = cdvLine.Show(cdvLine, "Line", "ATP", "ATP_View_Location_List", in_node, "LINE_LIST", display, header, "LINE_CODE");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Material CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                /// In Node Setup
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // CodeView Column Header Setup
                string[] header = new string[] { "Material ID", "Material Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                // Show
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material", "WIP", "WIP_View_Material_List", in_node, "List", display, header, "MAT_ID");                
                if (cdvMaterial.returnDatas == null || cdvMaterial.returnDatas.Count < 1)
                {
                    return;
                }

                txtMaterialDesc.Text = cdvMaterial.returnDatas[1];
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Work Order ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWorkOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter 
                && MPCF.Trim(txtWorkOrderID) != "")
            {
                //if (ViewLot(txtLotID.Text) == false)
                //{
                //    MPCF.SetFocus(txtLotID);
                //    return;
                //}
            }
        }

        /// <summary>
        /// Open Order Priority
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrderPriority_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (spdWorkOrder.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (spdWorkOrder.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                // Form 
                frmATPChangeWorkOrderPriority frm = new frmATPChangeWorkOrderPriority();
                frm.model.WorkDate = MPCF.DestroyDateFormat(Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.WORK_DATE].Value), DATE_TIME_FORMAT.DATE);
                frm.model.WorkCenter = cdvWorkCenter.Text;
                frm.model.LineId = cdvLine.Text;
                frm.model.Shop = cdvShop.Text;

                // Menu Info
                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPChangeWorkOrderPriority";
                menuInfo.s_func_desc = "Change Work Order Priority";
                menuInfo.s_func_name = "";

                // Open Form
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open Input Inventory Material
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputInvMat_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (spdWorkOrder.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (spdWorkOrder.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                frmATPInputInventoryMaterial frm = new frmATPInputInventoryMaterial();
                frm.model.WorkOrderID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.WORK_ORDER_ID].Value);
                frm.model.PackQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.PACK_QTY].Value);
                frm.model.Shop = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.SHOP_CODE].Value);
                frm.model.LineID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LINE].Value);
                frm.model.LineDesc = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LINE_DESC].Value);
                frm.model.MatID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.MAT_ID].Value);
                frm.model.MatDesc = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.MAT_DESC].Value);
                frm.model.OrderQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.ORDER_QTY].Value);
                frm.model.RemainQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.REMAIN_QTY].Value);
                frm.model.OutQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.PROD_QTY].Value);
                frm.model.LossQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LOSS_QTY].Value);

                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPInputInventoryMaterial";
                menuInfo.s_func_desc = "Input Inventory Material";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open Input Lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputLot_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (spdWorkOrder.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (spdWorkOrder.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                frmATPInputLot frm = new frmATPInputLot();
                frm.model.WorkOrderID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.WORK_ORDER_ID].Value);
                frm.model.PackQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.PACK_QTY].Value);
                frm.model.Shop = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.SHOP_CODE].Value);
                frm.model.LineID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LINE].Value);
                frm.model.LineDesc = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LINE_DESC].Value);
                frm.model.MatID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.MAT_ID].Value);
                frm.model.MatDesc = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.MAT_DESC].Value);
                frm.model.MatVer = MPCF.ToInt(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.MAT_VER].Value);
                frm.model.OrderQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.ORDER_QTY].Value);
                frm.model.RemainQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.REMAIN_QTY].Value);
                frm.model.OutQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.PROD_QTY].Value);
                frm.model.LossQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LOSS_QTY].Value);
                ////frm.model.Flow = ;

                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPInputLot";
                menuInfo.s_func_desc = "Input Lot";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open Entry Production Result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntryProdResult_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (spdWorkOrder.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (spdWorkOrder.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                frmATPEntryProductionResult frm = new frmATPEntryProductionResult();
                frm.model.WorkOrderID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.WORK_ORDER_ID].Value);
                frm.model.PackQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.PACK_QTY].Value);
                frm.model.Shop = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.SHOP_CODE].Value);
                frm.model.LineID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LINE].Value);
                frm.model.LineDesc = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LINE_DESC].Value);
                frm.model.MatID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.MAT_ID].Value);
                frm.model.MatDesc = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.MAT_DESC].Value);
                frm.model.OrderQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.ORDER_QTY].Value);
                frm.model.RemainQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.REMAIN_QTY].Value);
                frm.model.OutQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.PROD_QTY].Value);
                frm.model.LossQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LOSS_QTY].Value);

                // 선발행: Scan Already Printed Label (P)
                // 후발행: Input Quantity (Q)
                // 투입품: Scan Inventory Lot ID (I)
                string sEntryFlag = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.ENTRY_TYPE].Value);
                if(sEntryFlag.Equals("Y"))
                {
                    frm.model.EntryTypeFlag = 'P';
                    frm.model.EntryType = "Scan Already Printed Label";
                }
                else if (sEntryFlag.Equals("N"))
                {
                    frm.model.EntryTypeFlag = 'Q';
                    frm.model.EntryType = "Input Quantity";
                }
                else
                {
                    frm.model.EntryTypeFlag = 'I';
                    frm.model.EntryType = "Scan Inventory Lot ID";
                }                

                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPEntryProductionResult";
                menuInfo.s_func_desc = "Entry Production Result";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open Reprint Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReprintLabel_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (spdWorkOrder.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (spdWorkOrder.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                frmATPReprintLabel frm = new frmATPReprintLabel();
                frm.model.WorkOrderID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.WORK_ORDER_ID].Value);
                frm.model.PackQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.PACK_QTY].Value);
                frm.model.Shop = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.SHOP_CODE].Value);
                frm.model.LineID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LINE].Value);
                frm.model.LineDesc = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LINE_DESC].Value);
                frm.model.MatID = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.MAT_ID].Value);
                frm.model.MatDesc = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.MAT_DESC].Value);
                frm.model.OrderQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.ORDER_QTY].Value);
                frm.model.RemainQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.REMAIN_QTY].Value);
                frm.model.OutQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.PROD_QTY].Value);
                frm.model.LossQty = Convert.ToString(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.ActiveSheet.ActiveRowIndex, (int)COLS_PROCESS_LIST.LOSS_QTY].Value);

                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPReprintLabel";
                menuInfo.s_func_desc = "Reprint Label";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open Start Lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartLot_Click(object sender, EventArgs e)
        {
            try
            {
                frmATPStartLot frmStartLot = new frmATPStartLot();
                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPStartLot";
                menuInfo.s_func_desc = "Start Lot Function";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frmStartLot);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open End Lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndLot_Click(object sender, EventArgs e)
        {
            try
            {
                frmATPEndLot frmEndLot = new frmATPEndLot();
                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPEndLot";
                menuInfo.s_func_desc = "End Lot Function";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frmEndLot);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Work Order List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Required Field
                if (MPCF.CheckValue(cdvWorkCenter, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvShop, false) == false)
                {
                    return;
                }

                // View
                if(ViewWorkInProcess() == false)
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
        /// View Work In Process
        /// </summary>
        /// <returns></returns>
        private bool ViewWorkInProcess()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_WIP_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_WIP_LIST_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FROM_DATE", dtFromWorkDate.GetValueAsString(8));
                in_node.AddString("TO_DATE", dtToWorkDate.GetValueAsString(8));
                in_node.AddString("WORK_CENTER", cdvWorkCenter.Text);
                in_node.AddString("SHOP_CODE", cdvShop.Text);
                in_node.AddString("LINE_CODE", cdvLine.Text);
                in_node.AddString("MAT_ID", cdvMaterial.Text);
                in_node.AddString("ORDER_ID", txtWorkOrderID.Text);
                in_node.AddChar("ORD_STS_CLOSE", chkClose.Checked == true ? 'Y' : 'N');
                in_node.AddChar("ORD_STS_DELETE", chkDelete.Checked == true ? 'Y' : 'N');
                in_node.AddChar("ORD_STS_FINISH", chkFinish.Checked == true ? 'Y' : 'N');
                in_node.AddChar("ORD_STS_OPEN", chkOpen.Checked == true ? 'Y' : 'N');
                in_node.AddChar("ORD_STS_PRODUCE", chkProduce.Checked == true ? 'Y' : 'N');
                in_node.AddChar("ORD_STS_STOP", chkStop.Checked == true ? 'Y' : 'N');
                
                if (MPCF.CallService("ATP", "ATP_VIEW_WORKORDER_LIST", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Spread Clear
                spdWorkOrder.Sheets[0].Rows.Clear();

                // Bind
                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdWorkOrder.Sheets[0].Rows.Count;
                        spdWorkOrder.Sheets[0].RowCount++;

                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.LINE].Value = out_node.GetList(0)[i].GetString("LINE_CODE");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.LINE_DESC].Value = out_node.GetList(0)[i].GetString("LINE_DESC");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.WORK_DATE].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.WORK_ORDER_ID].Value = out_node.GetList(0)[i].GetString("ORDER_ID");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.ORD_TYPE].Value = out_node.GetList(0)[i].GetString("ORDER_TYPE");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.MAT_VER].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.ORDER_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("ORD_QTY"));
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.IN_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("ORD_IN_QTY"));
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.PROD_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("ORD_OUT_QTY"));
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.LOSS_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("ORD_LOSS_QTY"));
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.REMAIN_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("ORD_QTY") - out_node.GetList(0)[i].GetDouble("ORD_IN_QTY"));
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.PACK_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("ORD_PACK_QTY"));
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.ORD_STS].Value = Convert.ToString(out_node.GetList(0)[i].GetChar("ORD_STATUS_FLAG"));                        
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.SHOP_CODE].Value = out_node.GetList(0)[i].GetString("SHOP_CODE");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_PROCESS_LIST.ENTRY_TYPE].Value = Convert.ToString(out_node.GetList(0)[i].GetChar("PRE_PRINT_FLAG"));
                    }

                    MPCF.FitColumnHeader(spdWorkOrder);
                }

                // Show Success Message
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
