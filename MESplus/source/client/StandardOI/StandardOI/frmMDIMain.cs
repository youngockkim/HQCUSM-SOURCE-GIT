using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.CliFrx;
#if _H101
using SOI.MsgHandlerH101;
#endif
#if _Http
using SOI.MsgHandlerHTTP;
#endif
using Miracom.TRSCore;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using SOI.CliFrx.SOIModel;
using System.Collections;
using System.Reflection;
using SOI.OIFrx;
using SOI.OIFrx.SOIThemes;
using System.Diagnostics;
using System.Threading;
using SOI.CliFrx.CliFrxPopup;
using System.Threading.Tasks;
using SOI.HanwhaQcell.USModule;
using BOI.OIFrx;

namespace StandardOI
{
    public partial class frmMDIMain : Form, iMdiForm, intHmMdiFormFunction
    {

        delegate void M_PublishDataDelegate(TRSNode in_node);
        private M_PublishDataDelegate _M_PublishDataDelegate;

        #region Property

        private bool b_load_flag = false;
        private bool b_is_drag = false;
        private bool b_is_size_change = false;        
        private bool b_is_loading_completed = false;
        private bool b_is_marquee_mouse_enter = false;
        private bool b_is_start_ver_chk = false;
        protected bool b_can_get_favorites = true;
        private bool b_menu_opening = false;
                
        private int i_marquee_width = 0;
        private int i_version_timer_tick_check = 0;
        protected int i_display_index = 0;

        protected string sOldStatusMsg;
        
        delegate void SetBBSMessageDelegate();
        private delegate void ProgressStartCallback();
        private delegate void ProgressStopCallback();

        private Point pt_mouse_location;
        private Point pt_alarm_one_digit = new Point(38, 3);
        private Point pt_alarm_two_digit = new Point(32, 3);
        private Point pt_alarm_three_digit = new Point(26, 3);

        private Size sz_alarm_one_digit = new Size(16, 14);
        private Size sz_alarm_two_digit = new Size(22,14);
        private Size sz_alarm_three_digit = new Size(28, 14);

        private Thread _tAlarmMessage = null;
        private Thread _tLoadingScreen = null;

        protected Control m_MDIClient = new Control();

        protected Image m_ImgBackPic;
        protected Image _ImgLogo;

        private frmLogin _frmLogin;
        private frmMenu _frmMenu;
        private frmOpenedMenu _frmOpenedMenu;        

        public delegate void ShowAlarmMessageCallBack(AlarmMessage almMsg);        

        private int i_alarm_count = 0;
        public int AlarmCount
        {
            get { return i_alarm_count; }
            set
            {
                i_alarm_count = value;

                // 세자리인 경우
                if (i_alarm_count > 99)
                {
                    lblAlarmCount.Location = pt_alarm_three_digit;
                    lblAlarmCount.Size = sz_alarm_three_digit;
                    lblAlarmCount.Visible = true;
                    lblAlarmCount.Text = "99+";
                }
                // 두자리인 경우
                else if (i_alarm_count > 9
                            && i_alarm_count < 100)
                {
                    lblAlarmCount.Location = pt_alarm_two_digit;
                    lblAlarmCount.Size = sz_alarm_two_digit;
                    lblAlarmCount.Visible = true;
                    lblAlarmCount.Text = i_alarm_count.ToString();
                }
                // 한자리인 경우
                else if (i_alarm_count > 0
                            && i_alarm_count < 10)
                {                    
                    lblAlarmCount.Location = pt_alarm_one_digit;
                    lblAlarmCount.Size = sz_alarm_one_digit;
                    lblAlarmCount.Visible = true;
                    lblAlarmCount.Text = i_alarm_count.ToString();
                }
                // 없는 경우
                else if (i_alarm_count < 1)
                {                    
                    lblAlarmCount.Visible = false;
                    lblAlarmCount.Text = "";
                }
                // 기타의 경우
                else
                {
                    lblAlarmCount.Visible = true;
                    lblAlarmCount.Text = i_alarm_count.ToString();
                }
            }
        }

        private int i_show_alarm_count = 0;
        public int ShowAlarmCount
        {
            get { return i_show_alarm_count; }
            set { i_show_alarm_count = value; }
        }

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

        public frmMDIMain()
        {
            InitializeComponent();
            _M_PublishDataDelegate = new M_PublishDataDelegate(M_PublishData);

            //_setMessageDelegate = new SetMessageDelegate(SetMessage);
            //_setAlarmMessageDelegate = new SetAlarmMessageDelegate(SetAlarmMessage);
            //this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #endregion

        #region Event Handler
        
        /// <summary>
        /// Main Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMDIMain_Load(System.Object sender, System.EventArgs e)
        {
            // Timer 정지
            tmrLogOutTime.Stop();
            tmrCheckVersion.Stop();
            tmrCheckStatus.Stop();

            // Background Mask 설정
            MPGV.gfBackgroundMask.Owner = this;

            // 캡션 및 옵션, 기타자원 정보 로드
            if (MPIF.gInit.LoadResource() == false)
            {
                return;
            }

            // Theme 정보 로드
            MPCF.LoadTheme();

            // Theme 변환
            SetOITheme();

            // Background Default Form 설정
            MPGV.glOpenChildForm.Add(MPGV.gfrmDefaultBackForm);

            // Set Reply Wait Time
            MPGV.giRequestReplyWaitTime = 30;

            // Tabbed MDI Check
            if (MPCF.GetRegSetting(Application.ProductName, "Option", "TabbedMdi", "false") == "true")
            {
                //tsmTabbedMdi.Checked = true;
                //utmMain.Enabled = true;
            }
            else
            {
                //tsmTabbedMdi.Checked = false;
                //utmMain.Enabled = false;
            }

            // Background Login인 경우
            if (MPCF.GetRegSetting(Application.ProductName, "Option", "BackGroundLogin", "N") == "Y")
            {
                // Upgrade Flag 없음
                bool UpgradeFlag = false;

                if (MPCF.GetRegSetting(Application.ProductName, "Option", "BackGroundLogin", "") != "")
                {
                    MPCF.DeleteRegSetting(Application.ProductName, "Option", "BackGroundLogin");
                }

                // 다운로드 파일명, 업그레이드 파일명, 클라이언트 버전을 얻기 위해서 frmLogin을 Load 시킴. 화면에는 보이지 않게 함. 
                frmLogin login = new frmLogin();
                login.Width = 0;
                login.Height = 0;
                login.Show();
                login.Dispose();

                MPGV.gsPassword = MPCF.GetRegSetting(Application.ProductName, "Settings", "Password", "");
                MPGV.gsSiteNickName = MPGV.gsSiteID;

                if (MPIF.gInit.InitMsgHandler() == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(104));
                    MPGV.gbLogoutFlag = true;

                    Close();
                    Application.Exit();
                    return;
                }

                if (MPCF.SEC_Login_Ext(ref UpgradeFlag) == false)
                {
                    MPGV.gbLogoutFlag = true;

                    MPIF.gInit.TermMsgHandler();
                    Close();
                    Application.Exit();
                    return;
                }

#if _Http
                if (MPIF.gInit.TuneMsgHandler() == false)
                {
                    MPCF.ShowMsgBox("Tuning Failed!");
                    return;
                }
#endif
                if (UpgradeFlag == true)
                {
                    // 업그레이드시에 자동으로 로그인 하도록 설정하기 위해서
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

                    Close();
                    Application.Exit();
                    return;
                }
            }
            // Background Login이 아닌 경우
            else
            {
                // Login 화면 생성
                _frmLogin = new frmLogin();
                _frmLogin.Owner = this;

                // Show Login 화면
                if (_frmLogin.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    b_load_flag = true;
                    MPGV.gbLogoutFlag = true;

                    Close();
                    Application.Exit();
                    return;
                }
            }

            if (MPCF.GetRegSetting(Application.ProductName, "Option", "BackGroundLogin", "") != "")
            {
                MPCF.DeleteRegSetting(Application.ProductName, "Option", "BackGroundLogin");
            }

            if (MPCF.GetRegSetting(Application.ProductName, "Settings", "Password", "") != "")
            {
                MPCF.DeleteRegSetting(Application.ProductName, "Settings", "Password");
            }

            // 주기적으로  패스워드 변경 시
            if (MPGV.gcChangePassword == 'Y')
            {
                //// 패스워드 변경 창 생성
                //Form f = new frmChangePassword();

                //// Show 패드워스 변경창
                //if (f.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                //{
                //    b_load_flag = true;
                //    MPGV.gbLogoutFlag = true;

                //    f.Dispose();
                //    this.Close();
                //    Application.Exit();
                //    return;
                //}

                //MPGV.gcChangePassword = ' ';
                //f.Dispose();
            }

            //GetPopupMessage(BBS_POPUP_TYPE_LOGIN, MPGV.gsUserID, "", "", "");
            //c_prev_shift = MPCR.GetCurrentShift();

            //SetTimerHandler();

            if (MPCF.GetRegSetting(Application.ProductName, "Option", "TuneFlag") == "1")
            {
                HQGV.gbTunePublish = true;
            }
            else
            {
                HQGV.gbTunePublish = false;
            }

            HQGV.gsPCId = MPCF.GetRegSetting(Application.ProductName, "Option", "PCId");

            // Timer Start
            tmrLogOutTime.Start();
            tmrCheckVersion.Start();
            tmrCheckStatus.Start(); //2023.10.04 YYK Added

            // Menu Button Rearrange
            SetMenuButton(MPGV.gbMenuPositionLeft);

            // Set Main Form Size
            SetMainFormSize();
        }

