namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionRaiseAlarm
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
            this.pnlActionValueTop = new System.Windows.Forms.Panel();
            this.cboActionType = new System.Windows.Forms.ComboBox();
            this.lblActionType = new System.Windows.Forms.Label();
            this.grpActionTrue = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.cdvAlarmID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAlarmID = new System.Windows.Forms.Label();
            this.grpActionFalse = new System.Windows.Forms.GroupBox();
            this.lblMessageFalse = new System.Windows.Forms.Label();
            this.txtMessageFalse = new System.Windows.Forms.TextBox();
            this.lblSubjectFalse = new System.Windows.Forms.Label();
            this.txtSubjectFalse = new System.Windows.Forms.TextBox();
            this.cdvAlarmIDFalse = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAlarmIDFalse = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.pnlActionValueTop.SuspendLayout();
            this.grpActionTrue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmID)).BeginInit();
            this.grpActionFalse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmIDFalse)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.grpActionFalse);
            this.grpActionValue.Controls.Add(this.grpActionTrue);
            this.grpActionValue.Controls.Add(this.pnlActionValueTop);
            // 
            // pnlActionValueTop
            // 
            this.pnlActionValueTop.Controls.Add(this.cboActionType);
            this.pnlActionValueTop.Controls.Add(this.lblActionType);
            this.pnlActionValueTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionValueTop.Location = new System.Drawing.Point(3, 16);
            this.pnlActionValueTop.Name = "pnlActionValueTop";
            this.pnlActionValueTop.Size = new System.Drawing.Size(524, 26);
            this.pnlActionValueTop.TabIndex = 0;
            // 
            // cboActionType
            // 
            this.cboActionType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboActionType.FormattingEnabled = true;
            this.cboActionType.Items.AddRange(new object[] {
            "Just positive condition",
            "Action with True or False"});
            this.cboActionType.Location = new System.Drawing.Point(94, 2);
            this.cboActionType.Name = "cboActionType";
            this.cboActionType.Size = new System.Drawing.Size(250, 21);
            this.cboActionType.TabIndex = 1;
            this.cboActionType.SelectedIndexChanged += new System.EventHandler(this.cboActionType_SelectedIndexChanged);
            this.cboActionType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboActionType_KeyPress);
            // 
            // lblActionType
            // 
            this.lblActionType.AutoSize = true;
            this.lblActionType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActionType.Location = new System.Drawing.Point(8, 6);
            this.lblActionType.Name = "lblActionType";
            this.lblActionType.Size = new System.Drawing.Size(64, 13);
            this.lblActionType.TabIndex = 0;
            this.lblActionType.Text = "Action Type";
            // 
            // grpActionTrue
            // 
            this.grpActionTrue.Controls.Add(this.lblMessage);
            this.grpActionTrue.Controls.Add(this.txtMessage);
            this.grpActionTrue.Controls.Add(this.lblSubject);
            this.grpActionTrue.Controls.Add(this.txtSubject);
            this.grpActionTrue.Controls.Add(this.cdvAlarmID);
            this.grpActionTrue.Controls.Add(this.lblAlarmID);
            this.grpActionTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionTrue.Location = new System.Drawing.Point(3, 42);
            this.grpActionTrue.Name = "grpActionTrue";
            this.grpActionTrue.Size = new System.Drawing.Size(524, 142);
            this.grpActionTrue.TabIndex = 1;
            this.grpActionTrue.TabStop = false;
            this.grpActionTrue.Text = "True Action";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(8, 71);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(94, 67);
            this.txtMessage.MaxLength = 50;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(424, 69);
            this.txtMessage.TabIndex = 5;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(8, 46);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Text = "Subject";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(94, 42);
            this.txtSubject.MaxLength = 50;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(424, 20);
            this.txtSubject.TabIndex = 3;
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
            this.cdvAlarmID.Location = new System.Drawing.Point(94, 18);
            this.cdvAlarmID.MaxLength = 20;
            this.cdvAlarmID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmID.Name = "cdvAlarmID";
            this.cdvAlarmID.ReadOnly = true;
            this.cdvAlarmID.SearchSubItemIndex = 0;
            this.cdvAlarmID.SelectedDescIndex = -1;
            this.cdvAlarmID.SelectedSubItemIndex = -1;
            this.cdvAlarmID.SelectionStart = 0;
            this.cdvAlarmID.Size = new System.Drawing.Size(180, 20);
            this.cdvAlarmID.SmallImageList = null;
            this.cdvAlarmID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmID.TabIndex = 1;
            this.cdvAlarmID.TextBoxToolTipText = "";
            this.cdvAlarmID.TextBoxWidth = 180;
            this.cdvAlarmID.VisibleButton = true;
            this.cdvAlarmID.VisibleColumnHeader = false;
            this.cdvAlarmID.VisibleDescription = false;
            // 
            // lblAlarmID
            // 
            this.lblAlarmID.AutoSize = true;
            this.lblAlarmID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmID.Location = new System.Drawing.Point(8, 22);
            this.lblAlarmID.Name = "lblAlarmID";
            this.lblAlarmID.Size = new System.Drawing.Size(47, 13);
            this.lblAlarmID.TabIndex = 0;
            this.lblAlarmID.Text = "Alarm ID";
            this.lblAlarmID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpActionFalse
            // 
            this.grpActionFalse.Controls.Add(this.lblMessageFalse);
            this.grpActionFalse.Controls.Add(this.txtMessageFalse);
            this.grpActionFalse.Controls.Add(this.lblSubjectFalse);
            this.grpActionFalse.Controls.Add(this.txtSubjectFalse);
            this.grpActionFalse.Controls.Add(this.cdvAlarmIDFalse);
            this.grpActionFalse.Controls.Add(this.lblAlarmIDFalse);
            this.grpActionFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionFalse.Location = new System.Drawing.Point(3, 184);
            this.grpActionFalse.Name = "grpActionFalse";
            this.grpActionFalse.Size = new System.Drawing.Size(524, 143);
            this.grpActionFalse.TabIndex = 2;
            this.grpActionFalse.TabStop = false;
            this.grpActionFalse.Text = "False Action";
            // 
            // lblMessageFalse
            // 
            this.lblMessageFalse.AutoSize = true;
            this.lblMessageFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMessageFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageFalse.Location = new System.Drawing.Point(8, 71);
            this.lblMessageFalse.Name = "lblMessageFalse";
            this.lblMessageFalse.Size = new System.Drawing.Size(50, 13);
            this.lblMessageFalse.TabIndex = 6;
            this.lblMessageFalse.Text = "Message";
            this.lblMessageFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMessageFalse
            // 
            this.txtMessageFalse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageFalse.Location = new System.Drawing.Point(94, 67);
            this.txtMessageFalse.MaxLength = 50;
            this.txtMessageFalse.Multiline = true;
            this.txtMessageFalse.Name = "txtMessageFalse";
            this.txtMessageFalse.Size = new System.Drawing.Size(424, 69);
            this.txtMessageFalse.TabIndex = 7;
            // 
            // lblSubjectFalse
            // 
            this.lblSubjectFalse.AutoSize = true;
            this.lblSubjectFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubjectFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectFalse.Location = new System.Drawing.Point(8, 46);
            this.lblSubjectFalse.Name = "lblSubjectFalse";
            this.lblSubjectFalse.Size = new System.Drawing.Size(43, 13);
            this.lblSubjectFalse.TabIndex = 2;
            this.lblSubjectFalse.Text = "Subject";
            this.lblSubjectFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSubjectFalse
            // 
            this.txtSubjectFalse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubjectFalse.Location = new System.Drawing.Point(94, 42);
            this.txtSubjectFalse.MaxLength = 50;
            this.txtSubjectFalse.Name = "txtSubjectFalse";
            this.txtSubjectFalse.Size = new System.Drawing.Size(424, 20);
            this.txtSubjectFalse.TabIndex = 3;
            // 
            // cdvAlarmIDFalse
            // 
            this.cdvAlarmIDFalse.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmIDFalse.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmIDFalse.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmIDFalse.BtnToolTipText = "";
            this.cdvAlarmIDFalse.DescText = "";
            this.cdvAlarmIDFalse.DisplaySubItemIndex = -1;
            this.cdvAlarmIDFalse.DisplayText = "";
            this.cdvAlarmIDFalse.Focusing = null;
            this.cdvAlarmIDFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmIDFalse.Index = 0;
            this.cdvAlarmIDFalse.IsViewBtnImage = false;
            this.cdvAlarmIDFalse.Location = new System.Drawing.Point(94, 18);
            this.cdvAlarmIDFalse.MaxLength = 20;
            this.cdvAlarmIDFalse.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmIDFalse.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmIDFalse.Name = "cdvAlarmIDFalse";
            this.cdvAlarmIDFalse.ReadOnly = true;
            this.cdvAlarmIDFalse.SearchSubItemIndex = 0;
            this.cdvAlarmIDFalse.SelectedDescIndex = -1;
            this.cdvAlarmIDFalse.SelectedSubItemIndex = -1;
            this.cdvAlarmIDFalse.SelectionStart = 0;
            this.cdvAlarmIDFalse.Size = new System.Drawing.Size(180, 20);
            this.cdvAlarmIDFalse.SmallImageList = null;
            this.cdvAlarmIDFalse.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmIDFalse.TabIndex = 1;
            this.cdvAlarmIDFalse.TextBoxToolTipText = "";
            this.cdvAlarmIDFalse.TextBoxWidth = 180;
            this.cdvAlarmIDFalse.VisibleButton = true;
            this.cdvAlarmIDFalse.VisibleColumnHeader = false;
            this.cdvAlarmIDFalse.VisibleDescription = false;
            // 
            // lblAlarmIDFalse
            // 
            this.lblAlarmIDFalse.AutoSize = true;
            this.lblAlarmIDFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmIDFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmIDFalse.Location = new System.Drawing.Point(8, 22);
            this.lblAlarmIDFalse.Name = "lblAlarmIDFalse";
            this.lblAlarmIDFalse.Size = new System.Drawing.Size(47, 13);
            this.lblAlarmIDFalse.TabIndex = 0;
            this.lblAlarmIDFalse.Text = "Alarm ID";
            this.lblAlarmIDFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcFutureActionRaiseAlarm
            // 
            this.Name = "udcFutureActionRaiseAlarm";
            this.grpActionValue.ResumeLayout(false);
            this.pnlActionValueTop.ResumeLayout(false);
            this.pnlActionValueTop.PerformLayout();
            this.grpActionTrue.ResumeLayout(false);
            this.grpActionTrue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmID)).EndInit();
            this.grpActionFalse.ResumeLayout(false);
            this.grpActionFalse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmIDFalse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActionValueTop;
        private System.Windows.Forms.ComboBox cboActionType;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.GroupBox grpActionFalse;
        private System.Windows.Forms.Label lblSubjectFalse;
        private System.Windows.Forms.TextBox txtSubjectFalse;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAlarmIDFalse;
        private System.Windows.Forms.Label lblAlarmIDFalse;
        private System.Windows.Forms.GroupBox grpActionTrue;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAlarmID;
        private System.Windows.Forms.Label lblAlarmID;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessageFalse;
        private System.Windows.Forms.TextBox txtMessageFalse;
    }
}
