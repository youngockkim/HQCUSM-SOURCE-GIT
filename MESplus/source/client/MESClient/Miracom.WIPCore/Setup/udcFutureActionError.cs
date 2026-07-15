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

namespace Miracom.WIPCore.Setup
{
    public partial class udcFutureActionError : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionError()
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


            /* Form Load Event 대용으로 사용 */

            if (BASLIST.ViewMessageGroupList(cboMsgGrp, '1', null, false, false) == true)
            {
                if (cboMsgGrp.Items.Count > 0)
                {
                    cboMsgGrp.SelectedIndex = 0;
                }
            }

            if (BASLIST.ViewMessageGroupList(cboFalseMsgGrp, '1', null, false, false) == true)
            {
                if (cboFalseMsgGrp.Items.Count > 0)
                {
                    cboFalseMsgGrp.SelectedIndex = 0;
                }
            }

            chkOverride.Checked = true;
            chkFalseOverride.Checked = true;
            chkOverride.Checked = false;
            chkFalseOverride.Checked = false;
        }

        public override void setPoint(char c_oper_point, char c_ba_point, char c_skip_originated_service)
        {
            m_c_oper_point = c_oper_point;
            m_c_ba_point = c_ba_point;
            m_c_skip_originated_service = c_skip_originated_service;

            if (m_c_ba_point == 'B')
            {
                rbtError.Checked = true;
                rbtFalseError.Checked = true;

                rbtWarning.Enabled = false;
                rbtSuccess.Enabled = false;

                rbtFalseWarning.Enabled = false;
                rbtFalseSuccess.Enabled = false;
            }
            else
            {
                rbtWarning.Enabled = true;
                rbtSuccess.Enabled = true;

                rbtFalseWarning.Enabled = true;
                rbtFalseSuccess.Enabled = true;
            }
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cboMsgGrp.Text = node.GetString("DATA_1");
            cdvMsgID.Text = node.GetString("DATA_2");
            switch (node.GetString("DATA_3"))
            {
                case "E": rbtError.Checked = true; break;
                case "W": rbtWarning.Checked = true; break;
                case "S": rbtSuccess.Checked = true; break;
            }
            chkOverride.Checked = (node.GetString("DATA_4") == "Y" ? true : false);
            if (chkOverride.Checked == true)
            {
                txtMsg.Text = node.GetString("LONG_DATA_1");
                txtMsg.Tag = GetMessage(cdvMsgID.Text);
            }
            else
            {
                txtMsg.Text = GetMessage(cdvMsgID.Text);
                txtMsg.Tag = txtMsg.Text;
            }

            if (node.GetChar("ACTION_TYPE") == '1')
            {
                cboActionType.SelectedIndex = 0;
            }
            else if (node.GetChar("ACTION_TYPE") == '2')
            {
                cboActionType.SelectedIndex = 1;

                cboFalseMsgGrp.Text = node.GetString("DATA_11");
                cdvFalseMsgID.Text = node.GetString("DATA_12");
                switch (node.GetString("DATA_13"))
                {
                    case "E": rbtFalseError.Checked = true; break;
                    case "W": rbtFalseWarning.Checked = true; break;
                    case "S": rbtFalseSuccess.Checked = true; break;
                }
                chkFalseOverride.Checked = (node.GetString("DATA_14") == "Y" ? true : false);
                if (chkFalseOverride.Checked == true)
                {
                    txtFalseMsg.Text = node.GetString("LONG_DATA_2");
                    txtFalseMsg.Tag = GetMessage(cdvFalseMsgID.Text);
                }
                else
                {
                    txtFalseMsg.Text = GetMessage(cdvFalseMsgID.Text);
                    txtFalseMsg.Tag = txtFalseMsg.Text;
                }
            }

        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvMsgID, 1) == false) return false;

            if (cboActionType.SelectedIndex == 1)
            {
                if (MPCF.CheckValue(cdvFalseMsgID, 1) == false) return false;
            }

            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "ERROR ACTION");

            if (cboActionType.SelectedIndex == 0)
                node.AddChar("ACTION_TYPE", '1');
            else if (cboActionType.SelectedIndex == 1)
                node.AddChar("ACTION_TYPE", '2');

            node.AddString("DATA_1", cboMsgGrp.Text);
            node.AddString("DATA_2", cdvMsgID.Text);

            if (rbtError.Checked == true) node.AddString("DATA_3", "E");
            if (rbtWarning.Checked == true) node.AddString("DATA_3", "W");
            if (rbtSuccess.Checked == true) node.AddString("DATA_3", "S");

            if (chkOverride.Checked == true)
            {
                node.AddString("DATA_4", "Y");
                node.AddString("LONG_DATA_1", MPCF.Trim(txtMsg.Text));
            }

            if (cboActionType.SelectedIndex == 1)
            {
                node.AddString("DATA_11", cboFalseMsgGrp.Text);
                node.AddString("DATA_12", cdvFalseMsgID.Text);

                if (rbtFalseError.Checked == true) node.AddString("DATA_13", "E");
                if (rbtFalseWarning.Checked == true) node.AddString("DATA_13", "W");
                if (rbtFalseSuccess.Checked == true) node.AddString("DATA_13", "S");

                if (chkFalseOverride.Checked == true)
                {
                    node.AddString("DATA_14", "Y");
                    node.AddString("LONG_DATA_2", MPCF.Trim(txtFalseMsg.Text));
                }
            }
        }

        private string GetMessage(string s_msg_id)
        {
            TRSNode in_node = new TRSNode("View_Message_In");
            TRSNode out_node = new TRSNode("View_Message_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MSG_ID", MPCF.Trim(s_msg_id));

            if (MPCR.CallService("BAS", "BAS_View_Message", in_node, ref out_node) == false)
            {
                return "";
            }

            switch (MPGV.gcLanguage)
            {
                case '1': return out_node.GetString("MSG_1");
                case '2': return out_node.GetString("MSG_2");
                case '3': return out_node.GetString("MSG_3");
            }

            return "";
        }

        #endregion

        private void cboActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActionType.SelectedIndex == 0)
            {
                grpActionTrue.Visible = false;
                grpActionTrue.Visible = true;
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

        private void cboMsgGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdvMsgID.Text = "";
            txtMsg.Text = "";
            txtMsg.Tag = "";
            chkOverride.Checked = false;
            rbtError.Checked = true;
        }

        private void cboFalseMsgGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdvFalseMsgID.Text = "";
            txtFalseMsg.Text = "";
            txtFalseMsg.Tag = "";
            chkFalseOverride.Checked = false;
            rbtFalseError.Checked = true;
        }

        private void cdvMsgID_ButtonPress(object sender, EventArgs e)
        {
            cdvMsgID.Init();
            MPCF.InitListView(cdvMsgID.GetListView);
            cdvMsgID.Columns.Add("Msg ID", 50, HorizontalAlignment.Left);
            cdvMsgID.Columns.Add("Message", 100, HorizontalAlignment.Left);
            cdvMsgID.SelectedSubItemIndex = 0;

            if (BASLIST.ViewMessageList(cdvMsgID.GetListView, '1', cboMsgGrp.Text, null, "", false) == false)
            {
                ;
            }
        }

        private void cdvMsgID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtMsg.Text = e.SelectedItem.SubItems[1].Text;
            txtMsg.Tag = e.SelectedItem.SubItems[1].Text;
            chkOverride.Checked = false;
        }

        private void cdvFalseMsgID_ButtonPress(object sender, EventArgs e)
        {
            cdvFalseMsgID.Init();
            MPCF.InitListView(cdvFalseMsgID.GetListView);
            cdvFalseMsgID.Columns.Add("Msg ID", 50, HorizontalAlignment.Left);
            cdvFalseMsgID.Columns.Add("Message", 100, HorizontalAlignment.Left);
            cdvFalseMsgID.SelectedSubItemIndex = 0;

            if (BASLIST.ViewMessageList(cdvFalseMsgID.GetListView, '1', cboFalseMsgGrp.Text, null, "", false) == false)
            {
                ;
            }
        }

        private void cdvFalseMsgID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtFalseMsg.Text = e.SelectedItem.SubItems[1].Text;
            txtFalseMsg.Tag = e.SelectedItem.SubItems[1].Text;
            chkFalseOverride.Checked = false;
        }

        private void chkOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOverride.Checked == true)
            {
                txtMsg.ReadOnly = false;
            }
            else
            {
                txtMsg.ReadOnly = true;
                if (txtMsg.Tag != null)
                {
                    txtMsg.Text = txtMsg.Tag.ToString();
                }
            }
        }

        private void chkFalseOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFalseOverride.Checked == true)
            {
                txtFalseMsg.ReadOnly = false;
            }
            else
            {
                txtFalseMsg.ReadOnly = true;
                if (txtFalseMsg.Tag != null)
                {
                    txtFalseMsg.Text = txtFalseMsg.Tag.ToString();
                }
            }
        }



    }
}
