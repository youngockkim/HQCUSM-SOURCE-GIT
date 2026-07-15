namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionError
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
            this.grpActionFalse = new System.Windows.Forms.GroupBox();
            this.cboFalseMsgGrp = new System.Windows.Forms.ComboBox();
            this.grpFalseMsgCate = new System.Windows.Forms.GroupBox();
            this.rbtFalseSuccess = new System.Windows.Forms.RadioButton();
            this.rbtFalseWarning = new System.Windows.Forms.RadioButton();
            this.rbtFalseError = new System.Windows.Forms.RadioButton();
            this.chkFalseOverride = new System.Windows.Forms.CheckBox();
            this.txtFalseMsg = new System.Windows.Forms.TextBox();
            this.lblFalseMsg = new System.Windows.Forms.Label();
            this.cdvFalseMsgID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFalseMsgId = new System.Windows.Forms.Label();
            this.lblFalseMsgGroup = new System.Windows.Forms.Label();
            this.grpActionTrue = new System.Windows.Forms.GroupBox();
            this.grpMsgCate = new System.Windows.Forms.GroupBox();
            this.rbtSuccess = new System.Windows.Forms.RadioButton();
            this.rbtWarning = new System.Windows.Forms.RadioButton();
            this.rbtError = new System.Windows.Forms.RadioButton();
            this.chkOverride = new System.Windows.Forms.CheckBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.cdvMsgID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMsgId = new System.Windows.Forms.Label();
            this.cboMsgGrp = new System.Windows.Forms.ComboBox();
            this.lblMsgGroup = new System.Windows.Forms.Label();
            this.pnlActionValueTop = new System.Windows.Forms.Panel();
            this.cboActionType = new System.Windows.Forms.ComboBox();
            this.lblActionType = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.grpActionFalse.SuspendLayout();
            this.grpFalseMsgCate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFalseMsgID)).BeginInit();
            this.grpActionTrue.SuspendLayout();
            this.grpMsgCate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMsgID)).BeginInit();
            this.pnlActionValueTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.grpActionFalse);
            this.grpActionValue.Controls.Add(this.grpActionTrue);
            this.grpActionValue.Controls.Add(this.pnlActionValueTop);
            // 
            // grpActionFalse
            // 
            this.grpActionFalse.Controls.Add(this.cboFalseMsgGrp);
            this.grpActionFalse.Controls.Add(this.grpFalseMsgCate);
            this.grpActionFalse.Controls.Add(this.chkFalseOverride);
            this.grpActionFalse.Controls.Add(this.txtFalseMsg);
            this.grpActionFalse.Controls.Add(this.lblFalseMsg);
            this.grpActionFalse.Controls.Add(this.cdvFalseMsgID);
            this.grpActionFalse.Controls.Add(this.lblFalseMsgId);
            this.grpActionFalse.Controls.Add(this.lblFalseMsgGroup);
            this.grpActionFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionFalse.Location = new System.Drawing.Point(3, 155);
            this.grpActionFalse.Name = "grpActionFalse";
            this.grpActionFalse.Size = new System.Drawing.Size(524, 172);
            this.grpActionFalse.TabIndex = 5;
            this.grpActionFalse.TabStop = false;
            this.grpActionFalse.Text = "False Action";
            // 
            // cboFalseMsgGrp
            // 
            this.cboFalseMsgGrp.DropDownWidth = 100;
            this.cboFalseMsgGrp.Location = new System.Drawing.Point(94, 16);
            this.cboFalseMsgGrp.MaxDropDownItems = 30;
            this.cboFalseMsgGrp.MaxLength = 20;
            this.cboFalseMsgGrp.Name = "cboFalseMsgGrp";
            this.cboFalseMsgGrp.Size = new System.Drawing.Size(141, 20);
            this.cboFalseMsgGrp.TabIndex = 32;
            this.cboFalseMsgGrp.SelectedIndexChanged += new System.EventHandler(this.cboFalseMsgGrp_SelectedIndexChanged);
            this.cboFalseMsgGrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboActionType_KeyPress);
            // 
            // grpFalseMsgCate
            // 
            this.grpFalseMsgCate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFalseMsgCate.Controls.Add(this.rbtFalseSuccess);
            this.grpFalseMsgCate.Controls.Add(this.rbtFalseWarning);
            this.grpFalseMsgCate.Controls.Add(this.rbtFalseError);
            this.grpFalseMsgCate.Location = new System.Drawing.Point(241, 16);
            this.grpFalseMsgCate.Name = "grpFalseMsgCate";
            this.grpFalseMsgCate.Size = new System.Drawing.Size(277, 46);
            this.grpFalseMsgCate.TabIndex = 31;
            this.grpFalseMsgCate.TabStop = false;
            this.grpFalseMsgCate.Text = "Message Category";
            // 
            // rbtFalseSuccess
            // 
            this.rbtFalseSuccess.AutoSize = true;
            this.rbtFalseSuccess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtFalseSuccess.Location = new System.Drawing.Point(203, 21);
            this.rbtFalseSuccess.Name = "rbtFalseSuccess";
            this.rbtFalseSuccess.Size = new System.Drawing.Size(79, 17);
            this.rbtFalseSuccess.TabIndex = 24;
            this.rbtFalseSuccess.Text = "Success";
            this.rbtFalseSuccess.UseVisualStyleBackColor = true;
            // 
            // rbtFalseWarning
            // 
            this.rbtFalseWarning.AutoSize = true;
            this.rbtFalseWarning.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtFalseWarning.Location = new System.Drawing.Point(128, 21);
            this.rbtFalseWarning.Name = "rbtFalseWarning";
            this.rbtFalseWarning.Size = new System.Drawing.Size(74, 17);
            this.rbtFalseWarning.TabIndex = 23;
            this.rbtFalseWarning.Text = "Warning";
            this.rbtFalseWarning.UseVisualStyleBackColor = true;
            // 
            // rbtFalseError
            // 
            this.rbtFalseError.AutoSize = true;
            this.rbtFalseError.Checked = true;
            this.rbtFalseError.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtFalseError.Location = new System.Drawing.Point(4, 21);
            this.rbtFalseError.Name = "rbtFalseError";
            this.rbtFalseError.Size = new System.Drawing.Size(133, 17);
            this.rbtFalseError.TabIndex = 22;
            this.rbtFalseError.TabStop = true;
            this.rbtFalseError.Text = "Error and Rollback";
            this.rbtFalseError.UseVisualStyleBackColor = true;
            // 
            // chkFalseOverride
            // 
            this.chkFalseOverride.AutoSize = true;
            this.chkFalseOverride.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkFalseOverride.Location = new System.Drawing.Point(10, 88);
            this.chkFalseOverride.Name = "chkFalseOverride";
            this.chkFalseOverride.Size = new System.Drawing.Size(77, 17);
            this.chkFalseOverride.TabIndex = 30;
            this.chkFalseOverride.Text = "Override";
            this.chkFalseOverride.UseVisualStyleBackColor = true;
            this.chkFalseOverride.CheckedChanged += new System.EventHandler(this.chkFalseOverride_CheckedChanged);
            // 
            // txtFalseMsg
            // 
            this.txtFalseMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFalseMsg.Location = new System.Drawing.Point(94, 66);
            this.txtFalseMsg.MaxLength = 200;
            this.txtFalseMsg.Multiline = true;
            this.txtFalseMsg.Name = "txtFalseMsg";
            this.txtFalseMsg.Size = new System.Drawing.Size(424, 41);
            this.txtFalseMsg.TabIndex = 29;
            // 
            // lblFalseMsg
            // 
            this.lblFalseMsg.AutoSize = true;
            this.lblFalseMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFalseMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFalseMsg.Location = new System.Drawing.Point(8, 69);
            this.lblFalseMsg.Name = "lblFalseMsg";
            this.lblFalseMsg.Size = new System.Drawing.Size(50, 13);
            this.lblFalseMsg.TabIndex = 28;
            this.lblFalseMsg.Text = "Message";
            this.lblFalseMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvFalseMsgID
            // 
            this.cdvFalseMsgID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFalseMsgID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFalseMsgID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFalseMsgID.BtnToolTipText = "";
            this.cdvFalseMsgID.DescText = "";
            this.cdvFalseMsgID.DisplaySubItemIndex = -1;
            this.cdvFalseMsgID.DisplayText = "";
            this.cdvFalseMsgID.Focusing = null;
            this.cdvFalseMsgID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFalseMsgID.Index = 0;
            this.cdvFalseMsgID.IsViewBtnImage = false;
            this.cdvFalseMsgID.Location = new System.Drawing.Point(94, 41);
            this.cdvFalseMsgID.MaxLength = 8;
            this.cdvFalseMsgID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFalseMsgID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFalseMsgID.Name = "cdvFalseMsgID";
            this.cdvFalseMsgID.ReadOnly = true;
            this.cdvFalseMsgID.SearchSubItemIndex = 0;
            this.cdvFalseMsgID.SelectedDescIndex = -1;
            this.cdvFalseMsgID.SelectedSubItemIndex = -1;
            this.cdvFalseMsgID.SelectionStart = 0;
            this.cdvFalseMsgID.Size = new System.Drawing.Size(141, 20);
            this.cdvFalseMsgID.SmallImageList = null;
            this.cdvFalseMsgID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFalseMsgID.TabIndex = 27;
            this.cdvFalseMsgID.TextBoxToolTipText = "";
            this.cdvFalseMsgID.TextBoxWidth = 141;
            this.cdvFalseMsgID.VisibleButton = true;
            this.cdvFalseMsgID.VisibleColumnHeader = false;
            this.cdvFalseMsgID.VisibleDescription = false;
            this.cdvFalseMsgID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFalseMsgID_SelectedItemChanged);
            this.cdvFalseMsgID.ButtonPress += new System.EventHandler(this.cdvFalseMsgID_ButtonPress);
            // 
            // lblFalseMsgId
            // 
            this.lblFalseMsgId.AutoSize = true;
            this.lblFalseMsgId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFalseMsgId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFalseMsgId.Location = new System.Drawing.Point(8, 45);
            this.lblFalseMsgId.Name = "lblFalseMsgId";
            this.lblFalseMsgId.Size = new System.Drawing.Size(64, 13);
            this.lblFalseMsgId.TabIndex = 26;
            this.lblFalseMsgId.Text = "Message ID";
            this.lblFalseMsgId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFalseMsgGroup
            // 
            this.lblFalseMsgGroup.AutoSize = true;
            this.lblFalseMsgGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFalseMsgGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFalseMsgGroup.Location = new System.Drawing.Point(8, 21);
            this.lblFalseMsgGroup.Name = "lblFalseMsgGroup";
            this.lblFalseMsgGroup.Size = new System.Drawing.Size(82, 13);
            this.lblFalseMsgGroup.TabIndex = 25;
            this.lblFalseMsgGroup.Text = "Message Group";
            this.lblFalseMsgGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpActionTrue
            // 
            this.grpActionTrue.Controls.Add(this.grpMsgCate);
            this.grpActionTrue.Controls.Add(this.chkOverride);
            this.grpActionTrue.Controls.Add(this.txtMsg);
            this.grpActionTrue.Controls.Add(this.lblMsg);
            this.grpActionTrue.Controls.Add(this.cdvMsgID);
            this.grpActionTrue.Controls.Add(this.lblMsgId);
            this.grpActionTrue.Controls.Add(this.cboMsgGrp);
            this.grpActionTrue.Controls.Add(this.lblMsgGroup);
            this.grpActionTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionTrue.Location = new System.Drawing.Point(3, 43);
            this.grpActionTrue.Name = "grpActionTrue";
            this.grpActionTrue.Size = new System.Drawing.Size(524, 112);
            this.grpActionTrue.TabIndex = 4;
            this.grpActionTrue.TabStop = false;
            this.grpActionTrue.Text = "True Action";
            // 
            // grpMsgCate
            // 
            this.grpMsgCate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMsgCate.Controls.Add(this.rbtSuccess);
            this.grpMsgCate.Controls.Add(this.rbtWarning);
            this.grpMsgCate.Controls.Add(this.rbtError);
            this.grpMsgCate.Location = new System.Drawing.Point(241, 15);
            this.grpMsgCate.Name = "grpMsgCate";
            this.grpMsgCate.Size = new System.Drawing.Size(277, 46);
            this.grpMsgCate.TabIndex = 24;
            this.grpMsgCate.TabStop = false;
            this.grpMsgCate.Text = "Message Category";
            // 
            // rbtSuccess
            // 
            this.rbtSuccess.AutoSize = true;
            this.rbtSuccess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtSuccess.Location = new System.Drawing.Point(203, 21);
            this.rbtSuccess.Name = "rbtSuccess";
            this.rbtSuccess.Size = new System.Drawing.Size(79, 17);
            this.rbtSuccess.TabIndex = 24;
            this.rbtSuccess.Text = "Success";
            this.rbtSuccess.UseVisualStyleBackColor = true;
            // 
            // rbtWarning
            // 
            this.rbtWarning.AutoSize = true;
            this.rbtWarning.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtWarning.Location = new System.Drawing.Point(128, 21);
            this.rbtWarning.Name = "rbtWarning";
            this.rbtWarning.Size = new System.Drawing.Size(74, 17);
            this.rbtWarning.TabIndex = 23;
            this.rbtWarning.Text = "Warning";
            this.rbtWarning.UseVisualStyleBackColor = true;
            // 
            // rbtError
            // 
            this.rbtError.AutoSize = true;
            this.rbtError.Checked = true;
            this.rbtError.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtError.Location = new System.Drawing.Point(4, 21);
            this.rbtError.Name = "rbtError";
            this.rbtError.Size = new System.Drawing.Size(133, 17);
            this.rbtError.TabIndex = 22;
            this.rbtError.TabStop = true;
            this.rbtError.Text = "Error and Rollback";
            this.rbtError.UseVisualStyleBackColor = true;
            // 
            // chkOverride
            // 
            this.chkOverride.AutoSize = true;
            this.chkOverride.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOverride.Location = new System.Drawing.Point(9, 87);
            this.chkOverride.Name = "chkOverride";
            this.chkOverride.Size = new System.Drawing.Size(77, 17);
            this.chkOverride.TabIndex = 18;
            this.chkOverride.Text = "Override";
            this.chkOverride.UseVisualStyleBackColor = true;
            this.chkOverride.CheckedChanged += new System.EventHandler(this.chkOverride_CheckedChanged);
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.Location = new System.Drawing.Point(94, 65);
            this.txtMsg.MaxLength = 200;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(424, 41);
            this.txtMsg.TabIndex = 17;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(8, 69);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(50, 13);
            this.lblMsg.TabIndex = 16;
            this.lblMsg.Text = "Message";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvMsgID.Location = new System.Drawing.Point(94, 40);
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
            this.cdvMsgID.TabIndex = 15;
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
            this.lblMsgId.Location = new System.Drawing.Point(8, 44);
            this.lblMsgId.Name = "lblMsgId";
            this.lblMsgId.Size = new System.Drawing.Size(64, 13);
            this.lblMsgId.TabIndex = 14;
            this.lblMsgId.Text = "Message ID";
            this.lblMsgId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMsgGrp
            // 
            this.cboMsgGrp.DropDownWidth = 100;
            this.cboMsgGrp.Location = new System.Drawing.Point(94, 15);
            this.cboMsgGrp.MaxDropDownItems = 30;
            this.cboMsgGrp.MaxLength = 20;
            this.cboMsgGrp.Name = "cboMsgGrp";
            this.cboMsgGrp.Size = new System.Drawing.Size(141, 20);
            this.cboMsgGrp.TabIndex = 13;
            this.cboMsgGrp.SelectedIndexChanged += new System.EventHandler(this.cboMsgGrp_SelectedIndexChanged);
            this.cboMsgGrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboActionType_KeyPress);
            // 
            // lblMsgGroup
            // 
            this.lblMsgGroup.AutoSize = true;
            this.lblMsgGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsgGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgGroup.Location = new System.Drawing.Point(8, 20);
            this.lblMsgGroup.Name = "lblMsgGroup";
            this.lblMsgGroup.Size = new System.Drawing.Size(82, 13);
            this.lblMsgGroup.TabIndex = 12;
            this.lblMsgGroup.Text = "Message Group";
            this.lblMsgGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlActionValueTop
            // 
            this.pnlActionValueTop.Controls.Add(this.cboActionType);
            this.pnlActionValueTop.Controls.Add(this.lblActionType);
            this.pnlActionValueTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionValueTop.Location = new System.Drawing.Point(3, 17);
            this.pnlActionValueTop.Name = "pnlActionValueTop";
            this.pnlActionValueTop.Size = new System.Drawing.Size(524, 26);
            this.pnlActionValueTop.TabIndex = 3;
            // 
            // cboActionType
            // 
            this.cboActionType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboActionType.FormattingEnabled = true;
            this.cboActionType.Items.AddRange(new object[] {
            "Just positive condition",
            "Action with True or False"});
            this.cboActionType.Location = new System.Drawing.Point(94, 2);
            this.cboActionType.Name = "cboActionType";
            this.cboActionType.Size = new System.Drawing.Size(250, 20);
            this.cboActionType.TabIndex = 1;
            this.cboActionType.SelectedIndexChanged += new System.EventHandler(this.cboActionType_SelectedIndexChanged);
            this.cboActionType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboActionType_KeyPress);
            // 
            // lblActionType
            // 
            this.lblActionType.AutoSize = true;
            this.lblActionType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActionType.Location = new System.Drawing.Point(8, 6);
            this.lblActionType.Name = "lblActionType";
            this.lblActionType.Size = new System.Drawing.Size(73, 12);
            this.lblActionType.TabIndex = 0;
            this.lblActionType.Text = "Action Type";
            // 
            // udcFutureActionError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcFutureActionError";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionFalse.ResumeLayout(false);
            this.grpActionFalse.PerformLayout();
            this.grpFalseMsgCate.ResumeLayout(false);
            this.grpFalseMsgCate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFalseMsgID)).EndInit();
            this.grpActionTrue.ResumeLayout(false);
            this.grpActionTrue.PerformLayout();
            this.grpMsgCate.ResumeLayout(false);
            this.grpMsgCate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMsgID)).EndInit();
            this.pnlActionValueTop.ResumeLayout(false);
            this.pnlActionValueTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpActionFalse;
        private System.Windows.Forms.GroupBox grpActionTrue;
        private System.Windows.Forms.Panel pnlActionValueTop;
        private System.Windows.Forms.ComboBox cboActionType;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.Label lblMsgGroup;
        private System.Windows.Forms.ComboBox cboMsgGrp;
        private System.Windows.Forms.Label lblMsgId;
        private UI.Controls.MCCodeView.MCCodeView cdvMsgID;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.GroupBox grpMsgCate;
        private System.Windows.Forms.RadioButton rbtSuccess;
        private System.Windows.Forms.RadioButton rbtWarning;
        private System.Windows.Forms.RadioButton rbtError;
        private System.Windows.Forms.CheckBox chkOverride;
        private System.Windows.Forms.ComboBox cboFalseMsgGrp;
        private System.Windows.Forms.GroupBox grpFalseMsgCate;
        private System.Windows.Forms.RadioButton rbtFalseSuccess;
        private System.Windows.Forms.RadioButton rbtFalseWarning;
        private System.Windows.Forms.RadioButton rbtFalseError;
        private System.Windows.Forms.CheckBox chkFalseOverride;
        private System.Windows.Forms.TextBox txtFalseMsg;
        private System.Windows.Forms.Label lblFalseMsg;
        private UI.Controls.MCCodeView.MCCodeView cdvFalseMsgID;
        private System.Windows.Forms.Label lblFalseMsgId;
        private System.Windows.Forms.Label lblFalseMsgGroup;
    }
}
