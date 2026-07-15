namespace Miracom.MESCore.Controls
{
    partial class udcMaterial
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
            this.pnlMaterial = new System.Windows.Forms.Panel();
            this.cdvMat = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.cdvVersion = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlLabel = new System.Windows.Forms.Panel();
            this.lblMat = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.pnlLeft.SuspendLayout();
            this.pnlMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMat)).BeginInit();
            this.pnlVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvVersion)).BeginInit();
            this.pnlLabel.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlMaterial);
            this.pnlLeft.Controls.Add(this.pnlVersion);
            this.pnlLeft.Controls.Add(this.pnlLabel);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(210, 20);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlMaterial
            // 
            this.pnlMaterial.Controls.Add(this.cdvMat);
            this.pnlMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMaterial.Location = new System.Drawing.Point(60, 0);
            this.pnlMaterial.Name = "pnlMaterial";
            this.pnlMaterial.Size = new System.Drawing.Size(100, 20);
            this.pnlMaterial.TabIndex = 1;
            // 
            // cdvMat
            // 
            this.cdvMat.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMat.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMat.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMat.BtnToolTipText = "";
            this.cdvMat.DescText = "";
            this.cdvMat.DisplaySubItemIndex = -1;
            this.cdvMat.DisplayText = "";
            this.cdvMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvMat.Focusing = null;
            this.cdvMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMat.Index = 0;
            this.cdvMat.IsViewBtnImage = false;
            this.cdvMat.Location = new System.Drawing.Point(0, 0);
            this.cdvMat.MaxLength = 30;
            this.cdvMat.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMat.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMat.Name = "cdvMat";
            this.cdvMat.ReadOnly = false;
            this.cdvMat.SearchSubItemIndex = 0;
            this.cdvMat.SelectedDescIndex = -1;
            this.cdvMat.SelectedSubItemIndex = -1;
            this.cdvMat.SelectionStart = 0;
            this.cdvMat.Size = new System.Drawing.Size(100, 20);
            this.cdvMat.SmallImageList = null;
            this.cdvMat.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMat.TabIndex = 0;
            this.cdvMat.TextBoxToolTipText = "";
            this.cdvMat.TextBoxWidth = 100;
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
            // pnlVersion
            // 
            this.pnlVersion.Controls.Add(this.cdvVersion);
            this.pnlVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlVersion.Location = new System.Drawing.Point(160, 0);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.pnlVersion.Size = new System.Drawing.Size(50, 20);
            this.pnlVersion.TabIndex = 2;
            // 
            // cdvVersion
            // 
            this.cdvVersion.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvVersion.BorderHotColor = System.Drawing.Color.Black;
            this.cdvVersion.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvVersion.BtnToolTipText = "";
            this.cdvVersion.DescText = "";
            this.cdvVersion.DisplaySubItemIndex = -1;
            this.cdvVersion.DisplayText = "";
            this.cdvVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvVersion.Focusing = null;
            this.cdvVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvVersion.Index = 0;
            this.cdvVersion.IsViewBtnImage = false;
            this.cdvVersion.Location = new System.Drawing.Point(2, 0);
            this.cdvVersion.MaxLength = 6;
            this.cdvVersion.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvVersion.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvVersion.Name = "cdvVersion";
            this.cdvVersion.ReadOnly = false;
            this.cdvVersion.SearchSubItemIndex = 0;
            this.cdvVersion.SelectedDescIndex = -1;
            this.cdvVersion.SelectedSubItemIndex = -1;
            this.cdvVersion.SelectionStart = 0;
            this.cdvVersion.Size = new System.Drawing.Size(48, 20);
            this.cdvVersion.SmallImageList = null;
            this.cdvVersion.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvVersion.TabIndex = 0;
            this.cdvVersion.TextBoxToolTipText = "";
            this.cdvVersion.TextBoxWidth = 48;
            this.cdvVersion.VisibleButton = true;
            this.cdvVersion.VisibleColumnHeader = false;
            this.cdvVersion.VisibleDescription = false;
            this.cdvVersion.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvVersion_SelectedItemChanged);
            this.cdvVersion.ButtonPress += new System.EventHandler(this.cdvVersion_ButtonPress);
            this.cdvVersion.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvVersion_TextBoxKeyPress);
            this.cdvVersion.TextBoxTextChanged += new System.EventHandler(this.cdvVersion_TextBoxTextChanged);
            this.cdvVersion.TextBoxLostFocus += new System.EventHandler(this.cdvVersion_TextBoxLostFocus);
            this.cdvVersion.TextBoxGotFocus += new System.EventHandler(this.cdvVersion_TextBoxGotFocus);
            // 
            // pnlLabel
            // 
            this.pnlLabel.Controls.Add(this.lblMat);
            this.pnlLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlLabel.Name = "pnlLabel";
            this.pnlLabel.Size = new System.Drawing.Size(60, 20);
            this.pnlLabel.TabIndex = 0;
            // 
            // lblMat
            // 
            this.lblMat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMat.Location = new System.Drawing.Point(0, 3);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(60, 14);
            this.lblMat.TabIndex = 0;
            this.lblMat.Text = "Material";
            this.lblMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.txtDesc);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(210, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlMid.Size = new System.Drawing.Size(0, 20);
            this.pnlMid.TabIndex = 1;
            // 
            // txtDesc
            // 
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.Location = new System.Drawing.Point(8, 0);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(0, 20);
            this.txtDesc.TabIndex = 0;
            // 
            // udcMaterial
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "udcMaterial";
            this.Size = new System.Drawing.Size(210, 20);
            this.FontChanged += new System.EventHandler(this.udcMaterial_FontChanged);
            this.Resize += new System.EventHandler(this.udcMaterial_Resize);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMaterial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvMat)).EndInit();
            this.pnlVersion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvVersion)).EndInit();
            this.pnlLabel.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.pnlMid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.Panel pnlLabel;
        private System.Windows.Forms.Panel pnlMaterial;
        private System.Windows.Forms.Panel pnlVersion;
        private System.Windows.Forms.Label lblMat;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMat;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvVersion;
        private System.Windows.Forms.TextBox txtDesc;
    }
}
