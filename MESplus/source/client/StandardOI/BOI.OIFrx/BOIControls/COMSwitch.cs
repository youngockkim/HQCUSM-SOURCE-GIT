using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracom.TRSCore;
using SOI.MsgHandlerH101;
using SOI.OIFrx;
using System.Threading;
using SOI.CliFrx;
using Microsoft.Win32;
using BOI.OIFrx.BOIPopup;

namespace BOI.OIFrx.BOIControls
{
    public delegate void com_data(string aData);
    public partial class COMSwitch : UserControl
    {
        private COMPort Com_1 = new COMPort();
        private COMPort Com_2 = new COMPort();
        private COMPort Com_3 = new COMPort();
        private COMPort Com_4 = new COMPort();

        public event com_data Com_1_DataReceived;
        public event com_data Com_2_DataReceived;
        public event com_data Com_3_DataReceived;
        public event com_data Com_4_DataReceived;

        //private bool blnShown = false;
        
        private char on_check = ' ';

       
        Color OnColor;
        Color OffColor;

        
        public COMSwitch()
        {
            InitializeComponent();
            OnColor = Color.FromArgb(165, 195, 120);
            OffColor = Color.FromArgb(225, 100, 100);            
        }
        

        private void COMSwitch_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                RegistryKey serialcomm = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM");
                if (serialcomm == null)
                {                    
                    return;
                }
                Init_ScanPort();
                if (on_check == '1' || on_check == '2' || on_check == '3' || on_check == '4')
                {
                    //COM1
                    lblOnOffCOM1.Text = this.Com_1.PortName;
                    if (this.Com_1.IsOpen == true)
                    {
                        lblOnOffCOM1.Appearance.BackColor = OnColor;
                    }
                    else
                    {
                        lblOnOffCOM1.Appearance.BackColor = OffColor;
                    }
                }
                if (on_check == '2' || on_check == '3' || on_check == '4')
                {
                    //COM2
                    lblOnOffCOM2.Text = this.Com_2.PortName;
                    if (this.Com_2.IsOpen == true)
                    {
                        lblOnOffCOM2.Appearance.BackColor = OnColor;
                    }
                    else
                    {
                        lblOnOffCOM2.Appearance.BackColor = OffColor;
                    }
                }
                if (on_check == '3' || on_check == '4')
                {
                    //COM3
                    lblOnOffCOM3.Text = this.Com_3.PortName;
                    if (this.Com_3.IsOpen == true)
                    {
                        lblOnOffCOM3.Appearance.BackColor = OnColor;
                    }
                    else
                    {
                        lblOnOffCOM3.Appearance.BackColor = OffColor;
                    }
                }
                if (on_check == '4')
                {
                    //COM4
                    lblOnOffCOM4.Text = this.Com_4.PortName;
                    if (this.Com_4.IsOpen == true)
                    {
                        lblOnOffCOM4.Appearance.BackColor = OnColor;
                    }
                    else
                    {
                        lblOnOffCOM4.Appearance.BackColor = OffColor;
                    }
                }
                this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);

