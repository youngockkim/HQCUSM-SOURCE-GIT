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
    public partial class udcFutureActionHold : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionHold()
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

            cdvHoldCode.Init();
            MPCF.InitListView(cdvHoldCode.GetListView);
            cdvHoldCode.Columns.Add("Hold Code", 150, HorizontalAlignment.Left);
            cdvHoldCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvHoldCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvHoldCode.GetListView, '1', MPGC.MP_WIP_HOLD_CODE);

            cdvHoldCodeFalse.Init();
            MPCF.InitListView(cdvHoldCodeFalse.GetListView);
            cdvHoldCodeFalse.Columns.Add("Hold Code", 150, HorizontalAlignment.Left);
            cdvHoldCodeFalse.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvHoldCodeFalse.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvHoldCodeFalse.GetListView, '1', MPGC.MP_WIP_HOLD_CODE);
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cdvHoldCode.Text = node.GetString("DATA_1");
            txtHoldPass.Text = node.GetString("DATA_2");

            if (node.GetChar("ACTION_TYPE") == '1')
            {
                cboActionType.SelectedIndex = 0;
            }
            else if (node.GetChar("ACTION_TYPE") == '2')
            {
                cboActionType.SelectedIndex = 1;

                cdvHoldCodeFalse.Text = node.GetString("DATA_11");
                txtHoldPassFalse.Text = node.GetString("DATA_12");
            }
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvHoldCode, 1) == false) return false;

            if (cboActionType.SelectedIndex == 1)
            {
                if (MPCF.CheckValue(cdvHoldCodeFalse, 1) == false) return false;
            }

            return true;
        }
        
        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_HOLD);

            if (cboActionType.SelectedIndex == 0)
                node.AddChar("ACTION_TYPE", '1');
            else if (cboActionType.SelectedIndex == 1)
                node.AddChar("ACTION_TYPE", '2');

            node.AddString("DATA_1", cdvHoldCode.Text);
            node.AddString("DATA_2", txtHoldPass.Text);

            node.AddString("DATA_11", cdvHoldCodeFalse.Text);
            node.AddString("DATA_12", txtHoldPassFalse.Text);
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

