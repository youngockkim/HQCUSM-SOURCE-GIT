using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using System.Collections;

namespace BOI.OIFrx.BOIPopup
{
    public partial class frmCOMSetupEnv : frmPopupBase
    {
        public frmCOMSetupEnv()
        {
            InitializeComponent();
        }

        public frmCOMSetupEnv(int i_use_comport_cnt, string[] com)
        {
            
            InitializeComponent();

            i_com_port_count = i_use_comport_cnt;

            if (i_use_comport_cnt == 1)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort1", MPCF.Trim(com[0]));
            }
            else if (i_use_comport_cnt == 2)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort1", MPCF.Trim(com[0]));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort2", MPCF.Trim(com[1]));
            }
            else if (i_use_comport_cnt == 3)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort1", MPCF.Trim(com[0]));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort2", MPCF.Trim(com[1]));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort3", MPCF.Trim(com[2]));
            }
            else if (i_use_comport_cnt == 4)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort1", MPCF.Trim(com[0]));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort2", MPCF.Trim(com[1]));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort3", MPCF.Trim(com[2]));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort4", MPCF.Trim(com[3]));
            }
        }
        #region " Variable Definition "

        private bool b_load_flag;
        private int i_com_port_count = 4;

        #endregion


        #region " Funtion Definition "

        private void initPortSet(int port, SOIComboBox cbo_Port, SOIComboBox cbo_baud, SOIComboBox cbo_parity, SOIComboBox cbo_data, SOIComboBox cbo_stop)
        {
            cbo_Port.Items.Clear();
            cbo_baud.Items.Clear();
            cbo_parity.Items.Clear();
            cbo_data.Items.Clear();
            cbo_stop.Items.Clear();

            // Port 강제설정 (컴퓨터에 포트가 막혀서 자동 검색 기능 안됨)
            //cbo_Port.Items.Add("");

            for (int i = 1; i < 9; i++)
            {
                cbo_Port.Items.Add("COM" + i.ToString());
            }

            //cbo_Port.SelectedIndex = port - 1;

            // BaudRate Set
            cbo_baud.Items.Add("1200");
            cbo_baud.Items.Add("2400");
            cbo_baud.Items.Add("9600");
            cbo_baud.Items.Add("14400");
            cbo_baud.Items.Add("19200");
            cbo_baud.Items.Add("38400");
            cbo_baud.Items.Add("56000");
            cbo_baud.Items.Add("57600");
            cbo_baud.Items.Add("115200");

            cbo_baud.SelectedIndex = 2;

            // ParityBit Set
            cbo_parity.Items.Add("None");
            cbo_parity.Items.Add("Odd");
            cbo_parity.Items.Add("Even");
            cbo_parity.Items.Add("Mark");
            cbo_parity.Items.Add("Space");

            cbo_parity.SelectedIndex = 0;

            // DataBits Set
            cbo_data.Items.Add("5");
            cbo_data.Items.Add("6");
            cbo_data.Items.Add("7");
            cbo_data.Items.Add("8");

            cbo_data.SelectedIndex = 3;

            // StopBits Set
            cbo_stop.Items.Add("1");
            cbo_stop.Items.Add("1.5");
            cbo_stop.Items.Add("2");

            cbo_stop.SelectedIndex = 0;

        }

        // SetData_Space()
        //       -  
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        private bool SetData_Space(Control parentControl)
        {

            try
            {
                Control control;

                foreach (Control tempLoopVar_control in parentControl.Controls)
                {
                    if (tempLoopVar_control is ComboBox)
                    {
                        control = tempLoopVar_control;

                        control.Text = "";
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

        private void SetVisible()
        {
            if (i_com_port_count < 1)
            {
                grpComPort1.Visible = false;
                grpComPort2.Visible = false;
                grpComPort3.Visible = false;
                grpComPort4.Visible = false;
            }
            else if (i_com_port_count == 1)
            {
                grpComPort2.Visible = false;
                grpComPort3.Visible = false;
                grpComPort4.Visible = false;
            }
            else if (i_com_port_count == 2)
            {
                grpComPort3.Visible = false;
                grpComPort4.Visible = false;
            }
            else if (i_com_port_count == 3)
            {
                grpComPort4.Visible = false;
            }

        }

        private void FReadData(string s_port, string s_baud, string s_parity, string s_data, string s_stop,
                               SOIComboBox cbo_Port, SOIComboBox cbo_baud, SOIComboBox cbo_parity, SOIComboBox cbo_data, SOIComboBox cbo_stop)
        {
            //Scan Port
            for (int i = 0; i < cbo_Port.Items.Count; i++)
            {
                if (s_port == cbo_Port.Items[i].DataValue.ToString())
                {
                    cbo_Port.Value = cbo_Port.Items[i].DataValue;
                }
            }

            //Baud Rate
            if (s_baud.ToString().Trim() != string.Empty)
            {
                for (int i = 0; i < cbo_baud.Items.Count; i++)
                {
                    if (s_baud == cbo_baud.Items[i].DataValue.ToString())
                    {
                        cbo_baud.Value = cbo_baud.Items[i].DataValue;
                    }
                }
            }

            //Parity
            if (s_parity.ToString().Trim() != string.Empty)
            {
                for (int i = 0; i < cbo_parity.Items.Count; i++)
                {
                    if (s_parity == cbo_parity.Items[i].DataValue.ToString())
                    {
                        cbo_parity.Value = cbo_parity.Items[i].DataValue;
                    }
                }
            }

            //DataBits
            if (s_data.ToString().Trim() != string.Empty)
            {
                for (int i = 0; i < cbo_data.Items.Count; i++)
                {
                    if (s_data == cbo_data.Items[i].DataValue.ToString())
                    {
                        cbo_data.Value = cbo_data.Items[i].DataValue;
                    }
                }
            }

            //StopBits
            if (s_stop.ToString().Trim() != string.Empty)
            {
                for (int i = 0; i < cbo_stop.Items.Count; i++)
                {
                    if (s_stop == cbo_stop.Items[i].DataValue.ToString())
                    {
                        cbo_stop.Value = cbo_stop.Items[i].DataValue;
                    }
                }
            }
        }

        private bool ViewPrinterList()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        // ChkData()
        //       - Port Setup Item check 
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        private bool ChkData()
        {

            //if (MPCF.CheckValue(cboPort_1, 1) == false)
            //{
            //    //return false;
            //}

            if (MPCF.CheckValue(cboBaud_1, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(cboParity_1, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(cboData_1, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(cboStop_1, 1) == false)
            {
                return false;
            }
            
            return true;
        }

        #endregion



        private void btnView_Click(object sender, EventArgs e)
        {
            if (ChkData() == false)
            {
                return;
            }

            if (cboPort_1.Text.ToString().Trim() != "")
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort1", MPCF.Trim(cboPort_1.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMParity1", MPCF.Trim(cboParity_1.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMStopBits1", MPCF.Trim(cboStop_1.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMBaudRate1", MPCF.Trim(cboBaud_1.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMDataBits1", MPCF.Trim(cboData_1.Text.ToString().Trim()));
                BIGV.gsPortID1 = MPCF.Trim(cboPort_1.Text.ToString().Trim());
                BIGV.gsBaudRate1 = MPCF.Trim(cboBaud_1.Text.ToString().Trim());
                BIGV.gsParityBit1 = MPCF.Trim(cboParity_1.Text.ToString().Trim());
                BIGV.gsDataBits1 = MPCF.Trim(cboData_1.Text.ToString().Trim());
                BIGV.gsStopBits1 = MPCF.Trim(cboStop_1.Text.ToString().Trim());
            }

            if (cboPort_2.Text.ToString().Trim() != "")
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort2", MPCF.Trim(cboPort_2.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMParity2", MPCF.Trim(cboParity_2.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMStopBits2", MPCF.Trim(cboStop_2.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMBaudRate2", MPCF.Trim(cboBaud_2.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMDataBits2", MPCF.Trim(cboData_2.Text.ToString().Trim()));
                BIGV.gsPortID2 = MPCF.Trim(cboPort_2.Text.ToString().Trim());
                BIGV.gsBaudRate2 = MPCF.Trim(cboBaud_2.Text.ToString().Trim());
                BIGV.gsParityBit2 = MPCF.Trim(cboParity_2.Text.ToString().Trim());
                BIGV.gsDataBits2 = MPCF.Trim(cboData_2.Text.ToString().Trim());
                BIGV.gsStopBits2 = MPCF.Trim(cboStop_2.Text.ToString().Trim());
            }

            if (cboPort_3.Text.ToString().Trim() != "")
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort3", MPCF.Trim(cboPort_3.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMParity3", MPCF.Trim(cboParity_3.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMStopBits3", MPCF.Trim(cboStop_3.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMBaudRate3", MPCF.Trim(cboBaud_3.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMDataBits3", MPCF.Trim(cboData_3.Text.ToString().Trim()));
                BIGV.gsPortID3 = MPCF.Trim(cboPort_3.Text.ToString().Trim());
                BIGV.gsBaudRate3 = MPCF.Trim(cboBaud_3.Text.ToString().Trim());
                BIGV.gsParityBit3 = MPCF.Trim(cboParity_3.Text.ToString().Trim());
                BIGV.gsDataBits3 = MPCF.Trim(cboData_3.Text.ToString().Trim());
                BIGV.gsStopBits3 = MPCF.Trim(cboStop_3.Text.ToString().Trim());
            }

            if (cboPort_4.Text.ToString().Trim() != "")
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMPort4", MPCF.Trim(cboPort_4.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMParity4", MPCF.Trim(cboParity_4.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMStopBits4", MPCF.Trim(cboStop_4.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMBaudRate4", MPCF.Trim(cboBaud_4.Text.ToString().Trim()));
                MPCF.SaveRegSetting(Application.ProductName, "Option", "COMDataBits4", MPCF.Trim(cboData_4.Text.ToString().Trim()));
                BIGV.gsPortID4 = MPCF.Trim(cboPort_4.Text.ToString().Trim());
                BIGV.gsBaudRate4 = MPCF.Trim(cboBaud_4.Text.ToString().Trim());
                BIGV.gsParityBit4 = MPCF.Trim(cboParity_4.Text.ToString().Trim());
                BIGV.gsDataBits4 = MPCF.Trim(cboData_4.Text.ToString().Trim());
                BIGV.gsStopBits4 = MPCF.Trim(cboStop_4.Text.ToString().Trim());
            }

            this.Close();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCOMSetupEnv_Load(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {

                initPortSet(1, cboPort_1, cboBaud_1, cboParity_1, cboData_1, cboStop_1);
                initPortSet(2, cboPort_2, cboBaud_2, cboParity_2, cboData_2, cboStop_2);
                initPortSet(3, cboPort_3, cboBaud_3, cboParity_3, cboData_3, cboStop_3);
                initPortSet(4, cboPort_4, cboBaud_4, cboParity_4, cboData_4, cboStop_4);

                BIGV.gsPortID1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMPort1", ""));
                BIGV.gsBaudRate1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMBaudRate1", ""));
                BIGV.gsParityBit1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMParity1", ""));
                BIGV.gsDataBits1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMDataBits1", ""));
                BIGV.gsStopBits1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMStopBits1", ""));

                BIGV.gsPortID2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMPort2", ""));
                BIGV.gsBaudRate2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMBaudRate2", ""));
                BIGV.gsParityBit2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMParity2", ""));
                BIGV.gsDataBits2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMDataBits2", ""));
                BIGV.gsStopBits2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMStopBits2", ""));

                BIGV.gsPortID3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMPort3", ""));
                BIGV.gsBaudRate3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMBaudRate3", ""));
                BIGV.gsParityBit3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMParity3", ""));
                BIGV.gsDataBits3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMDataBits3", ""));
                BIGV.gsStopBits3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMStopBits3", ""));

                BIGV.gsPortID4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMPort4", ""));
                BIGV.gsBaudRate4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMBaudRate4", ""));
                BIGV.gsParityBit4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMParity4", ""));
                BIGV.gsDataBits4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMDataBits4", ""));
                BIGV.gsStopBits4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMStopBits4", ""));


                FReadData(BIGV.gsPortID1, BIGV.gsBaudRate1, BIGV.gsParityBit1, BIGV.gsDataBits1, BIGV.gsStopBits1, 
                          cboPort_1, cboBaud_1, cboParity_1, cboData_1, cboStop_1);

                FReadData(BIGV.gsPortID2, BIGV.gsBaudRate2, BIGV.gsParityBit2, BIGV.gsDataBits2, BIGV.gsStopBits2, 
                          cboPort_2, cboBaud_2, cboParity_2, cboData_2, cboStop_2);

                FReadData(BIGV.gsPortID3, BIGV.gsBaudRate3, BIGV.gsParityBit3, BIGV.gsDataBits3, BIGV.gsStopBits3, 
                          cboPort_3, cboBaud_3, cboParity_3, cboData_3, cboStop_3);

                FReadData(BIGV.gsPortID4, BIGV.gsBaudRate4, BIGV.gsParityBit4, BIGV.gsDataBits4, BIGV.gsStopBits4,
                          cboPort_4, cboBaud_4, cboParity_4, cboData_4, cboStop_4);

                
                SetVisible();

                b_load_flag = true;

            }
        }


    }
}
