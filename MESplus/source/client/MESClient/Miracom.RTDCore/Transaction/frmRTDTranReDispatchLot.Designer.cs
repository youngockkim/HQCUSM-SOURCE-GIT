namespace Miracom.RTDCore
{
    partial class frmRTDTranReDispatchLot
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
            this.grpCenter = new System.Windows.Forms.GroupBox();
            this.chkUnselectCapableOnly = new System.Windows.Forms.CheckBox();
            this.cdvMember4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvMember3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvMember2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvMember1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMember4 = new System.Windows.Forms.Label();
            this.lblMember3 = new System.Windows.Forms.Label();
            this.lblMember2 = new System.Windows.Forms.Label();
            this.lblChangeMember = new System.Windows.Forms.Label();
            this.lblMember1 = new System.Windows.Forms.Label();
            this.cboChangeMember = new System.Windows.Forms.ComboBox();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMember4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMember3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMember2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMember1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpCenter);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // grpCenter
            // 
            this.grpCenter.Controls.Add(this.chkUnselectCapableOnly);
            this.grpCenter.Controls.Add(this.cdvMember4);
            this.grpCenter.Controls.Add(this.cdvMember3);
            this.grpCenter.Controls.Add(this.cdvMember2);
            this.grpCenter.Controls.Add(this.cdvMember1);
            this.grpCenter.Controls.Add(this.lblMember4);
            this.grpCenter.Controls.Add(this.lblMember3);
            this.grpCenter.Controls.Add(this.lblMember2);
            this.grpCenter.Controls.Add(this.lblChangeMember);
            this.grpCenter.Controls.Add(this.lblMember1);
            this.grpCenter.Controls.Add(this.cboChangeMember);
            this.grpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCenter.Location = new System.Drawing.Point(3, 0);
            this.grpCenter.Name = "grpCenter";
            this.grpCenter.Size = new System.Drawing.Size(736, 513);
            this.grpCenter.TabIndex = 1;
            this.grpCenter.TabStop = false;
            // 
            // chkUnselectCapableOnly
            // 
            this.chkUnselectCapableOnly.AutoSize = true;
            this.chkUnselectCapableOnly.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUnselectCapableOnly.Location = new System.Drawing.Point(19, 178);
            this.chkUnselectCapableOnly.Name = "chkUnselectCapableOnly";
            this.chkUnselectCapableOnly.Size = new System.Drawing.Size(140, 18);
            this.chkUnselectCapableOnly.TabIndex = 10;
            this.chkUnselectCapableOnly.Text = "Unselect-Capable Only";
            // 
            // cdvMember4
            // 
            this.cdvMember4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMember4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMember4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMember4.BtnToolTipText = "";
            this.cdvMember4.DescText = "";
            this.cdvMember4.DisplaySubItemIndex = -1;
            this.cdvMember4.DisplayText = "";
            this.cdvMember4.Focusing = null;
            this.cdvMember4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMember4.Index = 0;
            this.cdvMember4.IsViewBtnImage = false;
            this.cdvMember4.Location = new System.Drawing.Point(152, 147);
            this.cdvMember4.MaxLength = 50;
            this.cdvMember4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMember4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMember4.Name = "cdvMember4";
            this.cdvMember4.ReadOnly = false;
            this.cdvMember4.SearchSubItemIndex = 0;
            this.cdvMember4.SelectedDescIndex = -1;
            this.cdvMember4.SelectedSubItemIndex = -1;
            this.cdvMember4.SelectionStart = 0;
            this.cdvMember4.Size = new System.Drawing.Size(200, 20);
            this.cdvMember4.SmallImageList = null;
            this.cdvMember4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMember4.TabIndex = 9;
            this.cdvMember4.TextBoxToolTipText = "";
            this.cdvMember4.TextBoxWidth = 200;
            this.cdvMember4.VisibleButton = true;
            this.cdvMember4.VisibleColumnHeader = false;
            this.cdvMember4.VisibleDescription = false;
            this.cdvMember4.ButtonPress += new System.EventHandler(this.cdvMember4_ButtonPress);
            // 
            // cdvMember3
            // 
            this.cdvMember3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMember3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMember3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMember3.BtnToolTipText = "";
            this.cdvMember3.DescText = "";
            this.cdvMember3.DisplaySubItemIndex = -1;
            this.cdvMember3.DisplayText = "";
            this.cdvMember3.Focusing = null;
            this.cdvMember3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMember3.Index = 0;
            this.cdvMember3.IsViewBtnImage = false;
            this.cdvMember3.Location = new System.Drawing.Point(152, 119);
            this.cdvMember3.MaxLength = 50;
            this.cdvMember3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMember3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMember3.Name = "cdvMember3";
            this.cdvMember3.ReadOnly = false;
            this.cdvMember3.SearchSubItemIndex = 0;
            this.cdvMember3.SelectedDescIndex = -1;
            this.cdvMember3.SelectedSubItemIndex = -1;
            this.cdvMember3.SelectionStart = 0;
            this.cdvMember3.Size = new System.Drawing.Size(200, 20);
            this.cdvMember3.SmallImageList = null;
            this.cdvMember3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMember3.TabIndex = 7;
            this.cdvMember3.TextBoxToolTipText = "";
            this.cdvMember3.TextBoxWidth = 200;
            this.cdvMember3.VisibleButton = true;
            this.cdvMember3.VisibleColumnHeader = false;
            this.cdvMember3.VisibleDescription = false;
            this.cdvMember3.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMember3_SelectedItemChanged);
            this.cdvMember3.ButtonPress += new System.EventHandler(this.cdvMember3_ButtonPress);
            // 
            // cdvMember2
            // 
            this.cdvMember2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMember2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMember2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMember2.BtnToolTipText = "";
            this.cdvMember2.DescText = "";
            this.cdvMember2.DisplaySubItemIndex = -1;
            this.cdvMember2.DisplayText = "";
            this.cdvMember2.Focusing = null;
            this.cdvMember2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMember2.Index = 0;
            this.cdvMember2.IsViewBtnImage = false;
            this.cdvMember2.Location = new System.Drawing.Point(152, 91);
            this.cdvMember2.MaxLength = 50;
            this.cdvMember2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMember2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMember2.Name = "cdvMember2";
            this.cdvMember2.ReadOnly = false;
            this.cdvMember2.SearchSubItemIndex = 0;
            this.cdvMember2.SelectedDescIndex = -1;
            this.cdvMember2.SelectedSubItemIndex = -1;
            this.cdvMember2.SelectionStart = 0;
            this.cdvMember2.Size = new System.Drawing.Size(200, 20);
            this.cdvMember2.SmallImageList = null;
            this.cdvMember2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMember2.TabIndex = 5;
            this.cdvMember2.TextBoxToolTipText = "";
            this.cdvMember2.TextBoxWidth = 200;
            this.cdvMember2.VisibleButton = true;
            this.cdvMember2.VisibleColumnHeader = false;
            this.cdvMember2.VisibleDescription = false;
            this.cdvMember2.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMember2_SelectedItemChanged);
            this.cdvMember2.ButtonPress += new System.EventHandler(this.cdvMember2_ButtonPress);
            // 
            // cdvMember1
            // 
            this.cdvMember1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMember1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMember1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMember1.BtnToolTipText = "";
            this.cdvMember1.DescText = "";
            this.cdvMember1.DisplaySubItemIndex = -1;
            this.cdvMember1.DisplayText = "";
            this.cdvMember1.Focusing = null;
            this.cdvMember1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMember1.Index = 0;
            this.cdvMember1.IsViewBtnImage = false;
            this.cdvMember1.Location = new System.Drawing.Point(152, 63);
            this.cdvMember1.MaxLength = 50;
            this.cdvMember1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMember1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMember1.Name = "cdvMember1";
            this.cdvMember1.ReadOnly = false;
            this.cdvMember1.SearchSubItemIndex = 0;
            this.cdvMember1.SelectedDescIndex = -1;
            this.cdvMember1.SelectedSubItemIndex = -1;
            this.cdvMember1.SelectionStart = 0;
            this.cdvMember1.Size = new System.Drawing.Size(200, 20);
            this.cdvMember1.SmallImageList = null;
            this.cdvMember1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMember1.TabIndex = 3;
            this.cdvMember1.TextBoxToolTipText = "";
            this.cdvMember1.TextBoxWidth = 200;
            this.cdvMember1.VisibleButton = true;
            this.cdvMember1.VisibleColumnHeader = false;
            this.cdvMember1.VisibleDescription = false;
            this.cdvMember1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMember1_SelectedItemChanged);
            this.cdvMember1.ButtonPress += new System.EventHandler(this.cdvMember1_ButtonPress);
            // 
            // lblMember4
            // 
            this.lblMember4.AutoSize = true;
            this.lblMember4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMember4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMember4.Location = new System.Drawing.Point(19, 150);
            this.lblMember4.Name = "lblMember4";
            this.lblMember4.Size = new System.Drawing.Size(54, 13);
            this.lblMember4.TabIndex = 8;
            this.lblMember4.Text = "Member 4";
            // 
            // lblMember3
            // 
            this.lblMember3.AutoSize = true;
            this.lblMember3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMember3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMember3.Location = new System.Drawing.Point(19, 122);
            this.lblMember3.Name = "lblMember3";
            this.lblMember3.Size = new System.Drawing.Size(54, 13);
            this.lblMember3.TabIndex = 6;
            this.lblMember3.Text = "Member 3";
            // 
            // lblMember2
            // 
            this.lblMember2.AutoSize = true;
            this.lblMember2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMember2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMember2.Location = new System.Drawing.Point(19, 94);
            this.lblMember2.Name = "lblMember2";
            this.lblMember2.Size = new System.Drawing.Size(54, 13);
            this.lblMember2.TabIndex = 4;
            this.lblMember2.Text = "Member 2";
            // 
            // lblChangeMember
            // 
            this.lblChangeMember.AutoSize = true;
            this.lblChangeMember.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChangeMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeMember.Location = new System.Drawing.Point(19, 37);
            this.lblChangeMember.Name = "lblChangeMember";
            this.lblChangeMember.Size = new System.Drawing.Size(85, 13);
            this.lblChangeMember.TabIndex = 0;
            this.lblChangeMember.Text = "Change Member";
            // 
            // lblMember1
            // 
            this.lblMember1.AutoSize = true;
            this.lblMember1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMember1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMember1.Location = new System.Drawing.Point(19, 66);
            this.lblMember1.Name = "lblMember1";
            this.lblMember1.Size = new System.Drawing.Size(54, 13);
            this.lblMember1.TabIndex = 2;
            this.lblMember1.Text = "Member 1";
            // 
            // cboChangeMember
            // 
            this.cboChangeMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChangeMember.Items.AddRange(new object[] {
            "Lot",
            "Resource",
            "Resource Group",
            "Material",
            "Flow",
            "Operation",
            "Batch",
            "Material-Flow-Operation",
            "Flow-Operation",
            "Material-Operation",
            "Dispatcher",
            "Dispatcher Rule",
            "All",
            "Child Lots",
            "Zero Qty Lot"});
            this.cboChangeMember.Location = new System.Drawing.Point(152, 34);
            this.cboChangeMember.Name = "cboChangeMember";
            this.cboChangeMember.Size = new System.Drawing.Size(200, 21);
            this.cboChangeMember.TabIndex = 1;
            this.cboChangeMember.SelectedIndexChanged += new System.EventHandler(this.cboChangeMember_SelectedIndexChanged);
            // 
            // frmRTDTranReDispatchLot
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRTDTranReDispatchLot";
            this.Text = "Re-Dispatch Lot";
            this.Load += new System.EventHandler(this.frmRTDTranReDispatchLot_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpCenter.ResumeLayout(false);
            this.grpCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMember4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMember3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMember2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMember1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCenter;
        private System.Windows.Forms.Label lblMember4;
        private System.Windows.Forms.Label lblMember3;
        private System.Windows.Forms.Label lblMember2;
        private System.Windows.Forms.Label lblChangeMember;
        private System.Windows.Forms.Label lblMember1;
        private System.Windows.Forms.ComboBox cboChangeMember;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMember4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMember3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMember2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMember1;
        private System.Windows.Forms.CheckBox chkUnselectCapableOnly;
    }
}
