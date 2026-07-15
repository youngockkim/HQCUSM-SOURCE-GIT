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
using BOI.INVCus;
using BOI.OIFrx;
using SOI.DNM;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPTranManageSelectWork : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum ORDER
        {
            ORDER_ID = 0,
            ORD_DATE,
            MAT_ID,
            MAT_DESC,
            ORD_QTY,
            PROD_QTY,
            NG_QTY,
            UNIT,
            LINE_GROUP,
            LINE,
            RES,
            ORD_START_TIME,
            ORD_END_TIME,
            ORD_STS
        }

        private enum BOM
        {
            INV_MAT_ID = 0,
            INV_MAT_DESC,
            BOM_QTY,
            UNIT
        }
        private string s_selected_order = "";
        private string s_oper = "";
        private string s_flow = "";
        private char s_mat_bom_type = ' ';

        #endregion

        #region Constructor

        public frmWIPTranManageSelectWork()
        {
            InitializeComponent();
        }

        public frmWIPTranManageSelectWork(string sOrder)
        {
            InitializeComponent();
            s_selected_order = sOrder;
            ViewOrder(sOrder);
            ViewOrderLot(sOrder);
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

            
            InvisibleColumn();
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
                    case "VIEW_ORDER_LIST":
                        ////LINE GROUP  
                        //if (MPCF.Trim(cdvLineGroup.Text) == "")
                        //{
                        //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                        //    cdvLineGroup.Focus();
                        //    return false;
                        //}

                        ////LINE
                        //if (MPCF.Trim(cdvLine.Text) == "")
                        //{
                        //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                        //    cdvLine.Focus();
                        //    return false;
                        //}

                        break;
                    case "BUTTON_CLICK":
                        //LINE GROUP  
                        if (MPCF.Trim(s_selected_order) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(436), MSG_LEVEL.WARNING, true);
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
        private bool ViewOrder(string sOrder)
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
                dvcArgu[1].sCondition_Value = MPCF.Trim(sOrder);


                if (TPDR.GetDataOne("", ref dt, "CWIP8030-001", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                spdWorkOrder_Sheet1.Cells[(int)ORDER.ORDER_ID, 0].Value = dt.Rows[0][1].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_DATE, 0].Value = dt.Rows[0][0].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.MAT_ID, 0].Value = dt.Rows[0][2].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.MAT_DESC, 0].Value = dt.Rows[0][3].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_QTY, 0].Value = dt.Rows[0][4].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.PROD_QTY, 0].Value = dt.Rows[0][5].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.UNIT, 0].Value = dt.Rows[0][6].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.LINE, 0].Value = dt.Rows[0][7].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.RES, 0].Value = dt.Rows[0][8].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_STS, 0].Value =  dt.Rows[0][11].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.LINE, 0].Tag = dt.Rows[0][12].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.RES, 0].Tag = dt.Rows[0][13].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.NG_QTY, 0].Value = dt.Rows[0][14].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.LINE_GROUP, 0].Text = dt.Rows[0][15].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_STS, 0].Tag = dt.Rows[0][17].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_START_TIME, 0].Text = dt.Rows[0][9].ToString();
                spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_END_TIME, 0].Text = dt.Rows[0][10].ToString();

                if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_STS, 0].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                {
                    btnInputBatcingInvMat.Enabled = false;
                    btnInputBatcingInvMat.Appearance.BackColor = SystemColors.Control;
                    btnInputBatcingInvMat.Appearance.BackColor2 = SystemColors.Control;

                    btnProcessBatching.Enabled = false;
                    btnProcessBatching.Appearance.BackColor = SystemColors.Control;
                    btnProcessBatching.Appearance.BackColor2 = SystemColors.Control;

                    btnEndWorkOrder.Enabled = false;
                    btnEndWorkOrder.Appearance.BackColor = SystemColors.Control;
                    btnEndWorkOrder.Appearance.BackColor2 = SystemColors.Control;
                }

                MPCF.FitColumnHeader(spdWorkOrder);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        //View Inventory Lot History
        private bool ViewOrderLot(string sOrder)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {
                spdLot_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORDER_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sOrder);


                if (TPDR.GetDataOne("", ref dt, "CWIP8020-001", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdLot_Sheet1.RowCount++;
                    spdLot_Sheet1.Cells[i, 0].Value = dt.Rows[i][0].ToString();
                }
                MPCF.FitColumnHeader(spdLot);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        private bool View_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                s_oper = "";
                s_flow = "";
                s_mat_bom_type = ' ';
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("ORDER_ID", MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.ORDER_ID, 0].Text));

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                
                s_oper = MPCF.Trim(out_node.GetString("OPER"));
                s_flow = MPCF.Trim(out_node.GetString("FLOW"));
                s_mat_bom_type = out_node.GetChar("MAT_BOM_TYPE");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        // Update_Order_Res()
        //       - Merge Target Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_Order_Status(char ProcStep, string ord_status)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("UPDATE_ORDER_STATUS_IN");
            TRSNode out_node = new TRSNode("UPDATE_ORDER_STATUS_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                //ORDER_ID
                in_node.AddString("ORDER_ID", MPCF.Trim(s_selected_order));

                //ORDER_STATUS
                in_node.AddChar("ORDER_STATUS", ord_status);


                if (MPCF.CallService("BWIP", "BWIP_Update_Order_Status", in_node, ref out_node) == false)
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


        private void InvisibleColumn()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        
        
        private void spdWorkOrder_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {

                if (spdWorkOrder.Sheets[0].RowCount <= 0 || e.ColumnHeader == true)
                    return;
                s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[e.Row, (int)ORDER.ORDER_ID].Text);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ViewOrder(s_selected_order);
                ViewOrderLot(s_selected_order);      
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnSetResource_Click(object sender, EventArgs e)
        {
            try
            {

                if (MPCF.Trim(s_selected_order) == "")
                {
                    BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP8040);
                }
                else
                {
                    BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP8040, s_selected_order);
                }

                if (ViewOrder(s_selected_order) == false)
                {
                    return;
                }
                else
                {
                    if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_STS, 0].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                    {
                        btnInputBatcingInvMat.Enabled = false;
                        btnInputBatcingInvMat.Appearance.BackColor = SystemColors.Control;
                        btnInputBatcingInvMat.Appearance.BackColor2 = SystemColors.Control;

                        btnProcessBatching.Enabled = false;
                        btnProcessBatching.Appearance.BackColor = SystemColors.Control;
                        btnProcessBatching.Appearance.BackColor2 = SystemColors.Control;

                        btnEndWorkOrder.Enabled = false;
                        btnEndWorkOrder.Appearance.BackColor = SystemColors.Control;
                        btnEndWorkOrder.Appearance.BackColor2 = SystemColors.Control;
                    }
                }
                if (ViewOrderLot(s_selected_order) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcessBatching_Click(object sender, EventArgs e)
        {
            try
            {                
                if (MPCF.Trim(s_selected_order) == "")
                {
                    BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP8070);
                }
                else
                {
                    BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP8070, s_selected_order);
                }

                if (ViewOrder(s_selected_order) == false)
                {
                    return;
                }
                else
                {
                    if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_STS, 0].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                    {
                        btnInputBatcingInvMat.Enabled = false;
                        btnInputBatcingInvMat.Appearance.BackColor = SystemColors.Control;
                        btnInputBatcingInvMat.Appearance.BackColor2 = SystemColors.Control;

                        btnProcessBatching.Enabled = false;
                        btnProcessBatching.Appearance.BackColor = SystemColors.Control;
                        btnProcessBatching.Appearance.BackColor2 = SystemColors.Control;

                        btnEndWorkOrder.Enabled = false;
                        btnEndWorkOrder.Appearance.BackColor = SystemColors.Control;
                        btnEndWorkOrder.Appearance.BackColor2 = SystemColors.Control;
                    }
                }
                if (ViewOrderLot(s_selected_order) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnInPutOperInvMat_Click(object sender, EventArgs e)
        {
            try
            {
                View_Lot(MPCF.Trim(spdLot_Sheet1.Cells[spdLot_Sheet1.ActiveRowIndex, 0].Text));

                frmWIPInputMaterialOperPretreatment frm = null;
                
                frm = new frmWIPInputMaterialOperPretreatment();
                frm.OrderId = MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.ORDER_ID, 0].Text);
                frm.LotId = MPCF.Trim(spdLot_Sheet1.Cells[spdLot_Sheet1.ActiveRowIndex, 0].Text);
                frm.MatId = MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.MAT_ID, 0].Text);
                frm.Oper = s_oper;
                frm.Flow = s_flow;
                frm.LineId = MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.LINE, 0].Text);
                frm.MatBomType = s_mat_bom_type.ToString();

                frm.ShowDialog(this);

                if (ViewOrder(s_selected_order) == false)
                {
                    return;
                }
                else
                {
                    if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_STS, 0].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                    {
                        btnInputBatcingInvMat.Enabled = false;
                        btnInputBatcingInvMat.Appearance.BackColor = SystemColors.Control;
                        btnInputBatcingInvMat.Appearance.BackColor2 = SystemColors.Control;

                        btnProcessBatching.Enabled = false;
                        btnProcessBatching.Appearance.BackColor = SystemColors.Control;
                        btnProcessBatching.Appearance.BackColor2 = SystemColors.Control;

                        btnEndWorkOrder.Enabled = false;
                        btnEndWorkOrder.Appearance.BackColor = SystemColors.Control;
                        btnEndWorkOrder.Appearance.BackColor2 = SystemColors.Control;
                    }
                }
                if (ViewOrderLot(s_selected_order) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            
            
        }

        private void btnReinfroceInvMat_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(s_selected_order) == "")
                {
                    BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP8050);
                }
                else
                {
                    BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP8050, s_selected_order);
                }

                if (ViewOrder(s_selected_order) == false)
                {
                    return;
                }
                else
                {
                    if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_STS, 0].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                    {
                        btnInputBatcingInvMat.Enabled = false;
                        btnInputBatcingInvMat.Appearance.BackColor = SystemColors.Control;
                        btnInputBatcingInvMat.Appearance.BackColor2 = SystemColors.Control;

                        btnProcessBatching.Enabled = false;
                        btnProcessBatching.Appearance.BackColor = SystemColors.Control;
                        btnProcessBatching.Appearance.BackColor2 = SystemColors.Control;

                        btnEndWorkOrder.Enabled = false;
                        btnEndWorkOrder.Appearance.BackColor = SystemColors.Control;
                        btnEndWorkOrder.Appearance.BackColor2 = SystemColors.Control;
                    }
                }
                if (ViewOrderLot(s_selected_order) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnEndWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("BUTTON_CLICK") == true)
                {
                    if (Update_Order_Status(MPGC.MP_STEP_UPDATE, BIGC.B_ORD_STATUS_COMPLETED) == false)
                    {
                        return;
                    }
                    else
                    {
                        
                        if (ViewOrder(s_selected_order) == false)
                        {
                            return;
                        }
                        else
                        {
                            if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_STS, 0].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                            {
                                btnInputBatcingInvMat.Enabled = false;
                                btnInputBatcingInvMat.Appearance.BackColor = SystemColors.Control;
                                btnInputBatcingInvMat.Appearance.BackColor2 = SystemColors.Control;

                                btnProcessBatching.Enabled = false;
                                btnProcessBatching.Appearance.BackColor = SystemColors.Control;
                                btnProcessBatching.Appearance.BackColor2 = SystemColors.Control;

                                btnEndWorkOrder.Enabled = false;
                                btnEndWorkOrder.Appearance.BackColor = SystemColors.Control;
                                btnEndWorkOrder.Appearance.BackColor2 = SystemColors.Control;
                            }
                        }
                        if (ViewOrderLot(s_selected_order) == false)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmWIPTranManageSelectWork_Activated(object sender, EventArgs e)
        {
            try
            {
                if (ViewOrder(s_selected_order) == false)
                {
                    return;
                }
                else
                {
                    if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[(int)ORDER.ORD_STS, 0].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                    {
                        btnInputBatcingInvMat.Enabled = false;
                        btnInputBatcingInvMat.Appearance.BackColor = SystemColors.Control;
                        btnInputBatcingInvMat.Appearance.BackColor2 = SystemColors.Control;

                        btnProcessBatching.Enabled = false;
                        btnProcessBatching.Appearance.BackColor = SystemColors.Control;
                        btnProcessBatching.Appearance.BackColor2 = SystemColors.Control;

                        btnEndWorkOrder.Enabled = false;
                        btnEndWorkOrder.Appearance.BackColor = SystemColors.Control;
                        btnEndWorkOrder.Appearance.BackColor2 = SystemColors.Control;
                    }
                }
                if (ViewOrderLot(s_selected_order) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

    }
}
