namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionStore
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
            this.grpActionFalse = new System.Windows.Forms.GroupBox();
            this.cdvToOperFalse = new Miracom.MESCore.Controls.udcOperation();
            this.grpActionTrue = new System.Windows.Forms.GroupBox();
            this.cdvToOper = new Miracom.MESCore.Controls.udcOperation();
            this.pnlActionValueTop = new System.Windows.Forms.Panel();
            this.cboActionType = new System.Windows.Forms.ComboBox();
            this.lblActionType = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.grpActionFalse.SuspendLayout();
            this.grpActionTrue.SuspendLayout();
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
            this.grpActionFalse.Controls.Add(this.cdvToOperFalse);
            this.grpActionFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionFalse.Location = new System.Drawing.Point(3, 184);
            this.grpActionFalse.Name = "grpActionFalse";
            this.grpActionFalse.Size = new System.Drawing.Size(524, 143);
            this.grpActionFalse.TabIndex = 2;
            this.grpActionFalse.TabStop = false;
            this.grpActionFalse.Text = "False Action";
            // 
            // cdvToOperFalse
            // 
            this.cdvToOperFalse.AddEmptyRowToLast = false;
            this.cdvToOperFalse.AddEmptyRowToTop = false;
            this.cdvToOperFalse.ButtonWidth = 21;
            this.cdvToOperFalse.DisplaySubItemIndex = 0;
            this.cdvToOperFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOperFalse.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOperFalse.LabelText = "To Operation";
            this.cdvToOperFalse.LabelWidth = 85;
            this.cdvToOperFalse.ListCond_ExtFactory = "";
            this.cdvToOperFalse.ListCond_Step = '6';
            this.cdvToOperFalse.Location = new System.Drawing.Point(8, 18);
            this.cdvToOperFalse.Name = "cdvToOperFalse";
            this.cdvToOperFalse.ReadOnly = false;
            this.cdvToOperFalse.SearchSubItemIndex = 0;
            this.cdvToOperFalse.SelectedDescIndex = 1;
            this.cdvToOperFalse.SelectedSubItemIndex = 0;
            this.cdvToOperFalse.Size = new System.Drawing.Size(266, 20);
            this.cdvToOperFalse.TabIndex = 1;
            this.cdvToOperFalse.TextBoxWidth = 181;
            this.cdvToOperFalse.Visible = false;
            this.cdvToOperFalse.VisibleButton = true;
            this.cdvToOperFalse.VisibleColumnHeader = false;
            this.cdvToOperFalse.VisibleDescription = false;
            // 
            // grpActionTrue
            // 
            this.grpActionTrue.Controls.Add(this.cdvToOper);
            this.grpActionTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionTrue.Location = new System.Drawing.Point(3, 42);
            this.grpActionTrue.Name = "grpActionTrue";
            this.grpActionTrue.Size = new System.Drawing.Size(524, 142);
            this.grpActionTrue.TabIndex = 1;
            this.grpActionTrue.TabStop = false;
            this.grpActionTrue.Text = "True Action";
            // 
            // cdvToOper
            // 
            this.cdvToOper.AddEmptyRowToLast = false;
            this.cdvToOper.AddEmptyRowToTop = false;
            this.cdvToOper.ButtonWidth = 21;
            this.cdvToOper.DisplaySubItemIndex = 0;
            this.cdvToOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOper.LabelText = "To Operation";
            this.cdvToOper.LabelWidth = 85;
            this.cdvToOper.ListCond_ExtFactory = "";
            this.cdvToOper.ListCond_Step = '6';
            this.cdvToOper.Location = new System.Drawing.Point(8, 18);
            this.cdvToOper.Name = "cdvToOper";
            this.cdvToOper.ReadOnly = false;
            this.cdvToOper.SearchSubItemIndex = 0;
            this.cdvToOper.SelectedDescIndex = 1;
            this.cdvToOper.SelectedSubItemIndex = 0;
            this.cdvToOper.Size = new System.Drawing.Size(266, 20);
            this.cdvToOper.TabIndex = 1;
            this.cdvToOper.TextBoxWidth = 181;
            this.cdvToOper.Visible = false;
            this.cdvToOper.VisibleButton = true;
            this.cdvToOper.VisibleColumnHeader = false;
            this.cdvToOper.VisibleDescription = false;
            // 
            // pnlActionValueTop
            // 
            this.pnlActionValueTop.Controls.Add(this.cboActionType);
            this.pnlActionValueTop.Controls.Add(this.lblActionType);
            this.pnlActionValueTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionValueTop.Location = new System.Drawing.Point(3, 16);
            this.pnlActionValueTop.Name = "pnlActionValueTop";
            this.pnlActionValueTop.Size = new System.Drawing.Size(524, 26);
            this.pnlActionValueTop.TabIndex = 0;
            // 
            // cboActionType
            // 
            this.cboActionType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboActionType.FormattingEnabled = true;
            this.cboActionType.Items.AddRange(new object[] {
            "Just positive condition",
            "To Operation with True or False"});
            this.cboActionType.Location = new System.Drawing.Point(94, 2);
            this.cboActionType.Name = "cboActionType";
            this.cboActionType.Size = new System.Drawing.Size(250, 21);
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
            this.lblActionType.Size = new System.Drawing.Size(64, 13);
            this.lblActionType.TabIndex = 0;
            this.lblActionType.Text = "Action Type";
            // 
            // udcFutureActionStore
            // 
            this.Name = "udcFutureActionStore";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionFalse.ResumeLayout(false);
            this.grpActionTrue.ResumeLayout(false);
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
        private Miracom.MESCore.Controls.udcOperation cdvToOper;
        private Miracom.MESCore.Controls.udcOperation cdvToOperFalse;
    }
}
