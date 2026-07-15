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
    public partial class udcStepActionCustomAction : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionCustomAction()
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

            txtData1.Text = node.GetString("DATA_1");
            txtData2.Text = node.GetString("DATA_2");
            txtData3.Text = node.GetString("DATA_3");
            txtData4.Text = node.GetString("DATA_4");
            txtData5.Text = node.GetString("DATA_5");
            txtData6.Text = node.GetString("DATA_6");
            txtData7.Text = node.GetString("DATA_7");
            txtData8.Text = node.GetString("DATA_8");
            txtData9.Text = node.GetString("DATA_9");
            txtData10.Text = node.GetString("DATA_10");
        }

        public override bool checkCondition()
        {
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "CUSTOM ACTION");

            node.AddString("DATA_1", txtData1.Text);
            node.AddString("DATA_2", txtData2.Text);
            node.AddString("DATA_3", txtData3.Text);
            node.AddString("DATA_4", txtData4.Text);
            node.AddString("DATA_5", txtData5.Text);
            node.AddString("DATA_6", txtData6.Text);
            node.AddString("DATA_7", txtData7.Text);
            node.AddString("DATA_8", txtData8.Text);
            node.AddString("DATA_9", txtData9.Text);
            node.AddString("DATA_10", txtData10.Text);
        }

        #endregion

    }
}
