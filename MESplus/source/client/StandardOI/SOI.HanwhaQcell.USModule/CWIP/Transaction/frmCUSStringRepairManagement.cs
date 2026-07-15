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
    public partial class frmCUSStringRepairManagement : SOIBaseForm02
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        public frmCUSStringRepairManagement()
        {
            InitializeComponent();
        }

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
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
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                MPCF.SetFocus(txtTrayId);
                txtTrayId.SelectAll();

                // (Required) 
                bIsShown = true;
            }
        }

        private void cdvWorker_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_WORKER_IN");
                TRSNode out_node = new TRSNode("VIEW_WORKER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("FACTORY", "USGAM1");
                in_node.AddString("TABLE_NAME", "@WORKER_MASTER");

                // CodeView Column Header Setup
                string[] header = new string[] { "Name", "ID"};

                // CodeView Display Column Setup
                string[] display = new string[] { "DATA_1", "KEY_1"};

                // Show
                //cdvWorker1.Text = cdvWorker1.Show(cdvWorker1, "WORKER", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "DATA_3");
                cdvWorker.Text = cdvWorker.Show(cdvWorker, "WORKER", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");


                // Validation
                if (string.IsNullOrEmpty(cdvWorker.Text) == true)
                {
                    MPCF.SetFocus(cdvWorker);
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("SAVE"))
                return;


            if (SaveRepairStringInfoWithRepairman() == true)
            {
                SearchRepairStringInfoByTrayId2();
                MPCF.ShowMessage("Data was saved successfully.", MSG_LEVEL.INFO, false);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "SAVE":
                        if ((string.IsNullOrEmpty(cdvWorker.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[WORKER]"));
                            MPCF.SetFocus(cdvWorker);
                            return false;
                        }
                        
                        if ((string.IsNullOrEmpty(cdvLineID.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[LINE ID]"));
                            MPCF.SetFocus(cdvLineID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtTrayId.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.SetFocus(txtTrayId);
                            txtTrayId.SelectAll();
                            return false;
                        }

                        if (MPCF.Trim(txtTrayId.Text).Length != 7)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(505) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.SetFocus(txtTrayId);
                            txtTrayId.SelectAll();
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtRepairQTY.Text) == true || Int32.Parse(txtRepairQTY.Text) == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Repair QTY]"));
                            MPCF.SetFocus(txtRepairQTY);
                            return false;
                        }

                        break;


                    case "TRAY":
                        if ((string.IsNullOrEmpty(txtTrayId.Text) == true))
                        {
                            //MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.ShowMsgBox("Please enter a valid Tray ID.");
                            MPCF.SetFocus(txtTrayId);
                            return false;
                        }
                        if (MPCF.Trim(txtTrayId.Text).Length != 7)
                        {
//                            MPCF.ShowMsgBox(MPCF.GetMessage(505) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.ShowMsgBox("Please enter a valid Tray ID." + Environment.NewLine + "Tray ID must consist with 7 characters.");
                            MPCF.SetFocus(txtTrayId);
                            txtTrayId.SelectAll();
                            return false;
                        }
                        if (txtTrayId.Text.Substring(0, 3).Equals("STR") == false)
                        {
//                            MPCF.ShowMsgBox(MPCF.GetMessage(505) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.ShowMsgBox("Please enter a valid Tray ID." + Environment.NewLine + " Tray ID must start with 'STR'.");
                            MPCF.SetFocus(txtTrayId);
                            txtTrayId.SelectAll();
                            return false;
                        }

                        int ret;
                        if ( Int32.TryParse(txtTrayId.Text.Substring(3, 4), out ret)==false)
                        {
//                            MPCF.ShowMsgBox(MPCF.GetMessage(505) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.ShowMsgBox("Please enter a valid Tray ID." + Environment.NewLine + "Tray ID must end with 4 numerical values.");
                            MPCF.SetFocus(txtTrayId);
                            txtTrayId.SelectAll();
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

        // Save
        private bool SaveRepairStringInfoWithRepairman()
        {
            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FACTORY", "USGAM1");
            in_node.AddString("USER_ID", MPCF.Trim(cdvWorker.Description));
            in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayId.Text));
            in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
            in_node.AddInt("REPAIR_QTY", MPCF.Trim(txtRepairQTY.Text));

            in_node.AddInt("LINE_ID", MPCF.Trim(cdvLineID.Description));

            if (MPCF.CallService("CWIP", "CWIP_Update_Tray", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        // Search
        private void SearchRepairStringInfoByTrayId()
        {
            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");
            //TRSNode out_list;

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayId.Text));


            if (MPCF.CallService("CWIP", "CWIP_View_Tray", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
            }

            txtTrayId.Text = out_node.GetString("TRAY_ID");

            //IS-22-04-039 
            //txtRepairQTY.Text = out_node.GetInt("REPAIR_QTY").ToString();
            //cdvWorker.Description = MPCF.Trim(out_node.GetString("USER_ID"));
            //cdvWorker.Text = MPCF.Trim(out_node.GetString("USER_NAME"));

            txtStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
            txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("ENT_TIME"));
            txtRepairQTY.Text = MPCF.MakeNumberFormat(out_node.GetInt("REPAIR_QTY"));
            
            if (String.IsNullOrWhiteSpace(txtEndTime.Text))
            {
                btnProcess.Enabled = true;
            }
            else
            {
                btnProcess.Enabled = false;
            }

            MPCF.SetFocus(txtTrayId);
            txtTrayId.SelectAll();

            /*
            spdTrayList.ActiveSheet.RowCount = 0;

            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {
                out_list = out_node.GetList(0)[i];
                spdTrayList.ActiveSheet.RowCount++;

                spdTrayList.ActiveSheet.Cells[i, 0].Value = out_list.GetInt("SEQ");
                spdTrayList.ActiveSheet.Cells[i, 1].Value = out_list.GetString("RES_ID");
                spdTrayList.ActiveSheet.Cells[i, 2].Value = out_list.GetInt("REPAIR_QTY");
                spdTrayList.ActiveSheet.Cells[i, 3].Value = out_list.GetInt("INPUT_QTY");
                spdTrayList.ActiveSheet.Cells[i, 4].Value = out_list.GetString("ORDER_ID");
                spdTrayList.ActiveSheet.Cells[i, 5].Value = MPCF.MakeDateFormat(out_list.GetString("START_TIME"));
                spdTrayList.ActiveSheet.Cells[i, 6].Value = MPCF.MakeDateFormat(out_list.GetString("ENT_TIME"));
                spdTrayList.ActiveSheet.Cells[i, 7].Value = MPCF.MakeDateFormat(out_list.GetString("INPUT_TIME"));
            }

            MPCF.FitColumnHeader(spdTrayList);
            */
        }

        private void SearchRepairStringInfoByTrayId2()
        {
            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");
            //TRSNode out_list;

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayId.Text));

            if (MPCF.CallService("CWIP", "CWIP_View_Tray", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
            }

            txtTrayId.Text = out_node.GetString("TRAY_ID");

            txtStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
            txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("ENT_TIME"));
            txtRepairQTY.Text = MPCF.MakeNumberFormat(out_node.GetInt("REPAIR_QTY"));

            if (String.IsNullOrWhiteSpace(txtEndTime.Text))
            {
                btnProcess.Enabled = true;
            }
            else
            {
                btnProcess.Enabled = false;
            }

            MPCF.SetFocus(txtTrayId);
            txtTrayId.SelectAll();

        }


        private void txtTrayId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (!CheckCondition("TRAY"))
                        return;

                    SearchRepairStringInfoByTrayId();
                    txtRepairQTY.Text = "24";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("TRAY"))
                return;

            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("FACTORY", "USGAM1");
            in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayId.Text));

            if (MPCF.CallService("CWIP", "CWIP_Update_Tray", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(74) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"), MSG_LEVEL.ERROR, false);
            }
            else
            {
                SearchRepairStringInfoByTrayId();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cdvWorker.Text = string.Empty;
            cdvWorker.Description = string.Empty;
            cdvLineID.Text = string.Empty;
            cdvLineID.Description = string.Empty;
            txtTrayId.Text = string.Empty;
            txtRepairQTY.Text = "24";
            txtStartTime.Text = string.Empty;
            txtEndTime.Text = string.Empty;

            btnProcess.Enabled = false;

            MPCF.SetFocus(txtTrayId);

            MPCF.ShowMessage("", MSG_LEVEL.INFO, false);
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim("MA"));

                string[] header = new string[] { "Line", "Line Desc" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                //cdvLineID.Text = cdvLineID.Show(cdvLineID, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "View Line", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
                
                // Clear
                MPCF.FieldClear(pnlMiddleMargin, cdvLineID);


                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtRepairQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            //Repair 수량을 수정하여 24가 아닌 경우 enter키를 누르면 저장되도록 함
            //2023년1월26일 손혜윤엔지니어요청사항
            if (txtRepairQTY.Value != null && txtRepairQTY.Value.Equals("24") == false && e.KeyChar == (char)13)
            {
                if (!CheckCondition("SAVE"))
                    return;


                if (SaveRepairStringInfoWithRepairman() == true)
                {
                    SearchRepairStringInfoByTrayId2();
                    MPCF.ShowMessage("Data was saved successfully.", MSG_LEVEL.INFO, false);
                }
            }
        }
         
    }
}
