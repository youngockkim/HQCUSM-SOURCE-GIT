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
    public partial class udcFutureActionAdapt : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionAdapt()
        {
            InitializeComponent();
        }

        #region "Functions"

        public override void setMFO(string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            initControl();

            base.setMFO(s_mat_id, i_mat_ver, s_flow, s_oper);

            cdvLotType.Init();
            MPCF.InitListView(cdvLotType.GetListView);
            cdvLotType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvLotType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvLotType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvLotType.GetListView, '1', MPGC.MP_WIP_LOT_TYPE);
            cdvLotType.Items.Insert(0, new ListViewItem(new string[] {"@",""}));

            cdvOwnerCode.Init();
            MPCF.InitListView(cdvOwnerCode.GetListView);
            cdvOwnerCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvOwnerCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOwnerCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvOwnerCode.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);
            cdvOwnerCode.Items.Insert(0, new ListViewItem(new string[] { "@", "" }));

            cdvCreateCode.Init();
            MPCF.InitListView(cdvCreateCode.GetListView);
            cdvCreateCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvCreateCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCreateCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCreateCode.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);
            cdvCreateCode.Items.Insert(0, new ListViewItem(new string[] { "@", "" }));

            cdvMatId.Text = "@";
            cdvFlow.Text = "@";
            cdvOper.Text = "@";
            cdvLotType.Text = "@";
            cboPriority.Text = "@";
            cdvCreateCode.Text = "@";
            cdvOwnerCode.Text = "@";
            cboOperator1.Text = "@";
            cboOperator2.Text = "@";
            cboOperator3.Text = "@";
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cdvMatId.Text = node.GetString("DATA_1");
            cdvMatId.Version = MPCF.ToInt(node.GetString("DATA_2"));
            cdvFlow.Text = node.GetString("DATA_3");
            cdvFlow.Sequence = MPCF.ToInt(node.GetString("DATA_4"));
            cdvOper.Text = node.GetString("DATA_5");

            cdvLotType.Text = node.GetString("DATA_6");
            cboPriority.Text = node.GetString("DATA_7");
            cdvCreateCode.Text = node.GetString("DATA_8");
            cdvOwnerCode.Text = node.GetString("DATA_9");

            cboOperator1.Text = node.GetString("DATA_10");
            cboOperator2.Text = node.GetString("DATA_12");
            cboOperator3.Text = node.GetString("DATA_14");

            numQty1.Value = MPCF.ToDecimal(node.GetString("DATA_11"));
            numQty2.Value = MPCF.ToDecimal(node.GetString("DATA_13"));
            numQty3.Value = MPCF.ToDecimal(node.GetString("DATA_15"));

            chkNoAutoTermLot.Checked = false;
            if (node.GetString("DATA_16") == "Y")
                chkNoAutoTermLot.Checked = true;
        }

        public override bool checkCondition()
        {
            if (cdvMatId.Text == "@" &&
               cdvFlow.Text == "@" &&
               cdvOper.Text == "@" &&
               cdvLotType.Text == "@" &&
               cboPriority.Text == "@" &&
               cdvCreateCode.Text == "@" &&
               cdvOwnerCode.Text == "@" &&
               cboOperator1.Text == "@" &&
               cboOperator2.Text == "@" &&
               cboOperator3.Text == "@")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                return false;
            }

            return true;
        }
        
        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_ADAPT);

            node.AddString("DATA_1", cdvMatId.Text);
            if (cdvMatId.Text == "@")
            {
                node.AddString("DATA_2", "@");
            }
            else
            {
                node.AddString("DATA_2", cdvMatId.Version.ToString());
            }

            node.AddString("DATA_3", cdvFlow.Text);
            if (cdvFlow.Text == "@")
            {
                node.AddString("DATA_4", "@");
            }
            else
            {
                node.AddString("DATA_4", cdvFlow.Sequence.ToString());
            }

            node.AddString("DATA_5", cdvOper.Text);
            node.AddString("DATA_6", cdvLotType.Text);
            node.AddString("DATA_7", cboPriority.Text);
            node.AddString("DATA_8", cdvCreateCode.Text);
            node.AddString("DATA_9", cdvOwnerCode.Text);

            node.AddString("DATA_10", cboOperator1.Text);
            node.AddString("DATA_12", cboOperator2.Text);
            node.AddString("DATA_14", cboOperator3.Text);

            node.AddString("DATA_11", numQty1.Value.ToString());
            node.AddString("DATA_13", numQty2.Value.ToString());
            node.AddString("DATA_15", numQty3.Value.ToString());
            
            if(chkNoAutoTermLot.Checked == true)
                node.AddString("DATA_16", "Y");
        }

        #endregion

        private void cboCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cdvMatId_MaterialButtonPressAfter(object sender, EventArgs e)
        {
            if (cdvMatId.MaterialItems.Count > 0)
            {
                cdvMatId.MaterialItems.Insert(0, new ListViewItem(new string[] { "@", "", "" }));
            }
        }

        private void cdvMatId_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvMatId.Text) != "@" && MPCF.Trim(cdvMatId.Text) != "")
            {
                cdvFlow.Text = "";
                cdvOper.Text = "";
            }
            else
            {
                cdvFlow.Text = "@";
                cdvOper.Text = "@";
            }
        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvMatId.Text) == "@" || MPCF.Trim(cdvMatId.Text) == "")
            {
                switch (base.getMFOSelectLevel())
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.M:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MF:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                        cdvFlow.ListCond_Step = '2';
                        cdvFlow.ListCond_MatID = m_s_mat_id;
                        cdvFlow.ListCond_MatVersion = m_i_mat_ver;
                        break;

                    default:
                        cdvFlow.ListCond_Step = '1';
                        cdvFlow.ListCond_MatID = "";
                        cdvFlow.ListCond_MatVersion = 0;
                        break;
                }
            }
            else
            {
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMatId.Text;
                cdvFlow.ListCond_MatVersion = cdvMatId.Version;
            }
        }

        private void cdvFlow_FlowButtonPressAfter(object sender, EventArgs e)
        {
            if (cdvFlow.FlowItems.Count > 0)
            {
                cdvFlow.FlowItems.Insert(0, new ListViewItem(new string[] { "@", "", "" }));
            }
        }

        private void cdvFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvFlow.Text) != "@" && MPCF.Trim(cdvFlow.Text) != "")
            {
                cdvOper.Text = "";
            }
            else
            {
                cdvOper.Text = "@";
            }
        }

        private void cdvOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvFlow.Text) == "" || MPCF.Trim(cdvFlow.Text) == "@")
            {
                switch (base.getMFOSelectLevel())
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.F:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MF:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                        cdvOper.ListCond_Step = '2';
                        cdvOper.ListCond_Flow = m_s_flow;
                        break;

                    default:
                        cdvOper.ListCond_Step = '1';
                        cdvOper.ListCond_Flow = "";
                        break;
                }
            }
            else
            {
                cdvOper.ListCond_Step = '2';
                cdvOper.ListCond_Flow = cdvFlow.Text;
            }
        }

        private void cdvOper_ButtonPressAfter(object sender, EventArgs e)
        {
            if (cdvOper.Items.Count > 0)
            {
                cdvOper.Items.Insert(0, new ListViewItem(new string[] { "@", "" }));
            }
        }

        private void cboOperator1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOperator1.Text == "@")
            {
                numQty1.Value = 0;
                numQty1.Enabled = false;
            }
            else
            {
                numQty1.Enabled = true;
            }
        }
        
        private void cboOperator2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOperator2.Text == "@")
            {
                numQty2.Value = 0;
                numQty2.Enabled = false;
            }
            else
            {
                numQty2.Enabled = true;
            }
        }

        private void cboOperator3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOperator3.Text == "@")
            {
                numQty3.Value = 0;
                numQty3.Enabled = false;
            }
            else
            {
                numQty3.Enabled = true;
            }
        }


    }
}

