namespace Miracom.UTLCore
{
    partial class frmUTLPerformanceTest
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUTLPerformanceTest));
            this.grpCreation = new System.Windows.Forms.GroupBox();
            this.chkIgnoreError = new System.Windows.Forms.CheckBox();
            this.chkRandomQty = new System.Windows.Forms.CheckBox();
            this.txtNowTime = new System.Windows.Forms.TextBox();
            this.cboLotID = new System.Windows.Forms.ComboBox();
            this.txtServiceCount = new System.Windows.Forms.TextBox();
            this.txtAvgTime = new System.Windows.Forms.TextBox();
            this.txtMaxTime = new System.Windows.Forms.TextBox();
            this.lblMinTime = new System.Windows.Forms.Label();
            this.txtMinTime = new System.Windows.Forms.TextBox();
            this.lblPrgTotal = new System.Windows.Forms.Label();
            this.prgTotal = new System.Windows.Forms.ProgressBar();
            this.lblProgress2 = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.txtElapsedTime = new System.Windows.Forms.TextBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtLotQty = new System.Windows.Forms.TextBox();
            this.lblLotQty = new System.Windows.Forms.Label();
            this.txtLotCount = new System.Windows.Forms.TextBox();
            this.lblLotCount = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.grpCreated = new System.Windows.Forms.GroupBox();
            this.lisLotList = new System.Windows.Forms.ListView();
            this.colThread = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colElapsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSplit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMerge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEDC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnEvent = new System.Windows.Forms.Button();
            this.udcResID = new Miracom.MESCore.Controls.udcResource();
            this.grpTestThread = new System.Windows.Forms.GroupBox();
            this.txtTotalLotCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.lblThreadCount = new System.Windows.Forms.Label();
            this.prgRunning = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpCreation.SuspendLayout();
            this.grpCreated.SuspendLayout();
            this.grpTestThread.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(510, 7);
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(601, 7);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.udcResID);
            this.pnlBottom.Controls.Add(this.btnEvent);
            this.pnlBottom.Controls.Add(this.btnStop);
            this.pnlBottom.Controls.Add(this.btnExcelExport);
            this.pnlBottom.Location = new System.Drawing.Point(0, 502);
            this.pnlBottom.Size = new System.Drawing.Size(734, 40);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcelExport, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnStop, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnEvent, 0);
            this.pnlBottom.Controls.SetChildIndex(this.udcResID, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpCreated);
            this.pnlCenter.Controls.Add(this.grpCreation);
            this.pnlCenter.Controls.Add(this.grpTestThread);
            this.pnlCenter.Size = new System.Drawing.Size(734, 502);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // grpCreation
            // 
            this.grpCreation.Controls.Add(this.chkIgnoreError);
            this.grpCreation.Controls.Add(this.chkRandomQty);
            this.grpCreation.Controls.Add(this.txtNowTime);
            this.grpCreation.Controls.Add(this.cboLotID);
            this.grpCreation.Controls.Add(this.txtServiceCount);
            this.grpCreation.Controls.Add(this.txtAvgTime);
            this.grpCreation.Controls.Add(this.txtMaxTime);
            this.grpCreation.Controls.Add(this.lblMinTime);
            this.grpCreation.Controls.Add(this.txtMinTime);
            this.grpCreation.Controls.Add(this.lblPrgTotal);
            this.grpCreation.Controls.Add(this.prgTotal);
            this.grpCreation.Controls.Add(this.lblProgress2);
            this.grpCreation.Controls.Add(this.lblElapsedTime);
            this.grpCreation.Controls.Add(this.txtElapsedTime);
            this.grpCreation.Controls.Add(this.lblEndTime);
            this.grpCreation.Controls.Add(this.txtEndTime);
            this.grpCreation.Controls.Add(this.lblStartTime);
            this.grpCreation.Controls.Add(this.txtStartTime);
            this.grpCreation.Controls.Add(this.txtLotQty);
            this.grpCreation.Controls.Add(this.lblLotQty);
            this.grpCreation.Controls.Add(this.txtLotCount);
            this.grpCreation.Controls.Add(this.lblLotCount);
            this.grpCreation.Controls.Add(this.lblLotID);
            this.grpCreation.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCreation.Location = new System.Drawing.Point(0, 38);
            this.grpCreation.Name = "grpCreation";
            this.grpCreation.Size = new System.Drawing.Size(734, 116);
            this.grpCreation.TabIndex = 1;
            this.grpCreation.TabStop = false;
            this.grpCreation.Text = "Creation Information";
            // 
            // chkIgnoreError
            // 
            this.chkIgnoreError.AutoSize = true;
            this.chkIgnoreError.Location = new System.Drawing.Point(647, 15);
            this.chkIgnoreError.Name = "chkIgnoreError";
            this.chkIgnoreError.Size = new System.Drawing.Size(81, 17);
            this.chkIgnoreError.TabIndex = 27;
            this.chkIgnoreError.Text = "Ignore Error";
            this.chkIgnoreError.UseVisualStyleBackColor = true;
            // 
            // chkRandomQty
            // 
            this.chkRandomQty.AutoSize = true;
            this.chkRandomQty.Location = new System.Drawing.Point(535, 15);
            this.chkRandomQty.Name = "chkRandomQty";
            this.chkRandomQty.Size = new System.Drawing.Size(103, 17);
            this.chkRandomQty.TabIndex = 26;
            this.chkRandomQty.Text = "Random Lot Qty";
            this.chkRandomQty.UseVisualStyleBackColor = true;
            this.chkRandomQty.CheckedChanged += new System.EventHandler(this.chkRandomQty_CheckedChanged);
            // 
            // txtNowTime
            // 
            this.txtNowTime.Location = new System.Drawing.Point(642, 91);
            this.txtNowTime.Name = "txtNowTime";
            this.txtNowTime.ReadOnly = true;
            this.txtNowTime.Size = new System.Drawing.Size(80, 20);
            this.txtNowTime.TabIndex = 25;
            // 
            // cboLotID
            // 
            this.cboLotID.FormattingEnabled = true;
            this.cboLotID.Items.AddRange(new object[] {
            "$DATETIME",
            "$DATE",
            "$TIME"});
            this.cboLotID.Location = new System.Drawing.Point(130, 13);
            this.cboLotID.Name = "cboLotID";
            this.cboLotID.Size = new System.Drawing.Size(150, 21);
            this.cboLotID.TabIndex = 1;
            // 
            // txtServiceCount
            // 
            this.txtServiceCount.Location = new System.Drawing.Point(555, 91);
            this.txtServiceCount.Name = "txtServiceCount";
            this.txtServiceCount.ReadOnly = true;
            this.txtServiceCount.Size = new System.Drawing.Size(80, 20);
            this.txtServiceCount.TabIndex = 24;
            // 
            // txtAvgTime
            // 
            this.txtAvgTime.Location = new System.Drawing.Point(472, 91);
            this.txtAvgTime.Name = "txtAvgTime";
            this.txtAvgTime.ReadOnly = true;
            this.txtAvgTime.Size = new System.Drawing.Size(80, 20);
            this.txtAvgTime.TabIndex = 23;
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.Location = new System.Drawing.Point(389, 91);
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.ReadOnly = true;
            this.txtMaxTime.Size = new System.Drawing.Size(80, 20);
            this.txtMaxTime.TabIndex = 21;
            // 
            // lblMinTime
            // 
            this.lblMinTime.AutoSize = true;
            this.lblMinTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinTime.Location = new System.Drawing.Point(20, 94);
            this.lblMinTime.Name = "lblMinTime";
            this.lblMinTime.Size = new System.Drawing.Size(265, 13);
            this.lblMinTime.TabIndex = 18;
            this.lblMinTime.Text = "Elapsed Time(sec)/service MIN/MAX/AVG/CNT/Now";
            // 
            // txtMinTime
            // 
            this.txtMinTime.Location = new System.Drawing.Point(306, 91);
            this.txtMinTime.Name = "txtMinTime";
            this.txtMinTime.ReadOnly = true;
            this.txtMinTime.Size = new System.Drawing.Size(80, 20);
            this.txtMinTime.TabIndex = 19;
            // 
            // lblPrgTotal
            // 
            this.lblPrgTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPrgTotal.AutoSize = true;
            this.lblPrgTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblPrgTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrgTotal.Location = new System.Drawing.Point(402, 42);
            this.lblPrgTotal.Name = "lblPrgTotal";
            this.lblPrgTotal.Size = new System.Drawing.Size(81, 13);
            this.lblPrgTotal.TabIndex = 11;
            this.lblPrgTotal.Text = "Progress Status";
            // 
            // prgTotal
            // 
            this.prgTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgTotal.Location = new System.Drawing.Point(130, 38);
            this.prgTotal.Name = "prgTotal";
            this.prgTotal.Size = new System.Drawing.Size(592, 22);
            this.prgTotal.Step = 1;
            this.prgTotal.TabIndex = 10;
            // 
            // lblProgress2
            // 
            this.lblProgress2.AutoSize = true;
            this.lblProgress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress2.Location = new System.Drawing.Point(20, 43);
            this.lblProgress2.Name = "lblProgress2";
            this.lblProgress2.Size = new System.Drawing.Size(48, 13);
            this.lblProgress2.TabIndex = 9;
            this.lblProgress2.Text = "Progress";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsedTime.Location = new System.Drawing.Point(522, 71);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(94, 13);
            this.lblElapsedTime.TabIndex = 16;
            this.lblElapsedTime.Text = "Elapsed Time(sec)";
            // 
            // txtElapsedTime
            // 
            this.txtElapsedTime.Location = new System.Drawing.Point(622, 67);
            this.txtElapsedTime.Name = "txtElapsedTime";
            this.txtElapsedTime.ReadOnly = true;
            this.txtElapsedTime.Size = new System.Drawing.Size(100, 20);
            this.txtElapsedTime.TabIndex = 17;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(303, 70);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 13);
            this.lblEndTime.TabIndex = 14;
            this.lblEndTime.Text = "End Time";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(361, 66);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(150, 20);
            this.txtEndTime.TabIndex = 15;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(20, 70);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(55, 13);
            this.lblStartTime.TabIndex = 12;
            this.lblStartTime.Text = "Start Time";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(130, 66);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(150, 20);
            this.txtStartTime.TabIndex = 13;
            // 
            // txtLotQty
            // 
            this.txtLotQty.Location = new System.Drawing.Point(485, 13);
            this.txtLotQty.Name = "txtLotQty";
            this.txtLotQty.Size = new System.Drawing.Size(40, 20);
            this.txtLotQty.TabIndex = 5;
            // 
            // lblLotQty
            // 
            this.lblLotQty.AutoSize = true;
            this.lblLotQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotQty.Location = new System.Drawing.Point(431, 17);
            this.lblLotQty.Name = "lblLotQty";
            this.lblLotQty.Size = new System.Drawing.Size(48, 13);
            this.lblLotQty.TabIndex = 4;
            this.lblLotQty.Text = "Lot Qty";
            // 
            // txtLotCount
            // 
            this.txtLotCount.Location = new System.Drawing.Point(359, 13);
            this.txtLotCount.Name = "txtLotCount";
            this.txtLotCount.Size = new System.Drawing.Size(60, 20);
            this.txtLotCount.TabIndex = 3;
            // 
            // lblLotCount
            // 
            this.lblLotCount.AutoSize = true;
            this.lblLotCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotCount.Location = new System.Drawing.Point(291, 17);
            this.lblLotCount.Name = "lblLotCount";
            this.lblLotCount.Size = new System.Drawing.Size(62, 13);
            this.lblLotCount.TabIndex = 2;
            this.lblLotCount.Text = "Lot Count";
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(20, 17);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(78, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID Prefix";
            // 
            // grpCreated
            // 
            this.grpCreated.Controls.Add(this.lisLotList);
            this.grpCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreated.Location = new System.Drawing.Point(0, 154);
            this.grpCreated.Name = "grpCreated";
            this.grpCreated.Size = new System.Drawing.Size(734, 348);
            this.grpCreated.TabIndex = 2;
            this.grpCreated.TabStop = false;
            this.grpCreated.Text = "Created Lot List";
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colThread,
            this.colSeq,
            this.colLotID,
            this.colOper,
            this.colElapsed,
            this.colStart,
            this.colEnd,
            this.colSplit,
            this.colMerge,
            this.colEDC});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.Location = new System.Drawing.Point(3, 16);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(728, 329);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            this.lisLotList.Click += new System.EventHandler(this.lisLotList_Click);
            this.lisLotList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lisLotList_KeyDown);
            // 
            // colThread
            // 
            this.colThread.Text = "Thread";
            this.colThread.Width = 50;
            // 
            // colSeq
            // 
            this.colSeq.Text = "Sequence";
            this.colSeq.Width = 63;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 212;
            // 
            // colOper
            // 
            this.colOper.Text = "Operation";
            // 
            // colElapsed
            // 
            this.colElapsed.Text = "Elapsed Time(sec)";
            this.colElapsed.Width = 100;
            // 
            // colStart
            // 
            this.colStart.Text = "Start Time";
            this.colStart.Width = 70;
            // 
            // colEnd
            // 
            this.colEnd.Text = "End Time";
            this.colEnd.Width = 70;
            // 
            // colSplit
            // 
            this.colSplit.Text = "Split Time";
            this.colSplit.Width = 70;
            // 
            // colMerge
            // 
            this.colMerge.Text = "Merge Time";
            this.colMerge.Width = 70;
            // 
            // colEDC
            // 
            this.colEDC.Text = "EDC Time";
            this.colEDC.Width = 70;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcelExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelExport.Image")));
            this.btnExcelExport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcelExport.Location = new System.Drawing.Point(12, 7);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(21, 26);
            this.btnExcelExport.TabIndex = 3;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(409, 7);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(88, 26);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnEvent
            // 
            this.btnEvent.Location = new System.Drawing.Point(221, 7);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(88, 26);
            this.btnEvent.TabIndex = 5;
            this.btnEvent.Text = "Res Event";
            this.btnEvent.UseVisualStyleBackColor = true;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // udcResID
            // 
            this.udcResID.AddEmptyRowToLast = false;
            this.udcResID.AddEmptyRowToTop = false;
            this.udcResID.ButtonWidth = 21;
            this.udcResID.DisplaySubItemIndex = 0;
            this.udcResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcResID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcResID.LabelText = "Resource";
            this.udcResID.LabelWidth = 60;
            this.udcResID.ListCond_ExtFactory = "";
            this.udcResID.ListCond_IncludeDeleteResource = false;
            this.udcResID.ListCond_Step = '1';
            this.udcResID.Location = new System.Drawing.Point(39, 10);
            this.udcResID.Name = "udcResID";
            this.udcResID.ReadOnly = false;
            this.udcResID.SearchSubItemIndex = 0;
            this.udcResID.SelectedDescIndex = 1;
            this.udcResID.SelectedSubItemIndex = 0;
            this.udcResID.Size = new System.Drawing.Size(176, 20);
            this.udcResID.TabIndex = 4;
            this.udcResID.TextBoxWidth = 116;
            this.udcResID.VisibleButton = true;
            this.udcResID.VisibleColumnHeader = false;
            this.udcResID.VisibleDescription = false;
            // 
            // grpTestThread
            // 
            this.grpTestThread.Controls.Add(this.prgRunning);
            this.grpTestThread.Controls.Add(this.txtTotalLotCount);
            this.grpTestThread.Controls.Add(this.label1);
            this.grpTestThread.Controls.Add(this.txtThreadCount);
            this.grpTestThread.Controls.Add(this.lblThreadCount);
            this.grpTestThread.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTestThread.Location = new System.Drawing.Point(0, 0);
            this.grpTestThread.Name = "grpTestThread";
            this.grpTestThread.Size = new System.Drawing.Size(734, 38);
            this.grpTestThread.TabIndex = 0;
            this.grpTestThread.TabStop = false;
            this.grpTestThread.Text = "Test Thread Information";
            // 
            // txtTotalLotCount
            // 
            this.txtTotalLotCount.Location = new System.Drawing.Point(377, 12);
            this.txtTotalLotCount.Name = "txtTotalLotCount";
            this.txtTotalLotCount.ReadOnly = true;
            this.txtTotalLotCount.Size = new System.Drawing.Size(148, 20);
            this.txtTotalLotCount.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Lot Count";
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(130, 12);
            this.txtThreadCount.MaxLength = 5;
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(60, 20);
            this.txtThreadCount.TabIndex = 1;
            this.txtThreadCount.Text = "1";
            // 
            // lblThreadCount
            // 
            this.lblThreadCount.AutoSize = true;
            this.lblThreadCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreadCount.Location = new System.Drawing.Point(20, 16);
            this.lblThreadCount.Name = "lblThreadCount";
            this.lblThreadCount.Size = new System.Drawing.Size(84, 13);
            this.lblThreadCount.TabIndex = 0;
            this.lblThreadCount.Text = "Thread Count";
            // 
            // prgRunning
            // 
            this.prgRunning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgRunning.Enabled = false;
            this.prgRunning.Location = new System.Drawing.Point(535, 11);
            this.prgRunning.Name = "prgRunning";
            this.prgRunning.Size = new System.Drawing.Size(187, 22);
            this.prgRunning.Step = 20;
            this.prgRunning.TabIndex = 11;
            this.prgRunning.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmUTLPerformanceTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 542);
            this.MinimumSize = new System.Drawing.Size(750, 300);
            this.Name = "frmUTLPerformanceTest";
            this.Text = "Performance Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUTLPerformanceTest_FormClosed);
            this.Load += new System.EventHandler(this.frmUTLPerformanceTest_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpCreation.ResumeLayout(false);
            this.grpCreation.PerformLayout();
            this.grpCreated.ResumeLayout(false);
            this.grpTestThread.ResumeLayout(false);
            this.grpTestThread.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCreated;
        private System.Windows.Forms.ListView lisLotList;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colOper;
        private System.Windows.Forms.ColumnHeader colElapsed;
        private System.Windows.Forms.GroupBox grpCreation;
        private System.Windows.Forms.TextBox txtLotCount;
        private System.Windows.Forms.Label lblLotCount;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Button btnStop;
        protected System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.TextBox txtLotQty;
        private System.Windows.Forms.Label lblLotQty;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.TextBox txtElapsedTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.ProgressBar prgTotal;
        private System.Windows.Forms.Label lblProgress2;
        private System.Windows.Forms.Label lblPrgTotal;
        private System.Windows.Forms.TextBox txtAvgTime;
        private System.Windows.Forms.TextBox txtMaxTime;
        private System.Windows.Forms.Label lblMinTime;
        private System.Windows.Forms.TextBox txtMinTime;
        private System.Windows.Forms.TextBox txtServiceCount;
        private System.Windows.Forms.ComboBox cboLotID;
        private System.Windows.Forms.TextBox txtNowTime;
        private System.Windows.Forms.ColumnHeader colEnd;
        private System.Windows.Forms.ColumnHeader colSplit;
        private System.Windows.Forms.ColumnHeader colMerge;
        private System.Windows.Forms.ColumnHeader colEDC;
        private System.Windows.Forms.ColumnHeader colStart;
        private System.Windows.Forms.Button btnEvent;
        private MESCore.Controls.udcResource udcResID;
        private System.Windows.Forms.CheckBox chkRandomQty;
        private System.Windows.Forms.CheckBox chkIgnoreError;
        private System.Windows.Forms.GroupBox grpTestThread;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.Label lblThreadCount;
        private System.Windows.Forms.ColumnHeader colThread;
        private System.Windows.Forms.TextBox txtTotalLotCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar prgRunning;
        private System.Windows.Forms.Timer timer1;
    }
}