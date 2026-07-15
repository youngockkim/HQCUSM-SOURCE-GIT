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
using System.Net;
using System.Net.Sockets;
using SOI.CliFrx;
namespace BOI.OIFrx.BOIControls
{

    public delegate void StatusBarDataReceivedHandler(TRSNode node);    
    public partial class H101TunerStatusBar : UserControl
    {
        public event StatusBarDataReceivedHandler H101MsgDataReceived;
        private H101Tuner h101Tuner = null;

        //bool blnShown = false;
        private bool tunerOn = true;
        public bool TunerOn
        {
            get { return tunerOn; }
            set 
            { 
                tunerOn = value;
                if (tunerOn == true)
                {
                    lblOnOff.Appearance.BackColor = OnColor;
                }
                else
                {
                    lblOnOff.Appearance.BackColor = OffColor;
                }
            }
        }

        private bool useGcmEnv = true;
        public bool UseGcmEnv
        {
            get { return useGcmEnv; }
            set { useGcmEnv = value; }
        }

        private string _tunerName = string.Empty;

        public string TunerName
        {
            get { return _tunerName; }
            set { _tunerName = value; }
        }

        private string _lineId = string.Empty;

        public string LineId
        {
            get { return _lineId; }
            set { _lineId = value; }
        }

        private string _lineDesc = string.Empty;

        public string LineDesc
        {
            get { return _lineDesc; }
            set { _lineDesc = value; }
        }

        private string _oper = string.Empty;

        public string Oper
        {
            get { return _oper; }
            set { _oper = value; }
        }

        private string _operDesc = string.Empty;

        public string OperDesc
        {
            get { return _operDesc; }
            set { _operDesc = value; }
        }

        private string _resId = string.Empty;

        public string ResId
        {
            get { return _resId; }
            set { _resId = value; }
        }

        private string _resDesc = string.Empty;

        public string ResDesc
        {
            get { return _resDesc; }
            set { _resDesc = value; }
        }

        private string _ipAddr = string.Empty;

        public string IpAddr
        {
            get { return _ipAddr; }
            set { _ipAddr = value; }
        }

        Color OnColor;
        Color OffColor;        
        private string _channel = string.Empty;
        private string _module = string.Empty;
        private string _serviceName = string.Empty;
        private bool _multiCast = true;
        private bool _useIPAssress = true;              

        public string Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        public string Module
        {
            get { return _module; }
            set { _module = value; }
        }


        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }

        public bool MultiCast
        {
            get { return _multiCast; }
            set { _multiCast = value; }
        }

        public bool UseIPAssress
        {
            get { return _useIPAssress; }
            set { _useIPAssress = value; }
        }

        public H101TunerStatusBar()
        {
            InitializeComponent();         
            this.h101Tuner = new H101Tuner();
            this.h101Tuner.DataReceived += new H101DataReceivedEventHandler(h101Tuner_DataReceived);                
            this.OnColor = Color.FromArgb(165, 195, 120);
            this.OffColor = Color.FromArgb(225, 100, 100);
            
            
        }
        

        private void H101TunerStatusBar_Load(object sender, EventArgs e)
        {
            
            if (!DesignMode)
            {
                this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
                GetDefaultValueFromReg();

                if (useGcmEnv == true)
                {
                    if (GetH101TunerEnvironment(this._tunerName) == false)
                    {                        
                        lblOnOff.Appearance.BackColor = OffColor;
                        lblOnOff.Text = "H101";
                        return;
                    }
                    this.h101Tuner.Channel = _channel;
                    this.h101Tuner.Module = _module;
                    this.h101Tuner.ServiceName = _serviceName;
                    this.h101Tuner.MultiCast = _multiCast;
                }
                else
                {
                    this.h101Tuner.Channel = _channel;
                    this.h101Tuner.Module = _module;
                    this.h101Tuner.ServiceName = _serviceName;
                    this.h101Tuner.MultiCast = _multiCast;                    
                }



                if (h101Tuner.Channel != string.Empty &&
                    h101Tuner.Module != string.Empty &&                    
                    tunerOn == true)
                {

                    if (h101Tuner.PublishCUSMsgTune() == false)
                    {
                        lblOnOff.Appearance.BackColor = OffColor;
                        lblOnOff.Text = "H101";
                    }
                    else
                    {
                        lblOnOff.Appearance.BackColor = OnColor;
                        lblOnOff.Text = _channel;
                    }

                }
                else
                {
                    lblOnOff.Appearance.BackColor = OffColor;
                    lblOnOff.Text = "H101";
                    //MPCF.ShowMessage(MPCF.GetMessage(143), SOI.CliFrx.MSG_LEVEL.ERROR, false);                    
                }

                

                //blnShown = true;
            }
            
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetDefaultValueToReg();
            OffTuner();
        }
      
        
        private void h101Tuner_DataReceived(object sender, H101DataReceivedEventArgs e)
        {
            //if (e.Node.GetChar("_SERVICE_NAME_DIFF") == 'Y')
            //{
            //    this.Invoke(new MethodInvoker(
            //            () =>
            //            {
            //                //서비스명 불일치 DEBUGING 사용
            //                //MPCF.ShowMessage("서비스명이 일치하지 않습니다.", SOI.CliFrx.MSG_LEVEL.ERROR, true);
            //            }
            //        )
            //    );
            //}
            //else
            //{
            //    IAsyncResult r = BeginInvoke(H101MsgDataReceived, e.Node);
            //    EndInvoke(r);
            //}

            IAsyncResult r = BeginInvoke(H101MsgDataReceived, e.Node);
            EndInvoke(r);
        }
       

       

