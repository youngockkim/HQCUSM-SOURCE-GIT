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

namespace BOI.COMCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCOMLabelTest : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string sDefaultPrintName = string.Empty;
        private string sChildLotId = string.Empty;
        private MenuInfoTag menuInfo;
        public PrintOptionModel printOption;
        private frmPrintOptionPopup frmOption;

        private enum INV_LOT_COL
        {
            HIST_SEQ = 0,
            TRAN_TIME,
            TRAN_CODE,
            INV_ACCT,
            MAT_ID,
            MAT_DESC,
            OPER_DESC,
            QTY_1,
            UNIT_1,
            FROM_TO_FLAG,
            FROM_TO_LOT_ID,
            INV_CMF_1,
            INV_CMF_2,
            INV_CMF_3,
            INV_CMF_4,
            INV_CMF_5,
            INV_CMF_6,
            INV_CMF_7,
            INV_CMF_8
        }

        #endregion

        #region Constructor

        public frmCOMLabelTest()
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
                    txtInvLotID.Focus();
                    txtInvLotID.SelectAll();
                    return false;
                }
               
                txtInvLotID.Focus();
                txtInvLotID.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
                String s_lot_id;

                s_lot_id = MPCF.Trim(txtInvLotID.Text);
                if (s_lot_id == "")
                    return;


                sDefaultPrintName = MPCF.GetRegSetting(this.Name, "Settings", "SAVE_PRINT_NAME");
                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return;
                }
                udcScreen.InitFlexibleScreen();
                if (udcScreen.LoadDesign("BASIC_LOT") == false)
                    return;
                if (udcScreen.SetDataToScreen(out_node) == false)
                    return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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
                    //tempLotId = txtInvLotID.Text.Trim();
                    //indexValue = tempLotId.IndexOf(":");

                    //txtInvLotID.Text = tempLotId.Substring(0, indexValue);
                    //txtUnitQty.Value = MPCF.ToDbl(tempLotId.Substring(indexValue + 1));

                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW_LOT":
                        //INV LOT ID
                        if (MPCF.Trim(txtInvLotID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            txtInvLotID.Focus();
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


        #endregion

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
                    sDefaultPrintName = this.printOption.Document.PrinterName;
                    MPCF.SaveRegSetting(this.Name, "Settings", "SAVE_PRINT_NAME", sDefaultPrintName);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.PrintInfo print_info = new FarPoint.Win.Spread.PrintInfo();

            try
            {

                if (string.IsNullOrEmpty(MPCF.Trim(sDefaultPrintName)) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(471));
                    return;
                }


                if (sChildLotId == "")
                {
                    
                    print_info.Printer = MPCF.Trim(sDefaultPrintName);
                    print_info.ShowGrid = false;
                    print_info.ShowBorder = true;
                    print_info.Margin = new FarPoint.Win.Spread.PrintMargin(20, 40, 0, 0, 0, 0);
                    print_info.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait;
                    print_info.UseMax = true;
                    print_info.UseSmartPrint = false;
                    print_info.PaperSize = new System.Drawing.Printing.PaperSize("A6", 413, 582);

                    udcScreen.ScreenSpread.ActiveSheet.PrintInfo = print_info;

                    udcScreen.ScreenSpread.PrintSheet(0);
                }
                else
                {
                    udcScreen.ScreenSpread.ActiveSheet.PrintInfo.Printer = MPCF.Trim(sDefaultPrintName);
                    udcScreen.ScreenSpread.PrintSheet(0);

                    //udcScreenLoss.ScreenSpread.ActiveSheet.PrintInfo.Printer = MPCF.Trim(sDefaultPrintName);
                    //udcScreenLoss.ScreenSpread.PrintSheet(0);
                }

                //spdSpread.ActiveSheet.PrintInfo.Printer = MPCF.Trim(cdvPrinter.Text);
                //spdSpread.PrintSheet(0);

                MPCF.ShowMsgBox(MPCF.GetMessage(52));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


    }
}
