namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionDeactivateMaterial
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
            this.cdvMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.chkAllVersions = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.lblDescription);
            this.grpActionValue.Controls.Add(this.chkAllVersions);
            this.grpActionValue.Controls.Add(this.cdvMatID);
            // 
            // cdvMatID
            // 
            this.cdvMatID.AddEmptyRowToLast = false;
            this.cdvMatID.AddEmptyRowToTop = false;
            this.cdvMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMatID.DisplaySubItemIndex = 0;
            this.cdvMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelText = "Material";
            this.cdvMatID.ListCond_ExtFactory = "";
            this.cdvMatID.ListCond_StepMaterial = '1';
            this.cdvMatID.ListCond_StepVersion = '1';
            this.cdvMatID.Location = new System.Drawing.Point(6, 20);
            this.cdvMatID.MaterialEnabled = true;
            this.cdvMatID.MaterialReadOnly = false;
            this.cdvMatID.Name = "cdvMatID";
            this.cdvMatID.SearchSubItemIndex = 0;
            this.cdvMatID.SelectedDescIndex = -1;
            this.cdvMatID.SelectedSubItemIndex = 0;
            this.cdvMatID.Size = new System.Drawing.Size(228, 20);
            this.cdvMatID.TabIndex = 0;
            this.cdvMatID.VersionEnabled = true;
            this.cdvMatID.VersionReadOnly = false;
            this.cdvMatID.VisibleColumnHeader = false;
            this.cdvMatID.VisibleDescription = false;
            this.cdvMatID.VisibleMaterialButton = true;
            this.cdvMatID.VisibleVersionButton = true;
            this.cdvMatID.WidthButton = 20;
            this.cdvMatID.WidthLabel = 60;
            this.cdvMatID.WidthMaterialAndVersion = 168;
            this.cdvMatID.WidthVersion = 50;
            this.cdvMatID.MaterialButtonPressAfter += new System.EventHandler(this.cdvMatID_MaterialButtonPressAfter);
            // 
            // chkAllVersions
            // 
            this.chkAllVersions.AutoSize = true;
            this.chkAllVersions.Location = new System.Drawing.Point(6, 46);
            this.chkAllVersions.Name = "chkAllVersions";
            this.chkAllVersions.Size = new System.Drawing.Size(133, 17);
            this.chkAllVersions.TabIndex = 1;
            this.chkAllVersions.Text = "Deactivate all versions";
            this.chkAllVersions.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(6, 70);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(228, 66);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "@MATERIAL is input during the execution of the action, is the Material ID.";
            // 
            // udcProcessActionDeactivateMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcProcessActionDeactivateMaterial";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MESCore.Controls.udcMaterial cdvMatID;
        private System.Windows.Forms.CheckBox chkAllVersions;
        private System.Windows.Forms.Label lblDescription;
    }
}
