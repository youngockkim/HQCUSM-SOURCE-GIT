using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.UI;
using Miracom.UI.Controls.MCCodeView;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupGroupDefinition : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupGroupDefinition()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const string GCM_GRP_TABLE_NAME = "GROUP_ITEM_NAME";
        private const string GCM_CMF_TABLE_NAME = "CMF_ITEM_NAME";
        private const string GCM_FACTORY_TYPE = "FACTORY_TYPE";
        private const string _DEFAULT_GCM_TABLE = "Default GCM Table";

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        
        #endregion

        #region " Function Definition "

        // Get_FacCmf_Data()
        //       - Get FacCmf Data
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal iStep As Integer : Group = 1, Cmf = 2
        //        - ByVal sItemName As String : Item Name
        //
        private void Get_FacCmf_Data(char c_step, string sItemName)
        {            
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ArrayList txtList;
            ArrayList cdvList;
            int i;
            
            if (c_step == '1')
            {
                MPCF.FieldClear(this.grpGrpPrompt);
            }

            if (WIPLIST.ViewFactoryCmfData('1', sItemName, ref out_node, "", true) == false)
            {
                return;
            }

            if (c_step == '1')
            {
                txtList = MPCF.GetIndexedControl("txtPpt", this.grpGrpPrompt);

                // Variable Group Table 
                cdvList = MPCF.GetIndexedControl("cdvTbl", this.grpGrpPrompt);
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        ((TextBox)txtList[i]).Text = out_node.GetList(0)[i].GetString("PROMPT");

                        // Variable Group Table 
                        ((MCCodeView)cdvList[i]).Text = out_node.GetList(0)[i].GetString("TABLE_NAME");
                        if (out_node.GetList(0)[i].GetString("TABLE_NAME") == "")
                        {
                            ((MCCodeView)cdvList[i]).Text = _DEFAULT_GCM_TABLE;
                        }
                    }
                }
            }

        }

        // Update_Factory_Cmf()
        //       - Update Factory Customized Field Value
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal iStep As Integer : Group = 1
        //        - ByVal c_step As String : MP_STEP_CREATE/UPDATE/DELETE
        //        - ByVal sItemName As String : MWIPFACCMF??Item Name
        private bool Update_Factory_Cmf(int iStep, char c_step, string sItemName)
        {
            TRSNode in_node = new TRSNode("UPDATE_CMF_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;
            int i = 0;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("ITEM_NAME", MPCF.Trim(sItemName));

            if (iStep == 1)
            {
                ArrayList txtList;
                ArrayList cdvList;
                TextBox txtTemp;
                MCCodeView cdvTemp;

                txtList = MPCF.GetIndexedControl("txtPpt", grpGrpPrompt);
                    
                cdvList = MPCF.GetIndexedControl("cdvTbl", grpGrpPrompt);

                for (i = 0; i < txtList.Count; i++)
                {
                    txtTemp = (TextBox)txtList[i];

                    cdvTemp = (MCCodeView)cdvList[i];

                    list_item = in_node.AddNode("LIST");

                    list_item.AddString("PROMPT", MPCF.Trim(txtTemp.Text));

                    if (MPCF.Trim(cdvTemp.Text) == _DEFAULT_GCM_TABLE)
                    {
                        list_item.AddString("TABLE_NAME", "");
                    }
                    else
                    {
                        list_item.AddString("TABLE_NAME", MPCF.Trim(cdvTemp.Text));
                    }
                }
            }
                
            if (MPCR.CallService("WIP", "WIP_Update_Factory_Cmf_Item", in_node, ref out_node) == false)
            {
                return false;
            }

            if (c_step != 'D')
            {
                MPCR.ShowSuccessMsg(out_node);
            }

            return true;
        }

        //
        // Update_Group_Item()
        //       - Create/Update/Delete Group Item
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_Group_Item(char ProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("TABLE_NAME", "GROUP_ITEM_NAME");
                node = in_node.AddNode("DATA_LIST");
                node.AddString("KEY_1", txtGrpItem.Text);
                node.AddString("DATA_1", txtGroupDesc.Text); 

                if (MPCR.CallService("BAS", "BAS_Update_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (ProcStep == 'D')
                {
                    MPCR.ShowSuccessMsg(out_node);      
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        
        #endregion

        private void frmWIPSetupGroupDefinition_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.InitListView(lisGrpList);

                BASLIST.ViewGCMDataList(lisGrpList, '1', GCM_GRP_TABLE_NAME, (int)SMALLICON_INDEX.IDX_CODE_DATA, null, "", true, -1, -1, null);
                
                if (MPGO.AllowVariableGroupTable() == false)
                {
                    lblMTableName.Visible = false;
                    cdvTbl1.Visible = false;
                    cdvTbl2.Visible = false;
                    cdvTbl3.Visible = false;
                    cdvTbl4.Visible = false;
                    cdvTbl5.Visible = false;
                    cdvTbl6.Visible = false;
                    cdvTbl7.Visible = false;
                    cdvTbl8.Visible = false;
                    cdvTbl9.Visible = false;
                    cdvTbl10.Visible = false;
                }

                b_load_flag = true;

                lblDataCount.Text = lisGrpList.Items.Count.ToString();
            }
        }

        private void lisGrpList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);

                if (lisGrpList.SelectedItems.Count > 0)
                {
                    txtGrpItem.Text = lisGrpList.SelectedItems[0].Text;
                    txtGroupDesc.Text = lisGrpList.SelectedItems[0].SubItems[1].Text;
                    Get_FacCmf_Data('1', txtGrpItem.Text);                
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Update_Group_Item(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                Update_Factory_Cmf(1, MPGC.MP_STEP_UPDATE, txtGrpItem.Text);
                Get_FacCmf_Data('1', txtGrpItem.Text);

                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }              
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lisGrpList.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisGrpList.Items[0].Selected = true;
                    return;
                }
                
                if (Update_Group_Item(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }

                Update_Factory_Cmf(1, MPGC.MP_STEP_UPDATE, txtGrpItem.Text);
                Get_FacCmf_Data('1', txtGrpItem.Text);
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }  
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (Update_Factory_Cmf(1, MPGC.MP_STEP_DELETE, txtGrpItem.Text) == false)
                {
                    return;
                }

                if (Update_Group_Item(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }

                string strTemp = "";
                Get_FacCmf_Data('1', strTemp);
                MPCF.FieldClear(this.pnlGrpItem);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            MPCF.FindListItemPartial(lisGrpList, txtFind.Text, 0, true, false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisGrpList, txtFind.Text, true, false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";

                if (BASLIST.ViewGCMDataList(lisGrpList, '1', GCM_GRP_TABLE_NAME, (int)SMALLICON_INDEX.IDX_CODE_DATA, null, "", true, -1, -1, null) == false)
                {
                    return;
                }

                lblDataCount.Text = lisGrpList.Items.Count.ToString();
                if (lisGrpList.Items.Count > 0)
                {
                    MPCF.FindListItem(lisGrpList, txtGrpItem.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisGrpList, this.Text, "");
        }

        private void cdvTbl_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            ListViewItem itmX;

            try
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

                cdvTemp.Init();
                MPCF.InitListView(cdvTemp.GetListView);
                cdvTemp.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
                cdvTemp.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMTableList(cdvTemp.GetListView, '1');
                itmX = cdvTemp.GetListView.Items.Insert(0, _DEFAULT_GCM_TABLE);
                itmX.SubItems.Add(_DEFAULT_GCM_TABLE);
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }



    }
}
