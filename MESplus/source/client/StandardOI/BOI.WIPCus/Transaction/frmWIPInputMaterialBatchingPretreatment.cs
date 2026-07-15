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
using BOI.OIFrx.BOIBaseForm;
using SOI.DNM;
using BOI.OIFrx;
using BOI.WIPCus.Popup;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button    
    public partial class frmWIPInputMaterialBatchingPretreatment : BOIBaseForm02
    {
        #region struct
        struct MATLOTINFO
        {
            public static string lotId;
            public static double qty_1;
        }
	    #endregion

        #region Enum
        enum BOM
        {
            MAT_ID,
            MAT_DESC,            
            BOM_QTY,
            INPUT_QTY,
            BONUS_QTY,
            OVER_RATE,
            SPEC,
            LSL,
            USL
        }

        enum ASSEMBLY
        {
            INPUT_DATETIME,
            SEQ,
            MAT_LOT_ID,
            MATERIAL,
            MATERIAL_DESC,            
            QTY,
            REMAIN_QTY,
            LOSS_QTY,
            SHELF_LIFE,
            ASSY_LOT_TYPE
        }             


        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string _orderId = string.Empty;
        private string _lotId = string.Empty;
        private string _lineId = string.Empty;
        private bool _isSemiProduct = false;
        private bool _isCarrierId = false;
        
        //constant
        private const string BATCHING_OPER = "A100";

        #endregion

        #region Constructor

        public frmWIPInputMaterialBatchingPretreatment()
        {
            InitializeComponent();
            OrderHeaderChange();
        }

        public frmWIPInputMaterialBatchingPretreatment(string args)
        {
            InitializeComponent();
            _orderId = args;
            OrderHeaderChange();
        }
        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
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
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                if (_orderId != string.Empty)
                {
                    string matId = string.Empty;
                    string matBomType = string.Empty;
                    string oper = string.Empty;

                    
                    boiOrderInfo.View_Order_Info(_orderId);                                        
                    
                    if (boiOrderInfo.spdOrderInfo.Sheets[0].RowCount > 0)
                    {
                        matId = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.MAT_ID));
                        matBomType = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetValue(0, (int)BIGC.ORDER.MAT_BOM_TYPE));
                        oper = BATCHING_OPER;

                        ViewlotInfo(_orderId, oper, "Y");
                        ViewBomList(matId, matBomType, oper, _orderId, _lotId);
                        if (_lotId != string.Empty)
                        {
                            ViewAssemblyList(_lotId, oper);
                        }
                        
                    }                    
                }
                ChangeContlorStaus();

                // (Required) 
                bIsShown = true;
            }
        }

        private void boiOrderInfo_WorkOrderButtonClick(object sender, EventArgs e)
        {
            string matId = string.Empty;
            string matBomType = string.Empty;
            string oper = string.Empty;            

            if(boiOrderInfo.spdOrderInfo.Sheets[0].RowCount > 0)
            {
                _orderId = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetValue(0, (int)BIGC.ORDER.ORDER_ID));
                matId = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.MAT_ID));
                matBomType = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetValue(0, (int)BIGC.ORDER.MAT_BOM_TYPE));
                oper = BATCHING_OPER;

                ViewlotInfo(_orderId, oper, "Y");
                ViewBomList(matId, matBomType, oper, _orderId, _lotId);
                if (_lotId != string.Empty)
                {
                    ViewAssemblyList(_lotId, oper);
                }
                
            }
            ChangeContlorStaus();
        }

        private void btnStartWork_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("START_LOT") == true)
                {
                    if (Start_Lot('1') == true)
                    {                        
                        MPCF.ClearList(spdTargetMaterial);
                        MPCF.ClearList(spdAssemblyInvLot);
                        boiOrderInfo.View_Order_Info(_orderId);
                        boiOrderInfo_WorkOrderButtonClick(boiOrderInfo, e);
                    }
                }
                ChangeContlorStaus();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnReqInsp_Click(object sender, EventArgs e)
        {
            try
            {
                double endQty = 0.0d;
                double loadCellWeight = 0.0d;  
                if (CheckCondition("END_LOT") == true)
                {                    
                    for (int i = 0; i < spdTargetMaterial_Sheet1.RowCount; i++)
                    {
                        endQty += MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(i, (int)BOM.INPUT_QTY)) + MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(i, (int)BOM.BONUS_QTY));
                    }

                    frmWIPEndLotBatching frm = new frmWIPEndLotBatching();
                    frm.EndQty = endQty;
                    frm.Oper = boiOrderInfo.Oper;
                    frm.ResID = boiOrderInfo.ResId;                    
                    if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {

                        if (End_Lot('2', frm.LoadCellWeight) == true)
                        {
                            _orderId = string.Empty;
                            _lotId = string.Empty;
                            MPCF.ClearList(spdTargetMaterial);
                            MPCF.ClearList(spdAssemblyInvLot);
                            MPCF.ClearList(boiOrderInfo.spdOrderInfo);
                            MPCF.FieldClear(this);
                            ChangeContlorStaus();

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void chkOutSelection_ValueChanged(object sender, EventArgs e)
        {
            if (chkOutSelection.CheckedIndex == 0)
            {
                numInputQty.Enabled = true;
                numInputQty.ReadOnly = false;
            }
            else if (chkOutSelection.CheckedIndex == 1)
            {
                numInputQty.Enabled = false;
            }            
        }

        private void txtMaterialLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                string invLotid = string.Empty;
                int foundRow = 0;
                int foundColumn = 0;

                _isCarrierId = false;
                if (txtMaterialLot.Text.Contains(BIGC.B_CARRIER_LOT_PREFIX) == true)
                {
                    _isCarrierId = true;
                }

                if (_isCarrierId == true)
                {
                    if (ViewCarrierLot(MPCF.Trim(txtMaterialLot.Text), out invLotid))
                    {
                        if (invLotid == string.Empty)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(255), MSG_LEVEL.ERROR, false);                            
                            return;
                        }
                        txtMaterialLot.Tag = invLotid;
                        if (chkOutSelection.Items[0].CheckState == CheckState.Checked)
                        {
                            View_Lot(MPCF.Trim(invLotid));
                            numInputQty.Value = MATLOTINFO.qty_1;
                        }
                        spdAssemblyInvLot.Search(0, MPCF.Trim(invLotid), true, true, false, false, 0, 0, ref foundRow, ref foundColumn);
                        spdAssemblyInvLot_Sheet1.ActiveRowIndex = foundRow;
                        spdAssemblyInvLot_Sheet1.SetActiveCell(foundRow, foundColumn);
                    }
                    
                }
                else
                {
                    if (chkOutSelection.Items[0].CheckState == CheckState.Checked)
                    {
                        View_Lot(MPCF.Trim(txtMaterialLot.Text));
                        numInputQty.Value = MATLOTINFO.qty_1;
                    }
                    spdAssemblyInvLot.Search(0, txtMaterialLot.Text, true, true, false, false, 0, 0, ref foundRow, ref foundColumn);
                    spdAssemblyInvLot_Sheet1.ActiveRowIndex = foundRow;
                    spdAssemblyInvLot_Sheet1.SetActiveCell(foundRow, foundColumn);
                }

                txtMaterialLot.Focus();
                txtMaterialLot.SelectAll();

            }
        }

        private void btnWeightConfirm_Click(object sender, EventArgs e)
        {
            if (CheckCondition("ASSEMBLY_LOT") == true)
            {
                string lotId = string.Empty;
                if (_isCarrierId == true)
                {
                    lotId = MPCF.Trim(txtMaterialLot.Tag);
                }
                else
                {
                    lotId = MPCF.Trim(txtMaterialLot.Text);
                }
                if (Assembly_Lot('1', lotId, MPCF.ToDbl(numInputQty.Value)) == true)
                {
                    if (_isSemiProduct == true)
                    {
                        //반제품 일 경우 투입량확인을 위해 BOM화면을 재조회한다.                        
                        ViewBomList(boiOrderInfo.MatId, boiOrderInfo.BomMatType, BATCHING_OPER, _orderId, _lotId);
                    }
                }
            }
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {

            try
            {
                if (CheckCondition("LOSS_INV_LOT") == true)
                {
                    string s_selected_lot = MPCF.Trim(spdAssemblyInvLot.ActiveSheet.Cells[spdAssemblyInvLot.ActiveSheet.ActiveRowIndex, (int)ASSEMBLY.MAT_LOT_ID].Text);
                    string s_oper = MPCF.Trim(BATCHING_OPER);
                    frmWIPInputLossQty frm = new frmWIPInputLossQty(s_selected_lot, s_oper);
                    frm.ShowDialog(this);

                }
                ChangeContlorStaus();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }            
        }


        private void btnCancelInput_Click(object sender, EventArgs e)
        {
            try
            {
                string matLotId = string.Empty;
                int seqNo = 0;
                double qty = 0.0d;
                string assyLotType = string.Empty;
                int selectedRow = spdAssemblyInvLot_Sheet1.ActiveRowIndex;
                if (selectedRow < 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(424), MSG_LEVEL.ERROR, false);
                    return;
                }

                

                matLotId = MPCF.Trim(spdAssemblyInvLot_Sheet1.GetValue(selectedRow, (int)ASSEMBLY.MAT_LOT_ID));
                seqNo = MPCF.ToInt(spdAssemblyInvLot_Sheet1.GetValue(selectedRow, (int)ASSEMBLY.SEQ));
                qty = MPCF.ToDbl(spdAssemblyInvLot_Sheet1.GetValue(selectedRow, (int)ASSEMBLY.QTY));
                assyLotType = MPCF.Trim(spdAssemblyInvLot_Sheet1.GetValue(selectedRow, (int)ASSEMBLY.ASSY_LOT_TYPE));
                if (Disassembly_Lot('1', matLotId, seqNo, qty, assyLotType) == true)
                {
                    ViewBomList(boiOrderInfo.MatId, boiOrderInfo.BomMatType, BATCHING_OPER, _orderId, _lotId);                                        
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnInputBulk_Click(object sender, EventArgs e)
        {
            try
            {                
                frmWIPInputBulkMaterialBatchingPretreatment frm = new frmWIPInputBulkMaterialBatchingPretreatment();
                frm.OrderId = _orderId;
                frm.LotId = _lotId;
                frm.MatId = boiOrderInfo.MatId;
                frm.Oper = BATCHING_OPER;
                frm.Flow = boiOrderInfo.Flow;
                frm.LineId = boiOrderInfo.WorkOrderLineId;
                frm.MatBomType = boiOrderInfo.BomMatType;
                frm.ShowDialog(this);
                boiOrderInfo_WorkOrderButtonClick(sender, e);
                


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnReflectReRun_Click(object sender, EventArgs e)
        {
            frmWIPReflectRerunPretreatment frm = new frmWIPReflectRerunPretreatment();
            frm.OrderId = _orderId;
            frm.LotId = _lotId;
            frm.MatId = boiOrderInfo.MatId;
            frm.Oper = BATCHING_OPER;
            frm.Flow = boiOrderInfo.Flow;
            frm.LineId = boiOrderInfo.WorkOrderLineId;
            frm.MatBomType = boiOrderInfo.BomMatType;
            frm.ShowDialog(this);
            boiOrderInfo_WorkOrderButtonClick(sender, e);
        }

        private void btnReflectReSterilize_Click(object sender, EventArgs e)
        {
            frmWIPReflectReSterilizePretreatment frm = new frmWIPReflectReSterilizePretreatment();
            frm.OrderId = _orderId;
            frm.LotId = _lotId;
            frm.MatId = boiOrderInfo.MatId;
            frm.Oper = BATCHING_OPER;
            frm.Flow = boiOrderInfo.Flow;
            frm.LineId = boiOrderInfo.WorkOrderLineId;
            frm.MatBomType = boiOrderInfo.BomMatType;
            frm.ShowDialog(this);
            boiOrderInfo_WorkOrderButtonClick(sender, e);
        }      

        private void frmWIPInputMaterialBatchingPretreatment_H101MsgDataReceived(TRSNode node)
        {

            if (node.GetChar("MES_STATUS") == '1')
            {
                MPCF.CheckContinueProc(node, false);
            }
            else
            {
                boiOrderInfo_WorkOrderButtonClick(new object(), new EventArgs());
            }
        
        }

        private void frmWIPInputMaterialBatchingPretreatment_Com_1_DataReceived(string aData)
        {
            try
            {
                numInputQty.Value = MPCF.ToDbl(aData);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        

        #region Function

        
        private void ViewBomList(string matId, string matBomType, string oper, string orderId, string lotId)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];
            DataTable dt = null;
            string s_sql = "";
            int i = 0;

            try
            {
                spdTargetMaterial_Sheet1.RowCount = 0;                

                dvcArgu[2].sCondtion_ID = "FACTORY";
                dvcArgu[2].sCondition_Value = MPGV.gsFactory;

                dvcArgu[3].sCondtion_ID = "MAT_ID";
                dvcArgu[3].sCondition_Value = matId;

                dvcArgu[4].sCondtion_ID = "MAT_BOM_TYPE";
                dvcArgu[4].sCondition_Value = matBomType;

                dvcArgu[5].sCondtion_ID = "OPER";
                dvcArgu[5].sCondition_Value = oper;

                dvcArgu[0].sCondtion_ID = "ORDER_ID";
                dvcArgu[0].sCondition_Value = orderId;

                dvcArgu[1].sCondtion_ID = "LOT_ID";
                dvcArgu[1].sCondition_Value = lotId;

                if (TPDR.GetDataOne("", ref dt, "CWIP8040-001", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();
                    GC.Collect();
                    return;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdTargetMaterial_Sheet1.RowCount++;

                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();                    
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.BOM_QTY].Value = MPCF.ToDbl(dt.Rows[i]["BOM_QTY"].ToString());                    
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.INPUT_QTY].Value = MPCF.ToDbl(dt.Rows[i]["INPUT_QTY"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.BONUS_QTY].Value = MPCF.ToDbl(dt.Rows[i]["BONUS_QTY"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.OVER_RATE].Value = MPCF.ToDbl(dt.Rows[i]["OVER_RATE"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.SPEC].Value = MPCF.Trim(dt.Rows[i]["SPEC"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.LSL].Value = MPCF.ToDbl(dt.Rows[i]["LSL"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.USL].Value = MPCF.ToDbl(dt.Rows[i]["USL"].ToString());
                    if (MPCF.Trim(dt.Rows[i]["SPEC"].ToString()) == "OK")
                    {
                        spdTargetMaterial_Sheet1.Cells[i, (int)BOM.INPUT_QTY].BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        spdTargetMaterial_Sheet1.Cells[i, (int)BOM.INPUT_QTY].BackColor = Color.FromArgb(242, 242, 242);
                    }
                }                

            }
            catch(Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void ViewAssemblyList(string lotId, string oper)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            string s_sql = "";
            int i = 0;

            try
            {

                spdAssemblyInvLot_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LOT_ID";
                dvcArgu[1].sCondition_Value = lotId;

                dvcArgu[2].sCondtion_ID = "OPER";
                dvcArgu[2].sCondition_Value = oper;

                dvcArgu[3].sCondtion_ID = "REINFORCE_FLAG";
                dvcArgu[3].sCondition_Value = "";
             


                if (TPDR.GetDataOne("", ref dt, "CWIP8040-002", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();
                    GC.Collect();
                    return;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdAssemblyInvLot_Sheet1.RowCount++;
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.INPUT_DATETIME].Value = MPCF.ToDate(dt.Rows[i]["INPUT_DATETIME"].ToString());
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.SEQ].Value = dt.Rows[i]["SEQ"].ToString();
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.MAT_LOT_ID].Value = dt.Rows[i]["MAT_LOT_ID"].ToString();
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.MATERIAL].Value = dt.Rows[i]["MATERIAL"].ToString();
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.MATERIAL_DESC].Value = dt.Rows[i]["MATERIAL_DESC"].ToString();                    
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.QTY].Value = MPCF.ToDbl(dt.Rows[i]["QTY"].ToString());
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.REMAIN_QTY].Value = MPCF.ToDbl(dt.Rows[i]["REMAIN_QTY"].ToString());
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.LOSS_QTY].Value = MPCF.ToDbl(dt.Rows[i]["LOSS_QTY"].ToString());
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.SHELF_LIFE].Value = MPCF.MakeDateFormat(dt.Rows[i]["SHELF_LIFE"].ToString(), DATE_TIME_FORMAT.DATE);                    
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.ASSY_LOT_TYPE].Value = MPCF.Trim(dt.Rows[i]["ASSY_LOT_TYPE"].ToString());
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void ViewlotInfo(string orderId, string oper, string startFlag)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            string s_sql = "";            

            try
            {
                _lotId = string.Empty;
                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;               

                dvcArgu[1].sCondtion_ID = "OPER";
                dvcArgu[1].sCondition_Value = oper;

                dvcArgu[2].sCondtion_ID = "ORDER_ID";
                dvcArgu[2].sCondition_Value = orderId;

                dvcArgu[3].sCondtion_ID = "START_FLAG";
                dvcArgu[3].sCondition_Value = startFlag;
                

                if (TPDR.GetDataOne("", ref dt, "CWIP8040-003", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();
                    GC.Collect();
                    return;
                }

                _lotId = MPCF.Trim(dt.Rows[0]["LOT_ID"]);                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "START_LOT":
                        //Order ID
                        if (MPCF.Trim(boiOrderInfo.OrderId) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(422), MSG_LEVEL.WARNING, true);
                            boiOrderInfo.Focus();
                            return false;
                        }                        

                        //Start Res ID
                        if (MPCF.Trim(boiOrderInfo.ResId) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        break;

                    case "END_LOT":                        
                        //End Res ID
                        if (MPCF.Trim(boiOrderInfo.ResId) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        ViewBomList(boiOrderInfo.MatId, boiOrderInfo.BomMatType, BATCHING_OPER, _orderId, _lotId);
                        for (int i = 0; i < spdTargetMaterial_Sheet1.RowCount; i++)
                        {
                            if (MPCF.Trim(spdTargetMaterial_Sheet1.GetValue(i, (int)BOM.SPEC)) != "OK")
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(443), MSG_LEVEL.WARNING, true);
                                return false;
                            }
                        }

                        
                        break;

                    case "LOSS_INV_LOT":
                        if (spdAssemblyInvLot.Sheets[0].ActiveRowIndex < 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(424), MSG_LEVEL.WARNING, true);
                            return false;
                        }
                        break;

                    case "ASSEMBLY_LOT":
                        if (MPCF.Trim(txtMaterialLot.Text) == string.Empty)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(445), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        // Start_Lot()
        //       - Start Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Start_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("START_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _orderId);

                in_node.AddString("START_RES_ID", boiOrderInfo.ResId);

                in_node.AddString("MAT_ID", boiOrderInfo.MatId);
                in_node.AddInt("MAT_VER", boiOrderInfo.MatVer);
                in_node.AddString("FLOW", boiOrderInfo.Flow);
                in_node.AddString("OPER", BATCHING_OPER);
                in_node.AddString("LINE_ID", boiOrderInfo.WorkOrderLineId);

                in_node.AddDouble("QTY_1", 0);
                in_node.AddChar(BIGC.B_MEMBER_CAST_FLAG, 'Y');
           
                if (MPCF.CallService("BWIP", "BWIP_Tran_Start_Preprocessing", in_node, ref out_node) == false)
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

        // Start_Lot()
        //       - Start Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Assembly_Lot(char ProcStep, string assLotId, double inQty)
        {
            TRSNode in_node = new TRSNode("ASSEMBLY_LOT_IN");
            TRSNode out_node = new TRSNode("ASSEMBLY_LOT_OUT");
            int foundRow = -1;
            int foundColumn = -1;
            double inputQty = 0.0d;
            string crrierId = string.Empty;
            try
            {      

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _orderId);
                in_node.AddString("OPER", BATCHING_OPER);
                in_node.AddString("LINE_ID", boiOrderInfo.WorkOrderLineId);               
                in_node.AddString("LOT_ID", _lotId);
                in_node.AddString("ASS_LOT_ID", assLotId);
                in_node.AddChar("P_MAT_BOM_TYPE", boiOrderInfo.BomMatType);
                in_node.AddDouble("IN_QTY_1", inQty);
                in_node.AddString("ACCOUNT_DETAIL", BIGC.B_INV_ACC_DETAIL_MOVE_INPUT);
                in_node.AddString("CMF_1", "N");
                if (_isSemiProduct == true)
                {
                    in_node.AddChar("SEMI_PRODUCT_FLAG", 'Y');
                }                                
                if (_isCarrierId == true)
                {
                    crrierId = MPCF.Trim(txtMaterialLot.Text);
                    in_node.AddString("CRR_ID", crrierId);
                }

                if (MPCF.CallService("BWIP", "BWIP_Assembly_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                MPCF.ShowSuccessMessage(out_node, false);           

                spdAssemblyInvLot_Sheet1.AddRows(0, 1);
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.INPUT_DATETIME, MPCF.ToDate(out_node.GetString("LOAD_TIME")));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.SEQ, out_node.GetInt("SEQ_NUM"));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.MAT_LOT_ID, out_node.GetString("ASS_LOT_ID"));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.MATERIAL, out_node.GetString("C_MAT_ID"));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.MATERIAL_DESC, out_node.GetString("C_MAT_DESC"));                
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.QTY, out_node.GetDouble("IN_QTY_1"));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.REMAIN_QTY, out_node.GetDouble("C_MAT_LOT_QTY_1") - out_node.GetDouble("IN_QTY_1"));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.LOSS_QTY, 0);
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.SHELF_LIFE, MPCF.MakeDateFormat(out_node.GetString("SHELF_LIFE"), DATE_TIME_FORMAT.DATE));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.ASSY_LOT_TYPE, out_node.GetString("ASSY_LOT_TYPE"));                

                //원자재 투입일 경우만 해당 제품을 찾아 보여 준다.
                if (_isSemiProduct == false)
                {
                    spdTargetMaterial.Search(0, out_node.GetString("C_MAT_ID"), true, true, false, false, 0, 0, ref foundRow, ref foundColumn);
                    if (foundRow >= 0)
                    {
                        inputQty = MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(foundRow, (int)BOM.INPUT_QTY));
                        inputQty += out_node.GetDouble("IN_QTY_1");

                        if (inputQty >= MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(foundRow, (int)BOM.LSL)) &&
                            inputQty <= MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(foundRow, (int)BOM.USL)))
                        {
                            spdTargetMaterial_Sheet1.Cells[foundRow, (int)BOM.SPEC].Value = "OK";
                            spdTargetMaterial_Sheet1.Cells[foundRow, (int)BOM.INPUT_QTY].BackColor = Color.GreenYellow;
                        }
                        else
                        {
                            spdTargetMaterial_Sheet1.Cells[foundRow, (int)BOM.SPEC].Value = "NG";
                            spdTargetMaterial_Sheet1.Cells[foundRow, (int)BOM.INPUT_QTY].BackColor = Color.FromArgb(242, 242, 242);
                        }

                        spdTargetMaterial_Sheet1.SetValue(foundRow, (int)BOM.INPUT_QTY, inputQty);

                    }
                }
                txtMaterialLot.Text = string.Empty;
                numInputQty.Value = 0.00d;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        // Start_Lot()
        //       - Start Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Disassembly_Lot(char ProcStep, string assLotId, int seqNum, double inQty, string assyLotType)
        {
            TRSNode in_node = new TRSNode("ASSEMBLY_LOT_IN");
            TRSNode out_node = new TRSNode("ASSEMBLY_LOT_OUT");
            int foundRow = -1;
            int foundColumn = -1;
            double inputQty = 0.0d;

            try
            {

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("LOT_ID", _lotId);
                in_node.AddString("ASS_LOT_ID", assLotId);
                in_node.AddInt("SEQ_NUM", seqNum);
                in_node.AddDouble("IN_QTY_1", inQty);
                in_node.AddString("ACCOUNT_DETAIL", BIGC.B_INV_ACC_DETAIL_MOVE_CANCEL_INPUT);
                if (assyLotType == BIGC.B_ASSY_LOT_SP_TYPE)
                {
                    in_node.AddChar("SEMI_PRODUCT_FLAG", 'Y');
                }                

                if (MPCF.CallService("BWIP", "BWIP_Disassembly_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdAssemblyInvLot_Sheet1.RemoveRows(spdAssemblyInvLot_Sheet1.ActiveRowIndex, 1);

                spdTargetMaterial.Search(0, out_node.GetString("C_MAT_ID"), true, true, false, false, 0, 0, ref foundRow, ref foundColumn);
                if (foundRow >= 0)
                {
                    inputQty = MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(foundRow, (int)BOM.INPUT_QTY));
                    inputQty -= out_node.GetDouble("IN_QTY_1");

                    if (inputQty >= MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(foundRow, (int)BOM.LSL)) &&
                        inputQty <= MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(foundRow, (int)BOM.USL)))
                    {
                        spdTargetMaterial_Sheet1.Cells[foundRow, (int)BOM.SPEC].Value = "OK";
                        spdTargetMaterial_Sheet1.Cells[foundRow, (int)BOM.INPUT_QTY].BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        spdTargetMaterial_Sheet1.Cells[foundRow, (int)BOM.SPEC].Value = "NG";
                        spdTargetMaterial_Sheet1.Cells[foundRow, (int)BOM.INPUT_QTY].BackColor = Color.FromArgb(242, 242, 242);
                    }

                    spdTargetMaterial_Sheet1.SetValue(foundRow, (int)BOM.INPUT_QTY, inputQty);

                }

                txtMaterialLot.Text = string.Empty;
                numInputQty.Value = 0.00d;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        // End_Lot()
        //       - End Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool End_Lot(char ProcStep, double endQty)
        {
            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("END_LOT_OUT");
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _orderId);
                in_node.AddString("MAT_ID", boiOrderInfo.MatId);
                in_node.AddInt("MAT_VER", boiOrderInfo.MatVer);
                in_node.AddString("FLOW", boiOrderInfo.Flow);
                in_node.AddString("OPER", BATCHING_OPER);

                in_node.AddString("LOT_ID", _lotId);

                in_node.AddString("END_RES_ID", boiOrderInfo.ResId);
                in_node.AddDouble("END_QTY", endQty);
                in_node.AddChar("START_OPER_FLAG", "Y");

                if (MPCF.CallService("BWIP", "BWIP_Tran_End_Preprocessing", in_node, ref out_node) == false)
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
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool View_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
            int foundRow = -1;
            int foundColumn = -1;
            try
            {
                _isSemiProduct = false;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("MAT_TYPE")) == BIGC.B_MAT_TYPE_DUMMY)
                {
                    _isSemiProduct = true;
                }
                else
                {
                    _isSemiProduct = false;
                    spdTargetMaterial.Search(0, out_node.GetString("MAT_ID"), true, true, false, false, 0, 0, ref foundRow, ref foundColumn);
                    if (foundRow >= 0)
                    {
                        spdTargetMaterial_Sheet1.ActiveRowIndex = foundRow;
                        if (foundColumn >= 0)
                        {
                            spdTargetMaterial_Sheet1.ActiveColumnIndex = foundColumn;
                        }

                        spdTargetMaterial_Sheet1.SetActiveCell(foundRow, foundColumn);
                    }                    
                }

                MATLOTINFO.lotId = sLotID;
                MATLOTINFO.qty_1 = out_node.GetDouble("QTY_1");

                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }


        private bool ViewCarrierLot(string sCrrId, out string lotId)
        {
            TRSNode in_node = new TRSNode("VIEW_CARRIER_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_OUT");
            lotId = string.Empty;
            int listCnt = 0;
            try
            {                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_ID", MPCF.Trim(sCrrId));

                if (MPCF.CallService("RAS", "RAS_View_Carrier_Lot_List", in_node, ref out_node) == false)
                {                    
                    return false;
                }

                listCnt = out_node.GetList("CRRLOT_LIST").Count;
                for (int i = 0; i < listCnt; i++)
                {
                    lotId = out_node.GetList("CRRLOT_LIST")[i].GetString("LOT_ID");
                    break;
                }                               			

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void ChangeContlorStaus()
        {
            try
            {
                if (_orderId == string.Empty)
                {
                    btnReflectWorker.Enabled = false;
                    btnWeightConfirm.Enabled = false;
                    btnCancelInput.Enabled = false;
                    btnReflectReRun.Enabled = false;
                    btnReflectReSterilize.Enabled = false;
                    btnStartWork.Enabled = false;
                    btnInputBulk.Enabled = false;
                    btnScrap.Enabled = false;
                    btnReqInsp.Enabled = false;
                }
                else
                {
                    if (_lotId == string.Empty)
                    {
                        btnReflectWorker.Enabled = false;
                        btnWeightConfirm.Enabled = false;
                        btnCancelInput.Enabled = false;
                        btnReflectReRun.Enabled = false;
                        btnReflectReSterilize.Enabled = false;
                        btnStartWork.Enabled = true;
                        btnInputBulk.Enabled = false;
                        btnScrap.Enabled = false;
                        btnReqInsp.Enabled = false;
                    }
                    else
                    {
                        btnReflectWorker.Enabled = true;
                        btnWeightConfirm.Enabled = true;
                        btnCancelInput.Enabled = true;
                        btnReflectReRun.Enabled = true;
                        btnReflectReSterilize.Enabled = true;
                        btnStartWork.Enabled = false;
                        btnInputBulk.Enabled = true;
                        btnScrap.Enabled = true;
                        btnReqInsp.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);                
            }
        }

        private void OrderHeaderChange()
        {
            boiOrderInfo.VisibleColums = new List<BIGC.ORDER>();
            boiOrderInfo.VisibleColums.Add(BIGC.ORDER.LOT_ID);
            boiOrderInfo.InvisibleColums = new List<BIGC.ORDER>();
            boiOrderInfo.InvisibleColums.Add(BIGC.ORDER.OPER);
            boiOrderInfo.InvisibleColums.Add(BIGC.ORDER.ORD_QTY_1);
        }
    
        #endregion

        

       

       
        

      

       

       

       

        
        

       

        

        
    }
}
