namespace SOI.Solar.Controls
{
    partial class udcUser
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.pnlDesc = new System.Windows.Forms.Panel();
            this.pnlUserDesc = new System.Windows.Forms.Panel();
            this.txtUserDesc = new System.Windows.Forms.TextBox();
            this.pnlMargin = new System.Windows.Forms.Panel();
            this.pnlUserID = new System.Windows.Forms.Panel();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.pnlLeft.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.pnlDesc.SuspendLayout();
            this.pnlUserDesc.SuspendLayout();
            this.pnlUserID.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblUser);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(60, 30);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.Location = new System.Drawing.Point(0, 3);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(60, 24);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.pnlDesc);
            this.pnlMid.Controls.Add(this.pnlUserID);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(60, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(359, 30);
            this.pnlMid.TabIndex = 1;
            // 
            // pnlDesc
            // 
            this.pnlDesc.Controls.Add(this.pnlUserDesc);
            this.pnlDesc.Controls.Add(this.pnlMargin);
            this.pnlDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesc.Location = new System.Drawing.Point(124, 0);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Size = new System.Drawing.Size(235, 30);
            this.pnlDesc.TabIndex = 4;
            // 
            // pnlUserDesc
            // 
            this.pnlUserDesc.Controls.Add(this.txtUserDesc);
            this.pnlUserDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserDesc.Location = new System.Drawing.Point(8, 0);
            this.pnlUserDesc.Name = "pnlUserDesc";
            this.pnlUserDesc.Size = new System.Drawing.Size(227, 30);
            this.pnlUserDesc.TabIndex = 4;
            // 
            // txtUserDesc
            // 
            this.txtUserDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserDesc.Location = new System.Drawing.Point(0, 0);
            this.txtUserDesc.Name = "txtUserDesc";
            this.txtUserDesc.ReadOnly = true;
            this.txtUserDesc.Size = new System.Drawing.Size(227, 29);
            this.txtUserDesc.TabIndex = 2;
            // 
            // pnlMargin
            // 
            this.pnlMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMargin.Location = new System.Drawing.Point(0, 0);
            this.pnlMargin.Name = "pnlMargin";
            this.pnlMargin.Size = new System.Drawing.Size(8, 30);
            this.pnlMargin.TabIndex = 3;
            // 
            // pnlUserID
            // 
            this.pnlUserID.Controls.Add(this.txtUserID);
            this.pnlUserID.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUserID.Location = new System.Drawing.Point(0, 0);
            this.pnlUserID.Name = "pnlUserID";
            this.pnlUserID.Size = new System.Drawing.Size(124, 30);
            this.pnlUserID.TabIndex = 3;
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserID.Location = new System.Drawing.Point(0, 0);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(124, 29);
            this.txtUserID.TabIndex = 1;
            this.txtUserID.Click += new System.EventHandler(this.txtUserID_Click);
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            this.txtUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserID_KeyPress);
            // 
            // udcUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.Name = "udcUser";
            this.Size = new System.Drawing.Size(419, 30);
            this.Load += new System.EventHandler(this.udcUser_Load);
            this.FontChanged += new System.EventHandler(this.udcUser_FontChanged);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.pnlDesc.ResumeLayout(false);
            this.pnlUserDesc.ResumeLayout(false);
            this.pnlUserDesc.PerformLayout();
            this.pnlUserID.ResumeLayout(false);
            this.pnlUserID.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUserDesc;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Panel pnlDesc;
        private System.Windows.Forms.Panel pnlUserDesc;
        private System.Windows.Forms.Panel pnlMargin;
        private System.Windows.Forms.Panel pnlUserID;
    }
}
