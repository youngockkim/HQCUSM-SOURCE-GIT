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
using SOI.CliFrx;
using System.Diagnostics;
using SOI.OIFrx;
using SOI.OIFrx.SOIThemes;

namespace StandardOI
{
    public partial class frmLogin : Form
    {
        #region Property

        public bool bIsOpened = false;

        /// <summary>
        /// Form 내에 있는 모든 컨트롤들의 Rendering을 완료한 이후에 Form을 표시한다.
        /// Load Event 이후에 발생하므로 Focus 등의 이벤트들은 Activated 이벤트에 할당해야 한다.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        #endregion

        #region Constructor

        public frmLogin()
        {
            InitializeComponent();
        }

        #endregion
        #region Event Handler


        /// <summary>
        /// Login 화면 Load 시 발생합니다.
        /// 기본 변수를 설정합니다.
        /// 자동 실행이 필요한 경우 자동 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Load(object sender, System.EventArgs e)
        {
            try
            {
                // Global 변수 설정
                MPGV.gsHelpURL = "http://localhost/MESHelp/";
                MPGV.gsDefaultHelpURL = "Manual_1";
                MPGV.gsDownloadFileList = "SOIDownloadFile.xml";
                MPGV.gsUpgradeFile = "SOIUpgradeFtp.exe"; // 자동설정됨.

                // *** 배포시 반드시 수정 필요 ***
                MPGV.gsClientVersion = "MESOI_V2.0.0.326";

                // Command Line 읽기
                string[] lisCmdArgs = Environment.GetCommandLineArgs();
                bool b_cmd_logon = false;

                // 최초 1회만 실행
                if (bIsOpened == false)
                {
                    // Command Line이 있는 경우
                    if (lisCmdArgs.Length > 1)
                    {
                        List<string> lisArgs = new List<string>(lisCmdArgs);
                        foreach (string arg in lisArgs)
                        {
                            if (arg.Contains("-factory") == true)
                            {
                                MPGV.gsFactory = arg.Substring(arg.IndexOf(":") + 1);
                            }
                            else if (arg.Contains("-userId") == true)
                            {
                                MPGV.gsUserID = arg.Substring(arg.IndexOf(":") + 1);
                            }
                            else if (arg.Contains("-password") == true)
                            {
                                txtPassword.Text = arg.Substring(arg.IndexOf(":") + 1);
                            }
                            else if (arg.Contains("-siteId") == true)
                            {
                                MPGV.gsSiteID = arg.Substring(arg.IndexOf(":") + 1);
                            }
                            else if (arg.Contains("-serverAddress") == true)
                            {
                                MPGV.gsRemoteAddress = arg.Substring(arg.IndexOf(":") + 1);
                            }
                            else if (arg.Contains("-stationMode") == true)
                            {
                                // Inner or INTER
                                MPGV.gsStationMode = arg.Substring(arg.IndexOf(":") + 1);
                            }
                            else if (arg.Contains("-rvService") == true)
                            {
                                MPGV.gsRvService = arg.Substring(arg.IndexOf(":") + 1);
                            }
                            else if (arg.Contains("-rvNetwork") == true)
                            {
                                MPGV.gsRvNetwork = arg.Substring(arg.IndexOf(":") + 1);
                            }
                            else if (arg.Contains("-bgColor") == true)
                            {
                                List<string> lisColor = new List<string>(Enum.GetNames(typeof(System.Drawing.KnownColor)));
                                string sColorName = arg.Substring(arg.IndexOf(":") + 1);
                                if (lisColor.Contains(sColorName) == true)
                                    MPGV.gTitleColor = System.Drawing.Color.FromName(sColorName);
                            }
                        }

                        b_cmd_logon = true;
                    }
                }

                // Caption 변환
                MPCF.ConvertCaption(this);

                // Theme 변환
                LoadControlThemeForLogin();

                // 저장된 Global 값 할당
                txtUserID.Text = MPGV.gsUserID;
                if (txtPassword.Text == "")
                {
                    txtPassword.Focus();
                }
                if (txtUserID.Text == "")
                {
                    txtUserID.Focus();
                }
                if (MPGV.gbUseSmallLetter == true)
                {
                    txtUserID.CharacterCasing = CharacterCasing.Normal;
                }
                else
                {
                    txtUserID.CharacterCasing = CharacterCasing.Upper;
                }

                // CMD Logon인 경우 자동 로그인
                if (b_cmd_logon == true)
                {
                    if (MPCF.Trim(MPGV.gsRemoteAddress) == "")
                    {
                        b_cmd_logon = false;
                    }
                    if (MPCF.Trim(MPGV.gsSiteID) == "")
                    {
                        b_cmd_logon = false;
                    }
                    
                    if (MPIF.gInit.getMiddleware == "TIBRV")
                    {
                        if (MPCF.Trim(MPGV.gsRvService) == "")
                        {
                            b_cmd_logon = false;
                        }
                    }

                    if (MPCF.Trim(txtUserID.Text) == "")
                    {
                        b_cmd_logon = false;
                    }
                    if(string.IsNullOrEmpty(txtPassword.Text) == true)
                    {
                        b_cmd_logon = false;
                    }
                    else
                    {
                        if(txtPassword.Text.Trim() == "")
                        {
                            b_cmd_logon = false;
                        }
                    }
                    if (b_cmd_logon == true)
                    {
                        btnLogin.PerformClick();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Load Falied.");
                return;                    
            }
        }

        /// <summary>
        /// 화면이 Activate 될 때 발생합니다.
        /// Focus 관련 로직이 포함되어 있습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Activated(object sender, EventArgs e)
        {
            // 최초 1회만 실행
            if (bIsOpened == false)
            {
                // Open 여부 설정
                bIsOpened = true;

                // Focus
                if (txtPassword.Text == "")
                {
                    txtPassword.Focus();
                }
                if (txtUserID.Text == "")
                {
                    txtUserID.Focus();
                }
            }
        }

        /// <summary>
        /// Setting 버튼 클릭 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption_Click(System.Object sender, System.EventArgs e)
        {
            // Option 화면 생성
            frmOption frm = new frmOption();
            frm.Owner = this;

            // 프로그램 재시작 하지 않음.
            frm.bFromLoginFlag = true;

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            // 언어 재설정
            if (MPGV.gbReLoadLanguageFlag == true)
            {
                // 언어 파일 초기화
                MPGV.ghtMessageData.Clear();
                MPGV.ghtCaptionData.Clear();

                MPCF.LoadResourceFile();
            }
        }

        /// <summary>
        /// Login 버튼 클릭 시 발생합니다.
        /// 로그인 처리 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 변수 선언
            int i;
            int iCur;
            string[] ListSiteID = new string[20];
            string[] ListRemoteAddress = new string[20];
            string[] ListStationMode = new string[20];
            string[] ListRvService = new string[20];
            string[] ListRvNetwork = new string[20];
            bool UpgradeFlag = false;

            // Factory 정보가 없는 경우 Return
            if (MPGV.gsFactory == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            // User ID 정보가 없는 경우 Return
            if (txtUserID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtUserID.Focus();
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            MPGV.gsUserID = txtUserID.Text;
            if (MPIF.gInit.getMiddleware == "H101")
            {
                //MPGV.gsPassword = MPCF.ToUpper(txtPassword.Text);

                if (string.IsNullOrEmpty(txtPassword.Text) == true)
                {
                    MPGV.gsPassword = "";
                }
                else
                {
                    MPGV.gsPassword = txtPassword.Text.ToUpper();
                }
            }
            else
            {
                MPGV.gsPassword = txtPassword.Text;
            }

            MPGV.gsSiteNickName = MPGV.gsSiteID;

            // Message Handler가 초기화 되지 못한 경우 Return
            if (MPIF.gInit.InitMsgHandler() == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(104));
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            // Login 정보 Validation
            if (MPCF.SEC_Login_Ext(ref UpgradeFlag) == false)
            {
                txtPassword.SelectAll();
                txtPassword.Focus();
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                MPIF.gInit.TermMsgHandler();
                return;
            }

#if _Http
            // SE의 경우 Message Handler Tunning 실패 후 Return
            if (MPIF.gInit.TuneMsgHandler() == false)
            {
                MPCF.ShowMsgBox("Tuning Failed!");
                return;
            }
#endif

            // Upgrage가 필요한 경우
            if (UpgradeFlag == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "BackGroundLogin", "Y");                
                MPCF.SaveRegSetting(Application.ProductName, "Settings", "Factory", MPGV.gsFactory);
                MPCF.SaveRegSetting(Application.ProductName, "Settings", "UserName", MPGV.gsUserID);
                MPCF.SaveRegSetting(Application.ProductName, "Settings", "Password", MPGV.gsPassword);

#if _H101
                MPCF.SaveRegSetting(Application.ProductName, "Option", "H101SiteID", MPGV.gsSiteID);
                MPCF.SaveRegSetting(Application.ProductName, "Option", "H101RemoteAddress", MPGV.gsRemoteAddress);
                MPCF.SaveRegSetting(Application.ProductName, "Option", "H101StationMode", MPGV.gsStationMode);
#endif
#if _Http
                MPCF.SaveRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress", MPGV.gsRemoteAddress);
#endif

                MPGV.gbLogoutFlag = true;

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }

            iCur = -1;

#if _H101
            for (i = 0; i < 20; i++)
            {
                ListSiteID[i] = MPCF.GetRegSetting(Application.ProductName, "Option", "H101SiteID" + i.ToString(), "");
                ListRemoteAddress[i] = MPCF.GetRegSetting(Application.ProductName, "Option", "H101RemoteAddress" + i.ToString(), "");
                ListStationMode[i] = MPCF.GetRegSetting(Application.ProductName, "Option", "H101StationMode" + i.ToString(), "");

                if (ListSiteID[i] == MPGV.gsSiteID && ListRemoteAddress[i] == MPGV.gsRemoteAddress)
                {
                    iCur = i;
                }
            }

            MPCF.SaveRegSetting(Application.ProductName, "Option", "H101SiteID", MPGV.gsSiteID);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "H101RemoteAddress", MPGV.gsRemoteAddress);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "H101StationMode", MPGV.gsStationMode);

            if (iCur >= 0)
            {
                for (i = 1; i <= iCur; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101SiteID" + i.ToString(), ListSiteID[i - 1]);
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101RemoteAddress" + i.ToString(), ListRemoteAddress[i - 1]);
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101StationMode" + i.ToString(), ListStationMode[i - 1]);
                }
            }
            else
            {
                for (i = 1; i <= 19; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101SiteID" + i.ToString(), ListSiteID[i - 1]);
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101RemoteAddress" + i.ToString(), ListRemoteAddress[i - 1]);
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "H101StationMode" + i.ToString(), ListStationMode[i - 1]);
                }
            }

