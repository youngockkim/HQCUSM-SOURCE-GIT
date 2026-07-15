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
    public partial class udcFutureActionCustom : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionCustom()
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

            txtData1.Text = node.GetString("DATA_1");
            txtData2.Text = node.GetString("DATA_2");
            txtData3.Text = node.GetString("DATA_3");
            txtData4.Text = node.GetString("DATA_4");
            txtData5.Text = node.GetString("DATA_5");

            if (node.GetChar("ACTION_TYPE") == '1')
            {
                cboActionType.SelectedIndex = 0;
            }
            else if (node.GetChar("ACTION_TYPE") == '2')
            {
                cboActionType.SelectedIndex = 1;

                txtDataFalse1.Text = node.GetString("DATA_11");
                txtDataFalse2.Text = node.GetString("DATA_12");
                txtDataFalse3.Text = node.GetString("DATA_13");
                txtDataFalse4.Text = node.GetString("DATA_14");
                txtDataFalse5.Text = node.GetString("DATA_15");
            }
        }

        public override bool checkCondition()
        {
            return true;
        }
        
        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "CUSTOM ACTION");

            if (cboActionType.SelectedIndex == 0)
                node.AddChar("ACTION_TYPE", '1');
            else if (cboActionType.SelectedIndex == 1)
                node.AddChar("ACTION_TYPE", '2');

            node.AddString("DATA_1", txtData1.Text);
            node.AddString("DATA_2", txtData2.Text);
            node.AddString("DATA_3", txtData3.Text);
            node.AddString("DATA_4", txtData4.Text);
            node.AddString("DATA_5", txtData5.Text);

            node.AddString("DATA_11", txtDataFalse1.Text);
            node.AddString("DATA_12", txtDataFalse2.Text);
            node.AddString("DATA_13", txtDataFalse3.Text);
            node.AddString("DATA_14", txtDataFalse4.Text);
            node.AddString("DATA_15", txtDataFalse5.Text);
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

