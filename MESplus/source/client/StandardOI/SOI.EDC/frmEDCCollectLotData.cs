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
using SOI.WIP;
using Infragistics.Win.UltraWinGrid;

namespace SOI.EDC
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmEDCCollectLotData : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode LOT = new TRSNode("LOT_INFO");
        private TRSNode ORDER = new TRSNode("ORDER_INFO");
        private EdcDataInfo charData;

        private int iColSetVersion = 0;
        
        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public frmEDCCollectLotData()
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
                // (Required) Init Focus Control
                 MPCF.SetFocus(txtLotID);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Lot ID Enter Key Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && MPCF.Trim(txtLotID.Text) != "")
                {
                    if (ViewLot(txtLotID.Text) == false)
                    {
                        txtLotID.SelectAll();
                        return;
                    }

                    bool singleData = true;
                    if (ViewMFOColSetList(ref singleData, false) == false)
                    {
                        return;
                    }

                    if (singleData == true)
                    {
                        if (FindColSetVersion() == false)
                        {
                            return;
                        }

                        if (ViewAttachCharacterList() == false)
                        {
                            return;
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
        /// Lot ID Search Button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLotIDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (MPCF.Trim(txtLotID) != "")
                {
                    if (ViewLot(txtLotID.Text) == false)
                    {
                        txtLotID.SelectAll();
                        return;
                    }

                    bool singleData = true;
                    if (ViewMFOColSetList(ref singleData, false) == false)
                    {
                        return;
                    }

                    if (singleData == true)
                    {
                        if (FindColSetVersion() == false)
                        {
                            return;
                        }

                        if (ViewAttachCharacterList() == false)
                        {
                            return;
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
        /// Collection Set Code View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvCollectionSet_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("View_MFO_ColSet_List_In");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddChar("OPT_LEVEL", '0');
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddChar("COLLECTION_MODE", 'M');
                in_node.AddChar("DEFAULT_FLAG", ' ');
                in_node.AddChar("DISABLE_FLAG", 'N');
                in_node.AddString("NEXT_OPER", "");
                in_node.AddInt("NEXT_SEQ", 0);
                in_node.AddString("NEXT_COL_SET_ID", "");

                // Display and Header Text Setup
                string[] display = new string[] { "COL_SET_ID", "COL_SET_DESC" };
                string[] header = new string[] { "Col Set ID", "Col Set Desc" };

                cdvCollectionSet.Text = cdvCollectionSet.Show(cdvCollectionSet, "EDC", "View MFO ColSet List", "EDC_View_MFO_ColSet_List", in_node, "COLSET_LIST", display, header, "Col Set ID");

                if (FindColSetVersion() == false)
                {
                    return;
                }

                if (ViewAttachCharacterList() == false)
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
        /// View Lot Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLotStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                frmWIPViewLotStatusPopup f = new frmWIPViewLotStatusPopup(txtLotID.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Lot History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLotHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                frmWIPViewLotHistoryPopup f = new frmWIPViewLotHistoryPopup(txtLotID.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Work Order 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (ORDER.GetString("ORDER_ID") == null 
                    || ORDER.GetString("ORDER_ID") == "")
                {
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(ORDER.GetString("ORDER_ID"));
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Do Process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvCollectionSet, false) == false)
                {
                    return;
                }

                // Collect Lot Data
                if (CollectLotData('2') == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();                    
                    return;
                }

                // Focus
                MPCF.SetFocus(txtLotID);
                txtLotID.SelectAll();                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLot(string sLotId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                
                LOT.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }

                txtMaterial.Text = LOT.GetString("MAT_ID") + " : " + LOT.GetString("MAT_DESC");
                txtOper.Text = LOT.GetString("OPER") + " : " + LOT.GetString("OPER_DESC");
                txtQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));;
                
                if (ViewOrder(LOT.GetString("ORDER_ID")) == false)
                {
                    return false;
                }

                if (LOT.GetString("LOT_STATUS") == "PROC")
                {
                    pbStart.LotStatus = true;
                }
                else
                {
                    pbStart.LotStatus = false;
                }

                pbHold.LotStatus = (LOT.GetChar("HOLD_FLAG") == 'Y' ? true : false);
                pbRework.LotStatus = (LOT.GetChar("RWK_FLAG") == 'Y' ? true : false);
                pbRepair.LotStatus = (LOT.GetChar("REP_FLAG") == 'Y' ? true : false);
                pbInventory.LotStatus = (LOT.GetChar("INV_FLAG") == 'Y' ? true : false);
                pbTransit.LotStatus = (LOT.GetChar("TRANSIT_FLAG") == 'Y' ? true : false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }            
        }

        /// <summary>
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewOrder(string sOrderId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", sOrderId);

                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                ORDER = out_node;
                txtWorkOrder.Text = out_node.GetString("ORDER_ID") + " : " + out_node.GetString("ORDER_DESC");
                txtCustomer.Text = out_node.GetString("CUSTOMER_ID");
                txtLine.Text = out_node.GetString("WORK_LINE") + " : " + out_node.GetString("WORK_LINE_DESC"); ;

                lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
                lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
                lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
                lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Collection Set ComboBox Data View
        /// CodeView 팝업창을 띄운다
        /// </summary>
        /// <returns></returns>
        private bool ViewMFOColSetList(ref bool singleData, bool skipCodeView)
        {
            try
            {
                TRSNode in_node = new TRSNode("View_MFO_ColSet_List_In");
                TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddChar("OPT_LEVEL", '0');
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddChar("COLLECTION_MODE", 'M');
                in_node.AddChar("DEFAULT_FLAG", ' ');
                in_node.AddChar("DISABLE_FLAG", 'N');
                in_node.AddString("NEXT_OPER", "");
                in_node.AddInt("NEXT_SEQ", 0);
                in_node.AddString("NEXT_COL_SET_ID", "");

                if (MPCF.CallService("EDC", "EDC_View_MFO_ColSet_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList(0) != null)
                {
                    if (out_node.GetList(0).Count == 1)
                    {
                        singleData = true;
                        cdvCollectionSet.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("COL_SET_ID"));                        
                    }
                    else if (out_node.GetList(0).Count > 1)
                    {
                        if (skipCodeView == false)
                        {
                            singleData = false;
                            cdvCollectionSet_CodeViewButtonClick(null, null);
                        }
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
        /// Find Col Set Version
        /// </summary>
        /// <returns></returns>
        private bool FindColSetVersion()
        {
            try
            {
                // Call Service
                TRSNode in_node = new TRSNode("FIND_COL_SET_VERSION_IN");
                TRSNode out_node = new TRSNode("FIND_COL_SET_VERSION_OUT");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("COL_SET_ID", cdvCollectionSet.Text);
                in_node.AddChar("LOT_OR_RES_FLAG", 'L');
                if (MPCF.CallService("EDC", "EDC_Find_Col_Set_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                iColSetVersion = out_node.GetInt("COL_SET_VERSION");

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
                MPCF.ShowMessage("MPCF.GetSpecInfo()\n" + ex.Message, MSG_LEVEL.ERROR, false);
                return "";
            }
        }

        /// <summary>
        /// View Attach Character List
        /// </summary>
        /// <returns></returns>
        private bool ViewAttachCharacterList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_OUT");
                List<TRSNode> CharList;
                List<TRSNode> UnitList;

                // Set Column Visible True
                for (int i = 13; i >= 4; i--)
                {
                    spdData.ActiveSheet.Columns[i].Visible = true;
                }

                //  Get EDC Data
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '5';
                in_node.AddChar("INCLUDE_UNIT_ID", 'Y');
                in_node.AddString("COL_SET_ID", cdvCollectionSet.Text);
                in_node.AddInt("COL_SET_VERSION", iColSetVersion);
                in_node.AddString("LOT_ID", txtLotID.Text);
                if (MPCF.CallService("EDC", "EDC_View_Attach_Character_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                CharList = out_node.GetList("CHAR_LIST");

                // Init Variables
                int iCharSeq = 0;
                int iUnitCount = 0;
                int iCharUnitSum = 0;
                int iMaxValueCnt = 0;
                int iCurrRowIndex = 0;
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
                
                // 캐릭터 수 만큼
                foreach (TRSNode CharInfo in CharList)
                {
                    // 전체 Row 수
                    iCharUnitSum++;

                    // 캐릭터 수
                    iCharSeq++;

                    // 해당 캐릭터의 총 Unit 수
                    iUnitCount = CharInfo.GetInt("UNIT_COUNT");
                    
                    // Unit 목록
                    UnitList = CharInfo.GetList("UNIT_LIST");

                    sDefaultValue = CharInfo.GetString("DEF_VALUE");
                    cDefUnitFlag = CharInfo.GetChar("DEF_UNIT_FLAG");
                    cDefUnitOvrFlag = CharInfo.GetChar("DEF_UNIT_OVR_FLAG");
                    sUnitTbl = CharInfo.GetString("UNIT_TBL");
                    sValueTbl = CharInfo.GetString("VALUE_TBL");

                    // Unit 수 만큼
                    for (int iUnitSeq = 0; iUnitSeq < iUnitCount; iUnitSeq++)
                    {
                        // 전체 Row 수
                        if (iUnitSeq != 0)
                        {
                            iCharUnitSum++;
                        }

                        // 신규 Data 생성
                        charData = new EdcDataInfo(iCharSeq, 
                                                                        CharInfo.GetString("CHAR_ID"),
                                                                        CharInfo.GetString("CHAR_DESC"),
                                                                        GetSpecInfo(CharInfo.GetString("UPPER_SPEC_LIMIT"), CharInfo.GetString("LOWER_SPEC_LIMIT"), CharInfo.GetString("TARGET_VALUE")),
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

                        // Row 추가
                        spdData.ActiveSheet.RowCount++;
                        // iCurrRowIndex = iCharSeq + iUnitSeq + iCharUnitSum - 1;
                        iCurrRowIndex = iCharUnitSum -1;

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

                        spdData.ActiveSheet.Cells[iCurrRowIndex, 6].BackColor = charData.V1_backColor;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 7].BackColor = charData.V2_backColor;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 8].BackColor = charData.V3_backColor;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 9].BackColor = charData.V4_backColor;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 10].BackColor = charData.V5_backColor;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 11].BackColor = charData.V6_backColor;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 12].BackColor = charData.V7_backColor;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 13].BackColor = charData.V8_backColor;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 14].BackColor = charData.V9_backColor;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 15].BackColor = charData.V10_backColor;

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
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 6].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 6].BackColor = charData.V1_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 6].Value = charData.V1;
                            }
                            if (charData.ValueCount >= 2)
                            {
                                charData.V2_input = true;
                                charData.V2_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V2 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 7].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 7].BackColor = charData.V2_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 7].Value = charData.V2;
                            }
                            if (charData.ValueCount >= 3)
                            {
                                charData.V3_input = true;
                                charData.V3_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V3 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 8].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 8].BackColor = charData.V3_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 8].Value = charData.V3;
                            }
                            if (charData.ValueCount >= 4)
                            {
                                charData.V4_input = true;
                                charData.V4_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V4 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 9].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 9].BackColor = charData.V4_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 9].Value = charData.V4;
                            }
                            if (charData.ValueCount >= 5)
                            {
                                charData.V5_input = true;
                                charData.V5_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V5 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 10].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 10].BackColor = charData.V5_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 10].Value = charData.V5;
                            }
                            if (charData.ValueCount >= 6)
                            {
                                charData.V6_input = true;
                                charData.V6_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V6 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 11].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 11].BackColor = charData.V6_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 11].Value = charData.V6;
                            }
                            if (charData.ValueCount >= 7)
                            {
                                charData.V7_input = true;
                                charData.V7_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V7 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 12].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 12].BackColor = charData.V7_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 12].Value = charData.V7;
                            }
                            if (charData.ValueCount >= 8)
                            {
                                charData.V8_input = true;
                                charData.V8_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V8 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 13].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 13].BackColor = charData.V8_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 13].Value = charData.V8;
                            }
                            if (charData.ValueCount >= 9)
                            {
                                charData.V9_input = true;
                                charData.V9_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V9 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 14].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 14].BackColor = charData.V9_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 14].Value = charData.V9;
                            }
                            if (charData.ValueCount >= 10)
                            {
                                charData.V10_input = true;
                                charData.V10_backColor = EditableCellBackColor;
                                if (sDefaultValue != "") charData.V10 = sDefaultValue;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 15].Locked = false;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 15].BackColor = charData.V10_backColor;
                                spdData.ActiveSheet.Cells[iCurrRowIndex, 15].Value = charData.V10;
                            }
                            if (iMaxValueCnt > charData.ValueCount)
                            {
                                for (int i = 0; i < iMaxValueCnt - charData.ValueCount; i++)
                                {
                                    spdData.ActiveSheet.Cells[iCurrRowIndex, 6 + charData.ValueCount + i].Locked = true;
                                }
                            }
                        }

                        if (charData.ValueCount > iMaxValueCnt)
                        {
                            iMaxValueCnt = charData.ValueCount;
                        }

                        spdData.ActiveSheet.Cells[iCurrRowIndex, 0].Value = charData.CharId;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 1].Value = charData.CharDesc;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 2].Value = charData.Spec;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 3].Value = charData.UnitSeq;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 4].Value = charData.ValueCount;
                        spdData.ActiveSheet.Cells[iCurrRowIndex, 5].Value = charData.UnitId;
                    }
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
        /// Fill Collection Data
        /// </summary>
        /// <param name="in_node"></param>
        /// <returns></returns>
        private bool FillCollectionData(ref TRSNode in_node)
        {
            try
            {
                int i;
                int j;
                TRSNode char_item, unit_item, value_item;
                CultureInfo ci_inter = new CultureInfo("en-US");

                char_item = in_node.AddNode("CHAR_LIST");

                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {                    
                    if (MPCF.ToInt(spdData.ActiveSheet.GetValue(i, 3)) == 1)
                    {
                        if (i != 0)
                        {
                            char_item = in_node.AddNode("CHAR_LIST");
                        }
                        char_item.AddString("CHAR_ID", spdData.ActiveSheet.GetValue(i, 0));
                    }

                    unit_item = char_item.AddNode("UNIT_LIST");
                    unit_item.AddString("UNIT_ID", spdData.ActiveSheet.GetValue(i, 5));
                    unit_item.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, 3)));

                    for (j = 0; j < MPCF.ToInt(spdData.ActiveSheet.Cells[i, 4].Value); j++)
                    {
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
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Draw Spec Out Mask
        /// </summary>
        /// <param name="out_node"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Collect Lot Data
        /// </summary>
        /// <param name="cProcStep"></param>
        /// <returns></returns>
        private bool CollectLotData(char cProcStep)
        {
            TRSNode in_node = new TRSNode("COLLECT_LOT_IN");
            TRSNode out_node = new TRSNode("COLLECT_LOT_OUT");
            
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddChar("LOT_EDC_TRAN_FLAG", 'Y');
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));                
                in_node.AddString("FLOW", LOT.GetString("FLOW"));                
                in_node.AddString("OPER", LOT.GetString("OPER"));                
                in_node.AddString("COL_SET_ID", cdvCollectionSet.Text);
                in_node.AddInt("COL_SET_VERSION", iColSetVersion);
                in_node.AddString("ORDER_ID", ORDER.GetString("ORDER_ID"));

                if (FillCollectionData(ref in_node) == false)
                {
                    return false;
                }

