//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBBSPopup.cs
//   Description : MES Cient Form Bulletin Board Popup 
//
//   MES Version : 5.2.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012.05.04 : Create by DM KIM
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public partial class frmBBSPopup : Form
    {
        public frmBBSPopup()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int COL_TITLE = 1;
        private const int COL_UPDATE_USER_ID = 2;
        private const int COL_UPDATE_TIME = 3;
        private const int COL_POPUP_CYCLE = 18;
        private const int COL_ACK_FLAG = 20;
        private const int COL_MAIN_MENU_ID = 21;
        private const int COL_SUB_MENU_ID = 22;
        private const int COL_SYS_MSG_FLAG = 23;

        #endregion

        #region " Variable Definition "

        private bool mb_load_flag;
        private bool mb_publish_flag;

        private string msUserID;
        private string msFactory;
        private string msLotID;
        private string msMatID;
        private string msFlow;
        private string msOper;
        private string msAreaID;
        private string msSubAreaID;
        private string msResID;
        private bool mbExcludeSysMsgFlag;

        private int mi_auto_close_time;

        #endregion

        #region " Property Definition "

        public bool Publish
        {
            get
            {
                return mb_publish_flag;
            }
            set
            {
                mb_publish_flag = value;
            }
        }
        public string UserID
        {
            set
            {
                msUserID = value;
            }
        }
        public string Factory
        {
            set
            {
                msFactory = value;
            }
        }
        public string LotID
        {
            set
            {
                msLotID = value;
            }
        }
        public string MatID
        {
            set
            {
                msMatID = value;
            }
        }
        public string Flow
        {
            set
            {
                msFlow = value;
            }
        }
        public string Oper
        {
            set
            {
                msOper = value;
            }
        }
        public string AreaID
        {
            set
            {
                msAreaID = value;
            }
        }
        public string SubAreaID
        {
            set
            {
                msSubAreaID = value;
            }
        }
        public string ResID
        {
            set
            {
                msResID = value;
            }
        }
        public bool ExcludeSysMessage
        {
            set
            {
                mbExcludeSysMsgFlag = value;
            }
        }

        #endregion

        #region " Function Definition "

        public void DisplayMsgList(TRSNode out_node)
        {
            int i;
            int iCnt;
            int iIconIndex;

            int iAutoCloseTime;
            bool bAutoClose;

            ListViewItem itmX;
            List<TRSNode> msgList;

            MPCF.InitListView(lisMsgList);
            MPCF.InitListView(lisFile);

            txtMsg.Text = "";
            iAutoCloseTime = 0;
            iIconIndex = 0;
            iCnt = 0;
            bAutoClose = true;

            try
            {
                msgList = out_node.GetList("MSG_LIST");
                for (i = 0; i < msgList.Count; i++)
                {
                    if (msgList[i].GetChar("POPUP_CYCLE") == 'O' && msgList[i].GetChar("ACK_FLAG") == 'Y')
                    {
                        continue;
                    }

                    iIconIndex = (int)SMALLICON_INDEX.IDX_MESSAGE;
                    switch (msgList[i].GetString("MSG_TYPE"))
                    {
                        case MPGC.MP_BBS_MSG_TYPE_INFO:
                            iIconIndex = (int)SMALLICON_INDEX.IDX_ALARM_INFO;
                            break;
                        case MPGC.MP_BBS_MSG_TYPE_ERROR:
                            iIconIndex = (int)SMALLICON_INDEX.IDX_ALARM_ERROR;
                            break;
                        case MPGC.MP_BBS_MSG_TYPE_WARN:
                            iIconIndex = (int)SMALLICON_INDEX.IDX_ALARM_WARN;
                            break;
                    }

                    iCnt++;
                    itmX = new ListViewItem(iCnt.ToString(), iIconIndex);
                    if (msgList[i].GetChar("PRIORITY") == '0')
                    {
                        itmX.ForeColor = Color.Red;
                    }

                    itmX.Tag = msgList[i].GetInt("BBS_SEQ");
                    itmX.SubItems.Add(msgList[i].GetString("MSG_TITLE"));
                    itmX.SubItems.Add(msgList[i].GetString("UPDATE_USER_ID"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(msgList[i].GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME));
                    itmX.SubItems.Add(msgList[i].GetString("MSG_TYPE"));
                    itmX.SubItems.Add(msgList[i].GetString("RES_ID"));
                    itmX.SubItems.Add(msgList[i].GetString("RESG_ID"));
                    itmX.SubItems.Add(msgList[i].GetString("AREA_ID"));
                    itmX.SubItems.Add(msgList[i].GetString("SUB_AREA_ID"));
                    itmX.SubItems.Add(msgList[i].GetString("RCV_USER_ID"));
                    itmX.SubItems.Add(msgList[i].GetString("SEC_GRP_ID"));
                    itmX.SubItems.Add(msgList[i].GetString("PRV_GRP_ID"));
                    itmX.SubItems.Add(msgList[i].GetString("MAT_ID"));
                    itmX.SubItems.Add(msgList[i].GetString("FLOW"));
                    itmX.SubItems.Add(msgList[i].GetString("OPER"));
                    itmX.SubItems.Add(msgList[i].GetString("LOT_ID"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(msgList[i].GetString("APPLY_START_TIME"), DATE_TIME_FORMAT.DATETIME) + " ~ " +
                                        MPCF.MakeDateFormat(msgList[i].GetString("APPLY_END_TIME"), DATE_TIME_FORMAT.DATETIME));
                    itmX.SubItems.Add(MPCF.Trim(msgList[i].GetChar("APPLY_SHIFT")));
                    itmX.SubItems.Add(MPCF.Trim(msgList[i].GetChar("POPUP_CYCLE")));
                    itmX.SubItems.Add(MPCF.Trim(msgList[i].GetString("RCV_FACTORY")));
                    itmX.SubItems.Add(MPCF.Trim(msgList[i].GetChar("ACK_FLAG")));
                    itmX.SubItems.Add(MPCF.Trim(msgList[i].GetString("MAIN_MENU_ID")));
                    itmX.SubItems.Add(MPCF.Trim(msgList[i].GetString("SUB_MENU_ID")));
                    itmX.SubItems.Add(MPCF.Trim(msgList[i].GetChar("SYS_MSG_FLAG")));
                    lisMsgList.Items.Add(itmX);

                    // AutoCloseTime Check
                    if (msgList[i].GetChar("AUTO_CLOSE_FLAG") == 'Y')
                    {
                        int iTime = msgList[i].GetInt("AUTO_CLOSE_TIME");
                        if (iTime > iAutoCloseTime)
                        {
                            iAutoCloseTime = iTime;
                        }
                    }
                    else
                    {
                        bAutoClose = false;
                    }
                }//end for

                if (lisMsgList.Items.Count > 0)
                {
                    lisMsgList.Items[0].Selected = true;
                }

                if (bAutoClose == true && iAutoCloseTime > 0)
                {
                    FormAutoClose(true, iAutoCloseTime);
                }
                else
                {
                    FormAutoClose(false, 0);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        // UpdateBBSMsg()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool AcknowledgeBBSMsg(int iBBSSeq, string sMainMenu, string sSubMenu)
        {

            TRSNode in_node = new TRSNode("ACKNOWLEDGE_BBS_MSG_IN");
            TRSNode out_node = new TRSNode("ACKNOWLEDGE_BBS_MSG_OUT");

            try
            {

                MPCR.SetInMsg(in_node);

                in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                in_node.AddInt("BBS_SEQ", iBBSSeq);
                in_node.AddString("MAIN_MENU_ID", sMainMenu);
                in_node.AddString("SUB_MENU_ID", sSubMenu);
                in_node.AddChar("ACK_FLAG", 'Y');

                if (MPCR.CallService("BAS", "BAS_Update_BBS_Msg", in_node, ref out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        // ViewBBSMsg_List()
        //       - View BBS Msg List
        // Return Value
        //       -
        // Arguments
        //        -
        private bool ViewBBSMsgList()
        {
            TRSNode out_node = new TRSNode("VIEW_BBS_MSG_LIST_OUT");
            if (BASLIST.ViewBBSMsgList(out_node, msLotID, msMatID, msFlow, msOper, msUserID, msResID, msAreaID, msSubAreaID, mbExcludeSysMsgFlag) == false)
            {
                return false;
            }
            DisplayMsgList(out_node);

            return true;
        }

        // ViewBBSMsg()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewBBSMsg(int iBBSSeq, string sMainMenu, string sSubMenu)
        {
            int i;
            TRSNode in_node = new TRSNode("VIEW_BBS_MSG_IN");
            TRSNode out_node = new TRSNode("VIEW_BBS_MSG_OUT");

            txtMsg.Text = "";

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddInt("BBS_SEQ", iBBSSeq);
            in_node.AddString("MAIN_MENU_ID", sMainMenu);
            in_node.AddString("SUB_MENU_ID", sSubMenu);

            if (MPCR.CallService("BAS", "BAS_View_BBS_Msg", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                txtMsg.Text += out_node.GetList(0)[i].GetString("MSG_TEXT");
            }

            return true;
        }

        // ViewBBSFile_List()
        //       - View BBS File List
        // Return Value
        //       -
        // Arguments
        //        -
        private bool ViewBBSFileList(int iBBSSeq, string sMainMenu, string sSubMenu)
        {
            TRSNode in_node = new TRSNode("VIEW_BBS_FILE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BBS_FILE_LIST_OUT");

            int i;
            ListViewItem itmX;


            MPCF.InitListView(lisFile);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddInt("BBS_SEQ", iBBSSeq);
            in_node.AddString("MAIN_MENU_ID", sMainMenu);
            in_node.AddString("SUB_MENU_ID", sSubMenu);

            if (MPCR.CallService("BAS", "BAS_View_BBS_File_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                itmX = new ListViewItem((i + 1).ToString(), (int)SMALLICON_INDEX.IDX_MESSAGE);
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ORG_FILE_NAME"));
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SAVE_FILE_NAME"));

                lisFile.Items.Add(itmX);
            }

            return true;
        }

        // DownloadBBSFile()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool DownloadBBSFile(int iBBSSeq, string sMainMenu, string sSubMenu, string s_save_file_name, string s_file_name)
        {
            TRSNode in_node = new TRSNode("DOWNLOAD_BBS_FILE_IN");
            TRSNode out_node = new TRSNode("DOWNLOADE_BBS_FILE_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddInt("BBS_SEQ", iBBSSeq);
            in_node.AddString("MAIN_MENU_ID", sMainMenu);
            in_node.AddString("SUB_MENU_ID", sSubMenu);
            in_node.AddString("SAVE_FILE_NAME", s_save_file_name);

            if (MPCR.CallService("BAS", "BAS_Download_BBS_File", in_node, ref out_node) == false)
            {
                return false;
            }

            byte[] bt_buffer;
            if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
            {
                try
                {
                    FileStream fs = File.Open(s_file_name, FileMode.Create);
                    BinaryWriter writer = new BinaryWriter(fs);
                    writer.Write(bt_buffer, 0, bt_buffer.Length);
                    writer.Close();
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return false;
                }
            }

            return true;
        }

        // InitPublishMessage()
        //       - BBS Message와 Publish Count 동기화
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool InitPublishMessage(int iIndex)
        {
            int i = 0;
            int j = 0;
            try
            {
                // Publish Message인 경우 Ack후 Message Count 동기화
                if (mb_publish_flag == true)
                {
                    for (i = 0; i < MPGV.giBBSMessageCnt; i++)
                    {
                        if (MPCF.Trim(MPGV.gtBBSMessageList[i].factory) == MPGV.gsFactory &&
                            MPCF.Trim(MPGV.gtBBSMessageList[i].main_menu_id) == MPCF.Trim(lisMsgList.Items[iIndex].SubItems[COL_MAIN_MENU_ID].Text) &&
                            MPCF.Trim(MPGV.gtBBSMessageList[i].sub_menu_id) == MPCF.Trim(lisMsgList.Items[iIndex].SubItems[COL_SUB_MENU_ID].Text) &&
                            MPGV.gtBBSMessageList[i].bbs_seq == MPCF.ToInt(lisMsgList.Items[iIndex].Tag))
                        {
                            for (j = i; j < MPGV.giBBSMessageCnt - 1; j++)
                            {
                                MPGV.gtBBSMessageList[j] = MPGV.gtBBSMessageList[j + 1];
                            }
                            MPGV.giBBSMessageCnt--;
                            break;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // FormAutoClose()
        //       - BBS Popup 화면 Auto Close 여부 Check 및 Auto Close Start & End
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool FormAutoClose(bool b_auto_close_flag, int AutoCloseTime)
        {
            try
            {
                mi_auto_close_time = AutoCloseTime;
                if (AutoCloseTime > 0)
                {
                    if (b_auto_close_flag == true)
                    {
                        tmrAutoClose.Enabled = true;
                        tmrAutoClose.Interval = 1000;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
        #endregion

        private void frmBBSPopup_Load(object sender, EventArgs e)
        {
            MPGV.gIBaseFormEvent.Form_Load(this, e);
            chkAutoRefresh.Checked = false;

            if (MPGV.giAutoRefreshTime > 0)
            {
                chkAutoRefresh.Checked = MPGV.gbAutoRefresh;
                tmrTimer.Interval = MPGV.giAutoRefreshTime * 1000;
            }

            if (chkAutoRefresh.Checked == true)
            {
                tmrTimer.Start();
            }
            else
            {
                tmrTimer.Stop();
            }
        }

        private void frmBBSPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            MPGV.gfrmPopupInformNote = null;
        }

        private void frmBBSPopup_Activated(object sender, EventArgs e)
        {
            if (mb_load_flag == false)
            {
                this.TopMost = false;
                mb_load_flag = true;
            }
        }

        private void frmBBSPopup_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (lisMsgList.Items.Count > 0)
                {
                    for (int i = 0; i < lisMsgList.Items.Count; i++)
                    {
                        if (MPCF.ToChar(lisMsgList.Items[i].SubItems[COL_ACK_FLAG].Text) == 'Y' ||
                            MPCF.ToChar(lisMsgList.Items[i].SubItems[COL_SYS_MSG_FLAG].Text) == 'Y')
                        {
                            // ACK FLAG 가 'Y' 이거나 System Message인 경우에 대해서만 동기화 진행
                            InitPublishMessage(i);
                        }
                    }
                }

                MPCF.InitListView(lisFile);
                GC.Collect();

                this.Close();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int iBBSSeq;
            string sMainMenu;
            string sSubMenu;

            if (lisFile.SelectedItems.Count < 1)
            {
                return;
            }

            iBBSSeq = MPCF.ToInt(lisMsgList.SelectedItems[0].Tag);
            sMainMenu = MPCF.Trim(lisMsgList.SelectedItems[0].SubItems[COL_MAIN_MENU_ID].Text);
            sSubMenu = MPCF.Trim(lisMsgList.SelectedItems[0].SubItems[COL_SUB_MENU_ID].Text);

            saveFileDialog.Filter = "All File | *.*";
            saveFileDialog.FileName = lisFile.SelectedItems[0].SubItems[1].Text;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (DownloadBBSFile(iBBSSeq, sMainMenu, sSubMenu, lisFile.SelectedItems[0].SubItems[2].Text, saveFileDialog.FileName) == false)
                {
                    return;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MPCF.InitListView(lisFile);
            ViewBBSMsgList();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            /* 2013.06.12. Aiden. Middleware 가 사용가능한지 확인 */
            if (MPIF.gInit.IsAvailableSendMessage == true)
            {
                ViewBBSMsgList();
            }
        }

        private void tmrAutoClose_Tick(object sender, EventArgs e)
        {
            mi_auto_close_time = mi_auto_close_time - 1;

            if (mi_auto_close_time <= 0)
                this.Close();
        }

        private void lisFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int iBBSSeq;
            string file_name;
            string sMainMenu;
            string sSubMenu;

            if (lisFile.SelectedItems.Count < 1)
            {
                return;
            }

            iBBSSeq = MPCF.ToInt(lisMsgList.SelectedItems[0].Tag);
            sMainMenu = MPCF.Trim(lisMsgList.SelectedItems[0].SubItems[COL_MAIN_MENU_ID].Text);
            sSubMenu = MPCF.Trim(lisMsgList.SelectedItems[0].SubItems[COL_SUB_MENU_ID].Text);

            file_name = Environment.GetEnvironmentVariable("TEMP") + "\\" + lisFile.SelectedItems[0].SubItems[1].Text;

            if (DownloadBBSFile(iBBSSeq, sMainMenu, sSubMenu, lisFile.SelectedItems[0].SubItems[2].Text, file_name) == false)
            {
                return;
            }

            Process process = new Process();
            process.StartInfo.FileName = file_name;
            process.Start();
        }

        private void lisMsgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sBBSSeq;
                char cAckFlag;
                char cSysMsgFlag;
                char cPopupCycle;
                string sMainMenu;
                string sSubMenu;

                if (lisMsgList.SelectedItems.Count < 1)
                {
                    return;
                }

                sBBSSeq = MPCF.ToInt(lisMsgList.SelectedItems[0].Tag);
                cAckFlag = MPCF.ToChar(lisMsgList.SelectedItems[0].SubItems[COL_ACK_FLAG].Text);
                sMainMenu = MPCF.Trim(lisMsgList.SelectedItems[0].SubItems[COL_MAIN_MENU_ID].Text);
                sSubMenu = MPCF.Trim(lisMsgList.SelectedItems[0].SubItems[COL_SUB_MENU_ID].Text);
                cSysMsgFlag = MPCF.ToChar(lisMsgList.SelectedItems[0].SubItems[COL_SYS_MSG_FLAG].Text);
                cPopupCycle = MPCF.ToChar(lisMsgList.SelectedItems[0].SubItems[COL_POPUP_CYCLE].Text);

                ViewBBSMsg(sBBSSeq, sMainMenu, sSubMenu);
                ViewBBSFileList(sBBSSeq, sMainMenu, sSubMenu);

                // Popup Cycle이 Once and Done 인 경우 Ack를 한다.
                if (cPopupCycle == 'O')
                {
                    if (cAckFlag != 'Y')
                    {
                        if (AcknowledgeBBSMsg(sBBSSeq, sMainMenu, sSubMenu) == false)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

    }
}