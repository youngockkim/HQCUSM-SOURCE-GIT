namespace Miracom.RTDCore
{
    partial class frmRTDViewDispatchedResourceList
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
            this.txtLot = new System.Windows.Forms.TextBox();
            this.lblLot = new System.Windows.Forms.Label();
            this.lisResourceList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriSts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEventTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResScoreText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnselected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResDspReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.chkUnselect = new System.Windows.Forms.CheckBox();
            this.chkUncapable = new System.Windows.Forms.CheckBox();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 40);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkUncapable);
            this.grpOption.Controls.Add(this.chkUnselect);
            this.grpOption.Controls.Add(this.txtLot);
            this.grpOption.Controls.Add(this.lblLot);
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Size = new System.Drawing.Size(736, 40);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.lisResourceList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 40);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 473);
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
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(120, 15);
            this.txtLot.MaxLength = 25;
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(200, 20);
            this.txtLot.TabIndex = 1;
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.Location = new System.Drawing.Point(15, 19);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(36, 13);
            this.lblLot.TabIndex = 0;
            this.lblLot.Text = "Lot ID";
            // 
            // lisResourceList
            // 
            this.lisResourceList.AllowColumnReorder = true;
            this.lisResourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRes,
            this.colDesc,
            this.colType,
            this.colUpDown,
            this.colPriSts,
            this.colArea,
            this.colSubArea,
            this.colLastEvent,
            this.colLastEventTime,
            this.colLastStartTime,
            this.colLastEndTime,
            this.colResScoreText,
            this.colUnselected,
            this.colCapable,
            this.colResRule,
            this.colResDspReason,
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
            this.colCmf10});
            this.lisResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResourceList.EnableSort = true;
            this.lisResourceList.EnableSortIcon = true;
            this.lisResourceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResourceList.FullRowSelect = true;
            this.lisResourceList.Location = new System.Drawing.Point(3, 3);
            this.lisResourceList.Name = "lisResourceList";
            this.lisResourceList.Size = new System.Drawing.Size(736, 470);
            this.lisResourceList.TabIndex = 0;
            this.lisResourceList.UseCompatibleStateImageBehavior = false;
            this.lisResourceList.View = System.Windows.Forms.View.Details;
            // 
            // colRes
            // 
            this.colRes.Text = "Resource ID";
            this.colRes.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Res Desc";
            this.colDesc.Width = 130;
            // 
            // colType
            // 
            this.colType.Text = "Res Type";
            this.colType.Width = 90;
            // 
            // colUpDown
            // 
            this.colUpDown.Text = "Up/Down";
            this.colUpDown.Width = 70;
            // 
            // colPriSts
            // 
            this.colPriSts.Text = "Primary Status";
            this.colPriSts.Width = 120;
            // 
            // colArea
            // 
            this.colArea.Text = "Area ID";
            this.colArea.Width = 120;
            // 
            // colSubArea
            // 
            this.colSubArea.Text = "Sub Area ID";
            this.colSubArea.Width = 120;
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
            // colResScoreText
            // 
            this.colResScoreText.Text = "Score Text";
            this.colResScoreText.Width = 150;
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
            // colResRule
            // 
            this.colResRule.Text = "Rule ID";
            this.colResRule.Width = 80;
            // 
            // colResDspReason
            // 
            this.colResDspReason.Text = "Dispatch Reason";
            this.colResDspReason.Width = 100;
            // 
            // colUnselectReason
            // 
            this.colUnselectReason.Text = "Unselected Reason";
            // 
            // colCapableReason
            // 
            this.colCapableReason.Text = "Capable Reason";
            // 
            // colCmf1
            // 
            this.colCmf1.Text = "Pds Cmf 1";
            // 
            // colCmf2
            // 
            this.colCmf2.Text = "Pds Cmf 2";
            // 
            // colCmf3
            // 
            this.colCmf3.Text = "Pds Cmf 3";
            // 
            // colCmf4
            // 
            this.colCmf4.Text = "Pds Cmf 4";
            // 
            // colCmf5
            // 
            this.colCmf5.Text = "Pds Cmf 5";
            // 
            // colCmf6
            // 
            this.colCmf6.Text = "Pds Cmf 6";
            // 
            // colCmf7
            // 
            this.colCmf7.Text = "Pds Cmf 7";
            // 
            // colCmf8
            // 
            this.colCmf8.Text = "Pds Cmf 8";
            // 
            // colCmf9
            // 
            this.colCmf9.Text = "Pds Cmf 9";
            // 
            // colCmf10
            // 
            this.colCmf10.Text = "Pds Cmf 10";
            // 
            // chkUnselect
            // 
            this.chkUnselect.AutoSize = true;
            this.chkUnselect.Location = new System.Drawing.Point(384, 17);
            this.chkUnselect.Name = "chkUnselect";
            this.chkUnselect.Size = new System.Drawing.Size(167, 17);
            this.chkUnselect.TabIndex = 2;
            this.chkUnselect.Text = "Include Unselected Resource";
            // 
            // chkUncapable
            // 
            this.chkUncapable.AutoSize = true;
            this.chkUncapable.Location = new System.Drawing.Point(566, 17);
            this.chkUncapable.Name = "chkUncapable";
            this.chkUncapable.Size = new System.Drawing.Size(165, 17);
            this.chkUncapable.TabIndex = 3;
            this.chkUncapable.Text = "Include Uncapable Resource";
            // 
            // frmRTDViewDispatchedResourceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRTDViewDispatchedResourceList";
            this.Text = "View Dispatched Resource List";
            this.Load += new System.EventHandler(this.frmRTDViewDispatchedResourceList_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.Label lblLot;
        private Miracom.UI.Controls.MCListView.MCListView lisResourceList;
        private System.Windows.Forms.ColumnHeader colRes;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colUpDown;
        private System.Windows.Forms.ColumnHeader colPriSts;
        private System.Windows.Forms.ColumnHeader colArea;
        private System.Windows.Forms.ColumnHeader colSubArea;
        private System.Windows.Forms.ColumnHeader colLastEvent;
        private System.Windows.Forms.ColumnHeader colLastEventTime;
        private System.Windows.Forms.ColumnHeader colLastStartTime;
        private System.Windows.Forms.ColumnHeader colLastEndTime;
        private System.Windows.Forms.ColumnHeader colResScoreText;
        private System.Windows.Forms.ColumnHeader colUnselected;
        private System.Windows.Forms.ColumnHeader colResRule;
        private System.Windows.Forms.ColumnHeader colResDspReason;
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
        private System.Windows.Forms.ColumnHeader colUnselectReason;
        private System.Windows.Forms.ColumnHeader colCapableReason;
    }
}
