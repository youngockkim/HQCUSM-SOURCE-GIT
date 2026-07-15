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
    public partial class frmQCMViewQCBatchHistory : Miracom.MESCore.ViewForm01
    {
        public frmQCMViewQCBatchHistory()
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

        // View_QC_Batch_History()
        //       - View all Flow List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Flow
        //        - Optional ByVal sOper As String = ""        : sOperÎ•?Í∞ÄÏß?Flow
        //        - Optional ByVal sMaterial As String = ""    : sMaterialÎ•?Í∞ÄÏß?Flow
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        private bool View_QC_Batch_History()
        {

            FarPoint.Win.Spread.SheetView shtHistory; 
            int i;
            int iRow;
            int iCol;

            try
            {

                MPCF.ClearList(spdHistory, true); 

                TRSNode in_node = new TRSNode("VIEW_QC_BATCH_HISTORY_IN");
                TRSNode out_node = new TRSNode("VIEW_QC_BATCH_HISTORY_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddInt("NEXT_HIST_SEQ", 0);


                shtHistory = spdHistory.Sheets[0]; 

                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_QC_Batch_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        TRSNode node = out_node.GetList(0)[i];

                        iRow = shtHistory.RowCount;

                        shtHistory.RowCount++;

                        iCol = 0;

                        shtHistory.Cells[iRow, iCol].Value = node.GetInt("HIST_SEQ");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("INSP_METHOD");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("MAT_ID");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetInt("MAT_VER"); 

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("INSP_SET_ID");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetInt("INSP_SET_VERSION");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetInt("ITEM_COUNT");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetDouble("TOT_QTY_1");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("INSP_STEP");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("TRAN_CODE");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("FINAL_DECISION");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetInt("INSP_SEQ");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_1");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_2");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_3");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_4");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_5");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_6");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_7");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_8");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_9");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_10");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("HIS_COMMENT");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = node.GetString("USER_ID");

                        iCol++;
                        shtHistory.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(node.GetString("TRAN_TIME")); 

                        iCol++;

                    }

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);


                MPCF.FitColumnHeader(spdHistory); 

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

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

        private void frmQCMViewQCBatchHistory_Load(object sender, EventArgs e)
        {

        }

        private void frmQCMViewQCBatchHistory_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {

                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory, true);
                MPCF.FitColumnHeader(spdHistory); 

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
            View_QC_Batch_History();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;
            FarPoint.Win.Spread.FpSpread spdData = null;
             
            spdData = spdHistory;

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
    }
}

