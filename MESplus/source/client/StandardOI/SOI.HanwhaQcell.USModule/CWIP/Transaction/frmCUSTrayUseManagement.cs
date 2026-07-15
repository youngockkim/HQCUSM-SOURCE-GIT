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
    public partial class frmCUSTrayUseManagement : SOIBaseForm02
    {
        #region Property

        // (Required)
        private string vStartTime = string.Empty;

        #endregion

        public frmCUSTrayUseManagement()
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

                        if ((string.IsNullOrEmpty(txtTrayId.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.SetFocus(txtTrayId);
                            return false;
                        }

                        if ((string.IsNullOrEmpty(cdvTrayType.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Traytype]"));
                            MPCF.SetFocus(cdvTrayType);
                            return false;
                        }

                        //if ((string.IsNullOrEmpty(cdvEquipID.Text) == true))
                        //{
                        //    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Equipment]"));
                        //    MPCF.SetFocus(cdvEquipID);
                        //    return false;
                        //}
                        break;

                    case "TRAY":

                        if ((string.IsNullOrEmpty(txtTrayId.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.SetFocus(txtTrayId);
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

        private void SearchTrayId()
        {
            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayId.Text));


            if (MPCF.CallService("CWIP", "CWIP_Update_Tray_Management", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);

                return;
            }

            txtTrayId.Text = out_node.GetString("TRAY_ID");
            //txtStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
            //txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("ENT_TIME"));
            txtStartTime.Text = "";

            btnProcess.Enabled = true;

            MPCF.SetFocus(txtTrayId);
            txtTrayId.SelectAll();
        }

        private void Create_data()
        {

            txtStartTime.Text = "";
            txtEndTime.Text = "";

            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayId.Text));
            //in_node.AddString("RES_ID", MPCF.Trim(cdvEquipID.Text));
            in_node.AddString("USER_ID", MPCF.Trim(cdvWorker.Text));
            in_node.AddString("TRAY_TYPE", MPCF.Trim(cdvTrayType.Text));


            if (MPCF.CallService("CWIP", "CWIP_Update_Tray_Management", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
            }

            //vStartTime = out_node.GetString("START_TIME");
            //txtStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
            //txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));
            txtStartTime.Text = DateTime.Today.ToShortDateString();


            MPCF.ShowSuccessMessage(out_node, false);

            if (txtStartTime.Text != "")
            {
                btnRestart.Enabled = false;
                btnProcess.Enabled = true;
            }
            else
            {
                btnRestart.Enabled = true; ;
                btnProcess.Enabled = false;
            }
        }




        private void cdvWorker_ValueChanged(object sender, EventArgs e)
        {
            set_button();
        }

        private void set_button()
        {
            btnRestart.Enabled = false;
            btnProcess.Enabled = false;
            txtStartTime.Text = "";
            txtEndTime.Text = "";

        }

        private void cdvWorker_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");

                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '8';

                in_node.AddString("TABLE_NAME", MPCF.Trim("@REPAIR_WORKER"));

                // CodeView Column Header Setup
                string[] header = new string[] { "Repair Worker", "Name" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_2", "DATA_1" };


                // Show

                cdvWorker.Text = cdvWorker.Show(cdvWorker, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_2");
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

        private void cdvEquipID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");
                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("TABLE_NAME", "TERMINATE_EQ");
                in_node.AddString("USE_YN", "Y");

                string[] header = new string[] { "Terminattion Equipment", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };
                cdvEquipID.Text = cdvEquipID.Show(cdvEquipID, "Terminate Equipment", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvEquipID.Text) != "")
                {
                    if (cdvEquipID.returnDatas.Count > 0)
                    {
                        cdvEquipID.Tag = cdvEquipID.returnDatas[1];
                    }
                }
                
                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvTrayType_CodeViewButtonClick_1(object sender, EventArgs e)
        {
            /// 새로 하나 만들어야함.
            try
            {

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");

                //In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@TRAY_TYPE"));

                // CodeView Column Header Setup
                string[] header = new string[] { "Tray Code", "Tray Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvTrayType.Text = cdvTrayType.Show(cdvTrayType, "Tray Type", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvTrayType.Text) == true)
                {
                    MPCF.SetFocus(cdvTrayType);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvTrayType);


            }
            catch (Exception)
            {
                throw;
            }
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("SEARCH"))
            {
                return;
            }
            Create_data();

            btnProcess.Enabled = false;
        }

        private void txtTrayId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (!CheckCondition("TRAY"))
                        return;

                    SearchTrayId();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

    }
    
}
