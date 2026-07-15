namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionTerminate
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
            this.cdvTermCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTermCode = new System.Windows.Forms.Label();
            this.chkMultiTrans = new System.Windows.Forms.CheckBox();
            this.grpActionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTermCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.chkMultiTrans);
            this.grpActionValue.Controls.Add(this.cdvTermCode);
            this.grpActionValue.Controls.Add(this.lblTermCode);
            // 
            // cdvTermCode
            // 
            this.cdvTermCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTermCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTermCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTermCode.BtnToolTipText = "";
            this.cdvTermCode.DescText = "";
            this.cdvTermCode.DisplaySubItemIndex = -1;
            this.cdvTermCode.DisplayText = "";
            this.cdvTermCode.Focusing = null;
            this.cdvTermCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTermCode.Index = 0;
            this.cdvTermCode.IsViewBtnImage = false;
            this.cdvTermCode.Location = new System.Drawing.Point(92, 20);
            this.cdvTermCode.MaxLength = 10;
            this.cdvTermCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTermCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTermCode.Name = "cdvTermCode";
            this.cdvTermCode.ReadOnly = true;
            this.cdvTermCode.SearchSubItemIndex = 0;
            this.cdvTermCode.SelectedDescIndex = -1;
            this.cdvTermCode.SelectedSubItemIndex = -1;
            this.cdvTermCode.SelectionStart = 0;
            this.cdvTermCode.Size = new System.Drawing.Size(142, 20);
            this.cdvTermCode.SmallImageList = null;
            this.cdvTermCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTermCode.TabIndex = 1;
            this.cdvTermCode.TextBoxToolTipText = "";
            this.cdvTermCode.TextBoxWidth = 142;
            this.cdvTermCode.VisibleButton = true;
            this.cdvTermCode.VisibleColumnHeader = false;
            this.cdvTermCode.VisibleDescription = false;
            // 
            // lblTermCode
            // 
            this.lblTermCode.AutoSize = true;
            this.lblTermCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTermCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermCode.Location = new System.Drawing.Point(6, 24);
            this.lblTermCode.Name = "lblTermCode";
            this.lblTermCode.Size = new System.Drawing.Size(82, 13);
            this.lblTermCode.TabIndex = 0;
            this.lblTermCode.Text = "Terminate Code";
            this.lblTermCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkMultiTrans
            // 
            this.chkMultiTrans.AutoSize = true;
            this.chkMultiTrans.Location = new System.Drawing.Point(9, 49);
            this.chkMultiTrans.Name = "chkMultiTrans";
            this.chkMultiTrans.Size = new System.Drawing.Size(146, 17);
            this.chkMultiTrans.TabIndex = 2;
            this.chkMultiTrans.Text = "Perform Multi Transaction";
            this.chkMultiTrans.UseVisualStyleBackColor = true;
            // 
            // udcStepActionTerminate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcStepActionTerminate";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTermCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.MCCodeView.MCCodeView cdvTermCode;
        private System.Windows.Forms.Label lblTermCode;
        private System.Windows.Forms.CheckBox chkMultiTrans;
    }
}
