namespace SOI.OIFrx
{
    partial class UIBaseForm11
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 40);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 123);
            this.panel2.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTop.Controls.Add(this.lblFormTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(1184, 0);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.Visible = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFormTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFormTitle.Location = new System.Drawing.Point(2, 2);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(1180, 0);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Form Title";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1184, 383);
            this.panel3.TabIndex = 2;
            // 
            // UIBaseForm11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 546);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.panel1);
            this.Name = "UIBaseForm11";
            this.Text = "UIBaseForm11";
            this.Activated += new System.EventHandler(this.UIBaseForm11_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIBaseForm11_Closed);
            this.Load += new System.EventHandler(this.UIBaseForm11_Load);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Panel pnlTop;
        protected System.Windows.Forms.Label lblFormTitle;
    }
}