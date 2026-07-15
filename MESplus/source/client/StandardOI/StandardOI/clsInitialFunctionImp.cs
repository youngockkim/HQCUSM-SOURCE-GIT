using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using SOI.CliFrx;
#if _H101
using SOI.MsgHandlerH101;
#endif
#if _Http
using SOI.MsgHandlerHTTP;
#endif
using Miracom.TRSCore;

namespace StandardOI
{
    public class clsInitialFunctionImp : clsMESPlusInitialFunction
    {
        /// <summary>
        /// Site Caster Prologue를 처리하기 위한 Abstract Function
        /// </summary>
        /// <param name="in_node"></param>
        public override void CustCasterPrologue(TRSNode in_node)
        {

        }
        
        /// <summary>
        /// Site Caster Epilogue를 처리하기 위한 Abstract Function
        /// </summary>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        public override void CustCasterEpilogue(TRSNode in_node, TRSNode out_node)
        {

        }

        /// <summary>
        /// //Site Tuner Prologue를 처리하기 위한 Abstract Function
        /// </summary>
        /// <param name="in_node"></param>
        public override void CustTunerPrologue(TRSNode in_node)
        {

        }

        /// <summary>
        /// Site Tuner Epilogue를 처리하기 위한 Abstract Function
        /// </summary>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        public override void CustTunerEpilogue(TRSNode in_node, TRSNode out_node)
        {

        }
    }
}
