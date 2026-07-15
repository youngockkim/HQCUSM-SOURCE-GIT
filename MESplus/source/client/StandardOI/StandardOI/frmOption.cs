#if _H101
using SOI.MsgHandlerH101;
#endif
#if _Http
using SOI.MsgHandlerHTTP;
#endif
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.CliFrx.CliFrxPopup;
using SOI.CliFrx;
using System.Diagnostics;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx;
using SOI.OIFrx.SOIThemes;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;
using BOI.OIFrx;
using Miracom.TRSCore;
using SOI.HanwhaQcell.USModule;

namespace StandardOI
{
    public partial class frmOption : frmPopupBase
    {
        #region Property

        private bool b_load_flag = false;
        protected bool b_restart_flag;
        public bool bFromLoginFlag = false;

        /// <summary>
        /// 팝업 화면의 그림자를 처리합니다.
        /// 팝업 화면 로드 시 디자인 처리가 완료되면 화면을 표시할 수 있도록 처리합니다.
        /// </summary>
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        #endregion

        #region Constructor

        public frmOption()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Option 창이 로드 될 때 발생합니다.
        /// 로그인 이전과 로그인 이후에 로드될 때 동작이 일부분 다릅니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOption_Load(object sender, EventArgs e)
        {
            int i;
            UltraGridRow ugrRow;

            try
            {
                // Client Version 
                lblProgramVersion.Text = MPGV.gsClientVersion;

                // Restart가 아닌 경우
                if (b_restart_flag == false)
                {
                    // 레지스트리에 등록된 Option 정보를 호출
                    if (MPIF.gInit.GetClientOptions() == false)
                    {
                        this.Close();
                    }
                }

                // Option Grid 초기화
                gridOption.InitDataSource();

#if _H101

                // Added fo QCELLS
                if (MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "H101SiteID0", "")) == "")
                {
                    // Site ID
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101SiteID0", "MPP1");

                    // Server Address
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101RemoteAddress0", "10.60.110.12;10.60.110.13");

                    // Statdion Mode
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode0", "INTER");

                    // Factory
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "Factory", "USGAM1");
                    txtFactory.Text = MPCF.GetRegSetting(Application.ProductName, "Option", "Factory", "");
                    MPGV.gsFactory = txtFactory.Text;

                    MPCF.SaveRegSetting(Application.ProductName, "Option", "Theme", "Dark");
                    MPGV.gsThemeName = "Dark";
                    
                }


                // 레지스트리에 등록된 주소정보를 Option Grid에 추가
                for (i = 0; i < 20; i++)
                {
                    if (MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "H101SiteID" + i.ToString(), "")) != "")
                    {
                        ugrRow = gridOption.DisplayLayout.Bands[0].AddNew();
                        ugrRow.Cells[0].Value = (i + 1).ToString();
                        ugrRow.Cells[1].Value = MPCF.GetRegSetting(Application.ProductName, "Option", "H101SiteID" + i.ToString(), "");
                        ugrRow.Cells[2].Value = MPCF.GetRegSetting(Application.ProductName, "Option", "H101RemoteAddress" + i.ToString(), "");
                        ugrRow.Cells[3].Value = MPCF.GetRegSetting(Application.ProductName, "Option", "H101StationMode" + i.ToString(), "");
                    }
                }

                // Site ID TextBox
                if (MPGV.gsSiteID != null)
                {
                    txtSiteID.Text = MPGV.gsSiteID;
                }
                else
                {
                    if (gridOption.Rows.Count > 0)
                    {
                        txtSiteID.Text = gridOption.Rows[0].Cells[1].ToString();
                    }
                }

                // Station Mode ComboBox
                cboStationMode.SelectedIndex = 0;
                if (MPGV.gsStationMode != null)
                {
                    if (MPGV.gsStationMode == "INTER")
                    {
                        cboStationMode.SelectedIndex = 1;
                    }
                }
                else
                {
                    if (gridOption.Rows.Count > 0)
                    {
                        if (gridOption.Rows[0].Cells[3].ToString() == "INTER")
                        {
                            cboStationMode.SelectedIndex = 1;
                        }
                    }
                }
