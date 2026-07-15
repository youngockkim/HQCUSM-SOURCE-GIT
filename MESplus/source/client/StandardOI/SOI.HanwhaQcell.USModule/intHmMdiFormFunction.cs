using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.TRSCore;

namespace SOI.HanwhaQcell.USModule
{
    public interface intHmMdiFormFunction
    {
        bool Publish_M_MsgTune();
        void M_PublishDataEvent(TRSNode node); 

    }
}
