using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using BOI.OIFrx;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;

namespace SOI.Solar
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSTShipLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        
        private TRSNode LOT;

        private string sCustomer = "";
        private string sPalletID = string.Empty;

        private enum COL_SHIP_LOT_LIST
        {
            CHK = 0,
            SEQ,
            SHIP_LOT_ID,
            MAT_ID,
            MAT_DESC,
            CUSTOMER,
            QTY_1,
            //RESULT,
            //SHEET,
            MAT_VER,
            FLOW_SEQ_NUM,
            LAST_ACTIVE_HIST_SEQ,
            FLOW,
            OPER,
            SHIP_PALLET_ID
        }

        #endregion

        #region Constructor

        public frmCUSTShipLot()
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
        private void frmCUSTShipLot_Load(object sender, EventArgs e)
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
        private void frmCUSTShipLot_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                MPCF.SetFocus(txtLotID);

                bIsShown = true;
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

                if (ViewLotList(sPalletID) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
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
                // Validation
                if (gridShipInfo.Rows.Count < 1)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, false);
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                // Ship
                if (ShipLot() == false)
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
                    txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자
                    sPalletID = this.txtLotID.Text.Trim();
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
                //string selectedLotId = e.Cell.Row.Cells["SHIP_LOT_ID"].Text;
                //if (ViewSheet(selectedLotId) == false)
                //{
                //    return;
                //}
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

                //Validation
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][(int)COL_SHIP_LOT_LIST.SHIP_LOT_ID].ToString() == sLotId)
                    {
                        // The data is duplicated.
                        MPCF.ShowMessage(MPCF.GetMessage(111), MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Lot 정보등록
                LOT = out_node;

                // Data Bind
                DataRow dr = dt.NewRow();                
                dr[(int)COL_SHIP_LOT_LIST.CHK] = true;
                dr[(int)COL_SHIP_LOT_LIST.SEQ] = dt.Rows.Count + 1;
                dr[(int)COL_SHIP_LOT_LIST.SHIP_LOT_ID] = txtLotID.Text;
                dr[(int)COL_SHIP_LOT_LIST.MAT_ID] = out_node.GetString("MAT_ID");
                dr[(int)COL_SHIP_LOT_LIST.MAT_DESC] = out_node.GetString("MAT_DESC");
                dr[(int)COL_SHIP_LOT_LIST.CUSTOMER] = sCustomer;
                dr[(int)COL_SHIP_LOT_LIST.QTY_1] = out_node.GetDouble("QTY_1").ToString();
                //dr[(int)COL_SHIP_LOT_LIST.RESULT] = sResult;
                //dr[(int)COL_SHIP_LOT_LIST.SHEET] = MPCF.FindLanguage("View");
                dr[(int)COL_SHIP_LOT_LIST.MAT_VER] = out_node.GetInt("MAT_VER");
                dr[(int)COL_SHIP_LOT_LIST.FLOW_SEQ_NUM] = out_node.GetInt("FLOW_SEQ_NUM");
                dr[(int)COL_SHIP_LOT_LIST.LAST_ACTIVE_HIST_SEQ] = out_node.GetInt("LAST_ACTIVE_HIST_SEQ");
                dr[(int)COL_SHIP_LOT_LIST.FLOW] = out_node.GetString("FLOW");
                dr[(int)COL_SHIP_LOT_LIST.OPER] = out_node.GetString("OPER");
                dt.Rows.Add(dr);                

                // Bind
                gridShipInfo.SetDataSource(dt);

                // Lot Qty 수량 변경
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

        // ViewLotList()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private bool ViewLotList(string sBoxID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");

            int i = 0;

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.SetString("BOX_ID", sBoxID);

            try
            {
                // DataTable 호출
                DataTable dt = gridShipInfo.GetDataSource();

                //Validation
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j][(int)COL_SHIP_LOT_LIST.SHIP_PALLET_ID].ToString() == sBoxID)
                    {
                        // The data is duplicated.
                        MPCF.ShowMessage(MPCF.GetMessage(111), MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }

                if (MPCF.CallService("CUS", "CUS_View_Lot_List_By_Box", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList("LIST").Count; i++)
                {
                    // Data Bind
                    DataRow dr = dt.NewRow();
                    dr[(int)COL_SHIP_LOT_LIST.CHK] = true;
                    dr[(int)COL_SHIP_LOT_LIST.SEQ] = dt.Rows.Count + 1;
                    dr[(int)COL_SHIP_LOT_LIST.SHIP_PALLET_ID] = sPalletID;
                    dr[(int)COL_SHIP_LOT_LIST.SHIP_LOT_ID] = out_node.GetList("LIST")[i].GetString("LOT_ID");
                    dr[(int)COL_SHIP_LOT_LIST.MAT_ID] = out_node.GetList("LIST")[i].GetString("MAT_ID");
                    dr[(int)COL_SHIP_LOT_LIST.MAT_DESC] = out_node.GetList("LIST")[i].GetString("MAT_DESC");
                    dr[(int)COL_SHIP_LOT_LIST.CUSTOMER] = sCustomer;
                    dr[(int)COL_SHIP_LOT_LIST.QTY_1] = out_node.GetDouble("QTY_1").ToString();
                    dr[(int)COL_SHIP_LOT_LIST.MAT_VER] = out_node.GetList("LIST")[i].GetInt("MAT_VER");
                    dr[(int)COL_SHIP_LOT_LIST.FLOW_SEQ_NUM] = out_node.GetList("LIST")[i].GetInt("FLOW_SEQ_NUM");
                    dr[(int)COL_SHIP_LOT_LIST.LAST_ACTIVE_HIST_SEQ] = out_node.GetList("LIST")[i].GetInt("LAST_ACTIVE_HIST_SEQ");
                    dr[(int)COL_SHIP_LOT_LIST.FLOW] = out_node.GetList("LIST")[i].GetString("FLOW");
                    dr[(int)COL_SHIP_LOT_LIST.OPER] = out_node.GetList("LIST")[i].GetString("OPER");
                    dt.Rows.Add(dr);

                    // Bind
                    gridShipInfo.SetDataSource(dt);

                    // Lot Qty 수량 변경
                    double dShipLotQty = 0;
                    for (int k = 0; k < gridShipInfo.Rows.Count; k++)
                    {
                        dShipLotQty += MPCF.ToDbl(gridShipInfo.Rows[k].Cells[(int)COL_SHIP_LOT_LIST.QTY_1].Value);
                    }

                    txtTotalQty.Text = dShipLotQty.ToString();
                    txtLotCount.Text = dt.Rows.Count.ToString();
                    //txtLotID.Text = "";

                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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

            bool bFailed = false;
            //List<int> successIndex = new List<int>();
            //List<WIPShipLotFailedModel> failedList = new List<WIPShipLotFailedModel>();

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
                in_node.AddString("SHIP_CODE", "CUST");
                in_node.AddString("TO_FACTORY", "CUSTOMER");
                //in_node.AddString("TO_OPER", "1010");
                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}
                //in_node.AddString("TRAN_CMF_1", txtShipOrder.Text);
                in_node.AddString("COMMENT", txtComment.Text);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    in_node.SetInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(dt.Rows[i][(int)COL_SHIP_LOT_LIST.LAST_ACTIVE_HIST_SEQ]));
                    in_node.SetString("LOT_ID", Convert.ToString(dt.Rows[i][(int)COL_SHIP_LOT_LIST.SHIP_LOT_ID]));
                    in_node.SetString("MAT_ID", Convert.ToString(dt.Rows[i][(int)COL_SHIP_LOT_LIST.MAT_ID]));
                    in_node.SetInt("MAT_VER", MPCF.ToInt(dt.Rows[i][(int)COL_SHIP_LOT_LIST.MAT_VER]));
                    in_node.SetString("FLOW", Convert.ToString(dt.Rows[i][(int)COL_SHIP_LOT_LIST.FLOW]));
                    in_node.SetInt("FLOW_SEQ_NUM", MPCF.ToInt(dt.Rows[i][(int)COL_SHIP_LOT_LIST.FLOW_SEQ_NUM]));
                    in_node.SetString("OPER", Convert.ToString(dt.Rows[i][(int)COL_SHIP_LOT_LIST.OPER]));

                    if (MPCF.CallService("WIP", "WIP_Ship_Lot", in_node, ref out_node) == false)
                    {
                        //bFailed = true;

                        //for (int index = 0; index < dt.Rows.Count; index++)
                        //{
                        //    if (successIndex.Contains(index) == true)
                        //    {
                        //        continue;
                        //    }
                        //    else
                        //    {
                        //        WIPShipLotFailedModel failedModel = new WIPShipLotFailedModel();
                        //        failedModel.SHIP_LOT_ID = Convert.ToString(dt.Rows[index][(int)COL_SHIP_LOT_LIST.SHIP_LOT_ID]);
                        //        failedModel.MAT_ID = Convert.ToString(dt.Rows[index][(int)COL_SHIP_LOT_LIST.MAT_ID]);
                        //        failedModel.MAT_DESC = Convert.ToString(dt.Rows[index][(int)COL_SHIP_LOT_LIST.MAT_DESC]);                                
                        //        failedModel.CUSTOMER = Convert.ToString(dt.Rows[index][(int)COL_SHIP_LOT_LIST.CUSTOMER]);
                        //        failedModel.QTY_1 = MPCF.ToInt(dt.Rows[index][(int)COL_SHIP_LOT_LIST.QTY_1]);
                        //        failedModel.RESULT = Convert.ToString(dt.Rows[index][(int)COL_SHIP_LOT_LIST.RESULT]);
                        //        failedModel.SHEET = Convert.ToString(dt.Rows[index][(int)COL_SHIP_LOT_LIST.SHEET]);
                        //        failedModel.MAT_VER = MPCF.ToInt(dt.Rows[index][(int)COL_SHIP_LOT_LIST.MAT_VER]);
                        //        failedModel.FLOW_SEQ_NUM = MPCF.ToInt(dt.Rows[index][(int)COL_SHIP_LOT_LIST.FLOW_SEQ_NUM]);
                        //        failedModel.LAST_ACTIVE_HIST_SEQ = MPCF.ToInt(dt.Rows[index][(int)COL_SHIP_LOT_LIST.LAST_ACTIVE_HIST_SEQ]);
                        //        failedModel.FLOW = Convert.ToString(dt.Rows[index][(int)COL_SHIP_LOT_LIST.FLOW]);
                        //        failedModel.OPER = Convert.ToString(dt.Rows[index][(int)COL_SHIP_LOT_LIST.OPER]);
                        //        failedList.Add(failedModel);
                        //    }
                        //}

                        return false;
                    }

                    //successIndex.Add(i);
                }

                //// 한건이라도 실패한 경우
                //if (bFailed == true)
                //{
                //    MPCF.FieldClear(gridShipInfo);

                //    // Out Message
                //    MPCF.ShowMessage(out_node.GetString(TRSDefine.OUT_MSG), MSG_LEVEL.ERROR, false);

                //    // DataTable 호출
                //    dt = gridShipInfo.GetDataSource();

                //    int iRowCount = 1;
                //    foreach (WIPShipLotFailedModel mod in failedList)
                //    {
                //        DataRow dr = dt.NewRow();
                //        dr[(int)COL_SHIP_LOT_LIST.CHK] = true;
                //        dr[(int)COL_SHIP_LOT_LIST.SEQ] = iRowCount++;
                //        dr[(int)COL_SHIP_LOT_LIST.SHIP_LOT_ID] = mod.SHIP_LOT_ID;
                //        dr[(int)COL_SHIP_LOT_LIST.MAT_ID] = mod.MAT_ID;
                //        dr[(int)COL_SHIP_LOT_LIST.MAT_DESC] = mod.MAT_DESC;
                //        dr[(int)COL_SHIP_LOT_LIST.CUSTOMER] = mod.CUSTOMER;
                //        dr[(int)COL_SHIP_LOT_LIST.QTY_1] = mod.QTY_1;
                //        dr[(int)COL_SHIP_LOT_LIST.RESULT] = mod.RESULT;
                //        dr[(int)COL_SHIP_LOT_LIST.SHEET] = mod.SHEET;
                //        dr[(int)COL_SHIP_LOT_LIST.MAT_VER] = mod.MAT_VER;
                //        dr[(int)COL_SHIP_LOT_LIST.FLOW_SEQ_NUM] = mod.FLOW_SEQ_NUM;
                //        dr[(int)COL_SHIP_LOT_LIST.LAST_ACTIVE_HIST_SEQ] = mod.LAST_ACTIVE_HIST_SEQ;
                //        dr[(int)COL_SHIP_LOT_LIST.FLOW] = mod.FLOW;
                //        dr[(int)COL_SHIP_LOT_LIST.OPER] = mod.OPER;
                //        dt.Rows.Add(dr);
                //    }

                //    gridShipInfo.SetDataSource(dt);

                //    return false;
                //}

                // 성공한 경우
                MPCF.FieldClear(this);
                
                // Success Message
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

        #endregion

        private void cdvSourceOrderID_ButtonPress(object sender, EventArgs e)
        {
            string sViewID = string.Empty;
            
            try
            {
                cdvSourceOrderID.Init();
                cdvSourceOrderID.SelectedSubItemIndex = 0;

                cdvSourceOrderID.Columns.Add("Set ID", 50, HorizontalAlignment.Left);
                cdvSourceOrderID.Columns.Add("Desc", 100, HorizontalAlignment.Left);

                DataTable dt = new DataTable();
                if (TPDR.DirectViewOne(cdvSourceOrderID.GetListView, "BAS-01", ref dt) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$ORDER_ID";
                dvcArgu[1].sCondition_Value = "%";


                // CodeView Column Header Setup
                string[] header = new string[] { "Order ID", "Order Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                // Show by RPTServer
                cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Order", "COM0001-011", dvcArgu, display, header, "ORDER_DESC", -1);

                if (cdvLossCode.returnDatas != null && cdvLossCode.returnDatas.Count > 0)
                {
                    cdvLossCode.Tag = cdvLossCode.returnDatas[0];
                    cdvLossCode.Text = cdvLossCode.returnDatas[1];
                }

                //if (MPCF.Trim(cdvLossCode.Text) != "")
                //{
                //    if (cdvLossCode.returnDatas != null && cdvLossCode.returnDatas.Count > 0)
                //    {
                //        cdvLossCode.Tag = cdvLossCode.returnDatas[0];
                //        cdvLossCode.Text = cdvLossCode.returnDatas[1];
                //        //sAccountDetail = cdvLossCode.returnDatas[2];
                //    }
                //    else
                //    {
                //        cdvLossCode.Tag = "";
                //        cdvLossCode.Text = "";
                //        //sAccountDetail = "";
                //    }
                //}
                //else
                //{
                //    cdvLossCode.Tag = "";
                //    cdvLossCode.Text = "";
                //    //sAccountDetail = "";
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

            return;
        }
    }
}
