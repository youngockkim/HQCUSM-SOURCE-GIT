
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;

//#If _EDC = True Then


namespace Miracom.EDCCore
{
    public class frmEDCDeleteResourceDataHistory : Miracom.MESCore.TranForm01
    {
        
#region " Windows Form auto generated code "
        
        public frmEDCDeleteResourceDataHistory()
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
        



        private System.Windows.Forms.Panel pnlMidTop;
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.GroupBox grpTop;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEventID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        protected System.Windows.Forms.Panel pnlTranBottom;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Panel pnlResourceData;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.FpSpread spdResHistory;
        private FarPoint.Win.Spread.SheetView spdResHistory_Sheet1;
        private Splitter splitter1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResID;
        private Label lblSubResource;
        private Button btnView;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlMidTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.cdvSubResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubResource = new System.Windows.Forms.Label();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.pnlResourceData = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.spdResHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdResHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlTranBottom = new System.Windows.Forms.Panel();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMidTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlMid.SuspendLayout();
            this.pnlResourceData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResHistory_Sheet1)).BeginInit();
            this.pnlTranBottom.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMid);
            this.pnlCenter.Controls.Add(this.pnlMidTop);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Delete Resource Data History";
            // 
            // pnlMidTop
            // 
            this.pnlMidTop.Controls.Add(this.grpTop);
            this.pnlMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidTop.Location = new System.Drawing.Point(3, 0);
            this.pnlMidTop.Name = "pnlMidTop";
            this.pnlMidTop.Size = new System.Drawing.Size(736, 95);
            this.pnlMidTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.cdvSubResID);
            this.grpTop.Controls.Add(this.lblSubResource);
            this.grpTop.Controls.Add(this.pnlPeriod);
            this.grpTop.Controls.Add(this.cdvEventID);
            this.grpTop.Controls.Add(this.cdvResID);
            this.grpTop.Controls.Add(this.lblEvent);
            this.grpTop.Controls.Add(this.lblResID);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(0, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(736, 95);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // cdvSubResID
            // 
            this.cdvSubResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResID.BtnToolTipText = "";
            this.cdvSubResID.ButtonWidth = 20;
            this.cdvSubResID.DescText = "";
            this.cdvSubResID.DisplaySubItemIndex = -1;
            this.cdvSubResID.DisplayText = "";
            this.cdvSubResID.Focusing = null;
            this.cdvSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResID.Index = 0;
            this.cdvSubResID.IsViewBtnImage = false;
            this.cdvSubResID.Location = new System.Drawing.Point(120, 40);
            this.cdvSubResID.MaxLength = 20;
            this.cdvSubResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.MultiSelect = false;
            this.cdvSubResID.Name = "cdvSubResID";
            this.cdvSubResID.ReadOnly = false;
            this.cdvSubResID.SameWidthHeightOfButton = false;
            this.cdvSubResID.SearchSubItemIndex = 0;
            this.cdvSubResID.SelectedDescIndex = -1;
            this.cdvSubResID.SelectedDescToQueryText = "";
            this.cdvSubResID.SelectedSubItemIndex = -1;
            this.cdvSubResID.SelectedValueToQueryText = "";
            this.cdvSubResID.SelectionStart = 0;
            this.cdvSubResID.Size = new System.Drawing.Size(200, 20);
            this.cdvSubResID.SmallImageList = null;
            this.cdvSubResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResID.TabIndex = 3;
            this.cdvSubResID.TextBoxToolTipText = "";
            this.cdvSubResID.TextBoxWidth = 200;
            this.cdvSubResID.VisibleButton = true;
            this.cdvSubResID.VisibleColumnHeader = false;
            this.cdvSubResID.VisibleDescription = false;
            this.cdvSubResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSubResource_SelectedItemChanged);
            this.cdvSubResID.ButtonPress += new System.EventHandler(this.cdvSubResource_ButtonPress);
            this.cdvSubResID.TextBoxTextChanged += new System.EventHandler(this.cdvSubResource_TextBoxTextChanged);
            // 
            // lblSubResource
            // 
            this.lblSubResource.AutoSize = true;
            this.lblSubResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubResource.Location = new System.Drawing.Point(15, 42);
            this.lblSubResource.Name = "lblSubResource";
            this.lblSubResource.Size = new System.Drawing.Size(89, 13);
            this.lblSubResource.TabIndex = 2;
            this.lblSubResource.Text = "Sub Resource ID";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(467, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(167, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // cdvEventID
            // 
            this.cdvEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEventID.BtnToolTipText = "";
            this.cdvEventID.ButtonWidth = 20;
            this.cdvEventID.DescText = "";
            this.cdvEventID.DisplaySubItemIndex = -1;
            this.cdvEventID.DisplayText = "";
            this.cdvEventID.Focusing = null;
            this.cdvEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEventID.Index = 0;
            this.cdvEventID.IsViewBtnImage = false;
            this.cdvEventID.Location = new System.Drawing.Point(120, 63);
            this.cdvEventID.MaxLength = 12;
            this.cdvEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MultiSelect = false;
            this.cdvEventID.Name = "cdvEventID";
            this.cdvEventID.ReadOnly = false;
            this.cdvEventID.SameWidthHeightOfButton = false;
            this.cdvEventID.SearchSubItemIndex = 0;
            this.cdvEventID.SelectedDescIndex = -1;
            this.cdvEventID.SelectedDescToQueryText = "";
            this.cdvEventID.SelectedSubItemIndex = -1;
            this.cdvEventID.SelectedValueToQueryText = "";
            this.cdvEventID.SelectionStart = 0;
            this.cdvEventID.Size = new System.Drawing.Size(200, 20);
            this.cdvEventID.SmallImageList = null;
            this.cdvEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEventID.TabIndex = 5;
            this.cdvEventID.TextBoxToolTipText = "";
            this.cdvEventID.TextBoxWidth = 200;
            this.cdvEventID.VisibleButton = true;
            this.cdvEventID.VisibleColumnHeader = false;
            this.cdvEventID.VisibleDescription = false;
            this.cdvEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvEventID_SelectedItemChanged);
            this.cdvEventID.ButtonPress += new System.EventHandler(this.cdvEventID_ButtonPress);
            this.cdvEventID.TextBoxTextChanged += new System.EventHandler(this.cdvEventID_TextBoxTextChanged);
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.ButtonWidth = 20;
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(120, 16);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MultiSelect = false;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SameWidthHeightOfButton = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedDescToQueryText = "";
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectedValueToQueryText = "";
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResID_KeyPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(15, 66);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(49, 13);
            this.lblEvent.TabIndex = 4;
            this.lblEvent.Text = "Event ID";
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.pnlResourceData);
            this.pnlMid.Controls.Add(this.pnlTranBottom);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(3, 95);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlMid.Size = new System.Drawing.Size(736, 418);
            this.pnlMid.TabIndex = 1;
            // 
            // pnlResourceData
            // 
            this.pnlResourceData.Controls.Add(this.spdData);
            this.pnlResourceData.Controls.Add(this.splitter1);
            this.pnlResourceData.Controls.Add(this.spdResHistory);
            this.pnlResourceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResourceData.Location = new System.Drawing.Point(0, 3);
            this.pnlResourceData.Name = "pnlResourceData";
            this.pnlResourceData.Size = new System.Drawing.Size(736, 371);
            this.pnlResourceData.TabIndex = 1;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 164);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(736, 207);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 1;
            this.spdData.TabStop = false;
            this.spdData.TabStripRatio = 0.501972386587771D;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 43;
            spdData_Sheet1.ColumnHeader.RowCount = 2;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Factory";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Resource";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Del Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Collection Set ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Version";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Character Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Character";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Character Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Unit Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Value Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Value Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Value Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).ColumnSpan = 25;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 40).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Spec Out Mask";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 41).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Update User ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 42).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Update Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 0).Value = "Factory";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 1).Value = "Resource";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 2).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 3).Value = "Event ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 4).Value = "Tran Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 15).Value = "1";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 16).Value = "2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 17).Value = "3";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 18).Value = "4";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 19).Value = "5";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 20).Value = "6";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 21).Value = "7";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 22).Value = "8";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 23).Value = "9";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 24).Value = "10";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 25).Value = "11";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 26).Value = "12";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 27).Value = "13";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 28).Value = "14";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 29).Value = "15";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 30).Value = "16";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 31).Value = "17";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 32).Value = "18";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 33).Value = "19";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 34).Value = "20";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 35).Value = "21";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 36).Value = "22";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 37).Value = "23";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 38).Value = "24";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 39).Value = "25";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 17F;
            this.spdData_Sheet1.ColumnHeader.Rows.Get(1).Height = 17F;
            this.spdData_Sheet1.Columns.Get(0).Label = "Factory";
            this.spdData_Sheet1.Columns.Get(0).Width = 0F;
            this.spdData_Sheet1.Columns.Get(1).Label = "Resource";
            this.spdData_Sheet1.Columns.Get(1).Width = 0F;
            this.spdData_Sheet1.Columns.Get(2).Label = "Hist Seq";
            this.spdData_Sheet1.Columns.Get(2).Width = 0F;
            this.spdData_Sheet1.Columns.Get(3).Label = "Event ID";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 30F;
            this.spdData_Sheet1.Columns.Get(4).Label = "Tran Time";
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 100F;
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 45F;
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 58F;
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 100F;
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 120F;
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Width = 100F;
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 30F;
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 100F;
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Width = 40F;
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 40F;
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Width = 40F;
            this.spdData_Sheet1.Columns.Get(15).Label = "1";
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Label = "2";
            this.spdData_Sheet1.Columns.Get(16).Locked = true;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).Label = "3";
            this.spdData_Sheet1.Columns.Get(17).Locked = true;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).Label = "4";
            this.spdData_Sheet1.Columns.Get(18).Locked = true;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).Label = "5";
            this.spdData_Sheet1.Columns.Get(19).Locked = true;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).Label = "6";
            this.spdData_Sheet1.Columns.Get(20).Locked = true;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(21).Label = "7";
            this.spdData_Sheet1.Columns.Get(21).Locked = true;
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).Label = "8";
            this.spdData_Sheet1.Columns.Get(22).Locked = true;
            this.spdData_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(23).Label = "9";
            this.spdData_Sheet1.Columns.Get(23).Locked = true;
            this.spdData_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(24).Label = "10";
            this.spdData_Sheet1.Columns.Get(24).Locked = true;
            this.spdData_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(25).Label = "11";
            this.spdData_Sheet1.Columns.Get(25).Locked = true;
            this.spdData_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(26).Label = "12";
            this.spdData_Sheet1.Columns.Get(26).Locked = true;
            this.spdData_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(27).Label = "13";
            this.spdData_Sheet1.Columns.Get(27).Locked = true;
            this.spdData_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(28).Label = "14";
            this.spdData_Sheet1.Columns.Get(28).Locked = true;
            this.spdData_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(29).Label = "15";
            this.spdData_Sheet1.Columns.Get(29).Locked = true;
            this.spdData_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(30).Label = "16";
            this.spdData_Sheet1.Columns.Get(30).Locked = true;
            this.spdData_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(31).Label = "17";
            this.spdData_Sheet1.Columns.Get(31).Locked = true;
            this.spdData_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(32).Label = "18";
            this.spdData_Sheet1.Columns.Get(32).Locked = true;
            this.spdData_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(33).Label = "19";
            this.spdData_Sheet1.Columns.Get(33).Locked = true;
            this.spdData_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(34).Label = "20";
            this.spdData_Sheet1.Columns.Get(34).Locked = true;
            this.spdData_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(35).Label = "21";
            this.spdData_Sheet1.Columns.Get(35).Locked = true;
            this.spdData_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(36).Label = "22";
            this.spdData_Sheet1.Columns.Get(36).Locked = true;
            this.spdData_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(37).Label = "23";
            this.spdData_Sheet1.Columns.Get(37).Locked = true;
            this.spdData_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(38).Label = "24";
            this.spdData_Sheet1.Columns.Get(38).Locked = true;
            this.spdData_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(39).Label = "25";
            this.spdData_Sheet1.Columns.Get(39).Locked = true;
            this.spdData_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(40).Locked = true;
            this.spdData_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(40).Width = 160F;
            this.spdData_Sheet1.Columns.Get(41).Locked = true;
            this.spdData_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(41).Width = 85F;
            this.spdData_Sheet1.Columns.Get(42).Locked = true;
            this.spdData_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(42).Width = 110F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdData_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 160);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(736, 4);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // spdResHistory
            // 
            this.spdResHistory.AccessibleDescription = "spdResHistory, Sheet1";
            this.spdResHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdResHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.spdResHistory.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdResHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResHistory.HorizontalScrollBar.Name = "";
            this.spdResHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdResHistory.HorizontalScrollBar.TabIndex = 4;
            this.spdResHistory.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResHistory.Location = new System.Drawing.Point(0, 0);
            this.spdResHistory.Name = "spdResHistory";
            this.spdResHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdResHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdResHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResHistory_Sheet1});
            this.spdResHistory.Size = new System.Drawing.Size(736, 160);
            this.spdResHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResHistory.TabIndex = 0;
            this.spdResHistory.TabStop = false;
            this.spdResHistory.TextTipDelay = 200;
            this.spdResHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdResHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResHistory.VerticalScrollBar.Name = "";
            this.spdResHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdResHistory.VerticalScrollBar.TabIndex = 5;
            this.spdResHistory.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResHistory.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdResHistory_SelectionChanged);
            this.spdResHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdResHistory.SetActiveViewport(0, -1, -1);
            // 
            // spdResHistory_Sheet1
            // 
            this.spdResHistory_Sheet1.Reset();
            spdResHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdResHistory_Sheet1.ColumnCount = 43;
            spdResHistory_Sheet1.RowCount = 0;
            this.spdResHistory_Sheet1.ActiveColumnIndex = -1;
            this.spdResHistory_Sheet1.ActiveRowIndex = -1;
            this.spdResHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdResHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdResHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdResHistory_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Numbers;
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Event";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Up/Down";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Primary Status";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "New Status 1";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "New Status 2";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "New Status 3";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "New Status 4";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "New Status 5";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "New Status 6";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "New Status 7";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "New Status 8";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "New Status 9";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "New Status 10";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Tran Cmf 1";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Tran Cmf 2";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Tran Cmf 3";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Tran Cmf 4";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Tran Cmf 5";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Tran Cmf 6";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Tran Cmf 7";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Tran Cmf 8";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Tran Cmf 9";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Tran Cmf 10";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Tran Cmf 11";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Tran Cmf 12";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Tran Cmf 13";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Tran Cmf 14";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Tran Cmf 15";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Tran Cmf 16";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Tran Cmf 17";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Tran Cmf 18";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Tran Cmf 19";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Tran Cmf 20";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Process Mode";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Control Mode";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "User Name";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Comment";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Hist Delete Flag";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Hist Delete Time";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Hist Delete User Name";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Hist Delete Comment";
            this.spdResHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdResHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdResHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(0).Width = 30F;
            this.spdResHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdResHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(1).Width = 140F;
            this.spdResHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(2).Label = "Event";
            this.spdResHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(2).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(4).Label = "Primary Status";
            this.spdResHistory_Sheet1.Columns.Get(4).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(5).Label = "New Status 1";
            this.spdResHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(5).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(6).Label = "New Status 2";
            this.spdResHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(6).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(7).Label = "New Status 3";
            this.spdResHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(7).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(8).Label = "New Status 4";
            this.spdResHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(8).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(9).Label = "New Status 5";
            this.spdResHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(9).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(10).Label = "New Status 6";
            this.spdResHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(10).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(11).Label = "New Status 7";
            this.spdResHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(11).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(12).Label = "New Status 8";
            this.spdResHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(12).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(13).Label = "New Status 9";
            this.spdResHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(13).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(14).Label = "New Status 10";
            this.spdResHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(14).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(15).Label = "Tran Cmf 1";
            this.spdResHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(15).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(16).Label = "Tran Cmf 2";
            this.spdResHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(16).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(17).Label = "Tran Cmf 3";
            this.spdResHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(17).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(18).Label = "Tran Cmf 4";
            this.spdResHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(18).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(19).Label = "Tran Cmf 5";
            this.spdResHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(19).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(20).Label = "Tran Cmf 6";
            this.spdResHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(20).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(21).Label = "Tran Cmf 7";
            this.spdResHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(21).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(22).Label = "Tran Cmf 8";
            this.spdResHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(22).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(23).Label = "Tran Cmf 9";
            this.spdResHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(23).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(24).Label = "Tran Cmf 10";
            this.spdResHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(24).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(25).Label = "Tran Cmf 11";
            this.spdResHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(25).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(26).Label = "Tran Cmf 12";
            this.spdResHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(26).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(27).Label = "Tran Cmf 13";
            this.spdResHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(27).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(28).Label = "Tran Cmf 14";
            this.spdResHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(28).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(29).Label = "Tran Cmf 15";
            this.spdResHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(29).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(30).Label = "Tran Cmf 16";
            this.spdResHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(30).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(31).Label = "Tran Cmf 17";
            this.spdResHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(31).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(32).Label = "Tran Cmf 18";
            this.spdResHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(32).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(33).Label = "Tran Cmf 19";
            this.spdResHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(33).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(34).Label = "Tran Cmf 20";
            this.spdResHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(34).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(35).Label = "Process Mode";
            this.spdResHistory_Sheet1.Columns.Get(35).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(36).Label = "Control Mode";
            this.spdResHistory_Sheet1.Columns.Get(36).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(37).Label = "User Name";
            this.spdResHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(37).Width = 85F;
            this.spdResHistory_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(38).Label = "Comment";
            this.spdResHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(38).Width = 150F;
            this.spdResHistory_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(39).Label = "Hist Delete Flag";
            this.spdResHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(39).Width = 92F;
            this.spdResHistory_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(40).Label = "Hist Delete Time";
            this.spdResHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(40).Width = 95F;
            this.spdResHistory_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(41).Label = "Hist Delete User Name";
            this.spdResHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(41).Width = 125F;
            this.spdResHistory_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(42).Label = "Hist Delete Comment";
            this.spdResHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(42).Width = 116F;
            this.spdResHistory_Sheet1.DefaultStyle.Locked = false;
            this.spdResHistory_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdResHistory_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.FrozenColumnCount = 3;
            this.spdResHistory_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdResHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdResHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdResHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResHistory_Sheet1.RowHeader.Visible = false;
            this.spdResHistory_Sheet1.Rows.Default.Height = 18F;
            this.spdResHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdResHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdResHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlTranBottom
            // 
            this.pnlTranBottom.Controls.Add(this.grpComment);
            this.pnlTranBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTranBottom.Location = new System.Drawing.Point(0, 374);
            this.pnlTranBottom.Name = "pnlTranBottom";
            this.pnlTranBottom.Size = new System.Drawing.Size(736, 44);
            this.pnlTranBottom.TabIndex = 2;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(0, 0);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(736, 44);
            this.grpComment.TabIndex = 0;
            this.grpComment.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(120, 15);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(604, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 18);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(466, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmEDCDeleteResourceDataHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmEDCDeleteResourceDataHistory";
            this.Text = "Delete Resource Data History";
            this.Activated += new System.EventHandler(this.frmEDCDeleteResourceDataHistory_Activated);
            this.Load += new System.EventHandler(this.frmEDCDeleteResourceDataHistory_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMidTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlMid.ResumeLayout(false);
            this.pnlResourceData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResHistory_Sheet1)).EndInit();
            this.pnlTranBottom.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Definition "
        
        private const int HIST_SEQ_COL = 0;
        private const int EVENT_ID = 2;
        
        private const int COLSET_ID = 4;
        private const int COLSET_VERSION =5;
        private const int CHAR_ID = 7;
        
        
