using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;
using System.Drawing;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupMessage.vb
//   Description : MES Cient Form Message Setup Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - BAS_Update_Message() : Create/Update/Delete Message information
//        - BAS_View_Message_Group_List() : View list message group
//        - BAS_View_Message_List() : View list message
//        - BAS_View_Message() : View message
//       - CheckCondition() : Check Create/Update/Delete condition
//
//   Detail Description
//       - BAS_View_Message_Group_List()??ê²½ìš° listview, combobox ë¡?overload ?˜ì–´ ?ˆìŒ.
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-03 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//Imports

namespace Miracom.BASCore
{
    public partial class frmBASSetupMessage : Miracom.MESCore.SetupForm02
    {
        public frmBASSetupMessage()
        {
            InitializeComponent();
        }

        public frmBASSetupMessage(string arg)
        {
            InitializeComponent();
            s_msg_group = arg;
        }

        #region "VariableDefinition"

        private bool b_load_flag;
        private bool b_export_stop = false;
        private string s_msg_group = "";

        #endregion

        #region " Function Definition "
        // View_Message()
        //       - View message
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVla sMsgId                : ê°€?¸ì˜¬ ë©”ì‹œì§€ ID
        private bool View_Message(string sMsgId)
        {
            TRSNode in_node = new TRSNode("View_Message_In");
            TRSNode out_node = new TRSNode("View_Message_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MSG_ID", MPCF.Trim(sMsgId));

            if (MPCR.CallService("BAS", "BAS_View_Message", in_node, ref out_node) == false)
            {
                return false;
            }

            cboMsgGrp.Text = out_node.GetString("MSG_GRP");
            txtMsgId.Text = out_node.GetString("MSG_ID");
            txtMsg1.Text = out_node.GetString("MSG_1");
            txtMsg2.Text = out_node.GetString("MSG_2");
            txtMsg3.Text = out_node.GetString("MSG_3");
            txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
            txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

            return true;
        }

