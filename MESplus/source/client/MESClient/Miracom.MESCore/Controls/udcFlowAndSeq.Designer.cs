namespace Miracom.MESCore.Controls
{
    partial class udcFlowAndSeq
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
            this.lblFlow = new System.Windows.Forms.Label();
            this.pnlLabel = new System.Windows.Forms.Panel();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.cdvSeq = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlFlow = new System.Windows.Forms.Panel();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSeq = new System.Windows.Forms.Panel();
            this.pnlLabel.SuspendLayout();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSeq)).BeginInit();
            this.pnlFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlSeq.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFlow
            // 
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Location = new System.Drawing.Point(0, 3);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(60, 14);
            this.lblFlow.TabIndex = 0;
            this.lblFlow.Text = "Flow";
            this.lblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLabel
            // 
            this.pnlLabel.Controls.Add(this.lblFlow);
            this.pnlLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlLabel.Name = "pnlLabel";
            this.pnlLabel.Size = new System.Drawing.Size(60, 20);
            this.pnlLabel.TabIndex = 0;
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
            // cdvSeq
            // 
            this.cdvSeq.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSeq.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSeq.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSeq.BtnToolTipText = "";
            this.cdvSeq.DescText = "";
            this.cdvSeq.DisplaySubItemIndex = -1;
            this.cdvSeq.DisplayText = "";
            this.cdvSeq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvSeq.Focusing = null;
            this.cdvSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSeq.Index = 0;
            this.cdvSeq.IsViewBtnImage = false;
            this.cdvSeq.Location = new System.Drawing.Point(2, 0);
            this.cdvSeq.MaxLength = 6;
            this.cdvSeq.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSeq.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSeq.Name = "cdvSeq";
            this.cdvSeq.ReadOnly = false;
            this.cdvSeq.SearchSubItemIndex = 0;
            this.cdvSeq.SelectedDescIndex = -1;
            this.cdvSeq.SelectedSubItemIndex = -1;
            this.cdvSeq.SelectionStart = 0;
            this.cdvSeq.Size = new System.Drawing.Size(48, 20);
            this.cdvSeq.SmallImageList = null;
            this.cdvSeq.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSeq.TabIndex = 0;
            this.cdvSeq.TextBoxToolTipText = "";
            this.cdvSeq.TextBoxWidth = 48;
            this.cdvSeq.VisibleButton = true;
            this.cdvSeq.VisibleColumnHeader = false;
            this.cdvSeq.VisibleDescription = false;
            this.cdvSeq.TextBoxTextChanged += new System.EventHandler(this.cdvSeq_TextBoxTextChanged);
            this.cdvSeq.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvSeq_TextBoxKeyPress);
            this.cdvSeq.ButtonPress += new System.EventHandler(this.cdvSeq_ButtonPress);
            this.cdvSeq.TextBoxLostFocus += new System.EventHandler(this.cdvSeq_TextBoxLostFocus);
            this.cdvSeq.TextBoxGotFocus += new System.EventHandler(this.cdvSeq_TextBoxGotFocus);
            this.cdvSeq.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSeq_SelectedItemChanged);
            // 
            // pnlFlow
            // 
            this.pnlFlow.Controls.Add(this.cdvFlow);
            this.pnlFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFlow.Location = new System.Drawing.Point(60, 0);
            this.pnlFlow.Name = "pnlFlow";
            this.pnlFlow.Size = new System.Drawing.Size(100, 20);
            this.pnlFlow.TabIndex = 1;
            // 
            // cdvFlow
            // 
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = -1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(0, 0);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(100, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 0;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 100;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.TextBoxTextChanged += new System.EventHandler(this.cdvFlow_TextBoxTextChanged);
            this.cdvFlow.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvFlow_TextBoxKeyPress);
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            this.cdvFlow.TextBoxLostFocus += new System.EventHandler(this.cdvFlow_TextBoxLostFocus);
            this.cdvFlow.TextBoxGotFocus += new System.EventHandler(this.cdvFlow_TextBoxGotFocus);
            this.cdvFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlFlow);
            this.pnlLeft.Controls.Add(this.pnlSeq);
            this.pnlLeft.Controls.Add(this.pnlLabel);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(210, 20);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlSeq
            // 
            this.pnlSeq.Controls.Add(this.cdvSeq);
            this.pnlSeq.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeq.Location = new System.Drawing.Point(160, 0);
            this.pnlSeq.Name = "pnlSeq";
            this.pnlSeq.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.pnlSeq.Size = new System.Drawing.Size(50, 20);
            this.pnlSeq.TabIndex = 2;
            // 
            // udcFlowAndSeq
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "udcFlowAndSeq";
            this.Size = new System.Drawing.Size(210, 20);
            this.FontChanged += new System.EventHandler(this.ucFlowAndSeq_FontChanged);
            this.Resize += new System.EventHandler(this.ucFlowAndSeq_Resize);
            this.pnlLabel.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.pnlMid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSeq)).EndInit();
            this.pnlFlow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlSeq.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.Panel pnlLabel;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Panel pnlMid;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSeq;
        private System.Windows.Forms.Panel pnlFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlSeq;
    }
}
