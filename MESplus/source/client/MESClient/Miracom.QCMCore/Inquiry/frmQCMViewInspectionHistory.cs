using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;

using Miracom.TRSCore;

namespace Miracom.QCMCore
{
    public partial class frmQCMViewInspectionHistory : Miracom.MESCore.ViewForm01
    {
        public frmQCMViewInspectionHistory()
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
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":

                    if (dtpFrom.Value > dtpTo.Value)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(120));
                        dtpFrom.Value = DateTime.Today.AddMonths(-1);
                        return false;
                    }
                    break;

            }

            return true;

        }

        // View_Inspection_History()
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool View_Inspection_History()
        {

            FarPoint.Win.Spread.SheetView shtHistory;
            int i;
            int iRow;
            int iCol;

            try
            {

                MPCF.ClearList(spdBatchHistory, true);
                MPCF.ClearList(spdItemHistory, true);

                TRSNode in_node = new TRSNode("VIEW_INSPECTION_HISTORY_IN");
                TRSNode out_node = new TRSNode("VIEW_INSPECTION_HISTORY_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddInt("NEXT_HIST_SEQ", 0);

                shtHistory = spdBatchHistory.Sheets[0];

                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Inspection_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        TRSNode node = out_node.GetList(0)[i];

                        iRow = shtHistory.RowCount;

                        shtHistory.RowCount++;

                        iCol = 0;

                        shtHistory.Cells[iRow, iCol].Value = node.GetInt("BATCH_HIST_SEQ");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("INSP_SET_ID");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetInt("INSP_SET_VERSION");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("INSP_ITEM");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("INSP_METHOD");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetDouble("SAMPLE_QTY");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetDouble("TEST_QTY");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetDouble("DEFECT_QTY"); 

                        iCol++;
                        if (node.GetChar("RESULT_FLAG") == 'P')
                        {
                            shtHistory.Cells[iRow, iCol].Value = "PASS";
                        }
                        else if (node.GetChar("RESULT_FLAG") == 'F')
                        {
                            shtHistory.Cells[iRow, iCol].Value = "FAIL";
                        }

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetInt("INSP_SEQ");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_1");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_2");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_3");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_4");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_5");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_6");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_7");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_8");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_9");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_10");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_COMMENT");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("USER_ID");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(node.GetString("TRAN_TIME"));

                        iCol++;

                    }

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);


                MPCF.FitColumnHeader(spdBatchHistory);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        // View_Item_Inspection_History()
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool View_Item_Inspection_History(string s_batch_id, int i_insp_seq, string s_insp_set_id, int i_insp_set_ver, string s_insp_item)
        {

            FarPoint.Win.Spread.SheetView shtHistory;
            int i;
            int iRow;
            int iCol;

            MPCF.ClearList(spdItemHistory, true);

            TRSNode in_node = new TRSNode("VIEW_ITEM_INSPECTION_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_ITEM_INSPECTION_HISTORY_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("BATCH_ID", MPCF.Trim(s_batch_id));
            in_node.AddInt("INSP_SEQ", i_insp_seq);
            in_node.AddString("INSP_SET_ID", MPCF.Trim(s_insp_set_id));
            in_node.AddInt("INSP_SET_VERSION", i_insp_set_ver);
            in_node.AddString("INSP_ITEM", MPCF.Trim(s_insp_item));
            in_node.AddString("NEXT_ITEM_ID", "");

            shtHistory = spdItemHistory.Sheets[0];

            do
            {
                if (MPCR.CallService("QCM", "QCM_View_Item_Inspection_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    TRSNode node = out_node.GetList(0)[i];

                    iRow = shtHistory.RowCount;

                    shtHistory.RowCount++;

                    iCol = 0; 
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ITEM_ID"); 

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetDouble("SAMPLE_QTY");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetDouble("TEST_QTY");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetDouble("DEFECT_QTY");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetInt("INSP_SEQ");

                    iCol++;
                    if (node.GetChar("RESULT_FLAG") == 'P')
                    {
                        shtHistory.Cells[iRow, iCol].Value = "PASS";
                    }
                    else if (node.GetChar("RESULT_FLAG") == 'F')
                    {
                        shtHistory.Cells[iRow, iCol].Value = "FAIL";
                    }

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("DEFECT_CODE");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_1");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_2");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_3");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_4");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_5");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_6");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_7");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_8");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_9");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_CMF_10");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("ISP_COMMENT");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = node.GetString("USER_ID");

                    iCol++;
                    shtHistory.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(node.GetString("TRAN_TIME"));

                }

                in_node.SetString("NEXT_ITEM_ID", out_node.GetString("NEXT_ITEM_ID"));

            } while (in_node.GetString("NEXT_ITEM_ID") != "");


            MPCF.FitColumnHeader(spdItemHistory);

            return true;

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtBatchID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmQCMViewInspectionHistory_Load(object sender, EventArgs e)
        {

        }

        private void frmQCMViewInspectionHistory_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {

                MPCF.FieldClear(this);
                MPCF.ClearList(spdBatchHistory, true);
                MPCF.ClearList(spdItemHistory, true);
                MPCF.FitColumnHeader(spdBatchHistory);
                MPCF.FitColumnHeader(spdItemHistory);

                dtpFrom.Value = DateTime.Today.AddMonths(-1);
                dtpTo.Value = DateTime.Today;

                b_load_flag = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            View_Inspection_History();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;
            FarPoint.Win.Spread.FpSpread spdData = null;

            spdData = spdBatchHistory;

            sCond = "Batch ID : " + MPCF.Trim(txtBatchID.Text);
            MPCF.ExportToExcel(spdData, this.Text, sCond);
        }

        private void btnExcel1_Click(object sender, EventArgs e)
        {
            string sCond;
            FarPoint.Win.Spread.FpSpread spdData = null;

            spdData = spdItemHistory;

            sCond = "Batch ID : " + MPCF.Trim(txtBatchID.Text);
            MPCF.ExportToExcel(spdData, this.Text, sCond);
        }

        private void txtBatchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtBatchID.Text != "")
                {
                    btnView.PerformClick();
                }
            }

        }

        private void spdBatchHistory_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdBatchHistory.Sheets[0];
                if (with_1.Rows.Count <= 0)
                {
                    return;
                }

                if (e.Row < 0)
                {
                    return;
                }

                View_Item_Inspection_History(txtBatchID.Text,
                                             MPCF.ToInt(with_1.Cells[e.Row, 9].Value),
                                             MPCF.Trim(with_1.Cells[e.Row,1].Value),
                                             MPCF.ToInt(with_1.Cells[e.Row,2].Value),
                                             MPCF.Trim(with_1.Cells[e.Row,3].Value));

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        } 
    }
}



