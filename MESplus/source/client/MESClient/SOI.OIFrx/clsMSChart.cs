using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace SOI.OIFrx
{
    public sealed class clsMSChart
    {
        /// <summary>
        /// 1. 기본 차트 시리즈 구성
        /// </summary>
        /// <param name="msChart">차트 Control 개체</param>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        public static void SetChartSeries(System.Windows.Forms.DataVisualization.Charting.Chart msChart, DataTable dt, SeriesChartType[] chartTypeArray, string[] sChartNameArray)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series;
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                series = new Series();
                series.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                series.ChartArea = "ChartArea1";
                if (i > chartTypeArray.Length - 1)
                {
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    series.ChartType = chartTypeArray[i];
                }
                series.CustomProperties = "LabelStyle=Top";
                series.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                series.IsValueShownAsLabel = false;
                series.Legend = "Legend1";
                series.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                series.MarkerColor = Color.White;
                if (i > sChartNameArray.Length - 1)
                {
                    series.Name = i.ToString();
                }
                else
                {
                    series.Name = sChartNameArray[i];
                }
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.ToolTip = series.Name + " : #VALY{D2}";
                series.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i+1].Caption);
                msChart.Series.Add(series);
            }
        }

        /// <summary>
        /// 2. 기본 차트에 라벨 표시
        /// </summary>
        /// <param name="msChart">차트 Control 개체</param>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        public static void SetChartSeries(System.Windows.Forms.DataVisualization.Charting.Chart msChart, DataTable dt, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool bShowLabel)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series;
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                series = new Series();
                series.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                series.ChartArea = "ChartArea1";
                if (i > chartTypeArray.Length - 1)
                {
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    series.ChartType = chartTypeArray[i];
                }
                series.CustomProperties = "LabelStyle=Top";
                series.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                series.IsValueShownAsLabel = bShowLabel;
                series.Legend = "Legend1";
                series.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                series.MarkerColor = Color.White;
                if (i > sChartNameArray.Length - 1)
                {
                    series.Name = i.ToString();
                }
                else
                {
                    series.Name = sChartNameArray[i];
                }
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.ToolTip = series.Name + " : #VALY{D2}";
                series.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                msChart.Series.Add(series);
            }
        }
        
        /// <summary>
        /// 3. 기본 차트에 세컨트 Y 축 포함
        /// </summary>
        /// <param name="msChart">차트 Control 개체</param>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bSecondAxisY">세컨드 Y축 여부</param>
        /// <param name="iSecondAxiYSeriesIndex">세컨드 Y축 인덱스 배열 (여러개 존재 가능)</param>
        /// <param name="secondeSeriesColor">세컨드 Series 색상</param>
        public static void SetChartSeries(System.Windows.Forms.DataVisualization.Charting.Chart msChart, DataTable dt, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool bSecondAxisY, int[] iSecondAxiYSeriesIndex, Color[] secondeSeriesColor)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series;
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                series = new Series();
                series.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                series.ChartArea = "ChartArea1";
                if (i > chartTypeArray.Length - 1)
                {
                    // 차트타입 개수가 시리즈 개수보다 적을 경우 라인 타입으로 지정
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    series.ChartType = chartTypeArray[i];
                }
                series.CustomProperties = "LabelStyle=Top";
                series.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                series.IsValueShownAsLabel = false;
                series.Legend = "Legend1";
                series.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                series.MarkerColor = Color.White;
                if (i > sChartNameArray.Length - 1)
                {
                    series.Name = i.ToString();
                }
                else
                {
                    series.Name = sChartNameArray[i];
                }
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.ToolTip = series.Name + " : #VALY{D2}";
                // Secondary Axis Y Setting
                if (bSecondAxisY == true)
                {
                    for (int index = 0; index < iSecondAxiYSeriesIndex.Length; index++)
                    {
                        if (iSecondAxiYSeriesIndex != null)
                        {
                            if (i == iSecondAxiYSeriesIndex[index])
                            {
                                series.YAxisType = AxisType.Secondary;
                                if (secondeSeriesColor != null)
                                    series.Color = secondeSeriesColor[index];
                            }
                        }
                    }
                }

                 // Data Bind
                series.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                msChart.Series.Add(series);
            }
        }

        /// <summary>
        /// 4. 차트에 라벨과 세컨드 Y축 포함
        /// </summary>
        /// <param name="msChart">차트 Control 개체</param>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        /// <param name="bSecondAxisY">세컨드 Y축 여부</param>
        /// <param name="iSecondAxiYSeriesIndex">세컨드 Y축 인덱스 배열 (여러개 존재 가능)</param>
        /// <param name="secondeSeriesColor">세컨드 Series 색상</param>
        public static void SetChartSeries(System.Windows.Forms.DataVisualization.Charting.Chart msChart, DataTable dt, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool bShowLabel, bool bSecondAxisY, int[] iSecondAxiYSeriesIndex, Color[] secondeSeriesColor)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series;
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                series = new Series();
                series.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                series.ChartArea = "ChartArea1";
                if (i > chartTypeArray.Length - 1)
                {
                    // 차트타입 개수가 시리즈 개수보다 적을 경우 라인 타입으로 지정
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    series.ChartType = chartTypeArray[i];
                }
                series.CustomProperties = "LabelStyle=Top";
                series.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                series.IsValueShownAsLabel = bShowLabel;
                series.Legend = "Legend1";
                series.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                series.MarkerColor = Color.White;
                if (i > sChartNameArray.Length - 1)
                {
                    series.Name = i.ToString();
                }
                else
                {
                    series.Name = sChartNameArray[i];
                }
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.ToolTip = series.Name + " : #VALY{D2}";
                // Secondary Axis Y Setting
                if (bSecondAxisY == true)
                {
                    for (int index = 0; index < iSecondAxiYSeriesIndex.Length; index++)
                    {
                        if (iSecondAxiYSeriesIndex != null)
                        {
                            if (i == iSecondAxiYSeriesIndex[index])
                            {
                                series.YAxisType = AxisType.Secondary;
                                if (secondeSeriesColor != null)
                                    series.Color = secondeSeriesColor[index];
                            }
                        }
                    }
                }

                // Data Bind
                series.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                msChart.Series.Add(series);
            }
        }        

        /// <summary>
        /// 5. 차트에 라벨 & 마커 표시 포함
        /// </summary>
        /// <param name="msChart">차트 Control 개체</param>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        /// <param name="bShowMarker">마커 표시 여부</param>
        /// <param name="markerStyle">마커 종류</param>
        /// <param name="markerColor">마커 색깔</param>
        public static void SetChartSeries(System.Windows.Forms.DataVisualization.Charting.Chart msChart, DataTable dt, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool bShowLabel, bool[] bShowMarker, MarkerStyle markerStyle, Color markerColor)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series;
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                series = new Series();
                series.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                series.ChartArea = "ChartArea1";
                if (i > chartTypeArray.Length - 1)
                {
                    // 차트타입 개수가 시리즈 개수보다 적을 경우 라인 타입으로 지정
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    series.ChartType = chartTypeArray[i];
                }
                series.CustomProperties = "LabelStyle=Top";
                series.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                series.IsValueShownAsLabel = bShowLabel;
                series.Legend = "Legend1";
                if (bShowMarker.Length != 0 && i > bShowMarker.Length - 1)
                {
                    if (bShowMarker[0] == true)
                    {
                        series.MarkerStyle = markerStyle;
                        series.MarkerColor = markerColor;
                    }
                    else
                    {
                        series.MarkerStyle = MarkerStyle.Circle;
                        series.MarkerColor = Color.White;
                    }
                }
                else
                {
                    if (bShowMarker[i] == true)
                    {
                        series.MarkerStyle = markerStyle;
                        series.MarkerColor = markerColor;
                    }
                }

                if (i > sChartNameArray.Length - 1)
                {
                    series.Name = i.ToString();
                }
                else
                {
                    series.Name = sChartNameArray[i];
                }
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.ToolTip = series.Name + " : #VALY{D2}";
                // Data Bind
                series.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                msChart.Series.Add(series);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msChart">차트 Control 개체</param>
        /// <param name="dt">DataTable : Index 0 = Axis X Value, index 1 이상 = Series</param>
        /// <param name="chartTypeArray">Series에 대한 각각의 차트 타입 배열</param>
        /// <param name="sChartNameArray">Series별 차트 명칭 배열</param>
        /// <param name="bShowLabel">라벨 표시 여부</param>
        /// <param name="bShowMarker">마커 표시 여부</param>
        /// <param name="markerStyle">마커 종류</param>
        /// <param name="markerColor">마커 색깔</param>
        /// <param name="bSecondAxisY">세컨드 Y축 여부</param>
        /// <param name="iSecondAxiYSeriesIndex">세컨드 Y축 인덱스 배열 (여러개 존재 가능)</param>
        /// <param name="secondeSeriesColor">세컨드 Series 색상</param>
        public static void SetChartSeries(System.Windows.Forms.DataVisualization.Charting.Chart msChart, DataTable dt, SeriesChartType[] chartTypeArray, string[] sChartNameArray, bool bShowLabel, bool[] bShowMarker, MarkerStyle markerStyle, Color markerColor, bool bSecondAxisY, int[] iSecondAxiYSeriesIndex, Color[] secondeSeriesColor)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series;
            DataView dataView = new DataView(dt);

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                series = new Series();
                series.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                series.ChartArea = "ChartArea1";
                if (i > chartTypeArray.Length - 1)
                {
                    // 차트타입 개수가 시리즈 개수보다 적을 경우 라인 타입으로 지정
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    series.ChartType = chartTypeArray[i];
                }
                series.CustomProperties = "LabelStyle=Top";
                series.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                series.IsValueShownAsLabel = bShowLabel;
                series.Legend = "Legend1";
                if (bShowMarker[i] == true)
                {
                    series.MarkerStyle = markerStyle;
                    series.MarkerColor = markerColor;
                }
                if (i > sChartNameArray.Length - 1)
                {
                    series.Name = i.ToString();
                }
                else
                {
                    series.Name = sChartNameArray[i];
                }
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                series.ToolTip = series.Name + " : " + "#VALY{F2}";

                // Secondary Axis Y Setting
                if (bSecondAxisY == true)
                {
                    for (int index = 0; index < iSecondAxiYSeriesIndex.Length; index++)
                    {
                        if (iSecondAxiYSeriesIndex != null)
                        {
                            if (i == iSecondAxiYSeriesIndex[index])
                            {
                                series.YAxisType = AxisType.Secondary;
                                if (secondeSeriesColor != null)
                                    series.Color = secondeSeriesColor[index];
                            }
                        }
                    }
                }

                // Data Bind
                series.Points.DataBindXY(dataView, dt.Columns[0].Caption, dataView, dt.Columns[i + 1].Caption);
                msChart.Series.Add(series);
            }
        }
    }
}
