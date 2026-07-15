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

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmCWIPFullcellCartLabelPopup : frmPopupBase
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

        #region Constant Definition

        public enum LOT_LIST
        {
            MAGAZINE,
            CNT,
            SMALLBOX,
            BATCHNO
        }

        #endregion

        #region Constructor

        public frmCWIPFullcellCartLabelPopup()
        {
            InitializeComponent();
            frmCWIPFullcellCartLabel(0);
        }

        #endregion

        #region Variable Definition

        public PrintOptionModel printOption;
        public frmPrintOptionPopup frmOption;
        public static string p_order_id;
        public static string p_lack_id;

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void soiButton1_Click(object sender, EventArgs e)
        {
            
        }

        #endregion
        
        #region Function

        private bool frmCWIPFullcellCartLabel(int flag)
        {
            try
            {   
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");
                TRSNode out_report = new TRSNode("REPORT_OUT");

                /*
                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = "FullCellSlip";
                spdList_Flexible.ScreenSpread.Tag = "FullCellSlip";

                if (spdList_Flexible.LoadDesign("FullCellSlip") == false)
                {
                    return false;
                }
                */

                spdList_Flexible.ScreenID = "FullCellSlipV2";
                spdList_Flexible.ScreenSpread.Tag = "FullCellSlipV2";

                if (spdList_Flexible.LoadDesign("FullCellSlipV2") == false)
                {
                    return false;
                }


                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", p_order_id);
                in_node.AddString("LACK_ID", p_lack_id);

                if (MPCF.CallService("CRPT", "CRPT_View_Fullcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                string magazineNo = string.Empty;
                string cntNo = string.Empty;
                string smallboxNo = string.Empty;
                string batchNo = string.Empty;

                if (out_node.GetList(0).Count > 0)
                {
                    out_report.SetString("CARRIER_ID", out_node.GetList(0)[0].GetString("CARRIER_ID"));
                    out_report.SetString("BATCH_NO", out_node.GetList(0)[0].GetString("BATCH_NO"));
                    out_report.SetString("EFFICIENCY", out_node.GetList(0)[0].GetString("EFFICIENCY"));
                    out_report.SetString("GRADE", out_node.GetList(0)[0].GetString("GRADE"));
                    //out_report.SetInt("MAGAZINE_CNT", out_node.GetList(0).Count);
                    out_report.SetDouble("MAGAZINE_CNT", out_node.GetDouble("MAGAZINE_CNT"));
                    //out_report.SetDouble("FULLCELL_CNT", out_node.GetDouble("FULLCELL_CNT"));
                    out_report.SetDouble("FULLCELL_CNT", out_node.GetDouble("TOTAL_NUM_CELLS"));
                    out_report.SetString("CLEAVING_PO", out_node.GetList(0)[0].GetString("CLEAVING_PO"));
                    out_report.SetDouble("STOCK_CELL", out_node.GetDouble("CLEAVING_PO_CNT") - out_node.GetDouble("TOTAL_NUM_CELLS"));
                    out_report.SetDouble("CLEAVING_PO_CNT", out_node.GetDouble("CLEAVING_PO_CNT"));
                    out_report.SetDouble("CLEAVING_PO_CNT2", out_node.GetDouble("CLEAVING_PO_CNT") - out_node.GetDouble("TOTAL_NUM_CELLS"));
                    //out_report.SetString("DATE_TIME", out_node.GetList(0)[0].GetString("DATE_TIME"));
                    out_report.SetString("DATE_TIME", MPCF.MakeDateFormat(out_node.GetList(0)[0].GetString("DATE_TIME"), DATE_TIME_FORMAT.DATETIME));
                    
                    int j = 0;
                    int magazineSeq = 0;
                    int boxSeq = 1;
                    int sumCount = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        // Magazine ID & Count
                        if (i < 1)
                        {
                            magazineSeq = 1;
                            boxSeq = 1;

                            magazineNo = String.Format("MAGAZINE_{0}", magazineSeq);
                            out_report.SetString(magazineNo, MPCF.Trim(out_node.GetList(0)[i].GetString("MAGAZINE")));

                            cntNo = String.Format("CNT_{0}", magazineSeq);
                            sumCount = sumCount + out_node.GetList(0)[i].GetInt("CNT");
                            out_report.SetInt(cntNo, sumCount);
                        }
                        else 
                        {
                            if (out_node.GetList(0)[i - 1].GetString("MAGAZINE") != out_node.GetList(0)[i].GetString("MAGAZINE"))
                            {
                                ++magazineSeq;
                                sumCount = 0;
                                boxSeq = 1;

                                magazineNo = String.Format("MAGAZINE_{0}", magazineSeq);
                                out_report.SetString(magazineNo, MPCF.Trim(out_node.GetList(0)[i].GetString("MAGAZINE")));

                                cntNo = String.Format("CNT_{0}", magazineSeq);
                                sumCount = sumCount + out_node.GetList(0)[i].GetInt("CNT");
                                out_report.SetInt(cntNo, sumCount);
                            }
                            else
                            {
                                cntNo = String.Format("CNT_{0}", magazineSeq);
                                sumCount = sumCount + out_node.GetList(0)[i].GetInt("CNT");
                                out_report.SetInt(cntNo, sumCount);
                            }
                            
                        }


                        // Cell Box ID
                        if (out_node.GetList(0)[i].GetInt("CNT") == 150)
                        {
                            smallboxNo = String.Format("SMALLBOX_{0}_{1}", magazineSeq, boxSeq);
                            out_report.SetString(smallboxNo, MPCF.Trim(out_node.GetList(0)[i].GetString("SMALLBOX_ID")));
                            ++boxSeq;
                        }
                        else if (out_node.GetList(0)[i].GetInt("CNT") == 300)
                        {
                            smallboxNo = String.Format("SMALLBOX_{0}_{1}", magazineSeq, 1);
                            out_report.SetString(smallboxNo, MPCF.Trim(out_node.GetList(0)[i].GetString("SMALLBOX_ID")));
                        }
                        else
                        {
                            smallboxNo = String.Format("SMALLBOX_{0}_{1}", magazineSeq, 1);
                            out_report.SetString(smallboxNo, MPCF.Trim(out_node.GetList(0)[i].GetString("SMALLBOX_ID")));
                        }

                    }


                }

                if (spdList_Flexible.SetDataToScreen(out_report) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.INFO, false);
                return false;
            }
        }

        #endregion        
    }
}
