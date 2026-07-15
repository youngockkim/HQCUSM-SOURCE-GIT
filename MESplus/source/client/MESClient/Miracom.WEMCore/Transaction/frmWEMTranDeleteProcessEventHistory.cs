using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WEMCore
{
    public partial class frmWEMTranDeleteProcessEventHistory : TranForm02
    {
        public frmWEMTranDeleteProcessEventHistory()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        private bool ViewProcessEventHistory()
        {
            TRSNode in_node = new TRSNode("VIEW_EVENT_HISTORY_IN");
            TRSNode out_node;
            List<TRSNode> lis_hist;
            List<TRSNode> lis_proc_hist;
            List<TRSNode> lis_status;
            int i_row;
            int i_col;

            int i_sts_start_col;
            int i_sts_end_col;

            MPCF.ClearList(spdHistory);
            if (spdHistory.ActiveSheet.ColumnCount > 14)
            {
                spdHistory.ActiveSheet.Columns.Remove(7, spdHistory.ActiveSheet.ColumnCount - 14);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));
            in_node.AddString("PROC_ID", MPCF.Trim(cdvProcID.Text));
            in_node.AddString("PROC_EVENT_ID", MPCF.Trim(cdvProcEventID.Text));

            lis_hist = new List<TRSNode>();

            do
            {
                out_node = new TRSNode("VIEW_EVENT_HISTORY_OUT");

                if (MPCR.CallService("WEM", "WEM_View_Event_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                lis_hist.Add(out_node);

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
            } while(in_node.GetInt("NEXT_HIST_SEQ") > 0);


            foreach (TRSNode node in lis_hist)
            {
                lis_proc_hist = node.GetList("HIST_LIST");
                foreach (TRSNode hist_node in lis_proc_hist)
                {
                    i_row = spdHistory.ActiveSheet.RowCount;
                    spdHistory.ActiveSheet.RowCount++;
                    i_col = 0;

                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetInt("HIST_SEQ");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = MPCF.MakeDateFormat(hist_node.GetString("TRAN_TIME"));
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetString("STEP_ID");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetChar("PROC_STATUS");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetString("LAST_STEP_ID");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetString("LAST_STEP_APPROVER");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = MPCF.MakeDateFormat(hist_node.GetString("LAST_STEP_FINISH_TIME"));
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetString("STEP_APPROVER");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetChar("STEP_APPROVER_TYPE");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetString("TRAN_USER_ID");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetString("TRAN_COMMENT");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = MPCF.MakeDateFormat(hist_node.GetString("HIST_DEL_TIME"));
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetString("HIST_DEL_USER_ID");
                    spdHistory.ActiveSheet.Cells[i_row, i_col++].Value = hist_node.GetString("HIST_DEL_COMMENT");
                }
            }

            i_sts_start_col = i_sts_end_col = -1;
            i_row = -1;

            foreach (TRSNode node in lis_hist)
            {
                lis_proc_hist = node.GetList("HIST_LIST");
                foreach (TRSNode hist_node in lis_proc_hist)
                {
                    i_row++;
                    lis_status = hist_node.GetList("STATUS_LIST");

                    foreach (TRSNode sts_node in lis_status)
                    {
                        if (i_sts_start_col < 0)
                        {
                            spdHistory.ActiveSheet.Columns.Add(7, 1);
                            i_sts_start_col = i_sts_end_col = 7;
                            i_col = 7;
                            spdHistory.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = sts_node.GetString("STATUS");
                            spdHistory.ActiveSheet.Columns[i_col].Locked = true;
                            spdHistory.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                            spdHistory.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
                        }
                        else
                        {
                            for (i_col = i_sts_start_col; i_col <= i_sts_end_col; i_col++)
                            {
                                if (sts_node.GetString("STATUS") == MPCF.Trim(spdHistory.ActiveSheet.ColumnHeader.Cells[0, i_col].Value))
                                {
                                    break;
                                }
                            }
                            if (i_col > i_sts_end_col)
                            {
                                spdHistory.ActiveSheet.Columns.Add(i_col, 1);
                                i_sts_end_col = i_col;
                                spdHistory.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = sts_node.GetString("STATUS");
                                spdHistory.ActiveSheet.Columns[i_col].Locked = true;
                                spdHistory.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                spdHistory.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
                            }
                        }

                        spdHistory.ActiveSheet.Cells[i_row, i_col].Value = sts_node.GetString("ST_VALUE");
                    }
                }
            }

            MPCF.FitColumnHeader(spdHistory);

            return true;
        }

        private bool DeleteProcessEventHistory()
        {
            TRSNode in_node = new TRSNode("DELETE_EVENT_HISTORY_IN");
            TRSNode out_node = new TRSNode("DELETE_EVENT_HISTORY_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("PROC_EVENT_ID", MPCF.Trim(cdvProcEventID.Text));
            in_node.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdHistory.ActiveSheet.Cells[0, 0].Value));
            in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtComment.Text));

            if (MPCR.CallService("WEM", "WEM_Delete_Event_History", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }
                    
        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvProcType;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWEMTranDeleteProcessEventHistory_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdHistory);

                b_load_flag = true;
            }
        }

        private void cdvProcType_ButtonPress(object sender, EventArgs e)
        {
            cdvProcType.Init();
            MPCF.InitListView(cdvProcType.GetListView);
            cdvProcType.Columns.Add("Process Type", 150, HorizontalAlignment.Left);
            cdvProcType.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvProcType.SelectedSubItemIndex = 0;
            cdvProcType.SelectedDescIndex = 1;
            WEMLIST.ViewWorkProcessTypeList(cdvProcType.GetListView);
        }

        private void cdvProcType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvProcID.Text = "";
            cdvProcEventID.Text = "";
        }

        private void cdvProcID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return;

            cdvProcID.Init();
            MPCF.InitListView(cdvProcID.GetListView);
            cdvProcID.Columns.Add("Process ID", 150, HorizontalAlignment.Left);
            cdvProcID.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvProcID.SelectedSubItemIndex = 0;
            cdvProcID.SelectedDescIndex = 1;
            WEMLIST.ViewWorkProcessList(cdvProcID.GetListView, cdvProcType.Text);
        }

        private void cdvProcID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvProcEventID.Text = "";
        }

        private void cdvProcEventID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return;
            if (MPCF.CheckValue(cdvProcID, 1) == false) return;

            cdvProcEventID.Init();
            MPCF.InitListView(cdvProcEventID.GetListView);
            cdvProcEventID.Columns.Add("Process Event ID", 150, HorizontalAlignment.Left);
            cdvProcEventID.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvProcEventID.SelectedSubItemIndex = 0;
            cdvProcEventID.SelectedDescIndex = 1;
            WEMLIST.ViewWorkProcessEventList(cdvProcEventID.GetListView, cdvProcType.Text, cdvProcID.Text);
        }

        private void cdvProcEventID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvProcEventID.Text) != "")
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (spdHistory.ActiveSheet.RowCount < 1) return;
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;

            if (DeleteProcessEventHistory() == false) return;

            txtComment.Text = "";
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return;
            if (MPCF.CheckValue(cdvProcID, 1) == false) return;
            if (MPCF.CheckValue(cdvProcEventID, 1) == false) return;

            ViewProcessEventHistory();
        }


    }
}
