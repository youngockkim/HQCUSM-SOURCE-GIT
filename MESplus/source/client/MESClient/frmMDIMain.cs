using System;
using System.Data;
using System.Text;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Collections;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Infragistics.Win.UltraWinDock;
using Miracom.TRSCore;

#if _WIP
using Miracom.WIPCore;
#endif
#if _RAS
using Miracom.RASCore;
#endif
#if _ALM
using Miracom.ALMCore;
#endif
#if _UTL
using Miracom.UTLCore;
#endif
#if _SPC
using Miracom.SPCCore;
#endif


namespace MESClient
{
    public partial class frmMDIMain : frmMDIMainCore, intMdiFormFunction
    {
        public frmMDIMain()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const string BBS_POPUP_TYPE_OPER = "OPER";
        private const string BBS_POPUP_TYPE_RES = "RES";
        private const string BBS_POPUP_TYPE_LOGIN = "LOGIN";

        #endregion

        #region " Variable Definition "

        private bool b_load_flag = false;

        /* BBS Popup Value */
        private bool b_oper_msg_load_flag = false;
        private bool b_res_msg_load_flag = false;
        private int  i_shift_time_check = 0;
        private char c_prev_shift;
        
        #endregion

        #region " Form Event Definition"

        private void frmMDIMain_Load(System.Object sender, System.EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Width = 0;
            this.Height = 0;

            m_ImgBackPic = (new frmMDIBackPic()).pbxBackImage.Image;

            if (MPIF.gInit.LoadResource() == false)
            {
                return;
            }

            //Added by LAVERWON (2006/07/07)
            //Request Reply Retry Wait Time
            MPGV.giRequestReplyWaitTime = 30;

            //Add by J.S. 2011.10.27 for load TAB MDI
            if (MPCF.GetRegSetting(Application.ProductName, "Option", "TabbedMdi", "false") == "true")
            {
                tsmTabbedMdi.Checked = true;
                utmMain.Enabled = true;
            }
            else
            {
                tsmTabbedMdi.Checked = false;
                utmMain.Enabled = false;
            }
        }

        private void frmMDIMain_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                this.Hide();

                Rectangle rect = Screen.GetWorkingArea(Control.MousePosition);

                //Set Size & Location of MDI Form
                this.Top = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "Option", "MDI_top", "0"));
                if (this.Top < 0) this.Top = 0;
                this.Left = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "Option", "MDI_left", "0"));
                if (this.Left < 0) this.Left = 0;
                this.Width = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "Option", "MDI_width", "1024"));
                if (this.Width < 0) this.Width = 1024;
                this.Height = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "Option", "MDI_height", "768"));
                if (this.Height < 0) this.Height = 768;

                if (this.Width > rect.Width)
                    this.Width = rect.Width;
                if (this.Height > rect.Height)
                    this.Height = rect.Height;
                if (this.Top < rect.Top)
                    this.Top = rect.Top;
                if (this.Left < rect.Left)
                    this.Left = rect.Left;
                if (this.Top + this.Height > rect.Top + rect.Height)
                    this.Top = rect.Top + ((rect.Height - this.Height) / 2);
                if (this.Left + this.Width > rect.Left + rect.Width)
                    this.Left = rect.Left + ((rect.Width - this.Width) / 2);

                
                // 주의사항!
                // login이 Dispose되면서 Activated 이벤트가 다시 호출되므로 b_load_flag는 
                // 반드시 login 화면이 Display 되기 전에 셋팅 되어야 한다.
                b_load_flag = true;

                if (MPCF.GetRegSetting(Application.ProductName, "Option", "BackGroundLogin", "N") == "Y")
                {
                    bool UpgradeFlag = false;

                    if (MPCF.GetRegSetting(Application.ProductName, "Option", "BackGroundLogin", "") != "")
                        MPCF.DeleteRegSetting(Application.ProductName, "Option", "BackGroundLogin");

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

                    if (MPCR.SEC_Login_Ext(ref UpgradeFlag) == false)
                    {
                        MPGV.gbLogoutFlag = true;
                        
                        MPIF.gInit.TermMsgHandler();
                        Close();
                        Application.Exit();
                        return;
                    }
#if _HTTP
                    // Added by ICBae 2012/04/13 for Http Push Service
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
                        MPCF.SaveRegSetting(Application.ProductName, "Option", "SiteID", MPGV.gsSiteID);
                        MPCF.SaveRegSetting(Application.ProductName, "Option", "RemoteAddress", MPGV.gsRemoteAddress);
                        MPCF.SaveRegSetting(Application.ProductName, "Settings", "Factory", MPGV.gsFactory);
                        MPCF.SaveRegSetting(Application.ProductName, "Settings", "UserName", MPGV.gsUserID);
                        MPCF.SaveRegSetting(Application.ProductName, "Settings", "Password", MPGV.gsPassword);

                        if (MPIF.gInit.getMiddleware == "TIBRV")
                        {
                            MPCF.SaveRegSetting(Application.ProductName, "Option", "RvService", MPGV.gsRvService);
                            MPCF.SaveRegSetting(Application.ProductName, "Option", "RvNetwork", MPGV.gsRvNetwork);
                        }
                            else if (MPIF.gInit.getMiddleware == "H101")
                            {
                                MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode", MPGV.gsStationMode);
                            }

                        MPGV.gbLogoutFlag = true;

                        Close();
                        Application.Exit();
                        return;
                    }

                }
                else
                {

                    frmLogin login = new frmLogin();
                    if (login.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        b_load_flag = true;
                        MPGV.gbLogoutFlag = true;

                        Close();
                        Application.Exit();
                        return;
                    }
                    login.Dispose();
                }

                this.TopMost = true;
                this.Show();
                this.TopMost = false;

                if (MPCF.GetRegSetting(Application.ProductName, "Option", "BackGroundLogin", "") != "")
                    MPCF.DeleteRegSetting(Application.ProductName, "Option", "BackGroundLogin");

                if (MPCF.GetRegSetting(Application.ProductName, "Settings", "Password", "") != "")
                    MPCF.DeleteRegSetting(Application.ProductName, "Settings", "Password");

                if (MPGV.gcChangePassword == 'Y')
                {
                    Form f = new frmChangePassword();
                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        b_load_flag = true;
                        MPGV.gbLogoutFlag = true;

                        f.Dispose();
                        this.Close();
                        Application.Exit();
                        return;
                    }
                    MPGV.gcChangePassword = ' ';
                    f.Dispose();
                }

                // Added by DM KIM 2012.05.12 BBS Popup Show
                GetPopupMessage(BBS_POPUP_TYPE_LOGIN, MPGV.gsUserID, "", "", "");
                c_prev_shift = MPCR.GetCurrentShift();

                if (InitMainForm() == false) return;
            }

