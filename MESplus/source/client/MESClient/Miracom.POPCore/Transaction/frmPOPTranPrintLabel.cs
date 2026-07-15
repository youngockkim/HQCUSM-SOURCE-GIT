using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.POPCore
{
    public partial class frmPOPTranPrintLabel : TranForm02
    {
        public frmPOPTranPrintLabel()
        {
            InitializeComponent();
        }


        #region "Constant Defintion"

        #endregion

        #region "Variable Definition"

        private bool b_load_flag;

        #endregion

        #region "Function Definition"

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        private bool ViewLotInfo(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            if (s_lot_id == "") return false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", s_lot_id);

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }


            udcScreen.InitFlexibleScreen();
            if (udcScreen.LoadDesign("LabelSample") == false) return false;
            if (udcScreen.SetDataToScreen(out_node) == false) return false;

            return true;
        }

        private void SetPrinterList()
        {
            ListViewItem itmX;

            try
            {
                cdvPrinter.Init();
                MPCF.InitListView(cdvPrinter.GetListView);
                cdvPrinter.Columns.Add("Printer", 50, System.Windows.Forms.HorizontalAlignment.Left);
                cdvPrinter.SelectedSubItemIndex = 0;

                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    itmX = new ListViewItem(printer.ToString());
                    this.cdvPrinter.Items.Add(itmX);

                    PrinterSettings p = new PrinterSettings();
                    p.PrinterName = printer;

                    if (p.IsDefaultPrinter)
                    {
                        cdvPrinter.Text = printer;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("Function : SetPrinterList()\n" + ex.Message);
            }
        }



        #endregion

        private void frmPOPTranPrintLabel_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                cdvPrinter.Text = MPCF.GetRegSetting(this.Name, "Settings", "SAVE_PRINT_NAME");
                if (MPCF.Trim(cdvPrinter.Text) == "")
                {
                    SetPrinterList();
                }

                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                }

                b_load_flag = true;
            }
        }

        private void frmPOPTranPrintLabel_FormClosing(object sender, FormClosingEventArgs e)
        {
            MPCF.SaveRegSetting(this.Name, "Settings", "SAVE_PRINT_NAME", cdvPrinter.Text);
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ViewLotInfo(MPCF.Trim(txtLotID.Text));
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtLotID, 1) == false) return;
            if (MPCF.CheckValue(cdvPrinter, 1) == false) return;

            if (numAngle.Value == 0)
            {
                udcScreen.ScreenView.PrintInfo.Printer = MPCF.Trim(cdvPrinter.Text);
                udcScreen.ScreenView.PrintInfo.ShowBorder = true;
                udcScreen.ScreenSpread.PrintSheet(0);
            }
            else
            {
                System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
                
                docToPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(docToPrint_PrintPage);
                docToPrint.PrinterSettings.PrinterName = MPCF.Trim(cdvPrinter.Text);
                docToPrint.Print();
            }

            MPCF.ShowMsgBox(MPCF.GetMessage(52));
        }

        private Image ConvertSpread2Image(FarPoint.Win.Spread.FpSpread spdSpread)
        {
            System.Drawing.Rectangle pageRect = new System.Drawing.Rectangle(0, 0, 700, 400);
            int pagecount = spdSpread.GetOwnerPrintPageCount(spdSpread.CreateGraphics(), pageRect, spdSpread.ActiveSheetIndex);

            System.Drawing.Bitmap bmp = new Bitmap(700, 700);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
                //rotate
                g.RotateTransform((float)numAngle.Value);
                //move image back
                g.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
                //GFX.Clear(Color.Transparent);
                g.Clear(System.Drawing.Color.White);
                g.DrawImage(bmp, new Point(0, 0));
                spdSpread.OwnerPrintDraw(g, pageRect, spdSpread.ActiveSheetIndex, pagecount);
                g.Dispose();
            }

            return bmp;
        }
        
        private void docToPrint_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image img = ConvertSpread2Image(udcScreen.ScreenSpread);
            e.Graphics.DrawImage(img, 0, 0);
        }


    
    
    
    
    
    }
}
