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
using System.Collections;

namespace SOI.WIP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPCreateLotBySN : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
                
        private TRSNode ORDER = new TRSNode("ORDER");
        private TRSNode LOT = new TRSNode("LOT");

        private string _flowOfOrder;

        private enum COL_LOT_LIST
        {
            INPUT_TIME,
            LOT_ID,
            QTY
        }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public frmWIPCreateLotBySN()
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
        private void frmWIPCreateLotBySN_Load(object sender, EventArgs e)
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
        private void frmWIPCreateLotBySN_Shown(object sender, EventArgs e)
        {
            // (Required)
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                MPCF.SetFocus(cdvWorkLine);

                // (Required)
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
                _flowOfOrder = "";

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
        /// Work Order CodeView Event
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
                in_node.AddString("MAT_ID", "");
                in_node.AddInt("MAT_VER", "");
                in_node.AddString("MAT_TYPE", "");
                in_node.AddString("MAT_GRP", "");

                // Display and Header Text Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };
                string[] header = new string[] { "Order ID", "Order Desc" };

                // Show CodeView and Get Return
                cdvWorkOrder.Text = cdvWorkOrder.Show(cdvWorkOrder, "View Work Order List", "ORD", "ORD_View_Order_List_Detail", in_node, "ORDER_LIST", display, header, "Order ID");

                // Validation
                if (string.IsNullOrEmpty(cdvWorkOrder.Text) == true)
                {
                    return;
                }

                // Clear
                MPCF.FieldClear(this, cdvWorkLine, cdvWorkOrder);
                ORDER = null;
                _flowOfOrder = "";

                // View Order
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
        /// In Oper CodeView Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FLOW", _flowOfOrder);

                // Display and Header Text Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };

                // Show CodeView and Get Return
                cdvInOper.Text = cdvInOper.Show(cdvInOper, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "Oper");

                // Validation
                if (string.IsNullOrEmpty(cdvInOper.Text) == true)
                {
                    return;
                }

                // Clear
                MPCF.FieldClear(gridInLotList);
                    
                // Focus
                MPCF.FieldClear(txtLotID);
                MPCF.SetFocus(txtLotID);
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
                if (e.KeyCode == Keys.Enter && MPCF.Trim(txtLotID.Text) != "")
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
                // 1) Validation
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvWorkOrder, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvInOper, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // 2) Create Lot
                if (CreateLot() == false)
                {
                    txtLotID.SelectAll();
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                // 3) Focus
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
                if (MPCF.CheckValue(cdvWorkOrder, false) == false) return;

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

                // View Popup
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

        #endregion

        #region Functions

        /// <summary>
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewOrder(string sOrderId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", sOrderId);

                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                ORDER = out_node;

                txtWorkOrder.Text = out_node.GetString("ORDER_ID") + " : " + out_node.GetString("ORDER_DESC");
                txtMaterial.Text = out_node.GetString("MAT_ID") + " : " + out_node.GetString("MAT_DESC");
                txtCustomer.Text = out_node.GetString("CUSTOMER_ID");
                txtDueDate.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
                lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
                lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));;
                lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

                _flowOfOrder = out_node.GetString("FLOW");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Lot List By Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <param name="sLotInOper"></param>
        /// <returns></returns>
        private bool ViewLotListByOrder(string sOrderId, string sLotInOper)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_HISTORY_BY_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_HISTORY_BY_ORDER_OUT");
                ArrayList lisData = new ArrayList();

                sLotInOper = MPCF.Trim(sLotInOper);
                if (gridInLotList.Rows.Count > 0)
                {
                    DataTable dt_temp = gridInLotList.GetDataSource();
                    dt_temp.Clear();
                }
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("ORDER_ID", sOrderId);
                in_node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_CREATE);
                in_node.AddString("OPER", sLotInOper);
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);

                do
                {
                    if (MPCF.CallService("WIP", "WIP_View_Lot_History_By_Order", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisData.Add(out_node);


                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);


                foreach (object obj in lisData)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        DataTable dt = gridInLotList.GetDataSource();
                        // 2) New Row
                        DataRow dr = dt.NewRow();

                        // 3) Data Insert

                        dr["CREATE_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                        dr["LOT_ID"] = out_node.GetList(0)[i].GetString("LOT_ID");
                        dr["QTY_1"] = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("QTY_1"));
                        // 4) New Row Add
                        dt.Rows.Add(dr);
                        if (dt.Rows.Count >= 10)
                        {
                            break;
                        }
                    }
                }
                // 5) Bind
                gridInLotList.DataBind();

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
        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");

            try
            {
                // Clear
                LOT.Init();
                
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    LOT.Init();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
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

                DataRow dr = dt.NewRow();
                dr[(int)COL_LOT_LIST.INPUT_TIME] = MPCF.MakeDateFormat(lotInfo.GetString("CREATE_TIME"));
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
        /// Create Lot
        /// </summary>
        /// <returns></returns>
        private bool CreateLot()
        {
            TRSNode in_node = new TRSNode("CREATE_LOT_IN");
            TRSNode out_node = new TRSNode("CREATE_LOT_OUT");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotID.Text);
                //in_node.AddString("LOT_DESC", MPCF.Trim(txtLotDesc.Text));
                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}
                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddString("MAT_ID", ORDER.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", ORDER.GetInt("MAT_VER"));
                in_node.AddString("FLOW", ORDER.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", ORDER.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", cdvInOper.Text);
                in_node.AddDouble("QTY_1", ORDER.GetDouble("QTY"));
                in_node.AddChar("LOT_TYPE", ORDER.GetChar("LOT_TYPE"));
                in_node.AddString("CREATE_CODE", ORDER.GetString("CREATE_CODE"));
                in_node.AddString("OWNER_CODE", ORDER.GetString("OWNER_CODE"));
                in_node.AddChar("LOT_PRIORITY", ORDER.GetChar("LOT_PRIORITY"));
                in_node.AddString("DUE_TIME", ORDER.GetString("ORG_DUE_TIME"));                
                in_node.AddChar("IN_CASE", '1');
                in_node.AddString("ORDER_ID", ORDER.GetString("ORDER_ID"));
                if (MPCF.CallService("ORD", "ORD_Create_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // View Lot (Get Lot Information)
                if (ViewLot(txtLotID.Text) == false)
                {
                    return false;
                }

                // Add Lot (Refresh Lot List)
                if (AddLotInfo(gridInLotList, LOT) == false)
                {
                    return false;
                }

                // View Order (Refresh Work Order Information)
                if (ViewOrder(cdvWorkOrder.Text) == false)
                {
                    return false;
                }

                // Clear
                MPCF.FieldClear(txtLotID);
                MPCF.SetFocus(txtLotID);

                // Success
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
