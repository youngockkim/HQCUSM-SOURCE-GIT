namespace Miracom.MESCore
{
    partial class frmConfirmMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmMessageBox));
            this.pnlDetailMsg = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lisDetailMsg = new Miracom.UI.Controls.MCListView.MCListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlMsgTop = new System.Windows.Forms.Panel();
            this.pnlRetryCancel = new System.Windows.Forms.Panel();
            this.btnRetryCancelCancel = new System.Windows.Forms.Button();
            this.btnRetryCancelRetry = new System.Windows.Forms.Button();
            this.pnlAbortRetryIgnore = new System.Windows.Forms.Panel();
            this.btnAbortRetryIgnoreIgnore = new System.Windows.Forms.Button();
            this.btnAbortRetryIgnoreRetry = new System.Windows.Forms.Button();
            this.btnAbortRetryIgnoreAbort = new System.Windows.Forms.Button();
            this.pnlOK = new System.Windows.Forms.Panel();
            this.btnOKOK = new System.Windows.Forms.Button();
            this.pnlOKCancel = new System.Windows.Forms.Panel();
            this.btnOKCancelCancel = new System.Windows.Forms.Button();
            this.btnOKCancelOK = new System.Windows.Forms.Button();
            this.pnlYesNoCancel = new System.Windows.Forms.Panel();
            this.btnYesNoCancelCancel = new System.Windows.Forms.Button();
            this.btnYesNoCancelNo = new System.Windows.Forms.Button();
            this.btnYesNoCancelYes = new System.Windows.Forms.Button();
            this.pnlYesNo = new System.Windows.Forms.Panel();
            this.btnYesNoNo = new System.Windows.Forms.Button();
            this.btnYesNoYes = new System.Windows.Forms.Button();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnSimple = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.cdvReason = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.btnWDetail = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlDetailMsg.SuspendLayout();
            this.pnlMsgTop.SuspendLayout();
            this.pnlRetryCancel.SuspendLayout();
            this.pnlAbortRetryIgnore.SuspendLayout();
            this.pnlOK.SuspendLayout();
            this.pnlOKCancel.SuspendLayout();
            this.pnlYesNoCancel.SuspendLayout();
            this.pnlYesNo.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReason)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetailMsg
            // 
            this.pnlDetailMsg.Controls.Add(this.btnExcel);
            this.pnlDetailMsg.Controls.Add(this.lisDetailMsg);
            this.pnlDetailMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailMsg.Location = new System.Drawing.Point(0, 98);
            this.pnlDetailMsg.Name = "pnlDetailMsg";
            this.pnlDetailMsg.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDetailMsg.Size = new System.Drawing.Size(522, 127);
            this.pnlDetailMsg.TabIndex = 3;
            this.pnlDetailMsg.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(429, 100);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lisDetailMsg
            // 
            this.lisDetailMsg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colValue});
            this.lisDetailMsg.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisDetailMsg.EnableSort = true;
            this.lisDetailMsg.EnableSortIcon = true;
            this.lisDetailMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisDetailMsg.FullRowSelect = true;
            this.lisDetailMsg.Location = new System.Drawing.Point(3, 3);
            this.lisDetailMsg.MultiSelect = false;
            this.lisDetailMsg.Name = "lisDetailMsg";
            this.lisDetailMsg.Size = new System.Drawing.Size(421, 121);
            this.lisDetailMsg.TabIndex = 2;
            this.lisDetailMsg.UseCompatibleStateImageBehavior = false;
            this.lisDetailMsg.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 200;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 200;
            // 
            // pnlMsgTop
            // 
            this.pnlMsgTop.Controls.Add(this.pnlRetryCancel);
            this.pnlMsgTop.Controls.Add(this.pnlAbortRetryIgnore);
            this.pnlMsgTop.Controls.Add(this.pnlOK);
            this.pnlMsgTop.Controls.Add(this.pnlOKCancel);
            this.pnlMsgTop.Controls.Add(this.pnlYesNoCancel);
            this.pnlMsgTop.Controls.Add(this.pnlYesNo);
            this.pnlMsgTop.Controls.Add(this.pnlMessage);
            this.pnlMsgTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMsgTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMsgTop.Name = "pnlMsgTop";
            this.pnlMsgTop.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pnlMsgTop.Size = new System.Drawing.Size(522, 98);
            this.pnlMsgTop.TabIndex = 2;
            // 
            // pnlRetryCancel
            // 
            this.pnlRetryCancel.Controls.Add(this.btnRetryCancelCancel);
            this.pnlRetryCancel.Controls.Add(this.btnRetryCancelRetry);
            this.pnlRetryCancel.Location = new System.Drawing.Point(620, 1);
            this.pnlRetryCancel.Name = "pnlRetryCancel";
            this.pnlRetryCancel.Size = new System.Drawing.Size(98, 96);
            this.pnlRetryCancel.TabIndex = 3;
            // 
            // btnRetryCancelCancel
            // 
            this.btnRetryCancelCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRetryCancelCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRetryCancelCancel.Location = new System.Drawing.Point(5, 35);
            this.btnRetryCancelCancel.Name = "btnRetryCancelCancel";
            this.btnRetryCancelCancel.Size = new System.Drawing.Size(88, 26);
            this.btnRetryCancelCancel.TabIndex = 1;
            this.btnRetryCancelCancel.Text = "Cancel";
            this.btnRetryCancelCancel.Click += new System.EventHandler(this.btnRetryCancelCancel_Click);
            // 
            // btnRetryCancelRetry
            // 
            this.btnRetryCancelRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetryCancelRetry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRetryCancelRetry.Location = new System.Drawing.Point(5, 5);
            this.btnRetryCancelRetry.Name = "btnRetryCancelRetry";
            this.btnRetryCancelRetry.Size = new System.Drawing.Size(88, 26);
            this.btnRetryCancelRetry.TabIndex = 0;
            this.btnRetryCancelRetry.Text = "Retry";
            this.btnRetryCancelRetry.Click += new System.EventHandler(this.btnRetryCancelRetry_Click);
            // 
            // pnlAbortRetryIgnore
            // 
            this.pnlAbortRetryIgnore.Controls.Add(this.btnAbortRetryIgnoreIgnore);
            this.pnlAbortRetryIgnore.Controls.Add(this.btnAbortRetryIgnoreRetry);
            this.pnlAbortRetryIgnore.Controls.Add(this.btnAbortRetryIgnoreAbort);
            this.pnlAbortRetryIgnore.Location = new System.Drawing.Point(718, 1);
            this.pnlAbortRetryIgnore.Name = "pnlAbortRetryIgnore";
            this.pnlAbortRetryIgnore.Size = new System.Drawing.Size(98, 96);
            this.pnlAbortRetryIgnore.TabIndex = 4;
            // 
            // btnAbortRetryIgnoreIgnore
            // 
            this.btnAbortRetryIgnoreIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnAbortRetryIgnoreIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAbortRetryIgnoreIgnore.Location = new System.Drawing.Point(5, 65);
            this.btnAbortRetryIgnoreIgnore.Name = "btnAbortRetryIgnoreIgnore";
            this.btnAbortRetryIgnoreIgnore.Size = new System.Drawing.Size(88, 26);
            this.btnAbortRetryIgnoreIgnore.TabIndex = 2;
            this.btnAbortRetryIgnoreIgnore.Text = "Ignore";
            this.btnAbortRetryIgnoreIgnore.Click += new System.EventHandler(this.btnAbortRetryIgnoreIgnore_Click);
            // 
            // btnAbortRetryIgnoreRetry
            // 
            this.btnAbortRetryIgnoreRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnAbortRetryIgnoreRetry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAbortRetryIgnoreRetry.Location = new System.Drawing.Point(5, 35);
            this.btnAbortRetryIgnoreRetry.Name = "btnAbortRetryIgnoreRetry";
            this.btnAbortRetryIgnoreRetry.Size = new System.Drawing.Size(88, 26);
            this.btnAbortRetryIgnoreRetry.TabIndex = 1;
            this.btnAbortRetryIgnoreRetry.Text = "Retry";
            this.btnAbortRetryIgnoreRetry.Click += new System.EventHandler(this.btnAbortRetryIgnoreRetry_Click);
            // 
            // btnAbortRetryIgnoreAbort
            // 
            this.btnAbortRetryIgnoreAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbortRetryIgnoreAbort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAbortRetryIgnoreAbort.Location = new System.Drawing.Point(5, 5);
            this.btnAbortRetryIgnoreAbort.Name = "btnAbortRetryIgnoreAbort";
            this.btnAbortRetryIgnoreAbort.Size = new System.Drawing.Size(88, 26);
            this.btnAbortRetryIgnoreAbort.TabIndex = 0;
            this.btnAbortRetryIgnoreAbort.Text = "Abort";
            this.btnAbortRetryIgnoreAbort.Click += new System.EventHandler(this.btnAbortRetryIgnoreAbort_Click);
            // 
            // pnlOK
            // 
            this.pnlOK.Controls.Add(this.btnOKOK);
            this.pnlOK.Location = new System.Drawing.Point(914, 1);
            this.pnlOK.Name = "pnlOK";
            this.pnlOK.Size = new System.Drawing.Size(98, 96);
            this.pnlOK.TabIndex = 6;
            // 
            // btnOKOK
            // 
            this.btnOKOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOKOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKOK.Location = new System.Drawing.Point(5, 5);
            this.btnOKOK.Name = "btnOKOK";
            this.btnOKOK.Size = new System.Drawing.Size(88, 26);
            this.btnOKOK.TabIndex = 0;
            this.btnOKOK.Text = "OK";
            this.btnOKOK.Click += new System.EventHandler(this.btnOKOK_Click);
            // 
            // pnlOKCancel
            // 
            this.pnlOKCancel.Controls.Add(this.btnOKCancelCancel);
            this.pnlOKCancel.Controls.Add(this.btnOKCancelOK);
            this.pnlOKCancel.Location = new System.Drawing.Point(816, 1);
            this.pnlOKCancel.Name = "pnlOKCancel";
            this.pnlOKCancel.Size = new System.Drawing.Size(98, 96);
            this.pnlOKCancel.TabIndex = 5;
            // 
            // btnOKCancelCancel
            // 
            this.btnOKCancelCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOKCancelCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKCancelCancel.Location = new System.Drawing.Point(5, 35);
            this.btnOKCancelCancel.Name = "btnOKCancelCancel";
            this.btnOKCancelCancel.Size = new System.Drawing.Size(88, 26);
            this.btnOKCancelCancel.TabIndex = 1;
            this.btnOKCancelCancel.Text = "Cancel";
            this.btnOKCancelCancel.Click += new System.EventHandler(this.btnOKCancelCancel_Click);
            // 
            // btnOKCancelOK
            // 
            this.btnOKCancelOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOKCancelOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKCancelOK.Location = new System.Drawing.Point(5, 5);
            this.btnOKCancelOK.Name = "btnOKCancelOK";
            this.btnOKCancelOK.Size = new System.Drawing.Size(88, 26);
            this.btnOKCancelOK.TabIndex = 0;
            this.btnOKCancelOK.Text = "OK";
            this.btnOKCancelOK.Click += new System.EventHandler(this.btnOKCancelOK_Click);
            // 
            // pnlYesNoCancel
            // 
            this.pnlYesNoCancel.Controls.Add(this.btnYesNoCancelCancel);
            this.pnlYesNoCancel.Controls.Add(this.btnYesNoCancelNo);
            this.pnlYesNoCancel.Controls.Add(this.btnYesNoCancelYes);
            this.pnlYesNoCancel.Location = new System.Drawing.Point(522, 1);
            this.pnlYesNoCancel.Name = "pnlYesNoCancel";
            this.pnlYesNoCancel.Size = new System.Drawing.Size(98, 96);
            this.pnlYesNoCancel.TabIndex = 2;
            // 
            // btnYesNoCancelCancel
            // 
            this.btnYesNoCancelCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnYesNoCancelCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoCancelCancel.Location = new System.Drawing.Point(5, 65);
            this.btnYesNoCancelCancel.Name = "btnYesNoCancelCancel";
            this.btnYesNoCancelCancel.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoCancelCancel.TabIndex = 0;
            this.btnYesNoCancelCancel.Text = "Cancel";
            this.btnYesNoCancelCancel.Click += new System.EventHandler(this.btnYesNoCancelCancel_Click);
            // 
            // btnYesNoCancelNo
            // 
            this.btnYesNoCancelNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnYesNoCancelNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoCancelNo.Location = new System.Drawing.Point(5, 35);
            this.btnYesNoCancelNo.Name = "btnYesNoCancelNo";
            this.btnYesNoCancelNo.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoCancelNo.TabIndex = 2;
            this.btnYesNoCancelNo.Text = "No";
            this.btnYesNoCancelNo.Click += new System.EventHandler(this.btnYesNoCancelNo_Click);
            // 
            // btnYesNoCancelYes
            // 
            this.btnYesNoCancelYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYesNoCancelYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoCancelYes.Location = new System.Drawing.Point(5, 5);
            this.btnYesNoCancelYes.Name = "btnYesNoCancelYes";
            this.btnYesNoCancelYes.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoCancelYes.TabIndex = 1;
            this.btnYesNoCancelYes.Text = "Yes";
            this.btnYesNoCancelYes.Click += new System.EventHandler(this.btnYesNoCancelYes_Click);
            // 
            // pnlYesNo
            // 
            this.pnlYesNo.Controls.Add(this.btnYesNoNo);
            this.pnlYesNo.Controls.Add(this.btnYesNoYes);
            this.pnlYesNo.Location = new System.Drawing.Point(424, 1);
            this.pnlYesNo.Name = "pnlYesNo";
            this.pnlYesNo.Size = new System.Drawing.Size(98, 96);
            this.pnlYesNo.TabIndex = 0;
            // 
            // btnYesNoNo
            // 
            this.btnYesNoNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnYesNoNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoNo.Location = new System.Drawing.Point(5, 35);
            this.btnYesNoNo.Name = "btnYesNoNo";
            this.btnYesNoNo.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoNo.TabIndex = 1;
            this.btnYesNoNo.Text = "No";
            this.btnYesNoNo.Click += new System.EventHandler(this.btnYesNoNo_Click);
            // 
            // btnYesNoYes
            // 
            this.btnYesNoYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYesNoYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoYes.Location = new System.Drawing.Point(5, 5);
            this.btnYesNoYes.Name = "btnYesNoYes";
            this.btnYesNoYes.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoYes.TabIndex = 0;
            this.btnYesNoYes.Text = "Yes";
            this.btnYesNoYes.Click += new System.EventHandler(this.btnYesNoYes_Click);
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.btnDetail);
            this.pnlMessage.Controls.Add(this.btnSimple);
            this.pnlMessage.Controls.Add(this.btnCopy);
            this.pnlMessage.Controls.Add(this.grpMessage);
            this.pnlMessage.Controls.Add(this.Label1);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMessage.Location = new System.Drawing.Point(0, 3);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMessage.Size = new System.Drawing.Size(424, 92);
            this.pnlMessage.TabIndex = 1;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.Location = new System.Drawing.Point(381, 62);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(16, 22);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.TabStop = false;
            this.btnDetail.Tag = "VIEW";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnSimple
            // 
            this.btnSimple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimple.Enabled = false;
            this.btnSimple.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSimple.Image = ((System.Drawing.Image)(resources.GetObject("btnSimple.Image")));
            this.btnSimple.Location = new System.Drawing.Point(381, 62);
            this.btnSimple.Name = "btnSimple";
            this.btnSimple.Size = new System.Drawing.Size(16, 22);
            this.btnSimple.TabIndex = 0;
            this.btnSimple.TabStop = false;
            this.btnSimple.Tag = "VIEW";
            this.btnSimple.Visible = false;
            this.btnSimple.Click += new System.EventHandler(this.btnSimple_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.BackColor = System.Drawing.SystemColors.Control;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(398, 62);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(21, 22);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.TabStop = false;
            this.btnCopy.Tag = "";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // grpMessage
            // 
            this.grpMessage.Controls.Add(this.cdvReason);
            this.grpMessage.Controls.Add(this.txtReason);
            this.grpMessage.Controls.Add(this.lblReason);
            this.grpMessage.Controls.Add(this.btnWDetail);
            this.grpMessage.Controls.Add(this.lblMessage);
            this.grpMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMessage.Location = new System.Drawing.Point(3, -6);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(421, 96);
            this.grpMessage.TabIndex = 0;
            this.grpMessage.TabStop = false;
            // 
            // cdvReason
            // 
            this.cdvReason.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReason.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReason.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvReason.BtnToolTipText = "";
            this.cdvReason.DescText = "";
            this.cdvReason.DisplaySubItemIndex = -1;
            this.cdvReason.DisplayText = "";
            this.cdvReason.Focusing = null;
            this.cdvReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReason.Index = 0;
            this.cdvReason.IsViewBtnImage = false;
            this.cdvReason.Location = new System.Drawing.Point(79, 69);
            this.cdvReason.MaxLength = 32767;
            this.cdvReason.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReason.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReason.Name = "cdvReason";
            this.cdvReason.ReadOnly = false;
            this.cdvReason.SearchSubItemIndex = 0;
            this.cdvReason.SelectedDescIndex = -1;
            this.cdvReason.SelectedSubItemIndex = -1;
            this.cdvReason.SelectionStart = 0;
            this.cdvReason.Size = new System.Drawing.Size(276, 20);
            this.cdvReason.SmallImageList = null;
            this.cdvReason.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvReason.TabIndex = 5;
            this.cdvReason.TextBoxToolTipText = "";
            this.cdvReason.TextBoxWidth = 276;
            this.cdvReason.Visible = false;
            this.cdvReason.VisibleButton = true;
            this.cdvReason.VisibleColumnHeader = false;
            this.cdvReason.VisibleDescription = false;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(79, 69);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(276, 20);
            this.txtReason.TabIndex = 4;
            this.txtReason.Visible = false;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReason.Location = new System.Drawing.Point(12, 73);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(44, 13);
            this.lblReason.TabIndex = 3;
            this.lblReason.Text = "Reason";
            this.lblReason.Visible = false;
            // 
            // btnWDetail
            // 
            this.btnWDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWDetail.Location = new System.Drawing.Point(361, 68);
            this.btnWDetail.Name = "btnWDetail";
            this.btnWDetail.Size = new System.Drawing.Size(16, 22);
            this.btnWDetail.TabIndex = 2;
            this.btnWDetail.TabStop = false;
            this.btnWDetail.Tag = "VIEW";
            this.btnWDetail.Text = "W";
            this.btnWDetail.Visible = false;
            this.btnWDetail.Click += new System.EventHandler(this.btnWDetail_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(3, 16);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(415, 77);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(3, 3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(418, 86);
            this.Label1.TabIndex = 1;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConfirmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 225);
            this.Controls.Add(this.pnlDetailMsg);
            this.Controls.Add(this.pnlMsgTop);
            this.Name = "frmConfirmMessageBox";
            this.Text = "MESplus";
            this.Load += new System.EventHandler(this.frmConfirmMessageBox_Load);
            this.pnlDetailMsg.ResumeLayout(false);
            this.pnlMsgTop.ResumeLayout(false);
            this.pnlRetryCancel.ResumeLayout(false);
            this.pnlAbortRetryIgnore.ResumeLayout(false);
            this.pnlOK.ResumeLayout(false);
            this.pnlOKCancel.ResumeLayout(false);
            this.pnlYesNoCancel.ResumeLayout(false);
            this.pnlYesNo.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.grpMessage.ResumeLayout(false);
            this.grpMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReason)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetailMsg;
        protected System.Windows.Forms.Button btnExcel;
        private UI.Controls.MCListView.MCListView lisDetailMsg;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Panel pnlMsgTop;
        private System.Windows.Forms.Panel pnlRetryCancel;
        private System.Windows.Forms.Button btnRetryCancelCancel;
        private System.Windows.Forms.Button btnRetryCancelRetry;
        private System.Windows.Forms.Panel pnlAbortRetryIgnore;
        private System.Windows.Forms.Button btnAbortRetryIgnoreIgnore;
        private System.Windows.Forms.Button btnAbortRetryIgnoreRetry;
        private System.Windows.Forms.Button btnAbortRetryIgnoreAbort;
        private System.Windows.Forms.Panel pnlOK;
        private System.Windows.Forms.Button btnOKOK;
        private System.Windows.Forms.Panel pnlOKCancel;
        private System.Windows.Forms.Button btnOKCancelCancel;
        private System.Windows.Forms.Button btnOKCancelOK;
        private System.Windows.Forms.Panel pnlYesNoCancel;
        private System.Windows.Forms.Button btnYesNoCancelCancel;
        private System.Windows.Forms.Button btnYesNoCancelNo;
        private System.Windows.Forms.Button btnYesNoCancelYes;
        private System.Windows.Forms.Panel pnlYesNo;
        private System.Windows.Forms.Button btnYesNoNo;
        private System.Windows.Forms.Button btnYesNoYes;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnSimple;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.Button btnWDetail;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label Label1;
        private UI.Controls.MCCodeView.MCCodeView cdvReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
    }
}