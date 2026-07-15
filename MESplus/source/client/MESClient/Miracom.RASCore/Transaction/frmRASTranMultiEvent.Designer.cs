namespace Miracom.RASCore
{
    partial class frmRASTranMultiEvent
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
            this.tabTran = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlTranInfo = new System.Windows.Forms.Panel();
            this.pnlConditionInfo = new System.Windows.Forms.Panel();
            this.pnlLotList = new System.Windows.Forms.Panel();
            this.grpResourceList = new System.Windows.Forms.GroupBox();
            this.lisResourceList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriSts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUseFac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEventTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProcCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaxProcCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastActiveHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlCheck = new System.Windows.Forms.Panel();
            this.grpCheck = new System.Windows.Forms.GroupBox();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.grpConditionInfo = new System.Windows.Forms.GroupBox();
            this.cdvPrt1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvLastEvent = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtDown = new System.Windows.Forms.RadioButton();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.rbtUp = new System.Windows.Forms.RadioButton();
            this.lblPrt1 = new System.Windows.Forms.Label();
            this.lblUpDownFlag = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.lblLastEvent = new System.Windows.Forms.Label();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.pnlTran = new System.Windows.Forms.Panel();
            this.tabResource = new System.Windows.Forms.TabControl();
            this.tbpEvent = new System.Windows.Forms.TabPage();
            this.grpTran = new System.Windows.Forms.GroupBox();
            this.cdvPrimaryChange = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtChangeUpDown = new System.Windows.Forms.TextBox();
            this.cdvEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEventID = new System.Windows.Forms.Label();
            this.lblUpDown = new System.Windows.Forms.Label();
            this.lblPrimaryStatus = new System.Windows.Forms.Label();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.cdvChangeStatus10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblStatus10 = new System.Windows.Forms.Label();
            this.lblStatus9 = new System.Windows.Forms.Label();
            this.lblStatus8 = new System.Windows.Forms.Label();
            this.lblStatus7 = new System.Windows.Forms.Label();
            this.lblStatus6 = new System.Windows.Forms.Label();
            this.lblStatus5 = new System.Windows.Forms.Label();
            this.lblStatus4 = new System.Windows.Forms.Label();
            this.lblStatus3 = new System.Windows.Forms.Label();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF20 = new System.Windows.Forms.Label();
            this.lblCMF19 = new System.Windows.Forms.Label();
            this.lblCMF18 = new System.Windows.Forms.Label();
            this.lblCMF17 = new System.Windows.Forms.Label();
            this.lblCMF16 = new System.Windows.Forms.Label();
            this.lblCMF15 = new System.Windows.Forms.Label();
            this.lblCMF14 = new System.Windows.Forms.Label();
            this.lblCMF13 = new System.Windows.Forms.Label();
            this.lblCMF12 = new System.Windows.Forms.Label();
            this.lblCMF11 = new System.Windows.Forms.Label();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlConditionInfo.SuspendLayout();
            this.pnlLotList.SuspendLayout();
            this.grpResourceList.SuspendLayout();
            this.pnlCheck.SuspendLayout();
            this.grpCheck.SuspendLayout();
            this.grpConditionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLastEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            this.pnlTran.SuspendLayout();
            this.tabResource.SuspendLayout();
            this.tbpEvent.SuspendLayout();
            this.grpTran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrimaryChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).BeginInit();
            this.grpComment.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus1)).BeginInit();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabTran);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Multi Event";
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpGeneral);
            this.tabTran.Controls.Add(this.tbpCMF);
            this.tabTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTran.ItemSize = new System.Drawing.Size(60, 18);
            this.tabTran.Location = new System.Drawing.Point(3, 3);
            this.tabTran.Name = "tabTran";
            this.tabTran.SelectedIndex = 0;
            this.tabTran.Size = new System.Drawing.Size(736, 503);
            this.tabTran.TabIndex = 1;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlTranInfo);
            this.tbpGeneral.Controls.Add(this.pnlTran);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(728, 477);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.pnlConditionInfo);
            this.pnlTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTranInfo.Name = "pnlTranInfo";
            this.pnlTranInfo.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 309);
            this.pnlTranInfo.TabIndex = 0;
            // 
            // pnlConditionInfo
            // 
            this.pnlConditionInfo.Controls.Add(this.pnlLotList);
            this.pnlConditionInfo.Controls.Add(this.pnlCheck);
            this.pnlConditionInfo.Controls.Add(this.grpConditionInfo);
            this.pnlConditionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConditionInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlConditionInfo.Name = "pnlConditionInfo";
            this.pnlConditionInfo.Size = new System.Drawing.Size(722, 306);
            this.pnlConditionInfo.TabIndex = 2;
            // 
            // pnlLotList
            // 
            this.pnlLotList.Controls.Add(this.grpResourceList);
            this.pnlLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotList.Location = new System.Drawing.Point(90, 113);
            this.pnlLotList.Name = "pnlLotList";
            this.pnlLotList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlLotList.Size = new System.Drawing.Size(632, 193);
            this.pnlLotList.TabIndex = 3;
            // 
            // grpResourceList
            // 
            this.grpResourceList.Controls.Add(this.lisResourceList);
            this.grpResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResourceList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResourceList.Location = new System.Drawing.Point(0, 4);
            this.grpResourceList.Name = "grpResourceList";
            this.grpResourceList.Size = new System.Drawing.Size(632, 189);
            this.grpResourceList.TabIndex = 0;
            this.grpResourceList.TabStop = false;
            this.grpResourceList.Text = "Resource List";
            // 
            // lisResourceList
            // 
            this.lisResourceList.AllowColumnReorder = true;
            this.lisResourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colRes,
            this.colDesc,
            this.colType,
            this.colUpDown,
            this.colPriSts,
            this.colPrt1,
            this.colPrt2,
            this.colPrt3,
            this.colPrt4,
            this.colPrt5,
            this.colPrt6,
            this.colPrt7,
            this.colPrt8,
            this.colPrt9,
            this.colPrt10,
            this.colSts1,
            this.colSts2,
            this.colSts3,
            this.colSts4,
            this.colSts5,
            this.colSts6,
            this.colSts7,
            this.colSts8,
            this.colSts9,
            this.colSts10,
            this.colUseFac,
            this.colLastEvent,
            this.colLastEventTime,
            this.colLastStartTime,
            this.colLastEndTime,
            this.colProcCount,
            this.colMaxProcCount,
            this.colLot1,
            this.colLot2,
            this.colLot3,
            this.colLot4,
            this.colLot5,
            this.colLot6,
            this.colLot7,
            this.colLot8,
            this.colLot9,
            this.colLot10,
            this.colLastActiveHistSeq,
            this.colLastHistSeq,
            this.colCreateUser,
            this.colCreateTime,
            this.colUpdateUser,
            this.colUpdateTime});
            this.lisResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResourceList.EnableSort = true;
            this.lisResourceList.EnableSortIcon = true;
            this.lisResourceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResourceList.FullRowSelect = true;
            this.lisResourceList.Location = new System.Drawing.Point(3, 16);
            this.lisResourceList.MultiSelect = false;
            this.lisResourceList.Name = "lisResourceList";
            this.lisResourceList.Size = new System.Drawing.Size(626, 170);
            this.lisResourceList.TabIndex = 0;
            this.lisResourceList.UseCompatibleStateImageBehavior = false;
            this.lisResourceList.View = System.Windows.Forms.View.Details;
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            // 
            // colRes
            // 
            this.colRes.Text = "Resource ID";
            this.colRes.Width = 89;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Res Desc";
            this.colDesc.Width = 119;
            // 
            // colType
            // 
            this.colType.Text = "Res Type";
            this.colType.Width = 98;
            // 
            // colUpDown
            // 
            this.colUpDown.Text = "Up/Down";
            this.colUpDown.Width = 59;
            // 
            // colPriSts
            // 
            this.colPriSts.Text = "Primary Status";
            this.colPriSts.Width = 88;
            // 
            // colPrt1
            // 
            this.colPrt1.Text = "Status Prompt 1";
            this.colPrt1.Width = 120;
            // 
            // colPrt2
            // 
            this.colPrt2.Text = "Status Prompt 2";
            this.colPrt2.Width = 120;
            // 
            // colPrt3
            // 
            this.colPrt3.Text = "Status Prompt 3";
            this.colPrt3.Width = 120;
            // 
            // colPrt4
            // 
            this.colPrt4.Text = "Status Prompt 4";
            this.colPrt4.Width = 120;
            // 
            // colPrt5
            // 
            this.colPrt5.Text = "Status Prompt 5";
            this.colPrt5.Width = 120;
            // 
            // colPrt6
            // 
            this.colPrt6.Text = "Status Prompt 6";
            this.colPrt6.Width = 120;
            // 
            // colPrt7
            // 
            this.colPrt7.Text = "Status Prompt 7";
            this.colPrt7.Width = 120;
            // 
            // colPrt8
            // 
            this.colPrt8.Text = "Status Prompt 8";
            this.colPrt8.Width = 120;
            // 
            // colPrt9
            // 
            this.colPrt9.Text = "Status Prompt 9";
            this.colPrt9.Width = 120;
            // 
            // colPrt10
            // 
            this.colPrt10.Text = "Status Prompt 10";
            this.colPrt10.Width = 120;
            // 
            // colSts1
            // 
            this.colSts1.Text = "Status 1";
            this.colSts1.Width = 120;
            // 
            // colSts2
            // 
            this.colSts2.Text = "Status 2";
            this.colSts2.Width = 120;
            // 
            // colSts3
            // 
            this.colSts3.Text = "Status 3";
            this.colSts3.Width = 120;
            // 
            // colSts4
            // 
            this.colSts4.Text = "Status 4";
            this.colSts4.Width = 120;
            // 
            // colSts5
            // 
            this.colSts5.Text = "Status 5";
            this.colSts5.Width = 120;
            // 
            // colSts6
            // 
            this.colSts6.Text = "Status 6";
            this.colSts6.Width = 120;
            // 
            // colSts7
            // 
            this.colSts7.Text = "Status 7";
            this.colSts7.Width = 120;
            // 
            // colSts8
            // 
            this.colSts8.Text = "Status 8";
            this.colSts8.Width = 120;
            // 
            // colSts9
            // 
            this.colSts9.Text = "Status 9";
            this.colSts9.Width = 120;
            // 
            // colSts10
            // 
            this.colSts10.Text = "Status 10";
            this.colSts10.Width = 120;
            // 
            // colUseFac
            // 
            this.colUseFac.Text = "Use Fac Prt Flag";
            this.colUseFac.Width = 100;
            // 
            // colLastEvent
            // 
            this.colLastEvent.Text = "Last Event";
            this.colLastEvent.Width = 100;
            // 
            // colLastEventTime
            // 
            this.colLastEventTime.Text = "Last Event Time";
            this.colLastEventTime.Width = 120;
            // 
            // colLastStartTime
            // 
            this.colLastStartTime.Text = "Last Start Time";
            this.colLastStartTime.Width = 120;
            // 
            // colLastEndTime
            // 
            this.colLastEndTime.Text = "Last End Time";
            this.colLastEndTime.Width = 120;
            // 
            // colProcCount
            // 
            this.colProcCount.Text = "Proc Lot Count";
            this.colProcCount.Width = 100;
            // 
            // colMaxProcCount
            // 
            this.colMaxProcCount.Text = "Max Proc Count";
            this.colMaxProcCount.Width = 100;
            // 
            // colLot1
            // 
            this.colLot1.Text = "Proc Lot 1";
            this.colLot1.Width = 100;
            // 
            // colLot2
            // 
            this.colLot2.Text = "Proc Lot 2";
            this.colLot2.Width = 100;
            // 
            // colLot3
            // 
            this.colLot3.Text = "Proc Lot 3";
            this.colLot3.Width = 100;
            // 
            // colLot4
            // 
            this.colLot4.Text = "Proc Lot 4";
            this.colLot4.Width = 100;
            // 
            // colLot5
            // 
            this.colLot5.Text = "Proc Lot 5";
            this.colLot5.Width = 100;
            // 
            // colLot6
            // 
            this.colLot6.Text = "Proc Lot 6";
            this.colLot6.Width = 100;
            // 
            // colLot7
            // 
            this.colLot7.Text = "Proc Lot 7";
            this.colLot7.Width = 100;
            // 
            // colLot8
            // 
            this.colLot8.Text = "Proc Lot 8";
            this.colLot8.Width = 100;
            // 
            // colLot9
            // 
            this.colLot9.Text = "Proc Lot 9";
            this.colLot9.Width = 100;
            // 
            // colLot10
            // 
            this.colLot10.Text = "Proc Lot 10";
            this.colLot10.Width = 100;
            // 
            // colLastActiveHistSeq
            // 
            this.colLastActiveHistSeq.Text = "Last Active Hist Seq";
            this.colLastActiveHistSeq.Width = 120;
            // 
            // colLastHistSeq
            // 
            this.colLastHistSeq.Text = "Last Hist Seq";
            this.colLastHistSeq.Width = 100;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 110;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Text = "Create Time";
            this.colCreateTime.Width = 120;
            // 
            // colUpdateUser
            // 
            this.colUpdateUser.Text = "Update User";
            this.colUpdateUser.Width = 110;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.Text = "Update Time";
            this.colUpdateTime.Width = 120;
            // 
            // pnlCheck
            // 
            this.pnlCheck.Controls.Add(this.grpCheck);
            this.pnlCheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCheck.Location = new System.Drawing.Point(0, 113);
            this.pnlCheck.Name = "pnlCheck";
            this.pnlCheck.Padding = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.pnlCheck.Size = new System.Drawing.Size(90, 193);
            this.pnlCheck.TabIndex = 2;
            // 
            // grpCheck
            // 
            this.grpCheck.Controls.Add(this.btnUncheckAll);
            this.grpCheck.Controls.Add(this.btnCheckAll);
            this.grpCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCheck.Location = new System.Drawing.Point(0, 4);
            this.grpCheck.Name = "grpCheck";
            this.grpCheck.Size = new System.Drawing.Size(86, 189);
            this.grpCheck.TabIndex = 0;
            this.grpCheck.TabStop = false;
            this.grpCheck.Text = "Check Method";
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUncheckAll.Location = new System.Drawing.Point(8, 44);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(70, 26);
            this.btnUncheckAll.TabIndex = 1;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCheckAll.Location = new System.Drawing.Point(8, 16);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(70, 26);
            this.btnCheckAll.TabIndex = 0;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // grpConditionInfo
            // 
            this.grpConditionInfo.Controls.Add(this.cdvPrt1);
            this.grpConditionInfo.Controls.Add(this.cdvGrp1);
            this.grpConditionInfo.Controls.Add(this.cdvLastEvent);
            this.grpConditionInfo.Controls.Add(this.cdvType);
            this.grpConditionInfo.Controls.Add(this.cdvResGroup);
            this.grpConditionInfo.Controls.Add(this.label1);
            this.grpConditionInfo.Controls.Add(this.rbtDown);
            this.grpConditionInfo.Controls.Add(this.cdvMaterial);
            this.grpConditionInfo.Controls.Add(this.rbtAll);
            this.grpConditionInfo.Controls.Add(this.rbtUp);
            this.grpConditionInfo.Controls.Add(this.lblPrt1);
            this.grpConditionInfo.Controls.Add(this.lblUpDownFlag);
            this.grpConditionInfo.Controls.Add(this.lblType);
            this.grpConditionInfo.Controls.Add(this.cdvFlow);
            this.grpConditionInfo.Controls.Add(this.lblLastEvent);
            this.grpConditionInfo.Controls.Add(this.cdvOperation);
            this.grpConditionInfo.Controls.Add(this.lblOperation);
            this.grpConditionInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConditionInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpConditionInfo.Location = new System.Drawing.Point(0, 0);
            this.grpConditionInfo.Name = "grpConditionInfo";
            this.grpConditionInfo.Size = new System.Drawing.Size(722, 113);
            this.grpConditionInfo.TabIndex = 0;
            this.grpConditionInfo.TabStop = false;
            // 
            // cdvPrt1
            // 
            this.cdvPrt1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrt1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrt1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrt1.BtnToolTipText = "";
            this.cdvPrt1.DescText = "";
            this.cdvPrt1.DisplaySubItemIndex = -1;
            this.cdvPrt1.DisplayText = "";
            this.cdvPrt1.Focusing = null;
            this.cdvPrt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrt1.Index = 0;
            this.cdvPrt1.IsViewBtnImage = false;
            this.cdvPrt1.Location = new System.Drawing.Point(438, 13);
            this.cdvPrt1.MaxLength = 30;
            this.cdvPrt1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrt1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrt1.Name = "cdvPrt1";
            this.cdvPrt1.ReadOnly = true;
            this.cdvPrt1.SearchSubItemIndex = 0;
            this.cdvPrt1.SelectedDescIndex = -1;
            this.cdvPrt1.SelectedSubItemIndex = -1;
            this.cdvPrt1.SelectionStart = 0;
            this.cdvPrt1.Size = new System.Drawing.Size(135, 20);
            this.cdvPrt1.SmallImageList = null;
            this.cdvPrt1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrt1.TabIndex = 7;
            this.cdvPrt1.TextBoxToolTipText = "";
            this.cdvPrt1.TextBoxWidth = 135;
            this.cdvPrt1.VisibleButton = true;
            this.cdvPrt1.VisibleColumnHeader = false;
            this.cdvPrt1.VisibleDescription = false;
            this.cdvPrt1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPrt1_SelectedItemChanged);
            this.cdvPrt1.ButtonPress += new System.EventHandler(this.cdvPrt1_ButtonPress);
            // 
            // cdvGrp1
            // 
            this.cdvGrp1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp1.BtnToolTipText = "";
            this.cdvGrp1.DescText = "";
            this.cdvGrp1.DisplaySubItemIndex = -1;
            this.cdvGrp1.DisplayText = "";
            this.cdvGrp1.Focusing = null;
            this.cdvGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp1.Index = 0;
            this.cdvGrp1.IsViewBtnImage = false;
            this.cdvGrp1.Location = new System.Drawing.Point(577, 13);
            this.cdvGrp1.MaxLength = 30;
            this.cdvGrp1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp1.Name = "cdvGrp1";
            this.cdvGrp1.ReadOnly = false;
            this.cdvGrp1.SearchSubItemIndex = 0;
            this.cdvGrp1.SelectedDescIndex = -1;
            this.cdvGrp1.SelectedSubItemIndex = -1;
            this.cdvGrp1.SelectionStart = 0;
            this.cdvGrp1.Size = new System.Drawing.Size(135, 20);
            this.cdvGrp1.SmallImageList = null;
            this.cdvGrp1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp1.TabIndex = 8;
            this.cdvGrp1.TextBoxToolTipText = "";
            this.cdvGrp1.TextBoxWidth = 135;
            this.cdvGrp1.VisibleButton = true;
            this.cdvGrp1.VisibleColumnHeader = false;
            this.cdvGrp1.VisibleDescription = false;
            this.cdvGrp1.ButtonPress += new System.EventHandler(this.cdvGrp1_ButtonPress);
            // 
            // cdvLastEvent
            // 
            this.cdvLastEvent.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLastEvent.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLastEvent.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLastEvent.BtnToolTipText = "";
            this.cdvLastEvent.DescText = "";
            this.cdvLastEvent.DisplaySubItemIndex = -1;
            this.cdvLastEvent.DisplayText = "";
            this.cdvLastEvent.Focusing = null;
            this.cdvLastEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLastEvent.Index = 0;
            this.cdvLastEvent.IsViewBtnImage = false;
            this.cdvLastEvent.Location = new System.Drawing.Point(438, 61);
            this.cdvLastEvent.MaxLength = 12;
            this.cdvLastEvent.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLastEvent.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLastEvent.Name = "cdvLastEvent";
            this.cdvLastEvent.ReadOnly = false;
            this.cdvLastEvent.SearchSubItemIndex = 0;
            this.cdvLastEvent.SelectedDescIndex = -1;
            this.cdvLastEvent.SelectedSubItemIndex = -1;
            this.cdvLastEvent.SelectionStart = 0;
            this.cdvLastEvent.Size = new System.Drawing.Size(180, 20);
            this.cdvLastEvent.SmallImageList = null;
            this.cdvLastEvent.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLastEvent.TabIndex = 12;
            this.cdvLastEvent.TextBoxToolTipText = "";
            this.cdvLastEvent.TextBoxWidth = 180;
            this.cdvLastEvent.VisibleButton = true;
            this.cdvLastEvent.VisibleColumnHeader = false;
            this.cdvLastEvent.VisibleDescription = false;
            this.cdvLastEvent.ButtonPress += new System.EventHandler(this.cdvLastEvent_ButtonPress);
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(438, 37);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(180, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 10;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 180;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // cdvResGroup
            // 
            this.cdvResGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGroup.BtnToolTipText = "";
            this.cdvResGroup.DescText = "";
            this.cdvResGroup.DisplaySubItemIndex = -1;
            this.cdvResGroup.DisplayText = "";
            this.cdvResGroup.Focusing = null;
            this.cdvResGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGroup.Index = 0;
            this.cdvResGroup.IsViewBtnImage = false;
            this.cdvResGroup.Location = new System.Drawing.Point(114, 85);
            this.cdvResGroup.MaxLength = 20;
            this.cdvResGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGroup.Name = "cdvResGroup";
            this.cdvResGroup.ReadOnly = false;
            this.cdvResGroup.SearchSubItemIndex = 0;
            this.cdvResGroup.SelectedDescIndex = -1;
            this.cdvResGroup.SelectedSubItemIndex = -1;
            this.cdvResGroup.SelectionStart = 0;
            this.cdvResGroup.Size = new System.Drawing.Size(180, 20);
            this.cdvResGroup.SmallImageList = null;
            this.cdvResGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGroup.TabIndex = 5;
            this.cdvResGroup.TextBoxToolTipText = "";
            this.cdvResGroup.TextBoxWidth = 180;
            this.cdvResGroup.VisibleButton = true;
            this.cdvResGroup.VisibleColumnHeader = false;
            this.cdvResGroup.VisibleDescription = false;
            this.cdvResGroup.ButtonPress += new System.EventHandler(this.cdvResGroup_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(14, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Resource Group";
            // 
            // rbtDown
            // 
            this.rbtDown.AutoSize = true;
            this.rbtDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtDown.Location = new System.Drawing.Point(539, 86);
            this.rbtDown.Name = "rbtDown";
            this.rbtDown.Size = new System.Drawing.Size(59, 18);
            this.rbtDown.TabIndex = 16;
            this.rbtDown.Text = "Down";
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = true;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(14, 13);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(280, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 100;
            this.cdvMaterial.WidthMaterialAndVersion = 180;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Checked = true;
            this.rbtAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtAll.Location = new System.Drawing.Point(441, 86);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(42, 18);
            this.rbtAll.TabIndex = 14;
            this.rbtAll.TabStop = true;
            this.rbtAll.Text = "All";
            // 
            // rbtUp
            // 
            this.rbtUp.AutoSize = true;
            this.rbtUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtUp.Location = new System.Drawing.Point(490, 86);
            this.rbtUp.Name = "rbtUp";
            this.rbtUp.Size = new System.Drawing.Size(45, 18);
            this.rbtUp.TabIndex = 15;
            this.rbtUp.Text = "Up";
            // 
            // lblPrt1
            // 
            this.lblPrt1.AutoSize = true;
            this.lblPrt1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrt1.Location = new System.Drawing.Point(321, 16);
            this.lblPrt1.Name = "lblPrt1";
            this.lblPrt1.Size = new System.Drawing.Size(112, 13);
            this.lblPrt1.TabIndex = 6;
            this.lblPrt1.Text = "Group Prompt / Group";
            // 
            // lblUpDownFlag
            // 
            this.lblUpDownFlag.AutoSize = true;
            this.lblUpDownFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpDownFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpDownFlag.Location = new System.Drawing.Point(321, 88);
            this.lblUpDownFlag.Name = "lblUpDownFlag";
            this.lblUpDownFlag.Size = new System.Drawing.Size(77, 13);
            this.lblUpDownFlag.TabIndex = 13;
            this.lblUpDownFlag.Text = "Up/Down Flag";
            this.lblUpDownFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Location = new System.Drawing.Point(321, 40);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 13);
            this.lblType.TabIndex = 9;
            this.lblType.Text = "Resource Type";
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = true;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 100;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(14, 37);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(280, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 180;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_FlowSelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            // 
            // lblLastEvent
            // 
            this.lblLastEvent.AutoSize = true;
            this.lblLastEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastEvent.Location = new System.Drawing.Point(321, 64);
            this.lblLastEvent.Name = "lblLastEvent";
            this.lblLastEvent.Size = new System.Drawing.Size(58, 13);
            this.lblLastEvent.TabIndex = 11;
            this.lblLastEvent.Text = "Last Event";
            this.lblLastEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(114, 61);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(180, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 3;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 180;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(14, 64);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(53, 13);
            this.lblOperation.TabIndex = 2;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTran
            // 
            this.pnlTran.Controls.Add(this.tabResource);
            this.pnlTran.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTran.Location = new System.Drawing.Point(0, 309);
            this.pnlTran.Name = "pnlTran";
            this.pnlTran.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlTran.Size = new System.Drawing.Size(728, 165);
            this.pnlTran.TabIndex = 0;
            // 
            // tabResource
            // 
            this.tabResource.Controls.Add(this.tbpEvent);
            this.tabResource.Controls.Add(this.tabStatus);
            this.tabResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResource.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResource.Location = new System.Drawing.Point(3, 3);
            this.tabResource.Name = "tabResource";
            this.tabResource.SelectedIndex = 0;
            this.tabResource.Size = new System.Drawing.Size(722, 162);
            this.tabResource.TabIndex = 3;
            // 
            // tbpEvent
            // 
            this.tbpEvent.Controls.Add(this.grpTran);
            this.tbpEvent.Controls.Add(this.grpComment);
            this.tbpEvent.Location = new System.Drawing.Point(4, 22);
            this.tbpEvent.Name = "tbpEvent";
            this.tbpEvent.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpEvent.Size = new System.Drawing.Size(714, 136);
            this.tbpEvent.TabIndex = 5;
            this.tbpEvent.Text = "Event";
            // 
            // grpTran
            // 
            this.grpTran.Controls.Add(this.cdvPrimaryChange);
            this.grpTran.Controls.Add(this.txtChangeUpDown);
            this.grpTran.Controls.Add(this.cdvEventID);
            this.grpTran.Controls.Add(this.lblEventID);
            this.grpTran.Controls.Add(this.lblUpDown);
            this.grpTran.Controls.Add(this.lblPrimaryStatus);
            this.grpTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTran.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTran.Location = new System.Drawing.Point(3, 0);
            this.grpTran.Name = "grpTran";
            this.grpTran.Size = new System.Drawing.Size(708, 88);
            this.grpTran.TabIndex = 0;
            this.grpTran.TabStop = false;
            // 
            // cdvPrimaryChange
            // 
            this.cdvPrimaryChange.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrimaryChange.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrimaryChange.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrimaryChange.BtnToolTipText = "";
            this.cdvPrimaryChange.DescText = "";
            this.cdvPrimaryChange.DisplaySubItemIndex = -1;
            this.cdvPrimaryChange.DisplayText = "";
            this.cdvPrimaryChange.Focusing = null;
            this.cdvPrimaryChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrimaryChange.Index = 0;
            this.cdvPrimaryChange.IsViewBtnImage = false;
            this.cdvPrimaryChange.Location = new System.Drawing.Point(124, 63);
            this.cdvPrimaryChange.MaxLength = 32767;
            this.cdvPrimaryChange.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrimaryChange.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrimaryChange.Name = "cdvPrimaryChange";
            this.cdvPrimaryChange.ReadOnly = true;
            this.cdvPrimaryChange.SearchSubItemIndex = 0;
            this.cdvPrimaryChange.SelectedDescIndex = -1;
            this.cdvPrimaryChange.SelectedSubItemIndex = -1;
            this.cdvPrimaryChange.SelectionStart = 0;
            this.cdvPrimaryChange.Size = new System.Drawing.Size(200, 20);
            this.cdvPrimaryChange.SmallImageList = null;
            this.cdvPrimaryChange.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrimaryChange.TabIndex = 5;
            this.cdvPrimaryChange.TextBoxToolTipText = "";
            this.cdvPrimaryChange.TextBoxWidth = 200;
            this.cdvPrimaryChange.VisibleButton = true;
            this.cdvPrimaryChange.VisibleColumnHeader = false;
            this.cdvPrimaryChange.VisibleDescription = false;
            this.cdvPrimaryChange.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // txtChangeUpDown
            // 
            this.txtChangeUpDown.Location = new System.Drawing.Point(124, 39);
            this.txtChangeUpDown.MaxLength = 4;
            this.txtChangeUpDown.Name = "txtChangeUpDown";
            this.txtChangeUpDown.ReadOnly = true;
            this.txtChangeUpDown.Size = new System.Drawing.Size(200, 20);
            this.txtChangeUpDown.TabIndex = 3;
            this.txtChangeUpDown.TabStop = false;
            // 
            // cdvEventID
            // 
            this.cdvEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEventID.BtnToolTipText = "";
            this.cdvEventID.DescText = "";
            this.cdvEventID.DisplaySubItemIndex = 0;
            this.cdvEventID.DisplayText = "";
            this.cdvEventID.Focusing = null;
            this.cdvEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEventID.Index = 0;
            this.cdvEventID.IsViewBtnImage = false;
            this.cdvEventID.Location = new System.Drawing.Point(124, 15);
            this.cdvEventID.MaxLength = 12;
            this.cdvEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.Name = "cdvEventID";
            this.cdvEventID.ReadOnly = false;
            this.cdvEventID.SearchSubItemIndex = 0;
            this.cdvEventID.SelectedDescIndex = -1;
            this.cdvEventID.SelectedSubItemIndex = -1;
            this.cdvEventID.SelectionStart = 0;
            this.cdvEventID.Size = new System.Drawing.Size(571, 20);
            this.cdvEventID.SmallImageList = null;
            this.cdvEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEventID.TabIndex = 1;
            this.cdvEventID.TextBoxToolTipText = "";
            this.cdvEventID.TextBoxWidth = 200;
            this.cdvEventID.VisibleButton = true;
            this.cdvEventID.VisibleColumnHeader = false;
            this.cdvEventID.VisibleDescription = true;
            this.cdvEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvEventID_SelectedItemChanged);
            this.cdvEventID.ButtonPress += new System.EventHandler(this.cdvEventID_ButtonPress);
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEventID.Location = new System.Drawing.Point(16, 18);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(57, 13);
            this.lblEventID.TabIndex = 0;
            this.lblEventID.Text = "Event ID";
            // 
            // lblUpDown
            // 
            this.lblUpDown.AutoSize = true;
            this.lblUpDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpDown.Location = new System.Drawing.Point(16, 40);
            this.lblUpDown.Name = "lblUpDown";
            this.lblUpDown.Size = new System.Drawing.Size(77, 13);
            this.lblUpDown.TabIndex = 2;
            this.lblUpDown.Text = "Up/Down Flag";
            // 
            // lblPrimaryStatus
            // 
            this.lblPrimaryStatus.AutoSize = true;
            this.lblPrimaryStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrimaryStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimaryStatus.Location = new System.Drawing.Point(16, 66);
            this.lblPrimaryStatus.Name = "lblPrimaryStatus";
            this.lblPrimaryStatus.Size = new System.Drawing.Size(74, 13);
            this.lblPrimaryStatus.TabIndex = 4;
            this.lblPrimaryStatus.Text = "Primary Status";
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(3, 88);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(708, 45);
            this.grpComment.TabIndex = 0;
            this.grpComment.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(124, 15);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(571, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 17);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.grpStatus);
            this.tabStatus.Location = new System.Drawing.Point(4, 22);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tabStatus.Size = new System.Drawing.Size(714, 136);
            this.tabStatus.TabIndex = 0;
            this.tabStatus.Text = "Change Status";
            this.tabStatus.Visible = false;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.cdvChangeStatus10);
            this.grpStatus.Controls.Add(this.cdvChangeStatus9);
            this.grpStatus.Controls.Add(this.cdvChangeStatus8);
            this.grpStatus.Controls.Add(this.cdvChangeStatus7);
            this.grpStatus.Controls.Add(this.cdvChangeStatus6);
            this.grpStatus.Controls.Add(this.cdvChangeStatus5);
            this.grpStatus.Controls.Add(this.cdvChangeStatus4);
            this.grpStatus.Controls.Add(this.cdvChangeStatus3);
            this.grpStatus.Controls.Add(this.cdvChangeStatus2);
            this.grpStatus.Controls.Add(this.cdvChangeStatus1);
            this.grpStatus.Controls.Add(this.lblStatus10);
            this.grpStatus.Controls.Add(this.lblStatus9);
            this.grpStatus.Controls.Add(this.lblStatus8);
            this.grpStatus.Controls.Add(this.lblStatus7);
            this.grpStatus.Controls.Add(this.lblStatus6);
            this.grpStatus.Controls.Add(this.lblStatus5);
            this.grpStatus.Controls.Add(this.lblStatus4);
            this.grpStatus.Controls.Add(this.lblStatus3);
            this.grpStatus.Controls.Add(this.lblStatus2);
            this.grpStatus.Controls.Add(this.lblStatus1);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpStatus.Location = new System.Drawing.Point(3, 0);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(708, 133);
            this.grpStatus.TabIndex = 0;
            this.grpStatus.TabStop = false;
            // 
            // cdvChangeStatus10
            // 
            this.cdvChangeStatus10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus10.BtnToolTipText = "";
            this.cdvChangeStatus10.DescText = "";
            this.cdvChangeStatus10.DisplaySubItemIndex = -1;
            this.cdvChangeStatus10.DisplayText = "";
            this.cdvChangeStatus10.Focusing = null;
            this.cdvChangeStatus10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus10.Index = 0;
            this.cdvChangeStatus10.IsViewBtnImage = false;
            this.cdvChangeStatus10.Location = new System.Drawing.Point(514, 110);
            this.cdvChangeStatus10.MaxLength = 32767;
            this.cdvChangeStatus10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus10.Name = "cdvChangeStatus10";
            this.cdvChangeStatus10.ReadOnly = true;
            this.cdvChangeStatus10.SearchSubItemIndex = 0;
            this.cdvChangeStatus10.SelectedDescIndex = -1;
            this.cdvChangeStatus10.SelectedSubItemIndex = -1;
            this.cdvChangeStatus10.SelectionStart = 0;
            this.cdvChangeStatus10.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus10.SmallImageList = null;
            this.cdvChangeStatus10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus10.TabIndex = 19;
            this.cdvChangeStatus10.TextBoxToolTipText = "";
            this.cdvChangeStatus10.TextBoxWidth = 176;
            this.cdvChangeStatus10.VisibleButton = true;
            this.cdvChangeStatus10.VisibleColumnHeader = false;
            this.cdvChangeStatus10.VisibleDescription = false;
            this.cdvChangeStatus10.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus9
            // 
            this.cdvChangeStatus9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus9.BtnToolTipText = "";
            this.cdvChangeStatus9.DescText = "";
            this.cdvChangeStatus9.DisplaySubItemIndex = -1;
            this.cdvChangeStatus9.DisplayText = "";
            this.cdvChangeStatus9.Focusing = null;
            this.cdvChangeStatus9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus9.Index = 0;
            this.cdvChangeStatus9.IsViewBtnImage = false;
            this.cdvChangeStatus9.Location = new System.Drawing.Point(514, 86);
            this.cdvChangeStatus9.MaxLength = 32767;
            this.cdvChangeStatus9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus9.Name = "cdvChangeStatus9";
            this.cdvChangeStatus9.ReadOnly = true;
            this.cdvChangeStatus9.SearchSubItemIndex = 0;
            this.cdvChangeStatus9.SelectedDescIndex = -1;
            this.cdvChangeStatus9.SelectedSubItemIndex = -1;
            this.cdvChangeStatus9.SelectionStart = 0;
            this.cdvChangeStatus9.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus9.SmallImageList = null;
            this.cdvChangeStatus9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus9.TabIndex = 17;
            this.cdvChangeStatus9.TextBoxToolTipText = "";
            this.cdvChangeStatus9.TextBoxWidth = 176;
            this.cdvChangeStatus9.VisibleButton = true;
            this.cdvChangeStatus9.VisibleColumnHeader = false;
            this.cdvChangeStatus9.VisibleDescription = false;
            this.cdvChangeStatus9.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus8
            // 
            this.cdvChangeStatus8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus8.BtnToolTipText = "";
            this.cdvChangeStatus8.DescText = "";
            this.cdvChangeStatus8.DisplaySubItemIndex = -1;
            this.cdvChangeStatus8.DisplayText = "";
            this.cdvChangeStatus8.Focusing = null;
            this.cdvChangeStatus8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus8.Index = 0;
            this.cdvChangeStatus8.IsViewBtnImage = false;
            this.cdvChangeStatus8.Location = new System.Drawing.Point(514, 62);
            this.cdvChangeStatus8.MaxLength = 32767;
            this.cdvChangeStatus8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus8.Name = "cdvChangeStatus8";
            this.cdvChangeStatus8.ReadOnly = true;
            this.cdvChangeStatus8.SearchSubItemIndex = 0;
            this.cdvChangeStatus8.SelectedDescIndex = -1;
            this.cdvChangeStatus8.SelectedSubItemIndex = -1;
            this.cdvChangeStatus8.SelectionStart = 0;
            this.cdvChangeStatus8.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus8.SmallImageList = null;
            this.cdvChangeStatus8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus8.TabIndex = 15;
            this.cdvChangeStatus8.TextBoxToolTipText = "";
            this.cdvChangeStatus8.TextBoxWidth = 176;
            this.cdvChangeStatus8.VisibleButton = true;
            this.cdvChangeStatus8.VisibleColumnHeader = false;
            this.cdvChangeStatus8.VisibleDescription = false;
            this.cdvChangeStatus8.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus7
            // 
            this.cdvChangeStatus7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus7.BtnToolTipText = "";
            this.cdvChangeStatus7.DescText = "";
            this.cdvChangeStatus7.DisplaySubItemIndex = -1;
            this.cdvChangeStatus7.DisplayText = "";
            this.cdvChangeStatus7.Focusing = null;
            this.cdvChangeStatus7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus7.Index = 0;
            this.cdvChangeStatus7.IsViewBtnImage = false;
            this.cdvChangeStatus7.Location = new System.Drawing.Point(514, 38);
            this.cdvChangeStatus7.MaxLength = 32767;
            this.cdvChangeStatus7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus7.Name = "cdvChangeStatus7";
            this.cdvChangeStatus7.ReadOnly = true;
            this.cdvChangeStatus7.SearchSubItemIndex = 0;
            this.cdvChangeStatus7.SelectedDescIndex = -1;
            this.cdvChangeStatus7.SelectedSubItemIndex = -1;
            this.cdvChangeStatus7.SelectionStart = 0;
            this.cdvChangeStatus7.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus7.SmallImageList = null;
            this.cdvChangeStatus7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus7.TabIndex = 13;
            this.cdvChangeStatus7.TextBoxToolTipText = "";
            this.cdvChangeStatus7.TextBoxWidth = 176;
            this.cdvChangeStatus7.VisibleButton = true;
            this.cdvChangeStatus7.VisibleColumnHeader = false;
            this.cdvChangeStatus7.VisibleDescription = false;
            this.cdvChangeStatus7.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus6
            // 
            this.cdvChangeStatus6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus6.BtnToolTipText = "";
            this.cdvChangeStatus6.DescText = "";
            this.cdvChangeStatus6.DisplaySubItemIndex = -1;
            this.cdvChangeStatus6.DisplayText = "";
            this.cdvChangeStatus6.Focusing = null;
            this.cdvChangeStatus6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus6.Index = 0;
            this.cdvChangeStatus6.IsViewBtnImage = false;
            this.cdvChangeStatus6.Location = new System.Drawing.Point(514, 14);
            this.cdvChangeStatus6.MaxLength = 32767;
            this.cdvChangeStatus6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus6.Name = "cdvChangeStatus6";
            this.cdvChangeStatus6.ReadOnly = true;
            this.cdvChangeStatus6.SearchSubItemIndex = 0;
            this.cdvChangeStatus6.SelectedDescIndex = -1;
            this.cdvChangeStatus6.SelectedSubItemIndex = -1;
            this.cdvChangeStatus6.SelectionStart = 0;
            this.cdvChangeStatus6.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus6.SmallImageList = null;
            this.cdvChangeStatus6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus6.TabIndex = 11;
            this.cdvChangeStatus6.TextBoxToolTipText = "";
            this.cdvChangeStatus6.TextBoxWidth = 176;
            this.cdvChangeStatus6.VisibleButton = true;
            this.cdvChangeStatus6.VisibleColumnHeader = false;
            this.cdvChangeStatus6.VisibleDescription = false;
            this.cdvChangeStatus6.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus5
            // 
            this.cdvChangeStatus5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus5.BtnToolTipText = "";
            this.cdvChangeStatus5.DescText = "";
            this.cdvChangeStatus5.DisplaySubItemIndex = -1;
            this.cdvChangeStatus5.DisplayText = "";
            this.cdvChangeStatus5.Focusing = null;
            this.cdvChangeStatus5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus5.Index = 0;
            this.cdvChangeStatus5.IsViewBtnImage = false;
            this.cdvChangeStatus5.Location = new System.Drawing.Point(136, 110);
            this.cdvChangeStatus5.MaxLength = 32767;
            this.cdvChangeStatus5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus5.Name = "cdvChangeStatus5";
            this.cdvChangeStatus5.ReadOnly = true;
            this.cdvChangeStatus5.SearchSubItemIndex = 0;
            this.cdvChangeStatus5.SelectedDescIndex = -1;
            this.cdvChangeStatus5.SelectedSubItemIndex = -1;
            this.cdvChangeStatus5.SelectionStart = 0;
            this.cdvChangeStatus5.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus5.SmallImageList = null;
            this.cdvChangeStatus5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus5.TabIndex = 9;
            this.cdvChangeStatus5.TextBoxToolTipText = "";
            this.cdvChangeStatus5.TextBoxWidth = 176;
            this.cdvChangeStatus5.VisibleButton = true;
            this.cdvChangeStatus5.VisibleColumnHeader = false;
            this.cdvChangeStatus5.VisibleDescription = false;
            this.cdvChangeStatus5.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus4
            // 
            this.cdvChangeStatus4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus4.BtnToolTipText = "";
            this.cdvChangeStatus4.DescText = "";
            this.cdvChangeStatus4.DisplaySubItemIndex = -1;
            this.cdvChangeStatus4.DisplayText = "";
            this.cdvChangeStatus4.Focusing = null;
            this.cdvChangeStatus4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus4.Index = 0;
            this.cdvChangeStatus4.IsViewBtnImage = false;
            this.cdvChangeStatus4.Location = new System.Drawing.Point(136, 86);
            this.cdvChangeStatus4.MaxLength = 32767;
            this.cdvChangeStatus4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus4.Name = "cdvChangeStatus4";
            this.cdvChangeStatus4.ReadOnly = true;
            this.cdvChangeStatus4.SearchSubItemIndex = 0;
            this.cdvChangeStatus4.SelectedDescIndex = -1;
            this.cdvChangeStatus4.SelectedSubItemIndex = -1;
            this.cdvChangeStatus4.SelectionStart = 0;
            this.cdvChangeStatus4.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus4.SmallImageList = null;
            this.cdvChangeStatus4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus4.TabIndex = 7;
            this.cdvChangeStatus4.TextBoxToolTipText = "";
            this.cdvChangeStatus4.TextBoxWidth = 176;
            this.cdvChangeStatus4.VisibleButton = true;
            this.cdvChangeStatus4.VisibleColumnHeader = false;
            this.cdvChangeStatus4.VisibleDescription = false;
            this.cdvChangeStatus4.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus3
            // 
            this.cdvChangeStatus3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus3.BtnToolTipText = "";
            this.cdvChangeStatus3.DescText = "";
            this.cdvChangeStatus3.DisplaySubItemIndex = -1;
            this.cdvChangeStatus3.DisplayText = "";
            this.cdvChangeStatus3.Focusing = null;
            this.cdvChangeStatus3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus3.Index = 0;
            this.cdvChangeStatus3.IsViewBtnImage = false;
            this.cdvChangeStatus3.Location = new System.Drawing.Point(136, 62);
            this.cdvChangeStatus3.MaxLength = 32767;
            this.cdvChangeStatus3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus3.Name = "cdvChangeStatus3";
            this.cdvChangeStatus3.ReadOnly = true;
            this.cdvChangeStatus3.SearchSubItemIndex = 0;
            this.cdvChangeStatus3.SelectedDescIndex = -1;
            this.cdvChangeStatus3.SelectedSubItemIndex = -1;
            this.cdvChangeStatus3.SelectionStart = 0;
            this.cdvChangeStatus3.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus3.SmallImageList = null;
            this.cdvChangeStatus3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus3.TabIndex = 5;
            this.cdvChangeStatus3.TextBoxToolTipText = "";
            this.cdvChangeStatus3.TextBoxWidth = 176;
            this.cdvChangeStatus3.VisibleButton = true;
            this.cdvChangeStatus3.VisibleColumnHeader = false;
            this.cdvChangeStatus3.VisibleDescription = false;
            this.cdvChangeStatus3.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus2
            // 
            this.cdvChangeStatus2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus2.BtnToolTipText = "";
            this.cdvChangeStatus2.DescText = "";
            this.cdvChangeStatus2.DisplaySubItemIndex = -1;
            this.cdvChangeStatus2.DisplayText = "";
            this.cdvChangeStatus2.Focusing = null;
            this.cdvChangeStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus2.Index = 0;
            this.cdvChangeStatus2.IsViewBtnImage = false;
            this.cdvChangeStatus2.Location = new System.Drawing.Point(136, 38);
            this.cdvChangeStatus2.MaxLength = 32767;
            this.cdvChangeStatus2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus2.Name = "cdvChangeStatus2";
            this.cdvChangeStatus2.ReadOnly = true;
            this.cdvChangeStatus2.SearchSubItemIndex = 0;
            this.cdvChangeStatus2.SelectedDescIndex = -1;
            this.cdvChangeStatus2.SelectedSubItemIndex = -1;
            this.cdvChangeStatus2.SelectionStart = 0;
            this.cdvChangeStatus2.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus2.SmallImageList = null;
            this.cdvChangeStatus2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus2.TabIndex = 3;
            this.cdvChangeStatus2.TextBoxToolTipText = "";
            this.cdvChangeStatus2.TextBoxWidth = 176;
            this.cdvChangeStatus2.VisibleButton = true;
            this.cdvChangeStatus2.VisibleColumnHeader = false;
            this.cdvChangeStatus2.VisibleDescription = false;
            this.cdvChangeStatus2.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus1
            // 
            this.cdvChangeStatus1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus1.BtnToolTipText = "";
            this.cdvChangeStatus1.DescText = "";
            this.cdvChangeStatus1.DisplaySubItemIndex = -1;
            this.cdvChangeStatus1.DisplayText = "";
            this.cdvChangeStatus1.Focusing = null;
            this.cdvChangeStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus1.Index = 0;
            this.cdvChangeStatus1.IsViewBtnImage = false;
            this.cdvChangeStatus1.Location = new System.Drawing.Point(136, 14);
            this.cdvChangeStatus1.MaxLength = 32767;
            this.cdvChangeStatus1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus1.Name = "cdvChangeStatus1";
            this.cdvChangeStatus1.ReadOnly = true;
            this.cdvChangeStatus1.SearchSubItemIndex = 0;
            this.cdvChangeStatus1.SelectedDescIndex = -1;
            this.cdvChangeStatus1.SelectedSubItemIndex = -1;
            this.cdvChangeStatus1.SelectionStart = 0;
            this.cdvChangeStatus1.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus1.SmallImageList = null;
            this.cdvChangeStatus1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus1.TabIndex = 1;
            this.cdvChangeStatus1.TextBoxToolTipText = "";
            this.cdvChangeStatus1.TextBoxWidth = 176;
            this.cdvChangeStatus1.VisibleButton = true;
            this.cdvChangeStatus1.VisibleColumnHeader = false;
            this.cdvChangeStatus1.VisibleDescription = false;
            this.cdvChangeStatus1.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // lblStatus10
            // 
            this.lblStatus10.AutoSize = true;
            this.lblStatus10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus10.Location = new System.Drawing.Point(392, 113);
            this.lblStatus10.Name = "lblStatus10";
            this.lblStatus10.Size = new System.Drawing.Size(52, 13);
            this.lblStatus10.TabIndex = 18;
            this.lblStatus10.Text = "Status 10";
            // 
            // lblStatus9
            // 
            this.lblStatus9.AutoSize = true;
            this.lblStatus9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus9.Location = new System.Drawing.Point(392, 89);
            this.lblStatus9.Name = "lblStatus9";
            this.lblStatus9.Size = new System.Drawing.Size(46, 13);
            this.lblStatus9.TabIndex = 16;
            this.lblStatus9.Text = "Status 9";
            // 
            // lblStatus8
            // 
            this.lblStatus8.AutoSize = true;
            this.lblStatus8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus8.Location = new System.Drawing.Point(392, 65);
            this.lblStatus8.Name = "lblStatus8";
            this.lblStatus8.Size = new System.Drawing.Size(46, 13);
            this.lblStatus8.TabIndex = 14;
            this.lblStatus8.Text = "Status 8";
            // 
            // lblStatus7
            // 
            this.lblStatus7.AutoSize = true;
            this.lblStatus7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus7.Location = new System.Drawing.Point(392, 41);
            this.lblStatus7.Name = "lblStatus7";
            this.lblStatus7.Size = new System.Drawing.Size(46, 13);
            this.lblStatus7.TabIndex = 12;
            this.lblStatus7.Text = "Status 7";
            // 
            // lblStatus6
            // 
            this.lblStatus6.AutoSize = true;
            this.lblStatus6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus6.Location = new System.Drawing.Point(392, 17);
            this.lblStatus6.Name = "lblStatus6";
            this.lblStatus6.Size = new System.Drawing.Size(46, 13);
            this.lblStatus6.TabIndex = 10;
            this.lblStatus6.Text = "Status 6";
            // 
            // lblStatus5
            // 
            this.lblStatus5.AutoSize = true;
            this.lblStatus5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus5.Location = new System.Drawing.Point(14, 113);
            this.lblStatus5.Name = "lblStatus5";
            this.lblStatus5.Size = new System.Drawing.Size(46, 13);
            this.lblStatus5.TabIndex = 8;
            this.lblStatus5.Text = "Status 5";
            // 
            // lblStatus4
            // 
            this.lblStatus4.AutoSize = true;
            this.lblStatus4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus4.Location = new System.Drawing.Point(14, 89);
            this.lblStatus4.Name = "lblStatus4";
            this.lblStatus4.Size = new System.Drawing.Size(46, 13);
            this.lblStatus4.TabIndex = 6;
            this.lblStatus4.Text = "Status 4";
            // 
            // lblStatus3
            // 
            this.lblStatus3.AutoSize = true;
            this.lblStatus3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus3.Location = new System.Drawing.Point(14, 65);
            this.lblStatus3.Name = "lblStatus3";
            this.lblStatus3.Size = new System.Drawing.Size(46, 13);
            this.lblStatus3.TabIndex = 4;
            this.lblStatus3.Text = "Status 3";
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoSize = true;
            this.lblStatus2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus2.Location = new System.Drawing.Point(14, 41);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(46, 13);
            this.lblStatus2.TabIndex = 2;
            this.lblStatus2.Text = "Status 2";
            // 
            // lblStatus1
            // 
            this.lblStatus1.AutoSize = true;
            this.lblStatus1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus1.Location = new System.Drawing.Point(14, 17);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(46, 13);
            this.lblStatus1.TabIndex = 0;
            this.lblStatus1.Text = "Status 1";
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCMF.Size = new System.Drawing.Size(728, 477);
            this.tbpCMF.TabIndex = 1;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.Visible = false;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF19);
            this.grpCMF.Controls.Add(this.cdvCMF18);
            this.grpCMF.Controls.Add(this.cdvCMF17);
            this.grpCMF.Controls.Add(this.cdvCMF16);
            this.grpCMF.Controls.Add(this.cdvCMF15);
            this.grpCMF.Controls.Add(this.cdvCMF14);
            this.grpCMF.Controls.Add(this.cdvCMF13);
            this.grpCMF.Controls.Add(this.cdvCMF12);
            this.grpCMF.Controls.Add(this.cdvCMF20);
            this.grpCMF.Controls.Add(this.cdvCMF11);
            this.grpCMF.Controls.Add(this.lblCMF20);
            this.grpCMF.Controls.Add(this.lblCMF19);
            this.grpCMF.Controls.Add(this.lblCMF18);
            this.grpCMF.Controls.Add(this.lblCMF17);
            this.grpCMF.Controls.Add(this.lblCMF16);
            this.grpCMF.Controls.Add(this.lblCMF15);
            this.grpCMF.Controls.Add(this.lblCMF14);
            this.grpCMF.Controls.Add(this.lblCMF13);
            this.grpCMF.Controls.Add(this.lblCMF12);
            this.grpCMF.Controls.Add(this.lblCMF11);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.Location = new System.Drawing.Point(3, 3);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(722, 471);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF19.BtnToolTipText = "";
            this.cdvCMF19.DescText = "";
            this.cdvCMF19.DisplaySubItemIndex = -1;
            this.cdvCMF19.DisplayText = "";
            this.cdvCMF19.Focusing = null;
            this.cdvCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF19.Index = 0;
            this.cdvCMF19.IsViewBtnImage = false;
            this.cdvCMF19.Location = new System.Drawing.Point(530, 208);
            this.cdvCMF19.MaxLength = 30;
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.Name = "cdvCMF19";
            this.cdvCMF19.ReadOnly = false;
            this.cdvCMF19.SearchSubItemIndex = 0;
            this.cdvCMF19.SelectedDescIndex = -1;
            this.cdvCMF19.SelectedSubItemIndex = -1;
            this.cdvCMF19.SelectionStart = 0;
            this.cdvCMF19.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF19.SmallImageList = null;
            this.cdvCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF19.TabIndex = 37;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 180;
            this.cdvCMF19.VisibleButton = true;
            this.cdvCMF19.VisibleColumnHeader = false;
            this.cdvCMF19.VisibleDescription = false;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF18.BtnToolTipText = "";
            this.cdvCMF18.DescText = "";
            this.cdvCMF18.DisplaySubItemIndex = -1;
            this.cdvCMF18.DisplayText = "";
            this.cdvCMF18.Focusing = null;
            this.cdvCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF18.Index = 0;
            this.cdvCMF18.IsViewBtnImage = false;
            this.cdvCMF18.Location = new System.Drawing.Point(530, 184);
            this.cdvCMF18.MaxLength = 30;
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.Name = "cdvCMF18";
            this.cdvCMF18.ReadOnly = false;
            this.cdvCMF18.SearchSubItemIndex = 0;
            this.cdvCMF18.SelectedDescIndex = -1;
            this.cdvCMF18.SelectedSubItemIndex = -1;
            this.cdvCMF18.SelectionStart = 0;
            this.cdvCMF18.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF18.SmallImageList = null;
            this.cdvCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF18.TabIndex = 35;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 180;
            this.cdvCMF18.VisibleButton = true;
            this.cdvCMF18.VisibleColumnHeader = false;
            this.cdvCMF18.VisibleDescription = false;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF17.BtnToolTipText = "";
            this.cdvCMF17.DescText = "";
            this.cdvCMF17.DisplaySubItemIndex = -1;
            this.cdvCMF17.DisplayText = "";
            this.cdvCMF17.Focusing = null;
            this.cdvCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF17.Index = 0;
            this.cdvCMF17.IsViewBtnImage = false;
            this.cdvCMF17.Location = new System.Drawing.Point(530, 160);
            this.cdvCMF17.MaxLength = 30;
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.Name = "cdvCMF17";
            this.cdvCMF17.ReadOnly = false;
            this.cdvCMF17.SearchSubItemIndex = 0;
            this.cdvCMF17.SelectedDescIndex = -1;
            this.cdvCMF17.SelectedSubItemIndex = -1;
            this.cdvCMF17.SelectionStart = 0;
            this.cdvCMF17.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF17.SmallImageList = null;
            this.cdvCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF17.TabIndex = 33;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 180;
            this.cdvCMF17.VisibleButton = true;
            this.cdvCMF17.VisibleColumnHeader = false;
            this.cdvCMF17.VisibleDescription = false;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF16.BtnToolTipText = "";
            this.cdvCMF16.DescText = "";
            this.cdvCMF16.DisplaySubItemIndex = -1;
            this.cdvCMF16.DisplayText = "";
            this.cdvCMF16.Focusing = null;
            this.cdvCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF16.Index = 0;
            this.cdvCMF16.IsViewBtnImage = false;
            this.cdvCMF16.Location = new System.Drawing.Point(530, 136);
            this.cdvCMF16.MaxLength = 30;
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.Name = "cdvCMF16";
            this.cdvCMF16.ReadOnly = false;
            this.cdvCMF16.SearchSubItemIndex = 0;
            this.cdvCMF16.SelectedDescIndex = -1;
            this.cdvCMF16.SelectedSubItemIndex = -1;
            this.cdvCMF16.SelectionStart = 0;
            this.cdvCMF16.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF16.SmallImageList = null;
            this.cdvCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF16.TabIndex = 31;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 180;
            this.cdvCMF16.VisibleButton = true;
            this.cdvCMF16.VisibleColumnHeader = false;
            this.cdvCMF16.VisibleDescription = false;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF15.BtnToolTipText = "";
            this.cdvCMF15.DescText = "";
            this.cdvCMF15.DisplaySubItemIndex = -1;
            this.cdvCMF15.DisplayText = "";
            this.cdvCMF15.Focusing = null;
            this.cdvCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF15.Index = 0;
            this.cdvCMF15.IsViewBtnImage = false;
            this.cdvCMF15.Location = new System.Drawing.Point(530, 112);
            this.cdvCMF15.MaxLength = 30;
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.Name = "cdvCMF15";
            this.cdvCMF15.ReadOnly = false;
            this.cdvCMF15.SearchSubItemIndex = 0;
            this.cdvCMF15.SelectedDescIndex = -1;
            this.cdvCMF15.SelectedSubItemIndex = -1;
            this.cdvCMF15.SelectionStart = 0;
            this.cdvCMF15.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF15.SmallImageList = null;
            this.cdvCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF15.TabIndex = 29;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 180;
            this.cdvCMF15.VisibleButton = true;
            this.cdvCMF15.VisibleColumnHeader = false;
            this.cdvCMF15.VisibleDescription = false;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF14.BtnToolTipText = "";
            this.cdvCMF14.DescText = "";
            this.cdvCMF14.DisplaySubItemIndex = -1;
            this.cdvCMF14.DisplayText = "";
            this.cdvCMF14.Focusing = null;
            this.cdvCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF14.Index = 0;
            this.cdvCMF14.IsViewBtnImage = false;
            this.cdvCMF14.Location = new System.Drawing.Point(530, 88);
            this.cdvCMF14.MaxLength = 30;
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.Name = "cdvCMF14";
            this.cdvCMF14.ReadOnly = false;
            this.cdvCMF14.SearchSubItemIndex = 0;
            this.cdvCMF14.SelectedDescIndex = -1;
            this.cdvCMF14.SelectedSubItemIndex = -1;
            this.cdvCMF14.SelectionStart = 0;
            this.cdvCMF14.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF14.SmallImageList = null;
            this.cdvCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF14.TabIndex = 27;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 180;
            this.cdvCMF14.VisibleButton = true;
            this.cdvCMF14.VisibleColumnHeader = false;
            this.cdvCMF14.VisibleDescription = false;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF13.BtnToolTipText = "";
            this.cdvCMF13.DescText = "";
            this.cdvCMF13.DisplaySubItemIndex = -1;
            this.cdvCMF13.DisplayText = "";
            this.cdvCMF13.Focusing = null;
            this.cdvCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF13.Index = 0;
            this.cdvCMF13.IsViewBtnImage = false;
            this.cdvCMF13.Location = new System.Drawing.Point(530, 64);
            this.cdvCMF13.MaxLength = 30;
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.Name = "cdvCMF13";
            this.cdvCMF13.ReadOnly = false;
            this.cdvCMF13.SearchSubItemIndex = 0;
            this.cdvCMF13.SelectedDescIndex = -1;
            this.cdvCMF13.SelectedSubItemIndex = -1;
            this.cdvCMF13.SelectionStart = 0;
            this.cdvCMF13.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF13.SmallImageList = null;
            this.cdvCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF13.TabIndex = 25;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 180;
            this.cdvCMF13.VisibleButton = true;
            this.cdvCMF13.VisibleColumnHeader = false;
            this.cdvCMF13.VisibleDescription = false;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF12.BtnToolTipText = "";
            this.cdvCMF12.DescText = "";
            this.cdvCMF12.DisplaySubItemIndex = -1;
            this.cdvCMF12.DisplayText = "";
            this.cdvCMF12.Focusing = null;
            this.cdvCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF12.Index = 0;
            this.cdvCMF12.IsViewBtnImage = false;
            this.cdvCMF12.Location = new System.Drawing.Point(530, 40);
            this.cdvCMF12.MaxLength = 30;
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.Name = "cdvCMF12";
            this.cdvCMF12.ReadOnly = false;
            this.cdvCMF12.SearchSubItemIndex = 0;
            this.cdvCMF12.SelectedDescIndex = -1;
            this.cdvCMF12.SelectedSubItemIndex = -1;
            this.cdvCMF12.SelectionStart = 0;
            this.cdvCMF12.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF12.SmallImageList = null;
            this.cdvCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF12.TabIndex = 23;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 180;
            this.cdvCMF12.VisibleButton = true;
            this.cdvCMF12.VisibleColumnHeader = false;
            this.cdvCMF12.VisibleDescription = false;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF20.BtnToolTipText = "";
            this.cdvCMF20.DescText = "";
            this.cdvCMF20.DisplaySubItemIndex = -1;
            this.cdvCMF20.DisplayText = "";
            this.cdvCMF20.Focusing = null;
            this.cdvCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF20.Index = 0;
            this.cdvCMF20.IsViewBtnImage = false;
            this.cdvCMF20.Location = new System.Drawing.Point(530, 232);
            this.cdvCMF20.MaxLength = 30;
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.Name = "cdvCMF20";
            this.cdvCMF20.ReadOnly = false;
            this.cdvCMF20.SearchSubItemIndex = 0;
            this.cdvCMF20.SelectedDescIndex = -1;
            this.cdvCMF20.SelectedSubItemIndex = -1;
            this.cdvCMF20.SelectionStart = 0;
            this.cdvCMF20.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF20.SmallImageList = null;
            this.cdvCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF20.TabIndex = 39;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 180;
            this.cdvCMF20.VisibleButton = true;
            this.cdvCMF20.VisibleColumnHeader = false;
            this.cdvCMF20.VisibleDescription = false;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF11.BtnToolTipText = "";
            this.cdvCMF11.DescText = "";
            this.cdvCMF11.DisplaySubItemIndex = -1;
            this.cdvCMF11.DisplayText = "";
            this.cdvCMF11.Focusing = null;
            this.cdvCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF11.Index = 0;
            this.cdvCMF11.IsViewBtnImage = false;
            this.cdvCMF11.Location = new System.Drawing.Point(530, 16);
            this.cdvCMF11.MaxLength = 30;
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.Name = "cdvCMF11";
            this.cdvCMF11.ReadOnly = false;
            this.cdvCMF11.SearchSubItemIndex = 0;
            this.cdvCMF11.SelectedDescIndex = -1;
            this.cdvCMF11.SelectedSubItemIndex = -1;
            this.cdvCMF11.SelectionStart = 0;
            this.cdvCMF11.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF11.SmallImageList = null;
            this.cdvCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF11.TabIndex = 21;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 180;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(384, 236);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(140, 14);
            this.lblCMF20.TabIndex = 38;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(384, 212);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(140, 14);
            this.lblCMF19.TabIndex = 36;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(384, 188);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(140, 14);
            this.lblCMF18.TabIndex = 34;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(384, 164);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(140, 14);
            this.lblCMF17.TabIndex = 32;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(384, 140);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(140, 14);
            this.lblCMF16.TabIndex = 30;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(384, 116);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(140, 14);
            this.lblCMF15.TabIndex = 28;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(384, 92);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(140, 14);
            this.lblCMF14.TabIndex = 26;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(384, 68);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(140, 14);
            this.lblCMF13.TabIndex = 24;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(384, 44);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(140, 14);
            this.lblCMF12.TabIndex = 22;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(384, 20);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(140, 14);
            this.lblCMF11.TabIndex = 20;
            this.lblCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(163, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 180;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(163, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 180;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(163, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 180;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(163, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 180;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(163, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 180;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(163, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 180;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(163, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 180;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(163, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 180;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(163, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 180;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(163, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 180;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(17, 236);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(17, 212);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(17, 188);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(17, 164);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(17, 140);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(17, 116);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(17, 92);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(17, 68);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(17, 44);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(17, 20);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.Location = new System.Drawing.Point(467, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmRASTranMultiEvent
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASTranMultiEvent";
            this.Text = "Multi Event";
            this.Activated += new System.EventHandler(this.frmRASTranMultiEvent_Activated);
            this.Load += new System.EventHandler(this.frmRASTranMultiEvent_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlConditionInfo.ResumeLayout(false);
            this.pnlLotList.ResumeLayout(false);
            this.grpResourceList.ResumeLayout(false);
            this.pnlCheck.ResumeLayout(false);
            this.grpCheck.ResumeLayout(false);
            this.grpConditionInfo.ResumeLayout(false);
            this.grpConditionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLastEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            this.pnlTran.ResumeLayout(false);
            this.tabResource.ResumeLayout(false);
            this.tbpEvent.ResumeLayout(false);
            this.grpTran.ResumeLayout(false);
            this.grpTran.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrimaryChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).EndInit();
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tabStatus.ResumeLayout(false);
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus1)).EndInit();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TabControl tabTran;
        protected System.Windows.Forms.TabPage tbpGeneral;
        protected System.Windows.Forms.Panel pnlTranInfo;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.Label lblComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.TabPage tbpCMF;
        protected System.Windows.Forms.GroupBox grpCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF20;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF11;
        protected System.Windows.Forms.Label lblCMF20;
        protected System.Windows.Forms.Label lblCMF19;
        protected System.Windows.Forms.Label lblCMF18;
        protected System.Windows.Forms.Label lblCMF17;
        protected System.Windows.Forms.Label lblCMF16;
        protected System.Windows.Forms.Label lblCMF15;
        protected System.Windows.Forms.Label lblCMF14;
        protected System.Windows.Forms.Label lblCMF13;
        protected System.Windows.Forms.Label lblCMF12;
        protected System.Windows.Forms.Label lblCMF11;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        protected System.Windows.Forms.Label lblCMF10;
        protected System.Windows.Forms.Label lblCMF9;
        protected System.Windows.Forms.Label lblCMF8;
        protected System.Windows.Forms.Label lblCMF7;
        protected System.Windows.Forms.Label lblCMF6;
        protected System.Windows.Forms.Label lblCMF5;
        protected System.Windows.Forms.Label lblCMF4;
        protected System.Windows.Forms.Label lblCMF3;
        protected System.Windows.Forms.Label lblCMF2;
        protected System.Windows.Forms.Label lblCMF1;
        private System.Windows.Forms.Panel pnlConditionInfo;
        private System.Windows.Forms.GroupBox grpConditionInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLastEvent;
        private System.Windows.Forms.RadioButton rbtDown;
        private System.Windows.Forms.RadioButton rbtUp;
        private System.Windows.Forms.Label lblLastEvent;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label lblOperation;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrt1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Label lblType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp1;
        private System.Windows.Forms.Label lblPrt1;
        private System.Windows.Forms.Panel pnlCheck;
        private System.Windows.Forms.GroupBox grpCheck;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Panel pnlLotList;
        private System.Windows.Forms.GroupBox grpResourceList;
        private System.Windows.Forms.Panel pnlTran;
        private System.Windows.Forms.TabControl tabResource;
        private System.Windows.Forms.TabPage tbpEvent;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblStatus10;
        private System.Windows.Forms.Label lblStatus9;
        private System.Windows.Forms.Label lblStatus8;
        private System.Windows.Forms.Label lblStatus7;
        private System.Windows.Forms.Label lblStatus6;
        private System.Windows.Forms.Label lblStatus5;
        private System.Windows.Forms.Label lblStatus4;
        private System.Windows.Forms.Label lblStatus3;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.Label lblStatus1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEventID;
        private System.Windows.Forms.Label lblEventID;
        protected System.Windows.Forms.GroupBox grpTran;
        private System.Windows.Forms.Label lblUpDown;
        private System.Windows.Forms.Label lblPrimaryStatus;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrimaryChange;
        private System.Windows.Forms.TextBox txtChangeUpDown;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus6;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.Label lblUpDownFlag;
        private System.Windows.Forms.Button btnView;
        private Miracom.UI.Controls.MCListView.MCListView lisResourceList;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colRes;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colUpDown;
        private System.Windows.Forms.ColumnHeader colPriSts;
        private System.Windows.Forms.ColumnHeader colPrt1;
        private System.Windows.Forms.ColumnHeader colPrt2;
        private System.Windows.Forms.ColumnHeader colPrt3;
        private System.Windows.Forms.ColumnHeader colPrt4;
        private System.Windows.Forms.ColumnHeader colPrt5;
        private System.Windows.Forms.ColumnHeader colPrt6;
        private System.Windows.Forms.ColumnHeader colPrt7;
        private System.Windows.Forms.ColumnHeader colPrt8;
        private System.Windows.Forms.ColumnHeader colPrt9;
        private System.Windows.Forms.ColumnHeader colPrt10;
        private System.Windows.Forms.ColumnHeader colSts1;
        private System.Windows.Forms.ColumnHeader colSts2;
        private System.Windows.Forms.ColumnHeader colSts3;
        private System.Windows.Forms.ColumnHeader colSts4;
        private System.Windows.Forms.ColumnHeader colSts5;
        private System.Windows.Forms.ColumnHeader colSts6;
        private System.Windows.Forms.ColumnHeader colSts7;
        private System.Windows.Forms.ColumnHeader colSts8;
        private System.Windows.Forms.ColumnHeader colSts9;
        private System.Windows.Forms.ColumnHeader colSts10;
        private System.Windows.Forms.ColumnHeader colUseFac;
        private System.Windows.Forms.ColumnHeader colLastEvent;
        private System.Windows.Forms.ColumnHeader colLastEventTime;
        private System.Windows.Forms.ColumnHeader colLastStartTime;
        private System.Windows.Forms.ColumnHeader colLastEndTime;
        private System.Windows.Forms.ColumnHeader colProcCount;
        private System.Windows.Forms.ColumnHeader colMaxProcCount;
        private System.Windows.Forms.ColumnHeader colLot1;
        private System.Windows.Forms.ColumnHeader colLot2;
        private System.Windows.Forms.ColumnHeader colLot3;
        private System.Windows.Forms.ColumnHeader colLot4;
        private System.Windows.Forms.ColumnHeader colLot5;
        private System.Windows.Forms.ColumnHeader colLot6;
        private System.Windows.Forms.ColumnHeader colLot7;
        private System.Windows.Forms.ColumnHeader colLot8;
        private System.Windows.Forms.ColumnHeader colLot9;
        private System.Windows.Forms.ColumnHeader colLot10;
        private System.Windows.Forms.ColumnHeader colLastActiveHistSeq;
        private System.Windows.Forms.ColumnHeader colLastHistSeq;
        private System.Windows.Forms.ColumnHeader colCreateUser;
        private System.Windows.Forms.ColumnHeader colCreateTime;
        private System.Windows.Forms.ColumnHeader colUpdateUser;
        private System.Windows.Forms.ColumnHeader colUpdateTime;

    }
}
