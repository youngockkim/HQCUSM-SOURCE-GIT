namespace SOI.OIFrx.SOIControls
{
    partial class SOICheckBoxOnOff
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.pnlOutBorder = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlOff = new System.Windows.Forms.Panel();
            this.btnOff = new Infragistics.Win.Misc.UltraButton();
            this.lblOffText = new Infragistics.Win.Misc.UltraLabel();
            this.pnlOn = new System.Windows.Forms.Panel();
            this.btnOn = new Infragistics.Win.Misc.UltraButton();
            this.lblOnText = new Infragistics.Win.Misc.UltraLabel();
            this.pnlOutBorder.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlOff.SuspendLayout();
            this.pnlOn.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOutBorder
            // 
            this.pnlOutBorder.Controls.Add(this.tableLayoutPanel1);
            this.pnlOutBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOutBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlOutBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOutBorder.Name = "pnlOutBorder";
            this.pnlOutBorder.Size = new System.Drawing.Size(150, 40);
            this.pnlOutBorder.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlOff, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlOn, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(148, 38);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlOff
            // 
            this.pnlOff.Controls.Add(this.btnOff);
            this.pnlOff.Controls.Add(this.lblOffText);
            this.pnlOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOff.Location = new System.Drawing.Point(74, 0);
            this.pnlOff.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOff.Name = "pnlOff";
            this.pnlOff.Size = new System.Drawing.Size(74, 38);
            this.pnlOff.TabIndex = 1;
            // 
            // btnOff
            // 
            this.btnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOff.Location = new System.Drawing.Point(0, 0);
            this.btnOff.Name = "btnOff";
            this.btnOff.ShowFocusRect = false;
            this.btnOff.ShowOutline = false;
            this.btnOff.Size = new System.Drawing.Size(74, 38);
            this.btnOff.TabIndex = 2;
            this.btnOff.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnOff.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // lblOffText
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblOffText.Appearance = appearance2;
            this.lblOffText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOffText.Location = new System.Drawing.Point(0, 0);
            this.lblOffText.Name = "lblOffText";
            this.lblOffText.Size = new System.Drawing.Size(74, 38);
            this.lblOffText.TabIndex = 1;
            this.lblOffText.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblOffText.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.lblOffText.Visible = false;
            this.lblOffText.Click += new System.EventHandler(this.lblOffText_Click);
            // 
            // pnlOn
            // 
            this.pnlOn.Controls.Add(this.btnOn);
            this.pnlOn.Controls.Add(this.lblOnText);
            this.pnlOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOn.Location = new System.Drawing.Point(0, 0);
            this.pnlOn.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOn.Name = "pnlOn";
            this.pnlOn.Size = new System.Drawing.Size(74, 38);
            this.pnlOn.TabIndex = 2;
            // 
            // btnOn
            // 
            this.btnOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOn.Location = new System.Drawing.Point(0, 0);
            this.btnOn.Name = "btnOn";
            this.btnOn.ShowFocusRect = false;
            this.btnOn.ShowOutline = false;
            this.btnOn.Size = new System.Drawing.Size(74, 38);
            this.btnOn.TabIndex = 1;
            this.btnOn.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnOn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnOn.Visible = false;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // lblOnText
            // 
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblOnText.Appearance = appearance3;
            this.lblOnText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOnText.Location = new System.Drawing.Point(0, 0);
            this.lblOnText.Name = "lblOnText";
            this.lblOnText.Size = new System.Drawing.Size(74, 38);
            this.lblOnText.TabIndex = 0;
            this.lblOnText.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblOnText.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.lblOnText.Click += new System.EventHandler(this.lblOnText_Click);
            // 
            // SOICheckBoxOnOff
            // 
            this.Controls.Add(this.pnlOutBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SOICheckBoxOnOff";
            this.Size = new System.Drawing.Size(150, 40);
            this.pnlOutBorder.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlOff.ResumeLayout(false);
            this.pnlOn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOutBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infragistics.Win.Misc.UltraLabel lblOnText;
        private Infragistics.Win.Misc.UltraLabel lblOffText;
        private System.Windows.Forms.Panel pnlOff;
        private System.Windows.Forms.Panel pnlOn;
        private Infragistics.Win.Misc.UltraButton btnOff;
        private Infragistics.Win.Misc.UltraButton btnOn;
    }
}
