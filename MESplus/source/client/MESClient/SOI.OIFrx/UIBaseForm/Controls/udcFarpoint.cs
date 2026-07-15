//-----------------------------------------------------------------------------
//
//   System      : MES Report
//   File Name   : 
//   Description : Client Common function Module 
//
//   MES Version : 5.x.x.x
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2014-12-01 : Created by Yeonggon Son
//
//
//   Copyright(C) 1998-2014 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using System.Windows.Forms;
using System.Drawing;
using Miracom.CliFrx;

namespace SOI.OIFrx
{
    public partial class udcFarpoint : FarPoint.Win.Spread.FpSpread
    {
        #region "Enum Deifiniton"
        /// <summary>
        /// Column 속성을 지정할 항목
        /// Column Header : LABEL, WIDTH
        /// Column : FIELD, TYPE, HALIGN, VALIGN, MERGE, HIDE, LOCK
        /// </summary>
        public enum ColumnProperty
        {
            LABEL,
            WIDTH,
            FIELD,
            TYPE,
            HALIGN,
            VALIGN,
            MERGE,
            HIDE,
            LOCK
        }

        //스프레드 칼럽 헤드 추가시 사용
        public enum COL_SPD : int
        {
            COL_LABEL = 0,
            COL_WIDTH,
            COL_KEY,
            COL_CELTYPE,
            COL_CELHALIGN,
            COL_CELVALIGN,
            COL_CELMERGE,
            COL_HIDE,
            COL_LOCK
        }

        public enum SpreadCellHAlign
        {
            Left,
            Center,
            Right
        }

        public enum SpreadCellVAlign
        {
            Top,
            Center,
            Bottom
        }

        public enum SpreadCellMerge
        {
            None,
            Always,
            Restricted
        }

        public enum SpreadPart
        {
            Row,
            Column,
            RowHeader,
            ColumnHeader,
            Sheet,
            Spread
        }

        //스프레드 셀 유형
        public enum SpreadCellType
        {
            CheckBoxCellType,
            TextCellType,
            NumberCellType,
            LongNumberCellType,
            DateTimeCellType,
            LongDateTimeCellType,
            ComboBoxCellType,
            HyperLinkCellType,
            ButtonCellType
        }
        #endregion

        #region "Variable Definition"
        //스프레드 칼럼 정의 변수
        private string sLabel = string.Empty;
        private int iWidth = 0;
        private string sKey = string.Empty;
        private Spread.SpreadCellType CelType = Spread.SpreadCellType.TextCellType;
        private Spread.SpreadCellHAlign CelHalign = Spread.SpreadCellHAlign.Center;
        private Spread.SpreadCellVAlign CelValign = Spread.SpreadCellVAlign.Center;
        private Spread.SpreadCellMerge CelMerge = Spread.SpreadCellMerge.None;
        private bool bHide = false;
        private bool bLock = true;
        FarPoint.Win.Spread.CellType.TextCellType type_text = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.ButtonCellType type_button_plus = new FarPoint.Win.Spread.CellType.ButtonCellType();
        FarPoint.Win.Spread.CellType.ButtonCellType type_button_minus = new FarPoint.Win.Spread.CellType.ButtonCellType();
        FarPoint.Win.Spread.CellType.ButtonCellType type_button = new ButtonCellType();
        FarPoint.Win.Spread.CellType.ComboBoxCellType type_combo = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        FarPoint.Win.Spread.CellType.MaskCellType type_mask = new FarPoint.Win.Spread.CellType.MaskCellType();
        FarPoint.Win.Spread.CellType.NumberCellType type_number = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.CheckBoxCellType type_check = new CheckBoxCellType();
        DateTimePickerCellType type_date = new DateTimePickerCellType();
        DataTable dtBlank = new DataTable();
        DataTable dtData = new DataTable();

        private ControlCollection control;

        public ControlCollection Control
        {
            get { return control; }
            set { control = Control; }
        }

        public FarPoint.Win.Spread.CellType.TextCellType GetTypeText() { return type_text; }
        public FarPoint.Win.Spread.CellType.NumberCellType GetTypeNumber() { return type_number; }
        public FarPoint.Win.Spread.CellType.ComboBoxCellType GetTypeCombo() { return type_combo; }
        public FarPoint.Win.Spread.CellType.CheckBoxCellType GetTypeCheck() { return type_check; }
        public DateTimePickerCellType GetTypeDate() { return type_date; }
        public FarPoint.Win.Spread.CellType.ButtonCellType GetTypeButton() { return type_button; }

