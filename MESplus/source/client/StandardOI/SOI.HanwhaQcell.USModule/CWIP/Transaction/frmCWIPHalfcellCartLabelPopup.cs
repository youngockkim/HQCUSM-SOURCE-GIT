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
    public partial class frmCWIPHalfcellCartLabelPopup : frmPopupBase
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

        public frmCWIPHalfcellCartLabelPopup()
        {
            InitializeComponent();
            frmCWIPHalfcellCartLabel(0);
        }

        #endregion

        #region Variable Definition

        public PrintOptionModel printOption;
        public frmPrintOptionPopup frmOption;
        public static string p_order_id;
        public static string p_lack_id;

        #endregion

        #region Event Handler

        private void frmTempSOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // 활성화
            this.Activate();
        }

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

        private bool frmCWIPHalfcellCartLabel(int flag)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");
                TRSNode out_report = new TRSNode("REPORT_OUT");

                int sizeOfCart = 0;

                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = "HalfCellSlipV2";
                spdList_Flexible.ScreenSpread.Tag = "HalfCellSlipV2";
                spdList_Flexible.ProcStep = '1';
                spdList_Flexible.LotID = "HalfCellSlipV2";

                if (spdList_Flexible.LoadDesign("HalfCellSlipV2") == false)
                {
                    return false;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", p_order_id);
                in_node.AddString("LACK_ID", p_lack_id);

                if (MPCF.CallService("CRPT", "CRPT_View_Halfcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                sizeOfCart = out_node.GetInt("CART_SIZE");

                string magazineNo = string.Empty;
                string cntNo = string.Empty;
                //string cleavingTime = string.Empty;
                string cleavingDesc = string.Empty;

                if (out_node.GetList(0).Count > 0)
                {
                    out_report.SetString("CART_ID", out_node.GetList(0)[0].GetString("CART_ID"));
                    out_report.SetString("LINE", out_node.GetList(0)[0].GetString("LINE"));
                    out_report.SetString("LINE_DESC", out_node.GetList(0)[0].GetString("LINE_DESC"));
                    //out_report.SetString("EFFICIENCY", out_node.GetList(0)[0].GetString("ORDER_EFFICIENCY"));
                    //out_report.SetString("GRADE", out_node.GetList(0)[0].GetString("ORDER_GRADE"));
                    out_report.SetInt("MAGAZINE_CNT", out_node.GetList(0).Count);
                    out_report.SetDouble("HALFCELL_CNT", out_node.GetDouble("TOTAL_NUM_CELLS"));

                    out_report.SetString("MODULE_PO", out_node.GetList(0)[0].GetString("MODULE_PO"));
                    out_report.SetDouble("MODULE_PO_QTY", out_node.GetDouble("MODULE_PO_QTY"));
                    out_report.SetString("DATE_TIME", MPCF.MakeDateFormat(out_node.GetList(0)[0].GetString("DATE_TIME"), DATE_TIME_FORMAT.DATETIME));

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (i >= sizeOfCart)
                        {
                            break;
                        }

                        magazineNo = String.Format("MAGAZINE_{0}", i + 1);
                        out_report.SetString(magazineNo, MPCF.Trim(out_node.GetList(0)[i].GetString("MAGAZINE")));

                        cntNo = String.Format("QTY_{0}", i + 1);
                        out_report.SetInt(cntNo, out_node.GetList(0)[i].GetInt("QTY"));

                        cleavingDesc = String.Format("CVL_DESC_{0}", i + 1);
                        out_report.SetString(cleavingDesc, MPCF.Trim(out_node.GetList(0)[i].GetString("CLEAVING_DESC")));

                        /*
                        if (!string.IsNullOrEmpty(out_node.GetList(0)[i].GetString("CLEAVING_TIME")) 
                            && out_node.GetList(0)[i].GetString("CLEAVING_TIME").Length == 14)
                        {
                            cleavingTime = String.Format("CVL_TIME_{0}", i + 1);
                            out_report.SetString(cleavingTime, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CLEAVING_TIME"), DATE_TIME_FORMAT.DATETIME));
                        }
                        */

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
