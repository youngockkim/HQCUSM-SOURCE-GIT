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
    public partial class udcStepActionHold : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionHold()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            cdvHoldCode.Init();
            MPCF.InitListView(cdvHoldCode.GetListView);
            cdvHoldCode.Columns.Add("Hold Code", 150, HorizontalAlignment.Left);
            cdvHoldCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvHoldCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvHoldCode.GetListView, '1', MPGC.MP_WIP_HOLD_CODE);
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            chkMultiTrans.Checked = node.GetChar("MULTI_TR_FLAG") == 'Y' ? true : false;

            cdvHoldCode.Text = node.GetString("DATA_1");
            txtHoldPass.Text = node.GetString("DATA_2");
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvHoldCode, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_HOLD);

            node.AddChar("MULTI_TR_FLAG", chkMultiTrans.Checked == true ? 'Y' : ' ');
            node.AddString("DATA_1", cdvHoldCode.Text);
            node.AddString("DATA_2", txtHoldPass.Text);
        }

        #endregion

    }
}