        #endregion

        /// <summary>
        /// Spread 초기화
        /// </summary>
        /// <param name="bRowHeader">Row Header를 보여줄지 여부</param>
        /// <param name="bSort">Column Sort 여부</param>
        /// <param name="operMode">Operation Mode 설정</param>
        public void ApplyTema(bool bRowHeader, bool bSort, FarPoint.Win.Spread.OperationMode operMode)
        {
            FarPoint.Win.Spread.SheetSkin spSkin;

            try
            {
                FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(this);
                spSkin = new FarPoint.Win.Spread.SheetSkin("InitSkin",
                                           System.Drawing.Color.AliceBlue,
                                           System.Drawing.Color.Empty,
                                           System.Drawing.Color.Empty,
                                           System.Drawing.Color.Gray,
                                           FarPoint.Win.Spread.GridLines.Both,
                    //System.Drawing.Color.FromArgb(42, 61, 112),
                                           System.Drawing.Color.WhiteSmoke,
                                           System.Drawing.Color.Black,
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
                this.BackColor = System.Drawing.Color.Silver;  //System.Drawing.SystemColors.Control; // System.Drawing.Color.Silver;
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

                    this.Sheets[i].ColumnHeader.DefaultStyle.Font = new Font("맑은 고딕", 8.15F, System.Drawing.FontStyle.Regular);  // new Font("Tahoma", 8F, FontStyle.Bold);

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
        /// 스프레드 칼럼 정의 및 데이터 표시
        /// </summary>
        /// <param name="fpSpd"></param>
        /// <param name="tblData"></param>
        /// <param name="oCol"></param>
        /// <returns></returns>
        public bool MakeSpreadColHeader(FarPoint.Win.Spread.FpSpread fpSpd, DataTable tblData, object[,] oCol)
        {
            DataTable dtColumn = new DataTable();
            int iColumnHeaderRow = 1;

            try
            {
                fpSpd.Sheets[0].DataSource = tblData;
                fpSpd.Sheets[0].RowCount = 0;
                fpSpd.Sheets[0].ColumnHeader.Columns.Count = -1;
                fpSpd.Sheets[0].ColumnHeader.Rows[0].Height = 40;
                dtData = new DataTable();

                dtColumn.TableName = "SetColumnProperty";
                dtColumn.Columns.Add(ColumnProperty.LABEL.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.WIDTH.ToString(), typeof(int));
                dtColumn.Columns.Add(ColumnProperty.FIELD.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.TYPE.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.HALIGN.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.VALIGN.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.MERGE.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.HIDE.ToString(), typeof(bool));
                dtColumn.Columns.Add(ColumnProperty.LOCK.ToString(), typeof(bool));

                if (oCol != null)
                {
                    if (oCol.GetLongLength(0) > 0)
                    {
                        for (int iCol = 0; iCol < oCol.GetLongLength(0); iCol++)
                        {
                            sLabel = oCol[iCol, (int)COL_SPD.COL_LABEL].ToString();
                            iWidth = Convert.ToInt32(oCol[iCol, (int)COL_SPD.COL_WIDTH].ToString());
                            sKey = oCol[iCol, (int)COL_SPD.COL_KEY].ToString();
                            CelType = (Spread.SpreadCellType)oCol[iCol, (int)COL_SPD.COL_CELTYPE];
                            CelHalign = (Spread.SpreadCellHAlign)oCol[iCol, (int)COL_SPD.COL_CELHALIGN];
                            CelValign = (Spread.SpreadCellVAlign)oCol[iCol, (int)COL_SPD.COL_CELVALIGN];
                            CelMerge = (Spread.SpreadCellMerge)oCol[iCol, (int)COL_SPD.COL_CELMERGE];
                            bHide = (bool)oCol[iCol, (int)COL_SPD.COL_HIDE];
                            bLock = (bool)oCol[iCol, (int)COL_SPD.COL_LOCK];
                            dtColumn.Rows.Add(sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock);

                            dtData.Columns.Add(sKey);
                        }
                    }
                }

                fpSpd.Sheets[0].ColumnHeader.Rows.Count = iColumnHeaderRow;
                fpSpd.Sheets[0].ColumnHeader.Columns.Count = dtColumn.Rows.Count;
                fpSpd.Sheets[0].Protect = true;

                //ColumnHeader의 Row를 iHeaderRowCnt만큼 생성한다.
                for (int hRowCnt = 0; hRowCnt < iColumnHeaderRow; hRowCnt++)
                {
                    for (int iCnt = 0; iCnt < dtColumn.Rows.Count; iCnt++)
                    {
                        for (int jCnt = 0; jCnt < dtColumn.Columns.Count; jCnt++)
                        {
                            #region //LABEL
                            //Column Header 에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LABEL.ToString())
                            {

                                if (dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()];
                                }
                                else
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = "";
                                }

                            }
                            #endregion

                            #region //WIDTH
                            //Column Header 에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.WIDTH.ToString())
                            {
                                int idefwidth = 60;
                                int iwidth = 0;

                                if (Int32.TryParse(dtColumn.Rows[iCnt][ColumnProperty.WIDTH.ToString()].ToString(), out iwidth))
                                {
                                    if (iwidth < 1) { iwidth = idefwidth; }
                                    fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = iwidth;
                                }
                                else
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = idefwidth;
                                }
                            }
                            #endregion

                            #region //FIELD
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.FIELD.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].DataField = dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString();
                                }
                            }
                            #endregion

                            #region //TYPE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.TYPE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(SpreadCellType.TextCellType.ToString());
                                }
                            }
                            #endregion

