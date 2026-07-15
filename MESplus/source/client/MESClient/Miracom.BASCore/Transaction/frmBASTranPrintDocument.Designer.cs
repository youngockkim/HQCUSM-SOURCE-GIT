namespace Miracom.BASCore.Transaction
{
    partial class frmBASTranPrintDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASTranPrintDocument));
            this.chkManual = new System.Windows.Forms.CheckBox();
            this.cdvManualFormat = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkHistory = new System.Windows.Forms.CheckBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManualFormat)).BeginInit();
            this.SuspendLayout();
            // 
            // udcLotInfor
            // 
            this.udcLotInfor.Location = new System.Drawing.Point(2, 2);
            this.udcLotInfor.Size = new System.Drawing.Size(1252, 641);
            // 
            // lblLotID
            // 
            this.lblLotID.Location = new System.Drawing.Point(15, 16);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.Location = new System.Drawing.Point(15, 40);
            this.lblLotDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            // 
            // txtLotID
            // 
            this.txtLotID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLotID.Location = new System.Drawing.Point(120, 14);
            this.txtLotID.Margin = new System.Windows.Forms.Padding(5);
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Location = new System.Drawing.Point(120, 38);
            this.txtLotDesc.Margin = new System.Windows.Forms.Padding(5);
            this.txtLotDesc.Size = new System.Drawing.Size(2662, 20);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTranTop.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pnlTranTop.Size = new System.Drawing.Size(1256, 67);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 67);
            this.pnlTranCenter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTranCenter.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.pnlTranCenter.Size = new System.Drawing.Size(1256, 643);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.chkHistory);
            this.grpTranTop.Controls.Add(this.chkManual);
            this.grpTranTop.Controls.Add(this.cdvManualFormat);
            this.grpTranTop.Location = new System.Drawing.Point(2, 0);
            this.grpTranTop.Margin = new System.Windows.Forms.Padding(2);
            this.grpTranTop.Padding = new System.Windows.Forms.Padding(2);
            this.grpTranTop.Size = new System.Drawing.Size(1252, 67);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.cdvManualFormat, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.chkManual, 0);
            this.grpTranTop.Controls.SetChildIndex(this.chkHistory, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotID, 0);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(1065, 6);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(2);
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1157, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 710);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBottom.Size = new System.Drawing.Size(1256, 40);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCenter.Size = new System.Drawing.Size(1256, 710);
            // 
            // pnlTop
            // 
            this.pnlTop.Margin = new System.Windows.Forms.Padding(7);
            this.pnlTop.Padding = new System.Windows.Forms.Padding(5);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(5, 5);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFormTitle.Size = new System.Drawing.Size(732, 0);
            this.lblFormTitle.Text = "TranForm32";
            // 
            // chkManual
            // 
            this.chkManual.AutoSize = true;
            this.chkManual.Location = new System.Drawing.Point(415, 16);
            this.chkManual.Margin = new System.Windows.Forms.Padding(2);
            this.chkManual.Name = "chkManual";
            this.chkManual.Size = new System.Drawing.Size(96, 17);
            this.chkManual.TabIndex = 4;
            this.chkManual.Text = "Manual Format";
            this.chkManual.UseVisualStyleBackColor = true;
            this.chkManual.Click += new System.EventHandler(this.chkManual_Click);
            // 
            // cdvManualFormat
            // 
            this.cdvManualFormat.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvManualFormat.BorderHotColor = System.Drawing.Color.Black;
            this.cdvManualFormat.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvManualFormat.BtnToolTipText = "";
            this.cdvManualFormat.DescText = "";
            this.cdvManualFormat.DisplaySubItemIndex = -1;
            this.cdvManualFormat.DisplayText = "";
            this.cdvManualFormat.Focusing = null;
            this.cdvManualFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvManualFormat.Index = 0;
            this.cdvManualFormat.IsViewBtnImage = false;
            this.cdvManualFormat.Location = new System.Drawing.Point(516, 14);
            this.cdvManualFormat.MaxLength = 30;
            this.cdvManualFormat.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvManualFormat.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvManualFormat.Name = "cdvManualFormat";
            this.cdvManualFormat.ReadOnly = false;
            this.cdvManualFormat.SearchSubItemIndex = 0;
            this.cdvManualFormat.SelectedDescIndex = -1;
            this.cdvManualFormat.SelectedSubItemIndex = -1;
            this.cdvManualFormat.SelectionStart = 0;
            this.cdvManualFormat.Size = new System.Drawing.Size(200, 20);
            this.cdvManualFormat.SmallImageList = null;
            this.cdvManualFormat.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvManualFormat.TabIndex = 8;
            this.cdvManualFormat.TextBoxToolTipText = "";
            this.cdvManualFormat.TextBoxWidth = 200;
            this.cdvManualFormat.VisibleButton = true;
            this.cdvManualFormat.VisibleColumnHeader = false;
            this.cdvManualFormat.VisibleDescription = false;
            this.cdvManualFormat.ButtonPress += new System.EventHandler(this.cdvManualFormat_ButtonPress);
            // 
            // chkHistory
            // 
            this.chkHistory.AutoSize = true;
            this.chkHistory.Location = new System.Drawing.Point(327, 16);
            this.chkHistory.Margin = new System.Windows.Forms.Padding(2);
            this.chkHistory.Name = "chkHistory";
            this.chkHistory.Size = new System.Drawing.Size(84, 17);
            this.chkHistory.TabIndex = 11;
            this.chkHistory.Text = "View History";
            this.chkHistory.UseVisualStyleBackColor = true;
            this.chkHistory.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(972, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 17;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(38, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 18;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmBASTranPrintDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 750);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1207, 726);
            this.Name = "frmBASTranPrintDocument";
            this.Text = "Print Document";
            this.Activated += new System.EventHandler(this.frmBASTranPrintDocument_Activated);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvManualFormat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public UI.Controls.MCCodeView.MCCodeView cdvManualFormat;
        public System.Windows.Forms.CheckBox chkManual;
        public System.Windows.Forms.CheckBox chkHistory;
        private System.Windows.Forms.Button btnView;
        protected System.Windows.Forms.Button btnExcel;
    }
}