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
    public partial class udcStepActionRepair : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionRepair()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            cdvRefOper.Init();
            MPCF.InitListView(cdvRefOper.GetListView);
            cdvRefOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvRefOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvRefOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvRefOper.GetListView, '1');

            cdvRepairCode.Init();
            MPCF.InitListView(cdvRepairCode.GetListView);
            cdvRepairCode.Columns.Add("Repair Code", 150, HorizontalAlignment.Left);
            cdvRepairCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvRepairCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvRepairCode.GetListView, '1', MPGC.MP_WIP_REPAIR_CODE);

            cdvRepairOper.Init();
            MPCF.InitListView(cdvRepairOper.GetListView);
            cdvRepairOper.Columns.Add("Repair Code", 150, HorizontalAlignment.Left);
            cdvRepairOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvRepairOper.SelectedSubItemIndex = 0;

            cdvReturnOper.Init();
            MPCF.InitListView(cdvReturnOper.GetListView);
            cdvReturnOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvReturnOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvReturnOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvReturnOper.GetListView, '1');
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            chkMultiTrans.Checked = node.GetChar("MULTI_TR_FLAG") == 'Y' ? true : false;

            cdvRefOper.Text = node.GetString("DATA_1");
            cdvRepairCode.Text = node.GetString("DATA_2");
            cdvRepairOper.Text = node.GetString("DATA_3");
            cdvReturnOper.Text = node.GetString("DATA_4");
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvRepairCode, 1) == false) return false;
            if (MPCF.CheckValue(cdvRepairOper, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_REPAIR);

            node.AddChar("MULTI_TR_FLAG", chkMultiTrans.Checked == true ? 'Y' : ' ');
            node.AddString("DATA_1", cdvRefOper.Text);
            node.AddString("DATA_2", cdvRepairCode.Text);
            node.AddString("DATA_3", cdvRepairOper.Text);
            node.AddString("DATA_4", cdvReturnOper.Text);
        }

        private bool ViewRepairOperList()
        {
            ListViewItem itmX;
            int i;

            TRSNode in_node = new TRSNode("VIEW_REPAIR_OPER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REPAIR_OPER_LIST_OUT");

            MPCF.InitListView(cdvRepairOper.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", cdvRefOper.Text);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Repair_Oper_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("REP_OPER"), (int)SMALLICON_INDEX.IDX_FLOW);
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("REP_OPER_DESC")));
                    cdvRepairOper.Items.Add(itmX);
                }

                in_node.SetString("NEXT_REP_OPER", out_node.GetString("NEXT_REP_OPER"));

            } while (in_node.GetString("NEXT_REP_OPER") != "");

            return true;
        }

        private bool ViewReturnOper()
        {
            TRSNode in_node = new TRSNode("VIEW_REPAIR_OPER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REPAIR_OPER_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("OPER", cdvRefOper.Text);
            in_node.AddString("NEXT_REP_OPER", cdvRepairOper.Text);

            if (MPCR.CallService("WIP", "WIP_View_Repair_Oper_List", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvReturnOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_OPER"));

            return true;
        }

        #endregion

        private void cdvRefOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRepairCode.Text = "";
            cdvRepairOper.Text = "";
            cdvReturnOper.Text = "";
        }

        private void cdvRepairOper_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvRefOper, 1) == false) return;
            if (ViewRepairOperList() == false) return;
        }

        private void cdvRepairOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvReturnOper.Text = "";
            if (ViewReturnOper() == false) return;
        }

    
    
    }
}
