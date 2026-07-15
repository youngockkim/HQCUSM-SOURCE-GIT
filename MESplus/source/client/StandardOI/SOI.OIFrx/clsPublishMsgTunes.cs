#if _H101
using SOI.MsgHandlerH101;
#endif
#if _Http
using SOI.MsgHandlerHTTP;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOI.CliFrx;

namespace SOI.OIFrx
{
    public class PublishMsgTune
    {
        // PublishMsgTune()
        //       - Publish Message Tune
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool PublishUTLMsgTune()
        {

            try
            {

                if (MPIF.gInit.getMiddleware == "HTTP")
                {
                    MPMH.registerDispatcher("UTL", new UTLTunerImpl());
                }
                else
                {
                    string sPublishChannel = "";

                    sPublishChannel = "/" + MPGV.gsSiteID;
                    sPublishChannel += "/UTL";
                    sPublishChannel += "/" + MPGV.gsFactory;
                    sPublishChannel += "/" + MPGV.gsUserGroup;
                    sPublishChannel += "/" + MPGV.gsUserID;

                    MPMH.registerDispatcher("UTL", new UTLTunerImpl());
                    if (true != MPMH.tune(sPublishChannel, true, false))
                    {
                        MPCF.ShowMessage("Message Tuning " + MPMH.StatusMessage, MSG_LEVEL.ERROR, true);
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                MPCF.ShowMessage("PublishUTLMsgTune() Failed.", MSG_LEVEL.ERROR, true);
                return false;
            }

            return true;
        }

        public static bool PublishUTLMsgUnTune()
        {

            try
            {
                string sPublishChannel;

                sPublishChannel = "/" + MPGV.gsSiteID;
                sPublishChannel += "/UTL";
                sPublishChannel += "/" + MPGV.gsFactory;
                sPublishChannel += "/" + MPGV.gsUserGroup;
                sPublishChannel += "/" + MPGV.gsUserID;

                MPMH.untune(sPublishChannel, true, false);
                MPMH.unregisterDispatcher("UTL");
            }
            catch (Exception)
            {
                MPCF.ShowMessage("PublishUTLMsgUnTune() Failed.", MSG_LEVEL.ERROR, true);
                return false;
            }

            return true;

        }

        /*
         PublishALMMsgTune()
               - Publish Alarm Message Tune
         Return Value
               - Boolean : True or False
         Arguments
               -
        */
        public static bool PublishALMMsgTune()
        {

            try
            {
                if (MPIF.gInit.getMiddleware == "HTTP")
                {
                    MPMH.registerDispatcher("ALM", new ALMTunerImpl());
                }
                else
                {
                    string sPublishAlarmChannel;

                    sPublishAlarmChannel = "/" + MPGV.gsSiteID;
                    sPublishAlarmChannel += "/ALM";
                    sPublishAlarmChannel += "/" + MPGV.gsFactory;
                    sPublishAlarmChannel += "/" + MPGV.gsUserID;

                    MPMH.registerDispatcher("ALM", new ALMTunerImpl());
                    if (true != MPMH.tune(sPublishAlarmChannel, true, false))
                    {
                        MPCF.ShowMessage("Message Tuning " + MPMH.StatusMessage, MSG_LEVEL.ERROR, true);
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                MPCF.ShowMessage("PublishALMMsgTune() Failed.", MSG_LEVEL.ERROR, true);
                return false;
            }

            return true;
        }

        public static bool PublishALMMsgUnTune()
        {

            try
            {
                string sPublishAlarmChannel;

                sPublishAlarmChannel = "/" + MPGV.gsSiteID;
                sPublishAlarmChannel += "/ALM";
                sPublishAlarmChannel += "/" + MPGV.gsFactory;
                sPublishAlarmChannel += "/" + MPGV.gsUserID;

                MPMH.untune(sPublishAlarmChannel, true, false);
                MPMH.unregisterDispatcher("ALM");

            }
            catch (Exception)
            {
                MPCF.ShowMessage("PublishALMMsgUnTune() Failed.", MSG_LEVEL.ERROR, true);
                return false;
            }

            return true;
        }




    }
}
