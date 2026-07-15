using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    public partial class frmMessageBox : Form
    {
        #region Constructor
        
        public frmMessageBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Show Dialog 시에 Background Mask 화면을 보여줍니다.
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            // Parent 설정
            if (this.Owner != null)
            {
                base.Owner = this.Owner;
            }

            return base.ShowDialog();
        }

        /// <summary>
        /// 메시지 박스 로드 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            try
            {
                // Message Box Location
                pnlMsgBox.Location = MPOF.CalcLocationFormCenter(this, pnlMsgBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        /// <summary>
        /// Background Mask Hide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMessageBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (CMNV.gIMdiForm.GetLoginState() == false)
            //{
            //    CMNF.SetBackgroundMask(false);
            //}
        }

        /// <summary>
        /// Yes 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// No 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// OK 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Cancel 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Function

        /// <summary>
        /// Message Box의 버튼을 설정합니다.
        /// </summary>
        /// <param name="msgButton"></param>
        public void SetButtonType(MessageBoxButtons msgButton)
        {
            btnYes.Visible = false;
            btnNo.Visible = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;

            switch (msgButton)
            {
                case MessageBoxButtons.OK:
                    btnOK.Visible = true;
                    btnOK.Dock = DockStyle.Fill;
                    this.AcceptButton = btnOK;
                    btnOK.Focus();
                    break;
                case MessageBoxButtons.YesNo:
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    btnYes.Width = pnlButtons.Width / 2;
                    btnYes.Dock = DockStyle.Left;
                    btnNo.Dock = DockStyle.Fill;
                    this.AcceptButton = btnYes;
                    this.CancelButton = btnNo;
                    btnYes.Focus();
                    break;
                case MessageBoxButtons.OKCancel:
                    btnOK.Visible = true;
                    btnCancel.Visible = true;
                    btnOK.Width = pnlButtons.Width / 2;
                    btnOK.Dock = DockStyle.Left;
                    btnCancel.Dock = DockStyle.Fill;
                    this.AcceptButton = btnOK;
                    this.CancelButton = btnCancel;
                    btnOK.Focus();
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    btnCancel.Visible = true;
                    btnYes.Width = pnlButtons.Width / 3;
                    btnYes.Dock = DockStyle.Left;
                    btnNo.Width = pnlButtons.Width / 3;
                    btnNo.Dock = DockStyle.Left;
                    btnCancel.Dock = DockStyle.Fill;
                    this.AcceptButton = btnYes;
                    this.CancelButton = btnCancel;
                    btnYes.Focus();
                    break;
            }
        }

        /// <summary>
        /// Message Box의 Level을 설정합니다.
        /// </summary>
        /// <param name="msgLevel"></param>
        /// <param name="sCaption"></param>
        public void SetMsgLevel(MSSAG_LEVEL msgLevel, string sCaption)
        {
            if (MPOF.Trim(sCaption) == "")
            {
                lblCaption.Text = "";

                switch (msgLevel)
                {
                    case MSSAG_LEVEL.ERROR:
                        lblCaption.Text = "Error";
                        lblCaption.Appearance.BackColor = Color.Red;
                        break;
                    case MSSAG_LEVEL.WARNING:
                        lblCaption.Text = "Warning";
                        lblCaption.Appearance.BackColor = Color.Orange;
                        break;
                    case MSSAG_LEVEL.INFO:
                        lblCaption.Text = "Information";
                        lblCaption.Appearance.BackColor = Color.SkyBlue;
                        break;
                    case MSSAG_LEVEL.NONE:
                        lblCaption.Text = "Message";
                        lblCaption.Visible = false;
                        pnlCaption.Visible = false;
                        pnlTopUnderline.Visible = false;
                        break;
                }
            }
            else
            {
                lblCaption.Text = sCaption;

                switch (msgLevel)
                {
                    case MSSAG_LEVEL.ERROR:
                        lblCaption.Appearance.BackColor = Color.Red;
                        break;
                    case MSSAG_LEVEL.WARNING:
                        lblCaption.Appearance.BackColor = Color.Orange;
                        break;
                    case MSSAG_LEVEL.INFO:
                        lblCaption.Appearance.BackColor = Color.SkyBlue;
                        break;
                    case MSSAG_LEVEL.NONE:
                        lblCaption.Visible = false;
                        pnlCaption.Visible = false;
                        pnlTopUnderline.Visible = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Message Box의 메시지를 설정합니다.
        /// </summary>
        /// <param name="message"></param>
        public void SetMessage(string message)
        {
            if(string.IsNullOrEmpty(message) == false)
            {
                using(Graphics g = CreateGraphics()) 
                {
                    SizeF size = g.MeasureString(message, lblMessage.Font);

                    if (size.Height >= lblMessage.Height
                        || (Math.Ceiling(size.Width) * Math.Ceiling(size.Height)) >= (lblMessage.Width * lblMessage.Height))
                    {
                        ChangeLabelVisibe(false);
                        txtMessage.Text = message;
                    }
                    else
                    {
                        ChangeLabelVisibe(true);
                        lblMessage.Text = message;
                    }
                }
            }
        }

        private void ChangeLabelVisibe(bool visible)
        {
            if (visible == true)
            {
                this.lblMessage.Visible = true;
                this.txtMessage.Visible = false;
            }
            else
            {
                this.lblMessage.Visible = false;
                this.txtMessage.Visible = true;
            }
        }


        #endregion
    }
}
