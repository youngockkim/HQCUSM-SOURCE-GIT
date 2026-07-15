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
    public partial class frmCMDMManageMeasurementReferenceSample : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCMDMManageMeasurementReferenceSample()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum LOT_LIST
        {
            COL_CHK = 0,
            TEST_DATE,
            CW,
            CW_BTN,
            X_LINK_NO,
            X_LINK_NO_BTN,
            POINT1_LXM,
            POINT1_GC,
            POINT2_LXM,
            POINT2_GC,
            DATA_COMMENT,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME
        }

        #endregion

        #region [Variable Definition]

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCMDMManageMeasurementReferenceSample_Load(object sender, EventArgs e)
        {
            // Init
            dtpTo.Value = DateTime.Today;
            dtpFrom.Value = DateTime.Today;
            //dtpFrom.Value = DateTime.Today.AddDays(-7);

            MPCF.ClearList(spdData);

            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void frmCMDMManageMeasurementReferenceSample_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpFrom);

                bIsShown = true;
            }
        }

        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.Column == 0)
                {
                    if (e.ColumnHeader)
                    {
                        Boolean bCheck = false;

                        if (string.IsNullOrEmpty(spdData.ActiveSheet.ColumnHeader.Cells[0, 0].Text))
                        {
                            bCheck = true;
                        }
                        else if ((Boolean)spdData.ActiveSheet.ColumnHeader.Cells[0, 0].Value == false)
                        {
                            bCheck = true;
                        }
                        else // True
                        {
                            bCheck = false;
                        }

                        spdData.ActiveSheet.ColumnHeader.Cells[0, 0].Value = bCheck;

                        for (int i = 0; i < spdData.Sheets[0].Rows.Count; i++)
                        {
                            spdData.ActiveSheet.Cells[i, 0].Value = bCheck;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Row >= 0 && e.Column == (int)LOT_LIST.CW_BTN) // CW
                {
                    if (spdData.ActiveSheet.RowCount <= 0)
                        return;

                    TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                    TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                    // In Node Setup
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '2'; // Numerical Order
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_CW));
                    in_node.AddString("KEY_1", "CW");

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_2", "DATA_1" };

                    cdvCW1.Text = cdvCW1.Show(cdvCW1, "CW", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                    if (!string.IsNullOrEmpty(cdvCW1.Text))
                    {
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.CW].Text = cdvCW1.Text;
                    }

                }
                else if (e.Row >= 0 && e.Column == (int)LOT_LIST.X_LINK_NO_BTN) // X-Link No
                {
                    if (spdData.ActiveSheet.RowCount <= 0)
                        return;

                    TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                    TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                    // In Node Setup
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '2'; // Numerical Order
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_X_LINK_NO));
                    in_node.AddString("KEY_1", "X-Link No");

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_2", "DATA_1" };

                    cdvXLinkNo1.Text = cdvXLinkNo1.Show(cdvXLinkNo1, "X-Link No", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                    if (!string.IsNullOrEmpty(cdvXLinkNo1.Text) == true)
                    {
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.X_LINK_NO].Text = cdvXLinkNo1.Text;

                    }

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCW_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2'; // Numerical Order
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_CW));
                in_node.AddString("KEY_1", "CW");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_2", "DATA_1" };

                cdvCW.Text = cdvCW.Show(cdvCW, "CW", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void cdvXLinkNo_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1'; // Alphabetical Order
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_X_LINK_NO));
                in_node.AddString("KEY_1", "X-Link No");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_2", "DATA_1" };

                cdvXLinkNo.Text = cdvXLinkNo.Show(cdvXLinkNo, "X-Link No", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

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
                if (ViewData() == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Create
                if (UpdateData(MPGC.MP_STEP_CREATE))
                {
                    btnView.PerformClick();
                    ClearColumnHeader();
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
                // Update
                if (UpdateData(MPGC.MP_STEP_UPDATE))
                {
                    btnView.PerformClick();
                    ClearColumnHeader();
                    return;
                }

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
                if (MPCF.ShowMsgBox(MPCF.GetMessage(545), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                // Delete
                if (UpdateData(MPGC.MP_STEP_DELETE))
                {
                    btnView.PerformClick();
                    ClearColumnHeader();
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddItems() == true)
                {
                    //MPCF.FitColumnHeader(spdData);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (RemoveItems() == true)
                {
                    //MPCF.FitColumnHeader(spdData);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnToExcelW_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pop = new SaveFileDialog();
                //pop.InitialDirectory = Application.StartupPath;
                pop.InitialDirectory = "c:\\";

                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdData.Sheets[0].Protect = false;
                    spdData.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdData.Sheets[0].Protect = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion


        #region Function

        private bool ViewData()
        {
            try
            {
                int i;
                DateTime dtpFromDateTimeOut = new DateTime();
                DateTime dtpToDateTimeOut = new DateTime();

                MPCF.ClearList(spdData);

                TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
                TRSNode lot_list;

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

                // CW
                if (string.IsNullOrEmpty(MPCF.Trim(cdvCW.Text)))
                {
                    in_node.AddString("CW", "%");
                }
                else
                {
                    in_node.AddString("CW", MPCF.Trim(cdvCW.Text));
                }

                // X_LINK_NO
                if (string.IsNullOrEmpty(MPCF.Trim(cdvXLinkNo.Text)))
                {
                    in_node.AddString("X_LINK_NO", "%");
                }
                else
                {
                    in_node.AddString("X_LINK_NO", MPCF.Trim(cdvXLinkNo.Text));
                }

                if (MPCF.CallService("CMDM", "CMDM_View_Reference_Sample_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdData.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    lot_list = out_node.GetList(0)[i];

                    spdData.ActiveSheet.RowCount++;

                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.COL_CHK].Value = false;
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.CW].Value = lot_list.GetString("CW");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.X_LINK_NO].Value = lot_list.GetString("X_LINK_NO");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.TEST_DATE].Value = MPCF.MakeDateFormat(lot_list.GetString("TEST_DATE"), DATE_TIME_FORMAT.DATE);

                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POINT1_LXM].Value = lot_list.GetDouble("POINT1_LXM");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POINT1_GC].Value = lot_list.GetDouble("POINT1_GC");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POINT2_LXM].Value = lot_list.GetDouble("POINT2_LXM");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POINT2_GC].Value = lot_list.GetDouble("POINT2_GC");

                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.DATA_COMMENT].Value = lot_list.GetString("DATA_COMMENT");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.CREATE_USER_ID].Value = lot_list.GetString("CREATE_USER_ID");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("CREATE_TIME"));
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.UPDATE_USER_ID].Value = lot_list.GetString("UPDATE_USER_ID");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("UPDATE_TIME"));
                }

                //MPCF.FitColumnHeader(spdData, (int)LOT_LIST.CW, (int)LOT_LIST.POINT2_GC);

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool AddItems()
        {
            try
            {
                DateTime dtpTodayOut = new DateTime();
                int iRow = 0;

                if (dtpTo.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(DateTime.Today.ToString(), out dtpTodayOut);
                }

                spdData.ActiveSheet.RowCount++;
                iRow = spdData.ActiveSheet.RowCount - 1;

                spdData.ActiveSheet.Cells[iRow, (int)LOT_LIST.COL_CHK].Value = true;
                spdData.ActiveSheet.Cells[iRow, (int)LOT_LIST.TEST_DATE].Value = MPCF.MakeDateFormat(dtpTodayOut.ToString("yyyyMMdd"), DATE_TIME_FORMAT.DATE);
                
                spdData.ActiveSheet.Rows[iRow].BackColor = Color.Yellow;
                spdData.ActiveSheet.Rows[iRow].ForeColor = Color.Black;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool RemoveItems()
        {
            try
            {
                for (int iRow = 0; iRow < spdData.ActiveSheet.RowCount; )
                {
                    if ((Boolean)spdData.ActiveSheet.Cells[iRow, (int)LOT_LIST.COL_CHK].Value == true)
                    {
                        spdData.ActiveSheet.RemoveRows(iRow, 1);
                        iRow = 0;
                    }
                    else
                    {
                        iRow++;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool UpdateData(char ProcStep)
        {
            try
            {
                DateTime dtpTestDateOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_DATA_IN");
                TRSNode out_node = new TRSNode("UPDATE_DATA_OUT");
                TRSNode data_list;
                int i;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (spdData.ActiveSheet.Cells[i, (int)LOT_LIST.COL_CHK].Value != null && Convert.ToBoolean(spdData.ActiveSheet.Cells[i, (int)LOT_LIST.COL_CHK].Value) == true)
                    {
                        data_list = in_node.AddNode("TRAN_LIST");

                        data_list.AddString("CW", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.CW].Text));
                        data_list.AddString("X_LINK_NO", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.X_LINK_NO].Text));

                        if (!string.IsNullOrEmpty(spdData.Sheets[0].Cells[i, (int)LOT_LIST.TEST_DATE].Text))
                        {
                            bool bTrySuccess = DateTime.TryParse(spdData.Sheets[0].Cells[i, (int)LOT_LIST.TEST_DATE].Value.ToString(), out dtpTestDateOut);
                            if (bTrySuccess == true)
                            {
                                data_list.AddString("TEST_DATE", dtpTestDateOut.ToString("yyyyMMdd"));
                            }
                        }

                        data_list.AddDouble("POINT1_LXM", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POINT1_LXM].Text));
                        data_list.AddDouble("POINT1_GC", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POINT1_GC].Text));
                        data_list.AddDouble("POINT2_LXM", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POINT2_LXM].Text));
                        data_list.AddDouble("POINT2_GC", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POINT2_GC].Text));

                        data_list.AddString("DATA_COMMENT", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.DATA_COMMENT].Text));

                    }
                }

                if (MPCF.CallService("CMDM", "CMDM_Update_Reference_Sample_Data_List", in_node, ref out_node) == false)
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

        private void ClearColumnHeader()
        {
            try
            {
                spdData.ActiveSheet.ColumnHeader.Cells[0, 0].Value = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion




    }
}
