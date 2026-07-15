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
    public partial class udcStepActionRelease : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionRelease()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            cdvReleaseCode.Init();
            MPCF.InitListView(cdvReleaseCode.GetListView);
            cdvReleaseCode.Columns.Add("Release Code", 150, HorizontalAlignment.Left);
            cdvReleaseCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvReleaseCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvReleaseCode.GetListView, '1', MPGC.MP_WIP_RELEASE_CODE);

            cdvHoldCode.Init();
            MPCF.InitListView(cdvHoldCode.GetListView);
            cdvHoldCode.Columns.Add("Hold Code", 150, HorizontalAlignment.Left);
            cdvHoldCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvHoldCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvHoldCode.GetListView, '1', MPGC.MP_WIP_HOLD_CODE);
            cdvHoldCode.InsertEmptyRow(0, 1);
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            chkMultiTrans.Checked = node.GetChar("MULTI_TR_FLAG") == 'Y' ? true : false;

            cdvReleaseCode.Text = node.GetString("DATA_1");
            txtHoldPass.Text = node.GetString("DATA_2");
            cdvHoldCode.Text = node.GetString("DATA_3");
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvReleaseCode, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_RELEASE);

            node.AddChar("MULTI_TR_FLAG", chkMultiTrans.Checked == true ? 'Y' : ' ');
            node.AddString("DATA_1", cdvReleaseCode.Text);
            node.AddString("DATA_2", txtHoldPass.Text);
            node.AddString("DATA_3", cdvHoldCode.Text);
        }

        #endregion

    }
}
