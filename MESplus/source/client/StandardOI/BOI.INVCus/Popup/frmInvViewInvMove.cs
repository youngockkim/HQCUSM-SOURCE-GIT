using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using BOI.OIFrx;
using SOI.DNM;
using BOI.OIFrx.Popup;

namespace BOI.INVCus.Popup
{
    public partial class frmInvViewInvMove : frmPopupBase
    {
        private enum INV_LOT_COL
        {
            MAT_ID = 0,
            MAT_DESC,
            MAT_GRP_1,
            MAT_GRP_2,
            MAT_GRP_3
        }
        public string OUT_MAT_ID = "";
        public string OUT_MAT_DESC = "";
        private string sDefaultPrintName = string.Empty;
        System.ComponentModel.ComponentResourceManager resources_1 = new System.ComponentModel.ComponentResourceManager(typeof(frmInvViewInvMove));
            
        public frmInvViewInvMove()
        {
            InitializeComponent();
            cdvPrinter.Text = MPCF.GetRegSetting(Application.ProductName, "Settings", "SAVE_PRINT_NAME", " ");
        }

        public frmInvViewInvMove(string sRequeseNo)
        {
            InitializeComponent();

            if (MPCF.Trim(sRequeseNo) == "")
            {
                cdvPrinter.Text = MPCF.GetRegSetting(Application.ProductName, "Settings", "SAVE_PRINT_NAME", " ");
            }
            else
            {
                txtRequestNo.Text = MPCF.Trim(sRequeseNo);
                ViewMatList();
                cdvPrinter.Text = MPCF.GetRegSetting(Application.ProductName, "Settings", "SAVE_PRINT_NAME", " ");
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                   

                    case "CATEGORY_2":
                        //Category 1
                        

                        break;

                    case "CATEGORY_3":
                        //Category 1
                        

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

        public FarPoint.Win.Spread.SheetView CopySheet(FarPoint.Win.Spread.SheetView sheet)
        {
            FarPoint.Win.Spread.SheetView newSheet = null;
            if (sheet != null)
            {
                newSheet = (FarPoint.Win.Spread.SheetView)FarPoint.Win.Serializer.LoadObjectXml(sheet.GetType(), FarPoint.Win.Serializer.GetObjectXml(sheet, "CopySheet"), "CopySheet");
            }
            return newSheet;
        }

        //View Inventory Lot History
        private bool ViewMatList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_LIST_OUT");
                int x = 0;
                int y = 0;
                int count = 0;
                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.Factory = MPGV.gsFactory;
                in_node.AddString("INV_REQ_NO", MPCF.Trim(txtRequestNo.Text));
                //in_node.AddString("REQ_TYPE", MPCF.Trim(BIGC.B_REQ_TYPE_DISPENSE));

           
                if (MPCF.CallService("BINV", "BINV_View_Request_Data", in_node, ref out_node) == false)
                {
                    return false;
                }
                for (int iCol = 0; iCol < spdRequest.ActiveSheet.ColumnCount; iCol++)
                {
                    for (int jCol = 0; jCol < spdRequest.ActiveSheet.RowCount; jCol++)
                    {

                        for (int k = 0; k < out_node.MemberCount; k++)
                        {
                            if (out_node.Members[k].ValueType == TRSDataType.String)
                            {
                                spdRequest.ActiveSheet.Cells[jCol, iCol].Text = spdRequest.ActiveSheet.Cells[jCol, iCol].Text.Replace(out_node.Members[k].Name, out_node.GetString(out_node.Members[k].Name));

                            }
                            else if (out_node.Members[k].ValueType == TRSDataType.Double)
                            {
                                spdRequest.ActiveSheet.Cells[jCol, iCol].Text = spdRequest.ActiveSheet.Cells[jCol, iCol].Text.Replace(out_node.Members[k].Name, out_node.GetDouble(out_node.Members[k].Name).ToString());
                            }
                        }
                    }
                }
                count = out_node.GetList(0).Count / 21;
                for (int j = 0; j <= count; j++)
                {
                    if (count > 0)
                    {
                        FarPoint.Win.Spread.SheetView sv_2 = new FarPoint.Win.Spread.SheetView();
                        sv_2 = CopySheet(spdRequest.Sheets[0]);
                        sv_2.SheetName = "Request" + "_" + (j + 1).ToString();
                        spdRequest.Sheets.Add(sv_2);
                    }
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        spdRequest.Sheets[j].Cells[11 + i, 1].Value = i + 1;
                        spdRequest.Sheets[j].Cells[11 + i, 2].Value = out_node.GetList(0)[i].GetString("LOT_CMF_1");
                        spdRequest.Sheets[j].Cells[11 + i, 4].Value = out_node.GetList(0)[i].GetString("LOT_CMF_2");
                        spdRequest.Sheets[j].Cells[11 + i, 5].Value = out_node.GetList(0)[i].GetString("LOT_CMF_3");
                        spdRequest.Sheets[j].Cells[11 + i, 7].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        spdRequest.Sheets[j].Cells[11 + i, 9].Value = out_node.GetList(0)[i].GetString("LOT_CMF_4");
                        spdRequest.Sheets[j].Cells[11 + i, 12].Value = out_node.GetList(0)[i].GetString("LOT_CMF_5");
                        spdRequest.Sheets[j].Cells[11 + i, 13].Value = out_node.GetList(0)[i].GetDouble("CREATE_QTY_2");
                        spdRequest.Sheets[j].Cells[11 + i, 14].Value = MPCF.ToInt(out_node.GetList(0)[i].GetDouble("CREATE_QTY_3"));

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

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ViewMatList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMatDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    ViewMatList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.FpSpread spdprint = new FarPoint.Win.Spread.FpSpread();
                spdRequest.Save(Application.StartupPath + "\\temp.xml", false);
                spdprint.Open(Application.StartupPath + "\\temp.xml");

                //print_info_set
                FarPoint.Win.Spread.PrintInfo print_info = new FarPoint.Win.Spread.PrintInfo();
                print_info = spdRequest.ActiveSheet.PrintInfo;
                print_info.Printer = MPCF.Trim(cdvPrinter.Text);
                
                for (int a = 0; a < spdprint.Sheets.Count; a++)
                {
                    spdprint.Sheets[a].PrintInfo = print_info;
                    spdprint.PrintSheet(a);
                    System.Threading.Thread.Sleep(10);
                }

                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvPrinter_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                MenuInfoTag selectedMenuInfo;
                frmCOMViewPrinterList frm = new frmCOMViewPrinterList();
                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "View Printer List";
                frm.Tag = selectedMenuInfo;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                cdvPrinter.Text = frm.OUT_PRINTER;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }



    }
}
