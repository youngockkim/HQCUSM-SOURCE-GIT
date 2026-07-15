
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;

namespace Miracom.RASCore
{
    public sealed class modGlobalVariables
    {
        public static Color DEFECT1_COLOR = Color.Red;
        public static Color DEFECT2_COLOR = Color.Blue;

        internal const char FLAG_INCREASE = '+';
        internal const char FLAG_DECREASE = '-';
        internal const char FLAG_MULTIPLY = '*';
        internal const char FLAG_DIVISION = '/';
        internal const char FLAG_MOD = 'M';
        internal const char FLAG_POW = 'P';
        internal const char FLAG_TIME = 'T';
        internal const char FLAG_RESET = 'R';
        internal const char FLAG_CHANGE = 'Y';
        internal const char FLAG_NOT_CHANGE = 'N';
        
    }
    
}
