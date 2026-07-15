using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Miracom.CliFrx;
using Excel;

namespace SOI.OIFrx
{
    public partial class udcMSChart : System.Windows.Forms.DataVisualization.Charting.Chart
    {
        #region Variable Definition

        //private string MSChartXValues; // X Values's Name In MSChart
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ToolTip ToolTipSeries = new ToolTip();

        private System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea;
        private System.Windows.Forms.DataVisualization.Charting.Legend chartLegend;
        private System.Windows.Forms.DataVisualization.Charting.Series chartSeries;
        private System.Windows.Forms.DataVisualization.Charting.Title chartTitle;
        private ChartDataGrid chartGrid;
        #endregion
        public udcMSChart()
        {
            InitializeComponent();
        }

        public udcMSChart(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        }

        #region MSChart Initialization
        public void MSChart_Initial()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BackColor = Color.White;
            //this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            //this.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            //this.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            //this.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.BorderlineWidth = 2;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
        }
        #endregion

        #region MSChart Title Initialization
        /// <summary>
        /// Initialization
        /// </summary>
        public void MSChart_SetTitle()
        {
            this.Titles.Clear();
        }

        /// <summary>
        /// 차트 타이틀 구성
        /// </summary>
        /// <param name="sChartTitle">차트 타이틀</param>
        /// <param name="alignment">차트 위치</param>
        /// <param name="colorTitleProperties">차트 타이틀 색상 속성 3가지 => Index 0 : Fore, 1 : Border, 2 : Background</param>
        public void MSChart_SetTitle(bool bViewTitle, string sChartTitle, ContentAlignment alignment, Color[] colorTitleProperties)
        {
            this.Titles.Clear();
            MSChart_AddTitle(bViewTitle, sChartTitle, alignment, colorTitleProperties);
        }

