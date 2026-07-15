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
    public partial class udcStepActionInputAttribute : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionInputAttribute()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        private void setComments()
        {
            txtCmmt1.Text = "$INCREASE(number) - Increase from current value by given \"number\"";
            txtCmmt2.Text = "$DECREASE(number) - Decrease from current value by given \"number\"";
            txtCmmt3.Text = "$DATE - Update as system date by \"YYYYMMDD\" format";
            txtCmmt4.Text = "$DATETIME - Update as system date/time by \"YYYYMMDDHH24MISS\" format";
        }

        public override void initControl()
        {
            base.initControl();

            setComments();

            cdvAttrType.Init();
            MPCF.InitListView(cdvAttrType.GetListView);
            cdvAttrType.Columns.Add("Attribute Type", 150, HorizontalAlignment.Left);
            cdvAttrType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrType.SelectedSubItemIndex = 0;
            cdvAttrType.DisplaySubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAttrType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);

            cdvAttrName.Init();
            MPCF.InitListView(cdvAttrName.GetListView);
            cdvAttrName.Columns.Add("SEQ", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrName.SelectedSubItemIndex = 1;
            cdvAttrName.DisplaySubItemIndex = 1;
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            chkMultiTrans.Checked = node.GetChar("MULTI_TR_FLAG") == 'Y' ? true : false;
            cdvAttrType.Text = node.GetString("DATA_1");
            cdvAttrName.Text = node.GetString("DATA_2");
            txtAttrValue.Text = node.GetString("DATA_3");
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false) return false;
            if (MPCF.CheckValue(cdvAttrName, 1) == false) return false;
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "INPUT ATTRIBUTE");

            node.AddChar("MULTI_TR_FLAG", chkMultiTrans.Checked == true ? 'Y' : ' ');
            node.AddString("DATA_1", cdvAttrType.Text);
            node.AddString("DATA_2", cdvAttrName.Text);
            node.AddString("DATA_3", txtAttrValue.Text);
        }

        #endregion

        private void cdvAttrType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvAttrName.Text = "";
            txtAttrValue.Text = "";
        }

        private void cdvAttrName_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false) return;
            BASLIST.ViewAttributeNameList(cdvAttrName.GetListView, '1', cdvAttrType.Text);
        }

        private void cdvAttrName_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtAttrValue.Text = "";
        }
    }
}
