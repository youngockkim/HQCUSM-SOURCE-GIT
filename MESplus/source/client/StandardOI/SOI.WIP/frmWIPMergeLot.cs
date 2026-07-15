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
    public partial class frmWIPMergeLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode LOT;
        private TRSNode ORDER;

        private enum COL_MERGE_LOT_LIST
        { 
            CHK = 0,
            SEQ,
            SOURCE_LOT_ID,
            MAT_ID,
            MAT_VER,
            FLOW,
            FLOW_SEQ_NUM,
            OPER,
            QTY_1,
            LAST_ACTIVE_HIST_SEQ
        }

        #endregion

        #region Constructor

        public frmWIPMergeLot()
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
        private void frmWIPMergeLot_Load(object sender, EventArgs e)
        {
            // Init
            LOT = new TRSNode("TARGET_LOT_INFO");
            ORDER = new TRSNode("ORDER_INFO");

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
        private void frmWIPMergeLot_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                // Lot ID Focus
                MPCF.SetFocus(txtTargetLotID);

                bIsShown = true;
            }
        }

        /// <summary>
        /// Target Lot ID에서 엔터키 입력 시 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && MPCF.Trim(txtTargetLotID.Text) != "")
                {
                    if (ViewLot(txtTargetLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtTargetLotID);
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
        /// Source Lot ID에서 엔터키 입력 시 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSourceLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && MPCF.Trim(txtSourceLotID.Text) != "")
                {
                    btnAdd_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        
        /// <summary>
        /// Add 버튼을 클릭하면 Merge Lot 정보를 등록합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation
                if (MPCF.CheckValue(txtSourceLotID, false) == false)
                {
                    return;
                }

                // View Source Lot
                if (ViewSourceLot(txtSourceLotID.Text) == false)
                {
                    MPCF.SetFocus(txtSourceLotID);
                    txtSourceLotID.SelectAll();                    
                    return;
                }

                // Clear
                txtSourceLotID.Text = "";
                MPCF.SetFocus(txtSourceLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Del 버튼을 클릭하면 선택된 Merge Lot 정보를 삭제합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우 종료
                if (gridMergeInfo.Rows.Count < 1)
                {
                    return;
                }

                // Row 제거
                for (int i = gridMergeInfo.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)gridMergeInfo.Rows[i].Cells[0].Value == true)
                    {
                        gridMergeInfo.Rows[i].Delete(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Merge Lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtTargetLotID, false) == false)
                {
                    return;
                }
                if (gridMergeInfo.Rows.Count < 1)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, false);
                    MPCF.SetFocus(txtSourceLotID);

                    return;
                }
                
                // Merge Lot
                if (MergeLot() == false)
                {
                    MPCF.SetFocus(txtTargetLotID);
                    txtTargetLotID.SelectAll();                    
                    return;
                }

                // Clear
                MPCF.SetFocus(txtTargetLotID);
                txtTargetLotID.SelectAll();                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Lot Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLotStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtTargetLotID, false) == false)
                {
                    return;
                }

                // Show Popup
                frmWIPViewLotStatusPopup f = new frmWIPViewLotStatusPopup(txtTargetLotID.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Lot History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLotHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtTargetLotID, false) == false)
                {
                    return;
                }

                // Show Popup
                frmWIPViewLotHistoryPopup f = new frmWIPViewLotHistoryPopup(txtTargetLotID.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Work Order 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (ORDER.GetString("ORDER_ID") == null 
                    || ORDER.GetString("ORDER_ID") == "")
                {
                    MPCF.SetFocus(txtTargetLotID);
                    return;
                }

                // Show Popup
                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(ORDER.GetString("ORDER_ID"));
                f.Owner = MPGV.gfrmMDI;
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
        /// View Lot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            
            try
            {                
                LOT.Init();

                // FieldClear
                MPCF.FieldClear(this, txtTargetLotID);
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }
                
                txtMatID.Text = LOT.GetString("MAT_ID") + " : " + LOT.GetString("MAT_DESC");
                txtOper.Text = LOT.GetString("OPER") + " : " + LOT.GetString("OPER_DESC");
                txtQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));
                
                if (ViewOrder(LOT.GetString("ORDER_ID")) == false)
                {
                    return false;
                }

                if (LOT.GetString("LOT_STATUS") == "PROC")
                {
                    pbStart.LotStatus = true;
                }
                else
                {
                    pbStart.LotStatus = false;
                }

                pbHold.LotStatus = (LOT.GetChar("HOLD_FLAG") == 'Y' ? true : false);
                pbRework.LotStatus = (LOT.GetChar("RWK_FLAG") == 'Y' ? true : false);
                pbRepair.LotStatus = (LOT.GetChar("REP_FLAG") == 'Y' ? true : false);
                pbInventory.LotStatus = (LOT.GetChar("INV_FLAG") == 'Y' ? true : false);
                pbTransit.LotStatus = (LOT.GetChar("TRANSIT_FLAG") == 'Y' ? true : false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Work Order
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
                txtCustomer.Text = out_node.GetString("CUSTOMER_ID");
                txtLine.Text = out_node.GetString("WORK_LINE") + " : " + out_node.GetString("WORK_LINE_DESC");;

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
        /// View Child lot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewSourceLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_SOURCE_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_SOURCE_LOT_OUT");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Data Bind
                DataTable dt = gridMergeInfo.GetDataSource();
                double dSourceLotQty = 0;
                bool bFound = false;                                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString() == txtSourceLotID.Text)
                    {
                        dt.Rows[i][(int)COL_MERGE_LOT_LIST.QTY_1] = (Convert.ToInt32(dt.Rows[i]["QTY_1"]) + Convert.ToInt32(txtQty.Text));

                        bFound = true;
                        break;
                    }
                }

                if (bFound == false)
                {
                    DataRow dr = dt.NewRow();
                    dr[(int)COL_MERGE_LOT_LIST.CHK] = true;
                    dr[(int)COL_MERGE_LOT_LIST.SEQ] = dt.Rows.Count + 1;
                    dr[(int)COL_MERGE_LOT_LIST.SOURCE_LOT_ID] = txtSourceLotID.Text;
                    dr[(int)COL_MERGE_LOT_LIST.MAT_ID] = out_node.GetString("MAT_ID");
                    dr[(int)COL_MERGE_LOT_LIST.MAT_VER] = out_node.GetInt("MAT_VER");
                    dr[(int)COL_MERGE_LOT_LIST.FLOW] = out_node.GetString("FLOW");
                    dr[(int)COL_MERGE_LOT_LIST.FLOW_SEQ_NUM] = out_node.GetInt("FLOW_SEQ_NUM");
                    dr[(int)COL_MERGE_LOT_LIST.OPER] = out_node.GetString("OPER");
                    dr[(int)COL_MERGE_LOT_LIST.QTY_1] = out_node.GetDouble("QTY_1");
                    dSourceLotQty += out_node.GetDouble("QTY_1");
                    dr[(int)COL_MERGE_LOT_LIST.LAST_ACTIVE_HIST_SEQ] = out_node.GetInt("LAST_ACTIVE_HIST_SEQ");
                    dt.Rows.Add(dr);
                }

                // Bind
                gridMergeInfo.DataBind();
                txtAfterQty.Text = MPCF.MakeNumberFormat(MPCF.ToDbl(txtQty.Text) + dSourceLotQty);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Merge Lot
        /// </summary>
        /// <returns></returns>
        private bool MergeLot()
        {
            TRSNode in_node = new TRSNode("MERGE_LOT_IN");
            TRSNode out_node = new TRSNode("MERGE_LOT_OUT");
            TRSNode merge_list = new TRSNode("MERGE_LIST");

            bool bFailed = false;
            List<int> successIndex = new List<int>();
            List<WIPMergeLotFailedModel> failedList = new List<WIPMergeLotFailedModel>();

            try
            {
                // DataTable 호출
                DataTable dt = gridMergeInfo.GetDataSource();

                if (dt.Rows.Count < 1)
                {
                    return true;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INTO_LOT_ID", txtTargetLotID.Text);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                //in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));
                //in_node.AddString("INTO_CRR_ID", MPCF.Trim(cdvIntoCrrID.Text));
                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}
                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                //in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    in_node.SetInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(dt.Rows[i][(int)COL_MERGE_LOT_LIST.LAST_ACTIVE_HIST_SEQ]));
                    in_node.SetString("LOT_ID", Convert.ToString(dt.Rows[i][(int)COL_MERGE_LOT_LIST.SOURCE_LOT_ID]));
                    in_node.SetString("MAT_ID", Convert.ToString(dt.Rows[i][(int)COL_MERGE_LOT_LIST.MAT_ID]));
                    in_node.SetInt("MAT_VER", MPCF.ToInt(dt.Rows[i][(int)COL_MERGE_LOT_LIST.MAT_VER]));
                    in_node.SetString("FLOW", Convert.ToString(dt.Rows[i][(int)COL_MERGE_LOT_LIST.FLOW]));
                    in_node.SetInt("FLOW_SEQ_NUM", MPCF.ToInt(dt.Rows[i][(int)COL_MERGE_LOT_LIST.FLOW_SEQ_NUM]));
                    in_node.SetString("OPER", Convert.ToString(dt.Rows[i][(int)COL_MERGE_LOT_LIST.OPER]));
                    in_node.SetDouble("MOVE_QTY_1", MPCF.ToDbl(dt.Rows[i][(int)COL_MERGE_LOT_LIST.QTY_1]));

                    if (MPCF.CallService("WIP", "WIP_Merge_Lot", in_node, ref out_node) == false)
                    {
                        bFailed = true;

                        for (int index = 0; index < dt.Rows.Count; index++)
                        {
                            if (successIndex.Contains(index) == true)
                            {
                                continue;
                            }
                            else
                            {
                                WIPMergeLotFailedModel failedModel = new WIPMergeLotFailedModel();
                                failedModel.SOURCE_LOT_ID = Convert.ToString(dt.Rows[index][(int)COL_MERGE_LOT_LIST.SOURCE_LOT_ID]);
                                failedModel.MAT_ID = Convert.ToString(dt.Rows[index][(int)COL_MERGE_LOT_LIST.MAT_ID]);
                                failedModel.MAT_VER = MPCF.ToInt(dt.Rows[index][(int)COL_MERGE_LOT_LIST.MAT_VER]);
                                failedModel.FLOW = Convert.ToString(dt.Rows[index][(int)COL_MERGE_LOT_LIST.FLOW]);
                                failedModel.FLOW_SEQ_NUM = MPCF.ToInt(dt.Rows[index][(int)COL_MERGE_LOT_LIST.FLOW_SEQ_NUM]);
                                failedModel.OPER = Convert.ToString(dt.Rows[index][(int)COL_MERGE_LOT_LIST.OPER]);
                                failedModel.QTY_1 = MPCF.ToDbl(dt.Rows[index][(int)COL_MERGE_LOT_LIST.QTY_1]);
                                failedModel.LAST_ACTIVE_HIST_SEQ = MPCF.ToInt(dt.Rows[index][(int)COL_MERGE_LOT_LIST.LAST_ACTIVE_HIST_SEQ]);
                                failedList.Add(failedModel);
                            }
                        }

                        break;
                    }

                    successIndex.Add(i);
                }

                // 한건이라도 실패한 경우
                if (bFailed == true)
                {
                    // View Lot
                    if (ViewLot(txtTargetLotID.Text) == false)
                    {
                        return false;
                    }

                    // Out Message
                    MPCF.ShowMessage(out_node.GetString(TRSDefine.OUT_MSG), MSG_LEVEL.ERROR, false);

                    // DataTable 호출
                    dt = gridMergeInfo.GetDataSource();
                    int iRowCount = 1;

                    foreach (WIPMergeLotFailedModel mod in failedList)
                    {
                        DataRow dr = dt.NewRow();
                        dr[(int)COL_MERGE_LOT_LIST.CHK] = true;
                        dr[(int)COL_MERGE_LOT_LIST.SEQ] = iRowCount++;
                        dr[(int)COL_MERGE_LOT_LIST.SOURCE_LOT_ID] = mod.SOURCE_LOT_ID;
                        dr[(int)COL_MERGE_LOT_LIST.MAT_ID] = mod.MAT_ID;
                        dr[(int)COL_MERGE_LOT_LIST.MAT_VER] = mod.MAT_VER;
                        dr[(int)COL_MERGE_LOT_LIST.FLOW] = mod.FLOW;
                        dr[(int)COL_MERGE_LOT_LIST.FLOW_SEQ_NUM] = mod.FLOW_SEQ_NUM;
                        dr[(int)COL_MERGE_LOT_LIST.OPER] = mod.OPER;
                        dr[(int)COL_MERGE_LOT_LIST.QTY_1] = mod.QTY_1;
                        dr[(int)COL_MERGE_LOT_LIST.LAST_ACTIVE_HIST_SEQ] = mod.LAST_ACTIVE_HIST_SEQ;
                        dt.Rows.Add(dr);
                    }

                    gridMergeInfo.SetDataSource(dt);

                    return false;
                }

                // View Lot
                if (ViewLot(txtTargetLotID.Text) == false)
                {
                    return false;
                }

                txtSourceLotID.Text = "";

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

    public class WIPMergeLotFailedModel
    {
        private string source_lot_id;
        public string SOURCE_LOT_ID
        {
            get { return source_lot_id; }
            set { source_lot_id = value; }
        }

        private string mat_id;
        public string MAT_ID
        {
            get { return mat_id; }
            set { mat_id = value; }
        }

        private int mat_ver;
        public int MAT_VER
        {
            get { return mat_ver; }
            set { mat_ver = value; }
        }

        private string flow;
        public string FLOW
        {
            get { return flow; }
            set { flow = value; }
        }

        private int flow_seq_num;
        public int FLOW_SEQ_NUM
        {
            get { return flow_seq_num; }
            set { flow_seq_num = value; }
        }

        private string oper;
        public string OPER
        {
            get { return oper; }
            set { oper = value; }
        }

        private double qty_1;
        public double QTY_1
        {
            get { return qty_1; }
            set { qty_1 = value; }
        }

        private int last_active_hist_seq;
        public int LAST_ACTIVE_HIST_SEQ
        {
            get { return last_active_hist_seq; }
            set { last_active_hist_seq = value; }
        }        
    }
}
