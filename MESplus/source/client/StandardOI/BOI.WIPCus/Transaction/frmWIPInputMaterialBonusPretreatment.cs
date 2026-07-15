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
    public partial class frmWIPInputMaterialBonusPretreatment : BOIBaseForm02
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
            SPEC
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

        private string _inputOper = string.Empty;
        private bool _isSemiProduct = false;
        private bool _isCarrierId = false;

        // (Required) 
        private bool bIsShown = false;

        private string _orderId = string.Empty;

        public string OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        private string _lotId = string.Empty;

        public string LotId
        {
            get { return _lotId; }
            set { _lotId = value; }
        }

        private string _matId = string.Empty;

        public string MatId
        {
            get { return _matId; }
            set { _matId = value; }
        }

        private string _oper = string.Empty;

        public string Oper
        {
            get { return _oper; }
            set { _oper = value; }
        }

        private string _flow = string.Empty;

        public string Flow
        {
            get { return _flow; }
            set { _flow = value; }
        }

        private string _lineId = string.Empty;

        public string LineId
        {
            get { return _lineId; }
            set { _lineId = value; }
        }

        private string _matBomType = string.Empty;

        public string MatBomType
        {
            get { return _matBomType; }
            set { _matBomType = value; }
        }
        
        //constant        
        BOI.WIPCus.Controls.BOIOrderInfo boiOrderInfo = new Controls.BOIOrderInfo();

        #endregion

        #region Constructor

        public frmWIPInputMaterialBonusPretreatment()
        {
            InitializeComponent();
            OrderHeaderChange();
        }

        public frmWIPInputMaterialBonusPretreatment(string args)
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
                InvisibleColumn();

                // (Required) 
                bIsShown = true;
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
                        ViewBomList(_matId, _matBomType, _oper, _orderId, _lotId);
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
                    string s_oper = _oper;
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

        private void btnInputBulk_Click(object sender, EventArgs e)
        {
            try
            {
                frmWIPInputBulkMaterialBatchingPretreatment frm = new frmWIPInputBulkMaterialBatchingPretreatment();
                frm.OrderId = _orderId;
                frm.LotId = _lotId;
                frm.MatId = _matId;
                frm.Oper = _oper;
                frm.Flow = _flow;
                frm.LineId = _lineId;
                frm.MatBomType = _matBomType;
                frm.ReinforceFlag = 'Y';
                frm.ShowDialog(this);
                ViewBomList(_matId, _matBomType, _oper, _orderId, _lotId);
                if (_lotId != string.Empty)
                {
                    ViewAssemblyList(_lotId, "");
                }

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
                    ViewBomList(_matId, _matBomType, _oper, _orderId, _lotId);                                        
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void boiSelectLotInfo_LotButtonClick(object sender, Controls.LotButtonClickEventArgs e)
        {
            
            _orderId = e.OrderId;
            _lotId = e.LotId;
            _matId = e.MatId;
            _oper = e.Oper;
            _lineId = e.LineId;
            _flow = e.Flow;
            _matBomType = e.MatBomType.ToString();
            boiOrderInfo.Oper = e.Oper;
            boiOrderInfo.View_Order_Info(e.OrderId);
            if (_lotId != string.Empty)
            {                
                if (boiSelectLotInfo.spdLotInfo.Sheets[0].RowCount > 0)
                {
                    ViewBomList(_matId, _matBomType, _oper, _orderId, _lotId);
                    if (_lotId != string.Empty)
                    {
                        ViewAssemblyList(_lotId, "");
                    }

                }
            }
            ChangeContlorStaus();
        }

        private void frmWIPInputMaterialBonusPretreatment_Com_1_DataReceived(string aData)
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
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[5];
            DataTable dt = null;
            string s_sql = "";
            int i = 0;

            try
            {
                spdTargetMaterial_Sheet1.RowCount = 0;                

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "MAT_ID";
                dvcArgu[1].sCondition_Value = matId;

                dvcArgu[2].sCondtion_ID = "MAT_BOM_TYPE";
                dvcArgu[2].sCondition_Value = matBomType;
                
                dvcArgu[3].sCondtion_ID = "ORDER_ID";
                dvcArgu[3].sCondition_Value = orderId;

                dvcArgu[4].sCondtion_ID = "LOT_ID";
                dvcArgu[4].sCondition_Value = lotId;

                if (TPDR.GetDataOne("", ref dt, "CWIP8050-001", dvcArgu, false, false, ref s_sql) == false)
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
                dvcArgu[3].sCondition_Value = "Y";

             


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
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.QTY].Value = MPCF.ToDbl(dt.Rows[i]["BONUS_QTY"].ToString());
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.REMAIN_QTY].Value = MPCF.ToDbl(dt.Rows[i]["REMAIN_QTY"].ToString());
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.LOSS_QTY].Value = MPCF.ToDbl(dt.Rows[i]["LOSS_QTY"].ToString());
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.SHELF_LIFE].Value = MPCF.ToDate(dt.Rows[i]["SHELF_LIFE"].ToString());
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.ASSY_LOT_TYPE].Value = MPCF.Trim(dt.Rows[i]["ASSY_LOT_TYPE"].ToString());
                }

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
                in_node.AddString("OPER", _inputOper);
                in_node.AddString("LINE_ID", _lineId);               
                in_node.AddString("LOT_ID", _lotId);
                in_node.AddString("ASS_LOT_ID", assLotId);
                in_node.AddChar("P_MAT_BOM_TYPE", _matBomType);
                in_node.AddDouble("IN_QTY_1", inQty);
                in_node.AddString("ACCOUNT_DETAIL", BIGC.B_INV_ACC_DETAIL_MOVE_INPUT);
                in_node.AddString("CMF_1", "N");                
                in_node.AddChar("REINFORCE_FLAG", 'Y'); //자재보강 플래그
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
                        inputQty = MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(foundRow, (int)BOM.BONUS_QTY));
                        inputQty += out_node.GetDouble("IN_QTY_1");

                        spdTargetMaterial_Sheet1.SetValue(foundRow, (int)BOM.BONUS_QTY, inputQty);

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
                    btnScrap.Enabled = false;
                    btnInputBulk.Enabled = false;
                }
                else
                {
                    if (_lotId == string.Empty)
                    {
                        btnReflectWorker.Enabled = false;
                        btnWeightConfirm.Enabled = false;
                        btnCancelInput.Enabled = false;
                        btnScrap.Enabled = false;
                        btnInputBulk.Enabled = false;
                    }
                    else
                    {
                        btnReflectWorker.Enabled = true;
                        btnWeightConfirm.Enabled = true;
                        btnCancelInput.Enabled = true;
                        btnScrap.Enabled = true;
                        btnInputBulk.Enabled = true;
                    }
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

        private void ViewBomList(string matId, string oper)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                spdTargetMaterial_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "MAT_ID";
                dvcArgu[1].sCondition_Value = matId;

                dvcArgu[2].sCondtion_ID = "OPER";
                dvcArgu[2].sCondition_Value = oper;


                if (TPDR.GetDataOne("", ref dt, "CWIP8050-0001", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();
                    GC.Collect();
                    return;
                }

                _inputOper = _oper;

                if (dt.Rows.Count > 0)
                {
                    
                    if (dt.Rows[0]["OPER_CMF_3"].ToString() == "Y")
                    {
                        //검사공정일 경우 이전공정 
                        _inputOper = dt.Rows[0]["PREV_OPER"].ToString();
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
            //boiLotInfo.VisibleColums = new List<int>();
            //boiLotInfo.VisibleColums.Add(BIGC.LOT.LOT_ID);
            //boiLotInfo.InvisibleColums = new List<int>();
            //boiLotInfo.InvisibleColums.Add(BIGC.LOT.OPER);
        }

        private void InvisibleColumn()
        {                        
            spdTargetMaterial.Sheets[0].Columns[(int)BOM.INPUT_QTY].Visible = false;
            spdTargetMaterial.Sheets[0].Columns[(int)BOM.SPEC].Visible = false;
            spdTargetMaterial.Sheets[0].Columns[(int)BOM.OVER_RATE].Visible = false;
        }       
    
        #endregion

       

        

 

        

       

       

       

       

        
        

       

        

        
    }
}
