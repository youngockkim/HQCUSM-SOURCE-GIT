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
    public partial class udcFutureActionInputAttribute : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionInputAttribute()
        {
            InitializeComponent();
            cboActionType.SelectedIndex = 0;
        }

        #region "Functions"

        public override void setMFO(string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            initControl();
            setComments();
            cboActionType.SelectedIndex = 0;

            base.setMFO(s_mat_id, i_mat_ver, s_flow, s_oper);

            cdvAttrName.Init();
            MPCF.InitListView(cdvAttrName.GetListView);
            cdvAttrName.Columns.Add("SEQ", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrName.SelectedSubItemIndex = 1;
            cdvAttrName.DisplaySubItemIndex = 1;
            BASLIST.ViewAttributeNameList(cdvAttrName.GetListView, '1', MPGC.MP_ATTR_TYPE_LOT);

            cdvAttrNameFalse.Init();
            MPCF.InitListView(cdvAttrNameFalse.GetListView);
            cdvAttrNameFalse.Columns.Add("SEQ", 150, HorizontalAlignment.Left);
            cdvAttrNameFalse.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrNameFalse.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrNameFalse.SelectedSubItemIndex = 1;
            cdvAttrNameFalse.DisplaySubItemIndex = 1;
            BASLIST.ViewAttributeNameList(cdvAttrNameFalse.GetListView, '1', MPGC.MP_ATTR_TYPE_LOT);
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cdvAttrName.Text = node.GetString("DATA_1");
            txtAttrValue.Text = node.GetString("DATA_2");

            if (node.GetChar("ACTION_TYPE") == '1')
            {
                cboActionType.SelectedIndex = 0;
            }
            else if (node.GetChar("ACTION_TYPE") == '2')
            {
                cboActionType.SelectedIndex = 1;

                cdvAttrNameFalse.Text = node.GetString("DATA_11");
                txtAttrValueFalse.Text = node.GetString("DATA_12");
            }
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvAttrName, 1) == false) return false;

            if (cboActionType.SelectedIndex == 1)
            {
                if (MPCF.CheckValue(cdvAttrNameFalse, 1) == false) return false;
            }

            return true;
        }
        
        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "INPUT ATTRIBUTE");

            if (cboActionType.SelectedIndex == 0)
                node.AddChar("ACTION_TYPE", '1');
            else if (cboActionType.SelectedIndex == 1)
                node.AddChar("ACTION_TYPE", '2');

            node.AddString("DATA_1", cdvAttrName.Text);
            node.AddString("DATA_2", txtAttrValue.Text);

            node.AddString("DATA_11", cdvAttrNameFalse.Text);
            node.AddString("DATA_12", txtAttrValueFalse.Text);
        }

        private void setComments()
        {
            txtCmmt1.Text = txtCmmt11.Text = "$INCREASE(number) - Increase from current value by given \"number\"";
            txtCmmt2.Text = txtCmmt12.Text = "$DECREASE(number) - Decrease from current value by given \"number\"";
            txtCmmt3.Text = txtCmmt13.Text = "$DATE - Update as system date by \"YYYYMMDD\" format";
            txtCmmt4.Text = txtCmmt14.Text = "$DATETIME - Update as system date/time by \"YYYYMMDDHH24MISS\" format";
        }

        #endregion

        private void cboActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActionType.SelectedIndex == 0)
            {
                grpActionFalse.Visible = false;
                MPCF.FieldClear(grpActionFalse);

                grpActionTrue.Text = "";
            }
            else
            {
                grpActionFalse.Visible = true;
                grpActionTrue.Text = MPCF.FindLanguage("True Action", CAPTION_TYPE.LABEL);
                setComments();
            }
        }

        private void cboActionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}

