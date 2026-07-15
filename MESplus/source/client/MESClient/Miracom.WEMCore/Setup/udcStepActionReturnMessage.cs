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
    public partial class udcStepActionReturnMessage : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionReturnMessage()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            if (BASLIST.ViewMessageGroupList(cboMsgGrp, '1', null, false, false) == true)
            {
                if (cboMsgGrp.Items.Count > 0)
                {
                    cboMsgGrp.SelectedIndex = 0;
                }
            }

            chkOverride.Checked = true;
            chkOverride.Checked = false;
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
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvMsgID, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "RETURN MESSAGE");

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

        private void cboMsgGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdvMsgID.Text = "";
            txtMsg.Text = "";
            txtMsg.Tag = "";
            chkOverride.Checked = false;
            rbtError.Checked = true;
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
    
    
    
    }
}
