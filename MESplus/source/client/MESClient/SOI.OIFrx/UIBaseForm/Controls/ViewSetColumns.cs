/*---------------------------------------------------------------------------------------------------*/
//
//  Program Id      : ViewSetColumns
//  Creator         : PARK S.H
//  Create Date     : 2014.03.26
//  Description     : Set Columns
//  History         : 스프레드 칼럼 속성(Visible)을 관리한다.
//
/*---------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI;
using Miracom.TRSCore;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Reflection;
using Miracom.UI.Controls.MCCodeView;

namespace SOI.OIFrx
{
    public partial class ViewSetColumns : Miracom.MESCore.TranForm02
    {
        public ViewSetColumns()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #region [ Enum Columns ]
        /// <summary>
        /// Spread Column Attribute
        /// </summary>
        private enum ColTp : int
        {
            sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock
        }
        /// <summary>
        /// Spread Information
        /// </summary>
        private enum Cols1 : int
        {
            FORMS, SPD, CUSTOM_COLS, DEFAULT_COLS, COLS_CODE, COLS_DESC
        }

        #endregion

        #endregion

        #region " Variable Definition "

        DataTable dtBlank = new DataTable();
        Hashtable htSelected = new Hashtable();
        Control ctlC = new Control();
        private DataTable _dtSpreadData = new DataTable(); // Spread에 바인딩 할 Raw Data
        SpreadTypes.ActivePosition activePosition = new SpreadTypes.ActivePosition(0, 0);
        //int time1, time2;
        FpSpread fpContext = new FpSpread();
        Spread sprMaker = new Spread();
        DataTable dtTemp = new DataTable();

        string sLabel = string.Empty;
        int iWidth = 0;
        string sKey = string.Empty;
        CheckBoxCellType chkTypeH = new CheckBoxCellType();
        DateTimePickerCellType DtPick = new DateTimePickerCellType();
        Spread.SpreadCellType CelType = Spread.SpreadCellType.TextCellType;
        Spread.SpreadCellHAlign CelHalign = Spread.SpreadCellHAlign.Center;
        Spread.SpreadCellVAlign CelValign = Spread.SpreadCellVAlign.Center;
        Spread.SpreadCellMerge CelMerge = Spread.SpreadCellMerge.None;
        bool bHide = false;
        bool bLock = true;
        #endregion

        #region " Properties "

        //public string Mode
        //{
        //    get { return m_Mode; }
        //    set { m_Mode = value; }
        //}
        public string sForms { get; set; }
        public string sSpdName { get; set; }
        public object[,] oCols { get; set; }
        public int[] iArrayHide { get; set; }

        public Hashtable hash { get; set; }
        #endregion

        #region " Function Definition "

        /// <summary>
        /// Object Clone
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool ObjectClone(Control ctl, object objs)
        {
            try
            {
                this.btnClose.BringToFront();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        /// <summary>
        /// RealTime Caption Change
        /// </summary>
        /// <returns></returns>
        private bool CaptionChange()
        {
            try
            {
                MPCF.ConvertMessage(this.Controls);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        /// <summary>
        /// initialze Condition
        /// </summary>
        /// <returns></returns>
        private bool initCondition(object objs)
        {
            try
            {
                this.btnClose.BringToFront();

                foreach (Control ctlChild in this.grpTranTop.Controls)
                {
                    Object obj = ctlChild as object;

                    if (obj is Label)
                    {
                        if (((Label)obj).Name.ToString().Equals("lblTitleDescription"))
                        {
                            ((Label)obj).Text = MPCF.FindLanguage(sForms, 0);
                        }
                    }
                }

                if (objs is FarPoint.Win.Spread.FpSpread)
                {
                    if (((FpSpread)objs).Name.ToString().Equals("spdData"))
                    {
                        ((FpSpread)objs).ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
                        ((FpSpread)objs).ColumnSplitBoxPolicy = SplitBoxPolicy.Never;
                        ((FpSpread)objs).RowSplitBoxPolicy = SplitBoxPolicy.Never;
                        ((FpSpread)objs).ActiveSheet.HorizontalGridLine = new GridLine(GridLineType.None);
                        ((FpSpread)objs).ActiveSheet.VerticalGridLine = new GridLine(GridLineType.None);
                        ((FpSpread)objs).BorderStyle = BorderStyle.FixedSingle;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check the conditions before transaction
        /// </summary>
        /// <param name="FuncName">Function Name</param>
        /// <returns></returns>
        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "VIEW":
                        //MPCF.ClearList(spdData);
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Clear Control Value
        /// </summary>
        /// <param name="FuncName">Function Name</param>
        /// <returns></returns>
        private bool ClearData(string FuncName)
        {
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "VIEW":
                        MPCF.FieldClear(this);
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool MakeSpreadCelType(FarPoint.Win.Spread.FpSpread fpSpd, object[,] oCol)
        {
            Spread sprMaker1 = new Spread();
            try
            {
                if (oCol != null)
                {
                    if (oCol.GetLongLength(0) > 0)
                    {
                        if (fpSpd.ActiveSheet.Rows.Count > 0)
                        {
                            foreach (DataRow dr in ((DataTable)fpSpd.DataSource as DataTable).Rows)
                            {
                                fpSpd.ActiveSheet.Rows[dr.Table.Rows.IndexOf(dr)].Height = 40;
                            }
                        }
                        sprMaker1.SpreadWidthResize(fpSpd, Spread.SpreadPart.Sheet);
                        fpSpd.Sheets[0].ColumnHeader.Rows[0].Height = 30;
                        fpSpd.ActiveSheet.ColumnHeader.Cells[0, (int)Cols1.CUSTOM_COLS].CellType = chkTypeH;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Make Spread ColumnHeader
        /// </summary>
        /// <param name="fpSpd"></param>
        private void MakeSpreadColHeader(FarPoint.Win.Spread.FpSpread fpSpd, DataTable tblData, object[,] oCol)
        {
            Spread sprMaker1 = new Spread();

            try
            {
                sprMaker1.MakeSpreadColHeader(fpSpd, tblData, oCol);
                CaptionChange();
                MakeSpreadCelType(fpSpd, ObjColumns(fpSpd));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        /// <summary>
        /// DataTable Column을 생성하는 함수입니다.
        /// </summary>
        /// <param name="sDtName"></param>
        /// <param name="oCol"></param>
        /// <returns></returns>
        public DataTable CreateDataTable(string sDtName, object[,] oCol)
        {
            DataTable dt = new DataTable(sDtName);

            try
            {
                string sKey = string.Empty;
                DataColumn[] dc = null;
                int i = 0;

                if (oCol != null && oCol.GetLongLength(0) > 0)
                {
                    for (int iCol = 0; iCol < oCol.GetLongLength(0); iCol++)
                    {
                        sKey = oCol[iCol, 0].ToString();
                        dt.Columns.Add(sKey, Type.GetType(oCol[iCol, 1].ToString()));
                        if (Boolean.Parse(oCol[iCol, 2].ToString()))
                        {
                            ++i;
                            dc[i].ColumnName = sKey;
                        }
                    }
                    if (i > 0)
                    {
                        dt.PrimaryKey = dc;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return dt;
        }
        /// <summary>
        /// DataColumn을 생성합니다.
        /// </summary>
        /// <param name="sDtName"></param>
        /// <returns></returns>
        public object[,] ObjColumns(string sDtName)
        {
            object[,] ObjCol = null;

            try
            {
                switch (sDtName.ToString())
                {
                    #region [ dtTemp ]
                    case "dtTemp":
                        ObjCol = new object[,] { 
                        { "Forms", typeof(string), false },
                        { "Spread_Name", typeof(string), false },
                        { "Custom_Column", typeof(bool), false },
                        { "Default_Column", typeof(bool), false },
                        { "Column_Name", typeof(string), false },
                        { "Column_Desc", typeof(string), false }
                        };
                        break;
                    #endregion
                    default:
                        break;
                }

                return ObjCol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        /// <summary>
        /// Column Header Data
        /// </summary>
        /// <param name="fpSpd"></param>
        /// <returns></returns>
        private object[,] ObjColumns(FarPoint.Win.Spread.FpSpread fpSpd)
        {
            object[,] ObjCol = null;

            try
            {
                switch (fpSpd.Name.ToString())
                {
                    #region [ spdData ]
                    case "spdData":
                        ObjCol = new object[,] {
                            {"Form", 100,"Forms", Spread.SpreadCellType.TextCellType, Spread.SpreadCellHAlign.Left, Spread.SpreadCellVAlign.Center, Spread.SpreadCellMerge.None, true, true},
                            {"Spread_Name", 100,"Spread_Name", Spread.SpreadCellType.TextCellType, Spread.SpreadCellHAlign.Left, Spread.SpreadCellVAlign.Center, Spread.SpreadCellMerge.None, true, true},
                            {"", 40,"Custom_Column", Spread.SpreadCellType.CheckBoxCellType, Spread.SpreadCellHAlign.Center, Spread.SpreadCellVAlign.Center, Spread.SpreadCellMerge.None, false, false},
                            {"Default_Column", 40,"Default_Column", Spread.SpreadCellType.CheckBoxCellType, Spread.SpreadCellHAlign.Center, Spread.SpreadCellVAlign.Center, Spread.SpreadCellMerge.None, false, true},
                            {"Column_Name", 100,"Column_Name", Spread.SpreadCellType.TextCellType, Spread.SpreadCellHAlign.Left, Spread.SpreadCellVAlign.Center, Spread.SpreadCellMerge.None, false, true},
                            {"Column_Desc", 100,"Column_Desc", Spread.SpreadCellType.TextCellType, Spread.SpreadCellHAlign.Left, Spread.SpreadCellVAlign.Center, Spread.SpreadCellMerge.None, false, true}
                            
                        };
                        break;
                    #endregion
                    default:
                        break;
                }
                return ObjCol;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return ObjCol;
            }
            finally
            {
            }
        }
        private bool SetColsInformation()
        {
            try
            {

                dtTemp = CreateDataTable("dtTemp", ObjColumns("dtTemp"));
                DataRow drTmp = null;

                if (oCols != null)
                {
                    if (oCols.GetLongLength(0) > 0)
                    {
                        for (int iCol = 0; iCol < oCols.GetLongLength(0); iCol++)
                        {
                            sLabel = oCols[iCol, (int)ColTp.sLabel].ToString();
                            iWidth = Convert.ToInt32(oCols[iCol, (int)ColTp.iWidth].ToString());
                            sKey = oCols[iCol, (int)ColTp.sKey].ToString();
                            CelType = (Spread.SpreadCellType)oCols[iCol, (int)ColTp.CelType];
                            CelHalign = (Spread.SpreadCellHAlign)oCols[iCol, (int)ColTp.CelHalign];
                            CelValign = (Spread.SpreadCellVAlign)oCols[iCol, (int)ColTp.CelValign];
                            CelMerge = (Spread.SpreadCellMerge)oCols[iCol, (int)ColTp.CelMerge];
                            bHide = (bool)oCols[iCol, (int)ColTp.bHide];
                            bLock = (bool)oCols[iCol, (int)ColTp.bLock];

                            drTmp = dtTemp.NewRow();
                            drTmp[(int)Cols1.FORMS] = sForms;
                            drTmp[(int)Cols1.SPD] = sSpdName;
                            //넘겨 온 column hidden value setting
                            foreach (int iIdx in iArrayHide)
                            {
                                if (iIdx == iCol)
                                {
                                    drTmp[(int)Cols1.CUSTOM_COLS] = bHide;
                                    drTmp[(int)Cols1.DEFAULT_COLS] = bHide;
                                    break;
                                }
                                else
                                {
                                    drTmp[(int)Cols1.CUSTOM_COLS] = true;
                                    drTmp[(int)Cols1.DEFAULT_COLS] = true;
                                }
                            }
                            drTmp[(int)Cols1.COLS_CODE] = sKey;
                            drTmp[(int)Cols1.COLS_DESC] = MPCF.FindLanguage(sLabel, 0);

                            dtTemp.Rows.Add(drTmp);
                            dtTemp.AcceptChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);

                return false;
            }
            return true;
        }
        #endregion

        #region " Form Event Definition "

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        private void ViewSetColumns_Shown(object sender, System.EventArgs e)
        {
            this.BringToFront();

            SetColsInformation();
            MakeSpreadColHeader(this.spdData, dtTemp, ObjColumns(this.spdData));
            MakeSpreadCelType(spdData, ObjColumns(spdData));
        }

        private void ViewSetColumns_Load(object sender, System.EventArgs e)
        {
            EventHandler();
            initCondition(this);
            initCondition(lblTitleDescription);
            initCondition(spdData);
        }

        #endregion

        #region " Main Button Event "
        /// <summary>
        /// 
        /// </summary>
        private void Button_EventCmnExecute(object sender, EventArgs e)
        {
            DataTable _dt = new DataTable();

            try
            {
                CheckCondition("VIEW");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            finally
            {
                MPGV.gsCurrentLot_ID = "";
                MOGV.grpCond = null;
                MOGV.htSelected = null;
            }
        }
        /// <summary>
        /// Save
        /// </summary>
        private void Button_EventCmnSave(object sender, EventArgs e)
        {

            try
            {
                //if (MPCF.ShowMsgBox("선택된 칼럼을 적용하시겠습니까?", Application.ProductName, MessageBoxButtons.YesNo, 1) != DialogResult.Yes) return;
                //iArryHide re-setting
                DataRow[] rows = (spdData.DataSource as DataTable).Select(" 1=1 AND Custom_Column='True'");
                iArrayHide = new int[rows.Length];
                int iCnt = 0;
                foreach (DataRow dr in (spdData.DataSource as DataTable).Rows)
                {
                    if ((bool)dr[(int)Cols1.CUSTOM_COLS] == true)
                    {
                        iArrayHide.SetValue(dr.Table.Rows.IndexOf(dr), iCnt);
                        iCnt++;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {
                this.Dispose();
            }
        }

        #endregion

        #region " Main Control Event Handler "

        /// <summary>
        /// Control Event Handler
        /// </summary>
        private void EventHandler()
        {
            // Main Button Event Handler
            this.btnView.Click += new System.EventHandler(Button_EventCmnExecute);
            this.btnProcess.Click += new System.EventHandler(Button_EventCmnSave);

            #region [ Control Event ]
            #endregion

            #region [ Spread Event ]
            this.spdData.MouseMove += new MouseEventHandler(spdData_MouseMove);
            this.spdData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(spdData_CellClick);
            this.spdData.ScrollTipFetch +=new ScrollTipFetchEventHandler(spdData_ScrollTipFetch);
            this.spdData.TopChange +=new TopChangeEventHandler(spdData_TopChange);
            this.spdData.LeftChange +=new LeftChangeEventHandler(spdData_LeftChange);            
            #endregion
        }

        #endregion

        #region " Event Definition "
        #region [ Control Event]


        #endregion

        #region [ Spread Event ]
        /// <summary>
        /// Spread MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdData_MouseMove(object sender, MouseEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            FarPoint.Win.Spread.Model.CellRange cRange = fpSpd.GetCellFromPixel(0, 0, e.X, e.Y);

            if (cRange.Row > -1)
            {
                if (cRange.Column > -1)
                {
                    if (fpSpd.ActiveSheet.Columns[cRange.Column].Locked)
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
        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            List<string> lstInfo = new List<string>();
            List<string> lstkey = new List<string>();
            htSelected = null;
            Spread sprMaker = new Spread();
            FarPoint.Win.Spread.FpSpread spread = sender as FarPoint.Win.Spread.FpSpread;
            DataTable dt = null;
            dt = new DataTable();
            List<string> lstAddKeys = new List<string>();

            try
            {
                string sLine = string.Empty;
                string sDate_Type = string.Empty;
                string sStart_Date = string.Empty;
                string sEnd_Date = string.Empty;

                FarPoint.Win.Spread.FpSpread fpSpd = sender as FarPoint.Win.Spread.FpSpread;
                ArrayList aCode = new ArrayList();
                int iCols = e.Column;
                lstInfo.Clear();

                if (e.ColumnHeader)
                {
                    if (((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.Columns[e.Column].CellType is FarPoint.Win.Spread.CellType.CheckBoxCellType)
                    {
                        if (((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].CellType is FarPoint.Win.Spread.CellType.CheckBoxCellType)
                        {
                            if (e.ColumnHeader)
                            {
                                ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Locked = false;
                                if (((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value.Equals("") ||
                                    ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value.Equals(false))
                                    ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value = true;
                                else
                                    ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value = !Convert.ToBoolean(((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value);

                                for (int i = 0; i < ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.RowCount; i++)
                                    ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.Cells[i, e.Column].Value = ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value;
                            }
                        }
                    }
                }
                else if (!e.ColumnHeader)
                {
                    if (fpSpd.Name.Equals("spdData"))
                    {
                        if (e.Column >= 0)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                #region [spdData]
                                //HASH TABLE
                                htSelected = sprMaker.GetRowHashTable(fpSpd, e.Row, null);
                                #endregion
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            finally
            {
            }
        }
        /// <summary>
        /// ScrollTipFetch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdData_ScrollTipFetch(object sender, FarPoint.Win.Spread.ScrollTipFetchEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            fpSpd.ActiveSheet.SetActiveCell(e.Row, e.Column);
        }

        private void spdData_TopChange(object sender, FarPoint.Win.Spread.TopChangeEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            int iActCol = fpSpd.ActiveSheet.ActiveColumnIndex;
            fpSpd.ActiveSheet.SetActiveCell(e.NewTop, iActCol);
        }


        private void spdData_LeftChange(object sender, FarPoint.Win.Spread.LeftChangeEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            int iActRow = fpSpd.ActiveSheet.ActiveRowIndex;
            fpSpd.ActiveSheet.SetActiveCell(iActRow, e.NewLeft);
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.btnProcess.PerformClick();
            this.Close();
        }

        private void ViewSetColumns_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.btnProcess.PerformClick();
        }

        private void ViewSetColumns_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.btnProcess.PerformClick();
        }
        #endregion


    }
}
