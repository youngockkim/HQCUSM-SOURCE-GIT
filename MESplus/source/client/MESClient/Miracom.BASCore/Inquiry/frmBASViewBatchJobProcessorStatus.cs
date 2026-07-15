//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASViewBatchJobProcessorStatus.vb
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
    public partial class frmBASViewBatchJobProcessorStatus : Miracom.MESCore.SetupForm02
    {
        public frmBASViewBatchJobProcessorStatus()
        {
            InitializeComponent();
        }

        #region " Variable Definition"

        bool b_LoadFlag = false;

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
        private bool CheckCondition(string FuncName, char ProcStep)
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

        /// <summary>
        /// Clear Control Data by Step
        /// </summary>
        /// <param name="ProcStep"></param>
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
        // View_Batch_Job_Processor_Status()
        //       - View Batch Process Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Batch_Job_Processor_Status()
        {
            TRSNode in_node = new TRSNode("VIEW_JOB_PROCESSOR_STATUS_IN");
            TRSNode out_node = new TRSNode("VIEW_JOB_PROCESSOR_STATUS_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("JOB_PROC_ID", txtBatPrc.Text);

                if (MPCR.CallService("BAS", "BAS_View_Batch_Job_Processor_Status", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("STATUS_FLAG") == 'P')
                {
                    txtJobStatus.Text = "Process";
                }
                else if (out_node.GetChar("STATUS_FLAG") == 'S')
                {
                    txtJobStatus.Text = "Success";
                }
                else if (out_node.GetChar("STATUS_FLAG") == 'F')
                {
                    txtJobStatus.Text = "Fail";
                }
                else
                {
                    txtJobStatus.Text = MPCF.Trim(out_node.GetChar("STATUS_FLAG"));
                }

                if (MPCF.Trim(out_node.GetString("START_TIME")) != "")
                {
                    txtStartTime.Text = MPCF.Trim(MPCF.MakeDateFormat(out_node.GetString("START_TIME")));
                }

                if (MPCF.Trim(out_node.GetString("END_TIME")) != "")
                {
                    txtEndTime.Text = MPCF.Trim(MPCF.MakeDateFormat(out_node.GetString("END_TIME")));
                }

                txtElapsedTime.Text = MPCF.Trim(out_node.GetDouble("ELAPSED_TIME"));
                txtLastSubNo.Text = MPCF.Trim(out_node.GetString("PROC_RUN_SUBNO"));
                txtLastHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));
                txtErrorMsg.Text = MPCF.Trim(out_node.GetString("ERROR_MSG"));
                txtDBErrorMsg.Text = MPCF.Trim(out_node.GetString("DB_ERROR_MSG"));

                txtProcKey1.Text = MPCF.Trim(out_node.GetString("PROC_KEY_1"));
                txtProcKey2.Text = MPCF.Trim(out_node.GetString("PROC_KEY_2"));
                txtProcKey3.Text = MPCF.Trim(out_node.GetString("PROC_KEY_3"));
                txtProcKey4.Text = MPCF.Trim(out_node.GetString("PROC_KEY_4"));
                txtProcKey5.Text = MPCF.Trim(out_node.GetString("PROC_KEY_5"));

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

        private void frmBASViewBatchJobProcessorStatus_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_LoadFlag == false)
                {
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

                    b_LoadFlag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void frmBASViewBatchJobProcessorStatus_Load(object sender, EventArgs e)
        {
            try
            {
                MPCF.InitListView(lisBatPrc);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmBASViewBatchJobProcessorHistory", false);
                if (form == null)
                {
                    form = new frmBASViewBatchJobProcessorHistory();
                    form.MdiParent = MPGV.gfrmMDI;
                }

                ((frmBASViewBatchJobProcessorHistory)form).JobProcID = txtBatPrc.Text;
                form.BringToFront();
                form.Show();
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

                    View_Batch_Job_Processor_Status();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
    }
}
