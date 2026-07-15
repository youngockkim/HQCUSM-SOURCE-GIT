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

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSTranLoadHalfCell : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        const int ENTER = 13;
        string sBoxID = string.Empty;

        #endregion

        #region Constructor

        public frmCUSTranLoadHalfCell()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum LOT_LIST
        {
            LACK_ID,
            PACK_ID,
            CELL_BOX_ID,
            PACK_QTY
        }

        #endregion

        #region [Variable Definition]

        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        public frmCWIPHalfcellCartLabelPopup frmCWIPHalfcellCartLabelPopup;
        public string p_order_id;
        public string p_lack_id;

        #endregion

        #region Event Handler

        private void frmCUSTranLoadHalfCell_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
            MPCF.ClearList(spdLotList);

            SetupPrtOpt();

            // Fix Operation
            cdvOperID.Text = HQGC.OPER_M1000; // Cleaving
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
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOperID.Text = cdvOperID.Show(cdvOperID, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOperID.Text == null || cdvOperID.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvEquipID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLineID.Text);
                in_node.AddString("OPER", cdvOperID.Text);

                // Display and Header Text Setup
                string[] header = new string[] { "Equip ID", "Equip Desc" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show CodeView and Get Return
                cdvEquipID.Text = cdvEquipID.Show(cdvEquipID, "View Resource List", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvEquipID.Text) == true)
                {
                    MPCF.SetFocus(cdvEquipID);
                    return;
                }

                if (!ViewWorkOrder())
                    return;

                // Focus
                MPCF.SetFocus(txtLackID);
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
                // CodeView Service
                TRSNode in_node = new TRSNode("View_Order_List_Detail_In");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLineID.Text);
                //in_node.AddChar("ORD_STATUS_FLAG", 'Y');
                in_node.AddString("MAT_ID", "");

                string[] header = new string[] { "Order ID", "Order Desc" };
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                cdvOrderNo.Text = cdvOrderNo.Show(cdvOrderNo, "View Production Order List By Line", "CORD", "CORD_View_Order_List_By_Line", in_node, "LIST", display, header, "ORDER_ID");

                if (cdvEquipID == null)
                {
                    return;
                }

                ViewOrder(cdvOrderNo.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmCUSTranLoadHalfCell_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
                MPCF.SetFocus(txtLackID);
            }
        }

        private void txtLackID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtLackID.Text) != "")
            {
                txtLackID.Text = MPCF.ToUpper(txtLackID.Text); // 일괄 대문자

                if (e.KeyChar == (char)13)
                {
                    if (string.IsNullOrEmpty(txtWorkOrder.Text) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(408), MSG_LEVEL.ERROR, false);
                        MPCF.SetFocus(txtLackID);
                        return;
                    }

                    MPCF.ClearList(spdLotList);

                    if (!ViewPackLotList(txtLackID.Text))
                    {
                        txtLackID.Focus();
                        txtLackID.SelectAll();
                        return;
                    }

                    txtLackID.Focus();
                    txtLackID.SelectAll();

                    p_order_id = cdvOrderNo.Text; // PO 정보 담아두기
                    p_lack_id = txtLackID.Text; // 캐리어 정보 담아두기
                }

            }
        }

        private void txtPack_ID_KeyPress(object sender, KeyPressEventArgs e)
        {      
             try
            {
                if (e.KeyChar == (char)13)
                {
                    if (!CheckCondition("VIEW"))
                        return;

                    if (txtLoadCount.Text == txtLimitCount.Text)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(502), MSG_LEVEL.ERROR, false);
                        return;
                    }

                    if (chkInputCellbox.Checked == false)
                    {
                        PackLotListAdd(txtPackID.Text);
                        p_order_id = cdvOperID.Text;
                        p_lack_id = txtLackID.Text;
                    }
                    else
                    {
                        MPCF.SetFocus(txtCellboxID);
                    }
                }
            }
             catch (Exception ex)
             {
                 MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
             }
        }

        private void txtCellboxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (!CheckCondition("VIEW"))
                        return;

                    if (txtLoadCount.Text == txtLimitCount.Text)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(502), MSG_LEVEL.ERROR, false);
                        return;
                    }

                    if (chkInputCellbox.Checked == true)
                        PackLotListAdd(txtPackID.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition("VIEW"))
                    return;

                ViewPackLotList(txtPackID.Text);
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
                if (txtWorkOrder.Text == null || txtWorkOrder.Text == string.Empty)
                {
                    return;
                }

                // Show Popup
                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(txtWorkOrder.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Pack_Lot_Input(txtPackID.Text, '1') == true)
            {
                ClearData("1");
                txtLackID.Text = string.Empty;
                txtPackID.Text = string.Empty;
                //txtMatLotID.Text = "";
                MPCF.SetFocus(txtLackID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdLotList);
            txtPackID.Text = "";
            txtLackID.Text = "";
            MPCF.SetFocus(txtLackID);

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
            if (!CheckCondition("PROCESS"))
                return;
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdLotList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowErrorMessage(MPCF.GetMessage(192));
                    return;
                }

                spdLotList.ActiveSheet.Rows.Remove(spdLotList.ActiveSheet.ActiveRowIndex, 1);

                int iRowCount = spdLotList.ActiveSheet.RowCount;

                for (int i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                {
                    //spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.NO].Value = iRowCount;
                    iRowCount--;
                }

                txtLoadCount.Text = spdLotList.ActiveSheet.RowCount.ToString();

                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void chkInputCellbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInputCellbox.Checked == true)
            {
                lblCellbox.Visible = true;
                txtCellboxID.Visible = true;
            }
            else
            {
                lblCellbox.Visible = false;
                txtCellboxID.Visible = false;
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

            /*
            if (string.IsNullOrEmpty(cdvEquipID.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(410), MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(cdvEquipID);
                return;
            }
            */

            if (string.IsNullOrEmpty(cdvOrderNo.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(504), MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(cdvOrderNo);
                return;
            }

            if (string.IsNullOrEmpty(txtLackID.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(324), MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(txtLackID);
                return;
            }

            frmCWIPHalfcellCartLabelPopup.p_lack_id = txtLackID.Text;
            frmCWIPHalfcellCartLabelPopup.p_order_id = txtWorkOrder.Text;

            frmCWIPHalfcellCartLabelPopup = new frmCWIPHalfcellCartLabelPopup();
            frmCWIPHalfcellCartLabelPopup.Owner = this;
            frmCWIPHalfcellCartLabelPopup.ShowDialog();
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

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            // print
            procprint();
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

                        if (string.IsNullOrEmpty(txtPackID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[PACK ID]"));
                            MPCF.SetFocus(txtPackID);
                            return false;
                        }

                        for (int k = 0; k < spdLotList.ActiveSheet.RowCount; k++)
                        {
                            if (txtPackID.Text == spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.PACK_ID].Text)
                            {
                                //MPCF.ShowErrorMessage("해당 Magazine은 스프레드에 추가 되어 있습니다.");
                                MPCF.ShowMessage(MPCF.GetMessage(501), MSG_LEVEL.ERROR, false);

                                txtPackID.Text = "";
                                return false;
                            }
                        }

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(txtLackID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[LACK ID]"));
                            MPCF.SetFocus(txtLackID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvOrderNo.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[ORDER NO]"));
                            MPCF.SetFocus(cdvOrderNo);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvEquipID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[RES ID]"));
                            MPCF.SetFocus(cdvEquipID);
                            return false;
                        }
                                               

                        if (spdLotList.ActiveSheet.RowCount == 0)
                        {
                            //MPCF.ShowMsgBox("저장 할 Data가 존재하지 않습니다.");
                            MPCF.ShowMessage(MPCF.GetMessage(462), MSG_LEVEL.ERROR, false);
                            MPCF.SetFocus(txtPackID);
                            return false;
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

                cdvOrderNo.Text = out_node.GetString("ORDER_ID");
                txtWorkOrder.Text = out_node.GetString("ORDER_ID");
                txtMaterial.Text = out_node.GetString("MAT_ID");
                txtMaterialDesc.Text = " : " + out_node.GetString("MAT_DESC");
                txtGrade.Text = out_node.GetString("GRADE_ID");
                txtDueDate.Text = MPCF.MakeDateFormat(out_node.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);

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

        private bool ViewPackLotList(string sCartID)
        {
            TRSNode in_node = new TRSNode("View_Pack_List_In");
            TRSNode out_node = new TRSNode("View_Pack_List_Out");
            TRSNode out_list;

            ArrayList lisPackList = new ArrayList();

            try
            {
                // Clear
                MPCF.ClearList(this.spdLotList);

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("ORDER_ID", MPCF.Trim(cdvOrderNo.Text));
                in_node.AddString("LACK_ID", MPCF.Trim(sCartID));

                if (MPCF.CallService("CRPT", "CRPT_View_Halfcell_Cart_Label", in_node, ref out_node) == false)
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

                }

                txtLoadCount.Text = (out_node.GetList(0).Count).ToString();


                MPCF.FitColumnHeader(spdLotList);

                txtPackID.Focus();
                txtPackID.SelectAll();
                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewLackInfo(string sLotID)
        {
            try {
                    TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
                    TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("CRR_ID", sLotID);

                    if (MPCF.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                    {
                        if (out_node.GetList(0) == null)
                        {                            
                            //MPCF.ShowMsgBox("대차 정보가 존재하지 않습니다.");
                            MPCF.ShowMessage(MPCF.GetMessage(407), MSG_LEVEL.ERROR, false);
                            return false;
                        }

                        return false;
                    }

                    txtLoadCount.Text = out_node.GetInt("USAGE_COUNT").ToString();
                    txtLimitCount.Text = out_node.GetInt("CRR_SIZE").ToString();

                    txtPackID.Focus();
                    txtPackID.SelectAll();
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

        private bool ViewOrder(string sOrderId)
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

            if (MPCF.CallService("CORD", "CORD_View_Current_Order_By_Line", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvOrderNo.Text = out_node.GetString("ORDER_ID");
            txtWorkOrder.Text = out_node.GetString("ORDER_ID");
            txtMaterial.Text = out_node.GetString("MAT_ID");
            txtMaterialDesc.Text = " : " + out_node.GetString("MAT_DESC");
            txtGrade.Text = out_node.GetString("GRADE_ID");
            txtDueDate.Text = MPCF.MakeDateFormat(out_node.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);

            lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
            lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
            lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
            lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

            MPCF.SetFocus(txtLackID);

            return true;
        }

        private bool PackLotListAdd(string sLotID)
        {
            try
            {

                //TRSNode in_node = new TRSNode("VIEW_CRR_IN");
                //TRSNode out_node = new TRSNode("VIEW_CRR_OUT");

                //MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                //in_node.AddString("ORDER_ID", cdvOrderNo.Text);  // Po ID
                //in_node.AddString("LACK_ID", txtLackD.Text);    // Cart ID
                //in_node.AddString("PACK_ID", txtPackID.Text);       // Magazine ID
                //in_node.AddChar("PACK_TYPE", 'F');               // PACK TYPE

                //if (MPCF.CallService("CWIP", "CWIP_View_Packing_Fullcell_List", in_node, ref out_node) == true)
                //{
                //    if (out_node.GetList(0) == null)
                //    {
                //        MPCF.ShowMessage(MPCF.GetMessage(407), MSG_LEVEL.ERROR, false);
                //        return false;
                //    }

                //    return false;
                //}

                //if (out_node.GetList(0).Count > 0)
                //{
                //    for (int i = 0; i < out_node.GetList(0).Count; i++)
                //    {
                //        spdLotList.ActiveSheet.AddRows(0, 1);
                //        spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                //        spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value = out_node.GetList(0)[i].GetString("LACK_ID");
                //        spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_ID].Value = out_node.GetList(0)[i].GetString("PACK_ID");
                //        spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_QTY].Value = out_node.GetList(0)[i].GetInt("PACK_QTY");
                //    }
                //}
                //else
                //{
                    spdLotList.ActiveSheet.AddRows(0, 1);
                    //spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value = txtLackID.Text;
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_ID].Value = txtPackID.Text;                    
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_QTY].Value = 1;
                    if (chkInputCellbox.Checked == true)
                    {
                        spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CELL_BOX_ID].Value = txtCellboxID.Text;
                    }
                    else
                    {
                        spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CELL_BOX_ID].Value = "";
                    }
                //}

                txtLoadCount.Text = spdLotList.ActiveSheet.RowCount.ToString();
                txtPackID.Text = string.Empty;
                txtCellboxID.Text = string.Empty;
                
                MPCF.SetFocus(txtPackID);

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool Tran_Pack_Lot_Input(string sLotID, char cStep)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                if (chkInputCellbox.Checked == false)
                {
                    in_node.ProcStep = '1';
                }
                else
                {
                    in_node.ProcStep = '2';
                }

                in_node.AddString("ORDER_ID", txtWorkOrder.Text);
                in_node.AddString("MAT_ID", txtMaterial.Text);
                in_node.AddString("OPER", cdvOperID.Text);
                in_node.AddString("RES_ID", cdvEquipID.Text);

                int iRowCnt = 0;
                for (int i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                {
                    iRowCnt++;
                }

                for (int k = spdLotList.ActiveSheet.RowCount - 1; k > -1; k--)
                {
                    list_item = in_node.AddNode("HALFCELL_PACK_LIST");
                    list_item.AddString("LACK_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.LACK_ID].Value));
                    list_item.AddString("PACK_TYPE", "H");
                    list_item.AddString("PACK_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.PACK_ID].Value));
                    list_item.AddString("CELL_BOX_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.CELL_BOX_ID].Value));
                    list_item.AddString("OPER", cdvOperID.Text);
                    list_item.AddString("MAT_ID", txtMaterial.Text);
                    list_item.AddInt("PACK_QTY", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.PACK_QTY].Value));
                    list_item.AddString("ORDER_ID", txtWorkOrder.Text);
                }

                if (MPCF.CallService("CWIP", "CWIP_Packing_Halfcell", in_node, ref out_node) == false)
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

        public bool procprint()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");
                TRSNode out_report = new TRSNode("REPORT_OUT");

                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = "HalfCellSlip";
                spdList_Flexible.ScreenSpread.Tag = "HalfCellSlip";
                spdList_Flexible.ProcStep = '1';
                spdList_Flexible.LotID = "HalfCellSlip";

                if (spdList_Flexible.LoadDesign("HalfCellSlip") == false)
                {
                    return false;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", cdvOrderNo.Text);
                in_node.AddString("LACK_ID", txtLackID.Text);

                if (MPCF.CallService("CRPT", "CRPT_View_Halfcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                string magazineNo = string.Empty;
                string cntNo = string.Empty;
                string smallboxNo = string.Empty;
                string batchNo = string.Empty;

                if (out_node.GetList(0).Count > 0)
                {
                    out_report.SetString("CARRIER_ID", out_node.GetList(0)[0].GetString("CARRIER_ID"));
                    out_report.SetString("LINE", out_node.GetList(0)[0].GetString("LINE"));
                    out_report.SetString("EFFICIENCY", out_node.GetList(0)[0].GetString("EFFICIENCY"));
                    out_report.SetString("GRADE", out_node.GetList(0)[0].GetString("GRADE"));
                    out_report.SetInt("MAGAZINE_CNT", out_node.GetList(0).Count);
                    out_report.SetDouble("HALFCELL_CNT", out_node.GetDouble("HALFCELL_CNT"));
                    //out_report.SetString("MODULE_PO_CNT", out_node.GetList(0)[0].GetString("CLEAVING_PO"));
                    out_report.SetString("STOCK_CELL", out_node.GetList(0)[0].GetDouble("STOCK_CELL"));
                    out_report.SetString("MODULE_PO", out_node.GetList(0)[0].GetString("MODULE_PO"));
                    out_report.SetString("DATE_TIME", out_node.GetList(0)[0].GetString("DATE_TIME"));

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        magazineNo = String.Format("MAGAZINE_{0}", i + 1);
                        out_report.SetString(magazineNo, MPCF.Trim(out_node.GetList(0)[0].GetString("MAGAZINE")));

                        cntNo = String.Format("CNT_{0}", i + 1);
                        out_report.SetInt(cntNo, out_node.GetList(0)[0].GetInt("CNT"));

                        smallboxNo = String.Format("CLEAVINGPO_{0}", i + 1);
                        out_report.SetString(smallboxNo, MPCF.Trim(out_node.GetList(0)[0].GetString("CLEAVING_PO")));

                        batchNo = String.Format("CLEAVINGNO_{0}", i + 1);
                        out_report.SetString(batchNo, MPCF.Trim(out_node.GetList(0)[0].GetString("CLEAVING_NO")));
                    }
                }

                if (spdList_Flexible.SetDataToScreen(out_report) == false)
                {
                    return false;
                }

                MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, true);
                return false;
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
