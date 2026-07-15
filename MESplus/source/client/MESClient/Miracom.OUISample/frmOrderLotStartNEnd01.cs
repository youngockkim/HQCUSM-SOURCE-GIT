using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.OUISample
{
    public partial class frmOrderLotStartNEnd01 : BaseForm03
    {
        public frmOrderLotStartNEnd01()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int COL_MAT = 0;
        private const int COL_WDATE = 1;
        private const int COL_ORDER = 2;
        private const int COL_ORD_QTY = 5;
        private const int COL_QTY = 14;
        private const int COL_ORD_IN = 24;
        private const int COL_ORD_OUT = 25;
        private const int COL_ORD_LOSS = 26;
        private const int COL_ORD_RWK = 27;
        
        #endregion

        #region " Variable Definition "

        private TRSNode LOT;
        private TRSNode ORDER;
        private List<string> li_order_lot_list;

        #endregion

        #region " Function Definition "

        private void ClearData(int i_case)
        {
            try
            {
                switch (i_case)
                {
                    case 1:
                        VisibleInputValue(false);

                        udcLotInfor.InitFlexibleScreen();

                        LOT = null;
                        ORDER = null;
                        btnProcess.Tag = null;

                        break;

                    case 2:
                        VisibleInputValue(false);

                        udcLotInfor.InitFlexibleScreen();

                        LOT = null;
                        btnProcess.Tag = null;

                        txtLotID.Text = "";
                        txtLotDesc.Text = "";

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool ViewOrderListDetail()
        {
            FarPoint.Win.Spread.SheetView shtOrder;
            FarPoint.Win.Spread.SheetView shtMat;
            int i;
            int iRow;
            int iCol;
            DateTime dt_work_date;

            MPCF.ClearList(spdOrder);
            MPCF.ClearList(spdMatOrder);

            lblOrderCount.Text = "Order Count : 0";
            lblOrderQty.Text = "Order Quantity : 0";
            lblOrderInQty.Text = "Order In Quantity : 0";


            TRSNode in_node = new TRSNode("View_Order_List_Detail_In");
            TRSNode out_node = new TRSNode("View_Order_List_Detail_Out");
            TRSNode order_list;

            dt_work_date = dtpWorkDate.Value;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TO_DATE", MPCF.ToDate(dt_work_date));
            in_node.AddString("FROM_DATE", MPCF.FromDate(dt_work_date.AddDays(-7)));
            in_node.AddChar("ORD_STATUS_FLAG", ' ');
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", 1);
            in_node.AddString("MAT_TYPE", "");
            in_node.AddString("MAT_GRP", "");

            shtOrder = spdOrder.ActiveSheet;
            shtMat = spdMatOrder.ActiveSheet;

            do
            {
                if (MPCR.CallService("ORD", "ORD_View_Order_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    order_list = out_node.GetList(0)[i];

                    iRow = shtOrder.RowCount;

                    shtOrder.RowCount++;
                    shtMat.RowCount++;

                    iCol = 0;

                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("MAT_ID"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("ORDER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("ORDER_DESC"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("ORDER_ID"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("MAT_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("ORDER_DESC"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("FLOW"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("FLOW"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_QTY"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("RES_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("RES_ID"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("BOM_SET_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("BOM_SET_ID"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetInt("BOM_SET_VERSION"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetInt("BOM_SET_VERSION"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CUSTOMER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CUSTOMER_ID"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CUSTOMER_MAT_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CUSTOMER_MAT_ID"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_DUE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_DUE_TIME"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_START_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_START_TIME"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_END_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_END_TIME"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("QTY"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("LOT_TYPE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("LOT_TYPE"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("OWNER_CODE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("OWNER_CODE"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CREATE_CODE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CREATE_CODE"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("LOT_PRIORITY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("LOT_PRIORITY"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("ORD_STATUS_FLAG"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("ORD_STATUS_FLAG"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("ORD_SHIP_FLAG"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("ORD_SHIP_FLAG"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORD_START_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORD_START_TIME"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORD_END_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORD_END_TIME"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_IN_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_IN_QTY"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_OUT_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_OUT_QTY"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_LOSS_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_LOSS_QTY"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_RWK_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_RWK_QTY"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CREATE_USER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CREATE_USER_ID"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("CREATE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("CREATE_TIME"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("UPDATE_USER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("UPDATE_USER_ID"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("UPDATE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("UPDATE_TIME"));

                    iCol++;

                }

                in_node.SetString("NEXT_ORDER_ID", out_node.GetString("NEXT_ORDER_ID"));
            } while (in_node.GetString("NEXT_ORDER_ID") != "");

            FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[3];
            sort[0] = new FarPoint.Win.Spread.SortInfo(0, true);
            sort[1] = new FarPoint.Win.Spread.SortInfo(1, true);
            sort[2] = new FarPoint.Win.Spread.SortInfo(3, true);
            shtOrder.SortRows(0, shtOrder.RowCount, sort);

            sort = new FarPoint.Win.Spread.SortInfo[3];
            sort[0] = new FarPoint.Win.Spread.SortInfo(0, true);
            sort[1] = new FarPoint.Win.Spread.SortInfo(1, true);
            sort[2] = new FarPoint.Win.Spread.SortInfo(2, true);
            shtMat.SortRows(0, shtMat.RowCount, sort);

            CalTotalQty();

            MPCF.FitColumnHeader(spdOrder);
            MPCF.FitColumnHeader(spdMatOrder); 
            
            return true;
        }

        private void CalTotalQty()
        {
            int i;

            double dTOQty;
            double dTQty;
            double dTOIQty;
            double dTOOQty;
            double dTOLQty;
            double dTORQty;

            double dMTOQty;
            double dMTQty;
            double dMTOIQty;
            double dMTOOQty;
            double dMTOLQty;
            double dMTORQty;

            double dTTOQty;
            double dTTQty;
            double dTTOIQty;
            double dTTOOQty;
            double dTTOLQty;
            double dTTORQty;

            FarPoint.Win.Spread.SheetView shtMat = spdMatOrder.ActiveSheet;

            if (shtMat.RowCount <= 0)
            {
                return;
            }

            i = 0;
            dTOQty = 0;
            dTQty = 0;
            dTOIQty = 0;
            dTOOQty = 0;
            dTOLQty = 0;
            dTORQty = 0;

            dMTOQty = 0;
            dMTQty = 0;
            dMTOIQty = 0;
            dMTOOQty = 0;
            dMTOLQty = 0;
            dMTORQty = 0;

            dTTOQty = 0;
            dTTQty = 0;
            dTTOIQty = 0;
            dTTOOQty = 0;
            dTTOLQty = 0;
            dTTORQty = 0;

            while (i < shtMat.RowCount - 1)
            {
                dTOQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_QTY].Value);
                dTQty += MPCF.ToDbl(shtMat.Cells[i, COL_QTY].Value);
                dTOIQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_IN].Value);
                dTOOQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_OUT].Value);
                dTOLQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_LOSS].Value);
                dTORQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_RWK].Value);

                if (shtMat.Cells[i, COL_MAT].Text == shtMat.Cells[i + 1, COL_MAT].Text)
                {
                    if (shtMat.Cells[i, COL_WDATE].Text == shtMat.Cells[i + 1, COL_WDATE].Text)
                    {
                        i++;
                    }
                    else
                    {
                        shtMat.AddRows(i + 1, 1);
                        shtMat.Cells[i + 1, COL_MAT].Value = shtMat.Cells[i, COL_MAT].Value;
                        shtMat.Cells[i + 1, COL_WDATE].Value = "DATE TOTAL";
                        shtMat.Rows[i + 1].BackColor = Color.LightGoldenrodYellow;
                        shtMat.Cells[i + 1, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dTOQty);
                        shtMat.Cells[i + 1, COL_QTY].Value = MPCF.Format("######,##0.###", dTQty);
                        shtMat.Cells[i + 1, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dTOIQty);
                        shtMat.Cells[i + 1, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dTOOQty);
                        shtMat.Cells[i + 1, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dTOLQty);
                        shtMat.Cells[i + 1, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dTORQty);

                        dMTOQty += dTOQty;
                        dMTQty += dTQty;
                        dMTOIQty += dTOIQty;
                        dMTOOQty += dTOOQty;
                        dMTOLQty += dTOLQty;
                        dMTORQty += dTORQty;

                        i += 2;

                        dTOQty = 0;

                        dTQty = 0;
                        dTOIQty = 0;
                        dTOOQty = 0;
                        dTOLQty = 0;
                        dTORQty = 0;
                    }
                }
                else
                {
                    shtMat.AddRows(i + 1, 1);
                    shtMat.Cells[i + 1, COL_MAT].Value = shtMat.Cells[i, COL_MAT].Value;
                    shtMat.Cells[i + 1, COL_WDATE].Value = "DATE TOTAL";
                    shtMat.Rows[i + 1].BackColor = Color.LightGoldenrodYellow;
                    shtMat.Cells[i + 1, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dTOQty);
                    shtMat.Cells[i + 1, COL_QTY].Value = MPCF.Format("######,##0.###", dTQty);
                    shtMat.Cells[i + 1, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dTOIQty);
                    shtMat.Cells[i + 1, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dTOOQty);
                    shtMat.Cells[i + 1, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dTOLQty);
                    shtMat.Cells[i + 1, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dTORQty);

                    dMTOQty += dTOQty;
                    dMTQty += dTQty;
                    dMTOIQty += dTOIQty;
                    dMTOOQty += dTOOQty;
                    dMTOLQty += dTOLQty;
                    dMTORQty += dTORQty;
                    dTOQty = 0;

                    dTQty = 0;
                    dTOIQty = 0;
                    dTOOQty = 0;
                    dTOLQty = 0;
                    dTORQty = 0;

                    shtMat.AddRows(i + 2, 1);
                    shtMat.Cells[i + 2, COL_MAT].Value = "MAT TOTAL";
                    shtMat.Rows[i + 2].BackColor = Color.Gainsboro;
                    shtMat.Cells[i + 2, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dMTOQty);
                    shtMat.Cells[i + 2, COL_QTY].Value = MPCF.Format("######,##0.###", dMTQty);
                    shtMat.Cells[i + 2, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dMTOIQty);
                    shtMat.Cells[i + 2, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dMTOOQty);
                    shtMat.Cells[i + 2, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dMTOLQty);
                    shtMat.Cells[i + 2, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dMTORQty);

                    dTTOQty += dMTOQty;
                    dTTQty += dMTQty;
                    dTTOIQty += dMTOIQty;
                    dTTOOQty += dMTOOQty;
                    dTTOLQty += dMTOLQty;
                    dTTORQty += dMTORQty;
                    dMTOQty = 0;

                    dMTQty = 0;
                    dMTOIQty = 0;
                    dMTOOQty = 0;
                    dMTOLQty = 0;
                    dMTORQty = 0;

                    i += 3;
                }
            }

            dTOQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_QTY].Value);
            dTQty += MPCF.ToDbl(shtMat.Cells[i, COL_QTY].Value);
            dTOIQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_IN].Value);
            dTOOQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_OUT].Value);
            dTOLQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_LOSS].Value);
            dTORQty += MPCF.ToDbl(shtMat.Cells[i, COL_ORD_RWK].Value);

            i = shtMat.RowCount;
            shtMat.RowCount++;

            shtMat.Cells[i, COL_MAT].Value = shtMat.Cells[i - 1, COL_MAT].Value;
            shtMat.Cells[i, COL_WDATE].Value = "DATE TOTAL";
            shtMat.Rows[i].BackColor = Color.LightGoldenrodYellow;
            shtMat.Cells[i, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dTOQty);
            shtMat.Cells[i, COL_QTY].Value = MPCF.Format("######,##0.###", dTQty);
            shtMat.Cells[i, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dTOIQty);
            shtMat.Cells[i, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dTOOQty);
            shtMat.Cells[i, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dTOLQty);
            shtMat.Cells[i, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dTORQty);

            dMTOQty += dTOQty;
            dMTQty += dTQty;
            dMTOIQty += dTOIQty;
            dMTOOQty += dTOOQty;
            dMTOLQty += dTOLQty;
            dMTORQty += dTORQty;


            i = shtMat.RowCount;
            shtMat.RowCount++;

            shtMat.Cells[i, COL_MAT].Value = "MAT TOTAL";
            shtMat.Rows[i].BackColor = Color.Gainsboro;
            shtMat.Cells[i, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dMTOQty);
            shtMat.Cells[i, COL_QTY].Value = MPCF.Format("######,##0.###", dMTQty);
            shtMat.Cells[i, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dMTOIQty);
            shtMat.Cells[i, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dMTOOQty);
            shtMat.Cells[i, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dMTOLQty);
            shtMat.Cells[i, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dMTORQty);

            dTTOQty += dMTOQty;
            dTTQty += dMTQty;
            dTTOIQty += dMTOIQty;
            dTTOOQty += dMTOOQty;
            dTTOLQty += dMTOLQty;
            dTTORQty += dMTORQty;


            i = shtMat.RowCount;
            shtMat.RowCount++;

            shtMat.Cells[i, 0].Value = "TOTAL";
            shtMat.Rows[i].BackColor = Color.LightSteelBlue;
            shtMat.Cells[i, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dTTOQty);
            shtMat.Cells[i, COL_QTY].Value = MPCF.Format("######,##0.###", dTTQty);
            shtMat.Cells[i, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dTTOIQty);
            shtMat.Cells[i, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dTTOOQty);
            shtMat.Cells[i, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dTTOLQty);
            shtMat.Cells[i, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dTTORQty);


            lblOrderCount.Text = "Order Count : " + spdOrder.ActiveSheet.RowCount;
            lblOrderQty.Text = "Order Quantity : " + MPCF.Format("######,##0.###", dTTOQty);
            lblOrderInQty.Text = "Order In Quantity : " + MPCF.Format("######,##0.###", dTTOIQty);
        }

        private bool ViewOrder(string s_order_id)
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ORDER_ID", s_order_id);

            if (MPCR.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
            {
                return false;
            }

            ORDER = out_node;

            return true;
        }

        private bool ViewOrderLotList(string s_order_id)
        {
            TRSNode in_node = new TRSNode("View_Order_Lot_List_In");
            TRSNode out_node = new TRSNode("View_Order_Lot_List_Out");
            TRSNode lot_list;
            int i;

            li_order_lot_list.Clear();

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ORDER_ID", s_order_id);

            do
            {
                if (MPCR.CallService("ORD", "ORD_View_Attach_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    lot_list = out_node.GetList(0)[i];

                    li_order_lot_list.Add(lot_list.GetString("LOT_ID"));
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            return true;
        }

        private bool ViewLotInfo(string s_lot_id)
        {
            s_lot_id = MPCF.Trim(s_lot_id);
            if (s_lot_id == "") return false;

            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            ClearData(2);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", s_lot_id);

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            DateTime dt_time = MPCF.ToDate(out_node.GetString("OPER_IN_TIME"));
            TimeSpan ts_time = DateTime.Now - dt_time;
            string s_time = ts_time.Days + ", " + ts_time.Hours + ":" + ts_time.Minutes + ":" + ts_time.Seconds;
            out_node.AddString("QUEUE_TIME", s_time);

            if (out_node.GetString("START_TIME") != "")
            {
                dt_time = MPCF.ToDate(out_node.GetString("START_TIME"));
                ts_time = DateTime.Now - dt_time;
                s_time = ts_time.Days + ", " + ts_time.Hours + ":" + ts_time.Minutes + ":" + ts_time.Seconds;
                out_node.AddString("PROC_TIME", s_time);
            }

            if (udcLotInfor.LoadDesign("OUI_LotStatus") == false) return false;
            if (udcLotInfor.SetDataToScreen(out_node) == false) return false;

            txtLotID.Text = out_node.GetString("LOT_ID");
            txtLotDesc.Text = out_node.GetString("LOT_DESC");

            LOT = out_node;

            MPCR.PopupInformNote(null, "", s_lot_id, "", "", "", "");

            return true;
        }

        private void SetInValueControl(Label lbl, Miracom.UI.Controls.MCCodeView.MCCodeView cdv, string s_label, string s_default_value)
        {
            if (s_label == "")
            {
                lbl.Visible = false;
                cdv.Visible = false;
            }
            else
            {
                lbl.Visible = true;
                cdv.Visible = true;

                lbl.Text = s_label;
                cdv.Text = s_default_value;

                if (cdv.Items.Count > 0)
                {
                    cdv.VisibleButton = true;
                }
            }
        }

        private void VisibleInputValue(bool b_visible,
            string s_label_1 = "",
            string s_default_value_1 = "",
            string s_label_2 = "",
            string s_default_value_2 = "",
            string s_label_3 = "",
            string s_default_value_3 = "",
            string s_label_4 = "",
            string s_default_value_4 = "",
            string s_label_5 = "",
            string s_default_value_5 = "")
        {
            if (b_visible == false)
            {
                pnlInValue.Visible = false;

                lblInValue01.Text = "";
                lblInValue02.Text = "";
                lblInValue03.Text = "";
                lblInValue04.Text = "";
                lblInValue05.Text = "";

                cdvInValue01.Text = "";
                cdvInValue02.Text = "";
                cdvInValue03.Text = "";
                cdvInValue04.Text = "";
                cdvInValue05.Text = "";

                return;
            }

            pnlInValue.Visible = true;
            SetInValueControl(lblInValue01, cdvInValue01, s_label_1, s_default_value_1);
            SetInValueControl(lblInValue02, cdvInValue02, s_label_2, s_default_value_2);
            SetInValueControl(lblInValue03, cdvInValue03, s_label_3, s_default_value_3);
            SetInValueControl(lblInValue04, cdvInValue04, s_label_4, s_default_value_4);
            SetInValueControl(lblInValue05, cdvInValue05, s_label_5, s_default_value_5);
        }

        private bool StartLot()
        {
            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            bool b_proc_alarm_action;

            try
            {
                MPCR.SetInMsg(in_node);

                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_START,
                                                LOT.GetString("MAT_ID"),
                                                LOT.GetInt("MAT_VER"),
                                                LOT.GetString("FLOW"),
                                                LOT.GetString("OPER"),
                                                LOT.GetString("LOT_ID"),
                                                "START_LOT",
                                                MPCF.Trim(cdvInValue01.Text),
                                                ref b_proc_alarm_action) == false)
                {
                    return false;
                }

                if (b_proc_alarm_action == true)
                    in_node.AddChar("PROC_ALARM_FLAG", 'Y');
                /***** End Check Transaction Confirm Message *****/

                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}
                in_node.AddString("RES_ID", MPCF.Trim(cdvInValue01.Text));

                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                //in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                //in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                //in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                //in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                //in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                //in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                //in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                //in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                //in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                //in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                //in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                //in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                //in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                //in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                //in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                //in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                //in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                //in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                //in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                //in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (MPCR.CallService("WIP", "WIP_Start_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool EndLot()
        {
            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            bool b_proc_alarm_action;

            try
            {
                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_END,
                                                LOT.GetString("MAT_ID"),
                                                LOT.GetInt("MAT_VER"),
                                                LOT.GetString("FLOW"),
                                                LOT.GetString("OPER"),
                                                LOT.GetString("LOT_ID"),
                                                "END_LOT",
                                                MPCF.Trim(cdvInValue01.Text),
                                                ref b_proc_alarm_action) == false)
                {
                    return false;
                }

                if (b_proc_alarm_action == true)
                    in_node.AddChar("PROC_ALARM_FLAG", 'Y');
                /***** End Check Transaction Confirm Message *****/

                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddDouble("QTY_1", -1);
                in_node.AddDouble("QTY_2", -1);
                in_node.AddDouble("QTY_3", -1);

                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}

                //in_node.AddString("TO_FLOW", MPCF.Trim(cdvToFlow.Text));
                //in_node.AddInt("TO_FLOW_SEQ_NUM", cdvToFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.Trim(cdvInValue02.Text));
                //in_node.AddString("RET_FLOW", MPCF.Trim(cdvReturnFlow.Text));
                //in_node.AddInt("RET_FLOW_SEQ_NUM", cdvReturnFlow.Sequence);
                //in_node.AddString("RET_OPER", MPCF.Trim(cdvRetOperation.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvInValue01.Text));
                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                //in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                //in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                //in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                //in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                //in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                //in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                //in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                //in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                //in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                //in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                //in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                //in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                //in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                //in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                //in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                //in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                //in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                //in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                //in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                //in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                //in_node.AddChar("FORCIBLY_END_WITH_SUBLOT_FLAG", chkForceEndSublot.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_End_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool HoldLot()
        {
            TRSNode in_node = new TRSNode("HOLD_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}

                in_node.AddString("HOLD_CODE", MPCF.Trim(cdvInValue01.Text));
                in_node.AddString("HOLD_PASSWORD", MPCF.Trim(cdvInValue02.Text).ToUpper(), true);

                //in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                //in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                //in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                //in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                //in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                //in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                //in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                //in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                //in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                //in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                //in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                //in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                //in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                //in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                //in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                //in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                //in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                //in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                //in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                //in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Hold_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmOrderLotStartNEnd01_Load(object sender, EventArgs e)
        {
            udcLotInfor.ScreenSpread.Tag = "Change Cell";
            udcLotInfor.InitFlexibleScreen();

            dtpWorkDate.Value = DateTime.Now;

            MPCF.ClearList(spdOrder);
            MPCF.ClearList(spdMatOrder);

            li_order_lot_list = new List<string>();

            ClearData(1);

            btnRefresh.PerformClick();
        }

        private void dtpWorkDate_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void cdvMaterial_ButtonPress(object sender, System.EventArgs e)
        {
            cdvMaterial.Init();
            MPCF.InitListView(cdvMaterial.GetListView);
            cdvMaterial.Columns.Add("Material", 50, HorizontalAlignment.Left);
            cdvMaterial.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvMaterial.SelectedSubItemIndex = 0;
            cdvMaterial.SameWidthHeightOfButton = true;

            if (WIPLIST.ViewMaterialList(cdvMaterial.GetListView, '1') == false)
            {
                return;
            }
        }

        private void cdvMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ViewOrderListDetail() == false) return;
        }

        private void cdvInValue_Enter(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            switch (cdvTemp.Name)
            {
                case "cdvInValue01":
                    lblInValue01.Visible = false;
                    break;
                case "cdvInValue02":
                    lblInValue02.Visible = false;
                    break;
                case "cdvInValue03":
                    lblInValue03.Visible = false;
                    break;
                case "cdvInValue04":
                    lblInValue04.Visible = false;
                    break;
                case "cdvInValue05":
                    lblInValue05.Visible = false;
                    break;
            }
        }

        private void cdvInValue_Leave(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if (cdvTemp.Text == "")
            {
                switch (cdvTemp.Name)
                {
                    case "cdvInValue01":
                        lblInValue01.Visible = true;
                        break;
                    case "cdvInValue02":
                        lblInValue02.Visible = true;
                        break;
                    case "cdvInValue03":
                        lblInValue03.Visible = true;
                        break;
                    case "cdvInValue04":
                        lblInValue04.Visible = true;
                        break;
                    case "cdvInValue05":
                        lblInValue05.Visible = true;
                        break;
                }
            }
        }

        private void cdvInValue_TextBoxTextChanged(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            Label lblTemp = null;

            if (cdvTemp.Text != "")
            {
                switch (cdvTemp.Name)
                {
                    case "cdvInValue01":
                        lblTemp = lblInValue01;
                        break;
                    case "cdvInValue02":
                        lblTemp = lblInValue02;
                        break;
                    case "cdvInValue03":
                        lblTemp = lblInValue03;
                        break;
                    case "cdvInValue04":
                        lblTemp = lblInValue04;
                        break;
                    case "cdvInValue05":
                        lblTemp = lblInValue05;
                        break;
                }

                if (lblTemp.Visible == true)
                {
                    lblTemp.Visible = false;
                }
            }
        }

        private void lblInValue_Click(object sender, EventArgs e)
        {
            Label lblTemp = (Label)sender;

            switch (lblTemp.Name)
            {
                case "lblInValue01":
                    cdvInValue01.Focus();
                    break;
                case "lblInValue02":
                    cdvInValue02.Focus();
                    break;
                case "lblInValue03":
                    cdvInValue03.Focus();
                    break;
                case "lblInValue04":
                    cdvInValue04.Focus();
                    break;
                case "lblInValue05":
                    cdvInValue05.Focus();
                    break;
            }
        }

        private void spdOrder_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            string sOrderID;
            int iRow = spdOrder.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return;

            sOrderID = MPCF.Trim(spdOrder.ActiveSheet.Cells[iRow, 1].Value);
            if (sOrderID == "") return;

            if (ViewOrderLotList(sOrderID) == false) return;
            if (ViewOrder(sOrderID) == false) return;
        }

        private void spdMatOrder_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            string sOrderID;
            int iRow = spdMatOrder.ActiveSheet.ActiveRowIndex;
            if(iRow < 0) return;

            sOrderID = MPCF.Trim(spdMatOrder.ActiveSheet.Cells[iRow, COL_ORDER].Value);
            if (sOrderID == "") return;

            if (ViewOrderLotList(sOrderID) == false) return;
            if (ViewOrder(sOrderID) == false) return;
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && MPCF.Trim(txtLotID.Text) != "")
            {
                txtLotID.Text = MPCF.Trim(txtLotID.Text);

                if (ORDER == null)
                {
                    MPCF.ShowMsgBox("Please select order first.");
                    txtLotID.Text = "";
                    txtLotDesc.Text = "";
                    txtLotID.Focus();
                    return;
                }

                if (li_order_lot_list.Contains(txtLotID.Text) == false)
                {
                    MPCF.ShowMsgBox("This lot does not contain in selected order.\n\n[" + txtLotID.Text + "]");
                    txtLotID.Text = "";
                    txtLotDesc.Text = "";
                    txtLotID.Focus();
                    return;
                }

                MPGV.gsCurrentLot_ID = txtLotID.Text;
                ViewLotInfo(txtLotID.Text);
            }
        }

        private void btnStartLot_Click(object sender, EventArgs e)
        {
            if (LOT == null) return;

            btnProcess.Tag = btnStartLot.Name;

            cdvInValue01.Init();
            MPCF.InitListView(cdvInValue01.GetListView);
            cdvInValue01.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvInValue01.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvInValue01.SelectedSubItemIndex = 0;
            cdvInValue01.SameWidthHeightOfButton = true;

            if (RASLIST.ViewResourceList(cdvInValue01.GetListView, "", 0, "", LOT.GetString("OPER"), false) == false)
            {
                return;
            }

            if (cdvInValue01.Items.Count < 1)
            {
                VisibleInputValue(false);
                return;
            }

            VisibleInputValue(true, "Start Res ID", ORDER.GetString("RES_ID"));
        }

        private void btnEndLot_Click(object sender, EventArgs e)
        {
            if (LOT == null) return;

            btnProcess.Tag = btnEndLot.Name;

            cdvInValue01.Init();
            MPCF.InitListView(cdvInValue01.GetListView);
            cdvInValue01.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvInValue01.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvInValue01.SelectedSubItemIndex = 0;
            cdvInValue01.SameWidthHeightOfButton = true;

            if (RASLIST.ViewResourceList(cdvInValue01.GetListView, "", 0, "", LOT.GetString("OPER"), false) == false)
            {
                return;
            }

            cdvInValue02.Init();
            MPCF.InitListView(cdvInValue02.GetListView);
            cdvInValue02.Columns.Add("To Oper", 50, HorizontalAlignment.Left);
            cdvInValue02.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvInValue02.SelectedSubItemIndex = 0;
            cdvInValue02.SameWidthHeightOfButton = true;

            if (WIPLIST.ViewOperationList(cdvInValue02.GetListView, '2', LOT.GetString("FLOW")) == false)
            {
                return;
            }


            if (cdvInValue01.Items.Count < 1)
            {
                VisibleInputValue(true, "", "", "To Oper");
            }
            else
            {
                VisibleInputValue(true, "End Res ID", LOT.GetString("START_RES_ID"), "To Oper");
            }
        }

        private void btnHoldLot_Click(object sender, EventArgs e)
        {
            if (LOT == null) return;

            btnProcess.Tag = btnHoldLot.Name;

            cdvInValue01.Init();
            MPCF.InitListView(cdvInValue01.GetListView);
            cdvInValue01.Columns.Add("Hold Code", 50, HorizontalAlignment.Left);
            cdvInValue01.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvInValue01.SelectedSubItemIndex = 0;
            cdvInValue01.SameWidthHeightOfButton = true;

            if (BASLIST.ViewGCMDataList(cdvInValue01.GetListView, '1', MPGC.MP_WIP_HOLD_CODE) == false)
            {
                return;
            }

            cdvInValue02.Init();
            cdvInValue02.VisibleButton = false;

            VisibleInputValue(true, "Hold Code", "", "Hold Password");
        }

        private void btnSplitLot_Click(object sender, EventArgs e)
        {
            if (LOT == null) return;

            MPGV.gIMdiForm.ActiveMenu("WIP2008");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (ORDER == null) return;
            if (LOT == null) return;
            if (MPCF.Trim(btnProcess.Tag) == "") return;

            string s_refresh_lot_id = LOT.GetString("LOT_ID");

            switch (MPCF.Trim(btnProcess.Tag))
            {
                case "btnStartLot":
                    if (pnlInValue.Visible == true)
                    {
                        if (MPCF.Trim(cdvInValue01.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n\n[" + lblInValue01.Text + "]");
                            cdvInValue01.Focus();
                            return;
                        }
                    }

                    if (StartLot() == false) return;

                    break;

                case "btnEndLot":
                    if (pnlInValue.Visible == true)
                    {
                        if (cdvInValue01.Visible == true && MPCF.Trim(cdvInValue01.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n\n[" + lblInValue01.Text + "]");
                            cdvInValue01.Focus();
                            return;
                        }
                    }

                    if (EndLot() == false) return;

                    break;

                case "btnHoldLot":
                    if (pnlInValue.Visible == true)
                    {
                        if (MPCF.Trim(cdvInValue01.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n\n[" + lblInValue01.Text + "]");
                            cdvInValue01.Focus();
                            return;
                        }
                    }

                    if (HoldLot() == false) return;

                    break;
            }

            ClearData(2);
        }









    }
}
