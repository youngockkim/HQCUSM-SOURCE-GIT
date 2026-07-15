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

namespace SOI.WIP
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPViewLotHistoryPopup : frmPopupBase
    {
        #region Property

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

        public frmWIPViewLotHistoryPopup(string lotId)
        {
            InitializeComponent();
            txtLotID.Text = lotId;
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
        private void frmWIPViewLotHistoryPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // (Required) Grid Initialize
            // SOIGrid 사용 시,  초기화를 해야 합니다.
            gridLotHistory.InitDataSource();

            dtpFromTime.Value = DateTime.Today.AddYears(-1);

            if (ViewLotHistory(txtLotID.Text) == false)
            {
                Close();
            }

            // 활성화
            this.Activate();
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

        #endregion

        #region Functions

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

                //txtLotDesc.Text = MPCF.Trim(out_node.GetString("MAT_DESC"));

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
            TRSNode out_node;
            //List<TRSNode> lisHist;
            ArrayList lisHist = new ArrayList();

            try
            {
                //if (_model.LotHistory != null) _model.LotHistory.Clear();
                //txtLotDesc.Text = "";

                ViewLot(sLotID);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                //// From Date 설정
                //DateTime dtpDateTimeOut = new DateTime();
                //if (dtpFromTime.Value != null)
                //{
                //    bool bTrySuccess = DateTime.TryParse(dtpFromTime.Value.ToString(), out dtpDateTimeOut);
                //    if (bTrySuccess == true)
                //    {
                //        in_node.AddString("FROM_TIME", dtpDateTimeOut.ToString("yyyyMMdd"));
                //    }
                //}

                //// To Date 설정
                //if (dtpToTime.Value != null)
                //{
                //    bool bTrySuccess = DateTime.TryParse(dtpToTime.Value.ToString(), out dtpDateTimeOut);
                //    if (bTrySuccess == true)
                //    {
                //        in_node.AddString("TO_TIME", dtpDateTimeOut.ToString("yyyyMMdd"));
                //    }
                //}

                in_node.AddString("FROM_TRAN_TIME", "20000101");
                in_node.AddString("TO_TRAN_TIME", "29991231");
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                //in_node.AddChar("INCLUDE_DEL_HIST", chkIncludeDelHistory.Checked == true ? 'Y' : ' ');

                do
                {
                    out_node = new TRSNode("View_Lot_History_Out");

                    if (MPCF.CallService("WIP", "WIP_View_Lot_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisHist.Add(out_node);

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                foreach (object obj in lisHist)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        DataTable dt = gridLotHistory.GetDataSource();

                        // 2) New Row
                        DataRow dr = dt.NewRow();

                        // 3) Data Insert
                        //dr["SEQ"] = (i + 1).ToString();
                        dr["SEQ"] = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                        dr["TRAN_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        dr["TRAN_CODE"] = out_node.GetList(0)[i].GetString("TRAN_CODE");
                        dr["MAT_ID"] = out_node.GetList(0)[i].GetString("MAT_ID");
                        dr["FLOW"] = out_node.GetList(0)[i].GetString("FLOW");
                        dr["OPER"] = out_node.GetList(0)[i].GetString("OPER");
                        dr["QTY_1"] = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("QTY_1"));
                        dr["LOT_TYPE_DESC"] = out_node.GetList(0)[i].GetString("LOT_TYPE_DESC");
                        dr["LOT_STATUS"] = out_node.GetList(0)[i].GetString("LOT_STATUS");
                        dr["ORDER_ID"] = out_node.GetList(0)[i].GetString("ORDER_ID");
                        dr["HOLD_FLAG"] = out_node.GetList(0)[i].GetChar("HOLD_FLAG");
                        dr["START_FLAG"] = out_node.GetList(0)[i].GetChar("START_FLAG");
                        dr["START_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME"));
                        dr["START_RES_ID"] = out_node.GetList(0)[i].GetString("START_RES_ID");
                        dr["END_FLAG"] = out_node.GetList(0)[i].GetChar("END_FLAG");
                        dr["END_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME"));
                        dr["END_RES_ID"] = out_node.GetList(0)[i].GetString("END_RES_ID");
                        dr["RWK_FLAG"] = out_node.GetList(0)[i].GetChar("RWK_FLAG");
                        dr["REP_FLAG"] = out_node.GetList(0)[i].GetChar("REP_FLAG");
                        dr["INV_FLAG"] = out_node.GetList(0)[i].GetChar("INV_FLAG");
                        dr["FROM_TO_FLAG"] = out_node.GetList(0)[i].GetChar("FROM_TO_FLAG");
                        dr["OPER_IN_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("OPER_IN_TIME"));
                        dr["SHIP_CODE"] = out_node.GetList(0)[i].GetString("SHIP_CODE");
                        dr["SHIP_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SHIP_TIME"));
                        dr["SCH_DUE_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                        dr["LOT_DEL_FLAG"] = out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG");
                        dr["LOT_DEL_CODE"] = out_node.GetList(0)[i].GetString("LOT_DEL_CODE");
                        dr["TRAN_USER_ID"] = out_node.GetList(0)[i].GetString("TRAN_USER_ID");
                        dr["TRAN_COMMENT"] = out_node.GetList(0)[i].GetString("TRAN_COMMENT");
                        dr["TRAN_CMF_1"] = out_node.GetList(0)[i].GetString("TRAN_CMF_1");
                        dr["TRAN_CMF_2"] = out_node.GetList(0)[i].GetString("TRAN_CMF_2");
                        dr["TRAN_CMF_3"] = out_node.GetList(0)[i].GetString("TRAN_CMF_3");
                        dr["TRAN_CMF_4"] = out_node.GetList(0)[i].GetString("TRAN_CMF_4");
                        dr["TRAN_CMF_5"] = out_node.GetList(0)[i].GetString("TRAN_CMF_5");
                        dr["TRAN_CMF_6"] = out_node.GetList(0)[i].GetString("TRAN_CMF_6");
                        dr["TRAN_CMF_7"] = out_node.GetList(0)[i].GetString("TRAN_CMF_7");
                        dr["TRAN_CMF_8"] = out_node.GetList(0)[i].GetString("TRAN_CMF_8");
                        dr["TRAN_CMF_9"] = out_node.GetList(0)[i].GetString("TRAN_CMF_9");
                        dr["TRAN_CMF_10"] = out_node.GetList(0)[i].GetString("TRAN_CMF_10");
                        dr["TRAN_CMF_11"] = out_node.GetList(0)[i].GetString("TRAN_CMF_11");
                        dr["TRAN_CMF_12"] = out_node.GetList(0)[i].GetString("TRAN_CMF_12");
                        dr["TRAN_CMF_13"] = out_node.GetList(0)[i].GetString("TRAN_CMF_13");
                        dr["TRAN_CMF_14"] = out_node.GetList(0)[i].GetString("TRAN_CMF_14");
                        dr["TRAN_CMF_15"] = out_node.GetList(0)[i].GetString("TRAN_CMF_15");
                        dr["TRAN_CMF_16"] = out_node.GetList(0)[i].GetString("TRAN_CMF_16");
                        dr["TRAN_CMF_17"] = out_node.GetList(0)[i].GetString("TRAN_CMF_17");
                        dr["TRAN_CMF_18"] = out_node.GetList(0)[i].GetString("TRAN_CMF_18");
                        dr["TRAN_CMF_19"] = out_node.GetList(0)[i].GetString("TRAN_CMF_19");
                        dr["TRAN_CMF_20"] = out_node.GetList(0)[i].GetString("TRAN_CMF_20");

                        //dr[2] = "Description " + i.ToString();

                        // 4) New Row Add
                        dt.Rows.Add(dr);
                    }
                }

                // 5) Bind
                gridLotHistory.DataBind();

                MPCF.FitColumnHeader(gridLotHistory);

                //_model.LotHistory = liHist;
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
