namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionEnd
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
            this.numOperCount = new System.Windows.Forms.NumericUpDown();
            this.lblByOperCount = new System.Windows.Forms.Label();
            this.cdvToOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvToFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.rbtMoveToOper = new System.Windows.Forms.RadioButton();
            this.rbtMoveByCount = new System.Windows.Forms.RadioButton();
            this.chkMultiTrans = new System.Windows.Forms.CheckBox();
            this.grpActionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOperCount)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.chkMultiTrans);
            this.grpActionValue.Controls.Add(this.rbtMoveByCount);
            this.grpActionValue.Controls.Add(this.rbtMoveToOper);
            this.grpActionValue.Controls.Add(this.numOperCount);
            this.grpActionValue.Controls.Add(this.lblByOperCount);
            this.grpActionValue.Controls.Add(this.cdvToOper);
            this.grpActionValue.Controls.Add(this.cdvToFlow);
            // 
            // numOperCount
            // 
            this.numOperCount.Location = new System.Drawing.Point(161, 136);
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
            this.numOperCount.Size = new System.Drawing.Size(73, 20);
            this.numOperCount.TabIndex = 5;
            // 
            // lblByOperCount
            // 
            this.lblByOperCount.AutoSize = true;
            this.lblByOperCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblByOperCount.Location = new System.Drawing.Point(6, 140);
            this.lblByOperCount.Name = "lblByOperCount";
            this.lblByOperCount.Size = new System.Drawing.Size(99, 13);
            this.lblByOperCount.TabIndex = 4;
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
            this.cdvToOper.Location = new System.Drawing.Point(6, 67);
            this.cdvToOper.Name = "cdvToOper";
            this.cdvToOper.ReadOnly = false;
            this.cdvToOper.SearchSubItemIndex = 0;
            this.cdvToOper.SelectedDescIndex = 1;
            this.cdvToOper.SelectedSubItemIndex = 0;
            this.cdvToOper.Size = new System.Drawing.Size(228, 20);
            this.cdvToOper.TabIndex = 2;
            this.cdvToOper.TextBoxWidth = 143;
            this.cdvToOper.Visible = false;
            this.cdvToOper.VisibleButton = true;
            this.cdvToOper.VisibleColumnHeader = false;
            this.cdvToOper.VisibleDescription = false;
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
            this.cdvToFlow.Location = new System.Drawing.Point(6, 42);
            this.cdvToFlow.Name = "cdvToFlow";
            this.cdvToFlow.SearchSubItemIndex = 0;
            this.cdvToFlow.SelectedDescIndex = -1;
            this.cdvToFlow.SelectedSubItemIndex = 0;
            this.cdvToFlow.SequenceReadOnly = false;
            this.cdvToFlow.Size = new System.Drawing.Size(228, 20);
            this.cdvToFlow.TabIndex = 1;
            this.cdvToFlow.Visible = false;
            this.cdvToFlow.VisibleColumnHeader = false;
            this.cdvToFlow.VisibleDescription = false;
            this.cdvToFlow.VisibleFlowButton = true;
            this.cdvToFlow.VisibleSequenceButton = true;
            this.cdvToFlow.WidthButton = 20;
            this.cdvToFlow.WidthFlowAndSequence = 143;
            this.cdvToFlow.WidthSequence = 50;
            // 
            // rbtMoveToOper
            // 
            this.rbtMoveToOper.AutoSize = true;
            this.rbtMoveToOper.Location = new System.Drawing.Point(7, 19);
            this.rbtMoveToOper.Name = "rbtMoveToOper";
            this.rbtMoveToOper.Size = new System.Drawing.Size(113, 17);
            this.rbtMoveToOper.TabIndex = 0;
            this.rbtMoveToOper.TabStop = true;
            this.rbtMoveToOper.Text = "Move to Operation";
            this.rbtMoveToOper.UseVisualStyleBackColor = true;
            // 
            // rbtMoveByCount
            // 
            this.rbtMoveByCount.AutoSize = true;
            this.rbtMoveByCount.Location = new System.Drawing.Point(7, 113);
            this.rbtMoveByCount.Name = "rbtMoveByCount";
            this.rbtMoveByCount.Size = new System.Drawing.Size(146, 17);
            this.rbtMoveByCount.TabIndex = 3;
            this.rbtMoveByCount.TabStop = true;
            this.rbtMoveByCount.Text = "Move by Operation Count";
            this.rbtMoveByCount.UseVisualStyleBackColor = true;
            // 
            // chkMultiTrans
            // 
            this.chkMultiTrans.AutoSize = true;
            this.chkMultiTrans.Location = new System.Drawing.Point(7, 175);
            this.chkMultiTrans.Name = "chkMultiTrans";
            this.chkMultiTrans.Size = new System.Drawing.Size(146, 17);
            this.chkMultiTrans.TabIndex = 6;
            this.chkMultiTrans.Text = "Perform Multi Transaction";
            this.chkMultiTrans.UseVisualStyleBackColor = true;
            // 
            // udcStepActionEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcStepActionEnd";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOperCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numOperCount;
        private System.Windows.Forms.Label lblByOperCount;
        private MESCore.Controls.udcOperation cdvToOper;
        private MESCore.Controls.udcFlowAndSeq cdvToFlow;
        private System.Windows.Forms.RadioButton rbtMoveByCount;
        private System.Windows.Forms.RadioButton rbtMoveToOper;
        private System.Windows.Forms.CheckBox chkMultiTrans;
    }
}
