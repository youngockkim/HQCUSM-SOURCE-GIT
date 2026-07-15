
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
//   File Name   : frmRASViewEventByGroup.vb
//   Description : View Event List By Group Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_Event_Group()  :  View Event group prompt and data
//       - CheckCondition()       :  Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-30 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASViewEventByGroup : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewEventByGroup()
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
        



        private System.Windows.Forms.Panel pnlGrp;
        private System.Windows.Forms.GroupBox grpOption;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.ComboBox cboGrp3;
        private System.Windows.Forms.ComboBox cboGrp2;
        private System.Windows.Forms.Label lblResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp3;
        private FarPoint.Win.Spread.FpSpread spdEvent;
        private FarPoint.Win.Spread.SheetView spdEvent_Sheet1;
        public System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ContextMenu ctxCopyMenu;
        private System.Windows.Forms.MenuItem ctxCopy;
        private System.Windows.Forms.Label lblPrt1;
        private System.Windows.Forms.Label lblGrp1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrt1;
        private System.Windows.Forms.Panel pnlEvent;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASViewEventByGroup));
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvGrp1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPrt1 = new System.Windows.Forms.Label();
            this.lblGrp1 = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboGrp3 = new System.Windows.Forms.ComboBox();
            this.cboGrp2 = new System.Windows.Forms.ComboBox();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvPrt1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.spdEvent = new FarPoint.Win.Spread.FpSpread();
            this.ctxCopyMenu = new System.Windows.Forms.ContextMenu();
            this.ctxCopy = new System.Windows.Forms.MenuItem();
            this.spdEvent_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrp.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp3)).BeginInit();
            this.pnlEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEvent_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.TabIndex = 2;
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 546);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Event List by Event Group";
            // 
            // pnlGrp
            // 
            this.pnlGrp.Controls.Add(this.grpOption);
            this.pnlGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrp.Location = new System.Drawing.Point(0, 0);
            this.pnlGrp.Name = "pnlGrp";
            this.pnlGrp.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlGrp.Size = new System.Drawing.Size(742, 71);
            this.pnlGrp.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvGrp1);
            this.grpOption.Controls.Add(this.lblPrt1);
            this.grpOption.Controls.Add(this.lblGrp1);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.cboGrp3);
            this.grpOption.Controls.Add(this.cboGrp2);
            this.grpOption.Controls.Add(this.lblResID);
            this.grpOption.Controls.Add(this.cdvPrt1);
            this.grpOption.Controls.Add(this.cdvGrp2);
            this.grpOption.Controls.Add(this.cdvGrp3);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 71);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // cdvGrp1
            // 
            this.cdvGrp1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp1.BtnToolTipText = "";
            this.cdvGrp1.DescText = "";
            this.cdvGrp1.DisplaySubItemIndex = -1;
            this.cdvGrp1.DisplayText = "";
            this.cdvGrp1.Focusing = null;
            this.cdvGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp1.Index = 0;
            this.cdvGrp1.IsViewBtnImage = false;
            this.cdvGrp1.Location = new System.Drawing.Point(512, 40);
            this.cdvGrp1.MaxLength = 30;
            this.cdvGrp1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp1.Name = "cdvGrp1";
            this.cdvGrp1.ReadOnly = false;
            this.cdvGrp1.SearchSubItemIndex = 0;
            this.cdvGrp1.SelectedDescIndex = -1;
            this.cdvGrp1.SelectedSubItemIndex = -1;
            this.cdvGrp1.SelectionStart = 0;
            this.cdvGrp1.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp1.SmallImageList = null;
            this.cdvGrp1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp1.TabIndex = 5;
            this.cdvGrp1.TextBoxToolTipText = "";
            this.cdvGrp1.TextBoxWidth = 200;
            this.cdvGrp1.VisibleButton = true;
            this.cdvGrp1.VisibleColumnHeader = false;
            this.cdvGrp1.VisibleDescription = false;
            this.cdvGrp1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGrp1_SelectedItemChanged);
            this.cdvGrp1.ButtonPress += new System.EventHandler(this.cdvGrp1_ButtonPress);
            this.cdvGrp1.TextBoxTextChanged += new System.EventHandler(this.cdvGrp1_TextBoxTextChanged);
            // 
            // lblPrt1
            // 
            this.lblPrt1.AutoSize = true;
            this.lblPrt1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrt1.Location = new System.Drawing.Point(15, 43);
            this.lblPrt1.Name = "lblPrt1";
            this.lblPrt1.Size = new System.Drawing.Size(72, 13);
            this.lblPrt1.TabIndex = 2;
            this.lblPrt1.Text = "Group Prompt";
            // 
            // lblGrp1
            // 
            this.lblGrp1.AutoSize = true;
            this.lblGrp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp1.Location = new System.Drawing.Point(400, 43);
            this.lblGrp1.Name = "lblGrp1";
            this.lblGrp1.Size = new System.Drawing.Size(67, 13);
            this.lblGrp1.TabIndex = 4;
            this.lblGrp1.Text = "Event Group";
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
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
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
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
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // cboGrp3
            // 
            this.cboGrp3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboGrp3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrp3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboGrp3.Location = new System.Drawing.Point(540, 100);
            this.cboGrp3.Name = "cboGrp3";
            this.cboGrp3.Size = new System.Drawing.Size(171, 21);
            this.cboGrp3.TabIndex = 8;
            this.cboGrp3.TabStop = false;
            this.cboGrp3.Visible = false;
            // 
            // cboGrp2
            // 
            this.cboGrp2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboGrp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrp2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboGrp2.Location = new System.Drawing.Point(276, 100);
            this.cboGrp2.Name = "cboGrp2";
            this.cboGrp2.Size = new System.Drawing.Size(171, 21);
            this.cboGrp2.TabIndex = 6;
            this.cboGrp2.TabStop = false;
            this.cboGrp2.Visible = false;
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Location = new System.Drawing.Point(15, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(53, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource";
            // 
            // cdvPrt1
            // 
            this.cdvPrt1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrt1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrt1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrt1.BtnToolTipText = "";
            this.cdvPrt1.DescText = "";
            this.cdvPrt1.DisplaySubItemIndex = -1;
            this.cdvPrt1.DisplayText = "";
            this.cdvPrt1.Focusing = null;
            this.cdvPrt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrt1.Index = 0;
            this.cdvPrt1.IsViewBtnImage = false;
            this.cdvPrt1.Location = new System.Drawing.Point(120, 40);
            this.cdvPrt1.MaxLength = 30;
            this.cdvPrt1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrt1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrt1.Name = "cdvPrt1";
            this.cdvPrt1.ReadOnly = true;
            this.cdvPrt1.SearchSubItemIndex = 0;
            this.cdvPrt1.SelectedDescIndex = -1;
            this.cdvPrt1.SelectedSubItemIndex = -1;
            this.cdvPrt1.SelectionStart = 0;
            this.cdvPrt1.Size = new System.Drawing.Size(200, 20);
            this.cdvPrt1.SmallImageList = null;
            this.cdvPrt1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrt1.TabIndex = 3;
            this.cdvPrt1.TextBoxToolTipText = "";
            this.cdvPrt1.TextBoxWidth = 200;
            this.cdvPrt1.VisibleButton = true;
            this.cdvPrt1.VisibleColumnHeader = false;
            this.cdvPrt1.VisibleDescription = false;
            this.cdvPrt1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPrt1_SelectedItemChanged);
            this.cdvPrt1.ButtonPress += new System.EventHandler(this.cdvPrt1_ButtonPress);
            // 
            // cdvGrp2
            // 
            this.cdvGrp2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp2.BtnToolTipText = "";
            this.cdvGrp2.DescText = "";
            this.cdvGrp2.DisplaySubItemIndex = -1;
            this.cdvGrp2.DisplayText = "";
            this.cdvGrp2.Focusing = null;
            this.cdvGrp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp2.Index = 0;
            this.cdvGrp2.IsViewBtnImage = false;
            this.cdvGrp2.Location = new System.Drawing.Point(276, 128);
            this.cdvGrp2.MaxLength = 30;
            this.cdvGrp2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp2.Name = "cdvGrp2";
            this.cdvGrp2.ReadOnly = false;
            this.cdvGrp2.SearchSubItemIndex = 0;
            this.cdvGrp2.SelectedDescIndex = -1;
            this.cdvGrp2.SelectedSubItemIndex = -1;
            this.cdvGrp2.SelectionStart = 0;
            this.cdvGrp2.Size = new System.Drawing.Size(171, 20);
            this.cdvGrp2.SmallImageList = null;
            this.cdvGrp2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp2.TabIndex = 7;
            this.cdvGrp2.TabStop = false;
            this.cdvGrp2.TextBoxToolTipText = "";
            this.cdvGrp2.TextBoxWidth = 171;
            this.cdvGrp2.Visible = false;
            this.cdvGrp2.VisibleButton = true;
            this.cdvGrp2.VisibleColumnHeader = false;
            this.cdvGrp2.VisibleDescription = false;
            // 
            // cdvGrp3
            // 
            this.cdvGrp3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp3.BtnToolTipText = "";
            this.cdvGrp3.DescText = "";
            this.cdvGrp3.DisplaySubItemIndex = -1;
            this.cdvGrp3.DisplayText = "";
            this.cdvGrp3.Focusing = null;
            this.cdvGrp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp3.Index = 0;
            this.cdvGrp3.IsViewBtnImage = false;
            this.cdvGrp3.Location = new System.Drawing.Point(540, 128);
            this.cdvGrp3.MaxLength = 30;
            this.cdvGrp3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp3.Name = "cdvGrp3";
            this.cdvGrp3.ReadOnly = false;
            this.cdvGrp3.SearchSubItemIndex = 0;
            this.cdvGrp3.SelectedDescIndex = -1;
            this.cdvGrp3.SelectedSubItemIndex = -1;
            this.cdvGrp3.SelectionStart = 0;
            this.cdvGrp3.Size = new System.Drawing.Size(171, 20);
            this.cdvGrp3.SmallImageList = null;
            this.cdvGrp3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp3.TabIndex = 9;
            this.cdvGrp3.TabStop = false;
            this.cdvGrp3.TextBoxToolTipText = "";
            this.cdvGrp3.TextBoxWidth = 171;
            this.cdvGrp3.Visible = false;
            this.cdvGrp3.VisibleButton = true;
            this.cdvGrp3.VisibleColumnHeader = false;
            this.cdvGrp3.VisibleDescription = false;
            // 
            // pnlEvent
            // 
            this.pnlEvent.Controls.Add(this.spdEvent);
            this.pnlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEvent.Location = new System.Drawing.Point(0, 71);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlEvent.Size = new System.Drawing.Size(742, 435);
            this.pnlEvent.TabIndex = 1;
            // 
            // spdEvent
            // 
            this.spdEvent.AccessibleDescription = "";
            this.spdEvent.ContextMenu = this.ctxCopyMenu;
            this.spdEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdEvent.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdEvent.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEvent.HorizontalScrollBar.Name = "";
            this.spdEvent.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdEvent.HorizontalScrollBar.TabIndex = 2;
            this.spdEvent.Location = new System.Drawing.Point(3, 5);
            this.spdEvent.Name = "spdEvent";
            this.spdEvent.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdEvent.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdEvent.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdEvent_Sheet1});
            this.spdEvent.Size = new System.Drawing.Size(736, 427);
            this.spdEvent.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdEvent.TabIndex = 0;
            this.spdEvent.TabStop = false;
            this.spdEvent.TextTipDelay = 200;
            this.spdEvent.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdEvent.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEvent.VerticalScrollBar.Name = "";
            this.spdEvent.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdEvent.VerticalScrollBar.TabIndex = 3;
            this.spdEvent.SetActiveViewport(0, -1, -1);
            // 
            // ctxCopyMenu
            // 
            this.ctxCopyMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctxCopy});
            // 
            // ctxCopy
            // 
            this.ctxCopy.Index = 0;
            this.ctxCopy.Text = "Copy";
            this.ctxCopy.Click += new System.EventHandler(this.ctxCopy_Click);
            // 
            // spdEvent_Sheet1
            // 
            this.spdEvent_Sheet1.Reset();
            spdEvent_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdEvent_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdEvent_Sheet1.ColumnCount = 63;
            spdEvent_Sheet1.RowCount = 0;
            this.spdEvent_Sheet1.ActiveColumnIndex = -1;
            this.spdEvent_Sheet1.ActiveRowIndex = -1;
            this.spdEvent_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdEvent_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Event ID";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "System Flag";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Check Up Down Flag";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Check Up Down";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Change Up Down Flag";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Change Up Down";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Primary Check Flag";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Primary Check Status";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Primary Change Flag";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Primary Change Status";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Primary GCM Table";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Check Flag1";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Check Status1";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Change Flag1";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Change Status1";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "GCM Table1";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Check Flag2";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Check Status2";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Change Flag2";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Change Status2";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "GCM Table2";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Check Flag3";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Check Status3";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Change Flag3";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Change Status3";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "GCM Table3";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Check Flag4";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Check Status4";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Change Flag4";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Change Status4";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "GCM Table4";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Check Flag5";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Check Status5";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Change Flag5";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Change Status5";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "GCM Table5";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Check Flag6";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Check Status6";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Change Flag6";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Change Status6";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "GCM Table6";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Check Flag7";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Check Status7";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Change Flag7";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Change Status7";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "GCM Table7";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Check Flag8";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Check Status8";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Change Flag8";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Change Status8";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "GCM Table8";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Check Flag9";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Check Status9";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Change Flag9";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Change Status9";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "GCM Table9";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Check Flag10";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Check Status10";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Change Flag10";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Change Status10";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "GCM Table10";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Col Set ID";
            this.spdEvent_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdEvent_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdEvent_Sheet1.Columns.Get(0).Label = "Event ID";
            this.spdEvent_Sheet1.Columns.Get(0).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(0).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(1).Label = "Description";
            this.spdEvent_Sheet1.Columns.Get(1).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(1).Width = 120F;
            this.spdEvent_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(2).Label = "System Flag";
            this.spdEvent_Sheet1.Columns.Get(2).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(2).Width = 78F;
            this.spdEvent_Sheet1.Columns.Get(3).Label = "Check Up Down Flag";
            this.spdEvent_Sheet1.Columns.Get(3).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(3).Width = 116F;
            this.spdEvent_Sheet1.Columns.Get(4).Label = "Check Up Down";
            this.spdEvent_Sheet1.Columns.Get(4).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(4).Width = 90F;
            this.spdEvent_Sheet1.Columns.Get(5).Label = "Change Up Down Flag";
            this.spdEvent_Sheet1.Columns.Get(5).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(5).Width = 126F;
            this.spdEvent_Sheet1.Columns.Get(6).Label = "Change Up Down";
            this.spdEvent_Sheet1.Columns.Get(6).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(6).Width = 98F;
            this.spdEvent_Sheet1.Columns.Get(7).Label = "Primary Check Flag";
            this.spdEvent_Sheet1.Columns.Get(7).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(7).Width = 120F;
            this.spdEvent_Sheet1.Columns.Get(8).Label = "Primary Check Status";
            this.spdEvent_Sheet1.Columns.Get(8).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(8).Width = 132F;
            this.spdEvent_Sheet1.Columns.Get(9).Label = "Primary Change Flag";
            this.spdEvent_Sheet1.Columns.Get(9).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(9).Width = 117F;
            this.spdEvent_Sheet1.Columns.Get(10).Label = "Primary Change Status";
            this.spdEvent_Sheet1.Columns.Get(10).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(10).Width = 125F;
            this.spdEvent_Sheet1.Columns.Get(11).Label = "Primary GCM Table";
            this.spdEvent_Sheet1.Columns.Get(11).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(11).Width = 130F;
            this.spdEvent_Sheet1.Columns.Get(12).Label = "Check Flag1";
            this.spdEvent_Sheet1.Columns.Get(12).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(12).Width = 80F;
            this.spdEvent_Sheet1.Columns.Get(13).Label = "Check Status1";
            this.spdEvent_Sheet1.Columns.Get(13).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(13).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(14).Label = "Change Flag1";
            this.spdEvent_Sheet1.Columns.Get(14).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(14).Width = 81F;
            this.spdEvent_Sheet1.Columns.Get(15).Label = "Change Status1";
            this.spdEvent_Sheet1.Columns.Get(15).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(15).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(16).Label = "GCM Table1";
            this.spdEvent_Sheet1.Columns.Get(16).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(16).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(17).Label = "Check Flag2";
            this.spdEvent_Sheet1.Columns.Get(17).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(17).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(18).Label = "Check Status2";
            this.spdEvent_Sheet1.Columns.Get(18).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(18).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(19).Label = "Change Flag2";
            this.spdEvent_Sheet1.Columns.Get(19).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(19).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(20).Label = "Change Status2";
            this.spdEvent_Sheet1.Columns.Get(20).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(20).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(21).Label = "GCM Table2";
            this.spdEvent_Sheet1.Columns.Get(21).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(21).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(22).Label = "Check Flag3";
            this.spdEvent_Sheet1.Columns.Get(22).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(22).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(23).Label = "Check Status3";
            this.spdEvent_Sheet1.Columns.Get(23).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(23).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(24).Label = "Change Flag3";
            this.spdEvent_Sheet1.Columns.Get(24).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(24).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(25).Label = "Change Status3";
            this.spdEvent_Sheet1.Columns.Get(25).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(25).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(26).Label = "GCM Table3";
            this.spdEvent_Sheet1.Columns.Get(26).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(26).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(27).Label = "Check Flag4";
            this.spdEvent_Sheet1.Columns.Get(27).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(27).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(28).Label = "Check Status4";
            this.spdEvent_Sheet1.Columns.Get(28).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(28).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(29).Label = "Change Flag4";
            this.spdEvent_Sheet1.Columns.Get(29).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(29).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(30).Label = "Change Status4";
            this.spdEvent_Sheet1.Columns.Get(30).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(30).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(31).Label = "GCM Table4";
            this.spdEvent_Sheet1.Columns.Get(31).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(31).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(32).Label = "Check Flag5";
            this.spdEvent_Sheet1.Columns.Get(32).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(32).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(33).Label = "Check Status5";
            this.spdEvent_Sheet1.Columns.Get(33).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(33).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(34).Label = "Change Flag5";
            this.spdEvent_Sheet1.Columns.Get(34).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(34).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(35).Label = "Change Status5";
            this.spdEvent_Sheet1.Columns.Get(35).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(35).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(36).Label = "GCM Table5";
            this.spdEvent_Sheet1.Columns.Get(36).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(36).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(37).Label = "Check Flag6";
            this.spdEvent_Sheet1.Columns.Get(37).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(37).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(38).Label = "Check Status6";
            this.spdEvent_Sheet1.Columns.Get(38).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(38).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(39).Label = "Change Flag6";
            this.spdEvent_Sheet1.Columns.Get(39).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(39).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(40).Label = "Change Status6";
            this.spdEvent_Sheet1.Columns.Get(40).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(40).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(41).Label = "GCM Table6";
            this.spdEvent_Sheet1.Columns.Get(41).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(41).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(42).Label = "Check Flag7";
            this.spdEvent_Sheet1.Columns.Get(42).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(42).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(43).Label = "Check Status7";
            this.spdEvent_Sheet1.Columns.Get(43).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(43).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(44).Label = "Change Flag7";
            this.spdEvent_Sheet1.Columns.Get(44).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(44).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(45).Label = "Change Status7";
            this.spdEvent_Sheet1.Columns.Get(45).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(45).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(46).Label = "GCM Table7";
            this.spdEvent_Sheet1.Columns.Get(46).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(46).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(47).Label = "Check Flag8";
            this.spdEvent_Sheet1.Columns.Get(47).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(47).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(48).Label = "Check Status8";
            this.spdEvent_Sheet1.Columns.Get(48).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(48).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(49).Label = "Change Flag8";
            this.spdEvent_Sheet1.Columns.Get(49).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(49).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(50).Label = "Change Status8";
            this.spdEvent_Sheet1.Columns.Get(50).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(50).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(51).Label = "GCM Table8";
            this.spdEvent_Sheet1.Columns.Get(51).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(51).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(52).Label = "Check Flag9";
            this.spdEvent_Sheet1.Columns.Get(52).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(52).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(53).Label = "Check Status9";
            this.spdEvent_Sheet1.Columns.Get(53).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(53).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(54).Label = "Change Flag9";
            this.spdEvent_Sheet1.Columns.Get(54).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(54).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(55).Label = "Change Status9";
            this.spdEvent_Sheet1.Columns.Get(55).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(55).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(56).Label = "GCM Table9";
            this.spdEvent_Sheet1.Columns.Get(56).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(56).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(57).Label = "Check Flag10";
            this.spdEvent_Sheet1.Columns.Get(57).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(57).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(58).Label = "Check Status10";
            this.spdEvent_Sheet1.Columns.Get(58).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(58).Width = 105F;
            this.spdEvent_Sheet1.Columns.Get(59).Label = "Change Flag10";
            this.spdEvent_Sheet1.Columns.Get(59).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(59).Width = 84F;
            this.spdEvent_Sheet1.Columns.Get(60).Label = "Change Status10";
            this.spdEvent_Sheet1.Columns.Get(60).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(60).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(61).Label = "GCM Table10";
            this.spdEvent_Sheet1.Columns.Get(61).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(61).Width = 100F;
            this.spdEvent_Sheet1.Columns.Get(62).Label = "Col Set ID";
            this.spdEvent_Sheet1.Columns.Get(62).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.Columns.Get(62).Width = 100F;
            this.spdEvent_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdEvent_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdEvent_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdEvent_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdEvent_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(10, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmRASViewEventByGroup
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlEvent);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmRASViewEventByGroup";
            this.Text = "View Event By Group";
            this.Activated += new System.EventHandler(this.frmRASViewEventByGroup_Activated);
            this.Load += new System.EventHandler(this.frmRASViewEventByGroup_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlEvent, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp3)).EndInit();
            this.pnlEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEvent_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable definition "
        string[] sGrpTableName = new string[10];
        bool b_load_flag;
        #endregion
        
        #region " Event definition "
        private void frmRASViewEventByGroup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdEvent, true);
                MPCF.FitColumnHeader(spdEvent);
                
                spdEvent.Sheets[0].SetColumnAllowAutoSort(0, 63, true);
                MPCF.FitColumnHeader(spdEvent);
                SetGroupCmfItem();
                b_load_flag = true;
            }
        }
        
        private void frmRASViewEventByGroup_Load(object sender, System.EventArgs e)
        {
        }
        
        private void cdvGrp1_ButtonPress(System.Object sender, System.EventArgs e)
        {
            if (cdvPrt1.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvPrt1.Focus();
                cdvGrp1.IsPopup = false;
                return;
            }
            cdvGrp1.Init();
            MPCF.InitListView(cdvGrp1.GetListView);
            cdvGrp1.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvGrp1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvGrp1.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvGrp1.GetListView, '1', cdvPrt1.Text) == false)
            {
                return;
            }
            cdvGrp1.AddEmptyRow(1);
        }
        
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == true)
            {
                if (RASLIST.ViewEventByGrpList(spdEvent, '1', cdvResID.Text, cdvGrp1.Text, cdvPrt1.Text, "", "", "", "", null, "") == false)
                {
                    return;
                }
                MPCF.FitColumnHeader(spdEvent);
                
            }
        }
        
        private void cdvGrp1_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdEvent, true);
            if (CheckCondition("VIEW") == true)
            {
                if (RASLIST.ViewEventByGrpList(spdEvent, '1', cdvResID.Text, cdvGrp1.Text, cdvPrt1.Text, "", "", "", "", null, "") == false)
                {
                    return;
                }
                MPCF.FitColumnHeader(spdEvent);
                
            }
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvTemp.GetListView, false);
        }
        
        private void ctxCopy_Click(System.Object sender, System.EventArgs e)
        {
            spdEvent_Sheet1.ClipboardCopy();
        }
        private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdEvent, true);
        }
        private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (CheckCondition("VIEW") == true)
            {
                if (RASLIST.ViewEventByGrpList(spdEvent, '1', cdvResID.Text, cdvGrp1.Text, cdvPrt1.Text, "", "", "", "", null, "") == false)
                {
                    return;
                }
                MPCF.FitColumnHeader(spdEvent);
                
            }
        }
        private void cdvGrp1_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdEvent, true);
        }
        private void cdvPrt1_ButtonPress(object sender, System.EventArgs e)
        {
            SetGRPItem(sGrpTableName);
            cdvPrt1.AddEmptyRow(1);
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Resource ID : " + MPCF.Trim(cdvResID.Text);
            MPCF.ExportToExcel(spdEvent, this.Text, sCond);
            
        }
        
        private void cdvPrt1_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvGrp1.DisplayText = "";
            cdvGrp1.Text = "";
        }
        
        #endregion
        
        #region " Function definition "
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":
                    
                    if (cdvPrt1.Text != "" && cdvGrp1.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvGrp1.Focus();
                        return false;
                    }
                    if (cdvGrp1.Text != "" && cdvPrt1.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvPrt1.Focus();
                        return false;
                    }
                    break;
                    //If cboGrp2.Text <> "" And cdvGrp2.Text = "" Then
                    //    ShowMsgBox(GetMessage(108))
                    //    cdvGrp2.Focus()
                    //    Return False
                    //End If
                    //If cboGrp3.Text <> "" And cdvGrp3.Text = "" Then
                    //    ShowMsgBox(GetMessage(108))
                    //    cdvGrp3.Focus()
                    //    Return False
                    //End If
                    //If cdvGrp2.Text <> "" And cboGrp2.Text = "" Then
                    //    ShowMsgBox(GetMessage(108))
                    //    cboGrp2.Focus()
                    //    Return False
                    //End If
                    //If cdvGrp3.Text <> "" And cboGrp3.Text = "" Then
                    //    ShowMsgBox(GetMessage(108))
                    //    cboGrp3.Focus()
                    //    Return False
                    //End If
            }
            
            return true;
        }
        
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        private void SetGroupCmfItem()
        {
            
            sGrpTableName[0] = MPGC.MP_GCM_EVN_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_EVN_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_EVN_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_EVN_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_EVN_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_EVN_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_EVN_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_EVN_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_EVN_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_EVN_GRP_10;
        }
        
        // SetGRPItem()
        //       - Set Group  Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        public void SetGRPItem(params string[] sGrpTableName)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ListViewItem itmx = null;
            int i;

            try
            {
                cdvPrt1.Init();
                MPCF.InitListView(cdvPrt1.GetListView);
                cdvPrt1.Columns.Add("Group", 100, HorizontalAlignment.Left);
                cdvPrt1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvPrt1.SelectedSubItemIndex = 1;
                cdvPrt1.DisplaySubItemIndex = 0;

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_EVENT, ref  out_node, "", true) == false)
                {
                    return;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")), (int)SMALLICON_INDEX.IDX_CODE_DATA);

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")) == "")
                        {
                            itmx.SubItems.Add(sGrpTableName[i]);
                        }
                        else
                        {
                            itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                        }
                        cdvPrt1.Items.Add(itmx);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
        
    }
    
}
