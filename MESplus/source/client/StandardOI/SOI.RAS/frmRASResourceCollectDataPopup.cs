using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmRASResourceCollectDataPopup : frmPopupBase
    {
        #region Property
        private EdcDataInfo charData;
        /// <summary>
        /// (Required) Show form after drawing is finished.
        /// Form 내에 있는 모든 컨트롤들의 Rendering을 완료한 이후에 Form을 표시한다.
        /// Load Event 이후에 발생하므로 Focus 등의 이벤트들은 Activated 이벤트에 할당해야 한다.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        #endregion

        #region Constructor

        public frmRASResourceCollectDataPopup(string sResID, string sEventID, ref TRSNode CollectEDC)
        {
            InitializeComponent();
            cdvResID.Text = sResID;
            if (cdvResID.Text != "")
            {
                cdvResID.Enabled = false;
            }
            cdvEventID.Text = sEventID;
            if (cdvEventID.Text != "")
            {
                cdvEventID.Enabled = false;
            }
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // 활성화
            this.Activate();
            if (ViewResource(cdvResID.Text) == false) return;
            if (ViewEvent(cdvEventID.Text) == false) return;
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            this.Close();
        }
        /// <summary>
        /// Code View Button Click        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            // In Node Setup
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';

            // Display and Header Text Setup
            string[] display = new string[] { "RES_ID", "RES_DESC" };
            string[] header = new string[] { "Res ID", "Res Desc" };

            // Show CodeView and Get Return
            cdvResID.Text = cdvResID.Show(cdvResID, "RAS", "View Resource List", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "Res ID");

            if (ViewResource(cdvResID.Text) == false) return;

        }
        /// <summary>
        /// Code View Button Click        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvEventID_CodeViewButtonClick(object sender, EventArgs e)
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
            cdvEventID.Text = cdvEventID.Show(cdvEventID, "RAS", "View Resource Event", "RAS_View_ResEvent_List", in_node, "EVENT_LIST", display, header, "Event ID");
            
            if (ViewEvent(cdvEventID.Text) == false) return;
        }

        #endregion

        
        #region Function
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

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("EVENT_ID", sEventId);

            if (MPCF.CallService("RAS", "RAS_View_Event", in_node, ref out_node) == false)
            {
                return false;
            }

            txtEventDesc.Text = MPCF.Trim(out_node.GetString("EVENT_DESC"));

            //btnCollectData.IsEnabled = false;
            if (MPCF.Trim(out_node.GetString("COL_SET_ID")) != "")
            {
                txtCollectionSet.Text = MPCF.Trim(out_node.GetString("COL_SET_ID"));
            }
            txtColSetVer.Text = MPCF.Trim(out_node.GetInt("COL_SET_VER"));

            if (FindColSetVersion() == false)
            {
                return false;
            }

            if (ViewAttachCharacterList() == false)
            {
                return false;
            }

            //if (out_node.GetChar("CHG_UP_DOWN_FLAG") == CHANGE)
            //{
            //    if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "U")
            //    {
            //        txtUpDownNew.Text = "UP";
            //    }
            //    else if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "D")
            //    {
            //        txtUpDownNew.Text = "DOWN";
            //    }
            //}
            //else
            //{
            //    txtUpDownNew.Text = txtUpDownCur.Text;
            //}

            //ChangeStatusInput(out_node, ThisMoment, 0, null, txtPriNew, txtPriCur);
            //ChangeStatusInput(out_node, ThisMoment, 1, lblSts1, txtSts1New, txtSts1Cur);
            //ChangeStatusInput(out_node, ThisMoment, 2, lblSts2, txtSts2New, txtSts2Cur);
            //ChangeStatusInput(out_node, ThisMoment, 3, lblSts3, txtSts3New, txtSts3Cur);
            //ChangeStatusInput(out_node, ThisMoment, 4, lblSts4, txtSts4New, txtSts4Cur);
            //ChangeStatusInput(out_node, ThisMoment, 5, lblSts5, txtSts5New, txtSts5Cur);
            //ChangeStatusInput(out_node, ThisMoment, 6, lblSts6, txtSts6New, txtSts6Cur);
            //ChangeStatusInput(out_node, ThisMoment, 7, lblSts7, txtSts7New, txtSts7Cur);
            //ChangeStatusInput(out_node, ThisMoment, 8, lblSts8, txtSts8New, txtSts8Cur);
            //ChangeStatusInput(out_node, ThisMoment, 9, lblSts9, txtSts9New, txtSts9Cur);
            //ChangeStatusInput(out_node, ThisMoment, 10, lblSts10, txtSts10New, txtSts10Cur);

            return true;
        }

        /// <summary>
        /// Find Col Set Version
        /// </summary>
        /// <returns></returns>
        private bool FindColSetVersion()
        {
            TRSNode in_node = new TRSNode("FIND_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("FIND_COL_SET_VERSION_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RES_ID", cdvResID.Text);
            //in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
            //in_node.AddString("FLOW", LOT.GetString("FLOW"));
            //in_node.AddString("OPER", LOT.GetString("OPER"));
            in_node.AddString("COL_SET_ID", txtCollectionSet.Text);
            in_node.AddChar("LOT_OR_RES_FLAG", 'R');

            if (MPCF.CallService("EDC", "EDC_Find_Col_Set_Version", in_node, ref out_node) == false)
            {
                return false;
            }

            txtColSetVer.Text = out_node.GetInt("COL_SET_VERSION").ToString();

            return true;
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

            //_model.EdcData = new ObservableCollection<EdcDataInfo>();
            for (int i = 13; i >= 4; i--)
            {
                spdData.ActiveSheet.Columns[i].Visible = true;
                //dxgData.Columns[i].Visible = true;
            }

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '5';

            in_node.AddChar("INCLUDE_UNIT_ID", 'Y');
            in_node.AddString("COL_SET_ID", txtCollectionSet.Text);
            in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(txtColSetVer.Text));
            in_node.AddString("RES_ID", cdvResID.Text);

            if (MPCF.CallService("EDC", "EDC_View_Attach_Character_List", in_node, ref out_node) == false)
            {
                return false;
            }


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

            //EditableCellBackColor = Application.Current.FindResource("SharedControlBackgroundColor_A") as SolidColorBrush;
            //LockCellBackColor = Application.Current.FindResource("TextBoxReadOnlyBackground") as SolidColorBrush;



            spdData.ActiveSheet.RowCount = 0;
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
                    charData = new EdcDataInfo(iCharSeq, CharInfo.GetString("CHAR_ID"),
                                                         CharInfo.GetString("CHAR_DESC"),
                                                         GetSpecInfo(CharInfo.GetString("UPPER_SPEC_LIMIT"),
                                                                     CharInfo.GetString("LOWER_SPEC_LIMIT"),
                                                                     CharInfo.GetString("TARGET_VALUE")),
                                               iUnitSeq + 1);
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
                        }
                        if (charData.ValueCount >= 2)
                        {
                            charData.V2_input = true;
                            charData.V2_backColor = EditableCellBackColor;
                            if (sDefaultValue != "") charData.V2 = sDefaultValue;
                        }
                        if (charData.ValueCount >= 3)
                        {
                            charData.V3_input = true;
                            charData.V3_backColor = EditableCellBackColor;
                            if (sDefaultValue != "") charData.V3 = sDefaultValue;
                        }
                        if (charData.ValueCount >= 4)
                        {
                            charData.V4_input = true;
                            charData.V4_backColor = EditableCellBackColor;
                            if (sDefaultValue != "") charData.V4 = sDefaultValue;
                        }
                        if (charData.ValueCount >= 5)
                        {
                            charData.V5_input = true;
                            charData.V5_backColor = EditableCellBackColor;
                            if (sDefaultValue != "") charData.V5 = sDefaultValue;
                        }
                        if (charData.ValueCount >= 6)
                        {
                            charData.V6_input = true;
                            charData.V6_backColor = EditableCellBackColor;
                            if (sDefaultValue != "") charData.V6 = sDefaultValue;
                        }
                        if (charData.ValueCount >= 7)
                        {
                            charData.V7_input = true;
                            charData.V7_backColor = EditableCellBackColor;
                            if (sDefaultValue != "") charData.V7 = sDefaultValue;
                        }
                        if (charData.ValueCount >= 8)
                        {
                            charData.V8_input = true;
                            charData.V8_backColor = EditableCellBackColor;
                            if (sDefaultValue != "") charData.V8 = sDefaultValue;
                        }
                        if (charData.ValueCount >= 9)
                        {
                            charData.V9_input = true;
                            charData.V9_backColor = EditableCellBackColor;
                            if (sDefaultValue != "") charData.V9 = sDefaultValue;
                        }
                        if (charData.ValueCount >= 10)
                        {
                            charData.V10_input = true;
                            charData.V10_backColor = EditableCellBackColor;
                            if (sDefaultValue != "") charData.V10 = sDefaultValue;
                        }
                    }

                    if (charData.ValueCount > iMaxValueCnt)
                    {
                        iMaxValueCnt = charData.ValueCount;
                    }

                    spdData.ActiveSheet.RowCount++;
                    spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 0].Value = charData.CharId;
                    spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 1].Value = charData.CharDesc;
                    spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 2].Value = charData.Spec;
                    spdData.ActiveSheet.Cells[iCharSeq + iUnitSeq + iCharUnitSum - 1, 3].Value = charData.UnitId;

                    //_model.EdcData.Add(charData);
                }//end for unitSeq
                iCharUnitSum = spdData.ActiveSheet.RowCount - 1;
            }//end for charSeq

            for (int i = 4 + iMaxValueCnt; i < 14; i++)
            {
                spdData.ActiveSheet.Columns[i].Visible = false;
                //dxgData.Columns[i].Visible = false;
            }

            // V1 ~ V10 컬럼에 대하여
            for (int i = 4; i < 14; i++)
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
                MPCF.ShowMessage("MPCF.GetSpecInfo()\n" + ex.Message, MSG_LEVEL.ERROR, false);
                return "";
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
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", sResId);

                if (MPCF.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtResDesc.Text = MPCF.Trim(out_node.GetString("RES_DESC"));
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

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
        #endregion
    }
}