                //blnShown = true;
            }
            
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OffTuner();
        }

        public void OffTuner()
        {
            this.Com_1.Close();
            this.Com_2.Close();
            this.Com_3.Close();
            this.Com_4.Close();
        }

        
        //
        // Init_ScanPort()
        //       - Scan Port Setup
        // Return Value
        //       - 
        // Arguments
        //       -
        //
        private void Init_ScanPort()
        {
            try
            {
                on_check = '0';
                //COM 1
                BIGV.gsPortID1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMPort1", ""));
                BIGV.gsBaudRate1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMBaudRate1", ""));
                BIGV.gsParityBit1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMParity1", ""));
                BIGV.gsDataBits1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMDataBits1", ""));
                BIGV.gsStopBits1 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMStopBits1", ""));

                if (MPCF.Trim(BIGV.gsPortID1) == "")
                {
                    return;
                }
                if (this.Com_1.IsOpen)
                {
                    this.Com_1.Close();
                }
                
                this.Com_1.PortName = BIGV.gsPortID1;
                this.Com_1.BaudRate = MPCF.ToInt(BIGV.gsBaudRate1);
                this.Com_1.DataBits = MPCF.ToInt(BIGV.gsDataBits1);

                switch (MPCF.Trim(BIGV.gsParityBit1.ToString().ToUpper()))
                {
                    case "NONE":
                        this.Com_1.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "ODD":
                        this.Com_1.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "EVEN":
                        this.Com_1.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "MARK":
                        this.Com_1.Parity = System.IO.Ports.Parity.Mark;
                        break;
                    case "SPACE":
                        this.Com_1.Parity = System.IO.Ports.Parity.Space;
                        break;
                }

                switch (MPCF.Trim(BIGV.gsStopBits1.ToString().ToUpper()))
                {
                    case "1":
                        this.Com_1.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "1.5":
                        this.Com_1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "2":
                        this.Com_1.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                }

                this.Com_1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Com_1_a_DataReceived);
                this.Com_1.ReadTimeout = 500;
                this.Com_1.Open();
                lblOnOffCOM1.Visible = true;
                on_check = '1';
                //COM 2
                BIGV.gsPortID2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMPort2", ""));
                BIGV.gsBaudRate2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMBaudRate2", ""));
                BIGV.gsParityBit2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMParity2", ""));
                BIGV.gsDataBits2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMDataBits2", ""));
                BIGV.gsStopBits2 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMStopBits2", ""));

                if (MPCF.Trim(BIGV.gsPortID2) == "")
                {

                    return;
                }
                if (this.Com_2.IsOpen)
                {
                    this.Com_2.Close();
                }

                this.Com_2.PortName = BIGV.gsPortID2;
                this.Com_2.BaudRate = MPCF.ToInt(BIGV.gsBaudRate2);
                this.Com_2.DataBits = MPCF.ToInt(BIGV.gsDataBits2);

                switch (MPCF.Trim(BIGV.gsParityBit2.ToString().ToUpper()))
                {
                    case "NONE":
                        this.Com_2.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "ODD":
                        this.Com_2.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "EVEN":
                        this.Com_2.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "MARK":
                        this.Com_2.Parity = System.IO.Ports.Parity.Mark;
                        break;
                    case "SPACE":
                        this.Com_2.Parity = System.IO.Ports.Parity.Space;
                        break;
                }

                switch (MPCF.Trim(BIGV.gsStopBits2.ToString().ToUpper()))
                {
                    case "1":
                        this.Com_2.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "1.5":
                        this.Com_2.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "2":
                        this.Com_2.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                }

                this.Com_2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Com_2_a_DataReceived);
                this.Com_2.ReadTimeout = 500;
                this.Com_2.Open();
                lblOnOffCOM2.Visible = true;
                on_check = '2';

                //COM 3
                BIGV.gsPortID3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMPort3", ""));
                BIGV.gsBaudRate3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMBaudRate3", ""));
                BIGV.gsParityBit3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMParity3", ""));
                BIGV.gsDataBits3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMDataBits3", ""));
                BIGV.gsStopBits3 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMStopBits3", ""));

                if (MPCF.Trim(BIGV.gsPortID3) == "")
                {

                    return;
                }
                if (this.Com_3.IsOpen)
                {
                    this.Com_3.Close();
                }

                this.Com_3.PortName = BIGV.gsPortID3;
                this.Com_3.BaudRate = MPCF.ToInt(BIGV.gsBaudRate3);
                this.Com_3.DataBits = MPCF.ToInt(BIGV.gsDataBits3);

                switch (MPCF.Trim(BIGV.gsParityBit3.ToString().ToUpper()))
                {
                    case "NONE":
                        this.Com_3.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "ODD":
                        this.Com_3.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "EVEN":
                        this.Com_3.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "MARK":
                        this.Com_3.Parity = System.IO.Ports.Parity.Mark;
                        break;
                    case "SPACE":
                        this.Com_3.Parity = System.IO.Ports.Parity.Space;
                        break;
                }

                switch (MPCF.Trim(BIGV.gsStopBits3.ToString().ToUpper()))
                {
                    case "1":
                        this.Com_3.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "1.5":
                        this.Com_3.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "2":
                        this.Com_3.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                }

                this.Com_3.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Com_3_a_DataReceived);
                this.Com_3.ReadTimeout = 500;
                this.Com_3.Open();
                lblOnOffCOM3.Visible = true;
                on_check = '3';

                //COM 4
                BIGV.gsPortID4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMPort4", ""));
                BIGV.gsBaudRate4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMBaudRate4", ""));
                BIGV.gsParityBit4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMParity4", ""));
                BIGV.gsDataBits4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMDataBits4", ""));
                BIGV.gsStopBits4 = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "COMStopBits4", ""));

                if (MPCF.Trim(BIGV.gsPortID4) == "")
                {

                    return;
                }
                if (this.Com_4.IsOpen)
                {
                    this.Com_4.Close();
                }

                this.Com_4.PortName = BIGV.gsPortID4;
                this.Com_4.BaudRate = MPCF.ToInt(BIGV.gsBaudRate4);
                this.Com_4.DataBits = MPCF.ToInt(BIGV.gsDataBits4);

                switch (MPCF.Trim(BIGV.gsParityBit4.ToString().ToUpper()))
                {
                    case "NONE":
                        this.Com_4.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "ODD":
                        this.Com_4.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "EVEN":
                        this.Com_4.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "MARK":
                        this.Com_4.Parity = System.IO.Ports.Parity.Mark;
                        break;
                    case "SPACE":
                        this.Com_4.Parity = System.IO.Ports.Parity.Space;
                        break;
                }

                switch (MPCF.Trim(BIGV.gsStopBits4.ToString().ToUpper()))
                {
                    case "1":
                        this.Com_4.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "1.5":
                        this.Com_4.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "2":
                        this.Com_4.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                }

                this.Com_4.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Com_4_a_DataReceived);
                this.Com_4.ReadTimeout = 500;
                this.Com_4.Open();
                lblOnOffCOM4.Visible = true;
                on_check = '4';

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        //
        // Close_ScanPort()
        //       - Scan Port Close
        // Return Value
        //       - 
        // Arguments
        //       -
        //
        private void Close_ScanPort()
        {
            if (this.Com_1.IsOpen)
            {
                this.Com_1.Close();
            }
            if (this.Com_2.IsOpen)
            {
                this.Com_2.Close();
            }
            if (this.Com_3.IsOpen)
            {
                this.Com_3.Close();
            }
            if (this.Com_4.IsOpen)
            {
                this.Com_4.Close();
            }
        }

        public void Com_1_a_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(500);
                string data = "";

                data = MPCF.Trim(this.Com_1.ReadExisting());
                if (data.Length == 20) //ck200
                {
                    data = MPCF.Trim(data.Substring(10, data.Length - 13));
                }
                else if (data.Length == 18) //ec-d kg
                {
                    data = MPCF.Trim(data.Substring(7, data.Length - 9));
                }
                else if (data.Length == 17) // ec-d g
                {
                    data = MPCF.Trim(data.Substring(7, data.Length - 8));
                }
                if (MPCF.Trim(data) == "")
                    return;

                this.Invoke(Com_1_DataReceived, data);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void Com_2_a_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(500);
                string data = "";

                data = MPCF.Trim(this.Com_2.ReadExisting());

                if (MPCF.Trim(data) == "")
                    return;

                this.Invoke(Com_2_DataReceived, data);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }



        private void Com_3_a_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(500);
                string data = "";

                data = MPCF.Trim(this.Com_3.ReadExisting());

                if (MPCF.Trim(data) == "")
                    return;

                this.Invoke(Com_3_DataReceived, data);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }



        private void Com_4_a_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(500);
                string data = "";

                data = MPCF.Trim(this.Com_4.ReadExisting());

                if (MPCF.Trim(data) == "")
                    return;

                this.Invoke(Com_4_DataReceived, data);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            try
            {
                MenuInfoTag selectedMenuInfo;
                
                RegistryKey serialcomm = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM");
                if (serialcomm == null)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(471), MSG_LEVEL.ERROR, true);
                    return;
                }
                int com_count = serialcomm.ValueCount;
                string[] com = new string[com_count];
                com = serialcomm.GetValueNames();
                string[] com_value = new string[com_count];
                for(int i =  0; i< com_count; i++)
                {
                    com_value[i] = serialcomm.GetValue(@com[i]).ToString();

                }
                frmCOMSetupEnv frm = new frmCOMSetupEnv(com_count, com_value);
                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "Setup Environment";
                frm.Tag = selectedMenuInfo;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Close_ScanPort();
                    Init_ScanPort();
                    if (on_check == '1' || on_check == '2' || on_check == '3' || on_check == '4')
                    {
                        //COM1
                        lblOnOffCOM1.Text = this.Com_1.PortName;
                        if (this.Com_1.IsOpen == true)
                        {
                            lblOnOffCOM1.Appearance.BackColor = OnColor;
                        }
                        else
                        {
                            lblOnOffCOM1.Appearance.BackColor = OffColor;
                        }
                    }
                    if (on_check == '2' || on_check == '3' || on_check == '4')
                    {
                        //COM2
                        lblOnOffCOM2.Text = this.Com_2.PortName;
                        if (this.Com_2.IsOpen == true)
                        {
                            lblOnOffCOM2.Appearance.BackColor = OnColor;
                        }
                        else
                        {
                            lblOnOffCOM2.Appearance.BackColor = OffColor;
                        }
                    }
                    if (on_check == '3' || on_check == '4')
                    {
                        //COM3
                        lblOnOffCOM3.Text = this.Com_3.PortName;
                        if (this.Com_3.IsOpen == true)
                        {
                            lblOnOffCOM3.Appearance.BackColor = OnColor;
                        }
                        else
                        {
                            lblOnOffCOM3.Appearance.BackColor = OffColor;
                        }
                    }
                    if (on_check == '4')
                    {
                        //COM4
                        lblOnOffCOM4.Text = this.Com_4.PortName;
                        if (this.Com_4.IsOpen == true)
                        {
                            lblOnOffCOM4.Appearance.BackColor = OnColor;
                        }
                        else
                        {
                            lblOnOffCOM4.Appearance.BackColor = OffColor;
                        }
                    }
                    this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);

                    //blnShown = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

 

    }
}
