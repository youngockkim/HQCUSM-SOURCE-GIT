using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.RAS
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmRASResourceEvent : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode FACTORY = new TRSNode("FACTORY_INFO");

        private const char CHANGE = 'Y';
        private const char NOTCHANGE = 'N';
        private const char INCREASE = '+';
        private const char DECREASE = '-';
        private const char OVERRIDE = 'O';
        private const char TIME = 'T';
        
        private const int CHAR_COL = 0;
        private const int CHAR_DESC_COL = 1;
        private const int SPEC_COL = 2;
        private const int OPT_INPUT_COL = 3;
        private const int VALUE_TYPE_COL = 4;
        private const int VALUE_COUNT_COL = 5;
        private const int DEF_UNIT_OVR_FLAG_COL = 6;
        private const int DEF_VALUE_COL = 7;
        private const int UNIT_TBL_COL = 8;
        private const int VALUE_TBL_COL = 9;
        private const int UNIT_SEQ_COL = 10;
        private const int UNIT_COL = 11;
        private const int VALUE_1_COL = 12;
        private const int VALUE_START_COL = 12;
        private const int MAX_VALUE_COUNT = 25;
        private const int MAX_DATA_COUNT = 5000;
        private const int OUT_SEQ = 0;
        private const int OUT_CHAR = 1;
        private const int OUT_UNIT_ID = 2;
        private const int OUT_RULE_TYPE = 3;
        private const int OUT_RULE_DESC = 4;
        
        private EdcDataInfo charData;

        #endregion

        #region Constructor

        public frmRASResourceEvent()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        ///  작업표준 지도서
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbStdOper_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                if (MPCF.RunStandardOperationView(string.Empty, 0, string.Empty, string.Empty, cdvResID.Text) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Resource ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };
                string[] header = new string[] { "Res ID", "Res Desc" };

                // Show CodeView and Get Return
                cdvResID.Text = cdvResID.Show(cdvResID, "View Resource List", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "Res ID");

                // Field Clear
                MPCF.FieldClear(this, cdvResID);

                // Validation
                if (string.IsNullOrEmpty(cdvResID.Text) == true)
                {
                    return;
                }

                // View Resource
                if (ViewResource(cdvResID.Text) == false)
                {
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvEventID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Event ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvEventID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESEVENT_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("NEXT_RES_ID", cdvResID.Text);
                in_node.AddChar("RES_TYPE", 'M');

                // Display and Header Text Setup
                string[] display = new string[] { "EVENT_ID", "EVENT_DESC" };
                string[] header = new string[] { "Event ID", "Event Desc" };

                // Show CodeView and Get Return
                cdvEventID.Text = cdvEventID.Show(cdvEventID, "View Resource Event", "RAS", "RAS_View_ResEvent_List", in_node, "EVENT_LIST", display, header, "Event ID");

                // Field Clear
                MPCF.FieldClear(txtEventDesc);
                MPCF.FieldClear(soiPanel11);

                // Validation
                if (string.IsNullOrEmpty(cdvEventID.Text) == true)
                {
                    return;
                }
                
                // View
                if (ViewEvent(cdvEventID.Text) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }            
        }

        /// <summary>
        /// Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvEventID, false) == false)
                {
                    return;
                }

                // Event
                if (ResourceEvent('1') == false)
                {
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvEventID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Collapse Status Controls
        /// </summary>
        private void CollapseStatusControls()
        {
            try
            {
                lblSts1.Visible = false;
                txtSts1Cur.Visible = false;
                txtSts1New.Visible = false;

                lblSts2.Visible = false;
                txtSts2Cur.Visible = false;
                txtSts2New.Visible = false;

                lblSts3.Visible = false;
                txtSts3Cur.Visible = false;
                txtSts3New.Visible = false;

                lblSts4.Visible = false;
                txtSts4Cur.Visible = false;
                txtSts4New.Visible = false;

                lblSts5.Visible = false;
                txtSts5Cur.Visible = false;
                txtSts5New.Visible = false;

                lblSts6.Visible = false;
                txtSts6Cur.Visible = false;
                txtSts6New.Visible = false;

                lblSts7.Visible = false;
                txtSts7Cur.Visible = false;
                txtSts7New.Visible = false;

                lblSts8.Visible = false;
                txtSts8Cur.Visible = false;
                txtSts8New.Visible = false;

                lblSts9.Visible = false;
                txtSts9Cur.Visible = false;
                txtSts9New.Visible = false;

                lblSts10.Visible = false;
                txtSts10Cur.Visible = false;
                txtSts10New.Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Factory 정보 중 RES_STS 정보를 조회 합니다.
        /// </summary>
        private bool ViewFactory()
        {
            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            try
            {
                // Clear
                FACTORY.Init();

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (MPCF.CallService("WIP", "WIP_View_Factory", in_node, ref FACTORY) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }        
        }

        /// <summary>
        /// Set Visible For Prompt Control
        /// </summary>
        /// <param name="label"></param>
        /// <param name="labelText"></param>
        /// <param name="beforeTextBox"></param>
        /// <param name="afterTextBox"></param>
        /// <param name="visible"></param>
        private void SetPromtVisible(SOILabel label, SOITextBox beforeTextBox, SOITextBox afterTextBox, string labelText)
        {
            if (label == null || beforeTextBox == null || afterTextBox == null)
            {
                return;
            }
            
            label.Text = MPCF.Trim(labelText);

            if (string.IsNullOrEmpty(labelText) == true)
            {
                label.Visible = false;
                beforeTextBox.Visible = false;
                afterTextBox.Visible = false;
            }
            else
            {
                label.Visible = true;
                beforeTextBox.Visible = true;
                afterTextBox.Visible = true;
            }
        }

        /// <summary>
        /// View Resource
        /// </summary>
        /// <param name="sResId"></param>
        /// <returns></returns>
        private bool ViewResource(string sResId)
        {
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

            try
            {
                // Init Control
                CollapseStatusControls();

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", sResId);
                if (MPCF.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                txtResDesc.Text = MPCF.Trim(out_node.GetString("RES_DESC"));
                if (MPCF.Trim(out_node.GetChar("RES_UP_DOWN_FLAG")) == "U")
                {
                    txtUpDownCur.Text = "UP";
                }
                else if (MPCF.Trim(out_node.GetChar("RES_UP_DOWN_FLAG")) == "D")
                {
                    txtUpDownCur.Text = "DOWN";
                }
                txtLastEvent.Text = MPCF.Trim(out_node.GetString("LAST_EVENT_ID"));
                txtLastEventTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_EVENT_TIME"));
                txtPriCur.Text = MPCF.Trim(out_node.GetString("RES_PRI_STS"));
                txtSts1Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                txtSts1Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                txtSts1Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                txtSts4Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                txtSts5Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                txtSts6Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                txtSts7Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                txtSts8Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                txtSts9Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                txtSts10Cur.Text = MPCF.Trim(out_node.GetString("RES_STS_10"));

                // Factory or Resource Prompt 
                if (out_node.GetChar("USE_FAC_PRT_FLAG") == 'Y')
                {
                    // Factory Prompt
                    if (ViewFactory() == false)
                    {
                        return false;
                    }

                    SetPromtVisible(lblSts1, txtSts1Cur, txtSts1New, FACTORY.GetString("RES_STS_1"));
                    SetPromtVisible(lblSts2, txtSts2Cur, txtSts2New, FACTORY.GetString("RES_STS_2"));
                    SetPromtVisible(lblSts3, txtSts3Cur, txtSts3New, FACTORY.GetString("RES_STS_3"));
                    SetPromtVisible(lblSts4, txtSts4Cur, txtSts4New, FACTORY.GetString("RES_STS_4"));
                    SetPromtVisible(lblSts5, txtSts5Cur, txtSts5New, FACTORY.GetString("RES_STS_5"));
                    SetPromtVisible(lblSts6, txtSts6Cur, txtSts6New, FACTORY.GetString("RES_STS_6"));
                    SetPromtVisible(lblSts7, txtSts7Cur, txtSts7New, FACTORY.GetString("RES_STS_7"));
                    SetPromtVisible(lblSts8, txtSts8Cur, txtSts8New, FACTORY.GetString("RES_STS_8"));
                    SetPromtVisible(lblSts9, txtSts9Cur, txtSts9New, FACTORY.GetString("RES_STS_9"));
                    SetPromtVisible(lblSts10, txtSts10Cur, txtSts10New, FACTORY.GetString("RES_STS_10"));
                }
                else
                {
                    SetPromtVisible(lblSts1, txtSts1Cur, txtSts1New, out_node.GetString("RES_STS_PRT_1"));
                    SetPromtVisible(lblSts2, txtSts2Cur, txtSts2New, out_node.GetString("RES_STS_PRT_2"));
                    SetPromtVisible(lblSts3, txtSts3Cur, txtSts3New, out_node.GetString("RES_STS_PRT_3"));
                    SetPromtVisible(lblSts4, txtSts4Cur, txtSts4New, out_node.GetString("RES_STS_PRT_4"));
                    SetPromtVisible(lblSts5, txtSts5Cur, txtSts5New, out_node.GetString("RES_STS_PRT_5"));
                    SetPromtVisible(lblSts6, txtSts6Cur, txtSts6New, out_node.GetString("RES_STS_PRT_6"));
                    SetPromtVisible(lblSts7, txtSts7Cur, txtSts7New, out_node.GetString("RES_STS_PRT_7"));
                    SetPromtVisible(lblSts8, txtSts8Cur, txtSts8New, out_node.GetString("RES_STS_PRT_8"));
                    SetPromtVisible(lblSts9, txtSts9Cur, txtSts9New, out_node.GetString("RES_STS_PRT_9"));
                    SetPromtVisible(lblSts10, txtSts10Cur, txtSts10New, out_node.GetString("RES_STS_PRT_10"));
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Change Status Input
        /// </summary>
        /// <param name="out_node"></param>
        /// <param name="ThisMoment"></param>
        /// <param name="index"></param>
        /// <param name="lbl"></param>
        /// <param name="txtNew"></param>
        /// <param name="txtCur"></param>
        private void ChangeStatusInput(TRSNode out_node, DateTime ThisMoment, int index, SOILabel lbl, SOITextBox txtNew, SOITextBox txtCur)
        {
            try
            {
                char cChangeFlag;
                string sMemberName;
                string sChangeValue;

                if (index == 0)
                {
                    cChangeFlag = out_node.GetChar("CHG_PRI_STS_FLAG");
                    sChangeValue = out_node.GetString("CHG_PRI_STS");

                    if (cChangeFlag == OVERRIDE)
                    {
                        //if (MPCF.Trim(out_node.GetString("TBL_PRI_STS")) != "")
                        //{
                        //    cdvPrimaryChange.VisibleButton = true;
                        //    cdvPrimaryChange.Tag = out_node.GetString("TBL_PRI_STS");
                        //}
                        //else
                        //{
                        //    cdvPrimaryChange.VisibleButton = false;
                        //}

                        txtNew.Text = sChangeValue;
                        txtNew.ReadOnly = false;
                    }
                    else
                    {
                        txtNew.ReadOnly = true;
                        if (cChangeFlag == CHANGE)
                        {
                            txtNew.Text = sChangeValue;
                        }
                        else if (cChangeFlag == INCREASE)
                        {
                            txtNew.Text = Convert.ToString((MPCF.ToDbl(txtCur.Text) + MPCF.ToDbl(sChangeValue)));
                        }
                        else if (cChangeFlag == DECREASE)
                        {
                            txtNew.Text = Convert.ToString((MPCF.ToDbl(txtCur.Text) - MPCF.ToDbl(sChangeValue)));
                        }
                        else if (cChangeFlag == TIME)
                        {
                            txtNew.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                        }
                        else //if (out_node.GetChar("CHG_PRI_STS_FLAG") == NOTCHANGE)
                        {
                            txtNew.Text = txtPriCur.Text;
                        }
                    }
                }
                else
                {
                    if (lbl.Visible == true)
                    {
                        sMemberName = "CHG_FLAG_" + index.ToString();
                        cChangeFlag = out_node.GetChar(sMemberName);

                        sMemberName = "CHG_STS_" + index.ToString();
                        sChangeValue = out_node.GetString(sMemberName);

                        if (cChangeFlag == OVERRIDE)
                        {
                            //if (MPCF.Trim(out_node.GetString("TBL_1")) != "")
                            //{
                            //    cdvChangeStatus1.VisibleButton = true;
                            //    cdvChangeStatus1.Tag = out_node.GetString("TBL_1");
                            //}
                            //else
                            //{
                            //    cdvChangeStatus1.VisibleButton = false;
                            //}

                            txtNew.Text = sChangeValue;
                            txtNew.ReadOnly = false;
                        }
                        else
                        {
                            txtNew.ReadOnly = true;
                            if (cChangeFlag == CHANGE)
                            {
                                txtNew.Text = sChangeValue;
                            }
                            else if (cChangeFlag == INCREASE)
                            {
                                txtNew.Text = Convert.ToString((MPCF.ToDbl(txtCur.Text) + MPCF.ToDbl(sChangeValue)));
                            }
                            else if (cChangeFlag == DECREASE)
                            {
                                txtNew.Text = Convert.ToString((MPCF.ToDbl(txtCur.Text) - MPCF.ToDbl(sChangeValue)));
                            }
                            else if (cChangeFlag == TIME)
                            {
                                txtNew.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                            }
                            else //if (cChangeFlag == NOTCHANGE)
                            {
                                txtNew.Text = txtCur.Text;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Find Col Set Version
        /// </summary>
        /// <returns></returns>
        private bool FindColSetVersion()
        {
            TRSNode in_node = new TRSNode("FIND_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("FIND_COL_SET_VERSION_OUT");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("COL_SET_ID", txtCollectionSet.Text);
                in_node.AddChar("LOT_OR_RES_FLAG", 'R');
                if (MPCF.CallService("EDC", "EDC_Find_Col_Set_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtColSetVer.Text = out_node.GetInt("COL_SET_VERSION").ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Attach Character List
        /// </summary>
        /// <returns></returns>
        private bool ViewAttachCharacterList()
        {
            TRSNode in_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_OUT");
            List<TRSNode> CharList;
            List<TRSNode> UnitList;

            try
            {
                // Init
                for (int i = 13; i >= 4; i--)
                {
                    spdData.ActiveSheet.Columns[i].Visible = true;
                }

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '5';
                in_node.AddChar("INCLUDE_UNIT_ID", 'Y');
                in_node.AddString("COL_SET_ID", txtCollectionSet.Text);
                in_node.AddInt("COL_SET_VERSION", txtColSetVer.Text);
                in_node.AddString("RES_ID", cdvResID.Text);
                if (MPCF.CallService("EDC", "EDC_View_Attach_Character_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Draw
                int iCharSeq = 0;
                int iUnitCount = 0;
                int iCharUnitSum = 0;
                int iMaxValueCnt = 0;
                string sDefaultValue;
                string sUnitTbl;
                string sValueTbl;
                char cDefUnitFlag;
                char cDefUnitOvrFlag;

                Color EditableCellBackColor = new Color();
                Color LockCellBackColor = new Color();

                EditableCellBackColor = MPGV.gTheme.SpreadCellEditableBackColor;
                LockCellBackColor = MPGV.gTheme.SpreadCellReadOnlyBackColor;

                MPCF.ClearList(this.spdData);
                CharList = out_node.GetList("CHAR_LIST");
                foreach (TRSNode CharInfo in CharList)
                {
                    iCharSeq++;
                    iUnitCount = CharInfo.GetInt("UNIT_COUNT");
                    UnitList = CharInfo.GetList("UNIT_LIST");
                    sDefaultValue = CharInfo.GetString("DEF_VALUE");
                    cDefUnitFlag = CharInfo.GetChar("DEF_UNIT_FLAG");
                    cDefUnitOvrFlag = CharInfo.GetChar("DEF_UNIT_OVR_FLAG");
                    sUnitTbl = CharInfo.GetString("UNIT_TBL");
                    sValueTbl = CharInfo.GetString("VALUE_TBL");

                    for (int iUnitSeq = 0; iUnitSeq < iUnitCount; iUnitSeq++)
                    {
                        charData = new EdcDataInfo(iCharSeq, CharInfo.GetString("CHAR_ID"), CharInfo.GetString("CHAR_DESC"),
                                                                            GetSpecInfo(CharInfo.GetString("UPPER_SPEC_LIMIT"),
                                                                            CharInfo.GetString("LOWER_SPEC_LIMIT"), CharInfo.GetString("TARGET_VALUE")), iUnitSeq + 1);

                        string sUnitId = "";
                        if (UnitList.Count < 1)
                        {
                            switch (cDefUnitFlag)
                            {
                                case 'C':
                                    sUnitId = CharInfo.GetString("UNIT");
                                    if (sUnitId == "")
                                    {
                                        sUnitId = "*";
                                    }
                                    break;

                                case 'E':
                                    sUnitId = "NULL";
                                    break;
                            }
                        }
                        else
                        {
                            if (cDefUnitFlag == 'Y')
                            {
                                if (UnitList[iUnitSeq].GetChar("NULL_FLAG") == 'Y')
                                {
                                    sUnitId = "NULL";
                                }
                                else
                                {
                                    sUnitId = UnitList[iUnitSeq].GetString("DEF_UNIT_ID");
                                }
                            }
                        }

                        spdData.ActiveSheet.RowCount++;
                        charData.UnitId = sUnitId;
                        charData.ValueCount = CharInfo.GetInt("VALUE_COUNT");
                        charData.ValueType = CharInfo.GetChar("VALUE_TYPE");

                        charData.V1_backColor = LockCellBackColor;
                        charData.V2_backColor = LockCellBackColor;
                        charData.V3_backColor = LockCellBackColor;
                        charData.V4_backColor = LockCellBackColor;
                        charData.V5_backColor = LockCellBackColor;
                        charData.V6_backColor = LockCellBackColor;
                        charData.V7_backColor = LockCellBackColor;
                        charData.V8_backColor = LockCellBackColor;
                        charData.V9_backColor = LockCellBackColor;
                        charData.V10_backColor = LockCellBackColor;

                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 6].BackColor = charData.V1_backColor;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 7].BackColor = charData.V2_backColor;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 8].BackColor = charData.V3_backColor;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 9].BackColor = charData.V4_backColor;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 10].BackColor = charData.V5_backColor;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 11].BackColor = charData.V6_backColor;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 12].BackColor = charData.V7_backColor;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 13].BackColor = charData.V8_backColor;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 14].BackColor = charData.V9_backColor;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 15].BackColor = charData.V10_backColor;

                        if (charData.ValueCount > 10)
                        {
                            charData.V1_input = true;
                            charData.V2_input = true;
                            charData.V3_input = true;
                            charData.V4_input = true;
                            charData.V5_input = true;
                            charData.V6_input = true;
                            charData.V7_input = true;
                            charData.V8_input = true;
                            charData.V9_input = true;
                            charData.V10_input = true;

                            charData.V1_backColor = EditableCellBackColor;
                            charData.V2_backColor = EditableCellBackColor;
                            charData.V3_backColor = EditableCellBackColor;
                            charData.V4_backColor = EditableCellBackColor;
                            charData.V5_backColor = EditableCellBackColor;
                            charData.V6_backColor = EditableCellBackColor;
                            charData.V7_backColor = EditableCellBackColor;
                            charData.V8_backColor = EditableCellBackColor;
                            charData.V9_backColor = EditableCellBackColor;
                            charData.V10_backColor = EditableCellBackColor;

                            if (sDefaultValue != "")
                            {
                                charData.V1 = sDefaultValue;
                                charData.V2 = sDefaultValue;
                                charData.V3 = sDefaultValue;
                                charData.V4 = sDefaultValue;
                                charData.V5 = sDefaultValue;
                                charData.V6 = sDefaultValue;
                                charData.V7 = sDefaultValue;
                                charData.V8 = sDefaultValue;
                                charData.V9 = sDefaultValue;
                                charData.V10 = sDefaultValue;
                            }

                            charData.ValueCount = 10;
                        }
                        else
                        {
                            if (charData.ValueCount >= 1)
                            {
                                charData.V1_input = true;
                                charData.V1_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V1 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 6].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 6].BackColor = charData.V1_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 6].Value = charData.V1;
                            }
                            if (charData.ValueCount >= 2)
                            {
                                charData.V2_input = true;
                                charData.V2_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V2 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 7].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 7].BackColor = charData.V2_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 7].Value = charData.V2;
                            }
                            if (charData.ValueCount >= 3)
                            {
                                charData.V3_input = true;
                                charData.V3_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V3 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 8].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 8].BackColor = charData.V3_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 8].Value = charData.V3;
                            }
                            if (charData.ValueCount >= 4)
                            {
                                charData.V4_input = true;
                                charData.V4_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V4 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 9].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 9].BackColor = charData.V4_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 9].Value = charData.V4;
                            }
                            if (charData.ValueCount >= 5)
                            {
                                charData.V5_input = true;
                                charData.V5_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V5 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 10].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 10].BackColor = charData.V5_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 10].Value = charData.V5;
                            }
                            if (charData.ValueCount >= 6)
                            {
                                charData.V6_input = true;
                                charData.V6_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V6 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 11].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 11].BackColor = charData.V6_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 11].Value = charData.V6;
                            }
                            if (charData.ValueCount >= 7)
                            {
                                charData.V7_input = true;
                                charData.V7_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V7 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 12].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 12].BackColor = charData.V7_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 12].Value = charData.V7;
                            }
                            if (charData.ValueCount >= 8)
                            {
                                charData.V8_input = true;
                                charData.V8_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V8 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 13].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 13].BackColor = charData.V8_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 13].Value = charData.V8;
                            }
                            if (charData.ValueCount >= 9)
                            {
                                charData.V9_input = true;
                                charData.V9_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V9 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 14].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 14].BackColor = charData.V9_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 14].Value = charData.V9;
                            }
                            if (charData.ValueCount >= 10)
                            {
                                charData.V10_input = true;
                                charData.V10_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V10 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 15].Locked = false;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 15].BackColor = charData.V10_backColor;
                                spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 15].Value = charData.V10;
                            }
                            if (iMaxValueCnt > charData.ValueCount)
                            {
                                for (int i = 0; i < iMaxValueCnt - charData.ValueCount; i++)
                                {
                                    spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 6 + charData.ValueCount + i].Locked = true;
                                }
                            }
                        }

                        if (charData.ValueCount > iMaxValueCnt)
                        {
                            iMaxValueCnt = charData.ValueCount;
                        }

                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 0].Value = charData.CharId;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 1].Value = charData.CharDesc;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 2].Value = charData.Spec;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 3].Value = charData.UnitSeq;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 4].Value = charData.ValueCount;
                        spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 5].Value = charData.UnitId;

                    }

                    iCharUnitSum = spdData.ActiveSheet.RowCount - 1;
                }

                for (int i = 6 + iMaxValueCnt; i < 16; i++)
                {
                    spdData.ActiveSheet.Columns[i].Visible = false;
                }

                // V1 ~ V10 컬럼에 대하여
                for (int i = 6; i < 16; i++)
                {
                    // 보이는 컬럼이 존재하는 경우
                    if (spdData.ActiveSheet.Columns[i].Visible == true)
                    {
                        //// 입력 로우가 없는 경우
                        //if (spdData.ActiveSheet.Rows[0] == null
                        //    || spdData.ActiveSheet.Rows[0, i]== null)
                        //{
                        //    break;
                        //}
                        //// 입력 로우가 있는 경우
                        //else
                        //{
                        //    //ctrlXamGrid.Rows[0].Cells[i].IsActive = true;
                        //    //spdData.ActiveSheet.Rows[0, i]

                        //    break;
                        //}
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Event
        /// </summary>
        /// <param name="sEventId"></param>
        /// <returns></returns>
        private bool ViewEvent(string sEventId)
        {
            TRSNode in_node = new TRSNode("VIEW_EVENT_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_OUT");
            DateTime ThisMoment = DateTime.Now;

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("EVENT_ID", sEventId);
                if (MPCF.CallService("RAS", "RAS_View_Event", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                txtEventDesc.Text = MPCF.Trim(out_node.GetString("EVENT_DESC"));
                if (out_node.GetChar("CHG_UP_DOWN_FLAG") == CHANGE)
                {
                    if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "U")
                    {
                        txtUpDownNew.Text = "UP";
                    }
                    else if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "D")
                    {
                        txtUpDownNew.Text = "DOWN";
                    }
                }
                else
                {
                    txtUpDownNew.Text = txtUpDownCur.Text;
                }

                ChangeStatusInput(out_node, ThisMoment, 0, null, txtPriNew, txtPriCur);
                ChangeStatusInput(out_node, ThisMoment, 1, lblSts1, txtSts1New, txtSts1Cur);
                ChangeStatusInput(out_node, ThisMoment, 2, lblSts2, txtSts2New, txtSts2Cur);
                ChangeStatusInput(out_node, ThisMoment, 3, lblSts3, txtSts3New, txtSts3Cur);
                ChangeStatusInput(out_node, ThisMoment, 4, lblSts4, txtSts4New, txtSts4Cur);
                ChangeStatusInput(out_node, ThisMoment, 5, lblSts5, txtSts5New, txtSts5Cur);
                ChangeStatusInput(out_node, ThisMoment, 6, lblSts6, txtSts6New, txtSts6Cur);
                ChangeStatusInput(out_node, ThisMoment, 7, lblSts7, txtSts7New, txtSts7Cur);
                ChangeStatusInput(out_node, ThisMoment, 8, lblSts8, txtSts8New, txtSts8Cur);
                ChangeStatusInput(out_node, ThisMoment, 9, lblSts9, txtSts9New, txtSts9Cur);
                ChangeStatusInput(out_node, ThisMoment, 10, lblSts10, txtSts10New, txtSts10Cur);
                                
                if (MPCF.Trim(out_node.GetString("COL_SET_ID")) != "")
                {
                    txtCollectionSet.Text = MPCF.Trim(out_node.GetString("COL_SET_ID"));

                    if (FindColSetVersion() == false)
                    {
                        return false;
                    }

                    if (ViewAttachCharacterList() == false)
                    {
                        return false;
                    }
                }
                else
                {
                    txtCollectionSet.Text = "";
                    txtColSetVer.Text = "";
                    MPCF.ClearList(this.spdData);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Get Spect Info
        /// </summary>
        /// <param name="sUSL"></param>
        /// <param name="sLSL"></param>
        /// <param name="sTarget"></param>
        /// <returns></returns>
        private string GetSpecInfo(string sUSL, string sLSL, string sTarget)
        {
            try
            {
                string sSpec;
                sSpec = " ";

                if (MPCF.Trim(sUSL) == "" && MPCF.Trim(sLSL) == "")
                {
                    if (MPCF.Trim(sTarget) != "")
                    {
                        sSpec += sTarget;
                    }
                }
                else
                {
                    if (MPCF.Trim(sTarget) != "")
                    {
                        if (MPCF.Trim(sUSL) != "" && MPCF.Trim(sLSL) != "")
                        {
                            if (MPCF.CheckNumeric(sTarget) == true && MPCF.CheckNumeric(sUSL) == true && MPCF.CheckNumeric(sLSL) == true)
                            {
                                if (MPCF.ToDbl(sUSL) - MPCF.ToDbl(sTarget) == MPCF.ToDbl(sTarget) - MPCF.ToDbl(sLSL))
                                {
                                    sSpec += MPCF.Trim(sTarget) + " +/- " + ((double)(MPCF.ToDbl(sUSL) - MPCF.ToDbl(sTarget))).ToString("#######,##0.#####");
                                }
                                else
                                {
                                    sSpec += MPCF.Trim(sLSL) + " ~ " + MPCF.Trim(sTarget) + " ~ " + MPCF.Trim(sUSL);
                                }
                            }
                            else
                            {
                                sSpec += MPCF.Trim(sLSL) + " ~ " + MPCF.Trim(sTarget) + " ~ " + MPCF.Trim(sUSL);
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(sUSL) != "")
                            {
                                if (MPCF.CheckNumeric(sUSL) == true)
                                {
                                    sSpec += MPCF.Trim(sTarget) + " + " + ((double)(MPCF.ToDbl(sUSL) - MPCF.ToDbl(sTarget))).ToString("#######,##0.#####");
                                }
                                else
                                {
                                    sSpec += MPCF.Trim(sTarget) + " ~ " + MPCF.Trim(sUSL);
                                }
                            }
                            else if (MPCF.Trim(sLSL) != "")
                            {
                                if (MPCF.CheckNumeric(sLSL) == true)
                                {
                                    sSpec += MPCF.Trim(sTarget) + " - " + ((double)(MPCF.ToDbl(sTarget) - MPCF.ToDbl(sLSL))).ToString("#######,##0.#####");
                                }
                                else
                                {
                                    sSpec += MPCF.Trim(sLSL) + " ~ " + MPCF.Trim(sTarget);
                                }
                            }
                        }
                    }
                    else
                    {
                        sSpec += MPCF.Trim(sLSL) + " ~ " + MPCF.Trim(sUSL);
                    }

                }

                return sSpec;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return string.Empty;
            }
        }

        /// <summary>
        /// Fill Collection Data
        /// </summary>
        /// <param name="in_node"></param>
        /// <returns></returns>
        private bool FillCollectionData(ref TRSNode in_node, char ProcStep)
        {
            int i;
            int j;
            TRSNode collect_res_data, char_item, unit_item, value_item;
            CultureInfo ci_inter = new CultureInfo("en-US");

            try
            {
                // COLLECT_RES_DATA 
                collect_res_data = in_node.AddNode("COLLECT_RES_DATA");

                MPCF.SetInMsg(collect_res_data);
                collect_res_data.ProcStep = MPCF.ToChar(ProcStep);
                collect_res_data.AddString("RES_ID", cdvResID.Text);
                collect_res_data.AddString("EVENT_ID", cdvEventID.Text);
                collect_res_data.AddString("COL_SET_ID", MPCF.Trim(txtCollectionSet.Text));
                collect_res_data.AddInt("COL_SET_VERSION", MPCF.ToInt(txtColSetVer.Text));
                
                // CHAR_LIST
                char_item = collect_res_data.AddNode("CHAR_LIST");
                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    // CHAR_ID
                    if (MPCF.ToInt(spdData.ActiveSheet.GetValue(i, 3)) == 1)
                    {
                        if (i != 0)
                        {
                            char_item = collect_res_data.AddNode("CHAR_LIST");
                        }

                        char_item.AddString("CHAR_ID", spdData.ActiveSheet.GetValue(i, 0));
                    }

                    // UNIT_LIST
                    unit_item = char_item.AddNode("UNIT_LIST");
                    unit_item.AddString("UNIT_ID", spdData.ActiveSheet.GetValue(i, 5));
                    unit_item.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, 3)));

                    for (j = 0; j < MPCF.ToInt(spdData.ActiveSheet.Cells[i, 4].Value); j++)
                    {
                        // VALUE_LIST
                        value_item = unit_item.AddNode("VALUE_LIST");

                        if (charData.ValueType == 'N' && MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, j + 6)) == true)
                        {
                            value_item.AddString("VALUE", MPCF.ToDbl(spdData.ActiveSheet.GetValue(i, j + 6)).ToString(ci_inter.NumberFormat));
                        }
                        else
                        {
                            value_item.AddString("VALUE", MPCF.Trim(spdData.ActiveSheet.GetValue(i, j + 6)));
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

        /// <summary>
        /// Resource Event
        /// </summary>
        /// <param name="cProcStep"></param>
        /// <returns></returns>
        private bool ResourceEvent(char cProcStep)
        {
            TRSNode in_node = new TRSNode("RESOURCE_EVENT_IN");
            TRSNode out_node = new TRSNode("RESOURCE_EVENT_OUT");
            
            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("EVENT_ID", cdvEventID.Text);
                in_node.AddString("CHG_PRI_STS", txtPriNew.Text);
                in_node.AddString("CHG_STS_1", txtSts1New.Text);
                in_node.AddString("CHG_STS_2", txtSts2New.Text);
                in_node.AddString("CHG_STS_3", txtSts3New.Text);
                in_node.AddString("CHG_STS_4", txtSts4New.Text);
                in_node.AddString("CHG_STS_5", txtSts5New.Text);
                in_node.AddString("CHG_STS_6", txtSts6New.Text);
                in_node.AddString("CHG_STS_7", txtSts7New.Text);
                in_node.AddString("CHG_STS_8", txtSts8New.Text);
                in_node.AddString("CHG_STS_9", txtSts9New.Text);
                in_node.AddString("CHG_STS_10", txtSts10New.Text);
                in_node.AddString("TRAN_COMMENT", txtComment.Text);

                if (txtCollectionSet.Text != "" || spdData.ActiveSheet.RowCount > 1)
                {
                    if (FillCollectionData(ref in_node, cProcStep) == false)
                    {
                        return false;
                    }
                }

#if _H101
                if (MPCF.CallService("RAS", "RAS_Resource_Event", in_node, ref out_node, "", 0, SOI.MsgHandlerH101.DeliveryMode.RReply, true) == false)
                {
                    //return false;
                }     
#endif
#if _Http
                if (MPCF.CallService("RAS", "RAS_Resource_Event", in_node, ref out_node, "", 0, SOI.MsgHandlerHTTP.DeliveryMode.RReply, true, false) == false)
                {
                    //return false;
                }
#endif

                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCF.CheckContinueProc(out_node, false);
                    return false;
                }

                if (cProcStep == '1')
                {                   
                    DialogResult result;

                    bool bSpecOut = DrawSpecOutMask(out_node);

                    if (bSpecOut == true)
                    {
                        result = MPCF.ShowMsgBox(out_node.GetString(TRSDefine.OUT_MSG), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING);

                        if (result != DialogResult.Yes)  // Data Non-commit Case
                        {
                            return false;
                        }
                    }

                    if (ResourceEvent('4') == false)
                    {
                        return false;
                    }
                }
                else
                {
                    // Field Clear
                    MPCF.FieldClear(this, cdvResID);

                    // View Resource
                    if (ViewResource(cdvResID.Text) == false)
                    {
                        return false;
                    }

                    // Clear Field
                    ClearField(1);
                }

                MPCF.ShowSuccessMessage(out_node, false);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Clear Field
        /// </summary>
        /// <param name="iCase"></param>
        private void ClearField(int iCase)
        {
            switch (iCase)
            {
                case 1:
                    cdvEventID.Text = "";
                    txtEventDesc.Text = "";
                    txtUpDownNew.Text = "";
                    txtPriNew.Text = "";
                    txtSts1New.Text = "";
                    txtSts2New.Text = "";
                    txtSts3New.Text = "";
                    txtSts4New.Text = "";
                    txtSts5New.Text = "";
                    txtSts6New.Text = "";
                    txtSts7New.Text = "";
                    txtSts8New.Text = "";
                    txtSts9New.Text = "";
                    txtSts10New.Text = "";
                    break;

                case 2:
                    cdvEventID.Text = "";
                    txtEventDesc.Text = "";
                    txtUpDownCur.Text = txtUpDownNew.Text = "";
                    txtPriCur.Text = txtPriNew.Text = "";
                    txtSts1Cur.Text = txtSts1New.Text = "";
                    txtSts2Cur.Text = txtSts2New.Text = "";
                    txtSts3Cur.Text = txtSts3New.Text = "";
                    txtSts4Cur.Text = txtSts4New.Text = "";
                    txtSts5Cur.Text = txtSts5New.Text = "";
                    txtSts6Cur.Text = txtSts6New.Text = "";
                    txtSts7Cur.Text = txtSts7New.Text = "";
                    txtSts8Cur.Text = txtSts8New.Text = "";
                    txtSts9Cur.Text = txtSts9New.Text = "";
                    txtSts10Cur.Text = txtSts10New.Text = "";
                    break;
            }
        }

        /// <summary>
        /// Draw Spec Out Mask
        /// </summary>
        /// <param name="out_node"></param>
        private bool DrawSpecOutMask(TRSNode out_node)
        {
            bool bSpecOut = false;
            int i;
            int m;
            int k;
            int i_value_count;
            int i_row;
            Color spec_out_back_color;

            TRSNode spec_out_mask_ary;
            List<TRSNode> char_list, unit_list;

            i_row = 0;
            char_list = out_node.GetList("CHAR_LIST");

            for (i = 0; i < char_list.Count; i++)
            {
                unit_list = char_list[i].GetList("UNIT_LIST");
                for (k = 0; k < unit_list.Count; k++)
                {
                    spec_out_mask_ary = unit_list[k].GetArray("SPEC_OUT_MASK");
                    i_value_count = spec_out_mask_ary.MemberCount;

                    for (m = 0; m < i_value_count; m++)
                    {
                        spec_out_back_color = Color.White;

                        if (spec_out_mask_ary.GetChar(m.ToString()) == '1' ||
                            spec_out_mask_ary.GetChar(m.ToString()) == '4' ||
                            spec_out_mask_ary.GetChar(m.ToString()) == '5')
                        {
                            spec_out_back_color = Color.Red;
                            bSpecOut = true;
                        }
                        else if (spec_out_mask_ary.GetChar(m.ToString()) == '2' ||
                                 spec_out_mask_ary.GetChar(m.ToString()) == '3')
                        {
                            spec_out_back_color = Color.Orange;
                        }
                        else if (MPCF.Trim(spdData.ActiveSheet.Rows[i_row].Tag) == "AUTO")
                        {
                            spec_out_back_color = Color.Cyan;
                        }

                        spdData.ActiveSheet.Cells[i_row, 6 + m].BackColor = spec_out_back_color;
                    }
                    i_row++;
                }
            }

            return bSpecOut;
        }

        #endregion

        public class EdcDataInfo
        {
            public string CharId { get; set; }
            public string CharDesc { get; set; }
            public int CharSeq { get; set; }
            public string Spec { get; set; }
            public string UnitId { get; set; }
            public int UnitSeq { get; set; }
            public int ValueCount { get; set; }
            public char ValueType { get; set; }
            public string V1 { get; set; }
            public string V2 { get; set; }
            public string V3 { get; set; }
            public string V4 { get; set; }
            public string V5 { get; set; }
            public string V6 { get; set; }
            public string V7 { get; set; }
            public string V8 { get; set; }
            public string V9 { get; set; }
            public string V10 { get; set; }
            public bool V1_input { get; set; }
            public bool V2_input { get; set; }
            public bool V3_input { get; set; }
            public bool V4_input { get; set; }
            public bool V5_input { get; set; }
            public bool V6_input { get; set; }
            public bool V7_input { get; set; }
            public bool V8_input { get; set; }
            public bool V9_input { get; set; }
            public bool V10_input { get; set; }
            public Color V1_backColor { get; set; }
            public Color V2_backColor { get; set; }
            public Color V3_backColor { get; set; }
            public Color V4_backColor { get; set; }
            public Color V5_backColor { get; set; }
            public Color V6_backColor { get; set; }
            public Color V7_backColor { get; set; }
            public Color V8_backColor { get; set; }
            public Color V9_backColor { get; set; }
            public Color V10_backColor { get; set; }

            public EdcDataInfo(int iCharSeq, string sCharId, string sCharDesc, string sSpec, int iUnitSeq)
            {
                this.CharSeq = iCharSeq;
                this.CharId = sCharId;
                this.CharDesc = sCharDesc;
                this.Spec = sSpec;
                this.UnitSeq = iUnitSeq;
            }
        }
    }
}
