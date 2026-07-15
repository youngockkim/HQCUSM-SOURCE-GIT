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
using BOI.WIPCus.Controls;
using SOI.DNM;
using BOI.OIFrx;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPPreprocessingProgress : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string _sOrderId = string.Empty;
        private string _sMatId = string.Empty;
        private string _sFlow = string.Empty;
        private bool _bHoldFlag = false;
        private string _orderId = string.Empty;
        private string _sFirstOper = string.Empty;
        private string _startLoadFlag = string.Empty; //Strat시 Load테이블에 Load하는지 여부
        
        private enum LOT_COL
        {
            SELECT,
            LOT_ID,
            Qty,
            OPER,
            LOT_STATUS,
            HOLD_FLAG,
            START_RES_ID,
            START_TIME,
            ORDER_ID,
            TANK_ID,
            START_FLAG,
            END_FLAG
        }

        #endregion

        #region Constructor

        public frmWIPPreprocessingProgress()
        {
            InitializeComponent();
        }

        public frmWIPPreprocessingProgress(string s_order_id)
        {
            InitializeComponent();
            _orderId = MPCF.Trim(s_order_id);
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
                ClearData();

                InvisibleColumn();

                //WORK USER 
                cdvWorkUser.Text = MPGV.gsUserID;
                boiOrderInfo.Oper = "";

                if (_orderId != string.Empty)
                {
                    string matId = string.Empty;
                    string matBomType = string.Empty;
                    string oper = string.Empty;

                    boiOrderInfo.View_Order_Info(_orderId);

                    if (boiOrderInfo.spdOrderInfo.Sheets[0].RowCount > 0)
                    {
                        boiOrderInfo_WorkOrderButtonClick(new object(), new EventArgs());
                    }
                }

                // (Required) 
                bIsShown = true;
            }
        }

        private void boiOrderInfo_WorkOrderButtonClick(object sender, EventArgs e)
        {
            try
            {
                _sOrderId = boiOrderInfo.spdOrderInfo.Sheets[0].Cells[0, (int)BIGC.ORDER.ORDER_ID].Value.ToString();
                _sMatId = boiOrderInfo.spdOrderInfo.Sheets[0].Cells[0, (int)BIGC.ORDER.MAT_ID].Tag.ToString();
                _sFlow = boiOrderInfo.spdOrderInfo.Sheets[0].Cells[0, (int)BIGC.ORDER.FLOW].Tag.ToString();

                //Start Oper확인
                CheckStartOper();

                if (cdvOper.Tag.ToString() != "")
                {
                    ViewOrderLotList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "USER_ID";
                dvcArgu[1].sCondition_Value = MPGV.gsUserID;

                dvcArgu[2].sCondtion_ID = "FLOW";
                dvcArgu[2].sCondition_Value = boiOrderInfo.Flow;

                dvcArgu[3].sCondtion_ID = "OPER_CMF_3";
                dvcArgu[3].sCondition_Value = "";

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvOper.Text = cdvOper.Show(cdvOper, "Oper", "COM0000-007", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvOper.Text) != "")
                {
                    if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 0)
                    {
                        cdvOper.Tag = cdvOper.returnDatas[0];
                        if (cdvOper.Tag.Equals("A100") || cdvOper.Tag.Equals("A200"))
                        {
                            ClearData();
                        }
                        else
                        {
                            ViewOrderLotList();
                        }

                        cdvTankId.Text = "";
                        cdvTankId.Tag = "";
                    }
                    else
                    {
                        //cdvOper.Tag = "";
                    }
                }
                else
                {
                    cdvOper.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("START_LOT") == true)
                {
                    if (Start_Lot('1') == true) //1 Create Lot
                    {
                        ViewOrderLotList();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            char cStep;
            try
            {
                if (CheckCondition("END_LOT") == true)
                {
                    cStep = '1';

                    if (End_Lot(cStep) == true)
                    {
                        ViewOrderLotList();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvStartResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("RES_ID") == false)
                {
                    return;
                }

                BICF.ViewResource(cdvStartResID, "", boiOrderInfo.WorkOrderLineId, MPCF.Trim(cdvOper.Tag.ToString()));

                btnStart.Enabled = true;
                txtEndQty.Value = 0;
                cdvEndResID.Text = "";
                cdvEndResID.Tag = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvEndResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("RES_ID") == false)
                {
                    return;
                }

                BICF.ViewResource(cdvEndResID, "", boiOrderInfo.WorkOrderLineId, MPCF.Trim(cdvOper.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdLotList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                InitResEnabledButton(e.Row);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnHoldRelease_Click(object sender, EventArgs e)
        {
            try
            {
                BOI.WIPCus.Popup.frmWIPSelectHoldReleasePopup frm = new Popup.frmWIPSelectHoldReleasePopup();

                if (btnHoldRelease.Tag.ToString() == "H")
                {
                    if (CheckCondition("HOLD_LOT") == true)
                    {
                        frm._sCode = "H";
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            if (Hold_Lot('1', frm._sCodeValue, frm._sComment) == true)
                            {
                                ViewOrderLotList();
                            }
                        }
                    }
                }
                else
                {
                    if (CheckCondition("RELEASE_LOT") == true)
                    {
                        frm._sCode = "R";
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            if (Release_Lot('1', frm._sCodeValue, frm._sComment) == true)
                            {
                                ViewOrderLotList();
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

        private void cdvTankId_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("TANK_ID") == false)
                {
                    return;
                }

                //FLOW의 PREV_OPER조회
                TRSNode in_node = new TRSNode("VIEW_FLOW_OPER_IN");
                TRSNode out_node = new TRSNode("VIEW_FLOW_OPER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FLOW", _sFlow);
                in_node.AddString("OPER", cdvOper.Tag.ToString());

                if (MPCF.CallService("BWIP", "BWIP_View_Flow_Oper", in_node, ref out_node) == false)
                {
                    return;
                }

                if (out_node.GetString("PREV_OPER").ToString() == "")
                {
                    return;
                }

                BICF.ViewResource(cdvTankId, "", boiOrderInfo.WorkOrderLineId, out_node.GetString("PREV_OPER"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            string sLotId = string.Empty;

            try
            {
                if (spdLotList.Sheets[0].RowCount < 1)
                {
                    return;
                }

                sLotId = spdLotList.Sheets[0].Cells[spdLotList.Sheets[0].ActiveRowIndex, (int)LOT_COL.LOT_ID].Value.ToString();

                BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP3001, sLotId);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnLoss_Click(object sender, EventArgs e)
        {
            string sLotId = string.Empty;

            try
            {
                if (spdLotList.Sheets[0].RowCount < 1)
                {
                    return;
                }

                sLotId = spdLotList.Sheets[0].Cells[spdLotList.Sheets[0].ActiveRowIndex, (int)LOT_COL.LOT_ID].Value.ToString();

                frmWIPPreprocessingLossLot frm = new frmWIPPreprocessingLossLot(sLotId);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnInputMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                string sLotId = string.Empty;
                sLotId = spdLotList.Sheets[0].Cells[spdLotList.Sheets[0].ActiveRowIndex, (int)LOT_COL.LOT_ID].Value.ToString(); ;

                frmWIPInputMaterialOperPretreatment frm = new frmWIPInputMaterialOperPretreatment();
                frm.OrderId = boiOrderInfo.OrderId;
                frm.LotId = sLotId;
                frm.MatId = boiOrderInfo.MatId;
                frm.Oper = MPCF.Trim(cdvOper.Tag);
                frm.Flow = boiOrderInfo.Flow;
                frm.LineId = boiOrderInfo.WorkOrderLineId;
                frm.MatBomType = boiOrderInfo.BomMatType;
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdLotList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            int iReleaseCount = 0;

            try
            {
                if (e.Column == (int)LOT_COL.SELECT)
                {
                    _bHoldFlag = false;

                    for (int i = 0; i < spdLotList.Sheets[0].RowCount; i++)
                    {
                        if (spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value != null
                            && (bool)spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value == true
                            && spdLotList.Sheets[0].Cells[i, (int)LOT_COL.HOLD_FLAG].Value.ToString() == "Y")
                        {
                            _bHoldFlag = true;
                        }
                        else if (spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value != null
                            && (bool)spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value == true
                            && spdLotList.Sheets[0].Cells[i, (int)LOT_COL.HOLD_FLAG].Value.ToString() != "Y")
                        {
                            iReleaseCount += 1;
                        }
                    }

                    if (iReleaseCount != 0 && _bHoldFlag == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(426), MSG_LEVEL.WARNING, true);
                        return;
                    }

                    if (_bHoldFlag == true)
                    {
                        btnHoldRelease.Text = "Release Lot";
                        btnHoldRelease.Tag = "R";
                    }
                    else
                    {
                        btnHoldRelease.Text = "Hold Lot";
                        btnHoldRelease.Tag = "H";
                    }

                    MPCF.ConvertCaption(this);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        private void CheckStartOper()
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "FLOW";
                dvcArgu[1].sCondition_Value = _sFlow;

                if (TPDR.GetDataOne(s_column, ref dt, "CWIP8070-002", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return;
                }

                _sFirstOper = dt.Rows[0]["FIRST_OPER"].ToString();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void InvisibleColumn()
        {
            try
            {
                spdLotList.Sheets[0].Columns[(int)LOT_COL.TANK_ID].Visible = false;
                spdLotList.Sheets[0].Columns[(int)LOT_COL.START_FLAG].Visible = false;
                spdLotList.Sheets[0].Columns[(int)LOT_COL.END_FLAG].Visible = false;
                spdLotList.Sheets[0].Columns[(int)LOT_COL.HOLD_FLAG].Visible = false;
                spdLotList.Sheets[0].Columns[(int)LOT_COL.ORDER_ID].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void ViewOrderLotList()
        {
            try
            {
                MPCF.ClearList(spdLotList);

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "OPER";
                dvcArgu[1].sCondition_Value = cdvOper.Tag.ToString();

                dvcArgu[2].sCondtion_ID = "ORDER_ID";
                dvcArgu[2].sCondition_Value = _sOrderId;

                dvcArgu[3].sCondtion_ID = "LOT_ID";
                dvcArgu[3].sCondition_Value = "";

                if (TPDR.GetDataOne(s_column, ref dt, "CWIP8070-001", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdLotList.Sheets[0].RowCount += 1;
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.OPER].Value = dt.Rows[i]["OPER_DESC"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.OPER].Tag = dt.Rows[i]["OPER"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.LOT_STATUS].Value = dt.Rows[i]["LOT_STATUS"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.HOLD_FLAG].Value = dt.Rows[i]["HOLD_FLAG"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.START_RES_ID].Value = dt.Rows[i]["START_RES_DESC"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.START_RES_ID].Tag = dt.Rows[i]["START_RES_ID"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.START_TIME].Value = dt.Rows[i]["START_TIME"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.TANK_ID].Value = dt.Rows[i]["TANK_DESC"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.TANK_ID].Tag = dt.Rows[i]["TANK_ID"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.START_FLAG].Value = dt.Rows[i]["START_FLAG"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.END_FLAG].Value = dt.Rows[i]["END_FLAG"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.Qty].Value = dt.Rows[i]["QTY_1"];
                }

                txtComment.Text = "";
                MPCF.FitColumnHeader(spdLotList);
                
                if(spdLotList.Sheets[0].RowCount > 0)
                {
                    _startLoadFlag = dt.Rows[0]["START_LOAD_FLAG"].ToString();
                    InitResEnabledButton(0);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool CheckCondition(string FuncName)
        {
            int iRowCount = 0;

            try
            {
                switch (FuncName)
                {
                    case "HOLD_LOT":
                        for (int i = 0; i < spdLotList.Sheets[0].RowCount;i++)
                        {
                            if (spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value != null
                                && (bool)spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value == true)
                            {
                                iRowCount += 1;
                            }
                        }

                        if(iRowCount == 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(199), MSG_LEVEL.WARNING, true);
                            return false;
                        }
                        
                        break;

                    case "RELEASE_LOT":
                        for (int i = 0; i < spdLotList.Sheets[0].RowCount;i++)
                        {
                            if (spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value != null
                                && (bool)spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value == true)
                            {
                                iRowCount += 1;
                            }
                        }

                        if(iRowCount == 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(199), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        break;

                    case "START_LOT":
                        //Order ID
                        if (MPCF.Trim(_sOrderId) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(422), MSG_LEVEL.WARNING, true);
                            boiOrderInfo.Focus();
                            return false;
                        }

                        //Oper
                        if (MPCF.Trim(cdvOper.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvOper.Focus();
                            return false;
                        }

                        //Start Res ID
                        if (MPCF.Trim(cdvStartResID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvStartResID.Focus();
                            return false;
                        }

                        //Start 공정이 아니면 필수
                        if (_sFirstOper.ToString() != cdvOper.Tag.ToString() && MPCF.Trim(cdvTankId.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvTankId.Focus();
                            return false;
                        }

                        break;

                    case "END_LOT":
                        //Order ID
                        if (MPCF.Trim(_sOrderId) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(422), MSG_LEVEL.WARNING, true);
                            boiOrderInfo.Focus();
                            return false;
                        }

                        //Oper
                        if (MPCF.Trim(cdvOper.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvOper.Focus();
                            return false;
                        }

                        //End Res ID
                        if (MPCF.Trim(cdvEndResID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvEndResID.Focus();
                            return false;
                        }

                        //End Qty
                        if (MPCF.Trim(txtEndQty.Value) == "0")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.WARNING, true);
                            txtEndQty.Focus();
                            return false;
                        }

                        //Start 공정이 아니면 필수
                        if (_sFirstOper.ToString() != cdvOper.Tag.ToString() && MPCF.Trim(cdvTankId.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvTankId.Focus();
                            return false;
                        }

                        break;

                    case "RES_ID":
                        //Oper
                        if (MPCF.Trim(cdvOper.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvOper.Focus();
                            return false;
                        }

                        break;

                    case "TANK_ID":
                        //작업지시
                        if (boiOrderInfo.spdOrderInfo.Sheets[0].Rows.Count < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(410), MSG_LEVEL.WARNING, true);
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

        // Start_Lot()
        //       - Start Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Start_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("START_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _sOrderId);

                in_node.AddString("START_RES_ID", cdvStartResID.Tag.ToString());

                in_node.AddString("MAT_ID", _sMatId);
                in_node.AddInt("MAT_VER", 1);
                in_node.AddString("FLOW", _sFlow);
                in_node.AddString("OPER", cdvOper.Tag.ToString());

                in_node.AddString("COMMENT", txtComment.Text);

                in_node.AddDouble("QTY_1", 0);

                in_node.AddString("TANK_ID", cdvTankId.Tag.ToString());

                in_node.AddString("LINE_ID", boiOrderInfo.WorkOrderLineId);

                //Start 공정인지 아닌지
                if (_sFirstOper.ToString() == cdvOper.Tag.ToString())
                {
                    in_node.AddChar("START_OPER_FLAG", 'Y');
                    //LOT_GEN_RULE
                    in_node.AddChar("LOT_GEN_RULE", BIGC.B_LOT_GEN_RULE_L);
                }
                else
                {
                    in_node.AddChar("START_OPER_FLAG", 'N');
                    //LOT_GEN_RULE
                    in_node.AddChar("LOT_GEN_RULE", BIGC.B_LOT_GEN_RULE_C);
                }

                if (MPCF.CallService("BWIP", "BWIP_Tran_Start_Preprocessing", in_node, ref out_node) == false)
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

        // End_Lot()
        //       - End Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool End_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("END_LOT_OUT");
            

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _sOrderId);
                in_node.AddString("MAT_ID", _sMatId);
                in_node.AddInt("MAT_VER", 1);
                in_node.AddString("FLOW", _sFlow);
                in_node.AddString("OPER", cdvOper.Tag.ToString());

                in_node.AddString("LOT_ID", spdLotList.Sheets[0].Cells[spdLotList.Sheets[0].ActiveRowIndex, (int)LOT_COL.LOT_ID].Value.ToString());

                in_node.AddString("END_RES_ID", cdvEndResID.Tag.ToString());
                in_node.AddDouble("END_QTY", txtEndQty.Value);

                in_node.AddString("COMMENT", txtComment.Text);
                in_node.AddString("TANK_ID", cdvTankId.Tag.ToString());
                in_node.AddString("ACCOUNT_DETAIL", BIGC.B_INV_ACC_DETAIL_MOVE_INPUT);

                //Start 공정인지 아닌지
                if (_sFirstOper.ToString() == cdvOper.Tag.ToString())
                {
                    in_node.AddChar("START_OPER_FLAG", 'Y');
                }
                else
                {
                    in_node.AddChar("START_OPER_FLAG", 'N');
                }

                //AUTO LOSS
                if (chkAutoLoss.Checked == true)
                {
                    in_node.AddChar("AUTO_LOSS_FLAG", 'Y');
                }else
                {
                    in_node.AddChar("AUTO_LOSS_FLAG", 'N');
                }

                if (MPCF.CallService("BWIP", "BWIP_Tran_End_Preprocessing", in_node, ref out_node) == false)
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

        // Hold_Lot()
        //       - Hold Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Hold_Lot(char ProcStep, string sHoldCode, string sComment)
        {
            TRSNode in_node = new TRSNode("HOLD_LOT_IN");
            TRSNode out_node = new TRSNode("HOLD_LOT_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _sOrderId);
                in_node.AddString("MAT_ID", _sMatId);
                in_node.AddInt("MAT_VER", 1);
                in_node.AddString("FLOW", _sFlow);
                in_node.AddString("OPER", cdvOper.Tag.ToString());

                in_node.AddString("COMMENT", sComment);
                in_node.AddString("HOLD_CODE", sHoldCode);

                for (int i = 0; i < spdLotList.Sheets[0].RowCount; i++)
                {
                    if (spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value != null
                               && (bool)spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value == true)
                    {
                        list_item = in_node.AddNode("HOLD_LIST");

                        list_item.AddString("LOT_ID", MPCF.Trim(spdLotList.Sheets[0].Cells[i, (int)LOT_COL.LOT_ID].Value));
                    }
                }

                if (MPCF.CallService("BWIP", "BWIP_Tran_Multi_Hold_Lot", in_node, ref out_node) == false)
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


        // Release_Lot()
        //       - Release Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Release_Lot(char ProcStep, string sReleaseCode, string sComment)
        {
            TRSNode in_node = new TRSNode("RELEASE_LOT_IN");
            TRSNode out_node = new TRSNode("RELEASE_LOT_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _sOrderId);
                in_node.AddString("MAT_ID", _sMatId);
                in_node.AddInt("MAT_VER", 1);
                in_node.AddString("FLOW", _sFlow);
                in_node.AddString("OPER", cdvOper.Tag.ToString());
                in_node.AddString("COMMENT", sComment);

                in_node.AddString("RELEASE_CODE", sReleaseCode);

                for (int i = 0; i < spdLotList.Sheets[0].RowCount; i++)
                {
                    if (spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value != null
                               && (bool)spdLotList.Sheets[0].Cells[i, (int)LOT_COL.SELECT].Value == true)
                    {
                        list_item = in_node.AddNode("RELEASE_LIST");

                        list_item.AddString("LOT_ID", MPCF.Trim(spdLotList.Sheets[0].Cells[i, (int)LOT_COL.LOT_ID].Value));
                    }
                }

                if (MPCF.CallService("BWIP", "BWIP_Tran_Multi_Release_Lot", in_node, ref out_node) == false)
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


        private void InitResEnabledButton(int iRow)
        {
            try
            {
                cdvStartResID.Text = spdLotList.Sheets[0].Cells[iRow, (int)LOT_COL.START_RES_ID].Value.ToString();
                cdvStartResID.Tag = spdLotList.Sheets[0].Cells[iRow, (int)LOT_COL.START_RES_ID].Tag.ToString();

                cdvTankId.Text = spdLotList.Sheets[0].Cells[iRow, (int)LOT_COL.TANK_ID].Value.ToString();
                cdvTankId.Tag = spdLotList.Sheets[0].Cells[iRow, (int)LOT_COL.TANK_ID].Tag.ToString();

                cdvEndResID.Text = "";
                cdvEndResID.Tag = "";

                txtEndQty.Value = spdLotList.Sheets[0].Cells[iRow, (int)LOT_COL.Qty].Value;

                if (spdLotList.Sheets[0].Cells[iRow, (int)LOT_COL.END_FLAG].Value.ToString() == BIGC.B_YES.ToString())
                {
                    btnStart.Enabled = false;
                    btnEnd.Enabled = false;
                    
                    if (spdLotList.Sheets[0].Cells[iRow, (int)LOT_COL.HOLD_FLAG].Value.ToString() == BIGC.B_YES.ToString())
                    {
                        btnLoss.Enabled = false;
                    }
                    else
                    {
                        btnLoss.Enabled = true;
                    }
                }
                else
                {
                    if (spdLotList.Sheets[0].Cells[iRow, (int)LOT_COL.START_FLAG].Value.ToString() == BIGC.B_YES.ToString())
                    {
                        btnEnd.Enabled = true;
                        btnLoss.Enabled = false;
                        btnStart.Enabled = false;
                    }
                    else
                    {
                        btnStart.Enabled = true;
                        btnEnd.Enabled = false;

                        if (spdLotList.Sheets[0].Cells[iRow, (int)LOT_COL.HOLD_FLAG].Value.ToString() == BIGC.B_YES.ToString())
                        {
                            btnLoss.Enabled = false;
                        }
                        else
                        {
                            btnLoss.Enabled = true;
                        }
                    }
                }

                btnViewDetail.Enabled = true;
                btnHoldRelease.Enabled = true;
                btnInputMaterial.Enabled = true;
                chkAutoLoss.Enabled = true;

                if (_startLoadFlag == "Y")
                {
                    btnEnd.Enabled = false;
                }

                if (_sFirstOper.ToString() == cdvOper.Tag.ToString())
                {
                    chkAutoLoss.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void ClearData()
        {
            try
            {
                MPCF.ClearList(spdLotList);

                btnViewDetail.Enabled = false;
                btnHoldRelease.Enabled = false;
                btnLoss.Enabled = false;
                btnInputMaterial.Enabled = false;
                btnStart.Enabled = false;
                btnEnd.Enabled = false;

                cdvStartResID.Text = "";
                cdvStartResID.Tag = "";

                cdvEndResID.Text = "";
                cdvEndResID.Tag = "";

                txtComment.Text = "";

                txtEndQty.Value = 0;

                cdvTankId.Text = "";
                cdvTankId.Tag = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

      

        private void frmWIPPreprocessingProgress_H101MsgDataReceived(TRSNode node)
        {
            if (node.GetChar("MES_STATUS") == '1')
            {
                MPCF.CheckContinueProc(node, false);
            }
            else
            {
                boiOrderInfo_WorkOrderButtonClick(new object(), new EventArgs());
            }
            
        }
    }
}
;