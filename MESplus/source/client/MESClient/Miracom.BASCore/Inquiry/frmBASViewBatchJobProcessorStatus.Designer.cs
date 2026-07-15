namespace Miracom.BASCore
{
    partial class frmBASViewBatchJobProcessorStatus
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
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtBatPrc = new System.Windows.Forms.TextBox();
            this.lblBatPrc = new System.Windows.Forms.Label();
            this.pnlRightBottom = new System.Windows.Forms.Panel();
            this.grpDateTime = new System.Windows.Forms.GroupBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.txtProcKey5 = new System.Windows.Forms.TextBox();
            this.txtProcKey4 = new System.Windows.Forms.TextBox();
            this.txtProcKey3 = new System.Windows.Forms.TextBox();
            this.txtProcKey2 = new System.Windows.Forms.TextBox();
            this.txtProcKey1 = new System.Windows.Forms.TextBox();
            this.lblProcKey = new System.Windows.Forms.Label();
            this.txtDBErrorMsg = new System.Windows.Forms.TextBox();
            this.lblDBErrorMsg = new System.Windows.Forms.Label();
            this.txtErrorMsg = new System.Windows.Forms.TextBox();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.txtLastHistSeq = new System.Windows.Forms.TextBox();
            this.lblLastHistSeq = new System.Windows.Forms.Label();
            this.txtLastSubNo = new System.Windows.Forms.TextBox();
            this.lblLastSubNo = new System.Windows.Forms.Label();
            this.txtElapsedTime = new System.Windows.Forms.TextBox();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtJobStatus = new System.Windows.Forms.TextBox();
            this.lblJobStatus = new System.Windows.Forms.Label();
            this.lisBatPrc = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grbTable.SuspendLayout();
            this.pnlRightBottom.SuspendLayout();
            this.grpDateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlRightBottom);
            this.pnlRight.Controls.Add(this.grbTable);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisBatPrc);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Text = "History";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // grbTable
            // 
            this.grbTable.Controls.Add(this.txtDesc);
            this.grbTable.Controls.Add(this.lblDesc);
            this.grbTable.Controls.Add(this.txtBatPrc);
            this.grbTable.Controls.Add(this.lblBatPrc);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbTable.Location = new System.Drawing.Point(0, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(506, 71);
            this.grbTable.TabIndex = 1;
            this.grbTable.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(347, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBatPrc
            // 
            this.txtBatPrc.Location = new System.Drawing.Point(120, 16);
            this.txtBatPrc.MaxLength = 30;
            this.txtBatPrc.Name = "txtBatPrc";
            this.txtBatPrc.Size = new System.Drawing.Size(200, 20);
            this.txtBatPrc.TabIndex = 1;
            // 
            // lblBatPrc
            // 
            this.lblBatPrc.AutoSize = true;
            this.lblBatPrc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatPrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatPrc.Location = new System.Drawing.Point(15, 19);
            this.lblBatPrc.Name = "lblBatPrc";
            this.lblBatPrc.Size = new System.Drawing.Size(87, 13);
            this.lblBatPrc.TabIndex = 0;
            this.lblBatPrc.Text = "Job Processor";
            this.lblBatPrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRightBottom
            // 
            this.pnlRightBottom.Controls.Add(this.grpDateTime);
            this.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightBottom.Location = new System.Drawing.Point(0, 71);
            this.pnlRightBottom.Name = "pnlRightBottom";
            this.pnlRightBottom.Size = new System.Drawing.Size(506, 435);
            this.pnlRightBottom.TabIndex = 2;
            // 
            // grpDateTime
            // 
            this.grpDateTime.Controls.Add(this.txtEndTime);
            this.grpDateTime.Controls.Add(this.lblEndTime);
            this.grpDateTime.Controls.Add(this.txtProcKey5);
            this.grpDateTime.Controls.Add(this.txtProcKey4);
            this.grpDateTime.Controls.Add(this.txtProcKey3);
            this.grpDateTime.Controls.Add(this.txtProcKey2);
            this.grpDateTime.Controls.Add(this.txtProcKey1);
            this.grpDateTime.Controls.Add(this.lblProcKey);
            this.grpDateTime.Controls.Add(this.txtDBErrorMsg);
            this.grpDateTime.Controls.Add(this.lblDBErrorMsg);
            this.grpDateTime.Controls.Add(this.txtErrorMsg);
            this.grpDateTime.Controls.Add(this.lblErrorMsg);
            this.grpDateTime.Controls.Add(this.txtLastHistSeq);
            this.grpDateTime.Controls.Add(this.lblLastHistSeq);
            this.grpDateTime.Controls.Add(this.txtLastSubNo);
            this.grpDateTime.Controls.Add(this.lblLastSubNo);
            this.grpDateTime.Controls.Add(this.txtElapsedTime);
            this.grpDateTime.Controls.Add(this.lblElapsedTime);
            this.grpDateTime.Controls.Add(this.txtStartTime);
            this.grpDateTime.Controls.Add(this.lblStartTime);
            this.grpDateTime.Controls.Add(this.txtJobStatus);
            this.grpDateTime.Controls.Add(this.lblJobStatus);
            this.grpDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDateTime.Location = new System.Drawing.Point(0, 0);
            this.grpDateTime.Name = "grpDateTime";
            this.grpDateTime.Size = new System.Drawing.Size(506, 435);
            this.grpDateTime.TabIndex = 0;
            this.grpDateTime.TabStop = false;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(113, 67);
            this.txtEndTime.MaxLength = 20;
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(177, 20);
            this.txtEndTime.TabIndex = 5;
            this.txtEndTime.TabStop = false;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndTime.Location = new System.Drawing.Point(8, 70);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 13);
            this.lblEndTime.TabIndex = 4;
            this.lblEndTime.Text = "End Time";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProcKey5
            // 
            this.txtProcKey5.Location = new System.Drawing.Point(113, 307);
            this.txtProcKey5.MaxLength = 100;
            this.txtProcKey5.Name = "txtProcKey5";
            this.txtProcKey5.ReadOnly = true;
            this.txtProcKey5.Size = new System.Drawing.Size(177, 20);
            this.txtProcKey5.TabIndex = 21;
            this.txtProcKey5.TabStop = false;
            // 
            // txtProcKey4
            // 
            this.txtProcKey4.Location = new System.Drawing.Point(113, 283);
            this.txtProcKey4.MaxLength = 100;
            this.txtProcKey4.Name = "txtProcKey4";
            this.txtProcKey4.ReadOnly = true;
            this.txtProcKey4.Size = new System.Drawing.Size(177, 20);
            this.txtProcKey4.TabIndex = 20;
            this.txtProcKey4.TabStop = false;
            // 
            // txtProcKey3
            // 
            this.txtProcKey3.Location = new System.Drawing.Point(113, 259);
            this.txtProcKey3.MaxLength = 100;
            this.txtProcKey3.Name = "txtProcKey3";
            this.txtProcKey3.ReadOnly = true;
            this.txtProcKey3.Size = new System.Drawing.Size(177, 20);
            this.txtProcKey3.TabIndex = 19;
            this.txtProcKey3.TabStop = false;
            // 
            // txtProcKey2
            // 
            this.txtProcKey2.Location = new System.Drawing.Point(113, 235);
            this.txtProcKey2.MaxLength = 100;
            this.txtProcKey2.Name = "txtProcKey2";
            this.txtProcKey2.ReadOnly = true;
            this.txtProcKey2.Size = new System.Drawing.Size(177, 20);
            this.txtProcKey2.TabIndex = 18;
            this.txtProcKey2.TabStop = false;
            // 
            // txtProcKey1
            // 
            this.txtProcKey1.Location = new System.Drawing.Point(113, 211);
            this.txtProcKey1.MaxLength = 100;
            this.txtProcKey1.Name = "txtProcKey1";
            this.txtProcKey1.ReadOnly = true;
            this.txtProcKey1.Size = new System.Drawing.Size(177, 20);
            this.txtProcKey1.TabIndex = 17;
            this.txtProcKey1.TabStop = false;
            // 
            // lblProcKey
            // 
            this.lblProcKey.AutoSize = true;
            this.lblProcKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcKey.Location = new System.Drawing.Point(8, 214);
            this.lblProcKey.Name = "lblProcKey";
            this.lblProcKey.Size = new System.Drawing.Size(94, 13);
            this.lblProcKey.TabIndex = 16;
            this.lblProcKey.Text = "Process Key 1 ~ 5";
            this.lblProcKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDBErrorMsg
            // 
            this.txtDBErrorMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBErrorMsg.Location = new System.Drawing.Point(113, 187);
            this.txtDBErrorMsg.MaxLength = 200;
            this.txtDBErrorMsg.Name = "txtDBErrorMsg";
            this.txtDBErrorMsg.ReadOnly = true;
            this.txtDBErrorMsg.Size = new System.Drawing.Size(354, 20);
            this.txtDBErrorMsg.TabIndex = 15;
            this.txtDBErrorMsg.TabStop = false;
            // 
            // lblDBErrorMsg
            // 
            this.lblDBErrorMsg.AutoSize = true;
            this.lblDBErrorMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDBErrorMsg.Location = new System.Drawing.Point(8, 190);
            this.lblDBErrorMsg.Name = "lblDBErrorMsg";
            this.lblDBErrorMsg.Size = new System.Drawing.Size(93, 13);
            this.lblDBErrorMsg.TabIndex = 14;
            this.lblDBErrorMsg.Text = "DB Error Message";
            this.lblDBErrorMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtErrorMsg
            // 
            this.txtErrorMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorMsg.Location = new System.Drawing.Point(113, 163);
            this.txtErrorMsg.MaxLength = 200;
            this.txtErrorMsg.Name = "txtErrorMsg";
            this.txtErrorMsg.ReadOnly = true;
            this.txtErrorMsg.Size = new System.Drawing.Size(354, 20);
            this.txtErrorMsg.TabIndex = 13;
            this.txtErrorMsg.TabStop = false;
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblErrorMsg.Location = new System.Drawing.Point(8, 166);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(75, 13);
            this.lblErrorMsg.TabIndex = 12;
            this.lblErrorMsg.Text = "Error Message";
            this.lblErrorMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLastHistSeq
            // 
            this.txtLastHistSeq.Location = new System.Drawing.Point(113, 139);
            this.txtLastHistSeq.MaxLength = 20;
            this.txtLastHistSeq.Name = "txtLastHistSeq";
            this.txtLastHistSeq.ReadOnly = true;
            this.txtLastHistSeq.Size = new System.Drawing.Size(177, 20);
            this.txtLastHistSeq.TabIndex = 11;
            this.txtLastHistSeq.TabStop = false;
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.AutoSize = true;
            this.lblLastHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastHistSeq.Location = new System.Drawing.Point(8, 142);
            this.lblLastHistSeq.Name = "lblLastHistSeq";
            this.lblLastHistSeq.Size = new System.Drawing.Size(73, 13);
            this.lblLastHistSeq.TabIndex = 10;
            this.lblLastHistSeq.Text = "Last Hist Seq.";
            this.lblLastHistSeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLastSubNo
            // 
            this.txtLastSubNo.Location = new System.Drawing.Point(113, 115);
            this.txtLastSubNo.MaxLength = 20;
            this.txtLastSubNo.Name = "txtLastSubNo";
            this.txtLastSubNo.ReadOnly = true;
            this.txtLastSubNo.Size = new System.Drawing.Size(177, 20);
            this.txtLastSubNo.TabIndex = 9;
            this.txtLastSubNo.TabStop = false;
            // 
            // lblLastSubNo
            // 
            this.lblLastSubNo.AutoSize = true;
            this.lblLastSubNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastSubNo.Location = new System.Drawing.Point(8, 118);
            this.lblLastSubNo.Name = "lblLastSubNo";
            this.lblLastSubNo.Size = new System.Drawing.Size(69, 13);
            this.lblLastSubNo.TabIndex = 8;
            this.lblLastSubNo.Text = "Last Sub No.";
            this.lblLastSubNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtElapsedTime
            // 
            this.txtElapsedTime.Location = new System.Drawing.Point(113, 91);
            this.txtElapsedTime.MaxLength = 20;
            this.txtElapsedTime.Name = "txtElapsedTime";
            this.txtElapsedTime.ReadOnly = true;
            this.txtElapsedTime.Size = new System.Drawing.Size(177, 20);
            this.txtElapsedTime.TabIndex = 7;
            this.txtElapsedTime.TabStop = false;
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblElapsedTime.Location = new System.Drawing.Point(8, 94);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(71, 13);
            this.lblElapsedTime.TabIndex = 6;
            this.lblElapsedTime.Text = "Elapsed Time";
            this.lblElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(113, 43);
            this.txtStartTime.MaxLength = 20;
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(177, 20);
            this.txtStartTime.TabIndex = 3;
            this.txtStartTime.TabStop = false;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartTime.Location = new System.Drawing.Point(8, 46);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(55, 13);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "Start Time";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtJobStatus
            // 
            this.txtJobStatus.Location = new System.Drawing.Point(113, 19);
            this.txtJobStatus.MaxLength = 20;
            this.txtJobStatus.Name = "txtJobStatus";
            this.txtJobStatus.ReadOnly = true;
            this.txtJobStatus.Size = new System.Drawing.Size(177, 20);
            this.txtJobStatus.TabIndex = 1;
            this.txtJobStatus.TabStop = false;
            // 
            // lblJobStatus
            // 
            this.lblJobStatus.AutoSize = true;
            this.lblJobStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblJobStatus.Location = new System.Drawing.Point(8, 22);
            this.lblJobStatus.Name = "lblJobStatus";
            this.lblJobStatus.Size = new System.Drawing.Size(57, 13);
            this.lblJobStatus.TabIndex = 0;
            this.lblJobStatus.Text = "Job Status";
            this.lblJobStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisBatPrc
            // 
            this.lisBatPrc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisBatPrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisBatPrc.EnableSort = true;
            this.lisBatPrc.EnableSortIcon = true;
            this.lisBatPrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisBatPrc.FullRowSelect = true;
            this.lisBatPrc.HideSelection = false;
            this.lisBatPrc.Location = new System.Drawing.Point(0, 0);
            this.lisBatPrc.MultiSelect = false;
            this.lisBatPrc.Name = "lisBatPrc";
            this.lisBatPrc.Size = new System.Drawing.Size(232, 506);
            this.lisBatPrc.TabIndex = 1;
            this.lisBatPrc.UseCompatibleStateImageBehavior = false;
            this.lisBatPrc.View = System.Windows.Forms.View.Details;
            this.lisBatPrc.SelectedIndexChanged += new System.EventHandler(this.lisBatPrc_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Job Processor";
            this.ColumnHeader1.Width = 120;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 240;
            // 
            // frmBASViewBatchJobProcessorStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASViewBatchJobProcessorStatus";
            this.Text = "View Batch Job Processor Status";
            this.Activated += new System.EventHandler(this.frmBASViewBatchJobProcessorStatus_Activated);
            this.Load += new System.EventHandler(this.frmBASViewBatchJobProcessorStatus_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grbTable.ResumeLayout(false);
            this.grbTable.PerformLayout();
            this.pnlRightBottom.ResumeLayout(false);
            this.grpDateTime.ResumeLayout(false);
            this.grpDateTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTable;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtBatPrc;
        private System.Windows.Forms.Label lblBatPrc;
        private System.Windows.Forms.Panel pnlRightBottom;
        private UI.Controls.MCListView.MCListView lisBatPrc;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox grpDateTime;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.TextBox txtProcKey5;
        private System.Windows.Forms.TextBox txtProcKey4;
        private System.Windows.Forms.TextBox txtProcKey3;
        private System.Windows.Forms.TextBox txtProcKey2;
        private System.Windows.Forms.TextBox txtProcKey1;
        private System.Windows.Forms.Label lblProcKey;
        private System.Windows.Forms.TextBox txtDBErrorMsg;
        private System.Windows.Forms.Label lblDBErrorMsg;
        private System.Windows.Forms.TextBox txtErrorMsg;
        private System.Windows.Forms.Label lblErrorMsg;
        private System.Windows.Forms.TextBox txtLastHistSeq;
        private System.Windows.Forms.Label lblLastHistSeq;
        private System.Windows.Forms.TextBox txtLastSubNo;
        private System.Windows.Forms.Label lblLastSubNo;
        private System.Windows.Forms.TextBox txtElapsedTime;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtJobStatus;
        private System.Windows.Forms.Label lblJobStatus;
    }
}