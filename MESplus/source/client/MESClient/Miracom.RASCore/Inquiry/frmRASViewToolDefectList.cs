
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
//   File Name   : frmRASViewToolDefectList.vb
//   Description : View Tool List by Oper Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_Tool_Type() : View Tool Type Information and find available Prompt
//       - ViewToolList_Detail_Local() : View Tool List by Oper (Local)
//       - CheckCondition()      : Check the conditions before transaction
//       - ClearData()           : Clear Fields and Initialize Sheet
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-08 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _TOOL = True Then

namespace Miracom.RASCore
{
    public class frmRASViewToolDefectList : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewToolDefectList()
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
        



        private System.Windows.Forms.Label lblToolType;
        private System.Windows.Forms.GroupBox grpOption2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDefectCode;
        private System.Windows.Forms.Label lblDefectCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolID;
        private System.Windows.Forms.Label lblToolID;
        private System.Windows.Forms.RadioButton optNotCleaned;
        private System.Windows.Forms.RadioButton optCleaned;
        private System.Windows.Forms.RadioButton optAllData;
        private FarPoint.Win.Spread.FpSpread spdToolDefectData;
        private FarPoint.Win.Spread.SheetView spdToolDefectData_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToolType = new System.Windows.Forms.Label();
            this.cdvDefectCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDefectCode = new System.Windows.Forms.Label();
            this.cdvToolID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToolID = new System.Windows.Forms.Label();
            this.grpOption2 = new System.Windows.Forms.GroupBox();
            this.optNotCleaned = new System.Windows.Forms.RadioButton();
            this.optCleaned = new System.Windows.Forms.RadioButton();
            this.optAllData = new System.Windows.Forms.RadioButton();
            this.spdToolDefectData = new FarPoint.Win.Spread.FpSpread();
            this.spdToolDefectData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefectCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).BeginInit();
            this.grpOption2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdToolDefectData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdToolDefectData_Sheet1)).BeginInit();
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
            this.pnlViewTop.Controls.Add(this.grpOption2);
            this.pnlViewTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlViewTop.Size = new System.Drawing.Size(742, 112);
            this.pnlViewTop.Controls.SetChildIndex(this.grpOption2, 0);
            this.pnlViewTop.Controls.SetChildIndex(this.grpOption, 0);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvToolID);
            this.grpOption.Controls.Add(this.cdvDefectCode);
            this.grpOption.Controls.Add(this.cdvType);
            this.grpOption.Controls.Add(this.lblToolID);
            this.grpOption.Controls.Add(this.lblDefectCode);
            this.grpOption.Controls.Add(this.lblToolType);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Size = new System.Drawing.Size(736, 72);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdToolDefectData);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 112);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 394);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Tool Defect Data";
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
            // lblToolType
            // 
            this.lblToolType.AutoSize = true;
            this.lblToolType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolType.Location = new System.Drawing.Point(15, 19);
            this.lblToolType.Name = "lblToolType";
            this.lblToolType.Size = new System.Drawing.Size(64, 13);
            this.lblToolType.TabIndex = 0;
            this.lblToolType.Text = "Tool Type";
            // 
            // cdvDefectCode
            // 
            this.cdvDefectCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefectCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefectCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDefectCode.BtnToolTipText = "";
            this.cdvDefectCode.DescText = "";
            this.cdvDefectCode.DisplaySubItemIndex = -1;
            this.cdvDefectCode.DisplayText = "";
            this.cdvDefectCode.Focusing = null;
            this.cdvDefectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDefectCode.Index = 0;
            this.cdvDefectCode.IsViewBtnImage = false;
            this.cdvDefectCode.Location = new System.Drawing.Point(480, 40);
            this.cdvDefectCode.MaxLength = 10;
            this.cdvDefectCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDefectCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDefectCode.Name = "cdvDefectCode";
            this.cdvDefectCode.ReadOnly = false;
            this.cdvDefectCode.SearchSubItemIndex = 0;
            this.cdvDefectCode.SelectedDescIndex = -1;
            this.cdvDefectCode.SelectedSubItemIndex = -1;
            this.cdvDefectCode.SelectionStart = 0;
            this.cdvDefectCode.Size = new System.Drawing.Size(192, 20);
            this.cdvDefectCode.SmallImageList = null;
            this.cdvDefectCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDefectCode.TabIndex = 5;
            this.cdvDefectCode.TextBoxToolTipText = "";
            this.cdvDefectCode.TextBoxWidth = 192;
            this.cdvDefectCode.VisibleButton = true;
            this.cdvDefectCode.VisibleColumnHeader = false;
            this.cdvDefectCode.VisibleDescription = false;
            this.cdvDefectCode.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvDefectCode_SelectedItemChanged);
            this.cdvDefectCode.ButtonPress += new System.EventHandler(this.cdvDefectCode_ButtonPress);
            // 
            // lblDefectCode
            // 
            this.lblDefectCode.AutoSize = true;
            this.lblDefectCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectCode.Location = new System.Drawing.Point(376, 44);
            this.lblDefectCode.Name = "lblDefectCode";
            this.lblDefectCode.Size = new System.Drawing.Size(67, 13);
            this.lblDefectCode.TabIndex = 4;
            this.lblDefectCode.Text = "Defect Code";
            this.lblDefectCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvToolID
            // 
            this.cdvToolID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolID.BtnToolTipText = "";
            this.cdvToolID.DescText = "";
            this.cdvToolID.DisplaySubItemIndex = -1;
            this.cdvToolID.DisplayText = "";
            this.cdvToolID.Focusing = null;
            this.cdvToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolID.Index = 0;
            this.cdvToolID.IsViewBtnImage = false;
            this.cdvToolID.Location = new System.Drawing.Point(120, 40);
            this.cdvToolID.MaxLength = 30;
            this.cdvToolID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.Name = "cdvToolID";
            this.cdvToolID.ReadOnly = true;
            this.cdvToolID.SearchSubItemIndex = 0;
            this.cdvToolID.SelectedDescIndex = -1;
            this.cdvToolID.SelectedSubItemIndex = -1;
            this.cdvToolID.SelectionStart = 0;
            this.cdvToolID.Size = new System.Drawing.Size(200, 20);
            this.cdvToolID.SmallImageList = null;
            this.cdvToolID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolID.TabIndex = 3;
            this.cdvToolID.TextBoxToolTipText = "";
            this.cdvToolID.TextBoxWidth = 200;
            this.cdvToolID.VisibleButton = true;
            this.cdvToolID.VisibleColumnHeader = false;
            this.cdvToolID.VisibleDescription = false;
            this.cdvToolID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToolID_SelectedItemChanged);
            this.cdvToolID.ButtonPress += new System.EventHandler(this.cdvToolID_ButtonPress);
            // 
            // lblToolID
            // 
            this.lblToolID.AutoSize = true;
            this.lblToolID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolID.Location = new System.Drawing.Point(15, 44);
            this.lblToolID.Name = "lblToolID";
            this.lblToolID.Size = new System.Drawing.Size(32, 13);
            this.lblToolID.TabIndex = 2;
            this.lblToolID.Text = "Tool";
            // 
            // grpOption2
            // 
            this.grpOption2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOption2.Controls.Add(this.optNotCleaned);
            this.grpOption2.Controls.Add(this.optCleaned);
            this.grpOption2.Controls.Add(this.optAllData);
            this.grpOption2.Location = new System.Drawing.Point(3, 72);
            this.grpOption2.Name = "grpOption2";
            this.grpOption2.Size = new System.Drawing.Size(736, 36);
            this.grpOption2.TabIndex = 1;
            this.grpOption2.TabStop = false;
            // 
            // optNotCleaned
            // 
            this.optNotCleaned.AutoSize = true;
            this.optNotCleaned.Location = new System.Drawing.Point(277, 12);
            this.optNotCleaned.Name = "optNotCleaned";
            this.optNotCleaned.Size = new System.Drawing.Size(84, 17);
            this.optNotCleaned.TabIndex = 2;
            this.optNotCleaned.Text = "Not Cleaned";
            // 
            // optCleaned
            // 
            this.optCleaned.AutoSize = true;
            this.optCleaned.Location = new System.Drawing.Point(144, 12);
            this.optCleaned.Name = "optCleaned";
            this.optCleaned.Size = new System.Drawing.Size(64, 17);
            this.optCleaned.TabIndex = 1;
            this.optCleaned.Text = "Cleaned";
            // 
            // optAllData
            // 
            this.optAllData.AutoSize = true;
            this.optAllData.Checked = true;
            this.optAllData.Location = new System.Drawing.Point(24, 12);
            this.optAllData.Name = "optAllData";
            this.optAllData.Size = new System.Drawing.Size(62, 17);
            this.optAllData.TabIndex = 0;
            this.optAllData.TabStop = true;
            this.optAllData.Text = "All Data";
            // 
            // spdToolDefectData
            // 
            this.spdToolDefectData.AccessibleDescription = "spdToolDefectData, Sheet1, Row 0, Column 0, ";
            this.spdToolDefectData.BackColor = System.Drawing.SystemColors.Control;
            this.spdToolDefectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdToolDefectData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdToolDefectData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdToolDefectData.HorizontalScrollBar.Name = "";
            this.spdToolDefectData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdToolDefectData.HorizontalScrollBar.TabIndex = 2;
            this.spdToolDefectData.Location = new System.Drawing.Point(3, 3);
            this.spdToolDefectData.Name = "spdToolDefectData";
            this.spdToolDefectData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdToolDefectData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdToolDefectData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdToolDefectData_Sheet1});
            this.spdToolDefectData.Size = new System.Drawing.Size(736, 388);
            this.spdToolDefectData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdToolDefectData.TabIndex = 0;
            this.spdToolDefectData.TabStop = false;
            this.spdToolDefectData.TextTipDelay = 200;
            this.spdToolDefectData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdToolDefectData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdToolDefectData.VerticalScrollBar.Name = "";
            this.spdToolDefectData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdToolDefectData.VerticalScrollBar.TabIndex = 3;
            this.spdToolDefectData.SetViewportLeftColumn(0, 0, 3);
            this.spdToolDefectData.SetViewportTopRow(0, 0, 1);
            this.spdToolDefectData.SetActiveViewport(0, -1, -1);
            // 
            // spdToolDefectData_Sheet1
            // 
            this.spdToolDefectData_Sheet1.Reset();
            spdToolDefectData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdToolDefectData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdToolDefectData_Sheet1.ColumnCount = 32;
            spdToolDefectData_Sheet1.RowCount = 5;
            this.spdToolDefectData_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic;
            this.spdToolDefectData_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdToolDefectData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolDefectData_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdToolDefectData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolDefectData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Tool";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tool Type";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Loc [X,Y,Z]";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Defect Code";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Tool Event";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Hist Seq";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Tool Type";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Hist Del Flag";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Defect Qty";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Cell [X,Y,Z]";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Tran Time";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Tran User ID";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Clean Flag";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Clean Hist Seq";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Clean User ID";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Clean Time";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Lot ID";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Sub Lot ID";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Resource";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Sub Resource";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Cause Flow";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Cause Oper";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Cause Resource";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Cause Sub Resource";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Check User ID 1";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Check User ID 2";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Attach File 1";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Attach File 2";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Attach File 3";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Attach File 4";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Attach File 5";
            this.spdToolDefectData_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Defect Comment";
            this.spdToolDefectData_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdToolDefectData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolDefectData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdToolDefectData_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdToolDefectData_Sheet1.ColumnHeader.Rows.Get(0).Height = 16F;
            this.spdToolDefectData_Sheet1.Columns.Get(0).Label = "Tool";
            this.spdToolDefectData_Sheet1.Columns.Get(0).Width = 107F;
            this.spdToolDefectData_Sheet1.Columns.Get(1).Label = "Tool Type";
            this.spdToolDefectData_Sheet1.Columns.Get(1).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(1).Visible = false;
            this.spdToolDefectData_Sheet1.Columns.Get(1).Width = 93F;
            this.spdToolDefectData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdToolDefectData_Sheet1.Columns.Get(2).Label = "Loc [X,Y,Z]";
            this.spdToolDefectData_Sheet1.Columns.Get(2).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolDefectData_Sheet1.Columns.Get(2).Width = 106F;
            this.spdToolDefectData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdToolDefectData_Sheet1.Columns.Get(3).Label = "Defect Code";
            this.spdToolDefectData_Sheet1.Columns.Get(3).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolDefectData_Sheet1.Columns.Get(3).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdToolDefectData_Sheet1.Columns.Get(4).Label = "Tool Event";
            this.spdToolDefectData_Sheet1.Columns.Get(4).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolDefectData_Sheet1.Columns.Get(4).Width = 113F;
            this.spdToolDefectData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdToolDefectData_Sheet1.Columns.Get(5).Label = "Hist Seq";
            this.spdToolDefectData_Sheet1.Columns.Get(5).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolDefectData_Sheet1.Columns.Get(5).Width = 80F;
            this.spdToolDefectData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdToolDefectData_Sheet1.Columns.Get(6).Label = "Tool Type";
            this.spdToolDefectData_Sheet1.Columns.Get(6).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolDefectData_Sheet1.Columns.Get(6).Width = 0F;
            this.spdToolDefectData_Sheet1.Columns.Get(7).Label = "Hist Del Flag";
            this.spdToolDefectData_Sheet1.Columns.Get(7).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(7).Width = 121F;
            this.spdToolDefectData_Sheet1.Columns.Get(8).Label = "Defect Qty";
            this.spdToolDefectData_Sheet1.Columns.Get(8).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(8).Width = 67F;
            this.spdToolDefectData_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdToolDefectData_Sheet1.Columns.Get(9).Label = "Cell [X,Y,Z]";
            this.spdToolDefectData_Sheet1.Columns.Get(9).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolDefectData_Sheet1.Columns.Get(9).Width = 105F;
            this.spdToolDefectData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdToolDefectData_Sheet1.Columns.Get(10).Label = "Tran Time";
            this.spdToolDefectData_Sheet1.Columns.Get(10).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolDefectData_Sheet1.Columns.Get(10).Width = 135F;
            this.spdToolDefectData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdToolDefectData_Sheet1.Columns.Get(11).Label = "Tran User ID";
            this.spdToolDefectData_Sheet1.Columns.Get(11).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolDefectData_Sheet1.Columns.Get(11).Width = 100F;
            this.spdToolDefectData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdToolDefectData_Sheet1.Columns.Get(12).Label = "Clean Flag";
            this.spdToolDefectData_Sheet1.Columns.Get(12).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolDefectData_Sheet1.Columns.Get(12).Width = 128F;
            this.spdToolDefectData_Sheet1.Columns.Get(13).Label = "Clean Hist Seq";
            this.spdToolDefectData_Sheet1.Columns.Get(13).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(13).Width = 163F;
            this.spdToolDefectData_Sheet1.Columns.Get(14).Label = "Clean User ID";
            this.spdToolDefectData_Sheet1.Columns.Get(14).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(14).Width = 105F;
            this.spdToolDefectData_Sheet1.Columns.Get(15).Label = "Clean Time";
            this.spdToolDefectData_Sheet1.Columns.Get(15).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(15).Width = 98F;
            this.spdToolDefectData_Sheet1.Columns.Get(16).Label = "Lot ID";
            this.spdToolDefectData_Sheet1.Columns.Get(16).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(16).Width = 109F;
            this.spdToolDefectData_Sheet1.Columns.Get(17).Label = "Sub Lot ID";
            this.spdToolDefectData_Sheet1.Columns.Get(17).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(17).Width = 95F;
            this.spdToolDefectData_Sheet1.Columns.Get(18).Label = "Resource";
            this.spdToolDefectData_Sheet1.Columns.Get(18).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(18).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(19).Label = "Sub Resource";
            this.spdToolDefectData_Sheet1.Columns.Get(19).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(19).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(20).Label = "Cause Flow";
            this.spdToolDefectData_Sheet1.Columns.Get(20).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(20).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(21).Label = "Cause Oper";
            this.spdToolDefectData_Sheet1.Columns.Get(21).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(21).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(22).Label = "Cause Resource";
            this.spdToolDefectData_Sheet1.Columns.Get(22).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(22).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(23).Label = "Cause Sub Resource";
            this.spdToolDefectData_Sheet1.Columns.Get(23).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(23).Width = 127F;
            this.spdToolDefectData_Sheet1.Columns.Get(24).Label = "Check User ID 1";
            this.spdToolDefectData_Sheet1.Columns.Get(24).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(24).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(25).Label = "Check User ID 2";
            this.spdToolDefectData_Sheet1.Columns.Get(25).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(25).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(26).Label = "Attach File 1";
            this.spdToolDefectData_Sheet1.Columns.Get(26).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(26).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(27).Label = "Attach File 2";
            this.spdToolDefectData_Sheet1.Columns.Get(27).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(27).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(28).Label = "Attach File 3";
            this.spdToolDefectData_Sheet1.Columns.Get(28).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(28).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(29).Label = "Attach File 4";
            this.spdToolDefectData_Sheet1.Columns.Get(29).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(29).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(30).Label = "Attach File 5";
            this.spdToolDefectData_Sheet1.Columns.Get(30).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(30).Width = 90F;
            this.spdToolDefectData_Sheet1.Columns.Get(31).Label = "Defect Comment";
            this.spdToolDefectData_Sheet1.Columns.Get(31).Locked = true;
            this.spdToolDefectData_Sheet1.Columns.Get(31).Width = 200F;
            this.spdToolDefectData_Sheet1.FrozenColumnCount = 3;
            this.spdToolDefectData_Sheet1.FrozenRowCount = 1;
            this.spdToolDefectData_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdToolDefectData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdToolDefectData_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdToolDefectData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolDefectData_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdToolDefectData_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdToolDefectData_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdToolDefectData_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdToolDefectData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolDefectData_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdToolDefectData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmRASViewToolDefectList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASViewToolDefectList";
            this.Text = "View Tool Defect Data";
            this.Activated += new System.EventHandler(this.frmRASViewToolDefectList_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefectCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).EndInit();
            this.grpOption2.ResumeLayout(false);
            this.grpOption2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdToolDefectData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdToolDefectData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        public bool LoadFlag
        {
            get
            {
                return b_load_flag;
            }
            set
            {
                b_load_flag = value;
            }
        }
        
        #endregion
        
        #region " Function Definition "
                
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String
        //
        private void ClearData(char ProcStep)
        {
            //            int i;
            
            try
            {
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //
        // ViewToolList_Detail_Local()
        //       - View Tool List by Oper (Local)
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void ViewToolDefectList_Detail_Local()
        {
            
            char sCleanFlag = ' ';
            char sProcStep;

            try
            {
                if (optAllData.Checked == true)
                {
                    sCleanFlag = ' ';
                }
                else if (optCleaned.Checked == true)
                {
                    sCleanFlag = 'Y';
                }
                else if (optNotCleaned.Checked == true)
                {
                    sCleanFlag = 'N';
                }

                if (cdvDefectCode.Text == "")
                {
                    sProcStep = '1';
                }
                else
                {
                    sProcStep = '4';
                }

                TRSNode in_node = new TRSNode("View_Tool_Defect_List_Detail_In");
                TRSNode out_node;
                int i;
                int iRow;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = sProcStep;
                in_node.AddChar("CLEAN_FLAG", sCleanFlag);
                in_node.AddChar("HIST_DEL_FLAG", 'N');
                in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));
                in_node.AddString("TOOL_ID", MPCF.Trim(cdvToolID.Text));
                in_node.AddString("NEXT_DEFECT_CODE", MPCF.Trim(cdvDefectCode.Text));

                out_node = new TRSNode("View_Tool_Defect_List_Detail_Out");

                if (MPCR.CallService("RAS", "RAS_View_Tool_Defect_List_Detail", in_node, ref out_node) == false)
                {
                    return;
                }


                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdToolDefectData.Sheets[0].RowCount;
                    spdToolDefectData.Sheets[0].RowCount++;
                    spdToolDefectData.Sheets[0].Cells[iRow, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOC_X")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOC_Y")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOC_Z"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DEFECT_CODE"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_EVENT_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_TYPE"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 8].Value = MPCF.Trim(out_node.GetList(0)[i].GetDouble("DEFECT_QTY"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 9].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_X")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_Y")) + ", " + MPCF.Trim(out_node.GetList(0)[i].GetInt("CELL_Z"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 10].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 11].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 12].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("CLEAN_FLAG"));
                    if (MPCF.Trim(out_node.GetList(0)[i].GetChar("CLEAN_FLAG")) == "Y")
                    {
                        spdToolDefectData.Sheets[0].Cells[iRow, 13].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("CLEAN_HIST_SEQ"));
                    }
                    else
                    {
                        spdToolDefectData.Sheets[0].Cells[iRow, 13].Value = " ";
                    }
                    spdToolDefectData.Sheets[0].Cells[iRow, 14].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CLEAN_USER_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 15].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CLEAN_TIME"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 16].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 17].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBLOT_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 18].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 19].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 20].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CAUSE_FLOW"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 21].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CAUSE_OPER"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 22].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CAUSE_RES_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 23].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CAUSE_SUBRES_ID"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 24].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_USER_ID1"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 25].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHK_USER_ID2"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 26].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("ATTACH_FILE_1"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 27].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("ATTACH_FILE_2"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 28].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("ATTACH_FILE_3"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 29].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("ATTACH_FILE_4"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 30].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("ATTACH_FILE_5"));
                    spdToolDefectData.Sheets[0].Cells[iRow, 31].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DEFECT_COMMENT"));
                    if (MPCF.Trim(out_node.GetList(0)[i].GetChar("CLEAN_FLAG")) == "Y")
                    {
                        spdToolDefectData.Sheets[0].Rows[iRow].ForeColor = Color.Magenta;
                    }
                    else
                    {
                        spdToolDefectData.Sheets[0].Rows[iRow].ForeColor = Color.Black;
                    }
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

            if (MPCF.CheckValue(cdvType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvToolID, 1) == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "View_Tool_Defect_List_Detail":
                    
                    break;
                    //Do Nothing
            }
            
            return true;
            
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
        
        private void frmRASViewToolDefectList_Activated(object sender, System.EventArgs e)
        {
            
            if (LoadFlag == false)
            {
                ClearData('1');
                LoadFlag = true;
            }
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition("ViewToolDefectList_Detail_Local") == true)
            {
                MPCF.ClearList(spdToolDefectData, true);
                ViewToolDefectList_Detail_Local();
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "Tool Type : " + MPCF.Trim(cdvType.Text) + "\r";
            sCond = sCond + "Tool ID : " + MPCF.Trim(cdvToolID.Text) + "\r";
            sCond = sCond + "Defect Code : " + MPCF.Trim(cdvDefectCode.Text) + "\r";
            
            if (optAllData.Checked == true)
            {
                sCond = sCond + "* " + optAllData.Text + "\r";
            }
            else if (optCleaned.Checked == true)
            {
                sCond = sCond + "* " + optCleaned.Text + "\r";
            }
            else if (optNotCleaned.Checked == true)
            {
                sCond = sCond + "* " + optNotCleaned.Text + "\r";
            }

            MPCF.ExportToExcel(spdToolDefectData, this.Text, sCond);
            
        }
        
        private void cdvType_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            
            RASLIST.ViewToolTypeList(cdvType.GetListView, '1', 'N', 'N', null);
        }
        
        private void cdvToolID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvToolID.Init();
            MPCF.InitListView(cdvToolID.GetListView);
            cdvToolID.Columns.Add("Tool ID", 50, HorizontalAlignment.Left);
            cdvToolID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolID.SelectedSubItemIndex = 0;
            RASLIST.ViewToolList(cdvToolID.GetListView, '2', cdvType.Text, ' ', false, null);
        }
        
        private void cdvDefectCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvDefectCode.Init();
            MPCF.InitListView(cdvDefectCode.GetListView);
            cdvDefectCode.Columns.Add("Tool Defect Code", 50, HorizontalAlignment.Left);
            cdvDefectCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvDefectCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvDefectCode.GetListView, '1', MPGC.MP_RAS_TOOL_DEFECT);
            cdvDefectCode.AddEmptyRow(1);
        }
        
        private void cdvType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdToolDefectData, true);
            cdvToolID.Text = "";
        }
        
        private void cdvToolID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdToolDefectData, true);
            if (cdvToolID.Text != "")
            {
                btnView_Click(sender, null);
            }
        }
        
        private void cdvDefectCode_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvToolID.Text != "")
            {
                btnView_Click(sender, null);
            }
        }
    }
    
    //#End If
}
