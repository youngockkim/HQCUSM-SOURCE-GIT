using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;

using SOI.DNM;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx;
using BOI.OIFrx.Popup;
using Miracom.POPCore;
using BOI.OIFrx;

// 포장 파렛 구성(수동)
namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPSingleResultRegistration : BOIBasePopup02
    {

        private Rs232 m_CommPort = new Rs232();

        public frmWIPSingleResultRegistration()
        {
            InitializeComponent();
        }

        #region Property

        public List<string> s_order_list;
        private enum WRKORD
        {
            ORDER_ID,
            ORDER_DATE,
            MAT_ID,
            MAT_DESC,
            BOM_TYPE,
            ORDER_QTY,
            PROD_QTY,
            LINE_ID,
            RES_ID,
            STATUS,
            BOX_PER_PALLET
        }

        private enum PRT
        {
            SEL,
            LOT_ID,
            PRINT_TIME,
            MAT_ID,
            MAT_DESC,
            QTY,
            MANUAL_FLAG
        }

        #endregion

        #region Function

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

        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <param name="s_order_list"></param>
        /// <returns></returns>
        private bool View_Order_List(List<string> s_order_list)
        {
            TRSNode in_node = new TRSNode("View_Order_In");
            TRSNode out_node = new TRSNode("View_Order_Out");

            int i = 0;
            int i_row = 0;

            try
            {
                spdWorkOrder_Sheet1.RowCount = 0;

                for (i = 0; i < s_order_list.Count; i++)
                {
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '2';
                    in_node.AddString("ORDER_ID", s_order_list[i]);

                    if (MPCF.CallService("BWIP", "BWIP_View_Order_List", in_node, ref out_node) == false)
                        return false;

                    //i_row = spdWorkOrder_Sheet1.RowCount;
                    i_row = spdWorkOrder_Sheet1.RowCount++;

                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.ORDER_ID].Value = out_node.GetString("ORDER_ID");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.ORDER_DATE].Value = MPCF.MakeDateFormat(out_node.GetString("ORD_DATE"), DATE_TIME_FORMAT.DATE);
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.MAT_ID].Value = out_node.GetString("MAT_ID");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.MAT_DESC].Value = out_node.GetString("MAT_DESC");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.BOM_TYPE].Value = out_node.GetChar("MAT_BOM_TYPE");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.ORDER_QTY].Value = out_node.GetDouble("ORD_QTY");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.PROD_QTY].Value = out_node.GetDouble("PROD_QTY");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.LINE_ID].Value = out_node.GetString("LINE_DESC");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.LINE_ID].Tag = out_node.GetString("LINE_ID");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.RES_ID].Value = out_node.GetString("RES_DESC");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.RES_ID].Tag = out_node.GetString("RES_ID");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.STATUS].Value = out_node.GetString("ORDER_STATUS_DESC");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.STATUS].Tag = out_node.GetChar("ORDER_STATUS");
                    spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.BOX_PER_PALLET].Value = out_node.GetInt("PACK_LOT_COUNT");
                }

                MPCF.FitColumnHeader(spdWorkOrder);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 데이터의 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool Check_Data()
        {
            int i_row = 0;
            try
            {
                if (MPCF.ToInt(txtBoxQty.Value) == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(111), MSG_LEVEL.ERROR, false);
                    txtBoxQty.Focus();
                    return false;
                }

                if (MPCF.CheckValue(cboShelfLife, 1) == false)
                {
                    cboShelfLife.Focus();
                    return false;
                }

                i_row = spdWorkOrder_Sheet1.ActiveRowIndex;
                if (MPCF.ToInt(spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.BOX_PER_PALLET].Value) < MPCF.ToInt(txtBoxQty.Value))
                {
                    MPCF.ShowMessage(MPCF.GetMessage(463), MSG_LEVEL.ERROR, false);
                    txtBoxQty.Focus();
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowErrorMessage("Check_Data() : " + ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Pallet을 생성한다.
        /// </summary>
        /// <returns></returns>
        private bool Create_Pallet()
        {
            TRSNode in_node = new TRSNode("Create_Pallet_In");
            TRSNode out_node = new TRSNode("Create_Pallet_Out");

            int i_row = 0;

            try
            {
                i_row = spdWorkOrder_Sheet1.ActiveRowIndex;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.ORDER_ID].Value);
                in_node.AddString("MAT_ID", spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.MAT_ID].Value);
                in_node.AddInt("PROD_QTY", MPCF.ToInt(txtBoxQty.Value));
                in_node.AddString("SHELF_LIFE", cboShelfLife.Text.Replace("-", "") + "000000");

                if (MPCF.CallService("BWIP", "BWIP_Package_Performance", in_node,
                    ref out_node) == false)
                    return false;

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

        /// <summary>
        /// Pallet 정보 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Pallet_List()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            int i_row = 0, i = 0;

            try
            {
                spdPalletList_Sheet1.RowCount = 0;
                i_row = spdWorkOrder_Sheet1.ActiveRowIndex;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORDER_ID";
                dvcArgu[1].sCondition_Value = spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.ORDER_ID].Text;

                if (TPDR.GetDataOne("", ref dt, "CWIP8540-001", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdPalletList_Sheet1.RowCount++;

                    spdPalletList_Sheet1.Cells[i, (int)PRT.SEL].Value = false;
                    spdPalletList_Sheet1.Cells[i, (int)PRT.LOT_ID].Value = dt.Rows[i]["LOT_ID"];
                    spdPalletList_Sheet1.Cells[i, (int)PRT.PRINT_TIME].Value = dt.Rows[i]["PRINT_TIME"];
                    spdPalletList_Sheet1.Cells[i, (int)PRT.MAT_ID].Value = dt.Rows[i]["MAT_ID"];
                    spdPalletList_Sheet1.Cells[i, (int)PRT.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"];
                    spdPalletList_Sheet1.Cells[i, (int)PRT.QTY].Value = dt.Rows[i]["QTY_1"];
                    spdPalletList_Sheet1.Cells[i, (int)PRT.MANUAL_FLAG].Value = dt.Rows[i]["MANUAL_FLAG"];
                }

                MPCF.FitColumnHeader(spdPalletList);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowErrorMessage("View_Pallet_List() :" + ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 작업지시의 실적 수량과 박스 누적 수량을 갱신한다.
        /// </summary>
        /// <param name="i_row"></param>
        /// <param name="s_order_id"></param>
        /// <returns></returns>
        private bool View_Order(int i_row, string s_order_id)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;

            try
            {
                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORDER_ID";
                dvcArgu[1].sCondition_Value = s_order_id;

                dvcArgu[2].sCondtion_ID = "OPER";
                dvcArgu[2].sCondition_Value = " ";

                if (TPDR.GetDataOne("", ref dt, "COM0000-010", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.PROD_QTY].Value = dt.Rows[0]["PROD_QTY"];
                txtTotalBoxQty.Value = dt.Rows[0]["PROD_QTY"];
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("" + ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }

            return true;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWIPSingleResultRegistration_Load(object sender, EventArgs e)
        {
            View_Order_List(s_order_list);

            View_Pallet_List();

            if (spdWorkOrder_Sheet1.RowCount > 0)
            {
                BICF.View_Shelf_Life(spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.ORDER_ID].Text, cboShelfLife);
                txtTotalBoxQty.Value = spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.PROD_QTY].Value;
            }
        }

        private void btnCreatePallet_Click(object sender, EventArgs e)
        {
            int i_row = 0;

            if (Check_Data())
            {
                if (Create_Pallet())
                {
                    View_Pallet_List();
                    i_row = spdWorkOrder_Sheet1.ActiveRowIndex;
                    View_Order(i_row, spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.ORDER_ID].Text);
                }
            }
        }

        private void btnRePrint_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                for (i = 0; i < spdPalletList_Sheet1.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdPalletList_Sheet1.Cells[i, (int)PRT.SEL].Value))
                    {
                        if (Tran_Print_Label(MPCF.Trim(spdPalletList_Sheet1.Cells[i, (int)PRT.LOT_ID].Value), 'Y') == false)
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View_Order_List(s_order_list);
            View_Pallet_List();
            if (spdWorkOrder_Sheet1.RowCount > 0)
                txtTotalBoxQty.Value = spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.PROD_QTY].Value;
        }

        private void spdWorkOrder_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (spdWorkOrder_Sheet1.RowCount > 0)
            {
                BICF.View_Shelf_Life(spdWorkOrder_Sheet1.Cells[e.Range.Row, (int)WRKORD.ORDER_ID].Text, cboShelfLife);
                cboShelfLife.SelectedIndex = cboShelfLife.Items.Count > 0 ? 1 : -1;
                txtTotalBoxQty.Value = spdWorkOrder_Sheet1.Cells[e.Range.Row, (int)WRKORD.PROD_QTY].Value;
                View_Pallet_List();
            }
        }

        #endregion
    }
}
