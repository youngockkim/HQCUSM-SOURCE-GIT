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
    public partial class frmBASViewFlexibleScreen : SOIBaseForm03
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COLS_SCREEN_LIST
        {
            SCREEN_ID = 0,
            SCREEN_DESCRIPTION
        }

        #endregion

        #region Constructor

        public frmBASViewFlexibleScreen()
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
            // (Required) 
            if (bIsShown == false)
            {
                ViewScreenList(string.Empty);

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Find Screen ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFindScreenID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (ViewScreenList(txtFindScreenID.Text) == false)
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
        /// Find Screen ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewScreenList(txtFindScreenID.Text) == false)
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
        /// Refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
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
        /// Print Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // Label Print 합니다.
                MPCF.PrintFlexibleScreen(this, base.printOption, udcScreen, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Spread Cell Click
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

        /// <summary>
        /// View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Check Data
                if (spdScreenList.Sheets[0].Rows.Count < 1)
                {
                    return;
                }

                if (ViewScreenInfo(spdScreenList.Sheets[0].Cells[spdScreenList.Sheets[0].GetSelection(0).Row, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString()) == false)
                {
                    return;
                }

                if (ViewScreen(spdScreenList.Sheets[0].GetSelection(0).Row) == false)
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
        /// <param name="screenId"></param>
        /// <returns></returns>
        private bool ViewScreenList(string screenId)
        {
            TRSNode in_node = new TRSNode("VIEW_SCREEN_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SCREEN_LIST_OUT");

            try
            {
                // Field Clear
                MPCF.FieldClear(this);
                udcScreen.InitFlexibleScreen();

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY_OPTION", MPGV.gsFactory);
                if (string.IsNullOrEmpty(screenId) == false)
                {
                    in_node.AddString("SCREEN_ID", screenId);
                }
                if (MPCF.CallService("BAS", "BAS_View_Screen_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                if (out_node.GetList(0) != null)
                {
                    // Clear
                    spdScreenList.Sheets[0].ClearSelection();

                    int iRow = 0;
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdScreenList.Sheets[0].Rows.Count;
                        spdScreenList.Sheets[0].RowCount++;

                        spdScreenList.Sheets[0].Cells[iRow, (int)COLS_SCREEN_LIST.SCREEN_ID].Value = out_node.GetList(0)[i].GetString("SCREEN_ID");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COLS_SCREEN_LIST.SCREEN_DESCRIPTION].Value = out_node.GetList(0)[i].GetString("SCREEN_DESC");                            
                    }

                    // Selection
                    spdScreenList.ActiveSheet.ActiveRowIndex = 0;
                    spdScreenList.Sheets[0].AddSelection(0, 0, 1, spdScreenList.Sheets[0].Columns.Count);
                }
                
                // Fit
                MPCF.FitColumnHeader(spdScreenList);

                // Re-bind
                if (string.IsNullOrEmpty(screenId) == false)
                {
                    txtFindScreenID.Text = screenId;
                    txtFindScreenID.SelectAll();
                    txtFindScreenID.Focus();
                }

                // View
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
                MPCF.FieldClear(grpScreenInfo);
                MPCF.FieldClear(grpDesign);

                // Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SCREEN_ID", sScreenID);
                if (MPCF.CallService("BAS", "BAS_View_Screen_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                txtScreenId.Text = out_node.GetString("SCREEN_ID");
                txtScreenDesc.Text = out_node.GetString("SCREEN_DESC");
                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text =  out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

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
                MPCF.FieldClear(grpDesign);

                // 1. Screen 정보가 없는 경우 종료
                if (spdScreenList.Sheets[0].Rows.Count < 1)
                {
                    return false;
                }

                // 2. 선택된 Screen이 없는 경우 종료
                if (selectedRowIndex < 0)
                {
                    return false;
                }

                // 3. 선택된 Screen ID로 파일 경로 설정
                sPathZip = MPGV.gsFlexibleScreenLocalPath + spdScreenList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString() + ".gzip";

                // 4. 파일이 없는 경우 생성
                if (Directory.Exists(MPGV.gsFlexibleScreenLocalPath) == false)
                {
                    Directory.CreateDirectory(MPGV.gsFlexibleScreenLocalPath);
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
                sPathXML = MPGV.gsFlexibleScreenLocalPath + spdScreenList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString() + ".xml";

                // 8. Init
                udcScreen.InitFlexibleScreen();

                // 9. Open
                //spdSpread.Open(sPathXML);
                udcScreen.ScreenSpread.Open(sPathXML);

                // 10. Set Theme
                udcScreen.SetOITheme();

                // 11. Lock
                udcScreen.ScreenLock = true;

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
                string sPath = MPGV.gsFlexibleScreenLocalPath + screenID;

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

        #endregion
    }
}