        private void lblOnOff_TextChanged(object sender, EventArgs e)
        {
            Size textSize = TextRenderer.MeasureText(lblOnOff.Text, lblOnOff.Font);
            textSize.Width += 10;
            if (((Control)this).Parent.Size.Width < textSize.Width)
            {
                ((Control)this).Parent.Size = textSize;
            }
            
        }

        private void lblOnOff_Click(object sender, EventArgs e)
        {
            try
            {
                string tunnerName = "";
                //Tunner 환경설정 창 오픈
                Popup.frmH101SetupEnv frm = new Popup.frmH101SetupEnv();
                frm.Line = _lineId;
                frm.LineDesc = _lineDesc;
                frm.Oper = _oper;
                frm.OperDesc = _operDesc;
                frm.ResId = _resId;
                frm.ResDesc = _resDesc;
                frm.UseIpAddress = _useIPAssress;
                DialogResult rtn = frm.ShowDialog(this);
                if (rtn == DialogResult.OK && frm.Oper != string.Empty)
                {
                    _lineId = frm.Line;
                    _lineDesc = frm.LineDesc;
                    _oper = frm.Oper;
                    _operDesc = frm.OperDesc;
                    _resId = frm.ResId;
                    _resDesc = frm.ResDesc;
                    _useIPAssress = frm.UseIpAddress;

                    tunnerName = _oper;
                    tunnerName += "/";
                    tunnerName += _resId;
                    if (_useIPAssress == true)
                    {
                        tunnerName += "/";
                        tunnerName += BIGV.gslocalIpAddress;
                    }

                    OffTuner();
                    if (GetH101TunerEnvironment(tunnerName))
                    {
                        this.h101Tuner.Channel = _channel;
                        this.h101Tuner.Module = _module;
                        this.h101Tuner.ServiceName = _serviceName;
                        this.h101Tuner.MultiCast = _multiCast;
                        OnTuner();
                    }
                    else
                    {
                        this.h101Tuner.Channel = "";
                        this.h101Tuner.Module = "";
                        this.h101Tuner.ServiceName = "";
                        this.h101Tuner.MultiCast = false;
                        lblOnOff.Appearance.BackColor = OffColor;
                        lblOnOff.Text = "H101";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        #region Function

        public void OffTuner()
        {
            this.h101Tuner.PublishCUSMsgUnTune();
        }

        public bool OnTuner()
        {
            if (h101Tuner.Channel != string.Empty &&
                h101Tuner.Module != string.Empty)
            {

                if (h101Tuner.PublishCUSMsgTune() == false)
                {
                    lblOnOff.Appearance.BackColor = OffColor;
                    lblOnOff.Text = "H101";
                    return false;
                }
                else
                {
                    lblOnOff.Appearance.BackColor = OnColor;
                    lblOnOff.Text = _channel;
                    return true;
                }
            }
            else
            {
                MPCF.ShowMessage(MPCF.GetMessage(104), SOI.CliFrx.MSG_LEVEL.ERROR, false);
                lblOnOff.Appearance.BackColor = OffColor;
                lblOnOff.Text = "H101";
                return false;
            }
        }

        public void RestartTuner()
        {
            if (GetH101TunerEnvironment(this._tunerName) == true)
            {
                OffTuner();
                OnTuner();
            }
        }

        public bool GetH101TunerEnvironment(string tunerName)
        {
            try
            {
                string channel = string.Empty;
                string module = string.Empty;
                string serviceName = string.Empty;
                bool multiCast = false;


                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_H101_TUNER_ENV));
                in_node.AddString("KEY_1", tunerName);

                if (MPCF.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("DATA_1")) == string.Empty)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(449), MSG_LEVEL.WARNING, false);
                    return false;
                }

                channel += MPCF.Trim(out_node.GetString("DATA_1"));
                if (MPCF.Trim(out_node.GetString("DATA_2")) != string.Empty)
                {
                    channel += "/";
                    channel += MPCF.Trim(out_node.GetString("DATA_2"));
                }
                if (MPCF.Trim(out_node.GetString("DATA_3")) != string.Empty)
                {
                    channel += "/";
                    channel += MPCF.Trim(BIGV.gslocalIpAddress);
                }


                module = MPCF.Trim(out_node.GetString("DATA_1")) + MPCF.Trim(out_node.GetString("DATA_2"));
                serviceName = MPCF.Trim(out_node.GetString("DATA_4"));
                multiCast = MPCF.Trim(out_node.GetString("DATA_5")) == "Y" ? true : false;

                _channel = channel;
                _module = module;
                _serviceName = serviceName;
                _multiCast = multiCast;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        public bool GetH101TunerEnvironment(string oper, string resId)
        {
            try
            {
                string channel = string.Empty;
                string module = string.Empty;
                string serviceName = string.Empty;
                bool multiCast = false;

                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_H101_TUNER_ENV));
                in_node.AddString("DATA_1", oper);
                in_node.AddString("DATA_2", resId);
                if (_useIPAssress == true)
                {
                    in_node.AddString("DATA_3", BIGV.gslocalIpAddress);
                }
                else
                {
                    in_node.AddString("DATA_3", "");
                }


                if (MPCF.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("DATA_1")) == string.Empty)
                {
                    return false;
                }

