namespace CTMAgent
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.lbxStatus = new System.Windows.Forms.ListBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numSearchCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSearchCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.SteelBlue;
            this.btnStart.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStart.Location = new System.Drawing.Point(135, 258);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(119, 30);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbxStatus
            // 
            this.lbxStatus.FormattingEnabled = true;
            this.lbxStatus.HorizontalScrollbar = true;
            this.lbxStatus.ItemHeight = 15;
            this.lbxStatus.Location = new System.Drawing.Point(3, 66);
            this.lbxStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbxStatus.Name = "lbxStatus";
            this.lbxStatus.Size = new System.Drawing.Size(317, 184);
            this.lbxStatus.TabIndex = 7;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(260, 258);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(60, 30);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(3, 258);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(60, 30);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(69, 258);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 30);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Interval(SEC)";
            // 
            // numInterval
            // 
            this.numInterval.Enabled = false;
            this.numInterval.Location = new System.Drawing.Point(119, 7);
            this.numInterval.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(201, 25);
            this.numInterval.TabIndex = 18;
            this.numInterval.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numSearchCount
            // 
            this.numSearchCount.Enabled = false;
            this.numSearchCount.Location = new System.Drawing.Point(119, 38);
            this.numSearchCount.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numSearchCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSearchCount.Name = "numSearchCount";
            this.numSearchCount.Size = new System.Drawing.Size(201, 25);
            this.numSearchCount.TabIndex = 20;
            this.numSearchCount.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "SearchCount";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(325, 293);
            this.Controls.Add(this.numSearchCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lbxStatus);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CTM V1.0.0.1";
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSearchCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lbxStatus;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numSearchCount;
        private System.Windows.Forms.Label label2;
    }
}

