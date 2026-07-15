namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionMove
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
            this.numOperCountFalse = new System.Windows.Forms.NumericUpDown();
            this.lblByOperCountFalse = new System.Windows.Forms.Label();
            this.cdvToOperFalse = new Miracom.MESCore.Controls.udcOperation();
            this.cdvToFlowFalse = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.grpActionTrue = new System.Windows.Forms.GroupBox();
            this.numOperCount = new System.Windows.Forms.NumericUpDown();
            this.lblByOperCount = new System.Windows.Forms.Label();
            this.cdvToOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvToFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.pnlActionValueTop = new System.Windows.Forms.Panel();
            this.cboActionType = new System.Windows.Forms.ComboBox();
            this.lblActionType = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.grpActionFalse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOperCountFalse)).BeginInit();
            this.grpActionTrue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOperCount)).BeginInit();
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
            this.grpActionFalse.Controls.Add(this.numOperCountFalse);
            this.grpActionFalse.Controls.Add(this.lblByOperCountFalse);
            this.grpActionFalse.Controls.Add(this.cdvToOperFalse);
            this.grpActionFalse.Controls.Add(this.cdvToFlowFalse);
            this.grpActionFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionFalse.Location = new System.Drawing.Point(3, 184);
            this.grpActionFalse.Name = "grpActionFalse";
            this.grpActionFalse.Size = new System.Drawing.Size(524, 143);
            this.grpActionFalse.TabIndex = 2;
            this.grpActionFalse.TabStop = false;
            this.grpActionFalse.Text = "False Action";
            // 
            // numOperCountFalse
            // 
            this.numOperCountFalse.Location = new System.Drawing.Point(129, 68);
            this.numOperCountFalse.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numOperCountFalse.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numOperCountFalse.Name = "numOperCountFalse";
            this.numOperCountFalse.Size = new System.Drawing.Size(145, 20);
            this.numOperCountFalse.TabIndex = 3;
            // 
            // lblByOperCountFalse
            // 
            this.lblByOperCountFalse.AutoSize = true;
            this.lblByOperCountFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblByOperCountFalse.Location = new System.Drawing.Point(8, 72);
            this.lblByOperCountFalse.Name = "lblByOperCountFalse";
            this.lblByOperCountFalse.Size = new System.Drawing.Size(99, 13);
            this.lblByOperCountFalse.TabIndex = 2;
            this.lblByOperCountFalse.Text = "By Operation Count";
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
            this.cdvToOperFalse.ListCond_Step = '1';
            this.cdvToOperFalse.Location = new System.Drawing.Point(8, 43);
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
            this.cdvToOperFalse.ButtonPress += new System.EventHandler(this.cdvToOperFalse_ButtonPress);
            // 
            // cdvToFlowFalse
            // 
            this.cdvToFlowFalse.AddEmptyRowToLast = false;
            this.cdvToFlowFalse.AddEmptyRowToTop = false;
            this.cdvToFlowFalse.DisplaySubItemIndex = 0;
            this.cdvToFlowFalse.FlowReadOnly = false;
            this.cdvToFlowFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlowFalse.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlowFalse.LabelText = "To Flow";
            this.cdvToFlowFalse.LabelWidth = 85;
            this.cdvToFlowFalse.ListCond_ExtFactory = "";
            this.cdvToFlowFalse.ListCond_Step = '2';
            this.cdvToFlowFalse.Location = new System.Drawing.Point(8, 18);
            this.cdvToFlowFalse.Name = "cdvToFlowFalse";
            this.cdvToFlowFalse.SearchSubItemIndex = 0;
            this.cdvToFlowFalse.SelectedDescIndex = -1;
            this.cdvToFlowFalse.SelectedSubItemIndex = 0;
            this.cdvToFlowFalse.SequenceReadOnly = false;
            this.cdvToFlowFalse.Size = new System.Drawing.Size(266, 20);
            this.cdvToFlowFalse.TabIndex = 0;
            this.cdvToFlowFalse.Visible = false;
            this.cdvToFlowFalse.VisibleColumnHeader = false;
            this.cdvToFlowFalse.VisibleDescription = false;
            this.cdvToFlowFalse.VisibleFlowButton = true;
            this.cdvToFlowFalse.VisibleSequenceButton = true;
            this.cdvToFlowFalse.WidthButton = 20;
            this.cdvToFlowFalse.WidthFlowAndSequence = 181;
            this.cdvToFlowFalse.WidthSequence = 50;
            this.cdvToFlowFalse.FlowButtonPress += new System.EventHandler(this.cdvToFlowFalse_FlowButtonPress);
            this.cdvToFlowFalse.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToFlowFalse_FlowSelectedItemChanged);
            // 
            // grpActionTrue
            // 
            this.grpActionTrue.Controls.Add(this.numOperCount);
            this.grpActionTrue.Controls.Add(this.lblByOperCount);
            this.grpActionTrue.Controls.Add(this.cdvToOper);
            this.grpActionTrue.Controls.Add(this.cdvToFlow);
            this.grpActionTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionTrue.Location = new System.Drawing.Point(3, 42);
            this.grpActionTrue.Name = "grpActionTrue";
            this.grpActionTrue.Size = new System.Drawing.Size(524, 142);
            this.grpActionTrue.TabIndex = 1;
            this.grpActionTrue.TabStop = false;
            this.grpActionTrue.Text = "True Action";
            // 
            // numOperCount
            // 
            this.numOperCount.Location = new System.Drawing.Point(129, 68);
            this.numOperCount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numOperCount.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numOperCount.Name = "numOperCount";
            this.numOperCount.Size = new System.Drawing.Size(145, 20);
            this.numOperCount.TabIndex = 3;
            // 
            // lblByOperCount
            // 
            this.lblByOperCount.AutoSize = true;
            this.lblByOperCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblByOperCount.Location = new System.Drawing.Point(8, 72);
            this.lblByOperCount.Name = "lblByOperCount";
            this.lblByOperCount.Size = new System.Drawing.Size(99, 13);
            this.lblByOperCount.TabIndex = 2;
            this.lblByOperCount.Text = "By Operation Count";
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
            this.cdvToOper.ListCond_Step = '1';
            this.cdvToOper.Location = new System.Drawing.Point(8, 43);
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
            this.cdvToOper.ButtonPress += new System.EventHandler(this.cdvToOper_ButtonPress);
            // 
            // cdvToFlow
            // 
            this.cdvToFlow.AddEmptyRowToLast = false;
            this.cdvToFlow.AddEmptyRowToTop = false;
            this.cdvToFlow.DisplaySubItemIndex = 0;
            this.cdvToFlow.FlowReadOnly = false;
            this.cdvToFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelText = "To Flow";
            this.cdvToFlow.LabelWidth = 85;
            this.cdvToFlow.ListCond_ExtFactory = "";
            this.cdvToFlow.ListCond_Step = '2';
            this.cdvToFlow.Location = new System.Drawing.Point(8, 18);
            this.cdvToFlow.Name = "cdvToFlow";
            this.cdvToFlow.SearchSubItemIndex = 0;
            this.cdvToFlow.SelectedDescIndex = -1;
            this.cdvToFlow.SelectedSubItemIndex = 0;
            this.cdvToFlow.SequenceReadOnly = false;
            this.cdvToFlow.Size = new System.Drawing.Size(266, 20);
            this.cdvToFlow.TabIndex = 0;
            this.cdvToFlow.Visible = false;
            this.cdvToFlow.VisibleColumnHeader = false;
            this.cdvToFlow.VisibleDescription = false;
            this.cdvToFlow.VisibleFlowButton = true;
            this.cdvToFlow.VisibleSequenceButton = true;
            this.cdvToFlow.WidthButton = 20;
            this.cdvToFlow.WidthFlowAndSequence = 181;
            this.cdvToFlow.WidthSequence = 50;
            this.cdvToFlow.FlowButtonPress += new System.EventHandler(this.cdvToFlow_FlowButtonPress);
            this.cdvToFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToFlow_FlowSelectedItemChanged);
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
            "To Flow/Oper with True or False",
            "By Operation Count with True or False"});
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
            // udcFutureActionMove
            // 
            this.Name = "udcFutureActionMove";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionFalse.ResumeLayout(false);
            this.grpActionFalse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOperCountFalse)).EndInit();
            this.grpActionTrue.ResumeLayout(false);
            this.grpActionTrue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOperCount)).EndInit();
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
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvToFlow;
        private System.Windows.Forms.Label lblByOperCountFalse;
        private Miracom.MESCore.Controls.udcOperation cdvToOperFalse;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvToFlowFalse;
        private System.Windows.Forms.Label lblByOperCount;
        private System.Windows.Forms.NumericUpDown numOperCountFalse;
        private System.Windows.Forms.NumericUpDown numOperCount;
    }
}
