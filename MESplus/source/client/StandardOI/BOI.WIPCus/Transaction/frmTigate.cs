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
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx.BOIControls;
using SOI.MsgHandlerH101;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTigate : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private H101Tuner h101tuner = new H101Tuner();
        private delegate void H101DataReceived(TRSNode node, TRSNode out_node);
        private H101DataReceived h101DataRecevied;
        MessageHandler msgHandler = new MessageHandler();  

        #endregion

        #region Constructor

        public frmTigate()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            h101DataRecevied += new H101DataReceived(OnH101DataReceived);
            h101tuner.DataReceived += new H101DataReceivedEventHandler(h101tuner_DataReceived);
            h101tuner.Module = "EISMC";
            h101tuner.Channel = "TIGATE2";
            h101tuner.MultiCast = false;
            h101tuner.PublishCUSMsgTune();
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        private void h101tuner_DataReceived(object sender, H101DataReceivedEventArgs e)
        {
            IAsyncResult r = BeginInvoke(h101DataRecevied, e.Node, e.OutNode);
            EndInvoke(r);
        }

        

        #endregion

        #region Function
        private void OnH101DataReceived(TRSNode node, TRSNode out_node)
        {
            try
            {
                if (node.GetString("_SERVICE_NAME") == "BEIS_Request_Resource_Data")
                {                    
                    string sValue = string.Empty;
                    string mInXmlString = string.Empty;
                    string in_msg = string.Empty;
                    try
                    {
                        sValue = MPCF.Trim(txtValue.Text);
                        node.SetString("VALUE", sValue);
                        out_node.SetString("VALUE", sValue);

                        //if (MPCF.CallService("BEIS", "BEIS_Reply_Resource_Data", node, SOI.MsgHandlerH101.DeliveryMode.Unicast, false) == false)
                        //{
                        //    return;
                        //}

                        MessageHandler messagehandler = new MessageHandler();

                        messagehandler.init("TIGATE", com.miracom.transceiverx.session.Session_Fields.SESSION_INNER_STATION_MODE | com.miracom.transceiverx.session.Session_Fields.SESSION_PULL_DELIVERY_MODE, "10.7.11.172:10101", 1334);
                        com.miracom.transceiverx.message.Message msg = MPMH.Instance.createMessage();
                        //필수 항목

                        msg.setProperty(MessageConst.XGEN_TAG_VERSION, MessageConst.XGEN_VERSION);
                        msg.setProperty(MessageConst.XGEN_TAG_MODULE, "MESPLUS");
                        msg.setProperty(MessageConst.XGEN_TAG_INTERFACE, "MESPLUS");
                        msg.setProperty(MessageConst.XGEN_TAG_OPERATION, "CallService");
                        msg.setProperty(MsgDefine.MSG_SERVICE_NAME, "BEIS_Reply_Resource_Data");

                        mInXmlString = "";


                        node.InsertMember(0, "_SERVICE_NAME", "BEIS_Reply_Resource_Data", TRSDataType.String, true);
                        node.InsertMember(1, "_MODULE_NAME", "BEIS", TRSDataType.String, true);

                        in_msg = TRSConvertorDefine.Convertor.ToXmlString(node);

                        mInXmlString = in_msg;

                        com.miracom.transceiverx.message.former.StreamTransformer former = new com.miracom.transceiverx.message.former.StreamTransformerImpl("UTF-8");

                        SOI.MsgHandlerH101.MessageType.serialize_Message(former, in_msg);
                        SOI.MsgHandlerH101.MessageCommon.SetBinaryData(former, node);
                        msg.setData(former.getBytes());
                        com.miracom.transceiverx.message.Message recievemsg = new com.miracom.transceiverx.message.MessageImpl();
                        messagehandler.sendMessage(msg, ref recievemsg, "/LKH1/MESServer", 100000, com.miracom.transceiverx.session.DeliveryType.UNICAST);

                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND) // this is sent even if a modal MessageBox is shown
            {
                if ((int)m.WParam == SC_CLOSE)
                {                    
                    Close();
                }
            }
            base.WndProc(ref m);
        }


        #endregion

        private void frmTigate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (h101tuner.isTuned == true)
            {
                h101tuner.PublishCUSMsgUnTune();
            }
        }
    }

    public class MessageConsumerImp : com.miracom.transceiverx.session.MessageConsumer
    {
        public MessageConsumerImp()
        {
        }


        public void onGMulticast(com.miracom.transceiverx.session.Session ss, com.miracom.transceiverx.message.Message msg)
        {
            throw new NotImplementedException();
        }

        public void onGUnicast(com.miracom.transceiverx.session.Session ss, com.miracom.transceiverx.message.Message msg)
        {
            throw new NotImplementedException();
        }

        public void onMulticast(com.miracom.transceiverx.session.Session ss, com.miracom.transceiverx.message.Message msg)
        {
            throw new NotImplementedException();
        }

        public void onReply(com.miracom.transceiverx.session.Session ss, com.miracom.transceiverx.message.Message req, com.miracom.transceiverx.message.Message reply, object hint)
        {
            throw new NotImplementedException();
        }

        public void onRequest(com.miracom.transceiverx.session.Session ss, com.miracom.transceiverx.message.Message msg)
        {
            throw new NotImplementedException();
        }

        public void onTimeout(com.miracom.transceiverx.session.Session ss, com.miracom.transceiverx.message.Message req)
        {
            throw new NotImplementedException();
        }

        public void onUnicast(com.miracom.transceiverx.session.Session ss, com.miracom.transceiverx.message.Message msg)
        {
            throw new NotImplementedException();
        }
    }
}
