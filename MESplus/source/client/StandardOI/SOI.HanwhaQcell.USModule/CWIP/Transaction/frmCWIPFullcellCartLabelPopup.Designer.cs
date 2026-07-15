namespace SOI.HanwhaQcell.USModule
{
    partial class frmCWIPFullcellCartLabelPopup
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
            this.components = new System.ComponentModel.Container();
            this.soiPanel3 = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.spdList_Flexible = new SOI.OIFrx.SOIControls.SOIFlexibleScreen();
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            this.soiPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Size = new System.Drawing.Size(866, 38);
            this.lblPopupTitle.Text = "FullCell Cart Label";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlPopupTop.Size = new System.Drawing.Size(886, 48);
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(2, 598);
            this.pnlPopupBottom.Size = new System.Drawing.Size(886, 50);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(766, 0);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupMiddle.Size = new System.Drawing.Size(886, 544);
            // 
            // pnlPopupTopMargin
            // 
            this.pnlPopupTopMargin.Size = new System.Drawing.Size(866, 38);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(866, 40);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.soiPanel3);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(866, 534);
            // 
            // soiPanel3
            // 
            this.soiPanel3._SetAutoScrollPanel = false;
            this.soiPanel3._UseOITheme = true;
            this.soiPanel3._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.soiPanel3.BackColor = System.Drawing.Color.Transparent;
            this.soiPanel3.Controls.Add(this.spdList_Flexible);
            this.soiPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiPanel3.Location = new System.Drawing.Point(0, 0);
            this.soiPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.soiPanel3.Name = "soiPanel3";
            this.soiPanel3.Size = new System.Drawing.Size(866, 534);
            this.soiPanel3.TabIndex = 3;
            // 
            // spdList_Flexible
            // 
            this.spdList_Flexible._ListCellCopy = true;
            this.spdList_Flexible._UseOITheme = true;
            this.spdList_Flexible.AutoScroll = true;
            this.spdList_Flexible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList_Flexible.Location = new System.Drawing.Point(0, 0);
            this.spdList_Flexible.Margin = new System.Windows.Forms.Padding(0);
            this.spdList_Flexible.Name = "spdList_Flexible";
            this.spdList_Flexible.OwnerFuncName = null;
            this.spdList_Flexible.ScreenAutoStretch = false;
            this.spdList_Flexible.ScreenID = null;
            this.spdList_Flexible.ScreenLock = false;
            this.spdList_Flexible.ScreenLockBackColor = System.Drawing.Color.Empty;
            this.spdList_Flexible.Size = new System.Drawing.Size(866, 534);
            this.spdList_Flexible.TabIndex = 4;
            // 
            // frmCWIPFullcellCartLabelPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 650);
            this.Name = "frmCWIPFullcellCartLabelPopup";
            this.Text = "frmCWIPFullcellCartLabel";
            this.Load += new System.EventHandler(this.frmTempSOIPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            this.soiPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OIFrx.SOIControls.SOIPanel soiPanel3;
        private OIFrx.SOIControls.SOIFlexibleScreen spdList_Flexible;
    }
}