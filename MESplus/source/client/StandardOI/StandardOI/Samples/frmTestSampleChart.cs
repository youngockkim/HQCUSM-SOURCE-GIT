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
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTestSampleChart : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSampleChart()
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
            // (Required) Chart Initialize
            // 차트를 사용하는 경우에는 아래 구문을 추가하여 DateSource를 초기화 해야 합니다.
            soiChart1.InitDataSource();
            soiChart2.InitDataSource();

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
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }


        /// <summary>
        /// Bind Data to Bar Chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBarChartBindData_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear exist data.
                // 기존 데이터를 삭제하고 초기화 합니다.
                // 기본적으로 Sample Column 1개(int type)와 Row Data 1건(값: 0)이 있습니다.
                soiChart1.ClearDataSource();

                // Bar Chart Data를 입력합니다.
                //  - arg0: Label
                //  - arg1: Value
                //  - arg2: Bar Color (default by theme)
                //  - arg3: Bar Text Color ( default by theme)
                soiChart1.SetBarChartData("Line A", 50, Color.FromArgb(255, 200, 200));
                soiChart1.SetBarChartData("Line B", 100, Color.White, Color.Black);
                soiChart1.SetBarChartData("Line C", 80);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Bind Data to Pie Chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPieChartBindData_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear exist data.
                // 기존 데이터를 삭제하고 초기화 합니다.
                soiChart2.ClearDataSource();

                // Pie Chart Data를 입력합니다.
                //  - arg0: Label
                //  - arg1: Value
                //  - arg2: Bar Color
                //  - arg3: Bar Text Color
                soiChart2.SetPieChartData("Line A", 50, Color.FromArgb(255, 200, 200));
                soiChart2.SetPieChartData("Line B", 20, Color.White);
                soiChart2.SetPieChartData("Line C", 30, Color.Blue);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        #endregion
    }
}