        /// <summary>
        /// 화면이 활성화 될 때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMDIMain_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    b_load_flag = true;

                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                    // Default Background Form을 추가한다.
                    SetDefaultBackgroundForm();

                    if (InitMainForm() == false)
                    {
                        return;
                    }

                    // Message Clear
                    ClearMessage();

                    string sLastOpenedForm = MPCF.GetRegSetting(Application.ProductName, "HomeFunction", "HomeFunc", "");
                    MenuInfoTag menuInfo = new MenuInfoTag();
                    if (CheckFormExist(sLastOpenedForm, ref menuInfo) == true)
                    {
                        OpenMenu(menuInfo);
                    }

                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

                    // Loading 화면 종료
                    MPGV.gIMdiForm.ShowLoadingScreen(false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("frmMDIMain_Activated() \n" + ex.Message, MSG_LEVEL.NONE, false);
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Main 화면의 사이즈가 변경될 때 발생합니다.
        /// 1. Child Form 사이즈를 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMDIMain_Resize(object sender, EventArgs e)
        {
            // 1. Child Form 사이즈 변경
            foreach (Form frm in MPGV.glOpenChildForm)
            {
                frm.Width = GetMainWidthForChildForm();
                frm.Height = GetMainHeightForChildForm();
            }
        }

        /// <summary>
        /// 메인화면이 종료될 때 발생합니다.
        /// 최근에 사용한 하나의 화면을 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMDIMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 이전 상태 저장
                // 1. 마지막 보여진 화면 1건 저장
                if (MPGV.glOpenChildForm.Count > 0)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "HomeFunction", "HomeFunc", MPGV.glOpenChildForm[MPGV.glOpenChildForm.Count - 1].Name);
                }

