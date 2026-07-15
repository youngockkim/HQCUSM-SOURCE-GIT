namespace Custom.HanwhaQcell.USModule
{
    partial class frmInputAuditPlanPopup
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
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAuditor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvCustomer = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvManager = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.dtpPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuditDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuditID = new System.Windows.Forms.TextBox();
            this.lblCalibrationInstituteCode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAgenda = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(458, 6);
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(640, 6);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(549, 6);
            this.btnUpdate.Text = "Save";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(731, 6);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 221);
            this.pnlBottom.Size = new System.Drawing.Size(834, 40);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.groupBox1);
            this.pnlCenter.Controls.Add(this.grpInfo);
            this.pnlCenter.Size = new System.Drawing.Size(834, 221);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Input Audit Plan";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.label5);
            this.grpInfo.Controls.Add(this.txtAuditor);
            this.grpInfo.Controls.Add(this.label2);
            this.grpInfo.Controls.Add(this.cdvCustomer);
            this.grpInfo.Controls.Add(this.cdvManager);
            this.grpInfo.Controls.Add(this.dtpPlanDate);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Controls.Add(this.txtAuditDesc);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Controls.Add(this.txtAuditID);
            this.grpInfo.Controls.Add(this.lblCalibrationInstituteCode);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(834, 95);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Information Audit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(399, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "Manager";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(399, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 129;
            this.label5.Text = "Customer";
            // 
            // txtAuditor
            // 
            this.txtAuditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditor.Location = new System.Drawing.Point(100, 69);
            this.txtAuditor.MaxLength = 50;
            this.txtAuditor.Name = "txtAuditor";
            this.txtAuditor.Size = new System.Drawing.Size(254, 20);
            this.txtAuditor.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(22, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Auditor";
            // 
            // cdvCustomer
            // 
            this.cdvCustomer.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCustomer.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCustomer.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCustomer.BtnToolTipText = "";
            this.cdvCustomer.ButtonWidth = 20;
            this.cdvCustomer.DescText = "";
            this.cdvCustomer.DisplaySubItemIndex = 0;
            this.cdvCustomer.DisplayText = "";
            this.cdvCustomer.Focusing = null;
            this.cdvCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCustomer.Index = 0;
            this.cdvCustomer.IsViewBtnImage = false;
            this.cdvCustomer.Location = new System.Drawing.Point(466, 43);
            this.cdvCustomer.MaxLength = 20;
            this.cdvCustomer.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCustomer.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCustomer.MultiSelect = false;
            this.cdvCustomer.Name = "cdvCustomer";
            this.cdvCustomer.ReadOnly = false;
            this.cdvCustomer.SameWidthHeightOfButton = false;
            this.cdvCustomer.SearchSubItemIndex = 0;
            this.cdvCustomer.SelectedDescIndex = 1;
            this.cdvCustomer.SelectedDescToQueryText = "";
            this.cdvCustomer.SelectedSubItemIndex = 0;
            this.cdvCustomer.SelectedValueToQueryText = "";
            this.cdvCustomer.SelectionStart = 0;
            this.cdvCustomer.Size = new System.Drawing.Size(353, 21);
            this.cdvCustomer.SmallImageList = null;
            this.cdvCustomer.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCustomer.TabIndex = 4;
            this.cdvCustomer.TextBoxToolTipText = "";
            this.cdvCustomer.TextBoxWidth = 110;
            this.cdvCustomer.VisibleButton = true;
            this.cdvCustomer.VisibleColumnHeader = false;
            this.cdvCustomer.VisibleDescription = true;
            this.cdvCustomer.ButtonPress += new System.EventHandler(this.cdvCustomer_ButtonPress);
            // 
            // cdvManager
            // 
            this.cdvManager.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvManager.BorderHotColor = System.Drawing.Color.Black;
            this.cdvManager.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvManager.BtnToolTipText = "";
            this.cdvManager.ButtonWidth = 20;
            this.cdvManager.DescText = "";
            this.cdvManager.DisplaySubItemIndex = 0;
            this.cdvManager.DisplayText = "";
            this.cdvManager.Focusing = null;
            this.cdvManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvManager.Index = 0;
            this.cdvManager.IsViewBtnImage = false;
            this.cdvManager.Location = new System.Drawing.Point(466, 69);
            this.cdvManager.MaxLength = 20;
            this.cdvManager.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvManager.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvManager.MultiSelect = false;
            this.cdvManager.Name = "cdvManager";
            this.cdvManager.ReadOnly = false;
            this.cdvManager.SameWidthHeightOfButton = false;
            this.cdvManager.SearchSubItemIndex = 0;
            this.cdvManager.SelectedDescIndex = 1;
            this.cdvManager.SelectedDescToQueryText = "";
            this.cdvManager.SelectedSubItemIndex = 0;
            this.cdvManager.SelectedValueToQueryText = "";
            this.cdvManager.SelectionStart = 0;
            this.cdvManager.Size = new System.Drawing.Size(353, 21);
            this.cdvManager.SmallImageList = null;
            this.cdvManager.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvManager.TabIndex = 6;
            this.cdvManager.TextBoxToolTipText = "";
            this.cdvManager.TextBoxWidth = 110;
            this.cdvManager.VisibleButton = true;
            this.cdvManager.VisibleColumnHeader = false;
            this.cdvManager.VisibleDescription = true;
            this.cdvManager.ButtonPress += new System.EventHandler(this.cdvManager_ButtonPress);
            // 
            // dtpPlanDate
            // 
            this.dtpPlanDate.Checked = false;
            this.dtpPlanDate.CustomFormat = "";
            this.dtpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanDate.Location = new System.Drawing.Point(100, 43);
            this.dtpPlanDate.Name = "dtpPlanDate";
            this.dtpPlanDate.Size = new System.Drawing.Size(96, 20);
            this.dtpPlanDate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(22, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Plan Date";
            // 
            // txtAuditDesc
            // 
            this.txtAuditDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditDesc.Location = new System.Drawing.Point(466, 17);
            this.txtAuditDesc.MaxLength = 50;
            this.txtAuditDesc.Name = "txtAuditDesc";
            this.txtAuditDesc.Size = new System.Drawing.Size(353, 20);
            this.txtAuditDesc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(399, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Description";
            // 
            // txtAuditID
            // 
            this.txtAuditID.BackColor = System.Drawing.Color.Silver;
            this.txtAuditID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditID.Location = new System.Drawing.Point(100, 17);
            this.txtAuditID.MaxLength = 20;
            this.txtAuditID.Name = "txtAuditID";
            this.txtAuditID.ReadOnly = true;
            this.txtAuditID.Size = new System.Drawing.Size(96, 20);
            this.txtAuditID.TabIndex = 1;
            // 
            // lblCalibrationInstituteCode
            // 
            this.lblCalibrationInstituteCode.AutoSize = true;
            this.lblCalibrationInstituteCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationInstituteCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationInstituteCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCalibrationInstituteCode.Location = new System.Drawing.Point(22, 21);
            this.lblCalibrationInstituteCode.Name = "lblCalibrationInstituteCode";
            this.lblCalibrationInstituteCode.Size = new System.Drawing.Size(45, 13);
            this.lblCalibrationInstituteCode.TabIndex = 10;
            this.lblCalibrationInstituteCode.Text = "Audit ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAgenda);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 126);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audit Contents";
            // 
            // txtAgenda
            // 
            this.txtAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgenda.Location = new System.Drawing.Point(12, 40);
            this.txtAgenda.MaxLength = 500;
            this.txtAgenda.Multiline = true;
            this.txtAgenda.Name = "txtAgenda";
            this.txtAgenda.Size = new System.Drawing.Size(807, 80);
            this.txtAgenda.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(16, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Agenda";
            // 
            // frmInputAuditPlanPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 261);
            this.MaximumSize = new System.Drawing.Size(850, 300);
            this.MinimumSize = new System.Drawing.Size(850, 300);
            this.Name = "frmInputAuditPlanPopup";
            this.Text = "Input Audit Plan";
            this.Activated += new System.EventHandler(this.frmInputAuditPlanPopup_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtAuditDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuditID;
        private System.Windows.Forms.Label lblCalibrationInstituteCode;
        private System.Windows.Forms.DateTimePicker dtpPlanDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAgenda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAuditor;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCustomer;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvManager;
    }
}