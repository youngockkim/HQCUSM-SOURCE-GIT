namespace Miracom.BASCore
{
    partial class frmBASAttributeHistoryDetail
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
            this.txtTranTime = new System.Windows.Forms.TextBox();
            this.txtHistorySeq = new System.Windows.Forms.TextBox();
            this.txtOldAttrValue = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtAttrType = new System.Windows.Forms.TextBox();
            this.txtAttrName = new System.Windows.Forms.TextBox();
            this.txtAttrKey = new System.Windows.Forms.TextBox();
            this.lblTranTime = new System.Windows.Forms.Label();
            this.lblKeyHistSeq = new System.Windows.Forms.Label();
            this.grpCenter = new System.Windows.Forms.GroupBox();
            this.lblAttrValue = new System.Windows.Forms.Label();
            this.txtAttrValue = new System.Windows.Forms.TextBox();
            this.lblOldAttrValue = new System.Windows.Forms.Label();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.lblAttrKey = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.grpCenter.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTranTime
            // 
            this.txtTranTime.Location = new System.Drawing.Point(537, 35);
            this.txtTranTime.MaxLength = 20;
            this.txtTranTime.Name = "txtTranTime";
            this.txtTranTime.ReadOnly = true;
            this.txtTranTime.Size = new System.Drawing.Size(146, 20);
            this.txtTranTime.TabIndex = 7;
            this.txtTranTime.TabStop = false;
            // 
            // txtHistorySeq
            // 
            this.txtHistorySeq.Location = new System.Drawing.Point(133, 35);
            this.txtHistorySeq.MaxLength = 20;
            this.txtHistorySeq.Name = "txtHistorySeq";
            this.txtHistorySeq.ReadOnly = true;
            this.txtHistorySeq.Size = new System.Drawing.Size(146, 20);
            this.txtHistorySeq.TabIndex = 5;
            this.txtHistorySeq.TabStop = false;
            // 
            // txtOldAttrValue
            // 
            this.txtOldAttrValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldAttrValue.Location = new System.Drawing.Point(133, 81);
            this.txtOldAttrValue.MaxLength = 1000;
            this.txtOldAttrValue.Multiline = true;
            this.txtOldAttrValue.Name = "txtOldAttrValue";
            this.txtOldAttrValue.ReadOnly = true;
            this.txtOldAttrValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOldAttrValue.Size = new System.Drawing.Size(550, 166);
            this.txtOldAttrValue.TabIndex = 11;
            this.txtOldAttrValue.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(581, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtAttrType
            // 
            this.txtAttrType.Location = new System.Drawing.Point(537, 12);
            this.txtAttrType.MaxLength = 20;
            this.txtAttrType.Name = "txtAttrType";
            this.txtAttrType.ReadOnly = true;
            this.txtAttrType.Size = new System.Drawing.Size(146, 20);
            this.txtAttrType.TabIndex = 3;
            this.txtAttrType.TabStop = false;
            // 
            // txtAttrName
            // 
            this.txtAttrName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttrName.Location = new System.Drawing.Point(133, 58);
            this.txtAttrName.MaxLength = 100;
            this.txtAttrName.Name = "txtAttrName";
            this.txtAttrName.ReadOnly = true;
            this.txtAttrName.Size = new System.Drawing.Size(550, 20);
            this.txtAttrName.TabIndex = 9;
            this.txtAttrName.TabStop = false;
            // 
            // txtAttrKey
            // 
            this.txtAttrKey.Location = new System.Drawing.Point(133, 12);
            this.txtAttrKey.MaxLength = 100;
            this.txtAttrKey.Name = "txtAttrKey";
            this.txtAttrKey.ReadOnly = true;
            this.txtAttrKey.Size = new System.Drawing.Size(146, 20);
            this.txtAttrKey.TabIndex = 1;
            this.txtAttrKey.TabStop = false;
            // 
            // lblTranTime
            // 
            this.lblTranTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTranTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTranTime.Location = new System.Drawing.Point(390, 38);
            this.lblTranTime.Name = "lblTranTime";
            this.lblTranTime.Size = new System.Drawing.Size(140, 14);
            this.lblTranTime.TabIndex = 6;
            this.lblTranTime.Text = "Transaction Time";
            // 
            // lblKeyHistSeq
            // 
            this.lblKeyHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKeyHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKeyHistSeq.Location = new System.Drawing.Point(10, 38);
            this.lblKeyHistSeq.Name = "lblKeyHistSeq";
            this.lblKeyHistSeq.Size = new System.Drawing.Size(115, 14);
            this.lblKeyHistSeq.TabIndex = 4;
            this.lblKeyHistSeq.Text = "History Seq";
            // 
            // grpCenter
            // 
            this.grpCenter.Controls.Add(this.lblAttrValue);
            this.grpCenter.Controls.Add(this.txtAttrValue);
            this.grpCenter.Controls.Add(this.lblTranTime);
            this.grpCenter.Controls.Add(this.lblKeyHistSeq);
            this.grpCenter.Controls.Add(this.lblOldAttrValue);
            this.grpCenter.Controls.Add(this.lblAttrType);
            this.grpCenter.Controls.Add(this.lblAttrName);
            this.grpCenter.Controls.Add(this.lblAttrKey);
            this.grpCenter.Controls.Add(this.txtTranTime);
            this.grpCenter.Controls.Add(this.txtHistorySeq);
            this.grpCenter.Controls.Add(this.txtOldAttrValue);
            this.grpCenter.Controls.Add(this.txtAttrType);
            this.grpCenter.Controls.Add(this.txtAttrName);
            this.grpCenter.Controls.Add(this.txtAttrKey);
            this.grpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCenter.Location = new System.Drawing.Point(0, 0);
            this.grpCenter.Name = "grpCenter";
            this.grpCenter.Size = new System.Drawing.Size(691, 430);
            this.grpCenter.TabIndex = 0;
            this.grpCenter.TabStop = false;
            // 
            // lblAttrValue
            // 
            this.lblAttrValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrValue.Location = new System.Drawing.Point(10, 255);
            this.lblAttrValue.Name = "lblAttrValue";
            this.lblAttrValue.Size = new System.Drawing.Size(115, 14);
            this.lblAttrValue.TabIndex = 12;
            this.lblAttrValue.Text = "New Attribute Value";
            // 
            // txtAttrValue
            // 
            this.txtAttrValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttrValue.Location = new System.Drawing.Point(133, 252);
            this.txtAttrValue.MaxLength = 1000;
            this.txtAttrValue.Multiline = true;
            this.txtAttrValue.Name = "txtAttrValue";
            this.txtAttrValue.ReadOnly = true;
            this.txtAttrValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAttrValue.Size = new System.Drawing.Size(550, 172);
            this.txtAttrValue.TabIndex = 13;
            this.txtAttrValue.TabStop = false;
            // 
            // lblOldAttrValue
            // 
            this.lblOldAttrValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOldAttrValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldAttrValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOldAttrValue.Location = new System.Drawing.Point(10, 84);
            this.lblOldAttrValue.Name = "lblOldAttrValue";
            this.lblOldAttrValue.Size = new System.Drawing.Size(115, 14);
            this.lblOldAttrValue.TabIndex = 10;
            this.lblOldAttrValue.Text = "Old Attribute Value";
            // 
            // lblAttrType
            // 
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrType.Location = new System.Drawing.Point(390, 15);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(140, 14);
            this.lblAttrType.TabIndex = 2;
            this.lblAttrType.Text = "Attribute Type";
            // 
            // lblAttrName
            // 
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrName.Location = new System.Drawing.Point(10, 61);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(115, 14);
            this.lblAttrName.TabIndex = 8;
            this.lblAttrName.Text = "Attribute Name";
            // 
            // lblAttrKey
            // 
            this.lblAttrKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrKey.Location = new System.Drawing.Point(10, 15);
            this.lblAttrKey.Name = "lblAttrKey";
            this.lblAttrKey.Size = new System.Drawing.Size(115, 14);
            this.lblAttrKey.TabIndex = 0;
            this.lblAttrKey.Text = "Attribute Key";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 430);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(691, 34);
            this.pnlBottom.TabIndex = 1;
            // 
            // frmBASAttributeHistoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 464);
            this.Controls.Add(this.grpCenter);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new System.Drawing.Size(699, 491);
            this.Name = "frmBASAttributeHistoryDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Attribute Detail History";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAttributeHistoryDetail_FormClosed);
            this.Activated += new System.EventHandler(this.frmAttributeHistoryDetail_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmAttributeHistoryDetail_KeyUp);
            this.Load += new System.EventHandler(this.frmAttributeHistoryDetail_Load);
            this.grpCenter.ResumeLayout(false);
            this.grpCenter.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTranTime;
        private System.Windows.Forms.TextBox txtHistorySeq;
        private System.Windows.Forms.TextBox txtOldAttrValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtAttrType;
        private System.Windows.Forms.TextBox txtAttrName;
        private System.Windows.Forms.TextBox txtAttrKey;
        private System.Windows.Forms.Label lblTranTime;
        private System.Windows.Forms.Label lblKeyHistSeq;
        private System.Windows.Forms.GroupBox grpCenter;
        private System.Windows.Forms.Label lblOldAttrValue;
        private System.Windows.Forms.Label lblAttrType;
        private System.Windows.Forms.Label lblAttrName;
        private System.Windows.Forms.Label lblAttrKey;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblAttrValue;
        private System.Windows.Forms.TextBox txtAttrValue;
    }
}