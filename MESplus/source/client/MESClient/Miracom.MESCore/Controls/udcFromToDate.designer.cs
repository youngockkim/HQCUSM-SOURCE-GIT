namespace Miracom.MESCore.Controls
{
    partial class udcFromToDate
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
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.pnlCondition = new System.Windows.Forms.Panel();
            this.lblCondition = new System.Windows.Forms.Label();
            this.lblPlus = new System.Windows.Forms.Label();
            this.pnlFromToDate.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFromToDate
            // 
            this.pnlFromToDate.BackColor = System.Drawing.Color.Transparent;
            this.pnlFromToDate.Controls.Add(this.cboConditionType);
            this.pnlFromToDate.Controls.Add(this.dtpToDate);
            this.pnlFromToDate.Controls.Add(this.dtpFromDate);
            this.pnlFromToDate.Controls.Add(this.lblTo);
            this.pnlFromToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFromToDate.Location = new System.Drawing.Point(80, 0);
            this.pnlFromToDate.Name = "pnlFromToDate";
            this.pnlFromToDate.Size = new System.Drawing.Size(302, 22);
            this.pnlFromToDate.TabIndex = 2;
            // 
            // cboConditionType
            // 
            this.cboConditionType.AccessibleDescription = "FromToDate";
            this.cboConditionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConditionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboConditionType.FormattingEnabled = true;
            this.cboConditionType.Location = new System.Drawing.Point(205, 0);
            this.cboConditionType.Name = "cboConditionType";
            this.cboConditionType.Size = new System.Drawing.Size(94, 21);
            this.cboConditionType.TabIndex = 5;
            this.cboConditionType.SelectedIndexChanged += new System.EventHandler(this.cboConditionType_SelectedIndexChanged);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(110, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(92, 20);
            this.dtpToDate.TabIndex = 4;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(2, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(92, 20);
            this.dtpFromDate.TabIndex = 3;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // lblTo
            // 
            this.lblTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(94, 4);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(17, 15);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCondition
            // 
            this.pnlCondition.BackColor = System.Drawing.Color.Transparent;
            this.pnlCondition.Controls.Add(this.lblCondition);
            this.pnlCondition.Controls.Add(this.lblPlus);
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCondition.Font = new System.Drawing.Font("Verdana", 8F);
            this.pnlCondition.Location = new System.Drawing.Point(0, 0);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(80, 22);
            this.pnlCondition.TabIndex = 4;
            // 
            // lblCondition
            // 
            this.lblCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCondition.ForeColor = System.Drawing.Color.Black;
            this.lblCondition.Location = new System.Drawing.Point(0, 3);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(60, 14);
            this.lblCondition.TabIndex = 12;
            this.lblCondition.Text = "Period";
            this.lblCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlus
            // 
            this.lblPlus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus.Location = new System.Drawing.Point(0, 5);
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.Size = new System.Drawing.Size(10, 16);
            this.lblPlus.TabIndex = 13;
            this.lblPlus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcFromToDate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlFromToDate);
            this.Controls.Add(this.pnlCondition);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "udcFromToDate";
            this.Size = new System.Drawing.Size(382, 22);
            this.FontChanged += new System.EventHandler(this.udcFromToDate_FontChanged);
            this.pnlFromToDate.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private WinUI.UcDoubleBuffer.UcDoubleBufferPanel pnlFromToDate;
        //private WinUI.UcDoubleBuffer.UcDoubleBufferPanel pnlCondition;
        public System.Windows.Forms.ComboBox cboConditionType;
        public System.Windows.Forms.DateTimePicker dtpToDate;
        public System.Windows.Forms.DateTimePicker dtpFromDate;
        public System.Windows.Forms.Panel pnlFromToDate;
        public System.Windows.Forms.Label lblTo;
        public System.Windows.Forms.Panel pnlCondition;
        public System.Windows.Forms.Label lblPlus;
        public System.Windows.Forms.Label lblCondition;
    }
}
