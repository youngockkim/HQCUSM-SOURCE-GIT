//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : clsCustomGlobalVariable.cs.cs
//   Description : Customizing Global Variable
//
//   MES Version : 5.2.0.0
//
//   Function List
//       -  
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

#region " using Definition "

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace SOI.HanwhaQcell.USModule
{ 
    public class HQGV
    {


        #region " Variable Definition "

        //public const string MP_GCM_SUB_AREA = "SUB_AREA";
        public static string gsQueryStatementLong = string.Empty; // for Mutiple Query Statement
        public static intHmMdiFormFunction gIHmMdiForm;
        public static bool gbTunePublish = false;        
        public static string gsPCId = "";
        //2023.10.03 YYK - Added OI Client & Printer Status Check 
        public static bool gbCheckPrinterFlag = false;
        public static bool gbStatusCheckFlag = true;
        public static string gsDefaultPrinter = "";
        public static string gsPrinterStatus = "";
        public static string gsPrinterStatusMsg = "";
        public static string gsClientIPAddress = "";
        public static int giPrinterCheckCount = 0;
        public static long glStatusCheckCount = 0;
        public static int giCheckCount = 0;        

        /*Temporary Begin*/
        //public const string HQ_AREA_A1 = "A1";     //A1
        //public const string HQ_AREA_A1 = "A2";     //A2
        /*Temporary End*/
     
        #endregion 

    }
}
