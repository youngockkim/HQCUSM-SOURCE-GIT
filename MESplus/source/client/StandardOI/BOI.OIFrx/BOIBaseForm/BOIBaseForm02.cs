using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracom.TRSCore;
using SOI.CliFrx;
using SOI.OIFrx.SOIThemes;
using System.IO;
using System.Diagnostics;
using SOI.OIFrx;
using SOIControls = SOI.OIFrx.SOIControls;
using System.Drawing.Drawing2D;

namespace BOI.OIFrx.BOIBaseForm
{
    public partial class BOIBaseForm02 : BOIBaseForm01
    {
        #region Property

        private bool b_is_favorite;
        private MenuInfoTag menuInfo;
        private int iFavSeqNum;
        private int iInitCount = 0;

        public new bool _UseOITheme
        {
            get
            {
                return base._UseOITheme;
            }
            set
            {
                base._UseOITheme = value;
                SetOITheme();
            }
        }

        private string _helpInfoFileName;
        [Browsable(false)]
        public string HelpInfoFileName
        {
            get { return _helpInfoFileName; }
            set { _helpInfoFileName = value; }
        }

        private byte[] _helpInfoFile;
        [Browsable(false)]
        public byte[] HelpInfoFile
        {
            get { return _helpInfoFile; }
            set { _helpInfoFile = value; }
        }

        private SOIBaseFormStyle _soiFormStyle;
        public SOIBaseFormStyle _SOIFormStyle
        {
            get { return _soiFormStyle; }
            set 
            {
                bool bApply = true;
                if (_soiFormStyle == SOIBaseFormStyle.Undefined
                    && iInitCount < 1)
                {
                    bApply = false;
                }
                _soiFormStyle = value;
                iInitCount++;

                if (bApply == true)
                {                    
                    SetFormStyle(_soiFormStyle);                    
                }
            }
        }

        private bool _useCommSetup = false;

        public bool UseCommSetup
        {
            get { return _useCommSetup; }
            set { _useCommSetup = value; }
        }

        public Panel pnlCommSetup;
        private Label lblCommSetup;
        private BOIControls.COMSwitch comSwitch;
        private BOIControls.H101TunerStatusBar h101TunerStatusBar;
        

        public delegate void com_data(string aData);

        public event com_data Com_1_DataReceived;
        public event com_data Com_2_DataReceived;
        public event com_data Com_3_DataReceived;
        public event com_data Com_4_DataReceived;

        public delegate void StatusBarDataReceivedHandler(TRSNode node);
        public event StatusBarDataReceivedHandler H101MsgDataReceived;

        #endregion

        #region Constructor

        public BOIBaseForm02()
        {
            InitializeComponent();            
        }

        private void h101TunerStatusBar_H101MsgDataReceived(TRSNode node)
        {
            if (this.h101TunerStatusBar != null)
            {
                H101MsgDataReceived(node);
            }
        }

        private void comSwitch_Com_1_DataReceived(string aData)
        {
            if (this.Com_1_DataReceived != null)
            {
                Com_1_DataReceived(aData);
            }
        }

        private void comSwitch_Com_2_DataReceived(string aData)
        {
            if (this.Com_2_DataReceived != null)
            {
                Com_2_DataReceived(aData);
            }
        }

        private void comSwitch_Com_3_DataReceived(string aData)
        {
            if (this.Com_3_DataReceived != null)
            {
                Com_3_DataReceived(aData);
            }
        }

        private void comSwitch_Com_4_DataReceived(string aData)
        {
            if (this.Com_4_DataReceived != null)
            {
                Com_4_DataReceived(aData);
            }
        }

       
        #endregion

        #region Event Handler

        /// <summary>
        /// 화면을 그릴 때 발생합니다.
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            // 디자인 모드에서만 적용
            if (DesignMode == true)
            {
                SetOITheme();
            }

            base.OnPaint(pe);
        }

        /// <summary>
        /// 화면 로드 시 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BOIBaseForm02_Load(object sender, EventArgs e)
        {
            if (DesignMode == true)
            {
                return;
            }

            // 테마 로드
            SetOITheme();

            // Menu 정보 로드
            menuInfo = (MenuInfoTag)this.Tag;

            // 즐겨찾기 설정
            SetFavorite();

            // Help Guide 설정
            SetHelpInfo();

            //Communication Setup 설정
            if (_useCommSetup == true)
            {
                SetCommSetupPanel();

                comSwitch.Com_1_DataReceived += new BOIControls.com_data(comSwitch_Com_1_DataReceived);
                comSwitch.Com_2_DataReceived += new BOIControls.com_data(comSwitch_Com_2_DataReceived);
                comSwitch.Com_3_DataReceived += new BOIControls.com_data(comSwitch_Com_3_DataReceived);
                comSwitch.Com_4_DataReceived += new BOIControls.com_data(comSwitch_Com_4_DataReceived);
                h101TunerStatusBar.H101MsgDataReceived += new BOIControls.StatusBarDataReceivedHandler(h101TunerStatusBar_H101MsgDataReceived);
            }
        }

