namespace Miracom.RTDCore
{
    partial class frmRTDViewDispatchedPortList
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
            this.lblPort = new System.Windows.Forms.Label();
            this.lisPortList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnselected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkUnselect = new System.Windows.Forms.CheckBox();
            this.chkUncapable = new System.Windows.Forms.CheckBox();
            this.lblResource = new System.Windows.Forms.Label();
            this.cdvResource = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvPort = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboRequestType = new System.Windows.Forms.ComboBox();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlViewTop.Size = new System.Drawing.Size(742, 68);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cboRequestType);
            this.grpOption.Controls.Add(this.cdvPort);
            this.grpOption.Controls.Add(this.cdvResource);
            this.grpOption.Controls.Add(this.lblResource);
            this.grpOption.Controls.Add(this.chkUncapable);
            this.grpOption.Controls.Add(this.chkUnselect);
            this.grpOption.Controls.Add(this.lblPort);
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Size = new System.Drawing.Size(736, 68);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.lisPortList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 68);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 445);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(14, 43);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(40, 13);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port ID";
            // 
            // lisPortList
            // 
            this.lisPortList.AllowColumnReorder = true;
            this.lisPortList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPort,
            this.colRes,
            this.colType,
            this.colScore,
            this.colRule,
            this.colReason,
            this.colUnselected,
            this.colCapable,
            this.colCmf1,
            this.colCmf2,
            this.colCmf3,
            this.colCmf4,
            this.colCmf5,
            this.colCmf6,
            this.colCmf7,
            this.colCmf8,
            this.colCmf9,
            this.colCmf10});
            this.lisPortList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisPortList.EnableSort = true;
            this.lisPortList.EnableSortIcon = true;
            this.lisPortList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisPortList.FullRowSelect = true;
            this.lisPortList.Location = new System.Drawing.Point(3, 3);
            this.lisPortList.Name = "lisPortList";
            this.lisPortList.Size = new System.Drawing.Size(736, 442);
            this.lisPortList.TabIndex = 0;
            this.lisPortList.UseCompatibleStateImageBehavior = false;
            this.lisPortList.View = System.Windows.Forms.View.Details;
            // 
            // colPort
            // 
            this.colPort.Text = "Port ID";
            this.colPort.Width = 100;
            // 
            // colRes
            // 
            this.colRes.Text = "Resource ID";
            this.colRes.Width = 130;
            // 
            // colType
            // 
            this.colType.Text = "Port Type";
            this.colType.Width = 90;
            // 
            // colScore
            // 
            this.colScore.Text = "Priority Score";
            this.colScore.Width = 122;
            // 
            // colRule
            // 
            this.colRule.Text = "Rule ID";
            this.colRule.Width = 120;
            // 
            // colReason
            // 
            this.colReason.Text = "Dispatch Reason";
            this.colReason.Width = 120;
            // 
            // colUnselected
            // 
            this.colUnselected.Text = "Unselected Flag";
            this.colUnselected.Width = 70;
            // 
            // colCapable
            // 
            this.colCapable.Text = "Capable Flag";
            // 
            // colCmf1
            // 
            this.colCmf1.Text = "Port Cmf 1";
            // 
            // colCmf2
            // 
            this.colCmf2.Text = "Port Cmf 2";
            // 
            // colCmf3
            // 
            this.colCmf3.Text = "Port Cmf 3";
            // 
            // colCmf4
            // 
            this.colCmf4.Text = "Port Cmf 4";
            // 
            // colCmf5
            // 
            this.colCmf5.Text = "Port Cmf 5";
            // 
            // colCmf6
            // 
            this.colCmf6.Text = "Port Cmf 6";
            // 
            // colCmf7
            // 
            this.colCmf7.Text = "Port Cmf 7";
            // 
            // colCmf8
            // 
            this.colCmf8.Text = "Port Cmf 8";
            // 
            // colCmf9
            // 
            this.colCmf9.Text = "Port Cmf 9";
            // 
            // colCmf10
            // 
            this.colCmf10.Text = "Port Cmf 10";
            // 
            // chkUnselect
            // 
            this.chkUnselect.AutoSize = true;
            this.chkUnselect.Location = new System.Drawing.Point(373, 39);
            this.chkUnselect.Name = "chkUnselect";
            this.chkUnselect.Size = new System.Drawing.Size(140, 17);
            this.chkUnselect.TabIndex = 2;
            this.chkUnselect.Text = "Include Unselected Port";
            // 
            // chkUncapable
            // 
            this.chkUncapable.AutoSize = true;
            this.chkUncapable.Location = new System.Drawing.Point(555, 39);
            this.chkUncapable.Name = "chkUncapable";
            this.chkUncapable.Size = new System.Drawing.Size(138, 17);
            this.chkUncapable.TabIndex = 3;
            this.chkUncapable.Text = "Include Uncapable Port";
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResource.Location = new System.Drawing.Point(14, 16);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(67, 13);
            this.lblResource.TabIndex = 4;
            this.lblResource.Text = "Resource ID";
            // 
            // cdvResource
            // 
            this.cdvResource.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResource.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResource.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResource.BtnToolTipText = "";
            this.cdvResource.ButtonWidth = 20;
            this.cdvResource.DescText = "";
            this.cdvResource.DisplaySubItemIndex = -1;
            this.cdvResource.DisplayText = "";
            this.cdvResource.Focusing = null;
            this.cdvResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResource.Index = 0;
            this.cdvResource.IsViewBtnImage = false;
            this.cdvResource.Location = new System.Drawing.Point(119, 13);
            this.cdvResource.MaxLength = 20;
            this.cdvResource.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResource.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResource.MultiSelect = false;
            this.cdvResource.Name = "cdvResource";
            this.cdvResource.ReadOnly = false;
            this.cdvResource.SameWidthHeightOfButton = false;
            this.cdvResource.SearchSubItemIndex = 0;
            this.cdvResource.SelectedDescIndex = -1;
            this.cdvResource.SelectedDescToQueryText = "";
            this.cdvResource.SelectedSubItemIndex = -1;
            this.cdvResource.SelectedValueToQueryText = "";
            this.cdvResource.SelectionStart = 0;
            this.cdvResource.Size = new System.Drawing.Size(200, 20);
            this.cdvResource.SmallImageList = null;
            this.cdvResource.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResource.TabIndex = 5;
            this.cdvResource.TextBoxToolTipText = "";
            this.cdvResource.TextBoxWidth = 200;
            this.cdvResource.VisibleButton = true;
            this.cdvResource.VisibleColumnHeader = false;
            this.cdvResource.VisibleDescription = false;
            this.cdvResource.ButtonPress += new System.EventHandler(this.cdvResource_ButtonPress);
            this.cdvResource.TextBoxTextChanged += new System.EventHandler(this.cdvResource_TextBoxTextChanged);
            // 
            // cdvPort
            // 
            this.cdvPort.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPort.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPort.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPort.BtnToolTipText = "";
            this.cdvPort.ButtonWidth = 20;
            this.cdvPort.DescText = "";
            this.cdvPort.DisplaySubItemIndex = -1;
            this.cdvPort.DisplayText = "";
            this.cdvPort.Focusing = null;
            this.cdvPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPort.Index = 0;
            this.cdvPort.IsViewBtnImage = false;
            this.cdvPort.Location = new System.Drawing.Point(119, 38);
            this.cdvPort.MaxLength = 10;
            this.cdvPort.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPort.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPort.MultiSelect = false;
            this.cdvPort.Name = "cdvPort";
            this.cdvPort.ReadOnly = false;
            this.cdvPort.SameWidthHeightOfButton = false;
            this.cdvPort.SearchSubItemIndex = 0;
            this.cdvPort.SelectedDescIndex = -1;
            this.cdvPort.SelectedDescToQueryText = "";
            this.cdvPort.SelectedSubItemIndex = -1;
            this.cdvPort.SelectedValueToQueryText = "";
            this.cdvPort.SelectionStart = 0;
            this.cdvPort.Size = new System.Drawing.Size(200, 20);
            this.cdvPort.SmallImageList = null;
            this.cdvPort.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPort.TabIndex = 6;
            this.cdvPort.TextBoxToolTipText = "";
            this.cdvPort.TextBoxWidth = 200;
            this.cdvPort.VisibleButton = true;
            this.cdvPort.VisibleColumnHeader = false;
            this.cdvPort.VisibleDescription = false;
            this.cdvPort.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPort_SelectedItemChanged);
            this.cdvPort.ButtonPress += new System.EventHandler(this.cdvPort_ButtonPress);
            // 
            // cboRequestType
            // 
            this.cboRequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRequestType.Items.AddRange(new object[] {
            "Unload Request",
            "Material Request",
            "Carrier Ready",
            "Process 4"});
            this.cboRequestType.Location = new System.Drawing.Point(373, 13);
            this.cboRequestType.Name = "cboRequestType";
            this.cboRequestType.Size = new System.Drawing.Size(140, 21);
            this.cboRequestType.TabIndex = 7;
            // 
            // frmRTDViewDispatchedPortList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRTDViewDispatchedPortList";
            this.Text = "View Dispatched Port List";
            this.Load += new System.EventHandler(this.frmRTDViewDispatchedPortList_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvResource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private Miracom.UI.Controls.MCListView.MCListView lisPortList;
        private System.Windows.Forms.ColumnHeader colPort;
        private System.Windows.Forms.ColumnHeader colRes;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colScore;
        private System.Windows.Forms.ColumnHeader colRule;
        private System.Windows.Forms.ColumnHeader colReason;
        private System.Windows.Forms.ColumnHeader colUnselected;
        private System.Windows.Forms.CheckBox chkUnselect;
        private System.Windows.Forms.CheckBox chkUncapable;
        private System.Windows.Forms.ColumnHeader colCapable;
        private System.Windows.Forms.ColumnHeader colCmf1;
        private System.Windows.Forms.ColumnHeader colCmf2;
        private System.Windows.Forms.ColumnHeader colCmf3;
        private System.Windows.Forms.ColumnHeader colCmf4;
        private System.Windows.Forms.ColumnHeader colCmf5;
        private System.Windows.Forms.ColumnHeader colCmf6;
        private System.Windows.Forms.ColumnHeader colCmf7;
        private System.Windows.Forms.ColumnHeader colCmf8;
        private System.Windows.Forms.ColumnHeader colCmf9;
        private System.Windows.Forms.ColumnHeader colCmf10;
        private System.Windows.Forms.Label lblResource;
        private UI.Controls.MCCodeView.MCCodeView cdvResource;
        private UI.Controls.MCCodeView.MCCodeView cdvPort;
        private System.Windows.Forms.ComboBox cboRequestType;
    }
}
