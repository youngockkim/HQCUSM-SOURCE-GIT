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

namespace StandardOI.Samples
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTestSampleSpreadAndPrint : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSampleSpreadAndPrint()
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

                // (Required) 
                bIsShown = true;
            }
        }


        /// <summary>
        /// Spread Data Bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpreadBindData_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear All Row
                soiSpread1.Sheets[0].Rows.Clear();

                // Data Bind
                int iRow;
                for (int i = 0; i < 10; i++)
                {
                    iRow = soiSpread1.Sheets[0].RowCount;
                    soiSpread1.Sheets[0].RowCount++;

                    soiSpread1.Sheets[0].Cells[iRow, 0].Value = "Code " + i.ToString();
                    soiSpread1.Sheets[0].Cells[iRow, 1].Value = i.ToString() + " Description";
                    soiSpread1.Sheets[0].Cells[iRow, 2].Value = "20160502";
                    soiSpread1.Sheets[0].Cells[iRow, 3].Value = "1302343334";
                    soiSpread1.Sheets[0].Cells[iRow, 4].Value = " ";
                    soiSpread1.Sheets[0].Cells[iRow, 5].Value = " ";
                    soiSpread1.Sheets[0].Cells[iRow, 6].Value = " ";
                    soiSpread1.Sheets[0].Cells[iRow, 7].Value = " ";
                    soiSpread1.Sheets[0].Cells[iRow, 8].Value = " ";
                    soiSpread1.Sheets[0].Cells[iRow, 9].Value = " ";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
                return;
            }
        }

        /// <summary>
        /// Spread Cell Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // (option) Clicked Cell Information
                // 현재 선택한 Row와 Columm의 정보
                MPCF.ShowMessage(soiSpread1.Sheets[0].Cells[e.Row, e.Column].Value.ToString(), MSG_LEVEL.INFO, true);

                // (option) CheckBox SelectAll/ReleaseAll
                // 첫번째 Column으로 체크박스를 사용하는 경우, 이하 CheckBox의 Select All / Release All 처리를 위한 구문입니다.
                //// First Column Header Cell
                //if (e.Row == 0 && e.Column == 0 && e.ColumnHeader == true)
                //{
                //    // Select All
                //    if (soiSpread1.Sheets[0].ColumnHeader.Cells[0, 0].Value == null
                //        || ((bool)soiSpread1.Sheets[0].ColumnHeader.Cells[0, 0].Value) == false)
                //    {
                //        soiSpread1.Sheets[0].ColumnHeader.Cells[0, 0].Value = true;

                //        for (int i = 0; i < soiSpread1.Sheets[0].Rows.Count; i++)
                //        {
                //            soiSpread1.Sheets[0].Cells[i, 0].Value = true;
                //        }
                //    }
                //    // Release All
                //    else
                //    {
                //        soiSpread1.Sheets[0].ColumnHeader.Cells[0, 0].Value = false;

                //        for (int i = 0; i < soiSpread1.Sheets[0].Rows.Count; i++)
                //        {
                //            soiSpread1.Sheets[0].Cells[i, 0].Value = false;
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Print Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpreadPrint_Click(object sender, EventArgs e)
        {
            // (Option) FpSpread Print Info Setup
            // FpSpread를 프린트할 때 여러 옵션을 수정할 수 있습니다. 
            // 아래에는 주로 사용되는 일부 옵션에 대해 설명합니다.
            //soiSpread1.Sheets[0].PrintInfo.BestFitCols = true; // Column의 Width를 내용에 맞춰 자동조절할지 여부
            //soiSpread1.Sheets[0].PrintInfo.BestFitRows = true; // Row의 Height를 내용에 맞춰 자동조절할지 여부
            //soiSpread1.Sheets[0].PrintInfo.Centering = FarPoint.Win.Spread.Centering.Both; // 한페이지에 spread가 중앙에 오도록 할지 여부. 수평/수직/둘다로 선택가능.
            //soiSpread1.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait; // 용지방향. Portrait(세로), Landscape(가로), Auto(자동)에서 선택.
            //soiSpread1.Sheets[0].PrintInfo.ShowBorder = true; // spread 외각선을 표시할지 여부. 셀 Grid와는 관련이 없음.
            //soiSpread1.Sheets[0].PrintInfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Hide; // Column Header를 보여줄지 여부.
            //soiSpread1.Sheets[0].PrintInfo.ShowGrid = true; // 셀 Grid 라인을 표시할지 여부.
            //soiSpread1.Sheets[0].PrintInfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide; // Row Header를 보여줄지 여부.

            //// Smart Print Rule을 등록. 
            //FarPoint.Win.Spread.SmartPrintRulesCollection prules = new FarPoint.Win.Spread.SmartPrintRulesCollection();
            //prules.Add(new FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.None)); // 용지방향을 내용에 맞게 자동 변경.
            //prules.Add(new FarPoint.Win.Spread.ScaleRule(FarPoint.Win.Spread.ResetOption.None, 1.0F, 0.6F, 0.1F)); // 용지에 맞게 내용을 자동 축소 (최소 60%까지).
            //soiSpread1.Sheets[0].PrintInfo.SmartPrintRules = prules;

            //soiSpread1.Sheets[0].PrintInfo.UseMax = false; // 빈Row 또는 빈Column을 프린트 하지 않을지 여부. true이면 프린트하지 않음.
            //soiSpread1.Sheets[0].PrintInfo.UseSmartPrint = true; // Smart Print Rule을 사용할지 여부.

            // (Option) Set Default Print Info
            // SOISpread는 아래의 기본 Print Info가 이미 할당되어 있습니다.
            // 특별히 기본 Print Info를 설정할 필요가 있는 경우 사용합니다.
            // 기본 Print Info는 아래의 내용들을 포함하고 있습니다.
            //   1) UseMax = false >> 비어있는 row, column도 프린트함.
            //   2) UseSmartPrint = true >> Smart Print Rule을 사용함.
            //          LandscapeRule 사용 >> 용지방향을 내용에 맞게 변경.
            //          ScaleRule 사용 >> 용지에 맞게 내용을 자동 축소(최소 60%까지)
            //MPCF.SetSpreadPrintDefaultInfo(soiSpread1);

            // Print Spread
            // print Option from SOIBaseForm03.
            // Print Option이 없는 경우에는 Print Option 설정 화면이 나타납니다.
            // Print Option은 화면별로 저장됩니다.
            MPCF.PrintSpread(this, base.printOption, soiSpread1);

            // (Option) Open manually "print Option popup" 
            // base.printOption = MPCF.ShowPrintOption(this, ((MenuInfoTag)this.Tag).s_func_name);
        }

        /// <summary>
        /// Import Excel to Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpreadImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // (Option 1) Import from OpenFileDialog
                btnSpreadImportExcel.RunImport(soiSpread1);

                // (Option 2) Import from file path
                //btnSpreadImportExcel.RunImport(@"D:\temp.xlsx", soiSpread1);

                // (Option 3) Import with Common function
                //MPCF.ExcelImportFromFile(soiSpread1);
                //MPCF.ExcelImportFromFile(@"D:\temp.xlsx", soiSpread1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Export Excel From Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpreadExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                // (Option 1) Export with SaveFileDialog
                btnSpreadExcelExport.RunExport(soiSpread1);

                // (Option 2) Export to file path
                //btnSpreadExcelExport.RunExport(@"D:\temp.xlsx", soiSpread1);

                // (Option 3) Export with Common function
                // MPCF.ExcelExportToFile(soiSpread1);
                // MPCF.ExcelExportToFile(@"D:\temp.xlsx", soiSpread1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Bind Data to SOIGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridBindData_Click(object sender, EventArgs e)
        {
            try
            {
                // DataTabe을 가져옵니다.
                DataTable dt = soiGrid2.GetDataSource();

                // Grid와 동일한 내용의 DataRow를 생성합니다.
                DataRow dr = dt.NewRow();

                // Cell 단위로 값을 입력합니다. 입력 형태는 각 column의 type에 따라 입력해야 합니다.
                dr[0] = "data1";
                dt.Rows.Add(dr);

                // For문을 이용해 추가하는 경우 입니다.
                for (int i = 0; i < 10; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = "Item" + i.ToString();
                    dr[1] = "Item" + i.ToString();
                    dr[2] = "Item" + i.ToString();
                    dt.Rows.Add(dr);
                }

                // 모두 완료되면 반드시 DataBind를 실행하여 입력결과를 반영합니다.
                soiGrid2.DataBind();

                // 추가가 완료되면 Focus가 가장 마지막 Row에 있으므로 처음 Row에 Focus를 주어야 합니다.
                soiGrid2.PerformAction(UltraGridAction.FirstRowInGrid);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// SOIGrid Print
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridPrint_Click(object sender, EventArgs e)
        {
            // Print Grid
            // print Option from SOIBaseForm03.
            // Print Option이 없는 경우에는 Print Option 설정 화면이 나타납니다.
            // Print Option은 화면별로 저장됩니다.
            MPCF.PrintGrid(this, base.printOption, soiGrid2);

            // (Option) Open manually "print Option popup" 
            // base.printOption = MPCF.ShowPrintOption(this, ((MenuInfoTag)this.Tag).s_func_name);

        }

        /// <summary>
        /// Export Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // (Option 1) Export with SaveFileDialog
                btnGridExportExcel.RunExport(soiGrid2);

                // (Option 2) Export with file Path
                btnGridExportExcel.RunExport(@"D:\temp.xlsx", soiGrid2);

                // (Option 3) Export with Common Function
                //MPCF.ExcelExportToFile(soiGrid2);
                //MPCF.ExcelExportToFile(@"D:\temp.xlsx", soiGrid2);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        #endregion
    }
}