                // 2. 화면 사이즈 저장
                if (this.WindowState != FormWindowState.Minimized)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "MDI_top", this.Top.ToString());
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "MDI_left", this.Left.ToString());
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "MDI_width", this.Width.ToString());
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "MDI_height", this.Height.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 메인 화면 이동에 대한 Mouse Down 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    b_is_drag = true;
                }
                pt_mouse_location = e.Location;
            }
        }

        /// <summary>
        /// 메인 화면 이동에 대한 Mouse Move 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_drag)
            {
                this.Location = new Point((this.Location.X - pt_mouse_location.X) + e.X, (this.Location.Y - pt_mouse_location.Y) + e.Y);
            }
        }

        /// <summary>
        /// 메인 화면 이동에 대한 Mouse Up 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            b_is_drag = false;
        }

        /// <summary>
        /// Top Double 클릭 시 화면을 Max/Normal로 바꿉니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlTop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Maximized 상태인 경우
            if (this.WindowState == FormWindowState.Normal)
            {
                SetMainWindowMax();
            }
            // Normal 상태인 경우
            else
            {
                SetMainWindowNormal();
            }
        }

        /// <summary>
        /// Size 조절 시작
        /// 모든 Size 조절 이벤트를 하나의 핸들러로 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutMiddleLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    b_is_size_change = true;
                }
                pt_mouse_location = e.Location;
            }
        }

        /// <summary>
        /// Left Size 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutMiddleLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_size_change)
            {
                Point ptTemp = new Point((this.Location.X - pt_mouse_location.X) + e.X, this.Location.Y);
                this.Width += this.Location.X - ptTemp.X;
                this.Location = ptTemp;
                this.Update();
            }
        }

        /// <summary>
        /// Size 조절 종료
        /// 모든 Size 조절 이벤트를 하나의 핸들러로 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutMiddleLeft_MouseUp(object sender, MouseEventArgs e)
        {
            b_is_size_change = false;
        }

        /// <summary>
        /// Right Size 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutMiddleRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_size_change)
            {
                this.Width += e.X;
                this.Update();
            }
        }

        /// <summary>
        /// Top Size 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutTopMiddle_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_size_change)
            {
                Point ptTemp = new Point(this.Location.X, (this.Location.Y - pt_mouse_location.Y) + e.Y);
                this.Height += this.Location.Y - ptTemp.Y;
                this.Location = ptTemp;
                this.Update();
            }
        }

        /// <summary>
        /// Bottom Size 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutBottomMiddle_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_size_change)
            {
                this.Height += e.Y;
                this.Update();
            }
        }

        /// <summary>
        /// Top Left Size 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutTopLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_size_change)
            {
                Point ptTemp = new Point((this.Location.X - pt_mouse_location.X) + e.X, (this.Location.Y - pt_mouse_location.Y) + e.Y);
                this.Width += this.Location.X - ptTemp.X;
                this.Height += this.Location.Y - ptTemp.Y;
                this.Location = ptTemp;
                this.Update();
            }
        }

        /// <summary>
        /// Top Right 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutTopRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_size_change)
            {
                Point ptTemp = new Point(this.Location.X, (this.Location.Y - pt_mouse_location.Y) + e.Y);
                this.Width += e.X;
                this.Height += this.Location.Y - ptTemp.Y;
                this.Location = ptTemp;
                this.Update();
            }
        }

        /// <summary>
        /// Bottom Left Size 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutBottomLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_size_change)
            {
                Point ptTemp = new Point((this.Location.X - pt_mouse_location.X) + e.X, this.Location.Y);
                this.Width += this.Location.X - ptTemp.X;
                this.Height += e.Y;
                this.Location = ptTemp;
                this.Update();
            }
        }

        /// <summary>
        /// Bottom Right Size 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlOutBottomRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_size_change)
            {
                this.Width += e.X;
                this.Height += e.Y;
                this.Update();
            }
        }

        /// <summary>
        /// Option 화면 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbOption_Click(object sender, EventArgs e)
        {
            // Option 창 생성
            frmOption frm = new frmOption();

            try
            {
                frm.Owner = this;

                // Show Dialog
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // 재시작여부 확인
                if (MPGV.gbReloginFlag == true
                    || MPGV.gbReLoadLanguageFlag == true)
                {
                    RestartProgram();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
            finally
            {
                if (frm != null)
                {
                    frm.Dispose();
                }
            }
        }

        /// <summary>
        /// 사용자 정보 화면 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbUserInfo_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(); ;

            try
            {
                frm.Owner = this;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
            finally
            {
                if (frm != null)
                {
                    frm.Dispose();
                }
            }
        }

        /// <summary>
        /// 로그아웃 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbLogout_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(13), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            RestartProgram();
        }

        /// <summary>
        /// 화면을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbExit_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(4), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

#if _Http
            MPMH.Instance.logout();
#endif

            this.Close();
        }

        /// <summary>
        /// 화면을 최대화 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                SetMainWindowMax();
            }
            else
            {
                SetMainWindowNormal();
            }
        }

        /// <summary>
        /// 화면을 최소화 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Menu 클릭 시 발생한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMenu_Click(object sender, EventArgs e)
        {
            try
            {
                // 생성
                _frmMenu = new frmMenu();
                _frmMenu.Owner = this;

                // 현재 Window Position
                Point po = GetWindowPosition();

                // Left Position
                if (MPGV.gbMenuPositionLeft == true)
                {
                    // 위치 변경
                    _frmMenu.Top = po.Y + pnlOutTopMiddle.Height + pnlTop.Height + pnlTopUnderline.Height + 8;
                    _frmMenu.Left = po.X + 10;
                }
                // Right Position
                else
                {
                    // 위치 변경
                    _frmMenu.Top = po.Y + pnlOutTopMiddle.Height + pnlTop.Height + pnlTopUnderline.Height + 8;
                    _frmMenu.Left = po.X + this.Width - _frmMenu.Width - 10;
                }

                _frmMenu.ShowDialog();
            }
            finally
            {
                if (_frmMenu != null)
                {
                    _frmMenu.Dispose();
                }
            }
        }

        /// <summary>
        /// Error Message 화면을 open 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMessage_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Error Message가 없는 경우 종료
                if (MPGV.glErrorMessageList.Count < 1)
                {
                    return;
                }

                frmViewErrorMessage frmErrorMessage = new frmViewErrorMessage();
                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "StandardOI.exe";
                menuInfo.s_assembly_name = "StandardOI.frmViewErrorMessage";
                menuInfo.s_func_desc = "View Error Message";
                menuInfo.s_func_name = "SYSTEM";
                
                OpenMenu(menuInfo, frmErrorMessage);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("lblMessage_MouseDown \n" + ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Alarm 선택 시 Alarm List 조회 화면을 Open합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlAlarm_Click(object sender, EventArgs e)
        {
            // Alarm Message가 없는 경우 종료
            if (MPGV.gtAlarmList.Count < 1)
            {
                return;
            }

            frmViewAlarmPublishMessage frmAlarmMessage = new frmViewAlarmPublishMessage();
            MenuInfoTag menuInfo = new MenuInfoTag();
            menuInfo.c_func_type = 'F';
            menuInfo.s_assembly_file = "StandardOI.exe";
            menuInfo.s_assembly_name = "StandardOI.frmViewAlarmPublishMessage";
            menuInfo.s_func_desc = "View Alarm Message";
            menuInfo.s_func_name = "SYSTEM";

            OpenMenu(menuInfo, frmAlarmMessage);
        }

        /// <summary>
        /// Message가 화면에 모두 표시되지 않는 경우에는 Marquee 형식으로 보여줍니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrMessageMarquee_Tick(object sender, EventArgs e)
        {
            if (i_marquee_width < 0)
            {
                lblMessage.Location = new Point(pnlMessageMargin.Width, lblMessage.Location.Y);
                i_marquee_width = lblMessage.Width;
            }
            else
            {
                lblMessage.Location = new Point(lblMessage.Location.X - 2, lblMessage.Location.Y);
                i_marquee_width -= 2;
            }
        }

        /// <summary>
        /// 마퀴 실행중인 경우 중지합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMessage_MouseEnter(object sender, EventArgs e)
        {
            // 실행중인 경우
            if (tmrMessageMarquee.Enabled)
            {
                // Stop
                tmrMessageMarquee.Stop();
                b_is_marquee_mouse_enter = true;
            }
        }

        /// <summary>
        /// 마퀴 중지된 경우 다시 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMessage_MouseLeave(object sender, EventArgs e)
        {
            // 실행 중지된 경우
            if (b_is_marquee_mouse_enter)
            {
                // Start
                tmrMessageMarquee.Start();
                b_is_marquee_mouse_enter = false;
            }
        }

        /// <summary>
        /// 1분마다 LogOut Time을 계산하고 LogOut 설정 시 LogOut 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrLogOutTime_Tick(object sender, EventArgs e)
        {
            // 디자인 모드에서는 미적용
            if (DesignMode == true)
            {
                return;
            }

            try
            {
                // Idle Time 증가
                MPGV.giIdleTime++;

                // 설정된 경우
                if (MPGV.giLogOutTime > 0)
                {
                    // 어떤 서비스라도 실행되면 Idle Time=0으로 초기화 됩니다.
                    // Idle Time이 설정된 Lotout Time을 지난 경우                    
                    if (MPGV.giIdleTime >= MPGV.giLogOutTime)
                    {
                        // Timer 정지
                        tmrLogOutTime.Stop();

                        // Message Box Show (OK만 가능)
                        MPCF.ShowMsgBox(MPCF.GetMessage(7), MessageBoxButtons.OK, MSG_LEVEL.NONE, "", true);

                        // Logout 실행. (반드시 실행됨)
                        Thread t = new Thread(new ThreadStart(LogOutApplication));
                        t.IsBackground = true;
                        t.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message); 
            }
        }

        /// <summary>
        /// 1분마다 Version을 확인하고 Upgrade 필요 시, Message Box가 표현됩니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrCheckVersion_Tick(object sender, EventArgs e)
        {
            // 디자인 모드에서는 종료
            if (DesignMode == true)
            {
                return;
            }

            // Version Check Time이 설정되지 않은 경우 종료
            if (MPGV.giVersionCheckTime < 1)
            {
                return;
            }

            // Process 중인 경우 제외
            if (MPIF.gInit.IsProcessCaster == true)
            {
                return;
            }

            // Message 전송이 불가능한 경우 종료
            if (MPIF.gInit.IsAvailableSendMessage == false)
            {
                return;
            }

            // Loging 상태인 경우 종료
            if (MPGV.gIMdiForm.GetLoginState() == true)
            {
                return;
            }
            
            try
            {
                HQCF.SendClientStatus();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            try
            {
                if (b_is_start_ver_chk == false)
                {
                    b_is_start_ver_chk = true;

                    i_version_timer_tick_check++;

                    // Check 시간보다 경과된 경우
                    if (i_version_timer_tick_check == MPGV.giVersionCheckTime)
                    {
                        // Upgrade 하는 경우
                        if (MPCF.Client_Upgrade(1) == 1)
                        {
                            // Reg 등록
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

                            // 메인화면 종료
                            this.Close();

                            // 프로그램 종료
                            Application.Exit();
                        }

                        i_version_timer_tick_check = 0;
                    }

                    b_is_start_ver_chk = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);

                // 에러 발생 시, 매 1분마다 에러가 발생하지 않도록 타이머를 정지.
                tmrCheckVersion.Stop();
            }
        }

        /// <summary>
        /// Manually Upgrade when Logo 3 times click 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMainLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.Clicks >= 2)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(11), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "MESplus OI Upgrade") == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    if (MPCF.Client_Upgrade(2) == 1)
                    {
                        MPGV.gbLogoutFlag = true;
                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Show Opened Function List Popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbOpenFormMenu_Click(object sender, EventArgs e)
        {
            try
            {
                // 생성
                _frmOpenedMenu = new frmOpenedMenu();
                _frmOpenedMenu.Owner = this;

                // 현재 Window Position
                Point po = GetWindowPosition();

                _frmOpenedMenu.Top = po.Y + pnlOutTopMiddle.Height + pnlTop.Height + pnlTopUnderline.Height + 2;
                _frmOpenedMenu.Left = po.X + pnlOutMiddleLeft.Width + pnlOpenForm.Width + 2;

                _frmOpenedMenu.ShowDialog();
            }
            finally
            {
                if (_frmOpenedMenu != null)
                {
                    _frmOpenedMenu.Dispose();
                }
            }
        }

        /// <summary>
        /// 단축키를 통해 화면을 열 때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuInfoTag menuInfo;
                ToolStripMenuItem m_menu = null;

                m_menu = (ToolStripMenuItem)sender;
                menuInfo = (MenuInfoTag)m_menu.Tag;

                Control cFocus = MPGV.gIMdiForm.OpenMenu(menuInfo);
                if (cFocus != null)
                {
                    cFocus.Focus();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        public bool Publish_M_MsgTune()
        {

            try
            {
                if (HQCF.Publish_M_MsgTune() == false)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        public void M_PublishDataEvent(TRSNode in_node)
        {
            IAsyncResult r = BeginInvoke(_M_PublishDataDelegate, new object[] { in_node });
            EndInvoke(r);
        }

        public void M_PublishData(TRSNode in_node)
        {
            try
            {
                Form f;

                    if (MPCF.Trim(in_node.GetString("IN_SERVICE_NAME")) == "EAPMES_Complete_Packing")
                    {
                        f = MPCF.GetChildForm(this, "frmCUSModulePackingAuto", false);

                        if (f == null)
                        {
                            f = new frmCUSModulePackingAuto();
                            f.MdiParent = this;
                            //f.Owner = this;
                            f.FormBorderStyle = FormBorderStyle.None;
                            f.WindowState = FormWindowState.Normal;
                            f.Show();
                            ((frmCUSModulePackingAuto)f).SetMessageEvent(in_node);
                        }
                        else
                        {
                            ((frmCUSModulePackingAuto)f).Activate();
                            ((frmCUSModulePackingAuto)f).SetMessageEvent(in_node);
                        }


                    }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMDIMain.HEVPublishData()\n" + ex.Message);
            }
        }

        /// <summary>
        /// 화면에 테마를 적용합니다.
        /// </summary>
        private void SetOITheme()
        {
            this.pnlTop.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlOutTopLeft.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlOutTopMiddle.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlOutTopControl.BackColor = MPGV.gTheme.MainFormTitleControlBoxBackground;
            this.pnlOutTopControlRight.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlOutTopRight.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlOutMiddleLeft.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlOutMiddleRight.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlOutBottomLeft.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlOutBottomMiddle.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlOutBottomRight.BackColor = MPGV.gTheme.MainFormTitleBackground;
            this.pnlControlBox.BackColor = MPGV.gTheme.MainFormTitleControlBoxBackground;    
            this.pnlTopUnderline.BackColor = MPGV.gTheme.MainFormTitleUnderline;
            this.pnlBottom.BackColor = MPGV.gTheme.MainFormBottomBackground;

            this.pnlOpenForm.BackColor = MPGV.gTheme.MainFormOpenMenuBackground;

            // Load Logo
            try
            {
                _ImgLogo = Image.FromFile(@"MESOI_logo.png");
            }
            catch (Exception)
            {
                _ImgLogo = Properties.Resources.MESplus_OI_logo;
            }

            if (_ImgLogo != null)
            {
                pbMainLogo.Image = _ImgLogo;
            }
        }

        /// <summary>
        /// Menu Button의 위치를 설정합니다.
        /// </summary>
        /// <param name="left"></param>
        private void SetMenuButton(bool left)
        {
            // Left 설정인 경우
            if (left == true)
            {
                pbMenu.Visible = false;
                pnlControlBox.Width = pnlControlBox.Width - (pbMenu.Width + pbMenu.Margin.Right);
                pnlControlBox.Location = new Point(pnlControlBox.Location.X + pbMenu.Width + pbMenu.Margin.Right, pnlControlBox.Location.Y);
                pnlOutTopControl.Width = pnlOutTopControl.Width - (pbMenu.Width + pbMenu.Margin.Right);
                pnlOutTopControl.Location = new Point(pnlOutTopControl.Location.X + pbMenu.Width + pbMenu.Margin.Right, pnlOutTopControl.Location.Y);
                pnlOutTopMiddle.Width = pnlOutTopMiddle.Width + (pbMenu.Width + pbMenu.Margin.Right);
            }
            // Right 설정인 경우
            else
            {
                pbMenuLeft.Visible = false;
                pbMainLogo.Location = new Point(0, pbMainLogo.Location.Y);
            }
        }

        /// <summary>
        /// Main Form Size를 설정합니다.
        /// Registry에 등록된 정보를 사용합니다.
        /// </summary>
        private void SetMainFormSize()
        {
            // Current Area
            Rectangle rect = Screen.GetWorkingArea(Control.MousePosition);

            //Set Size & Location of MDI Form
            this.Top = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "Option", "MDI_top", "0"));
            if (this.Top < 0)
            {
                this.Top = 0;
            }
            if (this.Top < rect.Top)
            {
                this.Top = rect.Top;
            }

            this.Left = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "Option", "MDI_left", "0"));
            if (this.Left < 0)
            {
                this.Left = 0;
            }
            if (this.Left < rect.Left)
            {
                this.Left = rect.Left;
            }

            this.Width = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "Option", "MDI_width", "1280"));
            if (this.Width < 0)
            {
                this.Width = 1280;
            }
            if (this.Width > rect.Width)
            {
                this.Width = rect.Width;
            }

            this.Height = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "Option", "MDI_height", "800"));
            if (this.Height < 0)
            {
                this.Height = 800;
            }
            if (this.Height > rect.Height)
            {
                this.Height = rect.Height;
            }

            if (this.Top + this.Height > rect.Top + rect.Height)
            {
                this.Top = rect.Top + ((rect.Height - this.Height) / 2);
            }

            if (this.Left + this.Width > rect.Left + rect.Width)
            {
                this.Left = rect.Left + ((rect.Width - this.Width) / 2);
            }
        }

        /// <summary>
        /// Main Form 초기화
        /// </summary>
        /// <returns></returns>
        protected bool InitMainForm()
        {
            try
            {
                // 화면 초기화
                pbMessage.Image = null;
                lblMessage.Text = "";
                AlarmCount = 0;
                //lblAlarmCount.Text = "";
                //lblAlarmCount.Visible = false;

                // Main 화면 Title 이름 변경
                //this.Text = this.Text + " [" + MPGV.gsSiteNickName + "]";

                // Factory Shift 정보 로드
                if (MPGV.gsServerName == "ADMServer")
                {
                    MPGV.gShiftInfor.iShiftCount = 0;
                    MPGV.gShiftInfor.sShift1StartTime = "000000";
                }
                else
                {
                    if (MPCF.GetFactoryShiftInfor() == false)
                    {
                        return false;
                    }
                }

                // Alarm Message Tunner 초기화
                if (MPGV.gIMdiForm.PublishALMMsgTune() == false)
                {
                    return false;
                }

                // Server에 등록된 화면목록 호출
                if (GetAllFunctionList() == false)
                {
                    return false;
                }

                // Caption 정보 로드
                if (MPIF.gInit.getMiddleware == "HTTP")
                {
                    if (MPCF.LoadMultiLangList() == false)
                    {
                        return false;
                    }
                }


                if (Publish_M_MsgTune() == false) return false;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMDIMain.InitMainForm()\n" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Login 화면인 경우 true, 메인화면인 경우 false
        /// </summary>
        /// <returns></returns>
        public bool GetLoginState()
        {
            if (_frmLogin != null
                && _frmLogin.bIsOpened == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Form Text로부터 해당 Form을 찾습니다.
        /// </summary>
        /// <returns></returns>
        private bool CheckFormExist(string sFormText, ref MenuInfoTag menuInfo)
        {
            try
            {
                // 화면 이름이 없는 경우 종료
                if (string.IsNullOrEmpty(sFormText) == true)
                {
                    return false;
                }

                // 화면 이름이 하단 목록 중 하나인 경우 종료 (시스템 화면)
                if (sFormText == "frmViewAlarmPublishMessage"
                    || sFormText == "frmViewErrorMessage"
                    || sFormText == "frmFavoriteSetup"
                    || sFormText == "SOIDefaultBackgroundForm")
                {
                    return false;
                }

                // 모든 화면 메뉴를 호출하고 화면이 없는경우 종료
                GetAllFunctionList();
                GetFavFunctionList();
                if (MPGV.galAllFunctionList.Count < 1)
                {
                    return false;
                }

                // 해당 화면이 있는지 확인
                string[] sAssemblyFile;
                bool bFound = false;
                foreach (TRSNode node in MPGV.galAllFunctionList)
                {
                    if (MPCF.Trim(MPGV.gsUserGroup) != "" && node.GetList(0).Count > 0)
                    {
                        for (int i = 0; i < node.GetList(0).Count; i++)
                        {
                            if(string.IsNullOrEmpty(((TRSNode)node.GetList(0)[i]).GetString("ASSEMBLY_FILE")) == false)
                            {
                                sAssemblyFile = ((TRSNode)node.GetList(0)[i]).GetString("ASSEMBLY_NAME").Split('.');
                                if(sAssemblyFile.Length > 0)
                                {
                                    if(sAssemblyFile[sAssemblyFile.Length - 1] == sFormText)
                                    {
                                        bFound = true;
                                        menuInfo.s_func_name = ((TRSNode)node.GetList(0)[i]).GetString("FUNC_NAME");
                                        menuInfo.s_func_desc = ((TRSNode)node.GetList(0)[i]).GetString("FUNC_DESC");
                                        menuInfo.s_assembly_file = ((TRSNode)node.GetList(0)[i]).GetString("ASSEMBLY_FILE");
                                        int args_start_p = ((TRSNode)node.GetList(0)[i]).GetString("ASSEMBLY_NAME").IndexOf(' ');
                                        if (args_start_p > 0)
                                        {
                                            menuInfo.s_assembly_name = ((TRSNode)node.GetList(0)[i]).GetString("ASSEMBLY_NAME").Substring(0, args_start_p);
                                            menuInfo.s_args = ((TRSNode)node.GetList(0)[i]).GetString("ASSEMBLY_NAME").Substring(args_start_p + 1, ((TRSNode)node.GetList(0)[i]).GetString("ASSEMBLY_NAME").Length - args_start_p - 1);
                                        }
                                        else
                                        {
                                            menuInfo.s_assembly_name = ((TRSNode)node.GetList(0)[i]).GetString("ASSEMBLY_NAME");
                                            menuInfo.s_args = null;
                                        }
                                        menuInfo.c_func_type = ((TRSNode)node.GetList(0)[i]).GetChar("FUNC_TYPE_FLAG");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                // 찾지 못한 경우
                if (bFound == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("Check Form Exist \n" + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 하단 메세지 바에 에러 메세지를 표시합니다.
        /// </summary>
        /// <param name="message">표시할 메세지</param>
        /// <param name="msgLevel">메세지 레벨</param>
        public void SetMessage(string message, MSG_LEVEL msgLevel)
        {
            // 로그인 화면에 대한 에러는 팝업으로만 표시
            if (_frmLogin != null
                && _frmLogin.bIsOpened == true)
            {
                return;
            }

            // 메시지가 null인 경우에는 공백 입력
            if (message == "")
            {
                message = " ";
            }

            // Clear Message
            ClearMessage();

            // 메시지 레벨에 따라 내용 및 아이콘 변경
            switch (msgLevel)
            {
                case MSG_LEVEL.INFO:
                    this.pbMessage.Image = Properties.Resources.Main_Msg_Info;
                    this.lblMessage.Appearance.ForeColor = MPGV.gTheme.MainFormMessageInfoForeground;
                    this.lblMessage.Text = message;
                    break;
                case MSG_LEVEL.WARNING:
                    this.pbMessage.Image = Properties.Resources.Main_Msg_Warn;
                    this.lblMessage.Appearance.ForeColor = MPGV.gTheme.MainFormMessageWarnForeground;
                    this.lblMessage.Text = message;
                    break;
                case MSG_LEVEL.ERROR:
                    this.pbMessage.Image = Properties.Resources.Main_Msg_Error;
                    this.lblMessage.Appearance.ForeColor = MPGV.gTheme.MainFormMessageErrorForeground;
                    this.lblMessage.Text = message;
                    break;
                default:
                    this.pbMessage.Image = null;
                    this.lblMessage.Appearance.ForeColor = MPGV.gTheme.MainFormMessageDefaultForeground;
                    this.lblMessage.Text = message;
                    break;
            }

            // 메시지가 긴 경우에는 아래와 같이 보여준다.
            if (lblMessage.Width > pnlMessageMargin.Width)
            {
                i_marquee_width = lblMessage.Width;
                tmrMessageMarquee.Start();
            }

            if (b_load_flag == true
                && b_menu_opening == false)
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Message Bar를 초기화합니다.
        /// </summary>
        private void ClearMessage()
        {
            // 이미지 삭제
            this.pbMessage.Image = null;

            // Default Color로 복귀
            this.lblMessage.Appearance.ForeColor = MPGV.gTheme.MainFormMessageDefaultForeground;

            // Text 제거
            this.lblMessage.Text = "";

            // Timer 초기화
            tmrMessageMarquee.Stop();

            // Marquee Widh 초기화
            i_marquee_width = 0;

            // Location 복귀
            lblMessage.Location = new Point(0, 0);
        }

        /// <summary>
        /// 전역 알람 리스트의 알람을 표시합니다.
        /// </summary>
        public void SetAlarmMessage()
        {
            this._tAlarmMessage = new Thread(new ThreadStart(this.ShowAlarmMessage));
            this._tAlarmMessage.Start();
        }

        /// <summary>
        /// Alarm Message를 실행합니다.
        /// Call Back 메소드를 사용합니다.
        /// </summary>
        private void ShowAlarmMessage()
        {
             // 새로운 Alarm Message를 생성하며 Collection에 추가하고, 동일한 내용을 복사한다.
             ObservableCollection<AlarmMessage> almMsg = new ObservableCollection<AlarmMessage>(MPGV.gtAlarmList);
             this.BeginInvoke(new ShowAlarmMessageCallBack(BindAlarmMessage), almMsg[0]);
        }

        /// <summary>
        /// Alarm 화면을 나타냅니다.
        /// </summary>
        /// <param name="almMsg"></param>
        private void BindAlarmMessage(AlarmMessage almMsg)
        {
            //SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));

            this.AlarmCount = this.AlarmCount + 1;

            if (MPGV.gbShowAlarmPopup == true)
            {
                // Form 생성
                frmAlarmMessage _frmAlarmMessage = new frmAlarmMessage();

                // 좌표 계산
                Point po = GetWindowPosition();

                // Alarm Count 계산
                int iCount = MPCF.GetShowAlarmCount() + 1;

                MPCF.SetShowAlarmCountIncrease();

                _frmAlarmMessage.SetAlarmFormID(iCount);
                _frmAlarmMessage.Owner = this;
                if (iCount < 5)
                {
                    _frmAlarmMessage.Top = po.Y + this.Height - (_frmAlarmMessage.Height * iCount) - pnlBottom.Height - (10 * iCount);
                }
                else
                {
                    _frmAlarmMessage.Top = po.Y + this.Height - (_frmAlarmMessage.Height * 4) - pnlBottom.Height - (10 * 4);
                }
                _frmAlarmMessage.Left = po.X + this.Width - _frmAlarmMessage.Width - 10;
                _frmAlarmMessage.AddAlarm(almMsg);
                _frmAlarmMessage.Show();
            }
        }

        /// <summary>
        /// Loading Screen을 보이거나 닫습니다.
        /// </summary>
        /// <param name="bShow"></param>
        public void ShowLoadingScreen(bool bShow)
        {
            // Show인 경우
            if (bShow
                && b_load_flag)
            {
                if (_tLoadingScreen != null
                    && _tLoadingScreen.IsAlive == true)
                {
                    return;
                }

                b_is_loading_completed = false;

                _tLoadingScreen = new Thread(new ThreadStart(ShowLoading));
                _tLoadingScreen.IsBackground = true;
                _tLoadingScreen.Start();
            }
            // Close인 경우
            else
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(300);

                    if (MPIF.gInit.IsProcessCaster == true)
                    {
                        return;
                    }

                    b_is_loading_completed = true;

                    MPCF.FlushMemory();
                });                
            }
        }

        /// <summary>
        /// Loading Screen을 실행합니다.
        /// </summary>
        public void ShowLoading()
        {
            using (frmLoadingScreen loadingScreen = new frmLoadingScreen())
            {
                loadingScreen.Top = this.Top;
                loadingScreen.Left = this.Left;
                loadingScreen.Width = this.Width;
                loadingScreen.Height = this.Height;
                loadingScreen.Show();

                while (!b_is_loading_completed)
                {                    
                    Application.DoEvents();
                }

                loadingScreen.Close();
            }
        }

        /// <summary>
        /// 현재 Open된 Window의 위치를 계산한다.
        /// </summary>
        /// <returns></returns>
        private Point GetWindowPosition()
        {
            Point po = new Point();

            po.X = this.Left;
            po.Y = this.Top;

            return po;
        }

        /// <summary>
        /// Publish Alarm message Tune
        /// </summary>
        /// <returns></returns>
        public bool PublishALMMsgTune()
        {
            if (PublishMsgTune.PublishALMMsgTune() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Shortcut Key를 등록합니다.
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <param name="shortcutKey"></param>
        /// <returns></returns>
        public bool AddShortcutKey(MenuInfoTag menuInfo, Keys shortcutKey)
        {
            // 1. Validation

            // 2. Create Item
            ToolStripMenuItem m_menu = new ToolStripMenuItem();
            m_menu.ShortcutKeys = shortcutKey;
            m_menu.Click += new EventHandler(ToolStripMenuItem_Click);
            m_menu.Tag = menuInfo;

            // 3. Add Item
            mnuMenu.Items.Insert(mnuMenu.Items.Count, m_menu);

            return true;
        }

        /// <summary>
        /// Shortcut Key를 삭제합니다.
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool RemoveShortcutKey(MenuInfoTag menuInfo)
        {
            MenuInfoTag tmpMenuInfo;
            List<int> removeItemIndexList = new List<int>();

            // 1. Find Item
            for (int i = 0; i < mnuMenu.Items.Count; i++)
            {
                if (mnuMenu.Items[i].Tag != null)
                {
                    tmpMenuInfo = (MenuInfoTag)mnuMenu.Items[i].Tag;

                    if (tmpMenuInfo.s_assembly_name == menuInfo.s_assembly_name)
                    {
                        removeItemIndexList.Add(i);
                    }
                }
            }

            // 2. Remove Item
            removeItemIndexList.Reverse();
            foreach (int index in removeItemIndexList)
            {
                mnuMenu.Items.RemoveAt(index);
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func_list"></param>
        /// <returns></returns>
        public bool SetShortcutKeys(ArrayList func_list)
        {
            try
            {
                ArrayList tmp_func_list = new ArrayList();
                TRSNode func_item;
                MenuInfoTag m_menu;
                Keys m_key;
                string s_tmp;

                // 1. Initialize
                mnuMenu.Items.Clear();

                // 2. Get Array List
                foreach (TRSNode node in func_list)
                {
                    if (MPCF.Trim(MPGV.gsUserGroup) != "" && node.GetList(0).Count > 0)
                    {
                        for (int i = 0; i < node.GetList(0).Count; i++)
                        {
                            tmp_func_list.Add(node.GetList(0)[i]);
                        }
                    }
                }

                // 3. Add Shortcut Key
                if (MPCF.Trim(MPGV.gsUserGroup) != "")
                {
                    for (int i = 0; i < tmp_func_list.Count; i++)
                    {
                        // Get Node
                        func_item = (TRSNode)tmp_func_list[i];

                        // Vaidation Shortcut Key
                        if (func_item.GetString("SHORT_CUT").Length > 0)
                        {
                            m_menu.s_func_name = func_item.GetString("FUNC_NAME");
                            m_menu.s_func_desc = func_item.GetString("FUNC_DESC");
                            m_menu.s_assembly_file = func_item.GetString("ASSEMBLY_FILE");
                            int args_start_p = func_item.GetString("ASSEMBLY_NAME").IndexOf(' ');
                            if (args_start_p > 0)
                            {
                                m_menu.s_assembly_name = func_item.GetString("ASSEMBLY_NAME").Substring(0, args_start_p);
                                m_menu.s_args = func_item.GetString("ASSEMBLY_NAME").Substring(args_start_p + 1, func_item.GetString("ASSEMBLY_NAME").Length - args_start_p - 1);
                            }
                            else
                            {
                                m_menu.s_assembly_name = func_item.GetString("ASSEMBLY_NAME");
                                m_menu.s_args = null;
                            }
                            m_menu.c_func_type = func_item.GetChar("FUNC_TYPE_FLAG");

                            m_key = (func_item.GetString("SHORT_CUT")[0] == 'C' ? Keys.Control : Keys.None);
                            m_key = m_key | (func_item.GetString("SHORT_CUT")[1] == 'A' ? Keys.Alt : Keys.None);
                            m_key = m_key | (func_item.GetString("SHORT_CUT")[2] == 'S' ? Keys.Shift : Keys.None);

                            s_tmp = func_item.GetString("SHORT_CUT").Substring(3);
                            if (s_tmp.Length > 1)
                            {
                                m_key = m_key | (Keys)((int)Keys.F1 + MPCF.ToInt(s_tmp.Substring(1)) - 1);
                            }
                            else
                            {
                                m_key = m_key | (Keys)((int)s_tmp[0]);
                            }

                            try
                            {
                                AddShortcutKey(m_menu, m_key);
                            }
                            catch (InvalidEnumArgumentException)
                            {
                                string s_error_string = "";
                                if (func_item.GetString("SHORT_CUT")[0] == 'C')
                                {
                                    s_error_string += "Control";
                                }
                                if (func_item.GetString("SHORT_CUT")[1] == 'A')
                                {
                                    if (s_error_string.Length > 1) s_error_string += "|";
                                    s_error_string += "Alt";
                                }
                                if (func_item.GetString("SHORT_CUT")[2] == 'S')
                                {
                                    if (s_error_string.Length > 1) s_error_string += "|";
                                    s_error_string += "Shift";
                                }
                                if (s_error_string.Length > 1) s_error_string += "+";
                                s_error_string += s_tmp;

                                MPCF.ShowErrorMessage("Not Allowed Shortcut Keys : " + s_error_string);
                            }
                        }
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
        /// 사용 가능한 화면 목록을 가져온다.
        /// </summary>
        /// <param name="mnuMenu"></param>
        /// <param name="i_menu_insert_index"></param>
        /// <param name="tolTool"></param>
        /// <returns></returns>
        public bool GetAllFunctionList()
        {
            // 변수 선언
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_LIST_OUT");

            //b_process_to_generate_menu = true;

            try
            {
                // 초기화
                MPGV.galAllFunctionList.Clear();

                // In Node
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("SEC_GRP_ID", MPGV.gsUserGroup);
                in_node.AddString("NEXT_FUNC_NAME", "");

                do
                {
                    // Call Service
                    if (MPCF.CallService("SEC", "SEC_View_Function_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    MPGV.galAllFunctionList.Add(out_node);

                    in_node.SetString("NEXT_FUNC_NAME", out_node.GetString("NEXT_FUNC_NAME"));
                } while (in_node.GetString("NEXT_FUNC_NAME") != "");

                SetShortcutKeys(MPGV.galAllFunctionList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("GetAllFunctionList() is Failed.\n" + ex.Message);
                return false;
            }

            //b_process_to_generate_menu = false;

            return true;
        }

        /// <summary>
        /// 등록된 즐겨찾기 화면을 가져온다.
        /// </summary>
        /// <param name="mnuMenu"></param>
        /// <param name="i_menu_insert_index"></param>
        /// <param name="tolTool"></param>
        /// <returns></returns>
        public bool GetFavFunctionList()
        {
            // 변수 선언
            TRSNode in_node = new TRSNode("VIEW_FAVORITE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FAVORITE_LIST_OUT");

            try
            {
                // 초기화
                MPGV.galFavFunctionList.Clear();

                // In Node
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("NEXT_FUNC_SEQ", "");

                do
                {
                    // Call Service
                    if (MPCF.CallService("SEC", "SEC_View_Favorites_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    MPGV.galFavFunctionList.Add(out_node);

                    in_node.SetString("NEXT_FUNC_SEQ", out_node.GetString("NEXT_FUNC_SEQ"));
                } while (in_node.GetString("NEXT_FUNC_SEQ") != "");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("GetAllFunctionList() is Failed.\n" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 화면을 Open 합니다.
        /// UI에서 등록된 화면을 open할 때 사용합니다.
        /// </summary>
        public Control OpenMenu(MenuInfoTag menuInfo)
        {
            string sApplicationPath;
            string[] sSplit;
            object oChildForm;
            Assembly asmDll;
            Control cFocusControl;

            try
            {
                // Message Flag
                b_menu_opening = true;

                // 메뉴 정보가 없는 경우 Return
                if (menuInfo.Equals(null))
                {
                    return null;
                }

                // Assembly File 정보가 없는 경우 Return
                if (MPCF.Trim(menuInfo.s_assembly_file) == "")
                {
                    return null;
                }

                // Program인 경우 실행
                if (menuInfo.c_func_type == 'P')
                {
                    System.Diagnostics.Process.Start(menuInfo.s_assembly_file, menuInfo.s_assembly_name);
                    return null;
                }
                // 그 외의 경우
                else
                {
                    menuInfo.s_assembly_name = MPCF.Trim(menuInfo.s_assembly_name);
                    sSplit = menuInfo.s_assembly_name.Split('.');
                    oChildForm = MPCF.GetChildForm(MPGV.gfrmMDI, sSplit[sSplit.Length - 1], true, menuInfo.s_func_name);

                    // Child Form이 없는 경우
                    if (oChildForm == null)
                    {
                        sApplicationPath = Application.StartupPath;
                        asmDll = Assembly.LoadFrom(sApplicationPath + "\\" + menuInfo.s_assembly_file);

                        // Argument가 없는 경우
                        if (string.IsNullOrEmpty(menuInfo.s_args) == true)
                        {
                            oChildForm = asmDll.CreateInstance(menuInfo.s_assembly_name);
                        }
                        // Argument가 있는 경우
                        else
                        {
                            oChildForm = asmDll.CreateInstance(menuInfo.s_assembly_name, true, BindingFlags.Default, null, new string[] { menuInfo.s_args }, null, null);
                        }

                        // Assembly가 없거나 생성되지 못한 경우
                        if (oChildForm == null)
                        {
                            return null;
                        }

                        // Tag 등록
                        ((Form)oChildForm).Tag = menuInfo;

#if DEBUG
                        // EE Server에서 SAMPLE 화면에 대해서는 Security Check를 하지 않음.
                        // 단, Debug 모드에서만 적용.
                        if (menuInfo.s_func_name != "SAMPLE")
                        {
                            // Security를 확인한다.
                            if (MPCF.CheckSecurityFormControl((Form)oChildForm) == false)
                            {
                                return null;
                            }
                        }
#else
                        // Security를 확인한다.
                        if (MPCF.CheckSecurityFormControl((Form)oChildForm) == false)
                        {
                            return null;
                        }                        
#endif

                        // 화면 등록
                        ((Form)oChildForm).MdiParent = this;
                        MPGV.glOpenChildForm.Add((Form)oChildForm);

                        // Opened Menu Visible 변경
                        if (MPGV.glOpenChildForm.Count > 1)
                        {
                            pnlOpenForm.Visible = true;
                        }
                        else
                        {
                            pnlOpenForm.Visible = false;
                        }

                        // MDI Child Form의 위치를 계산
                        ((Form)oChildForm).Left = GetMainLeftForChildForm();
                        ((Form)oChildForm).Top = GetMainTopForChildForm();
                        ((Form)oChildForm).Width = GetMainWidthForChildForm();
                        ((Form)oChildForm).Height = GetMainHeightForChildForm();

                        // 배경 화면 Hide
                        if (MPGV.glOpenChildForm.Contains(MPGV.gfrmDefaultBackForm) == true)
                        {
                            MPGV.gfrmDefaultBackForm.Hide();
                        }

                        // MessageBar Clear
                        ClearMessage();

                        // 화면을 연다.
                        ((Form)oChildForm).Show();
                    }
                    // Child Form이 있는 경우
                    else
                    {
                        ((Form)oChildForm).Activate();
                    }

                    try
                    {
                        cFocusControl = null;
                        cFocusControl = (Control)oChildForm.GetType().InvokeMember("GetFirstFocusItem", BindingFlags.InvokeMethod, null, oChildForm, null);
                        return cFocusControl;
                    }
                    catch (MissingMemberException)
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return null;
            }
            finally
            {
                b_menu_opening = false;
            }
        }

        /// <summary>
        /// 화면을 Open 합니다.
        /// UI에 등록되지 않은 화면을 open할 때 사용합니다.
        /// </summary>
        public Control OpenMenu(MenuInfoTag menuInfo, Form openForm)
        {
            Control cFocusControl;
            Form fChildForm;

            try
            {
                fChildForm = MPCF.GetChildForm(MPGV.gfrmMDI, openForm.Text, true, menuInfo.s_func_name);

                // 메뉴에 등록되지 않은 화면을 open할 때 사용합니다.
                if (fChildForm == null)
                {
                    // Loading 화면 시작
                    MPGV.gIMdiForm.ShowLoadingScreen(true);

                    // 설정
                    openForm.MdiParent = this;
                    openForm.Tag = menuInfo;

                    // 등록
                    MPGV.glOpenChildForm.Add(openForm);

                    // Opened Menu Visible 변경
                    if (MPGV.glOpenChildForm.Count > 1)
                    {
                        pnlOpenForm.Visible = true;
                    }
                    else
                    {
                        pnlOpenForm.Visible = false;
                    }

                    // MDI Child Form의 위치를 계산
                    openForm.Left = GetMainLeftForChildForm();
                    openForm.Top = GetMainTopForChildForm();
                    openForm.Width = GetMainWidthForChildForm();
                    openForm.Height = GetMainHeightForChildForm();

                    // 배경 화면 Hide
                    if (MPGV.glOpenChildForm.Contains(MPGV.gfrmDefaultBackForm) == true)
                    {
                        MPGV.gfrmDefaultBackForm.Hide();
                    }

                    // MessageBar Clear
                    ClearMessage();

                    // 화면 Show
                    openForm.Show();

                    // Loading 화면 시작
                    MPGV.gIMdiForm.ShowLoadingScreen(false);

                    try
                    {
                        cFocusControl = null;
                        cFocusControl = (Control)openForm.GetType().InvokeMember("GetFirstFocusItem", BindingFlags.InvokeMethod, null, openForm, null);
                        return cFocusControl;
                    }
                    catch (MissingMemberException)
                    {
                        return null;
                    }
                }
                else
                {
                    fChildForm.Activate();
                }

                return null;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Main 화면의 Left 위치를 계산합니다.
        /// </summary>
        /// <returns></returns>
        public int GetMainLeftForChildForm()
        {
            return 1;
        }

        /// <summary>
        /// Main 화면의 Top 위치를 계산합니다.
        /// </summary>
        /// <returns></returns>
        public int GetMainTopForChildForm()
        {
            return pnlTop.Height + 1;
        }

        /// <summary>
        /// Main 화면의 Width를 계산합니다.
        /// </summary>
        /// <returns></returns>
        public int GetMainWidthForChildForm()
        {
            return this.Width - 6;
        }

        /// <summary>
        /// Main 화면의 Height를 계산합니다.
        /// </summary>
        /// <returns></returns>
        public int GetMainHeightForChildForm()
        {
            return this.Height - pnlTop.Height - pnlBottom.Height - 6;
        }

        /// <summary>
        /// Main 화면을 최대화 합니다.
        /// </summary>
        public void SetMainWindowMax()
        {            
            //Rectangle bounds = Screen.FromHandle(this.Handle).WorkingArea;
            //int x_offset = SystemInformation.HorizontalResizeBorderThickness + SystemInformation.FixedFrameBorderSize.Width;
            //int y_offset = SystemInformation.VerticalResizeBorderThickness + SystemInformation.FixedFrameBorderSize.Height;

            //bounds.X -= x_offset;
            //bounds.Width += (x_offset * 2);
            //bounds.Height += y_offset;

            //this.MaximizedBounds = bounds;

            if (Screen.FromHandle(this.Handle).Primary == true)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            }
            else
            {
                this.MaximizedBounds = new Rectangle();
            }
            
            this.WindowState = FormWindowState.Maximized;
            pbMax.Image = Properties.Resources.Main_nor;
        }

        /// <summary>
        /// Main 화면을 이전 상태로 되돌립니다.
        /// </summary>
        public void SetMainWindowNormal()
        {
            this.WindowState = FormWindowState.Normal;
            pbMax.Image = Properties.Resources.Main_max;
        }

        /// <summary>
        /// 기본적인 배경 Form을 Show 합니다.
        /// </summary>
        public void SetDefaultBackgroundForm()
        {
            // MDI Child Form의 위치를 계산
            MPGV.gfrmDefaultBackForm.MdiParent = this;
            MPGV.gfrmDefaultBackForm.Left = GetMainLeftForChildForm();
            MPGV.gfrmDefaultBackForm.Top = GetMainTopForChildForm();
            MPGV.gfrmDefaultBackForm.Width = GetMainWidthForChildForm();
            MPGV.gfrmDefaultBackForm.Height = GetMainHeightForChildForm();
            MPGV.gfrmDefaultBackForm.SetOITheme();

            // Opended Menu 제거
            pnlOpenForm.Visible = false;

            // 화면을 연다.
            MPGV.gfrmDefaultBackForm.Show();
        }

        /// <summary>
        /// Alarm Count를 변경합니다.
        /// </summary>
        public void SetDecreaseAlarmCount()
        {
            if (MPGV.gtAlarmList.Count < 1)
            {
                this.AlarmCount = 0;
            }
            else
            {
                this.AlarmCount = MPGV.gtAlarmList.Count;
            }
        }

        ///// <summary>
        ///// Timer를 설정한다.
        ///// </summary>
        //private void SetTimerHandler()
        //{
        //    if (MPGV.giVersionCheckTime > 0)
        //    {
        //        if (checkTimer == null)
        //        {
        //            checkTimer = new System.Windows.Threading.DispatcherTimer();
        //            checkTimer.Tick += new EventHandler(checkTimer_Tick);
        //        }
        //        else
        //        {
        //            checkTimer.Stop();
        //        }

        //        checkTimer.Interval = new TimeSpan(0, MPGV.giVersionCheckTime, 0);
        //        checkTimer.Start();
        //    }
        //    else
        //    {
        //        if (checkTimer != null)
        //        {
        //            checkTimer.Stop();
        //        }
        //    }

        //    if (MPGV.giLogOutTime > 0)
        //    {
        //        if (autoLogoutTimer == null)
        //        {
        //            autoLogoutTimer = new System.Windows.Threading.DispatcherTimer();
        //            autoLogoutTimer.Tick += new EventHandler(autoLogoutTimer_Tick);
        //            autoLogoutTimer.Interval = new TimeSpan(0, 1, 0);
        //        }

        //        autoLogoutTimer.Start();
        //    }
        //    else
        //    {
        //        if (autoLogoutTimer != null)
        //        {
        //            autoLogoutTimer.Stop();
        //        }
        //    }

        //}

        /// <summary>
        /// Application을 종료 합니다.
        /// </summary>
        private void LogOutApplication()
        {
            // 3초 대기
            System.Threading.Thread.Sleep(3000);

            // Logout Flag 변경
            MPGV.gbLogoutFlag = true;

            // 메인화면 종료
            this.Invoke((MethodInvoker)delegate
            {
                this.Close();
            });

            // 프로그램 종료
            Application.Exit();
        }

        /// <summary>
        /// 재시작합니다.
        /// </summary>
        public void RestartProgram()
        {
            if (MPGV.gfrmMDI != null)
            {
                MPGV.gbLogoutFlag = true;
                MPGV.gfrmMDI.Close();
                this.Close();
                Application.Exit();
                Process.Start(Application.ExecutablePath);
                MPGV.gbLogoutFlag = false;
            }
        }
        
        #endregion

        #region iMdiForm 멤버

        public Control ActiveMenu(MenuInfoTag m_menu_tag)
        {
            throw new NotImplementedException();
        }

        public void ActiveMenu(string s_func_name)
        {
            throw new NotImplementedException();
        }

        public void EnablePublishAlarm()
        {
            throw new NotImplementedException();
        }

        public void EnablePublishBBS()
        {
            throw new NotImplementedException();
        }

        public void FavoritesRefresh()
        {
            throw new NotImplementedException();
        }

        public ImageList GetSmallIconList()
        {
            return null;
        }

        public ImageList GetToolBarIconList()
        {
            throw new NotImplementedException();
        }

        public void MenuRefresh()
        {
            throw new NotImplementedException();
        }

        public void Progress_End()
        {
            throw new NotImplementedException();
        }

        public void Progress_Start()
        {
            throw new NotImplementedException();
        }

        //public bool PublishALMMsgTune()
        //{
        //    throw new NotImplementedException();
        //}

        public bool PublishBBSMsgTune()
        {
            throw new NotImplementedException();
        }

        public bool PublishSPCMsgTune()
        {
            throw new NotImplementedException();
        }

        public bool PublishUTLMsgTune()
        {
            throw new NotImplementedException();
        }

        //public void SetAlarmMessage()
        //{
        //    throw new NotImplementedException();
        //}

        public void SetBBSMessage()
        {
            throw new NotImplementedException();
        }

        public void SetPublishMessage(string s_msg)
        {
            throw new NotImplementedException();
        }

        public void SetStatusMessage(string s_msg)
        {
            throw new NotImplementedException();
        }

        public bool ViewALMPublishMessage()
        {
            throw new NotImplementedException();
        }

        public bool ViewBBSPublishMessage()
        {
            throw new NotImplementedException();
        }

        public bool ViewSPCPublishData(object SPC_Publish_Data_In)
        {
            throw new NotImplementedException();
        }

        public bool ViewSPCPublishMessage()
        {
            throw new NotImplementedException();
        }

        public bool ViewUTLPublishMessage(bool bActivated)
        {
            throw new NotImplementedException();
        }

        public bool ViewWIPTranEndLot(bool bDispatcherFlag, string sLotID, string sResourceID)
        {
            throw new NotImplementedException();
        }

        public bool ViewWIPTranMoveLot(bool bDispatcherFlag, string sLotID)
        {
            throw new NotImplementedException();
        }

        public bool ViewWIPTranSkipLot(bool bDispatcherFlag, string sLotID)
        {
            throw new NotImplementedException();
        }

        public bool ViewWIPTranStartLot(bool bDispatcherFlag, string sLotID, string sResourceID)
        {
            throw new NotImplementedException();
        }

        #endregion


        /// <summary>
        /// 1분마다 Server에 Client 상태를 전송한다.(옵션 존재 시 Printe 상태를 학인 포함)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrCheckStatuse_Tick(object sender, EventArgs e)
        {
            HQGV.giCheckCount++;

            if (HQGV.giCheckCount < HQGC.MESOI_STATUS_CHECK_TIME) return;
            HQGV.giCheckCount = 0;

            //기준정보에 등록 안된 IP 인 경우 1시간 마다 정보 전송 Check  
            if (HQGV.gbStatusCheckFlag == false)
            {
                HQGV.glStatusCheckCount++;
                if (HQGV.glStatusCheckCount < HQGC.MESOI_SERVER_CHECK_TIME) return;
                HQGV.glStatusCheckCount = 0;
            }

            // 디자인 모드에서는 종료
            if (DesignMode == true)
            {
                return;
            }

            //// Version Check Time이 설정되지 않은 경우 종료
            //if (MPGV.giVersionCheckTime < 1)
            //{
            //    return;
            //}

            // Process 중인 경우 제외
            if (MPIF.gInit.IsProcessCaster == true)
            {
                return;
            }

            // Message 전송이 불가능한 경우 종료
            if (MPIF.gInit.IsAvailableSendMessage == false)
            {
                return;
            }

            // Loging 상태인 경우 종료
            if (MPGV.gIMdiForm.GetLoginState() == true)
            {
                return;
            }

            try
            {
                HQCF.SendClientStatus();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}
