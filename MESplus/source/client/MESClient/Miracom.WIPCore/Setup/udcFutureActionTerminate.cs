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
    public partial class udcFutureActionTerminate : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionTerminate()
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

            cdvTermCode.Init();
            MPCF.InitListView(cdvTermCode.GetListView);
            cdvTermCode.Columns.Add("Delete Reason", 150, HorizontalAlignment.Left);
            cdvTermCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTermCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTermCode.GetListView, '1', MPGC.MP_WIP_TERMINATE_CODE);

            cdvTermCodeFalse.Init();
            MPCF.InitListView(cdvTermCodeFalse.GetListView);
            cdvTermCodeFalse.Columns.Add("Delete Reason", 150, HorizontalAlignment.Left);
            cdvTermCodeFalse.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTermCodeFalse.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTermCodeFalse.GetListView, '1', MPGC.MP_WIP_TERMINATE_CODE);
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cdvTermCode.Text = node.GetString("DATA_1");

            if (node.GetChar("ACTION_TYPE") == '1')
            {
                cboActionType.SelectedIndex = 0;
            }
            else if (node.GetChar("ACTION_TYPE") == '2')
            {
                cboActionType.SelectedIndex = 1;

                cdvTermCodeFalse.Text = node.GetString("DATA_11");
            }
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvTermCode, 1) == false) return false;

            if (cboActionType.SelectedIndex == 1)
            {
                if (MPCF.CheckValue(cdvTermCodeFalse, 1) == false) return false;
            }

            return true;
        }
        
        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_TERMINATE);

            if (cboActionType.SelectedIndex == 0)
                node.AddChar("ACTION_TYPE", '1');
            else if (cboActionType.SelectedIndex == 1)
                node.AddChar("ACTION_TYPE", '2');

            node.AddString("DATA_1", cdvTermCode.Text);

            node.AddString("DATA_11", cdvTermCodeFalse.Text);
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

