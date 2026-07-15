using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using FarPoint.Win;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Collections;

namespace SOI.OIFrx
{
    public partial class udcDirectViewSpred : UserControl
    {
        public udcDirectViewSpred()
        {
            InitializeComponent();

            //EventHandler();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        /// <summary> SP 실행을 위한 컨텍스트 메뉴가 팝업된 Spread의 SheetView 컨트롤 </summary>        
        protected FarPoint.Win.Spread.StyleInfo _style = new StyleInfo();

        udcSpread m_upContext = null;
        DataTable m_dtSpreadData = new DataTable();
        object[,] m_ObjColumns = null;
        bool m_ExcelExportEnabled = true;

        public udcSpread upContext
        {
            get { return m_upContext; }
            set { m_upContext = value; }
        }

        public DataTable dtSpreadData
        {
            get { return m_dtSpreadData; }
            set { m_dtSpreadData = value; }
        }

        public int TagCol(string sTag)
        {
            return spdData.ActiveSheet.ColumnHeader.Columns[sTag].Index;
        }

        public int TagRow(string sTag)
        {
            return spdData.ActiveSheet.RowHeader.Columns[sTag].Index;
        }

        public int iCol { get; set; }
        public int iRow { get; set; }


        public object[,] ObjColumns
        {
            get { return m_ObjColumns; }
            set { m_ObjColumns = value; }
        }
        public int[] iArryVisibleCols { get; set; }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("AllowColumnMove")
       , Description("Column의 위치조정 설정")]

        public bool spdAllowColumnMove
        {
            get
            {
                return spdData.ActiveSheet.FpSpread.AllowColumnMove;
            }
            set
            {
                spdData.ActiveSheet.FpSpread.AllowColumnMove = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
      , DefaultValue("")
      , Category("OperationMode")
      , Description("RowSelection 설정")]

        public OperationMode spdOperationMode
        {
            get
            {
                return spdData.ActiveSheet.OperationMode;
            }
            set
            {
                spdData.ActiveSheet.OperationMode = value;
            }
        }
      
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("GroupBox Title")
       , Description("GroupBox의 Title을 설정")]
       
        public string gbTitle
        {
            get {
                    return grpTranMiddle.Text;
                }
            set {
                     grpTranMiddle.Text = value;
                }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("View ID")
       , Description("Query View ID를 설정")]

