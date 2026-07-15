using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public partial class frmBBSNew : Form
    {
        public frmBBSNew()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private bool b_clear_flag;

        public string sCurrentMainMenuID;
        public string sCurrentSubMenuID;
        public char cTranType;
        public bool bModifyFlag;
        public int iBBSSeq;
       
        


        #endregion

        #region " Function Definition "

        private bool CheckCondition(String sCase)
        {
            try
            {
                switch (sCase)
                {
                    case "BBS":
                        if (MPCF.CheckValue(txtTitle, 1) == false)
                        {
                            txtTitle.Focus();
                            return false;
                        }

                        if (MPCF.CheckValue(cdvType, 1) == false)
                        {
                            cdvType.Focus();
                            return false;
                        }

                        if (MPCF.CheckValue(cboPriority, 1) == false)
                        {
                            cboPriority.Focus();
                            return false;
                        }

                        if (MPCF.CheckValue(cboPopupCycle, 1) == false)
                        {
                            cboPopupCycle.Focus();
                            return false;
                        }

                        if (MPCF.CheckValue(cboApplyShift, 1) == false)
                        {
                            cboApplyShift.Focus();
                            return false;
                        }

                        if (chkAutoCloseTime.Checked)
                        {
                            if (MPCF.CheckValue(txtAutoCloseTime, 2) == false)
                            {
                                txtAutoCloseTime.Focus();
                                return false;
                            }
                        }
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // Update_BBS_Msg()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool UpdateBBSMsg()
        {

            TRSNode in_node = new TRSNode("UPDATE_BBS_MSG_IN");
            TRSNode out_node = new TRSNode("UPDATE_BBS_MSG_OUT");

            TRSNode list_item;
            string s;
            string[] result;
            string[] stringSeparators = new string[] {"\r\n"};
            char cPriority;

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddInt("BBS_SEQ", 0);

                if (bModifyFlag == true)
                {
                    in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                    in_node.SetInt("BBS_SEQ", iBBSSeq);
                }

                in_node.AddString("MAIN_MENU_ID", sCurrentMainMenuID);
                in_node.AddString("SUB_MENU_ID", sCurrentSubMenuID);

                in_node.AddString("LOT_ID", MPCF.RTrim(txtLotID.Text));
                in_node.AddString("RES_ID", MPCF.RTrim(cdvResID.Text));

                in_node.AddString("MSG_TYPE", MPCF.RTrim(cdvType.Text));
                in_node.AddString("MSG_TITLE", MPCF.RTrim(txtTitle.Text));

                /* Added by DM KIM 2012.05.03 Values 추가 Start */

                if (chkStart.Checked == true)
                {
                    String s_datetime = MPCF.ToStandardTime(dtpStartDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                        MPCF.ToStandardTime(dtpStartTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                    in_node.AddString("APPLY_START_TIME", s_datetime);
                }

                if (chkEnd.Checked == true)
                {
                    String s_datetime = MPCF.ToStandardTime(dtpEndDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                        MPCF.ToStandardTime(dtpEndTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                    in_node.AddString("APPLY_END_TIME", s_datetime);
                }

                in_node.AddChar("SYS_MSG_FLAG", chkSysMsg.Checked == true ? 'Y' : ' ');
                in_node.AddString("AREA_ID", MPCF.RTrim(cdvAreaID.Text));
                in_node.AddString("SUB_AREA_ID", MPCF.RTrim(cdvSubAreaID.Text));
                in_node.AddString("RESG_ID", MPCF.RTrim(cdvResGrp.Text));
                in_node.AddString("MAT_ID", MPCF.RTrim(cdvMaterial.Text));
                in_node.AddString("FLOW", MPCF.RTrim(cdvFlow.Text));
                in_node.AddString("OPER", MPCF.RTrim(cdvOperation.Text));
                in_node.AddString("RCV_USER_ID", MPCF.RTrim(cdvUserID.Text));
                in_node.AddString("SEC_GRP_ID", MPCF.RTrim(cdvSecGrp.Text));
                in_node.AddString("PRV_GRP_ID", MPCF.RTrim(cdvPrvGrp.Text));
                in_node.AddString("RCV_FACTORY", MPCF.RTrim(cdvFactory.Text));
                in_node.AddChar("POPUP_CYCLE", MPCF.ToChar(cboPopupCycle.Text.Substring(0, 1)));    /* E : Every Time, O : Once And Done */
                in_node.AddChar("APPLY_SHIFT", MPCF.ToChar(cboApplyShift.Text.Substring(0, 1)));

                cPriority = MPCF.ToChar(cboPriority.Text.Substring(0, 1));
                if (cPriority == 'N')
                {
                    cPriority = '0';
                }
                in_node.AddChar("PRIORITY", cPriority);
                in_node.AddChar("MODAL_FLAG", rbnModal.Checked == true ? 'Y' : ' ');

                if (chkAutoCloseTime.Checked == true)
                {
                    in_node.AddChar("AUTO_CLOSE_FLAG", 'Y');
                    in_node.AddInt("AUTO_CLOSE_TIME", MPCF.ToInt(txtAutoCloseTime.Text));
                }
                /* Added by DM KIM 2012.05.03 Values 추가 End */


                in_node.AddString("BBS_CMF_1", "");
                in_node.AddString("BBS_CMF_2", "");
                in_node.AddString("BBS_CMF_3", "");
                in_node.AddString("BBS_CMF_4", "");
                in_node.AddString("BBS_CMF_5", "");
                in_node.AddString("BBS_CMF_6", "");
                in_node.AddString("BBS_CMF_7", "");
                in_node.AddString("BBS_CMF_8", "");
                in_node.AddString("BBS_CMF_9", "");
                in_node.AddString("BBS_CMF_10", "");

                s = MPCF.RTrim(txtMsg.Text);

                result = s.Split(stringSeparators, StringSplitOptions.None);

                foreach (string entry in result)
                {
                    list_item = in_node.AddNode("MSG_TEXT_LIST");

                    list_item.AddString("MSG_TEXT", entry + "\r\n");
                }

                if (MPCR.CallService("BAS", "BAS_Update_BBS_Msg", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (bModifyFlag == false)
                {
                    iBBSSeq = out_node.GetInt("BBS_SEQ");
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }

        // View_BBS_Msg()
        //       - View BBS Msg by Seq
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewBBSMsg(int iBBSSeq)
        {
            int i;
            TRSNode in_node = new TRSNode("VIEW_BBS_MSG_IN");
            TRSNode out_node = new TRSNode("VIEW_BBS_MSG_OUT");
            List<TRSNode> msgList;

            txtTitle.Text = "";
            cdvType.Text = "";
            cdvResID.Text = "";
            cdvOperation.Text = "";
            txtLotID.Text = "";
            txtMsg.Text = "";

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAIN_MENU_ID", sCurrentMainMenuID);
                in_node.AddString("SUB_MENU_ID", sCurrentSubMenuID);
                in_node.AddInt("BBS_SEQ", iBBSSeq);

                if (MPCR.CallService("BAS", "BAS_View_BBS_Msg", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtTitle.Text = out_node.GetString("MSG_TITLE");
                cdvType.Text = out_node.GetString("MSG_TYPE");

                cdvResID.Text = out_node.GetString("RES_ID");
                cdvOperation.Text = out_node.GetString("OPER");
                txtLotID.Text = out_node.GetString("LOT_ID");

                msgList = out_node.GetList("MSG_TEXT_LIST");
                for (i = 0; i < msgList.Count; i++)
                {
                    txtMsg.Text += msgList[i].GetString("MSG_TEXT");
                }

                /* Added by DM KIM 2012.05.04 Values 추가 Start */

                if (out_node.GetString("APPLY_START_TIME") == "")
                {
                    chkStart.Checked = false;
                    dtpStartDate.Enabled = false;
                    dtpStartTime.Enabled = false;
                }
                else
                {
                    chkStart.Checked = true;
                    dtpStartDate.Enabled = true;
                    dtpStartTime.Enabled = true;

                    if (out_node.GetString("APPLY_START_TIME") != null)
                    {
                        dtpStartDate.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                        dtpStartTime.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                    }
                }
                if (out_node.GetString("APPLY_END_TIME") == "")
                {
                    chkEnd.Checked = false;
                    dtpEndDate.Enabled = false;
                    dtpEndTime.Enabled = false;
                }
                else
                {
                    chkEnd.Checked = true;
                    dtpEndDate.Enabled = true;
                    dtpEndTime.Enabled = true;

                    if (out_node.GetString("APPLY_END_TIME") != null)
                    {
                        dtpEndDate.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                        dtpEndTime.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                    }
                }

                chkSysMsg.Checked = out_node.GetChar("SYS_MSG_FLAG") == 'Y' ? true : false;
                cdvAreaID.Text = out_node.GetString("AREA_ID");
                cdvSubAreaID.Text = out_node.GetString("SUB_AREA_ID");
                cdvResGrp.Text = out_node.GetString("RESG_ID");
                cdvMaterial.Text = out_node.GetString("MAT_ID");
                cdvFlow.Text = out_node.GetString("FLOW");
                cdvOperation.Text = out_node.GetString("OPER");
                cdvUserID.Text = out_node.GetString("RCV_USER_ID");
                cdvSecGrp.Text = out_node.GetString("SEC_GRP_ID");
                cdvPrvGrp.Text = out_node.GetString("PRV_GRP_ID");
                cdvFactory.Text = out_node.GetString("RCV_FACTORY");
                cboPopupCycle.SelectedIndex = out_node.GetChar("POPUP_CYCLE") == 'E' ? 0 : 1;

                if (out_node.GetChar("APPLY_SHIFT") == 'N')
                {
                    cboApplyShift.SelectedIndex = 0;        // No matter shift
                }
                else
                {
                    cboApplyShift.Text = MPCF.Trim(out_node.GetChar("APPLY_SHIFT"));
                }

                if (out_node.GetChar("PRIORITY") == '0')
                {
                    cboPriority.SelectedIndex = 0;        // Notice
                }
                else
                {
                    cboPriority.Text = MPCF.Trim(out_node.GetChar("PRIORITY"));
                }

                if (out_node.GetChar("MODAL_FLAG") == 'Y')
                {
                    rbnModal.Checked = true;
                    rbnModeless.Checked = false;
                }
                else
                {
                    rbnModal.Checked = false;
                    rbnModeless.Checked = true;
                }

                if (out_node.GetChar("AUTO_CLOSE_FLAG") == 'Y')
                {
                    chkAutoCloseTime.Checked = true;
                    txtAutoCloseTime.Text = MPCF.Trim(MPCF.ToInt(out_node.GetInt("AUTO_CLOSE_TIME")));
                }
                /* Added by DM KIM 2012.05.03 Values 추가 End */
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // Upload_BBS_File()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool UploadBBSFile()
        {
            int i;

            if (b_clear_flag == true)
            {
                TRSNode in_node = new TRSNode("UPDATE_BBS_FILE_IN");
                TRSNode out_node = new TRSNode("UPDATE_BBS_FILE_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("MAIN_MENU_ID", sCurrentMainMenuID);
                in_node.AddString("SUB_MENU_ID", sCurrentSubMenuID);
                in_node.AddInt("BBS_SEQ", iBBSSeq);
                in_node.AddChar("CLEAR_FLAG", 'Y');

                in_node.AddString("ORG_FILE_NAME", "");

                if (MPCR.CallService("BAS", "BAS_Upload_BBS_File", in_node, ref out_node) == false)
                {
                    return false;
                }
            }

            for (i = 0; i < lisFile.Items.Count; i++)
            {
                if (lisFile.Items[i].Tag != null)
                {
                    TRSNode in_node = new TRSNode("UPDATE_BBS_FILE_IN");
                    TRSNode out_node = new TRSNode("UPDATE_BBS_FILE_OUT");

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '1';

                    in_node.AddString("MAIN_MENU_ID", sCurrentMainMenuID);
                    in_node.AddString("SUB_MENU_ID", sCurrentSubMenuID);
                    in_node.AddInt("BBS_SEQ", iBBSSeq);

                    in_node.AddString("ORG_FILE_NAME", lisFile.Items[i].SubItems[1].Text);

                    //Image File
                    byte[] img_buffer;
                    img_buffer = null;
                    img_buffer = (byte[])lisFile.Items[i].Tag;
                    
                    in_node.AddBlob(MPGC.MP_BIN_DATA_1, img_buffer);

                    if (MPCR.CallService("BAS", "BAS_Upload_BBS_File", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // View_BBS_File_List()
        //       - View BBS File List
        // Return Value
        //       -
        // Arguments
        //        -
        private bool ViewBBSFileList()
        {
            TRSNode in_node = new TRSNode("VIEW_BBS_FILE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BBS_FILE_LIST_OUT");

            int i;
            ListViewItem itmX;


            MPCF.ClearList(lisFile, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MAIN_MENU_ID", sCurrentMainMenuID);
            in_node.AddString("SUB_MENU_ID", sCurrentSubMenuID);
            in_node.AddInt("BBS_SEQ", iBBSSeq);


            if (MPCR.CallService("BAS", "BAS_View_BBS_File_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                itmX = new ListViewItem((i + 1).ToString(), 0);
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ORG_FILE_NAME"));
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SAVE_FILE_NAME"));

                lisFile.Items.Add(itmX);
            }

            return true;
        }

        private void CheckedSysMsgControl(bool bChk_Flag)
        {
            cdvResGrp.Enabled = bChk_Flag;
            cdvResID.Enabled = bChk_Flag;
            cdvAreaID.Enabled = bChk_Flag;
            cdvSubAreaID.Enabled = bChk_Flag;
            cdvMaterial.Enabled = bChk_Flag;
            cdvOperation.Enabled = bChk_Flag;
            cdvFlow.Enabled = bChk_Flag;
            txtLotID.Enabled = bChk_Flag;
            cdvUserID.Enabled = bChk_Flag;
            cdvSecGrp.Enabled = bChk_Flag;
            cdvPrvGrp.Enabled = bChk_Flag;
            rbnModal.Enabled = bChk_Flag;
            rbnModeless.Enabled = bChk_Flag;
            chkAutoCloseTime.Enabled = bChk_Flag;
            txtAutoCloseTime.Enabled = bChk_Flag;

            if (bChk_Flag == false)
            {
                cdvResGrp.Text = "";
                cdvResID.Text = "";
                cdvAreaID.Text = "";
                cdvSubAreaID.Text = "";
                cdvMaterial.Text = "";
                cdvOperation.Text = "";
                cdvFlow.Text = "";
                txtLotID.Text = "";
                cdvUserID.Text = "";
                cdvSecGrp.Text = "";
                cdvPrvGrp.Text = "";
                rbnModal.Checked = true;
                rbnModeless.Checked = false;
                chkAutoCloseTime.Checked = false;
                txtAutoCloseTime.Text = "";
            }
        }

        #endregion

        private void frmBBSNew_Load(object sender, EventArgs e)
        {
            MPGV.gIBaseFormEvent.Form_Load(this, e);
        }

        private void frmBBSNew_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                b_load_flag = true;

                if (bModifyFlag == true)
                {
                    if (ViewBBSMsg(iBBSSeq) == false)
                    {
                        btnOK.Enabled = false;
                    }
                    else
                    {
                        ViewBBSFileList();
                    }
                }
                else
                {
                    cboApplyShift.SelectedIndex = 0;
                    cboPopupCycle.SelectedIndex = 0;
                    cboPriority.SelectedIndex = 0;
                    chkAutoCloseTime.Checked = false;
                    txtAutoCloseTime.ReadOnly = true;
                    rbnModal.Checked = true;
                    chkStart.Checked = false;
                    chkEnd.Checked = false;
                    chkStart_CheckedChanged(null, null);
                    chkEnd_CheckedChanged(null, null);

                    dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
                }
                
            }

        }

        private void frmBBSNew_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is TextBox)
                {
                    if (e.KeyValue != 13 && e.KeyValue != 8 || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                    {
                        if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;

            RASLIST.ViewResourceList(cdvResID.GetListView, false);
            cdvResID.InsertEmptyRow(0, 1);
        }

        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;

            WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "");
            cdvOperation.InsertEmptyRow(0, 1);
        }

        private void cdvType_ButtonPress(object sender, EventArgs e)
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvType.GetListView, '1', "BBS_MSG_TYPE");
        }

        private void cdvResGrp_ButtonPress(object sender, EventArgs e)
        {
            cdvResGrp.Init();

            MPCF.InitListView(cdvResGrp.GetListView);
            cdvResGrp.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvResGrp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResGrp.SelectedSubItemIndex = 0;

            if (RASLIST.ViewResourceGroupList(cdvResGrp.GetListView, '1') == false) return;
            cdvResGrp.InsertEmptyRow(0, 1);
        }

        private void cdvSubAreaID_ButtonPress(object sender, EventArgs e)
        {
            //Modify by J.S. 2008.12.23 만약 area가 먼저 선택된경우 종속된 subarea만 보이게 한다.
            if (MPCF.RTrim(cdvAreaID.Text) == "")
            {
                cdvSubAreaID.Init();
                MPCF.InitListView(cdvSubAreaID.GetListView);
                cdvSubAreaID.Columns.Add("SubAreaID", 50, HorizontalAlignment.Left);
                cdvSubAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSubAreaID.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvSubAreaID.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE) == false)
                {
                    return;
                }
            }
            else
            {
                cdvSubAreaID.Init();
                MPCF.InitListView(cdvSubAreaID.GetListView);
                cdvSubAreaID.Columns.Add("SubAreaID", 50, HorizontalAlignment.Left);
                cdvSubAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSubAreaID.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList_AREA(cdvSubAreaID.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE, -1, null, "", false, -1, -1, null, cdvAreaID.Text) == false)
                {
                    return;
                }
            }
            cdvSubAreaID.InsertEmptyRow(0, 1);
        }

        private void cdvFlow_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvFlow.Init();
                MPCF.InitListView(cdvFlow.GetListView);
                cdvFlow.Columns.Add("Flow", 100, HorizontalAlignment.Left);
                cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvFlow.SelectedSubItemIndex = 0;
                WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "");
                cdvFlow.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvFactory_ButtonPress(object sender, EventArgs e)
        {
            cdvFactory.Init();
            MPCF.InitListView(cdvFactory.GetListView);
            cdvFactory.Columns.Add("Factory", 100, HorizontalAlignment.Left);
            cdvFactory.Columns.Add("Factory Desc", 100, HorizontalAlignment.Left);
            cdvFactory.SelectedSubItemIndex = 0;
            WIPLIST.ViewFactoryList(cdvFactory.GetListView, '1', null);
            cdvFactory.InsertEmptyRow(0, 1);
        }

        private void cdvPrvGrp_ButtonPress(object sender, EventArgs e)
        {
            cdvPrvGrp.Init();
            MPCF.InitListView(cdvPrvGrp.GetListView);
            cdvPrvGrp.Columns.Add(MPCF.FindLanguage("Privilege Group", 0), 50, HorizontalAlignment.Left);
            cdvPrvGrp.Columns.Add(MPCF.FindLanguage("Desc", 0), 100, HorizontalAlignment.Left);
            cdvPrvGrp.SelectedSubItemIndex = 0;
            if (SECLIST.ViewPrvGroupList(cdvPrvGrp.GetListView, '1', null, "") == false)
            {
                return;
            }
            cdvPrvGrp.InsertEmptyRow(0, 1);
        }

        private void cdvAreaID_ButtonPress(object sender, EventArgs e)
        {
            cdvAreaID.Init();
            MPCF.InitListView(cdvAreaID.GetListView);
            cdvAreaID.Columns.Add("AreaID", 50, HorizontalAlignment.Left);
            cdvAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAreaID.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvAreaID.GetListView, '1', MPGC.MP_RAS_AREA_CODE) == false)
            {
                return;
            }
            cdvAreaID.InsertEmptyRow(0, 1);
        }

        private void cdvMaterial_ButtonPress(object sender, EventArgs e)
        {
            cdvMaterial.Init();
            MPCF.InitListView(cdvMaterial.GetListView);
            cdvMaterial.Columns.Add("Material", 50, HorizontalAlignment.Left);
            cdvMaterial.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvMaterial.SelectedSubItemIndex = 0;
            WIPLIST.ViewMaterialList(cdvMaterial.GetListView, '1');
            cdvMaterial.InsertEmptyRow(0, 1);
        }

        private void cdvUserID_ButtonPress(object sender, EventArgs e)
        {
            cdvUserID.Init();
            MPCF.InitListView(cdvUserID.GetListView);
            cdvUserID.Columns.Add("UserID", 100, HorizontalAlignment.Left);
            cdvUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUserID.SelectedSubItemIndex = 0;

            SECLIST.ViewSECUserList(cdvUserID.GetListView);
            cdvUserID.InsertEmptyRow(0, 1);
        }

        private void cdvSecGrp_ButtonPress(object sender, EventArgs e)
        {
            cdvSecGrp.Init();
            MPCF.InitListView(cdvSecGrp.GetListView);
            cdvSecGrp.Columns.Add("Security Group", 100, HorizontalAlignment.Left);
            cdvSecGrp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvSecGrp.SelectedSubItemIndex = 0;
            SECLIST.ViewSecGroupList(cdvSecGrp.GetListView, '1', null, "");
            cdvSecGrp.InsertEmptyRow(0, 1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("BBS") == false)
                {
                    return;
                }
                if (UpdateBBSMsg() == false)
                {
                    return;
                }

                UploadBBSFile();

                MPCF.ClearList(lisFile, true);
                GC.Collect();

                this.Close();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            FileInfo finfo;
            BinaryReader br;
            byte[] file_buffer;
            int i;
            ListViewItem itmX;
            string[] result;
            string[] stringSeparators = new string[] { "\\" };
            string file_name = "";

            ofdFile.Filter = "All File|*.*";
            ofdFile.FileName = "";

            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                finfo = new FileInfo(ofdFile.FileName);
                if (finfo.Exists == true)
                {
                    br = new BinaryReader(finfo.OpenRead());
                    file_buffer = br.ReadBytes((int)finfo.Length);
                    br.Close();

                    i = lisFile.Items.Count;
                    itmX = new ListViewItem((i + 1).ToString(), 0);

                    result = ofdFile.FileName.Split(stringSeparators, StringSplitOptions.None);

                    foreach (string entry in result)
                    {
                        file_name = entry;
                    }

                    itmX.SubItems.Add(file_name);
                    itmX.Tag = file_buffer;

                    lisFile.Items.Add(itmX);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(lisFile, true);
            b_clear_flag = true;
        }

        private void chkAutoCloseTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoCloseTime.Checked)
            {
                txtAutoCloseTime.ReadOnly = false;
            }
            else
            {
                txtAutoCloseTime.ReadOnly = true;
                txtAutoCloseTime.Text = "";
            }
        }

        private void chkSysMsg_CheckedChanged(object sender, EventArgs e)
        {
            CheckedSysMsgControl(!chkSysMsg.Checked);
        }

        private void chkStart_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            dtpStartDate.Enabled = chkStart.Checked;
            dtpStartTime.Enabled = chkStart.Checked;
        }

        private void chkEnd_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            dtpEndDate.Enabled = chkEnd.Checked;
            dtpEndTime.Enabled = chkEnd.Checked;
        }
    }
}