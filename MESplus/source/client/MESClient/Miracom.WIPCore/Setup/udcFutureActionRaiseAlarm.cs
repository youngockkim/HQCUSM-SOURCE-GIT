using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;

namespace Miracom.WIPCore.Setup
{
    public partial class udcFutureActionRaiseAlarm : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionRaiseAlarm()
        {
            InitializeComponent();
            cboActionType.SelectedIndex = 0;
        }

        #region "Functions"

        public override void setMFO(string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            initControl();
            cboActionType.SelectedIndex = 0;

            base.setMFO(s_mat_id, i_mat_ver, s_flow, s_oper);

            cdvAlarmID.Init();
            MPCF.InitListView(cdvAlarmID.GetListView);
            cdvAlarmID.Columns.Add("Alarm", 150, HorizontalAlignment.Left);
            cdvAlarmID.Columns.Add("Message", 200, HorizontalAlignment.Left);
            cdvAlarmID.SelectedSubItemIndex = 0;
            ALMLIST.ViewAlarmMsgList(cdvAlarmID.GetListView, '1', ' ');

            cdvAlarmIDFalse.Init();
            MPCF.InitListView(cdvAlarmIDFalse.GetListView);
            cdvAlarmIDFalse.Columns.Add("Alarm", 150, HorizontalAlignment.Left);
            cdvAlarmIDFalse.Columns.Add("Message", 200, HorizontalAlignment.Left);
            cdvAlarmIDFalse.SelectedSubItemIndex = 0;
            ALMLIST.ViewAlarmMsgList(cdvAlarmIDFalse.GetListView, '1', ' ');
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cdvAlarmID.Text = node.GetString("DATA_1");
            txtSubject.Text = node.GetString("DATA_2");
            txtMessage.Text = node.GetString("DATA_3");

            if (node.GetChar("ACTION_TYPE") == '1')
            {
                cboActionType.SelectedIndex = 0;
            }
            else if (node.GetChar("ACTION_TYPE") == '2')
            {
                cboActionType.SelectedIndex = 1;

                cdvAlarmIDFalse.Text = node.GetString("DATA_11");
                txtSubjectFalse.Text = node.GetString("DATA_12");
                txtMessageFalse.Text = node.GetString("DATA_13");
            }
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvAlarmID, 1) == false) return false;

            if (cboActionType.SelectedIndex == 1)
            {
                if (MPCF.CheckValue(cdvAlarmIDFalse, 1) == false) return false;
            }

            return true;
        }
        
        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "RAISE ALARM");

            if (cboActionType.SelectedIndex == 0)
                node.AddChar("ACTION_TYPE", '1');
            else if (cboActionType.SelectedIndex == 1)
                node.AddChar("ACTION_TYPE", '2');

            node.AddString("DATA_1", cdvAlarmID.Text);
            node.AddString("DATA_2", txtSubject.Text);
            node.AddString("DATA_3", txtMessage.Text);

            node.AddString("DATA_11", cdvAlarmIDFalse.Text);
            node.AddString("DATA_12", txtSubjectFalse.Text);
            node.AddString("DATA_13", txtMessageFalse.Text);
        }

        #endregion

        private void cboActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActionType.SelectedIndex == 0)
            {
                grpActionFalse.Visible = false;
                MPCF.FieldClear(grpActionFalse);

                grpActionTrue.Text = "";
            }
            else
            {
                grpActionFalse.Visible = true;
                grpActionTrue.Text = MPCF.FindLanguage("True Action", CAPTION_TYPE.LABEL);
            }
        }

        private void cboActionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}

