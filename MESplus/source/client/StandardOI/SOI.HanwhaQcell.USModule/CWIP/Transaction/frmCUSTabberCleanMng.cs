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
    public partial class frmCUSTabberCleanMng : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private Color m_clrSelectedCellBackground;

        #endregion

        #region Constructor

        public frmCUSTabberCleanMng()
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
            //HIST_SEQ,
            //TARGET_QTY,
            //FEL_QTY,
            //DIFF_QTY,
            //TIME_LOSS,
            //TYPE_4M,
            //PROCESS_TYPE,
            //EQ,
            //DOWN_TIME,
            //EFF_TIME,
            ////HOUR_DESC,
            //HOUR_DESC,
            //EQ_MAX,
            //CMF_1
            //WORK_DATE,
            //LINE_ID,
            //HOUR_TYPE,

        }

        #endregion

        #region [Variable Definition]
        
        #endregion

        #region Event Handler

       

        private void frmCUSTabberCleanMng_Load(object sender, EventArgs e)
        {
            // Init
            //dtpDate.Value = DateTime.Now.AddDays(-1) ;
            dtpDate.Value = DateTime.Now;
         
            chk_auto_validation = "";
            chk_auto = "";


            set_view();
            
            comboxHoulyType.Items.Add("TYPE", "AM");
            comboxHoulyType.Items.Add("TYPE", "PM");
            comboxHoulyType.SelectedIndex = 0;

           
            MPCF.ConvertCaption(this);
        }

        private void frmCUSTabberCleanMng_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpDate);

                bIsShown = true;
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
              


        private void cdbtabber_CodeViewButtonClick(object sender, EventArgs e)
        {
            //view클릭시 모든 태버를 가져오므로 선택이 필요없어서 비활성화(2025/06/19)
            try
            {
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("TABLE_NAME", "@E10_EQP");
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

                string[] header = new string[] { "Cause Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };
                //cdbtabber.Text = cdbtabber.Show(cdbtabber, "Resource ID", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }




        private void btnToExcelModules_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        private void set_houlytype()
        {

            //comboxHoulyType.Items.Add("TYPE", "AM");
            //comboxHoulyType.Items.Add("TYPE", "PM");
            //comboxHoulyType.SelectedIndex = 0;

            //comboxHoulyType.Items.Clear();
            //comboxHoulyType.ResetText(); 
            //if (lblworkdate.Text == "")
            //{
            //    return;
            //}


            //int i = 0;
            //TRSNode in_node = new TRSNode("SQL_IN");
            //TRSNode out_node = new TRSNode("SQL_OUT");
            //List<TRSNode> row_list;
            //List<TRSNode> col_list;
            //StringBuilder sb;

            ////DataTable dt_temp = gridInLotList.GetDataSource();
            ////dt_temp.Clear();

           

            //in_node.AddString("SQL", sb.ToString());
            //if (MPCF.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            //{
            //    return;
            //}
         

            //in_node.AddString("SQL", sb.ToString());
            //row_list = out_node.GetList("ROWS");
            //foreach (TRSNode cols in row_list)
            //{
            //    col_list = cols.GetList("COLS");
            //    comboxHoulyType.Items.Add("TYPE", col_list[i].GetString("DATA"));
            //    i = i + 1;
            //    //comboxHoulyType.ca
            //    // 1) Get data Source 
            //    //DataTable dt = gridInLotList.GetDataSource();
            //    //// 2) New Row
            //    //DataRow dr = dt.NewRow();

            //    //// 3) Data Insert

            //    //dr["IN_TIME"] = MPCF.MakeDateFormat(col_list[0].GetString("DATA"));
            //    //dr["LOT_ID"] = col_list[1].GetString("DATA");
            //    //dr["QTY_1"] = MPCF.ToDbl(col_list[2].GetString("DATA"));

            //    //// 4) New Row Add
            //    //dt.Rows.Add(dr);

            //}
            //if (comboxHoulyType.Items.Count > 0)
            //{
            //    comboxHoulyType.SelectedIndex = 0;
            //}

        }

        private void set_view()
        {
            txt_clear();
         
        }

       

        private void txt_clear()
        {
            lblworkdate.Text = "";
            lblTabber.Text = "";
            lblcol.Text = "";
            comboxHoulyType.SelectedIndex = 0;
            txtHour.Value = null;
            txtMin.Value = null;            
            lblupdate_flag.Text = "";
        }

        private void txt_clear2()
        {
            lblworkdate.Text = "";
            lblTabber.Text = "";
            lblcol.Text = "";
            comboxHoulyType.SelectedIndex = 0;
            txtHour.Value = null;
            txtMin.Value = null;
        }


        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_clear();
    
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if  (CheckCondition("VIEW") == false)
                {
                    set_view();
                   return;
                }

                //#2.헤더 조정
                if (ViewPlanList() == false)        
                {
                    set_view();
                    return;
                }

                //#3.데이터 조회
                if (ViewList() == false)
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
                if (lblupdate_flag.Text == "Y")
                {
                    if (CheckCondition("UPDATE") == false)
                    {
                        return;
                    }

                    if (UpdateHourRpt(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
                }
                else if (lblupdate_flag.Text == "N")
                {
                    if (CheckCondition("CREATE") == false)
                    {
                        return;
                    }

                    if (UpdateHourRpt(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                }
                else
                {
                    MPCF.ShowMsgBox("Please process View at first.");
                    return;
                }




                // Refresh
                txt_clear();
                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (spdHour.ActiveSheet.ActiveCell.Text.Trim().Length == 0)
            {
                return;
            }

            spdHour.ActiveSheet.ActiveCell.Text = " ";

            if (UpdateHourRpt(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
            txtHour.Value = " ";
            txtMin.Value = " ";
        }


        private void spdHour_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                String StrVal;

                txt_clear2();

                if (e.Column > 0)
                {
                    lblworkdate.Text = this.spdHour_Sheet1.ColumnHeader.Cells.Get(1, e.Column).Text;
                    lblcol.Text = e.Column.ToString();
                }
                else
                {
                    lblworkdate.Text = "";
                    lblcol.Text = ""; 

                }

                lblTabber.Text = spdHour.Sheets[0].Cells[e.Row,0].Text;
                if (spdHour.ActiveSheet.Cells[e.Row, e.Column].Value == null)
                {
                    Checkcom.Checked = false;
                    txtHour.Value = null;
                    txtMin.Value = null;

                    return;
                }

                StrVal = spdHour.ActiveSheet.Cells[e.Row, e.Column].Value.ToString();
                StrVal = StrVal.Replace(":", "");
                StrVal = StrVal.Replace(" ", "");
                StrVal = MPCF.Trim(StrVal);


                if (StrVal.Length == 6)
                {
                    if (StrVal.Substring(4, 2) == "AM")
                    {
                        comboxHoulyType.SelectedIndex = 0;
                    }
                    else if (StrVal.Substring(4, 2) == "PM")
                    {
                        comboxHoulyType.SelectedIndex = 1;
                    }

                    txtHour.Value = StrVal.Substring(0, 2);
                    txtMin.Value = StrVal.Substring(2, 2);

                }
                if (spdHour.ActiveSheet.Cells[e.Row, e.Column].BackColor == System.Drawing.Color.Green)
                {
                    Checkcom.Checked = true;
                }
                else
                {
                    Checkcom.Checked = false;
                } 
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
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

                       if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                      


                        break;

                    case "VIEW":
                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                       

                        break;

                    case "UPDATE":

                      

                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }


                        if (MPCF.CheckValue(lblTabber, false) == false)
                        {
                            return false;
                        }



                        if (MPCF.CheckValue(comboxHoulyType, false) == false)
                        {
                            return false;
                        }

                        if (lblcol.Text == "")
                        {
                            MPCF.ShowMsgBox("Please Selecte Plan Date");
      
                            return false;
                        }

                        if (txtHour.Value ==null || 
                            txtHour.Value.ToString() == "0" || 
                            txtHour.Value.ToString() == "" || 
                            txtHour.Value.ToString() == " ")
                        {
                            MPCF.ShowMsgBox("Please enter a numerical value in Hour field.");
                            txtHour.Focus();
                            return false;
                        }

                        if (txtMin.Value ==null ||
                            txtMin.Value.ToString() == "" || 
                            txtMin.Value.ToString() == " ")
                        {
                            MPCF.ShowMsgBox("Please enter a numerical value in Minutes field.");
                            txtMin.Focus();
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


        private bool ViewPlanList()
        {
            try
            {
                int i;
               


                chk_type = "";

                DateTime dtpFromDateTimeOut = new DateTime();

                MPCF.ClearList(spdHour);

                TRSNode in_node = new TRSNode("VIEW_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '2';

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                in_node.AddString("FACTORY", "USGAM1");

                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("WORK_SHIFT", " ");

                in_node.ProcStep = '2';  //날짜 조회
                if (MPCF.CallService("CRAS", "CRAS_View_TABBER_CLEAN_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);


                out_list = out_node.GetList(0)[0];

                this.spdHour_Sheet1.Columns.Get(1).Visible = false;
                this.spdHour_Sheet1.Columns.Get(2).Visible = false;
                this.spdHour_Sheet1.Columns.Get(3).Visible = false;
                this.spdHour_Sheet1.Columns.Get(4).Visible = false;
                this.spdHour_Sheet1.Columns.Get(5).Visible = false;
                this.spdHour_Sheet1.Columns.Get(6).Visible = false;
                this.spdHour_Sheet1.Columns.Get(7).Visible = false;


  

             

                DateTime date_1 = new DateTime(Convert.ToInt32(out_list.GetString("PLAN_MIN_DATE").Substring(0, 4)), Convert.ToInt32(out_list.GetString("PLAN_MIN_DATE").Substring(4, 2)), Convert.ToInt32(out_list.GetString("PLAN_MIN_DATE").Substring(6, 2)));
                DateTime date_2 = new DateTime(Convert.ToInt32(out_list.GetString("PLAN_MAX_DATE").Substring(0, 4)), Convert.ToInt32(out_list.GetString("PLAN_MAX_DATE").Substring(4, 2)), Convert.ToInt32(out_list.GetString("PLAN_MAX_DATE").Substring(6, 2)));
                
                i = 1;

                while (date_1 <= date_2)
                {
                    this.spdHour_Sheet1.Columns.Get(i).Visible = true;
                    this.spdHour_Sheet1.ColumnHeader.Cells.Get(1, i).Value = date_1.ToString("yyyy-MM-dd");
                    date_1 = date_1.AddDays(1);
                    i = i + 1;
                }
                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        private bool ViewList()
        {
            try
            {
                int i;
                         

                chk_type = "";
                lblupdate_flag.Text = "";

                DateTime dtpFromDateTimeOut = new DateTime();
              
                MPCF.ClearList(spdHour);

                TRSNode in_node = new TRSNode("VIEW_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                
                in_node.AddString("FACTORY","USGAM1");

                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("WORK_SHIFT", " ");

                in_node.ProcStep = '1';  //데이터 조회
                if (MPCF.CallService("CRAS", "CRAS_View_TABBER_CLEAN_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdHour.ActiveSheet.RowCount = 0;

                if (out_node.GetList(0).Count == 0)
                {
                    lblupdate_flag.Text = "N";
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdHour.ActiveSheet.RowCount++;
                    if (lblupdate_flag.Text == "")
                    {
                        lblupdate_flag.Text = out_list.GetString("UPDATE_FLAG");
                    }
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.WORK_SHIFT].Value = out_list.GetString("WORK_SHIFT");

                    spdHour.ActiveSheet.Cells[i, 0].Value = out_list.GetString("RES_ID");

                    if (out_list.GetString("CLEAN1_PLAN_TIME").Length == 4)
                    {
                        if (Convert.ToInt32(out_list.GetString("CLEAN1_PLAN_TIME").Substring(0, 2)) >= 12)  //12 시보다 크면 PM
                        {
                            if (out_list.GetString("CLEAN1_PLAN_TIME").Substring(0, 2) == "12")
                            {
                                spdHour.ActiveSheet.Cells[i, 1].Value = out_list.GetString("CLEAN1_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN1_PLAN_TIME").Substring(2, 2) + " PM";
                            }
                            else
                            {
                                if((Convert.ToInt32(out_list.GetString("CLEAN1_PLAN_TIME").Substring(0, 2)) - 12).ToString().Length == 1)
                                {
                                    spdHour.ActiveSheet.Cells[i, 1].Value = "0" + (Convert.ToInt32(out_list.GetString("CLEAN1_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN1_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                                else
                                {
                                    spdHour.ActiveSheet.Cells[i, 1].Value = (Convert.ToInt32(out_list.GetString("CLEAN1_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN1_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                            }
                        }
                        else
                        {
                            if (out_list.GetString("CLEAN1_PLAN_TIME").Substring(0, 2) == "00")
                            {
                                spdHour.ActiveSheet.Cells[i, 1].Value = "12:" + out_list.GetString("CLEAN1_PLAN_TIME").Substring(2, 2) + " AM" ;
                            }
                            else
                            {

                                spdHour.ActiveSheet.Cells[i, 1].Value = out_list.GetString("CLEAN1_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN1_PLAN_TIME").Substring(2, 2) + " AM";                            
                            }
                         }
                      }
                    if (out_list.GetChar("CLEAN1_FLAG") == 'Y')
                    {
                        spdHour.ActiveSheet.Cells[i, 1].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        spdHour.ActiveSheet.Cells[i, 1].BackColor = System.Drawing.Color.Empty;
                    }


                    if (out_list.GetString("CLEAN2_PLAN_TIME").Length == 4)
                    {
                        if (Convert.ToInt32(out_list.GetString("CLEAN2_PLAN_TIME").Substring(0, 2)) >= 12)  //12 시보다 크면 PM
                        {
                            if (out_list.GetString("CLEAN2_PLAN_TIME").Substring(0, 2) == "12")
                            {
                                spdHour.ActiveSheet.Cells[i, 2].Value = out_list.GetString("CLEAN2_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN2_PLAN_TIME").Substring(2, 2) + " PM" ;
                            }
                            else
                            {
                                if ((Convert.ToInt32(out_list.GetString("CLEAN2_PLAN_TIME").Substring(0, 2)) - 12).ToString().Length == 1)
                                {
                                    spdHour.ActiveSheet.Cells[i, 2].Value = "0" + (Convert.ToInt32(out_list.GetString("CLEAN2_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN2_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                                else
                                {
                                    spdHour.ActiveSheet.Cells[i, 2].Value = (Convert.ToInt32(out_list.GetString("CLEAN2_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN2_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                            }
                        }
                        else
                        {
                            if (out_list.GetString("CLEAN2_PLAN_TIME").Substring(0, 2) == "00")
                            {
                                spdHour.ActiveSheet.Cells[i, 2].Value =  "12:" + out_list.GetString("CLEAN2_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                            else
                            {
                                spdHour.ActiveSheet.Cells[i, 2].Value = out_list.GetString("CLEAN2_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN2_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                        }
                    }

                    if (out_list.GetChar("CLEAN2_FLAG") == 'Y')
                    {
                        spdHour.ActiveSheet.Cells[i, 2].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        spdHour.ActiveSheet.Cells[i, 2].BackColor = System.Drawing.Color.Empty;
                    }

                    if (out_list.GetString("CLEAN3_PLAN_TIME").Length == 4)
                    {
                        if (Convert.ToInt32(out_list.GetString("CLEAN3_PLAN_TIME").Substring(0, 2)) >= 12)  //12 시보다 크면 PM
                        {
                            if (out_list.GetString("CLEAN3_PLAN_TIME").Substring(0, 2) == "12")
                            {
                                spdHour.ActiveSheet.Cells[i, 3].Value = out_list.GetString("CLEAN3_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN3_PLAN_TIME").Substring(2, 2) +  " PM";
                            }
                            else
                            {
                                if ((Convert.ToInt32(out_list.GetString("CLEAN3_PLAN_TIME").Substring(0, 2)) - 12).ToString().Length == 1)
                                {
                                    spdHour.ActiveSheet.Cells[i, 3].Value = "0" + (Convert.ToInt32(out_list.GetString("CLEAN3_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN3_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                                else
                                {
                                    spdHour.ActiveSheet.Cells[i, 3].Value = (Convert.ToInt32(out_list.GetString("CLEAN3_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN3_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                            }
                        }
                        else
                        {
                            if (out_list.GetString("CLEAN3_PLAN_TIME").Substring(0, 2) == "00")
                            {
                                spdHour.ActiveSheet.Cells[i, 3].Value ="12:" + out_list.GetString("CLEAN3_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                            else
                            {
                                spdHour.ActiveSheet.Cells[i, 3].Value = out_list.GetString("CLEAN3_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN3_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                        }
                    }
                    if (out_list.GetChar("CLEAN3_FLAG") == 'Y')
                    {
                        spdHour.ActiveSheet.Cells[i, 3].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        spdHour.ActiveSheet.Cells[i, 3].BackColor = System.Drawing.Color.Empty;
                    }

                    if (out_list.GetString("CLEAN4_PLAN_TIME").Length == 4)
                    {
                        if (Convert.ToInt32(out_list.GetString("CLEAN4_PLAN_TIME").Substring(0, 2)) >= 12)  //12 시보다 크면 PM
                        {
                            if (out_list.GetString("CLEAN4_PLAN_TIME").Substring(0, 2) == "12")
                            {
                                spdHour.ActiveSheet.Cells[i, 4].Value = out_list.GetString("CLEAN4_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN4_PLAN_TIME").Substring(2, 2) + " PM";
                            }
                            else
                            {
                                if ((Convert.ToInt32(out_list.GetString("CLEAN4_PLAN_TIME").Substring(0, 2)) - 12).ToString().Length == 1)
                                {
                                    spdHour.ActiveSheet.Cells[i, 4].Value = "0" + (Convert.ToInt32(out_list.GetString("CLEAN4_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN4_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                                else
                                {
                                    spdHour.ActiveSheet.Cells[i, 4].Value = (Convert.ToInt32(out_list.GetString("CLEAN4_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN4_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                            }
                        }
                        else
                        {
                            if (out_list.GetString("CLEAN4_PLAN_TIME").Substring(0, 2) == "00")
                            {
                                spdHour.ActiveSheet.Cells[i, 4].Value = "12:" + out_list.GetString("CLEAN4_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                            else
                            {
                                spdHour.ActiveSheet.Cells[i, 4].Value = out_list.GetString("CLEAN4_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN4_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                        }
                    }

                    if (out_list.GetChar("CLEAN4_FLAG") == 'Y')
                    {
                        spdHour.ActiveSheet.Cells[i, 4].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        spdHour.ActiveSheet.Cells[i, 4].BackColor = System.Drawing.Color.Empty;
                    }

                    if (out_list.GetString("CLEAN5_PLAN_TIME").Length == 4)
                    {
                        if (Convert.ToInt32(out_list.GetString("CLEAN5_PLAN_TIME").Substring(0, 2)) >= 12)  //12 시보다 크면 PM
                        {
                            if (out_list.GetString("CLEAN5_PLAN_TIME").Substring(0, 2) == "12")
                            {
                                spdHour.ActiveSheet.Cells[i, 5].Value = out_list.GetString("CLEAN5_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN5_PLAN_TIME").Substring(2, 2) + " PM";
                            }
                            else
                            {
                                if ((Convert.ToInt32(out_list.GetString("CLEAN5_PLAN_TIME").Substring(0, 2)) - 12).ToString().Length == 1)
                                {
                                    spdHour.ActiveSheet.Cells[i, 5].Value = "0" + (Convert.ToInt32(out_list.GetString("CLEAN5_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN5_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                                else
                                {
                                    spdHour.ActiveSheet.Cells[i, 5].Value = (Convert.ToInt32(out_list.GetString("CLEAN5_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN5_PLAN_TIME").Substring(2, 2) + " PM";
                                }


                            }

                        }
                        else
                        {
                            if (out_list.GetString("CLEAN5_PLAN_TIME").Substring(0, 2) == "00")
                            {
                                spdHour.ActiveSheet.Cells[i, 5].Value = "12:" + out_list.GetString("CLEAN5_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                            else
                            {
                                spdHour.ActiveSheet.Cells[i, 5].Value = out_list.GetString("CLEAN5_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN5_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                        }
                    }

                    if (out_list.GetChar("CLEAN5_FLAG") == 'Y')
                    {
                        spdHour.ActiveSheet.Cells[i, 5].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        spdHour.ActiveSheet.Cells[i, 5].BackColor = System.Drawing.Color.Empty;
                    }

                    if (out_list.GetString("CLEAN6_PLAN_TIME").Length == 4)
                    {
                        if (Convert.ToInt32(out_list.GetString("CLEAN6_PLAN_TIME").Substring(0, 2)) >= 12)  //12 시보다 크면 PM
                        {
                            if (out_list.GetString("CLEAN6_PLAN_TIME").Substring(0, 2) == "12")
                            {
                                spdHour.ActiveSheet.Cells[i, 6].Value = out_list.GetString("CLEAN6_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN6_PLAN_TIME").Substring(2, 2) + " PM";
                            }
                            else
                            {
                                if ((Convert.ToInt32(out_list.GetString("CLEAN6_PLAN_TIME").Substring(0, 2)) - 12).ToString().Length == 1)
                                {
                                    spdHour.ActiveSheet.Cells[i, 6].Value = "0" + (Convert.ToInt32(out_list.GetString("CLEAN6_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN6_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                                else
                                {
                                    spdHour.ActiveSheet.Cells[i, 6].Value = (Convert.ToInt32(out_list.GetString("CLEAN6_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN6_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                            }
                        }
                        else
                        {
                            if (out_list.GetString("CLEAN6_PLAN_TIME").Substring(0, 2) == "00")
                            {
                                spdHour.ActiveSheet.Cells[i, 6].Value = "12:" + out_list.GetString("CLEAN6_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                            else
                            {
                                spdHour.ActiveSheet.Cells[i, 6].Value = out_list.GetString("CLEAN6_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN6_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                        }
                    }

                    if (out_list.GetChar("CLEAN6_FLAG") == 'Y')
                    {
                        spdHour.ActiveSheet.Cells[i, 6].BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        //spdHour.ActiveSheet.Cells[i, 6].BackColor = System.Drawing.Color.Empty;
                    }

                    if (out_list.GetString("CLEAN7_PLAN_TIME").Length == 4)
                    {
                        if (Convert.ToInt32(out_list.GetString("CLEAN7_PLAN_TIME").Substring(0, 2)) >= 12)  //12 시보다 크면 PM
                        {
                            if (out_list.GetString("CLEAN7_PLAN_TIME").Substring(0, 2) == "12")
                            {
                                spdHour.ActiveSheet.Cells[i, 7].Value = out_list.GetString("CLEAN7_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN7_PLAN_TIME").Substring(2, 2) + " PM";
                            }
                            else
                            {
                                if ((Convert.ToInt32(out_list.GetString("CLEAN7_PLAN_TIME").Substring(0, 2)) - 12).ToString().Length == 1)
                                {
                                    spdHour.ActiveSheet.Cells[i, 7].Value = "0" + (Convert.ToInt32(out_list.GetString("CLEAN7_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN7_PLAN_TIME").Substring(2, 2) + " PM";
                                }
                                else
                                {
                                    spdHour.ActiveSheet.Cells[i, 7].Value = (Convert.ToInt32(out_list.GetString("CLEAN7_PLAN_TIME").Substring(0, 2)) - 12).ToString() + ":" + out_list.GetString("CLEAN7_PLAN_TIME").Substring(2, 2) + " PM";
                                }


                            }

                        }
                        else
                        {
                            if (out_list.GetString("CLEAN7_PLAN_TIME").Substring(0, 2) == "00")
                            {
                                spdHour.ActiveSheet.Cells[i, 7].Value = "12:" + out_list.GetString("CLEAN7_PLAN_TIME").Substring(2, 2) + " AM";
                            }
                            else
                            {
                                spdHour.ActiveSheet.Cells[i, 7].Value = out_list.GetString("CLEAN7_PLAN_TIME").Substring(0, 2) + ":" + out_list.GetString("CLEAN7_PLAN_TIME").Substring(2, 2) + " AM";

                            }
                        }
                    }
                    if (out_list.GetChar("CLEAN7_FLAG") == 'Y')
                    {
                        spdHour.ActiveSheet.Cells[i, 7].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        spdHour.ActiveSheet.Cells[i, 7].BackColor = System.Drawing.Color.Empty;
                    }                                         
                }

                ////색깔 채우기
                int rowCnt = spdHour.ActiveSheet.RowCount;
                if (rowCnt >= 13)
                {
                    spdHour.ActiveSheet.Cells[rowCnt - 1, 1].BackColor = Color.Green;

                    for (int row = 0; row < 4; row++)
                    {
                        spdHour.ActiveSheet.Cells[row, 2].BackColor = Color.Green;
                        spdHour.ActiveSheet.Cells[row, 5].BackColor = Color.Green;
                    }
                    for (int row = 4; row < 8; row++)
                    {
                        spdHour.ActiveSheet.Cells[row, 3].BackColor = Color.Green;
                        spdHour.ActiveSheet.Cells[row, 6].BackColor = Color.Green;
                    }
                    for (int row = 8; row < 12; row++)
                    {
                        spdHour.ActiveSheet.Cells[row, 4].BackColor = Color.Green;
                        spdHour.ActiveSheet.Cells[row, 7].BackColor = Color.Green;
                    }
                }

                for (int row = 0; row < spdHour.ActiveSheet.RowCount; row++)
                {
                    for (int col = 0; col < spdHour.ActiveSheet.ColumnCount; col++)
                    {
                        spdHour.ActiveSheet.Cells[row, col].Locked = true;
                    }
                }

                if (lblupdate_flag.Text == "N")
                {
                    //lblTabber.Enabled = false;
                    comboxHoulyType.Enabled = false;
                    txtHour.Enabled = false;
                    txtMin.Enabled = false;
                }
                else
                {
                    //lblTabber.Enabled = true;
                    comboxHoulyType.Enabled = true;
                    txtHour.Enabled = true;
                    txtMin.Enabled = true;
                }


                

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

               
                //header
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("WORK_SHIFT", " ");

                //detail
                if (ProcStep == 'I')        //create
                {

                   
                    if (dtpDate.Value != null)
                    {
                        bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpScrapDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                        }
                    }

                    for (i = 0; i < spdHour.Sheets[0].Rows.Count; i++)
                    {
                        work_list = in_node.AddNode("TRAN_LIST");
                        work_list.AddString("RES_ID", spdHour.ActiveSheet.Cells[i, 0].Value);


                    }
                }   
               

                else if (ProcStep == 'U')  //UPDATE
                {

                    string VarTime;
                    string VarDay;
                    string Val_hour;
                    string Val_min;
           


 
                    in_node.AddString("WORK_DATE", lblworkdate.Text.Replace("-",""));


                     Val_hour = txtHour.Value.ToString();
                    if (Val_hour.Length == 1)
                    {
                        Val_hour = "0" + Val_hour;
                    }

                        
                    Val_min = txtMin.Value.ToString();
                    if (Val_min.Length == 1)
                    {
                        Val_min = "0" + Val_min;
                    }

                    if (comboxHoulyType.Text == "AM")
                    {
                        if (Val_hour == "12")
                        {
                            Val_hour = "00";        //AM 12 -> 00시 변화(24:HHMM)
                        }

                        
                    }
                    else if (comboxHoulyType.Text == "PM")
                    {
                        if (Convert.ToInt32(txtHour.Value.ToString()) < 12)  //PM 12시보다 작으면 -> 13~23 시간으로 변화
                        {
                            Val_hour = (Convert.ToInt32(txtHour.Value) + 12).ToString();

                            if (Val_hour.Length == 1)
                            {
                                Val_hour = "0" + Val_hour;
                            }

                        }
                        

                    }

                    VarTime = Val_hour + Val_min;
                    //VarTime = "0910";
                    VarDay = lblcol.Text;

                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("CLEAN_TIME", MPCF.Trim(VarTime));
                    work_list.AddChar("CLEAN_DAY", VarDay);

                    String selectDate = Convert.ToString(spdHour_Sheet1.ColumnHeader.Cells.Get(1, int.Parse(VarDay)).Value);
                    selectDate = selectDate.Replace("-", "");

                    work_list.AddString("CMF_2", selectDate);
                    work_list.AddString("RES_ID", lblTabber.Text);
                    if (Checkcom.Checked == true)
                    {
                        work_list.AddChar("COM_FLAG", 'Y');
                    }
                    else
                    {
                        work_list.AddChar("COM_FLAG", ' ');
                    }

                
                }
                else if (ProcStep == 'D')  //DELETE
                {
                    string VarDay;

                    in_node.AddString("WORK_DATE", lblworkdate.Text.Replace("-", ""));
                    VarDay = lblcol.Text;
                    txtHour.Value = "";
                    txtMin.Value = "";

                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("CLEAN_TIME", "");
                    work_list.AddChar("CLEAN_DAY", VarDay);
                    String selectDate = Convert.ToString(spdHour_Sheet1.ColumnHeader.Cells.Get(1, int.Parse(VarDay)).Value);
                    selectDate = selectDate.Replace("-", "");

                    work_list.AddString("CMF_2", selectDate);
                    work_list.AddString("RES_ID", lblTabber.Text);
                    if (Checkcom.Checked == true)
                    {
                        work_list.AddChar("COM_FLAG", 'Y');
                    }
                    else
                    {
                        work_list.AddChar("COM_FLAG", ' ');
                    }
                    in_node.ProcStep = 'U';
                }
                if (MPCF.CallService("CRAS", "CRAS_Update_TABBER_CLEAN", in_node, ref out_node) == false)
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
        #endregion

        private void soiLabel16_Click(object sender, EventArgs e)
        {

        }

        private void pnlScrapInfo_Paint(object sender, PaintEventArgs e)
        {

        }


      
      

      

      

        private void cdvTIME_Load(object sender, EventArgs e)
        {

        }

        

        private void cdvEQ_Load(object sender, EventArgs e)
        {

        }

      
        private void cdvPro_Load(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            set_view();
        }

        private void dtpDate_TextChanged(object sender, EventArgs e)
        {
            set_view();
        }

        private void cdvLineID_ValueChanged(object sender, EventArgs e)
        {
            set_view();
        }

        private void cdvType_ValueChanged(object sender, EventArgs e)
        {
            set_view();
            
        }

        //private void cdvLineIDEntry_ValueChanged(object sender, EventArgs e)
        //{
        //    set_view();
        //}

        private void cdbtabber_ValueChanged(object sender, EventArgs e)
        {
            //set_view();

        }

        private void comboxHoulyType_ValueChanged(object sender, EventArgs e)
        {
            txtHour.Text = string.Empty;
        }

        private void comboxHoulyType_Click(object sender, EventArgs e)
        {
          
        }

        private void lblworkdate_TextChanged(object sender, EventArgs e)
        {
            set_houlytype();
        }

        private void dtpDate_BeforeDropDown(object sender, CancelEventArgs e)
        {

        }

        private void txtHour_ValueChanged(object sender, EventArgs e)
        {
            int result;
            if (comboxHoulyType.Text.Equals("AM"))
            {
                if (int.TryParse(this.txtHour.Text, out result))
                {
                    if (result < 1 || result > 12)
                        txtHour.Text = string.Empty;
                }
                else
                {
                    txtHour.Text = string.Empty;
                }
            }
            else
            {
                if (int.TryParse(this.txtHour.Text, out result))
                {
                    if (result < 1 || result > 11)
                        txtHour.Text = string.Empty;
                }
                else
                {
                    txtHour.Text = string.Empty;
                }
            }

        }

        private void txtMin_ValueChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(this.txtMin.Text, out result))
            {
                if (result < 0 || result > 59)
                    txtMin.Text = string.Empty;
            }
            else
            {
                txtMin.Text = string.Empty;
            }
        }

        private void spdHour_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            m_clrSelectedCellBackground = spdHour.ActiveSheet.ActiveCell.BackColor;
            spdHour.ActiveSheet.ActiveCell.BackColor = Color.Orange;
        }

        private void spdHour_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            spdHour.ActiveSheet.ActiveCell.BackColor = m_clrSelectedCellBackground;
        }
      

    

      
        
        }
}
