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
using Infragistics.Win.UltraWinGrid;

namespace SOI.WIP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPEndLotBySN : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode ORDER = new TRSNode("ORDER");
        private TRSNode LOT = new TRSNode("LOT");

        private enum COL_LOT_LIST
        {
            END_TIME,
            LOT_ID,
            QTY
        }

        #endregion

        #region Constructor

        public frmWIPEndLotBySN()
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
        private void frmWIPEndLotBySN_Load(object sender, EventArgs e)
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
        private void frmWIPEndLotBySN_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                // Lot ID Focus
                MPCF.SetFocus(cdvWorkLine);

                bIsShown = true;
            }
        }

        /// <summary>
        /// Work Line CodeView Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(MPGC.MP_RAS_SUBAREA_CODE));

                // Display and Header Text Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };

                // Show CodeView and Get Return
                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                // Clear
                MPCF.FieldClear(this, cdvWorkLine);
                ORDER.Init();

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Work Order CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkOrder_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("View_Order_List_Detail_In");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FROM_DATE", "20010101010101");
                in_node.AddString("TO_DATE", "99910101010101");
                in_node.AddString("WORK_LINE", cdvWorkLine.Text);
                in_node.AddChar("ACTIVE_ORD_FLAG", 'Y');
                //in_node.AddString("MAT_ID", "");
                //in_node.AddInt("MAT_VER", "");
                //in_node.AddString("MAT_TYPE", "");
                //in_node.AddString("MAT_GRP", "");

                // Display and Header Text Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };
                string[] header = new string[] { "Order ID", "Order Desc" };

                // Show CodeView and Get Return
                cdvWorkOrder.Text = cdvWorkOrder.Show(cdvWorkOrder, "View Work Order List", "ORD", "ORD_View_Order_List_Detail", in_node, "ORDER_LIST", display, header, "Order ID");

                // Clear
                MPCF.FieldClear(this, cdvWorkLine, cdvWorkOrder);
                ORDER.Init();

                // Validation
                if (string.IsNullOrEmpty(cdvWorkOrder.Text) == true)
                {
                    return;
                }

                // View Work Order
                if (ViewOrder(cdvWorkOrder.Text) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Operation CodeView Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvEndOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FLOW", ORDER.GetString("FLOW"));

                // Display and Header Text Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };

                // Show CodeView and Get Return
                cdvEndOper.Text = cdvEndOper.Show(cdvEndOper, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "Oper");

                // Clear
                MPCF.FieldClear(cdvResId);
                MPCF.FieldClear(txtLotID);
                MPCF.FieldClear(gridInLotList);
                
                // Validation
                if (string.IsNullOrEmpty(cdvEndOper.Text) == true)
                {
                    return;
                }

                // Get Resource by M-F-O
                if (ViewResource(ORDER.GetString("MAT_ID"), ORDER.GetString("FLOW"), cdvEndOper.Text) == false)
                {
                    MPCF.SetFocus(cdvResId);
                    return;
                }

                // Focus
                MPCF.SetFocus(txtLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Resource Code View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResId_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvEndOper, false) == false)
                {
                    return;
                }

                // CodeView
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("MAT_ID", ORDER.GetString("MAT_ID"));
                in_node.AddString("FLOW", ORDER.GetString("FLOW"));
                in_node.AddString("OPER", cdvEndOper.Text);
                string[] header = new string[] { "Resource ID", "Resource Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };
                cdvResId.Text = cdvResId.Show(cdvResId, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");

                // Clear
                MPCF.FieldClear(txtLotID);
                MPCF.FieldClear(gridInLotList);

                // Validation
                if (string.IsNullOrEmpty(cdvResId.Text) == true)
                {
                    return;
                }

                // Focus
                MPCF.SetFocus(txtLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Work Order Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }

                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(cdvWorkOrder.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Order In Lot History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewOrderInLotHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }

                frmWIPViewOrderLotListPopup f = new frmWIPViewOrderLotListPopup();
                f.Owner = MPGV.gfrmMDI;
                f._orderID = cdvWorkOrder.Text;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        
        /// <summary>
        /// Lot ID Enter Key Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Validation (Only Enter Key)
                if (e.KeyCode == Keys.Enter)
                {
                    btnProcess_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Process Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvResId, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvEndOper, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }

                // View Lot (For Order ID Validation)
                if (ViewLot(txtLotID.Text, true) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();                    
                    return;
                }

                // End Lot
                if (EndLot() == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
                    return;
                }

                // View Lot (For End Lot Information)
                if (ViewLot(txtLotID.Text, false) == false)
                {
                    return;
                }

                // Bind
                if (AddLotInfo(gridInLotList, LOT) == false)
                {
                    return;
                }

                // Set Focus
                MPCF.FieldClear(txtLotID);
                MPCF.SetFocus(txtLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Functions
 
        /// <summary>
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewOrder(string orderId)
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

            try
            {
                // Clear
                ORDER.Init();

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", orderId);
                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                ORDER = out_node;
                txtWorkOrder.Text = out_node.GetString("ORDER_ID") + " : " + out_node.GetString("ORDER_DESC");
                txtMaterial.Text = out_node.GetString("MAT_ID") + " : " + out_node.GetString("MAT_DESC");
                txtCustomer.Text = out_node.GetString("CUSTOMER_ID");
                txtDueDate.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
                lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
                lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));;
                lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Lot List by Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <param name="sOper"></param>
        /// <param name="sResId"></param>
        /// <returns></returns>
        private bool ViewLotListByOrder(string sOrderId, string sOper, string sResId)
        {
            try
            {
                TRSNode in_node = new TRSNode("SQL_IN");
                TRSNode out_node = new TRSNode("SQL_OUT");
                List<TRSNode> row_list;
                List<TRSNode> col_list;
                StringBuilder sb;

                if (gridInLotList.Rows.Count > 0)
                {
                    DataTable dt_temp = gridInLotList.GetDataSource();
                    dt_temp.Clear();
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCF.Trim(sResId) == "")
                {
                    sResId = " ";
                }

                sb = new StringBuilder();

                sb.Append("SELECT A.TRAN_TIME, A.LOT_ID, B.QTY_1 FROM MWIPLOTMVH A, MWIPLOTHIS B ");
                sb.Append("WHERE A.LOT_ID = B.LOT_ID ");
                sb.Append("AND A.HIST_SEQ = B.HIST_SEQ ");
                sb.Append("AND A.HIST_DEL_FLAG = ' ' ");
                sb.Append("AND A.FACTORY = '" + MPGV.gsFactory + "' ");
                sb.Append("AND A.OPER = '" + sOper + "' ");
                sb.Append("AND A.TRAN_CODE = 'END' ");
                sb.Append("AND B.END_RES_ID = '" + sResId + "' ");
                sb.Append("AND B.ORDER_ID = '" + sOrderId + "' ");
                sb.Append("ORDER BY A.TRAN_TIME DESC, A.LOT_ID ASC ");

                in_node.AddString("SQL", sb.ToString());

                //ObservableCollection<OrderInLotInfo> liList = new ObservableCollection<OrderInLotInfo>();

                if (MPCF.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                row_list = out_node.GetList("ROWS");
                foreach (TRSNode cols in row_list)
                {
                    col_list = cols.GetList("COLS");
                    // 1) Get data Source 
                    DataTable dt = gridInLotList.GetDataSource();
                    // 2) New Row
                    DataRow dr = dt.NewRow();

                    // 3) Data Insert

                    dr["IN_TIME"] = MPCF.MakeDateFormat(col_list[0].GetString("DATA"));
                    dr["LOT_ID"] = col_list[1].GetString("DATA");
                    dr["QTY_1"] = MPCF.ToDbl(col_list[2].GetString("DATA"));

                    // 4) New Row Add
                    dt.Rows.Add(dr);

                }

                // 5) Bind
                gridInLotList.DataBind();

                //_model.OrderInLotList = liList;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Vew Resource List
        /// </summary>
        /// <param name="sWorkLine"></param>
        /// <param name="sOper"></param>
        /// <returns></returns>
        private bool ViewResourceList(string sWorkLine, string sOper)
        {
            try
            {
                //TRSNode in_node = new TRSNode("SQL_IN");
                //TRSNode out_node = new TRSNode("SQL_OUT");
                //List<TRSNode> row_list;
                //List<TRSNode> col_list;
                //StringBuilder sb;

                //MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';

                //sb = new StringBuilder();

                //sb.Append("SELECT A.RES_ID, A.RES_DESC FROM MRASRESDEF A, MRASRESMFO B ");
                //sb.Append("WHERE A.FACTORY = B.FACTORY ");
                //sb.Append("AND A.RES_ID = B.RES_ID ");
                //sb.Append("AND A.FACTORY = '" + MPGV.gsFactory + "' ");
                //sb.Append("AND A.SUB_AREA_ID = '" + sWorkLine + "' ");
                //sb.Append("AND A.DELETE_FLAG = ' ' ");
                //sb.Append("AND B.MAT_ID = ' ' ");
                //sb.Append("AND B.FLOW = ' ' ");
                //sb.Append("AND B.OPER = '" + sOper + "' ");
                //sb.Append("ORDER BY A.RES_ID ASC");

                //in_node.AddString("SQL", sb.ToString());

                ////ObservableCollection<CodeModel> liList = new ObservableCollection<CodeModel>();

                //do
                //{
                //    if (MPCF.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                //    {
                //        return false;
                //    }

                //    row_list = out_node.GetList("ROWS");
                //    foreach (TRSNode cols in row_list)
                //    {
                //        col_list = cols.GetList("COLS");
                //        //liList.Add(new CodeModel(col_list[0].GetString("DATA"), col_list[1].GetString("DATA")));
                //        cboResID.Items.Add(col_list[0].GetString("DATA"), col_list[0].GetString("DATA"));
                //        if (row_list.Count == 1)
                //        {
                //            cboResID.Text = (string)cboResID.Items[0].DataValue;
                //        }
                //    }

                //    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                //} while (in_node.GetInt("NEXT_ROW") > 0);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 설비 정보를 M-F-O에 따라 조회하고 단건인 경우에만 자동으로 bind합니다.
        /// </summary>
        /// <param name="matId"></param>
        /// <param name="flow"></param>
        /// <param name="oper"></param>
        /// <returns></returns>
        private bool ViewResource(string matId, string flow, string oper)
        {
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("MAT_ID", matId);
                in_node.AddString("FLOW", flow);
                in_node.AddString("OPER", oper);
                if (MPCF.CallService("RAS", "RAS_View_Resource_List", in_node, ref out_node) == false)
                {
                    return false;                
                }

                // Validation (Only 1 Resource)
                if (out_node.GetList("RES_LIST") == null
                    || out_node.GetList("RES_LIST").Count != 1)
                {
                    return false;
                }
                
                // Bind
                cdvResId.Text = out_node.GetList("RES_LIST")[0].GetString("RES_ID");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLot(string lotId, bool orderIdCheck)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");

            try
            {
                // Clear
                LOT.Init();

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(lotId));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }

                if (orderIdCheck == true)
                {
                    if (LOT.GetString("ORDER_ID") != cdvWorkOrder.Text)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(82), MSG_LEVEL.ERROR, false);
                        return false;
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

        /// <summary>
        /// 해당 Lot 정보를 Grid에 Bind 합니다.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="lotInfo"></param>
        /// <returns></returns>
        private bool AddLotInfo(SOIGrid grid, TRSNode lotInfo)
        {
            try
            {
                // Validation
                if (grid == null || lotInfo == null)
                {
                    return false;
                }

                // Get Table
                DataTable dt = grid.GetDataSource();

                // Validation
                if (dt == null)
                {
                    return false;
                }

                // Add Lot
                DataRow dr = dt.NewRow();
                dr[(int)COL_LOT_LIST.END_TIME] = MPCF.MakeDateFormat(lotInfo.GetString("END_TIME"));
                dr[(int)COL_LOT_LIST.LOT_ID] = lotInfo.GetString("LOT_ID");
                dr[(int)COL_LOT_LIST.QTY] = MPCF.MakeNumberFormat(lotInfo.GetDouble("QTY_1"));
                dt.Rows.Add(dr);
                grid.SetDataSource(dt);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// End Lot
        /// </summary>
        /// <returns></returns>
        private bool EndLot()
        {
            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("END_LOT_OUT");
            TRSNode res_list;

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", cdvEndOper.Text);                
                in_node.AddString("RES_ID", cdvResId.Text);
                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                res_list = in_node.AddNode("RES_LIST");
                res_list.AddString("RES_ID", cdvResId.Text);
                res_list.AddDouble("LOT_QTY_1", LOT.GetDouble("QTY_1"));
                //res_list.AddDouble("LOT_QTY_2", MPCF.Trim(spdResource.ActiveSheet.Cells[i, (int)RES_COL.QTY_2].Value));
                //res_list.AddDouble("LOT_QTY_3", MPCF.Trim(spdResource.ActiveSheet.Cells[i, (int)RES_COL.QTY_3].Value));                

                if (MPCF.CallService("WIP", "WIP_End_Lot_Ext", in_node, ref out_node) == false)
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
    }
}
