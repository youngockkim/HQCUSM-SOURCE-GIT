namespace Miracom.WIPCore
{
    partial class frmWIPSetupMFOCopy
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpCopyObj = new System.Windows.Forms.GroupBox();
            this.cdvToFactory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToFactory = new System.Windows.Forms.Label();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.cdvToVer = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtToDesc = new System.Windows.Forms.TextBox();
            this.txtFromDesc = new System.Windows.Forms.TextBox();
            this.cdvToID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvFromVer = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFromID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFrom = new System.Windows.Forms.Label();
            this.grpCopyItem = new System.Windows.Forms.GroupBox();
            this.rbtOperation = new System.Windows.Forms.RadioButton();
            this.rbtFlow = new System.Windows.Forms.RadioButton();
            this.rbtMaterial = new System.Windows.Forms.RadioButton();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.tabCopyOption = new System.Windows.Forms.TabControl();
            this.tbpOption1 = new System.Windows.Forms.TabPage();
            this.grpOption1 = new System.Windows.Forms.GroupBox();
            this.chkOperAttributeSetup = new System.Windows.Forms.CheckBox();
            this.chkFlowAttributeSetup = new System.Windows.Forms.CheckBox();
            this.chkMaterialAttributeSetup = new System.Windows.Forms.CheckBox();
            this.chkOperAttribute = new System.Windows.Forms.CheckBox();
            this.chkFlowAttribute = new System.Windows.Forms.CheckBox();
            this.chkMaterialAttribute = new System.Windows.Forms.CheckBox();
            this.chkCrrChangeMFO = new System.Windows.Forms.CheckBox();
            this.chkSPCChartMFO = new System.Windows.Forms.CheckBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkFORelation = new System.Windows.Forms.CheckBox();
            this.chkMFRelation = new System.Windows.Forms.CheckBox();
            this.chkRecipeMFO = new System.Windows.Forms.CheckBox();
            this.chkSpecification = new System.Windows.Forms.CheckBox();
            this.chkColSetMFO = new System.Windows.Forms.CheckBox();
            this.chkFlexScrMFO = new System.Windows.Forms.CheckBox();
            this.chkAlarmMFO = new System.Windows.Forms.CheckBox();
            this.chkCrrGroupMFO = new System.Windows.Forms.CheckBox();
            this.chkResMFO = new System.Windows.Forms.CheckBox();
            this.chkStepRelation = new System.Windows.Forms.CheckBox();
            this.chkBatchKeep = new System.Windows.Forms.CheckBox();
            this.chkIDGenRule = new System.Windows.Forms.CheckBox();
            this.chkYield = new System.Windows.Forms.CheckBox();
            this.chkCycleTime = new System.Windows.Forms.CheckBox();
            this.chkInputOperValue = new System.Windows.Forms.CheckBox();
            this.chkSublotTracking = new System.Windows.Forms.CheckBox();
            this.chkMFOOption = new System.Windows.Forms.CheckBox();
            this.chkQueueTime = new System.Windows.Forms.CheckBox();
            this.chkFutureAction = new System.Windows.Forms.CheckBox();
            this.chkRepair = new System.Windows.Forms.CheckBox();
            this.chkRework = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpCopyObj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToFactory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromID)).BeginInit();
            this.grpCopyItem.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.tabCopyOption.SuspendLayout();
            this.tbpOption1.SuspendLayout();
            this.grpOption1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMid);
            this.pnlCenter.Controls.Add(this.pnlLeft);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpCopyObj);
            this.pnlLeft.Controls.Add(this.grpCopyItem);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(219, 506);
            this.pnlLeft.TabIndex = 0;
            // 
            // grpCopyObj
            // 
            this.grpCopyObj.Controls.Add(this.cdvToFactory);
            this.grpCopyObj.Controls.Add(this.lblToFactory);
            this.grpCopyObj.Controls.Add(this.chkOverwrite);
            this.grpCopyObj.Controls.Add(this.cdvToVer);
            this.grpCopyObj.Controls.Add(this.txtToDesc);
            this.grpCopyObj.Controls.Add(this.txtFromDesc);
            this.grpCopyObj.Controls.Add(this.cdvToID);
            this.grpCopyObj.Controls.Add(this.lblTo);
            this.grpCopyObj.Controls.Add(this.cdvFromVer);
            this.grpCopyObj.Controls.Add(this.cdvFromID);
            this.grpCopyObj.Controls.Add(this.lblFrom);
            this.grpCopyObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCopyObj.Location = new System.Drawing.Point(0, 100);
            this.grpCopyObj.Name = "grpCopyObj";
            this.grpCopyObj.Size = new System.Drawing.Size(216, 406);
            this.grpCopyObj.TabIndex = 1;
            this.grpCopyObj.TabStop = false;
            this.grpCopyObj.Text = "Copy Object";
            // 
            // cdvToFactory
            // 
            this.cdvToFactory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToFactory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToFactory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToFactory.BtnToolTipText = "";
            this.cdvToFactory.DescText = "";
            this.cdvToFactory.DisplaySubItemIndex = -1;
            this.cdvToFactory.DisplayText = "";
            this.cdvToFactory.Focusing = null;
            this.cdvToFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFactory.Index = 0;
            this.cdvToFactory.IsViewBtnImage = false;
            this.cdvToFactory.Location = new System.Drawing.Point(12, 317);
            this.cdvToFactory.MaxLength = 10;
            this.cdvToFactory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToFactory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToFactory.Name = "cdvToFactory";
            this.cdvToFactory.ReadOnly = false;
            this.cdvToFactory.SearchSubItemIndex = 0;
            this.cdvToFactory.SelectedDescIndex = -1;
            this.cdvToFactory.SelectedSubItemIndex = -1;
            this.cdvToFactory.SelectionStart = 0;
            this.cdvToFactory.Size = new System.Drawing.Size(198, 20);
            this.cdvToFactory.SmallImageList = null;
            this.cdvToFactory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToFactory.TabIndex = 18;
            this.cdvToFactory.TextBoxToolTipText = "";
            this.cdvToFactory.TextBoxWidth = 198;
            this.cdvToFactory.VisibleButton = true;
            this.cdvToFactory.VisibleColumnHeader = false;
            this.cdvToFactory.VisibleDescription = false;
            this.cdvToFactory.ButtonPress += new System.EventHandler(this.cdvToFactory_ButtonPress);
            // 
            // lblToFactory
            // 
            this.lblToFactory.AutoSize = true;
            this.lblToFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToFactory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToFactory.Location = new System.Drawing.Point(9, 301);
            this.lblToFactory.Name = "lblToFactory";
            this.lblToFactory.Size = new System.Drawing.Size(58, 13);
            this.lblToFactory.TabIndex = 17;
            this.lblToFactory.Text = "To Factory";
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(12, 245);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(77, 16);
            this.chkOverwrite.TabIndex = 16;
            this.chkOverwrite.Text = "Overwrite";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // cdvToVer
            // 
            this.cdvToVer.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToVer.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToVer.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToVer.BtnToolTipText = "";
            this.cdvToVer.DescText = "";
            this.cdvToVer.DisplaySubItemIndex = -1;
            this.cdvToVer.DisplayText = "";
            this.cdvToVer.Focusing = null;
            this.cdvToVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToVer.Index = 0;
            this.cdvToVer.IsViewBtnImage = false;
            this.cdvToVer.Location = new System.Drawing.Point(165, 152);
            this.cdvToVer.MaxLength = 6;
            this.cdvToVer.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToVer.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToVer.Name = "cdvToVer";
            this.cdvToVer.ReadOnly = false;
            this.cdvToVer.SearchSubItemIndex = 0;
            this.cdvToVer.SelectedDescIndex = -1;
            this.cdvToVer.SelectedSubItemIndex = -1;
            this.cdvToVer.SelectionStart = 0;
            this.cdvToVer.Size = new System.Drawing.Size(45, 20);
            this.cdvToVer.SmallImageList = null;
            this.cdvToVer.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToVer.TabIndex = 6;
            this.cdvToVer.TextBoxToolTipText = "";
            this.cdvToVer.TextBoxWidth = 45;
            this.cdvToVer.VisibleButton = true;
            this.cdvToVer.VisibleColumnHeader = false;
            this.cdvToVer.VisibleDescription = false;
            this.cdvToVer.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvVersion_TextBoxKeyPress);
            // 
            // txtToDesc
            // 
            this.txtToDesc.Location = new System.Drawing.Point(12, 176);
            this.txtToDesc.Multiline = true;
            this.txtToDesc.Name = "txtToDesc";
            this.txtToDesc.Size = new System.Drawing.Size(198, 63);
            this.txtToDesc.TabIndex = 7;
            // 
            // txtFromDesc
            // 
            this.txtFromDesc.Location = new System.Drawing.Point(12, 62);
            this.txtFromDesc.Multiline = true;
            this.txtFromDesc.Name = "txtFromDesc";
            this.txtFromDesc.ReadOnly = true;
            this.txtFromDesc.Size = new System.Drawing.Size(198, 63);
            this.txtFromDesc.TabIndex = 3;
            // 
            // cdvToID
            // 
            this.cdvToID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToID.BtnToolTipText = "";
            this.cdvToID.DescText = "";
            this.cdvToID.DisplaySubItemIndex = -1;
            this.cdvToID.DisplayText = "";
            this.cdvToID.Focusing = null;
            this.cdvToID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToID.Index = 0;
            this.cdvToID.IsViewBtnImage = false;
            this.cdvToID.Location = new System.Drawing.Point(12, 152);
            this.cdvToID.MaxLength = 30;
            this.cdvToID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToID.Name = "cdvToID";
            this.cdvToID.ReadOnly = false;
            this.cdvToID.SearchSubItemIndex = 0;
            this.cdvToID.SelectedDescIndex = -1;
            this.cdvToID.SelectedSubItemIndex = -1;
            this.cdvToID.SelectionStart = 0;
            this.cdvToID.Size = new System.Drawing.Size(148, 20);
            this.cdvToID.SmallImageList = null;
            this.cdvToID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToID.TabIndex = 5;
            this.cdvToID.TextBoxToolTipText = "";
            this.cdvToID.TextBoxWidth = 148;
            this.cdvToID.VisibleButton = true;
            this.cdvToID.VisibleColumnHeader = false;
            this.cdvToID.VisibleDescription = false;
            this.cdvToID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToID_SelectedItemChanged);
            this.cdvToID.ButtonPress += new System.EventHandler(this.cdvToID_ButtonPress);
            this.cdvToID.TextBoxTextChanged += new System.EventHandler(this.cdvToID_TextBoxTextChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTo.Location = new System.Drawing.Point(9, 136);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To";
            // 
            // cdvFromVer
            // 
            this.cdvFromVer.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFromVer.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFromVer.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFromVer.BtnToolTipText = "";
            this.cdvFromVer.DescText = "";
            this.cdvFromVer.DisplaySubItemIndex = -1;
            this.cdvFromVer.DisplayText = "";
            this.cdvFromVer.Focusing = null;
            this.cdvFromVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFromVer.Index = 0;
            this.cdvFromVer.IsViewBtnImage = false;
            this.cdvFromVer.Location = new System.Drawing.Point(165, 38);
            this.cdvFromVer.MaxLength = 6;
            this.cdvFromVer.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFromVer.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFromVer.Name = "cdvFromVer";
            this.cdvFromVer.ReadOnly = false;
            this.cdvFromVer.SearchSubItemIndex = 0;
            this.cdvFromVer.SelectedDescIndex = -1;
            this.cdvFromVer.SelectedSubItemIndex = -1;
            this.cdvFromVer.SelectionStart = 0;
            this.cdvFromVer.Size = new System.Drawing.Size(45, 20);
            this.cdvFromVer.SmallImageList = null;
            this.cdvFromVer.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFromVer.TabIndex = 2;
            this.cdvFromVer.TextBoxToolTipText = "";
            this.cdvFromVer.TextBoxWidth = 45;
            this.cdvFromVer.VisibleButton = true;
            this.cdvFromVer.VisibleColumnHeader = false;
            this.cdvFromVer.VisibleDescription = false;
            this.cdvFromVer.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvVersion_TextBoxKeyPress);
            // 
            // cdvFromID
            // 
            this.cdvFromID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFromID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFromID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFromID.BtnToolTipText = "";
            this.cdvFromID.DescText = "";
            this.cdvFromID.DisplaySubItemIndex = -1;
            this.cdvFromID.DisplayText = "";
            this.cdvFromID.Focusing = null;
            this.cdvFromID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFromID.Index = 0;
            this.cdvFromID.IsViewBtnImage = false;
            this.cdvFromID.Location = new System.Drawing.Point(12, 38);
            this.cdvFromID.MaxLength = 30;
            this.cdvFromID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFromID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFromID.Name = "cdvFromID";
            this.cdvFromID.ReadOnly = false;
            this.cdvFromID.SearchSubItemIndex = 0;
            this.cdvFromID.SelectedDescIndex = -1;
            this.cdvFromID.SelectedSubItemIndex = -1;
            this.cdvFromID.SelectionStart = 0;
            this.cdvFromID.Size = new System.Drawing.Size(148, 20);
            this.cdvFromID.SmallImageList = null;
            this.cdvFromID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFromID.TabIndex = 1;
            this.cdvFromID.TextBoxToolTipText = "";
            this.cdvFromID.TextBoxWidth = 148;
            this.cdvFromID.VisibleButton = true;
            this.cdvFromID.VisibleColumnHeader = false;
            this.cdvFromID.VisibleDescription = false;
            this.cdvFromID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFromID_SelectedItemChanged);
            this.cdvFromID.ButtonPress += new System.EventHandler(this.cdvFromID_ButtonPress);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFrom.Location = new System.Drawing.Point(9, 22);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(34, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // grpCopyItem
            // 
            this.grpCopyItem.Controls.Add(this.rbtOperation);
            this.grpCopyItem.Controls.Add(this.rbtFlow);
            this.grpCopyItem.Controls.Add(this.rbtMaterial);
            this.grpCopyItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyItem.Location = new System.Drawing.Point(0, 0);
            this.grpCopyItem.Name = "grpCopyItem";
            this.grpCopyItem.Size = new System.Drawing.Size(216, 100);
            this.grpCopyItem.TabIndex = 0;
            this.grpCopyItem.TabStop = false;
            this.grpCopyItem.Text = "Copy Item";
            // 
            // rbtOperation
            // 
            this.rbtOperation.AutoSize = true;
            this.rbtOperation.Location = new System.Drawing.Point(12, 68);
            this.rbtOperation.Name = "rbtOperation";
            this.rbtOperation.Size = new System.Drawing.Size(77, 16);
            this.rbtOperation.TabIndex = 2;
            this.rbtOperation.TabStop = true;
            this.rbtOperation.Text = "Operation";
            this.rbtOperation.UseVisualStyleBackColor = true;
            this.rbtOperation.CheckedChanged += new System.EventHandler(this.rbtOperation_CheckedChanged);
            // 
            // rbtFlow
            // 
            this.rbtFlow.AutoSize = true;
            this.rbtFlow.Location = new System.Drawing.Point(12, 45);
            this.rbtFlow.Name = "rbtFlow";
            this.rbtFlow.Size = new System.Drawing.Size(50, 16);
            this.rbtFlow.TabIndex = 1;
            this.rbtFlow.TabStop = true;
            this.rbtFlow.Text = "Flow";
            this.rbtFlow.UseVisualStyleBackColor = true;
            this.rbtFlow.CheckedChanged += new System.EventHandler(this.rbtFlow_CheckedChanged);
            // 
            // rbtMaterial
            // 
            this.rbtMaterial.AutoSize = true;
            this.rbtMaterial.Location = new System.Drawing.Point(12, 22);
            this.rbtMaterial.Name = "rbtMaterial";
            this.rbtMaterial.Size = new System.Drawing.Size(68, 16);
            this.rbtMaterial.TabIndex = 0;
            this.rbtMaterial.TabStop = true;
            this.rbtMaterial.Text = "Material";
            this.rbtMaterial.UseVisualStyleBackColor = true;
            this.rbtMaterial.CheckedChanged += new System.EventHandler(this.rbtMaterial_CheckedChanged);
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.tabCopyOption);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(219, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(523, 506);
            this.pnlMid.TabIndex = 1;
            // 
            // tabCopyOption
            // 
            this.tabCopyOption.Controls.Add(this.tbpOption1);
            this.tabCopyOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCopyOption.Location = new System.Drawing.Point(0, 0);
            this.tabCopyOption.Name = "tabCopyOption";
            this.tabCopyOption.SelectedIndex = 0;
            this.tabCopyOption.Size = new System.Drawing.Size(523, 506);
            this.tabCopyOption.TabIndex = 0;
            // 
            // tbpOption1
            // 
            this.tbpOption1.Controls.Add(this.grpOption1);
            this.tbpOption1.Location = new System.Drawing.Point(4, 22);
            this.tbpOption1.Name = "tbpOption1";
            this.tbpOption1.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOption1.Size = new System.Drawing.Size(515, 480);
            this.tbpOption1.TabIndex = 0;
            this.tbpOption1.Text = "Option";
            // 
            // grpOption1
            // 
            this.grpOption1.Controls.Add(this.chkOperAttributeSetup);
            this.grpOption1.Controls.Add(this.chkFlowAttributeSetup);
            this.grpOption1.Controls.Add(this.chkMaterialAttributeSetup);
            this.grpOption1.Controls.Add(this.chkOperAttribute);
            this.grpOption1.Controls.Add(this.chkFlowAttribute);
            this.grpOption1.Controls.Add(this.chkMaterialAttribute);
            this.grpOption1.Controls.Add(this.chkCrrChangeMFO);
            this.grpOption1.Controls.Add(this.chkSPCChartMFO);
            this.grpOption1.Controls.Add(this.chkSelectAll);
            this.grpOption1.Controls.Add(this.chkFORelation);
            this.grpOption1.Controls.Add(this.chkMFRelation);
            this.grpOption1.Controls.Add(this.chkRecipeMFO);
            this.grpOption1.Controls.Add(this.chkSpecification);
            this.grpOption1.Controls.Add(this.chkColSetMFO);
            this.grpOption1.Controls.Add(this.chkFlexScrMFO);
            this.grpOption1.Controls.Add(this.chkAlarmMFO);
            this.grpOption1.Controls.Add(this.chkCrrGroupMFO);
            this.grpOption1.Controls.Add(this.chkResMFO);
            this.grpOption1.Controls.Add(this.chkStepRelation);
            this.grpOption1.Controls.Add(this.chkBatchKeep);
            this.grpOption1.Controls.Add(this.chkIDGenRule);
            this.grpOption1.Controls.Add(this.chkYield);
            this.grpOption1.Controls.Add(this.chkCycleTime);
            this.grpOption1.Controls.Add(this.chkInputOperValue);
            this.grpOption1.Controls.Add(this.chkSublotTracking);
            this.grpOption1.Controls.Add(this.chkMFOOption);
            this.grpOption1.Controls.Add(this.chkQueueTime);
            this.grpOption1.Controls.Add(this.chkFutureAction);
            this.grpOption1.Controls.Add(this.chkRepair);
            this.grpOption1.Controls.Add(this.chkRework);
            this.grpOption1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption1.Location = new System.Drawing.Point(3, 3);
            this.grpOption1.Name = "grpOption1";
            this.grpOption1.Size = new System.Drawing.Size(509, 474);
            this.grpOption1.TabIndex = 0;
            this.grpOption1.TabStop = false;
            // 
            // chkOperAttributeSetup
            // 
            this.chkOperAttributeSetup.AutoSize = true;
            this.chkOperAttributeSetup.Location = new System.Drawing.Point(250, 438);
            this.chkOperAttributeSetup.Name = "chkOperAttributeSetup";
            this.chkOperAttributeSetup.Size = new System.Drawing.Size(243, 16);
            this.chkOperAttributeSetup.TabIndex = 30;
            this.chkOperAttributeSetup.Text = "Operation Attribute Setup (Merge Only)";
            this.chkOperAttributeSetup.UseVisualStyleBackColor = true;
            // 
            // chkFlowAttributeSetup
            // 
            this.chkFlowAttributeSetup.AutoSize = true;
            this.chkFlowAttributeSetup.Location = new System.Drawing.Point(250, 415);
            this.chkFlowAttributeSetup.Name = "chkFlowAttributeSetup";
            this.chkFlowAttributeSetup.Size = new System.Drawing.Size(216, 16);
            this.chkFlowAttributeSetup.TabIndex = 29;
            this.chkFlowAttributeSetup.Text = "Flow Attribute Setup (Merge Only)";
            this.chkFlowAttributeSetup.UseVisualStyleBackColor = true;
            // 
            // chkMaterialAttributeSetup
            // 
            this.chkMaterialAttributeSetup.AutoSize = true;
            this.chkMaterialAttributeSetup.Location = new System.Drawing.Point(250, 392);
            this.chkMaterialAttributeSetup.Name = "chkMaterialAttributeSetup";
            this.chkMaterialAttributeSetup.Size = new System.Drawing.Size(234, 16);
            this.chkMaterialAttributeSetup.TabIndex = 28;
            this.chkMaterialAttributeSetup.Text = "Material Attribute Setup (Merge Only)";
            this.chkMaterialAttributeSetup.UseVisualStyleBackColor = true;
            // 
            // chkOperAttribute
            // 
            this.chkOperAttribute.AutoSize = true;
            this.chkOperAttribute.Location = new System.Drawing.Point(14, 438);
            this.chkOperAttribute.Name = "chkOperAttribute";
            this.chkOperAttribute.Size = new System.Drawing.Size(156, 16);
            this.chkOperAttribute.TabIndex = 27;
            this.chkOperAttribute.Text = "Operation Attribute Data";
            this.chkOperAttribute.UseVisualStyleBackColor = true;
            // 
            // chkFlowAttribute
            // 
            this.chkFlowAttribute.AutoSize = true;
            this.chkFlowAttribute.Location = new System.Drawing.Point(14, 415);
            this.chkFlowAttribute.Name = "chkFlowAttribute";
            this.chkFlowAttribute.Size = new System.Drawing.Size(129, 16);
            this.chkFlowAttribute.TabIndex = 26;
            this.chkFlowAttribute.Text = "Flow Attribute Data";
            this.chkFlowAttribute.UseVisualStyleBackColor = true;
            // 
            // chkMaterialAttribute
            // 
            this.chkMaterialAttribute.AutoSize = true;
            this.chkMaterialAttribute.Location = new System.Drawing.Point(14, 392);
            this.chkMaterialAttribute.Name = "chkMaterialAttribute";
            this.chkMaterialAttribute.Size = new System.Drawing.Size(147, 16);
            this.chkMaterialAttribute.TabIndex = 25;
            this.chkMaterialAttribute.Text = "Material Attribute Data";
            this.chkMaterialAttribute.UseVisualStyleBackColor = true;
            // 
            // chkCrrChangeMFO
            // 
            this.chkCrrChangeMFO.AutoSize = true;
            this.chkCrrChangeMFO.Location = new System.Drawing.Point(250, 76);
            this.chkCrrChangeMFO.Name = "chkCrrChangeMFO";
            this.chkCrrChangeMFO.Size = new System.Drawing.Size(187, 16);
            this.chkCrrChangeMFO.TabIndex = 17;
            this.chkCrrChangeMFO.Text = "Carrier Change Info. by MFO";
            this.chkCrrChangeMFO.UseVisualStyleBackColor = true;
            // 
            // chkSPCChartMFO
            // 
            this.chkSPCChartMFO.AutoSize = true;
            this.chkSPCChartMFO.Location = new System.Drawing.Point(250, 214);
            this.chkSPCChartMFO.Name = "chkSPCChartMFO";
            this.chkSPCChartMFO.Size = new System.Drawing.Size(163, 16);
            this.chkSPCChartMFO.TabIndex = 23;
            this.chkSPCChartMFO.Text = "SPC Chart MFO Relation";
            this.chkSPCChartMFO.UseVisualStyleBackColor = true;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.Location = new System.Drawing.Point(14, 2);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(98, 17);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Text = "Select All Items";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // chkFORelation
            // 
            this.chkFORelation.AutoSize = true;
            this.chkFORelation.Location = new System.Drawing.Point(14, 53);
            this.chkFORelation.Name = "chkFORelation";
            this.chkFORelation.Size = new System.Drawing.Size(168, 16);
            this.chkFORelation.TabIndex = 2;
            this.chkFORelation.Text = "Flow - Operation Relation";
            this.chkFORelation.UseVisualStyleBackColor = true;
            // 
            // chkMFRelation
            // 
            this.chkMFRelation.AutoSize = true;
            this.chkMFRelation.Location = new System.Drawing.Point(14, 30);
            this.chkMFRelation.Name = "chkMFRelation";
            this.chkMFRelation.Size = new System.Drawing.Size(159, 16);
            this.chkMFRelation.TabIndex = 1;
            this.chkMFRelation.Text = "Material - Flow Relation";
            this.chkMFRelation.UseVisualStyleBackColor = true;
            // 
            // chkRecipeMFO
            // 
            this.chkRecipeMFO.AutoSize = true;
            this.chkRecipeMFO.Location = new System.Drawing.Point(250, 191);
            this.chkRecipeMFO.Name = "chkRecipeMFO";
            this.chkRecipeMFO.Size = new System.Drawing.Size(143, 16);
            this.chkRecipeMFO.TabIndex = 22;
            this.chkRecipeMFO.Text = "Recipe MFO Relation";
            this.chkRecipeMFO.UseVisualStyleBackColor = true;
            // 
            // chkSpecification
            // 
            this.chkSpecification.AutoSize = true;
            this.chkSpecification.Location = new System.Drawing.Point(250, 168);
            this.chkSpecification.Name = "chkSpecification";
            this.chkSpecification.Size = new System.Drawing.Size(96, 16);
            this.chkSpecification.TabIndex = 21;
            this.chkSpecification.Text = "Specification";
            this.chkSpecification.UseVisualStyleBackColor = true;
            // 
            // chkColSetMFO
            // 
            this.chkColSetMFO.AutoSize = true;
            this.chkColSetMFO.Location = new System.Drawing.Point(250, 145);
            this.chkColSetMFO.Name = "chkColSetMFO";
            this.chkColSetMFO.Size = new System.Drawing.Size(182, 16);
            this.chkColSetMFO.TabIndex = 20;
            this.chkColSetMFO.Text = "Collection Set MFO Relation";
            this.chkColSetMFO.UseVisualStyleBackColor = true;
            // 
            // chkFlexScrMFO
            // 
            this.chkFlexScrMFO.AutoSize = true;
            this.chkFlexScrMFO.Location = new System.Drawing.Point(250, 122);
            this.chkFlexScrMFO.Name = "chkFlexScrMFO";
            this.chkFlexScrMFO.Size = new System.Drawing.Size(192, 16);
            this.chkFlexScrMFO.TabIndex = 19;
            this.chkFlexScrMFO.Text = "Flexible Screen MFO Relation";
            this.chkFlexScrMFO.UseVisualStyleBackColor = true;
            // 
            // chkAlarmMFO
            // 
            this.chkAlarmMFO.AutoSize = true;
            this.chkAlarmMFO.Location = new System.Drawing.Point(250, 99);
            this.chkAlarmMFO.Name = "chkAlarmMFO";
            this.chkAlarmMFO.Size = new System.Drawing.Size(137, 16);
            this.chkAlarmMFO.TabIndex = 18;
            this.chkAlarmMFO.Text = "Alarm MFO Relation";
            this.chkAlarmMFO.UseVisualStyleBackColor = true;
            // 
            // chkCrrGroupMFO
            // 
            this.chkCrrGroupMFO.AutoSize = true;
            this.chkCrrGroupMFO.Location = new System.Drawing.Point(250, 53);
            this.chkCrrGroupMFO.Name = "chkCrrGroupMFO";
            this.chkCrrGroupMFO.Size = new System.Drawing.Size(180, 16);
            this.chkCrrGroupMFO.TabIndex = 16;
            this.chkCrrGroupMFO.Text = "Carrier Group MFO Relation";
            this.chkCrrGroupMFO.UseVisualStyleBackColor = true;
            // 
            // chkResMFO
            // 
            this.chkResMFO.AutoSize = true;
            this.chkResMFO.Location = new System.Drawing.Point(250, 30);
            this.chkResMFO.Name = "chkResMFO";
            this.chkResMFO.Size = new System.Drawing.Size(158, 16);
            this.chkResMFO.TabIndex = 15;
            this.chkResMFO.Text = "Resource MFO Relation";
            this.chkResMFO.UseVisualStyleBackColor = true;
            // 
            // chkStepRelation
            // 
            this.chkStepRelation.AutoSize = true;
            this.chkStepRelation.Location = new System.Drawing.Point(14, 329);
            this.chkStepRelation.Name = "chkStepRelation";
            this.chkStepRelation.Size = new System.Drawing.Size(98, 16);
            this.chkStepRelation.TabIndex = 14;
            this.chkStepRelation.Text = "Step Relation";
            this.chkStepRelation.UseVisualStyleBackColor = true;
            // 
            // chkBatchKeep
            // 
            this.chkBatchKeep.AutoSize = true;
            this.chkBatchKeep.Location = new System.Drawing.Point(14, 306);
            this.chkBatchKeep.Name = "chkBatchKeep";
            this.chkBatchKeep.Size = new System.Drawing.Size(89, 16);
            this.chkBatchKeep.TabIndex = 13;
            this.chkBatchKeep.Text = "Batch Keep";
            this.chkBatchKeep.UseVisualStyleBackColor = true;
            // 
            // chkIDGenRule
            // 
            this.chkIDGenRule.AutoSize = true;
            this.chkIDGenRule.Location = new System.Drawing.Point(14, 283);
            this.chkIDGenRule.Name = "chkIDGenRule";
            this.chkIDGenRule.Size = new System.Drawing.Size(129, 16);
            this.chkIDGenRule.TabIndex = 12;
            this.chkIDGenRule.Text = "ID Generation Rule";
            this.chkIDGenRule.UseVisualStyleBackColor = true;
            // 
            // chkYield
            // 
            this.chkYield.AutoSize = true;
            this.chkYield.Location = new System.Drawing.Point(14, 260);
            this.chkYield.Name = "chkYield";
            this.chkYield.Size = new System.Drawing.Size(52, 16);
            this.chkYield.TabIndex = 11;
            this.chkYield.Text = "Yield";
            this.chkYield.UseVisualStyleBackColor = true;
            // 
            // chkCycleTime
            // 
            this.chkCycleTime.AutoSize = true;
            this.chkCycleTime.Location = new System.Drawing.Point(14, 237);
            this.chkCycleTime.Name = "chkCycleTime";
            this.chkCycleTime.Size = new System.Drawing.Size(90, 16);
            this.chkCycleTime.TabIndex = 10;
            this.chkCycleTime.Text = "Cycle Time";
            this.chkCycleTime.UseVisualStyleBackColor = true;
            // 
            // chkInputOperValue
            // 
            this.chkInputOperValue.AutoSize = true;
            this.chkInputOperValue.Location = new System.Drawing.Point(14, 214);
            this.chkInputOperValue.Name = "chkInputOperValue";
            this.chkInputOperValue.Size = new System.Drawing.Size(145, 16);
            this.chkInputOperValue.TabIndex = 9;
            this.chkInputOperValue.Text = "Input Operation Value";
            this.chkInputOperValue.UseVisualStyleBackColor = true;
            // 
            // chkSublotTracking
            // 
            this.chkSublotTracking.AutoSize = true;
            this.chkSublotTracking.Location = new System.Drawing.Point(14, 191);
            this.chkSublotTracking.Name = "chkSublotTracking";
            this.chkSublotTracking.Size = new System.Drawing.Size(152, 16);
            this.chkSublotTracking.TabIndex = 8;
            this.chkSublotTracking.Text = "Sublot Tracking Option";
            this.chkSublotTracking.UseVisualStyleBackColor = true;
            // 
            // chkMFOOption
            // 
            this.chkMFOOption.AutoSize = true;
            this.chkMFOOption.Location = new System.Drawing.Point(14, 168);
            this.chkMFOOption.Name = "chkMFOOption";
            this.chkMFOOption.Size = new System.Drawing.Size(91, 16);
            this.chkMFOOption.TabIndex = 7;
            this.chkMFOOption.Text = "MFO Option";
            this.chkMFOOption.UseVisualStyleBackColor = true;
            // 
            // chkQueueTime
            // 
            this.chkQueueTime.AutoSize = true;
            this.chkQueueTime.Location = new System.Drawing.Point(14, 145);
            this.chkQueueTime.Name = "chkQueueTime";
            this.chkQueueTime.Size = new System.Drawing.Size(94, 16);
            this.chkQueueTime.TabIndex = 6;
            this.chkQueueTime.Text = "Queue Time";
            this.chkQueueTime.UseVisualStyleBackColor = true;
            // 
            // chkFutureAction
            // 
            this.chkFutureAction.AutoSize = true;
            this.chkFutureAction.Location = new System.Drawing.Point(14, 122);
            this.chkFutureAction.Name = "chkFutureAction";
            this.chkFutureAction.Size = new System.Drawing.Size(98, 16);
            this.chkFutureAction.TabIndex = 5;
            this.chkFutureAction.Text = "Future Action";
            this.chkFutureAction.UseVisualStyleBackColor = true;
            // 
            // chkRepair
            // 
            this.chkRepair.AutoSize = true;
            this.chkRepair.Location = new System.Drawing.Point(14, 99);
            this.chkRepair.Name = "chkRepair";
            this.chkRepair.Size = new System.Drawing.Size(118, 16);
            this.chkRepair.TabIndex = 4;
            this.chkRepair.Text = "Repair Operation";
            this.chkRepair.UseVisualStyleBackColor = true;
            // 
            // chkRework
            // 
            this.chkRework.AutoSize = true;
            this.chkRework.Location = new System.Drawing.Point(14, 76);
            this.chkRework.Name = "chkRework";
            this.chkRework.Size = new System.Drawing.Size(97, 16);
            this.chkRework.TabIndex = 3;
            this.chkRework.Text = "Rework Flow";
            this.chkRework.UseVisualStyleBackColor = true;
            // 
            // frmWIPSetupMFOCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupMFOCopy";
            this.Text = "MFO Copy";
            this.Activated += new System.EventHandler(this.frmWIPSetupMFOCopy_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grpCopyObj.ResumeLayout(false);
            this.grpCopyObj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToFactory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromID)).EndInit();
            this.grpCopyItem.ResumeLayout(false);
            this.grpCopyItem.PerformLayout();
            this.pnlMid.ResumeLayout(false);
            this.tabCopyOption.ResumeLayout(false);
            this.tbpOption1.ResumeLayout(false);
            this.grpOption1.ResumeLayout(false);
            this.grpOption1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpCopyItem;
        private System.Windows.Forms.GroupBox grpCopyObj;
        private System.Windows.Forms.TabControl tabCopyOption;
        private System.Windows.Forms.TabPage tbpOption1;
        private System.Windows.Forms.RadioButton rbtOperation;
        private System.Windows.Forms.RadioButton rbtFlow;
        private System.Windows.Forms.RadioButton rbtMaterial;
        private System.Windows.Forms.GroupBox grpOption1;
        private System.Windows.Forms.CheckBox chkFORelation;
        private System.Windows.Forms.CheckBox chkMFRelation;
        private System.Windows.Forms.CheckBox chkRecipeMFO;
        private System.Windows.Forms.CheckBox chkSpecification;
        private System.Windows.Forms.CheckBox chkColSetMFO;
        private System.Windows.Forms.CheckBox chkFlexScrMFO;
        private System.Windows.Forms.CheckBox chkAlarmMFO;
        private System.Windows.Forms.CheckBox chkCrrGroupMFO;
        private System.Windows.Forms.CheckBox chkResMFO;
        private System.Windows.Forms.CheckBox chkStepRelation;
        private System.Windows.Forms.CheckBox chkBatchKeep;
        private System.Windows.Forms.CheckBox chkIDGenRule;
        private System.Windows.Forms.CheckBox chkYield;
        private System.Windows.Forms.CheckBox chkCycleTime;
        private System.Windows.Forms.CheckBox chkInputOperValue;
        private System.Windows.Forms.CheckBox chkSublotTracking;
        private System.Windows.Forms.CheckBox chkMFOOption;
        private System.Windows.Forms.CheckBox chkQueueTime;
        private System.Windows.Forms.CheckBox chkFutureAction;
        private System.Windows.Forms.CheckBox chkRepair;
        private System.Windows.Forms.CheckBox chkRework;
        private System.Windows.Forms.TextBox txtToDesc;
        private System.Windows.Forms.TextBox txtFromDesc;
        private UI.Controls.MCCodeView.MCCodeView cdvToID;
        private System.Windows.Forms.Label lblTo;
        private UI.Controls.MCCodeView.MCCodeView cdvFromVer;
        private UI.Controls.MCCodeView.MCCodeView cdvFromID;
        private System.Windows.Forms.Label lblFrom;
        private UI.Controls.MCCodeView.MCCodeView cdvToVer;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.CheckBox chkSPCChartMFO;
        private System.Windows.Forms.CheckBox chkCrrChangeMFO;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private UI.Controls.MCCodeView.MCCodeView cdvToFactory;
        private System.Windows.Forms.Label lblToFactory;
        private System.Windows.Forms.CheckBox chkOperAttribute;
        private System.Windows.Forms.CheckBox chkFlowAttribute;
        private System.Windows.Forms.CheckBox chkMaterialAttribute;
        private System.Windows.Forms.CheckBox chkOperAttributeSetup;
        private System.Windows.Forms.CheckBox chkFlowAttributeSetup;
        private System.Windows.Forms.CheckBox chkMaterialAttributeSetup;
    }
}