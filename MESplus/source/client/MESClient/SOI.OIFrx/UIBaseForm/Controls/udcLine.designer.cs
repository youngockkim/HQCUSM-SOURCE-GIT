namespace SOI.OIFrx
{
    partial class udcLine
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
            this.lblLine = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.cdvLine = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlLeft.SuspendLayout();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLine)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblLine);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(70, 20);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblLine
            // 
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLine.Location = new System.Drawing.Point(0, 0);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(67, 20);
            this.lblLine.TabIndex = 1;
            this.lblLine.Text = "Line";
            this.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.cdvLine);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(70, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(150, 20);
            this.pnlMid.TabIndex = 1;
            // 
            // cdvLine
            // 
            this.cdvLine.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLine.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLine.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLine.BtnToolTipText = "Get flow list";
            this.cdvLine.ButtonWidth = 20;
            this.cdvLine.DescText = "";
            this.cdvLine.DisplaySubItemIndex = -1;
            this.cdvLine.DisplayText = "";
            this.cdvLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvLine.Focusing = null;
            this.cdvLine.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLine.Index = 0;
            this.cdvLine.IsViewBtnImage = false;
            this.cdvLine.Location = new System.Drawing.Point(0, 0);
            this.cdvLine.MaxLength = 32767;
            this.cdvLine.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLine.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLine.Name = "cdvLine";
            this.cdvLine.ReadOnly = false;
            this.cdvLine.SameWidthHeightOfButton = false;
            this.cdvLine.SearchSubItemIndex = 0;
            this.cdvLine.SelectedDescIndex = -1;
            this.cdvLine.SelectedSubItemIndex = -1;
            this.cdvLine.SelectionStart = 0;
            this.cdvLine.Size = new System.Drawing.Size(150, 20);
            this.cdvLine.SmallImageList = null;
            this.cdvLine.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLine.TabIndex = 1;
            this.cdvLine.TextBoxToolTipText = "";
            this.cdvLine.TextBoxWidth = 150;
            this.cdvLine.VisibleButton = true;
            this.cdvLine.VisibleColumnHeader = false;
            this.cdvLine.VisibleDescription = false;
            this.cdvLine.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvLine_SelectedItemChanged);
            this.cdvLine.ButtonPress += new System.EventHandler(this.cdvLine_ButtonPress);
            this.cdvLine.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvLine_TextBoxKeyPress);
            this.cdvLine.TextBoxTextChanged += new System.EventHandler(this.cdvLine_TextBoxTextChanged);
            this.cdvLine.TextBoxLostFocus += new System.EventHandler(this.cdvLine_TextBoxLostFocus);
            this.cdvLine.TextBoxGotFocus += new System.EventHandler(this.cdvLine_TextBoxGotFocus);
            // 
            // udcLine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(0, 50);
            this.MinimumSize = new System.Drawing.Size(100, 20);
            this.Name = "udcLine";
            this.Size = new System.Drawing.Size(220, 20);
            this.FontChanged += new System.EventHandler(this.udcLine_FontChanged);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMid;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLine;
        private System.Windows.Forms.Label lblLine;
    }
}
