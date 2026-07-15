//-----------------------------------------------------------------------------
//
//   System      : MES Report
//   File Name   : 
//   Description : Client Common function Module 
//
//   MES Version : 4.x.x.x
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2010-05-18 : Created by Hide
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using System.Windows.Forms;
using Miracom.CliFrx;

namespace SOI.OIFrx
{
    public enum Align { Center, Left, Right };
    public enum Visibles { True, False };
    public enum Frozen { True, False };
    public enum Merge { True, False, Left, Always };
    public enum Formatter { Number, Double1, Double2, Double3, Long, String, Percent, PercentDouble, PercentDouble2, Image };

    public class udcSpread2 : FarPoint.Win.Spread.FpSpread
    {
		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));

		}
		#endregion

        #region [ Spread Variable Definition ]

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private ArrayList _cellType = new ArrayList(10);
        private static FarPoint.Win.Spread.CellType.NumberCellType _number;
        private static FarPoint.Win.Spread.CellType.TextCellType _text;
        private static FarPoint.Win.Spread.CellType.NumberCellType _double1;
        private static FarPoint.Win.Spread.CellType.NumberCellType _double2;
        private static FarPoint.Win.Spread.CellType.NumberCellType _double3;
        private static FarPoint.Win.Spread.CellType.NumberCellType _long;
        private static FarPoint.Win.Spread.CellType.PercentCellType _percent;
        private static FarPoint.Win.Spread.CellType.PercentCellType _percentDouble;
        private static FarPoint.Win.Spread.CellType.PercentCellType _percentDouble2;        
        private static FarPoint.Win.Spread.CellType.ImageCellType _image;
        private bool isFirstAdded;
        private bool isPreCellsType = true; // 셀타입을 지정할는것을 수동으로 하고 싶을때 false 주면 됨..
        private DataTable dtNote = null;

        // 이값 이하는 blank 로 만듬.
        //private double RoundValue = 0.0009;
        //private double RoundValueMinus = -0.0009;
        //private double RoundValue2 = 0.009;
        //private double RoundValue2Minus = -0.009;
        //private double RoundValue2Per = 0.0009;
        //private double RoundValue2PerMinus = -0.0009;
        //private double RoundValue2Double1 = 0.04;
        //private double RoundValue2Double1Minus = -0.04;
        //private double RoundValue2Double2 = 0.004;
        //private double RoundValue2Double2Minus = -0.004;
        //private double RoundValue2Double3 = 0.0004;
        //private double RoundValue2Double3Minus = -0.0004;
        //private long RoundValue2Long = 0;
        //private long RoundValue2LongMinus = -0;
        #endregion

        #region [ Spread Creater ]

        public udcSpread2(System.ComponentModel.IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            PreDefinedCellType();
        }

        public udcSpread2()
        {
            InitializeComponent();
            PreDefinedCellType();

        }

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region [ Spread Common Method ]

        /// <summary>
        /// Spread Sheet에 DataSource Binding
        /// </summary>
        public new object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;
                if (isPreCellsType)
                {
                    // AutoGernerationColumn 이 true 이 상황에서
                    // 데이타 바인딩 전에 하면 실제로 적용이 안됨
                    // 데이타 바인딩 이후에 실제로 셀타입을 지정하기 위하여
                    RPT_SetCellsType();
                }
            }
        }

        /// <summary>
        /// CellType 을 먼저 정의해 놓은 부분
        /// </summary>
        private void PreDefinedCellType()
        {
            if (_number == null)
            {
                _number = new FarPoint.Win.Spread.CellType.NumberCellType();
                _number.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                _number.DecimalPlaces = 0;
                _number.DropDownButton = false;
                _number.MaximumValue = 9999999999;
                _number.MinimumValue = -9999999999;
                _number.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.No;
                _number.Separator = ",";
                _number.ShowSeparator = true;
                _number.NegativeRed = true;

                _text = new FarPoint.Win.Spread.CellType.TextCellType();
            }

            if (_double1 == null)
            {
                _double1 = new FarPoint.Win.Spread.CellType.NumberCellType();
                _double1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                _double1.DecimalPlaces = 1;
                _double1.DropDownButton = false;
                _double1.MaximumValue = 99999999999.9;
                _double1.MinimumValue = -99999999999.9;
                _double1.Separator = ",";
                _double1.ShowSeparator = true;
                _double1.NegativeRed = true;
            }

            if (_double2 == null)
            {
                _double2 = new FarPoint.Win.Spread.CellType.NumberCellType();
                _double2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                _double2.DecimalPlaces = 2;
                _double2.DropDownButton = false;
                _double2.MaximumValue = 99999999999.99;
                _double2.MinimumValue = -99999999999.99;
                _double2.Separator = ",";
                _double2.ShowSeparator = true;
                _double2.NegativeRed = true;
            }

            if (_double3 == null)
            {
                _double3 = new FarPoint.Win.Spread.CellType.NumberCellType();
                _double3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                _double3.DecimalPlaces = 3;
                _double3.DropDownButton = false;
                _double3.MaximumValue = 99999999999.999;
                _double3.MinimumValue = -99999999999.999;
                _double3.Separator = ",";
                _double3.ShowSeparator = true;
                _double3.NegativeRed = true;
            }

            if (_long == null)
            {
                _long = new FarPoint.Win.Spread.CellType.NumberCellType();
                _long.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                _long.DecimalPlaces = 0;
                _long.DropDownButton = false;
                _long.MaximumValue = 99999999999999;
                _long.MinimumValue = -99999999999999;
                _long.Separator = ",";
                _long.ShowSeparator = true;
                _long.NegativeRed = true;
            }

            if (_percent == null)
            {
                _percent = new FarPoint.Win.Spread.CellType.PercentCellType();
                _percent.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                _percent.DecimalPlaces = 0;
                _percent.DecimalSeparator = ".";
                _percent.DropDownButton = false;
                _percent.WordWrap = true;
                _percent.PercentSign = "%";
                _percent.Separator = ",";
                _percent.ShowSeparator = true;
                _percent.NegativeRed = true;
            }

            if (_percentDouble == null)
            {
                _percentDouble = new FarPoint.Win.Spread.CellType.PercentCellType();
                _percentDouble.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                _percentDouble.DropDownButton = false;
                _percentDouble.PercentSign = "%";
                _percentDouble.Separator = ",";
                _percentDouble.DecimalPlaces = 1;
                _percentDouble.ShowSeparator = true;
                _percentDouble.NegativeRed = true;
            }

            if (_percentDouble2 == null)
            {
                _percentDouble2 = new FarPoint.Win.Spread.CellType.PercentCellType();
                _percentDouble2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                _percentDouble2.DropDownButton = false;
                _percentDouble2.PercentSign = "%";
                _percentDouble2.Separator = ",";
                _percentDouble2.DecimalPlaces = 3;
                _percentDouble2.ShowSeparator = true;
                _percentDouble2.NegativeRed = true;
            }

            if (_image == null)
            {
                _image = new FarPoint.Win.Spread.CellType.ImageCellType();
                _image.Style = FarPoint.Win.RenderStyle.Stretch;
            }

        }

        private void InitNoteTable()
        {
            DataColumn column;

            if (dtNote != null)
            {
                dtNote.Dispose();
            }

            dtNote = new DataTable("NoteInfo");

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Row";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            dtNote.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Col";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            dtNote.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Note";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            dtNote.Columns.Add(column);

            System.Data.DataSet dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(dtNote);
        }

        /// <summary>
        /// 셀타입을 리턴해주는 메소드
        /// </summary>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public FarPoint.Win.Spread.CellType.ICellType getCellType(Formatter formatter)
        {
            if (formatter == Formatter.Number)
                return _number;
            else if (formatter == Formatter.Double1)
                return _double1;
            else if (formatter == Formatter.Double2)
                return _double2;
            else if (formatter == Formatter.Double3)
                return _double3;
            else if (formatter == Formatter.Long)
                return _long;
            else if (formatter == Formatter.Percent)
                return _percent;
            else if (formatter == Formatter.PercentDouble)
                return _percentDouble;
            else if (formatter == Formatter.PercentDouble2)
                return _percentDouble2;
            else if (formatter == Formatter.Image)
                return _image;
            else
                return _text;
        }

        private void SetNoteInfo()
        {
            int iRow = 0;
            int iCol = 0;
            string sNote = "";

            //Data가 있는경우만 Note정보 표시해줌.
            if (this.ActiveSheet.RowCount > 0)
            {
                for (int i = 0; i < dtNote.Rows.Count; i++)
                {
                    sNote = dtNote.Rows[i][2].ToString().TrimEnd();

                    if (sNote != "")
                    {
                        iRow = Convert.ToInt16(dtNote.Rows[i][0]);
                        iCol = Convert.ToInt16(dtNote.Rows[i][1]);

                        this.ActiveSheet.ColumnHeader.Cells.Get(iRow, iCol).Note = sNote;
                        this.ActiveSheet.ColumnHeader.Cells.Get(iRow, iCol).NoteIndicatorSize = new System.Drawing.Size(5, 5);
                    }
                }
            }
        }

        private int[] BubbleSort(int[] Source, bool Desc)
        {
            int i;
            int j;
            int temp;

            for (i = (Source.Length - 1); i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (Desc == true)
                    {
                        if (Source[j - 1] < Source[j])
                        {
                            temp = Source[j - 1];
                            Source[j - 1] = Source[j];
                            Source[j] = temp;
                        }
                    }
                    else
                    {
                        if (Source[j - 1] > Source[j])
                        {
                            temp = Source[j - 1];
                            Source[j - 1] = Source[j];
                            Source[j] = temp;
                        }
                    }
                }
            }
            return Source;
        }

        /// <summary>
        /// 원본 DataTable로 SubTotal 및 Total을 계산하여 결과를 DataTable로 반환한다.
        /// </summary>
        /// <param name="dt">원본 DataTable</param>
        /// <param name="TargetSubTotalColumns">계산할 기준값</param>
        /// <param name="StartColumnIndex">계산될 시작 Column Index</param>
        /// <param name="EndColumnIndex">계산될 마지막 Column Index</param>
        /// <returns>원본 DataTable에 SubTotal과 Total값을 포함한 DataTable</returns>
        private DataTable GetSubTotalDataTable(DataTable dt, int[] TargetSubTotalColumns, int StartColumnIndex, int EndColumnIndex)
        {
            try
            {
                DataTable dtResult = new DataTable();
                int[] iSubRowIndex = new int[TargetSubTotalColumns.Length]; // SubTotal결과 추가 후 다음 시작될 Row값을 저장
                //int[] iSubTotal = new int[TargetSubTotalColumns.Length];

                double[] dSubTotal = new double[TargetSubTotalColumns.Length];

                string[] sCurTargetColumn = new string[TargetSubTotalColumns.Length];
                string[] sNewTargetColumn = new string[TargetSubTotalColumns.Length];

                BubbleSort(TargetSubTotalColumns, true);

                for (int i = 0; i < dt.Columns.Count; i++)
                    dtResult.Columns.Add(dt.Columns[i].Caption, dt.Columns[i].DataType);

                for (int i = 0; i < iSubRowIndex.Length; i++)
                    iSubRowIndex[i] = 0;

                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    for (int iTargetCol = 0; iTargetCol < TargetSubTotalColumns.Length; iTargetCol++)
                        sNewTargetColumn[iTargetCol] = Convert.ToString(dt.Rows[iRow][TargetSubTotalColumns[iTargetCol]]); // 원본 DT의 Target Column값을 저장

                    for (int iTargetCol = 0; iTargetCol < TargetSubTotalColumns.Length; iTargetCol++)
                    {
                        bool bColumnDiff = false;
                        for (int i = iTargetCol; i < TargetSubTotalColumns.Length; i++)
                        {
                            if (iRow == 0 || sCurTargetColumn[i].ToString() != sNewTargetColumn[i].ToString())
                                bColumnDiff = true;
                        }

                        // 현재 Target Column의 값과 새로운 Target Column의 값을 비교하여 다르면 현재까지의 Row까지 Sub Total을 구한다.
                        if (bColumnDiff == true)
                        {
                            sCurTargetColumn[iTargetCol] = sNewTargetColumn[iTargetCol].ToString();
                            if (iRow != 0)
                            {
                                DataRow SubTotRow = null;
                                SubTotRow = dtResult.NewRow();
                                SubTotRow[0] = " ";
                                dtResult.Rows.Add(SubTotRow);
                                if (TargetSubTotalColumns[iTargetCol] != 0)
                                {
                                    for (int i = 0; i < TargetSubTotalColumns[iTargetCol]; i++)
                                        dtResult.Rows[dtResult.Rows.Count - 1][i] = dt.Rows[iRow - 1][i].ToString();
                                }
                                dtResult.Rows[dtResult.Rows.Count - 1][TargetSubTotalColumns[iTargetCol]] = dt.Rows[iRow - 1][TargetSubTotalColumns[iTargetCol]].ToString() + " Total";

                                for (int iCalcCol = StartColumnIndex; iCalcCol < EndColumnIndex + 1; iCalcCol++)
                                {
                                    //iSubTotal[iTargetCol] = 0;
                                    dSubTotal[iTargetCol] = 0;
                                    for (int k = iSubRowIndex[iTargetCol]; k < dtResult.Rows.Count - 1; k++)
                                    {
                                        bool bCheck = false;
                                        for (int j = 0; j < TargetSubTotalColumns.Length; j++)
                                        {
                                            if (dtResult.Rows[k][TargetSubTotalColumns[j]].ToString().EndsWith("Total"))
                                            {
                                                bCheck = true;
                                                break;
                                            }
                                        }
                                        if (bCheck == false)
                                        {
                                            //iSubTotal[iTargetCol] += Convert.ToInt32(dtResult.Rows[k][iCalcCol]);
                                            dSubTotal[iTargetCol] += Convert.ToDouble(dtResult.Rows[k][iCalcCol]);
                                        }
                                    }
                                    dtResult.Rows[dtResult.Rows.Count - 1][iCalcCol] = dSubTotal[iTargetCol];
                                }

                                iSubRowIndex[iTargetCol] = dtResult.Rows.Count;
                            }
                        }
                    }

                    // 원본 DT의 Data를 Result DataTable에 옮겨 적는다.
                    DataRow Row = null;
                    Row = dtResult.NewRow();
                    dtResult.Rows.Add(Row);

                    for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                        dtResult.Rows[dtResult.Rows.Count - 1][iCol] = dt.Rows[iRow][iCol];

                    for (int iTargetCol = 0; iTargetCol < TargetSubTotalColumns.Length; iTargetCol++)
                    {
                        // 마지막 Row의 Sub Total을 구한다.
                        if (iRow == dt.Rows.Count - 1)
                        {
                            DataRow SubTotRow = null;
                            SubTotRow = dtResult.NewRow();
                            SubTotRow[0] = " ";
                            dtResult.Rows.Add(SubTotRow);
                            if (TargetSubTotalColumns[iTargetCol] != 0)
                            {
                                for (int i = 0; i < TargetSubTotalColumns[iTargetCol]; i++)
                                    dtResult.Rows[dtResult.Rows.Count - 1][i] = dt.Rows[dt.Rows.Count - 1][i].ToString();
                            }
                            dtResult.Rows[dtResult.Rows.Count - 1][TargetSubTotalColumns[iTargetCol]] = dt.Rows[dt.Rows.Count - 1][TargetSubTotalColumns[iTargetCol]].ToString() + " Total";

                            for (int iCalcCol = StartColumnIndex; iCalcCol < EndColumnIndex + 1; iCalcCol++)
                            {
                                //iSubTotal[iTargetCol] = 0;
                                dSubTotal[iTargetCol] = 0;
                                for (int k = iSubRowIndex[iTargetCol]; k < dtResult.Rows.Count - 1; k++)
                                {
                                    bool bCheck = false;
                                    for (int j = 0; j < TargetSubTotalColumns.Length; j++)
                                    {
                                        if (dtResult.Rows[k][TargetSubTotalColumns[j]].ToString().EndsWith("Total"))
                                        {
                                            bCheck = true;
                                            break;
                                        }
                                    }
                                    if (bCheck == false)
                                    {
                                        //iSubTotal[iTargetCol] += Convert.ToInt32(dtResult.Rows[k][iCalcCol]);
                                        dSubTotal[iTargetCol] += Convert.ToDouble(dtResult.Rows[k][iCalcCol]);
                                    }
                                }
                                dtResult.Rows[dtResult.Rows.Count - 1][iCalcCol] = dSubTotal[iTargetCol];
                            }
                        }
                    }
                }

                // 최종 합계를 구한다.
                if (dt.Rows.Count > 0)
                {
                    DataRow TotRow = null;
                    double dTotal = 0;

                    TotRow = dtResult.NewRow();
                    TotRow[TargetSubTotalColumns[TargetSubTotalColumns.Length - 1]] = "Total";
                    dtResult.Rows.Add(TotRow);

                    for (int iCalcCol = StartColumnIndex; iCalcCol < EndColumnIndex + 1; iCalcCol++)
                    {
                        dTotal = 0;
                        for (int k = 0; k < dtResult.Rows.Count - 1; k++)
                        {
                            bool bCheck = false;
                            for (int j = 0; j < TargetSubTotalColumns.Length; j++)
                            {
                                if (dtResult.Rows[k][TargetSubTotalColumns[j]].ToString().EndsWith("Total"))
                                {
                                    bCheck = true;
                                    break;
                                }
                            }
                            if (bCheck == false)
                            {
                                dTotal += Convert.ToDouble(dtResult.Rows[k][iCalcCol]);
                            }
                        }
                        dtResult.Rows[dtResult.Rows.Count - 1][iCalcCol] = dTotal;
                    }
                }
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 원본 DataTable로 SubTotal 및 Total을 계산하여 결과를 DataTable로 반환한다.
        /// </summary>
        /// <param name="dt">원본 DataTable</param>
        /// <param name="TargetSubTotalColumns">계산할 기준값</param>
        /// <param name="CalcSubTotalColumns">계산될 Columns Index</param>
        /// <returns>원본 DataTable에 SubTotal과 Total값을 포함한 DataTable</returns>
        private DataTable GetSubTotalDataTable(DataTable dt, int[] TargetSubTotalColumns, int[] CalcSubTotalColumns)
        {
            try
            {
                DataTable dtResult = new DataTable();
                int[] iSubRowIndex = new int[TargetSubTotalColumns.Length]; // SubTotal결과 추가 후 다음 시작될 Row값을 저장
                //int[] iSubTotal = new int[TargetSubTotalColumns.Length];

                double[] dSubTotal = new double[TargetSubTotalColumns.Length];

                string[] sCurTargetColumn = new string[TargetSubTotalColumns.Length];
                string[] sNewTargetColumn = new string[TargetSubTotalColumns.Length];

                BubbleSort(TargetSubTotalColumns, true);

                for (int i = 0; i < dt.Columns.Count; i++)
                    dtResult.Columns.Add(dt.Columns[i].Caption, dt.Columns[i].DataType);

                for (int i = 0; i < iSubRowIndex.Length; i++)
                    iSubRowIndex[i] = 0;

                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    for (int iTargetCol = 0; iTargetCol < TargetSubTotalColumns.Length; iTargetCol++)
                        sNewTargetColumn[iTargetCol] = Convert.ToString(dt.Rows[iRow][TargetSubTotalColumns[iTargetCol]]); // 원본 DT의 Target Column값을 저장

                    for (int iTargetCol = 0; iTargetCol < TargetSubTotalColumns.Length; iTargetCol++)
                    {
                        bool bColumnDiff = false;
                        for (int i = iTargetCol; i < TargetSubTotalColumns.Length; i++)
                        {
                            if (iRow == 0 || sCurTargetColumn[i].ToString() != sNewTargetColumn[i].ToString())
                                bColumnDiff = true;
                        }

                        // 현재 Target Column의 값과 새로운 Target Column의 값을 비교하여 다르면 현재까지의 Row까지 Sub Total을 구한다.
                        if (bColumnDiff == true)
                        {
                            sCurTargetColumn[iTargetCol] = sNewTargetColumn[iTargetCol].ToString();
                            if (iRow != 0)
                            {
                                DataRow SubTotRow = null;
                                SubTotRow = dtResult.NewRow();
                                SubTotRow[0] = " ";
                                dtResult.Rows.Add(SubTotRow);
                                if (TargetSubTotalColumns[iTargetCol] != 0)
                                {
                                    for (int i = 0; i < TargetSubTotalColumns[iTargetCol]; i++)
                                        dtResult.Rows[dtResult.Rows.Count - 1][i] = dt.Rows[iRow - 1][i].ToString();
                                }
                                dtResult.Rows[dtResult.Rows.Count - 1][TargetSubTotalColumns[iTargetCol]] = dt.Rows[iRow - 1][TargetSubTotalColumns[iTargetCol]].ToString() + " Total";

                                for (int iCol = 0; iCol < dtResult.Columns.Count; iCol++)
                                {
                                    for (int iCalcCol = 0; iCalcCol < CalcSubTotalColumns.Length; iCalcCol++)
                                    {
                                        if (iCol == CalcSubTotalColumns[iCalcCol])
                                        {
                                            //iSubTotal[iTargetCol] = 0;
                                            dSubTotal[iTargetCol] = 0;
                                            for (int k = iSubRowIndex[iTargetCol]; k < dtResult.Rows.Count - 1; k++)
                                            {
                                                bool bCheck = false;
                                                for (int j = 0; j < TargetSubTotalColumns.Length; j++)
                                                {
                                                    if (dtResult.Rows[k][TargetSubTotalColumns[j]].ToString().EndsWith("Total"))
                                                    {
                                                        bCheck = true;
                                                        break;
                                                    }
                                                }
                                                if (bCheck == false)
                                                {
                                                    //iSubTotal[iTargetCol] += Convert.ToInt32(dtResult.Rows[k][iCol]);
                                                    dSubTotal[iTargetCol] += Convert.ToDouble(dtResult.Rows[k][iCol]);
                                                }
                                            }
                                            //dtResult.Rows[dtResult.Rows.Count - 1][iCol] = iSubTotal[iTargetCol];
                                            dtResult.Rows[dtResult.Rows.Count - 1][iCol] = dSubTotal[iTargetCol];
                                        }
                                    }
                                }
                                iSubRowIndex[iTargetCol] = dtResult.Rows.Count;
                            }
                        }
                    }

                    // 원본 DT의 Data를 Result DataTable에 옮겨 적는다.
                    DataRow Row = null;
                    Row = dtResult.NewRow();
                    dtResult.Rows.Add(Row);

                    for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                        dtResult.Rows[dtResult.Rows.Count - 1][iCol] = dt.Rows[iRow][iCol];

                    for (int iTargetCol = 0; iTargetCol < TargetSubTotalColumns.Length; iTargetCol++)
                    {
                        // 마지막 Row의 Sub Total을 구한다.
                        if (iRow == dt.Rows.Count - 1)
                        {
                            DataRow SubTotRow = null;
                            SubTotRow = dtResult.NewRow();
                            SubTotRow[0] = " ";
                            dtResult.Rows.Add(SubTotRow);
                            if (TargetSubTotalColumns[iTargetCol] != 0)
                            {
                                for (int i = 0; i < TargetSubTotalColumns[iTargetCol]; i++)
                                    dtResult.Rows[dtResult.Rows.Count - 1][i] = dt.Rows[dt.Rows.Count - 1][i].ToString();
                            }
                            dtResult.Rows[dtResult.Rows.Count - 1][TargetSubTotalColumns[iTargetCol]] = dt.Rows[dt.Rows.Count - 1][TargetSubTotalColumns[iTargetCol]].ToString() + " Total";

                            for (int iCol = 0; iCol < dtResult.Columns.Count; iCol++)
                            {
                                for (int iCalcCol = 0; iCalcCol < CalcSubTotalColumns.Length; iCalcCol++)
                                {
                                    if (iCol == CalcSubTotalColumns[iCalcCol])
                                    {
                                        //iSubTotal[iTargetCol] = 0;
                                        dSubTotal[iTargetCol] = 0;
                                        for (int k = iSubRowIndex[iTargetCol]; k < dtResult.Rows.Count - 1; k++)
                                        {
                                            bool bCheck = false;
                                            for (int j = 0; j < TargetSubTotalColumns.Length; j++)
                                            {
                                                if (dtResult.Rows[k][TargetSubTotalColumns[j]].ToString().EndsWith("Total"))
                                                {
                                                    bCheck = true;
                                                    break;
                                                }
                                            }
                                            if (bCheck == false)
                                            {

                                                //iSubTotal[iTargetCol] += Convert.ToInt32(dtResult.Rows[k][iCol]);
                                                dSubTotal[iTargetCol] += Convert.ToDouble(dtResult.Rows[k][iCol]);
                                            }
                                        }
                                        //dtResult.Rows[dtResult.Rows.Count - 1][iCol] = iSubTotal[iTargetCol];
                                        dtResult.Rows[dtResult.Rows.Count - 1][iCol] = dSubTotal[iTargetCol];
                                    }
                                }
                            }
                        }
                    }
                }

                // 최종 합계를 구한다.
                if (dt.Rows.Count > 0)
                {
                    DataRow TotRow = null;
                    int iTotal = 0;
                    double dTotal = 0;

                    TotRow = dtResult.NewRow();
                    TotRow[TargetSubTotalColumns[TargetSubTotalColumns.Length - 1]] = "Total";
                    dtResult.Rows.Add(TotRow);

                    for (int iCol = 0; iCol < dtResult.Columns.Count; iCol++)
                    {
                        for (int iCalcCol = 0; iCalcCol < CalcSubTotalColumns.Length; iCalcCol++)
                        {
                            if (iCol == CalcSubTotalColumns[iCalcCol])
                            {
                                iTotal = 0;
                                dTotal = 0;
                                for (int k = 0; k < dtResult.Rows.Count - 1; k++)
                                {
                                    bool bCheck = false;
                                    for (int j = 0; j < TargetSubTotalColumns.Length; j++)
                                    {
                                        if (dtResult.Rows[k][TargetSubTotalColumns[j]].ToString().EndsWith("Total"))
                                        {
                                            bCheck = true;
                                            break;
                                        }
                                    }
                                    if (bCheck == false)
                                    {
                                        iTotal += Convert.ToInt32(dtResult.Rows[k][iCol]);
                                        dTotal += Convert.ToDouble(dtResult.Rows[k][iCol]);
                                    }
                                }
                                //dtResult.Rows[dtResult.Rows.Count - 1][iCol] = iTotal;
                                dtResult.Rows[dtResult.Rows.Count - 1][iCol] = dTotal;
                            }
                        }
                    }
                }
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetTotalDataTable(DataTable dt, int TitleColumnIndex, int StartColumnIndex, int EndColumnIndex)
        {
            DataTable dtResult = new DataTable();

            try
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                    dtResult.Columns.Add(dt.Columns[i].Caption, dt.Columns[i].DataType);

                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    // 원본 DT의 Data를 Result DataTable에 옮겨 적는다.
                    DataRow Row = null;
                    Row = dtResult.NewRow();
                    dtResult.Rows.Add(Row);

                    for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                        dtResult.Rows[dtResult.Rows.Count - 1][iCol] = dt.Rows[iRow][iCol];
                }

                // 최종 합계를 구한다.
                if (dt.Rows.Count > 0)
                {
                    DataRow TotRow = null;
                    double dTotal = 0;

                    TotRow = dtResult.NewRow();
                    TotRow[TitleColumnIndex] = "Total";
                    dtResult.Rows.Add(TotRow);

                    for (int iCalcCol = StartColumnIndex; iCalcCol < EndColumnIndex + 1; iCalcCol++)
                    {
                        dTotal = 0;
                        for (int k = 0; k < dtResult.Rows.Count - 1; k++)
                        {
                            bool bCheck = false;
                            if (dtResult.Rows[k][TitleColumnIndex].ToString().EndsWith("Total"))
                                bCheck = true;

                            if (bCheck == false)
                            {
                                if (string.IsNullOrEmpty(dtResult.Rows[k][iCalcCol].ToString()) == false)
                                    dTotal += Convert.ToDouble(dtResult.Rows[k][iCalcCol]);
                            }
                        }
                        dtResult.Rows[dtResult.Rows.Count - 1][iCalcCol] = dTotal;
                    }
                }
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetTotalDataTable(DataTable dt, int TitleColumnIndex, int[] CalcSubTotalColumns)
        {
            DataTable dtResult = new DataTable();

            try
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                    dtResult.Columns.Add(dt.Columns[i].Caption, dt.Columns[i].DataType);
                
                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    // 원본 DT의 Data를 Result DataTable에 옮겨 적는다.
                    DataRow Row = null;
                    Row = dtResult.NewRow();
                    dtResult.Rows.Add(Row);

                    for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                        dtResult.Rows[dtResult.Rows.Count - 1][iCol] = dt.Rows[iRow][iCol];
                }
                // 최종 합계를 구한다.
                if (dt.Rows.Count > 0)
                {
                    DataRow TotRow = null;
                    double dTotal = 0;

                    TotRow = dtResult.NewRow();
                    TotRow[TitleColumnIndex] = "Total";
                    dtResult.Rows.Add(TotRow);

                    for (int iCol = 0; iCol < dtResult.Columns.Count; iCol++)
                    {
                        for (int iCalcCol = 0; iCalcCol < CalcSubTotalColumns.Length; iCalcCol++)
                        {
                            if (iCol == CalcSubTotalColumns[iCalcCol])
                            {
                                dTotal = 0;
                                for (int k = 0; k < dtResult.Rows.Count - 1; k++)
                                {
                                    bool bCheck = false;
                                    if (dtResult.Rows[k][TitleColumnIndex].ToString().EndsWith("Total"))
                                        bCheck = true;

                                    if (bCheck == false)
                                    {
                                        if (string.IsNullOrEmpty(dtResult.Rows[k][iCalcCol].ToString()) == false)
                                            dTotal += Convert.ToDouble(dtResult.Rows[k][iCol]);
                                    }
                                }
                                dtResult.Rows[dtResult.Rows.Count - 1][iCol] = dTotal;
                            }
                        }
                    }
                }
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ Spread Common Function ]

        /// <summary>
        /// Spread 초기화
        /// </summary>
        /// <param name="bRowHeader">Row Header를 보여줄지 여부</param>
        /// <param name="bSort">Column Sort 여부</param>
        /// <param name="operMode">Operation Mode 설정</param>
        public void RPT_InitSpread(bool bRowHeader, bool bSort, FarPoint.Win.Spread.OperationMode operMode)
        {
            FarPoint.Win.Spread.SheetSkin spSkin;

            try
            {
                FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(this);
                spSkin = new FarPoint.Win.Spread.SheetSkin("InitSkin",
                                           System.Drawing.Color.White,
                                           System.Drawing.Color.Empty,
                                           System.Drawing.Color.Empty,
                                           System.Drawing.Color.Gray,
                                           FarPoint.Win.Spread.GridLines.Both,
                                           System.Drawing.Color.FromArgb(42, 61, 112),
                                           System.Drawing.Color.White,
                                           System.Drawing.Color.FromArgb(192, 192, 255),
                                           System.Drawing.Color.White,
                                           System.Drawing.Color.Empty,
                                           System.Drawing.Color.White,
                    //System.Drawing.Color.FromArgb(231, 231, 255),
                    //System.Drawing.Color.FromArgb(247, 247, 222),
                                           true,
                                           true,
                                           false,
                                           true,
                                           bRowHeader);

                this.BorderStyle = BorderStyle.FixedSingle;
                this.BackColor = System.Drawing.Color.Silver;
                this.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                this.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                this.MoveActiveOnFocus = true;

                this.ColumnSplitBoxAlignment = FarPoint.Win.Spread.SplitBoxAlignment.Leading;
                this.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;

                this.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

                this.SetCursor(FarPoint.Win.Spread.CursorType.Normal, System.Windows.Forms.Cursors.Arrow);
                this.BorderStyle = BorderStyle.FixedSingle;
                this.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                this.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                this.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

                for (int i = 0; i < this.Sheets.Count; i++)
                {
                    //"Verdana", "Tahoma", "Times New Roman", "돋움"
                    Font myFonts = new Font("Tahoma", 8F, FontStyle.Regular);

                    spSkin.Apply(this.Sheets[i]);

                    this.Sheets[i].RowCount = 0;
                    this.Sheets[i].ColumnCount = 0;
                    this.Sheets[i].OperationMode = operMode;
                    this.Sheets[i].Columns[-1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    this.Sheets[i].ColumnHeader.DefaultStyle.Font = new Font("Tahoma", 8F, FontStyle.Bold);

                    this.Sheets[i].DefaultStyle.Font = myFonts;
                    this.Sheets[i].DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    // Auto sort setting.
                    this.Sheets[i].SetColumnAllowAutoSort(0, this.Sheets[i].ColumnCount, bSort);
                    this.Sheets[i].ColumnHeader.AutoSortIndex = 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 이전 컬럼 세팅을 전부 지우고 새로게 셋팅
        /// </summary>
        public void RPT_InitColumn()
        {
            isFirstAdded = true;
            this.ActiveSheet.DataSource = null;
            this.ActiveSheet.Columns.Count = 0;
            this.ActiveSheet.DataAutoSizeColumns = false;
            this.ActiveSheet.FrozenColumnCount = 0;
            this.ActiveSheet.Rows.Count = 0;
            this._cellType.Clear();
            this.InitNoteTable();
        }
                
        /// <summary>
        /// 셀타입을 정의 해주기 위하여
        /// </summary>
        public void RPT_SetCellsType()
        {
            int size = 0;
            if (_cellType.Count > this.ActiveSheet.Columns.Count)
                size = this.ActiveSheet.Columns.Count;
            else
                size = _cellType.Count;

            for (int i = 0; i < size; i++)
            {
                this.ActiveSheet.Columns[i].CellType = (FarPoint.Win.Spread.CellType.ICellType)_cellType[i];
                //if (_cellType[i] != _text && _cellType[i] != _number)                    
                //RPT_SetBlankFromZero(i);
            }
        }

        /// <summary>
        /// 가장 기본적인 컬럼 생성기
        /// 컬럼은 하나씩 더해가고 row 는 젤 마지막의 Header row에 추가
        /// </summary>
        /// <param name="header_Text">ColumnHeader Caption</param>
        /// <param name="isVisible">Column Visible Flag</param>
        /// <param name="isFrozen">Column Frozen Flag</param>
        /// <param name="align">Column TextAlign</param>
        /// <param name="isMerge">Column Merge Flag</param>
        /// <param name="format">Column CellType Format</param>
        /// <param name="size">Column Width</param>
        public void RPT_AddBasicColumn(string header_Text, Visibles isVisible, Frozen isFrozen, Align align, Merge isMerge, Formatter format, int width)
        {
            int rowPos = (this.ActiveSheet.ColumnHeader.Rows.Count == 0 ? 0 : this.ActiveSheet.ColumnHeader.Rows.Count - 1);
            this.RPT_AddBasicColumn(header_Text, rowPos, this.ActiveSheet.Columns.Count, isVisible, isFrozen, align, isMerge, format, width, null);
        }

        /// <summary>
        /// 가장 기본적인 컬럼 생성기
        /// 컬럼은 하나씩 더해가고 row 는 젤 마지막의 Header row에 추가
        /// </summary>
        /// <param name="header_Text">ColumnHeader Caption</param>
        /// <param name="isVisible">Column Visible Flag</param>
        /// <param name="isFrozen">Column Frozen Flag</param>
        /// <param name="align">Column TextAlign</param>
        /// <param name="isMerge">Column Merge Flag</param>
        /// <param name="format">Column CellType Format</param>
        /// <param name="width">Column Width</param>
        /// <param name="header_Note"></param>
        public void RPT_AddBasicColumn(string header_Text, Visibles isVisible, Frozen isFrozen, Align align, Merge isMerge, Formatter format, int width, string header_Note)
        {
            int rowPos = (this.ActiveSheet.ColumnHeader.Rows.Count == 0 ? 0 : this.ActiveSheet.ColumnHeader.Rows.Count - 1);
            this.RPT_AddBasicColumn(header_Text, rowPos, this.ActiveSheet.Columns.Count, isVisible, isFrozen, align, isMerge, format, width, header_Note);
        }

        /// <summary>
        /// 가장 기본적인 컬럼 생성기
        /// 컬럼은 하나씩 더해가고 row 는 젤 마지막의 Header row에 추가
        /// </summary>
        /// <param name="header_Text">ColumnHeader Caption</param>
        /// <param name="header_rowPos">ColumnHeader Row Position</param>
        /// <param name="header_columnPos">ColumnHeader Column Position</param>
        /// <param name="isVisible">Column Visible Flag</param>
        /// <param name="isFrozen">Column Frozen Flag</param>
        /// <param name="align">Column TextAlign</param>
        /// <param name="isMerge">Column Merge Flag</param>
        /// <param name="format">Column CellType Format</param>
        /// <param name="width">Column Width</param>
        public void RPT_AddBasicColumn(string header_Text, int header_rowPos, int header_columnPos, Visibles isVisible, Frozen isFrozen, Align align, Merge isMerge, Formatter format, int width)
        {
            RPT_AddBasicColumn(header_Text, header_rowPos, header_columnPos, isVisible, isFrozen, align, isMerge, format, width, null);
        }

        /// <summary>
        /// 가장 기본적인 컬럼 생성기
        /// 컬럼은 하나씩 더해가고 row 는 젤 마지막의 Header row에 추가
        /// </summary>
        /// <param name="header_Text">ColumnHeader Caption</param>
        /// <param name="header_rowPos">ColumnHeader Row Position</param>
        /// <param name="header_columnPos">ColumnHeader Column Position</param>
        /// <param name="isVisible">Column Visible Flag</param>
        /// <param name="isFrozen">Column Frozen Flag</param>
        /// <param name="align">Column TextAlign</param>
        /// <param name="isMerge">Column Merge Flag</param>
        /// <param name="format">Column CellType Format</param>
        /// <param name="width">Column Width</param>
        /// <param name="header_Note"></param>
        public void RPT_AddBasicColumn(string header_Text, int header_rowPos, int header_columnPos, Visibles isVisible, Frozen isFrozen, Align align, Merge isMerge, Formatter format, int width, string header_Note)
        {
            // 공통적으로 적용할 부분
            DataRow dtRow;

            try
            {
                if (!isFirstAdded)
                {
                    isFirstAdded = true;
                    this.ActiveSheet.Columns.Count = 0;
                    this.ActiveSheet.DataAutoSizeColumns = false;
                    this.ActiveSheet.FrozenColumnCount = 0;
                    this.ActiveSheet.Rows.Count = 0;
                    this._cellType.Clear();
                }

                int columnPos = header_columnPos;
                int rowPos = header_rowPos;

                // 컬럼 사이즈가 현재 사이즈 보다 큰경우 컬럼 사이즈 증가
                if (columnPos >= this.ActiveSheet.Columns.Count)
                    this.ActiveSheet.Columns.Count = columnPos + 1;

                // row 사이즈가 현재 사이즈 보다 큰경우 row 사이즈 증가
                if (rowPos >= this.ActiveSheet.ColumnHeader.Rows.Count)
                    this.ActiveSheet.ColumnHeader.Rows.Count = rowPos + 1;

                this.ActiveSheet.ColumnHeader.Cells.Get(rowPos, columnPos).Text = header_Text;

                //Spread의 Row가 0이면 오류 발생함.                
                //this.ActiveSheet.ColumnHeader.Cells.Get(rowPos, columnPos).Note = header_Text;
                //this.ActiveSheet.ColumnHeader.Cells.Get(rowPos, columnPos).NoteIndicatorSize = new System.Drawing.Size(7, 7);

                if (header_Note == null) header_Note = "";

                dtRow = dtNote.NewRow();
                dtRow["Row"] = rowPos;
                dtRow["Col"] = columnPos;
                dtRow["Note"] = header_Note;
                dtNote.Rows.Add(dtRow);

                if (isVisible == Visibles.True)
                    this.ActiveSheet.Columns[columnPos].Visible = true;
                else
                    this.ActiveSheet.Columns[columnPos].Visible = false;

                this.ActiveSheet.Columns[columnPos].Width = width;

                if (align == Align.Center)
                    this.ActiveSheet.Columns[columnPos].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                else if (align == Align.Left)
                    this.ActiveSheet.Columns[columnPos].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                else if (align == Align.Right)
                    this.ActiveSheet.Columns[columnPos].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;

                if (isFrozen == Frozen.True)
                    this.ActiveSheet.FrozenColumnCount++;

                if (isMerge == Merge.True)
                {
                    if (columnPos == 0 || this.ActiveSheet.Columns[columnPos - 1].MergePolicy == MergePolicy.None)
                        this.ActiveSheet.Columns[columnPos].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
                    else
                        this.ActiveSheet.Columns[columnPos].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    this.ActiveSheet.Columns[columnPos].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
                }
                else if (isMerge == Merge.Left)
                {
                    this.ActiveSheet.Columns[columnPos].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
                    this.ActiveSheet.Columns[columnPos].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
                }
                else if (isMerge == Merge.Always)
                {
                    this.ActiveSheet.Columns[columnPos].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
                    this.ActiveSheet.Columns[columnPos].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
                }
                else
                {
                    this.ActiveSheet.Columns[columnPos].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                }

                // 셀타입 저장
                // AutoGernerationColumn 이 true 이 상황에서
                // 데이타 바인딩 전에 하면 실제로 적용이 안됨
                // 데이타 바인딩 이후에 실제로 셀타입을 지정하기 위하여
                //			_cellType.Add( getCellType( format ) );
                if (_cellType.Capacity < this.ActiveSheet.ColumnCount)
                    _cellType.Capacity++;
                _cellType.Insert(columnPos, getCellType(format));

                // ReadOnly 
                //this.ActiveSheet.Columns[columnPos].Locked = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// 자동으로 Columns Width값 조정
        /// </summary>
        /// <param name="bIgnoreHeaders"></param>
        public void RPT_ColumnAutoFit(bool bIgnoreHeaders)
        {
            FarPoint.Win.Spread.CellType.TextCellType txtType = new TextCellType();

            this.ActiveSheet.RowCount += 1;
            for (int i = 0; i < this.ActiveSheet.Columns.Count; i++)
            {
                this.ActiveSheet.Cells[this.ActiveSheet.RowCount - 1, i].CellType = txtType;
                if (this.ActiveSheet.ColumnHeader.Cells[this.ActiveSheet.ColumnHeader.RowCount - 1, i].Text.Trim() != "")
                    this.ActiveSheet.Cells[this.ActiveSheet.RowCount - 1, i].Text = this.ActiveSheet.ColumnHeader.Cells[this.ActiveSheet.ColumnHeader.RowCount - 1, i].Text;
                else
                    this.ActiveSheet.Cells[this.ActiveSheet.RowCount - 1, i].Text = this.ActiveSheet.ColumnHeader.Columns[i].Label;
                this.ActiveSheet.Cells[this.ActiveSheet.RowCount - 1, i].Font = new Font("Tahoma", 8F, FontStyle.Bold);
            }
            for (int i = 0; i < this.ActiveSheet.Columns.Count; i++)
            {
                float width_max = this.ActiveSheet.GetPreferredColumnWidth(i, bIgnoreHeaders);

                //if (this.ActiveSheet.ColumnHeader.Columns[i].Width < width_max)
                //{
                    this.ActiveSheet.Columns[i].Width = width_max;
                //}
            }
            this.ActiveSheet.Rows[this.ActiveSheet.RowCount - 1].Remove();
        }

        public void RPT_RowAutoFit(bool bIgnoreHeaders)
        {
            for (int i = 0; i < this.ActiveSheet.Rows.Count; i++)
            {
                float height_max = this.ActiveSheet.GetPreferredRowHeight(i, bIgnoreHeaders);

                if (this.ActiveSheet.Rows[i].Height < height_max)
                {
                    this.ActiveSheet.Rows[i].Height = height_max;
                }
            }
        }

        public void RPT_ColumnsFilter()
        {
            try
            {
                for (int iCol = 0; iCol < this.ActiveSheet.ColumnCount; iCol++)
                {
                    this.ActiveSheet.Columns[iCol].AllowAutoFilter = true;
                    this.ActiveSheet.Columns[iCol].Width += 20;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void RPT_ColumnsFilter(int StartColumnIndex, int EndColumnIndex)
        {
            try
            {
                for (int iCol = StartColumnIndex; iCol < EndColumnIndex + 1; iCol++)
                {
                    this.ActiveSheet.Columns[iCol].AllowAutoFilter = true;
                    this.ActiveSheet.Columns[iCol].Width += 20;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void RPT_ColumnsFilter(int[] FilterColumnsIndex)
        {
            try
            {
                for (int iLength = 0; iLength < FilterColumnsIndex.Length; iLength++)
                {
                    this.ActiveSheet.Columns[FilterColumnsIndex[iLength]].AllowAutoFilter = true;
                    this.ActiveSheet.Columns[FilterColumnsIndex[iLength]].Width += 20;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void RPT_ColumnsSort()
        {
            try
            {
                for (int iCol = 0; iCol < this.ActiveSheet.ColumnCount; iCol++)
                {
                    this.ActiveSheet.Columns[iCol].AllowAutoSort = true;
                    this.ActiveSheet.Columns[iCol].Width += 15;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void RPT_ColumnsSort(int StartColumnIndex, int EndColumnIndex)
        {
            try
            {
                for (int iCol = StartColumnIndex; iCol < EndColumnIndex + 1; iCol++)
                {
                    this.ActiveSheet.Columns[iCol].AllowAutoSort = true;
                    this.ActiveSheet.Columns[iCol].Width += 15;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void RPT_ColumnsSort(int[] SortColumnsIndex)
        {
            try
            {
                for (int iLength = 0; iLength < SortColumnsIndex.Length; iLength++)
                {
                    this.ActiveSheet.Columns[SortColumnsIndex[iLength]].AllowAutoSort = true;
                    this.ActiveSheet.Columns[SortColumnsIndex[iLength]].Width += 15;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void RPT_SpreadPrint(FarPoint.Win.Spread.PrintOrientation Orientation)
        {
            // Create PrintInfo object and set properties.
            FarPoint.Win.Spread.PrintInfo printset = new FarPoint.Win.Spread.PrintInfo();
            FarPoint.Win.Spread.PrintMargin printMargin = new FarPoint.Win.Spread.PrintMargin();

            printMargin.Top = 60;
            printset.Margin = printMargin;
            printset.ColStart = this.Sheets[0].Models.Selection.AnchorColumn;
            printset.ColEnd = this.Sheets[0].Models.Selection.LeadColumn;
            printset.RowStart = this.Sheets[0].Models.Selection.AnchorRow;
            printset.RowEnd = this.Sheets[0].Models.Selection.LeadRow;
            printset.PrintType = FarPoint.Win.Spread.PrintType.All;
            printset.Orientation = Orientation; // [Auto]자동, [Landscape]가로, [Portrait]세로
            
            printset.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show;
            printset.UseMax = false;
            this.Sheets[0].PrintInfo = printset;
            
            this.PrintSheet(0);
        }

        public void RPT_AlternatingRows()
        {
            this.ActiveSheet.AlternatingRows[0].BackColor = Color.WhiteSmoke;
            this.ActiveSheet.AlternatingRows[1].BackColor = Color.FromArgb(214, 224, 232);
            this.ActiveSheet.AlternatingRows[1].ForeColor = Color.FromArgb(31, 54, 80);
        }

        public void RPT_NonAlternatingRows()
        {
            this.ActiveSheet.AlternatingRows[0].BackColor = Color.Empty;
            this.ActiveSheet.AlternatingRows[1].BackColor = Color.Empty;
            this.ActiveSheet.AlternatingRows[1].ForeColor = Color.Empty;
        }

        public void RPT_ColumnMergeColor(int iStartColumnMergeIndex, int iEndColumnMergeIndex)
        {
            this.ActiveSheet.Columns[iStartColumnMergeIndex, iEndColumnMergeIndex].BackColor = Color.FromArgb(214, 224, 232);
            this.ActiveSheet.Columns[iStartColumnMergeIndex, iEndColumnMergeIndex].Font = new Font("Tahoma", 8F, FontStyle.Bold);
            this.ActiveSheet.Columns[iStartColumnMergeIndex, iEndColumnMergeIndex].ForeColor = Color.Black;
        }

        public void RPT_AddTotal(int TitleColumnIndex, int[] CalcTotalColumns)
        {
            FarPoint.Win.ComplexBorder TotalComplexBorder = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
              new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.DoubleLine),
              new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
              new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            double dTotal = 0;

            try
            {
                if (this.ActiveSheet.RowCount > 0)
                {
                    this.ActiveSheet.RowCount += 1;
                    this.ActiveSheet.Cells[this.ActiveSheet.RowCount - 1, TitleColumnIndex].Text = "Total";
                    for (int iCol = 0; iCol < this.ActiveSheet.ColumnCount; iCol++)
                    {
                        for (int iCalcCol = 0; iCalcCol < CalcTotalColumns.Length; iCalcCol++)
                        {
                            if (iCol == CalcTotalColumns[iCalcCol])
                            {
                                dTotal = 0;
                                for (int k = 0; k < this.ActiveSheet.RowCount - 1; k++)
                                {
                                    bool bCheck = false;
                                    if (this.ActiveSheet.Cells[k, TitleColumnIndex].Text.EndsWith("Total"))
                                        bCheck = true;

                                    if (bCheck == false)
                                    {
                                        if (string.IsNullOrEmpty(this.ActiveSheet.Cells[k, iCol].Text.Trim()) == false)
                                        {
                                            if (this.ActiveSheet.Cells[k, iCol].Text.Trim().IndexOf(",") == -1)
                                                dTotal += Convert.ToDouble(this.ActiveSheet.Cells[k, iCol].Text);
                                            else
                                                dTotal += Convert.ToDouble(this.ActiveSheet.Cells[k, iCol].Text.Trim().Replace(",", ""));
                                        }
                                    }
                                }
                                this.ActiveSheet.Cells[this.ActiveSheet.RowCount - 1, iCol].Text = dTotal.ToString();
                            }
                        }
                    }
                }

                for (int iRow = 0; iRow < this.Sheets[0].RowCount; iRow++)
                {
                    if (this.Sheets[0].Cells[iRow, TitleColumnIndex].Text.EndsWith("Total"))
                    {
                        this.Sheets[0].Cells[iRow, TitleColumnIndex].ColumnSpan = CalcTotalColumns[0] - TitleColumnIndex;
                        this.Sheets[0].Cells[iRow, TitleColumnIndex].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                        this.Sheets[0].Rows[iRow].Font = new Font("Tahoma", 8F, FontStyle.Bold);
                        this.Sheets[0].Rows[iRow].ForeColor = Color.DarkBlue;
                        this.Sheets[0].Rows[iRow].BackColor = Color.LightGray;
                        for (int i = TitleColumnIndex; i < this.Sheets[0].ColumnCount; i++)
                            this.Sheets[0].Cells[iRow, i].Border = TotalComplexBorder;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RPT_AddTotal(int TitleColumnIndex, int StartColumnIndex, int EndColumnIndex)
        {
            FarPoint.Win.ComplexBorder TotalComplexBorder = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
              new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.DoubleLine),
              new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
              new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            double dTotal = 0;

            try
            {
                if (this.ActiveSheet.RowCount > 0)
                {
                    this.ActiveSheet.RowCount += 1;
                    this.ActiveSheet.Cells[this.ActiveSheet.RowCount - 1, TitleColumnIndex].Text = "Total";
                    for (int iCol = StartColumnIndex; iCol < EndColumnIndex; iCol++)
                    {
                        dTotal = 0;
                        for (int k = 0; k < this.ActiveSheet.RowCount - 1; k++)
                        {
                            bool bCheck = false;
                            if (this.ActiveSheet.Cells[k, TitleColumnIndex].Text.EndsWith("Total"))
                                bCheck = true;

                            if (bCheck == false)
                            {
                                if (string.IsNullOrEmpty(this.ActiveSheet.Cells[k, iCol].Text.Trim()) == false)
                                {
                                    if (this.ActiveSheet.Cells[k, iCol].Text.Trim().IndexOf(",") == -1)
                                        dTotal += Convert.ToDouble(this.ActiveSheet.Cells[k, iCol].Text);
                                    else
                                        dTotal += Convert.ToDouble(this.ActiveSheet.Cells[k, iCol].Text.Trim().Replace(",", ""));
                                }

                            }
                        }
                        this.ActiveSheet.Cells[this.ActiveSheet.RowCount - 1, iCol].Text = dTotal.ToString();
                    }
                }

                for (int iRow = 0; iRow < this.Sheets[0].RowCount; iRow++)
                {
                    if (this.Sheets[0].Cells[iRow, TitleColumnIndex].Text.EndsWith("Total"))
                    {
                        this.Sheets[0].Cells[iRow, TitleColumnIndex].ColumnSpan = StartColumnIndex - TitleColumnIndex;
                        this.Sheets[0].Cells[iRow, TitleColumnIndex].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                        this.Sheets[0].Rows[iRow].Font = new Font("Tahoma", 8F, FontStyle.Bold);
                        this.Sheets[0].Rows[iRow].ForeColor = Color.DarkBlue;
                        this.Sheets[0].Rows[iRow].BackColor = Color.LightGray;
                        for (int i = TitleColumnIndex; i < this.Sheets[0].ColumnCount; i++)
                            this.Sheets[0].Cells[iRow, i].Border = TotalComplexBorder;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RPT_AddTotal(DataTable dt, int TitleColumnIndex, int StartColumnIndex, int EndColumnIndex)
        {
            FarPoint.Win.ComplexBorder TotalComplexBorder = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.DoubleLine),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));

            try
            {
                this.DataSource = GetTotalDataTable(dt, TitleColumnIndex, StartColumnIndex, EndColumnIndex);
                for (int iRow = 0; iRow < this.Sheets[0].RowCount; iRow++)
                {
                    if (this.Sheets[0].Cells[iRow, TitleColumnIndex].Text.EndsWith("Total"))
                    {
                        this.Sheets[0].Cells[iRow, TitleColumnIndex].ColumnSpan = StartColumnIndex - TitleColumnIndex;
                        this.Sheets[0].Cells[iRow, TitleColumnIndex].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        this.Sheets[0].Rows[iRow].Font = new Font("Tahoma", 8F, FontStyle.Bold);
                        this.Sheets[0].Rows[iRow].ForeColor = Color.DarkBlue;
                        this.Sheets[0].Rows[iRow].BackColor = Color.LightGray;
                        for (int i = TitleColumnIndex; i < this.Sheets[0].ColumnCount; i++)
                            this.Sheets[0].Cells[iRow, i].Border = TotalComplexBorder;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RPT_AddTotal(DataTable dt, int TitleColumnIndex, int[] CalcTotalColumns)
        {
            FarPoint.Win.ComplexBorder TotalComplexBorder = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.DoubleLine),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));

            try
            {
                this.DataSource = GetTotalDataTable(dt, TitleColumnIndex, CalcTotalColumns);
                BubbleSort(CalcTotalColumns, false);
                for (int iRow = 0; iRow < this.Sheets[0].RowCount; iRow++)
                {
                    if (this.Sheets[0].Cells[iRow, TitleColumnIndex].Text.EndsWith("Total"))
                    {
                        this.Sheets[0].Cells[iRow, TitleColumnIndex].ColumnSpan = CalcTotalColumns[0] - TitleColumnIndex;
                        this.Sheets[0].Cells[iRow, TitleColumnIndex].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                        this.Sheets[0].Rows[iRow].Font = new Font("Tahoma", 8F, FontStyle.Bold);
                        this.Sheets[0].Rows[iRow].ForeColor = Color.DarkBlue;
                        this.Sheets[0].Rows[iRow].BackColor = Color.LightGray;
                        for (int i = TitleColumnIndex; i < this.Sheets[0].ColumnCount; i++)
                             this.Sheets[0].Cells[iRow, i].Border = TotalComplexBorder;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RPT_AddSubTotal(DataTable dt, int[] TargetSubTotalColumns, int StartColumnIndex, int EndColumnIndex)
        {
            FarPoint.Win.ComplexBorder SubTotalComplexBorder = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.ComplexBorder TotalComplexBorder = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.DoubleLine),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));

            try
            {
                this.DataSource = GetSubTotalDataTable(dt, TargetSubTotalColumns, StartColumnIndex, EndColumnIndex);
                BubbleSort(TargetSubTotalColumns, true);
                for (int iRow = 0; iRow < this.Sheets[0].RowCount; iRow++)
                {
                    for (int iTargetCol = 0; iTargetCol < TargetSubTotalColumns.Length; iTargetCol++)
                    {
                        if (this.Sheets[0].Cells[iRow, TargetSubTotalColumns[iTargetCol]].Text.EndsWith("Total"))
                        {
                            this.Sheets[0].Cells[iRow, TargetSubTotalColumns[iTargetCol]].ColumnSpan = StartColumnIndex - TargetSubTotalColumns[iTargetCol];
                            this.Sheets[0].Cells[iRow, TargetSubTotalColumns[iTargetCol]].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                            this.Sheets[0].Rows[iRow].Font = new Font("Tahoma", 8F, FontStyle.Bold);
                            this.Sheets[0].Rows[iRow].ForeColor = Color.DarkBlue;
                            this.Sheets[0].Rows[iRow].BackColor = Color.LightGray;
                            if (this.Sheets[0].Cells[iRow, TargetSubTotalColumns[iTargetCol]].Text == "Total")
                            {
                                for (int i = TargetSubTotalColumns[iTargetCol]; i < this.Sheets[0].ColumnCount; i++)
                                    this.Sheets[0].Cells[iRow, i].Border = TotalComplexBorder;
                            }
                            else
                            {
                                for (int i = TargetSubTotalColumns[iTargetCol]; i < this.Sheets[0].ColumnCount; i++)
                                    this.Sheets[0].Cells[iRow, i].Border = SubTotalComplexBorder;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RPT_AddSubTotal(DataTable dt, int[] TargetSubTotalColumns, int[] CalcSubTotalColumns)
        {
            FarPoint.Win.ComplexBorder SubTotalComplexBorder = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.ComplexBorder TotalComplexBorder = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.DoubleLine),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
                new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));

            try
            {
                this.DataSource = GetSubTotalDataTable(dt, TargetSubTotalColumns, CalcSubTotalColumns);
                BubbleSort(TargetSubTotalColumns, true);
                BubbleSort(CalcSubTotalColumns, false);
                for (int iRow = 0; iRow < this.Sheets[0].RowCount; iRow++)
                {
                    for (int iTargetCol = 0; iTargetCol < TargetSubTotalColumns.Length; iTargetCol++)
                    {
                        if (this.Sheets[0].Cells[iRow, TargetSubTotalColumns[iTargetCol]].Text.EndsWith("Total"))
                        {
                            this.Sheets[0].Cells[iRow, TargetSubTotalColumns[iTargetCol]].ColumnSpan = CalcSubTotalColumns[0] - TargetSubTotalColumns[iTargetCol];
                            this.Sheets[0].Cells[iRow, TargetSubTotalColumns[iTargetCol]].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                            this.Sheets[0].Rows[iRow].Font = new Font("Tahoma", 8F, FontStyle.Bold);
                            this.Sheets[0].Rows[iRow].ForeColor = Color.DarkBlue;
                            this.Sheets[0].Rows[iRow].BackColor = Color.LightGray;
                            if (this.Sheets[0].Cells[iRow, TargetSubTotalColumns[iTargetCol]].Text == "Total")
                            {
                                for (int i = TargetSubTotalColumns[iTargetCol]; i < this.Sheets[0].ColumnCount; i++)
                                    this.Sheets[0].Cells[iRow, i].Border = TotalComplexBorder;
                            }
                            else
                            {
                                for (int i = TargetSubTotalColumns[iTargetCol]; i < this.Sheets[0].ColumnCount; i++)
                                    this.Sheets[0].Cells[iRow, i].Border = SubTotalComplexBorder;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
