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
    public partial class frmWIPViewLotList : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COL_LOT_LIST
        {
            LOT_ID = 0,
            MAT_ID,
            FLOW,
            OPER,
            QTY_1,
            LOT_STATUS,
            HOLD_FLAG,
            HOLD_CODE,
            ORDER_ID,
            START_FLAG,
            START_TIME,
            START_RES_ID,
            END_FLAG,
            END_TIME,
            END_RES_ID,
            RWK_FLAG,
            REP_FLAG,
            LOT_TYPE_DESC,
            INV_FLAG,
            SHIP_CODE_2,
            SHIP_TIME,
            SCH_DUE_TIME,
            LOT_DEL_FLAG,
            LOT_DEL_CODE
        }

        #endregion

        #region Constructor

        public frmWIPViewLotList()
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
        private void frmWIPViewLotList_Load(object sender, EventArgs e)
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
        private void frmWIPViewLotList_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                //MPCF.SetFocus(cdvOper);

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvOper, false) == false)
                {
                    return;
                }

                if (ViewLotList(cdvOper.Text, cdvMatID.Text, cdvOrderID.Text) == false)
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
        /// Oper Code View Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };

                // Show CodeView and Get Return
                cdvOper.Text = cdvOper.Show(cdvOper, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "Oper");

                if (cdvOper.Text == null || cdvOper.Text == string.Empty)
                {
                    return;
                }

                if (ViewLotList(cdvOper.Text, cdvMatID.Text, cdvOrderID.Text) == false)
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
        /// Mat ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };
                string[] header = new string[] { "Mat ID", "Mat Desc" };

                // Show CodeView and Get Return
                cdvMatID.Text = cdvMatID.Show(cdvMatID, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "Mat ID");

                if (cdvMatID.Text == null)
                {
                    return;
                }

                if (ViewLotList(cdvOper.Text, cdvMatID.Text, cdvOrderID.Text) == false)
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
        /// Order CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOrderID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_ORDER_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };
                string[] header = new string[] { "Order ID", "Order Desc" };

                // Show CodeView and Get Return
                cdvOrderID.Text = cdvOrderID.Show(cdvOrderID, "View Order List", "ORD", "ORD_View_Order_List", in_node, "ORD_LIST", display, header, "Order ID");

                if (cdvOrderID == null)
                {
                    return;
                }

                if (ViewLotList(cdvOper.Text, cdvMatID.Text, cdvOrderID.Text) == false)
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
        /// Excel Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdHistory.ActiveSheet.RowCount < 1) return;

                if (MPCF.ExportToExcel(spdHistory, this.Text, "", true, true, true, -1, -1) == false)
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

        #region Functions

        /// <summary>
        /// View Lot List
        /// </summary>
        /// <param name="sOper"></param>
        /// <param name="sMatId"></param>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewLotList(string sOper, string sMatId, string sOrderId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");            
            TRSNode out_node;
            ArrayList lisHist = new ArrayList();
            int iLotCount = 0;
            double dTotalLotQty = 0;

            try
            {
                // 1. Field Clear
                MPCF.ClearList(this.spdHistory);
                txtLotCount.Text = "";
                txtTotalQty.Text = "";
                if (MPCF.Trim(sOrderId) == "")
                {
                    sOrderId = " ";
                }
                
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", MPCF.Trim(sOper));
                in_node.AddString("MAT_ID", MPCF.Trim(sMatId));
                in_node.AddString("SQL", "WHERE ('" + sOrderId + "' = ' ' OR ORDER_ID = '" + sOrderId + "')");
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);

                do
                {
                    out_node = new TRSNode("View_Lot_List_Out");

                    if (MPCF.CallService("WIP", "WIP_View_Lot_List_Detail_By_SQL_Query", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisHist.Add(out_node);
                    

                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                } while (in_node.GetString("NEXT_LOT_ID") != "");

                int iRow = 0;
                foreach (object obj in lisHist)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    //spdHistory.ActiveSheet.RowCount = out_node.GetList(0).Count;
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdHistory.Sheets[0].Rows.Count;
                        spdHistory.Sheets[0].RowCount++;

                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.LOT_ID].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.FLOW].Value = out_node.GetList(0)[i].GetString("FLOW");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.OPER].Value = out_node.GetList(0)[i].GetString("OPER");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.QTY_1].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("QTY_1"));
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.LOT_STATUS].Value = out_node.GetList(0)[i].GetString("LOT_STATUS");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.HOLD_FLAG].Value = out_node.GetList(0)[i].GetChar("HOLD_FLAG");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.HOLD_CODE].Value = out_node.GetList(0)[i].GetString("HOLD_CODE");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.ORDER_ID].Value = out_node.GetList(0)[i].GetString("ORDER_ID");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.START_FLAG].Value = out_node.GetList(0)[i].GetChar("START_FLAG");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.START_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME"));
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.START_RES_ID].Value = out_node.GetList(0)[i].GetString("START_RES_ID");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.END_FLAG].Value = out_node.GetList(0)[i].GetChar("END_FLAG");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.END_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME"));
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.END_RES_ID].Value = out_node.GetList(0)[i].GetString("END_RES_ID");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.RWK_FLAG].Value = out_node.GetList(0)[i].GetChar("RWK_FLAG");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.REP_FLAG].Value = out_node.GetList(0)[i].GetChar("REP_FLAG");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.LOT_TYPE_DESC].Value = out_node.GetList(0)[i].GetString("LOT_TYPE_DESC");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.INV_FLAG].Value = out_node.GetList(0)[i].GetChar("INV_FLAG");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.SHIP_CODE_2].Value = out_node.GetList(0)[i].GetString("SHIP_CODE");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.SHIP_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SHIP_TIME"));
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.SCH_DUE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.LOT_DEL_FLAG].Value = out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG");
                        spdHistory.Sheets[0].Cells[iRow, (int)COL_LOT_LIST.LOT_DEL_CODE].Value = out_node.GetList(0)[i].GetString("LOT_DEL_CODE");
                        dTotalLotQty += out_node.GetList(0)[i].GetDouble("QTY_1");
                        iLotCount++;
                    }
                }    

                MPCF.FitColumnHeader(spdHistory);

                txtLotCount.Text = MPCF.MakeNumberFormat(iLotCount);
                txtTotalQty.Text = MPCF.MakeNumberFormat(dTotalLotQty);
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