#endif
#if _Http
                // Option Grid에서 Site, Station Mode Hidden
                gridOption.DisplayLayout.Bands[0].Columns["site"].Hidden = true;
                gridOption.DisplayLayout.Bands[0].Columns["stsMode"].Hidden = true;

                // 레지스트리에 등록된 주소정보를 Option Grid에 추가
                for (i = 0; i < 20; i++)
                {
                    if (MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress" + i.ToString(), "")) != "")
                    {
                        ugrRow = gridOption.DisplayLayout.Bands[0].AddNew();
                        ugrRow.Cells["seq"].Value = (i+1).ToString(); 
                        ugrRow.Cells["address"].Value = MPCF.GetRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress" + i.ToString(), "");
                    }
                }

                // SiteID TextBox, Station Mode ComboBox Hidden
                tlpSiteAndStsMode.Visible = false;
#endif
                // Address
                if (MPGV.gsRemoteAddress != null)
                {
                    txtServerAddress.Text = MPGV.gsRemoteAddress;
                }
                else
                {
                    if (gridOption.Rows.Count > 0)
                    {
                        txtServerAddress.Text = gridOption.Rows[0].Cells[2].ToString();
                    }
                }

                // Factory
                if (MPGV.gsFactory != null)
                {
                    txtFactory.Text = MPGV.gsFactory;
                }

                // Theme
                MPCF.InitThemeSet();
                cboTheme.Items.Clear();
                for (int iTheme = 0; iTheme < MPGV.glThemeSet.Count; iTheme++)
                {
                    cboTheme.Items.Add(MPGV.glThemeSet[iTheme]);
                    if (MPGV.gsThemeName == MPGV.glThemeSet[iTheme])
                    {
                        cboTheme.SelectedIndex = iTheme;
                    }
                }

                // Time Out
                txtTimeOut.Text = MPGV.giTimeOut.ToString();

                // Language
                cboLanguage.SelectedIndex = MPCF.ToInt(MPGV.gcLanguage) - 1;

                // Auto logout
                if (MPGV.giLogOutTime == 0)
                {
                    txtAutoLogout.Text = "";
                }
                else
                {
                    txtAutoLogout.Text = MPGV.giLogOutTime.ToString();
                }

                // Version Check
                if (MPGV.giVersionCheckTime == 0)
                {
                    txtVersionCheck.Text = "";
                }
                else
                {
                    txtVersionCheck.Text = MPGV.giVersionCheckTime.ToString();
                }

                // Menu Position
                if (MPGV.gbMenuPositionLeft == true)
                {
                    rdbMenuPosition.CheckedIndex = 0;
                }
                else
                {
                    rdbMenuPosition.CheckedIndex = 1;
                }

                // Show Alarm Popup
                if (MPGV.gbShowAlarmPopup == true)
                {
                    rdbAlarmPopup.CheckedIndex = 0;
                }
                else
                {
                    rdbAlarmPopup.CheckedIndex = 1;
                }

                // Touch Keyboard 
                if (MPGV.gbTouchKeyboardUse == true)
                {
                    rdbTouchKeyboard.CheckedIndex = 0;
                }
                else
                {
                    rdbTouchKeyboard.CheckedIndex = 1;
                }

                if (MPGV.gbErrorSound == true)
                {
                    rdbErrorSound.CheckedIndex = 0;
                }
                else
                {
                    rdbErrorSound.CheckedIndex = 1;
                }

                txtPCID.Text = MPCF.GetRegSetting(Application.ProductName, "Option", "PCId");

                string tune_flag = MPCF.GetRegSetting(Application.ProductName, "Option", "TuneFlag");

                if (tune_flag == "1")
                {
                    rdoTune.CheckedIndex = 0;
                }
                else
                {
                    rdoTune.CheckedIndex = 1;
                }

                // 다국어 변환
                // Factory 변환
                MPCF.ConvertCaption(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage("frmOption_Load \n" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 화면이 Activate 될 때 발생합니다.
        /// Focus 관련 로직이 포함되어 있습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOption_Activated(object sender, EventArgs e)
        {
            // 최초 1회만 실행
            if (b_load_flag == false)
            {
                MPCF.SetFocus(txtServerAddress);

                // 리스트에 데이터가 있는 경우
                if (gridOption.Rows.Count > 0)
                {
                    // 첫번째 아이템 선택
                    gridOption.Rows[0].Selected = true;
                }

                b_load_flag = true;
            }
        }

        /// <summary>
        /// OK 버튼 클릭 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            int i;
            int j;

            try
            {
                MPGV.gbReloginFlag = false;
                MPGV.gbReLoadLanguageFlag = false;

                // Validation: Server Address
                if (MPCF.CheckValue(txtServerAddress, true) == false)
                {
                    return;
                }
#if _H101
                // Validation: Site ID
                if (MPCF.CheckValue(txtSiteID, true) == false)
                {
                    return;
                }

                // Validation: Station Mode
                if (MPCF.CheckValue(cboStationMode, true) == false)
                {
                    return;
                }
#endif
                // List에 Add
                if (AddToGrid() == false)
                {
                    return;
                }

                // 메인화면에서 Option을 실행한 경우
                if (bFromLoginFlag == false)
                {
#if _H101
                    // 아래 값들이 변경된 경우 재시작
                    if (MPGV.gsRemoteAddress != txtServerAddress.Text
                        || MPGV.gsSiteID != txtSiteID.Text
                        || (MPGV.gsStationMode != null && cboStationMode.Text.StartsWith(MPGV.gsStationMode) == false)
                        || MPGV.gsFactory != txtFactory.Text
                        || (MPGV.gsThemeName != null && cboTheme.Text.StartsWith(MPGV.gsThemeName) == false)
                        || MPGV.gcLanguage != MPCF.ToChar(cboLanguage.SelectedIndex + 1)
                        || MPGV.gbMenuPositionLeft != (rdbMenuPosition.CheckedIndex == 0 ? true : false))
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(3), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }

                        MPGV.gbReloginFlag = true;
                    }
#endif
#if _Http
                    // 아래 값들이 변경된 경우 재시작
                    if (MPGV.gsRemoteAddress != txtServerAddress.Text
                        || MPGV.gsFactory != txtFactory.Text
                        || (MPGV.gsThemeName != null && cboTheme.Text.StartsWith(MPGV.gsThemeName) == false)
                        || MPGV.gcLanguage != MPCF.ToChar(cboLanguage.SelectedIndex + 1)
                        || MPGV.gbMenuPositionLeft != (rdbMenuPosition.CheckedIndex == 0 ? true : false))
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(3), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }

                        MPGV.gbReloginFlag = true;
                    }
#endif
                }

                // Language Reload 여부 
                if (MPGV.gcLanguage != MPCF.ToChar(cboLanguage.SelectedIndex + 1))
                {
                    MPGV.gbReLoadLanguageFlag = true;
                }

                #region 레지스트리 저장

