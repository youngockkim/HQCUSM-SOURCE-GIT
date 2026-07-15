
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
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmORDSetupWorkOrder.vb
//   Description : Work Order Setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-11 : Created by H.K.KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _ORD = True Then

namespace Miracom.ORDCore
{
    public class frmORDSetupWorkOrder : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDSetupWorkOrder()
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
        private System.Windows.Forms.Panel pnlMidBottom;
        private System.Windows.Forms.Panel pnlMidMid;
        private System.Windows.Forms.Panel pnlMidRight;
        private System.Windows.Forms.GroupBox grpTop;
        private FarPoint.Win.Spread.FpSpread spdWorkOrder;
        private FarPoint.Win.Spread.SheetView spdWorkOrder_Sheet1;
        private System.Windows.Forms.RadioButton rbnRes;
        private System.Windows.Forms.RadioButton rbnOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResid;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.Label lblWorkShift;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvWorkShift;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Panel pnlComment;
        private System.Windows.Forms.GroupBox grpComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.GroupBox grpWorkOrder;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOrder;
        private System.Windows.Forms.RadioButton rbnMatid;
        private System.Windows.Forms.RadioButton rbnOrder;
        private System.Windows.Forms.RadioButton rbnLotID;
        private System.Windows.Forms.TextBox txtOrderQty;
        private System.Windows.Forms.Label lblOrderQty;
        private System.Windows.Forms.TextBox txtMatQty;
        private System.Windows.Forms.Label lblMatQty;
        private System.Windows.Forms.TextBox txtLotQty;
        private System.Windows.Forms.Label lblLotQty;
        private Miracom.MESCore.Controls.udcMaterial cdvMatid;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmORDSetupWorkOrder));
            this.pnlMidMid = new System.Windows.Forms.Panel();
            this.spdWorkOrder = new FarPoint.Win.Spread.FpSpread();
            this.spdWorkOrder_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlMidRight = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.pnlMidBottom = new System.Windows.Forms.Panel();
            this.grpWorkOrder = new System.Windows.Forms.GroupBox();
            this.cdvMatid = new Miracom.MESCore.Controls.udcMaterial();
            this.txtLotQty = new System.Windows.Forms.TextBox();
            this.lblLotQty = new System.Windows.Forms.Label();
            this.txtMatQty = new System.Windows.Forms.TextBox();
            this.lblMatQty = new System.Windows.Forms.Label();
            this.txtOrderQty = new System.Windows.Forms.TextBox();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.cdvLotID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rbnLotID = new System.Windows.Forms.RadioButton();
            this.cdvOrder = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rbnMatid = new System.Windows.Forms.RadioButton();
            this.rbnOrder = new System.Windows.Forms.RadioButton();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.pnlMidTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.cdvWorkShift = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblWorkShift = new System.Windows.Forms.Label();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResid = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rbnOper = new System.Windows.Forms.RadioButton();
            this.rbnRes = new System.Windows.Forms.RadioButton();
            this.btnView = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMidMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder_Sheet1)).BeginInit();
            this.pnlMidRight.SuspendLayout();
            this.pnlMidBottom.SuspendLayout();
            this.grpWorkOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrder)).BeginInit();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.pnlMidTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvWorkShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMidMid);
            this.pnlCenter.Controls.Add(this.pnlMidBottom);
            this.pnlCenter.Controls.Add(this.pnlMidTop);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Work Order Setup";
            // 
            // pnlMidMid
            // 
            this.pnlMidMid.Controls.Add(this.spdWorkOrder);
            this.pnlMidMid.Controls.Add(this.pnlMidRight);
            this.pnlMidMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMidMid.Location = new System.Drawing.Point(3, 71);
            this.pnlMidMid.Name = "pnlMidMid";
            this.pnlMidMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlMidMid.Size = new System.Drawing.Size(736, 302);
            this.pnlMidMid.TabIndex = 1;
            // 
            // spdWorkOrder
            // 
            this.spdWorkOrder.AccessibleDescription = "";
            this.spdWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdWorkOrder.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdWorkOrder.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdWorkOrder.HorizontalScrollBar.Name = "";
            this.spdWorkOrder.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdWorkOrder.HorizontalScrollBar.TabIndex = 2;
            this.spdWorkOrder.Location = new System.Drawing.Point(0, 3);
            this.spdWorkOrder.Name = "spdWorkOrder";
            this.spdWorkOrder.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdWorkOrder.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdWorkOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdWorkOrder_Sheet1});
            this.spdWorkOrder.Size = new System.Drawing.Size(700, 299);
            this.spdWorkOrder.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdWorkOrder.TabIndex = 0;
            this.spdWorkOrder.TextTipDelay = 200;
            this.spdWorkOrder.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdWorkOrder.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdWorkOrder.VerticalScrollBar.Name = "";
            this.spdWorkOrder.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdWorkOrder.VerticalScrollBar.TabIndex = 3;
            this.spdWorkOrder.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdWorkOrder_SelectionChanged);
            // 
            // spdWorkOrder_Sheet1
            // 
            this.spdWorkOrder_Sheet1.Reset();
            spdWorkOrder_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdWorkOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdWorkOrder_Sheet1.ColumnCount = 5;
            spdWorkOrder_Sheet1.RowCount = 5;
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Shift";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Type";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Work Order Item";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Qty";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Comment";
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdWorkOrder_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdWorkOrder_Sheet1.Columns.Get(0).Label = "Shift";
            this.spdWorkOrder_Sheet1.Columns.Get(0).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(0).Width = 40F;
            this.spdWorkOrder_Sheet1.Columns.Get(1).Label = "Type";
            this.spdWorkOrder_Sheet1.Columns.Get(1).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(1).Width = 63F;
            this.spdWorkOrder_Sheet1.Columns.Get(2).Label = "Work Order Item";
            this.spdWorkOrder_Sheet1.Columns.Get(2).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(2).Width = 128F;
            this.spdWorkOrder_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdWorkOrder_Sheet1.Columns.Get(3).Label = "Qty";
            this.spdWorkOrder_Sheet1.Columns.Get(3).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(4).Label = "Comment";
            this.spdWorkOrder_Sheet1.Columns.Get(4).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(4).Width = 356F;
            this.spdWorkOrder_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdWorkOrder_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdWorkOrder_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdWorkOrder_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdWorkOrder_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdWorkOrder_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdWorkOrder_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdWorkOrder_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdWorkOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlMidRight
            // 
            this.pnlMidRight.Controls.Add(this.btnDown);
            this.pnlMidRight.Controls.Add(this.btnUp);
            this.pnlMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMidRight.Location = new System.Drawing.Point(700, 3);
            this.pnlMidRight.Name = "pnlMidRight";
            this.pnlMidRight.Size = new System.Drawing.Size(36, 299);
            this.pnlMidRight.TabIndex = 1;
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(6, 152);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(25, 25);
            this.btnDown.TabIndex = 1;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(6, 118);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(25, 25);
            this.btnUp.TabIndex = 0;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // pnlMidBottom
            // 
            this.pnlMidBottom.Controls.Add(this.grpWorkOrder);
            this.pnlMidBottom.Controls.Add(this.pnlComment);
            this.pnlMidBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMidBottom.Location = new System.Drawing.Point(3, 373);
            this.pnlMidBottom.Name = "pnlMidBottom";
            this.pnlMidBottom.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlMidBottom.Size = new System.Drawing.Size(736, 140);
            this.pnlMidBottom.TabIndex = 2;
            // 
            // grpWorkOrder
            // 
            this.grpWorkOrder.Controls.Add(this.cdvMatid);
            this.grpWorkOrder.Controls.Add(this.txtLotQty);
            this.grpWorkOrder.Controls.Add(this.lblLotQty);
            this.grpWorkOrder.Controls.Add(this.txtMatQty);
            this.grpWorkOrder.Controls.Add(this.lblMatQty);
            this.grpWorkOrder.Controls.Add(this.txtOrderQty);
            this.grpWorkOrder.Controls.Add(this.lblOrderQty);
            this.grpWorkOrder.Controls.Add(this.cdvLotID);
            this.grpWorkOrder.Controls.Add(this.rbnLotID);
            this.grpWorkOrder.Controls.Add(this.cdvOrder);
            this.grpWorkOrder.Controls.Add(this.rbnMatid);
            this.grpWorkOrder.Controls.Add(this.rbnOrder);
            this.grpWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWorkOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpWorkOrder.Location = new System.Drawing.Point(0, 45);
            this.grpWorkOrder.Name = "grpWorkOrder";
            this.grpWorkOrder.Size = new System.Drawing.Size(736, 92);
            this.grpWorkOrder.TabIndex = 3;
            this.grpWorkOrder.TabStop = false;
            // 
            // cdvMatid
            // 
            this.cdvMatid.AddEmptyRowToLast = false;
            this.cdvMatid.AddEmptyRowToTop = false;
            this.cdvMatid.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMatid.DisplaySubItemIndex = 0;
            this.cdvMatid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatid.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMatid.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatid.LabelText = "Material";
            this.cdvMatid.ListCond_ExtFactory = "";
            this.cdvMatid.ListCond_StepMaterial = '1';
            this.cdvMatid.ListCond_StepVersion = '1';
            this.cdvMatid.Location = new System.Drawing.Point(120, 39);
            this.cdvMatid.MaterialEnabled = true;
            this.cdvMatid.MaterialReadOnly = false;
            this.cdvMatid.Name = "cdvMatid";
            this.cdvMatid.SearchSubItemIndex = 0;
            this.cdvMatid.SelectedDescIndex = -1;
            this.cdvMatid.SelectedSubItemIndex = 0;
            this.cdvMatid.Size = new System.Drawing.Size(200, 20);
            this.cdvMatid.TabIndex = 5;
            this.cdvMatid.VersionEnabled = true;
            this.cdvMatid.VersionReadOnly = false;
            this.cdvMatid.VisibleColumnHeader = false;
            this.cdvMatid.VisibleDescription = false;
            this.cdvMatid.VisibleMaterialButton = true;
            this.cdvMatid.VisibleVersionButton = true;
            this.cdvMatid.WidthButton = 20;
            this.cdvMatid.WidthLabel = 0;
            this.cdvMatid.WidthMaterialAndVersion = 200;
            this.cdvMatid.WidthVersion = 50;
            // 
            // txtLotQty
            // 
            this.txtLotQty.Location = new System.Drawing.Point(424, 64);
            this.txtLotQty.MaxLength = 11;
            this.txtLotQty.Name = "txtLotQty";
            this.txtLotQty.Size = new System.Drawing.Size(133, 20);
            this.txtLotQty.TabIndex = 11;
            this.txtLotQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLotQty
            // 
            this.lblLotQty.AutoSize = true;
            this.lblLotQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotQty.Location = new System.Drawing.Point(336, 67);
            this.lblLotQty.Name = "lblLotQty";
            this.lblLotQty.Size = new System.Drawing.Size(23, 13);
            this.lblLotQty.TabIndex = 10;
            this.lblLotQty.Text = "Qty";
            this.lblLotQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMatQty
            // 
            this.txtMatQty.Location = new System.Drawing.Point(424, 40);
            this.txtMatQty.MaxLength = 11;
            this.txtMatQty.Name = "txtMatQty";
            this.txtMatQty.Size = new System.Drawing.Size(133, 20);
            this.txtMatQty.TabIndex = 7;
            this.txtMatQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMatQty
            // 
            this.lblMatQty.AutoSize = true;
            this.lblMatQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMatQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatQty.Location = new System.Drawing.Point(336, 43);
            this.lblMatQty.Name = "lblMatQty";
            this.lblMatQty.Size = new System.Drawing.Size(23, 13);
            this.lblMatQty.TabIndex = 6;
            this.lblMatQty.Text = "Qty";
            this.lblMatQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderQty
            // 
            this.txtOrderQty.Location = new System.Drawing.Point(424, 16);
            this.txtOrderQty.MaxLength = 11;
            this.txtOrderQty.Name = "txtOrderQty";
            this.txtOrderQty.Size = new System.Drawing.Size(133, 20);
            this.txtOrderQty.TabIndex = 3;
            this.txtOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.AutoSize = true;
            this.lblOrderQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderQty.Location = new System.Drawing.Point(336, 19);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(23, 13);
            this.lblOrderQty.TabIndex = 2;
            this.lblOrderQty.Text = "Qty";
            this.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvLotID
            // 
            this.cdvLotID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLotID.BtnToolTipText = "";
            this.cdvLotID.DescText = "";
            this.cdvLotID.DisplaySubItemIndex = -1;
            this.cdvLotID.DisplayText = "";
            this.cdvLotID.Focusing = null;
            this.cdvLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLotID.Index = 0;
            this.cdvLotID.IsViewBtnImage = false;
            this.cdvLotID.Location = new System.Drawing.Point(120, 64);
            this.cdvLotID.MaxLength = 25;
            this.cdvLotID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLotID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLotID.Name = "cdvLotID";
            this.cdvLotID.ReadOnly = false;
            this.cdvLotID.SearchSubItemIndex = 0;
            this.cdvLotID.SelectedDescIndex = -1;
            this.cdvLotID.SelectedSubItemIndex = -1;
            this.cdvLotID.SelectionStart = 0;
            this.cdvLotID.Size = new System.Drawing.Size(200, 20);
            this.cdvLotID.SmallImageList = null;
            this.cdvLotID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotID.TabIndex = 9;
            this.cdvLotID.TextBoxToolTipText = "";
            this.cdvLotID.TextBoxWidth = 200;
            this.cdvLotID.VisibleButton = true;
            this.cdvLotID.VisibleColumnHeader = false;
            this.cdvLotID.VisibleDescription = false;
            this.cdvLotID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvLotID_SelectedItemChanged);
            this.cdvLotID.ButtonPress += new System.EventHandler(this.cdvLotID_ButtonPress);
            // 
            // rbnLotID
            // 
            this.rbnLotID.AutoSize = true;
            this.rbnLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnLotID.Location = new System.Drawing.Point(15, 67);
            this.rbnLotID.Name = "rbnLotID";
            this.rbnLotID.Size = new System.Drawing.Size(49, 18);
            this.rbnLotID.TabIndex = 8;
            this.rbnLotID.Text = "Lot ";
            this.rbnLotID.CheckedChanged += new System.EventHandler(this.rbnOrderMatLot_CheckedChanged);
            // 
            // cdvOrder
            // 
            this.cdvOrder.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOrder.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOrder.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOrder.BtnToolTipText = "";
            this.cdvOrder.DescText = "";
            this.cdvOrder.DisplaySubItemIndex = -1;
            this.cdvOrder.DisplayText = "";
            this.cdvOrder.Focusing = null;
            this.cdvOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOrder.Index = 0;
            this.cdvOrder.IsViewBtnImage = false;
            this.cdvOrder.Location = new System.Drawing.Point(120, 16);
            this.cdvOrder.MaxLength = 25;
            this.cdvOrder.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOrder.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOrder.Name = "cdvOrder";
            this.cdvOrder.ReadOnly = false;
            this.cdvOrder.SearchSubItemIndex = 0;
            this.cdvOrder.SelectedDescIndex = -1;
            this.cdvOrder.SelectedSubItemIndex = -1;
            this.cdvOrder.SelectionStart = 0;
            this.cdvOrder.Size = new System.Drawing.Size(200, 20);
            this.cdvOrder.SmallImageList = null;
            this.cdvOrder.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOrder.TabIndex = 1;
            this.cdvOrder.TextBoxToolTipText = "";
            this.cdvOrder.TextBoxWidth = 200;
            this.cdvOrder.VisibleButton = true;
            this.cdvOrder.VisibleColumnHeader = false;
            this.cdvOrder.VisibleDescription = false;
            this.cdvOrder.ButtonPress += new System.EventHandler(this.cdvOrder_ButtonPress);
            // 
            // rbnMatid
            // 
            this.rbnMatid.AutoSize = true;
            this.rbnMatid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnMatid.Location = new System.Drawing.Point(15, 43);
            this.rbnMatid.Name = "rbnMatid";
            this.rbnMatid.Size = new System.Drawing.Size(68, 18);
            this.rbnMatid.TabIndex = 4;
            this.rbnMatid.Text = "Material";
            this.rbnMatid.CheckedChanged += new System.EventHandler(this.rbnOrderMatLot_CheckedChanged);
            // 
            // rbnOrder
            // 
            this.rbnOrder.AutoSize = true;
            this.rbnOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnOrder.Location = new System.Drawing.Point(15, 19);
            this.rbnOrder.Name = "rbnOrder";
            this.rbnOrder.Size = new System.Drawing.Size(57, 18);
            this.rbnOrder.TabIndex = 0;
            this.rbnOrder.Text = "Order";
            this.rbnOrder.CheckedChanged += new System.EventHandler(this.rbnOrderMatLot_CheckedChanged);
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.grpComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComment.Location = new System.Drawing.Point(0, 0);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(736, 45);
            this.pnlComment.TabIndex = 2;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(0, 0);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(736, 45);
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
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 18);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMidTop
            // 
            this.pnlMidTop.Controls.Add(this.grpTop);
            this.pnlMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidTop.Location = new System.Drawing.Point(3, 0);
            this.pnlMidTop.Name = "pnlMidTop";
            this.pnlMidTop.Size = new System.Drawing.Size(736, 71);
            this.pnlMidTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.cdvWorkShift);
            this.grpTop.Controls.Add(this.dtpWorkDate);
            this.grpTop.Controls.Add(this.lblWorkShift);
            this.grpTop.Controls.Add(this.lblWorkDate);
            this.grpTop.Controls.Add(this.cdvOper);
            this.grpTop.Controls.Add(this.cdvResid);
            this.grpTop.Controls.Add(this.rbnOper);
            this.grpTop.Controls.Add(this.rbnRes);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(0, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(736, 71);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // cdvWorkShift
            // 
            this.cdvWorkShift.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvWorkShift.BorderHotColor = System.Drawing.Color.Black;
            this.cdvWorkShift.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvWorkShift.BtnToolTipText = "";
            this.cdvWorkShift.DescText = "";
            this.cdvWorkShift.DisplaySubItemIndex = -1;
            this.cdvWorkShift.DisplayText = "";
            this.cdvWorkShift.Focusing = null;
            this.cdvWorkShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvWorkShift.Index = 0;
            this.cdvWorkShift.IsViewBtnImage = false;
            this.cdvWorkShift.Location = new System.Drawing.Point(522, 40);
            this.cdvWorkShift.MaxLength = 1;
            this.cdvWorkShift.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvWorkShift.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvWorkShift.Name = "cdvWorkShift";
            this.cdvWorkShift.ReadOnly = true;
            this.cdvWorkShift.SearchSubItemIndex = 0;
            this.cdvWorkShift.SelectedDescIndex = -1;
            this.cdvWorkShift.SelectedSubItemIndex = -1;
            this.cdvWorkShift.SelectionStart = 0;
            this.cdvWorkShift.Size = new System.Drawing.Size(200, 20);
            this.cdvWorkShift.SmallImageList = null;
            this.cdvWorkShift.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvWorkShift.TabIndex = 7;
            this.cdvWorkShift.TextBoxToolTipText = "";
            this.cdvWorkShift.TextBoxWidth = 200;
            this.cdvWorkShift.VisibleButton = true;
            this.cdvWorkShift.VisibleColumnHeader = false;
            this.cdvWorkShift.VisibleDescription = false;
            this.cdvWorkShift.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvWorkShift_SelectedItemChanged);
            this.cdvWorkShift.ButtonPress += new System.EventHandler(this.cdvWorkShift_ButtonPress);
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(522, 17);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(96, 20);
            this.dtpWorkDate.TabIndex = 6;
            // 
            // lblWorkShift
            // 
            this.lblWorkShift.AutoSize = true;
            this.lblWorkShift.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkShift.Location = new System.Drawing.Point(404, 43);
            this.lblWorkShift.Name = "lblWorkShift";
            this.lblWorkShift.Size = new System.Drawing.Size(57, 13);
            this.lblWorkShift.TabIndex = 5;
            this.lblWorkShift.Text = "Work Shift";
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkDate.Location = new System.Drawing.Point(404, 20);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(59, 13);
            this.lblWorkDate.TabIndex = 4;
            this.lblWorkDate.Text = "Work Date";
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(120, 40);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 3;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxTextChanged += new System.EventHandler(this.cdvOper_TextBoxTextChanged);
            // 
            // cdvResid
            // 
            this.cdvResid.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResid.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResid.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResid.BtnToolTipText = "";
            this.cdvResid.DescText = "";
            this.cdvResid.DisplaySubItemIndex = -1;
            this.cdvResid.DisplayText = "";
            this.cdvResid.Focusing = null;
            this.cdvResid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResid.Index = 0;
            this.cdvResid.IsViewBtnImage = false;
            this.cdvResid.Location = new System.Drawing.Point(120, 16);
            this.cdvResid.MaxLength = 20;
            this.cdvResid.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResid.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResid.Name = "cdvResid";
            this.cdvResid.ReadOnly = false;
            this.cdvResid.SearchSubItemIndex = 0;
            this.cdvResid.SelectedDescIndex = -1;
            this.cdvResid.SelectedSubItemIndex = -1;
            this.cdvResid.SelectionStart = 0;
            this.cdvResid.Size = new System.Drawing.Size(200, 20);
            this.cdvResid.SmallImageList = null;
            this.cdvResid.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResid.TabIndex = 2;
            this.cdvResid.TextBoxToolTipText = "";
            this.cdvResid.TextBoxWidth = 200;
            this.cdvResid.VisibleButton = true;
            this.cdvResid.VisibleColumnHeader = false;
            this.cdvResid.VisibleDescription = false;
            this.cdvResid.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResid_SelectedItemChanged);
            this.cdvResid.ButtonPress += new System.EventHandler(this.cdvResid_ButtonPress);
            this.cdvResid.TextBoxTextChanged += new System.EventHandler(this.cdvResid_TextBoxTextChanged);
            // 
            // rbnOper
            // 
            this.rbnOper.AutoSize = true;
            this.rbnOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnOper.Location = new System.Drawing.Point(15, 43);
            this.rbnOper.Name = "rbnOper";
            this.rbnOper.Size = new System.Drawing.Size(54, 18);
            this.rbnOper.TabIndex = 1;
            this.rbnOper.Text = "Oper";
            this.rbnOper.CheckedChanged += new System.EventHandler(this.rbnResOper_CheckedChanged);
            // 
            // rbnRes
            // 
            this.rbnRes.AutoSize = true;
            this.rbnRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnRes.Location = new System.Drawing.Point(15, 19);
            this.rbnRes.Name = "rbnRes";
            this.rbnRes.Size = new System.Drawing.Size(77, 18);
            this.rbnRes.TabIndex = 0;
            this.rbnRes.Text = "Resource";
            this.rbnRes.CheckedChanged += new System.EventHandler(this.rbnResOper_CheckedChanged);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.Location = new System.Drawing.Point(284, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmORDSetupWorkOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmORDSetupWorkOrder";
            this.Text = "Work Order Setup";
            this.Activated += new System.EventHandler(this.frmORDSetupWorkOrder_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMidMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder_Sheet1)).EndInit();
            this.pnlMidRight.ResumeLayout(false);
            this.pnlMidBottom.ResumeLayout(false);
            this.grpWorkOrder.ResumeLayout(false);
            this.grpWorkOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrder)).EndInit();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.pnlMidTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvWorkShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResid)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        private bool b_load_flag = false;
        #endregion
        
        #region " Function Definition "
        
        // View_Lot()
        //       -  View Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Lot_Info(char c_step, string sLot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("LOT_ID", MPCF.Trim(sLot_id));

            txtLotQty.Text = "";

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            txtLotQty.Text = MPCF.Format("########,##0.###", out_node.GetDouble("QTY_1"));
            return true;
        }

        //
        // ViewWorkOrderList()
        //       - ViewWorkOrderList
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool ViewWorkOrderList(Control control, char c_step)
        {

            TRSNode in_node = new TRSNode("VIEW_WORKORDER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_WORKORDER_LIST_OUT");
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iLastRow;

            MPCF.ClearList(control, true);

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                
                if (rbnRes.Checked == true)
                {
                    in_node.AddChar("RES_OR_OPR_FLAG", 'R');
                }
                else if (rbnOper.Checked == true)
                {
                    in_node.AddChar("RES_OR_OPR_FLAG", 'O');
                }
                in_node.AddString("RES_ID", cdvResid.Text);
                in_node.AddString("OPER", cdvOper.Text);
                in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddChar("NEXT_WORK_SHIFT", ' ');
                if (cdvWorkShift.Text == "ALL")
                {
                    in_node.AddChar("WORK_SHIFT", 'A');
                }
                else
                {
                    in_node.AddChar("WORK_SHIFT", MPCF.ToChar(cdvWorkShift.Text));
                }
                in_node.AddInt("NEXT_SEQ_NUM", 0);
                do
                {
                    if (MPCR.CallService("ORD", "ORD_View_WorkOrder_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            sheetX = ((FarPoint.Win.Spread.FpSpread) control).Sheets[0];
                            iLastRow = sheetX.RowCount;
                            sheetX.RowCount++;
                            sheetX.RowHeader.Rows[iLastRow].Label = MPCF.Trim(out_node.GetList(0)[i].GetInt("SEQ_NUM"));
                            sheetX.SetValue(iLastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetChar("WORK_SHIFT")));
                            if (out_node.GetList(0)[i].GetChar("ORD_MAT_LOT_FLAG") == 'O')
                            {
                                sheetX.SetValue(iLastRow, 1, "ORDER");
                                sheetX.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("ORDER_ID")));
                            }
                            else if (out_node.GetList(0)[i].GetChar("ORD_MAT_LOT_FLAG") == 'M')
                            {
                                sheetX.SetValue(iLastRow, 1, "MATERIAL");
                                sheetX.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")) + "(" + MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER")) + ")");
                            }
                            else if (out_node.GetList(0)[i].GetChar("ORD_MAT_LOT_FLAG") == 'L')
                            {
                                sheetX.SetValue(iLastRow, 1, "LOT");
                                sheetX.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                            }
                            sheetX.SetValue(iLastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetDouble("QTY")));
                            sheetX.SetValue(iLastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("WORK_COMMENT")));
                        }
                    }
                    in_node.SetChar("NEXT_WORK_SHIFT", out_node.GetChar("NEXT_WORK_SHIFT"));
                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
                } while (in_node.GetChar("NEXT_WORK_SHIFT").ToString() != " " || in_node.GetInt("NEXT_SEQ_NUM") > 0);


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }
        private string GetMaterial(int iRow)
        {

            string sMaterial = "";
            int iMatVer = 0;

            try
            {
                /* 2013.06.12. Aiden. Material ID 에 (,) 가 포함된 경우 Parsing이 제대로 안되는 문제 해결 */
                MPCR.ParseSequenceInfo(spdWorkOrder.Sheets[0].Cells[iRow, 2].Text, ref sMaterial, ref iMatVer);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }

            return sMaterial;

        }
        private int GetMatVer(int iRow)
        {
            string sMaterial = "";
            int iMaterialVer = 0;

            try
            {
                /* 2013.06.12. Aiden. Material ID 에 (,) 가 포함된 경우 Parsing이 제대로 안되는 문제 해결 */
                MPCR.ParseSequenceInfo(spdWorkOrder.Sheets[0].Cells[iRow, 2].Text, ref sMaterial, ref iMaterialVer);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return 0;
            }

            return iMaterialVer;
        }
        private bool View_WorkOrder()
        {
            int sCurrentRow;

            sCurrentRow = spdWorkOrder.Sheets[0].ActiveRowIndex;

            txtComment.Text = spdWorkOrder.Sheets[0].Cells[sCurrentRow, 4].Text;

            if ((spdWorkOrder.Sheets[0].Cells[sCurrentRow, 1].Text).Substring(0, 1) == "O")
            {
                rbnOrder.Checked = true;
                cdvOrder.Text = spdWorkOrder.Sheets[0].Cells[sCurrentRow, 2].Text;
                txtOrderQty.Text = spdWorkOrder.Sheets[0].Cells[sCurrentRow, 3].Text;
            }
            else if ((spdWorkOrder.Sheets[0].Cells[sCurrentRow, 1].Text).Substring(0, 1) == "M")
            {
                rbnMatid.Checked = true;
                cdvMatid.Text = GetMaterial(sCurrentRow);
                cdvMatid.Version = GetMatVer(sCurrentRow);
                txtMatQty.Text = spdWorkOrder.Sheets[0].Cells[sCurrentRow, 3].Text;
            }
            else if ((spdWorkOrder.Sheets[0].Cells[sCurrentRow, 1].Text).Substring(0, 1) == "L")
            {
                rbnLotID.Checked = true;
                cdvLotID.Text = spdWorkOrder.Sheets[0].Cells[sCurrentRow, 2].Text;
                txtLotQty.Text = spdWorkOrder.Sheets[0].Cells[sCurrentRow, 3].Text;
            }

            return true;
        }
        private bool Update_WorkOrder(char c_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_WORKORDER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                if (rbnRes.Checked == true)
                {
                    in_node.AddChar("RES_OR_OPR_FLAG", 'R');
                    in_node.AddString("RES_ID", cdvResid.Text);
                    in_node.AddString("OPER", "");
                }
                else if (rbnOper.Checked == true)
                {
                    in_node.AddChar("RES_OR_OPR_FLAG", 'O');
                    in_node.AddString("OPER", cdvOper.Text);
                    in_node.AddString("RES_ID", "");
                }
                in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddChar("WORK_SHIFT", MPCF.ToChar(cdvWorkShift.Text));
                if (rbnOrder.Checked == true)
                {
                    in_node.AddChar("ORD_MAT_LOT_FLAG", 'O');
                    in_node.AddString("ORDER_ID", cdvOrder.Text);
                    in_node.AddDouble("QTY", MPCF.ToDbl(txtOrderQty.Text));
                }
                else if (rbnMatid.Checked == true)
                {
                    in_node.AddChar("ORD_MAT_LOT_FLAG", 'M');
                    in_node.AddString("MAT_ID", cdvMatid.Text);
                    in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMatid.Version));
                    in_node.AddDouble("QTY", MPCF.ToDbl(txtMatQty.Text));
                }
                else if (rbnLotID.Checked == true)
                {
                    in_node.AddChar("ORD_MAT_LOT_FLAG", 'L');
                    in_node.AddString("LOT_ID", cdvLotID.Text);
                    in_node.AddDouble("QTY", MPCF.ToDbl(txtLotQty.Text));
                }
                in_node.AddString("WORK_COMMENT", txtComment.Text);
                if (c_step == MPGC.MP_STEP_UPDATE || c_step == MPGC.MP_STEP_DELETE || c_step == '1' || c_step == '2')
                {
                    in_node.SetChar("WORK_SHIFT", MPCF.ToChar(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.Sheets[0].ActiveRowIndex, 0].Text));
                    in_node.AddInt("SEQ_NUM", MPCF.ToInt(spdWorkOrder.Sheets[0].RowHeader.Rows[spdWorkOrder.Sheets[0].ActiveRowIndex].Label));
                }

                if (MPCR.CallService("ORD", "ORD_Update_WorkOrder", in_node, ref out_node) == false)
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

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":
                    
                    if (cdvWorkShift.Text == "ALL")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(168));
                        return false;
                    }
                    if (rbnRes.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvResid, 1) == false)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (MPCF.CheckValue(cdvOper, 1) == false)
                        {
                            return false;
                        }
                    }
                    if (rbnOrder.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvOrder, 1) == false)
                        {
                            return false;
                        }
                    }
                    else if (rbnMatid.Checked == true)
                    {
                        if (cdvMatid.CheckValue() == false)
                        {
                            return false;
                        }
                    }
                    else if (rbnLotID.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvLotID, 1) == false)
                        {
                            return false;
                        }
                    }
                    break;
                case "UPDATE":
                    
                    if (spdWorkOrder.Sheets[0].SelectionCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        return false;
                    }
                    if (rbnRes.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvResid, 1) == false)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (MPCF.CheckValue(cdvOper, 1) == false)
                        {
                            return false;
                        }
                    }
                    if (rbnOrder.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvOrder, 1) == false)
                        {
                            return false;
                        }
                    }
                    else if (rbnMatid.Checked == true)
                    {
                        if (cdvMatid.CheckValue() == false)
                        {
                            return false;
                        }
                    }
                    else if (rbnLotID.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvLotID, 1) == false)
                        {
                            return false;
                        }
                    }
                    break;
                case "DELETE":
                    
                    if (spdWorkOrder.Sheets[0].SelectionCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        return false;
                    }
                    if (rbnRes.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvResid, 1) == false)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (MPCF.CheckValue(cdvOper, 1) == false)
                        {
                            return false;
                        }
                    }
                    break;
                case "VIEW":
                    
                    if (rbnRes.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvResid, 1, false, false , "", "", "") == false)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (MPCF.CheckValue(cdvOper, 1) == false)
                        {
                            return false;
                        }
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                if (this.cdvResid.Enabled == true)
                {
                    return this.cdvResid;
                }
                else
                {
                    return this.cdvOper;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void rbnResOper_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdWorkOrder, true);
            if (rbnRes.Checked == true)
            {
                cdvResid.Enabled = true;
                cdvResid.BackColor = SystemColors.Window;
                cdvOper.Enabled = false;
                cdvOper.BackColor = SystemColors.Control;
                cdvOper.Text = "";
            }
            else if (rbnOper.Checked == true)
            {
                cdvResid.Enabled = false;
                cdvResid.BackColor = SystemColors.Control;
                cdvResid.Text = "";
                cdvOper.Enabled = true;
                cdvOper.BackColor = SystemColors.Window;
            }
        }
        
        private void rbnOrderMatLot_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (rbnOrder.Checked == true)
            {
                cdvOrder.Enabled = true;
                cdvOrder.BackColor = SystemColors.Window;
                txtOrderQty.Enabled = true;
                
                cdvMatid.Enabled = false;
                cdvMatid.BackColor = SystemColors.Control;
                txtMatQty.Enabled = false;
                
                cdvLotID.Enabled = false;
                cdvLotID.BackColor = SystemColors.Control;
                txtLotQty.Enabled = false;
                
                MPCF.FieldClear(grpWorkOrder, cdvOrder, txtOrderQty, rbnOrder, null, null, false);
            }
            else if (rbnMatid.Checked == true)
            {
                cdvOrder.Enabled = false;
                cdvOrder.BackColor = SystemColors.Control;
                txtOrderQty.Enabled = false;
                
                cdvMatid.Enabled = true;
                cdvMatid.BackColor = SystemColors.Window;
                txtMatQty.Enabled = true;
                
                cdvLotID.Enabled = false;
                cdvLotID.BackColor = SystemColors.Control;
                txtLotQty.Enabled = false;
                
                MPCF.FieldClear(grpWorkOrder, cdvMatid, txtMatQty, rbnMatid, null, null, false);
            }
            else if (rbnLotID.Checked == true)
            {
                cdvOrder.Enabled = false;
                cdvOrder.BackColor = SystemColors.Control;
                txtOrderQty.Enabled = false;
                
                cdvMatid.Enabled = false;
                cdvMatid.BackColor = SystemColors.Control;
                txtMatQty.Enabled = false;
                
                cdvLotID.Enabled = true;
                cdvLotID.BackColor = SystemColors.Window;
                txtLotQty.Enabled = true;
                
                MPCF.FieldClear(grpWorkOrder, cdvLotID, txtLotQty, rbnLotID, null, null, false);
            }
        }
        
        private void frmORDSetupWorkOrder_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                dtpWorkDate.Value = DateTime.Now;
                rbnRes.Checked = true;
                rbnOrder.Checked = true;
                b_load_flag = true;
            }
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == true)
            {
                ViewWorkOrderList(spdWorkOrder, '1');
            }
        }
        
        private void cdvLotID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvLotID.Text != "")
            {
                View_Lot_Info('1', cdvLotID.Text);
            }
        }
        
        private void cdvWorkShift_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdWorkOrder, true);
        }
        
        private void cdvResid_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdWorkOrder, true);
        }
        
        private void cdvOper_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdWorkOrder, true);
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("CREATE") == true)
            {
                if (Update_WorkOrder(MPGC.MP_STEP_CREATE) == true)
                {
                    ViewWorkOrderList(spdWorkOrder, '1');
                }
            }
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("UPDATE") == true)
            {
                if (Update_WorkOrder(MPGC.MP_STEP_UPDATE) == true)
                {
                    ViewWorkOrderList(spdWorkOrder, '1');
                }
            }
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            
            if (CheckCondition("DELETE") == true)
            {
                if (Update_WorkOrder(MPGC.MP_STEP_DELETE) == true)
                {
                    ViewWorkOrderList(spdWorkOrder, '1');
                }
            }
        }
        
        private void btnUp_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("UPDATE") == true)
            {
                if (Update_WorkOrder('1') == true)
                {
                    ViewWorkOrderList(spdWorkOrder, '1');
                }
            }
        }
        
        private void btnDown_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("UPDATE") == true)
            {
                if (Update_WorkOrder('2') == true)
                {
                    ViewWorkOrderList(spdWorkOrder, '1');
                }
            }
        }
        
        private void spdWorkOrder_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            View_WorkOrder();
        }
        
        private void cdvResid_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdWorkOrder, true);
        }
        
        private void cdvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdWorkOrder, true);
        }
        
        //private void cdvMatid_MaterialButtonPress(object sender, System.EventArgs e)
        //{
        //    cdvMatid.Init();
        //    MPCF.InitListView(cdvMatid.MaterialGetListView);
        //    cdvMatid.MaterialColumns.Add("Material", 50, HorizontalAlignment.Left);
        //    cdvMatid.MaterialColumns.Add("Desc", 100, HorizontalAlignment.Left);
        //    cdvMatid.SelectedSubItemIndex = 0;

        //    WIPLIST.ViewMaterialList(cdvMatid.MaterialGetListView, '1');
        //}
        
        private void cdvOper_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvOper.GetListView, '1', "",0, "", "", null, "");
        }
        
        private void cdvResid_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResid.Init();
            MPCF.InitListView(cdvResid.GetListView);
            cdvResid.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvResid.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResid.SelectedSubItemIndex = 0;
            #if _RAS
            RASLIST.ViewResourceList(cdvResid.GetListView, false);
            #endif
        }
        
        private void cdvWorkShift_ButtonPress(object sender, System.EventArgs e)
        {
            
            ListViewItem itmX;
            cdvWorkShift.Init();
            MPCF.InitListView(cdvWorkShift.GetListView);
            cdvWorkShift.Columns.Add("Shift", 50, HorizontalAlignment.Left);
            cdvWorkShift.Columns.Add("Start", 100, HorizontalAlignment.Left);
            cdvWorkShift.SelectedSubItemIndex = 0;
            
            cdvWorkShift.AddEmptyRow(1);
            itmX = new ListViewItem("ALL", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itmX.SubItems.Add("ALL SHIFT");
            cdvWorkShift.Items.Add(itmX);
            WIPLIST.ViewFactoryShiftList(cdvWorkShift.GetListView, '1');
            
        }
        
        private void cdvOrder_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOrder.Init();
            MPCF.InitListView(cdvOrder.GetListView);
            cdvOrder.Columns.Add("Order", 50, HorizontalAlignment.Left);
            cdvOrder.Columns.Add("Mat ID", 200, HorizontalAlignment.Left);
            cdvOrder.Columns.Add("Mat Ver", 200, HorizontalAlignment.Left);
            cdvOrder.Columns.Add("Order Qty", 200, HorizontalAlignment.Left);
            cdvOrder.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOrder.SelectedSubItemIndex = 0;
            ORDLIST.ViewOrderList(cdvOrder.GetListView, '3', "", null, "");
        }
        
        private void cdvLotID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvLotID.Init();
            MPCF.InitListView(cdvLotID.GetListView);
            cdvLotID.Columns.Add("LotID", 50, HorizontalAlignment.Left);
            cdvLotID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvLotID.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewLotList(cdvLotID.GetListView, '1', null);
        }
    }
    //#End If
}
