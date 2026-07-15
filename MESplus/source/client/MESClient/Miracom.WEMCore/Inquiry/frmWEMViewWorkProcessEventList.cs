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
    public partial class frmWEMViewWorkProcessEventList : ViewForm01
    {
        public frmWEMViewWorkProcessEventList()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        private bool ViewProcessEventList()
        {
            TRSNode in_node = new TRSNode("VIEW_EVENT_LIST_IN");
            TRSNode out_node;
            List<TRSNode> lis_nodes;
            List<TRSNode> lis_events;
            List<TRSNode> lis_status;
            int i_row;
            int i_col;

            MPCF.ClearList(spdEventList);
            if (spdEventList.ActiveSheet.ColumnCount > 16)
            {
                spdEventList.ActiveSheet.ColumnCount = 16;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));
            in_node.AddString("PROC_ID", MPCF.Trim(cdvProcID.Text));
            in_node.AddString("STEP_ID", MPCF.Trim(cdvStepID.Text));
            in_node.AddChar("PROC_STATUS", MPCF.ToChar(cboEventStatus.Text));
            in_node.AddString("ASSIGNED_USER_ID", MPCF.Trim(cdvAssignedUser.Text));
            in_node.AddString("LAST_APPROVAL_USER_ID", MPCF.Trim(cdvLastApprovalUser.Text));
            in_node.AddChar("INCLUDE_STATUS_FLAG", 'Y');

            if (chkTranTime.Checked == true)
            {
                in_node.AddString("FROM_TRAN_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TRAN_TIME", MPCF.ToDate(dtpTo));
            }

            lis_nodes = new List<TRSNode>();

            do
            {
                out_node = new TRSNode("VIEW_EVENT_LIST_OUT");

                if (MPCR.CallService("WEM", "WEM_View_Event_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                lis_nodes.Add(out_node);

                in_node.SetString("NEXT_PROC_EVENT_ID", out_node.GetString("NEXT_PROC_EVENT_ID"));
            } while (in_node.GetString("NEXT_PROC_EVENT_ID") != "");


            foreach (TRSNode node in lis_nodes)
            {
                lis_events = node.GetList("PROC_EVENT_LIST");
                foreach (TRSNode event_node in lis_events)
                {
                    i_row = spdEventList.ActiveSheet.RowCount;
                    spdEventList.ActiveSheet.RowCount++;
                    i_col = 0;

                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("PROC_EVENT_ID");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("STEP_ID");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("PROC_ID");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("WORK_PROC_TYPE");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetChar("PROC_STATUS");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("LAST_STEP_ID");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("LAST_STEP_APPROVER");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = MPCF.MakeDateFormat(event_node.GetString("LAST_STEP_FINISH_TIME"));
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("LAST_TRAN_USER_ID");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = MPCF.MakeDateFormat(event_node.GetString("LAST_TRAN_TIME"));
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("REPORT_USER_ID");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = MPCF.MakeDateFormat(event_node.GetString("REPORT_TIME"));
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetChar("STEP_APPROVER_TYPE");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("STEP_APPROVER");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("PROC_EVENT_DESC");
                    spdEventList.ActiveSheet.Cells[i_row, i_col++].Value = event_node.GetString("LAST_COMMENT");
                }
            }

            i_row = -1;

            foreach (TRSNode node in lis_nodes)
            {
                lis_events = node.GetList("PROC_EVENT_LIST");
                foreach (TRSNode event_node in lis_events)
                {
                    i_row++;
                    lis_status = event_node.GetList("STATUS_LIST");

                    foreach (TRSNode sts_node in lis_status)
                    {
                        for (i_col = 16; i_col < spdEventList.ActiveSheet.ColumnCount; i_col++)
                        {
                            if (sts_node.GetString("STATUS") == MPCF.Trim(spdEventList.ActiveSheet.ColumnHeader.Cells[0, i_col].Value))
                            {
                                break;
                            }
                        }
                        if (i_col >= spdEventList.ActiveSheet.ColumnCount)
                        {
                            spdEventList.ActiveSheet.ColumnCount++;
                            spdEventList.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = sts_node.GetString("STATUS");
                            spdEventList.ActiveSheet.Columns[i_col].Locked = true;
                            spdEventList.ActiveSheet.Columns[i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                            spdEventList.ActiveSheet.Columns[i_col].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
                        }

                        spdEventList.ActiveSheet.Cells[i_row, i_col].Value = sts_node.GetString("ST_VALUE");
                    }
                }
            }

            MPCF.FitColumnHeader(spdEventList);

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

        private void frmWEMViewWorkProcessEventList_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdEventList);

                dtpFrom.Value = DateTime.Now.AddMonths(-1);
                dtpTo.Value = DateTime.Now;
                chkTranTime.Checked = false;

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
            WEMLIST.ViewWorkProcessTypeList(cdvProcType.GetListView);
            cdvProcType.InsertEmptyRow(0, 1);
        }

        private void cdvProcID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return;

            cdvProcID.Init();
            MPCF.InitListView(cdvProcID.GetListView);
            cdvProcID.Columns.Add("Process ID", 150, HorizontalAlignment.Left);
            cdvProcID.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvProcID.SelectedSubItemIndex = 0;
            WEMLIST.ViewWorkProcessList(cdvProcID.GetListView, cdvProcType.Text);
            cdvProcID.InsertEmptyRow(0, 1);
        }

        private void cdvStepID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return;

            cdvStepID.Init();
            MPCF.InitListView(cdvStepID.GetListView);
            cdvStepID.Columns.Add("Step ID", 150, HorizontalAlignment.Left);
            cdvStepID.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvStepID.SelectedSubItemIndex = 0;
            WEMLIST.ViewProcessStepList(cdvStepID.GetListView, cdvProcType.Text, cdvProcID.Text);
            cdvStepID.InsertEmptyRow(0, 1);
        }

        private void cdvAssignedUser_ButtonPress(object sender, EventArgs e)
        {
            cdvAssignedUser.Init();
            MPCF.InitListView(cdvAssignedUser.GetListView);
            cdvAssignedUser.Columns.Add("User ID", 150, HorizontalAlignment.Left);
            cdvAssignedUser.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvAssignedUser.SelectedSubItemIndex = 0;
            SECLIST.ViewSECUserList(cdvAssignedUser.GetListView);
            cdvAssignedUser.InsertEmptyRow(0, 1);
        }

        private void cdvLastApprovalUser_ButtonPress(object sender, EventArgs e)
        {
            cdvLastApprovalUser.Init();
            MPCF.InitListView(cdvLastApprovalUser.GetListView);
            cdvLastApprovalUser.Columns.Add("User ID", 150, HorizontalAlignment.Left);
            cdvLastApprovalUser.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvLastApprovalUser.SelectedSubItemIndex = 0;
            SECLIST.ViewSECUserList(cdvLastApprovalUser.GetListView);
            cdvLastApprovalUser.InsertEmptyRow(0, 1);
        }

        private void chkTranTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTranTime.Checked == true)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewProcessEventList();
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond = "";

            if (MPCF.Trim(cdvProcType.Text) != "")
            {
                sCond += "Work Process Type : " + MPCF.Trim(cdvProcType.Text) + "\r";
            }
            if (MPCF.Trim(cdvProcID.Text) != "")
            {
                sCond += "Work Process ID : " + MPCF.Trim(cdvProcID.Text) + "\r";
            }
            if (MPCF.Trim(cdvStepID.Text) != "")
            {
                sCond += "Step ID : " + MPCF.Trim(cdvStepID.Text) + "\r";
            }
            if (MPCF.Trim(cboEventStatus.Text) != "")
            {
                sCond += "Process Status : " + MPCF.Trim(cboEventStatus.Text) + "\r";
            }
            if (MPCF.Trim(cdvAssignedUser.Text) != "")
            {
                sCond += "Assigned User ID : " + MPCF.Trim(cdvAssignedUser.Text) + "\r";
            }
            if (MPCF.Trim(cdvLastApprovalUser.Text) != "")
            {
                sCond += "Last Approval User ID : " + MPCF.Trim(cdvLastApprovalUser.Text) + "\r";
            }
            if (chkTranTime.Checked == true)
            {
                sCond += "Last Tran Time : " + dtpFrom.Value.ToString("yyyy/MM/dd") + " ~ " + dtpTo.Value.ToString("yyyy/MM/dd") + "\r";
            }

            MPCF.ExportToExcel(spdEventList, this.Text, sCond);
        }




    }
}
