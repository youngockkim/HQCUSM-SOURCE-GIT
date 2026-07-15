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
    public partial class frmWIPSetupResource : BOIBasePopup02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum ORDER
        {
            CHECK = 0,
            ORD_DATE,
            ORDER_ID,
            MAT_ID,
            MAT_DESC,
            RES,
            BUTTON,
            ORD_STS,
            ORD_QTY,
            UNIT,
            LINE
        }

        #endregion
        private bool bCheckAll = false;

        #region Constructor

        public frmWIPSetupResource()
        {
            InitializeComponent();
        }

        public frmWIPSetupResource(string sOrder)
        {
            InitializeComponent();
            ViewOrder(sOrder);
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

            //MPCF.ClearList(spdWorkOrderWithRes);

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

        // Update_Order_Res()
        //       - Merge Target Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_Order_Res(char ProcStep)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("UPDATE_ORDER_RES_IN");
            TRSNode out_node = new TRSNode("UPDATE_ORDER_RES_OUT");

            TRSNode list_item;
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                for (i = 0; i < spdWorkOrderWithRes.Sheets[0].RowCount; i++)
                {
                    if ((bool)spdWorkOrderWithRes.Sheets[0].Cells[i, (int)ORDER.CHECK].Value == true)
                    {
                        list_item = in_node.AddNode("LIST");

                        //ORDER_ID
                        list_item.AddString("ORDER_ID", MPCF.Trim(spdWorkOrderWithRes.Sheets[0].Cells[i, (int)ORDER.ORDER_ID].Text));

                        //RES_ID
                        list_item.AddString("RES_ID", MPCF.Trim(spdWorkOrderWithRes.Sheets[0].Cells[i, (int)ORDER.RES].Tag.ToString()));

                        //ORDER_STATUS
                        list_item.AddChar("ORDER_STATUS", BIGC.B_ORD_STATUS_RESERVED);
                    }
                }

                if (in_node.GetList("LIST").Count == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(369), MSG_LEVEL.WARNING, false);
                    return false;
                }

                if (MPCF.CallService("BWIP", "BWIP_Multi_Update_Order_Res", in_node, ref out_node) == false)
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

        //View Inventory Lot History
        private bool ViewOrderList()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[7];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {
                spdWorkOrderWithRes_Sheet1.RowCount = 0;

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
                    spdWorkOrderWithRes_Sheet1.RowCount++;
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORD_DATE].Value = dt.Rows[i][0].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Value = dt.Rows[i][1].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.MAT_ID].Value = dt.Rows[i][2].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.MAT_DESC].Value = dt.Rows[i][3].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORD_QTY].Value = dt.Rows[i][4].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.UNIT].Value = dt.Rows[i][6].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.LINE].Value = dt.Rows[i][7].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.RES].Value = dt.Rows[i][8].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORD_STS].Value = dt.Rows[i][11].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.LINE].Tag = dt.Rows[i][12].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.RES].Tag = dt.Rows[i][13].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Tag = dt.Rows[i][14].ToString(); //LINE_GROUP
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORD_STS].Tag = dt.Rows[i][15].ToString(); //ORD_STS
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.MAT_DESC].Tag = dt.Rows[i][16].ToString(); // OPER
                }
                MPCF.FitColumnHeader(spdWorkOrderWithRes);
                spdWorkOrderWithRes_Sheet1.Columns[(int)ORDER.CHECK].Width = 50;
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
                spdWorkOrderWithRes_Sheet1.RowCount = 0;

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
                    spdWorkOrderWithRes_Sheet1.RowCount++;
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.CHECK].Value = true;
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORD_DATE].Value = dt.Rows[i][0].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Value = dt.Rows[i][1].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.MAT_ID].Value = dt.Rows[i][2].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.MAT_DESC].Value = dt.Rows[i][3].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORD_QTY].Value = dt.Rows[i][4].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.UNIT].Value = dt.Rows[i][6].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.LINE].Value = dt.Rows[i][7].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.RES].Value = dt.Rows[i][8].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORD_STS].Value = dt.Rows[i][11].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.LINE].Tag = dt.Rows[i][12].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.RES].Tag = dt.Rows[i][13].ToString();
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Tag = dt.Rows[i][16].ToString(); //LINE_GROUP
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.ORD_STS].Tag = dt.Rows[i][17].ToString(); //ORD_STS
                    spdWorkOrderWithRes_Sheet1.Cells[i, (int)ORDER.MAT_DESC].Tag = dt.Rows[i][18].ToString(); // FLOW
                }
                MPCF.FitColumnHeader(spdWorkOrderWithRes);
                spdWorkOrderWithRes_Sheet1.Columns[(int)ORDER.CHECK].Width = 50;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        //View Inventory Lot History
        private string FindFlowOper(string sFlow)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            dvcArgu[0].sCondtion_ID = "FACTORY";
            dvcArgu[0].sCondition_Value = MPGV.gsFactory;

            dvcArgu[1].sCondtion_ID = "FLOW";
            dvcArgu[1].sCondition_Value = MPCF.Trim(sFlow);


            if (TPDR.GetDataOne("", ref dt, "CWIP8030-002", dvcArgu, false, false, ref s_sql) == false)
            {
                if (dt != null)
                    dt.Dispose();

                GC.Collect();
                return "";
            }

            return dt.Rows[0][0].ToString();
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
                if (spdWorkOrderWithRes.Sheets[0].RowCount <= 0 || e.ColumnHeader == true)
                    return;
                

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
                spdWorkOrderWithRes_Sheet1.RowCount = 0;
                
                if(ViewOrderList() == false)
                    return;
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

        private void spdWorkOrderWithRes_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_flow_oper = "";
            try
            {
                if (e.Column == (int)ORDER.BUTTON)
                {
                    if (MPCF.Trim(spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.ORD_STS].Tag.ToString()) == BIGC.B_ORD_STATUS_NOT_WORKING || MPCF.Trim(spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.ORD_STS].Tag.ToString()) == BIGC.B_ORD_STATUS_RESERVED)
                    {
                        //oper find
                        s_flow_oper = FindFlowOper(spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.MAT_DESC].Tag.ToString());
                        if (MPCF.Trim(s_flow_oper) == "")
                        {
                            return;
                        }
                        else
                        {
                            BICF.ViewResource(cdvResource, MPCF.Trim(spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.ORDER_ID].Tag.ToString()), MPCF.Trim(spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.LINE].Tag.ToString()), s_flow_oper, "Y");
                            if (MPCF.Trim(cdvResource.Tag) == "")
                            {
                                spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.RES].Text = "";
                                spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.RES].Tag = "";
                            }
                            else
                            {
                                spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.RES].Text = cdvResource.Text;
                                spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.RES].Tag = cdvResource.Tag;
                                spdWorkOrderWithRes.ActiveSheet.Cells[e.Row, (int)ORDER.CHECK].Value = true;
                            }
                        }
                        
                    }
                    else
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(423), MSG_LEVEL.WARNING, true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Update_Order_Res(MPGC.MP_STEP_UPDATE) == false)
                return;
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (bCheckAll == false)
                {
                    for (int i = 0; i < spdWorkOrderWithRes.Sheets[0].RowCount; i++)
                    {
                        spdWorkOrderWithRes.Sheets[0].Cells[i, (int)ORDER.CHECK].Value = true;
                    }

                    bCheckAll = true;
                    btnCheckAll.Text = "Uncheck All";
                }
                else
                {
                    for (int i = 0; i < spdWorkOrderWithRes.Sheets[0].RowCount; i++)
                    {
                        spdWorkOrderWithRes.Sheets[0].Cells[i, (int)ORDER.CHECK].Value = false;
                    }

                    bCheckAll = false;
                    btnCheckAll.Text = "Check All";
                }

                MPCF.ConvertCaption(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
