namespace Miracom.MESCore
{
    partial class frmLotListMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLotListMain));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvCmfValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvLotCmf = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAttrValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAttr = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResId = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrValue = new System.Windows.Forms.Label();
            this.txtCrrId = new System.Windows.Forms.TextBox();
            this.lblAttribute = new System.Windows.Forms.Label();
            this.txtLotId = new System.Windows.Forms.TextBox();
            this.lblResId = new System.Windows.Forms.Label();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.lblLotCmf = new System.Windows.Forms.Label();
            this.lblLotId = new System.Windows.Forms.Label();
            this.cdvMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.txtTotQty = new System.Windows.Forms.Label();
            this.txtTotLot = new System.Windows.Forms.Label();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTotQty = new System.Windows.Forms.Label();
            this.lblTotLot = new System.Windows.Forms.Label();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenu();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.udcLotList = new Miracom.MESCore.Controls.udcLotList();
            this.udcWorkStation = new Miracom.MESCore.Controls.udcSmartWorkStation();
            this.tmrGotMessage = new System.Windows.Forms.Timer(this.components);
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmfValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotCmf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResId)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.cdvFlow);
            this.pnlBottom.Controls.Add(this.cdvCmfValue);
            this.pnlBottom.Controls.Add(this.cdvLotCmf);
            this.pnlBottom.Controls.Add(this.cdvAttrValue);
            this.pnlBottom.Controls.Add(this.cdvAttr);
            this.pnlBottom.Controls.Add(this.cdvResId);
            this.pnlBottom.Controls.Add(this.lblAttrValue);
            this.pnlBottom.Controls.Add(this.txtCrrId);
            this.pnlBottom.Controls.Add(this.lblAttribute);
            this.pnlBottom.Controls.Add(this.txtLotId);
            this.pnlBottom.Controls.Add(this.lblResId);
            this.pnlBottom.Controls.Add(this.lblCarrier);
            this.pnlBottom.Controls.Add(this.lblLotCmf);
            this.pnlBottom.Controls.Add(this.lblLotId);
            this.pnlBottom.Controls.Add(this.cdvMatID);
            this.pnlBottom.Controls.Add(this.txtTotQty);
            this.pnlBottom.Controls.Add(this.txtTotLot);
            this.pnlBottom.Controls.Add(this.chkAutoRefresh);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnMessage);
            this.pnlBottom.Controls.Add(this.button1);
            this.pnlBottom.Controls.Add(this.lblTotQty);
            this.pnlBottom.Controls.Add(this.lblTotLot);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 428);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(744, 123);
            this.pnlBottom.TabIndex = 0;
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 60;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(8, 27);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(250, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 190;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            // 
            // cdvCmfValue
            // 
            this.cdvCmfValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmfValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmfValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmfValue.BtnToolTipText = "";
            this.cdvCmfValue.ButtonWidth = 20;
            this.cdvCmfValue.DescText = "";
            this.cdvCmfValue.DisplaySubItemIndex = -1;
            this.cdvCmfValue.DisplayText = "";
            this.cdvCmfValue.Focusing = null;
            this.cdvCmfValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmfValue.Index = 0;
            this.cdvCmfValue.IsViewBtnImage = false;
            this.cdvCmfValue.Location = new System.Drawing.Point(348, 51);
            this.cdvCmfValue.MaxLength = 20;
            this.cdvCmfValue.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmfValue.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmfValue.MultiSelect = false;
            this.cdvCmfValue.Name = "cdvCmfValue";
            this.cdvCmfValue.ReadOnly = true;
            this.cdvCmfValue.SameWidthHeightOfButton = false;
            this.cdvCmfValue.SearchSubItemIndex = 0;
            this.cdvCmfValue.SelectedDescIndex = -1;
            this.cdvCmfValue.SelectedDescToQueryText = "";
            this.cdvCmfValue.SelectedSubItemIndex = -1;
            this.cdvCmfValue.SelectedValueToQueryText = "";
            this.cdvCmfValue.SelectionStart = 0;
            this.cdvCmfValue.Size = new System.Drawing.Size(150, 20);
            this.cdvCmfValue.SmallImageList = null;
            this.cdvCmfValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmfValue.TabIndex = 7;
            this.cdvCmfValue.TextBoxToolTipText = "";
            this.cdvCmfValue.TextBoxWidth = 150;
            this.cdvCmfValue.VisibleButton = true;
            this.cdvCmfValue.VisibleColumnHeader = false;
            this.cdvCmfValue.VisibleDescription = false;
            this.cdvCmfValue.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCmfValue_SelectedItemChanged);
            this.cdvCmfValue.ButtonPress += new System.EventHandler(this.cdvCmfValue_ButtonPress);
            // 
            // cdvLotCmf
            // 
            this.cdvLotCmf.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotCmf.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotCmf.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLotCmf.BtnToolTipText = "";
            this.cdvLotCmf.ButtonWidth = 20;
            this.cdvLotCmf.DescText = "";
            this.cdvLotCmf.DisplaySubItemIndex = -1;
            this.cdvLotCmf.DisplayText = "";
            this.cdvLotCmf.Focusing = null;
            this.cdvLotCmf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLotCmf.Index = 0;
            this.cdvLotCmf.IsViewBtnImage = false;
            this.cdvLotCmf.Location = new System.Drawing.Point(348, 27);
            this.cdvLotCmf.MaxLength = 20;
            this.cdvLotCmf.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotCmf.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotCmf.MultiSelect = false;
            this.cdvLotCmf.Name = "cdvLotCmf";
            this.cdvLotCmf.ReadOnly = true;
            this.cdvLotCmf.SameWidthHeightOfButton = false;
            this.cdvLotCmf.SearchSubItemIndex = 0;
            this.cdvLotCmf.SelectedDescIndex = -1;
            this.cdvLotCmf.SelectedDescToQueryText = "";
            this.cdvLotCmf.SelectedSubItemIndex = -1;
            this.cdvLotCmf.SelectedValueToQueryText = "";
            this.cdvLotCmf.SelectionStart = 0;
            this.cdvLotCmf.Size = new System.Drawing.Size(150, 20);
            this.cdvLotCmf.SmallImageList = null;
            this.cdvLotCmf.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotCmf.TabIndex = 6;
            this.cdvLotCmf.TextBoxToolTipText = "";
            this.cdvLotCmf.TextBoxWidth = 150;
            this.cdvLotCmf.VisibleButton = true;
            this.cdvLotCmf.VisibleColumnHeader = false;
            this.cdvLotCmf.VisibleDescription = false;
            this.cdvLotCmf.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvLotCmf_SelectedItemChanged);
            this.cdvLotCmf.ButtonPress += new System.EventHandler(this.cdvLotCmf_ButtonPress);
            // 
            // cdvAttrValue
            // 
            this.cdvAttrValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrValue.BtnToolTipText = "";
            this.cdvAttrValue.ButtonWidth = 20;
            this.cdvAttrValue.DescText = "";
            this.cdvAttrValue.DisplaySubItemIndex = -1;
            this.cdvAttrValue.DisplayText = "";
            this.cdvAttrValue.Focusing = null;
            this.cdvAttrValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrValue.Index = 0;
            this.cdvAttrValue.IsViewBtnImage = false;
            this.cdvAttrValue.Location = new System.Drawing.Point(68, 99);
            this.cdvAttrValue.MaxLength = 30;
            this.cdvAttrValue.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrValue.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrValue.MultiSelect = false;
            this.cdvAttrValue.Name = "cdvAttrValue";
            this.cdvAttrValue.ReadOnly = true;
            this.cdvAttrValue.SameWidthHeightOfButton = false;
            this.cdvAttrValue.SearchSubItemIndex = 0;
            this.cdvAttrValue.SelectedDescIndex = -1;
            this.cdvAttrValue.SelectedDescToQueryText = "";
            this.cdvAttrValue.SelectedSubItemIndex = -1;
            this.cdvAttrValue.SelectedValueToQueryText = "";
            this.cdvAttrValue.SelectionStart = 0;
            this.cdvAttrValue.Size = new System.Drawing.Size(190, 20);
            this.cdvAttrValue.SmallImageList = null;
            this.cdvAttrValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrValue.TabIndex = 4;
            this.cdvAttrValue.TextBoxToolTipText = "";
            this.cdvAttrValue.TextBoxWidth = 190;
            this.cdvAttrValue.VisibleButton = true;
            this.cdvAttrValue.VisibleColumnHeader = false;
            this.cdvAttrValue.VisibleDescription = false;
            this.cdvAttrValue.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrValue_SelectedItemChanged);
            this.cdvAttrValue.ButtonPress += new System.EventHandler(this.cdvAttrValue_ButtonPress);
            this.cdvAttrValue.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResId_TextBoxKeyPress);
            // 
            // cdvAttr
            // 
            this.cdvAttr.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttr.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttr.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttr.BtnToolTipText = "";
            this.cdvAttr.ButtonWidth = 20;
            this.cdvAttr.DescText = "";
            this.cdvAttr.DisplaySubItemIndex = -1;
            this.cdvAttr.DisplayText = "";
            this.cdvAttr.Focusing = null;
            this.cdvAttr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttr.Index = 0;
            this.cdvAttr.IsViewBtnImage = false;
            this.cdvAttr.Location = new System.Drawing.Point(68, 75);
            this.cdvAttr.MaxLength = 30;
            this.cdvAttr.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttr.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttr.MultiSelect = false;
            this.cdvAttr.Name = "cdvAttr";
            this.cdvAttr.ReadOnly = true;
            this.cdvAttr.SameWidthHeightOfButton = false;
            this.cdvAttr.SearchSubItemIndex = 0;
            this.cdvAttr.SelectedDescIndex = -1;
            this.cdvAttr.SelectedDescToQueryText = "";
            this.cdvAttr.SelectedSubItemIndex = -1;
            this.cdvAttr.SelectedValueToQueryText = "";
            this.cdvAttr.SelectionStart = 0;
            this.cdvAttr.Size = new System.Drawing.Size(190, 20);
            this.cdvAttr.SmallImageList = null;
            this.cdvAttr.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttr.TabIndex = 3;
            this.cdvAttr.TextBoxToolTipText = "";
            this.cdvAttr.TextBoxWidth = 190;
            this.cdvAttr.VisibleButton = true;
            this.cdvAttr.VisibleColumnHeader = false;
            this.cdvAttr.VisibleDescription = false;
            this.cdvAttr.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttr_SelectedItemChanged);
            this.cdvAttr.ButtonPress += new System.EventHandler(this.cdvAttr_ButtonPress);
            this.cdvAttr.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResId_TextBoxKeyPress);
            // 
            // cdvResId
            // 
            this.cdvResId.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResId.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResId.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResId.BtnToolTipText = "";
            this.cdvResId.ButtonWidth = 20;
            this.cdvResId.DescText = "";
            this.cdvResId.DisplaySubItemIndex = -1;
            this.cdvResId.DisplayText = "";
            this.cdvResId.Focusing = null;
            this.cdvResId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResId.Index = 0;
            this.cdvResId.IsViewBtnImage = false;
            this.cdvResId.Location = new System.Drawing.Point(68, 51);
            this.cdvResId.MaxLength = 25;
            this.cdvResId.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResId.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResId.MultiSelect = false;
            this.cdvResId.Name = "cdvResId";
            this.cdvResId.ReadOnly = true;
            this.cdvResId.SameWidthHeightOfButton = false;
            this.cdvResId.SearchSubItemIndex = 0;
            this.cdvResId.SelectedDescIndex = -1;
            this.cdvResId.SelectedDescToQueryText = "";
            this.cdvResId.SelectedSubItemIndex = -1;
            this.cdvResId.SelectedValueToQueryText = "";
            this.cdvResId.SelectionStart = 0;
            this.cdvResId.Size = new System.Drawing.Size(190, 20);
            this.cdvResId.SmallImageList = null;
            this.cdvResId.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResId.TabIndex = 2;
            this.cdvResId.TextBoxToolTipText = "";
            this.cdvResId.TextBoxWidth = 190;
            this.cdvResId.VisibleButton = true;
            this.cdvResId.VisibleColumnHeader = false;
            this.cdvResId.VisibleDescription = false;
            this.cdvResId.ButtonPress += new System.EventHandler(this.cdvResId_ButtonPress);
            this.cdvResId.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResId_TextBoxKeyPress);
            // 
            // lblAttrValue
            // 
            this.lblAttrValue.AutoSize = true;
            this.lblAttrValue.Location = new System.Drawing.Point(5, 103);
            this.lblAttrValue.Name = "lblAttrValue";
            this.lblAttrValue.Size = new System.Drawing.Size(53, 13);
            this.lblAttrValue.TabIndex = 12;
            this.lblAttrValue.Text = "Attr Value";
            // 
            // txtCrrId
            // 
            this.txtCrrId.Location = new System.Drawing.Point(348, 75);
            this.txtCrrId.MaxLength = 25;
            this.txtCrrId.Name = "txtCrrId";
            this.txtCrrId.Size = new System.Drawing.Size(150, 20);
            this.txtCrrId.TabIndex = 8;
            this.txtCrrId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrrId_KeyPress);
            // 
            // lblAttribute
            // 
            this.lblAttribute.AutoSize = true;
            this.lblAttribute.Location = new System.Drawing.Point(5, 79);
            this.lblAttribute.Name = "lblAttribute";
            this.lblAttribute.Size = new System.Drawing.Size(54, 13);
            this.lblAttribute.TabIndex = 12;
            this.lblAttribute.Text = "Attr Name";
            // 
            // txtLotId
            // 
            this.txtLotId.Location = new System.Drawing.Point(348, 3);
            this.txtLotId.MaxLength = 25;
            this.txtLotId.Name = "txtLotId";
            this.txtLotId.Size = new System.Drawing.Size(150, 20);
            this.txtLotId.TabIndex = 5;
            this.txtLotId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotId_KeyPress);
            // 
            // lblResId
            // 
            this.lblResId.AutoSize = true;
            this.lblResId.Location = new System.Drawing.Point(5, 55);
            this.lblResId.Name = "lblResId";
            this.lblResId.Size = new System.Drawing.Size(40, 13);
            this.lblResId.TabIndex = 12;
            this.lblResId.Text = "Res ID";
            // 
            // lblCarrier
            // 
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.Location = new System.Drawing.Point(284, 79);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(51, 13);
            this.lblCarrier.TabIndex = 11;
            this.lblCarrier.Text = "Carrier ID";
            // 
            // lblLotCmf
            // 
            this.lblLotCmf.AutoSize = true;
            this.lblLotCmf.Location = new System.Drawing.Point(284, 29);
            this.lblLotCmf.Name = "lblLotCmf";
            this.lblLotCmf.Size = new System.Drawing.Size(47, 13);
            this.lblLotCmf.TabIndex = 10;
            this.lblLotCmf.Text = "Lot CMF";
            // 
            // lblLotId
            // 
            this.lblLotId.AutoSize = true;
            this.lblLotId.Location = new System.Drawing.Point(284, 6);
            this.lblLotId.Name = "lblLotId";
            this.lblLotId.Size = new System.Drawing.Size(36, 13);
            this.lblLotId.TabIndex = 10;
            this.lblLotId.Text = "Lot ID";
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
            this.cdvMatID.Location = new System.Drawing.Point(8, 3);
            this.cdvMatID.MaterialEnabled = true;
            this.cdvMatID.MaterialReadOnly = false;
            this.cdvMatID.Name = "cdvMatID";
            this.cdvMatID.SearchSubItemIndex = 0;
            this.cdvMatID.SelectedDescIndex = -1;
            this.cdvMatID.SelectedSubItemIndex = 0;
            this.cdvMatID.Size = new System.Drawing.Size(250, 20);
            this.cdvMatID.TabIndex = 0;
            this.cdvMatID.VersionEnabled = true;
            this.cdvMatID.VersionReadOnly = false;
            this.cdvMatID.VisibleColumnHeader = false;
            this.cdvMatID.VisibleDescription = false;
            this.cdvMatID.VisibleMaterialButton = true;
            this.cdvMatID.VisibleVersionButton = true;
            this.cdvMatID.WidthButton = 20;
            this.cdvMatID.WidthLabel = 60;
            this.cdvMatID.WidthMaterialAndVersion = 190;
            this.cdvMatID.WidthVersion = 50;
            this.cdvMatID.VersionChanged += new System.EventHandler(this.cdvMatID_VersionChanged);
            // 
            // txtTotQty
            // 
            this.txtTotQty.AutoSize = true;
            this.txtTotQty.Location = new System.Drawing.Point(598, 29);
            this.txtTotQty.Name = "txtTotQty";
            this.txtTotQty.Size = new System.Drawing.Size(50, 13);
            this.txtTotQty.TabIndex = 5;
            this.txtTotQty.Text = "Total Qty";
            this.txtTotQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotLot
            // 
            this.txtTotLot.AutoSize = true;
            this.txtTotLot.Location = new System.Drawing.Point(598, 6);
            this.txtTotLot.Name = "txtTotLot";
            this.txtTotLot.Size = new System.Drawing.Size(49, 13);
            this.txtTotLot.TabIndex = 3;
            this.txtTotLot.Text = "Total Lot";
            this.txtTotLot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Enabled = false;
            this.chkAutoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoRefresh.Location = new System.Drawing.Point(650, 3);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(94, 18);
            this.chkAutoRefresh.TabIndex = 9;
            this.chkAutoRefresh.Text = "Auto Refresh";
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(548, 96);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(518, 96);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.BackColor = System.Drawing.SystemColors.Control;
            this.btnMessage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMessage.Location = new System.Drawing.Point(578, 96);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(59, 24);
            this.btnMessage.TabIndex = 12;
            this.btnMessage.Text = "Message";
            this.btnMessage.UseVisualStyleBackColor = false;
            this.btnMessage.Visible = false;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(650, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "Close";
            this.button1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotQty
            // 
            this.lblTotQty.AutoSize = true;
            this.lblTotQty.Location = new System.Drawing.Point(513, 29);
            this.lblTotQty.Name = "lblTotQty";
            this.lblTotQty.Size = new System.Drawing.Size(79, 13);
            this.lblTotQty.TabIndex = 4;
            this.lblTotQty.Text = "Tot Qty 1/2/3 :";
            this.lblTotQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotLot
            // 
            this.lblTotLot.AutoSize = true;
            this.lblTotLot.Location = new System.Drawing.Point(513, 6);
            this.lblTotLot.Name = "lblTotLot";
            this.lblTotLot.Size = new System.Drawing.Size(47, 13);
            this.lblTotLot.TabIndex = 2;
            this.lblTotLot.Text = "Tot Lot :";
            this.lblTotLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 60000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblFormTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(744, 22);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Visible = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFormTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFormTitle.Location = new System.Drawing.Point(2, 2);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(740, 18);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Lot List Main";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFormTitle.DoubleClick += new System.EventHandler(this.lblFormTitle_DoubleClick);
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.udcLotList);
            this.pnlMid.Controls.Add(this.udcWorkStation);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 22);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(744, 406);
            this.pnlMid.TabIndex = 1;
            // 
            // udcLotList
            // 
            this.udcLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcLotList.Icons = null;
            this.udcLotList.Location = new System.Drawing.Point(0, 0);
            this.udcLotList.ModuleName = "WIP";
            this.udcLotList.Name = "udcLotList";
            this.udcLotList.ParentPath = "LIST";
            this.udcLotList.ServiceName = "WIP_View_Lot_List_Detail_By_SQL_Query";
            this.udcLotList.Size = new System.Drawing.Size(744, 346);
            this.udcLotList.TabIndex = 2;
            this.udcLotList.TabStop = false;
            this.udcLotList.ListRefreshEvent += new Miracom.MESCore.Controls.udcLotList.ListRefreshEventHandler(this.btnRefresh_Click);
            this.udcLotList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.udcLotList_SelectionChanged);
            // 
            // udcWorkStation
            // 
            this.udcWorkStation.DisplayDirection = Miracom.CliFrx.DISPLAY_DIRECTION.DISPLAY_LANDSCAPE;
            this.udcWorkStation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.udcWorkStation.Location = new System.Drawing.Point(0, 346);
            this.udcWorkStation.LotId = null;
            this.udcWorkStation.LotInfo = null;
            this.udcWorkStation.MinimumSize = new System.Drawing.Size(0, 60);
            this.udcWorkStation.Name = "udcWorkStation";
            this.udcWorkStation.Size = new System.Drawing.Size(744, 60);
            this.udcWorkStation.TabIndex = 1;
            this.udcWorkStation.TabStop = false;
            // 
            // tmrGotMessage
            // 
            this.tmrGotMessage.Interval = 1000;
            this.tmrGotMessage.Tick += new System.EventHandler(this.tmrGotMessage_Tick);
            // 
            // frmLotListMain
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 551);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmLotListMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lot List Main";
            this.Activated += new System.EventHandler(this.frmLotListMain_Activated);
            this.Closed += new System.EventHandler(this.frmLotListMain_Closed);
            this.Load += new System.EventHandler(this.frmLotListMain_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLotListMain_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmLotListMain_KeyUp);
            this.Resize += new System.EventHandler(this.frmLotListMain_Resize);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmfValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotCmf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResId)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTotQty;
        private System.Windows.Forms.Label lblTotLot;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.ContextMenu ctxMenu;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.Label txtTotLot;
        private System.Windows.Forms.Label txtTotQty;
        private Miracom.MESCore.Controls.udcMaterial cdvMatID;
        private System.Windows.Forms.Button btnMessage;
        private System.Windows.Forms.Timer tmrGotMessage;
        private Controls.udcSmartWorkStation udcWorkStation;
        private System.Windows.Forms.TextBox txtCrrId;
        private System.Windows.Forms.TextBox txtLotId;
        private System.Windows.Forms.Label lblResId;
        private System.Windows.Forms.Label lblCarrier;
        private System.Windows.Forms.Label lblLotId;
        private System.Windows.Forms.Button button1;
        private UI.Controls.MCCodeView.MCCodeView cdvResId;
        private Controls.udcLotList udcLotList;
        private UI.Controls.MCCodeView.MCCodeView cdvLotCmf;
        private UI.Controls.MCCodeView.MCCodeView cdvAttr;
        private System.Windows.Forms.Label lblAttribute;
        private System.Windows.Forms.Label lblLotCmf;
        private UI.Controls.MCCodeView.MCCodeView cdvCmfValue;
        private UI.Controls.MCCodeView.MCCodeView cdvAttrValue;
        private System.Windows.Forms.Label lblAttrValue;
        private Controls.udcFlowAndSeq cdvFlow;
    }
}