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
    public partial class frmCUSXLinkTestReport : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSXLinkTestReport()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]
        public string chk_type;
        public string chk_auto_validation;
        public string chk_auto;
       

        public enum SPDSHIFT2_LIST
        {
            LINE_ID,
            LAMI_NUMER,
            LAMI_POS,
            WORK_DATE,
            TEST_DATE,
            LX11            ,
            LX12            ,
            LX21            ,
            LX22            ,
            LX31            ,
            LX32            ,
            LX41            ,
            LX42            ,
            LX51            ,
            LX52            ,
            LXTAT1          ,
            //LXTAT2          ,
            DX11            ,
            DX12            ,
            DX21            ,
            DX22            ,
            DX31            ,
            DX32            ,
            DX41            ,
            DX42            ,
            DX51            ,
            DX52            ,
            DXTAT1          ,
            //DXTAT2          ,
            //CREATE_USER_ID  ,
            //TRAN_TIME       ,
            //UPDATE_USER_ID  ,
            //UPDATE_TIME     
        }

       
        


        #endregion

        #region [Variable Definition]
        
        #endregion

        #region Event Handler

        private void frmCUSXLinkTestReport_Load(object sender, EventArgs e)
        {
            // Init
            //dtpDate.Value = FATETime.Now.AddDays(-1) ;
            dtpDate.Value = DateTime.Now;

            MPCF.ConvertCaption(this);

          //  getLineLocationList();


            // Refresh
            //btnView.PerformClick();

            SetSheetUI();
        }

        private void frmCUSXLinkTestReport_Shown(object sender, EventArgs e)
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
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }

                

                if (ViewXLinkTestList() == false)
                {
                    return;
                }

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
               
                //if (CheckCondition("UPDATE") == false)
                //{
                //    return;
                //}

                if (UpdateXlink(MPGC.MP_STEP_UPDATE) == false)
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

                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(594), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                       
                        break;

                    case "UPDATE":

                        if (spdXLinkTest.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(568));
                            return false;
                        }



                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(594), MSG_LEVEL.ERROR, false);
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

       


        private bool ViewXLinkTestList()
        {
            try
            {
                int i;
                FarPoint.Win.Spread.CellType.NumberCellType num = new FarPoint.Win.Spread.CellType.NumberCellType();
                FarPoint.Win.Spread.CellType.DateTimeCellType cDate = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                FarPoint.Win.Spread.CellType.TextCellType text = new FarPoint.Win.Spread.CellType.TextCellType();
                FarPoint.Win.Spread.CellType.GeneralCellType generalCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
                num.DecimalPlaces = 2;
                num.MaximumValue = 9999;
                num.MinimumValue = 0;


                cDate.DropDownButton = false;
                cDate.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                cDate.UserDefinedFormat = "yyyy/MM/dd";

                DateTime dtpFromDateTimeOut = new DateTime();

                MPCF.ClearList(spdXLinkTest);

                TRSNode in_node = new TRSNode("CRASXLINKR_LIST_IN");
                TRSNode out_node = new TRSNode("CRASXLINKR_LIST_OUT");
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

                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));


                if (MPCF.CallService("CRAS", "CRAS_View_Xlinktest_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdXLinkTest.ActiveSheet.RowCount = 0;

                spdXLinkTest.Sheets[0].Columns[3].CellType = cDate;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdXLinkTest.ActiveSheet.RowCount++;

                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LINE_ID].Value = out_list.GetString("LINE_ID");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LAMI_NUMER].Value = out_list.GetString("LAMI_NUMER");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LAMI_POS].Value = out_list.GetString("LAMI_POS");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.WORK_DATE].Value = out_list.GetString("WORK_DATE");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.TEST_DATE].Value = out_list.GetString("TEST_DATE");
                    

                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX11].Value = out_list.GetFloat("LX11");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX12].Value = out_list.GetFloat("LX12");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX21].Value = out_list.GetFloat("LX21");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX22].Value = out_list.GetFloat("LX22");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX31].Value = out_list.GetFloat("LX31");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX32].Value = out_list.GetFloat("LX32");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX41].Value = out_list.GetFloat("LX41");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX42].Value = out_list.GetFloat("LX42");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX51].Value = out_list.GetFloat("LX51");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LX52].Value = out_list.GetFloat("LX52");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LXTAT1].Value = out_list.GetFloat("LXTAT1");
                    //spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.LXTAT2].Value = out_list.GetFloat("LXTAT2");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX11].Value = out_list.GetFloat("DX11");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX12].Value = out_list.GetFloat("DX12");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX21].Value = out_list.GetFloat("DX21");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX22].Value = out_list.GetFloat("DX22");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX31].Value = out_list.GetFloat("DX31");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX32].Value = out_list.GetFloat("DX32");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX41].Value = out_list.GetFloat("DX41");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX42].Value = out_list.GetFloat("DX42");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX51].Value = out_list.GetFloat("DX51");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DX52].Value = out_list.GetFloat("DX52");
                    spdXLinkTest.ActiveSheet.Cells[i, (int)SPDSHIFT2_LIST.DXTAT1].Value = out_list.GetFloat("DXTAT1");


                    spdXLinkTest.ActiveSheet.Cells[i, 3].CellType = generalCellType;
                    spdXLinkTest.ActiveSheet.Cells[i, 4].CellType = generalCellType;
                    
                    spdXLinkTest.ActiveSheet.Cells[i, 5].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 6].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 7].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 8].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 9].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 10].CellType = num;

                    spdXLinkTest.ActiveSheet.Cells[i, 11].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 12].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 13].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 14].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 15].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 16].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 17].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 18].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 19].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 20].CellType = num;

                    spdXLinkTest.ActiveSheet.Cells[i, 21].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 22].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 23].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 24].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 25].CellType = num;
                    spdXLinkTest.ActiveSheet.Cells[i, 26].CellType = num;

                    
                    spdXLinkTest.ActiveSheet.Cells[i, 4].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 4].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 5].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 5].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 6].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 6].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 7].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 7].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 8].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 8].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 9].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 9].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 10].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 10].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 11].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 11].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 12].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 12].ForeColor = Color.Black;
                    
                    
                    spdXLinkTest.ActiveSheet.Cells[i, 13].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 13].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 14].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 14].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 15].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 15].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 16].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 16].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 17].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 17].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 18].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 18].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 19].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 19].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 20].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 20].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 21].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 21].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 22].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 22].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 23].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 23].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 24].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 24].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 25].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 25].ForeColor = Color.Black;
                    spdXLinkTest.ActiveSheet.Cells[i, 26].BackColor = Color.White;
                    spdXLinkTest.ActiveSheet.Cells[i, 26].ForeColor = Color.Black;
                }

                spdXLinkTest.ActiveSheet.AddSpanCell(0, 0, 16, 1);
                spdXLinkTest.ActiveSheet.AddSpanCell(0, 3, 16, 1);
                spdXLinkTest.ActiveSheet.AddSpanCell(0, 4, 16, 1);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

   
        private bool UpdateXlink(char ProcStep)
        {
            try
            {
                int i;
    
                TRSNode work_list = null;

                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_XLINK_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_XLINK_LIST_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FACTORY", "USGAM1");

                // Scrap Date
                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpScrapDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                //
                in_node.AddString("CREATE_USER_ID", MPCF.Trim(MPGV.gsUserID));

                //header
                
                for (i = 0; i < spdXLinkTest.Sheets[0].Rows.Count; i++)
                {
                    work_list = in_node.AddNode("TRAN_LIST");
                    //Header of Report
                    //Replace(",", "")

                    work_list.AddString("LINE_ID", spdXLinkTest.ActiveSheet.Cells[i, 0].Value);
                    work_list.AddString("LAMI_NUMER", spdXLinkTest.ActiveSheet.Cells[i, 1].Value);
                    work_list.AddString("LAMI_POS", spdXLinkTest.ActiveSheet.Cells[i, 2].Value);
                    
                    //work_list.AddString("WORK_DATE", spdXLinkTest.ActiveSheet.Cells[i, 3].Value);
                    //work_list.AddString("TEST_DATE", spdXLinkTest.ActiveSheet.Cells[i, 4].Value);
                    //셀 머지로 인해 첫번째 데이터를 이용하여 update
                    work_list.AddString("WORK_DATE", spdXLinkTest.ActiveSheet.Cells[0, 3].Value);
                    work_list.AddString("TEST_DATE", spdXLinkTest.ActiveSheet.Cells[0, 4].Value);

                    //Middle  of Report
                    work_list.AddFloat("LX11", spdXLinkTest.ActiveSheet.Cells[i, 5].Value);
                    work_list.AddFloat("LX12", spdXLinkTest.ActiveSheet.Cells[i, 6].Text);
                    work_list.AddFloat("LX21", spdXLinkTest.ActiveSheet.Cells[i, 7].Text);
                    work_list.AddFloat("LX22", spdXLinkTest.ActiveSheet.Cells[i, 8].Text);
                    work_list.AddFloat("LX31", spdXLinkTest.ActiveSheet.Cells[i, 9].Text);
                    work_list.AddFloat("LX32", spdXLinkTest.ActiveSheet.Cells[i, 10].Text);
                    work_list.AddFloat("LX41", spdXLinkTest.ActiveSheet.Cells[i, 11].Text);
                    work_list.AddFloat("LX42", spdXLinkTest.ActiveSheet.Cells[i, 12].Text);
                    work_list.AddFloat("LX51", spdXLinkTest.ActiveSheet.Cells[i, 13].Text);
                    work_list.AddFloat("LX52", spdXLinkTest.ActiveSheet.Cells[i, 14].Text);
                    work_list.AddFloat("LXTAT1", spdXLinkTest.ActiveSheet.Cells[i, 15].Text);
                    work_list.AddFloat("DX11", spdXLinkTest.ActiveSheet.Cells[i, 16].Text);
                    work_list.AddFloat("DX12", spdXLinkTest.ActiveSheet.Cells[i, 17].Text);
                    work_list.AddFloat("DX21", spdXLinkTest.ActiveSheet.Cells[i, 18].Text);
                    work_list.AddFloat("DX22", spdXLinkTest.ActiveSheet.Cells[i, 19].Text);
                    work_list.AddFloat("DX31", spdXLinkTest.ActiveSheet.Cells[i, 20].Text);
                    work_list.AddFloat("DX32", spdXLinkTest.ActiveSheet.Cells[i, 21].Text);
                    work_list.AddFloat("DX41", spdXLinkTest.ActiveSheet.Cells[i, 22].Text);
                    work_list.AddFloat("DX42", spdXLinkTest.ActiveSheet.Cells[i, 23].Text);
                    work_list.AddFloat("DX51", spdXLinkTest.ActiveSheet.Cells[i, 24].Text);
                    work_list.AddFloat("DX52", spdXLinkTest.ActiveSheet.Cells[i, 25].Text);
                    work_list.AddFloat("DXTAT1", spdXLinkTest.ActiveSheet.Cells[i, 26].Text);
                    //END of Report
                    /*
                    work_list.AddInt("RW", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 1].Text.Replace(",", "")));
                    work_list.AddInt("FRA", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 2].Text.Replace(",", "")));
                    work_list.AddInt("ETC", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 3].Text.Replace(",", "")));
                    work_list.AddInt("OK", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 4].Text.Replace(",", "")));
                    work_list.AddInt("NG", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 5].Text.Replace(",", "")));
                    work_list.AddInt("Repair", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 6].Text.Replace(",", "")));
                    work_list.AddInt("TABBERS", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 7].Text.Replace(",", "")));
                    work_list.AddInt("AMR_CART", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 8].Text.Replace(",", "")));
                    work_list.AddInt("STRING_REPAIR", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 9].Text.Replace(",", "")));
                    work_list.AddInt("MODULE_REPAIR", Convert.ToInt32(spdXLinkTest.ActiveSheet.Cells[i, 10].Text.Replace(",", "")));
                     * */
                    }

                if (MPCF.CallService("CRAS", "CRAS_Update_Xlinktest", in_node, ref out_node) == false)
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
                if (this.spdXLinkTest_Sheet1.RowCount > 0)
                {
                    MPCF.ClearList(spdXLinkTest);
                }
                
                //getShiftList();
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
            

            if (ViewXLinkTestList() == false)
            {
                return;
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
            in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

            string[] header = new string[] { "Line Code", "Description" };
            string[] display = new string[] { "KEY_1", "DATA_1" };

            cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

            /*
            TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));

            string[] header = new string[] { "Line Code", "Description" };
            string[] display = new string[] { "KEY_1", "DATA_1" };

            cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            */
        }


        private void cboShift_SelectionChanged(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            

            if (ViewXLinkTestList() == false)
            {
                return;
            }
        }


        public void SetSheetUI()
        {
            spdXLinkTest.Sheets[0].Columns[0].Width = 100;
            spdXLinkTest.Sheets[0].Columns[1].Width = 50;
            spdXLinkTest.Sheets[0].Columns[2].Width = 50;
            spdXLinkTest.Sheets[0].Columns[3].Width = 100;
            spdXLinkTest.Sheets[0].Columns[4].Width = 100;
            spdXLinkTest.Sheets[0].Columns[5].Width = 60;
            spdXLinkTest.Sheets[0].Columns[6].Width = 60;
            spdXLinkTest.Sheets[0].Columns[7].Width = 60;
            spdXLinkTest.Sheets[0].Columns[8].Width = 60;
            spdXLinkTest.Sheets[0].Columns[9].Width = 60;
            spdXLinkTest.Sheets[0].Columns[10].Width = 60;
            spdXLinkTest.Sheets[0].Columns[11].Width = 60;
            spdXLinkTest.Sheets[0].Columns[12].Width = 60;
            spdXLinkTest.Sheets[0].Columns[13].Width = 60;
            spdXLinkTest.Sheets[0].Columns[14].Width = 60;
            spdXLinkTest.Sheets[0].Columns[15].Width = 70;
            spdXLinkTest.Sheets[0].Columns[16].Width = 60;
            spdXLinkTest.Sheets[0].Columns[17].Width = 60;
            spdXLinkTest.Sheets[0].Columns[18].Width = 60;
            spdXLinkTest.Sheets[0].Columns[19].Width = 60;
            spdXLinkTest.Sheets[0].Columns[20].Width = 60;
            spdXLinkTest.Sheets[0].Columns[21].Width = 60;
            spdXLinkTest.Sheets[0].Columns[22].Width = 60;
            spdXLinkTest.Sheets[0].Columns[23].Width = 60;
            spdXLinkTest.Sheets[0].Columns[24].Width = 60;
            spdXLinkTest.Sheets[0].Columns[25].Width = 60;
            spdXLinkTest.Sheets[0].Columns[26].Width = 70;

        }

    }


}


