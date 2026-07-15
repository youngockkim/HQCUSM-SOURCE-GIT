namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionMoveStep
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
            this.cdvToStep = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rbtMoveToStep = new System.Windows.Forms.RadioButton();
            this.rbtMoveToCnt = new System.Windows.Forms.RadioButton();
            this.numByCount = new System.Windows.Forms.NumericUpDown();
            this.grpActionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numByCount)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.numByCount);
            this.grpActionValue.Controls.Add(this.rbtMoveToCnt);
            this.grpActionValue.Controls.Add(this.rbtMoveToStep);
            this.grpActionValue.Controls.Add(this.cdvToStep);
            // 
            // cdvToStep
            // 
            this.cdvToStep.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToStep.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToStep.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToStep.BtnToolTipText = "";
            this.cdvToStep.DescText = "";
            this.cdvToStep.DisplaySubItemIndex = -1;
            this.cdvToStep.DisplayText = "";
            this.cdvToStep.Focusing = null;
            this.cdvToStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToStep.Index = 0;
            this.cdvToStep.IsViewBtnImage = false;
            this.cdvToStep.Location = new System.Drawing.Point(8, 41);
            this.cdvToStep.MaxLength = 20;
            this.cdvToStep.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToStep.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToStep.Name = "cdvToStep";
            this.cdvToStep.ReadOnly = true;
            this.cdvToStep.SearchSubItemIndex = 0;
            this.cdvToStep.SelectedDescIndex = -1;
            this.cdvToStep.SelectedSubItemIndex = -1;
            this.cdvToStep.SelectionStart = 0;
            this.cdvToStep.Size = new System.Drawing.Size(226, 20);
            this.cdvToStep.SmallImageList = null;
            this.cdvToStep.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToStep.TabIndex = 9;
            this.cdvToStep.TextBoxToolTipText = "";
            this.cdvToStep.TextBoxWidth = 226;
            this.cdvToStep.VisibleButton = true;
            this.cdvToStep.VisibleColumnHeader = false;
            this.cdvToStep.VisibleDescription = false;
            // 
            // rbtMoveToStep
            // 
            this.rbtMoveToStep.AutoSize = true;
            this.rbtMoveToStep.Location = new System.Drawing.Point(8, 20);
            this.rbtMoveToStep.Name = "rbtMoveToStep";
            this.rbtMoveToStep.Size = new System.Drawing.Size(89, 17);
            this.rbtMoveToStep.TabIndex = 10;
            this.rbtMoveToStep.TabStop = true;
            this.rbtMoveToStep.Text = "Move to Step";
            this.rbtMoveToStep.UseVisualStyleBackColor = true;
            this.rbtMoveToStep.CheckedChanged += new System.EventHandler(this.rbtMove_CheckedChanged);
            // 
            // rbtMoveToCnt
            // 
            this.rbtMoveToCnt.AutoSize = true;
            this.rbtMoveToCnt.Location = new System.Drawing.Point(8, 72);
            this.rbtMoveToCnt.Name = "rbtMoveToCnt";
            this.rbtMoveToCnt.Size = new System.Drawing.Size(122, 17);
            this.rbtMoveToCnt.TabIndex = 11;
            this.rbtMoveToCnt.TabStop = true;
            this.rbtMoveToCnt.Text = "Move by Step Count";
            this.rbtMoveToCnt.UseVisualStyleBackColor = true;
            this.rbtMoveToCnt.CheckedChanged += new System.EventHandler(this.rbtMove_CheckedChanged);
            // 
            // numByCount
            // 
            this.numByCount.Location = new System.Drawing.Point(8, 95);
            this.numByCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numByCount.Name = "numByCount";
            this.numByCount.Size = new System.Drawing.Size(226, 20);
            this.numByCount.TabIndex = 12;
            // 
            // udcStepActionMoveStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcStepActionMoveStep";
            this.Load += new System.EventHandler(this.udcStepActionMoveStep_Load);
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numByCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.MCCodeView.MCCodeView cdvToStep;
        private System.Windows.Forms.RadioButton rbtMoveToCnt;
        private System.Windows.Forms.RadioButton rbtMoveToStep;
        private System.Windows.Forms.NumericUpDown numByCount;

    }
}
