namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionTerminate
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
            this.cdvTermCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTermCode = new System.Windows.Forms.Label();
            this.grpActionFalse = new System.Windows.Forms.GroupBox();
            this.cdvTermCodeFalse = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTermCodeFalse = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.pnlActionValueTop.SuspendLayout();
            this.grpActionTrue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTermCode)).BeginInit();
            this.grpActionFalse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTermCodeFalse)).BeginInit();
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
            this.grpActionTrue.Controls.Add(this.cdvTermCode);
            this.grpActionTrue.Controls.Add(this.lblTermCode);
            this.grpActionTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionTrue.Location = new System.Drawing.Point(3, 42);
            this.grpActionTrue.Name = "grpActionTrue";
            this.grpActionTrue.Size = new System.Drawing.Size(524, 73);
            this.grpActionTrue.TabIndex = 1;
            this.grpActionTrue.TabStop = false;
            this.grpActionTrue.Text = "True Action";
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
            this.cdvTermCode.Location = new System.Drawing.Point(94, 18);
            this.cdvTermCode.MaxLength = 10;
            this.cdvTermCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTermCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTermCode.Name = "cdvTermCode";
            this.cdvTermCode.ReadOnly = true;
            this.cdvTermCode.SearchSubItemIndex = 0;
            this.cdvTermCode.SelectedDescIndex = -1;
            this.cdvTermCode.SelectedSubItemIndex = -1;
            this.cdvTermCode.SelectionStart = 0;
            this.cdvTermCode.Size = new System.Drawing.Size(180, 20);
            this.cdvTermCode.SmallImageList = null;
            this.cdvTermCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTermCode.TabIndex = 1;
            this.cdvTermCode.TextBoxToolTipText = "";
            this.cdvTermCode.TextBoxWidth = 180;
            this.cdvTermCode.VisibleButton = true;
            this.cdvTermCode.VisibleColumnHeader = false;
            this.cdvTermCode.VisibleDescription = false;
            // 
            // lblTermCode
            // 
            this.lblTermCode.AutoSize = true;
            this.lblTermCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTermCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermCode.Location = new System.Drawing.Point(8, 22);
            this.lblTermCode.Name = "lblTermCode";
            this.lblTermCode.Size = new System.Drawing.Size(82, 13);
            this.lblTermCode.TabIndex = 0;
            this.lblTermCode.Text = "Terminate Code";
            this.lblTermCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpActionFalse
            // 
            this.grpActionFalse.Controls.Add(this.cdvTermCodeFalse);
            this.grpActionFalse.Controls.Add(this.lblTermCodeFalse);
            this.grpActionFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionFalse.Location = new System.Drawing.Point(3, 115);
            this.grpActionFalse.Name = "grpActionFalse";
            this.grpActionFalse.Size = new System.Drawing.Size(524, 212);
            this.grpActionFalse.TabIndex = 2;
            this.grpActionFalse.TabStop = false;
            this.grpActionFalse.Text = "False Action";
            // 
            // cdvTermCodeFalse
            // 
            this.cdvTermCodeFalse.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTermCodeFalse.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTermCodeFalse.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTermCodeFalse.BtnToolTipText = "";
            this.cdvTermCodeFalse.DescText = "";
            this.cdvTermCodeFalse.DisplaySubItemIndex = -1;
            this.cdvTermCodeFalse.DisplayText = "";
            this.cdvTermCodeFalse.Focusing = null;
            this.cdvTermCodeFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTermCodeFalse.Index = 0;
            this.cdvTermCodeFalse.IsViewBtnImage = false;
            this.cdvTermCodeFalse.Location = new System.Drawing.Point(94, 18);
            this.cdvTermCodeFalse.MaxLength = 10;
            this.cdvTermCodeFalse.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTermCodeFalse.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTermCodeFalse.Name = "cdvTermCodeFalse";
            this.cdvTermCodeFalse.ReadOnly = true;
            this.cdvTermCodeFalse.SearchSubItemIndex = 0;
            this.cdvTermCodeFalse.SelectedDescIndex = -1;
            this.cdvTermCodeFalse.SelectedSubItemIndex = -1;
            this.cdvTermCodeFalse.SelectionStart = 0;
            this.cdvTermCodeFalse.Size = new System.Drawing.Size(180, 20);
            this.cdvTermCodeFalse.SmallImageList = null;
            this.cdvTermCodeFalse.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTermCodeFalse.TabIndex = 1;
            this.cdvTermCodeFalse.TextBoxToolTipText = "";
            this.cdvTermCodeFalse.TextBoxWidth = 180;
            this.cdvTermCodeFalse.VisibleButton = true;
            this.cdvTermCodeFalse.VisibleColumnHeader = false;
            this.cdvTermCodeFalse.VisibleDescription = false;
            // 
            // lblTermCodeFalse
            // 
            this.lblTermCodeFalse.AutoSize = true;
            this.lblTermCodeFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTermCodeFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermCodeFalse.Location = new System.Drawing.Point(8, 22);
            this.lblTermCodeFalse.Name = "lblTermCodeFalse";
            this.lblTermCodeFalse.Size = new System.Drawing.Size(82, 13);
            this.lblTermCodeFalse.TabIndex = 0;
            this.lblTermCodeFalse.Text = "Terminate Code";
            this.lblTermCodeFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcFutureActionTerminate
            // 
            this.Name = "udcFutureActionTerminate";
            this.grpActionValue.ResumeLayout(false);
            this.pnlActionValueTop.ResumeLayout(false);
            this.pnlActionValueTop.PerformLayout();
            this.grpActionTrue.ResumeLayout(false);
            this.grpActionTrue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTermCode)).EndInit();
            this.grpActionFalse.ResumeLayout(false);
            this.grpActionFalse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTermCodeFalse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActionValueTop;
        private System.Windows.Forms.ComboBox cboActionType;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.GroupBox grpActionFalse;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTermCodeFalse;
        private System.Windows.Forms.Label lblTermCodeFalse;
        private System.Windows.Forms.GroupBox grpActionTrue;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTermCode;
        private System.Windows.Forms.Label lblTermCode;
    }
}
