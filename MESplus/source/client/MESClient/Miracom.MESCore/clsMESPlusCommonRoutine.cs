using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FarPoint.Win.Spread;
using Infragistics.Win.UltraWinEditors;

using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Reflection;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modCommonRoutine.vb
//   Description : Client Common Routine Module
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - InitGRPCMFControl()           : Group/ Cmf Control?§ÏùÑ Ï¥àÍ∏∞???úÎã§.
//       - SetGRPItem()                  : Group Control??GroupÍ∞íÏùÑ ?ïÏùò ?úÎã§.
//       - SetCMFItem()                  : Cmf Control??CmfÍ∞íÏùÑ ?ïÏùò ?úÎã§.
//       - ProcGRPCMFButtonPress()       : Group / Cmf CodeView Control?êÏÑú??ButtonPress?¥Î≤§?∏Î? Ï≤òÎ¶¨?úÎã§.
//       - CheckCMFKeyPress()            : Cmf Control?êÏÑú??KeyPress?¥Î≤§?∏Ïóê???ÖÎ†•Î¨∏Ïûê Format??ÎßûÎäîÏßÄ ?ïÏù∏?úÎã§.
//       - CheckGRPCMFValue()            : ?ÖÎ†•??Group/ CmfÍ∞íÎì§??ÎßûÎäîÏßÄ ?ïÏù∏?úÎã§.
//       - SetLotInfoSpreadInit()        : Lot??Í∏∞Î≥∏?ïÎ≥¥ SpreadÎ•?Ï¥àÍ∏∞?îÌïú??
//       - SetLotInfoSpread()            : Lot??Í∏∞Î≥∏?ïÎ≥¥ Spread??Lot ?ïÎ≥¥Î•?Ï±ÑÏö¥??
//       - FindColSetVersion()           : Collection Set???Ä???åÎßû?Ä Version ?ïÎ≥¥Î•?Ï∞æÍ≥† Character ?ïÎ≥¥Î•?ÎøåÎ†§Ï§Ä??
//       - ViewAttachCharacterList()     : Collection Set Version??Attach??Character List?§ÏùÑ spreadsheet??ÎøåÎ†§Ï§Ä??
//       - ViewMFOColSet()               : MFO???†Îãπ??Collection Set??Î≥¥Ïó¨Ï§Ä??
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-17 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.MESCore
{
    //use in udcFromToDate. why? I don't now.....
    //ask to choi min suk..!!!!
    public struct WeekInforTag
    {
        public int iDay;
        public int iMonth;
        public int iYear;
        public string sCalendarID;
        public int Week;
        public int WeekDays;
        public string WeekEndDate;
        public int WeekIndex;
        public string WeekStartDate;
    }

    public sealed class MPCR
    {

        #region "Const Definition"

        private const int VALUE_START_COL = 12;
        private const int DEFAULT_COL_COUNT = 12;

        #endregion

        #region "Enum Definition"

        private enum CHAR_COLUMN
        {
            CHAR_COL = 0,
            CHAR_DESC_COL = 1,
            SPEC_COL = 2,
            OPT_INPUT_COL = 3,
            VALUE_TYPE_COL = 4,
            VALUE_COUNT_COL = 5,
            DEF_UNIT_OVR_FLAG_COL = 6,
            DEF_VALUE_COL = 7,
            UNIT_TBL_COL = 8,
            VALUE_TBL_COL = 9,
            UNIT_SEQ_COL = 10,
            UNIT_COL = 11,
            VALUE_START_COL = 12
        }

        //Add by Kelly Jung for Lot Extension
        public enum INPUT_VALUE_TYPE
        {
            ATTRIBUTE = 0,
            LOT_EXTENSION = 1,
            TOOL
        }
        //Add by Kelly Jung for Lot Extension
        public enum INPUT_VALUE_POINT
        {
            START = 0,
            END = 1,
            CREATE = 2,
            SHIP = 3,
            RECEIVE = 4,
            HOLD = 5,
            RELEASE = 6,
            SPLIT = 7,
            MERGE = 8,
            COMBINE = 9,
            LOSS = 10,
            MOVE = 11,
            REWORK = 12,
            SKIP = 13,
            LOTEDC = 14,
            ADHOC =15,
            ADAPT
        }

        #endregion

        #region " Variable Definition "

        public static int iFieldSeq;

        #endregion

        // InitGRPCMFControl()
        //       - initial Group/Cmf Control
        // Return Value
        //       -
        // Arguments
        //       - ByVal sLabelName As String            : Label Control Prefix Name
        //        - ByVal sCodeViewName As String            : CodeView Control Prefix Name
        //        - ByVal parentControl As Control        : ParentControl
        public static void InitGRPCMFControl(string sLabelName, string sCodeViewName, Control parentControl)
        {
            ArrayList controls;
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            int i;

            controls = MPCF.GetIndexedControl(sLabelName, parentControl);
            for (i = 0; i <= controls.Count - 1; i++)
            {
                ((Label)controls[i]).Visible = false;
                ((Label)controls[i]).Text = "";
            }

            controls = MPCF.GetIndexedControl(sCodeViewName, parentControl);
            for (i = 0; i <= controls.Count - 1; i++)
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)controls[i];
                cdvTemp.Init();

                /* 2013.05.13. Aiden. CMF/GRP ø°º≠ ºˆ±‚ ¿‘∑¬¿Ã ∞°¥…«œ∞‘ ∫Ø∞Ê.
                 * º≠∫ÒΩ∫ø°º≠ Validation «œ∞Ì ¿÷∞Ì, CMF/GRP Item ¿Ã π´¡ˆ ∏π¿∫ ∞ÊøÏ ∏ÆΩ∫∆Æ ∞°¡Æø¿¥¬µ• ø¿∑°∞…∏≤.
                 */

                cdvTemp.ReadOnly = false;
                cdvTemp.VisibleButton = true;
                cdvTemp.Visible = false;
                cdvTemp.AllowDrop = true;

                MPCF.InitListView(cdvTemp.GetListView);
                cdvTemp.Columns.Add("Value", 100, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvTemp.SelectedSubItemIndex = 0;
            }
        }

        // SetGRPItem()
        //       - Setting Group Control Property
        // Return Value
        //       -
        // Arguments
        //       - ByVal sItemName As String             : Group Item Name
        //       - ByVal sLabelName As String            : Label Control Prefix Name
        //        - ByVal sCodeViewName As String            : CodeView Control Prefix Name
        //        - ByVal parentControl As Control        : ParentControl
        //       - ByVal ParamArray sGrpTableName() As String : Group Table Name array
        public static void SetGRPItem(string sItemName, string sLabelName, string sCodeViewName, Control parentControl, string[] sGrpTableName)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ArrayList lblList;
            ArrayList cdvList;
            Label lblTemp;
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            int i;

            try
            {
                InitGRPCMFControl(sLabelName, sCodeViewName, parentControl);

                if (WIPLIST.ViewFactoryCmfData('1', sItemName, ref out_node, "", true) == false)
                {
                    return;
                }

                lblList = MPCF.GetIndexedControl(sLabelName, parentControl);
                cdvList = MPCF.GetIndexedControl(sCodeViewName, parentControl);

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    lblTemp = (Label)lblList[i];
                    cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)cdvList[i];

                    lblTemp.Text = out_node.GetList(0)[i].GetString("PROMPT");

                    // 2006.07.19. Aiden Koo
                    // Variable Group Table ??Ïß¢Ê?êÌïòÍ∏??ÑÌï¥??Î≥¢ÊÍ≤?
                    // MWIPFACCMF.TBL ??Ïß¢Ê?ïÎêúTable Name??Ï°¥Ïû¨?úÎã§Î©?Í∑?Table??Item?ºÎ°úÍ∞íÏùÑ?úÏãú
                    if (out_node.GetList(0)[i].GetString("TABLE_NAME") != "")
                    {
                        sGrpTableName[i] = out_node.GetList(0)[i].GetString("TABLE_NAME");
                    }

                    if (lblTemp.Text != "")
                    {
                        lblTemp.Font = new System.Drawing.Font(lblTemp.Font, System.Drawing.FontStyle.Bold);
                        lblTemp.Visible = true;

                        cdvTemp.Tag = "A" + sGrpTableName[i];
                        cdvTemp.Visible = true;
                        cdvTemp.AllowDrop = false;

                        if (MPCF.Trim(cdvTemp.Tag) != "")
                        {
                            if (cdvTemp.DisplaySubItemIndex != cdvTemp.SelectedSubItemIndex)
                            {
                                BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', sGrpTableName[i], -1, null, "", false, -1, -1, null);
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


        // SetCMFItem()
        //       - Setting Cmf Control Property
        // Return Value
        //       -
        // Arguments
        //       - ByVal sItemName As String             : Group Item Name
        //       - ByVal sLabelName As String            : Label Control Prefix Name
        //        - ByVal sCodeViewName As String            : CodeView Control Prefix Name
        //        - ByVal parentControl As Control        : ParentControl
        public static void SetCMFItem(string sItemName, string sLabelName, string sCodeViewName, Control parentControl)
        {
            SetCMFItem(sItemName, sLabelName, sCodeViewName, parentControl, "");
        }
        public static void SetCMFItem(string sItemName, string sLabelName, string sCodeViewName, Control parentControl, string sFactory)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ArrayList lblList;
            ArrayList cdvList;
            Label lblTemp;
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            int i;

            try
            {
                InitGRPCMFControl(sLabelName, sCodeViewName, parentControl);

                if (WIPLIST.ViewFactoryCmfData('1', sItemName, ref out_node, sFactory, true) == false)
                {
                    return;
                }

                lblList = MPCF.GetIndexedControl(sLabelName, parentControl);
                cdvList = MPCF.GetIndexedControl(sCodeViewName, parentControl);

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (i >= cdvList.Count)
                    {
                        break;
                    }

                    lblTemp = (Label)lblList[i];
                    cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)cdvList[i];

                    lblTemp.Text = out_node.GetList(0)[i].GetString("PROMPT");

                    if (lblTemp.Text != "")
                    {
                        if (out_node.GetList(0)[i].GetChar("OPT") == 'Y')
                        {
                            lblTemp.Font = new System.Drawing.Font(lblTemp.Font, System.Drawing.FontStyle.Bold);
                            cdvTemp.AllowDrop = false;
                        }

                        cdvTemp.Tag = out_node.GetList(0)[i].GetChar("FORMAT");
                        cdvTemp.Tag = cdvTemp.Tag + out_node.GetList(0)[i].GetString("TABLE_NAME");
                        if (out_node.GetList(0)[i].GetString("TABLE_NAME") == "")
                        {
                            cdvTemp.VisibleButton = false;
                            cdvTemp.DisplaySubItemIndex = cdvTemp.SelectedSubItemIndex;
                        }

                        lblTemp.Visible = true;
                        cdvTemp.Visible = true;

                        if (out_node.GetList(0)[i].GetString("TABLE_NAME") != "")
                        {
                            if (cdvTemp.DisplaySubItemIndex != cdvTemp.SelectedSubItemIndex)
                            {
                                BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', out_node.GetList(0)[i].GetString("TABLE_NAME"));
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


        // ProcGRPCMFButtonPress()
        //       - Process Group/Cmf CodeView Button Press Event
        // Return Value
        //       -
        // Arguments
        //       - ByVal sender As Object    : Occur ButtonPress Event CodeView
        //
        public static void ProcGRPCMFButtonPress(object sender)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            string sTableName;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            if (MPCF.Trim(cdvTemp.Tag) != "")
            {
                sTableName = MPCF.Trim(cdvTemp.Tag);
                sTableName = sTableName.Substring(1, sTableName.Length - 1);
                BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', sTableName);

                if (cdvTemp.AllowDrop == true)
                {
                    cdvTemp.InsertEmptyRow(0, 1);
                }
            }

        }

        // CheckCMFKeyPress()
        //       - Check Cmf CodeView Key Press Event
        // Return Value
        //       -
        // Arguments
        //       - ByVal sender As Object    : Occur KeyPress Event CodeView
        //       - ByVal e As System.Windows.Forms.KeyPressEventArgs : KeyPress Event Argument
        public static void CheckCMFKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            char cFormat;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if ((MPCF.Trim(cdvTemp.Tag) != ""))
            {
                cFormat = MPCF.Trim(cdvTemp.Tag)[0];
                if (cFormat == 'N' || cFormat == 'F')
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (!(e.KeyChar == (char)43 || e.KeyChar == (char)45 || e.KeyChar == (char)8))
                        {
                            if (cFormat == 'F')
                            {
                                if (!(e.KeyChar == (char)46))
                                {
                                    e.Handled = true;
                                }
                            }
                            else
                            {
                                e.Handled = true;
                            }
                        }
                    }
                }
            }

        }

        // CheckGRPCMFValue()
        //       - Check Group/Cmf Value
        // Return Value
        //       -
        // Arguments
        //       - ByVal sLabelName As String    : Label Control Name
        //       - ByVal sCodeViewName As String : CodeView Control Name
        //       - ByVal parentControl As Control : Parent Control
        public static bool CheckGRPCMFValue(string sLabelName, string sCodeViewName, Control parentControl)
        {
            ArrayList lblList;
            ArrayList cdvList;
            Label lblTemp;
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            int i;

            try
            {
                lblList = MPCF.GetIndexedControl(sLabelName, parentControl);
                cdvList = MPCF.GetIndexedControl(sCodeViewName, parentControl);

                for (i = 0; i <= lblList.Count - 1; i++)
                {
                    lblTemp = (Label)lblList[i];

                    //Modify by J.S. 2009.01.07 cmf¿« font¿« bold∏¶ √ ±‚»≠ «œ¡ˆ æ æ∆º≠ º≥¡§¿Ã æ¯¿Ωø°µµ ∫“±∏«œ∞Ì checkµ«¥¬ ∞ÊøÏ ¿÷¿Ω
                    if (lblTemp.Font.Bold == true && MPCF.Trim(lblTemp.Text) != "")
                    {
                        cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)cdvList[i];

                        if (MPCF.Trim(cdvTemp.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108) + " [" + lblTemp.Text + "]");
                            cdvTemp.Focus();
                            return false;
                        }

                        if (MPCF.Trim(cdvTemp.Tag)[0] != 'A')
                        {
                            if (MPCF.CheckNumeric(cdvTemp.Text) == false)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(110) + " [" + lblTemp.Text + "]");
                                cdvTemp.Focus();
                                return false;
                            }
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

        public static bool ClearLotSpread(FarPoint.Win.Spread.FpSpread spdLotInfo)
        {

            spdLotInfo.ActiveSheet.Cells[0, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[1, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[2, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[3, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[4, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[5, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[6, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[7, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[8, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[9, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[10, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[11, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[12, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[13, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[14, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[15, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[16, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[17, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[18, 1].Text = "";

            spdLotInfo.ActiveSheet.Cells[0, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[1, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[2, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[3, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[4, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[5, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[6, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[7, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[8, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[9, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[10, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[11, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[12, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[13, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[14, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[15, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[16, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[17, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[18, 3].Text = "";

            spdLotInfo.ActiveSheet.Cells[0, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[1, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[2, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[3, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[4, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[5, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[6, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[7, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[8, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[9, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[10, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[11, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[12, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[13, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[14, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[15, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[16, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[17, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[18, 5].Text = "";

            return true;

        }

        public static bool ClearSubLotSpread(FarPoint.Win.Spread.FpSpread spdLotInfo)
        {

            spdLotInfo.ActiveSheet.Cells[0, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[1, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[2, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[3, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[4, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[5, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[6, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[7, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[8, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[9, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[10, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[11, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[12, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[13, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[14, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[15, 1].Text = "";
            spdLotInfo.ActiveSheet.Cells[16, 1].Text = "";

            spdLotInfo.ActiveSheet.Cells[0, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[1, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[2, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[3, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[4, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[5, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[6, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[7, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[8, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[9, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[10, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[11, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[12, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[13, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[14, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[15, 3].Text = "";
            spdLotInfo.ActiveSheet.Cells[16, 3].Text = "";

            spdLotInfo.ActiveSheet.Cells[0, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[1, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[2, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[3, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[4, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[5, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[6, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[7, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[8, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[9, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[10, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[11, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[12, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[13, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[14, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[15, 5].Text = "";
            spdLotInfo.ActiveSheet.Cells[16, 5].Text = "";

            return true;

        }

        public static void ChangeControlEnabled(Form frm, Control ctrl, bool enabled)
        {
            try
            {
                ArrayList disabled_controls;
                MemberInfo[] members = frm.GetType().GetMember("DisabledFormControls", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                disabled_controls = null;
                if (members.Length > 0)
                {
                    disabled_controls = (ArrayList)(frm.GetType().InvokeMember("DisabledFormControls", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, frm, null));
                }

                if (disabled_controls == null || disabled_controls.Count < 1)
                {
                    ctrl.Enabled = enabled;
                    return;
                }

                if (disabled_controls.Contains(ctrl.Name) == true)
                {
                    ctrl.Enabled = false;
                }
                else
                {
                    ctrl.Enabled = enabled;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("MPCR.ChangeControlEnabled() : " + ex.Message);
            }
        }

        // ¿Ã «‘ºˆ¥¬ ChangeControlEnabled() «‘ºˆ∑Œ ¥Î√ºµ . ¿Ã¿¸ »£»Øº∫¿ª ¿ß«ÿ ≥≤∞‹¡¸.
        public static void CheckSecurityFormControlSub(Control ctrl, ArrayList DisabledFormControls, bool enabled)
        {
            try
            {
                if (DisabledFormControls == null || DisabledFormControls.Count < 1)
                {
                    ctrl.Enabled = enabled;
                    return;
                }

                if (DisabledFormControls.Contains(ctrl.Name) == true)
                {
                    ctrl.Enabled = false;
                }
                else
                {
                    ctrl.Enabled = enabled;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("MPCR.CheckSecurityFormControlSub() : " + ex.Message);
            }
        }

        //¡§¿«µ» πˆ≈œ¿ª enable,disableΩ√≈≤¥Ÿ
        private static void CheckSecurityFormControlSub(Control ctrl, string ctrlType, params FuncCtrlList[] ctrlList)
        {
            Control control;
            bool bFindControl;
            string ctrlValue = "";

            foreach (Control tempLoopVar_control in ctrl.Controls)
            {
                control = tempLoopVar_control;

                if (control is Panel || control is GroupBox || control is TabControl || control is TabPage || control is SplitContainer)
                {
                    CheckSecurityFormControlSub(control, ctrlType, ctrlList);
                }
                else
                {
                    bFindControl = false;
                    switch (ctrlType)
                    {
                        case "BUTTON":

                            if (!(control is Button))
                            {
                                goto NextControl;
                            }
                            break;
                        case "CHECK":

                            if (!(control is CheckBox))
                            {
                                goto NextControl;
                            }
                            break;
                        case "OPTION":

                            // Do nothing
                            break;

                    }

                    for (int i = 0; i < 10; i++)
                    {
                        if (ctrlList[i].ctrlName == null)
                            ctrlList[i].ctrlName = "";
                    }

                    if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[0].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[0].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[1].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[1].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[2].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[2].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[3].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[3].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[4].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[4].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[5].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[5].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[6].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[6].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[7].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[7].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[8].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[8].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[9].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[9].ctrlValue;
                    }

                    if (bFindControl == true)
                    {
                        switch (ctrlType)
                        {
                            case "BUTTON":

                                if (ctrlValue == "Y")
                                {
                                    //Loadø°º≠ √≥∏Æ «‘¿∏∑Œ Disableµ…∞Õ∏∏ √≥∏Æ«—¥Ÿ
                                    //control.Enabled = True
                                }
                                else
                                {
                                    control.Enabled = false;
                                }
                                break;
                            case "CHECK":

                                if (ctrlValue == "Y")
                                {
                                    //Loadø°º≠ √≥∏Æ «‘¿∏∑Œ Disableµ…∞Õ∏∏ √≥∏Æ«—¥Ÿ
                                    //control.Enabled = True
                                }
                                else
                                {
                                    control.Enabled = false;
                                }
                                break;

                            case "OPTION":

                                if (ctrlValue == "Y")
                                {
                                    control.Enabled = false;
                                }
                                break;

                        }
                    }
                }
            NextControl:
                1.GetHashCode(); //nop
            }

        }

        //Tabpage∏¶ enable,disable Ω√≈≤¥Ÿ
        private static void CheckSecurityFormControlTabpage(Control ctrl, params FuncCtrlList[] ctrlList)
        {
            Control control;
            bool bFindControl;
            string ctrlValue = "";


            foreach (Control tempLoopVar_control in ctrl.Controls)
            {
                control = tempLoopVar_control;

                if (!(control is TabPage))
                {
                    if (control is Panel || control is GroupBox || control is TabControl)
                    {

                        CheckSecurityFormControlTabpage(control, ctrlList);
                    }

                }
                else if (control is TabPage)
                {

                    for (int i = 0; i < 10; i++)
                    {
                        if (ctrlList[i].ctrlName == null)
                            ctrlList[i].ctrlName = "";
                    }

                    bFindControl = false;

                    if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[0].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[0].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[1].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[1].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[2].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[2].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[3].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[3].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[4].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[4].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[5].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[5].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[6].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[6].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[7].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[7].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[8].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[8].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[9].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[9].ctrlValue;
                    }

                    if (bFindControl == true)
                    {
                        if (ctrlValue == "Y")
                        {
                            CheckSecurityFormControlTabpageField(control);
                        }
                    }
                }
            }

        }

        //tabpageæ»ø° ∆˜«‘µ» ∏µÁ « µÂ∏¶ Disable«—¥Ÿ
        private static void CheckSecurityFormControlTabpageField(Control ctrl)
        {
            Control control;

            try
            {

                foreach (Control tempLoopVar_control in ctrl.Controls)
                {
                    control = tempLoopVar_control;

                    if (control is Panel || control is GroupBox || control is TabControl || control is TabPage)
                    {
                        CheckSecurityFormControlTabpageField(control);
                    }
                    else
                    {

                        if (control is TextBox || control is ComboBox || control is Miracom.UI.Controls.MCCodeView.MCCodeView ||
                            control is FarPoint.Win.Spread.FpSpread || control is CheckBox || control is Infragistics.Win.UltraWinEditors.UltraTextEditor ||
                            control is NumericUpDown || control is RadioButton || control is DateTimePicker || control is ListView ||
                            control is Button || control is TreeView)
                        {
                            control.Enabled = false;
                        }

                    }

                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(iFieldSeq + ":" + "ERROR" + ex.Message);

            }

        }


        //tabpageæ»ø° ∆˜«‘µ» ∏µÁ « µÂ∏¶ Disable«—¥Ÿ
        private static void CheckSecurityFormControlField(Control ctrl, string fld_en_mask)
        {
            Control control;
            bool bFindControl;
            string ctrlValue;
            try
            {

                foreach (Control tempLoopVar_control in ctrl.Controls)
                {
                    control = tempLoopVar_control;

                    if (control is Panel || control is GroupBox || control is TabControl || control is TabPage)
                    {
                        CheckSecurityFormControlField(control, fld_en_mask);
                    }
                    else
                    {
                        if (control.Enabled == true)
                        {

                            bFindControl = false;
                            if (control is TextBox || control is ComboBox || control is Miracom.UI.Controls.MCCodeView.MCCodeView ||
                                control is FarPoint.Win.Spread.FpSpread || control is CheckBox ||
                                control is Infragistics.Win.UltraWinEditors.UltraNumericEditor || control is NumericUpDown ||
                                control is RadioButton || control is DateTimePicker)
                            {
                                bFindControl = true;
                            }

                            if (control is TextBox)
                            {
                                if (((TextBox)control).ReadOnly == true)
                                {
                                    bFindControl = false;
                                }
                            }

                            if (control.Name.Length >= 6)
                            {
                                if (control.Name.Substring(0, 6).ToUpper() == "CDVCMF")
                                {
                                    bFindControl = false;
                                }
                            }

                            if (control.Name.Length >= 8)
                            {
                                if (control.Name.Substring(0, 8).ToUpper() == "CDVGROUP")
                                {
                                    bFindControl = false;
                                }
                            }

                            if (control.Name.Length >= 9)
                            {
                                if (control.Name.Substring(0, 9).ToUpper() == "CDVCRTCMF")
                                {
                                    bFindControl = false;
                                }
                            }

                            if (bFindControl == true)
                            {

                                if (string.IsNullOrEmpty(fld_en_mask) == false)
                                {
                                    ctrlValue = fld_en_mask.Substring(iFieldSeq - 1, 1);
                                    iFieldSeq++;
                                    if (ctrlValue == "N")
                                    {
                                        control.Enabled = false;
                                    }
                                }

                            }

                        }

                    }

                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(iFieldSeq + ":" + "ERROR" + ex.Message);

            }

        }

        // PublishMsgTune()
        //       - Publish Message Tune
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool PublishUTLMsgTune()
        {

            try
            {
#if _HTTP
                MPMH.registerDispatcher("UTL", new UTLTunerImpl());
#else
                string sPublishChannel = "";

                sPublishChannel = "/" + MPGV.gsSiteID;
                sPublishChannel += "/UTL";
                sPublishChannel += "/" + MPGV.gsFactory;
                sPublishChannel += "/" + MPGV.gsUserGroup;
                sPublishChannel += "/" + MPGV.gsUserID;

                MPMH.registerDispatcher("UTL", new UTLTunerImpl());
                if (true != MPMH.tune(sPublishChannel, true, false))
                {
                    MPCF.ShowMsgBox("Message Tuning " + MPMH.StatusMessage, "Message Tuning", MessageBoxButtons.OK, 1);
                    return false;
                }
#endif
            }
            catch (Exception)
            {
                MPCF.ShowMsgBox("PublishUTLMsgTune() Failed.");
                return false;
            }

            return true;

        }

        public static bool PublishUTLMsgUnTune()
        {

            try
            {
                string sPublishChannel;

                sPublishChannel = "/" + MPGV.gsSiteID;
                sPublishChannel += "/UTL";
                sPublishChannel += "/" + MPGV.gsFactory;
                sPublishChannel += "/" + MPGV.gsUserGroup;
                sPublishChannel += "/" + MPGV.gsUserID;

                MPMH.untune(sPublishChannel, true, false);
                MPMH.unregisterDispatcher("UTL");
            }
            catch (Exception)
            {
                MPCF.ShowMsgBox("PublishUTLMsgUnTune() Failed.");
                return false;
            }

            return true;

        }

        /* Added by DM KIM 2012.05.07 BBS Publish Message Tune Start */

        public static bool PublishBBSMsgTune()
        {

            try
            {
#if _HTTP
                MPMH.registerDispatcher("BAS", new BASTunerImpl());
#else
                string sPublishChannel;

                sPublishChannel = "/" + MPGV.gsSiteID;
                sPublishChannel += "/BAS";
                sPublishChannel += "/" + MPGV.gsFactory;
                sPublishChannel += "/" + MPGV.gsUserID;

                MPMH.registerDispatcher("BAS", new BASTunerImpl());
                if (true != MPMH.tune(sPublishChannel, true, false))
                {
                    MPCF.ShowMsgBox("Message Tuning " + MPMH.StatusMessage, "Message Tuning", MessageBoxButtons.OK, 1);
                    return false;
                }
#endif
            }
            catch (Exception)
            {
                MPCF.ShowMsgBox("PublishBBSMsgTune() Failed.");
                return false;
            }

            return true;

        }

        public static bool PublishBASMsgUnTune()
        {

            try
            {
                string sPublishChannel;

                sPublishChannel = "/" + MPGV.gsSiteID;
                sPublishChannel += "/BAS";
                sPublishChannel += "/" + MPGV.gsFactory;
                sPublishChannel += "/" + MPGV.gsUserID;

                MPMH.untune(sPublishChannel, true, false);
                MPMH.unregisterDispatcher("BAS");
            }
            catch (Exception)
            {
                MPCF.ShowMsgBox("PublishBASMsgUnTune() Failed.");
                return false;
            }

            return true;

        }

        /* Added by DM KIM 2012.05.07 BBS Publish Message Tune End */

        public static void SetNumberCell(FarPoint.Win.Spread.Cell cell)
        {
            //Localization ¡ˆø¯ µ«¡ˆ æ ¿Ω
            //FarPoint.Win.Spread.CellType.NumberCellType typeNumber = new FarPoint.Win.Spread.CellType.NumberCellType();

            try
            {
                /*
                typeNumber.DecimalPlaces = 10;
                typeNumber.FixedPoint = false;
                typeNumber.MaximumValue = 9999999999;
                typeNumber.MinimumValue = - 9999999999;
                typeNumber.Separator = ",";
                typeNumber.ShowSeparator = true;
                
                cell.CellType = typeNumber;
                 */

                cell.HorizontalAlignment = CellHorizontalAlignment.Right;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        public static void SetNumberCell(FarPoint.Win.Spread.Column column)
        {
            //Localization ¡ˆø¯ µ«¡ˆ æ ¿Ω
            //FarPoint.Win.Spread.CellType.NumberCellType typeNumber = new FarPoint.Win.Spread.CellType.NumberCellType();

            try
            {
                /*
                typeNumber.DecimalPlaces = 10;
                typeNumber.FixedPoint = false;
                typeNumber.MaximumValue = 9999999999;
                typeNumber.MinimumValue = - 9999999999;
                typeNumber.Separator = ",";
                typeNumber.ShowSeparator = true;
                
                column.CellType = typeNumber;
                 */
                column.HorizontalAlignment = CellHorizontalAlignment.Right;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        public static void SetAsciiCell(FarPoint.Win.Spread.Cell cell)
        {

            //FarPoint.Win.Spread.CellType.TextCellType typeAscii = new FarPoint.Win.Spread.CellType.TextCellType();

            try
            {
                //cell.CellType = typeAscii;
                cell.HorizontalAlignment = CellHorizontalAlignment.Left;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        public static void SetAsciiCell(FarPoint.Win.Spread.Column column)
        {

            //FarPoint.Win.Spread.CellType.TextCellType typeAscii = new FarPoint.Win.Spread.CellType.TextCellType();

            try
            {
                //column.CellType = typeAscii;
                column.HorizontalAlignment = CellHorizontalAlignment.Left;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        #region "BAS Module"

        // Client_Upgrade()
        //       - Client Upgrade
        // Return Value
        //       - Integer : -1 - Occur error
        //                   0  - Server version same Client version
        //                   1  - Client Upgrade
        // Arguments
        //       -
        //
        public static int Client_Upgrade(int iStep)
        {

            TRSNode in_node = new TRSNode("CHECK_VERSION_IN");
            TRSNode out_node = new TRSNode("CHECK_VERSION_OUT");
            FileVersionInfo UpgradeExe;
            string UpgradeVersion;

            try
            {
                if (MPIF.gInit.IsAvailableSendMessage == false) return 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", Application.ProductName);

                // Retern Value : -1 -> Occur error
                //                 0 -> version same
                //                 1 -> Client upgrade


                // Server ∞° ¡◊æÓ¿÷¥¬ ∞ÊøÏ ¡÷±‚¿˚¿∏∑Œ Version ¿ª √º≈©«œ∏È "Notfound Replier" ∏ﬁΩ√¡ˆ∏¶ »≠∏Èø° ∞Ëº” √‚∑¬«‘.
                // ±◊∑°º≠ æ∆∑°øÕ ∞∞¿Ã ∫Ø∞Ê«‘.
                //if (MPCR.CallService("BAS", "BAS_Check_Version", in_node, ref out_node) == false)
                //{
                //    return -1;
                //}
                if (MessageCaster.CallService("BAS", "BAS_Check_Version", in_node, ref out_node) == false)
                {
                    return -1;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCR.CheckContinueProc(out_node);
                    return -1;
                }

                MPGV.gsServerVersion = out_node.GetString("SERVER_VERSION");

                // iStep = 1 : Î≤ÑÏ†Ñcheck ???¢ÊÎ¶¨Î©¥?ÖÍ∑∏?àÏù¥??
                // iStep = 2 : Î≤ÑÏ†Ñ???ÅÍ??ÜÏù¥?ÖÍ∑∏?àÏù¥??
                if (iStep == 1 && MPGV.gsServerVersion == MPGV.gsClientVersion)
                {
                    return 0;
                }

                if (iStep == 1)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(9), MessageBoxButtons.YesNo, 1) == DialogResult.No)
                    {
                        return 0;
                    }
                }


                //Add by J.S. 2013.06.19 MSG∏¶ ¿ÃøÎ«— upgradeπÊπ˝ √ﬂ∞°
                if (out_node.GetString("UPGRADE_METHOD") == "MSG")
                {
                    MPGV.gsUpgradeFile = "MESplusUpgradeMsg.exe";
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile) == true)
                    {
                        UpgradeExe = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                        UpgradeVersion = UpgradeExe.FileVersion;
                    }
                    else
                    {
                        UpgradeVersion = "0.0.0.0";
                    }

                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old") == true)
                    {
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old");
                    }

                    if (UpgradeVersion == "0.0.0.0")
                    {
                    }
                    else if (UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old", true);
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                    }


                    if (UpgradeVersion == "0.0.0.0" ||
                        UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        TRSNode min_node = new TRSNode("UPGRADE_MSG_IN");
                        TRSNode mout_node = new TRSNode("UPGRADE_MSG_OUT");

                        MPCR.SetInMsg(min_node);
                        min_node.ProcStep = '1';

                        min_node.AddString("FILE_NAME", MPGV.gsUpgradeFile);

                        if (MPCR.CallService("BAS", "BAS_Upgrade_Msg", min_node, ref mout_node, DeliveryMode.RReply, true) == false)
                        {
                            if (out_node.GetString("MSG").Trim() != "")
                            {
                                MessageBox.Show(out_node.GetString("MSG"));
                            }
                            return -1;
                        }

                        //Save File
                        FileStream fs = File.Open(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(fs);
                        byte[] buffer;

                        fs.Flush();
                        buffer = mout_node.GetBlob(MPGC.MP_BIN_DATA_2);
                        bw.Write(buffer);

                        bw.Close();
                        fs.Close();
                    }

                    //upgradeøÎ sub folder∏¶ ª˝º∫«œ∞Ì « ø‰∆ƒ¿œ¿ª ∫πªÁ«—¥Ÿ.
                    String upgradePath = Application.StartupPath + "\\_upgrade";
                    if (Directory.Exists(upgradePath) == false)
                    {
                        Directory.CreateDirectory(upgradePath);
                    }

                    File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, upgradePath + "\\" + MPGV.gsUpgradeFile, true);
                    File.Copy(Application.StartupPath + "\\" + "ICSharpCode.SharpZipLib.dll", upgradePath + "\\" + "ICSharpCode.SharpZipLib.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.CliFrx.dll", upgradePath + "\\" + "Miracom.CliFrx.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.MESCore.dll", upgradePath + "\\" + "Miracom.MESCore.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.MsgHandler.dll", upgradePath + "\\" + "Miracom.MsgHandler.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSConvertor.dll", upgradePath + "\\" + "Miracom.TRSConvertor.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSCore.dll", upgradePath + "\\" + "Miracom.TRSCore.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.UI.dll", upgradePath + "\\" + "Miracom.UI.dll", true);
                    
                    if (MPIF.gInit.getMiddleware == "H101")
                    {
                    	File.Copy(Application.StartupPath + "\\" + "transceiverxnet.dll", upgradePath + "\\" + "transceiverxnet.dll", true);
                    }
                    // Add by DM KIM 2013.08.28 Tibrv∑Œ ¡¢º”«“ ∞ÊøÏø°µµ MES Upgrade∞° ∞°¥…«œµµ∑œ ºˆ¡§
                    else if (MPIF.gInit.getMiddleware == "TIBRV")
                    {
                        File.Copy(Application.StartupPath + "\\" + "TIBCO.Rendezvous.dll", upgradePath + "\\" + "TIBCO.Rendezvous.dll", true);
                        File.Copy(Application.StartupPath + "\\" + "tibrv.dll", upgradePath + "\\" + "tibrv.dll", true);
                    }


                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    StartInfo.FileName = Application.StartupPath + "\\_upgrade"+ "\\" + MPGV.gsUpgradeFile;
                    StartInfo.Arguments = MPGV.gsRemoteAddress + " " + MPGV.gsSiteID + " " + MPGV.gsDownloadFileList + " " + MPGV.gsRvService + " " + MPGV.gsRvNetwork;

                    System.Diagnostics.Process.Start(StartInfo);
                }
                else
                {
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile) == true)
                    {
                        UpgradeExe = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                        UpgradeVersion = UpgradeExe.FileVersion;
                    }
                    else
                    {
                        UpgradeVersion = "0.0.0.0";
                    }

                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old") == true)
                    {
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old");
                    }

                    if (UpgradeVersion == "0.0.0.0")
                    {
                        PTSFTPClient ptsftp = new PTSFTPClient();
                        ptsftp.FtpServerIP = out_node.GetString("UPGRADE_ADDRESS");
                        ptsftp.FtpUserID = out_node.GetString("UPGRADE_USER_ID");
                        ptsftp.FtpPassword = out_node.GetString("UPGRADE_PASSWORD");

                        string remoteUrl = "ftp://" + ptsftp.FtpServerIP + "/" + out_node.GetString("UPGRADE_DIRECTORY") + "/" + MPGV.gsUpgradeFile;
                        string localUrl = Application.StartupPath + "\\" + MPGV.gsUpgradeFile;

                        ptsftp.DownLoad(remoteUrl, localUrl);
                    }
                    else if (UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old", true);
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);

                        //√ ±‚»≠
                        PTSFTPClient ptsftp = new PTSFTPClient();
                        ptsftp.FtpServerIP = out_node.GetString("UPGRADE_ADDRESS");
                        ptsftp.FtpUserID = out_node.GetString("UPGRADE_USER_ID");
                        ptsftp.FtpPassword = out_node.GetString("UPGRADE_PASSWORD");

                        string remoteUrl = "ftp://" + ptsftp.FtpServerIP + "/" + out_node.GetString("UPGRADE_DIRECTORY") + "/" + MPGV.gsUpgradeFile;
                        string localUrl = Application.StartupPath + "\\" + MPGV.gsUpgradeFile;

                        ptsftp.DownLoad(remoteUrl, localUrl);
                    }

                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    StartInfo.FileName = Application.StartupPath + "\\" + MPGV.gsUpgradeFile;
                    StartInfo.Arguments = out_node.GetString("UPGRADE_ADDRESS") + " " + out_node.GetString("UPGRADE_USER_ID") + " " +
                                          out_node.GetString("UPGRADE_PASSWORD") + " " + out_node.GetString("UPGRADE_DIRECTORY") + " " + MPGV.gsDownloadFileList;

                    System.Diagnostics.Process.Start(StartInfo);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return -1;
            }

            return 1;
        }


        // CheckGCMDataExist()
        //       - Client Upgrade
        // Return Value
        //       - Integer : -1 - Occur error
        //                   0  - Server version same Client version
        //                   1  - Client Upgrade
        // Arguments
        //       -
        //
        public static bool CheckGCMDataExist(string TableName, string Key_1)
        {
            return CheckGCMDataExist(TableName, Key_1, "");
        }
        public static bool CheckGCMDataExist(string TableName, string Key_1, string Key_2)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", TableName);
                in_node.AddString("KEY_1", Key_1);
                in_node.AddString("KEY_2", Key_2);

                if (MPCR.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
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

        #endregion

        #region "SEC Module"

        public struct FuncCtrlList
        {
            public string ctrlName;
            public string ctrlValue;
        }

        public static bool CheckSecurityFormControl(Form frm)
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_DETAIL_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_DETAIL_OUT");
            FuncCtrlList[] CtrlList = new FuncCtrlList[10];

            try
            {

                if (MPCF.Trim(frm.Tag) == "")
                {
                    return true;
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("FUNC_NAME", MPCF.Trim(frm.Tag));

                if (MPCR.CallService("SEC", "SEC_View_Function_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                CtrlList[0].ctrlName = out_node.GetString("CTL_NAME_1");
                CtrlList[0].ctrlValue = out_node.GetChar("CTL_EN_FLAG_1").ToString();
                CtrlList[1].ctrlName = out_node.GetString("CTL_NAME_2");
                CtrlList[1].ctrlValue = out_node.GetChar("CTL_EN_FLAG_2").ToString();
                CtrlList[2].ctrlName = out_node.GetString("CTL_NAME_3");
                CtrlList[2].ctrlValue = out_node.GetChar("CTL_EN_FLAG_3").ToString();
                CtrlList[3].ctrlName = out_node.GetString("CTL_NAME_4");
                CtrlList[3].ctrlValue = out_node.GetChar("CTL_EN_FLAG_4").ToString();
                CtrlList[4].ctrlName = out_node.GetString("CTL_NAME_5");
                CtrlList[4].ctrlValue = out_node.GetChar("CTL_EN_FLAG_5").ToString();
                CtrlList[5].ctrlName = out_node.GetString("CTL_NAME_6");
                CtrlList[5].ctrlValue = out_node.GetChar("CTL_EN_FLAG_6").ToString();
                CtrlList[6].ctrlName = out_node.GetString("CTL_NAME_7");
                CtrlList[6].ctrlValue = out_node.GetChar("CTL_EN_FLAG_7").ToString();
                CtrlList[7].ctrlName = out_node.GetString("CTL_NAME_8");
                CtrlList[7].ctrlValue = out_node.GetChar("CTL_EN_FLAG_8").ToString();
                CtrlList[8].ctrlName = out_node.GetString("CTL_NAME_9");
                CtrlList[8].ctrlValue = out_node.GetChar("CTL_EN_FLAG_9").ToString();
                CtrlList[9].ctrlName = out_node.GetString("CTL_NAME_10");
                CtrlList[9].ctrlValue = out_node.GetChar("CTL_EN_FLAG_10").ToString();
                CheckSecurityFormControlSub(frm, "BUTTON", CtrlList);
                CheckSecurityFormControlSub(frm, "CHECK", CtrlList);

                CtrlList[0].ctrlName = out_node.GetString("TAB_NAME_1");
                CtrlList[0].ctrlValue = out_node.GetChar("TAB_DS_FLAG_1").ToString();
                CtrlList[1].ctrlName = out_node.GetString("TAB_NAME_2");
                CtrlList[1].ctrlValue = out_node.GetChar("TAB_DS_FLAG_2").ToString();
                CtrlList[2].ctrlName = out_node.GetString("TAB_NAME_3");
                CtrlList[2].ctrlValue = out_node.GetChar("TAB_DS_FLAG_3").ToString();
                CtrlList[3].ctrlName = out_node.GetString("TAB_NAME_4");
                CtrlList[3].ctrlValue = out_node.GetChar("TAB_DS_FLAG_4").ToString();
                CtrlList[4].ctrlName = out_node.GetString("TAB_NAME_5");
                CtrlList[4].ctrlValue = out_node.GetChar("TAB_DS_FLAG_5").ToString();
                CtrlList[5].ctrlName = out_node.GetString("TAB_NAME_6");
                CtrlList[5].ctrlValue = out_node.GetChar("TAB_DS_FLAG_6").ToString();
                CtrlList[6].ctrlName = out_node.GetString("TAB_NAME_7");
                CtrlList[6].ctrlValue = out_node.GetChar("TAB_DS_FLAG_7").ToString();
                CtrlList[7].ctrlName = out_node.GetString("TAB_NAME_8");
                CtrlList[7].ctrlValue = out_node.GetChar("TAB_DS_FLAG_8").ToString();
                CtrlList[8].ctrlName = out_node.GetString("TAB_NAME_9");
                CtrlList[8].ctrlValue = out_node.GetChar("TAB_DS_FLAG_9").ToString();
                CtrlList[9].ctrlName = out_node.GetString("TAB_NAME_10");
                CtrlList[9].ctrlValue = out_node.GetChar("TAB_DS_FLAG_10").ToString();
                CheckSecurityFormControlTabpage(frm, CtrlList);

                CtrlList[0].ctrlName = out_node.GetString("OPT_NAME_1");
                CtrlList[0].ctrlValue = out_node.GetString("OPT_VALUE_1");
                CtrlList[1].ctrlName = out_node.GetString("OPT_NAME_2");
                CtrlList[1].ctrlValue = out_node.GetString("OPT_VALUE_2");
                CtrlList[2].ctrlName = out_node.GetString("OPT_NAME_3");
                CtrlList[2].ctrlValue = out_node.GetString("OPT_VALUE_3");
                CtrlList[3].ctrlName = out_node.GetString("OPT_NAME_4");
                CtrlList[3].ctrlValue = out_node.GetString("OPT_VALUE_4");
                CtrlList[4].ctrlName = out_node.GetString("OPT_NAME_5");
                CtrlList[4].ctrlValue = out_node.GetString("OPT_VALUE_5");
                CtrlList[5].ctrlName = out_node.GetString("OPT_NAME_6");
                CtrlList[5].ctrlValue = out_node.GetString("OPT_VALUE_6");
                CtrlList[6].ctrlName = out_node.GetString("OPT_NAME_7");
                CtrlList[6].ctrlValue = out_node.GetString("OPT_VALUE_7");
                CtrlList[7].ctrlName = out_node.GetString("OPT_NAME_8");
                CtrlList[7].ctrlValue = out_node.GetString("OPT_VALUE_8");
                CtrlList[8].ctrlName = out_node.GetString("OPT_NAME_9");
                CtrlList[8].ctrlValue = out_node.GetString("OPT_VALUE_9");
                CtrlList[9].ctrlName = out_node.GetString("OPT_NAME_10");
                CtrlList[9].ctrlValue = out_node.GetString("OPT_VALUE_10");
                CheckSecurityFormControlSub(frm, "OPTION", CtrlList);

                //Delete by ICBAE 2012.06.08 - Field Mask ±‚¥… ªË¡¶
                //∏∏æ‡« µÂƒ¡∆Æ∑—«œ∞Ì∏µÁ« µÂªÁøÎ¿Ãæ∆¥œ∏È« µÂƒ¡∆Æ∑—∑Á∆æ¿∏∑ŒµÈæÓ∞£¥Ÿ.
                //if (out_node.GetChar("FLD_EN_MASK_USE_FLAG") == 'Y' && out_node.GetChar("FLD_EN_ALL_FLAG") == ' ')
                //{
                //    iFieldSeq = 1;
                //    CheckSecurityFormControlField(frm, out_node.GetString("FLD_EN_MASK"));
                //}

                SetDisableFormControls(frm, out_node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        // ¿Ã¿¸ º“Ω∫øÕ¿« »£»Øº∫¿ª ¿ß«ÿ ≥≤∞‹µ“.
        public static bool CheckSecurityFormControl(Form frm, ref ArrayList DisabledFormControls)
        {
            ArrayList disabled_controls;
            MemberInfo[] members = frm.GetType().GetMember("DisabledFormControls", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (members.Length > 0)
            {
                disabled_controls = (ArrayList)(frm.GetType().InvokeMember("DisabledFormControls", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, frm, null));

                if (disabled_controls != null)
                {
                    if (disabled_controls == DisabledFormControls)
                    {
                        return true;
                    }
                    else if (DisabledFormControls == null)
                    {
                        DisabledFormControls = new ArrayList();
                        for (int i = 0; i < disabled_controls.Count; i++)
                        {
                            DisabledFormControls.Add(disabled_controls[i].ToString());
                        }
                    }
                    else if (DisabledFormControls.Count < 1)
                    {
                        for (int i = 0; i < disabled_controls.Count; i++)
                        {
                            DisabledFormControls.Add(disabled_controls[i].ToString());
                        }
                    }
                    else
                    {
                        DisabledFormControls.Clear();
                        for (int i = 0; i < disabled_controls.Count; i++)
                        {
                            DisabledFormControls.Add(disabled_controls[i].ToString());
                        }
                    }

                    return true;
                }
            }

            TRSNode in_node = new TRSNode("VIEW_FUNCTION_DETAIL_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_DETAIL_OUT");
            FuncCtrlList[] CtrlList = new FuncCtrlList[10];

            try
            {

                if (MPCF.Trim(frm.Tag) == "")
                {
                    return true;
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("FUNC_NAME", MPCF.Trim(frm.Tag));

                if (MPCR.CallService("SEC", "SEC_View_Function_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (DisabledFormControls == null)
                {
                    DisabledFormControls = new ArrayList();
                }

                DisabledFormControls.Clear();

                for (int i = 1; i <= 10; i++)
                {
                    if (out_node.GetChar("CTL_EN_FLAG_" + i.ToString()) != 'Y')
                    {
                        DisabledFormControls.Add(out_node.GetString("CTL_NAME_" + i.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private static void SetDisableFormControls(Form frm, TRSNode out_node)
        {
            ArrayList disabled_controls;
            MemberInfo[] members = frm.GetType().GetMember("DisabledFormControls", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (members.Length < 1) return;

            disabled_controls = (ArrayList)(frm.GetType().InvokeMember("DisabledFormControls", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, frm, null));

            if (disabled_controls != null)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (out_node.GetChar("CTL_EN_FLAG_" + i.ToString()) != 'Y')
                    {
                        disabled_controls.Add(out_node.GetString("CTL_NAME_" + i.ToString()));
                    }
                }
            }
        }

        public static bool GetHelpURL()
        {
            TRSNode in_node = new TRSNode("GET_HELPURL_IN");
            TRSNode out_node = new TRSNode("GET_HELPURL_OUT");
            ProcessStartInfo StartInfo;

            try
            {
                StartInfo = new ProcessStartInfo();
                StartInfo.FileName = "explorer.exe";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPGV.gfrmMDI.ActiveMdiChild == null)
                {
                    StartInfo.Arguments = MPGV.gsHelpURL + MPGV.gsDefaultHelpURL + "/index.html";
                    System.Diagnostics.Process.Start(StartInfo);

                    return false;
                }

                in_node.AddString("FUNC_NAME", MPCF.Trim(MPGV.gfrmMDI.ActiveMdiChild.Tag));

                if (MPCR.CallService("SEC", "SEC_Get_HelpURL", in_node, ref out_node) == false)
                {
                    return false;
                }
                else
                {
                    StartInfo.Arguments = MPGV.gsHelpURL + out_node.GetString("HELP_URL");
                    System.Diagnostics.Process.Start(StartInfo);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }



        //
        // SEC_Login()
        //       - Login Check Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool SEC_Login(ref bool UpgradeFlag)
        {
            TRSNode in_node = new TRSNode("LOGIN_IN");
            TRSNode out_node = new TRSNode("LOGIN_OUT");

            try
            {
                UpgradeFlag = false;
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //Modify by J.S. 2006/04/13
                //Upgrade???¥Í≤É?ºÎ°úClient??Ï¢ÖÎ•òÎ•?Íµ¨Î∂Ñ?úÎã§.
                in_node.AddString("PROGRAM_ID", Application.ProductName);

                if (MPCR.CallService("SEC", "SEC_Login", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPGV.gsUserGroup = out_node.GetString("SEC_GRP_ID");
                if (out_node.GetChar("AUTO_UPGRADE_FLAG") == '2')
                {
                    MPGV.gcAutoUpgrade = '2';
                }
                else if (out_node.GetChar("AUTO_UPGRADE_FLAG") == '3')
                {
                    MPGV.gcAutoUpgrade = '3';
                }
                else
                {
                    MPGV.gcAutoUpgrade = '1';
                }

                if (out_node.GetChar("USE_SAMLL_LETTER_FLAG") == 'Y')
                {
                    MPGV.gbUseSmallLetter = true;
                }
                else
                {
                    MPGV.gbUseSmallLetter = false;
                }

                MPGV.gsServerVersion = out_node.GetString("SERVER_VERSION");

                if (MPGV.gsServerVersion == MPGV.gsClientVersion)
                {
                    return true;
                }
                else
                {
                    if (MPGV.gcAutoUpgrade == '1')
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(9), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                        {
                            return true;
                        }
                    }
                    else if (MPGV.gcAutoUpgrade == '2')
                    {

                    }
                    else if (MPGV.gcAutoUpgrade == '3')
                    {
                        return true;
                    }
                }

                if (Client_Upgrade(2) != 1) return false;

                UpgradeFlag = true;
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }


        }

        public static bool SEC_Login_Ext(ref bool UpgradeFlag)
        {

            TRSNode in_node = new TRSNode("LOGIN_EXT_IN");
            TRSNode out_node = new TRSNode("LOGIN_EXT_OUT");

            try
            {
                UpgradeFlag = false;
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //Modify by J.S. 2006/04/13
                //Upgrade???¥Í≤É?ºÎ°úClient??Ï¢ÖÎ•òÎ•?Íµ¨Î∂Ñ?úÎã§.
                in_node.AddString("PROGRAM_ID", Application.ProductName);

                if (MPCR.CallService("SEC", "SEC_Login_Ext", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPGV.gsUserGroup = out_node.GetString("SEC_GRP_ID");
                if (out_node.GetChar("AUTO_UPGRADE_FLAG") == '2')
                {
                    MPGV.gcAutoUpgrade = '2';
                }
                else if (out_node.GetChar("AUTO_UPGRADE_FLAG") == '3')
                {
                    MPGV.gcAutoUpgrade = '3';
                }
                else
                {
                    MPGV.gcAutoUpgrade = '1';
                }

                if (out_node.GetChar("USE_SAMLL_LETTER_FLAG") == 'Y')
                {
                    MPGV.gbUseSmallLetter = true;
                }
                else
                {
                    MPGV.gbUseSmallLetter = false;
                }

                /* 2009.12.11. Aiden. TRSNode ¿« Member Name ¿ª ∫Ò±≥«“ ∞ÊøÏ ¥Î/º“πÆ¿⁄∏¶ ±∏∫–«“ ¡ˆ ø©∫Œ∏¶ º≥¡§ */
                if (out_node.GetChar("CASE_SENSITIVE_FLAG") == 'Y')
                {
                    TRSNodeTool.IsCaseSensitiveName = true;
                }
                else
                {
                    TRSNodeTool.IsCaseSensitiveName = false;
                }

                MPGV.gcChangePassword = out_node.GetChar("PASSWORD_CHANGE_FLAG");
                MPGV.gsServerVersion = out_node.GetString("SERVER_VERSION");

#if _HTTP
                // Add by IC.Bae 2012.06.29 for MESplusV6 push service
                if (out_node.GetString("MESSAGING_LOCATION") != "")
                {
                    int i = 0;

                    // Cometd Server Location
                    MPGV.gsMessagingLocation = out_node.GetString("MESSAGING_LOCATION");

                    // Alarm push service channel
                    TRSNode list = out_node.GetArray("ALM_CHANNELS");
                    if (list != null)
                    {
                        for (i = 0; i < list.MemberCount; i++)
                        {
                            MPGV.gaALMChannel.Add(list.GetString(i.ToString()));
                        }
                    }
                    // Util push service channel
                    list = out_node.GetArray("UTL_CHANNELS");
                    if (list != null)
                    {
                        for (i = 0; i < list.MemberCount; i++)
                        {
                            MPGV.gaUTLChannel.Add(list.GetString(i.ToString()));
                        }
                    }
                }

                MPGV.gsChannelPrefix = out_node.GetString("SITE_ID");
#endif

                if (MPGV.gsServerVersion == MPGV.gsClientVersion)
                {
                    return true;
                }
                else
                {
                    if (MPGV.gcAutoUpgrade == '1')
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(9), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                        {
                            return true;
                        }
                    }
                    else if (MPGV.gcAutoUpgrade == '2')
                    {

                    }
                    else if (MPGV.gcAutoUpgrade == '3')
                    {
                        return true;
                    }
                }

                if (Client_Upgrade(2) != 1) return false;

                UpgradeFlag = true;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }


        }



        #endregion

        #region "WIP Module"

        public static bool SetLotInfoSpread(FarPoint.Win.Spread.FpSpread spdLotInfo, string sLotID)
        {
            TRSNode out_node = null;
            return SetLotInfoSpread(spdLotInfo, sLotID, ref out_node);
        }

        public static bool SetLotInfoSpread(FarPoint.Win.Spread.FpSpread spdLotInfo, string sLotID, ref TRSNode lot_info)
        {
            return SetLotInfoSpread(spdLotInfo, '1', sLotID, ref lot_info);
        }

        public static bool SetLotInfoSpread(FarPoint.Win.Spread.FpSpread spdLotInfo, char cProcStep, string sLotID, ref TRSNode lot_info)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = cProcStep;
            in_node.AddString("LOT_ID", sLotID);

            if (ClearLotSpread(spdLotInfo) == false)
            {
                return false;
            }

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            lot_info = out_node;

            spdLotInfo.ActiveSheet.Cells[0, 1].Value = out_node.GetString("LOT_ID");
            spdLotInfo.ActiveSheet.Cells[0, 3].Value = out_node.GetString("MAT_ID") + " (" + out_node.GetInt("MAT_VER") + ") : " + out_node.GetString("MAT_DESC");
            spdLotInfo.ActiveSheet.Cells[0, 5].Value = out_node.GetString("FLOW") + " (" + out_node.GetInt("FLOW_SEQ_NUM") + ") : " + out_node.GetString("FLOW_DESC");

            spdLotInfo.ActiveSheet.Cells[1, 1].Value = out_node.GetString("OPER") + " : " + out_node.GetString("OPER_DESC");
            spdLotInfo.ActiveSheet.Cells[1, 3].Value = out_node.GetDouble("QTY_1") + "/" + out_node.GetDouble("QTY_2") + "/" + out_node.GetDouble("QTY_3");
            spdLotInfo.ActiveSheet.Cells[1, 5].Value = out_node.GetChar("LOT_TYPE");

            spdLotInfo.ActiveSheet.Cells[2, 1].Value = out_node.GetString("CREATE_CODE");
            spdLotInfo.ActiveSheet.Cells[2, 3].Value = out_node.GetString("OWNER_CODE");

            // 2006.05.24. CM Koo.
            // sch_due_time ??""??Í≤ΩÏö∞??Ï≤òÎ¶¨ Ï∂îÍ?
            if (out_node.GetString("SCH_DUE_TIME") == "" || out_node.GetString("SCH_DUE_TIME").Length < 8)
            {
                spdLotInfo.ActiveSheet.Cells[2, 5].Value = out_node.GetString("SCH_DUE_TIME");
            }
            else
            {
                spdLotInfo.ActiveSheet.Cells[2, 5].Value = MPCF.MakeDateFormat(out_node.GetString("SCH_DUE_TIME").Substring(0, 8), DATE_TIME_FORMAT.DATE);
            }

            spdLotInfo.ActiveSheet.Cells[3, 1].Value = out_node.GetString("LOT_STATUS");
            if (out_node.GetString("LOT_STATUS") == MPGC.MP_LOT_STATUS_WAIT)
            {
                spdLotInfo.ActiveSheet.Cells[3, 1].ForeColor = Color.Lime;
            }
            else if (out_node.GetString("LOT_STATUS") == MPGC.MP_LOT_STATUS_PROC)
            {
                spdLotInfo.ActiveSheet.Cells[3, 1].ForeColor = Color.Gold;
            }
            else
            {
                spdLotInfo.ActiveSheet.Cells[3, 1].ForeColor = Color.Black;
            }

            string sPriority;
            sPriority = "";
            switch (out_node.GetChar("LOT_PRIORITY"))
            {
                case '9':

                    sPriority = "HIGH";
                    spdLotInfo.ActiveSheet.Cells[3, 3].ForeColor = Color.Red;
                    break;
                case '8':
                    sPriority = "MID HIGH";
                    spdLotInfo.ActiveSheet.Cells[3, 3].ForeColor = Color.Gold;
                    break;

                case '7':
                    sPriority = "MID HIGH";
                    spdLotInfo.ActiveSheet.Cells[3, 3].ForeColor = Color.Gold;
                    break;

                case '6':

                    sPriority = "MID HIGH";
                    spdLotInfo.ActiveSheet.Cells[3, 3].ForeColor = Color.Gold;
                    break;
                case '5':

                    sPriority = "NORMAL";
                    //Add by J.S. 2008.12.22 for change to normal
                    spdLotInfo.ActiveSheet.Cells[3, 3].ForeColor = Color.Black;
                    break;
                case '4':
                    sPriority = "MID LOW";
                    spdLotInfo.ActiveSheet.Cells[3, 3].ForeColor = Color.GreenYellow;
                    break;

                case '3':
                    sPriority = "MID LOW";
                    spdLotInfo.ActiveSheet.Cells[3, 3].ForeColor = Color.GreenYellow;
                    break;

                case '2':

                    sPriority = "MID LOW";
                    spdLotInfo.ActiveSheet.Cells[3, 3].ForeColor = Color.GreenYellow;
                    break;
                case '1':

                    sPriority = "LOW";
                    spdLotInfo.ActiveSheet.Cells[3, 3].ForeColor = Color.Blue;
                    break;
            }
            spdLotInfo.ActiveSheet.Cells[3, 3].Value = sPriority + "(" + out_node.GetChar("LOT_PRIORITY") + ")";

            if (out_node.GetChar("HOLD_FLAG") != ' ')
            {
                spdLotInfo.ActiveSheet.Cells[3, 5].Value = out_node.GetChar("HOLD_FLAG") + " : " + out_node.GetString("HOLD_CODE");
            }

            spdLotInfo.ActiveSheet.Cells[4, 1].Value = out_node.GetChar("START_FLAG");
            spdLotInfo.ActiveSheet.Cells[4, 3].Value = out_node.GetChar("END_FLAG");
            if (out_node.GetChar("RWK_FLAG") != ' ')
            {
                spdLotInfo.ActiveSheet.Cells[4, 5].Value = out_node.GetChar("RWK_FLAG") + " : " + out_node.GetString("RWK_CODE");
            }

            spdLotInfo.ActiveSheet.Cells[5, 1].Value = out_node.GetChar("TRANSIT_FLAG");
            spdLotInfo.ActiveSheet.Cells[5, 5].Value = out_node.GetChar("NSTD_FLAG");
            spdLotInfo.ActiveSheet.Cells[5, 3].Value = out_node.GetChar("INV_FLAG");

            spdLotInfo.ActiveSheet.Cells[6, 1].Value = out_node.GetString("LAST_TRAN_CODE");
            spdLotInfo.ActiveSheet.Cells[6, 3].Value = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
            spdLotInfo.ActiveSheet.Cells[6, 5].Value = out_node.GetInt("LAST_HIST_SEQ");

            spdLotInfo.ActiveSheet.Cells[7, 1].Value = out_node.GetString("SHIP_CODE");
            spdLotInfo.ActiveSheet.Cells[7, 3].Value = MPCF.MakeDateFormat(out_node.GetString("SHIP_TIME"));
            spdLotInfo.ActiveSheet.Cells[7, 5].Value = out_node.GetChar("SAMPLE_FLAG");

            spdLotInfo.ActiveSheet.Cells[8, 1].Value = out_node.GetDouble("OPER_IN_QTY_1") + "/" + out_node.GetDouble("OPER_IN_QTY_2") + "/" + out_node.GetDouble("OPER_IN_QTY_3");
            spdLotInfo.ActiveSheet.Cells[8, 3].Value = out_node.GetDouble("CREATE_QTY_1") + "/" + out_node.GetDouble("CREATE_QTY_2") + "/" + out_node.GetDouble("CREATE_QTY_3");
            spdLotInfo.ActiveSheet.Cells[8, 5].Value = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));

            spdLotInfo.ActiveSheet.Cells[9, 1].Value = out_node.GetString("START_RES_ID");
            spdLotInfo.ActiveSheet.Cells[9, 3].Value = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));
            spdLotInfo.ActiveSheet.Cells[9, 5].Value = out_node.GetString("END_RES_ID");

            if (out_node.GetString("RWK_RET_FLOW") == "")
                spdLotInfo.ActiveSheet.Cells[10, 1].Value = "";
            else
                spdLotInfo.ActiveSheet.Cells[10, 1].Value = out_node.GetString("RWK_RET_FLOW") + "(" + out_node.GetInt("RWK_RET_FLOW_SEQ_NUM").ToString() + ")";

            spdLotInfo.ActiveSheet.Cells[10, 3].Value = out_node.GetString("RWK_RET_OPER");
            spdLotInfo.ActiveSheet.Cells[10, 5].Value = out_node.GetInt("RWK_COUNT").ToString();

            if (out_node.GetString("RWK_END_FLOW") == "")
                spdLotInfo.ActiveSheet.Cells[11, 1].Value = "";
            else
                spdLotInfo.ActiveSheet.Cells[11, 1].Value = out_node.GetString("RWK_END_FLOW") + "(" + out_node.GetInt("RWK_END_FLOW_SEQ_NUM").ToString() + ")";

            spdLotInfo.ActiveSheet.Cells[11, 3].Value = out_node.GetString("RWK_END_OPER");
            spdLotInfo.ActiveSheet.Cells[11, 5].Value = MPCF.MakeDateFormat(out_node.GetString("RWK_TIME"));

            if (out_node.GetString("NSTD_RET_FLOW") == "")
                spdLotInfo.ActiveSheet.Cells[12, 1].Value = "";
            else
                spdLotInfo.ActiveSheet.Cells[12, 1].Value = out_node.GetString("NSTD_RET_FLOW") + "(" + out_node.GetInt("NSTD_RET_FLOW_SEQ_NUM").ToString() + ")"; ;

            spdLotInfo.ActiveSheet.Cells[12, 3].Value = out_node.GetString("NSTD_RET_OPER");
            spdLotInfo.ActiveSheet.Cells[12, 5].Value = MPCF.MakeDateFormat(out_node.GetString("NSTD_TIME"));

            spdLotInfo.ActiveSheet.Cells[13, 1].Value = out_node.GetString("ORDER_ID");
            spdLotInfo.ActiveSheet.Cells[13, 3].Value = out_node.GetString("LOT_LOCATION");
            spdLotInfo.ActiveSheet.Cells[13, 5].Value = out_node.GetString("BATCH_ID");

            spdLotInfo.ActiveSheet.Cells[14, 1].Value = MPCF.MakeDateFormat(out_node.GetString("create_time"));
            spdLotInfo.ActiveSheet.Cells[14, 3].Value = MPCF.MakeDateFormat(out_node.GetString("FAC_IN_TIME"));
            spdLotInfo.ActiveSheet.Cells[14, 5].Value = MPCF.MakeDateFormat(out_node.GetString("FLOW_IN_TIME"));

            spdLotInfo.ActiveSheet.Cells[15, 1].Value = MPCF.MakeDateFormat(out_node.GetString("OPER_IN_TIME"));
            spdLotInfo.ActiveSheet.Cells[15, 3].Value = out_node.GetString("FROM_TO_LOT_ID");
            spdLotInfo.ActiveSheet.Cells[15, 5].Value = out_node.GetString("RESERVE_RES_ID");

            spdLotInfo.ActiveSheet.Cells[16, 1].Value = out_node.GetString("BOM_SET_ID");
            spdLotInfo.ActiveSheet.Cells[16, 3].Value = out_node.GetInt("BOM_SET_VERSION");
            spdLotInfo.ActiveSheet.Cells[16, 5].Value = out_node.GetInt("BOM_ACTIVE_HIST_SEQ");

            spdLotInfo.ActiveSheet.Cells[17, 1].Value = out_node.GetChar("LOT_DEL_FLAG");
            spdLotInfo.ActiveSheet.Cells[17, 3].Value = MPCF.MakeDateFormat(out_node.GetString("LOT_DEL_TIME"));
            spdLotInfo.ActiveSheet.Cells[17, 5].Value = out_node.GetString("LOT_DEL_CODE");

            spdLotInfo.ActiveSheet.Cells[18, 1].Value = out_node.GetDouble("START_QTY_1") + "/" + out_node.GetDouble("START_QTY_2") + "/" + out_node.GetDouble("START_QTY_3");
            spdLotInfo.ActiveSheet.Cells[18, 3].Value = out_node.GetString("CRR_ID");
            spdLotInfo.ActiveSheet.Cells[18, 5].Value = out_node.GetInt("LAST_ACTIVE_HIST_SEQ");

            return true;

        }

        public static bool SetSublotInfoSpread(FarPoint.Win.Spread.FpSpread spdSubLotInfo, string sSublotID)
        {
            TRSNode out_node = null;
            return SetSublotInfoSpread(spdSubLotInfo, sSublotID, ref out_node);
        }
        public static bool SetSublotInfoSpread(FarPoint.Win.Spread.FpSpread spdSubLotInfo, string sSublotID, ref TRSNode sublot_info)
        {
            return SetSublotInfoSpread(spdSubLotInfo, '1', sSublotID, ref sublot_info);
        }
        public static bool SetSublotInfoSpread(FarPoint.Win.Spread.FpSpread spdSubLotInfo, char cProcStep, string sSublotID, ref TRSNode sublot_info)
        {
            TRSNode in_node = new TRSNode("VIEW_SUBLOT_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SUBLOT_ID", sSublotID);

            if (ClearSubLotSpread(spdSubLotInfo) == false)
            {
                return false;
            }

            if (MPCR.CallService("WIP", "WIP_View_Sublot", in_node, ref out_node) == false)
            {
                return false;
            }

            sublot_info = out_node;

            spdSubLotInfo.ActiveSheet.Cells[0, 1].Value = sSublotID;
            spdSubLotInfo.ActiveSheet.Cells[0, 3].Value = out_node.GetInt("SLOT_NO").ToString();
            spdSubLotInfo.ActiveSheet.Cells[0, 5].Value = out_node.GetString("CRR_ID");

            spdSubLotInfo.ActiveSheet.Cells[1, 1].Value = out_node.GetString("LOT_ID");
            spdSubLotInfo.ActiveSheet.Cells[1, 3].Value = out_node.GetString("MAT_ID") + " (" + out_node.GetInt("MAT_VER") + ") : " + out_node.GetString("MAT_DESC");
            spdSubLotInfo.ActiveSheet.Cells[1, 5].Value = out_node.GetString("FLOW") + " (" + out_node.GetInt("FLOW_SEQ_NUM") + ") : " + out_node.GetString("FLOW_DESC");

            spdSubLotInfo.ActiveSheet.Cells[2, 1].Value = out_node.GetString("OPER") + " : " + out_node.GetString("OPER_DESC");
            spdSubLotInfo.ActiveSheet.Cells[2, 3].Value = out_node.GetDouble("QTY_2").ToString() + "/" + out_node.GetDouble("QTY_3").ToString();
            spdSubLotInfo.ActiveSheet.Cells[2, 5].Value = out_node.GetString("SUBLOT_STATUS");
            if (out_node.GetString("SUBLOT_STATUS") == MPGC.MP_LOT_STATUS_WAIT)
            {
                spdSubLotInfo.ActiveSheet.Cells[2, 5].ForeColor = Color.Lime;
            }
            else if (out_node.GetString("SUBLOT_STATUS") == MPGC.MP_LOT_STATUS_PROC)
            {
                spdSubLotInfo.ActiveSheet.Cells[2, 5].ForeColor = Color.Gold;
            }
            else
            {
                spdSubLotInfo.ActiveSheet.Cells[2, 5].ForeColor = Color.Black;
            }

            spdSubLotInfo.ActiveSheet.Cells[3, 1].Value = out_node.GetString("CREATE_CODE");
            spdSubLotInfo.ActiveSheet.Cells[3, 3].Value = out_node.GetString("OWNER_CODE");
            if (out_node.GetChar("HOLD_FLAG") != ' ')
            {
                spdSubLotInfo.ActiveSheet.Cells[3, 5].Value = out_node.GetChar("HOLD_FLAG") + " : " + out_node.GetString("HOLD_CODE");
            }

            spdSubLotInfo.ActiveSheet.Cells[4, 1].Value = out_node.GetChar("START_FLAG");
            spdSubLotInfo.ActiveSheet.Cells[4, 3].Value = out_node.GetChar("END_FLAG");
            if (out_node.GetChar("RWK_FLAG") != ' ')
            {
                spdSubLotInfo.ActiveSheet.Cells[4, 5].Value = out_node.GetChar("RWK_FLAG") + " : " + out_node.GetString("RWK_CODE");
            }

            spdSubLotInfo.ActiveSheet.Cells[5, 1].Value = out_node.GetChar("TRANSIT_FLAG");
            spdSubLotInfo.ActiveSheet.Cells[5, 3].Value = out_node.GetChar("INV_FLAG");
            spdSubLotInfo.ActiveSheet.Cells[5, 5].Value = out_node.GetChar("NSTD_FLAG");

            spdSubLotInfo.ActiveSheet.Cells[6, 1].Value = out_node.GetString("LAST_TRAN_CODE");
            spdSubLotInfo.ActiveSheet.Cells[6, 3].Value = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
            spdSubLotInfo.ActiveSheet.Cells[6, 5].Value = out_node.GetInt("LAST_HIST_SEQ").ToString();

            spdSubLotInfo.ActiveSheet.Cells[7, 1].Value = out_node.GetChar("GRADE");
            spdSubLotInfo.ActiveSheet.Cells[7, 3].Value = out_node.GetString("GRADE_CODE");
            spdSubLotInfo.ActiveSheet.Cells[7, 5].Value = out_node.GetString("CELL_GRADE");

            spdSubLotInfo.ActiveSheet.Cells[8, 1].Value = out_node.GetDouble("OPER_IN_QTY_2") + "/" + out_node.GetDouble("OPER_IN_QTY_3");
            spdSubLotInfo.ActiveSheet.Cells[8, 3].Value = out_node.GetDouble("CREATE_QTY_2") + "/" + out_node.GetDouble("CREATE_QTY_3");
            spdSubLotInfo.ActiveSheet.Cells[8, 5].Value = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));

            spdSubLotInfo.ActiveSheet.Cells[9, 1].Value = out_node.GetString("START_RES_ID");
            spdSubLotInfo.ActiveSheet.Cells[9, 3].Value = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));
            spdSubLotInfo.ActiveSheet.Cells[9, 5].Value = out_node.GetString("END_RES_ID");

            if (out_node.GetString("RWK_RET_FLOW") == "")
                spdSubLotInfo.ActiveSheet.Cells[10, 1].Value = "";
            else
                spdSubLotInfo.ActiveSheet.Cells[10, 1].Value = out_node.GetString("RWK_RET_FLOW") + "(" + out_node.GetInt("RWK_RET_FLOW_SEQ_NUM").ToString() + ")";

            spdSubLotInfo.ActiveSheet.Cells[10, 3].Value = out_node.GetString("RWK_RET_OPER");
            spdSubLotInfo.ActiveSheet.Cells[10, 5].Value = out_node.GetInt("RWK_COUNT").ToString();

            if (out_node.GetString("RWK_END_FLOW") == "")
                spdSubLotInfo.ActiveSheet.Cells[11, 1].Value = "";
            else
                spdSubLotInfo.ActiveSheet.Cells[11, 1].Value = out_node.GetString("RWK_END_FLOW") + "(" + out_node.GetInt("RWK_END_FLOW_SEQ_NUM").ToString() + ")";

            spdSubLotInfo.ActiveSheet.Cells[11, 3].Value = out_node.GetString("RWK_END_OPER");
            spdSubLotInfo.ActiveSheet.Cells[11, 5].Value = MPCF.MakeDateFormat(out_node.GetString("RWK_TIME"));

            if (out_node.GetString("NSTD_RET_FLOW") == "")
                spdSubLotInfo.ActiveSheet.Cells[12, 1].Value = "";
            else
                spdSubLotInfo.ActiveSheet.Cells[12, 1].Value = out_node.GetString("NSTD_RET_FLOW") + "(" + out_node.GetInt("NSTD_RET_FLOW_SEQ_NUM").ToString() + ")"; ;

            spdSubLotInfo.ActiveSheet.Cells[12, 3].Value = out_node.GetString("NSTD_RET_OPER");
            spdSubLotInfo.ActiveSheet.Cells[12, 5].Value = MPCF.MakeDateFormat(out_node.GetString("NSTD_TIME"));

            spdSubLotInfo.ActiveSheet.Cells[13, 1].Value = out_node.GetChar("REP_FLAG");
            spdSubLotInfo.ActiveSheet.Cells[13, 3].Value = out_node.GetString("REP_RET_OPER");
            spdSubLotInfo.ActiveSheet.Cells[13, 5].Value = out_node.GetString("SUBLOT_LOCATION");

            spdSubLotInfo.ActiveSheet.Cells[14, 1].Value = out_node.GetChar("SAMPLE_FLAG");
            spdSubLotInfo.ActiveSheet.Cells[14, 3].Value = out_node.GetChar("SAMPLE_WAIT_FLAG");
            spdSubLotInfo.ActiveSheet.Cells[14, 5].Value = out_node.GetChar("SAMPLE_RESULT");

            spdSubLotInfo.ActiveSheet.Cells[15, 1].Value = out_node.GetChar("LOT_BASE");
            spdSubLotInfo.ActiveSheet.Cells[15, 3].Value = out_node.GetString("RESERVE_RES_ID");
            spdSubLotInfo.ActiveSheet.Cells[15, 5].Value = out_node.GetChar("SUBLOT_DEL_FLAG");

            spdSubLotInfo.ActiveSheet.Cells[16, 1].Value = MPCF.MakeDateFormat(out_node.GetString("SUBLOT_DEL_TIME"));
            spdSubLotInfo.ActiveSheet.Cells[16, 3].Value = out_node.GetString("SUBLOT_DEL_CODE");
            spdSubLotInfo.ActiveSheet.Cells[16, 5].Value = out_node.GetInt("LAST_ACTIVE_HIST_SEQ");

            return true;

        }

        // GetProcTime()
        //       - Get Sum Queue Time, Process Time and Queue Time + Process Time
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal Material As String : Material ID
        //       - ByVal Flow As String : Flow
        //       - ByVal Oper As String : Operation
        //       - ByVal Qty As Double : Unit1 Qty
        //       - ByRef SumQueueTime As Double : Sum Queue Time
        //       - ByRef SumProcTime As Double : Sum Process Time
        //       - ByRef SumQueueProcTime As Double : Sum Queue Time + Process Time
        //
        public static bool GetProcTime(string Material, int MatVer, string Flow, int FlowSeq, string Oper, double Qty, ref double SumQueueTime, ref double SumProcTime, ref double SumQueueProcTime)
        {

            TRSNode in_node = new TRSNode("VIEW_PROCTIME_IN");
            TRSNode out_node = new TRSNode("VIEW_PROCTIME_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", Material);
                in_node.AddInt("MAT_VER", MatVer);
                in_node.AddString("FLOW", Flow);
                in_node.AddInt("FLOW_SEQ_NUM", FlowSeq);
                in_node.AddString("OPER", Oper);
                in_node.AddDouble("QTY", Qty);

                if (MPCR.CallService("WIP", "WIP_View_ProcTime", in_node, ref out_node) == false)
                {
                    return false;
                }

                SumQueueTime = out_node.GetDouble("SUM_QUEUE_TIME");
                SumProcTime = out_node.GetDouble("SUM_PROC_TIME");
                SumQueueProcTime = out_node.GetDouble("SUM_QUEUE_PROC_TIME");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        // GetFactoryShiftInfor()
        //       - Function Description
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool GetFactoryShiftInfor()
        {

            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCR.CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPGV.gShiftInfor.bVariableShift = out_node.GetChar("VARIABLE_SHIFT_FLAG") == 'Y' ? true : false;

                if (MPGV.gShiftInfor.bVariableShift == false)
                {
                    if (out_node.GetString("SHIFT_1_START") != "")
                    {
                        MPGV.gShiftInfor.cShift1DayFlag = out_node.GetChar("SHIFT_1_DAY_FLAG");
                        MPGV.gShiftInfor.sShift1StartTime = out_node.GetString("SHIFT_1_START") + "00";
                    }
                    if (out_node.GetString("SHIFT_2_START") != "")
                    {
                        MPGV.gShiftInfor.cShift2DayFlag = out_node.GetChar("SHIFT_2_DAY_FLAG");
                        MPGV.gShiftInfor.sShift2StartTime = out_node.GetString("SHIFT_2_START") + "00";
                    }
                    if (out_node.GetString("SHIFT_3_START") != "")
                    {
                        MPGV.gShiftInfor.cShift3DayFlag = out_node.GetChar("SHIFT_3_DAY_FLAG");
                        MPGV.gShiftInfor.sShift3StartTime = out_node.GetString("SHIFT_3_START") + "00";
                    }
                    if (out_node.GetString("SHIFT_4_START") != "")
                    {
                        MPGV.gShiftInfor.cShift4DayFlag = out_node.GetChar("SHIFT_4_DAY_FLAG");
                        MPGV.gShiftInfor.sShift4StartTime = out_node.GetString("SHIFT_4_START") + "00";
                    }

                    if (MPGV.gShiftInfor.sShift1StartTime != "")
                    {
                        MPGV.gShiftInfor.iShiftCount = 1;
                    }
                    if (MPGV.gShiftInfor.sShift2StartTime != "")
                    {
                        MPGV.gShiftInfor.iShiftCount = 2;
                    }
                    if (MPGV.gShiftInfor.sShift3StartTime != "")
                    {
                        MPGV.gShiftInfor.iShiftCount = 3;
                    }
                    if (MPGV.gShiftInfor.sShift4StartTime != "")
                    {
                        MPGV.gShiftInfor.iShiftCount = 4;
                    }
                }
                else
                {
                    MPGV.gShiftInfor.iShiftCount = 0;
                    MPGV.gShiftInfor.sShift1StartTime = "000000";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("GetFactoryShiftInfor() Failed.\n" + ex.Message);
                return false;
            }

            return true;

        }


        // SetLotCmfPrompt()
        //       - Function Description
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool SetLotCmfPrompt(FarPoint.Win.Spread.FpSpread spdLotHistory, int iCmfStartIndex)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            int i;

            try
            {
                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_LOT, ref out_node, "", true) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("PROMPT") != "")
                    {
                        spdLotHistory.ActiveSheet.ColumnHeader.Cells[0, i + iCmfStartIndex].Value = out_node.GetList(0)[i].GetString("PROMPT");
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


        // SetSubLotCmfPrompt()
        //       - Function Description
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool SetSubLotCmfPrompt(FarPoint.Win.Spread.FpSpread spdSubLotHistory, int iCmfStartIndex)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            int i;

            try
            {
                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_SUBLOT, ref out_node, "", true) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("PROMPT") != "")
                    {
                        spdSubLotHistory.ActiveSheet.ColumnHeader.Cells[0, i + iCmfStartIndex].Value = out_node.GetList(0)[i].GetString("PROMPT");
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



        #endregion

        #region "ALM Module"

#if _ALM
        /*
         PublishALMMsgTune()
               - Publish Alarm Message Tune
         Return Value
               - Boolean : True or False
         Arguments
               -
        */
        public static bool PublishALMMsgTune()
        {

            try
            {
#if _HTTP
                MPMH.registerDispatcher("ALM", new ALMTunerImpl());
#else
                string sPublishAlarmChannel;

                sPublishAlarmChannel = "/" + MPGV.gsSiteID;
                sPublishAlarmChannel += "/ALM";
                sPublishAlarmChannel += "/" + MPGV.gsFactory;
                sPublishAlarmChannel += "/" + MPGV.gsUserID;

                MPMH.registerDispatcher("ALM", new ALMTunerImpl());
                if (true != MPMH.tune(sPublishAlarmChannel, true, false))
                {
                    MPCF.ShowMsgBox("Message Tuning " + MPMH.StatusMessage, "Message Tuning", 0, 1);
                    return false;
                }
#endif
            }
            catch (Exception)
            {
                MPCF.ShowMsgBox("PublishALMMsgTune() Failed.");
                return false;
            }

            return true;

        }

        public static bool PublishALMMsgUnTune()
        {

            try
            {
                string sPublishAlarmChannel;

                sPublishAlarmChannel = "/" + MPGV.gsSiteID;
                sPublishAlarmChannel += "/ALM";
                sPublishAlarmChannel += "/" + MPGV.gsFactory;
                sPublishAlarmChannel += "/" + MPGV.gsUserID;

                MPMH.untune(sPublishAlarmChannel, true, false);
                MPMH.unregisterDispatcher("ALM");

            }
            catch (Exception)
            {
                MPCF.ShowMsgBox("PublishALMMsgUnTune() Failed.");
                return false;
            }

            return true;

        }
#endif

        #endregion

        #region "EDC Module"

#if _EDC

        // FindColSetVersion()
        //       -  Find Collection Set Version which is suitable to the lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String - Process Step
        //       - ByRef ColSetID As String  - Collection Set ID
        //       - ByRef ColSetVersion as Contol - Collection Set Version Control
        //       - Optional ByVal LotID as string ="" - Lot_ID
        //       - Optional ByVal MatID as string ="" - Material ID
        //       - Optional ByVal Flow As String ="" - Flow
        //       - Optional ByVal Oper As String ="" - Operation
        //       - Optional ByVal EventID As String ="" - Event ID
        //       - Optional byref LotResFlag as String - Lot_Or_Res_Flag 
        //       - Optional ByRef spdData As FarPoint.Win.Spread.FpSpread = Nothing - SpreadSheet Control
        //
        public static bool FindColSetVersion(char c_step, string ColSetID, ref int ColSetVersion, string LotID, string MatID, int MatVer, string Flow, string Oper,
                                             string EventID, char LotResFlag, FarPoint.Win.Spread.FpSpread spdData, bool bIgnoreError, char cIncludeUnitID)
        {
            TRSNode in_node = new TRSNode("FIND_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("FIND_COL_SET_VERSION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("LOT_ID", LotID);
            in_node.AddString("MAT_ID", MatID);
            in_node.AddInt("MAT_VER", MatVer);
            in_node.AddString("FLOW", Flow);
            in_node.AddString("OPER", Oper);
            in_node.AddString("EVENT_ID", EventID);
            in_node.AddString("COL_SET_ID", ColSetID);
            in_node.AddChar("LOT_OR_RES_FLAG", LotResFlag);

            if (MPCR.CallService("EDC", "EDC_Find_Col_Set_Version", in_node, ref out_node, bIgnoreError) == false)
            {
                return false;
            }

            ColSetVersion = out_node.GetInt("COL_SET_VERSION");

            if (spdData != null)
            {
                if (ViewAttachCharacterList(spdData,
                                            '5',
                                            ColSetID,
                                            ColSetVersion,
                                            "",
                                            null,
                                            cIncludeUnitID,
                                            LotID) == false)
                {
                    return false;
                }
            }

            return true;

        }


        // FindColSetVersion()
        //       -  Find Collection Set Version which is suitable to the lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String - Process Step
        //       - ByRef ColSetID As String  - Collection Set ID
        //       - ByRef ColSetVersion as Contol - Collection Set Version Control
        //       - Optional ByVal LotID as string ="" - Lot_ID
        //       - Optional ByVal MatID as string ="" - Material ID
        //       - Optional ByVal Flow As String ="" - Flow
        //       - Optional ByVal Oper As String ="" - Operation
        //       - Optional ByVal EventID As String ="" - Event ID
        //       - Optional byref LotResFlag as String - Lot_Or_Res_Flag Í∞?c_step="1" ??Í≤ΩÏö∞?êÎßå ?ÑÏöî)
        //       - Optional ByRef spdData As FarPoint.Win.Spread.FpSpread = Nothing - SpreadSheet Control
        //
        public static bool FindColSetVersion(char c_step, Control ColSetID, Control ColSetVersion, string LotID, string MatID, int MatVer, string Flow, string Oper,
                                             string EventID, ref char LotResFlag, FarPoint.Win.Spread.FpSpread spdData, char cIncludeUnitID)
        {
            TRSNode in_node = new TRSNode("FIND_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("FIND_COL_SET_VERSION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("LOT_ID", LotID);
            in_node.AddString("MAT_ID", MatID);
            in_node.AddInt("MAT_VER", MatVer);
            in_node.AddString("FLOW", Flow);
            in_node.AddString("OPER", Oper);
            in_node.AddString("EVENT_ID", EventID);

            if (ColSetID is TextBox)
            {
                in_node.AddString("COL_SET_ID", MPCF.Trim(((TextBox)ColSetID).Text));
            }
            else if (ColSetID is Miracom.UI.Controls.MCCodeView.MCCodeView)
            {
                in_node.AddString("COL_SET_ID", MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)ColSetID).Text));
            }
            else if (ColSetID is ComboBox)
            {
                in_node.AddString("COL_SET_ID", MPCF.Trim(((ComboBox)ColSetID).Text));
            }

            in_node.AddChar("LOT_OR_RES_FLAG", LotResFlag);

            if (MPCR.CallService("EDC", "EDC_Find_Col_Set_Version", in_node, ref out_node) == false)
            {
                return false;
            }

            if (ColSetID is TextBox)
            {
                ((TextBox)ColSetID).Text = out_node.GetString("COL_SET_ID");
            }
            else if (ColSetID is FarPoint.Win.Spread.FpSpread)
            {
                ((FarPoint.Win.Spread.FpSpread)ColSetID).Text = out_node.GetString("COL_SET_ID");
            }
            else if (ColSetID is ComboBox)
            {
                ((ComboBox)ColSetID).Text = out_node.GetString("COL_SET_ID");
            }

            if (ColSetVersion is TextBox)
            {
                ((TextBox)ColSetVersion).Text = out_node.GetInt("COL_SET_VERSION").ToString();
            }
            else if (ColSetVersion is Miracom.UI.Controls.MCCodeView.MCCodeView)
            {
                ((Miracom.UI.Controls.MCCodeView.MCCodeView)ColSetVersion).Text = out_node.GetInt("COL_SET_VERSION").ToString();
            }
            else if (ColSetVersion is ComboBox)
            {
                ((ComboBox)ColSetVersion).Text = out_node.GetInt("COL_SET_VERSION").ToString();
            }

            if (spdData != null)
            {
                if (ViewAttachCharacterList(spdData,
                                            '5',
                                            out_node.GetString("COL_SET_ID"),
                                            out_node.GetInt("COL_SET_VERSION"),
                                            "",
                                            null,
                                            cIncludeUnitID,
                                            LotID) == false)
                {
                    return false;
                }
            }

            return true;


        }

        // FindColSetVersion()
        //       -  Find Collection Set Version which is suitable to the lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String - Process Step
        //       - ByRef ColSetID As String  - Collection Set ID
        //       - ByRef ColSetVersion as Contol - Collection Set Version Control
        //       - Optional ByVal LotID as string ="" - Lot_ID
        //       - Optional ByVal MatID as string ="" - Material ID
        //       - Optional ByVal Flow As String ="" - Flow
        //       - Optional ByVal Oper As String ="" - Operation
        //       - Optional ByVal EventID As String ="" - Event ID
        //       - Optional byref LotResFlag as String - Lot_Or_Res_Flag 
        //       - Optional ByRef spdData As FarPoint.Win.Spread.FpSpread = Nothing - SpreadSheet Control
        //
        public static bool FindColSetVersion(char c_step, string ColSetID, ref int ColSetVersion, string LotID, string MatID, int MatVer, string Flow, string Oper,
                                       string ResID, string EventID, char LotResFlag, FarPoint.Win.Spread.FpSpread spdData, bool bIgnoreError, char cIncludeUnitID, clsDerivedCharList cls_derived_char_list)
        {
            TRSNode in_node = new TRSNode("FIND_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("FIND_COL_SET_VERSION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("LOT_ID", LotID);
            in_node.AddString("MAT_ID", MatID);
            in_node.AddInt("MAT_VER", MatVer);
            in_node.AddString("FLOW", Flow);
            in_node.AddString("OPER", Oper);
            in_node.AddString("EVENT_ID", EventID);
            in_node.AddString("COL_SET_ID", ColSetID);
            in_node.AddChar("LOT_OR_RES_FLAG", LotResFlag);

            if (MPCR.CallService("EDC", "EDC_Find_Col_Set_Version", in_node, ref out_node, bIgnoreError) == false)
            {
                return false;
            }

            ColSetVersion = out_node.GetInt("COL_SET_VERSION");

            if (LotResFlag == 'L')
            {
                cls_derived_char_list.GetDerivedInfo(ColSetID, ColSetVersion, LotID, "", "", "");
            }
            else
            {
                cls_derived_char_list.GetDerivedInfo(ColSetID, ColSetVersion, "", ResID, "", "");
            }

            if (spdData != null)
            {
                if (ViewAttachCharacterList(spdData,
                                            '5',
                                            ColSetID,
                                            ColSetVersion,
                                            "",
                                            null,
                                            cIncludeUnitID,
                                            cls_derived_char_list,
                                            LotID) == false)
                {
                    return false;
                }

                spdData.Tag = null;
            }

            return true;
        }

        // ViewAttachCharacterList()
        //       - View Character list that is attached to Collection Set Version
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByRef control As Control                      : Control to be displayed Attached Character List
        //       - ByVal ProcStep As String                        : Process Step
        //        - ByVal ColSetID As String                      : Collection Set ID
        //       - ByVal ColSetVersion As Integer                : Collection Set Version
        //       - Optional ByVal Ext_Factory As String = ""     : Ext Factory
        //
        public static bool ViewAttachCharacterList(Control control, char ProcStep, string ColSetID, int ColSetVersion, string Ext_Factory,
                                                   TreeNode parentNode, char cIncludeUnitID, string LotID)
        {
            return ViewAttachCharacterList(control, ProcStep, ColSetID, ColSetVersion, Ext_Factory, parentNode, cIncludeUnitID, null, LotID);

        }

        // ViewAttachCharacterList()
        //       - View Character list that is attached to Collection Set Version
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByRef control As Control                      : Control to be displayed Attached Character List
        //       - ByVal ProcStep As String                        : Process Step
        //        - ByVal ColSetID As String                      : Collection Set ID
        //       - ByVal ColSetVersion As Integer                : Collection Set Version
        //       - Optional ByVal Ext_Factory As String = ""     : Ext Factory
        //
        public static bool ViewAttachCharacterList(Control control, char ProcStep, string ColSetID, int ColSetVersion, string Ext_Factory,
                                                   TreeNode parentNode, char cIncludeUnitID, clsDerivedCharList cls_derived_char_list, string LotID)
        {

            int i;
            int j;
            int k;
            int m;
            int i_index;
            int iLastRow = 0;
            int iUnitCnt = 0;
            int iValueCnt = 0;
            int iUnitSeq = 0;
            int iMaxColumnCnt = 0;
            int iColCnt = 0;
            string sDefaultValue;
            string sUnitTbl;
            string sValueTbl;
            char cDefUnitFlag;
            char cDefUnitOvrFlag;
            FarPoint.Win.Spread.CellType.ComboBoxCellType UnitCellType = null;
            FarPoint.Win.Spread.CellType.ComboBoxCellType ValueCellType = null;
            ListViewItem itmX;
            TreeNode nodeX = null;

            TRSNode in_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_OUT");
            List<TRSNode> unit_list;

            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                else if (control is FpSpread)
                {
                    ((FpSpread)control).SuspendLayout();

                    ((FpSpread)control).ActiveSheet.RowCount = 0;
                    ((FpSpread)control).ActiveSheet.ColumnCount = DEFAULT_COL_COUNT;

                    ((FpSpread)control).ResumeLayout();
                }
                else if (!(control is TreeView))
                {
                    MPCF.ClearList(control, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (Ext_Factory != "")
                {
                    in_node.Factory = Ext_Factory;
                }

                in_node.AddChar("INCLUDE_UNIT_ID", cIncludeUnitID);
                in_node.AddString("COL_SET_ID", ColSetID);
                in_node.AddInt("COL_SET_VERSION", ColSetVersion);
                in_node.AddString("LOT_ID", LotID);

                do
                {
                    if (MPCR.CallService("EDC", "EDC_View_Attach_Character_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    //spread max column count
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is FpSpread)
                        {
                            iColCnt = 0;
                            iValueCnt = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                            if (iValueCnt > 0)
                            {
                                iColCnt = DEFAULT_COL_COUNT + iValueCnt;
                            }
                            else
                            {
                                iColCnt = DEFAULT_COL_COUNT;
                            }

                            if (iColCnt > iMaxColumnCnt)
                            {
                                iMaxColumnCnt = iColCnt;
                            }
                        }
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("CHAR_ID"), (int)SMALLICON_INDEX.IDX_CHARACTER);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(out_node.GetList(0)[i].GetString("CHAR_ID") + " : " + out_node.GetList(0)[i].GetString("CHAR_DESC"), (int)SMALLICON_INDEX.IDX_CHARACTER, (int)SMALLICON_INDEX.IDX_CHARACTER);
                            if (!(parentNode == null))
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)control).Nodes.Add(nodeX);
                            }
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("CHAR_ID"));

                        }
                        else if (control is FpSpread)
                        {
                            // Initialize
                            FarPoint.Win.Spread.SheetView with_1 = ((FpSpread)control).ActiveSheet;

                            iLastRow = with_1.RowCount - 1;
                            iUnitCnt = out_node.GetList(0)[i].GetInt("UNIT_COUNT");
                            iValueCnt = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                            UnitCellType = null;
                            ValueCellType = null;
                            with_1.Columns[MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].Width = 50;

                            with_1.RowCount += iUnitCnt;
                            if (with_1.ColumnCount < DEFAULT_COL_COUNT + iValueCnt)
                            {
                                with_1.ColumnCount = DEFAULT_COL_COUNT + iValueCnt;
                            }

                            sDefaultValue = out_node.GetList(0)[i].GetString("DEF_VALUE");
                            sUnitTbl = out_node.GetList(0)[i].GetString("UNIT_TBL");
                            sValueTbl = out_node.GetList(0)[i].GetString("VALUE_TBL");
                            cDefUnitFlag = out_node.GetList(0)[i].GetChar("DEF_UNIT_FLAG");
                            cDefUnitOvrFlag = out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG");

                            iUnitSeq = 0;
                            for (j = iLastRow + 1; j < with_1.RowCount; j++)
                            {
                                iUnitSeq++;
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.CHAR_COL), out_node.GetList(0)[i].GetString("CHAR_ID"));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.CHAR_DESC_COL), out_node.GetList(0)[i].GetString("CHAR_DESC"));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.SPEC_COL), MPCF.GetSpecInfo(out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"),
                                                                                                      out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"),
                                                                                                      out_node.GetList(0)[i].GetString("TARGET_VALUE")));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.OPT_INPUT_COL), out_node.GetList(0)[i].GetChar("OPT_INPUT_FLAG"));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.VALUE_TYPE_COL), out_node.GetList(0)[i].GetChar("VALUE_TYPE"));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.VALUE_COUNT_COL), out_node.GetList(0)[i].GetInt("VALUE_COUNT"));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.DEF_UNIT_OVR_FLAG_COL), out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG"));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.DEF_VALUE_COL), out_node.GetList(0)[i].GetString("DEF_VALUE"));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.UNIT_TBL_COL), out_node.GetList(0)[i].GetString("UNIT_TBL"));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.VALUE_TBL_COL), out_node.GetList(0)[i].GetString("VALUE_TBL"));
                                with_1.SetValue(j, MPCF.ToInt(CHAR_COLUMN.UNIT_SEQ_COL), iUnitSeq);
                            }

                            i_index = 0;

                            for (j = VALUE_START_COL; j < VALUE_START_COL + iValueCnt; j++)
                            {                               
                                for (k = iLastRow + 1; k < with_1.RowCount; k++)
                                {
                                    if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                                    {
                                        SetNumberCell(with_1.Cells[k, j]);
                                    }
                                    else
                                    {
                                        SetAsciiCell(with_1.Cells[k, j]);
                                    }

                                    if (cls_derived_char_list != null)
                                    {
                                        if (out_node.GetList(0)[i].GetChar("DERIVED_PARAM_FLAG") == 'Y')
                                        {
                                            with_1.Cells[k, j].Locked = true;
                                            with_1.Cells[k, j].BackColor = System.Drawing.Color.Cyan;
                                            with_1.Rows[k].Tag = "AUTO";

                                            cls_derived_char_list.SetCharLocation(out_node.GetList(0)[i].GetString("CHAR_ID"), with_1, i_index, k, j);
                                        }
                                    }
                                }

                                i_index += 1;
                            }

                            unit_list = out_node.GetList(0)[i].GetList("UNIT_LIST");
                            //Unit ID Cell Lock
                            if (unit_list.Count < 1)
                            {
                                if (cDefUnitFlag == 'C')
                                {
                                    for (m = 0; m < iUnitCnt; m++)
                                    {
                                        with_1.Cells[iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].Locked = true;
                                        with_1.Cells[iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].BackColor = System.Drawing.Color.WhiteSmoke;
                                        with_1.SetValue(iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), out_node.GetList(0)[i].GetString("UNIT"));
                                        if (out_node.GetList(0)[i].GetString("UNIT") == "")
                                        {
                                            with_1.SetValue(iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), "*");
                                        }
                                        with_1.SetTag(iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), "CHARACTER");
                                    }

                                }
                                else if (cDefUnitFlag == 'E')
                                {
                                    for (m = 0; m < iUnitCnt; m++)
                                    {
                                        with_1.Cells[iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].Locked = false;
                                        with_1.Cells[iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].BackColor = System.Drawing.Color.White;
                                        with_1.SetTag(iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), "NULL");
                                    }
                                }
                                else
                                {
                                    for (m = 0; m < iUnitCnt; m++)
                                    {
                                        with_1.Cells[iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].Locked = false;
                                        with_1.Cells[iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].BackColor = System.Drawing.Color.White;
                                    }
                                }
                            }
                            else
                            {
                                if (cDefUnitFlag == 'Y')
                                {
                                    for (m = 0; m < unit_list.Count; m++)
                                    {
                                        if (m > iUnitCnt - 1)
                                        {
                                            break;
                                        }

                                        // null_flag check
                                        if (unit_list[m].GetChar("NULL_FLAG") == 'Y')
                                        {
                                            with_1.SetTag(iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), "NULL");
                                        }
                                        else
                                        {
                                            with_1.SetValue(iLastRow + 1 + m, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), unit_list[m].GetString("DEF_UNIT_ID"));
                                        }

                                        if (out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG") == 'Y')
                                        {
                                        }
                                        else
                                        {
                                            with_1.Cells[iLastRow + 1 + m, (int)CHAR_COLUMN.UNIT_COL].Locked = true;
                                            with_1.Cells[iLastRow + 1 + m, (int)CHAR_COLUMN.UNIT_COL].BackColor = System.Drawing.Color.WhiteSmoke;
                                        }
                                    }
                                }

                                if ((cDefUnitFlag == 'Y' && cDefUnitOvrFlag == 'Y' && sUnitTbl != "") ||
                                    (cDefUnitFlag == ' ' && sUnitTbl != ""))
                                {
                                    for (j = iLastRow + 1; j <= with_1.RowCount - 1; j++)
                                    {
                                        if (UnitCellType == null)
                                        {
                                            if (BASLIST.ViewGCMDataList(control, '1', sUnitTbl, -1, null, "", false, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), j, null) == false)
                                            {
                                                return false;
                                            }
                                            else
                                            {
                                                UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(with_1.Cells[j, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].CellType);
                                                with_1.Columns[MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].Width = 50;
                                            }
                                        }
                                        else
                                        {
                                            with_1.Cells[j, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].CellType = UnitCellType;
                                        }
                                    }
                                }
                            }

                            //Default Value Setting                            
                            for (j = VALUE_START_COL; j <= iValueCnt + VALUE_START_COL - 1; j++)
                            {
                                for (k = iLastRow + 1; k <= with_1.RowCount - 1; k++)
                                {
                                    if (sDefaultValue != "")
                                    {
                                        with_1.SetValue(k, j, sDefaultValue);
                                    }
                                    if (sValueTbl != "")
                                    {
                                        if (ValueCellType == null)
                                        {
                                            if (BASLIST.ViewGCMDataList(control, '1', sValueTbl, -1, null, "", false, j, k, null) == false)
                                            {
                                                return false;
                                            }
                                            else
                                            {
                                                ValueCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(with_1.Cells[k, j].CellType);
                                            }
                                        }
                                        else
                                        {
                                            with_1.Cells[k, j].CellType = ValueCellType;
                                        }
                                    }
                                }
                            }

                            //Value Cell Lock
                            with_1.ColumnCount = iMaxColumnCnt;
                            for (j = iValueCnt + VALUE_START_COL; j < with_1.ColumnCount; j++)
                            {
                                for (k = iLastRow + 1; k < with_1.RowCount; k++)
                                {
                                    with_1.Cells[k, j].Locked = true;
                                    with_1.Cells[k, j].BackColor = System.Drawing.Color.WhiteSmoke;
                                }
                            }
                        }
                    }

                    in_node.SetString("NEXT_CHAR_ID", out_node.GetString("NEXT_CHAR_ID"));
                } while (in_node.GetString("NEXT_CHAR_ID") != "");

                // max input value count check, column unvisible.
                if (control is FpSpread)
                {
                    FarPoint.Win.Spread.SheetView with_2 = ((FpSpread)control).ActiveSheet;
                    int iColumnSeq = 0;

                    if (with_2.ColumnCount > DEFAULT_COL_COUNT)
                    {
                        with_2.ColumnHeader.Cells.Get(0, VALUE_START_COL).ColumnSpan = with_2.ColumnCount - DEFAULT_COL_COUNT;
                        for (i = VALUE_START_COL; i < with_2.ColumnCount; i++)
                        {
                            iColumnSeq++;
                            with_2.ColumnHeader.Cells.Get(1, i).Value = iColumnSeq;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }


            return true;

        }

        // ViewMFOColSet()
        //       - View Collection Set which is suitable M-F-O
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep as String  : Process Step
        //       - ByVal MatID As String     : Material ID
        //       - ByVal Flow As String      : Flow
        //       - ByVal Oper As String      : Operation
        //       - ByRef ColSetID As String  : Collection Set ID
        //       - Optional ByRef OvrFlag As String = "" : Override Flag
        //
        public static bool ViewMFOColSet(char ProcStep, string MatID, int MatVer, string Flow, string Oper, char ColMode, ref string ColSetID)
        {
            return ViewMFOColSet(ProcStep, MatID, MatVer, Flow, Oper, ColMode, ref ColSetID, false);
        }
        public static bool ViewMFOColSet(char ProcStep, string MatID, int MatVer, string Flow, string Oper, char ColMode, ref string ColSetID, bool b_ignore_error)
        {
            TRSNode in_node = new TRSNode("VIEW_MFO_COLSET_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_COLSET_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("MAT_ID", MatID);
                in_node.AddInt("MAT_VER", MatVer);
                in_node.AddString("FLOW", Flow);
                in_node.AddString("OPER", Oper);
                in_node.AddChar("COLLECTION_MODE", ColMode);

                if (MPCR.CallService("EDC", "EDC_View_MFO_ColSet", in_node, ref out_node, b_ignore_error) == false)
                {
                    return false;
                }

                ColSetID = out_node.GetString("COL_SET_ID");

                return true;

            }
            catch (Exception ex)
            {
                if (b_ignore_error == false)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                return false;
            }
        }

        // ViewMFOColSet()
        //       - View Collection Set which is suitable M-F-O
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep as String  : Process Step
        //       - ByVal MatID As String     : Material ID
        //       - ByVal Flow As String      : Flow
        //       - ByVal Oper As String      : Operation
        //       - ByRef ColSetID As Control  : Collection Set ID Control
        //       - Optional ByRef OvrFlag As Control = "" : Override Flag Control
        //
        public static bool ViewMFOColSet(char ProcStep, string MatID, int MatVer, string Flow, string Oper, char ColMode, Control ColSetID)
        {
            return ViewMFOColSet(ProcStep, MatID, MatVer, Flow, Oper, ColMode, ColSetID, false);
        }
        public static bool ViewMFOColSet(char ProcStep, string MatID, int MatVer, string Flow, string Oper, char ColMode, Control ColSetID, bool b_ignore_error)
        {
            TRSNode in_node = new TRSNode("VIEW_MFO_COLSET_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_COLSET_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("MAT_ID", MatID);
                in_node.AddInt("MAT_VER", MatVer);
                in_node.AddString("FLOW", Flow);
                in_node.AddString("OPER", Oper);
                in_node.AddChar("COLLECTION_MODE", ColMode);

                if (MPCR.CallService("EDC", "EDC_View_MFO_ColSet", in_node, ref out_node, b_ignore_error) == false)
                {
                    return false;
                }

                if (ColSetID is TextBox)
                {
                    ((TextBox)ColSetID).Text = out_node.GetString("COL_SET_ID");
                }
                else if (ColSetID is Label)
                {
                    ((Label)ColSetID).Text = out_node.GetString("COL_SET_ID");
                }
                else if (ColSetID is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    ((Miracom.UI.Controls.MCCodeView.MCCodeView)ColSetID).Text = out_node.GetString("COL_SET_ID");
                }
            }
            catch (Exception ex)
            {
                if (b_ignore_error == false)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                return false;
            }

            return true;
        }

        //
        // ViewDefaultList()
        //       - View Default Unit List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public static bool ViewDefaultUnitList(FarPoint.Win.Spread.FpSpread spdData, string ProcStep, string ColSetID, int ColSetVersion, string CharID, int Col, int Row, int ColCnt, int RowCnt)
        {


            int i = 0;
            int j = 0;

            TRSNode in_node = new TRSNode("VIEW_DEFAULT_UNIT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DEFAULT_UNIT_LIST_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COL_SET_ID", ColSetID);
                in_node.AddInt("COL_SET_VERSION", ColSetVersion);
                in_node.AddString("CHAR_ID", CharID);

                if (MPCR.CallService("EDC", "EDC_View_Default_Unit_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (j = 0; j < out_node.GetList(0).Count; j++)
                {
                    if (RowCnt <= i)
                    {
                        break;
                    }
                    FarPoint.Win.Spread.SheetView with_1 = spdData.ActiveSheet;
                    with_1.SetValue(Row + j, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), out_node.GetList(0)[i].GetString("DEF_UNIT_ID"));
                    if (out_node.GetList(0)[i].GetString("DEF_UNIT_ID") == "")
                    {
                        with_1.Cells[Row + j, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)].Tag = "NULL";
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

        public static void RecalculateDerivedParam(Control control, clsDerivedCharList cls_derived_char_list, int i_char_col, int i_value_start_col, int i_value_count_col)
        {
            RecalculateDerivedParam(control, cls_derived_char_list, 0, 0, i_char_col, i_value_start_col, i_value_count_col, -1);
        }

        public static void RecalculateDerivedParam(Control control, clsDerivedCharList cls_derived_char_list, int i_col_seq, int i_col_seq_col, int i_char_col, int i_value_start_col, int i_value_count_col)
        {
            RecalculateDerivedParam(control, cls_derived_char_list, i_col_seq, i_col_seq_col, i_char_col, i_value_start_col, i_value_count_col, -1);
        }

        public static void RecalculateDerivedParam(Control control, clsDerivedCharList cls_derived_char_list, int i_col_seq, int i_col_seq_col, int i_char_col, int i_value_start_col, int i_value_count_col, int i_check_col)
        {
            System.Collections.ArrayList a_values;
            string s_char_id;
            int i;
            int j;
            FarPoint.Win.Spread.SheetView data_sheet;
            int i_val_count;

            ClearDerivedParamFlag(control, i_value_start_col);

            if (control is FpSpread)
            {
                data_sheet = ((FpSpread)control).ActiveSheet;

                for (i = 0; i < data_sheet.RowCount; i++)
                {
                    if (i_col_seq > 0)
                    {
                        if (i_col_seq.Equals(MPCF.ToInt(data_sheet.Cells[i, i_col_seq_col].Value)) == false)
                        {
                            continue;
                        }
                    }
                    
                    if(MPCF.Trim(data_sheet.Rows[i].Tag) == "AUTO")
                    {
                        if (MPCF.Trim(data_sheet.Cells[i, i_value_start_col].Tag) != MPCF.Trim(data_sheet.Cells[i, i_value_start_col].Value))
                        {
                            data_sheet.Cells[i, i_value_start_col].Tag = data_sheet.Cells[i, i_value_start_col].Value;

                            a_values = new System.Collections.ArrayList();
                            s_char_id = MPCF.Trim(data_sheet.Cells[i, i_char_col].Value);

                            i_val_count = MPCF.ToInt(data_sheet.Cells[i, i_value_count_col].Value);
                            for (j = 0; j < i_val_count; j++)
                            {
                                a_values.Add(data_sheet.Cells[i, i_value_start_col + j].Value);
                            }

                            cls_derived_char_list.SetValue(s_char_id, 1, a_values, true);

                            if (i_check_col >= 0)
                            {
                                data_sheet.Cells[i, i_check_col].Value = true;
                            }

                            i = -1;
                        }
                    }
                }
            }
        }

        public static void ClearDerivedParamFlag(Control control, int i_value_start_col)
        {
            int i;

            if (control is FpSpread)
            {
                for (i = 0; i < ((FpSpread)control).ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(((FpSpread)control).ActiveSheet.Rows[i].Tag) == "AUTO")
                    {
                        ((FpSpread)control).ActiveSheet.Cells[i, i_value_start_col].Tag = null;
                    }
                }
            }
        }

#endif

        #endregion

        #region "SPC Module"

#if _SPC
        // PublishSPCMsgTune()
        //       - Publish Alarm Message Tune
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool PublishSPCMsgTune()
        {

            try
            {
#if _HTTP
                MPMH.registerDispatcher("SPC", new SPCTunerImpl());
#else
                string sPublishSPCChannel;

                sPublishSPCChannel = "/" + MPGV.gsSiteID;
                sPublishSPCChannel += "/SPC";
                sPublishSPCChannel += "/" + MPGV.gsFactory;
                sPublishSPCChannel += "/" + MPGV.gsUserGroup;
                sPublishSPCChannel += "/" + MPGV.gsUserID;

                MPMH.registerDispatcher("SPC", new SPCTunerImpl());
                if (true != MPMH.tune(sPublishSPCChannel, true, false))
                {
                    MPCF.ShowMsgBox("Message Tuning " + MPMH.StatusMessage, "Message Tuning", 0, 1);
                    return false;
                }
#endif
            }
            catch (Exception)
            {
                MPCF.ShowMsgBox("PublishSPCMsgTune() Failed.");
                return false;
            }

            return true;

        }

        public static bool PublishSPCMsgUnTune()
        {

            try
            {
                string sPublishSPCChannel;

                sPublishSPCChannel = "/" + MPGV.gsSiteID;
                sPublishSPCChannel += "/SPC";
                sPublishSPCChannel += "/" + MPGV.gsFactory;
                sPublishSPCChannel += "/" + MPGV.gsUserGroup;
                sPublishSPCChannel += "/" + MPGV.gsUserID;

                MPMH.untune(sPublishSPCChannel, true, false);
                MPMH.unregisterDispatcher("SPC");

            }
            catch (Exception)
            {
                MPCF.ShowMsgBox("PublishSPCMsgUnTune() Failed.");
                return false;
            }

            return true;

        }
#endif

        // FindColSetVersion()
        //       -  Find Collection Set Version which is suitable to the lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String - Process Step
        //       - ByRef ColSetID As String  - Collection Set ID
        //       - ByRef ColSetVersion as Contol - Collection Set Version Control
        //       - Optional ByVal LotID as string ="" - Lot_ID
        //       - Optional ByVal MatID as string ="" - Material ID
        //       - Optional ByVal Flow As String ="" - Flow
        //       - Optional ByVal Oper As String ="" - Operation
        //       - Optional ByVal EventID As String ="" - Event ID
        //       - Optional byref LotResFlag as String - Lot_Or_Res_Flag Í∞?c_step="1" ??Í≤ΩÏö∞?êÎßå ?ÑÏöî)
        //       - Optional ByRef spdData As FarPoint.Win.Spread.FpSpread = Nothing - SpreadSheet Control
        //
        public static bool FindSPCColSetVersion(char c_step, string ColSetID, ref int ColSetVersion, string LotID, string MatID, int MatVer, string Flow, string Oper, string EventID, char LotResFlag, Control control, string sAsciiFlag)
        {
            TRSNode in_node = new TRSNode("FIND_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("FIND_COL_SET_VERSION_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("LOT_ID", LotID);
                in_node.AddString("MAT_ID", MatID);
                in_node.AddInt("MAT_VER", MatVer);
                in_node.AddString("FLOW", Flow);
                in_node.AddString("OPER", Oper);
                in_node.AddString("EVENT_ID", EventID);
                in_node.AddString("COL_SET_ID", ColSetID);
                in_node.AddChar("LOT_OR_RES_FLAG", LotResFlag);

                if (MPCR.CallService("EDC", "EDC_Find_Col_Set_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                ColSetID = out_node.GetString("COL_SET_ID");
                ColSetVersion = out_node.GetInt("COL_SET_VERSION");

                if (sAsciiFlag == "Y")
                {
                    System.Windows.Forms.Control temp_object = control;
                    if (ViewAttachCharacterList(temp_object, '8', ColSetID, ColSetVersion, "", null, 'N', LotID) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    System.Windows.Forms.Control temp_object2 = control;
                    if (ViewAttachCharacterList(temp_object2, '7', ColSetID, ColSetVersion, "", null, 'N', LotID) == false)
                    {
                        return false;
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



        // Find_Spec_Version()
        //       - Find Spec Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool Find_Spec_Version(char c_step, string sChartID, ref int iSpecVer, bool bIgnoreError)
        {

            try
            {
                TRSNode in_node = new TRSNode("View_Event_In");
                TRSNode out_node = new TRSNode("View_Event_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_ID", sChartID);

                if (MPCR.CallService("SPC", "SPC_Find_Spec_Version", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                iSpecVer = out_node.GetInt("VERSION");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // ViewMFOColSet()
        //       - View Collection Set which is suitable M-F-O
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep as String  : Process Step
        //       - ByVal MatID As String     : Material ID
        //       - ByVal Flow As String      : Flow
        //       - ByVal Oper As String      : Operation
        //       - ByRef ColSetID As Control  : Collection Set ID Control
        //       - Optional ByRef OvrFlag As String = "" : Override Flag
        //
        public static bool ViewMFOChart(char c_step, string MatID, int MatVer, string Flow, string Oper, ref char sChartFlag, ref string sChartID, ref char sOvrFlag, bool bIgnoreError)
        {
            TRSNode in_node = new TRSNode("View_MFO_Chart_In");
            TRSNode out_node = new TRSNode("View_MFO_Chart_Out");
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MAT_ID", MatID);
                in_node.AddInt("MAT_VER", MatVer);
                in_node.AddString("FLOW", Flow);
                in_node.AddString("OPER", Oper);

                if (MPCR.CallService("SPC", "SPC_View_MFO_Chart", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                sChartFlag = out_node.GetChar("CHART_FLAG");
                sChartID = out_node.GetString("CHART_ID");
                sOvrFlag = out_node.GetChar("OVR_FLAG");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        #endregion

        public static bool SetCodeViewVisibleColumnHeader(object ff,
            bool VisibleColumnHeader,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl1,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl2,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl3,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl4,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl5,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl6,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl7,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl8,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl9,
            Miracom.UI.Controls.MCCodeView.MCCodeView ExceptCtl10)
        {

            //On Error Resume Next  - Cannot Convert to C#

            object l_Control;
            int i;
            bool bExceptFlag;

            l_Control = null;

            System.Windows.Forms.Control f = (System.Windows.Forms.Control)ff;

            for (i = 0; i <= f.Controls.Count - 1; i++)
            {
                bExceptFlag = false;

                l_Control = f.Controls[i];

                if (l_Control is Panel || l_Control is GroupBox || l_Control is TabControl || l_Control is TabPage)
                {

                    SetCodeViewVisibleColumnHeader(l_Control, VisibleColumnHeader, ExceptCtl1, ExceptCtl2, ExceptCtl3, ExceptCtl4, ExceptCtl5, ExceptCtl6, ExceptCtl7, ExceptCtl8, ExceptCtl9, ExceptCtl10);

                }
                else if (l_Control is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    if (ExceptCtl1 != null)
                    {
                        if (ExceptCtl1 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }
                    if (bExceptFlag == false && ExceptCtl2 != null)
                    {
                        if (ExceptCtl2 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }
                    if (bExceptFlag == false && ExceptCtl3 != null)
                    {
                        if (ExceptCtl3 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }

                    if (bExceptFlag == false && ExceptCtl4 != null)
                    {
                        if (ExceptCtl4 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }

                    if (bExceptFlag == false && ExceptCtl5 != null)
                    {
                        if (ExceptCtl5 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }

                    if (bExceptFlag == false && ExceptCtl6 != null)
                    {
                        if (ExceptCtl6 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }

                    if (bExceptFlag == false && ExceptCtl7 != null)
                    {
                        if (ExceptCtl7 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }

                    if (bExceptFlag == false && ExceptCtl8 != null)
                    {
                        if (ExceptCtl8 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }

                    if (bExceptFlag == false && ExceptCtl9 != null)
                    {
                        if (ExceptCtl9 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }

                    if (bExceptFlag == false && ExceptCtl10 != null)
                    {
                        if (ExceptCtl10 == l_Control)
                        {
                            bExceptFlag = true;
                        }
                        else
                        {
                            bExceptFlag = false;
                        }
                    }



                    if (bExceptFlag == false)
                    {
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)l_Control).VisibleColumnHeader = VisibleColumnHeader;
                    }

                }
            }

            return true;

        }

        /// <summary>
        /// BAS_SQL_Query_Out_Tag∏¶ DataTable∑Œ ∫Ø»Ø«—¥Ÿ.
        /// </summary>
        /// <param name="Query_Out">BAS_SQL_Query_Out_Tag</param>
        /// <returns>∫Ø»Øµ» DataTable</returns>
        public static DataTable ConvertToDataTable(TRSNode query_out)
        {
            return ConvertToDataTable(null, query_out);
        }

        /// <summary>
        /// BAS_SQL_Query_Out_Tag∏¶ DataTable∑Œ ∫Ø»Ø«—¥Ÿ. ±‚¡∏ DataTableø° Record∏¶ √ﬂ∞°«“ ∞ÊøÏ ªÁøÎ.
        /// </summary>
        /// <param name="cur_dt">±‚¡∏ DataTable</param>
        /// <param name="Query_Out">BAS_SQL_Query_Out_Tag</param>
        /// <returns>∫Ø»Øµ» DataTable</returns>
        public static DataTable ConvertToDataTable(DataTable cur_dt, TRSNode query_out)
        {
            int r;
            int c;
            DataTable dt;
            DataColumn dc;
            DataRow dr;

            List<TRSNode> col_list;
            List<TRSNode> row_list;
            TRSNode data_node;

            if (cur_dt == null)
            {
                if (query_out.GetList("ROWS").Count < 1) return null;

                dt = new DataTable("DataTable");

                col_list = query_out.GetList("COLUMNS");
                for (c = 0; c < col_list.Count; c++)
                {
                    dc = new DataColumn(col_list[c].GetString("NAME"));

                    switch (col_list[c].GetString("TYPE"))
                    {
                        case "INT":
                            dc.DataType = System.Type.GetType("System.Int32");
                            dc.DefaultValue = 0;
                            break;
                        case "LNG":
                            dc.DataType = System.Type.GetType("System.Int64");
                            dc.DefaultValue = 0;
                            break;
                        case "DBL":
                            dc.DataType = System.Type.GetType("System.Double");
                            dc.DefaultValue = 0;
                            break;
                        case "CHR":
                            dc.DataType = System.Type.GetType("System.String");
                            dc.DefaultValue = "";
                            break;
                        case "STR":
                            dc.DataType = System.Type.GetType("System.String");
                            dc.DefaultValue = "";
                            break;
                    }

                    dt.Columns.Add(dc);
                }
            }
            else
            {
                dt = cur_dt;
            }

            row_list = query_out.GetList("ROWS");
            for (r = 0; r < row_list.Count; r++)
            {
                dr = dt.NewRow();

                col_list = row_list[r].GetList("COLS");
                for (c = 0; c < col_list.Count; c++)
                {
                    data_node = col_list[c].GetMember("DATA");
                    if (data_node.IsNull == true)
                    {
                        dr[c] = DBNull.Value;
                    }
                    else
                    {
                        dr[c] = data_node.Value;
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
        /// <summary>
        /// BAS_SQL_Query_Out_Tag∏¶ DataTable∑Œ ∫Ø»Ø«—¥Ÿ. ±‚¡∏ DataTableø° Record∏¶ √ﬂ∞°«“ ∞ÊøÏ ªÁøÎ.
        /// </summary>
        /// <param name="cur_dt">±‚¡∏ DataTable</param>
        /// <param name="Query_Out">BAS_SQL_Query_Out_Tag</param>
        /// <returns>∫Ø»Øµ» DataTable</returns>
        public static void ConvertToDataTableWithDT(ref DataTable dt, TRSNode query_out)
        {
            int r;
            int c;
            DataColumn dc;
            DataRow dr;
            string[] s_datas;

            List<TRSNode> row_list;
            List<TRSNode> col_list;

            row_list = query_out.GetList("ROWS");

            if (dt.Columns.Count < 1)
            {
                if (row_list.Count < 1) return;

                col_list = row_list[0].GetList("COLS");
                s_datas = col_list[0].GetString("DATA").Split('`');

                for (c = 0; c < s_datas.Length; c++)
                {
                    dc = new DataColumn(s_datas[c]);
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "";

                    dt.Columns.Add(dc);
                }
            }

            for (r = 1; r < row_list.Count; r++)
            {
                dr = dt.NewRow();

                col_list = row_list[r].GetList("COLS");
                s_datas = col_list[0].GetString("DATA").Split('`');

                for (c = 0; c < s_datas.Length; c++)
                {
                    dr[c] = s_datas[c];
                }
                dt.Rows.Add(dr);
            }

            return;
        }

        /// <summary>
        /// List Control¿ª BAS_SQL_Query_Out_Tag ≥ªøÎ¿∏∑Œ √§øÓ¥Ÿ.
        /// </summary>
        /// <param name="obj">List Control</param>
        /// <param name="Query_Out">BAS_SQL_Query_Out_Tag</param>
        public static void FillDataView(object obj, TRSNode query_out)
        {
            FillDataView(obj, query_out, true, (int)SMALLICON_INDEX.IDX_CODE_DATA, true);
        }

        /// <summary>
        /// List Control¿ª BAS_SQL_Query_Out_Tag ≥ªøÎ¿∏∑Œ √§øÓ¥Ÿ.
        /// </summary>
        /// <param name="obj">List Control</param>
        /// <param name="Query_Out">BAS_SQL_Query_Out_Tag</param>
        /// <param name="listview_icon_index">ListView¿Œ ∞ÊøÏ «•Ω√µ… æ∆¿Ãƒ‹ ¿Œµ¶Ω∫</param>
        /// <param name="listview_generate_column_header">ListView¿Œ ∞ÊøÏ ƒÆ∑≥«Ï¥ı∏¶ ƒı∏ÆπÆ¿« ƒÆ∑≥¿∏∑Œ º≥¡§«“¡ˆ ø©∫Œ</param>
        public static void FillDataView(object obj, TRSNode query_out, bool fit_column_header, int listview_icon_index, bool listview_generate_column_header)
        {
            try
            {
                List<TRSNode> columns_list;
                List<TRSNode> row_list;
                List<TRSNode> col_list;
                string s_data;

                if (obj is ListView)
                {
                    ListView lis = (ListView)obj;
                    ListViewItem itmx;
                    System.Windows.Forms.ColumnHeader lc;
                    int r;
                    int c;

                    columns_list = query_out.GetList("COLUMNS");
                    if (columns_list.Count < 1) return;

                    if (lis.Items.Count < 1)
                    {
                        if (listview_generate_column_header == true)
                        {
                            lis.Columns.Clear();

                            for (c = 0; c < columns_list.Count; c++)
                            {
                                s_data = columns_list[c].GetString("NAME");
                                if (s_data != "")
                                {
                                    lc = new System.Windows.Forms.ColumnHeader();
                                    lc.Text = s_data;
                                    lis.Columns.Add(lc);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }

                    row_list = query_out.GetList("ROWS");
                    for (r = 0; r < row_list.Count; r++)
                    {
                        col_list = row_list[r].GetList("COLS");
                        s_data = col_list[0].GetString("DATA");

                        if (listview_icon_index >= 0)
                            itmx = new ListViewItem(s_data, listview_icon_index);
                        else
                            itmx = new ListViewItem(s_data);

                        for (c = 1; c < columns_list.Count; c++)
                        {
                            s_data = col_list[c].GetString("DATA");
                            itmx.SubItems.Add(s_data);
                        }
                        lis.Items.Add(itmx);
                    }
                }
                else
                {
                    DataTable dt;
                    int c;

                    columns_list = query_out.GetList("COLUMNS");

                    if (obj is DataGrid)
                    {
                        dt = ConvertToDataTable((DataTable)((DataGrid)obj).DataSource, query_out);
                        ((DataGrid)obj).DataSource = dt;
                    }
                    else if (obj is DataGridView)
                    {
                        dt = ConvertToDataTable((DataTable)((DataGridView)obj).DataSource, query_out);
                        ((DataGridView)obj).DataSource = dt;
                    }
                    else if (obj is FarPoint.Win.Spread.FpSpread)
                    {
                        dt = ConvertToDataTable((DataTable)((FarPoint.Win.Spread.FpSpread)obj).DataSource, query_out);
                        ((FarPoint.Win.Spread.FpSpread)obj).DataSource = dt;

                        if (dt != null)
                        {
                            for (c = 0; c < dt.Columns.Count; c++)
                            {
                                ((FarPoint.Win.Spread.FpSpread)obj).ActiveSheet.Columns[c].VerticalAlignment = CellVerticalAlignment.Center;

                                if (dt.Columns[c].DataType.Equals(Type.GetType("System.Double")) == true)
                                {
                                    if (MPCF.Trim(((FarPoint.Win.Spread.FpSpread)obj).ActiveSheet.Columns[c].Tag) != "Double")
                                    {
                                        try
                                        {
                                            ((FarPoint.Win.Spread.CellType.NumberCellType)(((FarPoint.Win.Spread.FpSpread)obj).ActiveSheet.Columns[c].CellType)).DecimalPlaces =
                                                columns_list[c].GetInt("SCALE");
                                            ((FarPoint.Win.Spread.FpSpread)obj).ActiveSheet.Columns[c].Tag = "Double";
                                        }
                                        catch (Exception ex)
                                        {
                                            Debug.WriteLine(ex.Message);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (fit_column_header == true) MPCF.FitColumnHeader(obj);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        /// <summary>
        /// List Control¿ª BAS_SQL_Query_Out_Tag ≥ªøÎ¿∏∑Œ √§øÓ¥Ÿ.
        /// </summary>
        /// <param name="obj">List Control</param>
        /// <param name="Query_Out">BAS_SQL_Query_Out_Tag</param>
        /// <param name="listview_icon_index">ListView¿Œ ∞ÊøÏ «•Ω√µ… æ∆¿Ãƒ‹ ¿Œµ¶Ω∫</param>
        /// <param name="listview_generate_column_header">ListView¿Œ ∞ÊøÏ ƒÆ∑≥«Ï¥ı∏¶ ƒı∏ÆπÆ¿« ƒÆ∑≥¿∏∑Œ º≥¡§«“¡ˆ ø©∫Œ</param>
        public static void FillDataViewWithDT(object obj, TRSNode query_out, bool fit_column_header, int listview_icon_index, bool listview_generate_column_header, ref DataTable dt)
        {
            try
            {

                if (obj is DataGrid)
                {
                    dt = ConvertToDataTable((DataTable)((DataGrid)obj).DataSource, query_out);
                    ((DataGrid)obj).DataSource = dt;
                }
                else if (obj is DataGridView)
                {
                    dt = ConvertToDataTable((DataTable)((DataGridView)obj).DataSource, query_out);
                    ((DataGridView)obj).DataSource = dt;
                }
                else if (obj is FarPoint.Win.Spread.FpSpread)
                {
                    ConvertToDataTableWithDT(ref dt, query_out);
                    //((FarPoint.Win.Spread.FpSpread)obj).DataSource = dt;

                    if (dt != null)
                    {
                            
                    }
                }
                return ;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// Check resource have port
        /// </summary>
        /// <param name="s_res_id">Resource ID</param>
        /// <param name="b_have_port">true is that resource have port, false is that resource doesn't have port</param>
        public static bool CheckResourceHavePort(string s_res_id, ref bool b_have_port)
        {
            TRSNode in_node = new TRSNode("VIEW_PORT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_PORT_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("RES_ID", s_res_id);
            in_node.AddString("SUBRES_ID", "");

            b_have_port = false;

            if (MPCR.CallService("RAS", "RAS_View_Port_List", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList(0).Count > 0)
                b_have_port = true;

            return true;
        }

        /// <summary>
        /// Check whether there are sheet name or not
        /// </summary>
        /// <param name="sheet_type">Sheet Type</param>
        /// <param name="b_is_sheet">true is that there are sheet, false is that there are not sheet</param>
        public static bool CheckSheetNameis(string sheet_type, ref bool b_is_sheet)
        {
            TRSNode in_node = new TRSNode("VIEW_SHEET_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SHEET_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SHEET_TYPE", sheet_type);

            b_is_sheet = false;

            if (MPCR.CallService("RAS", "RAS_View_Sheet_List", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList(0).Count > 0)
                b_is_sheet = true;

            return true;
        }

        /// <summary>
        /// Check MFO have carrier change option
        /// </summary>
        /// <param name="s_mat_id">Material ID</param>
        /// <param name="i_mat_ver">Material Version</param>
        /// <param name="s_flow">Flow</param>
        /// <param name="s_oper">Operation</param>
        /// <param name="c_change_point">A : Ad Hoc, S : Start, E - End</param>
        /// <param name="is_change_carrier">true is that MFO have change carrier option, false is that MFO doesn't have change carrier option</param>
        public static bool CheckCarrierChangeOption(string s_mat_id, int i_mat_ver, string s_flow, string s_oper, char c_change_point, ref bool is_change_carrier)
        {
            TRSNode in_node = new TRSNode("VIEW_MFO_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_OPTION_OUT");
            int i;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);
            in_node.AddChar("REL_LEVEL", ' ');

            is_change_carrier = false;

            if (MPCR.CallService("RAS", "RAS_View_Carrier_MFO_Option", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (c_change_point == out_node.GetList(0)[i].GetChar("CHG_POINT"))
                {
                    is_change_carrier = true;
                    break;
                }
            }

            return true;
        }

        public static bool CheckTranAlarmRelation(Form f_parent, char c_tran_point, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_lot_id, string s_event_id, string s_res_id, ref bool is_process_alarm)
        {
            TRSNode in_node = new TRSNode("CHECK_ALARM_IN");
            TRSNode out_node = new TRSNode("CHECK_ALARM_OUT");
            frmConfirmTransactionAlarm f;
            int i;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", s_lot_id);
            in_node.AddChar("TRAN_POINT", c_tran_point);
            in_node.AddString("RES_ID", s_res_id);
            in_node.AddString("EVENT_ID", s_event_id);

            is_process_alarm = false;

            if (MPCR.CallService("ALM", "ALM_Check_Confirm_Message", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList(0).Count < 1)
                return true;

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (out_node.GetList(0)[i].GetChar("NEED_CONFIRM_FLAG") == 'Y')
                    break;
            }
            if (i < out_node.GetList(0).Count)
            {
                f = new frmConfirmTransactionAlarm();

                f.SetCondition(s_mat_id, i_mat_ver, s_flow, s_oper, s_lot_id, s_event_id, s_res_id);
                f.SetMessage(out_node);

                if (f.ShowDialog(f_parent) != DialogResult.OK)
                {
                    return false;
                }
            }

            is_process_alarm = true;
            return true;
        }

        public static string GetExtCodeTable(string s_lot_id, string s_option_name)
        {
            TRSNode in_node = new TRSNode("TBL_IN");
            TRSNode out_node = new TRSNode("TBL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", s_lot_id);
            in_node.AddString("OPTION_NAME", s_option_name);

            if (MPCR.CallService("WIP", "WIP_View_Ext_Code_Table", in_node, ref out_node) == false)
            {
                return "";
            }

            return out_node.GetString("TABLE_NAME");
        }


        public static void SetInMsg(TRSNode in_node)
        {
            try
            {
                if (MPGV.gsFactory != null) in_node.Factory = MPGV.gsFactory;
                if (MPGV.gcLanguage != 0) in_node.Language = MPGV.gcLanguage;
                if (MPGV.gsPassport != null) in_node.Passport = MPGV.gsPassport;
                if (MPGV.gsPassword != null) in_node.Password = MPGV.gsPassword;
                if (MPGV.gsUserID != null) in_node.UserID = MPGV.gsUserID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetInMsg");
            }
        }

        public static bool CheckContinueProc(TRSNode node)
        {
            frmMessageBox frmMsg;
            ReturnMessageString retMsg;

            try
            {
                if (node.GetMember(TRSDefine.OUT_STATUSVALUE) == null)
                {
                    return false;
                }

                if (node.StatusValue == MPGC.MP_SUCCESS_STATUS && node.MsgCate == MPGC.MP_MSG_CATE_WARN)
                {
                    retMsg = new ReturnMessageString();
                    retMsg.MsgBoxIconType = MSGBOX_ICON_TYPE.WARNING;
                    retMsg.IsServerMsgFlag = true;
                    retMsg.IsNodeMsgFlag = true;
                    retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                    retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                    retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                    if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                    {
                        retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                    }

                    MPGV.gaWarningMsg.Add(retMsg);
                }
                else if (node.StatusValue == MPGC.MP_WARN_STATUS)
                {
                    retMsg = new ReturnMessageString();
                    retMsg.MsgBoxIconType = MSGBOX_ICON_TYPE.WARNING;
                    retMsg.IsServerMsgFlag = true;
                    retMsg.IsNodeMsgFlag = true;
                    retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                    retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                    retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                    if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                    {
                        retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                    }

                    frmMsg = new frmMessageBox();
                    frmMsg.Show(retMsg, Application.ProductName, MessageBoxButtons.OK, 1, MPGV.gfrmMDI);

                    retMsg = null;
                    frmMsg.Owner = null;
                    frmMsg = null;
                }

                if (node.StatusValue == MPGC.MP_SUCCESS_STATUS || node.StatusValue == MPGC.MP_WARN_STATUS)
                {
                    return true;
                }

                retMsg = new ReturnMessageString();
                retMsg.MsgBoxIconType = MSGBOX_ICON_TYPE.ERROR;
                retMsg.IsServerMsgFlag = true;
                retMsg.IsNodeMsgFlag = true;
                retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                {
                    retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                }

                frmMsg = new frmMessageBox();
                frmMsg.Show(retMsg, Application.ProductName, MessageBoxButtons.OK, 1, MPGV.gfrmMDI);

                retMsg = null;
                frmMsg.Owner = null;
                frmMsg = null;

                MPGV.gaWarningMsg.Clear();

                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("MPCR.CheckContinueProc()\n" + ex.Message);
                return false;
            }
        }


        public static bool ShowSuccessMsg(TRSNode node)
        {
            frmMessageBox frmMsg;
            ReturnMessageString retMsg;
            try
            {

                if (node.StatusValue != MPGC.MP_SUCCESS_STATUS && node.StatusValue != MPGC.MP_WARN_STATUS)
                {
                    return false;
                }

                if (node.StatusValue == MPGC.MP_WARN_STATUS)
                {
                    return true;
                }

                if (node.StatusValue == MPGC.MP_SUCCESS_STATUS && node.MsgCate == MPGC.MP_MSG_CATE_WARN)
                {
                    MPGV.gaWarningMsg.RemoveAt(MPGV.gaWarningMsg.Count - 1);
                }

                if (MPGV.gbShowMsgFlag == false)
                {
                    MPGV.gIMdiForm.SetStatusMessage(node.GetString(TRSDefine.OUT_MSG));
                    return true;
                }

                retMsg = new ReturnMessageString();
                retMsg.IsServerMsgFlag = true;
                retMsg.IsNodeMsgFlag = true;
                retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                {
                    retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                }

                if (node.GetList(TRSDefine.OUT_CSTATUS).Count > 0)
                {
                    retMsg.OutNode = node.GetList(TRSDefine.OUT_CSTATUS);
                }
                frmMsg = new frmMessageBox();
                frmMsg.Show(retMsg, Application.ProductName, MessageBoxButtons.OK, 1, MPGV.gfrmMDI, true);

                retMsg = null;
                frmMsg.Owner = null;
                frmMsg = null;

                MPGV.gaWarningMsg.Clear();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("MPCR.ShowSuccessMsg()\n" + ex.Message);
                return false;
            }
        }


        //need to change after source code merge
        //ask to choi min suk or lim mee hwa !!!!!!!!
        public static WeekInforTag GetWeekInfor(string calendar_id, int year, int month, int day)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_OUT");
            TRSNode row_node;

            WeekInforTag week_tag = new WeekInforTag();
            week_tag.Week = 0;
            string strQuery;

            try
            {
                strQuery = "" +
                    string.Format("SELECT D.PLAN_WEEK, MIN(W.SYS_DATE) WEEK_START_DATE, MAX(W.SYS_DATE) WEEK_END_DATE") + " \r\n" +
                    string.Format(" FROM MWIPCALDEF D, MWIPCALDEF W") + " \r\n" +
                    string.Format("WHERE D.CALENDAR_ID = '{0}'", calendar_id) + " \r\n" +
                    string.Format("AND D.SYS_YEAR = {0}", year) + " \r\n" +
                    string.Format("AND D.SYS_MONTH = {0}", month) + " \r\n" +
                    string.Format("AND D.SYS_DAY = {0}", day) + " \r\n" +
                    string.Format("AND D.CALENDAR_ID = W.CALENDAR_ID") + " \r\n" +
                    string.Format("AND D.SYS_YEAR = W.SYS_YEAR") + " \r\n" +
                    string.Format("AND D.PLAN_WEEK = W.PLAN_WEEK") + " \r\n" +
                    string.Format("GROUP BY D.PLAN_WEEK") + " \r\n" +
                    "";
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", strQuery);

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return week_tag;
                }

                row_node = out_node.GetList(1)[0];


                week_tag.Week = MPCF.ToInt(row_node.GetList(0)[0].GetString("DATA"));
                week_tag.WeekStartDate = row_node.GetList(0)[1].GetString("DATA");
                week_tag.WeekEndDate = row_node.GetList(0)[2].GetString("DATA");

                return week_tag;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return week_tag;
            }
        }



#if _HTTP
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", DeliveryMode.RReply, false);
        }

        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, DeliveryMode mode)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", mode, false);
        }

        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", mode, b_ignore_message);
        }

        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", DeliveryMode.RReply, b_ignore_message);
        }

        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, string channel, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, channel, DeliveryMode.RReply, b_ignore_message);
        }

        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, string channel, DeliveryMode mode, bool b_ignore_message)
        {
            try
            {
                if (MessageCaster.CallService(s_module_name, s_service_name, in_node, ref out_node, channel, 0, mode) == false)
                {
                    // 2009.04.08. Aiden.
                    // b_ignore_message = true ¿Ã¥ı∂Ûµµ ≈ÎΩ≈¡ﬂ πﬂª˝«— ø°∑Ø¥¬ »≠∏Èø° «•Ω√«œµµ∑œ «—¥Ÿ.
                    //if (b_ignore_message == false)
                    MPCF.ShowMsgBox(MPMH.StatusMessage);

                    return false;
                }

                if (b_ignore_message == false)
                {
                    if (MPCR.CheckContinueProc(out_node) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (b_ignore_message == false)
                    MPCF.ShowMsgBox("MPCR.CallService()\n" + ex.Message);

                return false;
            }
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, string channel, int ttl, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, channel, mode, b_ignore_message);
        }


        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, DeliveryMode mode)
        {
            return CallService(s_module_name, s_service_name, in_node, "", false);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, "", false);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, string channel)
        {
            return CallService(s_module_name, s_service_name, in_node, channel, false);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, string channel, bool b_ignore_message)
        {
            if (MessageCaster.CallService(s_module_name, s_service_name, in_node, channel) == false)
            {
                MPCF.ShowMsgBox(MPMH.StatusMessage);
                return false;
            }

            if (in_node.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                if (b_ignore_message == false)
                {
                    MPCR.CheckContinueProc(in_node);
                }
                return false;
            }
            return true;
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, string channel, int ttl, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, channel, b_ignore_message);
        }

#else
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, DeliveryMode.RReply, false);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, DeliveryMode.RReply, b_ignore_message);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, DeliveryMode mode)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, mode, false);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, string channel)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, channel, 0, DeliveryMode.RReply, false);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, mode, b_ignore_message);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, string channel, int ttl, DeliveryMode mode, bool b_ignore_message)
        {
            try
            {
                if (MessageCaster.CallService(s_module_name, s_service_name, in_node, ref out_node, channel, ttl, mode) == false)
                {
                    // 2009.04.08. Aiden.
                    // b_ignore_message = true ¿Ã¥ı∂Ûµµ ≈ÎΩ≈¡ﬂ πﬂª˝«— ø°∑Ø¥¬ »≠∏Èø° «•Ω√«œµµ∑œ «—¥Ÿ.
                    //if (b_ignore_message == false)
                    MPCF.ShowMsgBox(MPMH.StatusMessage);
                    SendSystemErrorReportAlarm(MPMH.StatusMessage, s_service_name, MessageCaster.InXmlString);

                    return false;
                }

                if (b_ignore_message == false)
                {
                    if (MPCR.CheckContinueProc(out_node) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (b_ignore_message == false)
                    MPCF.ShowMsgBox("MPCR.CallService()\n" + ex.Message);

                return false;
            }
        }

        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, DeliveryMode.Multicast, false);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, DeliveryMode.Multicast, b_ignore_message);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, DeliveryMode mode)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, mode, false);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, string channel)
        {
            return CallService(s_module_name, s_service_name, in_node, channel, 0, DeliveryMode.Multicast, false);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, mode, b_ignore_message);
        }
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, string channel, int ttl, DeliveryMode mode, bool b_ignore_message)
        {
            try
            {
                if (MessageCaster.CallService(s_module_name, s_service_name, in_node, channel, ttl, mode) == false)
                {
                    // 2009.04.08. Aiden.
                    // b_ignore_message = true ¿Ã¥ı∂Ûµµ ≈ÎΩ≈¡ﬂ πﬂª˝«— ø°∑Ø¥¬ »≠∏Èø° «•Ω√«œµµ∑œ «—¥Ÿ.
                    //if (b_ignore_message == false)
                    MPCF.ShowMsgBox(MPMH.StatusMessage);
                    SendSystemErrorReportAlarm(MPMH.StatusMessage, s_service_name, MessageCaster.InXmlString);

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                if (b_ignore_message == false)
                    MPCF.ShowMsgBox("MPCR.CallService()\n" + ex.Message);

                return false;
            }
        }
#endif

        public static bool ViewServiceMemberList(Control control, string s_service_name, string s_parent_path)
        {
            int i;
            System.Windows.Forms.ColumnHeader column;
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else
            {
                return false;
            }
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '4';

            in_node.AddString("SERVICE_NAME", s_service_name);
            in_node.AddChar("DIRECTION", 'O');
            in_node.AddString("PARENT_MEMBER_PATH", s_parent_path);

            if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList(0).Count > 0)
            {
                for (i = ((ListView)control).Columns.Count - 1; i >= 0; i--)
                {
                    if (((ListView)control).Columns[i].Tag != null)
                    {
                        if (((ListView)control).Columns[i].Tag.ToString() != "SEQ")
                        {
                            ((ListView)control).Columns.RemoveAt(i);
                        }
                    }
                    else
                    {
                        ((ListView)control).Columns.RemoveAt(i);
                    }
                }

            }
            else
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (control is ListView)
                {
                    column = new System.Windows.Forms.ColumnHeader();
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("MEMBER_PRT")) != "")
                    {
                        column.Text = out_node.GetList(0)[i].GetString("MEMBER_PRT");
                    }
                    else
                    {
                        column.Text = out_node.GetList(0)[i].GetString("MEMBER_NAME");
                    }
                    ((ListView)control).Columns.Add(column);
                    ((ListView)control).Columns[((ListView)control).Columns.Count - 1].Tag = out_node.GetList(0)[i].GetString("MEMBER_NAME");
                }
            }

            return true;
        }

        public static bool ViewFlexibleHeader(Control control, string s_service_name, string s_user_id, string s_dsp_id, string s_parent_path)
        {
            int i;
            System.Windows.Forms.ColumnHeader column;
            TRSNode in_node = new TRSNode("VIEW_FLEXIBLE_HEADER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FLEXIBLE_HEADER_LIST_OUT");

            ViewServiceMemberList(control, s_service_name, s_parent_path);

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);

            }
            else
            {
                return false;
            }
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '3';

            in_node.AddString("SERVICE_NAME", s_service_name);
            in_node.AddString("USER_ID", s_user_id, true);
            in_node.AddString("DSP_ID", s_dsp_id);
            in_node.AddString("PARENT_PATH", s_parent_path);

            if (MPCR.CallService("SEC", "SEC_View_Flexible_Header_List", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList(0).Count > 0)
            {
                for (i = ((ListView)control).Columns.Count - 1; i >= 0; i--)
                {
                    if (((ListView)control).Columns[i].Tag != null)
                    {
                        if (((ListView)control).Columns[i].Tag.ToString() != "SEQ")
                        {
                            ((ListView)control).Columns.RemoveAt(i);
                        }
                    }
                    else
                    {
                        ((ListView)control).Columns.RemoveAt(i);
                    }
                }
            }
            else
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (control is ListView)
                {
                    column = new System.Windows.Forms.ColumnHeader();
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("MEMBER_PRT")) != "")
                    {
                        column.Text = out_node.GetList(0)[i].GetString("MEMBER_PRT");
                    }
                    else
                    {
                        column.Text = out_node.GetList(0)[i].GetString("MEMBER_NAME");
                    }
                    ((ListView)control).Columns.Add(column);
                    ((ListView)control).Columns[((ListView)control).Columns.Count - 1].Tag = out_node.GetList(0)[i].GetString("MEMBER_NAME");
                }
            }

            return true;
        }

        public static bool ViewServiceResult(Control control, TRSNode in_node, ref TRSNode out_node, string s_module, string s_service_name, int i_img_idx)
        {

            int i, j, i_seq;
            ListViewItem itmX;
            string s_item_name;
            TRSNode member;
            string s_value;

            try
            {
                if (MPCR.CallService(s_module, s_service_name, in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem();
                    itmX.ImageIndex = i_img_idx;

                    for (j = 0; j < ((ListView)control).Columns.Count; j++)
                    {
                        s_item_name = MPCF.Trim(((ListView)control).Columns[j].Tag);
                        if (s_item_name.Equals("SEQ"))
                        {
                            i_seq = ((ListView)control).Items.Count + 1;
                            s_value = i_seq.ToString();
                        }
                        else if (s_item_name.IndexOf("TIME") >= 0 || s_item_name.IndexOf("DATE") >= 0)
                        {
                            member = out_node.GetList(0)[i].GetMember(s_item_name);

                            s_value = "";
                            if (member != null)
                            {
                                s_value = MPCF.MakeDateFormat(member.Value);
                            }
                        }
                        else
                        {
                            member = out_node.GetList(0)[i].GetMember(s_item_name);

                            s_value = "";
                            if (member != null)
                            {
                                s_value = member.Value;
                            }
                        }
                        if (j == 0)
                            itmX.Text = s_value;
                        else
                            itmX.SubItems.Add(s_value);
                    }

                    ((ListView)control).Items.Add(itmX);

                }

            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }       

        //
        // ZipCompress
        // - File compress to use GZip library
        // Parameter
        // - string path : Be compressed file path and file name
        // Return value
        // - bool : true or false
        public static bool ZipCompress(string path)
        {
            try
            {
                string sFileName = path + ".xml";

                FileStream fs = new FileStream(sFileName, FileMode.Open);
                byte[] input = new byte[fs.Length];
                fs.Read(input, 0, input.Length);
                fs.Close();

                FileStream fsOutput = new FileStream(path + ".gzip",
                                                     FileMode.Create,
                                                     FileAccess.Write);
                GZipStream zip = new GZipStream(fsOutput, CompressionMode.Compress);

                zip.Write(input, 0, input.Length);
                zip.Close();
                fsOutput.Close();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ZipDecompress
        // - File decompress to use GZip library
        // Parameter
        // - string path : Be decompressed file path and file name
        // Return value
        // - bool : true or false
        public static bool ZipDecompress(string path)
        {
            try
            {
                FileStream fs = new FileStream(path + ".gzip", FileMode.Open);
                FileStream fsOutput = new FileStream(path + ".xml",
                                                     FileMode.Create,
                                                     FileAccess.Write);
                GZipStream zip = new GZipStream(fs, CompressionMode.Decompress, true);

                byte[] buffer = new byte[4096];
                int bytesRead;
                bool continueLoop = true;
                while (continueLoop)
                {
                    bytesRead = zip.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    fsOutput.Write(buffer, 0, bytesRead);
                }
                zip.Close();
                fsOutput.Close();
                fs.Close();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(string S, MessageBoxButtons Buttons, int DefaultFocus, bool ReasonVisible, string ReasonTable, ref string ReasonCode)
        {
            return ShowMsgBox(S, MPGV.gfrmMDI, Application.ProductName, Buttons, DefaultFocus, ReasonVisible, ReasonTable, ref ReasonCode);
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(string S, string Caption, MessageBoxButtons Buttons, int DefaultFocus, bool ReasonVisible, string ReasonTable, ref string ReasonCode)
        {
            return ShowMsgBox(S, MPGV.gfrmMDI, Caption, Buttons, DefaultFocus, ReasonVisible, ReasonTable, ref ReasonCode);
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(string S, Form owner, string Caption, MessageBoxButtons Buttons, int DefaultFocus, bool ReasonVisible, string ReasonTable, ref string ReasonCode)
        {

            try
            {
                if (MPGV.gbShowMsgFlag == false)
                {
                    if (S == MPCF.GetMessage(52))
                    {
                        MPGV.gIMdiForm.SetStatusMessage(S);
                        return DialogResult.None;
                    }
                }

                System.Windows.Forms.DialogResult retValue;
                frmConfirmMessageBox frmMsg = new frmConfirmMessageBox();

                //frmMsg.Owner = owner;
                //frmMsg.lblReason.Visible = true;
                
                //if (IsCodeView == true)
                //{
                //    frmMsg.cdvReason.set = ListItem.Items;

                //    frmMsg.cdvReason.Visible = IsCodeView;
                //    frmMsg.cdvReason.
                //}

                //frmMsg.txtReason.Visible = !IsCodeView;

                retValue = frmMsg.Show(S, Caption, Buttons, DefaultFocus, owner, ReasonVisible, ReasonTable);
                ReasonCode = frmMsg.ReasonCode;
                frmMsg.Owner = null;
                frmMsg = null;

                return retValue;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("MPCR.ShowMsgBox()\n" + ex.Message);
                return DialogResult.None;
            }

        }

        /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
        //
        // ParseResourceID()
        //       - Parse Resource ID from out node
        // Return Value
        //       - String
        // Arguments
        //        - char cStep         : Step (1:Brief, 2:Normal)
        //        - string sStartEnd   : START or END
        //        - TRSNode list_item  : List Item Node
        //
        public static string ParseResourceID(char cStep, string sStartEnd, TRSNode list_item)
        {
            return ParseResourceID(cStep, sStartEnd, list_item, "RES_ID");
        }
        public static string ParseResourceID(char cStep, string sStartEnd, TRSNode list_item, string sExtCol)
        {
            string sRtnVal = String.Empty;
            string sListName = String.Format("{0}_RES_LIST", sStartEnd);
            int i;

            try
            {
                if (cStep != '1' && cStep != '2') return sRtnVal;
                if (sStartEnd == "") return sRtnVal;
                if (list_item == null) return sRtnVal;

                if (list_item.GetList(sListName).Count == 0)
                {
                    if (sStartEnd != "" && sExtCol == "RES_ID")
                        sRtnVal = list_item.GetString(String.Format("{0}_RES_ID", sStartEnd));
                    else
                        sRtnVal = list_item.GetString(sExtCol);
                }
                else
                {
                    switch (cStep)
                    {
                        case '1':
                            for (i = 0; i < list_item.GetList(sListName).Count; i++)
                            {
                                sRtnVal += String.Format("{0}, ", list_item.GetList(sListName)[i].GetString(sExtCol));
                            }
                            if (sRtnVal != "")
                                sRtnVal = sRtnVal.Remove(sRtnVal.LastIndexOf(","));
                            break;

                        case '2':
                            for (i = 0; i < list_item.GetList(sListName).Count; i++)
                            {
                                if (sExtCol == "RES_ID")
                                {
                                    sRtnVal += String.Format("{0} ({1}/{2}/{3})\r\n", list_item.GetList(sListName)[i].GetString(sExtCol),
                                                                                      list_item.GetList(sListName)[i].GetDouble("QTY_1"),
                                                                                      list_item.GetList(sListName)[i].GetDouble("QTY_2"),
                                                                                      list_item.GetList(sListName)[i].GetDouble("QTY_3"));
                                }
                                else
                                {
                                    sRtnVal += String.Format("{0}\r\n", list_item.GetList(sListName)[i].GetString(sExtCol));
                                }
                            }
                            if (sRtnVal != "")
                                sRtnVal = sRtnVal.Remove(sRtnVal.LastIndexOf("\r"));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("MPCR.ParseResourceID()\n" + ex.Message);
            }

            return sRtnVal;
        }
        /*** End of Add (2012.04.09) ***/

        public static void PopupInformNote(TRSNode msg_out_node, string sUserID, string sLotID, string sOper, string sAreaID, string sSubAreaID, string sResID)
        {
            TRSNode out_node;
            frmBBSPopup frmBBSPopup;
            bool b_modeless_flag;
            int i_msg_cnt = 0;

            try
            {
                out_node = msg_out_node;
                if (out_node == null)
                {
                    out_node = new TRSNode("VIEW_BBS_MSG_LIST_OUT");
                    if (BASLIST.ViewBBSMsgList(out_node, sLotID, "", "", sOper, sUserID, sResID, sAreaID, sSubAreaID, (MPCF.Trim(sUserID) == "" ? true : false)) == false)
                    {
                        return;
                    }
                }
                if (out_node == null)
                {
                    return;
                }

                i_msg_cnt = out_node.GetList("MSG_LIST").Count;
                if (i_msg_cnt < 1)
                {
                    return;
                }

                b_modeless_flag = out_node.GetChar("MODELESS_POPUP_FLAG") == 'Y' ? true : false;
                frmBBSPopup = (frmBBSPopup)MPGV.gfrmPopupInformNote;
                if (frmBBSPopup == null)
                {
                    frmBBSPopup = new frmBBSPopup();
                    MPGV.gfrmPopupInformNote = frmBBSPopup;
                }
                else
                {
                    if (b_modeless_flag == false)
                    {
                        b_modeless_flag = true;
                    }
                }

                frmBBSPopup.UserID = MPCF.Trim(sUserID);
                frmBBSPopup.LotID = MPCF.Trim(sLotID);
                frmBBSPopup.Oper = MPCF.Trim(sOper);
                frmBBSPopup.AreaID = MPCF.Trim(sAreaID);
                frmBBSPopup.SubAreaID = MPCF.Trim(sSubAreaID);
                frmBBSPopup.ResID = MPCF.Trim(sResID);
                frmBBSPopup.DisplayMsgList(out_node);

                if (b_modeless_flag == true)
                {
                    frmBBSPopup.Show();
                }
                else
                {
                    // Modal
                    frmBBSPopup.ShowDialog();
                    frmBBSPopup.Dispose();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        public static char GetCurrentShift()
        {
            return GetCurrentShift("");
        }
        public static char GetCurrentShift(string s_ext_factory)
        {
            TRSNode in_node = new TRSNode("CHECK_SHIFT_IN");
            TRSNode out_node = new TRSNode("CHECK_SHIFT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCF.Trim(s_ext_factory) != "")
            {
                in_node.Factory = s_ext_factory;
            }

            if (MPCR.CallService("BAS", "BAS_Check_Shift", in_node, ref out_node) == false)
            {
                return ' ';
            }

            return out_node.GetChar("CURRENT_SHIFT");
        }

        public static bool ViewLotStatusColumnList(ListView listView)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            List<String> ls_col_names;
            ListViewItem itm;
            int r, c;

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = 'MWIPLOTSTS' " +
                                     "       ORDER BY COLUMN_NAME");
            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return false;
            }

            ls_col_names = new List<string>();

            for (r = 0; r < out_node.GetList("ROWS").Count; r++)
            {
                for (c = 0; c < out_node.GetList("COLUMNS").Count; c++)
                {
                    ls_col_names.Add(out_node.GetList("ROWS")[r].GetList("COLS")[c].GetString("DATA"));
                }
            }

            in_node.Init();
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = 'MWIPLOTHIS' AND COLUMN_NAME LIKE 'OLD_%'" +
                                     "       ORDER BY COLUMN_NAME");
            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return false;
            }

            for (r = 0; r < out_node.GetList("ROWS").Count; r++)
            {
                for (c = 0; c < out_node.GetList("COLUMNS").Count; c++)
                {
                    ls_col_names.Add(out_node.GetList("ROWS")[r].GetList("COLS")[c].GetString("DATA"));
                }
            }

            for (r = 0; r < ls_col_names.Count; r++)
            {
                itm = new ListViewItem(ls_col_names[r], (int)SMALLICON_INDEX.IDX_CODE_DATA);
                listView.Items.Add(itm);
            }

            MPCF.FitColumnHeader(listView);

            return true;
        }

        public static bool ViewResourceStatusColumnList(ListView listView)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            List<String> ls_col_names;
            ListViewItem itm;
            int r, c;

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = 'MRASRESDEF' " +
                                     "       ORDER BY COLUMN_NAME");
            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return false;
            }

            ls_col_names = new List<string>();

            for (r = 0; r < out_node.GetList("ROWS").Count; r++)
            {
                for (c = 0; c < out_node.GetList("COLUMNS").Count; c++)
                {
                    ls_col_names.Add(out_node.GetList("ROWS")[r].GetList("COLS")[c].GetString("DATA"));
                }
            }

            in_node.Init();
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = 'MRASRESHIS' AND COLUMN_NAME LIKE 'OLD_%'" +
                                     "       ORDER BY COLUMN_NAME");
            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return false;
            }

            for (r = 0; r < out_node.GetList("ROWS").Count; r++)
            {
                for (c = 0; c < out_node.GetList("COLUMNS").Count; c++)
                {
                    ls_col_names.Add(out_node.GetList("ROWS")[r].GetList("COLS")[c].GetString("DATA"));
                }
            }

            for (r = 0; r < ls_col_names.Count; r++)
            {
                itm = new ListViewItem(ls_col_names[r], (int)SMALLICON_INDEX.IDX_CODE_DATA);
                listView.Items.Add(itm);
            }

            MPCF.FitColumnHeader(listView);

            return true;
        }

        public static bool ViewProcEventStatusColumnList(ListView listView)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            List<String> ls_col_names;
            ListViewItem itm;
            int r, c;

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = 'MWEMEVNSTS' " +
                                     "       ORDER BY COLUMN_NAME");
            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return false;
            }

            ls_col_names = new List<string>();

            for (r = 0; r < out_node.GetList("ROWS").Count; r++)
            {
                for (c = 0; c < out_node.GetList("COLUMNS").Count; c++)
                {
                    ls_col_names.Add(out_node.GetList("ROWS")[r].GetList("COLS")[c].GetString("DATA"));
                }
            }

            for (r = 0; r < ls_col_names.Count; r++)
            {
                itm = new ListViewItem(ls_col_names[r], (int)SMALLICON_INDEX.IDX_CODE_DATA);
                listView.Items.Add(itm);
            }

            MPCF.FitColumnHeader(listView);

            return true;
        }

        public static bool ViewMaterialPropertyColumnList(ListView listView)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            List<String> ls_col_names;
            ListViewItem itm;
            int r, c;

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = 'MWIPMATDEF' " +
                                     "       ORDER BY COLUMN_NAME");
            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return false;
            }

            ls_col_names = new List<string>();

            for (r = 0; r < out_node.GetList("ROWS").Count; r++)
            {
                for (c = 0; c < out_node.GetList("COLUMNS").Count; c++)
                {
                    ls_col_names.Add(out_node.GetList("ROWS")[r].GetList("COLS")[c].GetString("DATA"));
                }
            }

            for (r = 0; r < ls_col_names.Count; r++)
            {
                itm = new ListViewItem(ls_col_names[r], (int)SMALLICON_INDEX.IDX_CODE_DATA);
                listView.Items.Add(itm);
            }

            MPCF.FitColumnHeader(listView);

            return true;
        }

        //Add by Kelly Jung 20120917
        //Lot Extension Update for Transaction Screen
        //Included
        //--Update
        //----Attribute
        //----Lot Extension
        //--Inquiry
        //----Attribute
        //----Lot Extension
        //----Table Data
        public static void SetLotExtInput(FarPoint.Win.Spread.FpSpread spdItemInput, string sLotID, INPUT_VALUE_POINT point_type)
        {
            SetLotExtInput(spdItemInput, "", sLotID, "", 0, "", 0, "", point_type);
        }
        public static void SetLotExtInput(FarPoint.Win.Spread.FpSpread spdItemInput, string sFactory, string sLotID,
                                          string sMatID, int iMatVer, string sFlow, int iFlowSeq, string sOper,
                                          INPUT_VALUE_POINT point_type)
        {
            TRSNode in_node = new TRSNode("VIEW_OPER_INPUT_VALUE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_OPER_INPUT_VALUE_LIST_OUT");
            
            List<TRSNode> value_list;
            int i;
            int i_row;
            int i_argb;

            FarPoint.Win.Spread.CellType.NumberCellType numCell;
            FarPoint.Win.Spread.CellType.TextCellType txtCell;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;
            FarPoint.Win.Spread.CellType.BaseCellType cellType;
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkType;
            char c_val_fmt;
            int i_val_size;
            string s_val_table_name;
            string s_val_value;

            MPCR.SetInMsg(in_node);
            
            in_node.ProcStep = '4';
            in_node.AddString("LOT_ID", sLotID);
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddInt("FLOW_SEQ_NUM", iFlowSeq);
            in_node.AddString("OPER", sOper);
            
            switch (point_type)
            {
                case INPUT_VALUE_POINT.START: in_node.AddChar("POINT_TYPE", 'S'); break;
                case INPUT_VALUE_POINT.END: in_node.AddChar("POINT_TYPE", 'E'); break;
                case INPUT_VALUE_POINT.CREATE: in_node.AddChar("POINT_TYPE", 'C'); break;
                case INPUT_VALUE_POINT.SHIP: in_node.AddChar("POINT_TYPE", 'I'); break;
                case INPUT_VALUE_POINT.RECEIVE: in_node.AddChar("POINT_TYPE", 'V'); break;
                case INPUT_VALUE_POINT.HOLD: in_node.AddChar("POINT_TYPE", 'H'); break;
                case INPUT_VALUE_POINT.RELEASE: in_node.AddChar("POINT_TYPE", 'R'); break;
                case INPUT_VALUE_POINT.SPLIT: in_node.AddChar("POINT_TYPE", 'P'); break;
                case INPUT_VALUE_POINT.MERGE: in_node.AddChar("POINT_TYPE", 'M'); break;
                case INPUT_VALUE_POINT.COMBINE: in_node.AddChar("POINT_TYPE", 'B'); break;
                case INPUT_VALUE_POINT.LOSS: in_node.AddChar("POINT_TYPE", 'L'); break;
                case INPUT_VALUE_POINT.MOVE: in_node.AddChar("POINT_TYPE", 'O'); break;
                case INPUT_VALUE_POINT.REWORK: in_node.AddChar("POINT_TYPE", 'W'); break;
                case INPUT_VALUE_POINT.SKIP: in_node.AddChar("POINT_TYPE", 'K'); break;
                case INPUT_VALUE_POINT.LOTEDC: in_node.AddChar("POINT_TYPE", 'D'); break;
                case INPUT_VALUE_POINT.ADHOC: in_node.AddChar("POINT_TYPE", 'A'); break;
                case INPUT_VALUE_POINT.ADAPT: in_node.AddChar("POINT_TYPE", 'T'); break;
            }
            spdItemInput.ActiveSheet.RowCount = 0;
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Operation_Input_Value_List", in_node, ref out_node) == false)
                {
                    return;
                }

                value_list = out_node.GetList("VALUE_LIST");

                for (i = 0; i < value_list.Count; i++)
                {
                    i_row = spdItemInput.ActiveSheet.RowCount;
                    spdItemInput.ActiveSheet.RowCount++;

                    //Attribute Type
                    spdItemInput.ActiveSheet.Rows[i_row].Tag = value_list[i].GetString("DATA_1");
                    //Attribute Name Desc, Display Text
                    spdItemInput.ActiveSheet.Cells[i_row, 0].Value = value_list[i].GetString("DATA_3");
                    //Attribute Column Name
                    spdItemInput.ActiveSheet.Cells[i_row, 0].Tag = value_list[i].GetString("DATA_2");
                    // A : Attribute, C : Table-Column, X : Lot Extension, P : Just Prompt
                    spdItemInput.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetChar("VALUE_TYPE");

                    // Display Type
                    if (value_list[i].GetString("INPUT_VALUE_TYPE") == "CV")
                        spdItemInput.ActiveSheet.Cells[i_row, 3].Value = 'C';
                    else
                        spdItemInput.ActiveSheet.Cells[i_row, 3].Value = value_list[i].GetChar("DISPLAY_TYPE");

                    //Data Format
                    spdItemInput.ActiveSheet.Cells[i_row, 3].Tag = value_list[i].GetChar("LOT_EXT_FMT").ToString();



                    //Make bold type for Required Field 
                    if (value_list[i].GetChar("REQUIRE_FLAG") == 'Y')
                    {
                        spdItemInput.ActiveSheet.Cells[i_row, 0].Font = new Font(spdItemInput.Font.Name, spdItemInput.Font.Size, FontStyle.Bold);
                    }

                    //Background color setting
                    i_argb = value_list[i].GetInt("BACK_COLOR");
                    spdItemInput.ActiveSheet.Cells[i_row, 1].BackColor = Color.FromArgb(i_argb);
                    if (spdItemInput.ActiveSheet.Cells[i_row, 1].BackColor.GetBrightness() > 0.5)
                    {
                        spdItemInput.ActiveSheet.Cells[i_row, 1].ForeColor = Color.Black;
                    }
                    else
                    {
                        spdItemInput.ActiveSheet.Cells[i_row, 1].ForeColor = Color.White;
                    }


                    //Data Format Mapping
                    c_val_fmt = 'A';
                    i_val_size = 0;
                    s_val_table_name = "";
                    s_val_value = "";

                    // A : Attribute, C : Table-Column, X : Lot Extension
                    if (value_list[i].GetChar("VALUE_TYPE") == 'A')
                    {
                        c_val_fmt = value_list[i].GetChar("ATTR_FMT");
                        i_val_size = value_list[i].GetInt("ATTR_SIZE");
                        s_val_value = value_list[i].GetString("ATTR_VALUE");

                        if (value_list[i].GetChar("DISPLAY_TYPE") != 'V')
                        {
                            s_val_table_name = value_list[i].GetString("VALID_TBL");
                        }
                    }
                    else if (value_list[i].GetChar("VALUE_TYPE") == 'C')
                    {
                        s_val_value = value_list[i].GetString("COLUMN_VALUE");
                        i_val_size = 4000;
                    }
                    else if (value_list[i].GetChar("VALUE_TYPE") == 'X')
                    {
                        c_val_fmt = value_list[i].GetChar("LOT_EXT_FMT");
                        i_val_size = value_list[i].GetInt("LOT_EXT_SIZE");
                        s_val_value = value_list[i].GetString("LOT_EXT_VALUE");

                        if (value_list[i].GetChar("DISPLAY_TYPE") != 'V')
                        {
                            s_val_table_name = value_list[i].GetString("VALID_TBL");
                        }
                    }

                    cellType = null;
                    if (c_val_fmt == 'A' || c_val_fmt == 'C')
                    {
                        txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                        txtCell.MaxLength = i_val_size;

                        cellType = txtCell;
                    }
                    else if (c_val_fmt == 'N' || c_val_fmt == 'F')
                    {
                        numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                        numCell.ShowSeparator = true;
                        numCell.DecimalPlaces = 0;
                        if (c_val_fmt == 'F')
                        {
                            numCell.DecimalPlaces = 3;
                        }

                        cellType = numCell;
                    }

                    if (value_list[i].GetString("CMF_1") == "CHK")
                    {
                        checkType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                        spdItemInput.ActiveSheet.Cells[i_row, 2].CellType = checkType;
                        spdItemInput.ActiveSheet.Cells[i_row, 2].Value = false;
                    }
                    else if (s_val_table_name == "")
                    {
                        spdItemInput.ActiveSheet.Cells[i_row, 1].ColumnSpan = 2;
                    }
                    else
                    {
                        btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        btnCell.Text = "...";
                        spdItemInput.ActiveSheet.Cells[i_row, 2].CellType = btnCell;
                        spdItemInput.ActiveSheet.Cells[i_row, 2].Tag = s_val_table_name;
                    }

                    spdItemInput.ActiveSheet.Cells[i_row, 1].CellType = cellType;
                    spdItemInput.ActiveSheet.Cells[i_row, 1].Value = s_val_value;

                    //Set Display Only
                    if (value_list[i].GetChar("DISPLAY_TYPE") == 'V')
                    {
                        spdItemInput.ActiveSheet.Cells[i_row, 1].ForeColor = SystemColors.ControlText;
                        spdItemInput.ActiveSheet.Cells[i_row, 1].BackColor = SystemColors.Control;
                        spdItemInput.ActiveSheet.Cells[i_row, 1].Locked = true;
                    }
                    else if (value_list[i].GetChar("DISPLAY_TYPE") == 'I')
                    {
                        spdItemInput.ActiveSheet.Rows[i_row].Visible = false;
                    }

                }//end for

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);

            //SetUseCount(1);
            //SetCurrentTime();
            spdItemInput.ActiveSheet.Columns[0].BackColor = SystemColors.Control;
            spdItemInput.Refresh();

            MPCF.FitColumnHeader(spdItemInput, 0, 0);

            return;
        }


        //Add by Kelly Jung 20121107
        //Lot Extension Update for Transaction Screen
        //Included
        //--Update
        //----Attribute
        //----Lot Extension
        //--Inquiry
        //----Attribute
        //----Lot Extension
        //----Table Data
        public static bool SetLotExtFill(FarPoint.Win.Spread.FpSpread spdItemInput, string sLotID, TRSNode in_node)
        {
            int i;
            bool b_ext_exist;

            b_ext_exist = false;
            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag) != "X") continue;
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) != "U" && MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) != "C") continue;

                b_ext_exist = true;
                break;
            }

            if (b_ext_exist == false)
            {
                return true;
            }

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag) != "X") continue;
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) != "U" && MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) != "C") continue;
                if (spdItemInput.ActiveSheet.Cells[i, 0].Font == null) continue;
                if (spdItemInput.ActiveSheet.Cells[i, 0].Font.Bold == false) continue;
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Value) != "") continue;

                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                spdItemInput.ActiveSheet.SetActiveCell(i, 1);
                spdItemInput.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                spdItemInput.Focus();
                return false;
            }


            TRSNode ext_node;
            string s_ext_col_name;
            string s_ext_col_type;
            string s_ext_col_value;

            ext_node = in_node.AddNode("LOT_EXT");
            ext_node.AddString("LOT_ID", MPCF.Trim(sLotID));

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag) != "X") continue;
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) != "U" && MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) != "C") continue;

                s_ext_col_name = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Tag);
                s_ext_col_type = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Tag);
                s_ext_col_value = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Value);

                switch (s_ext_col_type)
                {
                    case "A":
                        if (spdItemInput.ActiveSheet.Cells[i, 1].ColumnSpan != 2)
                        {
                            if (spdItemInput.ActiveSheet.Cells[i, 2].CellType.ToString() == "CheckBoxCellType")
                            {
                                if ((bool)spdItemInput.ActiveSheet.Cells[i, 2].Value == true)
                                {
                                    s_ext_col_value = "Y" + " - " + s_ext_col_value;
                                }
                                else
                                {
                                    s_ext_col_value = "N" + " - " + s_ext_col_value;
                                }
                            }
                        }

                        if (s_ext_col_name.Length > 7)
                        {
                            if (s_ext_col_name.Substring(0, 7) == "OPER_WR")
                            {
                                //s_ext_col_value = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Value) + " : " + s_ext_col_value;
                                s_ext_col_value = MPCF.Trim(s_ext_col_value);
                            }
                        }

                        ext_node.AddString(s_ext_col_name, s_ext_col_value);
                        break;
                    case "C":
                        ext_node.AddChar(s_ext_col_name, s_ext_col_value);
                        break;
                    case "N":
                        ext_node.AddInt(s_ext_col_name, s_ext_col_value);
                        break;
                    case "F":
                        ext_node.AddDouble(s_ext_col_name, s_ext_col_value);
                        break;
                }
            }

            return true;
        }

        public static bool SetLotAttrFill(FarPoint.Win.Spread.FpSpread spdItemInput, TRSNode in_node)
        {
            int i;
            bool b_attr_exist;

            b_attr_exist = false;
            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag) != "A") continue;
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) == "V") continue;

                b_attr_exist = true;
                break;
            }

            if (b_attr_exist == false)
            {
                return true;
            }

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag) != "A") continue;
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) == "V") continue;
                if (spdItemInput.ActiveSheet.Cells[i, 0].Font == null) continue;
                if (spdItemInput.ActiveSheet.Cells[i, 0].Font.Bold == false) continue;
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Value) != "") continue;

                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                spdItemInput.ActiveSheet.SetActiveCell(i, 1);
                spdItemInput.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                spdItemInput.Focus();
                return false;
            }


            clsAttributeHandler cah = new clsAttributeHandler();

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag) != "A") continue;
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) == "V") continue;

                cah.addAttribute(MPCF.Trim(spdItemInput.ActiveSheet.Rows[i].Tag),
                                    in_node,
                                    MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Tag),
                                    MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Value));
            }

            cah.setAttributeValue(in_node);

            return true;
        }

        public static bool IsBinCollectionOper(String s_lot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_BY_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_BY_LOT_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);
                in_node.AddChar("CHECK_BIN_OPER_FLAG", 'Y');

                if (MPCR.CallService("WIP", "WIP_View_Bin_By_Lot", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                if (out_node.GetChar("USE_BIN_FLAG") != 'Y') return false;
                if (out_node.GetChar("BIN_RESULT_FLAG") == 'P') return false;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public static string GetAttributeValue(string s_attr_type, string s_attr_name, string s_attr_key)
        {
            return GetAttributeValue(s_attr_type, s_attr_name, s_attr_key, "");
        }

        public static string GetAttributeValue(string s_attr_type, string s_attr_name, string s_attr_key, string s_ext_factory)
        {
            TRSNode in_node = new TRSNode("VIEW_ATTRIBUTE_VALUE_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTRIBUTE_VALUE_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCF.Trim(s_ext_factory) != "")
            {
                in_node.Factory = s_ext_factory;
            }

            in_node.AddString("ATTR_TYPE", s_attr_type);
            in_node.AddString("ATTR_NAME", s_attr_name);
            in_node.AddString("ATTR_KEY", s_attr_key);

            if (MPCR.CallService("BAS", "BAS_View_Attribute_Value", in_node, ref out_node) == false)
            {
                return "";
            }

            if (out_node.GetList("VALUE_LIST").Count < 1)
            {
                return "";
            }

            return out_node.GetList("VALUE_LIST")[0].GetString("ATTR_VALUE");
        }
        
        public static int GetDataCountBySQL(string s_sql)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            byte[] bsq = System.Text.Encoding.UTF8.GetBytes(s_sql);
            in_node.AddBlob(MPGC.MP_BIN_DATA_1, bsq);

            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node, true) == false)
            {
                return 0;
            }

            if (out_node.GetList("ROWS").Count < 1)
            {
                return 0;
            }

            return MPCF.ToInt(out_node.GetList("ROWS")[0].GetList("COLS")[0].GetString("DATA"));
        }

        public static void ParseSequenceInfo(string s_string, ref string s_id, ref int i_seq)
        {
            string s_trim_string;
            string[] s_desc_trim_string;
            string s_sequence;
            int i_seq_delimeter_start;
            int i_seq_delimeter_end;

            s_id = "";
            i_seq = 0;
            /* Updated By YJJung 151211 Bug Fix Flow≥™ Material Desc ø° (,)∞° ∆˜«‘µ» ∞ÊøÏ Error πﬂª˝*/
            s_desc_trim_string = s_string.ToString().Split(':');
            s_trim_string = MPCF.Trim(s_desc_trim_string[0].ToString());
            if(s_trim_string == "") return;
            
            i_seq_delimeter_start = s_trim_string.LastIndexOf('(');
            i_seq_delimeter_end = s_trim_string.LastIndexOf(')');
            if (i_seq_delimeter_start < 0)
            {
                s_id = s_trim_string;
                return;
            }

            s_id = s_trim_string.Substring(0, i_seq_delimeter_start).Trim();
            s_sequence = s_trim_string.Substring(i_seq_delimeter_start + 1, i_seq_delimeter_end - i_seq_delimeter_start - 1).Trim();
            i_seq = MPCF.ToInt(s_sequence);
        }

        private static bool SendSystemErrorReportAlarm(string s_error_msg, string s_service_name, string s_in_xml)
        {
            /* 2013.06.12. Aiden. Middleware ∞° ªÁøÎ∞°¥…«—¡ˆ »Æ¿Œ */
            if (MPIF.gInit.IsAvailableSendMessage == false)
            {
                return true;
            }
            
            TRSNode in_node = new TRSNode("RAISE_ALARM_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            List<string> xml_list;

            xml_list = MPCF.ByteSplit(s_in_xml, 800);

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.Factory = MPGV.gsCentralFactory;

                in_node.AddString("ALARM_ID", "SysErrReportAlarm");
                in_node.AddString("ALARM_MSG", s_error_msg);

                in_node.AddString("LOT_ID", MPGV.gsCurrentLot_ID);
                in_node.AddString("RES_ID", MPGV.gsCurrentRes_ID);

                if (MPGV.gfrmMDI.ActiveMdiChild == null)
                {
                    if (MPGV.gfrmMDI.OwnedForms == null)
                    {
                        in_node.AddString("SOURCE_ID_1", MPGV.gfrmMDI.Text);
                    }
                    else
                    {
                        in_node.AddString("SOURCE_ID_1", MPGV.gfrmMDI.OwnedForms[0].Text);
                    }
                }
                else
                {
                    in_node.AddString("SOURCE_ID_1", MPGV.gfrmMDI.ActiveMdiChild.Text);
                }

                in_node.AddString("SOURCE_DESC_1", s_service_name);
                in_node.AddString("SOURCE_ID_2", "TTL:" + MPGV.giTimeOut.ToString());
                in_node.AddString("SOURCE_DESC_2", "SiteID:" + MPGV.gsSiteID);
                in_node.AddString("SOURCE_ID_3", MPGV.gsUserID);

                if (xml_list.Count > 0)
                {
                    in_node.AddString("ALARM_COMMENT_1", xml_list[0]);
                }
                if (xml_list.Count > 1)
                {
                    in_node.AddString("ALARM_COMMENT_2", xml_list[1]);
                }
                if (xml_list.Count > 2)
                {
                    in_node.AddString("ALARM_COMMENT_3", xml_list[2]);
                }
                if (xml_list.Count > 3)
                {
                    in_node.AddString("ALARM_COMMENT_4", xml_list[3]);
                }
                if (xml_list.Count > 4)
                {
                    in_node.AddString("ALARM_COMMENT_5", xml_list[4]);
                }

                if (MessageCaster.CallService("ALM", "ALM_Raise_Alarm", in_node, ref out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Method to test if the control or it's parent is in design mode
        /// </summary>
        /// <param name="control">Control to examine</param>
        /// <returns>True if in design mode, otherwise false</returns>
        public static bool IsInDesignMode(System.Windows.Forms.Control control)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return true;
            else
            {
                Control ctrl = control;

                while (ctrl != null)
                {
                    if (ctrl.Site != null && ctrl.Site.DesignMode)
                        return true;
                    ctrl = ctrl.Parent;
                }

                return System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
            }
        }
        

    } // end of class MPCR

    public class clsAttributeHandler
    {
        private class AttrValueTag
        {
            public string s_attr_name;
            public string s_attr_value;
        }

        private class AttrTypeTag
        {
            public string s_attr_type;
            public string s_attr_key;
            public List<AttrValueTag> values;
        }

        private List<AttrTypeTag> types;

        private AttrTypeTag findAttrType(string s_attr_type)
        {
            if (types == null)
            {
                types = new List<AttrTypeTag>();
            }

            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].s_attr_type == s_attr_type)
                {
                    return types[i];
                }
            }

            AttrTypeTag att = new AttrTypeTag();
            att.values = new List<AttrValueTag>();

            att.s_attr_type = s_attr_type;

            types.Add(att);

            return att;
        }

        public void addAttribute(string s_attr_type, TRSNode in_node, string s_attr_name, string s_attr_value)
        {
            AttrTypeTag att = findAttrType(s_attr_type);
            if (MPCF.Trim(att.s_attr_key) == "")
            {
                switch (s_attr_type)
                {
                    case MPGC.MP_ATTR_TYPE_LOT:
                        att.s_attr_key = in_node.GetString("LOT_ID");
                        break;
                    case MPGC.MP_ATTR_TYPE_MATERIAL:
                        att.s_attr_key = in_node.GetString("MAT_ID") + " : " + in_node.GetInt("MAT_VER").ToString();
                        break;
                    case MPGC.MP_ATTR_TYPE_FLOW:
                        att.s_attr_key = in_node.GetString("FLOW");
                        break;
                    case MPGC.MP_ATTR_TYPE_OPER:
                        att.s_attr_key = in_node.GetString("OPER");
                        break;
                    case MPGC.MP_ATTR_TYPE_RESOURCE:
                        att.s_attr_key = in_node.GetString("RES_ID");
                        break;
                    case MPGC.MP_ATTR_TYPE_FACTORY:
                        att.s_attr_key = in_node.GetString("FACTORY");
                        break;
                }
            }

            AttrValueTag atv = new AttrValueTag();
            atv.s_attr_name = s_attr_name;
            atv.s_attr_value = s_attr_value;

            att.values.Add(atv);
        }

        public void setAttributeValue(TRSNode in_node)
        {
            TRSNode attr_node;
            TRSNode value_node;

            for (int i = 0; i < types.Count; i++)
            {
                attr_node = in_node.AddNode("INPUT_ATTRIBUTE");
                MPCR.SetInMsg(attr_node);
                attr_node.ProcStep = '1';

                attr_node.AddString("ATTR_TYPE", types[i].s_attr_type);
                attr_node.AddString("ATTR_KEY", types[i].s_attr_key);

                for (int k = 0; k < types[i].values.Count; k++)
                {
                    value_node = attr_node.AddNode("VALUE_LIST");
                    value_node.AddString("ATTR_NAME", types[i].values[k].s_attr_name);
                    value_node.AddString("ATTR_VALUE", types[i].values[k].s_attr_value);
                }
            }
        }
    }


    #region "Creates a message filter Class"

    public class MESClientMessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            // Blocks all the messages relating to the left mouse button.
            if (MPGV.gbProcessCaster == true)
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (m.Msg)
                {
                    case 0x100: //KEYDOWN

                        return true;
                    case 0x201: //LBUTTONDOWN

                        return true;
                    case 0xA1: //NCLBUTTONDOWN

                        return true;
                }
            }

            return false;
        }
    }

    #endregion

    #region "Derived Parameter Class"

    public class clsDerivedCharList
    {
        private System.Collections.ArrayList a_derived_chars;

        public clsDerivedCharList()
        {
            a_derived_chars = new System.Collections.ArrayList();
        }

        public bool GetDerivedInfo(string s_col_set_id, int i_col_set_ver, string s_lot_id, string s_res_id, string s_override_lot_id, string s_override_res_id)
        {
            TRSNode in_node = new TRSNode("VIEW_DERIVED_CHARACTER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DERIVED_CHARACTER_LIST_OUT");
            int i;
            int j;
            clsDerivedChar cdc;
            int i_value_count;

            try
            {
                a_derived_chars.Clear();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COL_SET_ID", s_col_set_id);
                in_node.AddInt("COL_SET_VERSION", i_col_set_ver);
                in_node.AddString("LOT_ID", s_lot_id);
                in_node.AddString("RES_ID", s_res_id);
                in_node.AddString("OVERRIDE_LOT_ID", s_override_lot_id);
                in_node.AddString("OVERRIDE_RES_ID", s_override_res_id);

                if (MPCR.CallService("EDC", "EDC_View_Derived_Character_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    i_value_count = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                    for (j = 0; j < i_value_count; j++)
                    {
                        if (out_node.GetList(0)[i].GetString("DERIVED_PARAMETER") != "")
                        {
                            cdc = new clsDerivedChar();
                            cdc.SetDerivedCharInfo(out_node.GetList(0)[i], j);
                            a_derived_chars.Add(cdc);
                        }                   
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public void SetCharLocation(string s_char_id, FarPoint.Win.Spread.SheetView sheet, int i_index, int i_row, int i_col)
        {
            int i;
            clsDerivedChar cdc;

            for (i = 0; i < a_derived_chars.Count; i++)
            {
                cdc = (clsDerivedChar)a_derived_chars[i];

                if (s_char_id.Equals(cdc.ToString()) && i_index.Equals(cdc.GetIndex()))
                {
                    cdc.SetSheetInfo(sheet, i_row, i_col);
                    break;
                }
            }
        }

        public void SetValue(string s_char_id, int i_unit_seq, System.Collections.ArrayList a_values, bool b_auto_calculation)
        {
            int i;
            clsDerivedChar cdc;

            for (i = 0; i < a_derived_chars.Count; i++)
            {
                cdc = (clsDerivedChar)a_derived_chars[i];
                cdc.SetSourceValue(s_char_id, i_unit_seq, a_values, b_auto_calculation,i+1);
            }
        }
    }

    public class clsDerivedChar
    {
        private struct SOURCE_CHAR_INFO
        {
            public string s_value_type;
            public string s_char_id;
            public int i_unit_seq;
            public string s_calc_type;
            public int i_value_seq;
            public string s_value;
            public string s_value2;
            public string s_value3;
            public string s_value4;
            public string s_value5;
            public string s_value6;
            public string s_value7;
            public string s_value8;
            public string s_value9;
            public string s_value10;
            public string s_value11;
            public string s_value12;
            public string s_value13;
            public string s_value14;
            public string s_value15;
            public string s_value16;
            public string s_value17;
            public string s_value18;
            public string s_value19;
            public string s_value20;
            public string s_value21;
            public string s_value22;
            public string s_value23;
            public string s_value24;
            public string s_value25;
        }

        private string s_derived_char_id;
        private string[] s_formula;

        private System.Collections.ArrayList a_source_chars;
        private FarPoint.Win.Spread.SheetView sheet;
        private int i_row;
        private int i_col;
        private int i_value_index;

        public clsDerivedChar()
        {
            a_source_chars = new System.Collections.ArrayList();
        }

        public override string ToString()
        {
            return s_derived_char_id;
        }

        public int GetIndex()
        {
            return i_value_index;
        }

        public void SetIndex(int i_index)
        {
            this.i_value_index = i_index;
        }

        public void SetSheetInfo(FarPoint.Win.Spread.SheetView sheet, int i_row, int i_col)
        {
            this.sheet = sheet;
            this.i_row = i_row;
            this.i_col = i_col;
        }

        public void SetDerivedCharInfo(TRSNode char_item, int i_index)
        {
            int i;
            int i_fml_index;
            string s_derived_param;
            List<TRSNode> fml_list;

            s_derived_char_id = char_item.GetString("CHAR_ID");
            s_derived_param = char_item.GetString("DERIVED_PARAMETER");
            SetIndex(i_index);

            fml_list = char_item.GetList("FORMULA_LIST");
            s_formula = s_derived_param.Split('|');

            a_source_chars.Clear();

            i_fml_index = 0;
            for (i = 0; i < s_formula.Length; i++)
            {
                if (s_formula[i][0] == '@')
                {
                    s_formula[i] = s_formula[i].Substring(1);
                }

                if (s_formula[i][0] == '#')
                {
                    AddSourceChar(fml_list[i_fml_index].GetString("VALUE_TYPE"),
                                  fml_list[i_fml_index].GetString("USE_CHAR_ID"),
                                  fml_list[i_fml_index].GetInt("USE_UNIT_SEQ"),
                                  fml_list[i_fml_index].GetString("CALC_TYPE"),
                                  fml_list[i_fml_index].GetInt("USE_VALUE_SEQ"),
                                  fml_list[i_fml_index].GetString("VALUE"),
                                  fml_list[i_fml_index].GetString("VALUE_2"),
                                  fml_list[i_fml_index].GetString("VALUE_3"),
                                  fml_list[i_fml_index].GetString("VALUE_4"),
                                  fml_list[i_fml_index].GetString("VALUE_5"),
                                  fml_list[i_fml_index].GetString("VALUE_6"),
                                  fml_list[i_fml_index].GetString("VALUE_7"),
                                  fml_list[i_fml_index].GetString("VALUE_8"),
                                  fml_list[i_fml_index].GetString("VALUE_9"),
                                  fml_list[i_fml_index].GetString("VALUE_10"),
                                  fml_list[i_fml_index].GetString("VALUE_11"),
                                  fml_list[i_fml_index].GetString("VALUE_12"),
                                  fml_list[i_fml_index].GetString("VALUE_13"),
                                  fml_list[i_fml_index].GetString("VALUE_14"),
                                  fml_list[i_fml_index].GetString("VALUE_15"),
                                  fml_list[i_fml_index].GetString("VALUE_16"),
                                  fml_list[i_fml_index].GetString("VALUE_17"),
                                  fml_list[i_fml_index].GetString("VALUE_18"),
                                  fml_list[i_fml_index].GetString("VALUE_19"),
                                  fml_list[i_fml_index].GetString("VALUE_20"),
                                  fml_list[i_fml_index].GetString("VALUE_21"),
                                  fml_list[i_fml_index].GetString("VALUE_22"),
                                  fml_list[i_fml_index].GetString("VALUE_23"),
                                  fml_list[i_fml_index].GetString("VALUE_24"),
                                  fml_list[i_fml_index].GetString("VALUE_25")) ;
                    i_fml_index++;
                }
            }
        }

        public void SetSourceValue(string s_char_id, int i_unit_seq, System.Collections.ArrayList a_values, bool b_auto_calculation, int i_col_seq)
        {
            int i;
            int k;
            int i_value_count;
            bool b_calc;
            SOURCE_CHAR_INFO st_info;

            double d_value;
            double d_value_max;
            double d_value_min;
            double d_value_sum;

            b_calc = false;
            for (i = 0; i < a_source_chars.Count; i++)
            {
                st_info = (SOURCE_CHAR_INFO)a_source_chars[i];

                if (st_info.s_value_type.Equals("CC"))
                {
                    if (st_info.s_char_id.Equals(s_char_id) && st_info.i_unit_seq == i_unit_seq)
                    {
                        if (st_info.s_calc_type.Equals("OV"))
                        {
                            if (st_info.i_value_seq <= a_values.Count)
                            {
                                if (st_info.i_value_seq == 0)
                                {
                                    if (MPCF.Trim(a_values[i_value_index]) == "")
                                    {
                                        return;
                                    }
                                    st_info.s_value = MPCF.Trim(a_values[i_value_index]);
                                }
                                else
                                {
                                    if (MPCF.Trim(a_values[st_info.i_value_seq - 1]) == "")
                                    {
                                        return;
                                    }
                                    st_info.s_value = MPCF.Trim(a_values[st_info.i_value_seq - 1]);
                                }                                
                            }
                        }
                        else
                        {
                            i_value_count = 0;
                            d_value = 0;
                            d_value_max = 0;
                            d_value_min = 0;
                            d_value_sum = 0;

                            for (k = 0; k < a_values.Count; k++)
                            {
                                if (MPCF.Trim(a_values[k]) == "")
                                {
                                    continue;
                                }

                                i_value_count++;

                                d_value = MPCF.ToDbl(a_values[k]);
                                d_value_sum += d_value;

                                if (i_value_count == 1)
                                {
                                    d_value_max = d_value;
                                    d_value_min = d_value;
                                }

                                if (d_value_max < d_value)
                                {
                                    d_value_max = d_value;
                                }
                                if (d_value_min > d_value)
                                {
                                    d_value_min = d_value;
                                }
                            }

                            if (i_value_count < 1)
                            {
                                return;
                            }

                            switch (st_info.s_calc_type)
                            {
                                case "AV":
                                    st_info.s_value = MPCF.Trim(d_value_sum / i_value_count);
                                    break;
                                case "SM":
                                    st_info.s_value = d_value_sum.ToString();
                                    break;
                                case "MN":
                                    st_info.s_value = d_value_min.ToString();
                                    break;
                                case "MX":
                                    st_info.s_value = d_value_max.ToString();
                                    break;
                                case "VC":
                                    st_info.s_value = i_value_count.ToString();
                                    break;
                            }
                        }

                        a_source_chars[i] = st_info;
                        b_calc = true;
                    }
                }
            }

            if (b_calc == true && b_auto_calculation == true)
            {
                CalculateValue(i_col_seq);
            }
        }

        private void AddSourceChar(string s_value_type, string s_char_id, int i_unit_seq, string s_calc_type, int i_value_seq,string s_value, 
            string s_value2, string s_value3, string s_value4, string s_value5, string s_value6, string s_value7, string s_value8, string s_value9, 
            string s_value10, string s_value11, string s_value12, string s_value13, string s_value14, string s_value15, string s_value16, string s_value17,
            string s_value18, string s_value19, string s_value20, string s_value21, string s_value22, string s_value23, string s_value24, string s_value25)
        {
            SOURCE_CHAR_INFO st_info = new SOURCE_CHAR_INFO();
            string s_seq_value = string.Empty;

            st_info.s_value_type = s_value_type;
            st_info.s_char_id = s_char_id;
            st_info.i_unit_seq = i_unit_seq;
            st_info.s_calc_type = s_calc_type;
            st_info.i_value_seq = i_value_seq;

            if (i_value_seq != 0)
            {
                s_seq_value = s_value;

                st_info.s_value = s_seq_value;
                st_info.s_value2 = s_seq_value;
                st_info.s_value3 = s_seq_value;
                st_info.s_value4 = s_seq_value;
                st_info.s_value5 = s_seq_value;
                st_info.s_value6 = s_seq_value;
                st_info.s_value7 = s_seq_value;
                st_info.s_value8 = s_seq_value;
                st_info.s_value9 = s_seq_value;
                st_info.s_value10 = s_seq_value;
                st_info.s_value11 = s_seq_value;
                st_info.s_value12 = s_seq_value;
                st_info.s_value13 = s_seq_value;
                st_info.s_value14 = s_seq_value;
                st_info.s_value15 = s_seq_value;
                st_info.s_value16 = s_seq_value;
                st_info.s_value17 = s_seq_value;
                st_info.s_value18 = s_seq_value;
                st_info.s_value19 = s_seq_value;
                st_info.s_value20 = s_seq_value;
                st_info.s_value21 = s_seq_value;
                st_info.s_value22 = s_seq_value;
                st_info.s_value23 = s_seq_value;
                st_info.s_value24 = s_seq_value;
                st_info.s_value25 = s_seq_value;
            }
            else
            {
            st_info.s_value = s_value;
                st_info.s_value2 = s_value2;
                st_info.s_value3 = s_value3;
                st_info.s_value4 = s_value4;
                st_info.s_value5 = s_value5;
                st_info.s_value6 = s_value6;
                st_info.s_value7 = s_value7;
                st_info.s_value8 = s_value8;
                st_info.s_value9 = s_value9;
                st_info.s_value10 = s_value10;
                st_info.s_value11 = s_value11;
                st_info.s_value12 = s_value12;
                st_info.s_value13 = s_value13;
                st_info.s_value14 = s_value14;
                st_info.s_value15 = s_value15;
                st_info.s_value16 = s_value16;
                st_info.s_value17 = s_value17;
                st_info.s_value18 = s_value18;
                st_info.s_value19 = s_value19;
                st_info.s_value20 = s_value20;
                st_info.s_value21 = s_value21;
                st_info.s_value22 = s_value22;
                st_info.s_value23 = s_value23;
                st_info.s_value24 = s_value24;
                st_info.s_value25 = s_value25;
            }

            a_source_chars.Add(st_info);
        }

        private void CalculateValue(int i_col_seq)
        {
            int i;
            int i_src_idx;
            string s_fml;
            StringBuilder sb;
            SOURCE_CHAR_INFO st_info;
            string s_value;
            double d_value;

            sb = new StringBuilder();

            sb.Append("SELECT TO_CHAR(TO_NUMBER(");

            i_src_idx = 0;
            for (i = 0; i < s_formula.Length; i++)
            {
                if (s_formula[i][0] == '#')
                {
                    st_info = (SOURCE_CHAR_INFO)a_source_chars[i_src_idx];

                    switch (st_info.s_value_type)
                    {
                        case "OC":
                            switch (i_col_seq)
                            {
                                case 1:
                                    sb.Append(st_info.s_value);
                                    break;
                                case 2:
                                    sb.Append(st_info.s_value2);
                                    break;
                                case 3:
                                    sb.Append(st_info.s_value3);
                                    break;
                                case 4:
                                    sb.Append(st_info.s_value4);
                                    break;
                                case 5:
                                    sb.Append(st_info.s_value5);
                                    break;
                                case 6:
                                    sb.Append(st_info.s_value6);
                                    break;
                                case 7:
                                    sb.Append(st_info.s_value7);
                                    break;
                                case 8:
                                    sb.Append(st_info.s_value8);
                                    break;
                                case 9:
                                    sb.Append(st_info.s_value9);
                                    break;
                                case 10:
                                    sb.Append(st_info.s_value10);
                                    break;
                                case 11:
                                    sb.Append(st_info.s_value11);
                                    break;
                                case 12:
                                    sb.Append(st_info.s_value12);
                                    break;
                                case 13:
                                    sb.Append(st_info.s_value13);
                                    break;
                                case 14:
                                    sb.Append(st_info.s_value14);
                                    break;
                                case 15:
                                    sb.Append(st_info.s_value15);
                                    break;
                                case 16:
                                    sb.Append(st_info.s_value16);
                                    break;
                                case 17:
                                    sb.Append(st_info.s_value17);
                                    break;
                                case 18:
                                    sb.Append(st_info.s_value18);
                                    break;
                                case 19:
                                    sb.Append(st_info.s_value19);
                                    break;
                                case 20:
                                    sb.Append(st_info.s_value20);
                                    break;
                                case 21:
                                    sb.Append(st_info.s_value21);
                                    break;
                                case 22:
                                    sb.Append(st_info.s_value22);
                                    break;
                                case 23:
                                    sb.Append(st_info.s_value23);
                                    break;
                                case 24:
                                    sb.Append(st_info.s_value24);
                                    break;
                                case 25:
                                    sb.Append(st_info.s_value25);
                                    break;
                            }
                            break;

                        case "CV":
                        case "LS":
                        case "LA":
                        case "CC":
                            sb.Append(st_info.s_value);
                            break;

                        case "OT":
                        case "LB":
                        case "RB":
                            sb.Append(s_formula[i].Substring(1));
                            break;
                    }

                    i_src_idx++;
                }
                else
                {
                    sb.Append(s_formula[i]);
                }
            }
            // Aiden. 2011.04.21. Exponential ∞™¿ª «•Ω√«ÿæﬂ «œ¥¬ ∞ÊøÏµµ ¿÷¿∏π«∑Œ ∞°∞¯«œ¡ˆ æ ∞Ì «•Ω√«œµµ∑œ ∫Ø∞Ê
            //sb.Append("),'9999999999.99999') FROM DUAL");
            sb.Append(")) FROM DUAL");

            s_fml = sb.ToString();

            d_value = 0;

            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SQL", s_fml);
            if (MessageCaster.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == true)
            {
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    // ∞™¿Ã ¿‘∑¬µ«¡ˆ æ ¿∫ ∞ÊøÏ ∞¯πÈ¿Ãπ«∑Œ ∞ËªÍΩƒø°º≠ ø°∑Ø∞° πﬂª˝«“ ºˆ ¿÷¥Ÿ.
                    // µ˚∂Ûº≠ ø°∑Øø° ¥Î«ÿ π´Ω√«œ∞Ì ¡¯«‡«œµµ∑œ æ∆∑° πÆ¿Â¿ª ¡÷ºÆ√≥∏Æ
                    //MPCR.CheckContinueProc(out_node);
                    return;
                }

                if (out_node.GetList("ROWS").Count > 0)
                {
                    if (out_node.GetList("ROWS")[0].GetList("COLS").Count > 0)
                    {
                        s_value = out_node.GetList("ROWS")[0].GetList("COLS")[0].GetString("DATA");
                        d_value = MPCF.ToDbl(s_value);
                    }
                }
            }

            sheet.Cells[i_row, i_col].Value = d_value;
        }
    }

    #endregion

}
