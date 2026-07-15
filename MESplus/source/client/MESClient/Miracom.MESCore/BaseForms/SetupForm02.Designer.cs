namespace Miracom.MESCore
{
    partial class SetupForm02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm02));
            this.pnlFind = new System.Windows.Forms.Panel();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.lblDataCountBase = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.pnlLeftMain = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnFilterView = new System.Windows.Forms.Button();
            this.rbnNoFilter = new System.Windows.Forms.RadioButton();
            this.rbnFilter = new System.Windows.Forms.RadioButton();
            this.splMain = new System.Windows.Forms.Splitter();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.toolTipSetupForm2 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlFind.SuspendLayout();
            this.pnlLeftMain.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 4;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlFind);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlRight);
            this.pnlCenter.Controls.Add(this.splMain);
            this.pnlCenter.Controls.Add(this.pnlLeftMain);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm01";
            // 
            // pnlFind
            // 
            this.pnlFind.Controls.Add(this.lblDataCount);
            this.pnlFind.Controls.Add(this.lblDataCountBase);
            this.pnlFind.Controls.Add(this.btnExcel);
            this.pnlFind.Controls.Add(this.btnRefresh);
            this.pnlFind.Controls.Add(this.btnNext);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFind.Location = new System.Drawing.Point(0, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(232, 40);
            this.pnlFind.TabIndex = 0;
            // 
            // lblDataCount
            // 
            this.lblDataCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCount.Location = new System.Drawing.Point(5, 13);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(40, 12);
            this.lblDataCount.TabIndex = 1;
            this.lblDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTipSetupForm2.SetToolTip(this.lblDataCount, "Count of items");
            // 
            // lblDataCountBase
            // 
            this.lblDataCountBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDataCountBase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCountBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCountBase.Location = new System.Drawing.Point(4, 9);
            this.lblDataCountBase.Name = "lblDataCountBase";
            this.lblDataCountBase.Size = new System.Drawing.Size(42, 21);
            this.lblDataCountBase.TabIndex = 0;
            this.lblDataCountBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(200, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 5;
            this.toolTipSetupForm2.SetToolTip(this.btnExcel, "Export to excel");
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(174, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            this.toolTipSetupForm2.SetToolTip(this.btnRefresh, "Refresh list");
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(148, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 3;
            this.toolTipSetupForm2.SetToolTip(this.btnNext, "Find next item");
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(48, 9);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(96, 20);
            this.txtFind.TabIndex = 2;
            this.toolTipSetupForm2.SetToolTip(this.txtFind, "Find text\r\nIf you want to find from other columns except first column,\r\n$[column]" +
        ":[text] type this.");
            // 
            // pnlLeftMain
            // 
            this.pnlLeftMain.Controls.Add(this.pnlLeft);
            this.pnlLeftMain.Controls.Add(this.pnlFilter);
            this.pnlLeftMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftMain.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftMain.Name = "pnlLeftMain";
            this.pnlLeftMain.Size = new System.Drawing.Size(232, 506);
            this.pnlLeftMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 38);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(232, 468);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.pnlFilter.Size = new System.Drawing.Size(232, 38);
            this.pnlFilter.TabIndex = 0;
            this.pnlFilter.Visible = false;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.txtFilter);
            this.grpFilter.Controls.Add(this.btnFilterView);
            this.grpFilter.Controls.Add(this.rbnNoFilter);
            this.grpFilter.Controls.Add(this.rbnFilter);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(232, 36);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(26, 11);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 20);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // btnFilterView
            // 
            this.btnFilterView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFilterView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFilterView.Location = new System.Drawing.Point(184, 11);
            this.btnFilterView.Name = "btnFilterView";
            this.btnFilterView.Size = new System.Drawing.Size(36, 20);
            this.btnFilterView.TabIndex = 3;
            this.btnFilterView.Text = "View";
            // 
            // rbnNoFilter
            // 
            this.rbnNoFilter.Location = new System.Drawing.Point(131, 14);
            this.rbnNoFilter.Name = "rbnNoFilter";
            this.rbnNoFilter.Size = new System.Drawing.Size(49, 15);
            this.rbnNoFilter.TabIndex = 2;
            this.rbnNoFilter.Text = "All";
            this.rbnNoFilter.CheckedChanged += new System.EventHandler(this.rbnNoFilter_CheckedChanged);
            // 
            // rbnFilter
            // 
            this.rbnFilter.Checked = true;
            this.rbnFilter.Location = new System.Drawing.Point(8, 14);
            this.rbnFilter.Name = "rbnFilter";
            this.rbnFilter.Size = new System.Drawing.Size(16, 14);
            this.rbnFilter.TabIndex = 0;
            this.rbnFilter.TabStop = true;
            this.rbnFilter.CheckedChanged += new System.EventHandler(this.rbnFilter_CheckedChanged);
            // 
            // splMain
            // 
            this.splMain.BackColor = System.Drawing.SystemColors.Control;
            this.splMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splMain.Location = new System.Drawing.Point(232, 0);
            this.splMain.Name = "splMain";
            this.splMain.Size = new System.Drawing.Size(4, 506);
            this.splMain.TabIndex = 0;
            this.splMain.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(236, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(506, 506);
            this.pnlRight.TabIndex = 1;
            // 
            // toolTipSetupForm2
            // 
            this.toolTipSetupForm2.AutoPopDelay = 10000;
            this.toolTipSetupForm2.InitialDelay = 500;
            this.toolTipSetupForm2.ReshowDelay = 100;
            // 
            // SetupForm02
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "SetupForm02";
            this.Text = "SetupForm02";
            this.Load += new System.EventHandler(this.SetupForm02_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlLeftMain.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlFind;
        protected System.Windows.Forms.Label lblDataCount;
        protected System.Windows.Forms.Label lblDataCountBase;
        protected System.Windows.Forms.Button btnExcel;
        protected System.Windows.Forms.Button btnRefresh;
        protected System.Windows.Forms.Button btnNext;
        protected System.Windows.Forms.TextBox txtFind;
        protected System.Windows.Forms.Splitter splMain;
        protected System.Windows.Forms.Panel pnlRight;
        protected System.Windows.Forms.Panel pnlFilter;
        protected System.Windows.Forms.GroupBox grpFilter;
        protected System.Windows.Forms.Button btnFilterView;
        protected System.Windows.Forms.RadioButton rbnNoFilter;
        protected System.Windows.Forms.RadioButton rbnFilter;
        private System.Windows.Forms.Panel pnlLeftMain;
        protected System.Windows.Forms.Panel pnlLeft;
        protected System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ToolTip toolTipSetupForm2;
    }
}
