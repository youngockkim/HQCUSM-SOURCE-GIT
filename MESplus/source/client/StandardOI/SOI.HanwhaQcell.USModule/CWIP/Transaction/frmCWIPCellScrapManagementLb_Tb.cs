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
    
    public partial class frmCWIPCellScrapManagementLb_Tb : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;


        public enum TABBER_STATUS
        {
            NO,
            EQ,
            LEFT,
            RIGHT
        }

        #endregion
        
        #region [Constant Definition]

        int LB_DESIRED_DECIMAL_POINT = 2;
        #endregion

        #region Constructor

        public frmCWIPCellScrapManagementLb_Tb()
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
         
            //get date
            Dtpscrapdt.Value = DateTime.Today;
            //GET LINE 
            TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
            TRSNode out_list;
            MPCF.SetInMsg(in_node);

            //Eagle2 - 2023/08/28 이글1만 나오도록 수정 시작
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

                if (ViewTabberStatusList() == false)
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
        /// 


        private bool setup_tabber_name()
        {

            soiTabber1.Text = "US-E" +(cboLineId.SelectedIndex + 1) + "-TB-01";
            soiTabber2.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-02";
            soiTabber3.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-03";
            soiTabber4.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-04";
            soiTabber5.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-05";
            soiTabber6.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-06";
            soiTabber7.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-07";
            soiTabber8.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-08";
            soiTabber9.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-09";
            soiTabber10.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-10";
            soiTabber11.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-11";
            soiTabber12.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-12";
            if (MPCF.ToInt(cboLineId.Text.Substring(3, 2)) == 4 || MPCF.ToInt(cboLineId.Text.Substring(3, 2)) == 5
                || MPCF.ToInt(cboLineId.Text.Substring(3, 2)) == 6 || MPCF.ToInt(cboLineId.Text.Substring(3, 2)) == 7)
            {
                soiTabber11.Text = "";
                soiTabberL11.Enabled = false;
                soiTabberR11.Enabled = false;
                soiTabber12.Text = "";
                soiTabberL12.Enabled = false;
                soiTabberR12.Enabled = false;
            }
            else
            {
                soiTabber11.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-11";
                soiTabberL11.Enabled = true;
                soiTabberR11.Enabled = true;
                soiTabber12.Text = "US-E" + (cboLineId.SelectedIndex + 1) + "-TB-12";
                soiTabberL12.Enabled = true;
                soiTabberR12.Enabled = true;
            }
            

            return true;
        }

        private bool sumit_view()
        {
            if (Dtpscrapdt.Value != "" && cboLineId.Value != "" && cdvShift.Text != "" && cdvMatID.Text != "")
            {
                ViewTabberStatusList();
            }

            return true;
        }

        private bool cleardata()
        {
            soiTabberL01.Value = "";
            soiTabberR01.Text = "";

            soiTabberL02.Value = "";
            soiTabberR02.Text = "";

            soiTabberL03.Value = "";
            soiTabberR03.Text = "";

            soiTabberL04.Value = "";
            soiTabberR04.Text = "";

            soiTabberL05.Value = "";
            soiTabberR05.Text = "";

            soiTabberL06.Value = "";
            soiTabberR06.Text = "";

            soiTabberL07.Value = "";
            soiTabberR07.Text = "";

            soiTabberL08.Value = "";
            soiTabberR08.Text = "";

            soiTabberL09.Value = "";
            soiTabberR09.Text = "";

            soiTabberL10.Value = "";
            soiTabberR10.Text = "";

            soiTabberL11.Value = "";
            soiTabberR11.Text = "";

            soiTabberL12.Value = "";
            soiTabberR12.Text = "";



            return true;
        }

        private bool ViewTabberStatusList()
        {
            try
            {
                DateTime dtpFromDateTimeOut = new DateTime();
              
                if(cdvShift.Text == "")  
                {
                    MPCF.ShowMsgBox("Please Seleted Work Shift");
                    cdvShift.Focus();
                    return false;
                }

                if (cboLineId.Text == "")
                {
                    MPCF.ShowMsgBox("Please Seleted Lince Code");
                    cboLineId.Focus();
                    return false;
                }
                if (cdvMatID.Text == "")
                {
                    MPCF.ShowMsgBox("Please Seleted Material Code");
                    cdvMatID.Focus();
                    return false;
                }



                cleardata();
                setup_tabber_name();

                TRSNode in_node = new TRSNode("VIEW_SCRAP_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_SCRAP_LIST_OUT");
 
                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LINE_ID", cboLineId.Value);
                if (Dtpscrapdt.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(Dtpscrapdt.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                        in_node.AddString("TO_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                in_node.AddString("LINE_ID", MPCF.Trim(cboLineId.Value));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShift.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));





                if (MPCF.CallService("CWIP", "CWIP_View_Scrap_List_Lb", in_node, ref out_node) == false)
                {
                    return false;
                }

                int max_count = out_node.GetList(0).Count;
                string res_id = string.Empty;
            
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    
                    if (string.IsNullOrEmpty(out_node.GetList(0)[i].GetString("RES_ID")) == true)
                    {
                        continue;
                    }

                    if((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "01")
                        
                        )
                    {
                        soiTabber1.Text = out_node.GetList(0)[i].GetString("RES_ID");
                       // soiTabberL01.Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("LOSS_LB"),0);
                        soiTabberL01.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR01.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "02"))
                    {
                        soiTabber2.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL02.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR02.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                     && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "03"))
                    {
                        soiTabber3.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL03.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR03.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "04"))
                    {
                        soiTabber4.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL04.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR04.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "05"))
                    {
                        soiTabber5.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL05.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR05.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "06"))
                    {
                        soiTabber6.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL06.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR06.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "07"))
                    {
                        soiTabber7.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL07.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR07.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "08"))
                    {
                        soiTabber8.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL08.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR08.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "09"))
                    {
                        soiTabber9.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL09.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR09.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "10"))
                    {
                        soiTabber10.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL10.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR10.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "11"))
                    {
                        soiTabber11.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL11.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR11.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                    if ((out_node.GetList(0)[i].GetString("RES_ID").Substring(6, 2) == "TB")
                    && (out_node.GetList(0)[i].GetString("RES_ID").Substring(9, 2) == "12"))
                    {
                        soiTabber12.Text = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabberL12.Value = out_node.GetList(0)[i].GetString("LOSS_LB");
                        soiTabberR12.Text = out_node.GetList(0)[i].GetString("LOSS_COMMENT");
                    }

                   




                    
                 

                   
                }
                //btnSave.Enabled = true;

              
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }



        //UPDATE
        private bool Update_Tabber_Status_List(char act_type)
        {

            DateTime dtpFromDateTimeOut = new DateTime();

            if (cdvShift.Text == "")
            {
                MPCF.ShowMsgBox("Please Seleted Work Shift");
                cdvShift.Focus();
                return false;
            }

            if (cboLineId.Text == "")
            {
                MPCF.ShowMsgBox("Please Seleted Lince Code");
                cboLineId.Focus();
                return false;
            }
            if (cdvMatID.Text == "")
            {
                MPCF.ShowMsgBox("Please Seleted Material Code");
                cdvMatID.Focus();
                return false;
            }

            string check_update;

            TRSNode in_node = new TRSNode("UPDATE_SCRAP_IN");
            TRSNode out_node = new TRSNode("UPDATE_SCRAP_OUT");
            TRSNode work_list = null;

            check_update = "";
            try
            {
                DateTime dtpScrapDateTimeOut = new DateTime();
                bool bTrySuccess = DateTime.TryParse(Dtpscrapdt.Value.ToString(), out dtpScrapDateTimeOut);
                if (bTrySuccess == true)
                {
                    in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = act_type;
                in_node.AddString("LINE_ID", MPCF.Trim(cboLineId.Value));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShift.Text));


                for (int i = 0; i < 12; i++)
                {
                    string resId = String.Empty;
                    string comment1 = String.Empty;
                    string comment2 = String.Empty;

                    if (i == 0)
                    {
                        resId = soiTabber1.Text;
                        comment1 = soiTabberL01.Text;
                        comment2 = soiTabberR01.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "")  //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL01.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL01.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL01.Focus();
                            return false;
                        }

                        
                    }
                    else if (i == 1)
                    {
                        resId = soiTabber2.Text;
                        comment1 = soiTabberL02.Text;
                        comment2 = soiTabberR02.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL02.Focus();
                            return false;
                        }


                        if (!validateNumbernDecimalPoint(soiTabberL02.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL02.Focus();
                            return false;
                        }

                    }
                    else if (i == 2)
                    {
                        resId = soiTabber3.Text;
                        comment1 = soiTabberL03.Text;
                        comment2 = soiTabberR03.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL03.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL03.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL03.Focus();
                            return false;
                        }

                    }
                    else if (i == 3)
                    {
                        resId = soiTabber4.Text;
                        comment1 = soiTabberL04.Text;
                        comment2 = soiTabberR04.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL04.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL04.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL04.Focus();
                            return false;
                        }
                    }
                    else if (i == 4)
                    {
                        resId = soiTabber5.Text;
                        comment1 = soiTabberL05.Text;
                        comment2 = soiTabberR05.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL05.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL05.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL05.Focus();
                            return false;
                        }

                    }
                    else if (i == 5)
                    {
                        resId = soiTabber6.Text;
                        comment1 = soiTabberL06.Text;
                        comment2 = soiTabberR06.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL06.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL06.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL06.Focus();
                            return false;
                        }

                    }
                    else if (i == 6)
                    {
                        resId = soiTabber7.Text;
                        comment1 = soiTabberL07.Text;
                        comment2 = soiTabberR07.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL07.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL07.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL07.Focus();
                            return false;
                        }

                    }
                    else if (i == 7)
                    {
                        resId = soiTabber8.Text;
                        comment1 = soiTabberL08.Text;
                        comment2 = soiTabberR08.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL08.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL08.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL08.Focus();
                            return false;
                        }

                    }
                    else if (i == 8)
                    {
                        resId = soiTabber9.Text;
                        comment1 = soiTabberL09.Text;
                        comment2 = soiTabberR09.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "")//IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL09.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL09.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL09.Focus();
                            return false;
                        }

                    }
                    else if (i == 9)
                    {
                        resId = soiTabber10.Text;
                        comment1 = soiTabberL10.Text;
                        comment2 = soiTabberR10.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL10.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL10.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL10.Focus();
                            return false;
                        }

                    }
                    else if (i == 10)
                    {
                        resId = soiTabber11.Text;
                        comment1 = soiTabberL11.Text;
                        comment2 = soiTabberR11.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL11.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL11.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL11.Focus();
                            return false;
                        }

                    }
                    else if (i == 11)
                    {
                        resId = soiTabber12.Text;
                        comment1 = soiTabberL12.Text;
                        comment2 = soiTabberR12.Text;

                        if (MPCF.ToDbl(comment1) < 1.85 && comment1 != "") //IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(567));
                            soiTabberL12.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(soiTabberL12.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            soiTabberL12.Focus();
                            return false;
                        }
                    }

                    if (comment1 == "0")        //0보다 작으면 넘어간다
                    {
                        continue;
                    }

                    if (comment1 == "")        //0보다 작으면 넘어간다
                    {
                        continue;
                    }

                    check_update = "X";




                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("MAT_ID", MPCF.Trim(cdvMatID.Code));
                    work_list.AddString("LOSS_OPER", MPCF.Trim(HQGC.OPER_M2000));
                    work_list.AddString("RES_ID", MPCF.Trim(resId));
                    work_list.AddString("CAUSE", MPCF.Trim("C001"));
                    work_list.AddString("LOSS_LB", MPCF.Trim(comment1.Replace(",", "")));
                    work_list.AddString("LOSS_COMMENT", MPCF.Trim(comment2));
                    work_list.AddString("LOSS_LB_CHECK_NEW", 'Y');//IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                    work_list.AddString("BOX_WEIGHT", "1.85");    // 2023-09-09 신규추가(이글1,2상이하여 신규 컬럼 추가하여 box무게저장)
                }

                if (check_update != "X")
                {
                    MPCF.ShowMsgBox("Please Enter LB");
                    return false;
                }


                if (MPCF.CallService("CWIP", "CWIP_Update_Scrap_List_Lb", in_node, ref out_node) == false)
                {
                    return false;
                }
                //btnSave.Enabled = true;
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
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
              
                if (Update_Tabber_Status_List('I') == false)
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

        private void cboLineId_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                cleardata();
                setup_tabber_name();
                //btnSave.Enabled = false;
                cdvMatID.Text = "";
                cdvMatID.Description = "";
                sumit_view();


                //btnProcess.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void Dtpscrapdt_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                cleardata();
                setup_tabber_name();
                //btnSave.Enabled = false;
                cdvMatID.Text = "";
                cdvMatID.Description = "";
                sumit_view();



                //btnProcess.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private void  cdvShift_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                cleardata();
                setup_tabber_name();

                //btnProcess.PerformClick();
                //btnSave.Enabled = false;
                sumit_view();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

        }

        private void cdvMatID_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                cleardata();
                setup_tabber_name();

                //btnProcess.PerformClick();
                //btnSave.Enabled = false;
                sumit_view();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

        }

        private void cdvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            DateTime dtpScrapDateTimeOut = new DateTime();
            try
            {
              

                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                bool bTrySuccess = DateTime.TryParse(Dtpscrapdt.Value.ToString(), out dtpScrapDateTimeOut);
                if (bTrySuccess == true)
                {
                    in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                }
                in_node.AddString("LINE_ID", MPCF.Trim(cboLineId.Value));
                in_node.AddString("OPER", "M2000");

                string[] header = new string[] { "Material", "Description" };
                string[] display = new string[] { "MAT_ID", "MAT_SHORT_DESC" };

                cdvMatID.Text = cdvMatID.Show(cdvMatID, "Material ID", "CWIP", "CWIP_View_Material_List_By_Production", in_node, "MAT_LIST", display, header, "MAT_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvMatID.Text) == true)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Update_Tabber_Status_List('U') == false)
            {
                return;
            }
            else
            {
                btnProcess.PerformClick();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Update_Tabber_Status_List('D') == false)
            {
                return;
            }
            else
            {
                btnProcess.PerformClick();
            }
        }



        private void soiTabberL01_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL01.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }


        }

               

        private void soiTabberL02_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL02.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }



        }

        private void soiTabberL03_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL03.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }


        }


        private void soiTabberL04_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL04.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }


        }

        private void soiTabberL05_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL05.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }


        }

        private void soiTabberL06_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL06.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }


        }

        private void soiTabberL07_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL07.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }


        }


        private void soiTabberL08_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL08.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }


        }


        private void soiTabberL09_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL09.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }


        }

        private void soiTabberL10_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL10.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }


        }

        private void soiTabberL11_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL11.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }



        }

        private void soiTabberL12_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (soiTabberL12.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void soiTabberL01_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL01.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL02_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL02.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL03_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL03.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL04_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL04.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL05_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL05.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL06_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL06.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL07_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL07.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL08_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL08.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL09_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL09.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL10_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL10.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL11_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL11.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void soiTabberL12_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(soiTabberL12.Text, LB_DESIRED_DECIMAL_POINT);
        }

        //숫자여부/Null 값 여부 검증
        private bool validateNumbernDecimalPoint(string cellValue, int desiredDecimalPoint)
        {
            float result;

            if (cellValue.Trim().Length <= 0)
            {
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false); 
                return true;
            }

            NumberStyles style = NumberStyles.Number | NumberStyles.AllowDecimalPoint;
            if (float.TryParse(cellValue, style, CultureInfo.InvariantCulture, out result) == false)
            {
                MPCF.ShowMessage("Please write two decimal places only (0.00 lbs).", MSG_LEVEL.ERROR, false);
                return false;
            }

            int posPoint = cellValue.IndexOf(".");
            if (posPoint <= 0 || cellValue.Length - (posPoint + 1) != 2)
            {
                MPCF.ShowMessage("Please write two decimal places only (0.00 lbs).", MSG_LEVEL.ERROR, false);
                return false;
            }
            MPCF.ShowMessage("", MSG_LEVEL.NONE, false);
            return true;
        }
    }
}
