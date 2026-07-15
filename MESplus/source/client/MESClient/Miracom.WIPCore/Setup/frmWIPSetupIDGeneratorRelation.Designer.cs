namespace Miracom.WIPCore
{
    partial class frmWIPSetupIDGeneratorRelation
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
            this.tabRelation = new System.Windows.Forms.TabControl();
            this.tbpMFO = new System.Windows.Forms.TabPage();
            this.udcMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.tbpRes = new System.Windows.Forms.TabPage();
            this.lisRule = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvTranCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvKey5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTranCode = new System.Windows.Forms.Label();
            this.lblKey5 = new System.Windows.Forms.Label();
            this.cdvKey4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey4 = new System.Windows.Forms.Label();
            this.cdvKey3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey3 = new System.Windows.Forms.Label();
            this.cdvKey2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.cdvKey1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.grpTRAN = new System.Windows.Forms.GroupBox();
            this.cdvRule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRule = new System.Windows.Forms.Label();
            this.cdvGenType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGenType = new System.Windows.Forms.Label();
            this.udcRes = new Miracom.MESCore.Controls.udcResourceTreeList01();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabRelation.SuspendLayout();
            this.tbpMFO.SuspendLayout();
            this.tbpRes.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTranCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey1)).BeginInit();
            this.grpTRAN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGenType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpTRAN);
            this.pnlRight.Controls.Add(this.grpCMF);
            this.pnlRight.Controls.Add(this.lisRule);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tabRelation);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // tabRelation
            // 
            this.tabRelation.Controls.Add(this.tbpMFO);
            this.tabRelation.Controls.Add(this.tbpRes);
            this.tabRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRelation.Location = new System.Drawing.Point(3, 0);
            this.tabRelation.Name = "tabRelation";
            this.tabRelation.SelectedIndex = 0;
            this.tabRelation.Size = new System.Drawing.Size(226, 506);
            this.tabRelation.TabIndex = 0;
            this.tabRelation.SelectedIndexChanged += new System.EventHandler(this.tabRelation_SelectedIndexChanged);
            // 
            // tbpMFO
            // 
            this.tbpMFO.Controls.Add(this.udcMFO);
            this.tbpMFO.Location = new System.Drawing.Point(4, 22);
            this.tbpMFO.Name = "tbpMFO";
            this.tbpMFO.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMFO.Size = new System.Drawing.Size(218, 480);
            this.tbpMFO.TabIndex = 0;
            this.tbpMFO.Text = "MFO";
            // 
            // udcMFO
            // 
            this.udcMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMFO.IncludeFlowSeqNum = false;
            this.udcMFO.ListCond_ExtFactory = "";
            this.udcMFO.ListCond_Step = '1';
            this.udcMFO.Location = new System.Drawing.Point(3, 3);
            this.udcMFO.MaterialType = "";
            this.udcMFO.Name = "udcMFO";
            this.udcMFO.Size = new System.Drawing.Size(212, 474);
            this.udcMFO.TabIndex = 0;
            this.udcMFO.VisibleLevel1MFO = true;
            this.udcMFO.VisibleLevel2FO = true;
            this.udcMFO.VisibleLevel3O = true;
            this.udcMFO.VisibleLevel4MO = true;
            this.udcMFO.VisibleLevel5MF = false;
            this.udcMFO.VisibleLevel6M = false;
            this.udcMFO.VisibleLevel7F = false;
            this.udcMFO.VisibleLevel8Factory = true;
            this.udcMFO.VisibleMaterialIncludeDeleteCheck = false;
            this.udcMFO.VisibleMaterialType = false;
            this.udcMFO.VisibleOnlySetData = true;
            this.udcMFO.VisibleViewType = true;
            this.udcMFO.AfterGetTree += new System.EventHandler(this.udcMFO_AfterGetTree);
            this.udcMFO.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcMFO_AfterSelect);
            this.udcMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcMFO_LevelItemSelect);
            this.udcMFO.GetOnlySetData += new System.EventHandler(this.udcMFO_GetOnlySetData);
            this.udcMFO.SetDataSelectedIndexChanged += new System.EventHandler(this.udcMFO_SetDataSelectedIndexChanged);
            // 
            // tbpRes
            // 
            this.tbpRes.Controls.Add(this.udcRes);
            this.tbpRes.Location = new System.Drawing.Point(4, 22);
            this.tbpRes.Name = "tbpRes";
            this.tbpRes.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRes.Size = new System.Drawing.Size(218, 480);
            this.tbpRes.TabIndex = 1;
            this.tbpRes.Text = "Resource";
            // 
            // lisRule
            // 
            this.lisRule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lisRule.Dock = System.Windows.Forms.DockStyle.Top;
            this.lisRule.EnableSort = true;
            this.lisRule.EnableSortIcon = true;
            this.lisRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRule.FullRowSelect = true;
            this.lisRule.Location = new System.Drawing.Point(3, 3);
            this.lisRule.MultiSelect = false;
            this.lisRule.Name = "lisRule";
            this.lisRule.Size = new System.Drawing.Size(500, 245);
            this.lisRule.TabIndex = 0;
            this.lisRule.UseCompatibleStateImageBehavior = false;
            this.lisRule.View = System.Windows.Forms.View.Details;
            this.lisRule.SelectedIndexChanged += new System.EventHandler(this.lisRule_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Rule ID";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Tran Code";
            this.columnHeader37.Width = 80;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Key1";
            this.columnHeader38.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key2";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Key3";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Key4";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Key5";
            this.columnHeader4.Width = 80;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvTranCode);
            this.grpCMF.Controls.Add(this.cdvKey5);
            this.grpCMF.Controls.Add(this.lblTranCode);
            this.grpCMF.Controls.Add(this.lblKey5);
            this.grpCMF.Controls.Add(this.cdvKey4);
            this.grpCMF.Controls.Add(this.lblKey4);
            this.grpCMF.Controls.Add(this.cdvKey3);
            this.grpCMF.Controls.Add(this.lblKey3);
            this.grpCMF.Controls.Add(this.cdvKey2);
            this.grpCMF.Controls.Add(this.lblKey2);
            this.grpCMF.Controls.Add(this.cdvKey1);
            this.grpCMF.Controls.Add(this.lblKey1);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCMF.Location = new System.Drawing.Point(3, 248);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(500, 183);
            this.grpCMF.TabIndex = 1;
            this.grpCMF.TabStop = false;
            // 
            // cdvTranCode
            // 
            this.cdvTranCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTranCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTranCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTranCode.BtnToolTipText = "";
            this.cdvTranCode.DescText = "";
            this.cdvTranCode.DisplaySubItemIndex = -1;
            this.cdvTranCode.DisplayText = "";
            this.cdvTranCode.Focusing = null;
            this.cdvTranCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTranCode.Index = 0;
            this.cdvTranCode.IsViewBtnImage = false;
            this.cdvTranCode.Location = new System.Drawing.Point(188, 20);
            this.cdvTranCode.MaxLength = 12;
            this.cdvTranCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTranCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTranCode.Name = "cdvTranCode";
            this.cdvTranCode.ReadOnly = true;
            this.cdvTranCode.SearchSubItemIndex = 0;
            this.cdvTranCode.SelectedDescIndex = -1;
            this.cdvTranCode.SelectedSubItemIndex = -1;
            this.cdvTranCode.SelectionStart = 0;
            this.cdvTranCode.Size = new System.Drawing.Size(153, 20);
            this.cdvTranCode.SmallImageList = null;
            this.cdvTranCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTranCode.TabIndex = 33;
            this.cdvTranCode.TextBoxToolTipText = "";
            this.cdvTranCode.TextBoxWidth = 153;
            this.cdvTranCode.VisibleButton = true;
            this.cdvTranCode.VisibleColumnHeader = false;
            this.cdvTranCode.VisibleDescription = false;
            this.cdvTranCode.ButtonPress += new System.EventHandler(this.cdvTranCode_ButtonPress);
            // 
            // cdvKey5
            // 
            this.cdvKey5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey5.BtnToolTipText = "";
            this.cdvKey5.DescText = "";
            this.cdvKey5.DisplaySubItemIndex = -1;
            this.cdvKey5.DisplayText = "";
            this.cdvKey5.Focusing = null;
            this.cdvKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey5.Index = 0;
            this.cdvKey5.IsViewBtnImage = false;
            this.cdvKey5.Location = new System.Drawing.Point(188, 145);
            this.cdvKey5.MaxLength = 30;
            this.cdvKey5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey5.Name = "cdvKey5";
            this.cdvKey5.ReadOnly = true;
            this.cdvKey5.SearchSubItemIndex = 0;
            this.cdvKey5.SelectedDescIndex = -1;
            this.cdvKey5.SelectedSubItemIndex = -1;
            this.cdvKey5.SelectionStart = 0;
            this.cdvKey5.Size = new System.Drawing.Size(153, 20);
            this.cdvKey5.SmallImageList = null;
            this.cdvKey5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey5.TabIndex = 43;
            this.cdvKey5.TextBoxToolTipText = "";
            this.cdvKey5.TextBoxWidth = 153;
            this.cdvKey5.VisibleButton = true;
            this.cdvKey5.VisibleColumnHeader = false;
            this.cdvKey5.VisibleDescription = false;
            this.cdvKey5.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // lblTranCode
            // 
            this.lblTranCode.AutoSize = true;
            this.lblTranCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTranCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranCode.Location = new System.Drawing.Point(21, 27);
            this.lblTranCode.Name = "lblTranCode";
            this.lblTranCode.Size = new System.Drawing.Size(74, 13);
            this.lblTranCode.TabIndex = 32;
            this.lblTranCode.Text = "Transaction";
            this.lblTranCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKey5
            // 
            this.lblKey5.AutoSize = true;
            this.lblKey5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey5.Location = new System.Drawing.Point(21, 152);
            this.lblKey5.Name = "lblKey5";
            this.lblKey5.Size = new System.Drawing.Size(31, 13);
            this.lblKey5.TabIndex = 42;
            this.lblKey5.Text = "Key5";
            this.lblKey5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvKey4
            // 
            this.cdvKey4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey4.BtnToolTipText = "";
            this.cdvKey4.DescText = "";
            this.cdvKey4.DisplaySubItemIndex = -1;
            this.cdvKey4.DisplayText = "";
            this.cdvKey4.Focusing = null;
            this.cdvKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey4.Index = 0;
            this.cdvKey4.IsViewBtnImage = false;
            this.cdvKey4.Location = new System.Drawing.Point(188, 120);
            this.cdvKey4.MaxLength = 30;
            this.cdvKey4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey4.Name = "cdvKey4";
            this.cdvKey4.ReadOnly = true;
            this.cdvKey4.SearchSubItemIndex = 0;
            this.cdvKey4.SelectedDescIndex = -1;
            this.cdvKey4.SelectedSubItemIndex = -1;
            this.cdvKey4.SelectionStart = 0;
            this.cdvKey4.Size = new System.Drawing.Size(153, 20);
            this.cdvKey4.SmallImageList = null;
            this.cdvKey4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey4.TabIndex = 41;
            this.cdvKey4.TextBoxToolTipText = "";
            this.cdvKey4.TextBoxWidth = 153;
            this.cdvKey4.VisibleButton = true;
            this.cdvKey4.VisibleColumnHeader = false;
            this.cdvKey4.VisibleDescription = false;
            this.cdvKey4.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // lblKey4
            // 
            this.lblKey4.AutoSize = true;
            this.lblKey4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey4.Location = new System.Drawing.Point(21, 127);
            this.lblKey4.Name = "lblKey4";
            this.lblKey4.Size = new System.Drawing.Size(31, 13);
            this.lblKey4.TabIndex = 40;
            this.lblKey4.Text = "Key4";
            this.lblKey4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvKey3
            // 
            this.cdvKey3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey3.BtnToolTipText = "";
            this.cdvKey3.DescText = "";
            this.cdvKey3.DisplaySubItemIndex = -1;
            this.cdvKey3.DisplayText = "";
            this.cdvKey3.Focusing = null;
            this.cdvKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey3.Index = 0;
            this.cdvKey3.IsViewBtnImage = false;
            this.cdvKey3.Location = new System.Drawing.Point(188, 95);
            this.cdvKey3.MaxLength = 30;
            this.cdvKey3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey3.Name = "cdvKey3";
            this.cdvKey3.ReadOnly = true;
            this.cdvKey3.SearchSubItemIndex = 0;
            this.cdvKey3.SelectedDescIndex = -1;
            this.cdvKey3.SelectedSubItemIndex = -1;
            this.cdvKey3.SelectionStart = 0;
            this.cdvKey3.Size = new System.Drawing.Size(153, 20);
            this.cdvKey3.SmallImageList = null;
            this.cdvKey3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey3.TabIndex = 39;
            this.cdvKey3.TextBoxToolTipText = "";
            this.cdvKey3.TextBoxWidth = 153;
            this.cdvKey3.VisibleButton = true;
            this.cdvKey3.VisibleColumnHeader = false;
            this.cdvKey3.VisibleDescription = false;
            this.cdvKey3.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // lblKey3
            // 
            this.lblKey3.AutoSize = true;
            this.lblKey3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey3.Location = new System.Drawing.Point(21, 102);
            this.lblKey3.Name = "lblKey3";
            this.lblKey3.Size = new System.Drawing.Size(31, 13);
            this.lblKey3.TabIndex = 38;
            this.lblKey3.Text = "Key3";
            this.lblKey3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvKey2
            // 
            this.cdvKey2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey2.BtnToolTipText = "";
            this.cdvKey2.DescText = "";
            this.cdvKey2.DisplaySubItemIndex = -1;
            this.cdvKey2.DisplayText = "";
            this.cdvKey2.Focusing = null;
            this.cdvKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey2.Index = 0;
            this.cdvKey2.IsViewBtnImage = false;
            this.cdvKey2.Location = new System.Drawing.Point(188, 70);
            this.cdvKey2.MaxLength = 30;
            this.cdvKey2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey2.Name = "cdvKey2";
            this.cdvKey2.ReadOnly = true;
            this.cdvKey2.SearchSubItemIndex = 0;
            this.cdvKey2.SelectedDescIndex = -1;
            this.cdvKey2.SelectedSubItemIndex = -1;
            this.cdvKey2.SelectionStart = 0;
            this.cdvKey2.Size = new System.Drawing.Size(153, 20);
            this.cdvKey2.SmallImageList = null;
            this.cdvKey2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey2.TabIndex = 37;
            this.cdvKey2.TextBoxToolTipText = "";
            this.cdvKey2.TextBoxWidth = 153;
            this.cdvKey2.VisibleButton = true;
            this.cdvKey2.VisibleColumnHeader = false;
            this.cdvKey2.VisibleDescription = false;
            this.cdvKey2.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey2.Location = new System.Drawing.Point(21, 77);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(31, 13);
            this.lblKey2.TabIndex = 36;
            this.lblKey2.Text = "Key2";
            this.lblKey2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvKey1
            // 
            this.cdvKey1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey1.BtnToolTipText = "";
            this.cdvKey1.DescText = "";
            this.cdvKey1.DisplaySubItemIndex = -1;
            this.cdvKey1.DisplayText = "";
            this.cdvKey1.Focusing = null;
            this.cdvKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey1.Index = 0;
            this.cdvKey1.IsViewBtnImage = false;
            this.cdvKey1.Location = new System.Drawing.Point(188, 45);
            this.cdvKey1.MaxLength = 30;
            this.cdvKey1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey1.Name = "cdvKey1";
            this.cdvKey1.ReadOnly = true;
            this.cdvKey1.SearchSubItemIndex = 0;
            this.cdvKey1.SelectedDescIndex = -1;
            this.cdvKey1.SelectedSubItemIndex = -1;
            this.cdvKey1.SelectionStart = 0;
            this.cdvKey1.Size = new System.Drawing.Size(153, 20);
            this.cdvKey1.SmallImageList = null;
            this.cdvKey1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey1.TabIndex = 35;
            this.cdvKey1.TextBoxToolTipText = "";
            this.cdvKey1.TextBoxWidth = 153;
            this.cdvKey1.VisibleButton = true;
            this.cdvKey1.VisibleColumnHeader = false;
            this.cdvKey1.VisibleDescription = false;
            this.cdvKey1.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey1.Location = new System.Drawing.Point(21, 52);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(31, 13);
            this.lblKey1.TabIndex = 34;
            this.lblKey1.Text = "Key1";
            this.lblKey1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpTRAN
            // 
            this.grpTRAN.Controls.Add(this.cdvRule);
            this.grpTRAN.Controls.Add(this.lblRule);
            this.grpTRAN.Controls.Add(this.cdvGenType);
            this.grpTRAN.Controls.Add(this.lblGenType);
            this.grpTRAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTRAN.Location = new System.Drawing.Point(3, 431);
            this.grpTRAN.Name = "grpTRAN";
            this.grpTRAN.Size = new System.Drawing.Size(500, 72);
            this.grpTRAN.TabIndex = 2;
            this.grpTRAN.TabStop = false;
            // 
            // cdvRule
            // 
            this.cdvRule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRule.BtnToolTipText = "";
            this.cdvRule.DescText = "";
            this.cdvRule.DisplaySubItemIndex = -1;
            this.cdvRule.DisplayText = "";
            this.cdvRule.Focusing = null;
            this.cdvRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRule.Index = 0;
            this.cdvRule.IsViewBtnImage = false;
            this.cdvRule.Location = new System.Drawing.Point(188, 43);
            this.cdvRule.MaxLength = 30;
            this.cdvRule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRule.Name = "cdvRule";
            this.cdvRule.ReadOnly = true;
            this.cdvRule.SearchSubItemIndex = 0;
            this.cdvRule.SelectedDescIndex = -1;
            this.cdvRule.SelectedSubItemIndex = -1;
            this.cdvRule.SelectionStart = 0;
            this.cdvRule.Size = new System.Drawing.Size(153, 20);
            this.cdvRule.SmallImageList = null;
            this.cdvRule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRule.TabIndex = 35;
            this.cdvRule.TextBoxToolTipText = "";
            this.cdvRule.TextBoxWidth = 153;
            this.cdvRule.VisibleButton = true;
            this.cdvRule.VisibleColumnHeader = false;
            this.cdvRule.VisibleDescription = false;
            this.cdvRule.ButtonPress += new System.EventHandler(this.cdvRule_ButtonPress);
            // 
            // lblRule
            // 
            this.lblRule.AutoSize = true;
            this.lblRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRule.Location = new System.Drawing.Point(21, 50);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new System.Drawing.Size(50, 13);
            this.lblRule.TabIndex = 34;
            this.lblRule.Text = "Rule ID";
            this.lblRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvGenType
            // 
            this.cdvGenType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGenType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGenType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGenType.BtnToolTipText = "";
            this.cdvGenType.DescText = "";
            this.cdvGenType.DisplaySubItemIndex = -1;
            this.cdvGenType.DisplayText = "";
            this.cdvGenType.Focusing = null;
            this.cdvGenType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGenType.Index = 0;
            this.cdvGenType.IsViewBtnImage = false;
            this.cdvGenType.Location = new System.Drawing.Point(188, 18);
            this.cdvGenType.MaxLength = 1;
            this.cdvGenType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGenType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGenType.Name = "cdvGenType";
            this.cdvGenType.ReadOnly = true;
            this.cdvGenType.SearchSubItemIndex = 0;
            this.cdvGenType.SelectedDescIndex = -1;
            this.cdvGenType.SelectedSubItemIndex = -1;
            this.cdvGenType.SelectionStart = 0;
            this.cdvGenType.Size = new System.Drawing.Size(153, 20);
            this.cdvGenType.SmallImageList = null;
            this.cdvGenType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGenType.TabIndex = 33;
            this.cdvGenType.TextBoxToolTipText = "";
            this.cdvGenType.TextBoxWidth = 153;
            this.cdvGenType.VisibleButton = true;
            this.cdvGenType.VisibleColumnHeader = false;
            this.cdvGenType.VisibleDescription = false;
            this.cdvGenType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblGenType
            // 
            this.lblGenType.AutoSize = true;
            this.lblGenType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGenType.Location = new System.Drawing.Point(21, 25);
            this.lblGenType.Name = "lblGenType";
            this.lblGenType.Size = new System.Drawing.Size(124, 13);
            this.lblGenType.TabIndex = 32;
            this.lblGenType.Text = "Generator Type For Filter";
            this.lblGenType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcRes
            // 
            this.udcRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcRes.ListCond_ExtFactory = "";
            this.udcRes.ListCond_Step = '1';
            this.udcRes.Location = new System.Drawing.Point(3, 3);
            this.udcRes.Name = "udcRes";
            this.udcRes.Size = new System.Drawing.Size(212, 474);
            this.udcRes.TabIndex = 0;
            this.udcRes.VisibleLevel1R = true;
            this.udcRes.VisibleLevel2G = true;
            this.udcRes.VisibleLevel3T = true;
            this.udcRes.VisibleOnlySetData = true;
            this.udcRes.VisibleResourceIncludeDeleteCheck = false;
            this.udcRes.AfterGetTree += new System.EventHandler(this.udcRes_AfterGetTree);
            this.udcRes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcRes_AfterSelect);
            this.udcRes.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcRes_LevelItemSelect);
            this.udcRes.GetOnlySetData += new System.EventHandler(this.udcRes_GetOnlySetData);
            this.udcRes.SetDataSelectedIndexChanged += new System.EventHandler(this.udcRes_SetDataSelectedIndexChanged);
            // 
            // frmWIPSetupIDGeneratorRelation
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupIDGeneratorRelation";
            this.Text = "ID Generator Relation Setup";
            this.Load += new System.EventHandler(this.frmWIPSetupIDGeneratorRelation_Load);
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
            this.tabRelation.ResumeLayout(false);
            this.tbpMFO.ResumeLayout(false);
            this.tbpRes.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            this.grpCMF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTranCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey1)).EndInit();
            this.grpTRAN.ResumeLayout(false);
            this.grpTRAN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGenType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRelation;
        private System.Windows.Forms.TabPage tbpMFO;
        private Miracom.MESCore.Controls.udcMFOTreeList udcMFO;
        private System.Windows.Forms.TabPage tbpRes;
        private Miracom.UI.Controls.MCListView.MCListView lisRule;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox grpCMF;
        private System.Windows.Forms.GroupBox grpTRAN;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRule;
        private System.Windows.Forms.Label lblRule;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGenType;
        private System.Windows.Forms.Label lblGenType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTranCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey5;
        private System.Windows.Forms.Label lblTranCode;
        private System.Windows.Forms.Label lblKey5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey4;
        private System.Windows.Forms.Label lblKey4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey3;
        private System.Windows.Forms.Label lblKey3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey2;
        private System.Windows.Forms.Label lblKey2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey1;
        private System.Windows.Forms.Label lblKey1;
        private MESCore.Controls.udcResourceTreeList01 udcRes;
    }
}
