using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SOI.CliFrx;
using Miracom.CliFrx;

namespace SOI.OIFrx.SOIBaseForm
{
    public partial class SOIBaseForm06 : Form
    {
        #region Property

      //  private MenuInfoTag menuInfo;

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

        public SOIBaseForm06()
        {
            InitializeComponent();
            DisabledFormControls = new ArrayList();
        }

        public ArrayList DisabledFormControls;

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
        private void SOIBaseForm06_Load(object sender, EventArgs e)
        {
            //if (DesignMode == true)
            //{
            //    SetOITheme();
            //    return;
            //}

            //// Menu 정보 로드
            //menuInfo = (MenuInfoTag)this.Tag;

            //// Title 설정
            // SetTitle();


            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }

            //// 테마 로드
            //MPOF.LoadControlTheme(this);

            //if (MOGV.gIBaseFormEvent != null)
            //{
            //    MOGV.gIBaseFormEvent.Form_Load(this, e);
            //}

        }

        /// <summary>
        /// 화면이 닫힐 때 발생합니다.
        /// Message Bar를 초기화 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SOIBaseForm06_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (MOGV.gIBaseFormEvent != null)
                {
                    MOGV.gIBaseFormEvent.Form_Closed(this, e);
                }

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

                //this.Dispose();
                // Memory Flush
                MPOF.FlushMemory();
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage("SOIBaseForm06_FormClosed() \n" + ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// 화면을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 화면 닫기
            this.Close();
        }

        #endregion

        #region Function

        /// <summary>
        /// 화면 이름을 FUNC_DESC로 설정합니다.
        /// </summary>
        public void SetTitle()
        {
//            lblFormTitle.Text = MPCF.FindLanguage(menuInfo.s_func_desc);
//#if _H101
//            lblFormTitle.Text = MPOF.FindLanguage(menuInfo.s_func_desc);
//#endif
//#if _Http
//            lblFormTitle.Text = menuInfo.s_func_desc;
//#endif
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
               // this.pnlTop.BackColor = MOGV.gTheme.FormTopBackground;
                this.pnlBottom.BackColor = MOGV.gTheme.FormBottomBackground;
                this.pnlMiddle.BackColor = MOGV.gTheme.FormMiddleBackground;
               // this.lblFormTitle.Appearance.ForeColor = MOGV.gTheme.FormTitleForeground;
            }
        }

        public void DisplayMessage(string sMessage, MSSAG_LEVEL msgLevel)
        {
            // 메시지 레벨에 따라 내용 및 아이콘 변경
            switch (msgLevel)
            {
                case MSSAG_LEVEL.INFO:
                    pb.Image = Properties.Resources.Main_Msg_Info;
                    lblMessage.Text = sMessage;
                    lblMessage.ForeColor = Color.White;
                    break;
                case MSSAG_LEVEL.WARNING:
                    pb.Image = Properties.Resources.Main_Msg_Warn;
                    lblMessage.Text = sMessage;
                    lblMessage.ForeColor = Color.Yellow;
                    break;
                case MSSAG_LEVEL.ERROR:
                    pb.Image = Properties.Resources.Main_Msg_Error;
                    lblMessage.Text = sMessage;
                    lblMessage.ForeColor = Color.Red;
                    break;
                case MSSAG_LEVEL.SUCCESS:
                    pb.Image = Properties.Resources.Main_Msg_Info;
                    lblMessage.Text = sMessage;
                    lblMessage.ForeColor = Color.White;
                    break;
            }

            if (MOGV.gbPlaySoundFlag == true)
            {
                MOSF.PlaySound((int)msgLevel);
            }
        }

        #endregion
    }
}
