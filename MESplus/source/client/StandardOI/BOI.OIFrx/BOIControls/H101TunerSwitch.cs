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
namespace BOI.OIFrx.BOIControls
{

    public delegate void DataReceivedHandler(TRSNode node);    
    public partial class H101TunerSwitch : UserControl
    {        
        public event DataReceivedHandler DataReceived;
        private H101Tuner h101Tuner = null;

        private bool tunerOn = false;
        private bool blnShown = false;

        public bool TunerOn
        {
            get { return tunerOn; }
            set 
            { 
                tunerOn = value;
                if (tunerOn == true)
                {
                    chkTunerOnOff.OnOffState = SOI.OIFrx.SOICheckBoxOnOffState.OnState;
                    lblOnOff.Appearance.BackColor = OnColor;
                }
                else
                {
                    chkTunerOnOff.OnOffState = SOI.OIFrx.SOICheckBoxOnOffState.OffState;
                    lblOnOff.Appearance.BackColor = OffColor;
                }
            }
        }

        Color OnColor;
        Color OffColor;        
        private string _channel = string.Empty;
        private string _module = string.Empty;
        private string _serviceName = string.Empty;
        private bool _multiCast = true;

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

        public H101TunerSwitch()
        {
            InitializeComponent();
            this.h101Tuner = new H101Tuner();
            h101Tuner.DataReceived += new H101DataReceivedEventHandler(h101Tuner_DataReceived);
            OnColor = Color.FromArgb(165, 195, 120);
            OffColor = Color.FromArgb(225, 100, 100);            
        }
        

        private void H101TunerSwitch_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                this.h101Tuner.Channel = _channel;
                this.h101Tuner.Module = _module;
                this.h101Tuner.ServiceName = _serviceName;
                this.h101Tuner.MultiCast = _multiCast;

                if (chkTunerOnOff.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OnState &&
                    h101Tuner.Channel != string.Empty &&
                    h101Tuner.Module != string.Empty &&
                    h101Tuner.ServiceName != string.Empty &&
                    tunerOn == true)
                {
                    chkTunerOnOff.OnOffState = SOI.OIFrx.SOICheckBoxOnOffState.OnState;
                    if (h101Tuner.PublishCUSMsgTune() == false)
                    {
                        chkTunerOnOff.OnOffState = SOICheckBoxOnOffState.OffState;
                        lblOnOff.Appearance.BackColor = OffColor;
                    }
                         
                }

                this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);

                blnShown = true;
            }
            
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OffTuner();
        }
      
        
        private void h101Tuner_DataReceived(object sender, H101DataReceivedEventArgs e)
        {
            if (e.Node.GetChar("_SERVICE_NAME_DIFF") == 'Y')
            {
                this.Invoke(new MethodInvoker(
                        () =>
                        {
                            //서비스명 불일치 DEBUGING 사용
                            //MPCF.ShowMessage("서비스명이 일치하지 않습니다.", SOI.CliFrx.MSG_LEVEL.ERROR, true);
                        }
                    )
                );
            }
            else
            {
                IAsyncResult r = BeginInvoke(DataReceived, e.Node);
                EndInvoke(r);
            }
        }

        private void chkTunerOnOff_OnOffStateChanged(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (this.blnShown == true)
                {
                    if (chkTunerOnOff.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OnState &&
                        this.h101Tuner.Channel != string.Empty &&
                        this.h101Tuner.Module != string.Empty &&
                        this.h101Tuner.ServiceName != string.Empty)
                    {
                        if (this.h101Tuner.PublishCUSMsgTune() == false)
                        {
                            chkTunerOnOff.OnOffState = SOICheckBoxOnOffState.OffState;
                            lblOnOff.Appearance.BackColor = OffColor;
                        }
                        else
                        {
                            lblOnOff.Appearance.BackColor = OnColor;
                        }
                    }
                    else
                    {
                        this.h101Tuner.PublishCUSMsgUnTune();
                        lblOnOff.Appearance.BackColor = OffColor;
                    }
                }
            }
        }

        public void OffTuner()
        {
            this.h101Tuner.PublishCUSMsgUnTune();
        }
    }
}
