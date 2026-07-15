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
    public partial class frmCWIPCellScrapManagementLb : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCWIPCellScrapManagementLb()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        int LB_DESIRED_DECIMAL_POINT = 2;

        public enum SCRAP_LIST
        {
            WORK_DATE = 0,
            LINE_ID,
            WORK_SHIFT,
            MAT_ID,
            MAT_DESC,
            LOSS_OPER,            
            OPER_DESC,
            RES_ID,
            RES_DESC,
            CAUSE,
            CAUSE_DESC,
            LOSS_LB,
            LOSS_COMMENT,
            CREATE_USER_ID,
            CREATE_TIME,
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
        private void frmCWIPCellScrapManagementLb_Load(object sender, EventArgs e)
        {
            // Init
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            //dtpFrom.Value = DateTime.Today.AddDays(-7);

            dtpScrap.Value = DateTime.Today;

            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void frmCWIPCellScrapManagementLb_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(cdvLineID);

                bIsShown = true;
            }
        }

        private void spdScrap_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // Clear
                MPCF.FieldClear(pnlScrapInfo, cdvScrapLineID);

                // Display Scrap Information
                cdvScrapLineID.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LINE_ID].Text;
                dtpScrap.Value = DateTime.Parse(spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.WORK_DATE].Text);
                cboShift.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.WORK_SHIFT].Text;
                cdvMatID.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.MAT_DESC].Text;

                if (spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_OPER].Text == HQGC.OPER_M2000 
                        && (spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.RES_ID].Text).Contains("TB"))
                {
                    cdvResTabber.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.RES_ID].Text;
                    txtQtyTabber.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_LB].Text;
                    txtCommentTabber.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_COMMENT].Text;
                }
                else if (spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_OPER].Text == HQGC.OPER_M2000 
                        && (spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.RES_ID].Text).Contains("SI"))
                {
                    cdvResString.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.RES_ID].Text;
                    txtQtyString.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_LB].Text;
                    txtCommentString.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_COMMENT].Text;
                }
                else if (spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_OPER].Text == HQGC.OPER_M2040)
                {
                    cdvResFrontEL.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.RES_ID].Text;
                    txtQtyFrontEL.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_LB].Text;
                    txtCommentFrontEL.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_COMMENT].Text;
                }

                else if (spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_OPER].Text == HQGC.OPER_T1000)
                {
                    txtQtyEquipment.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_LB].Text;
                    txtCommentEquipment.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_COMMENT].Text;
                }

                this.btnUpdate.Enabled = true;
                this.btnDelete.Enabled = true;
                this.btnProcess.Enabled = false;
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
                in_node.AddString("LINE_LOCATION", "E1");

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

 

        private void cdvScrapLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            DateTime dtpScrapDateTimeOut = new DateTime();

            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", "E1");

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvScrapLineID.Text = cdvScrapLineID.Show(cdvScrapLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Clear
                MPCF.FieldClear(pnlScrapInfo, cdvScrapLineID);

                cdvResTabber.Text = "US-E" + cdvScrapLineID.Text.Substring(4, 1) + "-TB-01";
                cdvResString.Text = "US-E" + cdvScrapLineID.Text.Substring(4, 1) + "-SI-01";
                cdvResFrontEL.Text = "US-E" + cdvScrapLineID.Text.Substring(4, 1) + "-FEL-01";

                // MatId 1개 인 경우 자동반영되도록
                TRSNode in_mat_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_MATERIAL_LIST_OUT");
                MPCF.SetInMsg(in_mat_node);
                in_mat_node.ProcStep = '1';

                bool bTrySuccess = DateTime.TryParse(dtpScrap.Value.ToString(), out dtpScrapDateTimeOut);
                if (bTrySuccess == true)
                {
                    in_mat_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    in_mat_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLineID.Text));
                    in_mat_node.AddString("OPER", "M2000");

                    if (MPCF.CallService("CWIP", "CWIP_View_Material_List_By_Production", in_mat_node, ref out_node) == true)
                    {
                        if (out_node.GetList(0).Count == 1)
                        {
                            TRSNode out_list = out_node.GetList(0)[0];
                            cdvMatID.Text = out_list.GetString("MAT_ID");
                            cdvMatID.Description = out_list.GetString("MAT_SHORT_DESC");
                        }
                    }
                }      

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvScrapShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                string[] header = new string[] { "Shift", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                //cdvScrapShift.Text = cdvScrapShift.Show(cdvScrapShift, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

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
                if (CheckCondition("MATERIAL") == false)
                    return;

                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                bool bTrySuccess = DateTime.TryParse(dtpScrap.Value.ToString(), out dtpScrapDateTimeOut);
                if (bTrySuccess == true)
                {
                    in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                }
                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLineID.Text));
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

        private void cdvResTabber_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                {
                    return;
                }

                /*
                if (MPCF.CheckValue(cdvScrapOper, false) == false)
                {
                    return;
                }
                */

                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLineID.Text));
                in_node.AddString("OPER", MPCF.Trim(HQGC.OPER_M2000)); // Tabber
                in_node.AddString("RES_ID", MPCF.Trim("%TB%")); // Tabber

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                cdvResTabber.Text = cdvResTabber.Show(cdvResTabber, "Resource ID", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvResString_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                {
                    return;
                }

                /*
                if (MPCF.CheckValue(cdvScrapOper, false) == false)
                {
                    return;
                }
                */

                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLineID.Text));
                in_node.AddString("OPER", MPCF.Trim(HQGC.OPER_M2000)); // Tabber
                in_node.AddString("RES_ID", MPCF.Trim("%SI%")); // String Inspection

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                cdvResString.Text = cdvResString.Show(cdvResString, "Resource ID", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvResFrontEL_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                {
                    return;
                }

                /*
                if (MPCF.CheckValue(cdvScrapOper, false) == false)
                {
                    return;
                }
                */

                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLineID.Text));
                in_node.AddString("OPER", MPCF.Trim(HQGC.OPER_M2040)); // FrontEnd EL

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                cdvResFrontEL.Text = cdvResFrontEL.Show(cdvResFrontEL, "Resource ID", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

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

                if (ViewScrapList() == false)
                {
                    //txtLotID.SelectAll();
                    //MPCF.SetFocus(txtLotID);
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
                if (CheckCondition("CREATE") == false)
                {
                    return;
                }

                if (UpdateScrap(MPGC.MP_STEP_CREATE) == false)
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

                if (UpdateScrap(MPGC.MP_STEP_UPDATE) == false)
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
                // Update
                if (CheckCondition("DELETE") == false)
                {
                    return;
                }

                if (UpdateScrap(MPGC.MP_STEP_DELETE) == false)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear
                MPCF.FieldClear(pnlScrapInfo);
                this.btnProcess.Enabled = true;
                this.btnDelete.Enabled = false;
                this.btnUpdate.Enabled = false;
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

                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpScrapList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdScrap.Sheets[0].Protect = false;
                    spdScrap.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdScrap.Sheets[0].Protect = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

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
                if (dtpScrap.Value != null)
                {
                    in_node.AddString("SYS_DATE", ((DateTime)(dtpScrap.Value)).ToString("yyyyMMdd"));
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

        private bool CheckCondition(string FuncName)
        {
            double check_lb;
            try
            {
                switch (FuncName)
                {
                    case "CREATE":

                        if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(dtpScrap, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvMatID, false) == false)
                        {
                            return false;
                        }

                        if (cdvMatID.Text.Length <= 0 )
                        {
                            MPCF.ShowMsgBox("Please Select material");
                            return false;

                        }

   
                        if (!validateNumbernDecimalPoint(txtQtyString.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            txtQtyString.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(txtQtyFrontEL.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            txtQtyFrontEL.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(txtQtyEquipment.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            txtQtyEquipment.Focus();
                            return false;
                        }


                        //check_lb = 0;
                        //check_lb = MPCF.ToDbl(txtQtyTabber.Text.Replace(",", ""));

                        //if (MPCF.CheckValue(cdvResTabber, false) == true && check_lb < 1.9)
                        //{
                        //    MPCF.ShowMsgBox(MPCF.GetMessage(567));
                        //    txtQtyTabber.Focus();
                        //    return false;
                        //}

                        check_lb = 0;
                        check_lb = MPCF.ToDbl(txtQtyString.Text.Replace(",", ""));
                        //IS-21-04-027	Cell Loss OI Update 개발
                        //if (MPCF.CheckValue(cdvResString, false) == true && check_lb < 1.9)
                        //if (MPCF.CheckValue(cdvResString, false) == true && check_lb < 2.68)//IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        if (MPCF.CheckValue(cdvResString, false) == true && check_lb < 2.80)  //2023-09-09 2.79 하한값 설정
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(583));
                            txtQtyString.Focus();
                            return false;
                        }

                        check_lb = 0;
                        check_lb = MPCF.ToDbl(txtQtyFrontEL.Text.Replace(",", ""));

                        //IS-21-04-027	Cell Loss OI Update 개발
                        //if (MPCF.CheckValue(cdvResFrontEL, false) == true && check_lb < 1.9)
                        //if (MPCF.CheckValue(cdvResFrontEL, false) == true && check_lb < 2.73)//IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        if (MPCF.CheckValue(cdvResFrontEL, false) == true && check_lb < 2.80)  //2023-09-09 2.79 하한값 설정
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(583));
                            txtQtyFrontEL.Focus();
                            return false;
                        }


                        check_lb = 0;
                        check_lb = MPCF.ToDbl(txtQtyEquipment.Text.Replace(",", ""));

                        if (txtQtyEquipment.Text.Replace(",", "").Equals(""))
                        {
                            //[2025-07-18] - The "Equipment Error" column will become optional depending on the updating column
                            //if (MPCF.ShowMsgBox("There is no value entered in Equipment Error field. Would you like to proceed?", MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) == System.Windows.Forms.DialogResult.No)
                            //{
                            //    txtQtyEquipment.Focus();
                            //    return false;
                            //}
                        }
                        //else if (check_lb < 2.58)
                        else if (check_lb < 2.80)  //2023-09-09 2.79 하한값 설정
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(583));
                            txtQtyEquipment.Focus();
                            return false;
                        }


                        break;

                    case "UPDATE":

                      

                        if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(dtpScrap, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvMatID, false) == false)
                        {
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(txtQtyString.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            txtQtyString.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(txtQtyFrontEL.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            txtQtyFrontEL.Focus();
                            return false;
                        }

                        if (!validateNumbernDecimalPoint(txtQtyEquipment.Text, LB_DESIRED_DECIMAL_POINT))
                        {
                            txtQtyEquipment.Focus();
                            return false;
                        }

                        check_lb = 0;
                        check_lb = MPCF.ToDbl(txtQtyString.Text.Replace(",", ""));

                        //IS-21-04-027	Cell Loss OI Update 개발
                        //if (MPCF.CheckValue(cdvResString, false) == true && check_lb < 1.9)
                        //if (MPCF.CheckValue(cdvResString, false) == true && check_lb < 2.68)//IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        if (MPCF.CheckValue(cdvResString, false) == true && check_lb < 2.80)  //2023-09-09 2.79 하한값 설정
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(583));
                            txtQtyString.Focus();
                            return false;
                        }

                        check_lb = 0;
                        check_lb = MPCF.ToDbl(txtQtyFrontEL.Text.Replace(",", ""));

                        //IS-21-04-027	Cell Loss OI Update 개발
                        //if (MPCF.CheckValue(cdvResFrontEL, false) == true && check_lb < 1.9)
                        //if (MPCF.CheckValue(cdvResFrontEL, false) == true && check_lb < 2.73)//IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        if (MPCF.CheckValue(cdvResFrontEL, false) == true && check_lb < 2.80)  //2023-09-09 2.79 하한값 설정
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(583));
                            txtQtyFrontEL.Focus();
                            return false;
                        }


                        check_lb = 0;
                        check_lb = MPCF.ToDbl(txtQtyEquipment.Text.Replace(",", ""));

                        //IS-21-04-027	Cell Loss OI Update 개발
                        //if (check_lb < 2 && check_lb > 0)
                        //if (check_lb < 2.58)//IS-21-08-023	[프로그램변경]MES OI Client 수정 개발 - Cell Scrap Management
                        //if (check_lb < 2.80)  //2023-09-09 2.79 하한값 설정
                        //{
                        //    MPCF.ShowMsgBox(MPCF.GetMessage(583));
                        //    txtQtyEquipment.Focus();
                        //    return false;
                        //}

                        break;

                    case "DELETE":

                        if (spdScrap.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(546));
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(dtpScrap, false) == false)
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

        private bool ViewScrapList()
        {
            try
            {
                int i;
                DateTime dtpFromDateTimeOut = new DateTime();
                DateTime dtpToDateTimeOut = new DateTime();

                MPCF.ClearList(spdScrap);

                TRSNode in_node = new TRSNode("VIEW_SCRAP_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_SCRAP_LIST_OUT");
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

                if (MPCF.CallService("CWIP", "CWIP_View_Scrap_List_Lb", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdScrap.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdScrap.ActiveSheet.RowCount++;

                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LINE_ID].Value = out_list.GetString("CM_KEY_1");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.WORK_SHIFT].Value = out_list.GetString("CM_KEY_2");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.MAT_ID].Value = out_list.GetString("MAT_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.MAT_DESC].Value = out_list.GetString("MAT_SHORT_DESC");

                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LOSS_OPER].Value = out_list.GetString("LOSS_OPER");

                    if (out_list.GetString("LOSS_OPER") == HQGC.OPER_T1000)
                    {
                        spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.OPER_DESC].Text = HQGC.OPER_T1000_DESC;
                    }
                    else
                    {
                        spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.OPER_DESC].Value = out_list.GetString("OPER_DESC");
                    }

                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.RES_ID].Value = out_list.GetString("RES_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.RES_DESC].Value = out_list.GetString("RES_DESC");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.CAUSE].Value = out_list.GetString("CM_KEY_3");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.CAUSE_DESC].Value = out_list.GetString("CAUSE_DESC");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LOSS_LB].Value = out_list.GetString("LOSS_LB");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.WORK_DATE].Value = MPCF.MakeDateFormat(out_list.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LOSS_COMMENT].Value = out_list.GetString("LOSS_COMMENT");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.CREATE_USER_ID].Value = out_list.GetString("CREATE_USER_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(out_list.GetString("CREATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.UPDATE_USER_ID].Value = out_list.GetString("UPDATE_USER_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(out_list.GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                }

                MPCF.FitColumnHeader(spdScrap);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool UpdateScrap(char ProcStep)
        {
            try
            {
                string check_update;
                check_update = "";
                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_SCRAP_IN");
                TRSNode out_node = new TRSNode("UPDATE_SCRAP_OUT");
                TRSNode scrap_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLineID.Text));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));

                // Scrap Date
                if (dtpScrap.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpScrap.Value.ToString(), out dtpScrapDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (ProcStep == MPGC.MP_STEP_CREATE)
                {
                   
                    // 2. Tabber

                    //if (txtQtyTabber.Text != "" && MPCF.CheckValue(cdvResTabber, false) == false)
                    //{
                    //    MPCF.ShowMsgBox("Please Selected Equipment");
                    //    cdvResTabber.Focus();
                    //    return false;
                    //}

                    //if (MPCF.CheckValue(cdvResTabber, false) != false)
                    //{
                    //    if (txtQtyTabber.Text != "")
                    //    {
                    //        scrap_list = in_node.AddNode("TRAN_LIST");
                    //        scrap_list.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                    //        scrap_list.AddString("LOSS_OPER", MPCF.Trim(HQGC.OPER_M2000));
                    //        scrap_list.AddString("RES_ID", MPCF.Trim(cdvResTabber.Text));
                    //        scrap_list.AddString("CAUSE", MPCF.Trim("C001"));
                    //        scrap_list.AddString("LOSS_LB", MPCF.Trim(txtQtyTabber.Text));
                    //        scrap_list.AddString("LOSS_COMMENT", MPCF.Trim(txtCommentTabber.Text));
                    //        check_update = "X";
                    //    }
                    //}

                    // 3. String

                    if (txtQtyString.Text != "" && MPCF.CheckValue(cdvResString, false) == false)
                    {
                        MPCF.ShowMsgBox("Please Selected Equipment");
                        cdvResString.Focus();
                        return false;
                    }

                    if (MPCF.CheckValue(cdvResString, false) != false)
                    {
                        if (txtQtyString.Text != "")
                        {
                            scrap_list = in_node.AddNode("TRAN_LIST");
                            scrap_list.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                            scrap_list.AddString("LOSS_OPER", MPCF.Trim(HQGC.OPER_M2000));
                            scrap_list.AddString("RES_ID", MPCF.Trim(cdvResString.Text));
                            scrap_list.AddString("CAUSE", MPCF.Trim("C001"));
                            scrap_list.AddString("LOSS_LB", MPCF.Trim(txtQtyString.Text));
                            scrap_list.AddString("LOSS_COMMENT", MPCF.Trim(txtCommentString.Text));
                            //IS-21-04-027	Cell Loss OI Update 개발
                            scrap_list.AddString("LOSS_LB_CHECK_NEW", 'Y');
                            scrap_list.AddString("BOX_WEIGHT", "2.80");// 2023-09-09 신규추가(이글1,2상이하여 신규 컬럼 추가하여 box무게저장)
                            check_update = "X";
                        }
                    } 

                    // 4. FrontEnd EL

                    if (cdvResFrontEL.Text != "" && MPCF.CheckValue(cdvResFrontEL, false) == false)
                    {
                        MPCF.ShowMsgBox("Please Selected Equipment");
                        cdvResString.Focus();
                        return false;
                    }

                    if (MPCF.CheckValue(cdvResFrontEL, false) != false)
                    {
                        if (cdvResFrontEL.Text != "")
                        {
                            scrap_list = in_node.AddNode("TRAN_LIST");
                            scrap_list.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                            scrap_list.AddString("LOSS_OPER", MPCF.Trim(HQGC.OPER_M2040));
                            scrap_list.AddString("RES_ID", MPCF.Trim(cdvResFrontEL.Text));
                            scrap_list.AddString("CAUSE", MPCF.Trim("C001"));
                            scrap_list.AddString("LOSS_LB", MPCF.Trim(txtQtyFrontEL.Text));
                            scrap_list.AddString("LOSS_COMMENT", MPCF.Trim(txtCommentFrontEL.Text));
                            //IS-21-04-027	Cell Loss OI Update 개발
                            scrap_list.AddString("LOSS_LB_CHECK_NEW", 'Y');
                            scrap_list.AddString("BOX_WEIGHT", "2.80");// 2023-09-09 신규추가(이글1,2상이하여 신규 컬럼 추가하여 box무게저장)
                            check_update = "X";
                        }
                    }

                    // 5. Equipment Errors
                    if (txtQtyEquipment.Text != "0" && txtQtyEquipment.Text != "")
                    {
                        scrap_list = in_node.AddNode("TRAN_LIST");
                        scrap_list.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                        scrap_list.AddString("LOSS_OPER", MPCF.Trim(HQGC.OPER_T1000));
                        scrap_list.AddString("CAUSE", MPCF.Trim("C001"));
                        scrap_list.AddString("LOSS_LB", MPCF.Trim(txtQtyEquipment.Text));
                        scrap_list.AddString("LOSS_COMMENT", MPCF.Trim(txtCommentEquipment.Text));
                        //IS-21-04-027	Cell Loss OI Update 개발
                        scrap_list.AddString("LOSS_LB_CHECK_NEW", 'Y');
                        scrap_list.AddString("BOX_WEIGHT", "2.80");// 2023-09-09 신규추가(이글1,2상이하여 신규 컬럼 추가하여 box무게저장)
                        check_update = "X";
                  
                    }

                    if (check_update != "X")
                    {
                        MPCF.ShowMsgBox("Please Enter LB");
                        return false;
                    }

                }
                else if (ProcStep == MPGC.MP_STEP_UPDATE || ProcStep == MPGC.MP_STEP_DELETE)
                {
                    scrap_list = in_node.AddNode("TRAN_LIST");
                    scrap_list.AddString("LOSS_OPER", spdScrap.Sheets[0].Cells[spdScrap.Sheets[0].ActiveRowIndex, (int)SCRAP_LIST.LOSS_OPER].Text);
                    scrap_list.AddString("RES_ID", spdScrap.Sheets[0].Cells[spdScrap.Sheets[0].ActiveRowIndex, (int)SCRAP_LIST.RES_ID].Text);
                    scrap_list.AddString("MAT_ID", spdScrap.Sheets[0].Cells[spdScrap.Sheets[0].ActiveRowIndex, (int)SCRAP_LIST.MAT_ID].Text);                    

                     if (spdScrap.Sheets[0].Cells[spdScrap.Sheets[0].ActiveRowIndex, (int)SCRAP_LIST.LOSS_OPER].Text == HQGC.OPER_M2000
                            && (spdScrap.Sheets[0].Cells[spdScrap.Sheets[0].ActiveRowIndex, (int)SCRAP_LIST.RES_ID].Text).Contains("TB"))
                    {
                        //scrap_list.AddString("CAUSE", MPCF.Trim("C001"));
                        //scrap_list.AddString("LOSS_LB", MPCF.Trim(txtQtyTabber.Text));
                        //scrap_list.AddString("LOSS_COMMENT", MPCF.Trim(txtCommentTabber.Text));
                    }
                    else if (spdScrap.Sheets[0].Cells[spdScrap.Sheets[0].ActiveRowIndex, (int)SCRAP_LIST.LOSS_OPER].Text == HQGC.OPER_M2000
                            && (spdScrap.Sheets[0].Cells[spdScrap.Sheets[0].ActiveRowIndex, (int)SCRAP_LIST.RES_ID].Text).Contains("SI"))
                    {
                        scrap_list.AddString("CAUSE", MPCF.Trim("C001"));
                        scrap_list.AddString("LOSS_LB", MPCF.Trim(txtQtyString.Text));
                        scrap_list.AddString("LOSS_COMMENT", MPCF.Trim(txtCommentString.Text));
                        //IS-21-04-027	Cell Loss OI Update 개발
                        scrap_list.AddString("LOSS_LB_CHECK_NEW", 'Y');
                    }
                    else if (spdScrap.Sheets[0].Cells[spdScrap.Sheets[0].ActiveRowIndex, (int)SCRAP_LIST.LOSS_OPER].Text == HQGC.OPER_M2040)
                    {
                        scrap_list.AddString("CAUSE", MPCF.Trim("C001"));
                        scrap_list.AddString("LOSS_LB", MPCF.Trim(txtQtyFrontEL.Text));
                        scrap_list.AddString("LOSS_COMMENT", MPCF.Trim(txtCommentFrontEL.Text));
                        //IS-21-04-027	Cell Loss OI Update 개발
                        scrap_list.AddString("LOSS_LB_CHECK_NEW", 'Y');
                    }

                     else if (spdScrap.Sheets[0].Cells[spdScrap.Sheets[0].ActiveRowIndex, (int)SCRAP_LIST.LOSS_OPER].Text == HQGC.OPER_T1000)
                     {
                         scrap_list.AddString("CAUSE", MPCF.Trim("C001"));
                         scrap_list.AddString("LOSS_LB", MPCF.Trim(txtQtyEquipment.Text));
                         scrap_list.AddString("LOSS_COMMENT", MPCF.Trim(txtCommentEquipment.Text));
                         //IS-21-04-027	Cell Loss OI Update 개발
                         scrap_list.AddString("LOSS_LB_CHECK_NEW", 'Y');
                     }


                }
                else
                {
                    return false;
                }


                if (MPCF.CallService("CWIP", "CWIP_Update_Scrap_List_Lb", in_node, ref out_node) == false)
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

        private void soiTableLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtQtyTabber_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (txtQtyTabber.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }


        private void txtQtyString_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (txtQtyString.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }


        private void txtQtyFrontEL_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (txtQtyFrontEL.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtQtyEquipment_KeyPress(object sender, KeyPressEventArgs e)        //숫자,"." 만 입력가능
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (txtQtyEquipment.Text.IndexOf('.') != -1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }


        private void txtQtyTabber_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(txtQtyTabber.Text, LB_DESIRED_DECIMAL_POINT);

        }

        private void txtQtyString_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(txtQtyString.Text, LB_DESIRED_DECIMAL_POINT);       
        }

        private void txtQtyFrontEL_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(txtQtyFrontEL.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void txtQtyEquipment_ValueChanged(object sender, EventArgs e)
        {
            validateNumbernDecimalPoint(txtQtyEquipment.Text, LB_DESIRED_DECIMAL_POINT);
        }

        private void cdvScrapLineID_ValueChanged(object sender, EventArgs e)
        {
            //MPCF.FieldClear(pnlScrapInfo, cdvMatID);
        }

        private void cdvScrapShift_ValueChanged(object sender, EventArgs e)
        {
            //cdvMatID.Code = "";
            //cdvMatID.Text = "";
            //MPCF.FieldClear(pnlScrapInfo, cdvMatID);


        }


        private void cdvScrapLineID_Load(object sender, EventArgs e)
        {

        }

        private void cdvScrapShift_Load(object sender, EventArgs e)
        {

        }

        private void cdvMatID_Load(object sender, EventArgs e)
        {

        }

        //숫자여부/Null 값 여부 검증
        private bool validateNumbernDecimalPoint( string cellValue, int desiredDecimalPoint)
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
            if (posPoint <= 0 || cellValue.Length - (posPoint + 1 ) != 2)
            {
                MPCF.ShowMessage("Please write two decimal places only (0.00 lbs).", MSG_LEVEL.ERROR, false);
                return false;
            }
            MPCF.ShowMessage("", MSG_LEVEL.NONE, false);
            return true;
        }

        private void dtpScrap_ValueChanged(object sender, EventArgs e)
        {
            getShiftList();
        }
    }
}
