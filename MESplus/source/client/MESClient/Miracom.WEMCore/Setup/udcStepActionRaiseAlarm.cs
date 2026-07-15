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
    public partial class udcStepActionRaiseAlarm : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionRaiseAlarm()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            cdvAlarmID.Init();
            MPCF.InitListView(cdvAlarmID.GetListView);
            cdvAlarmID.Columns.Add("Alarm", 150, HorizontalAlignment.Left);
            cdvAlarmID.Columns.Add("Message", 200, HorizontalAlignment.Left);
            cdvAlarmID.SelectedSubItemIndex = 0;
            ALMLIST.ViewAlarmMsgList(cdvAlarmID.GetListView, '1', ' ');
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cdvAlarmID.Text = node.GetString("DATA_1");
            txtSubject.Text = node.GetString("DATA_2");
            txtMessage.Text = node.GetString("DATA_3");
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvAlarmID, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "RAISE ALARM");

            node.AddString("DATA_1", cdvAlarmID.Text);
            node.AddString("DATA_2", txtSubject.Text);
            node.AddString("DATA_3", txtMessage.Text);
        }

        #endregion

    }
}
