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
using System.Collections;

namespace SOI.EDC
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmEDCViewLotData : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmEDCViewLotData()
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
            // Init
            gridLotEDCHistory.InitDataSource();

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
        /// Lot ID Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Validation
                    if (MPCF.CheckValue(txtLotID, false) == false)
                    {
                        return;
                    }

                    // View Lot History
                    if (ViewLotHistory(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        txtLotID.SelectAll();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View EDC Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLotEDCHistory_ClickCell(object sender, ClickCellEventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }
                
                // View Data
                if (ViewLotData(txtLotID.Text, MPCF.ToInt(gridLotEDCHistory.Selected.Rows[0].Cells[0].Value), ' ') == false)
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
        /// Excel Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false || spdData.ActiveSheet.RowCount < 1)
                {
                    return;
                }

                // Excel Export
                if (MPCF.ExportToExcel(spdData, this.Text, "", true, true, true, -1, -1) == false)
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
        /// View 
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

                // View
                if (ViewLotHistory(txtLotID.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Lot History
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLotHistory(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_HISTORY_IN");
            TRSNode out_node;
            ArrayList lisHist = new ArrayList();

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
                in_node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_LOTEDC);
                in_node.AddString("FROM_TIME", "20010101000000");
                in_node.AddString("TO_TIME", "99990101000000");
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);

                do
                {
                    out_node = new TRSNode("VIEW_LOT_HISTORY_OUT");

                    if (MPCF.CallService("WIP", "WIP_View_Lot_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisHist.Add(out_node);
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                // Field Clear
                MPCF.FieldClear(this, txtLotID);

                // Bind
                DataTable dt = null;
                DataRow dr = null;
                foreach (object obj in lisHist)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    dt = gridLotEDCHistory.GetDataSource();

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        dr = dt.NewRow();
                        dr["SEQ"] = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                        dr["TRAN_CODE"] = out_node.GetList(0)[i].GetString("TRAN_CODE");
                        dr["TRAN_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        dr["MAT_ID"] = out_node.GetList(0)[i].GetString("MAT_ID");
                        dr["FLOW"] = out_node.GetList(0)[i].GetString("FLOW");
                        dr["OPER"] = out_node.GetList(0)[i].GetString("OPER");
                        dr["QTY_1"] = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("QTY_1"));
                        dr["LOT_STATUS"] = out_node.GetList(0)[i].GetString("LOT_STATUS");
                        dr["HOLD_FLAG"] = out_node.GetList(0)[i].GetChar("HOLD_FLAG");
                        dr["HOLD_CODE"] = out_node.GetList(0)[i].GetString("HOLD_CODE");
                        dr["START_FLAG"] = out_node.GetList(0)[i].GetChar("START_FLAG");
                        dr["START_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME"));
                        dr["START_RES_ID"] = out_node.GetList(0)[i].GetString("START_RES_ID");
                        dr["END_FLAG"] = out_node.GetList(0)[i].GetChar("END_FLAG");
                        dr["END_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME"));
                        dr["END_RES_ID"] = out_node.GetList(0)[i].GetString("END_RES_ID");
                        dr["ORDER_ID"] = out_node.GetList(0)[i].GetString("ORDER_ID");
                        dr["OPER_IN_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("OPER_IN_TIME"));
                        dr["TRAN_USER_ID"] = out_node.GetList(0)[i].GetString("TRAN_USER_ID");
                        dr["TRAN_COMMENT"] = out_node.GetList(0)[i].GetString("TRAN_COMMENT");
                        dt.Rows.Add(dr);
                    }

                    gridLotEDCHistory.SetDataSource(dt);
                }

                if (gridLotEDCHistory.Rows.Count > 0)
                {
                    gridLotEDCHistory.Rows[0].Selected = true;

                    if (ViewLotData(txtLotID.Text, MPCF.ToInt(gridLotEDCHistory.Rows[0].Cells[0].Value), ' ') == false)
                    {
                        return false;
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
        /// Get Spec Info
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
        /// View Lot Data
        /// </summary>
        /// <param name="sLotID"></param>
        /// <param name="iHistSeq"></param>
        /// <param name="cIncludeDelHistory"></param>
        /// <returns></returns>
        private bool ViewLotData(string sLotID, int iHistSeq, char cIncludeDelHistory)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_DATA_OUT");

            try
            {
                FarPoint.Win.Spread.SheetView sheetX;
                int k;
                int m;
                int iRow;
                int iMaxValueCount = 0;
                int COL_VALUE = 7;
                string s_spec_out_mask;
                int iPrecision = 0;
                
                // Field Clear
                MPCF.ClearList(this.spdData);
                for (int i = 16; i >= 7; i--)
                {
                    spdData.ActiveSheet.Columns[i].Visible = true;
                }

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotID);
                in_node.AddInt("HIST_SEQ", iHistSeq);
                in_node.AddChar("INCLUDE_DEL_HIST", cIncludeDelHistory);

                do
                {
                    if (MPCF.CallService("EDC", "EDC_View_Lot_Data", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    sheetX = spdData.ActiveSheet;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        if (out_node.GetList(0)[i].GetChar("HIS_DEL_FLAG") == 'Y')
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }

                        //CHARACTER의 DISPLAY_PRECISION
                        iPrecision = out_node.GetList(0)[i].GetInt("DISPLAY_PRECISION");
                        sheetX.Cells[iRow, 0].Value = out_node.GetList(0)[i].GetInt("COL_SEQ");
                        sheetX.Cells[iRow, 1].Value = out_node.GetList(0)[i].GetString("COL_SET_ID");
                        sheetX.Cells[iRow, 2].Value = out_node.GetList(0)[i].GetInt("COL_SET_VERSION");
                        sheetX.Cells[iRow, 3].Value = out_node.GetList(0)[i].GetString("CHAR_ID");
                        sheetX.Cells[iRow, 4].Value = out_node.GetList(0)[i].GetString("CHAR_DESC");
                        sheetX.Cells[iRow, 5].Value = GetSpecInfo(out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"),
                                                                   out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"),
                                                                   out_node.GetList(0)[i].GetString("TARGET_VALUE"));
                        sheetX.Cells[iRow, 6].Value = out_node.GetList(0)[i].GetString("UNIT_ID");

                        if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                        {
                            if (out_node.GetList(0)[i].GetString("VALUE_1") != "")
                                sheetX.Cells[iRow, COL_VALUE + 0].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_1"));
                            if (out_node.GetList(0)[i].GetString("VALUE_2") != "")
                                sheetX.Cells[iRow, COL_VALUE + 1].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_2"));
                            if (out_node.GetList(0)[i].GetString("VALUE_3") != "")
                                sheetX.Cells[iRow, COL_VALUE + 2].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_3"));
                            if (out_node.GetList(0)[i].GetString("VALUE_4") != "")
                                sheetX.Cells[iRow, COL_VALUE + 3].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_4"));
                            if (out_node.GetList(0)[i].GetString("VALUE_5") != "")
                                sheetX.Cells[iRow, COL_VALUE + 4].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_5"));
                            if (out_node.GetList(0)[i].GetString("VALUE_6") != "")
                                sheetX.Cells[iRow, COL_VALUE + 5].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_6"));
                            if (out_node.GetList(0)[i].GetString("VALUE_7") != "")
                                sheetX.Cells[iRow, COL_VALUE + 6].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_7"));
                            if (out_node.GetList(0)[i].GetString("VALUE_8") != "")
                                sheetX.Cells[iRow, COL_VALUE + 7].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_8"));
                            if (out_node.GetList(0)[i].GetString("VALUE_9") != "")
                                sheetX.Cells[iRow, COL_VALUE + 8].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_9"));
                            if (out_node.GetList(0)[i].GetString("VALUE_10") != "")
                                sheetX.Cells[iRow, COL_VALUE + 9].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_10"));                          
                        }
                        else
                        {
                            sheetX.Cells[iRow, COL_VALUE + 0].Value = out_node.GetList(0)[i].GetString("VALUE_1");
                            sheetX.Cells[iRow, COL_VALUE + 1].Value = out_node.GetList(0)[i].GetString("VALUE_2");
                            sheetX.Cells[iRow, COL_VALUE + 2].Value = out_node.GetList(0)[i].GetString("VALUE_3");
                            sheetX.Cells[iRow, COL_VALUE + 3].Value = out_node.GetList(0)[i].GetString("VALUE_4");
                            sheetX.Cells[iRow, COL_VALUE + 4].Value = out_node.GetList(0)[i].GetString("VALUE_5");
                            sheetX.Cells[iRow, COL_VALUE + 5].Value = out_node.GetList(0)[i].GetString("VALUE_6");
                            sheetX.Cells[iRow, COL_VALUE + 6].Value = out_node.GetList(0)[i].GetString("VALUE_7");
                            sheetX.Cells[iRow, COL_VALUE + 7].Value = out_node.GetList(0)[i].GetString("VALUE_8");
                            sheetX.Cells[iRow, COL_VALUE + 8].Value = out_node.GetList(0)[i].GetString("VALUE_9");
                            sheetX.Cells[iRow, COL_VALUE + 9].Value = out_node.GetList(0)[i].GetString("VALUE_10");                            
                        }

                        for (k = COL_VALUE; k < COL_VALUE + 10; k++)
                        {
                            if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                            {
                                //DISPLAY PRECISION 적용
                                if (iPrecision > 0 && sheetX.Cells[iRow, k].Value != null)
                                {
                                    sheetX.Cells[iRow, k].Value = MPCF.SetPrecision(sheetX.Cells[iRow, k].Value.ToString(), iPrecision);
                                }
                            }
                        }

                        sheetX.Cells[iRow, COL_VALUE + 10].Value = out_node.GetList(0)[i].GetString("SPEC_OUT_MASK");
                        sheetX.Cells[iRow, COL_VALUE + 11].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                        sheetX.Cells[iRow, COL_VALUE + 12].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"));

                        if (iMaxValueCount < out_node.GetList(0)[i].GetInt("VALUE_COUNT"))
                        {
                            iMaxValueCount = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                        }

                        s_spec_out_mask = out_node.GetList(0)[i].GetString("SPEC_OUT_MASK");

                        if (s_spec_out_mask != "")
                        {
                            for (m = 0; m < s_spec_out_mask.Length; m++)
                            {
                                if (s_spec_out_mask[m] == '1' ||
                                    s_spec_out_mask[m] == '4' ||
                                    s_spec_out_mask[m] == '5')
                                {
                                    sheetX.Cells[iRow, COL_VALUE + m].BackColor = Color.Red;
                                }
                                else if (s_spec_out_mask[m] == '2' ||
                                         s_spec_out_mask[m] == '3')
                                {
                                    sheetX.Cells[iRow, COL_VALUE + m].BackColor = Color.Orange;
                                }
                                else
                                {
                                    sheetX.Cells[iRow, COL_VALUE + m].BackColor = MPGV.gTheme.SpreadCellEditableBackColor;
                                }
                            }
                        }

                        iRow++;
                    }

                    in_node.SetString("NEXT_COL_SET_ID", out_node.GetString("NEXT_COL_SET_ID"));
                    in_node.SetInt("NEXT_CHAR_SEQ_NUM", out_node.GetInt("NEXT_CHAR_SEQ_NUM"));
                    in_node.SetInt("NEXT_UNIT_SEQ_NUM", out_node.GetInt("NEXT_UNIT_SEQ_NUM"));
                    in_node.SetInt("NEXT_VALUE_SEQ_NUM", out_node.GetInt("NEXT_VALUE_SEQ_NUM"));
                    in_node.SetInt("NEXT_COL_SEQ", out_node.GetInt("NEXT_COL_SEQ"));
                } while (in_node.GetString("NEXT_COL_SET_ID") != "" ||
                                in_node.GetInt("NEXT_CHAR_SEQ_NUM") > 0 ||
                                in_node.GetInt("NEXT_UNIT_SEQ_NUM") > 0 ||
                                in_node.GetInt("NEXT_VALUE_SEQ_NUM") > 0 ||
                                in_node.GetInt("NEXT_COL_SEQ") > 0);


                for (int i = 7 + iMaxValueCount; i < 17; i++)
                {
                    spdData.ActiveSheet.Columns[i].Visible = false;
                }

                // Fit Column Header
                MPCF.FitColumnHeader(spdData);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        public class LotHistoryInfo
        {
            public int HistSeq { get; set; }
            public string TranCode { get; set; }
            public string TranTime { get; set; }
            public string MatId { get; set; }
            public string Flow { get; set; }
            public string Oper { get; set; }
            public double Qty { get; set; }
            public string Status { get; set; }
            public string HoldFlag { get; set; }
            public string HoldCode { get; set; }
            public string StartFlag { get; set; }
            public string StartTime { get; set; }
            public string StartResId { get; set; }
            public string EndFlag { get; set; }
            public string EndTime { get; set; }
            public string EndResId { get; set; }
            public string OrderId { get; set; }
            public string OperInTime { get; set; }
            public string TranUserId { get; set; }
            public string TranComment { get; set; }

            public LotHistoryInfo(TRSNode node)
            {
                this.HistSeq = node.GetInt("HIST_SEQ");
                this.TranCode = node.GetString("TRAN_CODE");
                this.TranTime = MPCF.MakeDateFormat(node.GetString("TRAN_TIME"));
                this.MatId = node.GetString("MAT_ID");
                this.Flow = node.GetString("FLOW");
                this.Oper = node.GetString("OPER");
                this.Qty = node.GetDouble("QTY_1");
                this.Status = node.GetString("LOT_STATUS");
                this.HoldFlag = node.GetChar("HOLD_FLAG").ToString();
                this.HoldCode = node.GetString("HOLD_CODE");
                this.StartFlag = node.GetChar("START_FLAG").ToString();
                this.StartTime = MPCF.MakeDateFormat(node.GetString("START_TIME"));
                this.StartResId = node.GetString("START_RES_ID");
                this.EndFlag = node.GetChar("END_FLAG").ToString();
                this.EndTime = MPCF.MakeDateFormat(node.GetString("END_TIME"));
                this.EndResId = node.GetString("END_RES_ID");
                this.OrderId = node.GetString("ORDER_ID");
                this.OperInTime = MPCF.MakeDateFormat(node.GetString("OPER_IN_TIME"));
                this.TranUserId = node.GetString("TRAN_USER_ID");
                this.TranComment = node.GetString("TRAN_COMMENT");
            }
        }

        public class EdcDataInfo
        {
            public string seq { get; set; }
            public int ColSeq { get; set; }
            public string ColSetId { get; set; }
            public int ColSetVer { get; set; }
            public string CharId { get; set; }
            public string CharDesc { get; set; }
            public int CharSeq { get; set; }
            public string Spec { get; set; }
            public string UnitId { get; set; }
            public int UnitSeq { get; set; }
            public int ValueCount { get; set; }
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

            public string SpecOutMask { get; set; }
            public string UpdateUser { get; set; }
            public string UpdateTime { get; set; }

            public EdcDataInfo(int iColSeq, string sColSetId, int iColSetVer, int iCharSeq, string sCharId, string sCharDesc, string sSpec, int iUnitSeq, string sUnitId)
            {
                this.ColSeq = iColSeq;
                this.ColSetId = sColSetId;
                this.ColSetVer = iColSetVer;
                this.CharSeq = iCharSeq;
                this.CharId = sCharId;
                this.CharDesc = sCharDesc;
                this.Spec = sSpec;
                this.UnitSeq = iUnitSeq;
                this.UnitId = sUnitId;
            }
        }
    }
}
