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
    public partial class frmINVChangeQtyInventoryLot : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private Rs232 m_CommPort = new Rs232();
        private string sAccountDetail = string.Empty;

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

        public frmINVChangeQtyInventoryLot()
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

                cboCalType.Text = "+";
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
            try
            {
                if (e.Column != (int)MAT_LOT_COL.REASON_BUTTON)
                {
                    return;
                }

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
                //cdvReason.Text = cdvReason.Show(cdvReason, "Reason", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                //if (MPCF.Trim(cdvReason.Text) != "")
                //{
                //    if (cdvReason.returnDatas.Count > 0)
                //    {
                //        spdMatLot.Sheets[0].Cells[e.Row, (int)MAT_LOT_COL.REASON_CODE].Value = cdvReason.returnDatas[0];
                //        spdMatLot.Sheets[0].Cells[e.Row, (int)MAT_LOT_COL.REASON_DESC].Value = cdvReason.returnDatas[1];
                //    }
                //}
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
                if (CheckCondition("ADD_ROW") == false)
                {
                    return;
                }

                spdQty.Sheets[0].RowCount += 1;
                spdQty.Sheets[0].Cells[spdQty.Sheets[0].RowCount - 1, (int)MAT_LOT_COL.INV_LOT_ID].Value = txtInvLotID.Text;

                //spdMatLot.Sheets[0].Cells[spdMatLot.Sheets[0].RowCount - 1, (int)MAT_LOT_COL.QTY].Value = dUnitQty - dLossQty;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
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
                txtInvStoreID.Text = "";
                txtInvStoreDesc.Text = "";
                txtInvQty.Value = txtInvQty.NullText;
                txtChangeQty.Value = txtChangeQty.NullText;

                spdQty.ActiveSheet.Cells[0, 0].Value = 0.00;
                spdQty.ActiveSheet.Cells[0, 1].Value = 0.00;
            }
            return;
        }

        private bool CheckCondition(string FuncName)
        {

            try
            {
                switch (FuncName)
                {
                    case "ADD_ROW":
                        
                        break;

                    case "VIEW_LOT":
                        
                        break;

                    case "CHANGE_QTY":

                        

                        //InvLotID
                        if (MPCF.Trim(txtInvLotID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            txtInvLotID.Focus();
                            return false;
                        }
                        //Change Type
                        if (MPCF.Trim(cdvChangeType.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvChangeType.Focus();
                            return false;
                        }

                        //수량 체크
                        if (MPCF.ToDbl(txtChangeQty.Value) <= 0.00)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(372), MSG_LEVEL.WARNING, true);
                            txtChangeQty.Focus();
                            return false;
                        }

                        if (cboCalType.Text == "-")
                        {
                            if (MPCF.ToDbl(txtChangeQty.Value) > MPCF.ToDbl(txtInvQty.Value))
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(371), MSG_LEVEL.WARNING, true);
                                txtChangeQty.Focus();
                                return false;
                            }
                            //377 - 전량 변경 하시겠습니까?
                            if (MPCF.ToDbl(txtChangeQty.Value) == MPCF.ToDbl(txtInvQty.Value))
                            {
                                if (MPCF.ShowMsgBox(MPCF.GetMessage(377), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == System.Windows.Forms.DialogResult.No)
                                {
                                    return false;
                                }
                            }
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
        private bool View_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                ClearData(1);
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false)
                {
                    txtInvLotID.Focus();
                    txtInvLotID.SelectAll();
                    return false;
                }

                txtInvMatID.Text = out_node.GetString("MAT_ID");
                txtMatUnit.Text = out_node.GetString("UNIT_1");
                txtInvMatDesc.Text = out_node.GetString("MAT_DESC");
                txtInvStoreID.Text = out_node.GetString("OPER");
                txtInvStoreDesc.Text = out_node.GetString("OPER_DESC");
                //txtUnitQty.Value = out_node.GetDouble("CREATE_QTY_1");
                txtInvQty.Value = out_node.GetDouble("QTY_1");

                spdQty.ActiveSheet.Cells[0, 0].Value = out_node.GetDouble("QTY_1");
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

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (bCheckAll == false)
                {
                    for (int i = 0; i < spdQty.Sheets[0].RowCount; i++)
                    {
                        spdQty.Sheets[0].Cells[i, (int)MAT_LOT_COL.CHECK_SELECT].Value = true;
                    }

                    bCheckAll = true;
                }
                else
                {
                    for (int i = 0; i < spdQty.Sheets[0].RowCount; i++)
                    {
                        spdQty.Sheets[0].Cells[i, (int)MAT_LOT_COL.CHECK_SELECT].Value = false;
                    }

                    bCheckAll = false;
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
                if (CheckCondition("CHANGE_QTY") == true)
                {
                    if (Change_Qty_Inv_Lot('1') == true)
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

        // Change_Qty_Inv_Lot()
        //       - Change Qty Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Change_Qty_Inv_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("CHANGE_QYT_LOT_IN");
            TRSNode out_node = new TRSNode("CHANGE_QYT_LOT_OUT");
            TRSNode list_item;
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("LOT_ID", MPCF.Trim(txtInvLotID.Text));

                in_node.AddString("ACCOUNT_DETAIL", MPCF.Trim(sAccountDetail));
                in_node.AddString("REASON_GROUP", BIGC.B_INV_RSN_GRP_RG4);
                in_node.AddString("REASON_DETAIL", MPCF.Trim(cdvChangeType.Tag));

                list_item = in_node.AddNode("UNIT1");
                list_item.AddString("CODE", "CV");
                if (MPCF.ToChar(cboCalType.Text) == '+')
                {
                    list_item.AddDouble("QTY", MPCF.ToDbl(txtChangeQty.Value));
                }
                else if (MPCF.ToChar(cboCalType.Text) == '-')
                {
                    list_item.AddDouble("QTY", MPCF.ToDbl(txtChangeQty.Value) * -1);
                }


                if (MPCF.CallService("BINV", "BINV_Tran_Cv_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                
                spdQty.ActiveSheet.Cells[0, 1].Value = out_node.GetDouble("REMAIN_QTY");


                MPCF.ShowSuccessMessage(out_node, false);

                txtInvLotID.Focus();
                txtInvLotID.SelectAll();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
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
                in_node.AddString("LOT_ID", MPCF.Trim(txtInvLotID.Text));
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

        private void txtInvLotID_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (CheckCondition("VIEW_LOT") == true)
                    {
                       // tempLotId = txtInvLotID.Text.Trim();
                        //indexValue = tempLotId.IndexOf(":");

                        //txtInvLotID.Text = tempLotId.Substring(0, indexValue);
                        txtInvLotID.Text = MPCF.Trim(txtInvLotID.Text);
                        //spdQty.ActiveSheet.Cells[0, 0].Value = MPCF.ToDbl(tempLotId.Substring(indexValue + 1));

                        if (View_Lot(txtInvLotID.Text) == false)
                        {
                            txtInvLotID.Focus();
                            txtInvLotID.SelectAll();
                            return;
                        }
                    }
                    else
                    {
                        txtInvLotID.Focus();
                        txtInvLotID.SelectAll();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvChangeType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup
                sAccountDetail = "";
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_RSN_DETAIL));
                if (cboCalType.Text == "-")
                {
                    in_node.AddString("DATA_2", BIGC.B_INV_RSN_GRP_RG4);
                }
                else if (cboCalType.Text == "+")
                {
                    in_node.AddString("DATA_2", BIGC.B_INV_RSN_GRP_RG9);
                }

                // CodeView Column Header Setup
                string[] header = new string[] { "Reason", "Description", "Account Detail" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" , "DATA_3"};

                // Show
                cdvChangeType.Text = cdvChangeType.Show(cdvChangeType, "Reason", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvChangeType.Text) != "")
                {
                    if (cdvChangeType.returnDatas.Count > 0)
                    {
                        cdvChangeType.Tag = cdvChangeType.returnDatas[0];
                        cdvChangeType.Text = cdvChangeType.returnDatas[1];
                        sAccountDetail = cdvChangeType.returnDatas[2];
                    }
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
