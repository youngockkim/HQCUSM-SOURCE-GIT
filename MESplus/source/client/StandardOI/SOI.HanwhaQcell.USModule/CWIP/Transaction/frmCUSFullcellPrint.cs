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
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSFullcellPrint : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        #region Variable Definition

        private frmPrintOptionPopup frmOption;
        public string v_cart_id = string.Empty;

        #endregion

        #region Constructor

        public frmCUSFullcellPrint()
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
        private void frmTempSOIBaseForm03_Load(object sender, EventArgs e)
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
        private void frmTempSOIBaseForm03_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                MPCF.SetFocus(txtCartId);
                txtCartId.SelectAll();

                // (Required) 
                bIsShown = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(printOption.Document.PrinterName))
                {
                    MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                    MPCF.SetFocus(txtCartId);
                    txtCartId.SelectAll();
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnPrintOption_Click(object sender, EventArgs e)
        {
            // Print Option Popup
            if (frmOption == null)
            {
                frmOption = new frmPrintOptionPopup();
            }

            frmOption.Owner = this;
            frmOption.printOption = this.printOption;
            //            frmOption.funcName = this.menuInfo.s_func_name;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // clear
            spdList_Flexible.InitFlexibleScreen();
            txtCartId.Text = "";
            MPCF.SetFocus(txtCartId);
        }

        private void txtCartId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    /*
                    if (string.IsNullOrEmpty(cdvOrderNo.Text) == true)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(412));
                        MPCF.SetFocus(txtCartId);
                        return;
                    }
                    */

                    v_cart_id = txtCartId.Text;
                    ViewCart(txtCartId.Text);

                    MPCF.SetFocus(txtCartId);
                    txtCartId.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion


        #region Function

        private bool ViewCart(string CartID)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");

                PreviewLabel(out_node);

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool PreviewLabel(TRSNode out_report)
        {
            spdList_Flexible.InitFlexibleScreen();

            try
            {
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");

                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = "FullCellSlipV2";
                spdList_Flexible.ScreenSpread.Tag = "FullCellSlipV2";
                //spdList_Flexible.ProcStep = '1';
                //spdList_Flexible.LotID = "FullCellSlipV2";

                if (spdList_Flexible.LoadDesign("FullCellSlipV2") == false)
                {
                    return false;
                }

                MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                in_node.ProcStep = '4';
                //in_node.AddString("ORDER_ID", cdvOrderNo.Text);
                in_node.AddString("LACK_ID", txtCartId.Text);

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
                    out_report.SetString("DATE_TIME", out_node.GetList(0)[0].GetString("DATE_TIME"));


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
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
