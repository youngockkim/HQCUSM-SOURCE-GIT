
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;

//#If _SPC = True Then

namespace Miracom.SPCCore
{
    public sealed class modSPCConstants
    {
        
        #region "Process Step ?ÅÏàò"
        
        public const char MP_STEP_PEND = 'P';
        public const char MP_STEP_CONT = 'N';
        public const char MP_STEP_VIEW = 'V';

        public const char MP_STEP_EXCLUDE_DATA = 'D';
        public const char MP_STEP_INCLUDE_DATA = 'L';
        
        #endregion
        
        #region "GCM Table ?¥Î¶Ñ"
        
        
        public const string MP_SPC_ACTION_CODE = "SPC_ACTION_CODE";
        public const string MP_SPC_TROUBLE_CODE = "SPC_TROUBLE_CODE";
        
        #endregion
        
        
        #region "USL/LSL MIN/MAX "
        
        public const double MAX_VALUE = 9999999999;
        public const double MIN_VALUE = - 9999999999;
        
        #endregion
        
        #region "Collect SPC EDC Data"
        
        public const int VALUE_COUNT = 1000;
        
        #endregion
        
        //#Region "SPC Defines"
        
        //    Public Const DOUBLE_NULL_DATA As Double = Double.MaxValue
        //    Public Const INTEGER_NULL_DATA As Double = Integer.MaxValue
        
        public const bool gbIgnoreSpecError = true;
        
        //#End Region
        
        
    }
    
    
    //#End If
    
}
