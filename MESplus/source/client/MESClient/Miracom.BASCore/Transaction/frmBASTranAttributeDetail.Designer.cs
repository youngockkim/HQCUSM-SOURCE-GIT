namespace Miracom.BASCore
{
    partial class frmBASTranAttributeDetail
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
            this.txtAttrValue = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtAttrType = new System.Windows.Forms.TextBox();
            this.txtAttrName = new System.Windows.Forms.TextBox();
            this.txtAttrKey = new System.Windows.Forms.TextBox();
            this.grpCenter = new System.Windows.Forms.GroupBox();
            this.lblAttrValue = new System.Windows.Forms.Label();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.lblAttrKey = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblAttrDesc = new System.Windows.Forms.Label();
            this.txtAttrDesc = new System.Windows.Forms.TextBox();
            this.grpCenter.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAttrValue
            // 
            this.txtAttrValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttrValue.Location = new System.Drawing.Point(114, 86);
            this.txtAttrValue.MaxLength = 1000;
            this.txtAttrValue.Multiline = true;
            this.txtAttrValue.Name = "txtAttrValue";
            this.txtAttrValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAttrValue.Size = new System.Drawing.Size(472, 164);
            this.txtAttrValue.TabIndex = 9;
            this.txtAttrValue.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(498, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtAttrType
            // 
            this.txtAttrType.Location = new System.Drawing.Point(460, 13);
            this.txtAttrType.MaxLength = 20;
            this.txtAttrType.Name = "txtAttrType";
            this.txtAttrType.ReadOnly = true;
            this.txtAttrType.Size = new System.Drawing.Size(126, 20);
            this.txtAttrType.TabIndex = 3;
            this.txtAttrType.TabStop = false;
            // 
            // txtAttrName
            // 
            this.txtAttrName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttrName.Location = new System.Drawing.Point(114, 38);
            this.txtAttrName.MaxLength = 100;
            this.txtAttrName.Name = "txtAttrName";
            this.txtAttrName.ReadOnly = true;
            this.txtAttrName.Size = new System.Drawing.Size(472, 20);
            this.txtAttrName.TabIndex = 5;
            this.txtAttrName.TabStop = false;
            // 
            // txtAttrKey
            // 
            this.txtAttrKey.Location = new System.Drawing.Point(114, 13);
            this.txtAttrKey.MaxLength = 100;
            this.txtAttrKey.Name = "txtAttrKey";
            this.txtAttrKey.ReadOnly = true;
            this.txtAttrKey.Size = new System.Drawing.Size(126, 20);
            this.txtAttrKey.TabIndex = 1;
            this.txtAttrKey.TabStop = false;
            // 
            // grpCenter
            // 
            this.grpCenter.Controls.Add(this.lblAttrDesc);
            this.grpCenter.Controls.Add(this.txtAttrDesc);
            this.grpCenter.Controls.Add(this.lblAttrValue);
            this.grpCenter.Controls.Add(this.lblAttrType);
            this.grpCenter.Controls.Add(this.lblAttrName);
            this.grpCenter.Controls.Add(this.lblAttrKey);
            this.grpCenter.Controls.Add(this.txtAttrValue);
            this.grpCenter.Controls.Add(this.txtAttrType);
            this.grpCenter.Controls.Add(this.txtAttrName);
            this.grpCenter.Controls.Add(this.txtAttrKey);
            this.grpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCenter.Location = new System.Drawing.Point(0, 0);
            this.grpCenter.Name = "grpCenter";
            this.grpCenter.Size = new System.Drawing.Size(592, 256);
            this.grpCenter.TabIndex = 0;
            this.grpCenter.TabStop = false;
            // 
            // lblAttrValue
            // 
            this.lblAttrValue.AutoSize = true;
            this.lblAttrValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrValue.Location = new System.Drawing.Point(9, 89);
            this.lblAttrValue.Name = "lblAttrValue";
            this.lblAttrValue.Size = new System.Drawing.Size(76, 13);
            this.lblAttrValue.TabIndex = 8;
            this.lblAttrValue.Text = "Attribute Value";
            // 
            // lblAttrType
            // 
            this.lblAttrType.AutoSize = true;
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrType.Location = new System.Drawing.Point(334, 16);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(73, 13);
            this.lblAttrType.TabIndex = 2;
            this.lblAttrType.Text = "Attribute Type";
            // 
            // lblAttrName
            // 
            this.lblAttrName.AutoSize = true;
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrName.Location = new System.Drawing.Point(9, 41);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(77, 13);
            this.lblAttrName.TabIndex = 4;
            this.lblAttrName.Text = "Attribute Name";
            // 
            // lblAttrKey
            // 
            this.lblAttrKey.AutoSize = true;
            this.lblAttrKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrKey.Location = new System.Drawing.Point(9, 16);
            this.lblAttrKey.Name = "lblAttrKey";
            this.lblAttrKey.Size = new System.Drawing.Size(67, 13);
            this.lblAttrKey.TabIndex = 0;
            this.lblAttrKey.Text = "Attribute Key";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnProcess);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 256);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(592, 37);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProcess.Location = new System.Drawing.Point(406, 7);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(88, 26);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Input";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblAttrDesc
            // 
            this.lblAttrDesc.AutoSize = true;
            this.lblAttrDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrDesc.Location = new System.Drawing.Point(9, 65);
            this.lblAttrDesc.Name = "lblAttrDesc";
            this.lblAttrDesc.Size = new System.Drawing.Size(102, 13);
            this.lblAttrDesc.TabIndex = 6;
            this.lblAttrDesc.Text = "Attribute Description";
            // 
            // txtAttrDesc
            // 
            this.txtAttrDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttrDesc.Location = new System.Drawing.Point(114, 62);
            this.txtAttrDesc.MaxLength = 255;
            this.txtAttrDesc.Name = "txtAttrDesc";
            this.txtAttrDesc.ReadOnly = true;
            this.txtAttrDesc.Size = new System.Drawing.Size(472, 20);
            this.txtAttrDesc.TabIndex = 7;
            this.txtAttrDesc.TabStop = false;
            // 
            // frmBASTranAttributeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(592, 293);
            this.Controls.Add(this.grpCenter);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new System.Drawing.Size(600, 326);
            this.Name = "frmBASTranAttributeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input Detailed Value";
            this.Activated += new System.EventHandler(this.frmBASTranAttributeDetail_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBASTranAttributeDetail_FormClosed);
            this.Load += new System.EventHandler(this.frmBASTranAttributeDetail_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmBASTranAttributeDetail_KeyUp);
            this.grpCenter.ResumeLayout(false);
            this.grpCenter.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtAttrValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtAttrType;
        private System.Windows.Forms.TextBox txtAttrName;
        private System.Windows.Forms.TextBox txtAttrKey;
        private System.Windows.Forms.GroupBox grpCenter;
        private System.Windows.Forms.Label lblAttrValue;
        private System.Windows.Forms.Label lblAttrType;
        private System.Windows.Forms.Label lblAttrName;
        private System.Windows.Forms.Label lblAttrKey;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblAttrDesc;
        private System.Windows.Forms.TextBox txtAttrDesc;

    }
}