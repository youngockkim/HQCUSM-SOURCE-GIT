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
    public partial class frmCWIPMoveHalfCellsToModuleLine : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        const int ENTER = 13;
        string sBoxID = string.Empty;

        #endregion

        #region Constructor

        public frmCWIPMoveHalfCellsToModuleLine()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum BOM_LIST
        {
            ORDER_ID = 0,
            EFFICIENCY,
            GRADE
        }

        public enum LOT_LIST
        {
            CART_ID = 0,
            PACK_ID,
            PACK_QTY,
            CLEAVING_NO,
            CLEAVING_DESC,
            MODULE_LINE,
            MODULE_PO
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

        private void frmCWIPMoveHalfCellsToModuleLine_Load(object sender, EventArgs e)
        {
            MPCF.ConvertCaption(this);
            MPCF.ClearList(spdLotList);

            SetupPrtOpt();

            // Fix Operation
            cdvOperID.Text = HQGC.OPER_M2000; // Tabber
        }

        private void frmCWIPMoveHalfCellsToModuleLine_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
                MPCF.SetFocus(txtCart);
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

                // Clear Production Order
                MPCF.FieldClear(cdvOrderNo);

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
                double orderEfficiency = 0;

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

                if (double.TryParse(pop.outEfficiency, out orderEfficiency))
                {
                    orderEfficiency = orderEfficiency / 100.00;
                    txtEfficiency.Text = orderEfficiency.ToString("#.00");
                }
                else
                {
                    txtEfficiency.Text = pop.outEfficiency;
                }

                txtGrade.Text = pop.outGrade;

                lblOrderQty.Text = MPCF.MakeNumberFormat(pop.outOrderQty);
                lblInQty.Text = MPCF.MakeNumberFormat(pop.outInQty);
                lblOutQty.Text = MPCF.MakeNumberFormat(pop.outOutQty);
                lblLossQty.Text = MPCF.MakeNumberFormat(pop.outLossQty);

                ViewOrderBOMList();

                // Clear
                //txtCart.Text = string.Empty;
                MPCF.SetFocus(txtCart);
                txtCart.SelectAll();

                //MPCF.ClearList(this.spdLotList);

                //ViewOrder(cdvOrderNo.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtCart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtCart.Text = MPCF.ToUpper(txtCart.Text);

                if (!ViewCart(txtCart.Text))
                {
                    txtCart.Focus();
                    txtCart.SelectAll();
                    return;
                }

                txtCart.Focus();
                txtCart.SelectAll();

                p_order_id = txtWorkOrder.Text;
                p_lack_id = txtCart.Text;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvLineID, false) == false)
            {
                return;
            }

            if (MPCF.CheckValue(cdvOrderNo, false) == false)
            {
                return;
            }

            if (MPCF.CheckValue(txtCart, false) == false)
            {
                return;
            }

            if (MoveHalfCells(txtCart.Text) == true)
            {

                txtCart.Text = MPCF.ToUpper(txtCart.Text);

                // View
                if (!ViewCart(txtCart.Text))
                {
                    txtCart.Focus();
                    txtCart.SelectAll();
                    return;
                }

                p_order_id = txtWorkOrder.Text;
                p_lack_id = txtCart.Text;
            }

            MPCF.SetFocus(txtCart);
            txtCart.SelectAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdLotList);

            txtCart.Text = string.Empty;
            MPCF.SetFocus(txtCart);
            txtCart.SelectAll();
        }

        private void btnPrintOption_Click_1(object sender, EventArgs e)
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
            // print
            procprint();
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            /*
            if (string.IsNullOrEmpty(txtWorkOrder.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(504), MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(txtWorkOrder);
                return;
            }

            if (string.IsNullOrEmpty(txtCart.Text) == true)
            {
                MPCF.ShowMessage(MPCF.GetMessage(324), MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(txtCart);
                return;
            }
            */

            frmCWIPHalfcellCartLabelPopup.p_lack_id = txtCart.Text;
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

        private void ViewOrderBOMList()
        {
            try
            {
                int i;
                MPCF.ClearList(spdBOM);

                TRSNode in_node = new TRSNode("VIEW_ORDER_BOM_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_BOM_LIST_OUT");
                TRSNode bom_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2'; // MATE_TYPE = 'CELL'
                in_node.AddString("ORDER_ID", MPCF.Trim(cdvOrderNo.Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Order_BOM_List", in_node, ref out_node) == false)
                {
                    return;
                }

                spdBOM.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    bom_list = out_node.GetList(0)[i];

                    spdBOM.ActiveSheet.RowCount++;
                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.ORDER_ID].Value = bom_list.GetString("ORDER_ID");
                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.EFFICIENCY].Value = bom_list.GetString("EFFICIENCY");
                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.GRADE].Value = bom_list.GetString("GRADE");

                }

                MPCF.FitColumnHeader(spdBOM);

                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool ViewCart(string sCartID)
        {
            TRSNode in_node = new TRSNode("View_Pack_List_In");
            TRSNode out_node = new TRSNode("View_Pack_List_Out");
            TRSNode out_list;

            ArrayList lisPackList = new ArrayList();

            int sizeOfCart = 0;

            try
            {
                // Clear
                MPCF.ClearList(this.spdLotList);

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", MPCF.Trim(txtWorkOrder.Text));
                in_node.AddString("LACK_ID", MPCF.Trim(sCartID));

                if (MPCF.CallService("CRPT", "CRPT_View_Halfcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                sizeOfCart = out_node.GetInt("CART_SIZE");

                spdLotList.ActiveSheet.RowCount = 0;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    /*
                    if (i >= sizeOfCart)
                    {
                        break;
                    }
                    */

                    spdLotList.ActiveSheet.RowCount++;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CART_ID].Value = out_list.GetString("CARRIER_ID"); // Cart
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_ID].Value = out_list.GetString("MAGAZINE"); // Magazine
                    //spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CELL_BOX_ID].Value = out_list.GetString("SMALLBOX_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_QTY].Value = out_list.GetInt("QTY");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CLEAVING_NO].Value = out_list.GetString("CLEAVING_NO");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CLEAVING_DESC].Value = out_list.GetString("CLEAVING_DESC");

                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.MODULE_LINE].Value = out_list.GetString("LINE");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.MODULE_PO].Value = out_list.GetString("MODULE_PO");

                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.MODULE_LINE].ForeColor = Color.Red;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.MODULE_PO].ForeColor = Color.Red;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.MODULE_LINE].BackColor = Color.LightGreen;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.MODULE_PO].BackColor = Color.LightGreen;

                    /*
                    if (!string.IsNullOrEmpty(out_node.GetList(0)[i].GetString("CLEAVING_TIME"))
                        && out_node.GetList(0)[i].GetString("CLEAVING_TIME").Length == 14)
                    {
                        spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CLEAVING_TIME].Value 
                            = MPCF.MakeDateFormat(out_list.GetString("CLEAVING_TIME"), DATE_TIME_FORMAT.DATETIME);
                    }
                    */
                }

                //txtLoadCount.Text = (out_node.GetList(0).Count).ToString();

                txtLoadCount.Text = MPCF.ToStr(out_node.GetDouble("MAGAZINE_CNT"));
                txtNumBoxes.Text = MPCF.ToStr(out_node.GetDouble("HALFCELL_CNT"));
                txtNumCells.Text = MPCF.ToStr(out_node.GetDouble("TOTAL_NUM_CELLS"));

                MPCF.FitColumnHeader(spdLotList);

                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool MoveHalfCells(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("ORDER_ID", MPCF.Trim(txtWorkOrder.Text));
                in_node.AddString("ORDER_EFFICIENCY", MPCF.Trim(txtEfficiency.Text));
                in_node.AddString("ORDER_GRADE", MPCF.Trim(txtGrade.Text));
                in_node.AddString("LACK_ID", MPCF.Trim(txtCart.Text));
                
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

        public bool procprint()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");
                TRSNode out_report = new TRSNode("REPORT_OUT");

                int sizeOfCart = 0;

                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = "HalfCellSlipV2";
                spdList_Flexible.ScreenSpread.Tag = "HalfCellSlipV2";
                spdList_Flexible.ProcStep = '1';
                spdList_Flexible.LotID = "HalfCellSlipV2";

                if (spdList_Flexible.LoadDesign("HalfCellSlipV2") == false)
                {
                    return false;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", p_order_id);
                in_node.AddString("LACK_ID", p_lack_id);

                if (MPCF.CallService("CRPT", "CRPT_View_Halfcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                sizeOfCart = out_node.GetInt("CART_SIZE");

                string magazineNo = string.Empty;
                string cntNo = string.Empty;
                //string cleavingTime = string.Empty;
                string cleavingDesc = string.Empty;

                if (out_node.GetList(0).Count > 0)
                {
                    out_report.SetString("CART_ID", out_node.GetList(0)[0].GetString("CART_ID"));
                    out_report.SetString("LINE", out_node.GetList(0)[0].GetString("LINE"));
                    out_report.SetString("LINE_DESC", out_node.GetList(0)[0].GetString("LINE_DESC"));
                    //out_report.SetString("EFFICIENCY", out_node.GetList(0)[0].GetString("ORDER_EFFICIENCY"));
                    //out_report.SetString("GRADE", out_node.GetList(0)[0].GetString("ORDER_GRADE"));
                    out_report.SetInt("MAGAZINE_CNT", out_node.GetList(0).Count);
                    out_report.SetDouble("HALFCELL_CNT", out_node.GetDouble("TOTAL_NUM_CELLS"));

                    out_report.SetString("MODULE_PO", out_node.GetList(0)[0].GetString("MODULE_PO"));
                    out_report.SetDouble("MODULE_PO_QTY", out_node.GetDouble("MODULE_PO_QTY"));
                    out_report.SetString("DATE_TIME", MPCF.MakeDateFormat(out_node.GetList(0)[0].GetString("DATE_TIME"), DATE_TIME_FORMAT.DATETIME));

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (i >= sizeOfCart)
                        {
                            break;
                        }

                        magazineNo = String.Format("MAGAZINE_{0}", i + 1);
                        out_report.SetString(magazineNo, MPCF.Trim(out_node.GetList(0)[i].GetString("MAGAZINE")));

                        cntNo = String.Format("QTY_{0}", i + 1);
                        out_report.SetInt(cntNo, out_node.GetList(0)[i].GetInt("QTY"));

                        cleavingDesc = String.Format("CVL_DESC_{0}", i + 1);
                        out_report.SetString(cleavingDesc, MPCF.Trim(out_node.GetList(0)[i].GetString("CLEAVING_DESC")));

                        /*
                        if (!string.IsNullOrEmpty(out_node.GetList(0)[i].GetString("CLEAVING_TIME"))
                            && out_node.GetList(0)[i].GetString("CLEAVING_TIME").Length == 14)
                        {
                            cleavingTime = String.Format("CVL_TIME_{0}", i + 1);
                            out_report.SetString(cleavingTime, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CLEAVING_TIME"), DATE_TIME_FORMAT.DATETIME));
                        }
                        */
                    }
                }

                if (spdList_Flexible.SetDataToScreen(out_report) == false)
                {
                    return false;
                }

                //for (int z = 0; z < 2; z++)
                //{
                    MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, true);
                //}

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
