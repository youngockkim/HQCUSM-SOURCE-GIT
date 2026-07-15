using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.CliFrx;
using SOI.OIFrx;
using SOI.DNM;
using SOI.MsgHandlerH101;

using BOI.OIFrx;
using Infragistics.Win;
using BOI.OIFrx.Popup;
using Miracom.POPCore;

// 성형 실적
namespace BOI.WIPCus
{
    public partial class frmWIPTranMoldPerformance : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        private Rs232 m_CommPort = new Rs232();
        private string s_lot_id = "";
        public frmWIPTranMoldPerformance()
        {
            InitializeComponent();
        }

        public frmWIPTranMoldPerformance(string sOrder)
        {
            InitializeComponent();
            ViewOrder(sOrder);
        }

        private enum ORD
        {
            ORDER_ID,
            ORD_DATE,
            MAT_ID,
            MAT_DESC,
            BOM_TYPE,
            ORD_QTY,
            RLT_QTY,
            UNIT,
            LINE,
            RES_ID
        }

        private enum LOT
        {
            ORDER_ID,
            LOT_ID,
            MAT_ID,
            MAT_DESC,
            QTY,
            UNIT,
            CREATE_TIME
        }

        /// <summary>
        /// 데이터 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool Check_Data()
        {
            try
            {
                if (spdWorkOrder_Sheet1.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(410), MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (cdvPackageType.Text == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (MPCF.ToInt(numProductQty.Value) == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.ERROR, false);
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Check_Data() : " + ex.Message, MSG_LEVEL.ERROR, false);
            }

            return true;
        }

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
                in_node.ProcStep = '2';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("SCREEN_ID", BIGC.B_LABEL_LB002);
                in_node.AddChar("PRINT_HIS_FLAG", c_manual_flag); //성형공병은 랏 생성시 이력 쌓음
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
        /// 성형 실적 처리
        /// </summary>
        /// <returns></returns>
        private bool Mold_Performance()
        {
            TRSNode in_node = new TRSNode("Mold_Performance_In");
            TRSNode out_node = new TRSNode("Mold_Performance_Out");
            int i_row = 0;

            try
            {
                i_row = spdWorkOrder_Sheet1.ActiveRowIndex;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", spdWorkOrder_Sheet1.Cells[i_row, (int)ORD.ORDER_ID].Value);
                in_node.AddString("MAT_ID", spdWorkOrder_Sheet1.Cells[i_row, (int)ORD.MAT_ID].Value);
                in_node.AddInt("PROD_QTY", MPCF.ToInt(numProductQty.Value));

                if (MPCF.CallService("BWIP", "BWIP_Mold_Performance", in_node, ref out_node) == false)
                    return false;

                Tran_Print_Label(out_node.GetString("LOT_ID"), ' ');

                MPCF.ShowSuccessMessage(out_node, false);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Mold_Performance() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewOrder(string sOrder)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {
                spdWorkOrder_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORDER_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sOrder);


                if (TPDR.GetDataOne("", ref dt, "CWIP8030-001", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdWorkOrder_Sheet1.RowCount++;
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORDER_ID].Value = dt.Rows[i][1].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORD_DATE].Value = dt.Rows[i][0].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.MAT_ID].Value = dt.Rows[i][2].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.MAT_DESC].Value = dt.Rows[i][3].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.BOM_TYPE].Value = dt.Rows[i][19].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORD_QTY].Value = dt.Rows[i][4].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.RLT_QTY].Value = dt.Rows[i][5].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.UNIT].Value = dt.Rows[i][6].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.LINE].Value = dt.Rows[i][7].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.LINE].Tag = dt.Rows[i][12].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.RES_ID].Value = dt.Rows[i][8].ToString();
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.RES_ID].Tag = dt.Rows[i][13].ToString();

                }
                if (spdWorkOrder_Sheet1.RowCount > 0)
                    View_production_Performance(spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORDER_ID].Text);
                else
                    spdLotList_Sheet1.RowCount = 0;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 작업지시를 기준으로 생산 실적을 조회
        /// </summary>
        /// <param name="s_order_id"></param>
        /// <returns></returns>
        private bool View_production_Performance(string s_order_id)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORDER_ID";
                dvcArgu[1].sCondition_Value = s_order_id;

                if (TPDR.DirectViewOne(spdLotList, "CWIP2403-001", ref dt, false, false, dvcArgu, true, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    spdLotList_Sheet1.RowCount = 0;

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < spdLotList_Sheet1.ColumnCount; i++)
                {
                    spdLotList_Sheet1.Columns[i].Locked = true;
                    spdLotList_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdLotList_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                }

                spdLotList_Sheet1.Columns[(int)LOT.MAT_DESC].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                spdLotList_Sheet1.Columns[(int)LOT.QTY].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("" + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 성형의 실적 조회
        /// </summary>
        /// <returns></returns>
        private bool View_production_results()
        {
            TRSNode in_node = new TRSNode("View_Production_In");
            TRSNode out_node = new TRSNode("View_Production_Out");

            try
            {
                if (cbShift.SelectedItem == null)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(435), MSG_LEVEL.ERROR, false);
                    return false;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("WORK_DATE", dtDate.GetValueAsDateTime().ToString("yyyyMMdd"));
                in_node.AddString("WORK_SHIFT", cbShift.SelectedItem.DataValue);
                in_node.AddString("CTU", chkPrint.Checked ? "CTU" : ""); // 상컵
                in_node.AddString("CBU", chkBottom.Checked ? "CBU" : ""); // 하컵
                in_node.AddString("CTP", chkUnprint.Checked ? "CTP" : ""); // 무인쇄 상컵

                if (MPCF.CallService("BWIP", "BWIP_View_Production_Results", in_node, ref out_node) == false)
                    return false;

                numPlanQty.Value = out_node.GetDouble("PLAN_QTY");
                numResult.Value = out_node.GetDouble("RESULT_QTY");
                numRemain.Value = out_node.GetDouble("REMAIN_QTY");

                MPCF.ShowMessageClear();
            }
            catch (System.Exception ex)
            {
            	MPCF.ShowMessage("" + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 작업조 가져오기
        /// </summary>
        /// <returns></returns>
        private bool Get_work_shift()
        {
            TRSNode in_node = new TRSNode("View_GCM_In");
            TRSNode out_node = new TRSNode("View_GCM_Out");

            ValueListItem itemx;                

            int i = 0;
 
            try
            {
                cbShift.Clear();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "B_WORK_SHIFT");

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                    return false;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itemx = new ValueListItem(out_node.GetList(0)[i].GetString("KEY_1"), out_node.GetList(0)[i].GetString("DATA_1"));
                    cbShift.Items.Add(itemx);
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("" + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void cdvPackageType_CodeViewButtonClick(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            dvcArgu[0].sCondtion_ID = "FACTORY";
            dvcArgu[0].sCondition_Value = MPGV.gsFactory;

            dvcArgu[1].sCondtion_ID = "TABLE_NAME";
            dvcArgu[1].sCondition_Value = "B_PACK_TYPE";

            string[] header = new string[] { "Pack Type", "Pack Type Desc", "Quantity" };

            // CodeView Display Column Setup
            string[] display = new string[] { "KEY_1", "DATA_1", "DATA_2" };

            // Show
            cdvPackageType.Text = cdvPackageType.Show(cdvPackageType, "Pack Type", "COM0000-001", dvcArgu, display, header, "DATA_1", -1);
            cdvPackageType.Tag = "";
            if (MPCF.Trim(cdvPackageType.Text) != "")
            {
                if (cdvPackageType.returnDatas.Count > 0)
                {
                    cdvPackageType.Tag = cdvPackageType.returnDatas[0];
                    numProductQty.Value = MPCF.ToInt(cdvPackageType.returnDatas[2]) * MPCF.ToInt(numBoxQty.Value);
                    numProductQty.Tag = MPCF.ToInt(cdvPackageType.returnDatas[2]);
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!Check_Data())
                return;

            if(Mold_Performance())
                View_production_Performance(spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORDER_ID].Text);
        }

        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            frmWIPViewWorkOrderList form = new frmWIPViewWorkOrderList();
            int i = 0;

            form.s_mold_pack_flag = "Y";

            if (form.ShowDialog() == DialogResult.OK)
            {
                spdWorkOrder_Sheet1.RowCount = 0;
                spdWorkOrder_Sheet1.RowCount++;
                i = form.mspdWorkOrder.ActiveRowIndex;

                spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORDER_ID].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_ID].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORD_DATE].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_DATE].Value; ;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.MAT_ID].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.MAT_ID].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.MAT_DESC].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.MAT_DESC].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.BOM_TYPE].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.BOM_TYPE].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORD_QTY].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_QTY].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.RLT_QTY].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RLT_QTY].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.UNIT].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.UNIT].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.LINE].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.LINE_ID].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.LINE].Tag = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.LINE_ID].Tag;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.RES_ID].Value = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RES_ID].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)ORD.RES_ID].Tag = form.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RES_ID].Tag;

                if (spdWorkOrder_Sheet1.RowCount > 0)
                    View_production_Performance(spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORDER_ID].Text);
                else
                    spdLotList_Sheet1.RowCount = 0;
            }
        }

        private void btnBom_Click(object sender, EventArgs e)
        {
            if (spdWorkOrder_Sheet1.RowCount > 0)
            {
                frmWIPViewBomListPopup form = null;
                int i_row = spdWorkOrder_Sheet1.ActiveRowIndex;

                form = new frmWIPViewBomListPopup();
                form.ms_p_mat_id = MPCF.Trim(spdWorkOrder_Sheet1.Cells[i_row, (int)ORD.MAT_ID].Value);
                form.ms_mat_bom_type = MPCF.Trim(spdWorkOrder_Sheet1.Cells[i_row, (int)ORD.BOM_TYPE].Value);

                form.ShowDialog();
            }
        }

        private void spdWorkOrder_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (spdWorkOrder_Sheet1.RowCount > 0)
                View_production_Performance(spdWorkOrder_Sheet1.Cells[e.Range.Row, (int)ORD.ORDER_ID].Text);
        }

        private void frmWIPTranMoldPerformance_Load(object sender, EventArgs e)
        {
            dtDate.Value = DateTime.Today;
            Get_work_shift();
        }

        private void numBoxQty_ValueChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(numProductQty.Tag) && MPCF.ToInt(numBoxQty.Value) > 0)
            {
                numProductQty.Value = MPCF.ToInt(numProductQty.Tag) * MPCF.ToInt(numBoxQty.Value);
            }
        }

        private void numBoxQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //numProductQty.Focus();
            }
        }

        private void chkBottom_CheckedChanged(object sender, EventArgs e)
        {
            View_production_results();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            View_production_results();
        }
        
        private void btnRePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdLotList_Sheet1.RowCount > 0)
                {
                    s_lot_id = MPCF.Trim(spdLotList.ActiveSheet.Cells[spdLotList_Sheet1.ActiveRowIndex, (int)LOT.LOT_ID].Text);
                    if (Tran_Print_Label(MPCF.Trim(s_lot_id), 'Y') == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

    }
}
