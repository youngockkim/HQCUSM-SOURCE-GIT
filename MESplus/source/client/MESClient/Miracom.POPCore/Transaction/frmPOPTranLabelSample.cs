using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;
using System.Drawing.Printing;

namespace Miracom.POPCore
{
    public partial class frmPOPTranLabelSample : Miracom.MESCore.ViewForm01
    {

        private string sDefaultPrintName = string.Empty;
        private string sChildLotId = string.Empty;
        private string s_history_lot_id = string.Empty;
        private string s_order_id = string.Empty;
        private string s_line_id = string.Empty;
        private string s_oper_code = string.Empty;
        private double s_qty_1 = 0;
        private string s_tran_code = string.Empty;

        public frmPOPTranLabelSample()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
            string s_lot_id;

            s_lot_id = MPCF.Trim(txtLotID.Text);
            if (s_lot_id == "") 
                return ;


            sDefaultPrintName = MPCF.GetRegSetting(this.Name, "Settings", "SAVE_PRINT_NAME");
            cdvPrinter.Text = sDefaultPrintName;


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '4';
            in_node.AddString("LOT_ID", s_lot_id);

            if (MPCR.CallService("CUS", "CUS_View_Lot", in_node, ref out_node) == false)
            {
                return;
            }

            string temp;

            double dQty;

            string sLastTranTime;
            string sArrPlanStartTime;
            string sDptPlanStartTime;

            
            if (out_node.GetString("CHILD_LOT_ID") == "")
            {
                temp = out_node.GetString("LAST_TRAN_TIME");
                sLastTranTime = temp.Substring(8, 2) + ":" + temp.Substring(10, 2) + " " + temp.Substring(6, 2) + "-" + temp.Substring(4, 2) + "-" + temp.Substring(0, 4);

                temp = out_node.GetString("DPT_PLAN");
                sDptPlanStartTime = temp.Substring(8, 2) + ":" + temp.Substring(10, 2) + " " + temp.Substring(6, 2) + "-" + temp.Substring(4, 2) + "-" + temp.Substring(0, 4);


                temp = out_node.GetString("ARR_PLAN");

                if (temp == "NA")
                {
                    sArrPlanStartTime = temp;
                }
                else
                {
                    sArrPlanStartTime = temp.Substring(8, 2) + ":" + temp.Substring(10, 2) + " " + temp.Substring(6, 2) + "-" + temp.Substring(4, 2) + "-" + temp.Substring(0, 4);
                }

                out_node.SetString("NOMAL", "GOOD");
                out_node.SetString("LAST_TRAN_TIME", sLastTranTime);
                out_node.SetString("DPT_PLAN", sDptPlanStartTime);
                out_node.SetString("ARR_PLAN", sArrPlanStartTime);
                out_node.SetString("LOT_CMF_6", MPCF.Trim(txtLotID.Text));

                s_history_lot_id = out_node.GetString("LOT_ID");
                s_order_id = out_node.GetString("LOT_CMF_3");
                s_line_id = out_node.GetString("LOT_CMF_6");
                s_oper_code = out_node.GetString("OPER");
                s_qty_1 = out_node.GetDouble("QTY_1");
                s_tran_code = out_node.GetString("LAST_TRAN_CODE");

                udcScreen.InitFlexibleScreen();
                if (udcScreen.LoadDesign("TransferSheet") == false)
                    return;
                if (udcScreen.SetDataToScreen(out_node) == false)
                    return;
            }
            else
            {
                // LOT ID
                temp = out_node.GetString("LAST_TRAN_TIME");
                sLastTranTime = temp.Substring(8, 2) + ":" + temp.Substring(10, 2) + " " + temp.Substring(6, 2) + "-" + temp.Substring(4, 2) + "-" + temp.Substring(0, 4);

                temp = out_node.GetString("DPT_PLAN");
                sDptPlanStartTime = temp.Substring(8, 2) + ":" + temp.Substring(10, 2) + " " + temp.Substring(6, 2) + "-" + temp.Substring(4, 2) + "-" + temp.Substring(0, 4);

                temp = out_node.GetString("ARR_PLAN");

                if (temp == "NA")
                {
                    sArrPlanStartTime = temp;
                }
                else
                {
                    sArrPlanStartTime = temp.Substring(8, 2) + ":" + temp.Substring(10, 2) + " " + temp.Substring(6, 2) + "-" + temp.Substring(4, 2) + "-" + temp.Substring(0, 4);
                }


                out_node.SetString("NOMAL", "GOOD");
                out_node.SetString("LAST_TRAN_TIME", sLastTranTime);
                out_node.SetString("DPT_PLAN", sDptPlanStartTime);
                out_node.SetString("ARR_PLAN", sArrPlanStartTime);
                out_node.SetString("LOT_CMF_6", MPCF.Trim(txtLotID.Text));

                s_history_lot_id = out_node.GetString("LOT_ID");
                s_order_id = out_node.GetString("LOT_CMF_3");
                s_line_id = out_node.GetString("LOT_CMF_6");
                s_oper_code = out_node.GetString("OPER");
                s_qty_1 = out_node.GetDouble("QTY_1");
                s_tran_code = out_node.GetString("NOMAL");

                udcScreen.InitFlexibleScreen();
                if (udcScreen.LoadDesign("TransferSheet") == false)
                    return;
                if (udcScreen.SetDataToScreen(out_node) == false)
                    return;

                // CHILD_LOT_ID

                sChildLotId = out_node.GetString("CHILD_LOT_ID");
                out_node.SetString("LOT_ID", sChildLotId);

                dQty = out_node.GetDouble("CHILD_LOT_QTY");
                out_node.SetDouble("QTY_1", dQty);
                out_node.SetString("NOMAL", "NG");
                out_node.SetString("LAST_TRAN_TIME", sLastTranTime);
                out_node.SetString("DPT_PLAN", sDptPlanStartTime);
                out_node.SetString("ARR_OPER", "REPAIR");
                out_node.SetString("ARR_OPER_DESC", "");
                out_node.SetString("ARR_PLAN", "");
                out_node.SetString("LOT_CMF_6", MPCF.Trim(txtLotID.Text));

                s_history_lot_id = out_node.GetString("LOT_ID");
                s_order_id = out_node.GetString("LOT_CMF_3");
                s_line_id = out_node.GetString("LOT_CMF_6");
                s_oper_code = out_node.GetString("OPER");
                s_qty_1 = out_node.GetDouble("QTY_1");
                s_tran_code = out_node.GetString("NOMAL");

                udcScreenLoss.InitFlexibleScreen();
                if (udcScreenLoss.LoadDesign("TransferSheet") == false)
                    return;
                if (udcScreenLoss.SetDataToScreen(out_node) == false)
                    return;
            }
        }
  

