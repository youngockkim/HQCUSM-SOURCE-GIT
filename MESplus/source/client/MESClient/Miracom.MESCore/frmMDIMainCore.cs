using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;
using System.Threading;

namespace Miracom.MESCore
{
    public partial class frmMDIMainCore : Form
    {
        delegate void SetAlarmMessageDelegate();
        delegate void SetBBSMessageDelegate();

        private SetAlarmMessageDelegate _SetAlarmMessageDelegate;
        private SetBBSMessageDelegate _SetBBSMessageDelegate;

        public frmMDIMainCore()
        {
            InitializeComponent();

            _SetAlarmMessageDelegate = new SetAlarmMessageDelegate(SetAlarm);
            _SetBBSMessageDelegate = new SetBBSMessageDelegate(SetBBS);
        }

        #region " Constant Definition "

        #endregion
        
        #region " Variable Definition "
        
        protected Control m_MDIClient = new Control();
        protected Image m_ImgBackPic;
        protected string sOldStatusMsg;
        protected int i_display_index = 0;
        protected bool b_can_get_favorites = true;

        private int i_version_timer_tick_check = 0;
        private bool b_process_to_generate_menu = false;
        private bool b_is_start_ver_chk = false;
        private List<string> ls_last_open_func_names;

        private delegate void ProgressStartCallback();
        private delegate void ProgressStopCallback();


        #endregion
        
        #region "Form Event Definition"
        
        private void frmMDIMainCore_Load(object sender, System.EventArgs e)
        {
            if (this.DesignMode == true) return;
            
            //Call the method that changes the background color.
            SetBackGroundColorOfMDIForm();
            
            //tmrProgress  처리
            Progress_End();

            ls_last_open_func_names = new List<string>();
        }

        private void frmMDIMainCore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DesignMode == true) return;

            int i_seq;
            string s_func_name;

