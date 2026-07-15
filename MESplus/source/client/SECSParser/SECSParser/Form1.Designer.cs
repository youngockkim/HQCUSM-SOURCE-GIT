namespace SECSParser
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.fileProgressBar = new System.Windows.Forms.ProgressBar();
            this.counterLabel = new System.Windows.Forms.Label();
            this.totalProgressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxSmg1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBoxHmg1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.processButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton19 = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // fileProgressBar
            // 
            this.fileProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileProgressBar.Location = new System.Drawing.Point(3, 3);
            this.fileProgressBar.Name = "fileProgressBar";
            this.fileProgressBar.Size = new System.Drawing.Size(1380, 40);
            this.fileProgressBar.TabIndex = 16;
            // 
            // counterLabel
            // 
            this.counterLabel.AutoSize = true;
            this.counterLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.counterLabel.Location = new System.Drawing.Point(0, 0);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(11, 12);
            this.counterLabel.TabIndex = 5;
            this.counterLabel.Text = "0";
            // 
            // totalProgressBar
            // 
            this.totalProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalProgressBar.Location = new System.Drawing.Point(3, 49);
            this.totalProgressBar.Name = "totalProgressBar";
            this.totalProgressBar.Size = new System.Drawing.Size(1380, 2);
            this.totalProgressBar.Step = 1;
            this.totalProgressBar.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1380, 49);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1372, 23);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preset";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.radioButton1);
            this.flowLayoutPanel2.Controls.Add(this.radioButton4);
            this.flowLayoutPanel2.Controls.Add(this.radioButton3);
            this.flowLayoutPanel2.Controls.Add(this.radioButton5);
            this.flowLayoutPanel2.Controls.Add(this.radioButton6);
            this.flowLayoutPanel2.Controls.Add(this.radioButton13);
            this.flowLayoutPanel2.Controls.Add(this.radioButton7);
            this.flowLayoutPanel2.Controls.Add(this.radioButton10);
            this.flowLayoutPanel2.Controls.Add(this.radioButton2);
            this.flowLayoutPanel2.Controls.Add(this.radioButton8);
            this.flowLayoutPanel2.Controls.Add(this.radioButton16);
            this.flowLayoutPanel2.Controls.Add(this.radioButton11);
            this.flowLayoutPanel2.Controls.Add(this.radioButton9);
            this.flowLayoutPanel2.Controls.Add(this.radioButton19);
            this.flowLayoutPanel2.Controls.Add(this.radioButton12);
            this.flowLayoutPanel2.Controls.Add(this.radioButton14);
            this.flowLayoutPanel2.Controls.Add(this.radioButton15);
            this.flowLayoutPanel2.Controls.Add(this.radioButton17);
            this.flowLayoutPanel2.Controls.Add(this.radioButton18);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1366, 17);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(84, 16);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "CLEAVING";
            this.radioButton1.Text = "CLEAVING";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(93, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(75, 16);
            this.radioButton4.TabIndex = 14;
            this.radioButton4.Tag = "HCLMOV";
            this.radioButton4.Text = "HCLMOV";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(174, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 16);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Tag = "SUALAB";
            this.radioButton3.Text = "SUALAB";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(250, 3);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(90, 16);
            this.radioButton5.TabIndex = 15;
            this.radioButton5.Tag = "INS_ERROR";
            this.radioButton5.Text = "INS_ERROR";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(346, 3);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(130, 16);
            this.radioButton6.TabIndex = 16;
            this.radioButton6.Tag = "SKIP_INSPECTION";
            this.radioButton6.Text = "SKIP_INSPECTION";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(482, 3);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(71, 16);
            this.radioButton13.TabIndex = 23;
            this.radioButton13.Tag = "TABBER";
            this.radioButton13.Text = "TABBER";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(559, 3);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(47, 16);
            this.radioButton7.TabIndex = 17;
            this.radioButton7.Tag = "LOT";
            this.radioButton7.Text = "LOT";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(612, 3);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(43, 16);
            this.radioButton10.TabIndex = 20;
            this.radioButton10.Tag = "AOI";
            this.radioButton10.Text = "AOI";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(661, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(45, 16);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Tag = "SIM";
            this.radioButton2.Text = "SIM";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(712, 3);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(48, 16);
            this.radioButton8.TabIndex = 18;
            this.radioButton8.Tag = "GRT";
            this.radioButton8.Text = "GRT";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(766, 3);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(102, 16);
            this.radioButton16.TabIndex = 26;
            this.radioButton16.Tag = "GRT_UPDATE";
            this.radioButton16.Text = "GRT_UPDATE";
            this.radioButton16.UseVisualStyleBackColor = true;
            this.radioButton16.CheckedChanged += new System.EventHandler(this.radioButton16_CheckedChanged);
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(874, 3);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(47, 16);
            this.radioButton11.TabIndex = 21;
            this.radioButton11.Tag = "HVT";
            this.radioButton11.Text = "HVT";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(927, 3);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(48, 16);
            this.radioButton9.TabIndex = 19;
            this.radioButton9.Tag = "FQC";
            this.radioButton9.Text = "FQC";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(1032, 3);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(46, 16);
            this.radioButton12.TabIndex = 22;
            this.radioButton12.Tag = "BEL";
            this.radioButton12.Text = "BEL";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(1084, 3);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(87, 16);
            this.radioButton14.TabIndex = 24;
            this.radioButton14.Tag = "MAGAZINE";
            this.radioButton14.Text = "MAGAZINE";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(1177, 3);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(71, 16);
            this.radioButton15.TabIndex = 25;
            this.radioButton15.Tag = "DEFECT";
            this.radioButton15.Text = "DEFECT";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.Location = new System.Drawing.Point(1254, 3);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(48, 16);
            this.radioButton17.TabIndex = 27;
            this.radioButton17.Tag = "GRT";
            this.radioButton17.Text = "GRT";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton18
            // 
            this.radioButton18.AutoSize = true;
            this.radioButton18.Location = new System.Drawing.Point(1308, 3);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Size = new System.Drawing.Size(48, 16);
            this.radioButton18.TabIndex = 28;
            this.radioButton18.Tag = "GRT";
            this.radioButton18.Text = "GRT";
            this.radioButton18.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxSmg1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1371, 24);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SMG";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxSmg1
            // 
            this.comboBoxSmg1.FormattingEnabled = true;
            this.comboBoxSmg1.Location = new System.Drawing.Point(7, 4);
            this.comboBoxSmg1.Name = "comboBoxSmg1";
            this.comboBoxSmg1.Size = new System.Drawing.Size(566, 20);
            this.comboBoxSmg1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBoxHmg1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1371, 24);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "HMG";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBoxHmg1
            // 
            this.comboBoxHmg1.FormattingEnabled = true;
            this.comboBoxHmg1.Location = new System.Drawing.Point(6, 3);
            this.comboBoxHmg1.Name = "comboBoxHmg1";
            this.comboBoxHmg1.Size = new System.Drawing.Size(488, 20);
            this.comboBoxHmg1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.totalProgressBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fileProgressBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1386, 439);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 158);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.inputTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.resultTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(1380, 278);
            this.splitContainer1.SplitterDistance = 654;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 17;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTextBox.Location = new System.Drawing.Point(0, 0);
            this.inputTextBox.MaxLength = 0;
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(654, 278);
            this.inputTextBox.TabIndex = 0;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTextBox.Location = new System.Drawing.Point(0, 0);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(721, 278);
            this.resultTextBox.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 57);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.counterLabel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.processButton);
            this.splitContainer2.Size = new System.Drawing.Size(1380, 40);
            this.splitContainer2.SplitterDistance = 657;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 18;
            // 
            // processButton
            // 
            this.processButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.processButton.Location = new System.Drawing.Point(631, 0);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(87, 40);
            this.processButton.TabIndex = 0;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.button_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 439);
            this.panel1.TabIndex = 7;
            // 
            // radioButton19
            // 
            this.radioButton19.AutoSize = true;
            this.radioButton19.Location = new System.Drawing.Point(981, 3);
            this.radioButton19.Name = "radioButton19";
            this.radioButton19.Size = new System.Drawing.Size(45, 16);
            this.radioButton19.TabIndex = 29;
            this.radioButton19.Tag = "FEL";
            this.radioButton19.Text = "FEL";
            this.radioButton19.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 439);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar fileProgressBar;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.ProgressBar totalProgressBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxSmg1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboBoxHmg1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.RadioButton radioButton17;
        private System.Windows.Forms.RadioButton radioButton18;
        private System.Windows.Forms.RadioButton radioButton19;
    }
}

