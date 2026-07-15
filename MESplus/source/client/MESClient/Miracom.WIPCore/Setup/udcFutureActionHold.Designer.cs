namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionHold
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
            this.lblHoldPass = new System.Windows.Forms.Label();
            this.txtHoldPass = new System.Windows.Forms.TextBox();
            this.cdvHoldCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblHoldCode = new System.Windows.Forms.Label();
            this.grpActionFalse = new System.Windows.Forms.GroupBox();
            this.lblHoldPassFalse = new System.Windows.Forms.Label();
            this.txtHoldPassFalse = new System.Windows.Forms.TextBox();
            this.cdvHoldCodeFalse = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblHoldCodeFalse = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.pnlActionValueTop.SuspendLayout();
            this.grpActionTrue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).BeginInit();
            this.grpActionFalse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCodeFalse)).BeginInit();
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
            this.grpActionTrue.Controls.Add(this.lblHoldPass);
            this.grpActionTrue.Controls.Add(this.txtHoldPass);
            this.grpActionTrue.Controls.Add(this.cdvHoldCode);
            this.grpActionTrue.Controls.Add(this.lblHoldCode);
            this.grpActionTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionTrue.Location = new System.Drawing.Point(3, 42);
            this.grpActionTrue.Name = "grpActionTrue";
            this.grpActionTrue.Size = new System.Drawing.Size(524, 73);
            this.grpActionTrue.TabIndex = 1;
            this.grpActionTrue.TabStop = false;
            this.grpActionTrue.Text = "True Action";
            // 
            // lblHoldPass
            // 
            this.lblHoldPass.AutoSize = true;
            this.lblHoldPass.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldPass.Location = new System.Drawing.Point(8, 46);
            this.lblHoldPass.Name = "lblHoldPass";
            this.lblHoldPass.Size = new System.Drawing.Size(78, 13);
            this.lblHoldPass.TabIndex = 2;
            this.lblHoldPass.Text = "Hold Password";
            this.lblHoldPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHoldPass
            // 
            this.txtHoldPass.Location = new System.Drawing.Point(94, 42);
            this.txtHoldPass.MaxLength = 20;
            this.txtHoldPass.Name = "txtHoldPass";
            this.txtHoldPass.PasswordChar = '*';
            this.txtHoldPass.Size = new System.Drawing.Size(180, 20);
            this.txtHoldPass.TabIndex = 3;
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
            this.cdvHoldCode.Location = new System.Drawing.Point(94, 18);
            this.cdvHoldCode.MaxLength = 10;
            this.cdvHoldCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.Name = "cdvHoldCode";
            this.cdvHoldCode.ReadOnly = true;
            this.cdvHoldCode.SearchSubItemIndex = 0;
            this.cdvHoldCode.SelectedDescIndex = -1;
            this.cdvHoldCode.SelectedSubItemIndex = -1;
            this.cdvHoldCode.SelectionStart = 0;
            this.cdvHoldCode.Size = new System.Drawing.Size(180, 20);
            this.cdvHoldCode.SmallImageList = null;
            this.cdvHoldCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvHoldCode.TabIndex = 1;
            this.cdvHoldCode.TextBoxToolTipText = "";
            this.cdvHoldCode.TextBoxWidth = 180;
            this.cdvHoldCode.VisibleButton = true;
            this.cdvHoldCode.VisibleColumnHeader = false;
            this.cdvHoldCode.VisibleDescription = false;
            // 
            // lblHoldCode
            // 
            this.lblHoldCode.AutoSize = true;
            this.lblHoldCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldCode.Location = new System.Drawing.Point(8, 22);
            this.lblHoldCode.Name = "lblHoldCode";
            this.lblHoldCode.Size = new System.Drawing.Size(57, 13);
            this.lblHoldCode.TabIndex = 0;
            this.lblHoldCode.Text = "Hold Code";
            this.lblHoldCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpActionFalse
            // 
            this.grpActionFalse.Controls.Add(this.lblHoldPassFalse);
            this.grpActionFalse.Controls.Add(this.txtHoldPassFalse);
            this.grpActionFalse.Controls.Add(this.cdvHoldCodeFalse);
            this.grpActionFalse.Controls.Add(this.lblHoldCodeFalse);
            this.grpActionFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionFalse.Location = new System.Drawing.Point(3, 115);
            this.grpActionFalse.Name = "grpActionFalse";
            this.grpActionFalse.Size = new System.Drawing.Size(524, 212);
            this.grpActionFalse.TabIndex = 2;
            this.grpActionFalse.TabStop = false;
            this.grpActionFalse.Text = "False Action";
            // 
            // lblHoldPassFalse
            // 
            this.lblHoldPassFalse.AutoSize = true;
            this.lblHoldPassFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldPassFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldPassFalse.Location = new System.Drawing.Point(8, 46);
            this.lblHoldPassFalse.Name = "lblHoldPassFalse";
            this.lblHoldPassFalse.Size = new System.Drawing.Size(78, 13);
            this.lblHoldPassFalse.TabIndex = 2;
            this.lblHoldPassFalse.Text = "Hold Password";
            this.lblHoldPassFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHoldPassFalse
            // 
            this.txtHoldPassFalse.Location = new System.Drawing.Point(94, 42);
            this.txtHoldPassFalse.MaxLength = 20;
            this.txtHoldPassFalse.Name = "txtHoldPassFalse";
            this.txtHoldPassFalse.PasswordChar = '*';
            this.txtHoldPassFalse.Size = new System.Drawing.Size(180, 20);
            this.txtHoldPassFalse.TabIndex = 3;
            // 
            // cdvHoldCodeFalse
            // 
            this.cdvHoldCodeFalse.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvHoldCodeFalse.BorderHotColor = System.Drawing.Color.Black;
            this.cdvHoldCodeFalse.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvHoldCodeFalse.BtnToolTipText = "";
            this.cdvHoldCodeFalse.DescText = "";
            this.cdvHoldCodeFalse.DisplaySubItemIndex = -1;
            this.cdvHoldCodeFalse.DisplayText = "";
            this.cdvHoldCodeFalse.Focusing = null;
            this.cdvHoldCodeFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvHoldCodeFalse.Index = 0;
            this.cdvHoldCodeFalse.IsViewBtnImage = false;
            this.cdvHoldCodeFalse.Location = new System.Drawing.Point(94, 18);
            this.cdvHoldCodeFalse.MaxLength = 10;
            this.cdvHoldCodeFalse.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCodeFalse.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCodeFalse.Name = "cdvHoldCodeFalse";
            this.cdvHoldCodeFalse.ReadOnly = true;
            this.cdvHoldCodeFalse.SearchSubItemIndex = 0;
            this.cdvHoldCodeFalse.SelectedDescIndex = -1;
            this.cdvHoldCodeFalse.SelectedSubItemIndex = -1;
            this.cdvHoldCodeFalse.SelectionStart = 0;
            this.cdvHoldCodeFalse.Size = new System.Drawing.Size(180, 20);
            this.cdvHoldCodeFalse.SmallImageList = null;
            this.cdvHoldCodeFalse.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvHoldCodeFalse.TabIndex = 1;
            this.cdvHoldCodeFalse.TextBoxToolTipText = "";
            this.cdvHoldCodeFalse.TextBoxWidth = 180;
            this.cdvHoldCodeFalse.VisibleButton = true;
            this.cdvHoldCodeFalse.VisibleColumnHeader = false;
            this.cdvHoldCodeFalse.VisibleDescription = false;
            // 
            // lblHoldCodeFalse
            // 
            this.lblHoldCodeFalse.AutoSize = true;
            this.lblHoldCodeFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCodeFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldCodeFalse.Location = new System.Drawing.Point(8, 22);
            this.lblHoldCodeFalse.Name = "lblHoldCodeFalse";
            this.lblHoldCodeFalse.Size = new System.Drawing.Size(57, 13);
            this.lblHoldCodeFalse.TabIndex = 0;
            this.lblHoldCodeFalse.Text = "Hold Code";
            this.lblHoldCodeFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcFutureActionHold
            // 
            this.Name = "udcFutureActionHold";
            this.grpActionValue.ResumeLayout(false);
            this.pnlActionValueTop.ResumeLayout(false);
            this.pnlActionValueTop.PerformLayout();
            this.grpActionTrue.ResumeLayout(false);
            this.grpActionTrue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).EndInit();
            this.grpActionFalse.ResumeLayout(false);
            this.grpActionFalse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCodeFalse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActionValueTop;
        private System.Windows.Forms.ComboBox cboActionType;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.GroupBox grpActionFalse;
        private System.Windows.Forms.Label lblHoldPassFalse;
        private System.Windows.Forms.TextBox txtHoldPassFalse;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvHoldCodeFalse;
        private System.Windows.Forms.Label lblHoldCodeFalse;
        private System.Windows.Forms.GroupBox grpActionTrue;
        private System.Windows.Forms.Label lblHoldPass;
        private System.Windows.Forms.TextBox txtHoldPass;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvHoldCode;
        private System.Windows.Forms.Label lblHoldCode;
    }
}