            MPCF.SaveRegSetting(Application.ProductName, "Option", "H101SiteID" + "0", MPGV.gsSiteID);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "H101RemoteAddress" + "0", MPGV.gsRemoteAddress);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "H101StationMode" + "0", MPGV.gsStationMode);
#endif            
#if _Http
            for (i = 0; i < 20; i++)
            {
                ListRemoteAddress[i] = MPCF.GetRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress" + i.ToString(), "");

                if (ListRemoteAddress[i] == MPGV.gsRemoteAddress)
                {
                    iCur = i;
                }
            }

            MPCF.SaveRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress", MPGV.gsRemoteAddress);

            if (iCur >= 0)
            {
                for (i = 1; i <= iCur; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress" + i.ToString(), ListRemoteAddress[i - 1]);
                }
            }
            else
            {
                for (i = 1; i <= 19; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress" + i.ToString(), ListRemoteAddress[i - 1]);
                }
            }

            MPCF.SaveRegSetting(Application.ProductName, "Option", "HTTPRemoteAddress" + "0", MPGV.gsRemoteAddress);
#endif

            MPCF.SaveRegSetting(Application.ProductName, "Settings", "Factory", MPGV.gsFactory);
            MPCF.SaveRegSetting(Application.ProductName, "Settings", "UserName", MPGV.gsUserID);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "UseSmallLetter", (MPGV.gbUseSmallLetter == true ? "Y" : "N"));
            MPCF.SaveRegSetting(Application.ProductName, "Option", "AutoUpgrade", MPGV.gcAutoUpgrade.ToString());            
            MPCF.SaveRegSetting(Application.ProductName, "Option", "Factory" + "0", MPGV.gsFactory);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "UserName" + "0", MPGV.gsUserID);

            // 로그인 화면 Open 여부 설정
            this.bIsOpened = false;

            if (MPGV.gsPassport == MPGC.MP_DONT_CHECK_PASSWORD)
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Close 버튼 클릭 시 발생합니다.
        /// 종료합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Function

        /// <summary>
        /// 화면에 테마를 적용합니다.
        /// </summary>
        private void LoadControlThemeForLogin()
        {
            // Theme 적용
            this.BackColor = MPGV.gTheme.LoginFormBorder;
            this.pnlLoginBackground.BackColor = MPGV.gTheme.LoginFormBackground;
            this.lblTopMESLabel.Appearance.ForeColor = MPGV.gTheme.LoginFormForeground;
            this.lblTopOILabel.Appearance.ForeColor = MPGV.gTheme.LoginFormForeground;
            this.lblUserID.Appearance.ForeColor = MPGV.gTheme.LoginFormForeground;
            this.lblPassword.Appearance.ForeColor = MPGV.gTheme.LoginFormForeground;
            this.btnOption.Appearance.ForeColor = MPGV.gTheme.LoginFormForeground;
            this.btnOption.HotTrackAppearance.ForeColor = MPGV.gTheme.LoginFormForeground;
            this.btnLogin.Appearance.BackColor = MPGV.gTheme.LoginFormLoginButtonBackground;
            this.btnLogin.Appearance.BackColor2 = MPGV.gTheme.LoginFormLoginButtonBackground;
            this.btnLogin.HotTrackAppearance.BackColor = MPGV.gTheme.LoginFormLoginButtonBackground;
            this.btnLogin.HotTrackAppearance.BackColor2 = MPGV.gTheme.LoginFormLoginButtonBackground;

            // TextBox Test
            this.txtUserID.SetContextMenu(this.txtUserID.UseSOIContextMenu);

            //// Image 적용
            //if (MPGV.gTheme is clsLightColors)
            //{
            //    pbLoginImage.Image = Properties.Resources.login_dark_img;
            //    btnOption.Appearance.Image = Properties.Resources.OptionImage;
            //}
            //else
            //{
            //    pbLoginImage.Image = Properties.Resources.LoginImage;
            //    btnOption.Appearance.Image = Properties.Resources.SettingsImage;
            //}
        }

        #endregion

        private void lblTopOILabel_Click(object sender, EventArgs e)
        {

        }

        private void lblTopMESLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
