//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASViewBatchJobProcessorHistory.vb
//   Description : Batch Process Definition form
//
//   MES Version : 5.3.1.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Table() : View General Code Table definition
//       - View_Table_List() : View all table list which is included in one factory
//       - Update_Table() : Create/Update/Delete General code Table definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2013-08-21 : Created by DM KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;

namespace Miracom.BASCore
{
    public partial class frmBASViewBatchJobProcessorHistory : Miracom.MESCore.SetupForm02
    {
        public frmBASViewBatchJobProcessorHistory()
        {
            InitializeComponent();
        }

        #region " Variable Definition"

        private bool b_load_flag = false;
        private bool b_popup_flag = false;

        private string ms_Job_proc_id = "";

        public string JobProcID
        {
            set
            {
                ms_Job_proc_id = value;
                b_popup_flag = true;
            }            
        }

        #endregion

        #region "Function Definition"

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (MPCF.CheckValue(txtBatPrc, 1) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtBatPrc.Select();
                            return false;
                        }
                       
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this.pnlRight);
                }
                else if (ProcStep == "2")
                {
                    MPCF.ClearList(lisBatPrc, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        //
        // View_Batch_Job_Processor_History()
        //       - View Batch Process History List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Batch_Job_Processor_History()
        {
            TRSNode in_node = new TRSNode("VIEW_JOB_PROC_HISTORY_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_JOB_PROC_HISTORY_LIST_OUT");
            List<TRSNode> hist_list;

            int i;
            int iRow;
            int iCol;
       
            try
            {
                MPCF.ClearList(spdList);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("JOB_PROC_ID", txtBatPrc.Text);
                in_node.AddString("FROM_TIME", MPCF.ToStandardTime(dtpFrom.Value, MPGC.MP_CONVERT_DATE_FORMAT) + "000000");
                in_node.AddString("TO_TIME", MPCF.ToStandardTime(dtpTo.Value, MPGC.MP_CONVERT_DATE_FORMAT) + "235959");
                
                do
                {
                    if (MPCR.CallService("BAS", "BAS_View_Batch_Job_Processor_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    hist_list = out_node.GetList("HISTORY_LIST");
                    for (i = 0; i < hist_list.Count; i++)
                    {
                        iRow = spdList.ActiveSheet.RowCount;
                        spdList.ActiveSheet.RowCount++;

                        iCol = 0;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetInt("HIST_SEQ");

                        iCol++;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetString("PROC_RUN_SUBNO");

                        iCol++;
                        if (hist_list[i].GetChar("STATUS_FLAG") == 'P')
                        {
                            spdList.ActiveSheet.Cells[iRow, iCol].Value = "Process";
                        }
                        else if (hist_list[i].GetChar("STATUS_FLAG") == 'S')
                        {
                            spdList.ActiveSheet.Cells[iRow, iCol].Value = "Success";
                        }
                        else if (hist_list[i].GetChar("STATUS_FLAG") == 'F')
                        {
                            spdList.ActiveSheet.Cells[iRow, iCol].Value = "Fail";
                        }
                        else
                        {
                            spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetChar("STATUS_FLAG");
                        }
                        
                        iCol++;
                        if (MPCF.Trim(hist_list[i].GetString("START_TIME")) != "")
                        {
                            spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(hist_list[i].GetString("START_TIME"));
                        }

                        iCol++;
                        if (MPCF.Trim(hist_list[i].GetString("END_TIME")) != "")
                        {
                            spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(hist_list[i].GetString("END_TIME"));
                        }

                        iCol++;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetDouble("ELAPSED_TIME");

                        iCol++;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetString("ERROR_MSG");

                        iCol++;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetString("DB_ERROR_MSG");

                        iCol++;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetString("PROC_KEY_1");

                        iCol++;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetString("PROC_KEY_2");

                        iCol++;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetString("PROC_KEY_3");

                        iCol++;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetString("PROC_KEY_4");

                        iCol++;
                        spdList.ActiveSheet.Cells[iRow, iCol].Value = hist_list[i].GetString("PROC_KEY_5");

                        spdList.ActiveSheet.Rows[iRow].Height = spdList.ActiveSheet.GetPreferredRowHeight(iRow);
                    }

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

                } while(in_node.GetInt("NEXT_HIST_SEQ") > 0);

                MPCF.FitColumnHeader(spdList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;   
            }
        }

        /// <summary>
        /// Get First Focust Item
        /// </summary>
        /// <returns></returns>
        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.lisBatPrc;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmBASViewBatchJobProcessorHistory_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    dtpFrom.Value = DateTime.Today.AddDays(-7);
                    dtpTo.Value = DateTime.Today;

                    lblDataCount.Text = "";

                    if (BASLIST.ViewBatchJobProcessorList(lisBatPrc, '1', 1, null, "") == true)
                    {
                        lblDataCount.Text = lisBatPrc.Items.Count.ToString();
                        if (lisBatPrc.Items.Count > 0)
                        {
                            lisBatPrc.Items[0].Selected = true;
                        }
                    }
                    else
                    {
                        return;
                    }

                    b_load_flag = true;
                }

                if (b_popup_flag == true)
                {
                    txtBatPrc.Text = ms_Job_proc_id;
                    if (lisBatPrc.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisBatPrc, txtBatPrc.Text, false);
                    }

                    txtDesc.Text = lisBatPrc.SelectedItems[0].SubItems[1].Text;

                    b_popup_flag = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == true)
                {
                    View_Batch_Job_Processor_History();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisBatPrc, txtFind.Text, true, false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                if (BASLIST.ViewBatchJobProcessorList(lisBatPrc, '1', 1, null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisBatPrc.Items.Count.ToString();
                if (lisBatPrc.Items.Count > 0)
                {
                    MPCF.FindListItem(lisBatPrc, txtBatPrc.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ExportToExcel(lisBatPrc, this.Text, "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

            MPCF.FindListItemPartial(lisBatPrc, txtFind.Text, 0, true, false);
        }

        private void lisBatPrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);

                if (lisBatPrc.SelectedItems.Count > 0)
                {
                    txtBatPrc.Text = lisBatPrc.SelectedItems[0].Text;
                    txtDesc.Text = lisBatPrc.SelectedItems[0].SubItems[1].Text;

                    View_Batch_Job_Processor_History();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
    }
}
