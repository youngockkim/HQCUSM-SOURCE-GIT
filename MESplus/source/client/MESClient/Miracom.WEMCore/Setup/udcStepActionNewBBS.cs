using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;

namespace Miracom.WEMCore.Setup
{
    public partial class udcStepActionNewBBS : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionNewBBS()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        public override void initControl()
        {
            base.initControl();
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            //cdvAlarmID.Text = node.GetString("DATA_1");
            //txtSubject.Text = node.GetString("DATA_2");
            //txtMessage.Text = node.GetString("DATA_3");
        }

        public override bool checkCondition()
        {
            //if (MPCF.CheckValue(cdvAlarmID, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "CHG_STATUS_VALUE");

            //node.AddString("DATA_1", cdvAlarmID.Text);
            //node.AddString("DATA_2", txtSubject.Text);
            //node.AddString("DATA_3", txtMessage.Text);
        }

        #endregion

    }
}
