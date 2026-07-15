using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSCleavingStatus : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private bool bLineSelected = false;

        public enum CLEAVING_STATUS
        {
            NO,
            EQ,
            LEFT,
            RIGHT
        }

        #endregion

        #region Constructor

        public frmCUSCleavingStatus()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // Init
            //LINE 가져오기.

            // Init
            //GET LINE 
            TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
            TRSNode out_list;
            MPCF.SetInMsg(in_node);

            /* 2023/10/06 이글1, 이글2 라인목록 분리
            in_node.ProcStep = '5';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
            in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
            int i;
            if (MPCF.CallService("CBAS", "CBAS_View_Data_List", in_node, ref out_node) == true)
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    cboLineId.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                }
            }
            */

            //2023/10/06 이글1만 나오도록 수정 시작
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
            in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
            in_node.AddString("LINE_LOCATION", "E1");

            int i;
            if (MPCF.CallService("CWIP", "CWIP_View_Line_List", in_node, ref out_node) == true)
            {
                //Eagle2 - 2023/08/28 이글1만 나오도록 수정 종료
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    cboLineId.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                }
            }

            dtDateId.Value = DateTime.Today;

            DateTime dayShiftStartDate = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd") + " 06:00:00");
            DateTime nightShiftStartDate = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd") + " 18:00:00");
            //DateTime StartDate = Convert.ToDateTime("2022-01-06 16:10:00");

            //현재시간
            DateTime NowDate = DateTime.Now;

            cboTimeId.Items.Add("060000", "06:00");
            cboTimeId.Items.Add("070000", "07:00");
            cboTimeId.Items.Add("080000", "08:00");
            cboTimeId.Items.Add("090000", "09:00");
            cboTimeId.Items.Add("100000", "10:00");
            cboTimeId.Items.Add("110000", "11:00");
            cboTimeId.Items.Add("120000", "12:00");
            cboTimeId.Items.Add("130000", "13:00");
            cboTimeId.Items.Add("140000", "14:00");
            cboTimeId.Items.Add("150000", "15:00");
            cboTimeId.Items.Add("160000", "16:00");
            cboTimeId.Items.Add("170000", "17:00");
            cboTimeId.Items.Add("180000", "18:00");
            cboTimeId.Items.Add("190000", "19:00");
            cboTimeId.Items.Add("200000", "20:00");
            cboTimeId.Items.Add("210000", "21:00");
            cboTimeId.Items.Add("220000", "22:00");
            cboTimeId.Items.Add("230000", "23:00");
            cboTimeId.Items.Add("000000", "00:00");
            cboTimeId.Items.Add("010000", "01:00");
            cboTimeId.Items.Add("020000", "02:00");
            cboTimeId.Items.Add("030000", "03:00");
            cboTimeId.Items.Add("040000", "04:00");
            cboTimeId.Items.Add("050000", "05:00");

            cboTimeId.SelectedText = NowDate.ToString("HH") + "0000";

            
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) 
                bIsShown = true;
            }
        }

        //LINE CHANGE EVENT
        //btnProcess_Click();

        /// <summary>
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }


                if (ViewCleavingStatusList() == false)
                {
                    return;
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        #endregion
        
        #region Functions

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewCleavingStatusList()
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_CLEAVING_STATUS_IN");
                TRSNode out_node = new TRSNode("LIST");
 
                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LINE_ID", cboLineId.Value);
                String dtid = dtDateId.GetValueAsDateTime().ToString("yyyyMMdd");
                in_node.AddString("TRAN_DATE", dtid);
                in_node.AddString("TRAN_TIME", cboTimeId.Value);

                if (MPCF.CallService("CWIP", "CWIP_View_Cleaving_Status", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                int max_count = out_node.GetList(0).Count;
                string res_id = string.Empty;
                string last_udpate_time = string.Empty;
                string last_udpate_time_tmp = string.Empty;

                if (max_count == 0)
                {
                    clear();
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if(i == 0)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 5).Replace("-","");
                        soiCleaving1.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiCleaving1.Text = res_id;
                        soiCleavingL01.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiHCCSNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_SAP")+"";
                        soiHCCLNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_LINE") + "";
                        soiFCCSNum.Text = out_node.GetList(0)[i].GetInt("FULL_CELL_SAP") + "";
                        soiCUOTNum.Text = out_node.GetList(0)[i].GetInt("CELL_UNPACK") + "";
                    }
                    else if (i == 1)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 5).Replace("-", "");
                        soiCleaving2.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiCleaving2.Text = res_id;
                        soiCleavingL02.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiHCCSNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_SAP") + "";
                        soiHCCLNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_LINE") + "";
                        soiFCCSNum.Text = out_node.GetList(0)[i].GetInt("FULL_CELL_SAP") + "";
                        soiCUOTNum.Text = out_node.GetList(0)[i].GetInt("CELL_UNPACK") + "";
                    }
                    else if (i == 2)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 5).Replace("-", "");
                        soiCleaving3.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiCleaving3.Text = res_id;
                        soiCleavingL03.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiHCCSNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_SAP") + "";
                        soiHCCLNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_LINE") + "";
                        soiFCCSNum.Text = out_node.GetList(0)[i].GetInt("FULL_CELL_SAP") + "";
                        soiCUOTNum.Text = out_node.GetList(0)[i].GetInt("CELL_UNPACK") + "";
                    }
                    else if (i == 3)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 5).Replace("-", "");
                        soiCleaving4.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiCleaving4.Text = res_id;
                        soiCleavingL04.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiHCCSNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_SAP") + "";
                        soiHCCLNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_LINE") + "";
                        soiFCCSNum.Text = out_node.GetList(0)[i].GetInt("FULL_CELL_SAP") + "";
                        soiCUOTNum.Text = out_node.GetList(0)[i].GetInt("CELL_UNPACK") + "";
                    }
                    else if (i == 4)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 5).Replace("-", "");
                        soiCleaving5.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiCleaving5.Text = res_id;
                        soiCleavingL05.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiHCCSNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_SAP") + "";
                        soiHCCLNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_LINE") + "";
                        soiFCCSNum.Text = out_node.GetList(0)[i].GetInt("FULL_CELL_SAP") + "";
                        soiCUOTNum.Text = out_node.GetList(0)[i].GetInt("CELL_UNPACK") + "";
                    }
                    else if (i == 5)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 5).Replace("-", "");
                        soiCleaving6.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiCleaving6.Text = res_id;
                        soiCleavingL06.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiHCCSNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_SAP") + "";
                        soiHCCLNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_LINE") + "";
                        soiFCCSNum.Text = out_node.GetList(0)[i].GetInt("FULL_CELL_SAP") + "";
                        soiCUOTNum.Text = out_node.GetList(0)[i].GetInt("CELL_UNPACK") + "";
                    }
                    else if (i == 6)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 5).Replace("-", "");
                        soiCleaving7.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiCleaving7.Text = res_id;
                        soiCleavingL07.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiHCCSNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_SAP") + "";
                        soiHCCLNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_LINE") + "";
                        soiFCCSNum.Text = out_node.GetList(0)[i].GetInt("FULL_CELL_SAP") + "";
                        soiCUOTNum.Text = out_node.GetList(0)[i].GetInt("CELL_UNPACK") + "";
                    }
                    else if (i == 7)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 5).Replace("-", "");
                        soiCleaving8.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiCleaving8.Text = res_id;
                        soiCleavingL08.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiHCCSNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_SAP") + "";
                        soiHCCLNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_LINE") + "";
                        soiFCCSNum.Text = out_node.GetList(0)[i].GetInt("FULL_CELL_SAP") + "";
                        soiCUOTNum.Text = out_node.GetList(0)[i].GetInt("CELL_UNPACK") + "";
                    }
                    else if (i == 8)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 5).Replace("-", "");
                        soiCleaving9.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiCleaving9.Text = res_id;
                        soiCleavingL09.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiHCCSNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_SAP") + "";
                        soiHCCLNum.Text = out_node.GetList(0)[i].GetInt("HALF_CELL_LINE") + "";
                        soiFCCSNum.Text = out_node.GetList(0)[i].GetInt("FULL_CELL_SAP") + "";
                        soiCUOTNum.Text = out_node.GetList(0)[i].GetInt("CELL_UNPACK") + "";
                    }
                    

                    if (out_node.GetList(0)[i].GetString("UPDATE_TIME").Length == 14)
                    {
                        if (i == 0)
                        {
                            last_udpate_time = out_node.GetList(0)[i].GetString("UPDATE_TIME").ToString();
                        }
                        else
                        {
                            last_udpate_time_tmp = out_node.GetList(0)[i].GetString("UPDATE_TIME").ToString();

                            if (DateTime.Parse(MPCF.MakeDateFormat(last_udpate_time, DATE_TIME_FORMAT.DATETIME)) < DateTime.Parse(MPCF.MakeDateFormat(last_udpate_time_tmp, DATE_TIME_FORMAT.DATETIME)))
                            {
                                last_udpate_time = out_node.GetList(0)[i].GetString("UPDATE_TIME").ToString();
                            }
                        }
                    }
                }

                /*
                if(last_udpate_time.Length == 14)
                {
                    soiGroupBox1.Text = "Cleaving Status - " + res_id + "(Time: " + last_udpate_time.Substring(8, 2) + ":" + last_udpate_time.Substring(10, 2) + ")";
                }
                else
                {
                    soiGroupBox1.Text = "Cleaving Status - " + res_id + "(Time: xx:xx)";
                }
                */
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// User 정보 조회
        /// </summary>
        /// <param name="sUserId"></param>
        /// <returns></returns>
        /// 
        /*
        public string ViewUserInfo(string sUserId)
        {
            TRSNode in_node = new TRSNode("VIEW_USER_IN");
            TRSNode out_node = new TRSNode("VIEW_USER_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("USER_ID", sUserId);

                if (MPCF.CallService("SEC", "SEC_View_User", in_node, ref out_node) == false)
                {
                    return "";
                }


                return out_node.GetString("USER_DESC");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
                return "";
            }
        }
        */


        //UPDATE
        private bool Update_Cleaving_Status_List()
        {
            TRSNode in_node = new TRSNode("TRAN_LIST");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode work_list = null;

            //if (string.IsNullOrEmpty(sTmpLotID) == true)


            if (soiHCCSNum.Text == "" || string.IsNullOrEmpty(soiHCCSNum.Text) == true)
            {
                soiHCCSNum.Text = "0";
            }

            if (soiHCCLNum.Text == "" || string.IsNullOrEmpty(soiHCCLNum.Text) == true)
            {
                soiHCCLNum.Text = "0";
            }

            if (soiFCCSNum.Text == "" || string.IsNullOrEmpty(soiFCCSNum.Text) == true)
            {
                soiFCCSNum.Text = "0";
            }

            if (soiCUOTNum.Text == "" || string.IsNullOrEmpty(soiCUOTNum.Text) == true)
            {
                soiCUOTNum.Text = "0";
            }



            try
            {
                MPCF.SetInMsg(in_node);

                for (int i = 0; i < 9; i++)
                {
                    string resId = String.Empty;
                    string comment1 = String.Empty;
                    int hccs = 0;
                    int hccl = 0;
                    int fccs = 0;
                    int cuot = 0;

                    if (i == 0)
                    {
                        resId = soiCleaving1.Tag.ToString();
                        comment1 = soiCleavingL01.Text;
                        hccs = int.Parse(soiHCCSNum.Text);
                        hccl = int.Parse(soiHCCLNum.Text);
                        fccs = int.Parse(soiFCCSNum.Text);
                        cuot = int.Parse(soiCUOTNum.Text);
                    }
                    else if (i == 1)
                    {
                        resId = soiCleaving2.Tag.ToString();
                        comment1 = soiCleavingL02.Text;
                        hccs = int.Parse(soiHCCSNum.Text);
                        hccl = int.Parse(soiHCCLNum.Text);
                        fccs = int.Parse(soiFCCSNum.Text);
                        cuot = int.Parse(soiCUOTNum.Text);
                    }
                    else if (i == 2)
                    {
                        resId = soiCleaving3.Tag.ToString();
                        comment1 = soiCleavingL03.Text;
                        hccs = int.Parse(soiHCCSNum.Text);
                        hccl = int.Parse(soiHCCLNum.Text);
                        fccs = int.Parse(soiFCCSNum.Text);
                        cuot = int.Parse(soiCUOTNum.Text);
                    }
                    else if (i == 3)
                    {
                        resId = soiCleaving4.Tag.ToString();
                        comment1 = soiCleavingL04.Text;
                        hccs = int.Parse(soiHCCSNum.Text);
                        hccl = int.Parse(soiHCCLNum.Text);
                        fccs = int.Parse(soiFCCSNum.Text);
                        cuot = int.Parse(soiCUOTNum.Text);
                    }
                    else if (i == 4)
                    {
                        resId = soiCleaving5.Tag.ToString();
                        comment1 = soiCleavingL05.Text;
                        hccs = int.Parse(soiHCCSNum.Text);
                        hccl = int.Parse(soiHCCLNum.Text);
                        fccs = int.Parse(soiFCCSNum.Text);
                        cuot = int.Parse(soiCUOTNum.Text);
                    }
                    else if (i == 5)
                    {
                        resId = soiCleaving6.Tag.ToString();
                        comment1 = soiCleavingL06.Text;
                        hccs = int.Parse(soiHCCSNum.Text);
                        hccl = int.Parse(soiHCCLNum.Text);
                        fccs = int.Parse(soiFCCSNum.Text);
                        cuot = int.Parse(soiCUOTNum.Text);
                    }
                    else if (i == 6)
                    {
                        resId = soiCleaving7.Tag.ToString();
                        comment1 = soiCleavingL07.Text;
                        hccs = int.Parse(soiHCCSNum.Text);
                        hccl = int.Parse(soiHCCLNum.Text);
                        fccs = int.Parse(soiFCCSNum.Text);
                        cuot = int.Parse(soiCUOTNum.Text);
                    }
                    else if (i == 7)
                    {
                        resId = soiCleaving8.Tag.ToString();
                        comment1 = soiCleavingL08.Text;
                        hccs = int.Parse(soiHCCSNum.Text);
                        hccl = int.Parse(soiHCCLNum.Text);
                        fccs = int.Parse(soiFCCSNum.Text);
                        cuot = int.Parse(soiCUOTNum.Text);
                    }
                    else if (i == 8)
                    {
                        resId = soiCleaving9.Tag.ToString();
                        comment1 = soiCleavingL09.Text;
                        hccs = int.Parse(soiHCCSNum.Text);
                        hccl = int.Parse(soiHCCLNum.Text);
                        fccs = int.Parse(soiFCCSNum.Text);
                        cuot = int.Parse(soiCUOTNum.Text);
                    }
                    
                    work_list = in_node.AddNode("WORK_LIST");
                    work_list.AddString("FACTORY", MPGV.gsFactory);
                    work_list.AddString("LINE_ID", MPCF.Trim(cboLineId.Value));
                    work_list.AddString("RES_ID", resId);
                    String dtid = dtDateId.GetValueAsDateTime().ToString("yyyyMMdd");
                    work_list.AddString("TRAN_DATE", dtid);
                    work_list.AddString("TRAN_TIME", cboTimeId.Value);
                    work_list.AddString("COMMENT_1", MPCF.Trim(comment1));
                    work_list.AddInt("HALF_CELL_SAP", hccs);
                    work_list.AddInt("HALF_CELL_LINE", hccl);
                    work_list.AddInt("FULL_CELL_SAP", fccs);
                    work_list.AddInt("CELL_UNPACK", cuot);
                    
                }
                

                if (MPCF.CallService("CWIP", "CWIP_Update_Cleaving_Status", in_node, ref out_node) == false)
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

        private bool CheckCondition(string FuncName)
        {
            switch (FuncName)
            {

                case "VIEW":

                    if (MPCF.CheckValue(cboTimeId, false) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(dtDateId, false) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(cboLineId, false) == false)
                    {
                        return false;
                    }

                    

                    break;

                case "UPDATE":

                    if (MPCF.CheckValue(cboTimeId, false) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(dtDateId, false) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(cboLineId, false) == false)
                    {
                        return false;
                    }

                    break;
            }



            return true;
        }

        //CLEAR
        private void clear()
        {
            soiCleavingL01.Text = "";
            soiCleavingL02.Text = "";
            soiCleavingL03.Text = "";
            soiCleavingL04.Text = "";
            soiCleavingL05.Text = "";
            soiCleavingL06.Text = "";
            soiCleavingL07.Text = "";
            soiCleavingL08.Text = "";
            soiCleavingL09.Text = "";
            soiHCCSNum.Text = "";
            soiHCCLNum.Text = "";
            soiFCCSNum.Text = "";
            soiCUOTNum.Text = "";
        }

        #endregion
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (CheckCondition("UPDATE") == false)
                {
                    return;
                }

                if (Update_Cleaving_Status_List() == false)
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cboLineId_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (bLineSelected)
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cboTimeId_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (bLineSelected)
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private void dtDateId_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (bLineSelected)
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cboLineId_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                bLineSelected = true;
                btnProcess.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
    }
}
