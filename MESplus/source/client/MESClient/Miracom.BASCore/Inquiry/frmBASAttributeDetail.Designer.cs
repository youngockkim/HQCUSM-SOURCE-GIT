namespace Miracom.BASCore
{
    partial class frmBASAttributeDetail
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpCenter = new System.Windows.Forms.GroupBox();
            this.lblLastTranTime = new System.Windows.Forms.Label();
            this.lblLastHistSeq = new System.Windows.Forms.Label();
            this.lblLastActiveHistSeq = new System.Windows.Forms.Label();
            this.lblKeyHistSeq = new System.Windows.Forms.Label();
            this.lblAttrValue = new System.Windows.Forms.Label();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.lblAttrKey = new System.Windows.Forms.Label();
            this.txtLastTranTime = new System.Windows.Forms.TextBox();
            this.txtLastHistorySeq = new System.Windows.Forms.TextBox();
            this.txtLastActiveHistorySeq = new System.Windows.Forms.TextBox();
            this.txtHistorySeq = new System.Windows.Forms.TextBox();
            this.txtAttrValue = new System.Windows.Forms.TextBox();
            this.txtAttrType = new System.Windows.Forms.TextBox();
            this.txtAttrName = new System.Windows.Forms.TextBox();
            this.txtAttrKey = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpCenter.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCenter
            // 
            this.grpCenter.Controls.Add(this.lblLastTranTime);
            this.grpCenter.Controls.Add(this.lblLastHistSeq);
            this.grpCenter.Controls.Add(this.lblLastActiveHistSeq);
            this.grpCenter.Controls.Add(this.lblKeyHistSeq);
            this.grpCenter.Controls.Add(this.lblAttrValue);
            this.grpCenter.Controls.Add(this.lblAttrType);
            this.grpCenter.Controls.Add(this.lblAttrName);
            this.grpCenter.Controls.Add(this.lblAttrKey);
            this.grpCenter.Controls.Add(this.txtLastTranTime);
            this.grpCenter.Controls.Add(this.txtLastHistorySeq);
            this.grpCenter.Controls.Add(this.txtLastActiveHistorySeq);
            this.grpCenter.Controls.Add(this.txtHistorySeq);
            this.grpCenter.Controls.Add(this.txtAttrValue);
            this.grpCenter.Controls.Add(this.txtAttrType);
            this.grpCenter.Controls.Add(this.txtAttrName);
            this.grpCenter.Controls.Add(this.txtAttrKey);
            this.grpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCenter.Location = new System.Drawing.Point(0, 0);
            this.grpCenter.Name = "grpCenter";
            this.grpCenter.Size = new System.Drawing.Size(592, 262);
            this.grpCenter.TabIndex = 0;
            this.grpCenter.TabStop = false;
            // 
            // lblLastTranTime
            // 
            this.lblLastTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLastTranTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastTranTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastTranTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastTranTime.Location = new System.Drawing.Point(334, 238);
            this.lblLastTranTime.Name = "lblLastTranTime";
            this.lblLastTranTime.Size = new System.Drawing.Size(120, 15);
            this.lblLastTranTime.TabIndex = 14;
            this.lblLastTranTime.Text = "Last Transaction Time";
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLastHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastHistSeq.Location = new System.Drawing.Point(9, 238);
            this.lblLastHistSeq.Name = "lblLastHistSeq";
            this.lblLastHistSeq.Size = new System.Drawing.Size(99, 15);
            this.lblLastHistSeq.TabIndex = 12;
            this.lblLastHistSeq.Text = "Last History Seq";
            // 
            // lblLastActiveHistSeq
            // 
            this.lblLastActiveHistSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLastActiveHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastActiveHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastActiveHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastActiveHistSeq.Location = new System.Drawing.Point(334, 213);
            this.lblLastActiveHistSeq.Name = "lblLastActiveHistSeq";
            this.lblLastActiveHistSeq.Size = new System.Drawing.Size(120, 15);
            this.lblLastActiveHistSeq.TabIndex = 10;
            this.lblLastActiveHistSeq.Text = "Last Active History Seq";
            // 
            // lblKeyHistSeq
            // 
            this.lblKeyHistSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKeyHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKeyHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKeyHistSeq.Location = new System.Drawing.Point(9, 213);
            this.lblKeyHistSeq.Name = "lblKeyHistSeq";
            this.lblKeyHistSeq.Size = new System.Drawing.Size(99, 15);
            this.lblKeyHistSeq.TabIndex = 8;
            this.lblKeyHistSeq.Text = "Key History Seq";
            // 
            // lblAttrValue
            // 
            this.lblAttrValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrValue.Location = new System.Drawing.Point(9, 66);
            this.lblAttrValue.Name = "lblAttrValue";
            this.lblAttrValue.Size = new System.Drawing.Size(99, 15);
            this.lblAttrValue.TabIndex = 6;
            this.lblAttrValue.Text = "Attribute Value";
            // 
            // lblAttrType
            // 
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrType.Location = new System.Drawing.Point(334, 16);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(120, 15);
            this.lblAttrType.TabIndex = 2;
            this.lblAttrType.Text = "Attribute Type";
            // 
            // lblAttrName
            // 
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrName.Location = new System.Drawing.Point(9, 41);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(99, 15);
            this.lblAttrName.TabIndex = 4;
            this.lblAttrName.Text = "Attribute Name";
            // 
            // lblAttrKey
            // 
            this.lblAttrKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrKey.Location = new System.Drawing.Point(9, 16);
            this.lblAttrKey.Name = "lblAttrKey";
            this.lblAttrKey.Size = new System.Drawing.Size(99, 15);
            this.lblAttrKey.TabIndex = 0;
            this.lblAttrKey.Text = "Attribute Key";
            // 
            // txtLastTranTime
            // 
            this.txtLastTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLastTranTime.Location = new System.Drawing.Point(460, 235);
            this.txtLastTranTime.MaxLength = 20;
            this.txtLastTranTime.Name = "txtLastTranTime";
            this.txtLastTranTime.ReadOnly = true;
            this.txtLastTranTime.Size = new System.Drawing.Size(126, 20);
            this.txtLastTranTime.TabIndex = 15;
            this.txtLastTranTime.TabStop = false;
            // 
            // txtLastHistorySeq
            // 
            this.txtLastHistorySeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLastHistorySeq.Location = new System.Drawing.Point(114, 235);
            this.txtLastHistorySeq.MaxLength = 20;
            this.txtLastHistorySeq.Name = "txtLastHistorySeq";
            this.txtLastHistorySeq.ReadOnly = true;
            this.txtLastHistorySeq.Size = new System.Drawing.Size(126, 20);
            this.txtLastHistorySeq.TabIndex = 13;
            this.txtLastHistorySeq.TabStop = false;
            // 
            // txtLastActiveHistorySeq
            // 
            this.txtLastActiveHistorySeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLastActiveHistorySeq.Location = new System.Drawing.Point(460, 210);
            this.txtLastActiveHistorySeq.MaxLength = 20;
            this.txtLastActiveHistorySeq.Name = "txtLastActiveHistorySeq";
            this.txtLastActiveHistorySeq.ReadOnly = true;
            this.txtLastActiveHistorySeq.Size = new System.Drawing.Size(126, 20);
            this.txtLastActiveHistorySeq.TabIndex = 11;
            this.txtLastActiveHistorySeq.TabStop = false;
            // 
            // txtHistorySeq
            // 
            this.txtHistorySeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHistorySeq.Location = new System.Drawing.Point(114, 210);
            this.txtHistorySeq.MaxLength = 20;
            this.txtHistorySeq.Name = "txtHistorySeq";
            this.txtHistorySeq.ReadOnly = true;
            this.txtHistorySeq.Size = new System.Drawing.Size(126, 20);
            this.txtHistorySeq.TabIndex = 9;
            this.txtHistorySeq.TabStop = false;
            // 
            // txtAttrValue
            // 
            this.txtAttrValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttrValue.Location = new System.Drawing.Point(114, 63);
            this.txtAttrValue.MaxLength = 1000;
            this.txtAttrValue.Multiline = true;
            this.txtAttrValue.Name = "txtAttrValue";
            this.txtAttrValue.ReadOnly = true;
            this.txtAttrValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAttrValue.Size = new System.Drawing.Size(472, 142);
            this.txtAttrValue.TabIndex = 7;
            this.txtAttrValue.TabStop = false;
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
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 262);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(592, 37);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(498, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmBASAttributeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(592, 299);
            this.Controls.Add(this.grpCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 326);
            this.Name = "frmBASAttributeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Attribute Detail Value";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAttributeDetail_FormClosed);
            this.Activated += new System.EventHandler(this.frmAttributeDetail_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmAttributeDetail_KeyUp);
            this.Load += new System.EventHandler(this.frmAttributeDetail_Load);
            this.grpCenter.ResumeLayout(false);
            this.grpCenter.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCenter;
        private System.Windows.Forms.Label lblLastTranTime;
        private System.Windows.Forms.Label lblLastHistSeq;
        private System.Windows.Forms.Label lblLastActiveHistSeq;
        private System.Windows.Forms.Label lblKeyHistSeq;
        private System.Windows.Forms.Label lblAttrValue;
        private System.Windows.Forms.Label lblAttrType;
        private System.Windows.Forms.Label lblAttrName;
        private System.Windows.Forms.Label lblAttrKey;
        private System.Windows.Forms.TextBox txtLastTranTime;
        private System.Windows.Forms.TextBox txtLastHistorySeq;
        private System.Windows.Forms.TextBox txtLastActiveHistorySeq;
        private System.Windows.Forms.TextBox txtHistorySeq;
        private System.Windows.Forms.TextBox txtAttrValue;
        private System.Windows.Forms.TextBox txtAttrType;
        private System.Windows.Forms.TextBox txtAttrName;
        private System.Windows.Forms.TextBox txtAttrKey;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnClose;
    }
}