namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionInputAttribute
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
            this.txtCmmt4 = new System.Windows.Forms.TextBox();
            this.txtCmmt3 = new System.Windows.Forms.TextBox();
            this.txtCmmt2 = new System.Windows.Forms.TextBox();
            this.txtCmmt1 = new System.Windows.Forms.TextBox();
            this.lblAttrValue = new System.Windows.Forms.Label();
            this.txtAttrValue = new System.Windows.Forms.TextBox();
            this.cdvAttrName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.grpActionFalse = new System.Windows.Forms.GroupBox();
            this.txtCmmt14 = new System.Windows.Forms.TextBox();
            this.txtCmmt13 = new System.Windows.Forms.TextBox();
            this.txtCmmt12 = new System.Windows.Forms.TextBox();
            this.txtCmmt11 = new System.Windows.Forms.TextBox();
            this.lblAttrValueFalse = new System.Windows.Forms.Label();
            this.txtAttrValueFalse = new System.Windows.Forms.TextBox();
            this.cdvAttrNameFalse = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrNameFalse = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.pnlActionValueTop.SuspendLayout();
            this.grpActionTrue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).BeginInit();
            this.grpActionFalse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrNameFalse)).BeginInit();
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
            this.grpActionTrue.Controls.Add(this.txtCmmt4);
            this.grpActionTrue.Controls.Add(this.txtCmmt3);
            this.grpActionTrue.Controls.Add(this.txtCmmt2);
            this.grpActionTrue.Controls.Add(this.txtCmmt1);
            this.grpActionTrue.Controls.Add(this.lblAttrValue);
            this.grpActionTrue.Controls.Add(this.txtAttrValue);
            this.grpActionTrue.Controls.Add(this.cdvAttrName);
            this.grpActionTrue.Controls.Add(this.lblAttrName);
            this.grpActionTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionTrue.Location = new System.Drawing.Point(3, 42);
            this.grpActionTrue.Name = "grpActionTrue";
            this.grpActionTrue.Size = new System.Drawing.Size(524, 142);
            this.grpActionTrue.TabIndex = 1;
            this.grpActionTrue.TabStop = false;
            this.grpActionTrue.Text = "True Action";
            // 
            // txtCmmt4
            // 
            this.txtCmmt4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt4.Location = new System.Drawing.Point(94, 119);
            this.txtCmmt4.Name = "txtCmmt4";
            this.txtCmmt4.ReadOnly = true;
            this.txtCmmt4.Size = new System.Drawing.Size(424, 13);
            this.txtCmmt4.TabIndex = 8;
            this.txtCmmt4.TabStop = false;
            this.txtCmmt4.Text = "$DATETIME - Update as system date/time by \"YYYYMMDDHH24MISS\" format";
            // 
            // txtCmmt3
            // 
            this.txtCmmt3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt3.Location = new System.Drawing.Point(94, 102);
            this.txtCmmt3.Name = "txtCmmt3";
            this.txtCmmt3.ReadOnly = true;
            this.txtCmmt3.Size = new System.Drawing.Size(424, 13);
            this.txtCmmt3.TabIndex = 7;
            this.txtCmmt3.TabStop = false;
            this.txtCmmt3.Text = "$DATE - Update as system date by \"YYYYMMDD\" format";
            // 
            // txtCmmt2
            // 
            this.txtCmmt2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt2.Location = new System.Drawing.Point(94, 85);
            this.txtCmmt2.Name = "txtCmmt2";
            this.txtCmmt2.ReadOnly = true;
            this.txtCmmt2.Size = new System.Drawing.Size(424, 13);
            this.txtCmmt2.TabIndex = 6;
            this.txtCmmt2.TabStop = false;
            this.txtCmmt2.Text = "$DECREASE(number) - Decrease from current value by given \"number\"";
            // 
            // txtCmmt1
            // 
            this.txtCmmt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt1.Location = new System.Drawing.Point(94, 68);
            this.txtCmmt1.Name = "txtCmmt1";
            this.txtCmmt1.ReadOnly = true;
            this.txtCmmt1.Size = new System.Drawing.Size(424, 13);
            this.txtCmmt1.TabIndex = 5;
            this.txtCmmt1.TabStop = false;
            this.txtCmmt1.Text = "$INCREASE(number) - Increase from current value by given \"number\"";
            // 
            // lblAttrValue
            // 
            this.lblAttrValue.AutoSize = true;
            this.lblAttrValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrValue.Location = new System.Drawing.Point(8, 46);
            this.lblAttrValue.Name = "lblAttrValue";
            this.lblAttrValue.Size = new System.Drawing.Size(76, 13);
            this.lblAttrValue.TabIndex = 2;
            this.lblAttrValue.Text = "Attribute Value";
            this.lblAttrValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAttrValue
            // 
            this.txtAttrValue.Location = new System.Drawing.Point(94, 42);
            this.txtAttrValue.MaxLength = 50;
            this.txtAttrValue.Name = "txtAttrValue";
            this.txtAttrValue.Size = new System.Drawing.Size(180, 20);
            this.txtAttrValue.TabIndex = 3;
            // 
            // cdvAttrName
            // 
            this.cdvAttrName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrName.BtnToolTipText = "";
            this.cdvAttrName.DescText = "";
            this.cdvAttrName.DisplaySubItemIndex = -1;
            this.cdvAttrName.DisplayText = "";
            this.cdvAttrName.Focusing = null;
            this.cdvAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrName.Index = 0;
            this.cdvAttrName.IsViewBtnImage = false;
            this.cdvAttrName.Location = new System.Drawing.Point(94, 18);
            this.cdvAttrName.MaxLength = 50;
            this.cdvAttrName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.Name = "cdvAttrName";
            this.cdvAttrName.ReadOnly = true;
            this.cdvAttrName.SearchSubItemIndex = 0;
            this.cdvAttrName.SelectedDescIndex = -1;
            this.cdvAttrName.SelectedSubItemIndex = -1;
            this.cdvAttrName.SelectionStart = 0;
            this.cdvAttrName.Size = new System.Drawing.Size(180, 20);
            this.cdvAttrName.SmallImageList = null;
            this.cdvAttrName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrName.TabIndex = 1;
            this.cdvAttrName.TextBoxToolTipText = "";
            this.cdvAttrName.TextBoxWidth = 180;
            this.cdvAttrName.VisibleButton = true;
            this.cdvAttrName.VisibleColumnHeader = false;
            this.cdvAttrName.VisibleDescription = false;
            // 
            // lblAttrName
            // 
            this.lblAttrName.AutoSize = true;
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrName.Location = new System.Drawing.Point(8, 22);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(77, 13);
            this.lblAttrName.TabIndex = 0;
            this.lblAttrName.Text = "Attribute Name";
            this.lblAttrName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpActionFalse
            // 
            this.grpActionFalse.Controls.Add(this.txtCmmt14);
            this.grpActionFalse.Controls.Add(this.txtCmmt13);
            this.grpActionFalse.Controls.Add(this.txtCmmt12);
            this.grpActionFalse.Controls.Add(this.txtCmmt11);
            this.grpActionFalse.Controls.Add(this.lblAttrValueFalse);
            this.grpActionFalse.Controls.Add(this.txtAttrValueFalse);
            this.grpActionFalse.Controls.Add(this.cdvAttrNameFalse);
            this.grpActionFalse.Controls.Add(this.lblAttrNameFalse);
            this.grpActionFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionFalse.Location = new System.Drawing.Point(3, 184);
            this.grpActionFalse.Name = "grpActionFalse";
            this.grpActionFalse.Size = new System.Drawing.Size(524, 143);
            this.grpActionFalse.TabIndex = 2;
            this.grpActionFalse.TabStop = false;
            this.grpActionFalse.Text = "False Action";
            // 
            // txtCmmt14
            // 
            this.txtCmmt14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt14.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt14.Location = new System.Drawing.Point(94, 119);
            this.txtCmmt14.Name = "txtCmmt14";
            this.txtCmmt14.ReadOnly = true;
            this.txtCmmt14.Size = new System.Drawing.Size(424, 13);
            this.txtCmmt14.TabIndex = 12;
            this.txtCmmt14.TabStop = false;
            this.txtCmmt14.Text = "$DATETIME - Update as system date/time by \"YYYYMMDDHH24MISS\" format";
            // 
            // txtCmmt13
            // 
            this.txtCmmt13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt13.Location = new System.Drawing.Point(94, 102);
            this.txtCmmt13.Name = "txtCmmt13";
            this.txtCmmt13.ReadOnly = true;
            this.txtCmmt13.Size = new System.Drawing.Size(424, 13);
            this.txtCmmt13.TabIndex = 11;
            this.txtCmmt13.TabStop = false;
            this.txtCmmt13.Text = "$DATE - Update as system date by \"YYYYMMDD\" format";
            // 
            // txtCmmt12
            // 
            this.txtCmmt12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt12.Location = new System.Drawing.Point(94, 85);
            this.txtCmmt12.Name = "txtCmmt12";
            this.txtCmmt12.ReadOnly = true;
            this.txtCmmt12.Size = new System.Drawing.Size(424, 13);
            this.txtCmmt12.TabIndex = 10;
            this.txtCmmt12.TabStop = false;
            this.txtCmmt12.Text = "$DECREASE(number) - Decrease from current value by given \"number\"";
            // 
            // txtCmmt11
            // 
            this.txtCmmt11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt11.Location = new System.Drawing.Point(94, 68);
            this.txtCmmt11.Name = "txtCmmt11";
            this.txtCmmt11.ReadOnly = true;
            this.txtCmmt11.Size = new System.Drawing.Size(424, 13);
            this.txtCmmt11.TabIndex = 9;
            this.txtCmmt11.TabStop = false;
            this.txtCmmt11.Text = "$INCREASE(number) - Increase from current value by given \"number\"";
            // 
            // lblAttrValueFalse
            // 
            this.lblAttrValueFalse.AutoSize = true;
            this.lblAttrValueFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrValueFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrValueFalse.Location = new System.Drawing.Point(8, 46);
            this.lblAttrValueFalse.Name = "lblAttrValueFalse";
            this.lblAttrValueFalse.Size = new System.Drawing.Size(76, 13);
            this.lblAttrValueFalse.TabIndex = 2;
            this.lblAttrValueFalse.Text = "Attribute Value";
            this.lblAttrValueFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAttrValueFalse
            // 
            this.txtAttrValueFalse.Location = new System.Drawing.Point(94, 42);
            this.txtAttrValueFalse.MaxLength = 50;
            this.txtAttrValueFalse.Name = "txtAttrValueFalse";
            this.txtAttrValueFalse.Size = new System.Drawing.Size(180, 20);
            this.txtAttrValueFalse.TabIndex = 3;
            // 
            // cdvAttrNameFalse
            // 
            this.cdvAttrNameFalse.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrNameFalse.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrNameFalse.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrNameFalse.BtnToolTipText = "";
            this.cdvAttrNameFalse.DescText = "";
            this.cdvAttrNameFalse.DisplaySubItemIndex = -1;
            this.cdvAttrNameFalse.DisplayText = "";
            this.cdvAttrNameFalse.Focusing = null;
            this.cdvAttrNameFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrNameFalse.Index = 0;
            this.cdvAttrNameFalse.IsViewBtnImage = false;
            this.cdvAttrNameFalse.Location = new System.Drawing.Point(94, 18);
            this.cdvAttrNameFalse.MaxLength = 50;
            this.cdvAttrNameFalse.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrNameFalse.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrNameFalse.Name = "cdvAttrNameFalse";
            this.cdvAttrNameFalse.ReadOnly = true;
            this.cdvAttrNameFalse.SearchSubItemIndex = 0;
            this.cdvAttrNameFalse.SelectedDescIndex = -1;
            this.cdvAttrNameFalse.SelectedSubItemIndex = -1;
            this.cdvAttrNameFalse.SelectionStart = 0;
            this.cdvAttrNameFalse.Size = new System.Drawing.Size(180, 20);
            this.cdvAttrNameFalse.SmallImageList = null;
            this.cdvAttrNameFalse.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrNameFalse.TabIndex = 1;
            this.cdvAttrNameFalse.TextBoxToolTipText = "";
            this.cdvAttrNameFalse.TextBoxWidth = 180;
            this.cdvAttrNameFalse.VisibleButton = true;
            this.cdvAttrNameFalse.VisibleColumnHeader = false;
            this.cdvAttrNameFalse.VisibleDescription = false;
            // 
            // lblAttrNameFalse
            // 
            this.lblAttrNameFalse.AutoSize = true;
            this.lblAttrNameFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrNameFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrNameFalse.Location = new System.Drawing.Point(8, 22);
            this.lblAttrNameFalse.Name = "lblAttrNameFalse";
            this.lblAttrNameFalse.Size = new System.Drawing.Size(77, 13);
            this.lblAttrNameFalse.TabIndex = 0;
            this.lblAttrNameFalse.Text = "Attribute Name";
            this.lblAttrNameFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcFutureActionInputAttribute
            // 
            this.Name = "udcFutureActionInputAttribute";
            this.grpActionValue.ResumeLayout(false);
            this.pnlActionValueTop.ResumeLayout(false);
            this.pnlActionValueTop.PerformLayout();
            this.grpActionTrue.ResumeLayout(false);
            this.grpActionTrue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).EndInit();
            this.grpActionFalse.ResumeLayout(false);
            this.grpActionFalse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrNameFalse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActionValueTop;
        private System.Windows.Forms.ComboBox cboActionType;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.GroupBox grpActionFalse;
        private System.Windows.Forms.Label lblAttrValueFalse;
        private System.Windows.Forms.TextBox txtAttrValueFalse;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrNameFalse;
        private System.Windows.Forms.Label lblAttrNameFalse;
        private System.Windows.Forms.GroupBox grpActionTrue;
        private System.Windows.Forms.Label lblAttrValue;
        private System.Windows.Forms.TextBox txtAttrValue;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrName;
        private System.Windows.Forms.Label lblAttrName;
        private System.Windows.Forms.TextBox txtCmmt14;
        private System.Windows.Forms.TextBox txtCmmt13;
        private System.Windows.Forms.TextBox txtCmmt12;
        private System.Windows.Forms.TextBox txtCmmt11;
        private System.Windows.Forms.TextBox txtCmmt4;
        private System.Windows.Forms.TextBox txtCmmt3;
        private System.Windows.Forms.TextBox txtCmmt2;
        private System.Windows.Forms.TextBox txtCmmt1;
    }
}