#endregion
        
#region " Variable Definition"
        
        //int iLastSeq = 3;
        bool bLoadFlag;
        
#endregion
        
#region " Function Definition "
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    
                case "ViewResHist":
                    
                    
                    //Resource History Validation
                    if (cdvResID.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvResID.Focus();
                        return false;
                    }
                    
                    if (dtpFrom.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        dtpFrom.Focus();
                        return false;
                    }
                    
                    if (dtpTo.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        dtpTo.Focus();
                        return false;
                    }

                    if (MPCF.ToInt(MPCF.ToStandardTime(dtpFrom.Value, MPGC.MP_CONVERT_DATETIME_FORMAT)) > MPCF.ToInt(MPCF.ToStandardTime(dtpTo.Value, MPGC.MP_CONVERT_DATETIME_FORMAT)))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(160));
                        dtpFrom.Focus();
                        return false;
                    }
                    break;
                    
                case "ViewResourceData":
                    
                    
                    //Resource Data Validation
                    if (cdvResID.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvResID.Focus();
                        return false;
                    }
                    
                    if (spdResHistory.Sheets[0].RowCount == 0 || spdResHistory.Sheets[0].SelectionCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(161));
                        spdResHistory.Focus();
                        return false;
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
    
    //
    // ViewResourceHist()
    //       - View Resource History
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       - Optional ByVal c_step As String = "1"
    //       - ByVal sColSetId As String
    
    private bool ViewResHist(string sResId)
    {
        
        string sFromTime;
        string sToTime;
        
        sFromTime = MPCF.FromDate(dtpFrom);
        sToTime = MPCF.ToDate(dtpTo);
        
        if (RASLIST.ViewResourceHistory(spdResHistory, '2', cdvResID.Text, 'Y', cdvEventID.Text, sFromTime, sToTime, null, false) == false)
        {
            return false;
        }

        return true;
    }
        private bool View_SubResource_History()
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;

            TRSNode in_node = new TRSNode("VIEW_SUB_RESOURCE_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_SUB_RESOURCE_HISTORY_OUT");

            try
            {
                MPCF.ClearList(spdResHistory, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("SUBRES_ID", cdvSubResID.Text);
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
                in_node.AddString("EVENT_ID", cdvEventID.Text);
                in_node.AddChar("INCLUDE_DEL_HIST", 'Y');

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Sub_Resource_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sheetX = spdResHistory.ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG")) == "Y")
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        sheetX.Cells[iRow, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                        sheetX.Cells[iRow, 1].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        sheetX.Cells[iRow, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID"));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "D")
                        {
                            sheetX.Cells[iRow, 3].Value = "DOWN";
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "U")
                        {
                            sheetX.Cells[iRow, 3].Value = "UP";
                        }
                        sheetX.Cells[iRow, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_PRI_STS"));
                        sheetX.Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_1"));
                        sheetX.Cells[iRow, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_2"));
                        sheetX.Cells[iRow, 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_3"));
                        sheetX.Cells[iRow, 8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_4"));
                        sheetX.Cells[iRow, 9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_5"));
                        sheetX.Cells[iRow, 10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_6"));
                        sheetX.Cells[iRow, 11].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_7"));
                        sheetX.Cells[iRow, 12].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_8"));
                        sheetX.Cells[iRow, 13].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_9"));
                        sheetX.Cells[iRow, 14].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_10"));
                        sheetX.Cells[iRow, 15].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_1"));
                        sheetX.Cells[iRow, 16].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_2"));
                        sheetX.Cells[iRow, 17].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_3"));
                        sheetX.Cells[iRow, 18].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_4"));
                        sheetX.Cells[iRow, 19].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_5"));
                        sheetX.Cells[iRow, 20].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_6"));
                        sheetX.Cells[iRow, 21].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_7"));
                        sheetX.Cells[iRow, 22].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_8"));
                        sheetX.Cells[iRow, 23].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_9"));
                        sheetX.Cells[iRow, 24].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_10"));
                        sheetX.Cells[iRow, 25].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_11"));
                        sheetX.Cells[iRow, 26].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_12"));
                        sheetX.Cells[iRow, 27].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_13"));
                        sheetX.Cells[iRow, 28].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_14"));
                        sheetX.Cells[iRow, 29].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_15"));
                        sheetX.Cells[iRow, 30].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_16"));
                        sheetX.Cells[iRow, 31].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_17"));
                        sheetX.Cells[iRow, 32].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_18"));
                        sheetX.Cells[iRow, 33].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_19"));
                        sheetX.Cells[iRow, 34].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_20"));
                        sheetX.Cells[iRow, 35].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));
                        sheetX.Cells[iRow, 36].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT"));
                        sheetX.Cells[iRow, 37].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG"));
                        sheetX.Cells[iRow, 38].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_TIME")));
                        sheetX.Cells[iRow, 39].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_USER_ID"));
                        sheetX.Cells[iRow, 40].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_COMMENT"));
                    }

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
    
    // Delete_resData_History()
    //       -   Delete resData History
    // Return Value
    //       -
    // Arguments
    //       -
    private bool Delete_ResData_History()
    {
        TRSNode in_node = new TRSNode("DELETE_RESDATA_HISTORY_IN");
        TRSNode out_node = new TRSNode("CMN_OUT");
        
        try
        {
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
            in_node.AddString("SUBRES_ID", MPCF.Trim(cdvSubResID.Text));
            in_node.AddInt("HIST_SEQ", MPCF.ToInt(MPCF.ToDbl(spdResHistory.Sheets[0].Cells[spdResHistory.Sheets[0].ActiveRowIndex, 0].Value)));
            in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
            in_node.AddString("COL_SET_ID", MPCF.Trim(spdData.Sheets[0].Cells[0, COLSET_ID].Value));
            in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(spdData.Sheets[0].Cells[0, COLSET_VERSION].Value));

            if (MPCR.CallService("EDC", "EDC_Delete_ResData_History", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return false;
        }
    }
    
    public virtual Control GetFisrtFocusItem()
    {
        
        try
        {
            return this.cdvResID;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return null;
        }
        
    }
    
    #endregion
    
    private void frmEDCDeleteResourceDataHistory_Load(object sender, System.EventArgs e)
    {
        try
        {
            
            MPCF.FieldClear(this);
            
            dtpFrom.Value = DateTime.Now.AddMonths(- 1);
            dtpTo.Value = DateTime.Now;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
    }
    
    private void frmEDCDeleteResourceDataHistory_Activated(object sender, System.EventArgs e)
    {
        if (bLoadFlag == false)
        {
            MPCF.FieldClear(this, cdvResID, null, null, null, null, false);
            MPCF.FieldClear(this, cdvEventID, null, null, null, null, false);
            MPCF.ClearList(spdResHistory, true);
            MPCF.ClearList(spdData, true);
        
            bLoadFlag = true;
        }
    }
    private void btnProcess_Click(System.Object sender, System.EventArgs e)
    {
        if (spdResHistory.Sheets[0].RowCount < 1)
        {
            return;
        }
        
        if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
        {
            return;
        }
        
        if (Delete_ResData_History() == true)
        {
            btnView.PerformClick();
            MPCF.ClearList(spdData, true);
            txtComment.Text = "";
        }
    }
    
    private void cdvResID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            if (CheckCondition("ViewResHist", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (ViewResHist(cdvResID.Text) == false)
            {
                return;
            }
        }
    }
    
    private void cdvResID_ButtonPress(object sender, System.EventArgs e)
    {
        
        cdvResID.Init();
        cdvResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
        cdvResID.Columns.Add("Description", 100, HorizontalAlignment.Left);
        cdvResID.SelectedSubItemIndex = 0;
        if (RASLIST.ViewResourceList(cdvResID.GetListView, false) == false)
        {
            return;
        }
        
    }
    
    private void cdvEventID_ButtonPress(object sender, System.EventArgs e)
    {
        cdvEventID.Init();
        cdvEventID.Columns.Add("Event ID", 50, HorizontalAlignment.Left);
        cdvEventID.Columns.Add("Description", 100, HorizontalAlignment.Left);
        cdvEventID.SelectedSubItemIndex = 0;
        if (cdvResID.Text != "")
        {
            if (MPCF.Trim(cdvSubResID.Text) == "")
            {
                if (RASLIST.ViewResEventList(cdvEventID.GetListView, '1', cdvResID.Text, null, "") == false)
                {
                    return;
                }
            }
            else
            {
                if (RASLIST.ViewSubResEventList(cdvEventID.GetListView, '1', cdvResID.Text, cdvSubResID.Text, null, "") == false)
                {
                    return;
                }
            }
        }
        else
        {
            cdvEventID.Text = "";
            cdvEventID.GetListView.Clear();
        }
        
    }
    private void spdResHistory_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
    {
        
        try
        {
            int iRow = 0;
            
            MPCF.ClearList(spdData, true);
            if (cdvResID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvResID.Focus();
                return;
            }
            
            if (spdResHistory.Sheets[0].ActiveRowIndex < 0)
            {
                return;
            }
            
            iRow = spdResHistory.Sheets[0].ActiveRowIndex;
            
            EDCLIST.ViewResourceData(spdData, '1', cdvResID.Text,
                cdvSubResID.Text,MPCF.Trim(spdResHistory.Sheets[0].GetValue(iRow, EVENT_ID)), MPCF.ToInt(spdResHistory.Sheets[0].GetValue(iRow, HIST_SEQ_COL)), 'Y', null, false);
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
        
    }
    
    
    private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
        cdvSubResID.Text = "";        
    }
    
    private void cdvEventID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
    }
    
    private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
        cdvSubResID.Text = "";
    }
    
    private void cdvEventID_TextBoxTextChanged(object sender, System.EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
    }

    private void cdvSubResource_ButtonPress(object sender, EventArgs e)
    {
        cdvSubResID.Init();
        MPCF.InitListView(cdvSubResID.GetListView);
        cdvSubResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
        cdvSubResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvSubResID.SelectedSubItemIndex = 0;

        RASLIST.ViewSubResourceList(cdvSubResID.GetListView, '5', cdvResID.Text);
    }

    private void cdvSubResource_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
    }

    private void cdvSubResource_TextBoxTextChanged(object sender, EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
    }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (CheckCondition("ViewResHist", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (MPCF.Trim(cdvSubResID.Text) == "")
            {
                if (ViewResHist(cdvResID.Text) == false)
                {
                    return;
                }
            }
            else
            {
                View_SubResource_History();
            }
        }
}

//#End If


}
