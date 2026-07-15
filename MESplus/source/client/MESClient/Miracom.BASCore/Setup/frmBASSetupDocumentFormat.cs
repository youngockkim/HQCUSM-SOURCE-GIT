using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

using FarPoint.Win.Spread;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using System.IO;
using Miracom.MsgHandler;

namespace Miracom.BASCore
{
    public partial class frmBASSetupDocumentFormat : Miracom.MESCore.SetupForm02
    {
        public frmBASSetupDocumentFormat()
        {
            InitializeComponent();
        }

        #region " Constants Definition "

        #endregion // Constants Definition

        #region " Variables Definition "

        private bool b_load_flag;
        //private string s_base_path;

        #endregion // Variables Definition

        #region " Functions Definition "

        //
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];

            sGrpTableName[0] = MPGC.MP_GCM_FORMAT_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_FORMAT_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_FORMAT_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_FORMAT_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_FORMAT_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_FORMAT_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_FORMAT_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_FORMAT_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_FORMAT_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_FORMAT_GRP_10;

            MPCR.SetGRPItem(MPGC.MP_GRP_FORMAT, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
            MPCR.SetCMFItem(MPGC.MP_CMF_FORMAT, "lblCMF", "cdvCMF", grpCMF);

        }
        /// <summary>
        /// Check Condition
        /// </summary>
        /// <param name></param>        
        /// <returns>true or false</returns>
        private bool CheckCondition()
        {
            return CheckCondition(-1);
        }
        private bool CheckCondition(int i_step)
        {

            if (MPCF.CheckValue(txtDocID, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(cdvModule, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(cdvService, 1) == false)
            {
                return false;
            }

            if (i_step == 1)
            {
                if (MPCF.CheckValue(txtPageWidth, 1) == false)
                {
                    return false;
                }

                if (MPCF.CheckValue(txtPageWidth, 1) == false)
                {
                    return false;
                }
            }

            if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
            {
                tabScreen.SelectedTab = tbpGroup;
                return false;
            }
            if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
            {
                tabScreen.SelectedTab = tbpCustom;
                return false;
            }

            return true;

        }

        /// <summary>
        /// 포멧 정보 갱신
        /// </summary>
        /// <param name="c_step"> Step</param>        
        /// <returns>true or false</returns>        
        private bool Update_Format(char c_step)
        {
            TRSNode in_node = new TRSNode("FORMAT_IN");
            TRSNode out_node = new TRSNode("FORMAT_OUT");
                
            string sPath = string.Empty;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("DOF_ID", MPCF.Trim(txtDocID.Text));                
                in_node.AddString("DOF_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("MODULE_NAME", MPCF.Trim(cdvModule.Text));
                in_node.AddString("SERVICE_NAME", MPCF.Trim(cdvService.Text));
                in_node.AddInt("PAGE_WIDTH", MPCF.Trim(txtPageWidth.Text));
                in_node.AddInt("PAGE_HEIGHT", MPCF.Trim(txtPageHeight.Text));
                in_node.AddString("PAPER_TYPE", MPCF.Trim(cdvPagePaper.Text));

                in_node.AddDouble("TOP_SPACE", MPCF.Trim(txtTop.Text));
                in_node.AddDouble("BOTTOM_SPACE", MPCF.Trim(txtBottom.Text));
                in_node.AddDouble("LEFT_SPACE", MPCF.Trim(txtLeft.Text));
                in_node.AddDouble("RIGHT_SPACE", MPCF.Trim(txtRight.Text));

                if(rbnPortrait.Checked == true)
                    in_node.AddString("DIRECTION_TYPE", "POT");
                else
                    in_node.AddString("DIRECTION_TYPE", "LAN");

                in_node.AddString("TO_DOF_ID", MPCF.Trim(txtCopy.Text));                

                in_node.AddString("DOF_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("DOF_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("DOF_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("DOF_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("DOF_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("DOF_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("DOF_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("DOF_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("DOF_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("DOF_CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddString("DOF_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("DOF_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("DOF_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("DOF_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("DOF_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("DOF_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("DOF_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("DOF_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("DOF_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("DOF_GRP_10", MPCF.Trim(cdvGroup10.Text));

                if (MPCR.CallService("BAS", "BAS_Update_Document_Format", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                btnRefresh.PerformClick();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        /// <summary>
        /// View Service List
        /// </summary>
        /// <param name="control">ListView control</param>        
        /// <returns>true or false</returns>    
        private bool ViewServiceList(Control control)
        {
            TRSNode in_node = new TRSNode("View_Service_List_In");
            TRSNode out_node = new TRSNode("View_Service_List_Out");
            ListViewItem itmx;
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", cdvModule.Text);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_NAME")), (int)SMALLICON_INDEX.IDX_KEY);
                    if (((ListView)control).Columns.Count > 1)
                    {
                        itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_DESC")));
                    }
                    ((ListView)control).Items.Add(itmx);
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_SERVICE_NAME") != "");

            return true;
        }

        /// <summary>
        /// View Docment Information
        /// </summary>
        /// <param name="sFormatID">Format ID</param>        
        /// <returns>true or false</returns>    
        private bool ViewDocInfo(string sFormatID)
        {
            TRSNode in_node = new TRSNode("View_Doc_Info_IN");
            TRSNode out_node = new TRSNode("View_Doc_Info_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DOF_ID", sFormatID);

                if (MPCR.CallService("BAS", "BAS_View_Document_Format", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDocID.Text = out_node.GetString("DOF_ID");
                txtDesc.Text = out_node.GetString("DOF_DESC");
                cdvModule.Text = out_node.GetString("MODULE_NAME");
                cdvService.Text = out_node.GetString("SERVICE_NAME");                
                txtPageWidth.Text = out_node.GetInt("PAGE_WIDTH").ToString();
                txtPageHeight.Text = out_node.GetInt("PAGE_HEIGHT").ToString();
                cdvPagePaper.Text = out_node.GetString("PAPER_TYPE");

                if (out_node.GetString("DIRECTION_TYPE") == "POT")
                {
                    rbnPortrait.Checked = true;
                    rbnLandscape.Checked = false;
                }
                else if (out_node.GetString("DIRECTION_TYPE") == "POT")
                {
                    rbnPortrait.Checked = false;
                    rbnLandscape.Checked = true;
                }
                txtTop.Text = out_node.GetDouble("TOP_SPACE").ToString();
                txtBottom.Text = out_node.GetDouble("BOTTOM_SPACE").ToString();
                txtLeft.Text = out_node.GetDouble("LEFT_SPACE").ToString();
                txtRight.Text = out_node.GetDouble("RIGHT_SPACE").ToString();

                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                cdvCMF1.Text = out_node.GetString("DOF_CMF_1");
                cdvCMF2.Text = out_node.GetString("DOF_CMF_2");
                cdvCMF3.Text = out_node.GetString("DOF_CMF_3");
                cdvCMF4.Text = out_node.GetString("DOF_CMF_4");
                cdvCMF5.Text = out_node.GetString("DOF_CMF_5");
                cdvCMF6.Text = out_node.GetString("DOF_CMF_6");
                cdvCMF7.Text = out_node.GetString("DOF_CMF_7");
                cdvCMF8.Text = out_node.GetString("DOF_CMF_8");
                cdvCMF9.Text = out_node.GetString("DOF_CMF_9");
                cdvCMF10.Text = out_node.GetString("DOF_CMF_10");

                cdvGroup1.Text = out_node.GetString("DOF_GRP_1");
                cdvGroup2.Text = out_node.GetString("DOF_GRP_2");
                cdvGroup3.Text = out_node.GetString("DOF_GRP_3");
                cdvGroup4.Text = out_node.GetString("DOF_GRP_4");
                cdvGroup5.Text = out_node.GetString("DOF_GRP_5");
                cdvGroup6.Text = out_node.GetString("DOF_GRP_6");
                cdvGroup7.Text = out_node.GetString("DOF_GRP_7");
                cdvGroup8.Text = out_node.GetString("DOF_GRP_8");
                cdvGroup9.Text = out_node.GetString("DOF_GRP_9");
                cdvGroup10.Text = out_node.GetString("DOF_GRP_10");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        /// <param name></param>        
        /// <returns>control</returns>    
        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.lisFormat;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion // Functions Definition

        #region " Event Definition "

        private void frmBASSetupDocumentFormat_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {

                MPCF.FieldClear(this);
                SetGroupCmfItem();
                btnRefresh.PerformClick();

                b_load_flag = true;

                rbnPortrait.Checked = true;
                picPortrait.Visible = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string sFormatID = "";

            try
            {
                sFormatID = MPCF.Trim(txtDocID.Text);
                
                lblDataCount.Text = "";
                MPCF.FieldClear(pnlRight);
                
                if (BASLIST.ViewDocFormatList(lisFormat, '1', "", null, "", false) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisFormat.Items.Count);
                    if (lisFormat.Items.Count > 0)
                    {
                        if (sFormatID == "")
                        {
                            lisFormat.Items[0].Selected = true;
                        }
                        else
                        {
                            if (MPCF.FindListItem(lisFormat, sFormatID, false) == false)
                            {
                                lisFormat.Items[0].Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            MPCF.FindListItemPartial(lisFormat, txtFind.Text, 0, true, false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisFormat, txtFind.Text, true, false);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "";
            MPCF.ExportToExcel(lisFormat, this.Text, sCond);
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(1) == false)
            {
                return;
            }
            if (Update_Format(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(1) == false)
            {
                return;
            }
            if (Update_Format(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }

            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (Update_Format(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
        }

        private void lisFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisFormat.SelectedItems.Count < 1)
            {
                return;
            }

            string sFormatID;

            sFormatID = MPCF.Trim(lisFormat.SelectedItems[0].SubItems[0].Text);

            ViewDocInfo(sFormatID);
        }

        private void cdvFactory_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void cdvGroupCmf_ButtonPress(object sender, EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvPagePaper_ButtonPress(object sender, EventArgs e)
        {
            cdvPagePaper.Init();
            MPCF.InitListView(cdvPagePaper.GetListView);
            cdvPagePaper.Columns.Add("Paper Type", 150, HorizontalAlignment.Left);
            cdvPagePaper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvPagePaper.Columns.Add("Width", 0, HorizontalAlignment.Left);
            cdvPagePaper.Columns.Add("Height", 0, HorizontalAlignment.Left);
            cdvPagePaper.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvPagePaper.GetListView, '1', MPGC.MP_PAPER_TYPE);

            ListViewItem item = new ListViewItem(MPGC.MP_PAPER_TYPE_CUSTOM);
            item.SubItems.Add("");
            cdvPagePaper.Items.Add(item);
        }

        private void cdvPagePaper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvPagePaper.SelectedItem.SubItems[0].Text == MPGC.MP_PAPER_TYPE_CUSTOM)
            {
                txtPageWidth.Text = "";
                txtPageHeight.Text = "";
            }
            else
            {
                if (MPCF.CheckNumeric(cdvPagePaper.SelectedItem.SubItems[2].Text) == false ||
                    MPCF.CheckNumeric(cdvPagePaper.SelectedItem.SubItems[3].Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(339));
                    return;
                }
                txtPageWidth.Text = cdvPagePaper.SelectedItem.SubItems[2].Text;
                txtPageHeight.Text = cdvPagePaper.SelectedItem.SubItems[3].Text;
            }
        }

        private void cdvPagePaper_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (cdvPagePaper.Text == MPGC.MP_PAPER_TYPE_CUSTOM)
            {
                txtPageWidth.ReadOnly = false;
                txtPageHeight.ReadOnly = false;
            }
            else
            {
                txtPageWidth.ReadOnly = true;
                txtPageHeight.ReadOnly = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form f = new frmBASSetupDocumentDesign(txtDocID.Text, txtDesc.Text);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }
            if (Update_Format(MPGC.MP_STEP_COPY) == false)
            {
                return;
            }
        }

        private void cdvModule_Click(object sender, EventArgs e)
        {
            
        }

        private void cdvService_ButtonPress(object sender, EventArgs e)
        {
            cdvService.Init();
            MPCF.InitListView(cdvService.GetListView);
            cdvService.Columns.Add("Service", 150, HorizontalAlignment.Left);
            cdvService.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvService.SelectedSubItemIndex = 0;

            ViewServiceList(cdvService.GetListView);
        }

        private void cdvModule_ButtonPress(object sender, EventArgs e)
        {
            cdvModule.Init();
            MPCF.InitListView(cdvModule.GetListView);
            cdvModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvModule.SelectedSubItemIndex = 0;

            TRSNode in_node = new TRSNode("View_Module_List_In");
            TRSNode out_node = new TRSNode("View_Module_List_Out");
            ListViewItem viewItem;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCR.CallService("SVM", "SVM_View_Module_List", in_node, ref out_node) == false)
            {
                return;
            }

            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {
                viewItem = cdvModule.GetListView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("MODULE_NAME"),
                                                               (int)SMALLICON_INDEX.IDX_MODULE));
            }
        }

        private void rbnPortrait_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnPortrait.Checked == true)
            {
                picPortrait.Visible = true;
                picLandscape.Visible = false;
            }
            else
            {
                picPortrait.Visible = false;
                picLandscape.Visible = true;
            }
        }

        private void txtPageWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && Char.IsDigit(e.KeyChar) == false) e.Handled = true;
        }

        #endregion

        

    }
}