//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupTestProgram.cs
//   Description : Setup Test Program 
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - End_Lot() : Start Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-04-06 : Created by DMKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.MsgHandler;
using Miracom.TRSCore;
using System.Collections;


namespace Miracom.WIPCore
{
    public partial class frmWIPSetupTestProgram : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupTestProgram()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        private void ClearData(string ProcStep)
        {
            try
            {
                switch (ProcStep)
                {
                    case "1":
                        MPCF.FieldClear(this);
                        break;

                    case "2":
                        // View Test Program List
                        MPCF.FieldClear(grpVersion);
                        MPCF.FieldClear(grpLotCMF);
                        MPCF.FieldClear(grpTestProgramInfo);
                        MPCF.FieldClear(grpPgmCMF);
                        MPCF.FieldClear(grpApproval);
                        MPCF.FieldClear(grpRelease);
                        MPCF.InitListView(lisPgmList);
                        MPCF.InitListView(lisVersion);

                        MPCR.ChangeControlEnabled(this, btnCreate, true);
                        MPCR.ChangeControlEnabled(this, btnUpdate, true);
                        MPCR.ChangeControlEnabled(this, btnDelete, true);

                        MPCR.ChangeControlEnabled(this, btnApproval, true);
                        MPCR.ChangeControlEnabled(this, btnCancelApproval, false);
                        MPCR.ChangeControlEnabled(this, btnRelease, true);

                        break;

                    case "3":
                        // View Test Program Version List & View Test Program Version Info
                        MPCF.FieldClear(grpTestProgramInfo);
                        MPCF.FieldClear(grpPgmCMF);
                        MPCF.FieldClear(grpApproval);
                        MPCF.FieldClear(grpRelease);
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool CheckCondition(char ProcStep)
        {
            if (tabRelation.SelectedTab == tbpMFO)
            {
                if (udcMFO.SelectedItem != MESCore.Controls.TreeSelectedItem.Oper)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    udcMFO.Focus();
                    return false;
                }
            }
            else if (tabRelation.SelectedTab == tbpRes)
            {
                if (udcRes.SelectedItem == MESCore.Controls.TreeSelectedItem.None || udcRes.SelectedItem == MESCore.Controls.TreeSelectedItem.Another)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    udcRes.Focus();
                    return false;
                }
            }

            if (numTestVersion.Value < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                tabTestProgramInfo.SelectedTab = tbpKeyValue;
                numTestVersion.Focus();
                return false;
            }

            switch (ProcStep)
            {
                case MPGC.MP_STEP_CREATE:
                case MPGC.MP_STEP_UPDATE:

                    if (MPCF.CheckValue(txtTestProgram, 1) == false)
                    {
                        tabTestProgramInfo.SelectedTab = tbpGeneral;
                        txtTestProgram.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(txtTestProgramVer, 1) == false)
                    {
                        tabTestProgramInfo.SelectedTab = tbpGeneral;
                        txtTestProgramVer.Focus();
                        return false;
                    }

                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpPgmCMF) == false)
                    {
                        tabTestProgramInfo.SelectedTab = tbpPgmCMF;
                        return false;
                    }
                    break;
            }

