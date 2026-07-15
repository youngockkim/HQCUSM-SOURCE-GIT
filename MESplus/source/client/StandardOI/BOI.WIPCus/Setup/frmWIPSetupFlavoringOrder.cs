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
using System.Collections;
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
    public partial class frmWIPSetupFlavoringOrder : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum DummyList
        {
            SELECT,
            DUMMY_MAT_ID,
            P_MAT_BOM_TYPE,
            DUMMY_MAT_DESC
        }

        private enum DummyMatList
        {
            MAT_ID,
            MAT_DESC,
            UNIT,
            RESTUL_QTY
        }

        private enum DummyOrderList
        {
            SELECT,
            ORD_DATE,
            ORDER_ID,
            MAT_ID,
            MAT_DESC,
            ORD_QTY_1,
            ORD_QTY,
            UNIT_1,
            LINE_ID,
            RES_ID,
            ORD_START_TIME,
            ORD_END_TIME,
            ORDER_STATUS
        }

        #endregion

        #region Constructor

        public frmWIPSetupFlavoringOrder()
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


            // 활성화
            this.Activate();

            dtpOrderDate.Value = System.DateTime.Today;
            dtpWorkDate.Value = System.DateTime.Today;

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
                GetDefaultValueFromReg();
                bIsShown = true;

            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim((string)cdvMatId.Tag) == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(448), MSG_LEVEL.ERROR, false);
                    cdvMatId.Focus();
                    return;
                }
                else
                {
                    if (ClearSpreadList() == false)
                    {
                        return;
                    }
                }
                if (View_Dummy_Material_List((string)cdvMatId.Tag, "DM", MPCF.Trim(txtBomMatType.Text)) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

        }

        private void lisDummyList_RowFocusChanged(int iprvRow, int icurRow)
        {
            try
            {
                if (icurRow >= 0)
                {
                    string mat_id = string.Empty;
                    string mat_bom_type = string.Empty;

                    spdDummyList.Sheets[0].ActiveRowIndex = icurRow;
                    spdDummyList.Sheets[0].SetActiveCell(icurRow, 0, true);
                    mat_id = MPCF.Trim(spdDummyList.Sheets[0].Cells[icurRow, (int)DummyList.DUMMY_MAT_ID].Value);
                    mat_bom_type = MPCF.Trim(spdDummyList.Sheets[0].Cells[icurRow, (int)DummyList.P_MAT_BOM_TYPE].Value);
                    if (View_Dummy_Material_Raw_Material_List(mat_id, mat_bom_type) == false)
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("lisDummyList_RowFocusChanged() : " + ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("DUMMY_ORDER_IN");
            TRSNode out_node = new TRSNode("DUMMY_ORDER_OUT");
            TRSNode list_item;

            string s_ord_date = string.Empty;
            string s_p_mat_bom_type = string.Empty;
            string s_line_id = string.Empty;
            string s_mat_id = string.Empty;
            string s_work_date = string.Empty;
            double d_lot_qty = 0.0;
            double d_ord_qty = 0.0;
            int i_check_count = 0;

            if (MPCF.ToDbl(numCreateLotQty.Value) == 0.0) {
                MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.ERROR, false);
                numCreateLotQty.Focus();
                return;
            }

            if (MPCF.ToDbl(numStandardMixQty.Value) == 0.0)
            {
                MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.ERROR, false);
                numStandardMixQty.Focus();
                return;
            }

            if (MPCF.Trim((string)cdvLine.Text) == "")
            {
                cdvLine.Focus();
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                return;
            }
            
            // 생성 lot 개수
                        
            try
            {
                for (int i = 0; i < spdDummyList.Sheets[0].RowCount; i++)
                {
                    if (spdDummyList.Sheets[0].Cells[i, (int)DummyList.SELECT].Value == null)
                    {
                        continue;
                    }
                    else if ((bool)spdDummyList.Sheets[0].Cells[i, (int)DummyList.SELECT].Value == true)
                    {
                        i_check_count++;
                        s_mat_id = MPCF.Trim(spdDummyList.Sheets[0].Cells[i, (int)DummyList.DUMMY_MAT_ID].Value);
                        s_p_mat_bom_type = MPCF.Trim(spdDummyList.Sheets[0].Cells[i, (int)DummyList.P_MAT_BOM_TYPE].Value);
                        s_ord_date = MPCF.Trim(dtpWorkDate.GetValueAsString(8));
                        s_line_id = (string)cdvLine.Tag;
                        d_lot_qty = MPCF.ToDbl(numCreateLotQty.Value); // 생성 lot 개수
                        d_ord_qty = MPCF.ToDbl(numStandardMixQty.Value); // 작업지시수량
                        s_work_date = MPCF.Trim(dtpWorkDate.GetValueAsDateTime().ToString("yyyyMMdd"));
                        list_item = in_node.AddNode("DUMMY_LIST");
                        list_item.AddString("P_MAT_ID", s_mat_id);
                        list_item.AddString("LINE_ID", s_line_id);
                        list_item.AddString("ORD_DATE", s_work_date);
                        list_item.AddChar("P_MAT_BOM_TYPE", s_p_mat_bom_type);
                        list_item.AddDouble("ORD_QTY", d_lot_qty);
                        list_item.AddDouble("ORD_QTY_1", d_ord_qty);
                        list_item.AddString("UNIT_1", "EA");

                        //CWIP8610-004

                        TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
                        DataTable dt = null;

                        dvcArgu[0].sCondtion_ID = "FACTORY";
                        dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                        dvcArgu[1].sCondtion_ID = "MAT_ID";
                        dvcArgu[1].sCondition_Value = MPCF.Trim(s_mat_id);

                        if (TPDR.GetDataOne("", ref dt, "CWIP8610-004", dvcArgu, false, false) == false)
                        {
                            if (dt != null)
                                dt.Dispose();

                            GC.Collect();
                            //return;
                        }
                        else
                        {
                            list_item.AddString("FLOW", dt.Rows[0][0].ToString()); //FLOW
                            list_item.AddString("OPER", dt.Rows[0][1].ToString()); // FIRST OPER
                        }
                    }
                }
                if (i_check_count > 0)
                {
                    if (Update_Dummy_Order(in_node, '1') == false)
                    {
                        return;
                    }
                    btnView.PerformClick();
                }
                else
                {
                    MPCF.ShowMessage(MPCF.GetMessage(447), MSG_LEVEL.ERROR, false);
                    return;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {

            try
            {
                BICF.ViewLine(cdvLine, "");
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(53), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            TRSNode in_node = new TRSNode("DUMMY_ORDER_IN");
            TRSNode list_item;
            string s_order_id = string.Empty;
            int i_check_count = 0;

            for (int i = 0; i < spdWorkOrder.Sheets[0].RowCount; i++)
            {
                if (spdWorkOrder.Sheets[0].Cells[i, (int)DummyOrderList.SELECT].Value == null)
                {
                    continue;
                }
                else if ((bool)spdWorkOrder.Sheets[0].Cells[i, (int)DummyOrderList.SELECT].Value == true)
                {
                    i_check_count++;
                    list_item = in_node.AddNode("DUMMY_LIST");
                    s_order_id = MPCF.Trim(spdWorkOrder.Sheets[0].Cells[i, (int)DummyOrderList.ORDER_ID].Value);
                    list_item.AddString("ORDER_ID", s_order_id);
                }
            }
            if (i_check_count > 0)
            {
                if (Update_Dummy_Order(in_node, '2') == false)
                {
                    return;
                }
                btnView.PerformClick();
            }
            else
            {
                MPCF.ShowMessage(MPCF.GetMessage(422), MSG_LEVEL.ERROR, false);
                return;
            }

        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                BOI.WIPCus.Popup.frmWIPSelectBatchingOrderPopup frm = new BOI.WIPCus.Popup.frmWIPSelectBatchingOrderPopup();
             
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (ClearSpreadList() == false)
                    {
                        return;
                    }
                    numStandardMixQty.Value = frm.DOrderQty;
                    cdvMatId.Tag = frm.SMatId;
                    cdvMatId.Text = frm.SMatDesc;
                    txtBomMatType.Text = frm.SMatBomType;

                    if (View_Dummy_Material_List(frm.SMatId, "DM", frm.SMatBomType) == false)
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

        private void cdvMatId_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                // CodeView Column Header Setup
                string[] header = new string[] { "P_MAT_ID", "P_MAT_BOM_TYPE", "MAT_DESC" };

                // CodeView Display Column Setup
                string[] display = new string[] { "P_MAT_ID", "P_MAT_BOM_TYPE", "MAT_DESC" };
                cdvMatId.Text = cdvMatId.Show(cdvMatId, "Material List", "CWIP8610-001", dvcArgu, display, header, "MAT_DESC", -1);
                cdvMatId.Tag = "";

                if (MPCF.Trim(cdvMatId.Text) != "")
                {
                    if (cdvMatId.returnDatas.Count > 0)
                    {
                        cdvMatId.Tag = cdvMatId.returnDatas[0];
                        txtBomMatType.Text = cdvMatId.returnDatas[1];

                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion


        #region Function

        public void GetDefaultValueFromReg()
        {
            try
            {
                txtBomMatType.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtBomMatType.Text"));
                cdvMatId.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvMatId.Tag"));
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
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtBomMatType.Text", MPCF.Trim(txtBomMatType.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvMatId.Tag", MPCF.Trim(cdvMatId.Tag));
           

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        private bool ClearSpreadList()
        {
            try
            {
                MPCF.ClearList(spdDummyList);
                MPCF.ClearList(spdDummyBomList);
                MPCF.ClearList(spdWorkOrder);
                //MPCF.FieldClear(numCreateLotQty);
                //MPCF.FieldClear(numStandardMixQty);
                //MPCF.FieldClear(cdvLine);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool View_Dummy_Material_List(string sMatId, string sMatType, string sMatBomType)
        {

            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            //string s_sql = "";

            int i = 0;
            try
            {
                spdDummyList_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "MAT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sMatId);

                dvcArgu[2].sCondtion_ID = "MAT_TYPE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(sMatType);

                dvcArgu[3].sCondtion_ID = "MAT_BOM_TYPE";
                dvcArgu[3].sCondition_Value = sMatBomType;

                if (TPDR.GetDataOne("", ref dt, "CWIP8610-002", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdDummyList_Sheet1.RowCount++;

                    spdDummyList_Sheet1.Cells[i, (int)DummyList.DUMMY_MAT_ID].Value = dt.Rows[i][0].ToString();
                    spdDummyList_Sheet1.Cells[i, (int)DummyList.DUMMY_MAT_DESC].Value = dt.Rows[i][1].ToString();
                    spdDummyList_Sheet1.Cells[i, (int)DummyList.P_MAT_BOM_TYPE].Value = dt.Rows[i][2].ToString();
                }

                //MPCF.FitColumnHeader(spdDummyList);
                lisDummyList_RowFocusChanged(0, 0);
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() != null)
                    {
                        View_Dummy_Material_Order_List(dt.Rows[i][0].ToString(), MPCF.Trim(dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd")), sMatBomType);
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


        private bool View_Dummy_Material_Raw_Material_List(string p_mat_id, string p_mat_bom_type)
        {

            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            //string s_sql = "";

            int i = 0;
            try
            {
                spdDummyBomList_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "P_MAT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(p_mat_id);

                dvcArgu[2].sCondtion_ID = "P_MAT_BOM_TYPE";
                dvcArgu[2].sCondition_Value = p_mat_bom_type.Substring(0, 1);


                if (TPDR.GetDataOne("", ref dt, "CWIP2300-004", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdDummyBomList_Sheet1.RowCount++;

                    spdDummyBomList_Sheet1.Cells[i, (int)DummyMatList.MAT_ID].Value = dt.Rows[i][2].ToString();
                    spdDummyBomList_Sheet1.Cells[i, (int)DummyMatList.MAT_DESC].Value = dt.Rows[i][3].ToString();
                    spdDummyBomList_Sheet1.Cells[i, (int)DummyMatList.RESTUL_QTY].Value = dt.Rows[i][4].ToString();
                    spdDummyBomList_Sheet1.Cells[i, (int)DummyMatList.UNIT].Value = dt.Rows[i][5].ToString();

                }
                //MPCF.FitColumnHeader(spdDummyBomList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        private bool View_Dummy_Material_Order_List(string mat_id, string ord_date, string mat_bom_type)
        {

            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            int i_row;
            try
            {
                //spdWorkOrder_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "MAT_BOM_TYPE";
                dvcArgu[1].sCondition_Value = MPCF.Trim(mat_bom_type);

                dvcArgu[2].sCondtion_ID = "MAT_ID";
                dvcArgu[2].sCondition_Value = mat_id;

                dvcArgu[3].sCondtion_ID = "ORD_DATE";
                dvcArgu[3].sCondition_Value = MPCF.Trim(ord_date);

                if (TPDR.GetDataOne("", ref dt, "CWIP8610-003", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    i_row = spdWorkOrder_Sheet1.RowCount++;
                
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.ORD_DATE].Value = MPCF.ToDate((string)dt.Rows[i]["ORD_DATE"]);
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.MAT_ID].Value = dt.Rows[i]["MAT_ID"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.ORD_QTY].Value = dt.Rows[i]["ORD_QTY"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.ORD_QTY_1].Value = dt.Rows[i]["ORD_QTY_1"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.UNIT_1].Value = dt.Rows[i]["UNIT_1"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.LINE_ID].Value = dt.Rows[i]["LINE_ID"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.RES_ID].Value = dt.Rows[i]["RES_ID"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.ORD_START_TIME].Value = dt.Rows[i]["ORD_START_TIME"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.ORD_END_TIME].Value = dt.Rows[i]["ORD_END_TIME"];
                    spdWorkOrder_Sheet1.Cells[i_row, (int)DummyOrderList.ORDER_STATUS].Value = dt.Rows[i]["ORDER_STATUS"];
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

        private bool Update_Dummy_Order(TRSNode in_node, char c_step)
        {
            TRSNode out_node = new TRSNode("DUMMY_ORDER_OUT");
            
            try
            {
                MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                in_node.Factory = MPGV.gsFactory;
                in_node.ProcStep = c_step;
                in_node.UserID = MPGV.gsUserID;

                if (MPCF.CallService("BWIP", "BWIP_Update_Dummy_Order", in_node, ref out_node) == false)
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

        #endregion

        private void frmWIPSetupFlavoringOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetDefaultValueToReg();
        }


    }
}
