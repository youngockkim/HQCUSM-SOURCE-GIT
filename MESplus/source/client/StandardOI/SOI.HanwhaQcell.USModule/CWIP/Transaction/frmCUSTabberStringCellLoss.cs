using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using SOI.WIP;
using Infragistics.Win.UltraWinGrid;

using System.Globalization;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSTabberStringCellLoss : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSTabberStringCellLoss()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum ENTRY_LIST
        {
            WORK_DATE = 0,
            CREATE_TIME,
            LINE_ID,
            WORK_SHIFT,
            TABBER,
            SIDE,
            TYPE_RECOVERY,
			COUNT, // IS-21-09-055 Tabber String Cell Loss OI Client - Update
            ADD_COMMENTS,
            CREATE_USER_ID,
            UPDATE_USER_ID,
            UPDATE_TIME
        }

        #endregion

        #region [Variable Definition]

        public PrintOptionModel printOption;

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSTabberStringCellLoss_Load(object sender, EventArgs e)
        {
            // Init
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            //dtpFrom.Value = DateTime.Today.AddDays(-7);

            dtpEntry.Value = DateTime.Today;

			// IS-21-09-055 Tabber String Cell Loss OI Client - Update
			cbxCount.SelectedIndex = 0;

            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void frmCUSTabberStringCellLoss_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(cdvLineID);

                bIsShown = true;
            }
        }

        private void spdEntry_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // Clear
                MPCF.FieldClear(pnlEntryInfo, cdvEntryLineID);

                // Display Entry Information
                //dtpEntry.Value = spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.WORK_DATE].Text;
				string workdata = "";
				workdata = spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.WORK_DATE].Text + "000000";
				dtpEntry.Value = DateTime.ParseExact(workdata, "yyyyMMddHHmmss", null);

                cdvEntryLineID.Text = spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.LINE_ID].Text;
                cdvEntryShift.Text = spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.WORK_SHIFT].Text;

                cdvEntryTabber.Text = (string)spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.TABBER].Tag;
                cdvEntrySide.Text = (string)spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.SIDE].Tag;
                cdvEntryTypeOfRecovery.Text = (string)spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.TYPE_RECOVERY].Tag;

				cdvEntryLineID.Description = (string)spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.LINE_ID].Tag;
				cdvEntryShift.Description = (string)spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.WORK_SHIFT].Tag;

                cdvEntryTabber.Description = spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.TABBER].Text;
                cdvEntrySide.Description = spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.SIDE].Text;
                cdvEntryTypeOfRecovery.Description = spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.TYPE_RECOVERY].Text;

				// IS-21-09-055 Tabber String Cell Loss OI Client - Update
				int nSelectedIndex = 0;
				string strSelectedIndex;
				strSelectedIndex = (string)spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.COUNT].Text;
				bool bTrySuccess = int.TryParse(strSelectedIndex, out nSelectedIndex);
				if (bTrySuccess != true || nSelectedIndex < 1)
				{
					MPCF.ShowMessage("Old Info Count Error, Please Input Count", MSG_LEVEL.INFO, false);
					nSelectedIndex = 0;
				}
				cbxCount.SelectedIndex = nSelectedIndex - 1;
				
				
                txtEntryAddComments.Text = spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.ADD_COMMENTS].Text;
                //txtEntryTime.Text = spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.CREATE_TIME].Text;
				txtEntryTime.Text = (string)spdEntry.Sheets[0].Cells[e.Row, (int)ENTRY_LIST.CREATE_TIME].Tag; // org db time data
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
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

        private void cdvEntryLineID_CodeViewButtonClick(object sender, EventArgs e)
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

                cdvEntryLineID.Text = cdvEntryLineID.Show(cdvEntryLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvEntryShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                string[] header = new string[] { "Shift", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvEntryShift.Text = cdvEntryShift.Show(cdvEntryShift, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvEntryTabber_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@TABBER");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvEntryTabber.Text = cdvEntryTabber.Show(cdvEntryTabber, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvEntrySide_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME","@TABBER_SIDE");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvEntrySide.Text = cdvEntrySide.Show(cdvEntrySide, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvEntryTypeOfRecovery_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@TABBER_RECOV_TYPE");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvEntryTypeOfRecovery.Text = cdvEntryTypeOfRecovery.Show(cdvEntryTypeOfRecovery, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

       

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                /*
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvShift, false) == false)
                {
                    return;
                }
                */

                if (ViewEntryList() == false)
                {
                    //txtLotID.SelectAll();
                    //MPCF.SetFocus(txtLotID);
                    return;
                }

				// Input Data Clear
				ClearData();

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
                // Update
                if (CheckCondition("CREATE") == false)
                {
                    return;
                }

                if (UpdateEntry(MPGC.MP_STEP_CREATE) == false)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Update
                if (CheckCondition("UPDATE") == false)
                {
                    return;
                }

                if (UpdateEntry(MPGC.MP_STEP_UPDATE) == false)
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
                // Delete
                if (CheckCondition("DELETE") == false)
                {
                    return;
                }

                if (MPCF.ShowMsgBox(MPCF.GetMessage(541), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (UpdateEntry(MPGC.MP_STEP_DELETE) == false)
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
        
        private void btnToExcelModules_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pop = new SaveFileDialog();
                //pop.InitialDirectory = Application.StartupPath;
                pop.InitialDirectory = "c:\\";

                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpEntryList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdEntry.Sheets[0].Protect = false;
                    spdEntry.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdEntry.Sheets[0].Protect = true;
                }
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
                    case "CREATE":

                        if (MPCF.CheckValue(dtpEntry, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryShift, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryTabber, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntrySide, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryTypeOfRecovery, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "UPDATE":

                        if (spdEntry.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(546));
                            return false;
                        }

                        if (MPCF.CheckValue(dtpEntry, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryShift, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryTabber, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntrySide, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryTypeOfRecovery, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "DELETE":

                        if (spdEntry.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(546));
                            return false;
                        }

                        if (MPCF.CheckValue(dtpEntry, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEntryShift, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(dtpEntry, false) == false)
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

        private bool ViewEntryList()
        {
            try
            {
                int i;
                DateTime dtpFromDateTimeOut = new DateTime();
                DateTime dtpToDateTimeOut = new DateTime();

                MPCF.ClearList(spdEntry);

                TRSNode in_node = new TRSNode("VIEW_ENTRY_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ENTRY_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (dtpTo.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpToDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TO_DATE", dtpToDateTimeOut.ToString("yyyyMMdd"));
                    }
                }


                // Line ID
                if (string.IsNullOrEmpty(MPCF.Trim(cdvLineID.Text)))
                {
                    in_node.AddString("LINE_ID", "%");
                }
                else
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                }

                // Work Shift
                if (string.IsNullOrEmpty(MPCF.Trim(cdvShift.Text)))
                {
                    in_node.AddString("WORK_SHIFT", "%");
                }
                else
                {
                    in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShift.Text));
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Entry_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdEntry.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdEntry.ActiveSheet.RowCount++;

                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.WORK_DATE].Value = out_list.GetString("WORK_DATE");
                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(out_list.GetString("CREATE_TIME"), DATE_TIME_FORMAT.DATETIME);
					spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.CREATE_TIME].Tag = out_list.GetString("CREATE_TIME");

					spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.LINE_ID].Value = out_list.GetString("LINE_ID");
                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.WORK_SHIFT].Value = out_list.GetString("WORK_SHIFT");
                    //spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.TABBER].Value = out_list.GetString("TABBER");
                    //spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.SIDE].Value = out_list.GetString("SIDE");
                    //spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.TYPE_RECOVERY].Value = out_list.GetString("TYPE_RECOVERY");
                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.TABBER].Value = out_list.GetString("TABBER_DESC");
                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.SIDE].Value = out_list.GetString("SIDE_DESC");
                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.TYPE_RECOVERY].Value = out_list.GetString("TYPE_RECOVERY_DESC");

					// IS-21-09-055 Tabber String Cell Loss OI Client - Update
					spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.COUNT].Value = out_list.GetString("CMF_1");

					// desc gcm data
					spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.LINE_ID].Tag = out_list.GetString("LINE_ID_DESC");
					spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.WORK_SHIFT].Tag = out_list.GetString("WORK_SHIFT_DESC");
					spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.TABBER].Tag = out_list.GetString("TABBER");
					spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.SIDE].Tag = out_list.GetString("SIDE");
					spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.TYPE_RECOVERY].Tag = out_list.GetString("TYPE_RECOVERY");

                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.ADD_COMMENTS].Value = out_list.GetString("ADD_COMMENTS");
                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.CREATE_USER_ID].Value = out_list.GetString("CREATE_USER_ID");
                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.UPDATE_USER_ID].Value = out_list.GetString("UPDATE_USER_ID");
                    spdEntry.ActiveSheet.Cells[i, (int)ENTRY_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(out_list.GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                }

                MPCF.FitColumnHeader(spdEntry);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

		private bool UpdateEntry(char ProcStep)
		{
			try
			{
				DateTime dtpEntryDateTimeOut = new DateTime();

				TRSNode in_node = new TRSNode("UPDATE_SCRAP_IN");
				TRSNode out_node = new TRSNode("UPDATE_SCRAP_OUT");

				MPCF.SetInMsg(in_node);
				in_node.ProcStep = ProcStep;

				in_node.AddString("LINE_ID", MPCF.Trim(cdvEntryLineID.Text));
				in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvEntryShift.Text));

				// Entry Date
				if (dtpEntry.Value != null)
				{
					bool bTrySuccess = DateTime.TryParse(dtpEntry.Value.ToString(), out dtpEntryDateTimeOut);
					if (bTrySuccess == true)
					{
						in_node.AddString("WORK_DATE", dtpEntryDateTimeOut.ToString("yyyyMMdd"));
					}
				}

				if (ProcStep == MPGC.MP_STEP_CREATE)
				{
					in_node.AddString("TABBER", MPCF.Trim(cdvEntryTabber.Text));
					in_node.AddString("SIDE", MPCF.Trim(cdvEntrySide.Text));
					in_node.AddString("TYPE_RECOVERY", MPCF.Trim(cdvEntryTypeOfRecovery.Text));

					// IS-21-09-055 Tabber String Cell Loss OI Client - Update
					in_node.AddString("CMF_1", MPCF.Trim(cbxCount.Text)); // COUNT

					in_node.AddString("ADD_COMMENTS", MPCF.Trim(txtEntryAddComments.Text));
					in_node.AddString("CREATE_TIME", MPCF.Trim("yyyyMMddHHmmss")); // 의미 없지만 형식 동일하게 처리 (server 단에서 현재 시간 사용)
				}
				else if (ProcStep == MPGC.MP_STEP_UPDATE || ProcStep == MPGC.MP_STEP_DELETE)
				{
					in_node.AddString("TABBER", MPCF.Trim(cdvEntryTabber.Text));
					in_node.AddString("SIDE", MPCF.Trim(cdvEntrySide.Text));
					in_node.AddString("TYPE_RECOVERY", MPCF.Trim(cdvEntryTypeOfRecovery.Text));
					in_node.AddString("ADD_COMMENTS", MPCF.Trim(txtEntryAddComments.Text));

					// IS-21-09-055 Tabber String Cell Loss OI Client - Update
					in_node.AddString("CMF_1", MPCF.Trim(cbxCount.Text)); // COUNT

					in_node.AddString("CREATE_TIME", MPCF.Trim(txtEntryTime.Text));
				}
				else
				{
					return false;
				}


				if (MPCF.CallService("CWIP", "CWIP_Update_Entry_List", in_node, ref out_node) == false)
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


		private void btnClear_Click(object sender, EventArgs e)
		{
			// Input Data Clear
			ClearData();
		}

		// Input Data Clear
		private void ClearData()
		{
			try
			{
				// Clear
				dtpEntry.Value = DateTime.Now;

				MPCF.FieldClear(cdvEntryLineID);
				MPCF.FieldClear(cdvEntryShift);
				MPCF.FieldClear(cdvEntryTabber);
				MPCF.FieldClear(cdvEntrySide);
				MPCF.FieldClear(cdvEntryTypeOfRecovery);
				MPCF.FieldClear(txtEntryAddComments);
				MPCF.FieldClear(txtEntryTime);

				// IS-21-09-055 Tabber String Cell Loss OI Client - Update
				cbxCount.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			}
		}

    }
}
