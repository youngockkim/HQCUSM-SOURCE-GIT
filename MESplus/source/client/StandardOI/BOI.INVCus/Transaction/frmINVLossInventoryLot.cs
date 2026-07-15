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
using BOI.OIFrx;
using SOI.DNM;
using Miracom.POPCore;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVLossInventoryLot : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private MenuInfoTag menuInfo;
        public PrintOptionModel printOption;
        private frmPrintOptionPopup frmOption;
        private Rs232 m_CommPort = new Rs232();

        private bool bCheckAll = false;
        private string sAccountDetail = string.Empty;

        private enum MAT_LOT_COL
        {
            CHECK_SELECT = 0,
            INV_LOT_ID,
            REASON_CODE,
            QTY,
            UNIT,
            LOSS_DESC,
            LOSS_CODE
        }


        #endregion

        #region Constructor

        public frmINVLossInventoryLot()
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
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdInvLot);

            InvisibleColumn();

            btnLabelPrint.Enabled = false;

            // Menu 정보 로드
            menuInfo = (MenuInfoTag)this.Tag;

            // Print Option 할당
            if (printOption == null)
            {
                printOption = new PrintOptionModel();
            }

            // Print Option 정보 호출
            MPCF.GetPrintOptionFromReg(ref this.printOption, this.menuInfo.s_func_name);
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

                // (Required) 
                bIsShown = true;
            }
        }

        private void txtMatLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (CheckCondition("VIEW_LOT") == true)
                    {
                        if (View_Lot(txtInvLotID.Text) == false)
                        {
                            ClearData('1');
                        }
                    }
                    else
                    {
                        ClearData('1');
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double dUnitQty;
            double dLossQty;

            try
            {
                if (CheckCondition("ADD_ROW") == false)
                {
                    return;
                }

                spdInvLot.Sheets[0].RowCount += 1;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)MAT_LOT_COL.INV_LOT_ID].Value = txtInvLotID.Text;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)MAT_LOT_COL.UNIT].Value = txtUnit.Text;

                dUnitQty = MPCF.ToDbl(txtUnitQty.Value);
                dLossQty = MPCF.ToDbl(txtLossQty.Value);

                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)MAT_LOT_COL.QTY].Value = dLossQty;

                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)MAT_LOT_COL.REASON_CODE].Value = cdvReason.Tag;

                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)MAT_LOT_COL.LOSS_DESC].Value = cdvLossCode.Text;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)MAT_LOT_COL.LOSS_CODE].Value = cdvLossCode.Tag;

                ClearData('1');
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            try
            {
                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "COL_GRP";
                dvcArgu[1].sCondition_Value = BIGC.B_COL_GRP_1_ML;


                // CodeView Column Header Setup
                string[] header = new string[] { "Loss Code", "Loss Code Desc",  "Account Detail"};

                // CodeView Display Column Setup
                string[] display = new string[] { "CHAR_ID", "CHAR_DESC", "CHAR_CMF_2" };

                // Show
                cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Loss Code", "COM0000-018", dvcArgu, display, header, "CHAR_DESC", -1);

                if (MPCF.Trim(cdvLossCode.Text) != "")
                {
                    if (cdvLossCode.returnDatas != null && cdvLossCode.returnDatas.Count > 0)
                    {
                        cdvLossCode.Tag = cdvLossCode.returnDatas[0];
                        cdvLossCode.Text = cdvLossCode.returnDatas[1];
                        sAccountDetail = cdvLossCode.returnDatas[2];
                    }
                    else
                    {
                        cdvLossCode.Tag = "";
                        cdvLossCode.Text = "";
                        sAccountDetail = "";
                    }
                }
                else
                {
                    cdvLossCode.Tag = "";
                    cdvLossCode.Text = "";
                    sAccountDetail = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return ;
            }

            return ;
        }

        private void txtMatLotID_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ClearData('2');
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            try
            {
                // Print Option Popup 생성
                if (frmOption == null)
                {
                    frmOption = new frmPrintOptionPopup();
                }

                // Print Option Popup 초기화
                frmOption.Owner = this;
                frmOption.printOption = this.printOption;
                frmOption.funcName = this.menuInfo.s_func_name;

                // Show Dialog
                if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.printOption = frmOption.printOption;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (bCheckAll == false)
                {
                    for (int i = 0; i < spdInvLot.Sheets[0].RowCount; i++)
                    {
                        spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.CHECK_SELECT].Value = true;
                    }

                    bCheckAll = true;
                    btnCheckAll.Text = "Uncheck All";
                }
                else
                {
                    for (int i = 0; i < spdInvLot.Sheets[0].RowCount; i++)
                    {
                        spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.CHECK_SELECT].Value = false;
                    }

                    bCheckAll = false;
                    btnCheckAll.Text = "Check All";
                }

                MPCF.ConvertCaption(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("LOSS_LOT") == true)
                {
                    if (Loss_Lot('1') == true)
                    {
                        btnLabelPrint.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvReason_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

            // In Node Setup
            in_node.Init();
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_RSN_DETAIL));
            in_node.AddString("DATA_2", BIGC.B_INV_RSN_GRP_RG2);

            // CodeView Column Header Setup
            string[] header = new string[] { "Reason", "Description" };

            // CodeView Display Column Setup
            string[] display = new string[] { "KEY_1", "DATA_1" };

            // Show
            cdvReason.Text = cdvReason.Show(cdvReason, "Reason", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

            if (MPCF.Trim(cdvReason.Text) != "")
            {
                if (cdvReason.returnDatas.Count > 0)
                {
                    cdvReason.Text = cdvReason.returnDatas[1];
                    cdvReason.Tag = cdvReason.returnDatas[0];
                }
            }
        }

        #endregion

        #region Function

        private bool Tran_Print_Label(string s_lot_id)
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
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));
                in_node.AddString("SCREEN_ID", BIGC.B_LABEL_LB005);
                in_node.AddChar("PRINT_HIS_FLAG", 'Y');

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

        private bool CheckCondition(string FuncName)
        {
            int iRow;

            try
            {
                switch (FuncName)
                {
                    case "ADD_ROW":
                        //Store Oper
                        if (MPCF.Trim(txtStoreId.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            txtStoreId.Focus();
                            return false;
                        }
                        //Mat LotID
                        if (MPCF.Trim(txtInvLotID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            txtInvLotID.Focus();
                            return false;
                        }
                        //LOSS CODE
                        if (MPCF.Trim(cdvLossCode.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLossCode.Focus();
                            return false;
                        }
                        //REASON CODE
                        if (MPCF.Trim(cdvReason.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvReason.Focus();
                            return false;
                        }
                        //Unit Qty
                        if (MPCF.Trim(txtUnitQty.Value) == "0")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.WARNING, true);
                            txtUnitQty.Focus();
                            return false;
                        }
                        //Loss Qty
                        if (MPCF.Trim(txtLossQty.Value) == "0")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.WARNING, true);
                            txtLossQty.Focus();
                            return false;
                        }
                        else if (MPCF.ToInt(MPCF.Trim(txtLossQty.Value)) > MPCF.ToInt(MPCF.Trim(txtUnitQty.Value)))
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(367), MSG_LEVEL.WARNING, true);
                            txtUnitQty.Focus();
                            return false;
                        }

                        //같은 Lot 있는지 조회
                        for (iRow = 0; iRow < spdInvLot.Sheets[0].RowCount; iRow++)
                        {
                            if(spdInvLot.Sheets[0].Cells[iRow, (int)MAT_LOT_COL.INV_LOT_ID].Value.ToString().Trim() == txtInvLotID.Text.Trim())
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(368).Replace("{1}", txtInvLotID.Text.Trim()), MSG_LEVEL.WARNING, true);
                                return false;
                            }
                        }

                        break;

                    case "VIEW_LOT":
                        //Store Oper

                        break;

                    case "LOSS_LOT":
                        //Reason

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

        private void InvisibleColumn()
        {
            try
            {
                spdInvLot.Sheets[0].Columns[(int)MAT_LOT_COL.REASON_CODE].Visible = false;
                spdInvLot.Sheets[0].Columns[(int)MAT_LOT_COL.LOSS_CODE].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void ClearData(char step)
        {
            try
            {
                switch (step)
                {
                    case '1':
                        txtInvLotID.Text = "";

                        txtStoreId.Text = "";
                        txtStoreId.Tag = "";

                        cdvLossCode.Text = "";
                        cdvLossCode.Tag = "";

                        cdvReason.Text = "";
                        cdvReason.Tag = "";

                        txtMatID.Text = "";
                        txtMatDesc.Text = "";

                        txtUnitQty.Value = 0;
                        txtLossQty.Value = 0;
                        txtUnit.Text = "";

                        break;

                    case '2':
                        txtStoreId.Text = "";
                        txtStoreId.Tag = "";

                        cdvLossCode.Text = "";
                        cdvLossCode.Tag = "";

                        cdvReason.Text = "";
                        cdvReason.Tag = "";

                        txtMatID.Text = "";
                        txtMatDesc.Text = "";

                        txtUnitQty.Value = 0;
                        txtLossQty.Value = 0;
                        txtUnit.Text = "";

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtUnit.Text = out_node.GetString("UNIT_1");

                txtStoreId.Text = out_node.GetString("OPER_DESC");
                txtStoreId.Tag = out_node.GetString("OPER");

                txtMatID.Text = out_node.GetString("MAT_ID");
                txtMatDesc.Text = out_node.GetString("MAT_DESC");
                txtUnitQty.Value = out_node.GetDouble("QTY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        // Loss_Lot()
        //       - Create New Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Loss_Lot(char ProcStep)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("LOSS_LOT_IN");
            TRSNode out_node = new TRSNode("LOSS_LOT_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                for (i = 0; i < spdInvLot.Sheets[0].RowCount; i++)
                {
                    if (spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.CHECK_SELECT].Value != null && (bool)spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.CHECK_SELECT].Value == true)
                    {
                        list_item = in_node.AddNode("LOSS_LIST");

                        //자재 LotID
                        list_item.AddString("LOT_ID", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.INV_LOT_ID].Value));

                        //UNIT
                        list_item.AddString("UNIT", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.UNIT].Value));

                        //REASON
                        list_item.AddString("LOSS_COMMENT", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.REASON_CODE].Value));

                        //LOSS QTY
                        list_item.AddDouble("LOSS_QTY", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.QTY].Value));

                        //LOSS CODE
                        list_item.AddString("LOSS_CODE", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.LOSS_CODE].Value));

                        //계정그룹&계정그룹상세유형
                        list_item.AddString("LOT_CMF_1", ""); //LOT_CMF_1 계정그룹 =>Server에서 진행
                        list_item.AddString("LOT_CMF_2", sAccountDetail); //LOT_CMF_2 계정상세유형

                        //사유
                        list_item.AddString("LOT_CMF_7", BIGC.B_INV_RSN_GRP_RG2); //INV_CMF_7 사유그룹
                        list_item.AddString("LOT_CMF_8", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)MAT_LOT_COL.REASON_CODE].Value)); //INV_CMF_8 사유
                    }
                }

                if (in_node.GetList("LOSS_LIST").Count == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(369), MSG_LEVEL.WARNING, false);
                    return false;
                }

                if (MPCF.CallService("BINV", "BINV_Tran_Loss_Inv_Lot", in_node, ref out_node) == false) //BINV_Multi_Tran_Loss_Inventory_Lot
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

        private void spdInvLot_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.Column == (int)MAT_LOT_COL.INV_LOT_ID)
                {
                    spdInvLot.Sheets[0].RemoveRows(e.Row, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void btnLabelPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < spdInvLot.ActiveSheet.RowCount; i++)
            {
                if (Convert.ToBoolean(spdInvLot.ActiveSheet.Cells[i, (int)MAT_LOT_COL.CHECK_SELECT].Value) == true)
                {
                    if (Tran_Print_Label(MPCF.Trim(spdInvLot.ActiveSheet.Cells[i, (int)MAT_LOT_COL.INV_LOT_ID].Text)) == false)
                    {
                        return;
                    }
                }
            }
            btnLabelPrint.Enabled = false;
        }
    }
}
