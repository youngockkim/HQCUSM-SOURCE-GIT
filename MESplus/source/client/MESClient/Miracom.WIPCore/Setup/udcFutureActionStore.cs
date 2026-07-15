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
    public partial class udcFutureActionStore : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionStore()
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
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            if (node.GetChar("ACTION_TYPE") == '1')
            {
                cboActionType.SelectedIndex = 0;

                cdvToOper.Text = node.GetString("DATA_1");
            }
            else if (node.GetChar("ACTION_TYPE") == '2')
            {
                cboActionType.SelectedIndex = 1;

                cdvToOper.Text = node.GetString("DATA_1");
                cdvToOperFalse.Text = node.GetString("DATA_11");
            }
        }

        public override bool checkCondition()
        {
            if (cboActionType.SelectedIndex == 0)
            {
                if (MPCF.CheckValue(cdvToOper, 1) == false)
                {
                    return false;
                }
            }
            else if (cboActionType.SelectedIndex == 1)
            {
                if (MPCF.CheckValue(cdvToOper, 1) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cdvToOperFalse, 1) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_STORE);

            if (cboActionType.SelectedIndex == 0)
            {
                node.AddChar("ACTION_TYPE", '1');

                node.AddString("DATA_1", cdvToOper.Text);
            }
            else if (cboActionType.SelectedIndex == 1)
            {
                node.AddChar("ACTION_TYPE", '2');

                node.AddString("DATA_1", cdvToOper.Text);
                node.AddString("DATA_11", cdvToOperFalse.Text);
            }
        }

        #endregion

        private void cboActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(grpActionTrue);
            MPCF.FieldClear(grpActionFalse);

            grpActionTrue.Text = MPCF.FindLanguage("True Action", CAPTION_TYPE.LABEL);

            grpActionFalse.Visible = false;

            cdvToOper.Visible = true;
            cdvToOperFalse.Visible = true;

            if (cboActionType.SelectedIndex == 0)
            {
                grpActionTrue.Text = "";
            }
            else if (cboActionType.SelectedIndex == 1)
            {
                grpActionFalse.Visible = true;
            }
        }

        private void cboActionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


    }
}

