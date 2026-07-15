namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSSampleSetup
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cdvViewSampleGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSampleGroup = new System.Windows.Forms.Label();
            this.lisView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.txtSampleCode = new System.Windows.Forms.TextBox();
            this.lblSampleCode = new System.Windows.Forms.Label();
            this.txtSampleName = new System.Windows.Forms.TextBox();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.tabSampling = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.grbStandradEquip = new System.Windows.Forms.GroupBox();
            this.rdoUseFlagNo = new System.Windows.Forms.RadioButton();
            this.rdoUseFlagYes = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cdvSampleGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewSampleGroup)).BeginInit();
            this.grpMaterial.SuspendLayout();
            this.tabSampling.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.grbStandradEquip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSampleGroup)).BeginInit();
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
            this.pnlLeft.Controls.Add(this.groupBox2);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cdvViewSampleGroup);
            this.groupBox2.Controls.Add(this.lblSampleGroup);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 48);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // cdvViewSampleGroup
            // 
            this.cdvViewSampleGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvViewSampleGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvViewSampleGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvViewSampleGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvViewSampleGroup.BtnToolTipText = "";
            this.cdvViewSampleGroup.ButtonWidth = 20;
            this.cdvViewSampleGroup.DescText = "";
            this.cdvViewSampleGroup.DisplaySubItemIndex = 0;
            this.cdvViewSampleGroup.DisplayText = "";
            this.cdvViewSampleGroup.Focusing = null;
            this.cdvViewSampleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvViewSampleGroup.Index = 0;
            this.cdvViewSampleGroup.IsViewBtnImage = false;
            this.cdvViewSampleGroup.Location = new System.Drawing.Point(91, 17);
            this.cdvViewSampleGroup.MaxLength = 20;
            this.cdvViewSampleGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvViewSampleGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvViewSampleGroup.MultiSelect = false;
            this.cdvViewSampleGroup.Name = "cdvViewSampleGroup";
            this.cdvViewSampleGroup.ReadOnly = false;
            this.cdvViewSampleGroup.SameWidthHeightOfButton = false;
            this.cdvViewSampleGroup.SearchSubItemIndex = 0;
            this.cdvViewSampleGroup.SelectedDescIndex = -1;
            this.cdvViewSampleGroup.SelectedDescToQueryText = "";
            this.cdvViewSampleGroup.SelectedSubItemIndex = 0;
            this.cdvViewSampleGroup.SelectedValueToQueryText = "";
            this.cdvViewSampleGroup.SelectionStart = 0;
            this.cdvViewSampleGroup.Size = new System.Drawing.Size(128, 20);
            this.cdvViewSampleGroup.SmallImageList = null;
            this.cdvViewSampleGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvViewSampleGroup.TabIndex = 4;
            this.cdvViewSampleGroup.TextBoxToolTipText = "";
            this.cdvViewSampleGroup.TextBoxWidth = 128;
            this.cdvViewSampleGroup.VisibleButton = true;
            this.cdvViewSampleGroup.VisibleColumnHeader = false;
            this.cdvViewSampleGroup.VisibleDescription = false;
            this.cdvViewSampleGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvViewSampleGroup_SelectedItemChanged);
            this.cdvViewSampleGroup.ButtonPress += new System.EventHandler(this.cdvViewSampleGroup_ButtonPress);
            // 
            // lblSampleGroup
            // 
            this.lblSampleGroup.AutoSize = true;
            this.lblSampleGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSampleGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSampleGroup.Location = new System.Drawing.Point(14, 20);
            this.lblSampleGroup.Name = "lblSampleGroup";
            this.lblSampleGroup.Size = new System.Drawing.Size(74, 13);
            this.lblSampleGroup.TabIndex = 3;
            this.lblSampleGroup.Text = "Sample Group";
            // 
            // lisView
            // 
            this.lisView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lisView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisView.FullRowSelect = true;
            this.lisView.Location = new System.Drawing.Point(0, 48);
            this.lisView.Name = "lisView";
            this.lisView.Size = new System.Drawing.Size(232, 458);
            this.lisView.TabIndex = 5;
            this.lisView.UseCompatibleStateImageBehavior = false;
            this.lisView.View = System.Windows.Forms.View.Details;
            this.lisView.SelectedIndexChanged += new System.EventHandler(this.lisView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sample Code";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 130;
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.txtSampleCode);
            this.grpMaterial.Controls.Add(this.lblSampleCode);
            this.grpMaterial.Controls.Add(this.txtSampleName);
            this.grpMaterial.Controls.Add(this.lblItemDesc);
            this.grpMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterial.Location = new System.Drawing.Point(0, 0);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Size = new System.Drawing.Size(506, 71);
            this.grpMaterial.TabIndex = 2;
            this.grpMaterial.TabStop = false;
            // 
            // txtSampleCode
            // 
            this.txtSampleCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSampleCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSampleCode.Location = new System.Drawing.Point(135, 14);
            this.txtSampleCode.MaxLength = 50;
            this.txtSampleCode.Name = "txtSampleCode";
            this.txtSampleCode.Size = new System.Drawing.Size(173, 20);
            this.txtSampleCode.TabIndex = 6;
            // 
            // lblSampleCode
            // 
            this.lblSampleCode.AutoSize = true;
            this.lblSampleCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSampleCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampleCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSampleCode.Location = new System.Drawing.Point(16, 18);
            this.lblSampleCode.Name = "lblSampleCode";
            this.lblSampleCode.Size = new System.Drawing.Size(81, 13);
            this.lblSampleCode.TabIndex = 3;
            this.lblSampleCode.Text = "Sample Code";
            // 
            // txtSampleName
            // 
            this.txtSampleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSampleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSampleName.Location = new System.Drawing.Point(135, 40);
            this.txtSampleName.MaxLength = 100;
            this.txtSampleName.Name = "txtSampleName";
            this.txtSampleName.Size = new System.Drawing.Size(361, 20);
            this.txtSampleName.TabIndex = 7;
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDesc.Location = new System.Drawing.Point(16, 43);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(60, 13);
            this.lblItemDesc.TabIndex = 1;
            this.lblItemDesc.Text = "Description";
            this.lblItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tabSampling.TabIndex = 3;
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
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.cdvSampleGroup);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.txtUpdateTime);
            this.GroupBox1.Controls.Add(this.txtCreateTime);
            this.GroupBox1.Controls.Add(this.txtUpdateUser);
            this.GroupBox1.Controls.Add(this.lblUpdate);
            this.GroupBox1.Controls.Add(this.txtCreateUser);
            this.GroupBox1.Controls.Add(this.lblCreate);
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
            this.grbStandradEquip.Location = new System.Drawing.Point(133, 54);
            this.grbStandradEquip.Name = "grbStandradEquip";
            this.grbStandradEquip.Size = new System.Drawing.Size(110, 28);
            this.grbStandradEquip.TabIndex = 83;
            this.grbStandradEquip.TabStop = false;
            // 
            // rdoUseFlagNo
            // 
            this.rdoUseFlagNo.AutoSize = true;
            this.rdoUseFlagNo.Location = new System.Drawing.Point(57, 8);
            this.rdoUseFlagNo.Name = "rdoUseFlagNo";
            this.rdoUseFlagNo.Size = new System.Drawing.Size(39, 17);
            this.rdoUseFlagNo.TabIndex = 10;
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
            this.rdoUseFlagYes.TabIndex = 9;
            this.rdoUseFlagYes.TabStop = true;
            this.rdoUseFlagYes.Text = "Yes";
            this.rdoUseFlagYes.UseVisualStyleBackColor = true;
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
            // cdvSampleGroup
            // 
            this.cdvSampleGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvSampleGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSampleGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSampleGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSampleGroup.BtnToolTipText = "";
            this.cdvSampleGroup.ButtonWidth = 20;
            this.cdvSampleGroup.DescText = "";
            this.cdvSampleGroup.DisplaySubItemIndex = 0;
            this.cdvSampleGroup.DisplayText = "";
            this.cdvSampleGroup.Focusing = null;
            this.cdvSampleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSampleGroup.Index = 0;
            this.cdvSampleGroup.IsViewBtnImage = false;
            this.cdvSampleGroup.Location = new System.Drawing.Point(133, 23);
            this.cdvSampleGroup.MaxLength = 40;
            this.cdvSampleGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSampleGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSampleGroup.MultiSelect = false;
            this.cdvSampleGroup.Name = "cdvSampleGroup";
            this.cdvSampleGroup.ReadOnly = false;
            this.cdvSampleGroup.SameWidthHeightOfButton = false;
            this.cdvSampleGroup.SearchSubItemIndex = 0;
            this.cdvSampleGroup.SelectedDescIndex = 1;
            this.cdvSampleGroup.SelectedDescToQueryText = "";
            this.cdvSampleGroup.SelectedSubItemIndex = 0;
            this.cdvSampleGroup.SelectedValueToQueryText = "";
            this.cdvSampleGroup.SelectionStart = 0;
            this.cdvSampleGroup.Size = new System.Drawing.Size(280, 21);
            this.cdvSampleGroup.SmallImageList = null;
            this.cdvSampleGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSampleGroup.TabIndex = 8;
            this.cdvSampleGroup.TextBoxToolTipText = "";
            this.cdvSampleGroup.TextBoxWidth = 110;
            this.cdvSampleGroup.VisibleButton = true;
            this.cdvSampleGroup.VisibleColumnHeader = false;
            this.cdvSampleGroup.VisibleDescription = true;
            this.cdvSampleGroup.ButtonPress += new System.EventHandler(this.cdvSampleGroup_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Sample Group";
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
            // frmMMSSampleSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSSampleSetup";
            this.Text = "Sample Setup";
            this.Activated += new System.EventHandler(this.frmMMSSampleSetup_Activated);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewSampleGroup)).EndInit();
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            this.tabSampling.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.grbStandradEquip.ResumeLayout(false);
            this.grbStandradEquip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSampleGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvViewSampleGroup;
        private System.Windows.Forms.Label lblSampleGroup;
        private System.Windows.Forms.ListView lisView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.TextBox txtSampleCode;
        private System.Windows.Forms.Label lblSampleCode;
        private System.Windows.Forms.TextBox txtSampleName;
        private System.Windows.Forms.Label lblItemDesc;
        private System.Windows.Forms.TabControl tabSampling;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label label4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSampleGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.GroupBox grbStandradEquip;
        private System.Windows.Forms.RadioButton rdoUseFlagNo;
        private System.Windows.Forms.RadioButton rdoUseFlagYes;
    }
}