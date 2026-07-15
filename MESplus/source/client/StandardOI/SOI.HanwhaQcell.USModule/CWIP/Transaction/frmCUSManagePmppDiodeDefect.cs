using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    public partial class frmCUSManagePmppDiodeDefect : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private static string FM_TYPE = "PT";

        private bool registeredYn = false;

        public enum FM_LIST
        {
            NO,
            COL_CHK,
            LINE,
            MODULE_ID,
            PMPP,
            DIODE,
            RES_ID,
            INS_TIME,
            WORK_DATE,
            WORK_TIME,
            WORK_SHIFT,
            DEFECT_POSITION,
            MACHINE_ISSUE_TYPE,
            OPERATOR,
            MACHINE_TECHNICIAN,
            SOLDERING,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME
        }

        #endregion

        #region Constructor

        public frmCUSManagePmppDiodeDefect()
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
            dtpFrom.Value = DateTime.Today;
           // dtpTo.Value = DateTime.Today;
           // dtpApplyTime.Value = DateTime.Now;
           // cdvUserID.Text = MPGV.gsUserID;

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


        private void soiLineCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                soiLineCode.Text = soiLineCode.Show(soiLineCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(soiLineCode.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private void soiSolderingCondition_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@PMPP_SOLDERING"));

                string[] header = new string[] { "Soldering Type", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                soiSolderingCondition.Text = soiSolderingCondition.Show(soiSolderingCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(soiSolderingCondition.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private void soiDetectPositionCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
        
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_DETECT_POSITION));

                string[] header = new string[] { "Detect Position Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                soiDetectPositionCode.Text = soiDetectPositionCode.Show(soiDetectPositionCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // ValidationS
                if (string.IsNullOrEmpty(soiDetectPositionCode.Text) == true)
                {
                    return;
                }
              
                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        //RES_ID 
        private void soiFrameEQCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
            
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_FRAME_EQUIPMENT));

                string[] header = new string[] { "Frame EQ Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                soiFrameEQCode.Text = soiFrameEQCode.Show(soiFrameEQCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(soiFrameEQCode.Text) == true)
                {
                    return;
                }
        
                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        //soldering click
        private void soiSolderingCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@PMPP_SOLDERING"));

                string[] header = new string[] { "Soldering Type", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                soiSolderingCode.Text = soiSolderingCode.Show(soiSolderingCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(soiFrameEQCode.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void soiShiftCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
          
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                string[] header = new string[] { "Shift Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                soiShiftCode.Text = soiShiftCode.Show(soiShiftCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(soiShiftCode.Text) == true)
                {
                    return;
                }
           
                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

      


        //private void soiMachineIssueTypeCode_CodeViewButtonClick(object sender, EventArgs e)
        //{
        //    try
        //    {
             
        //        TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
        //        MPCF.SetInMsg(in_node);
        //        in_node.ProcStep = '1';
        //        in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MACHINE_ISSUE_TYPE));

        //        string[] header = new string[] { "Machine Issue Type Code", "Description" };
        //        string[] display = new string[] { "KEY_1", "DATA_1" };

        //        soiMachineIssueTypeCode.Text = soiMachineIssueTypeCode.Show(soiMachineIssueTypeCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

        //        // Validation
        //        if (string.IsNullOrEmpty(soiMachineIssueTypeCode.Text) == true)
        //        {
        //            return;
        //        }
         
        //        return;

        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //        return;
        //    }
        //}


		private void soiDefectTypeCode_CodeViewButtonClick(object sender, EventArgs e)
		{
			try
			{

				TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
				MPCF.SetInMsg(in_node);
				in_node.ProcStep = '1';
				in_node.AddString("TABLE_NAME", MPCF.Trim("@PMPP_DEFECT_TYPE"));

				string[] header = new string[] { "PMPP Defect Type Code", "Description" };
				string[] display = new string[] { "KEY_1", "DATA_1" };

				soiDefectTypeCode.Text = soiDefectTypeCode.Show(soiDefectTypeCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

				// Validation
				if (string.IsNullOrEmpty(soiDefectTypeCode.Text) == true)
				{
					return;
				}

				return;

			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
				return;
			}
		}

        private void cdvDefectPositionU_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
     
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_DETECT_POSITION));

                string[] header = new string[] { "Defect Position Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvDefectPositionU.Text = cdvDefectPositionU.Show(cdvDefectPositionU, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvDefectPositionU.Text) == true)
                {
                    return;
                }
       
                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

		//private void cdvMachineIssueTypeU_CodeViewButtonClick(object sender, EventArgs e)
		//{
		//    try
		//    {
 
		//        TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
		//        MPCF.SetInMsg(in_node);
		//        in_node.ProcStep = '1';
		//        in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MACHINE_ISSUE_TYPE));

		//        string[] header = new string[] { "Machine Issue Type Code", "Description" };
		//        string[] display = new string[] { "KEY_1", "DATA_1" };

		//        cdvMachineIssueTypeU.Text = cdvMachineIssueTypeU.Show(cdvMachineIssueTypeU, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

		//        // Validation
		//        if (string.IsNullOrEmpty(cdvMachineIssueTypeU.Text) == true)
		//        {
		//            return;
		//        }
               
		//        return;

		//    }
		//    catch (Exception ex)
		//    {
		//        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
		//        return;
		//    }
		//}


		private void cdvDefectTypeU_CodeViewButtonClick(object sender, EventArgs e)
		{
			try
			{
				TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
				MPCF.SetInMsg(in_node);
				in_node.ProcStep = '1';
				in_node.AddString("TABLE_NAME", MPCF.Trim("@PMPP_DEFECT_TYPE"));

				string[] header = new string[] { "PMPP Defect Type Code", "Description" };
				string[] display = new string[] { "KEY_1", "DATA_1" };

				cdvDefectTypeU.Text = cdvDefectTypeU.Show(cdvDefectTypeU, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

				// Validation
				if (string.IsNullOrEmpty(cdvDefectTypeU.Text) == true)
				{
					return;
				}

				return;
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
				return;
			}
		}

        /// <summary>
        /// Include Res Id CheckBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRegisteredYn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
        
                if (chkRegisteredYn.Checked == true)
                {
                    registeredYn = true;
                }
                else
                {
                    registeredYn = false;
                }

                btnProcess.PerformClick();
            
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        /// <summary>
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
				// 20210225 locationData 리스트 삭제
				ViewClearUI(1);

                if (ViewAlertList() == false)
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

		private void ViewClearUI(int nType)
		{
			MPCF.ClearList(this.spdE10LocationDataList);

			ModuleIDLabel.Text = "";

			if(nType == 1)
			{
				soiTBModuleID.Text = "";
			}

			cdvDefectPositionU.Text = "";
			cdvDefectPositionU.Description = "";

			soiSolderingCondition.Text = "";
			soiSolderingCondition.Description = "";

			cdvDefectTypeU.Text = "";
			cdvDefectTypeU.Description = "";

			soiTextBox1.Text = "";
			soiTextBox2.Text = "";
		}
        
        #region Functions

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        /// 
        private bool ViewAlertList()
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_E0_TROUBLE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_E0_TROUBLE_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';

				in_node.ProcStep = '2';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                //in_node.AddString("FM_TYPE", FM_TYPE);

                if (dtpFrom.Value != null)
                {
                    DateTime dtpDateTimeOut = new DateTime();
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (soiLineCode != null && soiLineCode.Text != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(soiLineCode.Text));
                }
                else
                {
                    in_node.AddString("LINE_ID", "%");
                }

                if (soiSolderingCode != null && soiSolderingCode.Text != "")
                {
                    in_node.AddString("SOLDERING", MPCF.Trim(soiSolderingCode.Text));
                }
                else
                {
                    in_node.AddString("SOLDERING", "%");
                }



                if (soiDetectPositionCode != null && soiDetectPositionCode.Text != "")
                {
                    in_node.AddString("DEFECT_POSITION", MPCF.Trim(soiDetectPositionCode.Text));
                }
                else
                {
                    in_node.AddString("DEFECT_POSITION", "%");
                }



                if (soiFrameEQCode != null && soiFrameEQCode.Text != "")
                {
                    in_node.AddString("RES_ID", MPCF.Trim(soiFrameEQCode.Text));
                }
                else
                {
                    in_node.AddString("RES_ID", "%");
                }



                if (soiShiftCode != null && soiShiftCode.Text != "")
                {
                    in_node.AddString("WORK_SHIFT", MPCF.Trim(soiShiftCode.Text));
                }
                else
                {
                    in_node.AddString("WORK_SHIFT", "%");
                }


                if (soiDefectTypeCode != null && soiDefectTypeCode.Text != "")
                {
                    in_node.AddString("MACHINE_ISSUE_TYPE", MPCF.Trim(soiDefectTypeCode.Text));
                }
                else
                {
                    in_node.AddString("MACHINE_ISSUE_TYPE", "%");
                }

                in_node.AddBoolean("UPDATE_YN", registeredYn);
                

                if (MPCF.CallService("CWIP", "CWIP_View_Pmpp_Diode_Alert_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                MPCF.ClearList(this.spdE10TroubleList);
                spdE10TroubleList.Text = "Manage DIODE/PMPP Alert List";
             
                
                // Bind
                spdE10TroubleList.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.NO].Value = i;
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.COL_CHK].Value = "";
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.LINE].Value = out_node.GetList(0)[i].GetString("LINE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.MODULE_ID].Value = out_node.GetList(0)[i].GetString("MODULE_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.PMPP].Value = out_node.GetList(0)[i].GetString("PMPP");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.DIODE].Value = out_node.GetList(0)[i].GetString("DIODE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.INS_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("INS_TIME"), DATE_TIME_FORMAT.DATETIME);

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_DATE].Value = out_node.GetList(0)[i].GetString("WORK_DATE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_TIME].Value = out_node.GetList(0)[i].GetString("WORK_TIME");

                    //spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_DATE].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                    //spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("WORK_TIME"), DATE_TIME_FORMAT.TIME);
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_SHIFT].Value = out_node.GetList(0)[i].GetString("WORK_SHIFT");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.DEFECT_POSITION].Value = out_node.GetList(0)[i].GetString("DEFECT_POSITION");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.MACHINE_ISSUE_TYPE].Value = out_node.GetList(0)[i].GetString("MACHINE_ISSUE_TYPE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.OPERATOR].Value = out_node.GetList(0)[i].GetString("OPERATOR");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.MACHINE_TECHNICIAN].Value = out_node.GetList(0)[i].GetString("MACHINE_TECHNICIAN");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.SOLDERING].Value = out_node.GetList(0)[i].GetString("CMF_1");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_USER_ID].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_USER_ID].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("INS_TIME")) == "")
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.INS_TIME].Value = "";
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.INS_TIME].Tag = out_node.GetList(0)[i].GetString("INS_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.INS_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("INS_TIME"), DATE_TIME_FORMAT.DATETIME);
                    }
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("WORK_DATE")) == "")
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_DATE].Value = "";
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_DATE].Tag = out_node.GetList(0)[i].GetString("WORK_DATE");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_DATE].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                    }
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("WORK_TIME")) == "")
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_TIME].Value = "";
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_TIME].Tag = out_node.GetList(0)[i].GetString("WORK_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("WORK_TIME"), DATE_TIME_FORMAT.TIME);
                    }
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME")) == "")
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Value = "";
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Tag = out_node.GetList(0)[i].GetString("CREATE_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                    }

                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME")) == "")
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Value = "";
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Tag = out_node.GetList(0)[i].GetString("UPDATE_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                    }
                }
                // Fit Column Hedaer
                MPCF.FitColumnHeader(spdE10TroubleList);

                lblSumQty_W.Text = spdE10TroubleList.ActiveSheet.RowCount.ToString();
                
                for (int i = 0; i < spdE10TroubleList.Sheets[0].Rows.Count; i++)
                {
                    spdE10TroubleList.ActiveSheet.Cells[i, 1].Value = false;
                }
               
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion



		#region Functions

		/// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        /// 
        private bool ViewLocationDataList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_E0_TROUBLE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_E0_TROUBLE_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                //in_node.AddString("FM_TYPE", FM_TYPE);
				
				// select row
				string moduleID = "";
				int nRowSelect = spdE10TroubleList.Sheets[0].GetSelection(0).Row;

				for (int i = 0; i < spdE10TroubleList.Sheets[0].Rows.Count; i++)
				{
					if (i == nRowSelect)
					{
						moduleID = MPCF.Trim(spdE10TroubleList.Sheets[0].Cells[i, (int)FM_LIST.MODULE_ID].Text);
					}
				}

				if (moduleID == "")
				{
					MPCF.ShowMessage(MPCF.GetMessage(71), MSG_LEVEL.INFO, false);
					return false;
				}
				
				in_node.AddString("LOT_ID", MPCF.Trim(moduleID));
				
                if (dtpFrom.Value != null)
                {
                    DateTime dtpDateTimeOut = new DateTime();
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

				ModuleIDLabel.Text = moduleID;

                if (soiLineCode != null && soiLineCode.Text != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(soiLineCode.Text));
                }
                else
                {
                    in_node.AddString("LINE_ID", "%");
                }

                if (soiSolderingCode != null && soiSolderingCode.Text != "")
                {
                    in_node.AddString("SOLDERING", MPCF.Trim(soiSolderingCode.Text));
                }
                else
                {
                    in_node.AddString("SOLDERING", "%");
                }

				in_node.AddString("DEFECT_POSITION", "%");

                if (soiFrameEQCode != null && soiFrameEQCode.Text != "")
                {
                    in_node.AddString("RES_ID", MPCF.Trim(soiFrameEQCode.Text));
                }
                else
                {
                    in_node.AddString("RES_ID", "%");
                }

                if (soiShiftCode != null && soiShiftCode.Text != "")
                {
                    in_node.AddString("WORK_SHIFT", MPCF.Trim(soiShiftCode.Text));
                }
                else
                {
                    in_node.AddString("WORK_SHIFT", "%");
                }

                if (soiDefectTypeCode != null && soiDefectTypeCode.Text != "")
                {
                    in_node.AddString("MACHINE_ISSUE_TYPE", MPCF.Trim(soiDefectTypeCode.Text));
                }
                else
                {
                    in_node.AddString("MACHINE_ISSUE_TYPE", "%");
                }

                in_node.AddBoolean("UPDATE_YN", registeredYn);
                
                if (MPCF.CallService("CWIP", "CWIP_View_Pmpp_Diode_Alert_List", in_node, ref out_node) == false)
                {
                    return false;
                }


                // Clear
				MPCF.ClearList(this.spdE10LocationDataList);
				spdE10LocationDataList.Text = "Location Data";

				// Bind
				spdE10LocationDataList.ActiveSheet.RowCount = out_node.GetList(0).Count;
				for (int i = 0, nIndex = 0; i < out_node.GetList(0).Count; i++)
				{
					string defectPosition = out_node.GetList(0)[i].GetString("DEFECT_POSITION");

                    //DEFECT POSITION
                    TRSNode gcm_in_node = new TRSNode("VIEW_GCM_DATA_IN");
                    TRSNode gcm_out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                    TRSNode out_list;
                    MPCF.SetInMsg(gcm_in_node);

                    gcm_in_node.ProcStep = '3';
                    gcm_in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_DETECT_POSITION));
                    
                    Boolean dfFlag = false;

                    int j;
                    if (MPCF.CallService("CBAS", "CBAS_View_Data_List", gcm_in_node, ref gcm_out_node) == true)
                    {
                        for (j = 0; j < gcm_out_node.GetList(0).Count; j++)
                        {
                            out_list = gcm_out_node.GetList(0)[j];
                            String KEY_1 = out_list.GetString("KEY_1");

                            if (defectPosition == KEY_1)
                            {
                                dfFlag = true;
                            }
                        }
                    }

                    if (dfFlag)
					{
						spdE10LocationDataList.ActiveSheet.Cells[i, (int)0].Value = i;
						spdE10LocationDataList.ActiveSheet.Cells[i, (int)1].Value = out_node.GetList(0)[i].GetString("MODULE_ID");
						spdE10LocationDataList.ActiveSheet.Cells[i, (int)2].Value = out_node.GetList(0)[i].GetString("DEFECT_POSITION");
						spdE10LocationDataList.ActiveSheet.Cells[i, (int)3].Tag = out_node.GetList(0)[i].GetString("CMF_1");
						spdE10LocationDataList.ActiveSheet.Cells[i, (int)3].Value = out_node.GetList(0)[i].GetString("CMF_1_DATA");
						spdE10LocationDataList.ActiveSheet.Cells[i, (int)4].Tag = out_node.GetList(0)[i].GetString("DEFECT_TYPE");
						spdE10LocationDataList.ActiveSheet.Cells[i, (int)4].Value = out_node.GetList(0)[i].GetString("MACHINE_ISSUE_TYPE");

						spdE10LocationDataList.ActiveSheet.Cells[i, (int)5].Value = out_node.GetList(0)[i].GetString("OPERATOR");
						spdE10LocationDataList.ActiveSheet.Cells[i, (int)6].Value = out_node.GetList(0)[i].GetString("MACHINE_TECHNICIAN");

						spdE10LocationDataList.ActiveSheet.Cells[i, (int)7].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");

						if (MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME")) == "")
						{
							spdE10LocationDataList.ActiveSheet.Cells[i, (int)8].Value = "";
						}
						else
						{
							spdE10LocationDataList.ActiveSheet.Cells[i, (int)8].Tag = out_node.GetList(0)[i].GetString("CREATE_TIME");
							spdE10LocationDataList.ActiveSheet.Cells[i, (int)8].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"), DATE_TIME_FORMAT.DATETIME);
						}

						if (MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME")) == "")
						{
							spdE10LocationDataList.ActiveSheet.Cells[i, (int)9].Value = "";
						}
						else
						{
							spdE10LocationDataList.ActiveSheet.Cells[i, (int)9].Tag = out_node.GetList(0)[i].GetString("UPDATE_TIME");
							spdE10LocationDataList.ActiveSheet.Cells[i, (int)9].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME);
						}

						nIndex++;
					}
				}
                // Fit Column Hedaer
                MPCF.FitColumnHeader(spdE10LocationDataList);
				               
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        
        //udpate
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvDefectPositionU, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvDefectTypeU, false) == false)
                {
                    return;
                }

                if (spdE10TroubleList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(71), MSG_LEVEL.INFO, false);
                    return;
                }

                if (Update_Pmpp_Diode_List() == false)
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

        private bool Update_Pmpp_Diode_List()
        {
            TRSNode in_node = new TRSNode("UPDATE_DATA_IN");
            TRSNode out_node = new TRSNode("UPDATE_DATA_OUT");
            TRSNode data_list;
            int i;
            try
            {
				in_node.ProcStep = '2';

                MPCF.SetInMsg(in_node);
               
                Boolean isList = false;

				int nRowSelect = spdE10TroubleList.Sheets[0].GetSelection(0).Row;
                for (i = 0; i < spdE10TroubleList.Sheets[0].Rows.Count; i++)
                {
                    //if (spdE10TroubleList.Sheets[0].Cells[i, 1].Value == null || (bool)spdE10TroubleList.Sheets[0].Cells[i, 1].Value == false)

					if(nRowSelect == i)
                    {
                        data_list = in_node.AddNode("TRAN_LIST");

                        data_list.AddString("FACTORY", MPGV.gsFactory);
                        data_list.AddString("MODULE_ID", MPCF.Trim(spdE10TroubleList.Sheets[0].Cells[i, (int)FM_LIST.MODULE_ID].Text));
                        data_list.AddString("DEFECT_POSITION", MPCF.Trim(cdvDefectPositionU.Text));
                        data_list.AddString("MACHINE_ISSUE_TYPE", MPCF.Trim(cdvDefectTypeU.Text));
                        data_list.AddString("OPERATOR", MPCF.Trim(soiTextBox1.Text));
                        data_list.AddString("MACHINE_TECHNICIAN", MPCF.Trim(soiTextBox2.Text));
                        data_list.AddString("SOLDERING_TYPE", MPCF.Trim(soiSolderingCondition.Text));
						data_list.AddString("WORK_DATE", MPCF.Trim(spdE10TroubleList.Sheets[0].Cells[i, (int)FM_LIST.WORK_DATE].Tag));
						
                        isList = true;
                    }
                }

                if (!isList)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(71), MSG_LEVEL.INFO, false);
                    return false;
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_Pmpp_Diode_Alert", in_node, ref out_node) == false)
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

        private void btnToExcelW_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pop = new SaveFileDialog();
                //pop.InitialDirectory = Application.StartupPath;
                pop.InitialDirectory = "c:\\";

                pop.FileName = MPCF.Trim("Manage_PMPP_DIDOE_Alert_List") + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdE10TroubleList.Sheets[0].Protect = false;
                    spdE10TroubleList.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdE10TroubleList.Sheets[0].Protect = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdE10TroubleList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
				if(e.Row > -1)
				{
					ViewClearUI(2);
					soiTBModuleID.Text = spdE10TroubleList.ActiveSheet.Cells[e.Row, (int)FM_LIST.MODULE_ID].Text;
				}

				
				//if (e.Column == 1)
				//{
				//    if (e.ColumnHeader)
				//    {
				//        Boolean bCheck = false;

				//        if (string.IsNullOrEmpty(spdE10TroubleList.ActiveSheet.ColumnHeader.Cells[0, 1].Text))
				//        {
				//            bCheck = true;
				//        }
				//        else if ((Boolean)spdE10TroubleList.ActiveSheet.ColumnHeader.Cells[0, 1].Value == false)
				//        {
				//            bCheck = true;
				//        }
				//        else // True
				//        {
				//            bCheck = false;
				//        }

				//        spdE10TroubleList.ActiveSheet.ColumnHeader.Cells[0, 1].Value = bCheck;

				//        for (int i = 0; i < spdE10TroubleList.Sheets[0].Rows.Count; i++)
				//        {
				//            spdE10TroubleList.ActiveSheet.Cells[i, 1].Value = bCheck;
				//        }
				//    }
				//    else
				//    {
				//        Boolean bCheck = false;
				//        /*
				//        if (string.IsNullOrEmpty(spdE10TroubleList.ActiveSheet.Cells[e.Row, 1].Text))
				//        {
				//            bCheck = true;
				//        }
				//        else if ((Boolean)spdE10TroubleList.ActiveSheet.Cells[e.Row, 1].Value == false)
				//        {
				//            bCheck = true;
				//        }
				//        else // True
				//        {
				//            bCheck = false;
				//        }
				//         * */

				//        if ((Boolean)spdE10TroubleList.ActiveSheet.Cells[e.Row, 1].Value == false)
				//        {
				//            bCheck = true;
				//        }
				//        else // True
				//        {
				//            bCheck = false;
				//        }
				//        //spdE10TroubleList.ActiveSheet.Cells[e.Row, 1].Value = bCheck;
				//        spdE10TroubleList.ActiveSheet.Cells[e.Row, 1].Value = bCheck;
				//    }

				//}
				
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
		}

		private void spdE10TroubleList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			try
			{
				ViewClearUI(2);

                if (ViewLocationDataList() == false)
				{
					return;
				}
                
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
		}

		private void spdE10LocationDataList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			try
			{
				if (SetLocationDataItem() == false)
				{
					return;
				}
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
		}


		private bool SetLocationDataItem()
		{
			try
			{
				// select row
				bool nFindSelect = false;
				string moduleID = "";
				int nRowSelect = spdE10LocationDataList.Sheets[0].GetSelection(0).Row;

				for (int i = 0; i < spdE10LocationDataList.Sheets[0].Rows.Count; i++)
				{
					if (i == nRowSelect)
					{
						nFindSelect = true;
						moduleID = MPCF.Trim(spdE10LocationDataList.Sheets[0].Cells[i, (int)0].Text);

						//spdE10LocationDataList.ActiveSheet.Cells[i, (int)1].Value = out_node.GetList(0)[i].GetString("MODULE_ID");
						//spdE10LocationDataList.ActiveSheet.Cells[i, (int)2].Value = out_node.GetList(0)[i].GetString("DEFECT_POSITION");
						//spdE10LocationDataList.ActiveSheet.Cells[i, (int)3].Tag = out_node.GetList(0)[i].GetString("CMF_1");
						//spdE10LocationDataList.ActiveSheet.Cells[i, (int)3].Value = out_node.GetList(0)[i].GetString("CMF_1_DATA");
						//spdE10LocationDataList.ActiveSheet.Cells[i, (int)4].Tag = out_node.GetList(0)[i].GetString("DEFECT_TYPE");
						//spdE10LocationDataList.ActiveSheet.Cells[i, (int)4].Value = out_node.GetList(0)[i].GetString("MACHINE_ISSUE_TYPE");
						//spdE10LocationDataList.ActiveSheet.Cells[i, (int)5].Value = out_node.GetList(0)[i].GetString("OPERATOR");
						//spdE10LocationDataList.ActiveSheet.Cells[i, (int)6].Value = out_node.GetList(0)[i].GetString("MACHINE_TECHNICIAN");
						//spdE10LocationDataList.ActiveSheet.Cells[i, (int)7].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
						cdvDefectPositionU.Text = (string)spdE10LocationDataList.Sheets[0].Cells[i, (int)2].Text;
						cdvDefectPositionU.Description = spdE10LocationDataList.Sheets[0].Cells[i, (int)2].Text;

						soiSolderingCondition.Text = (string)spdE10LocationDataList.Sheets[0].Cells[i, (int)3].Tag;
						soiSolderingCondition.Description = spdE10LocationDataList.Sheets[0].Cells[i, (int)3].Text;

						cdvDefectTypeU.Text = (string)spdE10LocationDataList.Sheets[0].Cells[i, (int)4].Tag;
						cdvDefectTypeU.Description = spdE10LocationDataList.Sheets[0].Cells[i, (int)4].Text;

						soiTextBox1.Text = spdE10LocationDataList.Sheets[0].Cells[i, (int)5].Text;
						soiTextBox2.Text = spdE10LocationDataList.Sheets[0].Cells[i, (int)6].Text;
					}
				}

				return nFindSelect;

			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
				return false;
			}
		}

    }
}




