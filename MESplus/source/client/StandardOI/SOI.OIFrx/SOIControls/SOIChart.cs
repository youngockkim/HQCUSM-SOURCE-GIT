using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinChart;
using System.Data;
using Infragistics.UltraChart.Shared.Styles;
using System.Drawing;
using Infragistics.UltraChart.Resources.Appearance;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIChart : UltraChart
    {
        #region Property

        private bool bFirstAdd = false;

        private Font barChartFont = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

        private DataTable dt_chart_data;

        private bool _useOITheme = true; // 최초 컨트롤 Add시 Default로 테마 적용
        public bool _UseOITheme
        {
            get
            {
                return _useOITheme;
            }
            set
            {
                _useOITheme = value;
                SetOITheme();
            }
        }

        [Browsable(false)]
        public new ChartType ChartType
        {
            get
            {
                return base.ChartType;
            }
            set
            {
                base.ChartType = value;
            }
        }

        private SOIChartType soiChartType;
        public SOIChartType SOIChartType
        {
            get
            {
                return soiChartType;
            }
            set
            {
                soiChartType = value;
                base.ChartType = SetChartType(soiChartType);
                SetOITheme();
            }
        }

        private SOIChartBarValueType soiChartBarValueType;
        public SOIChartBarValueType SOIChartBarValueType
        {
            get
            {
                return soiChartBarValueType;
            }
            set
            {
                soiChartBarValueType = value;
            }
        }


        #endregion

        #region Constructor

        public SOIChart()
        {
            InitializeComponent();
        }

        public SOIChart(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Event Handler

        //protected override void OnCreateControl()
        //{
        //    base.OnCreateControl();

        //    if (base.ChartType != Infragistics.UltraChart.Shared.Styles.ChartType.BarChart
        //        || base.ChartType != Infragistics.UltraChart.Shared.Styles.ChartType.PieChart)
        //    {
        //        SOIChartType = OIFrx.SOIChartType.BarChart;
        //    }
        //}

        //protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        //{
        //    // 디자인 모드에서만 적용
        //    if (DesignMode == true)
        //    {
        //        SetOITheme();
        //    }

        //    base.OnPaint(pe);
        //}

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            if (_UseOITheme == true)
            {
                // 공통 속성
                this.EmptyChartText = string.Empty;
                this.ColorModel.ModelStyle = ColorModels.CustomLinear;

                // 공통 색상
                this.BackColor = MPGV.gTheme.ChartBackground;
                this.Border.Color = MPGV.gTheme.ChartBorder;

                if (SOIChartType == OIFrx.SOIChartType.BarChart)
                {
                    // 속성                    
                    this.BarChart.BarSpacing = 1;
                    this.BarChart.SeriesSpacing = 2;
                    this.Axis.X.Visible = false;
                    this.Axis.Y.Labels.Font = barChartFont;
                    this.Axis.Y.LineThickness = 1;
                    this.Axis.Y.MajorGridLines.Visible = false;                    
                    this.Axis.Y.Labels.SeriesLabels.Visible = false;
                    this.Data.ZeroAligned = true;
                    this.Data.SwapRowsAndColumns = false;

                    // 색상
                    this.Axis.Y.Labels.FontColor = MPGV.gTheme.ChartForeground;
                    this.Axis.Y.LineColor = MPGV.gTheme.ChartBarYLineBorder;                    
                }
                else if (SOIChartType == OIFrx.SOIChartType.PieChart)
                {
                    // 속성
                    //this.PieChart.Labels.Visible = false;
                    //this.PieChart.Labels.LeaderLinesVisible = false;

                    this.PieChart.RadiusFactor = 70;
                    this.PieChart.Labels.Visible = true;
                    this.PieChart.Labels.LeaderLinesVisible = true;
                    this.PieChart.Labels.Font = barChartFont;
                    this.PieChart.Labels.FontColor = MPGV.gTheme.ChartForeground;
                    //this.PieChart.Labels.LeaderDrawStyle = LineDrawStyle.Solid;
                    this.PieChart.Labels.LeaderLineThickness = 2;
                    this.PieChart.Labels.Format = PieLabelFormat.Custom;
                    this.PieChart.Labels.FormatString = "<ITEM_LABEL>\n<PERCENT_VALUE:#0.##>%";
                    this.Data.SwapRowsAndColumns = true;                    
                }
            }
        }

        /// <summary>
        /// Chart Type을 설정합니다.
        /// </summary>
        private ChartType SetChartType(SOIChartType type)
        {
            ChartType returnType;

            if (type == OIFrx.SOIChartType.PieChart)
            {
                returnType = Infragistics.UltraChart.Shared.Styles.ChartType.PieChart;
            }
            else
            {
                returnType = Infragistics.UltraChart.Shared.Styles.ChartType.BarChart;
            }

            return returnType;
        }

        /// <summary>
        /// Data Table을 가져옵니다.
        /// </summary>
        public DataTable GetDataSource()
        {
            return dt_chart_data;
        }

        /// <summary>
        /// Data Table을 초기화 합니다.
        /// </summary>
        public void InitDataSource()
        {
            string sTableKey = "ChartTable";

            // Data Source Init
            if (dt_chart_data == null)
            {
                dt_chart_data = new DataTable(sTableKey);

                DataColumn dc = new DataColumn(" ");
                dc.DataType = typeof(int);
                dt_chart_data.Columns.Add(dc);

                DataRow dr = dt_chart_data.NewRow();
                dr[0] = 0;
                dt_chart_data.Rows.Add(dr);

                // 최초 컬러 초기화
                this.ColorModel.CustomPalette = new Color[] { MPGV.gTheme.ChartBarDefaultBarColor };

                // Line을 보여주지 않음.
                this.Axis.Y.LineThickness = 0;

                // 초기화 이후인지 구분하지 위한 구분자
                bFirstAdd = true;

                this.DataSource = dt_chart_data;
                this.DataBind();
            }
        }

        /// <summary>
        /// DataTable을 삭제하고 다시 초기화 합니다.
        /// </summary>
        public void ClearDataSource()
        {
            if (dt_chart_data != null)
            {
                dt_chart_data.Dispose();
                dt_chart_data = null;
            }

            InitDataSource();
        }

        /// <summary>
        /// BarChart Data를 입력합니다.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetBarChartData(string label, int value)
        {
            return SetBarChartData(label, value, MPGV.gTheme.ChartBarDefaultBarColor, MPGV.gTheme.ChartForeground);
        }

        /// <summary>
        /// BarChart Data를 입력합니다.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetBarChartData(string label, int value, Color barColor)
        {
            return SetBarChartData(label, value, barColor, MPGV.gTheme.ChartForeground);
        }

        /// <summary>
        /// BarChart Data를 입력합니다.
        /// </summary>
        public bool SetBarChartData(string label, int value, Color barColor, Color barTextColor)
        {
            DataRow dr;

            try
            {
                // Chart를 초기화 하지 않은 경우
                if (dt_chart_data == null)
                {
                    return false;
                }

                // Chart를 초기화한 이후 처음 데이터가 입력되는 경우
                if (bFirstAdd == true)
                {
                    dt_chart_data = new DataTable();
                    this.ColorModel.CustomPalette = null;
                    bFirstAdd = false;
                }

                // Column 입력
                DataColumn dc = new DataColumn(label);
                dc.DataType = typeof(int);
                dt_chart_data.Columns.Add(dc);

                // Line을 표시
                this.Axis.Y.LineThickness = 0;

                // Row가 없는 경우
                if (dt_chart_data.Rows.Count < 1)
                {
                    dr = dt_chart_data.NewRow();
                    dr[0] = value;
                    dt_chart_data.Rows.Add(dr);
                }
                // Row가 있는 경우
                else
                {
                    dr = dt_chart_data.Rows[0];
                    dr[dt_chart_data.Columns.Count - 1] = value;
                }

                // 최초 Color가 입력되는 경우
                if(dt_chart_data.Columns.Count == 1)
                {
                    this.ColorModel.CustomPalette = new Color[] { barColor };
                }
                // 이미 Color가 입력되어 있는 경우
                else
                {
                    Color[] col = new Color[dt_chart_data.Columns.Count];

                    for(int i= 0 ; i< this.ColorModel.CustomPalette.Length; i++)
                    {
                        col[i] = this.ColorModel.CustomPalette[i];
                    }
                    
                    col[dt_chart_data.Columns.Count - 1] = barColor;

                    this.ColorModel.CustomPalette = col;                    
                }
                this.ColorModel.AlphaLevel = 255;

                // Chart Text 입력
                ChartTextAppearance chartText = new ChartTextAppearance();
                chartText.ChartTextFont = barChartFont;
                chartText.FontColor = barTextColor;
                chartText.HorizontalAlign = StringAlignment.Near;
                chartText.ItemFormatString = GetBarChartItemFormat(this.SOIChartBarValueType);
                chartText.Column = dt_chart_data.Columns.Count - 1;                
                chartText.Row = 0;
                chartText.Visible = true;
                this.BarChart.ChartText.Add(chartText);

                this.DataSource = dt_chart_data;
                this.DataBind();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Pie Chart Data를 입력합니다.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="value"></param>
        /// <param name="barColor"></param>
        /// <param name="barTextColor"></param>
        /// <returns></returns>
        public bool SetPieChartData(string label, int value, Color barColor)
        {
            DataRow dr;

            try
            {
                // Chart를 초기화 하지 않은 경우
                if (dt_chart_data == null)
                {
                    return false;
                }

                // Chart를 초기화한 이후 처음 데이터가 입력되는 경우
                if (bFirstAdd == true)
                {
                    dt_chart_data = new DataTable();
                    this.ColorModel.CustomPalette = null;
                    bFirstAdd = false;
                }

                // Column 입력
                DataColumn dc = new DataColumn(label);
                dc.DataType = typeof(int);
                dt_chart_data.Columns.Add(dc);

                // Row가 없는 경우
                if (dt_chart_data.Rows.Count < 1)
                {
                    dr = dt_chart_data.NewRow();
                    dr[0] = value;
                    dt_chart_data.Rows.Add(dr);
                }
                // Row가 있는 경우
                else
                {
                    dr = dt_chart_data.Rows[0];
                    dr[dt_chart_data.Columns.Count - 1] = value;
                }

                // 최초 Color가 입력되는 경우
                if (dt_chart_data.Columns.Count == 1)
                {
                    this.ColorModel.CustomPalette = new Color[] { barColor };
                }
                // 이미 Color가 입력되어 있는 경우
                else
                {
                    Color[] col = new Color[dt_chart_data.Columns.Count];

                    for (int i = 0; i < this.ColorModel.CustomPalette.Length; i++)
                    {
                        col[i] = this.ColorModel.CustomPalette[i];
                    }

                    col[dt_chart_data.Columns.Count - 1] = barColor;

                    this.ColorModel.CustomPalette = col;
                }
                this.ColorModel.AlphaLevel = 255;

                //// Chart Text 입력
                //ChartTextAppearance chartText = new ChartTextAppearance();
                //chartText.ChartTextFont = barChartFont;
                //chartText.FontColor = barTextColor;
                //chartText.HorizontalAlign = StringAlignment.Near;
                //chartText.ItemFormatString = "<PERCENT_VALUE:#0.##>%";
                //chartText.Column = dt_chart_data.Columns.Count - 1;
                //chartText.Row = 0;
                //chartText.Visible = true;
                //this.PieChart.ChartText.Add(chartText);

                this.PieChart.ChartText.Clear();

                //// Column 반드시 1건만 존재
                //if (dt_chart_data.Columns.Count < 1)
                //{
                //    // Column 입력
                //    DataColumn dc = new DataColumn(label);
                //    dc.DataType = typeof(int);
                //    dt_chart_data.Columns.Add(dc);
                //}

                //// Row 입력
                //dr = dt_chart_data.NewRow();
                //dr[0] = value;
                //dt_chart_data.Rows.Add(dr);

                //// 최초 Color가 입력되는 경우
                //if (dt_chart_data.Rows.Count == 1)
                //{
                //    this.ColorModel.CustomPalette = new Color[] { barColor };
                //}
                //// 이미 Color가 입력되어 있는 경우
                //else
                //{
                //    Color[] col = new Color[dt_chart_data.Rows.Count];

                //    for (int i = 0; i < this.ColorModel.CustomPalette.Length; i++)
                //    {
                //        col[i] = this.ColorModel.CustomPalette[i];
                //    }

                //    col[dt_chart_data.Rows.Count - 1] = barColor;

                //    this.ColorModel.CustomPalette = col;
                //}
                //this.ColorModel.AlphaLevel = 255;

                //// Chart Text 입력
                //ChartTextAppearance chartText = new ChartTextAppearance();
                //chartText.ChartTextFont = barChartFont;
                //chartText.FontColor = barTextColor;
                //chartText.HorizontalAlign = StringAlignment.Center;
                //chartText.VerticalAlign = StringAlignment.Center;
                //chartText.ItemFormatString = "<PERCENT_VALUE:#0.##>%";
                //chartText.Column = 0;
                //chartText.Row = dt_chart_data.Rows.Count - 1;
                //chartText.Visible = true;
                //this.PieChart.ChartText.Add(chartText);

                this.DataSource = dt_chart_data;
                this.DataBind();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// % 또는 수량표기 포맷을 설정합니다.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetBarChartItemFormat(SOIChartBarValueType type)
        {
            string sReturn = string.Empty;

            if (type == OIFrx.SOIChartBarValueType.Percentage)
            {
                sReturn = "<DATA_VALUE:#,##0>%";
            }
            else if (type == OIFrx.SOIChartBarValueType.Quantity)
            {
                sReturn = "<DATA_VALUE:###,###,##0>";
            }

            return sReturn;
        }

        #endregion
    }
}
