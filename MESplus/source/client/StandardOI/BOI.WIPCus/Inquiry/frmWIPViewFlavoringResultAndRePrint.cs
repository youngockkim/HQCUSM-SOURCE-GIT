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
using SOI.DNM;
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
    public partial class frmWIPViewFlavoringResultAndRePrint : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string s_selected_order;

        private Rs232 m_CommPort = new Rs232();

        private enum ORDER
        {
            SEL,
            ORD_DATE,
            ORDER_ID,
            MAT_ID,
            MAT_DESC,
            ORD_QTY,
            PROD_QTY,
            UNIT,
            LINE,
            RES,
            ORD_START_TIME,
            ORD_END_TIME,
            ORD_STS
        }

        private enum LOT_COL
        {
            SEL,
            LOT_ID,
            CREATE_TIME,
            IN_QTY_1,
            MAT_ID,
            PRINT_NUM,
            PRINT_TIME
        }

        #endregion

        #region Constructor

        public frmWIPViewFlavoringResultAndRePrint()
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

                dtpOrderDate.Value = System.DateTime.Today;

                MPCF.ClearList(spdWorkOrder);
                MPCF.ClearList(spdMatList);

                InvisibleColumn();

                // (Required) 
                bIsShown = true;
            }
        }

        private void cdvLineGroup_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                BICF.ViewLineGroup(cdvLineGroup);
                cdvLine.Text = "";
                cdvLine.Tag = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
            return;
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                BICF.ViewLine(cdvLine, MPCF.Trim(cdvLineGroup.Tag.ToString()));
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                MenuInfoTag selectedMenuInfo;

                BOI.INVCus.Popup.frmInvViewMatList frm = new BOI.INVCus.Popup.frmInvViewMatList(MPCF.Trim(cdvMatID.Text), BIGC.B_MAT_TYPE_GRP_P);

                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "View Mat List";
                frm.Tag = selectedMenuInfo;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (MPCF.Trim(frm.OUT_MAT_ID) == "")
                {
                    frm.ShowDialog();
                }
                txtMatDesc.Text = frm.OUT_MAT_DESC;
                cdvMatID.Text = frm.OUT_MAT_ID;
                txtMatUnit.Text = frm.OUT_MAT_UNIT_1;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW_ORDER_LIST") == true)
                {
                    ViewOrderList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdWorkOrder_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                s_selected_order = spdWorkOrder.Sheets[0].Cells[e.Row, (int)ORDER.ORDER_ID].Value.ToString();
                ViewBomLot(s_selected_order, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void txtInvLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if(ViewBomLot(s_selected_order, txtInvLotID.Text.Trim()) == true)
                    {
                        if(chkAutoPrint.Checked == true)
                        {
                            if (Tran_Print_Label(txtInvLotID.Text.Trim(), MPCF.Trim(spdMatList.ActiveSheet.Cells[0, (int)LOT_COL.PRINT_TIME].Text)) == false)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        #endregion

        #region Function

        private bool ViewBomLot(string sorderId, string sLotId)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {
                MPCF.ClearList(spdMatList);

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORDER_ID";
                dvcArgu[1].sCondition_Value = sorderId;

                dvcArgu[2].sCondtion_ID = "LOT_ID";
                dvcArgu[2].sCondition_Value = sLotId;

                if (TPDR.GetDataOne("", ref dt, "CWIP2302-003", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdMatList.Sheets[0].RowCount++;

                    spdMatList.Sheets[0].Cells[i, (int)LOT_COL.SEL].Value = false;
                    spdMatList.Sheets[0].Cells[i, (int)LOT_COL.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdMatList.Sheets[0].Cells[i, (int)LOT_COL.CREATE_TIME].Value = dt.Rows[i]["CREATE_TIME"].ToString();
                    spdMatList.Sheets[0].Cells[i, (int)LOT_COL.IN_QTY_1].Value = dt.Rows[i]["QTY_1"].ToString();

                    spdMatList.Sheets[0].Cells[i, (int)LOT_COL.MAT_ID].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdMatList.Sheets[0].Cells[i, (int)LOT_COL.MAT_ID].Tag = dt.Rows[i]["MAT_ID"].ToString();

                    spdMatList.Sheets[0].Cells[i, (int)LOT_COL.PRINT_NUM].Value = dt.Rows[i]["PRINT_NUM"].ToString();
                    spdMatList.Sheets[0].Cells[i, (int)LOT_COL.PRINT_TIME].Value = dt.Rows[i]["PRINT_TIME"].ToString();
                }

                MPCF.FitColumnHeader(spdMatList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }
        private void InvisibleColumn()
        {
            try
            {
                spdWorkOrder.Sheets[0].Columns[(int)ORDER.SEL].Visible = false;
                //spdMatList.Sheets[0].Columns[(int)LOT_COL.SEL].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW_ORDER_LIST":
                        //LINE GROUP  
                        if (MPCF.Trim(cdvLineGroup.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLineGroup.Focus();
                            return false;
                        }

                        //LINE
                        if (MPCF.Trim(cdvLine.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLine.Focus();
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

        //View Inventory Lot History
        private bool ViewOrderList()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[7];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {
                spdWorkOrder_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORD_DATE";
                dvcArgu[1].sCondition_Value = dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[2].sCondtion_ID = "ORD_TO_DATE";
                dvcArgu[2].sCondition_Value = dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[3].sCondtion_ID = "LINE_ID";
                if (MPCF.Trim(cdvLine.Text) == "")
                {
                    dvcArgu[3].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[3].sCondition_Value = MPCF.Trim(cdvLine.Tag);
                }

                dvcArgu[4].sCondtion_ID = "LINE_GRP";
                if (MPCF.Trim(cdvLineGroup.Text) == "")
                {
                    dvcArgu[4].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[4].sCondition_Value = MPCF.Trim(cdvLineGroup.Tag);
                }

                dvcArgu[5].sCondtion_ID = "ORD_STATUS";
                dvcArgu[5].sCondition_Value = MPCF.Trim(rbStatus.Items[rbStatus.CheckedIndex].DataValue.ToString());

                dvcArgu[6].sCondtion_ID = "MAT_ID";
                if (MPCF.Trim(cdvMatID.Text) == "")
                {
                    dvcArgu[6].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[6].sCondition_Value = MPCF.Trim(cdvMatID.Text);
                }


                if (TPDR.GetDataOne("", ref dt, "CWIP8010-001", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdWorkOrder_Sheet1.RowCount++;

                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.SEL].Value = false;
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_DATE].Value = dt.Rows[i][0].ToString();
                    if (i == 0)
                    {
                        s_selected_order = dt.Rows[i][1].ToString();
                    }
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Value = dt.Rows[i][1].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.MAT_ID].Value = dt.Rows[i][2].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.MAT_DESC].Value = dt.Rows[i][3].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_QTY].Value = dt.Rows[i][4].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.PROD_QTY].Value = dt.Rows[i][5].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.UNIT].Value = dt.Rows[i][6].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.LINE].Value = dt.Rows[i][7].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.RES].Value = dt.Rows[i][8].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_START_TIME].Value = dt.Rows[i][9].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_END_TIME].Value = dt.Rows[i][10].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_STS].Value = dt.Rows[i][11].ToString();
                }

                MPCF.FitColumnHeader(spdWorkOrder);

                ViewBomLot(s_selected_order, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        #endregion

        private void btnLabelPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < spdMatList.ActiveSheet.RowCount; i++)
            {
                if (Convert.ToBoolean(spdMatList.ActiveSheet.Cells[i, (int)LOT_COL.SEL].Value) == true)
                {
                    if (Tran_Print_Label(MPCF.Trim(spdMatList.ActiveSheet.Cells[i, (int)LOT_COL.LOT_ID].Text), MPCF.Trim(spdMatList.ActiveSheet.Cells[i, (int)LOT_COL.PRINT_TIME].Text)) == false)
                    {
                        return;
                    }
                }
            }

            ViewBomLot(s_selected_order, "");
        }

        private bool Tran_Print_Label(string s_lot_id, string s_print_time)
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
                in_node.ProcStep = '8';
                in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));
                in_node.AddString("SCREEN_ID", BIGC.B_LABEL_LB003);
                in_node.AddString("PRINT_TIME", s_print_time);
                in_node.AddChar("PRINT_HIS_FLAG", 'Y');

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
    }
}
