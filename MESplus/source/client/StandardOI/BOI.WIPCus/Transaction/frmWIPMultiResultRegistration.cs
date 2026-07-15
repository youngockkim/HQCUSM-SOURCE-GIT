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


namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPMultiResultRegistration : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        BOI.OIFrx.BOIControls.H101Tuner ResTuner1 = null;
        BOI.OIFrx.BOIControls.H101Tuner ResTuner2 = null;
        BOI.OIFrx.BOIControls.H101Tuner ResTuner3 = null;
        BOI.OIFrx.BOIControls.H101Tuner ResTuner4 = null;

        #endregion

        public delegate void ResourceReceivedHandler(TRSNode node);
        ResourceReceivedHandler resRecvHandler1;
        ResourceReceivedHandler resRecvHandler2;
        ResourceReceivedHandler resRecvHandler3;
        ResourceReceivedHandler resRecvHandler4;

        #region Constructor

        public frmWIPMultiResultRegistration()
        {
            InitializeComponent();
        }

        private Rs232 m_CommPort = new Rs232();

        #endregion

        private bool Tran_Print_Label(string sLotID, char c_manual_flag)
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
                in_node.ProcStep = '3';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("SCREEN_ID", BIGC.B_LABEL_LB001);
                in_node.AddChar("PRINT_HIS_FLAG", c_manual_flag); //포장은 랏 생성시 이력 쌓음
                in_node.AddChar("MANUAL_FLAG", c_manual_flag);

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

        private bool Create_Pallet(BOI.WIPCus.Controls.BOIPallet pltProd)
        {
            TRSNode in_node = new TRSNode("Create_Pallet_In");
            TRSNode out_node = new TRSNode("Create_Pallet_Out");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", pltProd.OrderID);
                in_node.AddString("MAT_ID", pltProd.MatID);
                in_node.AddInt("PROD_QTY", pltProd.ProdQty);
                in_node.AddString("SHELF_LIFE", pltProd.ShelfDate.Replace("-", "") + "000000");
                in_node.AddChar("AUTO_FLAG", 'Y');
                in_node.AddString("COUNTER_ID", pltProd.CounterID);

                if (MPCF.CallService("BWIP", "BWIP_Package_Performance", in_node, ref out_node) == false)
                    return false;

                pltProd.BoxQty = out_node.GetInt("PROD_QTY") / pltProd.BoxPerPallet;

                Tran_Print_Label(out_node.GetString("LOT_ID"), ' ');

                MPCF.ShowSuccessMessage(out_node, false);

            }
            catch (System.Exception ex)
            {
                MPCF.ShowErrorMessage("Create_Pallet() : " + ex.Message);
                return false;
            }

            return true;
        }

        private bool Check_Data(BOI.WIPCus.Controls.BOIPallet pltProd)
        {
            if (pltProd.OrderID == "")
            {
                MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, true);
                return false;
            }

            if (pltProd.ShelfDate == "")
            {
                // CMN475 ERROR - 유통기간을 선택하세요.
                MPCF.ShowMessage(MPCF.GetMessage(475), MSG_LEVEL.ERROR, true);
                return false;
            }

            if (pltProd.ProdQty == 0)
            {
                // CMN474 ERROR - 실적 수량이 0입니다. 츨력을 할 수 없습니다.
                MPCF.ShowMessage(MPCF.GetMessage(474), MSG_LEVEL.ERROR, true);
                return false;
            }

            return true;
        }

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

            ResTuner1 = new BOI.OIFrx.BOIControls.H101Tuner();
            ResTuner2 = new BOI.OIFrx.BOIControls.H101Tuner();
            ResTuner3 = new BOI.OIFrx.BOIControls.H101Tuner();
            ResTuner4 = new BOI.OIFrx.BOIControls.H101Tuner();

            ResTuner1.DataReceived += new BOI.OIFrx.BOIControls.H101DataReceivedEventHandler(ResTuner1_DataReceived);
            ResTuner2.DataReceived += new BOI.OIFrx.BOIControls.H101DataReceivedEventHandler(ResTuner2_DataReceived);
            ResTuner3.DataReceived += new BOI.OIFrx.BOIControls.H101DataReceivedEventHandler(ResTuner3_DataReceived);
            ResTuner4.DataReceived += new BOI.OIFrx.BOIControls.H101DataReceivedEventHandler(ResTuner4_DataReceived);

            resRecvHandler1 = new ResourceReceivedHandler(resRecvResult1);
            resRecvHandler2 = new ResourceReceivedHandler(resRecvResult2);
            resRecvHandler3 = new ResourceReceivedHandler(resRecvResult3);
            resRecvHandler4 = new ResourceReceivedHandler(resRecvResult4);
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

        private void setTuner(BOI.WIPCus.Controls.BOIPallet pltProd,  BOI.OIFrx.BOIControls.H101Tuner resTuner)
        {
            if (pltProd.OrderID != "" && pltProd.CounterID != "" && pltProd.ShelfDate != "")
            {
                if (resTuner.Module != pltProd.CounterID)
                {
                    if (resTuner.isTuned)
                        resTuner.PublishCUSMsgUnTune();

                    resTuner.Module = pltProd.CounterID;
                    resTuner.Channel = pltProd.CounterID;
                    resTuner.MultiCast = false;
                    resTuner.ServiceName = "BEIS_EQInterface_Pack_Result";
                    resTuner.PublishCUSMsgTune();
                }
                else if (!resTuner.isTuned)
                {
                    resTuner.Module = pltProd.CounterID;
                    resTuner.Channel = pltProd.CounterID;
                    resTuner.MultiCast = false;
                    resTuner.ServiceName = "BEIS_EQInterface_Pack_Result";
                    resTuner.PublishCUSMsgTune();
                }
            }
            else
            {
                if (resTuner.isTuned)
                    resTuner.PublishCUSMsgUnTune();
            }
        }

        private bool DisplayQty(TRSNode node, BOI.WIPCus.Controls.BOIPallet pltProd)
        {
            try
            {
                pltProd.CumProdQty += 1;
                pltProd.ProdQty = node.GetInt("PROD_QTY");
                if (pltProd.ProdQty == pltProd.BoxPerPallet)
                {
                    Create_Pallet(pltProd);
                    pltProd.ProdQty = 0;
                    pltProd.BoxQty = pltProd.CumProdQty / pltProd.BoxPerPallet;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        private void ResTuner1_DataReceived(object sender, BOI.OIFrx.BOIControls.H101DataReceivedEventArgs e)
        {
            IAsyncResult result = BeginInvoke(resRecvHandler1, e.Node);
            EndInvoke(result);
        }

        private void resRecvResult1(TRSNode node)
        {
            try
            {
                DisplayQty(node, pltProd1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ResTuner1_DataReceived()\n" + ex.Message);
                return;
            }
        }

        private void ResTuner2_DataReceived(object sender, BOI.OIFrx.BOIControls.H101DataReceivedEventArgs e)
        {
            IAsyncResult result = BeginInvoke(resRecvHandler2, e.Node);
            EndInvoke(result);
        }

        private void resRecvResult2(TRSNode node)
        {
            try
            {
                DisplayQty(node, pltProd2);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ResTuner2_DataReceived()\n" + ex.Message);
                return;
            }
        }

        private void ResTuner3_DataReceived(object sender, BOI.OIFrx.BOIControls.H101DataReceivedEventArgs e)
        {
            IAsyncResult result = BeginInvoke(resRecvHandler3, e.Node);
            EndInvoke(result);
        }

        private void resRecvResult3(TRSNode node)
        {
            try
            {
                DisplayQty(node, pltProd3);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ResTuner3_DataReceived()\n" + ex.Message);
                return;
            }
        }

        private void ResTuner4_DataReceived(object sender, BOI.OIFrx.BOIControls.H101DataReceivedEventArgs e)
        {
            IAsyncResult result = BeginInvoke(resRecvHandler4, e.Node);
            EndInvoke(result);
        }

        private void resRecvResult4(TRSNode node)
        {
            try
            {
                DisplayQty(node, pltProd4);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ResTuner4_DataReceived()\n" + ex.Message);
                return;
            }
        }

        private void pltProd1_CounterChanged(object sender, EventArgs e)
        {
            txtCounter1.Text = pltProd1.CounterDesc;

            setTuner(pltProd1, ResTuner1);
        }

        private void pltProd2_CounterChanged(object sender, EventArgs e)
        {
            txtCounter2.Text = pltProd2.CounterDesc;
            setTuner(pltProd2, ResTuner2);
        }

        private void pltProd3_CounterChanged(object sender, EventArgs e)
        {
            txtCounter3.Text = pltProd3.CounterDesc;
            setTuner(pltProd3, ResTuner3);
        }

        private void pltProd4_CounterChanged(object sender, EventArgs e)
        {
            txtCounter4.Text = pltProd4.CounterDesc;
            setTuner(pltProd4, ResTuner4);
        }

        private void frmWIPMultiResultRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ResTuner1.isTuned)
                ResTuner1.Dispose();

            if (ResTuner2.isTuned)
                ResTuner2.Dispose();

            if (ResTuner3.isTuned)
                ResTuner3.Dispose();

            if (ResTuner4.isTuned)
                ResTuner4.Dispose();
        }

        private void pltProd1_ShelfChanged(object sender, EventArgs e)
        {
            setTuner(pltProd1, ResTuner1);
        }

        private void pltProd2_ShelfChanged(object sender, EventArgs e)
        {
            setTuner(pltProd2, ResTuner2);
        }

        private void pltProd3_ShelfChanged(object sender, EventArgs e)
        {
            setTuner(pltProd3, ResTuner3);
        }

        private void pltProd4_ShelfChanged(object sender, EventArgs e)
        {
            setTuner(pltProd4, ResTuner4);
        }

        private void pltProd1_OrderChanging(object sender, EventArgs e)
        {
            if (pltProd1.CounterID != "")
                ResTuner1.PublishCUSMsgUnTune();

            txtCounter1.Clear();
        }

        private void pltProd2_OrderChanging(object sender, EventArgs e)
        {
            if (pltProd2.CounterID != "")
                setTuner(pltProd2, ResTuner2);
        }

        private void pltProd3_OrderChanging(object sender, EventArgs e)
        {
            if (pltProd3.CounterID != "")
                setTuner(pltProd3, ResTuner3);
        }

        private void pltProd4_OrderChanging(object sender, EventArgs e)
        {
            if (pltProd4.CounterID != "")
                setTuner(pltProd4, ResTuner4);
        }

        private void pltProd1_PrintStart(object sender, EventArgs e)
        {
            if (!Check_Data(pltProd1))
                return;

            Create_Pallet(pltProd1);
        }

        private void pltProd2_PrintStart(object sender, EventArgs e)
        {
            if (!Check_Data(pltProd2))
                return;

            Create_Pallet(pltProd2);
        }

        private void pltProd3_PrintStart(object sender, EventArgs e)
        {
            if (!Check_Data(pltProd3))
                return;

            Create_Pallet(pltProd3);
        }

        private void pltProd4_PrintStart(object sender, EventArgs e)
        {
            if (!Check_Data(pltProd4))
                return;

            Create_Pallet(pltProd4);
        }
    }
}
