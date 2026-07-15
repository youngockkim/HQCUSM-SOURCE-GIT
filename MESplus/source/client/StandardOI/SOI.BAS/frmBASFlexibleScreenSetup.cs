using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using System.Text.RegularExpressions;
using System.IO;

namespace SOI.BAS
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmBASFlexibleScreenSetup : SOIBaseForm03
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private string s_base_path;

        private enum COLS_SCREEN_LIST
        {
            SCREEN_ID = 0,
            DESCRIPTION
        }

        #endregion

        #region Constructor

        public frmBASFlexibleScreenSetup()
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
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // Initialize
            btnEdit.Visible = false;
            btnFromExcel.Visible = false;
            btnClear.Visible = false;
            btnPrint.Visible = false;
            s_base_path = MPGV.gsFlexibleScreenLocalPath;

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            try
            {
                // (Required) 
                if (bIsShown == false)
                {
                    // (Required) Init Focus Control
                    // MPCF.SetFocus(control);                

                    ViewScreenList(string.Empty);

                    // (Required) 
                    bIsShown = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Find TextBox Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFindScreenID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (ViewScreenList(string.Empty) == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Find Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewScreenList(string.Empty) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Refresh Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(txtFindScreenID);

                // View
                if (ViewScreenList(string.Empty) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        
        /// <summary>
        /// Create Screen ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {                
                // Validation
                if (CheckCondition() == false)
                {
                    return;
                }                
                
                // Create
                if (Update_Screen(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Update Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (CheckCondition() == false)
                {
                    return;
                }

                // Update
                if (Update_Screen(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Delete Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (CheckCondition() == false)
                {
                    return;
                }

                // Message
                // Are you sure you want to delete the data?
                if (MPCF.ShowMsgBox(MPCF.GetMessage(53), MessageBoxButtons.YesNo, MSG_LEVEL.NONE) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                // Delete
                if (Update_Screen(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Edit Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.Design.DesignerMain design = new FarPoint.Win.Spread.Design.DesignerMain(udcScreen.ScreenSpread);
                design.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// From Excel File To Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFromExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ofdFile.Filter = "Excel Files(*.xls;*.xlsx)|*.xls;*.xlsx";
                ofdFile.DefaultExt = "xls,xlsx";
                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    udcScreen.InitFlexibleScreen();
                    udcScreen.ScreenSpread.OpenExcel(ofdFile.FileName, FarPoint.Excel.ExcelOpenFlags.NoFlagsSet);                    
                    udcScreen.SetFlexibleScreenForExcel();

                    // Columns와 Rows 수 제한  
                    // 불필요한 column과 row는 수행시간에 영향을 주어 제한이 필요.
                    udcScreen.ScreenSpread.Sheets[0].Rows.Count = 10000;
                    udcScreen.ScreenSpread.Sheets[0].Columns.Count = 500;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Clear Flexible Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                udcScreen.InitFlexibleScreen();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Test Print
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (FlexibleScreenPrint() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Selected Tab Change Event
        /// Change Button Visible State
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabScreen_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                // General Tab
                if (tabScreen.SelectedTab == tabScreen.Tabs[0])
                {
                    btnEdit.Visible = false;
                    btnFromExcel.Visible = false;
                    btnClear.Visible = false;
                    btnPrint.Visible = false;
                }
                else
                {
                    btnEdit.Visible = true;
                    btnFromExcel.Visible = true;
                    btnClear.Visible = true;
                    btnPrint.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Screen List Cell Change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdScreenList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // 1. Check Data
                if (spdScreenList.Sheets[0].Rows.Count < 1)
                {
                    return;
                }

                // 2. Check Same Cell
                if (txtScreenID.Text == spdScreenList.Sheets[0].Cells[e.Row, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString())
                {
                    return;
                }

                // 3. View Screen Info
                if (ViewScreenInfo(spdScreenList.Sheets[0].Cells[e.Row, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString()) == false)
                {
                    return;
                }

                // 4. View Screen
                if (ViewScreen(e.Row) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Screen List
        /// </summary>
        /// <returns></returns>
        private bool ViewScreenList(string screenId)
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(spdScreenList);
                MPCF.FieldClear(pnlGeneral);
                udcScreen.InitFlexibleScreen();

                // 2. Call Service
                TRSNode in_node = new TRSNode("View_Screen_List_In");
                TRSNode out_node = new TRSNode("View_Screen_List_Out");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY_OPTION", MPGV.gsFactory);
                if (string.IsNullOrEmpty(txtFindScreenID.Text) == false)
                {
                    in_node.AddString("SCREEN_ID", txtFindScreenID.Text);
                }
                if (MPCF.CallService("BAS", "BAS_View_Screen_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // 3. Bind
                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;
                    bool bFound = false;

                    spdScreenList.Sheets[0].ClearSelection();

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdScreenList.Sheets[0].Rows.Count;
                        spdScreenList.Sheets[0].RowCount++;

                        spdScreenList.Sheets[0].Cells[iRow, (int)COLS_SCREEN_LIST.SCREEN_ID].Value = out_node.GetList(0)[i].GetString("SCREEN_ID");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COLS_SCREEN_LIST.DESCRIPTION].Value = out_node.GetList(0)[i].GetString("SCREEN_DESC");

                        // Screen ID를 지정하지 않은 경우
                        if (string.IsNullOrEmpty(screenId) == true 
                            && i == 0)
                        {
                            bFound = true;
                            spdScreenList.ActiveSheet.ActiveRowIndex = 0;
                            spdScreenList.Sheets[0].AddSelection(iRow, 0, 1, spdScreenList.Sheets[0].Columns.Count);
                        }
                        // Screen ID를 지정한 경우
                        else if (out_node.GetList(0)[i].GetString("SCREEN_ID") == screenId)
                        {
                            bFound = true;
                            spdScreenList.ActiveSheet.ActiveRowIndex = i;
                            spdScreenList.Sheets[0].AddSelection(i, 0, 1, spdScreenList.Sheets[0].Columns.Count);
                        }
                    }

                    // 지정한 Screen ID를 찾지 못한 경우
                    if (bFound == false)
                    {
                        spdScreenList.ActiveSheet.ActiveRowIndex = 0;
                        spdScreenList.Sheets[0].AddSelection(iRow, 0, 1, spdScreenList.Sheets[0].Columns.Count);
                    }

                    MPCF.FitColumnHeader(spdScreenList);
                }

                // 4. View
                if (spdScreenList.Sheets[0].Rows.Count > 0)
                {
                    if (ViewScreenInfo(spdScreenList.Sheets[0].Cells[spdScreenList.Sheets[0].GetSelection(0).Row, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString()) == false)
                    {
                        return false;
                    }

                    if (ViewScreen(spdScreenList.Sheets[0].GetSelection(0).Row) == false)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Validation
        /// Screen ID 생성 규칙에 준수하였는지 확인.
        /// </summary>
        /// <returns></returns>
        private bool CheckCondition()
        {
            try
            {
                // Not Empty Check
                if (MPCF.CheckValue(txtScreenID, false) == false)
                {
                    return false;
                }
                else
                {
                    // Generation ID Rule Check
                    Regex objAlphaPattern = new Regex(@"^[a-zA-Z0-9_.-]*$");
                    if (objAlphaPattern.IsMatch(txtScreenID.Text) == false)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(81) + @"^[a-zA-Z0-9_.-]*$", MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Screen 
        /// </summary>
        /// <param name="sScreenID"></param>
        /// <returns></returns>
        private bool ViewScreenInfo(string sScreenID)
        {
            TRSNode in_node = new TRSNode("View_Screen_Info_IN");
            TRSNode out_node = new TRSNode("View_Screen_Info_OUT");

            try
            {
                // Field Clear
                MPCF.FieldClear(pnlGeneral);

                // Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SCREEN_ID", sScreenID);
                if (MPCF.CallService("BAS", "BAS_View_Screen_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                txtScreenID.Text = out_node.GetString("SCREEN_ID");
                txtDescription.Text = out_node.GetString("SCREEN_DESC");
                tbvCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                tbvCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                tbvUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                tbvUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Screen 조회
        /// Local 파일에 있고 변경되지 않은 경우 Local 파일로 조회
        /// Local 파일에 없거나 변경된 경우 서비스 조회
        /// </summary>
        /// <returns></returns>
        private bool ViewScreen(int selectedRowIndex)
        {
            string sPathZip;
            string sPathXML;
            string sCreateTime;

            long iFileSize;
            DateTime create_time;
            TRSNode in_node = new TRSNode("View_Screen_IN");
            TRSNode out_node = new TRSNode("View_Screen_OUT");

            try
            {
                // Field Clear
                MPCF.FieldClear(pnlScreen);

                // 1. Screen 정보가 없는 경우 종료
                if (spdScreenList.Sheets[0].Rows.Count < 1)
                {
                    return false;
                }

                // 2. 선택된 Screen이 없는 경우 종료
                if(selectedRowIndex < 0)
                {
                    return false;
                }

                // 3. 선택된 Screen ID로 파일 경로 설정
                sPathZip = s_base_path + spdScreenList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString() + ".gzip";

                // 4. 파일이 없는 경우 생성
                if (Directory.Exists(s_base_path) == false)
                {
                    Directory.CreateDirectory(s_base_path);
                }

                // 5. File 정보 가져오기
                FileInfo fi = new FileInfo(sPathZip);

                // 6. Server File 정보와 비교
                // 파일이 없던 경우 초기값으로 비교하여 강제 업데이트
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SCREEN_ID", spdScreenList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString());
                if (fi.Exists == false)
                {
                    in_node.AddString("CREATION_TIME", "19001231000000");
                    in_node.AddInt("FILE_SIZE", 0);
                }
                else
                {
                    create_time = fi.CreationTime;
                    sCreateTime = MPCF.ToStandardTime(create_time, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    iFileSize = fi.Length;
                    in_node.AddString("CREATION_TIME", sCreateTime);
                    in_node.AddInt("FILE_SIZE", iFileSize);
                }
                if (MPCF.CallService("BAS", "BAS_Check_Screen", in_node, ref out_node) == false)
                {
                    return false;
                }
                if (out_node.GetChar("NEED_UPDATE") == 'Y')
                {
                    // File Update
                    UpdateScreenXML(spdScreenList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString(), out_node);
                }

                // 7. XML 파일 경로 설정
                sPathXML = s_base_path + spdScreenList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString() + ".xml";

                // 8. Clear
                //if (spdSpread.Sheets.Count > 0)
                //{
                //    spdSpread.Sheets[0].Rows.Clear();
                //}
                udcScreen.InitFlexibleScreen();

                // 9. Open
                //spdSpread.Open(sPathXML);
                udcScreen.ScreenSpread.Open(sPathXML);

                // 10. Set Theme
                udcScreen.SetOITheme();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 다운로드한 파일을 Local에 저장
        /// </summary>
        /// <param name="out_node"></param>
        /// <returns></returns>
        private bool UpdateScreenXML(string screenID, TRSNode out_node)
        {
            try
            {
                // 1. File Path 설정
                string sPath = s_base_path + screenID;

                // 2. gzip 파일 생성.
                FileStream fs = File.Open(sPath + ".gzip", FileMode.Create);

                // 3. 다운로드한 파일 저장
                BinaryWriter bw = new BinaryWriter(fs);                
                fs.Flush();
                byte[] buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_2);
                bw.Write(buffer);
                bw.Close();
                fs.Close();

                // 4. 생성 날짜 수정.
                DateTime dt_create_time = MPCF.ToDate(out_node.GetString("CREATION_TIME"));
                File.SetCreationTime(sPath + ".gzip", dt_create_time);

                // 5. XML 파일 생성
                MPCF.ZipDecompress(sPath);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Update Screen
        /// </summary>
        /// <param name="c_step"></param>
        /// <returns></returns>
        private bool Update_Screen(char c_step)
        {
            TRSNode in_node = new TRSNode("SCREEN_IN");
            TRSNode out_node = new TRSNode("SCREEN_OUT");

            string sPath = string.Empty;

            try
            {
                // 1. Local 경로에 파일로 저장.
                sPath = s_base_path + txtScreenID.Text;
                if (Directory.Exists(s_base_path) == false)
                {
                    Directory.CreateDirectory(s_base_path);
                }

                //spdSpread.Save(sPath + ".xml", false);
                udcScreen.ScreenSpread.Save(sPath + ".xml", false);

                // 2. 저장된 파일과 동일한 gzip 압축파일 생성
                if (MPCF.ZipCompress(sPath) == false)
                {
                    return false;
                }

                // 3. In Node Setup
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("SCREEN_ID", MPCF.Trim(txtScreenID.Text));
                in_node.AddString("SCREEN_DESC", MPCF.Trim(txtDescription.Text));                

                // 4. Add Screen File
                FileInfo finfo = new FileInfo(sPath + ".gzip");
                if (finfo.Exists == true)
                {
                    BinaryReader br = new BinaryReader(finfo.OpenRead());
                    byte[] file_buffer = br.ReadBytes((int)finfo.Length);

                    // Add Blob to InNode
                    in_node.AddBlob(MPGC.MP_BIN_DATA_2, file_buffer);

                    br.Close();
                }
                else
                {
                    // Failed to load resource.  Check if resource file exists.
                    MPCF.ShowMessage(MPCF.GetMessage(69), MSG_LEVEL.ERROR, false);
                    return false;
                }

                // 5. Call Service
                if (MPCF.CallService("BAS", "BAS_Update_Screen", in_node, ref out_node) == false)
                {
                    return false;
                }

                // 6. Re-Search
                if (c_step == MPGC.MP_STEP_DELETE)
                {
                    // View Screen List 
                    if (ViewScreenList(string.Empty) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    // View Screen List
                    if (ViewScreenList(MPCF.Trim(txtScreenID.Text)) == false)
                    {
                        return false;
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
        /// Flexible Screen 디자인 화면을 프린트 합니다.
        /// 프린트 테스트 용도로 사용됩니다.
        /// </summary>
        /// <returns></returns>
        private bool FlexibleScreenPrint()
        {
            try
            {
                // Label Print 합니다.
                MPCF.PrintFlexibleScreen(this, base.printOption, udcScreen, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
