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
    public partial class udcFutureActionSkip : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionSkip()
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

                cdvToFlow.Text = node.GetString("DATA_1");
                cdvToFlow.Sequence = MPCF.ToInt(node.GetString("DATA_2"));
                cdvToOper.Text = node.GetString("DATA_3");
            }
            else if (node.GetChar("ACTION_TYPE") == '3')
            {
                cboActionType.SelectedIndex = 1;

                cdvToFlow.Text = node.GetString("DATA_1");
                cdvToFlow.Sequence = MPCF.ToInt(node.GetString("DATA_2"));
                cdvToOper.Text = node.GetString("DATA_3");

                cdvToFlowFalse.Text = node.GetString("DATA_11");
                cdvToFlowFalse.Sequence = MPCF.ToInt(node.GetString("DATA_12"));
                cdvToOperFalse.Text = node.GetString("DATA_13");
            }
            else if (node.GetChar("ACTION_TYPE") == '4')
            {
                cboActionType.SelectedIndex = 2;

                numOperCount.Value = MPCF.ToInt(node.GetString("DATA_1"));
                numOperCountFalse.Value = MPCF.ToInt(node.GetString("DATA_11"));
            }
        }

        public override bool checkCondition()
        {
            if (cboActionType.SelectedIndex == 0)
            {
                if (MPCF.Trim(cdvToFlow.Text) == "" && MPCF.Trim(cdvToOper.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvToFlow.Focus();
                    return false;
                }
            }
            else if (cboActionType.SelectedIndex == 1)
            {
                if (MPCF.Trim(cdvToFlow.Text) == "" && MPCF.Trim(cdvToOper.Text) == "" && MPCF.Trim(cdvToFlowFalse.Text) == "" && MPCF.Trim(cdvToOperFalse.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvToFlow.Focus();
                    return false;
                }
            }
            else if (cboActionType.SelectedIndex == 2)
            {
                if (numOperCount.Value == 0 && numOperCountFalse.Value == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    numOperCount.Focus();
                    return false;
                }
            }

            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_SKIP);

            if (cboActionType.SelectedIndex == 0)
            {
                node.AddChar("ACTION_TYPE", '1');

                node.AddString("DATA_1", cdvToFlow.Text);
                node.AddString("DATA_2", cdvToFlow.Sequence.ToString());
                node.AddString("DATA_3", cdvToOper.Text);
            }
            else if (cboActionType.SelectedIndex == 1)
            {
                node.AddChar("ACTION_TYPE", '3');

                node.AddString("DATA_1", cdvToFlow.Text);
                node.AddString("DATA_2", cdvToFlow.Sequence.ToString());
                node.AddString("DATA_3", cdvToOper.Text);

                node.AddString("DATA_11", cdvToFlowFalse.Text);
                node.AddString("DATA_12", cdvToFlowFalse.Sequence.ToString());
                node.AddString("DATA_13", cdvToOperFalse.Text);

            }
            else if (cboActionType.SelectedIndex == 2)
            {
                node.AddChar("ACTION_TYPE", '4');

                node.AddString("DATA_1", numOperCount.Value.ToString());
                node.AddString("DATA_11", numOperCountFalse.Value.ToString());
            }
        }

        #endregion

        private void cboActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(grpActionTrue);
            MPCF.FieldClear(grpActionFalse);

            grpActionTrue.Text = MPCF.FindLanguage("True Action", CAPTION_TYPE.LABEL);

            grpActionFalse.Visible = false;

            cdvToFlow.Visible = true;
            cdvToOper.Visible = true;

            cdvToFlowFalse.Visible = true;
            cdvToOperFalse.Visible = true;

            lblByOperCount.Visible = false;
            numOperCount.Visible = false;

            lblByOperCountFalse.Visible = false;
            numOperCountFalse.Visible = false;

            if (cboActionType.SelectedIndex == 0)
            {
                grpActionTrue.Text = "";
            }
            else if (cboActionType.SelectedIndex == 1)
            {
                grpActionFalse.Visible = true;
            }
            else if (cboActionType.SelectedIndex == 2)
            {
                grpActionFalse.Visible = true;

                cdvToFlow.Visible = false;
                cdvToOper.Visible = false;

                cdvToFlowFalse.Visible = false;
                cdvToOperFalse.Visible = false;

                lblByOperCount.Visible = true;
                numOperCount.Visible = true;

                lblByOperCountFalse.Visible = true;
                numOperCountFalse.Visible = true;
            }
        }

        private void cboActionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cdvToFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvToFlow.ListCond_Step = '1';
            cdvToFlow.ListCond_MatID = "";
            cdvToFlow.ListCond_MatVersion = 0;
        }

        private void cdvToFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvToOper.Text = "";
            if (MPCF.Trim(cdvToFlow.Text) != "")
            {
                cdvToFlow.ListCond_Step = '2';
                cdvToFlow.ListCond_MatID = m_s_mat_id;
                cdvToFlow.ListCond_MatVersion = m_i_mat_ver;
            }
        }

        private void cdvToOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvToFlow.Text) == "")
            {
                if (m_s_flow == "")
                {
                    cdvToOper.ListCond_Step = '1';
                }
                else
                {
                    cdvToOper.ListCond_Step = '2';
                    cdvToOper.ListCond_Flow = m_s_flow;
                }
            }
            else
            {
                cdvToOper.ListCond_Step = '2';
                cdvToOper.ListCond_Flow = cdvToFlow.Text;
            }
        }

        private void cdvToFlowFalse_FlowButtonPress(object sender, EventArgs e)
        {
            cdvToFlowFalse.ListCond_Step = '1';
            cdvToFlowFalse.ListCond_MatID = "";
            cdvToFlowFalse.ListCond_MatVersion = 0;
        }

        private void cdvToFlowFalse_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvToOperFalse.Text = "";
            if (MPCF.Trim(cdvToFlowFalse.Text) != "")
            {
                cdvToFlowFalse.ListCond_Step = '2';
                cdvToFlowFalse.ListCond_MatID = m_s_mat_id;
                cdvToFlowFalse.ListCond_MatVersion = m_i_mat_ver;
            }
        }

        private void cdvToOperFalse_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvToFlowFalse.Text) == "")
            {
                if (m_s_flow == "")
                {
                    cdvToOperFalse.ListCond_Step = '1';
                }
                else
                {
                    cdvToOperFalse.ListCond_Step = '2';
                    cdvToOperFalse.ListCond_Flow = m_s_flow;
                }
            }
            else
            {
                cdvToOperFalse.ListCond_Step = '2';
                cdvToOperFalse.ListCond_Flow = cdvToFlowFalse.Text;
            }
        }



    }
}

