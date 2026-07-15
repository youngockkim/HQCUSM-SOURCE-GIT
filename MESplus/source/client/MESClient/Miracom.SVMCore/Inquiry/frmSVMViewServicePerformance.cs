using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;


namespace Miracom.SVMCore
{
    public partial class frmSVMViewServicePerformance : Miracom.MESCore.ViewForm01
    {
        public frmSVMViewServicePerformance()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        /* 2013.06.12. Aiden. 체크 조회 조건 추가 */
        private bool CheckCondition()
        {

            try
            {
                if (dtpFrom.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    dtpFrom.Focus();
                    return false;
                }

                if (dtpTo.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    dtpTo.Focus();
                    return false;
                }

                if (dtpFrom.Value > dtpTo.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(160));
                    dtpFrom.Focus();
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool View_Service_List(Control control)
        {
            TRSNode in_node = new TRSNode("View_Service_List_In");
            TRSNode out_node = new TRSNode("View_Service_List_Out");
            ListViewItem itmx;
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", "");

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_NAME")), (int)SMALLICON_INDEX.IDX_KEY);
                    if (((ListView)control).Columns.Count > 1)
                    {
                        itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_DESC")));
                    }
                    ((ListView)control).Items.Add(itmx);
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_MODULE_NAME") != "");

            return true;
        }


        // View_Service_Performance_Info_List()
        //       - View View_Service_Performance_Info_List
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_Service_Performance_Info_List()
        {
            TRSNode in_node = new TRSNode("View_Service_Performance_Info_List_In");
            TRSNode out_node = new TRSNode("View_Service_Performance_Info_List_Out");
            int i;
            int iRow;
            int iCol;

            MPCF.ClearList(spdList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SYSTEM_NODE", MPCF.Trim(txtSystemNode.Text));
            in_node.AddString("SERVER_NAME", MPCF.Trim(txtServerName.Text));
            in_node.AddString("SUBNO", MPCF.Trim(txtSubNo.Text));
            in_node.AddString("SERVICE_NAME", MPCF.Trim(cdvService.Text));

            /* 2013.06.12. Aiden. 조회 조건 추가 */
            in_node.AddString("FROM_TRAN_TIME", MPCF.ToStandardTime(dtpFrom.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
            in_node.AddString("TO_TRAN_TIME", MPCF.ToStandardTime(dtpTo.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
            in_node.AddDouble("AVG_CONSUME_SEC", MPCF.ToDbl(txtElapsedTime.Text));
            in_node.AddInt("SERVICE_COUNT", MPCF.ToInt(txtServiceCount.Text));
            in_node.AddInt("NEXT_SEQ_NUM", int.MaxValue);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_Performance_Info_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdList.ActiveSheet.RowCount;
                    spdList.ActiveSheet.RowCount++;

                    iCol = 0;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("SEQ_NUM");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SYSTEM_NODE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SERVER_NAME");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBNO");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SERVICE_NAME");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("SERVICE_COUNT");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetDouble("AVG_CONSUME_SEC");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetDouble("MIN_CONSUME_SEC");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetDouble("MAX_CONSUME_SEC");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetDouble("TOTAL_CONSUME_SEC");

                    //speed up
                    if (spdList.ActiveSheet.RowCount == 100)
                    {
                        MPCF.FitColumnHeader(spdList);
                    }
                }

                in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
            } while (in_node.GetInt("NEXT_SEQ_NUM") > 0);

            if (spdList.ActiveSheet.RowCount < 100)
            {
                MPCF.FitColumnHeader(spdList);
            }
            return true;
        }

        private bool View_Service_Consume_Time_Trend()
        {
            TRSNode in_node = new TRSNode("View_Service_Consume_Time_In");
            TRSNode out_node = new TRSNode("View_Service_Consume_Time_Out");
            int i;
            int i_row;
            List<TRSNode> list;

            double d_total;
            double d_consume;
            double d_service_count;
            int i_compress_rate;

            d_total = 0;
            i_compress_rate = MPCF.ToInt(cboCompressRate.Text);

            foreach (Series series in chtTrend.Series)
            {
                series.Points.Clear();
            }
            MPCF.ClearList(spdTrendChart);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SYSTEM_NODE", MPCF.Trim(txtSystemNode.Text));
            in_node.AddString("SERVER_NAME", MPCF.Trim(txtServerName.Text));
            in_node.AddString("SUBNO", MPCF.Trim(txtSubNo.Text));
            in_node.AddString("SERVICE_NAME", MPCF.Trim(cdvService.Text));

            /* 2013.06.12. Aiden. 조회 조건 추가 */
            in_node.AddString("FROM_TRAN_TIME", MPCF.ToStandardTime(dtpFrom.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
            in_node.AddString("TO_TRAN_TIME", MPCF.ToStandardTime(dtpTo.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
            in_node.AddDouble("AVG_CONSUME_SEC", MPCF.ToDbl(txtElapsedTime.Text));
            in_node.AddInt("SERVICE_COUNT", MPCF.ToInt(txtServiceCount.Text));

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_Consume_Time", in_node, ref out_node) == false)
                {
                    return false;
                }

                list = out_node.GetList(0);
                for (i = 0; i < list.Count; i++)
                {
                    i_row = spdTrendChart.ActiveSheet.RowCount;
                    spdTrendChart.ActiveSheet.RowCount++;

                    spdTrendChart.ActiveSheet.Cells[i_row, 0].Value = MPCF.MakeDateFormat(list[i].GetString("TRAN_TIME"));
                    spdTrendChart.ActiveSheet.Cells[i_row, 1].Value = list[i].GetInt("SERVICE_COUNT");
                    spdTrendChart.ActiveSheet.Cells[i_row, 2].Value = list[i].GetDouble("TOTAL_CONSUME_SEC");

                    d_consume = list[i].GetDouble("AVG_CONSUME_SEC");
                    d_total += d_consume;

                    spdTrendChart.ActiveSheet.Cells[i_row, 3].Value = d_consume;
                }

                in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
            } while (in_node.GetInt("NEXT_SEQ_NUM") > 0);

            if (spdTrendChart.ActiveSheet.RowCount > 0)
            {
                d_total = d_total / spdTrendChart.ActiveSheet.RowCount;
                for (i = 0; i < spdTrendChart.ActiveSheet.RowCount; i++)
                {
                    d_consume = MPCF.ToDbl(spdTrendChart.ActiveSheet.Cells[i, 3].Value);

                    chtTrend.Series["Elapsed"].Points.AddY(d_consume);
                    chtTrend.Series["Average"].Points.AddY(d_total);
                    chtTrend.Series["Elapsed"].Points[i].AxisLabel = spdTrendChart.ActiveSheet.Cells[i, 0].Value.ToString();

                    if (chkShowWithServiceCount.Checked == true)
                    {
                        d_service_count = MPCF.ToDbl(spdTrendChart.ActiveSheet.Cells[i, 1].Value);
                        d_service_count = d_service_count / i_compress_rate;
                        chtTrend.Series["ServiceCount"].Points.AddY(d_service_count);
                    }
                }

                lblAverage.Text = "Average : " + d_total.ToString("0.###");
            }

            return true;
        }

        private bool View_Service_Consume_Time_Worst()
        {
            TRSNode in_node = new TRSNode("View_Service_Consume_Time_In");
            TRSNode out_node = new TRSNode("View_Service_Consume_Time_Out");
            int i;
            int i_row;
            List<TRSNode> list;
            double d_consume;

            foreach (Series series in chtWorst.Series)
            {
                series.Points.Clear();
            }
            MPCF.ClearList(spdWorstChart);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("SYSTEM_NODE", MPCF.Trim(txtSystemNode.Text));
            in_node.AddString("SERVER_NAME", MPCF.Trim(txtServerName.Text));
            in_node.AddString("SUBNO", MPCF.Trim(txtSubNo.Text));
            in_node.AddString("SERVICE_NAME", MPCF.Trim(cdvService.Text));

            /* 2013.06.12. Aiden. 조회 조건 추가 */
            in_node.AddString("FROM_TRAN_TIME", MPCF.ToStandardTime(dtpFrom.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
            in_node.AddString("TO_TRAN_TIME", MPCF.ToStandardTime(dtpTo.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
            in_node.AddDouble("AVG_CONSUME_SEC", MPCF.ToDbl(txtElapsedTime.Text));
            in_node.AddInt("SERVICE_COUNT", MPCF.ToInt(txtServiceCount.Text));

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_Consume_Time", in_node, ref out_node) == false)
                {
                    return false;
                }

                list = out_node.GetList(0);
                for (i = 0; i < list.Count; i++)
                {
                    i_row = spdWorstChart.ActiveSheet.RowCount;
                    spdWorstChart.ActiveSheet.RowCount++;

                    spdWorstChart.ActiveSheet.Cells[i_row, 0].Value = list[i].GetString("SERVICE_NAME");
                    spdWorstChart.ActiveSheet.Cells[i_row, 1].Value = list[i].GetInt("SERVICE_COUNT");
                    spdWorstChart.ActiveSheet.Cells[i_row, 2].Value = list[i].GetDouble("TOTAL_CONSUME_SEC");
                    spdWorstChart.ActiveSheet.Cells[i_row, 3].Value = list[i].GetDouble("AVG_CONSUME_SEC");
                }

                in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
            } while (in_node.GetInt("NEXT_SEQ_NUM") > 0);

            if (spdWorstChart.ActiveSheet.RowCount > 0)
            {
                for (i = 0; i < (spdWorstChart.ActiveSheet.RowCount > 10 ? 10 : spdWorstChart.ActiveSheet.RowCount); i++)
                {
                    d_consume = MPCF.ToDbl(spdWorstChart.ActiveSheet.Cells[i, 3].Value);

                    chtWorst.Series["Service"].Points.AddY(d_consume);
                    chtWorst.Series["Service"].Points[i].LegendText = MPCF.Trim(spdWorstChart.ActiveSheet.Cells[i, 0].Value);
                }
            }

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtSystemNode;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmSVMViewServicePerformance_Activated(object sender, System.EventArgs e)
        {

            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList);
                MPCF.ClearList(spdTrendChart);
                MPCF.ClearList(spdWorstChart);

                foreach (Series series in chtTrend.Series)
                {
                    series.Points.Clear();
                }
                foreach (Series series in chtWorst.Series)
                {
                    series.Points.Clear();
                }
                cboCompressRate.SelectedIndex = 0;

                dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                dtpTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                b_load_flag = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }

            switch (tabItems.SelectedIndex)
            {
                case 0:
                    View_Service_Performance_Info_List();
                    break;

                case 1:
                    View_Service_Consume_Time_Trend();
                    break;

                case 2:
                    View_Service_Consume_Time_Worst();
                    break;
            }
        }

        private void cdvService_ButtonPress(object sender, EventArgs e)
        {
            cdvService.Init();
            MPCF.InitListView(cdvService.GetListView);
            cdvService.Columns.Add("Bonus Code", 150, HorizontalAlignment.Left);
            cdvService.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvService.SelectedSubItemIndex = 0;
            View_Service_List(cdvService.GetListView);
        }

        /* 2013.06.12. Aiden. spread 의 Excel Export 기능으로 변경 */
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (sfdExcel.ShowDialog(this) == DialogResult.Cancel) return;

            if (tabItems.SelectedTab == tbpData)
            {
                spdList.ActiveSheet.Protect = false;
                spdList.SaveExcel(sfdExcel.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
            }
            else if (tabItems.SelectedTab == tbpTrendChart)
            {
                spdTrendChart.ActiveSheet.Protect = false;
                spdTrendChart.SaveExcel(sfdExcel.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
            }
            else if (tabItems.SelectedTab == tbpWorst)
            {
                spdWorstChart.ActiveSheet.Protect = false;
                spdWorstChart.SaveExcel(sfdExcel.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
            }
        }

        private void chtTrend_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = chtTrend.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chtTrend_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chtTrend.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                spdTrendChart.ActiveSheet.SetActiveCell(result.PointIndex, 0);
                spdTrendChart.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left);

                spdTrendChart.ActiveSheet.ClearSelection();
                spdTrendChart.ActiveSheet.AddSelection(result.PointIndex, 0, 1, spdTrendChart.ActiveSheet.ColumnCount);
                spdTrendChart.Focus();
            }
        }

        private void chkShowWithServiceCount_CheckedChanged(object sender, EventArgs e)
        {
            lblCompressRate.Visible = chkShowWithServiceCount.Checked;
            cboCompressRate.Visible = chkShowWithServiceCount.Checked;
        }

        private void chtWorst_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Call Hit Test Method
            HitTestResult result = chtWorst.HitTest(e.X, e.Y);

            // Reset Data Point Attributes
            foreach (DataPoint point in chtWorst.Series[0].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }

            // If a Data Point or a Legend item is selected.
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // Set cursor type 
                this.Cursor = Cursors.Hand;

                // Find selected data point
                DataPoint point = chtWorst.Series[0].Points[result.PointIndex];

                // Set End Gradient Color to White
                point.BackSecondaryColor = Color.White;

                // Set selected hatch style
                point.BackHatchStyle = ChartHatchStyle.Percent25;

                // Increase border width
                point.BorderWidth = 2;

                spdWorstChart.ActiveSheet.SetActiveCell(result.PointIndex, 0);
                spdWorstChart.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left);

                spdWorstChart.ActiveSheet.ClearSelection();
                spdWorstChart.ActiveSheet.AddSelection(result.PointIndex, 0, 1, spdTrendChart.ActiveSheet.ColumnCount);
                spdWorstChart.Focus();
            }
            else
            {
                // Set default cursor
                this.Cursor = Cursors.Default;
            }

        }

    }
}

