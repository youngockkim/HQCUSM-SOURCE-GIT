using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.CliFrx;
using SOI.OIFrx;
using SOI.OIFrx.SOIControls;

namespace BOI.OIFrx.BOIBaseForm
{
    public partial class BOIBasePopup01 : Form
    {
        #region Property

        private int iInitCount = 0;


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

        private bool _useOITheme = true; // 최초 컨트롤 Add시 Default로 테마 적용
        public bool _UseOITheme
        {
            get
            {
                return _useOITheme;
            }
            set
            {
                _useOITheme = value;
                SetOITheme();
            }
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

        public BOIBasePopup01()
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
        /// 화면 로드 시 발생합니다.
        /// Title 이름 처리.
        /// 다국어 처리.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BOIBasePopup01_Load(object sender, EventArgs e)
        {
            if (DesignMode == true)
            {
                SetOITheme();
                return;
            }

            // Menu 정보 로드
            //menuInfo = (MenuInfoTag)this.Tag;

            // Title 설정
            //SetTitle();

            // 테마 로드
            MPCF.LoadControlTheme(this);

            // 언어 설정된것으로 변경
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// 화면이 닫힐 때 발생합니다.
        /// Message Bar를 초기화 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BOIBasePopup01_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 팝업 화면을 닫는 경우 뒷배경을 제거 합니다.
                if (MPGV.gIMdiForm.GetLoginState() == false)
                {
                    MPCF.SetBackgroundMask(false);
                }

                // Message Bar를 초기화 합니다.
                //MPCF.ShowMessageClear();

                // Owner가 있는 경우 Owner를 활성화 합니다.
                if (this.Owner != null)
                {
                    Owner.Activate();
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("BOIBasePopup01_FormClosed() \n" + ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// 화면을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
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
            
            // 화면 닫기
            this.Close();
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
            return base.ShowDialog();
        }

        #endregion

        #region Function

        /// <summary>
        /// 화면 이름을 FUNC_DESC로 설정합니다.
        /// </summary>
        public void SetTitle()
        {
            //lblFormTitle.Text = MPCF.FindLanguage(menuInfo.s_func_desc);
#if _H101
            //lblFormTitle.Text = MPCF.FindLanguage(menuInfo.s_func_desc);
#endif
#if _Http
            lblFormTitle.Text = menuInfo.s_func_desc;
#endif
        }

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            if (_UseOITheme == true)
            {

                // 색상
                this.pnlTop.BackColor = MPGV.gTheme.FormTopBackground;
                this.pnlBottom.BackColor = MPGV.gTheme.FormBottomBackground;
                this.pnlMiddle.BackColor = MPGV.gTheme.FormMiddleBackground;
                this.lblFormTitle.Appearance.ForeColor = MPGV.gTheme.FormTitleForeground;
            }
        }


        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        //public void SetOITheme()
        //{
        //    this.BackColor = MPGV.gTheme.PopupTopBackground;
        //    lblPopupTitle.Appearance.ForeColor = MPGV.gTheme.PopupTopForeground;
        //    this.pnlPopupTop.BackColor = MPGV.gTheme.PopupTopBackground;
        //    this.pnlPopupTopUnderline.BackColor = MPGV.gTheme.PopupTopUnderline;
        //    this.pnlPopupMiddle.BackColor = MPGV.gTheme.PopupMiddleBackground;
        //    this.pnlPopupBottom.BackColor = MPGV.gTheme.PopupBottomBackground;
        //}

        /// <summary>
        /// Form의 기본 Font를 변경합니다.
        /// Common Variable에 변경할 Font의 크기를 설정하고 사용합니다.
        /// OI Style: 12pt
        /// UI Style: 9pt
        /// </summary>
        /// <param name="style"></param>
        public virtual void SetFormStyle(SOIBaseFormStyle style)
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
            //MPCF.ChangeFormFont(this.pnlPopupMiddleMargin, style);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

       
    }
}
