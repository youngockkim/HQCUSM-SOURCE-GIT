using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.CliFrx;
using SOI.OIFrx.SOIModel;

namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCWIPStringRepairData : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCWIPStringRepairData()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]
        public string chk_type;
        public string chk_auto_validation;
        public string chk_common_line;
        public string chk_auto;
        public enum HOUR_LIST
        {
            WORK_SHIFT,
            WORK_TIME,
            HIST_SEQ,
            TARGET_QTY,
            FEL_QTY,
            DIFF_QTY,
            TIME_LOSS,
            TYPE_4M,
            PROCESS_TYPE,
            EQ,
            DOWN_TIME,
            EFF_TIME,
            //HOUR_DESC,
            HOUR_DESC,
            CMF_2, //Root Cause
            CMF_3, //Action Plan
            EQ_MAX,
            CMF_4, //Humidity
            CMF_1
            //WORK_DATE,
            //LINE_ID,
            //HOUR_TYPE,

        }
        public enum STR_RPR_DAT
        {
            WORK_DATE,
            WORK_SHIFT,            
            OPERATOR_NAME,
            E1_QTY,
            E2_QTY,
            E3_QTY,
            TAKEN_TIME,
            LOSS_WEIGHT
        }

        #endregion

        #region [Variable Definition]
        
        #endregion

        #region Event Handler

        private void frmCUSHourGap_Load(object sender, EventArgs e)
        {
            // Init
            
            dtpDate.Value = DateTime.Now;
            dtpDate2.Value = DateTime.Now;
                      
            set_view();
           
            MPCF.ConvertCaption(this);
        }

        private void frmCUSHourGap_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpDate);

                bIsShown = true;
            }
        } 

        private void cdvShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                string[] header = new string[] { "Shift", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvShift.Text = cdvShift.Show(cdvShift, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvShift2_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            /*             {
                             TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                             MPCF.SetInMsg(in_node);
                             in_node.ProcStep = '1';
                             in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                             string[] header = new string[] { "Shift", "Description" };
                             string[] display = new string[] { "KEY_1", "DATA_1" };

                             cdvShift2.Text = cdvShift2.Show(cdvShift2, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                         }  
             */
                          // Ver 2. View Shift Codes by Date
                           {
                            //dtpWorkTimeOut = (dtpDate2.Value);

                            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                            MPCF.SetInMsg(in_node);
                            in_node.ProcStep = '1';

                            if (dtpDate2.Value != null)
                            {
                                in_node.AddString("SYS_DATE", ((DateTime)(dtpDate2.Value)).ToString("yyyyMMdd"));                            
                            }
                                               
                            string[] display = new string[] {"SHIFT" };
                            string[] header = new string[] {"Shift" };

                            cdvShift2.Text = cdvShift2.Show(cdvShift2, "View Shift", "CBAS", "CBAS_View_Shift_List", in_node, "LIST", display, header, "SHIFT");
                                            
                            // Validation
                            if (string.IsNullOrEmpty(cdvShift2.Text) == true)
                            {
                                return;
                            }

                        }          


            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void set_view()
        {
            txt_clear();
            btnProcess.Enabled = false;            
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void set_update()
        {
            txt_clear();
            btnProcess.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void set_create()
        {
            txt_clear();
            btnProcess.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }


        private void txt_clear()
        {

        }

        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_clear();
    
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == false)
                {
                    set_view();
                    return;
                }

                if (ViewStringRepairData() == false)
                {
                    set_view();
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("CREATE") == false)
                {
                    return;
                }

                if (UpdateStringRepairData(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                // Refresh
                btnView.PerformClick();
                set_view();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("UPDATE") == false)
                {
                    return;
                }

                if (UpdateStringRepairData(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                // Refresh
                btnView.PerformClick();
                set_view();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("DELETE") == false)
                {
                    return;
                }

                if (UpdateStringRepairData(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                // Refresh
                btnView.PerformClick();
                set_view();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        bool ignoreEvent = false;
        private void spdStringRepairData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                txt_clear();

                

                dtpDate2.Value = MPCF.ToDate(spdStringRepairData.Sheets[0].Cells[e.Row, (int)STR_RPR_DAT.WORK_DATE].Text);

                ignoreEvent = true;
                cdvShift2.Text = spdStringRepairData.Sheets[0].Cells[e.Row, (int)STR_RPR_DAT.WORK_SHIFT].Text;                
                cdvWorker.Text = spdStringRepairData.Sheets[0].Cells[e.Row, (int)STR_RPR_DAT.OPERATOR_NAME].Text;                
                ignoreEvent = false;

                txtE1Qty.Text = spdStringRepairData.Sheets[0].Cells[e.Row, (int)STR_RPR_DAT.E1_QTY].Text;
                txtE2Qty.Text = spdStringRepairData.Sheets[0].Cells[e.Row, (int)STR_RPR_DAT.E2_QTY].Text;
                txtE3Qty.Text = spdStringRepairData.Sheets[0].Cells[e.Row, (int)STR_RPR_DAT.E3_QTY].Text;

                txtTimeTaken.Value = spdStringRepairData.Sheets[0].Cells[e.Row, (int)STR_RPR_DAT.TAKEN_TIME].Text;
                txtLossWeight.Value = spdStringRepairData.Sheets[0].Cells[e.Row, (int)STR_RPR_DAT.LOSS_WEIGHT].Text;

                if (false == String.IsNullOrEmpty(cdvWorker.Text))
                {
                    set_update();   
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvWorker_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_WORKER_IN");
                TRSNode out_node = new TRSNode("VIEW_WORKER_OUT");

                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '8';

                in_node.AddString("TABLE_NAME", MPCF.Trim("@REPAIR_WORKER"));

                // CodeView Column Header Setup
                string[] header = new string[] { "Repair Worker", "Name" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_2", "DATA_1" };


                // Show

                cdvWorker.Text = cdvWorker.Show(cdvWorker, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_2");
                if (string.IsNullOrEmpty(cdvWorker.Text) == true)
                {
                    MPCF.SetFocus(cdvWorker);
                    return;
                }


                // Validation
                if (string.IsNullOrEmpty(cdvWorker.Text) == true)
                {
                    MPCF.SetFocus(cdvWorker);
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
     

        #endregion
        
        #region Function

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "CREATE":
                        if (string.IsNullOrEmpty(cdvShift2.Text))
                        {
                            MPCF.ShowMessage("Please enter the relevant Work Shift data.", MSG_LEVEL.ERROR, false);
                            return false;

                        }    
                        
                        if (string.IsNullOrEmpty(cdvWorker.Text))
                        {
                            MPCF.ShowMessage("Please use the pop-up menu to select a name of operator.", MSG_LEVEL.ERROR, false);
                            return false;

                        }                                                                       
                        break;                                                                 
                        
                    case "UPDATE":
                        if (string.IsNullOrEmpty(cdvShift2.Text))
                        {
                            MPCF.ShowMessage("Please enter the relevant Work Shift data.", MSG_LEVEL.ERROR, false);
                            return false;

                        }    

                        if (string.IsNullOrEmpty(cdvWorker.Text))
                        {
                            MPCF.ShowMessage("Please use the pop-up menu to select a name of operator.", MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        break;

                    case "APPEND":
                        break;

                    case "DELETE":
                        if (MPCF.ShowMsgBox("Do you want to Delete?", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return false;
                        }
                        break;

                    default:
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

        #endregion


        private bool ViewStringRepairData()
        {
            try
            {
                int i;            

                chk_type = "";

                DateTime dtpFromDateTimeOut = new DateTime();
              
                MPCF.ClearList(spdStringRepairData);
                               
                TRSNode in_node = new TRSNode("VIEW_STR_REPAIR_IN");
                TRSNode out_node = new TRSNode("VIEW_STR_REPAIR_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);

                //Append Start 12.22
                dtpDate2.Value = dtpDate.Value;

                cdvShift2.Text = ""; 
                cdvWorker.Text = ""; 
                txtE1Qty.Value = String.Empty;
                txtE2Qty.Value = String.Empty;
                txtE3Qty.Value = String.Empty;
                txtTimeTaken.Text = "";
                txtLossWeight.Value = String.Empty;
                //Append End 12.22

                in_node.ProcStep = '1';

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));                        
                    }
                }

                in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShift.Text));


                if (MPCF.CallService("CWIP", "CWIP_View_String_Repair_Data_List", in_node, ref out_node) == false)
                {
                    MPCF.ShowErrorMessage("Duplicated Operator Name");
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);
                            
                spdStringRepairData.ActiveSheet.RowCount = 0;
           
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdStringRepairData.ActiveSheet.RowCount++;

                    spdStringRepairData.ActiveSheet.Cells[i, (int)STR_RPR_DAT.WORK_DATE].Value = out_list.GetString("WORK_DATE");
                    spdStringRepairData.ActiveSheet.Cells[i, (int)STR_RPR_DAT.WORK_SHIFT].Value = out_list.GetString("WORK_SHIFT");

                     spdStringRepairData.ActiveSheet.Cells[i, (int)STR_RPR_DAT.OPERATOR_NAME].Value = out_list.GetString("OPERATOR_NAME");

                    spdStringRepairData.ActiveSheet.Cells[i, (int)STR_RPR_DAT.E1_QTY].Value = MPCF.MakeNumberFormat(out_list.GetInt("E1_QTY"), 0);
                    spdStringRepairData.ActiveSheet.Cells[i, (int)STR_RPR_DAT.E2_QTY].Value = MPCF.MakeNumberFormat(out_list.GetInt("E2_QTY"), 0);
                    spdStringRepairData.ActiveSheet.Cells[i, (int)STR_RPR_DAT.E3_QTY].Value = MPCF.MakeNumberFormat(out_list.GetInt("E3_QTY"), 0);

                    spdStringRepairData.ActiveSheet.Cells[i, (int)STR_RPR_DAT.TAKEN_TIME].Value = MPCF.MakeNumberFormat(out_list.GetInt("TAKEN_TIME"), 0);
                    spdStringRepairData.ActiveSheet.Cells[i, (int)STR_RPR_DAT.LOSS_WEIGHT].Value = MPCF.MakeNumberFormat(out_list.GetDouble("LOSS_WEIGHT"), 1);
              
                }
                spdStringRepairData.ActiveSheet.RowCount++;
                MPCF.FitColumnHeader(spdStringRepairData);
                
                return true;
            }
            
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        
        }

        private bool UpdateStringRepairData(char ProcStep)
        {
            try
            {
                int i;

                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_STR_REPAIR_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_STR_REPAIR_LIST_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);
                bool bTrySuccess = DateTime.TryParse(dtpDate2.Value.ToString(), out dtpScrapDateTimeOut);
                if (bTrySuccess == true)
                {
                    in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                }

                in_node.AddString("WORK_SHIFT", cdvShift2.Text);                
                in_node.AddString("OPERATOR_NAME", cdvWorker.Text);


                if (string.IsNullOrEmpty(txtE1Qty.Text))
                    txtE1Qty.Value = 0;
                if (string.IsNullOrEmpty(txtE2Qty.Text))
                    txtE2Qty.Value = 0;
                if (string.IsNullOrEmpty(txtE3Qty.Text))
                    txtE3Qty.Value = 0;
                if (string.IsNullOrEmpty(txtTimeTaken.Text))
                    txtTimeTaken.Value = 0;
                in_node.AddInt("E1_QTY", Convert.ToInt32(txtE1Qty.Value));
                in_node.AddInt("E2_QTY", Convert.ToInt32(txtE2Qty.Value));
                in_node.AddInt("E3_QTY", Convert.ToInt32(txtE3Qty.Value));
                in_node.AddInt("TAKEN_TIME", Convert.ToInt32(txtTimeTaken.Value));
                in_node.AddDouble("LOSS_WEIGHT", Convert.ToDouble(txtLossWeight.Value));
                in_node.AddString("CREATE_USER_ID", "ADMIN");

                if (ProcStep == 'I')        //create
                {

                }
                else if (ProcStep == 'A')  //append 
                {
                }

                else if (ProcStep == 'U')  //UPDATE
                {
                    in_node.AddString("UPDATE_USER_ID", "ADMIN");
                }
                else if (ProcStep == 'D')  //DELETE
                {

                }
                if (MPCF.CallService("CWIP", "CWIP_Update_String_Repair_Data", in_node, ref out_node) == false)
                {
                    if(out_node.MsgCode.Equals("CWIP-XXXX"))
                    {
                        MPCF.ShowMessage("Duplicated Operator Name", MSG_LEVEL.ERROR, false);
                    }
                    return false;
                }
                MPCF.ShowSuccessMessage(out_node, false);


                return true;
            }
            catch (Exception ex)
            {                
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        private bool UpdateHourRpt(char ProcStep)
        {
            try
            {
                int i;

                TRSNode work_list = null;

                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_HOUR_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_HOUR_LIST_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);

                // Scrap Date
                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpScrapDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                //header
                //in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                //in_node.AddString("HOUR_TYPE", MPCF.Trim(cdvType.Text));
                //in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShift.Text));
                //detail
                if (ProcStep == 'I')        //create
                {

                }
                else if (ProcStep == 'A')  //append 
                {
                }

                else if (ProcStep == 'U')  //UPDATE
                {

                }
                else if (ProcStep == 'D')  //DELETE
                {

                }
                if (MPCF.CallService("CRAS", "CRAS_Update_Hour_Gap", in_node, ref out_node) == false)
                {
                    MPCF.ShowSuccessMessage(out_node, false);
                    return false;
                }
                MPCF.ShowSuccessMessage(out_node, false);


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void cdvShift2_ValueChanged(object sender, EventArgs e)
        {
            if (!ignoreEvent)
                set_create();
        }

        private void dtpDate2_ValueChanged(object sender, EventArgs e)
        {
            if (!ignoreEvent)
                set_create();
        }

        private void cdvWorker_ValueChanged(object sender, EventArgs e)
        {
            if (!ignoreEvent)
                set_create();
        }

        private void txtTimeTaken_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)           //숫자 만 입력가능
            {
                MPCF.ShowMessage("Please enter a numerical value.", MSG_LEVEL.ERROR, false);

                txtTimeTaken.Clear();
                txtTimeTaken.Focus();
                e.Handled = true;
            }
            else   //append 
            {
                MPCF.ShowMessageClear();
            }

            if (txtTimeTaken.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }   
        }

        private void txtE1Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            MPCF.ShowMessageClear();

            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)           //숫자 만 입력가능
            {
                MPCF.ShowMessage("Please enter a numerical value.", MSG_LEVEL.ERROR, false);

                txtE1Qty.Clear();
                txtE1Qty.Focus();
                e.Handled = true;
            }
            else   //append 
            {
                MPCF.ShowMessageClear();
            }

            if (txtE1Qty.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
                      
        }

        private void txtE2Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            MPCF.ShowMessageClear();          

            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)           //숫자 만 입력가능
            {
                MPCF.ShowMessage("Please enter a numerical value.", MSG_LEVEL.ERROR, false);

                txtE2Qty.Clear();
                txtE2Qty.Focus();                               
                e.Handled = true;
            }
            else   //append 
            {
                MPCF.ShowMessageClear();
            }

            if (txtE2Qty.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
                       
        }

        private void txtE3Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            MPCF.ShowMessageClear();

            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)           //숫자 만 입력가능
            {
                MPCF.ShowMessage("Please enter a numerical value.", MSG_LEVEL.ERROR, false);
                
                txtE3Qty.Clear();
                txtE3Qty.Focus();
                e.Handled = true;
            }
            else   //append 
            {
                MPCF.ShowMessageClear();
            }

            if (txtE3Qty.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }

                       
        }

        private void cdvWorker_Enter(object sender, EventArgs e)
        {
            MPCF.ShowMessage("Please use the pop-up menu to select a name of operator.", MSG_LEVEL.ERROR, false);
            cdvWorker.Focus();
            return ;
        }

        private void cdvShift2_Enter(object sender, EventArgs e)
        {
            MPCF.ShowMessage("Please enter the relevant Work Shift data.", MSG_LEVEL.ERROR, false);
            cdvShift2.Focus();
            return;
        }
       
        private void txtE1Qty_MouseDown(object sender, MouseEventArgs e)
        {
            MPCF.ShowMessageClear();
        }

        private void txtE2Qty_MouseDown(object sender, MouseEventArgs e)
        {
            MPCF.ShowMessageClear();
        }

        private void txtE3Qty_MouseDown(object sender, MouseEventArgs e)
        {
            MPCF.ShowMessageClear();
        }

        private void txtTimeTaken_MouseDown(object sender, MouseEventArgs e)
        {
            MPCF.ShowMessageClear();
        }

        private void txtLossWeight_MouseDown(object sender, MouseEventArgs e)
        {
            MPCF.ShowMessageClear();
        }

       
       
                 
    }

}
