using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx;
using Miracom.TRSCore;
using SOI.CliFrx;

namespace StandardOI
{
    public partial class frmUserInfo : frmPopupBase
    {
        #region Property

        private bool _loadedFlag = false;

        /// <summary>
        /// 팝업 화면의 그림자를 처리합니다.
        /// 팝업 화면 로드 시 디자인 처리가 완료되면 화면을 표시할 수 있도록 처리합니다.
        /// </summary>
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        #endregion

        #region Constructor

        public frmUserInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// 화면이 로드될 때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            // 다국어 변환
            MPCF.ConvertCaption(this);

            // 로드 서비스
            if (ViewUserInfo(MPGV.gsUserID) == false)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 화면이 활성화 될 때 발생합니다.
        /// 초기 Focus 컨트롤을 설정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUserInfo_Activated(object sender, EventArgs e)
        {
            if (_loadedFlag == false)
            {
                _loadedFlag = true;

                MPCF.SetFocus(txtPassword);
            }
        }

        /// <summary>
        /// 변경된 사용자 정보를 Update 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {  
            // 2016.09.20 wjkim
            // MPCF.CheckValue()가 보안상 Heap에 password를 저장하는 위험이 있어
            // null check --> focus 방식으로 변경.
            if (string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                txtPassword.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNewPassword.Text) == true)
            {
                txtNewPassword.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtConfirmPassword.Text) == true)
            {
                txtConfirmPassword.Focus();
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MPCF.ShowMessage("New password does not match with confirm password", MSG_LEVEL.ERROR, true);
                return;
            }

            if (UpdateUserInfo() == false)
            {
                return;
            }

            this.Close();
        }

        /// <summary>
        /// 화면을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Function

        /// <summary>
        /// User 정보 조회
        /// </summary>
        /// <param name="sUserId"></param>
        /// <returns></returns>
        public bool ViewUserInfo(string sUserId)
        {
            TRSNode in_node = new TRSNode("VIEW_USER_IN");
            TRSNode out_node = new TRSNode("VIEW_USER_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("USER_ID", sUserId);

                if (MPCF.CallService("SEC", "SEC_View_User", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtUserID.Text = out_node.GetString("USER_ID");
                txtSecGroup.Text = out_node.GetString("SEC_GRP_ID");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }
        }

        /// <summary>
        /// 사용자 정보를 Update 합니다.
        /// </summary>
        /// <returns></returns>
        private bool UpdateUserInfo()
        {
            try
            {
                TRSNode in_node = new TRSNode("UPDATE_USER_IN");
                TRSNode out_node = new TRSNode("UPDATE_USER_OUT");

#if _H101
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CURRENT_PASSWORD", MPCF.ToUpper(txtPassword.Text));
                in_node.AddString("NEW_PASSWORD", MPCF.ToUpper(txtNewPassword.Text));
                in_node.AddString("CONFIRM_PASSWORD", MPCF.ToUpper(txtConfirmPassword.Text));

                if (MPCF.CallService("SEC", "SEC_Change_Password_Ext", in_node, ref out_node) == false)
                {
                    return false;
                }
#endif

#if _HTTP
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'U';
                in_node.AddString("USER_ID", txtUserID.Text);
                in_node.AddString("CURRENT_PASSWORD", txtPassword.Text);
                in_node.AddString("NEW_PASSWORD", txtNewPassword.Text);
                in_node.AddString("CONFIRM_PASSWORD", txtConfirmPassword.Text);
                in_node.AddString("SEC_GRP_ID", txtSecGroup.Text);

                if (MPCF.CallService("SEC", "SEC_UPDATE_USER_PROFILE", in_node, ref out_node) == false)
                {
                    MPCF.ShowMessage(out_node.GetString("MSG"), MSG_LEVEL.ERROR, true);
                    return false;
                }
#endif

                MPCF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }
        }

        #endregion

        
    }
}
