
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using FarPoint.Win.Spread;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using Miracom.TRSCore;


//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmPOPSetupLabelDesign.vb
//   Description : Create/Update/Delete Label Design Form
//
//   MES Version : 1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_LabelDesign() : View Label Design definition
//       - Update_LabelDesign() : Create/Update/Delete Label Design definition
//       - initCodeView() :   initial CodeView Control
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-04-27 : Created by HS Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _POP = True Then


namespace Miracom.POPCore
{
    public class frmPOPSetupLabelDesign : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmPOPSetupLabelDesign()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        
        private System.ComponentModel.Container components = null;
        



        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTextFont;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvBarcodeFont;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvRotate;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvData;
        private System.Windows.Forms.GroupBox grbLabelDesignName;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLabel;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Panel pnlDesign;
        private System.Windows.Forms.TabControl tabDesign;
        private System.Windows.Forms.TabPage tbpDesignItem;
        private System.Windows.Forms.GroupBox grbDesignItem;
        private FarPoint.Win.Spread.FpSpread spdDesign;
        private System.Windows.Forms.TabPage tbpImage;
        private FarPoint.Win.Spread.SheetView spdDesign_Sheet1;
        private System.Windows.Forms.TabPage tbpCommand;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Panel pnlPage;
        protected System.Windows.Forms.Button btnRefresh;
        protected System.Windows.Forms.Label lblLabelID;
        private System.Windows.Forms.Panel pnlLabelHeader;
        private System.Windows.Forms.GroupBox grbPage;
        protected System.Windows.Forms.TextBox txtPageWidth;
        protected System.Windows.Forms.Label lblPageWidth;
        protected System.Windows.Forms.TextBox txtPageHeight;
        protected System.Windows.Forms.Label lblPageHeight;
        private System.Windows.Forms.GroupBox grbLabel;
        protected System.Windows.Forms.TextBox txtLabelWidth;
        protected System.Windows.Forms.Label lblLabelWidth;
        protected System.Windows.Forms.TextBox txtLabelHeight;
        protected System.Windows.Forms.Label lblLabelHeight;
        private System.Windows.Forms.GroupBox grbMargin;
        protected System.Windows.Forms.TextBox txtMarginLeft;
        protected System.Windows.Forms.Label lblMarginLeft;
        protected System.Windows.Forms.TextBox txtMarginTop;
        protected System.Windows.Forms.Label lblMarginTop;
        private System.Windows.Forms.GroupBox grbPrint;
        protected System.Windows.Forms.TextBox txtResolution;
        protected System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkPreView;
        private System.Windows.Forms.NumericUpDown nudRatio;
        protected System.Windows.Forms.Label lblRatio;
        private System.Windows.Forms.PictureBox picLabel;
        protected System.Windows.Forms.Label lblPort;
        private CheckBox chkRPrint;
        private CheckBox chkDefaultPrinter;
        private System.Windows.Forms.ComboBox cboPort;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType5 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType6 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType7 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType8 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType9 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType15 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType16 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType17 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType18 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType10 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType19 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType20 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType21 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType22 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType23 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType24 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType25 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType26 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType27 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType28 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOPSetupLabelDesign));
            this.cdvTextFont = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvBarcodeFont = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvRotate = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlDesign = new System.Windows.Forms.Panel();
            this.tabDesign = new System.Windows.Forms.TabControl();
            this.tbpDesignItem = new System.Windows.Forms.TabPage();
            this.grbDesignItem = new System.Windows.Forms.GroupBox();
            this.spdDesign = new FarPoint.Win.Spread.FpSpread();
            this.spdDesign_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpImage = new System.Windows.Forms.TabPage();
            this.pnlLabelHeader = new System.Windows.Forms.Panel();
            this.lblRatio = new System.Windows.Forms.Label();
            this.nudRatio = new System.Windows.Forms.NumericUpDown();
            this.chkPreView = new System.Windows.Forms.CheckBox();
            this.grbPrint = new System.Windows.Forms.GroupBox();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.lblResolution = new System.Windows.Forms.Label();
            this.grbMargin = new System.Windows.Forms.GroupBox();
            this.txtMarginLeft = new System.Windows.Forms.TextBox();
            this.lblMarginLeft = new System.Windows.Forms.Label();
            this.txtMarginTop = new System.Windows.Forms.TextBox();
            this.lblMarginTop = new System.Windows.Forms.Label();
            this.grbLabel = new System.Windows.Forms.GroupBox();
            this.txtLabelWidth = new System.Windows.Forms.TextBox();
            this.lblLabelWidth = new System.Windows.Forms.Label();
            this.txtLabelHeight = new System.Windows.Forms.TextBox();
            this.lblLabelHeight = new System.Windows.Forms.Label();
            this.grbPage = new System.Windows.Forms.GroupBox();
            this.txtPageWidth = new System.Windows.Forms.TextBox();
            this.lblPageWidth = new System.Windows.Forms.Label();
            this.txtPageHeight = new System.Windows.Forms.TextBox();
            this.lblPageHeight = new System.Windows.Forms.Label();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.picLabel = new System.Windows.Forms.PictureBox();
            this.tbpCommand = new System.Windows.Forms.TabPage();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.grbLabelDesignName = new System.Windows.Forms.GroupBox();
            this.cdvLabel = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLabelID = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.chkRPrint = new System.Windows.Forms.CheckBox();
            this.chkDefaultPrinter = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTextFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBarcodeFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).BeginInit();
            this.pnlDesign.SuspendLayout();
            this.tabDesign.SuspendLayout();
            this.tbpDesignItem.SuspendLayout();
            this.grbDesignItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDesign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDesign_Sheet1)).BeginInit();
            this.tbpImage.SuspendLayout();
            this.pnlLabelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRatio)).BeginInit();
            this.grbPrint.SuspendLayout();
            this.grbMargin.SuspendLayout();
            this.grbLabel.SuspendLayout();
            this.grbPage.SuspendLayout();
            this.pnlPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLabel)).BeginInit();
            this.tbpCommand.SuspendLayout();
            this.grbLabelDesignName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.chkDefaultPrinter);
            this.pnlBottom.Controls.Add(this.chkRPrint);
            this.pnlBottom.Controls.Add(this.lblPort);
            this.pnlBottom.Controls.Add(this.cboPort);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnPrint, 0);
            this.pnlBottom.Controls.SetChildIndex(this.cboPort, 0);
            this.pnlBottom.Controls.SetChildIndex(this.lblPort, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkRPrint, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkDefaultPrinter, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlDesign);
            this.pnlCenter.Controls.Add(this.grbLabelDesignName);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Label Design Setup";
            // 
            // cdvTextFont
            // 
            this.cdvTextFont.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTextFont.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTextFont.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTextFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTextFont.Location = new System.Drawing.Point(17, 17);
            this.cdvTextFont.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTextFont.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTextFont.Name = "cdvTextFont";
            this.cdvTextFont.Size = new System.Drawing.Size(20, 20);
            this.cdvTextFont.SmallImageList = null;
            this.cdvTextFont.TabIndex = 0;
            this.cdvTextFont.TabStop = false;
            this.cdvTextFont.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTextFont.Visible = false;
            this.cdvTextFont.VisibleColumnHeader = false;
            this.cdvTextFont.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTextFont_SelectedItemChanged);
            // 
            // cdvBarcodeFont
            // 
            this.cdvBarcodeFont.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvBarcodeFont.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBarcodeFont.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBarcodeFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvBarcodeFont.Location = new System.Drawing.Point(135, 17);
            this.cdvBarcodeFont.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBarcodeFont.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBarcodeFont.Name = "cdvBarcodeFont";
            this.cdvBarcodeFont.Size = new System.Drawing.Size(20, 20);
            this.cdvBarcodeFont.SmallImageList = null;
            this.cdvBarcodeFont.TabIndex = 0;
            this.cdvBarcodeFont.TabStop = false;
            this.cdvBarcodeFont.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvBarcodeFont.Visible = false;
            this.cdvBarcodeFont.VisibleColumnHeader = false;
            this.cdvBarcodeFont.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvRotate_SelectedItemChanged);
            // 
            // cdvRotate
            // 
            this.cdvRotate.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvRotate.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRotate.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvRotate.Location = new System.Drawing.Point(273, 17);
            this.cdvRotate.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRotate.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRotate.Name = "cdvRotate";
            this.cdvRotate.Size = new System.Drawing.Size(20, 20);
            this.cdvRotate.SmallImageList = null;
            this.cdvRotate.TabIndex = 0;
            this.cdvRotate.TabStop = false;
            this.cdvRotate.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvRotate.Visible = false;
            this.cdvRotate.VisibleColumnHeader = false;
            this.cdvRotate.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvRotate_SelectedItemChanged);
            // 
            // cdvData
            // 
            this.cdvData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvData.Location = new System.Drawing.Point(379, 17);
            this.cdvData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvData.Name = "cdvData";
            this.cdvData.Size = new System.Drawing.Size(20, 20);
            this.cdvData.SmallImageList = null;
            this.cdvData.TabIndex = 0;
            this.cdvData.TabStop = false;
            this.cdvData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvData.Visible = false;
            this.cdvData.VisibleColumnHeader = false;
            this.cdvData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvRotate_SelectedItemChanged);
            // 
            // pnlDesign
            // 
            this.pnlDesign.Controls.Add(this.tabDesign);
            this.pnlDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesign.Location = new System.Drawing.Point(0, 71);
            this.pnlDesign.Name = "pnlDesign";
            this.pnlDesign.Size = new System.Drawing.Size(742, 442);
            this.pnlDesign.TabIndex = 3;
            // 
            // tabDesign
            // 
            this.tabDesign.Controls.Add(this.tbpDesignItem);
            this.tabDesign.Controls.Add(this.tbpImage);
            this.tabDesign.Controls.Add(this.tbpCommand);
            this.tabDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDesign.Location = new System.Drawing.Point(0, 0);
            this.tabDesign.Name = "tabDesign";
            this.tabDesign.SelectedIndex = 0;
            this.tabDesign.Size = new System.Drawing.Size(742, 442);
            this.tabDesign.TabIndex = 0;
            this.tabDesign.SelectedIndexChanged += new System.EventHandler(this.tabDesign_SelectedIndexChanged);
            // 
            // tbpDesignItem
            // 
            this.tbpDesignItem.Controls.Add(this.grbDesignItem);
            this.tbpDesignItem.Location = new System.Drawing.Point(4, 22);
            this.tbpDesignItem.Name = "tbpDesignItem";
            this.tbpDesignItem.Size = new System.Drawing.Size(734, 416);
            this.tbpDesignItem.TabIndex = 0;
            this.tbpDesignItem.Text = "Design Item";
            // 
            // grbDesignItem
            // 
            this.grbDesignItem.Controls.Add(this.spdDesign);
            this.grbDesignItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDesignItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbDesignItem.Location = new System.Drawing.Point(0, 0);
            this.grbDesignItem.Name = "grbDesignItem";
            this.grbDesignItem.Size = new System.Drawing.Size(734, 416);
            this.grbDesignItem.TabIndex = 6;
            this.grbDesignItem.TabStop = false;
            // 
            // spdDesign
            // 
            this.spdDesign.AccessibleDescription = "spdDesign, Sheet1, Row 0, Column 0, ";
            this.spdDesign.BackColor = System.Drawing.SystemColors.Control;
            this.spdDesign.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDesign.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdDesign.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDesign.HorizontalScrollBar.Name = "";
            this.spdDesign.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdDesign.HorizontalScrollBar.TabIndex = 12;
            this.spdDesign.Location = new System.Drawing.Point(3, 16);
            this.spdDesign.Name = "spdDesign";
            this.spdDesign.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdDesign.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdDesign.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDesign_Sheet1});
            this.spdDesign.Size = new System.Drawing.Size(728, 397);
            this.spdDesign.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdDesign.TabIndex = 5;
            this.spdDesign.TabStop = false;
            this.spdDesign.TextTipDelay = 200;
            this.spdDesign.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDesign.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDesign.VerticalScrollBar.Name = "";
            this.spdDesign.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdDesign.VerticalScrollBar.TabIndex = 13;
            this.spdDesign.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdDesign_Change);
            this.spdDesign.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdDesign_EnterCell);
            this.spdDesign.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdDesign_CellClick);
            this.spdDesign.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdDesign_ButtonClicked);
            this.spdDesign.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdDesign_ComboCloseUp);
            this.spdDesign.ComboSelChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdDesign_ComboSelChange);
            this.spdDesign.SetViewportLeftColumn(0, 0, 8);
            this.spdDesign.SetActiveViewport(0, 0, -1);
            // 
            // spdDesign_Sheet1
            // 
            this.spdDesign_Sheet1.Reset();
            spdDesign_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDesign_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDesign_Sheet1.ColumnCount = 48;
            spdDesign_Sheet1.RowCount = 2;
            this.spdDesign_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDesign_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sel";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Type";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Position X";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Position Y";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Variable Flag";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Data";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 8).ColumnSpan = 2;
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 8).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Rotate";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 9).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 10).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Reverse";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 11).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Not Print";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 12).ColumnSpan = 2;
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 12).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Text Font";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 14).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Text Width";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 15).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Text Height";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 16).ColumnSpan = 2;
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 16).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Barcode Font";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 18).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Bar Width";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 19).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Bar Height";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 20).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Bar Rate";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 21).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Above";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 22).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Below";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 23).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Check Digit";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 24).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Element Height";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 25).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "ECC Level";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 26).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Column Count";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 27).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Row Count";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 28).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Format Id";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 29).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Truncate Flag";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 30).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Feed";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 31).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Narrow Bar Width";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 32).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Narrow Space Width";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 33).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Wide Bar Width";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 34).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Wide Space Width";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 35).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Char Space Width";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 36).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "1-Cell Width";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 37).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Background Image";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 38).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Image Scale X";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 39).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Image Scale Y";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 40).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Graphic Width";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 41).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Graphic Height";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 42).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Graphic Thick";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "SQL";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 44).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Create User ID";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 45).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Create Time";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 46).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Update User ID";
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 47).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdDesign_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Update Time";
            this.spdDesign_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDesign_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdDesign_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdDesign_Sheet1.Columns.Get(0).Width = 31F;
            checkBoxCellType1.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdDesign_Sheet1.Columns.Get(1).CellType = checkBoxCellType1;
            this.spdDesign_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(1).Label = "Sel";
            this.spdDesign_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(1).Width = 35F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "Text",
        "Barcode",
        "Image",
        "Graphic"};
            this.spdDesign_Sheet1.Columns.Get(2).CellType = comboBoxCellType1;
            this.spdDesign_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDesign_Sheet1.Columns.Get(2).Label = "Type";
            this.spdDesign_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(3).CellType = textCellType1;
            this.spdDesign_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(3).Label = "Position X";
            this.spdDesign_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(3).Width = 70F;
            this.spdDesign_Sheet1.Columns.Get(4).CellType = textCellType2;
            this.spdDesign_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(4).Label = "Position Y";
            this.spdDesign_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(4).Width = 70F;
            this.spdDesign_Sheet1.Columns.Get(5).CellType = checkBoxCellType2;
            this.spdDesign_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(5).Label = "Variable Flag";
            this.spdDesign_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(5).Width = 110F;
            this.spdDesign_Sheet1.Columns.Get(6).CellType = textCellType3;
            this.spdDesign_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDesign_Sheet1.Columns.Get(6).Label = "Data";
            this.spdDesign_Sheet1.Columns.Get(6).Locked = false;
            this.spdDesign_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(6).Width = 136F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdDesign_Sheet1.Columns.Get(7).CellType = buttonCellType1;
            this.spdDesign_Sheet1.Columns.Get(7).Width = 21F;
            this.spdDesign_Sheet1.Columns.Get(8).CellType = textCellType4;
            this.spdDesign_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDesign_Sheet1.Columns.Get(8).Label = "Rotate";
            this.spdDesign_Sheet1.Columns.Get(8).Locked = true;
            this.spdDesign_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdDesign_Sheet1.Columns.Get(9).CellType = buttonCellType2;
            this.spdDesign_Sheet1.Columns.Get(9).Width = 21F;
            this.spdDesign_Sheet1.Columns.Get(10).CellType = checkBoxCellType3;
            this.spdDesign_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(10).Label = "Reverse";
            this.spdDesign_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(11).CellType = checkBoxCellType4;
            this.spdDesign_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(11).Label = "Not Print";
            this.spdDesign_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(12).Label = "Text Font";
            this.spdDesign_Sheet1.Columns.Get(12).Locked = true;
            this.spdDesign_Sheet1.Columns.Get(12).Width = 70F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdDesign_Sheet1.Columns.Get(13).CellType = buttonCellType3;
            this.spdDesign_Sheet1.Columns.Get(13).Width = 21F;
            this.spdDesign_Sheet1.Columns.Get(14).Label = "Text Width";
            this.spdDesign_Sheet1.Columns.Get(14).Width = 70F;
            this.spdDesign_Sheet1.Columns.Get(15).CellType = textCellType5;
            this.spdDesign_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(15).Label = "Text Height";
            this.spdDesign_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(15).Width = 70F;
            this.spdDesign_Sheet1.Columns.Get(16).CellType = textCellType6;
            this.spdDesign_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdDesign_Sheet1.Columns.Get(16).Label = "Barcode Font";
            this.spdDesign_Sheet1.Columns.Get(16).Locked = true;
            this.spdDesign_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(16).Width = 70F;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.Text = "...";
            this.spdDesign_Sheet1.Columns.Get(17).CellType = buttonCellType4;
            this.spdDesign_Sheet1.Columns.Get(17).Width = 21F;
            this.spdDesign_Sheet1.Columns.Get(18).CellType = textCellType7;
            this.spdDesign_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(18).Label = "Bar Width";
            this.spdDesign_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(18).Width = 89F;
            this.spdDesign_Sheet1.Columns.Get(19).CellType = textCellType8;
            this.spdDesign_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(19).Label = "Bar Height";
            this.spdDesign_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(19).Width = 70F;
            this.spdDesign_Sheet1.Columns.Get(20).CellType = textCellType9;
            this.spdDesign_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(20).Label = "Bar Rate";
            this.spdDesign_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(21).CellType = checkBoxCellType5;
            this.spdDesign_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(21).Label = "Above";
            this.spdDesign_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(21).Width = 100F;
            this.spdDesign_Sheet1.Columns.Get(22).CellType = checkBoxCellType6;
            this.spdDesign_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(22).Label = "Below";
            this.spdDesign_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(22).Width = 110F;
            this.spdDesign_Sheet1.Columns.Get(23).CellType = checkBoxCellType7;
            this.spdDesign_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(23).Label = "Check Digit";
            this.spdDesign_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(23).Width = 100F;
            this.spdDesign_Sheet1.Columns.Get(24).CellType = textCellType10;
            this.spdDesign_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(24).Label = "Element Height";
            this.spdDesign_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(24).Width = 96F;
            this.spdDesign_Sheet1.Columns.Get(25).CellType = textCellType11;
            this.spdDesign_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(25).Label = "ECC Level";
            this.spdDesign_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(25).Width = 75F;
            this.spdDesign_Sheet1.Columns.Get(26).CellType = textCellType12;
            this.spdDesign_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(26).Label = "Column Count";
            this.spdDesign_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(26).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(27).Label = "Row Count";
            this.spdDesign_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(27).Width = 76F;
            this.spdDesign_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(28).Label = "Format Id";
            this.spdDesign_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(29).CellType = checkBoxCellType8;
            this.spdDesign_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(29).Label = "Truncate Flag";
            this.spdDesign_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(29).Width = 86F;
            this.spdDesign_Sheet1.Columns.Get(30).CellType = checkBoxCellType9;
            this.spdDesign_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(30).Label = "Feed";
            this.spdDesign_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(30).Visible = false;
            this.spdDesign_Sheet1.Columns.Get(30).Width = 70F;
            this.spdDesign_Sheet1.Columns.Get(31).CellType = textCellType13;
            this.spdDesign_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(31).Label = "Narrow Bar Width";
            this.spdDesign_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(31).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(32).CellType = textCellType14;
            this.spdDesign_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(32).Label = "Narrow Space Width";
            this.spdDesign_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(32).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(33).CellType = textCellType15;
            this.spdDesign_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(33).Label = "Wide Bar Width";
            this.spdDesign_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(33).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(34).CellType = textCellType16;
            this.spdDesign_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(34).Label = "Wide Space Width";
            this.spdDesign_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(34).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(35).CellType = textCellType17;
            this.spdDesign_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(35).Label = "Char Space Width";
            this.spdDesign_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(35).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(36).CellType = textCellType18;
            this.spdDesign_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDesign_Sheet1.Columns.Get(36).Label = "1-Cell Width";
            this.spdDesign_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(36).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(37).CellType = checkBoxCellType10;
            this.spdDesign_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(37).Label = "Background Image";
            this.spdDesign_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(37).Width = 120F;
            this.spdDesign_Sheet1.Columns.Get(38).CellType = textCellType19;
            this.spdDesign_Sheet1.Columns.Get(38).Label = "Image Scale X";
            this.spdDesign_Sheet1.Columns.Get(38).Width = 110F;
            this.spdDesign_Sheet1.Columns.Get(39).CellType = textCellType20;
            this.spdDesign_Sheet1.Columns.Get(39).Label = "Image Scale Y";
            this.spdDesign_Sheet1.Columns.Get(39).Width = 110F;
            this.spdDesign_Sheet1.Columns.Get(40).CellType = textCellType21;
            this.spdDesign_Sheet1.Columns.Get(40).Label = "Graphic Width";
            this.spdDesign_Sheet1.Columns.Get(40).Width = 110F;
            this.spdDesign_Sheet1.Columns.Get(41).CellType = textCellType22;
            this.spdDesign_Sheet1.Columns.Get(41).Label = "Graphic Height";
            this.spdDesign_Sheet1.Columns.Get(41).Width = 110F;
            this.spdDesign_Sheet1.Columns.Get(42).CellType = textCellType23;
            this.spdDesign_Sheet1.Columns.Get(42).Label = "Graphic Thick";
            this.spdDesign_Sheet1.Columns.Get(42).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(43).CellType = textCellType24;
            this.spdDesign_Sheet1.Columns.Get(43).Label = "SQL";
            this.spdDesign_Sheet1.Columns.Get(43).Width = 361F;
            this.spdDesign_Sheet1.Columns.Get(44).CellType = textCellType25;
            this.spdDesign_Sheet1.Columns.Get(44).Label = "Create User ID";
            this.spdDesign_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(44).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(45).CellType = textCellType26;
            this.spdDesign_Sheet1.Columns.Get(45).Label = "Create Time";
            this.spdDesign_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(45).Width = 80F;
            this.spdDesign_Sheet1.Columns.Get(46).CellType = textCellType27;
            this.spdDesign_Sheet1.Columns.Get(46).Label = "Update User ID";
            this.spdDesign_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(46).Width = 90F;
            this.spdDesign_Sheet1.Columns.Get(47).CellType = textCellType28;
            this.spdDesign_Sheet1.Columns.Get(47).Label = "Update Time";
            this.spdDesign_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDesign_Sheet1.Columns.Get(47).Width = 80F;
            this.spdDesign_Sheet1.FrozenColumnCount = 8;
            this.spdDesign_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDesign_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdDesign_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDesign_Sheet1.RowHeader.Visible = false;
            this.spdDesign_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDesign_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDesign_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpImage
            // 
            this.tbpImage.AutoScroll = true;
            this.tbpImage.Controls.Add(this.pnlLabelHeader);
            this.tbpImage.Controls.Add(this.pnlPage);
            this.tbpImage.Location = new System.Drawing.Point(4, 22);
            this.tbpImage.Name = "tbpImage";
            this.tbpImage.Size = new System.Drawing.Size(734, 416);
            this.tbpImage.TabIndex = 1;
            this.tbpImage.Text = "Image";
            this.tbpImage.Visible = false;
            // 
            // pnlLabelHeader
            // 
            this.pnlLabelHeader.Controls.Add(this.lblRatio);
            this.pnlLabelHeader.Controls.Add(this.nudRatio);
            this.pnlLabelHeader.Controls.Add(this.chkPreView);
            this.pnlLabelHeader.Controls.Add(this.grbPrint);
            this.pnlLabelHeader.Controls.Add(this.grbMargin);
            this.pnlLabelHeader.Controls.Add(this.grbLabel);
            this.pnlLabelHeader.Controls.Add(this.grbPage);
            this.pnlLabelHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLabelHeader.Location = new System.Drawing.Point(524, 0);
            this.pnlLabelHeader.Name = "pnlLabelHeader";
            this.pnlLabelHeader.Size = new System.Drawing.Size(210, 416);
            this.pnlLabelHeader.TabIndex = 1;
            // 
            // lblRatio
            // 
            this.lblRatio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRatio.Location = new System.Drawing.Point(12, 310);
            this.lblRatio.Name = "lblRatio";
            this.lblRatio.Size = new System.Drawing.Size(100, 14);
            this.lblRatio.TabIndex = 5;
            this.lblRatio.Text = "Ratio(%)";
            this.lblRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudRatio
            // 
            this.nudRatio.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudRatio.Location = new System.Drawing.Point(118, 307);
            this.nudRatio.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudRatio.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudRatio.Name = "nudRatio";
            this.nudRatio.Size = new System.Drawing.Size(80, 20);
            this.nudRatio.TabIndex = 6;
            this.nudRatio.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudRatio.ValueChanged += new System.EventHandler(this.nudRatio_ValueChanged);
            // 
            // chkPreView
            // 
            this.chkPreView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPreView.Location = new System.Drawing.Point(12, 286);
            this.chkPreView.Name = "chkPreView";
            this.chkPreView.Size = new System.Drawing.Size(108, 18);
            this.chkPreView.TabIndex = 4;
            this.chkPreView.Text = "All Item Preview";
            this.chkPreView.CheckedChanged += new System.EventHandler(this.chkPreView_CheckedChanged);
            // 
            // grbPrint
            // 
            this.grbPrint.Controls.Add(this.txtResolution);
            this.grbPrint.Controls.Add(this.lblResolution);
            this.grbPrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbPrint.Location = new System.Drawing.Point(0, 211);
            this.grbPrint.Name = "grbPrint";
            this.grbPrint.Size = new System.Drawing.Size(210, 70);
            this.grbPrint.TabIndex = 3;
            this.grbPrint.TabStop = false;
            this.grbPrint.Text = "Print";
            // 
            // txtResolution
            // 
            this.txtResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResolution.Location = new System.Drawing.Point(118, 16);
            this.txtResolution.MaxLength = 11;
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.ReadOnly = true;
            this.txtResolution.Size = new System.Drawing.Size(80, 20);
            this.txtResolution.TabIndex = 1;
            this.txtResolution.TabStop = false;
            this.txtResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblResolution
            // 
            this.lblResolution.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolution.Location = new System.Drawing.Point(12, 18);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(100, 14);
            this.lblResolution.TabIndex = 0;
            this.lblResolution.Text = "Resolution(DPI)";
            this.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.txtMarginLeft);
            this.grbMargin.Controls.Add(this.lblMarginLeft);
            this.grbMargin.Controls.Add(this.txtMarginTop);
            this.grbMargin.Controls.Add(this.lblMarginTop);
            this.grbMargin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbMargin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbMargin.Location = new System.Drawing.Point(0, 141);
            this.grbMargin.Name = "grbMargin";
            this.grbMargin.Size = new System.Drawing.Size(210, 70);
            this.grbMargin.TabIndex = 2;
            this.grbMargin.TabStop = false;
            this.grbMargin.Text = "Margin(mm)";
            // 
            // txtMarginLeft
            // 
            this.txtMarginLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarginLeft.Location = new System.Drawing.Point(118, 16);
            this.txtMarginLeft.MaxLength = 11;
            this.txtMarginLeft.Name = "txtMarginLeft";
            this.txtMarginLeft.ReadOnly = true;
            this.txtMarginLeft.Size = new System.Drawing.Size(80, 20);
            this.txtMarginLeft.TabIndex = 1;
            this.txtMarginLeft.TabStop = false;
            this.txtMarginLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMarginLeft
            // 
            this.lblMarginLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMarginLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarginLeft.Location = new System.Drawing.Point(12, 18);
            this.lblMarginLeft.Name = "lblMarginLeft";
            this.lblMarginLeft.Size = new System.Drawing.Size(100, 14);
            this.lblMarginLeft.TabIndex = 0;
            this.lblMarginLeft.Text = "Left";
            this.lblMarginLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMarginTop
            // 
            this.txtMarginTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarginTop.Location = new System.Drawing.Point(118, 40);
            this.txtMarginTop.MaxLength = 11;
            this.txtMarginTop.Name = "txtMarginTop";
            this.txtMarginTop.ReadOnly = true;
            this.txtMarginTop.Size = new System.Drawing.Size(80, 20);
            this.txtMarginTop.TabIndex = 3;
            this.txtMarginTop.TabStop = false;
            this.txtMarginTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMarginTop
            // 
            this.lblMarginTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMarginTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarginTop.Location = new System.Drawing.Point(12, 42);
            this.lblMarginTop.Name = "lblMarginTop";
            this.lblMarginTop.Size = new System.Drawing.Size(100, 14);
            this.lblMarginTop.TabIndex = 2;
            this.lblMarginTop.Text = "Top";
            this.lblMarginTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbLabel
            // 
            this.grbLabel.Controls.Add(this.txtLabelWidth);
            this.grbLabel.Controls.Add(this.lblLabelWidth);
            this.grbLabel.Controls.Add(this.txtLabelHeight);
            this.grbLabel.Controls.Add(this.lblLabelHeight);
            this.grbLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbLabel.Location = new System.Drawing.Point(0, 71);
            this.grbLabel.Name = "grbLabel";
            this.grbLabel.Size = new System.Drawing.Size(210, 70);
            this.grbLabel.TabIndex = 1;
            this.grbLabel.TabStop = false;
            this.grbLabel.Text = "Label(mm)";
            // 
            // txtLabelWidth
            // 
            this.txtLabelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelWidth.Location = new System.Drawing.Point(118, 16);
            this.txtLabelWidth.MaxLength = 11;
            this.txtLabelWidth.Name = "txtLabelWidth";
            this.txtLabelWidth.ReadOnly = true;
            this.txtLabelWidth.Size = new System.Drawing.Size(80, 20);
            this.txtLabelWidth.TabIndex = 1;
            this.txtLabelWidth.TabStop = false;
            this.txtLabelWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLabelWidth
            // 
            this.lblLabelWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLabelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelWidth.Location = new System.Drawing.Point(12, 18);
            this.lblLabelWidth.Name = "lblLabelWidth";
            this.lblLabelWidth.Size = new System.Drawing.Size(100, 14);
            this.lblLabelWidth.TabIndex = 0;
            this.lblLabelWidth.Text = "Width";
            this.lblLabelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLabelHeight
            // 
            this.txtLabelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelHeight.Location = new System.Drawing.Point(118, 40);
            this.txtLabelHeight.MaxLength = 11;
            this.txtLabelHeight.Name = "txtLabelHeight";
            this.txtLabelHeight.ReadOnly = true;
            this.txtLabelHeight.Size = new System.Drawing.Size(80, 20);
            this.txtLabelHeight.TabIndex = 3;
            this.txtLabelHeight.TabStop = false;
            this.txtLabelHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLabelHeight
            // 
            this.lblLabelHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLabelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelHeight.Location = new System.Drawing.Point(12, 42);
            this.lblLabelHeight.Name = "lblLabelHeight";
            this.lblLabelHeight.Size = new System.Drawing.Size(100, 14);
            this.lblLabelHeight.TabIndex = 2;
            this.lblLabelHeight.Text = "Height";
            this.lblLabelHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbPage
            // 
            this.grbPage.Controls.Add(this.txtPageWidth);
            this.grbPage.Controls.Add(this.lblPageWidth);
            this.grbPage.Controls.Add(this.txtPageHeight);
            this.grbPage.Controls.Add(this.lblPageHeight);
            this.grbPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbPage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbPage.Location = new System.Drawing.Point(0, 0);
            this.grbPage.Name = "grbPage";
            this.grbPage.Size = new System.Drawing.Size(210, 71);
            this.grbPage.TabIndex = 0;
            this.grbPage.TabStop = false;
            this.grbPage.Text = "Page(mm)";
            // 
            // txtPageWidth
            // 
            this.txtPageWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageWidth.Location = new System.Drawing.Point(118, 16);
            this.txtPageWidth.MaxLength = 11;
            this.txtPageWidth.Name = "txtPageWidth";
            this.txtPageWidth.ReadOnly = true;
            this.txtPageWidth.Size = new System.Drawing.Size(80, 20);
            this.txtPageWidth.TabIndex = 1;
            this.txtPageWidth.TabStop = false;
            this.txtPageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPageWidth
            // 
            this.lblPageWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPageWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageWidth.Location = new System.Drawing.Point(12, 18);
            this.lblPageWidth.Name = "lblPageWidth";
            this.lblPageWidth.Size = new System.Drawing.Size(100, 14);
            this.lblPageWidth.TabIndex = 0;
            this.lblPageWidth.Text = "Width";
            this.lblPageWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPageHeight
            // 
            this.txtPageHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageHeight.Location = new System.Drawing.Point(118, 40);
            this.txtPageHeight.MaxLength = 11;
            this.txtPageHeight.Name = "txtPageHeight";
            this.txtPageHeight.ReadOnly = true;
            this.txtPageHeight.Size = new System.Drawing.Size(80, 20);
            this.txtPageHeight.TabIndex = 3;
            this.txtPageHeight.TabStop = false;
            this.txtPageHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPageHeight
            // 
            this.lblPageHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPageHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageHeight.Location = new System.Drawing.Point(12, 42);
            this.lblPageHeight.Name = "lblPageHeight";
            this.lblPageHeight.Size = new System.Drawing.Size(100, 14);
            this.lblPageHeight.TabIndex = 2;
            this.lblPageHeight.Text = "Height";
            this.lblPageHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPage
            // 
            this.pnlPage.BackColor = System.Drawing.Color.Azure;
            this.pnlPage.Controls.Add(this.picLabel);
            this.pnlPage.Location = new System.Drawing.Point(10, 10);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(352, 332);
            this.pnlPage.TabIndex = 0;
            this.pnlPage.Visible = false;
            // 
            // picLabel
            // 
            this.picLabel.BackColor = System.Drawing.Color.White;
            this.picLabel.Location = new System.Drawing.Point(42, 40);
            this.picLabel.Name = "picLabel";
            this.picLabel.Size = new System.Drawing.Size(258, 244);
            this.picLabel.TabIndex = 2;
            this.picLabel.TabStop = false;
            // 
            // tbpCommand
            // 
            this.tbpCommand.Controls.Add(this.txtCommand);
            this.tbpCommand.Location = new System.Drawing.Point(4, 22);
            this.tbpCommand.Name = "tbpCommand";
            this.tbpCommand.Size = new System.Drawing.Size(734, 416);
            this.tbpCommand.TabIndex = 2;
            this.tbpCommand.Text = "Command";
            // 
            // txtCommand
            // 
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(0, 0);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.ReadOnly = true;
            this.txtCommand.Size = new System.Drawing.Size(734, 416);
            this.txtCommand.TabIndex = 0;
            this.txtCommand.TabStop = false;
            // 
            // grbLabelDesignName
            // 
            this.grbLabelDesignName.Controls.Add(this.cdvLabel);
            this.grbLabelDesignName.Controls.Add(this.lblLabelID);
            this.grbLabelDesignName.Controls.Add(this.txtDesc);
            this.grbLabelDesignName.Controls.Add(this.Label6);
            this.grbLabelDesignName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbLabelDesignName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbLabelDesignName.Location = new System.Drawing.Point(0, 0);
            this.grbLabelDesignName.Name = "grbLabelDesignName";
            this.grbLabelDesignName.Size = new System.Drawing.Size(742, 71);
            this.grbLabelDesignName.TabIndex = 0;
            this.grbLabelDesignName.TabStop = false;
            // 
            // cdvLabel
            // 
            this.cdvLabel.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLabel.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLabel.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLabel.BtnToolTipText = "";
            this.cdvLabel.ButtonWidth = 20;
            this.cdvLabel.DescText = "";
            this.cdvLabel.DisplaySubItemIndex = 0;
            this.cdvLabel.DisplayText = "";
            this.cdvLabel.Focusing = null;
            this.cdvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLabel.Index = 0;
            this.cdvLabel.IsViewBtnImage = false;
            this.cdvLabel.Location = new System.Drawing.Point(118, 14);
            this.cdvLabel.MaxLength = 25;
            this.cdvLabel.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLabel.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLabel.Name = "cdvLabel";
            this.cdvLabel.ReadOnly = false;
            this.cdvLabel.SameWidthHeightOfButton = false;
            this.cdvLabel.SearchSubItemIndex = 0;
            this.cdvLabel.SelectedDescIndex = -1;
            this.cdvLabel.SelectedSubItemIndex = 0;
            this.cdvLabel.SelectionStart = 0;
            this.cdvLabel.Size = new System.Drawing.Size(200, 21);
            this.cdvLabel.SmallImageList = null;
            this.cdvLabel.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLabel.TabIndex = 1;
            this.cdvLabel.TextBoxToolTipText = "";
            this.cdvLabel.TextBoxWidth = 200;
            this.cdvLabel.VisibleButton = true;
            this.cdvLabel.VisibleColumnHeader = false;
            this.cdvLabel.VisibleDescription = false;
            this.cdvLabel.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvLabel_SelectedItemChanged);
            this.cdvLabel.ButtonPress += new System.EventHandler(this.cdvLabel_ButtonPress);
            this.cdvLabel.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvLabel_TextBoxKeyPress);
            // 
            // lblLabelID
            // 
            this.lblLabelID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLabelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelID.Location = new System.Drawing.Point(12, 18);
            this.lblLabelID.Name = "lblLabelID";
            this.lblLabelID.Size = new System.Drawing.Size(100, 14);
            this.lblLabelID.TabIndex = 0;
            this.lblLabelID.Text = "Label";
            this.lblLabelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(118, 38);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(614, 20);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TabStop = false;
            // 
            // Label6
            // 
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(12, 42);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(100, 14);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Description";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(10, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Location = new System.Drawing.Point(170, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 26);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print Test";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblPort
            // 
            this.lblPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPort.Location = new System.Drawing.Point(42, 13);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(42, 14);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Port";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.Items.AddRange(new object[] {
            "SPOOL",
            "LPT1",
            "LPT2",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cboPort.Location = new System.Drawing.Point(88, 10);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(76, 21);
            this.cboPort.TabIndex = 6;
            this.cboPort.SelectedIndexChanged += new System.EventHandler(this.cboPort_SelectedIndexChanged);
            // 
            // chkRPrint
            // 
            this.chkRPrint.AutoSize = true;
            this.chkRPrint.Location = new System.Drawing.Point(266, 12);
            this.chkRPrint.Name = "chkRPrint";
            this.chkRPrint.Size = new System.Drawing.Size(96, 17);
            this.chkRPrint.TabIndex = 8;
            this.chkRPrint.Text = "Remote Printer";
            this.chkRPrint.CheckedChanged += new System.EventHandler(this.chkRPrint_CheckedChanged);
            // 
            // chkDefaultPrinter
            // 
            this.chkDefaultPrinter.AutoSize = true;
            this.chkDefaultPrinter.Location = new System.Drawing.Point(364, 12);
            this.chkDefaultPrinter.Name = "chkDefaultPrinter";
            this.chkDefaultPrinter.Size = new System.Drawing.Size(93, 17);
            this.chkDefaultPrinter.TabIndex = 9;
            this.chkDefaultPrinter.Text = "Default Printer";
            // 
            // frmPOPSetupLabelDesign
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmPOPSetupLabelDesign";
            this.Text = "Label Design Setup";
            this.Activated += new System.EventHandler(this.frmPOPSetupLabelDesign_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvTextFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBarcodeFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).EndInit();
            this.pnlDesign.ResumeLayout(false);
            this.tabDesign.ResumeLayout(false);
            this.tbpDesignItem.ResumeLayout(false);
            this.grbDesignItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDesign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDesign_Sheet1)).EndInit();
            this.tbpImage.ResumeLayout(false);
            this.pnlLabelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRatio)).EndInit();
            this.grbPrint.ResumeLayout(false);
            this.grbPrint.PerformLayout();
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.grbLabel.ResumeLayout(false);
            this.grbLabel.PerformLayout();
            this.grbPage.ResumeLayout(false);
            this.grbPage.PerformLayout();
            this.pnlPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLabel)).EndInit();
            this.tbpCommand.ResumeLayout(false);
            this.tbpCommand.PerformLayout();
            this.grbLabelDesignName.ResumeLayout(false);
            this.grbLabelDesignName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLabel)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Event Definition"
        //------------------------------------------
        private Rs232 m_CommPort = new Rs232(); //?대깽?몃? ?꾩옱??Form?먯꽌 諛쏄린?꾪빐?쒕뒗 WithEvent瑜??좎뼵?댁＜?댁빞 ?쒕떎.
        //------------------------------------------
        #endregion
        
        #region "Constant Defintion"
        
        private const int SEQ_COL = 0;
        private const int CHECK_COL = 1;
        private const int OBJECT_TYPE_COL = 2;
        private const int POSITION_X_COL = 3;
        private const int POSITION_Y_COL = 4;
        private const int VARIABLE_COL = 5;
        private const int DATA_COL = 6;
        private const int ROTATE_COL = 8;
        private const int REVERSE_COL = 10;
        private const int NOT_PRINT_COL = 11;
        private const int TEXT_FONT_COL = 12;
        private const int TEXT_WIDTH_COL = 14;
        private const int TEXT_HEIGHT_COL = 15;
        
        private const int BARCODE_FONT_COL = 16;
        private const int BARCODE_WIDTH_COL = 18;
        private const int BARCODE_HEIGHT_COL = 19;
        private const int BARCODE_RATE_COL = 20;
        private const int BARCODE_ABOVE_COL = 21;
        private const int BARCODE_BELOW_COL = 22;
        private const int BARCODE_CHECK_COL = 23;
        private const int ELEMENT_HEIGHT_COL = 24;
        private const int ECC_LEVEL_COL = 25;
        private const int COL_COUNT_COL = 26;
        private const int ROW_COUNT_COL = 27;
        private const int FORMAT_ID_COL = 28;
        private const int TRUN_FLAG_COL = 29;
        private const int FEED_COL = 30;

        //Added by for TPCL
        private const int BARCODE_NAR_BAR_WIDTH_COL = 31;
        private const int BARCODE_NAR_SPACE_WIDTH_COL = 32;
        private const int BARCODE_WID_BAR_WIDTH_COL = 33;
        private const int BARCODE_WID_SPACE_WIDTH_COL = 34;
        private const int BARCODE_C_C_SPACE_COL = 35;
        private const int BARCODE_1_CELL_WIDTH_COL = 36;

        private const int BACKGROUND_COL = 37;
        private const int IMAGE_SCALE_X_COL = 38;
        private const int IMAGE_SCALE_Y_COL = 39;
        
        private const int GRAPHIC_WIDTH_COL = 40;
        private const int GRAPHIC_HEIGHT_COL = 41;
        private const int GRAPHIC_THICK_COL = 42;

        private const int ARGUMENT_SQL_COL = 43;
        
        private const int CREATE_USER_COL = 44;
        private const int CREATE_TIME_COL = 45;
        private const int UPDATE_USER_COL = 46;
        private const int UPDATE_TIME_COL = 47;
        
        private const int MAX_DATA_COUNT = 100;
        
        private const double SCREEN_DPI = 73; //Monitor Resolution
        private const double INCHE_MILI_RATE = 25.4; //1 Inche = 25.4mm
        
        #endregion
        
        #region "Variable Definition"
        
        //Private Structure Format
        //    Dim Col_Fmt As String
        //    Dim Col_Size As Integer
        //End Structure
        
        //Dim FormatTbl(20) As Format
        
        private bool b_load_flag;
        
        double dOriginX;
        double dOriginY;
        double dPageWidth;
        double dPageHeight;
        double dLabelWidth;
        double dLabelHeight;
        double dMarginTop;
        double dMarginLeft;
        char sInvert;
        char sReverse;
        char sLabelType;
        double dResolution;
        char sPrintSpeed;
        double dDarkness;
        double dPrintQty;
        string sPrintIP;
        string sUser;
        string sPassword;
        string sPrinterType;

        string sFeedPosition;
        string sCutPosition;
        string sBackPosition;
        string sPrinterMode;
        string sTagMode;
        string sCutInterval;
        string sSensorType;
        string sIssueMode;
        string sTagRotation;
        string sRibonOption;
        
        float sngRatio;
        string[] PrintDataArray;
        
        #endregion
        
        #region "Function Definition"
        
        private bool PreviewImage()
        {
            
            try
            {
                //이미지 적용 필요 도시바용
                if (MPCF.Trim(sPrinterType) == "" || sPrinterType.Equals(modPOPPrint.POP_PRINT_TYPE_TPCL))
                {
                    return true;
                }

                if (spdDesign.Sheets[0].RowCount <= 0)
                {
                    return true;
                }
                
                pnlPage.Top = 0;
                pnlPage.Left = 0;
                pnlPage.Width = (int)(dPageWidth * SCREEN_DPI / INCHE_MILI_RATE * sngRatio);
                pnlPage.Height = (int)(dPageHeight * SCREEN_DPI / INCHE_MILI_RATE * sngRatio);

                picLabel.Top = (int)(dMarginTop * SCREEN_DPI / INCHE_MILI_RATE * sngRatio);
                picLabel.Left = (int)(dMarginLeft * SCREEN_DPI / INCHE_MILI_RATE * sngRatio);
                picLabel.Width = (int)(dLabelWidth * SCREEN_DPI / INCHE_MILI_RATE * sngRatio);
                picLabel.Height = (int)(dLabelHeight * SCREEN_DPI / INCHE_MILI_RATE * sngRatio);
                
                if (picLabel.Width <= 0 || picLabel.Height <= 0)
                {
                    return true;
                }
                
                picLabel_Paint();
                
                pnlPage.Visible = true;
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        private void picLabel_Paint()
        {
            
            int i;
            float sngDotRate;
            float sngFontSize;
            Font NewFont;
            Image NewImage;
            float CurPosX = 0.0F;
            float CurPosY = 0.0F;
            double dInitPosX;
            double dInitPosY;
            string strFilePath;
            string strCurrentDir;
            Brush NewBrush = null;
            //Dim fieldRotateAngle As Single
            SizeF fieldSize = new SizeF();
            
            try
            {
                
                Bitmap bmpC = new Bitmap(picLabel.Width, picLabel.Height);
                Graphics graph = Graphics.FromImage(bmpC);
                
                graph.FillRectangle(Brushes.White, 0, 0, picLabel.Width, picLabel.Height);
                graph.DrawRectangle(Pens.Black, 0, 0, picLabel.Width - 1, picLabel.Height - 1);

                sngDotRate = (float)(dResolution / SCREEN_DPI);
                dInitPosX = dOriginX / sngDotRate * sngRatio - dMarginLeft * SCREEN_DPI / INCHE_MILI_RATE * sngRatio;
                dInitPosY = dOriginY / sngDotRate * sngRatio - dMarginTop * SCREEN_DPI / INCHE_MILI_RATE * sngRatio;
                
                for (i = 0; i < spdDesign.Sheets[0].RowCount; i++)
                {
                    
                    if ((spdDesign.Sheets[0].GetValue(i, NOT_PRINT_COL) == null || Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, NOT_PRINT_COL)) == false || chkPreView.Checked == true) && 
                        (MPCF.Trim(spdDesign.Sheets[0].Cells[i, POSITION_X_COL].Text) != "" && 
                         MPCF.Trim(spdDesign.Sheets[0].Cells[i, POSITION_Y_COL].Text) != ""))
                    {
                        
                        if (MPCF.Trim(spdDesign.Sheets[0].Cells[i, OBJECT_TYPE_COL].Text) != "")
                        {
                            CurPosX = (float)(MPCF.ToDbl(spdDesign.Sheets[0].Cells[i, POSITION_X_COL].Text) / sngDotRate * sngRatio + dInitPosX);
                            CurPosY = (float)(MPCF.ToDbl(spdDesign.Sheets[0].Cells[i, POSITION_Y_COL].Text) / sngDotRate * sngRatio + dInitPosY);

                            if (spdDesign.Sheets[0].GetValue(i, REVERSE_COL) != null && Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, REVERSE_COL)) == true)
                            {
                                NewBrush = Brushes.Red;
                            }
                            else
                            {
                                if (MPCF.Trim(sReverse) == "R")
                                {
                                    NewBrush = Brushes.Red;
                                }
                                else
                                {
                                    NewBrush = Brushes.Black;
                                }
                            }
                            
                        }

                        if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_BARCODE || 
                            MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_TEXT)
                        {
                            Matrix fieldMatrix = new Matrix();
                            Pen fieldPen = new Pen(Color.Transparent, 1);
                            PointF fieldRotatePoint = new PointF(CurPosX, CurPosY);
                            float fieldRotateAngle = 0.0F;
                            
                            
                            if (MPCF.Trim(spdDesign.Sheets[0].Cells[i, ROTATE_COL].Text) == MPGC.POP_ROTATE_NORMAL)
                            {
                                fieldRotateAngle = 0.0F;
                            }
                            else if (MPCF.Trim(spdDesign.Sheets[0].Cells[i, ROTATE_COL].Text) == MPGC.POP_ROTATE_ROTATED)
                            {
                                fieldRotateAngle = 90.0F;
                            }
                            else if (MPCF.Trim(spdDesign.Sheets[0].Cells[i, ROTATE_COL].Text) == MPGC.POP_ROTATE_INVERTED)
                            {
                                fieldRotateAngle = 180.0F;
                            }
                            else if (MPCF.Trim(spdDesign.Sheets[0].Cells[i, ROTATE_COL].Text) == MPGC.POP_ROTATE_BOTTOMUP)
                            {
                                fieldRotateAngle = 270.0F;
                            }
                            
                            graph.DrawRectangle(fieldPen, 0, 0, 100, 200);
                            
                            fieldMatrix.RotateAt(fieldRotateAngle, fieldRotatePoint);
                            
                            graph.Transform = fieldMatrix;

                            if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_BARCODE)
                            {
                                sngFontSize = (float)(MPCF.ToDbl(MPCF.Trim(spdDesign.Sheets[0].Cells[i, BARCODE_HEIGHT_COL].Text)) /(sngDotRate * 2) * sngRatio);
                                NewFont = new System.Drawing.Font("3 of 9 Barcode", sngFontSize, FontStyle.Regular);
                            }
                            else
                            {
                                sngFontSize = (float)(MPCF.ToDbl(MPCF.Trim(spdDesign.Sheets[0].Cells[i, TEXT_HEIGHT_COL].Text)) /(sngDotRate * 2) * sngRatio);
                                NewFont = new System.Drawing.Font("ZB:Zebra ZPL A", sngFontSize, FontStyle.Regular);
                            }
                            
                            fieldSize = graph.MeasureString(MPCF.Trim(spdDesign.Sheets[0].Cells[i, DATA_COL].Text), NewFont);
                            
                            if (fieldRotateAngle == 90.0F)
                            {
                                CurPosY = CurPosY - fieldSize.Height;
                            }
                            else if (fieldRotateAngle == 180.0F)
                            {
                                CurPosX = CurPosX - fieldSize.Width;
                                CurPosY = CurPosY - fieldSize.Height;
                            }
                            else if (fieldRotateAngle == 270.0F)
                            {
                                CurPosX = CurPosX - fieldSize.Width;
                            }
                            
                            graph.DrawString(spdDesign.Sheets[0].Cells[i, DATA_COL].Text, NewFont, NewBrush, CurPosX, CurPosY);
                            
                            NewFont.Dispose();
                            
                        }

                        if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_IMAGE)
                        {
                            strCurrentDir = Directory.GetCurrentDirectory();
                            strFilePath = strCurrentDir + "\\Image\\" + MPCF.Trim(spdDesign.Sheets[0].Cells[i, DATA_COL].Text) + ".bmp";
                            
                            if (File.Exists(strFilePath) == true)
                            {
                                
                                NewImage = Image.FromFile(strFilePath);
                                
                                fieldSize.Width = System.Convert.ToSingle(NewImage.Width / sngDotRate * System.Convert.ToSingle(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_X_COL))) * sngRatio;
                                fieldSize.Height = System.Convert.ToSingle(NewImage.Height / sngDotRate * System.Convert.ToSingle(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_Y_COL))) * sngRatio;
                                
                                graph.DrawImage(NewImage, CurPosX, CurPosY, fieldSize.Width, fieldSize.Height);
                                
                                NewImage.Dispose();
                            }
                        }

                        if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_GRAPHIC)
                        {
                            
                            Pen NewPen;
                            
                            NewPen = new Pen(Brushes.Black, System.Convert.ToSingle(spdDesign.Sheets[0].GetValue(i, GRAPHIC_THICK_COL)) / sngDotRate * sngRatio);
                            
                            CurPosX = CurPosX + System.Convert.ToSingle(spdDesign.Sheets[0].GetValue(i, GRAPHIC_THICK_COL)) /(sngDotRate * 2) * sngRatio;
                            CurPosY = CurPosY + System.Convert.ToSingle(spdDesign.Sheets[0].GetValue(i, GRAPHIC_THICK_COL)) /(sngDotRate * 2) * sngRatio;
                            
                            fieldSize.Width = (System.Convert.ToSingle(spdDesign.Sheets[0].GetValue(i, GRAPHIC_WIDTH_COL)) - System.Convert.ToSingle(spdDesign.Sheets[0].GetValue(i, GRAPHIC_THICK_COL))) / sngDotRate * sngRatio;
                            fieldSize.Height = (System.Convert.ToSingle(spdDesign.Sheets[0].GetValue(i, GRAPHIC_HEIGHT_COL)) - System.Convert.ToSingle(spdDesign.Sheets[0].GetValue(i, GRAPHIC_THICK_COL))) / sngDotRate * sngRatio;
                            
                            if (fieldSize.Width < 1)
                            {
                                fieldSize.Width = 1;
                            }
                            if (fieldSize.Height < 1)
                            {
                                fieldSize.Height = 1;
                            }
                            
                            graph.DrawRectangle(NewPen, CurPosX, CurPosY, fieldSize.Width, fieldSize.Height);
                            
                            NewPen.Dispose();
                            
                        }
                    }
                }
                
                MemoryStream ms = new MemoryStream();
                
                bmpC.Save(ms, ImageFormat.Jpeg);
                
                picLabel.Image = Image.FromStream(ms);
                
                if (MPCF.Trim(sInvert) == "I")
                {
                    picLabel.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                
                bmpC.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        
        //-----------------------------------------------------------------------------
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        //-----------------------------------------------------------------------------
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            int i = 0;
            
            try
            {
                switch (FuncName.TrimEnd())
                {
                    case "Update_Label_Design":
                        
                        if (cdvLabel.Text.Trim() == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvLabel.Select();
                            return false;
                        }
                        
                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:
                                
                                for (i = 0; i < spdDesign.Sheets[0].RowCount; i++)
                                {
                                    if (spdDesign.Sheets[0].GetValue(i, CHECK_COL) != null &&
                                        Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, CHECK_COL)) == true)
                                    {
                                        if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL)) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            spdDesign.Select();
                                            return false;
                                        }
                                        if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, POSITION_X_COL)) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            spdDesign.Select();
                                            return false;
                                        }
                                        
                                        if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, POSITION_Y_COL)) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            spdDesign.Select();
                                            return false;
                                        }

                                        if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) != MPGC.POP_TYPE_GRAPHIC)
                                        {
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, DATA_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }
                                        }

                                        if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_TEXT)
                                        {
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, TEXT_FONT_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }
                                            //Width(Range : 10~1500)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, TEXT_WIDTH_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }
                                            //Height(Range : 10~1500)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, TEXT_HEIGHT_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }
                                        }
                                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_BARCODE)
                                        {
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }

                                            //Bar Height(Default:10)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_HEIGHT_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, BARCODE_HEIGHT_COL, 10);
                                            }

                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) != MPGC.POP_BAR_FONT_PDF417
                                                && MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) != modPOPPrint.POP_BAR_FONT_DATA_MATRIX)
                                            {
                                                //Narrow Bar width(Default : 2)(Range : 1~10)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_WIDTH_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, BARCODE_WIDTH_COL, 2);
                                                }

                                                //Bar Rate(Default:3)(Range : 2.0~3.0)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_RATE_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, BARCODE_RATE_COL, 3);
                                                }
                                            }
                                            
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) == MPGC.POP_BAR_FONT_PDF417)
                                            {
                                                //Element Height(Default:10)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ELEMENT_HEIGHT_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, ELEMENT_HEIGHT_COL, spdDesign.Sheets[0].GetValue(i, BARCODE_HEIGHT_COL));
                                                }
                                                //ECC Level(Default:0)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ECC_LEVEL_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, ECC_LEVEL_COL, 0);
                                                }
                                                //Column Count(Default:1)(Range : 1~30)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, COL_COUNT_COL, 1);
                                                }
                                                //Row Count(Default:1)(Range : 1~90)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROW_COUNT_COL)) == "")
                                                {
                                                    if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)) == "1")
                                                    {
                                                        spdDesign.Sheets[0].SetValue(i, ROW_COUNT_COL, 2);
                                                    }
                                                    else
                                                    {
                                                        spdDesign.Sheets[0].SetValue(i, ROW_COUNT_COL, 1);
                                                    }
                                                }
                                            }

                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) == modPOPPrint.POP_BAR_FONT_DATA_MATRIX)
                                            {
                                                //Element Height(Default:10)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ELEMENT_HEIGHT_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, ELEMENT_HEIGHT_COL, spdDesign.Sheets[0].GetValue(i, BARCODE_HEIGHT_COL));
                                                }
                                                //ECC Level(Default:0)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ECC_LEVEL_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, ECC_LEVEL_COL, 0);
                                                }
                                                //Column Count(Default:1)(Range : 1~30)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, COL_COUNT_COL, 1);
                                                }
                                                //Row Count(Default:1)(Range : 1~90)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROW_COUNT_COL)) == "")
                                                {
                                                    if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)) == "1")
                                                    {
                                                        spdDesign.Sheets[0].SetValue(i, ROW_COUNT_COL, 2);
                                                    }
                                                    else
                                                    {
                                                        spdDesign.Sheets[0].SetValue(i, ROW_COUNT_COL, 1);
                                                    }
                                                }

                                                //Format Id (defautl : 6)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, FORMAT_ID_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, FORMAT_ID_COL, 6);
                                                }
                                            }
                                        }
                                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_IMAGE)
                                        {
                                            //Image Scale X(Default:1)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_X_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, IMAGE_SCALE_X_COL, 1);
                                            }
                                            //Image Scale Y(Default:1)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_Y_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, IMAGE_SCALE_Y_COL, 1);
                                            }
                                        }
                                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_GRAPHIC)
                                        {
                                            //Graphic Width(Default:0)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, GRAPHIC_WIDTH_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, GRAPHIC_WIDTH_COL, 0);
                                            }
                                            //Graphic Height(Default:0)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, GRAPHIC_HEIGHT_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, GRAPHIC_HEIGHT_COL, 0);
                                            }
                                            //Graphic Thick(Default:1)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, GRAPHIC_THICK_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, GRAPHIC_THICK_COL, 1);
                                            }
                                        }
                                        
                                    }
                                }
                                break;
                                
                                
                            case MPGC.MP_STEP_UPDATE:
                                
                                
                                for (i = 0; i < spdDesign.Sheets[0].RowCount; i++)
                                {
                                    if (spdDesign.Sheets[0].GetValue(i, CHECK_COL) != null &&
                                        Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, CHECK_COL)) == true)
                                    {
                                        if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL)) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            spdDesign.Select();
                                            return false;
                                        }
                                        if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, POSITION_X_COL)) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            spdDesign.Select();
                                            return false;
                                        }
                                        
                                        if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, POSITION_Y_COL)) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            spdDesign.Select();
                                            return false;
                                        }

                                        if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) != MPGC.POP_TYPE_GRAPHIC)
                                        {
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, DATA_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }
                                        }

                                        if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_TEXT)
                                        {
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, TEXT_FONT_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }
                                            //Width(Range : 10~1500)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, TEXT_WIDTH_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }
                                            //Height(Range : 10~1500)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, TEXT_HEIGHT_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }
                                        }
                                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_BARCODE)
                                        {
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }

                                            //Bar Height(Default:10)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_HEIGHT_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, BARCODE_HEIGHT_COL, 10);
                                            }

                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) != MPGC.POP_BAR_FONT_PDF417
                                                && MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) != modPOPPrint.POP_BAR_FONT_DATA_MATRIX)
                                            {
                                                //Narrow Bar width(Default : 2)(Range : 1~10)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_WIDTH_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, BARCODE_WIDTH_COL, 2);
                                                }
                                                
                                                //Bar Rate(Default:3)(Range : 2.0~3.0)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_RATE_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, BARCODE_RATE_COL, 3);
                                                }
                                            }
                                            
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) == MPGC.POP_BAR_FONT_PDF417)
                                            {
                                                //Element Height(Default:10)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ELEMENT_HEIGHT_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, ELEMENT_HEIGHT_COL, spdDesign.Sheets[0].GetValue(i, BARCODE_HEIGHT_COL));
                                                }
                                                //ECC Level(Default:0)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ECC_LEVEL_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, ECC_LEVEL_COL, 0);
                                                }
                                                //Column Count(Default:1)(Range : 1~30)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, COL_COUNT_COL, 1);
                                                }
                                                //Row Count(Default:1)(Range : 1~90)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROW_COUNT_COL)) == "")
                                                {
                                                    if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)) == "1")
                                                    {
                                                        spdDesign.Sheets[0].SetValue(i, ROW_COUNT_COL, 2);
                                                    }
                                                    else
                                                    {
                                                        spdDesign.Sheets[0].SetValue(i, ROW_COUNT_COL, 1);
                                                    }
                                                }
                                            }

                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL)) == modPOPPrint.POP_BAR_FONT_DATA_MATRIX)
                                            {
                                                //Element Height(Default:10)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ELEMENT_HEIGHT_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, ELEMENT_HEIGHT_COL, spdDesign.Sheets[0].GetValue(i, BARCODE_HEIGHT_COL));
                                                }
                                                //ECC Level(Default:0)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ECC_LEVEL_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, ECC_LEVEL_COL, 0);
                                                }
                                                //Column Count(Default:1)(Range : 1~30)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, COL_COUNT_COL, 1);
                                                }
                                                //Row Count(Default:1)(Range : 1~90)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROW_COUNT_COL)) == "")
                                                {
                                                    if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)) == "1")
                                                    {
                                                        spdDesign.Sheets[0].SetValue(i, ROW_COUNT_COL, 2);
                                                    }
                                                    else
                                                    {
                                                        spdDesign.Sheets[0].SetValue(i, ROW_COUNT_COL, 1);
                                                    }
                                                }

                                                //Format Id (defautl : 6)
                                                if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, FORMAT_ID_COL)) == "")
                                                {
                                                    spdDesign.Sheets[0].SetValue(i, FORMAT_ID_COL, 6);
                                                }
                                            }
                                        }
                                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_IMAGE)
                                        {
                                            //Image Scale X(Default:1)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_X_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, IMAGE_SCALE_X_COL, 1);
                                            }
                                            //Image Scale Y(Default:1)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_Y_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, IMAGE_SCALE_Y_COL, 1);
                                            }
                                        }
                                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_GRAPHIC)
                                        {
                                            //Graphic Width(Default:0)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, GRAPHIC_WIDTH_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, GRAPHIC_WIDTH_COL, 0);
                                            }
                                            //Graphic Height(Default:0)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, GRAPHIC_HEIGHT_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, GRAPHIC_HEIGHT_COL, 0);
                                            }
                                            //Graphic Thick(Default:1)
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, GRAPHIC_THICK_COL)) == "")
                                            {
                                                spdDesign.Sheets[0].SetValue(i, GRAPHIC_THICK_COL, 1);
                                            }
                                        }

                                        if (spdDesign.Sheets[0].GetValue(i, VARIABLE_COL) != null &&
                                            Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, VARIABLE_COL)) == true)
                                        {
                                            //Argument SQL is not define
                                            if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ARGUMENT_SQL_COL)) == "")
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                                spdDesign.Select();
                                                return false;
                                            }
                                        }
                                    }
                                }
                                break;
                                
                            case MPGC.MP_STEP_DELETE:
                                
                                break;
                                
                        }
                        break;
                }
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        //-----------------------------------------------------------------------------
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        //-----------------------------------------------------------------------------
        private void ClearData(char ProcStep)
        {
            
            try
            {
                
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this);
                    MPCF.ClearList(spdDesign);
                }
                else if (ProcStep == '2')
                {
                    //FieldClear(Me.pnlCenter, cdvLabel.Text)
                    txtDesc.Text = "";
                    MPCF.ClearList(spdDesign);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //-----------------------------------------------------------------------------
        //
        // View_Label_Design()
        //       - View Label Design
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        private bool View_Label_Design()
        {
            
            int i;
            int LastSeq = 0;
            
            TRSNode in_node = new TRSNode("View_Label_Design_In");
            TRSNode out_node = new TRSNode("View_Label_Design_Out");
            
            try
            {
                //ClearData('1')
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LABEL_ID", cdvLabel.Text.TrimEnd());
                
                do
                {
                    
                    if (MPCR.CallService("POP", "POP_View_Label_Design", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    txtDesc.Text = out_node.GetString("LABEL_DESC").TrimEnd();

                    dPageWidth = out_node.GetDouble("PAGE_WIDTH");
                    dPageHeight = out_node.GetDouble("PAGE_HEIGHT");
                    dLabelWidth = out_node.GetDouble("LABEL_WIDTH");
                    dLabelHeight = out_node.GetDouble("LABEL_HEIGHT");
                    dMarginTop = out_node.GetDouble("MARGIN_TOP");
                    dMarginLeft = out_node.GetDouble("MARGIN_LEFT");
                    dOriginX = out_node.GetDouble("ORIGIN_X");
                    dOriginY = out_node.GetDouble("ORIGIN_Y");
                    sLabelType = out_node.GetChar("LABEL_TYPE");
                    sInvert = out_node.GetChar("INVERT");
                    sReverse = out_node.GetChar("REVERSE");
                    dResolution = MPCF.ToDbl(out_node.GetString("RESOLUTION"));
                    sPrintSpeed = out_node.GetChar("PRINT_SPEED");
                    dDarkness = out_node.GetInt("DARKNESS");
                    dPrintQty = out_node.GetInt("PRINT_QTY");
                    sPrinterType = out_node.GetString("PRINTER_TYPE").TrimEnd();

                    sFeedPosition = out_node.GetString("FEED_POSITION").TrimEnd();
                    sCutPosition = out_node.GetString("CUT_POSITION").TrimEnd();
                    sBackPosition = out_node.GetString("BACK_FEED_LENGTH").TrimEnd();
                    sPrinterMode = out_node.GetString("PRINTER_MODE").TrimEnd();
                    sTagMode = out_node.GetString("TAG_MODE_FLAG").TrimEnd();
                    sCutInterval = out_node.GetString("CUT_INTERVAL").TrimEnd();
                    sSensorType = out_node.GetString("SENSOR_TYPE").TrimEnd();
                    sIssueMode = out_node.GetString("ISSUE_MODE").TrimEnd();
                    sTagRotation = out_node.GetString("TAG_ROTATION").TrimEnd();
                    sRibonOption = out_node.GetString("RIBON_OPTION").TrimEnd();
                    
                    txtPageWidth.Text = Convert.ToString(dPageWidth);
                    txtPageHeight.Text = Convert.ToString(dPageHeight);
                    txtLabelWidth.Text = Convert.ToString(dLabelWidth);
                    txtLabelHeight.Text = Convert.ToString(dLabelHeight);
                    txtMarginLeft.Text = Convert.ToString(dMarginLeft);
                    txtMarginTop.Text = Convert.ToString(dMarginTop);
                    txtResolution.Text = Convert.ToString(dResolution);

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        int LastRow;
                        
                        spdDesign.Sheets[0].RowCount++;
                        LastRow = spdDesign.Sheets[0].RowCount - 1;
                        
                        FarPoint.Win.Spread.SheetView with_1 = spdDesign.Sheets[0];

                        LastSeq = MPCF.ToInt(out_node.GetList(0)[i].GetInt("SEQ_NUM"));
                        with_1.SetValue(LastRow, SEQ_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("SEQ_NUM")));
                        with_1.SetValue(LastRow, POSITION_X_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("POSITION_X")));
                        with_1.SetValue(LastRow, POSITION_Y_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("POSITION_Y")));
                        with_1.SetValue(LastRow, VARIABLE_COL, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("VARIABLE_FLAG")) == "Y") ? true : false));

                        with_1.SetValue(LastRow, DATA_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("DATA")));
                        with_1.SetValue(LastRow, ROTATE_COL, MPCF.Trim(out_node.GetList(0)[i].GetChar("ROTATE")));
                        with_1.SetValue(LastRow, REVERSE_COL, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("REVERSE_FLAG")) == "Y") ? true : false));
                        
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TYPE")) == MPGC.POP_TYPE_TEXT)
                        {
                            with_1.SetValue(LastRow, OBJECT_TYPE_COL, "Text");
                            with_1.SetValue(LastRow, TEXT_FONT_COL, MPCF.Trim(out_node.GetList(0)[i].GetChar("FONT")));
                            with_1.SetValue(LastRow, TEXT_WIDTH_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("WIDTH")));
                            with_1.SetValue(LastRow, TEXT_HEIGHT_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("HEIGHT")));
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetString("TYPE")) == MPGC.POP_TYPE_BARCODE)
                        {
                            with_1.SetValue(LastRow, OBJECT_TYPE_COL, "Barcode");
                            with_1.SetValue(LastRow, BARCODE_FONT_COL, MPCF.Trim(out_node.GetList(0)[i].GetChar("FONT")));
                            with_1.SetValue(LastRow, BARCODE_WIDTH_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("WIDTH")));
                            with_1.SetValue(LastRow, BARCODE_HEIGHT_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("HEIGHT")));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("FONT")) == MPGC.POP_BAR_FONT_PDF417)
                            {
                                with_1.SetValue(LastRow, ELEMENT_HEIGHT_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("HEIGHT")));
                                with_1.SetValue(LastRow, ECC_LEVEL_COL, MPCF.Trim(out_node.GetList(0)[i].GetChar("ECC_LEVEL")));
                                with_1.SetValue(LastRow, COL_COUNT_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("COLUMN_COUNT")));
                                with_1.SetValue(LastRow, ROW_COUNT_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("ROW_COUNT")));
                                with_1.SetValue(LastRow, TRUN_FLAG_COL, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("TRUN_FLAG")) == "Y") ? true : false));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("FONT")) == modPOPPrint.POP_BAR_FONT_DATA_MATRIX)
                            {
                                with_1.SetValue(LastRow, ELEMENT_HEIGHT_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("HEIGHT")));
                                with_1.SetValue(LastRow, ECC_LEVEL_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("MAGNI_FACTOR")));
                                with_1.SetValue(LastRow, COL_COUNT_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("COLUMN_COUNT")));
                                with_1.SetValue(LastRow, ROW_COUNT_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("ROW_COUNT")));
                                with_1.SetValue(LastRow, FORMAT_ID_COL, MPCF.Trim(out_node.GetList(0)[i].GetChar("MODEL")));
                                
                            }

                            //Added by barcode for tpcl
                            with_1.SetValue(LastRow, BARCODE_NAR_BAR_WIDTH_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("NAR_BAR_WIDTH")));
                            with_1.SetValue(LastRow, BARCODE_NAR_SPACE_WIDTH_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("NAR_SPACE_WIDTH")));
                            with_1.SetValue(LastRow, BARCODE_WID_BAR_WIDTH_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("WID_BAR_WIDTH")));
                            with_1.SetValue(LastRow, BARCODE_WID_SPACE_WIDTH_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("WID_SPACE_WIDTH")));
                            with_1.SetValue(LastRow, BARCODE_C_C_SPACE_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_SPACE_WIDTH")));
                            with_1.SetValue(LastRow, BARCODE_1_CELL_WIDTH_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("1_CELL_WIDTH")));
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetString("TYPE")) == MPGC.POP_TYPE_IMAGE)
                        {
                            with_1.SetValue(LastRow, OBJECT_TYPE_COL, "Image");
                            with_1.SetValue(LastRow, IMAGE_SCALE_X_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("WIDTH")));
                            with_1.SetValue(LastRow, IMAGE_SCALE_Y_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("HEIGHT")));
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetString("TYPE")) == MPGC.POP_TYPE_GRAPHIC)
                        {
                            with_1.SetValue(LastRow, OBJECT_TYPE_COL, "Graphic");
                            with_1.SetValue(LastRow, GRAPHIC_WIDTH_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("WIDTH")));
                            with_1.SetValue(LastRow, GRAPHIC_HEIGHT_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("HEIGHT")));
                            with_1.SetValue(LastRow, GRAPHIC_THICK_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("THICK")));
                        }
                        with_1.SetValue(LastRow, BARCODE_RATE_COL, MPCF.Trim(out_node.GetList(0)[i].GetInt("BAR_RATE")));
                        
                        with_1.SetValue(LastRow, BARCODE_ABOVE_COL, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("ABOVE_FLAG")) == "Y") ? true : false));
                        with_1.SetValue(LastRow, BARCODE_BELOW_COL, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("BELOW_FLAG")) == "Y") ? true : false));
                        with_1.SetValue(LastRow, BARCODE_CHECK_COL, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CHECK_DIGIT")) == "Y") ? true : false));
                        with_1.SetValue(LastRow, FEED_COL, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("FEED_FLAG")) == "Y") ? true : false));
                        with_1.SetValue(LastRow, NOT_PRINT_COL, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("PRINT_FLAG")) == "N") ? true : false));
                        with_1.SetValue(LastRow, BACKGROUND_COL, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("BACKGROUND_FLAG")) == "Y") ? true : false));

                        with_1.SetValue(LastRow, ARGUMENT_SQL_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("ARG_SQL")));
                        
                        with_1.SetValue(LastRow, CREATE_USER_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID")));
                        with_1.SetValue(LastRow, CREATE_TIME_COL, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME"))));
                        with_1.SetValue(LastRow, UPDATE_USER_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID")));
                        with_1.SetValue(LastRow, UPDATE_TIME_COL, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME"))));

                        SetRowType(LastRow);
                    }

                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
                } while (in_node.GetInt("NEXT_SEQ_NUM") > 0);
                
                spdDesign.Sheets[0].RowCount++;
                spdDesign.Sheets[0].SetValue(spdDesign.Sheets[0].RowCount - 1, SEQ_COL, LastSeq + 1);
                
                for (i = 1; i <= GRAPHIC_THICK_COL; i++)
                {
                    spdDesign.Sheets[0].Cells.Get(spdDesign.Sheets[0].RowCount - 1, i).BackColor = System.Drawing.Color.WhiteSmoke;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //-----------------------------------------------------------------------------
        //
        // Update_Label_Design()
        //       - Create/Update/Delete Label Design
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        //-----------------------------------------------------------------------------
        private bool Update_Label_Design(char ProcStep)
        {
            
            int i = 0;
            int iIndex = 0;
            
            TRSNode in_node = new TRSNode("Update_Label_Design_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode item_list;

            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("LABEL_ID", cdvLabel.Text.TrimEnd());
                in_node.AddString("LABEL_DESC", txtDesc.Text.TrimEnd());

                iIndex = 0;
                for (i = 0; i < spdDesign.Sheets[0].RowCount; i++)
                {
                    if (spdDesign.Sheets[0].GetValue(i, CHECK_COL) != null && Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, CHECK_COL)) == true)
                    {
                        item_list = in_node.AddNode("ITEM_LIST");

                        item_list.SetInt("SEQ_NUM", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, SEQ_COL)));
                        item_list.SetString("TYPE", MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1));
                        item_list.SetInt("POSITION_X", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, POSITION_X_COL)));
                        item_list.SetInt("POSITION_Y", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, POSITION_Y_COL)));

                        if (spdDesign.Sheets[0].GetValue(i, VARIABLE_COL) == null)
                            item_list.SetChar("VARIABLE_FLAG",'N');
                        else
                            item_list.SetChar("VARIABLE_FLAG",(Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, VARIABLE_COL)) == true) ? 'Y' : 'N');

                        item_list.SetString("DATA", MPCF.Trim(spdDesign.Sheets[0].GetValue(i, DATA_COL)));
                        if (item_list.GetChar("VARIABLE_FLAG") == 'Y')
                        //if (Update_Label_Design_In._C.item_list[iIndex].variable_flag == 'Y')
                        {
                            if (item_list.GetString("DATA").Substring(0, 1) != "$") // if (Update_Label_Design_In._C.item_list[iIndex].data.Substring(0, 1) != "$") 
                                //Update_Label_Design_In._C.item_list[iIndex].data = "$" + Update_Label_Design_In._C.item_list[iIndex].data;
                                item_list.SetString("DATA", "$" + item_list.GetString("DATA"));

                            //Update_Label_Design_In._C.item_list[iIndex].data = MPCF.ToUpper(Update_Label_Design_In._C.item_list[iIndex].data);
                            item_list.SetString("DATA", MPCF.ToUpper(item_list.GetString("DATA")));
                        }
                        //Update_Label_Design_In._C.item_list[iIndex].rotate = MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROTATE_COL)) != "" ? MPCF.ToChar(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROTATE_COL))) : 'N';
                        item_list.SetChar("ROTATE", MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROTATE_COL)) != "" ? MPCF.ToChar(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROTATE_COL))) : 'N');

                        if (spdDesign.Sheets[0].GetValue(i, REVERSE_COL) == null)
                            //Update_Label_Design_In._C.item_list[iIndex].reverse_flag = 'N';
                            item_list.SetChar("REVERSE_FLAG", 'N');
                        else
                            //Update_Label_Design_In._C.item_list[iIndex].reverse_flag = (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, REVERSE_COL)) == true) ? 'Y' : 'N';
                            item_list.SetChar("REVERSE_FLAG", (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, REVERSE_COL)) == true) ? 'Y' : 'N');

                        if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_TEXT)
                        {
                            item_list.SetChar("FONT", MPCF.ToChar(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, TEXT_FONT_COL))));
                            item_list.SetInt("WIDTH", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, TEXT_WIDTH_COL)));
                            item_list.SetInt("HEIGHT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, TEXT_HEIGHT_COL)));
                        }
                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_BARCODE)
                        {
                            item_list.SetChar("FONT", MPCF.ToChar(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL))));
                            item_list.SetInt("WIDTH", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, BARCODE_WIDTH_COL)));
                            item_list.SetInt("HEIGHT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, BARCODE_HEIGHT_COL)));
                            item_list.SetInt("BAR_RATE", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, BARCODE_RATE_COL)));

                            if (spdDesign.Sheets[0].GetValue(i, BARCODE_ABOVE_COL) == null)
                                item_list.SetChar("ABOVE_FLAG", 'N');
                            else
                                item_list.SetChar("ABOVE_FLAG", (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, BARCODE_ABOVE_COL)) == true) ? 'Y' : 'N');

                            if (spdDesign.Sheets[0].GetValue(i, BARCODE_BELOW_COL) == null)
                                item_list.SetChar("BELOW_FLAG", 'N');
                            else
                                item_list.SetChar("BELOW_FLAG", (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, BARCODE_BELOW_COL)) == true) ? 'Y' : 'N');

                            if (spdDesign.Sheets[0].GetValue(i, BARCODE_CHECK_COL) == null)
                                item_list.SetChar("CHECK_DIGIT", 'N');
                            else
                                item_list.SetChar("CHECK_DIGIT", (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, BARCODE_CHECK_COL)) == true) ? 'Y' : 'N');
                            
                            if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL), 0, 1) == "7")
                            {
                                item_list.SetChar("ECC_LEVEL", MPCF.ToChar(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ECC_LEVEL_COL))));
                                item_list.SetInt("COLUMN_COUNT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)));
                                item_list.SetInt("HEIGHT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, ELEMENT_HEIGHT_COL)));
                                item_list.SetInt("ROW_COUNT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, ROW_COUNT_COL)));

                                if (spdDesign.Sheets[0].GetValue(i, TRUN_FLAG_COL) == null)
                                    item_list.SetChar("TRUN_FLAG", 'N');
                                else
                                    item_list.SetChar("TRUN_FLAG", (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, TRUN_FLAG_COL)) == true) ? 'Y' : 'N');
                            }

                            if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL), 0, 1) == "X")
                            {
                                item_list.SetInt("MAGNI_FACTOR", MPCF.ToInt(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ECC_LEVEL_COL))));
                                item_list.SetInt("COLUMN_COUNT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)));
                                item_list.SetInt("HEIGHT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, ELEMENT_HEIGHT_COL)));
                                item_list.SetInt("ROW_COUNT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, ROW_COUNT_COL)));
                                item_list.SetChar("MODEL", MPCF.ToChar(spdDesign.Sheets[0].GetValue(i, FORMAT_ID_COL)));                                 
                            }

                            //Added by patrick for tpcl
                            item_list.SetString("NAR_BAR_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_NAR_BAR_WIDTH_COL));
                            item_list.SetString("NAR_SPACE_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_NAR_SPACE_WIDTH_COL));
                            item_list.SetString("WID_BAR_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_WID_BAR_WIDTH_COL));
                            item_list.SetString("WID_SPACE_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_WID_SPACE_WIDTH_COL));
                            item_list.SetString("CHAR_SPACE_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_C_C_SPACE_COL));
                            item_list.SetString("1_CELL_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_1_CELL_WIDTH_COL));
                        }
                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_IMAGE)
                        {
                            item_list.SetInt("WIDTH", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_X_COL)));
                            item_list.SetInt("HEIGHT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_Y_COL)));

                            if (spdDesign.Sheets[0].GetValue(i, BACKGROUND_COL) == null)
                                item_list.SetChar("BACKGROUND_FLAG", 'N');
                            else
                                item_list.SetChar("BACKGROUND_FLAG", (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, BACKGROUND_COL)) == true) ? 'Y' : 'N');
                        }
                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_GRAPHIC)
                        {
                            item_list.SetInt("WIDTH", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, GRAPHIC_WIDTH_COL)));
                            item_list.SetInt("HEIGHT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, GRAPHIC_HEIGHT_COL)));
                            item_list.SetInt("THICK", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, GRAPHIC_THICK_COL)));
                        }

                        if (spdDesign.Sheets[0].GetValue(i, FEED_COL) == null)
                            item_list.SetChar("FEED_FLAG", 'N');
                        else
                            item_list.SetChar("FEED_FLAG", (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, FEED_COL)) == true) ? 'Y' : 'N');
                        
                        if (spdDesign.Sheets[0].GetValue(i, NOT_PRINT_COL) == null)
                            item_list.SetChar("PRINT_FLAG", 'Y');
                        else
                            item_list.SetChar("PRINT_FLAG", (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, NOT_PRINT_COL)) == false) ? 'Y' : 'N');

                        item_list.SetString("ARG_SQL" , MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ARGUMENT_SQL_COL)));

                        //item_list.SetString("LABEL_CMD", PrintDataArray[i].Trim());
                        iIndex++;
                    }
                }

                out_node.AddString("START_CMD", PrintDataArray[0].Trim());
                out_node.AddString("END_CMD", PrintDataArray[PrintDataArray.Length - 1].Trim());

                in_node.AddString("START_CMD", PrintDataArray[0].Trim());
                in_node.AddString("END_CMD", PrintDataArray[PrintDataArray.Length - 1].Trim());

                if (MPCR.CallService("POP", "POP_Update_Label_Design", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        private bool PreviewCommand()
        {
            
            int i = 0;
            int iIndex = 0;
            TRSNode design_info = new TRSNode("View_Label_Design_Out");
            TRSNode item_list;

            try
            {
                
                if (spdDesign.Sheets[0].RowCount <= 0)
                {
                    return true;
                }
                
                txtCommand.Text = "";

                //View_Label_Design_Out.origin_x = dOriginX;
                //View_Label_Design_Out.origin_y = dOriginY;
                design_info.SetDouble("ORIGIN_X", dOriginX);
                design_info.SetDouble("ORIGIN_Y", dOriginY);

                //View_Label_Design_Out.invert = sInvert;
                //View_Label_Design_Out.reverse = sReverse;
                //View_Label_Design_Out.print_speed = sPrintSpeed;
                design_info.SetChar("INVERT", sInvert);
                design_info.SetChar("REVERSE", sReverse);
                design_info.SetChar("PRINT_SPEED", sPrintSpeed);

                //View_Label_Design_Out.darkness = (int)dDarkness;
                //View_Label_Design_Out.print_qty = (int)dPrintQty;
                design_info.SetInt("DARKNESS", (int)dDarkness);
                design_info.SetInt("PRINT_QTY", (int)dPrintQty);

                //View_Label_Design_Out.label_width = dLabelWidth;
                //View_Label_Design_Out.label_height = dLabelHeight;
                design_info.SetDouble("PAGE_WIDTH", dPageWidth);
                design_info.SetDouble("PAGE_HEIGHT", dPageHeight);
                design_info.SetDouble("LABEL_WIDTH", dLabelWidth);
                design_info.SetDouble("LABEL_HEIGHT", dLabelHeight);

                //View_Label_Design_Out.label_type = sLabelType;
                //View_Label_Design_Out.resolution = Convert.ToString(dResolution);
                design_info.SetChar("LABEL_TYPE", sLabelType);
                design_info.SetString("RESOLUTION", Convert.ToString(dResolution));
                design_info.SetString("PRINTER_TYPE", sPrinterType);

                design_info.SetString("FEED_POSITION", sFeedPosition);
                design_info.SetString("CUT_POSITION", sCutPosition);
                design_info.SetString("BACK_FEED_LENGTH", sBackPosition);
                design_info.SetString("PRINTER_MODE", sPrinterMode);
                design_info.SetString("TAG_MODE_FLAG", sTagMode);
                design_info.SetString("CUT_INTERVAL", sCutInterval);
                design_info.SetString("SENSOR_TYPE", sSensorType);
                design_info.SetString("ISSUE_MODE", sIssueMode);
                design_info.SetString("TAG_ROTATION", sTagRotation);
                design_info.SetString("RIBON_OPTION", sRibonOption);

                iIndex = 0;
                for (i = 0; i < spdDesign.Sheets[0].RowCount; i++)
                {
                    item_list = design_info.AddNode("ITEM_LIST");

                    if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) != "" && (MPCF.Trim(spdDesign.Sheets[0].Cells[i, POSITION_X_COL].Text) != "" && MPCF.Trim(spdDesign.Sheets[0].Cells[i, POSITION_Y_COL].Text) != ""))
                    {

                        item_list.SetInt("SEQ_NUM", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, SEQ_COL)));
                        item_list.SetString("TYPE", MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1));
                        item_list.SetInt("POSITION_X" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, POSITION_X_COL)));
                        item_list.SetInt("POSITION_Y" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, POSITION_Y_COL)));

                        if (spdDesign.Sheets[0].GetValue(i, VARIABLE_COL) == null)
                            item_list.SetChar("VARIABLE_FLAG" , 'N');
                        else
                            item_list.SetChar("VARIABLE_FLAG" , (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, VARIABLE_COL)) == true) ? 'Y' : 'N');

                        item_list.SetString("DATA" , MPCF.Trim(spdDesign.Sheets[0].GetValue(i, DATA_COL)));
                        if (MPCF.Trim(spdDesign.Sheets[0].GetValue(i, VARIABLE_COL)) == "Y")
                        {
                            item_list.SetString("DATA", MPCF.ToUpper(item_list.GetString("DATA")));
                        }
                        item_list.SetChar("ROTATE" , MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROTATE_COL)) != "" ? MPCF.ToChar(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ROTATE_COL))) : 'N');

                        if (spdDesign.Sheets[0].GetValue(i, REVERSE_COL) == null)
                            item_list.SetChar("REVERSE_FLAG" , 'N');
                        else
                            item_list.SetChar("REVERSE_FLAG" , (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, REVERSE_COL)) == true) ? 'Y' : 'N');

                        if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_TEXT)
                        {
                            item_list.SetChar("FONT" , MPCF.ToChar(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, TEXT_FONT_COL))));
                            item_list.SetInt("WIDTH" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, TEXT_WIDTH_COL)));
                            item_list.SetInt("HEIGHT" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, TEXT_HEIGHT_COL)));
                        }
                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_BARCODE)
                        {
                            item_list.SetChar("FONT" , MPCF.ToChar(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL))));
                            item_list.SetInt("WIDTH" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, BARCODE_WIDTH_COL)));
                            item_list.SetInt("HEIGHT" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, BARCODE_HEIGHT_COL)));
                            item_list.SetInt("BAR_RATE" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, BARCODE_RATE_COL)));

                            if (spdDesign.Sheets[0].GetValue(i, BARCODE_ABOVE_COL) == null)
                                item_list.SetChar("ABOVE_FLAG" , 'N');
                            else
                                item_list.SetChar("ABOVE_FLAG" , (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, BARCODE_ABOVE_COL)) == true) ? 'Y' : 'N');

                            if (spdDesign.Sheets[0].GetValue(i, BARCODE_BELOW_COL) == null)
                                item_list.SetChar("BELOW_FLAG" , 'N');
                            else
                                item_list.SetChar("BELOW_FLAG" , (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, BARCODE_BELOW_COL)) == true) ? 'Y' : 'N');

                            if (spdDesign.Sheets[0].GetValue(i, BARCODE_CHECK_COL) == null)
                                item_list.SetChar("CHECK_DIGIT" , 'N');
                            else
                                item_list.SetChar("CHECK_DIGIT" , (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, BARCODE_CHECK_COL)) == true) ? 'Y' : 'N');


                            if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL), 0, 1) == "7")
                            {
                                item_list.SetInt("HEIGHT" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, ELEMENT_HEIGHT_COL)));
                                item_list.SetChar("ECC_LEVEL" , MPCF.ToChar(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ECC_LEVEL_COL))));
                                item_list.SetInt("COLUMN_COUNT" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)));
                                item_list.SetInt("ROW_COUNT" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, ROW_COUNT_COL)));

                                if (spdDesign.Sheets[0].GetValue(i, TRUN_FLAG_COL) == null)
                                    item_list.SetChar("TRUN_FLAG" , 'N');
                                else
                                    item_list.SetChar("TRUN_FLAG" , (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, TRUN_FLAG_COL)) == true) ? 'Y' : 'N');
                            }

                            if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, BARCODE_FONT_COL), 0, 1) == "X")
                            {
                                item_list.SetInt("HEIGHT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, ELEMENT_HEIGHT_COL)));
                                item_list.SetInt("MAGNI_FACTOR", MPCF.ToInt(MPCF.Trim(spdDesign.Sheets[0].GetValue(i, ECC_LEVEL_COL))));
                                item_list.SetInt("COLUMN_COUNT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, COL_COUNT_COL)));
                                item_list.SetInt("ROW_COUNT", MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, ROW_COUNT_COL)));
                                item_list.SetChar("MODEL", MPCF.ToChar(spdDesign.Sheets[0].GetValue(i, FORMAT_ID_COL)));
                                 
                            }

                            //Added by patrico for tpcl
                            item_list.SetString("NAR_BAR_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_NAR_BAR_WIDTH_COL));
                            item_list.SetString("NAR_SPACE_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_NAR_SPACE_WIDTH_COL));
                            item_list.SetString("WID_BAR_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_WID_BAR_WIDTH_COL));
                            item_list.SetString("WID_SPACE_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_WID_SPACE_WIDTH_COL));
                            item_list.SetString("CHAR_SPACE_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_C_C_SPACE_COL));
                            item_list.SetString("1_CELL_WIDTH", spdDesign.Sheets[0].GetValue(i, BARCODE_1_CELL_WIDTH_COL));
                        }
                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_IMAGE)
                        {
                            item_list.SetInt("WIDTH" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_X_COL)));
                            item_list.SetInt("HEIGHT" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, IMAGE_SCALE_Y_COL)));

                            if (spdDesign.Sheets[0].GetValue(i, BACKGROUND_COL) == null)
                                item_list.SetChar("BACKGROUND_FLAG" , 'N');
                            else
                                item_list.SetChar("BACKGROUND_FLAG" , (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, BACKGROUND_COL)) == true) ? 'Y' : 'N');
                        }
                        else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_GRAPHIC)
                        {
                            item_list.SetInt("WIDTH" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, GRAPHIC_WIDTH_COL)));
                            item_list.SetInt("HEIGHT" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, GRAPHIC_HEIGHT_COL)));
                            item_list.SetInt("THICK" , MPCF.ToInt(spdDesign.Sheets[0].GetValue(i, GRAPHIC_THICK_COL)));
                        }

                        if (spdDesign.Sheets[0].GetValue(i, FEED_COL) == null)
                            item_list.SetChar("FEED_FLAG" , 'N');
                        else
                            item_list.SetChar("FEED_FLAG" , (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, FEED_COL)) == true) ? 'Y' : 'N');

                        if (spdDesign.Sheets[0].GetValue(i, NOT_PRINT_COL) == null)
                            item_list.SetChar("PRINT_FLAG" , 'Y');
                        else
                            item_list.SetChar("PRINT_FLAG" , (Convert.ToBoolean(spdDesign.Sheets[0].GetValue(i, NOT_PRINT_COL)) == false) ? 'Y' : 'N');
                        
                        iIndex++;
                    }
                }
                
                if (iIndex <= 0)
                {
                    return true;
                }

                //Added by patrick to tpcl(toshiba print command type)
                //In case of toshiba tpcl, else convert zebra code
                if (sPrinterType.Equals(modPOPPrint.POP_PRINT_TYPE_TPCL))
                {
                    if (modPOPPrint.MakeToshibaCommand(cboPort.Text, m_CommPort, ref design_info, out PrintDataArray, true) == false)
                    {

                        return false;
                    }
                }
                else
                {
                    if (modPOPPrint.MakeZebraCommand(cboPort.Text, m_CommPort, ref design_info, out PrintDataArray, true) == false)
                    {

                        return false;
                    }
                }
                
                for (i = 0; i < PrintDataArray.Length; i++)
                {
                    txtCommand.Text = txtCommand.Text + PrintDataArray[i].Trim() + "\r\n";
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void SetRowType(int i_row)
        {
            int i;

            for (i = 0; i < spdDesign.Sheets[0].ColumnCount; i++)
            {
                spdDesign.Sheets[0].Cells[i_row, i].Locked = false;
                spdDesign.Sheets[0].Cells[i_row, i].BackColor = System.Drawing.Color.White;
            }

            if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i_row, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_TEXT)
            {

                for (i = BARCODE_FONT_COL; i <= GRAPHIC_THICK_COL; i++)
                {
                    spdDesign.Sheets[0].Cells[i_row, i].Locked = true;
                    spdDesign.Sheets[0].Cells[i_row, i].BackColor = System.Drawing.Color.LightGray;
                }

            }
            else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i_row, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_BARCODE)
            {

                for (i = TEXT_FONT_COL; i <= TEXT_HEIGHT_COL; i++)
                {
                    spdDesign.Sheets[0].Cells[i_row, i].Locked = true;
                    spdDesign.Sheets[0].Cells[i_row, i].BackColor = System.Drawing.Color.LightGray;
                }

                for (i = BACKGROUND_COL; i <= GRAPHIC_THICK_COL; i++)
                {
                    spdDesign.Sheets[0].Cells[i_row, i].Locked = true;
                    spdDesign.Sheets[0].Cells[i_row, i].BackColor = System.Drawing.Color.LightGray;
                }

            }
            else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i_row, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_IMAGE)
            {

                for (i = ROTATE_COL; i <= ROTATE_COL; i++)
                {
                    spdDesign.Sheets[0].Cells[i_row, i].Locked = true;
                    spdDesign.Sheets[0].Cells[i_row, i].BackColor = System.Drawing.Color.LightGray;
                }

                for (i = TEXT_FONT_COL; i <= FEED_COL; i++)
                {
                    spdDesign.Sheets[0].Cells[i_row, i].Locked = true;
                    spdDesign.Sheets[0].Cells[i_row, i].BackColor = System.Drawing.Color.LightGray;
                }

                for (i = GRAPHIC_WIDTH_COL; i <= GRAPHIC_THICK_COL; i++)
                {
                    spdDesign.Sheets[0].Cells[i_row, i].Locked = true;
                    spdDesign.Sheets[0].Cells[i_row, i].BackColor = System.Drawing.Color.LightGray;
                }

            }
            else if (MPCF.Mid(spdDesign.Sheets[0].GetValue(i_row, OBJECT_TYPE_COL), 0, 1) == MPGC.POP_TYPE_GRAPHIC)
            {

                for (i = TEXT_FONT_COL; i <= IMAGE_SCALE_Y_COL; i++)
                {
                    spdDesign.Sheets[0].Cells[i_row, i].Locked = true;
                    spdDesign.Sheets[0].Cells[i_row, i].BackColor = System.Drawing.Color.LightGray;
                }

                for (i = VARIABLE_COL; i <= REVERSE_COL; i++)
                {
                    spdDesign.Sheets[0].Cells[i_row, i].Locked = true;
                    spdDesign.Sheets[0].Cells[i_row, i].BackColor = System.Drawing.Color.LightGray;
                }
            }
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvLabel;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmPOPSetupLabelDesign_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                ClearData('1');

                chkDefaultPrinter.Enabled = false;
                
                sngRatio = (float)nudRatio.Value / 100;

                if (MPCR.CheckSecurityFormControl(this, ref this.DisabledFormControls) == false)
                {
                    return;
                }

                b_load_flag = true;
                
            }
        }
        
        private void cdvLabel_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvLabel.Init();
            MPCF.InitListView(cdvLabel.GetListView);
            cdvLabel.Columns.Add("Label", 100, HorizontalAlignment.Left);
            cdvLabel.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvLabel.SelectedSubItemIndex = 0;
            cdvLabel.DisplaySubItemIndex = 0;
            POPLIST.ViewLabelList(cdvLabel.GetListView, '1', "", 0, "", null, "");
        }
        
        private void cdvLabel_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }
        
        private void cdvLabel_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (cdvLabel.Text.Trim() != "")
                    {
                        ClearData('2');
                        View_Label_Design();                        

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdDesign_CellClick(System.Object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            
            try
            {
                if (spdDesign.Sheets[0].Columns[OBJECT_TYPE_COL].Visible == false)
                {
                    return;
                }
                if (spdDesign.Sheets[0].RowCount == 0)
                {
                    spdDesign.Sheets[0].RowCount++;
                    return;
                }
                if (spdDesign.Sheets[0].ActiveRow == null)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdDesign_EnterCell(System.Object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            int LastSeq = 0;
            try
            {
                if (cdvLabel.Text.Trim() == "")
                {
                    return;
                }
                if (spdDesign.Sheets[0].Columns[OBJECT_TYPE_COL].Visible == false)
                {
                    return;
                }
                if (e.Row == spdDesign.Sheets[0].RowCount - 1)
                {
                    if (e.Column > 0)
                    {
                        if (MPCF.Trim(spdDesign.Sheets[0].Cells[e.Row, OBJECT_TYPE_COL].Text) != "")
                        {
                            LastSeq = MPCF.ToInt(spdDesign.Sheets[0].GetValue(spdDesign.Sheets[0].RowCount - 1, SEQ_COL));
                            spdDesign.Sheets[0].RowCount++;
                            spdDesign.Sheets[0].SetValue(spdDesign.Sheets[0].RowCount - 1, SEQ_COL, LastSeq + 1);
                            int i = 0;
                            for (i = 1; i <= GRAPHIC_THICK_COL; i++)
                            {
                                spdDesign.Sheets[0].Cells.Get(spdDesign.Sheets[0].RowCount - 1, i).BackColor = System.Drawing.Color.WhiteSmoke;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void spdDesign_ComboCloseUp(object sender, EditorNotifyEventArgs e)
        {
            //SetRowType(e.Row);
        }

        private void spdDesign_ComboSelChange(object sender, EditorNotifyEventArgs e)
        {
            //SetRowType(e.Row);
        }

        private void spdDesign_Change(System.Object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            try
            {
                if (e.Column <= 0) return;

                if (e.Column > 1 && e.Row >= 0)
                {
                    spdDesign.Sheets[0].SetValue(e.Row, CHECK_COL, true);
                }

                if (e.Column == 2 && e.Row >= 0)
                {
                    SetRowType(e.Row);
                }

                if (e.Column == BACKGROUND_COL)
                {
                    spdDesign.Sheets[0].SetValue(e.Row, NOT_PRINT_COL, spdDesign.Sheets[0].GetValue(e.Row, BACKGROUND_COL));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdDesign_ButtonClicked(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == TEXT_FONT_COL + 1)
                {
                    cdvTextFont.Init();
                    MPCF.InitListView(cdvTextFont.GetListView);
                    cdvTextFont.Columns.Add("Font", 50, HorizontalAlignment.Left);
                    cdvTextFont.Columns.Add("Font Desc", 50, HorizontalAlignment.Left);
                    cdvTextFont.Columns.Add("Width", 50, HorizontalAlignment.Right);
                    cdvTextFont.Columns.Add("Height", 50, HorizontalAlignment.Right);
                    BASLIST.ViewGCMDataList(cdvTextFont.GetListView, '1', MPGC.MP_POP_TEXT_FONT);
                    if (cdvTextFont.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
                else if (e.Column == BARCODE_FONT_COL + 1)
                {
                    cdvBarcodeFont.Init();
                    MPCF.InitListView(cdvBarcodeFont.GetListView);
                    cdvBarcodeFont.Columns.Add("Font", 50, HorizontalAlignment.Left);
                    cdvBarcodeFont.Columns.Add("Font Desc", 50, HorizontalAlignment.Left);
                    BASLIST.ViewGCMDataList(cdvBarcodeFont.GetListView, '1', MPGC.MP_POP_BARCODE_FONT);
                    if (cdvBarcodeFont.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
                else if (e.Column == ROTATE_COL + 1)
                {
                    cdvRotate.Init();
                    MPCF.InitListView(cdvRotate.GetListView);
                    cdvRotate.Columns.Add("Rotate", 50, HorizontalAlignment.Left);
                    cdvRotate.Columns.Add("Rotate Desc", 50, HorizontalAlignment.Left);
                    BASLIST.ViewGCMDataList(cdvRotate.GetListView, '1', MPGC.MP_POP_ROTATE);
                    if (cdvRotate.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
                else if (e.Column == DATA_COL + 1)
                {
                    
                    string sValue;
                    
                    //spdDesign.Sheets(0).Cells(e.Row, e.Column).Locked = False
                    
                    cdvData.Init();
                    MPCF.InitListView(cdvData.GetListView);
                    
                    sValue = MPCF.Trim(spdDesign.Sheets[0].GetValue(e.Row, VARIABLE_COL));
                    if (sValue != null)
                    {
                        if (sValue.ToUpper() == "TRUE")
                        {

                            sValue = MPCF.Trim(spdDesign.Sheets[0].GetValue(e.Row, OBJECT_TYPE_COL));
                            if (sValue != null)
                            {
                                if (sValue.Substring(0, 1) == MPGC.POP_TYPE_TEXT || sValue.Substring(0, 1) == MPGC.POP_TYPE_BARCODE)
                                {
                                    cdvData.Columns.Add("Data", 50, HorizontalAlignment.Left);
                                    cdvData.Columns.Add("Data Desc", 50, HorizontalAlignment.Left);
                                    BASLIST.ViewGCMDataList(cdvData.GetListView, '1', MPGC.MP_POP_PRINT_VARIABLE);
                                }
                            }
                            
                        }
                        else if (sValue.ToUpper() == "FALSE")
                        {
                            
                            //sValue = CStr(spdDesign.Sheets(0).GetValue(e.Row, OBJECT_TYPE_COL))
                            //If sValue <> Nothing Then
                            //    If sValue.ToUpper = "TEXT" Or sValue.ToUpper = "BARCODE" Then
                            //        spdDesign.Sheets(0).Cells(e.Row, e.Column).Locked = True
                            //    End If
                            //End If
                            
                        }
                    }
                    
                    sValue = MPCF.Trim(spdDesign.Sheets[0].GetValue(e.Row, OBJECT_TYPE_COL));
                    if (sValue != null)
                    {
                        if (sValue.Substring(0, 1) == MPGC.POP_TYPE_IMAGE)
                        {
                            cdvData.Columns.Add("Image", 50, HorizontalAlignment.Left);
                            cdvData.Columns.Add("Image Desc", 50, HorizontalAlignment.Left);
                            POPLIST.ViewImageList(cdvData.GetListView, '1', null, "", -1, -1);
                        }
                    }
                    
                    if (cdvData.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvTextFont_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            spdDesign.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            spdDesign.Sheets[0].Cells[e.Row, e.Col + 1].Value = e.SelectedItem.SubItems[3].Text;
            spdDesign.Sheets[0].Cells[e.Row, e.Col + 2].Value = e.SelectedItem.SubItems[2].Text;
            
        }
        
        private void cdvBarcodeFont_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            spdDesign.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;

            if (MPCF.Trim(spdDesign.Sheets[0].Cells[e.Row, e.Col + 1].Value) == "")
            {
                spdDesign.Sheets[0].Cells[e.Row, e.Col + 1].Value = 2;
            }
            if (MPCF.Trim(spdDesign.Sheets[0].Cells[e.Row, e.Col + 2].Value) == "")
            {
                spdDesign.Sheets[0].Cells[e.Row, e.Col + 2].Value = 10;
            }
            if (MPCF.Trim(spdDesign.Sheets[0].Cells[e.Row, e.Col + 3].Value) == "")
            {
                spdDesign.Sheets[0].Cells[e.Row, e.Col + 3].Value = 3;
            }
            
        }
        
        private void cdvRotate_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            spdDesign.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Label_Design", MPGC.MP_STEP_CREATE) == true)
                {
                    PreviewCommand();

                    if (Update_Label_Design(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    ClearData('2');
                    View_Label_Design();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                
                if (CheckCondition("Update_Label_Design", MPGC.MP_STEP_DELETE) == true)
                {
                    PreviewCommand();

                    if (Update_Label_Design(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    ClearData('2');
                    View_Label_Design();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        
        private void btnPrint_Click(System.Object sender, System.EventArgs e)
        {
            TRSNode out_node = new TRSNode("View_Label_Design_Out");
            
            try
            {
                if (MPCF.CheckValue(cboPort, 1) == false)
                {
                    return;
                }
                
                if (spdDesign.Sheets[0].RowCount <= 0)
                {
                    return;
                }
                /* Winspool.drv Win32 API를 이용하여, LPT나 COM등의 '포트'가 아닌, 특정 Printer Name에 ZPL Command raw data를 직접 전달 하는 방식 추가 */
                if (MPCF.Mid(cboPort.Text, 0, 3) == modPOPPrint.POP_PRINT_PORT_SPOOL)
                {
                    if (chkDefaultPrinter.Checked == true)
                    {
                        /* Zebra Printer 가 기본 프린터로 설정된 경우, 해당 프린터 Name을 가져옴 */
                        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                        modPOPPrint.sPrinterName = pd.PrinterSettings.PrinterName;
                    }
                    else
                    {
                        // Allow the user to select a printer.
                        /* 기본 프린터로 설정되어 있지 않은 경우, Printer 선택 창을 띄어 사용자가 선택 하게 함. */
                        PrintDialog pd = new PrintDialog();
                        pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                        if (DialogResult.OK == pd.ShowDialog(this))
                        {
                            modPOPPrint.sPrinterName = pd.PrinterSettings.PrinterName;
                        }
                    }
                }

                if (modPOPPrint.GetPrintInformation(cdvLabel.Text, " ", ref out_node) == false)
                {
                    return;
                }

                if (chkRPrint.Checked == false)
                {
                    if (out_node.GetString("PRINTER_TYPE").Equals(modPOPPrint.POP_PRINT_TYPE_TPCL))
                    {
                        if (modPOPPrint.ExcutePrint(cboPort.Text, m_CommPort, ref out_node, modPOPPrint.POP_PRINT_TYPE_TPCL) == false)
                            return;                    
                    }
                    else
                    {
                        if (modPOPPrint.ExcutePrint(cboPort.Text, m_CommPort, ref out_node) == false)
                            return;                    
                    }                    
                }
                else
                {
                    PreviewCommand();

                    if (modPOPPrint.ExcutePrintCommand(cboPort.Text, m_CommPort, txtCommand.Text, chkRPrint.Checked, sPrintIP, sUser, sPassword) == false)
                    {
                        return;
                    }
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            //m_CommPort.Write("^XA^FO 80,80^AE 21,10^FD ZEBRA^FS^XZ")
        }
        
        private void tabDesign_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                
                if (tabDesign.SelectedTab == tbpDesignItem)
                {
                    MPCR.CheckSecurityFormControlSub(btnCreate, this.DisabledFormControls, true);
                    MPCR.CheckSecurityFormControlSub(btnUpdate, this.DisabledFormControls, true);
                    MPCR.CheckSecurityFormControlSub(btnDelete, this.DisabledFormControls, true);
                }
                else if (tabDesign.SelectedTab == tbpImage)
                {
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    
                    PreviewImage();
                }
                else
                {
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    
                    PreviewCommand();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            if (cdvLabel.Text.Trim() != "")
            {
                ClearData('2');
                View_Label_Design();
                
                if (tabDesign.SelectedTab == tbpImage)
                {
                    PreviewImage();
                }
                else if (tabDesign.SelectedTab == tbpCommand)
                {
                    PreviewCommand();
                }
            }
        }
        
        private void chkPreView_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            btnRefresh.PerformClick();
        }
        
        private void nudRatio_ValueChanged(System.Object sender, System.EventArgs e)
        {
            
            sngRatio = (float)nudRatio.Value / 100;
            
            PreviewImage();
            
        }

        private void chkRPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRPrint.Checked == true)
            {
                cboPort.Items.Clear();

                if (BASLIST.ViewGCMDataList(cboPort, '1', "LABEL_PRINTER") == false)
                {
                    return;
                }
            }
            else
            {
                cboPort.Items.Clear();

                cboPort.Items.Add("SPOOL");
                cboPort.Items.Add("LPT1");
                cboPort.Items.Add("LPT2");
                cboPort.Items.Add("COM1");
                cboPort.Items.Add("COM2");
                cboPort.Items.Add("COM3");
                cboPort.Items.Add("COM4");
                cboPort.Items.Add("COM5");
                cboPort.Items.Add("COM6");
                cboPort.Items.Add("COM7");
                cboPort.Items.Add("COM8");
            }
        }

        private void cboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkRPrint.Checked == true && cboPort.Text.Trim() != "")
            {
                try
                {
                    TRSNode in_node = new TRSNode("View_Data_In");
                    TRSNode out_node = new TRSNode("View_Data_Out");

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("TABLE_NAME", "LABEL_PRINTER");
                    in_node.AddString("KEY_1", cboPort.Text);

                    if (MPCR.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    sPrintIP = MPCF.Trim(out_node.GetString("DATA_2"));
                    sUser = MPCF.Trim(out_node.GetString("DATA_3"));
                    sPassword = MPCF.Trim(out_node.GetString("DATA_4"));
                    
                    return;
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox("frmPOPSetupLabelDesign.View_Data()\n" + ex.Message);
                    return;
                }
            }

            if (MPCF.Mid(cboPort.Text, 0, 3) == modPOPPrint.POP_PRINT_PORT_SPOOL)
            {
                chkDefaultPrinter.Enabled = true;
            }
            else
            {
                chkDefaultPrinter.Enabled = false;
            }
        }


    }
    //#End If
}