        //
        // Update_Message()
        //       - Change message information
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVla c_step                : Create/Update/Delete êµ¬ë¶„??
        //
        private bool Update_Message(char c_step)
        {

            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_MESSAGE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MSG_ID", MPCF.Trim(txtMsgId.Text));
                in_node.AddString("MSG_GRP", MPCF.Trim(cboMsgGrp.Text));
                in_node.AddString("MSG_1", MPCF.Trim(txtMsg1.Text));
                in_node.AddString("MSG_2", MPCF.Trim(txtMsg2.Text));
                in_node.AddString("MSG_3", MPCF.Trim(txtMsg3.Text));

                //// TRSNode Test Code
                //{
                //    TRSNode nd1 = new TRSNode("test1");

                //    nd1.SetString("STR1", null);
                //    nd1.SetChar("CHR1", null);
                //    nd1.SetBoolean("BOL1", null);
                //    nd1.SetBinary("BIN1", null);
                //    nd1.SetUByte("UBYT1", null);
                //    nd1.SetUShort("USHT1", null);
                //    nd1.SetUInt("UINT1", null);
                //    nd1.SetULong("ULNG1", null);
                //    nd1.SetFloat("FLT1", null);
                //    nd1.SetDouble("DBL1", null);
                //    nd1.SetByte("BYT1", null);
                //    nd1.SetShort("SHT1", null);
                //    nd1.SetInt("INT1", null);
                //    nd1.SetLong("LNG1", null);
                //    nd1.AddDatetime("DTT1", null);
                //    nd1.SetBlob("BLB1", null);

                //    TRSNode ar2 = nd1.AddArray("ARRAY", TRSArrayDataType.Double);
                //    ar2.AddItem(null);
                //    ar2.AddItem(2.2222);
                //    ar2.AddItem(0.8329423489);
                //    ar2.AddItem(null);

                //    nd1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    nd1.SetChar("CHR2", 'M');
                //    nd1.SetBoolean("BOL2", true);
                //    nd1.SetBinary("BIN2", 1);
                //    nd1.SetUByte("UBYT2", 2);
                //    nd1.SetUShort("USHT2", 3);
                //    nd1.SetUInt("UINT2", 4);
                //    nd1.SetULong("ULNG2", 5);
                //    nd1.SetFloat("FLT2", 6.66666f);
                //    nd1.SetDouble("DBL2", 7.000000009);
                //    nd1.SetByte("BYT2", -8);
                //    nd1.SetShort("SHT2", -9);
                //    nd1.SetInt("INT2", -10);
                //    nd1.SetLong("LNG2", -11);
                //    nd1.AddDatetime("DTT2", DateTime.Now);

                //    string ss = "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";
                //    ss += "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";
                //    ss += "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";
                //    ss += "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";
                //    ss += "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";

                //    byte[] bs = System.Text.Encoding.UTF8.GetBytes(ss);
                //    nd1.SetBlob("BLB2", bs);

                //    TRSNode ls1 = nd1.AddNode("LIST");
                //    ls1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ls1.SetChar("CHR2", 'M');
                //    ls1.SetBoolean("BOL2", true);
                //    ls1.SetBinary("BIN2", 1);
                //    ls1.SetUByte("UBYT2", 2);
                //    ls1.SetUShort("USHT2", 3);
                //    ls1.SetUInt("UINT2", 4);
                //    ls1.SetULong("ULNG2", 5);
                //    ls1.SetFloat("FLT2", 6.66666f);
                //    ls1.SetDouble("DBL2", 7.000000009);
                //    ls1.SetByte("BYT2", -8);
                //    ls1.SetShort("SHT2", -9);
                //    ls1.SetInt("INT2", -10);
                //    ls1.SetLong("LNG2", -11);
                //    ls1.AddDatetime("DTT2", DateTime.Now);

                //    ls1 = nd1.AddNode("LIST");
                //    ls1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ls1.SetChar("CHR2", 'M');
                //    ls1.SetBoolean("BOL2", true);
                //    ls1.SetBinary("BIN2", 1);
                //    ls1.SetUByte("UBYT2", 2);
                //    ls1.SetUShort("USHT2", 3);
                //    ls1.SetUInt("UINT2", 4);
                //    ls1.SetULong("ULNG2", 5);
                //    ls1.SetFloat("FLT2", 6.66666f);
                //    ls1.SetDouble("DBL2", 7.000000009);
                //    ls1.SetByte("BYT2", -8);
                //    ls1.SetShort("SHT2", -9);
                //    ls1.SetInt("INT2", -10);
                //    ls1.SetLong("LNG2", -11);
                //    ls1.AddDatetime("DTT2", DateTime.Now);

                //    ls1 = nd1.AddNode("LIST");
                //    ls1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ls1.SetChar("CHR2", 'M');
                //    ls1.SetBoolean("BOL2", true);
                //    ls1.SetBinary("BIN2", 1);
                //    ls1.SetUByte("UBYT2", 2);
                //    ls1.SetUShort("USHT2", 3);
                //    ls1.SetUInt("UINT2", 4);
                //    ls1.SetULong("ULNG2", 5);
                //    ls1.SetFloat("FLT2", 6.66666f);
                //    ls1.SetDouble("DBL2", 7.000000009);
                //    ls1.SetByte("BYT2", -8);
                //    ls1.SetShort("SHT2", -9);
                //    ls1.SetInt("INT2", -10);
                //    ls1.SetLong("LNG2", -11);
                //    ls1.AddDatetime("DTT2", DateTime.Now);

                //    TRSNode ar1 = ls1.AddArray("ARRAY", TRSArrayDataType.String);
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");

                //    string xml1 = Miracom.TRSCore.TRSConvertorDefine.Convertor.ToXmlString(nd1);

                //    TRSNode nd2 = new TRSNode("test1");

                //    Miracom.TRSCore.TRSConvertorDefine.Convertor.Parse(nd2, xml1);

                //    string a1 = nd2.GetString("STR1");
                //    string a2 = nd2.GetString("STR2");
                //    char a3 = nd2.GetChar("CHR1");
                //    bool a4 = nd2.GetBoolean("BOL1");
                //    byte a5 = nd2.GetBinary("BIN1");
                //    byte a6 = nd2.GetUByte("UBYT1");
                //    ushort a7 = nd2.GetUShort("USHT1");
                //    uint a8 = nd2.GetUInt("UINT1");
                //    ulong a9 = nd2.GetULong("ULNG1");
                //    float a10 = nd2.GetFloat("FLT1");
                //    double a11 = nd2.GetDouble("DBL1");
                //    sbyte a12 = nd2.GetByte("BYT1");
                //    short a13 = nd2.GetShort("SHT1");
                //    int a14 = nd2.GetInt("INT1");
                //    long a15 = nd2.GetLong("LNG1");
                //    DateTime a16 = nd2.GetDatetime("DTT1");
                //    byte[] a17 = nd2.GetBlob("BLB1");
                //    byte[] a18 = nd2.GetBlob("BLB2");

                //    string ss2 = System.Text.Encoding.UTF8.GetString(a18);


                //    string xml2 = Miracom.TRSCore.TRSConvertorDefine.Convertor.ToXmlString(nd2);

                //    if(xml1.Equals(xml2) == true)
                //        MessageBox.Show("Match");
                //    else
                //        MessageBox.Show("No match");
                //}


                //{
                //    in_node.SetString("STR1", null);
                //    in_node.SetChar("CHR1", null);
                //    in_node.SetBoolean("BOL1", null);
                //    in_node.SetBinary("BIN1", null);
                //    in_node.SetUByte("UBYT1", null);
                //    in_node.SetUShort("USHT1", null);
                //    in_node.SetUInt("UINT1", null);
                //    in_node.SetULong("ULNG1", null);
                //    in_node.SetFloat("FLT1", null);
                //    in_node.SetDouble("DBL1", null);
                //    in_node.SetByte("BYT1", null);
                //    in_node.SetShort("SHT1", null);
                //    in_node.SetInt("INT1", null);
                //    in_node.SetLong("LNG1", null);
                //    in_node.AddDatetime("DTT1", null);
                //    in_node.SetBlob("BLB1", null);

                //    TRSNode ar2 = in_node.AddArray("ARRAY", TRSArrayDataType.Double);
                //    ar2.AddItem(null);
                //    ar2.AddItem(2.2222);
                //    ar2.AddItem(0.8329423489);
                //    ar2.AddItem(null);

                //    in_node.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    in_node.SetChar("CHR2", 'M');
                //    in_node.SetBoolean("BOL2", true);
                //    in_node.SetBinary("BIN2", 1);
                //    in_node.SetUByte("UBYT2", 2);
                //    in_node.SetUShort("USHT2", 3);
                //    in_node.SetUInt("UINT2", 4);
                //    in_node.SetULong("ULNG2", 5);
                //    in_node.SetFloat("FLT2", 6.66666f);
                //    in_node.SetDouble("DBL2", 7.000000009);
                //    in_node.SetByte("BYT2", -8);
                //    in_node.SetShort("SHT2", -9);
                //    in_node.SetInt("INT2", -10);
                //    in_node.SetLong("LNG2", -11);
                //    in_node.AddDatetime("DTT2", DateTime.Now);

                //    string ss = "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";
                //    ss += "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";
                //    ss += "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";
                //    ss += "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";
                //    ss += "[12/05/08,08:26:15] ´ëÇÑ¹Î±¹%%%%*********************************************************************[12/05/08,08:26:15] CUrtOcmSetup()[12/05/08,08:26:15] Installs ASPNET component[12/05/08,08:26:15] OC_PREINITIALIZE - SubComponent: [12/05/08,08:26:15] OnPreInitialize(), charWidth = 3[12/05/08,08:26:15] OC_INIT_COMPONENT - SubComponent: (null)[12/05/08,08:26:15] InitializeComponent()[12/05/08,08:26:16] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:26:16] OnQueryState()[12/05/08,08:26:16] Called with OCSELSTATETYPE_ORIGINAL ... determining if we were installed previously.[12/05/08,08:26:16] OnQueryState(),Return Value is  0[12/05/08,08:26:16] OC_CALC_DISK_SPACE - SubComponent: aspnet[12/05/08,08:26:16] OnCalculateDiskSpace(), adding = 1[12/05/08,08:26:16] OnCalculateDiskSpace(), adding size from section aspnet_install[12/05/08,08:26:16] OC_WIZARD_CREATED - SubComponent: (null)[12/05/08,08:26:16] OnWizardCreated()[12/05/08,08:39:05] OC_QUERY_STATE - SubComponent: aspnet[12/05/08,08:39:05] OnQueryState()[12/05/08,08:39:05] Called with OCSELSTATETYPE_CURRENT.[12/05/08,08:39:05] Upgrade not detected[12/05/08,08:39:05] OnQueryState(),Return Value is  0[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: (null)[12/05/08,08:39:45] OnQueueFileOperations was not called, since subcomponent is unknown[12/05/08,08:39:45] OC_QUEUE_FILE_OPS - SubComponent: aspnet[12/05/08,08:39:45] OnQueueFileOperations()[12/05/08,08:39:45] OnQueueFileOperations() - state has not changed, exiting[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: (null)[12/05/08,08:39:46] OnQueryStepCount was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_QUERY_STEP_COUNT - SubComponent: aspnet[12/05/08,08:39:46] OnQueryStepCount()[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: (null)[12/05/08,08:39:46] OnAboutToCommitQueue was not called, since subcomponent is unknown[12/05/08,08:39:46] OC_ABOUT_TO_COMMIT_QUEUE - SubComponent: aspnet[12/05/08,08:39:46] OnAboutToCommitQueue()";

                //    byte[] bs = System.Text.Encoding.Default.GetBytes(ss);
                //    in_node.SetBlob("BLB2", bs);

                //    TRSNode ls1 = in_node.AddNode("LIST");
                //    ls1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ls1.SetChar("CHR2", 'M');
                //    ls1.SetBoolean("BOL2", true);
                //    ls1.SetBinary("BIN2", 1);
                //    ls1.SetUByte("UBYT2", 2);
                //    ls1.SetUShort("USHT2", 3);
                //    ls1.SetUInt("UINT2", 4);
                //    ls1.SetULong("ULNG2", 5);
                //    ls1.SetFloat("FLT2", 6.66666f);
                //    ls1.SetDouble("DBL2", 7.000000009);
                //    ls1.SetByte("BYT2", -8);
                //    ls1.SetShort("SHT2", -9);
                //    ls1.SetInt("INT2", -10);
                //    ls1.SetLong("LNG2", -11);
                //    ls1.AddDatetime("DTT2", DateTime.Now);

                //    ls1 = in_node.AddNode("LIST");
                //    ls1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ls1.SetChar("CHR2", 'M');
                //    ls1.SetBoolean("BOL2", true);
                //    ls1.SetBinary("BIN2", 1);
                //    ls1.SetUByte("UBYT2", 2);
                //    ls1.SetUShort("USHT2", 3);
                //    ls1.SetUInt("UINT2", 4);
                //    ls1.SetULong("ULNG2", 5);
                //    ls1.SetFloat("FLT2", 6.66666f);
                //    ls1.SetDouble("DBL2", 7.000000009);
                //    ls1.SetByte("BYT2", -8);
                //    ls1.SetShort("SHT2", -9);
                //    ls1.SetInt("INT2", -10);
                //    ls1.SetLong("LNG2", -11);
                //    ls1.AddDatetime("DTT2", DateTime.Now);

                //    ls1 = in_node.AddNode("LIST");
                //    ls1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ls1.SetChar("CHR2", 'M');
                //    ls1.SetBoolean("BOL2", true);
                //    ls1.SetBinary("BIN2", 1);
                //    ls1.SetUByte("UBYT2", 2);
                //    ls1.SetUShort("USHT2", 3);
                //    ls1.SetUInt("UINT2", 4);
                //    ls1.SetULong("ULNG2", 5);
                //    ls1.SetFloat("FLT2", 6.66666f);
                //    ls1.SetDouble("DBL2", 7.000000009);
                //    ls1.SetByte("BYT2", -8);
                //    ls1.SetShort("SHT2", -9);
                //    ls1.SetInt("INT2", -10);
                //    ls1.SetLong("LNG2", -11);
                //    ls1.AddDatetime("DTT2", DateTime.Now);

                //    TRSNode ar1 = ls1.AddArray("ARRAY", TRSArrayDataType.String);
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //    ar1.SetString("STR2", "abcde´ëÇÑ¹Î±¹");
                //}

                //{
                //    FileInfo finfo;
                //    BinaryReader br;
                //    byte[] file_buffer;

                //    finfo = new FileInfo("d:\\aa.pdf");
                //    if (finfo.Exists == true)
                //    {
                //        br = new BinaryReader(finfo.OpenRead());
                //        file_buffer = br.ReadBytes((int)finfo.Length);
                //        in_node.AddBlob(MPGC.MP_BIN_DATA_2, file_buffer);
                //        br.Close();
                //    }
                //}


                if (MPCR.CallService("BAS", "BAS_Update_Message", in_node, ref out_node) == false)
                {
                    return false;
                }


                //// TRSNode Test Code
                //{
                //    string a1 = out_node.GetString("STR1");
                //    string a2 = out_node.GetString("STR2");
                //    char a3 = out_node.GetChar("CHR1");
                //    bool a4 = out_node.GetBoolean("BOL1");
                //    byte a5 = out_node.GetBinary("BIN1");
                //    byte a6 = out_node.GetUByte("UBYT1");
                //    ushort a7 = out_node.GetUShort("USHT1");
                //    uint a8 = out_node.GetUInt("UINT1");
                //    ulong a9 = out_node.GetULong("ULNG1");
                //    float a10 = out_node.GetFloat("FLT1");
                //    double a11 = out_node.GetDouble("DBL1");
                //    sbyte a12 = out_node.GetByte("BYT1");
                //    short a13 = out_node.GetShort("SHT1");
                //    int a14 = out_node.GetInt("INT1");
                //    long a15 = out_node.GetLong("LNG1");
                //    DateTime a16 = out_node.GetDatetime("DTT1");
                //    byte[] a17 = out_node.GetBlob("BLB1");
                //}

                //{
                //    FileInfo finfo;
                //    BinaryWriter bw;
                //    byte[] file_buffer;

                //    file_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_3);
                //    if (file_buffer != null)
                //    {
                //        finfo = new FileInfo("d:\\zz.pdf");
                //        bw = new BinaryWriter(finfo.OpenWrite());
                //        bw.Write(file_buffer);
                //        bw.Close();
                //    }
                //}

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisMsgList.Items.Add(MPCF.Trim(txtMsgId.Text), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (MPGV.gcLanguage == '1')
                        {
                            itm.SubItems.Add(MPCF.Trim(txtMsg1.Text));
                        }
                        else if (MPGV.gcLanguage == '2')
                        {
                            itm.SubItems.Add(MPCF.Trim(txtMsg2.Text));
                        }
                        else if (MPGV.gcLanguage == '3')
                        {
                            itm.SubItems.Add(MPCF.Trim(txtMsg3.Text));
                        }
                        itm.Selected = true;
                        lisMsgList.Sorting = SortOrder.Ascending;
                        lisMsgList.Sort();
                        itm.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisMsgList, MPCF.Trim(txtMsgId.Text), false) == true)
                        {
                            if (MPGV.gcLanguage == '1')
                            {
                                lisMsgList.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtMsg1.Text);
                            }
                            else if (MPGV.gcLanguage == '2')
                            {
                                lisMsgList.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtMsg2.Text);
                            }
                            else if (MPGV.gcLanguage == '3')
                            {
                                lisMsgList.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtMsg3.Text);
                            }
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisMsgList, MPCF.Trim(txtMsgId.Text), false);
                        if (idx != -1)
                        {
                            lisMsgList.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisMsgList.Items.Count);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }

        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete êµ¬ë¶„??
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "Update_Message":

                    switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                    {
                        case MPGC.MP_STEP_CREATE:
                            if (MPCF.CheckValue(cboMsgGrp, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.CheckValue(txtMsgId, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.CheckValue(txtMsg1, 1) == false)
                            {
                                return false;
                            }
                            break;

                        case MPGC.MP_STEP_UPDATE:

                            if (MPCF.CheckValue(cboMsgGrp, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.CheckValue(txtMsgId, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.CheckValue(txtMsg1, 1) == false)
                            {
                                return false;
                            }
                            break;
                        case MPGC.MP_STEP_DELETE:

                            if (MPCF.CheckValue(txtMsgId, 1) == false)
                            {
                                return false;
                            }
                            break;
                    }
                    break;
            }

            return true;

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cboMsgGrp;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmBASSetupMessage_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {

                MPCF.InitListView(lisMsgList);
                MPCF.FieldClear(this, rboMsgId);

                if (BASLIST.ViewMessageGroupList(cboMsgGrp, '1', null, false, false) == true)
                {
                    if (cboMsgGrp.Items.Count > 0)
                    {
                        //Modify by J.S. 2015.05.14 Á¸ÀçÇÏÁö ¾Ê´Â Ç×¸ñÀÌ ¿Ã°æ¿ì 0¹øÂ° Ç×¸ñ Display
                        int j = 0;
                        int i = 0;
                        if (s_msg_group != "")
                        {
                            for (i = 0; i < cboMsgGrp.Items.Count; i++)
                            {
                                if (cboMsgGrp.Items[i].ToString() == s_msg_group)
                                {
                                    j = i;
                                    break;
                                }
                            }
                        }

                        cboMsgGrp.SelectedIndex = j;

                        cboInsertMsgGrp.Items.Clear();
                        for (i = 0; i < cboMsgGrp.Items.Count; i++)
                        {
                            cboInsertMsgGrp.Items.Add(cboMsgGrp.Items[i]);
                        }
                    }
                }

                b_load_flag = true;
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisMsgList, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisMsgList, txtFind.Text, 0, true, false);
        }

        private void lisMsgList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lisMsgList.SelectedItems.Count > 0)
            {
                View_Message(MPCF.Trim(lisMsgList.SelectedItems[0].Text));
                txtInsertMsgId.Text = MPCF.Trim(lisMsgList.SelectedItems[0].Text);
                cboInsertMsgGrp.Text = MPCF.Trim(cboMsgGrp.Text);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                lblDataCount.Text = "";
                if (BASLIST.ViewMessageList(lisMsgList, '1', cboMsgGrp.Text, null, "", false) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisMsgList.Items.Count);
                    if (lisMsgList.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisMsgList, txtMsgId.Text, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("Update_Message", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Message(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("Update_Message", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Message(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Message", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Message(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    MPCF.FieldClear(this.pnlRight);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void txtMsgId_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)58)
            {
                e.Handled = true;
            }
        }

        private void cboMsgGrp_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboMsgGrp_TextChanged(object sender, System.EventArgs e)
        {

            if (cboMsgGrp.Text == "")
            {
                return;
            }
            lblDataCount.Text = "";
            if (BASLIST.ViewMessageList(lisMsgList, '1', cboMsgGrp.Text, null, "", false) == true)
            {
                lblDataCount.Text = MPCF.Trim(lisMsgList.Items.Count);
                if (lisMsgList.Items.Count > 0)
                {
                    if (MPCF.FindListItem(lisMsgList, txtMsgId.Text, false) == true)
                    {
                        lisMsgList_SelectedIndexChanged(lisMsgList, e);
                    }
                    else
                    {
                        lisMsgList.Items[0].Selected = true;
                    }

                    lisMsgList.Focus();
                }
            }

        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Message Group : " + cboMsgGrp.Text;
            MPCF.ExportToExcel(lisMsgList, this.Text, sCond);
        }

        private void btnInsertExportFile_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "SQL | *.sql";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInsertExportFile.Text = saveFileDialog.FileName;
                txtExport.Text = "";
            }

        }

        private void btnInsertExport_Click_1(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            string Query = null;
            string data;
            txtExport.Text = "";
            int i, j;
            string temp = null;
            string cmt = null;
            StringBuilder script = null;

            #region rdobutton Ã¼Å©
            if (rboMsgId.Checked == true)
            {
                Query = "SELECT * FROM MMSGMSGDEF WHERE MSG_ID = '" + txtInsertMsgId.Text + "'";
                cmt = "MMSGMSGDEF Table(MSG_ID) : " + txtInsertMsgId.Text;
            }
            else if (rboGroup.Checked == true)
            {
                Query = "SELECT * FROM MMSGMSGDEF WHERE MSG_GRP = '" + cboInsertMsgGrp.Text + "' ORDER BY MSG_ID";
                cmt = "MMSGMSGDEF Table(MSG_GRP) : " + cboInsertMsgGrp.Text;
            }
            else if (rboAllTbl.Checked == true)
            {
                Query = "SELECT * FROM MMSGMSGDEF ORDER BY MSG_ID";
                cmt = "MMSGMSGDEF Table(All Table) : MMSGMSGDEF";
            }
            #endregion

            script = new StringBuilder();
            progressBarExport.Value = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", Query);

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    progressBarExport.Maximum = out_node.GetList("ROWS").Count;

                    #region ÄÃ·³¸í ¼ÂÆÃ
                    temp = "INSERT INTO MMSGMSGDEF(";

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        temp += out_node.GetList(0)[i].GetString("NAME");
                        if (i < out_node.GetList(0).Count - 1) temp += ", ";
                    }
                    temp += ") VALUES(";
                    script.Append("/* Start [" + cmt + "] */\r\n");
                    script.Append(temp);
                    #endregion

                    if (out_node.GetList("ROWS").Count <= 0)
                    {
                        txtExport.Text = "No Data";
                        return;
                    }

                    //Request Reply Timeout ¹ß»ý½Ã ¿É¼Ç¿¡¼­ TimeOut½Ã°£À» ´Ã·ÁÁÖ¾î¾ßÇÔ
                    #region Data°ª ¹Þ±â
                    for (i = 0; i < out_node.GetList("ROWS").Count; i++)
                    {
                        for (j = 0; j < out_node.GetList("COLUMNS").Count; j++)
                        {
                            if (out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA") == "")
                            {
                                script.Append("' ");
                                if (j < out_node.GetList(0).Count - 1) script.Append("', ");
                                else script.Append("'");
                            }
                            else
                            {
                                script.Append("'");
                                if (out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA").Contains("'"))
                                {
                                    data = out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA").Replace("'", "''");
                                }
                                else
                                {
                                    data = out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA");
                                }
                                script.Append(data);
                                if (j < out_node.GetList(0).Count - 1) script.Append("', ");
                                else script.Append("'");
                            }
                        }
                        script.Append(");\r\n");
                        progressBarExport.Increment(1);

                        if (b_export_stop) //Stop Ã³¸®
                        {
                            txtExport.Focus();
                            txtExport.AppendText("<User Stop>..." + "\r\n");
                            b_export_stop = false;
                            return;
                        }
                        if (i < out_node.GetList("ROWS").Count - 1) script.Append(temp);
                        if (i >= out_node.GetList("ROWS").Count - 1) script.Append("/* End [" + cmt + "] */\r\n\r\n");
                    }
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (out_node.GetInt("NEXT_ROW") > 0);
                #endregion

                txtExport.Text = script.ToString();
                txtExport.Select(0, txtExport.Text.Length);
                txtExport.SelectionFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
                progressBarExport.Increment(1);

                if (txtInsertExportFile.Text != "")
                {
                    StreamWriter write = new StreamWriter(txtInsertExportFile.Text, false, Encoding.GetEncoding("EUC-KR"));
                    write.Write(script);
                    write.Close();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            progressBarExport.Value = 0;
            return;
        }

        private void btnClipCopy_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(txtExport.Text) != "")
                {
                    Clipboard.SetText(txtExport.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnInsertExportStop_Click_1(object sender, EventArgs e)
        {
            b_export_stop = true;
        }
    }
}
