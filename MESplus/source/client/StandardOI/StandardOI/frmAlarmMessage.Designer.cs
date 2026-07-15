namespace StandardOI
{
    partial class frmAlarmMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlarmMessage));
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.tmrAlarm = new System.Windows.Forms.Timer(this.components);
            this.pnlMessage = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.lblMessage = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.lblTitle = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.pnlMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(251, 5);
            this.pbClose.Margin = new System.Windows.Forms.Padding(0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(25, 25);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 1;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // tmrAlarm
            // 
            this.tmrAlarm.Interval = 1000;
            this.tmrAlarm.Tick += new System.EventHandler(this.tmrClose_Tick);
            // 
            // pnlMessage
            // 
            this.pnlMessage._UseOITheme = false;
            this.pnlMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMessage.BackColor = System.Drawing.Color.White;
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Location = new System.Drawing.Point(4, 35);
            this.pnlMessage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(272, 81);
            this.pnlMessage.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage._UseConvertLanguage = true;
            this.lblMessage._UseOITheme = false;
            this.lblMessage._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance27.BackColor = System.Drawing.Color.Transparent;
            appearance27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance27.TextHAlignAsString = "Left";
            appearance27.TextVAlignAsString = "Middle";
            this.lblMessage.Appearance = appearance27;
            this.lblMessage.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMessage.Location = new System.Drawing.Point(36, 4);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(232, 73);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblMessage.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblTitle
            // 
            this.lblTitle._UseConvertLanguage = true;
            this.lblTitle._UseOITheme = false;
            this.lblTitle._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lblTitle.Appearance = appearance1;
            this.lblTitle.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(9, 5);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(216, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblTitle.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // frmAlarmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(280, 120);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMessage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbClose);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAlarmMessage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmAlarmMessage";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAlarmMessage_FormClosed);
            this.Load += new System.EventHandler(this.frmAlarmMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbClose;
        private SOI.OIFrx.SOIControls.SOILabel lblTitle;
        private SOI.OIFrx.SOIControls.SOIPanel pnlMessage;
        private SOI.OIFrx.SOIControls.SOILabel lblMessage;
        private System.Windows.Forms.Timer tmrAlarm;

    }
}