//#If _EDC = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCViewLotDatabyCollectionSet.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  CheckCondition() : Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by W.Y. Choi
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
using Miracom.UI.Controls;
using Miracom.TRSCore;

namespace Miracom.EDCCore
{
    public class frmEDCViewLotDatabyCollectionSet : Miracom.MESCore.ViewForm01
    {

        #region " Windows Form auto generated code "

        public frmEDCViewLotDatabyCollectionSet()
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




        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCollectionSet;
        private System.Windows.Forms.Label lblCollectionSet;
        private System.Windows.Forms.Label lblCharacter;
        private System.Windows.Forms.Label lblFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblOperatio;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCharacter;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Label lblPeriod;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.cdvCollectionSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCollectionSet = new System.Windows.Forms.Label();
            this.lblCharacter = new System.Windows.Forms.Label();
            this.cdvCharacter = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFlow = new System.Windows.Forms.Label();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperatio = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 95);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.lblPeriod);
            this.grpOption.Controls.Add(this.dtpEndDate);
            this.grpOption.Controls.Add(this.dtpStartDate);
            this.grpOption.Controls.Add(this.cdvOperation);
            this.grpOption.Controls.Add(this.cdvFlow);
            this.grpOption.Controls.Add(this.cdvCharacter);
            this.grpOption.Controls.Add(this.cdvCollectionSet);
            this.grpOption.Controls.Add(this.lblOperatio);
            this.grpOption.Controls.Add(this.lblFlow);
            this.grpOption.Controls.Add(this.lblCharacter);
            this.grpOption.Controls.Add(this.lblCollectionSet);
            this.grpOption.Size = new System.Drawing.Size(742, 95);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdData);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 95);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 418);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot Data by Collection Set";
            // 
            // cdvCollectionSet
            // 
            this.cdvCollectionSet.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCollectionSet.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCollectionSet.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCollectionSet.BtnToolTipText = "";
            this.cdvCollectionSet.DescText = "";
            this.cdvCollectionSet.DisplaySubItemIndex = -1;
            this.cdvCollectionSet.DisplayText = "";
            this.cdvCollectionSet.Focusing = null;
            this.cdvCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCollectionSet.Index = 0;
            this.cdvCollectionSet.IsViewBtnImage = false;
            this.cdvCollectionSet.Location = new System.Drawing.Point(120, 16);
            this.cdvCollectionSet.MaxLength = 25;
            this.cdvCollectionSet.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.Name = "cdvCollectionSet";
            this.cdvCollectionSet.ReadOnly = false;
            this.cdvCollectionSet.SearchSubItemIndex = 0;
            this.cdvCollectionSet.SelectedDescIndex = -1;
            this.cdvCollectionSet.SelectedSubItemIndex = -1;
            this.cdvCollectionSet.SelectionStart = 0;
            this.cdvCollectionSet.Size = new System.Drawing.Size(200, 20);
            this.cdvCollectionSet.SmallImageList = null;
            this.cdvCollectionSet.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCollectionSet.TabIndex = 1;
            this.cdvCollectionSet.TextBoxToolTipText = "";
            this.cdvCollectionSet.TextBoxWidth = 200;
            this.cdvCollectionSet.VisibleButton = true;
            this.cdvCollectionSet.VisibleColumnHeader = false;
            this.cdvCollectionSet.VisibleDescription = false;
            this.cdvCollectionSet.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCollectionSet_SelectedItemChanged);
            this.cdvCollectionSet.ButtonPress += new System.EventHandler(this.cdvCollectionSet_ButtonPress);
            this.cdvCollectionSet.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCollectionSet_KeyPress);
            // 
            // lblCollectionSet
            // 
            this.lblCollectionSet.AutoSize = true;
            this.lblCollectionSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectionSet.Location = new System.Drawing.Point(15, 19);
            this.lblCollectionSet.Name = "lblCollectionSet";
            this.lblCollectionSet.Size = new System.Drawing.Size(86, 13);
            this.lblCollectionSet.TabIndex = 0;
            this.lblCollectionSet.Text = "Collection Set";
            // 
            // lblCharacter
            // 
            this.lblCharacter.AutoSize = true;
            this.lblCharacter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacter.Location = new System.Drawing.Point(15, 43);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(53, 13);
            this.lblCharacter.TabIndex = 2;
            this.lblCharacter.Text = "Character";
            // 
            // cdvCharacter
            // 
            this.cdvCharacter.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharacter.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharacter.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCharacter.BtnToolTipText = "";
            this.cdvCharacter.DescText = "";
            this.cdvCharacter.DisplaySubItemIndex = -1;
            this.cdvCharacter.DisplayText = "";
            this.cdvCharacter.Focusing = null;
            this.cdvCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCharacter.Index = 0;
            this.cdvCharacter.IsViewBtnImage = false;
            this.cdvCharacter.Location = new System.Drawing.Point(120, 40);
            this.cdvCharacter.MaxLength = 25;
            this.cdvCharacter.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCharacter.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCharacter.Name = "cdvCharacter";
            this.cdvCharacter.ReadOnly = false;
            this.cdvCharacter.SearchSubItemIndex = 0;
            this.cdvCharacter.SelectedDescIndex = -1;
            this.cdvCharacter.SelectedSubItemIndex = -1;
            this.cdvCharacter.SelectionStart = 0;
            this.cdvCharacter.Size = new System.Drawing.Size(200, 20);
            this.cdvCharacter.SmallImageList = null;
            this.cdvCharacter.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharacter.TabIndex = 3;
            this.cdvCharacter.TextBoxToolTipText = "";
            this.cdvCharacter.TextBoxWidth = 200;
            this.cdvCharacter.VisibleButton = true;
            this.cdvCharacter.VisibleColumnHeader = false;
            this.cdvCharacter.VisibleDescription = false;
            this.cdvCharacter.ButtonPress += new System.EventHandler(this.cdvCharacter_ButtonPress);
            this.cdvCharacter.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCollectionSet_KeyPress);
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlow.Location = new System.Drawing.Point(420, 43);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(29, 13);
            this.lblFlow.TabIndex = 8;
            this.lblFlow.Text = "Flow";
            // 
            // cdvFlow
            // 
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = -1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(530, 40);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(200, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 9;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 200;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            this.cdvFlow.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCollectionSet_KeyPress);
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
            this.cdvOperation.Location = new System.Drawing.Point(530, 64);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(200, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 11;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 200;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            this.cdvOperation.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCollectionSet_KeyPress);
            // 
            // lblOperatio
            // 
            this.lblOperatio.AutoSize = true;
            this.lblOperatio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatio.Location = new System.Drawing.Point(420, 67);
            this.lblOperatio.Name = "lblOperatio";
            this.lblOperatio.Size = new System.Drawing.Size(53, 13);
            this.lblOperatio.TabIndex = 10;
            this.lblOperatio.Text = "Operation";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(530, 16);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(90, 20);
            this.dtpStartDate.TabIndex = 6;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(636, 16);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(90, 20);
            this.dtpEndDate.TabIndex = 7;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 3);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(742, 415);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
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
            spdData_Sheet1.ColumnCount = 0;
            spdData_Sheet1.ColumnHeader.RowCount = 2;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Location = new System.Drawing.Point(420, 19);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(37, 13);
            this.lblPeriod.TabIndex = 5;
            this.lblPeriod.Text = "Period";
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(15, 65);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(305, 20);
            this.cdvMaterial.TabIndex = 4;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 105;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // frmEDCViewLotDatabyCollectionSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmEDCViewLotDatabyCollectionSet";
            this.Text = "View Lot Data by Collection Set";
            this.Activated += new System.EventHandler(this.frmEDCViewLotDatabyColllectionSet_Activated);
            this.Load += new System.EventHandler(this.frmEDCViewLotDatabyColllectionSet_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Variable Definition"

        bool LoadFlag;

        #endregion

        #region " Function Definition"

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

                    case "ViewLotDataByCollectionSet":


                        //Collection Set Validation
                        if (cdvCollectionSet.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvCollectionSet.Focus();
                            return false;
                        }

                        //Tran time Validation
                        if (dtpStartDate.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            dtpStartDate.Focus();
                            return false;
                        }

                        if (dtpEndDate.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            dtpEndDate.Focus();
                            return false;
                        }
                        
                        if (MPCF.ToInt(MPCF.ToStandardTime(dtpStartDate.Value, MPGC.MP_CONVERT_DATETIME_FORMAT)) > MPCF.ToInt(MPCF.ToStandardTime(dtpEndDate.Value, MPGC.MP_CONVERT_DATETIME_FORMAT)))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(160));
                            dtpStartDate.Focus();
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

        private bool Make_Column_Header()
        {
            int i;
            int i_max_value_count;
            int i_value_count;
            string s_value_type;

            spdData.ActiveSheet.ColumnHeader.RowCount = 2;
            spdData.ActiveSheet.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 0).Value = "Hist Seq";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 1).Value = "Del Flag";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 2).Value = "Lot ID";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 3).Value = "Material";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 4).Value = "Mat Ver";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 5).Value = "Flow";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 6).Value = "Oper";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 7).Value = "Measure Resource ID";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 8).Value = "Proc Flow";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 9).Value = "Proc Oper";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 10).Value = "Proc Resource ID";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 11).Value = "Recipe ID";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 12).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 12).Value = "Recipe Version";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 13).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 13).Value = "Collection Set ID";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 14).Value = "Version";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 15).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 15).Value = "Collection Seq";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 16).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 16).Value = "Character Seq";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 17).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 17).Value = "Character";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 18).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 18).Value = "Character Desc";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 19).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 19).Value = "Unit Seq";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 20).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 20).Value = "Unit ID";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 21).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 21).Value = "Value Seq";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 22).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 22).Value = " Value Type";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 23).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 23).Value = " Value Count";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 24).ColumnSpan = 25;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 24).Value = "Value";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 24).Value = "1";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 25).Value = "2";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 26).Value = "3";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 27).Value = "4";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 28).Value = "5";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 29).Value = "6";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 30).Value = "7";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 31).Value = "8";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 32).Value = "9";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 33).Value = "10";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 34).Value = "11";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 35).Value = "12";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 36).Value = "13";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 37).Value = "14";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 38).Value = "15";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 39).Value = "16";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 40).Value = "17";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 41).Value = "18";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 42).Value = "19";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 43).Value = "20";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 44).Value = "21";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 45).Value = "22";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 46).Value = "23";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 47).Value = "24";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(1, 48).Value = "25";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 49).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 49).Value = "Spec Out Mask";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 50).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 50).Value = "Update User ID";
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 51).RowSpan = 2;
            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, 51).Value = "Update Time";
            spdData.ActiveSheet.ColumnHeader.Rows.Get(0).Height = 18F;
            spdData.ActiveSheet.ColumnHeader.Rows.Get(1).Height = 18F;
            spdData.ActiveSheet.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(0).Locked = true;
            spdData.ActiveSheet.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(0).Width = 30F;
            spdData.ActiveSheet.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(1).Locked = true;
            spdData.ActiveSheet.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(1).Width = 30F;
            spdData.ActiveSheet.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(2).Locked = true;
            spdData.ActiveSheet.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(2).Width = 100F;
            spdData.ActiveSheet.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(3).Locked = true;
            spdData.ActiveSheet.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(3).Width = 100F;
            spdData.ActiveSheet.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(4).Locked = true;
            spdData.ActiveSheet.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(4).Width = 30F;
            spdData.ActiveSheet.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(5).Locked = true;
            spdData.ActiveSheet.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(5).Width = 70F;
            spdData.ActiveSheet.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(6).Locked = true;
            spdData.ActiveSheet.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(6).Width = 40F;
            spdData.ActiveSheet.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(7).Locked = true;
            spdData.ActiveSheet.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(7).Width = 70F;
            spdData.ActiveSheet.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(8).Locked = true;
            spdData.ActiveSheet.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(8).Width = 70F;
            spdData.ActiveSheet.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(9).Locked = true;
            spdData.ActiveSheet.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(9).Width = 40F;
            spdData.ActiveSheet.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(10).Locked = true;
            spdData.ActiveSheet.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(10).Width = 70F;
            spdData.ActiveSheet.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(11).Locked = true;
            spdData.ActiveSheet.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(11).Width = 100F;
            spdData.ActiveSheet.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            spdData.ActiveSheet.Columns.Get(12).Locked = true;
            spdData.ActiveSheet.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(12).Width = 45F;
            spdData.ActiveSheet.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(13).Locked = true;
            spdData.ActiveSheet.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(13).Width = 100F;
            spdData.ActiveSheet.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(14).Locked = true;
            spdData.ActiveSheet.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(14).Width = 45F;
            spdData.ActiveSheet.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(15).Locked = true;
            spdData.ActiveSheet.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(15).Width = 58F;
            spdData.ActiveSheet.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(16).Locked = true;
            spdData.ActiveSheet.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(16).Width = 58F;
            spdData.ActiveSheet.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(17).Locked = true;
            spdData.ActiveSheet.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(17).Width = 100F;
            spdData.ActiveSheet.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(18).Locked = true;
            spdData.ActiveSheet.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(18).Width = 120F;
            spdData.ActiveSheet.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(19).Locked = true;
            spdData.ActiveSheet.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(19).Width = 30F;
            spdData.ActiveSheet.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(20).Locked = true;
            spdData.ActiveSheet.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(20).Width = 100F;
            spdData.ActiveSheet.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(21).Locked = true;
            spdData.ActiveSheet.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(21).Width = 40F;
            spdData.ActiveSheet.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(22).Locked = true;
            spdData.ActiveSheet.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(22).Width = 40F;
            spdData.ActiveSheet.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            spdData.ActiveSheet.Columns.Get(23).Locked = true;
            spdData.ActiveSheet.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(23).Width = 40F;
            spdData.ActiveSheet.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(24).Label = "1";
            spdData.ActiveSheet.Columns.Get(24).Locked = true;
            spdData.ActiveSheet.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(25).Label = "2";
            spdData.ActiveSheet.Columns.Get(25).Locked = true;
            spdData.ActiveSheet.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(26).Label = "3";
            spdData.ActiveSheet.Columns.Get(26).Locked = true;
            spdData.ActiveSheet.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(27).Label = "4";
            spdData.ActiveSheet.Columns.Get(27).Locked = true;
            spdData.ActiveSheet.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(28).Label = "5";
            spdData.ActiveSheet.Columns.Get(28).Locked = true;
            spdData.ActiveSheet.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(29).Label = "6";
            spdData.ActiveSheet.Columns.Get(29).Locked = true;
            spdData.ActiveSheet.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(30).Label = "7";
            spdData.ActiveSheet.Columns.Get(30).Locked = true;
            spdData.ActiveSheet.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(31).Label = "8";
            spdData.ActiveSheet.Columns.Get(31).Locked = true;
            spdData.ActiveSheet.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(32).Label = "9";
            spdData.ActiveSheet.Columns.Get(32).Locked = true;
            spdData.ActiveSheet.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(33).Label = "10";
            spdData.ActiveSheet.Columns.Get(33).Locked = true;
            spdData.ActiveSheet.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(34).Label = "11";
            spdData.ActiveSheet.Columns.Get(34).Locked = true;
            spdData.ActiveSheet.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(35).Label = "12";
            spdData.ActiveSheet.Columns.Get(35).Locked = true;
            spdData.ActiveSheet.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(36).Label = "13";
            spdData.ActiveSheet.Columns.Get(36).Locked = true;
            spdData.ActiveSheet.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(37).Label = "14";
            spdData.ActiveSheet.Columns.Get(37).Locked = true;
            spdData.ActiveSheet.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(38).Label = "15";
            spdData.ActiveSheet.Columns.Get(38).Locked = true;
            spdData.ActiveSheet.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(39).Label = "16";
            spdData.ActiveSheet.Columns.Get(39).Locked = true;
            spdData.ActiveSheet.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(40).Label = "17";
            spdData.ActiveSheet.Columns.Get(40).Locked = true;
            spdData.ActiveSheet.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(41).Label = "18";
            spdData.ActiveSheet.Columns.Get(41).Locked = true;
            spdData.ActiveSheet.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(42).Label = "19";
            spdData.ActiveSheet.Columns.Get(42).Locked = true;
            spdData.ActiveSheet.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(43).Label = "20";
            spdData.ActiveSheet.Columns.Get(43).Locked = true;
            spdData.ActiveSheet.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(44).Label = "21";
            spdData.ActiveSheet.Columns.Get(44).Locked = true;
            spdData.ActiveSheet.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(45).Label = "22";
            spdData.ActiveSheet.Columns.Get(45).Locked = true;
            spdData.ActiveSheet.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(46).Label = "23";
            spdData.ActiveSheet.Columns.Get(46).Locked = true;
            spdData.ActiveSheet.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(47).Label = "24";
            spdData.ActiveSheet.Columns.Get(47).Locked = true;
            spdData.ActiveSheet.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdData.ActiveSheet.Columns.Get(48).Label = "25";
            spdData.ActiveSheet.Columns.Get(48).Locked = true;
            spdData.ActiveSheet.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(49).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(49).Locked = true;
            spdData.ActiveSheet.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(49).Width = 160F;
            spdData.ActiveSheet.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(50).Locked = true;
            spdData.ActiveSheet.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(50).Width = 85F;
            spdData.ActiveSheet.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            spdData.ActiveSheet.Columns.Get(51).Locked = true;
            spdData.ActiveSheet.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdData.ActiveSheet.Columns.Get(51).Width = 110F;

            spdData.ActiveSheet.Columns.Get(24, 48).Width = 60F;

            i_max_value_count = 0;
            for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
            {
                if(MPCF.Trim(spdData.ActiveSheet.GetValue(i, 1)) == "Y")
                {
                    spdData.ActiveSheet.Rows[i].ForeColor = Color.Magenta;
                }

                s_value_type = MPCF.Trim(spdData.ActiveSheet.GetValue(i, 22));
                if (s_value_type == "N")
                {
                    spdData.ActiveSheet.Cells[i, 24, i, 48].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                }
                else
                {
                    spdData.ActiveSheet.Cells[i, 24, i, 48].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                }

                
                i_value_count = MPCF.ToInt(spdData.ActiveSheet.GetValue(i, 23));
                if(i_value_count > i_max_value_count)
                {
                    i_max_value_count = i_value_count;
                }
            }

            if (i_max_value_count == 0)
            {
                i_max_value_count = 1;
            }

            if (i_max_value_count < 25)
            {
                spdData.ActiveSheet.Columns.Get(24 + i_max_value_count, 48).Visible = false;
            }

            spdData.ActiveSheet.FrozenColumnCount = 3;

            MPCF.ConvertMessage(pnlViewMid.Controls);

            return true;

        }


        private DataTable FillDataTable(DataTable dt, TRSNode out_node)
        {
            int r;
            DataColumn dc;
            DataRow dr;
            double[] value;
            int i;
            int iPrecision = -1;

            value = new double[25];

            if (dt == null)
            {
                if (out_node.GetList(0).Count < 1) return null;

                dt = new DataTable("DataTable");

                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetInt("HIST_SEQ").GetType(); dc.DefaultValue = 0; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetChar("HIS_DEL_FLAG").GetType(); dc.DefaultValue = ' '; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("LOT_ID").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("MAT_ID").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetInt("MAT_VER").GetType(); dc.DefaultValue = 0; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("FLOW").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("OPER").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("MEAS_RES_ID").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("PROC_FLOW").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("PROC_OPER").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("PROC_RES_ID").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("RECIPE_ID").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetInt("RECIPE_VERSION").GetType(); dc.DefaultValue = 0; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("COL_SET_ID").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetInt("COL_SET_VERSION").GetType(); dc.DefaultValue = 0; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetInt("COL_SEQ").GetType(); dc.DefaultValue = 0; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetInt("CHAR_SEQ_NUM").GetType(); dc.DefaultValue = 0; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("CHAR_ID").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("CHAR_DESC").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetInt("UNIT_SEQ_NUM").GetType(); dc.DefaultValue = 0; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("UNIT_ID").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetInt("VALUE_SEQ_NUM").GetType(); dc.DefaultValue = 0; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetChar("VALUE_TYPE").GetType(); dc.DefaultValue = ' '; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetInt("VALUE_COUNT").GetType(); dc.DefaultValue = 0; dt.Columns.Add(dc);

                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = System.Type.GetType("System.String"); dc.DefaultValue = ""; dt.Columns.Add(dc);

                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("SPEC_OUT_MASK").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("UPDATE_USER_ID").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
                dc = new DataColumn(); dc.DataType = out_node.GetList(0)[0].GetString("UPDATE_TIME").GetType(); dc.DefaultValue = ""; dt.Columns.Add(dc);
            }

            for (r = 0; r < out_node.GetList(0).Count; r++)
            {
                //CHARACTERÀÇ DISPLAY_PRECISION
                iPrecision = out_node.GetList(0)[r].GetInt("DISPLAY_PRECISION");

                string s_lot = out_node.GetList(0)[r].GetString("LOT_ID");
                dr = dt.NewRow();

                dr[0] = out_node.GetList(0)[r].GetInt("HIST_SEQ");
                dr[1] = out_node.GetList(0)[r].GetChar("HIS_DEL_FLAG");
                dr[2] = out_node.GetList(0)[r].GetString("LOT_ID");
                dr[3] = out_node.GetList(0)[r].GetString("MAT_ID");
                dr[4] = out_node.GetList(0)[r].GetInt("MAT_VER");
                dr[5] = out_node.GetList(0)[r].GetString("FLOW");
                dr[6] = out_node.GetList(0)[r].GetString("OPER");
                dr[7] = out_node.GetList(0)[r].GetString("MEAS_RES_ID");
                dr[8] = out_node.GetList(0)[r].GetString("PROC_FLOW");
                dr[9] = out_node.GetList(0)[r].GetString("PROC_OPER");
                dr[10] = out_node.GetList(0)[r].GetString("PROC_RES_ID");    
                dr[11] = out_node.GetList(0)[r].GetString("RECIPE_ID");
                dr[12] = out_node.GetList(0)[r].GetInt("RECIPE_VERSION");
                dr[13] = out_node.GetList(0)[r].GetString("COL_SET_ID");
                dr[14] = out_node.GetList(0)[r].GetInt("COL_SET_VERSION");
                dr[15] = out_node.GetList(0)[r].GetInt("COL_SEQ");
                dr[16] = out_node.GetList(0)[r].GetInt("CHAR_SEQ_NUM");
                dr[17] = out_node.GetList(0)[r].GetString("CHAR_ID");
                dr[18] = out_node.GetList(0)[r].GetString("CHAR_DESC");
                dr[19] = out_node.GetList(0)[r].GetInt("UNIT_SEQ_NUM");
                dr[20] = out_node.GetList(0)[r].GetString("UNIT_ID");
                dr[21] = out_node.GetList(0)[r].GetInt("VALUE_SEQ_NUM");
                dr[22] = out_node.GetList(0)[r].GetChar("VALUE_TYPE");
                dr[23] = out_node.GetList(0)[r].GetInt("VALUE_COUNT");

                if (out_node.GetList(0)[r].GetChar("VALUE_TYPE") == 'N')
                {
                    if (out_node.GetList(0)[r].GetString("VALUE_1") == "") out_node.GetList(0)[r].SetString("VALUE_1", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_2") == "") out_node.GetList(0)[r].SetString("VALUE_2", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_3") == "") out_node.GetList(0)[r].SetString("VALUE_3", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_4") == "") out_node.GetList(0)[r].SetString("VALUE_4", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_5") == "") out_node.GetList(0)[r].SetString("VALUE_5", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_6") == "") out_node.GetList(0)[r].SetString("VALUE_6", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_7") == "") out_node.GetList(0)[r].SetString("VALUE_7", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_8") == "") out_node.GetList(0)[r].SetString("VALUE_8", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_9") == "") out_node.GetList(0)[r].SetString("VALUE_9", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_10") == "") out_node.GetList(0)[r].SetString("VALUE_10", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_11") == "") out_node.GetList(0)[r].SetString("VALUE_11", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_12") == "") out_node.GetList(0)[r].SetString("VALUE_12", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_13") == "") out_node.GetList(0)[r].SetString("VALUE_13", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_14") == "") out_node.GetList(0)[r].SetString("VALUE_14", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_15") == "") out_node.GetList(0)[r].SetString("VALUE_15", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_16") == "") out_node.GetList(0)[r].SetString("VALUE_16", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_17") == "") out_node.GetList(0)[r].SetString("VALUE_17", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_18") == "") out_node.GetList(0)[r].SetString("VALUE_18", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_19") == "") out_node.GetList(0)[r].SetString("VALUE_19", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_20") == "") out_node.GetList(0)[r].SetString("VALUE_20", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_21") == "") out_node.GetList(0)[r].SetString("VALUE_21", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_22") == "") out_node.GetList(0)[r].SetString("VALUE_22", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_23") == "") out_node.GetList(0)[r].SetString("VALUE_23", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_24") == "") out_node.GetList(0)[r].SetString("VALUE_24", "0");
                    if (out_node.GetList(0)[r].GetString("VALUE_25") == "") out_node.GetList(0)[r].SetString("VALUE_25", "0");

                    value[0] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_1"));
                    value[1] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_2"));
                    value[2] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_3"));
                    value[3] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_4"));
                    value[4] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_5"));
                    value[5] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_6"));
                    value[6] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_7"));
                    value[7] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_8"));
                    value[8] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_9"));
                    value[9] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_10"));
                    value[10] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_11"));
                    value[11] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_12"));
                    value[12] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_13"));
                    value[13] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_14"));
                    value[14] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_15"));
                    value[15] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_16"));
                    value[16] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_17"));
                    value[17] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_18"));
                    value[18] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_19"));
                    value[19] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_20"));
                    value[20] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_21"));
                    value[21] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_22"));
                    value[22] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_23"));
                    value[23] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_24"));
                    value[24] = MPCF.ToDbl(out_node.GetList(0)[r].GetString("VALUE_25"));

                    for (i = 0; i < 25; i++)
                    {                        
                        //DISPLAY PRECISION Àû¿ë
                        if (iPrecision > 0)
                        {
                            dr[24 + i] = MPCF.SetPrecision(value[i].ToString(), iPrecision);
                        }
                        else if (iPrecision == 0)
                        {
                            //precision ¹Ì¼³Á¤½Ã ±äÁ¸°ª Àû¿ë
                            dr[24 + i] = value[i].ToString();
                        }
                    }
                }
                else
                {
                    dr[24] = out_node.GetList(0)[r].GetString("VALUE_1");
                    dr[25] = out_node.GetList(0)[r].GetString("VALUE_2");
                    dr[26] = out_node.GetList(0)[r].GetString("VALUE_3");
                    dr[27] = out_node.GetList(0)[r].GetString("VALUE_4");
                    dr[28] = out_node.GetList(0)[r].GetString("VALUE_5");
                    dr[29] = out_node.GetList(0)[r].GetString("VALUE_6");
                    dr[30] = out_node.GetList(0)[r].GetString("VALUE_7");
                    dr[31] = out_node.GetList(0)[r].GetString("VALUE_8");
                    dr[32] = out_node.GetList(0)[r].GetString("VALUE_9");
                    dr[33] = out_node.GetList(0)[r].GetString("VALUE_10");
                    dr[34] = out_node.GetList(0)[r].GetString("VALUE_11");
                    dr[35] = out_node.GetList(0)[r].GetString("VALUE_12");
                    dr[36] = out_node.GetList(0)[r].GetString("VALUE_13");
                    dr[37] = out_node.GetList(0)[r].GetString("VALUE_14");
                    dr[38] = out_node.GetList(0)[r].GetString("VALUE_15");
                    dr[39] = out_node.GetList(0)[r].GetString("VALUE_16");
                    dr[40] = out_node.GetList(0)[r].GetString("VALUE_17");
                    dr[41] = out_node.GetList(0)[r].GetString("VALUE_18");
                    dr[42] = out_node.GetList(0)[r].GetString("VALUE_19");
                    dr[43] = out_node.GetList(0)[r].GetString("VALUE_20");
                    dr[44] = out_node.GetList(0)[r].GetString("VALUE_21");
                    dr[45] = out_node.GetList(0)[r].GetString("VALUE_22");
                    dr[46] = out_node.GetList(0)[r].GetString("VALUE_23");
                    dr[47] = out_node.GetList(0)[r].GetString("VALUE_24");
                    dr[48] = out_node.GetList(0)[r].GetString("VALUE_25");
                }

                dr[49] = out_node.GetList(0)[r].GetString("SPEC_OUT_MASK");
                dr[50] = out_node.GetList(0)[r].GetString("UPDATE_USER_ID");
                dr[51] = MPCF.MakeDateFormat(out_node.GetList(0)[r].GetString("UPDATE_TIME"));


                dt.Rows.Add(dr);
            }

            return dt;
        }

        
        // ViewLotDataByCollectionSet()
        //       - View Lot Data by Collection Set
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : Listê°€ ?¤ì–´ê°?control
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - ByVal sLotID As String                    : Lot id
        //       - ByVal iHistSeq As Integer                 : History Sequence
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete Historyê¹Œì? ?¬í•¨??ê²ƒì¸ì§€?
        //       - Optional ByVal sTreeItem As String = ""           : Tree Item ê°?
        //       - Optional ByVal bIgnoreErrr As Boolean = False    : ?ëŸ¬ ë°œìƒ??ë¬´ì‹œ??ê²ƒì¸ì§€?
        //
        private bool ViewLotDataByCollectionSet(string sColSet, string sCharID, string sStartTran, string sEndTran, string sMatID, int iMatVer, string sFlow, string sOper)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_DATA_OUT");

            DataTable dt = null;

            spdData.SuspendLayout();

            spdData.ActiveSheet.RowCount = 0;
            spdData.ActiveSheet.ColumnCount = 0;

            spdData.ResumeLayout();

            spdData.SuspendLayout();

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("COL_SET_ID", sColSet);
            in_node.AddString("CHAR_ID", sCharID);
            in_node.AddString("START_TRAN_TIME", sStartTran);
            in_node.AddString("END_TRAN_TIME", sEndTran);
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", sFlow);
            in_node.AddString("OPER", sOper);
            in_node.AddInt("NEXT_CHAR_SEQ_NUM", 0);
            in_node.AddInt("NEXT_UNIT_SEQ_NUM", 0);
            in_node.AddInt("NEXT_VALUE_SEQ_NUM", 0);
            in_node.AddInt("NEXT_COL_SEQ", 0);

            do
            {
                if (MPCR.CallService("EDC", "EDC_View_Lot_Data_By_ColSet", in_node, ref out_node) == false)
                {
                    return false;
                }

                dt = FillDataTable(dt, out_node);

                in_node.SetInt("NEXT_CHAR_SEQ_NUM", out_node.GetInt("NEXT_CHAR_SEQ_NUM"));
                in_node.SetInt("NEXT_UNIT_SEQ_NUM", out_node.GetInt("NEXT_UNIT_SEQ_NUM"));
                in_node.SetInt("NEXT_VALUE_SEQ_NUM", out_node.GetInt("NEXT_VALUE_SEQ_NUM"));
                in_node.SetInt("NEXT_COL_SEQ", out_node.GetInt("NEXT_COL_SEQ"));
                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

            } while (in_node.GetInt("NEXT_CHAR_SEQ_NUM") > 0 ||
                     in_node.GetInt("NEXT_UNIT_SEQ_NUM") > 0 ||
                     in_node.GetInt("NEXT_VALUE_SEQ_NUM") > 0 ||
                     in_node.GetInt("NEXT_COL_SEQ") > 0);

            if (dt != null)
            {
                spdData.DataSource = dt;

                Make_Column_Header();

                spdData.ResumeLayout();
            }
                       
            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvCollectionSet;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmEDCViewLotDatabyColllectionSet_Load(object sender, System.EventArgs e)
        {

            try
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdData, true);

                dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                dtpEndDate.Value = DateTime.Now;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void frmEDCViewLotDatabyColllectionSet_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (LoadFlag == false)
                {
                    if (EDCLIST.ViewEDCColSetList(cdvCollectionSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
                    {
                        return;
                    }
                    if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "") == false)
                    {
                        return;
                    }
                    if (WIPLIST.ViewMaterialList(cdvMaterial.MaterialGetListView, '1') == false)
                    {
                        return;
                    }
                    if (WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "") == false)
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

        private void cdvCollectionSet_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                btnView_Click(sender, e);
            }

        }

        private void cdvCollectionSet_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvCharacter.Text = "";

            /*
            if (EDCLIST.ViewCharacterbyCollection(cdvCharacter.GetListView, '6', e.Text, null, "") == false)
            {
                return;
            }
            */

        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {

            string sToDate;
            string sFromDate;

            sFromDate = MPCF.FromDate(dtpStartDate);
            sToDate = MPCF.ToDate(dtpEndDate);

            try
            {

                if (CheckCondition("ViewLotDataByCollectionSet", MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (ViewLotDataByCollectionSet(cdvCollectionSet.Text, cdvCharacter.Text, sFromDate, sToDate, MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOperation.Text)) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvCollectionSet_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCollectionSet.Init();
            cdvCollectionSet.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
            cdvCollectionSet.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvCollectionSet.SelectedSubItemIndex = 0;
            if (EDCLIST.ViewEDCColSetList(cdvCollectionSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
            {
                return;
            }

        }

        private void cdvCharacter_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCharacter.Init();
            cdvCharacter.Columns.Add("Character", 50, HorizontalAlignment.Left);
            cdvCharacter.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvCharacter.SelectedSubItemIndex = 0;
            if (EDCLIST.ViewEDCCharacterList(cdvCharacter.GetListView, '4', 'E', cdvCollectionSet.Text, "") == false)
            {
                return;
            }

        }

        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            cdvFlow.Init();
            cdvFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            if (cdvMaterial.Text != "")
            {
                if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, "", null, "") == false)
                {
                    return;
                }
            }
            else
            {
                if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "") == false)
                {
                    return;
                }
            }

        }

        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOperation.Init();
            cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;

            if (cdvFlow.Text != "")
            {
                if (WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
            }
            else
            {
                if (WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "") == false)
                {
                    return;
                }
            }

        }

        private void cdvFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvOperation.Text = "";

        }

        private void cdvMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvFlow.Text = "";
            cdvOperation.Text = "";

        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Collection Set :" + MPCF.Trim(cdvCollectionSet.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpStartDate), DATE_TIME_FORMAT.NONE) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpEndDate));
            MPCF.ExportToExcel(spdData, this.Text, sCond);
        }


    }

    //#End If


}
