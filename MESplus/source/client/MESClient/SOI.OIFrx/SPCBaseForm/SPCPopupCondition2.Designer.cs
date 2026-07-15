namespace SOI.OIFrx
{
    partial class SPCPopupCondition2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPCPopupCondition2));
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.soiSplitContainer1 = new SOI.OIFrx.SOIControls.SOISplitContainer(this.components);
            this.udcLine = new SOI.OIFrx.udcSpread();
            this.pnlCondition = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.cdvLineCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLineCode = new System.Windows.Forms.Label();
            this.udcShop = new SOI.OIFrx.udcSpread();
            this.soiPanel1 = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.cdvShopCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblShopCode = new System.Windows.Forms.Label();
            this.btnView = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.btnClose = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.btnSelect = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiSplitContainer1)).BeginInit();
            this.soiSplitContainer1.Panel1.SuspendLayout();
            this.soiSplitContainer1.Panel2.SuspendLayout();
            this.soiSplitContainer1.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLineCode)).BeginInit();
            this.soiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShopCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnSelect);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.soiSplitContainer1);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // soiSplitContainer1
            // 
            this.soiSplitContainer1._UseOITheme = true;
            this.soiSplitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.soiSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.soiSplitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.soiSplitContainer1.Name = "soiSplitContainer1";
            // 
            // soiSplitContainer1.Panel1
            // 
            this.soiSplitContainer1.Panel1.Controls.Add(this.udcLine);
            this.soiSplitContainer1.Panel1.Controls.Add(this.pnlCondition);
            // 
            // soiSplitContainer1.Panel2
            // 
            this.soiSplitContainer1.Panel2.Controls.Add(this.udcShop);
            this.soiSplitContainer1.Panel2.Controls.Add(this.soiPanel1);
            this.soiSplitContainer1.Size = new System.Drawing.Size(742, 513);
            this.soiSplitContainer1.SplitterDistance = 371;
            this.soiSplitContainer1.SplitterWidth = 10;
            this.soiSplitContainer1.TabIndex = 3;
            // 
            // udcLine
            // 
            this.udcLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcLine.gbTitle = "View Car Type By Line";
            this.udcLine.iArryVisibleCols = null;
            this.udcLine.iCol = 0;
            this.udcLine.iRow = 0;
            this.udcLine.Location = new System.Drawing.Point(0, 32);
            this.udcLine.m_gbTitle = "View Car Type By Line";
            this.udcLine.Name = "udcLine";
            this.udcLine.ObjColumns = null;
            this.udcLine.sArrySearchCols = null;
            this.udcLine.Size = new System.Drawing.Size(371, 481);
            this.udcLine.TabIndex = 3;
            this.udcLine.tsExcelExportEnabled = true;
            this.udcLine.tsSearchMenuEnabled = true;
            this.udcLine.tsSearchTextEnabled = true;
            this.udcLine.tsSetColumnsEnabled = true;
            this.udcLine.tsSortAsscendingEnabled = true;
            this.udcLine.tsSortDescendingEnabled = true;
            this.udcLine.tsViewQueryEnabled = true;
            this.udcLine.tsZoomInOutEnabled = true;
            this.udcLine.upContext = null;
            // 
            // pnlCondition
            // 
            this.pnlCondition._UseOITheme = true;
            this.pnlCondition._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlCondition.BackColor = System.Drawing.Color.Transparent;
            this.pnlCondition.Controls.Add(this.cdvLineCode);
            this.pnlCondition.Controls.Add(this.lblLineCode);
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCondition.Location = new System.Drawing.Point(0, 0);
            this.pnlCondition.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(371, 32);
            this.pnlCondition.TabIndex = 2;
            // 
            // cdvLineCode
            // 
            this.cdvLineCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLineCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLineCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLineCode.BtnToolTipText = "";
            this.cdvLineCode.ButtonWidth = 20;
            this.cdvLineCode.DescText = "";
            this.cdvLineCode.DisplaySubItemIndex = -1;
            this.cdvLineCode.DisplayText = "";
            this.cdvLineCode.Focusing = null;
            this.cdvLineCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLineCode.Index = 0;
            this.cdvLineCode.IsViewBtnImage = false;
            this.cdvLineCode.Location = new System.Drawing.Point(131, 6);
            this.cdvLineCode.MaxLength = 20;
            this.cdvLineCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLineCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLineCode.MultiSelect = false;
            this.cdvLineCode.Name = "cdvLineCode";
            this.cdvLineCode.ReadOnly = false;
            this.cdvLineCode.SameWidthHeightOfButton = false;
            this.cdvLineCode.SearchSubItemIndex = 0;
            this.cdvLineCode.SelectedDescIndex = 1;
            this.cdvLineCode.SelectedDescToQueryText = "";
            this.cdvLineCode.SelectedSubItemIndex = -1;
            this.cdvLineCode.SelectedValueToQueryText = "";
            this.cdvLineCode.SelectionStart = 0;
            this.cdvLineCode.Size = new System.Drawing.Size(278, 20);
            this.cdvLineCode.SmallImageList = null;
            this.cdvLineCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLineCode.TabIndex = 5;
            this.cdvLineCode.TextBoxToolTipText = "";
            this.cdvLineCode.TextBoxWidth = 103;
            this.cdvLineCode.VisibleButton = true;
            this.cdvLineCode.VisibleColumnHeader = false;
            this.cdvLineCode.VisibleDescription = true;
            // 
            // lblLineCode
            // 
            this.lblLineCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineCode.Location = new System.Drawing.Point(10, 6);
            this.lblLineCode.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.lblLineCode.Name = "lblLineCode";
            this.lblLineCode.Size = new System.Drawing.Size(113, 20);
            this.lblLineCode.TabIndex = 4;
            this.lblLineCode.Text = "Line Code";
            this.lblLineCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcShop
            // 
            this.udcShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcShop.gbTitle = "View Char ID By Shop";
            this.udcShop.iArryVisibleCols = null;
            this.udcShop.iCol = 0;
            this.udcShop.iRow = 0;
            this.udcShop.Location = new System.Drawing.Point(0, 32);
            this.udcShop.m_gbTitle = "View Char ID By Shop";
            this.udcShop.Name = "udcShop";
            this.udcShop.ObjColumns = null;
            this.udcShop.sArrySearchCols = null;
            this.udcShop.Size = new System.Drawing.Size(361, 481);
            this.udcShop.TabIndex = 11;
            this.udcShop.tsExcelExportEnabled = true;
            this.udcShop.tsSearchMenuEnabled = true;
            this.udcShop.tsSearchTextEnabled = true;
            this.udcShop.tsSetColumnsEnabled = true;
            this.udcShop.tsSortAsscendingEnabled = true;
            this.udcShop.tsSortDescendingEnabled = true;
            this.udcShop.tsViewQueryEnabled = true;
            this.udcShop.tsZoomInOutEnabled = true;
            this.udcShop.upContext = null;
            // 
            // soiPanel1
            // 
            this.soiPanel1._UseOITheme = true;
            this.soiPanel1._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.soiPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiPanel1.Controls.Add(this.cdvShopCode);
            this.soiPanel1.Controls.Add(this.lblShopCode);
            this.soiPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.soiPanel1.Location = new System.Drawing.Point(0, 0);
            this.soiPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiPanel1.Name = "soiPanel1";
            this.soiPanel1.Size = new System.Drawing.Size(361, 32);
            this.soiPanel1.TabIndex = 10;
            // 
            // cdvShopCode
            // 
            this.cdvShopCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShopCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShopCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShopCode.BtnToolTipText = "";
            this.cdvShopCode.ButtonWidth = 20;
            this.cdvShopCode.DescText = "";
            this.cdvShopCode.DisplaySubItemIndex = -1;
            this.cdvShopCode.DisplayText = "";
            this.cdvShopCode.Focusing = null;
            this.cdvShopCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvShopCode.Index = 0;
            this.cdvShopCode.IsViewBtnImage = false;
            this.cdvShopCode.Location = new System.Drawing.Point(130, 6);
            this.cdvShopCode.MaxLength = 20;
            this.cdvShopCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShopCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShopCode.MultiSelect = false;
            this.cdvShopCode.Name = "cdvShopCode";
            this.cdvShopCode.ReadOnly = false;
            this.cdvShopCode.SameWidthHeightOfButton = false;
            this.cdvShopCode.SearchSubItemIndex = 0;
            this.cdvShopCode.SelectedDescIndex = 1;
            this.cdvShopCode.SelectedDescToQueryText = "";
            this.cdvShopCode.SelectedSubItemIndex = -1;
            this.cdvShopCode.SelectedValueToQueryText = "";
            this.cdvShopCode.SelectionStart = 0;
            this.cdvShopCode.Size = new System.Drawing.Size(278, 20);
            this.cdvShopCode.SmallImageList = null;
            this.cdvShopCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShopCode.TabIndex = 9;
            this.cdvShopCode.TextBoxToolTipText = "";
            this.cdvShopCode.TextBoxWidth = 103;
            this.cdvShopCode.VisibleButton = true;
            this.cdvShopCode.VisibleColumnHeader = false;
            this.cdvShopCode.VisibleDescription = true;
            // 
            // lblShopCode
            // 
            this.lblShopCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopCode.Location = new System.Drawing.Point(9, 6);
            this.lblShopCode.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.lblShopCode.Name = "lblShopCode";
            this.lblShopCode.Size = new System.Drawing.Size(113, 20);
            this.lblShopCode.TabIndex = 8;
            this.lblShopCode.Text = "Shop Code";
            this.lblShopCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnView
            // 
            this.btnView._UseOITheme = true;
            this.btnView._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance19.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.FontData.BoldAsString = "True";
            appearance19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance19.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnView.Appearance = appearance19;
            this.btnView.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance20.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance20.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnView.HotTrackAppearance = appearance20;
            this.btnView.Location = new System.Drawing.Point(386, 6);
            this.btnView.Margin = new System.Windows.Forms.Padding(0);
            this.btnView.Name = "btnView";
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance21.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance21.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance21.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnView.PressedAppearance = appearance21;
            this.btnView.ShowFocusRect = false;
            this.btnView.ShowOutline = false;
            this.btnView.Size = new System.Drawing.Size(113, 28);
            this.btnView.TabIndex = 32;
            this.btnView.Text = "View";
            this.btnView.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnView.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnView.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnClose
            // 
            this.btnClose._UseOITheme = true;
            this.btnClose._UseStyle = SOI.OIFrx.SOIButtonStyle.CancelStyle;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance6.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance6.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance6.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance6.FontData.BoldAsString = "True";
            appearance6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnClose.Appearance = appearance6;
            this.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            appearance7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            appearance7.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.btnClose.HotTrackAppearance = appearance7;
            this.btnClose.Location = new System.Drawing.Point(622, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance10.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnClose.PressedAppearance = appearance10;
            this.btnClose.ShowFocusRect = false;
            this.btnClose.ShowOutline = false;
            this.btnClose.Size = new System.Drawing.Size(113, 28);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnClose.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnClose.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnSelect
            // 
            this.btnSelect._UseOITheme = true;
            this.btnSelect._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance1.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance1.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance1.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnSelect.Appearance = appearance1;
            this.btnSelect.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance2.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnSelect.HotTrackAppearance = appearance2;
            this.btnSelect.Location = new System.Drawing.Point(504, 6);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelect.Name = "btnSelect";
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance3.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnSelect.PressedAppearance = appearance3;
            this.btnSelect.ShowFocusRect = false;
            this.btnSelect.ShowOutline = false;
            this.btnSelect.Size = new System.Drawing.Size(113, 28);
            this.btnSelect.TabIndex = 31;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnSelect.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSelect.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // SPCPopupCondition2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "SPCPopupCondition2";
            this.Text = "SPCPopupCondition2";
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.soiSplitContainer1.Panel1.ResumeLayout(false);
            this.soiSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiSplitContainer1)).EndInit();
            this.soiSplitContainer1.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvLineCode)).EndInit();
            this.soiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvShopCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SOIControls.SOISplitContainer soiSplitContainer1;
        private udcSpread udcLine;
        private SOIControls.SOIPanel pnlCondition;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLineCode;
        private System.Windows.Forms.Label lblLineCode;
        private udcSpread udcShop;
        private SOIControls.SOIPanel soiPanel1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvShopCode;
        private System.Windows.Forms.Label lblShopCode;
        public SOIControls.SOIButton btnView;
        public SOIControls.SOIButton btnClose;
        public SOIControls.SOIButton btnSelect;
    }
}