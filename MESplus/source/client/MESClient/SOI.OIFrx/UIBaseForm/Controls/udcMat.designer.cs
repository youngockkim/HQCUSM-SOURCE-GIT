namespace SOI.OIFrx
{
    partial class udcMat
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
            this.lblMat = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.cdvMat = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlLeft.SuspendLayout();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMat)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblMat);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(70, 20);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblMat
            // 
            this.lblMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMat.Location = new System.Drawing.Point(0, 0);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(67, 20);
            this.lblMat.TabIndex = 1;
            this.lblMat.Text = "Mat";
            this.lblMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.cdvMat);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(70, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(150, 20);
            this.pnlMid.TabIndex = 1;
            // 
            // cdvMat
            // 
            this.cdvMat.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMat.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMat.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMat.BtnToolTipText = "Get flow list";
            this.cdvMat.ButtonWidth = 20;
            this.cdvMat.DescText = "";
            this.cdvMat.DisplaySubItemIndex = -1;
            this.cdvMat.DisplayText = "";
            this.cdvMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvMat.Focusing = null;
            this.cdvMat.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMat.Index = 0;
            this.cdvMat.IsViewBtnImage = false;
            this.cdvMat.Location = new System.Drawing.Point(0, 0);
            this.cdvMat.MaxLength = 32767;
            this.cdvMat.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMat.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMat.Name = "cdvMat";
            this.cdvMat.ReadOnly = false;
            this.cdvMat.SameWidthHeightOfButton = false;
            this.cdvMat.SearchSubItemIndex = 0;
            this.cdvMat.SelectedDescIndex = -1;
            this.cdvMat.SelectedSubItemIndex = -1;
            this.cdvMat.SelectionStart = 0;
            this.cdvMat.Size = new System.Drawing.Size(150, 20);
            this.cdvMat.SmallImageList = null;
            this.cdvMat.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMat.TabIndex = 1;
            this.cdvMat.TextBoxToolTipText = "";
            this.cdvMat.TextBoxWidth = 150;
            this.cdvMat.VisibleButton = true;
            this.cdvMat.VisibleColumnHeader = false;
            this.cdvMat.VisibleDescription = false;
            this.cdvMat.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMat_SelectedItemChanged);
            this.cdvMat.ButtonPress += new System.EventHandler(this.cdvMat_ButtonPress);
            this.cdvMat.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvMat_TextBoxKeyPress);
            this.cdvMat.TextBoxTextChanged += new System.EventHandler(this.cdvMat_TextBoxTextChanged);
            this.cdvMat.TextBoxLostFocus += new System.EventHandler(this.cdvMat_TextBoxLostFocus);
            this.cdvMat.TextBoxGotFocus += new System.EventHandler(this.cdvMat_TextBoxGotFocus);
            // 
            // udcMat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(0, 50);
            this.MinimumSize = new System.Drawing.Size(100, 20);
            this.Name = "udcMat";
            this.Size = new System.Drawing.Size(220, 20);
            this.FontChanged += new System.EventHandler(this.udcLine_FontChanged);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvMat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMid;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMat;
        private System.Windows.Forms.Label lblMat;
    }
}
