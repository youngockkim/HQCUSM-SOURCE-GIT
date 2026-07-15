
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
//   File Name   : frmRASViewResourceByGroup.vb
//   Description : View Resource List By Group Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_Resource_Group()  :  View Resource group prompt and data
//       - CheckCondition()       :  Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-17 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports
namespace Miracom.RASCore
{
    public class frmRASViewResourceByGroup : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewResourceByGroup()
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
        private System.Windows.Forms.ComboBox cboGrp3;
        private System.Windows.Forms.ComboBox cboGrp2;
        private System.Windows.Forms.Label lblType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp3;
        private System.Windows.Forms.Panel pnlResList;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private FarPoint.Win.Spread.FpSpread spdRes;
        private FarPoint.Win.Spread.SheetView spdRes_Sheet1;
        private System.Windows.Forms.ContextMenu ctxCopyMenu;
        private System.Windows.Forms.MenuItem ctxCopy;
        public System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblPrt1;
        private System.Windows.Forms.Label lblGrp1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrt1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASViewResourceByGroup));
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvPrt1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboGrp3 = new System.Windows.Forms.ComboBox();
            this.cboGrp2 = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cdvGrp1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPrt1 = new System.Windows.Forms.Label();
            this.lblGrp1 = new System.Windows.Forms.Label();
            this.pnlResList = new System.Windows.Forms.Panel();
            this.spdRes = new FarPoint.Win.Spread.FpSpread();
            this.ctxCopyMenu = new System.Windows.Forms.ContextMenu();
            this.ctxCopy = new System.Windows.Forms.MenuItem();
            this.spdRes_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrp.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp3)).BeginInit();
            this.pnlResList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRes_Sheet1)).BeginInit();
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
            this.lblFormTitle.Text = "View Resource List by Group ";
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
            this.grpOption.Controls.Add(this.cdvPrt1);
            this.grpOption.Controls.Add(this.cdvType);
            this.grpOption.Controls.Add(this.cboGrp3);
            this.grpOption.Controls.Add(this.cboGrp2);
            this.grpOption.Controls.Add(this.lblType);
            this.grpOption.Controls.Add(this.cdvGrp1);
            this.grpOption.Controls.Add(this.cdvGrp2);
            this.grpOption.Controls.Add(this.cdvGrp3);
            this.grpOption.Controls.Add(this.lblPrt1);
            this.grpOption.Controls.Add(this.lblGrp1);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 71);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
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
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(120, 16);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(200, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 200;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvType_SelectedItemChanged);
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // cboGrp3
            // 
            this.cboGrp3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboGrp3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrp3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboGrp3.Location = new System.Drawing.Point(540, 88);
            this.cboGrp3.Name = "cboGrp3";
            this.cboGrp3.Size = new System.Drawing.Size(171, 21);
            this.cboGrp3.TabIndex = 7;
            this.cboGrp3.TabStop = false;
            this.cboGrp3.Visible = false;
            // 
            // cboGrp2
            // 
            this.cboGrp2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboGrp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrp2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboGrp2.Location = new System.Drawing.Point(276, 88);
            this.cboGrp2.Name = "cboGrp2";
            this.cboGrp2.Size = new System.Drawing.Size(171, 21);
            this.cboGrp2.TabIndex = 4;
            this.cboGrp2.TabStop = false;
            this.cboGrp2.Visible = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Location = new System.Drawing.Point(15, 19);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Resource Type";
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
            this.cdvGrp2.Location = new System.Drawing.Point(276, 116);
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
            this.cdvGrp2.TabIndex = 5;
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
            this.cdvGrp3.Location = new System.Drawing.Point(540, 116);
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
            this.cdvGrp3.TabIndex = 8;
            this.cdvGrp3.TabStop = false;
            this.cdvGrp3.TextBoxToolTipText = "";
            this.cdvGrp3.TextBoxWidth = 171;
            this.cdvGrp3.Visible = false;
            this.cdvGrp3.VisibleButton = true;
            this.cdvGrp3.VisibleColumnHeader = false;
            this.cdvGrp3.VisibleDescription = false;
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
            this.lblGrp1.Location = new System.Drawing.Point(404, 43);
            this.lblGrp1.Name = "lblGrp1";
            this.lblGrp1.Size = new System.Drawing.Size(85, 13);
            this.lblGrp1.TabIndex = 4;
            this.lblGrp1.Text = "Resource Group";
            // 
            // pnlResList
            // 
            this.pnlResList.Controls.Add(this.spdRes);
            this.pnlResList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResList.Location = new System.Drawing.Point(0, 71);
            this.pnlResList.Name = "pnlResList";
            this.pnlResList.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlResList.Size = new System.Drawing.Size(742, 435);
            this.pnlResList.TabIndex = 1;
            // 
            // spdRes
            // 
            this.spdRes.AccessibleDescription = "";
            this.spdRes.ContextMenu = this.ctxCopyMenu;
            this.spdRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdRes.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdRes.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdRes.HorizontalScrollBar.Name = "";
            this.spdRes.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdRes.HorizontalScrollBar.TabIndex = 2;
            this.spdRes.Location = new System.Drawing.Point(3, 5);
            this.spdRes.Name = "spdRes";
            this.spdRes.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdRes.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdRes.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdRes_Sheet1});
            this.spdRes.Size = new System.Drawing.Size(736, 427);
            this.spdRes.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdRes.TabIndex = 0;
            this.spdRes.TabStop = false;
            this.spdRes.TextTipDelay = 200;
            this.spdRes.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdRes.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdRes.VerticalScrollBar.Name = "";
            this.spdRes.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdRes.VerticalScrollBar.TabIndex = 3;
            this.spdRes.SetActiveViewport(0, -1, -1);
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
            // spdRes_Sheet1
            // 
            this.spdRes_Sheet1.Reset();
            spdRes_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdRes_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdRes_Sheet1.ColumnCount = 27;
            spdRes_Sheet1.RowCount = 0;
            this.spdRes_Sheet1.ActiveColumnIndex = -1;
            this.spdRes_Sheet1.ActiveRowIndex = -1;
            this.spdRes_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdRes_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Res ID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Res Desc";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Res Type";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Use Fac";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Area ID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Sub Area ID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Res Location";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Proc Rule";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Max Proc";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "PM Sch Enable";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Unit Base";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Sec Chk";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Create UserID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Create Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Update UserID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Update Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Up Down";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Primary Status";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Proc Mode";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Ctrl Mode";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Proc Count";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Last Start Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Last End Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Last Event";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Last Event Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Last Act Hist Seq";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Last Hist Seq";
            this.spdRes_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdRes_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdRes_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(0).Label = "Res ID";
            this.spdRes_Sheet1.Columns.Get(0).Locked = true;
            this.spdRes_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(0).Width = 100F;
            this.spdRes_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(1).Label = "Res Desc";
            this.spdRes_Sheet1.Columns.Get(1).Locked = true;
            this.spdRes_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(1).Width = 130F;
            this.spdRes_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(2).Label = "Res Type";
            this.spdRes_Sheet1.Columns.Get(2).Locked = true;
            this.spdRes_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(2).Width = 86F;
            this.spdRes_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(3).Label = "Use Fac";
            this.spdRes_Sheet1.Columns.Get(3).Locked = true;
            this.spdRes_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(3).Width = 54F;
            this.spdRes_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(4).Label = "Area ID";
            this.spdRes_Sheet1.Columns.Get(4).Locked = true;
            this.spdRes_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(4).Width = 80F;
            this.spdRes_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(5).Label = "Sub Area ID";
            this.spdRes_Sheet1.Columns.Get(5).Locked = true;
            this.spdRes_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(5).Width = 80F;
            this.spdRes_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(6).Label = "Res Location";
            this.spdRes_Sheet1.Columns.Get(6).Locked = true;
            this.spdRes_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(6).Width = 90F;
            this.spdRes_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(7).Label = "Proc Rule";
            this.spdRes_Sheet1.Columns.Get(7).Locked = true;
            this.spdRes_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(7).Width = 56F;
            this.spdRes_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdRes_Sheet1.Columns.Get(8).Label = "Max Proc";
            this.spdRes_Sheet1.Columns.Get(8).Locked = true;
            this.spdRes_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(8).Width = 59F;
            this.spdRes_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(9).Label = "PM Sch Enable";
            this.spdRes_Sheet1.Columns.Get(9).Locked = true;
            this.spdRes_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(9).Width = 90F;
            this.spdRes_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(10).Label = "Unit Base";
            this.spdRes_Sheet1.Columns.Get(10).Locked = true;
            this.spdRes_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(10).Width = 67F;
            this.spdRes_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(11).Label = "Sec Chk";
            this.spdRes_Sheet1.Columns.Get(11).Locked = true;
            this.spdRes_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(11).Width = 57F;
            this.spdRes_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(12).Label = "Create UserID";
            this.spdRes_Sheet1.Columns.Get(12).Locked = true;
            this.spdRes_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(12).Width = 80F;
            this.spdRes_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(13).Label = "Create Time";
            this.spdRes_Sheet1.Columns.Get(13).Locked = true;
            this.spdRes_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(13).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(14).Label = "Update UserID";
            this.spdRes_Sheet1.Columns.Get(14).Locked = true;
            this.spdRes_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(14).Width = 102F;
            this.spdRes_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(15).Label = "Update Time";
            this.spdRes_Sheet1.Columns.Get(15).Locked = true;
            this.spdRes_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(15).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(16).Label = "Up Down";
            this.spdRes_Sheet1.Columns.Get(16).Locked = true;
            this.spdRes_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(16).Width = 80F;
            this.spdRes_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(17).Label = "Primary Status";
            this.spdRes_Sheet1.Columns.Get(17).Locked = true;
            this.spdRes_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(17).Width = 81F;
            this.spdRes_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(18).Label = "Proc Mode";
            this.spdRes_Sheet1.Columns.Get(18).Locked = true;
            this.spdRes_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(18).Width = 76F;
            this.spdRes_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdRes_Sheet1.Columns.Get(20).Label = "Proc Count";
            this.spdRes_Sheet1.Columns.Get(20).Locked = true;
            this.spdRes_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(20).Width = 63F;
            this.spdRes_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(21).Label = "Last Start Time";
            this.spdRes_Sheet1.Columns.Get(21).Locked = true;
            this.spdRes_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(21).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(22).Label = "Last End Time";
            this.spdRes_Sheet1.Columns.Get(22).Locked = true;
            this.spdRes_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(22).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(23).Label = "Last Event";
            this.spdRes_Sheet1.Columns.Get(23).Locked = true;
            this.spdRes_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(23).Width = 100F;
            this.spdRes_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(24).Label = "Last Event Time";
            this.spdRes_Sheet1.Columns.Get(24).Locked = true;
            this.spdRes_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(24).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdRes_Sheet1.Columns.Get(25).Label = "Last Act Hist Seq";
            this.spdRes_Sheet1.Columns.Get(25).Locked = true;
            this.spdRes_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(25).Width = 102F;
            this.spdRes_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdRes_Sheet1.Columns.Get(26).Label = "Last Hist Seq";
            this.spdRes_Sheet1.Columns.Get(26).Locked = true;
            this.spdRes_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(26).Width = 84F;
            this.spdRes_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdRes_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdRes_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdRes_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdRes_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
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
            // frmRASViewResourceByGroup
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlResList);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmRASViewResourceByGroup";
            this.Text = "View Resource By Group";
            this.Activated += new System.EventHandler(this.frmRASViewResourceByGroup_Activated);
            this.Load += new System.EventHandler(this.frmRASViewResourceByGroup_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlResList, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp3)).EndInit();
            this.pnlResList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRes_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable definition "
        string[] sGrpTableName = new string[10];
        bool b_load_flag;
        #endregion
        
        #region " Event definition "
        
        private void frmRASViewResourceByGroup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdRes, true);
                MPCF.FitColumnHeader(spdRes);
                
                spdRes.Sheets[0].SetColumnAllowAutoSort(0, 28, true);
                MPCF.FitColumnHeader(spdRes);
                SetGroupCmfItem();
                b_load_flag = true;
            }
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
                if (RASLIST.ViewResourceListDetailByGroup(spdRes, '1', cdvType.Text, cdvGrp1.Text, cdvPrt1.Text, "", "", "", "", null, "") == false)
                {
                    return;
                }
                
                MPCF.FitColumnHeader(spdRes);
                
            }
        }
        
        private void cdvGrp1_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdRes, true);
            if (CheckCondition("VIEW") == true)
            {
                if (RASLIST.ViewResourceListDetailByGroup(spdRes, '1', cdvType.Text, cdvGrp1.Text, cdvPrt1.Text, "", "", "", "", null, "") == false)
                {
                    return;
                }
                MPCF.FitColumnHeader(spdRes);
                
            }
        }
        
        private void cdvType_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
            if (cdvTemp.AddEmptyRow(1) == false)
            {
                return;
            }
        }
        
        private void frmRASViewResourceByGroup_Load(object sender, System.EventArgs e)
        {
        }
        
        private void ctxCopy_Click(System.Object sender, System.EventArgs e)
        {
            spdRes_Sheet1.ClipboardCopy();
        }
        
        private void cdvPrt1_ButtonPress(object sender, System.EventArgs e)
        {
            SetGRPItem(sGrpTableName);
            cdvPrt1.AddEmptyRow(1);
        }
        
        private void cdvType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (CheckCondition("VIEW") == true)
            {
                if (RASLIST.ViewResourceListDetailByGroup(spdRes, '1', cdvType.Text, cdvGrp1.Text, cdvPrt1.Text, "", "", "", "", null, "") == false)
                {
                    return;
                }
                MPCF.FitColumnHeader(spdRes);
                
            }
        }
        
        private void cdvGrp1_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdRes, true);
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Resource Type : " + MPCF.Trim(cdvType.Text);
            MPCF.ExportToExcel(spdRes, this.Text, sCond);
            
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
        
        private void SetGroupCmfItem()
        {
            
            sGrpTableName[0] = MPGC.MP_GCM_RES_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_RES_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_RES_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_RES_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_RES_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_RES_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_RES_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_RES_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_RES_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_RES_GRP_10;
            
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

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_RESOURCE, ref out_node, "", true) == false)
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
                return this.cdvType;
                
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
