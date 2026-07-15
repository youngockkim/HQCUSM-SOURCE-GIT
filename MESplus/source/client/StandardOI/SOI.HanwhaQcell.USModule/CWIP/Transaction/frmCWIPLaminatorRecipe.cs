using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace SOI.HanwhaQcell.USModule
{
    
    public partial class frmCWIPLaminatorRecipe : SOIBaseForm02
    {
        #region Property

        // (Required)         
        private List<string> m_listLaminator = new List<string>();
        
        // (Required) 
        private bool bIsShown = false;

        #endregion
        
        #region [Constant Definition]
        int ROWHEIGHT = 37;
        int MAX_COL_COUNT = 7;
        int DATA_START_COL = 3;
        String EQUIPMENT_TYPE_LAMINATOR = "LAMINATOR";
        Color CELL_NULL_COLOR = Color.Tomato;

        #endregion

        #region Constructor

        public frmCWIPLaminatorRecipe()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param> 
        /// <param name="e"></param>
        private void frmCWIPLaminatorRecipe_Load(object sender, EventArgs e)
        {
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            dtpDate.Value = DateTime.Now;
            
            this.spdChmb1._UseAutoHeight = false;
            this.spdChmb2._UseAutoHeight = false;

            getLineLocationList();
        }

        private void frmCWIPLaminatorRecipe_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        private void cboLineLocation_SelectionChanged(object sender, EventArgs e)
        {
            cdvLineID.Text = "";
            cdvLineID.Description = "";

            cleardata();

            this.BtnDelete.Enabled = false;
            this.btnCreate.Enabled = false;
            this.btnUpdate.Enabled = false;
        }
        #endregion
        
        #region Functions
        private bool cleardata()
        {
            spdChmb1.ActiveSheet.RowCount = 0;
            spdChmb2.ActiveSheet.RowCount = 0;

            for (int inx = this.m_listLaminator.Count - 1; inx >= 0; inx--)
            {
                this.m_listLaminator.RemoveAt(inx);
            }

            return true;
        }

        private bool getLineLocationList()
        {
            try
            {
                // Init
                //LINE 가져오기.

                // Init
                //GET LINE 
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_LOCATION));

                int i;
                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboLineLocation.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void getLaminatorResource()
        {
            try
            {
                TRSNode in_node = new TRSNode("DATA_IN");
                TRSNode out_node = new TRSNode("DATA_OUT");

                // 아래는 서비스 조회에 대한 예제입니다.                    
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '9';
                in_node.AddString("FACTORY", "USGAM1");
                in_node.AddString("RES_CMF_1", cdvLineID.Text);
                in_node.AddString("RES_CMF_11", "LAMINATOR");
                if (MPCF.CallService("CRAS", "CRAS_View_Resource_List_By_Line", in_node, ref out_node) == false)
                {
                    return;
                }

                // 조회한 서비스에서 List를 찾고 List에 해당 데이터가 있는지 검색합니다.                    
                if (out_node.GetList("RES_LIST") != null && out_node.GetList("RES_LIST").Count > 0)
                {                    
                    foreach (TRSNode data in out_node.GetList("RES_LIST"))
                    {
                        m_listLaminator.Add(data.GetString("RES_ID"));
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void getChamberBaseData()
        {
            try
            {
                TRSNode in_node = new TRSNode("DATA_IN");
                TRSNode out_node = new TRSNode("DATA_OUT");
                
                // 아래는 서비스 조회에 대한 예제입니다.                    
                MPCF.SetInMsg(in_node);               
                in_node.ProcStep = 'A';
                in_node.AddString("FACTORY", "USGAM1");
                in_node.AddString("KEY_1", cboLineLocation.Value);
                if (MPCF.CallService("CBAS", "CBAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return;
                }

                // 조회한 서비스에서 List를 찾고 List에 해당 데이터가 있는지 검색합니다.                    
                if (out_node.GetList("LIST") != null && out_node.GetList("LIST").Count > 0)
                {
                    spdChmb1.ActiveSheet.RowCount = 0;
                    spdChmb2.ActiveSheet.RowCount = 0;

                    int inx = 0, jnx= 0;
                    int chamber = 0, prechamber = 0;
                    int iDecimal = 0;
                    
                    foreach (TRSNode data in out_node.GetList("LIST"))
                    {
                        if ( int.TryParse(data.GetString("KEY_2"), out chamber) == false )
                            return;
                        if (int.TryParse(data.GetString("DATA_3"), out iDecimal) == false)
                            return;

                        if (chamber >= 100 && chamber <= 200)
                        {
                            spdChmb1.ActiveSheet.RowCount++;
                            spdChmb1.ActiveSheet.Rows[inx].Height = ROWHEIGHT;

                            if ( chamber != prechamber ) 
                            {
                                spdChmb1.ActiveSheet.Cells[inx, 0].Value = data.GetString("DATA_1");
                                spdChmb1.ActiveSheet.AddSpanCell(inx, 0, 1, 7);
                                spdChmb1.ActiveSheet.Cells[inx, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                spdChmb1.ActiveSheet.Cells[inx, 0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                spdChmb1.ActiveSheet.Cells[inx, 0].Locked = true;
                                spdChmb1.ActiveSheet.Cells[inx, 0].BackColor = Color.FromArgb(0, 150, 152);//Color.FromArgb(61, 69, 80);
                                prechamber = chamber;
                                inx++;
                                spdChmb1.ActiveSheet.RowCount++;
                                spdChmb1.ActiveSheet.Rows[inx].Height = ROWHEIGHT;
                            }
                            if (inx > 0)
                            {

                                spdChmb1.ActiveSheet.Cells[inx, 0].Value = data.GetString("KEY_2");
                                spdChmb1.ActiveSheet.Cells[inx, 1].Value = data.GetString("KEY_3");
                                spdChmb1.ActiveSheet.Cells[inx, 2].Value = data.GetString("DATA_2");
                                FarPoint.Win.Spread.CellType.NumberCellType nmbrcell = new FarPoint.Win.Spread.CellType.NumberCellType();
                                if (iDecimal > 0)
                                {
                                    nmbrcell.DecimalSeparator = ".";

                                }
                                nmbrcell.DecimalPlaces = iDecimal;
                                spdChmb1.ActiveSheet.Cells[inx, 3].CellType = nmbrcell;
                                spdChmb1.ActiveSheet.Cells[inx, 4].CellType = nmbrcell;
                                spdChmb1.ActiveSheet.Cells[inx, 5].CellType = nmbrcell;
                                spdChmb1.ActiveSheet.Cells[inx, 6].CellType = nmbrcell;
                            }
                            inx++;
                        }
                        else if (chamber > 200 )
                        {
                            spdChmb2.ActiveSheet.RowCount++;
                            spdChmb2.ActiveSheet.Rows[jnx].Height = ROWHEIGHT;

                            if (chamber != prechamber)
                            {
                                spdChmb2.ActiveSheet.Cells[jnx, 0].Value = data.GetString("DATA_1");
                                spdChmb2.ActiveSheet.AddSpanCell(jnx, 0, 1, 7);
                                spdChmb2.ActiveSheet.Cells[jnx, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                spdChmb2.ActiveSheet.Cells[jnx, 0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                spdChmb2.ActiveSheet.Cells[jnx, 0].Locked = true;
                                //spdChmb2.ActiveSheet.Cells[jnx, 0].BackColor = Color.FromArgb(61, 69, 80);
                                spdChmb2.ActiveSheet.Cells[jnx, 0].BackColor = Color.FromArgb(0, 150, 152);
                                prechamber = chamber;
                                jnx++;
                                spdChmb2.ActiveSheet.RowCount++;
                                spdChmb2.ActiveSheet.Rows[jnx].Height = ROWHEIGHT;
                            }
                            if (jnx > 0)
                            {
                                spdChmb2.ActiveSheet.Cells[jnx, 0].Value = data.GetString("KEY_2");
                                spdChmb2.ActiveSheet.Cells[jnx, 1].Value = data.GetString("KEY_3");
                                spdChmb2.ActiveSheet.Cells[jnx, 2].Value = data.GetString("DATA_2");
                                FarPoint.Win.Spread.CellType.NumberCellType nmbrcell = new FarPoint.Win.Spread.CellType.NumberCellType();
                                if (iDecimal > 0)
                                {
                                    nmbrcell.DecimalSeparator = ".";
                                    
                                }
                                nmbrcell.DecimalPlaces = iDecimal;
                                spdChmb2.ActiveSheet.Cells[jnx, 3].CellType = nmbrcell;
                                spdChmb2.ActiveSheet.Cells[jnx, 4].CellType = nmbrcell;
                                spdChmb2.ActiveSheet.Cells[jnx, 5].CellType = nmbrcell;
                                spdChmb2.ActiveSheet.Cells[jnx, 6].CellType = nmbrcell;

                            }
                            jnx++;
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void getChamberInputData()
        {
            try
            {
                TRSNode in_node = new TRSNode("DATA_IN");
                TRSNode out_node = new TRSNode("DATA_OUT");

                DateTime dtpScrapDateTimeOut = new DateTime();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", "USGAM1");
                in_node.AddString("LINE_ID", cdvLineID.Text);

                // Scrap Date
                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpScrapDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Laminator_Recipe_List", in_node, ref out_node) == false)
                {
                    return;
                }

                // 조회한 서비스에서 List를 찾고 List에 해당 데이터가 있는지 검색합니다.                    
                if (out_node.GetList("LAMINATOR_RECIPE_LIST") != null && out_node.GetList("LAMINATOR_RECIPE_LIST").Count > 0)
                {
                    this.BtnDelete.Enabled = true;
                    this.btnCreate.Enabled = false;
                    this.btnUpdate.Enabled = true;
                    foreach (TRSNode data in out_node.GetList("LAMINATOR_RECIPE_LIST"))
                    {
                        if (setInputDataToSpread(spdChmb1, data) == false)
                        {
                            setInputDataToSpread(spdChmb2, data);
                        }
                    }
                }
                else
                {
                    this.BtnDelete.Enabled = false;
                    this.btnCreate.Enabled = true ;
                    this.btnUpdate.Enabled = false;
                }

                spdChmb1.ActiveSheet.SetActiveCell(1, 3);
                spdChmb2.ActiveSheet.SetActiveCell(1, 3);

                MPCF.ShowSuccessMessage(out_node, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool setInputDataToSpread(SOISpread spread, TRSNode data)
        {
            for (int row = 0; row < spdChmb1.ActiveSheet.RowCount; row++)
            {
                if (data.GetString("CHMB_CD") != spread.ActiveSheet.Cells[row, 0].Value.ToString() ||
                    data.GetString("CHMB_ATTR") != spread.ActiveSheet.Cells[row, 1].Value.ToString()
                   )
                {
                    continue;
                }

                for (int col = DATA_START_COL; col < MAX_COL_COUNT; col++)
                {
                    int col_lami = m_listLaminator.Count - (MAX_COL_COUNT - col);
                    if (col_lami < 0 || col_lami >= m_listLaminator.Count)
                    {
                        continue;
                    }
                    if (data.GetString("RES_ID") == m_listLaminator[col_lami])
                    {
                        string itemVal = data.GetDouble("ATTR_VAL").ToString();
                        spread.ActiveSheet.Cells[row, col].Value = itemVal=="-999999999"?null:itemVal;
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cboLineLocation, false) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(593), MSG_LEVEL.ERROR, false);
                    return;
                }

                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", cboLineLocation.Value); 

                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }

                resetData();
                // Focus
                MPCF.SetFocus(cdvLineID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void resetData()
        {
            cleardata();
            getLaminatorResource();

            getChamberBaseData();
            getChamberInputData();
            checkCellEdited(spdChmb1);
            checkCellEdited(spdChmb2);
        }

        private bool validateRule()
        {
            if (checkCellEdited(spdChmb1) == false ||
                checkCellEdited(spdChmb2) == false)
            {
                MPCF.ShowMessage("All cells must be filled out", MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        //Only when users enter new set of data--all cells must be filled out. 
        //If there is any missing cell, pop-up message should appear for users to navigate the issue. 
        //(Create 버튼: 사용자가 새로운 데이터 (모든 셀에 데이터 입력을 해야만)를 입력시에만 사용가능. 
        //누락된 셀이 있는 경우, 팝업 메시지를 띄워 사용자가 이슈를 해결할 수 있도록 알려줘야 합니다.)
        private bool checkCellEdited(SOISpread spread)
        {
            bool bAllEdited = true;

            for (int row = 0; row < spread.ActiveSheet.RowCount; row++)
            {
                for (int col = 3; col < MAX_COL_COUNT; col++)
                {
                    if (spread.ActiveSheet.Cells[row, 0].Value == null ||
                        spread.ActiveSheet.Cells[row, 1].Value == null)
                    {
                        continue;
                    }
                    if (spread.ActiveSheet.Cells[row, col].Value == null)
                    {
                        spread.ActiveSheet.Cells[row, col].BackColor = CELL_NULL_COLOR;// Color.FromArgb(255, 200, 0, 0);
                        bAllEdited = false;
                    }
                    else
                    {
                        spread.ActiveSheet.Cells[row, col].BackColor = Color.FromArgb(61,69,80);
                    }

                }
            }

            return bAllEdited;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateRule() == false)
                {
                    return;
                }

                if (save(spdChmb1, 'I') == false) 
                    return;

                if (save(spdChmb2, 'I') == false)
                    return;

                resetData();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateRule() == false)
                {
                    return;
                }

                if (save(spdChmb1, 'U') == false)
                    return;

                if (save(spdChmb2, 'U') == false)
                    return;

                resetData();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateRule() == false)
                {
                    return;
                }

                if (save(spdChmb1, 'D') == false)
                    return;

                if (save(spdChmb2, 'D') == false)
                    return;

                resetData();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        private void spdChmb2_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            FarPoint.Win.Spread.Cell activeCell = ((FarPoint.Win.Spread.SheetView)sender).ActiveCell;
            if (activeCell.Value == null)
            {
                activeCell.BackColor = CELL_NULL_COLOR;
            }
            else
            {
                if (activeCell.Column.Index > 2)
                {
                    activeCell.BackColor = Color.FromArgb(61, 69, 80);
                }
            }
        }

        private void spdChmb1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            FarPoint.Win.Spread.Cell activeCell = ((FarPoint.Win.Spread.SheetView)sender).ActiveCell;
            if (activeCell.Value == null)
            {
                activeCell.BackColor = CELL_NULL_COLOR;
            }
            else
            {
                if (activeCell.Column.Index > 2)
                {
                    activeCell.BackColor = Color.FromArgb(61, 69, 80);
                }
            }
        }

        private bool save(SOISpread spread, char inproc)
        {
            TRSNode in_node = new TRSNode("DATA_IN");
            TRSNode out_node = new TRSNode("DATA_OUT");
            DateTime dtpScrapDateTimeOut = new DateTime();

            TRSNode tran_list = null;
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = inproc;
            in_node.AddString("FACTORY", "USGAM1");
            in_node.AddString("LINE_ID", cdvLineID.Text);

            // Scrap Date
            if (dtpDate.Value != null)
            {
                bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpScrapDateTimeOut);
                if (bTrySuccess == true)
                {
                    in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                }
            }
            //spread.ActiveSheet.RowCount
            for (int row = 0; row < spread.ActiveSheet.RowCount; row++)
            {
                for (int col = DATA_START_COL; col < MAX_COL_COUNT; col++)
                {
                    if (spread.ActiveSheet.Cells[row, 0].Value == null || 
                        spread.ActiveSheet.Cells[row, 1].Value == null)
                    {
                        continue;
                    }
                    int col_lami = m_listLaminator.Count - (MAX_COL_COUNT - col);
                    if (col_lami < 0 || col_lami >= m_listLaminator.Count)
                    {
                        return false;
                    }

                    tran_list = in_node.AddNode("TRAN_LIST");
                    
                    tran_list.AddString("RES_ID", m_listLaminator[col_lami]);
                    tran_list.AddString("CHMB_CD", spread.ActiveSheet.Cells[row, 0].Value);
                    tran_list.AddString("CHMB_ATTR", spread.ActiveSheet.Cells[row, 1].Value);
                    if (spread.ActiveSheet.Cells[row, col].Value == null)
                    {
                        tran_list.AddDouble("ATTR_VAL", -999999999);
                    }
                    else
                    {
                        tran_list.AddDouble("ATTR_VAL", spread.ActiveSheet.Cells[row, col].Value);
                    }

                }
            }

            if (MPCF.CallService("CWIP", "CWIP_Update_Laminator_Recipe", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCF.ShowSuccessMessage(out_node, false);
            return true;
        }



    }
}
