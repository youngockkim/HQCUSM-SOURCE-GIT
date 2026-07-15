using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
namespace Miracom.RTDCore
{
    public partial class frmRTDTranReDispatchLot : Miracom.MESCore.TranForm01
    {
        public frmRTDTranReDispatchLot()
        {
            InitializeComponent();
        }

        private bool CheckCondition()
        {
            if (MPCF.CheckValue(cboChangeMember, 1) == false) return false;

            if (cdvMember1.Visible == true)
            {
                if (MPCF.CheckValue(cdvMember1, 1) == false) return false;
            }
            if (cdvMember2.Visible == true)
            {
                if (MPCF.CheckValue(cdvMember2, 1) == false) return false;
            }
            if (cdvMember3.Visible == true)
            {
                if (MPCF.CheckValue(cdvMember3, 1) == false) return false;
            }
            if (cdvMember4.Visible == true)
            {
                if (MPCF.CheckValue(cdvMember4, 1) == false) return false;
            }

            return true;
        }

        private bool Re_Dispatch_Lot()
        {
            TRSNode in_node = new TRSNode("RE_DISPATCH_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (cboChangeMember.SelectedIndex == 12)
                {
                    in_node.AddString("CHANGE_MEMBER", "ALL");
                }
                else if (cboChangeMember.SelectedIndex == 0)
                {
                    in_node.AddString("CHANGE_MEMBER", "LOT_ID");
                    in_node.AddString("LOT_ID", cdvMember1.Text);
                }
                else if (cboChangeMember.SelectedIndex == 1)
                {
                    in_node.AddString("CHANGE_MEMBER", "RES_ID");
                    in_node.AddString("RES_ID", cdvMember1.Text);
                }
                else if (cboChangeMember.SelectedIndex == 2)
                {
                    in_node.AddString("CHANGE_MEMBER", "RESG_ID");
                    in_node.AddString("RESG_ID", cdvMember1.Text);
                }
                else if (cboChangeMember.SelectedIndex == 3)
                {
                    in_node.AddString("CHANGE_MEMBER", "MAT_ID");
                    in_node.AddString("MAT_ID", cdvMember1.Text);
                    in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMember2.Text));
                }
                else if (cboChangeMember.SelectedIndex == 4)
                {
                    in_node.AddString("CHANGE_MEMBER", "FLOW");
                    in_node.AddString("FLOW", cdvMember1.Text);
                }
                else if (cboChangeMember.SelectedIndex == 5)
                {
                    in_node.AddString("CHANGE_MEMBER", "OPER");
                    in_node.AddString("OPER", cdvMember1.Text);
                }
                else if (cboChangeMember.SelectedIndex == 6)
                {
                    in_node.AddString("CHANGE_MEMBER", "BATCH_ID");
                    in_node.AddString("BATCH_ID", cdvMember1.Text);
                }
                else if (cboChangeMember.SelectedIndex == 7)
                {
                    in_node.AddString("CHANGE_MEMBER", "MFO");
                    in_node.AddString("MAT_ID", cdvMember1.Text);
                    in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMember2.Text));
                    in_node.AddString("FLOW", cdvMember3.Text);
                    in_node.AddString("OPER", cdvMember4.Text);
                }
                else if (cboChangeMember.SelectedIndex == 8)
                {
                    in_node.AddString("CHANGE_MEMBER", "FO");
                    in_node.AddString("FLOW", cdvMember1.Text);
                    in_node.AddString("OPER", cdvMember2.Text);
                }
                else if (cboChangeMember.SelectedIndex == 9)
                {
                    in_node.AddString("CHANGE_MEMBER", "MO");
                    in_node.AddString("MAT_ID", cdvMember1.Text);
                    in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMember2.Text));
                    in_node.AddString("OPER", cdvMember3.Text);
                }
                else if (cboChangeMember.SelectedIndex == 10)
                {
                    in_node.AddString("CHANGE_MEMBER", "DSP_ID");
                    in_node.AddString("DSP_ID", cdvMember1.Text);
                }
                else if (cboChangeMember.SelectedIndex == 11)
                {
                    in_node.AddString("CHANGE_MEMBER", "RULE_ID");
                    in_node.AddString("RULE_ID", cdvMember1.Text);               
                }
                else if (cboChangeMember.SelectedIndex == 13) //Add by J.S. 2011.11.10
                {
                    in_node.AddString("CHANGE_MEMBER", "CHILD_LOTS");
                    in_node.AddString("LOT_ID", cdvMember1.Text);
                    in_node.AddString("ETC_ID", "20000101010000"); //이시간 이후에 만들어진 Child lot redispatch
                }
                else if (cboChangeMember.SelectedIndex == 14) //Addde by Chris Jung 2013.09.06 
                {
                    in_node.AddString("CHANGE_MEMBER", "ZERO_QTY_LOTS");
                }

                //Add by J.S. 2009.03.19
                if (chkUnselectCapableOnly.Checked == true)
                {
                    in_node.AddChar("UNSELECT_CAPABLE_ONLY_FLAG", 'Y');
                }
                else
                {
                    in_node.AddChar("UNSELECT_CAPABLE_ONLY_FLAG", ' ');
                }

                if (MPCR.CallService("RTD", "RTD_Re_Dispatch_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);


                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private void cboChangeMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChangeMember.SelectedIndex == 12)
            {
                lblMember1.Visible = false;
                lblMember2.Visible = false;
                lblMember3.Visible = false;
                lblMember4.Visible = false;
                cdvMember1.Text = "";
                cdvMember1.Visible = false;
                cdvMember2.Text = "";
                cdvMember2.Visible = false;
                cdvMember3.Text = "";
                cdvMember3.Visible = false;
                cdvMember4.Text = "";
                cdvMember4.Visible = false;
            }
            else if (cboChangeMember.SelectedIndex == 3)
            {
                lblMember1.Text = cboChangeMember.Text;
                lblMember1.Visible = true;
                lblMember2.Text = "Material Ver";
                lblMember2.Visible = true;
                lblMember3.Visible = false;
                lblMember4.Visible = false;
                cdvMember1.Text = "";
                cdvMember1.Visible = true;
                cdvMember2.Text = "";
                cdvMember2.Visible = true;
                cdvMember3.Text = "";
                cdvMember3.Visible = false;
                cdvMember4.Text = "";
                cdvMember4.Visible = false;
            }
            else if (cboChangeMember.SelectedIndex == 7)
            {
                lblMember1.Text = "Material";
                lblMember1.Visible = true;
                lblMember2.Text = "Material Ver";
                lblMember2.Visible = true;
                lblMember3.Text = "Flow";
                lblMember3.Visible = true;
                lblMember4.Text = "Operation";
                lblMember4.Visible = true;
                cdvMember1.Text = "";
                cdvMember1.Visible = true;
                cdvMember2.Text = "";
                cdvMember2.Visible = true;
                cdvMember3.Text = "";
                cdvMember3.Visible = true;
                cdvMember4.Text = "";
                cdvMember4.Visible = true;
            }
            else if (cboChangeMember.SelectedIndex == 8)
            {
                lblMember1.Text = "Flow";
                lblMember1.Visible = true;
                lblMember2.Text = "Operation";
                lblMember2.Visible = true;
                lblMember3.Visible = false;
                lblMember4.Visible = false;
                cdvMember1.Text = "";
                cdvMember1.Visible = true;
                cdvMember2.Text = "";
                cdvMember2.Visible = true;
                cdvMember3.Text = "";
                cdvMember3.Visible = false;
                cdvMember4.Text = "";
                cdvMember4.Visible = false;
            }
            else if (cboChangeMember.SelectedIndex == 9)
            {
                lblMember1.Text = "Material";
                lblMember1.Visible = true;
                lblMember2.Text = "Material Ver";
                lblMember2.Visible = true;
                lblMember3.Text = "Operation";
                lblMember3.Visible = true;
                lblMember4.Visible = false;
                cdvMember1.Text = "";
                cdvMember1.Visible = true;
                cdvMember2.Text = "";
                cdvMember2.Visible = true;
                cdvMember3.Text = "";
                cdvMember3.Visible = true;
                cdvMember4.Text = "";
                cdvMember4.Visible = false;
            }
            else if (cboChangeMember.SelectedIndex == 13) //Add by J.S. 2011.11.10
            {
                lblMember1.Text = "Mother Lot";
                lblMember1.Visible = true;
                lblMember2.Visible = false;
                lblMember3.Visible = false;
                lblMember4.Visible = false;
                cdvMember1.Text = "";
                cdvMember1.Visible = true;
                cdvMember2.Text = "";
                cdvMember2.Visible = false;
                cdvMember3.Text = "";
                cdvMember3.Visible = false;
                cdvMember4.Text = "";
                cdvMember4.Visible = false;
            }
            else
            {
                lblMember1.Text = cboChangeMember.Text;
                lblMember1.Visible = true;
                lblMember2.Visible = false;
                lblMember3.Visible = false;
                lblMember4.Visible = false;
                cdvMember1.Text = "";
                cdvMember1.Visible = true;
                cdvMember2.Text = "";
                cdvMember2.Visible = false;
                cdvMember3.Text = "";
                cdvMember3.Visible = false;
                cdvMember4.Text = "";
                cdvMember4.Visible = false;
            }

            if (cboChangeMember.SelectedIndex == 0 || cboChangeMember.SelectedIndex == 6 || cboChangeMember.SelectedIndex == 13)
            {
                cdvMember1.VisibleButton = false;
            }
            else
            {
                cdvMember1.VisibleButton = true;
            }

        }

        private void cdvMember1_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvMember2.Text = "";
            cdvMember3.Text = "";
            cdvMember4.Text = "";
        }

        private void cdvMember2_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvMember3.Text = "";
            cdvMember4.Text = "";
        }

        private void cdvMember3_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvMember4.Text = "";
        }

        private void cdvMember1_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvMember1.Init();
                MPCF.InitListView(cdvMember1.GetListView);
                cdvMember1.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvMember1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvMember1.SelectedSubItemIndex = 0;
                if (cboChangeMember.SelectedIndex == 1)
                {
                    RASLIST.ViewResourceList(cdvMember1.GetListView, false);
                }
                else if (cboChangeMember.SelectedIndex == 2)
                {
                    RASLIST.ViewResourceGroupList(cdvMember1.GetListView, '1');
                }
                else if (cboChangeMember.SelectedIndex == 3 || cboChangeMember.SelectedIndex == 7 || cboChangeMember.SelectedIndex == 9)
                {
                    WIPLIST.ViewMaterialList(cdvMember1.GetListView, '1');
                }
                else if (cboChangeMember.SelectedIndex == 4 || cboChangeMember.SelectedIndex == 8)
                {
                    WIPLIST.ViewFlowList(cdvMember1.GetListView, '1');
                }
                else if (cboChangeMember.SelectedIndex == 5)
                {
                    WIPLIST.ViewOperationList(cdvMember1.GetListView, '1', "", 0, "", "", null, "");
                }
                else if (cboChangeMember.SelectedIndex == 6)
                {
                    //batch
                }

                else if (cboChangeMember.SelectedIndex == 10)
                {
                    RTDLIST.ViewDispatcherList(cdvMember1.GetListView, '1', null, "");
                }
                else if (cboChangeMember.SelectedIndex == 11)
                {
                    RTDLIST.ViewRuleList(cdvMember1.GetListView, '1', null, "", ' ');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvMember2_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvMember2.Init();
                MPCF.InitListView(cdvMember2.GetListView);
                cdvMember2.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvMember2.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvMember2.SelectedSubItemIndex = 0;
                if (cboChangeMember.SelectedIndex == 3 || cboChangeMember.SelectedIndex == 7 || cboChangeMember.SelectedIndex == 9)
                {
                    if (MPCF.CheckValue(cdvMember1, 1) == false) return;
                    WIPLIST.ViewMaterialVersionList(cdvMember2.GetListView, '1', cdvMember1.Text);
                }
                else if (cboChangeMember.SelectedIndex == 8)
                {
                    if (MPCF.CheckValue(cdvMember1, 1) == false) return;
                    WIPLIST.ViewOperationList(cdvMember2.GetListView, '2', cdvMember1.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvMember3_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvMember3.Init();
                MPCF.InitListView(cdvMember3.GetListView);
                cdvMember3.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvMember3.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvMember3.SelectedSubItemIndex = 0;
                if (cboChangeMember.SelectedIndex == 7)
                {
                    WIPLIST.ViewFlowList(cdvMember3.GetListView, '3', cdvMember1.Text, MPCF.ToInt(cdvMember2.Text));
                }
                
                else if (cboChangeMember.SelectedIndex == 9)
                {
                    if (MPCF.CheckValue(cdvMember1, 1) == false) return;
                    if (MPCF.CheckValue(cdvMember2, 1) == false) return;
                    WIPLIST.ViewOperationList(cdvMember3.GetListView, '3', cdvMember1.Text, MPCF.ToInt(cdvMember2.Text));
                }               
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvMember4_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvMember4.Init();
                MPCF.InitListView(cdvMember4.GetListView);
                cdvMember4.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvMember4.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvMember4.SelectedSubItemIndex = 0;
                if (cboChangeMember.SelectedIndex == 7)
                {
                    if (MPCF.CheckValue(cdvMember1, 1) == false) return;
                    if (MPCF.CheckValue(cdvMember2, 1) == false) return;
                    if (MPCF.CheckValue(cdvMember3, 1) == false) return;
                    
                    WIPLIST.ViewOperationList(cdvMember4.GetListView, '4', cdvMember1.Text, MPCF.ToInt(cdvMember2.Text), cdvMember3.Text, "", null, "");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false) return ;
            Re_Dispatch_Lot();
        }

        private void frmRTDTranReDispatchLot_Load(object sender, EventArgs e)
        {
            lblMember1.Visible = false;
            lblMember2.Visible = false;
            lblMember3.Visible = false;
            lblMember4.Visible = false;
            cdvMember1.Text = "";
            cdvMember1.Visible = false;
            cdvMember2.Text = "";
            cdvMember2.Visible = false;
            cdvMember3.Text = "";
            cdvMember3.Visible = false;
            cdvMember4.Text = "";
            cdvMember4.Visible = false;
        }     
    }

    
}

