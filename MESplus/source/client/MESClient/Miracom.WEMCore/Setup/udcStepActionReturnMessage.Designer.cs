namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionReturnMessage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMsgCate = new System.Windows.Forms.GroupBox();
            this.rbtSuccess = new System.Windows.Forms.RadioButton();
            this.rbtWarning = new System.Windows.Forms.RadioButton();
            this.rbtError = new System.Windows.Forms.RadioButton();
            this.cdvMsgID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMsgId = new System.Windows.Forms.Label();
            this.cboMsgGrp = new System.Windows.Forms.ComboBox();
            this.lblMsgGroup = new System.Windows.Forms.Label();
            this.chkOverride = new System.Windows.Forms.CheckBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.grpActionValue.SuspendLayout();
            this.grpMsgCate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMsgID)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.txtMsg);
            this.grpActionValue.Controls.Add(this.chkOverride);
            this.grpActionValue.Controls.Add(this.lblMsg);
            this.grpActionValue.Controls.Add(this.cdvMsgID);
            this.grpActionValue.Controls.Add(this.lblMsgId);
            this.grpActionValue.Controls.Add(this.cboMsgGrp);
            this.grpActionValue.Controls.Add(this.lblMsgGroup);
            this.grpActionValue.Controls.Add(this.grpMsgCate);
            // 
            // grpMsgCate
            // 
            this.grpMsgCate.Controls.Add(this.rbtSuccess);
            this.grpMsgCate.Controls.Add(this.rbtWarning);
            this.grpMsgCate.Controls.Add(this.rbtError);
            this.grpMsgCate.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMsgCate.Location = new System.Drawing.Point(3, 16);
            this.grpMsgCate.Name = "grpMsgCate";
            this.grpMsgCate.Size = new System.Drawing.Size(234, 60);
            this.grpMsgCate.TabIndex = 25;
            this.grpMsgCate.TabStop = false;
            this.grpMsgCate.Text = "Message Category";
            // 
            // rbtSuccess
            // 
            this.rbtSuccess.AutoSize = true;
            this.rbtSuccess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtSuccess.Location = new System.Drawing.Point(95, 38);
            this.rbtSuccess.Name = "rbtSuccess";
            this.rbtSuccess.Size = new System.Drawing.Size(72, 18);
            this.rbtSuccess.TabIndex = 24;
            this.rbtSuccess.Text = "Success";
            this.rbtSuccess.UseVisualStyleBackColor = true;
            // 
            // rbtWarning
            // 
            this.rbtWarning.AutoSize = true;
            this.rbtWarning.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtWarning.Location = new System.Drawing.Point(12, 38);
            this.rbtWarning.Name = "rbtWarning";
            this.rbtWarning.Size = new System.Drawing.Size(71, 18);
            this.rbtWarning.TabIndex = 23;
            this.rbtWarning.Text = "Warning";
            this.rbtWarning.UseVisualStyleBackColor = true;
            // 
            // rbtError
            // 
            this.rbtError.AutoSize = true;
            this.rbtError.Checked = true;
            this.rbtError.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtError.Location = new System.Drawing.Point(12, 16);
            this.rbtError.Name = "rbtError";
            this.rbtError.Size = new System.Drawing.Size(119, 18);
            this.rbtError.TabIndex = 22;
            this.rbtError.TabStop = true;
            this.rbtError.Text = "Error and Rollback";
            this.rbtError.UseVisualStyleBackColor = true;
            // 
            // cdvMsgID
            // 
            this.cdvMsgID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMsgID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMsgID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMsgID.BtnToolTipText = "";
            this.cdvMsgID.DescText = "";
            this.cdvMsgID.DisplaySubItemIndex = -1;
            this.cdvMsgID.DisplayText = "";
            this.cdvMsgID.Focusing = null;
            this.cdvMsgID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMsgID.Index = 0;
            this.cdvMsgID.IsViewBtnImage = false;
            this.cdvMsgID.Location = new System.Drawing.Point(93, 107);
            this.cdvMsgID.MaxLength = 8;
            this.cdvMsgID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMsgID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMsgID.Name = "cdvMsgID";
            this.cdvMsgID.ReadOnly = true;
            this.cdvMsgID.SearchSubItemIndex = 0;
            this.cdvMsgID.SelectedDescIndex = -1;
            this.cdvMsgID.SelectedSubItemIndex = -1;
            this.cdvMsgID.SelectionStart = 0;
            this.cdvMsgID.Size = new System.Drawing.Size(141, 20);
            this.cdvMsgID.SmallImageList = null;
            this.cdvMsgID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMsgID.TabIndex = 29;
            this.cdvMsgID.TextBoxToolTipText = "";
            this.cdvMsgID.TextBoxWidth = 141;
            this.cdvMsgID.VisibleButton = true;
            this.cdvMsgID.VisibleColumnHeader = false;
            this.cdvMsgID.VisibleDescription = false;
            this.cdvMsgID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMsgID_SelectedItemChanged);
            this.cdvMsgID.ButtonPress += new System.EventHandler(this.cdvMsgID_ButtonPress);
            // 
            // lblMsgId
            // 
            this.lblMsgId.AutoSize = true;
            this.lblMsgId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsgId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgId.Location = new System.Drawing.Point(7, 111);
            this.lblMsgId.Name = "lblMsgId";
            this.lblMsgId.Size = new System.Drawing.Size(64, 13);
            this.lblMsgId.TabIndex = 28;
            this.lblMsgId.Text = "Message ID";
            this.lblMsgId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMsgGrp
            // 
            this.cboMsgGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMsgGrp.DropDownWidth = 100;
            this.cboMsgGrp.Location = new System.Drawing.Point(93, 82);
            this.cboMsgGrp.MaxDropDownItems = 30;
            this.cboMsgGrp.MaxLength = 20;
            this.cboMsgGrp.Name = "cboMsgGrp";
            this.cboMsgGrp.Size = new System.Drawing.Size(141, 21);
            this.cboMsgGrp.TabIndex = 27;
            this.cboMsgGrp.SelectedIndexChanged += new System.EventHandler(this.cboMsgGrp_SelectedIndexChanged);
            // 
            // lblMsgGroup
            // 
            this.lblMsgGroup.AutoSize = true;
            this.lblMsgGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsgGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgGroup.Location = new System.Drawing.Point(7, 87);
            this.lblMsgGroup.Name = "lblMsgGroup";
            this.lblMsgGroup.Size = new System.Drawing.Size(82, 13);
            this.lblMsgGroup.TabIndex = 26;
            this.lblMsgGroup.Text = "Message Group";
            this.lblMsgGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkOverride
            // 
            this.chkOverride.AutoSize = true;
            this.chkOverride.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOverride.Location = new System.Drawing.Point(93, 134);
            this.chkOverride.Name = "chkOverride";
            this.chkOverride.Size = new System.Drawing.Size(72, 18);
            this.chkOverride.TabIndex = 31;
            this.chkOverride.Text = "Override";
            this.chkOverride.UseVisualStyleBackColor = true;
            this.chkOverride.CheckedChanged += new System.EventHandler(this.chkOverride_CheckedChanged);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(7, 136);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(50, 13);
            this.lblMsg.TabIndex = 30;
            this.lblMsg.Text = "Message";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.Location = new System.Drawing.Point(10, 157);
            this.txtMsg.MaxLength = 200;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(224, 154);
            this.txtMsg.TabIndex = 32;
            // 
            // udcProcessActionReturnMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcProcessActionReturnMessage";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            this.grpMsgCate.ResumeLayout(false);
            this.grpMsgCate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMsgID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMsgCate;
        private System.Windows.Forms.RadioButton rbtSuccess;
        private System.Windows.Forms.RadioButton rbtWarning;
        private System.Windows.Forms.RadioButton rbtError;
        private UI.Controls.MCCodeView.MCCodeView cdvMsgID;
        private System.Windows.Forms.Label lblMsgId;
        private System.Windows.Forms.ComboBox cboMsgGrp;
        private System.Windows.Forms.Label lblMsgGroup;
        private System.Windows.Forms.CheckBox chkOverride;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtMsg;
    }
}
