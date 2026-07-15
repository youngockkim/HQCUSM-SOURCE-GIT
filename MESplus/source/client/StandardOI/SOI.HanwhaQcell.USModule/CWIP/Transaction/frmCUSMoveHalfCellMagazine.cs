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
    public partial class frmCUSMoveHalfCellMagazine : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        const int ENTER = 13;
        string sBoxID = string.Empty;

        #endregion

        #region Constructor

        public frmCUSMoveHalfCellMagazine()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum LOT_LIST
        {
            NO,
            LACK_ID,
            QTY
        }

        #endregion

        #region [Variable Definition]

        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void frmCUSMoveHalfCellMagazine_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
            MPCF.ClearList(spdLotList);

            SetupPrtOpt();

            // Fix Operation
            cdvOperID.Text = HQGC.OPER_M2000; // Tabber
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void frmCUSMoveHalfCellMagazine_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
                MPCF.SetFocus(txtLackID);
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

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

                // Validation
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

                ViewOrder(cdvOrderNo.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtLackID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtLackID.Text) != "")
            {
                txtLackID.Text = MPCF.ToUpper(txtLackID.Text); // 일괄 대문자

                if (!CheckCondition("VIEW"))
                    return;

                if (e.KeyChar == (char)13)
                {
                    LackLotListAdd(txtLackID.Text);
                }

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

            if (Tran_Lack_Lot_Input(txtLackID.Text) == true)
            {
                ClearData("1");
                txtLackID.Text = string.Empty;
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

            ProcPrint();
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
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.NO].Value = iRowCount;
                    iRowCount--;
                }

                txtCount.Text = spdLotList.ActiveSheet.RowCount.ToString();

                
            }
            catch (Exception)
            {
                throw;
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

                        if (string.IsNullOrEmpty(txtLackID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[PACK ID]"));
                            MPCF.SetFocus(txtLackID);
                            return false;
                        }

                        for (int k = 0; k < spdLotList.ActiveSheet.RowCount; k++)
                        {
                            if (txtLackID.Text == spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.LACK_ID].Text)
                            {
                                //MPCF.ShowErrorMessage("해당 Magazine은 스프레드에 추가 되어 있습니다.");
                                MPCF.ShowMessage(MPCF.GetMessage(501), MSG_LEVEL.ERROR, false);

                                txtLackID.Text = "";
                                return false;
                            }
                        }

                        break;

                    case "PROCESS":

                        if (spdLotList.ActiveSheet.RowCount == 0)
                        {
                            //MPCF.ShowMsgBox("저장 할 Data가 존재하지 않습니다.");
                            MPCF.ShowMessage(MPCF.GetMessage(462), MSG_LEVEL.ERROR, false);
                            MPCF.SetFocus(txtLackID);
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

        private bool ViewPackLotList(string sLotID)
        {
            //TRSNode in_node = new TRSNode("View_Pack_List_In");
            //TRSNode out_node = new TRSNode("View_Pack_List_Out");

            //ArrayList lisPackList = new ArrayList();

            try
            {
                // Clear
                //MPCF.ClearList(this.spdLotList);

                // View Lot for Validation
                //ViewPackLot(sLotID);

                // Call Service
                //MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                //in_node.AddString("LACK_ID", MPCF.Trim(sLotID));

                //if (MPCF.CallService("CUS", "CWIP_View_PACK_List", in_node, ref out_node) == false)
                //{
                //    return false;
                //}

                //if (out_node.GetList(0) == null)
                //{
                //    txtLackID.Focus();
                //    txtLackID.SelectAll();
                //    return true;
                //}
                
                //int iRow = 0;

                //for (int i = 0; i < out_node.GetList(0).Count; i++)
                //{
                //    spdLotList.ActiveSheet.AddRows(0, 1);
                //    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                //    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value = out_node.GetList(0)[iRow].GetString("LACK_ID");
                //    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.QTY].Value = out_node.GetList(0)[iRow].GetInt("QTY");
                //}
                        
                //foreach (object obj in lisPackList)
                //{
                //    out_node = null;

                //    out_node = (TRSNode)obj;
                //    spdLotList.ActiveSheet.RowCount = out_node.GetList(0).Count;
                //}

                //MPCF.FitColumnHeader(spdLotList);

                //txtLackID.Focus();
                //txtLackID.SelectAll();
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

                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = out_node.GetInt("USAGE_COUNT").ToString();
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
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

            lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
            lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
            lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
            lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_PACK_QTY")); //PACK QTY
            return true;
        }

        private bool LackLotListAdd(string sLotID)
        {
            try
            {
                spdLotList.ActiveSheet.AddRows(0, 1);
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value = txtLackID.Text;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.QTY].Value = 1;
                txtCount.Text = spdLotList.ActiveSheet.RowCount.ToString();

                txtLackID.Text = string.Empty;
                MPCF.SetFocus(txtLackID);
                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool Tran_Lack_Lot_Input(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", txtWorkOrder.Text);

                in_node.AddString("LACK_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value));
                if (MPCF.CallService("CWIP", "CWIP_Move_HalfCell_Cart", in_node, ref out_node) == false)
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

        private bool ProcPrint()
        {
            //TRSNode out_node = new TRSNode("OUT_NODE");
            //SOIFlexibleScreen udcPrinit = new SOIFlexibleScreen();

            //int i;
            //int iRowCount;
            //string sProdID;

            //try
            //{
            //    udcPrinit.InitFlexibleScreen();
            //    udcPrinit.ScreenID = "ViewHalfCellMagazineList";
            //    udcPrinit.ScreenSpread.Tag = "ViewHalfCellMagazineList";
            //    udcPrinit.ProcStep = '1';
            //    //             MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
            //    //              udcPrinit.OwnerFuncName = menuInfo.s_func_name;
            //    udcPrinit.LotID = "ViewHalfCellMagazineList";

            //    if (udcPrinit.LoadDesign() == false)
            //    {
            //        return false;
            //    }

            //    iRowCount = spdLotList.ActiveSheet.RowCount;

            //    out_node.SetString("MAT_SHORT_DESC", MPCF.Trim(spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value));
            //    out_node.SetString("LACK_ID", txtLackID.Text);

            //    for (i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
            //    {
            //        sProdID = String.Format("PROD_ID_{0}", i + 1);
            //        out_node.SetString(sProdID, MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LACK_ID].Value));
            //    }

            //    if (udcPrinit.SetDataToScreen(out_node) == false)
            //    {
            //        return false;
            //    }

            //    udcPrinit.ScreenSpread.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;

            //    for (i = 0; i < MPCF.ToInt(txtPrintQty.Value); i++)
            //    {
            //        MPCF.PrintFlexibleScreen(this, this.printOption, udcPrinit, false);
            //    }

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMsgBox(ex.Message);
            //    return false;
            //}

            return true;
        }

        #endregion


    }
}
