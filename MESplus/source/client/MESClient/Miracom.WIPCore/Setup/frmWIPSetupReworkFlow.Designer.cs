namespace Miracom.WIPCore
{
    partial class frmWIPSetupReworkFlow
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
            this.tvMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.pnlRwkList = new System.Windows.Forms.Panel();
            this.lisRwkList = new System.Windows.Forms.ListView();
            this.colRwkFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkFlowSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkStopOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRetFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRetFlowSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRetOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRetOption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlRwkInfo = new System.Windows.Forms.Panel();
            this.grpRetInfo = new System.Windows.Forms.GroupBox();
            this.lblReturnOption = new System.Windows.Forms.Label();
            this.cboReturnOption = new System.Windows.Forms.ComboBox();
            this.cdvReturnOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvReturnFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.grpRwkInfo = new System.Windows.Forms.GroupBox();
            this.cdvReworkStopOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvReworkOper = new Miracom.MESCore.Controls.udcOperation();
            this.txtReworkCode = new System.Windows.Forms.TextBox();
            this.cdvReworkFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.lblReworkCode = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlRwkList.SuspendLayout();
            this.pnlRwkInfo.SuspendLayout();
            this.grpRetInfo.SuspendLayout();
            this.grpRwkInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
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
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlRwkInfo);
            this.pnlRight.Controls.Add(this.pnlRwkList);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvMFO);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
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
            // tvMFO
            // 
            this.tvMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMFO.IncludeFlowSeqNum = false;
            this.tvMFO.ListCond_ExtFactory = "";
            this.tvMFO.ListCond_Step = '1';
            this.tvMFO.Location = new System.Drawing.Point(0, 0);
            this.tvMFO.MaterialType = "";
            this.tvMFO.Name = "tvMFO";
            this.tvMFO.Size = new System.Drawing.Size(232, 506);
            this.tvMFO.TabIndex = 0;
            this.tvMFO.VisibleLevel1MFO = true;
            this.tvMFO.VisibleLevel2FO = true;
            this.tvMFO.VisibleLevel3O = true;
            this.tvMFO.VisibleLevel4MO = false;
            this.tvMFO.VisibleLevel5MF = false;
            this.tvMFO.VisibleLevel6M = false;
            this.tvMFO.VisibleLevel7F = false;
            this.tvMFO.VisibleLevel8Factory = false;
            this.tvMFO.VisibleMaterialIncludeDeleteCheck = false;
            this.tvMFO.VisibleMaterialType = false;
            this.tvMFO.VisibleOnlySetData = true;
            this.tvMFO.VisibleViewType = true;
            this.tvMFO.AfterGetTree += new System.EventHandler(this.tvMFO_AfterGetTree);
            this.tvMFO.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_AfterSelect);
            this.tvMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_LevelItemSelect);
            this.tvMFO.GetOnlySetData += new System.EventHandler(this.tvMFO_GetOnlySetData);
            this.tvMFO.SetDataSelectedIndexChanged += new System.EventHandler(this.tvMFO_SetDataSelectedIndexChanged);
            // 
            // pnlRwkList
            // 
            this.pnlRwkList.Controls.Add(this.lisRwkList);
            this.pnlRwkList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRwkList.Location = new System.Drawing.Point(0, 0);
            this.pnlRwkList.Name = "pnlRwkList";
            this.pnlRwkList.Size = new System.Drawing.Size(506, 290);
            this.pnlRwkList.TabIndex = 0;
            // 
            // lisRwkList
            // 
            this.lisRwkList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRwkFlow,
            this.colRwkFlowSeq,
            this.colRwkOper,
            this.colRwkStopOper,
            this.colRetFlow,
            this.colRetFlowSeq,
            this.colRetOper,
            this.colRetOption});
            this.lisRwkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRwkList.FullRowSelect = true;
            this.lisRwkList.Location = new System.Drawing.Point(0, 0);
            this.lisRwkList.MultiSelect = false;
            this.lisRwkList.Name = "lisRwkList";
            this.lisRwkList.Size = new System.Drawing.Size(506, 290);
            this.lisRwkList.TabIndex = 0;
            this.lisRwkList.UseCompatibleStateImageBehavior = false;
            this.lisRwkList.View = System.Windows.Forms.View.Details;
            this.lisRwkList.SelectedIndexChanged += new System.EventHandler(this.lisRwkList_SelectedIndexChanged);
            // 
            // colRwkFlow
            // 
            this.colRwkFlow.Text = "Rework Flow";
            this.colRwkFlow.Width = 120;
            // 
            // colRwkFlowSeq
            // 
            this.colRwkFlowSeq.Text = "Rework Flow Seq";
            this.colRwkFlowSeq.Width = 40;
            // 
            // colRwkOper
            // 
            this.colRwkOper.Text = "Rework Oper";
            this.colRwkOper.Width = 80;
            // 
            // colRwkStopOper
            // 
            this.colRwkStopOper.Text = "Rework Stop Oper";
            this.colRwkStopOper.Width = 80;
            // 
            // colRetFlow
            // 
            this.colRetFlow.Text = "Return Flow";
            this.colRetFlow.Width = 100;
            // 
            // colRetFlowSeq
            // 
            this.colRetFlowSeq.Text = "Return Flow Seq";
            this.colRetFlowSeq.Width = 40;
            // 
            // colRetOper
            // 
            this.colRetOper.Text = "Return Oper";
            this.colRetOper.Width = 80;
            // 
            // colRetOption
            // 
            this.colRetOption.Text = "Return Option";
            this.colRetOption.Width = 250;
            // 
            // pnlRwkInfo
            // 
            this.pnlRwkInfo.Controls.Add(this.grpRetInfo);
            this.pnlRwkInfo.Controls.Add(this.grpRwkInfo);
            this.pnlRwkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRwkInfo.Location = new System.Drawing.Point(0, 290);
            this.pnlRwkInfo.Name = "pnlRwkInfo";
            this.pnlRwkInfo.Size = new System.Drawing.Size(506, 216);
            this.pnlRwkInfo.TabIndex = 1;
            // 
            // grpRetInfo
            // 
            this.grpRetInfo.Controls.Add(this.lblReturnOption);
            this.grpRetInfo.Controls.Add(this.cboReturnOption);
            this.grpRetInfo.Controls.Add(this.cdvReturnOper);
            this.grpRetInfo.Controls.Add(this.cdvReturnFlow);
            this.grpRetInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRetInfo.Location = new System.Drawing.Point(0, 116);
            this.grpRetInfo.Name = "grpRetInfo";
            this.grpRetInfo.Size = new System.Drawing.Size(506, 100);
            this.grpRetInfo.TabIndex = 1;
            this.grpRetInfo.TabStop = false;
            this.grpRetInfo.Text = "Retrun Information";
            // 
            // lblReturnOption
            // 
            this.lblReturnOption.AutoSize = true;
            this.lblReturnOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReturnOption.Location = new System.Drawing.Point(16, 68);
            this.lblReturnOption.Name = "lblReturnOption";
            this.lblReturnOption.Size = new System.Drawing.Size(73, 13);
            this.lblReturnOption.TabIndex = 2;
            this.lblReturnOption.Text = "Return Option";
            // 
            // cboReturnOption
            // 
            this.cboReturnOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReturnOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboReturnOption.FormattingEnabled = true;
            this.cboReturnOption.Items.AddRange(new object[] {
            "Keep Rework",
            "Clear Rework",
            "Clear Rework and Move to Next Operation",
            "Keep Rework and Move to Next Operation"});
            this.cboReturnOption.Location = new System.Drawing.Point(126, 64);
            this.cboReturnOption.Name = "cboReturnOption";
            this.cboReturnOption.Size = new System.Drawing.Size(299, 21);
            this.cboReturnOption.TabIndex = 3;
            // 
            // cdvReturnOper
            // 
            this.cdvReturnOper.AddEmptyRowToLast = false;
            this.cdvReturnOper.AddEmptyRowToTop = false;
            this.cdvReturnOper.ButtonWidth = 21;
            this.cdvReturnOper.DisplaySubItemIndex = 0;
            this.cdvReturnOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnOper.LabelText = "Return Operation";
            this.cdvReturnOper.LabelWidth = 110;
            this.cdvReturnOper.ListCond_ExtFactory = "";
            this.cdvReturnOper.ListCond_Step = '2';
            this.cdvReturnOper.Location = new System.Drawing.Point(16, 40);
            this.cdvReturnOper.Name = "cdvReturnOper";
            this.cdvReturnOper.ReadOnly = false;
            this.cdvReturnOper.SearchSubItemIndex = 0;
            this.cdvReturnOper.SelectedDescIndex = 1;
            this.cdvReturnOper.SelectedSubItemIndex = 0;
            this.cdvReturnOper.Size = new System.Drawing.Size(311, 20);
            this.cdvReturnOper.TabIndex = 1;
            this.cdvReturnOper.TextBoxWidth = 201;
            this.cdvReturnOper.VisibleButton = true;
            this.cdvReturnOper.VisibleColumnHeader = false;
            this.cdvReturnOper.VisibleDescription = false;
            this.cdvReturnOper.ButtonPress += new System.EventHandler(this.cdvReturnOper_ButtonPress);
            // 
            // cdvReturnFlow
            // 
            this.cdvReturnFlow.AddEmptyRowToLast = false;
            this.cdvReturnFlow.AddEmptyRowToTop = false;
            this.cdvReturnFlow.DisplaySubItemIndex = 0;
            this.cdvReturnFlow.FlowReadOnly = false;
            this.cdvReturnFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnFlow.LabelText = "Return Flow";
            this.cdvReturnFlow.LabelWidth = 110;
            this.cdvReturnFlow.ListCond_ExtFactory = "";
            this.cdvReturnFlow.ListCond_Step = '2';
            this.cdvReturnFlow.Location = new System.Drawing.Point(16, 16);
            this.cdvReturnFlow.Name = "cdvReturnFlow";
            this.cdvReturnFlow.SearchSubItemIndex = 0;
            this.cdvReturnFlow.SelectedDescIndex = -1;
            this.cdvReturnFlow.SelectedSubItemIndex = 0;
            this.cdvReturnFlow.SequenceReadOnly = false;
            this.cdvReturnFlow.Size = new System.Drawing.Size(311, 20);
            this.cdvReturnFlow.TabIndex = 0;
            this.cdvReturnFlow.VisibleColumnHeader = false;
            this.cdvReturnFlow.VisibleDescription = false;
            this.cdvReturnFlow.VisibleFlowButton = true;
            this.cdvReturnFlow.VisibleSequenceButton = true;
            this.cdvReturnFlow.WidthButton = 20;
            this.cdvReturnFlow.WidthFlowAndSequence = 201;
            this.cdvReturnFlow.WidthSequence = 50;
            this.cdvReturnFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvReturnFlow_SelectedItemChanged);
            this.cdvReturnFlow.FlowButtonPress += new System.EventHandler(this.cdvReturnFlow_ButtonPress);
            // 
            // grpRwkInfo
            // 
            this.grpRwkInfo.Controls.Add(this.cdvReworkStopOper);
            this.grpRwkInfo.Controls.Add(this.cdvReworkOper);
            this.grpRwkInfo.Controls.Add(this.txtReworkCode);
            this.grpRwkInfo.Controls.Add(this.cdvReworkFlow);
            this.grpRwkInfo.Controls.Add(this.lblReworkCode);
            this.grpRwkInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRwkInfo.Location = new System.Drawing.Point(0, 0);
            this.grpRwkInfo.Name = "grpRwkInfo";
            this.grpRwkInfo.Size = new System.Drawing.Size(506, 116);
            this.grpRwkInfo.TabIndex = 0;
            this.grpRwkInfo.TabStop = false;
            this.grpRwkInfo.Text = "Rework Information";
            // 
            // cdvReworkStopOper
            // 
            this.cdvReworkStopOper.AddEmptyRowToLast = false;
            this.cdvReworkStopOper.AddEmptyRowToTop = false;
            this.cdvReworkStopOper.ButtonWidth = 21;
            this.cdvReworkStopOper.DisplaySubItemIndex = 0;
            this.cdvReworkStopOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkStopOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkStopOper.LabelText = "Stop Operation";
            this.cdvReworkStopOper.LabelWidth = 110;
            this.cdvReworkStopOper.ListCond_ExtFactory = "";
            this.cdvReworkStopOper.ListCond_Step = '2';
            this.cdvReworkStopOper.Location = new System.Drawing.Point(16, 88);
            this.cdvReworkStopOper.Name = "cdvReworkStopOper";
            this.cdvReworkStopOper.ReadOnly = false;
            this.cdvReworkStopOper.SearchSubItemIndex = 0;
            this.cdvReworkStopOper.SelectedDescIndex = 1;
            this.cdvReworkStopOper.SelectedSubItemIndex = 0;
            this.cdvReworkStopOper.Size = new System.Drawing.Size(311, 20);
            this.cdvReworkStopOper.TabIndex = 4;
            this.cdvReworkStopOper.TextBoxWidth = 201;
            this.cdvReworkStopOper.VisibleButton = true;
            this.cdvReworkStopOper.VisibleColumnHeader = false;
            this.cdvReworkStopOper.VisibleDescription = false;
            this.cdvReworkStopOper.ButtonPress += new System.EventHandler(this.cdvReworkStopOper_ButtonPress);
            // 
            // cdvReworkOper
            // 
            this.cdvReworkOper.AddEmptyRowToLast = false;
            this.cdvReworkOper.AddEmptyRowToTop = false;
            this.cdvReworkOper.ButtonWidth = 21;
            this.cdvReworkOper.DisplaySubItemIndex = 0;
            this.cdvReworkOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkOper.LabelText = "Rework Operation";
            this.cdvReworkOper.LabelWidth = 110;
            this.cdvReworkOper.ListCond_ExtFactory = "";
            this.cdvReworkOper.ListCond_Step = '2';
            this.cdvReworkOper.Location = new System.Drawing.Point(16, 64);
            this.cdvReworkOper.Name = "cdvReworkOper";
            this.cdvReworkOper.ReadOnly = false;
            this.cdvReworkOper.SearchSubItemIndex = 0;
            this.cdvReworkOper.SelectedDescIndex = 1;
            this.cdvReworkOper.SelectedSubItemIndex = 0;
            this.cdvReworkOper.Size = new System.Drawing.Size(311, 20);
            this.cdvReworkOper.TabIndex = 3;
            this.cdvReworkOper.TextBoxWidth = 201;
            this.cdvReworkOper.VisibleButton = true;
            this.cdvReworkOper.VisibleColumnHeader = false;
            this.cdvReworkOper.VisibleDescription = false;
            this.cdvReworkOper.ButtonPress += new System.EventHandler(this.cdvReworkOper_ButtonPress);
            // 
            // txtReworkCode
            // 
            this.txtReworkCode.Location = new System.Drawing.Point(126, 16);
            this.txtReworkCode.MaxLength = 20;
            this.txtReworkCode.Name = "txtReworkCode";
            this.txtReworkCode.ReadOnly = true;
            this.txtReworkCode.Size = new System.Drawing.Size(201, 20);
            this.txtReworkCode.TabIndex = 1;
            // 
            // cdvReworkFlow
            // 
            this.cdvReworkFlow.AddEmptyRowToLast = false;
            this.cdvReworkFlow.AddEmptyRowToTop = false;
            this.cdvReworkFlow.DisplaySubItemIndex = 0;
            this.cdvReworkFlow.FlowReadOnly = false;
            this.cdvReworkFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkFlow.LabelText = "Rework Flow";
            this.cdvReworkFlow.LabelWidth = 110;
            this.cdvReworkFlow.ListCond_ExtFactory = "";
            this.cdvReworkFlow.ListCond_Step = '2';
            this.cdvReworkFlow.Location = new System.Drawing.Point(16, 40);
            this.cdvReworkFlow.Name = "cdvReworkFlow";
            this.cdvReworkFlow.SearchSubItemIndex = 0;
            this.cdvReworkFlow.SelectedDescIndex = -1;
            this.cdvReworkFlow.SelectedSubItemIndex = 0;
            this.cdvReworkFlow.SequenceReadOnly = false;
            this.cdvReworkFlow.Size = new System.Drawing.Size(311, 20);
            this.cdvReworkFlow.TabIndex = 2;
            this.cdvReworkFlow.VisibleColumnHeader = false;
            this.cdvReworkFlow.VisibleDescription = false;
            this.cdvReworkFlow.VisibleFlowButton = true;
            this.cdvReworkFlow.VisibleSequenceButton = true;
            this.cdvReworkFlow.WidthButton = 20;
            this.cdvReworkFlow.WidthFlowAndSequence = 201;
            this.cdvReworkFlow.WidthSequence = 50;
            this.cdvReworkFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvReworkFlow_SelectedItemChanged);
            this.cdvReworkFlow.FlowButtonPress += new System.EventHandler(this.cdvReworkFlow_ButtonPress);
            // 
            // lblReworkCode
            // 
            this.lblReworkCode.AutoSize = true;
            this.lblReworkCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReworkCode.Location = new System.Drawing.Point(16, 19);
            this.lblReworkCode.Name = "lblReworkCode";
            this.lblReworkCode.Size = new System.Drawing.Size(72, 13);
            this.lblReworkCode.TabIndex = 0;
            this.lblReworkCode.Text = "Rework Code";
            this.lblReworkCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPSetupReworkFlow
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupReworkFlow";
            this.Text = "Rework Flow Setup";
            this.Load += new System.EventHandler(this.frmWIPSetupRF_Load);
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
            this.pnlRwkList.ResumeLayout(false);
            this.pnlRwkInfo.ResumeLayout(false);
            this.grpRetInfo.ResumeLayout(false);
            this.grpRetInfo.PerformLayout();
            this.grpRwkInfo.ResumeLayout(false);
            this.grpRwkInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.MESCore.Controls.udcMFOTreeList tvMFO;
        private System.Windows.Forms.Panel pnlRwkInfo;
        private System.Windows.Forms.Panel pnlRwkList;
        private System.Windows.Forms.ListView lisRwkList;
        private System.Windows.Forms.ColumnHeader colRwkFlow;
        private System.Windows.Forms.ColumnHeader colRwkFlowSeq;
        private System.Windows.Forms.ColumnHeader colRwkOper;
        private System.Windows.Forms.ColumnHeader colRetFlow;
        private System.Windows.Forms.ColumnHeader colRetFlowSeq;
        private System.Windows.Forms.ColumnHeader colRetOption;
        private System.Windows.Forms.ColumnHeader colRetOper;
        private System.Windows.Forms.GroupBox grpRetInfo;
        private System.Windows.Forms.GroupBox grpRwkInfo;
        private System.Windows.Forms.TextBox txtReworkCode;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvReworkFlow;
        private System.Windows.Forms.Label lblReworkCode;
        private Miracom.MESCore.Controls.udcOperation cdvReworkOper;
        private Miracom.MESCore.Controls.udcOperation cdvReturnOper;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvReturnFlow;
        private Miracom.MESCore.Controls.udcOperation cdvReworkStopOper;
        private System.Windows.Forms.Label lblReturnOption;
        private System.Windows.Forms.ComboBox cboReturnOption;
        private System.Windows.Forms.ColumnHeader colRwkStopOper;
    }
}