        /// <summary>
        /// 즐겨찾기에 등록/해제 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pbFavorite_Click(object sender, EventArgs e)
        {
            if (UpdateFavorite() == false)
            {
                return;
            }
        }

        /// <summary>
        /// Help Info File을 실행합니다.
        /// PNG, JPG, BMP 이미지 파일인 경우 내부 이미지 뷰어 팝업을 실행합니다.
        /// PDF 파일인 경우 외부 PDF 뷰어 exe 파일을 실행합니다.
        /// 기타 파일인 경우 확장자에 맞추어 외부 프로그램을 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbHelp_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우
                if (this.HelpInfoFile.Length < 1)
                {
                    return;
                }

                // 파일 확장자 체크
                string extension = System.IO.Path.GetExtension(this.HelpInfoFileName);
                if (extension.StartsWith("."))
                {
                    extension = extension.Substring(1);
                }

                // 이미지인 경우
                if (extension.ToUpper().Equals("PNG") == true
                    || extension.ToUpper().Equals("JPG") == true
                    || extension.ToUpper().Equals("BMP") == true)
                {
                    MPCF.RunImageViewer(MPCF.ByteArrayToImage(this.HelpInfoFile), true);
                }
                // PDF인 경우
                else
                {
                    string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + "." + extension;
                    File.WriteAllBytes(path, this.HelpInfoFile);

                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = path;
                        process.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("BOIBaseForm02.pbHelp_Click() Error \n" + ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void lblFormTitle_MouseEnter(object sender, EventArgs e)
        {
            if (MPGV.gsUserGroup == "ADMIN_GROUP")
            {
                ToolTip LblTooltip = new ToolTip(new Container());
                LblTooltip.IsBalloon = true; 				//풍선 모양
                LblTooltip.SetToolTip(lblFormTitle, this.Name);
                LblTooltip.AutoPopDelay = 5000;

                LblTooltip.InitialDelay = 1000;

                LblTooltip.ReshowDelay = 500;
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public new void SetOITheme()
        {
            if (_UseOITheme == true)
            {
                // 속성

                // 색상
                if (MPGV.gTheme is clsLightColors)
                {
                    pbHelp.Image = Properties.Resources.HelpImage;
                    pbStdOper.Image = Properties.Resources.InfoImage;
                }
                else
                {
                    pbHelp.Image = Properties.Resources.HelpImage_DarkGray;
                    pbStdOper.Image = Properties.Resources.InfoImage_DarkGray;
                }

                //base.SetOITheme();
            }
        }

        /// <summary>
        /// Form의 기본 Font를 변경합니다.
        /// Common Variable에 변경할 Font의 크기를 설정하고 사용합니다.
        /// OI Style: 12pt
        /// UI Style: 9pt
        /// </summary>
        /// <param name="style"></param>
        public void SetFormStyle(SOIBaseFormStyle style)
        {
            // Auto Scale Mode Change
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            // Change Auto Scroll Margin
            if (style == SOIBaseFormStyle.OI_Style)
            {
                this.pnlMiddleMargin.AutoScrollMinSize = new System.Drawing.Size(0, 599);
            }
            else if (style == SOIBaseFormStyle.UI_Style)
            {
                this.pnlMiddleMargin.AutoScrollMinSize = new System.Drawing.Size(0, 597);
            }
            
            // Change Form Font
            MPCF.ChangeFormFont(this.pnlMiddleMargin, style);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        /// <summary>
        /// 즐겨찾기 화면 여부를 설정합니다.
        /// </summary>
        /// <returns></returns>
        public bool SetFavorite()
        {
            try
            {
                // 즐겨찾기 화면인 경우
                if (CheckFavorite(this) == true)
                {
                    //pbFavorite.Image = Image.FromFile(@"SOIResources\Icons\favoriteOn.png");
                    pbFavorite.Image = Properties.Resources.favoriteOn;
                    b_is_favorite = true;
                }
                else
                {
                    //pbFavorite.Image = Image.FromFile(@"SOIResources\Icons\favoriteOff.png");
                    pbFavorite.Image = Properties.Resources.favoriteOff;
                    b_is_favorite = false;
                }

                return true;
            }
            catch(Exception ex)
            {
                MPCF.ShowMessage("BOIBaseForm02.SetFavorite() Error \n" + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 즐겨찾기 화면 여부를 설정합니다.
        /// </summary>
        /// <returns></returns>
        public bool SetFavorite(bool bFavorite)
        {
            try
            {
                if (bFavorite == true)
                {
                    pbFavorite.Image = Properties.Resources.favoriteOn;
                    b_is_favorite = true;
                }
                else
                {
                    pbFavorite.Image = Properties.Resources.favoriteOff;
                    b_is_favorite = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("BOIBaseForm02.SetFavorite(bool) Error \n" + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Help 아이콘 활성화 여부를 설정합니다.
        /// 설정된 Help Guide 파일이 있는 경우 활성화 합니다.
        /// </summary>
        /// <returns></returns>
        public bool SetHelpInfo()
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_OUT");

            try
            {
                // 화면 명이 없는 경우 
                if (string.IsNullOrEmpty(this.menuInfo.s_func_name) == true)
                {
                    return false;
                }

                // Help File 호출
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FUNC_NAME", this.menuInfo.s_func_name);
                if (MPCF.CallService("SEC", "SEC_View_Function", in_node, ref out_node) == false)
                {
                    return false;
                }
                byte[] helpBytes = out_node.GetBlob(MPGC.MP_BIN_DATA_1);

                // Help File이 있는 경우
                if (helpBytes == null || helpBytes.Length < 1)
                {
                    return false;
                }
                else
                {
                    this.HelpInfoFileName = out_node.GetString(MPGC.MP_BIN_DATA_1 + "_FILE_NAME");
                    this.HelpInfoFile = helpBytes;
                    this.pbHelp.Visible = true;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("BOIBaseForm02.SetHelpInfo() Error \n" + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 즐겨찾기 화면 여부를 확인합니다.
        /// </summary>
        /// <returns></returns>
        public bool CheckFavorite(Form frm)
        {
            bool bResult = false;

            try
            {
                // 즐겨찾기 화면목록에서
                List<TRSNode> func_list;

                if (MPGV.galFavFunctionList != null 
                    && MPGV.galFavFunctionList.Count > 0
                    && MPGV.galFavFunctionList[0] != null)
                {
                    func_list = ((TRSNode)MPGV.galFavFunctionList[0]).GetList(0);
                }
                else
                {
                    return false;
                }

                for (int i = func_list.Count; i > 0; i--)
                {
                    // 현재 화면이 있는 경우
                    if (((MenuInfoTag)frm.Tag).s_func_name == func_list[i-1].GetString("FUNC_NAME"))
                    {
                        bResult = true;
                        iFavSeqNum = i;
                        break;
                    }
                }

                if (bResult == false)
                {
                    iFavSeqNum = func_list.Count + 1;
                }
                
            }
            catch(Exception ex)
            {
                MPCF.ShowMessage("BOIBaseForm02.CheckFavorite() Error \n" + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return bResult;
        }

        /// <summary>
        /// 즐겨찾기 등록/해제 합니다.
        /// </summary>
        public bool UpdateFavorite()
        {
            char cStep;

            // Favorite 등록된 화면인 경우
            if (b_is_favorite == true)
            {
                // 해제
                cStep = MPGC.MP_STEP_DELETE;
            }
            // Favorite 해제된 화면인 경우
            else
            {
                // 등록
                cStep = MPGC.MP_STEP_CREATE;
            }

            TRSNode in_node = new TRSNode("VIEW_FUNCTION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_LIST_OUT");

            MPCF.SetInMsg(in_node);

            in_node.ProcStep = cStep;
            in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
            in_node.AddString("FUNC_NAME", ((MenuInfoTag)this.Tag).s_func_name);
            in_node.AddString("USER_FUNC_DESC", ((MenuInfoTag)this.Tag).s_func_desc);
            in_node.AddInt("SEQ_NUM", iFavSeqNum);

            if (MPCF.CallService("SEC", "SEC_Update_Favorites", in_node, ref out_node) == false)
            {
                return false;
            }

            // 등록된 화면인 경우
            if (b_is_favorite == true)
            {
                //pbFavorite.Image = Image.FromFile(@"SOIResources\Icons\favoriteOff.png");
                pbFavorite.Image = Properties.Resources.favoriteOff;
                b_is_favorite = false;
            }
            // 해제된 화면인 경우
            else
            {
                //pbFavorite.Image = Image.FromFile(@"SOIResources\Icons\favoriteOn.png");
                pbFavorite.Image = Properties.Resources.favoriteOn;
                b_is_favorite = true;
            }

            return true;
        }

        /// <summary>
        /// Show Dialog 시에 Background Mask 화면을 보여줍니다.
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog(Form frmParent)
        {
            Panel pnlTopUnderline = new Panel();
            pnlTopUnderline.Height = 4;
            pnlTopUnderline.BackColor = Color.FromArgb(0, 72, 129);
            this.pnlTop.Controls.Add(pnlTopUnderline);
            pnlTopUnderline.Dock = DockStyle.Top;
            pnlTopUnderline.BringToFront();            

            this.pnlTopMargin.Controls.Add(this.pnlStdOper);
            if (MPGV.gIMdiForm.GetLoginState() == false)
            {
                MPCF.SetBackgroundMask(true);
            }
            MenuInfoTag menuInfo = new MenuInfoTag();
            menuInfo.s_func_desc = this.lblFormTitle.Text;
            this.Tag = menuInfo;
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Normal;
            this.pnlFavorite.Visible = false;            
            this.Left = frmParent.Left;
            this.Top = frmParent.Top;
            this.Height = frmParent.Height;
            this.Width = frmParent.Width;
            this.pnlTop.BackColor = Color.FromArgb(0, 120, 215);            
            this.lblFormTitle.Appearance.ForeColor = Color.FromArgb(255, 255, 255);

            this.ResumeLayout(false);
            this.PerformLayout();
            
            return base.ShowDialog();
            
        }

        public void SetCommSetupPanel()
        {
            
            lblCommSetup = new Label();                               
            
            lblCommSetup.AutoSize = false;
            lblCommSetup.Size = new System.Drawing.Size(20, 50);
            lblCommSetup.Click += new EventHandler(lblCommSetup_Click);
            lblCommSetup.Paint += new PaintEventHandler(lblCommSetup_Paint);
            h101TunerStatusBar = new BOIControls.H101TunerStatusBar();
            comSwitch = new BOIControls.COMSwitch();
            pnlCommSetup = new Panel();
            pnlCommSetup.Controls.Add(h101TunerStatusBar);
            h101TunerStatusBar.Dock = DockStyle.Bottom;
            h101TunerStatusBar.BringToFront();
            pnlCommSetup.Controls.Add(comSwitch);
            comSwitch.Dock = DockStyle.Fill;
            comSwitch.BringToFront();              

            this.pnlTop.Controls.Add(pnlCommSetup);            
            pnlCommSetup.Dock = DockStyle.Right;            
            pnlCommSetup.SendToBack();
            pnlCommSetup.Visible = false;

            this.pnlTop.Controls.Add(lblCommSetup);
            lblCommSetup.Dock = DockStyle.Right;
            lblCommSetup.SendToBack();     

        }

        void lblCommSetup_Paint(object sender, PaintEventArgs e)
        {
            //Pen rectpen = new Pen(Color.Gray, 1);                      
            Pen pen = new Pen(Color.White, 6);
            //Line의 시작점 모양 변경 
            pen.EndCap = LineCap.ArrowAnchor;
            //Line의 끝점 모양 변경          
            //e.Graphics.DrawRectangle(rectpen, 0, 0, lblCommSetup.Width, lblCommSetup.Height);              
            e.Graphics.DrawLine(pen, 15, 10, 0, 10); //Line 그리기 
        }

        void lblCommSetup_Click(object sender, EventArgs e)
        {
            if (pnlCommSetup.Visible == false)
            {
                pnlCommSetup.Visible = true;
                lblCommSetup.Dock = DockStyle.Right;
                lblCommSetup.BringToFront();
                pnlCommSetup.Dock = DockStyle.Right;
                pnlCommSetup.BringToFront();
                pnlTopMargin.Width = pnlTopMargin.Width - pnlCommSetup.Width;
                pnlTopMargin.BringToFront();
            }
            else
            {
                pnlCommSetup.Visible = false;
                pnlTopMargin.Width = pnlTopMargin.Width + pnlCommSetup.Width;
                lblCommSetup.Dock = DockStyle.Right;
                lblCommSetup.SendToBack();

            }
        }

        #endregion

        

    }
}
