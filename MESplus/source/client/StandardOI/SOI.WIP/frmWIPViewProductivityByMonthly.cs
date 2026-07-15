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

namespace SOI.WIP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPViewProductivityByMonthly : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public string SUM_D01 { get; set; }
        public string SUM_D02 { get; set; }
        public string SUM_D03 { get; set; }
        public string SUM_D04 { get; set; }
        public string SUM_D05 { get; set; }
        public string SUM_D06 { get; set; }
        public string SUM_D07 { get; set; }
        public string SUM_D08 { get; set; }
        public string SUM_D09 { get; set; }
        public string SUM_D10 { get; set; }
        public string SUM_D11 { get; set; }
        public string SUM_D12 { get; set; }
        public string SUM_D13 { get; set; }
        public string SUM_D14 { get; set; }
        public string SUM_D15 { get; set; }
        public string SUM_D16 { get; set; }
        public string SUM_D17 { get; set; }
        public string SUM_D18 { get; set; }
        public string SUM_D19 { get; set; }
        public string SUM_D20 { get; set; }
        public string SUM_D21 { get; set; }
        public string SUM_D22 { get; set; }
        public string SUM_D23 { get; set; }
        public string SUM_D24 { get; set; }
        public string SUM_D25 { get; set; }
        public string SUM_D26 { get; set; }
        public string SUM_D27 { get; set; }
        public string SUM_D28 { get; set; }
        public string SUM_D29 { get; set; }
        public string SUM_D30 { get; set; }
        public string SUM_D31 { get; set; }
        public string sMatID = "";

        #endregion

        #region Constructor

        public frmWIPViewProductivityByMonthly()
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
        private void frmWIPViewProductivityByMonthly_Load(object sender, EventArgs e)
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
        private void frmWIPViewProductivityByMonthly_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                //// (Required) Init Focus Control
                //MPCF.SetFocus(dtpPeriod);

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Mat Id CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                                
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };
                string[] header = new string[] { "Mat ID", "Mat Desc" };

                cdvMatID.Text = cdvMatID.Show(cdvMatID, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "Mat ID");

                if (cdvMatID == null || cdvMatID.Text == string.Empty)
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
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear
                MPCF.ClearList(this.spdData);

                if (ViewProductivity() == false)
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
        /// Clear Summary Data
        /// </summary>
        /// <returns></returns>
        private void ClearSumData()
        {
            SUM_D01 = "";
            SUM_D02 = "";
            SUM_D03 = "";
            SUM_D04 = "";
            SUM_D05 = "";
            SUM_D06 = "";
            SUM_D07 = "";
            SUM_D08 = "";
            SUM_D09 = "";
            SUM_D10 = "";
            SUM_D11 = "";
            SUM_D12 = "";
            SUM_D13 = "";
            SUM_D14 = "";
            SUM_D15 = "";
            SUM_D16 = "";
            SUM_D17 = "";
            SUM_D18 = "";
            SUM_D19 = "";
            SUM_D20 = "";
            SUM_D21 = "";
            SUM_D22 = "";
            SUM_D23 = "";
            SUM_D24 = "";
            SUM_D25 = "";
            SUM_D26 = "";
            SUM_D27 = "";
            SUM_D28 = "";
            SUM_D29 = "";
            SUM_D30 = "";
            SUM_D31 = "";
        }

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewProductivity()
        {
            TRSNode in_node = new TRSNode("VIEW_MONTHLY_PRODUCTIVITY_IN");
            TRSNode out_node = new TRSNode("VIEW_MONTHLY_PRODUCTIVITY_OUT");
            ArrayList dataList = new ArrayList();
            ArrayList passList = new ArrayList();
            ArrayList lossList = new ArrayList();
            ArrayList yieldList = new ArrayList();
            int j = 0;
            int k = 0;
            int l = 0;

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MONTH", dtpPeriod.GetValue(8));

                if (cdvMatID != null && cdvMatID.Text != "")
                {
                    in_node.AddString("MAT_ID", cdvMatID.Text);
                }

                if (MPCF.CallService("RPT", "RPT_View_Monthly_Productivity", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Init
                sMatID = string.Empty;
                k = spdData.ActiveSheet.RowCount;

                // List
                foreach (TRSNode node in out_node.GetList(0))
                {
                    // Init                    
                    l = 0;

                    // Pass Data
                    DataInfo passData = new DataInfo(MPCF.FindLanguage("Pass Qty"), node.GetString("MAT_ID"));                    
                    foreach (TRSNode day in node.GetList(0))
                    {
                        passData.Set(day.GetString("DAY"), day.GetDouble("PASS_QTY").ToString());
                    }
                    passList.Add(passData);

                    // 
                    if (passList.Count > 0 && sMatID != passData.MatId)
                    {
                        for (int i = 0; i < passList.Count; i++)
                        {
                            if (sMatID == passData.MatId)
                            {
                                l++;
                                continue;
                            }

                            spdData.ActiveSheet.RowCount++;
                            spdData.ActiveSheet.Cells[i + j, 0].Value = passData.Category;
                            spdData.ActiveSheet.Cells[i + j, 1].Value = passData.MatId;
                            sMatID = passData.MatId;
                            spdData.ActiveSheet.Cells[i + j, 2].Value = MPCF.MakeNumberFormat(passData.D01);
                            spdData.ActiveSheet.Cells[i + j, 3].Value = MPCF.MakeNumberFormat(passData.D02);
                            spdData.ActiveSheet.Cells[i + j, 4].Value = MPCF.MakeNumberFormat(passData.D03);
                            spdData.ActiveSheet.Cells[i + j, 5].Value = MPCF.MakeNumberFormat(passData.D04);
                            spdData.ActiveSheet.Cells[i + j, 6].Value = MPCF.MakeNumberFormat(passData.D05);
                            spdData.ActiveSheet.Cells[i + j, 7].Value = MPCF.MakeNumberFormat(passData.D06);
                            spdData.ActiveSheet.Cells[i + j, 8].Value = MPCF.MakeNumberFormat(passData.D07);
                            spdData.ActiveSheet.Cells[i + j, 9].Value = MPCF.MakeNumberFormat(passData.D08);
                            spdData.ActiveSheet.Cells[i + j, 10].Value = MPCF.MakeNumberFormat(passData.D09);
                            spdData.ActiveSheet.Cells[i + j, 11].Value = MPCF.MakeNumberFormat(passData.D10);
                            spdData.ActiveSheet.Cells[i + j, 12].Value = MPCF.MakeNumberFormat(passData.D11);
                            spdData.ActiveSheet.Cells[i + j, 13].Value = MPCF.MakeNumberFormat(passData.D12);
                            spdData.ActiveSheet.Cells[i + j, 14].Value = MPCF.MakeNumberFormat(passData.D13);
                            spdData.ActiveSheet.Cells[i + j, 15].Value = MPCF.MakeNumberFormat(passData.D14);
                            spdData.ActiveSheet.Cells[i + j, 16].Value = MPCF.MakeNumberFormat(passData.D15);
                            spdData.ActiveSheet.Cells[i + j, 17].Value = MPCF.MakeNumberFormat(passData.D16);
                            spdData.ActiveSheet.Cells[i + j, 18].Value = MPCF.MakeNumberFormat(passData.D17);
                            spdData.ActiveSheet.Cells[i + j, 19].Value = MPCF.MakeNumberFormat(passData.D18);
                            spdData.ActiveSheet.Cells[i + j, 20].Value = MPCF.MakeNumberFormat(passData.D19);
                            spdData.ActiveSheet.Cells[i + j, 21].Value = MPCF.MakeNumberFormat(passData.D20);
                            spdData.ActiveSheet.Cells[i + j, 22].Value = MPCF.MakeNumberFormat(passData.D21);
                            spdData.ActiveSheet.Cells[i + j, 23].Value = MPCF.MakeNumberFormat(passData.D22);
                            spdData.ActiveSheet.Cells[i + j, 24].Value = MPCF.MakeNumberFormat(passData.D23);
                            spdData.ActiveSheet.Cells[i + j, 25].Value = MPCF.MakeNumberFormat(passData.D24);
                            spdData.ActiveSheet.Cells[i + j, 26].Value = MPCF.MakeNumberFormat(passData.D25);
                            spdData.ActiveSheet.Cells[i + j, 27].Value = MPCF.MakeNumberFormat(passData.D26);
                            spdData.ActiveSheet.Cells[i + j, 28].Value = MPCF.MakeNumberFormat(passData.D27);
                            spdData.ActiveSheet.Cells[i + j, 29].Value = MPCF.MakeNumberFormat(passData.D28);
                            spdData.ActiveSheet.Cells[i + j, 30].Value = MPCF.MakeNumberFormat(passData.D29);
                            spdData.ActiveSheet.Cells[i + j, 31].Value = MPCF.MakeNumberFormat(passData.D30);
                            spdData.ActiveSheet.Cells[i + j, 32].Value = MPCF.MakeNumberFormat(passData.D31);

                            SUM_D01 = (MPCF.ToDbl(SUM_D01) + MPCF.ToDbl(passData.D01)).ToString();
                            SUM_D02 = (MPCF.ToDbl(SUM_D02) + MPCF.ToDbl(passData.D02)).ToString();
                            SUM_D03 = (MPCF.ToDbl(SUM_D03) + MPCF.ToDbl(passData.D03)).ToString();
                            SUM_D04 = (MPCF.ToDbl(SUM_D04) + MPCF.ToDbl(passData.D04)).ToString();
                            SUM_D05 = (MPCF.ToDbl(SUM_D05) + MPCF.ToDbl(passData.D05)).ToString();
                            SUM_D06 = (MPCF.ToDbl(SUM_D06) + MPCF.ToDbl(passData.D06)).ToString();
                            SUM_D07 = (MPCF.ToDbl(SUM_D07) + MPCF.ToDbl(passData.D07)).ToString();
                            SUM_D08 = (MPCF.ToDbl(SUM_D08) + MPCF.ToDbl(passData.D08)).ToString();
                            SUM_D09 = (MPCF.ToDbl(SUM_D09) + MPCF.ToDbl(passData.D09)).ToString();
                            SUM_D10 = (MPCF.ToDbl(SUM_D10) + MPCF.ToDbl(passData.D10)).ToString();
                            SUM_D11 = (MPCF.ToDbl(SUM_D11) + MPCF.ToDbl(passData.D11)).ToString();
                            SUM_D12 = (MPCF.ToDbl(SUM_D12) + MPCF.ToDbl(passData.D12)).ToString();
                            SUM_D13 = (MPCF.ToDbl(SUM_D13) + MPCF.ToDbl(passData.D13)).ToString();
                            SUM_D14 = (MPCF.ToDbl(SUM_D14) + MPCF.ToDbl(passData.D14)).ToString();
                            SUM_D15 = (MPCF.ToDbl(SUM_D15) + MPCF.ToDbl(passData.D15)).ToString();
                            SUM_D16 = (MPCF.ToDbl(SUM_D16) + MPCF.ToDbl(passData.D16)).ToString();
                            SUM_D17 = (MPCF.ToDbl(SUM_D17) + MPCF.ToDbl(passData.D17)).ToString();
                            SUM_D18 = (MPCF.ToDbl(SUM_D18) + MPCF.ToDbl(passData.D18)).ToString();
                            SUM_D19 = (MPCF.ToDbl(SUM_D19) + MPCF.ToDbl(passData.D19)).ToString();
                            SUM_D20 = (MPCF.ToDbl(SUM_D20) + MPCF.ToDbl(passData.D20)).ToString();
                            SUM_D21 = (MPCF.ToDbl(SUM_D21) + MPCF.ToDbl(passData.D21)).ToString();
                            SUM_D22 = (MPCF.ToDbl(SUM_D22) + MPCF.ToDbl(passData.D22)).ToString();
                            SUM_D23 = (MPCF.ToDbl(SUM_D23) + MPCF.ToDbl(passData.D23)).ToString();
                            SUM_D24 = (MPCF.ToDbl(SUM_D24) + MPCF.ToDbl(passData.D24)).ToString();
                            SUM_D25 = (MPCF.ToDbl(SUM_D25) + MPCF.ToDbl(passData.D25)).ToString();
                            SUM_D26 = (MPCF.ToDbl(SUM_D26) + MPCF.ToDbl(passData.D26)).ToString();
                            SUM_D27 = (MPCF.ToDbl(SUM_D27) + MPCF.ToDbl(passData.D27)).ToString();
                            SUM_D28 = (MPCF.ToDbl(SUM_D28) + MPCF.ToDbl(passData.D28)).ToString();
                            SUM_D29 = (MPCF.ToDbl(SUM_D29) + MPCF.ToDbl(passData.D29)).ToString();
                            SUM_D30 = (MPCF.ToDbl(SUM_D30) + MPCF.ToDbl(passData.D30)).ToString();
                            SUM_D31 = (MPCF.ToDbl(SUM_D31) + MPCF.ToDbl(passData.D31)).ToString();
                        }

                        j += passList.Count - l;
                    }
                }

                if (j > 0)
                {
                    spdData.ActiveSheet.RowCount++;
                    spdData.ActiveSheet.Cells[j, 1].Value = MPCF.FindLanguage("Total");
                    spdData.ActiveSheet.Cells[j, 2].Value = MPCF.MakeNumberFormat(SUM_D01);
                    spdData.ActiveSheet.Cells[j, 3].Value = MPCF.MakeNumberFormat(SUM_D02);
                    spdData.ActiveSheet.Cells[j, 4].Value = MPCF.MakeNumberFormat(SUM_D03);
                    spdData.ActiveSheet.Cells[j, 5].Value = MPCF.MakeNumberFormat(SUM_D04);
                    spdData.ActiveSheet.Cells[j, 6].Value = MPCF.MakeNumberFormat(SUM_D05);
                    spdData.ActiveSheet.Cells[j, 7].Value = MPCF.MakeNumberFormat(SUM_D06);
                    spdData.ActiveSheet.Cells[j, 8].Value = MPCF.MakeNumberFormat(SUM_D07);
                    spdData.ActiveSheet.Cells[j, 9].Value = MPCF.MakeNumberFormat(SUM_D08);
                    spdData.ActiveSheet.Cells[j, 10].Value = MPCF.MakeNumberFormat(SUM_D09);
                    spdData.ActiveSheet.Cells[j, 11].Value = MPCF.MakeNumberFormat(SUM_D10);
                    spdData.ActiveSheet.Cells[j, 12].Value = MPCF.MakeNumberFormat(SUM_D11);
                    spdData.ActiveSheet.Cells[j, 13].Value = MPCF.MakeNumberFormat(SUM_D12);
                    spdData.ActiveSheet.Cells[j, 14].Value = MPCF.MakeNumberFormat(SUM_D13);
                    spdData.ActiveSheet.Cells[j, 15].Value = MPCF.MakeNumberFormat(SUM_D14);
                    spdData.ActiveSheet.Cells[j, 16].Value = MPCF.MakeNumberFormat(SUM_D15);
                    spdData.ActiveSheet.Cells[j, 17].Value = MPCF.MakeNumberFormat(SUM_D16);
                    spdData.ActiveSheet.Cells[j, 18].Value = MPCF.MakeNumberFormat(SUM_D17);
                    spdData.ActiveSheet.Cells[j, 19].Value = MPCF.MakeNumberFormat(SUM_D18);
                    spdData.ActiveSheet.Cells[j, 20].Value = MPCF.MakeNumberFormat(SUM_D19);
                    spdData.ActiveSheet.Cells[j, 21].Value = MPCF.MakeNumberFormat(SUM_D20);
                    spdData.ActiveSheet.Cells[j, 22].Value = MPCF.MakeNumberFormat(SUM_D21);
                    spdData.ActiveSheet.Cells[j, 23].Value = MPCF.MakeNumberFormat(SUM_D22);
                    spdData.ActiveSheet.Cells[j, 24].Value = MPCF.MakeNumberFormat(SUM_D23);
                    spdData.ActiveSheet.Cells[j, 25].Value = MPCF.MakeNumberFormat(SUM_D24);
                    spdData.ActiveSheet.Cells[j, 26].Value = MPCF.MakeNumberFormat(SUM_D25);
                    spdData.ActiveSheet.Cells[j, 27].Value = MPCF.MakeNumberFormat(SUM_D26);
                    spdData.ActiveSheet.Cells[j, 28].Value = MPCF.MakeNumberFormat(SUM_D27);
                    spdData.ActiveSheet.Cells[j, 29].Value = MPCF.MakeNumberFormat(SUM_D28);
                    spdData.ActiveSheet.Cells[j, 30].Value = MPCF.MakeNumberFormat(SUM_D29);
                    spdData.ActiveSheet.Cells[j, 31].Value = MPCF.MakeNumberFormat(SUM_D30);
                    spdData.ActiveSheet.Cells[j, 32].Value = MPCF.MakeNumberFormat(SUM_D31);
                    j += 1;
                }

                if (j > 0)
                {
                    spdData.ActiveSheet.Cells.Get(k, 0).RowSpan = j - k;
                }

                ClearSumData();

                k = spdData.ActiveSheet.RowCount;

                sMatID = "";

                foreach (TRSNode node in out_node.GetList(0))
                {
                    DataInfo lossData = new DataInfo(MPCF.FindLanguage("Loss Qty"), node.GetString("MAT_ID"));
                    l = 0;
                    foreach (TRSNode day in node.GetList(0))
                    {
                        lossData.Set(day.GetString("DAY"), day.GetDouble("LOSS_QTY").ToString());
                    }

                    lossList.Add(lossData);

                    if (lossList.Count > 0)
                    {
                        for (int i = 0; i < lossList.Count; i++)
                        {
                            if (sMatID == lossData.MatId)
                            {
                                l++;
                                continue;
                            }
                            spdData.ActiveSheet.RowCount++;
                            spdData.ActiveSheet.Cells[i + j, 0].Value = lossData.Category;
                            spdData.ActiveSheet.Cells[i + j, 1].Value = lossData.MatId;
                            sMatID = lossData.MatId;
                            spdData.ActiveSheet.Cells[i + j, 2].Value = MPCF.MakeNumberFormat(lossData.D01);
                            spdData.ActiveSheet.Cells[i + j, 3].Value = MPCF.MakeNumberFormat(lossData.D02);
                            spdData.ActiveSheet.Cells[i + j, 4].Value = MPCF.MakeNumberFormat(lossData.D03);
                            spdData.ActiveSheet.Cells[i + j, 5].Value = MPCF.MakeNumberFormat(lossData.D04);
                            spdData.ActiveSheet.Cells[i + j, 6].Value = MPCF.MakeNumberFormat(lossData.D05);
                            spdData.ActiveSheet.Cells[i + j, 7].Value = MPCF.MakeNumberFormat(lossData.D06);
                            spdData.ActiveSheet.Cells[i + j, 8].Value = MPCF.MakeNumberFormat(lossData.D07);
                            spdData.ActiveSheet.Cells[i + j, 9].Value = MPCF.MakeNumberFormat(lossData.D08);
                            spdData.ActiveSheet.Cells[i + j, 10].Value = MPCF.MakeNumberFormat(lossData.D09);
                            spdData.ActiveSheet.Cells[i + j, 11].Value = MPCF.MakeNumberFormat(lossData.D10);
                            spdData.ActiveSheet.Cells[i + j, 12].Value = MPCF.MakeNumberFormat(lossData.D11);
                            spdData.ActiveSheet.Cells[i + j, 13].Value = MPCF.MakeNumberFormat(lossData.D12);
                            spdData.ActiveSheet.Cells[i + j, 14].Value = MPCF.MakeNumberFormat(lossData.D13);
                            spdData.ActiveSheet.Cells[i + j, 15].Value = MPCF.MakeNumberFormat(lossData.D14);
                            spdData.ActiveSheet.Cells[i + j, 16].Value = MPCF.MakeNumberFormat(lossData.D15);
                            spdData.ActiveSheet.Cells[i + j, 17].Value = MPCF.MakeNumberFormat(lossData.D16);
                            spdData.ActiveSheet.Cells[i + j, 18].Value = MPCF.MakeNumberFormat(lossData.D17);
                            spdData.ActiveSheet.Cells[i + j, 19].Value = MPCF.MakeNumberFormat(lossData.D18);
                            spdData.ActiveSheet.Cells[i + j, 20].Value = MPCF.MakeNumberFormat(lossData.D19);
                            spdData.ActiveSheet.Cells[i + j, 21].Value = MPCF.MakeNumberFormat(lossData.D20);
                            spdData.ActiveSheet.Cells[i + j, 22].Value = MPCF.MakeNumberFormat(lossData.D21);
                            spdData.ActiveSheet.Cells[i + j, 23].Value = MPCF.MakeNumberFormat(lossData.D22);
                            spdData.ActiveSheet.Cells[i + j, 24].Value = MPCF.MakeNumberFormat(lossData.D23);
                            spdData.ActiveSheet.Cells[i + j, 25].Value = MPCF.MakeNumberFormat(lossData.D24);
                            spdData.ActiveSheet.Cells[i + j, 26].Value = MPCF.MakeNumberFormat(lossData.D25);
                            spdData.ActiveSheet.Cells[i + j, 27].Value = MPCF.MakeNumberFormat(lossData.D26);
                            spdData.ActiveSheet.Cells[i + j, 28].Value = MPCF.MakeNumberFormat(lossData.D27);
                            spdData.ActiveSheet.Cells[i + j, 29].Value = MPCF.MakeNumberFormat(lossData.D28);
                            spdData.ActiveSheet.Cells[i + j, 30].Value = MPCF.MakeNumberFormat(lossData.D29);
                            spdData.ActiveSheet.Cells[i + j, 31].Value = MPCF.MakeNumberFormat(lossData.D30);
                            spdData.ActiveSheet.Cells[i + j, 32].Value = MPCF.MakeNumberFormat(lossData.D31);

                            SUM_D01 = (MPCF.ToDbl(SUM_D01) + MPCF.ToDbl(lossData.D01)).ToString();
                            SUM_D02 = (MPCF.ToDbl(SUM_D02) + MPCF.ToDbl(lossData.D02)).ToString();
                            SUM_D03 = (MPCF.ToDbl(SUM_D03) + MPCF.ToDbl(lossData.D03)).ToString();
                            SUM_D04 = (MPCF.ToDbl(SUM_D04) + MPCF.ToDbl(lossData.D04)).ToString();
                            SUM_D05 = (MPCF.ToDbl(SUM_D05) + MPCF.ToDbl(lossData.D05)).ToString();
                            SUM_D06 = (MPCF.ToDbl(SUM_D06) + MPCF.ToDbl(lossData.D06)).ToString();
                            SUM_D07 = (MPCF.ToDbl(SUM_D07) + MPCF.ToDbl(lossData.D07)).ToString();
                            SUM_D08 = (MPCF.ToDbl(SUM_D08) + MPCF.ToDbl(lossData.D08)).ToString();
                            SUM_D09 = (MPCF.ToDbl(SUM_D09) + MPCF.ToDbl(lossData.D09)).ToString();
                            SUM_D10 = (MPCF.ToDbl(SUM_D10) + MPCF.ToDbl(lossData.D10)).ToString();
                            SUM_D11 = (MPCF.ToDbl(SUM_D11) + MPCF.ToDbl(lossData.D11)).ToString();
                            SUM_D12 = (MPCF.ToDbl(SUM_D12) + MPCF.ToDbl(lossData.D12)).ToString();
                            SUM_D13 = (MPCF.ToDbl(SUM_D13) + MPCF.ToDbl(lossData.D13)).ToString();
                            SUM_D14 = (MPCF.ToDbl(SUM_D14) + MPCF.ToDbl(lossData.D14)).ToString();
                            SUM_D15 = (MPCF.ToDbl(SUM_D15) + MPCF.ToDbl(lossData.D15)).ToString();
                            SUM_D16 = (MPCF.ToDbl(SUM_D16) + MPCF.ToDbl(lossData.D16)).ToString();
                            SUM_D17 = (MPCF.ToDbl(SUM_D17) + MPCF.ToDbl(lossData.D17)).ToString();
                            SUM_D18 = (MPCF.ToDbl(SUM_D18) + MPCF.ToDbl(lossData.D18)).ToString();
                            SUM_D19 = (MPCF.ToDbl(SUM_D19) + MPCF.ToDbl(lossData.D19)).ToString();
                            SUM_D20 = (MPCF.ToDbl(SUM_D20) + MPCF.ToDbl(lossData.D20)).ToString();
                            SUM_D21 = (MPCF.ToDbl(SUM_D21) + MPCF.ToDbl(lossData.D21)).ToString();
                            SUM_D22 = (MPCF.ToDbl(SUM_D22) + MPCF.ToDbl(lossData.D22)).ToString();
                            SUM_D23 = (MPCF.ToDbl(SUM_D23) + MPCF.ToDbl(lossData.D23)).ToString();
                            SUM_D24 = (MPCF.ToDbl(SUM_D24) + MPCF.ToDbl(lossData.D24)).ToString();
                            SUM_D25 = (MPCF.ToDbl(SUM_D25) + MPCF.ToDbl(lossData.D25)).ToString();
                            SUM_D26 = (MPCF.ToDbl(SUM_D26) + MPCF.ToDbl(lossData.D26)).ToString();
                            SUM_D27 = (MPCF.ToDbl(SUM_D27) + MPCF.ToDbl(lossData.D27)).ToString();
                            SUM_D28 = (MPCF.ToDbl(SUM_D28) + MPCF.ToDbl(lossData.D28)).ToString();
                            SUM_D29 = (MPCF.ToDbl(SUM_D29) + MPCF.ToDbl(lossData.D29)).ToString();
                            SUM_D30 = (MPCF.ToDbl(SUM_D30) + MPCF.ToDbl(lossData.D30)).ToString();
                            SUM_D31 = (MPCF.ToDbl(SUM_D31) + MPCF.ToDbl(lossData.D31)).ToString();

                        }
                        j += lossList.Count - l;
                    }
                }

                if (j > 0)
                {
                    spdData.ActiveSheet.RowCount++;
                    spdData.ActiveSheet.Cells[j, 1].Value = MPCF.FindLanguage("Total");
                    spdData.ActiveSheet.Cells[j, 2].Value = MPCF.MakeNumberFormat(SUM_D01);
                    spdData.ActiveSheet.Cells[j, 3].Value = MPCF.MakeNumberFormat(SUM_D02);
                    spdData.ActiveSheet.Cells[j, 4].Value = MPCF.MakeNumberFormat(SUM_D03);
                    spdData.ActiveSheet.Cells[j, 5].Value = MPCF.MakeNumberFormat(SUM_D04);
                    spdData.ActiveSheet.Cells[j, 6].Value = MPCF.MakeNumberFormat(SUM_D05);
                    spdData.ActiveSheet.Cells[j, 7].Value = MPCF.MakeNumberFormat(SUM_D06);
                    spdData.ActiveSheet.Cells[j, 8].Value = MPCF.MakeNumberFormat(SUM_D07);
                    spdData.ActiveSheet.Cells[j, 9].Value = MPCF.MakeNumberFormat(SUM_D08);
                    spdData.ActiveSheet.Cells[j, 10].Value = MPCF.MakeNumberFormat(SUM_D09);
                    spdData.ActiveSheet.Cells[j, 11].Value = MPCF.MakeNumberFormat(SUM_D10);
                    spdData.ActiveSheet.Cells[j, 12].Value = MPCF.MakeNumberFormat(SUM_D11);
                    spdData.ActiveSheet.Cells[j, 13].Value = MPCF.MakeNumberFormat(SUM_D12);
                    spdData.ActiveSheet.Cells[j, 14].Value = MPCF.MakeNumberFormat(SUM_D13);
                    spdData.ActiveSheet.Cells[j, 15].Value = MPCF.MakeNumberFormat(SUM_D14);
                    spdData.ActiveSheet.Cells[j, 16].Value = MPCF.MakeNumberFormat(SUM_D15);
                    spdData.ActiveSheet.Cells[j, 17].Value = MPCF.MakeNumberFormat(SUM_D16);
                    spdData.ActiveSheet.Cells[j, 18].Value = MPCF.MakeNumberFormat(SUM_D17);
                    spdData.ActiveSheet.Cells[j, 19].Value = MPCF.MakeNumberFormat(SUM_D18);
                    spdData.ActiveSheet.Cells[j, 20].Value = MPCF.MakeNumberFormat(SUM_D19);
                    spdData.ActiveSheet.Cells[j, 21].Value = MPCF.MakeNumberFormat(SUM_D20);
                    spdData.ActiveSheet.Cells[j, 22].Value = MPCF.MakeNumberFormat(SUM_D21);
                    spdData.ActiveSheet.Cells[j, 23].Value = MPCF.MakeNumberFormat(SUM_D22);
                    spdData.ActiveSheet.Cells[j, 24].Value = MPCF.MakeNumberFormat(SUM_D23);
                    spdData.ActiveSheet.Cells[j, 25].Value = MPCF.MakeNumberFormat(SUM_D24);
                    spdData.ActiveSheet.Cells[j, 26].Value = MPCF.MakeNumberFormat(SUM_D25);
                    spdData.ActiveSheet.Cells[j, 27].Value = MPCF.MakeNumberFormat(SUM_D26);
                    spdData.ActiveSheet.Cells[j, 28].Value = MPCF.MakeNumberFormat(SUM_D27);
                    spdData.ActiveSheet.Cells[j, 29].Value = MPCF.MakeNumberFormat(SUM_D28);
                    spdData.ActiveSheet.Cells[j, 30].Value = MPCF.MakeNumberFormat(SUM_D29);
                    spdData.ActiveSheet.Cells[j, 31].Value = MPCF.MakeNumberFormat(SUM_D30);
                    spdData.ActiveSheet.Cells[j, 32].Value = MPCF.MakeNumberFormat(SUM_D31);
                    j += 1;
                }

                if (j > 0)
                {
                    spdData.ActiveSheet.Cells.Get(k, 0).RowSpan = j - k;
                }

                ClearSumData();

                k = spdData.ActiveSheet.RowCount;

                sMatID = "";

                foreach (TRSNode node in out_node.GetList(0))
                {
                    DataInfo yieldData = new DataInfo(MPCF.FindLanguage("Yield"), node.GetString("MAT_ID"));
                    l = 0;
                    foreach (TRSNode day in node.GetList(0))
                    {
                        yieldData.Set(day.GetString("DAY"), day.GetDouble("YIELD").ToString());
                    }

                    yieldList.Add(yieldData);

                    if (yieldList.Count > 0)
                    {
                        for (int i = 0; i < yieldList.Count; i++)
                        {
                            if (sMatID == yieldData.MatId)
                            {
                                l++;
                                continue;
                            }

                            spdData.ActiveSheet.RowCount++;
                            spdData.ActiveSheet.Cells[i + j, 0].Value = yieldData.Category;
                            spdData.ActiveSheet.Cells[i + j, 1].Value = yieldData.MatId;
                            sMatID = yieldData.MatId;
                            spdData.ActiveSheet.Cells[i + j, 2].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D01), 1);
                            spdData.ActiveSheet.Cells[i + j, 3].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D02), 1);
                            spdData.ActiveSheet.Cells[i + j, 4].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D03), 1);
                            spdData.ActiveSheet.Cells[i + j, 5].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D04), 1);
                            spdData.ActiveSheet.Cells[i + j, 6].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D05), 1);
                            spdData.ActiveSheet.Cells[i + j, 7].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D06), 1);
                            spdData.ActiveSheet.Cells[i + j, 8].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D07), 1);
                            spdData.ActiveSheet.Cells[i + j, 9].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D08), 1);
                            spdData.ActiveSheet.Cells[i + j, 10].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D09), 1);
                            spdData.ActiveSheet.Cells[i + j, 11].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D10), 1);
                            spdData.ActiveSheet.Cells[i + j, 12].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D11), 1);
                            spdData.ActiveSheet.Cells[i + j, 13].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D12), 1);
                            spdData.ActiveSheet.Cells[i + j, 14].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D13), 1);
                            spdData.ActiveSheet.Cells[i + j, 15].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D14), 1);
                            spdData.ActiveSheet.Cells[i + j, 16].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D15), 1);
                            spdData.ActiveSheet.Cells[i + j, 17].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D16), 1);
                            spdData.ActiveSheet.Cells[i + j, 18].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D17), 1);
                            spdData.ActiveSheet.Cells[i + j, 19].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D18), 1);
                            spdData.ActiveSheet.Cells[i + j, 20].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D19), 1);
                            spdData.ActiveSheet.Cells[i + j, 21].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D20), 1);
                            spdData.ActiveSheet.Cells[i + j, 22].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D21), 1);
                            spdData.ActiveSheet.Cells[i + j, 23].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D22), 1);
                            spdData.ActiveSheet.Cells[i + j, 24].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D23), 1);
                            spdData.ActiveSheet.Cells[i + j, 25].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D24), 1);
                            spdData.ActiveSheet.Cells[i + j, 26].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D25), 1);
                            spdData.ActiveSheet.Cells[i + j, 27].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D26), 1);
                            spdData.ActiveSheet.Cells[i + j, 28].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D27), 1);
                            spdData.ActiveSheet.Cells[i + j, 29].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D28), 1);
                            spdData.ActiveSheet.Cells[i + j, 30].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D29), 1);
                            spdData.ActiveSheet.Cells[i + j, 31].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D30), 1);
                            spdData.ActiveSheet.Cells[i + j, 32].Value = MPCF.DoubleToString(MPCF.ToDbl(yieldData.D31), 1);

                            SUM_D01 = (MPCF.ToDbl(SUM_D01) + MPCF.ToDbl(yieldData.D01)).ToString();
                            SUM_D02 = (MPCF.ToDbl(SUM_D02) + MPCF.ToDbl(yieldData.D02)).ToString();
                            SUM_D03 = (MPCF.ToDbl(SUM_D03) + MPCF.ToDbl(yieldData.D03)).ToString();
                            SUM_D04 = (MPCF.ToDbl(SUM_D04) + MPCF.ToDbl(yieldData.D04)).ToString();
                            SUM_D05 = (MPCF.ToDbl(SUM_D05) + MPCF.ToDbl(yieldData.D05)).ToString();
                            SUM_D06 = (MPCF.ToDbl(SUM_D06) + MPCF.ToDbl(yieldData.D06)).ToString();
                            SUM_D07 = (MPCF.ToDbl(SUM_D07) + MPCF.ToDbl(yieldData.D07)).ToString();
                            SUM_D08 = (MPCF.ToDbl(SUM_D08) + MPCF.ToDbl(yieldData.D08)).ToString();
                            SUM_D09 = (MPCF.ToDbl(SUM_D09) + MPCF.ToDbl(yieldData.D09)).ToString();
                            SUM_D10 = (MPCF.ToDbl(SUM_D10) + MPCF.ToDbl(yieldData.D10)).ToString();
                            SUM_D11 = (MPCF.ToDbl(SUM_D11) + MPCF.ToDbl(yieldData.D11)).ToString();
                            SUM_D12 = (MPCF.ToDbl(SUM_D12) + MPCF.ToDbl(yieldData.D12)).ToString();
                            SUM_D13 = (MPCF.ToDbl(SUM_D13) + MPCF.ToDbl(yieldData.D13)).ToString();
                            SUM_D14 = (MPCF.ToDbl(SUM_D14) + MPCF.ToDbl(yieldData.D14)).ToString();
                            SUM_D15 = (MPCF.ToDbl(SUM_D15) + MPCF.ToDbl(yieldData.D15)).ToString();
                            SUM_D16 = (MPCF.ToDbl(SUM_D16) + MPCF.ToDbl(yieldData.D16)).ToString();
                            SUM_D17 = (MPCF.ToDbl(SUM_D17) + MPCF.ToDbl(yieldData.D17)).ToString();
                            SUM_D18 = (MPCF.ToDbl(SUM_D18) + MPCF.ToDbl(yieldData.D18)).ToString();
                            SUM_D19 = (MPCF.ToDbl(SUM_D19) + MPCF.ToDbl(yieldData.D19)).ToString();
                            SUM_D20 = (MPCF.ToDbl(SUM_D20) + MPCF.ToDbl(yieldData.D20)).ToString();
                            SUM_D21 = (MPCF.ToDbl(SUM_D21) + MPCF.ToDbl(yieldData.D21)).ToString();
                            SUM_D22 = (MPCF.ToDbl(SUM_D22) + MPCF.ToDbl(yieldData.D22)).ToString();
                            SUM_D23 = (MPCF.ToDbl(SUM_D23) + MPCF.ToDbl(yieldData.D23)).ToString();
                            SUM_D24 = (MPCF.ToDbl(SUM_D24) + MPCF.ToDbl(yieldData.D24)).ToString();
                            SUM_D25 = (MPCF.ToDbl(SUM_D25) + MPCF.ToDbl(yieldData.D25)).ToString();
                            SUM_D26 = (MPCF.ToDbl(SUM_D26) + MPCF.ToDbl(yieldData.D26)).ToString();
                            SUM_D27 = (MPCF.ToDbl(SUM_D27) + MPCF.ToDbl(yieldData.D27)).ToString();
                            SUM_D28 = (MPCF.ToDbl(SUM_D28) + MPCF.ToDbl(yieldData.D28)).ToString();
                            SUM_D29 = (MPCF.ToDbl(SUM_D29) + MPCF.ToDbl(yieldData.D29)).ToString();
                            SUM_D30 = (MPCF.ToDbl(SUM_D30) + MPCF.ToDbl(yieldData.D30)).ToString();
                            SUM_D31 = (MPCF.ToDbl(SUM_D31) + MPCF.ToDbl(yieldData.D31)).ToString();
                        }
                        j += yieldList.Count - l;
                    }
                }

                if (j > 0)
                {
                    spdData.ActiveSheet.RowCount++;
                    spdData.ActiveSheet.Cells[j, 1].Value = MPCF.FindLanguage("Average");
                    spdData.ActiveSheet.Cells[j, 2].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D01) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 3].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D02) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 4].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D03) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 5].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D04) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 6].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D05) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 7].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D06) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 8].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D07) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 9].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D08) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 10].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D09) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 11].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D10) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 12].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D11) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 13].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D12) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 14].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D13) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 15].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D14) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 16].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D15) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 17].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D16) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 18].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D17) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 19].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D18) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 20].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D19) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 21].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D20) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 22].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D21) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 23].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D22) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 24].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D23) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 25].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D24) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 26].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D25) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 27].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D26) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 28].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D27) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 29].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D28) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 30].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D29) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 31].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D30) / yieldList.Count), 1);
                    spdData.ActiveSheet.Cells[j, 32].Value = MPCF.DoubleToString((MPCF.ToDbl(SUM_D31) / yieldList.Count), 1);
                    j += 1;
                }

                if (j > 0)
                {
                    spdData.ActiveSheet.Cells.Get(k, 0).RowSpan = j - k;
                }

                ClearSumData();

                // Fit Header
                MPCF.FitColumnHeader(spdData);

                // Sucess
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

        public class DataInfo
        {
            #region Property

            public string seq { get; set; }

            private string _category;
            public string Category
            {
                get { return _category; }
                set
                {
                    _category = value;
                }
            }

            public string MatId { get; set; }
            public string D01 { get; set; }
            public string D02 { get; set; }
            public string D03 { get; set; }
            public string D04 { get; set; }
            public string D05 { get; set; }
            public string D06 { get; set; }
            public string D07 { get; set; }
            public string D08 { get; set; }
            public string D09 { get; set; }
            public string D10 { get; set; }
            public string D11 { get; set; }
            public string D12 { get; set; }
            public string D13 { get; set; }
            public string D14 { get; set; }
            public string D15 { get; set; }
            public string D16 { get; set; }
            public string D17 { get; set; }
            public string D18 { get; set; }
            public string D19 { get; set; }
            public string D20 { get; set; }
            public string D21 { get; set; }
            public string D22 { get; set; }
            public string D23 { get; set; }
            public string D24 { get; set; }
            public string D25 { get; set; }
            public string D26 { get; set; }
            public string D27 { get; set; }
            public string D28 { get; set; }
            public string D29 { get; set; }
            public string D30 { get; set; }
            public string D31 { get; set; }

            #endregion

            #region Constructor

            /// <summary>
            /// 
            /// </summary>
            public DataInfo()
            {

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sCategory"></param>
            /// <param name="sMatId"></param>
            public DataInfo(string sCategory, string sMatId)
            {
                this.Category = sCategory;
                this.MatId = sMatId;

                for (int i = 1; i <= 31; i++)
                {
                    Set(i.ToString("00"), "0");
                }
            }

            #endregion

            #region Function

            /// <summary>
            /// 
            /// </summary>
            /// <param name="day"></param>
            /// <param name="value"></param>
            public void Set(string day, object value)
            {
                this.GetType().GetProperty("D" + day).SetValue(this, value, null);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="day"></param>
            /// <returns></returns>
            public string Get(string day)
            {
                return this.GetType().GetProperty("D" + day).GetValue(this, null).ToString();
            }

            #endregion
        }
    }
}
