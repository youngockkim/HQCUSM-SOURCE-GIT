namespace Custom.HanwhaQcell.USModule
{
    partial class frmJobChangeCopyToPopup
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.PnlTop1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtToWorkOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvToLine = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFromMatID = new System.Windows.Forms.TextBox();
            this.txtFromMatDesc = new System.Windows.Forms.TextBox();
            this.txtFromStartDate = new System.Windows.Forms.TextBox();
            this.txtFromWorkOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cdvFromLine = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtToOrderSeq = new System.Windows.Forms.TextBox();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.PnlTop1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToLine)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromLine)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(326, 7);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCopy);
            this.pnlBottom.Location = new System.Drawing.Point(0, 201);
            this.pnlBottom.Size = new System.Drawing.Size(584, 40);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCopy, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.PnlTop1);
            this.pnlCenter.Size = new System.Drawing.Size(584, 201);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Work Order";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(623, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 26);
            this.btnSearch.TabIndex = 124;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // PnlTop1
            // 
            this.PnlTop1.Controls.Add(this.groupBox1);
            this.PnlTop1.Controls.Add(this.groupBox2);
            this.PnlTop1.Controls.Add(this.btnSearch);
            this.PnlTop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTop1.Location = new System.Drawing.Point(0, 0);
            this.PnlTop1.Name = "PnlTop1";
            this.PnlTop1.Size = new System.Drawing.Size(584, 201);
            this.PnlTop1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtToOrderSeq);
            this.groupBox1.Controls.Add(this.txtToWorkOrder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cdvToLine);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 82);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From Work Order Information";
            // 
            // txtToWorkOrder
            // 
            this.txtToWorkOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToWorkOrder.Location = new System.Drawing.Point(93, 28);
            this.txtToWorkOrder.MaxLength = 100;
            this.txtToWorkOrder.Name = "txtToWorkOrder";
            this.txtToWorkOrder.ReadOnly = true;
            this.txtToWorkOrder.Size = new System.Drawing.Size(116, 20);
            this.txtToWorkOrder.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "Work Order";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(21, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "Work Line";
            // 
            // cdvToLine
            // 
            this.cdvToLine.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToLine.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToLine.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToLine.BtnToolTipText = "";
            this.cdvToLine.ButtonWidth = 20;
            this.cdvToLine.DescText = "";
            this.cdvToLine.DisplaySubItemIndex = 0;
            this.cdvToLine.DisplayText = "";
            this.cdvToLine.Focusing = null;
            this.cdvToLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToLine.Index = 0;
            this.cdvToLine.IsViewBtnImage = false;
            this.cdvToLine.Location = new System.Drawing.Point(93, 54);
            this.cdvToLine.MaxLength = 40;
            this.cdvToLine.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToLine.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToLine.MultiSelect = false;
            this.cdvToLine.Name = "cdvToLine";
            this.cdvToLine.ReadOnly = false;
            this.cdvToLine.SameWidthHeightOfButton = false;
            this.cdvToLine.SearchSubItemIndex = 0;
            this.cdvToLine.SelectedDescIndex = 1;
            this.cdvToLine.SelectedDescToQueryText = "";
            this.cdvToLine.SelectedSubItemIndex = 0;
            this.cdvToLine.SelectedValueToQueryText = "";
            this.cdvToLine.SelectionStart = 0;
            this.cdvToLine.Size = new System.Drawing.Size(303, 21);
            this.cdvToLine.SmallImageList = null;
            this.cdvToLine.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToLine.TabIndex = 122;
            this.cdvToLine.TextBoxToolTipText = "";
            this.cdvToLine.TextBoxWidth = 135;
            this.cdvToLine.VisibleButton = true;
            this.cdvToLine.VisibleColumnHeader = false;
            this.cdvToLine.VisibleDescription = true;
            this.cdvToLine.ButtonPress += new System.EventHandler(this.cdvToLine_ButtonPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtFromMatID);
            this.groupBox2.Controls.Add(this.txtFromMatDesc);
            this.groupBox2.Controls.Add(this.txtFromStartDate);
            this.groupBox2.Controls.Add(this.txtFromWorkOrder);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cdvFromLine);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 119);
            this.groupBox2.TabIndex = 127;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From Work Order Information";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 129;
            this.label6.Text = "Material";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFromMatID
            // 
            this.txtFromMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMatID.Location = new System.Drawing.Point(93, 52);
            this.txtFromMatID.MaxLength = 100;
            this.txtFromMatID.Name = "txtFromMatID";
            this.txtFromMatID.ReadOnly = true;
            this.txtFromMatID.Size = new System.Drawing.Size(129, 20);
            this.txtFromMatID.TabIndex = 128;
            // 
            // txtFromMatDesc
            // 
            this.txtFromMatDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMatDesc.Location = new System.Drawing.Point(228, 52);
            this.txtFromMatDesc.MaxLength = 100;
            this.txtFromMatDesc.Name = "txtFromMatDesc";
            this.txtFromMatDesc.ReadOnly = true;
            this.txtFromMatDesc.Size = new System.Drawing.Size(344, 20);
            this.txtFromMatDesc.TabIndex = 127;
            // 
            // txtFromStartDate
            // 
            this.txtFromStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromStartDate.Location = new System.Drawing.Point(93, 79);
            this.txtFromStartDate.MaxLength = 100;
            this.txtFromStartDate.Name = "txtFromStartDate";
            this.txtFromStartDate.ReadOnly = true;
            this.txtFromStartDate.Size = new System.Drawing.Size(131, 20);
            this.txtFromStartDate.TabIndex = 126;
            // 
            // txtFromWorkOrder
            // 
            this.txtFromWorkOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromWorkOrder.Location = new System.Drawing.Point(93, 25);
            this.txtFromWorkOrder.MaxLength = 100;
            this.txtFromWorkOrder.Name = "txtFromWorkOrder";
            this.txtFromWorkOrder.ReadOnly = true;
            this.txtFromWorkOrder.Size = new System.Drawing.Size(129, 20);
            this.txtFromWorkOrder.TabIndex = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 125;
            this.label3.Text = "Start Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 119;
            this.label4.Text = "Work Order";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(243, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 123;
            this.label5.Text = "Work Line";
            // 
            // cdvFromLine
            // 
            this.cdvFromLine.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFromLine.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFromLine.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFromLine.BtnToolTipText = "";
            this.cdvFromLine.ButtonWidth = 20;
            this.cdvFromLine.DescText = "";
            this.cdvFromLine.DisplaySubItemIndex = 0;
            this.cdvFromLine.DisplayText = "";
            this.cdvFromLine.Focusing = null;
            this.cdvFromLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFromLine.Index = 0;
            this.cdvFromLine.IsViewBtnImage = false;
            this.cdvFromLine.Location = new System.Drawing.Point(309, 79);
            this.cdvFromLine.MaxLength = 40;
            this.cdvFromLine.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFromLine.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFromLine.MultiSelect = false;
            this.cdvFromLine.Name = "cdvFromLine";
            this.cdvFromLine.ReadOnly = true;
            this.cdvFromLine.SameWidthHeightOfButton = false;
            this.cdvFromLine.SearchSubItemIndex = 0;
            this.cdvFromLine.SelectedDescIndex = 1;
            this.cdvFromLine.SelectedDescToQueryText = "";
            this.cdvFromLine.SelectedSubItemIndex = 0;
            this.cdvFromLine.SelectedValueToQueryText = "";
            this.cdvFromLine.SelectionStart = 0;
            this.cdvFromLine.Size = new System.Drawing.Size(263, 21);
            this.cdvFromLine.SmallImageList = null;
            this.cdvFromLine.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFromLine.TabIndex = 122;
            this.cdvFromLine.TextBoxToolTipText = "";
            this.cdvFromLine.TextBoxWidth = 100;
            this.cdvFromLine.VisibleButton = false;
            this.cdvFromLine.VisibleColumnHeader = false;
            this.cdvFromLine.VisibleDescription = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(380, 7);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 26);
            this.btnCopy.TabIndex = 126;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtToOrderSeq
            // 
            this.txtToOrderSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToOrderSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToOrderSeq.Location = new System.Drawing.Point(215, 28);
            this.txtToOrderSeq.MaxLength = 5;
            this.txtToOrderSeq.Name = "txtToOrderSeq";
            this.txtToOrderSeq.Size = new System.Drawing.Size(44, 20);
            this.txtToOrderSeq.TabIndex = 126;
            // 
            // frmJobChangeCopyToPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 241);
            this.MaximumSize = new System.Drawing.Size(600, 280);
            this.MinimumSize = new System.Drawing.Size(600, 280);
            this.Name = "frmJobChangeCopyToPopup";
            this.Text = "View Work Order";
            this.Activated += new System.EventHandler(this.frmJobChangeCopyToPopup_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.PnlTop1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToLine)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlTop1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToLine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFromMatDesc;
        private System.Windows.Forms.TextBox txtFromStartDate;
        private System.Windows.Forms.TextBox txtFromWorkOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFromLine;
        private System.Windows.Forms.TextBox txtToWorkOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFromMatID;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtToOrderSeq;

    }
}