#if _H101
                if (MPCF.CallService("EDC", "EDC_Collect_Lot", in_node, ref out_node, "", 0, SOI.MsgHandlerH101.DeliveryMode.RReply, true) == false)
                {
                    //return false;
                }     
#endif
#if _Http
                if (MPCF.CallService("EDC", "EDC_Collect_Lot", in_node, ref out_node, "", 0, SOI.MsgHandlerHTTP.DeliveryMode.RReply, true, false) == false)
                {
                    //return false;
                }
#endif

                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCF.CheckContinueProc(out_node, false);
                    return false;
                }

                if (cProcStep == '2')
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

                    if (CollectLotData('4') == false)
                    {
                        return false;
                    }

                    //if (ViewLot(txtLotID.Text) == false)
                    //{
                    //    txtLotID.SelectAll();
                    //    return false;
                    //}

                    //if (ViewMFOColSetList() == false)
                    //{
                    //    return false;
                    //}

                    //if (FindColSetVersion() == false)
                    //{
                    //    return false;
                    //}

                    //if (ViewAttachCharacterList() == false)
                    //{
                    //    return false;
                    //}
                }
                else
                {
                    if (ViewLot(txtLotID.Text) == false)
                    {
                        txtLotID.SelectAll();
                        return false;
                    }

                    bool singleData = true;
                    if (ViewMFOColSetList(ref singleData, true) == false)
                    {
                        return false;
                    }

                    if (singleData == true)
                    {
                        if (FindColSetVersion() == false)
                        {
                            return false;
                        }

                        if (ViewAttachCharacterList() == false)
                        {
                            return false;
                        }
                    }
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

        #endregion
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
}