        private void cdvPrinter_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                cdvPrinter.Init();

                cdvPrinter.Text = e.SelectedItem.SubItems[0].Text;
                cdvPrinter.DescText = e.SelectedItem.SubItems[0].Text;
                sDefaultPrintName = e.SelectedItem.SubItems[0].Text;

                MPCF.SaveRegSetting(this.Name, "Settings", "SAVE_PRINT_NAME", sDefaultPrintName);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("Function : cdvPrinter_SelectedItemChanged()\n" + ex.Message);
            }

        }

        private void cdvPrinter_ButtonPress(object sender, EventArgs e)
        {
            ListViewItem itmX;

            try
            {
                cdvPrinter.Init();
                MPCF.InitListView(cdvPrinter.GetListView);
                cdvPrinter.Columns.Add("_ID", 50, System.Windows.Forms.HorizontalAlignment.Left);
                cdvPrinter.SelectedSubItemIndex = 0;
                cdvPrinter.DisplaySubItemIndex = 1;

                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    itmX = new ListViewItem(printer.ToString());
                    this.cdvPrinter.Items.Add(itmX);

                    PrinterSettings p = new PrinterSettings();
                    p.PrinterName = printer;

                    if (p.IsDefaultPrinter)
                    {
                        sDefaultPrintName = cdvPrinter.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("Function : cdvPrinter_SelectedItemChanged()\n" + ex.Message);
            }
        }

        private void btnProcess_1_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (string.IsNullOrEmpty(MPCF.Trim(cdvPrinter.Text)) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(471));
                    return;
                }


                if (sChildLotId == "")
                {
                    udcScreen.ScreenSpread.ActiveSheet.PrintInfo.Printer = MPCF.Trim(cdvPrinter.Text);
                    udcScreen.ScreenSpread.ActiveSheet.PrintInfo.ShowBorder = true;
                    udcScreen.ScreenSpread.PrintSheet(0);
                }
                else
                {
                    udcScreen.ScreenSpread.ActiveSheet.PrintInfo.Printer = MPCF.Trim(cdvPrinter.Text);
                    udcScreen.ScreenSpread.PrintSheet(0);

                    udcScreenLoss.ScreenSpread.ActiveSheet.PrintInfo.Printer = MPCF.Trim(cdvPrinter.Text);
                    udcScreenLoss.ScreenSpread.PrintSheet(0);
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
