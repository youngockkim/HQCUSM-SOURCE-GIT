namespace Miracom.MESCore.Controls
{
    partial class udcStep
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
            this.lblStep = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.cdvStep = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlLeft.SuspendLayout();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvStep)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblStep);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(68, 20);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblStep
            // 
            this.lblStep.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStep.Location = new System.Drawing.Point(0, 3);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(60, 14);
            this.lblStep.TabIndex = 0;
            this.lblStep.Text = "Step";
            this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.cdvStep);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(68, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(105, 20);
            this.pnlMid.TabIndex = 1;
            // 
            // cdvStep
            // 
            this.cdvStep.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvStep.BorderHotColor = System.Drawing.Color.Black;
            this.cdvStep.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvStep.BtnToolTipText = "Get flow list";
            this.cdvStep.DescText = "";
            this.cdvStep.DisplaySubItemIndex = -1;
            this.cdvStep.DisplayText = "";
            this.cdvStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvStep.Focusing = null;
            this.cdvStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvStep.Index = 0;
            this.cdvStep.IsViewBtnImage = false;
            this.cdvStep.Location = new System.Drawing.Point(0, 0);
            this.cdvStep.MaxLength = 20;
            this.cdvStep.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvStep.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvStep.Name = "cdvStep";
            this.cdvStep.ReadOnly = false;
            this.cdvStep.SearchSubItemIndex = 0;
            this.cdvStep.SelectedDescIndex = -1;
            this.cdvStep.SelectedSubItemIndex = -1;
            this.cdvStep.SelectionStart = 0;
            this.cdvStep.Size = new System.Drawing.Size(105, 20);
            this.cdvStep.SmallImageList = null;
            this.cdvStep.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvStep.TabIndex = 0;
            this.cdvStep.TextBoxToolTipText = "";
            this.cdvStep.TextBoxWidth = 105;
            this.cdvStep.VisibleButton = true;
            this.cdvStep.VisibleColumnHeader = false;
            this.cdvStep.VisibleDescription = false;
            this.cdvStep.TextBoxTextChanged += new System.EventHandler(this.cdvStep_TextBoxTextChanged);
            this.cdvStep.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvStep_TextBoxKeyPress);
            this.cdvStep.ButtonPress += new System.EventHandler(this.cdvStep_ButtonPress);
            this.cdvStep.TextBoxLostFocus += new System.EventHandler(this.cdvStep_TextBoxLostFocus);
            this.cdvStep.TextBoxGotFocus += new System.EventHandler(this.cdvStep_TextBoxGotFocus);
            this.cdvStep.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvStep_SelectedItemChanged);
            // 
            // udcStep
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "udcStep";
            this.Size = new System.Drawing.Size(173, 20);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.Label lblStep;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvStep;
    }
}
