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
    public partial class frmCUSEndShift : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private bool mbLoadedFirstTime = true;
        #endregion

        #region Constructor

        public frmCUSEndShift()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]
        public string chk_type;
        public string chk_auto_validation;
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
            HOUR_DESC,
            //WORK_DATE,
            //LINE_ID,
            //HOUR_TYPE,
            EQ_MAX
        }

        public enum SPDSHIFT2_LIST
        {
            LINE_ID,
            RW,
            FRA,
            ETC,
            OK,
            NG,
            Repair
        }

        public enum SPDSHIFT_LIST
        {
        LINE_ID,
        PROCESS_TYPE,
        EFF_TIME,
        REMARK
        }



        #endregion

        #region [Variable Definition]
        
        #endregion

        #region Event Handler

        private void frmCUSEndShift_Load(object sender, EventArgs e)
        {
            // Init
            //dtpDate.Value = DateTime.Now.AddDays(-1) ;
            dtpDate.Value = DateTime.Now;

            MPCF.ConvertCaption(this);

            getLineLocationList();


            // Refresh
            btnView.PerformClick();
            mbLoadedFirstTime = false;
        }

        private void frmCUSEndShift_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpDate);

                bIsShown = true;
            }
        }
   
        private void btnToExcelModules_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveFileDialog pop = new SaveFileDialog();
                //pop.InitialDirectory = "C:\\";

                //pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpScrapList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                //pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                //pop.FilterIndex = 1;

                //if (pop.ShowDialog() == DialogResult.OK)
                //{
                //    spdHour.Sheets[0].Protect = false;
                //    spdHour.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                //    spdHour.Sheets[0].Protect = true;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


  
        


        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                clearData();

                if ( mbLoadedFirstTime  == false && CheckCondition("VIEW") == false)
                {
                    return;
                }

                if (ViewRemarkList() == false)
                {
                    return;
                }

                if (ViewShiftList() == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void clearData()
        {
            this.txtAdditionalComments.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
               
                //if (CheckCondition("UPDATE") == false)
                //{
                //    return;
                //}

                if (UpdateHourRpt(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }

                if (UpdateHourRpt2(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }


          

                // Refresh
                btnView.PerformClick();
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
 
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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
                    case "VIEW":

                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(594), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        if (MPCF.CheckValue(cboLineLocation, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(595), MSG_LEVEL.ERROR, false);
                            return false;
                        }                       

                        break;

                    case "UPDATE":

                        if (spdHour.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(568));
                            return false;
                        }



                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(594), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        
                        if (MPCF.CheckValue(cboLineLocation, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(595), MSG_LEVEL.ERROR, false);
                            return false;
                        } 

                        break;
                    case "APPEND":



                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(594), MSG_LEVEL.ERROR, false);
                            return false;
                        }

                        if (MPCF.CheckValue(cboLineLocation, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(595), MSG_LEVEL.ERROR, false);
                            return false;
                        } 
                        break;

                    case "DELETE":

                       
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

        private bool ViewRemarkList()
        {
            try
            {
                int i;

                FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();
             
                txt.MaxLength = 499;
             


     
                DateTime dtpFromDateTimeOut = new DateTime();

                MPCF.ClearList(spdremark);

                TRSNode in_node = new TRSNode("VIEW_SHIFT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_SHIFT_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                in_node.AddString("LINE_LOCATION", MPCF.Trim(cboLineLocation.Value));

                if (MPCF.CallService("CRAS", "CRAS_View_Crasdwntim_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdremark.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdremark.ActiveSheet.RowCount++;

                    spdremark.ActiveSheet.Cells[i, (int)SPDSHIFT_LIST.LINE_ID].Value = out_list.GetString("LINE_ID");
                    spdremark.ActiveSheet.Cells[i, (int)SPDSHIFT_LIST.PROCESS_TYPE].Value = out_list.GetString("PROCESS_TYPE");
                    spdremark.ActiveSheet.Cells[i, (int)SPDSHIFT_LIST.EFF_TIME].Value = MPCF.MakeNumberFormat(out_list.GetInt("EFF_TIME"), 0);
                    spdremark.ActiveSheet.Cells[i, (int)SPDSHIFT_LIST.REMARK].Value = out_list.GetString("REMARK");
                    spdremark.ActiveSheet.Cells[i, 3].CellType = txt;
                    spdremark.ActiveSheet.Cells[i, 3].BackColor = Color.White;
                    spdremark.ActiveSheet.Cells[i, 3].ForeColor = Color.Black;
                }


                //MPCF.FitColumnHeader(spdremark);


                spdremark.Sheets[0].Columns[0].Width = 100;
                spdremark.Sheets[0].Columns[1].Width = 200;
                spdremark.Sheets[0].Columns[2].Width = 130;
                spdremark.Sheets[0].Columns[3].Width = 500;
              




                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        private bool ViewShiftList()
        {
            try
            {
                int i;
                FarPoint.Win.Spread.CellType.NumberCellType num = new FarPoint.Win.Spread.CellType.NumberCellType();
                num.DecimalPlaces = 0;
                num.MaximumValue = 999999;
                num.MinimumValue = 0;


               

                DateTime dtpFromDateTimeOut = new DateTime();

                MPCF.ClearList(spdHour);

                TRSNode in_node = new TRSNode("VIEW_SHIFT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_SHIFT_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                in_node.AddString("LINE_LOCATION", MPCF.Trim(cboLineLocation.Value));


                if (MPCF.CallService("CRAS", "CRAS_View_Crasdshift_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdHour.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdHour.ActiveSheet.RowCount++;

                    spdHour.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LINE_ID].Value = out_list.GetString("LINE_ID");
                    spdHour.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.RW].Value = out_list.GetInt("RW");
                    spdHour.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.FRA].Value = out_list.GetInt("FRA");
                    spdHour.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.ETC].Value = out_list.GetInt("ETC");
                    spdHour.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.OK].Value = out_list.GetInt("OK");
                    spdHour.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.NG].Value = out_list.GetInt("NG");
                    if (out_list.GetString("CMF_1").Length <= 0)
                    {
                        spdHour.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.Repair].Value = "0";
                    }
                    else
                    {
                        spdHour.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.Repair].Value = out_list.GetString("CMF_1");
                    }
                    spdHour.ActiveSheet.Cells[i, 1].CellType = num;
                    spdHour.ActiveSheet.Cells[i, 2].CellType = num;
                    spdHour.ActiveSheet.Cells[i, 3].CellType = num;
                    spdHour.ActiveSheet.Cells[i, 4].CellType = num;
                    spdHour.ActiveSheet.Cells[i, 5].CellType = num;
                    spdHour.ActiveSheet.Cells[i, 6].CellType = num;

                    spdHour.ActiveSheet.Cells[i, 1].BackColor = Color.White;
                    spdHour.ActiveSheet.Cells[i, 1].ForeColor = Color.Black;
                    spdHour.ActiveSheet.Cells[i, 2].BackColor = Color.White;
                    spdHour.ActiveSheet.Cells[i, 2].ForeColor = Color.Black;
                    spdHour.ActiveSheet.Cells[i, 3].BackColor = Color.White;
                    spdHour.ActiveSheet.Cells[i, 3].ForeColor = Color.Black;
                    spdHour.ActiveSheet.Cells[i, 4].BackColor = Color.White;
                    spdHour.ActiveSheet.Cells[i, 4].ForeColor = Color.Black;
                    spdHour.ActiveSheet.Cells[i, 5].BackColor = Color.White;
                    spdHour.ActiveSheet.Cells[i, 5].ForeColor = Color.Black;
                    spdHour.ActiveSheet.Cells[i, 6].BackColor = Color.White;
                    spdHour.ActiveSheet.Cells[i, 6].ForeColor = Color.Black;


   
                }

                //MPCF.FitColumnHeader(spdremark);


                spdHour.Sheets[0].Columns[0].Width = 100;
                spdHour.Sheets[0].Columns[1].Width = 100;
                spdHour.Sheets[0].Columns[2].Width = 100;
                spdHour.Sheets[0].Columns[3].Width = 100;
                spdHour.Sheets[0].Columns[4].Width = 100;
                spdHour.Sheets[0].Columns[5].Width = 100;
                spdHour.Sheets[0].Columns[6].Width = 100;
                
                this.txtAdditionalComments.Text = out_node.GetString("SHIFT_COMMENT");              
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

                TRSNode in_node = new TRSNode("UPDATE_SHIFT_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_SHIFT_LIST_OUT");

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
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                in_node.AddString("LINE_LOCATION", MPCF.Trim(cboLineLocation.Value));

                for (i = 0; i < spdHour.Sheets[0].Rows.Count; i++)
                {
                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("LINE_ID", spdHour.ActiveSheet.Cells[i, 0].Value);
                    work_list.AddInt("RW", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, 1].Text.Replace(",", "")));
                    work_list.AddInt("FRA", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, 2].Text.Replace(",", "")));
                    work_list.AddInt("ETC", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, 3].Text.Replace(",", "")));
                    work_list.AddInt("OK", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, 4].Text.Replace(",", "")));
                    work_list.AddInt("NG", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, 5].Text.Replace(",", "")));
                    work_list.AddInt("Repair", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, 6].Text.Replace(",", "")));

                    }
                in_node.AddString("SHIFT_COMMENT", MPCF.Trim(txtAdditionalComments.Text));

                if (MPCF.CallService("CRAS", "CRAS_Update_Crasdshift", in_node, ref out_node) == false)
                {
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


        private bool UpdateHourRpt2(char ProcStep)
        {
            try
            {
                int i;

                TRSNode work_list = null;

                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_TIME_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_TIME_LIST_OUT");

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
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                in_node.AddString("LINE_LOCATION", MPCF.Trim(cboLineLocation.Value));

                for (i = 0; i < spdremark.Sheets[0].Rows.Count; i++)
                {
                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("LINE_ID", spdremark.ActiveSheet.Cells[i, 0].Value);
                    work_list.AddString("PROCESS_TYPE", spdremark.ActiveSheet.Cells[i, 1].Value);
                    work_list.AddInt("EFF_TIME", spdremark.ActiveSheet.Cells[i, 2].Text.Replace(",",""));
                    work_list.AddString("REMARK", spdremark.ActiveSheet.Cells[i, 3].Value);

                }

                if (MPCF.CallService("CRAS", "CRAS_Update_Crasdwntim", in_node, ref out_node) == false)
                {
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

        private bool getLineLocationList()
        {
            try
            {
                // Init
                //LINE 가져오기.

                // Init
                //GET LINE 
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_LOCATION));

                int i;
                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboLineLocation.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    }
                }      
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }
        private bool getShiftList()
        {
            try
            {
                cboShift.Items.Clear();
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (dtpDate.Value != null)
                {
                    in_node.AddString("SYS_DATE", ((DateTime)(dtpDate.Value)).ToString("yyyyMMdd"));
                }

                int i;
                if (MPCF.CallService("CBAS", "CBAS_View_Shift_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboShift.Items.Add(out_list.GetString("shift"), out_list.GetString("SHIFT"));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }
        #endregion



      

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.spdHour_Sheet1.RowCount > 0)
                {
                    MPCF.ClearList(spdHour);
                }
                if (this.spdremark_Sheet1.RowCount > 0)
                {
                    MPCF.ClearList(spdremark);
                }
                getShiftList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
                

        private void cboShift_Load(object sender, EventArgs e)
        {

        }


        private void cboLineLocation_SelectionChanged(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            if (ViewRemarkList() == false)
            {
                return;
            }

            if (ViewShiftList() == false)
            {
                return;
            }
        }

        private void cboShift_SelectionChanged(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            if (ViewRemarkList() == false)
            {
                return;
            }

            if (ViewShiftList() == false)
            {
                return;
            }
        }
    }
}
