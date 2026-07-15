namespace SOI.OIFrx
{
    partial class udcDateConditionType
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlFromToDate = new System.Windows.Forms.Panel();
            this.cboConditionType = new System.Windows.Forms.ComboBox();
            this.pnlFromToDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFromToDate
            // 
            this.pnlFromToDate.BackColor = System.Drawing.Color.Transparent;
            this.pnlFromToDate.Controls.Add(this.cboConditionType);
            this.pnlFromToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFromToDate.Location = new System.Drawing.Point(0, 0);
            this.pnlFromToDate.Name = "pnlFromToDate";
            this.pnlFromToDate.Size = new System.Drawing.Size(76, 30);
            this.pnlFromToDate.TabIndex = 2;
            // 
            // cboConditionType
            // 
            this.cboConditionType.AccessibleDescription = "FromToDate";
            this.cboConditionType.BackColor = System.Drawing.SystemColors.Window;
            this.cboConditionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConditionType.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.cboConditionType.Location = new System.Drawing.Point(0, 0);
            this.cboConditionType.Name = "cboConditionType";
            this.cboConditionType.Size = new System.Drawing.Size(76, 28);
            this.cboConditionType.TabIndex = 5;
            this.cboConditionType.SelectedIndexChanged += new System.EventHandler(this.cboConditionType_SelectedIndexChanged);
            // 
            // udcDateConditionType
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlFromToDate);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.Name = "udcDateConditionType";
            this.Size = new System.Drawing.Size(76, 30);
            this.FontChanged += new System.EventHandler(this.udcDateConditionType_FontChanged);
            this.pnlFromToDate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private WinUI.UcDoubleBuffer.UcDoubleBufferPanel pnlFromToDate;
        //private WinUI.UcDoubleBuffer.UcDoubleBufferPanel pnlCondition;
        public System.Windows.Forms.ComboBox cboConditionType;
        public System.Windows.Forms.Panel pnlFromToDate;
    }
}