            if (this.ActiveMdiChild == null)
            {
                int i;
                int i_count = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "LastOpenFuncList", "Count", ""));

                for (i = 0; i < i_count; i++)
                {
                    MPCF.DeleteRegSetting(Application.ProductName, "LastOpenFuncList", "FuncName" + i.ToString());
                }
                MPCF.DeleteRegSetting(Application.ProductName, "LastOpenFuncList", "Count");
            }
            else
            {
                i_seq = 0;
                foreach (Form cForm in this.MdiChildren)
                {
                    s_func_name = MPCF.Trim(cForm.Tag);
                    if (s_func_name != "")
                    {
                        MPCF.SaveRegSetting(Application.ProductName, "LastOpenFuncList", "FuncName" + i_seq.ToString(), s_func_name);
                        i_seq++;
                    }
                }

                MPCF.SaveRegSetting(Application.ProductName, "LastOpenFuncList", "Count", i_seq.ToString());
            }
        }

        private void frmMDIMainCore_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void frmMDIMainCore_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                this.Text = Application.ProductName + " [" + MPGV.gsSiteNickName + "]";
            }
            else
            {
                this.Text = Application.ProductName + " [" + MPGV.gsSiteNickName + ", " + this.ActiveMdiChild.Text + "]";
            }
        }

        private void lblAlarm_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (MPGV.gsAlarmType == "ALM")
                {
#if _ALM
                    if (MPGV.gIMdiForm.ViewALMPublishMessage() == false)
                    {
                        return;
                    }
#endif
                }
                else if (MPGV.gsAlarmType == "SPC")
                {
#if _SPC
                    if (MPGV.gIMdiForm.ViewSPCPublishMessage() == false)
                    {
                        return;
                    }
#endif // _SPC
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void tmrAlarm_Tick(object sender, System.EventArgs e)
        {
            if (this.DesignMode == true) return;

            if (MPGV.gsAlarmType == "ALM")
            {
                #if _ALM
                if (MPGV.giAlarmCnt > 0)
                {
                    pnlAlarm.Size = new System.Drawing.Size(pnlAlarm.Size.Width, 23);
                    pnlAlarm.Visible = true;

                    //if (MPCF.Trim(lblAlarm.Text) == "")
                    //{
                    //    lblAlarm.Text = MPGV.gtAlarmList[MPGV.giAlarmCnt-1].alarm_msg;
                    //}
                    if (pnlAlarm.BackColor.Equals(Color.PaleGreen) == true)
                    {
                        pnlAlarm.BackColor = Color.LemonChiffon;
                        lblAlarm.BackColor = Color.LemonChiffon;
                    }
                    else
                    {
                        pnlAlarm.BackColor = Color.PaleGreen;
                        lblAlarm.BackColor = Color.PaleGreen;
                    }
                    if (lblAlarm.Right <= 0)
                    {
                        lblAlarm.Left = pnlAlarm.Right;
                        //i_display_index++;
                        //if (i_display_index >= MPGV.giAlarmCnt)
                        //{
                        //    i_display_index = 0;
                        //}
                        //lblAlarm.Text = MPGV.gtAlarmList[i_display_index].alarm_msg;

                    }
                    else
                    {
                        lblAlarm.Left = lblAlarm.Left - 30;
                    }
                    
                }
                else
                {
                    pnlAlarm.Size = new System.Drawing.Size(pnlAlarm.Size.Width, 0);
                    pnlAlarm.Visible = false;
                    lblAlarm.Text = "";
                }
                #endif // _ALM
            }
            else if (MPGV.gsAlarmType == "SPC")
            {
                #if _SPC
                if (MPGV.giSPCAlarmCnt > 0)
                {
                    pnlAlarm.Size = new System.Drawing.Size(pnlAlarm.Size.Width, 23);
                    pnlAlarm.Visible = true;
                    
                    if (MPGV.gcLanguage == '2')
                    {
                        lblAlarm.Text = MPGV.gsMessageData[1, 12];
                    }
                    else if (MPGV.gcLanguage == '3')
                    {
                        lblAlarm.Text = MPGV.gsMessageData[2, 12];
                    }
                    else
                    {
                        lblAlarm.Text = MPGV.gsMessageData[0, 12];
                    }
                    
                    if (lblAlarm.BackColor.Equals(Color.PaleGreen) == true)
                    {
                        lblAlarm.BackColor = Color.LemonChiffon;
                    }
                    else
                    {
                        lblAlarm.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    pnlAlarm.Size = new System.Drawing.Size(pnlAlarm.Size.Width, 0);
                    pnlAlarm.Visible = false;
                }
                #endif // _SPC
            }
            
        }
        
        private void tmrLogOutTime_Tick(object sender, System.EventArgs e)
        {
            if (this.DesignMode == true) return;

            try
            {
                MPGV.giIdleTime++;
                if (MPGV.giLogOutTime > 0)
                {
                    if (MPGV.giIdleTime >= MPGV.giLogOutTime)
                    {
                        
                        MPCF.ShowMsgBox(MPCF.GetMessage(7));
                        System.Threading.Thread.Sleep(5000);
                        MPGV.gbLogoutFlag = true;
                        MPGV.gfrmMDI.Close();
                        this.Close();
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void tmrSuccess_Tick(object sender, System.EventArgs e)
        {
            if (this.DesignMode == true) return;
            
            try
            {

                if (this.stsMDIMainPanel2.Text != "")
                {
                    //Add by J.S. 2008/03/20
                    //최소시간 동안은 상태를 화면에 계속 표시하기위해서...
                    if (sOldStatusMsg == this.stsMDIMainPanel2.Text)
                    {
                        sOldStatusMsg = "";
                        this.stsMDIMainPanel2.Text = "";
                    }
                    else
                    {
                        sOldStatusMsg = this.stsMDIMainPanel2.Text;
                    }
                }
                
                //if (this.stsMDIMainPanel2.Text != "")
                //{
                //    this.stsMDIMainPanel2.Text = "";
                //}
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMDIMainCore.tmrSuccess_Tick()\n" + ex.Message);
            }
            
        }

        private void tmrTimeStatus_Tick(System.Object sender, System.EventArgs e)
        {
            if (this.DesignMode == true) return;

            // Set Time of Status Bar
            stsMDIMainPanel6.Text = DateTime.Now.ToString();

            //Add by J.S test for GC
            //Delete by J.S. 정상적으로 GC가 동작함
            //GC.Collect();

        }

        private void tmrProgress_Tick(System.Object sender, System.EventArgs e)
        {
            if (this.DesignMode == true) return;

            if (pgbMain.Value >= pgbMain.Maximum)
            {
                pgbMain.Value = 0;
            }

            pgbMain.PerformStep();

        }

        private void tmrMsg_Tick(System.Object sender, System.EventArgs e)
        {
            if (this.DesignMode == true) return;

            if (MPGV.gbShowMessagePanel == true)
            {

                pnlMessage.Size = new System.Drawing.Size(pnlMessage.Size.Width, 23);
                pnlMessage.Visible = true;

                if (lblMessage.BackColor.Equals(Color.LemonChiffon) == true)
                {
                    lblMessage.BackColor = Color.Salmon;
                }
                else
                {
                    lblMessage.BackColor = Color.LemonChiffon;
                }
            }
            else
            {
                pnlMessage.Size = new System.Drawing.Size(pnlMessage.Size.Width, 0);
                pnlMessage.Visible = false;
            }

        }

        private void tmrCheckVersion_Tick(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;

            if (MPGV.giVersionCheckTime < 1) return;
            if (MPGV.gbProcessCaster == true) return;
            if (MPIF.gInit.IsAvailableSendMessage == false) return;

            if (b_is_start_ver_chk == false)
            {
                b_is_start_ver_chk = true;

                i_version_timer_tick_check++;
                if (i_version_timer_tick_check == MPGV.giVersionCheckTime)
                {
                    if (MPCR.Client_Upgrade(1) == 1)
                    {
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

                        this.Close();
                        Application.Exit();
                    }
                    i_version_timer_tick_check = 0;
                }

                b_is_start_ver_chk = false;
            }
        }

        private void MDIMainStatusBar_DrawItem(System.Object sender, System.Windows.Forms.StatusBarDrawItemEventArgs sbdevent)
        {
            // Create a StringFormat object to align text in the panel.
            StringFormat sf = new StringFormat();

            if (sbdevent.Index == 0)
            {

                // Format the String of the StatusBarPanel to be centered.
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                // Draw a back blackground in owner-drawn panel.
                sbdevent.Graphics.FillRectangle(Brushes.DarkBlue, sbdevent.Bounds);

                // Draw the current date (short date format) with white text in the control's font.
                //'sbdevent.Graphics.DrawString(Date.Now.ToString, MDIMainStatusBar.Font, Brushes.White, _
                //'    New RectangleF(sbdevent.Bounds.X, sbdevent.Bounds.Y, _
                //'    sbdevent.Bounds.Width, sbdevent.Bounds.Height), sf)

            }

            if (sbdevent.Index == 2)
            {

            }
        }

        private void m_MDIClient_Resize(object sender, System.EventArgs e)
        {
            
            if (m_ImgBackPic == null)
            {
                return;
            }
            
            Graphics g = m_MDIClient.CreateGraphics();
            Point pt = new Point((m_MDIClient.Width - m_ImgBackPic.Width) / 2, (m_MDIClient.Height - m_ImgBackPic.Height) / 2);
            
            g.DrawImage(m_ImgBackPic, pt.X, pt.Y, m_ImgBackPic.Width, m_ImgBackPic.Height);
            
            Rectangle rect = new Rectangle();
            rect.X = 0;
            rect.Y = 0;
            rect.Width = m_MDIClient.Width;
            rect.Height = pt.Y;
            g.FillRectangle(Brushes.White, rect);
            rect.Y = pt.Y + m_ImgBackPic.Height;
            rect.Width = m_MDIClient.Width;
            g.FillRectangle(Brushes.White, rect);
            rect.Y = pt.Y;
            rect.Width = pt.X;
            rect.Height = m_ImgBackPic.Height;
            g.FillRectangle(Brushes.White, rect);
            rect.X = pt.X + m_ImgBackPic.Width;
            g.FillRectangle(Brushes.White, rect);
            
        }
        
        private void m_MDIClient_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            
            if (m_ImgBackPic == null)
            {
                return;
            }
            
            Graphics g = m_MDIClient.CreateGraphics();
            Point pt = new Point((m_MDIClient.Width - m_ImgBackPic.Width) / 2, (m_MDIClient.Height - m_ImgBackPic.Height) / 2);
            
            g.DrawImage(m_ImgBackPic, pt.X, pt.Y, m_ImgBackPic.Width, m_ImgBackPic.Height);
            
            Rectangle rect = new Rectangle();
            rect.X = 0;
            rect.Y = 0;
            rect.Width = m_MDIClient.Width;
            rect.Height = pt.Y;
            g.FillRectangle(Brushes.White, rect);
            rect.Y = pt.Y + m_ImgBackPic.Height;
            rect.Width = m_MDIClient.Width;
            g.FillRectangle(Brushes.White, rect);
            
            rect.Y = pt.Y;
            rect.Width = pt.X;
            rect.Height = m_ImgBackPic.Height;
            g.FillRectangle(Brushes.White, rect);
            rect.X = pt.X + m_ImgBackPic.Width;
            g.FillRectangle(Brushes.White, rect);
            
        }
        
        
#if _UTL
        private void lblMessage_Click(System.Object sender, System.EventArgs e)
        {
            if (this.DesignMode == true) return;

            if (MPGV.gIMdiForm.ViewUTLPublishMessage(false) == true)
            {
                MPGV.gbShowMessagePanel = false;
            }
        }
#endif
        
        #endregion
        
        #region "Functions Definition"

        private void SetBackGroundColorOfMDIForm()
        {
            Control ctl;

            //MDI Background Color 표시
            //Loop through controls,
            //looking for controls of MdiClient type.
            foreach (Control tempLoopVar_ctl in this.Controls)
            {
                ctl = tempLoopVar_ctl;
                if ((ctl) is MdiClient)
                {

                    // If the control is the correct type,
                    // change the color.
                    ctl.BackColor = System.Drawing.Color.White;

                    // Save MDIClient
                    m_MDIClient = ctl;
                    m_MDIClient.Resize += new System.EventHandler(m_MDIClient_Resize);
                    m_MDIClient.Paint += new System.Windows.Forms.PaintEventHandler(m_MDIClient_Paint);

                    break;
                }
            }
        }

        protected virtual void SetSiteInfo()
        {
            stsMDIMainPanel3.Text = "Site ID : " + MPGV.gsSiteID;
            stsMDIMainPanel4.Text = "Factory : " + MPGV.gsFactory;
            stsMDIMainPanel5.Text = "User ID : " + MPGV.gsUserID;
            stsMDIMainPanel6.Text = DateTime.Now.ToString();

            this.Text = Application.ProductName + " [" + MPGV.gsSiteNickName + "]";
        }

        protected virtual bool InitMainForm()
        {

            SetSiteInfo();
#if _UTL
            if (MPGV.gIMdiForm.PublishUTLMsgTune() == false) return false;
#endif

#if _ALM
            if (MPGV.gIMdiForm.PublishALMMsgTune() == false) return false;
#endif

#if _SPC
            if (MPGV.gIMdiForm.PublishSPCMsgTune() == false) return false;
#endif

            //Add by J.S. JUNG 2008/02/11 ADMClient에서는 필요 없는 항목임
            if (MPGV.gsServerName == "ADMServer")
            {
                MPGV.gShiftInfor.iShiftCount = 0;
                MPGV.gShiftInfor.sShift1StartTime = "000000";
            }
            else
            {
                // Get Factory Shift Information
                if (MPCR.GetFactoryShiftInfor() == false) return false;
            }

            // Add by DM KIM 2012.05.09 BBS Message Tune

            if (MPGV.gIMdiForm.PublishBBSMsgTune() == false) return false;

            return true;
        }

        protected virtual bool InitMainFormAfter()
        {
            string s_reload_screens_flag = MPCF.GetRegSetting(Application.ProductName, "Option", "ReloadScreens", "2");

            if (s_reload_screens_flag == "1")
            {
                int i;
                int i_count = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "LastOpenFuncList", "Count", ""));
                string s_last_func_name;

                for (i = 0; i < i_count; i++)
                {
                    s_last_func_name = MPCF.GetRegSetting(Application.ProductName, "LastOpenFuncList", "FuncName" + i.ToString(), "");
                    if (s_last_func_name != "")
                    {
                        MPGV.gIMdiForm.ActiveMenu(s_last_func_name);
                    }
                }
            }

            return true;
        }

        public void Progress_Start()
        {
            if (this.pgbMain.InvokeRequired)
            {
                ProgressStartCallback d = new ProgressStartCallback(Progress_Start);
                this.Invoke(d);
            }
            else
            {
                pgbMain.Value = 0;
                pgbMain.Visible = true;

                tmrProgress.Start();
            }
        }

        public void Progress_End()
        {
            if (this.pgbMain.InvokeRequired)
            {
                ProgressStopCallback d = new ProgressStopCallback(Progress_End);
                this.Invoke(d);
            }
            else
            {
                pgbMain.Value = 100;
                pgbMain.Visible = false;

                tmrProgress.Stop();
            }
        }

        public void SetStatusMessage(string s_msg)
        {
            this.stsMDIMainPanel2.Text = MPCF.Trim(s_msg);
        }

        public virtual void SetPublishMessage(string s_msg)
        {
            lblMessage.Text = MPCF.Trim(s_msg);
        }

        public void SetAlarmMessage()
        {
            IAsyncResult r = BeginInvoke(_SetAlarmMessageDelegate);
            EndInvoke(r);
        }

        private void SetAlarm()
        {
            int i, i_len;
            string s_temp;
            lblAlarm.Text = "";
            s_temp = lblAlarm.Text;
           
            for (i = 0; i < MPGV.giAlarmCnt; i++)
            {
                if (MPCF.Trim(lblAlarm.Text) != "")
                {
                    lblAlarm.Text = lblAlarm.Text + "    ";
                }
                 s_temp = lblAlarm.Text + "[" + MPCF.MakeDateFormat(MPGV.gtAlarmList[i].create_time) + "] "
                    + MPCF.RTrim(MPGV.gtAlarmList[i].alarm_msg);
                i_len = s_temp.Length;
                if (i_len >= 5000)
                {
                    break;
                }
               
                lblAlarm.Text = s_temp;
               
            }
            lblAlarm.Left = 0;
        }

        public void EnablePublishAlarm()
        {
            tmrAlarm.Enabled = true;
            tmrAlarm.Interval = 1000;
        }

        public void VisibleMessagePanel(bool b_visible)
        {
            pnlMessage.Visible = b_visible;
        }
        

        /* Add by DM KIM 2012.05.09 BBS Publish Message */

        public void EnablePublishBBS()
        {
            tmrBBSMsg.Enabled = true;
            tmrBBSMsg.Interval = 1000;
        }

        public void SetBBSMessage()
        {
            IAsyncResult r = BeginInvoke(_SetBBSMessageDelegate);
            EndInvoke(r);
        }

        private void SetBBS()
        {
            if (MPGV.gfrmPopupInformNote != null)
            {
                MPGV.giBBSMessageCnt = 0;
                MPCR.PopupInformNote(null, MPGV.gsUserID, "", "", "", "", "");
                return;
            }

            int i, i_len;
            string s_temp;
            lblBBSMessage.Text = "";
            s_temp = lblBBSMessage.Text;

            for (i = 0; i < MPGV.giBBSMessageCnt; i++)
            {
                if (MPCF.Trim(lblBBSMessage.Text) != "")
                {
                    lblBBSMessage.Text = lblBBSMessage.Text + "    ";
                }
                s_temp = lblBBSMessage.Text + "[" + MPCF.MakeDateFormat(MPGV.gtBBSMessageList[i].update_time) + "] "
                   + MPCF.RTrim(MPGV.gtBBSMessageList[i].msg_title + " (" + MPCF.RTrim(MPGV.gtBBSMessageList[i].update_user_id) + ")" );
                i_len = s_temp.Length;
                if (i_len >= 5000)
                {
                    break;
                }

                lblBBSMessage.Text = s_temp;

            }
            lblBBSMessage.Left = 0;
        }


        #endregion

        #region "Menu Functions Definition"

        protected virtual bool ViewFavoritesList(ToolStrip tolTool)
        {

            int i;
            MenuInfoTag m_menu_tag;
            ToolStripButton m_tool;
            ToolStripSeparator m_sep;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("VIEW_FAVORITES_LIST_IN");
            TRSNode out_node;
            int args_start_p = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddInt("NEXT_FUNC_SEQ", 0);

                do
                {
                    out_node = new TRSNode("VIEW_FAVORITES_LIST_OUT");

                    if (MPCR.CallService("SEC", "SEC_View_Favorites_List", in_node, ref out_node) == false)
                    {
                        b_can_get_favorites = false;
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetInt("NEXT_FUNC_SEQ", out_node.GetInt("NEXT_FUNC_SEQ"));
                } while (in_node.GetInt("NEXT_FUNC_SEQ") > 0);


                //2008.12.16 Add by J.S. for Refresh Toolbar
                tolTool.Items.Clear();

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        m_tool = new ToolStripButton();

                        m_menu_tag.s_func_name = out_node.GetList(0)[i].GetString("FUNC_NAME");
                        m_menu_tag.s_assembly_file = out_node.GetList(0)[i].GetString("ASSEMBLY_FILE");
                        m_menu_tag.c_func_type = out_node.GetList(0)[i].GetChar("FUNC_TYPE_FLAG");
                        if (m_menu_tag.c_func_type == 'P')
                        {
                            m_menu_tag.s_assembly_name = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME");
                            m_menu_tag.s_args = null;
                        }
                        else
                        {
                            args_start_p = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").IndexOf(' ');
                            if (args_start_p > 0)
                            {
                                m_menu_tag.s_assembly_name = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Substring(0, args_start_p);
                                m_menu_tag.s_args = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Substring(args_start_p + 1, out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Length - args_start_p - 1);
                            }
                            else
                            {
                                m_menu_tag.s_assembly_name = out_node.GetList(0)[i].GetString("ASSEMBLY_NAME");
                                m_menu_tag.s_args = null;
                            }
                        }

                        m_tool.Text = "";
                        m_tool.ToolTipText = out_node.GetList(0)[i].GetString("USER_FUNC_DESC");
                        m_tool.Tag = m_menu_tag;

                        if (out_node.GetList(0)[i].GetInt("ICON_INDEX") >= 0 && out_node.GetList(0)[i].GetInt("ICON_INDEX") < imlToolBar.Images.Count)
                            m_tool.Image = imlToolBar.Images[out_node.GetList(0)[i].GetInt("ICON_INDEX")];
                        else
                            m_tool.Image = imlToolBar.Images[116];

                        m_tool.Click += new EventHandler(ToolStripMenuItem_Click);
                        tolTool.Items.Add(m_tool);

                    }
                }

                if (out_node.GetList(0).Count > 0)
                {
                    m_sep = new ToolStripSeparator();
                    tolTool.Items.Add(m_sep);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ViewFavoritesList1() is Failed.\n" + ex.Message);
                return false;
            }

            if (b_process_to_generate_menu == false)
            {
                //2008.12.16 Add by J.S. for Refresh Toolbar
                TRSNode in_node2 = new TRSNode("VIEW_FUNCTION_LIST_IN");
                TRSNode out_node2 = new TRSNode("VIEW_FUNCTION_LIST_OUT");

                try
                {
                    MPCR.SetInMsg(in_node2);
                    in_node2.ProcStep = '1';
                    in_node2.AddString("PROGRAM_ID", MPGV.gsProgramID);
                    in_node2.AddString("SEC_GRP_ID", MPGV.gsUserGroup);
                    in_node2.AddString("NEXT_FUNC_NAME", "");


                    do
                    {
                        if (MPCR.CallService("SEC", "SEC_View_Function_List", in_node2, ref out_node2) == false)
                        {
                            return false;
                        }

                        for (i = 0; i < out_node2.GetList(0).Count; i++)
                        {
                            if (out_node2.GetList(0)[i].GetChar("ADD_TOOL_BAR") == 'Y')
                            {
                                m_tool = new ToolStripButton();

                                m_menu_tag.s_func_name = out_node2.GetList(0)[i].GetString("FUNC_NAME");
                                m_menu_tag.s_assembly_file = out_node2.GetList(0)[i].GetString("ASSEMBLY_FILE");
                                m_menu_tag.c_func_type = out_node2.GetList(0)[i].GetChar("FUNC_TYPE_FLAG");
                                if (m_menu_tag.c_func_type == 'P')
                                {
                                    m_menu_tag.s_assembly_name = out_node2.GetList(0)[i].GetString("ASSEMBLY_NAME");
                                    m_menu_tag.s_args = null;
                                }
                                else
                                {
                                    args_start_p = out_node2.GetList(0)[i].GetString("ASSEMBLY_NAME").IndexOf(' ');
                                    if (args_start_p > 0)
                                    {
                                        m_menu_tag.s_assembly_name = out_node2.GetList(0)[i].GetString("ASSEMBLY_NAME").Substring(0, args_start_p);
                                        m_menu_tag.s_args = out_node2.GetList(0)[i].GetString("ASSEMBLY_NAME").Substring(args_start_p + 1, out_node.GetList(0)[i].GetString("ASSEMBLY_NAME").Length - args_start_p - 1);
                                    }
                                    else
                                    {
                                        m_menu_tag.s_assembly_name = out_node2.GetList(0)[i].GetString("ASSEMBLY_NAME");
                                        m_menu_tag.s_args = null;
                                    }
                                }

                                m_tool.Text = "";
                                m_tool.ToolTipText = out_node2.GetList(0)[i].GetString("FUNC_DESC");
                                m_tool.Tag = m_menu_tag;

                                if (out_node2.GetList(0)[i].GetInt("ICON_INDEX") >= 0 && out_node2.GetList(0)[i].GetInt("ICON_INDEX") < imlToolBar.Images.Count)
                                    m_tool.Image = imlToolBar.Images[out_node2.GetList(0)[i].GetInt("ICON_INDEX")];
                                else
                                    m_tool.Image = imlToolBar.Images[116];

                                m_tool.Click += new EventHandler(ToolStripMenuItem_Click);
                                tolTool.Items.Add(m_tool);
                            }
                        }

                        in_node2.SetString("NEXT_FUNC_NAME", out_node2.GetString("NEXT_FUNC_NAME"));
                    } while (in_node2.GetString("NEXT_FUNC_NAME") != "");

                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox("ViewFavoritesList2() is Failed.\n" + ex.Message);
                    return false;
                }
            }

            return true;
        }

        
        protected virtual bool GetAvailableFunctionList(MenuStrip mnuMenu, int i_menu_insert_index, ToolStrip tolTool)
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_LIST_OUT");
            ArrayList func_list;
            int i;

            b_process_to_generate_menu = true;

            // 2010.07.12. SEC_View_Favorites_List Service 에 대한 Privilede 권한이 없더라도 진행할 수 있도록 변경함.
            //if (ViewFavoritesList(tolTool) == false) return false;
            ViewFavoritesList(tolTool);

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("SEC_GRP_ID", MPGV.gsUserGroup);
                in_node.AddString("NEXT_FUNC_NAME", "");

                func_list = new ArrayList();

                do
                {
                    if (MPCR.CallService("SEC", "SEC_View_Function_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        func_list.Add(out_node.GetList(0)[i]);
                    }

                    in_node.SetString("NEXT_FUNC_NAME", out_node.GetString("NEXT_FUNC_NAME"));
                } while (in_node.GetString("NEXT_FUNC_NAME") != "");

                i = 0;
                ShowMainMenu(mnuMenu, i_menu_insert_index, tolTool, null, "1", func_list, ref i);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("GetAvailableFunctionList() is Failed.\n" + ex.Message);
                return false;
            }

            b_process_to_generate_menu = false;

            return true;
        }


        protected virtual void ShowMainMenu(MenuStrip mnuMenu, int i_menu_insert_index, ToolStrip tolTool, ToolStripMenuItem parent_menu, string s_parent_level, ArrayList func_list, ref int i)
        {
            string[] s_p_level;
            string[] s_c_level;
            ToolStripMenuItem m_menu;
            ToolStripSeparator m_menu_separator;
            ToolStripButton m_tool;
            MenuInfoTag m_menu_tag;
            Keys m_key;
            string s_tmp;
            TRSNode func_item;
            int args_start_p = 0;

            try
            {
                m_menu = null;
                s_p_level = s_parent_level.Split('.');

                if (func_list != null)
                {
                    while (i < func_list.Count)
                    {
                        func_item = (TRSNode)func_list[i];

                        s_c_level = func_item.GetString("DISP_LEVEL").Split('.');

                        if (s_p_level.Length > s_c_level.Length)
                        {
                            return;
                        }
                        else if (s_p_level.Length < s_c_level.Length)
                        {
                            ShowMainMenu(mnuMenu, i_menu_insert_index, tolTool, m_menu, func_item.GetString("DISP_LEVEL"), func_list, ref i);
                        }
                        else
                        {
                            if (func_item.GetChar("SEPARATOR") == 'Y' && parent_menu != null)
                            {
                                m_menu_separator = new ToolStripSeparator();
                                parent_menu.DropDownItems.Add(m_menu_separator);
                            }

                            m_menu_tag.s_func_name = func_item.GetString("FUNC_NAME");
                            m_menu_tag.s_assembly_file = func_item.GetString("ASSEMBLY_FILE");
                            m_menu_tag.c_func_type = func_item.GetChar("FUNC_TYPE_FLAG");
                            if (m_menu_tag.c_func_type == 'P')
                            {
                                m_menu_tag.s_assembly_name = func_item.GetString("ASSEMBLY_NAME");
                                m_menu_tag.s_args = null;
                            }
                            else
                            {
                                args_start_p = func_item.GetString("ASSEMBLY_NAME").IndexOf(' ');
                                if (args_start_p > 0)
                                {
                                    m_menu_tag.s_assembly_name = func_item.GetString("ASSEMBLY_NAME").Substring(0, args_start_p);
                                    m_menu_tag.s_args = func_item.GetString("ASSEMBLY_NAME").Substring(args_start_p + 1, func_item.GetString("ASSEMBLY_NAME").Length - args_start_p - 1);
                                }
                                else
                                {
                                    m_menu_tag.s_assembly_name = func_item.GetString("ASSEMBLY_NAME");
                                    m_menu_tag.s_args = null;
                                }
                            }

                            if (func_item.GetChar("ADD_TOOL_BAR") == 'Y')
                            {
                                m_tool = new ToolStripButton();

                                m_tool.Text = "";
                                m_tool.ToolTipText = func_item.GetString("FUNC_DESC");
                                m_tool.Tag = m_menu_tag;

                                if (func_item.GetInt("ICON_INDEX") >= 0 && func_item.GetInt("ICON_INDEX") < imlToolBar.Images.Count)
                                    m_tool.Image = imlToolBar.Images[func_item.GetInt("ICON_INDEX")];
                                else
                                    m_tool.Image = imlToolBar.Images[116];

                                m_tool.Click += new EventHandler(ToolStripMenuItem_Click);
                                tolTool.Items.Add(m_tool);
                            }

                            m_menu = new ToolStripMenuItem();
                            m_menu.Tag = m_menu_tag;
                            m_menu.Text = func_item.GetString("FUNC_DESC");
                            m_menu.Click += new EventHandler(ToolStripMenuItem_Click);

                            //Menu 활성/비활성화 제어
                            if (m_menu_tag.c_func_type == 'F' && string.IsNullOrEmpty(m_menu_tag.s_assembly_file.ToString()) == true)
                                m_menu.Enabled = false;

                            if (func_item.GetInt("ICON_INDEX") >= 0 && func_item.GetInt("ICON_INDEX") < imlToolBar.Images.Count)
                                m_menu.Image = imlToolBar.Images[func_item.GetInt("ICON_INDEX")];
                            else
                                m_menu.Image = null;

                            if (func_item.GetString("SHORT_CUT").Length > 0)
                            {
                                m_key =         (func_item.GetString("SHORT_CUT")[0] == 'C' ? Keys.Control : Keys.None);
                                m_key = m_key | (func_item.GetString("SHORT_CUT")[1] == 'A' ? Keys.Alt : Keys.None);
                                m_key = m_key | (func_item.GetString("SHORT_CUT")[2] == 'S' ? Keys.Shift : Keys.None);

                                s_tmp = func_item.GetString("SHORT_CUT").Substring(3);
                                if (s_tmp.Length > 1)
                                    m_key = m_key | (Keys)((int)Keys.F1 + MPCF.ToInt(s_tmp.Substring(1)) - 1);
                                else
                                    m_key = m_key | (Keys)((int)s_tmp[0]);

                                try
                                {
                                    m_menu.ShortcutKeys = m_key;
                                }
                                catch (InvalidEnumArgumentException e)
                                {
                                    string s_error_string;

                                    m_menu.ShortcutKeys = Keys.None;

                                    s_error_string = "";
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

                                    MessageBox.Show("Not Allowed Shortcut Keys : " + s_error_string);

                                    System.Diagnostics.Debug.WriteLine(e.Message);
                                }
                            }

                            if (parent_menu == null)
                                mnuMenu.Items.Insert((mnuMenu.Items.Count - 3) + i_menu_insert_index, m_menu);
                            else
                                parent_menu.DropDownItems.Add(m_menu);

                            i++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ShowMainMenu()\n" + e.Message);
            }
        }

        protected virtual void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuInfoTag m_menu_tag;
            ToolStripMenuItem m_menu = null;
            ToolStripButton m_tool = null;
            Control focus_control;

            try
            {
                m_menu_tag.s_func_name = null;
                m_menu_tag.s_assembly_file = null;
                m_menu_tag.s_assembly_name = null;
                m_menu_tag.c_func_type = ' ';
                m_menu_tag.s_args = null;

                if (sender == null) return;

                if (sender is ToolStripMenuItem)
                {
                    m_menu = (ToolStripMenuItem)sender;
                    m_menu_tag = (MenuInfoTag)m_menu.Tag;
                }
                else if (sender is ToolStripButton)
                {
                    m_tool = (ToolStripButton)sender;
                    m_menu_tag = (MenuInfoTag)m_tool.Tag;
                }

                focus_control = ExecuteMenu(m_menu_tag);
                if (focus_control != null)
                {
                    focus_control.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Modified by I.C.Bae. Offer from SeokYoung-Kim
        // Form이 열릴때, Function Setup에 해당 Assembly Name에 Argument가 추가되어 있으면, CreateInstance시에 Argument를 넣어준다.
        // Argument를 받는 Form에서는 Argument를 받기 위해, Form의 생성자에 Parameter로 string을 받도록 추가해 주어야한다.
        // 전달되는 Argument를 하나의 문자열로 전달되므로, 여러개의 Argument를 넣고 싶으면 전달 받는 Form에서 알아서 Parsing해서 사용한다.
        protected virtual Control ExecuteMenu(MenuInfoTag m_menu_tag)
        {
            Assembly asm;
            string s_dir;
            string[] s_tmp;
            object obj;
            Control focus_control;

            try
            {
                if (m_menu_tag.Equals(null)) return null;
                if (MPCF.Trim(m_menu_tag.s_assembly_file) == "") return null;

                if (m_menu_tag.c_func_type == 'P')
                {
                    System.Diagnostics.Process.Start(m_menu_tag.s_assembly_file, m_menu_tag.s_assembly_name);   

                    return null;
                }
                else
                {
                    m_menu_tag.s_assembly_name = MPCF.Trim(m_menu_tag.s_assembly_name);
                    s_tmp = m_menu_tag.s_assembly_name.Split('.');

                    obj = MPCF.GetChildForm(MPGV.gfrmMDI, s_tmp[s_tmp.Length - 1], true, m_menu_tag.s_func_name);

                    if (obj == null)
                    {
                        s_dir = Application.StartupPath;
                        asm = Assembly.LoadFrom(s_dir + "\\" + m_menu_tag.s_assembly_file);

                        if (string.IsNullOrEmpty(m_menu_tag.s_args) == true)
                            obj = asm.CreateInstance(m_menu_tag.s_assembly_name);
                        else
                            obj = asm.CreateInstance(m_menu_tag.s_assembly_name, true, BindingFlags.Default, null, new string[] { m_menu_tag.s_args }, null, null);

                        if (obj == null) return null;

                        ((Form)obj).MdiParent = MPGV.gfrmMDI;
                        ((Form)obj).Tag = m_menu_tag.s_func_name;

                        if (MPCR.CheckSecurityFormControl((Form)obj) == false)
                        {
                            return null;
                        }

                        ((Form)obj).Show();
                    }

                    try
                    {
                        focus_control = null;
                        focus_control = (Control)obj.GetType().InvokeMember("GetFisrtFocusItem", BindingFlags.InvokeMethod, null, obj, null);
                        return focus_control;
                    }
                    catch (MissingMethodException)
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        protected virtual void ChangeMenuText(MenuStrip mnuMenu)
        {
            if (mnuMenu == null) return;

            foreach (ToolStripMenuItem menu in mnuMenu.Items)
            {
                ChangeMenuTextSub(menu);
            }
        }

        private void ChangeMenuTextSub(ToolStripMenuItem menu)
        {
            menu.Text = MPCF.FindLanguage(menu.Text, 2);

            for (int i = 0; i < menu.DropDownItems.Count; i++)
            {
                if (menu.DropDownItems[i] is ToolStripMenuItem)
                {
                    ChangeMenuTextSub((ToolStripMenuItem)menu.DropDownItems[i]);
                }
            }
        }

        #endregion

        private void pnlAlarm_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPGV.gsAlarmType == "ALM")
                {
#if _ALM
                    if (MPGV.gIMdiForm.ViewALMPublishMessage() == false)
                    {
                        return;
                    }
#endif
                }
                else if (MPGV.gsAlarmType == "SPC")
                {
#if _SPC
                    if (MPGV.gIMdiForm.ViewSPCPublishMessage() == false)
                    {
                        return;
                    }
#endif // _SPC
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tmrBBSMsg_Tick(object sender, EventArgs e)
        {
            try
            {
                if (MPGV.giBBSMessageCnt > 0)
                {
                    pnlBBSMessage.Size = new System.Drawing.Size(pnlBBSMessage.Size.Width, 23);
                    pnlBBSMessage.Visible = true;

                    if (pnlBBSMessage.BackColor.Equals(Color.PaleGreen) == true)
                    {
                        pnlBBSMessage.BackColor = Color.LemonChiffon;
                        lblBBSMessage.BackColor = Color.LemonChiffon;
                    }
                    else
                    {
                        pnlBBSMessage.BackColor = Color.PaleGreen;
                        lblBBSMessage.BackColor = Color.PaleGreen;
                    }
                    if (lblBBSMessage.Right <= 0)
                    {
                        lblBBSMessage.Left = pnlBBSMessage.Right;
                    }
                    else
                    {
                        lblBBSMessage.Left = lblBBSMessage.Left - 30;
                    }

    }
                else
                {
                    pnlBBSMessage.Size = new System.Drawing.Size(pnlAlarm.Size.Width, 0);
                    pnlBBSMessage.Visible = false;
                    lblBBSMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void pnlBBSMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPGV.gIMdiForm.ViewBBSPublishMessage() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lblBBSMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPGV.gIMdiForm.ViewBBSPublishMessage() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }
}