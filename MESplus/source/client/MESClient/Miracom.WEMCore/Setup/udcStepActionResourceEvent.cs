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
    public partial class udcStepActionResourceEvent : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionResourceEvent()
        {
            InitializeComponent();
            initControl();
        }

        #region "Constants"
        private const char CHANGE = 'Y';
        private const string NOTCHANGE = "N";
        private const string INCREASE = "+";
        private const string DECREASE = "-";
        private const char OVERRIDE = 'O';
        private const string TIME = "T";

        #endregion

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            cdvEvent.Init();
            MPCF.InitListView(cdvEvent.GetListView);
            cdvEvent.Columns.Add("Event", 50, HorizontalAlignment.Left);
            cdvEvent.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvEvent.SelectedSubItemIndex = 0;
            RASLIST.ViewEventList(cdvEvent.GetListView, '1', "", null, "");
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            chkMultiTrans.Checked = node.GetChar("MULTI_TR_FLAG") == 'Y' ? true : false;

            cdvEvent.Text = node.GetString("DATA_1");

            cdvEvent_SelectedItemChanged(null, null);

            cdvChangeStatus1.Text = node.GetString("DATA_2");
            cdvChangeStatus2.Text = node.GetString("DATA_3");
            cdvChangeStatus3.Text = node.GetString("DATA_4");
            cdvChangeStatus4.Text = node.GetString("DATA_5");
            cdvChangeStatus5.Text = node.GetString("DATA_6");
            cdvChangeStatus6.Text = node.GetString("DATA_7");
            cdvChangeStatus7.Text = node.GetString("DATA_8");
            cdvChangeStatus8.Text = node.GetString("DATA_9");
            cdvChangeStatus9.Text = node.GetString("DATA_10");
            cdvChangeStatus10.Text = node.GetString("DATA_11");
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvEvent, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "RESOURCE EVENT");

            node.AddChar("MULTI_TR_FLAG", chkMultiTrans.Checked == true ? 'Y' : ' ');
            node.AddString("DATA_1", cdvEvent.Text);
            node.AddString("DATA_2", cdvChangeStatus1.Text);
            node.AddString("DATA_3", cdvChangeStatus2.Text);
            node.AddString("DATA_4", cdvChangeStatus3.Text);
            node.AddString("DATA_5", cdvChangeStatus4.Text);
            node.AddString("DATA_6", cdvChangeStatus5.Text);
            node.AddString("DATA_7", cdvChangeStatus6.Text);
            node.AddString("DATA_8", cdvChangeStatus7.Text);
            node.AddString("DATA_9", cdvChangeStatus8.Text);
            node.AddString("DATA_10", cdvChangeStatus9.Text);
            node.AddString("DATA_11", cdvChangeStatus10.Text);
        }

        private void ClearCodeView()
        {
            foreach (Control control in grpActionValue.Controls)
            {
                if (control is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    if (control.Name == "cdvEvent") continue;

                    ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).Init();
                    ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).ReadOnly = true;
                    ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).VisibleButton = false;
                    ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).Text = "";
                    ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).Tag = "";
                    ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).BackColor = System.Drawing.SystemColors.Control;
                }
            }
        }

        private void ChangeStatusControl(TRSNode out_node, int i_sts_index)
        {
            string s_chg_flag_name;
            string s_table_name;
            string s_chg_sts_name;
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            s_chg_flag_name = "CHG_FLAG_" + i_sts_index.ToString();
            s_table_name = "TBL_" + i_sts_index.ToString();
            s_chg_sts_name = "CHG_STS_" + i_sts_index.ToString();

            cdvTemp = null;
            switch (i_sts_index)
            {
                case 1: cdvTemp = cdvChangeStatus1; break;
                case 2: cdvTemp = cdvChangeStatus2; break;
                case 3: cdvTemp = cdvChangeStatus3; break;
                case 4: cdvTemp = cdvChangeStatus4; break;
                case 5: cdvTemp = cdvChangeStatus5; break;
                case 6: cdvTemp = cdvChangeStatus6; break;
                case 7: cdvTemp = cdvChangeStatus7; break;
                case 8: cdvTemp = cdvChangeStatus8; break;
                case 9: cdvTemp = cdvChangeStatus9; break;
                case 10: cdvTemp = cdvChangeStatus10; break;
            }

            if (out_node.GetChar(s_chg_flag_name) == OVERRIDE)
            {
                if (out_node.GetString(s_table_name) != "")
                {
                    cdvTemp.VisibleButton = true;
                    cdvTemp.Tag = out_node.GetString(s_table_name);
                }
                else
                {
                    cdvTemp.VisibleButton = false;
                    if (out_node.GetString(s_chg_sts_name) == "")
                        cdvTemp.ReadOnly = false;
                    else
                        cdvTemp.Text = out_node.GetString(s_chg_sts_name);
                }
                cdvTemp.BackColor = System.Drawing.SystemColors.Window;
            }
            else
            {
                cdvTemp.VisibleButton = false;
                cdvTemp.ReadOnly = true;
                cdvTemp.BackColor = System.Drawing.SystemColors.Control;
                if (out_node.GetChar(s_chg_flag_name) == CHANGE)
                {
                    cdvTemp.Text = out_node.GetString(s_chg_sts_name);
                }
            }
        }

        private bool ViewEvent(string s_event_id)
        {
            TRSNode in_node = new TRSNode("VIEW_EVENT_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_OUT");

            ClearCodeView();

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("EVENT_ID", s_event_id);


            if (MPCR.CallService("RAS", "RAS_View_Event", in_node, ref out_node) == false)
            {                
                return false;
            }

            ChangeStatusControl(out_node, 1);
            ChangeStatusControl(out_node, 2);
            ChangeStatusControl(out_node, 3);
            ChangeStatusControl(out_node, 4);
            ChangeStatusControl(out_node, 5);
            ChangeStatusControl(out_node, 6);
            ChangeStatusControl(out_node, 7);
            ChangeStatusControl(out_node, 8);
            ChangeStatusControl(out_node, 9);
            ChangeStatusControl(out_node, 10);

            return true;
        }

        #endregion

        private void cdvEvent_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvEvent.Text) == "") return;
            ViewEvent(cdvEvent.Text);
        }

        private void cdvEvent_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvEvent.Text) == "")
            {
                ClearCodeView();
            }
        }

        private void cdvChangeStatus_ButtonPress(System.Object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if (MPCF.Trim(cdvTemp.Tag) == "") return;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Status", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPCF.Trim(cdvTemp.Tag));
        }

    }
}
