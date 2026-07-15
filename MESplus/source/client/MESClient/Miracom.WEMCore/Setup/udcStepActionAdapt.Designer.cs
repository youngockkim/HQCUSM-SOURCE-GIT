namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionAdapt
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
            this.lblLabel1 = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.numQty3 = new System.Windows.Forms.NumericUpDown();
            this.cboOperator3 = new System.Windows.Forms.ComboBox();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.numQty2 = new System.Windows.Forms.NumericUpDown();
            this.cboOperator2 = new System.Windows.Forms.ComboBox();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.numQty1 = new System.Windows.Forms.NumericUpDown();
            this.cboOperator1 = new System.Windows.Forms.ComboBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.cdvOwnerCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMatId = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvLotType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLotType = new System.Windows.Forms.Label();
            this.chkMultiTrans = new System.Windows.Forms.CheckBox();
            this.grpActionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.chkMultiTrans);
            this.grpActionValue.Controls.Add(this.lblLabel1);
            this.grpActionValue.Controls.Add(this.cboPriority);
            this.grpActionValue.Controls.Add(this.numQty3);
            this.grpActionValue.Controls.Add(this.cboOperator3);
            this.grpActionValue.Controls.Add(this.lblQty3);
            this.grpActionValue.Controls.Add(this.numQty2);
            this.grpActionValue.Controls.Add(this.cboOperator2);
            this.grpActionValue.Controls.Add(this.lblQty2);
            this.grpActionValue.Controls.Add(this.numQty1);
            this.grpActionValue.Controls.Add(this.cboOperator1);
            this.grpActionValue.Controls.Add(this.lblQty1);
            this.grpActionValue.Controls.Add(this.cdvOwnerCode);
            this.grpActionValue.Controls.Add(this.lblOwnerCode);
            this.grpActionValue.Controls.Add(this.cdvCreateCode);
            this.grpActionValue.Controls.Add(this.lblCreateCode);
            this.grpActionValue.Controls.Add(this.lblPriority);
            this.grpActionValue.Controls.Add(this.cdvOper);
            this.grpActionValue.Controls.Add(this.cdvFlow);
            this.grpActionValue.Controls.Add(this.cdvMatId);
            this.grpActionValue.Controls.Add(this.cdvLotType);
            this.grpActionValue.Controls.Add(this.lblLotType);
            // 
            // lblLabel1
            // 
            this.lblLabel1.AutoSize = true;
            this.lblLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel1.Location = new System.Drawing.Point(6, 297);
            this.lblLabel1.Name = "lblLabel1";
            this.lblLabel1.Size = new System.Drawing.Size(121, 13);
            this.lblLabel1.TabIndex = 21;
            this.lblLabel1.Text = "@ : Input Null value";
            // 
            // cboPriority
            // 
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.FormattingEnabled = true;
            this.cboPriority.Items.AddRange(new object[] {
            "@",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cboPriority.Location = new System.Drawing.Point(104, 114);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(130, 21);
            this.cboPriority.TabIndex = 6;
            // 
            // numQty3
            // 
            this.numQty3.DecimalPlaces = 3;
            this.numQty3.Location = new System.Drawing.Point(165, 241);
            this.numQty3.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numQty3.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numQty3.Name = "numQty3";
            this.numQty3.Size = new System.Drawing.Size(69, 20);
            this.numQty3.TabIndex = 19;
            this.numQty3.ThousandsSeparator = true;
            // 
            // cboOperator3
            // 
            this.cboOperator3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator3.FormattingEnabled = true;
            this.cboOperator3.Items.AddRange(new object[] {
            "@",
            "=",
            "+",
            "-"});
            this.cboOperator3.Location = new System.Drawing.Point(104, 241);
            this.cboOperator3.Name = "cboOperator3";
            this.cboOperator3.Size = new System.Drawing.Size(58, 21);
            this.cboOperator3.TabIndex = 18;
            this.cboOperator3.SelectedIndexChanged += new System.EventHandler(this.cboOperator3_SelectedIndexChanged);
            // 
            // lblQty3
            // 
            this.lblQty3.AutoSize = true;
            this.lblQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty3.Location = new System.Drawing.Point(6, 245);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(48, 13);
            this.lblQty3.TabIndex = 17;
            this.lblQty3.Text = "To Qty 3";
            this.lblQty3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numQty2
            // 
            this.numQty2.DecimalPlaces = 3;
            this.numQty2.Location = new System.Drawing.Point(165, 215);
            this.numQty2.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numQty2.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numQty2.Name = "numQty2";
            this.numQty2.Size = new System.Drawing.Size(69, 20);
            this.numQty2.TabIndex = 16;
            this.numQty2.ThousandsSeparator = true;
            // 
            // cboOperator2
            // 
            this.cboOperator2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator2.FormattingEnabled = true;
            this.cboOperator2.Items.AddRange(new object[] {
            "@",
            "=",
            "+",
            "-"});
            this.cboOperator2.Location = new System.Drawing.Point(104, 215);
            this.cboOperator2.Name = "cboOperator2";
            this.cboOperator2.Size = new System.Drawing.Size(58, 21);
            this.cboOperator2.TabIndex = 15;
            this.cboOperator2.SelectedIndexChanged += new System.EventHandler(this.cboOperator2_SelectedIndexChanged);
            // 
            // lblQty2
            // 
            this.lblQty2.AutoSize = true;
            this.lblQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty2.Location = new System.Drawing.Point(6, 219);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(48, 13);
            this.lblQty2.TabIndex = 14;
            this.lblQty2.Text = "To Qty 2";
            this.lblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numQty1
            // 
            this.numQty1.DecimalPlaces = 3;
            this.numQty1.Location = new System.Drawing.Point(165, 189);
            this.numQty1.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numQty1.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numQty1.Name = "numQty1";
            this.numQty1.Size = new System.Drawing.Size(69, 20);
            this.numQty1.TabIndex = 13;
            this.numQty1.ThousandsSeparator = true;
            // 
            // cboOperator1
            // 
            this.cboOperator1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator1.FormattingEnabled = true;
            this.cboOperator1.Items.AddRange(new object[] {
            "@",
            "=",
            "+",
            "-"});
            this.cboOperator1.Location = new System.Drawing.Point(104, 189);
            this.cboOperator1.Name = "cboOperator1";
            this.cboOperator1.Size = new System.Drawing.Size(58, 21);
            this.cboOperator1.TabIndex = 12;
            this.cboOperator1.SelectedIndexChanged += new System.EventHandler(this.cboOperator1_SelectedIndexChanged);
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(6, 193);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(48, 13);
            this.lblQty1.TabIndex = 11;
            this.lblQty1.Text = "To Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvOwnerCode
            // 
            this.cdvOwnerCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOwnerCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOwnerCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOwnerCode.BtnToolTipText = "";
            this.cdvOwnerCode.DescText = "";
            this.cdvOwnerCode.DisplaySubItemIndex = -1;
            this.cdvOwnerCode.DisplayText = "";
            this.cdvOwnerCode.Focusing = null;
            this.cdvOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOwnerCode.Index = 0;
            this.cdvOwnerCode.IsViewBtnImage = false;
            this.cdvOwnerCode.Location = new System.Drawing.Point(104, 164);
            this.cdvOwnerCode.MaxLength = 10;
            this.cdvOwnerCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.Name = "cdvOwnerCode";
            this.cdvOwnerCode.ReadOnly = true;
            this.cdvOwnerCode.SearchSubItemIndex = 0;
            this.cdvOwnerCode.SelectedDescIndex = -1;
            this.cdvOwnerCode.SelectedSubItemIndex = -1;
            this.cdvOwnerCode.SelectionStart = 0;
            this.cdvOwnerCode.Size = new System.Drawing.Size(130, 20);
            this.cdvOwnerCode.SmallImageList = null;
            this.cdvOwnerCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOwnerCode.TabIndex = 10;
            this.cdvOwnerCode.TextBoxToolTipText = "";
            this.cdvOwnerCode.TextBoxWidth = 130;
            this.cdvOwnerCode.VisibleButton = true;
            this.cdvOwnerCode.VisibleColumnHeader = false;
            this.cdvOwnerCode.VisibleDescription = false;
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerCode.Location = new System.Drawing.Point(6, 168);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(82, 13);
            this.lblOwnerCode.TabIndex = 9;
            this.lblOwnerCode.Text = "To Owner Code";
            this.lblOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCreateCode
            // 
            this.cdvCreateCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCode.BtnToolTipText = "";
            this.cdvCreateCode.DescText = "";
            this.cdvCreateCode.DisplaySubItemIndex = -1;
            this.cdvCreateCode.DisplayText = "";
            this.cdvCreateCode.Focusing = null;
            this.cdvCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCode.Index = 0;
            this.cdvCreateCode.IsViewBtnImage = false;
            this.cdvCreateCode.Location = new System.Drawing.Point(104, 139);
            this.cdvCreateCode.MaxLength = 10;
            this.cdvCreateCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.Name = "cdvCreateCode";
            this.cdvCreateCode.ReadOnly = true;
            this.cdvCreateCode.SearchSubItemIndex = 0;
            this.cdvCreateCode.SelectedDescIndex = -1;
            this.cdvCreateCode.SelectedSubItemIndex = -1;
            this.cdvCreateCode.SelectionStart = 0;
            this.cdvCreateCode.Size = new System.Drawing.Size(130, 20);
            this.cdvCreateCode.SmallImageList = null;
            this.cdvCreateCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCode.TabIndex = 8;
            this.cdvCreateCode.TextBoxToolTipText = "";
            this.cdvCreateCode.TextBoxWidth = 130;
            this.cdvCreateCode.VisibleButton = true;
            this.cdvCreateCode.VisibleColumnHeader = false;
            this.cdvCreateCode.VisibleDescription = false;
            // 
            // lblCreateCode
            // 
            this.lblCreateCode.AutoSize = true;
            this.lblCreateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCode.Location = new System.Drawing.Point(6, 143);
            this.lblCreateCode.Name = "lblCreateCode";
            this.lblCreateCode.Size = new System.Drawing.Size(82, 13);
            this.lblCreateCode.TabIndex = 7;
            this.lblCreateCode.Text = "To Create Code";
            this.lblCreateCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(6, 118);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(54, 13);
            this.lblPriority.TabIndex = 5;
            this.lblPriority.Text = "To Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvOper
            // 
            this.cdvOper.AddEmptyRowToLast = false;
            this.cdvOper.AddEmptyRowToTop = false;
            this.cdvOper.ButtonWidth = 21;
            this.cdvOper.DisplaySubItemIndex = 0;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.LabelText = "To Operation";
            this.cdvOper.LabelWidth = 98;
            this.cdvOper.ListCond_ExtFactory = "";
            this.cdvOper.ListCond_Step = '1';
            this.cdvOper.Location = new System.Drawing.Point(6, 64);
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = 1;
            this.cdvOper.SelectedSubItemIndex = 0;
            this.cdvOper.Size = new System.Drawing.Size(228, 20);
            this.cdvOper.TabIndex = 2;
            this.cdvOper.TextBoxWidth = 130;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.ButtonPressAfter += new System.EventHandler(this.cdvOper_ButtonPressAfter);
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "To Flow";
            this.cdvFlow.LabelWidth = 98;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(6, 39);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(228, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 130;
            this.cdvFlow.WidthSequence = 40;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_FlowSelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            this.cdvFlow.FlowButtonPressAfter += new System.EventHandler(this.cdvFlow_FlowButtonPressAfter);
            // 
            // cdvMatId
            // 
            this.cdvMatId.AddEmptyRowToLast = false;
            this.cdvMatId.AddEmptyRowToTop = false;
            this.cdvMatId.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMatId.DisplaySubItemIndex = 0;
            this.cdvMatId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatId.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMatId.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatId.LabelText = "To Material";
            this.cdvMatId.ListCond_ExtFactory = "";
            this.cdvMatId.ListCond_StepMaterial = '1';
            this.cdvMatId.ListCond_StepVersion = '1';
            this.cdvMatId.Location = new System.Drawing.Point(6, 14);
            this.cdvMatId.MaterialEnabled = true;
            this.cdvMatId.MaterialReadOnly = false;
            this.cdvMatId.Name = "cdvMatId";
            this.cdvMatId.SearchSubItemIndex = 0;
            this.cdvMatId.SelectedDescIndex = -1;
            this.cdvMatId.SelectedSubItemIndex = 0;
            this.cdvMatId.Size = new System.Drawing.Size(228, 20);
            this.cdvMatId.TabIndex = 0;
            this.cdvMatId.VersionEnabled = true;
            this.cdvMatId.VersionReadOnly = false;
            this.cdvMatId.VisibleColumnHeader = false;
            this.cdvMatId.VisibleDescription = false;
            this.cdvMatId.VisibleMaterialButton = true;
            this.cdvMatId.VisibleVersionButton = true;
            this.cdvMatId.WidthButton = 20;
            this.cdvMatId.WidthLabel = 98;
            this.cdvMatId.WidthMaterialAndVersion = 130;
            this.cdvMatId.WidthVersion = 40;
            this.cdvMatId.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatId_MaterialSelectedItemChanged);
            this.cdvMatId.MaterialButtonPressAfter += new System.EventHandler(this.cdvMatId_MaterialButtonPressAfter);
            // 
            // cdvLotType
            // 
            this.cdvLotType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLotType.BtnToolTipText = "";
            this.cdvLotType.DescText = "";
            this.cdvLotType.DisplaySubItemIndex = -1;
            this.cdvLotType.DisplayText = "";
            this.cdvLotType.Focusing = null;
            this.cdvLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLotType.Index = 0;
            this.cdvLotType.IsViewBtnImage = false;
            this.cdvLotType.Location = new System.Drawing.Point(104, 89);
            this.cdvLotType.MaxLength = 10;
            this.cdvLotType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.Name = "cdvLotType";
            this.cdvLotType.ReadOnly = true;
            this.cdvLotType.SearchSubItemIndex = 0;
            this.cdvLotType.SelectedDescIndex = -1;
            this.cdvLotType.SelectedSubItemIndex = -1;
            this.cdvLotType.SelectionStart = 0;
            this.cdvLotType.Size = new System.Drawing.Size(130, 20);
            this.cdvLotType.SmallImageList = null;
            this.cdvLotType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotType.TabIndex = 4;
            this.cdvLotType.TextBoxToolTipText = "";
            this.cdvLotType.TextBoxWidth = 130;
            this.cdvLotType.VisibleButton = true;
            this.cdvLotType.VisibleColumnHeader = false;
            this.cdvLotType.VisibleDescription = false;
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(6, 93);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(65, 13);
            this.lblLotType.TabIndex = 3;
            this.lblLotType.Text = "To Lot Type";
            this.lblLotType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkMultiTrans
            // 
            this.chkMultiTrans.AutoSize = true;
            this.chkMultiTrans.Location = new System.Drawing.Point(6, 268);
            this.chkMultiTrans.Name = "chkMultiTrans";
            this.chkMultiTrans.Size = new System.Drawing.Size(146, 17);
            this.chkMultiTrans.TabIndex = 20;
            this.chkMultiTrans.Text = "Perform Multi Transaction";
            this.chkMultiTrans.UseVisualStyleBackColor = true;
            // 
            // udcStepActionAdapt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcStepActionAdapt";
            this.grpActionValue.ResumeLayout(false);
            this.grpActionValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLabel1;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.NumericUpDown numQty3;
        private System.Windows.Forms.ComboBox cboOperator3;
        private System.Windows.Forms.Label lblQty3;
        private System.Windows.Forms.NumericUpDown numQty2;
        private System.Windows.Forms.ComboBox cboOperator2;
        private System.Windows.Forms.Label lblQty2;
        private System.Windows.Forms.NumericUpDown numQty1;
        private System.Windows.Forms.ComboBox cboOperator1;
        private System.Windows.Forms.Label lblQty1;
        private UI.Controls.MCCodeView.MCCodeView cdvOwnerCode;
        private System.Windows.Forms.Label lblOwnerCode;
        private UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        private System.Windows.Forms.Label lblCreateCode;
        private System.Windows.Forms.Label lblPriority;
        private MESCore.Controls.udcOperation cdvOper;
        private MESCore.Controls.udcFlowAndSeq cdvFlow;
        private MESCore.Controls.udcMaterial cdvMatId;
        private UI.Controls.MCCodeView.MCCodeView cdvLotType;
        private System.Windows.Forms.Label lblLotType;
        private System.Windows.Forms.CheckBox chkMultiTrans;
    }
}
