
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupRepairOper.vb
//   Description : Repair Operation Setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - GetSPOperList() : Get Operation List by Flow
//       - ViewRepairOperList() : Get Repair Operation List
//       - UpdateRepairOper() : Update Repair Operation
//       - SetSelectData() : Set Variable by Selected Row
//       - GetSelectData() : Get Variable by Selected Row
//       - FindTopRow() : ?ÑÏû¨ ?†ÌÉù??RowÎ•??¨Ìï®?òÎäî OperationÎ•?Í∞ÄÏß?RowÎ•?Ï∞æÎäî??
//       - FindOper() : ?ÑÏû¨ ?†ÌÉù??RowÎ•??¨Ìï®?òÎäî OperationÎ•?Ï∞æÎäî??
//       - GetOperList() : Get Oper List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-04-06 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPSetupRepairOper : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPSetupRepairOper()
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

        private System.ComponentModel.IContainer components;

        
        



        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ImageList imlSPIcons;
        private System.Windows.Forms.Panel pnlRepairOperSub;
        private System.Windows.Forms.Panel pnlRepairOperList;
        private FarPoint.Win.Spread.FpSpread spdOperationList;
        private FarPoint.Win.Spread.SheetView spdOperationList_Sheet1;
        private System.Windows.Forms.Panel pnlRepairDetail;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.GroupBox gpbRepairOperSub;
        private System.Windows.Forms.Label lblRetOper;
        public Miracom.UI.Controls.MCCodeView.MCCodeView cdvRepairOper;
        private System.Windows.Forms.Label lblRepairOper;
        public Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label lblOperation;
        public Miracom.UI.Controls.MCCodeView.MCCodeView cdvReturnOper;
        private System.Windows.Forms.GroupBox grbOperInfo;
        protected Button btnExcel;
        private System.Windows.Forms.Button btnRefresh;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupRepairOper));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.imlSPIcons = new System.Windows.Forms.ImageList(this.components);
            this.pnlRepairOperSub = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.grbOperInfo = new System.Windows.Forms.GroupBox();
            this.pnlRepairDetail = new System.Windows.Forms.Panel();
            this.gpbRepairOperSub = new System.Windows.Forms.GroupBox();
            this.cdvReturnOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRetOper = new System.Windows.Forms.Label();
            this.cdvRepairOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRepairOper = new System.Windows.Forms.Label();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.pnlRepairOperList = new System.Windows.Forms.Panel();
            this.spdOperationList = new FarPoint.Win.Spread.FpSpread();
            this.spdOperationList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlRepairOperSub.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.pnlRepairDetail.SuspendLayout();
            this.gpbRepairOperSub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReturnOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRepairOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            this.pnlRepairOperList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOperationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOperationList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Delete";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnAdd);
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnAdd, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlRepairOperList);
            this.pnlCenter.Controls.Add(this.pnlRepairOperSub);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Repair Operation Setup";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(466, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.Location = new System.Drawing.Point(466, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // imlSPIcons
            // 
            this.imlSPIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSPIcons.ImageStream")));
            this.imlSPIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSPIcons.Images.SetKeyName(0, "");
            this.imlSPIcons.Images.SetKeyName(1, "");
            this.imlSPIcons.Images.SetKeyName(2, "");
            this.imlSPIcons.Images.SetKeyName(3, "");
            // 
            // pnlRepairOperSub
            // 
            this.pnlRepairOperSub.Controls.Add(this.Panel1);
            this.pnlRepairOperSub.Controls.Add(this.pnlRepairDetail);
            this.pnlRepairOperSub.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlRepairOperSub.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRepairOperSub.Location = new System.Drawing.Point(461, 3);
            this.pnlRepairOperSub.Name = "pnlRepairOperSub";
            this.pnlRepairOperSub.Size = new System.Drawing.Size(278, 503);
            this.pnlRepairOperSub.TabIndex = 2;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.grbOperInfo);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 100);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(278, 403);
            this.Panel1.TabIndex = 1;
            // 
            // grbOperInfo
            // 
            this.grbOperInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbOperInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbOperInfo.Location = new System.Drawing.Point(0, 0);
            this.grbOperInfo.Name = "grbOperInfo";
            this.grbOperInfo.Size = new System.Drawing.Size(278, 403);
            this.grbOperInfo.TabIndex = 0;
            this.grbOperInfo.TabStop = false;
            // 
            // pnlRepairDetail
            // 
            this.pnlRepairDetail.Controls.Add(this.gpbRepairOperSub);
            this.pnlRepairDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRepairDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlRepairDetail.Name = "pnlRepairDetail";
            this.pnlRepairDetail.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlRepairDetail.Size = new System.Drawing.Size(278, 100);
            this.pnlRepairDetail.TabIndex = 0;
            // 
            // gpbRepairOperSub
            // 
            this.gpbRepairOperSub.Controls.Add(this.cdvReturnOper);
            this.gpbRepairOperSub.Controls.Add(this.lblRetOper);
            this.gpbRepairOperSub.Controls.Add(this.cdvRepairOper);
            this.gpbRepairOperSub.Controls.Add(this.lblRepairOper);
            this.gpbRepairOperSub.Controls.Add(this.cdvOperation);
            this.gpbRepairOperSub.Controls.Add(this.lblOperation);
            this.gpbRepairOperSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbRepairOperSub.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpbRepairOperSub.Location = new System.Drawing.Point(3, 0);
            this.gpbRepairOperSub.Name = "gpbRepairOperSub";
            this.gpbRepairOperSub.Size = new System.Drawing.Size(275, 100);
            this.gpbRepairOperSub.TabIndex = 0;
            this.gpbRepairOperSub.TabStop = false;
            // 
            // cdvReturnOper
            // 
            this.cdvReturnOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReturnOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReturnOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvReturnOper.BtnToolTipText = "";
            this.cdvReturnOper.DescText = "";
            this.cdvReturnOper.DisplaySubItemIndex = -1;
            this.cdvReturnOper.DisplayText = "";
            this.cdvReturnOper.Focusing = null;
            this.cdvReturnOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnOper.Index = 0;
            this.cdvReturnOper.IsViewBtnImage = false;
            this.cdvReturnOper.Location = new System.Drawing.Point(126, 64);
            this.cdvReturnOper.MaxLength = 10;
            this.cdvReturnOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvReturnOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvReturnOper.Name = "cdvReturnOper";
            this.cdvReturnOper.ReadOnly = false;
            this.cdvReturnOper.SearchSubItemIndex = 0;
            this.cdvReturnOper.SelectedDescIndex = -1;
            this.cdvReturnOper.SelectedSubItemIndex = -1;
            this.cdvReturnOper.SelectionStart = 0;
            this.cdvReturnOper.Size = new System.Drawing.Size(138, 20);
            this.cdvReturnOper.SmallImageList = null;
            this.cdvReturnOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvReturnOper.TabIndex = 5;
            this.cdvReturnOper.TextBoxToolTipText = "";
            this.cdvReturnOper.TextBoxWidth = 138;
            this.cdvReturnOper.VisibleButton = true;
            this.cdvReturnOper.VisibleColumnHeader = false;
            this.cdvReturnOper.VisibleDescription = false;
            this.cdvReturnOper.ButtonPress += new System.EventHandler(this.cdvReturnOper_ButtonPress);
            // 
            // lblRetOper
            // 
            this.lblRetOper.AutoSize = true;
            this.lblRetOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetOper.Location = new System.Drawing.Point(15, 67);
            this.lblRetOper.Name = "lblRetOper";
            this.lblRetOper.Size = new System.Drawing.Size(65, 13);
            this.lblRetOper.TabIndex = 4;
            this.lblRetOper.Text = "Return Oper";
            this.lblRetOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvRepairOper
            // 
            this.cdvRepairOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRepairOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRepairOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRepairOper.BtnToolTipText = "";
            this.cdvRepairOper.DescText = "";
            this.cdvRepairOper.DisplaySubItemIndex = -1;
            this.cdvRepairOper.DisplayText = "";
            this.cdvRepairOper.Focusing = null;
            this.cdvRepairOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRepairOper.Index = 0;
            this.cdvRepairOper.IsViewBtnImage = false;
            this.cdvRepairOper.Location = new System.Drawing.Point(126, 40);
            this.cdvRepairOper.MaxLength = 10;
            this.cdvRepairOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRepairOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRepairOper.Name = "cdvRepairOper";
            this.cdvRepairOper.ReadOnly = false;
            this.cdvRepairOper.SearchSubItemIndex = 0;
            this.cdvRepairOper.SelectedDescIndex = -1;
            this.cdvRepairOper.SelectedSubItemIndex = -1;
            this.cdvRepairOper.SelectionStart = 0;
            this.cdvRepairOper.Size = new System.Drawing.Size(138, 20);
            this.cdvRepairOper.SmallImageList = null;
            this.cdvRepairOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRepairOper.TabIndex = 3;
            this.cdvRepairOper.TextBoxToolTipText = "";
            this.cdvRepairOper.TextBoxWidth = 138;
            this.cdvRepairOper.VisibleButton = true;
            this.cdvRepairOper.VisibleColumnHeader = false;
            this.cdvRepairOper.VisibleDescription = false;
            this.cdvRepairOper.ButtonPress += new System.EventHandler(this.cdvRepairOper_ButtonPress);
            // 
            // lblRepairOper
            // 
            this.lblRepairOper.AutoSize = true;
            this.lblRepairOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRepairOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepairOper.Location = new System.Drawing.Point(15, 43);
            this.lblRepairOper.Name = "lblRepairOper";
            this.lblRepairOper.Size = new System.Drawing.Size(64, 13);
            this.lblRepairOper.TabIndex = 2;
            this.lblRepairOper.Text = "Repair Oper";
            this.lblRepairOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(126, 16);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = true;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(138, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 1;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 138;
            this.cdvOperation.VisibleButton = false;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(15, 19);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(53, 13);
            this.lblOperation.TabIndex = 0;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRepairOperList
            // 
            this.pnlRepairOperList.Controls.Add(this.spdOperationList);
            this.pnlRepairOperList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRepairOperList.Location = new System.Drawing.Point(3, 3);
            this.pnlRepairOperList.Name = "pnlRepairOperList";
            this.pnlRepairOperList.Size = new System.Drawing.Size(458, 503);
            this.pnlRepairOperList.TabIndex = 1;
            // 
            // spdOperationList
            // 
            this.spdOperationList.AccessibleDescription = "";
            this.spdOperationList.BackColor = System.Drawing.SystemColors.Control;
            this.spdOperationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOperationList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdOperationList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOperationList.HorizontalScrollBar.Name = "";
            this.spdOperationList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdOperationList.HorizontalScrollBar.TabIndex = 2;
            this.spdOperationList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOperationList.Location = new System.Drawing.Point(0, 0);
            this.spdOperationList.Name = "spdOperationList";
            this.spdOperationList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOperationList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOperationList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOperationList_Sheet1});
            this.spdOperationList.Size = new System.Drawing.Size(458, 503);
            this.spdOperationList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOperationList.TabIndex = 0;
            this.spdOperationList.TextTipDelay = 200;
            this.spdOperationList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOperationList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOperationList.VerticalScrollBar.Name = "";
            this.spdOperationList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdOperationList.VerticalScrollBar.TabIndex = 3;
            this.spdOperationList.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdOperationList_CellClick);
            // 
            // spdOperationList_Sheet1
            // 
            this.spdOperationList_Sheet1.Reset();
            spdOperationList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOperationList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOperationList_Sheet1.ColumnCount = 5;
            spdOperationList_Sheet1.ColumnHeader.RowCount = 2;
            spdOperationList_Sheet1.RowCount = 5;
            this.spdOperationList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperationList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOperationList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperationList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Operation";
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 3;
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Operation Desc";
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Level";
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(1, 2).Value = "Level";
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(1, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(1, 3).Value = "Repair Oper";
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(1, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(1, 4).Value = "Return Oper";
            this.spdOperationList_Sheet1.ColumnHeader.Cells.Get(1, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOperationList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperationList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOperationList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOperationList_Sheet1.Columns.Get(0).Locked = true;
            this.spdOperationList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOperationList_Sheet1.Columns.Get(0).Width = 23F;
            this.spdOperationList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOperationList_Sheet1.Columns.Get(1).Locked = true;
            this.spdOperationList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOperationList_Sheet1.Columns.Get(1).Width = 49F;
            this.spdOperationList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOperationList_Sheet1.Columns.Get(2).Label = "Level";
            this.spdOperationList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOperationList_Sheet1.Columns.Get(2).Width = 62F;
            this.spdOperationList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOperationList_Sheet1.Columns.Get(3).Label = "Repair Oper";
            this.spdOperationList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOperationList_Sheet1.Columns.Get(3).Width = 140F;
            this.spdOperationList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOperationList_Sheet1.Columns.Get(4).Label = "Return Oper";
            this.spdOperationList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOperationList_Sheet1.Columns.Get(4).Width = 140F;
            this.spdOperationList_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdOperationList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdOperationList_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdOperationList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperationList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOperationList_Sheet1.RowHeader.Visible = false;
            this.spdOperationList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdOperationList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdOperationList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperationList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOperationList_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdOperationList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdOperationList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(10, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(40, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmWIPSetupRepairOper
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupRepairOper";
            this.Text = "Repair Operation Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupRepairOper_Activated);
            this.Load += new System.EventHandler(this.frmWIPSetupRepairOper_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlRepairOperSub.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.pnlRepairDetail.ResumeLayout(false);
            this.gpbRepairOperSub.ResumeLayout(false);
            this.gpbRepairOperSub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReturnOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRepairOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            this.pnlRepairOperList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOperationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOperationList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool LoadFlag;
        private string SelOOper = "";
        private string SelOOperDesc = "";
        private string SelORepOper = "";
        private string SelORetOper = "";
        private int PrevSelOCol = - 1;
        private int PrevSelORow = - 1;
        private FarPoint.Win.Spread.CellType.GeneralCellType plusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType minusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType emptyCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType checkCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        
        private enum CELL_STATUS
        {
            PLUS = 1,
            MINUS = 2,
            EMPTY = 3,
            CHECK = 4
        }
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            
            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":
                    
                    if (SelOOper == "")
                    {
                        return false;
                    }
                    break;
                case "UPDATE":
                    
                    if (SelOOper == "" || SelORepOper == "")
                    {
                        return false;
                    }
                    break;
                case "DELETE":
                    
                    if (SelOOper == "" || SelORepOper == "")
                    {
                        return false;
                    }
                    break;
            }
            
            if (cdvRepairOper.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvRepairOper.Focus();
                return false;
            }
            if (cdvOperation.Text == MPCF.Trim(cdvRepairOper.Text))
            {
                MPCF.ShowMsgBox("Repair Operation???ÑÏû¨  OperationÍ≥?Í∞ôÏäµ?àÎã§.");
                cdvRepairOper.Focus();
                return false;
            }
            
            return true;
            
        }
        
        //
        // GetSPOperList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal spdList As FarPoint.Win.Spread.SheetView : SpreadSheet
        //
        private bool GetSPOperList(FarPoint.Win.Spread.SheetView spdList)
        {
            int i = 0;
            int iRowCount = - 1;

            TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            spdList.RowCount = 0;

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdList.RowCount += out_node.GetList(0).Count;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRowCount++;
                    spdList.Cells[iRowCount, 0].CellType = plusCellType;
                    spdList.Cells[iRowCount, 0].Tag = CELL_STATUS.PLUS;
                    spdList.Cells[iRowCount, 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPER"));
                    spdList.Cells[iRowCount, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC"));
                    spdList.AddSpanCell(iRowCount, 2, 1, 5);
                }

                in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));
            } while (in_node.GetString("NEXT_OPER") != "");

            spdList.Columns[1].Border = new FarPoint.Win.LineBorder(SystemColors.Control, 1, false, false, true, false);
            spdList.Columns[2].Border = new FarPoint.Win.LineBorder(SystemColors.Control, 1, false, false, true, false);

            return true;

        }

        //
        // ViewRepairOperList()
        //       - Get Repair Oper List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal spdList As FarPoint.Win.Spread.SheetView : SpreadSheet
        //       - ByVal iRow As Integer : Parent Row of Selected Row
        //       - ByVal sOper As String : Operation
        //
        public bool ViewRepairOperList(FarPoint.Win.Spread.SheetView spdList, int iRow, char c_step, string sOper)
        {

            int i;
            int j;
            int iInsertedRow = iRow;
            int iInsertedRowCnt = 0;

            TRSNode in_node = new TRSNode("VIEW_REPAIR_OPER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REPAIR_OPER_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("OPER", MPCF.Trim(sOper));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Repair_Oper_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iInsertedRowCnt++;
                    iInsertedRow++;
                    spdList.AddRows(iInsertedRow, 1);
                    spdList.Cells[iInsertedRow, 0].CellType = emptyCellType;
                    spdList.Cells[iInsertedRow, 0].Tag = CELL_STATUS.EMPTY;
                    spdList.Cells[iInsertedRow, 3].Value = out_node.GetList(0)[i].GetString("REP_OPER");
                    spdList.Cells[iInsertedRow, 3].Tag = out_node.GetList(0)[i].GetString("REP_OPER");
                    spdList.Cells[iInsertedRow, 4].Value = out_node.GetList(0)[i].GetString("RET_OPER");
                    spdList.Cells[iInsertedRow, 4].Tag = out_node.GetList(0)[i].GetString("RET_OPER");
                }

                in_node.SetString("NEXT_REP_OPER", out_node.GetString("NEXT_REP_OPER"));

            } while (in_node.GetString("NEXT_REP_OPER") != "");

            for (i = iRow + 1; i <= iRow + iInsertedRowCnt; i++)
            {
                for (j = 1; j <= spdList.Columns.Count - 1; j++)
                {
                    if (j < 4 || j % 2 == 1)
                    {
                        spdList.Cells[i, j].Border = new FarPoint.Win.LineBorder(SystemColors.Control, 1, false, false, true, false);
                    }
                }
            }

            if (iRow <= PrevSelORow)
            {
                PrevSelORow += iInsertedRowCnt;
            }

            return true;

        }

        //
        // UpdateRepairOper()
        //       - Update Repair Oper
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal proc_step As String : Process Step
        //       - ByVal sOper As String : Operation
        //       - ByVal sRepOper As String : Repair Operation
        //       - ByVal sRetOper As String : Return Operation
        //
        private bool UpdateRepairOper(char proc_step, string sOper, string sRepOper, string sRetOper)
        {

            TRSNode in_node = new TRSNode("UPDATE_REPAIR_OPER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = proc_step;

            //in_node.Add("OPT_LEVEL", "O");
            in_node.AddString("OPER", MPCF.Trim(sOper));
            in_node.AddString("REP_OPER", MPCF.Trim(sRepOper));
            in_node.AddString("RET_OPER", MPCF.Trim(sRetOper));

            if (MPCR.CallService("WIP", "WIP_Update_Repair_Oper", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;

        }

        
        //
        // SetSelectData()
        //       - Set Variable by Selected Row
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sOper As String : Operation
        //       - ByVal sRepOper As String : Repair Operation
        //       - ByVal sRetOper As String : Return Operation
        //
        private bool SetSelectData(string sOper, string sRepOper, string sRetOper)
        {
            
            SelOOper = sOper;
            SelORepOper = sRepOper;
            SelORetOper = sRetOper;
            return true;
        }
        
        
        //
        // GetSelectData()
        //       - Get Variable by Selected Row
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal spdList As FarPoint.Win.Spread.SheetView : SpreadSheet
        //       - ByVal iSelRow As Integer : Selected Row
        //
        private bool GetSelectData(FarPoint.Win.Spread.SheetView spdList, int iSelRow)
        {
            
            FindOper(spdList, iSelRow);
            if (iSelRow < spdList.RowCount)
            {
                if (MPCF.ToInt(spdList.Cells[iSelRow, 0].Tag) == (int)CELL_STATUS.CHECK ||
                    MPCF.ToInt(spdList.Cells[iSelRow, 0].Tag) == (int)CELL_STATUS.EMPTY)
                {
                    
                    SelORepOper = MPCF.Trim(spdList.Cells[iSelRow, 3].Tag);
                    SelORetOper = MPCF.Trim(spdList.Cells[iSelRow, 4].Tag);
                    
                }
                
                return true;
            }
            
            SelORepOper = "";
            SelORetOper = "";
            
            return true;
            
        }
        
        //
        // FindTopRow()
        //       - ?ÑÏû¨ ?†ÌÉù??RowÎ•??¨Ìï®?òÎäî OperationÎ•?Í∞ÄÏß?RowÎ•?Ï∞æÎäî??
        // Return Value
        //       - Integer : Finded Row
        // Arguments
        //       - ByVal spdList As FarPoint.Win.Spread.SheetView : SpreadSheet
        //       - ByVal iRow As Integer : Selected Row
        //
        private int FindTopRow(FarPoint.Win.Spread.SheetView spdList, string iRow)
        {
            
            int i;
            i = MPCF.ToInt(iRow);
            while (i >= 0 && i < spdList.RowCount)
            {
                if (MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.MINUS ||
                    MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.PLUS)
                {
                    return i;
                }
                i--;
            }
            
            return - 1;
            
        }

        //
        // FindTopRow()
        //       - ?ÑÏû¨ ?†ÌÉù??RowÎ•??¨Ìï®?òÎäî OperationÎ•?Í∞ÄÏß?RowÎ•?Ï∞æÎäî??
        // Return Value
        //       - Integer : Finded Row
        // Arguments
        //       - ByVal spdList As FarPoint.Win.Spread.SheetView : SpreadSheet
        //       - ByVal iRow As Integer : Selected Row
        //
        private int FindTopRow(FarPoint.Win.Spread.SheetView spdList, int iRow)
        {

            int i;
            i = iRow;
            while (i >= 0 && i < spdList.RowCount)
            {
                if (MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.MINUS ||
                    MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.PLUS)
                {
                    return i;
                }
                i--;
            }

            return -1;

        }

        //
        // FindOper()
        //       - ?ÑÏû¨ ?†ÌÉù??RowÎ•??¨Ìï®?òÎäî OperationÎ•?Ï∞æÎäî??
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal spdList As FarPoint.Win.Spread.SheetView : SpreadSheet
        //       - ByVal iRow As Integer : Selected Row
        //
        private bool FindOper(FarPoint.Win.Spread.SheetView spdList, string iRow)
        {
            
            int i;
            i = MPCF.ToInt(iRow);
            while (i >= 0 && i < spdList.RowCount)
            {
                if (MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.MINUS ||
                    MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.PLUS)
                {
                    SelOOper = MPCF.Trim(spdList.Cells[i, 1].Text);
                    SelOOperDesc = MPCF.Trim(spdList.Cells[i, 2].Text);
                    return true;
                }
                i--;
            }
            
            return false;
            
        }
        //
        // FindOper()
        //       - ?ÑÏû¨ ?†ÌÉù??RowÎ•??¨Ìï®?òÎäî OperationÎ•?Ï∞æÎäî??
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal spdList As FarPoint.Win.Spread.SheetView : SpreadSheet
        //       - ByVal iRow As Integer : Selected Row
        //
        private bool FindOper(FarPoint.Win.Spread.SheetView spdList, int iRow)
        {

            int i;
            i = iRow;
            while (i >= 0 && i < spdList.RowCount)
            {
                if (MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.MINUS ||
                    MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.PLUS)
                {
                    SelOOper = MPCF.Trim(spdList.Cells[i, 1].Text);
                    SelOOperDesc = MPCF.Trim(spdList.Cells[i, 2].Text);
                    return true;
                }
                i--;
            }

            return false;

        }
        
        //
        // FindRow()
        //       - Create /Update ??Î°úÏö∞Î•?Ï∞æÎäî??
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal spdList As FarPoint.Win.Spread.SheetView : SpreadSheet
        //       - ByVal iRow As Integer : Selected Row
        //
        private int FindRow(FarPoint.Win.Spread.SheetView spdList, string iStart, string sRepOper, string sRetOper)
        {
            
            int i;
            i = MPCF.ToInt(iStart);
            while (i >= 0 && i < spdList.RowCount)
            {
                if (MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.MINUS ||
                    MPCF.ToInt(spdList.Cells[i, 0].Tag) == (int)CELL_STATUS.PLUS)
                {
                    break;
                }
                
                if (MPCF.Trim(spdList.Cells[i, 3].Value).ToUpper() == MPCF.Trim(sRepOper).ToUpper())
                {
                    if (MPCF.Trim(spdList.Cells[i, 4].Value).ToUpper() == MPCF.Trim(sRetOper).ToUpper())
                    {
                        return i;
                    }
                }
                i++;
            }
            
            return - 1;
            
        }
        
        //
        // GetOperList()
        //       - Get Oper List by Flow
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool GetOperList(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList)
        {
            
            try
            {
                cdvList.Init();
                MPCF.InitListView(cdvList.GetListView);
                cdvList.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvList.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvList.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvList.GetListView, '1', "", 0,"", "", null, "") == false)
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.spdOperationList;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPSetupRepairOper_Load(object sender, System.EventArgs e)
        {
            
            plusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.PLUS - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            minusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.MINUS - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            emptyCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.EMPTY - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            checkCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.CHECK - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Right, FarPoint.Win.VerticalAlignment.Center);
        }
        
        private void frmWIPSetupRepairOper_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (LoadFlag == false)
                {
                    MPCF.ClearList(spdOperationList, true);
                    
                    ClearData("1");
                    if (GetSPOperList(spdOperationList.Sheets[0]) == false)
                    {
                        return;
                    }
                    
                    LoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdOperationList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.ColumnHeader == true)
                {
                    return;
                }
                if (e.RowHeader == true)
                {
                    return;
                }
                
                int i = 0;

                switch ((CELL_STATUS) spdOperationList.Sheets[0].Cells[e.Row, 0].Tag)
                {
                    case CELL_STATUS.PLUS:
                        
                        spdOperationList.Sheets[0].Cells[e.Row, 0].CellType = minusCellType;
                        spdOperationList.Sheets[0].Cells[e.Row, 0].Tag = CELL_STATUS.MINUS;
                        SetSelectData(MPCF.Trim(spdOperationList.Sheets[0].Cells[e.Row, 1].Text), "", "");
                        SelOOperDesc = MPCF.Trim(spdOperationList.Sheets[0].Cells[e.Row, 2].Text);
                        if (ViewRepairOperList(spdOperationList.Sheets[0], e.Row, '1', SelOOper) == false)
                        {
                            return;
                        }
                        break;
                    case CELL_STATUS.MINUS:
                        
                        spdOperationList.Sheets[0].Cells[e.Row, 0].CellType = plusCellType;
                        spdOperationList.Sheets[0].Cells[e.Row, 0].Tag = CELL_STATUS.PLUS;
                        SetSelectData(MPCF.Trim(spdOperationList.Sheets[0].Cells[e.Row, 1].Text), "", "");
                        SelOOperDesc = MPCF.Trim(spdOperationList.Sheets[0].Cells[e.Row, 2].Text);
                        i = e.Row + 1;
                        if (i < spdOperationList.Sheets[0].RowCount)
                        {
                            int iRemoveCnt = 0;

                            while (MPCF.ToInt(spdOperationList.Sheets[0].Cells[i, 0].Tag) == (int)CELL_STATUS.EMPTY ||
                                   MPCF.ToInt(spdOperationList.Sheets[0].Cells[i, 0].Tag) == (int)CELL_STATUS.CHECK)
                            {
                                spdOperationList.Sheets[0].RemoveRows(i, 1);
                                iRemoveCnt++;
                                if (i > spdOperationList.Sheets[0].RowCount - 1)
                                {
                                    break;
                                }
                            }
                            if (e.Row < PrevSelORow)
                            {
                                PrevSelORow -= iRemoveCnt;
                            }
                            
                        }
                        break;
                    case CELL_STATUS.EMPTY:
                        
                        spdOperationList.Sheets[0].Cells[e.Row, 0].CellType = checkCellType;
                        spdOperationList.Sheets[0].Cells[e.Row, 0].Tag = CELL_STATUS.CHECK;
                        if (FindOper(spdOperationList.Sheets[0], e.Row) == false)
                        {
                            SelOOper = "";
                            SelOOperDesc = "";
                        }
                        SetSelectData(SelOOper, MPCF.Trim(spdOperationList.Sheets[0].Cells[e.Row, 3].Tag), MPCF.Trim(spdOperationList.Sheets[0].Cells[e.Row, 4].Tag));
                        break;
                    case CELL_STATUS.CHECK:
                        
                        spdOperationList.Sheets[0].Cells[e.Row, 0].Tag = CELL_STATUS.CHECK;
                        if (FindOper(spdOperationList.Sheets[0], e.Row) == false)
                        {
                            SelOOper = "";
                            SelOOperDesc = "";
                        }
                        SetSelectData(SelOOper, MPCF.Trim(spdOperationList.Sheets[0].Cells[e.Row, 3].Tag), MPCF.Trim(spdOperationList.Sheets[0].Cells[e.Row, 4].Tag));
                        break;
                }
                
                if (PrevSelORow != e.Row && PrevSelORow >= 0 && PrevSelORow < spdOperationList.Sheets[0].RowCount)
                {
                    if (MPCF.ToInt(spdOperationList.Sheets[0].Cells[PrevSelORow, 0].Tag) == (int)CELL_STATUS.CHECK)
                    {
                        spdOperationList.Sheets[0].Cells[PrevSelORow, 0].CellType = emptyCellType;
                        spdOperationList.Sheets[0].Cells[PrevSelORow, 0].Tag = CELL_STATUS.EMPTY;
                    }
                }
                
                PrevSelORow = e.Row;
                PrevSelOCol = e.Column;
                
                cdvOperation.Text = SelOOper;
                cdvRepairOper.Text = SelORepOper;
                
                if (SelORetOper == "")
                {
                    cdvReturnOper.Text = SelOOper;
                }
                else
                {
                    cdvReturnOper.Text = SelORetOper;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            
            int i = 0;
            try
            {
                if (CheckCondition("CREATE") == false)
                {
                    return;
                }
                
                SelORepOper = MPCF.Trim(cdvRepairOper.Text);
                SelORetOper = MPCF.Trim(cdvReturnOper.Text);
                if (UpdateRepairOper(MPGC.MP_STEP_CREATE, SelOOper, SelORepOper, SelORetOper) == false)
                {
                    return;
                }
                i = FindTopRow(spdOperationList.Sheets[0], PrevSelORow) + 1;
                if (i == - 1)
                {
                    return;
                }
                spdOperationList.Sheets[0].Cells[FindTopRow(spdOperationList.Sheets[0], i - 1), 0].CellType = minusCellType;
                spdOperationList.Sheets[0].Cells[FindTopRow(spdOperationList.Sheets[0], i - 1), 0].Tag = CELL_STATUS.MINUS;
                if (i < spdOperationList.Sheets[0].RowCount)
                {
                    while (MPCF.ToInt(spdOperationList.Sheets[0].Cells[i, 0].Tag) == (int)CELL_STATUS.EMPTY ||
                           MPCF.ToInt(spdOperationList.Sheets[0].Cells[i, 0].Tag) == (int)CELL_STATUS.CHECK)
                    {
                        spdOperationList.Sheets[0].RemoveRows(i, 1);
                        if (i > spdOperationList.Sheets[0].RowCount - 1)
                        {
                            break;
                        }
                    }
                }
                if (ViewRepairOperList(spdOperationList.Sheets[0], i - 1, '1', SelOOper) == false)
                {
                    return;
                }
                
                PrevSelORow = FindRow(spdOperationList.Sheets[0], Convert.ToString(i), SelORepOper, SelORetOper);
                if (PrevSelORow > 0)
                {
                    spdOperationList.Sheets[0].Cells[PrevSelORow, 0].CellType = checkCellType;
                    spdOperationList.Sheets[0].Cells[PrevSelORow, 0].Tag = CELL_STATUS.CHECK;
                    spdOperationList.Sheets[0].ActiveRowIndex = PrevSelORow;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            //Dim i As Integer = 0
            
            //If CheckCondition("UPDATE") = False Then Exit Sub
            
            //SelORepOper = RTrim(cdvRepairOper.Text)
            //SelORetOper = RTrim(cdvReturnOper.Text)
            //If UpdateRepairOper(MP_STEP_UPDATE, SelOOper, SelORepOper, SelORetOper) = False Then Exit Sub
            //i = FindTopRow(spdOperationList.Sheets(0), PrevSelORow) + 1
            //If i = -1 Then
            //    Exit Sub
            //End If
            //spdOperationList.Sheets(0).Cells(FindTopRow(spdOperationList.Sheets(0), i - 1), 0).CellType = minusCellType
            //spdOperationList.Sheets(0).Cells(FindTopRow(spdOperationList.Sheets(0), i - 1), 0).Tag = (int)CELL_STATUS.MINUS))
            //If i < spdOperationList.Sheets(0).RowCount Then
            //    While (spdOperationList.Sheets(0).Cells(i, 0).Tag = (int)CELL_STATUS.EMPTY)) Or spdOperationList.Sheets(0).Cells(i, 0).Tag = (int)CELL_STATUS.CHECK)))
            //        spdOperationList.Sheets(0).RemoveRows(i, 1)
            //        If i > spdOperationList.Sheets(0).RowCount - 1 Then
            //            Exit While
            //        End If
            //    End While
            //End If
            //If ViewRepairOperList(spdOperationList.Sheets(0), i - 1, "1", SelOOper) = False Then Exit Sub
            
            //PrevSelORow = FindRow(spdOperationList.Sheets(0), i, SelORepOper, SelORetOper)
            //If PrevSelORow > 0 Then
            //    spdOperationList.Sheets(0).Cells(PrevSelORow, 0).CellType = checkCellType
            //    spdOperationList.Sheets(0).Cells(PrevSelORow, 0).Tag = (int)CELL_STATUS.CHECK))
            //    spdOperationList.Sheets(0).ActiveRowIndex = PrevSelORow
            //End If
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            if (spdOperationList.Sheets[0].ActiveRowIndex <= 0)
            {
                return;
            }
            if (MPCF.ToInt(spdOperationList.Sheets[0].Cells[spdOperationList.Sheets[0].ActiveRowIndex, 0].Tag) != (int)CELL_STATUS.CHECK)
            {
                return;
            }
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            
            if (CheckCondition("DELETE") == false)
            {
                return;
            }
            
            if (UpdateRepairOper(MPGC.MP_STEP_DELETE, SelOOper, SelORepOper, SelORetOper) == false)
            {
                return;
            }
            spdOperationList.Sheets[0].RemoveRows(PrevSelORow, 1);
            PrevSelORow--;
            GetSelectData(spdOperationList.Sheets[0], PrevSelORow);
            
        }
        
        private void cdvRepairOper_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (GetOperList(cdvRepairOper) == false)
            {
                return;
            }
            
        }
        
        private void cdvReturnOper_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (GetOperList(cdvReturnOper) == false)
            {
                return;
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            if (GetSPOperList(spdOperationList.Sheets[0]) == false)
            {
                return;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ExportToExcel(spdOperationList, this.Text, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
    }
    
}
