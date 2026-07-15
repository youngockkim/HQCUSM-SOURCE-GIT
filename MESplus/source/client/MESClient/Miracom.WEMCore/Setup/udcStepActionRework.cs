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
    public partial class udcStepActionRework : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionRework()
        {
            InitializeComponent();
            initControl();
        }

        private string s_rework_table;

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            cdvRefOper.Init();
            MPCF.InitListView(cdvRefOper.GetListView);
            cdvRefOper.Columns.Add("Operation", 100, HorizontalAlignment.Left);
            cdvRefOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvRefOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvRefOper.GetListView, '1');
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            chkMultiTrans.Checked = node.GetChar("MULTI_TR_FLAG") == 'Y' ? true : false;

            cdvRefOper.Text = node.GetString("DATA_1");
            cdvRwkCode.Text = node.GetString("DATA_2");
            cdvRwkFlow.Text = node.GetString("DATA_3");
            cdvRwkOper.Text = node.GetString("DATA_4");
            cdvRetFlow.Text = node.GetString("DATA_5");
            cdvRetOper.Text = node.GetString("DATA_6");

            switch (node.GetString("DATA_7"))
            {
                case "Y": // Clear Rework
                    cboRetOption.SelectedIndex = 1;
                    break;
                case "A": // Clear Rework and Move to Next Oper
                    cboRetOption.SelectedIndex = 2;
                    break;
                case "B": // Keep Rework and Move to Next Oper
                    cboRetOption.SelectedIndex = 3;
                    break;
                default: // keep Rework
                    cboRetOption.SelectedIndex = 0;
                    break;
            }
            cdvRwkStopOper.Text = node.GetString("DATA_8");
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvRwkCode, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_REWORK);

            node.AddChar("MULTI_TR_FLAG", chkMultiTrans.Checked == true ? 'Y' : ' ');
            node.AddString("DATA_1", cdvRefOper.Text);
            node.AddString("DATA_2", cdvRwkCode.Text);
            node.AddString("DATA_3", cdvRwkFlow.Text);
            node.AddString("DATA_4", cdvRwkOper.Text);
            node.AddString("DATA_5", cdvRetFlow.Text);
            node.AddString("DATA_6", cdvRetOper.Text);
            switch (cboRetOption.SelectedIndex)
            {
                case 0: // Keep Rework
                    node.AddString("DATA_7", " ");
                    break;
                case 1: // Clear Rework
                    node.AddString("DATA_7", "Y");
                    break;
                case 2: // Clear Rework and Move to Next Oper
                    node.AddString("DATA_7", "A");
                    break;
                case 3: // Keep Rework and Move to Next Oper
                    node.AddString("DATA_7", "B");
                    break;
            }
            node.AddString("DATA_8", cdvRwkStopOper.Text);
        }

        private bool ViewOperation()
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", cdvRefOper.Text);

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            s_rework_table = out_node.GetString("REWORK_TBL");
            if (s_rework_table == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(195));
                return false;
            }

            return true;

        }

        private void GetReworkCodeList()
        {
            cdvRwkCode.Init();
            MPCF.InitListView(cdvRwkCode.GetListView);
            cdvRwkCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvRwkCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvRwkCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvRwkCode.GetListView, '1', s_rework_table);
        }

        #endregion

        private void cdvRefOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRwkCode.Text = "";
            cdvRwkFlow.Text = "";
            cdvRwkOper.Text = "";
            cdvRwkStopOper.Text = "";
            cdvRetFlow.Text = "";
            cdvRetOper.Text = "";
            cboRetOption.SelectedIndex = -1;

            if (ViewOperation() == false) return;
            GetReworkCodeList();
        }

        private void cdvRwkCode_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvRefOper, 1) == false)
            {
                cdvRwkCode.IsPopup = false;
                return;
            }
        }

        private void cdvRwkCode_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRwkFlow.Text = "";
            cdvRwkOper.Text = "";
            cdvRwkStopOper.Text = "";
            cdvRetFlow.Text = "";
            cdvRetOper.Text = "";
            cboRetOption.SelectedIndex = -1;
        }

        private void cdvRwkFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRwkOper.Text = "";
            cdvRwkStopOper.Text = "";
            cdvRetFlow.Text = "";
            cdvRetOper.Text = "";

            cdvRwkOper.ListCond_Step = '2';
            cdvRwkOper.ListCond_Flow = cdvRwkFlow.Text;

            cdvRwkStopOper.ListCond_Step = '2';
            cdvRwkStopOper.ListCond_Flow = cdvRwkFlow.Text;
        }

        private void cdvRwkOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRetFlow.Text = "";
            cdvRetOper.Text = "";
        }

        private void cdvRwkStopOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvRwkOper, 1) == false)
            {
                cdvRwkStopOper.RefuseEventExec = true;
                cdvRwkStopOper.IsPopup = false;
                return;
            }
        }

        private void cdvRetFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRetOper.Text = "";

            cdvRetOper.ListCond_Step = '2';
            cdvRetOper.ListCond_Flow = cdvRetFlow.Text;
        }


    
    }
}
