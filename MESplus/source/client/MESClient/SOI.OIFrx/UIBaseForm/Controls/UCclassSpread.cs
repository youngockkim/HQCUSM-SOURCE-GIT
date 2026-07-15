/*---------------------------------------------------------------------------------------------------
 
    PROG ID		: UCclassSpread
    Creator		: MoSangHun(Miracom)
    Create Date	: 
    Description	: 
 
    History		: 2010.03.05 Sunghee Park.  재 생성하여 추가.
----------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Collections;
//==
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System.Drawing;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
using System.Data.OleDb;

namespace SOI.OIFrx
{
    public class UCclassSpread
    {
        //=============
        FarPoint.Win.Spread.FpSpread fpMain;
        //DataTable tblData = null;
        DataSet dsetFData = null;
        bool IsUseRowFixHeader = true;
        bool IsUseDesignMode = false;
        public List<string[]> lstHeader = null;
        public List<int[]> lstRowSpan = null;
        public List<int[]> lstColSpan = null;
        public List<int[]> lstColWidth = null;
        public List<string[]> lstColHAlign = null;

        public List<string[]> lstRowHeader = null;
        public List<int[]> lstRowRowSpan = null;
        public List<int[]> lstRowColSpan = null;
        public List<int[]> lstRowColHeight = null;
        public List<int[]> lstRowColWidth = null;
        public List<int> lstHideColumn = null;
        public List<int> lstLockColumn = null;
        public List<int> lstShowColumn = null;
        int[] iColumnColspan = null;
        List<FarPoint.Win.Spread.CellType.ICellType> lstCellType = null;
        int nDataRowCount = 3;
        List<int> lstSpNotChangeCol = null;
        string[] lstColumnDataFields = null;
        int nColumnCount = -1;
        int nColHeaderCount = 1;

        public List<string> straGroup = new List<string>();
        public List<string> straCompute = new List<string>();
        DataTable tblTotalGroup = new DataTable();
        string strSortCondition = string.Empty;
        //=============

        public FarPoint.Win.Spread.FpSpread TargetSpread
        {
            get { return fpMain; }
            set
            {
                fpMain = value;
            }
        }


        #region  [ Get ] / Set
        public int ColHeaderCount
        {
            get { return nColHeaderCount; }
            set { nColHeaderCount = value; }
        }
        public int ColumnCount
        {
            get { return nColumnCount; }
            set { nColumnCount = value; }
        }
        public string[] ColumnDataFields
        {
            get { return lstColumnDataFields; }
            set { lstColumnDataFields = value; }
        }

        public bool UseDesignMode
        {
            get { return IsUseDesignMode; }
            set { IsUseDesignMode = value; }
        }


        #region [Column Header]

        [Category("GridSetting")]
        [Description("Column값중 숨길 Column의 Index를 List로 설정한다.")]
        [DefaultValue(null)]
        public List<int> HideColumn
        {
            get { return lstHideColumn; }
            set
            {
                lstHideColumn = value;
            }
        }
        [Category("GridSetting")]
        [Description("Column값중 보여질 Column의 Index를 List로 설정한다.")]
        [DefaultValue(null)]
        public List<int> ShowColumn
        {
            get { return lstShowColumn; }
            set
            {
                lstShowColumn = value;
            }
        }
        [Category("GridSetting")]
        [Description("Column값중 Lock속성을 부여할 Column의 Index를 List로 설정한다.")]
        [DefaultValue(null)]
        public List<int> LockColumn
        {
            get { return lstLockColumn; }
            set { lstLockColumn = value; }
        }

        [Category("GridSetting")]
        [Description("Header를 설정")]
        [DefaultValue(null)]
        public List<string[]> Header
        {
            get { return lstHeader; }
            set
            {
                lstHeader = value;
            }
        }

        [Category("GridSetting")]
        [Description("Header RowSpan")]
        [DefaultValue(null)]
        public List<int[]> RowSpan
        {
            get { return lstRowSpan; }
            set
            {
                lstRowSpan = value;
            }
        }

        [Category("GridSetting")]
        [Description("Header ColSpan")]
        [DefaultValue(null)]
        public List<int[]> ColSpan
        {
            get { return lstColSpan; }
            set
            {
                lstColSpan = value;
            }
        }

        [Category("GridSetting")]
        [Description("Header ColWidth 설정")]
        [DefaultValue(null)]
        public List<int[]> ColWidth
        {
            get { return lstColWidth; }
            set
            {
                lstColWidth = value;
            }
        }

        [Category("GridSetting")]
        [Description("Column HorizontalAlignment 설정")]
        [DefaultValue(null)]
        public List<string[]> ColHAlign
        {
            get { return lstColHAlign; }
            set
            {
                lstColHAlign = value;
            }
        }

        #endregion

        #region [ Row Header ]
        [Category("GridSetting")]
        [Description("Header를 설정")]
        [DefaultValue(null)]
        public List<string[]> RowHeader
        {
            get { return lstRowHeader; }
            set
            {
                lstRowHeader = value;
            }
        }

        [Category("GridSetting")]
        [Description("Header RowSpan")]
        [DefaultValue(null)]
        public List<int[]> RowRowSpan
        {
            get { return lstRowRowSpan; }
            set
            {
                lstRowRowSpan = value;
            }
        }

        [Category("GridSetting")]
        [Description("Header ColSpan")]
        [DefaultValue(null)]
        public List<int[]> RowColSpan
        {
            get { return lstRowColSpan; }
            set
            {
                lstRowColSpan = value;
            }
        }

        [Category("GridSetting")]
        [Description("Header ColWidth 설정")]
        [DefaultValue(null)]
        public List<int[]> RowColWidth
        {
            get { return lstRowColWidth; }
            set
            {
                lstRowColWidth = value;
            }
        }
        #endregion


        [Category("GridSetting")]
        [Description("SampleDataColumn중 변경없이 그대로 보여지는Column지정")]
        [DefaultValue(null)]
        public List<int> SampleNotChangeColumn
        {
            get { return lstSpNotChangeCol; }
            set { lstSpNotChangeCol = value; }
        }

        /// <summary>
        /// Row Header를 Header형태로 사용할지 아니면 Row에 Fix시켜서 사용할지 유무를 결정
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UseRowFixHeader
        {
            get { return IsUseRowFixHeader; }
            set { IsUseRowFixHeader = value; }
        }

        [Category("GridSetting")]
        [Description("SampleDataRowCount의 갯수를 지정한다.")]
        [DefaultValue(3)]
        public int SampleDataRowCount
        {
            get { return nDataRowCount; }
            set { nDataRowCount = value; }
        }

        [Category("GridSetting")]
        [Description("Column ColSpan")]
        [DefaultValue(null)]
        public int[] ColumnColSpan
        {
            get { return iColumnColspan; }
            set
            {
                iColumnColspan = value;
            }
        }

        [Category("GridSetting")]
        [Description("FrozenColumnCount를 설정")]
        [DefaultValue(null)]
        public int FrosenColumnCount
        {
            get { return this.fpMain.ActiveSheet.FrozenColumnCount; }
            set
            {
                this.fpMain.ActiveSheet.FrozenColumnCount = value;
            }
        }

        [Category("GridSetting")]
        [Description("FrozenRowCount를 설정")]
        [DefaultValue(null)]
        public int FrosenRowCount
        {
            get { return this.fpMain.ActiveSheet.FrozenRowCount; }
            set
            {
                this.fpMain.ActiveSheet.FrozenRowCount = value;
            }
        }

        [Category("GridSetting")]
        [Description("FrozenTrailingRowCount를 설정")]
        [DefaultValue(null)]
        public int FrozenTrailingRowCount
        {
            get { return this.fpMain.ActiveSheet.FrozenTrailingRowCount; }
            set
            {
                this.fpMain.ActiveSheet.FrozenTrailingRowCount = value;
            }
        }
        #endregion

        #region [ 함수들 ]

        public void InitializeSpread()
        {
            //=============
            //FarPoint.Win.Spread.FpSpread fpMain;
            //tblData = null;
            dsetFData = null;
            IsUseRowFixHeader = false;
            IsUseDesignMode = false;
            lstHeader = null;
            lstRowSpan = null;
            lstColSpan = null;
            lstColWidth = null;
            lstColHAlign = null;

            lstRowHeader = null;
            lstRowRowSpan = null;
            lstRowColSpan = null;
            lstRowColHeight = null;
            lstRowColWidth = null;
            lstHideColumn = null;
            lstShowColumn = null;
            lstLockColumn = null;
            iColumnColspan = null;
            lstCellType = null;
            nDataRowCount = 3;
            lstSpNotChangeCol = null;
            lstColumnDataFields = null;
            nColumnCount = -1;
            nColHeaderCount = 1;

            straGroup = new List<string>();
            straCompute = new List<string>();
            tblTotalGroup = new DataTable();
            //=============
        }


        /// <summary>
        /// Header를 만들기 위한 string설정
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void AddColumnHeader(string value)
        {
            string[] straValue = value.Split('^');
            string[] straTemp;
            int nCol = straValue.Length;
            int[] lstRSpan = new int[nCol];
            int[] lstCSpan = new int[nCol]; ;
            int[] lstCWidth = new int[nCol]; ;
            string[] lstTitle = new string[nCol];
            for (int i = 0; i < straValue.Length; i++)
            {
                straTemp = straValue[i].Split(':');
                lstRSpan[i] = Int32.Parse(straTemp[0]);
                lstCSpan[i] = Int32.Parse(straTemp[1]);
                lstTitle[i] = straTemp[2];
                lstCWidth[i] = Int32.Parse(straTemp[3]);
            }

            if (lstRowSpan == null) lstRowSpan = new List<int[]>();
            if (lstColSpan == null) lstColSpan = new List<int[]>();
            if (lstColWidth == null) lstColWidth = new List<int[]>();
            if (lstHeader == null) lstHeader = new List<string[]>();

            lstRowSpan.Add(lstRSpan);
            lstColSpan.Add(lstCSpan);
            lstColWidth.Add(lstCWidth);
            lstHeader.Add(lstTitle);
        }

        /// <summary>
        /// Header를 만들기 위한 string설정
        /// Column의 HorizontalAlignment 설정 추가
        /// sanghun mo 추가
        /// </summary>
        /// <param name="value">Column들을 만들기 위한 값:</param>
        /// <returns></returns>
        public void AddColumnHeader2(string value)
        {
            string[] straValue = value.Split('^');
            string[] straTemp;
            int nCol = straValue.Length;
            //int[] lstRSpan = new int[nCol];
            //int[] lstCSpan = new int[nCol];
            string[] lstTitle = new string[nCol];
            int[] lstCWidth = new int[nCol];
            string[] lstCHAlign = new string[nCol];
            for (int i = 0; i < straValue.Length; i++)
            {
                straTemp = straValue[i].Split(':');
                //lstRSpan[i] = Int32.Parse(straTemp[0]);
                //lstCSpan[i] = Int32.Parse(straTemp[1]);
                lstTitle[i] = straTemp[0];
                lstCWidth[i] = Int32.Parse(straTemp[1]);
                lstCHAlign[i] = straTemp[2];
            }

            //if (lstRowSpan == null) lstRowSpan = new List<int[]>();
            //if (lstColSpan == null) lstColSpan = new List<int[]>();
            if (lstHeader == null) lstHeader = new List<string[]>();
            if (lstColWidth == null) lstColWidth = new List<int[]>();
            if (lstColHAlign == null) lstColHAlign = new List<string[]>();

            if (this.ColHeaderCount > 1)
            {
                for (int i = 0; i < ColHeaderCount; i++)
                {
                    lstHeader.Add(lstTitle);
                    lstColWidth.Add(lstCWidth);
                    lstColHAlign.Add(lstCHAlign);
                }
            }
            else
            {
                //lstRowSpan.Add(lstRSpan);
                //lstColSpan.Add(lstCSpan);
                lstHeader.Add(lstTitle);
                lstColWidth.Add(lstCWidth);
                lstColHAlign.Add(lstCHAlign);
            }

        }

        /// <summary>
        /// Header를 만들기 위한 string설정
        /// </summary>
        /// <param name="value">Column들을 만들기 위한 값:</param>
        /// <returns></returns>
        public void AddRowHeader(string value)
        {
            string[] straValue = value.Split('^');
            string[] straTemp;
            int nCol = straValue.Length;
            int[] lstRSpan = new int[nCol];
            int[] lstCSpan = new int[nCol]; ;
            int[] lstCWidth = new int[nCol]; ;
            string[] lstTitle = new string[nCol];
            for (int i = 0; i < straValue.Length; i++)
            {
                straTemp = straValue[i].Split(':');
                lstRSpan[i] = Int32.Parse(straTemp[0]);
                lstCSpan[i] = Int32.Parse(straTemp[1]);
                lstTitle[i] = straTemp[2];
                lstCWidth[i] = Int32.Parse(straTemp[3]);
            }

            if (lstRowRowSpan == null) lstRowRowSpan = new List<int[]>();
            if (lstRowColSpan == null) lstRowColSpan = new List<int[]>();
            if (lstRowColWidth == null) lstRowColWidth = new List<int[]>();
            if (lstRowHeader == null) lstRowHeader = new List<string[]>();

            lstRowRowSpan.Add(lstRSpan);
            lstRowColSpan.Add(lstCSpan);
            lstRowColWidth.Add(lstCWidth);
            lstRowHeader.Add(lstTitle);
        }

        /// <summary>
        /// Column의 CellType값을 설정
        /// </summary>
        /// <param name="value">FarPoint.Win.Spread.CellType</param>
        public void AddCellType(FarPoint.Win.Spread.CellType.ICellType value)
        {
            if (lstCellType == null) lstCellType = new List<FarPoint.Win.Spread.CellType.ICellType>();
            lstCellType.Add(value);
        }


        /// <summary>
        /// Grid의 Header속성을 적용 시킨다.
        /// </summary>
        public void InitHeader()
        {
            if (Header == null) return;

            //this.fpMain.ActiveSheet.Columns.Count = Header[0].Length;
            if (ColumnDataFields != null)
            {
                this.fpMain.ActiveSheet.Columns.Count =
                                                    (nColumnCount == -1) ?
                                                    ((Header[0].Length >= ColumnDataFields.Length) ? Header[0].Length : ColumnDataFields.Length) :
                                                    ColumnCount;
            }
            else
            {
                this.fpMain.ActiveSheet.Columns.Count = (nColumnCount == -1) ? Header[0].Length : ColumnCount;
            }

            #region [ Column Header ]
            this.fpMain.ActiveSheet.ColumnHeaderRowCount = Header.Count;

            for (int i = 0; i < Header.Count; i++)
            {
                for (int j = 0; j < Header[i].Length; j++)
                {
                    this.fpMain.ActiveSheet.ColumnHeader.Cells.Get(i, j).Value = Header[i].GetValue(j).ToString();
                }
            }

            //ColumnWidth
            if (ColWidth != null)
            {
                for (int j = 0; j < Header[0].Length; j++)
                {
                    this.fpMain.ActiveSheet.Columns[j].Width = (int)ColWidth[0].GetValue(j);
                }
            }

            //Column HorizontalAlignment
            if (ColHAlign != null)
            {
                CellHorizontalAlignment alignType = new CellHorizontalAlignment();

                for (int i = 0; i < ColHAlign[0].Length; i++)
                {
                    if (ColHAlign[0].GetValue(i).ToString() == "L") { alignType = CellHorizontalAlignment.Left; }
                    else if (ColHAlign[0].GetValue(i).ToString() == "R") { alignType = CellHorizontalAlignment.Right; }
                    else { alignType = CellHorizontalAlignment.Center; }

                    //Cell 의 HorizontalAlignment 
                    this.fpMain.ActiveSheet.Columns[i].HorizontalAlignment = alignType;
                    // Cell ColumnHeader HorizontalAlignment
                    this.fpMain.ActiveSheet.ColumnHeader.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                }
            }

            // SPAN
            if (RowSpan != null)
            {
                for (int i = 0; i < RowSpan.Count; i++)
                {
                    for (int j = 0; j < RowSpan[i].Length; j++)
                    {
                        this.fpMain.ActiveSheet.ColumnHeader.Cells.Get(i, j).RowSpan = (int)RowSpan[i].GetValue(j);
                    }
                }
            }

            if (ColSpan != null)
            {
                int iCursor = 0;
                for (int i = 0; i < ColSpan.Count; i++)
                {
                    iCursor = 0;
                    for (int j = 0; j < ColSpan[i].Length; j++)
                    {
                        this.fpMain.ActiveSheet.ColumnHeader.Cells.Get(i, j).ColumnSpan = (int)ColSpan[i].GetValue(j);
                        iCursor += (int)ColSpan[i].GetValue(j);
                    }
                }
            }
            #endregion

            #region [ RowHeader ]
            if (RowHeader != null)
            {
                if (UseRowFixHeader)
                {
                    #region [ RowHeader ]
                    this.fpMain.ActiveSheet.RowHeaderColumnCount = RowHeader.Count;
                    fpMain.ActiveSheet.Rows.Count = this.fpMain.ActiveSheet.RowHeaderColumnCount;
                    this.fpMain.ActiveSheet.RowHeader.Columns.Count = RowColWidth[0].Length;

                    for (int i = 0; i < RowHeader.Count; i++)
                    {
                        for (int j = 0; j < RowHeader[i].Length; j++)
                        {
                            this.fpMain.ActiveSheet.RowHeader.Cells.Get(i, j).Value = RowHeader[i].GetValue(j).ToString();
                        }
                    }

                    //ColumnWidth
                    if (RowColWidth != null)
                    {
                        for (int j = 0; j < RowColWidth[0].Length; j++)
                        {
                            this.fpMain.ActiveSheet.RowHeader.Columns[j].Width = (int)RowColWidth[0].GetValue(j);
                        }
                    }

                    // SPAN
                    if (RowRowSpan != null)
                    {
                        for (int i = 0; i < RowRowSpan.Count; i++)
                        {
                            for (int j = 0; j < RowRowSpan[i].Length; j++)
                            {
                                this.fpMain.ActiveSheet.RowHeader.Cells.Get(i, j).RowSpan = (int)RowRowSpan[i].GetValue(j);
                            }
                        }
                    }

                    if (RowColSpan != null)
                    {
                        int iCursor = 0;
                        for (int i = 0; i < RowColSpan.Count; i++)
                        {
                            iCursor = 0;
                            for (int j = 0; j < RowColSpan[i].Length; j++)
                            {
                                this.fpMain.ActiveSheet.RowHeader.Cells.Get(i, j).ColumnSpan = (int)RowColSpan[i].GetValue(j);
                                iCursor += (int)RowColSpan[i].GetValue(j);
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    AddFixedRow();
                }
            }

            #endregion

            #region [ Column Hide ]
            if (HideColumn != null)
            {
                foreach (int nColumn in HideColumn)
                {
                    this.fpMain.ActiveSheet.Columns[nColumn].Visible = false;
                }
            }
            #endregion

            #region [ Column Show ]
            if (ShowColumn != null)
            {
                foreach (int nColumn in ShowColumn)
                {
                    this.fpMain.ActiveSheet.Columns[nColumn].Visible = true;
                }
            }
            #endregion

            #region [ Column Lock ]
            if (LockColumn != null)
            {
                foreach (int nColumn in LockColumn)
                {
                    this.fpMain.ActiveSheet.Columns[nColumn].Locked = true;
                }
            }
            #endregion

            #region [ Design Mode사용할때 ]
            if (UseDesignMode)
            {
                //this.fpMain.ActiveSheet.Rows.Add(0, 1);
                //this.fpMain.ActiveSheet.Cells[0, 0].ColumnSpan = fpMain.ActiveSheet.Columns.Count;
                //fpMain.ActiveSheet.Rows[0].Height = 50;
                //fpMain.ActiveSheet.Rows[0].BackColor = System.Drawing.Color.Beige;
            }
            #endregion

            #region [ DataField 매치값이 있을때 ]
            if (ColumnDataFields != null)
            {
                int nCnt = 0;
                foreach (string str in ColumnDataFields)
                {
                    fpMain.ActiveSheet.Columns[nCnt].DataField = str;

                    nCnt++;
                }
            }
            #endregion
        }

        /// <summary>
        /// Grid의 Header속성을 적용 시킨다.2
        /// </summary>
        public void InitHeader2()
        {
            if (Header == null) return;

            //this.fpMain.ActiveSheet.Columns.Count = Header[0].Length;
            if (ColumnDataFields != null)
            {
                this.fpMain.ActiveSheet.Columns.Count =
                                                    (nColumnCount == -1) ?
                                                    ((Header[0].Length >= ColumnDataFields.Length) ? Header[0].Length : ColumnDataFields.Length) :
                                                    ColumnCount;
            }
            else
            {
                this.fpMain.ActiveSheet.Columns.Count = (nColumnCount == -1) ? Header[0].Length : ColumnCount;
            }

            #region [ Column Header ]
            this.fpMain.ActiveSheet.ColumnHeaderRowCount = Header.Count;

            for (int i = 0; i < Header.Count; i++)
            {
                for (int j = 0; j < Header[i].Length; j++)
                {
                    this.fpMain.ActiveSheet.ColumnHeader.Cells.Get(i, j).Value = Header[i].GetValue(j).ToString();
                }
            }

            //ColumnWidth
            if (ColWidth != null)
            {
                for (int j = 0; j < Header[0].Length; j++)
                {
                    this.fpMain.ActiveSheet.Columns[j].Width = (int)ColWidth[0].GetValue(j);
                }
            }

            //Column HorizontalAlignment
            if (ColHAlign != null)
            {
                CellHorizontalAlignment alignType = new CellHorizontalAlignment();

                for (int i = 0; i < ColHAlign[0].Length; i++)
                {
                    if (ColHAlign[0].GetValue(i).ToString() == "L") { alignType = CellHorizontalAlignment.Left; }
                    else if (ColHAlign[0].GetValue(i).ToString() == "R") { alignType = CellHorizontalAlignment.Right; }
                    else { alignType = CellHorizontalAlignment.Center; }

                    //Cell 의 HorizontalAlignment 
                    this.fpMain.ActiveSheet.Columns[i].HorizontalAlignment = alignType;
                    // Cell ColumnHeader HorizontalAlignment
                    this.fpMain.ActiveSheet.ColumnHeader.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                }
            }

            //// SPAN
            //if (RowSpan != null)
            //{
            //    for (int i = 0; i < RowSpan.Count; i++)
            //    {
            //        for (int j = 0; j < RowSpan[i].Length; j++)
            //        {
            //            this.fpMain.ActiveSheet.ColumnHeader.Cells.Get(i, j).RowSpan = (int)RowSpan[i].GetValue(j);
            //        }
            //    }
            //}

            //if (ColSpan != null)
            //{
            //    int iCursor = 0;
            //    for (int i = 0; i < ColSpan.Count; i++)
            //    {
            //        iCursor = 0;
            //        for (int j = 0; j < ColSpan[i].Length; j++)
            //        {
            //            this.fpMain.ActiveSheet.ColumnHeader.Cells.Get(i, j).ColumnSpan = (int)ColSpan[i].GetValue(j);
            //            iCursor += (int)ColSpan[i].GetValue(j);
            //        }
            //    }
            //}
            #endregion

            #region [ RowHeader ]
            if (RowHeader != null)
            {
                if (UseRowFixHeader)
                {
                    #region [ RowHeader ]
                    this.fpMain.ActiveSheet.RowHeaderColumnCount = RowHeader.Count;
                    fpMain.ActiveSheet.Rows.Count = this.fpMain.ActiveSheet.RowHeaderColumnCount;
                    this.fpMain.ActiveSheet.RowHeader.Columns.Count = RowColWidth[0].Length;

                    for (int i = 0; i < RowHeader.Count; i++)
                    {
                        for (int j = 0; j < RowHeader[i].Length; j++)
                        {
                            this.fpMain.ActiveSheet.RowHeader.Cells.Get(i, j).Value = RowHeader[i].GetValue(j).ToString();
                        }
                    }

                    //ColumnWidth
                    if (RowColWidth != null)
                    {
                        for (int j = 0; j < RowColWidth[0].Length; j++)
                        {
                            this.fpMain.ActiveSheet.RowHeader.Columns[j].Width = (int)RowColWidth[0].GetValue(j);
                        }
                    }

                    // SPAN
                    if (RowRowSpan != null)
                    {
                        for (int i = 0; i < RowRowSpan.Count; i++)
                        {
                            for (int j = 0; j < RowRowSpan[i].Length; j++)
                            {
                                this.fpMain.ActiveSheet.RowHeader.Cells.Get(i, j).RowSpan = (int)RowRowSpan[i].GetValue(j);
                            }
                        }
                    }

                    if (RowColSpan != null)
                    {
                        int iCursor = 0;
                        for (int i = 0; i < RowColSpan.Count; i++)
                        {
                            iCursor = 0;
                            for (int j = 0; j < RowColSpan[i].Length; j++)
                            {
                                this.fpMain.ActiveSheet.RowHeader.Cells.Get(i, j).ColumnSpan = (int)RowColSpan[i].GetValue(j);
                                iCursor += (int)RowColSpan[i].GetValue(j);
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    AddFixedRow();
                }
            }

            #endregion

            #region [ Column Hide ]
            if (HideColumn != null)
            {
                foreach (int nColumn in HideColumn)
                {
                    this.fpMain.ActiveSheet.Columns[nColumn].Visible = false;
                }
            }
            #endregion

            #region [ Column Show ]
            if (ShowColumn != null)
            {
                foreach (int nColumn in ShowColumn)
                {
                    this.fpMain.ActiveSheet.Columns[nColumn].Visible = true;
                }
            }
            #endregion

            #region [ Column Lock ]
            if (LockColumn != null)
            {
                foreach (int nColumn in LockColumn)
                {
                    this.fpMain.ActiveSheet.Columns[nColumn].Locked = true;
                }
            }
            #endregion

            #region [ Design Mode사용할때 ]
            if (UseDesignMode)
            {
                //this.fpMain.ActiveSheet.Rows.Add(0, 1);
                //this.fpMain.ActiveSheet.Cells[0, 0].ColumnSpan = fpMain.ActiveSheet.Columns.Count;
                //fpMain.ActiveSheet.Rows[0].Height = 50;
                //fpMain.ActiveSheet.Rows[0].BackColor = System.Drawing.Color.Beige;
            }
            #endregion

            #region [ DataField 매치값이 있을때 ]
            if (ColumnDataFields != null)
            {
                int nCnt = 0;
                foreach (string str in ColumnDataFields)
                {
                    fpMain.ActiveSheet.Columns[nCnt].DataField = str;

                    nCnt++;
                }
            }
            #endregion
        }

        /// <summary>
        /// DataBind후 Spread의 마지막 속성들을 적용시킨다.
        /// </summary>
        public void AfterDataBind()
        {
            #region [ Column Type ]
            if (lstCellType != null)
            {
                for (int i = 0; i < lstCellType.Count; i++)
                {
                    try
                    {
                        this.fpMain.ActiveSheet.Columns[i].CellType = lstCellType[i];  // CellType적용시키기
                        //if (this.fpMain.ActiveSheet.Columns[i].CellType.ToString().Equals("FarPoint.Win.Spread.CellType.ComboBoxCellType"))
                        //{
                        //    this.fpMain.ActiveSheet.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        //    this.fpMain.ActiveSheet.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        //}
                    }
                    catch { }
                }
            }
            #endregion
        }

        /// <summary>
        /// CellType 적용시키기
        /// </summary>
        /// <param name="cellType">FarPoint.Win.Spread.CellType</param>
        public void SetDefaultCellType(string cellType)
        {
            #region [ CellType]
            for (int i = 0; i < this.fpMain.ActiveSheet.Columns.Count; i++)
            {
                try
                {
                    this.fpMain.ActiveSheet.Columns[i].CellType = this.SetCellType(cellType);
                }
                catch { }
            }
            #endregion
        }

        /// <summary>
        /// Row Header를 안보이게 한 상태에서 Row의 특정 영역을 Header처럼 보이게 사용할때 사용
        /// </summary>
        private void AddFixedRow()
        {
            fpMain.ActiveSheet.RowHeaderVisible = false;
            fpMain.ActiveSheet.Rows.Count = RowHeader.Count;



            for (int i = 0; i < RowHeader.Count; i++)
            {
                for (int j = 0; j < RowHeader[i].Length; j++)
                {
                    this.fpMain.ActiveSheet.Cells.Get(i, j).Value = RowHeader[i].GetValue(j).ToString();
                }
            }

            //ColumnWidth
            if (RowColWidth != null)
            {
                for (int j = 0; j < RowColWidth[0].Length; j++)
                {
                    this.fpMain.ActiveSheet.Columns[j].Width = (int)RowColWidth[0].GetValue(j);
                }
            }

            // SPAN
            if (RowRowSpan != null)
            {
                for (int i = 0; i < RowRowSpan.Count; i++)
                {
                    for (int j = 0; j < RowRowSpan[i].Length; j++)
                    {
                        this.fpMain.ActiveSheet.Cells.Get(i, j).RowSpan = (int)RowRowSpan[i].GetValue(j);
                    }
                }
            }

            if (RowColSpan != null)
            {
                int iCursor = 0;
                for (int i = 0; i < RowColSpan.Count; i++)
                {
                    iCursor = 0;
                    for (int j = 0; j < RowColSpan[i].Length; j++)
                    {
                        this.fpMain.ActiveSheet.Cells.Get(i, j).ColumnSpan = (int)RowColSpan[i].GetValue(j);
                        iCursor += (int)RowColSpan[i].GetValue(j);
                    }
                }
            }
        }

        object[] objTList = null;
        DataTable tblTemp = null;
        DataTable tblReturn = null;
        /// <summary>
        /// Sample Data생성
        /// </summary>
        /// <param name="tblData">원본데이터</param>
        /// <param name="objList">Sample로 만들 String List</param>
        /// <returns>DataTable</returns>
        public DataTable GetSampleData(DataTable tblData, object[] objList)
        {

            tblTemp = tblData;
            objTList = objList;

            Thread t = new Thread(new ThreadStart(FillDataSet));
            t.Start();
            t.Join();
            t.Abort();
            return tblReturn;
        }

        public string GetExcelData(string strPath, string strSheetName)
        {
            DataTable tblData = LoadExcel(strPath, strSheetName);
            DataSet dsetData = new DataSet();
            dsetData.Tables.Add(tblData);

            return dsetData.GetXml();
        }

        public string GetExcelData(string strPath)
        {
            DataTable tblData = LoadExcel(strPath);
            DataSet dsetData = new DataSet();
            dsetData.Tables.Add(tblData);

            return dsetData.GetXml();
        }

        public DataTable GetDataWithXML(string sXML)
        {
            string strTemp = "<?xml version='1.0' encoding='euc-kr' ?>";
            strTemp += sXML;

            DataSet dsetData = new DataSet();
            System.IO.MemoryStream streamXML = new System.IO.MemoryStream(System.Text.Encoding.Default.GetBytes(strTemp));
            dsetData.ReadXml(streamXML);

            return dsetData.Tables[0];
        }

        public DataTable GetDataWithXML(string sXML, bool IsFullXML)
        {
            DataSet dsetData = new DataSet();
            System.IO.MemoryStream streamXML = new System.IO.MemoryStream(System.Text.Encoding.Default.GetBytes(sXML));
            dsetData.ReadXml(streamXML);

            return dsetData.Tables[0];
        }

        public DataTable LoadExcel(string filename, string strSheetName)
        {
            string fname = System.IO.Path.GetFileName(filename);
            string fpath = System.IO.Path.GetDirectoryName(filename);
            string strQuery = string.Format("SELECT * FROM [{0}$]", strSheetName);

            Microsoft.Win32.RegistryKey localmachine = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            Microsoft.Win32.RegistryKey subkey = localmachine.OpenSubKey("Microsoft", true).OpenSubKey("Jet", true).OpenSubKey("4.0", true).OpenSubKey("Engines", true).OpenSubKey("Excel", true);
            subkey.SetValue("TypeGuessRows", 0);


            DataTable dtTable = new DataTable();
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                                                    @"Data Source=" + filename + ";" +
                                                                    @"Extended Properties=" + Convert.ToChar(34).ToString() +
                                                                    @"Excel 8.0;HDR=NO;IMEX=1;" + Convert.ToChar(34).ToString();



            OleDbConnection conn = new OleDbConnection(connectString);
            try
            {
                conn.Open();

                OleDbCommand cmdSelect = new OleDbCommand(strQuery, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmdSelect);

                adapter.Fill(dtTable);
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
                conn = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }

            return dtTable;
        }

        public DataTable LoadExcel(string filename)
        {
            string fname = System.IO.Path.GetFileName(filename);
            string fpath = System.IO.Path.GetDirectoryName(filename);

            Microsoft.Win32.RegistryKey localmachine = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            Microsoft.Win32.RegistryKey subkey = localmachine.OpenSubKey("Microsoft", true).OpenSubKey("Jet", true).OpenSubKey("4.0", true).OpenSubKey("Engines", true).OpenSubKey("Excel", true);
            subkey.SetValue("TypeGuessRows", 0);


            DataTable dtTable = new DataTable();
            DataTable dtSNTable = new DataTable();

            string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                                                    @"Data Source=" + filename + ";" +
                                                                    @"Extended Properties=" + Convert.ToChar(34).ToString() +
                                                                    @"Excel 8.0;HDR=YES;IMEX=1;" + Convert.ToChar(34).ToString();



            OleDbConnection conn = new OleDbConnection(connectString);
            try
            {
                conn.Open();

                dtSNTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string strSheetName = dtSNTable.Rows[0]["TABLE_NAME"].ToString();

                if (strSheetName.EndsWith("$"))
                {
                    strSheetName = strSheetName.Substring(0, strSheetName.Length - 1);
                }

                dtSNTable.Dispose();
                dtSNTable = null;

                string strQuery = string.Format("SELECT * FROM [{0}$]", strSheetName);

                OleDbCommand cmdSelect = new OleDbCommand(strQuery, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmdSelect);

                adapter.Fill(dtTable);
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
                conn = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }

            return dtTable;
        }

        /// <summary>
        /// Data 채워넣기
        /// </summary>
        private void FillDataSet()
        {
            for (int i = 0; i < SampleDataRowCount; i++)
            {
                DataRow dr = tblTemp.NewRow();
                int nCnt = 0;
                foreach (DataColumn col in tblTemp.Columns)
                {
                    if (SampleNotChangeColumn == null)
                    {

                        dr[col.ColumnName] = GetColumnValue(objTList[nCnt], col.ColumnName.ToString(), lstCellType[nCnt]);
                        //dr[col.ColumnName] = GetColumnValue(objTList[nCnt], col.ColumnName.ToString(), col.DataType);
                    }
                    else
                    {
                        if (SampleNotChangeColumn.IndexOf(nCnt) > -1)
                        {
                            dr[col.ColumnName] = objTList[nCnt].ToString();
                        }
                        else
                        {
                            dr[col.ColumnName] = GetColumnValue(objTList[nCnt], col.ColumnName.ToString(), lstCellType[nCnt]);
                            //dr[col.ColumnName] = GetColumnValue(objTList[nCnt], col.ColumnName.ToString(), col.DataType);
                        }
                    }
                    nCnt++;
                    Thread.Sleep(1);
                }

                tblTemp.Rows.Add(dr);
            }

            DataTable tblClone = tblTemp.Clone();
            foreach (DataRow dr in tblTemp.Select("1=1", tblTemp.Columns[0].ColumnName.ToString()))
            {
                tblClone.Rows.Add(dr.ItemArray);
            }

            tblReturn = tblClone;
        }

        /// <summary>
        /// Sample값 만들때 Column값 가져오기
        /// </summary>
        /// <param name="objTemp">Object</param>
        /// <param name="strTitle">Column Title</param>
        /// <param name="t">Type</param>
        /// <returns>string</returns>
        public string GetColumnValue(object objTemp, string strTitle, Type t)
        {
            string strReturn = string.Empty;
            try
            {
                System.Random random = new System.Random();
                int nRandom;

                switch (t.Name.ToUpper())
                {
                    case "DATETIME":
                        DateTime dt = System.DateTime.Now;
                        nRandom = random.Next(0, 20);
                        dt = dt.AddDays(-nRandom);
                        strReturn = dt.ToShortDateString();
                        break;
                    case "STRING":
                        strReturn = objTemp == null ? strTitle + "_" + random.Next(0, 2) : (objTemp as string).Substring(0, objTemp.ToString().Length - 1) + random.Next(0, 2);
                        break;
                    case "INT32":
                        strReturn = random.Next(0, 10000).ToString();
                        break;
                    default:
                        strReturn = random.NextDouble().ToString();
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }


            return strReturn;
        }

        /// <summary>
        /// Sample값 만들때 Column값 가져오기
        /// </summary>
        /// <param name="objTemp">Object</param>
        /// <param name="strTitle">Column Title</param>
        /// <param name="t">Type</param>
        /// <returns>string</returns>
        public string GetColumnValue(object objTemp, string strTitle, FarPoint.Win.Spread.CellType.ICellType t)
        {
            string strReturn = string.Empty;
            try
            {
                System.Random random = new System.Random();
                int nRandom;

                switch (t.ToString().ToUpper())
                {
                    case "DATETIMECELLTYPE":
                        DateTime dt = System.DateTime.Now;
                        nRandom = random.Next(0, 20);
                        dt = dt.AddDays(-nRandom);
                        strReturn = dt.ToShortDateString();
                        break;
                    case "TEXTCELLTYPE":
                        strReturn = objTemp == null ? strTitle + "_" + random.Next(0, 2) : (objTemp as string).Substring(0, objTemp.ToString().Length - 1) + random.Next(0, 2);
                        break;
                    case "NUMBERCELLTYPE":
                        strReturn = random.Next(0, 10000).ToString();
                        break;
                    case "CHECKBOXCELLTYPE":
                        strReturn = random.Next(0, 1).ToString();
                        break;
                    case "COMBOBOXCELLTYPE":
                        strReturn = random.Next(0, 1).ToString();
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }


            return strReturn;
        }


        /// <summary>
        /// Spread에서 해당 Column의 Index를 알려준다
        /// </summary>
        /// <param name="spread">FarPoint.Win.Spread.FpSpread</param>
        /// <param name="nRow">Row</param>
        /// <param name="strColumnName">ColumnName</param>
        /// <returns>string</returns>
        public string GetColumnValue(FarPoint.Win.Spread.FpSpread spread, int nRow, string strColumnName)
        {
            #region [ 작업전 원본 ]
            //int nBreak = -1;
            //DataTable tblData = null;
            //if (spread.ActiveSheet.DataSource.GetType().Equals(typeof(System.Data.DataSet)))
            //{
            //    tblData = (spread.ActiveSheet.DataSource as DataSet).Tables[0];
            //}
            //else
            //{
            //    tblData = spread.Sheets[0].DataSource as DataTable;
            //}

            //for (int i = 0; i < tblData.Columns.Count; i++)
            //{
            //    if (tblData.Columns[i].ColumnName.ToUpper().Equals(strColumnName.ToUpper()))
            //    {
            //        nBreak = i;
            //        break;
            //    }
            //}
            //return tblData.Rows[nRow][nBreak].ToString() == null ? string.Empty : tblData.Rows[nRow][nBreak].ToString();
            #endregion

            string strReturn = string.Empty;
            FarPoint.Win.Spread.SheetView fspSheetX;
            fspSheetX = spread.Sheets[0];

            for (int i = 0; i < fspSheetX.Columns.Count; i++)
            {
                if (fspSheetX.Columns[i].DataField.ToUpper().Equals(strColumnName.ToUpper()))
                {
                    strReturn = fspSheetX.Cells[nRow, i].Value == null ? string.Empty : fspSheetX.Cells[nRow, i].Value.ToString();
                    break;
                }
            }

            return strReturn;
        }

        /// <summary>
        /// Spread에서 해당 Column의 Index를 알려준다
        /// </summary>
        /// <param name="spread">FarPoint.Win.Spread.FpSpread</param>
        /// <param name="nRow">Row</param>
        /// <param name="strColumnName">ColumnName</param>
        /// <returns>string</returns>
        public string GetColumnValue(FarPoint.Win.Spread.FpSpread spread, string strColumnName, int nRow)
        {
            string strReturn = string.Empty;
            FarPoint.Win.Spread.SheetView fspSheetX;
            fspSheetX = spread.Sheets[0];

            for (int i = 0; i < fspSheetX.Columns.Count; i++)
            {
                if (fspSheetX.Columns[i].DataField.ToUpper().Equals(strColumnName.ToUpper()))
                {
                    strReturn = fspSheetX.Cells[nRow, i].Value == null ? string.Empty : fspSheetX.Cells[nRow, i].Value.ToString();
                    break;
                }
            }

            return strReturn;
        }

        /// <summary>
        /// Spread의 특정 Column값을 넣어준다.
        /// </summary>
        /// <param name="spread"></param>
        /// <param name="nRow"></param>
        /// <param name="strColumnName"></param>
        /// <param name="Value"></param>
        public void SetColumnValue(FarPoint.Win.Spread.FpSpread spread, int nRow, string strColumnName, object Value)
        {
            string strReturn = string.Empty;
            FarPoint.Win.Spread.SheetView fspSheetX;
            fspSheetX = spread.Sheets[0];

            for (int i = 0; i < fspSheetX.Columns.Count; i++)
            {
                if (fspSheetX.Columns[i].DataField.ToUpper().Equals(strColumnName.ToUpper()))
                {
                    fspSheetX.Cells[nRow, i].Value = Value;
                    break;
                }
            }

            //for (int i = 0; i < spread.ActiveSheet.Columns.Count; i++)
            //{
            //    if (spread.ActiveSheet.Columns[i].DataField.ToUpper().Equals(strColumnName.ToUpper()))
            //    {
            //        spread.ActiveSheet.Cells[nRow, i].Value = Value;
            //        break;
            //    }
            //}
        }

        /// <summary>
        /// Spread의 특정 Column값을 Tag에 넣어준다.
        /// </summary>
        /// <param name="spread"></param>
        /// <param name="nRow"></param>
        /// <param name="strColumnName"></param>
        /// <param name="Value"></param>
        public void SetColumnTag(FarPoint.Win.Spread.FpSpread spread, int nRow, string strColumnName, object Value)
        {
            string strReturn = string.Empty;
            FarPoint.Win.Spread.SheetView fspSheetX;
            fspSheetX = spread.Sheets[0];

            for (int i = 0; i < fspSheetX.Columns.Count; i++)
            {
                if (fspSheetX.Columns[i].DataField.ToUpper().Equals(strColumnName.ToUpper()))
                {
                    fspSheetX.Cells[nRow, i].Tag = Value;
                    break;
                }
            }
        }

        /// <summary>
        /// Spread에서 해당 Column의 Index를 알려준다
        /// </summary>
        /// <param name="spread">FarPoint.Win.Spread.FpSpread</param>
        /// <param name="strColumnName">ColumnName</param>
        /// <returns>int</returns>
        public int GetColumnIndex(FarPoint.Win.Spread.FpSpread spread, string strColumnName)
        {
            int nBreak = -1;
            for (int i = 0; i < spread.ActiveSheet.Columns.Count; i++)
            {
                if (spread.ActiveSheet.Columns[i].DataField.ToUpper().Equals(strColumnName.ToUpper()))
                {
                    nBreak = i;
                    break;
                }
            }
            return nBreak;
        }

        /// <summary>
        /// Row의 전체 값을 HashTable로 변환해서 Return한다
        /// </summary>
        /// <param name="spread">FarPoint.Win.Spread.FpSpread spread</param>
        /// <param name="nRow">Row</param>
        /// <returns>Hashtable</returns>
        public Hashtable GetRowHashTable(FarPoint.Win.Spread.FpSpread spread, int nRow, List<string> lstAddKeys)
        {
            Hashtable ht = new Hashtable();
            try
            {
                string[] straTemp = null;
                if (lstAddKeys != null)
                {
                    foreach (string strKey in lstAddKeys)
                    {
                        straTemp = strKey.Split(':');
                        ht.Add(straTemp[0], straTemp[1]);
                    }
                }
                DataTable tblTemp = new DataTable();
                FarPoint.Win.Spread.SheetView fspSheetX;
                fspSheetX = spread.Sheets[0];

                for (int i = 0; i < fspSheetX.Columns.Count; i++)
                {
                    if (tblTemp.Columns.IndexOf(fspSheetX.Columns[i].DataField.ToString()) == -1)
                    {
                        tblTemp.Columns.Add(fspSheetX.Columns[i].DataField.ToString(), typeof(string));
                    }
                }

                DataRow dr = tblTemp.NewRow();
                for (int i = 0; i < fspSheetX.Columns.Count; i++)
                {
                    dr[fspSheetX.Columns[i].DataField] = fspSheetX.Cells[nRow, i].Value;
                }
                tblTemp.Rows.Add(dr);
                bool IsSearch;
                foreach (DataColumn col in tblTemp.Columns)
                {
                    IsSearch = false;
                    foreach (string str in ht.Keys)
                    {
                        if (str.ToUpper() == col.ColumnName.ToUpper())
                        {
                            IsSearch = true;
                            break;
                        }
                    }
                    if (!IsSearch) ht.Add(col.ColumnName.ToUpper(), tblTemp.Rows[0][col.ColumnName].ToString());
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message.ToString()); }

            return ht;
        }

        /// <summary>
        /// Row의 전체 값을 HashTable로 변환해서 Return한다
        /// null값을 공백값으로 치환한다.
        /// </summary>
        /// <param name="spread"></param>
        /// <param name="nRow"></param>
        /// <param name="lstAddKeys"></param>
        /// <param name="strType"></param>
        /// <returns>Hashtable</returns>
        public Hashtable GetRowHashTable(FarPoint.Win.Spread.FpSpread spread, int nRow, List<string> lstAddKeys, string strType)
        {
            DataSet dsTemp = new DataSet();
            DataTable tblTemp = new DataTable();

            Hashtable ht = new Hashtable();
            string[] straTemp = null;

            if (lstAddKeys != null)
            {
                foreach (string strKey in lstAddKeys)
                {
                    straTemp = strKey.Split(':');
                    ht.Add(straTemp[0]
                        , (straTemp[1] == null) ? "" : straTemp[1]);
                }
            }

            if (spread.ActiveSheet.DataSource.GetType().Name == "DataTable")
            {
                tblTemp = spread.ActiveSheet.DataSource as DataTable;
            }
            else
            {
                dsTemp = spread.ActiveSheet.DataSource as DataSet;
                tblTemp = dsTemp.Tables[0] as DataTable;
            }

            //foreach (DataColumn col in tblTemp.Columns)
            //{
            //    ht.Add(col.ColumnName.ToUpper(), tblTemp.Rows[nRow][col.ColumnName].ToString());
            //}

            //for (int i = 0; i < tblTemp.Columns.Count; i++)
            //{
            //    if (strType.Trim() == "")
            //    {
            //        ht.Add(tblTemp.Columns[i].ColumnName.ToString().ToUpper(), tblTemp.Rows[nRow][tblTemp.Columns[i].ColumnName.ToString()]);
            //    }
            //    else
            //    {
            //        ht.Add(tblTemp.Columns[i].ColumnName.ToString().ToUpper()		//KEY
            //                    , (tblTemp.Rows[nRow][tblTemp.Columns[i].ColumnName.ToString()] == null) ? "" : tblTemp.Rows[nRow][tblTemp.Columns[i].ColumnName.ToString()]);		//VALUE
            //    }
            //}

            for (int i = 0; i < spread.ActiveSheet.Columns.Count; i++)
            {
                if (strType.Trim() == "")
                {
                    ht.Add(spread.ActiveSheet.Columns[i].DataField.ToString(), spread.ActiveSheet.Cells[nRow, i].Value);
                }
                else
                {
                    ht.Add(spread.ActiveSheet.Columns[i].DataField.ToString()		//KEY
                                , (spread.ActiveSheet.Cells[nRow, i].Value == null) ? "" : spread.ActiveSheet.Cells[nRow, i].Value);		//VALUE
                }
            }

            return ht;
        }

        /// <summary>
        /// Row의 전체 값을 HashTable로 변환해서 Return한다
        /// </summary>
        /// <param name="tblData">DataTable</param>
        /// <param name="nRow">Row</param>
        /// <param name="lstAddKeys">기존 DataTable의 Column값이 다시 추가해야할 Column</param>
        /// <returns>Hashtable</returns>
        public Hashtable GetRowHashTable(DataTable tblData, int nRow, List<string> lstAddKeys)
        {
            Hashtable ht = new Hashtable();
            string[] straTemp = null;
            if (lstAddKeys != null)
            {
                foreach (string strKey in lstAddKeys)
                {
                    straTemp = strKey.Split(':');
                    ht.Add(straTemp[0], straTemp[1]);
                }
            }


            for (int i = 0; i < tblData.Columns.Count; i++)
            {
                ht.Add(tblData.Columns[i].ColumnName.ToString().ToUpper(), tblData.Rows[nRow][tblData.Columns[i].ColumnName.ToString()]);
            }
            return ht;
        }

        /// <summary>
        /// Row의 전체 값을 HashTable로 변환해서 Return한다
        /// null값을 공백값으로 치환한다.
        /// </summary>
        /// <param name="tblData">DataTable</param>
        /// <param name="nRow">Row</param>
        /// <param name="lstAddKeys">기존 DataTable의 Column값이 다시 추가해야할 Column</param>
        /// <returns>Hashtable</returns>
        public Hashtable GetRowHashTable(DataTable tblData, int nRow, List<string> lstAddKeys, string strType)
        {
            Hashtable ht = new Hashtable();
            string[] straTemp = null;
            if (lstAddKeys != null)
            {
                foreach (string strKey in lstAddKeys)
                {
                    straTemp = strKey.Split(':');
                    ht.Add(straTemp[0]
                        , (straTemp[1] == null) ? "" : straTemp[1]);
                }
            }


            for (int i = 0; i < tblData.Columns.Count; i++)
            {
                if (strType.Trim() == "")
                {
                    ht.Add(tblData.Columns[i].ColumnName.ToString().ToUpper(), tblData.Rows[nRow][tblData.Columns[i].ColumnName.ToString()]);
                }
                else
                {
                    ht.Add(tblData.Columns[i].ColumnName.ToString().ToUpper()		//KEY
                                , (tblData.Rows[nRow][tblData.Columns[i].ColumnName.ToString()] == null) ? "" : tblData.Rows[nRow][tblData.Columns[i].ColumnName.ToString()]);		//VALUE
                }


            }
            return ht;
        }

        /// <summary>
        /// Row의 전체 값을 HashTable로 변환해서 Return한다
        /// </summary>
        /// <param name="tblData">DataTable</param>
        /// <param name="nRow">Row</param>
        /// <param name="lstAddKeys">기존 DataTable의 Column값이 다시 추가해야할 Column</param>
        /// <returns>Hashtable</returns>
        public Hashtable GetRowHashTable(DataSet dsetFData, int nRow, List<string> lstAddKeys, string strType)
        {
            Hashtable ht = new Hashtable();
            string[] straTemp = null;
            if (lstAddKeys != null)
            {
                foreach (string strKey in lstAddKeys)
                {
                    straTemp = strKey.Split(':');
                    ht.Add(straTemp[0]
                        , (straTemp[1] == null) ? "" : straTemp[1]);
                }
            }


            for (int i = 0; i < dsetFData.Tables[0].Columns.Count; i++)
            {
                if (strType.Trim() == "")
                {
                    ht.Add(dsetFData.Tables[0].Columns[i].ColumnName.ToString().ToUpper(), dsetFData.Tables[0].Rows[nRow][dsetFData.Tables[0].Columns[i].ColumnName.ToString()]);
                }
                else
                {
                    ht.Add(dsetFData.Tables[0].Columns[i].ColumnName.ToString().ToUpper()		//KEY
                                , (dsetFData.Tables[0].Rows[nRow][dsetFData.Tables[0].Columns[i].ColumnName.ToString()] == null) ? "" : dsetFData.Tables[0].Rows[nRow][dsetFData.Tables[0].Columns[i].ColumnName.ToString()]);		//VALUE
                }


            }
            return ht;
        }

        /// <summary>
        /// Spread의 해당 Row의 모든 값을 Table로 만들어서 Return
        /// </summary>
        /// <param name="spread">FarPoint.Win.Spread.FpSpread</param>
        /// <param name="nRow">Row</param>
        /// <param name="lstAddKeys">기존 DataTable의 Column값이 다시 추가해야할 Column</param>
        /// <returns>DataTable</returns>
        public DataTable GetRowTable(FarPoint.Win.Spread.FpSpread spread, int nRow, List<string> lstAddKeys)
        {
            DataTable dt = new DataTable();

            DataTable dtSource = null;
            if (spread.ActiveSheet.DataSource.GetType().Equals(typeof(System.Data.DataSet)))
            {
                dtSource = (spread.ActiveSheet.DataSource as DataSet).Tables[0];
            }
            else
            {
                dtSource = spread.ActiveSheet.DataSource as DataTable;
            }

            string[] straTemp = null;

            #region [ Column생성 ]
            if (lstAddKeys != null)
            {
                foreach (string strKey in lstAddKeys)
                {
                    straTemp = strKey.Split(':');
                    dt.Columns.Add(new DataColumn(straTemp[0], typeof(string)));
                }
            }
            foreach (DataColumn col in dtSource.Columns)
            {
                dt.Columns.Add(new DataColumn(col.ColumnName.ToString().ToUpper(), col.DataType));
            }


            #endregion

            #region [ Row생성 ]
            DataRow dr = dt.NewRow();
            if (lstAddKeys != null)
            {
                foreach (string strKey in lstAddKeys)
                {
                    straTemp = strKey.Split(':');
                    dr[straTemp[0]] = straTemp[1];
                }
            }

            foreach (DataColumn col in dtSource.Columns)
            {
                dr[col.ColumnName.ToString().ToUpper()] = dtSource.Rows[nRow][col.ColumnName];
            }

            dt.Rows.Add(dr);
            #endregion

            return dt;
        }

        /// <summary>
        /// 실행문을 위한 DataTable생성
        /// </summary>
        /// <param name="objList">ColumnName List</param>
        /// <returns>DataTable</returns>
        public DataTable GetExecuteTable(object[] objList)
        {
            DataTable tblReturn = new DataTable();
            try
            {
                for (int i = 0; i < objList.Length; i++)
                {
                    tblReturn.Columns.Add(new DataColumn("col" + i.ToString(), typeof(string)));
                }
                DataRow dr = tblReturn.NewRow();
                for (int i = 0; i < objList.Length; i++)
                {
                    dr[i] = objList[i] == null ? "" : objList[i].ToString();
                }

                tblReturn.Rows.Add(dr);
            }
            catch { }

            return tblReturn;
        }

        /// <summary>
        /// 실행문을 위한 DataTable생성
        /// </summary>
        /// <param name="objList">ColumnName List</param>
        /// <returns>DataTable</returns>
        public DataTable GetExecuteTable(object[] objList, bool nullable)
        {
            DataTable tblReturn = new DataTable();
            try
            {
                for (int i = 0; i < objList.Length; i++)
                {
                    tblReturn.Columns.Add(new DataColumn("col" + i.ToString(), typeof(string)));
                }
                DataRow dr = tblReturn.NewRow();
                for (int i = 0; i < objList.Length; i++)
                {
                    if (!nullable)
                    {
                        dr[i] = objList[i] == null ? "" : objList[i].ToString();
                    }
                    else
                    {
                        dr[i] = objList[i].ToString();
                    }
                }

                tblReturn.Rows.Add(dr);
            }
            catch { }

            return tblReturn;
        }

        /// <summary>
        /// 실행문을 위한 DataTable생성
        /// </summary>
        /// <param name="objList">ColumnName List</param>
        /// <returns>DataTable</returns>
        public DataTable GetExecuteTable(List<object[]> objList)
        {
            DataTable tblReturn = new DataTable();
            try
            {
                if (objList.Count == 0) return null;

                for (int i = 0; i < objList[0].Length; i++)
                {
                    tblReturn.Columns.Add(new DataColumn("col" + i.ToString(), typeof(string)));
                }

                foreach (object[] objTemp in objList)
                {
                    DataRow dr = tblReturn.NewRow();
                    for (int i = 0; i < objTemp.Length; i++)
                    {
                        dr[i] = objTemp[i] == null ? "" : objTemp[i].ToString();
                    }

                    tblReturn.Rows.Add(dr);
                }


            }
            catch { }

            return tblReturn;
        }

        /// <summary>
        /// 실행문을 위한 DataTable생성
        /// </summary>
        /// <param name="objList">ColumnName List</param>
        /// <returns>DataTable</returns>
        public DataTable GetExecuteTable(List<object[]> objList, bool nullable)
        {
            DataTable tblReturn = new DataTable();
            try
            {
                if (objList.Count == 0) return null;

                for (int i = 0; i < objList[0].Length; i++)
                {
                    tblReturn.Columns.Add(new DataColumn("col" + i.ToString(), typeof(string)));
                }

                foreach (object[] objTemp in objList)
                {
                    DataRow dr = tblReturn.NewRow();
                    for (int i = 0; i < objTemp.Length; i++)
                    {
                        if (!nullable)
                        {
                            dr[i] = objTemp[i] == null ? "" : objTemp[i].ToString();
                        }
                        else
                        {
                            dr[i] = objTemp[i];
                        }
                    }

                    tblReturn.Rows.Add(dr);
                }


            }
            catch { }

            return tblReturn;
        }

        #region [ Groupping ]
        /// <summary>
        /// Groupping된 데이터를 가져온다
        /// </summary>
        /// <param name="dsetData">원본 DataSet</param>
        /// <param name="lstGroup">Goupping할 String List</param>
        /// <param name="lstCompute">계산할 String List</param>
        /// <returns></returns>
        public DataTable GetGroupData(DataSet dsetData, List<string> lstGroup, List<string> lstCompute)
        {
            dsetFData = dsetData;
            straGroup = lstGroup;
            straCompute = lstCompute;
            tblTotalGroup = new DataTable();

            for (int i = 0; i < straGroup.Count; i++)
            {
                tblTotalGroup.Columns.Add(new DataColumn(straGroup[i].ToString(), typeof(string)));
            }

            for (int i = 0; i < straCompute.Count; i++)
            {
                tblTotalGroup.Columns.Add(new DataColumn(straCompute[i].ToString().Split(':').Length == 2 ? straCompute[i].ToString().Split(':')[0].ToString() : straCompute[i].ToString().Split(':')[1].ToString(), typeof(float)));
                //tblTotalGroup.Columns.Add(new DataColumn(straCompute[i].ToString().Split(':')[0], typeof(float)));
                //tblTotalGroup.Columns.Add(new DataColumn(straCompute[i].ToString().Split(':')[0], typeof(float)));
            }

            //==========
            DataRow[] rows = dsetFData.Tables[0].Select("1=1", straGroup[0]);
            List<string> lstSearch = new List<string>();
            List<object> lstCondition = new List<object>();
            foreach (DataRow dr in rows)
            {
                lstCondition.Clear();
                if (lstSearch.IndexOf(dr[straGroup[0]].ToString()) == -1)
                {
                    lstSearch.Add(dr[straGroup[0]].ToString());
                    lstCondition.Add(dr[straGroup[0].ToString()]);
                    //System.Diagnostics.Debug.WriteLine("Search : " + straGroup[0] + "='" + dr[straGroup[0].ToString()].ToString() + "'");
                    AddGrouppingRows(lstCondition, straGroup[0] + "='" + dr[straGroup[0].ToString()].ToString().Replace("'", "''") + "'", straGroup.Count == 1 ? 1 : 2);

                }
            }
            //==========

            //// 각 Group 들에 대한 Key 구분 값을 준다.
            //tblTotalGroup.Columns.Add(new DataColumn("ID", typeof(int)));
            //for (int iRow = 0; iRow < tblTotalGroup.Rows.Count; iRow++)
            //{
            //    tblTotalGroup.Rows[iRow][tblTotalGroup.Columns.Count - 1] = iKey;
            //}
            return tblTotalGroup;
        }

        public DataTable GetGroupData1(DataSet dsetData, List<string> lstGroup, List<string> lstCompute)
        {
            dsetFData = dsetData;
            straGroup = lstGroup;
            straCompute = lstCompute;
            tblTotalGroup = new DataTable();

            for (int i = 0; i < straGroup.Count; i++)
            {
                tblTotalGroup.Columns.Add(new DataColumn(straGroup[i].ToString(), typeof(string)));
            }

            for (int i = 0; i < straCompute.Count; i++)
            {
                tblTotalGroup.Columns.Add(new DataColumn(straCompute[i].ToString().Split(':')[0].Length == 2 ? straCompute[i].ToString().Split(':')[0].ToString() : straCompute[i].ToString().Split(':')[2].ToString(), typeof(float)));

            }

            //==========
            DataRow[] rows = dsetFData.Tables[0].Select("1=1", straGroup[0]);
            List<string> lstSearch = new List<string>();
            List<object> lstCondition = new List<object>();
            foreach (DataRow dr in rows)
            {
                lstCondition.Clear();
                if (lstSearch.IndexOf(dr[straGroup[0]].ToString()) == -1)
                {
                    lstSearch.Add(dr[straGroup[0]].ToString());
                    lstCondition.Add(dr[straGroup[0].ToString()]);
                    AddGrouppingRows1(lstCondition, straGroup[0] + "='" + dr[straGroup[0].ToString()].ToString() + "'", straGroup.Count == 1 ? 1 : 2);

                }
            }
            //==========

            //// 각 Group 들에 대한 Key 구분 값을 준다.
            //tblTotalGroup.Columns.Add(new DataColumn("ID", typeof(int)));
            //for (int iRow = 0; iRow < tblTotalGroup.Rows.Count; iRow++)
            //{
            //    tblTotalGroup.Rows[iRow][tblTotalGroup.Columns.Count - 1] = iKey;
            //}
            return tblTotalGroup;
        }

        public DataTable GetPivotData(DataSet dsetData, List<string> lstGroup, List<string> lstCompute, string strSort)
        {

            dsetFData = dsetData;
            straGroup = lstGroup;
            straCompute = lstCompute;
            tblTotalGroup = new DataTable();
            strSortCondition = strSort;
            try
            {
                if (straGroup != null)
                {
                    for (int i = 0; i < straGroup.Count; i++)
                    {
                        tblTotalGroup.Columns.Add(new DataColumn(straGroup[i].ToString(), typeof(string)));
                    }
                }

                for (int i = 0; i < straCompute.Count; i++)
                {
                    if (straCompute[i].ToString().Split(':').Length > 2)
                    {
                        tblTotalGroup.Columns.Add(new DataColumn(straCompute[i].ToString().Split(':')[2].ToString(), typeof(float)));
                    }
                    else
                    {
                        tblTotalGroup.Columns.Add(new DataColumn(straCompute[i].ToString().Split(':')[0].ToString(), typeof(float)));
                    }

                }

                //==========
                DataRow[] rows = dsetFData.Tables[0].Select("1=1", strSortCondition);
                List<string> lstSearch = new List<string>();
                List<object> lstCondition = new List<object>();
                foreach (DataRow dr in rows)
                {
                    lstCondition.Clear();
                    if (lstSearch.IndexOf(dr[straGroup[0]].ToString()) == -1)
                    {
                        lstSearch.Add(dr[straGroup[0]].ToString());
                        lstCondition.Add(dr[straGroup[0].ToString()]);
                        AddPivotRows(lstCondition, straGroup[0] + "='" + dr[straGroup[0].ToString()].ToString().Replace("'", "''") + "'", straGroup.Count == 1 ? 1 : 2, lstCompute);

                    }
                }
            }
            catch (Exception)
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }


            return tblTotalGroup;
        }

        /// <summary>
        /// Groupping을 위한 StringList만들기
        /// </summary>
        /// <param name="lstCondition">String List용 Condition</param>
        /// <param name="strSearh">Select할 조건</param>
        /// <param name="nLevel">Level</param>
        private void AddGrouppingRows(List<object> lstCondition, string strSearh, int nLevel)
        {

            DataRow[] rows = dsetFData.Tables[0].Select(strSearh, straGroup[nLevel - 1]);
            if (straGroup.Count == nLevel)
            {
                List<string> straSearchTemp = new List<string>();
                foreach (DataRow dr in rows)
                {
                    if (straSearchTemp.IndexOf(dr[straGroup[nLevel - 1]].ToString()) == -1)
                    {
                        straSearchTemp.Add(dr[straGroup[nLevel - 1]].ToString());
                        List<object> lstObj = new List<object>();
                        //foreach (object obj in lstCondition)
                        //{
                        //    lstObj.Add(obj);
                        //}
                        //if (straGroup.Count != 1) lstObj.Add(dr[straGroup[nLevel - 1]].ToString());

                        foreach (string str in straGroup)
                        {
                            lstObj.Add(dr[str]);
                        }

                        string[] straTemp;
                        for (int i = 0; i < straCompute.Count; i++)
                        {
                            straTemp = straCompute[i].Split(':');
                            lstObj.Add(GetComputeData(strSearh + " AND " + straGroup[nLevel - 1] + "='" + dr[straGroup[nLevel - 1].ToString()].ToString() + "'", straTemp[0], straTemp[1]));
                        }

                        tblTotalGroup.Rows.Add(lstObj.ToArray());
                    }
                }

                lstCondition.RemoveAt(lstCondition.Count - 1);
                return;
            }
            else
            {
                string strRSearch = string.Empty;
                foreach (DataRow dr in rows)
                {
                    string strNowSearch = strSearh + " AND " + straGroup[nLevel - 1] + "='" + dr[straGroup[nLevel - 1]].ToString().Replace("'", "''") + "'";
                    if (!strRSearch.Equals(strNowSearch))
                    {
                        strRSearch = strNowSearch;
                        lstCondition.Add(dr[straGroup[nLevel - 1]].ToString());
                        string strTemp = string.Empty;
                        //System.Diagnostics.Debug.WriteLine("NowSearch 로 찾자:" + strNowSearch);
                        AddGrouppingRows(lstCondition, strNowSearch, nLevel + 1);
                    }
                }
            }
        }
        private void AddGrouppingRows1(List<object> lstCondition, string strSearh, int nLevel)
        {

            DataRow[] rows = dsetFData.Tables[0].Select(strSearh, straGroup[nLevel - 1]);
            if (straGroup.Count == nLevel)
            {
                List<string> straSearchTemp = new List<string>();
                foreach (DataRow dr in rows)
                {
                    if (straSearchTemp.IndexOf(dr[straGroup[nLevel - 1]].ToString()) == -1)
                    {
                        straSearchTemp.Add(dr[straGroup[nLevel - 1]].ToString());
                        List<object> lstObj = new List<object>();
                        foreach (object obj in lstCondition)
                        {
                            lstObj.Add(obj);
                        }
                        if (straGroup.Count != 1) lstObj.Add(dr[straGroup[nLevel - 1]].ToString());
                        string[] straTemp;
                        string strCompute = string.Empty;
                        for (int i = 0; i < straCompute.Count; i++)
                        {
                            straTemp = straCompute[i].Split(':');
                            strCompute = straTemp.Length == 4 ? string.Format("{0} AND {1}='{2}' AND {3}"
                                                                                  , strSearh
                                                                                  , straGroup[nLevel - 1]
                                                                                  , dr[straGroup[nLevel - 1].ToString()].ToString()
                                                                                  , straTemp[3].IndexOf('{') > -1 ? GetFormatStringData(dr, straTemp[3]) : straTemp[3]) :
                                                                  string.Format("{0} AND {1}='{2}'"
                                                                                  , strSearh
                                                                                  , straGroup[nLevel - 1]
                                                                                  , dr[straGroup[nLevel - 1].ToString()].ToString());
                            lstObj.Add(GetComputeData(strCompute, straTemp[0], straTemp[1]));
                        }

                        tblTotalGroup.Rows.Add(lstObj.ToArray());
                    }
                }

                lstCondition.RemoveAt(lstCondition.Count - 1);
                return;
            }
            else
            {
                string strRSearch = string.Empty;
                foreach (DataRow dr in rows)
                {
                    string strNowSearch = strSearh + " AND " + straGroup[nLevel - 1] + "='" + dr[straGroup[nLevel - 1]].ToString() + "'";
                    if (!strRSearch.Equals(strNowSearch))
                    {
                        strRSearch = strNowSearch;
                        lstCondition.Add(dr[straGroup[nLevel - 1]].ToString());
                        string strTemp = string.Empty;
                        //System.Diagnostics.Debug.WriteLine("NowSearch 로 찾자:" + strNowSearch);
                        AddGrouppingRows1(lstCondition, strNowSearch, nLevel + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Compute할때 수식사용한것 처리
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strFomater"></param>
        /// <returns></returns>
        private string GetFormatStringData(DataRow dr, string strFomater)
        {
            //{LOT_NO,CASE}  = > LOT_NO = '111' AND CASE = '2'
            string strReturn = strFomater.Replace("{", "").Replace("}", "");
            string[] straValue = strReturn.Split(',');
            strReturn = string.Empty;
            foreach (string str in straValue)
            {
                strReturn = strReturn == string.Empty ? string.Format("{0} = '{1}'", str, dr[strReturn].ToString()) : string.Format(" AND {0} = '{1}'", str, dr[strReturn].ToString());
            }

            return strReturn;
        }

        private void AddPivotRows(List<object> lstCondition, string strSearh, int nLevel, List<string> lstCompute)
        {

            DataRow[] rows = dsetFData.Tables[0].Select(strSearh, strSortCondition);
            if (straGroup.Count == nLevel)
            {
                List<string> straSearchTemp = new List<string>();
                string strValue = string.Empty;
                string strCompute = string.Empty;
                foreach (DataRow dr in rows)
                {
                    if (straSearchTemp.IndexOf(dr[straGroup[nLevel - 1]].ToString()) == -1)
                    {
                        straSearchTemp.Add(dr[straGroup[nLevel - 1]].ToString());
                        List<object> lstObj = new List<object>();
                        //foreach (object obj in lstCondition)
                        //{
                        //    lstObj.Add(obj);
                        //}
                        //if (straGroup.Count != 1) lstObj.Add(dr[straGroup[nLevel - 1]].ToString());

                        foreach (string str in straGroup)
                        {
                            lstObj.Add(dr[str]);
                        }

                        string[] straTemp;
                        for (int i = 0; i < straCompute.Count; i++)
                        {
                            straTemp = straCompute[i].Split(':');
                            strCompute = string.Format("{0} AND {1}='{2}' AND {3}",
                                                                     strSearh
                                                                     , straGroup[nLevel - 1]
                                                                     , dr[straGroup[nLevel - 1].ToString()].ToString()
                                                                     , straTemp[straTemp.Length - 1]);
                            strValue = GetComputeData(strCompute, straTemp[0], straTemp[1]).ToString();
                            lstObj.Add(strValue.Length == 0 ? "0" : strValue);
                        }
                        try
                        {
                            tblTotalGroup.Rows.Add(lstObj.ToArray());
                        }
                        catch (Exception)
                        {
                            //System.Diagnostics.Debug.WriteLine("AddPivotRows - Error : " + ex.Message.ToString());
                        }

                    }
                }

                lstCondition.RemoveAt(lstCondition.Count - 1);
                return;
            }
            else
            {
                string strRSearch = string.Empty;
                foreach (DataRow dr in rows)
                {
                    string strNowSearch = strSearh + " AND " + straGroup[nLevel - 1] + "='" + dr[straGroup[nLevel - 1]].ToString().Replace("'", "''") + "'";
                    if (!strRSearch.Equals(strNowSearch))
                    {
                        strRSearch = strNowSearch;
                        lstCondition.Add(dr[straGroup[nLevel - 1]].ToString());
                        string strTemp = string.Empty;
                        //System.Diagnostics.Debug.WriteLine("NowSearch 로 찾자:" + strNowSearch);
                        AddPivotRows(lstCondition, strNowSearch, nLevel + 1, lstCompute);
                    }
                }
            }
        }

        /// <summary>
        /// Compute된 값을 Return한다
        /// </summary>
        /// <param name="strSearch">Search조건</param>
        /// <param name="strValue">ColumnName</param>
        /// <param name="strType">SUM, AVG, COUNT 등등</param>
        /// <returns>object</returns>
        public object GetComputeData(string strSearch, string strValue, string strType)
        {
            object objReturn = 0;
            try
            {
                objReturn = dsetFData.Tables[0].Compute(strType + "([" + strValue + "])", strSearch);
            }
            catch (Exception)
            {
                //System.Diagnostics.Debug.WriteLine("GetComputeData - Error : " + ex.Message);
            }

            return objReturn == null ? 0 : objReturn;
        }

        public object GetComputeData(DataTable tblData, string strSearch, string strValue, string strType)
        {
            object objReturn = 0;
            try
            {
                objReturn = tblData.Compute(strType + "([" + strValue + "])", strSearch);
            }
            catch (Exception)
            {
                //System.Diagnostics.Debug.WriteLine("GetComputeData - Error : " + ex.Message);
            }


            return objReturn == null ? 0 : objReturn;
        }
        #endregion


        #region [Get Column DataType]
        /// <summary>
        /// CellType지정
        /// </summary>
        /// <param name="type"></param>
        /// <returns>ICellType</returns>
        public ICellType SetCellType(string type)
        {
            ICellType _celltype = null;

            switch (type.ToUpper())
            {
                case "CHECK":
                    FarPoint.Win.Spread.CellType.CheckBoxCellType checkboxcelltype = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

                    _celltype = checkboxcelltype;
                    break;

                case "TEXT":
                    FarPoint.Win.Spread.CellType.TextCellType textcelltype = new FarPoint.Win.Spread.CellType.TextCellType();

                    _celltype = textcelltype;
                    break;

                case "NUMBER":
                    FarPoint.Win.Spread.CellType.NumberCellType numbercelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numbercelltype.DecimalPlaces = 0;
                    numbercelltype.Separator = ",";
                    numbercelltype.MaximumValue = 999999999999;
                    numbercelltype.ShowSeparator = true;

                    _celltype = numbercelltype;
                    break;

                case "DOUBLE":
                    FarPoint.Win.Spread.CellType.NumberCellType doublecelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                    doublecelltype.DecimalPlaces = 2;
                    doublecelltype.Separator = ",";
                    doublecelltype.MaximumValue = 999999999999.99;
                    doublecelltype.ShowSeparator = true;

                    _celltype = doublecelltype;
                    break;

                case "DATEFULL":
                    FarPoint.Win.Spread.CellType.DateTimeCellType datefullcelltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                    datefullcelltype.DateSeparator = "/";
                    datefullcelltype.DateTimeFormat = DateTimeFormat.UserDefined;
                    datefullcelltype.UserDefinedFormat = "yyyy/MM/dd hh:mm:dd";
                    datefullcelltype.SpinButton = true;

                    _celltype = datefullcelltype;
                    break;

                case "DATEPART":
                    FarPoint.Win.Spread.CellType.DateTimeCellType datepartcelltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                    datepartcelltype.DateSeparator = "/";
                    datepartcelltype.DateTimeFormat = DateTimeFormat.UserDefined;
                    datepartcelltype.UserDefinedFormat = "yyyy/MM/dd";
                    datepartcelltype.SpinButton = true;

                    _celltype = datepartcelltype;
                    break;

                case "COMBOBOX":
                    FarPoint.Win.Spread.CellType.ComboBoxCellType comboboxcelltype = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    comboboxcelltype.Editable = false;

                    _celltype = comboboxcelltype;
                    break;

                case "HYPERLINK":
                    FarPoint.Win.Spread.CellType.HyperLinkCellType hyperlinkcelltype = new FarPoint.Win.Spread.CellType.HyperLinkCellType();

                    _celltype = hyperlinkcelltype;
                    break;

                default:
                    FarPoint.Win.Spread.CellType.TextCellType defaulttype = new FarPoint.Win.Spread.CellType.TextCellType();

                    _celltype = defaulttype;
                    break;
            }

            return _celltype;
        }
        #endregion


        #endregion

    }
}
