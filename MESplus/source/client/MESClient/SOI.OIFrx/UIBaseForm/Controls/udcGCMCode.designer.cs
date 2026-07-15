namespace SOI.OIFrx
{
    partial class udcGCMCode
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
            this.lblLabel = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.cdvData = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlLeft.SuspendLayout();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblLabel);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(60, 20);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblLabel
            // 
            this.lblLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLabel.Location = new System.Drawing.Point(0, 3);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(60, 14);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Data";
            this.lblLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.cdvData);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(60, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(172, 20);
            this.pnlMid.TabIndex = 1;
            // 
            // cdvData
            // 
            this.cdvData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvData.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvData.BtnToolTipText = "Get flow list";
            this.cdvData.ButtonWidth = 20;
            this.cdvData.DescText = "";
            this.cdvData.DisplaySubItemIndex = -1;
            this.cdvData.DisplayText = "";
            this.cdvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvData.Focusing = null;
            this.cdvData.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvData.Index = 0;
            this.cdvData.IsViewBtnImage = false;
            this.cdvData.Location = new System.Drawing.Point(0, 0);
            this.cdvData.MaxLength = 32767;
            this.cdvData.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvData.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvData.Name = "cdvData";
            this.cdvData.ReadOnly = false;
            this.cdvData.SameWidthHeightOfButton = false;
            this.cdvData.SearchSubItemIndex = 0;
            this.cdvData.SelectedDescIndex = -1;
            this.cdvData.SelectedSubItemIndex = -1;
            this.cdvData.SelectionStart = 0;
            this.cdvData.Size = new System.Drawing.Size(172, 20);
            this.cdvData.SmallImageList = null;
            this.cdvData.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvData.TabIndex = 0;
            this.cdvData.TextBoxToolTipText = "";
            this.cdvData.TextBoxWidth = 172;
            this.cdvData.VisibleButton = true;
            this.cdvData.VisibleColumnHeader = false;
            this.cdvData.VisibleDescription = false;
            this.cdvData.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvData_SelectedItemChanged);
            this.cdvData.ButtonPress += new System.EventHandler(this.cdvData_ButtonPress);
            this.cdvData.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvData_TextBoxKeyPress);
            this.cdvData.TextBoxTextChanged += new System.EventHandler(this.cdvData_TextBoxTextChanged);
            this.cdvData.TextBoxLostFocus += new System.EventHandler(this.cdvData_TextBoxLostFocus);
            this.cdvData.TextBoxGotFocus += new System.EventHandler(this.cdvData_TextBoxGotFocus);
            // 
            // udcGCMCode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(500, 20);
            this.MinimumSize = new System.Drawing.Size(100, 20);
            this.Name = "udcGCMCode";
            this.Size = new System.Drawing.Size(232, 20);
            this.FontChanged += new System.EventHandler(this.udcCComCodeGCM_FontChanged);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.Label lblLabel;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvData;
    }
}
