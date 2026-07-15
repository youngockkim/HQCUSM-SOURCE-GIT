namespace SOI.Samples.SampleControls
{
    partial class frmSampleFlexibleScreen
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.soiGroupBox7 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiFlexibleScreen1 = new SOI.OIFrx.SOIControls.SOIFlexibleScreen();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox7)).BeginInit();
            this.soiGroupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // soiGroupBox7
            // 
            this.soiGroupBox7._UseOITheme = false;
            this.soiGroupBox7._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance4.BackColor = System.Drawing.Color.Black;
            appearance4.BackColor2 = System.Drawing.Color.Black;
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance4.BorderColor2 = System.Drawing.Color.Black;
            appearance4.BorderColor3DBase = System.Drawing.Color.Black;
            this.soiGroupBox7.Appearance = appearance4;
            this.soiGroupBox7.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.White;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.BorderColor2 = System.Drawing.Color.Black;
            this.soiGroupBox7.ContentAreaAppearance = appearance5;
            this.soiGroupBox7.Controls.Add(this.soiFlexibleScreen1);
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            appearance6.BorderColor = System.Drawing.Color.Black;
            appearance6.BorderColor2 = System.Drawing.Color.Black;
            appearance6.FontData.BoldAsString = "True";
            appearance6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox7.HeaderAppearance = appearance6;
            this.soiGroupBox7.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor;
            this.soiGroupBox7.Location = new System.Drawing.Point(14, 14);
            this.soiGroupBox7.Margin = new System.Windows.Forms.Padding(5);
            this.soiGroupBox7.Name = "soiGroupBox7";
            this.soiGroupBox7.Size = new System.Drawing.Size(416, 257);
            this.soiGroupBox7.TabIndex = 7;
            this.soiGroupBox7.Text = "Default Spread";
            this.soiGroupBox7.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // soiFlexibleScreen1
            // 
            this.soiFlexibleScreen1._ListCellCopy = true;
            this.soiFlexibleScreen1._UseOITheme = true;
            this.soiFlexibleScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiFlexibleScreen1.Location = new System.Drawing.Point(2, 28);
            this.soiFlexibleScreen1.Margin = new System.Windows.Forms.Padding(0);
            this.soiFlexibleScreen1.Name = "soiFlexibleScreen1";
            this.soiFlexibleScreen1.OwnerFuncName = null;
            this.soiFlexibleScreen1.ScreenAutoStretch = false;
            this.soiFlexibleScreen1.ScreenID = null;
            this.soiFlexibleScreen1.ScreenLock = false;
            this.soiFlexibleScreen1.ScreenLockBackColor = System.Drawing.Color.Empty;
            this.soiFlexibleScreen1.Size = new System.Drawing.Size(412, 227);
            this.soiFlexibleScreen1.TabIndex = 0;
            // 
            // frmSampleFlexibleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.soiGroupBox7);
            this.Name = "frmSampleFlexibleScreen";
            this.Text = "frmSampleFlexibleScreen";
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox7)).EndInit();
            this.soiGroupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OIFrx.SOIControls.SOIGroupBox soiGroupBox7;
        private OIFrx.SOIControls.SOIFlexibleScreen soiFlexibleScreen1;
    }
}