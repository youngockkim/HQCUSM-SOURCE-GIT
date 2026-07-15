namespace Miracom.WIPCore.Setup
{
    partial class udcFutureActionRework
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
            this.cboRetOption = new System.Windows.Forms.ComboBox();
            this.cdvRwkStopOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvRetOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvRetFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvRwkOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvRwkFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvRwkCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRwkCode = new System.Windows.Forms.Label();
            this.grpActionFalse = new System.Windows.Forms.GroupBox();
            this.cboRetOptionFalse = new System.Windows.Forms.ComboBox();
            this.cdvRwkStopOperFalse = new Miracom.MESCore.Controls.udcOperation();
            this.cdvRetOperFalse = new Miracom.MESCore.Controls.udcOperation();
            this.cdvRetFlowFalse = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvRwkOperFalse = new Miracom.MESCore.Controls.udcOperation();
            this.cdvRwkFlowFalse = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvRwkCodeFalse = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRwkCodeFalse = new System.Windows.Forms.Label();
            this.lblRetOption = new System.Windows.Forms.Label();
            this.lblRetOptionFalse = new System.Windows.Forms.Label();
            this.grpActionValue.SuspendLayout();
            this.pnlActionValueTop.SuspendLayout();
            this.grpActionTrue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkCode)).BeginInit();
            this.grpActionFalse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkCodeFalse)).BeginInit();
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
            this.pnlActionValueTop.Location = new System.Drawing.Point(3, 17);
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
            this.cboActionType.Size = new System.Drawing.Size(250, 20);
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
            this.lblActionType.Size = new System.Drawing.Size(73, 12);
            this.lblActionType.TabIndex = 0;
            this.lblActionType.Text = "Action Type";
            // 
            // grpActionTrue
            // 
            this.grpActionTrue.Controls.Add(this.lblRetOption);
            this.grpActionTrue.Controls.Add(this.cboRetOption);
            this.grpActionTrue.Controls.Add(this.cdvRwkStopOper);
            this.grpActionTrue.Controls.Add(this.cdvRetOper);
            this.grpActionTrue.Controls.Add(this.cdvRetFlow);
            this.grpActionTrue.Controls.Add(this.cdvRwkOper);
            this.grpActionTrue.Controls.Add(this.cdvRwkFlow);
            this.grpActionTrue.Controls.Add(this.cdvRwkCode);
            this.grpActionTrue.Controls.Add(this.lblRwkCode);
            this.grpActionTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionTrue.Location = new System.Drawing.Point(3, 43);
            this.grpActionTrue.Name = "grpActionTrue";
            this.grpActionTrue.Size = new System.Drawing.Size(524, 142);
            this.grpActionTrue.TabIndex = 1;
            this.grpActionTrue.TabStop = false;
            this.grpActionTrue.Text = "True Action";
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
            this.cboRetOption.Location = new System.Drawing.Point(301, 115);
            this.cboRetOption.Name = "cboRetOption";
            this.cboRetOption.Size = new System.Drawing.Size(217, 20);
            this.cboRetOption.TabIndex = 14;
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
            this.cdvRwkStopOper.Location = new System.Drawing.Point(301, 66);
            this.cdvRwkStopOper.Name = "cdvRwkStopOper";
            this.cdvRwkStopOper.ReadOnly = false;
            this.cdvRwkStopOper.SearchSubItemIndex = 0;
            this.cdvRwkStopOper.SelectedDescIndex = 1;
            this.cdvRwkStopOper.SelectedSubItemIndex = 0;
            this.cdvRwkStopOper.Size = new System.Drawing.Size(217, 20);
            this.cdvRwkStopOper.TabIndex = 7;
            this.cdvRwkStopOper.TextBoxWidth = 131;
            this.cdvRwkStopOper.VisibleButton = true;
            this.cdvRwkStopOper.VisibleColumnHeader = false;
            this.cdvRwkStopOper.VisibleDescription = false;
            this.cdvRwkStopOper.ButtonPress += new System.EventHandler(this.cdvRwkStopOper_ButtonPress);
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
            this.cdvRetOper.Location = new System.Drawing.Point(8, 116);
            this.cdvRetOper.Name = "cdvRetOper";
            this.cdvRetOper.ReadOnly = false;
            this.cdvRetOper.SearchSubItemIndex = 0;
            this.cdvRetOper.SelectedDescIndex = 1;
            this.cdvRetOper.SelectedSubItemIndex = 0;
            this.cdvRetOper.Size = new System.Drawing.Size(266, 20);
            this.cdvRetOper.TabIndex = 5;
            this.cdvRetOper.TextBoxWidth = 180;
            this.cdvRetOper.VisibleButton = true;
            this.cdvRetOper.VisibleColumnHeader = false;
            this.cdvRetOper.VisibleDescription = false;
            this.cdvRetOper.ButtonPress += new System.EventHandler(this.cdvRetOper_ButtonPress);
            // 
            // cdvRetFlow
            // 
            this.cdvRetFlow.AddEmptyRowToLast = false;
            this.cdvRetFlow.AddEmptyRowToTop = false;
            this.cdvRetFlow.DisplaySubItemIndex = 0;
            this.cdvRetFlow.FlowReadOnly = false;
            this.cdvRetFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetFlow.LabelText = "Return Flow";
            this.cdvRetFlow.LabelWidth = 86;
            this.cdvRetFlow.ListCond_ExtFactory = "";
            this.cdvRetFlow.ListCond_Step = '2';
            this.cdvRetFlow.Location = new System.Drawing.Point(8, 91);
            this.cdvRetFlow.Name = "cdvRetFlow";
            this.cdvRetFlow.SearchSubItemIndex = 0;
            this.cdvRetFlow.SelectedDescIndex = -1;
            this.cdvRetFlow.SelectedSubItemIndex = 0;
            this.cdvRetFlow.SequenceReadOnly = false;
            this.cdvRetFlow.Size = new System.Drawing.Size(266, 20);
            this.cdvRetFlow.TabIndex = 4;
            this.cdvRetFlow.VisibleColumnHeader = false;
            this.cdvRetFlow.VisibleDescription = false;
            this.cdvRetFlow.VisibleFlowButton = true;
            this.cdvRetFlow.VisibleSequenceButton = true;
            this.cdvRetFlow.WidthButton = 20;
            this.cdvRetFlow.WidthFlowAndSequence = 180;
            this.cdvRetFlow.WidthSequence = 50;
            this.cdvRetFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRetFlow_SelectedItemChanged);
            this.cdvRetFlow.FlowButtonPress += new System.EventHandler(this.cdvRetFlow_FlowButtonPress);
            this.cdvRetFlow.SeqButtonPress += new System.EventHandler(this.cdvRetFlow_SeqButtonPress);
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
            this.cdvRwkOper.Location = new System.Drawing.Point(8, 66);
            this.cdvRwkOper.Name = "cdvRwkOper";
            this.cdvRwkOper.ReadOnly = false;
            this.cdvRwkOper.SearchSubItemIndex = 0;
            this.cdvRwkOper.SelectedDescIndex = 1;
            this.cdvRwkOper.SelectedSubItemIndex = 0;
            this.cdvRwkOper.Size = new System.Drawing.Size(266, 20);
            this.cdvRwkOper.TabIndex = 3;
            this.cdvRwkOper.TextBoxWidth = 180;
            this.cdvRwkOper.VisibleButton = true;
            this.cdvRwkOper.VisibleColumnHeader = false;
            this.cdvRwkOper.VisibleDescription = false;
            this.cdvRwkOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkOper_SelectedItemChanged);
            this.cdvRwkOper.ButtonPress += new System.EventHandler(this.cdvRwkOper_ButtonPress);
            // 
            // cdvRwkFlow
            // 
            this.cdvRwkFlow.AddEmptyRowToLast = false;
            this.cdvRwkFlow.AddEmptyRowToTop = false;
            this.cdvRwkFlow.DisplaySubItemIndex = 0;
            this.cdvRwkFlow.FlowReadOnly = false;
            this.cdvRwkFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkFlow.LabelText = "Rework Flow";
            this.cdvRwkFlow.LabelWidth = 86;
            this.cdvRwkFlow.ListCond_ExtFactory = "";
            this.cdvRwkFlow.ListCond_Step = '2';
            this.cdvRwkFlow.Location = new System.Drawing.Point(8, 41);
            this.cdvRwkFlow.Name = "cdvRwkFlow";
            this.cdvRwkFlow.SearchSubItemIndex = 0;
            this.cdvRwkFlow.SelectedDescIndex = -1;
            this.cdvRwkFlow.SelectedSubItemIndex = 0;
            this.cdvRwkFlow.SequenceReadOnly = false;
            this.cdvRwkFlow.Size = new System.Drawing.Size(266, 20);
            this.cdvRwkFlow.TabIndex = 2;
            this.cdvRwkFlow.VisibleColumnHeader = false;
            this.cdvRwkFlow.VisibleDescription = false;
            this.cdvRwkFlow.VisibleFlowButton = true;
            this.cdvRwkFlow.VisibleSequenceButton = true;
            this.cdvRwkFlow.WidthButton = 20;
            this.cdvRwkFlow.WidthFlowAndSequence = 180;
            this.cdvRwkFlow.WidthSequence = 50;
            this.cdvRwkFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkFlow_FlowSelectedItemChanged);
            this.cdvRwkFlow.FlowButtonPress += new System.EventHandler(this.cdvRwkFlow_FlowButtonPress);
            this.cdvRwkFlow.SeqButtonPress += new System.EventHandler(this.cdvRwkFlow_SeqButtonPress);
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
            this.cdvRwkCode.Location = new System.Drawing.Point(94, 16);
            this.cdvRwkCode.MaxLength = 10;
            this.cdvRwkCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRwkCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRwkCode.Name = "cdvRwkCode";
            this.cdvRwkCode.ReadOnly = true;
            this.cdvRwkCode.SearchSubItemIndex = 0;
            this.cdvRwkCode.SelectedDescIndex = -1;
            this.cdvRwkCode.SelectedSubItemIndex = -1;
            this.cdvRwkCode.SelectionStart = 0;
            this.cdvRwkCode.Size = new System.Drawing.Size(180, 20);
            this.cdvRwkCode.SmallImageList = null;
            this.cdvRwkCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRwkCode.TabIndex = 1;
            this.cdvRwkCode.TextBoxToolTipText = "";
            this.cdvRwkCode.TextBoxWidth = 180;
            this.cdvRwkCode.VisibleButton = true;
            this.cdvRwkCode.VisibleColumnHeader = false;
            this.cdvRwkCode.VisibleDescription = false;
            this.cdvRwkCode.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkCode_SelectedItemChanged);
            // 
            // lblRwkCode
            // 
            this.lblRwkCode.AutoSize = true;
            this.lblRwkCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRwkCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRwkCode.Location = new System.Drawing.Point(8, 20);
            this.lblRwkCode.Name = "lblRwkCode";
            this.lblRwkCode.Size = new System.Drawing.Size(72, 13);
            this.lblRwkCode.TabIndex = 0;
            this.lblRwkCode.Text = "Rework Code";
            this.lblRwkCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpActionFalse
            // 
            this.grpActionFalse.Controls.Add(this.lblRetOptionFalse);
            this.grpActionFalse.Controls.Add(this.cboRetOptionFalse);
            this.grpActionFalse.Controls.Add(this.cdvRwkStopOperFalse);
            this.grpActionFalse.Controls.Add(this.cdvRetOperFalse);
            this.grpActionFalse.Controls.Add(this.cdvRetFlowFalse);
            this.grpActionFalse.Controls.Add(this.cdvRwkOperFalse);
            this.grpActionFalse.Controls.Add(this.cdvRwkFlowFalse);
            this.grpActionFalse.Controls.Add(this.cdvRwkCodeFalse);
            this.grpActionFalse.Controls.Add(this.lblRwkCodeFalse);
            this.grpActionFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActionFalse.Location = new System.Drawing.Point(3, 185);
            this.grpActionFalse.Name = "grpActionFalse";
            this.grpActionFalse.Size = new System.Drawing.Size(524, 142);
            this.grpActionFalse.TabIndex = 2;
            this.grpActionFalse.TabStop = false;
            this.grpActionFalse.Text = "False Action";
            // 
            // cboRetOptionFalse
            // 
            this.cboRetOptionFalse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRetOptionFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRetOptionFalse.FormattingEnabled = true;
            this.cboRetOptionFalse.Items.AddRange(new object[] {
            "Keep Rework",
            "Clear Rework",
            "Clear Rework and Move to Next Operation",
            "Keep Rework and Move to Next Operation"});
            this.cboRetOptionFalse.Location = new System.Drawing.Point(301, 115);
            this.cboRetOptionFalse.Name = "cboRetOptionFalse";
            this.cboRetOptionFalse.Size = new System.Drawing.Size(217, 20);
            this.cboRetOptionFalse.TabIndex = 16;
            // 
            // cdvRwkStopOperFalse
            // 
            this.cdvRwkStopOperFalse.AddEmptyRowToLast = false;
            this.cdvRwkStopOperFalse.AddEmptyRowToTop = false;
            this.cdvRwkStopOperFalse.ButtonWidth = 21;
            this.cdvRwkStopOperFalse.DisplaySubItemIndex = 0;
            this.cdvRwkStopOperFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkStopOperFalse.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkStopOperFalse.LabelText = "Stop Oper";
            this.cdvRwkStopOperFalse.LabelWidth = 86;
            this.cdvRwkStopOperFalse.ListCond_ExtFactory = "";
            this.cdvRwkStopOperFalse.ListCond_Step = '1';
            this.cdvRwkStopOperFalse.Location = new System.Drawing.Point(301, 66);
            this.cdvRwkStopOperFalse.Name = "cdvRwkStopOperFalse";
            this.cdvRwkStopOperFalse.ReadOnly = false;
            this.cdvRwkStopOperFalse.SearchSubItemIndex = 0;
            this.cdvRwkStopOperFalse.SelectedDescIndex = 1;
            this.cdvRwkStopOperFalse.SelectedSubItemIndex = 0;
            this.cdvRwkStopOperFalse.Size = new System.Drawing.Size(217, 20);
            this.cdvRwkStopOperFalse.TabIndex = 8;
            this.cdvRwkStopOperFalse.TextBoxWidth = 131;
            this.cdvRwkStopOperFalse.VisibleButton = true;
            this.cdvRwkStopOperFalse.VisibleColumnHeader = false;
            this.cdvRwkStopOperFalse.VisibleDescription = false;
            this.cdvRwkStopOperFalse.ButtonPress += new System.EventHandler(this.cdvRwkStopOperFalse_ButtonPress);
            // 
            // cdvRetOperFalse
            // 
            this.cdvRetOperFalse.AddEmptyRowToLast = false;
            this.cdvRetOperFalse.AddEmptyRowToTop = false;
            this.cdvRetOperFalse.ButtonWidth = 21;
            this.cdvRetOperFalse.DisplaySubItemIndex = 0;
            this.cdvRetOperFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetOperFalse.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetOperFalse.LabelText = "Return Oper";
            this.cdvRetOperFalse.LabelWidth = 86;
            this.cdvRetOperFalse.ListCond_ExtFactory = "";
            this.cdvRetOperFalse.ListCond_Step = '1';
            this.cdvRetOperFalse.Location = new System.Drawing.Point(8, 116);
            this.cdvRetOperFalse.Name = "cdvRetOperFalse";
            this.cdvRetOperFalse.ReadOnly = false;
            this.cdvRetOperFalse.SearchSubItemIndex = 0;
            this.cdvRetOperFalse.SelectedDescIndex = 1;
            this.cdvRetOperFalse.SelectedSubItemIndex = 0;
            this.cdvRetOperFalse.Size = new System.Drawing.Size(266, 20);
            this.cdvRetOperFalse.TabIndex = 5;
            this.cdvRetOperFalse.TextBoxWidth = 180;
            this.cdvRetOperFalse.VisibleButton = true;
            this.cdvRetOperFalse.VisibleColumnHeader = false;
            this.cdvRetOperFalse.VisibleDescription = false;
            this.cdvRetOperFalse.ButtonPress += new System.EventHandler(this.cdvRetOperFalse_ButtonPress);
            // 
            // cdvRetFlowFalse
            // 
            this.cdvRetFlowFalse.AddEmptyRowToLast = false;
            this.cdvRetFlowFalse.AddEmptyRowToTop = false;
            this.cdvRetFlowFalse.DisplaySubItemIndex = 0;
            this.cdvRetFlowFalse.FlowReadOnly = false;
            this.cdvRetFlowFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetFlowFalse.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetFlowFalse.LabelText = "Return Flow";
            this.cdvRetFlowFalse.LabelWidth = 86;
            this.cdvRetFlowFalse.ListCond_ExtFactory = "";
            this.cdvRetFlowFalse.ListCond_Step = '2';
            this.cdvRetFlowFalse.Location = new System.Drawing.Point(8, 91);
            this.cdvRetFlowFalse.Name = "cdvRetFlowFalse";
            this.cdvRetFlowFalse.SearchSubItemIndex = 0;
            this.cdvRetFlowFalse.SelectedDescIndex = -1;
            this.cdvRetFlowFalse.SelectedSubItemIndex = 0;
            this.cdvRetFlowFalse.SequenceReadOnly = false;
            this.cdvRetFlowFalse.Size = new System.Drawing.Size(266, 20);
            this.cdvRetFlowFalse.TabIndex = 4;
            this.cdvRetFlowFalse.VisibleColumnHeader = false;
            this.cdvRetFlowFalse.VisibleDescription = false;
            this.cdvRetFlowFalse.VisibleFlowButton = true;
            this.cdvRetFlowFalse.VisibleSequenceButton = true;
            this.cdvRetFlowFalse.WidthButton = 20;
            this.cdvRetFlowFalse.WidthFlowAndSequence = 180;
            this.cdvRetFlowFalse.WidthSequence = 50;
            this.cdvRetFlowFalse.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRetFlowFalse_SelectedItemChanged);
            this.cdvRetFlowFalse.FlowButtonPress += new System.EventHandler(this.cdvRetFlowFalse_FlowButtonPress);
            this.cdvRetFlowFalse.SeqButtonPress += new System.EventHandler(this.cdvRetFlowFalse_SeqButtonPress);
            // 
            // cdvRwkOperFalse
            // 
            this.cdvRwkOperFalse.AddEmptyRowToLast = false;
            this.cdvRwkOperFalse.AddEmptyRowToTop = false;
            this.cdvRwkOperFalse.ButtonWidth = 21;
            this.cdvRwkOperFalse.DisplaySubItemIndex = 0;
            this.cdvRwkOperFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkOperFalse.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkOperFalse.LabelText = "Rework Oper";
            this.cdvRwkOperFalse.LabelWidth = 86;
            this.cdvRwkOperFalse.ListCond_ExtFactory = "";
            this.cdvRwkOperFalse.ListCond_Step = '1';
            this.cdvRwkOperFalse.Location = new System.Drawing.Point(8, 66);
            this.cdvRwkOperFalse.Name = "cdvRwkOperFalse";
            this.cdvRwkOperFalse.ReadOnly = false;
            this.cdvRwkOperFalse.SearchSubItemIndex = 0;
            this.cdvRwkOperFalse.SelectedDescIndex = 1;
            this.cdvRwkOperFalse.SelectedSubItemIndex = 0;
            this.cdvRwkOperFalse.Size = new System.Drawing.Size(266, 20);
            this.cdvRwkOperFalse.TabIndex = 3;
            this.cdvRwkOperFalse.TextBoxWidth = 180;
            this.cdvRwkOperFalse.VisibleButton = true;
            this.cdvRwkOperFalse.VisibleColumnHeader = false;
            this.cdvRwkOperFalse.VisibleDescription = false;
            this.cdvRwkOperFalse.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkOperFalse_SelectedItemChanged);
            this.cdvRwkOperFalse.ButtonPress += new System.EventHandler(this.cdvRwkOperFalse_ButtonPress);
            // 
            // cdvRwkFlowFalse
            // 
            this.cdvRwkFlowFalse.AddEmptyRowToLast = false;
            this.cdvRwkFlowFalse.AddEmptyRowToTop = false;
            this.cdvRwkFlowFalse.DisplaySubItemIndex = 0;
            this.cdvRwkFlowFalse.FlowReadOnly = false;
            this.cdvRwkFlowFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkFlowFalse.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkFlowFalse.LabelText = "Rework Flow";
            this.cdvRwkFlowFalse.LabelWidth = 86;
            this.cdvRwkFlowFalse.ListCond_ExtFactory = "";
            this.cdvRwkFlowFalse.ListCond_Step = '2';
            this.cdvRwkFlowFalse.Location = new System.Drawing.Point(8, 41);
            this.cdvRwkFlowFalse.Name = "cdvRwkFlowFalse";
            this.cdvRwkFlowFalse.SearchSubItemIndex = 0;
            this.cdvRwkFlowFalse.SelectedDescIndex = -1;
            this.cdvRwkFlowFalse.SelectedSubItemIndex = 0;
            this.cdvRwkFlowFalse.SequenceReadOnly = false;
            this.cdvRwkFlowFalse.Size = new System.Drawing.Size(266, 20);
            this.cdvRwkFlowFalse.TabIndex = 2;
            this.cdvRwkFlowFalse.VisibleColumnHeader = false;
            this.cdvRwkFlowFalse.VisibleDescription = false;
            this.cdvRwkFlowFalse.VisibleFlowButton = true;
            this.cdvRwkFlowFalse.VisibleSequenceButton = true;
            this.cdvRwkFlowFalse.WidthButton = 20;
            this.cdvRwkFlowFalse.WidthFlowAndSequence = 180;
            this.cdvRwkFlowFalse.WidthSequence = 50;
            this.cdvRwkFlowFalse.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkFlowFalse_FlowSelectedItemChanged);
            this.cdvRwkFlowFalse.FlowButtonPress += new System.EventHandler(this.cdvRwkFlowFalse_FlowButtonPress);
            this.cdvRwkFlowFalse.SeqButtonPress += new System.EventHandler(this.cdvRwkFlowFalse_SeqButtonPress);
            // 
            // cdvRwkCodeFalse
            // 
            this.cdvRwkCodeFalse.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRwkCodeFalse.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRwkCodeFalse.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRwkCodeFalse.BtnToolTipText = "";
            this.cdvRwkCodeFalse.DescText = "";
            this.cdvRwkCodeFalse.DisplaySubItemIndex = -1;
            this.cdvRwkCodeFalse.DisplayText = "";
            this.cdvRwkCodeFalse.Focusing = null;
            this.cdvRwkCodeFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkCodeFalse.Index = 0;
            this.cdvRwkCodeFalse.IsViewBtnImage = false;
            this.cdvRwkCodeFalse.Location = new System.Drawing.Point(94, 16);
            this.cdvRwkCodeFalse.MaxLength = 10;
            this.cdvRwkCodeFalse.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRwkCodeFalse.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRwkCodeFalse.Name = "cdvRwkCodeFalse";
            this.cdvRwkCodeFalse.ReadOnly = true;
            this.cdvRwkCodeFalse.SearchSubItemIndex = 0;
            this.cdvRwkCodeFalse.SelectedDescIndex = -1;
            this.cdvRwkCodeFalse.SelectedSubItemIndex = -1;
            this.cdvRwkCodeFalse.SelectionStart = 0;
            this.cdvRwkCodeFalse.Size = new System.Drawing.Size(180, 20);
            this.cdvRwkCodeFalse.SmallImageList = null;
            this.cdvRwkCodeFalse.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRwkCodeFalse.TabIndex = 1;
            this.cdvRwkCodeFalse.TextBoxToolTipText = "";
            this.cdvRwkCodeFalse.TextBoxWidth = 180;
            this.cdvRwkCodeFalse.VisibleButton = true;
            this.cdvRwkCodeFalse.VisibleColumnHeader = false;
            this.cdvRwkCodeFalse.VisibleDescription = false;
            this.cdvRwkCodeFalse.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkCodeFalse_SelectedItemChanged);
            // 
            // lblRwkCodeFalse
            // 
            this.lblRwkCodeFalse.AutoSize = true;
            this.lblRwkCodeFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRwkCodeFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRwkCodeFalse.Location = new System.Drawing.Point(8, 20);
            this.lblRwkCodeFalse.Name = "lblRwkCodeFalse";
            this.lblRwkCodeFalse.Size = new System.Drawing.Size(72, 13);
            this.lblRwkCodeFalse.TabIndex = 0;
            this.lblRwkCodeFalse.Text = "Rework Code";
            this.lblRwkCodeFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRetOption
            // 
            this.lblRetOption.AutoSize = true;
            this.lblRetOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetOption.Location = new System.Drawing.Point(301, 95);
            this.lblRetOption.Name = "lblRetOption";
            this.lblRetOption.Size = new System.Drawing.Size(73, 13);
            this.lblRetOption.TabIndex = 19;
            this.lblRetOption.Text = "Return Option";
            this.lblRetOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRetOptionFalse
            // 
            this.lblRetOptionFalse.AutoSize = true;
            this.lblRetOptionFalse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetOptionFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetOptionFalse.Location = new System.Drawing.Point(301, 95);
            this.lblRetOptionFalse.Name = "lblRetOptionFalse";
            this.lblRetOptionFalse.Size = new System.Drawing.Size(73, 13);
            this.lblRetOptionFalse.TabIndex = 20;
            this.lblRetOptionFalse.Text = "Return Option";
            this.lblRetOptionFalse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcFutureActionRework
            // 
            this.Name = "udcFutureActionRework";
            this.grpActionValue.ResumeLayout(false);
            this.pnlActionValueTop.ResumeLayout(false);
            this.pnlActionValueTop.PerformLayout();
            this.grpActionTrue.ResumeLayout(false);
            this.grpActionTrue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkCode)).EndInit();
            this.grpActionFalse.ResumeLayout(false);
            this.grpActionFalse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkCodeFalse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActionValueTop;
        private System.Windows.Forms.ComboBox cboActionType;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.GroupBox grpActionFalse;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRwkCodeFalse;
        private System.Windows.Forms.Label lblRwkCodeFalse;
        private System.Windows.Forms.GroupBox grpActionTrue;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRwkCode;
        private System.Windows.Forms.Label lblRwkCode;
        private Miracom.MESCore.Controls.udcOperation cdvRetOper;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvRetFlow;
        private Miracom.MESCore.Controls.udcOperation cdvRwkOper;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvRwkFlow;
        private Miracom.MESCore.Controls.udcOperation cdvRetOperFalse;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvRetFlowFalse;
        private Miracom.MESCore.Controls.udcOperation cdvRwkOperFalse;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvRwkFlowFalse;
        private Miracom.MESCore.Controls.udcOperation cdvRwkStopOperFalse;
        private Miracom.MESCore.Controls.udcOperation cdvRwkStopOper;
        private System.Windows.Forms.ComboBox cboRetOption;
        private System.Windows.Forms.ComboBox cboRetOptionFalse;
        private System.Windows.Forms.Label lblRetOption;
        private System.Windows.Forms.Label lblRetOptionFalse;
    }
}
