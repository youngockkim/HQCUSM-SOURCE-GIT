namespace Miracom.MESCore.Controls
{
    partial class udcFlexibleConditionForLot
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
            this.cdvCondition = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpFlexibleCondition = new System.Windows.Forms.GroupBox();
            this.lblAttributeName = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpLogical = new System.Windows.Forms.GroupBox();
            this.cboLogical = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpOperator = new System.Windows.Forms.GroupBox();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.cdvValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtQuery = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCondition)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.grpFlexibleCondition.SuspendLayout();
            this.grpLogical.SuspendLayout();
            this.grpOperator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue)).BeginInit();
            this.SuspendLayout();
            // 
            // cdvCondition
            // 
            this.cdvCondition.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCondition.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCondition.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCondition.BtnToolTipText = "";
            this.cdvCondition.DescText = "";
            this.cdvCondition.DisplaySubItemIndex = 0;
            this.cdvCondition.DisplayText = "";
            this.cdvCondition.Focusing = null;
            this.cdvCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCondition.Index = 0;
            this.cdvCondition.IsViewBtnImage = false;
            this.cdvCondition.Location = new System.Drawing.Point(99, 16);
            this.cdvCondition.MaxLength = 20;
            this.cdvCondition.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCondition.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCondition.Name = "cdvCondition";
            this.cdvCondition.ReadOnly = false;
            this.cdvCondition.SearchSubItemIndex = 0;
            this.cdvCondition.SelectedDescIndex = -1;
            this.cdvCondition.SelectedSubItemIndex = 0;
            this.cdvCondition.SelectionStart = 0;
            this.cdvCondition.Size = new System.Drawing.Size(150, 20);
            this.cdvCondition.SmallImageList = null;
            this.cdvCondition.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCondition.TabIndex = 1;
            this.cdvCondition.TextBoxToolTipText = "";
            this.cdvCondition.TextBoxWidth = 150;
            this.cdvCondition.VisibleButton = true;
            this.cdvCondition.VisibleColumnHeader = false;
            this.cdvCondition.VisibleDescription = false;
            this.cdvCondition.ButtonPress += new System.EventHandler(this.cdvCondition_ButtonPress);
            this.cdvCondition.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCondition_SelectedItemChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpFlexibleCondition);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(700, 83);
            this.pnlMain.TabIndex = 0;
            // 
            // grpFlexibleCondition
            // 
            this.grpFlexibleCondition.Controls.Add(this.lblAttributeName);
            this.grpFlexibleCondition.Controls.Add(this.btnClear);
            this.grpFlexibleCondition.Controls.Add(this.grpLogical);
            this.grpFlexibleCondition.Controls.Add(this.btnAdd);
            this.grpFlexibleCondition.Controls.Add(this.grpOperator);
            this.grpFlexibleCondition.Controls.Add(this.txtQuery);
            this.grpFlexibleCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFlexibleCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFlexibleCondition.Location = new System.Drawing.Point(0, 0);
            this.grpFlexibleCondition.Name = "grpFlexibleCondition";
            this.grpFlexibleCondition.Size = new System.Drawing.Size(700, 83);
            this.grpFlexibleCondition.TabIndex = 0;
            this.grpFlexibleCondition.TabStop = false;
            // 
            // lblAttributeName
            // 
            this.lblAttributeName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttributeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttributeName.Location = new System.Drawing.Point(9, 61);
            this.lblAttributeName.Name = "lblAttributeName";
            this.lblAttributeName.Size = new System.Drawing.Size(90, 14);
            this.lblAttributeName.TabIndex = 4;
            this.lblAttributeName.Text = "Added Condition";
            this.lblAttributeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(644, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 36);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpLogical
            // 
            this.grpLogical.Controls.Add(this.cboLogical);
            this.grpLogical.Controls.Add(this.cdvCondition);
            this.grpLogical.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLogical.Location = new System.Drawing.Point(6, 10);
            this.grpLogical.Name = "grpLogical";
            this.grpLogical.Size = new System.Drawing.Size(252, 42);
            this.grpLogical.TabIndex = 0;
            this.grpLogical.TabStop = false;
            this.grpLogical.Text = "Logical Operator";
            // 
            // cboLogical
            // 
            this.cboLogical.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLogical.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cboLogical.Location = new System.Drawing.Point(6, 16);
            this.cboLogical.MaxLength = 1;
            this.cboLogical.Name = "cboLogical";
            this.cboLogical.Size = new System.Drawing.Size(87, 21);
            this.cboLogical.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(592, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 36);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpOperator
            // 
            this.grpOperator.Controls.Add(this.cboOperator);
            this.grpOperator.Controls.Add(this.cdvValue);
            this.grpOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOperator.Location = new System.Drawing.Point(263, 10);
            this.grpOperator.Name = "grpOperator";
            this.grpOperator.Size = new System.Drawing.Size(323, 42);
            this.grpOperator.TabIndex = 1;
            this.grpOperator.TabStop = false;
            this.grpOperator.Text = "Operator";
            // 
            // cboOperator
            // 
            this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator.Items.AddRange(new object[] {
            "= (Equal)",
            "> (Greater than)",
            ">= (Equal or Greater than)",
            "< (Less than)",
            "<= (Equal or Less than)"});
            this.cboOperator.Location = new System.Drawing.Point(6, 16);
            this.cboOperator.MaxLength = 1;
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(155, 21);
            this.cboOperator.TabIndex = 0;
            // 
            // cdvValue
            // 
            this.cdvValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue.BtnToolTipText = "";
            this.cdvValue.DescText = "";
            this.cdvValue.DisplaySubItemIndex = 0;
            this.cdvValue.DisplayText = "";
            this.cdvValue.Focusing = null;
            this.cdvValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue.Index = 0;
            this.cdvValue.IsViewBtnImage = false;
            this.cdvValue.Location = new System.Drawing.Point(167, 16);
            this.cdvValue.MaxLength = 20;
            this.cdvValue.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue.Name = "cdvValue";
            this.cdvValue.ReadOnly = false;
            this.cdvValue.SearchSubItemIndex = 0;
            this.cdvValue.SelectedDescIndex = -1;
            this.cdvValue.SelectedSubItemIndex = 0;
            this.cdvValue.SelectionStart = 0;
            this.cdvValue.Size = new System.Drawing.Size(150, 20);
            this.cdvValue.SmallImageList = null;
            this.cdvValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue.TabIndex = 1;
            this.cdvValue.TextBoxToolTipText = "";
            this.cdvValue.TextBoxWidth = 150;
            this.cdvValue.VisibleButton = true;
            this.cdvValue.VisibleColumnHeader = false;
            this.cdvValue.VisibleDescription = false;
            this.cdvValue.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvValue_TextBoxKeyPress);
            this.cdvValue.ButtonPress += new System.EventHandler(this.cdvValue_ButtonPress);
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(105, 58);
            this.txtQuery.MaxLength = 10000;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(588, 20);
            this.txtQuery.TabIndex = 5;
            // 
            // udcFlexibleConditionForLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "udcFlexibleConditionForLot";
            this.Size = new System.Drawing.Size(700, 83);
            this.Load += new System.EventHandler(this.udcFlexibleConditionForLot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCondition)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.grpFlexibleCondition.ResumeLayout(false);
            this.grpFlexibleCondition.PerformLayout();
            this.grpLogical.ResumeLayout(false);
            this.grpOperator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCondition;
        private System.Windows.Forms.Panel pnlMain;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue;
        private System.Windows.Forms.GroupBox grpOperator;
        private System.Windows.Forms.GroupBox grpLogical;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboLogical;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.GroupBox grpFlexibleCondition;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblAttributeName;
    }
}
