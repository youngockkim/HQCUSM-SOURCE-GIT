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
    public partial class frmINVMergeInventoryLot : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private Rs232 m_CommPort = new Rs232();
        private MenuInfoTag menuInfo;
        public PrintOptionModel printOption;
        private frmPrintOptionPopup frmOption;

        private bool bCheckAll = false;

        private enum MAT_LOT_COL
        {
            CHECK_SELECT = 0,
            INV_LOT_ID,
            REASON_DESC,
            REASON_BUTTON,
            REASON_CODE,
            UNIT,
            QTY,
            LOSS_DESC,
            LOSS_CODE
        }


        #endregion

        #region Constructor

        public frmINVMergeInventoryLot()
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
            try
            {
                // (Required) Convert Caption
                // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
                MPCF.ConvertCaption(this);


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
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
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



        private void spdMatLot_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOSS_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_LOSS_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_LOSS_CODE));

                // CodeView Column Header Setup
                string[] header = new string[] { "Loss Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                //cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Loss", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");

                //if (MPCF.Trim(cdvLossCode.Text) != "")
                //{
                //    if (cdvLossCode.returnDatas.Count > 0)
                //    {
                //        cdvLossCode.Tag = cdvLossCode.returnDatas[0];
                //        cdvLossCode.Text = cdvLossCode.returnDatas[1];
                //    }
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        private void ClearData(int i)
        {
            if (i == 1)
            {
                txtInvMatID.Text = "";
                txtInvMatDesc.Text = "";
                txtMatUnit.Text = "";
                txtInvStoreID.Text = "";
                txtInvStoreDesc.Text = "";
                txtMergeLotID.Text = "";
                txtMergeLotQty.Value = txtMergeLotQty.NullText;
                txtInvQty.Value = txtInvQty.NullText;
                spdQty.ActiveSheet.Cells[0, 0].Value = 0.00;
                spdQty.ActiveSheet.Cells[0,1].Value = 0.00;
                spdInvLot.ActiveSheet.RowCount = 0;
            }
            else if (i == 2)
            {
                txtMergeLotQty.Value = txtMergeLotQty.NullText;
            }
            return;
        }

        private bool CheckCondition(string FuncName)
        {
            int iRow;

            try
            {
                switch (FuncName)
                {
                    case "ADD_ROW":

                        

                        //Mat LotID
                        if (MPCF.Trim(txtTargetLotID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            txtTargetLotID.Focus();
                            return false;
                        }
                        //Merge Lot Qty
                        if (MPCF.Trim(txtMergeLotQty.Value) == "0")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.WARNING, true);
                            txtMergeLotQty.Focus();
                            return false;
                        }

                        //같은 Lot 있는지 조회
                        for (iRow = 0; iRow < spdInvLot.Sheets[0].RowCount; iRow++)
                        {
                            if (spdInvLot.Sheets[0].Cells[iRow, 2].Value.ToString().Trim() == MPCF.Trim(txtMergeLotID.Text))
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(368).Replace("{1}", txtMergeLotID.Text.Trim()), MSG_LEVEL.WARNING, true);
                                return false;
                            }
                        }

                        if (MPCF.Trim(txtTargetLotID.Text) == MPCF.Trim(txtMergeLotID.Text))
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(376), MSG_LEVEL.WARNING, true);
                            txtMergeLotID.Focus();
                            return false;
                        }
                        break;

                    case "VIEW_LOT":

                        break;

                    case "MERGE_LOT":

                        

                        //InvLotID
                        if (MPCF.Trim(txtTargetLotID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            txtTargetLotID.Focus();
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

        private void InvisibleColumn()
        {
            try
            {
                //spdQty.Sheets[0].Columns[(int)MAT_LOT_COL.REASON_CODE].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool View_Lot(string sLotID, char type)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (type == 'T')
                {
                    ClearData(1);
                }
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false)
                {
                    if(type == 'T')
                    {
                        txtTargetLotID.Focus();
                        txtTargetLotID.SelectAll();
                    }
                    else if (type == 'M')
                    {
                        txtMergeLotID.Focus();
                        txtMergeLotID.SelectAll();
                    }
                    return false;
                }
                if (type == 'T')
                {
                    txtInvMatID.Text = out_node.GetString("MAT_ID");
                    txtInvMatDesc.Text = out_node.GetString("MAT_DESC");
                    txtMatUnit.Text = out_node.GetString("UNIT_1");
                    txtInvStoreID.Text = out_node.GetString("OPER");
                    txtInvStoreDesc.Text = out_node.GetString("OPER_DESC");
                    //txtUnitQty.Value = out_node.GetDouble("CREATE_QTY_1");
                    txtInvQty.Value = out_node.GetDouble("QTY_1");

                    spdQty.ActiveSheet.Cells[0, 0].Value = out_node.GetDouble("QTY_1");
                }
                else if (type == 'M')
                {
                    //Validation
                    if (MPCF.Trim(out_node.GetString("MAT_ID")) != MPCF.Trim(txtInvMatID.Text))
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(374), MSG_LEVEL.WARNING, true);
                        return false;
                    }

                    if (MPCF.Trim(out_node.GetString("OPER")) != MPCF.Trim(txtInvStoreID.Text))
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(375), MSG_LEVEL.WARNING, true);
                        return false;
                    }
                    txtMergeLotQty.Value = out_node.GetDouble("QTY_1");

                    if (CheckCondition("ADD_ROW") == true)
                    {
                        spdInvLot.ActiveSheet.AddRows(spdInvLot.ActiveSheet.RowCount, 1);
                        spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 0].Value = true;
                        spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 1].Value = spdInvLot.ActiveSheet.RowCount;
                        spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 2].Text = MPCF.Trim(txtMergeLotID.Text);
                        spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 3].Text = MPCF.Trim(out_node.GetString("MAT_DESC"));
                        spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 4].Text = out_node.GetString("UNIT_1");
                        spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 5].Value = MPCF.ToDbl(txtMergeLotQty.Value);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
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


        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("MERGE_LOT") == true)
                {
                    if (Merge_Inv_Lot('1') == true)
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
        private bool Tran_Print_Label()
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
                in_node.AddString("LOT_ID", MPCF.Trim(txtTargetLotID.Text));
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
        // Merge_Inv_Lot()
        //       - Merge Target Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Merge_Inv_Lot(char ProcStep)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("MERGE_LOT_IN");
            TRSNode out_node = new TRSNode("MERGE_LOT_OUT");

            TRSNode list_item;
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                for (i = 0; i < spdInvLot.Sheets[0].RowCount; i++)
                {
                    if ( (bool)spdInvLot.Sheets[0].Cells[i, 0].Value == true)
                    {
                        list_item = in_node.AddNode("LIST");

                        
                        //Target LotID
                        list_item.AddString("INTO_LOT_ID", MPCF.Trim(txtTargetLotID.Text));
                        
                        //From LotID
                        list_item.AddString("LOT_ID", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, 2].Value));

                        //UNIT
                        //list_item.AddString("UNIT", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, 3].Value));

                        //QTY
                        list_item.AddDouble("MOVE_QTY_1", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, 5].Value));
}
                }

                if (in_node.GetList("LIST").Count == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(369), MSG_LEVEL.WARNING, false);
                    return false;
                }

                if (MPCF.CallService("BINV", "BINV_Multi_Tran_Merge_Inventory_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }
                spdQty.ActiveSheet.Cells[0, 1].Value = out_node.GetDouble("REMAIN_QTY");

                MPCF.ShowSuccessMessage(out_node, false);
                txtTargetLotID.Focus();
                txtTargetLotID.SelectAll();
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        private void txtInvLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string tempLotId;
            //int indexValue;

            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (CheckCondition("VIEW_LOT") == true)
                    {
                        //tempLotId = txtTargetLotID.Text.Trim();
                        //indexValue = tempLotId.IndexOf(":");
                        txtTargetLotID.Text = MPCF.Trim(txtTargetLotID.Text);
                        //txtTargetLotID.Text = tempLotId.Substring(0, indexValue);

                        if (View_Lot(txtTargetLotID.Text, 'T') == false)
                        {

                            txtTargetLotID.Focus();
                            txtTargetLotID.SelectAll();
                        }
                    }
                    else
                    {

                        txtTargetLotID.Focus();
                        txtTargetLotID.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtMergeLotID_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ClearData(2);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtMergeLotID_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (CheckCondition("VIEW_LOT") == true)
                    {
                        //tempLotId = txtMergeLotID.Text.Trim();
                        //indexValue = tempLotId.IndexOf(":");
                        txtMergeLotID.Text = MPCF.Trim(txtMergeLotID.Text);
                        //txtMergeLotID.Text = tempLotId.Substring(0, indexValue);

                        //txtMergeLotUnitQty.Value = MPCF.ToDbl(tempLotId.Substring(indexValue + 1));

                        if (View_Lot(txtMergeLotID.Text,'M') == false)
                        {
                            txtMergeLotID.Focus();
                            txtMergeLotID.SelectAll();
                            txtMergeLotQty.Value = 0;
                        }
                    }
                    else
                    {
                        txtMergeLotID.Focus();
                        txtMergeLotID.SelectAll();
                        txtMergeLotQty.Value = 0;
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
            try
            {
                if (CheckCondition("ADD_ROW") == true)
                {
                    spdInvLot.ActiveSheet.AddRows(spdInvLot.ActiveSheet.RowCount, 1);
                    spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 0].Value = true;
                    spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 1].Value = spdInvLot.ActiveSheet.RowCount;
                    spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 2].Text = MPCF.Trim(txtMergeLotID.Text);
                    //spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 3].Text = MPCF.Trim(out_node.GetString("MAT_DESC"));
                    //spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 4].Text = out_node.GetDouble("QTY_1").ToString();
                    spdInvLot.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 5].Value = MPCF.ToDbl(txtMergeLotQty.Value);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnSelectDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < spdInvLot.ActiveSheet.RowCount; i++)
                {
                    if ((Boolean)spdInvLot.ActiveSheet.Cells[i, 0].Value == true)
                    {
                        spdInvLot.ActiveSheet.Rows[i].Remove();
                        i--;
                    }
                }
                for (int i = 0; i < spdInvLot.ActiveSheet.RowCount; i++)
                {
                    spdInvLot.ActiveSheet.Cells[i, 1].Value = i + 1;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCheckAll_Click_1(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < spdInvLot.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdInvLot.ActiveSheet.Cells[i, 2].Text) == MPCF.Trim(txtMergeLotID.Text))
                    {
                        spdInvLot.ActiveSheet.Rows[i].Remove();
                        break;
                    }
                }
                for (int i = 0; i < spdInvLot.ActiveSheet.RowCount; i++)
                {
                    spdInvLot.ActiveSheet.Cells[i, 1].Value = i + 1;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnLabelPrint_Click(object sender, EventArgs e)
        {
            if (Tran_Print_Label() == false)
            {
                return;
            }
            btnLabelPrint.Enabled = false;
        }

    }
}
