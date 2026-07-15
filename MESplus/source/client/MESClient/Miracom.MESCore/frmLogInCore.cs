
using Miracom.MsgHandler;
using System.Data;
using Miracom.CliFrx;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace Miracom.MESCore
{
    public class frmLogInCore : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmLogInCore()
        {
            InitializeComponent();
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
                GC.SuppressFinalize(this);
            }
            base.Dispose(disposing);
        }


        private System.ComponentModel.Container components = null;
        protected TextBox txtFactory;
        protected TextBox txtUserID;
        protected TextBox txtPassword;
        protected Button btnOption;
        protected Button btnOK;
        protected Button btnExit;
        protected Label lblFactory;
        protected Label lblUserID;
        protected Label lblVersion;
        protected TextBox txtSiteID;
        protected Label lblSiteID;
        private PictureBox picLogin;
        protected Panel pnlMain;
        protected Label lblPassword;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogInCore));
            this.btnOption = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblFactory = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtSiteID = new System.Windows.Forms.TextBox();
            this.lblSiteID = new System.Windows.Forms.Label();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOption
            // 
            this.btnOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOption.ForeColor = System.Drawing.Color.Black;
            this.btnOption.Location = new System.Drawing.Point(183, 310);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(75, 24);
            this.btnOption.TabIndex = 5;
            this.btnOption.Text = "Options...";
            this.btnOption.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOption.UseVisualStyleBackColor = false;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(271, 310);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(359, 310);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 24);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblFactory
            // 
            this.lblFactory.AutoSize = true;
            this.lblFactory.BackColor = System.Drawing.Color.White;
            this.lblFactory.Location = new System.Drawing.Point(226, 232);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(42, 13);
            this.lblFactory.TabIndex = 8;
            this.lblFactory.Text = "Factory";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.BackColor = System.Drawing.Color.White;
            this.lblUserID.Location = new System.Drawing.Point(226, 258);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(43, 13);
            this.lblUserID.TabIndex = 9;
            this.lblUserID.Text = "User ID";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(226, 284);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            // 
            // txtFactory
            // 
            this.txtFactory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFactory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFactory.Location = new System.Drawing.Point(306, 228);
            this.txtFactory.MaxLength = 10;
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Size = new System.Drawing.Size(128, 20);
            this.txtFactory.TabIndex = 0;
            // 
            // txtUserID
            // 
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserID.Location = new System.Drawing.Point(306, 254);
            this.txtUserID.MaxLength = 20;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(128, 20);
            this.txtUserID.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(306, 280);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(128, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.White;
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVersion.Location = new System.Drawing.Point(17, 224);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(149, 13);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "Client Version : MES_V1.0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVersion.Visible = false;
            // 
            // txtSiteID
            // 
            this.txtSiteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtSiteID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSiteID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSiteID.Location = new System.Drawing.Point(306, 202);
            this.txtSiteID.MaxLength = 10;
            this.txtSiteID.Name = "txtSiteID";
            this.txtSiteID.ReadOnly = true;
            this.txtSiteID.Size = new System.Drawing.Size(128, 20);
            this.txtSiteID.TabIndex = 6;
            // 
            // lblSiteID
            // 
            this.lblSiteID.AutoSize = true;
            this.lblSiteID.BackColor = System.Drawing.Color.White;
            this.lblSiteID.Location = new System.Drawing.Point(226, 206);
            this.lblSiteID.Name = "lblSiteID";
            this.lblSiteID.Size = new System.Drawing.Size(39, 13);
            this.lblSiteID.TabIndex = 7;
            this.lblSiteID.Text = "Site ID";
            // 
            // picLogin
            // 
            this.picLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogin.Image = ((System.Drawing.Image)(resources.GetObject("picLogin.Image")));
            this.picLogin.Location = new System.Drawing.Point(0, 0);
            this.picLogin.Margin = new System.Windows.Forms.Padding(0);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(456, 344);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogin.TabIndex = 0;
            this.picLogin.TabStop = false;
            this.picLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLogin_MouseDown);
            this.picLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLogin_MouseUp);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtSiteID);
            this.pnlMain.Controls.Add(this.lblSiteID);
            this.pnlMain.Controls.Add(this.lblVersion);
            this.pnlMain.Controls.Add(this.txtPassword);
            this.pnlMain.Controls.Add(this.txtUserID);
            this.pnlMain.Controls.Add(this.txtFactory);
            this.pnlMain.Controls.Add(this.lblPassword);
            this.pnlMain.Controls.Add(this.lblUserID);
            this.pnlMain.Controls.Add(this.lblFactory);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.btnOK);
            this.pnlMain.Controls.Add(this.btnOption);
            this.pnlMain.Controls.Add(this.picLogin);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(456, 344);
            this.pnlMain.TabIndex = 13;
            // 
            // frmLogInCore
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(456, 344);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmLogInCore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MESClient - Login";
            this.Activated += new System.EventHandler(this.frmLogInCore_Activated);
            this.Closed += new System.EventHandler(this.frmLogInCore_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        private bool b_load_flag = false;
        #endregion
        
        #region "Function Difinition"
        
        protected virtual void ShowOptionWindow(bool bRestart)
        {
            
            frmOptionCore f = new frmOptionCore(bRestart);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                txtSiteID.Text = MPGV.gsSiteID;
                return;
            }           
            
        }
        
        #endregion
        
        private void frmLogInCore_Activated(object sender, System.EventArgs e)
        {
            string[] lisCmdArgs = Environment.GetCommandLineArgs();
            bool b_cmd_logon = false;

            if (b_load_flag == false)
            {
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

                txtSiteID.Text = MPGV.gsSiteID;
                txtFactory.Text = MPGV.gsFactory;
                txtUserID.Text = MPGV.gsUserID;
                
                if (MPCF.ToClientLanguage(this) == false)
                {
                    return;
                }
                
                if (txtPassword.Text == "")
                {
                    txtPassword.Focus();
                }
                if (txtUserID.Text == "")
                {
                    txtUserID.Focus();
                }
                if (txtFactory.Text == "")
                {
                    txtFactory.Focus();
                }
                
                if (MPGV.gbUseSmallLetter == true)
                {
                    txtUserID.CharacterCasing = CharacterCasing.Normal;
                }
                else
                {
                    txtUserID.CharacterCasing = CharacterCasing.Upper;
                }
                
                b_load_flag = true;

                if (b_cmd_logon == true)
                {
                    if (MPCF.Trim(MPGV.gsRemoteAddress) == "")
                        b_cmd_logon = false;
                    if (MPCF.Trim(MPGV.gsSiteID) == "")
                        b_cmd_logon = false;

                    if (MPIF.gInit.getMiddleware == "TIBRV")
                    {
                        if (MPCF.Trim(MPGV.gsRvService) == "")
                            b_cmd_logon = false;
                    }

                    if (MPCF.Trim(txtFactory.Text) == "")
                        b_cmd_logon = false;
                    if (MPCF.Trim(txtUserID.Text) == "")
                        b_cmd_logon = false;
                    if (MPCF.Trim(txtPassword.Text) == "")
                        b_cmd_logon = false;

                    if (b_cmd_logon == true)
                    {
                        btnOK.PerformClick();
                    }
                }
            }
            
        }
        
        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            
            int i;
            int iCur;
            string[] ListSiteID = new string[20];
            string[] ListRemoteAddress = new string[20];
            string[] ListStationMode = new string[20];
            string[] ListRvService = new string[20];
            string[] ListRvNetwork = new string[20];
            bool UpgradeFlag = false;
            
            if (txtFactory.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtFactory.Focus();
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            if (txtUserID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtUserID.Focus();
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            
            MPGV.gsFactory = txtFactory.Text;
            MPGV.gsUserID = txtUserID.Text;
            MPGV.gsPassword = txtPassword.Text;

            MPGV.gsSiteNickName = MPGV.gsSiteID;
            
            if (MPIF.gInit.InitMsgHandler() == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(104));
                txtFactory.Focus();
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
                        
            //Add by J.S 2006/4/6 for ASC
            if (MPCR.SEC_Login_Ext(ref UpgradeFlag) == false)
            {
                txtPassword.SelectAll();
                txtPassword.Focus();
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                MPIF.gInit.TermMsgHandler();
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
                // store login information for automatic login
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
                
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
            
            iCur = - 1;
            for (i = 0; i < 20; i++)
            {
                ListSiteID[i] = MPCF.GetRegSetting(Application.ProductName, "Option", "SiteID" + i.ToString(), "");
                ListRemoteAddress[i] = MPCF.GetRegSetting(Application.ProductName, "Option", "RemoteAddress" + i.ToString(), "");

                if (MPIF.gInit.getMiddleware == "TIBRV")
                {
                    ListRvService[i] = MPCF.GetRegSetting(Application.ProductName, "Option", "RvService" + i.ToString(), "");
                    ListRvNetwork[i] = MPCF.GetRegSetting(Application.ProductName, "Option", "RvNetwork" + i.ToString(), "");
                }
                else if (MPIF.gInit.getMiddleware == "H101")
                {
                    ListStationMode[i] = MPCF.GetRegSetting(Application.ProductName, "Option", "StationMode" + i.ToString(), "");
                }
                
                if (ListSiteID[i] == MPGV.gsSiteID && ListRemoteAddress[i] == MPGV.gsRemoteAddress)
                {
                    if (MPIF.gInit.getMiddleware == "TIBRV")
                    {
                        if (ListRvService[i] == MPGV.gsRvService && ListRvNetwork[i] == MPGV.gsRvNetwork)
                        {
                            iCur = i;
                        }
                    }
                    else
                    {
                        iCur = i;
                    }
                }
            }

            MPCF.SaveRegSetting(Application.ProductName, "Option", "SiteID", MPGV.gsSiteID);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "RemoteAddress", MPGV.gsRemoteAddress);
            MPCF.SaveRegSetting(Application.ProductName, "Settings", "Factory", MPGV.gsFactory);
            MPCF.SaveRegSetting(Application.ProductName, "Settings", "UserName", MPGV.gsUserID);

            if (MPIF.gInit.getMiddleware == "TIBRV")
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "RvService", MPGV.gsRvService);
                MPCF.SaveRegSetting(Application.ProductName, "Option", "RvNetwork", MPGV.gsRvNetwork);
            }
            else if (MPIF.gInit.getMiddleware == "H101")
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode", MPGV.gsStationMode);
            }

            MPCF.SaveRegSetting(Application.ProductName, "Option", "UseSmallLetter", (MPGV.gbUseSmallLetter == true ? "Y" : "N"));
            MPCF.SaveRegSetting(Application.ProductName, "Option", "AutoUpgrade", MPGV.gcAutoUpgrade.ToString()); 
            
            if (iCur >= 0)
            {
                for (i = 1; i <= iCur; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "SiteID" + i.ToString(), ListSiteID[i - 1]);
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "RemoteAddress" + i.ToString(), ListRemoteAddress[i - 1]);

                    if (MPIF.gInit.getMiddleware == "TIBRV")
                    {
                        MPCF.SaveRegSetting(Application.ProductName, "Option", "RvService" + i.ToString(), ListRvService[i - 1]);
                        MPCF.SaveRegSetting(Application.ProductName, "Option", "RvNetwork" + i.ToString(), ListRvNetwork[i - 1]);
                    }
                    else
                    {
                        if (MPIF.gInit.getMiddleware == "H101")
                        {
                            MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode" + i.ToString(), ListStationMode[i - 1]);
                        }

                        MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvService" + i.ToString());
                        MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvNetwork" + i.ToString());
                    }
                }
            }
            else
            {
                for (i = 1; i <= 19; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "SiteID" + i.ToString(), ListSiteID[i - 1]);
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "RemoteAddress" + i.ToString(), ListRemoteAddress[i - 1]);

                    if (MPIF.gInit.getMiddleware == "TIBRV")
                    {
                        MPCF.SaveRegSetting(Application.ProductName, "Option", "RvService" + i.ToString(), ListRvService[i - 1]);
                        MPCF.SaveRegSetting(Application.ProductName, "Option", "RvNetwork" + i.ToString(), ListRvNetwork[i - 1]);
                    }
                    else
                    {
                        if (MPIF.gInit.getMiddleware == "H101")
                        {
                            MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode" + i.ToString(), ListStationMode[i - 1]);
                        }

                        MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvService" + i.ToString());
                        MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvNetwork" + i.ToString());
                    }
                }
            }
            
            MPCF.SaveRegSetting(Application.ProductName, "Option", "SiteID" + "0", MPGV.gsSiteID);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "RemoteAddress" + "0", MPGV.gsRemoteAddress);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "Factory" + "0", MPGV.gsFactory);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "UserName" + "0", MPGV.gsUserID);

            if (MPIF.gInit.getMiddleware == "TIBRV")
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "RvService" + "0", MPGV.gsRvService);
                MPCF.SaveRegSetting(Application.ProductName, "Option", "RvNetwork" + "0", MPGV.gsRvNetwork);
            }
            else
            {
                if (MPIF.gInit.getMiddleware == "H101")
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode" + "0", MPGV.gsStationMode);
                }

                MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvService" + "0");
                MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvNetwork" + "0");
            }

            
            if (MPGV.gsPassport == MPGC.MP_DONT_CHECK_PASSWORD)
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.Close();
            }
            
        }
        
        private void btnExit_Click(System.Object sender, System.EventArgs e)
        {
            
            this.Close();
            
        }
        
        private void btnOption_Click(System.Object sender, System.EventArgs e)
        {
            
            ShowOptionWindow(false);
            
        }
        
        private void frmLogInCore_Closed(object sender, System.EventArgs e)
        {
            if (this.MdiParent == null)
            {
                
            }
            else
            {
                if (this.MdiParent.IsMdiContainer == true)
                {
                    this.Dispose();
                }
            }
        }

        private void picLogin_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.Clicks == 2)
            {
                lblVersion.Text = MPCF.FindLanguage("Client Version : ", CAPTION_TYPE.LABEL) + MPGV.gsClientVersion;
                lblVersion.Visible = true;
            }

        }

        private void picLogin_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (lblVersion.Visible == true)
                lblVersion.Visible = false;
        }
        
    }
    
}
