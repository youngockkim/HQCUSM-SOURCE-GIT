namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionRelease
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
            this.lblHoldPass = new System.Windows.Forms.Label();
            this.txtHoldPass = new System.Windows.Forms.TextBox();
            this.cdvReleaseCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRelCode = new System.Windows.Forms.Label();
            this.cdvHoldCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblHoldCode = new System.Windows.Forms.Label();
            this.chkMultiTrans = new System.Windows.Forms.CheckBox();
            this.grpActionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReleaseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.chkMultiTrans);
            this.grpActionValue.Controls.Add(this.cdvHoldCode);
            this.grpActionValue.Controls.Add(this.lblHoldCode);
            this.grpActionValue.Controls.Add(this.lblHoldPass);
            this.grpActionValue.Controls.Add(this.txtHoldPass);
            this.grpActionValue.Controls.Add(this.cdvReleaseCode);
            this.grpActionValue.Controls.Add(this.lblRelCode);
            // 
            // lblHoldPass
            // 
            this.lblHoldPass.AutoSize = true;
            this.lblHoldPass.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldPass.Location = new System.Drawing.Point(6, 47);
            this.lblHoldPass.Name = "lblHoldPass";
            this.lblHoldPass.Size = new System.Drawing.Size(78, 13);
            this.lblHoldPass.TabIndex = 2;
            this.lblHoldPass.Text = "Hold Password";
            this.lblHoldPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHoldPass
            // 
            this.txtHoldPass.Location = new System.Drawing.Point(92, 43);
            this.txtHoldPass.MaxLength = 20;
            this.txtHoldPass.Name = "txtHoldPass";
            this.txtHoldPass.PasswordChar = '*';
            this.txtHoldPass.Size = new System.Drawing.Size(142, 20);
            this.txtHoldPass.TabIndex = 3;
            // 
            // cdvReleaseCode
            // 
            this.cdvReleaseCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReleaseCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReleaseCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvReleaseCode.BtnToolTipText = "";
            this.cdvReleaseCode.DescText = "";
            this.cdvReleaseCode.DisplaySubItemIndex = -1;
            this.cdvReleaseCode.DisplayText = "";
            this.cdvReleaseCode.Focusing = null;
            this.cdvReleaseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReleaseCode.Index = 0;
            this.cdvReleaseCode.IsViewBtnImage = false;
            this.cdvReleaseCode.Location = new System.Drawing.Point(92, 19);
            this.cdvReleaseCode.MaxLength = 10;
            this.cdvReleaseCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvReleaseCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvReleaseCode.Name = "cdvReleaseCode";
            this.cdvReleaseCode.ReadOnly = true;
            this.cdvReleaseCode.SearchSubItemIndex = 0;
            this.cdvReleaseCode.SelectedDescIndex = -1;
            this.cdvReleaseCode.SelectedSubItemIndex = -1;
            this.cdvReleaseCode.SelectionStart = 0;
            this.cdvReleaseCode.Size = new System.Drawing.Size(142, 20);
            this.cdvReleaseCode.SmallImageList = null;
            this.cdvReleaseCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvReleaseCode.TabIndex = 1;
            this.cdvReleaseCode.TextBoxToolTipText = "";
            this.cdvReleaseCode.TextBoxWidth = 142;
            this.cdvReleaseCode.VisibleButton = true;
            this.cdvReleaseCode.VisibleColumnHeader = false;
            this.cdvReleaseCode.VisibleDescription = false;
            // 
            // lblRelCode
            // 
            this.lblRelCode.AutoSize = true;
            this.lblRelCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelCode.Location = new System.Drawing.Point(6, 23);
            this.lblRelCode.Name = "lblRelCode";
            this.lblRelCode.Size = new System.Drawing.Size(74, 13);
            this.lblRelCode.TabIndex = 0;
            this.lblRelCode.Text = "Release Code";
            this.lblRelCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvHoldCode
            // 
            this.cdvHoldCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvHoldCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvHoldCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvHoldCode.BtnToolTipText = "";
            this.cdvHoldCode.DescText = "";
            this.cdvHoldCode.DisplaySubItemIndex = -1;
            this.cdvHoldCode.DisplayText = "";
            this.cdvHoldCode.Focusing = null;
            this.cdvHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvHoldCode.Index = 0;
            this.cdvHoldCode.IsViewBtnImage = false;
            this.cdvHoldCode.Location = new System.Drawing.Point(92, 67);
            this.cdvHoldCode.MaxLength = 10;
            this.cdvHoldCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.Name = "cdvHoldCode";
            this.cdvHoldCode.ReadOnly = true;
            this.cdvHoldCode.SearchSubItemIndex = 0;
            this.cdvHoldCode.SelectedDescIndex = -1;
            this.cdvHoldCode.SelectedSubItemIndex = -1;
            this.cdvHoldCode.SelectionStart = 0;
            this.cdvHoldCode.Size = new System.Drawing.Size(142, 20);
            this.cdvHoldCode.SmallImageList = null;
            this.cdvHoldCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvHoldCode.TabIndex = 5;
            this.cdvHoldCode.TextBoxToolTipText = "";
            this.cdvHoldCode.TextBoxWidth = 142;
            this.cdvHoldCode.VisibleButton = true;
            this.cdvHoldCode.VisibleColumnHeader = false;
            this.cdvHoldCode.VisibleDescription = false;
            // 
            // lblHoldCode
            // 
            this.lblHoldCode.AutoSize = true;
            this.lblHoldCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldCode.Location = new System.Drawing.Point(6, 71);
            this.lblHoldCode.Name = "lblHoldCode";
            this.lblHoldCode.Size = new System.Drawing.Size(57, 13);
            this.lblHoldCode.TabIndex = 4;
            this.lblHoldCode.Text = "Hold Code";
            this.lblHoldCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkMultiTrans
            // 
            this.chkMultiTrans.AutoSize = true;
            this.chkMultiTrans.Location = new System.Drawing.Point(9, 96);
            this.chkMultiTrans.Name = "chkMultiTrans";
            this.chkMultiTrans.Size = new System.Drawing.Size(146, 17);
            this.chkMultiTrans.TabIndex = 6;
            this.chkMultiTrans.Text = "Perform Multi Transaction";
            this.chkMultiTrans.UseVisualStyleBackColor = true;
            // 
            // udcStepActionRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcStepActionRelease";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReleaseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHoldPass;
        private System.Windows.Forms.TextBox txtHoldPass;
        private UI.Controls.MCCodeView.MCCodeView cdvReleaseCode;
        private System.Windows.Forms.Label lblRelCode;
        private UI.Controls.MCCodeView.MCCodeView cdvHoldCode;
        private System.Windows.Forms.Label lblHoldCode;
        private System.Windows.Forms.CheckBox chkMultiTrans;
    }
}
