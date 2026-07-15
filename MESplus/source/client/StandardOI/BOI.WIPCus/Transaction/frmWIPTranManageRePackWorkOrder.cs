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
    public partial class frmWIPTranManageRePackWorkOrder : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

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

        private enum BOM
        {
            INV_MAT_ID = 0,
            INV_MAT_DESC,
            BOM_QTY,
            UNIT
        }
        private string s_selected_order;

        #endregion

        #region Constructor

        public frmWIPTranManageRePackWorkOrder()
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
            //MPCF.ConvertCaption(this);

            MPCF.ClearList(spdWorkOrder);

            dtpOrderDate.Value = System.DateTime.Today;
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

                dvcArgu[2].sCondtion_ID = "LINE_ID";
                if (MPCF.Trim(cdvLine.Text) == "")
                {
                    dvcArgu[2].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[2].sCondition_Value = MPCF.Trim(cdvLine.Tag);
                }

                dvcArgu[3].sCondtion_ID = "LINE_GRP";
                if (MPCF.Trim(cdvLineGroup.Text) == "")
                {
                    dvcArgu[3].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[3].sCondition_Value = MPCF.Trim(cdvLineGroup.Tag);
                }

                dvcArgu[4].sCondtion_ID = "ORD_STATUS";
                dvcArgu[4].sCondition_Value = MPCF.Trim(rbStatus.Items[rbStatus.CheckedIndex].DataValue.ToString());

                dvcArgu[5].sCondtion_ID = "MAT_ID";
                if (MPCF.Trim(cdvMatID.Text) == "")
                {
                    dvcArgu[5].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[5].sCondition_Value = MPCF.Trim(cdvMatID.Text);
                }

                dvcArgu[6].sCondtion_ID = "ORD_TO_DATE";
                dvcArgu[6].sCondition_Value = dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd");

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
                    if(i==0)
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
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_STS].Tag = dt.Rows[i]["ORDER_STATUS"];
                }

                MPCF.FitColumnHeader(spdWorkOrder);

                btnProcessRePacking.Enabled = true;
                btnProcessRePacking.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnProcessRePacking.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));

                btnManualPallet.Enabled = true;
                btnManualPallet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnManualPallet.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));

                if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_PROCESS || MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                {
                    btnProcessRePacking.Enabled = false;
                    btnProcessRePacking.Appearance.BackColor = SystemColors.Control;
                    btnProcessRePacking.Appearance.BackColor2 = SystemColors.Control;
                }

                if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                {
                    btnManualPallet.Enabled = false;
                    btnManualPallet.Appearance.BackColor = SystemColors.Control;
                    btnManualPallet.Appearance.BackColor2 = SystemColors.Control;

                    btnProcessEnd.Enabled = false;
                    btnProcessEnd.Appearance.BackColor = SystemColors.Control;
                    btnProcessEnd.Appearance.BackColor2 = SystemColors.Control;
                }              
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        

        private bool CheckCondition(string FuncName)
        {
            int i_cnt = 0;
            int i = 0;

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
                    case "End_Order":
                    case "Start_Order":
                        if (spdWorkOrder_Sheet1.RowCount == 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, true);
                            return false;
                        }

                        for (i = 0; i < spdWorkOrder_Sheet1.RowCount; i++)
                        {
                            if (Convert.ToBoolean(spdWorkOrder_Sheet1.Cells[i, (int)ORDER.SEL].Value))
                            {
                                i_cnt++;
                                break;
                            }
                        }

                        if (i_cnt == 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(402), MSG_LEVEL.ERROR, true);
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

        /// <summary>
        /// 작업지시 시작
        /// </summary>
        /// <returns></returns>
        private bool Start_Order()
        {
            TRSNode in_node = new TRSNode("Start_Order_In");
            TRSNode out_node = new TRSNode("Start_Order_Out");

            int i = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                for (i = 0; i < spdWorkOrder_Sheet1.RowCount; i++)
                {
                    if (spdWorkOrder_Sheet1.Cells[i, (int)ORDER.SEL].Text == "True")
                    {
                        in_node.SetString("ORDER_ID", spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORDER_ID].Value);

                        if (MPCF.CallService("BWIP", "BWIP_Start_Order", in_node, ref out_node) == false)
                            return false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Start_Order() : " + ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }

            MPCF.ShowSuccessMessage(out_node, false);

            return true;
        }

        /// <summary>
        /// 작업지시 종료
        /// </summary>
        /// <returns></returns>
        private bool End_Order()
        {
            TRSNode in_node = new TRSNode("End_Order_In");
            TRSNode out_node = new TRSNode("End_Order_Out");

            int i = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                for (i = 0; i < spdWorkOrder_Sheet1.RowCount; i++)
                {
                    if (spdWorkOrder_Sheet1.Cells[i, (int)ORDER.SEL].Text == "True")
                    {
                        in_node.SetString("ORDER_ID", spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Value);

                        if (MPCF.CallService("BWIP", "BWIP_End_Order", in_node, ref out_node) == false)
                            return false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("End_Order() : " + ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }

            MPCF.ShowSuccessMessage(out_node, false);

            return true;
        }

        #endregion

        private void cdvLineGroup_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (BICF.ViewLineGroup(cdvLineGroup))
                {
                    cdvLine.Tag = "";
                    cdvLine.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return ;
            }
            return ;
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

        private void cdvMatID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    MenuInfoTag selectedMenuInfo;

                    BOI.INVCus.Popup.frmInvViewMatList frm = new BOI.INVCus.Popup.frmInvViewMatList(MPCF.Trim(cdvMatID.Text), BIGC.B_MAT_TYPE_GRP_P);

                    selectedMenuInfo = new MenuInfoTag();
                    selectedMenuInfo.s_func_desc = "View Mat List";
                    frm.Tag = selectedMenuInfo;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    txtMatDesc.Text = frm.OUT_MAT_DESC;
                    cdvMatID.Text = frm.OUT_MAT_ID;
                    txtMatUnit.Text = frm.OUT_MAT_UNIT_1;
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

                if (e.ColumnHeader == false && e.Column == (int)ORDER.SEL)
                {
                    if (Convert.ToBoolean(spdWorkOrder_Sheet1.Cells[e.Row, e.Column].Value) == false)
                    {
                        BICF.CheckSpreadCell(spdWorkOrder, 0, false);
                    }
                }                 

                s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[e.Row, (int)ORDER.ORDER_ID].Text);

                btnProcessRePacking.Enabled = true;
                btnProcessRePacking.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnProcessRePacking.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));

                btnManualPallet.Enabled = true;
                btnManualPallet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnManualPallet.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));

                if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[e.Row, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_PROCESS || MPCF.Trim(spdWorkOrder_Sheet1.Cells[e.Row, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                {
                    btnProcessRePacking.Enabled = false;
                    btnProcessRePacking.Appearance.BackColor = SystemColors.Control;
                    btnProcessRePacking.Appearance.BackColor2 = SystemColors.Control;
                }

                if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[e.Row, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                {
                    btnManualPallet.Enabled = false;
                    btnManualPallet.Appearance.BackColor = SystemColors.Control;
                    btnManualPallet.Appearance.BackColor2 = SystemColors.Control;

                    btnProcessEnd.Enabled = false;
                    btnProcessEnd.Appearance.BackColor = SystemColors.Control;
                    btnProcessEnd.Appearance.BackColor2 = SystemColors.Control;
                }
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
                if (CheckCondition("Start_Order"))
                    Start_Order();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcessBatching_Click(object sender, EventArgs e)
        {
            List<string> s_order_List = null;
            int i = 0, i_cnt = 0;

            try
            {

                if (spdWorkOrder_Sheet1.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, false);
                    return;
                }

                for (i = 0; i < spdWorkOrder_Sheet1.RowCount; i++)
                {
                    if (spdWorkOrder_Sheet1.Cells[i, (int)ORDER.SEL].Text == "True")
                    {
                        if (s_order_List == null)
                            s_order_List = new List<string>();

                        s_order_List.Add(spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Text);
                        i_cnt++;
                    }
                }

                if (i_cnt == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(402), MSG_LEVEL.ERROR, false);
                    return;
                }

                frmMaterialInputInPacking frm = new frmMaterialInputInPacking();
                frm.s_order_list = s_order_List;
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnManualPallet_Click(object sender, EventArgs e)
        {
            List<string> s_order_List = null;
            int i = 0, i_cnt = 0;

            try
            {
                if (spdWorkOrder_Sheet1.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, false);
                    return;
                }

                for (i = 0; i < spdWorkOrder_Sheet1.RowCount; i++)
                {
                    if (spdWorkOrder_Sheet1.Cells[i, (int)ORDER.SEL].Text == "True")
                    {
                        if (s_order_List == null)
                            s_order_List = new List<string>();

                        s_order_List.Add(spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Text);
                        i_cnt++;
                    }
                }

                if (i_cnt == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(402), MSG_LEVEL.ERROR, false);
                    return;
                }

                frmWIPSingleResultRegistration frm = new frmWIPSingleResultRegistration();
                frm.s_order_list = s_order_List;
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcessEnd_Click(object sender, EventArgs e)
        {
            if (CheckCondition("End_Order"))
                End_Order();
        }
    }
}
