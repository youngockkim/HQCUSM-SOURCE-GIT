namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSCalibrationUserSetup
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
            this.lisView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tabSampling = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.grbStandradEquip = new System.Windows.Forms.GroupBox();
            this.rdoUseFlagNo = new System.Windows.Forms.RadioButton();
            this.rdoUseFlagYes = new System.Windows.Forms.RadioButton();
            this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.btnFileName = new System.Windows.Forms.Button();
            this.cdvFileName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpMaterial.SuspendLayout();
            this.tabSampling.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.grbStandradEquip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFileName)).BeginInit();
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
            this.pnlRight.Controls.Add(this.tabSampling);
            this.pnlRight.Controls.Add(this.grpMaterial);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisView);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // lisView
            // 
            this.lisView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lisView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisView.FullRowSelect = true;
            this.lisView.Location = new System.Drawing.Point(0, 0);
            this.lisView.Name = "lisView";
            this.lisView.Size = new System.Drawing.Size(232, 506);
            this.lisView.TabIndex = 6;
            this.lisView.UseCompatibleStateImageBehavior = false;
            this.lisView.View = System.Windows.Forms.View.Details;
            this.lisView.SelectedIndexChanged += new System.EventHandler(this.lisView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Calibration User ID";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Calibration User Name";
            this.columnHeader2.Width = 130;
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.txtUserID);
            this.grpMaterial.Controls.Add(this.lblUserID);
            this.grpMaterial.Controls.Add(this.txtUserName);
            this.grpMaterial.Controls.Add(this.lblUserName);
            this.grpMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterial.Location = new System.Drawing.Point(0, 0);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Size = new System.Drawing.Size(506, 71);
            this.grpMaterial.TabIndex = 3;
            this.grpMaterial.TabStop = false;
            // 
            // txtUserID
            // 
            this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(135, 14);
            this.txtUserID.MaxLength = 50;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(173, 20);
            this.txtUserID.TabIndex = 5;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserID.Location = new System.Drawing.Point(16, 18);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(114, 13);
            this.lblUserID.TabIndex = 3;
            this.lblUserID.Text = "Calibration User ID";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(135, 40);
            this.txtUserName.MaxLength = 100;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(361, 20);
            this.txtUserName.TabIndex = 6;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(16, 43);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(112, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Calibration User Name";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabSampling
            // 
            this.tabSampling.Controls.Add(this.tbpGeneral);
            this.tabSampling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabSampling.ItemSize = new System.Drawing.Size(60, 18);
            this.tabSampling.Location = new System.Drawing.Point(0, 71);
            this.tabSampling.Name = "tabSampling";
            this.tabSampling.SelectedIndex = 0;
            this.tabSampling.Size = new System.Drawing.Size(506, 435);
            this.tabSampling.TabIndex = 4;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.GroupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(498, 409);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.grbStandradEquip);
            this.GroupBox1.Controls.Add(this.dtpExpireDate);
            this.GroupBox1.Controls.Add(this.btnFileName);
            this.GroupBox1.Controls.Add(this.cdvFileName);
            this.GroupBox1.Controls.Add(this.lblFileName);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.txtUpdateTime);
            this.GroupBox1.Controls.Add(this.txtCreateTime);
            this.GroupBox1.Controls.Add(this.txtUpdateUser);
            this.GroupBox1.Controls.Add(this.lblUpdate);
            this.GroupBox1.Controls.Add(this.txtCreateUser);
            this.GroupBox1.Controls.Add(this.lblCreate);
            this.GroupBox1.Controls.Add(this.txtFilePath);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(3, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(492, 406);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // grbStandradEquip
            // 
            this.grbStandradEquip.Controls.Add(this.rdoUseFlagNo);
            this.grbStandradEquip.Controls.Add(this.rdoUseFlagYes);
            this.grbStandradEquip.Location = new System.Drawing.Point(133, 53);
            this.grbStandradEquip.Name = "grbStandradEquip";
            this.grbStandradEquip.Size = new System.Drawing.Size(118, 28);
            this.grbStandradEquip.TabIndex = 84;
            this.grbStandradEquip.TabStop = false;
            // 
            // rdoUseFlagNo
            // 
            this.rdoUseFlagNo.AutoSize = true;
            this.rdoUseFlagNo.Location = new System.Drawing.Point(57, 8);
            this.rdoUseFlagNo.Name = "rdoUseFlagNo";
            this.rdoUseFlagNo.Size = new System.Drawing.Size(39, 17);
            this.rdoUseFlagNo.TabIndex = 9;
            this.rdoUseFlagNo.TabStop = true;
            this.rdoUseFlagNo.Text = "No";
            this.rdoUseFlagNo.UseVisualStyleBackColor = true;
            // 
            // rdoUseFlagYes
            // 
            this.rdoUseFlagYes.AutoSize = true;
            this.rdoUseFlagYes.Checked = true;
            this.rdoUseFlagYes.Location = new System.Drawing.Point(4, 8);
            this.rdoUseFlagYes.Name = "rdoUseFlagYes";
            this.rdoUseFlagYes.Size = new System.Drawing.Size(43, 17);
            this.rdoUseFlagYes.TabIndex = 8;
            this.rdoUseFlagYes.TabStop = true;
            this.rdoUseFlagYes.Text = "Yes";
            this.rdoUseFlagYes.UseVisualStyleBackColor = true;
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.CustomFormat = "yyyy-MM-dd";
            this.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpireDate.Location = new System.Drawing.Point(133, 29);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.Size = new System.Drawing.Size(118, 20);
            this.dtpExpireDate.TabIndex = 7;
            // 
            // btnFileName
            // 
            this.btnFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileName.Location = new System.Drawing.Point(437, 91);
            this.btnFileName.Name = "btnFileName";
            this.btnFileName.Size = new System.Drawing.Size(43, 21);
            this.btnFileName.TabIndex = 11;
            this.btnFileName.Text = "Open";
            this.btnFileName.UseVisualStyleBackColor = true;
            this.btnFileName.Click += new System.EventHandler(this.btnFileName_Click);
            // 
            // cdvFileName
            // 
            this.cdvFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFileName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFileName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFileName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFileName.BtnToolTipText = "";
            this.cdvFileName.ButtonWidth = 20;
            this.cdvFileName.DescText = "";
            this.cdvFileName.DisplaySubItemIndex = -1;
            this.cdvFileName.DisplayText = "";
            this.cdvFileName.Focusing = null;
            this.cdvFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFileName.Index = 0;
            this.cdvFileName.IsViewBtnImage = false;
            this.cdvFileName.Location = new System.Drawing.Point(133, 91);
            this.cdvFileName.MaxLength = 32767;
            this.cdvFileName.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFileName.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFileName.MultiSelect = false;
            this.cdvFileName.Name = "cdvFileName";
            this.cdvFileName.ReadOnly = true;
            this.cdvFileName.SameWidthHeightOfButton = false;
            this.cdvFileName.SearchSubItemIndex = 0;
            this.cdvFileName.SelectedDescIndex = -1;
            this.cdvFileName.SelectedDescToQueryText = "";
            this.cdvFileName.SelectedSubItemIndex = -1;
            this.cdvFileName.SelectedValueToQueryText = "";
            this.cdvFileName.SelectionStart = 0;
            this.cdvFileName.Size = new System.Drawing.Size(298, 20);
            this.cdvFileName.SmallImageList = null;
            this.cdvFileName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFileName.TabIndex = 10;
            this.cdvFileName.TextBoxToolTipText = "";
            this.cdvFileName.TextBoxWidth = 298;
            this.cdvFileName.VisibleButton = true;
            this.cdvFileName.VisibleColumnHeader = false;
            this.cdvFileName.VisibleDescription = false;
            this.cdvFileName.ButtonPress += new System.EventHandler(this.cdvFileName_ButtonPress);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(15, 95);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 13);
            this.lblFileName.TabIndex = 36;
            this.lblFileName.Text = "File Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Expire Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(15, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Use Flag";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(304, 372);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 23;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(304, 348);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 20;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(133, 372);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(168, 20);
            this.txtUpdateUser.TabIndex = 22;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(12, 374);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 21;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(133, 348);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(168, 20);
            this.txtCreateUser.TabIndex = 19;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(12, 350);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 18;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(267, 91);
            this.txtFilePath.MaxLength = 20;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(62, 20);
            this.txtFilePath.TabIndex = 41;
            this.txtFilePath.TabStop = false;
            this.txtFilePath.Visible = false;
            // 
            // frmMMSCalibrationUserSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSCalibrationUserSetup";
            this.Text = "Calibration User Setup";
            this.Activated += new System.EventHandler(this.frmMMSCalibrationUserSetup_Activated);
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
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            this.tabSampling.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.grbStandradEquip.ResumeLayout(false);
            this.grbStandradEquip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFileName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lisView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TabControl tabSampling;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFileName;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.DateTimePicker dtpExpireDate;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.GroupBox grbStandradEquip;
        private System.Windows.Forms.RadioButton rdoUseFlagNo;
        private System.Windows.Forms.RadioButton rdoUseFlagYes;
    }
}