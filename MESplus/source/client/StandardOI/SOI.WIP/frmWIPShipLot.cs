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
    public partial class frmWIPShipLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string sCustomer = "";
        private string sResult = "";
        private TRSNode LOT;

        #endregion

        #region Constructor

        public frmWIPShipLot()
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
        private void frmWIPShipLot_Load(object sender, EventArgs e)
        {
            // Init
            LOT = new TRSNode("LOT_INFO");
            gridShipInfo.InitDataSource();

            SetGridButtonTheme();

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
        private void frmWIPShipLot_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                MPCF.SetFocus(cdvShipFactory);

                bIsShown = true;
            }
        }
        
        /// <summary>
        /// Ship Factory Code View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvShipFactory_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_SHIP_FACTORY_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "FACTORY_TO", "TRANSIT_OPER" };
                string[] header = new string[] { "To Factory", "Transit Oper" };

                // Show CodeView and Get Return
                cdvShipFactory.Text = cdvShipFactory.Show(cdvShipFactory, "View Shipping Factory", "WIP", "WIP_View_Ship_Factory_List", in_node, "LIST", display, header, "To Factory");

                if (cdvShipFactory == null || cdvShipFactory.Text == string.Empty)
                {
                    return;
                }

                if (cdvShipFactory.returnDatas.Count > 0)
                {
                    txtTransitOper.Text = cdvShipFactory.returnDatas[1];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Ship Code CodeView Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvShipCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(MPGC.MP_WIP_SHIP_CODE));

                // Display and Header Text Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Ship Code", "Ship Desc" };

                // Show CodeView and Get Return
                cdvShipCode.Text = cdvShipCode.Show(cdvShipCode, "View Ship Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Ship Code");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, false) == false) return;

                if (AddLot(txtLotID.Text) == false)
                {
                    txtLotID.SelectAll();
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                txtLotID.Text = "";
                MPCF.SetFocus(txtLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Del Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우 종료
                if (gridShipInfo.Rows.Count < 1)
                {
                    return;
                }

                // Row 제거
                for (int i = gridShipInfo.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)gridShipInfo.Rows[i].Cells[0].Value == true)
                    {
                        gridShipInfo.Rows[i].Delete(false);
                    }
                }

                double dShipLotQty = 0;
                for (int i = 0; i < gridShipInfo.Rows.Count; i++)
                {
                    gridShipInfo.Rows[i].Cells[1].Value = i + 1;
                    dShipLotQty += MPCF.ToDbl(gridShipInfo.Rows[i].Cells[6].Value);
                }

                txtTotalQty.Text = dShipLotQty.ToString();
                txtLotCount.Text = gridShipInfo.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Ship Lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //if (MPCF.CheckValue(cboShipFactory, false) == false) return;
                if (MPCF.CheckValue(cdvShipFactory, false) == false) return;

                //if (MPCF.CheckValue(cboShipCode, false) == false) return;
                if (MPCF.CheckValue(cdvShipCode, false) == false) return;

                if (gridShipInfo.Rows.Count < 1)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, false);

                    MPCF.SetFocus(txtLotID);

                    return;
                }

                //if (CheckCMFFields() == false)
                //{
                //    return;
                //}

                if (ShipLot() == false)
                {
                    return;
                }

                //MPCF.SetFocus(cboShipFactory);
                MPCF.SetFocus(cdvShipFactory);
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
                    btnAdd_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Sheet View Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridShipInfo_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {
                string selectedLotId = e.Cell.Row.Cells["SHIP_LOT_ID"].Text;
                if (ViewSheet(selectedLotId) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool AddLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                // DataTable 호출
                DataTable dt = gridShipInfo.GetDataSource();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SHIP_LOT_ID"].ToString() == sLotId)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(368), MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                LOT = out_node;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["MAT_ID"].ToString() != out_node.GetString("MAT_ID"))
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(369), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                    }
                }

                if (out_node.GetChar("LOT_CMF_6") == 'P')
                {
                    sResult = MPCF.FindLanguage("Pass");
                }
                else if (out_node.GetChar("LOT_CMF_6") == 'R')
                {
                    sResult = MPCF.FindLanguage("RejectFlag");
                }

                if (ViewOrder(out_node.GetString("ORDER_ID")) == false)
                {
                    return false;
                }

                // Row 추가
                DataRow dr = dt.NewRow();

                // 값 추가
                dr["chk"] = true;
                dr["SEQ"] = dt.Rows.Count + 1;
                dr["SHIP_LOT_ID"] = txtLotID.Text;
                dr["MAT_ID"] = out_node.GetString("MAT_ID");
                dr["MAT_DESC"] = out_node.GetString("MAT_DESC");
                dr["CUSTOMER"] = sCustomer;
                dr["QTY_1"] = out_node.GetDouble("QTY_1").ToString();
                dr["RESULT"] = sResult;
                dr["SHEET"] = MPCF.FindLanguage("View");

                // Add
                dt.Rows.Add(dr);                

                // Bind
                gridShipInfo.DataBind();
                double dShipLotQty = 0;
                for (int i = 0; i < gridShipInfo.Rows.Count; i++)
                {
                    dShipLotQty += MPCF.ToDbl(gridShipInfo.Rows[i].Cells[6].Value);
                }

                txtTotalQty.Text = dShipLotQty.ToString();
                txtLotCount.Text = dt.Rows.Count.ToString();
                txtLotID.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

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

                sCustomer = out_node.GetString("CUSTOMER_ID");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Ship Lot
        /// </summary>
        /// <returns></returns>
        private bool ShipLot()
        {
            TRSNode in_node = new TRSNode("SHIP_LOT_IN");
            TRSNode out_node = new TRSNode("SHIP_LOT_OUT");

            try
            {
                // DataTable 호출
                DataTable dt = gridShipInfo.GetDataSource();

                if (dt.Rows.Count < 1)
                {
                    return true;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SHIP_CODE", cdvShipCode.Text);
                in_node.AddString("TO_FACTORY", cdvShipFactory.Text);
                in_node.AddString("TO_OPER", txtTransitOper.Text);

                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}

                in_node.AddString("TRAN_CMF_1", txtShipOrder.Text);

                //// Input CMF 관련 추가
                //if (btnInputCMF.Visibility == System.Windows.Visibility.Visible)
                //{
                //    in_node.AddString("TRAN_CMF_2", MPCF.Trim(_cmfDatas.TranCMF2));
                //    in_node.AddString("TRAN_CMF_3", MPCF.Trim(_cmfDatas.TranCMF3));
                //    in_node.AddString("TRAN_CMF_4", MPCF.Trim(_cmfDatas.TranCMF4));
                //    in_node.AddString("TRAN_CMF_5", MPCF.Trim(_cmfDatas.TranCMF5));
                //    in_node.AddString("TRAN_CMF_6", MPCF.Trim(_cmfDatas.TranCMF6));
                //    in_node.AddString("TRAN_CMF_7", MPCF.Trim(_cmfDatas.TranCMF7));
                //    in_node.AddString("TRAN_CMF_8", MPCF.Trim(_cmfDatas.TranCMF8));
                //    in_node.AddString("TRAN_CMF_9", MPCF.Trim(_cmfDatas.TranCMF9));
                //    in_node.AddString("TRAN_CMF_10", MPCF.Trim(_cmfDatas.TranCMF10));
                //    in_node.AddString("TRAN_CMF_11", MPCF.Trim(_cmfDatas.TranCMF11));
                //    in_node.AddString("TRAN_CMF_12", MPCF.Trim(_cmfDatas.TranCMF12));
                //    in_node.AddString("TRAN_CMF_13", MPCF.Trim(_cmfDatas.TranCMF13));
                //    in_node.AddString("TRAN_CMF_14", MPCF.Trim(_cmfDatas.TranCMF14));
                //    in_node.AddString("TRAN_CMF_15", MPCF.Trim(_cmfDatas.TranCMF15));
                //    in_node.AddString("TRAN_CMF_16", MPCF.Trim(_cmfDatas.TranCMF16));
                //    in_node.AddString("TRAN_CMF_17", MPCF.Trim(_cmfDatas.TranCMF17));
                //    in_node.AddString("TRAN_CMF_18", MPCF.Trim(_cmfDatas.TranCMF18));
                //    in_node.AddString("TRAN_CMF_19", MPCF.Trim(_cmfDatas.TranCMF19));
                //    in_node.AddString("TRAN_CMF_20", MPCF.Trim(_cmfDatas.TranCMF20));
                //}

                in_node.AddString("COMMENT", txtComment.Text);

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                    in_node.AddString("LOT_ID", dt.Rows[i]["SHIP_LOT_ID"].ToString());
                    in_node.AddString("MAT_ID", dt.Rows[i]["MAT_ID"].ToString());
                    in_node.SetInt("MAT_VER", LOT.GetInt("MAT_VER")); // Enabled by Hyun, 2019.01.07
                    in_node.AddString("FLOW", LOT.GetString("FLOW"));
                    //in_node.SetInt("FLOW_SEQ_NUM", s.LOT.GetInt("FLOW_SEQ_NUM"));
                    in_node.AddString("OPER", LOT.GetString("OPER"));

                    if (MPCF.CallService("WIP", "WIP_Ship_Lot", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }

                cdvShipFactory.Text = "";
                cdvShipCode.Text = "";

                txtTransitOper.Text = "";
                txtShipOrder.Text = "";
                txtComment.Text = "";

                txtLotID.Text = "";
                gridShipInfo.InitDataSource();
                txtLotCount.Text = "";
                txtTotalQty.Text = "";

                //// Input CMF 관련 추가
                //_cmfDatas = new CMFReturnData();

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Grid Button Color by Theme
        /// </summary>
        private void SetGridButtonTheme()
        {
            try
            {
                if (gridShipInfo != null)
                {
                    gridShipInfo.DisplayLayout.Bands[0].Columns["SHEET"].CellButtonAppearance.BackColor = MPGV.gTheme.ButtonDefaultBackground;
                    gridShipInfo.DisplayLayout.Bands[0].Columns["SHEET"].CellButtonAppearance.ForeColor = MPGV.gTheme.Foreground;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Sheet
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewSheet(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_SHEET_IN");
            TRSNode out_node = new TRSNode("VIEW_SHEET_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotId);

                if (MPCF.CallService("WIP", "Wip_View_Inspect_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                frmWIPViewShipLotTemplatePopup frm = new frmWIPViewShipLotTemplatePopup();
                frm.model = new WIPViewShipLotTemplatePopupModel();
                frm.model.ReadOnlyFlag = true;
                frm.model.FileData = out_node.GetBlob(MPGC.MP_BIN_DATA_1);

                frm.Owner = MPGV.gfrmMDI;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion
    }
}
