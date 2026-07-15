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
    public partial class frmWIPViewSublotLossList : Miracom.MESCore.ViewForm01
    {
        public frmWIPViewSublotLossList()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private string s_loss_code_tbl;

        #endregion

        #region " Function Definition "

        //
        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool ViewOperation()
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

            s_loss_code_tbl = out_node.GetString("LOSS_TBL");
            if (s_loss_code_tbl == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(248));
                return false;
            }

            return true;

        }

        // View_SubLot_Loss_List()
        //       - View Sub Lot Loss List By Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewSubLotLossList()
        {
            TRSNode in_node = new TRSNode("LOSS_LIST_IN");
            TRSNode out_node = new TRSNode("LOSS_LIST_OUT");
            int i;
            int iRow;
            int iCol;

            MPCF.ClearList(spdList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SUBLOT_ID", MPCF.Trim(txtSublotID.Text));
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
            in_node.AddString("LOSS_CODE", MPCF.Trim(cdvLossCode.Text));
            in_node.AddChar("GRADE", MPCF.ToChar(cdvGrade.Text));
            /* 2013.06.12. Aiden. QTY Flag 추가 */
            in_node.AddChar("QTY_FLAG", MPCF.ToChar(cboQtyFlag.Text));
            in_node.AddString("FROM_DATE", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_DATE", MPCF.ToDate(dtpTo));
            in_node.AddChar("INCLUDE_DEL_HIST", (chkInculdeDelHist.Checked == true ? 'Y' : ' '));
            in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_Loss_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdList.ActiveSheet.RowCount;
                    spdList.ActiveSheet.RowCount++;

                    iCol = 0;
                    if (out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG") == 'Y')
                    {
                        spdList.ActiveSheet.Rows[iRow].ForeColor = Color.Magenta;
                    }

                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("GRADE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOSS_CODE");

                    /* 2013.06.12. Aiden. Loss Qty, QTY Flag 추가 */
                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetDouble("LOSS_QTY");
                    
                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("QTY_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CAUSE_FLOW");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CAUSE_OPER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CAUSE_RES_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_USER_ID");
                }

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
            } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

            MPCF.FitColumnHeader(spdList);
            return true;
        }


        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtSublotID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmWIPViewSublotLossList_Activated(object sender, System.EventArgs e)
        {

            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList);

                dtpFrom.Value = DateTime.Today.AddMonths(-1);
                dtpTo.Value = DateTime.Today;

                b_load_flag = true;
            }
        }

        private void cdvOperation_ButtonPress(object sender, EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;

            WIPLIST.ViewOperationList(cdvOperation.GetListView, '1');
        }

        private void cdvOperation_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvLossCode.Text != "")
            {
                cdvLossCode.Text = "";
            }
        }

        private void cdvLossCode_ButtonPress(object sender, EventArgs e)
        {
            if (cdvOperation.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108) + " [Operation]");
                cdvOperation.Focus();
                return;
            }

            //clear the loss code list first
            cdvLossCode.Init();
            MPCF.InitListView(cdvLossCode.GetListView);
            cdvLossCode.Columns.Add("Loss Code", 50, HorizontalAlignment.Left);
            cdvLossCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvLossCode.SelectedSubItemIndex = 0;

            //get the operation first before you can get loss code
            if (ViewOperation() == false)
            {
                return;
            }
            BASLIST.ViewGCMDataList(cdvLossCode.GetListView, '1', s_loss_code_tbl);
        }

        private void cdvGrade_ButtonPress(object sender, EventArgs e)
        {
            cdvGrade.Init();
            MPCF.InitListView(cdvGrade.GetListView);
            cdvGrade.Columns.Add("Grade", 50, HorizontalAlignment.Left);
            cdvGrade.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvGrade.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvGrade.GetListView, '1', MPGC.MP_WIP_SUBLOT_GRADE);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtSublotID, 1) == false) return;

            ViewSubLotLossList();
        }






    }
}

