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
using BOI.OIFrx.Popup;
using Miracom.POPCore;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button    
    public partial class frmWIPInputFragranceMaterial : BOIBaseForm02
    {
        #region struct
        struct MATLOTINFO
        {
            public static string lotId;
            public static double qty_1;
            public static string unit;
        }
	    #endregion

        #region Enum
        enum BOM
        {
            MAT_ID,
            MAT_DESC,            
            BOM_QTY,
            INPUT_QTY,
            OVER_RATE,
            SPEC,
            LSL,
            USL,
            UNIT
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
            UNIT
        }             


        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string _orderId = string.Empty;
        private string _lotId = string.Empty;
        private string _lineId = string.Empty;
        private Dictionary<string, Unit> unitList;
        private string _baseUnit = string.Empty;
        private string[] bom_list = new string[8];

        private Rs232 m_CommPort = new Rs232();
        //constant
        private const string FRAGRANCE_OPER = "P240";

        #endregion

        #region Constructor

        public frmWIPInputFragranceMaterial()
        {
            InitializeComponent();
            OrderHeaderChange();
        }

        public frmWIPInputFragranceMaterial(string args)
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
            //boiOrderInfo.Oper = FRAGRANCE_OPER;      
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
                
                //Unit 가져오기
                GetUnitList();

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
                        oper = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER));

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
                //GetUnitList();

                

                _orderId = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetValue(0, (int)BIGC.ORDER.ORDER_ID));
                matId = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.MAT_ID));
                matBomType = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetValue(0, (int)BIGC.ORDER.MAT_BOM_TYPE));
                oper = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER));

                ViewlotInfo(_orderId, oper, "Y");
                ViewBomList(matId, matBomType, oper, _orderId, _lotId);
                if (_lotId != string.Empty)
                {
                    ViewAssemblyList(_lotId, oper);
                }
                else
                {
                    MPCF.ClearList(spdAssemblyInvLot);
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
                if (CheckCondition("END_LOT") == true)
                {
                    frmWIPEndLotBatching frm = new frmWIPEndLotBatching();
                    if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {

                        if (End_Lot('2', frm.EndQty) == true)
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
                numInputQty.ReadOnly = false;
                numInputQty.Enabled = true;
            }
            else if (chkOutSelection.CheckedIndex == 1)
            {
                numInputQty.ReadOnly = true;
                numInputQty.Enabled = false;
            }
            


        }

        private void txtMaterialLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                int foundRow = 0;
                int foundColumn = 0;
                if (chkOutSelection.Items[0].CheckState == CheckState.Checked)
                {                    
                    View_Lot(MPCF.Trim(txtMaterialLot.Text));
                    numInputQty.Value = MATLOTINFO.qty_1;
                    //numInputQty.Value = MPCF.ToDbl(numInputQty.Value) * 1000;
                }
                spdAssemblyInvLot.Search(0, txtMaterialLot.Text, true, true, false, false, 0, 0, ref foundRow, ref foundColumn);
                spdAssemblyInvLot_Sheet1.ActiveRowIndex = foundRow;
                spdAssemblyInvLot_Sheet1.SetActiveCell(foundRow, foundColumn);
                

                txtMaterialLot.Focus();
                txtMaterialLot.SelectAll();

            }
        }

        private void btnWeightConfirm_Click(object sender, EventArgs e)
        {
            if (CheckCondition("ASSEMBLY_LOT") == true)
            {
                Assembly_Lot('1', MPCF.Trim(txtMaterialLot.Text), MPCF.ToDbl(numInputQty.Value));
            }
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {

            try
            {
                if (CheckCondition("LOSS_INV_LOT") == true)
                {
                    string s_selected_lot = MPCF.Trim(spdAssemblyInvLot.ActiveSheet.Cells[spdAssemblyInvLot.ActiveSheet.ActiveRowIndex, (int)ASSEMBLY.MAT_LOT_ID].Text);
                    string s_oper = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER));
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
                int selectedRow = spdAssemblyInvLot_Sheet1.ActiveRowIndex;
                if (selectedRow < 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(424), MSG_LEVEL.ERROR, false);
                    return;
                }

                

                matLotId = MPCF.Trim(spdAssemblyInvLot_Sheet1.GetValue(selectedRow, (int)ASSEMBLY.MAT_LOT_ID));
                seqNo = MPCF.ToInt(spdAssemblyInvLot_Sheet1.GetValue(selectedRow, (int)ASSEMBLY.SEQ));
                qty = MPCF.ToDbl(spdAssemblyInvLot_Sheet1.GetValue(selectedRow, (int)ASSEMBLY.QTY));

                if (Disassembly_Lot('1', matLotId, seqNo, qty) == true)
                {
                    ViewBomList(boiOrderInfo.MatId, boiOrderInfo.BomMatType, MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER)), _orderId, _lotId);                                        
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvCarrierId_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                chkUseCarrier.Checked = false;
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "CRR_GROUP";
                dvcArgu[1].sCondition_Value = "%";
                // CodeView Column Header Setup
                string[] header = new string[] { "Carrier", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "CRR_ID", "CRR_DESC" };

                // Show
                cdvCarrierId.Text = cdvCarrierId.Show(cdvCarrierId, "Carrier", "CWIP2401-0001", dvcArgu, display, header, "CRR_DESC", -1, true);

                if (MPCF.Trim(cdvCarrierId.Text) != "")
                {
                    if (cdvCarrierId.returnDatas.Count > 0)
                    {
                        cdvCarrierId.Tag = cdvCarrierId.returnDatas[0];
                        chkUseCarrier.Checked = true;
                    }
                    else
                    {
                        cdvCarrierId.Tag = "";
                        chkUseCarrier.Checked = false;
                    }
                }
                else
                {
                    cdvCarrierId.Tag = "";
                    chkUseCarrier.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            double endQty = 0.0d;
            try
            {
                if (CheckCondition("END_LOT") == true)
                {
                    //BOM정보 재조회
                    ViewBomList(boiOrderInfo.MatId, boiOrderInfo.BomMatType, MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER)), _orderId, _lotId);
                    for (int i = 0; i < spdTargetMaterial_Sheet1.RowCount; i++)
                    {
                        if (MPCF.Trim(spdTargetMaterial_Sheet1.GetValue(i, (int)BOM.SPEC)) != "OK")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(443), MSG_LEVEL.WARNING, true);
                            return;
                        }
                    }                   

                    for (int i = 0; i < spdTargetMaterial_Sheet1.RowCount; i++)
                    {
                        endQty += MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(i, (int)BOM.INPUT_QTY));  
                    }

                    if (End_Lot('1', endQty) == true)
                    {
                        _lotId = string.Empty;
                        boiOrderInfo.LotId = string.Empty;
                        MPCF.ClearList(spdTargetMaterial);
                        MPCF.ClearList(spdAssemblyInvLot);
                        ChangeContlorStaus();
                    }
                    

                    //frmWIPInputEndQty frm = new frmWIPInputEndQty();
                    //frm.EndQty = endQty;
                    //if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    //{                        

                    //}
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnSplitLabel_Click(object sender, EventArgs e)
        {
            bool splitLabel = false;
            double endQty = 0.0d;
            try
            {
                if (CheckCondition("END_LOT") == true)
                {
                    //BOM정보 재조회
                    ViewBomList(boiOrderInfo.MatId, boiOrderInfo.BomMatType, MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER)), _orderId, _lotId);
                    for (int i = 0; i < spdTargetMaterial_Sheet1.RowCount; i++)
                    {
                        if (MPCF.Trim(spdTargetMaterial_Sheet1.GetValue(i, (int)BOM.SPEC)) != "OK")
                        {
                            if (MPCF.ShowMsgBox(MPCF.GetMessage(465), MessageBoxButtons.YesNo, MSG_LEVEL.INFO, "INFO") == System.Windows.Forms.DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                splitLabel = true;
                                break;
                            }
                        }
                    }

                    for (int i = 0; i < spdTargetMaterial_Sheet1.RowCount; i++)
                    {
                        endQty += MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(i, (int)BOM.INPUT_QTY));
                    }

                    if (End_Lot('2', endQty) == true)
                    {
                        MPCF.ClearList(spdTargetMaterial);
                        MPCF.ClearList(spdAssemblyInvLot);
                        boiOrderInfo.View_Order_Info(_orderId);
                        boiOrderInfo_WorkOrderButtonClick(boiOrderInfo, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void cboUnit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ChangeBomQtyFromUnit();
                ChangeInputQtyFromUnit();
                ChangeLotQtyFromUnit();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmWIPInputFragranceMaterial_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetDefaultValueToReg();
        }

        private void btnPrintCornLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tran_Print_Label('C', "") == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmWIPInputFragranceMaterial_Com_1_DataReceived(string aData)
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

        private bool Tran_Print_Label(char cLblFlag, string LotID)
        {
            string[] PrintDataArray;
            string sPrintString = "";

            TRSNode in_node = new TRSNode("POP_TRAN_PRINT_LABEL_IN");
            TRSNode out_node = new TRSNode("POP_TRAN_PRINT_LABEL_OUT");
            TRSNode print_node;
            TRSNode design_node;
            try
            {

                MPCF.SetInMsg(in_node);
                if (cLblFlag == 'C') //콘과자 
                {
                    in_node.ProcStep = '4';
                    if (MPCF.Trim(cdvCarrierId.Tag) == "" || MPCF.Trim(cdvCarrierId.Tag) == null)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(469), MSG_LEVEL.WARNING, true);
                        cdvCarrierId.Focus();
                        return false;
                    }
                    else
                    {
                        in_node.AddString("LOT_ID", MPCF.Trim(cdvCarrierId.Tag));
                    }
                    in_node.AddString("SCREEN_ID", BIGC.B_LABEL_LB004);
                    in_node.AddChar("PRINT_HIS_FLAG", 'Y');
                }
                else if (cLblFlag == 'L') // 향료 라벨
                {
                    in_node.ProcStep = '5';
                    in_node.AddString("LOT_ID", MPCF.Trim(LotID));
                    in_node.AddString("SCREEN_ID", BIGC.B_LABEL_LB003);
                    in_node.AddChar("PRINT_HIS_FLAG", 'Y'); //재발행시는 N

                    ViewBomList_2(MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.MAT_ID)), MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetValue(0, (int)BIGC.ORDER.MAT_BOM_TYPE)), MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER)), MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetValue(0, (int)BIGC.ORDER.ORDER_ID)), MPCF.Trim(boiOrderInfo.LotId));
                    in_node.AddString("INV_MAT_DESC_1", bom_list[0] + "   " + bom_list[1]);
                    in_node.AddString("INV_MAT_DESC_2", bom_list[2] + "   " + bom_list[3]);
                    in_node.AddString("INV_MAT_DESC_3", bom_list[4] + "   " + bom_list[5]);
                    in_node.AddString("INV_MAT_DESC_4", bom_list[6] + "   " + bom_list[7]);
                }

                if (MPCF.CallService("BWIP", "BWIP_Tran_Print_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                /* 라벨 출력 항목들을 print_node에 초기화한다. */
                print_node = out_node.GetList("PRINT_LABEL_OUT")[0];
                design_node = out_node.GetList("LABEL_DESIGN_OUT")[0];
                string printer = MPCF.GetRegSetting(Application.ProductName, "Settings", "SAVE_PRINT_NAME");

                //spool
                if (MPCF.Trim(printer) == "" || printer == null)
                {
                    System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                    modPOPPrint.sPrinterName = pd.PrinterSettings.PrinterName;
                    printer = pd.PrinterSettings.PrinterName;
                    MPCF.SaveRegSetting(Application.ProductName, "Settings", "SAVE_PRINT_NAME", pd.PrinterSettings.PrinterName);
                }
                else
                {
                    modPOPPrint.sPrinterName = printer;
                }

                if (modPOPPrint.MakeZebraCommand(BIGC.B_PORT_SPOOL, m_CommPort, ref design_node, out PrintDataArray, true) == false)
                {
                    return false;
                }


                if (BICF.Fill_PrintDatas(ref print_node, PrintDataArray, out sPrintString) == false)
                {
                    return false;
                }

                if (modPOPPrint.Send_Data(BIGC.B_PORT_SPOOL, m_CommPort, sPrintString) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
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

                if (TPDR.GetDataOne("", ref dt, "CWIP8040-006", dvcArgu, false, false, ref s_sql) == false)
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
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.OVER_RATE].Value = MPCF.ToDbl(dt.Rows[i]["OVER_RATE"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.SPEC].Value = MPCF.Trim(dt.Rows[i]["SPEC"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.LSL].Value = MPCF.ToDbl(dt.Rows[i]["LSL"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.USL].Value = MPCF.ToDbl(dt.Rows[i]["USL"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.UNIT].Value = MPCF.Trim(dt.Rows[i]["UNIT"].ToString());
                    if (MPCF.Trim(dt.Rows[i]["SPEC"].ToString()) == "OK")
                    {
                        spdTargetMaterial_Sheet1.Cells[i, (int)BOM.INPUT_QTY].BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        spdTargetMaterial_Sheet1.Cells[i, (int)BOM.INPUT_QTY].BackColor = Color.FromArgb(242, 242, 242);
                    }
                }

                ChangeBomQtyFromUnit();

            }
            catch(Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void ViewBomList_2(string matId, string matBomType, string oper, string orderId, string lotId)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];
            DataTable dt = null;
            string s_sql = "";
            int i = 0;

            try
            {
                spdTargetMaterial_Sheet1.RowCount = 0;

                for (int j = 0; j < bom_list.Length; j++)
                {
                    bom_list[j] = "";
                }

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

                if (TPDR.GetDataOne("", ref dt, "CWIP8040-006", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();
                    GC.Collect();
                    return;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    bom_list[i] = dt.Rows[i]["MAT_ID"].ToString() + " " + dt.Rows[i]["MAT_DESC"].ToString() + " (" + dt.Rows[i]["INPUT_QTY"].ToString() + " " + dt.Rows[i]["UNIT"].ToString() + ")";
                }
            }
            catch (Exception ex)
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
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.SHELF_LIFE].Value = MPCF.ToDate(dt.Rows[i]["SHELF_LIFE"].ToString());
                    spdAssemblyInvLot_Sheet1.Cells[i, (int)ASSEMBLY.UNIT].Value = MPCF.Trim(BIGC.B_DATABASE_DEFAULT_UNIT);

                }
                ChangeInputQtyFromUnit();
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
                boiOrderInfo.LotId = _lotId;
                
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
                        if (MPCF.Trim(boiOrderInfo.OrderId) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(422), MSG_LEVEL.WARNING, true);
                            boiOrderInfo.Focus();
                            return false;
                        }                                                

                        break;

                    case "END_LOT":                                                                      
                        
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
                            txtMaterialLot.Focus();
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
                in_node.AddString("OPER", MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER)));
                in_node.AddString("LINE_ID", boiOrderInfo.WorkOrderLineId);

                in_node.AddDouble("QTY_1", 0);
           
                if (MPCF.CallService("BWIP", "BWIP_Tran_Start_Flavor_Oper", in_node, ref out_node) == false)
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
            Unit baseUnit;
            Unit selectUnit;
            TRSNode in_node = new TRSNode("ASSEMBLY_LOT_IN");
            TRSNode out_node = new TRSNode("ASSEMBLY_LOT_OUT");
            int foundRow = -1;
            int foundColumn = -1;
            double inputQty = 0.0d;
            double ConvertValue = 0.0d;

            double convetInputQty = 0.0d;
            double convetChildMatQty = 0.0d;
            
            try
            {
                //향료는 g단위로 계근되어 kg으로 변경함
                selectUnit = (Unit)cboUnit.SelectedItem.DataValue;
                unitList.TryGetValue("KG", out baseUnit);
                selectUnit.ConvertValue("KG", inQty, out ConvertValue);
                inQty = ConvertValue;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _orderId);
                in_node.AddString("OPER", MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER)));
                in_node.AddString("LINE_ID", boiOrderInfo.WorkOrderLineId);               
                in_node.AddString("LOT_ID", _lotId);
                in_node.AddString("ASS_LOT_ID", assLotId);
                in_node.AddChar("P_MAT_BOM_TYPE", boiOrderInfo.BomMatType);
                in_node.AddDouble("IN_QTY_1", inQty);
                in_node.AddString("ACCOUNT_DETAIL", BIGC.B_INV_ACC_DETAIL_MOVE_INPUT);
                in_node.AddString("CMF_1", "N");


                if (MPCF.CallService("BWIP", "BWIP_Assembly_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                MPCF.ShowSuccessMessage(out_node, false);

                baseUnit.ConvertValue(selectUnit.BaseUnit, out_node.GetDouble("IN_QTY_1"), out convetInputQty);
                baseUnit.ConvertValue(selectUnit.BaseUnit, out_node.GetDouble("C_MAT_LOT_QTY_1"), out convetChildMatQty);

                spdAssemblyInvLot_Sheet1.AddRows(0, 1);
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.INPUT_DATETIME, MPCF.ToDate(out_node.GetString("LOAD_TIME")));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.SEQ, out_node.GetInt("SEQ_NUM"));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.MAT_LOT_ID, out_node.GetString("ASS_LOT_ID"));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.MATERIAL, out_node.GetString("C_MAT_ID"));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.MATERIAL_DESC, out_node.GetString("C_MAT_DESC"));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.QTY, convetInputQty);                
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.REMAIN_QTY, convetChildMatQty - convetInputQty);
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.LOSS_QTY, 0);
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.SHELF_LIFE, MPCF.MakeDateFormat(out_node.GetString("SHELF_LIFE"), DATE_TIME_FORMAT.DATE));
                spdAssemblyInvLot_Sheet1.SetValue(0, (int)ASSEMBLY.UNIT, selectUnit.BaseUnit);

                spdTargetMaterial.Search(0, out_node.GetString("C_MAT_ID"), true, true, false, false, 0, 0, ref foundRow, ref foundColumn);
                if (foundRow >= 0)
                {
                    inputQty = MPCF.ToDbl(spdTargetMaterial_Sheet1.GetValue(foundRow, (int)BOM.INPUT_QTY));
                    inputQty += convetInputQty;

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

        // Start_Lot()
        //       - Start Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Disassembly_Lot(char ProcStep, string assLotId, int seqNum, double inQty)
        {
            Unit baseUnit;
            Unit selectUnit;
            TRSNode in_node = new TRSNode("ASSEMBLY_LOT_IN");
            TRSNode out_node = new TRSNode("ASSEMBLY_LOT_OUT");
            int foundRow = -1;
            int foundColumn = -1;
            double inputQty = 0.0d;
            double ConvertValue = 0.0d;

            try
            {
                //향료는 g단위로 계근되어 kg으로 변경함
                selectUnit = (Unit)cboUnit.SelectedItem.DataValue;
                unitList.TryGetValue("KG", out baseUnit);
                selectUnit.ConvertValue("KG", inQty, out ConvertValue);
                inQty = ConvertValue;


                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("LOT_ID", _lotId);
                in_node.AddString("ASS_LOT_ID", assLotId);
                in_node.AddInt("SEQ_NUM", seqNum);
                in_node.AddDouble("IN_QTY_1", inQty);
                in_node.AddString("ACCOUNT_DETAIL", BIGC.B_INV_ACC_DETAIL_MOVE_CANCEL_INPUT);


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
            Unit baseUnit;
            Unit selectUnit;
            double ConvertValue = 0.0d;
            try
            {

                //향료는 g단위로 계근되어 kg으로 변경함
                selectUnit = (Unit)cboUnit.SelectedItem.DataValue;
                unitList.TryGetValue("KG", out baseUnit);
                selectUnit.ConvertValue("KG", endQty, out ConvertValue);
                endQty = ConvertValue;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _orderId);
                in_node.AddString("MAT_ID", boiOrderInfo.MatId);
                in_node.AddInt("MAT_VER", boiOrderInfo.MatVer);
                in_node.AddString("FLOW", boiOrderInfo.Flow);
                in_node.AddString("OPER", MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetTag(0, (int)BIGC.ORDER.OPER)));

                in_node.AddString("LOT_ID", _lotId);

                in_node.AddString("END_RES_ID", boiOrderInfo.ResId);
                in_node.AddDouble("END_QTY", endQty);            

                if (chkUseCarrier.Checked == true)
                {
                    in_node.AddChar("USE_CRR", 'Y');
                    in_node.AddString("CRR_ID", MPCF.Trim(cdvCarrierId.Tag));
                }

                if (MPCF.CallService("BWIP", "BWIP_Tran_End_Semi_Product", in_node, ref out_node) == false)
                {
                    return false;
                }
                //라벨 발행
                //if (Tran_Print_Label('L', out_node.GetString("LOT_ID")) == false)
                //{
                //    return false;
                //}

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
            Unit unit;

            try
            {                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

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

                if (unitList.TryGetValue("KG", out unit))
                {
                    MATLOTINFO.lotId = sLotID;
                    unit.ConvertValue(((Unit)cboUnit.SelectedItem.DataValue).BaseUnit, out_node.GetDouble("QTY_1"), out MATLOTINFO.qty_1);
                    MATLOTINFO.unit = ((Unit)cboUnit.SelectedItem.DataValue).BaseUnit;
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
                }
                else
                {
                    if (_lotId == string.Empty)
                    {
                        btnReflectWorker.Enabled = false;
                        btnWeightConfirm.Enabled = false;
                        btnCancelInput.Enabled = false;
                        btnStartWork.Enabled = true;
                        btnScrap.Enabled = false;
                    }
                    else
                    {
                        btnReflectWorker.Enabled = true;
                        btnWeightConfirm.Enabled = true;
                        btnCancelInput.Enabled = true;
                        btnStartWork.Enabled = false;
                        btnScrap.Enabled = true;
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
            boiOrderInfo.InvisibleColums.Add(BIGC.ORDER.RES_ID);
        }

        private void GetUnitList()
        {
            try
            {                
                cboUnit.Items.Clear();
                bool addItem = false;
                Unit unit = null;
                Unit cmpunit = null;
                Unit.UnitConvert unitConvert = null;
                unitList = null;

                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");
                List<TRSNode> lisData;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "UNIT_CONVERT");                

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return;
                }

                lisData = out_node.GetList("DATA_LIST");

                if (lisData.Count > 0)
                {
                    unitList = new Dictionary<string, Unit>();

                    for (int i = 0; i < lisData.Count; i++)
                    {
                        addItem = false;
                        unit = null;
                        if (cboUnit.Items.Count > 0)
                        {
                            for (int j = 0; j < cboUnit.Items.Count; j++)
                            {
                                cmpunit = null;
                                cmpunit = new Unit();
                                cmpunit.BaseUnit = MPCF.Trim(lisData[i].GetString("KEY_1"));
                                if (((Unit)cboUnit.Items[j].DataValue).Equals(cmpunit))
                                {
                                    unit = (Unit)cboUnit.Items[j].DataValue;
                                    break;
                                }
                            }
                            if (unit == null)
                            {
                                addItem = true;
                                unit = new Unit();
                                unit.BaseUnit = MPCF.Trim(lisData[i].GetString("KEY_1"));
                            }
                        }
                        else
                        {
                            addItem = true;
                            unit = new Unit();
                            unit.BaseUnit = MPCF.Trim(lisData[i].GetString("KEY_1"));
                        }
                        
                        unitConvert = new Unit.UnitConvert();                        
                        unitConvert.ToUnit = MPCF.Trim(lisData[i].GetString("KEY_2"));
                        unitConvert.ScaleFactor = MPCF.ToDbl(lisData[i].GetString("DATA_1"));
                        if (unit.UnitConvertList == null)
                        {
                            unit.UnitConvertList = new Dictionary<string, Unit.UnitConvert>();
                        }
                        unit.UnitConvertList.Add(MPCF.Trim(lisData[i].GetString("KEY_2")), unitConvert);

                        if (addItem == true)
                        {
                            cboUnit.Items.Add(unit, lisData[i].GetString("KEY_1"));
                            unitList.Add(lisData[i].GetString("KEY_1"), unit);
                        }
                        
                    }

                    GetDefaultValueFromReg();

                    if (_baseUnit == string.Empty)
                    {
                        cboUnit.SelectedIndex = 0;
                    }
                    else
                    {
                        cboUnit.SelectedIndex = cboUnit.Items.ValueList.FindString(_baseUnit);
                    }
                    
                }

                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool ChangeBomQtyFromUnit()
        {
            try
            {
                Unit baseUnit;
                List<double> valueBom = new List<double>();
                List<double> valueInput = new List<double>();
                List<double> valueLsl = new List<double>();
                List<double> valueUsl = new List<double>();
                List<string> unit = new List<string>();
                bool succeedConverting = true;

                double convertValue = 0.0d;
                //BOM 단위표시 변경
                for (int i = 0; i < spdTargetMaterial.Sheets[0].RowCount; i++)
                {
                    if (cboUnit.SelectedItem != null)
                    {
                        unitList.TryGetValue(MPCF.Trim(spdTargetMaterial.Sheets[0].GetValue(i, (int)BOM.UNIT)), out baseUnit);
                        if (baseUnit != null)
                        {
                            //BOM수량 삽입
                            if (baseUnit.ConvertValue(((Unit)cboUnit.SelectedItem.DataValue).BaseUnit,
                                                                                            MPCF.ToDbl(spdTargetMaterial.Sheets[0].GetValue(i, (int)BOM.BOM_QTY)),
                                                                                            out convertValue))
                            {
                                valueBom.Add(convertValue);
                                unit.Add(cboUnit.SelectedItem.DisplayText);
                                if (baseUnit.ConvertValue(((Unit)cboUnit.SelectedItem.DataValue).BaseUnit,
                                                                                            MPCF.ToDbl(spdTargetMaterial.Sheets[0].GetValue(i, (int)BOM.INPUT_QTY)),
                                                                                            out convertValue))
                                {
                                    valueInput.Add(convertValue);
                                    if (baseUnit.ConvertValue(((Unit)cboUnit.SelectedItem.DataValue).BaseUnit,
                                                                                                MPCF.ToDbl(spdTargetMaterial.Sheets[0].GetValue(i, (int)BOM.LSL)),
                                                                                                out convertValue))
                                    {
                                        valueLsl.Add(convertValue);
                                        if (baseUnit.ConvertValue(((Unit)cboUnit.SelectedItem.DataValue).BaseUnit,
                                                                                                MPCF.ToDbl(spdTargetMaterial.Sheets[0].GetValue(i, (int)BOM.USL)),
                                                                                                out convertValue))
                                        {
                                            valueUsl.Add(convertValue);
                                        }
                                        else
                                        {
                                            succeedConverting = false;
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        succeedConverting = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    succeedConverting = false;
                                    break;
                                }

                            }
                            else
                            {
                                succeedConverting = false;
                                break;
                            }


                        }
                        else
                        {
                            succeedConverting = false;
                            break;
                        }
                        
                    }
                }

                if (succeedConverting == true)
                {
                    for (int i = 0; i < valueBom.Count; i++)
                    {
                        spdTargetMaterial.Sheets[0].SetValue(i, (int)BOM.BOM_QTY, valueBom[i]);
                        spdTargetMaterial.Sheets[0].SetValue(i, (int)BOM.INPUT_QTY, valueInput[i]);
                        spdTargetMaterial.Sheets[0].SetValue(i, (int)BOM.LSL, valueLsl[i]);
                        spdTargetMaterial.Sheets[0].SetValue(i, (int)BOM.USL, valueUsl[i]);
                        spdTargetMaterial.Sheets[0].SetValue(i, (int)BOM.UNIT, unit[i]);
                    }
                }
                else
                {
                    MPCF.ShowMessage(MPCF.GetMessage(459), MSG_LEVEL.ERROR, true);
                }


                return succeedConverting;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ChangeInputQtyFromUnit()
        {
            try
            {
                Unit baseUnit;
                List<double> valueInputQty = new List<double>();
                List<double> valueRemainQty = new List<double>();
                List<double> valueLossQty = new List<double>();
                List<string> unit = new List<string>();
                bool succeedConverting = true;

                double convertValue = 0.0d;
                //ASSEMBLY 단위표시 변경
                for (int i = 0; i < spdAssemblyInvLot.Sheets[0].RowCount; i++)
                {
                    if (cboUnit.SelectedItem != null)
                    {
                        unitList.TryGetValue(MPCF.Trim(spdAssemblyInvLot.Sheets[0].GetValue(i, (int)ASSEMBLY.UNIT)), out baseUnit);
                        if (baseUnit != null)
                        {                            
                            if (baseUnit.ConvertValue(((Unit)cboUnit.SelectedItem.DataValue).BaseUnit,
                                                                                            MPCF.ToDbl(spdAssemblyInvLot.Sheets[0].GetValue(i, (int)ASSEMBLY.QTY)),
                                                                                            out convertValue))
                            {
                                valueInputQty.Add(convertValue);
                                unit.Add(cboUnit.SelectedItem.DisplayText);
                                if (baseUnit.ConvertValue(((Unit)cboUnit.SelectedItem.DataValue).BaseUnit,
                                                                                            MPCF.ToDbl(spdAssemblyInvLot.Sheets[0].GetValue(i, (int)ASSEMBLY.REMAIN_QTY)),
                                                                                            out convertValue))
                                {
                                    valueRemainQty.Add(convertValue);
                                    if (baseUnit.ConvertValue(((Unit)cboUnit.SelectedItem.DataValue).BaseUnit,
                                                                                            MPCF.ToDbl(spdAssemblyInvLot.Sheets[0].GetValue(i, (int)ASSEMBLY.LOSS_QTY)),
                                                                                            out convertValue))
                                    {
                                        valueLossQty.Add(convertValue);
                                    }
                                    else
                                    {
                                        succeedConverting = false;
                                        break;
                                    }

                                }
                                else
                                {
                                    succeedConverting = false;
                                    break;
                                }

                            }
                            else
                            {
                                succeedConverting = false;
                                break;
                            }


                        }
                        else
                        {
                            succeedConverting = false;
                            break;
                        }

                    }
                }

                if (succeedConverting == true)
                {
                    for (int i = 0; i < valueInputQty.Count; i++)
                    {
                        spdAssemblyInvLot.Sheets[0].SetValue(i, (int)ASSEMBLY.QTY, valueInputQty[i]);
                        spdAssemblyInvLot.Sheets[0].SetValue(i, (int)ASSEMBLY.REMAIN_QTY, valueRemainQty[i]);
                        spdAssemblyInvLot.Sheets[0].SetValue(i, (int)ASSEMBLY.LOSS_QTY, valueLossQty[i]);
                        spdAssemblyInvLot.Sheets[0].SetValue(i, (int)ASSEMBLY.UNIT, unit[i]);
                    }
                }
                else
                {
                    MPCF.ShowMessage(MPCF.GetMessage(459), MSG_LEVEL.ERROR, true);
                }


                return succeedConverting;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ChangeLotQtyFromUnit()
        {
            try
            {
                Unit baseUnit;
                double value = 0;
                string unit = string.Empty;
                bool succeedConverting = true;

                double convertValue = 0.0d;
                //BOM 단위표시 변경
                if (cboUnit.SelectedItem != null && (MATLOTINFO.unit != null && MATLOTINFO.unit != string.Empty))
                {
                    unitList.TryGetValue(MATLOTINFO.unit, out baseUnit);
                    if (baseUnit != null)
                    {
                        if (baseUnit.ConvertValue(((Unit)cboUnit.SelectedItem.DataValue).BaseUnit,
                                                                            MPCF.ToDbl(numInputQty.Value),
                                                                            out convertValue))
                        {
                            value = convertValue;
                            unit = cboUnit.SelectedItem.DisplayText;

                        }
                        else
                        {
                            succeedConverting = false;                            
                        }
                    }
                    else
                    {
                        succeedConverting = false;                        
                    }

                }

                if (succeedConverting == true)
                {
                    numInputQty.Value = convertValue;
                    MATLOTINFO.unit = unit;
                }
                else
                {
                    MPCF.ShowMessage(MPCF.GetMessage(459), MSG_LEVEL.ERROR, true);
                }


                return succeedConverting;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        public void GetDefaultValueFromReg()
        {
            try
            {
                _baseUnit = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "UNIT"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void SetDefaultValueToReg()
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "UNIT", MPCF.Trim(cboUnit.SelectedItem.DisplayText));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

    
        #endregion                      

    }

    public class Unit
    {
        public Unit()
        {
        }        

        private string _baseunit = string.Empty;

        public string BaseUnit
        {
            get { return _baseunit; }
            set { _baseunit = value; }
        }

        private Dictionary<string, UnitConvert> _unitConvertList = null;

        public Dictionary<string, UnitConvert> UnitConvertList
        {
            get { return _unitConvertList; }
            set { _unitConvertList = value; }
        }

        public class UnitConvert
        {
            public UnitConvert()
            {
            }

            private string _toUnit = string.Empty;

            public string ToUnit
            {
                get { return _toUnit; }
                set { _toUnit = value; }
            }

            private double _scaleFactor = 0.0d;

            public double ScaleFactor
            {
                get { return _scaleFactor; }
                set { _scaleFactor = value; }
            }

        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Unit unit = obj as Unit;
            return unit.BaseUnit == this.BaseUnit;         
        }

        public override int GetHashCode()
        {
            //해시 함수 미구현 같은 Key를 갖을 수 있으니 HashSet 사용하면 안됨
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return _baseunit;
        }


        public bool ConvertValue(string unit, double value, out double convertValue)
        {
            if (this.BaseUnit.Equals(unit))
            {
                convertValue = value;
            }
            else
            {
                UnitConvert unitConvert = null;
                this.UnitConvertList.TryGetValue(unit, out unitConvert);
                if (unitConvert != null)
                {
                    convertValue = value * unitConvert.ScaleFactor;
                }
                else
                {
                    convertValue = -1;                
                    return false;
                }
            }
            return true;
        }

        
    }
}
