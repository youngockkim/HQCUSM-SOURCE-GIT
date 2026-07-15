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
    public partial class frmCWIPPalletRepackingLog : SOIBaseForm02
    {
        #region Property

        #endregion

        #region Constructor

        public frmCWIPPalletRepackingLog()
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

        public enum DATA_LIST
        {
            FACTORY_NO,
            PALLET_ID,
            PACK_TIME,
            MAT_ID,
            MATERIAL_NAME,
            CAUSE_ID,
            CAUSE_NAME
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

                        if (MPCF.CheckValue(cdvCause, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboFactoryNo, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtPalletID, false) == false)
                        {
                            return false;
                        }
                        
                        break;

                    case "VIEW":
                        if (MPCF.CheckValue(cboFactoryNo, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtPalletID, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "UPDATE":

                        if (spdFqcLog.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(598));
                            return false;
                        }


                        if (MPCF.CheckValue(cdvCause, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboFactoryNo, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtPalletID, false) == false)
                        {
                            return false;
                        }
 
                        if (MPCF.CheckValue(cdvMaterial, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtPalletID, false) == false)
                        {
                            return false;
                        }

                        break;
                    case "APPEND":
                        
                        if (MPCF.CheckValue(cdvCause, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboFactoryNo, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtPalletID, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvMaterial, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtPalletID, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "DELETE":

                        if (spdFqcLog.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(599));
                            return false;
                        }
                        
                        if (MPCF.CheckValue(cboFactoryNo, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtPalletID, false) == false)
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

        private bool ViewWorklogList()
        {
            try
            {
                int i;


                chk_type = "";

                MPCF.ClearList(spdFqcLog);

                TRSNode in_node = new TRSNode("REPACKING_LOG_IN");
                TRSNode out_node = new TRSNode("REPACKING_LOG_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';


                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FACTORY_NO", MPCF.Trim(cboFactoryNo.Value));
                in_node.AddString("PALLET_ID", MPCF.Trim(txtPalletID.Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Repacking_Log_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdFqcLog.ActiveSheet.RowCount = 0;


                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdFqcLog.ActiveSheet.RowCount++;
                    spdFqcLog.ActiveSheet.Cells[i, (int)DATA_LIST.FACTORY_NO].Value = out_list.GetString("FACTORY_NO");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DATA_LIST.PALLET_ID].Value = out_list.GetString("PALLET_ID");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DATA_LIST.PACK_TIME].Value = out_list.GetString("PACK_TIME");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DATA_LIST.MAT_ID].Value = out_list.GetString("MAT_ID");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DATA_LIST.MATERIAL_NAME].Value = out_list.GetString("MATERIAL_NAME");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DATA_LIST.CAUSE_ID].Value = out_list.GetString("CAUSE_ID");
                    spdFqcLog.ActiveSheet.Cells[i, (int)DATA_LIST.CAUSE_NAME].Value = out_list.GetString("CAUSE_NAME");                                        
                }

                //MPCF.FitColumnHeader(spdFqcLog);


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
            try
            {
                TRSNode in_node = new TRSNode("REPACKING_LOG_IN");
                TRSNode out_node = new TRSNode("REPACKING_LOG_OUT");
                TRSNode list_item;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FACTORY_NO", MPCF.Trim(cboFactoryNo.Value));
                in_node.AddString("PALLET_ID", MPCF.Trim(txtPalletID.Text));

                list_item = in_node.AddNode("DATA_LIST");
                //header
                list_item.AddString("MAT_ID", spdFqcLog.ActiveSheet.Cells[spdFqcLog.ActiveSheet.ActiveRowIndex, (int)DATA_LIST.MAT_ID].Value);
                list_item.AddString("CAUSE_ID", MPCF.Trim(cdvCause.Text));

                if (MPCF.CallService("CWIP", "CWIP_Update_Repacking_Log", in_node, ref out_node) == false)
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
            //if (txtPalletID.Text.Length >= 13)
            //{
            //    cdvMaterial.Text = txtPalletID.Text.Substring(5, 8);
            //} 
            
        }

        #endregion

        #region Event Handler

        private void frmCWIPPalletRepackingLog_Load(object sender, EventArgs e)
        {
            initialize();

            chk_auto_validation = "";
            chk_auto = "";
            chk_common_line = "";


            MPCF.ConvertCaption(this);
            getLineLocationList();
            enableTransaction(false);
        }


        private void initialize() 
        {
        }

        private bool getLineLocationList()
        {
            try
            {
                // Init
                //LINE 가져오기.

                // Init
                //GET LINE 
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_LOCATION));

                int i;
                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboFactoryNo.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
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
         
        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_PAKING_MTRL_LIST));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List Options", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");
                                 
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void cdvCause_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_REPAKING_CAUSE_LIST));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvCause.Text = cdvCause.Show(cdvCause, "Cause List Options", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void setGridDataToComponent(int row, int col)
        {
            string strMatList = "" ;

            if (spdFqcLog.ActiveSheet.Cells[row, (int)DATA_LIST.PALLET_ID].Value.ToString().Length > 0 )
            {
                txtPalletID.Text = spdFqcLog.ActiveSheet.Cells[row, (int)DATA_LIST.PALLET_ID].Value.ToString();
            }

            if (spdFqcLog.ActiveSheet.Cells[row, (int)DATA_LIST.MAT_ID].Value.ToString().Length > 0)
            {
                cdvMaterial.Value = spdFqcLog.ActiveSheet.Cells[row, (int)DATA_LIST.MAT_ID].Value.ToString();
            }

            if (spdFqcLog.ActiveSheet.Cells[row, (int)DATA_LIST.CAUSE_ID].Value.ToString().Length > 0)
            {
                cdvCause.Text = spdFqcLog.ActiveSheet.Cells[row, (int)DATA_LIST.CAUSE_ID].Value.ToString();
                cdvCause.Description = spdFqcLog.ActiveSheet.Cells[row, (int)DATA_LIST.CAUSE_NAME].Value.ToString();
            }
        }

        private void set_view()
        {
            enableTransaction(false);
        }

        private void set_update()
        {
            //txt_clear();
            //txtPalletID.Enabled = true;
            //cdvMaterial.Enabled = false; 
        }

        private void set_create()
        {
            txt_clear();
            txtPalletID.Enabled = false;
            cdvMaterial.Enabled = false; 
        }

        private void data_clear()
        {
            cdvMaterial.Text = "";
            //cdvMaterial.Description = "";
            cdvCause.Text = "";
            cdvCause.Description = ""; 
        }

        private void txt_clear()
        {
            cdvMaterial.Text = "";
            txtPalletID.Text = "";
            cdvMaterial.Text = "";
            txtPalletID.Text = "";
            mbKeyPressed = false;
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
                if (e.Row >= 0 && e.Column >= 0)
                {
                    enableTransaction(true);
                }
                else
                {
                    enableTransaction(false);
                }
                setGridDataToComponent(e.Row, e.Column);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }               
 
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("APPEND") == false)
                {
                    return;
                }

                if (AddData() == false)
                {
                    return;
                }

                //if (UpdateData(MPGC.MP_STEP_CREATE) == false)
                //{
                //    return;
                //}

                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool AddData()
        {
            string strMat = "";
            List<string> data = cdvMaterial.returnValues;

            try
            {
                TRSNode in_node = new TRSNode("REPACKING_LOG_IN");
                TRSNode out_node = new TRSNode("REPACKING_LOG_OUT");
                TRSNode list_item;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'I';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FACTORY_NO", MPCF.Trim(cboFactoryNo.Value));
                in_node.AddString("PALLET_ID", MPCF.Trim(txtPalletID.Text));

                foreach (string rec in data)
                {
                    Boolean bFound = false;
                    for (int inx = 0; inx < spdFqcLog.ActiveSheet.RowCount; inx++)
                    {
                        strMat = spdFqcLog.ActiveSheet.Cells[inx, (int)DATA_LIST.MAT_ID].Value.ToString();
                        if (rec == strMat)
                        {
                            bFound = true;
                        }
                    }

                    if (bFound)
                    {
                        continue;
                    }

                    list_item = in_node.AddNode("DATA_LIST");
                    
                    //header
                    list_item.AddString("MAT_ID", MPCF.Trim(rec));
                    list_item.AddString("CAUSE_ID", MPCF.Trim(cdvCause.Text));
                }
                if (MPCF.CallService("CWIP", "CWIP_Update_Repacking_Log", in_node, ref out_node) == false)
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

        private void enableTransaction(bool bEnable)
        {
            //btnProcess.Enabled = bEnable;
            btnUpdate.Enabled = bEnable;
            btnDelete.Enabled = bEnable;
        }
         
        private void txtPalletID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (validateData() == false)
                {
                    MPCF.ShowMessage("Only digits and '.' are allowed in the barcode serial number.", MSG_LEVEL.ERROR, false);
                    return;
                }

                // Refresh
                btnView.PerformClick();
            }
        }
 

        private bool validateData()
        {
            //for (int inx = 0; inx < txtPalletID.Text.Length; inx++)
            //{
            //    char charBarcode= txtPalletID.Text[inx];
            //    if (!(char.IsDigit(charBarcode) || charBarcode == '.'))
            //        return false;
            //}

            return true;
        }


        #endregion

        private void btnToExcelModules_Click(object sender, EventArgs e)
        {

        }
         
    }
}
