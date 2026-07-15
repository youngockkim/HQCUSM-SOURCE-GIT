using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOI.Solar
{
    public sealed class CSGV
    {
        public static string gsProcUserID;
        public static string gsProcUserDesc;

        public static string gsDefaultTerminalID;
        public static string gsTerminalID;
        public static string gsTerminalIPAddress;
        public static string gsTerminalResList;
        public static string gsTerminalWCList;
        //public static string gsTerminalOper;
        public static string gsLabelPrinter;

        public static string gsCurrentResID;
        public static string gsCurrentOrderID;

        public static int gsLblMarginLeft = 0;
        public static int gsLblMarginTop = 0;
        
        //public static char gcOrderCriteria;
        //public static char gcMoldCheckFlag;
        //public static char gcPalleteCheckFlag;
        //public static char gcSNPLockFlag;

        public static char gcTermUpScreenApply1;
        public static char gcTermUpScreenApply2;
        public static char gcTermUpScreenApply3;
        //public static string gsWaitInvOper;

        public static string gsDebugIPAddress;
        public static string file_path;

        public static char gcWorkCenterCheckedFlag = ' ';

        public static string gsQueryStatementLOG = "";
        public static int gsQueryStatementLOGCount = 0;


        public static string[,] gsMessageData;


        public static string gsPPCOperation;
        public static string gsPPCStartResourceID;
        public static string gsPPCEndResourceID;
        public static string gsMCChannel;
        public static string gsIPAddress;
        public static string gsResouceList;
        public static string gsFMBUrl;

        //public static string gsDebugIPAddress;
        //public static string file_path;

    }
}
