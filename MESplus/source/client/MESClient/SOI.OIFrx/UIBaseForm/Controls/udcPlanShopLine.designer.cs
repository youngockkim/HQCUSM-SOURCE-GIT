namespace SOI.OIFrx
{
    partial class udcPlantShopLine
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
            this.ctrlLine = new udcLine();
            this.pnlMargin3 = new System.Windows.Forms.Panel();
            this.pnlMargin2 = new System.Windows.Forms.Panel();
            this.ctrlShop = new udcShop();
            this.pnlMarzine4 = new System.Windows.Forms.Panel();
            this.pnlMargin1 = new System.Windows.Forms.Panel();
            this.ctrlPlant = new udcGCMCode();
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
            this.pnlControl1.Controls.Add(this.ctrlLine);
            this.pnlControl1.Controls.Add(this.pnlMargin3);
            this.pnlControl1.Controls.Add(this.pnlMargin2);
            this.pnlControl1.Controls.Add(this.ctrlShop);
            this.pnlControl1.Controls.Add(this.pnlMarzine4);
            this.pnlControl1.Controls.Add(this.pnlMargin1);
            this.pnlControl1.Controls.Add(this.ctrlPlant);
            this.pnlControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControl1.Location = new System.Drawing.Point(125, 0);
            this.pnlControl1.MinimumSize = new System.Drawing.Size(315, 20);
            this.pnlControl1.Name = "pnlControl1";
            this.pnlControl1.Size = new System.Drawing.Size(315, 22);
            this.pnlControl1.TabIndex = 3;
            // 
            // ctrlLine
            // 
            this.ctrlLine.AddEmptyRowToLast = false;
            this.ctrlLine.AddEmptyRowToTop = true;
            this.ctrlLine.ButtonWidth = 20;
            this.ctrlLine.DisplaySubItemIndex = 1;
            this.ctrlLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLine.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLine.LabelFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLine.LabelText = "Line";
            this.ctrlLine.LabelWidth = 0;
            this.ctrlLine.ListCond_ExtFactory = "";
            this.ctrlLine.ListCond_Step = '1';
            this.ctrlLine.Location = new System.Drawing.Point(220, 0);
            this.ctrlLine.MaximumSize = new System.Drawing.Size(0, 20);
            this.ctrlLine.MaxLength = 32767;
            this.ctrlLine.MinimumSize = new System.Drawing.Size(100, 20);
            this.ctrlLine.Name = "ctrlLine";
            this.ctrlLine.ReadOnly = false;
            this.ctrlLine.SearchSubItemIndex = 0;
            this.ctrlLine.SelectedDescIndex = 1;
            this.ctrlLine.SelectedSubItemIndex = 0;
            this.ctrlLine.Size = new System.Drawing.Size(100, 20);
            this.ctrlLine.TabIndex = 11;
            this.ctrlLine.TextBoxWidth = 100;
            this.ctrlLine.VisibleButton = true;
            this.ctrlLine.VisibleColumnHeader = false;
            this.ctrlLine.VisibleDescription = false;
            this.ctrlLine.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.ctrlLine_SelectedItemChanged);
            this.ctrlLine.ButtonPress += new System.EventHandler(this.ctrlLine_ButtonPress);
            this.ctrlLine.ButtonPressAfter += new System.EventHandler(this.ctrlLine_ButtonPressAfter);
            this.ctrlLine.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctrlLine_TextBoxKeyPress);
            this.ctrlLine.TextBoxTextChanged += new System.EventHandler(this.ctrlLine_TextBoxTextChanged);
            this.ctrlLine.TextBoxLostFocus += new System.EventHandler(this.ctrlLine_TextBoxLostFocus);
            this.ctrlLine.TextBoxGotFocus += new System.EventHandler(this.ctrlLine_TextBoxGotFocus);
            // 
            // pnlMargin3
            // 
            this.pnlMargin3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMargin3.Location = new System.Drawing.Point(215, 0);
            this.pnlMargin3.Name = "pnlMargin3";
            this.pnlMargin3.Size = new System.Drawing.Size(5, 22);
            this.pnlMargin3.TabIndex = 10;
            // 
            // pnlMargin2
            // 
            this.pnlMargin2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMargin2.Location = new System.Drawing.Point(210, 0);
            this.pnlMargin2.Name = "pnlMargin2";
            this.pnlMargin2.Size = new System.Drawing.Size(5, 22);
            this.pnlMargin2.TabIndex = 9;
            // 
            // ctrlShop
            // 
            this.ctrlShop.AddEmptyRowToLast = false;
            this.ctrlShop.AddEmptyRowToTop = true;
            this.ctrlShop.ButtonWidth = 20;
            this.ctrlShop.DisplaySubItemIndex = 1;
            this.ctrlShop.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlShop.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlShop.LabelFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlShop.LabelText = "Shop";
            this.ctrlShop.LabelWidth = 0;
            this.ctrlShop.ListCond_ExtFactory = "";
            this.ctrlShop.ListCond_Step = '1';
            this.ctrlShop.Location = new System.Drawing.Point(110, 0);
            this.ctrlShop.MaximumSize = new System.Drawing.Size(0, 20);
            this.ctrlShop.MaxLength = 20;
            this.ctrlShop.MinimumSize = new System.Drawing.Size(100, 20);
            this.ctrlShop.Name = "ctrlShop";
            this.ctrlShop.ReadOnly = false;
            this.ctrlShop.SearchSubItemIndex = 0;
            this.ctrlShop.SelectedDescIndex = 1;
            this.ctrlShop.SelectedSubItemIndex = 0;
            this.ctrlShop.Size = new System.Drawing.Size(100, 20);
            this.ctrlShop.TabIndex = 0;
            this.ctrlShop.TextBoxWidth = 100;
            this.ctrlShop.VisibleButton = true;
            this.ctrlShop.VisibleColumnHeader = false;
            this.ctrlShop.VisibleDescription = false;
            this.ctrlShop.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.ctrlShop_SelectedItemChanged);
            this.ctrlShop.ButtonPress += new System.EventHandler(this.ctrlShop_ButtonPress);
            this.ctrlShop.ButtonPressAfter += new System.EventHandler(this.ctrlShop_ButtonPressAfter);
            this.ctrlShop.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctrlShop_TextBoxKeyPress);
            this.ctrlShop.TextBoxTextChanged += new System.EventHandler(this.ctrlShop_TextBoxTextChanged);
            this.ctrlShop.TextBoxLostFocus += new System.EventHandler(this.ctrlShop_TextBoxLostFocus);
            this.ctrlShop.TextBoxGotFocus += new System.EventHandler(this.ctrlShop_TextBoxGotFocus);
            // 
            // pnlMarzine4
            // 
            this.pnlMarzine4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMarzine4.Location = new System.Drawing.Point(105, 0);
            this.pnlMarzine4.Name = "pnlMarzine4";
            this.pnlMarzine4.Size = new System.Drawing.Size(5, 22);
            this.pnlMarzine4.TabIndex = 5;
            // 
            // pnlMargin1
            // 
            this.pnlMargin1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMargin1.Location = new System.Drawing.Point(100, 0);
            this.pnlMargin1.Name = "pnlMargin1";
            this.pnlMargin1.Size = new System.Drawing.Size(5, 22);
            this.pnlMargin1.TabIndex = 4;
            // 
            // ctrlPlant
            // 
            this.ctrlPlant.ButtonWidth = 21;
            this.ctrlPlant.Custom_AddEmptyRowLast = false;
            this.ctrlPlant.Custom_AddEmptyRowTop = true;
            this.ctrlPlant.Custom_Step = '1';
            this.ctrlPlant.Custom_SubTableName = "";
            this.ctrlPlant.Custom_TableName = "AREA";
            this.ctrlPlant.Custom_Visible_DATA_1 = true;
            this.ctrlPlant.Custom_Visible_DATA_10 = false;
            this.ctrlPlant.Custom_Visible_DATA_2 = false;
            this.ctrlPlant.Custom_Visible_DATA_3 = false;
            this.ctrlPlant.Custom_Visible_DATA_4 = false;
            this.ctrlPlant.Custom_Visible_DATA_5 = false;
            this.ctrlPlant.Custom_Visible_DATA_6 = false;
            this.ctrlPlant.Custom_Visible_DATA_7 = false;
            this.ctrlPlant.Custom_Visible_DATA_8 = false;
            this.ctrlPlant.Custom_Visible_DATA_9 = false;
            this.ctrlPlant.Custom_VisibleDataFlag = new bool[] {
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
            this.ctrlPlant.DisplaySubItemIndex = 1;
            this.ctrlPlant.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlPlant.ExtFactory = "";
            this.ctrlPlant.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPlant.LabelFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPlant.LabelText = "Plant";
            this.ctrlPlant.LabelWidth = 0;
            this.ctrlPlant.Location = new System.Drawing.Point(0, 0);
            this.ctrlPlant.MaximumSize = new System.Drawing.Size(400, 20);
            this.ctrlPlant.MaxLength = 32767;
            this.ctrlPlant.MinimumSize = new System.Drawing.Size(0, 20);
            this.ctrlPlant.Name = "ctrlPlant";
            this.ctrlPlant.ReadOnly = true;
            this.ctrlPlant.SearchSubItemIndex = 0;
            this.ctrlPlant.SelectedDescIndex = 1;
            this.ctrlPlant.SelectedSubItemIndex = 0;
            this.ctrlPlant.Size = new System.Drawing.Size(100, 20);
            this.ctrlPlant.TabIndex = 8;
            this.ctrlPlant.TextBoxWidth = 100;
            this.ctrlPlant.VisibleButton = true;
            this.ctrlPlant.VisibleColumnHeader = false;
            this.ctrlPlant.VisibleDescription = false;
            this.ctrlPlant.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.ctrlPlant_SelectedItemChanged);
            this.ctrlPlant.ButtonPressAfter += new System.EventHandler(this.ctrlPlant_ButtonPressAfter);
            this.ctrlPlant.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctrlPlant_TextBoxKeyPress);
            this.ctrlPlant.TextBoxTextChanged += new System.EventHandler(this.ctrlPlant_TextBoxTextChanged);
            this.ctrlPlant.TextBoxLostFocus += new System.EventHandler(this.ctrlPlant_TextBoxLostFocus);
            this.ctrlPlant.TextBoxGotFocus += new System.EventHandler(this.ctrlPlant_TextBoxGotFocus);
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
            this.lblLabel1.Text = "Plant/Shop/Line";
            this.lblLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcPlantShopLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRow1);
            this.Name = "udcPlantShopLine";
            this.Size = new System.Drawing.Size(584, 22);
            this.FontChanged += new System.EventHandler(this.udcMGrpShopLine_FontChanged);
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
        private udcShop ctrlShop;
        private System.Windows.Forms.Panel pnlMarginLabel1;
        private System.Windows.Forms.Panel pnlLabel1;
        private System.Windows.Forms.Label lblLabel1;
        private System.Windows.Forms.Panel pnlMargin3;
        private udcLine ctrlLine;
        private udcGCMCode ctrlPlant;
        private System.Windows.Forms.Panel pnlMarzine4;
    }
}
