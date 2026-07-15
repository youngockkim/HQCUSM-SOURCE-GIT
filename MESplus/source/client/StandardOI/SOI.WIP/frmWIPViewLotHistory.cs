using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Infragistics.Excel;

namespace SOI.WIP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPViewLotHistory : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        
        #endregion

        #region Constructor

        public frmWIPViewLotHistory()
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
        private void frmWIPViewLotHistory_Load(object sender, EventArgs e)
        {
            // Init
            dtpFromTime.Value = DateTime.Now.AddMonths(-1);

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
        private void frmWIPViewLotHistory_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// (Required) View Lot History
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // View History
                if (ViewLotHistory(txtLotID.Text) == false)
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
        /// Lot ID에서 엔터키 입력 시 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && MPCF.Trim(txtLotID.Text) != "")
                {
                    if (ViewLotHistory(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
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
        /// Excel Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, false) == false || spdHistory.ActiveSheet.RowCount < 1) return;

                string sCond;

                //sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFromTime)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpToTime.Value));
                sCond = string.Empty;

                if (MPCF.ExportToExcel(spdHistory, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        
        #endregion

        #region Functions

        /// <summary>
        /// Lot CMF 정보를 조회하고 값이 있는 경우에만 Grid Column을 보여줍니다.
        /// </summary>
        private void ShowLotCMF()
        {
            try
            {
                //// 해당 CMF Setup Table 추출
                //TRSNode in_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_IN");
                //TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");

                //MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                //in_node.AddString("ITEM_NAME", MPGC.MP_CMF_LOT);

                //if (MPCF.CallService("WIP", "WIP_View_Factory_Cmf_Item", in_node, out_node) == false)
                //{
                //    return;
                //}

                //if (out_node.ListCount > 0
                //    && out_node.GetList(0).Count > 0)
                //{
                //    for (int i = 0; i < out_node.GetList(0).Count; i++)
                //    {
                //        // PROMPT가 값이 있는 경우 등록
                //        if (out_node.GetList(0)[i].GetString("PROMPT") != "")
                //        {
                //            SetLotCMFVisibility(i, out_node.GetList(0)[i].GetString("PROMPT"));
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

            return;
        }

        /// <summary>
        /// Lot CMF column에 대한 visibility를 설정합니다.
        /// </summary>
        /// <param name="i"></param>
        private void SetLotCMFVisibility(int pi, string psPrompt)
        {
            //switch (pi)
            //{
            //    case 0:
            //        ColLotCMF1.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF1.HeaderText = psPrompt;
            //        break;
            //    case 1:
            //        ColLotCMF2.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF2.HeaderText = psPrompt;
            //        break;
            //    case 2:
            //        ColLotCMF3.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF3.HeaderText = psPrompt;
            //        break;
            //    case 3:
            //        ColLotCMF4.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF4.HeaderText = psPrompt;
            //        break;
            //    case 4:
            //        ColLotCMF5.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF5.HeaderText = psPrompt;
            //        break;
            //    case 5:
            //        ColLotCMF6.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF6.HeaderText = psPrompt;
            //        break;
            //    case 6:
            //        ColLotCMF7.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF7.HeaderText = psPrompt;
            //        break;
            //    case 7:
            //        ColLotCMF8.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF8.HeaderText = psPrompt;
            //        break;
            //    case 8:
            //        ColLotCMF9.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF9.HeaderText = psPrompt;
            //        break;
            //    case 9:
            //        ColLotCMF10.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF10.HeaderText = psPrompt;
            //        break;
            //    case 10:
            //        ColLotCMF11.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF11.HeaderText = psPrompt;
            //        break;
            //    case 11:
            //        ColLotCMF12.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF12.HeaderText = psPrompt;
            //        break;
            //    case 12:
            //        ColLotCMF13.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF13.HeaderText = psPrompt;
            //        break;
            //    case 13:
            //        ColLotCMF14.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF14.HeaderText = psPrompt;
            //        break;
            //    case 14:
            //        ColLotCMF15.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF15.HeaderText = psPrompt;
            //        break;
            //    case 15:
            //        ColLotCMF16.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF16.HeaderText = psPrompt;
            //        break;
            //    case 16:
            //        ColLotCMF17.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF17.HeaderText = psPrompt;
            //        break;
            //    case 17:
            //        ColLotCMF18.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF18.HeaderText = psPrompt;
            //        break;
            //    case 18:
            //        ColLotCMF19.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF19.HeaderText = psPrompt;
            //        break;
            //    case 19:
            //        ColLotCMF20.Visibility = System.Windows.Visibility.Visible;
            //        ColLotCMF20.HeaderText = psPrompt;
            //        break;
            //}
        }

        /// <summary>
        /// Lot Type List 조회
        /// </summary>
        /// <param name="sTableName"></param>
        /// <returns></returns>
        private bool ViewLotTypeList(string sTableName)
        {
            //TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            //TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");
            //List<TRSNode> lisData;

            //MPCF.SetInMsg(in_node);
            //in_node.ProcStep = '1';
            //in_node.AddString("TABLE_NAME", MPCF.Trim(sTableName));

            //ObservableCollection<LotTypeInfo> liCodeList = new ObservableCollection<LotTypeInfo>();

            //do
            //{
            //    if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, out_node) == false)
            //    {
            //        return false;
            //    }

            //    lisData = out_node.GetList("DATA_LIST");
            //    foreach (TRSNode data in lisData)
            //    {
            //        liCodeList.Add(new LotTypeInfo(data.GetString("KEY_1"), data.GetString("DATA_1")));
            //    }

            //    in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
            //    in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
            //    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            //} while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "" || in_node.GetInt("NEXT_ROW") > 0);

            //_model.LotTypeList = liCodeList;

            return true;
        }

        /// <summary>
        /// Lot 조회
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotId);

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
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
        /// Lot History 조회
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool ViewLotHistory(string sLotID)
        {
            TRSNode in_node = new TRSNode("View_Lot_History_In");
            TRSNode out_node = new TRSNode("View_Lot_History_Out");

            ArrayList lisHist = new ArrayList();

            try
            {
                // Clear
                MPCF.ClearList(this.spdHistory);

                // View Lot for Validation
                ViewLot(sLotID);

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("FROM_TIME", "20000101");
                in_node.AddString("TO_TIME", "29991231");
                //in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                if (chkIncludeDelHistory.Checked == true)
                {
                    in_node.AddChar("INCLUDE_DEL_HIST", 'Y');
                }
                
                //do
                //{
                //    out_node = new TRSNode("View_Lot_History_Out");

                //    if (MPCF.CallService("WIP", "WIP_View_Lot_History", in_node, ref out_node) == false)
                //    {
                //        return false;
                //    }

                //    lisHist.Add(out_node);

                //    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                //} while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                if (MPCF.CallService("WIP", "WIP_View_Lot_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdHistory.Sheets[0].Rows.Count;
                        spdHistory.Sheets[0].RowCount++;

                        spdHistory.ActiveSheet.Cells[iRow, 0].Value = out_node.GetList(0)[iRow].GetInt("HIST_SEQ");
                        spdHistory.ActiveSheet.Cells[iRow, 1].Value = MPCF.MakeDateFormat(out_node.GetList(0)[iRow].GetString("TRAN_TIME"));
                        spdHistory.ActiveSheet.Cells[iRow, 2].Value = out_node.GetList(0)[iRow].GetString("TRAN_CODE");
                        spdHistory.ActiveSheet.Cells[iRow, 3].Value = out_node.GetList(0)[iRow].GetString("MAT_ID");
                        spdHistory.ActiveSheet.Cells[iRow, 4].Value = out_node.GetList(0)[iRow].GetString("FLOW");
                        spdHistory.ActiveSheet.Cells[iRow, 5].Value = out_node.GetList(0)[iRow].GetString("OPER");
                        spdHistory.ActiveSheet.Cells[iRow, 6].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[iRow].GetDouble("QTY_1"));
                        spdHistory.ActiveSheet.Cells[iRow, 7].Value = out_node.GetList(0)[iRow].GetString("LOT_TYPE_DESC");
                        spdHistory.ActiveSheet.Cells[iRow, 8].Value = out_node.GetList(0)[iRow].GetString("LOT_STATUS");
                        spdHistory.ActiveSheet.Cells[iRow, 9].Value = out_node.GetList(0)[iRow].GetString("ORDER_ID");
                        spdHistory.ActiveSheet.Cells[iRow, 10].Value = out_node.GetList(0)[iRow].GetChar("HOLD_FLAG");
                        spdHistory.ActiveSheet.Cells[iRow, 11].Value = out_node.GetList(0)[iRow].GetString("HOLD_CODE");
                        spdHistory.ActiveSheet.Cells[iRow, 12].Value = out_node.GetList(0)[iRow].GetChar("START_FLAG");
                        spdHistory.ActiveSheet.Cells[iRow, 13].Value = MPCF.MakeDateFormat(out_node.GetList(0)[iRow].GetString("START_TIME"));
                        spdHistory.ActiveSheet.Cells[iRow, 14].Value = out_node.GetList(0)[iRow].GetString("START_RES_ID");
                        spdHistory.ActiveSheet.Cells[iRow, 15].Value = out_node.GetList(0)[iRow].GetChar("END_FLAG");
                        spdHistory.ActiveSheet.Cells[iRow, 16].Value = MPCF.MakeDateFormat(out_node.GetList(0)[iRow].GetString("END_TIME"));
                        spdHistory.ActiveSheet.Cells[iRow, 17].Value = out_node.GetList(0)[iRow].GetString("END_RES_ID");
                        spdHistory.ActiveSheet.Cells[iRow, 18].Value = out_node.GetList(0)[iRow].GetChar("RWK_FLAG");
                        spdHistory.ActiveSheet.Cells[iRow, 19].Value = out_node.GetList(0)[iRow].GetChar("REP_FLAG");
                        spdHistory.ActiveSheet.Cells[iRow, 20].Value = out_node.GetList(0)[iRow].GetChar("INV_FLAG");
                        spdHistory.ActiveSheet.Cells[iRow, 21].Value = out_node.GetList(0)[iRow].GetChar("FROM_TO_FLAG");
                        spdHistory.ActiveSheet.Cells[iRow, 22].Value = MPCF.MakeDateFormat(out_node.GetList(0)[iRow].GetString("OPER_IN_TIME"));
                        spdHistory.ActiveSheet.Cells[iRow, 23].Value = out_node.GetList(0)[iRow].GetString("SHIP_CODE");
                        spdHistory.ActiveSheet.Cells[iRow, 24].Value = MPCF.MakeDateFormat(out_node.GetList(0)[iRow].GetString("SHIP_TIME"));
                        spdHistory.ActiveSheet.Cells[iRow, 25].Value = MPCF.MakeDateFormat(out_node.GetList(0)[iRow].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                        spdHistory.ActiveSheet.Cells[iRow, 26].Value = out_node.GetList(0)[iRow].GetChar("LOT_DEL_FLAG");
                        spdHistory.ActiveSheet.Cells[iRow, 27].Value = out_node.GetList(0)[iRow].GetString("LOT_DEL_CODE");
                        spdHistory.ActiveSheet.Cells[iRow, 28].Value = out_node.GetList(0)[iRow].GetString("TRAN_USER_ID");
                        spdHistory.ActiveSheet.Cells[iRow, 29].Value = out_node.GetList(0)[iRow].GetString("TRAN_COMMENT");
                        spdHistory.ActiveSheet.Cells[iRow, 30].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_1");
                        spdHistory.ActiveSheet.Cells[iRow, 31].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_2");
                        spdHistory.ActiveSheet.Cells[iRow, 32].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_3");
                        spdHistory.ActiveSheet.Cells[iRow, 33].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_4");
                        spdHistory.ActiveSheet.Cells[iRow, 34].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_5");
                        spdHistory.ActiveSheet.Cells[iRow, 35].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_6");
                        spdHistory.ActiveSheet.Cells[iRow, 36].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_7");
                        spdHistory.ActiveSheet.Cells[iRow, 37].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_8");
                        spdHistory.ActiveSheet.Cells[iRow, 38].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_9");
                        spdHistory.ActiveSheet.Cells[iRow, 39].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_10");
                        spdHistory.ActiveSheet.Cells[iRow, 40].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_11");
                        spdHistory.ActiveSheet.Cells[iRow, 41].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_12");
                        spdHistory.ActiveSheet.Cells[iRow, 42].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_13");
                        spdHistory.ActiveSheet.Cells[iRow, 43].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_14");
                        spdHistory.ActiveSheet.Cells[iRow, 44].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_15");
                        spdHistory.ActiveSheet.Cells[iRow, 45].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_16");
                        spdHistory.ActiveSheet.Cells[iRow, 46].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_17");
                        spdHistory.ActiveSheet.Cells[iRow, 47].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_18");
                        spdHistory.ActiveSheet.Cells[iRow, 48].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_19");
                        spdHistory.ActiveSheet.Cells[iRow, 49].Value = out_node.GetList(0)[iRow].GetString("TRAN_CMF_20");
                    }
                }
                
                foreach (object obj in lisHist)
                {
                    out_node = null;

                    out_node = (TRSNode)obj;
                    spdHistory.ActiveSheet.RowCount = out_node.GetList(0).Count;
                }

                MPCF.FitColumnHeader(spdHistory);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion
    }
}
