namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionCustom
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
            this.pnlActionValueTop = new System.Windows.Forms.Panel();
            this.cboActionType = new System.Windows.Forms.ComboBox();
            this.lblActionType = new System.Windows.Forms.Label();
            this.grpActionTrue = new System.Windows.Forms.GroupBox();
            this.lblData5 = new System.Windows.Forms.Label();
            this.txtData5 = new System.Windows.Forms.TextBox();
            this.lblData4 = new System.Windows.Forms.Label();
            this.txtData4 = new System.Windows.Forms.TextBox();
            this.lblData3 = new System.Windows.Forms.Label();
            this.txtData3 = new System.Windows.Forms.TextBox();
            this.txtData1 = new System.Windows.Forms.TextBox();
            this.lblData2 = new System.Windows.Forms.Label();
            this.txtData2 = new System.Windows.Forms.TextBox();
            this.lblData1 = new System.Windows.Forms.Label();
            this.grpActionFalse = new System.Windows.Forms.GroupBox();
            this.lblDataFalse5 = new System.Windows.Forms.Label();
            this.txtDataFalse5 = new System.Windows.Forms.TextBox();
            this.lblDataFalse4 = new System.Windows.Forms.Label();
            this.txtDataFalse4 = new System.Windows.Forms.TextBox();
            this.lblDataFalse3 = new System.Windows.Forms.Label();
            this.txtDataFalse3 = new System.Windows.Forms.TextBox();
            this.txtDataFalse1 = new System.Windows.Forms.TextBox();
            this.lblDataFalse2 = new System.Windows.Forms.Label();
            this.txtDataFalse2 = new System.Windows.Forms.TextBox();
            this.lblDataFalse1 = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.pnlActionValueTop.SuspendLayout();
            this.grpActionTrue.SuspendLayout();
            this.grpActionFalse.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.grpActionFalse);
            this.grpActionValue.Controls.Add(this.grpActionTrue);
            this.grpActionValue.Controls.Add(this.pnlActionValueTop);
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
            "Action with True or False"});
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
            // grpActionTrue
            // 
            this.grpActionTrue.Controls.Add(this.lblData5);
            this.grpActionTrue.Controls.Add(this.txtData5);
            this.grpActionTrue.Controls.Add(this.lblData4);
            this.grpActionTrue.Controls.Add(this.txtData4);
            this.grpActionTrue.Controls.Add(this.lblData3);
            this.grpActionTrue.Controls.Add(this.txtData3);
            this.grpActionTrue.Controls.Add(this.txtData1);
            this.grpActionTrue.Controls.Add(this.lblData2);
            this.grpActionTrue.Controls.Add(this.txtData2);
            this.grpActionTrue.Controls.Add(this.lblData1);
            this.grpActionTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionTrue.Location = new System.Drawing.Point(3, 42);
            this.grpActionTrue.Name = "grpActionTrue";
            this.grpActionTrue.Size = new System.Drawing.Size(524, 142);
            this.grpActionTrue.TabIndex = 1;
            this.grpActionTrue.TabStop = false;
            this.grpActionTrue.Text = "True Action";
            // 
            // lblData5
            // 
            this.lblData5.AutoSize = true;
            this.lblData5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblData5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData5.Location = new System.Drawing.Point(8, 118);
            this.lblData5.Name = "lblData5";
            this.lblData5.Size = new System.Drawing.Size(39, 13);
            this.lblData5.TabIndex = 9;
            this.lblData5.Text = "Data 5";
            this.lblData5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtData5
            // 
            this.txtData5.Location = new System.Drawing.Point(94, 114);
            this.txtData5.MaxLength = 50;
            this.txtData5.Name = "txtData5";
            this.txtData5.Size = new System.Drawing.Size(180, 20);
            this.txtData5.TabIndex = 10;
            // 
            // lblData4
            // 
            this.lblData4.AutoSize = true;
            this.lblData4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblData4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData4.Location = new System.Drawing.Point(8, 94);
            this.lblData4.Name = "lblData4";
            this.lblData4.Size = new System.Drawing.Size(39, 13);
            this.lblData4.TabIndex = 7;
            this.lblData4.Text = "Data 4";
            this.lblData4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtData4
            // 
            this.txtData4.Location = new System.Drawing.Point(94, 90);
            this.txtData4.MaxLength = 50;
            this.txtData4.Name = "txtData4";
            this.txtData4.Size = new System.Drawing.Size(180, 20);
            this.txtData4.TabIndex = 8;
            // 
            // lblData3
            // 
            this.lblData3.AutoSize = true;
            this.lblData3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblData3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData3.Location = new System.Drawing.Point(8, 70);
            this.lblData3.Name = "lblData3";
            this.lblData3.Size = new System.Drawing.Size(39, 13);
            this.lblData3.TabIndex = 5;
            this.lblData3.Text = "Data 3";
            this.lblData3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtData3
            // 
            this.txtData3.Location = new System.Drawing.Point(94, 66);
            this.txtData3.MaxLength = 50;
            this.txtData3.Name = "txtData3";
            this.txtData3.Size = new System.Drawing.Size(180, 20);
            this.txtData3.TabIndex = 6;
            // 
            // txtData1
            // 
            this.txtData1.Location = new System.Drawing.Point(94, 18);
            this.txtData1.MaxLength = 50;
            this.txtData1.Name = "txtData1";
            this.txtData1.Size = new System.Drawing.Size(180, 20);
            this.txtData1.TabIndex = 4;
            // 
            // lblData2
            // 
            this.lblData2.AutoSize = true;
            this.lblData2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblData2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData2.Location = new System.Drawing.Point(8, 46);
            this.lblData2.Name = "lblData2";
            this.lblData2.Size = new System.Drawing.Size(39, 13);
            this.lblData2.TabIndex = 2;
            this.lblData2.Text = "Data 2";
            this.lblData2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtData2
            // 
            this.txtData2.Location = new System.Drawing.Point(94, 42);
            this.txtData2.MaxLength = 50;
            this.txtData2.Name = "txtData2";
            this.txtData2.Size = new System.Drawing.Size(180, 20);
            this.txtData2.TabIndex = 3;
            // 
            // lblData1
            // 
            this.lblData1.AutoSize = true;
            this.lblData1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData1.Location = new System.Drawing.Point(8, 22);
            this.lblData1.Name = "lblData1";
            this.lblData1.Size = new System.Drawing.Size(39, 13);
            this.lblData1.TabIndex = 0;
            this.lblData1.Text = "Data 1";
            this.lblData1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpActionFalse
            // 
            this.grpActionFalse.Controls.Add(this.lblDataFalse5);
            this.grpActionFalse.Controls.Add(this.txtDataFalse5);
            this.grpActionFalse.Controls.Add(this.lblDataFalse4);
            this.grpActionFalse.Controls.Add(this.txtDataFalse4);
            this.grpActionFalse.Controls.Add(this.lblDataFalse3);
            this.grpActionFalse.Controls.Add(this.txtDataFalse3);
            this.grpActionFalse.Controls.Add(this.txtDataFalse1);
            this.grpActionFalse.Controls.Add(this.lblDataFalse2);
            this.grpActionFalse.Controls.Add(this.txtDataFalse2);
            this.grpActionFalse.Controls.Add(this.lblDataFalse1);
            this.grpActionFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionFalse.Location = new System.Drawing.Point(3, 184);
            this.grpActionFalse.Name = "grpActionFalse";
            this.grpActionFalse.Size = new System.Drawing.Size(524, 143);
            this.grpActionFalse.TabIndex = 2;
            this.grpActionFalse.TabStop = false;
            this.grpActionFalse.Text = "False Action";
            // 
            // lblDataFalse5
            // 
            this.lblDataFalse5.AutoSize = true;
            this.lblDataFalse5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataFalse5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFalse5.Location = new System.Drawing.Point(8, 118);
            this.lblDataFalse5.Name = "lblDataFalse5";
            this.lblDataFalse5.Size = new System.Drawing.Size(39, 13);
            this.lblDataFalse5.TabIndex = 19;
            this.lblDataFalse5.Text = "Data 5";
            this.lblDataFalse5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataFalse5
            // 
            this.txtDataFalse5.Location = new System.Drawing.Point(94, 114);
            this.txtDataFalse5.MaxLength = 50;
            this.txtDataFalse5.Name = "txtDataFalse5";
            this.txtDataFalse5.Size = new System.Drawing.Size(180, 20);
            this.txtDataFalse5.TabIndex = 20;
            // 
            // lblDataFalse4
            // 
            this.lblDataFalse4.AutoSize = true;
            this.lblDataFalse4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataFalse4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFalse4.Location = new System.Drawing.Point(8, 94);
            this.lblDataFalse4.Name = "lblDataFalse4";
            this.lblDataFalse4.Size = new System.Drawing.Size(39, 13);
            this.lblDataFalse4.TabIndex = 17;
            this.lblDataFalse4.Text = "Data 4";
            this.lblDataFalse4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataFalse4
            // 
            this.txtDataFalse4.Location = new System.Drawing.Point(94, 90);
            this.txtDataFalse4.MaxLength = 50;
            this.txtDataFalse4.Name = "txtDataFalse4";
            this.txtDataFalse4.Size = new System.Drawing.Size(180, 20);
            this.txtDataFalse4.TabIndex = 18;
            // 
            // lblDataFalse3
            // 
            this.lblDataFalse3.AutoSize = true;
            this.lblDataFalse3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataFalse3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFalse3.Location = new System.Drawing.Point(8, 70);
            this.lblDataFalse3.Name = "lblDataFalse3";
            this.lblDataFalse3.Size = new System.Drawing.Size(39, 13);
            this.lblDataFalse3.TabIndex = 15;
            this.lblDataFalse3.Text = "Data 3";
            this.lblDataFalse3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataFalse3
            // 
            this.txtDataFalse3.Location = new System.Drawing.Point(94, 66);
            this.txtDataFalse3.MaxLength = 50;
            this.txtDataFalse3.Name = "txtDataFalse3";
            this.txtDataFalse3.Size = new System.Drawing.Size(180, 20);
            this.txtDataFalse3.TabIndex = 16;
            // 
            // txtDataFalse1
            // 
            this.txtDataFalse1.Location = new System.Drawing.Point(94, 18);
            this.txtDataFalse1.MaxLength = 50;
            this.txtDataFalse1.Name = "txtDataFalse1";
            this.txtDataFalse1.Size = new System.Drawing.Size(180, 20);
            this.txtDataFalse1.TabIndex = 14;
            // 
            // lblDataFalse2
            // 
            this.lblDataFalse2.AutoSize = true;
            this.lblDataFalse2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataFalse2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFalse2.Location = new System.Drawing.Point(8, 46);
            this.lblDataFalse2.Name = "lblDataFalse2";
            this.lblDataFalse2.Size = new System.Drawing.Size(39, 13);
            this.lblDataFalse2.TabIndex = 12;
            this.lblDataFalse2.Text = "Data 2";
            this.lblDataFalse2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataFalse2
            // 
            this.txtDataFalse2.Location = new System.Drawing.Point(94, 42);
            this.txtDataFalse2.MaxLength = 50;
            this.txtDataFalse2.Name = "txtDataFalse2";
            this.txtDataFalse2.Size = new System.Drawing.Size(180, 20);
            this.txtDataFalse2.TabIndex = 13;
            // 
            // lblDataFalse1
            // 
            this.lblDataFalse1.AutoSize = true;
            this.lblDataFalse1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataFalse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFalse1.Location = new System.Drawing.Point(8, 22);
            this.lblDataFalse1.Name = "lblDataFalse1";
            this.lblDataFalse1.Size = new System.Drawing.Size(39, 13);
            this.lblDataFalse1.TabIndex = 11;
            this.lblDataFalse1.Text = "Data 1";
            this.lblDataFalse1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcFutureActionCustom
            // 
            this.Name = "udcFutureActionCustom";
            this.grpActionValue.ResumeLayout(false);
            this.pnlActionValueTop.ResumeLayout(false);
            this.pnlActionValueTop.PerformLayout();
            this.grpActionTrue.ResumeLayout(false);
            this.grpActionTrue.PerformLayout();
            this.grpActionFalse.ResumeLayout(false);
            this.grpActionFalse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActionValueTop;
        private System.Windows.Forms.ComboBox cboActionType;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.GroupBox grpActionFalse;
        private System.Windows.Forms.GroupBox grpActionTrue;
        private System.Windows.Forms.Label lblData2;
        private System.Windows.Forms.TextBox txtData2;
        private System.Windows.Forms.Label lblData1;
        private System.Windows.Forms.TextBox txtData1;
        private System.Windows.Forms.Label lblDataFalse5;
        private System.Windows.Forms.TextBox txtDataFalse5;
        private System.Windows.Forms.Label lblDataFalse4;
        private System.Windows.Forms.TextBox txtDataFalse4;
        private System.Windows.Forms.Label lblDataFalse3;
        private System.Windows.Forms.TextBox txtDataFalse3;
        private System.Windows.Forms.TextBox txtDataFalse1;
        private System.Windows.Forms.Label lblDataFalse2;
        private System.Windows.Forms.TextBox txtDataFalse2;
        private System.Windows.Forms.Label lblDataFalse1;
        private System.Windows.Forms.Label lblData5;
        private System.Windows.Forms.TextBox txtData5;
        private System.Windows.Forms.Label lblData4;
        private System.Windows.Forms.TextBox txtData4;
        private System.Windows.Forms.Label lblData3;
        private System.Windows.Forms.TextBox txtData3;
    }
}
