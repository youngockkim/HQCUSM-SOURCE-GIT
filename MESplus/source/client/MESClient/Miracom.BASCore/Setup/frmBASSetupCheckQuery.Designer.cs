namespace Miracom.BASCore
{
    partial class frmBASSetupCheckQuery
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
            this.grpFuncGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lisDataCode = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlCheckQuery = new System.Windows.Forms.Panel();
            this.pnlCheckTop2 = new System.Windows.Forms.Panel();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.pnlCheckFill = new System.Windows.Forms.Panel();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.cboValTabType = new System.Windows.Forms.ComboBox();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.lblValidateTableType = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.cdvTableName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValidateTable = new System.Windows.Forms.Label();
            this.pnlCheckTop = new System.Windows.Forms.Panel();
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.cdvQueryType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDataType = new System.Windows.Forms.Label();
            this.txtQueryID = new System.Windows.Forms.TextBox();
            this.lblDataCode = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpFuncGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            this.pnlCheckQuery.SuspendLayout();
            this.pnlCheckTop2.SuspendLayout();
            this.grpQuery.SuspendLayout();
            this.pnlCheckFill.SuspendLayout();
            this.grpType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableName)).BeginInit();
            this.pnlCheckTop.SuspendLayout();
            this.grbTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvQueryType)).BeginInit();
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
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlCheckQuery);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisDataCode);
            this.pnlLeft.Controls.Add(this.grpFuncGroup);
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
            // grpFuncGroup
            // 
            this.grpFuncGroup.Controls.Add(this.cdvGroup);
            this.grpFuncGroup.Controls.Add(this.lblGroup);
            this.grpFuncGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFuncGroup.Location = new System.Drawing.Point(0, 0);
            this.grpFuncGroup.Name = "grpFuncGroup";
            this.grpFuncGroup.Size = new System.Drawing.Size(232, 36);
            this.grpFuncGroup.TabIndex = 1;
            this.grpFuncGroup.TabStop = false;
            // 
            // cdvGroup
            // 
            this.cdvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup.BtnToolTipText = "";
            this.cdvGroup.DescText = "";
            this.cdvGroup.DisplaySubItemIndex = -1;
            this.cdvGroup.DisplayText = "";
            this.cdvGroup.Focusing = null;
            this.cdvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup.Index = 0;
            this.cdvGroup.IsViewBtnImage = false;
            this.cdvGroup.Location = new System.Drawing.Point(89, 11);
            this.cdvGroup.MaxLength = 20;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = false;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedSubItemIndex = -1;
            this.cdvGroup.SelectionStart = 0;
            this.cdvGroup.Size = new System.Drawing.Size(139, 20);
            this.cdvGroup.SmallImageList = null;
            this.cdvGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup.TabIndex = 1;
            this.cdvGroup.TextBoxToolTipText = "";
            this.cdvGroup.TextBoxWidth = 139;
            this.cdvGroup.VisibleButton = true;
            this.cdvGroup.VisibleColumnHeader = false;
            this.cdvGroup.VisibleDescription = false;
            this.cdvGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGroup_SelectedItemChanged);
            this.cdvGroup.ButtonPress += new System.EventHandler(this.cdvGroup_ButtonPress);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup.Location = new System.Drawing.Point(6, 13);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(62, 13);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Query Type";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisDataCode
            // 
            this.lisDataCode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisDataCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisDataCode.EnableSort = true;
            this.lisDataCode.EnableSortIcon = true;
            this.lisDataCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisDataCode.FullRowSelect = true;
            this.lisDataCode.HideSelection = false;
            this.lisDataCode.Location = new System.Drawing.Point(0, 36);
            this.lisDataCode.MultiSelect = false;
            this.lisDataCode.Name = "lisDataCode";
            this.lisDataCode.Size = new System.Drawing.Size(232, 470);
            this.lisDataCode.TabIndex = 2;
            this.lisDataCode.UseCompatibleStateImageBehavior = false;
            this.lisDataCode.View = System.Windows.Forms.View.Details;
            this.lisDataCode.SelectedIndexChanged += new System.EventHandler(this.lisDataCode_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Query";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // pnlCheckQuery
            // 
            this.pnlCheckQuery.Controls.Add(this.pnlCheckTop2);
            this.pnlCheckQuery.Controls.Add(this.pnlCheckFill);
            this.pnlCheckQuery.Controls.Add(this.pnlCheckTop);
            this.pnlCheckQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCheckQuery.Location = new System.Drawing.Point(0, 0);
            this.pnlCheckQuery.Name = "pnlCheckQuery";
            this.pnlCheckQuery.Size = new System.Drawing.Size(506, 506);
            this.pnlCheckQuery.TabIndex = 0;
            // 
            // pnlCheckTop2
            // 
            this.pnlCheckTop2.Controls.Add(this.grpQuery);
            this.pnlCheckTop2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCheckTop2.Location = new System.Drawing.Point(0, 70);
            this.pnlCheckTop2.Name = "pnlCheckTop2";
            this.pnlCheckTop2.Size = new System.Drawing.Size(506, 307);
            this.pnlCheckTop2.TabIndex = 1;
            // 
            // grpQuery
            // 
            this.grpQuery.Controls.Add(this.txtQuery);
            this.grpQuery.Controls.Add(this.lblQuery);
            this.grpQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQuery.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpQuery.Location = new System.Drawing.Point(0, 0);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(506, 307);
            this.grpQuery.TabIndex = 2;
            this.grpQuery.TabStop = false;
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(125, 19);
            this.txtQuery.MaxLength = 1000;
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(372, 277);
            this.txtQuery.TabIndex = 1;
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuery.Location = new System.Drawing.Point(13, 16);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(40, 13);
            this.lblQuery.TabIndex = 0;
            this.lblQuery.Text = "Query";
            this.lblQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCheckFill
            // 
            this.pnlCheckFill.Controls.Add(this.grpType);
            this.pnlCheckFill.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCheckFill.Location = new System.Drawing.Point(0, 377);
            this.pnlCheckFill.Name = "pnlCheckFill";
            this.pnlCheckFill.Size = new System.Drawing.Size(506, 129);
            this.pnlCheckFill.TabIndex = 2;
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.cboValTabType);
            this.grpType.Controls.Add(this.cboFormat);
            this.grpType.Controls.Add(this.nudSize);
            this.grpType.Controls.Add(this.lblValidateTableType);
            this.grpType.Controls.Add(this.lblFormat);
            this.grpType.Controls.Add(this.lblSize);
            this.grpType.Controls.Add(this.cdvTableName);
            this.grpType.Controls.Add(this.lblValidateTable);
            this.grpType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpType.Location = new System.Drawing.Point(0, 0);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(506, 129);
            this.grpType.TabIndex = 3;
            this.grpType.TabStop = false;
            this.grpType.Text = "Input Data Type";
            // 
            // cboValTabType
            // 
            this.cboValTabType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboValTabType.FormattingEnabled = true;
            this.cboValTabType.Items.AddRange(new object[] {
            "",
            "A : Allowed",
            "N : Not Allowed"});
            this.cboValTabType.Location = new System.Drawing.Point(125, 72);
            this.cboValTabType.Name = "cboValTabType";
            this.cboValTabType.Size = new System.Drawing.Size(177, 21);
            this.cboValTabType.TabIndex = 11;
            this.cboValTabType.SelectedIndexChanged += new System.EventHandler(this.cboValTabType_SelectedIndexChanged);
            // 
            // cboFormat
            // 
            this.cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormat.FormattingEnabled = true;
            this.cboFormat.Items.AddRange(new object[] {
            "",
            "A : Ascii",
            "N : Number",
            "F : Float",
            "D : DateTime",
            "E : Date",
            "T : Time"});
            this.cboFormat.Location = new System.Drawing.Point(125, 19);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(177, 21);
            this.cboFormat.TabIndex = 10;
            this.cboFormat.SelectedIndexChanged += new System.EventHandler(this.cboFormat_SelectedIndexChanged);
            // 
            // nudSize
            // 
            this.nudSize.Location = new System.Drawing.Point(125, 46);
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(177, 20);
            this.nudSize.TabIndex = 8;
            // 
            // lblValidateTableType
            // 
            this.lblValidateTableType.AutoSize = true;
            this.lblValidateTableType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValidateTableType.Location = new System.Drawing.Point(13, 76);
            this.lblValidateTableType.Name = "lblValidateTableType";
            this.lblValidateTableType.Size = new System.Drawing.Size(87, 13);
            this.lblValidateTableType.TabIndex = 6;
            this.lblValidateTableType.Text = "Valid Table Type";
            this.lblValidateTableType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFormat.Location = new System.Drawing.Point(13, 23);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(39, 13);
            this.lblFormat.TabIndex = 5;
            this.lblFormat.Text = "Format";
            this.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSize.Location = new System.Drawing.Point(13, 50);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "Size";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvTableName
            // 
            this.cdvTableName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTableName.BtnToolTipText = "";
            this.cdvTableName.DescText = "";
            this.cdvTableName.DisplaySubItemIndex = -1;
            this.cdvTableName.DisplayText = "";
            this.cdvTableName.Enabled = false;
            this.cdvTableName.Focusing = null;
            this.cdvTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableName.Index = 0;
            this.cdvTableName.IsViewBtnImage = false;
            this.cdvTableName.Location = new System.Drawing.Point(125, 99);
            this.cdvTableName.MaxLength = 20;
            this.cdvTableName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTableName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTableName.Name = "cdvTableName";
            this.cdvTableName.ReadOnly = false;
            this.cdvTableName.SearchSubItemIndex = 0;
            this.cdvTableName.SelectedDescIndex = -1;
            this.cdvTableName.SelectedSubItemIndex = -1;
            this.cdvTableName.SelectionStart = 0;
            this.cdvTableName.Size = new System.Drawing.Size(177, 20);
            this.cdvTableName.SmallImageList = null;
            this.cdvTableName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTableName.TabIndex = 3;
            this.cdvTableName.TextBoxToolTipText = "";
            this.cdvTableName.TextBoxWidth = 177;
            this.cdvTableName.VisibleButton = true;
            this.cdvTableName.VisibleColumnHeader = false;
            this.cdvTableName.VisibleDescription = false;
            this.cdvTableName.ButtonPress += new System.EventHandler(this.cdvTableName_ButtonPress);
            // 
            // lblValidateTable
            // 
            this.lblValidateTable.AutoSize = true;
            this.lblValidateTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValidateTable.Location = new System.Drawing.Point(13, 103);
            this.lblValidateTable.Name = "lblValidateTable";
            this.lblValidateTable.Size = new System.Drawing.Size(75, 13);
            this.lblValidateTable.TabIndex = 2;
            this.lblValidateTable.Text = "Validate Table";
            this.lblValidateTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCheckTop
            // 
            this.pnlCheckTop.Controls.Add(this.grbTable);
            this.pnlCheckTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCheckTop.Location = new System.Drawing.Point(0, 0);
            this.pnlCheckTop.Name = "pnlCheckTop";
            this.pnlCheckTop.Size = new System.Drawing.Size(506, 70);
            this.pnlCheckTop.TabIndex = 0;
            // 
            // grbTable
            // 
            this.grbTable.Controls.Add(this.cdvQueryType);
            this.grbTable.Controls.Add(this.lblDataType);
            this.grbTable.Controls.Add(this.txtQueryID);
            this.grbTable.Controls.Add(this.lblDataCode);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbTable.Location = new System.Drawing.Point(0, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(506, 70);
            this.grbTable.TabIndex = 1;
            this.grbTable.TabStop = false;
            // 
            // cdvQueryType
            // 
            this.cdvQueryType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvQueryType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvQueryType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvQueryType.BtnToolTipText = "";
            this.cdvQueryType.DescText = "";
            this.cdvQueryType.DisplaySubItemIndex = -1;
            this.cdvQueryType.DisplayText = "";
            this.cdvQueryType.Focusing = null;
            this.cdvQueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvQueryType.Index = 0;
            this.cdvQueryType.IsViewBtnImage = false;
            this.cdvQueryType.Location = new System.Drawing.Point(125, 13);
            this.cdvQueryType.MaxLength = 20;
            this.cdvQueryType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvQueryType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvQueryType.Name = "cdvQueryType";
            this.cdvQueryType.ReadOnly = false;
            this.cdvQueryType.SearchSubItemIndex = 0;
            this.cdvQueryType.SelectedDescIndex = -1;
            this.cdvQueryType.SelectedSubItemIndex = -1;
            this.cdvQueryType.SelectionStart = 0;
            this.cdvQueryType.Size = new System.Drawing.Size(177, 20);
            this.cdvQueryType.SmallImageList = null;
            this.cdvQueryType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvQueryType.TabIndex = 1;
            this.cdvQueryType.TextBoxToolTipText = "";
            this.cdvQueryType.TextBoxWidth = 177;
            this.cdvQueryType.VisibleButton = true;
            this.cdvQueryType.VisibleColumnHeader = false;
            this.cdvQueryType.VisibleDescription = false;
            this.cdvQueryType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvQueryType_SelectedItemChanged);
            this.cdvQueryType.ButtonPress += new System.EventHandler(this.cdvQueryType_ButtonPress);
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataType.Location = new System.Drawing.Point(13, 17);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(72, 13);
            this.lblDataType.TabIndex = 0;
            this.lblDataType.Text = "Query Type";
            this.lblDataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQueryID
            // 
            this.txtQueryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueryID.Location = new System.Drawing.Point(125, 39);
            this.txtQueryID.MaxLength = 30;
            this.txtQueryID.Name = "txtQueryID";
            this.txtQueryID.Size = new System.Drawing.Size(177, 20);
            this.txtQueryID.TabIndex = 3;
            // 
            // lblDataCode
            // 
            this.lblDataCode.AutoSize = true;
            this.lblDataCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataCode.Location = new System.Drawing.Point(13, 43);
            this.lblDataCode.Name = "lblDataCode";
            this.lblDataCode.Size = new System.Drawing.Size(73, 13);
            this.lblDataCode.TabIndex = 2;
            this.lblDataCode.Text = "Query Code";
            this.lblDataCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBASSetupCheckQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASSetupCheckQuery";
            this.Text = "Check Query Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupCheckQuery_Activated);
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
            this.grpFuncGroup.ResumeLayout(false);
            this.grpFuncGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            this.pnlCheckQuery.ResumeLayout(false);
            this.pnlCheckTop2.ResumeLayout(false);
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            this.pnlCheckFill.ResumeLayout(false);
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableName)).EndInit();
            this.pnlCheckTop.ResumeLayout(false);
            this.grbTable.ResumeLayout(false);
            this.grbTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvQueryType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFuncGroup;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup;
        private System.Windows.Forms.Label lblGroup;
        private UI.Controls.MCListView.MCListView lisDataCode;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Panel pnlCheckQuery;
        private System.Windows.Forms.Panel pnlCheckTop;
        private System.Windows.Forms.Panel pnlCheckTop2;
        private System.Windows.Forms.GroupBox grbTable;
        private UI.Controls.MCCodeView.MCCodeView cdvQueryType;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.TextBox txtQueryID;
        private System.Windows.Forms.Label lblDataCode;
        private System.Windows.Forms.GroupBox grpQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.Panel pnlCheckFill;
        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.Label lblValidateTableType;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label lblSize;
        private UI.Controls.MCCodeView.MCCodeView cdvTableName;
        private System.Windows.Forms.Label lblValidateTable;
        private System.Windows.Forms.ComboBox cboFormat;
        private System.Windows.Forms.ComboBox cboValTabType;
    }
}