        /// <summary>
        /// 차트 타이틀 구성
        /// </summary>
        /// <param name="sChartTitle">차트 타이틀</param>
        /// <param name="alignment">차트 위치</param>
        /// <param name="colorTitleProperties">차트 타이틀 색상 속성 3가지 => Index 0 : Fore, 1 : Border, 2 : Background</param>
        public void MSChart_AddTitle(bool bViewTitle, string sChartTitle, ContentAlignment alignment, Color[] colorTitleProperties)
        {
            chartTitle = new Title();

            this.chartTitle.Visible = bViewTitle;
            this.chartTitle.Text = sChartTitle;
            this.chartTitle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Bold);
            if (colorTitleProperties != null && colorTitleProperties.Length > 0)
            {
                if (colorTitleProperties.Length >= 1)
                    this.chartTitle.ForeColor = (Color)colorTitleProperties[0];

                if (colorTitleProperties.Length >= 2)
                    this.chartTitle.BorderColor = (Color)colorTitleProperties[1];

                if (colorTitleProperties.Length >= 3)
                    this.chartTitle.BackColor = (Color)colorTitleProperties[2];
            }
            this.chartTitle.Alignment = (ContentAlignment)alignment;
            this.chartTitle.ToolTip = sChartTitle;
            this.Titles.Add(chartTitle);
        }

        /// <summary>
        /// 차트 타이틀 구성
        /// </summary>
        /// <param name="sChartTitle">차트 타이틀</param>
        /// <param name="font">폰트</param>
        /// <param name="alignment">차트 위치</param>
        /// <param name="colorTitleProperties">차트 타이틀 색상 속성 3가지 => Index 0 : Fore, 1 : Border, 2 : Background</param>
        public void MSChart_SetTitle(bool bViewTitle, string sChartTitle, System.Drawing.Font font, ContentAlignment alignment, Color[] colorTitleProperties)
        {
            this.Titles.Clear();
            MSChart_AddTitle(bViewTitle, sChartTitle, alignment, colorTitleProperties);
        }
        
        /// <summary>
        /// 차트 타이틀 구성
        /// </summary>
        /// <param name="sChartTitle">차트 타이틀</param>
        /// <param name="font">폰트</param>
        /// <param name="alignment">차트 위치</param>
        /// <param name="colorTitleProperties">차트 타이틀 색상 속성 3가지 => Index 0 : Fore, 1 : Border, 2 : Background</param>
        public void MSChart_AddTitle(bool bViewTitle, string sChartTitle, System.Drawing.Font font, ContentAlignment alignment, Color[] colorTitleProperties)
        {
            chartTitle = new Title();

            this.chartTitle.Visible = bViewTitle;
            this.chartTitle.Text = sChartTitle;
            this.chartTitle.Font = font;
            if (colorTitleProperties != null && colorTitleProperties.Length > 0)
            {
                if (colorTitleProperties.Length >= 1)
                    this.chartTitle.ForeColor = (Color)colorTitleProperties[0];

                if (colorTitleProperties.Length >= 2)
                    this.chartTitle.BorderColor = (Color)colorTitleProperties[1];

                if (colorTitleProperties.Length >= 3)
                    this.chartTitle.BackColor = (Color)colorTitleProperties[2];
            }
            this.chartTitle.Alignment = (ContentAlignment)alignment;
            this.chartTitle.ToolTip = sChartTitle;
            this.Titles.Add(chartTitle);
        }   
        #endregion

        #region MSChart ChartArea Initialization
        /// <summary>
        /// Initialization
        /// </summary>
        public void MSChart_SetChartArea()
        {
            this.ChartAreas.Clear();
        }

        /// <summary>
        /// 3. 차트 영역 여러개 구성
        /// </summary>
        /// <param name="chartNameArray">차트 이름 배열</param>
        /// <param name="iAxixXIntervalArray">차트배열 개수만큼 X축 간격</param>
        /// <param name="axixXIntervalTypeArray">차트배열 개수만큼 X축 간격 스타일</param>
        /// <param name="iAxixYIntervalArray">차트배열 개수만큼 Y축 간격</param>
        /// <param name="axixYintervalTypeArray">차트배열 개수만큼 Y축 간격 스타일</param>
        public void MSChart_ChartArea_Initial(string[] chartNameArray, double[] dAxixXIntervalArray, DateTimeIntervalType[] axixXIntervalTypeArray, double[] dAxixYIntervalArray, DateTimeIntervalType[] axixYIntervalTypeArray)
        {
            MSChart_SetChartArea(chartNameArray, dAxixXIntervalArray, axixXIntervalTypeArray, dAxixYIntervalArray, axixYIntervalTypeArray);
        }
        /// <summary>
        /// 3. 차트 영역 여러개 구성
        /// </summary>
        /// <param name="chartNameArray">차트 이름 배열</param>
        /// <param name="iAxixXIntervalArray">차트배열 개수만큼 X축 간격</param>
        /// <param name="axixXIntervalTypeArray">차트배열 개수만큼 X축 간격 스타일</param>
        /// <param name="iAxixYIntervalArray">차트배열 개수만큼 Y축 간격</param>
        /// <param name="axixYintervalTypeArray">차트배열 개수만큼 Y축 간격 스타일</param>
        public void MSChart_SetChartArea(string[] chartNameArray, double[] dAxixXIntervalArray, DateTimeIntervalType[] axixXIntervalTypeArray, double[] dAxixYIntervalArray, DateTimeIntervalType[] axixYIntervalTypeArray)
        {
            this.ChartAreas.Clear();
            MSChart_AddChartArea(chartNameArray, dAxixXIntervalArray, axixXIntervalTypeArray, dAxixYIntervalArray, axixYIntervalTypeArray);
        }

        /// <summary>
        /// 3. 차트 영역 여러개 구성
        /// </summary>
        /// <param name="chartNameArray">차트 이름 배열</param>
        /// <param name="iAxixXIntervalArray">차트배열 개수만큼 X축 간격</param>
        /// <param name="axixXIntervalTypeArray">차트배열 개수만큼 X축 간격 스타일</param>
        /// <param name="iAxixYIntervalArray">차트배열 개수만큼 Y축 간격</param>
        /// <param name="axixYintervalTypeArray">차트배열 개수만큼 Y축 간격 스타일</param>
        public void MSChart_AddChartArea(string[] chartNameArray, double[] dAxixXIntervalArray, DateTimeIntervalType[] axixXIntervalTypeArray, double[] dAxixYIntervalArray, DateTimeIntervalType[] axixYIntervalTypeArray)
        {
             for (int i = 0; i < chartNameArray.Length; i++)
            {
                chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();

                chartArea.AxisX.Interval = dAxixXIntervalArray[i];
                chartArea.AxisX.IntervalOffset = 0;
                chartArea.AxisX.IntervalType = (DateTimeIntervalType)axixXIntervalTypeArray[i];
                chartArea.AxisX.IsLabelAutoFit = true;
                chartArea.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
                chartArea.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                chartArea.AxisX.MajorGrid.Enabled = true;
                chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chartArea.AxisX2.IsLabelAutoFit = false;
                chartArea.AxisX2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chartArea.AxisX2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                chartArea.AxisY.Interval = dAxixYIntervalArray[i];
                chartArea.AxisY.IntervalOffset = 0;
                chartArea.AxisY.IntervalType = (DateTimeIntervalType)axixYIntervalTypeArray[i];
                chartArea.AxisY.IsLabelAutoFit = false;
                chartArea.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
                chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chartArea.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                chartArea.AxisY2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                chartArea.BackColor = Color.White;
                //chartArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
                //chartArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
                chartArea.BackSecondaryColor = System.Drawing.Color.Transparent;
                chartArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                chartArea.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                chartArea.CursorX.IsUserEnabled = true;
                chartArea.CursorX.IsUserSelectionEnabled = true;
                chartArea.CursorX.LineColor = System.Drawing.Color.Chocolate;
                chartArea.CursorY.IsUserEnabled = true;
                chartArea.CursorY.IsUserSelectionEnabled = true;
                chartArea.CursorY.LineColor = System.Drawing.Color.Chocolate;
                chartArea.Name = chartNameArray[i];
                chartArea.ShadowColor = System.Drawing.Color.Transparent;
                this.ChartAreas.Add(chartArea);
            }
        }

        /// <summary>
        /// 1. 기본 차트영역 구성
        /// </summary>
        /// <param name="sChartAreaName">차트 영역 이름</param>
        /// <param name="iAxisXInterval">X축 간격</param>
        /// <param name="axixXIntervalType">X축 간격 스타일(Nubmer, Date, ...)</param>
        /// <param name="iAxisYInterval">Y축 간격</param>
        /// <param name="axixYIntervalType">Y축 간격 스타일(Nubmer, Date, ...)</param>
        public void MSChart_ChartArea_Initial(string sChartAreaName, double dAxisXInterval, DateTimeIntervalType axixXIntervalType, double dAxisYInterval, DateTimeIntervalType axixYIntervalType)
        {
            MSChart_SetChartArea(sChartAreaName, dAxisXInterval, axixXIntervalType, dAxisYInterval, axixYIntervalType);
        }

        /// <summary>
        /// 1. 기본 차트영역 구성
        /// </summary>
        /// <param name="sChartAreaName">차트 영역 이름</param>
        /// <param name="iAxisXInterval">X축 간격</param>
        /// <param name="axixXIntervalType">X축 간격 스타일(Nubmer, Date, ...)</param>
        /// <param name="iAxisYInterval">Y축 간격</param>
        /// <param name="axixYIntervalType">Y축 간격 스타일(Nubmer, Date, ...)</param>
        public void MSChart_SetChartArea(string sChartAreaName, double dAxisXInterval, DateTimeIntervalType axixXIntervalType, double dAxisYInterval, DateTimeIntervalType axixYIntervalType)
        {
            this.ChartAreas.Clear();
            MSChart_AddChartArea(sChartAreaName, dAxisXInterval, axixXIntervalType, dAxisYInterval, axixYIntervalType);
        }

        /// <summary>
        /// 1. 기본 차트영역 구성
        /// </summary>
        /// <param name="sChartAreaName">차트 영역 이름</param>
        /// <param name="iAxisXInterval">X축 간격</param>
        /// <param name="axixXIntervalType">X축 간격 스타일(Nubmer, Date, ...)</param>
        /// <param name="iAxisYInterval">Y축 간격</param>
        /// <param name="axixYIntervalType">Y축 간격 스타일(Nubmer, Date, ...)</param>
        public void MSChart_AddChartArea(string sChartAreaName, double dAxisXInterval, DateTimeIntervalType axixXIntervalType, double dAxisYInterval, DateTimeIntervalType axixYIntervalType)
        {
            chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();

            chartArea.AxisX.Interval = dAxisXInterval;
            chartArea.AxisX.IntervalOffset = 0;
            chartArea.AxisX.IntervalType = (DateTimeIntervalType)axixXIntervalType;
            chartArea.AxisX.IsLabelAutoFit = true;
            chartArea.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisX2.IsLabelAutoFit = false;
            chartArea.AxisX2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisX2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisY.Interval = dAxisYInterval;
            chartArea.AxisY.Enabled = AxisEnabled.True;
            chartArea.AxisY.IntervalType = (DateTimeIntervalType)axixYIntervalType;
            chartArea.AxisY.IsLabelAutoFit = true;
            chartArea.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisY2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisY2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisY2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.BackColor = Color.White;
            //chartArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            //chartArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            //chartArea.BackSecondaryColor = System.Drawing.Color.Transparent;
            //chartArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            //chartArea.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorX.LineColor = System.Drawing.Color.Chocolate;
            chartArea.CursorY.IsUserEnabled = true;
            chartArea.CursorY.IsUserSelectionEnabled = true;
            chartArea.CursorY.LineColor = System.Drawing.Color.Chocolate;
            chartArea.Name = sChartAreaName;
            chartArea.ShadowColor = System.Drawing.Color.Transparent;
            this.ChartAreas.Add(chartArea);
        }
        /// <summary>
        /// 2. 차트 Cursor 추가
        /// </summary>
        /// <param name="sChartAreaName">차트 영역 이름</param>
        /// <param name="iAxisXInterval">X축 간격</param>
        /// <param name="axixXIntervalType">X축 간격 스타일(Nubmer, Date, ...)</param>
        /// <param name="iAxisYInterval">Y축 간격</param>
        /// <param name="axixYIntervalType">Y축 간격 스타일(Nubmer, Date, ...)</param>
        /// <param name="bViewCursorX">X축 Cursor 표현 여부</param>
        /// <param name="bViewCursorY">Y축 Cursor 표현 여부</param>
        /// <param name="cursorColor">Cursor 색상</param>
        public void MSChart_ChartArea_Initial(string sChartName, double dAxisXInterval, DateTimeIntervalType axixXIntervalType, double dAxisYInterval, DateTimeIntervalType axixYIntervalType, bool bViewCursorX, bool bViewCursorY, Color cursorColor)
        {
            MSChart_SetChartArea(sChartName, dAxisXInterval, axixXIntervalType, dAxisYInterval, axixYIntervalType, bViewCursorX, bViewCursorY, cursorColor);
        }
        /// <summary>
        /// 2. 차트 Cursor 추가
        /// </summary>
        /// <param name="sChartAreaName">차트 영역 이름</param>
        /// <param name="iAxisXInterval">X축 간격</param>
        /// <param name="axixXIntervalType">X축 간격 스타일(Nubmer, Date, ...)</param>
        /// <param name="iAxisYInterval">Y축 간격</param>
        /// <param name="axixYIntervalType">Y축 간격 스타일(Nubmer, Date, ...)</param>
        /// <param name="bViewCursorX">X축 Cursor 표현 여부</param>
        /// <param name="bViewCursorY">Y축 Cursor 표현 여부</param>
        /// <param name="cursorColor">Cursor 색상</param>
        public void MSChart_SetChartArea(string sChartName, double dAxisXInterval, DateTimeIntervalType axixXIntervalType, double dAxisYInterval, DateTimeIntervalType axixYIntervalType, bool bViewCursorX, bool bViewCursorY, Color cursorColor)
        {
            this.ChartAreas.Clear();
            MSChart_AddChartArea(sChartName, dAxisXInterval, axixXIntervalType, dAxisYInterval, axixYIntervalType, bViewCursorX, bViewCursorY, cursorColor);
       }        
        /// <summary>
        /// 2. 차트 Cursor 추가
        /// </summary>
        /// <param name="sChartAreaName">차트 영역 이름</param>
        /// <param name="iAxisXInterval">X축 간격</param>
        /// <param name="axixXIntervalType">X축 간격 스타일(Nubmer, Date, ...)</param>
        /// <param name="iAxisYInterval">Y축 간격</param>
        /// <param name="axixYIntervalType">Y축 간격 스타일(Nubmer, Date, ...)</param>
        /// <param name="bViewCursorX">X축 Cursor 표현 여부</param>
        /// <param name="bViewCursorY">Y축 Cursor 표현 여부</param>
        /// <param name="cursorColor">Cursor 색상</param>
        public void MSChart_AddChartArea(string sChartName, double dAxisXInterval, DateTimeIntervalType axixXIntervalType, double dAxisYInterval, DateTimeIntervalType axixYIntervalType, bool bViewCursorX, bool bViewCursorY, Color cursorColor)
        {
            chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();

            chartArea.AxisX.Interval = dAxisXInterval;
            chartArea.AxisX.IntervalOffset = 0;
            chartArea.AxisX.IntervalType = (DateTimeIntervalType)axixXIntervalType;
            chartArea.AxisX.IsLabelAutoFit = true;
            chartArea.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisX2.IsLabelAutoFit = false;
            chartArea.AxisX2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisX2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisY.Enabled = AxisEnabled.True;
            chartArea.AxisY.Interval = dAxisYInterval;
            chartArea.AxisY.IntervalOffset = 0;
            chartArea.AxisY.IntervalType = (DateTimeIntervalType)axixYIntervalType;
            chartArea.AxisY.IsLabelAutoFit = true;
            chartArea.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisY2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea.AxisY2.IsLabelAutoFit = false;
            chartArea.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea.AxisY2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisY2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.BackColor = Color.White;
            //chartArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            //chartArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea.BackSecondaryColor = System.Drawing.Color.Transparent;
            //chartArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            //chartArea.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea.CursorX.IsUserEnabled = bViewCursorX;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorY.IsUserEnabled = bViewCursorY;
            chartArea.CursorY.IsUserSelectionEnabled = true;
            if (cursorColor == null)
            {
                chartArea.CursorX.LineColor = Color.Chocolate;
                chartArea.CursorX.LineColor = Color.Chocolate;
            }
            else
            {
                chartArea.CursorX.LineColor = cursorColor;
                chartArea.CursorY.LineColor = cursorColor;
            }

            chartArea.Name = sChartName;
            chartArea.ShadowColor = System.Drawing.Color.Transparent;
            this.ChartAreas.Add(chartArea);
        }
        #endregion

        #region MSChart Legend Initialization
        /// <summary>
        /// Initialization
        /// </summary>
        public void MSChart_SetLegend()
        {
            this.Legends.Clear();
        }

        /// <summary>
        /// 1. 기본 레전드
        /// </summary>
        /// <param name="sLegendName">레전드 이름</param>
        public void MSChart_Legend_Initial(string sLegendName)
        {
            MSChart_SetLegend(sLegendName);
        }
        /// <summary>
        /// 1. 기본 레전드
        /// </summary>
        /// <param name="sLegendName">레전드 이름</param>
        public void MSChart_SetLegend(string sLegendName)
        {
            this.Legends.Clear();
            MSChart_AddLegend(sLegendName);
        }


        /// <summary>
        /// 1. 기본 레전드
        /// </summary>
        /// <param name="sLegendName">레전드 이름</param>
        public void MSChart_AddLegend(string sLegendName)
        {
            chartLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            chartLegend.Name = sLegendName;
            chartLegend.Enabled = true;
            chartLegend.Alignment = System.Drawing.StringAlignment.Center;
            chartLegend.BackColor = System.Drawing.Color.Transparent;
            chartLegend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;

            chartLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartLegend.IsTextAutoFit = false;
            chartLegend.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;

            this.Legends.Add(chartLegend);
        }

        /// <summary>
        /// 2. 레전드 표현 여부 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        public void MSChart_Legend_Initial(bool bLegendEnable, string sLegendName)
        {
            MSChart_SetLegend(bLegendEnable, sLegendName);
        }

        /// <summary>
        /// 2. 레전드 표현 여부 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        public void MSChart_SetLegend(bool bLegendEnable, string sLegendName)
        {
            this.Legends.Clear();
            MSChart_AddLegend(bLegendEnable, sLegendName);
        }

        /// <summary>
        /// 2. 레전드 표현 여부 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        public void MSChart_AddLegend(bool bLegendEnable, string sLegendName)
        {
            chartLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Name = sLegendName;
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Alignment = System.Drawing.StringAlignment.Center;
            chartLegend.BackColor = System.Drawing.Color.Transparent;
            chartLegend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;

            chartLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartLegend.IsTextAutoFit = false;
            chartLegend.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;

            this.Legends.Add(chartLegend);
        }

        /// <summary>
        /// 3. 레전드 위치 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        public void MSChart_Legend_Initial(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking)
        {
            MSChart_SetLegend(bLegendEnable, sLegendName, alignment, docking);
        }

        /// <summary>
        /// 3. 레전드 위치 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        public void MSChart_SetLegend(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking)
        {
            this.Legends.Clear();
            MSChart_AddLegend(bLegendEnable, sLegendName, alignment, docking);
        }

        /// <summary>
        /// 3. 레전드 위치 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        public void MSChart_AddLegend(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking)
        {
            this.Legends.Clear();
            //if (bLegendEnable == false)
            //    return;

            chartLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Name = sLegendName;
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Alignment = (StringAlignment)alignment;
            chartLegend.BackColor = System.Drawing.Color.Transparent;
            chartLegend.Docking = (Docking)docking;

            chartLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartLegend.IsTextAutoFit = false;
            chartLegend.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;

            this.Legends.Add(chartLegend);
        }

        /// <summary>
        /// 4. 레전드 배경색 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        /// <param name="legendBackColor">배경색</param>
        public void MSChart_Legend_Initial(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking, Color legendBackColor)
        {
            MSChart_SetLegend(bLegendEnable, sLegendName, alignment, docking, legendBackColor);
        }

        /// <summary>
        /// 4. 레전드 배경색 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        /// <param name="legendBackColor">배경색</param>
        public void MSChart_SetLegend(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking, Color legendBackColor)
        {
            this.Legends.Clear();
            MSChart_AddLegend(bLegendEnable, sLegendName, alignment, docking, legendBackColor);
        }

        /// <summary>
        /// 4. 레전드 배경색 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        /// <param name="legendBackColor">배경색</param>
        public void MSChart_AddLegend(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking, Color legendBackColor)
        {
            chartLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Name = sLegendName;
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Alignment = (StringAlignment)alignment;
            chartLegend.BackColor = (Color)legendBackColor;
            chartLegend.Docking = (Docking)docking;

            chartLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartLegend.IsTextAutoFit = false;
            chartLegend.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;

            this.Legends.Add(chartLegend);
        }

        /// <summary>
        /// 5. 레전드 스타일 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        /// <param name="legendBackColor">배경색</param>
        /// <param name="legendStyle">레전드 스타일</param>
        public void MSChart_Legend_Initial(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking, Color legendBackColor, LegendStyle legendStyle)
        {
            MSChart_SetLegend(bLegendEnable, sLegendName, alignment, docking, legendBackColor, legendStyle);
        }

        /// <summary>
        /// 5. 레전드 스타일 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        /// <param name="legendBackColor">배경색</param>
        /// <param name="legendStyle">레전드 스타일</param>
        public void MSChart_SetLegend(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking, Color legendBackColor, LegendStyle legendStyle)
        {
            this.Legends.Clear();
            MSChart_AddLegend(bLegendEnable, sLegendName, alignment, docking, legendBackColor, legendStyle);
        }

        /// <summary>
        /// 5. 레전드 스타일 추가
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        /// <param name="legendBackColor">배경색</param>
        /// <param name="legendStyle">레전드 스타일</param>
        public void MSChart_AddLegend(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking, Color legendBackColor, LegendStyle legendStyle)
        {
            chartLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Name = sLegendName;
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Alignment = (StringAlignment)alignment;
            chartLegend.BackColor = (Color)legendBackColor;
            chartLegend.Docking = (Docking)docking;

            chartLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartLegend.IsTextAutoFit = false;
            chartLegend.LegendStyle = (LegendStyle)legendStyle;

            this.Legends.Add(chartLegend);
        }

        /// <summary>
        /// 6. 레전드 배경색 기본(Transparent), 스타일 추가 
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        /// <param name="legendStyle">레전드 스타일</param>
        public void MSChart_Legend_Initial(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking, LegendStyle legendStyle)
        {
            MSChart_SetLegend(bLegendEnable, sLegendName, alignment, docking, legendStyle);
        }

        /// <summary>
        /// 6. 레전드 배경색 기본(Transparent), 스타일 추가 
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        /// <param name="legendStyle">레전드 스타일</param>
        public void MSChart_SetLegend(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking, LegendStyle legendStyle)
        {
            this.Legends.Clear();
            MSChart_AddLegend(bLegendEnable, sLegendName, alignment, docking, legendStyle);
        }

        /// <summary>
        /// 6. 레전드 배경색 기본(Transparent), 스타일 추가 
        /// </summary>
        /// <param name="bLegendEnable">레전드 표현 여부</param>
        /// <param name="sLegendName">레전드 이름</param>
        /// <param name="alignment">수평 위치</param>
        /// <param name="docking">도킹 위치</param>
        /// <param name="legendStyle">레전드 스타일</param>
        public void MSChart_AddLegend(bool bLegendEnable, string sLegendName, StringAlignment alignment, Docking docking, LegendStyle legendStyle)
        {
            chartLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Name = sLegendName;
            chartLegend.Enabled = bLegendEnable;
            chartLegend.Alignment = (StringAlignment)alignment;
            chartLegend.BackColor = System.Drawing.Color.Transparent;
            chartLegend.Docking = (Docking)docking;

            chartLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartLegend.IsTextAutoFit = false;
            chartLegend.LegendStyle = (LegendStyle)legendStyle;

            this.Legends.Add(chartLegend);
        }

        #endregion

        #region MSChart Series Initialization

        /// <summary>
        /// Initialization
        /// </summary>
        public void MSChart_SetChartSeries()
        {
            this.Series.Clear();
        }

        /// <summary>
        /// 1. 기본 차트 시리즈 구성
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        public void MSChart_SetChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray)
        {
            this.Series.Clear();
            MSChart_AddChartSeries(dt, sChartAreaName, sChartLegendName, chartTypeArray, sChartNameArray);
        }

        /// <summary>
        /// 1. 기본 차트 시리즈 구성
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        public void MSChart_AddChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray)
        {
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                chartSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
                chartSeries.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                chartSeries.ChartArea = sChartAreaName;
                if (i > chartTypeArray.Length - 1)
                {
                    chartSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    chartSeries.ChartType = chartTypeArray[i];
                }
                chartSeries.CustomProperties = "LabelStyle=Top";
                chartSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chartSeries.IsValueShownAsLabel = false;
                chartSeries.Legend = sChartLegendName;
                chartSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chartSeries.MarkerColor = Color.White;
                if (i > sChartNameArray.Length - 1)
                {
                    chartSeries.Name = i.ToString();
                }
                else
                {
                    chartSeries.Name = sChartNameArray[i];
                }
                chartSeries.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                chartSeries.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                chartSeries.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                chartSeries.ToolTip = chartSeries.Name + " : #VALY{D1}";

                this.Series.Add(chartSeries);
            }


            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int j = 1; j < dt.Columns.Count; j++)
            //    {
            //        MSChartXValues = FwxCmnFunction.PackCondition(MSChartXValues, dt.Rows[i][j].ToString());
            //    }
            //}
        }

        /// <summary>
        /// 2. 기본 차트에 라벨 표시
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        public void MSChart_SetChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool[] bShowLabelArray)
        {
            this.Series.Clear();
            MSChart_AddChartSeries(dt, sChartAreaName, sChartLegendName, chartTypeArray, sChartNameArray, bShowLabelArray);
        }

        /// <summary>
        /// 2. 기본 차트에 라벨 표시
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        public void MSChart_AddChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool[] bShowLabelArray)
        {
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                chartSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
                chartSeries.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                chartSeries.ChartArea = sChartAreaName;
                if (i > chartTypeArray.Length - 1)
                {
                    chartSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    chartSeries.ChartType = chartTypeArray[i];
                }
                chartSeries.CustomProperties = "LabelStyle=Top";
                chartSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                if (i > bShowLabelArray.Length - 1)
                {
                    chartSeries.IsValueShownAsLabel = false;
                }
                else
                {
                    chartSeries.IsValueShownAsLabel = bShowLabelArray[i];
                }

                chartSeries.Legend = sChartLegendName;
                chartSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chartSeries.MarkerColor = Color.White;
                if (i > sChartNameArray.Length - 1)
                {
                    chartSeries.Name = i.ToString();
                }
                else
                {
                    chartSeries.Name = sChartNameArray[i];
                }
                chartSeries.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                chartSeries.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                chartSeries.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                chartSeries.ToolTip = chartSeries.Name + " : #VALY{D1}";
                this.Series.Add(chartSeries);
            }
        }

        /// <summary>
        /// 3. 기본 차트에 세컨트 Y 축 포함
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bSecondAxisY">세컨드 Y축 여부</param>
        /// <param name="iSecondAxiYSeriesIndex">세컨드 Y축 인덱스 배열 (여러개 존재 가능)</param>
        /// <param name="secondeSeriesColor">세컨드 Series 색상</param>
        public void MSChart_SetChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool bSecondAxisY, int[] iSecondAxiYSeriesIndex, Color[] secondeSeriesColor)
        {
            this.Series.Clear();
            MSChart_AddChartSeries(dt, sChartAreaName, sChartLegendName, chartTypeArray, sChartNameArray, bSecondAxisY, iSecondAxiYSeriesIndex, secondeSeriesColor);

        }

        /// <summary>
        /// 3. 기본 차트에 세컨트 Y 축 포함
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bSecondAxisY">세컨드 Y축 여부</param>
        /// <param name="iSecondAxiYSeriesIndex">세컨드 Y축 인덱스 배열 (여러개 존재 가능)</param>
        /// <param name="secondeSeriesColor">세컨드 Series 색상</param>
        public void MSChart_AddChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool bSecondAxisY, int[] iSecondAxiYSeriesIndex, Color[] secondeSeriesColor)
        {
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                chartSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
                chartSeries.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                chartSeries.ChartArea = sChartAreaName;
                if (i > chartTypeArray.Length - 1)
                {
                    // 차트타입 개수가 시리즈 개수보다 적을 경우 라인 타입으로 지정
                    chartSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    chartSeries.ChartType = chartTypeArray[i];
                }
                chartSeries.CustomProperties = "LabelStyle=Top";
                chartSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chartSeries.IsValueShownAsLabel = false;
                chartSeries.Legend = sChartLegendName;
                chartSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chartSeries.MarkerColor = Color.White;
                if (i > sChartNameArray.Length - 1)
                {
                    chartSeries.Name = i.ToString();
                }
                else
                {
                    chartSeries.Name = sChartNameArray[i];
                }
                chartSeries.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                chartSeries.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                // Secondary Axis Y Setting
                if (bSecondAxisY == true)
                {
                    for (int index = 0; index < iSecondAxiYSeriesIndex.Length; index++)
                    {
                        if (iSecondAxiYSeriesIndex != null)
                        {
                            if (i == iSecondAxiYSeriesIndex[index])
                            {
                                chartSeries.YAxisType = AxisType.Secondary;
                                if (secondeSeriesColor != null)
                                    chartSeries.Color = secondeSeriesColor[index];
                            }
                        }
                    }
                }

                // Data Bind
                chartSeries.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                chartSeries.ToolTip = chartSeries.Name + " : #VALY{D1}";
                this.Series.Add(chartSeries);
            }
        }

        /// <summary>
        /// 4. 차트에 라벨과 세컨드 Y축 포함
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        /// <param name="bSecondAxisY">세컨드 Y축 여부</param>
        /// <param name="iSecondAxiYSeriesIndex">세컨드 Y축 인덱스 배열 (여러개 존재 가능)</param>
        /// <param name="secondeSeriesColor">세컨드 Series 색상</param>
        public void MSChart_SetChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool[] bShowLabelArray, bool bSecondAxisY, int[] iSecondAxiYSeriesIndex, Color[] secondeSeriesColor)
        {
            this.Series.Clear();
            MSChart_AddChartSeries(dt, sChartAreaName, sChartLegendName, chartTypeArray, sChartNameArray, bShowLabelArray, bSecondAxisY, iSecondAxiYSeriesIndex, secondeSeriesColor);
        }

        /// <summary>
        /// 4. 차트에 라벨과 세컨드 Y축 포함
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        /// <param name="bSecondAxisY">세컨드 Y축 여부</param>
        /// <param name="iSecondAxiYSeriesIndex">세컨드 Y축 인덱스 배열 (여러개 존재 가능)</param>
        /// <param name="secondeSeriesColor">세컨드 Series 색상</param>
        public void MSChart_AddChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool[] bShowLabelArray, bool bSecondAxisY, int[] iSecondAxiYSeriesIndex, Color[] secondeSeriesColor)
        {
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                chartSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
                chartSeries.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                chartSeries.ChartArea = sChartAreaName;
                if (i > chartTypeArray.Length - 1)
                {
                    // 차트타입 개수가 시리즈 개수보다 적을 경우 라인 타입으로 지정
                    chartSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    chartSeries.ChartType = chartTypeArray[i];
                }
                chartSeries.CustomProperties = "LabelStyle=Top";
                chartSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                if (i > bShowLabelArray.Length - 1)
                {
                    chartSeries.IsValueShownAsLabel = false;
                }
                else
                {
                    chartSeries.IsValueShownAsLabel = bShowLabelArray[i];
                }
                chartSeries.Legend = sChartLegendName;
                chartSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chartSeries.MarkerColor = Color.White;
                if (i > sChartNameArray.Length - 1)
                {
                    chartSeries.Name = i.ToString();
                }
                else
                {
                    chartSeries.Name = sChartNameArray[i];
                }
                chartSeries.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                chartSeries.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                // Secondary Axis Y Setting
                if (bSecondAxisY == true)
                {
                    for (int index = 0; index < iSecondAxiYSeriesIndex.Length; index++)
                    {
                        if (iSecondAxiYSeriesIndex != null)
                        {
                            if (i == iSecondAxiYSeriesIndex[index])
                            {
                                chartSeries.YAxisType = AxisType.Secondary;
                                if (secondeSeriesColor != null)
                                    chartSeries.Color = secondeSeriesColor[index];
                            }
                        }
                    }
                }

                // Data Bind
                chartSeries.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                chartSeries.ToolTip = chartSeries.Name + " : #VALY{D1}";
                this.Series.Add(chartSeries);
            }
        }


        /// <summary>
        /// 5. 차트에 라벨 & 마커 표시 포함
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        /// <param name="bShowMarker">마커 표시 여부</param>
        /// <param name="markerStyle">마커 종류</param>
        /// <param name="markerColor">마커 색깔</param>
        public void MSChart_SetChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool[] bShowLabelArray, bool[] bShowMarker, MarkerStyle markerStyle, Color markerColor)
        {
            this.Series.Clear();
            MSChart_AddChartSeries(dt, sChartAreaName, sChartLegendName, chartTypeArray, sChartNameArray, bShowLabelArray, bShowMarker, markerStyle, markerColor);
 
        }

        /// <summary>
        /// 5. 차트에 라벨 & 마커 표시 포함
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        /// <param name="bShowMarker">마커 표시 여부</param>
        /// <param name="markerStyle">마커 종류</param>
        /// <param name="markerColor">마커 색깔</param>
        public void MSChart_AddChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool[] bShowLabelArray, bool[] bShowMarker, MarkerStyle markerStyle, Color markerColor)
        {
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                chartSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
                chartSeries.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                chartSeries.ChartArea = sChartAreaName;
                if (i > chartTypeArray.Length - 1)
                {
                    // 차트타입 개수가 시리즈 개수보다 적을 경우 라인 타입으로 지정
                    chartSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    chartSeries.ChartType = chartTypeArray[i];
                }
                chartSeries.CustomProperties = "LabelStyle=Top";
                chartSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                if (i > bShowLabelArray.Length - 1)
                {
                    chartSeries.IsValueShownAsLabel = false;
                }
                else
                {
                    chartSeries.IsValueShownAsLabel = bShowLabelArray[i];
                }
                chartSeries.Legend = sChartLegendName;
                if (bShowMarker.Length != 0 && i > bShowMarker.Length - 1)
                {
                    if (bShowMarker[0] == true)
                    {
                        chartSeries.MarkerStyle = markerStyle;
                        chartSeries.MarkerColor = markerColor;
                    }
                    else
                    {
                        chartSeries.MarkerStyle = MarkerStyle.Circle;
                        chartSeries.MarkerColor = Color.White;
                    }
                }
                else
                {
                    if (bShowMarker[i] == true)
                    {
                        chartSeries.MarkerStyle = markerStyle;
                        chartSeries.MarkerColor = markerColor;
                    }
                }

                if (i > sChartNameArray.Length - 1)
                {
                    chartSeries.Name = i.ToString();
                }
                else
                {
                    chartSeries.Name = sChartNameArray[i];
                }
                chartSeries.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                chartSeries.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                // Data Bind
                chartSeries.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                chartSeries.ToolTip = chartSeries.Name + " : #VALY{D1}";
                this.Series.Add(chartSeries);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        /// <param name="bShowMarker">마커 표시 여부</param>
        /// <param name="markerStyle">마커 종류</param>
        /// <param name="markerColor">마커 색깔</param>
        /// <param name="bSecondAxisY">세컨드 Y축 여부</param>
        /// <param name="iSecondAxiYSeriesIndex">세컨드 Y축 인덱스 배열 (여러개 존재 가능)</param>
        /// <param name="secondeSeriesColor">세컨드 Series 색상</param>
        public void MSChart_SetChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool[] bShowLabelArray, bool[] bShowMarker, MarkerStyle markerStyle, Color markerColor, bool bSecondAxisY, int[] iSecondAxiYSeriesIndex, Color[] secondeSeriesColor)
        {
            this.Series.Clear();
            MSChart_AddChartSeries(dt, sChartAreaName, sChartLegendName, chartTypeArray, sChartNameArray, bShowLabelArray, bShowMarker, markerStyle, markerColor, bSecondAxisY, iSecondAxiYSeriesIndex, secondeSeriesColor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="sChartAreaName">이미 설정된 ChartArea 이름</param>
        /// <param name="sChartLegendName">이미 설정된 ChartLegend 이름</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        /// <param name="bShowMarker">마커 표시 여부</param>
        /// <param name="markerStyle">마커 종류</param>
        /// <param name="markerColor">마커 색깔</param>
        /// <param name="bSecondAxisY">세컨드 Y축 여부</param>
        /// <param name="iSecondAxiYSeriesIndex">세컨드 Y축 인덱스 배열 (여러개 존재 가능)</param>
        /// <param name="secondeSeriesColor">세컨드 Series 색상</param>
        public void MSChart_AddChartSeries(System.Data.DataTable dt, string sChartAreaName, string sChartLegendName, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool[] bShowLabelArray, bool[] bShowMarker, MarkerStyle markerStyle, Color markerColor, bool bSecondAxisY, int[] iSecondAxiYSeriesIndex, Color[] secondeSeriesColor)
        {
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                chartSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
                chartSeries.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                chartSeries.ChartArea = sChartAreaName;
                if (i > chartTypeArray.Length - 1)
                {
                    // 차트타입 개수가 시리즈 개수보다 적을 경우 라인 타입으로 지정
                    chartSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    chartSeries.ChartType = chartTypeArray[i];
                }
                chartSeries.CustomProperties = "LabelStyle=Top";
                chartSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                if (i > bShowLabelArray.Length - 1)
                {
                    chartSeries.IsValueShownAsLabel = false;
                }
                else
                {
                    chartSeries.IsValueShownAsLabel = bShowLabelArray[i];
                }
                chartSeries.Legend = sChartLegendName;
                if (bShowMarker[i] == true)
                {
                    chartSeries.MarkerStyle = markerStyle;
                    chartSeries.MarkerColor = markerColor;
                }
                if (i > sChartNameArray.Length - 1)
                {
                    chartSeries.Name = i.ToString();
                }
                else
                {
                    chartSeries.Name = sChartNameArray[i];
                }
                chartSeries.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                chartSeries.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                // Secondary Axis Y Setting
                if (bSecondAxisY == true)
                {
                    for (int index = 0; index < iSecondAxiYSeriesIndex.Length; index++)
                    {
                        if (iSecondAxiYSeriesIndex != null)
                        {
                            if (i == iSecondAxiYSeriesIndex[index])
                            {
                                chartSeries.YAxisType = AxisType.Secondary;
                                if (secondeSeriesColor != null)
                                    chartSeries.Color = secondeSeriesColor[index];
                            }
                            else
                            {
                                chartSeries.YAxisType = AxisType.Primary;
                            }
                        }
                    }
                }

                // Data Bind
                chartSeries.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                chartSeries.ToolTip = chartSeries.Name + " : #VALY{D1}";
                this.Series.Add(chartSeries);
            }
        }

        /// <summary>
        /// 그래프 Y 데이타 중 최대값을 가져온다
        /// </summary>
        /// <param name="dtValue">DataTable Data</param>
        /// <param name="iCheckColoumnIndex">최대값을 가져올 컬럼 인덱스</param>
        /// <returns></returns>
        public double GetMaximunValue(System.Data.DataTable dtValue, int iCheckColoumnIndex)
        {
            if (dtValue == null)
                return 0;

            if (dtValue.Rows.Count == 0)
                return 0;

            double dMaxValue = 0;
            double dNextValue = 0;

            try
            {
                dMaxValue = Convert.ToDouble(dtValue.Rows[0][iCheckColoumnIndex].ToString());
                for (int i = 0; i < dtValue.Rows.Count; i++)
                {
                    dNextValue = Convert.ToDouble(dtValue.Rows[i][iCheckColoumnIndex].ToString());
                    if (dMaxValue < dNextValue)
                    {
                        dMaxValue = dNextValue;
                    }
                }

                return dMaxValue;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 그래프 Y 데이타 중 최소값을 가져온다.
        /// </summary>
        /// <param name="dtValue">DataTable Data</param>
        /// <param name="iCheckColoumnIndex">최소값을 가져올 컬럼 인덱스</param>
        /// <returns></returns>
        public double GetMinimunValue(System.Data.DataTable dtValue, int iCheckColoumnIndex)
        {
            if (dtValue == null)
                return 0;

            if (dtValue.Rows.Count == 0)
                return 0;

            double dMinValue = 0;
            double dNextValue = 0;

            try
            {
                dMinValue = Convert.ToDouble(dtValue.Rows[0][iCheckColoumnIndex].ToString());
                for (int i = 0; i < dtValue.Rows.Count; i++)
                {
                    dNextValue = Convert.ToDouble(dtValue.Rows[i][iCheckColoumnIndex].ToString());
                    if (dMinValue > dNextValue)
                    {
                        dMinValue = dNextValue;
                    }
                }

                return dMinValue;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 그래프의 Y 축의 최대값으로 지정할 값을 가져온다.
        /// </summary>
        /// <param name="dMaxValue">Y축의 데이타 중 최대값, 백분율 값만 가능</param>
        /// <returns></returns>
        public double GetMaxAxixYValue(double dMaxValue)
        {
            try
            {

                if (dMaxValue == 0)
                    return dMaxValue;

                dMaxValue = dMaxValue * 10;
                return StdMathExtension.RoundUpFix(dMaxValue) / 10;
            }
            catch
            {
                return dMaxValue;
            }
        }

        /// <summary>
        /// 그래프의 Y 축의 최소값으로 지정할 값을 가져온다.
        /// </summary>
        /// <param name="dMinValue">Y축의 데이타 중 최소값, 백분율 값만 가능</param>
        /// <returns></returns>
        public double GetMinAxixYValue(double dMinValue)
        {
            try
            {
                if (dMinValue == 0)
                    return dMinValue;

                dMinValue = dMinValue * 10;
                return StdMathExtension.RoundDownFix(dMinValue) / 10;
            }
            catch
            {
                return dMinValue;
            }
        }

        /// <summary>
        /// Initialize all ChartGrid with a table data.
        /// </summary>
        public void AddDataGrid(string chartAreaName, bool bRowTitleEnable, bool bColTitleEnable, bool[] bShowLabelArray)
        {
            chartGrid = new ChartDataGrid();
            chartGrid.RowTitleEnabled = bRowTitleEnable;
            chartGrid.ColTitleEnabled = bColTitleEnable; 

            foreach (bool b in bShowLabelArray)
            {
                chartGrid.SeriesEnables.Add(b);
            }

            chartGrid.AddDataGrid(this, chartAreaName);
        }

        #endregion
    }

    public class ChartDataGrid
    {
        #region Members
        protected System.Windows.Forms.DataVisualization.Charting.Chart ChartObj = null;
        public ArrayList RowTitles = new ArrayList();
        public ArrayList SeriesEnables = new ArrayList();
        protected System.Drawing.Color tableColor = Color.White;
        protected System.Drawing.Color borderColor = Color.Black;
        protected bool enabled = true;
        protected bool Initialized = false;
        protected System.Drawing.Color rowForeColor = Color.Black;
        protected System.Drawing.Color rowBackColor = Color.Khaki;
        protected bool rowTitleEnabled = true;
        protected int rowTitleSize = 50;
        protected int rowViewCount = 0;
        protected bool colTitleEnabled = true;
        protected System.Drawing.Color colForeColor = Color.Black;
        protected System.Drawing.Color colBackColor = Color.Khaki;
        #endregion

        #region Properies

        /// <summary>
        /// Enables or Disables the painting of the Data Table.
        /// </summary>
        public int RowTitleSize
        {
            get
            {
                return rowTitleSize;
            }
            set
            {
                rowTitleSize = value;
            }
        }

        /// <summary>
        /// Enables or Disables the painting of the Data Table.
        /// </summary>
        public System.Drawing.Color RowForeColor
        {
            get
            {
                return rowForeColor;
            }
            set
            {
                rowForeColor = value;
            }
        }

        /// <summary>
        /// Enables or Disables the painting of the Data Table.
        /// </summary>
        public System.Drawing.Color RowBackColor
        {
            get
            {
                return rowBackColor;
            }
            set
            {
                rowBackColor = value;
            }
        }

        /// <summary>
        /// Enables or Disables the painting of the Data Table.
        /// </summary>
        public System.Drawing.Color ColForeColor
        {
            get
            {
                return colForeColor;
            }
            set
            {
                colForeColor = value;
            }
        }

        /// <summary>
        /// Enables or Disables the painting of the Data Table.
        /// </summary>
        public System.Drawing.Color ColBackColor
        {
            get
            {
                return colBackColor;
            }
            set
            {
                colBackColor = value;
            }
        }

        /// <summary>
        /// Enables or Disables the painting of the Data Table.
        /// </summary>
        public bool RowTitleEnabled
        {
            get
            {
                return rowTitleEnabled;
            }
            set
            {
                rowTitleEnabled = value;
            }
        }

        /// <summary>
        /// Enables or Disables the painting of the Data Table.
        /// </summary>
        public bool ColTitleEnabled
        {
            get
            {
                return colTitleEnabled;
            }
            set
            {
                colTitleEnabled = value;
            }
        }


        /// <summary>
        /// Enables or Disables the painting of the Data Table.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }

        /// <summary>
        /// Sets or gets the Chart object.
        /// </summary>
        public System.Windows.Forms.DataVisualization.Charting.Chart Chart
        {
            get
            {
                return ChartObj;
            }
            set
            {
                ChartObj = value;
            }
        }


        /// <summary>
        /// Sets or gets the Table Color that will be painted.
        /// </summary>
        public System.Drawing.Color TableColor
        {
            get
            {
                return tableColor;
            }
            set
            {
                tableColor = value;
            }
        }

        /// <summary>
        /// Sets or gets the Table Border Color that will be painted.
        /// </summary>
        public System.Drawing.Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Construct a ChartDataTableHelper instance.
        /// </summary>
        public ChartDataGrid()
        {
            ChartObj = null;

            SeriesEnables.Clear();
        }

        #endregion

        #region Initialization Methods
        /// <summary>
        /// Initialize all ChartAreas with a table.
        /// </summary>
        public void AddDataGrid(System.Windows.Forms.DataVisualization.Charting.Chart chartObj, string chartAreaName)
        {
            ChartObj = chartObj;

            

            rowViewCount = 0;
            if (SeriesEnables.Count != 0)
            {
                foreach (bool b in SeriesEnables)
                {
                    if (b == true)
                        ++rowViewCount;
                }
            }
            else
            {
                // for each series that is attached to the chart area,
                // draw some boxes around the labels in the color provided
                foreach (System.Windows.Forms.DataVisualization.Charting.Series ser in ChartObj.Series)
                {
                    if (ser.Enabled == true)
                        ++rowViewCount;
                }
            }
            //컬럼헤드 추가..
            if (ColTitleEnabled) ++rowViewCount;

            foreach (System.Windows.Forms.DataVisualization.Charting.ChartArea area in ChartObj.ChartAreas)
            {
                if (area.Name == chartAreaName)
                {
                    AddDataTable(area.Name);
                    if (!Initialized)
                        ChartObj.PostPaint += new EventHandler<ChartPaintEventArgs>(Chart_PostPaint);
                    Initialized = true;
                }
            }
        }

        /// <summary>
        /// Initialize the specified ChartArea with a table.
        /// </summary>
        public void AddDataTable(string chartAreaName)
        {
            int Row = 0;

            // for each of the series that are attached to this 
            // named chart area, create a custom axis label.
            // All tables lines will be drawn on a paint event.
            // ****************************************************
            // NOTE: ALL SERIES MUST HAVE THE SAME NUMBER OF POINTS!
            // ****************************************************
            foreach (System.Windows.Forms.DataVisualization.Charting.Series ser in ChartObj.Series)
            {
                if (chartAreaName == ser.ChartArea && (bool)SeriesEnables[Row] == true)
                {
                    // shadows must be turned off otherwise
                    // they will still show up for the transparent points
                    ser.ShadowOffset = 0;
                    // adjust the series values to ensure they are not
                    // indexed and they are sorted... plus adding each point
                    // to make the dummy series data 
                    int index = 0;
                    foreach (DataPoint pt in ser.Points)
                    {
                        pt.XValue = (++index);
                    }

                    Row++;
                    double From = 0.0;
                    double To = 0.0;
                    bool firstPoint = true;

                    foreach (DataPoint dp in ser.Points)
                    {
                        if (firstPoint && dp.XValue == 0)
                            From = 0.5;
                        else if (firstPoint)
                            From = dp.XValue - 0.5;

                        if (firstPoint)
                        {
                            ChartObj.ChartAreas[chartAreaName].AxisX.Minimum = From;
                            ChartObj.ChartAreas[chartAreaName].AxisX.MajorGrid.Interval = 1;
                            ChartObj.ChartAreas[chartAreaName].AxisX.MajorTickMark.Interval = 1;
                            ChartObj.ChartAreas[chartAreaName].AxisX.LabelStyle.Interval = 1;
                            ChartObj.ChartAreas[chartAreaName].AxisX.MajorGrid.IntervalOffset = 0.5;
                            ChartObj.ChartAreas[chartAreaName].AxisX.MajorTickMark.IntervalOffset = 0.5;
                            ChartObj.ChartAreas[chartAreaName].AxisX.LabelStyle.IntervalOffset = 0.5;

                            ChartObj.ChartAreas[chartAreaName].CursorX.IntervalOffset = 0.5;

                            if (rowTitleEnabled)
                            {
                                if (rowTitleSize > 25)
                                {
                                    // Set Chart Area position
                                    ChartObj.ChartAreas[chartAreaName].Position.Auto = true;
                                    ChartObj.ChartAreas[chartAreaName].Position.X = 10;
                                    ChartObj.ChartAreas[chartAreaName].Position.Y = 12;
                                    ChartObj.ChartAreas[chartAreaName].Position.Width = 87;
                                    ChartObj.ChartAreas[chartAreaName].Position.Height = 90 - (rowViewCount * 6);
                                }
                            }
                        }

                        To = From + 1;

                        ChartObj.ChartAreas[chartAreaName].AxisX.CustomLabels.Add(
                            From, To,
                            " ",     // space used as a placeholder
                            Row, LabelMarkStyle.None, GridTickTypes.Gridline
                            );

                        firstPoint = false;
                        From += 1;
                    }

                    ChartObj.ChartAreas[chartAreaName].AxisX.Maximum = To;
                }
            }
        }
        #endregion

        #region Paint Event Handling

        /// <summary>
        /// Chart Paint event handler.
        /// </summary>
        private void Chart_PostPaint(object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e)
        {
            if (e.ChartElement is System.Windows.Forms.DataVisualization.Charting.ChartArea)
            {
                System.Windows.Forms.DataVisualization.Charting.ChartArea area = (System.Windows.Forms.DataVisualization.Charting.ChartArea)e.ChartElement;
                // call the paint method.
                if (ChartObj.ChartAreas.IndexOf(area.Name) >= 0 && enabled)
                {
                    PaintDataTable(e);
                }
            }
        }

        /// <summary>
        /// This method does all the work for the painting of the data table.
        /// </summary>
        private void PaintDataTable(System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea area = (System.Windows.Forms.DataVisualization.Charting.ChartArea)e.ChartElement;

            // get the rect of the chart area
            RectangleF rect = e.ChartGraphics.GetAbsoluteRectangle(area.Position.ToRectangleF());

            // get the inner plot position
            ElementPosition elemPos = area.InnerPlotPosition;

            // find the coordinates of the inner plot position
            float x = rect.X + (rect.Width / 100 * elemPos.X);
            float y = rect.Y + (rect.Height / 100 * elemPos.Y);
            float ChartAreaBottomY = (rect.Y + rect.Height);

            // offset the bottom by the width+1 of the scrollbar if it is visible
            if (area.AxisX.ScrollBar.IsVisible && !area.AxisX.ScrollBar.IsPositionedInside)
                ChartAreaBottomY -= ((float)area.AxisX.ScrollBar.Size + 1);  

            float width = (rect.Width / 100 * elemPos.Width);
            float height = (rect.Height / 100 * elemPos.Height);

            // find the height of the font that will be used
            System.Drawing.Font axisFont = area.AxisX.LabelStyle.Font;

            string testString = "ForFontHeight";
            SizeF axisFontSize = e.ChartGraphics.Graphics.MeasureString(testString, axisFont);

            // find the height of the font that will be used
            System.Drawing.Font titleFont = area.AxisX.TitleFont;
            testString = area.AxisX.Title;
            SizeF titleFontSize = e.ChartGraphics.Graphics.MeasureString(testString, titleFont);

            int seriesCount = rowViewCount;
            float iRowTitleSize = rowTitleSize;

            // now, if a box was actually drawn, then draw 
            // the verticle lines to separate the columns of the table.
            if (seriesCount > 0)
            {
                for (int i = 0; i < e.Chart.Series.Count; i++)
                {
                    if (area.Name == e.Chart.Series[i].ChartArea)
                    {
                        double min = area.AxisX.Minimum;
                        double max = area.AxisX.Maximum;

                        // modify the min value for the current axis view
                        if (area.AxisX.ScaleView.Position - 1 > min)
                            min = area.AxisX.ScaleView.Position - 1;

                        // modify the max value for the currect axis view
                        if ((area.AxisX.ScaleView.Position + area.AxisX.ScaleView.Size + 0.5) < max)
                            max = area.AxisX.ScaleView.Position + area.AxisX.ScaleView.Size + 0.5;

                        // find the starting point that will be display.
                        // this is dependent on the current axis view.
                        // this sample assumes the same number of points in each
                        // series so always take from the zeroth series
                        int pointIndex = 0;
                        foreach (DataPoint pt in ChartObj.Series[0].Points)
                        {
                            if (pt.XValue > min)
                                break;

                            pointIndex++;
                        }

                        bool TableLegendDrawn = false;

                        for (double AxisValue = min; AxisValue < max; AxisValue++)
                        {
                            float pixelX = (float)e.ChartGraphics.GetPositionFromAxis(area.Name, AxisName.X, AxisValue);
                            float nextPixelX = (float)e.ChartGraphics.GetPositionFromAxis(area.Name, AxisName.X, AxisValue + 1);
                            float pixelY = ChartAreaBottomY - titleFontSize.Height - ((seriesCount * (axisFontSize.Height - 15)) + 35);//grid 위치조정

                            PointF point1 = PointF.Empty;
                            PointF point2 = PointF.Empty;

                            // Set Maximum and minimum points
                            point1.X = pixelX;
                            point1.Y = 0;

                            // Convert relative coordinates to absolute coordinates.
                            point1 = e.ChartGraphics.GetAbsolutePoint(point1);
                            point2.X = point1.X;
                            point2.Y = ChartAreaBottomY - titleFontSize.Height;
                            point1.Y = pixelY;

                            point2.X = nextPixelX;
                            point2.Y = 0;
                            point2 = e.ChartGraphics.GetAbsolutePoint(point2);

                            StringFormat format = new StringFormat();
                            format.Alignment = StringAlignment.Center;
                            format.LineAlignment = StringAlignment.Center;


                            // Row title view point values.
                            if ((point1.X - iRowTitleSize) < 5)
                            {
                                iRowTitleSize = point1.X - 5;
                            }

                            // for each series draw one value in the column
                            int row = 1;
                            int j = 0;
                            string label = string.Empty;
                            bool ColoumnTitleDrawn = false;

                            foreach (System.Windows.Forms.DataVisualization.Charting.Series ser in ChartObj.Series)
                            {
                                if (pointIndex < ser.Points.Count)
                                {
                                    if (area.Name == ser.ChartArea && (bool)SeriesEnables[j++] == true)
                                    {
                                        if (!ColoumnTitleDrawn && ColTitleEnabled)
                                        {
                                            if (!TableLegendDrawn && RowTitleEnabled)
                                            {
                                                DataRectanglePaint(e.ChartGraphics.Graphics,
                                                                    point1.X - iRowTitleSize,
                                                                    point1.Y + (row * (axisFontSize.Height + 2)),
                                                                    iRowTitleSize,
                                                                    axisFontSize.Height + 2,
                                                                    "구분",
                                                                    axisFont,
                                                                    format,
                                                                    area.AxisX.LabelStyle.ForeColor,
                                                                    colBackColor,
                                                                    borderColor);
                                            }

                                            DataRectanglePaint(e.ChartGraphics.Graphics,
                                                                point1.X,
                                                                    point1.Y + (row * (axisFontSize.Height + 2)),
                                                                point2.X - point1.X,
                                                                   axisFontSize.Height + 2,
                                                                ser.Points[pointIndex].AxisLabel,
                                                                axisFont,
                                                                format,
                                                                area.AxisX.LabelStyle.ForeColor,
                                                                colBackColor,
                                                                borderColor);
                                            ColoumnTitleDrawn = true;
                                            row++;
                                        }

                                        {
                                            if (!TableLegendDrawn && RowTitleEnabled)
                                            {
                                                DataRectanglePaint(e.ChartGraphics.Graphics,
                                                                    point1.X - iRowTitleSize,
                                                                    point1.Y + (row * (axisFontSize.Height + 2)),
                                                                    iRowTitleSize,
                                                                    axisFontSize.Height + 2,
                                                                    ser.Name.ToString(),
                                                                    axisFont,
                                                                    format,
                                                                    area.AxisX.LabelStyle.ForeColor,
                                                                    colBackColor,
                                                                    borderColor);
                                            }

                                            DataRectanglePaint(e.ChartGraphics.Graphics,
                                                                point1.X,
                                                                    point1.Y + (row * (axisFontSize.Height + 2)),
                                                                point2.X - point1.X,
                                                                    axisFontSize.Height + 2,
                                                                (ser.LabelFormat.PadLeft(1, ' ').Substring(0, 1) == "P") ? ((ser.Points[pointIndex].YValues[0] * 100).ToString("##0.0") + "%") : (ser.Points[pointIndex].YValues[0].ToString()),
                                                                axisFont,
                                                                format,
                                                                area.AxisX.LabelStyle.ForeColor,
                                                                tableColor,
                                                                borderColor);
                                            row++;
                                        }
                                    }
                                }
                            }

                            TableLegendDrawn = true;

                            pointIndex++;
                        }

                        // do this only once so break!
                        break;
                    }
                }
            }
        }

               /// <summary>
        /// This method does all the work for the painting of the data table.
        /// </summary>
        private void DataRectanglePaint(Graphics g, float x, float y, float width, float height, string str, System.Drawing.Font font, StringFormat format, Color foreColor, Color backColor, Color borderColor)
        {
            // draw the series color box 
            g.FillRectangle(new SolidBrush(backColor), x, y, width, height);
            //g.DrawRectangle(new Pen(borderColor), x, y, width, height);
            g.DrawLine(new Pen(borderColor), x, y, x + width, y);
            g.DrawLine(new Pen(borderColor), x, y + height, x + width, y + height);
            g.DrawLine(new Pen(borderColor), x, y, x, y + height);
            g.DrawLine(new Pen(borderColor), x + width, y, x + width, y + height);
            g.DrawString(str, font, new SolidBrush(foreColor), new RectangleF(x, y + 2, width, height - 2), format);
        }
        #endregion
    }

    public class StdMathExtension
    {
        public static int Sign(
#if CS3
            this
#endif // CS3
decimal x)
        {
            return Math.Sign(x);
        }

        public static int Sign(
#if CS3
            this
#endif // CS3
double x)
        {
            return Math.Sign(x);
        }

        public static int Integer(
#if CS3
            this
#endif // CS3
decimal x)
        {
            return (int)Math.Truncate(x);
        }

        public static int Integer(
#if CS3
            this
#endif // CS3
double x)
        {
            return (int)Math.Truncate(x);
        }

        public static decimal Fraction(
#if CS3
            this
#endif // CS3
decimal x)
        {
            return x - Math.Truncate(x);
        }

        public static double Fraction(
#if CS3
            this
#endif // CS3
double x)
        {
            return x - Math.Truncate(x);
        }

        public static decimal RoundUp(
#if CS3
            this
#endif // CS3
decimal x)
        {
            return Integer(x) + Sign(Fraction(x));
        }

        public static double RoundUp(
#if CS3
            this
#endif // CS3
double x)
        {
            return Integer(x) + Sign(Fraction(x));
        }

        public static decimal RoundDown(
#if CS3
            this
#endif // CS3
decimal x)
        {
            return Integer(x);
        }

        public static double RoundDown(
#if CS3
            this
#endif // CS3
double x)
        {
            return Integer(x);
        }

        public static decimal Round(
#if CS3
            this
#endif // CS3
decimal x)
        {
            return Integer(x) + Integer(Fraction(x) * 2m);
        }

        public static double Round(
#if CS3
            this
#endif // CS3
double x)
        {
            return Integer(x) + Integer(Fraction(x) * 2d);
        }

        public static decimal Fix(
#if CS3
            this
#endif // CS3
decimal x)
        {
            if (x >= 0m || Fraction(x) == 0m)
                return Integer(x);
            else
                return Integer(x) - 1;
        }

        public static double Fix(
#if CS3
            this
#endif // CS3
double x)
        {
            if (x >= 0d || Fraction(x) == 0d)
                return Integer(x);
            else
                return Integer(x) - 1;
        }

        public static decimal RoundDownFix(
#if CS3
            this
#endif // CS3
decimal x)
        {
            return Fix(x);
        }

        public static double RoundDownFix(
#if CS3
            this
#endif // CS3
double x)
        {
            return Fix(x);
        }

        public static int Absolute(
#if CS3
            this
#endif // CS3
int x)
        {
            return Math.Abs(x);
        }

        public static decimal RoundUpFix(
#if CS3
            this
#endif // CS3
decimal x)
        {
            return Fix(x) + Absolute(Sign(Fraction(x)));
        }

        public static double RoundUpFix(
#if CS3
            this
#endif // CS3
double x)
        {
            return Fix(x) + Absolute(Sign(Fraction(x)));
        }

        public static decimal RoundFix(
#if CS3
            this
#endif // CS3
decimal x)
        {
            return Fix(x + 0.5m);
        }

        public static double RoundFix(
#if CS3
            this
#endif // CS3
double x)
        {
            return Fix(x + 0.5d);
        }

        public static decimal RoundTo(
#if CS3
            this
#endif // CS3
decimal x, int d)
        {
            decimal n = (decimal)Math.Pow(10, d);
            x *= n;
            return (Integer(x) + Integer(Fraction(x) * 2m)) / n;
        }

        public static double RoundTo(
#if CS3
            this
#endif // CS3
double x, int d)
        {
            double n = Math.Pow(10, d);
            x *= n;
            return (Integer(x) + Integer(Fraction(x) * 2d)) / n;
        }
    }

    public class StdExcelFunction
    {
        private const int EXCEL_FIRST_ROWCOL = 1;
        private const int EXCEL_START_ROW = 3;
        private const int EXCEL_START_COL = 1;

        /// <summary>
        /// Export Data of Control to Excel Application Data
        /// </summary>
        /// <param name="ctlObject">Excel export target object(ListView, FpSpread)</param>
        /// <param name="sTitle">Excel export title string.</param>
        /// <param name="sCondition">Excel export condition string.</param>
        /// <param name="bColorFlag">Cell Fore/Backgroup color set(True/False)</param>
        /// <param name="bTextBase">Cell format only text(True/False)</param>
        /// <param name="bShowDate">Current Date/Time visible(True/False)</param>
        /// <param name="iStartCol">Start column(-1: All column)</param>
        /// <param name="iEndCol">Last column(-1: All column)</param>
        /// <returns>True or False, Otherwise Exception pass the throw </returns>
        public static bool ExportToExcel(System.Windows.Forms.Control ctlObject,
                            string sTitle, string sCondition,
                            bool bColorFlag, bool bTextBase, bool bShowDate,
                            int iStartCol, int iEndCol)
        {
            if (ExportToExcel(ctlObject, sTitle, sCondition, bColorFlag, bTextBase, bShowDate, iStartCol, iEndCol, 0, false, true) == true)
            {
                MPCF.ShowMsgBox("Excel Export가 완료 되었습니다.", "Excel Export", MessageBoxButtons.OK, 1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Export Data of Control to Excel Application Data
        /// </summary>
        /// <param name="ctlObject">Excel export target object(ListView, FpSpread)</param>
        /// <param name="sTitle">Excel export title string.</param>
        /// <param name="sCondition">Excel export condition string.</param>
        /// <param name="bColorFlag">Cell Fore/Backgroup color set(True/False)</param>
        /// <param name="bTextBase">Cell format only text(True/False)</param>
        /// <param name="bShowDate">Current Date/Time visible(True/False)</param>
        /// <param name="iStartCol">Start column(-1: All column)</param>
        /// <param name="iEndCol">Last column(-1: All column)</param>
        /// <param name="iRowHeight">Row Height(0: default RowHeight)</param>
        /// <returns>True or False, Otherwise Exception pass the throw </returns>
        public static bool ExportToExcel(System.Windows.Forms.Control ctlObject,
                            string sTitle, string sCondition,
                            bool bColorFlag, bool bTextBase, bool bShowDate,
                            int iStartCol, int iEndCol, int iRowHeight, bool bMergeRows)
        {
            if (ExportToExcel(ctlObject, sTitle, sCondition, bColorFlag, bTextBase, bShowDate, iStartCol, iEndCol, iRowHeight, false, bMergeRows) == true)
            {
                MPCF.ShowMsgBox("Excel Export가 완료 되었습니다.", "Excel Export", MessageBoxButtons.OK, 1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Export Data of Control to Excel Application Data
        /// </summary>
        /// <param name="ctlObject">Excel export target object(ListView, FpSpread)</param>
        /// <param name="sTitle">Excel export title string.</param>
        /// <param name="sCondition">Excel export condition string.</param>
        /// <param name="bColorFlag">Cell Fore/Backgroup color set(True/False)</param>
        /// <param name="bTextBase">Cell format only text(True/False)</param>
        /// <param name="bShowDate">Current Date/Time visible(True/False)</param>
        /// <param name="iStartCol">Start column(-1: All column)</param>
        /// <param name="iEndCol">Last column(-1: All column)</param>
        /// <param name="iRowHeight">Row Height(0: default RowHeight)</param>
        /// <param name="bOnlyData">Only Data export</param>
        /// <returns>True or False, Otherwise Exception pass the throw </returns>
        public static bool ExportToExcel(System.Windows.Forms.Control ctlObject,
                            string sTitle, string sCondition,
                            bool bColorFlag, bool bTextBase, bool bShowDate,
                            int iStartCol, int iEndCol, int iRowHeight, bool bOnlyData, bool bMergeRows)
        {
            try
            {
                // Export excel title.
                if (sTitle == null)
                {
                    sTitle = "##";
                }
                else
                {
                    // Invalide Sheet name replace(/,?,*,[,])
                    sTitle = sTitle.Trim().Replace("/", "").Replace("?", "").Replace("*", "").Replace("[", "").Replace("]", "");
                    if (sTitle.Length > 30)
                    {
                        sTitle = sTitle.Substring(0, 30);
                    }
                }

                // Export excel condition.
                if (sCondition == null)
                {
                    sCondition = " ";
                }

                // Export excel data.
                if (ctlObject is ListView)
                {
                    if (((ListView)ctlObject).Items.Count > 0)
                    {
                        return ListviewToExcel(new ListView[] { (ListView)ctlObject },
                                null, 0,
                                sTitle, sCondition,
                                bColorFlag, bTextBase, bShowDate);
                    }
                }
                else if (ctlObject is FarPoint.Win.Spread.FpSpread)
                {
                    if (((FarPoint.Win.Spread.FpSpread)ctlObject).ActiveSheet.RowCount > 0)
                    {
                        return SpreadSheetToExcel(new FarPoint.Win.Spread.SheetView[] { ((FarPoint.Win.Spread.FpSpread)ctlObject).ActiveSheet },
                                null, 0,
                                sTitle, sCondition,
                                bColorFlag, bTextBase, bShowDate,
                                iStartCol, iEndCol, iRowHeight,
                                bOnlyData, null, bMergeRows);
                    }
                }
                else
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(11), "Error", MessageBoxButtons.OK, 1);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message, "Error", MessageBoxButtons.OK, 1);
            }

            return false;

        }


        /// <summary>
        /// Export Data of Array Control to Excel Application Data
        /// </summary>
        /// <param name="ctlObject">Excel export target array object(ListView, FpSpread)</param>
        /// <param name="sImageFileName">Excel export image file full path(Jpg, bmp, etc)</param>
        /// <param name="iImagePostion">Image posiont(1: Top, 2: Bottom)</param>
        /// <param name="sTitle">Excel export title string.</param>
        /// <param name="sCondition">Excel export condition string.</param>
        /// <param name="bColorFlag">Cell Fore/Backgroup color set(True/False)</param>
        /// <param name="bTextBase">Cell format only text(True/False)</param>
        /// <param name="bShowDate">Current Date/Time visible(True/False)</param>
        /// <param name="iStartCol">Start column(-1: All column)</param>
        /// <param name="iEndCol">Last column(-1: All column)</param>
        /// <returns>True or False, Otherwise Exception pass the throw </returns>
        public static bool ExportToExcelEx(System.Windows.Forms.Control[] ctlObject,
                            string sImageFileName, int iImagePostion,
                            string sTitle, string sCondition,
                            bool bColorFlag, bool bTextBase, bool bShowDate,
                            int iStartCol, int iEndCol)
        {
            if (ExportToExcelEx(ctlObject, sImageFileName, iImagePostion,
                            sTitle, sCondition, bColorFlag, bTextBase, bShowDate,
                            iStartCol, iEndCol, 0, false, null, true) == true)
            {
                MPCF.ShowMsgBox("Excel Export가 완료 되었습니다.", "Excel Export", MessageBoxButtons.OK, 1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Export Data of Array Control to Excel Application Data
        /// </summary>
        /// <param name="ctlObject">Excel export target array object(ListView, FpSpread)</param>
        /// <param name="sImageFileName">Excel export image file full path(Jpg, bmp, etc)</param>
        /// <param name="iImagePostion">Image posiont(1: Top, 2: Bottom)</param>
        /// <param name="sTitle">Excel export title string.</param>
        /// <param name="sCondition">Excel export condition string.</param>
        /// <param name="bColorFlag">Cell Fore/Backgroup color set(True/False)</param>
        /// <param name="bTextBase">Cell format only text(True/False)</param>
        /// <param name="bShowDate">Current Date/Time visible(True/False)</param>
        /// <param name="iStartCol">Start column(-1: All column)</param>
        /// <param name="iEndCol">Last column(-1: All column)</param>
        /// <param name="iRowHeight">Row Height(0: default RowHeight)</param>
        /// <param name="bOnlyData">Only Data export</param>
        /// <returns>True or False, Otherwise Exception pass the throw </returns>
        public static bool ExportToExcelEx(System.Windows.Forms.Control[] ctlObject,
                            string sImageFileName, int iImagePostion,
                            string sTitle, string sCondition,
                            bool bColorFlag, bool bTextBase, bool bShowDate,
                            int iStartCol, int iEndCol, int iRowHeight, bool bOnlyData)
        {
            if (ExportToExcelEx(ctlObject, sImageFileName, iImagePostion,
                            sTitle, sCondition, bColorFlag, bTextBase, bShowDate,
                            iStartCol, iEndCol, iRowHeight, bOnlyData, null, true) == true)
            {
                MPCF.ShowMsgBox("Excel Export가 완료 되었습니다.", "Excel Export", MessageBoxButtons.OK, 1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Export Data of Array Control to Excel Application Data
        /// </summary>
        /// <param name="ctlObject">Excel export target array object(ListView, FpSpread)</param>
        /// <param name="sImageFileName">Excel export image file full path(Jpg, bmp, etc)</param>
        /// <param name="iImagePostion">Image posiont(1: Top, 2: Bottom)</param>
        /// <param name="sTitle">Excel export title string.</param>
        /// <param name="sCondition">Excel export condition string.</param>
        /// <param name="bColorFlag">Cell Fore/Backgroup color set(True/False)</param>
        /// <param name="bTextBase">Cell format only text(True/False)</param>
        /// <param name="bShowDate">Current Date/Time visible(True/False)</param>
        /// <param name="iStartCol">Start column(-1: All column)</param>
        /// <param name="iEndCol">Last column(-1: All column)</param>
        /// <param name="iRowHeight">Row Height(0: default RowHeight)</param>
        /// <param name="bOnlyData">Only Data export</param>
        /// <param name="pageOptions">Set Print PageSetup Array[12] values(Set defualt use = -1)</param>
        /// <returns>True or False, Otherwise Exception pass the throw </returns>
        public static bool ExportToExcelEx(System.Windows.Forms.Control[] ctlObject,
                            string sImageFileName, int iImagePostion,
                            string sTitle, string sCondition,
                            bool bColorFlag, bool bTextBase, bool bShowDate,
                            int iStartCol, int iEndCol, int iRowHeight,
                            bool bOnlyData, float[] pageOptions, bool bMergeRows)
        {
            ListView[] xList = null;
            FarPoint.Win.Spread.SheetView[] xSheet = null;
            Boolean bReturn = false;

            try
            {
                // Export excel title.
                if (sTitle == null)
                {
                    sTitle = "##";
                }
                else
                {
                    // Invalide Sheet name replace(/,?,*,[,])
                    sTitle = sTitle.Trim().Replace("/", "").Replace("?", "").Replace("*", "").Replace("[", "").Replace("]", "");
                    if (sTitle.Length > 30)
                    {
                        sTitle = sTitle.Substring(0, 30);
                    }
                }

                // Export excel condition.
                if (sCondition == null)
                {
                    sCondition = " ";
                }

                foreach (System.Windows.Forms.Control objList in ctlObject)
                {
                    if (objList is ListView)
                    {
                        ListView[] tempView = null;

                        if (((ListView)objList).Items.Count <= 0)
                        {
                            continue;
                        }

                        if (xList == null || xList.Length <= 0)
                        {
                            tempView = new ListView[1];
                            tempView[0] = (ListView)objList;
                        }
                        else
                        {
                            tempView = new ListView[xList.Length + 1];
                            Array.Copy(xList, tempView, xList.Length);
                            tempView[xList.Length] = (ListView)objList;
                        }

                        xList = new ListView[tempView.Length];
                        Array.Copy(tempView, xList, tempView.Length);
                    }
                    else if (objList is FarPoint.Win.Spread.FpSpread)
                    {
                        FarPoint.Win.Spread.SheetView[] tempView = null;

                        if (((FarPoint.Win.Spread.FpSpread)objList).ActiveSheet.RowCount <= 0)
                        {
                            continue;
                        }

                        if (xSheet == null || xSheet.Length <= 0)
                        {
                            tempView = new FarPoint.Win.Spread.SheetView[1];
                            tempView[0] = ((FarPoint.Win.Spread.FpSpread)objList).ActiveSheet;
                        }
                        else
                        {
                            tempView = new FarPoint.Win.Spread.SheetView[xSheet.Length + 1];
                            Array.Copy(xSheet, tempView, xSheet.Length);
                            tempView[xSheet.Length] = ((FarPoint.Win.Spread.FpSpread)objList).ActiveSheet;
                        }

                        xSheet = new FarPoint.Win.Spread.SheetView[tempView.Length];
                        Array.Copy(tempView, xSheet, tempView.Length);
                    }
                }

                if (xList != null && xList.Length > 0)
                {
                    bReturn = ListviewToExcel(xList,
                                sImageFileName, iImagePostion,
                                sTitle, sCondition, bColorFlag, bTextBase, bShowDate);
                }

                if (xSheet != null && xSheet.Length > 0)
                {
                    bReturn = SpreadSheetToExcel(xSheet,
                                sImageFileName, iImagePostion,
                                sTitle, sCondition,
                                bColorFlag, bTextBase, bShowDate,
                                iStartCol, iEndCol, iRowHeight, bOnlyData, pageOptions, bMergeRows);
                }
                else
                {
                    bReturn = SpreadSheetToExcel(xSheet,
                                sImageFileName, iImagePostion,
                                sTitle, sCondition,
                                bColorFlag, bTextBase, bShowDate,
                                iStartCol, iEndCol, iRowHeight, bOnlyData, pageOptions, bMergeRows);
                }

                return bReturn;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message, "Error", MessageBoxButtons.OK, 1);
            }

            return false;

        }

        // ExportToText()
        //       - Export Data of Control to Tab Text Data
        // Return Value
        //       - True or False
        // Arguments
        //       - ByRef l_control as listview
        //       - ByVal title as string : Form title
        //       - Optional ByVal Condition as string
        //
        private static bool ExportToText(System.Windows.Forms.Control ctlObject, string title, string condition)
        {
            string sClipData;
            string sFileName;
            int i, j;

            StreamWriter TXTStream = null;
            SaveFileDialog SaveDialog;
            ListView lisCtl;
            ListViewItem lisItem;

            try
            {
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                sFileName = title;
                sFileName += "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";


                SaveDialog = new SaveFileDialog();
                SaveDialog.FileName = sFileName;
                SaveDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                if (SaveDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return false;
                }

                sFileName = SaveDialog.FileName;
                if (sFileName.IndexOf(".") <= 0)
                {
                    sFileName += ".xls";
                }

                TXTStream = File.CreateText(sFileName);

                sClipData = "";
                sClipData = title + "\r";
                if (condition.Trim() != "")
                {
                    sClipData += "\r" + "\r";
                    sClipData += condition + "\r";
                    sClipData += "\r";
                }
                sClipData = sClipData + "\r";

                if (ctlObject is ListView)
                {
                    lisCtl = (ListView)ctlObject;
                    for (i = 0; i < lisCtl.Columns.Count; i++)
                    {
                        if (lisCtl.Columns[i].Width > 0)
                        {
                            //sClipData = sClipData + Strings.Replace(lisCtl.Columns[i].Text, "\r", "   ", 1, -1, 0).Replace("\n", " ") + "\t";
                            sClipData += lisCtl.Columns[i].Text.Replace("\r", "   ").Replace("\n", " ") + "\t";
                        }
                    }
                    sClipData += "\r";

                    for (i = 0; i < lisCtl.Items.Count; i++)
                    {
                        for (j = 0; j < lisCtl.Columns.Count; j++)
                        {
                            if (lisCtl.Columns[j].Width > 0)
                            {
                                lisItem = lisCtl.Items[i];
                                try
                                {
                                    if (lisItem.SubItems[j].Text.IndexOf("<") > 0 ||
                                        lisItem.SubItems[j].Text.IndexOf(">") > 0)
                                    {
                                        sClipData += System.Convert.ToString(lisItem.SubItems[j].Text).Trim().Replace(" ", "").Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                    }
                                    else
                                    {
                                        sClipData += System.Convert.ToString(lisItem.SubItems[j].Text).Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                    }
                                }
                                catch
                                {
                                    sClipData += "\t";
                                }
                            }
                        }
                        sClipData += "\r";
                    }
                }
                else
                {
                    MPCF.ShowMsgBox("Invalid Control Type.", "Warring", MessageBoxButtons.OK, 1);
                    return false;
                }

                Clipboard.SetDataObject((object)sClipData, false, 5, 10);

                TXTStream.Write(sClipData);
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message, "Error", MessageBoxButtons.OK, 1);
                return false;
            }
            finally
            {
                if (TXTStream != null)
                {
                    TXTStream.Close();
                    TXTStream = null;
                }

                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }

        }

        // ListViewToExcel()
        //       - Export Data of Listview Control to Excel Application Data
        // Return Value
        //       - True or False
        private static bool ListviewToExcel(ListView[] xList,
                string imageFile, int imagePostion,
                string title, string condition,
                bool colorFlag, bool bTextBase, bool bShowDate)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks xlBooks = xlApp.Workbooks;
            Excel.Workbook xlBook = xlBooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.ActiveSheet;
            Excel.Range xlWiths;

            Int32 i, j;
            int iRestRows, iRestCols, iColumnCnt;
            string clipboardData;
            ListViewItem lisItem;
            bool bReturn = true;

            try
            {
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                if (title.Trim().Length > 30)
                {
                    xlSheet.Name = title.TrimEnd().Substring(0, 30);
                }
                else
                {
                    xlSheet.Name = title.TrimEnd();
                }

                // Start Row/Column reset.
                iRestRows = EXCEL_START_ROW;
                iRestCols = EXCEL_START_COL;

                // 데이터 조회조건에 대한 설명 또는 추가정보 설정.
                condition = condition.TrimEnd(new char[] { ' ', '\r', '\n' });
                if (condition.Length > 0)
                {
                    string[] sTempStr = condition.Split(new char[] { '\r', '\n' });
                    iRestRows += (sTempStr.Length + 1);
                }

                //First Column Width
                xlSheet.Cells.Select();
                xlSheet.Cells.EntireColumn.ColumnWidth = 1;
                xlSheet.Cells.Font.Name = "Tahoma";
                xlSheet.Cells.Font.Size = 10;

                // 이미지가 상단에 위치할 경우(만약, imagePostion == 0이면 이미지를 표시하지 않음)
                if (imageFile != null && imagePostion == 1)
                {
                    int importRows = iRestRows;

                    importRows = InsertImageToExcel((Excel._Worksheet)xlSheet, imageFile, importRows, iRestCols);
                    if (importRows > 0) // Image is Top position.
                    {
                        iRestRows += importRows + 2;
                    }
                }

                // 각종 엑셀의 경고메시지를 보이지 않도록 합니다.
                xlApp.DisplayAlerts = false;

                //'셀서식을 TEXT로 인식하도록 한다.
                //'단, 셀 서식이 Text일 경우에는 셀 병합할 때 확인 창이 뜬다.
                if (bTextBase == true)
                {
                    xlSheet.Cells.NumberFormat = "@";
                }

                // 여러개의 ListView를 하나의 Excel에 붙여넣음.
                foreach (ListView activeList in xList)
                {

                    if (activeList.Items.Count <= 0)
                    {
                        continue;
                    }



                    iColumnCnt = 0;
                    for (i = 0; i < activeList.Columns.Count; i++)
                    {
                        if (activeList.Columns[i].Width > 0)
                        {
                            iColumnCnt++;
                        }
                    }

                    //'Column Header에 대한 셀서식
                    xlWiths = xlSheet.get_Range(xlSheet.Cells[iRestRows, iRestCols], xlSheet.Cells[iRestRows, iRestCols + iColumnCnt - 1]);
                    xlWiths.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                    xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                    xlWiths.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue);
                    xlWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    xlWiths.Font.Bold = true;
                    xlWiths.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xlWiths.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xlWiths.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    if (xlWiths.Rows.Count > 1)
                    {
                        xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    }
                    if (xlWiths.Columns.Count > 1)
                    {
                        xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    }

                    //' List에 대한 셀서식
                    if (activeList.Items.Count > 0)
                    {
                        xlWiths = xlSheet.get_Range(xlSheet.Cells[iRestRows + 1, iRestCols], xlSheet.Cells[iRestRows + activeList.Items.Count, iRestCols + iColumnCnt - 1]);
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        if (xlWiths.Columns.Count > 1)
                        {
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                        }

                        if (xlWiths.Rows.Count > 1)
                        {
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                        }

                        if (colorFlag == true)
                        {
                            xlWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(activeList.ForeColor);
                        }
                    }

                    clipboardData = "";
                    for (i = 0; i < activeList.Columns.Count; i++)
                    {
                        if (activeList.Columns[i].Width > 0)
                        {
                            clipboardData += activeList.Columns[i].Text + "\t";
                        }
                    }
                    clipboardData += "\r";
                    Clipboard.SetDataObject((object)clipboardData, false, 5, 10);
                    ((Excel.Range)xlSheet.Cells[iRestRows, iRestCols]).Select();
                    //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    clipboardData = "";
                    for (i = 0; i < activeList.Items.Count; i++)
                    {
                        for (j = 0; j < activeList.Columns.Count; j++)
                        {
                            if (activeList.Columns[j].Width > 0)
                            {
                                try
                                {
                                    if (activeList.Items[i].SubItems[j].Text.IndexOf("<") > 0 ||
                                        activeList.Items[i].SubItems[j].Text.IndexOf(">") > 0)
                                    {
                                        clipboardData += System.Convert.ToString(activeList.Items[i].SubItems[j].Text).Trim().Replace(" ", "").Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                    }
                                    else
                                    {
                                        clipboardData += System.Convert.ToString(activeList.Items[i].SubItems[j].Text).Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                    }
                                }
                                catch
                                {
                                    clipboardData += "\t";
                                }
                            }
                        }

                        clipboardData = clipboardData + "\r";
                        if ((i + 1) % 100 == 0 || i == activeList.Items.Count - 1)
                        {
                            if ((i + 1) >= 100)
                            {
                                ((Excel.Range)xlSheet.Cells[(iRestRows + 1 + 100 * ((i) / 100)), iRestCols]).Select();
                                //xlSheet.get_Range("B" + System.Convert.ToString(iRestRows + 1 + 100 * ((i) / 100)), Type.Missing).Select();
                            }
                            else
                            {
                                ((Excel.Range)xlSheet.Cells[(iRestRows + 1), iRestCols]).Select();
                                //xlSheet.get_Range("B" + System.Convert.ToString(iRestRows + 1), Type.Missing).Select();
                            }

                            Clipboard.SetDataObject((object)clipboardData, false, 5, 10);
                            //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            clipboardData = "";
                        }
                    }

                    // Column크기를 자동으로 조절.
                    xlWiths = xlSheet.get_Range(xlSheet.Cells[iRestRows + 1, iRestCols], xlSheet.Cells[iRestRows + activeList.Items.Count, iRestCols + iColumnCnt - 1]);
                    xlWiths.CurrentRegion.EntireColumn.AutoFit();

                    if (colorFlag == true)
                    {
                        for (i = 0; i < activeList.Items.Count; i++)
                        {
                            lisItem = activeList.Items[i];
                            if (lisItem.SubItems[0].ForeColor.IsEmpty == false)
                            {
                                if (lisItem.SubItems[0].ForeColor.ToArgb() != System.Drawing.Color.Black.ToArgb())
                                {
                                    xlSheet.get_Range(xlSheet.Cells[i + iRestRows + 1, iRestCols], xlSheet.Cells[i + iRestRows + 1, iRestCols + iColumnCnt - 1]).Font.Color =
                                    System.Drawing.ColorTranslator.ToOle(lisItem.SubItems[0].ForeColor);
                                }
                            }
                        }
                    }

                    iRestRows += activeList.Items.Count + 1;
                }

                //'Title 에 대한 셀 서식 지정
                xlWiths = xlSheet.get_Range(xlSheet.Cells[1, 2], xlSheet.Cells[1, 2]);
                xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter;
                xlWiths.RowHeight = 30;
                xlWiths.Font.Size = 12;
                xlWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                xlWiths.Font.Bold = true;
                //xlWiths.Font.Name = "Tahoma";
                ((Excel.Range)xlSheet.Cells[1, iRestCols]).Value2 = title;

                if (bShowDate == true)
                {
                    string sNowDate;
                    sNowDate = string.Format(Convert.ToString(DateTime.Now), "yyyy-MM-dd") + " " + string.Format(Convert.ToString(DateTime.Now), "HH:mm:ss");
                    ((Excel.Range)xlSheet.Cells[2, iRestCols]).Value2 = "Today: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }

                if (condition.Length > 0)
                {
                    Clipboard.SetDataObject((object)condition, false, 5, 10);
                    ((Excel.Range)xlSheet.Cells[3, iRestCols]).Select();
                    //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                ((Excel.Range)xlSheet.Cells[1, 1]).Select();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWiths);
                return bReturn;

            }
            catch (Exception ex)
            {
                String errorMessage = "";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                MPCF.ShowMsgBox(errorMessage, "Error [" + ex.Source + "]", MessageBoxButtons.OK, 1);
                bReturn = false;
                return bReturn;
            }
            finally
            {
                // 사용자에게 저장 여부를 묻는다.
                xlBook.Saved = false;

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks);

                if (bReturn == false)
                {
                    //Make Excel application close.
                    xlApp.DisplayAlerts = false;
                    //xlBook.Saved = true;
                    xlApp.Quit();
                }
                else
                {
                    // 모든 엑셀의 경고메시지가 나타나도록 한다.
                    xlApp.DisplayAlerts = true;
                    //Make Excel visible and give the user control.
                    xlApp.Visible = true;
                    xlApp.UserControl = true;
                }

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                GC.Collect();
                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }

        }


        // Print()
        //       - Export Data of Control to Print
        // Return Value
        //       - True or False
        public static bool Print(System.Windows.Forms.Control ctlObject,
                            string sTitle, string sCondition,
                            bool bColorFlag, bool bTextBase, bool bShowDate,
                            int iStartCol, int iEndCol, int iRowHeight,
                            bool bOnlyData, float[] pageOptions, bool bMergeCells)
        {
            string TempFile = "";

            try
            {
                // Export excel title.
                if (sTitle == null)
                {
                    sTitle = "##";
                }
                else
                {
                    // Invalide Sheet name replace(/,?,*,[,])
                    sTitle = sTitle.Trim().Replace("/", "").Replace("?", "").Replace("*", "").Replace("[", "").Replace("]", "");
                    if (sTitle.Length > 30)
                    {
                        sTitle = sTitle.Substring(0, 30);
                    }
                }

                // Export excel condition.
                if (sCondition == null)
                {
                    sCondition = " ";
                }

                // Export excel data.
                if (ctlObject is ListView)
                {
                    // ListView를 기준으로 그래프가 상위/하위에 있는지를 구분함.
                    //imagePosition = 1; // 1:Top  2:Bottom

                    if (((ListView)ctlObject).Items.Count > 0)
                    {
                        return ListviewToExcel(new ListView[] { (ListView)ctlObject },
                                TempFile, 0,
                                sTitle, sCondition,
                                bColorFlag, bTextBase, bShowDate);
                    }
                }
                else if (ctlObject is FarPoint.Win.Spread.FpSpread)
                {
                    // FpSpread를 기준으로 그래프가 상위/하위에 있는지를 구분함.
                    //imagePosition = 1; // 1:Top  2:Bottom

                    if (((FarPoint.Win.Spread.FpSpread)ctlObject).ActiveSheet.RowCount > 0)
                    {
                        return SpreadSheetToPrint(new FarPoint.Win.Spread.SheetView[] { ((FarPoint.Win.Spread.FpSpread)ctlObject).ActiveSheet },
                               TempFile, 0,
                               sTitle, sCondition,
                               bColorFlag, bTextBase, bShowDate,
                               iStartCol, iEndCol, iRowHeight, false, pageOptions, bMergeCells);
                    }
                }
                else
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(11), "Error", MessageBoxButtons.OK, 1);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message, "Error", MessageBoxButtons.OK, 1);
            }
            finally
            {

            }


            return false;

        }

        // SpreadSheetToExcel()
        //       - Export Data of Spread Sheet Control to Excel Application Data
        // Return Value
        //       - True or False
        // Arguments
        //       - ByRef l_control As Spread Sheet
        //       - ByVal title As string
        //       - Optional ByVal Condition As string
        //       - Optional ByVal ColorFlag As Boolean
        //       - Optional ByVal bTextBase As Boolean    '
        //
        public static bool SpreadSheetToExcel(FarPoint.Win.Spread.SheetView actSheet, string imageFile, int imagePostion,
                string title, string condition, bool colorFlag, bool bTextBase, bool bShowDate, int iStartCol, int iEndCol)
        {

            Excel.Application XApp = new Excel.Application();
            Excel.Workbooks XBooks = XApp.Workbooks;
            Excel.Workbook XBook = XBooks.Add(XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet XSheet = (Excel.Worksheet)XBook.ActiveSheet;
            Excel.Range xWiths;

            //Excel.Application XApp;
            //Excel._Workbook XBook;
            //Excel._Worksheet XSheet;
            //Excel.Range xWiths;

            Int32 i, j, k;
            int[] aColumns = null;
            int iRestRows, iRestCols, iColumnCnt;
            string clipboardData;
            bool bAddColumn;

            try
            {
                int iRowHeaderCount, iColHeaderCount;

                //XApp = new Excel.Application();
                //XBook = (Excel._Workbook)(XApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet));
                //XSheet = (Excel._Worksheet)XBook.ActiveSheet;

                //XApp.Visible = false;
                //XApp.Visible = true;
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                if (title.Trim().Length > 30)
                {
                    XSheet.Name = title.TrimEnd().Substring(0, 30);
                }
                else
                {
                    XSheet.Name = title.TrimEnd();
                }

                // Start Row/Column reset.
                iRestRows = 3;
                iRestCols = 2;
                iColumnCnt = 0;

                if (actSheet.RowHeader.Visible == false || actSheet.RowHeader.ColumnCount <= 0)
                {
                    iRowHeaderCount = 0;
                }
                else
                {
                    iRowHeaderCount = actSheet.RowHeader.ColumnCount;
                }
                iColumnCnt = iRowHeaderCount;

                if (actSheet.ColumnHeader.Visible == false || actSheet.ColumnHeader.RowCount <= 0)
                {
                    iColHeaderCount = 0;
                }
                else
                {
                    iColHeaderCount = actSheet.ColumnHeader.RowCount;
                }


                //'지정한 컬럼만 Export 할 경우가 아닌 경우
                if (iStartCol < 0)
                {
                    iStartCol = 0;
                }

                if (iEndCol < 0)
                {
                    iEndCol = actSheet.ColumnCount;
                    if (iEndCol > XSheet.Columns.Count)
                    {
                        // Excel 최대 Column이면 시작 Column을 제외한다.
                        iEndCol = XSheet.Columns.Count - iRestCols;
                    }
                    iEndCol--;
                }

                // 데이터 조회조건에 대한 설명 또는 추가정보 설정.
                condition = condition.TrimEnd(new char[] { ' ', '\r', '\n' });
                if (condition.Length > 0)
                {
                    string[] sTempStr = condition.Split(new char[] { '\r', '\n' });
                    iRestRows += (sTempStr.Length + 1);
                }

                //lImage, int imagePostion,
                if (imageFile != null)
                {
                    int importRows = iRestRows;

                    if (imagePostion == 2) // Image is bottom.(이미지가 아래에 있으면,...)
                    {
                        importRows += actSheet.RowCount + iColHeaderCount + 1;
                    }

                    importRows = InsertImageToExcel((Excel._Worksheet)XSheet, imageFile, importRows, iRestCols);
                    if (imagePostion == 1 && importRows > 0) // Image is Top position.(이미지가 위에 있으면,...)
                    {
                        iRestRows += importRows + 1;
                    }
                }


                //First Column Width
                XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[XSheet.Rows.Count, 1]).EntireColumn.ColumnWidth = 0.5;
                XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[XSheet.Rows.Count, ExcelComponent.EXCEL_MAX_COL]).Font.Size = 10;

                //'셀서식을 TEXT로 인식하도록 한다.
                //'단, 셀 서식이 Text일 경우에는 셀 병합할 때 확인 창이 뜬다.
                if (bTextBase == true)
                {
                    XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[XSheet.Rows.Count, ExcelComponent.EXCEL_MAX_COL]).NumberFormat = "@";
                }


                for (i = iStartCol; i <= iEndCol; i++)
                {
                    if (actSheet.Columns[i].Width > 0 && actSheet.Columns[i].Visible == true)
                    {
                        bAddColumn = true;
                        for (j = 0; j < iColHeaderCount; j++)
                        {
                            if (actSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.ButtonCellType)
                            {
                                bAddColumn = false;
                                break;
                            }
                            else if (actSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.EmptyCellType)
                            {
                                bAddColumn = false;
                                break;
                            }
                            else if (actSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.ProgressCellType)
                            {
                                bAddColumn = false;
                                break;
                            }
                            else if (actSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.SliderCellType)
                            {
                                bAddColumn = false;
                                break;
                            }
                        }

                        if (bAddColumn == true)
                        {
                            if (aColumns == null)
                            {
                                aColumns = new int[iColumnCnt + 1];
                            }
                            else
                            {
                                int[] tempArray = new int[iColumnCnt];

                                Array.Copy(aColumns, tempArray, iColumnCnt);
                                aColumns = new int[iColumnCnt + 1];
                                Array.Copy(tempArray, aColumns, iColumnCnt);
                            }
                            aColumns[iColumnCnt] = i;
                            iColumnCnt++;
                        }
                    }
                }


                if (iColHeaderCount > 0)
                {
                    // Column Header name 및 Cell 서식 설정.
                    for (j = 0; j < iColHeaderCount; j++)
                    {
                        string thisHeader;
                        string[] sColumnHeader;

                        thisHeader = actSheet.ColumnHeader.GetClip(j, 0, 1, -1);
                        sColumnHeader = thisHeader.TrimEnd(new char[] { '\n', '\r' }).Split('\t');

                        clipboardData = "";
                        for (i = 0; i < iColumnCnt; i++)
                        {
                            if (iRowHeaderCount > i)
                            {
                                clipboardData += " " + "\t";
                            }
                            else
                            {
                                thisHeader = "";
                                if (aColumns[i] < sColumnHeader.Length)
                                {
                                    thisHeader = sColumnHeader[aColumns[i]];
                                }

                                clipboardData += thisHeader + "\t";
                                if (actSheet.ColumnHeader.Cells[j, aColumns[i]].ColumnSpan > 1)
                                {
                                    for (k = 0; k <= actSheet.ColumnHeader.Cells[j, aColumns[i]].ColumnSpan - 2; k++)
                                    {
                                        clipboardData += " " + "\t";
                                    }
                                    i += actSheet.ColumnHeader.Cells[j, aColumns[i]].ColumnSpan - 1;
                                }
                            }
                        }

                        clipboardData = clipboardData + "\n";
                        Clipboard.SetDataObject(clipboardData);
                        XSheet.get_Range("B" + System.Convert.ToString(iRestRows + j), Type.Missing).Select();
                        XSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }

                    XApp.DisplayAlerts = false;

                    // Column Heaer의 Merge를 설정.
                    for (j = 0; j < iColHeaderCount; j++)
                    {
                        for (k = 0; k < iColumnCnt; k++)
                        {
                            i = aColumns[k];
                            if (iRowHeaderCount > k)
                            {
                                k += iRowHeaderCount - 1;
                            }
                            else
                            {
                                if (actSheet.ColumnHeader.Cells[j, i].ColumnSpan > 1)
                                {
                                    xWiths = XSheet.get_Range(XSheet.Cells[j + iRestRows, k + iRestCols],
                                            XSheet.Cells[j + iRestRows, k + iRestCols + actSheet.ColumnHeader.Cells[j, i].ColumnSpan - 1]);
                                    //xWiths.Borders[XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                    xWiths.Select();
                                    xWiths.Merge(Type.Missing);

                                    k += actSheet.ColumnHeader.Cells[j, i].ColumnSpan - 1;
                                }

                                if (actSheet.ColumnHeader.Cells[j, i].RowSpan > 1)
                                {
                                    xWiths = XSheet.get_Range(XSheet.Cells[j + iRestRows, k + iRestCols],
                                            XSheet.Cells[j + iRestRows + actSheet.ColumnHeader.Cells[j, i].RowSpan - 1, k + iRestCols]);
                                    //xWiths.Borders[XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                    xWiths.Select();
                                    xWiths.Merge(Type.Missing);
                                }
                            }
                        }
                    }


                    // Column Header 에 대한 셀서식설정.
                    xWiths = XSheet.get_Range(XSheet.Cells[iRestRows, iRestCols], XSheet.Cells[iRestRows + iColHeaderCount - 1, iRestCols + iColumnCnt - 1]);
                    xWiths.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                    xWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                    xWiths.Interior.ColorIndex = 15;
                    xWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                    xWiths.Font.Bold = true;
                    xWiths.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xWiths.Borders[XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xWiths.Borders[XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xWiths.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    if (xWiths.Rows.Count > 1)
                    {
                        xWiths.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    }

                    if (xWiths.Columns.Count > 1)
                    {
                        xWiths.Borders[XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    }

                    // Data 시작 위치 재설정.
                    iRestRows += iColHeaderCount;
                }

                //if (sheet.RowHeader.Visible == true && sheet.RowHeader.ColumnCount > 0)
                if (iRowHeaderCount > 0)
                {
                    //'Row Header 셀서식
                    xWiths = XSheet.get_Range(XSheet.Cells[iRestRows, iRestCols], XSheet.Cells[iRestRows + actSheet.RowCount - 1, iRestCols + iRowHeaderCount - 1]);
                    xWiths.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                    xWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                    xWiths.Interior.ColorIndex = 15;
                    xWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                    xWiths.Font.Bold = true;
                    xWiths.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xWiths.Borders[XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xWiths.Borders[XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xWiths.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    if (xWiths.Rows.Count > 1)
                    {
                        xWiths.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    }
                }

                // Spread 에 대한 셀서식
                if (actSheet.RowCount > 0)
                {
                    xWiths = XSheet.get_Range(XSheet.Cells[iRestRows, iRestCols + iRowHeaderCount], XSheet.Cells[iRestRows + actSheet.RowCount - 1, iRestCols + iColumnCnt - 1]);
                    xWiths.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xWiths.Borders[XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    xWiths.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    if (xWiths.Columns.Count > 1)
                    {
                        xWiths.Borders[XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xWiths.Borders[XlBordersIndex.xlInsideVertical].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                    }

                    if (xWiths.Rows.Count > 1)
                    {
                        xWiths.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xWiths.Borders[XlBordersIndex.xlInsideHorizontal].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                    }
                }

                for (i = 0; i < actSheet.RowCount; i++)
                {
                    clipboardData = "";
                    for (j = 0; j < iColumnCnt; j++)
                    {
                        try
                        {
                            if (iRowHeaderCount > j)
                            {
                                clipboardData += actSheet.RowHeader.Cells[i, j].Text.Trim().Replace(" ", "").Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                            }
                            else
                            {
                                if (actSheet.Cells[i, aColumns[j]].Text.IndexOf("<") > 0 || actSheet.Cells[i, aColumns[j]].Text.IndexOf(">") > 0)
                                {
                                    clipboardData += actSheet.Cells[i, aColumns[j]].Text.Trim().Replace(" ", "").Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                }
                                else
                                {
                                    clipboardData += actSheet.Cells[i, aColumns[j]].Text.Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                }
                            }
                        }
                        catch
                        {
                            clipboardData += "\t";
                        }
                    }

                    clipboardData = clipboardData + "\n";
                    Clipboard.SetDataObject(clipboardData);
                    XSheet.get_Range("B" + System.Convert.ToString(iRestRows + i), Type.Missing).Select();
                    //XSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    XSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                // Column크기를 자동으로 조절.
                xWiths = XSheet.get_Range(XSheet.Cells[iRestRows - iColHeaderCount, iRestCols], XSheet.Cells[iRestRows + actSheet.RowCount - 1, iRestCols + iColumnCnt - 1]);
                xWiths.CurrentRegion.EntireColumn.AutoFit();

                if (colorFlag == true)
                {
                    for (i = 0; i < actSheet.RowCount; i++)
                    {
                        for (j = iStartCol; j <= iEndCol; j++)
                        {
                            if (actSheet.Cells[i, j].ForeColor.IsEmpty == false)
                            {
                                if (actSheet.Cells[i, j].ForeColor.ToArgb() != System.Drawing.Color.Black.ToArgb())
                                {
                                    XSheet.get_Range(XSheet.Cells[i + iRestRows, j + iRestCols + iRowHeaderCount], XSheet.Cells[i + iRestRows, j + iRestCols + iRowHeaderCount]).Font.Color =
                                        System.Drawing.ColorTranslator.ToOle(actSheet.Cells[i, j].ForeColor);
                                }
                            }

                            if (actSheet.Cells[i, j].BackColor.IsEmpty == false)
                            {
                                if (actSheet.Cells[i, j].BackColor.ToArgb() != System.Drawing.Color.White.ToArgb())
                                {
                                    XSheet.get_Range(XSheet.Cells[i + iRestRows, j + iRestCols + iRowHeaderCount], XSheet.Cells[i + iRestRows, j + iRestCols + iRowHeaderCount]).Interior.Color =
                                        System.Drawing.ColorTranslator.ToOle(actSheet.Cells[i, j].BackColor);
                                }
                            }
                        }
                    }

                }

                //'Title 에 대한 셀 서식 지정
                xWiths = XSheet.get_Range(XSheet.Cells[1, 2], XSheet.Cells[1, 2]);
                xWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter;
                xWiths.RowHeight = 30;
                xWiths.Font.Size = 12;
                xWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                xWiths.Font.Bold = true;
                xWiths.Font.Name = "Arail";
                ((Range)XSheet.Cells[1, 2]).Value2 = title;

                if (bShowDate == true)
                {
                    string sNowDate;
                    sNowDate = string.Format(Convert.ToString(DateTime.Now), "yyyy-MM-dd") + " " + string.Format(Convert.ToString(DateTime.Now), "HH:mm:ss");
                    ((Range)XSheet.Cells[2, 2]).Value2 = "\'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }

                if (condition.Length > 0)
                {
                    Clipboard.SetDataObject(condition);
                    ((Range)XSheet.Cells[3, 2]).Select();
                    XSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                XApp.DisplayAlerts = true;
                ((Range)XSheet.Cells[2, 2]).Select();
                XApp.Visible = true;

                return true;

            }
            catch (Exception ex)
            {
                //FwxCmnFunction.ShowMsgBox(ex.Message, "Error", MessageBoxButtons.OK, 1);
                MPCF.ShowMsgBox(ex.ToString(), "Error", MessageBoxButtons.OK, 1);
                return false;
            }
            finally
            {

                System.Runtime.InteropServices.Marshal.ReleaseComObject(XSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XBooks);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XApp);
                GC.Collect();
                System.Windows.Forms.Cursor.Current = Cursors.Default;

            }

        }

        // SpreadSheetToExcel()
        //       - Export Data of Spread Sheet Control to Excel Application Data
        // Return Value
        //       - True or False
        private static bool SpreadSheetToExcel(FarPoint.Win.Spread.SheetView[] xSheet,
                string imageFile, int imagePostion,
                string title, string condition,
                bool colorFlag, bool bTextBase, bool bShowDate,
                int iStartCol, int iEndCol, int iRowHeight,
                bool bOnlyData, float[] pageOptions, bool bMergeRows)
        {

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks xlBooks = xlApp.Workbooks;
            Excel.Workbook xlBook = xlBooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.ActiveSheet;
            Excel.Range xlWiths;


            Int32 i, j, k, y;
            int startColumn, endColumn;
            int[] aColumns = null;
            int iRestRows, iRestCols, iColumnCnt;
            int pastColumn, pastColumnCount, pastColumnIdx;
            string clipboardData;
            bool bAddColumn, bReturn = true;


            try
            {
                int iRowHeaderCount, iColHeaderCount;

                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                // Sheet Naet init.
                if (title.Length > 0)
                {
                    string sheetTile = "";
                    sheetTile = title.Replace(" ", "").Replace(":", ".").Replace("?", ".").Replace("*", ".").Replace("[", ".").Replace("]", ".").Replace("<", ".").Replace(">", ".");
                    xlSheet.Name = sheetTile;
                }

                // Start Row/Column reset init.
                iColumnCnt = 0;
                iRowHeaderCount = 0;
                iColHeaderCount = 0;
                startColumn = 0;
                endColumn = 0;
                // Spread Data만 Export할 경우 Row/Column Header를 표시하지 않음.
                if (bOnlyData)
                {
                    iRestRows = EXCEL_FIRST_ROWCOL;
                    iRestCols = EXCEL_FIRST_ROWCOL;
                }
                else
                {
                    iRestRows = EXCEL_START_ROW;
                    iRestCols = EXCEL_START_COL;
                }

                // Spread Data만 Export할 경우 Image를 표시하지 않음.
                if (bOnlyData == false)
                {
                    // 데이터 조회조건에 대한 설명 또는 추가정보 설정.
                    condition = condition.TrimEnd(new char[] { ' ', '\r', '\n' });
                    if (condition.Length > 0)
                    {
                        string[] sTempStr = condition.Split(new char[] { '\r', '\n' });
                        iRestRows += (sTempStr.Length + 1);
                    }
                }

                //First Column Font/Width init.
                xlSheet.Cells.Select();
                xlSheet.Cells.EntireColumn.ColumnWidth = 1;
                xlSheet.Cells.Font.Name = "Tahoma";
                xlSheet.Cells.Font.Size = 10;
                ////  텍스트가 사용 가능한 열 너비에 맞게 자동으로 축소 여부.
                //xlSheet.Cells.ShrinkToFit = true;

                // 이미지가 상단에 위치할 경우(만약, imagePostion == 0이면 이미지를 표시하지 않음)
                // Spread Data만 Export할 경우 Image를 표시하지 않음.
                if (bOnlyData == false && imageFile != null && imagePostion == 1)
                {
                    int importRows = iRestRows;

                    importRows = InsertImageToExcel((Excel._Worksheet)xlSheet, imageFile, importRows, iRestCols);
                    if (importRows > 0) // Image is Top position.
                    {
                        iRestRows += importRows + 2;
                    }
                }

                // 각종 엑셀의 경고메시지를 보이지 않도록 합니다.
                xlApp.DisplayAlerts = false;

                // 셀서식을 TEXT로 인식하도록 한다.
                // 단, 셀 서식이 Text일 경우에는 셀 병합할 때 확인 창이 뜬다.
                if (bTextBase == true)
                {
                    xlSheet.Cells.NumberFormat = "@";
                }

                if (xSheet != null)
                {
                    // 여러장의 분할된 Sread Sheet를 하나의 Excel에 붙여넣음.
                    foreach (FarPoint.Win.Spread.SheetView activeSheet in xSheet)
                    {
                        if (activeSheet.RowCount <= 0)
                        {
                            continue;
                        }

                        // Row Header count.
                        if (activeSheet.RowHeader.Visible == false || activeSheet.RowHeader.ColumnCount <= 0)
                        {
                            iRowHeaderCount = 0;
                        }
                        else
                        {
                            iRowHeaderCount = activeSheet.RowHeader.ColumnCount;
                        }

                        // Column Header count.
                        if (activeSheet.ColumnHeader.Visible == false || activeSheet.ColumnHeader.RowCount <= 0)
                        {
                            iColHeaderCount = 0;
                        }
                        else
                        {
                            iColHeaderCount = activeSheet.ColumnHeader.RowCount;
                        }

                        // 지정한 컬럼만 Export 할 경우가 아닌 경우
                        if (iStartCol < 0)
                        {
                            startColumn = 0;
                        }

                        if (iEndCol < 0)
                        {
                            endColumn = activeSheet.ColumnCount;
                            if (endColumn > xlSheet.Columns.Count)
                            {
                                // Excel 최대 Column이면 시작 Column을 제외한다.
                                endColumn = xlSheet.Columns.Count - iRestCols;
                            }
                        }

                        // Export target cell column number.(저장 대상 셀을 찾는다.)
                        iColumnCnt = 0;
                        for (i = startColumn; i < endColumn; i++)
                        {
                            if (activeSheet.Columns[i].Width > 0 && activeSheet.Columns[i].Visible == true)
                            {
                                bAddColumn = true;
                                for (j = 0; j < iColHeaderCount; j++)
                                {
                                    if (activeSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.ButtonCellType)
                                    {
                                        bAddColumn = false;
                                        break;
                                    }
                                    else if (activeSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.EmptyCellType)
                                    {
                                        bAddColumn = false;
                                        break;
                                    }
                                    else if (activeSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.ProgressCellType)
                                    {
                                        bAddColumn = false;
                                        break;
                                    }
                                    else if (activeSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.SliderCellType)
                                    {
                                        bAddColumn = false;
                                        break;
                                    }
                                }

                                if (bAddColumn == true)
                                {
                                    if (aColumns == null)
                                    {
                                        aColumns = new int[iColumnCnt + 1];
                                    }
                                    else
                                    {
                                        int[] tempArray = new int[iColumnCnt];

                                        Array.Copy(aColumns, tempArray, iColumnCnt);
                                        aColumns = new int[iColumnCnt + 1];
                                        Array.Copy(tempArray, aColumns, iColumnCnt);
                                    }
                                    aColumns[iColumnCnt] = i;
                                    iColumnCnt++;
                                }
                            }
                        }

                        // Spread Data만 Export할 경우 Row/Column Header를 표시하지 않음.
                        if (bOnlyData == false && iColHeaderCount > 0)
                        {
                            int spanCount; // Row/Column span count.

                            // Column Header name 및 Cell 서식 설정.
                            for (j = 0; j < iColHeaderCount; j++)
                            {
                                string thisHeader;
                                string[] sColumnHeader;

                                thisHeader = activeSheet.ColumnHeader.GetClip(j, 0, 1, -1);
                                sColumnHeader = thisHeader.TrimEnd(new char[] { '\n', '\r' }).Split('\t');

                                clipboardData = "";
                                for (i = 0; i < iColumnCnt; i++)
                                {
                                    thisHeader = "";
                                    if (aColumns[i] < sColumnHeader.Length)
                                    {
                                        thisHeader = sColumnHeader[aColumns[i]];
                                    }

                                    clipboardData += thisHeader + "\t";
                                    spanCount = activeSheet.ColumnHeader.Cells[j, aColumns[i]].ColumnSpan;
                                    if (spanCount > 1)
                                    {
                                        /* Added By YJJung */
                                        for (y = i; y < i + spanCount; y++)
                                        {
                                            if (activeSheet.Columns[y].Visible == false)
                                            {
                                                spanCount = spanCount - 1;
                                            }
                                        }
                                        /* Added End */
                                        for (k = 0; k <= (spanCount - 2); k++)
                                        {
                                            clipboardData += " " + "\t";
                                        }
                                        i += spanCount - 1;
                                    }
                                }

                                clipboardData = clipboardData + "\n";
                                Clipboard.SetDataObject((object)clipboardData, false, 5, 10);
                                ((Excel.Range)xlSheet.Cells[(iRestRows + j), (iRestCols + iRowHeaderCount)]).Select();
                                //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                                xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            }


                            // Column Heaer의 Merge를 설정.
                            for (j = 0; j < iColHeaderCount; j++)
                            {
                                for (k = 0; k < iColumnCnt; k++)
                                {
                                    i = aColumns[k];
                                    if (iRowHeaderCount > k)
                                    {
                                        k += iRowHeaderCount - 1;
                                    }
                                    else
                                    {

                                        spanCount = activeSheet.ColumnHeader.Cells[j, i].ColumnSpan;

                                        if (spanCount > 1)
                                        {
                                            /* Added By YJJung */
                                            for (y = i; y < i + spanCount; y++)
                                            {
                                                if (activeSheet.Columns[y].Visible == false)
                                                {
                                                    spanCount = spanCount - 1;
                                                }
                                            }
                                            /* Added End */
                                            xlWiths = xlSheet.get_Range(xlSheet.Cells[j + iRestRows, k + iRestCols],
                                                    xlSheet.Cells[j + iRestRows, k + iRestCols + spanCount - 1]);
                                            //xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                            xlWiths.Select();
                                            xlWiths.Merge(Type.Missing);

                                            k += spanCount - 1;
                                        }

                                        spanCount = activeSheet.ColumnHeader.Cells[j, i].RowSpan;
                                        if (spanCount > 1 && spanCount <= (iColHeaderCount - j))
                                        {
                                            xlWiths = xlSheet.get_Range(xlSheet.Cells[j + iRestRows, k + iRestCols],
                                                    xlSheet.Cells[j + iRestRows + spanCount - 1, k + iRestCols]);
                                            //xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                            xlWiths.Select();
                                            xlWiths.Merge(Type.Missing);
                                        }
                                    }
                                }
                            }


                            // Column Header 에 대한 셀서식설정.
                            xlWiths = xlSheet.get_Range(xlSheet.Cells[iRestRows, iRestCols], xlSheet.Cells[iRestRows + iColHeaderCount - 1, iRestCols + iRowHeaderCount + iColumnCnt - 1]);
                            xlWiths.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                            xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                            xlWiths.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue);
                            xlWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                            xlWiths.Font.Bold = true;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            if (xlWiths.Rows.Count > 1)
                            {
                                xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            }

                            if (xlWiths.Columns.Count > 1)
                            {
                                xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            }

                            // Data 시작 위치 재설정.
                            iRestRows += iColHeaderCount;
                        }

                        #region Set RowHeader/Rows cell formula.
                        // Set RowHeaders cell formula.
                        if (iRowHeaderCount > 0)
                        {
                            int spanCount, skipColumn; // Row/Column span count.
                            string rowLavel;

                            // Row Header의 Merge를 설정.
                            for (j = 0; j < activeSheet.RowCount; j++)
                            {
                                for (k = 0; k < iRowHeaderCount; k++)
                                {
                                    skipColumn = 0;
                                    // Set Row Header Text.
                                    rowLavel = activeSheet.GetRowLabel(j, k).ToString().Trim();
                                    ((Excel.Range)xlSheet.Cells[j + iRestRows, k + iRestCols]).Value2 = rowLavel;

                                    spanCount = activeSheet.RowHeader.Cells[j, k].ColumnSpan;
                                    if (spanCount > 1 && spanCount <= (iRowHeaderCount - k))
                                    {
                                        xlWiths = xlSheet.get_Range(xlSheet.Cells[j + iRestRows, k + iRestCols],
                                                xlSheet.Cells[j + iRestRows, k + iRestCols + spanCount - 1]);
                                        //xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                        xlWiths.Select();
                                        xlWiths.Merge(Type.Missing);

                                        skipColumn = spanCount - 1;
                                    }

                                    spanCount = activeSheet.RowHeader.Cells[j, k].RowSpan;
                                    if (spanCount > 1)
                                    {
                                        xlWiths = xlSheet.get_Range(xlSheet.Cells[j + iRestRows, k + iRestCols],
                                                xlSheet.Cells[j + iRestRows + spanCount - 1, k + iRestCols]);
                                        //xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                        xlWiths.Select();
                                        xlWiths.Merge(Type.Missing);
                                    }

                                    k += skipColumn;
                                }
                            }

                            //'Row Header 셀서식
                            xlWiths = xlSheet.get_Range(xlSheet.Cells[iRestRows, iRestCols], xlSheet.Cells[iRestRows + activeSheet.RowCount - 1, iRestCols + iRowHeaderCount - 1]);
                            xlWiths.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                            xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                            xlWiths.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue);
                            xlWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                            xlWiths.Font.Bold = true;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            if (xlWiths.Rows.Count > 1)
                            {
                                xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            }

                            if (xlWiths.Columns.Count > 1)
                            {
                                xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            }

                            // Data Start Column position reset.
                            //iRestCols += iRowHeaderCount;
                        }

                        // Set Rows cell formula.
                        if (activeSheet.RowCount > 0)
                        {
                            xlWiths = xlSheet.get_Range(xlSheet.Cells[iRestRows, iRestCols + iRowHeaderCount], xlSheet.Cells[iRestRows + activeSheet.RowCount - 1, iRestCols + iRowHeaderCount + iColumnCnt - 1]);
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            if (xlWiths.Columns.Count > 1)
                            {
                                xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                            }

                            if (xlWiths.Rows.Count > 1)
                            {
                                xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                            }
                        }
                        #endregion

                        #region Get Spread all values.(Hidden column skip).
                        pastColumn = 0;
                        pastColumnCount = 0;
                        pastColumnIdx = iRestCols + iRowHeaderCount;
                        for (i = 0; i < iColumnCnt; i++)
                        {
                            if (aColumns[i] == (pastColumn + pastColumnCount))
                            {
                                pastColumnCount++;
                                continue;
                            }
                            else
                            {
                                if (pastColumnCount > 0)
                                {
                                    clipboardData = activeSheet.GetClip(0, pastColumn, -1, pastColumnCount);
                                    Clipboard.SetDataObject((object)clipboardData, false, 5, 10);
                                    ((Excel.Range)xlSheet.Cells[iRestRows, pastColumnIdx]).Select();
                                    //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                                    xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                                    pastColumnIdx += pastColumnCount;
                                }

                                pastColumn = aColumns[i];
                                pastColumnCount = 1;
                            }
                        }

                        if (pastColumnCount > 0)
                        {
                            clipboardData = activeSheet.GetClip(0, pastColumn, -1, pastColumnCount);
                            Clipboard.SetDataObject((object)clipboardData, false, 5, 10);
                            ((Excel.Range)xlSheet.Cells[iRestRows, pastColumnIdx]).Select();
                            //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }

                        // Column크기를 자동으로 조절(Row and Column header).
                        xlWiths = xlSheet.get_Range(xlSheet.Cells[(iRestRows - iColHeaderCount > 0 ? iRestRows - iColHeaderCount : iRestRows), iRestCols],
                                    xlSheet.Cells[iRestRows + activeSheet.RowCount - 1, iRestCols + iRowHeaderCount + iColumnCnt - 1]);
                        xlWiths.EntireColumn.AutoFit();
                        // Row 크기를 조절.
                        if (iRowHeight > 0)
                        {
                            //Keep the minimum row height to 13.
                            if (iRowHeight < 13)
                            {
                                iRowHeight = 13;
                            }
                            xlWiths.EntireRow.RowHeight = iRowHeight;
                        }
                        #endregion

                        // 각 Column의 Background/ForeColor를 설정함.
                        if (colorFlag == true)
                        {
                            for (i = 0; i < activeSheet.RowCount; i++)
                            {
                                for (j = startColumn; j < endColumn; j++)
                                {
                                    if (activeSheet.Cells[i, j].ForeColor.IsEmpty == false)
                                    {
                                        if (activeSheet.Cells[i, j].ForeColor.ToArgb() != System.Drawing.Color.Black.ToArgb())
                                        {
                                            ((Excel.Range)xlSheet.Cells[i + iRestRows, j + iRestCols + iRowHeaderCount]).Font.Color =
                                                System.Drawing.ColorTranslator.ToOle(activeSheet.Cells[i, j].ForeColor);
                                        }
                                    }

                                    if (activeSheet.Cells[i, j].BackColor.IsEmpty == false)
                                    {
                                        if (activeSheet.Cells[i, j].BackColor.ToArgb() != System.Drawing.Color.White.ToArgb())
                                        {
                                            ((Excel.Range)xlSheet.Cells[i + iRestRows, j + iRestCols + iRowHeaderCount]).Interior.Color =
                                                System.Drawing.ColorTranslator.ToOle(activeSheet.Cells[i, j].BackColor);
                                        }
                                    }
                                }
                            }
                        }

                        /* Added by YJJUng for all of merged rows */
                        if (bMergeRows == true)
                        {
                            string curStr;
                            int spanCount;
                            int spanStart;
                            spanCount = 0;
                            spanStart = 0;
                            curStr = "";
                            for (j = startColumn; j < endColumn; j++)
                            {
                                if (activeSheet.Columns[j].Visible == true)
                                {
                                    for (i = 0; i < activeSheet.RowCount; i++)
                                    {

                                        if (i == 0)
                                        {
                                            curStr = (string)activeSheet.Cells[i, j].Value;
                                            spanCount = 0;
                                            spanStart = 0;
                                        }

                                        if (curStr != (string)activeSheet.Cells[i, j].Value && spanCount > 0)
                                        {
                                            //spanCount++;
                                            curStr = (string)activeSheet.Cells[i, j].Value;
                                            //spanCount = activeSheet.Cells[i, j].RowSpan;

                                            xlWiths = xlSheet.get_Range(xlSheet.Cells[spanStart + iRestRows, j + 1],
                                                       xlSheet.Cells[spanStart + iRestRows + spanCount - 1, j + 1]);

                                            xlWiths.Select();
                                            xlWiths.Merge(Type.Missing);
                                            xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignTop;
                                            spanStart = i;
                                            spanCount = 1;
                                        }
                                        else if (curStr == (string)activeSheet.Cells[i, j].Value && i == activeSheet.RowCount - 1)
                                        {
                                            //xlWiths.EntireRow.AutoFit();
                                            xlWiths = xlSheet.get_Range(xlSheet.Cells[spanStart + iRestRows, j + 1],
                                                       xlSheet.Cells[spanStart + iRestRows + spanCount, j + 1]);

                                            xlWiths.Select();
                                            xlWiths.Merge(Type.Missing);
                                            xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignTop;
                                            spanCount = 1;
                                        }
                                        else
                                        {
                                            spanCount++;
                                        }
                                    }
                                }
                            }
                        }
                        /* Added End */
                        iRestRows += activeSheet.RowCount;
                        // 데이터만 export(bOnlyData == true)할 경우엔 Spread별로 구분하는 Row를 넣지 않음.
                        if (bOnlyData == false)
                        {
                            iRestRows++;
                        }
                    }
                }

                // Spread Data만 Export할 경우 Page Setup.
                if (pageOptions != null && pageOptions.Length == 12)
                {
                    InsertPrintOption(xlSheet, pageOptions);
                }

                // Spread Data만 Export할 경우 Title, Row/Column Header, Conditions, Current Date를 표시하지 않음.
                if (bOnlyData == false)
                {
                    // Title 에 대한 셀 서식 지정
                    xlWiths = xlSheet.get_Range(xlSheet.Cells[1, iRestCols], xlSheet.Cells[1, iRestCols]);
                    xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignTop;
                    xlWiths.RowHeight = 30;
                    xlWiths.Font.Size = 18;
                    xlWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                    xlWiths.Font.Bold = true;
                    ((Excel.Range)xlSheet.Cells[1, iRestCols]).Value2 = title;

                    // Current Date/Time표시 유무.
                    if (bShowDate == true)
                    {
                        string sNowDate;
                        sNowDate = string.Format(Convert.ToString(DateTime.Now), "yyyy-MM-dd") + " " + string.Format(Convert.ToString(DateTime.Now), "HH:mm:ss");
                        ((Excel.Range)xlSheet.Cells[2, iRestCols]).Value2 = "Today: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    //'조회조건에 값
                    if (condition.Length > 0)
                    {
                        Clipboard.SetDataObject((object)condition, false, 5, 10);
                        ((Excel.Range)xlSheet.Cells[3, iRestCols]).Select();
                        //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }

                    // 이미지가 하단에 위치할 경우,..
                    if (imageFile != null && imagePostion > 1)
                    {
                        int importRows = iRestRows + 1;

                        importRows = InsertImageToExcel((Excel._Worksheet)xlSheet, imageFile, importRows, iRestCols);
                    }
                }
                else
                {
                    // Set Excel file name.
                    xlBook.Saved = true;
                    xlBook.SaveAs(xlSheet.Name, Excel.XlFileFormat.xlWorkbookNormal,
                            Type.Missing, Type.Missing, true, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                // Set cursor position.
                ((Excel.Range)xlSheet.Cells[1, 1]).Select();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWiths);
                return bReturn;

            }
            catch (Exception ex)
            {
                String errorMessage = "";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                MPCF.ShowMsgBox(errorMessage, "Error [" + ex.Source + "]", MessageBoxButtons.OK, 1);
                bReturn = false;
                return bReturn;
            }
            finally
            {
                // 사용자에게 저장 여부를 묻는다.
                xlBook.Saved = false;

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks);

                if (bReturn == false)
                {
                    //Make Excel application close.
                    xlApp.DisplayAlerts = false;
                    //xlBook.Saved = true;
                    xlApp.Quit();
                }
                else
                {
                    // 모든 엑셀의 경고메시지가 나타나도록 한다.
                    xlApp.DisplayAlerts = true;
                    //Make Excel visible and give the user control.
                    xlApp.Visible = true;
                    xlApp.UserControl = true;
                }

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                GC.Collect();
                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }

        }

        /// <summary>
        /// Excel에 이미지(그래프)를 넣어서 export한다.
        /// </summary>
        /// <param name="xSheet">Microsoft.Office.Interop.Excel.Worksheet </param>
        /// <param name="imagefile">Image file name</param>
        /// <param name="row">Excel Sheet image row number</param>
        /// <param name="column">Excel Sheet image column number</param>
        /// <returns>이미지 크기에 따른 이미지의 마지막 Row number</returns>
        private static int InsertImageToExcel(Excel._Worksheet xSheet, string imagefile, int row, int column)
        {
            Excel.Range xlWiths;
            Excel.Pictures xPics;
            Excel.Picture xPicture;
            int nHightRow;

            try
            {
                //create some pictures
                xPics = (Excel.Pictures)xSheet.Pictures(Type.Missing);
                xPics.Insert(imagefile, Type.Missing);
                xPicture = (Excel.Picture)xPics.Item(1);

                //set the position of the pics
                xlWiths = (Excel.Range)xSheet.Cells[row, column];
                xPicture.Left = (double)xlWiths.Left;
                xPicture.Top = (double)xlWiths.Top;
                // 이미지의 폭/높이는 변경하지 않음.
                //xPic01.Height = (double)xlWiths.Height;
                //xPic01.Width = (double)xlWiths.Width;

                // 이미즈의 폭에 따른 컬럼(Column)의 계산이 컬럼의 크기 기준값이 달라 계산되지 않으므로,
                // 계산하지 않고, 이미지의 높이에 따른 로우(Row)의 크기만 계산.
                if (xPicture.Height <= (double)xlWiths.Height)
                {
                    nHightRow = row + 1;
                }
                else if ((double)xlWiths.Height <= 0)
                {
                    nHightRow = (int)xPicture.Height;
                }
                else
                {
                    nHightRow = (int)(xPicture.Height / (double)xlWiths.Height) + 1;
                    if (nHightRow > xSheet.Rows.Count)
                    {
                        nHightRow = (int)xPicture.Height;
                    }
                }

                return nHightRow;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message, "Error", MessageBoxButtons.OK, 1);
                return -1;
            }
        }

        // SpreadSheetToPrint()
        //       - Export Data of Spread Sheet Control to Printer
        // Return Value
        //       - True or False
        //
        private static bool SpreadSheetToPrint(FarPoint.Win.Spread.SheetView[] xSheet,
               string imageFile, int imagePostion,
                string title, string condition,
                bool colorFlag, bool bTextBase, bool bShowDate,
                int iStartCol, int iEndCol, int iRowHeight,
                bool bOnlyData, float[] pageOptions, bool bMergeRows)
        {

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks xlBooks = xlApp.Workbooks;
            Excel.Workbook xlBook = xlBooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.ActiveSheet;
            Excel.Range xlWiths;


            Int32 i, j, k, y;
            int startColumn, endColumn;
            int[] aColumns = null;
            int iRestRows, iRestCols, iColumnCnt;
            int pastColumn, pastColumnCount, pastColumnIdx;
            string clipboardData;
            bool bAddColumn, bReturn = true;


            try
            {
                int iRowHeaderCount, iColHeaderCount;

                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                xlApp.Visible = false;
                // Sheet Naet init.
                if (title.Length > 0)
                {
                    string sheetTile = "";
                    sheetTile = title.Replace(" ", "").Replace(":", ".").Replace("?", ".").Replace("*", ".").Replace("[", ".").Replace("]", ".").Replace("<", ".").Replace(">", ".");
                    xlSheet.Name = sheetTile;
                }

                // Start Row/Column reset init.
                iColumnCnt = 0;
                iRowHeaderCount = 0;
                iColHeaderCount = 0;
                startColumn = 0;
                endColumn = 0;
                // Spread Data만 Export할 경우 Row/Column Header를 표시하지 않음.
                if (bOnlyData)
                {
                    iRestRows = EXCEL_FIRST_ROWCOL;
                    iRestCols = EXCEL_FIRST_ROWCOL;
                }
                else
                {
                    iRestRows = EXCEL_START_ROW;
                    iRestCols = EXCEL_START_COL;
                }

                // Spread Data만 Export할 경우 Image를 표시하지 않음.
                if (bOnlyData == false)
                {
                    // 데이터 조회조건에 대한 설명 또는 추가정보 설정.
                    condition = condition.TrimEnd(new char[] { ' ', '\r', '\n' });
                    if (condition.Length > 0)
                    {
                        string[] sTempStr = condition.Split(new char[] { '\r', '\n' });
                        iRestRows += (sTempStr.Length + 1);
                    }
                }

                //First Column Font/Width init.
                xlSheet.Cells.Select();
                xlSheet.Cells.EntireColumn.ColumnWidth = 1;
                xlSheet.Cells.Font.Name = "Tahoma";
                xlSheet.Cells.Font.Size = 10;

                ////  텍스트가 사용 가능한 열 너비에 맞게 자동으로 축소 여부.
                //xlSheet.Cells.ShrinkToFit = true;

                // 이미지가 상단에 위치할 경우(만약, imagePostion == 0이면 이미지를 표시하지 않음)
                // Spread Data만 Export할 경우 Image를 표시하지 않음.
                if (bOnlyData == false && imageFile != null && imagePostion == 1)
                {
                    int importRows = iRestRows;

                    importRows = InsertImageToExcel((Excel._Worksheet)xlSheet, imageFile, importRows, iRestCols);
                    if (importRows > 0) // Image is Top position.
                    {
                        iRestRows += importRows + 2;
                    }
                }

                // 각종 엑셀의 경고메시지를 보이지 않도록 합니다.
                xlApp.DisplayAlerts = false;

                // 셀서식을 TEXT로 인식하도록 한다.
                // 단, 셀 서식이 Text일 경우에는 셀 병합할 때 확인 창이 뜬다.
                if (bTextBase == true)
                {
                    xlSheet.Cells.NumberFormat = "@";
                }


                // 여러장의 분할된 Sread Sheet를 하나의 Excel에 붙여넣음.
                foreach (FarPoint.Win.Spread.SheetView activeSheet in xSheet)
                {
                    if (activeSheet.RowCount <= 0)
                    {
                        continue;
                    }

                    // Row Header count.
                    if (activeSheet.RowHeader.Visible == false || activeSheet.RowHeader.ColumnCount <= 0)
                    {
                        iRowHeaderCount = 0;
                    }
                    else
                    {
                        iRowHeaderCount = activeSheet.RowHeader.ColumnCount;
                    }

                    // Column Header count.
                    if (activeSheet.ColumnHeader.Visible == false || activeSheet.ColumnHeader.RowCount <= 0)
                    {
                        iColHeaderCount = 0;
                    }
                    else
                    {
                        iColHeaderCount = activeSheet.ColumnHeader.RowCount;
                    }

                    // 지정한 컬럼만 Export 할 경우가 아닌 경우
                    if (iStartCol < 0)
                    {
                        startColumn = 0;
                    }

                    if (iEndCol < 0)
                    {
                        endColumn = activeSheet.ColumnCount;
                        if (endColumn > xlSheet.Columns.Count)
                        {
                            // Excel 최대 Column이면 시작 Column을 제외한다.
                            endColumn = xlSheet.Columns.Count - iRestCols;
                        }
                    }

                    // Export target cell column number.(저장 대상 셀을 찾는다.)
                    iColumnCnt = 0;
                    for (i = startColumn; i < endColumn; i++)
                    {
                        if (activeSheet.Columns[i].Width > 0 && activeSheet.Columns[i].Visible == true)
                        {
                            bAddColumn = true;
                            for (j = 0; j < iColHeaderCount; j++)
                            {
                                if (activeSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.ButtonCellType)
                                {
                                    bAddColumn = false;
                                    break;
                                }
                                else if (activeSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.EmptyCellType)
                                {
                                    bAddColumn = false;
                                    break;
                                }
                                else if (activeSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.ProgressCellType)
                                {
                                    bAddColumn = false;
                                    break;
                                }
                                else if (activeSheet.ColumnHeader.Cells[j, i].CellType is FarPoint.Win.Spread.CellType.SliderCellType)
                                {
                                    bAddColumn = false;
                                    break;
                                }
                            }

                            if (bAddColumn == true)
                            {
                                if (aColumns == null)
                                {
                                    aColumns = new int[iColumnCnt + 1];
                                }
                                else
                                {
                                    int[] tempArray = new int[iColumnCnt];

                                    Array.Copy(aColumns, tempArray, iColumnCnt);
                                    aColumns = new int[iColumnCnt + 1];
                                    Array.Copy(tempArray, aColumns, iColumnCnt);
                                }
                                aColumns[iColumnCnt] = i;
                                iColumnCnt++;
                            }
                        }
                    }

                    // Spread Data만 Export할 경우 Row/Column Header를 표시하지 않음.
                    if (bOnlyData == false && iColHeaderCount > 0)
                    {
                        int spanCount; // Row/Column span count.

                        // Column Header name 및 Cell 서식 설정.
                        for (j = 0; j < iColHeaderCount; j++)
                        {
                            string thisHeader;
                            string[] sColumnHeader;

                            thisHeader = activeSheet.ColumnHeader.GetClip(j, 0, 1, -1);
                            sColumnHeader = thisHeader.TrimEnd(new char[] { '\n', '\r' }).Split('\t');

                            clipboardData = "";
                            for (i = 0; i < iColumnCnt; i++)
                            {
                                thisHeader = "";
                                if (aColumns[i] < sColumnHeader.Length)
                                {
                                    thisHeader = sColumnHeader[aColumns[i]];
                                }

                                clipboardData += thisHeader + "\t";
                                spanCount = activeSheet.ColumnHeader.Cells[j, aColumns[i]].ColumnSpan;
                                if (spanCount > 1)
                                {
                                    /* Added By YJJung */
                                    for (y = i; y < i + spanCount; y++)
                                    {
                                        if (activeSheet.Columns[y].Visible == false)
                                        {
                                            spanCount = spanCount - 1;
                                        }
                                    }
                                    /* Added End */
                                    for (k = 0; k <= (spanCount - 2); k++)
                                    {
                                        clipboardData += " " + "\t";
                                    }
                                    i += spanCount - 1;
                                }
                            }

                            clipboardData = clipboardData + "\n";
                            Clipboard.SetDataObject((object)clipboardData, false, 5, 10);
                            ((Excel.Range)xlSheet.Cells[(iRestRows + j), (iRestCols + iRowHeaderCount)]).Select();
                            //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }


                        // Column Heaer의 Merge를 설정.
                        for (j = 0; j < iColHeaderCount; j++)
                        {
                            for (k = 0; k < iColumnCnt; k++)
                            {
                                i = aColumns[k];
                                if (iRowHeaderCount > k)
                                {
                                    k += iRowHeaderCount - 1;
                                }
                                else
                                {
                                    spanCount = activeSheet.ColumnHeader.Cells[j, i].ColumnSpan;
                                    if (spanCount > 1)
                                    {
                                        /* Added By YJJung */
                                        for (y = i; y < i + spanCount; y++)
                                        {
                                            if (activeSheet.Columns[y].Visible == false)
                                            {
                                                spanCount = spanCount - 1;
                                            }
                                        }
                                        /* Added End */
                                        xlWiths = xlSheet.get_Range(xlSheet.Cells[j + iRestRows, k + iRestCols],
                                                xlSheet.Cells[j + iRestRows, k + iRestCols + spanCount - 1]);
                                        //xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                        xlWiths.Select();
                                        xlWiths.Merge(Type.Missing);

                                        k += spanCount - 1;
                                    }

                                    spanCount = activeSheet.ColumnHeader.Cells[j, i].RowSpan;
                                    if (spanCount > 1 && spanCount <= (iColHeaderCount - j))
                                    {
                                        xlWiths = xlSheet.get_Range(xlSheet.Cells[j + iRestRows, k + iRestCols],
                                                xlSheet.Cells[j + iRestRows + spanCount - 1, k + iRestCols]);
                                        //xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                        xlWiths.Select();
                                        xlWiths.Merge(Type.Missing);
                                    }
                                }
                            }
                        }


                        // Column Header 에 대한 셀서식설정.
                        xlWiths = xlSheet.get_Range(xlSheet.Cells[iRestRows, iRestCols], xlSheet.Cells[iRestRows + iColHeaderCount - 1, iRestCols + iRowHeaderCount + iColumnCnt - 1]);
                        xlWiths.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                        xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                        xlWiths.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue);
                        xlWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                        xlWiths.Font.Bold = true;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        if (xlWiths.Rows.Count > 1)
                        {
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        }

                        if (xlWiths.Columns.Count > 1)
                        {
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        }

                        // Data 시작 위치 재설정.
                        iRestRows += iColHeaderCount;
                    }

                    #region Set RowHeader/Rows cell formula.
                    // Set RowHeaders cell formula.
                    if (iRowHeaderCount > 0)
                    {
                        int spanCount, skipColumn; // Row/Column span count.
                        string rowLavel;

                        // Row Heaer의 Merge를 설정.
                        for (j = 0; j < activeSheet.RowCount; j++)
                        {
                            for (k = 0; k < iRowHeaderCount; k++)
                            {
                                skipColumn = 0;
                                // Set Row Header Text.
                                rowLavel = activeSheet.GetRowLabel(j, k).ToString().Trim();
                                ((Excel.Range)xlSheet.Cells[j + iRestRows, k + iRestCols]).Value2 = rowLavel;

                                spanCount = activeSheet.RowHeader.Cells[j, k].ColumnSpan;
                                if (spanCount > 1 && spanCount <= (iRowHeaderCount - k))
                                {
                                    xlWiths = xlSheet.get_Range(xlSheet.Cells[j + iRestRows, k + iRestCols],
                                            xlSheet.Cells[j + iRestRows, k + iRestCols + spanCount - 1]);
                                    //xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                    xlWiths.Select();
                                    xlWiths.Merge(Type.Missing);

                                    skipColumn = spanCount - 1;
                                }

                                spanCount = activeSheet.RowHeader.Cells[j, k].RowSpan;
                                if (spanCount > 1)
                                {
                                    xlWiths = xlSheet.get_Range(xlSheet.Cells[j + iRestRows, k + iRestCols],
                                            xlSheet.Cells[j + iRestRows + spanCount - 1, k + iRestCols]);
                                    //xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                    xlWiths.Select();
                                    xlWiths.Merge(Type.Missing);
                                }

                                k += skipColumn;
                            }
                        }

                        //'Row Header 셀서식
                        xlWiths = xlSheet.get_Range(xlSheet.Cells[iRestRows, iRestCols], xlSheet.Cells[iRestRows + activeSheet.RowCount - 1, iRestCols + iRowHeaderCount - 1]);
                        xlWiths.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                        xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                        xlWiths.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue);
                        xlWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                        xlWiths.Font.Bold = true;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        if (xlWiths.Rows.Count > 1)
                        {
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        }

                        if (xlWiths.Columns.Count > 1)
                        {
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        }

                        // Data Start Column position reset.
                        //iRestCols += iRowHeaderCount;
                    }

                    // Set Rows cell formula.
                    if (activeSheet.RowCount > 0)
                    {
                        xlWiths = xlSheet.get_Range(xlSheet.Cells[iRestRows, iRestCols + iRowHeaderCount], xlSheet.Cells[iRestRows + activeSheet.RowCount - 1, iRestCols + iRowHeaderCount + iColumnCnt - 1]);
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        xlWiths.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        if (xlWiths.Columns.Count > 1)
                        {
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                        }

                        if (xlWiths.Rows.Count > 1)
                        {
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            xlWiths.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                        }
                    }
                    #endregion

                    #region Get Spread all values.(Hidden column skip).
                    pastColumn = 0;
                    pastColumnCount = 0;
                    pastColumnIdx = iRestCols + iRowHeaderCount;
                    for (i = 0; i < iColumnCnt; i++)
                    {
                        if (aColumns[i] == (pastColumn + pastColumnCount))
                        {
                            pastColumnCount++;
                            continue;
                        }
                        else
                        {
                            if (pastColumnCount > 0)
                            {
                                clipboardData = activeSheet.GetClip(0, pastColumn, -1, pastColumnCount);
                                Clipboard.SetDataObject((object)clipboardData, false, 5, 10);
                                ((Excel.Range)xlSheet.Cells[iRestRows, pastColumnIdx]).Select();
                                //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                                xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                                pastColumnIdx += pastColumnCount;
                            }

                            pastColumn = aColumns[i];
                            pastColumnCount = 1;
                        }
                    }

                    if (pastColumnCount > 0)
                    {
                        clipboardData = activeSheet.GetClip(0, pastColumn, -1, pastColumnCount);
                        Clipboard.SetDataObject((object)clipboardData, false, 5, 10);
                        ((Excel.Range)xlSheet.Cells[iRestRows, pastColumnIdx]).Select();
                        //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }

                    // Column크기를 자동으로 조절(Row and Column header).
                    xlWiths = xlSheet.get_Range(xlSheet.Cells[(iRestRows - iColHeaderCount > 0 ? iRestRows - iColHeaderCount : iRestRows), iRestCols],
                                xlSheet.Cells[iRestRows + activeSheet.RowCount - 1, iRestCols + iRowHeaderCount + iColumnCnt - 1]);
                    xlWiths.EntireColumn.AutoFit();
                    // Row 크기를 조절.
                    if (iRowHeight > 0)
                    {
                        //Keep the minimum row height to 13.
                        if (iRowHeight < 13)
                        {
                            iRowHeight = 13;
                        }
                        xlWiths.EntireRow.RowHeight = iRowHeight;
                    }
                    #endregion

                    // 각 Column의 Background/ForeColor를 설정함.
                    if (colorFlag == true)
                    {
                        for (i = 0; i < activeSheet.RowCount; i++)
                        {
                            for (j = startColumn; j < endColumn; j++)
                            {
                                if (activeSheet.Cells[i, j].ForeColor.IsEmpty == false)
                                {
                                    if (activeSheet.Cells[i, j].ForeColor.ToArgb() != System.Drawing.Color.Black.ToArgb())
                                    {
                                        ((Excel.Range)xlSheet.Cells[i + iRestRows, j + iRestCols + iRowHeaderCount]).Font.Color =
                                            System.Drawing.ColorTranslator.ToOle(activeSheet.Cells[i, j].ForeColor);
                                    }
                                }

                                if (activeSheet.Cells[i, j].BackColor.IsEmpty == false)
                                {
                                    if (activeSheet.Cells[i, j].BackColor.ToArgb() != System.Drawing.Color.White.ToArgb())
                                    {
                                        ((Excel.Range)xlSheet.Cells[i + iRestRows, j + iRestCols + iRowHeaderCount]).Interior.Color =
                                            System.Drawing.ColorTranslator.ToOle(activeSheet.Cells[i, j].BackColor);
                                    }
                                }
                            }
                        }
                    }

                    /* Added by YJJUng for all of merged rows */
                    if (bMergeRows == true)
                    {
                        for (i = 0; i < activeSheet.RowCount; i++)
                        {

                            int spanCount;
                            spanCount = 0;
                            for (j = startColumn; j < endColumn; j++)
                            {
                                if (activeSheet.Cells[i, j].RowSpan > 1)
                                {

                                    spanCount = activeSheet.Cells[i, j].RowSpan;

                                    xlWiths = xlSheet.get_Range(xlSheet.Cells[i + iRestRows, j + iRestCols],
                                               xlSheet.Cells[i + iRestRows + spanCount - 1, j + iRestCols]);

                                    xlWiths.Select();

                                    xlWiths.Merge(Type.Missing);

                                    spanCount = 1;
                                }
                            }
                        }
                        /* Added End */
                    }
                    iRestRows += activeSheet.RowCount;
                    // 데이터만 export(bOnlyData == true)할 경우엔 Spread별로 구분하는 Row를 넣지 않음.
                    if (bOnlyData == false)
                    {
                        iRestRows++;
                    }
                }


                // Spread Data만 Export할 경우 Page Setup.
                if (pageOptions != null && pageOptions.Length == 12)
                {
                    InsertPrintOption(xlSheet, pageOptions);
                }

                // Spread Data만 Export할 경우 Title, Row/Column Header, Conditions, Current Date를 표시하지 않음.
                if (bOnlyData == false)
                {
                    // Title 에 대한 셀 서식 지정
                    xlWiths = xlSheet.get_Range(xlSheet.Cells[1, iRestCols], xlSheet.Cells[1, iRestCols]);
                    xlWiths.VerticalAlignment = ExcelComponent.XlVAlign.xlValignTop;
                    xlWiths.RowHeight = 30;
                    xlWiths.Font.Size = 18;
                    xlWiths.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                    xlWiths.Font.Bold = true;
                    ((Excel.Range)xlSheet.Cells[1, iRestCols]).Value2 = title;

                    // Current Date/Time표시 유무.
                    if (bShowDate == true)
                    {
                        string sNowDate;
                        sNowDate = string.Format(Convert.ToString(DateTime.Now), "yyyy-MM-dd") + " " + string.Format(Convert.ToString(DateTime.Now), "HH:mm:ss");
                        ((Excel.Range)xlSheet.Cells[2, iRestCols]).Value2 = "Today: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    //'조회조건에 값
                    if (condition.Length > 0)
                    {
                        Clipboard.SetDataObject((object)condition, false, 5, 10);
                        ((Excel.Range)xlSheet.Cells[3, iRestCols]).Select();
                        //xlSheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        xlSheet._PasteSpecial(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }

                    // 이미지가 하단에 위치할 경우,..
                    if (imageFile != null && imagePostion > 1)
                    {
                        int importRows = iRestRows + 1;

                        importRows = InsertImageToExcel((Excel._Worksheet)xlSheet, imageFile, importRows, iRestCols);
                    }

                    // Page Setup
                    xlSheet.PageSetup.TopMargin = 0;
                    xlSheet.PageSetup.LeftMargin = 0;
                    xlSheet.PageSetup.RightMargin = 0;

                    if (true)
                    {
                        xlSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

                        xlWiths = xlSheet.get_Range(xlSheet.Cells[1, 1],
                                                xlSheet.Cells[iRestRows, endColumn]);

                        xlSheet.PageSetup.Zoom = ((72 * 11.69 - (10 * 2) - xlSheet.PageSetup.LeftMargin - xlSheet.PageSetup.RightMargin) / (double)xlWiths.Width) * 100;
                    }
                }


                // Set cursor position.

                ((Excel.Range)xlSheet.Cells[1, 1]).Select();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWiths);
                xlSheet.PrintOut(1, 1, 1, false, null, false, true, null);

                return bReturn;

            }
            catch (Exception ex)
            {
                String errorMessage = "";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                MPCF.ShowMsgBox(errorMessage, "Error [" + ex.Source + "]", MessageBoxButtons.OK, 1);
                bReturn = false;
                return bReturn;
            }
            finally
            {

                // 사용자에게 저장 여부를 묻는다.
                xlBook.Saved = false;

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks);

                if (bReturn == true)
                {
                    //Make Excel application close.
                    xlApp.DisplayAlerts = false;
                    //xlBook.Saved = true;
                    xlApp.Quit();
                }
                else
                {
                    // 모든 엑셀의 경고메시지가 나타나도록 한다.
                    xlApp.DisplayAlerts = true;
                    //Make Excel visible and give the user control.
                    xlApp.Visible = true;
                    xlApp.UserControl = true;
                }

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                GC.Collect();
                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }

        }

        /// <summary>
        /// Export excel Page Setup.
        /// </summary>
        /// <param name="xSheet">Microsoft.Office.Interop.Excel.Worksheet </param>
        /// <param name="prtOptions">pageOption Array[12] values(Set defualt use = -1): 
        /// Array 1.Sets the size of the left margin, in points.
        /// Array 2.Sets the size of the right margin, in points.
        /// Array 3.Sets the size of the top margin, in points.
        /// Array 4.Sets the size of the bottom margin, in points.
        /// Array 5.Sets the size of the header margin, in points.
        /// Array 6.Sets the size of the footer margin, in points.
        /// Array 7.True(1) if row and column headings are printed with this page.(Default:False)
        /// Array 8.True(1) if cell gridlines are printed on the page.(Default:True)
        /// Array 9.True(1) if the sheet is centered horizontally on the page when it's printed.(Default:False)
        /// Array 10.True(1) if the sheet is centered vertically on the page when it's printed.(Default:False)
        /// Array 11.Sets a XlPageOrientation value that represents the portrait or landscape printing mode.
        /// Array 12.Sets a percentage (between 10 and 400 percent) by which Microsoft Excel will scale the worksheet for printing.</param>
        /// <returns></returns>
        private static bool InsertPrintOption(Excel._Worksheet xSheet, float[] pageOptions)
        {
            try
            {
                if (pageOptions.Length < 12)
                {
                    return false;
                }

                // Sets the size of the left margin, in points. Read/write Double.
                if (pageOptions[0] >= 0)
                {
                    xSheet.PageSetup.LeftMargin = xSheet.Application.CentimetersToPoints((double)pageOptions[0]);
                }

                // Sets the size of the right margin, in points. Read/write Double.
                if (pageOptions[1] >= 0)
                {
                    xSheet.PageSetup.RightMargin = xSheet.Application.CentimetersToPoints((double)pageOptions[1]);
                }

                // Sets the size of the top margin, in points. Read/write Double.
                if (pageOptions[2] >= 0)
                {
                    xSheet.PageSetup.TopMargin = xSheet.Application.CentimetersToPoints((double)pageOptions[2]);
                }

                // Sets the size of the bottom margin, in points. Read/write Double.
                if (pageOptions[3] >= 0)
                {
                    xSheet.PageSetup.BottomMargin = xSheet.Application.CentimetersToPoints((double)pageOptions[3]);
                }

                // Sets the size of the header margin, in points. Read/write Double.
                if (pageOptions[4] >= 0)
                {
                    xSheet.PageSetup.HeaderMargin = xSheet.Application.CentimetersToPoints((double)pageOptions[4]);
                }

                // Sets the size of the footer margin, in points. Read/write Double.
                if (pageOptions[5] >= 0)
                {
                    xSheet.PageSetup.FooterMargin = xSheet.Application.CentimetersToPoints((double)pageOptions[5]);
                }

                //True if row and column headings are printed with this page.(Default:False)
                if (pageOptions[6] >= 0)
                {
                    xSheet.PageSetup.PrintHeadings = (pageOptions[6] <= 0F ? true : false);
                }

                //True if cell gridlines are printed on the page.(Default:True)
                if (pageOptions[7] >= 0)
                {
                    xSheet.PageSetup.PrintGridlines = (pageOptions[7] <= 0F ? true : false);
                }

                //True if the sheet is centered horizontally on the page when it's printed.(Default:False)
                if (pageOptions[8] >= 0)
                {
                    xSheet.PageSetup.CenterHorizontally = (pageOptions[8] <= 0F ? true : false);
                }

                //True if the sheet is centered vertically on the page when it's printed.(Default:False)
                if (pageOptions[9] >= 0)
                {
                    xSheet.PageSetup.CenterVertically = (pageOptions[9] <= 0F ? true : false);
                }

                // Sets a XlPageOrientation value that represents the portrait or landscape printing mode.
                if (pageOptions[10] >= 0)
                {
                    xSheet.PageSetup.Orientation =
                        (pageOptions[10] <= 0F ? Excel.XlPageOrientation.xlPortrait : Excel.XlPageOrientation.xlLandscape);
                }

                //Sets a percentage (between 10 and 400 percent) by which Microsoft Excel will scale the worksheet for printing.
                if (pageOptions[11] > 0)
                {
                    xSheet.PageSetup.Zoom = (pageOptions[11] <= 10F ? 10 : (int)pageOptions[11]);
                }
                if (pageOptions[11] == 0)
                {
                    xSheet.PageSetup.Zoom = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
