using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace SOI.OIFrx
{
    public class miracomTunerImpl : miracomTuner
    {
        public override void M_Publish_Data(TRSNode node)
        {
            try
            {
                MOGV.gIHmMdiForm.M_PublishDataEvent(node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("M_Publish_Data()\n" + ex.Message);
            }
        }
    }
}
