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
    public partial class frmCUSDayInventory : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSDayInventory()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]
        public string chk_type;
        public string chk_auto_validation;
        public string chk_common_line;
        public string chk_auto;
        public bool mbKeyPressed = false;

        public enum DAYINVENTORY
        {
            MAT_ID,
            MAT_DESC,
            MAT_QTY,
            BATCH_NO,
            TRAN_TIME,
            INVT_BRCD,
            BRCD_SIZE,
            INVT_MSGS,
            WORK_DATE,
            LINE_ID,
            INVT_SEQ,
            OPER_TYPE,
            OPER_NAME,
        }


        #endregion

        #region [Variable Definition]

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

                        //if (MPCF.CheckValue(cdvOperType, false) == false)
                        //{
                        //    return false;
                        //}
                        if (MPCF.CheckValue(txtOperator, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvMaterial, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtBarcode, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "VIEW":
                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        //if (MPCF.CheckValue(cdvOperType, false) == false)
                        //{
                        //    return false;
                        //}
                        if (MPCF.CheckValue(txtOperator, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "UPDATE":

                        if (spdFqcLog.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(590));
                            return false;
                        }


                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        //if (MPCF.CheckValue(cdvOperType, false) == false)
                        //{
                        //    return false;
                        //}
                        if (MPCF.CheckValue(txtOperator, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvMaterial, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtBarcode, false) == false)
                        {
                            return false;
                        }

                        break;
                    case "APPEND":

                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        //if (MPCF.CheckValue(cdvOperType, false) == false)
                        //{
                        //    return false;
                        //}
                        if (MPCF.CheckValue(txtOperator, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvMaterial, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtBarcode, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "DELETE":

                        if (spdFqcLog.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(591));
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

        private bool ViewWorklogList()
        {
            try
            {
                int i;


                chk_type = "";

                DateTime dtpFromDateTimeOut = new DateTime();

                MPCF.ClearList(spdFqcLog);

                TRSNode in_node = new TRSNode("VIEW_FQCLOG_IN");
                TRSNode out_node = new TRSNode("VIEW_FQCLOG_OUT");
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

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("OPER_TYPE", MPCF.Trim(cdvOperType.Text));
                in_node.AddString("OPER_NAME", MPCF.Trim(txtOperator.Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Day_Inventory_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdFqcLog.ActiveSheet.RowCount = 0;


                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdFqcLog.ActiveSheet.RowCount++;
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.WORK_DATE].Value = out_list.GetString("WORK_DATE");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.LINE_ID].Value = out_list.GetString("LINE_ID");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.INVT_SEQ].Value = out_list.GetInt("INVT_SEQ");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.OPER_TYPE].Value = out_list.GetString("OPER_TYPE");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.OPER_NAME].Value = out_list.GetString("OPER_NAME");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.MAT_ID].Value = out_list.GetString("MAT_ID");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.MAT_DESC].Value = out_list.GetString("MAT_DESC");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.MAT_QTY].Value = out_list.GetDouble("MAT_QTY");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.BATCH_NO].Value = out_list.GetString("BATCH_NO");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.TRAN_TIME].Value = out_list.GetString("TRAN_TIME");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.INVT_BRCD].Value = out_list.GetString("INVT_BRCD");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.BRCD_SIZE].Value = out_list.GetString("INVT_BRCD").Length;

                    if (out_list.GetString("INVT_BRCD").Length < 40)
                    {
                        String msg = MPCF.GetMessage(592);

                        msg = out_list.GetString("INVT_MSGS").Length > 0 ? out_list.GetString("INVT_MSGS") + "(more)\n" + msg : msg;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.INVT_MSGS].Value = msg;
                    }
                    else
                    {
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.INVT_MSGS].Value = out_list.GetString("INVT_MSGS");
                    }



                    if (out_list.GetString("INVT_MSGS").Trim().Length > 0)
                    {
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.MAT_ID].ForeColor = Color.Red;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.MAT_DESC].ForeColor = Color.Red;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.BATCH_NO].ForeColor = Color.Red;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.TRAN_TIME].ForeColor = Color.Red;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.TRAN_TIME].ForeColor = Color.Red;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.INVT_BRCD].ForeColor = Color.Red;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.MAT_QTY].ForeColor = Color.Red;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.BRCD_SIZE].ForeColor = Color.Red;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.INVT_MSGS].ForeColor = Color.Red;
                    }
                    else
                    {
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.MAT_ID].ForeColor = Color.White;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.MAT_DESC].ForeColor = Color.White;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.BATCH_NO].ForeColor = Color.White;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.TRAN_TIME].ForeColor = Color.White;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.TRAN_TIME].ForeColor = Color.White;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.INVT_BRCD].ForeColor = Color.White;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.MAT_QTY].ForeColor = Color.White;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.INVT_MSGS].ForeColor = Color.White;
                        spdFqcLog.ActiveSheet.Cells[i, (int)DAYINVENTORY.BRCD_SIZE].ForeColor = Color.White;
                    }

                    if (out_list.GetInt("INVT_SEQ") == 0)
                    {
                        chk_type = "C";
                    }

                    else
                    {
                        chk_type = "U";
                    }
                }

                //MPCF.FitColumnHeader(spdFqcLog);


                if (chk_type == "C")
                {
                    set_create();
                }
                else if (chk_type == "U")
                {
                    set_update();
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool UpdateData(char ProcStep)
        {
            int seqno = 0,
                actionTime = 0;

            try
            {
                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_FQCLOG_IN");
                TRSNode out_node = new TRSNode("UPDATE_FQCLOG_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);

                // Scrap Date
                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpScrapDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                if (MPCF.Trim(txtSEQ.Text).Length > 0)
                {
                    int.TryParse(MPCF.Trim(txtSEQ.Text), out seqno);
                }

                //header
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddInt("INVT_SEQ", seqno);
                in_node.AddString("OPER_NAME", MPCF.Trim(txtOperator.Text));
                in_node.AddString("OPER_TYPE", MPCF.Trim(cdvOperType.Text));
                in_node.AddString("MAT_ID", cdvMaterial.Text);
                in_node.AddDouble("MAT_QTY", txtQty.Text);
                in_node.AddString("BATCH_NO", txtBatchNo.Text);
                in_node.AddString("INVT_BRCD", txtBarcode.Text);
                in_node.AddString("INVT_MSGS", txtMessages.Text);

                if (MPCF.CallService("CWIP", "CWIP_Update_Day_Inventory", in_node, ref out_node) == false)
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
        private void parseBarcodeData()
        {
            if (txtBarcode.Text.Length >= 13)
            {
                cdvMaterial.Text = txtBarcode.Text.Substring(5, 8);
            }
            if (txtBarcode.Text.Length >= 27)
            {
                txtQty.Text = txtBarcode.Text.Substring(14, 13);
            }
            if (txtBarcode.Text.Length >= 40)
            {
                txtBatchNo.Text = txtBarcode.Text.Substring(33, 7);
            }

            if (txtBarcode.Text.Length < 40)
            {
                txtMessages.Text = MPCF.GetMessage(592);
            }
        }

        #endregion

        #region Event Handler

        private void frmCUSDayInventory_Load(object sender, EventArgs e)
        {
            initialize();

            // Init
            dtpDate.Value = DateTime.Today;

            chk_auto_validation = "";
            chk_auto = "";
            chk_common_line = "";


            MPCF.ConvertCaption(this);
        }


        private void initialize()
        {
            //2024/05/10  Monthly로 고정요청
            cdvOperType.Text = "IT20";

            spdFqcLog.Sheets[0].Columns.Get((int)DAYINVENTORY.WORK_DATE).Width = 0;
            spdFqcLog.Sheets[0].Columns.Get((int)DAYINVENTORY.LINE_ID).Width = 0;
            spdFqcLog.Sheets[0].Columns.Get((int)DAYINVENTORY.INVT_SEQ).Width = 0;
            spdFqcLog.Sheets[0].Columns.Get((int)DAYINVENTORY.OPER_TYPE).Width = 0;
            spdFqcLog.Sheets[0].Columns.Get((int)DAYINVENTORY.OPER_NAME).Width = 0;
        }

        private void frmCUSDayInventory_Shown(object sender, EventArgs e)
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

            if (cdvOperType.Text.Length > 0 &&
                txtOperator.Text.Length > 0)
            {
                // Refresh
                btnView.PerformClick();
            }
        }


        private void cdvOperType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@DAYINV_OPER_TYPE"));

                string[] header = new string[] { "Type", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvOperType.Text = cdvOperType.Show(cdvOperType, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

            if (cdvLineID.Text.Length > 0 &&
                txtOperator.Text.Length > 0)
            {
                // Refresh
                btnView.PerformClick();
            }
        }

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_TYPE", MPCF.Trim(HQGC.MATERIAL_TYPE_P)); // Production

                string[] header = new string[] { "Product", "Description" };
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "MAT_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvMaterial.Text) == true)
                {
                    return;
                }

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
                //SaveFileDialog pop = new SaveFileDialog();
                //pop.InitialDirectory = "C:\\";

                //pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpScrapList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                //pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                //pop.FilterIndex = 1;

                //if (pop.ShowDialog() == DialogResult.OK)
                //{
                //    spdFqcLog.Sheets[0].Protect = false;
                //    spdFqcLog.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                //    spdFqcLog.Sheets[0].Protect = true;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void set_view()
        {
            txt_clear();
            checkWorkDateValid();
        }

        private void set_update()
        {
            txt_clear();
            checkWorkDateValid();
            txtBarcode.Enabled = true;
            cdvMaterial.Enabled = false;
            txtMessages.Enabled = false;
        }

        private void set_create()
        {
            txt_clear();
            checkWorkDateValid();
            txtBarcode.Enabled = false;
            cdvMaterial.Enabled = false;
            txtMessages.Enabled = false;
        }

        private void data_clear()
        {
            txtQty.Text = "";
            txtBatchNo.Text = "";
            cdvMaterial.Text = "";
            cdvMaterial.Description = "";
            txtMessages.Text = "";
        }

        private void txt_clear()
        {
            cdvMaterial.Text = "";
            txtQty.Text = "";
            txtBatchNo.Text = "";
            txtBarcode.Text = "";
            cdvMaterial.Text = "";
            txtSEQ.Text = "";
            txtBarcode.Text = "";
            txtMessages.Text = "";
            mbKeyPressed = false;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_clear();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }

                if (ViewWorklogList() == false)
                {
                    return;
                }
                set_view();
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
                if (chk_type == "C")
                {
                    if (CheckCondition("CREATE") == false)
                    {
                        return;
                    }

                    if (UpdateData(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (CheckCondition("UPDATE") == false)
                    {
                        return;
                    }

                    if (UpdateData(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
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
                if (MPCF.ShowMsgBox(MPCF.GetMessage(451), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (CheckCondition("DELETE") == false)
                {
                    return;
                }

                if (UpdateData(MPGC.MP_STEP_DELETE) == false)
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

        private void spdFqcLog_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {

                set_update();
                txt_clear();
                txtSEQ.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)DAYINVENTORY.INVT_SEQ].Text;
                cdvMaterial.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)DAYINVENTORY.MAT_ID].Text;
                cdvMaterial.Description = spdFqcLog.Sheets[0].Cells[e.Row, (int)DAYINVENTORY.MAT_DESC].Text;
                txtQty.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)DAYINVENTORY.MAT_QTY].Text;
                txtBatchNo.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)DAYINVENTORY.BATCH_NO].Text;
                txtMessages.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)DAYINVENTORY.INVT_MSGS].Text;
                txtBarcode.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)DAYINVENTORY.INVT_BRCD].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("APPEND") == false)
                {
                    return;
                }


                if (UpdateData(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (cdvLineID.Text.Length > 0 &&
                 cdvOperType.Text.Length > 0 &&
                 txtOperator.Text.Length > 0)
            {
                // Refresh
                btnView.PerformClick();
            }


        }

        private void checkWorkDateValid()
        {
            if (DateTime.Parse(dtpDate.Value.ToString()) > DateTime.Today)
            {
                enableTransaction(false);
            }
            else
            {
                if (DateTime.Parse(dtpDate.Value.ToString()) < DateTime.Today)
                {
                    enableTransaction(false);
                }
                if (DateTime.Parse(dtpDate.Value.ToString()) == DateTime.Today)
                {
                    enableTransaction(true);
                }
            }
        }

        private void enableTransaction(bool bEnable)
        {
            btnADD.Enabled = bEnable;
            btnUpdate.Enabled = bEnable;
            btnDelete.Enabled = bEnable;
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                data_clear();

                if (validateData() == false)
                {
                    MPCF.ShowMessage("Only digits and '.' are allowed in the barcode serial number.", MSG_LEVEL.ERROR, false);
                    return;
                }

                parseBarcodeData();
                return;
            }

            //숫자와 백스페이스만 입력
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))
            {
                e.Handled = true;
            }

            mbKeyPressed = true;
        }
        private void txtOperator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                // Refresh
                btnView.PerformClick();
            }
        }
        private void txtBarcode_ValueChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length == 40 && txtSEQ.Text.Trim().Length == 0)
            {
                data_clear();

                if (validateData() == false)
                {
                    MPCF.ShowMessage("Only digits and '.' are allowed in the barcode serial number.", MSG_LEVEL.ERROR, false);
                    return;
                }

                cdvMaterial.Text = txtBarcode.Text.Substring(5, 8);
                txtQty.Text = txtBarcode.Text.Substring(14, 13);
                txtBatchNo.Text = txtBarcode.Text.Substring(33, 7);

                //when barcode scan
                if (chkScanner.Checked)
                {
                    if (btnADD.Enabled == false)
                    {
                        this.CheckCondition("APPEND");
                    }
                    btnADD.PerformClick();
                }
            }
        }

        private bool validateData()
        {
            for (int inx = 0; inx < txtBarcode.Text.Length; inx++)
            {
                char charBarcode = txtBarcode.Text[inx];
                if (!(char.IsDigit(charBarcode) || charBarcode == '.'))
                    return false;
            }

            return true;
        }
        #endregion

    }
}
