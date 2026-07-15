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

namespace BOI.OIFrx.BOIBaseForm
{
    public partial class BOIBasePopup02 : BOIBasePopup01
    {
        #region Property

        //private bool b_is_favorite;
        //private MenuInfoTag menuInfo;
        //private int iFavSeqNum;

        private bool b_is_drag = false;

        //private int iInitCount = 0;

        private Point pt_mouse_location;
        

        //public new bool _UseOITheme
        //{
        //    get
        //    {
        //        return base._UseOITheme;
        //    }
        //    set
        //    {
        //        base._UseOITheme = value;
        //        SetOITheme();
        //    }
        //}

        //private string _helpInfoFileName;
        //[Browsable(false)]
        //public string HelpInfoFileName
        //{
        //    get { return _helpInfoFileName; }
        //    set { _helpInfoFileName = value; }
        //}

        //private byte[] _helpInfoFile;
        //[Browsable(false)]
        //public byte[] HelpInfoFile
        //{
        //    get { return _helpInfoFile; }
        //    set { _helpInfoFile = value; }
        //}

        //private SOIBaseFormStyle _soiFormStyle;
        //public SOIBaseFormStyle _SOIFormStyle
        //{
        //    get { return _soiFormStyle; }
        //    set 
        //    {
        //        bool bApply = true;
        //        if (_soiFormStyle == SOIBaseFormStyle.Undefined
        //            && iInitCount < 1)
        //        {
        //            bApply = false;
        //        }
        //        _soiFormStyle = value;
        //        iInitCount++;

        //        if (bApply == true)
        //        {                    
        //            SetFormStyle(_soiFormStyle);                    
        //        }
        //    }
        //}

        #endregion

        #region Constructor

        public BOIBasePopup02()
        {
            InitializeComponent();
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
        private void BOIBasePopup02_Load(object sender, EventArgs e)
        {
            if (DesignMode == true)
            {
                return;
            }

            // 테마 로드
            //SetOITheme();

            // Menu 정보 로드
            //menuInfo = (MenuInfoTag)this.Tag;

            // 즐겨찾기 설정
            //SetFavorite();

            // Help Guide 설정
            //SetHelpInfo();
        }       

        

        ///// <summary>
        ///// Show Dialog 시에 Background Mask 화면을 보여줍니다.
        ///// </summary>
        ///// <returns></returns>
        //public new DialogResult ShowDialog()
        //{
        //    if (MPGV.gIMdiForm.GetLoginState() == false)
        //    {
        //        MPCF.SetBackgroundMask(true);
        //    }
        //    return base.ShowDialog();
        //}

        private void pnlTopMargin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                b_is_drag = true;
                pt_mouse_location = e.Location;
            }
        }

        private void pnlTopMargin_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_drag)
            {
                this.Location = new Point((this.Location.X - pt_mouse_location.X) + e.X, (this.Location.Y - pt_mouse_location.Y) + e.Y);
            }
        }

        private void pnlTopMargin_MouseUp(object sender, MouseEventArgs e)
        {
            b_is_drag = false;
        }


        private void lblFormTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                b_is_drag = true;
                pt_mouse_location = e.Location;
            }
        }

        private void lblFormTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_drag)
            {
                this.Location = new Point((this.Location.X - pt_mouse_location.X) + e.X, (this.Location.Y - pt_mouse_location.Y) + e.Y);
            }
        }

        private void lblFormTitle_MouseUp(object sender, MouseEventArgs e)
        {
            b_is_drag = false;
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
                //if (MPGV.gTheme is clsLightColors)
                //{
                //    pbHelp.Image = Properties.Resources.HelpImage;
                //    pbStdOper.Image = Properties.Resources.InfoImage;
                //}
                //else
                //{
                //    pbHelp.Image = Properties.Resources.HelpImage_DarkGray;
                //    pbStdOper.Image = Properties.Resources.InfoImage_DarkGray;
                //}

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
        public override void SetFormStyle(SOIBaseFormStyle style)
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
        /// Show Dialog 시에 Background Mask 화면을 보여줍니다.
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            if (MPGV.gIMdiForm.GetLoginState() == false)
            {
                MPCF.SetBackgroundMask(true);
            }

            
            this.StartPosition = FormStartPosition.CenterParent;            
            this.WindowState = FormWindowState.Normal;          
            return base.ShowDialog();
        }

        /// <summary>
        /// Show Dialog 시에 Background Mask 화면을 보여줍니다.
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog(Form frmParent)
        {
            if (MPGV.gIMdiForm.GetLoginState() == false)
            {
                MPCF.SetBackgroundMask(true);
            }                            
            
            this.Left = frmParent.Left;
            this.Top = frmParent.Top;
            this.Height = frmParent.Height;
            this.Width = frmParent.Width;
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Normal;
            return base.ShowDialog();
        }

        #endregion


        

    }
}
