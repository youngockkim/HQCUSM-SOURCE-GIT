using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Miracom.CliFrx;

namespace SOI.OIFrx
{
    public partial class udcAttachFile : UserControl
    {
        public udcAttachFile()
        {
            InitializeComponent();

            InitSpread();
        }

        #region " Constant Definition "

        private enum COL_SPD : int
        {
            COL_CHK = 0,
            COL_FILE_NAME,
            COL_FILE_SIZE,
            COL_FILE_PATH,
            COL_UPLOAD_FLAG
        }

        #endregion

        #region " Variable Definition "

        public FarPoint.Win.Spread.FpSpread GetSpread() { return spdData; }

        private System.EventHandler AddButtonPressEvent;
        public event System.EventHandler AddButtonPress
        {
            add
            {
                AddButtonPressEvent = (System.EventHandler)System.Delegate.Combine(AddButtonPressEvent, value);
            }
            remove
            {
                AddButtonPressEvent = (System.EventHandler)System.Delegate.Remove(AddButtonPressEvent, value);
            }
        }
        private System.EventHandler AddButtonPressEventAfter;
        public event System.EventHandler AddButtonPressAfter
        {
            add
            {
                AddButtonPressEventAfter = (System.EventHandler)System.Delegate.Combine(AddButtonPressEventAfter, value);
            }
            remove
            {
                AddButtonPressEventAfter = (System.EventHandler)System.Delegate.Remove(AddButtonPressEventAfter, value);
            }
        }
        private System.EventHandler DelButtonPressEvent;
        public event System.EventHandler DelButtonPress
        {
            add
            {
                DelButtonPressEvent = (System.EventHandler)System.Delegate.Combine(DelButtonPressEvent, value);
            }
            remove
            {
                DelButtonPressEvent = (System.EventHandler)System.Delegate.Remove(DelButtonPressEvent, value);
            }
        }
        private System.EventHandler DelButtonPressEventAfter;
        public event System.EventHandler DelButtonPressAfter
        {
            add
            {
                DelButtonPressEventAfter = (System.EventHandler)System.Delegate.Combine(DelButtonPressEventAfter, value);
            }
            remove
            {
                DelButtonPressEventAfter = (System.EventHandler)System.Delegate.Remove(DelButtonPressEventAfter, value);
            }
        }

        #endregion

        #region " Function Definition "

        /// <summary>
        /// 조회 후 칼럼 정렬
        /// </summary>
        /// <param name="fpSpd"></param>
        /// <param name="iCol"></param>
        private void SetCelType(FarPoint.Win.Spread.FpSpread fpSpd, int iCol)
        {
            SetCelType(fpSpd, iCol, -1);
        }

