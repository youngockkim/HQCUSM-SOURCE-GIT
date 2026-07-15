using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIThemes;

namespace SOI.OIFrx.SOIPopup
{
    public partial class frmPopupBase : Form
    {
        #region Property

        private bool b_is_drag = false;
        private int iInitCount = 0;
        private Point pt_mouse_location;

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

        private SOIPopupShowStyle _soiPopupShowStyle;
        public SOIPopupShowStyle _SOIPopupShowStyle
        {
            get { return _soiPopupShowStyle; }
            set { _soiPopupShowStyle = value; }
        }

        #endregion

        #region Constructor

        public frmPopupBase()
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
                // 테마를 사용하는 경우에만 적용
                if (_UseOITheme == true)
                {
                    SetOITheme();
                }
            }

            base.OnPaint(pe);
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

            if (this._SOIPopupShowStyle == SOIPopupShowStyle.Maximized)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Left = MPGV.gfrmMDI.Left + 3;
                this.Top = MPGV.gfrmMDI.Top + 46;
                this.Width = MPGV.gIMdiForm.GetMainWidthForChildForm();
                this.Height = MPGV.gIMdiForm.GetMainHeightForChildForm();
            }

            return base.ShowDialog();
        }

        /// <summary>
        /// Base Popup Form을 로드할 때 테마를 적용합니다.
        /// 실제 적용되는 화면은 상속받은 화면 입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopupBase_Load(object sender, EventArgs e)
        {
            MPCF.LoadControlTheme(this);
        }

        /// <summary>
        /// 화면을 닫으며 Owner를 Activate 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopupBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 팝업 화면을 닫는 경우 뒷배경을 제거 합니다.
                if (MPGV.gIMdiForm.GetLoginState() == false)
                {
                    MPCF.SetBackgroundMask(false);
                }

                if (this._soiPopupShowStyle == SOIPopupShowStyle.PopupAsFunc)
                {
                    // 화면을 목록에서 제거
                    if (MPGV.glOpenChildForm.Contains(this) == true)
                    {
                        MPGV.glOpenChildForm.Remove(this);
                    }

                    // 배경 화면 Show
                    if (MPGV.glOpenChildForm.Count < 2)
                    {
                        MPGV.gIMdiForm.SetDefaultBackgroundForm();
                    }

                    // Message Bar를 초기화 합니다.
                    MPCF.ShowMessageClear();

                    // Memory Flush
                    MPCF.FlushMemory();
                }
                else
                {
                    // Owner가 있는 경우 Owner를 활성화 합니다.
                    if (this.Owner != null)
                    {
                        Owner.Activate();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("frmPopupBase_FormClosed() \n" + ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// 화면 이동 로직 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPopupTopMargin_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._SOIPopupShowStyle == SOIPopupShowStyle.Normal)
            {
                if (e.Button == MouseButtons.Left)
                {
                    b_is_drag = true;
                    pt_mouse_location = e.Location;
                }
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

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            this.BackColor = MPGV.gTheme.PopupTopBackground;
            lblPopupTitle.Appearance.ForeColor = MPGV.gTheme.PopupTopForeground;
            this.pnlPopupTop.BackColor = MPGV.gTheme.PopupTopBackground;
            this.pnlPopupTopUnderline.BackColor = MPGV.gTheme.PopupTopUnderline;
            this.pnlPopupMiddle.BackColor = MPGV.gTheme.PopupMiddleBackground;
            this.pnlPopupBottom.BackColor = MPGV.gTheme.PopupBottomBackground;
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

            //// Change Auto Scroll Margin
            //if (style == SOIBaseFormStyle.OI_Style)
            //{
            //    this.pnlPopupMiddleMargin.AutoScrollMinSize = new System.Drawing.Size(0, 599);
            //}
            //else if (style == SOIBaseFormStyle.UI_Style)
            //{
            //    this.pnlPopupMiddleMargin.AutoScrollMinSize = new System.Drawing.Size(0, 597);
            //}

            // Change Form Font
            MPCF.ChangeFormFont(this.pnlPopupMiddleMargin, style);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }
}
