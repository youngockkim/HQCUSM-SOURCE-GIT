namespace Miracom.SPCClient
{
    partial class frmSPCOption
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
            this.grpStyle = new System.Windows.Forms.GroupBox();
            this.rbn3D = new System.Windows.Forms.RadioButton();
            this.rbnFlat = new System.Windows.Forms.RadioButton();
            this.pnlBottom.SuspendLayout();
            this.grpSystem.SuspendLayout();
            this.pnlMainLeft.SuspendLayout();
            this.grpAutoRefresh.SuspendLayout();
            this.grpUseGrid.SuspendLayout();
            this.pnlMainRight.SuspendLayout();
            this.grpListRefresh.SuspendLayout();
            this.grpStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMainLeft
            // 
            this.pnlMainLeft.Controls.Add(this.grpStyle);
            this.pnlMainLeft.Controls.SetChildIndex(this.grpUseGrid, 0);
            this.pnlMainLeft.Controls.SetChildIndex(this.grpAutoRefresh, 0);
            this.pnlMainLeft.Controls.SetChildIndex(this.grpStyle, 0);
            // 
            // grpStyle
            // 
            this.grpStyle.Controls.Add(this.rbn3D);
            this.grpStyle.Controls.Add(this.rbnFlat);
            this.grpStyle.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStyle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpStyle.Location = new System.Drawing.Point(0, 130);
            this.grpStyle.Name = "grpStyle";
            this.grpStyle.Size = new System.Drawing.Size(252, 56);
            this.grpStyle.TabIndex = 2;
            this.grpStyle.TabStop = false;
            this.grpStyle.Text = "Style";
            // 
            // rbn3D
            // 
            this.rbn3D.Location = new System.Drawing.Point(144, 19);
            this.rbn3D.Name = "rbn3D";
            this.rbn3D.Size = new System.Drawing.Size(76, 17);
            this.rbn3D.TabIndex = 1;
            this.rbn3D.Text = "3D";
            // 
            // rbnFlat
            // 
            this.rbnFlat.Location = new System.Drawing.Point(32, 19);
            this.rbnFlat.Name = "rbnFlat";
            this.rbnFlat.Size = new System.Drawing.Size(76, 17);
            this.rbnFlat.TabIndex = 0;
            this.rbnFlat.Text = "Flat";
            // 
            // frmSPCOption
            // 
            this.ClientSize = new System.Drawing.Size(514, 318);
            this.Name = "frmSPCOption";
            this.Activated += new System.EventHandler(this.frmSPCOption_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.grpSystem.ResumeLayout(false);
            this.grpSystem.PerformLayout();
            this.pnlMainLeft.ResumeLayout(false);
            this.grpAutoRefresh.ResumeLayout(false);
            this.grpAutoRefresh.PerformLayout();
            this.grpUseGrid.ResumeLayout(false);
            this.pnlMainRight.ResumeLayout(false);
            this.grpListRefresh.ResumeLayout(false);
            this.grpStyle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpStyle;
        internal System.Windows.Forms.RadioButton rbn3D;
        internal System.Windows.Forms.RadioButton rbnFlat;
    }
}
