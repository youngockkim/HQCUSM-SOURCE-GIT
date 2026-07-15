using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;



namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button\

    public partial class frmCUSTranLoadFullCell : SOIBaseForm02
    {
        #region Property

        const int ENTER = 13;
        string sBoxID = string.Empty;

        // RFID Property
        clsCustomBaseTcpComm _tcpComm = new clsCustomBaseTcpComm();
        CONNECTED_STATUS _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
        string _ip = "192.168.0.79";
        string _portNo = "33000";
        byte[] _receiveByte = new byte[1024];
        byte[] _receiveByteTemp = new byte[1024];
        RFID_Antena _readAntena = RFID_Antena.IO_1;
        RFID_Antena _writeAntena = RFID_Antena.IO_1;
        // RFID Property

        #endregion

        #region Constructor

        public frmCUSTranLoadFullCell()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum LOT_LIST
        {
            SEQ,
            LACK_ID,
            PACK_ID,
            CELL_BOX_ID,
            PACK_QTY
        }

        #endregion

        #region [Variable Definition]

        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        public frmCWIPFullcellCartLabelPopup frmCWIPFullcellCartLabelPopup;
        public string p_order_id;
        public string p_lack_id;

        public enum RFID_Antena
        {
            IO_1 = 1
        }

        #endregion

        #region Event Handler

        private void frmCUSTranLoadFullCell_Load(object sender, EventArgs e)
        {
            //Initialize();

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
            MPCF.ClearList(spdLotList);
            SetupPrtOpt();

            // Fix Operation
            cdvOperID.Text = HQGC.OPER_M0050; // Opeation Stock & Full Cell Management
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_CV));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
        
                /*
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@LINE_CODE");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }
                */
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOperID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOperID.Text = cdvOperID.Show(cdvOperID, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOrderNo_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {             
                // Old Version
                /*
                TRSNode in_node = new TRSNode("VIEW_ORDER_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLineID.Text);
                in_node.AddString("MAT_ID", "");

                // Display and Header Text Setup
                //string[] display = new string[] { "ORDER_ID", "ORDER_DESC", "EFFICIENCY", "GRADE", "ORD_QTY", "USED_QTY", "REMAIN_QTY" };
                //string[] header = new string[] { "Order ID", "Order Desc" , "Efficiency", "Grade", "OrderQty", "UsedQty", "RemainQty" };

                string[] display = new string[] { "ORDER_ID", "ORDER_DESC", "EFFICIENCY", "GRADE"};
                string[] header = new string[] { "Order ID", "Order Description", "Efficiency", "Grade"};

                // Show CodeView and Get Return
                cdvOrderNo.Text = cdvOrderNo.Show(cdvOrderNo, "View Production Order List By Line", "CORD", "CORD_View_Order_List_By_Line", in_node, "LIST", display, header, "ORDER_ID");

                if (cdvOrderNo == null)
                {
                    return;
                }
                */

                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }

                // New Version
                frmCORDViewWorkOrderPopup pop = new frmCORDViewWorkOrderPopup(MPCF.Trim(cdvLineID.Text));
                pop.StartPosition = FormStartPosition.CenterParent;
                pop.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
                pop.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                //pop.ClientSize = new System.Drawing.Size(1024, 768);
                pop.ShowDialog(this);
                pop.Focus();
                //pop.Owner = MPGV.gfrmMDI;
                //pop.ShowDialog();

                // View Code
                if (string.IsNullOrEmpty(pop.outOrderID))
                {
                    return;
                }

                cdvOrderNo.Text = pop.outOrderID;

                // Display Order Information
                txtWorkOrder.Text = pop.outOrderID;
                txtMaterial.Text = pop.outMatID;
                txtEfficiency.Text = pop.outEfficiency;
                txtGrade.Text = pop.outGrade;

                lblOrderQty.Text = MPCF.MakeNumberFormat(pop.outOrderQty);
                lblInQty.Text = MPCF.MakeNumberFormat(pop.outInQty);
                lblOutQty.Text = MPCF.MakeNumberFormat(pop.outOutQty);
                lblLossQty.Text = MPCF.MakeNumberFormat(pop.outLossQty);

                txtCart.Text = string.Empty;
                MPCF.SetFocus(txtCart);

                ViewOrder(cdvOrderNo.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtCart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtCart.Text) != "")
            {
                txtCart.Text = MPCF.ToUpper(txtCart.Text); 

                if (e.KeyChar == (char)13)
                {
                    if (string.IsNullOrEmpty(txtWorkOrder.Text) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(504), MSG_LEVEL.ERROR, false);
                        MPCF.SetFocus(txtCart);
                        return;
                    }

                    MPCF.ClearList(spdLotList);

                    if (!ViewPackLotList(txtCart.Text))
                    {
                        txtCart.Focus();
                        txtCart.SelectAll();
                        return;
                    }
                    else
                    {
                        txtCellBoxID1.Focus();
                        txtCellBoxID1.SelectAll();
                    }

                    p_order_id = cdvOrderNo.Text; 
                    p_lack_id = txtCart.Text; 
                }

            }
        }

        private void txtMagazine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtMagazine.Text) != "")
            {
                txtMagazine.Text = MPCF.ToUpper(txtMagazine.Text); // 일괄 대문자

                if (e.KeyChar == (char)13)
                {
                    if (!CheckCondition("VIEW"))
                        return;

                    txtCellBoxID1.Focus();
                    txtCellBoxID1.SelectAll();

                }

            }
        }

        private void txtCellBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition("VIEW"))
                    return;

                ViewPackLotList(txtMagazine.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Terminalize();
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdLotList);
            txtCart.Text = "";
            txtCellBoxID1.Text = "";
            txtCellBoxID2.Text = "";
            MPCF.SetFocus(txtCart);
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            // Print Option Popup 생성
            if (frmOption == null)
            {
                frmOption = new frmPrintOptionPopup();
            }

            // Print Option Popup 초기화
            frmOption.Owner = this;
            frmOption.printOption = this.printOption;
            //            frmOption.funcName = this.menuInfo.s_func_name;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (!CheckCondition("PROCESS"))
            //    return;
            if (procprint())
            {
                MPCF.ClearList(this.spdLotList);

                txtCart.Text = string.Empty;
                MPCF.SetFocus(txtCart);

                txtCellBoxID1.Text = string.Empty;

                // Clear
                MPCF.FieldClear(pnlQty);    
            }
        }

        private void soiButton1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cdvLineID.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(411), MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(cdvLineID);
                return;
            }

            if (string.IsNullOrEmpty(cdvOperID.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(412), MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(cdvOperID);
                return;
            }

            if (string.IsNullOrEmpty(cdvOrderNo.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(504), MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(cdvOrderNo);
                return;
            }


            if (string.IsNullOrEmpty(txtCart.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(533), MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(txtCart);
                return;
            }

            if (string.IsNullOrEmpty(txtWorkOrder.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(504), MSG_LEVEL.ERROR, false);                
                MPCF.SetFocus(cdvOrderNo);
                return;
            }

            frmCWIPFullcellCartLabelPopup.p_lack_id = txtCart.Text;
            frmCWIPFullcellCartLabelPopup.p_order_id = cdvOrderNo.Text;

            frmCWIPFullcellCartLabelPopup = new frmCWIPFullcellCartLabelPopup();
            frmCWIPFullcellCartLabelPopup.Owner = this;
            frmCWIPFullcellCartLabelPopup.ShowDialog();

        }

        private void txtCellBoxID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (btnRFID.Text == "RFID(Off)")
                { MPCF.ShowMessage("RF_ID disconnected.\nPlease follow the instructions.\n  Step1.Reconnect Lan cable \n  Step2.Reconnect RF_ID power plug\n  Step3.Restart Computer.", MSG_LEVEL.ERROR, true); return; };
             
                string sCellBoxID = string.Empty;

                
                if (e.KeyChar == (char)13)
                {
                    if (!CheckCondition("PROCESS"))
                        return;

                    if (txtCellBoxID1.Text.Length <= 12)
                    {
                        sCellBoxID = txtCellBoxID1.Text;
                    }
                    else
                    {
                        sCellBoxID = txtCellBoxID1.Text.Substring(0, 12);
                    }

                    if (AddItems(sCellBoxID))
                    {
                        //if (!CheckCondition("PROCESS"))
                        //    return;

                        if (PackFullCell(sCellBoxID))
                        {
                            ViewPackLotList(txtCart.Text, sCellBoxID);
                            txtCellBoxID1.Text = string.Empty;
                            txtCellBoxID1.Focus();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void txtCellBoxID2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void RFID_timer_Tick(object sender, EventArgs e)
        {
            string result = string.Empty;
            result = ReadRfid();

            //if(
            //    string.IsNullOrWhiteSpace(result) ||
            //    "0".PadLeft(13, '0') == result
            //    )
            //{
            //    return;
            //}

            txtMagazine.Text = result;
        }

        private void frmCUSTranLoadFullCell_FormClosing(object sender, FormClosingEventArgs e)
        {
            Terminalize();
        }

        private void soiButton2_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnPrintOption_Click(object sender, EventArgs e)
        {
            // Print Option Popup 생성
            if (frmOption == null)
            {
                frmOption = new frmPrintOptionPopup();
            }

            // Print Option Popup 초기화
            frmOption.Owner = this;
            frmOption.printOption = this.printOption;
            //            frmOption.funcName = this.menuInfo.s_func_name;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPGV.gsUserID != "ADMIN")
                {
                    return;
                }

                frmCWIPSetupFullCellMagazinePopup pop = new frmCWIPSetupFullCellMagazinePopup(RFID_timer.Enabled);
                pop.Owner = MPGV.gfrmMDI;
                pop.ShowDialog();

                RFID_timer.Enabled = pop.outTimerEnabled;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function
        
        private void SetupPrtOpt()
        {
            this.printOption = new PrintOptionModel();
            if (MPCF.GetPrintOptionFromReg(ref this.printOption, null) == false)
            {
                return;
            }
        }

        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdLotList);
                }
            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (string.IsNullOrEmpty(txtMagazine.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(534));
                            MPCF.SetFocus(txtMagazine);
                            return false;
                        }

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(txtCellBoxID1.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(506));
                            MPCF.SetFocus(txtCellBoxID1);
                            return false;
                        }

                        for (int k = 0; k < spdLotList.ActiveSheet.RowCount; k++)
                        {
                            if (txtCellBoxID1.Text.Substring(0, 12) == spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.CELL_BOX_ID].Text)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(501));
                                txtCellBoxID1.Text = "";
                                MPCF.SetFocus(txtCellBoxID1);
                                return false;
                            }
                        }

                        break;

                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewPackLotList(string sCartID)
        {
            TRSNode in_node = new TRSNode("View_Pack_List_In");
            TRSNode out_node = new TRSNode("View_Pack_List_Out");
            TRSNode out_list;
            int magazineSeq = 0;

            try
            {
                // Clear
                MPCF.ClearList(this.spdLotList);

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("ORDER_ID", MPCF.Trim(cdvOrderNo.Text));
                in_node.AddString("LACK_ID", MPCF.Trim(sCartID));

                if (MPCF.CallService("CRPT", "CRPT_View_Fullcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdLotList.ActiveSheet.RowCount = 0;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdLotList.ActiveSheet.RowCount++;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LACK_ID].Value = out_list.GetString("CARRIER_ID"); // Cart
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_ID].Value = out_list.GetString("MAGAZINE"); // Magazine
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CELL_BOX_ID].Value = out_list.GetString("SMALLBOX_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_QTY].Value = out_list.GetInt("CNT");

                    if (i < 1)
                    {
                        magazineSeq = 1;
                    }
                    else
                    {
                        if (spdLotList.ActiveSheet.Cells[i-1, (int)LOT_LIST.PACK_ID].Text != spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_ID].Text)
                        {
                            ++magazineSeq;
                        }
                    }

                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.SEQ].Value = magazineSeq;

                }

                txtLoadCount.Text = MPCF.ToStr(out_node.GetDouble("MAGAZINE_CNT"));
                txtNumBoxes.Text = MPCF.ToStr(out_node.GetDouble("FULLCELL_CNT"));
                txtNumCells.Text = MPCF.ToStr(out_node.GetDouble("TOTAL_NUM_CELLS"));

                MPCF.FitColumnHeader(spdLotList);

                txtMagazine.Focus();
                txtMagazine.SelectAll();
                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewPackLotList(string sCartID, string sInCellBoxID)
        {
            TRSNode in_node = new TRSNode("View_Pack_List_In");
            TRSNode out_node = new TRSNode("View_Pack_List_Out");
            TRSNode out_list;
            int magazineSeq = 0;

            try
            {
                // Clear
                MPCF.ClearList(this.spdLotList);

                // View Lot for Validation
                //ViewPackLot(sLotID);

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("ORDER_ID", MPCF.Trim(cdvOrderNo.Text));
                in_node.AddString("LACK_ID", MPCF.Trim(sCartID));

                if (MPCF.CallService("CRPT", "CRPT_View_Fullcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                spdLotList.ActiveSheet.RowCount = 0;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdLotList.ActiveSheet.RowCount++;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LACK_ID].Value = out_list.GetString("CARRIER_ID"); // Cart
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_ID].Value = out_list.GetString("MAGAZINE"); // Magazine
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CELL_BOX_ID].Value = out_list.GetString("SMALLBOX_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_QTY].Value = out_list.GetInt("CNT");

                    if (i < 1)
                    {
                        magazineSeq = 1;
                    }
                    else
                    {
                        if (spdLotList.ActiveSheet.Cells[i-1, (int)LOT_LIST.PACK_ID].Text != spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_ID].Text)
                        {
                            ++magazineSeq;
                        }
                    }

                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.SEQ].Value = magazineSeq;

                    if (spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CELL_BOX_ID].Text == sInCellBoxID)
                    {
                        spdLotList.ActiveSheet.Rows[i].ForeColor = Color.Black;
                        spdLotList.ActiveSheet.Rows[i].BackColor = Color.Yellow;
                    }

                }

                txtLoadCount.Text = MPCF.ToStr(out_node.GetDouble("MAGAZINE_CNT"));
                txtNumBoxes.Text = MPCF.ToStr(out_node.GetDouble("FULLCELL_CNT"));
                txtNumCells.Text = MPCF.ToStr(out_node.GetDouble("TOTAL_NUM_CELLS"));

                MPCF.FitColumnHeader(spdLotList);
                    
                txtMagazine.Focus();
                txtMagazine.SelectAll();
                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

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

            //txtWorkOrder.Text = out_node.GetString("ORDER_ID");
            //txtMaterial.Text = out_node.GetString("MAT_ID");
            //txtMaterialDesc.Text = out_node.GetString("MAT_DESC");
            //txtGrade.Text = out_node.GetString("GRADE_ID");
            //txtEfficiency.Text = out_node.GetString("EFFICIENCY");

            lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
            lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
            lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
            lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_PACK_QTY")); //PACK QTY

            MPCF.SetFocus(txtCart);

            return true;
        }

        private bool ViewLackInfo(string sLotID)
        {
            try {
                TRSNode in_node = new TRSNode("VIEW_CRR_IN");
                TRSNode out_node = new TRSNode("VIEW_CRR_OUT");

                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("CRR_ID", sLotID);

                    if (MPCF.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                    {
                        if (out_node.GetList(0) == null)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(538), MSG_LEVEL.ERROR, false);
                            return false;
                        }

                        return false;
                    }

                    //txtLoadCount.Text = out_node.GetInt("USAGE_COUNT").ToString();
                    txtNumCells.Text = out_node.GetInt("CRR_SIZE").ToString();
                                   
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewPackInfo(string sLotID)
        {
            try
            {                
                TRSNode in_node = new TRSNode("VIEW_CRR_IN");
                TRSNode out_node = new TRSNode("VIEW_CRR_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", cdvOrderNo.Text);  // Po ID
                in_node.AddString("LACK_ID", sLotID);           // Cart ID
                in_node.AddString("PACK_ID", txtMagazine.Text);    // Magazine ID
                in_node.AddChar("PACK_TYPE", 'F');               // PACK TYPE

                if (MPCF.CallService("CWIP", "CWIP_View_Packing_Fullcell_List", in_node, ref out_node) == true)
                {
                    if (out_node.GetList(0) == null)
                    {
                        return true;
                    }
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdLotList.ActiveSheet.AddRows(0, 1);
                    //spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value = out_node.GetList(0)[i].GetString("LACK_ID");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_ID].Value = out_node.GetList(0)[i].GetString("PACK_ID");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CELL_BOX_ID].Value = out_node.GetList(0)[i].GetString("CELL_BOX_ID");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_QTY].Value = out_node.GetList(0)[i].GetInt("PACK_QTY");
                }
                               
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewPackLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_PACK_IN");
            TRSNode out_node = new TRSNode("VIEW_PACK_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LACK_ID", sLotId);

                if (MPCF.CallService("CUS", "CWIP_View_Pack_Lot", in_node, ref out_node) == false)
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

        private bool AddItems(string sLotID)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_PACK_IN");
                TRSNode out_node = new TRSNode("VIEW_PACK_OUT");


                // sLotID Validation Check
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_LOT_ID", sLotID);
                in_node.AddString("ORDER_ID", cdvOrderNo.Text);

                if (MPCF.CallService("CWIP", "CWIP_View_Fullcell_Lot_Validation", in_node, ref out_node) == false)
                {
                    MPCF.ShowMsgBox(out_node.Msg);
                    return false;
                }

                double cellboxPower = 0;
                string cellboxGrade = string.Empty;
                double orderPower = 0;
                string orderGrade = string.Empty;
                
                cellboxPower = Convert.ToDouble(out_node.GetString("EFFICIENCY"));
                cellboxPower = cellboxPower / 100;
                cellboxGrade = out_node.GetString("GRADE");
                orderPower = Convert.ToDouble(out_node.GetString("POWERGRADE"));
                orderGrade = out_node.GetString("QUALITYGRADE");

                string.Format("##.##", cellboxPower);
                string.Format("##.##", orderPower);

                if (cellboxPower == 0 || cellboxGrade == "" || orderPower == 0 || orderGrade == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(598));
                    return false;
                }

                /*
                if (cellboxPower.Equals(orderPower) == false || cellboxGrade.Equals(orderGrade) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(514));
                    return false;
                }
                */


                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool PackFullCell(string sCellBoxID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';

                in_node.AddString( "ORDER_ID", txtWorkOrder.Text);
                in_node.AddString("MAT_ID", txtMaterial.Text);
                in_node.AddString("OPER", cdvOperID.Text);

                list_item = in_node.AddNode("FULLCELL_PACK_LIST");
                list_item.AddString("LACK_ID", MPCF.Trim(txtCart.Text));
                list_item.AddString("PACK_TYPE", "F");
                list_item.AddString("PACK_ID", MPCF.Trim(txtMagazine.Text));
                list_item.AddString("CELL_BOX_ID", sCellBoxID);
                list_item.AddString("OPER", cdvOperID.Text);
                list_item.AddString("MAT_ID", txtMaterial.Text);
                list_item.AddInt("PACK_QTY", 300);
                list_item.AddString("ORDER_ID", txtWorkOrder.Text);

                if (MPCF.CallService("CWIP", "CWIP_Packing_Fullcell", in_node, ref out_node) == false)
                {
                    MPCF.ShowMsgBox(out_node.Msg);
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

        public IORESULT Initialize()
        {
            IORESULT result = IORESULT.SUCCEEDED;
            _tcpComm.CONNECTEDSTATUS += new clsCustomBaseTcpComm.degCONNECTEDSTATUS(ConnectedStatusEvent);

            _ip = "192.168.0.79";
            _portNo = "33000";
            _readAntena = (RFID_Antena)ushort.Parse("1");
            _writeAntena = (RFID_Antena)ushort.Parse("1");
            _tcpComm.IsLog = false;
            _tcpComm.IsReceiveString = true;
            result = _tcpComm.Initialize(_ip, _portNo, SERVER_CLIENT.Client, 10000);//setting[0] : ip, setting[1] : port

            if (result != IORESULT.SUCCEEDED)
            {
                Console.WriteLine(string.Format("Failed Open : {0}", _ip));
                btnRFID.Text = "RFID(Off)";
                return IORESULT.FAILED;
            }
            btnRFID.Text = "RFID(On)";
            return IORESULT.SUCCEEDED;
        }

        public IORESULT Terminalize()
        {
            IORESULT result = IORESULT.SUCCEEDED;

            result = _tcpComm.DeInitialize();

            if (result != IORESULT.SUCCEEDED)
            {
                Console.WriteLine(string.Format("Failed Close"));
                return IORESULT.FAILED;
            }
            btnRFID.Text = "RFID(Off)";
            return result;
        }

        public void ConnectedStatusEvent(CONNECTED_STATUS connectedStatus)
        {
            _connectedStatus = connectedStatus;
            Console.WriteLine("{0} : ConnectedStatusEvent  = {1}", _ip, _connectedStatus.ToString());

            if (_connectedStatus == CONNECTED_STATUS.CONNECTED)
            {
                _tcpComm.ReceiveAllClear();
            }
        }

        public string ReadRfid()
        {
            string result = string.Empty;
            IORESULT ioResult = IORESULT.SUCCEEDED;
            lock (this)
            {
                string receive = string.Empty;
                string strCmd = string.Empty;
                int startAddress = 0;
                int length = 14;
                RFID_Antena enAntena = RFID_Antena.IO_1;
                _tcpComm.ReceiveAllClear();

                enAntena = (RFID_Antena)ushort.Parse("1");

                if (enAntena == RFID_Antena.IO_1)
                    enAntena = _readAntena;
                else if (enAntena == RFID_Antena.IO_1)
                    enAntena = _writeAntena;

                startAddress = 0;
                length = 14;
                strCmd = string.Format("RD_{0:00}_{1:00000}_{2:0000}\r\n", (ushort)enAntena, startAddress, length);
                byte[] command = Encoding.ASCII.GetBytes(strCmd);
                ioResult = _tcpComm.Send(command,10);
                if (ioResult == IORESULT.SUCCEEDED)
                {
                    string rfid_magazine_id = string.Empty;
                    ioResult = _tcpComm.Receive(ref rfid_magazine_id, 13, 1);

                    if (ioResult == IORESULT.SUCCEEDED)
                    {
                        result = rfid_magazine_id.Substring(20, 14);
                        btnRFID.Text = "RFID(On)";
                    }
                }
                else
                {
                    btnRFID.Text = "RFID(Off)";
                }
            }
            return result;
        }

        public bool procprint()
        {
            try
            {   
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");
                TRSNode out_report = new TRSNode("REPORT_OUT");

                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = "FullCellSlipV2";
                spdList_Flexible.ScreenSpread.Tag = "FullCellSlipV2";

                if (spdList_Flexible.LoadDesign("FullCellSlipV2") == false)
                {
                    return false;
                }

                MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                in_node.ProcStep = '3';
                in_node.AddString("ORDER_ID", p_order_id);
                in_node.AddString("LACK_ID", p_lack_id);

                if (MPCF.CallService("CRPT", "CRPT_View_Fullcell_Cart_Label", in_node, ref out_node) == false)
                {
                    MPCF.ShowMsgBox(out_node.Msg);
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                string magazineNo = string.Empty;
                string cntNo = string.Empty;
                string smallboxNo = string.Empty;
                string batchNo = string.Empty;

                if (out_node.GetList(0).Count > 0)
                {
                    out_report.SetString("CARRIER_ID", out_node.GetList(0)[0].GetString("CARRIER_ID"));
                    out_report.SetString("BATCH_NO", out_node.GetList(0)[0].GetString("BATCH_NO"));
                    out_report.SetString("EFFICIENCY", out_node.GetList(0)[0].GetString("EFFICIENCY"));
                    out_report.SetString("GRADE", out_node.GetList(0)[0].GetString("GRADE"));
                    //out_report.SetInt("MAGAZINE_CNT", out_node.GetList(0).Count);
                    out_report.SetDouble("MAGAZINE_CNT", out_node.GetDouble("MAGAZINE_CNT"));
                    //out_report.SetDouble("FULLCELL_CNT", out_node.GetDouble("FULLCELL_CNT"));
                    out_report.SetDouble("FULLCELL_CNT", out_node.GetDouble("TOTAL_NUM_CELLS"));
                    out_report.SetString("CLEAVING_PO", out_node.GetList(0)[0].GetString("CLEAVING_PO"));
                    out_report.SetDouble("STOCK_CELL", out_node.GetDouble("CLEAVING_PO_CNT") - out_node.GetDouble("TOTAL_NUM_CELLS"));
                    out_report.SetDouble("CLEAVING_PO_CNT", out_node.GetDouble("CLEAVING_PO_CNT"));
                    out_report.SetDouble("CLEAVING_PO_CNT2", out_node.GetDouble("CLEAVING_PO_CNT") - out_node.GetDouble("TOTAL_NUM_CELLS"));
                    //out_report.SetString("DATE_TIME", out_node.GetList(0)[0].GetString("DATE_TIME"));
                    out_report.SetString("DATE_TIME", MPCF.MakeDateFormat(out_node.GetList(0)[0].GetString("DATE_TIME"), DATE_TIME_FORMAT.DATETIME));

                    int j = 0;
                    int magazineSeq = 0;
                    int boxSeq = 1;
                    int sumCount = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        // Magazine ID & Count
                        if (i < 1)
                        {
                            magazineSeq = 1;
                            boxSeq = 1;

                            magazineNo = String.Format("MAGAZINE_{0}", magazineSeq);
                            out_report.SetString(magazineNo, MPCF.Trim(out_node.GetList(0)[i].GetString("MAGAZINE")));

                            cntNo = String.Format("CNT_{0}", magazineSeq);
                            sumCount = sumCount + out_node.GetList(0)[i].GetInt("CNT");
                            out_report.SetInt(cntNo, sumCount);
                        }
                        else
                        {
                            if (out_node.GetList(0)[i - 1].GetString("MAGAZINE") != out_node.GetList(0)[i].GetString("MAGAZINE"))
                            {
                                ++magazineSeq;
                                sumCount = 0;
                                boxSeq = 1;

                                magazineNo = String.Format("MAGAZINE_{0}", magazineSeq);
                                out_report.SetString(magazineNo, MPCF.Trim(out_node.GetList(0)[i].GetString("MAGAZINE")));

                                cntNo = String.Format("CNT_{0}", magazineSeq);
                                sumCount = sumCount + out_node.GetList(0)[i].GetInt("CNT");
                                out_report.SetInt(cntNo, sumCount);
                            }
                            else
                            {
                                cntNo = String.Format("CNT_{0}", magazineSeq);
                                sumCount = sumCount + out_node.GetList(0)[i].GetInt("CNT");
                                out_report.SetInt(cntNo, sumCount);
                            }

                        }

                        // Cell Box ID
                        if (out_node.GetList(0)[i].GetInt("CNT") == 150)
                        {
                            smallboxNo = String.Format("SMALLBOX_{0}_{1}", magazineSeq, boxSeq);
                            out_report.SetString(smallboxNo, MPCF.Trim(out_node.GetList(0)[i].GetString("SMALLBOX_ID")));
                            ++boxSeq;
                        }
                        else if (out_node.GetList(0)[i].GetInt("CNT") == 300)
                        {
                            smallboxNo = String.Format("SMALLBOX_{0}_{1}", magazineSeq, 1);
                            out_report.SetString(smallboxNo, MPCF.Trim(out_node.GetList(0)[i].GetString("SMALLBOX_ID")));
                        }
                        else
                        {
                            smallboxNo = String.Format("SMALLBOX_{0}_{1}", magazineSeq, 1);
                            out_report.SetString(smallboxNo, MPCF.Trim(out_node.GetList(0)[i].GetString("SMALLBOX_ID")));
                        }

                    }

                }

                if (spdList_Flexible.SetDataToScreen(out_report) == false)
                {
                    return false;
                }

                for (int z = 0; z < 2; z++)
                {
                    MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.INFO, false);
                return false;
            }
        }

        #endregion






    }
}