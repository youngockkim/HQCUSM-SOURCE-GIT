namespace Miracom.POPCore
{
    partial class frmPOPTranPrintLabel
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
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.cdvPrinter = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.udcScreen = new Miracom.MESCore.Controls.udcFlexibleScreen();
            this.lblAngle = new System.Windows.Forms.Label();
            this.numAngle = new System.Windows.Forms.NumericUpDown();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrinter)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(742, 48);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.groupBox1);
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 48);
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 458);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.txtLotID);
            this.grpTranTop.Controls.Add(this.lblLotID);
            this.grpTranTop.Size = new System.Drawing.Size(736, 48);
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Print";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 6;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.numAngle);
            this.pnlBottom.Controls.Add(this.lblAngle);
            this.pnlBottom.Controls.Add(this.lblPrinter);
            this.pnlBottom.Controls.Add(this.cdvPrinter);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.cdvPrinter, 0);
            this.pnlBottom.Controls.SetChildIndex(this.lblPrinter, 0);
            this.pnlBottom.Controls.SetChildIndex(this.lblAngle, 0);
            this.pnlBottom.Controls.SetChildIndex(this.numAngle, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm04";
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Location = new System.Drawing.Point(35, 22);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(87, 18);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
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
            this.cdvPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvPrinter.Index = 0;
            this.cdvPrinter.IsViewBtnImage = false;
            this.cdvPrinter.Location = new System.Drawing.Point(90, 10);
            this.cdvPrinter.MaxLength = 200;
            this.cdvPrinter.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrinter.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrinter.Name = "cdvPrinter";
            this.cdvPrinter.ReadOnly = false;
            this.cdvPrinter.SameWidthHeightOfButton = false;
            this.cdvPrinter.SearchSubItemIndex = 0;
            this.cdvPrinter.SelectedDescIndex = -1;
            this.cdvPrinter.SelectedSubItemIndex = 0;
            this.cdvPrinter.SelectionStart = 0;
            this.cdvPrinter.Size = new System.Drawing.Size(200, 20);
            this.cdvPrinter.SmallImageList = null;
            this.cdvPrinter.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrinter.TabIndex = 2;
            this.cdvPrinter.TextBoxToolTipText = "";
            this.cdvPrinter.TextBoxWidth = 200;
            this.cdvPrinter.VisibleButton = true;
            this.cdvPrinter.VisibleColumnHeader = false;
            this.cdvPrinter.VisibleDescription = false;
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinter.Location = new System.Drawing.Point(38, 13);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(37, 13);
            this.lblPrinter.TabIndex = 1;
            this.lblPrinter.Text = "Printer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.udcScreen);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 455);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Label Design";
            // 
            // udcScreen
            // 
            this.udcScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcScreen.Location = new System.Drawing.Point(3, 16);
            this.udcScreen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.udcScreen.Name = "udcScreen";
            this.udcScreen.ScreenAutoStretch = false;
            this.udcScreen.ScreenID = null;
            this.udcScreen.ScreenLock = false;
            this.udcScreen.ScreenLockBackColor = System.Drawing.Color.Empty;
            this.udcScreen.Size = new System.Drawing.Size(730, 436);
            this.udcScreen.TabIndex = 1;
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngle.Location = new System.Drawing.Point(353, 14);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(58, 13);
            this.lblAngle.TabIndex = 3;
            this.lblAngle.Text = "Print Angle";
            // 
            // numAngle
            // 
            this.numAngle.Location = new System.Drawing.Point(423, 10);
            this.numAngle.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numAngle.Name = "numAngle";
            this.numAngle.Size = new System.Drawing.Size(50, 20);
            this.numAngle.TabIndex = 4;
            // 
            // frmPOPTranPrintLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmPOPTranPrintLabel";
            this.Text = "Print Label using Flexible Screen";
            this.Activated += new System.EventHandler(this.frmPOPTranPrintLabel_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPOPTranPrintLabel_FormClosing);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrinter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private UI.Controls.MCCodeView.MCCodeView cdvPrinter;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.GroupBox groupBox1;
        private MESCore.Controls.udcFlexibleScreen udcScreen;
        private System.Windows.Forms.NumericUpDown numAngle;
        private System.Windows.Forms.Label lblAngle;
    }
}