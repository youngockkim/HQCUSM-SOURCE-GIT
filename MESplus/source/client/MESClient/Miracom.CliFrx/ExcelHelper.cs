using System;
using System.Data;
//using Microsoft.Vbe.Interop;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
//using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace Miracom.CliFrx
{
    /// <summary>
    /// Chart 정보를 가진 구조체
    /// </summary>
    public struct ChartInfo
    {
        public string Title;
        public float Left;
        public float Top;
        public float Width;
        public float Height;
        public Excel.XlChartType ChartType;
        public ChartInfo(string title, float left, float top, float width, float height, Excel.XlChartType chartType)
        {
            this.Title = title;
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
            this.ChartType = chartType;
        }
    }

    /// <summary>
    /// 축 정보를 가진 구조체
    /// </summary>
    public struct AxisInfo
    {
        public string Title;
        public Excel.XlHAlign HAlign;
        public Excel.XlVAlign VAlign;
        public IScale Scale;
        public AxisInfo(string title, Excel.XlHAlign hAlign, Excel.XlVAlign vAlign, IScale scale)
        {
            this.Title = title;
            this.HAlign = hAlign;
            this.VAlign = vAlign;
            this.Scale = scale;
        }
    }

    /// <summary>
    /// 축 서식 정보 호환을 위한 인터페이스
    /// </summary>
    public interface IScale
    {
    }

    /// <summary>
    /// Y(값) 축 서식정보
    /// </summary>
    public class ValueScale : IScale
    {
        /// <summary>
        /// 최소값
        /// </summary>
        public double _minimumScale;
        /// <summary>
        /// 최대값
        /// </summary>
        public double _maximumScale;
        /// <summary>
        /// 주 단위
        /// </summary>
        public double _majorUnit;
        /// <summary>
        /// 보조 단위
        /// </summary>
        public double _minorUnit;
        /// <summary>
        /// X(항목) 축 교점
        /// </summary>
        public double _crossesAt;
        /// <summary>
        /// 최소값 자동
        /// </summary>
        public bool _minimumScaleIsAuto;
        /// <summary>
        /// 최대값 자동
        /// </summary>
        public bool _maximumScaleIsAuto;
        /// <summary>
        /// 주 단위 자동
        /// </summary>
        public bool _majorUnitIsAuto;
        /// <summary>
        /// 보조 단위 자동
        /// </summary>
        public bool _minorUnitIsAuto;
        /// <summary>
        /// X(항목) 축 교점
        /// xlCustom : 자동 해제
        /// xlAutomatic : 자동 설정
        /// xlMaximum : 최대값에서 X(항목) 축 교차
        /// </summary>
        public Excel.XlAxisCrosses _crosses;
        /// <summary>
        /// 표시단위
        /// </summary>
        public Excel.XlDisplayUnit _displayUnit;
        /// <summary>
        /// 로그 눈금 간격
        /// </summary>
        public Excel.XlScaleType _scaleType;
        /// <summary>
        /// 값을 꺼꾸로
        /// </summary>
        public bool _reversePlotOrder;
        /// <summary>
        /// 주 눈금
        /// </summary>
        public Excel.XlTickMark _majorTickMark;
        /// <summary>
        /// 보조 눈금
        /// </summary>
        public Excel.XlTickMark _minorTickMark;
        /// <summary>
        /// 눈금 레이블
        /// </summary>
        public Excel.XlTickLabelPosition _tickLabelPosition;

        /// <summary>
        /// 생성자. 값 축 서식을 기본값으로 초기화한다.
        /// </summary>
        public ValueScale()
        {
            this._displayUnit = (Excel.XlDisplayUnit)Excel.Constants.xlNone;
            this._minimumScaleIsAuto = true;
            this._maximumScaleIsAuto = true;
            this._majorUnitIsAuto = true;
            this._minorUnitIsAuto = true;
            this._crosses = Excel.XlAxisCrosses.xlAxisCrossesAutomatic;
            this._scaleType = Excel.XlScaleType.xlScaleLinear;
            this._reversePlotOrder = false;
            this._majorTickMark = Excel.XlTickMark.xlTickMarkInside;
            this._minorTickMark = Excel.XlTickMark.xlTickMarkNone;
            //this._tickLabelPosition = Excel.XlTickLabelPosition.xlTickLabelPositionLow;
            this._tickLabelPosition = Excel.XlTickLabelPosition.xlTickLabelPositionNextToAxis;
        }
        /// <summary>
        /// 값 축 서식의 눈금 정보의 자동설정 값을 지정한다.
        /// </summary>
        /// <param name="minimumScaleIsAuto">최소값 자동</param>
        /// <param name="maximumScaleIsAuto">최대값 자동</param>
        /// <param name="majorUnitIsAuto">주 단위 자동</param>
        /// <param name="minorUnitIsAuto">보조 단위 자동</param>
        /// <param name="crosses">X(항목) 축 교점 자동</param>
        public void SetAuto(bool minimumScaleIsAuto, bool maximumScaleIsAuto, bool majorUnitIsAuto, bool minorUnitIsAuto, Excel.XlAxisCrosses crosses)
        {
            this._minimumScaleIsAuto = minimumScaleIsAuto;
            this._maximumScaleIsAuto = maximumScaleIsAuto;
            this._majorUnitIsAuto = majorUnitIsAuto;
            this._minorUnitIsAuto = minorUnitIsAuto;
            this._crosses = crosses;
        }
        /// <summary>
        /// 값 축 서식의 눈금 정보를 설정한다.
        /// </summary>
        /// <param name="mimimumScale">최소값</param>
        /// <param name="maximumScale">최대값</param>
        /// <param name="majorUnit">주 단위</param>
        /// <param name="minorUnit">보조 단위</param>
        /// <param name="crossesAt">X(항목) 축 교점</param>
        /// <param name="displayUnit">표시 단위</param>
        public void SetScale(double mimimumScale, double maximumScale, double majorUnit, double minorUnit, double crossesAt, Excel.Constants displayUnit)
        {
            this._minimumScale = mimimumScale;
            this._maximumScale = maximumScale;
            this._minorUnit = minorUnit;
            this._majorUnit = majorUnit;
            this._crossesAt = crossesAt;
            this._displayUnit = (Excel.XlDisplayUnit)displayUnit;
        }
        /// <summary>
        /// 값 축 서식의 눈금 옵션정보를 설정한다.
        /// </summary>
        /// <param name="scaleType">로그 눈금 간격</param>
        /// <param name="reversePlotOrder">값을 거꾸로 적용 여부</param>
        public void SetScaleOption(Excel.XlScaleType scaleType, bool reversePlotOrder)
        {
            this._scaleType = scaleType;
            this._reversePlotOrder = reversePlotOrder;
        }
        /// <summary>
        /// 값 축 서식의 무늬를 지정한다.
        /// </summary>
        /// <param name="majorTickMark">주 눈금</param>
        /// <param name="minorTickMark">보조 눈금</param>
        /// <param name="tickLabelPosition">눈금레이블</param>
        public void SetPattern(Excel.XlTickMark majorTickMark, Excel.XlTickMark minorTickMark, Excel.XlTickLabelPosition tickLabelPosition)
        {
            this._majorTickMark = majorTickMark;
            this._minorTickMark = minorTickMark;
            this._tickLabelPosition = tickLabelPosition;
        }
    }
    /// <summary>
    /// X(항목) 축 서식정보
    /// </summary>
    public class CategoryScale : IScale
    {
        /// <summary>
        /// Y(값) 축과 교차할 항목번호
        /// </summary>
        public int _crossesAt;
        /// <summary>
        /// 눈금 레이블 사이에 들어갈 항목 수
        /// </summary>
        public int _tickLabelSpacing;
        /// <summary>
        /// 눈금 사이에 들어갈 항목 수
        /// </summary>
        public int _tickMarkSpacing;
        /// <summary>
        /// 항목 사이에 Y(값) 축 교차
        /// </summary>
        public bool _axisBetweenCategories;
        /// <summary>
        /// 항목을 거꾸로
        /// </summary>
        public bool _reversePlotOrder;
        /// <summary>
        /// 최대 항목에서 Y(값) 축 교차
        /// </summary>
        public Excel.XlAxisCrosses _crosses;

        /// <summary>
        /// 생성자. 항목 축 서식을 지정한 값으로 초기화한다.
        /// </summary>
        /// <param name="crossesAt">Y(값) 축과 교차할 항목번호</param>
        /// <param name="tickLabelSpacing">눈금 레이블 사이에 들어갈 항목 수</param>
        /// <param name="tickMarkSpacing">눈금 사이에 들어갈 항목 수</param>
        /// <param name="axisBetweenCategories">항목 사이에 Y(값) 축 교차</param>
        /// <param name="reversePlotOrder">항목을 거꾸로 적용 여부</param>
        /// <param name="crosses">최대 항목에서 Y(값) 축 교차</param>
        public CategoryScale(int crossesAt, int tickLabelSpacing, int tickMarkSpacing, bool axisBetweenCategories, bool reversePlotOrder, Excel.XlAxisCrosses crosses)
        {
            this._crossesAt = crossesAt;
            this._tickLabelSpacing = tickLabelSpacing;
            this._tickMarkSpacing = tickMarkSpacing;
            this._axisBetweenCategories = axisBetweenCategories;
            this._reversePlotOrder = reversePlotOrder;
            this._crosses = crosses;
        }
    }

    /// <summary>
    /// 엑셀 처리
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// 워크시트에 차트를 추가한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="seriesNames">계열 이름. 문자열 배열</param>
        /// <param name="seriesRanges">계열 값. Excel.Range형 배열</param>
        /// <param name="hasTrendlines">추세선 추가 여부. Boolean형 배열</param>
        /// <param name="trendlineColors">추세선 색. System.Drawing.Color형 배열</param>
        /// <param name="trendlineStyles">추세선 스타일. Excel.XlLineStyle형 배열</param>
        /// <param name="chart">차트 정보</param>
        /// <param name="xAxis">항목 정보</param>
        /// <param name="yAxis">값 정보</param>
        public static void AddChart(Excel.Worksheet worksheet, string[] seriesNames, Excel.Range[] seriesRanges, bool[] hasTrendlines, Color[] trendlineColors, Excel.XlLineStyle[] trendlineStyles, ChartInfo chart, AxisInfo xAxis, AxisInfo yAxis)
        {
            Excel.Application objExcel = worksheet.Application;
            Excel.Workbook objBook = (Excel.Workbook)worksheet.Parent;
            Excel.Sheets objCharts = (Excel.Sheets)objBook.Charts;
            Excel.Chart objChart1 = (Excel.Chart)objCharts.Add(Type.Missing, worksheet, Type.Missing, Type.Missing);
            Excel.Chart objChart2 = objChart1.Location(Excel.XlChartLocation.xlLocationAsObject, worksheet.Name);
            string strChartName = objChart2.Name;
            Excel.SeriesCollection objSeriesCollection = (Excel.SeriesCollection)objChart2.SeriesCollection(Type.Missing);
            Excel.Series objSeries = null;

            try
            {
                Excel.ChartArea chartArea = objChart2.ChartArea;
                chartArea.Select();
                chartArea.AutoScaleFont = false;
                Excel.Font objFont = chartArea.Font;
                objFont.Size = 8;
                ReleaseComObject(objFont, chartArea);

                objChart2.ChartType = chart.ChartType;
                // 차트 계열 설정
                objChart2.HasDataTable = false;
                for (int i = 0; i < seriesNames.Length; i++)
                {
                    objSeries = AddSeries(objSeriesCollection, seriesNames[i], seriesRanges[i], hasTrendlines[i], trendlineColors[i], trendlineStyles[i]);
                    ReleaseComObject(objSeries);
                }
                SetChartTitle(objChart2, chart);

                // 차트 그림 영역
                Excel.PlotArea objPlot = objChart2.PlotArea;
                objPlot.Select();
                Excel.Interior objInterior = objPlot.Interior;
                objInterior.ColorIndex = Excel.XlColorIndex.xlColorIndexNone;

                // 차트 축
                Excel.Axes objAxes = (Excel.Axes)objChart2.Axes(Type.Missing, Excel.XlAxisGroup.xlPrimary);
                Excel.Axis objCategory = (Excel.Axis)objChart2.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);//가로(항목)축
                SetAxisTitle(objCategory, xAxis, 0, true);
                Excel.Axis objValue = (Excel.Axis)objChart2.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);//세로(값)축
                SetAxisTitle(objValue, yAxis, 90, false);
                ReleaseComObject(objValue, objCategory, objAxes);
                ReleaseComObject(objInterior, objPlot);

                Locate(worksheet, chart.Left, chart.Top, chart.Width, chart.Height); //좌표
                SetLegend(objChart2, Excel.Constants.xlRight, hasTrendlines, trendlineColors, trendlineStyles); //범례
            }
            catch (Exception ex)
            {
                //HttpContext.Current.Response.Write(ex.ToString());
            }
            finally
            {
                ReleaseComObject(objSeries, objSeriesCollection);
                ReleaseComObject(objChart1, objChart2, objCharts, objBook, objExcel);
            }
        }
        /// <summary>
        /// 차트의 좌표를 변경한다.
        /// </summary>
        /// <param name="worksheet">차트를 포함한 워크시트</param>
        /// <param name="left">왼쪽 좌표</param>
        /// <param name="top">상단 좌표</param>
        /// <param name="width">넓이</param>
        /// <param name="height">높이</param>
        public static void Locate(Excel.Worksheet worksheet, float left, float top, float width, float height)
        {
            Excel.Shapes objShapes = worksheet.Shapes;
            Excel.Shape objShape = objShapes.Item(objShapes.Count);
            objShape.Left = left;
            objShape.Top = top;
            objShape.Width = width;
            objShape.Height = height;
            ReleaseComObject(objShape, objShapes);
        }
        /// <summary>
        /// 차트에 계열을 추가한다.
        /// </summary>
        /// <param name="seriesCollection">차트의 계열 컬렉션</param>
        /// <param name="seriesName">계열 이름</param>
        /// <param name="seriesRange">계열 값(Excel.Range형)</param>
        /// <param name="hasTrendline">추세선 추가 여부</param>
        /// <param name="trendlineColor">추세선 색</param>
        /// <param name="trendlineStyle">추세선 스타일</param>
        /// <returns>차트에 추가된 계열</returns>
        public static Excel.Series AddSeries(Excel.SeriesCollection seriesCollection, string seriesName, Excel.Range seriesRange, bool hasTrendline, Color trendlineColor, Excel.XlLineStyle trendlineStyle)
        {
            Excel.Series objSeries = null;
            objSeries = seriesCollection.NewSeries();
            objSeries.Name = seriesName;
            objSeries.Values = seriesRange;
            if (hasTrendline)
            {
                Excel.Trendlines objTrendlines = (Excel.Trendlines)objSeries.Trendlines(Type.Missing);
                Excel.Trendline objTrendline = objTrendlines.Add(Excel.XlTrendlineType.xlLinear, Type.Missing, Type.Missing, 0, 0, true, false, false, seriesName);
                Excel.Border objBorder = objTrendline.Border;
                objBorder.Color = ColorTranslator.ToOle(trendlineColor);
                objBorder.Weight = Excel.XlBorderWeight.xlMedium;
                //objBorder.LineStyle = Excel.XlLineStyle.xlContinuous;
                objBorder.LineStyle = trendlineStyle;
                objTrendline.Intercept = 0;
                objTrendline.InterceptIsAuto = true;
                ReleaseComObject(objBorder, objTrendline, objTrendlines);
            }

            return objSeries;
        }
        /// <summary>
        /// 차트 타이틀 서식을 설정한다.
        /// </summary>
        /// <param name="chart">대상 차트</param>
        /// <param name="chartInfo">차트 정보</param>
        public static void SetChartTitle(Excel.Chart chart, ChartInfo chartInfo)
        {
            chart.HasTitle = true;
            Excel.ChartTitle objTitle = chart.ChartTitle;
            Excel.Characters objCharacters = null;
            Excel.Font objFont = null;
            string[] strTitles = chartInfo.Title.Split("\n".ToCharArray());
            if (strTitles.Length == 2)
            {
                objTitle.Text = chartInfo.Title;
                objCharacters = objTitle.get_Characters(1, strTitles[0].Length);
                objFont = objCharacters.Font;
                objFont.Name = "휴먼옛체";
                objFont.FontStyle = "굵게";
                //objFont.Size =  23.2f;//15;
                objFont.Size = 15;
                objFont.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle;
                objFont.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                ReleaseComObject(objFont, objCharacters);
                objCharacters = objTitle.get_Characters(chartInfo.Title.Length - strTitles[1].Length + 1, strTitles[1].Length);
                objFont = objCharacters.Font;
                objFont.Name = "휴먼옛체";
                objFont.FontStyle = "굵게";
                //objFont.Size = 14.5f; //9.5;
                objFont.Size = 9.5;
                objFont.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle;
                objFont.ColorIndex = 5;
            }
            else
            {
                objTitle.Text = chartInfo.Title;
                objFont = objTitle.Font;
                objFont.Name = "휴먼옛체";
                objFont.FontStyle = "굵게";
                //objFont.Size = 24.5f; //16;
                objFont.Size = 16;
                objFont.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle;
                objFont.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
            }
            ReleaseComObject(objFont, objCharacters, objTitle);
        }
        /// <summary>
        /// 축의 타이틀 서식을 설정한다.
        /// </summary>
        /// <param name="axis">대상 축</param>
        /// <param name="axisInfo">축 정보</param>
        /// <param name="orientation">텍스트의 방위</param>
        /// <param name="isCategory">항목 축인 경우 true, 값 축인 경우 false</param>
        public static void SetAxisTitle(Excel.Axis axis, AxisInfo axisInfo, int orientation, bool isCategory)
        {
            axis.HasTitle = true;
            Excel.AxisTitle objTitle = axis.AxisTitle;
            Excel.Characters objCharacters = objTitle.get_Characters(Type.Missing, Type.Missing);
            objCharacters.Text = axisInfo.Title;
            objTitle.Text = axisInfo.Title;
            objTitle.HorizontalAlignment = axisInfo.HAlign;
            objTitle.VerticalAlignment = axisInfo.VAlign;
            objTitle.ReadingOrder = (int)Excel.Constants.xlContext;
            objTitle.Orientation = orientation;
            if (isCategory)
            {
                axis.CategoryType = Excel.XlCategoryType.xlAutomaticScale;
                CategoryScale scale = (CategoryScale)axisInfo.Scale;
                axis.CrossesAt = scale._crossesAt;
                axis.TickLabelSpacing = scale._tickLabelSpacing;
                axis.TickMarkSpacing = scale._tickMarkSpacing;
                axis.AxisBetweenCategories = scale._axisBetweenCategories;
                axis.ReversePlotOrder = scale._reversePlotOrder;
                axis.Crosses = scale._crosses;
            }
            else
            {
                ValueScale scale = (ValueScale)axisInfo.Scale;
                axis.MaximumScaleIsAuto = false;
                axis.MinimumScaleIsAuto = false;
                axis.MajorUnitIsAuto = false;
                axis.MinorUnitIsAuto = false;
                axis.Crosses = Excel.XlAxisCrosses.xlAxisCrossesCustom;
                axis.MaximumScale = scale._maximumScale;
                axis.MinimumScale = scale._minimumScale;
                axis.MajorUnit = scale._majorUnit;
                axis.MinorUnit = scale._minorUnit;
                axis.CrossesAt = scale._crossesAt;
                axis.MaximumScaleIsAuto = scale._maximumScaleIsAuto;
                axis.MinimumScaleIsAuto = scale._minimumScaleIsAuto;
                axis.MajorUnitIsAuto = scale._majorUnitIsAuto;
                axis.MinorUnitIsAuto = scale._minorUnitIsAuto;
                axis.Crosses = scale._crosses;
                axis.ScaleType = scale._scaleType;
                axis.ReversePlotOrder = scale._reversePlotOrder;
                axis.MajorTickMark = scale._majorTickMark;
                axis.MinorTickMark = scale._minorTickMark;
                axis.TickLabelPosition = scale._tickLabelPosition;
                //axis.TickLabels.NumberFormatLinked = false;
            }
            axis.HasMajorGridlines = false;
            axis.HasMinorGridlines = false;
            ReleaseComObject(objCharacters, objTitle);
        }
        /// <summary>
        /// 범례 서식을 설정한다.
        /// 추세선이 추가된 경우, 계열의 범례표지를 지우고 추세선의 범례표지만 남긴다. 
        /// </summary>
        /// <param name="chart">대상 차트</param>
        /// <param name="position">범례 배치</param>
        /// <param name="hasTrendlines">추세선이 추가됐는지 여부</param>
        /// <param name="entryColors">범례 표지 색</param>
        /// <param name="trendlineStyles">추세선 스타일. Excel.XlLineStyle형 배열</param>
        public static void SetLegend(Excel.Chart chart, Excel.Constants position, bool[] hasTrendlines, Color[] entryColors, Excel.XlLineStyle[] trendlineStyles)
        {
            chart.HasLegend = true;
            Excel.Legend objLegend = chart.Legend;
            objLegend.Select();
            objLegend.Position = (Excel.XlLegendPosition)position;
            Excel.LegendEntries objLegendEntries = (Excel.LegendEntries)objLegend.LegendEntries(Type.Missing);
            Excel.LegendEntry objLegendEntry = null;
            Excel.LegendKey objLegendKey = null;
            Excel.Border objBorder = null;

            int iDeletedCount = 0;
            for (int i = 0; i < hasTrendlines.Length; i++)
            {
                objLegendEntry = objLegendEntries.Item(i + 1 - iDeletedCount);
                if (hasTrendlines[i])
                {
                    objLegendKey = objLegendEntry.LegendKey;
                    objBorder = objLegendKey.Border;
                    objBorder.Weight = Excel.XlBorderWeight.xlMedium;
                    objBorder.LineStyle = Excel.Constants.xlAutomatic;
                    objLegendKey.MarkerBackgroundColor = (int)Excel.XlColorIndex.xlColorIndexAutomatic;
                    objLegendKey.MarkerForegroundColor = (int)Excel.XlColorIndex.xlColorIndexAutomatic;
                    objLegendEntry.Delete();
                    ReleaseComObject(objBorder, objLegendKey, objLegendEntry);
                    iDeletedCount++;
                    objLegendEntry = objLegendEntries.Item(hasTrendlines.Length);
                }
                objLegendKey = objLegendEntry.LegendKey;
                objBorder = objLegendKey.Border;
                objBorder.Color = ColorTranslator.ToOle(entryColors[i]);
                objBorder.Weight = Excel.XlBorderWeight.xlMedium;
                //objBorder.LineStyle = Excel.XlLineStyle.xlContinuous;
                objBorder.LineStyle = trendlineStyles[i];
                objLegendKey.MarkerSize = 3;
                if (hasTrendlines[i])
                {
                    objLegendKey.MarkerStyle = Excel.XlMarkerStyle.xlMarkerStyleNone;
                }
                else
                {
                    objLegendKey.Smooth = false;
                    objLegendKey.Shadow = false;
                    objLegendKey.MarkerStyle = Excel.XlMarkerStyle.xlMarkerStyleDiamond;

                    objLegendKey.MarkerBackgroundColor = ColorTranslator.ToOle(entryColors[i]);
                    objLegendKey.MarkerForegroundColor = ColorTranslator.ToOle(entryColors[i]);
                }
                ReleaseComObject(objBorder, objLegendKey, objLegendEntry);
            }
            ReleaseComObject(objBorder, objLegendKey, objLegendEntry, objLegendEntries);
            ReleaseComObject(objLegend);
        }
        /// <summary>
        /// 셀에 메모를 추가한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="memo">메모 내용</param>
        /// <param name="col1">메모를 추가할 셀의 열번호</param>
        /// <param name="row1">메모를 추가할 셀의 행번호</param>
        /// <param name="autosize">자동 크기 여부</param>
        public static void AddMemo(Excel.Worksheet worksheet, string memo, int col1, int row1, bool autosize)
        {
            Excel.Range objRange = ExcelHelper.GetRange(worksheet, col1, row1);
            AddMemo(objRange, memo, autosize);

            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 영역에 메모를 추가한다.
        /// </summary>
        /// <param name="rng">메모를 추가할 영역</param>
        /// <param name="memo">메모 내용</param>
        /// <param name="autosize">자동 크기 여부</param>
        public static void AddMemo(Excel.Range rng, string memo, bool autosize)
        {
            Excel.Comment comment = rng.Comment;
            if (comment != null) comment.Delete();
            ReleaseComObject(comment);
            comment = rng.AddComment(memo);
            //comment.Visible = false;
            Excel.Shape objShape = comment.Shape;
            Excel.TextFrame objTextFrame = objShape.TextFrame;
            objTextFrame.AutoSize = autosize;
            ReleaseComObject(objTextFrame, objShape, comment);
        }
        /// <summary>
        /// 워크북에 워크시트를 추가한다.
        /// </summary>
        /// <param name="workbook">대상 워크북</param>
        /// <returns>추가된 워크시트</returns>
        public static Excel.Worksheet AddWorksheet(Excel.Workbook workbook)
        {
            Excel.Sheets objSheets = workbook.Worksheets;
            Excel.Worksheet objSheet = (Excel.Worksheet)objSheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            ReleaseComObject(objSheets);

            return objSheet;
        }
        /// <summary>
        /// 워크북의 지정 위치에 워크시트를 추가한다.
        /// </summary>
        /// <param name="workbook">대상 워크북</param>
        /// <param name="sheetIndex">워크시트를 추가할 위치</param>
        /// <returns>추가된 워크시트</returns>
        public static Excel.Worksheet AddWorksheet(Excel.Workbook workbook, int sheetIndex)
        {
            //Excel.Worksheet objSheet1 = AddWorksheet(workbook);
            Excel.Worksheet objSheet1 = null;
            Excel.Worksheet objSheet2 = null;
            Excel.Sheets objSheets = workbook.Worksheets;

            if (sheetIndex > objSheets.Count)
            {
                objSheet2 = (Excel.Worksheet)objSheets[objSheets.Count];
                //objSheet1.Move(Type.Missing, objSheet2);
                objSheet1 = (Excel.Worksheet)objSheets.Add(Type.Missing, objSheet2, Type.Missing, Type.Missing);
            }
            else
            {
                sheetIndex = ((sheetIndex < 1) ? 1 : sheetIndex);
                objSheet2 = (Excel.Worksheet)objSheets[sheetIndex];
                //objSheet1.Move(objSheet2, Type.Missing);
                objSheet1 = (Excel.Worksheet)objSheets.Add(objSheet2, Type.Missing, Type.Missing, Type.Missing);
            }

            if (objSheet2 != null) Marshal.ReleaseComObject(objSheet2);
            if (objSheets != null) Marshal.ReleaseComObject(objSheets);

            return objSheet1;
        }
        /// <summary>
        /// 워크북의 기존 워크시트를 복사해서 지정 위치에 추가한다.
        /// </summary>
        /// <param name="workbook">대상 워크북</param>
        /// <param name="sourceIndex">복사할 워크시트의 위치</param>
        /// <param name="sheetIndex">워크시트를 추가할 위치</param>
        /// <returns>추가된 워크시트</returns>
        public static Excel.Worksheet AddWorksheet(Excel.Workbook workbook, int sourceIndex, int sheetIndex)
        {
            Excel.Worksheet objSource = null;
            Excel.Worksheet objSheet1 = null;
            Excel.Worksheet objSheet2 = null;
            Excel.Sheets objSheets = workbook.Worksheets;

            if (sourceIndex < 1 || sourceIndex > objSheets.Count)
            {
                objSheet1 = AddWorksheet(workbook);
            }
            else
            {
                objSource = (Excel.Worksheet)objSheets[sourceIndex];

                if (sheetIndex > objSheets.Count)
                {
                    objSheet2 = (Excel.Worksheet)objSheets[objSheets.Count];
                    objSource.Copy(Type.Missing, objSheet2);
                    objSheet1 = (Excel.Worksheet)objSheets[objSheets.Count];
                }
                else
                {
                    sheetIndex = ((sheetIndex < 1) ? 1 : sheetIndex);
                    objSheet2 = (Excel.Worksheet)objSheets[sheetIndex];
                    objSource.Copy(objSheet2, Type.Missing);
                    objSheet1 = (Excel.Worksheet)objSheets[sheetIndex];
                }
            }

            if (objSource != null) Marshal.ReleaseComObject(objSource);
            if (objSheet2 != null) Marshal.ReleaseComObject(objSheet2);
            if (objSheets != null) Marshal.ReleaseComObject(objSheets);

            return objSheet1;
        }
        /// <summary>
        /// 일련번호로 자동 채우기한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="startNumber">채우기 시작 값</param>
        /// <param name="count">실행 셀 수</param>
        /// <param name="col1">시작 셀의 열번호</param>
        /// <param name="row1">시작 셀의 행번호</param>
        /// <param name="vertical">세로방향으로 채우기를 실행할 지 여부</param>
        public static void AutoFillSeries(Excel.Worksheet worksheet, int startNumber, int count, int col1, int row1, bool vertical)
        {
            int col2 = (vertical ? col1 : (col1 + count - 1));
            int row2 = (vertical ? (row1 + count - 1) : row1);
            AutoFillSeries(worksheet, startNumber, GetRelAddress(col1, row1), GetRelAddress(col2, row2));
        }
        /// <summary>
        /// 일련번호로 자동 채우기한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="startNumber">채우기 시작 값</param>
        /// <param name="fromCell">시작 셀의 좌표</param>
        /// <param name="toCell">끝 셀의 좌표</param>
        public static void AutoFillSeries(Excel.Worksheet worksheet, int startNumber, string fromCell, string toCell)
        {
            Excel.Range objRefRng = null;
            Excel.Range objRng = null;

            try
            {
                objRefRng = worksheet.get_Range(fromCell, Type.Missing);
                objRng = worksheet.get_Range(fromCell, toCell);

                AutoFillSeries(objRefRng, objRng, startNumber);
            }
            finally
            {
                if (objRefRng != null) { Marshal.ReleaseComObject(objRefRng); objRefRng = null; }
                if (objRng != null) { Marshal.ReleaseComObject(objRng); objRng = null; }
            }
        }
        /// <summary>
        /// 일련번호로 자동 채우기한다.
        /// </summary>
        /// <param name="refRng">채우기 시작 값 영역</param>
        /// <param name="rng">자동 채우기 영역</param>
        /// <param name="startNumber">채우기 시작 값</param>
        public static void AutoFillSeries(Excel.Range refRng, Excel.Range rng, int startNumber)
        {
            refRng.Value2 = startNumber;

            if ((rng.Columns.Count == 1) && (rng.Rows.Count == 1))
                return;

            refRng.AutoFill(rng, Excel.XlAutoFillType.xlFillSeries);
        }
        /// <summary>
        /// 일련번호로 자동 채우기한다.
        /// </summary>
        /// <param name="refRng">채우기 시작 값 영역</param>
        /// <param name="rng">자동 채우기 영역</param>
        /// <param name="refValue">패턴을 가진 채우기 시작 값</param>
        public static void AutoFillSeries(Excel.Range refRng, Excel.Range rng, object[] refValue)
        {
            refRng.Value2 = refValue;
            refRng.AutoFill(rng, Excel.XlAutoFillType.xlFillSeries);
        }
        /// <summary>
        /// 워크북을 닫는다.
        /// </summary>
        /// <param name="workbook">대상 워크북</param>
        /// <param name="saveChages">변경내용을 저장할 지 여부</param>
        public static void Close(Excel.Workbook workbook, bool saveChages)
        {
            workbook.Close(saveChages, Type.Missing, Type.Missing);
        }
        /// <summary>
        /// 워크북을 복사한다.
        /// </summary>
        /// <param name="workbook">복사할 대상 워크북</param>
        /// <param name="fileName">복사한 워크북을 저장할 파일명(전체경로)</param>
        public static void Copy(Excel.Workbook workbook, string fileName)
        {
            workbook.SaveCopyAs(fileName);
        }
        /// <summary>
        /// 복사 후 모두 붙여넣기한다.
        /// </summary>
        /// <param name="refRng">복사할 영역</param>
        /// <param name="rng">붙여넣기할 영역</param>
        public static void CopyAndPasteAll(Excel.Range refRng, Excel.Range rng)
        {
            refRng.Copy(Type.Missing);
            rng.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
        }
        /// <summary>
        /// 복사 후 모두 붙여넣기한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="amount">붙여넣기할 횟수</param>
        /// <param name="col1">복사영역의 시작 열번호</param>
        /// <param name="col2">복사영역의 끝 열번호</param>
        public static void CopyAndPasteAll(Excel.Worksheet worksheet, int amount, int col1, int col2)
        {
            Excel.Range objRefRng = ExcelHelper.GetRange(worksheet, col1, col2, true);
            Excel.Range objWholeRng = objRefRng.get_Resize(Missing.Value, amount * (col2 - col1 + 1));
            Excel.Range objColumns = objWholeRng.Columns;
            Excel.Range objRng = null;
            objRefRng.Copy(Type.Missing);
            for (int i = 1; i <= amount; i++)
            {
                objRng = (Excel.Range)objColumns[(i * (col2 - col1 + 1)) + 1, Missing.Value];
                CopyAndPasteAll(objRefRng, objRng);
                ReleaseComObject(objRng);
            }
            ReleaseComObject(objColumns, objWholeRng, objRefRng);
        }
        /// <summary>
        /// 복사 후 데이터만 붙여넣기한다.
        /// </summary>
        /// <param name="refRng">복사할 영역</param>
        /// <param name="rng">붙여넣기할 영역</param>
        public static void CopyAndPasteDataOnly(Excel.Range refRng, Excel.Range rng)
        {
            refRng.Copy(Type.Missing);
            rng.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
        }
        /// <summary>
        /// 워크북을 생성한다.
        /// </summary>
        /// <param name="excel">엑셀 개체</param>
        /// <param name="fullPath">생성한 워크북을 저장할 전체 경로</param>
        /// <param name="sheetCount">생성한 워크북의 워크시트의 개수</param>
        /// <returns>생성한 워크북 개체</returns>
        public static Excel.Workbook Create(Excel.Application excel, string fullPath, int sheetCount)
        {
            Excel.Workbook objBook = null;
            Excel.Workbooks objBooks = null;
            Excel.Sheets objSheets = null;
            Excel.Worksheet objSheet = null;

            objBooks = excel.Workbooks;
            objBook = objBooks.Add(Type.Missing);
            excel.DisplayAlerts = false;
            objSheets = (Excel.Sheets)objBook.Worksheets;

            sheetCount = ((sheetCount < 1) ? 1 : sheetCount);
            if (objSheets.Count > sheetCount)
            {
                while (objSheets.Count > sheetCount)
                {
                    DeleteWorksheet(objBook, objBook.Worksheets.Count);
                }
            }
            if (objSheets.Count < sheetCount)
            {
                while (objSheets.Count < sheetCount)
                {
                    objSheet = AddWorksheet(objBook);
                    ReleaseComObject(objSheet);
                }
            }
            // if fullpath is empty, workbook will be returned without saving.
            if (!fullPath.Equals(string.Empty)) SaveAs(objBook, fullPath);
            ReleaseComObject(objSheets, objBooks);

            return objBook;
        }
        /// <summary>
        /// 워크북에서 워크시트를 삭제한다.
        /// </summary>
        /// <param name="workbook">대상 워크북</param>
        /// <param name="sheetIndex">삭제할 워크시트의 인덱스</param>
        public static void DeleteWorksheet(Excel.Workbook workbook, int sheetIndex)
        {
            Excel.Sheets objSheets = workbook.Worksheets;
            Excel.Worksheet objSheet = (Excel.Worksheet)objSheets[sheetIndex];

            objSheet.Delete();

            if (objSheet != null) Marshal.ReleaseComObject(objSheet);
            if (objSheets != null) Marshal.ReleaseComObject(objSheets);
        }
        /// <summary>
        /// 영역의 모든 경계선에 실선을 그린다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="col1">적용 영역의 시작 열번호</param>
        /// <param name="col2">적용 영역의 끝 열번호</param>
        /// <param name="row1">적용 영역의 시작 행번호</param>
        /// <param name="row2">적용 영역의 끝 행번호</param>
        public static void DrawFullLine(Excel.Worksheet worksheet, int col1, int col2, int row1, int row2)
        {
            Excel.Range objRange = GetRange(worksheet, col1, col2, row1, row2);
            DrawFullLine(objRange);

            if (objRange != null) Marshal.ReleaseComObject(objRange);
        }
        /// <summary>
        /// 영역의 모든 경계선에 실선을 그린다.
        /// </summary>
        /// <param name="rng">적용 영역</param>
        public static void DrawFullLine(Excel.Range rng)
        {
            Excel.Borders borders = rng.Borders;
            Excel.Border down = borders[Excel.XlBordersIndex.xlDiagonalDown];
            Excel.Border up = borders[Excel.XlBordersIndex.xlDiagonalUp];

            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
            borders.Weight = Excel.XlBorderWeight.xlThin;
            down.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            up.LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            if (down != null) Marshal.ReleaseComObject(down);
            if (up != null) Marshal.ReleaseComObject(up);
            if (borders != null) Marshal.ReleaseComObject(borders);
        }
        /// <summary>
        /// 좌표의 상대주소를 반환한다.
        /// </summary>
        /// <param name="col">좌표의 열번호</param>
        /// <param name="row">좌표의 행번호</param>
        /// <returns>상대주소</returns>
        public static string GetRelAddress(int col, int row)
        {
            col = ((col > 256) ? 256 : col); //Excel Last Column => 256(IV)
            int remainder = 0;
            int quotient = Math.DivRem(col - 1, 26, out remainder);
            string strFirst = ((quotient == 0) ? string.Empty : Convert.ToChar(quotient + 64).ToString());
            string strSecond = Convert.ToChar(remainder + 65).ToString();

            return string.Concat(strFirst, strSecond, row);
        }
        /// <summary>
        /// 좌표의 절대주소를 반환한다.
        /// </summary>
        /// <param name="col">좌표의 열번호</param>
        /// <param name="row">좌표의 행번호</param>
        /// <returns>절대주소</returns>
        public static string GetAbsAddress(int col, int row)
        {
            col = ((col > 256) ? 256 : col); //Excel Last Column => 256(IV)
            int remainder = 0;
            int quotient = Math.DivRem(col - 1, 26, out remainder);
            string strFirst = ((quotient == 0) ? string.Empty : Convert.ToChar(quotient + 64).ToString());
            string strSecond = Convert.ToChar(remainder + 65).ToString();

            return string.Concat("$", strFirst, strSecond, "$", row);
        }
        /// <summary>
        /// 좌표에 해당하는 셀 개체를 반환한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="col1">셀의 열번호</param>
        /// <param name="row1">셀의 행번호</param>
        /// <returns>Excel.Range형 셀 개체</returns>
        public static Excel.Range GetRange(Excel.Worksheet worksheet, int col1, int row1)
        {
            return GetRange(worksheet, GetRelAddress(col1, row1), Type.Missing);
        }
        /// <summary>
        /// 좌표에 해당하는 영역 개체를 반환한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="col1">좌표의 시작 셀의 열번호</param>
        /// <param name="col2">좌표의 끝 셀의 열번호</param>
        /// <param name="row1">좌표의 시작 셀의 행번호</param>
        /// <param name="row2">좌표의 끝 셀의 행번호</param>
        /// <returns>Excel.Range형 영역 개체</returns>
        public static Excel.Range GetRange(Excel.Worksheet worksheet, int col1, int col2, int row1, int row2)
        {
            return GetRange(worksheet, GetRelAddress(col1, row1), GetRelAddress(col2, row2));
        }
        /// <summary>
        /// 좌표에 해당하는 영역 개체를 반환한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="fromCell">시작 셀의 좌표</param>
        /// <param name="toCell">끝 셀의 좌표</param>
        /// <returns>Excel.Range형 영역 개체</returns>
        public static Excel.Range GetRange(Excel.Worksheet worksheet, object fromCell, object toCell)
        {
            return worksheet.get_Range(fromCell, toCell);
        }
        /// <summary>
        /// 좌표에 해당하는 행 개체를 반환한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="row">열번호</param>
        /// <returns>Excel.Range형 행 개체</returns>
        public static Excel.Range GetRange(Excel.Worksheet worksheet, int row)
        {
            return GetRange(worksheet, row, false);
        }
        /// <summary>
        /// 좌표에 해당하는 열 또는 행 개체를 반환한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="index">열번호 또는 행번호</param>
        /// <param name="isColumn">열 개체를 반환받고자 할 경우 true, 행 개체를 반환받고자 할 경우 false</param>
        /// <returns>Excel.Range형 열 또는 행 개체</returns>
        public static Excel.Range GetRange(Excel.Worksheet worksheet, int index, bool isColumn)
        {
            return GetRange(worksheet, index, index, isColumn);
        }
        /// <summary>
        /// 좌표에 해당하는 열 또는 행 개체를 반환한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="fromIndex">열번호 또는 행번호의 시작 위치</param>
        /// <param name="toIndex">열번호 또는 행번호의 끝 위치</param>
        /// <param name="isColumn">열 개체를 반환받고자 할 경우 true, 행 개체를 반환받고자 할 경우 false</param>
        /// <returns>Excel.Range형 열 또는 행 개체</returns>
        public static Excel.Range GetRange(Excel.Worksheet worksheet, int fromIndex, int toIndex, bool isColumn)
        {
            Excel.Range objRange = null;
            Excel.Range objRows = worksheet.Rows;
            Excel.Range objColumns = worksheet.Columns;
            Excel.Range objColumnOrRow = null;

            if (isColumn)
            {
                //				fromIndex = ((fromIndex < 1) ? 65 : fromIndex + 64);
                //				toIndex = ((toIndex < 1) ? 65 : toIndex + 64);
                //				string fromExp = string.Concat(Convert.ToChar(fromIndex), ":", Convert.ToChar(toIndex));
                //				objColumnOrRow = (Excel.Range)objColumns[fromExp, Missing.Value];

                objRange = (Excel.Range)objColumns[fromIndex, Type.Missing];
                objColumnOrRow = objRange.get_Resize(Type.Missing, toIndex - fromIndex + 1);
            }
            else
            {
                //				string fromExp = string.Concat(fromIndex,":",toIndex);
                //				objColumnOrRow = (Excel.Range)objRows[fromExp, Type.Missing];
                // Rows 로는 봔환안됨? 1:3 에러 발생
                string fromExp = (fromIndex == toIndex) ? fromIndex.ToString() : string.Concat(fromIndex, ":", toIndex);
                objColumnOrRow = (Excel.Range)objRows[fromExp, Type.Missing];
            }
            ReleaseComObject(objRange, objRows, objColumns);

            return objColumnOrRow;
        }
        /// <summary>
        /// 좌표에 해당하는 열 또는 행 개체를 반환한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="fromIndex">열번호 또는 행번호의 시작 위치</param>
        /// <param name="toIndex">열번호 또는 행번호의 끝 위치</param>
        /// <param name="isColumn">열 개체를 반환받고자 할 경우 true, 행 개체를 반환받고자 할 경우 false</param>
        /// <returns>Excel.Range형 열 또는 행 개체</returns>
        public static Excel.Range GetRange(Excel._Worksheet worksheet, int fromIndex, int toIndex, bool isColumn)
        {
            Excel.Range objRange = null;
            Excel.Range objRows = worksheet.Rows;
            Excel.Range objColumns = worksheet.Columns;
            Excel.Range objColumnOrRow = null;

            if (isColumn)
            {
                //				fromIndex = ((fromIndex < 1) ? 65 : fromIndex + 64);
                //				toIndex = ((toIndex < 1) ? 65 : toIndex + 64);
                //				string fromExp = string.Concat(Convert.ToChar(fromIndex), ":", Convert.ToChar(toIndex));
                //				objColumnOrRow = (Excel.Range)objColumns[fromExp, Missing.Value];

                objRange = (Excel.Range)objColumns[fromIndex, Type.Missing];
                objColumnOrRow = objRange.get_Resize(Type.Missing, toIndex - fromIndex + 1);
            }
            else
            {
                //				string fromExp = string.Concat(fromIndex,":",toIndex);
                //				objColumnOrRow = (Excel.Range)objRows[fromExp, Type.Missing];
                // Rows 로는 반환안됨? 1:3 에러 발생
                string fromExp = (fromIndex == toIndex) ? fromIndex.ToString() : string.Concat(fromIndex, ":", toIndex);
                objColumnOrRow = (Excel.Range)objRows[fromExp, Type.Missing];
            }
            ReleaseComObject(objRange, objRows, objColumns);

            return objColumnOrRow;
        }
        /// <summary>
        /// 해당 Cell에서 텍스트를 반환한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="col1">좌표의 열번호</param>
        /// <param name="row1">좌표의 행번호</param>
        /// <returns>Cell Text</returns>
        public static string GetValue(Excel.Worksheet worksheet, int col1, int row1)
        {
            string returnString = string.Empty;
            Excel.Range objRange = ExcelHelper.GetRange(worksheet, col1, row1);
            if (objRange.Value2 != null)
                returnString = objRange.Value2.ToString();
            ReleaseComObject(objRange);
            return returnString;
        }
        /// <summary>
        /// 세로방향으로 자동채우기로 값을 채운다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="startNumber">채우기 시작 값</param>
        /// <param name="count">실행 셀 수</param>
        /// <param name="firstCol">시작 셀의 열번호</param>
        /// <param name="firstRow">시작 셀의 행번호</param>
        public static void Fill(Excel.Worksheet worksheet, int startNumber, int count, int firstCol, int firstRow)
        {
            Fill(worksheet, startNumber, count, firstCol, firstRow, false);
        }
        /// <summary>
        /// 자동채우기로 값을 채운다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="startNumber">채우기 시작 값</param>
        /// <param name="count">실행 셀 수</param>
        /// <param name="col1">시작 셀의 열번호</param>
        /// <param name="row1">시작 셀의 행번호</param>
        /// <param name="vertical">세로방향으로 채우기를 실행할 지 여부</param>
        public static void Fill(Excel.Worksheet worksheet, int startNumber, int count, int col1, int row1, bool vertical)
        {
            AutoFillSeries(worksheet, startNumber, count, col1, row1, vertical);
        }
        /// <summary>
        /// 지정한 좌표에서부터 DataTable 값을 채운다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="dt">DataTable형 데이터</param>
        /// <param name="col1">좌표의 시작 열번호</param>
        /// <param name="row1">좌표의 시작 행번호</param>
        public static void Fill(Excel.Worksheet worksheet, DataTable dt, int col1, int row1)
        {
            for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
            {
                Fill(worksheet, dt.Rows[iRow].ItemArray, col1, row1 + iRow);
            }
        }
        /// <summary>
        /// 세로방향으로 지정한 좌표에서부터 object[] 값을 채운다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="data">object[]형 데이터</param>
        /// <param name="col1">좌표의 시작 열번호</param>
        /// <param name="row1">좌표의 시작 행번호</param>
        public static void Fill(Excel.Worksheet worksheet, object[] data, int col1, int row1)
        {
            Fill(worksheet, data, col1, row1, false);
        }
        /// <summary>
        /// 지정한 좌표에서부터 object[] 값을 채운다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="data">object[]형 데이터</param>
        /// <param name="col1">좌표의 시작 열번호</param>
        /// <param name="row1">좌표의 시작 행번호</param>
        /// <param name="vertical">세로방향으로 채우기를 실행할 지 여부</param>
        public static void Fill(Excel.Worksheet worksheet, object[] data, int col1, int row1, bool vertical)
        {
            //col1 = ((col1 < 1) ? 65 : col1 + 64);
            //row1 = ((row1 < 1) ? 1 : row1);
            //int col2 = (vertical ? col1 : (col1 + data.Length - 1));
            //int row2 = (vertical ? (row1 + data.Length - 1) : row1);
            //string fromCell = Convert.ToChar(col1).ToString() + row1.ToString();
            //string toCell = Convert.ToChar(col2).ToString() + row2.ToString();

            //Fill(worksheet, data, fromCell, toCell, vertical);

            int col2 = (vertical ? col1 : (col1 + data.Length - 1));
            int row2 = (vertical ? (row1 + data.Length - 1) : row1);

            Excel.Range objRange = GetRange(worksheet, col1, col2, row1, row2);
            if (vertical)
            {
                object[,] objData = new object[data.Length, 1];
                for (int i = 0; i < data.Length; i++) objData[i, 0] = data[i];
                objRange.Value2 = objData;
            }
            else objRange.Value2 = data;

            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 세로방향으로 지정한 좌표에서부터 object[] 값을 채운다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="data">object[]형 데이터</param>
        /// <param name="fromCell">시작 셀의 좌표</param>
        /// <param name="toCell">끝 셀의 좌표</param>
        public static void Fill(Excel.Worksheet worksheet, object[] data, object fromCell, object toCell)
        {
            Fill(worksheet, data, fromCell, toCell, false);
        }
        /// <summary>
        /// 지정한 좌표에서부터 object[] 값을 채운다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="data">object[]형 데이터</param>
        /// <param name="fromCell">시작 셀의 좌표</param>
        /// <param name="toCell">끝 셀의 좌표</param>
        /// <param name="vertical">세로방향으로 채우기를 실행할 지 여부</param>
        public static void Fill(Excel.Worksheet worksheet, object[] data, object fromCell, object toCell, bool vertical)
        {
            Excel.Range objRange = GetRange(worksheet, fromCell, toCell);
            if (vertical)
            {
                object[,] objData = new object[data.Length, 1];
                for (int i = 0; i < data.Length; i++) objData[i, 0] = data[i];
                objRange.Value2 = objData;
            }
            else objRange.Value2 = data;

            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 셀에 값을 채운다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="data">값</param>
        /// <param name="col1">값을 채울 셀의 열번호</param>
        /// <param name="row1">값을 채울 셀의 행번호</param>
        public static void Fill(Excel.Worksheet worksheet, object data, int col1, int row1)
        {
            Excel.Range objRange = GetRange(worksheet, col1, row1);
            Fill(objRange, data);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 영역에 값을 채운다.
        /// </summary>
        /// <param name="rng">값을 채울 영역</param>
        /// <param name="data">값</param>
        public static void Fill(Excel.Range rng, object data)
        {
            rng.Value2 = data;
        }
        /// <summary>
        /// 워크시트에 열을 추가한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="amount">추가할 열 수</param>
        /// <param name="col">열을 추가할 위치</param>
        public static void InsertColumns(Excel.Worksheet worksheet, int amount, int col)
        {
            Excel.Range objRange = ExcelHelper.GetRange(worksheet, col, true);
            InsertColumns(objRange, amount);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 워크시트에 열을 추가한다.
        /// </summary>
        /// <param name="rng">열을 추가할 영역</param>
        /// <param name="amount">추가할 열 수</param>
        public static void InsertColumns(Excel.Range rng, int amount)
        {
            rng.Copy(Type.Missing);
            for (int i = 0; i < amount; i++)
            {
                rng.Insert(Excel.XlDirection.xlToRight, Type.Missing);
            }
        }
        /// <summary>
        /// 워크시트에 행을 추가한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="rowCount">추가할 행 개수</param>
        /// <param name="row">행을 추가할 위치</param>
        public static void InsertRows(Excel.Worksheet worksheet, int rowCount, int row)
        {
            //			Excel.Range objRange = ExcelHelper.GetRange(worksheet, row);
            //			Excel.Range objRangeInserted = null;
            //			objRange.Copy(Type.Missing);
            //			for(int i = 0 ; i < rowCount ; i++)
            //			{
            //				objRangeInserted = objRange.Insert(Excel.XlDirection.xlDown, Type.Missing);
            //			}
            //			ReleaseComObject(objRange);
            //
            //			return objRangeInserted;
        }
        public static void NewRows(Excel.Worksheet worksheet, int rowCount, int row)
        {
            Excel.Range objRange = ExcelHelper.GetRange(worksheet, row);
            NewRows(objRange, rowCount);
            ReleaseComObject(objRange);
        }

        public static void NewRows(Excel.Range rng, int rowCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                rng.Insert(Excel.XlDirection.xlDown, Type.Missing);
            }
        }
        /// <summary>
        /// 좌표 영역을 병합한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="col1">병합 영역의 시작 열번호</param>
        /// <param name="col2">병합 영역의 끝 열번호</param>
        /// <param name="row1">병합 영역의 시작 행번호</param>
        /// <param name="row2">병합 영역의 끝 행번호</param>
        public static void MergeRange(Excel.Worksheet worksheet, int col1, int col2, int row1, int row2)
        {
            Excel.Range objRange = GetRange(worksheet, col1, col2, row1, row2);
            MergeRange(objRange);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 영역을 병합한다.
        /// </summary>
        /// <param name="rng">병합할 영역</param>
        public static void MergeRange(Excel.Range rng)
        {
            rng.Merge(Type.Missing);
        }
        /// <summary>
        /// 워크북을 연다
        /// </summary>
        /// <param name="workbooks">엑셀의 워크북 개체</param>
        /// <param name="fullPath">열기할 워크북 경로</param>
        /// <returns>열기한 워크북 개체</returns>
        public static Excel.Workbook Open(Excel.Workbooks workbooks, string fullPath)
        {
            Excel.Workbook objBook = workbooks.Open(fullPath,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            return objBook;
        }
        /// <summary>
        /// COM 개체를 해제한다.
        /// </summary>
        /// <param name="comObjects">COM 개체들</param>
        /// <returns>해제된 COM 개체수(NULL인 COM 개체는 포함하지 않음)</returns>
        public static int ReleaseComObject(params object[] comObjects)
        {
            int iReleasedCount = 0;
            for (int i = 0; i < comObjects.Length; i++)
            {
                if (comObjects[i] != null)
                {
                    Marshal.ReleaseComObject(comObjects[i]);
                    iReleasedCount++;
                }
            }
            return iReleasedCount;
        }
        /// <summary>
        /// 워크북을 저장한다.
        /// </summary>
        /// <param name="workbook">저장할 워크북</param>
        public static void Save(Excel.Workbook workbook)
        {
            workbook.Save();
        }
        /// <summary>
        /// 워크북을 다른 이름으로 저장한다.
        /// </summary>
        /// <param name="workbook">저장할 워크북</param>
        /// <param name="fullPath">새로운 저장 경로</param>
        public static void SaveAs(Excel.Workbook workbook, string fullPath)
        {
            workbook.SaveAs(fullPath, Excel.XlFileFormat.xlWorkbookNormal,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
        /// <summary>
        /// 배경 서식을 지정한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="pattern">Excel.XlPattern 형 패턴</param>
        /// <param name="bgColor">배경색</param>
        /// <param name="col1">서식 적용 영역의 시작 열번호</param>
        /// <param name="col2">서식 적용 영역의 끝 열번호</param>
        /// <param name="row1">서식 적용 영역의 시작 행번호</param>
        /// <param name="row2">서식 적용 영역의 끝 행번호</param>
        public static void SetBgStyle(Excel.Worksheet worksheet, Excel.XlPattern pattern, Color bgColor, int col1, int col2, int row1, int row2)
        {
            Excel.Range objRange = ExcelHelper.GetRange(worksheet, col1, col2, row1, row2);
            SetBgStyle(objRange, pattern, bgColor);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 배경 서식을 지정한다.
        /// </summary>
        /// <param name="rng">배경 서식을 적용할 영역</param>
        /// <param name="pattern">Excel.XlPattern 형 패턴</param>
        /// <param name="bgColor">배경색</param>
        public static void SetBgStyle(Excel.Range rng, Excel.XlPattern pattern, Color bgColor)
        {
            Excel.Interior objInterior = rng.Interior;
            objInterior.Pattern = pattern;
            objInterior.Color = ColorTranslator.ToOle(bgColor);
            ReleaseComObject(objInterior);
        }
        /// <summary>
        /// 폰트 서식를 지정한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="fontName">폰트 이름</param>
        /// <param name="fontSize">폰트 크기</param>
        /// <param name="bold">굵게 표시 여부</param>
        /// <param name="underline">밑줄 표시 여부</param>
        /// <param name="col1">서식 적용 영역의 시작 열번호</param>
        /// <param name="col2">서식 적용 영역의 끝 열번호</param>
        /// <param name="row1">서식 적용 영역의 시작 행번호</param>
        /// <param name="row2">서식 적용 영역의 끝 행번호</param>
        public static void SetFont(Excel.Worksheet worksheet, string fontName, double fontSize, bool bold, bool underline, int col1, int col2, int row1, int row2)
        {
            Excel.Range objRange = ExcelHelper.GetRange(worksheet, col1, col2, row1, row2);
            SetFont(objRange, fontName, fontSize, bold, underline, Excel.XlHAlign.xlHAlignGeneral);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 폰트 서식를 지정한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="fontName">폰트 이름</param>
        /// <param name="fontSize">폰트 크기</param>
        /// <param name="bold">굵게 표시 여부</param>
        /// <param name="underline">밑줄 표시 여부</param>
        /// <param name="col1">서식 적용 영역의 시작 열번호</param>
        /// <param name="col2">서식 적용 영역의 끝 열번호</param>
        /// <param name="row1">서식 적용 영역의 시작 행번호</param>
        /// <param name="row2">서식 적용 영역의 끝 행번호</param>
        /// <param name="hAlign">가로 맞춤 방식</param>
        public static void SetFont(Excel.Worksheet worksheet, string fontName, double fontSize, bool bold, bool underline, int col1, int col2, int row1, int row2, Excel.XlHAlign hAlign)
        {
            Excel.Range objRange = ExcelHelper.GetRange(worksheet, col1, col2, row1, row2);
            SetFont(objRange, fontName, fontSize, bold, underline, hAlign);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 폰트 서식를 지정한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="fontName">폰트 이름</param>
        /// <param name="fontSize">폰트 크기</param>
        /// <param name="bold">굵게 표시 여부</param>
        /// <param name="underline">밑줄 표시 여부</param>
        /// <param name="fromCell">서식 적용 시작 셀의 좌표</param>
        /// <param name="toCell">서식 적용 끝 셀의 좌표</param>
        public static void SetFont(Excel.Worksheet worksheet, string fontName, double fontSize, bool bold, bool underline, string fromCell, string toCell)
        {
            Excel.Range objRange = ExcelHelper.GetRange(worksheet, fromCell, toCell);
            SetFont(objRange, fontName, fontSize, bold, underline, Excel.XlHAlign.xlHAlignGeneral);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 폰트 서식를 지정한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="fontName">폰트 이름</param>
        /// <param name="fontSize">폰트 크기</param>
        /// <param name="bold">굵게 표시 여부</param>
        /// <param name="underline">밑줄 표시 여부</param>
        /// <param name="fromCell">서식 적용 시작 셀의 좌표</param>
        /// <param name="toCell">서식 적용 끝 셀의 좌표</param>
        /// <param name="hAlign">가로 맞춤 방식/param>
        public static void SetFont(Excel.Worksheet worksheet, string fontName, double fontSize, bool bold, bool underline, string fromCell, string toCell, Excel.XlHAlign hAlign)
        {
            Excel.Range objRange = ExcelHelper.GetRange(worksheet, fromCell, toCell);
            SetFont(objRange, fontName, fontSize, bold, underline, hAlign);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 폰트 서식를 지정한다.
        /// </summary>
        /// <param name="rng">폰트 서식을 적용할 영역</param>
        /// <param name="fontName">폰트 이름</param>
        /// <param name="fontSize">폰트 크기</param>
        /// <param name="bold">굵게 표시 여부</param>
        /// <param name="underline">밑줄 표시 여부</param>
        public static void SetFont(Excel.Range rng, string fontName, double fontSize, bool bold, bool underline)
        {
            SetFont(rng, fontName, fontSize, bold, underline, Excel.XlHAlign.xlHAlignGeneral);
        }
        /// <summary>
        /// 폰트 서식를 지정한다.
        /// </summary>
        /// <param name="rng">폰트 서식을 적용할 영역</param>
        /// <param name="fontName">폰트 이름</param>
        /// <param name="fontSize">폰트 크기</param>
        /// <param name="bold">굵게 표시 여부</param>
        /// <param name="underline">밑줄 표시 여부</param>
        /// <param name="hAlign">가로 맞춤 방식</param>
        public static void SetFont(Excel.Range rng, string fontName, double fontSize, bool bold, bool underline, Excel.XlHAlign hAlign)
        {
            rng.HorizontalAlignment = hAlign;

            Excel.Font objFont = rng.Font;
            objFont.Name = fontName;
            objFont.Size = fontSize;
            objFont.Bold = bold;
            objFont.Underline = underline;
            rng.WrapText = true;

            ReleaseComObject(objFont);
        }
        /// <summary>
        /// 공식을 지정한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="formula">공식</param>
        /// <param name="col1">공식 지정 셀의 시작 열번호</param>
        /// <param name="row1">공식 지정 셀의 시작 행번호</param>
        public static void SetFormula(Excel.Worksheet worksheet, string formula, int col1, int row1)
        {
            Excel.Range objRange = GetRange(worksheet, col1, row1);
            SetFormula(objRange, formula);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 공식을 지정한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="formula">공식</param>
        /// <param name="col1">공식 지정 영역의 시작 열번호</param>
        /// <param name="col2">공식 지정 영역의 끝 열번호</param>
        /// <param name="row1">공식 지정 영역의 시작 행번호</param>
        /// <param name="row2">공식 지정 영역의 끝 행번호</param>
        public static void SetFormula(Excel.Worksheet worksheet, string formula, int col1, int col2, int row1, int row2)
        {
            Excel.Range objRange = GetRange(worksheet, col1, col2, row1, row2);
            SetFormula(objRange, formula);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 공식을 지정한다.
        /// </summary>
        /// <param name="rng">공식을 지정할 영역</param>
        /// <param name="formula">공식</param>
        public static void SetFormula(Excel.Range rng, string formula)
        {
            rng.Formula = formula;
        }
        /// <summary>
        /// 표시형식을 지정한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="format">표시형식</param>
        /// <param name="col1">형식 지정 영역의 시작 열번호</param>
        /// <param name="col2">형식 지정 영역의 끝 열번호</param>
        /// <param name="row1">형식 지정 영역의 시작 행번호</param>
        /// <param name="row2">형식 지정 영역의 끝 행번호</param>
        public static void SetNumberFormat(Excel.Worksheet worksheet, string format, int col1, int col2, int row1, int row2)
        {
            Excel.Range objRange = GetRange(worksheet, col1, col2, row1, row2);
            SetNumberFormat(objRange, format);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 표시형식을 지정한다.
        /// </summary>
        /// <param name="rng">형식을 지정할 영역</param>
        /// <param name="format">표시형식</param>
        public static void SetNumberFormat(Excel.Range rng, string format)
        {
            rng.NumberFormat = format;
        }
        /// <summary>
        /// 열너비와 행높이를 설정한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="width">열너비</param>
        /// <param name="height">행높이</param>
        /// <param name="fromCell">시작 셀의 좌표</param>
        /// <param name="toCell">끝 셀의 좌표</param>
        public static void SetSize(Excel.Worksheet worksheet, double width, double height, string fromCell, string toCell)
        {
            Excel.Range objRange = GetRange(worksheet, fromCell, toCell);
            SetSize(objRange, width, height);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 열너비와 행높이를 설정한다.
        /// </summary>
        /// <param name="rng">대상 영역</param>
        /// <param name="width">열너비</param>
        /// <param name="height">행높이</param>
        public static void SetSize(Excel.Range rng, double width, double height)
        {
            SetWidth(rng, width);
            SetHeight(rng, height);
        }
        /// <summary>
        /// 열너비를 설정한다.
        /// </summary>
        /// <param name="rng">대상 영역</param>
        /// <param name="width">열너비</param>
        public static void SetWidth(Excel.Range rng, double width)
        {
            rng.ColumnWidth = width;
        }
        /// <summary>
        /// 행높이를 설정한다.
        /// </summary>
        /// <param name="rng">대상 영역</param>
        /// <param name="height">행높이</param>
        public static void SetHeight(Excel.Range rng, double height)
        {
            rng.RowHeight = height;
        }
        /// <summary>
        /// 매크로를 실행한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="col1">매크로 적용 영역의 시작 열번호</param>
        /// <param name="col2">매크로 적용 영역의 끝 열번호</param>
        /// <param name="row1">매크로 적용 영역의 시작 행번호</param>
        /// <param name="row2">매크로 적용 영역의 끝 행번호</param>
        /// <param name="macroName">매크로명</param>
        public static void RunMacro(Excel.Worksheet worksheet, int col1, int col2, int row1, int row2, string macroName)
        {
            Excel.Range objRange = GetRange(worksheet, col1, col2, row1, row2);
            RunMacro(worksheet, objRange, macroName);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 매크로를 실행한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="rng">매크로를 적용할 영역</param>
        /// <param name="macroName">매크로명</param>
        public static void RunMacro(Excel.Worksheet worksheet, Excel.Range rng, string macroName)
        {
            Excel.Application excel = worksheet.Application;
            rng.Select();
            excel.Run(macroName,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            ReleaseComObject(excel);
        }
        /// <summary>
        /// 좌표 영역의 병합을 해제한다.
        /// </summary>
        /// <param name="worksheet">대상 워크시트</param>
        /// <param name="col1">병합 영역의 시작 열번호</param>
        /// <param name="col2">병합 영역의 끝 열번호</param>
        /// <param name="row1">병합 영역의 시작 행번호</param>
        /// <param name="row2">병합 영역의 끝 행번호</param>
        public static void UnMergeRange(Excel.Worksheet worksheet, int col1, int col2, int row1, int row2)
        {
            Excel.Range objRange = GetRange(worksheet, col1, col2, row1, row2);
            UnMergeRange(objRange);
            ReleaseComObject(objRange);
        }
        /// <summary>
        /// 영역의 병합을 해제한다.
        /// </summary>
        /// <param name="rng">병합된 영역</param>
        public static void UnMergeRange(Excel.Range rng)
        {
            rng.UnMerge();
        }

        public static void AddShape(Excel.Worksheet worksheet, Office.MsoAutoShapeType type, float left, float top, float width, float height, Color backColor, Color lineColor, string text)
        {
            Excel.Shapes objShapes = worksheet.Shapes;
            Excel.Shape objShape = objShapes.AddShape(type, left, top, width, height);
            Excel.FillFormat objFillFormat = objShape.Fill;
            objFillFormat.Visible = Office.MsoTriState.msoTrue;
            objFillFormat.Solid();
            Excel.ColorFormat objColorFormat = objFillFormat.ForeColor;
            objColorFormat.RGB = ColorTranslator.ToOle(backColor);
            objFillFormat.Transparency = 0f;
            Excel.LineFormat objLineFormat = objShape.Line;
            objLineFormat.Weight = 0.75f;
            objLineFormat.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
            objLineFormat.Style = Office.MsoLineStyle.msoLineSingle;
            objLineFormat.Transparency = 0f;
            objLineFormat.Visible = Office.MsoTriState.msoTrue;
            ReleaseComObject(objColorFormat, objFillFormat);
            objColorFormat = objLineFormat.ForeColor;
            objColorFormat.RGB = ColorTranslator.ToOle(lineColor);
            Excel.TextFrame objTextFrame = objShape.TextFrame;
            Excel.Characters objCharacters = objTextFrame.Characters(1, text.Length);
            objCharacters.Text = text;
            Excel.Font objFont = objCharacters.Font;
            objFont.Name = "휴먼옛체";
            objFont.FontStyle = "굵게";
            objFont.Size = 20;
            objFont.Strikethrough = false;
            objFont.Superscript = false;
            objFont.OutlineFont = false;
            objFont.Shadow = false;
            objFont.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleNone;
            objFont.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
            objTextFrame.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            objShape.ZOrder(Office.MsoZOrderCmd.msoBringToFront);
            ReleaseComObject(objColorFormat, objLineFormat);
            ReleaseComObject(objFont, objCharacters, objTextFrame);
            ReleaseComObject(objShape, objShapes);
        }

        #region 보류중...VBProject 객체 프로그래밍 방식으로 처리 안됨..왜?
        public static void AddMacro(Excel.Workbook workbook, string macroCode)
        {
            //			VBComponent objMacro = workbook.VBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule);
            //			objMacro.CodeModule.AddFromString(macroCode);
            //			objMacro = null;
        }

        public static void DeleteMacro(Excel.Workbook workbook)
        {
            //			VBComponents components = null;
            //			try
            //			{
            //				components = workbook.VBProject.VBComponents;
            //				int iComponenetCount = workbook.VBProject.VBComponents.Count;
            //				for(int i = iComponenetCount-1 ; i >= 0; i--)
            //				{
            //					components.Remove(components.Item(i));
            //				}
            //			}
            //			catch(Exception ex)
            //			{
            //				HttpContext.Current.Response.Write(ex.ToString());
            //			}
            //			components = null;
        }
        #endregion 보류중...VBProject 객체 프로그래밍 방식으로 처리 안됨..왜?
    }
}