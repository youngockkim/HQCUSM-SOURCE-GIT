using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.SECCore
{
    public partial class frmSECViewFunctionUsage : ViewForm01
    {
        public frmSECViewFunctionUsage()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag = false;

        #endregion

        #region " Function Definition "

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdList);
                    cdvProgramID.Text = MPGV.gsProgramID;
                    //MPCF.ClearList(spdTab);
                    //MPCF.ClearList(spdField);
                    //MPCF.ClearList(spdOption);
                    //tvAttachFunc.Nodes.Clear();

                    //MPCF.FitColumnHeader(spdControl);
                    //MPCF.FitColumnHeader(spdTab);

                    //chkAddToolBar.Checked = false;
                    //chkShortCTRL.Checked = false;
                    //chkShortALT.Checked = false;
                    //chkShortSHIFT.Checked = false;
                    //cboShortKey.Text = "";

                }
                else if (ProcStep == "2")
                {
                    //MPCF.ClearList(spdControl);
                    //MPCF.ClearList(spdTab);
                    //MPCF.ClearList(spdField);
                    //MPCF.ClearList(spdOption);
                }
            }
            catch (Exception)
            {
            }
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(char ProcStep)
        {
            if (ProcStep == '1')
            {
                if (MPCF.CheckValue(cdvProgramID, 1) == false)
                {
                    return false;
                }
            }

            return true;
        }


        private bool ViewUsgeData(char cProcStep)
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_USAGE_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_USAGE_OUT");
            ArrayList a_list = new ArrayList();
            FarPoint.Win.Spread.SheetView sheet = spdList_Sheet1;

            int i, iRow, iCol;

            try
            {
                MPCF.ClearList(spdList, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;
                in_node.AddString("PROGRAM_ID", MPCF.Trim(cdvProgramID.Text));
                in_node.AddString("FROM_DATE", MPCF.ToStandardTime(dtpFrom.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddString("TO_DATE", MPCF.ToStandardTime(dtpTo.Value, MPGC.MP_CONVERT_DATE_FORMAT));

                do
                {
                    if (MPCR.CallService("SEC", "SEC_View_Function_Usage", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_TRAN_DATE", out_node.GetString("NEXT_TRAN_DATE"));
                    in_node.SetString("NEXT_PROGRAM_ID", out_node.GetString("NEXT_PROGRAM_ID"));
                    in_node.SetString("NEXT_FUNC_NAME", out_node.GetString("NEXT_FUNC_NAME"));
                } while (in_node.GetString("NEXT_TRAN_DATE") != "");

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = sheet.RowCount;
                        sheet.RowCount++;
                        iCol = 0;

                        sheet.Cells[iRow, iCol++].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_DATE"), DATE_TIME_FORMAT.DATE);
                        sheet.Cells[iRow, iCol++].Value = out_node.GetList(0)[i].GetString("FUNC_NAME");
                        sheet.Cells[iRow, iCol++].Value = out_node.GetList(0)[i].GetString("FUNC_DESC");
                        sheet.Cells[iRow, iCol++].Value = out_node.GetList(0)[i].GetInt("USAGE_COUNT");
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }


        #endregion

        private void frmSECViewFunctionUsage_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData("1");
                b_load_flag = true;

                MPCF.ToClientLanguage(this);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckCondition('1') == true)
                {
                    ViewUsgeData('1');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvProgramID_ButtonPress(object sender, EventArgs e)
        {
            cdvProgramID.Init();
            MPCF.InitListView(cdvProgramID.GetListView);
            cdvProgramID.Columns.Add("Program ID", 50, HorizontalAlignment.Left);
            cdvProgramID.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvProgramID.GetListView, '1', MPGC.MP_SEC_PROGRAM_LIST);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(spdList, this.Text, "");            
        }
    }
}
