
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranCleanLotDefect.vb
//   Description : Clean Lot Defect
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-07 : Created by SKJIN
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
    public class frmWIPTranCleanLotDefect : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranCleanLotDefect()
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
        



        private System.Windows.Forms.GroupBox grpTranInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblUser2;
        private System.Windows.Forms.TextBox txtClearHistSeq;
        private System.Windows.Forms.CheckBox chkClearAllDefect;
        protected FarPoint.Win.Spread.FpSpread spdDefectData;
        protected FarPoint.Win.Spread.SheetView spdDefectData_LotInfo;
        protected System.Windows.Forms.Button btnDefectView;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.grpTranInfo = new System.Windows.Forms.GroupBox();
            this.btnDefectView = new System.Windows.Forms.Button();
            this.chkClearAllDefect = new System.Windows.Forms.CheckBox();
            this.txtClearHistSeq = new System.Windows.Forms.TextBox();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.spdDefectData = new FarPoint.Win.Spread.FpSpread();
            this.spdDefectData_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.pnlTranInfo.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            this.grpLotInfo.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTran.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTranInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTranInfo);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 235);
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 415);
            // 
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(722, 376);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 379);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.TabStop = true;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.TabStop = false;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 2);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.TabStop = false;
            // 
            // tabTran
            // 
            this.tabTran.Size = new System.Drawing.Size(736, 441);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 444);
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
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
            this.lblFormTitle.Text = "Clean Lot Defect";
            // 
            // grpTranInfo
            // 
            this.grpTranInfo.Controls.Add(this.btnDefectView);
            this.grpTranInfo.Controls.Add(this.chkClearAllDefect);
            this.grpTranInfo.Controls.Add(this.txtClearHistSeq);
            this.grpTranInfo.Controls.Add(this.lblUser2);
            this.grpTranInfo.Controls.Add(this.cdvResID);
            this.grpTranInfo.Controls.Add(this.lblResID);
            this.grpTranInfo.Controls.Add(this.spdDefectData);
            this.grpTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTranInfo.Location = new System.Drawing.Point(0, 0);
            this.grpTranInfo.Name = "grpTranInfo";
            this.grpTranInfo.Size = new System.Drawing.Size(722, 235);
            this.grpTranInfo.TabIndex = 6;
            this.grpTranInfo.TabStop = false;
            // 
            // btnDefectView
            // 
            this.btnDefectView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefectView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDefectView.Location = new System.Drawing.Point(176, 16);
            this.btnDefectView.Name = "btnDefectView";
            this.btnDefectView.Size = new System.Drawing.Size(88, 26);
            this.btnDefectView.TabIndex = 0;
            this.btnDefectView.Text = "Defect View";
            this.btnDefectView.Click += new System.EventHandler(this.btnDefectView_Click);
            // 
            // chkClearAllDefect
            // 
            this.chkClearAllDefect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkClearAllDefect.Location = new System.Drawing.Point(116, 106);
            this.chkClearAllDefect.Name = "chkClearAllDefect";
            this.chkClearAllDefect.Size = new System.Drawing.Size(115, 14);
            this.chkClearAllDefect.TabIndex = 3;
            this.chkClearAllDefect.Text = "Clear All Defect";
            this.chkClearAllDefect.CheckedChanged += new System.EventHandler(this.chkClearAllDefect_CheckedChanged);
            // 
            // txtClearHistSeq
            // 
            this.txtClearHistSeq.Location = new System.Drawing.Point(114, 130);
            this.txtClearHistSeq.MaxLength = 10;
            this.txtClearHistSeq.Name = "txtClearHistSeq";
            this.txtClearHistSeq.Size = new System.Drawing.Size(134, 20);
            this.txtClearHistSeq.TabIndex = 5;
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser2.Location = new System.Drawing.Point(8, 132);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(77, 13);
            this.lblUser2.TabIndex = 4;
            this.lblUser2.Text = "Clear Hist Seq.";
            this.lblUser2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(114, 62);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(138, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 2;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 138;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Location = new System.Drawing.Point(8, 64);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 1;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // spdDefectData
            // 
            this.spdDefectData.AccessibleDescription = "";
            this.spdDefectData.Dock = System.Windows.Forms.DockStyle.Right;
            this.spdDefectData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdDefectData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefectData.HorizontalScrollBar.Name = "";
            this.spdDefectData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdDefectData.HorizontalScrollBar.TabIndex = 2;
            this.spdDefectData.Location = new System.Drawing.Point(268, 16);
            this.spdDefectData.MoveActiveOnFocus = false;
            this.spdDefectData.Name = "spdDefectData";
            this.spdDefectData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdDefectData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdDefectData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDefectData_LotInfo});
            this.spdDefectData.Size = new System.Drawing.Size(451, 216);
            this.spdDefectData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdDefectData.TabIndex = 6;
            this.spdDefectData.TabStop = false;
            this.spdDefectData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdDefectData.TextTipDelay = 200;
            this.spdDefectData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDefectData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefectData.VerticalScrollBar.Name = "";
            this.spdDefectData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdDefectData.VerticalScrollBar.TabIndex = 3;
            this.spdDefectData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdDefectData_CellClick);
            // 
            // spdDefectData_LotInfo
            // 
            this.spdDefectData_LotInfo.Reset();
            spdDefectData_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDefectData_LotInfo.ColumnCount = 11;
            spdDefectData_LotInfo.RowCount = 1;
            this.spdDefectData_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefectData_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 0).Value = "Tran Time";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 1).Value = "Defect Code";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 2).Value = "Sub Lot ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 3).Value = "Count";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 4).Value = "Loc X";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 5).Value = "Loc Y";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 6).Value = "Loc Z";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 7).Value = "Cell X";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 8).Value = "Cell Y";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 9).Value = "Cell Z";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 10).Value = "Hist Seq.";
            this.spdDefectData_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefectData_LotInfo.Columns.Get(0).Label = "Tran Time";
            this.spdDefectData_LotInfo.Columns.Get(0).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(0).Width = 106F;
            this.spdDefectData_LotInfo.Columns.Get(1).BackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefectData_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDefectData_LotInfo.Columns.Get(1).Label = "Defect Code";
            this.spdDefectData_LotInfo.Columns.Get(1).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefectData_LotInfo.Columns.Get(1).Width = 76F;
            this.spdDefectData_LotInfo.Columns.Get(2).Label = "Sub Lot ID";
            this.spdDefectData_LotInfo.Columns.Get(2).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(2).Width = 114F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999D;
            numberCellType1.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(3).CellType = numberCellType1;
            this.spdDefectData_LotInfo.Columns.Get(3).Label = "Count";
            this.spdDefectData_LotInfo.Columns.Get(3).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(3).Width = 52F;
            this.spdDefectData_LotInfo.Columns.Get(4).CellType = numberCellType2;
            this.spdDefectData_LotInfo.Columns.Get(4).Label = "Loc X";
            this.spdDefectData_LotInfo.Columns.Get(4).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(4).Width = 54F;
            this.spdDefectData_LotInfo.Columns.Get(5).CellType = numberCellType3;
            this.spdDefectData_LotInfo.Columns.Get(5).Label = "Loc Y";
            this.spdDefectData_LotInfo.Columns.Get(5).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(5).Width = 53F;
            this.spdDefectData_LotInfo.Columns.Get(6).CellType = numberCellType4;
            this.spdDefectData_LotInfo.Columns.Get(6).Label = "Loc Z";
            this.spdDefectData_LotInfo.Columns.Get(6).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(6).Width = 52F;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.MaximumValue = 9999999D;
            numberCellType5.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(7).CellType = numberCellType5;
            this.spdDefectData_LotInfo.Columns.Get(7).Label = "Cell X";
            this.spdDefectData_LotInfo.Columns.Get(7).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(7).Width = 56F;
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.MaximumValue = 9999999D;
            numberCellType6.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(8).CellType = numberCellType6;
            this.spdDefectData_LotInfo.Columns.Get(8).Label = "Cell Y";
            this.spdDefectData_LotInfo.Columns.Get(8).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(8).Width = 55F;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.MaximumValue = 9999999D;
            numberCellType7.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(9).CellType = numberCellType7;
            this.spdDefectData_LotInfo.Columns.Get(9).Label = "Cell Z";
            this.spdDefectData_LotInfo.Columns.Get(9).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(9).Width = 52F;
            this.spdDefectData_LotInfo.Columns.Get(10).Label = "Hist Seq.";
            this.spdDefectData_LotInfo.Columns.Get(10).Locked = true;
            this.spdDefectData_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.RowHeader.Columns.Default.Resizable = true;
            this.spdDefectData_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDefectData_LotInfo.Rows.Default.Height = 17F;
            this.spdDefectData_LotInfo.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdDefectData_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPTranCleanLotDefect
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranCleanLotDefect";
            this.Text = "Clean Lot Defect";
            this.Activated += new System.EventHandler(this.frmWIPTranCleanLotDefect_Activated);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlGeneralTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            this.grpLotInfo.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTran.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpTranInfo.ResumeLayout(false);
            this.grpTranInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        
        #endregion
        
        #region " Variable Definition "
        
        bool LoadFlag;
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this);
                    MPCF.ClearList(spdDefectData);
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
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string ProcStep)
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            
            if (chkClearAllDefect.Checked == false)
            {
                if (MPCF.CheckValue(txtClearHistSeq, 2) == false)
                {
                    return false;
                }
            }
            
            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }
            
            return true;
            
        }

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            MPCF.FieldClear(this, txtLotID);
            MPCF.ClearList(spdDefectData);

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            return true;
        }

        private bool ViewSublotList(ListView control, string sLotId)
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("View_Sublot_List_In");
            TRSNode out_node = new TRSNode("View_Sublot_List_Out");

            MPCF.InitListView(control);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("SUBLOT_ID"), (int)SMALLICON_INDEX.IDX_SLOT_FULL);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("SLOT_NO").ToString());
                    control.Items.Add(itmX);

                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            return true;

        }

        
        //
        // GetFlowList()
        //       - Get Flow List by Material
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal cdvList As MCCodeView.MCCodeView : Flow List
        //
        private bool GetFlowList(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList)
        {
            
            try
            {
                cdvList.Init();
                MPCF.InitListView(cdvList.GetListView);
                cdvList.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvList.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvList.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewFlowList(cdvList.GetListView, '1', "",0, "", null, "") == false)
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
        
        //
        // GetOperationList()
        //       - Get Operation List by Flow
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow
        //
        private bool GetOperationList(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList, string sFlow)
        {
            
            try
            {
                cdvList.Init();
                MPCF.InitListView(cdvList.GetListView);
                cdvList.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvList.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvList.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvList.GetListView, '2', "", 0,sFlow, "", null, "") == false)
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

        private bool ViewLotDefectList()
        {

            int i;
            int iRow;

            TRSNode in_node = new TRSNode("View_Lot_Defect_List_Detail_In");
            TRSNode out_node = new TRSNode("View_Lot_Defect_List_Detail_Out");


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            MPCF.ClearList(spdDefectData);
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_Defect_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    FarPoint.Win.Spread.SheetView with_1 = spdDefectData.Sheets[0];

                    iRow = with_1.RowCount;
                    with_1.RowCount++;

                    with_1.Cells[iRow, 0].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                    with_1.Cells[iRow, 1].Value = out_node.GetList(0)[i].GetString("DEFECT_CODE");
                    with_1.Cells[iRow, 2].Value = out_node.GetList(0)[i].GetString("SUBLOT_ID");
                    with_1.Cells[iRow, 3].Value = out_node.GetList(0)[i].GetDouble("DEFECT_QTY");
                    with_1.Cells[iRow, 4].Value = out_node.GetList(0)[i].GetDouble("LOC_X");
                    with_1.Cells[iRow, 5].Value = out_node.GetList(0)[i].GetDouble("LOC_Y");
                    with_1.Cells[iRow, 6].Value = out_node.GetList(0)[i].GetDouble("LOC_Z");
                    with_1.Cells[iRow, 7].Value = out_node.GetList(0)[i].GetInt("CELL_X");
                    with_1.Cells[iRow, 8].Value = out_node.GetList(0)[i].GetInt("CELL_Y");
                    with_1.Cells[iRow, 9].Value = out_node.GetList(0)[i].GetInt("CELL_Z");
                    with_1.Cells[iRow, 10].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");

                }

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

            } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_SEQ_NUM") > 0);

            return true;

        }
        //
        // Clean_Lot_Defect()
        //       - Clean Defect Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Clean_Lot_Defect(char ProcStep)
        {
            TRSNode in_node = new TRSNode("Clean_Lot_Defect_In");
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                if (chkClearAllDefect.Checked == true)
                {
                    in_node.AddChar("CLEAR_ALL_DEFECT", 'Y');
                    in_node.AddInt("CLEAR_HIST_SEQ", 0);
                }
                else
                {
                    in_node.AddChar("CLEAR_ALL_DEFECT", ' ');
                    in_node.AddInt("CLEAR_HIST_SEQ", MPCF.ToInt(txtClearHistSeq.Text));
                }

                in_node.AddString("DEFECT_COMMENT", MPCF.Trim(txtComment.Text));


                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (MPCR.CallService("WIP", "WIP_Clean_Lot_Defect", in_node, ref out_node) == false)
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

        
        
        #endregion
        
        private void frmWIPTranCleanLotDefect_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (LoadFlag == false)
                {
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_CLEAN_LOT_DEFECT);
                    
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
                    }
                    
                    LoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }

            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
#if _RAS
            if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
            {
                return;
            }
#endif
            
        }
        
        private void btnDefectView_Click(System.Object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }
            
            if (ViewLotDefectList() == false)
            {
                return;
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {

            if (CheckCondition("1") == false) return;
            if (Clean_Lot_Defect('1') == false) return;

            ViewLotInfo(txtLotID.Text);
        }
        
        private void chkClearAllDefect_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkClearAllDefect.Checked == true)
            {
                txtClearHistSeq.Text = "";
                txtClearHistSeq.Enabled = false;
            }
            else
            {
                txtClearHistSeq.Enabled = true;
            }
        }
        
        private void spdDefectData_CellClick(System.Object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (txtClearHistSeq.Enabled == true)
            {
                txtClearHistSeq.Text = MPCF.Trim(spdDefectData.Sheets[0].GetValue(e.Row, 10));
            }
        }
        
        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                ClearData("1");
            }
        }
        
    }
    
}
