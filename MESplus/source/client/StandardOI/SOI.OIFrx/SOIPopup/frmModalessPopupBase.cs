using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx.SOIPopup
{
    public partial class frmModalessPopupBase : Form
    {
        #region Property

        private bool b_is_drag = false;
        private bool b_is_size_change = false;        

        private Point pt_mouse_location;

        /// <summary>
        /// 테마 사용 여부를 설정합니다.
        /// </summary>
        private bool _useOITheme = true;
        public bool _UseOITheme
        {
            get
            {
                return _useOITheme;
            }
            set
            {
                _useOITheme = value;
                if (_useOITheme == true)
                {
                    // Use OI Theme 변경 시 테마 적용
                    SetOITheme();
                }
            }
        }

        #endregion

        #region Constructor

        public frmModalessPopupBase()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Paint 이벤트 발생 시 디자인 타임에서만 적용합니다.
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
        /// Base Popup Form을 로드할 때 테마를 적용합니다.
        /// 실제 적용되는 화면은 상속받은 화면 입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmModalessPopupBase_Load(object sender, EventArgs e)
        {
            MPCF.LoadControlTheme(this);
        }

        /// <summary>
        /// Popup 화면을 최대화 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPopupTopMargin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Maximized 상태인 경우
            if (this.WindowState == FormWindowState.Normal)
            {
                if (Screen.FromHandle(this.Handle).Primary == true)
                {
                    this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                }
                else
                {
                    this.MaximizedBounds = new Rectangle();
                }

                this.WindowState = FormWindowState.Maximized;
            }
            // Normal 상태인 경우
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// 화면 이동 로직 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPopupTopMargin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                b_is_drag = true;
                pt_mouse_location = e.Location;
            }
        }

        /// <summary>
        /// 화면 이동 로직 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPopupTopMargin_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_is_drag)
            {
                this.Location = new Point((this.Location.X - pt_mouse_location.X) + e.X, (this.Location.Y - pt_mouse_location.Y) + e.Y);
            }
        }

        /// <summary>
        /// 화면 이동 로직 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPopupTopMargin_MouseUp(object sender, MouseEventArgs e)
        {
            b_is_drag = false;
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

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            // 테마를 사용하는 경우에만 적용
            if (_UseOITheme == true)
            {
                this.BackColor = MPGV.gTheme.PopupTopBackground;
                lblPopupTitle.Appearance.ForeColor = MPGV.gTheme.PopupTopForeground;
                this.pnlPopupTop.BackColor = MPGV.gTheme.PopupTopBackground;
                this.pnlPopupTopUnderline.BackColor = MPGV.gTheme.PopupTopUnderline;
                this.pnlPopupMiddle.BackColor = MPGV.gTheme.PopupMiddleBackground;
                this.pnlPopupBottom.BackColor = MPGV.gTheme.PopupBottomBackground;

                this.pnlOutTopLeft.BackColor = MPGV.gTheme.PopupTopBackground;
                this.pnlOutTopMiddle.BackColor = MPGV.gTheme.PopupTopBackground;
                this.pnlOutTopRight.BackColor = MPGV.gTheme.PopupTopBackground;
                this.pnlOutMiddleLeft.BackColor = MPGV.gTheme.PopupTopBackground;
                this.pnlOutMiddleRight.BackColor = MPGV.gTheme.PopupTopBackground;
                this.pnlOutBottomLeft.BackColor = MPGV.gTheme.PopupTopBackground;
                this.pnlOutBottomMiddle.BackColor = MPGV.gTheme.PopupTopBackground;
                this.pnlOutBottomRight.BackColor = MPGV.gTheme.PopupTopBackground;
            }
        }

        #endregion
    }
}