        /// <summary>
        /// 조회 후 칼럼 정렬
        /// </summary>
        /// <param name="fpSpd"></param>
        /// <param name="iCol"></param>
        private void SetCelType(FarPoint.Win.Spread.FpSpread fpSpd, int iCol, int iRow)
        {
            spdData.GetTypeNumber().DecimalPlaces = 0;

            try
            {
                if (fpSpd.Name.ToString().Equals("spdData"))
                {
                    //스프레드 칼럼 정의
                    if (iRow < 0)
                    {
                        #region < Columns >
                        switch (iCol)
                        {
                            case (int)COL_SPD.COL_CHK:
                                fpSpd.Sheets[0].Columns[iCol].Locked = false;
                                fpSpd.Sheets[0].Columns[iCol].CellType = spdData.GetTypeCheck();
                                fpSpd.Sheets[0].Columns[iCol].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                fpSpd.Sheets[0].Columns[iCol].Width = 30;
                                break;
                            case (int)COL_SPD.COL_FILE_NAME:
                                fpSpd.Sheets[0].Columns[iCol].Locked = true;
                                fpSpd.Sheets[0].Columns[iCol].CellType = spdData.GetTypeText();
                                fpSpd.Sheets[0].Columns[iCol].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                                fpSpd.Sheets[0].Columns[iCol].Width = 150;
                                break;
                            case (int)COL_SPD.COL_FILE_SIZE:
                                fpSpd.Sheets[0].Columns[iCol].Locked = true;
                                fpSpd.Sheets[0].Columns[iCol].CellType = spdData.GetTypeNumber();
                                fpSpd.Sheets[0].Columns[iCol].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                                fpSpd.Sheets[0].Columns[iCol].Width = 80;
                                break;
                            case (int)COL_SPD.COL_FILE_PATH:
                                fpSpd.Sheets[0].Columns[iCol].Locked = true;
                                fpSpd.Sheets[0].Columns[iCol].CellType = spdData.GetTypeText();
                                fpSpd.Sheets[0].Columns[iCol].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                                fpSpd.Sheets[0].Columns[iCol].Width = 300;
                                break;
                            case (int)COL_SPD.COL_UPLOAD_FLAG:
                                fpSpd.Sheets[0].Columns[iCol].Locked = true;
                                fpSpd.Sheets[0].Columns[iCol].CellType = spdData.GetTypeText();
                                fpSpd.Sheets[0].Columns[iCol].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                fpSpd.Sheets[0].Columns[iCol].Width = 80;
                                break;

                            default:
                                break;
                        }
                        #endregion
                    }
                    //스프레드 로우 정의
                    else if (iRow >= 0)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 칼럼 정의
        /// </summary>
        /// <param name="fpSpd">스프레드</param>
        /// <returns></returns>
        private object[,] ObjColumns(FarPoint.Win.Spread.FpSpread fpSpd)
        {
            object[,] ObjCol = null;

            try
            {
                switch (fpSpd.Name.ToString())
                {
                    #region "spdData"
                    case "spdData":
                        ObjCol = new object[,] {
                            {" "        , 30,  "CHK", udcFarpoint.SpreadCellType.CheckBoxCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"File Name", 150, "FILE_NAME", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"File Size", 100, "FILE_SIZE", udcFarpoint.SpreadCellType.NumberCellType, udcFarpoint.SpreadCellHAlign.Right, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"File Path", 300, "FILE_PATH", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"Upload Flag", 80, "UPLOAD_FLAG", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
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

        /// <summary>
        /// 스프레드 초기화
        /// </summary>
        /// <returns></returns>
        private bool InitSpread()
        {
            try
            {
                //스프레드 테마 적용 및 초기화
                spdData.ApplyTema(false, true, FarPoint.Win.Spread.OperationMode.Normal);
                spdData.MakeSpreadColHeader(spdData, null, ObjColumns(spdData));

                //각 스프레드 셀 유형 초기화
                #region [Spread Cell Type - spdData]
                int idCol = 0;
                for (int i = 0; i < spdData.Sheets[0].ColumnCount; i++)
                {
                    SetCelType(spdData, idCol++);
                }
                int idRow = 0;
                for (int i = 0; i < spdData.Sheets[0].RowCount; i++)
                {
                    SetCelType(spdData, -1, idRow++);
                }
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 파일 추가
        /// </summary>
        /// <returns></returns>
        private bool AddFile()
        {
            DataTable _dt = (DataTable)spdData.DataSource;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.FilterIndex = 1;                                 // FilterIndex는 1부터 시작 (여기서는 *.txt)        
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;
 
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                    {
                        DataRow[] _drValidation = _dt.Select("FILE_NAME = '" + openFileDialog.SafeFileNames[i] + "'");

                        if (_drValidation.Length > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(366));
                            return false;
                        }

                        DataRow _dr = _dt.NewRow();

                        FileStream fsFile = new FileStream(openFileDialog.FileNames[i], FileMode.Open, FileAccess.Read, FileShare.Read);

                        _dr[(int)COL_SPD.COL_CHK]           = "False";
                        _dr[(int)COL_SPD.COL_FILE_NAME]     = openFileDialog.SafeFileNames[i];
                        _dr[(int)COL_SPD.COL_FILE_SIZE]     = fsFile.Length / 1000;
                        _dr[(int)COL_SPD.COL_FILE_PATH]     = openFileDialog.FileNames[i];
                        _dr[(int)COL_SPD.COL_UPLOAD_FLAG]   = "N";

                        _dt.Rows.Add(_dr);
                    }

                    spdData.DataSource = _dt;

                    //각 스프레드 셀 유형 초기화
                    #region [Spread Cell Type - spdData]
                    int idCol = 0;
                    for (int i = 0; i < spdData.Sheets[0].ColumnCount; i++)
                    {
                        SetCelType(spdData, idCol++);
                    }
                    int idRow = 0;
                    for (int i = 0; i < spdData.Sheets[0].RowCount; i++)
                    {
                        SetCelType(spdData, -1, idRow++);
                    }
                    #endregion
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 파일 삭제
        /// </summary>
        /// <returns></returns>
        private bool DelFile()
        {
            try
            {
                DataTable _dt = (DataTable)spdData.DataSource;

                for (int i = _dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow _dr = _dt.Rows[i];  

                    if (Convert.ToBoolean(_dr[(int)COL_SPD.COL_CHK]) == true)
                    {
                        _dr.Delete();
                    }
                }

                spdData.DataSource = _dt;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddButtonPressEvent != null)
                AddButtonPressEvent(this, e);

            if (AddFile() == false) return;

            if (AddButtonPressEventAfter != null)
                AddButtonPressEventAfter(this, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (DelButtonPressEvent != null)
                DelButtonPressEvent(this, e);

            if (DelFile() == false) return;

            if (DelButtonPressEventAfter != null)
                DelButtonPressEventAfter(this, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (InitSpread() == false) return;
        }
    }
}
