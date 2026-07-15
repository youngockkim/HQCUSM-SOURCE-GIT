namespace Miracom.MESCore
{
    partial class frmConfirmTransactionAlarm
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
            this.txtMatID = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.txtMatVer = new System.Windows.Forms.TextBox();
            this.lblFlow = new System.Windows.Forms.Label();
            this.txtFlow = new System.Windows.Forms.TextBox();
            this.lblOper = new System.Windows.Forms.Label();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblHoldStatus = new System.Windows.Forms.Label();
            this.txtHoldStatus = new System.Windows.Forms.TextBox();
            this.lblHoldCode = new System.Windows.Forms.Label();
            this.txtHoldCode = new System.Windows.Forms.TextBox();
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.txtEventID = new System.Windows.Forms.TextBox();
            this.lblEventID = new System.Windows.Forms.Label();
            this.txtResID = new System.Windows.Forms.TextBox();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Visible = false;
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(742, 70);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.grpMessage);
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 70);
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 436);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.txtEventID);
            this.grpTranTop.Controls.Add(this.lblEventID);
            this.grpTranTop.Controls.Add(this.txtResID);
            this.grpTranTop.Controls.Add(this.lblResID);
            this.grpTranTop.Controls.Add(this.lblHoldStatus);
            this.grpTranTop.Controls.Add(this.txtHoldStatus);
            this.grpTranTop.Controls.Add(this.lblHoldCode);
            this.grpTranTop.Controls.Add(this.txtHoldCode);
            this.grpTranTop.Controls.Add(this.lblLotID);
            this.grpTranTop.Controls.Add(this.txtLotID);
            this.grpTranTop.Controls.Add(this.lblOper);
            this.grpTranTop.Controls.Add(this.txtOper);
            this.grpTranTop.Controls.Add(this.lblFlow);
            this.grpTranTop.Controls.Add(this.txtFlow);
            this.grpTranTop.Controls.Add(this.txtMatVer);
            this.grpTranTop.Controls.Add(this.lblMaterial);
            this.grpTranTop.Controls.Add(this.txtMatID);
            this.grpTranTop.Size = new System.Drawing.Size(736, 70);
            this.grpTranTop.Text = "Message Condition";
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Text = "Break";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm02";
            // 
            // txtMatID
            // 
            this.txtMatID.Location = new System.Drawing.Point(82, 16);
            this.txtMatID.Name = "txtMatID";
            this.txtMatID.ReadOnly = true;
            this.txtMatID.Size = new System.Drawing.Size(100, 20);
            this.txtMatID.TabIndex = 1;
            // 
            // lblMaterial
            // 
            this.lblMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaterial.Location = new System.Drawing.Point(11, 19);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(71, 13);
            this.lblMaterial.TabIndex = 0;
            this.lblMaterial.Text = "Material";
            // 
            // txtMatVer
            // 
            this.txtMatVer.Location = new System.Drawing.Point(185, 16);
            this.txtMatVer.Name = "txtMatVer";
            this.txtMatVer.ReadOnly = true;
            this.txtMatVer.Size = new System.Drawing.Size(25, 20);
            this.txtMatVer.TabIndex = 2;
            // 
            // lblFlow
            // 
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Location = new System.Drawing.Point(229, 19);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(56, 13);
            this.lblFlow.TabIndex = 3;
            this.lblFlow.Text = "Flow";
            // 
            // txtFlow
            // 
            this.txtFlow.Location = new System.Drawing.Point(286, 16);
            this.txtFlow.Name = "txtFlow";
            this.txtFlow.ReadOnly = true;
            this.txtFlow.Size = new System.Drawing.Size(100, 20);
            this.txtFlow.TabIndex = 4;
            // 
            // lblOper
            // 
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Location = new System.Drawing.Point(402, 19);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 5;
            this.lblOper.Text = "Operation";
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(457, 16);
            this.txtOper.Name = "txtOper";
            this.txtOper.ReadOnly = true;
            this.txtOper.Size = new System.Drawing.Size(100, 20);
            this.txtOper.TabIndex = 6;
            // 
            // lblLotID
            // 
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Location = new System.Drawing.Point(573, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(53, 13);
            this.lblLotID.TabIndex = 7;
            this.lblLotID.Text = "Lot ID";
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(628, 16);
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(100, 20);
            this.txtLotID.TabIndex = 8;
            // 
            // lblHoldStatus
            // 
            this.lblHoldStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldStatus.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHoldStatus.Location = new System.Drawing.Point(11, 44);
            this.lblHoldStatus.Name = "lblHoldStatus";
            this.lblHoldStatus.Size = new System.Drawing.Size(71, 13);
            this.lblHoldStatus.TabIndex = 9;
            this.lblHoldStatus.Text = "Hold Status";
            // 
            // txtHoldStatus
            // 
            this.txtHoldStatus.Location = new System.Drawing.Point(82, 41);
            this.txtHoldStatus.Name = "txtHoldStatus";
            this.txtHoldStatus.ReadOnly = true;
            this.txtHoldStatus.Size = new System.Drawing.Size(128, 20);
            this.txtHoldStatus.TabIndex = 10;
            // 
            // lblHoldCode
            // 
            this.lblHoldCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCode.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHoldCode.Location = new System.Drawing.Point(229, 44);
            this.lblHoldCode.Name = "lblHoldCode";
            this.lblHoldCode.Size = new System.Drawing.Size(56, 13);
            this.lblHoldCode.TabIndex = 11;
            this.lblHoldCode.Text = "Hold Code";
            // 
            // txtHoldCode
            // 
            this.txtHoldCode.Location = new System.Drawing.Point(286, 41);
            this.txtHoldCode.Name = "txtHoldCode";
            this.txtHoldCode.ReadOnly = true;
            this.txtHoldCode.Size = new System.Drawing.Size(100, 20);
            this.txtHoldCode.TabIndex = 12;
            // 
            // grpMessage
            // 
            this.grpMessage.Controls.Add(this.txtMessage);
            this.grpMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMessage.Location = new System.Drawing.Point(3, 3);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(736, 433);
            this.grpMessage.TabIndex = 0;
            this.grpMessage.TabStop = false;
            this.grpMessage.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.DetectUrls = false;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(3, 16);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(730, 414);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.Text = "";
            // 
            // txtEventID
            // 
            this.txtEventID.Location = new System.Drawing.Point(457, 41);
            this.txtEventID.Name = "txtEventID";
            this.txtEventID.ReadOnly = true;
            this.txtEventID.Size = new System.Drawing.Size(100, 20);
            this.txtEventID.TabIndex = 14;
            // 
            // lblEventID
            // 
            this.lblEventID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventID.Location = new System.Drawing.Point(402, 44);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(53, 13);
            this.lblEventID.TabIndex = 13;
            this.lblEventID.Text = "Event ID";
            // 
            // txtResID
            // 
            this.txtResID.Location = new System.Drawing.Point(628, 41);
            this.txtResID.Name = "txtResID";
            this.txtResID.ReadOnly = true;
            this.txtResID.Size = new System.Drawing.Size(100, 20);
            this.txtResID.TabIndex = 16;
            // 
            // lblResID
            // 
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Location = new System.Drawing.Point(573, 44);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(53, 13);
            this.lblResID.TabIndex = 15;
            this.lblResID.Text = "Resource ID";
            // 
            // frmConfirmTransactionAlarm
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmConfirmTransactionAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm Transaction Alarm Message";
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatVer;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.TextBox txtMatID;
        private System.Windows.Forms.Label lblOper;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.TextBox txtFlow;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblHoldStatus;
        private System.Windows.Forms.TextBox txtHoldStatus;
        private System.Windows.Forms.Label lblHoldCode;
        private System.Windows.Forms.TextBox txtHoldCode;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.TextBox txtEventID;
        private System.Windows.Forms.Label lblEventID;
        private System.Windows.Forms.TextBox txtResID;
        private System.Windows.Forms.Label lblResID;

    }
}
