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
    public partial class frmWIPTranManageMoldWorkOrder : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum ORDER
        {
            ORD_DATE = 0,
            ORDER_ID,
            MAT_ID,
            MAT_DESC,
            TYPE,
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

        public frmWIPTranManageMoldWorkOrder()
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

            MPCF.ClearList(spdWorkOrder);

            dtpOrderDate.Value = System.DateTime.Today;
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

                GetDefaultValueFromReg();     
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
                    s_selected_order = "";
                    if (ViewOrderList() == false)
                    {
                        return;
                    }
                    else
                    {
                        s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[0, (int)ORDER.ORDER_ID].Text);
                        if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_PROCESS || MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                        {
                            btnProcessMold.Enabled = false;
                            btnProcessMold.Appearance.BackColor = SystemColors.Control;
                            btnProcessMold.Appearance.BackColor2 = SystemColors.Control;
                        }

                        if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                        {
                            btnProcessEnd.Enabled = false;
                            btnProcessEnd.Appearance.BackColor = SystemColors.Control;
                            btnProcessEnd.Appearance.BackColor2 = SystemColors.Control;

                            btnProcessResult.Enabled = false;
                            btnProcessResult.Appearance.BackColor = SystemColors.Control;
                            btnProcessResult.Appearance.BackColor2 = SystemColors.Control;
                            
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


        public void GetDefaultValueFromReg()
        {
            try
            {

                cdvLineGroup.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Tag"));
                cdvLineGroup.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Text"));

                cdvLine.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Tag"));
                cdvLine.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void SetDefaultValueToReg()
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Tag", MPCF.Trim(cdvLineGroup.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Text", MPCF.Trim(cdvLineGroup.Text));

                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Tag", MPCF.Trim(cdvLine.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Text", MPCF.Trim(cdvLine.Text));


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
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
                //버튼 초기화
                btnProcessMold.Enabled = true;
                btnProcessMold.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnProcessMold.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));

                btnProcessEnd.Enabled = true;
                btnProcessEnd.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnProcessEnd.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));

                btnProcessResult.Enabled = true;
                btnProcessResult.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnProcessResult.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
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

                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_DATE].Value = dt.Rows[i][0].ToString();
                    if(i==0)
                    {
                        s_selected_order = dt.Rows[i][1].ToString();
                    }
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Value = dt.Rows[i][1].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.MAT_ID].Value = dt.Rows[i][2].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.MAT_DESC].Value = dt.Rows[i][3].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.TYPE].Value = dt.Rows[i]["MAT_BOM_TYPE"];
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_QTY].Value = dt.Rows[i][4].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.PROD_QTY].Value = dt.Rows[i][5].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.UNIT].Value = dt.Rows[i][6].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.LINE].Value = dt.Rows[i][7].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.RES].Value = dt.Rows[i][8].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_START_TIME].Value = dt.Rows[i][9].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_END_TIME].Value = dt.Rows[i][10].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_STS].Value = dt.Rows[i][11].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_STS].Tag = dt.Rows[i][15].ToString();
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

        // Update_Order_Res()
        //       - Merge Target Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Start_Order()
        {
            TRSNode in_node = new TRSNode("Start_Order_In");
            TRSNode out_node = new TRSNode("Start_Order_Out");

            int i_row = 0;

            try
            {
                i_row = spdWorkOrder_Sheet1.ActiveRowIndex;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                //ORDER_ID
                in_node.SetString("ORDER_ID", spdWorkOrder_Sheet1.Cells[i_row, (int)ORDER.ORDER_ID].Value);

                if (MPCF.CallService("BWIP", "BWIP_Start_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);
                btnProcessMold.Enabled = false;
                btnProcessMold.Appearance.BackColor = SystemColors.Control;
                btnProcessMold.Appearance.BackColor2 = SystemColors.Control;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool End_Order()
        {
            TRSNode in_node = new TRSNode("End_Order_In");
            TRSNode out_node = new TRSNode("End_Order_Out");

            int i_row = 0;

            try
            {
                i_row = spdWorkOrder_Sheet1.ActiveRowIndex;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                //ORDER_ID
                in_node.SetString("ORDER_ID", spdWorkOrder_Sheet1.Cells[i_row, (int)ORDER.ORDER_ID].Value);

                if (MPCF.CallService("BWIP", "BWIP_End_Order", in_node, ref out_node) == false)
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

        private void cdvLineGroup_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                BICF.ViewLineGroup(cdvLineGroup);
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

                if (spdWorkOrder.Sheets[0].RowCount <= 0 || e.ColumnHeader == true)
                    return;

                btnProcessMold.Enabled = true;
                btnProcessMold.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnProcessMold.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));

                btnProcessEnd.Enabled = true;
                btnProcessEnd.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnProcessEnd.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));

                btnProcessResult.Enabled = true;
                btnProcessResult.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
                btnProcessResult.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));

                s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[e.Row, (int)ORDER.ORDER_ID].Text);
                if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[e.Row, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_PROCESS || MPCF.Trim(spdWorkOrder_Sheet1.Cells[e.Row, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                {
                    btnProcessMold.Enabled = false;
                    btnProcessMold.Appearance.BackColor = SystemColors.Control;
                    btnProcessMold.Appearance.BackColor2 = SystemColors.Control;
                }

                if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[e.Row, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                {
                    btnProcessEnd.Enabled = false;
                    btnProcessEnd.Appearance.BackColor = SystemColors.Control;
                    btnProcessEnd.Appearance.BackColor2 = SystemColors.Control;

                    btnProcessResult.Enabled = false;
                    btnProcessResult.Appearance.BackColor = SystemColors.Control;
                    btnProcessResult.Appearance.BackColor2 = SystemColors.Control;
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
                if (CheckCondition("BUTTON_CLICK") == true)
                {                    
                    if (MPCF.Trim(s_selected_order) == "")
                    {
                        frmWIPSetupResource frm = new frmWIPSetupResource();
                        frm.ShowDialog();
                    }
                    else
                    {
                        frmWIPSetupResource frm = new frmWIPSetupResource(s_selected_order);
                        frm.ShowDialog();
                    }

                    spdWorkOrder_Sheet1.RowCount = 0;

                    if (ViewOrderList() == false)
                    {
                        return;
                    }
                    else
                    {
                        s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[0, (int)ORDER.ORDER_ID].Text);
                        if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_PROCESS || MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                        {
                            btnProcessMold.Enabled = false;
                            btnProcessMold.Appearance.BackColor = SystemColors.Control;
                            btnProcessMold.Appearance.BackColor2 = SystemColors.Control;
                        }

                        if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                        {
                            btnProcessEnd.Enabled = false;
                            btnProcessEnd.Appearance.BackColor = SystemColors.Control;
                            btnProcessEnd.Appearance.BackColor2 = SystemColors.Control;

                            btnProcessResult.Enabled = false;
                            btnProcessResult.Appearance.BackColor = SystemColors.Control;
                            btnProcessResult.Appearance.BackColor2 = SystemColors.Control;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void cdvLineGroup_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdvLine.Tag = "";
                cdvLine.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcessMold_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("BUTTON_CLICK") == true)
                {
                    if (Start_Order() == false)
                    {
                        return;
                    }
                    else
                    {
                        spdWorkOrder_Sheet1.RowCount = 0;

                        if (ViewOrderList() == false)
                        {
                            return;
                        }
                        else
                        {
                            s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[0, (int)ORDER.ORDER_ID].Text);
                            if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_PROCESS || MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                            {
                                btnProcessMold.Enabled = false;
                                btnProcessMold.Appearance.BackColor = SystemColors.Control;
                                btnProcessMold.Appearance.BackColor2 = SystemColors.Control;
                            }

                            if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                            {
                                btnProcessEnd.Enabled = false;
                                btnProcessEnd.Appearance.BackColor = SystemColors.Control;
                                btnProcessEnd.Appearance.BackColor2 = SystemColors.Control;

                                btnProcessResult.Enabled = false;
                                btnProcessResult.Appearance.BackColor = SystemColors.Control;
                                btnProcessResult.Appearance.BackColor2 = SystemColors.Control;
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

        private void btnInputInvMat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("BUTTON_CLICK") == true)
                {
                    if (MPCF.Trim(s_selected_order) == "")
                    {
                        BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP2401);
                    }
                    else
                    {
                        BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP2401, s_selected_order);
                    }

                    spdWorkOrder_Sheet1.RowCount = 0;

                    if (ViewOrderList() == false)
                    {
                        return;
                    }
                    else
                    {
                        s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[0, (int)ORDER.ORDER_ID].Text);
                        if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_PROCESS || MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                        {
                            btnProcessMold.Enabled = false;
                            btnProcessMold.Appearance.BackColor = SystemColors.Control;
                            btnProcessMold.Appearance.BackColor2 = SystemColors.Control;
                        }

                        if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                        {
                            btnProcessEnd.Enabled = false;
                            btnProcessEnd.Appearance.BackColor = SystemColors.Control;
                            btnProcessEnd.Appearance.BackColor2 = SystemColors.Control;

                            btnProcessResult.Enabled = false;
                            btnProcessResult.Appearance.BackColor = SystemColors.Control;
                            btnProcessResult.Appearance.BackColor2 = SystemColors.Control;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcessResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("BUTTON_CLICK") == true)
                {
                    if (MPCF.Trim(s_selected_order) == "")
                    {
                        BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP2403);
                    }
                    else
                    {
                        BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP2403, s_selected_order);
                    }

                    spdWorkOrder_Sheet1.RowCount = 0;

                    if (ViewOrderList() == false)
                    {
                        return;
                    }
                    else
                    {
                        s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[0, (int)ORDER.ORDER_ID].Text);
                        if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_PROCESS || MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                        {
                            btnProcessMold.Enabled = false;
                            btnProcessMold.Appearance.BackColor = SystemColors.Control;
                            btnProcessMold.Appearance.BackColor2 = SystemColors.Control;
                        }

                        if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                        {
                            btnProcessEnd.Enabled = false;
                            btnProcessEnd.Appearance.BackColor = SystemColors.Control;
                            btnProcessEnd.Appearance.BackColor2 = SystemColors.Control;

                            btnProcessResult.Enabled = false;
                            btnProcessResult.Appearance.BackColor = SystemColors.Control;
                            btnProcessResult.Appearance.BackColor2 = SystemColors.Control;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcessEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("BUTTON_CLICK") == true)
                {
                    if (End_Order() == false)
                    {
                        return;
                    }
                    else
                    {
                        spdWorkOrder_Sheet1.RowCount = 0;

                        if (ViewOrderList() == false)
                        {
                            return;
                        }
                        else
                        {
                            s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[0, (int)ORDER.ORDER_ID].Text);
                            if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_PROCESS || MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                            {
                                btnProcessMold.Enabled = false;
                                btnProcessMold.Appearance.BackColor = SystemColors.Control;
                                btnProcessMold.Appearance.BackColor2 = SystemColors.Control;
                            }

                            if (MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)ORDER.ORD_STS].Tag) == BIGC.B_ORD_STATUS_COMPLETED)
                            {
                                btnProcessEnd.Enabled = false;
                                btnProcessEnd.Appearance.BackColor = SystemColors.Control;
                                btnProcessEnd.Appearance.BackColor2 = SystemColors.Control;

                                btnProcessResult.Enabled = false;
                                btnProcessResult.Appearance.BackColor = SystemColors.Control;
                                btnProcessResult.Appearance.BackColor2 = SystemColors.Control;
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

        private void frmWIPTranManageMoldWorkOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetDefaultValueToReg();
        }


    }
}
