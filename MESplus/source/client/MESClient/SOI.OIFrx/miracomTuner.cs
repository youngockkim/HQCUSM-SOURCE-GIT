using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Miracom.TRSCore;

namespace SOI.OIFrx
{
    public abstract class miracomTuner : Miracom.MsgHandler.ServiceDispatcher
    {
        public bool dispatch(string s_service_name, TRSNode in_node, TRSNode out_node)
        {
            if (s_service_name.Equals("M_Publish_Data"))
                M_Publish_Data(in_node);
            else
                return false;

            return true;
        }

        public abstract void M_Publish_Data(TRSNode node);

    }
}