#if _TOOL
            if (this.ActiveMdiChild == null)
            {
            }
            else
            {
                if (this.ActiveMdiChild.Name == "frmRASTranToolEvent")
                {
                    frmRASTranToolEvent frmRASTranToolEvent = null;
                    frmRASTranToolEvent = (frmRASTranToolEvent)this.ActiveMdiChild;

                    frmRASTranToolEvent.bRunning = true;
                    frmRASTranToolEvent.DrawDefectMap();

                    frmRASTranToolEvent.bRunningClean = true;
                    frmRASTranToolEvent.DrawDefectMapClean();

                }
            }
#endif

        }

        private void frmMDIMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dResult = DialogResult.None;
            if (MPGV.gbLogoutFlag == false)
            {
                dResult = MPCF.ShowMsgBox(MPCF.GetMessage(4), Application.ProductName, MessageBoxButtons.YesNo, 2);
                if (dResult == DialogResult.No || dResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                SaveSystemMenu();
            }
            
            if (this.WindowState != FormWindowState.Minimized)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "MDI_top", this.Top.ToString());
                MPCF.SaveRegSetting(Application.ProductName, "Option", "MDI_left", this.Left.ToString());
                MPCF.SaveRegSetting(Application.ProductName, "Option", "MDI_width", this.Width.ToString());
                MPCF.SaveRegSetting(Application.ProductName, "Option", "MDI_height", this.Height.ToString());
            }

            //Add by J.S. 2011.10.27 for save TAB MDI
            if (utmMain.Enabled == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "TabbedMdi", "true");
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "TabbedMdi", "false");
            }

#if _HTTP
            MPMH.Instance.logout();
