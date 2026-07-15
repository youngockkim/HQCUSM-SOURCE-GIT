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
    public partial class udcStepActionTerminate : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionTerminate()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            cdvTermCode.Init();
            MPCF.InitListView(cdvTermCode.GetListView);
            cdvTermCode.Columns.Add("Delete Reason", 150, HorizontalAlignment.Left);
            cdvTermCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTermCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTermCode.GetListView, '1', MPGC.MP_WIP_TERMINATE_CODE);
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            chkMultiTrans.Checked = node.GetChar("MULTI_TR_FLAG") == 'Y' ? true : false;

            cdvTermCode.Text = node.GetString("DATA_1");
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvTermCode, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_TERMINATE);

            node.AddChar("MULTI_TR_FLAG", chkMultiTrans.Checked == true ? 'Y' : ' ');
            node.AddString("DATA_1", cdvTermCode.Text);
        }

        #endregion

    }
}