                channel += MPCF.Trim(out_node.GetString("DATA_1"));
                if (MPCF.Trim(out_node.GetString("DATA_2")) != string.Empty)
                {
                    channel += "/";
                    channel += MPCF.Trim(out_node.GetString("DATA_2"));
                }
                if (MPCF.Trim(out_node.GetString("DATA_3")) != string.Empty)
                {
                    channel += "/";
                    channel += MPCF.Trim(BIGV.gslocalIpAddress);
                }


                module = MPCF.Trim(out_node.GetString("DATA_1")) + MPCF.Trim(out_node.GetString("DATA_2"));
                serviceName = MPCF.Trim(out_node.GetString("DATA_4"));
                multiCast = MPCF.Trim(out_node.GetString("DATA_5")) == "Y" ? true : false;

                _channel = channel;
                _module = module;
                _serviceName = serviceName;
                _multiCast = multiCast;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        public void GetDefaultValueFromReg()
        {
            try
            {
                string tunnerName = string.Empty;
                string useIp = string.Empty;
                _lineId = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "LINE_ID"));
                _lineDesc = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "LINE_DESC"));

                _oper = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "OPER"));
                _operDesc = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "OPER_DESC"));

                _resId = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "RES_ID"));
                _resDesc = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "RES_DESC"));

                useIp = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "USE_IP_ADDRESS"));
                if (useIp == "true")
                {
                    _useIPAssress = true;
                }
                else
                {
                    _useIPAssress = false;
                }

                if (_oper != string.Empty)
                {
                    tunnerName = _oper;
                    tunnerName += "/";
                    tunnerName += _resId;
                    if (_useIPAssress == true)
                    {
                        tunnerName += "/";
                        tunnerName += BIGV.gslocalIpAddress;
                    }
                    this._tunerName = tunnerName;
                    useGcmEnv = true;
                }
                else
                {
                    useGcmEnv = false;
                    this._tunerName = string.Empty;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void SetDefaultValueToReg()
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "LINE_ID", MPCF.Trim(_lineId));
                MPCF.SaveRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "LINE_DESC", MPCF.Trim(_lineDesc));

                MPCF.SaveRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "OPER", MPCF.Trim(_oper));
                MPCF.SaveRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "OPER_DESC", MPCF.Trim(_operDesc));

                MPCF.SaveRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "RES_ID", MPCF.Trim(_resId));
                MPCF.SaveRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "RES_DESC", MPCF.Trim(_resDesc));

                MPCF.SaveRegSetting(Application.ProductName, this.ParentForm.Name + "_" + this.Name, "USE_IP_ADDRESS", MPCF.Trim(_useIPAssress.ToString()));                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        #endregion
    }
   
}

