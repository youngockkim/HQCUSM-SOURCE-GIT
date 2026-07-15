namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionInputAttribute
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
            this.txtCmmt4 = new System.Windows.Forms.TextBox();
            this.txtCmmt3 = new System.Windows.Forms.TextBox();
            this.txtCmmt2 = new System.Windows.Forms.TextBox();
            this.txtCmmt1 = new System.Windows.Forms.TextBox();
            this.lblAttrValue = new System.Windows.Forms.Label();
            this.txtAttrValue = new System.Windows.Forms.TextBox();
            this.cdvAttrName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.cdvAttrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.chkMultiTrans = new System.Windows.Forms.CheckBox();
            this.grpActionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.chkMultiTrans);
            this.grpActionValue.Controls.Add(this.cdvAttrType);
            this.grpActionValue.Controls.Add(this.lblAttrType);
            this.grpActionValue.Controls.Add(this.txtCmmt4);
            this.grpActionValue.Controls.Add(this.txtCmmt3);
            this.grpActionValue.Controls.Add(this.txtCmmt2);
            this.grpActionValue.Controls.Add(this.txtCmmt1);
            this.grpActionValue.Controls.Add(this.lblAttrValue);
            this.grpActionValue.Controls.Add(this.txtAttrValue);
            this.grpActionValue.Controls.Add(this.cdvAttrName);
            this.grpActionValue.Controls.Add(this.lblAttrName);
            // 
            // txtCmmt4
            // 
            this.txtCmmt4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt4.Location = new System.Drawing.Point(11, 202);
            this.txtCmmt4.Multiline = true;
            this.txtCmmt4.Name = "txtCmmt4";
            this.txtCmmt4.ReadOnly = true;
            this.txtCmmt4.Size = new System.Drawing.Size(223, 30);
            this.txtCmmt4.TabIndex = 9;
            this.txtCmmt4.TabStop = false;
            this.txtCmmt4.Text = "$DATETIME - Update as system date/time by \"YYYYMMDDHH24MISS\" format";
            // 
            // txtCmmt3
            // 
            this.txtCmmt3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt3.Location = new System.Drawing.Point(11, 166);
            this.txtCmmt3.Multiline = true;
            this.txtCmmt3.Name = "txtCmmt3";
            this.txtCmmt3.ReadOnly = true;
            this.txtCmmt3.Size = new System.Drawing.Size(223, 30);
            this.txtCmmt3.TabIndex = 8;
            this.txtCmmt3.TabStop = false;
            this.txtCmmt3.Text = "$DATE - Update as system date by \"YYYYMMDD\" format";
            // 
            // txtCmmt2
            // 
            this.txtCmmt2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt2.Location = new System.Drawing.Point(11, 130);
            this.txtCmmt2.Multiline = true;
            this.txtCmmt2.Name = "txtCmmt2";
            this.txtCmmt2.ReadOnly = true;
            this.txtCmmt2.Size = new System.Drawing.Size(223, 30);
            this.txtCmmt2.TabIndex = 7;
            this.txtCmmt2.TabStop = false;
            this.txtCmmt2.Text = "$DECREASE(number) - Decrease from current value by given \"number\"";
            // 
            // txtCmmt1
            // 
            this.txtCmmt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmmt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmmt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmmt1.Location = new System.Drawing.Point(11, 94);
            this.txtCmmt1.Multiline = true;
            this.txtCmmt1.Name = "txtCmmt1";
            this.txtCmmt1.ReadOnly = true;
            this.txtCmmt1.Size = new System.Drawing.Size(223, 30);
            this.txtCmmt1.TabIndex = 6;
            this.txtCmmt1.TabStop = false;
            this.txtCmmt1.Text = "$INCREASE(number) - Increase from current value by given \"number\"";
            // 
            // lblAttrValue
            // 
            this.lblAttrValue.AutoSize = true;
            this.lblAttrValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrValue.Location = new System.Drawing.Point(8, 72);
            this.lblAttrValue.Name = "lblAttrValue";
            this.lblAttrValue.Size = new System.Drawing.Size(76, 13);
            this.lblAttrValue.TabIndex = 4;
            this.lblAttrValue.Text = "Attribute Value";
            this.lblAttrValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAttrValue
            // 
            this.txtAttrValue.Location = new System.Drawing.Point(94, 68);
            this.txtAttrValue.MaxLength = 50;
            this.txtAttrValue.Name = "txtAttrValue";
            this.txtAttrValue.Size = new System.Drawing.Size(140, 20);
            this.txtAttrValue.TabIndex = 5;
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
            this.cdvAttrName.Location = new System.Drawing.Point(94, 44);
            this.cdvAttrName.MaxLength = 50;
            this.cdvAttrName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.Name = "cdvAttrName";
            this.cdvAttrName.ReadOnly = true;
            this.cdvAttrName.SearchSubItemIndex = 0;
            this.cdvAttrName.SelectedDescIndex = -1;
            this.cdvAttrName.SelectedSubItemIndex = -1;
            this.cdvAttrName.SelectionStart = 0;
            this.cdvAttrName.Size = new System.Drawing.Size(140, 20);
            this.cdvAttrName.SmallImageList = null;
            this.cdvAttrName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrName.TabIndex = 3;
            this.cdvAttrName.TextBoxToolTipText = "";
            this.cdvAttrName.TextBoxWidth = 140;
            this.cdvAttrName.VisibleButton = true;
            this.cdvAttrName.VisibleColumnHeader = false;
            this.cdvAttrName.VisibleDescription = false;
            this.cdvAttrName.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrName_SelectedItemChanged);
            this.cdvAttrName.ButtonPress += new System.EventHandler(this.cdvAttrName_ButtonPress);
            // 
            // lblAttrName
            // 
            this.lblAttrName.AutoSize = true;
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrName.Location = new System.Drawing.Point(8, 48);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(77, 13);
            this.lblAttrName.TabIndex = 2;
            this.lblAttrName.Text = "Attribute Name";
            this.lblAttrName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvAttrType
            // 
            this.cdvAttrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrType.BtnToolTipText = "";
            this.cdvAttrType.DescText = "";
            this.cdvAttrType.DisplaySubItemIndex = -1;
            this.cdvAttrType.DisplayText = "";
            this.cdvAttrType.Focusing = null;
            this.cdvAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrType.Index = 0;
            this.cdvAttrType.IsViewBtnImage = false;
            this.cdvAttrType.Location = new System.Drawing.Point(93, 20);
            this.cdvAttrType.MaxLength = 50;
            this.cdvAttrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.Name = "cdvAttrType";
            this.cdvAttrType.ReadOnly = true;
            this.cdvAttrType.SearchSubItemIndex = 0;
            this.cdvAttrType.SelectedDescIndex = -1;
            this.cdvAttrType.SelectedSubItemIndex = -1;
            this.cdvAttrType.SelectionStart = 0;
            this.cdvAttrType.Size = new System.Drawing.Size(140, 20);
            this.cdvAttrType.SmallImageList = null;
            this.cdvAttrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrType.TabIndex = 1;
            this.cdvAttrType.TextBoxToolTipText = "";
            this.cdvAttrType.TextBoxWidth = 140;
            this.cdvAttrType.VisibleButton = true;
            this.cdvAttrType.VisibleColumnHeader = false;
            this.cdvAttrType.VisibleDescription = false;
            this.cdvAttrType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrType_SelectedItemChanged);
            // 
            // lblAttrType
            // 
            this.lblAttrType.AutoSize = true;
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.Location = new System.Drawing.Point(7, 24);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(73, 13);
            this.lblAttrType.TabIndex = 0;
            this.lblAttrType.Text = "Attribute Type";
            this.lblAttrType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkMultiTrans
            // 
            this.chkMultiTrans.AutoSize = true;
            this.chkMultiTrans.Location = new System.Drawing.Point(10, 240);
            this.chkMultiTrans.Name = "chkMultiTrans";
            this.chkMultiTrans.Size = new System.Drawing.Size(146, 17);
            this.chkMultiTrans.TabIndex = 10;
            this.chkMultiTrans.Text = "Perform Multi Transaction";
            this.chkMultiTrans.UseVisualStyleBackColor = true;
            // 
            // udcStepActionInputAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcStepActionInputAttribute";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCmmt4;
        private System.Windows.Forms.TextBox txtCmmt3;
        private System.Windows.Forms.TextBox txtCmmt2;
        private System.Windows.Forms.TextBox txtCmmt1;
        private System.Windows.Forms.Label lblAttrValue;
        private System.Windows.Forms.TextBox txtAttrValue;
        private UI.Controls.MCCodeView.MCCodeView cdvAttrName;
        private System.Windows.Forms.Label lblAttrName;
        private UI.Controls.MCCodeView.MCCodeView cdvAttrType;
        private System.Windows.Forms.Label lblAttrType;
        private System.Windows.Forms.CheckBox chkMultiTrans;
    }
}