                            #region //HALIGN
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HALIGN.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = TakeCellHAlign(dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = CellHorizontalAlignment.Left;
                                }
                            }
                            #endregion

                            #region //VALIGN
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.VALIGN.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = TakeCellVAlign(dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = CellVerticalAlignment.Center;
                                }
                            }
                            #endregion

                            #region //MERGE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.MERGE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].MergePolicy = TakeMergePolicy(dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
                                }
                            }
                            #endregion

                            #region //HIDE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HIDE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Visible = !((bool)dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()]);
                                    //HIDE : Visible 이므로 속성값의 반대로 세팅
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Visible = true;
                                }
                            }
                            #endregion

                            #region //LOCK
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LOCK.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Locked = (bool)dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()];
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Locked = false;
                                }
                            }
                            #endregion
                        }
                    }
                }

                fpSpd.Sheets[0].DataSource = dtData;

                fpSpd.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
                fpSpd.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
                fpSpd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spdData_MouseMove);
                fpSpd.ScrollTipFetch += new ScrollTipFetchEventHandler(this.spdData_ScrollTipFetch);
                fpSpd.TopChange += new FarPoint.Win.Spread.TopChangeEventHandler(this.spdData_TopChange);
                fpSpd.LeftChange += new FarPoint.Win.Spread.LeftChangeEventHandler(this.spdData_LeftChange);

                MPCF.ConvertMessage(this.Controls);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 스프레드 칼럼 정의 및 데이터 표시
        /// </summary>
        /// <param name="fpSpd"></param>
        /// <param name="tblData"></param>
        /// <param name="oCol"></param>
        /// <returns></returns>
        public bool MakeSpreadColHeader(FarPoint.Win.Spread.FpSpread fpSpd, DataTable tblData, object[,] oCol, int i_row)
        {
            DataTable dtColumn = new DataTable();
            int iColumnHeaderRow = i_row;

            try
            {
                fpSpd.Sheets[0].DataSource = tblData;
                fpSpd.Sheets[0].RowCount = 0;
                fpSpd.Sheets[0].ColumnHeader.Columns.Count = -1;
                fpSpd.Sheets[0].ColumnHeader.Rows[0].Height = 40;
                dtData = new DataTable();

                dtColumn.TableName = "SetColumnProperty";
                dtColumn.Columns.Add(ColumnProperty.LABEL.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.WIDTH.ToString(), typeof(int));
                dtColumn.Columns.Add(ColumnProperty.FIELD.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.TYPE.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.HALIGN.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.VALIGN.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.MERGE.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.HIDE.ToString(), typeof(bool));
                dtColumn.Columns.Add(ColumnProperty.LOCK.ToString(), typeof(bool));

                if (oCol != null)
                {
                    if (oCol.GetLongLength(0) > 0)
                    {
                        for (int iCol = 0; iCol < oCol.GetLongLength(0); iCol++)
                        {
                            sLabel = oCol[iCol, (int)COL_SPD.COL_LABEL].ToString();
                            iWidth = Convert.ToInt32(oCol[iCol, (int)COL_SPD.COL_WIDTH].ToString());
                            sKey = oCol[iCol, (int)COL_SPD.COL_KEY].ToString();
                            CelType = (Spread.SpreadCellType)oCol[iCol, (int)COL_SPD.COL_CELTYPE];
                            CelHalign = (Spread.SpreadCellHAlign)oCol[iCol, (int)COL_SPD.COL_CELHALIGN];
                            CelValign = (Spread.SpreadCellVAlign)oCol[iCol, (int)COL_SPD.COL_CELVALIGN];
                            CelMerge = (Spread.SpreadCellMerge)oCol[iCol, (int)COL_SPD.COL_CELMERGE];
                            bHide = (bool)oCol[iCol, (int)COL_SPD.COL_HIDE];
                            bLock = (bool)oCol[iCol, (int)COL_SPD.COL_LOCK];
                            dtColumn.Rows.Add(sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock);

                            dtData.Columns.Add(sKey);
                        }
                    }
                }

                fpSpd.Sheets[0].ColumnHeader.Rows.Count = iColumnHeaderRow;
                fpSpd.Sheets[0].ColumnHeader.Columns.Count = dtColumn.Rows.Count;
                fpSpd.Sheets[0].Protect = true;

                //ColumnHeader의 Row를 iHeaderRowCnt만큼 생성한다.
                for (int hRowCnt = 0; hRowCnt < iColumnHeaderRow; hRowCnt++)
                {
                    for (int iCnt = 0; iCnt < dtColumn.Rows.Count; iCnt++)
                    {
                        for (int jCnt = 0; jCnt < dtColumn.Columns.Count; jCnt++)
                        {
                            #region //LABEL
                            //Column Header 에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LABEL.ToString())
                            {

                                if (dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()];
                                }
                                else
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = "";
                                }

                            }
                            #endregion

                            #region //WIDTH
                            //Column Header 에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.WIDTH.ToString())
                            {
                                int idefwidth = 60;
                                int iwidth = 0;

                                if (Int32.TryParse(dtColumn.Rows[iCnt][ColumnProperty.WIDTH.ToString()].ToString(), out iwidth))
                                {
                                    if (iwidth < 1) { iwidth = idefwidth; }
                                    fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = iwidth;
                                }
                                else
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = idefwidth;
                                }
                            }
                            #endregion

                            #region //FIELD
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.FIELD.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].DataField = dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString();
                                }
                            }
                            #endregion

                            #region //TYPE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.TYPE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(SpreadCellType.TextCellType.ToString());
                                }
                            }
                            #endregion

                            #region //HALIGN
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HALIGN.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = TakeCellHAlign(dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = CellHorizontalAlignment.Left;
                                }
                            }
                            #endregion

                            #region //VALIGN
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.VALIGN.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = TakeCellVAlign(dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = CellVerticalAlignment.Center;
                                }
                            }
                            #endregion

                            #region //MERGE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.MERGE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].MergePolicy = TakeMergePolicy(dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
                                }
                            }
                            #endregion

                            #region //HIDE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HIDE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Visible = !((bool)dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()]);
                                    //HIDE : Visible 이므로 속성값의 반대로 세팅
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Visible = true;
                                }
                            }
                            #endregion

                            #region //LOCK
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LOCK.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Locked = (bool)dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()];
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Locked = false;
                                }
                            }
                            #endregion
                        }
                    }
                }

                fpSpd.Sheets[0].DataSource = dtData;

                fpSpd.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
                fpSpd.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
                fpSpd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spdData_MouseMove);
                fpSpd.ScrollTipFetch += new ScrollTipFetchEventHandler(this.spdData_ScrollTipFetch);
                fpSpd.TopChange += new FarPoint.Win.Spread.TopChangeEventHandler(this.spdData_TopChange);
                fpSpd.LeftChange += new FarPoint.Win.Spread.LeftChangeEventHandler(this.spdData_LeftChange);

                MPCF.ConvertMessage(this.Controls);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 스프레드 칼럼 정의 및 데이터 표시
        /// </summary>
        /// <param name="fpSpd"></param>
        /// <param name="tblData"></param>
        /// <param name="oCol"></param>
        /// <returns></returns>
        public bool MakeSpreadColHeader(FarPoint.Win.Spread.FpSpread fpSpd, DataTable tblData, List<object[]> oCol, int i_row)
        {
            DataTable dtColumn = new DataTable();
            int iColumnHeaderRow = i_row;

            try
            {
                fpSpd.Sheets[0].DataSource = tblData;
                fpSpd.Sheets[0].RowCount = 0;
                fpSpd.Sheets[0].ColumnHeader.Columns.Count = -1;
                fpSpd.Sheets[0].ColumnHeader.Rows[0].Height = 40;
                dtData = new DataTable();

                dtColumn.TableName = "SetColumnProperty";
                dtColumn.Columns.Add(ColumnProperty.LABEL.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.WIDTH.ToString(), typeof(int));
                dtColumn.Columns.Add(ColumnProperty.FIELD.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.TYPE.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.HALIGN.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.VALIGN.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.MERGE.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.HIDE.ToString(), typeof(bool));
                dtColumn.Columns.Add(ColumnProperty.LOCK.ToString(), typeof(bool));

                if (oCol != null)
                {
                    if (oCol.Count > 0)
                    {
                        for (int iCol = 0; iCol < oCol.Count; iCol++)
                        {
                            
                            sLabel = MPCF.Trim(oCol[iCol].GetValue((int)COL_SPD.COL_LABEL));
                            iWidth = Convert.ToInt32(MPCF.Trim(oCol[iCol].GetValue((int)COL_SPD.COL_WIDTH)));
                            sKey = MPCF.Trim(oCol[iCol].GetValue((int)COL_SPD.COL_KEY));
                            CelType = (Spread.SpreadCellType) oCol[iCol].GetValue((int)COL_SPD.COL_CELTYPE);
                            CelHalign = (Spread.SpreadCellHAlign)oCol[iCol].GetValue((int)COL_SPD.COL_CELHALIGN);
                            CelValign = (Spread.SpreadCellVAlign)oCol[iCol].GetValue((int)COL_SPD.COL_CELVALIGN);
                            CelMerge = (Spread.SpreadCellMerge)oCol[iCol].GetValue((int)COL_SPD.COL_CELMERGE);
                            bHide = (bool)oCol[iCol].GetValue((int)COL_SPD.COL_HIDE);
                            bLock = (bool)oCol[iCol].GetValue((int)COL_SPD.COL_LOCK);
                            dtColumn.Rows.Add(sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock);

                            dtData.Columns.Add(sKey);
                        }
                    }
                }

                fpSpd.Sheets[0].ColumnHeader.Rows.Count = iColumnHeaderRow;
                fpSpd.Sheets[0].ColumnHeader.Columns.Count = dtColumn.Rows.Count;
                fpSpd.Sheets[0].Protect = true;

                //ColumnHeader의 Row를 iHeaderRowCnt만큼 생성한다.
                for (int hRowCnt = 0; hRowCnt < iColumnHeaderRow; hRowCnt++)
                {
                    for (int iCnt = 0; iCnt < dtColumn.Rows.Count; iCnt++)
                    {
                        for (int jCnt = 0; jCnt < dtColumn.Columns.Count; jCnt++)
                        {
                            #region //LABEL
                            //Column Header 에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LABEL.ToString())
                            {

                                if (dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()];
                                }
                                else
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = "";
                                }

                            }
                            #endregion

                            #region //WIDTH
                            //Column Header 에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.WIDTH.ToString())
                            {
                                int idefwidth = 60;
                                int iwidth = 0;

                                if (Int32.TryParse(dtColumn.Rows[iCnt][ColumnProperty.WIDTH.ToString()].ToString(), out iwidth))
                                {
                                    if (iwidth < 1) { iwidth = idefwidth; }
                                    fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = iwidth;
                                }
                                else
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = idefwidth;
                                }
                            }
                            #endregion

                            #region //FIELD
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.FIELD.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].DataField = dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString();
                                }
                            }
                            #endregion

                            #region //TYPE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.TYPE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(SpreadCellType.TextCellType.ToString());
                                }
                            }
                            #endregion

                            #region //HALIGN
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HALIGN.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = TakeCellHAlign(dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = CellHorizontalAlignment.Left;
                                }
                            }
                            #endregion

                            #region //VALIGN
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.VALIGN.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = TakeCellVAlign(dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = CellVerticalAlignment.Center;
                                }
                            }
                            #endregion

                            #region //MERGE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.MERGE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].MergePolicy = TakeMergePolicy(dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
                                }
                            }
                            #endregion

                            #region //HIDE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HIDE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Visible = !((bool)dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()]);
                                    //HIDE : Visible 이므로 속성값의 반대로 세팅
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Visible = true;
                                }
                            }
                            #endregion

                            #region //LOCK
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LOCK.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Locked = (bool)dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()];
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Locked = false;
                                }
                            }
                            #endregion
                        }
                    }
                }

                fpSpd.Sheets[0].DataSource = dtData;

                fpSpd.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
                fpSpd.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
                fpSpd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spdData_MouseMove);
                fpSpd.ScrollTipFetch += new ScrollTipFetchEventHandler(this.spdData_ScrollTipFetch);

                MPCF.ConvertMessage(this.Controls);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void spdData_MouseMove(object sender, MouseEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            FarPoint.Win.Spread.Model.CellRange cRange = fpSpd.GetCellFromPixel(0, 0, e.X, e.Y);

            if (cRange.Row > -1)
            {
                if (cRange.Column > -1)
                {
                    if (fpSpd.ActiveSheet.Columns[cRange.Column].Locked ||
                        fpSpd.ActiveSheet.Cells[cRange.Row, cRange.Column].Locked)
                    {
                        fpSpd.EditModePermanent = false;
                    }
                    else
                    {
                        fpSpd.EditModePermanent = true;
                        fpSpd.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Hand);
                    }
                }
            }

        }

        private void spdData_ScrollTipFetch(object sender, FarPoint.Win.Spread.ScrollTipFetchEventArgs e)
        {
            ((udcFarpoint)sender).ActiveSheet.SetActiveCell(e.Row, e.Column);
        }

        private void spdData_TopChange(object sender, FarPoint.Win.Spread.TopChangeEventArgs e)
        {
            int iActCol = ((udcFarpoint)sender).ActiveSheet.ActiveColumnIndex;
            ((udcFarpoint)sender).ActiveSheet.SetActiveCell(e.NewTop, iActCol);
        }


        private void spdData_LeftChange(object sender, FarPoint.Win.Spread.LeftChangeEventArgs e)
        {
            int iActRow = ((udcFarpoint)sender).ActiveSheet.ActiveRowIndex;
            ((udcFarpoint)sender).ActiveSheet.SetActiveCell(iActRow, e.NewLeft);
        }


        #region "Spread Column Setting Function"
        public static ICellType TakeCellType(string type)
        {
            ICellType _celltype = null;

            if (type.Trim().ToUpper() == SpreadCellType.CheckBoxCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.CheckBoxCellType checkboxcelltype = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

                _celltype = checkboxcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.TextCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.TextCellType defaulttype = new FarPoint.Win.Spread.CellType.TextCellType();

                _celltype = defaulttype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.NumberCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.NumberCellType numbercelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                numbercelltype.DecimalPlaces = 0;
                numbercelltype.Separator = ",";
                numbercelltype.MaximumValue = 999999999999;
                numbercelltype.ShowSeparator = true;
                numbercelltype.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.Yes;

                _celltype = numbercelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.LongNumberCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.NumberCellType doublecelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                doublecelltype.DecimalPlaces = 2;
                doublecelltype.Separator = ",";
                doublecelltype.MaximumValue = 999999999999.99;
                doublecelltype.ShowSeparator = true;

                _celltype = doublecelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.DateTimeCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.DateTimeCellType datepartcelltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                datepartcelltype.DateSeparator = "/";
                datepartcelltype.DateTimeFormat = DateTimeFormat.UserDefined;
                datepartcelltype.UserDefinedFormat = "yyyy/MM/dd";
                datepartcelltype.SpinButton = false;

                _celltype = datepartcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.LongDateTimeCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.DateTimeCellType datefullcelltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                datefullcelltype.DateSeparator = "/";
                datefullcelltype.DateTimeFormat = DateTimeFormat.UserDefined;
                datefullcelltype.UserDefinedFormat = "yyyy/MM/dd HH:mm:ss";
                datefullcelltype.SpinButton = false;

                _celltype = datefullcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.ComboBoxCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.ComboBoxCellType comboboxcelltype = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                comboboxcelltype.Editable = false;

                _celltype = comboboxcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.HyperLinkCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.HyperLinkCellType hyperlinkcelltype = new FarPoint.Win.Spread.CellType.HyperLinkCellType();

                _celltype = hyperlinkcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.ButtonCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();

                _celltype = buttonCellType;
                buttonCellType.Text = "...";
            }
            else
            {
                FarPoint.Win.Spread.CellType.TextCellType defaulttype = new FarPoint.Win.Spread.CellType.TextCellType();

                _celltype = defaulttype;
            }

            return _celltype;
        }

        public static CellHorizontalAlignment TakeCellHAlign(string type)
        {
            CellHorizontalAlignment _cellHAlign = new CellHorizontalAlignment();

            if (type.Trim().ToUpper() == SpreadCellHAlign.Left.ToString().ToUpper())
            {
                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            }
            else if (type.Trim().ToUpper() == SpreadCellHAlign.Center.ToString().ToUpper())
            {
                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            }
            else if (type.Trim().ToUpper() == SpreadCellHAlign.Right.ToString().ToUpper())
            {
                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            }
            else
            {
                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            }

            return _cellHAlign;
        }

        public static CellVerticalAlignment TakeCellVAlign(string type)
        {
            CellVerticalAlignment _cellVAlign = new CellVerticalAlignment();

            if (type.Trim().ToUpper() == SpreadCellVAlign.Top.ToString().ToUpper())
            {
                _cellVAlign = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            }
            else if (type.Trim().ToUpper() == SpreadCellVAlign.Center.ToString().ToUpper())
            {
                _cellVAlign = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            else if (type.Trim().ToUpper() == SpreadCellVAlign.Bottom.ToString().ToUpper())
            {
                _cellVAlign = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            }
            else
            {
                _cellVAlign = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            return _cellVAlign;
        }

        public static FarPoint.Win.Spread.Model.MergePolicy TakeMergePolicy(string type)
        {
            FarPoint.Win.Spread.Model.MergePolicy _cellMergePolicy = new FarPoint.Win.Spread.Model.MergePolicy();

            if (type.Trim().ToUpper() == SpreadCellMerge.None.ToString().ToUpper())
            {
                _cellMergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            }
            else if (type.Trim().ToUpper() == SpreadCellMerge.Always.ToString().ToUpper())
            {
                _cellMergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            }
            else if (type.Trim().ToUpper() == SpreadCellMerge.Restricted.ToString().ToUpper())
            {
                _cellMergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            }
            else
            {
                _cellMergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            }

            return _cellMergePolicy;
        }

        public static void SpreadSpan(FarPoint.Win.Spread.FpSpread fpSpd, SpreadPart part, int row, int column, int rowCount, int columnCount, string Text)
        {
            string Caption = string.Empty;

            //실행조건
            if (fpSpd == null) { return; }
            if (part == SpreadPart.Spread || part == SpreadPart.Sheet) { return; }

            try
            {
                if (Text != "" || Text == null) { Caption = Text; }
                else
                {
                    if (part == SpreadPart.ColumnHeader || part == SpreadPart.RowHeader)
                    {
                        if (part == SpreadPart.ColumnHeader) { Caption = fpSpd.Sheets[0].ColumnHeader.Cells.Get(row, column).Text; }
                        else { Caption = fpSpd.Sheets[0].RowHeader.Cells.Get(row, column).Text; }
                    }
                    else
                    {
                        Caption = fpSpd.Sheets[0].Cells.Get(row, column).Text;
                    }
                }

                if (part == SpreadPart.ColumnHeader)
                {
                    fpSpd.Sheets[0].Models.ColumnHeaderSpan.Add(row, column, rowCount, columnCount);
                    fpSpd.Sheets[0].ColumnHeader.Cells[row, column].Text = Caption;
                }
                else if (part == SpreadPart.RowHeader)
                {
                    fpSpd.Sheets[0].Models.RowHeaderSpan.Add(row, column, rowCount, columnCount);
                    fpSpd.Sheets[0].RowHeader.Cells[row, column].Text = Caption;
                }
                else
                {
                    fpSpd.Sheets[0].Models.Span.Add(row, column, rowCount, columnCount);
                    fpSpd.Sheets[0].Cells[row, column].Text = Caption;
                }
            }
            catch { }
        }
        #endregion
    }
}