        public string spdViewID
        {
            get
            {
                return lblViewID.Text;
            }
            set
            {
                lblViewID.Text = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Excel Export")
       , Description("Context 엑셀 다운로드 사용여부를 설정")]
        public bool tsExcelExportEnabled
        {
            get { return m_ExcelExportEnabled; }
            set { ExcelExportToolStripMenuItem.Enabled = value; this.Invalidate(); }
        }

         [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Spread Cell Click")
       , Description("Spread Cell Click 설정")]
        public event FarPoint.Win.Spread.CellClickEventHandler spdCellClick
        {
            add
            {
                spdData.CellClick += value;
            }
            remove
            {
                spdData.CellClick -= value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
      , DefaultValue("")
      , Category("Spread SelectChanged")
      , Description("Spread SelectCahanged 설정")]
        public event FarPoint.Win.Spread.SelectionChangedEventHandler spdSelectChanged
        {
            add
            {
                spdData.SelectionChanged += value;
            }
            remove
            {
                spdData.SelectionChanged -= value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
      , DefaultValue("")
      , Category("Spread ButtonClicked")
      , Description("Spread ButtonClicked 설정")]
        public event FarPoint.Win.Spread.EditorNotifyEventHandler spdButtonClicked
        {
            add
            {
                spdData.ButtonClicked += value;
            }
            remove
            {
                spdData.ButtonClicked -= value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
      , DefaultValue("")
      , Category("Spread Cell Double Click")
       , Description("Spread Cell Double Click 설정")]
        public event FarPoint.Win.Spread.CellClickEventHandler spdCellDoubleClick
        {
            add
            {
                spdData.CellDoubleClick += value;
            }
            remove
            {
                spdData.CellDoubleClick -= value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Spread EditModeOff")
       , Description("Spread EditModeOff")]
        public event System.EventHandler EditModeOff
        {
            add
            {
                spdData.EditModeOff += value;
            }
            remove
            {
                spdData.EditModeOff -= value;
            }
        }


        private void udcDirectViewSpred_Load(object sender, EventArgs e)
        {
           
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
        /// Make Spread ColumnHeader
        /// </summary>
        /// <param name="fpSpd"></param>
        private void MakeSpreadColHeader(udcDirectViewSpred ucSpd, DataTable tblData, object[,] oCol)
        {
            udcDirectViewSpred sprMaker1 = new udcDirectViewSpred();

            try
            {
                sprMaker1.MakeSpreadColHeader(ucSpd, tblData, oCol);

                if (ucSpd.spdData.Name.ToString().Equals("spdData"))
                {
                    sprMaker1.SetHideColumn(ucSpd, iArryVisibleCols, false);
                }
                CaptionChange();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        public void SetHideColumn(udcDirectViewSpred spd, int[] keys, bool bValue)
        {
            foreach (int key in keys)
            {
                spd.spdData.ActiveSheet.Columns[key].Visible = bValue;
            }
        }

        #region [ Context Event ]
        /// <summary>
        /// Context Menu Excel Export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ExportExcel(spdData, "", false, MPCF.FindLanguage(this.grpTranMiddle.Text, 0));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void customizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //frmDNMColumnSetupPopup frm = new frmDNMColumnSetupPopup();
                //frm.model.ViewID = lblViewID.Text;
                //frm.StartPosition = FormStartPosition.CenterParent;
                //frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void viewSqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ViewControl sc = new ViewControl("View Query");
                    sc.ShowDialog();
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion

        #region [ Spread Event ]
        /// <summary>
        /// spdData Cell Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                spdData.Focus();

                FarPoint.Win.Spread.CellType.TextCellType txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                FarPoint.Win.Spread.CellType.NumberCellType numCell = new FarPoint.Win.Spread.CellType.NumberCellType();

                if (e.Button == MouseButtons.Right)
                {
                    this.ContextMenuStrip = SortcontextMenuStrip;

                    // jhlee. 20170808 add. > admin 그룹인 경우에만 view sql이 보이도록 설정
                    if (MPGV.gcAdminGrpFlag != 'Y' && SortcontextMenuStrip.Items.Count > 1)
                    {
                        SortcontextMenuStrip.Items.RemoveAt(1);
                    }
                }
                else
                {
                    int i = 0;

                    // 행 선택 흔적 지우기
                    for (i = 0; i < ((FpSpread)sender).Sheets[0].Rows.Count; i++)
                    {
                        if (((FpSpread)sender).Sheets[0].Rows[i].Border != _style.Border)
                        {
                            ((FpSpread)sender).Sheets[0].Rows[i].Border = _style.Border;
                            break;
                        }
                    }

                    // 행 선택
                    FarPoint.Win.Spread.Row row;
                    FarPoint.Win.BevelBorder bord = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered, Color.Black, Color.Black, 1, false, true, false, true);
                    row = ((FpSpread)sender).Sheets[0].Rows[e.Row];
                    row.Border = bord;

                    if (spdData.Sheets[0].OperationMode == OperationMode.SingleSelect)
                    {
                        MOGV.sClipboardText = spdData.Sheets[0].Cells[e.Row, e.Column].Text;
                    }

                    //spdData.Sheets[0].SetActiveCell(e.Row, e.Column);

                    

                    //if ((spdData.Sheets[0].ActiveColumn.CellType.ToString().ToUpper() == txtCell.ToString().ToUpper() && spdData.Sheets[0].ActiveCell.Value != null)
                    //    || (spdData.Sheets[0].ActiveColumn.CellType.ToString().ToUpper() == numCell.ToString().ToUpper() && spdData.Sheets[0].ActiveCell.Value != null)
                    //    )
                    //{
                    //    KCGV.sClipboardText = spdData.Sheets[0].ActiveCell.Value.ToString();
                    //}
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

        // 복사를 누를 경우.
        private void spdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char) 3 )
                {
                    if (MOGV.sClipboardText != "" && spdData.Sheets[0].OperationMode == OperationMode.SingleSelect)
                    {
                        Clipboard.SetText(MOGV.sClipboardText);
                    }

                    #region old code
                    //if (spdData.Sheets[0].RowCount > 0 && spdData.Sheets[0].ActiveCell != null)
                    //{
                    //    if (spdData.Sheets[0].ActiveCell.Value != null)
                    //    {
                    //        string sText = " ";
                    //        if (string.IsNullOrEmpty(spdData.Sheets[0].ActiveCell.Value.ToString()) == false)
                    //        {
                    //            sText = spdData.Sheets[0].ActiveCell.Value.ToString();
                    //        }

                    //        Clipboard.SetText(sText);
                    //    }
                    //}
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

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
                        fpSpd.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Default);
                    }
                }
            }
        }

        private void spdData_DoubleClick(object sender, EventArgs e)
        {
            return;
        }
        #endregion 
    }

}