#endif
        }

        #endregion

        #region "Default Menu Event Definition"

        private void tsmLogout_Click(object sender, EventArgs e)
        {
            DialogResult dResult;

            MPGV.gbLogoutFlag = true;

            dResult = MPCF.ShowMsgBox(MPCF.GetMessage(13), Application.ProductName, MessageBoxButtons.YesNo, 2);
            if (dResult == DialogResult.No || dResult == DialogResult.Cancel)
            {
                MPGV.gbLogoutFlag = false;
                return;
            }

#if _HTTP
            MPMH.Instance.logout();
#endif

            this.Close();
            Application.Exit();

            Process.Start(Application.ExecutablePath);
            MPGV.gbLogoutFlag = false;
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword f = new frmChangePassword();
            f.ShowDialog();
            f.Dispose();
        }

        private void tsmClientUpgrade_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(11), Application.ProductName, MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (MPCR.Client_Upgrade(2) == 1)
            {
                MPGV.gbLogoutFlag = true;
                this.Close();
                Application.Exit();
            }
        }

        private void tsmOption_Click(object sender, EventArgs e)
        {
            frmOptionCore f = new frmOptionCore(true);
            f.ShowDialog();
            f.Dispose();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void tsmTabbedMdi_Click(object sender, EventArgs e)
        {
            if (tsmTabbedMdi.Checked == true)
                tsmTabbedMdi.Checked = false;
            else
                tsmTabbedMdi.Checked = true;

            utmMain.Enabled = tsmTabbedMdi.Checked;
        }

        private void tsmCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
                f.Dispose();
            }
        }

        private void tsmHelp_Click(object sender, EventArgs e)
        {
            //GetHelpURL()
            //Shell("explorer.exe http://61.106.159.83/MESplus_V32/wwhelp.htm")
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
            f.Dispose();
        }

        private void tsmMenu_Click(object sender, EventArgs e)
        {
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_MENU].Closed = false;
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_MENU].Activate();
        }

        private void tsmFavorites_Click(object sender, EventArgs e)
        {
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_FAVORITES].Closed = false;
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_FAVORITES].Activate();
        }

        private void tsmOperation_Click(object sender, EventArgs e)
        {
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_OPERATION].Closed = false;
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_OPERATION].Activate();
        }

        private void tsmResource_Click(object sender, EventArgs e)
        {
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_RESOURCE].Closed = false;
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_RESOURCE].Activate();
        }

        private void tsmDispatcher_Click(object sender, EventArgs e)
        {
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_DISPATCHER].Closed = false;
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_DISPATCHER].Activate();
        }

        private void tsmBBS_Click(object sender, EventArgs e)
        {
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_BBS].Closed = false;
            udmMain.ControlPanes[MPGC.MP_SYS_DOCK_BBS].Activate();
        }

        private void tsmInit_Click(object sender, EventArgs e)
        {
            DialogResult dResult;

            MPGV.gbLogoutFlag = true;

            try
            {
                dResult = MPCF.ShowMsgBox(MPCF.GetMessage(14), Application.ProductName, MessageBoxButtons.YesNo, 2);
                if (dResult == DialogResult.No || dResult == DialogResult.Cancel)
                {
                    MPGV.gbLogoutFlag = false;
                    return;
                }

                // Delete systemmenu.bin file
                File.Delete(Application.StartupPath+"\\SystemMenu.bin");

                this.Close();
                Application.Exit();

                Process.Start(Application.ExecutablePath);
                MPGV.gbLogoutFlag = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region " Function Definition "

        // InitMainForm()
        //       - Initialize Main Form
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        -
        //
        protected override bool InitMainForm()
        {
            try
            {
                this.TopMost = true;

                if (base.InitMainForm() == false) return false;
                if (GetAvailableFunctionList(mnuMain, 1, tolMain) == false) return false;

                SetFavoriteMenu();
                LoadSystemMenu();
                ChangeMenuText(mnuMain);
                ChangeDockText();

                if (base.InitMainFormAfter() == false) return false;

                this.TopMost = false;

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMDIMain.InitMainForm()\n" + ex.Message);
                return false;
            }
        }

        public void FavoritesRefresh()
        {
            try
            {
                if (b_can_get_favorites == false) return;

                // 즐겨찾기 메뉴를 다시 그리고
                SetFavoriteMenu();

                // 즐겨찾기 트리를 다시 그린다.
                MPCF.InitTreeView(tvFavorites);
                SetFavoritesTree();

                //2008.12.16 Add by J.S. for Refresh Toolbar
                ViewFavoritesList(tolMain);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //Add by J.S. 2009.01.07 refresh main menu after menu setup
        public void MenuRefresh()
        {
            int i_menu_count;

            try
            {
                i_menu_count = mnuMain.Items.Count;
                for (int i = 0; i < i_menu_count; i++)
                {
                    if (mnuMain.Items.Count > 3)
                    {
                        foreach (ToolStripMenuItem menu in mnuMain.Items)
                        {
                            if (MPCF.RTrim(menu.Tag) != "")
                            {
                                mnuMain.Items.Remove(menu);
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (GetAvailableFunctionList(mnuMain, 1, tolMain) == false)
                {
                    return;
                }

                // Menu Tree를 다시 그린다.
                MPCF.InitTreeView(tvMenu);
                SetMenuTree();
                SetFavoriteMenu();
                // 메뉴 변경 후 설정 언어로 메뉴명 변경
                ChangeMenuText(mnuMain);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public Control ActiveMenu(MenuInfoTag m_menu_tag)
        {
            return ExecuteMenu(m_menu_tag);
        }

        public void ActiveMenu(string s_func_name)
        {
            ToolStripMenuItem m_find_menu;

            try
            {
                if (MPCF.Trim(s_func_name) == "") return;

                m_find_menu = null;
                foreach (ToolStripMenuItem menu in mnuMain.Items)
                {
                    if (menu.Tag == null) continue;

                    m_find_menu = null;
                    m_find_menu = FindMenuItem(s_func_name, menu);
                    if (m_find_menu != null)
                        break;
                }

                if (m_find_menu != null)
                    m_find_menu.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private ToolStripMenuItem FindMenuItem(string s_func_name, ToolStripMenuItem menu)
        {
            MenuInfoTag m_menu_tag;
            ToolStripMenuItem m_menu_item;
            ToolStripMenuItem m_find_menu;
            int i;

            try
            {
                if (menu.Tag != null)
                {
                    m_menu_tag = (MenuInfoTag)menu.Tag;
                    if (!(m_menu_tag.Equals(null)))
                        if (MPCF.Trim(m_menu_tag.s_assembly_name) != "")
                            if (MPCF.Trim(m_menu_tag.s_func_name) == s_func_name)
                                return menu;
                }

                m_find_menu = null;
                for (i = 0; i < menu.DropDownItems.Count; i++)
                {
                    if (menu.DropDownItems[i] is ToolStripMenuItem)
                    {
                        m_menu_item = (ToolStripMenuItem)menu.DropDownItems[i];

                        m_find_menu = null;
                        m_find_menu = FindMenuItem(s_func_name, m_menu_item);
                        if (m_find_menu != null)
                            break;
                    }
                }

                return m_find_menu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        
        private bool LoadSystemMenu()
        {

            string filename = "SystemMenu.bin";
            System.IO.FileStream stream = null;

            try
            {
                // Keep docking Menu text 
                foreach (DockableControlPane DockPan in udmMain.ControlPanes)
                    DockPan.Tag = DockPan.Text;

                stream = new System.IO.FileStream(Application.StartupPath + "\\" + filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                udmMain.LoadFromBinary(stream);

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return true;
        }

        private bool SaveSystemMenu()
        {

            string filename = "SystemMenu.bin";
            System.IO.FileStream stream = null;
            try
            {
                stream = new System.IO.FileStream(Application.StartupPath + "\\" + filename, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
                this.udmMain.SaveAsBinary(stream);

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return true;
        }

        private void SetFavoriteMenu()
        {
            if (b_can_get_favorites == false) return;

            ListView lisTmp;
            MenuInfoTag m_menu_tag;
            ToolStripMenuItem favorite_top_menu;
            ToolStripMenuItem favorite_menu;

            favorite_top_menu = null;
            foreach (ToolStripMenuItem top_menu in mnuMain.Items)
            {
                if (top_menu.Tag == null) continue;

                m_menu_tag = (MenuInfoTag)top_menu.Tag;
                if (m_menu_tag.s_func_name == "TOP0005")
                {
                    favorite_top_menu = top_menu;
                    break;
                }
            }
            if (favorite_top_menu == null) return;

            for (int i = 0; i < favorite_top_menu.DropDownItems.Count; i++)
            {
                if (!(favorite_top_menu.DropDownItems[i] is ToolStripMenuItem)) continue;

                favorite_menu = (ToolStripMenuItem)favorite_top_menu.DropDownItems[i];
                if (((MenuInfoTag)(favorite_menu.Tag)).s_func_name.IndexOf("FAV") < 0)
                {
                    favorite_top_menu.DropDownItems.Remove(favorite_menu);
                    i--;
                }
            }

            // 즐겨찾기 TOP메뉴에 하위 메뉴가 존재하고 마지막이 메뉴라면 구분선 추가
            if (favorite_top_menu.DropDownItems.Count > 0)
                if (favorite_top_menu.DropDownItems[favorite_top_menu.DropDownItems.Count - 1] is ToolStripMenuItem)
                    favorite_top_menu.DropDownItems.Add(new ToolStripSeparator());

            lisTmp = new ListView();
            lisTmp.View = View.Details;

            lisTmp.Columns.Add(new ColumnHeader());
            lisTmp.Columns.Add(new ColumnHeader());
            SECLIST.ViewFavoritesList(lisTmp, '1', MPGV.gsProgramID, null, "");

            foreach (ListViewItem lis in lisTmp.Items)
            {
                m_menu_tag = (MenuInfoTag)lis.Tag;

                favorite_menu = new ToolStripMenuItem();
                favorite_menu.Tag = m_menu_tag;
                favorite_menu.Text = lis.SubItems[1].Text;
                favorite_menu.Click += new EventHandler(ToolStripMenuItem_Click);
                favorite_top_menu.DropDownItems.Add(favorite_menu);
            }

            if (MPGV.gTitleColor.IsEmpty == false)
                tolMain.BackColor = MPGV.gTitleColor;
        }

        private void ChangeDockText()
        {
            if (udmMain == null) return;
            foreach (DockableControlPane DockPan in udmMain.ControlPanes)
            {
                if (MPCF.Trim(DockPan.Tag) == "")
                {
                    if (DockPan.Key == MPGC.MP_SYS_DOCK_MENU)
                        DockPan.Tag = "Menu";
                    else if (DockPan.Key == MPGC.MP_SYS_DOCK_DISPATCHER)
                        DockPan.Tag = "Dispatcher";
                    else if (DockPan.Key == MPGC.MP_SYS_DOCK_FAVORITES)
                        DockPan.Tag = "Favorites";
                    else if (DockPan.Key == MPGC.MP_SYS_DOCK_OPERATION)
                        DockPan.Tag = "Operation";
                    else if (DockPan.Key == MPGC.MP_SYS_DOCK_RESOURCE)
                        DockPan.Tag = "Resource";
                    else if (DockPan.Key == MPGC.MP_SYS_DOCK_BBS)
                        DockPan.Tag = "Bulletin Board";
                }

                DockPan.Text = MPCF.FindLanguage(MPCF.Trim(DockPan.Tag), 0);
            }

        }


#if _UTL
        public bool PublishUTLMsgTune()
        {

            try
            {
                if (MPCR.PublishUTLMsgTune() == false)
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

        public bool ViewUTLPublishMessage(bool bActivated)
        {

            try
            {
                Form f;

                f = MPCF.GetChildForm(this, "frmUTLPublishMessage", false);

                if (bActivated == true)
                {
                    if (f == null)
                    {
                        MPGV.gbShowMessagePanel = true;
                    }
                    else
                    {
                        MPGV.gbShowMessagePanel = false;
                        ((frmUTLPublishMessage)f).SetMessageEvent(MPGV.gsMessage);
                    }
                }
                else
                {
                    if (f == null)
                    {
                        f = new frmUTLPublishMessage();
                        f.MdiParent = this;
                        f.Show();
                        ((frmUTLPublishMessage)f).SetMessageEvent(MPGV.gsMessage);
                    }
                    else
                    {
                        ((frmUTLPublishMessage)f).SetMessageEvent(MPGV.gsMessage);
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
#endif

#if _ALM
        public bool PublishALMMsgTune()
        {

            try
            {
                if (MPCR.PublishALMMsgTune() == false)
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

        public bool ViewALMPublishMessage()
        {

            Form f;

            try
            {
                f = MPCF.GetChildForm(this, "frmALMPublishMessage");

                if (f == null)
                {
                    f = new frmALMPublishMessage();
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    ((frmALMPublishMessage)f).b_load_flag = false;
                    f.Activate();
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
#endif

#if _SPC
#if _HTTP
        public bool PublishSPCMsgTune()
        {
            return true;
        }

        public bool ViewSPCPublishData(object SPC_Publish_Data_In)
        {
            return true;
        }

        public bool ViewSPCPublishMessage()
        {
            return true;
        }
#else
        public bool PublishSPCMsgTune()
        {

            try
            {
                if (MPCR.PublishSPCMsgTune() == false)
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

        public bool ViewSPCPublishData(object SPC_Publish_Data_In)
        {

            try
            {
                if (Miracom.SPCCore.modSPCFunctions.SPC_Publish_Data((TRSNode)SPC_Publish_Data_In) == MPGC.MP_FAIL_STATUS)
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

        public bool ViewSPCPublishMessage()
        {

            Form f;

            try
            {
                f = MPCF.GetChildForm(this, "frmSPCAlarmDisplay");

                if (f == null)
                {
                    f = new frmSPCAlarmDisplay();
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    ((frmSPCAlarmDisplay)f).b_load_flag = false;
                    f.Activate();
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
#endif
#endif

        public ImageList GetSmallIconList()
        {
            ImageList imlTemp;

            imlTemp = new ImageList();
            imlTemp.ColorDepth = imlSmallIcon.ColorDepth;
            imlTemp.ImageSize = imlSmallIcon.ImageSize;
            imlTemp.TransparentColor = imlSmallIcon.TransparentColor;
            for (int i = 0; i < imlSmallIcon.Images.Count; i++)
            {
                imlTemp.Images.Add(imlSmallIcon.Images[i]);
            }
            return imlTemp;
        }

        public ImageList GetToolBarIconList()
        {
            ImageList imlTemp;

            imlTemp = new ImageList();
            imlTemp.ColorDepth = imlToolBar.ColorDepth;
            imlTemp.ImageSize = imlToolBar.ImageSize;
            imlTemp.TransparentColor = imlToolBar.TransparentColor;
            for (int i = 0; i < imlToolBar.Images.Count; i++)
            {
                imlTemp.Images.Add(imlToolBar.Images[i]);
            }
            return imlTemp;
        }

        /* Added by DM KIM 2012.05.08 BBS Popup Message 관련 Start */
        private bool GetPopupMessage(string sCase, string s_user_id, string s_oper, string s_area_id, string s_sub_area_id)
        {
            if (sCase == BBS_POPUP_TYPE_LOGIN)
            {
                MPCR.PopupInformNote(null, s_user_id, "", "", "", "", "");
                return true;
            }

            TRSNode out_node = new TRSNode("VIEW_BBS_MSG_LIST_OUT");
            int i_msg_cnt = 0;

            b_oper_msg_load_flag = false;
            b_res_msg_load_flag = false;
            btnOperMsg.Visible = false;
            btnOperMsg.Tag = null;
            btnResMsg.Visible = false;
            btnResMsg.Tag = null;
            tmrGotMessage.Stop();
            tmrGotMessage.Enabled = false;

            try
            {
                switch (sCase)
                {
                    case BBS_POPUP_TYPE_OPER:
                        if (BASLIST.ViewBBSMsgList(out_node, "", "", s_oper) == false)
                        {
                            return false;
                        }
                        break;
                    case BBS_POPUP_TYPE_RES:
                        if (BASLIST.ViewBBSMsgList(out_node, s_area_id, s_sub_area_id) == false)
                        {
                            return false;
                        }
                        break;
                }

                i_msg_cnt = out_node.GetList("MSG_LIST").Count;
                if (i_msg_cnt > 0)
                {
                    out_node.SetString("__OPER", s_oper);
                    out_node.SetString("__AREA_ID", s_area_id);
                    out_node.SetString("__SUB_AREA_ID", s_sub_area_id);

                    if (sCase == BBS_POPUP_TYPE_OPER)
                    {
                        b_oper_msg_load_flag = true;
                        btnOperMsg.Tag = out_node;
                        tmrGotMessage.Enabled = true;
                        tmrGotMessage.Start();
                    }
                    else if (sCase == BBS_POPUP_TYPE_RES)
                    {
                        b_res_msg_load_flag = true;
                        btnResMsg.Tag = out_node;
                        tmrGotMessage.Enabled = true;
                        tmrGotMessage.Start();
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

        private void btnMsg_Click(object sender, EventArgs e)
        {
            TRSNode out_node;
            Button btnTemp;

            string s_oper = "";
            string s_area_id = "";
            string s_sub_area_id = "";
            out_node = null;

            try
            {
                btnTemp = (Button)sender;
                if(btnTemp.Name == "btnOperMsg")
                {
                    out_node = (TRSNode)btnOperMsg.Tag;
                    s_oper = out_node.GetString("__OPER");
                }
                else if (btnTemp.Name == "btnResMsg")
                {
                    out_node = (TRSNode)btnResMsg.Tag;
                    s_area_id = out_node.GetString("__AREA_ID");
                    s_sub_area_id = out_node.GetString("__SUB_AREA_ID");
                }

                if (out_node != null)
                {
                    MPCR.PopupInformNote(out_node, "", "", s_oper, s_area_id, s_sub_area_id, "");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void tmrGotMessage_Tick(object sender, EventArgs e)
        {
            /* Added by DM KIM 2012.05.07 View Popup Msg List*/

            if (b_oper_msg_load_flag == true)
            {
                btnOperMsg.Visible = true;
                if (btnOperMsg.BackColor.Equals(Color.LemonChiffon) == true)
                {
                    btnOperMsg.BackColor = Color.Salmon;
                }
                else
                {
                    btnOperMsg.BackColor = Color.LemonChiffon;
                }
            }
            else
            {
                btnOperMsg.Visible = false;
            }

            if (b_res_msg_load_flag == true)
            {
                btnResMsg.Visible = true;
                if (btnResMsg.BackColor.Equals(Color.LemonChiffon) == true)
                {
                    btnResMsg.BackColor = Color.Salmon;
                }
                else
                {
                    btnResMsg.BackColor = Color.LemonChiffon;
                }
            }
            else
            {
                btnResMsg.Visible = false;
            }
        }

        private void tmrShiftCheck_Tick(object sender, EventArgs e)
        {
            if (MPGV.gbProcessCaster == true) return;
            if (MPIF.gInit.IsAvailableSendMessage == false) return;

            i_shift_time_check++;

            if (i_shift_time_check == 60 * 10) // 10 minutes
            {
                char c_cur_shift = MPCR.GetCurrentShift();
                if (c_prev_shift != c_cur_shift)
                {
                    GetPopupMessage(BBS_POPUP_TYPE_LOGIN, MPGV.gsUserID, "", "", "");
                    c_prev_shift = c_cur_shift;
                }
                i_shift_time_check = 0;
            }
        }

        // Add by DM KIM 2012.05.09 BBS Message Publish 
        public bool PublishBBSMsgTune()
        {
            try
            {
                if (MPCR.PublishBBSMsgTune() == false)
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

        public bool ViewBBSPublishMessage()
        {
            MPGV.giBBSMessageCnt = 0;
            MPCR.PopupInformNote(null, MPGV.gsUserID, "", "", "", "", "");
            return true;
        }

        /* Added by DM KIM 2012.05.08 BBS Popup Message 관련 End */
        #endregion

        #region " Left Main Routine"

        private void udmMain_PaneDisplayed(object sender, PaneDisplayedEventArgs e)
        {
            if (e.Pane.Key == MPGC.MP_SYS_DOCK_MENU)
            {
                if (pnlMenu.Tag == null)
                {
                    MPCF.InitTreeView(tvMenu);

                    SetMenuTree();
                    pnlMenu.Tag = 'Y';
                }
            }
            else if (e.Pane.Key == MPGC.MP_SYS_DOCK_FAVORITES)
            {
                if (pnlFavorites.Tag == null)
                {
                    MPCF.InitTreeView(tvFavorites);

                    SetFavoritesTree();
                    pnlFavorites.Tag = 'Y';
                }
            }
            else if (e.Pane.Key == MPGC.MP_SYS_DOCK_OPERATION)
            {
                if (pnlOperation.Tag == null)
                {
                    MPCF.InitTreeView(tvOper);

                    SetOperationTree();
                    pnlOperation.Tag = 'Y';
                }
            }
            else if (e.Pane.Key == MPGC.MP_SYS_DOCK_RESOURCE)
            {
                if (pnlResource.Tag == null)
                {
                    MPCF.InitTreeView(tvResource);

                    SetResourceTree();
                    pnlResource.Tag = 'Y';
                }
            }
            else if (e.Pane.Key == MPGC.MP_SYS_DOCK_BBS)
            {
                if (pnlBBS.Tag == null)
                {
                    MPCF.InitTreeView(tvBBS);

                    SetBBSTree();
                    pnlBBS.Tag = 'Y';
                }
            }
#if _RTD
            else if (e.Pane.Key == MPGC.MP_SYS_DOCK_DISPATCHER)
            {
                if (pnlDispatcher.Tag == null)
                {
                    MPCF.InitTreeView(tvDispatcher);

                    SetDispatcherTree();
                    pnlDispatcher.Tag = 'Y';
                }
            }
#endif
        }

        private void SetMenuTree()
        {
            try
            {
                TreeNode node;

                tvMenu.ShowRootLines = false;
                node = tvMenu.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                SECLIST.ViewFunctionList(tvMenu, MPGV.gsProgramID, MPGV.gsUserGroup, node, false);
                node.ExpandAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void SetFavoritesTree()
        {
            try
            {
                if (b_can_get_favorites == false) return;

                TreeNode node;

                //Favorites Setting
                tvFavorites.ShowRootLines = false;
                node = tvFavorites.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                SECLIST.ViewFavoritesList(tvFavorites, '1', MPGV.gsProgramID, node, "");
                node.ExpandAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void SetResourceTree()
        {
            try
            {
                TreeNode node;

                //Resource Setting
                tvResource.ShowRootLines = false;
                node = tvResource.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                SetResourceTreeItem(node);
                node.Expand();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //Add by J.S. 2009.04.02
        private void SetBBSTree()
        {
            try
            {
                TreeNode node;

                //BBS Setting
                tvBBS.ShowRootLines = false;
                node = tvBBS.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                SetBBSTreeItem(node);
                node.Expand();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private void SetOperationTree()
        {
            try
            {
                TreeNode node;

                //Operation Setting
                tvOper.ShowRootLines = false;
                node = tvOper.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                WIPLIST.ViewOperationList(tvOper, '1', "", 0, "", "", node, "");
                node.ExpandAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
#if _RTD
        private void SetDispatcherTree()
        {

            try
            {
#if _HTTP
                // 현재 RTD 사용하지 않음
#else
                TreeNode node;

                //Dispatcher Setting
                tvDispatcher.ShowRootLines = false;
                node = tvDispatcher.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                RTDLIST.ViewDispatcherList(tvDispatcher, '2', node, "");
                node.ExpandAll();
#endif

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
#endif
        private void SetResourceTreeItem(TreeNode ParentNode)
        {
            if (BASLIST.ViewGCMDataList(tvResource, '1', MPGC.MP_RAS_AREA_CODE, (int)SMALLICON_INDEX.IDX_AREA, ParentNode, "", true, -1, -1, null) == true)
            {
                return;
            }
        }

        //Add by J.S. 2009.04.02
        private void SetBBSTreeItem(TreeNode ParentNode)
        {
            if (BASLIST.ViewGCMDataList(tvResource, '1', "BBS_MAIN_MENU", (int)SMALLICON_INDEX.IDX_AREA, ParentNode, "", true, -1, -1, null) == true)
            {
                foreach (TreeNode AreaNode in ParentNode.Nodes)
                {
                    if (AreaNode != null)
                    {
                        //Modify by J.S. 2009.04.02 for get subarea that included at area
                        if (BASLIST.ViewGCMDataList_AREA(tvBBS, '1', "BBS_SUB_MENU", (int)SMALLICON_INDEX.IDX_SUB_AREA, AreaNode, "", true, -1, -1, null, MPCF.SubtractString(AreaNode.Text, ":", false, false)) == false)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void tvMenu_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Tag == null) return;

            tvMenu.Tag = ExecuteMenu((MenuInfoTag)e.Node.Tag);
        }

        private void tvMenu_Enter(object sender, System.EventArgs e)
        {
            try
            {
                if (tvMenu.Tag == null) return;

                if (tvMenu.Tag is Control)
                    ((Control)tvMenu.Tag).Focus();

                tvMenu.Tag = null;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        
        private void tvFavorites_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Tag == null) return;

            tvFavorites.Tag = ExecuteMenu((MenuInfoTag)e.Node.Tag);
        }

        private void tvFavorites_Enter(object sender, System.EventArgs e)
        {
            try
            {
                if (tvFavorites.Tag == null) return;

                if (tvFavorites.Tag is Control)
                    ((Control)tvFavorites.Tag).Focus();

                tvFavorites.Tag = null;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

#if _RAS
        private void tvResource_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Text == MPGV.gsFactory) return;
            if (e.Node.Level > 2) return;
            if (e.Node.Level == 1 && e.Node.GetNodeCount(true) > 0) return;

            if (e.Node.Level == 1 && e.Node.GetNodeCount(true) < 1)
            {
                if (BASLIST.ViewGCMDataList_AREA(tvResource, '1', MPGC.MP_RAS_SUBAREA_CODE, (int)SMALLICON_INDEX.IDX_SUB_AREA, e.Node, "", true, -1, -1, null, MPCF.SubtractString(e.Node.Text, ":", false, false)) == false)
                {
                    return;
                }

                if (e.Node.GetNodeCount(true) > 0)
                {
                    return;
                }
            }

            string s_area_id;
            string s_sub_area_id;
            frmResourceListMain frmResList = null;

            try
            {
                frmResList = (frmResourceListMain)MPCF.GetChildForm(this, "frmResourceListMain", false);
                if (frmResList == null)
                {
                    frmResList = new frmResourceListMain();
                    frmResList.MdiParent = this;
                }

                s_area_id = "";
                s_sub_area_id = "";
                
                if (e.Node.Level == 1)
                {
                    s_area_id = MPCF.SubtractString(e.Node.Text, ":", false, false);
                    //s_sub_area_id = MPCF.SubtractString(e.Node.Text, ":", false, false);
                }
                else if (e.Node.Level == 2)
                {
                    s_area_id = MPCF.SubtractString(e.Node.Parent.Text, ":", false, false);
                    s_sub_area_id = MPCF.SubtractString(e.Node.Text, ":", false, false);
                }

                GetPopupMessage(BBS_POPUP_TYPE_RES, "", "", s_area_id, s_sub_area_id);

                frmResList.SetArea(s_area_id, s_sub_area_id, m_MDIClient.Width, m_MDIClient.Height);
                frmResList.Show();
                tvResource.Tag = frmResList.GetFisrtFocusItem();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
#endif
        private void tvResource_Enter(object sender, System.EventArgs e)
        {
            try
            {
                if (tvResource.Tag == null) return;

                if (tvResource.Tag is Control)
                    ((Control)tvResource.Tag).Focus();

                tvResource.Tag = null;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //Add by J.S. 2009.04.03 for BBS
        private void tvBBS_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Text == MPGV.gsFactory) return;
            if (e.Node.GetNodeCount(true) > 0) return;

            string s_main_menu_id;
            string s_sub_menu_id;
            frmBBSMain frmBBSList = null;

            try
            {
                frmBBSList = (frmBBSMain)MPCF.GetChildForm(this, "frmBBSMain", false);
                if (frmBBSList == null)
                {
                    frmBBSList = new frmBBSMain();
                    frmBBSList.MdiParent = this;
                }

                s_main_menu_id = MPCF.SubtractString(e.Node.Parent.Text, ":", false, false);
                s_sub_menu_id = MPCF.SubtractString(e.Node.Text, ":", false, false);

                frmBBSList.SetMenuID(s_main_menu_id, s_sub_menu_id, m_MDIClient.Width, m_MDIClient.Height);
                frmBBSList.Show();
                tvBBS.Tag = frmBBSList.GetFisrtFocusItem();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }


        private void tvBBS_Enter(object sender, System.EventArgs e)
        {
            try
            {
                if (tvBBS.Tag == null) return;

                if (tvBBS.Tag is Control)
                    ((Control)tvBBS.Tag).Focus();

                tvBBS.Tag = null;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void tvOper_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Text == MPGV.gsFactory) return;
            if (e.Node.Level < 1) return;

            string s_oper;
            frmLotListMain frmLotList = null;

            try
            {
                frmLotList = (frmLotListMain)MPCF.GetChildForm(this, "frmLotListMain", false);
                if (frmLotList == null)
                {
                    frmLotList = new frmLotListMain();
                    frmLotList.MdiParent = this;
                }

                s_oper = MPCF.SubtractString(e.Node.Text, ":", false, false);

                GetPopupMessage(BBS_POPUP_TYPE_OPER, "", s_oper, "", "");

                frmLotList.SetOperation(s_oper, m_MDIClient.Width, m_MDIClient.Height);
                frmLotList.Show();
                frmLotList.Activate();
                tvOper.Tag = frmLotList.GetFisrtFocusItem();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tvOper_Enter(object sender, System.EventArgs e)
        {
            try
            {
                if (tvOper.Tag == null) return;

                if (tvOper.Tag is Control)
                    ((Control)tvOper.Tag).Focus();

                tvOper.Tag = null;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        
        private void tvDispatcher_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
#if _RTD
            if (e.Node == null) return;
            if (e.Node.Text == MPGV.gsFactory) return;
            if (e.Node.Level < 1) return;

            string s_dsp_id;
            string s_dsp_desc;
            string s_dsp_type;
            frmLotListbyDispatcher frmLotListbyDispatcher = null;

            try
            {
                frmLotListbyDispatcher = (frmLotListbyDispatcher)MPCF.GetChildForm(this, "frmLotListbyDispatcher", false);
                if (frmLotListbyDispatcher == null)
                {
                    frmLotListbyDispatcher = new frmLotListbyDispatcher();
                    frmLotListbyDispatcher.MdiParent = this;
                }

                s_dsp_id = MPCF.SubtractString(e.Node.Text, ":", false, false);
                s_dsp_desc = MPCF.SubtractString(e.Node.Text, ":", true, false);
                s_dsp_type = MPCF.Trim(e.Node.Tag);

                frmLotListbyDispatcher.SetDispatcher(s_dsp_id, s_dsp_desc, s_dsp_type, m_MDIClient.Width, m_MDIClient.Height);
                frmLotListbyDispatcher.Show();
                tvDispatcher.Tag = frmLotListbyDispatcher.GetFisrtFocusItem();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif
        }

        private void tvDispatcher_Enter(object sender, System.EventArgs e)
        {
#if _RTD
            try
            {
                if (tvDispatcher.Tag == null) return;

                if (tvDispatcher.Tag is Control)
                    ((Control)tvDispatcher.Tag).Focus();

                tvDispatcher.Tag = null;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif
        }

        private void tvMenu_Click(object sender, EventArgs e)
        {
            tvMenu.SelectedNode = null;
        }

        private void tvFavorites_Click(object sender, EventArgs e)
        {
            tvFavorites.SelectedNode = null;
        }

        private void tvOper_Click(object sender, EventArgs e)
        {
            tvOper.SelectedNode = null;
        }

        private void tvResource_Click(object sender, EventArgs e)
        {
            tvResource.SelectedNode = null;
        }

        //Add by J.S. 2009.04.03
        private void tvBBS_Click(object sender, EventArgs e)
        {
            tvBBS.SelectedNode = null;
        }

        private void tvDispatcher_Click(object sender, EventArgs e)
        {
            tvDispatcher.SelectedNode = null;
        }

        private void btnMenuRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitTreeView(tvMenu);
                SetMenuTree();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnFavoritesRefresh_Click(System.Object sender, System.EventArgs e)
        {
            FavoritesRefresh();
        }

        private void btnResourceRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitTreeView(tvResource);
                SetResourceTree();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnBBSRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitTreeView(tvBBS);
                SetBBSTree();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnOperationRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitTreeView(tvOper);
                SetOperationTree();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDispatcherRefresh_Click(System.Object sender, System.EventArgs e)
        {
#if _RTD
            try
            {
                MPCF.InitTreeView(tvDispatcher);
                SetDispatcherTree();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif
        }

        #endregion

        #region "RTD Module - View WIP Transaction"

#if _RTD
        public bool ViewWIPTranStartLot(bool bDispatcherFlag, string sLotID, string sResourceID)
        {

            try
            {
                Form form = MPCF.GetChildForm(this, "frmWIPTranStartLot");

                if (form == null)
                {
                    form = new frmWIPTranStartLot();
                }

                ((frmWIPTranStartLot)form).bDispatcherFlag = bDispatcherFlag;
                ((frmWIPTranStartLot)form).sLotID = sLotID;
                ((frmWIPTranStartLot)form).sResourceID = sResourceID;
                form.MdiParent = this;
                form.Show();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        public bool ViewWIPTranEndLot(bool bDispatcherFlag, string sLotID, string sResourceID)
        {

            try
            {
                Form form = MPCF.GetChildForm(this, "frmWIPTranEndLot");

                if (form == null)
                {
                    form = new frmWIPTranEndLot();
                }

                ((frmWIPTranEndLot)form).bDispatcherFlag = bDispatcherFlag;
                ((frmWIPTranEndLot)form).sLotID = sLotID;
                ((frmWIPTranEndLot)form).sResourceID = sResourceID;
                form.MdiParent = MPGV.gfrmMDI;
                form.Show();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        public bool ViewWIPTranMoveLot(bool bDispatcherFlag, string sLotID)
        {

            try
            {
                Form form = MPCF.GetChildForm(this, "frmWIPTranMoveLot");
                if (form == null)
                {
                    form = new frmWIPTranMoveLot();
                }
                ((frmWIPTranMoveLot)form).bDispatcherFlag = bDispatcherFlag;
                ((frmWIPTranMoveLot)form).sLotID = sLotID;
                form.MdiParent = MPGV.gfrmMDI;
                form.Show();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        public bool ViewWIPTranSkipLot(bool bDispatcherFlag, string sLotID)
        {

            try
            {
                Form form = MPCF.GetChildForm(this, "frmWIPTranSkipLot");
                if (form == null)
                {
                    form = new frmWIPTranSkipLot();
                }
                ((frmWIPTranSkipLot)form).bDispatcherFlag = bDispatcherFlag;
                ((frmWIPTranSkipLot)form).sLotID = sLotID;
                form.MdiParent = MPGV.gfrmMDI;
                form.Show();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
#endif

        #endregion

    }
}

