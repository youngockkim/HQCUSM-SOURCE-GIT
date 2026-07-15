using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using System.Collections;

namespace BOI.OIFrx.Popup
{
    public partial class frmCOMViewPrinterList : frmPopupBase
    {
        public frmCOMViewPrinterList()
        {
            InitializeComponent();
            ViewPrinterList();
        }
        private string sDefaultPrintName = "";
        public string OUT_PRINTER = "";
        
        private bool ViewPrinterList()
        {
            try
            {
                int i = 0;
                spdPrinterList.ActiveSheet.Rows.Count = 0;
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    spdPrinterList.ActiveSheet.AddRows(i, 1);
                    spdPrinterList.ActiveSheet.Cells[i, 0].Text = printer.ToString();

                    PrinterSettings p = new PrinterSettings();
                    p.PrinterName = printer;

                    if (p.IsDefaultPrinter)
                    {
                        sDefaultPrintName = printer.ToString();
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            ViewPrinterList();
        }

        private void spdPrinterList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (spdPrinterList.Sheets[0].RowCount <= 0 || e.ColumnHeader == true)
                return;
            OUT_PRINTER = MPCF.Trim(spdPrinterList.ActiveSheet.Cells[e.Row, 0].Text);
            sDefaultPrintName = MPCF.Trim(spdPrinterList.ActiveSheet.Cells[e.Row, 0].Text);
            MPCF.SaveRegSetting(Application.ProductName, "Settings", "SAVE_PRINT_NAME", sDefaultPrintName);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
