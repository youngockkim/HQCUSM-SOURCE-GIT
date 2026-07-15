namespace BOI.WIPCus
{
    partial class frmTigate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTigate));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.txtValue = new SOI.OIFrx.SOIControls.SOITextBox(this.components);
            this.pnlTopMargin.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomMargin.SuspendLayout();
            this.pnlMiddleMargin.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottomClosePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            this.SuspendLayout();
            // 
            // pbHelp
            // 
            this.pbHelp.Image = ((object)(resources.GetObject("pbHelp.Image")));
            // 
            // pbStdOper
            // 
            this.pbStdOper.Image = ((object)(resources.GetObject("pbStdOper.Image")));
            // 
            // pnlMiddleMargin
            // 
            this.pnlMiddleMargin.Controls.Add(this.txtValue);
            // 
            // txtValue
            // 
            this.txtValue._UseOITheme = true;
            this.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance5.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance5.FontData.BoldAsString = "True";
            appearance5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance5.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtValue.Appearance = appearance5;
            this.txtValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtValue.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValue.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtValue.Location = new System.Drawing.Point(15, 23);
            this.txtValue.Margin = new System.Windows.Forms.Padding(0);
            this.txtValue.MaxLength = 100;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(258, 36);
            this.txtValue.TabIndex = 12;
            this.txtValue.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtValue.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtValue.UseSOIContextMenu = true;
            // 
            // frmTigate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 647);
            this.Name = "frmTigate";
            this.Text = "frmTigate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTigate_FormClosing);
            this.Load += new System.EventHandler(this.frmTempBOIBaseForm02_Load);
            this.Shown += new System.EventHandler(this.frmTempBOIBaseForm02_Shown);
            this.pnlTopMargin.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomMargin.ResumeLayout(false);
            this.pnlMiddleMargin.ResumeLayout(false);
            this.pnlMiddleMargin.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.pnlBottomClosePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOITextBox txtValue;
    }
}