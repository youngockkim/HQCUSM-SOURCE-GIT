namespace SOI.HanwhaQcell.USModule
{
    partial class frmCWIPFullCellImagePopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.soiTableLayoutPanel1 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.soiPictureBox1 = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            this.soiTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Size = new System.Drawing.Size(1576, 38);
            this.lblPopupTitle.Text = "MODULE IMAGE";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlPopupTop.Size = new System.Drawing.Size(1596, 48);
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(2, 848);
            this.pnlPopupBottom.Size = new System.Drawing.Size(1596, 50);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1476, 0);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupMiddle.Size = new System.Drawing.Size(1596, 794);
            // 
            // pnlPopupTopMargin
            // 
            this.pnlPopupTopMargin.Size = new System.Drawing.Size(1576, 38);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(1576, 40);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.soiTableLayoutPanel1);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(1576, 784);
            // 
            // soiTableLayoutPanel1
            // 
            this.soiTableLayoutPanel1._UseOITheme = true;
            this.soiTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel1.ColumnCount = 1;
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.Controls.Add(this.soiPictureBox1, 0, 0);
            this.soiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel1.Name = "soiTableLayoutPanel1";
            this.soiTableLayoutPanel1.RowCount = 1;
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 484F));
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 484F));
            this.soiTableLayoutPanel1.Size = new System.Drawing.Size(1576, 784);
            this.soiTableLayoutPanel1.TabIndex = 2;
            // 
            // soiPictureBox1
            // 
            this.soiPictureBox1._UseLotStatusStyle = SOI.OIFrx.SOIPictureBoxStyle.None;
            this.soiPictureBox1._UseOITheme = true;
            this.soiPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.soiPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.soiPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.soiPictureBox1.LotStatus = false;
            this.soiPictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.soiPictureBox1.Name = "soiPictureBox1";
            this.soiPictureBox1.ScaleImage = Infragistics.Win.ScaleImage.Always;
            this.soiPictureBox1.Size = new System.Drawing.Size(1576, 784);
            this.soiPictureBox1.TabIndex = 0;
            this.soiPictureBox1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiPictureBox1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // frmCWIPFullCellImagePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Name = "frmCWIPFullCellImagePopup";
            this.Text = "frmCWIPFullCellImagePopup";
            this.Load += new System.EventHandler(this.frmCWIPFullCellImagePopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            this.soiTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel1;
        private OIFrx.SOIControls.SOIPictureBox soiPictureBox1;
    }
}