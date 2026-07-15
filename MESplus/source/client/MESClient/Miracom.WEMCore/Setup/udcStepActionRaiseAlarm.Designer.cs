namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionRaiseAlarm
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.cdvAlarmID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAlarmID = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmID)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.lblMessage);
            this.grpActionValue.Controls.Add(this.txtMessage);
            this.grpActionValue.Controls.Add(this.lblSubject);
            this.grpActionValue.Controls.Add(this.txtSubject);
            this.grpActionValue.Controls.Add(this.cdvAlarmID);
            this.grpActionValue.Controls.Add(this.lblAlarmID);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(8, 112);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(75, 108);
            this.txtMessage.MaxLength = 50;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(159, 203);
            this.txtMessage.TabIndex = 11;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(8, 42);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 8;
            this.lblSubject.Text = "Subject";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(75, 38);
            this.txtSubject.MaxLength = 50;
            this.txtSubject.Multiline = true;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(159, 66);
            this.txtSubject.TabIndex = 9;
            // 
            // cdvAlarmID
            // 
            this.cdvAlarmID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmID.BtnToolTipText = "";
            this.cdvAlarmID.DescText = "";
            this.cdvAlarmID.DisplaySubItemIndex = -1;
            this.cdvAlarmID.DisplayText = "";
            this.cdvAlarmID.Focusing = null;
            this.cdvAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmID.Index = 0;
            this.cdvAlarmID.IsViewBtnImage = false;
            this.cdvAlarmID.Location = new System.Drawing.Point(75, 14);
            this.cdvAlarmID.MaxLength = 20;
            this.cdvAlarmID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmID.Name = "cdvAlarmID";
            this.cdvAlarmID.ReadOnly = true;
            this.cdvAlarmID.SearchSubItemIndex = 0;
            this.cdvAlarmID.SelectedDescIndex = -1;
            this.cdvAlarmID.SelectedSubItemIndex = -1;
            this.cdvAlarmID.SelectionStart = 0;
            this.cdvAlarmID.Size = new System.Drawing.Size(159, 20);
            this.cdvAlarmID.SmallImageList = null;
            this.cdvAlarmID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmID.TabIndex = 7;
            this.cdvAlarmID.TextBoxToolTipText = "";
            this.cdvAlarmID.TextBoxWidth = 159;
            this.cdvAlarmID.VisibleButton = true;
            this.cdvAlarmID.VisibleColumnHeader = false;
            this.cdvAlarmID.VisibleDescription = false;
            // 
            // lblAlarmID
            // 
            this.lblAlarmID.AutoSize = true;
            this.lblAlarmID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmID.Location = new System.Drawing.Point(8, 18);
            this.lblAlarmID.Name = "lblAlarmID";
            this.lblAlarmID.Size = new System.Drawing.Size(47, 13);
            this.lblAlarmID.TabIndex = 6;
            this.lblAlarmID.Text = "Alarm ID";
            this.lblAlarmID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcProcessActionRaiseAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcProcessActionRaiseAlarm";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private UI.Controls.MCCodeView.MCCodeView cdvAlarmID;
        private System.Windows.Forms.Label lblAlarmID;
    }
}
