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
    public partial class frmCWIPRepairIncentive : SOIBaseForm02
    {
        #region Property

        // (Required)
        private bool bIsShown = false;
        private string vStartTime = string.Empty;

        #endregion

        public frmCWIPRepairIncentive()
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
 
        private void cdvLocation_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");

                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("TYPE_1", MPCF.Trim("REPAIR_OITT"));
                in_node.AddString("TYPE_2", MPCF.Trim("LOC"));

                // CodeView Column Header Setup
                string[] header = new string[] { "Location Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "TYPE_3", "DATA_1" };


                // Show

                cdvLocation.Text = cdvLocation.Show(cdvLocation, "Code List", "CBAS", "CBAS_View_CGCMTBLDAT_List", in_node, "CGCMTBLDAT_LIST", display, header, "TYPE_3");
                if (string.IsNullOrEmpty(cdvLocation.Text) == true)
                {
                    MPCF.SetFocus(cdvLocation);
                    return;
                }

            }
            catch (Exception)
            {
                throw;
            }
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
                string[] header = new string[] {"Repair Worker", "Name" };

                // CodeView Display Column Setup
                string[] display = new string[] {"KEY_2", "DATA_1" };


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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("END"))
            {
                return;
            }

            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = 'U';
            in_node.AddString("FACTORY", "USGAM1");
            in_node.AddString("WORKER", MPCF.Trim(cdvWorker.Text));
            in_node.AddString("LOCATION", MPCF.Trim(cdvLocation.Text));
            in_node.AddString("START_TIME", vStartTime);

            
            if (MPCF.CallService("CWIP", "CWIP_Update_Repair_Insentive", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage("Please Check Start/End Time", MSG_LEVEL.ERROR, false);     
            }
            
            txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));
            btnProcess.Enabled = false;
//            Search_data();

        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {

                    case "SEARCH":
                        if ((string.IsNullOrEmpty(cdvWorker.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[WORKER]"));
                            MPCF.SetFocus(cdvWorker);
                            return false;
                        }

                        if ((string.IsNullOrEmpty(cdvLocation.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[LOCATION]"));
                            MPCF.SetFocus(cdvLocation);
                            return false;
                        }

                        break;

                    case "START":
                        if ((string.IsNullOrEmpty(cdvWorker.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[WORKER]"));
                            MPCF.SetFocus(cdvWorker);
                            return false;
                        }

                        if ((string.IsNullOrEmpty(cdvLocation.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[LOCATION]"));
                            MPCF.SetFocus(cdvLocation);
                            return false;
                        }

                        break;
                    case "END":
                        if ((string.IsNullOrEmpty(cdvWorker.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[WORKER]"));
                            MPCF.SetFocus(cdvWorker);
                            return false;
                        }

                        if ((string.IsNullOrEmpty(cdvLocation.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[LOCATION]"));
                            MPCF.SetFocus(cdvLocation);
                            return false;
                        }
                        if ((string.IsNullOrEmpty(txtStartTime.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Start Time]"));
                            MPCF.SetFocus(txtStartTime);
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


       
        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("START"))
            {
                return;
            }

            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = 'I';
            in_node.AddString("FACTORY", "USGAM1");
            in_node.AddString("WORKER", MPCF.Trim(cdvWorker.Text));
            in_node.AddString("LOCATION", MPCF.Trim(cdvLocation.Text));

            if (MPCF.CallService("CWIP", "CWIP_Update_Repair_Insentive", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage("Please Check Start/End Time", MSG_LEVEL.ERROR, false);     
                return ;
            }

            Search_data();

          
        }

        private void set_button()
        {
            btnRestart.Enabled = false;
            btnProcess.Enabled = false;
            txtStartTime.Text = "";
            txtEndTime.Text = "";

        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            cdvWorker.Text = string.Empty;
            cdvWorker.Description = string.Empty;
            cdvLocation.Text = string.Empty;
            cdvLocation.Description = string.Empty;
            txtStartTime.Text = string.Empty;
            txtEndTime.Text = string.Empty;
            btnRestart.Enabled = false;
            btnClose.Enabled = false;



            //MPCF.SetFocus(txtTrayId);
        }


        private void Search_data()
        {

            txtStartTime.Text = "";
            txtEndTime.Text = "";

            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("WORKER", MPCF.Trim(cdvWorker.Text));
            in_node.AddString("LOCATION", MPCF.Trim(cdvLocation.Text));

            if (MPCF.CallService("CWIP", "CWIP_View_Repair_Insentive", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
            }

            vStartTime = out_node.GetString("START_TIME");
            txtStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
            txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));
            
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

            btnRestart.Enabled = false;
            btnProcess.Enabled = false;

            if (!CheckCondition("SEARCH"))
            {
                return;
            }
            Search_data();
        }

        private void cdvWorker_ValueChanged(object sender, EventArgs e)
        {
            set_button();
        }

        private void cdvLocation_ValueChanged(object sender, EventArgs e)
        {
            set_button();
        }

      

    }
}
