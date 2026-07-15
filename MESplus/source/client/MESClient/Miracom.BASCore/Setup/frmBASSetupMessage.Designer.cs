namespace Miracom.BASCore
{
    partial class frmBASSetupMessage
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
            this.pnlMsgList = new System.Windows.Forms.Panel();
            this.lisMsgList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlMsgGrp = new System.Windows.Forms.Panel();
            this.grpMsgGrp = new System.Windows.Forms.GroupBox();
            this.cboMsgGrp = new System.Windows.Forms.ComboBox();
            this.lblMessageGroup = new System.Windows.Forms.Label();
            this.pnlMsgId = new System.Windows.Forms.Panel();
            this.grpMsgId = new System.Windows.Forms.GroupBox();
            this.txtMsgId = new System.Windows.Forms.TextBox();
            this.lblMsgId = new System.Windows.Forms.Label();
            this.pnlMsgData = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpMsgData = new System.Windows.Forms.GroupBox();
            this.txtMsg3 = new System.Windows.Forms.TextBox();
            this.txtMsg2 = new System.Windows.Forms.TextBox();
            this.txtMsg1 = new System.Windows.Forms.TextBox();
            this.lblMsg_3 = new System.Windows.Forms.Label();
            this.lblMsg_2 = new System.Windows.Forms.Label();
            this.lblMsg_1 = new System.Windows.Forms.Label();
            this.pnlUserTime = new System.Windows.Forms.Panel();
            this.grpUserTime = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblCreate = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grbExportCenter = new System.Windows.Forms.GroupBox();
            this.txtExport = new System.Windows.Forms.RichTextBox();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rboMsgId = new System.Windows.Forms.RadioButton();
            this.cboInsertMsgGrp = new System.Windows.Forms.ComboBox();
            this.rboAllTbl = new System.Windows.Forms.RadioButton();
            this.rboGroup = new System.Windows.Forms.RadioButton();
            this.txtInsertExportFile = new System.Windows.Forms.TextBox();
            this.btnInsertExportFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClipCopy = new System.Windows.Forms.Button();
            this.txtInsertMsgId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInsertExportStop = new System.Windows.Forms.Button();
            this.btnInsertExport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMsgList.SuspendLayout();
            this.pnlMsgGrp.SuspendLayout();
            this.grpMsgGrp.SuspendLayout();
            this.pnlMsgId.SuspendLayout();
            this.grpMsgId.SuspendLayout();
            this.pnlMsgData.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpMsgData.SuspendLayout();
            this.pnlUserTime.SuspendLayout();
            this.grpUserTime.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grbExportCenter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 2;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlMsgData);
            this.pnlRight.Controls.Add(this.pnlMsgId);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlMsgList);
            this.pnlLeft.Controls.Add(this.pnlMsgGrp);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(370, 6);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(558, 6);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(464, 6);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(652, 6);
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Message Setup";
            // 
            // pnlMsgList
            // 
            this.pnlMsgList.Controls.Add(this.lisMsgList);
            this.pnlMsgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMsgList.Location = new System.Drawing.Point(0, 47);
            this.pnlMsgList.Name = "pnlMsgList";
            this.pnlMsgList.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlMsgList.Size = new System.Drawing.Size(232, 466);
            this.pnlMsgList.TabIndex = 1;
            // 
            // lisMsgList
            // 
            this.lisMsgList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.ColumnHeader1});
            this.lisMsgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMsgList.EnableSort = true;
            this.lisMsgList.EnableSortIcon = true;
            this.lisMsgList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMsgList.FullRowSelect = true;
            this.lisMsgList.Location = new System.Drawing.Point(3, 3);
            this.lisMsgList.MultiSelect = false;
            this.lisMsgList.Name = "lisMsgList";
            this.lisMsgList.Size = new System.Drawing.Size(229, 460);
            this.lisMsgList.TabIndex = 0;
            this.lisMsgList.UseCompatibleStateImageBehavior = false;
            this.lisMsgList.View = System.Windows.Forms.View.Details;
            this.lisMsgList.SelectedIndexChanged += new System.EventHandler(this.lisMsgList_SelectedIndexChanged);
            // 
            // colCode
            // 
            this.colCode.Text = "Message ID";
            this.colCode.Width = 90;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Message";
            this.ColumnHeader1.Width = 300;
            // 
            // pnlMsgGrp
            // 
            this.pnlMsgGrp.Controls.Add(this.grpMsgGrp);
            this.pnlMsgGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMsgGrp.Location = new System.Drawing.Point(0, 0);
            this.pnlMsgGrp.Name = "pnlMsgGrp";
            this.pnlMsgGrp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlMsgGrp.Size = new System.Drawing.Size(232, 47);
            this.pnlMsgGrp.TabIndex = 0;
            // 
            // grpMsgGrp
            // 
            this.grpMsgGrp.Controls.Add(this.cboMsgGrp);
            this.grpMsgGrp.Controls.Add(this.lblMessageGroup);
            this.grpMsgGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMsgGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMsgGrp.Location = new System.Drawing.Point(3, 0);
            this.grpMsgGrp.Name = "grpMsgGrp";
            this.grpMsgGrp.Size = new System.Drawing.Size(229, 47);
            this.grpMsgGrp.TabIndex = 0;
            this.grpMsgGrp.TabStop = false;
            // 
            // cboMsgGrp
            // 
            this.cboMsgGrp.DropDownWidth = 100;
            this.cboMsgGrp.Location = new System.Drawing.Point(118, 16);
            this.cboMsgGrp.MaxDropDownItems = 30;
            this.cboMsgGrp.MaxLength = 20;
            this.cboMsgGrp.Name = "cboMsgGrp";
            this.cboMsgGrp.Size = new System.Drawing.Size(98, 21);
            this.cboMsgGrp.TabIndex = 0;
            this.cboMsgGrp.TextChanged += new System.EventHandler(this.cboMsgGrp_TextChanged);
            this.cboMsgGrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMsgGrp_KeyPress);
            // 
            // lblMessageGroup
            // 
            this.lblMessageGroup.AutoSize = true;
            this.lblMessageGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMessageGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageGroup.Location = new System.Drawing.Point(10, 19);
            this.lblMessageGroup.Name = "lblMessageGroup";
            this.lblMessageGroup.Size = new System.Drawing.Size(95, 13);
            this.lblMessageGroup.TabIndex = 0;
            this.lblMessageGroup.Text = "Message Group";
            this.lblMessageGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMsgId
            // 
            this.pnlMsgId.Controls.Add(this.grpMsgId);
            this.pnlMsgId.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMsgId.Location = new System.Drawing.Point(0, 0);
            this.pnlMsgId.Name = "pnlMsgId";
            this.pnlMsgId.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlMsgId.Size = new System.Drawing.Size(506, 47);
            this.pnlMsgId.TabIndex = 0;
            // 
            // grpMsgId
            // 
            this.grpMsgId.Controls.Add(this.txtMsgId);
            this.grpMsgId.Controls.Add(this.lblMsgId);
            this.grpMsgId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMsgId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMsgId.Location = new System.Drawing.Point(3, 0);
            this.grpMsgId.Name = "grpMsgId";
            this.grpMsgId.Size = new System.Drawing.Size(500, 47);
            this.grpMsgId.TabIndex = 0;
            this.grpMsgId.TabStop = false;
            // 
            // txtMsgId
            // 
            this.txtMsgId.Location = new System.Drawing.Point(120, 16);
            this.txtMsgId.MaxLength = 10;
            this.txtMsgId.Name = "txtMsgId";
            this.txtMsgId.Size = new System.Drawing.Size(200, 20);
            this.txtMsgId.TabIndex = 1;
            this.txtMsgId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsgId_KeyPress);
            // 
            // lblMsgId
            // 
            this.lblMsgId.AutoSize = true;
            this.lblMsgId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsgId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgId.Location = new System.Drawing.Point(15, 19);
            this.lblMsgId.Name = "lblMsgId";
            this.lblMsgId.Size = new System.Drawing.Size(74, 13);
            this.lblMsgId.TabIndex = 0;
            this.lblMsgId.Text = "Message ID";
            this.lblMsgId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMsgData
            // 
            this.pnlMsgData.Controls.Add(this.tabControl1);
            this.pnlMsgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMsgData.Location = new System.Drawing.Point(0, 47);
            this.pnlMsgData.Name = "pnlMsgData";
            this.pnlMsgData.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.pnlMsgData.Size = new System.Drawing.Size(506, 466);
            this.pnlMsgData.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(500, 461);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.grpMsgData);
            this.tabPage1.Controls.Add(this.pnlUserTime);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Message";
            // 
            // grpMsgData
            // 
            this.grpMsgData.Controls.Add(this.txtMsg3);
            this.grpMsgData.Controls.Add(this.txtMsg2);
            this.grpMsgData.Controls.Add(this.txtMsg1);
            this.grpMsgData.Controls.Add(this.lblMsg_3);
            this.grpMsgData.Controls.Add(this.lblMsg_2);
            this.grpMsgData.Controls.Add(this.lblMsg_1);
            this.grpMsgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMsgData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMsgData.Location = new System.Drawing.Point(3, 3);
            this.grpMsgData.Name = "grpMsgData";
            this.grpMsgData.Size = new System.Drawing.Size(486, 337);
            this.grpMsgData.TabIndex = 3;
            this.grpMsgData.TabStop = false;
            this.grpMsgData.Text = "Message Data";
            // 
            // txtMsg3
            // 
            this.txtMsg3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg3.Location = new System.Drawing.Point(120, 215);
            this.txtMsg3.MaxLength = 200;
            this.txtMsg3.Multiline = true;
            this.txtMsg3.Name = "txtMsg3";
            this.txtMsg3.Size = new System.Drawing.Size(330, 95);
            this.txtMsg3.TabIndex = 5;
            // 
            // txtMsg2
            // 
            this.txtMsg2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg2.Location = new System.Drawing.Point(120, 115);
            this.txtMsg2.MaxLength = 200;
            this.txtMsg2.Multiline = true;
            this.txtMsg2.Name = "txtMsg2";
            this.txtMsg2.Size = new System.Drawing.Size(330, 95);
            this.txtMsg2.TabIndex = 3;
            // 
            // txtMsg1
            // 
            this.txtMsg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg1.Location = new System.Drawing.Point(120, 14);
            this.txtMsg1.MaxLength = 200;
            this.txtMsg1.Multiline = true;
            this.txtMsg1.Name = "txtMsg1";
            this.txtMsg1.Size = new System.Drawing.Size(330, 95);
            this.txtMsg1.TabIndex = 1;
            // 
            // lblMsg_3
            // 
            this.lblMsg_3.AutoSize = true;
            this.lblMsg_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsg_3.Location = new System.Drawing.Point(15, 225);
            this.lblMsg_3.Name = "lblMsg_3";
            this.lblMsg_3.Size = new System.Drawing.Size(59, 13);
            this.lblMsg_3.TabIndex = 4;
            this.lblMsg_3.Text = "Message 3";
            this.lblMsg_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMsg_2
            // 
            this.lblMsg_2.AutoSize = true;
            this.lblMsg_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsg_2.Location = new System.Drawing.Point(15, 125);
            this.lblMsg_2.Name = "lblMsg_2";
            this.lblMsg_2.Size = new System.Drawing.Size(59, 13);
            this.lblMsg_2.TabIndex = 2;
            this.lblMsg_2.Text = "Message 2";
            this.lblMsg_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMsg_1
            // 
            this.lblMsg_1.AutoSize = true;
            this.lblMsg_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsg_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg_1.Location = new System.Drawing.Point(15, 24);
            this.lblMsg_1.Name = "lblMsg_1";
            this.lblMsg_1.Size = new System.Drawing.Size(68, 13);
            this.lblMsg_1.TabIndex = 0;
            this.lblMsg_1.Text = "Message 1";
            this.lblMsg_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUserTime
            // 
            this.pnlUserTime.Controls.Add(this.grpUserTime);
            this.pnlUserTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUserTime.Location = new System.Drawing.Point(3, 340);
            this.pnlUserTime.Name = "pnlUserTime";
            this.pnlUserTime.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlUserTime.Size = new System.Drawing.Size(486, 92);
            this.pnlUserTime.TabIndex = 4;
            // 
            // grpUserTime
            // 
            this.grpUserTime.Controls.Add(this.txtUpdateTime);
            this.grpUserTime.Controls.Add(this.txtCreateTime);
            this.grpUserTime.Controls.Add(this.txtUpdateUser);
            this.grpUserTime.Controls.Add(this.txtCreateUser);
            this.grpUserTime.Controls.Add(this.lblUpdate);
            this.grpUserTime.Controls.Add(this.lblCreate);
            this.grpUserTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUserTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUserTime.Location = new System.Drawing.Point(3, 0);
            this.grpUserTime.Name = "grpUserTime";
            this.grpUserTime.Size = new System.Drawing.Size(480, 89);
            this.grpUserTime.TabIndex = 0;
            this.grpUserTime.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(304, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(165, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(304, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(165, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(136, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(163, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(136, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(163, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(20, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(20, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.grbExportCenter);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export";
            // 
            // grbExportCenter
            // 
            this.grbExportCenter.Controls.Add(this.txtExport);
            this.grbExportCenter.Controls.Add(this.progressBarExport);
            this.grbExportCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbExportCenter.Location = new System.Drawing.Point(3, 123);
            this.grbExportCenter.Name = "grbExportCenter";
            this.grbExportCenter.Size = new System.Drawing.Size(486, 309);
            this.grbExportCenter.TabIndex = 5;
            this.grbExportCenter.TabStop = false;
            // 
            // txtExport
            // 
            this.txtExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExport.Location = new System.Drawing.Point(3, 16);
            this.txtExport.Name = "txtExport";
            this.txtExport.ReadOnly = true;
            this.txtExport.Size = new System.Drawing.Size(480, 267);
            this.txtExport.TabIndex = 13;
            this.txtExport.Text = "";
            this.txtExport.WordWrap = false;
            // 
            // progressBarExport
            // 
            this.progressBarExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarExport.Location = new System.Drawing.Point(3, 283);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(480, 23);
            this.progressBarExport.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rboMsgId);
            this.groupBox1.Controls.Add(this.cboInsertMsgGrp);
            this.groupBox1.Controls.Add(this.rboAllTbl);
            this.groupBox1.Controls.Add(this.rboGroup);
            this.groupBox1.Controls.Add(this.txtInsertExportFile);
            this.groupBox1.Controls.Add(this.btnInsertExportFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnClipCopy);
            this.groupBox1.Controls.Add(this.txtInsertMsgId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnInsertExportStop);
            this.groupBox1.Controls.Add(this.btnInsertExport);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB Insert Script Create";
            // 
            // rboMsgId
            // 
            this.rboMsgId.AutoSize = true;
            this.rboMsgId.Checked = true;
            this.rboMsgId.Location = new System.Drawing.Point(269, 18);
            this.rboMsgId.Name = "rboMsgId";
            this.rboMsgId.Size = new System.Drawing.Size(57, 17);
            this.rboMsgId.TabIndex = 2;
            this.rboMsgId.TabStop = true;
            this.rboMsgId.Text = "Msg Id";
            this.rboMsgId.UseVisualStyleBackColor = true;
            // 
            // cboInsertMsgGrp
            // 
            this.cboInsertMsgGrp.DropDownWidth = 100;
            this.cboInsertMsgGrp.Location = new System.Drawing.Point(113, 16);
            this.cboInsertMsgGrp.MaxDropDownItems = 30;
            this.cboInsertMsgGrp.MaxLength = 20;
            this.cboInsertMsgGrp.Name = "cboInsertMsgGrp";
            this.cboInsertMsgGrp.Size = new System.Drawing.Size(150, 21);
            this.cboInsertMsgGrp.TabIndex = 1;
            // 
            // rboAllTbl
            // 
            this.rboAllTbl.AutoSize = true;
            this.rboAllTbl.Location = new System.Drawing.Point(415, 18);
            this.rboAllTbl.Name = "rboAllTbl";
            this.rboAllTbl.Size = new System.Drawing.Size(66, 17);
            this.rboAllTbl.TabIndex = 4;
            this.rboAllTbl.Text = "All Table";
            this.rboAllTbl.UseVisualStyleBackColor = true;
            // 
            // rboGroup
            // 
            this.rboGroup.AutoSize = true;
            this.rboGroup.Location = new System.Drawing.Point(345, 18);
            this.rboGroup.Name = "rboGroup";
            this.rboGroup.Size = new System.Drawing.Size(54, 17);
            this.rboGroup.TabIndex = 3;
            this.rboGroup.Text = "Group";
            this.rboGroup.UseVisualStyleBackColor = true;
            // 
            // txtInsertExportFile
            // 
            this.txtInsertExportFile.Location = new System.Drawing.Point(113, 64);
            this.txtInsertExportFile.MaxLength = 1000;
            this.txtInsertExportFile.Name = "txtInsertExportFile";
            this.txtInsertExportFile.ReadOnly = true;
            this.txtInsertExportFile.Size = new System.Drawing.Size(329, 20);
            this.txtInsertExportFile.TabIndex = 8;
            // 
            // btnInsertExportFile
            // 
            this.btnInsertExportFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertExportFile.Location = new System.Drawing.Point(441, 63);
            this.btnInsertExportFile.Name = "btnInsertExportFile";
            this.btnInsertExportFile.Size = new System.Drawing.Size(21, 21);
            this.btnInsertExportFile.TabIndex = 9;
            this.btnInsertExportFile.Text = "...";
            this.btnInsertExportFile.Click += new System.EventHandler(this.btnInsertExportFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Export File";
            // 
            // btnClipCopy
            // 
            this.btnClipCopy.Location = new System.Drawing.Point(287, 91);
            this.btnClipCopy.Name = "btnClipCopy";
            this.btnClipCopy.Size = new System.Drawing.Size(75, 23);
            this.btnClipCopy.TabIndex = 12;
            this.btnClipCopy.Text = "Clip Copy";
            this.btnClipCopy.Click += new System.EventHandler(this.btnClipCopy_Click_1);
            // 
            // txtInsertMsgId
            // 
            this.txtInsertMsgId.Location = new System.Drawing.Point(113, 40);
            this.txtInsertMsgId.MaxLength = 10;
            this.txtInsertMsgId.Name = "txtInsertMsgId";
            this.txtInsertMsgId.Size = new System.Drawing.Size(150, 20);
            this.txtInsertMsgId.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Message Id";
            // 
            // btnInsertExportStop
            // 
            this.btnInsertExportStop.Location = new System.Drawing.Point(200, 91);
            this.btnInsertExportStop.Name = "btnInsertExportStop";
            this.btnInsertExportStop.Size = new System.Drawing.Size(75, 23);
            this.btnInsertExportStop.TabIndex = 11;
            this.btnInsertExportStop.Text = "Stop";
            this.btnInsertExportStop.Click += new System.EventHandler(this.btnInsertExportStop_Click_1);
            // 
            // btnInsertExport
            // 
            this.btnInsertExport.Location = new System.Drawing.Point(113, 91);
            this.btnInsertExport.Name = "btnInsertExport";
            this.btnInsertExport.Size = new System.Drawing.Size(75, 23);
            this.btnInsertExport.TabIndex = 10;
            this.btnInsertExport.Text = "Export";
            this.btnInsertExport.Click += new System.EventHandler(this.btnInsertExport_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Group";
            // 
            // frmBASSetupMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASSetupMessage";
            this.Text = "Message Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupMessage_Activated);
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
            this.pnlMsgList.ResumeLayout(false);
            this.pnlMsgGrp.ResumeLayout(false);
            this.grpMsgGrp.ResumeLayout(false);
            this.grpMsgGrp.PerformLayout();
            this.pnlMsgId.ResumeLayout(false);
            this.grpMsgId.ResumeLayout(false);
            this.grpMsgId.PerformLayout();
            this.pnlMsgData.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpMsgData.ResumeLayout(false);
            this.grpMsgData.PerformLayout();
            this.pnlUserTime.ResumeLayout(false);
            this.grpUserTime.ResumeLayout(false);
            this.grpUserTime.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.grbExportCenter.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.GroupBox grpMsgGrp;
        private System.Windows.Forms.ComboBox cboMsgGrp;
        private System.Windows.Forms.Label lblMessageGroup;
        private System.Windows.Forms.GroupBox grpMsgId;
        private System.Windows.Forms.TextBox txtMsgId;
        private System.Windows.Forms.Label lblMsgId;
        private Miracom.UI.Controls.MCListView.MCListView lisMsgList;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.Panel pnlMsgList;
        private System.Windows.Forms.Panel pnlMsgGrp;
        private System.Windows.Forms.Panel pnlMsgId;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grpMsgData;
        private System.Windows.Forms.TextBox txtMsg3;
        private System.Windows.Forms.TextBox txtMsg2;
        private System.Windows.Forms.TextBox txtMsg1;
        private System.Windows.Forms.Label lblMsg_3;
        private System.Windows.Forms.Label lblMsg_2;
        private System.Windows.Forms.Label lblMsg_1;
        private System.Windows.Forms.Panel pnlUserTime;
        private System.Windows.Forms.GroupBox grpUserTime;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox grbExportCenter;
        private System.Windows.Forms.RichTextBox txtExport;
        private System.Windows.Forms.ProgressBar progressBarExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboInsertMsgGrp;
        private System.Windows.Forms.RadioButton rboAllTbl;
        private System.Windows.Forms.RadioButton rboGroup;
        private System.Windows.Forms.TextBox txtInsertExportFile;
        private System.Windows.Forms.Button btnInsertExportFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClipCopy;
        private System.Windows.Forms.TextBox txtInsertMsgId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsertExportStop;
        private System.Windows.Forms.Button btnInsertExport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RadioButton rboMsgId;
        private System.Windows.Forms.Panel pnlMsgData;
    }
}