#if _H101
                // Server Address
                MPCF.SaveRegSetting(Application.ProductName, "Option", "H101RemoteAddress", txtServerAddress.Text);
                MPGV.gsRemoteAddress = txtServerAddress.Text;

                // Site ID
                MPCF.SaveRegSetting(Application.ProductName, "Option", "H101SiteID", txtSiteID.Text);
                MPGV.gsSiteID = txtSiteID.Text;

                // Statdion Mode
                if (cboStationMode.SelectedIndex == 1)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode", "INTER");
                    MPGV.gsStationMode = "INTER";
                }
                else
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode", "Inner");
                    MPGV.gsStationMode = "Inner";
                }

                // Option Grid List (입력된 정보개수 만큼)
                for (i = 0; i < gridOption.Rows.Count; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101SiteID" + i.ToString(), gridOption.Rows[i].Cells[1].Value.ToString());
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101RemoteAddress" + i.ToString(), gridOption.Rows[i].Cells[2].Value.ToString());
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101StationMode" + i.ToString(), gridOption.Rows[i].Cells[3].Value.ToString());
                }
                // Option Grid List (나머지 20개까지는 공백)
                for (j = i; j < 20; j++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101SiteID" + j.ToString(), " ");
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101RemoteAddress" + j.ToString(), " ");
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101StationMode" + i.ToString(), " ");
                }
                MPGV.gsRemoteAddress = txtServerAddress.Text;
