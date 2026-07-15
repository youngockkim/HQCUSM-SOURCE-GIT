using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Miracom.TRSCore;
using SOI.OIFrx;
using System.Windows.Forms;
using SOI.CliFrx;
using System.Collections;
using SOI.MsgHandlerH101;
namespace BOI.OIFrx.BOIControls
{

    public delegate void H101DataReceivedEventHandler(object sender, H101DataReceivedEventArgs e);
    public class H101Tuner : IDisposable, ServiceDispatcher
    {        
        public event H101DataReceivedEventHandler DataReceived = null;

        private bool disposed = false;
        private string _channel = string.Empty;
        private string _module = string.Empty;
        private string _serviceName = string.Empty;
        private bool _isTuned = false;
        private bool _multiCast = true;
        private bool _useRandomChannel = false;
        private string _randomChannelValue = string.Empty;

       
        
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

        public bool isTuned
        {
            get { return _isTuned; }
        }

        public bool UseRandomChannel
        {
            get { return _useRandomChannel; }
            set 
            { 
                _useRandomChannel = value;               
            }
        }
       

        public H101Tuner()
        {
            
        }


        //----------------------------------------------------------------------------------------------------

        private void myDispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //UnTune
                    PublishCUSMsgUnTune();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            myDispose(true);                        
            GC.SuppressFinalize(this);
        }

 

        public bool PublishCUSMsgTune()
        {

            try
            {
                string sPublishChannel = "";
                if (_useRandomChannel == true)
                {
                    if (BICF.GetRandomChannelValue(out _randomChannelValue) == false)
                    {
                        MPCF.ShowMessage("PublishCUSMsgTune() Failed. " + MPCF.GetMessage(413), MSG_LEVEL.ERROR, true);
                    }
                }
                

                sPublishChannel = "/" + MPGV.gsSiteID;
                if (_useRandomChannel == true)
                {
                    _module += _randomChannelValue;
                }
                sPublishChannel += "/" + _module;                
                sPublishChannel += "/" + MPGV.gsFactory;
                if (_useRandomChannel == true)
                {
                    _channel += "/" + _randomChannelValue;
                }
                sPublishChannel += "/" + _channel;
               
               

                if (CheckTuneStatus(_module, _channel) == false)
                {
                    MPMH.registerDispatcher(_module, this);
                    if (true != MPMH.tune(sPublishChannel, _multiCast, false))
                    {
                        MPCF.ShowMessage("Message Tuning " + MPMH.StatusMessage, MSG_LEVEL.ERROR, true);
                        return false;
                    }

                    _isTuned = true;
                }
                else
                {
                    //MPCF.ShowMessage("PublishCUSMsgTune() Failed. " + MPCF.GetMessage(413), MSG_LEVEL.ERROR, true);
                    return false;
                }

                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("PublishCUSMsgTune() Failed. " + ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }

            return true;
        }

        public bool PublishCUSMsgUnTune()
        {

            try
            {
                string srandomChannelValue = string.Empty;
                string sPublishChannel;

                sPublishChannel = "/" + MPGV.gsSiteID;
                //if (_useRandomChannel == true)
                //{
                //    _module += _randomChannelValue;
                //}
                sPublishChannel += "/" + _module;                
                sPublishChannel += "/" + MPGV.gsFactory;
                //if (_useRandomChannel == true)
                //{
                //    _channel += "/" + _randomChannelValue;
                //}
                sPublishChannel += "/" + _channel;               
                
                MPMH.untune(sPublishChannel, _multiCast, false);
                MPMH.unregisterDispatcher(_module);

                if (_useRandomChannel == true)
                {
                    BICF.RemoveRandomChannelValue(_randomChannelValue);
                }

                _isTuned = false;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("PublishCUSMsgUnTune() Failed." + ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }

            return true;

        }

        /// <summary>
        /// 채널 명(module)으로 등록된 Dispatcher를 검색합니다.
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        private bool CheckTuneStatus(string module, string channel)
        {
            try
            {
                bool TuneStatusOn = false;
                Hashtable ht = MPMH.Instance.getDispatcher();

                if (ht.Count > 0
                    && ht.Contains(module))
                {
                    TuneStatusOn = true;                    
                }

                return TuneStatusOn;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return true;
            }
        }

        public bool dispatch(string s_service_name, TRSNode in_node, TRSNode out_node)
        {
            if (this._serviceName == s_service_name)
            {
                OnDataReceived(in_node, out_node);
            }
            else
            {
                in_node.AddChar("_SERVICE_NAME_DIFF", 'Y');
                OnDataReceived(in_node, out_node);                
                
            }
            
            return true;
        }


        public void OnDataReceived(TRSNode in_node, TRSNode out_node)
        {
            try
            {
                if (DataReceived != null)
                {
                    DataReceived(this, new H101DataReceivedEventArgs(in_node, out_node));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
           
        }

     
    }

    public class H101DataReceivedEventArgs
    {
        private string _serviceName = string.Empty;
        private TRSNode _node = null;

        public TRSNode Node
        {
            get { return _node; }
            set { _node = value; }
        }

        private TRSNode _outNode = null;

        public TRSNode OutNode
        {
            get { return _outNode; }
            set { _outNode = value; }
        }

        public H101DataReceivedEventArgs(TRSNode in_node, TRSNode out_node)
        {
            this._node = in_node;
            this._outNode = out_node;
        }


        public void Dispose()
        {            
            GC.SuppressFinalize(this);
        }
    }
}


