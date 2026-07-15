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
    public partial class frmCMDMManageMeasurementEVAtoGlass : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCMDMManageMeasurementEVAtoGlass()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum LOT_LIST
        {
            COL_CHK = 0,
            SAMPLING_DATE,
            TEST_DATE,
            CW,
            CW_BTN,
            LINE_ID,
            LINE_BTN,
            LINE_DESC,
            MACHINE_NO,
            MACHINE_BTN,
            POSITION,
            POSITION_BTN,
            MEASURE_TYPE,
            MEASURE_TYPE_BTN,
            TYPE_EVA_FRONT,
            TYPE_EVA_FRONT_BTN,
            GRN_NR_EVA_FRONT,
            GLASS_TYPE,
            GLASS_TYPE_BTN,
            GRN_NR_GLASS,
            REPEAT_MEASURE_NO,
            REPEAT_MEASURE_NO_BTN,
            POS_A,
            POS_B,
            POS_C,
            POS_D,
            POS_E,
            POS_F,
            POS_G,
            POS_H,
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
        private void frmCMDMManageMeasurementEVAtoGlass_Load(object sender, EventArgs e)
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

        private void frmCMDMManageMeasurementEVAtoGlass_Shown(object sender, EventArgs e)
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
                else if (e.Row >= 0 && e.Column == (int)LOT_LIST.LINE_BTN) // Line
                {
                    if (spdData.ActiveSheet.RowCount <= 0)
                        return;

                    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                    in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                    string[] header = new string[] { "Line Code", "Description" };
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    cdvLineID1.Text = cdvLineID1.Show(cdvLineID1, "Line", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                    if (!string.IsNullOrEmpty(cdvLineID1.Text))
                    {
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.LINE_ID].Text = cdvLineID1.Text;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.LINE_DESC].Text = cdvLineID1.Description;
                    }

                }
                else if (e.Row >= 0 && e.Column == (int)LOT_LIST.MACHINE_BTN) // Machine
                {
                    if (spdData.ActiveSheet.RowCount <= 0)
                        return;

                    TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                    TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                    // In Node Setup
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '2'; // Numerical Order
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_MACHINE));
                    in_node.AddString("KEY_1", "Machine");

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_2", "DATA_1" };

                    cdvMachine1.Text = cdvMachine1.Show(cdvMachine1, "Machine", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                    if (!string.IsNullOrEmpty(cdvMachine1.Text))
                    {
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.MACHINE_NO].Text = cdvMachine1.Text;
                    }
                }
                else if (e.Row >= 0 && e.Column == (int)LOT_LIST.POSITION_BTN) // Position
                {
                    if (spdData.ActiveSheet.RowCount <= 0)
                        return;

                    TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                    TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                    // In Node Setup
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '2'; // Numerical Order
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_POSITION));
                    in_node.AddString("KEY_1", "Position");

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_2", "DATA_1" };

                    cdvPosition1.Text = cdvPosition1.Show(cdvPosition1, "Position", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                    if (!string.IsNullOrEmpty(cdvPosition1.Text))
                    {
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.POSITION].Text = cdvPosition1.Text;
                    }
                }
                else if (e.Row >= 0 && e.Column == (int)LOT_LIST.MEASURE_TYPE_BTN) // Measure Type
                {
                    if (spdData.ActiveSheet.RowCount <= 0)
                        return;

                    TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                    TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                    // In Node Setup
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1'; // Alphabetical Order
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_MEASURE_TYPE));
                    in_node.AddString("KEY_1", "Measurement Type");

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_2", "DATA_1" };

                    cdvMeasureType1.Text = cdvMeasureType1.Show(cdvMeasureType1, "Measurement Type", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                    if (!string.IsNullOrEmpty(cdvMeasureType1.Text))
                    {
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.MEASURE_TYPE].Text = cdvMeasureType1.Text;
                    }
                }
                else if (e.Row >= 0 && e.Column == (int)LOT_LIST.TYPE_EVA_FRONT_BTN) // Type of EVA Frontside
                {
                    if (spdData.ActiveSheet.RowCount <= 0)
                        return;

                    TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                    TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                    // In Node Setup
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1'; // Alphabetical Order
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_TYPE_EVA_FRONT));
                    in_node.AddString("KEY_1", "Type of EVA Frontside");

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_2", "DATA_1" };

                    cdvTypeEVAFrontside1.Text = cdvTypeEVAFrontside1.Show(cdvTypeEVAFrontside1, "Type of EVA Frontside", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                    if (!string.IsNullOrEmpty(cdvTypeEVAFrontside1.Text))
                    {
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.TYPE_EVA_FRONT].Text = cdvTypeEVAFrontside1.Text;
                    }
                }
                else if (e.Row >= 0 && e.Column == (int)LOT_LIST.GLASS_TYPE_BTN) // Type of Glass
                {
                    if (spdData.ActiveSheet.RowCount <= 0)
                        return;

                    TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                    TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                    // In Node Setup
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1'; // Alphabetical Order
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_TYPE_GLASS));
                    in_node.AddString("KEY_1", "Type of Glass");

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_2", "DATA_1" };

                    cdvGlassType1.Text = cdvGlassType1.Show(cdvGlassType1, "Type of Glass", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                    if (!string.IsNullOrEmpty(cdvGlassType1.Text))
                    {
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.GLASS_TYPE].Text = cdvGlassType1.Text;
                    }
                }
                else if (e.Row >= 0 && e.Column == (int)LOT_LIST.REPEAT_MEASURE_NO_BTN) // Repeat Measurement No
                {
                    if (spdData.ActiveSheet.RowCount <= 0)
                        return;

                    TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                    TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                    // In Node Setup
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1'; // Alphabetical Order
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_RPT_MEASURE_NO));
                    in_node.AddString("KEY_1", "Repeat Measurement No");

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_2", "DATA_1" };

                    cdvRepeatMeasureNo1.Text = cdvRepeatMeasureNo1.Show(cdvRepeatMeasureNo1, "Repeat Measurement No", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                    if (!string.IsNullOrEmpty(cdvRepeatMeasureNo1.Text))
                    {
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.COL_CHK].Value = true;
                        spdData.ActiveSheet.Cells[e.Row, (int)LOT_LIST.REPEAT_MEASURE_NO].Text = cdvRepeatMeasureNo1.Text;
                    }
                }



            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
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

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
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

        private void cdvMachine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2'; // Numerical Order
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_MACHINE));
                in_node.AddString("KEY_1", "Machine");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_2", "DATA_1" };

                cdvMachine.Text = cdvMachine.Show(cdvMachine, "Machine", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvPosition_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2'; // Numerical Order
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_POSITION));
                in_node.AddString("KEY_1", "Position");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_2", "DATA_1" };

                cdvPosition.Text = cdvPosition.Show(cdvPosition, "Position", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMeasureType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1'; // Alphabetical Order
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MD_MEASURE_TYPE));
                in_node.AddString("KEY_1", "Measurement Type");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_2", "DATA_1" };

                cdvMeasureType.Text = cdvMeasureType.Show(cdvMeasureType, "Measurement Type", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

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

                // LINE_ID
                if (string.IsNullOrEmpty(MPCF.Trim(cdvLineID.Text)))
                {
                    in_node.AddString("LINE_ID", "%");
                }
                else
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                }

                // MACHINE_NO
                if (string.IsNullOrEmpty(MPCF.Trim(cdvMachine.Text)))
                {
                    in_node.AddString("MACHINE_NO", "%");
                }
                else
                {
                    in_node.AddString("MACHINE_NO", MPCF.Trim(cdvMachine.Text));
                }

                // POSITION
                if (string.IsNullOrEmpty(MPCF.Trim(cdvPosition.Text)))
                {
                    in_node.AddString("POSITION", "%");
                }
                else
                {
                    in_node.AddString("POSITION", MPCF.Trim(cdvPosition.Text));
                }

                // MEASURE_TYPE
                if (string.IsNullOrEmpty(MPCF.Trim(cdvMeasureType.Text)))
                {
                    in_node.AddString("MEASURE_TYPE", "%");
                }
                else
                {
                    in_node.AddString("MEASURE_TYPE", MPCF.Trim(cdvMeasureType.Text));
                }

                if (MPCF.CallService("CMDM", "CMDM_View_EVA_To_Glass_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdData.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    lot_list = out_node.GetList(0)[i];

                    spdData.ActiveSheet.RowCount++;

                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.COL_CHK].Value = false;
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.SAMPLING_DATE].Value = MPCF.MakeDateFormat(lot_list.GetString("SAMPLING_DATE"), DATE_TIME_FORMAT.DATE);
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.TEST_DATE].Value = MPCF.MakeDateFormat(lot_list.GetString("TEST_DATE"), DATE_TIME_FORMAT.DATE);
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.CW].Value = lot_list.GetString("CW");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.LINE_ID].Value = lot_list.GetString("LINE_ID");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.LINE_DESC].Value = lot_list.GetString("LINE_DESC");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.MACHINE_NO].Value = lot_list.GetString("MACHINE_NO");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POSITION].Value = lot_list.GetString("POSITION");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.MEASURE_TYPE].Value = lot_list.GetString("MEASURE_TYPE");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.TYPE_EVA_FRONT].Value = lot_list.GetString("TYPE_EVA_FRONT");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.GRN_NR_EVA_FRONT].Value = lot_list.GetString("GRN_NR_EVA_FRONT");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.GLASS_TYPE].Value = lot_list.GetString("GLASS_TYPE");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.GRN_NR_GLASS].Value = lot_list.GetString("GRN_NR_GLASS");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.REPEAT_MEASURE_NO].Value = lot_list.GetString("REPEAT_MEASURE_NO");

                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POS_A].Value = lot_list.GetDouble("POS_A");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POS_B].Value = lot_list.GetDouble("POS_B");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POS_C].Value = lot_list.GetDouble("POS_C");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POS_D].Value = lot_list.GetDouble("POS_D");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POS_E].Value = lot_list.GetDouble("POS_E");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POS_F].Value = lot_list.GetDouble("POS_F");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POS_G].Value = lot_list.GetDouble("POS_G");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.POS_H].Value = lot_list.GetDouble("POS_H");

                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.DATA_COMMENT].Value = lot_list.GetString("DATA_COMMENT");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.CREATE_USER_ID].Value = lot_list.GetString("CREATE_USER_ID");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("CREATE_TIME"));
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.UPDATE_USER_ID].Value = lot_list.GetString("UPDATE_USER_ID");
                    spdData.ActiveSheet.Cells[i, (int)LOT_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("UPDATE_TIME"));
                }

                //MPCF.FitColumnHeader(spdData, (int)LOT_LIST.SAMPLING_DATE, (int)LOT_LIST.POS_H);

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
                spdData.ActiveSheet.Cells[iRow, (int)LOT_LIST.SAMPLING_DATE].Value = MPCF.MakeDateFormat(dtpTodayOut.ToString("yyyyMMdd"), DATE_TIME_FORMAT.DATE);
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
                DateTime dtpXLinkTestDateOut = new DateTime();
                DateTime dtpLamiDateDateOut = new DateTime();

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

                        if (!string.IsNullOrEmpty(spdData.Sheets[0].Cells[i, (int)LOT_LIST.SAMPLING_DATE].Text))
                        {
                            bool bTrySuccess = DateTime.TryParse(spdData.Sheets[0].Cells[i, (int)LOT_LIST.SAMPLING_DATE].Value.ToString(), out dtpXLinkTestDateOut);
                            if (bTrySuccess == true)
                            {
                                data_list.AddString("SAMPLING_DATE", dtpXLinkTestDateOut.ToString("yyyyMMdd"));
                            }
                        }

                        if (!string.IsNullOrEmpty(spdData.Sheets[0].Cells[i, (int)LOT_LIST.TEST_DATE].Text))
                        {
                            bool bTrySuccess = DateTime.TryParse(spdData.Sheets[0].Cells[i, (int)LOT_LIST.TEST_DATE].Value.ToString(), out dtpLamiDateDateOut);
                            if (bTrySuccess == true)
                            {
                                data_list.AddString("TEST_DATE", dtpLamiDateDateOut.ToString("yyyyMMdd"));
                            }
                        }

                        data_list.AddString("LINE_ID", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.LINE_ID].Text));
                        data_list.AddString("MACHINE_NO", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.MACHINE_NO].Text));
                        data_list.AddString("POSITION", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POSITION].Text));
                        data_list.AddString("MEASURE_TYPE", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.MEASURE_TYPE].Text));

                        data_list.AddString("TYPE_EVA_FRONT", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.TYPE_EVA_FRONT].Text));
                        data_list.AddString("GRN_NR_EVA_FRONT", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.GRN_NR_EVA_FRONT].Text));
                        data_list.AddString("GLASS_TYPE", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.GLASS_TYPE].Text));
                        data_list.AddString("GRN_NR_GLASS", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.GRN_NR_GLASS].Text));
                        data_list.AddString("REPEAT_MEASURE_NO", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.REPEAT_MEASURE_NO].Text));

                        data_list.AddDouble("POS_A", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POS_A].Text));
                        data_list.AddDouble("POS_B", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POS_B].Text));
                        data_list.AddDouble("POS_C", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POS_C].Text));
                        data_list.AddDouble("POS_D", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POS_D].Text));
                        data_list.AddDouble("POS_E", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POS_E].Text));
                        data_list.AddDouble("POS_F", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POS_F].Text));
                        data_list.AddDouble("POS_G", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POS_G].Text));
                        data_list.AddDouble("POS_H", MPCF.ToDbl(spdData.Sheets[0].Cells[i, (int)LOT_LIST.POS_H].Text));

                        data_list.AddString("DATA_COMMENT", MPCF.Trim(spdData.Sheets[0].Cells[i, (int)LOT_LIST.DATA_COMMENT].Text));

                    }
                }

                if (MPCF.CallService("CMDM", "CMDM_Update_EVA_To_Glass_Data_List", in_node, ref out_node) == false)
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
