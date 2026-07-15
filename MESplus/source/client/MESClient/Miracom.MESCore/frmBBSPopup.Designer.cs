namespace Miracom.MESCore
{
    partial class frmBBSPopup
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.grpAttachFile = new System.Windows.Forms.GroupBox();
            this.lisFile = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panTop = new System.Windows.Forms.Panel();
            this.lisMsgList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResourceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResourceGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubarea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSecGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrivilegeGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApplyTimeFromTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShift = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPopupCycle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRcvFactory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAckFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMainMenu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubMenu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSysMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panMid = new System.Windows.Forms.Panel();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.tmrAutoClose = new System.Windows.Forms.Timer(this.components);
            this.spl1 = new System.Windows.Forms.Splitter();
            this.pnlBottom.SuspendLayout();
            this.grpAttachFile.SuspendLayout();
            this.panTop.SuspendLayout();
            this.panMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.chkAutoRefresh);
            this.pnlBottom.Controls.Add(this.grpAttachFile);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 440);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBottom.Size = new System.Drawing.Size(685, 118);
            this.pnlBottom.TabIndex = 0;
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.Enabled = false;
            this.chkAutoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoRefresh.Location = new System.Drawing.Point(400, 90);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(95, 18);
            this.chkAutoRefresh.TabIndex = 1;
            this.chkAutoRefresh.Text = "Auto Refresh";
            // 
            // grpAttachFile
            // 
            this.grpAttachFile.Controls.Add(this.lisFile);
            this.grpAttachFile.Controls.Add(this.btnSave);
            this.grpAttachFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpAttachFile.Location = new System.Drawing.Point(3, 3);
            this.grpAttachFile.Name = "grpAttachFile";
            this.grpAttachFile.Size = new System.Drawing.Size(391, 112);
            this.grpAttachFile.TabIndex = 0;
            this.grpAttachFile.TabStop = false;
            this.grpAttachFile.Text = "Attach File";
            // 
            // lisFile
            // 
            this.lisFile.AllowColumnReorder = true;
            this.lisFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lisFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisFile.EnableSort = true;
            this.lisFile.EnableSortIcon = true;
            this.lisFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lisFile.FullRowSelect = true;
            this.lisFile.Location = new System.Drawing.Point(3, 16);
            this.lisFile.MultiSelect = false;
            this.lisFile.Name = "lisFile";
            this.lisFile.Size = new System.Drawing.Size(301, 93);
            this.lisFile.TabIndex = 0;
            this.lisFile.UseCompatibleStateImageBehavior = false;
            this.lisFile.View = System.Windows.Forms.View.Details;
            this.lisFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lisFile_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Seq";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Name";
            this.columnHeader2.Width = 500;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Save File Name";
            this.columnHeader3.Width = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(310, 81);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(525, 84);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(604, 84);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.lisMsgList);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Padding = new System.Windows.Forms.Padding(3);
            this.panTop.Size = new System.Drawing.Size(685, 193);
            this.panTop.TabIndex = 0;
            // 
            // lisMsgList
            // 
            this.lisMsgList.AllowColumnReorder = true;
            this.lisMsgList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColSeq,
            this.colTitle,
            this.colUpdateUser,
            this.colUpdateTime,
            this.colType,
            this.colResourceID,
            this.colResourceGroup,
            this.colArea,
            this.colSubarea,
            this.colUserID,
            this.colSecGroup,
            this.colPrivilegeGroup,
            this.colMaterial,
            this.colFlow,
            this.colOperation,
            this.colLotID,
            this.colApplyTimeFromTo,
            this.colShift,
            this.colPopupCycle,
            this.colRcvFactory,
            this.colAckFlag,
            this.colMainMenu,
            this.colSubMenu,
            this.colSysMsg});
            this.lisMsgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMsgList.EnableSort = true;
            this.lisMsgList.EnableSortIcon = true;
            this.lisMsgList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lisMsgList.FullRowSelect = true;
            this.lisMsgList.Location = new System.Drawing.Point(3, 3);
            this.lisMsgList.MultiSelect = false;
            this.lisMsgList.Name = "lisMsgList";
            this.lisMsgList.Size = new System.Drawing.Size(679, 187);
            this.lisMsgList.TabIndex = 1;
            this.lisMsgList.UseCompatibleStateImageBehavior = false;
            this.lisMsgList.View = System.Windows.Forms.View.Details;
            this.lisMsgList.SelectedIndexChanged += new System.EventHandler(this.lisMsgList_SelectedIndexChanged);
            // 
            // ColSeq
            // 
            this.ColSeq.Text = "Seq";
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 400;
            // 
            // colUpdateUser
            // 
            this.colUpdateUser.Text = "Update User";
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.Text = "Update Time";
            // 
            // colType
            // 
            this.colType.Text = "Type";
            // 
            // colResourceID
            // 
            this.colResourceID.Text = "Resource ID";
            this.colResourceID.Width = 80;
            // 
            // colResourceGroup
            // 
            this.colResourceGroup.Text = "Resource Group";
            // 
            // colArea
            // 
            this.colArea.Text = "Area";
            // 
            // colSubarea
            // 
            this.colSubarea.Text = "Subarea";
            // 
            // colUserID
            // 
            this.colUserID.Text = "User ID";
            this.colUserID.Width = 80;
            // 
            // colSecGroup
            // 
            this.colSecGroup.Text = "Sec Group";
            // 
            // colPrivilegeGroup
            // 
            this.colPrivilegeGroup.Text = "Privilege Group";
            // 
            // colMaterial
            // 
            this.colMaterial.Text = "Material";
            // 
            // colFlow
            // 
            this.colFlow.Text = "Flow";
            // 
            // colOperation
            // 
            this.colOperation.Text = "Operation";
            this.colOperation.Width = 80;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            // 
            // colApplyTimeFromTo
            // 
            this.colApplyTimeFromTo.Text = "Apply Time From - To";
            // 
            // colShift
            // 
            this.colShift.Text = "Shift";
            // 
            // colPopupCycle
            // 
            this.colPopupCycle.Text = "Popup Cycle";
            // 
            // colRcvFactory
            // 
            this.colRcvFactory.Text = "Receive Factory";
            this.colRcvFactory.Width = 0;
            // 
            // colAckFlag
            // 
            this.colAckFlag.Text = "Req. Ack";
            // 
            // colMainMenu
            // 
            this.colMainMenu.Text = "Main Menu";
            // 
            // colSubMenu
            // 
            this.colSubMenu.Text = "Sub Menu";
            // 
            // colSysMsg
            // 
            this.colSysMsg.Text = "Sys. Msg.";
            // 
            // panMid
            // 
            this.panMid.Controls.Add(this.txtMsg);
            this.panMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMid.Location = new System.Drawing.Point(0, 196);
            this.panMid.Name = "panMid";
            this.panMid.Size = new System.Drawing.Size(685, 244);
            this.panMid.TabIndex = 6;
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.SystemColors.Window;
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(0, 0);
            this.txtMsg.MaxLength = 65000;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(685, 244);
            this.txtMsg.TabIndex = 0;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 60000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // tmrAutoClose
            // 
            this.tmrAutoClose.Interval = 1000;
            this.tmrAutoClose.Tick += new System.EventHandler(this.tmrAutoClose_Tick);
            // 
            // spl1
            // 
            this.spl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.spl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.spl1.Location = new System.Drawing.Point(0, 193);
            this.spl1.Name = "spl1";
            this.spl1.Size = new System.Drawing.Size(685, 3);
            this.spl1.TabIndex = 7;
            this.spl1.TabStop = false;
            // 
            // frmBBSPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 558);
            this.Controls.Add(this.panMid);
            this.Controls.Add(this.spl1);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmBBSPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popup Message";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frmBBSPopup_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBBSPopup_FormClosed);
            this.Load += new System.EventHandler(this.frmBBSPopup_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmBBSPopup_KeyUp);
            this.pnlBottom.ResumeLayout(false);
            this.grpAttachFile.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.panMid.ResumeLayout(false);
            this.panMid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Panel panMid;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.GroupBox grpAttachFile;
        private UI.Controls.MCListView.MCListView lisFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.Timer tmrAutoClose;
        private System.Windows.Forms.Splitter spl1;
        private UI.Controls.MCListView.MCListView lisMsgList;
        private System.Windows.Forms.ColumnHeader ColSeq;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colUpdateUser;
        private System.Windows.Forms.ColumnHeader colUpdateTime;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colResourceID;
        private System.Windows.Forms.ColumnHeader colResourceGroup;
        private System.Windows.Forms.ColumnHeader colArea;
        private System.Windows.Forms.ColumnHeader colSubarea;
        private System.Windows.Forms.ColumnHeader colUserID;
        private System.Windows.Forms.ColumnHeader colSecGroup;
        private System.Windows.Forms.ColumnHeader colPrivilegeGroup;
        private System.Windows.Forms.ColumnHeader colMaterial;
        private System.Windows.Forms.ColumnHeader colFlow;
        private System.Windows.Forms.ColumnHeader colOperation;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colApplyTimeFromTo;
        private System.Windows.Forms.ColumnHeader colShift;
        private System.Windows.Forms.ColumnHeader colPopupCycle;
        private System.Windows.Forms.ColumnHeader colRcvFactory;
        private System.Windows.Forms.ColumnHeader colAckFlag;
        private System.Windows.Forms.ColumnHeader colMainMenu;
        private System.Windows.Forms.ColumnHeader colSubMenu;
        private System.Windows.Forms.ColumnHeader colSysMsg;
    }
}