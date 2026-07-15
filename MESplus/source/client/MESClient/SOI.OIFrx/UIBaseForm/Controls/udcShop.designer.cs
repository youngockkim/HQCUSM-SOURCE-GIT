namespace SOI.OIFrx
{
    partial class udcShop
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
            this.lblShop = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.cdvShop = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlLeft.SuspendLayout();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShop)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblShop);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(70, 20);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblShop
            // 
            this.lblShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShop.Location = new System.Drawing.Point(0, 0);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(67, 20);
            this.lblShop.TabIndex = 1;
            this.lblShop.Text = "Shop";
            this.lblShop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.cdvShop);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(70, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(150, 20);
            this.pnlMid.TabIndex = 1;
            // 
            // cdvShop
            // 
            this.cdvShop.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShop.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShop.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShop.BtnToolTipText = "Get flow list";
            this.cdvShop.ButtonWidth = 20;
            this.cdvShop.DescText = "";
            this.cdvShop.DisplaySubItemIndex = -1;
            this.cdvShop.DisplayText = "";
            this.cdvShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvShop.Focusing = null;
            this.cdvShop.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.cdvShop.Index = 0;
            this.cdvShop.IsViewBtnImage = false;
            this.cdvShop.Location = new System.Drawing.Point(0, 0);
            this.cdvShop.MaxLength = 32767;
            this.cdvShop.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShop.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShop.Name = "cdvShop";
            this.cdvShop.ReadOnly = false;
            this.cdvShop.SameWidthHeightOfButton = false;
            this.cdvShop.SearchSubItemIndex = 0;
            this.cdvShop.SelectedDescIndex = -1;
            this.cdvShop.SelectedSubItemIndex = -1;
            this.cdvShop.SelectionStart = 0;
            this.cdvShop.Size = new System.Drawing.Size(150, 20);
            this.cdvShop.SmallImageList = null;
            this.cdvShop.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShop.TabIndex = 0;
            this.cdvShop.TextBoxToolTipText = "";
            this.cdvShop.TextBoxWidth = 150;
            this.cdvShop.VisibleButton = true;
            this.cdvShop.VisibleColumnHeader = false;
            this.cdvShop.VisibleDescription = false;
            this.cdvShop.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvShop_SelectedItemChanged);
            this.cdvShop.ButtonPress += new System.EventHandler(this.cdvShop_ButtonPress);
            this.cdvShop.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvShop_TextBoxKeyPress);
            this.cdvShop.TextBoxTextChanged += new System.EventHandler(this.cdvShop_TextBoxTextChanged);
            this.cdvShop.TextBoxLostFocus += new System.EventHandler(this.cdvShop_TextBoxLostFocus);
            this.cdvShop.TextBoxGotFocus += new System.EventHandler(this.cdvShop_TextBoxGotFocus);
            // 
            // udcShop
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(0, 50);
            this.MinimumSize = new System.Drawing.Size(100, 20);
            this.Name = "udcShop";
            this.Size = new System.Drawing.Size(220, 20);
            this.FontChanged += new System.EventHandler(this.udcShop_FontChanged);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvShop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMid;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvShop;
        private System.Windows.Forms.Label lblShop;
    }
}
