namespace Miracom.RTDCore
{
    partial class frmRTDTranAdjustPriority
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRTDTranAdjustPriority));
            this.grpOper = new System.Windows.Forms.GroupBox();
            this.rbnResource = new System.Windows.Forms.RadioButton();
            this.cdvResource = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rbnOper = new System.Windows.Forms.RadioButton();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lisDispatcher = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSetOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSetResGrp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSetRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDspID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRuleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBatchId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTempBatchSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRefOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnselect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResvLot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRsvTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriAdjust = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdjustReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTrigger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDspReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnselectReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapableReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlUpDown = new System.Windows.Forms.Panel();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUncapable = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            this.pnlUpDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(368, 6);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Unselect";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 9;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnUncapable);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUncapable, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.lisDispatcher);
            this.pnlCenter.Controls.Add(this.pnlUpDown);
            this.pnlCenter.Controls.Add(this.grpOper);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // grpOper
            // 
            this.grpOper.Controls.Add(this.rbnResource);
            this.grpOper.Controls.Add(this.cdvResource);
            this.grpOper.Controls.Add(this.rbnOper);
            this.grpOper.Controls.Add(this.cdvOper);
            this.grpOper.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOper.Location = new System.Drawing.Point(0, 0);
            this.grpOper.Name = "grpOper";
            this.grpOper.Size = new System.Drawing.Size(742, 70);
            this.grpOper.TabIndex = 5;
            this.grpOper.TabStop = false;
            // 
            // rbnResource
            // 
            this.rbnResource.AutoSize = true;
            this.rbnResource.Location = new System.Drawing.Point(27, 32);
            this.rbnResource.Name = "rbnResource";
            this.rbnResource.Size = new System.Drawing.Size(71, 17);
            this.rbnResource.TabIndex = 0;
            this.rbnResource.TabStop = true;
            this.rbnResource.Text = "Resource";
            this.rbnResource.CheckedChanged += new System.EventHandler(this.rbnResource_CheckedChanged);
            // 
            // cdvResource
            // 
            this.cdvResource.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResource.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResource.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResource.BtnToolTipText = "";
            this.cdvResource.DescText = "";
            this.cdvResource.DisplaySubItemIndex = -1;
            this.cdvResource.DisplayText = "";
            this.cdvResource.Focusing = null;
            this.cdvResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResource.Index = 0;
            this.cdvResource.IsViewBtnImage = false;
            this.cdvResource.Location = new System.Drawing.Point(126, 30);
            this.cdvResource.MaxLength = 20;
            this.cdvResource.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResource.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResource.Name = "cdvResource";
            this.cdvResource.ReadOnly = false;
            this.cdvResource.SearchSubItemIndex = 0;
            this.cdvResource.SelectedDescIndex = -1;
            this.cdvResource.SelectedSubItemIndex = -1;
            this.cdvResource.SelectionStart = 0;
            this.cdvResource.Size = new System.Drawing.Size(200, 20);
            this.cdvResource.SmallImageList = null;
            this.cdvResource.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResource.TabIndex = 1;
            this.cdvResource.TextBoxToolTipText = "";
            this.cdvResource.TextBoxWidth = 200;
            this.cdvResource.VisibleButton = true;
            this.cdvResource.VisibleColumnHeader = false;
            this.cdvResource.VisibleDescription = false;
            this.cdvResource.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResource_SelectedItemChanged);
            this.cdvResource.ButtonPress += new System.EventHandler(this.cdvResource_ButtonPress);
            this.cdvResource.TextBoxTextChanged += new System.EventHandler(this.cdvResource_TextBoxTextChanged);
            // 
            // rbnOper
            // 
            this.rbnOper.AutoSize = true;
            this.rbnOper.Location = new System.Drawing.Point(416, 32);
            this.rbnOper.Name = "rbnOper";
            this.rbnOper.Size = new System.Drawing.Size(71, 17);
            this.rbnOper.TabIndex = 2;
            this.rbnOper.TabStop = true;
            this.rbnOper.Text = "Operation";
            this.rbnOper.CheckedChanged += new System.EventHandler(this.rbnResource_CheckedChanged);
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(515, 30);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 3;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxTextChanged += new System.EventHandler(this.cdvOper_TextBoxTextChanged);
            // 
            // lisDispatcher
            // 
            this.lisDispatcher.AllowDrop = true;
            this.lisDispatcher.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colLot,
            this.colSetOper,
            this.colSetResGrp,
            this.colSetRes,
            this.colDspID,
            this.colRuleID,
            this.colBatchId,
            this.colTempBatchSeq,
            this.colCurOper,
            this.colRefOper,
            this.colUnselect,
            this.colResvLot,
            this.colRsvTime,
            this.colCapable,
            this.colPriAdjust,
            this.colPriority,
            this.colHistSeq,
            this.colAdjustReason,
            this.colTrigger,
            this.colDspReason,
            this.colUnselectReason,
            this.colCapableReason,
            this.colCmf1,
            this.colCmf2,
            this.colCmf3,
            this.colCmf4,
            this.colCmf5,
            this.colCmf6,
            this.colCmf7,
            this.colCmf8,
            this.colCmf9,
            this.colCmf10,
            this.colUser});
            this.lisDispatcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisDispatcher.EnableSort = true;
            this.lisDispatcher.EnableSortIcon = true;
            this.lisDispatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisDispatcher.FullRowSelect = true;
            this.lisDispatcher.HideSelection = false;
            this.lisDispatcher.Location = new System.Drawing.Point(0, 70);
            this.lisDispatcher.MultiSelect = false;
            this.lisDispatcher.Name = "lisDispatcher";
            this.lisDispatcher.Size = new System.Drawing.Size(700, 443);
            this.lisDispatcher.TabIndex = 0;
            this.lisDispatcher.UseCompatibleStateImageBehavior = false;
            this.lisDispatcher.View = System.Windows.Forms.View.Details;
            this.lisDispatcher.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisDispatcher_ItemDrag);
            this.lisDispatcher.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisDispatcher_DragDrop);
            this.lisDispatcher.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisDispatcher_DragEnter);
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSeq.Width = 50;
            // 
            // colLot
            // 
            this.colLot.Text = "Lot ID";
            this.colLot.Width = 100;
            // 
            // colSetOper
            // 
            this.colSetOper.Text = "Set Oper";
            this.colSetOper.Width = 70;
            // 
            // colSetResGrp
            // 
            this.colSetResGrp.Text = "Set Resource Group";
            this.colSetResGrp.Width = 120;
            // 
            // colSetRes
            // 
            this.colSetRes.Text = "Set Resource";
            this.colSetRes.Width = 80;
            // 
            // colDspID
            // 
            this.colDspID.Text = "Dispatcher";
            this.colDspID.Width = 80;
            // 
            // colRuleID
            // 
            this.colRuleID.Text = "Rule ID";
            this.colRuleID.Width = 80;
            // 
            // colBatchId
            // 
            this.colBatchId.Text = "Temp Batch ID";
            this.colBatchId.Width = 100;
            // 
            // colTempBatchSeq
            // 
            this.colTempBatchSeq.Text = "Temp Batch Seq.";
            // 
            // colCurOper
            // 
            this.colCurOper.Text = "Current Oper";
            this.colCurOper.Width = 80;
            // 
            // colRefOper
            // 
            this.colRefOper.Text = "Refer Oper";
            this.colRefOper.Width = 80;
            // 
            // colUnselect
            // 
            this.colUnselect.Text = "Unselected Flag";
            this.colUnselect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colUnselect.Width = 80;
            // 
            // colResvLot
            // 
            this.colResvLot.Text = "Reserve Flag";
            this.colResvLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colResvLot.Width = 80;
            // 
            // colRsvTime
            // 
            this.colRsvTime.Text = "Reserve Time";
            this.colRsvTime.Width = 80;
            // 
            // colCapable
            // 
            this.colCapable.Text = "Capable Flag";
            this.colCapable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCapable.Width = 80;
            // 
            // colPriAdjust
            // 
            this.colPriAdjust.Text = "Priority Adjust Flag";
            this.colPriAdjust.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colPriAdjust.Width = 80;
            // 
            // colPriority
            // 
            this.colPriority.Text = "Priority Score";
            this.colPriority.Width = 90;
            // 
            // colHistSeq
            // 
            this.colHistSeq.Text = "Hist Seq";
            this.colHistSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colAdjustReason
            // 
            this.colAdjustReason.Text = "Adjust Reason";
            this.colAdjustReason.Width = 100;
            // 
            // colTrigger
            // 
            this.colTrigger.Text = "Trigger by";
            this.colTrigger.Width = 80;
            // 
            // colDspReason
            // 
            this.colDspReason.Text = "Dsp Reason";
            this.colDspReason.Width = 100;
            // 
            // colUnselectReason
            // 
            this.colUnselectReason.Text = "Unselect Reason";
            // 
            // colCapableReason
            // 
            this.colCapableReason.Text = "Capable Reason";
            // 
            // colCmf1
            // 
            this.colCmf1.Text = "Pds Cmf1";
            // 
            // colCmf2
            // 
            this.colCmf2.Text = "Pds Cmf2";
            // 
            // colCmf3
            // 
            this.colCmf3.Text = "Pds Cmf3";
            // 
            // colCmf4
            // 
            this.colCmf4.Text = "Pds Cmf4";
            // 
            // colCmf5
            // 
            this.colCmf5.Text = "Pds Cmf5";
            // 
            // colCmf6
            // 
            this.colCmf6.Text = "Pds Cmf6";
            // 
            // colCmf7
            // 
            this.colCmf7.Text = "Pds Cmf7";
            // 
            // colCmf8
            // 
            this.colCmf8.Text = "Pds Cmf8";
            // 
            // colCmf9
            // 
            this.colCmf9.Text = "Pds Cmf9";
            // 
            // colCmf10
            // 
            this.colCmf10.Text = "Pds Cmf10";
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            this.colUser.Width = 80;
            // 
            // pnlUpDown
            // 
            this.pnlUpDown.Controls.Add(this.txtCount);
            this.pnlUpDown.Controls.Add(this.btnDown);
            this.pnlUpDown.Controls.Add(this.btnUp);
            this.pnlUpDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUpDown.Location = new System.Drawing.Point(700, 70);
            this.pnlUpDown.Name = "pnlUpDown";
            this.pnlUpDown.Size = new System.Drawing.Size(42, 443);
            this.pnlUpDown.TabIndex = 7;
            // 
            // txtCount
            // 
            this.txtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.Location = new System.Drawing.Point(6, 206);
            this.txtCount.MaxLength = 6;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(31, 20);
            this.txtCount.TabIndex = 2;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(9, 234);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 3;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(9, 174);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 1;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(274, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(556, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 26);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUncapable
            // 
            this.btnUncapable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUncapable.Location = new System.Drawing.Point(462, 6);
            this.btnUncapable.Name = "btnUncapable";
            this.btnUncapable.Size = new System.Drawing.Size(88, 26);
            this.btnUncapable.TabIndex = 7;
            this.btnUncapable.Text = "Uncapable";
            this.btnUncapable.Click += new System.EventHandler(this.btnUncapable_Click);
            // 
            // frmRTDTranAdjustPriority
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRTDTranAdjustPriority";
            this.Text = "Adjust Lot Priority";
            this.Load += new System.EventHandler(this.frmRTDTranAdjustPriority_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpOper.ResumeLayout(false);
            this.grpOper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            this.pnlUpDown.ResumeLayout(false);
            this.pnlUpDown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private System.Windows.Forms.RadioButton rbnOper;
        private System.Windows.Forms.RadioButton rbnResource;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResource;
        private Miracom.UI.Controls.MCListView.MCListView lisDispatcher;
        private System.Windows.Forms.ColumnHeader colLot;
        private System.Windows.Forms.ColumnHeader colSetOper;
        private System.Windows.Forms.Panel pnlUpDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ColumnHeader colSetResGrp;
        private System.Windows.Forms.ColumnHeader colSetRes;
        private System.Windows.Forms.ColumnHeader colDspID;
        private System.Windows.Forms.ColumnHeader colRuleID;
        private System.Windows.Forms.ColumnHeader colBatchId;
        private System.Windows.Forms.ColumnHeader colCurOper;
        private System.Windows.Forms.ColumnHeader colRefOper;
        private System.Windows.Forms.ColumnHeader colUnselect;
        private System.Windows.Forms.ColumnHeader colResvLot;
        private System.Windows.Forms.ColumnHeader colRsvTime;
        private System.Windows.Forms.ColumnHeader colCapable;
        private System.Windows.Forms.ColumnHeader colPriAdjust;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.ColumnHeader colHistSeq;
        private System.Windows.Forms.ColumnHeader colAdjustReason;
        private System.Windows.Forms.ColumnHeader colTrigger;
        private System.Windows.Forms.ColumnHeader colDspReason;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colTempBatchSeq;
        private System.Windows.Forms.ColumnHeader colUnselectReason;
        private System.Windows.Forms.ColumnHeader colCapableReason;
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
        private System.Windows.Forms.Button btnUncapable;
    }
}
