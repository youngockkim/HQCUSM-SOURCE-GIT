namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpActionValue = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpActionValue.Location = new System.Drawing.Point(0, 0);
            this.grpActionValue.Name = "grpActionValue";
            this.grpActionValue.Size = new System.Drawing.Size(530, 330);
            this.grpActionValue.TabIndex = 0;
            this.grpActionValue.TabStop = false;
            this.grpActionValue.Text = "Action Value";
            // 
            // udcFutureActionBase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grpActionValue);
            this.Name = "udcFutureActionBase";
            this.Size = new System.Drawing.Size(530, 330);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox grpActionValue;

    }
}
