using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOI.OIFrx
{
    public class BIGV
    {
        public BIGV()
        {
        }

        //Work Order에 등록된 라인
        public static string gsWorkOrderLineId;        

        #region COMPort

        public static string gsPortID1;
        public static string gsPortID2;
        public static string gsPortID3;
        public static string gsPortID4;
        public static string gsPortID5;
        public static string gsPortID6;
        public static string gsBaudRate1;
        public static string gsBaudRate2;
        public static string gsBaudRate3;
        public static string gsBaudRate4;
        public static string gsBaudRate5;
        public static string gsBaudRate6;
        public static string gsDataBits1;
        public static string gsDataBits2;
        public static string gsDataBits3;
        public static string gsDataBits4;
        public static string gsDataBits5;
        public static string gsDataBits6;
        public static string gsParityBit1;
        public static string gsParityBit2;
        public static string gsParityBit3;
        public static string gsParityBit4;
        public static string gsParityBit5;
        public static string gsParityBit6;
        public static string gsStopBits1;
        public static string gsStopBits2;
        public static string gsStopBits3;
        public static string gsStopBits4;
        public static string gsStopBits5;
        public static string gsStopBits6;

        #endregion


        public class SearchCondition
        {
            public string s_ctrl_name;
            public string s_code;
            public string s_code_desc;
        }
        public static string gslocalIpAddress;

        public static int gsQueryStatementLOGCount = 0;
        public static string gsQueryStatementLOG = "";
        public static string gsMCPulblishChannel = "";
        public static bool gbTunePublish = false;        
        public static bool gbDefaultPrint = false;                
        public static string gsOper = "";
        public static string gsResId = "";
        public static string gsTuneId = "";
        public static string gsPCId = "";       
        public static string gsKioskId = "";

    }
}