#endif
#if _Http
                // Server Address
                MPCF.SaveRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress", txtServerAddress.Text);
                MPGV.gsRemoteAddress = txtServerAddress.Text;

                // Option Grid List (입력된 정보개수 만큼)
                for (i = 0; i < gridOption.Rows.Count; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress" + i.ToString(), gridOption.Rows[i].Cells[2].Value.ToString());
                }
                // Option Grid List (나머지 20개까지는 공백)
                for (j = i; j < 20; j++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress" + j.ToString(), " ");
                }
                MPGV.gsRemoteAddress = txtServerAddress.Text;
#endif

                // Factory
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Factory", txtFactory.Text);
                MPGV.gsFactory = txtFactory.Text;

                // Theme
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Theme", cboTheme.Text);
                MPGV.gsThemeName = cboTheme.Text;
                MPCF.LoadTheme();

                // Time Out
                // 입력하지 않은 경우 기본 20분
                if (txtTimeOut.Text == "")
                {
                    txtTimeOut.Text = "20";
                }
                // 숫자가 아닌경우 기본 20분
                else if (MPCF.CheckNumeric(txtTimeOut.Text) == false)
                {
                    txtTimeOut.Text = "20";
                }
                // 값이 있는 경우
                if (MPCF.CheckNumeric(txtTimeOut.Text))
                {
                    // 10분이하, 300분이상인 경우 기본 20분
                    if (MPCF.ToInt(txtTimeOut.Text) == 0 || MPCF.ToInt(txtTimeOut.Text) < 10 || MPCF.ToInt(txtTimeOut.Text) > 300)
                    {
                        txtTimeOut.Text = "20";
                    }

                    MPCF.SaveRegSetting(Application.ProductName, "Option", "TimeOut", txtTimeOut.Text);
                    MPGV.giTimeOut = MPCF.ToInt(txtTimeOut.Text);
                    MPIF.gInit.setTTL(MPGV.giTimeOut);
                }

                // Language
                MPGV.gcLanguage = MPCF.ToChar(cboLanguage.SelectedIndex + 1);
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Language", MPGV.gcLanguage.ToString());

                // Logout Time
                // 입력하지 않은 경우 0(실행안함)
                if (txtAutoLogout.Text == "")
                {
                    MPGV.giLogOutTime = 0;
                }
                else if (MPCF.ToInt(txtAutoLogout.Text) == 0)
                {
                    MPGV.giLogOutTime = 0;
                }
                // 숫자가 아니거나 5분보다 작으면 5분
                else if (MPCF.ToInt(txtAutoLogout.Text) <= 5 && MPCF.ToInt(txtAutoLogout.Text) != 0)
                {
                    MPGV.giLogOutTime = 5;
                }
                else if (MPCF.ToInt(txtAutoLogout.Text) > 5)
                {
                    MPGV.giLogOutTime = MPCF.ToInt(txtAutoLogout.Text);
                }
                MPCF.SaveRegSetting(Application.ProductName, "Option", "LogOutTime", MPGV.giLogOutTime.ToString());

                // Version Check
                // 입력하지 않은 경우 0(실행안함)
                if (txtVersionCheck.Text == "")
                {
                    MPGV.giVersionCheckTime = 0;
                }
                else if (MPCF.CheckNumeric(txtVersionCheck.Text))
                {
                    MPGV.giVersionCheckTime = MPCF.ToInt(txtVersionCheck.Text);
                }
                MPCF.SaveRegSetting(Application.ProductName, "Option", "VersionCheckTime", MPGV.giVersionCheckTime.ToString());

                // Menu Position
                if (rdbMenuPosition.CheckedIndex == 0)
                {
                    MPGV.gbMenuPositionLeft = true;
                }
                else
                {
                    MPGV.gbMenuPositionLeft = false;
                }
                MPCF.SaveRegSetting(Application.ProductName, "Option", "MenuPosition", rdbMenuPosition.CheckedIndex.ToString());

                // Show Alarm Popup
                if (rdbAlarmPopup.CheckedIndex == 0)
                {
                    MPGV.gbShowAlarmPopup = true;
                }
                else
                {
                    MPGV.gbShowAlarmPopup = false;
                }
                MPCF.SaveRegSetting(Application.ProductName, "Option", "ShowAlarmPopup", rdbAlarmPopup.CheckedIndex.ToString());

                // Touch Keyboard
                if (rdbTouchKeyboard.CheckedIndex == 0)
                {
                    MPGV.gbTouchKeyboardUse = true;
                }
                else
                {
                    MPGV.gbTouchKeyboardUse = false;
                }
                MPCF.SaveRegSetting(Application.ProductName, "Option", "TouchKeyboard", rdbTouchKeyboard.CheckedIndex.ToString());

                // Error Sound
                if (rdbErrorSound.CheckedIndex == 0)
                {
                    MPGV.gbErrorSound = true;
                }
                else
                {
                    MPGV.gbErrorSound = false;
                }
                MPCF.SaveRegSetting(Application.ProductName, "Option", "ErrorSound", rdbErrorSound.CheckedIndex.ToString());

                //신성솔라 추가

                if (rdoTune.CheckedIndex == 0)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "TuneFlag", "1");
                    HQGV.gbTunePublish = true;
                }
                else
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "TuneFlag", "2");
                    HQGV.gbTunePublish = false;
                }

                MPCF.SaveRegSetting(Application.ProductName, "Option", "PCId", MPCF.Trim(txtPCID.Text));
                HQGV.gsPCId = MPCF.Trim(txtPCID.Text);

                #endregion

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        /// <summary>
        /// Close 버튼 클릭 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Server Address에서 Enter Key 입력 시 실행됩니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtServerAddress_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
