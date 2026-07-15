namespace Miracom.UTLCore
{
    partial class frmUTLGenerateLotData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIgnoreError = new System.Windows.Forms.CheckBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.grpTestThread = new System.Windows.Forms.GroupBox();
            this.prgRunning = new System.Windows.Forms.ProgressBar();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.lblThreadCount = new System.Windows.Forms.Label();
            this.grpCreated = new System.Windows.Forms.GroupBox();
            this.lisLotList = new System.Windows.Forms.ListView();
            this.colThread = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStop = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpTestThread.SuspendLayout();
            this.grpCreated.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnStop);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnStop, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpCreated);
            this.pnlCenter.Controls.Add(this.groupBox1);
            this.pnlCenter.Controls.Add(this.grpTestThread);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIgnoreError);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Work Date";
            // 
            // chkIgnoreError
            // 
            this.chkIgnoreError.AutoSize = true;
            this.chkIgnoreError.Location = new System.Drawing.Point(602, 18);
            this.chkIgnoreError.Name = "chkIgnoreError";
            this.chkIgnoreError.Size = new System.Drawing.Size(81, 17);
            this.chkIgnoreError.TabIndex = 28;
            this.chkIgnoreError.Text = "Ignore Error";
            this.chkIgnoreError.UseVisualStyleBackColor = true;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(377, 16);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(120, 20);
            this.dtpEnd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End Date";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(130, 16);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(120, 20);
            this.dtpStart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date";
            // 
            // grpTestThread
            // 
            this.grpTestThread.Controls.Add(this.prgRunning);
            this.grpTestThread.Controls.Add(this.txtThreadCount);
            this.grpTestThread.Controls.Add(this.lblThreadCount);
            this.grpTestThread.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTestThread.Location = new System.Drawing.Point(0, 0);
            this.grpTestThread.Name = "grpTestThread";
            this.grpTestThread.Size = new System.Drawing.Size(742, 38);
            this.grpTestThread.TabIndex = 1;
            this.grpTestThread.TabStop = false;
            this.grpTestThread.Text = "Test Thread Information";
            // 
            // prgRunning
            // 
            this.prgRunning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgRunning.Enabled = false;
            this.prgRunning.Location = new System.Drawing.Point(207, 11);
            this.prgRunning.Name = "prgRunning";
            this.prgRunning.Size = new System.Drawing.Size(523, 22);
            this.prgRunning.Step = 20;
            this.prgRunning.TabIndex = 11;
            this.prgRunning.Visible = false;
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(130, 12);
            this.txtThreadCount.MaxLength = 5;
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(60, 20);
            this.txtThreadCount.TabIndex = 1;
            this.txtThreadCount.Text = "1";
            // 
            // lblThreadCount
            // 
            this.lblThreadCount.AutoSize = true;
            this.lblThreadCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreadCount.Location = new System.Drawing.Point(20, 16);
            this.lblThreadCount.Name = "lblThreadCount";
            this.lblThreadCount.Size = new System.Drawing.Size(84, 13);
            this.lblThreadCount.TabIndex = 0;
            this.lblThreadCount.Text = "Thread Count";
            // 
            // grpCreated
            // 
            this.grpCreated.Controls.Add(this.lisLotList);
            this.grpCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreated.Location = new System.Drawing.Point(0, 82);
            this.grpCreated.Name = "grpCreated";
            this.grpCreated.Size = new System.Drawing.Size(742, 424);
            this.grpCreated.TabIndex = 3;
            this.grpCreated.TabStop = false;
            this.grpCreated.Text = "Created Lot List";
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colThread,
            this.colLotID,
            this.colOper,
            this.colMatId});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.Location = new System.Drawing.Point(3, 16);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(736, 405);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            // 
            // colThread
            // 
            this.colThread.Text = "Thread";
            this.colThread.Width = 73;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 212;
            // 
            // colOper
            // 
            this.colOper.Text = "Operation";
            this.colOper.Width = 108;
            // 
            // colMatId
            // 
            this.colMatId.Text = "Mat ID";
            this.colMatId.Width = 234;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(409, 7);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(88, 26);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmUTLGenerateLotData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmUTLGenerateLotData";
            this.Text = "Generate Lot Data";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUTLGenerateLotData_FormClosed);
            this.Load += new System.EventHandler(this.frmUTLGenerateLotData_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpTestThread.ResumeLayout(false);
            this.grpTestThread.PerformLayout();
            this.grpCreated.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTestThread;
        private System.Windows.Forms.ProgressBar prgRunning;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.Label lblThreadCount;
        private System.Windows.Forms.GroupBox grpCreated;
        private System.Windows.Forms.ListView lisLotList;
        private System.Windows.Forms.ColumnHeader colThread;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colOper;
        private System.Windows.Forms.CheckBox chkIgnoreError;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ColumnHeader colMatId;
    }
}