            return true;
        }

        private void SetGroupCmfItem()
        {
            MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblLotCMF", "cdvLotCMF", grpLotCMF);
            MPCR.SetCMFItem(MPGC.MP_CMF_TEST_PGM, "lblCMF", "cdvCMF", grpPgmCMF);

            string[] sGrpTableName = new string[10];

            sGrpTableName[0] = MPGC.MP_GCM_RES_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_RES_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_RES_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_RES_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_RES_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_RES_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_RES_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_RES_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_RES_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_RES_GRP_10;

            MPCR.SetGRPItem(MPGC.MP_GRP_RESOURCE, "lblResGrp", "cdvResGrp", grpLotCMF, sGrpTableName);
        
            ArrayList lblList;
            Label lblTemp;
            int i;

            lblList = MPCF.GetIndexedControl("lblLotCMF", grpLotCMF);
            for (i = 0; i < lblList.Count; i++)
            {
                lblTemp = (Label)lblList[i];
                lisPgmList.Columns[i].Text = lblTemp.Text;

                if (MPCF.Trim(lblTemp.Text) == "")
                {
                    lisPgmList.Columns[i].Width = 0;
                    continue;
                }

                lblTemp.Font = new Font(lblLotCMF1.Font, FontStyle.Regular);
            }

            lblList = MPCF.GetIndexedControl("lblResGrp", grpLotCMF);
            for (i = 0; i < lblList.Count; i++)
            {
                lblTemp = (Label)lblList[i];
                lisPgmList.Columns[i + 10].Text = lblTemp.Text;

                if (MPCF.Trim(lblTemp.Text) == "")
                {
                    lisPgmList.Columns[i + 10].Width = 0;
                    continue;
                }

                lblTemp.Font = new Font(lblLotCMF1.Font, FontStyle.Regular);
            }

            for (i = 0; i < lisPgmList.Columns.Count; i++)
            {
                if (lisPgmList.Columns[i].Text != "")
                {
                    lisPgmList.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }

            ArrayList cdvList;
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvList = MPCF.GetIndexedControl("cdvLotCMF", grpLotCMF);
            for (i = 0; i < cdvList.Count; i++)
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)cdvList[i];
                if (cdvTemp.Visible == false) continue;

                cdvTemp.ReadOnly = false;
            }

            cdvList = MPCF.GetIndexedControl("cdvResGrp", grpLotCMF);
            for (i = 0; i < cdvList.Count; i++)
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)cdvList[i];
                if (cdvTemp.Visible == false) continue;

                cdvTemp.ReadOnly = false;
            }

        }

        private bool ViewMFOSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            StringBuilder sb;

            MPCF.InitListView(udcMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (udcMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MWIPTSTPGM ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT MAT_ID, MAT_VER, OPER FROM MWIPTSTPGM ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER FROM MWIPTSTPGM ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER FROM MWIPTSTPGM ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER ASC");
                    break;

            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(udcMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private bool ViewResourceSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;

            MPCF.InitListView(udcRes.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (udcRes.SelectLevel)
            {
                case Miracom.MESCore.Controls.ResourceSelectLevel.R:
                    sb.Append("SELECT RES_ID FROM MWIPTSTPGM ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcRes.SelectLevelChar + "' ");
                    sb.Append("AND RES_ID <> ' ' ");
                    sb.Append("GROUP BY RES_ID ");
                    sb.Append("ORDER BY RES_ID ASC");
                    break;

                case Miracom.MESCore.Controls.ResourceSelectLevel.G:
                    sb.Append("SELECT RESG_ID FROM MWIPTSTPGM ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcRes.SelectLevelChar + "' ");
                    sb.Append("AND RESG_ID <> ' ' ");
                    sb.Append("GROUP BY RESG_ID ");
                    sb.Append("ORDER BY RESG_ID ASC");
                    break;

                case Miracom.MESCore.Controls.ResourceSelectLevel.T:
                    sb.Append("SELECT RES_TYPE FROM MWIPTSTPGM ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcRes.SelectLevelChar + "' ");
                    sb.Append("AND RES_TYPE <> ' ' ");
                    sb.Append("GROUP BY RES_TYPE ");
                    sb.Append("ORDER BY RES_TYPE ASC");
                    break;
            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(udcRes.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private bool ViewTestProgramKeyList()
        {
            TRSNode in_node = new TRSNode("VIEW_TEST_PROGRAM_KEY_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_TEST_PROGRAM_KEY_LIST_OUT");

            List<TRSNode> key_list;
            ListViewItem itmX;
            int i;

            MPCF.InitListView(lisPgmList);
            MPCF.InitListView(lisVersion);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (tabRelation.SelectedTab == tbpMFO)
            {
                in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                in_node.AddString("MAT_ID", udcMFO.MatID);
                in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                in_node.AddString("FLOW", udcMFO.Flow);
                in_node.AddInt("FLOW_SEQ_NUM", udcMFO.FlowSeqNum);
                in_node.AddString("OPER", udcMFO.Oper);
            }
            else
            {
                in_node.AddChar("REL_LEVEL", udcRes.SelectLevelChar);
                in_node.AddString("RES_TYPE", udcRes.ResourceType);
                in_node.AddString("RESG_ID", udcRes.ResourceGroup);
                in_node.AddString("RES_ID", udcRes.Resource);
            }

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Test_Program_Key_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                key_list = out_node.GetList("PGM_KEY_LIST");
                for (i = 0; i < key_list.Count; i++)
                {
                    itmX = new ListViewItem(key_list[i].GetString("LOT_CMF_1"), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    itmX.SubItems.Add(key_list[i].GetString("LOT_CMF_2"));
                    itmX.SubItems.Add(key_list[i].GetString("LOT_CMF_3"));
                    itmX.SubItems.Add(key_list[i].GetString("LOT_CMF_4"));
                    itmX.SubItems.Add(key_list[i].GetString("LOT_CMF_5"));
                    itmX.SubItems.Add(key_list[i].GetString("LOT_CMF_6"));
                    itmX.SubItems.Add(key_list[i].GetString("LOT_CMF_7"));
                    itmX.SubItems.Add(key_list[i].GetString("LOT_CMF_8"));
                    itmX.SubItems.Add(key_list[i].GetString("LOT_CMF_9"));
                    itmX.SubItems.Add(key_list[i].GetString("LOT_CMF_10"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_1"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_2"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_3"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_4"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_5"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_6"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_7"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_8"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_9"));
                    itmX.SubItems.Add(key_list[i].GetString("RES_GRP_10"));

                    lisPgmList.Items.Add(itmX);
                }

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while(in_node.GetInt("NEXT_SEQ") > 0);

            for (i = 0; i < lisPgmList.Columns.Count; i++)
            {
                if (lisPgmList.Columns[i].Text != "")
                {
                    lisPgmList.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }

            return true;
        }

        private bool ViewTestProgramVersionList()
        {
            TRSNode in_node = new TRSNode("VIEW_TEST_PROGRAM_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_TEST_PROGRAM_VERSION_LIST_OUT");
            List<TRSNode> ver_list;
            ListViewItem itmX;
            int i;

            try
            {
                MPCF.InitListView(lisVersion);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (tabRelation.SelectedTab == tbpMFO)
                {
                    in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", udcMFO.MatID);
                    in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                    in_node.AddString("FLOW", udcMFO.Flow);
                    in_node.AddInt("FLOW_SEQ_NUM", udcMFO.FlowSeqNum);
                    in_node.AddString("OPER", udcMFO.Oper);
                }
                else
                {
                    in_node.AddChar("REL_LEVEL", udcRes.SelectLevelChar);
                    in_node.AddString("RES_TYPE", udcRes.ResourceType);
                    in_node.AddString("RESG_ID", udcRes.ResourceGroup);
                    in_node.AddString("RES_ID", udcRes.Resource);
                }

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvLotCMF1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvLotCMF2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvLotCMF3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvLotCMF4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvLotCMF5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvLotCMF6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvLotCMF7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvLotCMF8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvLotCMF9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvLotCMF10.Text));
                in_node.AddString("RES_GRP_1", MPCF.Trim(cdvResGrp1.Text));
                in_node.AddString("RES_GRP_2", MPCF.Trim(cdvResGrp2.Text));
                in_node.AddString("RES_GRP_3", MPCF.Trim(cdvResGrp3.Text));
                in_node.AddString("RES_GRP_4", MPCF.Trim(cdvResGrp4.Text));
                in_node.AddString("RES_GRP_5", MPCF.Trim(cdvResGrp5.Text));
                in_node.AddString("RES_GRP_6", MPCF.Trim(cdvResGrp6.Text));
                in_node.AddString("RES_GRP_7", MPCF.Trim(cdvResGrp7.Text));
                in_node.AddString("RES_GRP_8", MPCF.Trim(cdvResGrp8.Text));
                in_node.AddString("RES_GRP_9", MPCF.Trim(cdvResGrp9.Text));
                in_node.AddString("RES_GRP_10", MPCF.Trim(cdvResGrp10.Text));

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Test_Program_Version_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    ver_list = out_node.GetList("TEST_VER_LIST");
                    for (i = 0; i < ver_list.Count; i++)
                    {
                        itmX = new ListViewItem(MPCF.Trim(ver_list[i].GetInt("TEST_VERSION")), (int)SMALLICON_INDEX.IDX_VERSION);
                        lisVersion.Items.Add(itmX);
                    }

                    in_node.SetInt("NEXT_TEST_VERSION", out_node.GetInt("NEXT_TEST_VERSION"));
                } while(in_node.GetInt("NEXT_TEST_VERSION") > 0);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewTestProgramVersion()
        {
            TRSNode in_node = new TRSNode("VIEW_TEST_PROGRAM_VERSION_IN");
            TRSNode out_node = new TRSNode("VIEW_TEST_PROGRAM_VERSION_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (tabRelation.SelectedTab == tbpMFO)
                {
                    in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", udcMFO.MatID);
                    in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                    in_node.AddString("FLOW", udcMFO.Flow);
                    in_node.AddInt("FLOW_SEQ_NUM", udcMFO.FlowSeqNum);
                    in_node.AddString("OPER", udcMFO.Oper);
                }
                else
                {
                    in_node.AddChar("REL_LEVEL", udcRes.SelectLevelChar);
                    in_node.AddString("RES_TYPE", udcRes.ResourceType);
                    in_node.AddString("RESG_ID", udcRes.ResourceGroup);
                    in_node.AddString("RES_ID", udcRes.Resource);
                }

                in_node.AddInt("TEST_VERSION", numTestVersion.Value);

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvLotCMF1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvLotCMF2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvLotCMF3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvLotCMF4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvLotCMF5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvLotCMF6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvLotCMF7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvLotCMF8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvLotCMF9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvLotCMF10.Text));
                in_node.AddString("RES_GRP_1", MPCF.Trim(cdvResGrp1.Text));
                in_node.AddString("RES_GRP_2", MPCF.Trim(cdvResGrp2.Text));
                in_node.AddString("RES_GRP_3", MPCF.Trim(cdvResGrp3.Text));
                in_node.AddString("RES_GRP_4", MPCF.Trim(cdvResGrp4.Text));
                in_node.AddString("RES_GRP_5", MPCF.Trim(cdvResGrp5.Text));
                in_node.AddString("RES_GRP_6", MPCF.Trim(cdvResGrp6.Text));
                in_node.AddString("RES_GRP_7", MPCF.Trim(cdvResGrp7.Text));
                in_node.AddString("RES_GRP_8", MPCF.Trim(cdvResGrp8.Text));
                in_node.AddString("RES_GRP_9", MPCF.Trim(cdvResGrp9.Text));
                in_node.AddString("RES_GRP_10", MPCF.Trim(cdvResGrp10.Text));

                if (MPCR.CallService("WIP", "WIP_View_Test_Program_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtTestProgram.Text = out_node.GetString("TEST_PGM_NAME");
                txtTestProgramVer.Text = out_node.GetString("TEST_PGM_VER");

                txtTestTime.Text = MPCF.Trim(out_node.GetString("TEST_TIME"));
                txtIndexTime.Text = MPCF.Trim(out_node.GetString("INDEX_TIME"));
                txtTemperature.Text = MPCF.Trim(out_node.GetString("TEST_TEMP"));
                txtProgramDir.Text = MPCF.Trim(out_node.GetString("PROGRAM_DIR"));

                txtDescription.Text = MPCF.Trim(out_node.GetString("DESCRIPTION"));

                if (out_node.GetString("APPLY_START_TIME") == "")
                {
                    chkStart.Checked = false;
                }
                else
                {
                    chkStart.Checked = true;

                    if (out_node.GetString("APPLY_START_TIME") != null)
                    {
                        dtpStartDate.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                        dtpStartTime.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                    }
                }
                if (out_node.GetString("APPLY_END_TIME") == "")
                {
                    chkEnd.Checked = false;
                }
                else
                {
                    chkEnd.Checked = true;

                    if (out_node.GetString("APPLY_END_TIME") != null)
                    {
                        dtpEndDate.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                        dtpEndTime.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                    }

                }

                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);

                MPCR.ChangeControlEnabled(this, btnApproval, true);
                MPCR.ChangeControlEnabled(this, btnCancelApproval, false);
                MPCR.ChangeControlEnabled(this, btnRelease, true);

                if (out_node.GetChar("APPROVAL_FLAG") == 'Y')
                {
                    txtApprovalUser.Text = MPCF.Trim(out_node.GetString("APPROVAL_USER_ID"));
                    txtApprovalTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPROVAL_TIME"));

                    MPCR.ChangeControlEnabled(this, btnCreate, false);
                    MPCR.ChangeControlEnabled(this, btnUpdate, false);
                    MPCR.ChangeControlEnabled(this, btnDelete, false);

                    MPCR.ChangeControlEnabled(this, btnApproval, false);
                    MPCR.ChangeControlEnabled(this, btnCancelApproval, true);
                    MPCR.ChangeControlEnabled(this, btnRelease, true);
                }
                if (out_node.GetChar("RELEASE_FLAG") == 'Y')
                {
                    txtReleaseUser.Text = MPCF.Trim(out_node.GetString("RELEASE_USER_ID"));
                    txtReleaseTime.Text = MPCF.MakeDateFormat(out_node.GetString("RELEASE_TIME"));

                    MPCR.ChangeControlEnabled(this, btnCreate, false);
                    MPCR.ChangeControlEnabled(this, btnUpdate, false);
                    MPCR.ChangeControlEnabled(this, btnDelete, false);

                    MPCR.ChangeControlEnabled(this, btnApproval, false);
                    MPCR.ChangeControlEnabled(this, btnCancelApproval, false);
                    MPCR.ChangeControlEnabled(this, btnRelease, false);
                }

                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                cdvCMF1.Text = out_node.GetString("TEST_PGM_CMF_1");
                cdvCMF2.Text = out_node.GetString("TEST_PGM_CMF_2");
                cdvCMF3.Text = out_node.GetString("TEST_PGM_CMF_3");
                cdvCMF4.Text = out_node.GetString("TEST_PGM_CMF_4");
                cdvCMF5.Text = out_node.GetString("TEST_PGM_CMF_5");
                cdvCMF6.Text = out_node.GetString("TEST_PGM_CMF_6");
                cdvCMF7.Text = out_node.GetString("TEST_PGM_CMF_7");
                cdvCMF8.Text = out_node.GetString("TEST_PGM_CMF_8");
                cdvCMF9.Text = out_node.GetString("TEST_PGM_CMF_9");
                cdvCMF10.Text = out_node.GetString("TEST_PGM_CMF_10");
                cdvCMF11.Text = out_node.GetString("TEST_PGM_CMF_11");
                cdvCMF12.Text = out_node.GetString("TEST_PGM_CMF_12");
                cdvCMF13.Text = out_node.GetString("TEST_PGM_CMF_13");
                cdvCMF14.Text = out_node.GetString("TEST_PGM_CMF_14");
                cdvCMF15.Text = out_node.GetString("TEST_PGM_CMF_15");
                cdvCMF16.Text = out_node.GetString("TEST_PGM_CMF_16");
                cdvCMF17.Text = out_node.GetString("TEST_PGM_CMF_17");
                cdvCMF18.Text = out_node.GetString("TEST_PGM_CMF_18");
                cdvCMF19.Text = out_node.GetString("TEST_PGM_CMF_19");
                cdvCMF20.Text = out_node.GetString("TEST_PGM_CMF_20");

                return true;
            }
            catch (Exception eX)
            {
                MPCF.ShowMsgBox(eX.Message);
                return false;
            }
        }

        private bool UpdateTestProgram(char c_case)
        {
            TRSNode in_node = new TRSNode("UPDATE_TEST_PROGRAM_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_case;

                if (tabRelation.SelectedTab == tbpMFO)
                {
                    in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", udcMFO.MatID);
                    in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                    in_node.AddString("FLOW", udcMFO.Flow);
                    in_node.AddString("OPER", udcMFO.Oper);

                }
                else
                {
                    in_node.AddChar("REL_LEVEL", udcRes.SelectLevelChar);
                    in_node.AddString("RES_TYPE", udcRes.ResourceType);
                    in_node.AddString("RESG_ID", udcRes.ResourceGroup);
                    in_node.AddString("RES_ID", udcRes.Resource);

                }

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvLotCMF1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvLotCMF2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvLotCMF3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvLotCMF4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvLotCMF5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvLotCMF6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvLotCMF7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvLotCMF8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvLotCMF9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvLotCMF10.Text));

                in_node.AddString("RES_GRP_1", MPCF.Trim(cdvResGrp1.Text));
                in_node.AddString("RES_GRP_2", MPCF.Trim(cdvResGrp2.Text));
                in_node.AddString("RES_GRP_3", MPCF.Trim(cdvResGrp3.Text));
                in_node.AddString("RES_GRP_4", MPCF.Trim(cdvResGrp4.Text));
                in_node.AddString("RES_GRP_5", MPCF.Trim(cdvResGrp5.Text));
                in_node.AddString("RES_GRP_6", MPCF.Trim(cdvResGrp6.Text));
                in_node.AddString("RES_GRP_7", MPCF.Trim(cdvResGrp7.Text));
                in_node.AddString("RES_GRP_8", MPCF.Trim(cdvResGrp8.Text));
                in_node.AddString("RES_GRP_9", MPCF.Trim(cdvResGrp9.Text));
                in_node.AddString("RES_GRP_10", MPCF.Trim(cdvResGrp10.Text));

                in_node.AddInt("TEST_VERSION", numTestVersion.Value);

                in_node.AddString("TEST_PGM_NAME", MPCF.Trim(txtTestProgram.Text));
                in_node.AddString("TEST_PGM_VER", MPCF.Trim(txtTestProgramVer.Text));
                in_node.AddString("DESCRIPTION", MPCF.Trim(txtDescription.Text));

                in_node.AddString("TEST_TIME", MPCF.Trim(txtTestTime.Text));
                in_node.AddString("INDEX_TIME", MPCF.Trim(txtIndexTime.Text));
                in_node.AddString("TEST_TEMP", MPCF.Trim(txtTemperature.Text));
                in_node.AddString("PROGRAM_DIR", MPCF.Trim(txtProgramDir.Text));

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

                in_node.AddString("TEST_PGM_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TEST_PGM_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TEST_PGM_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TEST_PGM_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TEST_PGM_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TEST_PGM_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TEST_PGM_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TEST_PGM_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TEST_PGM_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TEST_PGM_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("TEST_PGM_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("TEST_PGM_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("TEST_PGM_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("TEST_PGM_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("TEST_PGM_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("TEST_PGM_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("TEST_PGM_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("TEST_PGM_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("TEST_PGM_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("TEST_PGM_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (MPCR.CallService("WIP", "WIP_Update_Test_Program", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private bool ApprovalReleaseTestProgram(char c_case)
        {
            TRSNode in_node = new TRSNode("RELEASE_TEST_PROGRAM_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_case;

                if (tabRelation.SelectedTab == tbpMFO)
                {
                    in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", udcMFO.MatID);
                    in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                    in_node.AddString("FLOW", udcMFO.Flow);
                    in_node.AddString("OPER", udcMFO.Oper);

                }
                else
                {
                    in_node.AddChar("REL_LEVEL", udcRes.SelectLevelChar);
                    in_node.AddString("RES_TYPE", udcRes.ResourceType);
                    in_node.AddString("RESG_ID", udcRes.ResourceGroup);
                    in_node.AddString("RES_ID", udcRes.Resource);

                }

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvLotCMF1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvLotCMF2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvLotCMF3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvLotCMF4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvLotCMF5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvLotCMF6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvLotCMF7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvLotCMF8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvLotCMF9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvLotCMF10.Text));

                in_node.AddString("RES_GRP_1", MPCF.Trim(cdvResGrp1.Text));
                in_node.AddString("RES_GRP_2", MPCF.Trim(cdvResGrp2.Text));
                in_node.AddString("RES_GRP_3", MPCF.Trim(cdvResGrp3.Text));
                in_node.AddString("RES_GRP_4", MPCF.Trim(cdvResGrp4.Text));
                in_node.AddString("RES_GRP_5", MPCF.Trim(cdvResGrp5.Text));
                in_node.AddString("RES_GRP_6", MPCF.Trim(cdvResGrp6.Text));
                in_node.AddString("RES_GRP_7", MPCF.Trim(cdvResGrp7.Text));
                in_node.AddString("RES_GRP_8", MPCF.Trim(cdvResGrp8.Text));
                in_node.AddString("RES_GRP_9", MPCF.Trim(cdvResGrp9.Text));
                in_node.AddString("RES_GRP_10", MPCF.Trim(cdvResGrp10.Text));

                in_node.AddInt("TEST_VERSION", numTestVersion.Value);

                if (MPCR.CallService("WIP", "WIP_Approval_Release_Test_Program", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        #endregion

        private void frmWIPSetupTestProgram_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.FieldClear(this);
                    MPCF.InitListView(lisPgmList);

                    ClearData("1");
                    SetGroupCmfItem();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            if (tabRelation.SelectedTab == tbpMFO)
            {
                udcMFO.GetNext(txtFind.Text);
            }
            else
            {
                udcRes.GetNext(txtFind.Text);
            }
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            if (tabRelation.SelectedTab == tbpMFO)
            {
                udcMFO.RefreshSelectedList();
            }
            else
            {
                udcRes.RefreshSelectedList();
            }
        }

        private void cdvCMFGrp_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMFGrp_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        private void tabRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData("2");
        }


        private void udcMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.GetTreeView.GetNodeCount(false));
        }

        private void udcMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.SelectedNode.GetNodeCount(false));
        }

        private void udcMFO_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            ClearData("2");
            ViewTestProgramKeyList();
        }

        private void udcMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewMFOSettingDataList();
        }

        private void udcMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData("2");
            udcMFO_LevelItemSelect(null, null);
        }


        private void udcRes_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcRes.GetTreeView.GetNodeCount(false));
        }

        private void udcRes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcRes.SelectedNode.GetNodeCount(false));
        }

        private void udcRes_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            ClearData("2");
            ViewTestProgramKeyList();
        }

        private void udcRes_GetOnlySetData(object sender, EventArgs e)
        {
            ViewResourceSettingDataList();
        }

        private void udcRes_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            udcRes_LevelItemSelect(null, null);
        }


        private void lisCMFList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisPgmList.SelectedItems.Count < 1) return;

            cdvLotCMF1.Text = lisPgmList.SelectedItems[0].SubItems[0].Text;
            cdvLotCMF2.Text = lisPgmList.SelectedItems[0].SubItems[1].Text;
            cdvLotCMF3.Text = lisPgmList.SelectedItems[0].SubItems[2].Text;
            cdvLotCMF4.Text = lisPgmList.SelectedItems[0].SubItems[3].Text;
            cdvLotCMF5.Text = lisPgmList.SelectedItems[0].SubItems[4].Text;
            cdvLotCMF6.Text = lisPgmList.SelectedItems[0].SubItems[5].Text;
            cdvLotCMF7.Text = lisPgmList.SelectedItems[0].SubItems[6].Text;
            cdvLotCMF8.Text = lisPgmList.SelectedItems[0].SubItems[7].Text;
            cdvLotCMF9.Text = lisPgmList.SelectedItems[0].SubItems[8].Text;
            cdvLotCMF10.Text = lisPgmList.SelectedItems[0].SubItems[9].Text;

            cdvResGrp1.Text = lisPgmList.SelectedItems[0].SubItems[10].Text;
            cdvResGrp2.Text = lisPgmList.SelectedItems[0].SubItems[11].Text;
            cdvResGrp3.Text = lisPgmList.SelectedItems[0].SubItems[12].Text;
            cdvResGrp4.Text = lisPgmList.SelectedItems[0].SubItems[13].Text;
            cdvResGrp5.Text = lisPgmList.SelectedItems[0].SubItems[14].Text;
            cdvResGrp6.Text = lisPgmList.SelectedItems[0].SubItems[15].Text;
            cdvResGrp7.Text = lisPgmList.SelectedItems[0].SubItems[16].Text;
            cdvResGrp8.Text = lisPgmList.SelectedItems[0].SubItems[17].Text;
            cdvResGrp9.Text = lisPgmList.SelectedItems[0].SubItems[18].Text;
            cdvResGrp10.Text = lisPgmList.SelectedItems[0].SubItems[19].Text;

            // View Test Program Version List
            ClearData("3");
            if (ViewTestProgramVersionList() == false) return;
        }

        private void lisVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisVersion.SelectedItems.Count < 1) return;

            numTestVersion.Value = MPCF.ToInt(lisVersion.SelectedItems[0].Text);

            // View Test Program Version Info
            ClearData("3");
            if (ViewTestProgramVersion() == false) return;
        }

        private void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStart.Checked == true)
            {
                dtpStartDate.Enabled = true;
                dtpStartTime.Enabled = true;
            }
            else
            {
                dtpStartDate.Enabled = false;
                dtpStartTime.Enabled = false;
            }
        }

        private void chkEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnd.Checked == true)
            {
                dtpEndDate.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else
            {
                dtpEndDate.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;
            if (UpdateTestProgram(MPGC.MP_STEP_CREATE) == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                if (ViewTestProgramKeyList() == false) return;
                if (ViewTestProgramVersionList() == false) return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;
            if (UpdateTestProgram(MPGC.MP_STEP_UPDATE) == false) return;

            ClearData("3");
            if (MPGV.gbListAutoRefresh == true)
            {
                if (ViewTestProgramVersion() == false) return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;
            if (UpdateTestProgram(MPGC.MP_STEP_DELETE) == false) return;

            ClearData("2");
            if (MPGV.gbListAutoRefresh == true)
            {
                if (ViewTestProgramKeyList() == false) return;
            }
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_APPROVAL) == false) return;
            if (ApprovalReleaseTestProgram(MPGC.MP_STEP_APPROVAL) == false) return;
            if (MPGV.gbListAutoRefresh == true)
            {
                if (ViewTestProgramVersion() == false) return;
            }
        }

        private void btnCancelApproval_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CANCEL_APPROVAL) == false) return;
            if (ApprovalReleaseTestProgram(MPGC.MP_STEP_CANCEL_APPROVAL) == false) return;
            if (MPGV.gbListAutoRefresh == true)
            {
                if (ViewTestProgramVersion() == false) return;
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_RELEASE) == false) return;
            if (ApprovalReleaseTestProgram(MPGC.MP_STEP_RELEASE) == false) return;
            if (MPGV.gbListAutoRefresh == true)
            {
                if (ViewTestProgramVersion() == false) return;
            }
        }

        private void numTestVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (numTestVersion.Value > 0)
            {
                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);

                MPCR.ChangeControlEnabled(this, btnApproval, true);
                MPCR.ChangeControlEnabled(this, btnCancelApproval, false);
                MPCR.ChangeControlEnabled(this, btnRelease, true);
            }
        }



    }
}
