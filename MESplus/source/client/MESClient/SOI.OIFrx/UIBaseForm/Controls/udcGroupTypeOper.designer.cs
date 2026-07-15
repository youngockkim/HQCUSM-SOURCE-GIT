namespace SOI.OIFrx
{
    partial class udcGroupTypeOper
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
            this.pnlRow1 = new System.Windows.Forms.Panel();
            this.txtDesc1 = new System.Windows.Forms.TextBox();
            this.pnlControl1 = new System.Windows.Forms.Panel();
            this.ctrlOper = new udcOper();
            this.pnlMargin3 = new System.Windows.Forms.Panel();
            this.pnlMargin2 = new System.Windows.Forms.Panel();
            this.ctrlType = new udcGCMCode();
            this.pnlMargin1 = new System.Windows.Forms.Panel();
            this.ctrlGroup = new udcGCMCode();
            this.pnlMarginLabel1 = new System.Windows.Forms.Panel();
            this.pnlLabel1 = new System.Windows.Forms.Panel();
            this.lblLabel1 = new System.Windows.Forms.Label();
            this.pnlRow1.SuspendLayout();
            this.pnlControl1.SuspendLayout();
            this.pnlLabel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRow1
            // 
            this.pnlRow1.Controls.Add(this.txtDesc1);
            this.pnlRow1.Controls.Add(this.pnlControl1);
            this.pnlRow1.Controls.Add(this.pnlMarginLabel1);
            this.pnlRow1.Controls.Add(this.pnlLabel1);
            this.pnlRow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRow1.Location = new System.Drawing.Point(0, 0);
            this.pnlRow1.Name = "pnlRow1";
            this.pnlRow1.Size = new System.Drawing.Size(584, 22);
            this.pnlRow1.TabIndex = 5;
            // 
            // txtDesc1
            // 
            this.txtDesc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc1.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.txtDesc1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDesc1.Location = new System.Drawing.Point(446, 0);
            this.txtDesc1.Name = "txtDesc1";
            this.txtDesc1.ReadOnly = true;
            this.txtDesc1.Size = new System.Drawing.Size(138, 20);
            this.txtDesc1.TabIndex = 2;
            this.txtDesc1.Visible = false;
            // 
            // pnlControl1
            // 
            this.pnlControl1.Controls.Add(this.ctrlOper);
            this.pnlControl1.Controls.Add(this.pnlMargin3);
            this.pnlControl1.Controls.Add(this.pnlMargin2);
            this.pnlControl1.Controls.Add(this.ctrlType);
            this.pnlControl1.Controls.Add(this.pnlMargin1);
            this.pnlControl1.Controls.Add(this.ctrlGroup);
            this.pnlControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControl1.Location = new System.Drawing.Point(125, 0);
            this.pnlControl1.MinimumSize = new System.Drawing.Size(315, 20);
            this.pnlControl1.Name = "pnlControl1";
            this.pnlControl1.Size = new System.Drawing.Size(315, 22);
            this.pnlControl1.TabIndex = 3;
            // 
            // ctrlOper
            // 
            this.ctrlOper.AddEmptyRowToLast = false;
            this.ctrlOper.AddEmptyRowToTop = true;
            this.ctrlOper.ButtonWidth = 20;
            this.ctrlOper.DisplaySubItemIndex = 1;
            this.ctrlOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOper.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlOper.LabelFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlOper.LabelText = "Line";
            this.ctrlOper.LabelWidth = 0;
            this.ctrlOper.ListCond_ExtFactory = "";
            this.ctrlOper.ListCond_Step = '1';
            this.ctrlOper.Location = new System.Drawing.Point(215, 0);
            this.ctrlOper.MaximumSize = new System.Drawing.Size(0, 20);
            this.ctrlOper.MaxLength = 32767;
            this.ctrlOper.MinimumSize = new System.Drawing.Size(100, 20);
            this.ctrlOper.Name = "ctrlOper";
            this.ctrlOper.ReadOnly = false;
            this.ctrlOper.SearchSubItemIndex = 0;
            this.ctrlOper.SelectedDescIndex = 1;
            this.ctrlOper.SelectedSubItemIndex = 0;
            this.ctrlOper.Size = new System.Drawing.Size(100, 20);
            this.ctrlOper.TabIndex = 11;
            this.ctrlOper.TextBoxWidth = 100;
            this.ctrlOper.VisibleButton = true;
            this.ctrlOper.VisibleColumnHeader = false;
            this.ctrlOper.VisibleDescription = false;
            this.ctrlOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.ctrlOper_SelectedItemChanged);
            this.ctrlOper.ButtonPress += new System.EventHandler(this.ctrlOper_ButtonPress);
            this.ctrlOper.ButtonPressAfter += new System.EventHandler(this.ctrlOper_ButtonPressAfter);
            this.ctrlOper.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctrlOper_TextBoxKeyPress);
            this.ctrlOper.TextBoxTextChanged += new System.EventHandler(this.ctrlOper_TextBoxTextChanged);
            this.ctrlOper.TextBoxLostFocus += new System.EventHandler(this.ctrlOper_TextBoxLostFocus);
            this.ctrlOper.TextBoxGotFocus += new System.EventHandler(this.ctrlOper_TextBoxGotFocus);
            // 
            // pnlMargin3
            // 
            this.pnlMargin3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMargin3.Location = new System.Drawing.Point(210, 0);
            this.pnlMargin3.Name = "pnlMargin3";
            this.pnlMargin3.Size = new System.Drawing.Size(5, 22);
            this.pnlMargin3.TabIndex = 10;
            // 
            // pnlMargin2
            // 
            this.pnlMargin2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMargin2.Location = new System.Drawing.Point(205, 0);
            this.pnlMargin2.Name = "pnlMargin2";
            this.pnlMargin2.Size = new System.Drawing.Size(5, 22);
            this.pnlMargin2.TabIndex = 9;
            // 
            // ctrlType
            // 
            this.ctrlType.ButtonWidth = 20;
            this.ctrlType.Custom_AddEmptyRowLast = false;
            this.ctrlType.Custom_AddEmptyRowTop = true;
            this.ctrlType.Custom_Step = '1';
            this.ctrlType.Custom_SubTableName = "";
            this.ctrlType.Custom_TableName = "CINV_WH_TYPE";
            this.ctrlType.Custom_Visible_DATA_1 = false;
            this.ctrlType.Custom_Visible_DATA_10 = false;
            this.ctrlType.Custom_Visible_DATA_2 = false;
            this.ctrlType.Custom_Visible_DATA_3 = false;
            this.ctrlType.Custom_Visible_DATA_4 = false;
            this.ctrlType.Custom_Visible_DATA_5 = false;
            this.ctrlType.Custom_Visible_DATA_6 = false;
            this.ctrlType.Custom_Visible_DATA_7 = false;
            this.ctrlType.Custom_Visible_DATA_8 = false;
            this.ctrlType.Custom_Visible_DATA_9 = false;
            this.ctrlType.Custom_VisibleDataFlag = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
            this.ctrlType.DisplaySubItemIndex = 1;
            this.ctrlType.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlType.ExtFactory = "";
            this.ctrlType.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlType.LabelFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlType.LabelText = "Shop";
            this.ctrlType.LabelWidth = 0;
            this.ctrlType.Location = new System.Drawing.Point(105, 0);
            this.ctrlType.MaximumSize = new System.Drawing.Size(0, 20);
            this.ctrlType.MaxLength = 20;
            this.ctrlType.MinimumSize = new System.Drawing.Size(100, 20);
            this.ctrlType.Name = "ctrlType";
            this.ctrlType.ReadOnly = false;
            this.ctrlType.SearchSubItemIndex = 0;
            this.ctrlType.SelectedDescIndex = 1;
            this.ctrlType.SelectedSubItemIndex = 0;
            this.ctrlType.Size = new System.Drawing.Size(100, 20);
            this.ctrlType.TabIndex = 0;
            this.ctrlType.TextBoxWidth = 100;
            this.ctrlType.VisibleButton = true;
            this.ctrlType.VisibleColumnHeader = false;
            this.ctrlType.VisibleDescription = false;
            this.ctrlType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.ctrlType_SelectedItemChanged);
            this.ctrlType.ButtonPressAfter += new System.EventHandler(this.ctrlType_ButtonPressAfter);
            this.ctrlType.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctrlType_TextBoxKeyPress);
            this.ctrlType.TextBoxTextChanged += new System.EventHandler(this.ctrlType_TextBoxTextChanged);
            this.ctrlType.TextBoxLostFocus += new System.EventHandler(this.ctrlType_TextBoxLostFocus);
            this.ctrlType.TextBoxGotFocus += new System.EventHandler(this.ctrlType_TextBoxGotFocus);
            // 
            // pnlMargin1
            // 
            this.pnlMargin1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMargin1.Location = new System.Drawing.Point(100, 0);
            this.pnlMargin1.Name = "pnlMargin1";
            this.pnlMargin1.Size = new System.Drawing.Size(5, 22);
            this.pnlMargin1.TabIndex = 4;
            // 
            // ctrlGroup
            // 
            this.ctrlGroup.ButtonWidth = 21;
            this.ctrlGroup.Custom_AddEmptyRowLast = false;
            this.ctrlGroup.Custom_AddEmptyRowTop = true;
            this.ctrlGroup.Custom_Step = '1';
            this.ctrlGroup.Custom_SubTableName = "";
            this.ctrlGroup.Custom_TableName = "CINV_WH_GROUP";
            this.ctrlGroup.Custom_Visible_DATA_1 = true;
            this.ctrlGroup.Custom_Visible_DATA_10 = false;
            this.ctrlGroup.Custom_Visible_DATA_2 = false;
            this.ctrlGroup.Custom_Visible_DATA_3 = false;
            this.ctrlGroup.Custom_Visible_DATA_4 = false;
            this.ctrlGroup.Custom_Visible_DATA_5 = false;
            this.ctrlGroup.Custom_Visible_DATA_6 = false;
            this.ctrlGroup.Custom_Visible_DATA_7 = false;
            this.ctrlGroup.Custom_Visible_DATA_8 = false;
            this.ctrlGroup.Custom_Visible_DATA_9 = false;
            this.ctrlGroup.Custom_VisibleDataFlag = new bool[] {
        true,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
            this.ctrlGroup.DisplaySubItemIndex = 1;
            this.ctrlGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlGroup.ExtFactory = "";
            this.ctrlGroup.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlGroup.LabelFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlGroup.LabelText = "Plant";
            this.ctrlGroup.LabelWidth = 0;
            this.ctrlGroup.Location = new System.Drawing.Point(0, 0);
            this.ctrlGroup.MaximumSize = new System.Drawing.Size(400, 20);
            this.ctrlGroup.MaxLength = 32767;
            this.ctrlGroup.MinimumSize = new System.Drawing.Size(0, 20);
            this.ctrlGroup.Name = "ctrlGroup";
            this.ctrlGroup.ReadOnly = true;
            this.ctrlGroup.SearchSubItemIndex = 0;
            this.ctrlGroup.SelectedDescIndex = 1;
            this.ctrlGroup.SelectedSubItemIndex = 0;
            this.ctrlGroup.Size = new System.Drawing.Size(100, 20);
            this.ctrlGroup.TabIndex = 8;
            this.ctrlGroup.TextBoxWidth = 100;
            this.ctrlGroup.VisibleButton = true;
            this.ctrlGroup.VisibleColumnHeader = false;
            this.ctrlGroup.VisibleDescription = false;
            this.ctrlGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.ctrlGroup_SelectedItemChanged);
            this.ctrlGroup.ButtonPressAfter += new System.EventHandler(this.ctrlGroup_ButtonPressAfter);
            this.ctrlGroup.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctrlGroup_TextBoxKeyPress);
            this.ctrlGroup.TextBoxTextChanged += new System.EventHandler(this.ctrlGroup_TextBoxTextChanged);
            this.ctrlGroup.TextBoxLostFocus += new System.EventHandler(this.ctrlGroup_TextBoxLostFocus);
            this.ctrlGroup.TextBoxGotFocus += new System.EventHandler(this.ctrlGroup_TextBoxGotFocus);
            // 
            // pnlMarginLabel1
            // 
            this.pnlMarginLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMarginLabel1.Location = new System.Drawing.Point(120, 0);
            this.pnlMarginLabel1.Name = "pnlMarginLabel1";
            this.pnlMarginLabel1.Size = new System.Drawing.Size(5, 22);
            this.pnlMarginLabel1.TabIndex = 3;
            // 
            // pnlLabel1
            // 
            this.pnlLabel1.Controls.Add(this.lblLabel1);
            this.pnlLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLabel1.Location = new System.Drawing.Point(0, 0);
            this.pnlLabel1.Name = "pnlLabel1";
            this.pnlLabel1.Size = new System.Drawing.Size(120, 22);
            this.pnlLabel1.TabIndex = 2;
            // 
            // lblLabel1
            // 
            this.lblLabel1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLabel1.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.lblLabel1.Location = new System.Drawing.Point(0, 3);
            this.lblLabel1.Name = "lblLabel1";
            this.lblLabel1.Size = new System.Drawing.Size(120, 17);
            this.lblLabel1.TabIndex = 1;
            this.lblLabel1.Text = "Group/Type/Oper";
            this.lblLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcGroupTypeOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRow1);
            this.Name = "udcGroupTypeOper";
            this.Size = new System.Drawing.Size(584, 22);
            this.FontChanged += new System.EventHandler(this.udcGroupTypeOper_FontChanged);
            this.pnlRow1.ResumeLayout(false);
            this.pnlRow1.PerformLayout();
            this.pnlControl1.ResumeLayout(false);
            this.pnlLabel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRow1;
        private System.Windows.Forms.TextBox txtDesc1;
        private System.Windows.Forms.Panel pnlControl1;
        private System.Windows.Forms.Panel pnlMargin2;
        private System.Windows.Forms.Panel pnlMargin1;
        private udcGCMCode ctrlType;
        private System.Windows.Forms.Panel pnlMarginLabel1;
        private System.Windows.Forms.Panel pnlLabel1;
        private System.Windows.Forms.Label lblLabel1;
        private System.Windows.Forms.Panel pnlMargin3;
        private udcOper ctrlOper;
        private udcGCMCode ctrlGroup;
    }
}