#if _H101
                    if (MPCF.CheckValue(txtSiteID, true) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cboStationMode, true) == false)
                    {
                        return;
                    }
#endif
                    AddToGrid();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        /// <summary>
        /// Site ID에서 Enter Key 입력 시 실행됩니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSiteID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
#if _H101
                    if (MPCF.CheckValue(txtServerAddress, true) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cboStationMode, true) == false)
                    {
                        return;
                    }
#endif
                    AddToGrid();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        /// <summary>
        /// Add 버튼 클릭 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToGrid();
        }

        /// <summary>
        /// Delete 버튼 클릭 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            RemoveFromGrid();
        }

        /// <summary>
        /// Grid에서 선택된 Row가 변경될 때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridOption_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            try
            {
                // 데이터 소스가 없거나 데이터가 없는 경우
                if (gridOption.Rows.Count == 0)
                {
                    return;
                }

                // 선택된 Row가 없는 경우
                if (gridOption.Selected.Rows.Count < 1)
                {
                    return;
                }

                // Address
                txtServerAddress.Text = gridOption.Selected.Rows[0].Cells[2].Text;

#if _H101
                // Site ID
                txtSiteID.Text = gridOption.Selected.Rows[0].Cells[1].Text;

                // Station Mode
                if (gridOption.Selected.Rows[0].Cells[3].Text == "INTER")
                {
                    cboStationMode.SelectedIndex = 1;
                }
                else
                {
                    cboStationMode.SelectedIndex = 0;
                }
#endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// TextBox에 입력된 정보를 Grid에 추가합니다.
        /// </summary>
        private bool AddToGrid()
        {
#if _H101
            try
            {
                // 동일한 데이터 제거
                for (int i = 0; i < gridOption.Rows.Count; i++)
                {
                    if (gridOption.Rows[i].Cells[1].Value.ToString() == txtSiteID.Text)
                    {
                        if (gridOption.Rows[i].Cells[2].Value.ToString() == txtServerAddress.Text)
                        {
                            gridOption.Rows[i].Delete(false);
                            break;
                        }
                    }
                }

                // 최대 데이터 제거
                if (gridOption.Rows.Count == 20)
                {
                    gridOption.Rows[19].Delete(false);
                }

                // 신규 데이터 추가
                UltraGridRow ugr = gridOption.DisplayLayout.Bands[0].AddNew();
                ugr.Cells[1].Value = txtSiteID.Text;
                ugr.Cells[2].Value = txtServerAddress.Text;
                ugr.Cells[3].Value = cboStationMode.SelectedItem.DisplayText;
                ugr.ParentCollection.Move(ugr, 0);

                // Sequence 정렬
                for (int i = 0; i < gridOption.Rows.Count; i++)
                {
                    gridOption.Rows[i].Cells[0].Value = ((int)(i + 1)).ToString();
                }

                // 재선택
                gridOption.Rows[0].Selected = true;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
#endif
#if _Http
            try
            {
                // 동일한 데이터 제거
                for (int i = 0; i < gridOption.Rows.Count; i++)
                {
                    if (gridOption.Rows[i].Cells[2].Value.ToString() == txtServerAddress.Text)
                    {
                        gridOption.Rows[i].Delete(false);
                        break;
                    }
                }

                // 최대 데이터 제거
                if (gridOption.Rows.Count == 20)
                {
                    gridOption.Rows[19].Delete();
                }

                // 신규 데이터 추가
                UltraGridRow ugr = gridOption.DisplayLayout.Bands[0].AddNew();
                ugr.Cells[2].Value = txtServerAddress.Text;
                ugr.ParentCollection.Move(ugr, 0);

                // Sequence 정렬
                for (int i = 0; i < gridOption.Rows.Count; i++)
                {
                    gridOption.Rows[i].Cells[0].Value = ((int)(i + 1)).ToString();
                }

                // 재선택
                gridOption.Rows[0].Selected = true;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
#endif
        }

        /// <summary>
        /// Grid에서 Address를 제거합니다.
        /// </summary>
        private void RemoveFromGrid()
        {
            //int i;
            int i_sel;

            // 선택된 Row가 없는 경우 리턴
            if (gridOption.Selected.Rows.Count < 1)
            {
                return;
            }

            // Selected Row Index 추출
            i_sel = gridOption.Selected.Rows[0].Index;

            // Selected Row 제거
            gridOption.Rows[i_sel].Delete(false);

            // Clear Field
            txtSiteID.Text = "";
            txtServerAddress.Text = "";
            cboStationMode.SelectedIndex = -1;

            // Sequence 재정렬
            for (int i = 0; i < gridOption.Rows.Count; i++)
            {
                gridOption.Rows[i].Cells[0].Value = ((int)(i + 1)).ToString();
            }

            // 재선택
            if (i_sel < gridOption.Rows.Count)
            {
                gridOption.Rows[i_sel].Selected = true;
            }
            else
            {
                i_sel = gridOption.Rows.Count - 1;
                if (i_sel >= 0)
                {
                    gridOption.Rows[i_sel].Selected = true;
                }
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                //if (MPIF.gInit.InitMsgHandler() == false)
                //{
                //    MPCF.ShowMsgBox(MPCF.GetMessage(104));
                //    this.DialogResult = System.Windows.Forms.DialogResult.None;
                //    return;
                //}

                //// CodeView Service
                //TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                //MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                
                //// Display and Header Text Setup
                //string[] display = new string[] { "RES_ID", "RES_DESC" };
                //string[] header = new string[] { "Res ID", "Res Desc" };

                //// Show CodeView and Get Return
                //cdvResID.Text = cdvResID.Show(cdvResID, "View Resource List", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "Res ID");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

		private void cdvResID_ValueChanged(object sender, EventArgs e)
		{
            MPCF.SaveRegSetting(Application.ProductName, "Option", "PCId", MPCF.Trim(txtPCID.Text));
		}
    }
}