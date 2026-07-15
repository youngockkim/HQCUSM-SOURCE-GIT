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
    public partial class frmCWIPTerminateMaterialv1 : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCWIPTerminateMaterialv1()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum MATETIRAL_LIST
        {
            ORDER_ID = 0,
            MATE_TYPE,
            MAT_DESC,
            MAT_ID,
            UNIT_ID,
            SEQ
        }

        public enum TERMINATED_LIST
        {
            TERMINATION_DT = 0,
            LINE_ID,
            WORK_SHIFT,
            MATE_TYPE,
            MAT_ID,
            MAT_DESC,
            UNIT_ID,
            QTY,
            REASON_CODE,
            TER_COMMENT,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME,
            HIST_SEQ,
            SEQ
        }

        #endregion

        #region [Variable Definition]

        private DateTime gSelectedMaterialDate;
        private string gSelectedMaterialDateString = string.Empty;

        private string gSelectedMaterialLineID = string.Empty;
        private string gSelectedMaterialLineIDDesc = string.Empty;
        private string gSelectedMaterialShift = string.Empty;
        private string gSelectedMaterialShiftDesc = string.Empty;
        private string gSelectedMaterialOrderID = string.Empty;
        private string gSelectedMaterialMatType = string.Empty;
        private string gSelectedMaterialMatID = string.Empty;
        private string gSelectedMaterialMatDesc = string.Empty;
        private string gSelectedMaterialUnitID = string.Empty;
        private string gSelectedMaterialQty = string.Empty;

        private string gSelectedMaterialReasonCode = string.Empty;
        private string gSelectedMaterialReasonCodeDesc = string.Empty;
        private string gSelectedMaterialComment = string.Empty;

        private string gSelectedMaterialSeq = string.Empty;
        private string gSelectedMaterialHistSeq = string.Empty;


        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCWIPTerminateMaterial_Load(object sender, EventArgs e)
        {
            // Init
            dtpTo.Value = DateTime.Today;
            dtpFrom.Value = DateTime.Today;

            dtpMaterialDate.Value = DateTime.Now;
            //수정[2024.09.27]
            soiCodeProductionOrder.Text = "000000000000";  //order id는 dummy값을 입력 (테이블 추가없이 사용하기 위하여 dummy화하여 사용 

            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdMaterial);
            MPCF.ClearList(spdTerminated);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void frmCWIPTerminateMaterial_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                //MPCF.SetFocus(dtpDate);
                MPCF.SetFocus(cdvLineID);

                bIsShown = true;
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

                string[] header = new string[] { "Line Code", "Description", "FACTORY" };
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_7" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                cdvMaterialLineID.Text = cdvLineID.Text;
                cdvMaterialLineID.Code = cdvLineID.Code;
                cdvMaterialLineID.Description = cdvLineID.Description;

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
                
                cdvMaterialShift.Text = soiShiftCode.Text;
                cdvMaterialShift.Code = soiShiftCode.Code;
                cdvMaterialShift.Description = soiShiftCode.Description;

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

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    cdvLineID.Focus();
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_MATERIAL_TERMINATE));
                in_node.AddString("KEY_1", cdvLineID.returnDatas[2]);
                //cdvLineID != null ?cdvLineID.returnDatas[2]
                string[] header = new string[] { "Code", "Description", "Mat. Type", "UNIT" };
                string[] display = new string[] { "KEY_2", "DATA_2", "DATA_1", "DATA_3" };

                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                if (cdvMaterial.Text.Length > 0)
                {
                    soiMaterialMatID.Text = cdvMaterial.Text;
                    soiMaterialMatDesc.Text = cdvMaterial.returnDatas[1];
                    soiMaterialMatType.Text = cdvMaterial.returnDatas[2];
                    soiMaterialUnitID.Text = cdvMaterial.returnDatas[3];
                }
                else
                {
                    soiMaterialMatID.Text = cdvMaterial.Text;
                    soiMaterialMatDesc.Text = "";
                    soiMaterialMatType.Text = "";
                    soiMaterialUnitID.Text = "";
                }

                // Validation
                if (string.IsNullOrEmpty(cdvMaterialReasonCode.Text) == true)
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

        private void cdvMaterialLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description", "FACTORY" };
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_7" };

                cdvMaterialLineID.Text = cdvMaterialLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvMaterialLineID.Text) == true)
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

        private void cdvMaterialShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                string[] header = new string[] { "Shift Code", "Description" };
                string[] display = new string[] { "SHIFT", "SHIFT1" };

                if (dtpMaterialDate.Value != null)
                {
                    in_node.AddString("SYS_DATE", ((DateTime)(dtpMaterialDate.Value)).ToString("yyyyMMdd"));
                }

                //cdvMaterialShift.Text = cdvMaterialShift.Show(soiShiftCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
                cdvMaterialShift.Text = cdvMaterialShift.Show(soiShiftCode, "Code List", "CBAS", "CBAS_View_Shift_List", in_node, "LIST", display, header, "SHIFT");
                
                // Validation
                if (string.IsNullOrEmpty(cdvMaterialShift.Text) == true)
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

        private void cdvMaterialReasonCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_KIND));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvMaterialReasonCode.Text = cdvMaterialReasonCode.Show(cdvMaterialReasonCode, "Material List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvMaterialReasonCode.Text) == true)
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

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvMaterial, false) == false)
                {
                    return;
                }

                // Initialize Spread
                MPCF.ClearList(spdMaterial);
                MPCF.ClearList(spdTerminated);

                // View Material List
                //if (ViewMaterialList() == false)
                //{
                //    cdvLineID.Select();
                //    MPCF.SetFocus(cdvLineID);
                //    return;
                //}

                // View Terminated Material List
                if (ViewTermainetedMaterialList() == false)
                {
                    cdvLineID.Select();
                    MPCF.SetFocus(cdvLineID);
                    return;
                }

                ClearData();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "MATERIAL":
                    case "CREATE":
                    case "UPDATE":
                        if (MPCF.CheckValue(cdvMaterialLineID, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvMaterialShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(soiMaterialOrderID, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(soiMaterialMatID, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(soiMaterialUnitID, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(soiMaterialQty, false) == false)
                        {
                            return false;
                        }

                        int nQty = -1;
                        if (Int32.TryParse(soiMaterialQty.Text, out nQty) == false)
                        {
                            MPCF.ShowMsgBox("Please Enter Qty(Number)");
                            soiMaterialQty.Focus();
                            return false;
                        }

                        if (MPCF.CheckValue(cdvMaterialReasonCode, false) == false)
                        {
                            return false;
                        }
                        break;

                    case "CANCEL":
                        if (MPCF.CheckValue(cdvMaterialLineID, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvMaterialShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(soiMaterialOrderID, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(soiMaterialMatID, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(soiMaterialHistSeq, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(soiMaterialSeq, false) == false)
                        {
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation (all)
                if (CheckCondition("CREATE") == false)
                {
                    return;
                }

                if (!ValidateTerminateOrderMaterial())
                {
                    return;
                }

                if (!TerminateMaterial(MPGC.MP_STEP_CREATE))
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
                // Validation (all)
                if (CheckCondition("UPDATE") == false)
                {
                    return;
                }

                if (!ValidateTerminateOrderMaterial())
                {
                    return;
                }

                if (!TerminateMaterial(MPGC.MP_STEP_UPDATE))
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

        private void btnToExcelMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pop = new SaveFileDialog();
                pop.InitialDirectory = "c:\\";

                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpModuleList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdMaterial.Sheets[0].Protect = false;
                    spdMaterial.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdMaterial.Sheets[0].Protect = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnToExcelTerminated_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pop = new SaveFileDialog();
                pop.InitialDirectory = "c:\\";

                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpTerminated.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdTerminated.Sheets[0].Protect = false;
                    spdTerminated.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdTerminated.Sheets[0].Protect = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdMaterial_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            gSelectedMaterialOrderID = spdMaterial.Sheets[0].Cells[e.Row, (int)MATETIRAL_LIST.ORDER_ID].Text;
            gSelectedMaterialMatType = spdMaterial.Sheets[0].Cells[e.Row, (int)MATETIRAL_LIST.MATE_TYPE].Text;
            gSelectedMaterialMatID = spdMaterial.Sheets[0].Cells[e.Row, (int)MATETIRAL_LIST.MAT_ID].Text;
            gSelectedMaterialMatDesc = (string)spdMaterial.Sheets[0].Cells[e.Row, (int)MATETIRAL_LIST.MAT_ID].Tag;
            gSelectedMaterialUnitID = spdMaterial.Sheets[0].Cells[e.Row, (int)MATETIRAL_LIST.UNIT_ID].Text;
            gSelectedMaterialSeq = spdMaterial.Sheets[0].Cells[e.Row, (int)MATETIRAL_LIST.SEQ].Text;
        }

        private void spdTerminated_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            gSelectedMaterialDateString = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.TERMINATION_DT].Text + "000000";
            gSelectedMaterialDate = DateTime.ParseExact(gSelectedMaterialDateString, "yyyyMMddHHmmss", null);

            gSelectedMaterialLineID = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.LINE_ID].Text;
            gSelectedMaterialLineIDDesc = (string)spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.LINE_ID].Tag;
            gSelectedMaterialShift = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.WORK_SHIFT].Text;
            gSelectedMaterialShiftDesc = (string)spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.WORK_SHIFT].Tag;
            gSelectedMaterialMatType = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.MATE_TYPE].Text;
            gSelectedMaterialMatID = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.MAT_ID].Text;
            gSelectedMaterialMatDesc = (string)spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.MAT_DESC].Value;
            gSelectedMaterialUnitID = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.UNIT_ID].Text;
            gSelectedMaterialQty = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.QTY].Text;
            gSelectedMaterialReasonCode = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.REASON_CODE].Text;
            gSelectedMaterialReasonCodeDesc = (string)spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.REASON_CODE].Tag;
            gSelectedMaterialComment = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.TER_COMMENT].Text;
            gSelectedMaterialHistSeq = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.HIST_SEQ].Text;
            gSelectedMaterialSeq = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.SEQ].Text;
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

        private bool ViewMaterialList()
        {
            try
            {
                int i;
                MPCF.ClearList(spdMaterial);

                TRSNode in_node = new TRSNode("VIEW_ORDER_BOM_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_BOM_LIST_OUT");
                TRSNode bom_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';

                if (string.IsNullOrEmpty(MPCF.Trim(soiCodeProductionOrder.Text)))
                {
                    in_node.AddString("ORDER_ID", "%");
                }
                else
                {
                    in_node.AddString("ORDER_ID", MPCF.Trim(soiCodeProductionOrder.Text));
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvMaterial.Text)))
                {
                    in_node.AddString("MAT_ID", "%");
                }
                else
                {
                    in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Order_BOM_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdMaterial.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    bom_list = out_node.GetList(0)[i];

                    spdMaterial.ActiveSheet.RowCount++;

                    spdMaterial.ActiveSheet.Cells[i, (int)MATETIRAL_LIST.ORDER_ID].Value = bom_list.GetString("ORDER_ID");
                    spdMaterial.ActiveSheet.Cells[i, (int)MATETIRAL_LIST.MATE_TYPE].Value = bom_list.GetString("MATE_TYPE");
                    spdMaterial.ActiveSheet.Cells[i, (int)MATETIRAL_LIST.MAT_DESC].Value = bom_list.GetString("MAT_DESC");
                    spdMaterial.ActiveSheet.Cells[i, (int)MATETIRAL_LIST.MAT_ID].Value = bom_list.GetString("MAT_ID");
                    spdMaterial.ActiveSheet.Cells[i, (int)MATETIRAL_LIST.MAT_ID].Tag = bom_list.GetString("MAT_DESC");
                    if (bom_list.GetString("UNIT_ID") == "KG")
                    {
                        spdMaterial.ActiveSheet.Cells[i, (int)MATETIRAL_LIST.UNIT_ID].Value = "LB";
                    }
                    else
                    {
                        spdMaterial.ActiveSheet.Cells[i, (int)MATETIRAL_LIST.UNIT_ID].Value = bom_list.GetString("UNIT_ID");
                    }
                    spdMaterial.ActiveSheet.Cells[i, (int)MATETIRAL_LIST.SEQ].Value = bom_list.GetInt("SEQ");
                }

                MPCF.FitColumnHeader(spdMaterial);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewTermainetedMaterialList()
        {
            try
            {
                int i;
                DateTime dtpFromDateTimeOut = new DateTime();
                DateTime dtpToDateTimeOut = new DateTime();

                MPCF.ClearList(spdTerminated);

                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                TRSNode terminated_lot_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1'; // by view conditions

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
                if (string.IsNullOrEmpty(MPCF.Trim(soiCodeProductionOrder.Text)))
                {
                    in_node.AddString("ORDER_ID", "%");
                }
                else
                {
                    in_node.AddString("ORDER_ID", MPCF.Trim(soiCodeProductionOrder.Text));
                }
                if (string.IsNullOrEmpty(MPCF.Trim(cdvMaterial.Text)))
                {
                    in_node.AddString("MAT_ID", "%");
                }
                else
                {
                    in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvLineID.Text)))
                {
                    in_node.AddString("LINE_ID", "%");
                }
                else
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                }

                if (string.IsNullOrEmpty(MPCF.Trim(soiShiftCode.Text)))
                {
                    in_node.AddString("WORK_SHIFT", "%");
                }
                else
                {
                    in_node.AddString("WORK_SHIFT", MPCF.Trim(soiShiftCode.Text));
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Material_Termination_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdTerminated.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    terminated_lot_list = out_node.GetList(0)[i];

                    spdTerminated.ActiveSheet.RowCount++;

                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.TERMINATION_DT].Value = terminated_lot_list.GetString("TERMINATION_DT");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LINE_ID].Value = terminated_lot_list.GetString("LINE_ID");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LINE_ID].Tag = terminated_lot_list.GetString("LINE_ID_DESC");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.WORK_SHIFT].Value = terminated_lot_list.GetString("WORK_SHIFT");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.WORK_SHIFT].Tag = terminated_lot_list.GetString("WORK_SHIFT_DESC");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.MATE_TYPE].Value = terminated_lot_list.GetString("MATE_TYPE");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.MAT_ID].Value = terminated_lot_list.GetString("MAT_ID");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.MAT_ID].Tag = terminated_lot_list.GetString("MATE_NO_DESC"); // DESC
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.MAT_DESC].Value = terminated_lot_list.GetString("MATE_NO_DESC"); // DESC
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.UNIT_ID].Value = terminated_lot_list.GetString("UNIT_ID");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.QTY].Value = terminated_lot_list.GetInt("QTY");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.REASON_CODE].Value = terminated_lot_list.GetString("REASON_CODE");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.REASON_CODE].Tag = terminated_lot_list.GetString("REASON_CODE_DESC"); // DESC
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.TER_COMMENT].Value = terminated_lot_list.GetString("TER_COMMENT");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.CREATE_USER_ID].Value = terminated_lot_list.GetString("CREATE_USER_ID");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.CREATE_TIME].Value = terminated_lot_list.GetString("CREATE_TIME");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.UPDATE_USER_ID].Value = terminated_lot_list.GetString("UPDATE_USER_ID");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.UPDATE_TIME].Value = terminated_lot_list.GetString("UPDATE_TIME");

                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.HIST_SEQ].Value = terminated_lot_list.GetInt("HIST_SEQ");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.SEQ].Value = terminated_lot_list.GetInt("SEQ");
                }

                //MPCF.FitColumnHeader(spdTerminated);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ValidateTerminateOrderMaterial()
        {
            TRSNode in_node = new TRSNode("VALIDATE_ORDER_IN");
            TRSNode out_node = new TRSNode("VALIDATE_ORDER_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("ORDER_ID", soiMaterialOrderID.Text);

                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
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

        private bool TerminateMaterial(char cProcStep)
        {
            TRSNode in_node = new TRSNode("TERMINATE_LOT_IN");
            TRSNode out_node = new TRSNode("TERMINATE_LOT_OUT");
            DateTime dtpTerminateMaterial = new DateTime();

            try
            {
                MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                if (cProcStep == 'N')
                {
                    cProcStep = 'U';
                    in_node.AddString("CANCEL_YN", "Y");
                }
                in_node.ProcStep = cProcStep;

                //in_node.AddString("TERMINATION_DT", dtpMaterialDate);
                if (dtpMaterialDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpMaterialDate.Value.ToString(), out dtpTerminateMaterial);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TERMINATION_DT", dtpTerminateMaterial.ToString("yyyyMMdd"));
                    }
                }

                in_node.AddString("LINE_ID", MPCF.Trim(cdvMaterialLineID.Text));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvMaterialShift.Text));
                in_node.AddString("ORDER_ID", MPCF.Trim(soiMaterialOrderID.Text));
                in_node.AddString("MATE_TYPE", MPCF.Trim(soiMaterialMatType.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(soiMaterialMatID.Text));
                in_node.AddString("MATE_NO_DESC", MPCF.Trim(soiMaterialMatDesc.Text));
                in_node.AddString("UNIT_ID", MPCF.Trim(soiMaterialUnitID.Text));
                in_node.AddInt("QTY", MPCF.ToInt(soiMaterialQty.Text));
                in_node.AddString("REASON_CODE", MPCF.Trim(cdvMaterialReasonCode.Text));
                in_node.AddString("TER_COMMENT", MPCF.Trim(soiMaterialComment.Text));

                in_node.AddInt("HIST_SEQ", MPCF.ToInt(soiMaterialHistSeq.Text));
                in_node.AddInt("SEQ", MPCF.ToInt(soiMaterialSeq.Text));

                if (MPCF.CallService("CWIP", "CWIP_Update_Material_Termination", in_node, ref out_node) == false)
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


        private void spdMaterial_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //bool nFindSelect = false;
                int nRowSelect = spdMaterial.Sheets[0].GetSelection(0).Row;

                ClearData();

                for (int i = 0; i < spdMaterial.Sheets[0].Rows.Count; i++)
                {
                    if (i == nRowSelect)
                    {
                        //nFindSelect = true;

                        gSelectedMaterialOrderID = spdMaterial.Sheets[0].Cells[i, (int)MATETIRAL_LIST.ORDER_ID].Text;
                        gSelectedMaterialMatType = spdMaterial.Sheets[0].Cells[i, (int)MATETIRAL_LIST.MATE_TYPE].Text;
                        gSelectedMaterialMatID = spdMaterial.Sheets[0].Cells[i, (int)MATETIRAL_LIST.MAT_ID].Text;
                        gSelectedMaterialMatDesc = (string)spdMaterial.Sheets[0].Cells[i, (int)MATETIRAL_LIST.MAT_ID].Tag;
                        gSelectedMaterialUnitID = spdMaterial.Sheets[0].Cells[i, (int)MATETIRAL_LIST.UNIT_ID].Text;
                        gSelectedMaterialSeq = spdMaterial.Sheets[0].Cells[i, (int)MATETIRAL_LIST.SEQ].Text;

                        soiMaterialOrderID.Text = gSelectedMaterialOrderID;
                        soiMaterialMatID.Text = gSelectedMaterialMatID;
                        soiMaterialMatDesc.Text = gSelectedMaterialMatDesc;
                        soiMaterialMatType.Text = gSelectedMaterialMatType;
                        soiMaterialUnitID.Text = gSelectedMaterialUnitID;

                        soiMaterialSeq.Text = gSelectedMaterialSeq;

                        break;
                    }
                }
                //return nFindSelect;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private void spdTerminated_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //bool nFindSelect = false;
                int nRowSelect = spdTerminated.Sheets[0].GetSelection(0).Row;

                ClearData();

                for (int i = 0; i < spdTerminated.Sheets[0].Rows.Count; i++)
                {
                    if (i == nRowSelect)
                    {
                        //nFindSelect = true;

                        gSelectedMaterialDateString = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.TERMINATION_DT].Text + "000000";
                        gSelectedMaterialDate = DateTime.ParseExact(gSelectedMaterialDateString, "yyyyMMddHHmmss", null);

                        gSelectedMaterialLineID = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.LINE_ID].Text;
                        gSelectedMaterialLineIDDesc = (string)spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.LINE_ID].Tag;
                        gSelectedMaterialShift = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.WORK_SHIFT].Text;
                        gSelectedMaterialShiftDesc = (string)spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.WORK_SHIFT].Tag;
                        gSelectedMaterialMatType = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.MATE_TYPE].Text;
                        gSelectedMaterialMatID = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.MAT_ID].Text;
                        gSelectedMaterialMatDesc = (string)spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.MAT_ID].Tag;
                        gSelectedMaterialUnitID = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.UNIT_ID].Text;
                        gSelectedMaterialQty = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.QTY].Text;
                        gSelectedMaterialReasonCode = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.REASON_CODE].Text;
                        gSelectedMaterialReasonCodeDesc = (string)spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.REASON_CODE].Tag;
                        gSelectedMaterialComment = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.TER_COMMENT].Text;

                        gSelectedMaterialHistSeq = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.HIST_SEQ].Text;
                        gSelectedMaterialSeq = spdTerminated.Sheets[0].Cells[i, (int)TERMINATED_LIST.SEQ].Text;

                        //====================================================
                        dtpMaterialDate.Value = gSelectedMaterialDate;

                        cdvMaterialLineID.Text = gSelectedMaterialLineID;
                        cdvMaterialLineID.Description = gSelectedMaterialLineIDDesc;

                        cdvMaterialShift.Text = gSelectedMaterialShift;
                        cdvMaterialShift.Description = gSelectedMaterialShiftDesc;

                        //soiMaterialOrderID.Text = gSelectedMaterialOrderID;
                        soiMaterialMatID.Text = gSelectedMaterialMatID;
                        soiMaterialMatDesc.Text = gSelectedMaterialMatDesc;
                        soiMaterialMatType.Text = gSelectedMaterialMatType;
                        soiMaterialUnitID.Text = gSelectedMaterialUnitID;

                        soiMaterialQty.Text = gSelectedMaterialQty;
                        cdvMaterialReasonCode.Text = gSelectedMaterialReasonCode;
                        cdvMaterialReasonCode.Description = gSelectedMaterialReasonCodeDesc;
                        soiMaterialComment.Text = gSelectedMaterialComment;

                        soiMaterialHistSeq.Text = gSelectedMaterialHistSeq;
                        soiMaterialSeq.Text = gSelectedMaterialSeq;

                        DateTime terDate = DateTime.ParseExact(spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.TERMINATION_DT].Text, "yyyyMMdd", null);
                        DateTime sysDate = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMdd"), "yyyyMMdd", null);
                        DateTime limitDate = DateTime.ParseExact(DateTime.Now.AddDays(-3).ToString("yyyyMMdd"), "yyyyMMdd", null);

                        int result = DateTime.Compare(terDate, limitDate);

                        if (result >= 0)
                        {
                            btnCancel.Enabled = true;
                        }
                        else
                        {
                            btnCancel.Enabled = false;
                        }

                        break;
                    }
                }
                //return nFindSelect;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        // Input Data Clear
        private void ClearData()
        {
            try
            {
                // Clear
                dtpMaterialDate.Value = DateTime.Now;

                //MPCF.FieldClear(dtpMaterialDate);
                //MPCF.FieldClear(cdvMaterialLineID);
                //MPCF.FieldClear(cdvMaterialShift);
                //MPCF.FieldClear(soiMaterialOrderID);
                //MPCF.FieldClear(soiMaterialMatID);
                //MPCF.FieldClear(soiMaterialMatDesc);
                //MPCF.FieldClear(soiMaterialMatType);
                //MPCF.FieldClear(soiMaterialUnitID);
                MPCF.FieldClear(soiMaterialQty);
                MPCF.FieldClear(cdvMaterialReasonCode);
                MPCF.FieldClear(soiMaterialComment);

                MPCF.FieldClear(soiMaterialHistSeq);
                MPCF.FieldClear(soiMaterialSeq);
                btnCancel.Enabled = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation (all)
                if (CheckCondition("CANCEL") == false)
                {
                    return;
                }

                if (!ValidateTerminateOrderMaterial())
                {
                    return;
                }

                if (!TerminateMaterial(MPGC.MP_STEP_RETURN))
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
    }
}
