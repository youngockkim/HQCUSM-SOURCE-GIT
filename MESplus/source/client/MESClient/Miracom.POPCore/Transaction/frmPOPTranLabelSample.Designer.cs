namespace Miracom.POPCore
{
    partial class frmPOPTranLabelSample
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
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblStartLotID = new System.Windows.Forms.Label();
            this.udcScreen = new Miracom.MESCore.Controls.udcFlexibleScreen();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.cdvPrinter = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnProcess_1 = new System.Windows.Forms.Button();
            this.udcScreenLoss = new Miracom.MESCore.Controls.udcFlexibleScreen();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrinter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(1558, 7);
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(1234, 71);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblStartLotID);
            this.grpOption.Size = new System.Drawing.Size(1234, 71);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.udcScreen);
            this.pnlViewMid.Controls.Add(this.udcScreenLoss);
            this.pnlViewMid.Size = new System.Drawing.Size(1234, 548);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1649, 7);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnProcess_1);
            this.pnlBottom.Controls.Add(this.lblPrinter);
            this.pnlBottom.Controls.Add(this.cdvPrinter);
            this.pnlBottom.Location = new System.Drawing.Point(0, 619);
            this.pnlBottom.Size = new System.Drawing.Size(1234, 40);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.cdvPrinter, 0);
            this.pnlBottom.Controls.SetChildIndex(this.lblPrinter, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess_1, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(1234, 619);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // txtLotID
            // 
            this.txtLotID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLotID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLotID.Location = new System.Drawing.Point(131, 19);
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(412, 30);
            this.txtLotID.TabIndex = 125;
            // 
            // lblStartLotID
            // 
            this.lblStartLotID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStartLotID.AutoSize = true;
            this.lblStartLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblStartLotID.ForeColor = System.Drawing.Color.Navy;
            this.lblStartLotID.Location = new System.Drawing.Point(27, 27);
            this.lblStartLotID.Name = "lblStartLotID";
            this.lblStartLotID.Size = new System.Drawing.Size(72, 18);
            this.lblStartLotID.TabIndex = 124;
            this.lblStartLotID.Text = "Sheet ID";
            // 
            // udcScreen
            // 
            this.udcScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcScreen.Location = new System.Drawing.Point(0, 0);
            this.udcScreen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.udcScreen.Name = "udcScreen";
            this.udcScreen.ScreenAutoStretch = false;
            this.udcScreen.ScreenID = null;
            this.udcScreen.ScreenLock = false;
            this.udcScreen.ScreenLockBackColor = System.Drawing.Color.Empty;
            this.udcScreen.Size = new System.Drawing.Size(1234, 548);
            this.udcScreen.TabIndex = 2;
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinter.Location = new System.Drawing.Point(54, 11);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(76, 13);
            this.lblPrinter.TabIndex = 172;
            this.lblPrinter.Text = "프린터 선택";
            // 
            // cdvPrinter
            // 
            this.cdvPrinter.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrinter.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrinter.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrinter.BtnToolTipText = "";
            this.cdvPrinter.ButtonWidth = 20;
            this.cdvPrinter.DescText = "";
            this.cdvPrinter.DisplaySubItemIndex = 0;
            this.cdvPrinter.DisplayText = "";
            this.cdvPrinter.Focusing = null;
            this.cdvPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrinter.Index = 0;
            this.cdvPrinter.IsViewBtnImage = false;
            this.cdvPrinter.Location = new System.Drawing.Point(143, 8);
            this.cdvPrinter.MaxLength = 32767;
            this.cdvPrinter.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrinter.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrinter.Name = "cdvPrinter";
            this.cdvPrinter.ReadOnly = false;
            this.cdvPrinter.SameWidthHeightOfButton = false;
            this.cdvPrinter.SearchSubItemIndex = 0;
            this.cdvPrinter.SelectedDescIndex = -1;
            this.cdvPrinter.SelectedSubItemIndex = -1;
            this.cdvPrinter.SelectionStart = 0;
            this.cdvPrinter.Size = new System.Drawing.Size(283, 21);
            this.cdvPrinter.SmallImageList = null;
            this.cdvPrinter.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrinter.TabIndex = 173;
            this.cdvPrinter.TextBoxToolTipText = "";
            this.cdvPrinter.TextBoxWidth = 283;
            this.cdvPrinter.VisibleButton = true;
            this.cdvPrinter.VisibleColumnHeader = false;
            this.cdvPrinter.VisibleDescription = false;
            this.cdvPrinter.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPrinter_SelectedItemChanged);
            this.cdvPrinter.ButtonPress += new System.EventHandler(this.cdvPrinter_ButtonPress);
            // 
            // btnProcess_1
            // 
            this.btnProcess_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess_1.Location = new System.Drawing.Point(1956, 7);
            this.btnProcess_1.Name = "btnProcess_1";
            this.btnProcess_1.Size = new System.Drawing.Size(88, 26);
            this.btnProcess_1.TabIndex = 174;
            this.btnProcess_1.Text = "출력";
            this.btnProcess_1.UseVisualStyleBackColor = true;
            this.btnProcess_1.Click += new System.EventHandler(this.btnProcess_1_Click);
            // 
            // udcScreenLoss
            // 
            this.udcScreenLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcScreenLoss.Location = new System.Drawing.Point(0, 0);
            this.udcScreenLoss.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.udcScreenLoss.Name = "udcScreenLoss";
            this.udcScreenLoss.ScreenAutoStretch = false;
            this.udcScreenLoss.ScreenID = null;
            this.udcScreenLoss.ScreenLock = false;
            this.udcScreenLoss.ScreenLockBackColor = System.Drawing.Color.Empty;
            this.udcScreenLoss.Size = new System.Drawing.Size(1234, 548);
            this.udcScreenLoss.TabIndex = 3;
            // 
            // frmPOPTranLabelSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 659);
            this.MinimumSize = new System.Drawing.Size(1250, 550);
            this.Name = "frmPOPTranLabelSample";
            this.Text = "Label Print Sample";
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrinter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblStartLotID;
        private Miracom.MESCore.Controls.udcFlexibleScreen udcScreen;
        private System.Windows.Forms.Button btnProcess_1;
        private System.Windows.Forms.Label lblPrinter;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrinter;
        private Miracom.MESCore.Controls.udcFlexibleScreen udcScreenLoss;
    }
}