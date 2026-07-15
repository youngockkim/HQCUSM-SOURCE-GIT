using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPViewLotBonusList : Miracom.MESCore.ViewForm01
    {
        public frmWIPViewLotBonusList()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "
        private string BonusTable = "";
        #endregion

        #region " Function Definition "

        //
        // View_Bonus_Lot_List()
        //       -  View Bonus Lot List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Bonus_Lot_List()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_BONUS_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_BONUS_LIST_OUT");
            int i, j, k;
            int iRow;
            int iDataRow;
            int iDataCol;

            MPCF.ClearList(spdList, true);
            spdList.Sheets[0].ColumnCount = 11;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
            in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
            in_node.AddString("BONUS_CODE", MPCF.Trim(cdvBonusCode.Text));
            in_node.AddChar("INCLUDE_DEL_HIST", chkInculdeDelHist.Checked == true ? 'Y' : ' ');
            in_node.AddChar("QTY_FLAG", MPCF.ToChar(cboQty.Text));
            in_node.AddInt("NEXT_SEQ", 0);
            
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_Bonus_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                //fill in all the columns
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdList.Sheets[0].RowCount;

                    if (out_node.GetList(0)[i].GetList(0).Count <= 0) continue;

                    spdList.Sheets[0].RowCount++;

                    spdList.Sheets[0].Cells[iRow, 0].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                    spdList.Sheets[0].Cells[iRow, 1].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                    spdList.Sheets[0].Cells[iRow, 2].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                    spdList.Sheets[0].Cells[iRow, 3].Value = out_node.GetList(0)[i].GetChar("QTY_FLAG");
                    spdList.Sheets[0].Cells[iRow, 4].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    spdList.Sheets[0].Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER"));
                    spdList.Sheets[0].Cells[iRow, 6].Value = out_node.GetList(0)[i].GetString("FLOW");
                    spdList.Sheets[0].Cells[iRow, 7].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");
                    spdList.Sheets[0].Cells[iRow, 8].Value = out_node.GetList(0)[i].GetString("OPER");
                    spdList.Sheets[0].Cells[iRow, 9].Value = out_node.GetList(0)[i].GetString("RES_ID");
        
                    string sBonusCode = String.Empty;
                    bool bInputValue;
                    for (j = 0; j < out_node.GetList(0)[i].GetList(0).Count; j++)
                    {
                        bInputValue = false;

                        for (k = 10; k < spdList.Sheets[0].ColumnCount; k++)
                        {
                            sBonusCode = out_node.GetList(0)[i].GetList(0)[j].GetString("BONUS_CODE");
                            if (spdList.Sheets[0].ColumnHeader.Columns[k].Label == sBonusCode)
                            {
                                spdList.Sheets[0].Cells[iRow, k].Value = out_node.GetList(0)[i].GetList(0)[j].GetDouble("BONUS_QTY");
                                bInputValue = true;
                                break;
                            }
                        }

                        if (bInputValue == false)
                        {
                            spdList.Sheets[0].ColumnCount++;
                            spdList.Sheets[0].Cells[iRow, k].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                            spdList.Sheets[0].ColumnHeader.Columns[k].Label = sBonusCode;
                            spdList.Sheets[0].Cells[iRow, k].Value = out_node.GetList(0)[i].GetList(0)[j].GetDouble("BONUS_QTY");
                        }
                    }
                    iDataRow = spdList.Sheets[0].RowCount;
                    spdList.Sheets[0].Cells[iRow, 10].Formula = "SUM(R" + iDataRow.ToString() + "C12:R" + iDataRow.ToString() + "C" + spdList.Sheets[0].ColumnCount.ToString() +")";
                    spdList.Sheets[0].Cells[iRow, 10].Font = new Font("MS Sans Serif", 8, FontStyle.Bold);
                }

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);

            spdList.Sheets[0].RowCount++;
            iDataRow = spdList.Sheets[0].RowCount - 1;

            spdList.Sheets[0].AddSpanCell(iDataRow, 0, 1, 10);
            spdList.Sheets[0].Cells[iDataRow, 0].BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            spdList.Sheets[0].Cells[iDataRow, 0].Value = "Total Bonus Quantity";
            spdList.Sheets[0].Cells[iDataRow, 0].Font = new Font("MS Sans Serif", 8, FontStyle.Bold);
            spdList.Sheets[0].Cells[iDataRow, 0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdList.Sheets[0].Cells[iDataRow, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            for (i = 10; i < spdList.Sheets[0].ColumnCount; i++)
            {
                spdList.Sheets[0].Cells[iDataRow, i].BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                spdList.Sheets[0].Cells[iDataRow, i].Font = new Font("MS Sans Serif", 8, FontStyle.Bold);
                spdList.Sheets[0].Cells[iDataRow, i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                iDataCol = i + 1;
                if (spdList.Sheets[0].RowCount > 1)
                {
                    spdList.Sheets[0].Cells[iDataRow, i].Formula = "SUM(R1C" + iDataCol.ToString() + ":R" + iDataRow.ToString() + "C" + iDataCol.ToString() + ")";
                }
            }

            MPCF.FitColumnHeader(spdList);

            return true;
        }

        //
        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation()
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", cdvOperation.Text);

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            BonusTable = out_node.GetString("BONUS_TBL");
            if (BonusTable == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(248));
                return false;
            }

            return true;
        }

        public virtual Control GetFirstFocusItem()
        {

            try
            {
                return this.txtLotID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {
            View_Bonus_Lot_List();
        }

        private void frmWIPViewLotBonusList1_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = dtpTo.Value.AddDays(-7);
            MPCF.FieldClear(this);
            MPCF.ClearList(spdList, true);
            MPCF.FitColumnHeader(spdList);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "Lot ID : " + MPCF.Trim(txtLotID.Text) + "\r";
            sCond = sCond + "Material : " + MPCF.Trim(cdvMaterial.Text) + "\r";
            sCond = sCond + "Version : " + cdvMaterial.Version + "\r";
            sCond = sCond + "Flow : " + MPCF.Trim(cdvFlow.Text) + "\r";
            sCond = sCond + "Operation: " + MPCF.Trim(cdvOperation.Text) + "\r";
            sCond = sCond + "Resource ID : " + MPCF.Trim(cdvResID.Text) + "\r";
            sCond = sCond + "Bonus Code : " + MPCF.Trim(cdvBonusCode.Text) + "\r";
            sCond = sCond + "Delete Flag : " + Convert.ToString(chkInculdeDelHist.Checked == true ? 'Y' : 'N') +"\r";
            sCond = sCond + "Date : " + dtpFrom.Value.ToString("yyyy/MM/dd") + " ~ " + dtpTo.Value.ToString("yyyy/MM/dd");

            if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }

        private void cdvOperation_ButtonPress(object sender, EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;

            WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "");
            
        }

        private void cdvResID_ButtonPress(object sender, EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            cdvResID.DisplaySubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResID.GetListView, true);
        }

        private void cdvBonusCode_ButtonPress(object sender, EventArgs e)
        {
            if (cdvOperation.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108) + " [Operation]");
                cdvOperation.Focus();
                return;
            }

            //clear the bonus code list first
            cdvBonusCode.Init();
            cdvBonusCode.Text = "";

            //get the operation first before you can get bonus code
            if (View_Operation() == false)
            {
                return;
            }
            
            cdvBonusCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvBonusCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvBonusCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvBonusCode.GetListView, '1', BonusTable);
        }

        private void cdvFlow_ButtonPress(object sender, EventArgs e)
        {
            cdvFlow.Init();
            cdvFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;

            WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "");            
        }
    }
}

