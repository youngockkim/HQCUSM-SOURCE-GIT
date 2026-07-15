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

namespace SOI.SMT
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmSMTInputQCLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private TRSNode outWorkOrder;

        #endregion

        #region Constructor

        public frmSMTInputQCLot()
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
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // Grid Init
            gridPCBId.InitDataSource();

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
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                MPCF.SetFocus(cdvLineID);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Line ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(this);
                FieldClearInForm();

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "SUB_AREA");
                in_node.AddString("DATA_2", "SMT");

                // CodeView Column Header Setup
                string[] header = new string[] { "Line ID", "Line Description", "Lane Type" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_4" };

                // Show
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Work Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (string.IsNullOrEmpty(cdvLineID.Text) == false)
                {
                    if(cdvLineID.returnDatas.Count > 0)
                    {
                        if (cdvLineID.returnDatas[2].Equals("S"))
                        {
                            cboLane.SelectedIndex = 0;
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Order ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOrderID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_WORK_ORDER_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLineID.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Order ID", "Description", "Board Type", "Mat ID" };

                // CodeView Display Column Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC", "BOARD_TYPE", "MAT_ID" };

                // Show
                cdvOrderID.Text = cdvOrderID.Show(cdvOrderID, "Order ID", "SMT", "SMT_View_Work_Order_List", in_node, "ORDER_LIST", display, header, "ORDER_ID");

                // Field Clear
                MPCF.FieldClear(this, cdvLineID, cboLane, cdvOrderID, null, null, true);

                if (string.IsNullOrEmpty(cdvOrderID.Text) == false)
                {
                    if (ViewWorkOrder(cdvOrderID.Text) == false)
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

        /// <summary>
        /// Operation CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLineID.Text);
                in_node.AddString("ORDER_ID", cdvOrderID.Text);
                in_node.AddString("OPER_GRP", "QC");

                // CodeView Column Header Setup
                string[] header = new string[] { "Operation", "Operation Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };

                // Show
                cdvOper.Text = cdvOper.Show(cdvOper, "Operation", "SMT", "SMT_View_Oper_List_By_Grp", in_node, "LIST", display, header, "OPER");

                if (string.IsNullOrEmpty(cdvOper.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Lot ID Generate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_LOT_ID_GEN_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_ID_GEN_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';                
                in_node.AddString("ORDER_ID", cdvOrderID.Text);

                if (MPCF.CallService("SMT", "SMT_View_Work_Order", in_node, ref out_node) == false)
                {
                    return;
                }

                txtLotID.Text = out_node.GetString("ORDER_LOT_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Lot ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnGen.Enabled == true)
                {
                    return;
                }

                if (MPCF.Trim(txtLotID.Text) != "")
                {
                    try
                    {
                        TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                        TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = '1';
                        in_node.AddString("LOT_ID", txtLotID.Text);

                        if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                        {
                            return;
                        }

                        if (AddToGrid(txtLotID.Text) == false)
                        {
                            return;
                        }

                        txtScanQty.Text = gridPCBId.Rows.Count.ToString();

                        txtLotID.Text = string.Empty;
                        MPCF.SetFocus(txtLotID);                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                    }
                }
            }
        }

        /// <summary>
        /// Selected Lot ID Remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = gridPCBId.GetDataSource();

                // 2) Remove Row
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)dt.Rows[i][0] == true)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }

                // 3) Bind
                gridPCBId.DataBind();

                txtScanQty.Text = gridPCBId.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            MPCF.FieldClear(this);
            FieldClearInForm();
        }

        /// <summary>
        /// Input QC Lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (InputQCLot() == false)
            {
                return;
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <returns></returns>
        private void FieldClearInForm()
        {
            btnGen.Enabled = false;
            txtLotQty.Enabled = false;
            tlpScanQty.Visible = true;
            tlpLotQty.Visible = false;
            gridPCBId.Visible = true;
            btnDel.Visible = true;
            outWorkOrder = null;
        }

        /// <summary>
        /// View Work Order by work order ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private bool ViewWorkOrder(string orderId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", orderId);

                if (MPCF.CallService("SMT", "SMT_View_Work_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                outWorkOrder = out_node;

                txtOrderDesc.Text = out_node.GetString("ORDER_DESC");
                txtOrderMat.Text = out_node.GetString("MAT_ID");
                lblOrderQty.Text = out_node.GetDouble("ORDER_QTY").ToString("#,###,##0.###");
                lblInQty.Text = out_node.GetDouble("IN_QTY").ToString("#,###,##0.###");
                lblOutQty.Text = out_node.GetDouble("OUT_QTY").ToString("#,###,##0.###");
                lblLossQty.Text = out_node.GetDouble("LOSS_QTY").ToString("#,###,##0.###");

                if (out_node.GetChar("BOARD_TYPE") == 'M')
                {
                    btnGen.Enabled = false;
                    txtLotQty.Enabled = false;
                    txtScanQty.Text = "0";
                    tlpScanQty.Visible = true;
                    tlpLotQty.Visible = false;
                    gridPCBId.Visible = true;
                    btnDel.Visible = true;
                }
                else
                {
                    btnGen.Enabled = true;
                    txtLotQty.Enabled = true;
                    txtScanQty.Text = string.Empty;
                    tlpScanQty.Visible = false;
                    tlpLotQty.Visible = true;
                    gridPCBId.Visible = false;
                    btnDel.Visible = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("View Work Order() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Grid에 데이터를 저장합니다.
        /// </summary>
        /// <returns></returns>
        private bool AddToGrid(string lotId)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = gridPCBId.GetDataSource();

                // 2) Exist Data Check
                bool bFound = false;
                foreach (DataRow dr in dt.Rows)
                {
                    if (lotId.Equals(dr["lotId"]))
                    {
                        bFound = true;
                        break;
                    }
                }

                if (bFound == true)
                {
                    return false;
                }

                // 3) New Row
                DataRow drNew = dt.NewRow();

                // 4) Data
                drNew[0] = false;
                drNew[1] = lotId;

                // 5) New Row Add
                dt.Rows.Add(drNew);

                // 6) Bind
                gridPCBId.DataBind();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("Add To Grid() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Input QC Lot
        /// </summary>
        /// <returns></returns>
        private bool InputQCLot()
        {
            try
            {
                // CheckValue
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cboLane, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cdvOper, false) == false)
                {
                    return false;
                }

                TRSNode in_node = new TRSNode("VIEW_INPUT_QC_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_INPUT_QC_LOT_OUT");

                MPCF.SetInMsg(in_node);

                // Board Type Compare
                if (outWorkOrder != null && outWorkOrder.GetChar("BOARD_TYPE") == 'M')
                {
                    in_node.ProcStep = '2';
                    SetList(in_node);
                }
                else
                {
                    in_node.ProcStep = '3';
                    in_node.AddString("LOT_ID", txtLotID.Text);
                }

                in_node.AddString("OPER", cdvOper.Text);
                in_node.AddString("ORDER_ID", cdvOrderID.Text);
                
                if (MPCF.CallService("SMT", "SMT_Input_Qc_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                if (ViewWorkOrder(cdvOrderID.Text) == false)
                {
                    return false;
                }

                // Board Type Compare
                if (outWorkOrder != null && outWorkOrder.GetChar("BOARD_TYPE") == 'M')
                {
                    MPCF.FieldClear(gridPCBId);
                    txtScanQty.Text = "0";
                    MPCF.SetFocus(txtLotID);
                }
                else
                {
                    txtLotID.Text = string.Empty;
                    MPCF.SetFocus(txtLotID);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("InputQCLot() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Set List
        /// </summary>
        /// <param name="in_node"></param>
        /// <returns></returns>
        private bool SetList(TRSNode in_node)
        {
            TRSNode list_in;

            // DataTable 호출
            DataTable dt = gridPCBId.GetDataSource();

            if (dt.Rows.Count < 1)
            {
                return true;
            }
            list_in = in_node.AddNode("LOT_LIST");

            MPCF.SetInMsg(list_in);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //list_item = list_in.AddNode("QC_LOT");

                list_in.AddString("LOT_ID", dt.Rows[i]["lotId"].ToString());
            }

            return true;
        }

        #endregion
    }
}
