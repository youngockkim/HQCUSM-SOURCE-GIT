namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionRework
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
            this.cdvRetOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvRwkOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvRwkCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRwkCode = new System.Windows.Forms.Label();
            this.lblRetOption = new System.Windows.Forms.Label();
            this.cboRetOption = new System.Windows.Forms.ComboBox();
            this.cdvRwkStopOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvRefOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRefOper = new System.Windows.Forms.Label();
            this.cdvRwkFlow = new Miracom.MESCore.Controls.udcFlow();
            this.cdvRetFlow = new Miracom.MESCore.Controls.udcFlow();
            this.chkMultiTrans = new System.Windows.Forms.CheckBox();
            this.grpActionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRefOper)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.chkMultiTrans);
            this.grpActionValue.Controls.Add(this.cdvRetFlow);
            this.grpActionValue.Controls.Add(this.cdvRwkFlow);
            this.grpActionValue.Controls.Add(this.cdvRefOper);
            this.grpActionValue.Controls.Add(this.lblRefOper);
            this.grpActionValue.Controls.Add(this.lblRetOption);
            this.grpActionValue.Controls.Add(this.cboRetOption);
            this.grpActionValue.Controls.Add(this.cdvRwkStopOper);
            this.grpActionValue.Controls.Add(this.cdvRetOper);
            this.grpActionValue.Controls.Add(this.cdvRwkOper);
            this.grpActionValue.Controls.Add(this.cdvRwkCode);
            this.grpActionValue.Controls.Add(this.lblRwkCode);
            // 
            // cdvRetOper
            // 
            this.cdvRetOper.AddEmptyRowToLast = false;
            this.cdvRetOper.AddEmptyRowToTop = false;
            this.cdvRetOper.ButtonWidth = 21;
            this.cdvRetOper.DisplaySubItemIndex = 0;
            this.cdvRetOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetOper.LabelText = "Return Oper";
            this.cdvRetOper.LabelWidth = 86;
            this.cdvRetOper.ListCond_ExtFactory = "";
            this.cdvRetOper.ListCond_Step = '1';
            this.cdvRetOper.Location = new System.Drawing.Point(6, 155);
            this.cdvRetOper.Name = "cdvRetOper";
            this.cdvRetOper.ReadOnly = false;
            this.cdvRetOper.SearchSubItemIndex = 0;
            this.cdvRetOper.SelectedDescIndex = 1;
            this.cdvRetOper.SelectedSubItemIndex = 0;
            this.cdvRetOper.Size = new System.Drawing.Size(228, 20);
            this.cdvRetOper.TabIndex = 7;
            this.cdvRetOper.TextBoxWidth = 142;
            this.cdvRetOper.VisibleButton = true;
            this.cdvRetOper.VisibleColumnHeader = false;
            this.cdvRetOper.VisibleDescription = false;
            // 
            // cdvRwkOper
            // 
            this.cdvRwkOper.AddEmptyRowToLast = false;
            this.cdvRwkOper.AddEmptyRowToTop = false;
            this.cdvRwkOper.ButtonWidth = 21;
            this.cdvRwkOper.DisplaySubItemIndex = 0;
            this.cdvRwkOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkOper.LabelText = "Rework Oper";
            this.cdvRwkOper.LabelWidth = 86;
            this.cdvRwkOper.ListCond_ExtFactory = "";
            this.cdvRwkOper.ListCond_Step = '1';
            this.cdvRwkOper.Location = new System.Drawing.Point(6, 107);
            this.cdvRwkOper.Name = "cdvRwkOper";
            this.cdvRwkOper.ReadOnly = false;
            this.cdvRwkOper.SearchSubItemIndex = 0;
            this.cdvRwkOper.SelectedDescIndex = 1;
            this.cdvRwkOper.SelectedSubItemIndex = 0;
            this.cdvRwkOper.Size = new System.Drawing.Size(228, 20);
            this.cdvRwkOper.TabIndex = 5;
            this.cdvRwkOper.TextBoxWidth = 142;
            this.cdvRwkOper.VisibleButton = true;
            this.cdvRwkOper.VisibleColumnHeader = false;
            this.cdvRwkOper.VisibleDescription = false;
            this.cdvRwkOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkOper_SelectedItemChanged);
            // 
            // cdvRwkCode
            // 
            this.cdvRwkCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRwkCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRwkCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRwkCode.BtnToolTipText = "";
            this.cdvRwkCode.DescText = "";
            this.cdvRwkCode.DisplaySubItemIndex = -1;
            this.cdvRwkCode.DisplayText = "";
            this.cdvRwkCode.Focusing = null;
            this.cdvRwkCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkCode.Index = 0;
            this.cdvRwkCode.IsViewBtnImage = false;
            this.cdvRwkCode.Location = new System.Drawing.Point(92, 59);
            this.cdvRwkCode.MaxLength = 10;
            this.cdvRwkCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRwkCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRwkCode.Name = "cdvRwkCode";
            this.cdvRwkCode.ReadOnly = true;
            this.cdvRwkCode.SearchSubItemIndex = 0;
            this.cdvRwkCode.SelectedDescIndex = -1;
            this.cdvRwkCode.SelectedSubItemIndex = -1;
            this.cdvRwkCode.SelectionStart = 0;
            this.cdvRwkCode.Size = new System.Drawing.Size(142, 20);
            this.cdvRwkCode.SmallImageList = null;
            this.cdvRwkCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRwkCode.TabIndex = 3;
            this.cdvRwkCode.TextBoxToolTipText = "";
            this.cdvRwkCode.TextBoxWidth = 142;
            this.cdvRwkCode.VisibleButton = true;
            this.cdvRwkCode.VisibleColumnHeader = false;
            this.cdvRwkCode.VisibleDescription = false;
            this.cdvRwkCode.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkCode_SelectedItemChanged);
            this.cdvRwkCode.ButtonPress += new System.EventHandler(this.cdvRwkCode_ButtonPress);
            // 
            // lblRwkCode
            // 
            this.lblRwkCode.AutoSize = true;
            this.lblRwkCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRwkCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRwkCode.Location = new System.Drawing.Point(6, 63);
            this.lblRwkCode.Name = "lblRwkCode";
            this.lblRwkCode.Size = new System.Drawing.Size(72, 13);
            this.lblRwkCode.TabIndex = 2;
            this.lblRwkCode.Text = "Rework Code";
            this.lblRwkCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRetOption
            // 
            this.lblRetOption.AutoSize = true;
            this.lblRetOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetOption.Location = new System.Drawing.Point(6, 210);
            this.lblRetOption.Name = "lblRetOption";
            this.lblRetOption.Size = new System.Drawing.Size(73, 13);
            this.lblRetOption.TabIndex = 9;
            this.lblRetOption.Text = "Return Option";
            // 
            // cboRetOption
            // 
            this.cboRetOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRetOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRetOption.FormattingEnabled = true;
            this.cboRetOption.Items.AddRange(new object[] {
            "Keep Rework",
            "Clear Rework",
            "Clear Rework and Move to Next Operation",
            "Keep Rework and Move to Next Operation"});
            this.cboRetOption.Location = new System.Drawing.Point(17, 227);
            this.cboRetOption.Name = "cboRetOption";
            this.cboRetOption.Size = new System.Drawing.Size(217, 21);
            this.cboRetOption.TabIndex = 10;
            // 
            // cdvRwkStopOper
            // 
            this.cdvRwkStopOper.AddEmptyRowToLast = false;
            this.cdvRwkStopOper.AddEmptyRowToTop = false;
            this.cdvRwkStopOper.ButtonWidth = 21;
            this.cdvRwkStopOper.DisplaySubItemIndex = 0;
            this.cdvRwkStopOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkStopOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkStopOper.LabelText = "Stop Oper";
            this.cdvRwkStopOper.LabelWidth = 86;
            this.cdvRwkStopOper.ListCond_ExtFactory = "";
            this.cdvRwkStopOper.ListCond_Step = '1';
            this.cdvRwkStopOper.Location = new System.Drawing.Point(6, 179);
            this.cdvRwkStopOper.Name = "cdvRwkStopOper";
            this.cdvRwkStopOper.ReadOnly = false;
            this.cdvRwkStopOper.SearchSubItemIndex = 0;
            this.cdvRwkStopOper.SelectedDescIndex = 1;
            this.cdvRwkStopOper.SelectedSubItemIndex = 0;
            this.cdvRwkStopOper.Size = new System.Drawing.Size(228, 20);
            this.cdvRwkStopOper.TabIndex = 8;
            this.cdvRwkStopOper.TextBoxWidth = 142;
            this.cdvRwkStopOper.VisibleButton = true;
            this.cdvRwkStopOper.VisibleColumnHeader = false;
            this.cdvRwkStopOper.VisibleDescription = false;
            this.cdvRwkStopOper.ButtonPress += new System.EventHandler(this.cdvRwkStopOper_ButtonPress);
            // 
            // cdvRefOper
            // 
            this.cdvRefOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRefOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRefOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRefOper.BtnToolTipText = "";
            this.cdvRefOper.DescText = "";
            this.cdvRefOper.DisplaySubItemIndex = -1;
            this.cdvRefOper.DisplayText = "";
            this.cdvRefOper.Focusing = null;
            this.cdvRefOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRefOper.Index = 0;
            this.cdvRefOper.IsViewBtnImage = false;
            this.cdvRefOper.Location = new System.Drawing.Point(92, 35);
            this.cdvRefOper.MaxLength = 10;
            this.cdvRefOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRefOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRefOper.Name = "cdvRefOper";
            this.cdvRefOper.ReadOnly = true;
            this.cdvRefOper.SearchSubItemIndex = 0;
            this.cdvRefOper.SelectedDescIndex = -1;
            this.cdvRefOper.SelectedSubItemIndex = -1;
            this.cdvRefOper.SelectionStart = 0;
            this.cdvRefOper.Size = new System.Drawing.Size(142, 20);
            this.cdvRefOper.SmallImageList = null;
            this.cdvRefOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRefOper.TabIndex = 1;
            this.cdvRefOper.TextBoxToolTipText = "";
            this.cdvRefOper.TextBoxWidth = 142;
            this.cdvRefOper.VisibleButton = true;
            this.cdvRefOper.VisibleColumnHeader = false;
            this.cdvRefOper.VisibleDescription = false;
            this.cdvRefOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRefOper_SelectedItemChanged);
            // 
            // lblRefOper
            // 
            this.lblRefOper.AutoSize = true;
            this.lblRefOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRefOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefOper.Location = new System.Drawing.Point(6, 17);
            this.lblRefOper.Name = "lblRefOper";
            this.lblRefOper.Size = new System.Drawing.Size(174, 13);
            this.lblRefOper.TabIndex = 0;
            this.lblRefOper.Text = "Rework Code Reference Operation";
            this.lblRefOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvRwkFlow
            // 
            this.cdvRwkFlow.AddEmptyRowToLast = false;
            this.cdvRwkFlow.AddEmptyRowToTop = false;
            this.cdvRwkFlow.ButtonWidth = 21;
            this.cdvRwkFlow.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvRwkFlow.DisplaySubItemIndex = 0;
            this.cdvRwkFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkFlow.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvRwkFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkFlow.LabelText = "Rework Flow";
            this.cdvRwkFlow.LabelWidth = 86;
            this.cdvRwkFlow.ListCond_ExtFactory = "";
            this.cdvRwkFlow.ListCond_Step = '1';
            this.cdvRwkFlow.Location = new System.Drawing.Point(6, 83);
            this.cdvRwkFlow.Name = "cdvRwkFlow";
            this.cdvRwkFlow.ReadOnly = false;
            this.cdvRwkFlow.SearchSubItemIndex = 0;
            this.cdvRwkFlow.SelectedDescIndex = 1;
            this.cdvRwkFlow.SelectedSubItemIndex = 0;
            this.cdvRwkFlow.Size = new System.Drawing.Size(228, 20);
            this.cdvRwkFlow.TabIndex = 4;
            this.cdvRwkFlow.TextBoxWidth = 142;
            this.cdvRwkFlow.VisibleButton = true;
            this.cdvRwkFlow.VisibleColumnHeader = false;
            this.cdvRwkFlow.VisibleDescription = false;
            this.cdvRwkFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkFlow_SelectedItemChanged);
            // 
            // cdvRetFlow
            // 
            this.cdvRetFlow.AddEmptyRowToLast = false;
            this.cdvRetFlow.AddEmptyRowToTop = false;
            this.cdvRetFlow.ButtonWidth = 21;
            this.cdvRetFlow.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvRetFlow.DisplaySubItemIndex = 0;
            this.cdvRetFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetFlow.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvRetFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetFlow.LabelText = "Return Flow";
            this.cdvRetFlow.LabelWidth = 86;
            this.cdvRetFlow.ListCond_ExtFactory = "";
            this.cdvRetFlow.ListCond_Step = '1';
            this.cdvRetFlow.Location = new System.Drawing.Point(6, 131);
            this.cdvRetFlow.Name = "cdvRetFlow";
            this.cdvRetFlow.ReadOnly = false;
            this.cdvRetFlow.SearchSubItemIndex = 0;
            this.cdvRetFlow.SelectedDescIndex = 1;
            this.cdvRetFlow.SelectedSubItemIndex = 0;
            this.cdvRetFlow.Size = new System.Drawing.Size(228, 20);
            this.cdvRetFlow.TabIndex = 6;
            this.cdvRetFlow.TextBoxWidth = 142;
            this.cdvRetFlow.VisibleButton = true;
            this.cdvRetFlow.VisibleColumnHeader = false;
            this.cdvRetFlow.VisibleDescription = false;
            this.cdvRetFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRetFlow_SelectedItemChanged);
            // 
            // chkMultiTrans
            // 
            this.chkMultiTrans.AutoSize = true;
            this.chkMultiTrans.Location = new System.Drawing.Point(6, 256);
            this.chkMultiTrans.Name = "chkMultiTrans";
            this.chkMultiTrans.Size = new System.Drawing.Size(146, 17);
            this.chkMultiTrans.TabIndex = 11;
            this.chkMultiTrans.Text = "Perform Multi Transaction";
            this.chkMultiTrans.UseVisualStyleBackColor = true;
            // 
            // udcStepActionRework
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcStepActionRework";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRefOper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MESCore.Controls.udcOperation cdvRetOper;
        private MESCore.Controls.udcOperation cdvRwkOper;
        private UI.Controls.MCCodeView.MCCodeView cdvRwkCode;
        private System.Windows.Forms.Label lblRwkCode;
        private System.Windows.Forms.Label lblRetOption;
        private System.Windows.Forms.ComboBox cboRetOption;
        private MESCore.Controls.udcOperation cdvRwkStopOper;
        private UI.Controls.MCCodeView.MCCodeView cdvRefOper;
        private System.Windows.Forms.Label lblRefOper;
        private MESCore.Controls.udcFlow cdvRetFlow;
        private MESCore.Controls.udcFlow cdvRwkFlow;
        private System.Windows.Forms.CheckBox chkMultiTrans;
    }
}
